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
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>double</destination>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>(byte)Math.Abs </destination>
        <destination>complex.Abs</destination>
        <destination>Math.Abs</destination>
    </type>
    <type>
        <source locate="after">
            HCfuncname
        </source>
        <destination>abs</destination>
        <destination>abs</destination>
        <destination>abs</destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination>Absolute values of array elements</destination>
        <destination>Magnitude of array elements</destination>
        <destination>Absolute values of array elements</destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination>Absolute values of array elements</destination>
        <destination>Magnitude of array elements</destination>
        <destination>Absolute values of array elements</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs
                        
        #endregion HYCALPER LOOPEND UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Absolute values of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Absolute values of array elements</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a dense array.</para></remarks>
        public static  ILArray<double>  abs ( ILArray<double> A) {
            if (A.IsEmpty)
                return  ILArray<double> .empty(A.Dimensions); 
            ILDimension inDim = A.Dimensions;
            double [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  double [newLength];
            retDblArr = ILMemoryPool.Pool.New< double > (newLength); 
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe
            {
                fixed ( double * pOutArr = retDblArr)
                fixed ( double * pInArr = A.m_data) {
                    double * lastElement = pOutArr + retDblArr.Length;
                    double * tmpOut = pOutArr;
                    double * tmpIn = pInArr;
                    while (tmpOut < lastElement) { // HC02
                       
                        *tmpOut++ =  Math.Abs ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<double> ( retDblArr, inDim );
        }
        /// <summary>Magnitude of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Magnitude of array elements</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a dense array.</para></remarks>
        public static  ILArray<double>  abs ( ILArray<complex> A) {
            if (A.IsEmpty)
                return  ILArray<double> .empty(A.Dimensions); 
            ILDimension inDim = A.Dimensions;
            double [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  double [newLength];
            retDblArr = ILMemoryPool.Pool.New< double > (newLength); 
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe
            {
                fixed ( double * pOutArr = retDblArr)
                fixed ( complex * pInArr = A.m_data) {
                    double * lastElement = pOutArr + retDblArr.Length;
                    double * tmpOut = pOutArr;
                    complex * tmpIn = pInArr;
                    while (tmpOut < lastElement) { // HC02
                       
                        *tmpOut++ =  complex.Abs ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<double> ( retDblArr, inDim );
        }
        /// <summary>Absolute values of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Absolute values of array elements</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a dense array.</para></remarks>
        public static  ILArray<byte>  abs ( ILArray<byte> A) {
            if (A.IsEmpty)
                return  ILArray<byte> .empty(A.Dimensions); 
            ILDimension inDim = A.Dimensions;
            byte [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  byte [newLength];
            retDblArr = ILMemoryPool.Pool.New< byte > (newLength); 
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe
            {
                fixed ( byte * pOutArr = retDblArr)
                fixed ( byte * pInArr = A.m_data) {
                    byte * lastElement = pOutArr + retDblArr.Length;
                    byte * tmpOut = pOutArr;
                    byte * tmpIn = pInArr;
                    while (tmpOut < lastElement) { // HC02
                       
                        *tmpOut++ =  (byte)Math.Abs  ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<byte> ( retDblArr, inDim );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
