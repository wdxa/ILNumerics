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
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {

        /// <summary>
        /// upper triangular part of matrix
        /// </summary>
        /// <typeparam name="T">inner type of matrix</typeparam>
        /// <param name="A">original matrix, size [m x n]</param>
        /// <returns>physical array of size [m x n], holding upper triangular part of A</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if A has more than 2 dimensions.</exception>
        public static ILArray<T> triu <T>(ILArray<T> A) {
            if (A.Dimensions.NumberOfDimensions > 2)
                throw  new ILArgumentException("triu: input argument must be matrix!");
            return A.copyUpperTriangle(A.Dimensions[0]); 
            
        }
        /// <summary>
        /// lower triangular part of matrix
        /// </summary>
        /// <typeparam name="T">inner type of matrix</typeparam>
        /// <param name="A">original matrix, size [m x n]</param>
        /// <returns>physical array of size [m x n], holding lower triangular part of A</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if A has more than 2 dimensions.</exception>
        public static ILArray<T> tril <T>(ILArray<T> A) {
            if (A.Dimensions.NumberOfDimensions > 2)
                throw  new ILArgumentException("tril: input argument must be matrix!");
            return A.copyLowerTriangle(); 
            
        }
    }
}
