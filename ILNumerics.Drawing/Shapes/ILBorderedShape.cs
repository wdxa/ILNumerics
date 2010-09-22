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

        public ILLineProperties Border {
            get {
                return m_border; 
            }
        }
        #endregion

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
        public ILBorderedShape(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : this(panel, (X != null && X.IsVector) ? X.Length 
                           : (Y != null && Y.IsVector) ? Y.Length
                           : (Z != null && Z.IsVector) ? Z.Length
                           : 0) {
            ILArray<float> x = null,y = null,z = null;
            int minLen = 0; 
            if (X != null) {
                if (!X.IsVector)
                    throw new ILArgumentException("X must be vector!");
                x = ILNumerics.BuiltInFunctions.ILMath.tosingle(X);
                minLen = X.Length; 
            } 
            if (Y != null) {
                if (!Y.IsVector)
                    throw new ILArgumentException("Y must be vector!");
                y = ILNumerics.BuiltInFunctions.ILMath.tosingle(Y);
                minLen = Math.Min(minLen, Y.Length); 
            } 
            if (Z != null) {
                if (!Z.IsVector)
                    throw new ILArgumentException("Z must be vector!");
                z = ILNumerics.BuiltInFunctions.ILMath.tosingle(Z);
                minLen = Math.Min(minLen, Z.Length); 
            }
            for (int i = 0; i < Vertices.Length && i < minLen; i++) {
                VertexType v = new VertexType();
                if (x != null) v.XPosition = x.GetValue(i);
                if (y != null) v.YPosition = y.GetValue(i);
                if (z != null) v.ZPosition = z.GetValue(i);
                Vertices[i] = v; 
            }
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
        protected override void IntConfigure() {
            // nothing to do ...
        }
    }
}
