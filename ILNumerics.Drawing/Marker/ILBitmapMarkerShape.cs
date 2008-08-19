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
    public abstract class ILBitmapMarkerShape : ILMarkerShape {

        #region attributes
        protected Bitmap m_bitmap; 
        #endregion

        #region constructors
        internal ILBitmapMarkerShape (ILPanel panel, Bitmap bitmap) : base(panel) {
            m_bitmap = bitmap;     
        }
        #endregion

        #region properties
        public Bitmap Bitmap {
            get {
                return m_bitmap; 
            }
            set {
                m_bitmap = value; 
                storeBitmap(m_bitmap); 
            }
        }
        #endregion

        #region public interface
        public string Hash() {
            // create hash based on the width, height & middle scanline of bitmap
            StringBuilder sb = new StringBuilder(
                        String.Format("M:{0}W{1}H{2}:","BMP",m_bitmap.Width,m_bitmap.Height)); 
            int h = m_bitmap.Height / 2; 
            for (int x = 0; x < Math.Min(m_bitmap.Width,30);x++) {
                sb.Append(m_bitmap.GetPixel(x,h).ToArgb().ToString());
            }
            return sb.ToString(); 
        }

        #endregion

        #region private helper
        protected virtual void storeBitmap(Bitmap bitmap) {
            string key = Hash(); 
            ILTextureManager mana = m_panel.TextureManager; 
            mana.StoreTextureItem(key,m_bitmap); 
        }
        #endregion
    }
}
