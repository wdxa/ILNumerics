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
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Platform.OpenGL;  
using ILNumerics.Exceptions; 

namespace ILNumerics.Drawing.Marker {
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
        private ILPanel m_panel; 
        private int m_markerSize; 
        private ILMarkerShape m_shape; 
        private Color m_color; 
        protected bool m_visible; 
        #endregion

        #region properties 
        /// <summary>
        /// Switch on or off the visibility of all markers 
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
        /// Shape of markers, compatible with string, markerStyle or bitmap arguments
        /// </summary>
        public ILMarkerShape Shape {
            get {
                return m_shape; 
            }
            set {
                //implement abstract factory pattern
                if (value is ILMarkerShapeProxy) {
                    m_shape = Create(value as ILMarkerShapeProxy);  
                    if ((m_shape is ILStyledMarkerShape) && (m_shape as ILStyledMarkerShape).Style == MarkerStyle.None )
                        m_visible = false; 
                    else 
                        m_visible = true; 
                    m_markerSize = 8; 
                } 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Size of markers in pixels (default: 10)
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
        #endregion

        #region constructor
        /// <summary>
        /// create a new marker property instance
        /// </summary>
        public ILMarker (ILPanel panel) {
            m_panel = panel; 
            m_shape = MarkerStyle.None; 
            m_markerSize = 10;
            m_visible = false; 
            m_color = Color.DarkBlue; 
        }
        #endregion

        #region public interface
        internal static ILTexMarkerShape Create(ILPanel panel, string expression) {
            switch (panel.GraphicDeviceType) {
                case GraphicDeviceType.OpenGL:
                    return new ILOGLTexMarkerShape(panel,expression);    
                    break;
                default:
                    throw new NotImplementedException("TexMarkerShapes are not implemented yet for this graphics device type!");
            }
        }
        internal static ILStyledMarkerShape Create(ILPanel panel, MarkerStyle style) {
            switch (panel.GraphicDeviceType) {
                case GraphicDeviceType.OpenGL:
                    return new ILOGLStyledMarkerShape(panel,style);    
                default:
                    throw new NotImplementedException("styled markers are not implemented yet for this graphics device type!");
            }
        }
        internal static ILBitmapMarkerShape Create(ILPanel panel, Bitmap bitmap) {
            switch (panel.GraphicDeviceType) {
                case GraphicDeviceType.OpenGL:
                    return new ILOGLBitmapMarkerShape(panel,bitmap);    
                default:
                    throw new NotImplementedException("Bitmap markers are not implemented yet for this graphics device type!");
            }
        }
        internal ILMarkerShape Create(ILMarkerShapeProxy proxy) {

            if (proxy.Source is string) {
                return Create(m_panel,proxy.Source as string); 
            } else if (proxy.Source is MarkerStyle) {
                return Create(m_panel,(MarkerStyle)proxy.Source); 
            } else if (proxy.Source is Bitmap) {
                return Create(m_panel,proxy.Source as Bitmap); 
            }
            throw new ILArgumentException(String.Format("Unable to create marker shape based on proxy source given: {0}",proxy.Source.ToString())); 
        }
        #endregion

    }
}
