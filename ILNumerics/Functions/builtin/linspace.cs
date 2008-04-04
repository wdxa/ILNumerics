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
using ILNumerics;
using ILNumerics.Exceptions;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// create linearly spaced row vector of 100 elements 
        /// </summary>
        /// <param name="start">first value</param>
        /// <param name="end">last value</param>
        /// <returns>row vector with 100 elements linearly spaced between start and end</returns>
        public static ILArray<double> linspace (double start, double end) {
            return linspace(start, end,100); 
        }

        /// <summary>
        /// create linearly spaced row vector
        /// </summary>
        /// <param name="start">first value</param>
        /// <param name="end">last value</param>
        /// <param name="length">number of elements to create</param>
        /// <returns>row vector with 'length' elements linearly spaced between start and end</returns>
        public static ILArray<double> linspace (double start, double end, int length) {
            if (length < 2) 
                return new ILArray<double>(new double[1]{end},1,1); 
            double [] ret = ILMemoryPool.Pool.New<double>(length);
            double fact = ( end - start ) / (length - 1); 
            for (int i = 0; i < ret.Length; i++) {
                ret[i] = start + i * fact; 
            }
            return new ILArray<double> (ret,1,length); 
        }    
    }
}
