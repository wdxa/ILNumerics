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
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>complex.Sin</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_OPERATOR_TEMPLATE
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a dense array.</para></remarks>
        public static /*!HC:outCls*/ ILArray<double> /*!HC:HCfuncname*/ sin (/*!HC:inCls1*/ ILArray<double> A) {
            if (A.IsEmpty)
                return /*!HC:outCls*/ ILArray<double> .empty(A.Dimensions); 
            ILDimension inDim = A.Dimensions;
            /*!HC:outArr*/ double [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new /*!HC:outArr*/ double [newLength];
            retDblArr = ILMemoryPool.Pool.New</*!HC:outArr*/ double > (newLength); 
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe
            {
                fixed (/*!HC:outArr*/ double * pOutArr = retDblArr)
                fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                    /*!HC:outArr*/ double * lastElement = pOutArr + retDblArr.Length;
                    /*!HC:outArr*/ double * tmpOut = pOutArr;
                    /*!HC:inArr1*/ double * tmpIn = pInArr;
                    while (tmpOut < lastElement) { // HC02
                        /*!HC:HCCompute02*/
                        *tmpOut++ = /*!HC:HCoperation*/ Math.Sin ( *tmpIn++ ) /*!HC:HCpostOp*/ ;
                    }
                }
            }

            return new /*!HC:outCls*/ ILArray<double> ( retDblArr, inDim );
        }
        #endregion HYCALPER LOOPEND UNARY_OPERATOR_TEMPLATE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a dense array.</para></remarks>
        public static  ILArray<complex>  sin ( ILArray<complex> A) {
            if (A.IsEmpty)
                return  ILArray<complex> .empty(A.Dimensions); 
            ILDimension inDim = A.Dimensions;
            complex [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  complex [newLength];
            retDblArr = ILMemoryPool.Pool.New< complex > (newLength); 
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe
            {
                fixed ( complex * pOutArr = retDblArr)
                fixed ( complex * pInArr = A.m_data) {
                    complex * lastElement = pOutArr + retDblArr.Length;
                    complex * tmpOut = pOutArr;
                    complex * tmpIn = pInArr;
                    while (tmpOut < lastElement) { // HC02
                       
                        *tmpOut++ =  complex.Sin ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<complex> ( retDblArr, inDim );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
