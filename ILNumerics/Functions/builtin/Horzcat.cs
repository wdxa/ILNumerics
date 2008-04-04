#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// horizontal concatenation for arbitrary arrays
        /// </summary>
        /// <param name="inArrays"> arrays to be concatenated with each other. All
        /// arrays must be of the same inner type. The dimensions of all arrays 
        /// must match - except the second dimension.</param>
        /// <returns>large array having all arrays in 'inArrays' placed behind each other.
        /// </returns>
        /// <remarks>The array returned may be a reference storage if all elements of 'inArrays' 
        /// point to the same object instance, or a physical storage array otherwise. In the case of
        /// all elements pointing to the same object, the static member 
        /// ILNumerics.Settings.ILSettings.MinimumRefDimensions will be taken into account too.
        /// 
        /// Horizontal concatenation means concatenation along the second dimension.
        /// </remarks>
        public static ILArray<T> horzcat<T>(params ILArray<T>[] inArrays) {
            if (inArrays.Length < 2)
                throw new Exception("horzcat: invalid number of arguments. At least 2 arrays expected!");
            try {
                ILArray<T> ret = (ILArray<T>)inArrays[0].Concat(inArrays[1], 1);
                for (int i = 2; i < inArrays.Length; i++) {
                    ret = (ILArray<T>)ret.Concat(inArrays[i], 1);
                }
                return ret;
            } catch (Exception e) {
                if (e.InnerException is ArgumentException) {
                    return null;
                } else {
                    throw new Exception("horzcat: all but the second dimensions of all arrays must match!");
                }
            }
        }
    }
}
