#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details.
//
#endregion

using System;
using System.Drawing; 
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Graphs; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Shapes {
    public abstract class ILCompositeShape<VertexType> : ILShape<VertexType> 
        where VertexType : struct, IILVertexDefinition {

        #region eventing 
        #endregion

        #region attributes
        /// <summary>
        /// actual indices used for rendering (sorted for translucent shapes)
        /// </summary>
        protected ILArray<int> m_renderIndices;
        /// <summary>
        /// cache indices defining each shapes corners
        /// </summary>
        protected ILArray<int> m_shapeIndices; 
        /// <summary>
        /// cache camera position of last sorting
        /// </summary>
        protected ILPoint3Df m_oldCameraPosition;
        #endregion

        #region properties
        #endregion

        #region constructors
        /// <summary>
        /// create composite shape
        /// </summary>
        /// <param name="panel">scene hosting the scene</param>
        /// <param name="numVertices">number of overall vertices for the shape</param>
        public ILCompositeShape (ILPanel panel, int numVertices, int verticesPerShape) 
            : base(panel,numVertices,verticesPerShape) {
            Opacity = 255; 
            m_shapeIndices = ILMath.toint32(
                ILMath.counter(0.0,1.0,VerticesPerShape,numVertices / VerticesPerShape)); 
        }
        /// <summary>
        /// create composite shape 
        /// </summary>
        /// <param name="panel">hosting panel</param>
        /// <param name="verticesPerShape">number of vertices per shape</param>
        /// <param name="X">x coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Y">y coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Z">z coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="mapping">Composes shapes out of vertices. Matrix having [verticesPerShape] rows.
        /// Every element in a column specifies the index of a vertex according to its position in X,Y,Z.#
        /// The [verticesPerShape] elements in a column therefore compose a single shape. Vertices may 
        /// get used arbitrary times (or not at all). All elements must be positive integer values in 
        /// range 0...[vertCount-1].</param>
        public ILCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel,X.Length,verticesPerShape) {
            if (!X.IsVector || !Y.IsVector || !Z.IsVector || X.Length != Y.Length || Y.Length != Z.Length) {
                throw new ILArgumentException("numeric vectors of same length expected for: X, Y and Z"); 
            }
            if (mapping == null || mapping.IsEmpty || !mapping.IsMatrix || !mapping.IsNumeric || mapping.Dimensions[0] != verticesPerShape) 
                throw new ILArgumentException("mapping must be a numeric matrix, "+verticesPerShape.ToString()+" rows, each column specifies indices for the vertices of a single shape."); 
            if (mapping is ILArray<int>) 
                m_shapeIndices = (mapping as ILArray<int>).C; 
            else 
                m_shapeIndices = ILMath.toint32(mapping); 
            ILArray<float> fX = ILMath.tosingle(X); 
            ILArray<float> fY = ILMath.tosingle(Y); 
            ILArray<float> fZ = ILMath.tosingle(Z); 
            for (int i = 0; i < m_vertices.Length; i++) {
                m_vertices[i].XPosition = fX.GetValue(i);     
                m_vertices[i].YPosition = fY.GetValue(i);     
                m_vertices[i].ZPosition = fZ.GetValue(i);     
			}
            m_panel = panel; 
            Opacity = 255; 
            m_shading = ShadingStyles.Flat; 
        }
        /// <summary>
        /// create composite shape 
        /// </summary>
        /// <param name="panel">hosting panel</param>
        /// <param name="verticesPerShape">number of vertices per shape</param>
        /// <param name="X">x coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Y">y coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Z">z coordinates (true world coords), vector with [vertCount] values</param>
        /// <remarks>The constructor creates a new composite shape out of all vertices specified in X,Y and Z.
        /// Every vertex is only used once. Every shape uses [verticesPerShape] vertices one after another.</remarks>
        public ILCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,X.Length,verticesPerShape) {
            if (!X.IsVector || !Y.IsVector || !Z.IsVector || X.Length != Y.Length || Y.Length != Z.Length) {
                throw new ILArgumentException("numeric vectors of same length expected for: X, Y and Z"); 
            }
            ILArray<float> fX = ILMath.tosingle(X); 
            ILArray<float> fY = ILMath.tosingle(Y); 
            ILArray<float> fZ = ILMath.tosingle(Z); 
            for (int i = 0; i < m_vertices.Length; i++) {
                m_vertices[i].XPosition = fX.GetValue(i);     
                m_vertices[i].YPosition = fY.GetValue(i);     
                m_vertices[i].ZPosition = fZ.GetValue(i);     
			}
            m_shapeIndices = ILMath.toint32(
                ILMath.counter(0.0,1.0,VerticesPerShape, m_vertCount / VerticesPerShape)); 
            m_panel = panel; 
            Opacity = 255; 
            m_shading = ShadingStyles.Flat; 
        }
        /// <summary>
        /// create composite shape 
        /// </summary>
        /// <param name="panel">hosting panel</param>
        /// <param name="verticesPerShape">number of vertices per shape</param>
        /// <param name="X">x coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Y">y coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="Z">z coordinates (true world coords), vector with [vertCount] values</param>
        /// <param name="colors">matrix with [vertCount] rows, 3 columns for (R,G,B) or 4 columns for 
        /// (A,R,G,B) for every vertex specified by X,Y,Z. Elements must range from 0..255. If colors 
        /// has 3 columns only, an alpha value of 255 is used as default.</param>
        /// <param name="mapping">Composes shapes out of vertices. Matrix having [verticesPerShape] rows.
        /// Every element in a column specifies the index of a vertex according to its position in X,Y,Z.#
        /// The [verticesPerShape] elements in a column therefore compose a single shape. Vertices may 
        /// get used arbitrary times (or not at all). All elements must be positive integer values in 
        /// range 0...[vertCount-1].</param>
        public ILCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray colors, ILBaseArray mapping) 
            : base (panel,X.Length,verticesPerShape) {
            if (!VertexDefinition.StoresColor) 
                throw new NotSupportedException("The underlying vertex type cannot store individual color values! Use another shape or flat shading!"); 
            if (!X.IsVector || !Y.IsVector || !Z.IsVector || X.Length != Y.Length || Y.Length != Z.Length) {
                throw new ILArgumentException("numeric vectors of same length expected for: X, Y and Z"); 
            }
            if ((colors.Dimensions[1] != 3 && colors.Dimensions[1] != 4) || colors.Dimensions[0] != X.Length) 
                throw new ILArgumentException("invalid size of colors data! Colors must have 3 or 4 columns with color components (RGB) or alpha value + color components (ARGB) respectively. Number of rows must match number of vertices."); 
            if (mapping == null || mapping.IsEmpty || !mapping.IsMatrix || !mapping.IsNumeric || mapping.Dimensions[0] != verticesPerShape) 
                throw new ILArgumentException("mapping must be a numeric matrix, "+verticesPerShape.ToString()+" rows, each column specifies indices for the vertices of a single shape."); 
            if (mapping is ILArray<int>) 
                m_shapeIndices = (mapping as ILArray<int>).C; 
            else 
                m_shapeIndices = ILMath.toint32(mapping); 
            if (m_shapeIndices.MinValue < 0 || m_shapeIndices.MaxValue >= X.Dimensions[1]) {
                throw new ILArgumentException("invalid mapping: indices must point to existing vertex indices"); 
            }
            ILArray<float> fX = ILMath.tosingle(X); 
            ILArray<float> fY = ILMath.tosingle(Y); 
            ILArray<float> fZ = ILMath.tosingle(Z); 
            ILArray<byte> fcol = ILMath.tobyte(colors); 
            if (fcol.Dimensions[1] == 3) {
                for (int i = 0; i < m_vertices.Length; i++) {
                    m_vertices[i].XPosition = fX.GetValue(i);     
                    m_vertices[i].YPosition = fY.GetValue(i);     
                    m_vertices[i].ZPosition = fZ.GetValue(i); 
                    m_vertices[i].Color = Color.FromArgb(
                            fcol.GetValue(i,0),
                            fcol.GetValue(i,1),
                            fcol.GetValue(i,2)); 
			    }
            } else if (fcol.Dimensions[1] == 4) {
                for (int i = 0; i < m_vertices.Length; i++) {
                    m_vertices[i].XPosition = fX.GetValue(i);     
                    m_vertices[i].YPosition = fY.GetValue(i);     
                    m_vertices[i].ZPosition = fZ.GetValue(i); 
                    m_vertices[i].Color = Color.FromArgb(
                            fcol.GetValue(i,1),
                            fcol.GetValue(i,2),
                            fcol.GetValue(i,3)); 
                    m_vertices[i].Alpha = fcol.GetValue(i); 
			    }
            }
            m_panel = panel; 
            Opacity = 255;
            m_shading = ShadingStyles.Interpolate; 
        }
        #endregion

        #region public interface 
        protected override void IntDrawShape(ILRenderProperties props) {
            if (m_vertCount >= VerticesPerShape) {
                // draw from back to front
                if (m_oldCameraPosition != m_panel.Camera.Position) {
                    sortPrimitives(); 
                }
                m_renderer.Draw(props,this,m_renderIndices);
            }
        }
        protected override void IntDrawLabel(ILRenderProperties props) {
            if (m_vertCount >= VerticesPerShape) {
                ILPoint3Df cent = m_vertices[m_shapeIndices.GetValue(0)].Position; 
                // draw label at center of first shape
                if (!String.IsNullOrEmpty(m_label.Text)) {
                    for (int i = 1; i < VerticesPerShape; i++) {
                        cent += m_vertices[m_shapeIndices.GetValue(i)].Position;
                    }
                    m_label.Draw(props, cent / VerticesPerShape); 
                }
            }
        }
        protected void sortPrimitives () {
            m_oldCameraPosition = m_panel.Camera.Position; 
            m_renderIndices = Computation.SortIndices(
                        m_vertices,m_shapeIndices,m_vertCount,m_panel.Camera.Position,
                        VerticesPerShape);
        }
        #endregion

        private class Computation : ILMath {
            public static ILArray<int> SortIndices(VertexType[] vertices, 
                                            ILArray<int> shapeIndices,int vertCount, 
                                            ILPoint3Df camera, int vertPerPrimitive) {
                //System.Diagnostics.Debug.Assert(Math.IEEERemainder(vertCount,vertPerPrimitive) == 0); 
                float[] posArr = new float[3*vertCount]; 
                int p = 0; 
                foreach (VertexType vertex in vertices) {
                    posArr[p++] = vertex.XPosition; 
                    posArr[p++] = vertex.YPosition; 
                    posArr[p++] = vertex.ZPosition; 
                }
                ILArray<float> pos = new ILArray<float>(posArr,3,vertCount); 
                ILArray<float> cam = new ILArray<float>(
                                     new float[] {camera.X, camera.Y, camera.Z},3,1); 
                // flip the camera around and move it outside the scene 
                ILArray<double> ind = null; 
                cam = -cam * maxall(pos);
                cam = repmat(cam,1,vertCount); 
                pos = pos - cam;
                pos = sum(pos * pos,0);   // pos holds distances for eaech vertex now
                // sort per primitive
                pos = sum(reshape(pos[shapeIndices[":"]], vertPerPrimitive, shapeIndices.Dimensions[1]),0);
                ind = ILArray<double>.empty();
                sort(pos,out ind,1,false); 
                // ind: indices into shapeIndices' columns 
                return shapeIndices[null,ind][":"]; 
            }
        }
    }
}
