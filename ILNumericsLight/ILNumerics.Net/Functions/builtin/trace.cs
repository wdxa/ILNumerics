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
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {

        #region HYCALPER LOOPSTART trace 
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static /*!HC:inCls1*/ ILArray<double> trace (/*!HC:inCls1*/ ILArray<double> A) {
            if (A.IsEmpty) 
                return /*!HC:inCls1*/ ILArray<double> .empty(A.Dimensions); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        #endregion HYCALPER LOOPEND trace 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<complex> trace ( ILArray<complex> A) {
            if (A.IsEmpty) 
                return  ILArray<complex> .empty(A.Dimensions); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<byte> trace ( ILArray<byte> A) {
            if (A.IsEmpty) 
                return  ILArray<byte> .empty(A.Dimensions); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }

#endregion HYCALPER AUTO GENERATED CODE


    }
}
