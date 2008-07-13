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

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Helper class used to create hashes for renderable items (currently text only)
    /// </summary>
    /// <remarks>This class should be used to retrieve an (unique) key for any 
    /// renderable items used in ILNumerics.Drawing renderer classes. This way on can 
    /// ensure not to create hash conflicts between different cached items.
    ///  </remarks>
    public class ILHashCreator {

        /// <summary>
        /// create hash for a text item, used to uniquely identify the item in a collection
        /// </summary>
        /// <param name="font">font used to draw the character</param>
        /// <param name="text">text content</param>
        /// <returns>string as key into collection. The key is: F:[(int)FontStyle][Size (3digits)]&[FontName]&text</returns>
        public static string Hash (Font font, string text) {
            return String.Format("F:{0}&{1:g3}&{2}&{3}",(int)font.Style,font.Size,font.Name,text); 
        }

        /// <summary>
        /// create unique hash for bitmaps
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <returns>unique key identifying the bitmap</returns>
        public static string Hash (Bitmap bitmap) {
            throw new NotImplementedException(); 
        }

    }
}
