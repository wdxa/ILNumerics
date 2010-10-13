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
        /// <summary>
        /// [deprecated] line properties, use individual properties of ILLine instead
        /// </summary>
        public ILLineProperties Properties {
            get { return m_properties; }
            private set { m_properties = value; }
        } 
        /// <summary>
        /// the oldest vertex to be removed on the next Queue() call
        /// </summary>
        internal int OldestVertexID {
            get { return m_oldestVertexID; }
        }
        /// <summary>
        /// determines, if the line is to be drawn antialiased (on width > 1 only)
        /// </summary>
        public bool Antialiasing {
            get { return m_properties.Antialiasing; }
            set { m_properties.Antialiasing = value; }
        }
        /// <summary>
        /// stipple pattern for the line, if Style is set to custom pattern
        /// </summary>
        public short Pattern {
            get { return m_properties.Pattern; }
            set { m_properties.Pattern = value; }
        }
        /// <summary>
        /// scaling for the stipple pattern
        /// </summary>
        public float PatternScale {
            get { return m_properties.PatternScale; }
            set { m_properties.PatternScale = value; }
        }
        /// <summary>
        /// line style, default: solid
        /// </summary>
        public LineStyle Style {
            get { return m_properties.Style; }
            set { m_properties.Style = value; }
        }
        /// <summary>
        /// line width (pixels)
        /// </summary>
        public int Width {
            get { return m_properties.Width; }
            set { m_properties.Width = value; }
        }
        /// <summary>
        /// inner color of the line
        /// </summary>
        public override Color FillColor {
            get {
                return m_properties.Color;
            }
            set {
                m_properties.Color = value;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// create new simple line with 2 ends
        /// </summary>
        /// <param name="panel"></param>
        public ILLine (ILPanel panel) 
            : this (panel,2) { }
        /// <summary>
        /// create new line, determine number of vertices
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="numVertices">number of vertices for the line</param>
        public ILLine (ILPanel panel, int numVertices) 
            : base (panel,numVertices) {
            if (numVertices < 2) 
                throw new ILArgumentException("line must have at least 2 points!"); 
            m_fillColor = Color.Black; 
            m_border.Visible = false;
            m_oldestVertexID = 0;  
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_properties.Color = Color.Blue;
            m_autoLimitsUpdateCount = numVertices;
            m_shading = ShadingStyles.Flat; 
        }
        /// <summary>
        /// create new line, give vertices positions also
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="X">X coordinates</param>
        /// <param name="Y">Y coordinates</param>
        /// <param name="Z">Z coordinates</param>
        public ILLine(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel, X,Y,Z) {
            m_fillColor = Color.Black;
            m_border.Visible = false;
            m_oldestVertexID = 0;
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_properties.Color = Color.Blue;
            m_shading = ShadingStyles.Flat; 
            m_autoLimitsUpdateCount = Vertices.Length; 
        }
        #endregion

        #region private helpers 
        void m_properties_Changed(object sender, EventArgs e) {
            m_fillColor = m_properties.Color;
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
        /// <summary>
        /// update vertices, may also alter number of line segments 
        /// </summary>
        /// <param name="X">X coordinates</param>                   
        /// <param name="Y">Y coordinates</param>
        /// <param name="Z">Z coordinates</param>
        public override void Update(ILBaseArray X, ILBaseArray Y, ILBaseArray Z) {
            int newLen = Math.Max(Math.Max(X.Length,Y.Length),Z.Length);
            if (VertexCount != newLen) {
                m_numVerticesPerShape = newLen; 
                Resize(newLen); 
            }
            base.Update(X, Y, Z);
        }
        #endregion


    }
}
