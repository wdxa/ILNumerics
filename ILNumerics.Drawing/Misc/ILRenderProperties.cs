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

namespace ILNumerics.Drawing {
    /// <summary>
    /// extended drawing properties
    /// </summary>
    /// <remarks>the class collects flags for special
    /// rendering states (vector exports, picking).
    /// </remarks>
    public class ILRenderProperties {
        /// <summary>
        /// current camera 
        /// </summary>
        public ILCamera Camera;
        /// <summary>
        /// current clipping (view limits) data
        /// </summary>
        public bool Clipping;
        /// <summary>
        /// if not null, the rendering should be done offscreen via this graphics object
        /// </summary>
        public System.Drawing.Graphics Graphics;
        /// <summary>
        /// if set to true while rendering, the render process will be cancelled 
        /// </summary>
        public bool Canceled = false;
        /// <summary>
        /// inform content object of the reason for rendering, see the <see cref="ILNumerics.Drawing.RenderReason">enumeration</see> for possible values.
        /// </summary>
        internal RenderReason Reason;
        /// <summary>
        /// measures the absolute used up region while rendering, initiallized to int.MaxValue
        /// </summary>
        public int MinX;
        /// <summary>
        /// measures the absolute used up region while rendering, initiallized to int.MinValue
        /// </summary>
        public int MaxX;
        /// <summary>
        /// measures the absolute used up region while rendering, initiallized to int.MaxValue
        /// </summary>
        public int MinY;
        /// <summary>
        /// measures the absolute used up region while rendering, initiallized to int.MinValue
        /// </summary>
        public int MaxY;
        /// <summary>
        /// Some rendering settings require multiple rendering passes. Those are counted here.
        /// </summary>
        public int PassCount = 0;

        /// <summary>
        /// Resets this instance.
        /// </summary>
        /// <returns>Instance reset to default values.</returns>
        public ILRenderProperties Reset() {
            PassCount = 0;
            Reason = RenderReason.PaintEvent;
            MinX = int.MaxValue;
            MinY = int.MaxValue;
            MaxX = int.MinValue;
            MaxY = int.MinValue;
            return this; 
        }
    }
}
