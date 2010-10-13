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
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc; 


namespace ILNumerics.Drawing.Shapes {
    
    public class ILLines 
        : ILCompositeShape<C4bV3f> {

        #region attributes 
        ILLineProperties m_properties;
        void m_properties_Changed(object sender, EventArgs e) {
            m_fillColor = m_properties.Color;
            OnChanged();
        }
        #endregion

        #region properties
        /// <summary>
        /// all properties for the lines (in shading mode 'flat')
        /// </summary>
        public ILLineProperties Properties {
            get { return m_properties; }
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
        /// color for the lines (in shading mode 'flat')
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
        /// Create new lines composite shapes, prepare memory for vertices only
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="numVertices">number of overall vertices in the shape</param>
        public ILLines (ILPanel panel, int numVertices)
            : base(panel, numVertices, 2) {
            m_fillColor = Color.Blue;   
            m_properties = new ILLineProperties();
            m_properties.Color = Color.Blue;
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }
        /// <summary>
        /// create new lines composite shape
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="X">x coordinates vector </param>
        /// <param name="Y">y coordinates vector </param>
        /// <param name="Z">z coordinates vector </param>
        public ILLines(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,2,X,Y,Z) { 
            m_fillColor = Color.Blue;    
            m_properties = new ILLineProperties();
            m_properties.Color = Color.Blue; 
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }
        /// <summary>
        /// create new lines composite shape
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="X">X coords vector</param>
        /// <param name="Y">Y coords vector</param>
        /// <param name="Z">Z coords vector</param>
        /// <param name="mapping">Mapping of shapes, composes shapes out of vertices. Matrix having  
        /// 2 rows. Every element in a column specifies the index of a vertex according to its position in X,Y,Z.
        /// The 2 elements in a column therefore compose a single line. Vertices may get used arbitrary times 
        /// (or not at all). All elements must be positive integer values in range 
        /// 0...[<see cref="ILNumerics.Drawing.Shapes.ILShape.VertexCount"/>-1].</param>
        public ILLines(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping)
            : base(panel, 2, X, Y, Z, mapping) {
            m_fillColor = Color.Blue;
            m_properties = new ILLineProperties();
            m_properties.Color = Color.Blue;
            m_properties.Changed += new EventHandler(m_properties_Changed);
            ILColorEnumerator colors = new ILColorEnumerator();
            for (int i = 0; i < m_vertCount; i++) {
                m_vertices[i].Color = colors.NextColor();
            }
        }
        /// <summary>
        /// create lines composite shape 
        /// </summary>
        /// <param name="panel">hosting panel</param>
        /// <param name="X">x coordinates vector </param>
        /// <param name="Y">y coordinates vector </param>
        /// <param name="Z">z coordinates vector </param>
        /// <param name="colors">matrix with <see cref="ILNumerics.Drawing.Shapes.ILShape.VertexCount"/> 
        /// rows, 3 columns for (R,G,B) or 4 columns for 
        /// (A,R,G,B) for every vertex specified by X,Y,Z. Elements must range from 0..255. If colors 
        /// has 3 columns only, alpha values of 255 are used as default.</param>
        /// <param name="mapping">Mapping of shapes, composes shapes out of vertices. Matrix having  
        /// 2 rows. Every element in a column specifies the index of a vertex according to its position in X,Y,Z.
        /// The 2 elements in a column therefore compose a single line. Vertices may get used arbitrary times 
        /// (or not at all). All elements must be positive integer values in range 
        /// 0...[<see cref="ILNumerics.Drawing.Shapes.ILShape.VertexCount"/>-1].</param>
        public ILLines(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray colors, ILBaseArray mapping)
            : base(panel, 2, X, Y, Z,colors, mapping) {
            m_fillColor = Color.Blue;
            m_properties = new ILLineProperties();
            m_properties.Color = Color.Blue;
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }
        #endregion

    }
}
