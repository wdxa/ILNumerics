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
using ILNumerics.Misc; 

namespace ILNumerics.Drawing.Shapes {
    public abstract class ILCompositeShape<VertexType> : ILShape<VertexType> 
        where VertexType : struct, IILVertexDefinition {

        #region eventing 
        #endregion

        #region attributes
        /// <summary>
        /// actual indices used for rendering (sorted for translucent shapes)
        /// </summary>
        protected int[] m_renderIndices;
        /// <summary>
        /// cache indices defining each shapes corners
        /// </summary>
        protected ILArray<int> m_shapeIndices; 
        /// <summary>
        /// cache camera position of last sorting
        /// </summary>
        protected ILPoint3Df m_oldCameraPosition;

        private float[] m_vertexPositions; 
        #endregion

        #region properties
        /// <summary>
        /// Indices used to render primitives from vertices 
        /// </summary>
        public ILArray<int> Indices {
            get {
                return m_shapeIndices; 
            }
            set {
                m_shapeIndices = value; 
            }
        }
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
            Update(X, Y, Z, mapping);
            Opacity = 255; 
            m_shading = ShadingStyles.Interpolate; 
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
            Update(X, Y, Z);
            m_shapeIndices = ILMath.toint32(
                ILMath.counter(0.0, 1.0, VerticesPerShape, m_vertCount / VerticesPerShape));
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
            Update(X, Y, Z, colors, mapping);
            Opacity = 255;
            m_shading = ShadingStyles.Interpolate; 
        }

        #endregion

        #region public interface 
        public void Update(ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) {
            if (!X.IsVector || !Y.IsVector || !Z.IsVector || X.Length != Y.Length || Y.Length != Z.Length) {
                throw new ILArgumentException("numeric vectors of same length expected for: X, Y and Z");
            }
            if (mapping == null || mapping.IsEmpty || !mapping.IsMatrix || !mapping.IsNumeric || mapping.Dimensions[0] != VerticesPerShape)
                throw new ILArgumentException("mapping must be a numeric matrix, " + VerticesPerShape.ToString() + " rows, each column specifies indices for the vertices of a single shape.");
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
            Invalidate();
        }
        public void Update(ILBaseArray X, ILBaseArray Y, ILBaseArray Z) {
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
            Invalidate();
        }
        public void Update(ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray colors, ILBaseArray mapping) {
            if (!VertexDefinition.StoresColor)
                throw new NotSupportedException("The underlying vertex type cannot store individual color values! Use another shape or flat shading!");
            if (!X.IsVector || !Y.IsVector || !Z.IsVector || X.Length != Y.Length || Y.Length != Z.Length) {
                throw new ILArgumentException("numeric vectors of same length expected for: X, Y and Z");
            }
            if ((colors.Dimensions[1] != 3 && colors.Dimensions[1] != 4) || colors.Length != X.Length)
                throw new ILArgumentException("invalid size of colors data! Colors must have 3 or 4 columns with color components (RGB) or alpha value + color components (ARGB) respectively. Number of rows must match number of vertices.");
            if (mapping == null || mapping.IsEmpty || !mapping.IsMatrix || !mapping.IsNumeric || mapping.Dimensions[0] != VerticesPerShape)
                throw new ILArgumentException("mapping must be a numeric matrix, " + VerticesPerShape.ToString() + " rows, each column specifies indices for the vertices of a single shape.");
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
                            fcol.GetValue(i, 0),
                            fcol.GetValue(i, 1),
                            fcol.GetValue(i, 2));
                }
            } else if (fcol.Dimensions[1] == 4) {
                for (int i = 0; i < m_vertices.Length; i++) {
                    m_vertices[i].XPosition = fX.GetValue(i);
                    m_vertices[i].YPosition = fY.GetValue(i);
                    m_vertices[i].ZPosition = fZ.GetValue(i);
                    m_vertices[i].Color = Color.FromArgb(
                            fcol.GetValue(i, 1),
                            fcol.GetValue(i, 2),
                            fcol.GetValue(i, 3));
                    m_vertices[i].Alpha = fcol.GetValue(i);
                }
            }
            Invalidate();
        }
        protected override void IntDrawShape(ILRenderProperties props) {
            if (m_vertCount >= VerticesPerShape) {
                // draw from back to front
                if (m_oldCameraPosition != m_panel.Camera.Position
                    || m_renderIndices == null) {
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
        protected override void  ComputeLimits() {
 	         base.ComputeLimits();
             updateVertexPositions(Vertices, ref m_vertexPositions);
        }
        protected override void IntConfigure() {
            // nothing to do here ...
        }
        #endregion

        #region private helper

        //protected void sortPrimitives() {
        //    m_oldCameraPosition = m_panel.Camera.Position;
        //    Computation.SortIndices(
        //                m_vertices, m_shapeIndices, m_vertCount, m_panel.Camera.Position,
        //                VerticesPerShape).ExportValues(ref m_renderIndices);
        //}

        private void sortPrimitives() {
            m_oldCameraPosition = m_panel.Camera.Position;
            if (m_renderIndices == null || m_renderIndices.Length < m_shapeIndices.Dimensions.NumberOfElements)
                m_renderIndices = new int[m_shapeIndices.Dimensions.NumberOfElements];
            float camScale = (ILPoint3Df.Max(m_positionMax, m_positionMin) - m_positionCenter).GetLength(); 
            Computation.SortIndices(
                        m_vertexPositions
                        , m_shapeIndices
                        , m_vertCount
                        , m_panel.Camera.LookAt + ((m_panel.Camera.LookAt - m_panel.Camera.Position) * camScale)
                        , VerticesPerShape
                        , m_renderIndices);
        }
        
        private void updateVertexPositions(VertexType[] vertices, ref float[] vertexPositions) {
            if (vertexPositions == null || vertexPositions.Length < 3 * vertices.Length) {
                vertexPositions = new float[3 * vertices.Length];
            }
            int p = 0;
            if (vertices is C4bV3f[]) {
                C4bV3f[] verticesC4bV3f = (C4bV3f[])(object)vertices; 
                foreach (C4bV3f vertex in verticesC4bV3f) {
                    vertexPositions[p++] = vertex.XPosition;
                    vertexPositions[p++] = vertex.YPosition;
                    vertexPositions[p++] = vertex.ZPosition;
                }
            } else if (vertices is C4fN3fV3f[]) {
                C4fN3fV3f[] verticesC4fN3fV3f = (C4fN3fV3f[])(object)vertices; 
                foreach (C4fN3fV3f vertex in verticesC4fN3fV3f) {
                    vertexPositions[p++] = vertex.XPosition;
                    vertexPositions[p++] = vertex.YPosition;
                    vertexPositions[p++] = vertex.ZPosition;
                }
            } 
            // ... more vertex types here? 
        }

        private class Computation : ILMath {
            public static void SortIndices(float[] vertPositions,
                                            ILArray<int> shapeIndices, int vertCount,
                                            ILPoint3Df camera, int vertPerPrimitive, int[] renderIndices) {
                ////System.Diagnostics.Debug.Assert(Math.IEEERemainder(vertCount,vertPerPrimitive) == 0); 
                //float[] posArr = new float[3*vertCount]; 
                //int p = 0; 
                //foreach (VertexType vertex in vertices) {
                //    posArr[p++] = vertex.XPosition; 
                //    posArr[p++] = vertex.YPosition; 
                //    posArr[p++] = vertex.ZPosition; 
                //}
                bool dummy;
                float[] dist = ILMemoryPool.Pool.New<float>(vertPositions.Length / 3, false, out dummy);
                float camx = camera.X, camy = camera.Y, camz = camera.Z;
                for (int distPos = 0, vPos = 0; distPos < dist.Length; distPos++) {
                    float tmpX = vertPositions[vPos++] - camx;
                    float tmpY = vertPositions[vPos++] - camy;
                    float tmpZ = vertPositions[vPos++] - camz;
                    dist[distPos] = tmpX * tmpX + tmpY * tmpY + tmpZ * tmpZ;
                }
#if DEBUG
                //ILArray<double> indDeb; 
                //ILArray<float> minID = sort(new ILArray<float>(dist, 1, dist.Length), out indDeb,1,false);
                //System.Diagnostics.Debug.Write("ind: " + shapeIndices.ValuesToString(0));
                //System.Diagnostics.Debug.Write("dist: " + new ILArray<float>(dist, 1, dist.Length).ValuesToString(0));
                //System.Diagnostics.Debug.Write("dist[ind]: " + (new ILArray<float>(dist, 1, dist.Length)[shapeIndices]).ValuesToString(0));
                //System.Diagnostics.Debug.Write("sum(dist[ind]): " + sum(new ILArray<float>(dist, 1, dist.Length)[shapeIndices]).ValuesToString(0));
#endif
                dist = sum(new ILArray<float>(dist, 1, dist.Length)[shapeIndices], 0).InternalArray4Experts;
                double[] idx = counter(0.0, 1.0, 1, dist.Length).InternalArray4Experts;
                Algorithms.ILQuickSort.QuickSortAscSolidIDX(dist, idx, 0, dist.Length - 1, 1);
                // ind: indices into shapeIndices' columns 
                shapeIndices[null, (ILArray<double>)idx].ExportValues(ref renderIndices);
            }

            //public static ILArray<int> SortIndices(VertexType[] vertices,
            //                                ILArray<int> shapeIndices, int vertCount,
            //                                ILPoint3Df camera, int vertPerPrimitive) {
            //    //System.Diagnostics.Debug.Assert(Math.IEEERemainder(vertCount,vertPerPrimitive) == 0); 
            //    float[] posArr = new float[3 * vertCount];
            //    int p = 0;
            //    foreach (VertexType vertex in vertices) {
            //        posArr[p++] = vertex.XPosition;
            //        posArr[p++] = vertex.YPosition;
            //        posArr[p++] = vertex.ZPosition;
            //    }
            //    ILArray<float> pos = new ILArray<float>(posArr, 3, vertCount);
            //    ILArray<float> cam = new ILArray<float>(
            //                         new float[] { camera.X, camera.Y, camera.Z }, 3, 1);
            //    // flip the camera around and move it outside the scene 
            //    ILArray<double> ind = null;
            //    cam = -cam * maxall(pos);
            //    cam = repmat(cam, 1, vertCount);
            //    pos = pos - cam;
            //    pos = sum(pos * pos, 0);   // pos holds distances for eaech vertex now
            //    // sort per primitive
            //    pos = sum(reshape(pos[shapeIndices[":"]], vertPerPrimitive, shapeIndices.Dimensions[1]), 0);
            //    ind = ILArray<double>.empty();
            //    sort(pos, out ind, 1, false);
            //    // ind: indices into shapeIndices' columns 
            //    return shapeIndices[null, ind][":"];
            //}

        }

        #endregion
    }
}
