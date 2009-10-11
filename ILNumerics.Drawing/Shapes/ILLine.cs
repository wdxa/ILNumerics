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
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc;
using ILNumerics.Drawing.Graphs;  
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// A simple single line
    /// </summary>
    public class ILLine : ILBorderedShape<C4bV3f> {

        #region attributes 
        ILLineProperties m_properties;
        int m_autoLimitsUpdateCount = 0;
        int m_updateCount = 0; 

        public int AutoLimitsUpdateCount {
            get { return m_autoLimitsUpdateCount; }
            set { m_autoLimitsUpdateCount = value; }
        }
        int m_oldestVertexID; 
        #endregion

        #region properties
        public ILLineProperties Properties {
            get { return m_properties; }
            set { m_properties = value; }
        } 
        internal int OldestVertexID {
            get { return m_oldestVertexID; }
        }
        #endregion

        #region constructors
        public ILLine (ILPanel panel) 
            : this (panel,2) { }

        public ILLine (ILPanel panel, int numVertices) 
            : base (panel,numVertices) {
            if (numVertices < 2) 
                throw new ILArgumentException("line must have at least 2 points!"); 
            m_fillColor = Color.Black; 
            m_border.Visible = false;
            m_oldestVertexID = 0;  
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_autoLimitsUpdateCount = numVertices; 
        }
        #endregion

        #region private helpers 
        void m_properties_Changed(object sender, EventArgs e) {
            OnChanged();
        }
        protected override void IntDrawShape(ILRenderProperties props) {
            if (m_vertCount == 0 || m_vertCount >= VerticesPerShape) {
                m_renderer.Draw(props, this);
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
        #endregion

        #region public interface
        public void Queue(IILVertexDefinition vertex) {
            SetVertex(m_oldestVertexID++, vertex);
            if (m_oldestVertexID >= m_vertCount) {
                m_oldestVertexID = 0; 
            }
            if (m_updateCount++ < m_autoLimitsUpdateCount) {
                bool signal = false;
                m_positionMax = ILPoint3Df.Max(m_positionMax, vertex.Position, ref signal);
                m_positionMin = ILPoint3Df.Min(m_positionMin, vertex.Position, ref signal); 
                if (signal) {
                    OnSizeChanged(); 
                }
            } else {
                m_updateCount = 0; 
                Invalidate();
            }
        }

        #endregion


    }
}
