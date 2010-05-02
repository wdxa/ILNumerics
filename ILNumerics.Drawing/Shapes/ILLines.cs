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
            OnChanged(); 
        }
        #endregion

        #region properties
        public ILLineProperties Properties {
            get { return m_properties; }
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
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }

        public ILLines (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,2,X,Y,Z) { 
            m_fillColor = Color.Blue;    
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }
        public ILLines (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel,2,X,Y,Z,mapping) { 
            m_fillColor = Color.Blue; 
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
            ILColorEnumerator colors = new ILColorEnumerator();
            for (int i = 0; i < m_vertCount; i++) {
                m_vertices[i].Color = colors.NextColor(); 
            }
        }
        #endregion

    }
}
