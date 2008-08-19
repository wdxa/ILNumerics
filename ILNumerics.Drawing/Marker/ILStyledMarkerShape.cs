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
using ILNumerics.Drawing.Labeling; 

namespace ILNumerics.Drawing.Marker {
    public abstract class ILStyledMarkerShape : ILMarkerShape {

        #region attributes 
        protected MarkerStyle m_style; 
        #endregion

        #region properties
        /// <summary>
        /// The style of markers 
        /// </summary>
        public MarkerStyle Style {
            get {
                return m_style; 
            }
            set {
                m_style = value; 
                CacheMarkerBitmap(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create new styled marker
        /// </summary>
        internal ILStyledMarkerShape (ILPanel panel, MarkerStyle style) : base(panel) {
            m_style = style; 
        }
        #endregion

        #region public interface
        public override string ToString() {
            return String.Format(""); 
        }
        public string Hash() {
            string key = Enum.GetName(typeof(MarkerStyle),m_style); 
            key = key.Substring(0,3); 
            return String.Format("M:{0}",key); 
        }
        /// <summary>
        /// convert marker style into bitmap
        /// </summary>
        /// <param name="marker">marker with style property</param>
        /// <returns>bitmap according to style</returns>
        /// <remarks>the bitmap will be loaded from ILNumerics.Drawing ressources. For marker style 'bitmap'
        /// the bitmap referenced in the marker will be returned.</remarks>
        public static Bitmap BitmapFromStyle(MarkerStyle style) {
            switch (style) {
                case MarkerStyle.Circle:
                    return Resources.Markers.Circle25x25;
                case MarkerStyle.Diamond:
                    return Resources.Markers.Diamond25x25;
                case MarkerStyle.TriangleUp:
                    return Resources.Markers.TriangleUp25x25;
                case MarkerStyle.TriangleDown:
                    return Resources.Markers.TriangleDown25x25;
                case MarkerStyle.TriangleLeft:
                    return Resources.Markers.TriangleLeft25x25;
                case MarkerStyle.TriangleRight:
                    return Resources.Markers.TriangleRight25x25;
                case MarkerStyle.Plus:
                    return Resources.Markers.Plus25x25;
                case MarkerStyle.Cross:
                    return Resources.Markers.Cross25x25;
                default:
                    throw new NotImplementedException("ILStyledMarker: marker style not supported!");
            }
            return null;
        }


        #endregion

        #region private helper

        protected void CacheMarkerBitmap() {
            ILTextureManager mana = m_panel.TextureManager;
            string key = Hash();
            Bitmap markerbmp = BitmapFromStyle(m_style);
            // we need it in format Argb!
            mana.StoreTextureItem(key, markerbmp);
        }
        
        #endregion
    }
}
