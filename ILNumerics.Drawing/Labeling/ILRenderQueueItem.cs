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
using System.Drawing; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Single item with rendering instructions, used in ILRenderQueues
    /// </summary>
    public class ILRenderQueueItem { 
        /// <summary>
        /// unique key, identifies the item in the render cache
        /// </summary>
        public string Key; 
        /// <summary>
        /// rendering offset for the item (used for sub-/superscripts etc.)
        /// </summary>
        public Point Offset; 
        /// <summary>
        /// individual color for the item 
        /// </summary>
        /// <remarks>If this property is set to Color.Empty, the item will 
        /// be drawn with the color assigned to hosting element.</remarks>
        public Color Color; 

        /// <summary>
        /// construct a new ILRenderQueueItem
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="xOffset">x coordinate for offset</param>
        /// <param name="yOffset">y coordinate for offset</param>
        /// <param name="color">individual color</param>
        public ILRenderQueueItem (string key, int xOffset, int yOffset, Color color) {
            Key = key; 
            Offset = new Point(xOffset,yOffset); 
            Color = color; 
        }
        /// <summary>
        /// construct a new ILRenderQueueItem
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="offset">offset</param>
        /// <param name="color">individual color</param>
        public ILRenderQueueItem (string key, Point offset, Color color) {
            Key = key; 
            Offset = offset;
            Color = color; 
        }
    }
}
