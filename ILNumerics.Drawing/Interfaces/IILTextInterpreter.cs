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
    /// <summary>
    /// interface for classes capable of transforming text 
    /// expressions into visual output representation
    /// </summary>
    /// <seealso cref="ILNumerics.Drawing.Labeling.ILSimpleTexInterpreter"/>
    public interface IILTextInterpreter {
        /// <summary>
        /// transform text element (text) into bitmap for rendering
        /// </summary>
        /// <param name="expression">item text expression, defines the visual output content</param>
        /// <param name="font">font used for rendering the text</param>
        /// <param name="color">initial color, unless overridden, used for items in expression</param>
        /// <param name="renderer">IILRenderer implementation, used for caching the element(s)</param>
        /// <returns>renderer queue, contains item keys and the size of transformed item expression</returns>
        /// <remarks>The implementation should use the general caching capabilities 
        /// of the renderer class. Therefore the item's elements must be cached subsequently
        /// into the renderer before drawing. The render queue returned may be 
        /// used for rendering in the same renderer than.</remarks>
        ILRenderQueue Transform(
                string expression, Font font, Color color, IILRenderer renderer);  
    }
}
