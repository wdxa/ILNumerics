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
        /// array reshaping
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="newDimensions">new dimension array. This may be 
        /// a comma seperated list or an int array</param>
        /// <returns>reshaped X</returns>
        /// <remarks>A will not be changed. A new array is created, having 
        /// the size and number of dimension specified by newDimensions. </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException"> 
        /// if the number of elements in A and the number of elements for the 
        /// new dimensions specified by <paramref name="newDimensions"/> 
        /// do not match.</exception>
        public static ILArray<T> reshape<T>(ILArray<T> A, params int[] newDimensions) {
            return A.R.Reshape(new ILDimension (newDimensions)); 
        }
    }
}
