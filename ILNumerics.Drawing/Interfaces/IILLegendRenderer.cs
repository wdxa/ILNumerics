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
using ILNumerics.Drawing.Labeling; 

namespace ILNumerics.Drawing.Interfaces {
    public interface IILLegendRenderer {
        /// <summary>
        /// draws a small example of the visual output 
        /// </summary>
        /// <param name="g">graphics object, if this is null, drawing into current GL context</param>
        /// <param name="sampleArea">area to draw the line + marker into</param>
        /// <param name="labelArea">area to draw corresponding label into</param>
        void DrawToLegend(Graphics g, Rectangle sampleArea, Rectangle labelArea); 
        /// <summary>
        /// Read access to label element
        /// </summary>
        ILLabel Label {get; }
    }
}
