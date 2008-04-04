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

namespace ILNumerics.Drawing {
   
    /// <summary>
    /// occours if the clipping data for an subfigure have changed
    /// </summary>
    /// <param name="sender">object which changed the data</param>
    /// <param name="e">arguments containing the new clipping data</param>
    public delegate void ILClippingDataChangedEvent (object sender, ClippingChangedEventArgs e); 
    
    /// <summary>
    /// delegate used to measure text, device dependent
    /// </summary>
    /// <param name="text">text to be measured</param>
    /// <param name="font">Font used for rendering</param>
    /// <returns>Size in screen coords</returns>
    public delegate Size MeasureTextDelegate(string text, Font font); 

    /// <summary>
    /// arguments on ClippinChangedEvents
    /// </summary>
    public class ClippingChangedEventArgs : EventArgs {
        /// <summary>
        /// creates a new ClippingChangedEventArgs object
        /// </summary>
        /// <param name="clippingData"></param>
        public ClippingChangedEventArgs(ILClippingData clippingData) {
            ClippingData = clippingData; 
        }
        /// <summary>
        /// the current (new) clipping data
        /// </summary>
        public ILClippingData ClippingData;
    }
}
