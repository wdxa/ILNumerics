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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Interfaces {
    /// <summary>
    /// interface for all classes capable of renderung (device 
    /// dependant) texts into plot panels 
    /// </summary>
    public interface IILTextRenderer {
        /// <summary>
        /// The name of the TextRenderer instance
        /// </summary>
        string Name { get; }
        /// <summary>
        /// A more descriptive name to be displayed into GUI's
        /// </summary>
        string NameLong { get; }
        /// <summary>
        /// Get or set the alignment for text inside rectangle to 
        /// be drawn (optional, if supported by device)
        /// </summary>
        TickLabelAlign Alignment { get; set; } 
        /// <summary>
        /// Query the coordinate system to be used for location 
        /// parameter on Draw() command
        /// </summary>
        CoordSystem CoordsSystem { get; }
        /// <summary>
        /// Get the graphics device type this TextRenderer instance 
        /// is capable to use for drawing 
        /// </summary>
        GraphicDeviceType DeviceType { get; }
        /// <summary>
        /// Determine, if the text is to be drawn after the rendering 
        /// backbuffer has been swapped and presented to the screen.
        /// </summary>
        bool DrawAfterBufferSwapped { get; } 
        /// <summary>
        /// Get/set system font used to draw the text
        /// </summary>
        Font Font { get; set; }
        /// <summary>
        /// Get/ set orientation for text rendering
        /// </summary>
        TextOrientation Orientation {get;set;}
        /// <summary>
        /// prepares the output generation 
        /// </summary>
        /// <param name="g">graphics object (from OnPaint event)</param>
        /// <returns>The really selected font. The font may be different 
        /// from the one requested.</returns>
        Font Prepare (Graphics g); 
        /// <summary>
        /// Draw the text 
        /// </summary>
        /// <param name="text">Text to be drawn</param>
        /// <param name="location">Location realtive to surface</param>
        /// <param name="c">Color</param>
        /// <remarks><para>In order to determine the coordinate system (world,screen) for the location parameter, 
        /// use the <see cref="IILTextRenderer.CoordsSystem"/> property.</para>
        /// <para>Before calling Draw(), the TextRenderer must have been initialized with Prepare(g)!</para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">on attempt to draw any text without previous initialization</exception>
        void Draw (string text, System.Drawing.Point position, Color c); 
        /// <summary>
        /// free all TextRenderer ressources, one must prepare it again before drawing!
        /// </summary>
        void Free(); 
        /// <summary>
        /// determine the size of text after rendering
        /// </summary>
        /// <param name="text">text to be measured</param>
        /// <param name="graphics">graphics object, may or may not be used 
        /// for measuring text</param>
        /// <returns>Size in screen coords</returns>
        Size MeasureText (string text, Graphics graphics); 

    }
}
