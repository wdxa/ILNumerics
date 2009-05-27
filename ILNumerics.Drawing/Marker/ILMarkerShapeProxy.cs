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
using ILNumerics.Drawing.Interfaces;
using ILNumerics.Drawing.Shapes;

namespace ILNumerics.Drawing.Marker {
    
    /// <summary>
    /// Class used to enable flexible settings for marker shapes in ILMarker
    /// </summary>
    class ILMarkerShapeProxy : ILMarkerShape {

        #region attributes
        private object m_source; 
        #endregion 

        #region constructors
        public ILMarkerShapeProxy (string expression) : base (null) {
            m_source = expression; 
        }
        public ILMarkerShapeProxy (Bitmap bitmap) : base (null) {
            m_source = bitmap; 
        }
        public ILMarkerShapeProxy (MarkerStyle style) : base (null) {
            m_source = style; 
        }
        #endregion

        #region properties
        internal Object Source {
            get {
                return m_source; 
            }
        }
        #endregion

        #region public interface 
        internal override void Draw(ILRenderProperties p, ILMarker marker, C4bV3f[] vertices, int startID, int vertCount) {
            // dummy. Nothing to do! 
        }
        #endregion
    }
}
