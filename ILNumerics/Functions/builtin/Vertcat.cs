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
using ILNumerics.Exceptions; 

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// vertical concatenation for arbitrary arrays
        /// </summary>
        /// <param name="inArrays"> arrays to be concatenated with each other. All
        /// arrays must be of the same inner type. The dimensions of all arrays 
        /// must match - except the first dimension.</param>
        /// <returns>large array having all arrays in 'inArrays' placed beneath each other.
        /// </returns>
        /// <remarks>The array returned may be a reference array if all elements of 'inArrays' 
        /// point to the same object instance, or a solid array otherwise. In the case of
        /// all elements pointing to the same object, the static member 
        /// ILNumerics.ILSettings.MinimumRefDimensions will be taken into account too.
        /// 
        /// Vertical concatenation means concatenation along the first dimension.
        /// </remarks>
        public static ILArray<T> vertcat<T>(params ILArray<T>[] inArrays) {
            if (inArrays == null) 
                throw new ILArgumentException("input argument must not be null!"); 
            if (inArrays.Length == 0 || object.Equals(inArrays[0],null)) 
                return ILArray<T>.empty(0,0); 
            if (inArrays.Length == 1) 
                return inArrays[0].C; 
            ILArray<T> ret = (ILArray<T>)inArrays[0].Concat(inArrays[1], 0);
            for (int i = 2; i < inArrays.Length; i++) {
                ret = (ILArray<T>)ret.Concat(inArrays[i], 0);
            }
            return ret;
        }
    }
}
