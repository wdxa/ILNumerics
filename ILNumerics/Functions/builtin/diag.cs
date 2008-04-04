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
        /// diagonal matrix or diagonal of matrix
        /// </summary>
        /// <param name="X">matrix or vector. If X is matrix, diag returns the 
        /// elements on the main diagonal as column vector. If X is vector, a square matrix of size 
        /// [length(X), length(X)] will be created, having the elemrnts of 
        /// X on the main diagonal.</param>
        /// <returns>depending on 'X' a matrix or a vector with the elements of/on 
        /// the main diagonal.</returns>
        public static ILArray<T> diag<T>(ILArray<T> X) {
            return diag(X, 0); 
        }
        /// <summary>
        /// diagonal matrix or diagonal of matrix
        /// </summary>
        /// <param name="X">matrix or vector. If X is matrix, diag returns the 
        /// elements on the 'diagPosition's diagonal as column vector. If X is vector, a square matrix of size 
        /// [length(X) + diagPosition, length(X) + diagPosition] will be created, having 
        /// the elements of X on the 'diagPosition's diagonal.</param>
        /// <param name="diagPosition">index of diagonal to extract/ create. Here 0 means the 
        /// main diagonal, diagPosition > 0 is above the main diagonal, diagPosition smaller 0 means 
        /// above the main diagonal.</param>
        /// <returns>depending on 'X' a matrix or a vector with the elements of/on a diagonal.</returns>
        /// <remarks>The type of return Array will be the same as the type of X.</remarks>
        public static ILArray<T> diag<T>(ILArray<T> X, int diagPosition) {
            if (Object.Equals(X, null) || X.Dimensions.NumberOfDimensions > 2) {
                throw new ILArgumentException("diag: input array must be matrix, vector or scalar."); 
            }
            if (X.IsEmpty) 
                return ILArray<T> .empty(); 
            ILArray<T> ret = null;
            if  (X.IsScalar) {
                ret = new ILArray<T> (X[0,0]);
            } else if (X.IsVector) {
                int retLen = X.Length + Math.Abs(diagPosition);
                ret = ILArray<T> .zeros(retLen, retLen);
                T [] dIn = X.m_data;
                if (Math.Abs(diagPosition) > 0) {
                    for (int i = 0; i < dIn.Length; i++) {
                        ret[i, i + diagPosition] = dIn[i];
                    }
                } else {
                    for (int i = 0; i < retLen; i++) {
                        ret[i + diagPosition, i] = dIn[i];
                    }
                }
            } else  { // X is matrix
                int retLen = Math.Min(X.Dimensions[0], X.Dimensions[1]) - Math.Abs(diagPosition);
                ret = ILArray<T> .zeros(retLen, 1);
                T [] dRet = ret.m_data;
                if (diagPosition > 0) {
                    if (diagPosition >= X.Dimensions[1])
                        return ILArray<T> .empty();
                    for (int i = 0; i < retLen; i++) {
                        dRet[i] = X.GetValue(i, diagPosition + i);
                    }
                } else {
                    if (diagPosition <= -X.Dimensions[0])
                        return ILArray<T> .empty();
                    for (int i = 0; i < retLen; i++) {
                        dRet[i] = X.GetValue(diagPosition + i, i);
                    }
                }
            }
            return ret;
        }
    }
}
