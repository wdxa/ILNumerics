//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
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
        /// size of array A 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>double ILArray with the length of each dimension of A.</returns>
        /// <remarks>If A is null, an empty array will be returned. Otherwise the array returned will always be a row vector of length s. s &gt;= 2</remarks>
        public static ILArray<double> size(ILBaseArray A) {
            if (object.Equals (A,null))
                return ILArray<double>.empty(0,0); 
            int numDim = A.Dimensions.NumberOfDimensions;
            double [] retArr = new double[numDim]; 
            for (int i = 0; i < numDim; i++) {
                retArr[i] = A.Dimensions[i];     
            }
            return new ILArray<double>(retArr,1,numDim); 
        }
        /// <summary>
        /// length of one specific dimension of A
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="dim">number of dimension to query the length for</param>
        /// <returns>length of dimension 'dim'</returns>
        public static int size(ILBaseArray A, int dim) {
            if (object.Equals(A,null) || dim < 0)
                throw new ILArgumentException("size: A must not be null");
            return A.Dimensions[dim];
        }

        /// <summary>
        /// longest dimension of A
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>if A is null:0 - length of longest dimension of A</returns>
        /// <remarks>this is an alias/abreviation for A.Dimensions.Longest</remarks>
        public static int length(ILBaseArray A) {
            if (object.Equals(A,null)) return 0;
            return A.Dimensions.Longest; 
        }
        
        /// <summary>
        /// Number of dimensions of A
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>if A is null: 0 - else number of dimensions of A</returns>
        /// <remarks>this is an alias/abreviation for A.Dimensions.NumberOfDimensions</remarks>
        /// 
        public static int ndims(ILBaseArray A) {
            if (object.Equals(A,null)) return 0;
            return A.Dimensions.NumberOfDimensions;  
        }

        /// <summary>
        /// Number of elements of A
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>number of elements of A</returns>
        /// <remarks>this is an alias/abreviation for A.Dimensions.NumberOfElements</remarks>
        public static int numel(ILBaseArray A) {
            if (object.Equals(A,null)) return 0;
            return A.Dimensions.NumberOfElements;   
        }
    }
}
