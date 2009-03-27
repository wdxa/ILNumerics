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
        <destination>complex</destination>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>(byte)Math.Sign</destination>
        <destination>complex.Sign</destination>
        <destination>(double)Math.Sign</destination>
    </type>
    <type>
        <source locate="after">
            HCfuncname
        </source>
        <destination>sign</destination>
        <destination>sign</destination>
        <destination>sign</destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination>Signum of array elements</destination>
        <destination>Signum of array elements</destination>
        <destination>Signum of array elements</destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination>Array with elements signaling the sign of corresponding elements of A</destination>
        <destination>Array with elements signaling the sign of corresponding elements of A</destination>
        <destination>Array with elements signaling the sign of corresponding elements of A</destination>
    </type>
    <type>
        <source locate="comment">
            remarks
        </source>
        <destination><![CDATA[<para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
                        <para>The array returned will be a solid array.</para>]]></destination>
        <destination><![CDATA[<para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
                        <para>The array returned will be a solid array.</para>]]></destination>
        <destination><![CDATA[<para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
                        <para>The array returned will be a solid array.</para>]]></destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs
                        
        #endregion HYCALPER LOOPEND UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<double>  sign ( ILArray<double> A) {
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
                       
                        *tmpOut++ =  (double)Math.Sign ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<double> ( retDblArr, inDim );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<complex>  sign ( ILArray<complex> A) {
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
                       
                        *tmpOut++ =  complex.Sign ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<complex> ( retDblArr, inDim );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<byte>  sign ( ILArray<byte> A) {
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
                       
                        *tmpOut++ =  (byte)Math.Sign ( *tmpIn++ )  ;
                    }
                }
            }

            return new  ILArray<byte> ( retDblArr, inDim );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
