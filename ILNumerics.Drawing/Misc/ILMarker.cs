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
    /// Properties for marker (f.e. used for line plots)
    /// </summary>
    public class ILMarker {
        
        #region eventing 
        /// <summary>
        /// Fires when the properties have changed
        /// </summary>
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this,new EventArgs()); 
            }
        }
        #endregion

        #region attributes 
        private int m_markerSize; 
        private Bitmap m_markerBitmap; 
        private MarkerStyle m_markerStyle; 
        private Color m_color; 
        #endregion

        #region properties 
        /// <summary>
        /// Marker color
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
        /// Style for markers (default: none)
        /// </summary>
        public MarkerStyle Style {
            get {
                return m_markerStyle; 
            }
            set {
                m_markerStyle = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Size of markers (default: 4)
        /// </summary>
        public int Size {            
            get {
                return m_markerSize; 
            }
            set {
                m_markerSize = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// bitmap for markers if MarkerStyle is set to 'Bitmap'
        /// </summary>
        public Bitmap Bitmap {
            get {
                return m_markerBitmap; 
            }
            set {
                m_markerBitmap = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create a new marker property instance
        /// </summary>
        public ILMarker () {
            m_markerStyle = MarkerStyle.None; 
            m_markerSize = 3;
        }
        #endregion
    }
}
