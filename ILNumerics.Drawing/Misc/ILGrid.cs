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
    /// Line properties
    /// </summary>
    public class ILLinePropertiesG {
        
        #region events 
        /// <summary>
        /// fires if a property of the line has changed
        /// </summary>
        public event EventHandler Changed;
        #endregion 

        #region attributes, properties
        private bool m_visible; 
        private Color m_color; 
        private LineStyle m_lineStyle; 
        private UInt16 m_lineWidth;
        
        /// <summary>
        /// get/set the line color 
        /// </summary>
        public Color Color {
            get {
                return m_color;
            }
            set {
                m_color = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get / set the pattern style (solid,dashed...)
        /// </summary>
        public LineStyle LineStyle {
            get {
                return m_lineStyle; 
            }
            set {
                if (value == LineStyle.UserPattern) 
                    throw new Exceptions.ILArgumentException("ILLineProperties: UserPattern is not supported!");
                m_lineStyle = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get/set the drawing width of lines 
        /// </summary>
        public UInt16 LineWidth {
            get {
                return m_lineWidth; 
            }
            set {
                m_lineWidth = value;
                OnChanged(); 
            }
        }
        /// <summary>
        /// When true, the lines are visible; false: hidden
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
        #endregion 

        #region constructor
        public ILLinePropertiesG() {
            m_color =  Color.Gray; 
            m_lineStyle = LineStyle.Dashed; 
            m_visible = true; 
            m_lineWidth = 1; 
        }
        #endregion

        #region event handler 
        private void OnChanged() {
            if (Changed != null) 
                Changed(this,null); 
        }
        #endregion
    }
}
