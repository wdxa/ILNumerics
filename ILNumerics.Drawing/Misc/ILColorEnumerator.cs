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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ILNumerics.Drawing.Misc;  

namespace ILNumerics.Drawing.Misc {
    /// <summary>
    /// enumerate colors 
    /// </summary>
    public class ILColorEnumerator {

        List<Color> m_colors;
        int m_curPos; 

        /// <summary>
        /// create new color enumeration based on a specific colormap
        /// </summary>
        /// <param name="basemap"></param>
        public ILColorEnumerator(Colormaps basemap) {
            ILColormap cm = new ILColormap(basemap);
            m_colors = new List<Color>(); 
            for (int i = 0; i < cm.Length; i++) {
                m_colors.Add(cm.Map(i)); 
            }
            m_curPos = 0; 
        }
        /// <summary>
        /// create new color enumerator based on Colormap.Lines
        /// </summary>
        public ILColorEnumerator () : this (Colormaps.Lines) { }

        /// <summary>
        /// return next color and increase internal pointer
        /// </summary>
        /// <returns></returns>
        public Color NextColor() {
            Color ret = m_colors[m_curPos++]; 
            if (m_curPos == m_colors.Count) 
                m_curPos = 0;
            return ret; 
        }
    }
}
