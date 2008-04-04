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

namespace ILNumerics.Drawing.Graphs {
    public abstract class ILPlot2DGraph : ILGraph {
        protected ILLineProperties m_properties; 
        protected ILMarker m_marker; 

        /// <summary>
        /// Get properties of lines
        /// </summary>
        public ILLineProperties Line {
            get {
                return m_properties; 
            }
        }
        /// <summary>
        /// Get properties of markers (not yet implemented)
        /// </summary>
        public ILMarker Marker {
            get {
                return m_marker; 
            }
        }

        public ILPlot2DGraph (ILBaseArray sourceArray,
                              ILClippingData clippingContainer) 
            : base (sourceArray,clippingContainer) {
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_marker = new ILMarker(); 
            m_marker.Changed += new EventHandler(m_properties_Changed);
            m_graphType = GraphType.Plot2D; 
        }
        protected virtual void m_properties_Changed(object sender, EventArgs e) {
            m_isReady = false; 
        }
    }
}
