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
    <destination>char</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
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
                return /*!HC:inCls1*/ ILArray<double> .empty(); 
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
        public static  ILArray<UInt64> trace ( ILArray<UInt64> A) {
            if (A.IsEmpty) 
                return  ILArray<UInt64> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<UInt32> trace ( ILArray<UInt32> A) {
            if (A.IsEmpty) 
                return  ILArray<UInt32> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<UInt16> trace ( ILArray<UInt16> A) {
            if (A.IsEmpty) 
                return  ILArray<UInt16> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<Int64> trace ( ILArray<Int64> A) {
            if (A.IsEmpty) 
                return  ILArray<Int64> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<Int32> trace ( ILArray<Int32> A) {
            if (A.IsEmpty) 
                return  ILArray<Int32> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<Int16> trace ( ILArray<Int16> A) {
            if (A.IsEmpty) 
                return  ILArray<Int16> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<float> trace ( ILArray<float> A) {
            if (A.IsEmpty) 
                return  ILArray<float> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<fcomplex> trace ( ILArray<fcomplex> A) {
            if (A.IsEmpty) 
                return  ILArray<fcomplex> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<complex> trace ( ILArray<complex> A) {
            if (A.IsEmpty) 
                return  ILArray<complex> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }
        /// <summary>
        /// trace of matrix
        /// </summary>
        /// <param name="A">input matrix, size [m x n]</param>
        /// <returns>scalar of same type as A with the sum of diagonal elements of A.</returns>
        public static  ILArray<char> trace ( ILArray<char> A) {
            if (A.IsEmpty) 
                return  ILArray<char> .empty(); 
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
                return  ILArray<byte> .empty(); 
            if (A.IsVector || A.IsScalar) 
                return A[0]; 
            return sum(diag(A));
        }

#endregion HYCALPER AUTO GENERATED CODE


    }
}
