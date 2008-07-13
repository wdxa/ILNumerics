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

namespace ILNumerics.Drawing {
    /// <summary>
    /// properties for line graphs
    /// </summary>
    public class ILLineProperties {

        #region event handling 
        /// <summary>
        /// fires if the properties were changed
        /// </summary>
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this,new EventArgs()); 
            }
        }
        #endregion

        #region attributes
        private int m_lineWidth; 
        private LineStyle m_lineStyle; 
        private short m_linePattern; 
        private float m_linePatternScale; 
        private Color m_foreColor; 
        private bool m_visible; 
        private bool m_setAntialiasing = false;
        private bool m_antialiasing;
        #endregion

        #region Properties 
        /// <summary>
        /// line width (default: 1)
        /// </summary>
        /// <remarks>if antialiasing is active, it will be disabled 
        /// as long as the width is less than 2 and automatically 
        /// reenabled if the width gets larger than 1 again.</remarks>
        public int Width {
            get {
                return m_lineWidth; 
            }
            set {
                // for width = 1, antialiasing will not work and 
                // must get disabled temporarily here 
                if (value <= 1) {
                    if (m_antialiasing) {
                        m_antialiasing = false; 
                        m_setAntialiasing = true; 
                    }
                } else {
                    if (m_setAntialiasing) {
                        m_setAntialiasing = false; 
                        m_antialiasing = true; 
                    }
                }
                m_lineWidth = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// line style (default: solid)
        /// </summary>
        public LineStyle Style {
            get {
                return m_lineStyle; 
            }
            set {
                m_lineStyle = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// user defined line stipple pattern for line style 'UserPattern'
        /// </summary>
        /// <remarks>the pattern is defined by corresponding bits 
        /// set in the short value. It may be stretched via the 
        /// LinePatternScale parameter. Default: 15</remarks>
        public short Pattern {
            get {
                return m_linePattern; 
            }
            set {
                m_linePattern = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// scaling for line stipple patterns (default: 4.0f)
        /// </summary>
        public float PatternScale {
            get {
                return m_linePatternScale; 
            }
            set {
                m_linePatternScale = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Line color (default: DarkOliveGreen)
        /// </summary>
        public Color Color {
            get {
                return m_foreColor; 
            }
            set {
                m_foreColor = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// get / set if lines are visible (default: true)
        /// </summary>
        public bool Visible {
            get {
                return m_visible; 
            }
            set {
                m_visible = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// draw lines with smooth antialiasing (if possible and supported)
        /// </summary>
        /// <remarks>If the object supports antialiased lines, edges will be drawn 
        /// smoothly. This sometimes comes with the drawback of the lines beeing 
        /// more thick. Not all objects support antialiasing. Default value is 'false'.</remarks>
        public bool Antialiasing {
            get {
                return m_antialiasing; 
            }
            set {
                if (m_setAntialiasing && !value) {
                    m_setAntialiasing = false; 
                }
                m_antialiasing = value; 
                OnChanged(); 
            }
        }
        #endregion 

        #region constructors
        /// <summary>
        /// create default properties for graphs
        /// </summary>
        public ILLineProperties() {
            m_lineStyle = LineStyle.Solid; 
            m_foreColor = Color.AntiqueWhite;
            m_lineWidth = 1; 
            m_linePattern = 15; 
            m_linePatternScale = 4.0f;
            m_visible = true; 
            m_antialiasing = false; 
        }
        /// <summary>
        /// create a new instance of this class based on another instance
        /// </summary>
        /// <param name="props">properties to be copied</param>
        public ILLineProperties(ILLineProperties props) {
            m_lineStyle = props.Style; 
            m_foreColor = props.Color;
            m_lineWidth = props.Width; 
            m_linePattern = props.Pattern; 
            m_linePatternScale = props.PatternScale; 
            m_visible = true; 
            m_antialiasing = props.m_antialiasing;
        }
        #endregion
    }
}
