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
