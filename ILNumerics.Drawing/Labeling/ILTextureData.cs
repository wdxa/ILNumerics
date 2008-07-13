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

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// class encapsulating texture item definitions
    /// </summary>
    public class ILTextureData {

        #region attributes 
        private RectangleF m_textureRectangle;
        private int m_width = -1; 
        private int m_height = -1; 
        #endregion 

        #region Properties
        /// <summary>
        /// the item's rectangle area in the texture sheet (texture coordinates) 
        /// </summary>
        public RectangleF TextureRectangle {
            get {
                return m_textureRectangle; 
            }
            set {
                m_textureRectangle = value; 
            }
        }
        /// <summary>
        /// Width of the (rendered) item
        /// </summary>
        public int Width {
            get {
                return m_width;
            }
            set {
                m_width = value; 
            }
        }
        /// <summary>
        /// Height of the (rendered) item
        /// </summary>
        public int Height {
            get {
                return m_height; 
            }
            set {
                m_height = value; 
            }
        }
        #endregion

        #region constructor
        internal ILTextureData (int height, int width) {
            m_height = height; 
            m_width = width;
        }
        #endregion
    }
}
