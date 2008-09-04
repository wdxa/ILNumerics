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
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>byte</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>(byte)Math.Sign</destination>
        <destination>(Int16)Math.Sign</destination>
        <destination>(Int32)Math.Sign</destination>
        <destination>(Int64)Math.Sign</destination>
        <destination>complex.Sign</destination>
        <destination>fcomplex.Sign</destination>
        <destination>(float)Math.Sign</destination>
        <destination>(double)Math.Sign</destination>
    </type>
    <type>
        <source locate="after">
            HCfuncname
        </source>
        <destination>sign</destination>
        <destination>sign</destination>
        <destination>sign</destination>
        <destination>sign</destination>
        <destination>sign</destination>
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
        <destination>Signum of array elements</destination>
        <destination>Signum of array elements</destination>
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
        <destination>Array with elements signaling the sign of corresponding elements of A</destination>
        <destination>Array with elements signaling the sign of corresponding elements of A</destination>
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
        <destination><![CDATA[<para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
                        <para>The array returned will be a solid array.</para>]]></destination>
        <destination><![CDATA[<para>The signum function for each element a is computed by: a / abs(a). Therefore, values returned will all lay on the unit circle.</para><para>If the input array is empty, an empty array will be returned.</para>
                        <para>The array returned will be a solid array.</para>]]></destination>
        <destination><![CDATA[<para>The signum function for each element a is computed by: a / abs(a). Therefore, values returned will all lay on the unit circle.</para><para>If the input array is empty, an empty array will be returned.</para>
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
                return  ILArray<double> .empty(); 
            ILDimension inDim = A.Dimensions;
            double [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  double [newLength];
            retDblArr = ILMemoryPool.Pool.New< double > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( double * pOutArr = retDblArr)
                            fixed ( double * pInArr = A.m_data) {
                                double * tmpOut = pOutArr;
                                double * tmpIn = pInArr;
                                double * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (double)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( double * pOutArr = retDblArr)
                            fixed ( double * pInArr = A.m_data) {
                                double * tmpOut = pOutArr;
                                double * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                double * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (double)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
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
                #endregion
            }
            return new  ILArray<double> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<float>  sign ( ILArray<float> A) {
            if (A.IsEmpty)
                return  ILArray<float> .empty(); 
            ILDimension inDim = A.Dimensions;
            float [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  float [newLength];
            retDblArr = ILMemoryPool.Pool.New< float > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( float * pInArr = A.m_data) {
                                float * tmpOut = pOutArr;
                                float * tmpIn = pInArr;
                                float * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (float)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( float * pInArr = A.m_data) {
                                float * tmpOut = pOutArr;
                                float * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                float * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (float)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( float * pOutArr = retDblArr)
                    fixed ( float * pInArr = A.m_data) {
                        float * lastElement = pOutArr + retDblArr.Length;
                        float * tmpOut = pOutArr;
                        float * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  (float)Math.Sign ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function for each element a is computed by: a / abs(a). Therefore, values returned will all lay on the unit circle.</para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<fcomplex>  sign ( ILArray<fcomplex> A) {
            if (A.IsEmpty)
                return  ILArray<fcomplex> .empty(); 
            ILDimension inDim = A.Dimensions;
            fcomplex [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  fcomplex [newLength];
            retDblArr = ILMemoryPool.Pool.New< fcomplex > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = A.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpIn = pInArr;
                                fcomplex * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  fcomplex.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = A.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                fcomplex * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  fcomplex.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( fcomplex * pOutArr = retDblArr)
                    fixed ( fcomplex * pInArr = A.m_data) {
                        fcomplex * lastElement = pOutArr + retDblArr.Length;
                        fcomplex * tmpOut = pOutArr;
                        fcomplex * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  fcomplex.Sign ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function for each element a is computed by: a / abs(a). Therefore, values returned will all lay on the unit circle.</para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<complex>  sign ( ILArray<complex> A) {
            if (A.IsEmpty)
                return  ILArray<complex> .empty(); 
            ILDimension inDim = A.Dimensions;
            complex [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  complex [newLength];
            retDblArr = ILMemoryPool.Pool.New< complex > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( complex * pInArr = A.m_data) {
                                complex * tmpOut = pOutArr;
                                complex * tmpIn = pInArr;
                                complex * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  complex.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( complex * pInArr = A.m_data) {
                                complex * tmpOut = pOutArr;
                                complex * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                complex * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  complex.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
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
                #endregion
            }
            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<Int64>  sign ( ILArray<Int64> A) {
            if (A.IsEmpty)
                return  ILArray<Int64> .empty(); 
            ILDimension inDim = A.Dimensions;
            Int64 [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  Int64 [newLength];
            retDblArr = ILMemoryPool.Pool.New< Int64 > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int64 * pOutArr = retDblArr)
                            fixed ( Int64 * pInArr = A.m_data) {
                                Int64 * tmpOut = pOutArr;
                                Int64 * tmpIn = pInArr;
                                Int64 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (Int64)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int64 * pOutArr = retDblArr)
                            fixed ( Int64 * pInArr = A.m_data) {
                                Int64 * tmpOut = pOutArr;
                                Int64 * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                Int64 * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (Int64)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int64 * pOutArr = retDblArr)
                    fixed ( Int64 * pInArr = A.m_data) {
                        Int64 * lastElement = pOutArr + retDblArr.Length;
                        Int64 * tmpOut = pOutArr;
                        Int64 * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  (Int64)Math.Sign ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<Int64> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<Int32>  sign ( ILArray<Int32> A) {
            if (A.IsEmpty)
                return  ILArray<Int32> .empty(); 
            ILDimension inDim = A.Dimensions;
            Int32 [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  Int32 [newLength];
            retDblArr = ILMemoryPool.Pool.New< Int32 > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int32 * pOutArr = retDblArr)
                            fixed ( Int32 * pInArr = A.m_data) {
                                Int32 * tmpOut = pOutArr;
                                Int32 * tmpIn = pInArr;
                                Int32 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (Int32)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int32 * pOutArr = retDblArr)
                            fixed ( Int32 * pInArr = A.m_data) {
                                Int32 * tmpOut = pOutArr;
                                Int32 * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                Int32 * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (Int32)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int32 * pOutArr = retDblArr)
                    fixed ( Int32 * pInArr = A.m_data) {
                        Int32 * lastElement = pOutArr + retDblArr.Length;
                        Int32 * tmpOut = pOutArr;
                        Int32 * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  (Int32)Math.Sign ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<Int32> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<Int16>  sign ( ILArray<Int16> A) {
            if (A.IsEmpty)
                return  ILArray<Int16> .empty(); 
            ILDimension inDim = A.Dimensions;
            Int16 [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  Int16 [newLength];
            retDblArr = ILMemoryPool.Pool.New< Int16 > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int16 * pOutArr = retDblArr)
                            fixed ( Int16 * pInArr = A.m_data) {
                                Int16 * tmpOut = pOutArr;
                                Int16 * tmpIn = pInArr;
                                Int16 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (Int16)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int16 * pOutArr = retDblArr)
                            fixed ( Int16 * pInArr = A.m_data) {
                                Int16 * tmpOut = pOutArr;
                                Int16 * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                Int16 * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (Int16)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int16 * pOutArr = retDblArr)
                    fixed ( Int16 * pInArr = A.m_data) {
                        Int16 * lastElement = pOutArr + retDblArr.Length;
                        Int16 * tmpOut = pOutArr;
                        Int16 * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  (Int16)Math.Sign ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<Int16> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>Signum of array elements</summary>
        /// <param name="A">input array</param>
        /// <returns>Array with elements signaling the sign of corresponding elements of A</returns>
        /// <remarks><para>The signum function produces following values: <list type="bullet"><item>-1 - for elements &lt; zero,</item><item> 0 - for elements equal zero,</item><item> 1 - for elements &gt; zero,</item></list></para><para>If the input array is empty, an empty array will be returned.</para>
        ///                         <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<byte>  sign ( ILArray<byte> A) {
            if (A.IsEmpty)
                return  ILArray<byte> .empty(); 
            ILDimension inDim = A.Dimensions;
            byte [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new  byte [newLength];
            retDblArr = ILMemoryPool.Pool.New< byte > (newLength); 
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (A.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = A.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                if (A.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( byte * pOutArr = retDblArr)
                            fixed ( byte * pInArr = A.m_data) {
                                byte * tmpOut = pOutArr;
                                byte * tmpIn = pInArr;
                                byte * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                int* secDimIdx = secDimStart;
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                while (secDimIdx < secDimEnd) {
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                    tmpIn = pInArr + *secDimIdx++;
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {   // HC00
                                       
                                        *tmpOut =  (byte)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [A.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( byte * pOutArr = retDblArr)
                            fixed ( byte * pInArr = A.m_data) {
                                byte * tmpOut = pOutArr;
                                byte * tmpOutEnd = tmpOut + retDblArr.Length - 1;
                                byte * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];     // if the first index of leaddim is not 0, it will be added later anyway. so we subtract it here
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD, count = retDblArr.Length / leadDimLen;
                                // start at first element
                                while (count --> 0) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (byte)Math.Sign ( *( tmpIn + *leadDimIdx++ ) )  ;
                                        tmpOut += incOut;
                                    }
                                    if (tmpOut > tmpOutEnd)
                                        tmpOut -= retDblArr.Length - 1;

                                    // increment higher dimensions 
                                    d = 1;
                                    while (d < dimLen) {
                                        curD = ( d + leadDim ) % dimLen;
                                        tmpIn -= idxOffset [curD, curPosition [curD]];
                                        curPosition [curD]++;
                                        if (curPosition [curD] < idxOffset [curD].Length) {
                                            tmpIn += idxOffset [curD, curPosition [curD]];
                                            break;
                                        }
                                        curPosition [curD] = 0;
                                        tmpIn += idxOffset [curD, 0];
                                        d++;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
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
                #endregion
            }
            return new  ILArray<byte> ( retDblArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
