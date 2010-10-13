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
using ILNumerics.Exceptions;
using ILNumerics.Drawing.Interfaces;  
using ILNumerics.Drawing.Controls; 
namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// Base class for all simple shapes, rendering a primitive 
    /// with a border, which is independantly configurable. 
    /// </summary>
    /// <typeparam name="VertexType">inner vertex element type (struct)</typeparam>
    public abstract class ILBorderedShape<VertexType> : ILShape<VertexType> 
        where VertexType : struct, IILVertexDefinition {

        #region eventing 
        #endregion

        #region attributes
        protected ILLineProperties m_border; 
        #endregion

        #region properties 
        /// <summary>
        /// get reference to the properties of the shapes border 
        /// </summary>
        public ILLineProperties Border {
            get {
                return m_border; 
            }
        }
        #endregion

        /// <summary>
        /// create new bordered shape
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="numVertices">number of vertices, this bordered shape will be made out of</param>
        public ILBorderedShape (ILPanel panel, int numVertices) 
            : base(panel,numVertices,numVertices) {
            m_border = new ILLineProperties();
            m_border.Changed += new EventHandler(m_border_Changed);
            m_fillColor = Color.Yellow;
            m_border.Width = 1; 
            m_border.Antialiasing = false; 
            m_border.Color = Color.Bisque; 
            m_shading = ShadingStyles.Flat; 
            m_vertexStoresColor = false; 
        }
        /// <summary>
        /// create new bordered shape, provide initial vertex data
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="X">X coordinates, vector of length 'VertexCount'</param>
        /// <param name="Y">Y coordinates, vector of length 'VertexCount'</param>
        /// <param name="Z">Z coordinates, vector of length 'VertexCount'</param>
        public ILBorderedShape(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : this(panel, (X != null && X.IsVector) ? X.Length 
                           : (Y != null && Y.IsVector) ? Y.Length
                           : (Z != null && Z.IsVector) ? Z.Length
                           : 0) {
            Update(X, Y, Z);
        }
        /// <summary>
        /// update vertices of the shape
        /// </summary>
        /// <param name="X">X positions vector</param>
        /// <param name="Y">Y positions vector</param>
        /// <param name="Z">Z positions vector</param>
        /// <remarks>Updates are made to the positions of the vectors only. X, Y and Z must be 
        /// vectors of length <see cref="ILNumerics.Drawing.Shapes.ILShape.VertexCount"/>.</remarks>
        public virtual void Update(ILBaseArray X, ILBaseArray Y, ILBaseArray Z) {
            ILArray<double> x = null, y = null, z = null;
            int minLen = 0;
            if (X != null) { 
                if (!X.IsVector)
                    throw new ILArgumentException("X must be vector!");
                x = ILNumerics.BuiltInFunctions.ILMath.todouble(X);
                minLen = X.Length;
            }
            if (Y != null) {
                if (!Y.IsVector)
                    throw new ILArgumentException("Y must be vector!");
                y = ILNumerics.BuiltInFunctions.ILMath.todouble(Y);
                minLen = Math.Min(minLen, Y.Length);
            }
            if (Z != null) {
                if (!Z.IsVector)
                    throw new ILArgumentException("Z must be vector!");
                z = ILNumerics.BuiltInFunctions.ILMath.todouble(Z);
                minLen = Math.Min(minLen, Z.Length);
            }
            for (int i = 0; i < Vertices.Length && i < minLen; i++) {
                Vertices[i].Position = new ILPoint3Df(x.GetValue(i),y.GetValue(i),z.GetValue(i)); 
                //VertexType v = new VertexType();
                //if (x != null) v.XPosition = x.GetValue(i);
                //if (y != null) v.YPosition = y.GetValue(i);
                //if (z != null) v.ZPosition = z.GetValue(i);
                //Vertices[i] = v;
            }
            Invalidate();
        }


        void m_border_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        protected override void IntDrawShape(ILRenderProperties props) {
            if (m_vertCount == 0 || m_vertCount >= VerticesPerShape) {
                m_renderer.Draw(props,this);   
            }
        }
        protected override void IntDrawLabel(ILRenderProperties props) {
            if (m_vertCount == 0 || m_vertCount >= VerticesPerShape) {
                if (!String.IsNullOrEmpty(m_label.Text) && m_vertCount > 1) {
                    ILPoint3Df cent = m_vertices[0].Position + m_vertices[1].Position;
                    m_label.Draw(props, cent / 2); 
                }
            }
        }
    }
}
