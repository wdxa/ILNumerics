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
using ILNumerics;
using ILNumerics.Misc;
using ILNumerics.Storage;
using ILNumerics.Native;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions;
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
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
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
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
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
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
            inArr2
        </source>
        <destination>double</destination>
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
            outCls
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
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
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>double</destination>
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
            outCast
        </source>
        <destination></destination>
        <destination>(byte)</destination>
        <destination>(char)</destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination>(Int16)</destination>
        <destination></destination>
        <destination></destination>
        <destination>(UInt16)</destination>
        <destination></destination>
        <destination></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
        <destination>*</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
        <destination>multiplyElem</destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
        <destination>Multiply elements</destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
        <destination>Array with elementwise multiplication of A and B</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {

        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs

        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE@Add.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<UInt64>  multiplyElem ( ILArray<UInt64> A,  ILArray<UInt64> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<UInt64> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<UInt64> (new  UInt64 [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  UInt64 [] retArr = new  UInt64 [inDim.NumberOfElements];
                    UInt64 [] retArr = ILMemoryPool.Pool.New< UInt64 > (inDim.NumberOfElements);
                    UInt64 scalarValue = A.GetValue(0); 
                    UInt64 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt64 * pOutArr = retArr)
                                fixed ( UInt64 * pInArr = B.m_data) {
                                        UInt64 * tmpOut = pOutArr;
                                        UInt64 * tmpIn = pInArr;
                                        UInt64 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( UInt64 * pOutArr = retArr)
                                    fixed ( UInt64 * pInArr = B.m_data) {
                                        UInt64 * tmpOut = pOutArr;
                                        UInt64 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        UInt64 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt64 * pOutArr = retArr)
                            fixed ( UInt64 * pInArr = B.m_data) {
                                UInt64 * lastElement = pOutArr + retArr.Length;
                                UInt64 * tmpOut = pOutArr;
                                UInt64 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<UInt64> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  UInt64 [] retArr = new  UInt64 [inDim.NumberOfElements];
                    UInt64 [] retArr = ILMemoryPool.Pool.New< UInt64 > (inDim.NumberOfElements);
                    UInt64 scalarValue = B.GetValue(0); 
                    UInt64 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt64 * pOutArr = retArr)
                                fixed ( UInt64 * pInArr = A.m_data) {
                                        UInt64 * tmpOut = pOutArr;
                                        UInt64 * tmpIn = pInArr;
                                        UInt64 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( UInt64 * pOutArr = retArr)
                                    fixed ( UInt64 * pInArr = A.m_data) {
                                        UInt64 * tmpOut = pOutArr;
                                        UInt64 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        UInt64 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt64 * pOutArr = retArr)
                            fixed ( UInt64 * pInArr = A.m_data) {
                                UInt64 * lastElement = pOutArr + retArr.Length;
                                UInt64 * tmpOut = pOutArr;
                                UInt64 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<UInt64> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    UInt64 [] retSystemArr;
                    UInt64 tmpValue1; 
                    UInt64 tmpValue2; 
                    // retSystemArr = new  UInt64 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< UInt64 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( UInt64 * pOutArr = retSystemArr)
                        fixed ( UInt64 * inA1 = A.m_data) 
                        fixed ( UInt64 * inA2 = B.m_data) {
                            UInt64 * pInA1 = inA1; 
                            UInt64 * pInA2 = inA2;
                            int c = 0; 
                            UInt64 * poutarr = pOutArr;
                            UInt64 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<UInt64> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<UInt32>  multiplyElem ( ILArray<UInt32> A,  ILArray<UInt32> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<UInt32> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<UInt32> (new  UInt32 [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  UInt32 [] retArr = new  UInt32 [inDim.NumberOfElements];
                    UInt32 [] retArr = ILMemoryPool.Pool.New< UInt32 > (inDim.NumberOfElements);
                    UInt32 scalarValue = A.GetValue(0); 
                    UInt32 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt32 * pOutArr = retArr)
                                fixed ( UInt32 * pInArr = B.m_data) {
                                        UInt32 * tmpOut = pOutArr;
                                        UInt32 * tmpIn = pInArr;
                                        UInt32 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( UInt32 * pOutArr = retArr)
                                    fixed ( UInt32 * pInArr = B.m_data) {
                                        UInt32 * tmpOut = pOutArr;
                                        UInt32 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        UInt32 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt32 * pOutArr = retArr)
                            fixed ( UInt32 * pInArr = B.m_data) {
                                UInt32 * lastElement = pOutArr + retArr.Length;
                                UInt32 * tmpOut = pOutArr;
                                UInt32 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<UInt32> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  UInt32 [] retArr = new  UInt32 [inDim.NumberOfElements];
                    UInt32 [] retArr = ILMemoryPool.Pool.New< UInt32 > (inDim.NumberOfElements);
                    UInt32 scalarValue = B.GetValue(0); 
                    UInt32 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt32 * pOutArr = retArr)
                                fixed ( UInt32 * pInArr = A.m_data) {
                                        UInt32 * tmpOut = pOutArr;
                                        UInt32 * tmpIn = pInArr;
                                        UInt32 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( UInt32 * pOutArr = retArr)
                                    fixed ( UInt32 * pInArr = A.m_data) {
                                        UInt32 * tmpOut = pOutArr;
                                        UInt32 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        UInt32 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt32 * pOutArr = retArr)
                            fixed ( UInt32 * pInArr = A.m_data) {
                                UInt32 * lastElement = pOutArr + retArr.Length;
                                UInt32 * tmpOut = pOutArr;
                                UInt32 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<UInt32> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    UInt32 [] retSystemArr;
                    UInt32 tmpValue1; 
                    UInt32 tmpValue2; 
                    // retSystemArr = new  UInt32 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< UInt32 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( UInt32 * pOutArr = retSystemArr)
                        fixed ( UInt32 * inA1 = A.m_data) 
                        fixed ( UInt32 * inA2 = B.m_data) {
                            UInt32 * pInA1 = inA1; 
                            UInt32 * pInA2 = inA2;
                            int c = 0; 
                            UInt32 * poutarr = pOutArr;
                            UInt32 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<UInt32> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<UInt16>  multiplyElem ( ILArray<UInt16> A,  ILArray<UInt16> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<UInt16> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<UInt16> (new  UInt16 [1]{ (UInt16) (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  UInt16 [] retArr = new  UInt16 [inDim.NumberOfElements];
                    UInt16 [] retArr = ILMemoryPool.Pool.New< UInt16 > (inDim.NumberOfElements);
                    UInt16 scalarValue = A.GetValue(0); 
                    UInt16 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt16 * pOutArr = retArr)
                                fixed ( UInt16 * pInArr = B.m_data) {
                                        UInt16 * tmpOut = pOutArr;
                                        UInt16 * tmpIn = pInArr;
                                        UInt16 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (UInt16) (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( UInt16 * pOutArr = retArr)
                                    fixed ( UInt16 * pInArr = B.m_data) {
                                        UInt16 * tmpOut = pOutArr;
                                        UInt16 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        UInt16 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (UInt16) (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt16 * pOutArr = retArr)
                            fixed ( UInt16 * pInArr = B.m_data) {
                                UInt16 * lastElement = pOutArr + retArr.Length;
                                UInt16 * tmpOut = pOutArr;
                                UInt16 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =  (UInt16) (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<UInt16> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  UInt16 [] retArr = new  UInt16 [inDim.NumberOfElements];
                    UInt16 [] retArr = ILMemoryPool.Pool.New< UInt16 > (inDim.NumberOfElements);
                    UInt16 scalarValue = B.GetValue(0); 
                    UInt16 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( UInt16 * pOutArr = retArr)
                                fixed ( UInt16 * pInArr = A.m_data) {
                                        UInt16 * tmpOut = pOutArr;
                                        UInt16 * tmpIn = pInArr;
                                        UInt16 * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =  (UInt16) (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( UInt16 * pOutArr = retArr)
                                    fixed ( UInt16 * pInArr = A.m_data) {
                                        UInt16 * tmpOut = pOutArr;
                                        UInt16 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        UInt16 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =  (UInt16) (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( UInt16 * pOutArr = retArr)
                            fixed ( UInt16 * pInArr = A.m_data) {
                                UInt16 * lastElement = pOutArr + retArr.Length;
                                UInt16 * tmpOut = pOutArr;
                                UInt16 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =  (UInt16) (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<UInt16> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    UInt16 [] retSystemArr;
                    UInt16 tmpValue1; 
                    UInt16 tmpValue2; 
                    // retSystemArr = new  UInt16 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< UInt16 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( UInt16 * pOutArr = retSystemArr)
                        fixed ( UInt16 * inA1 = A.m_data) 
                        fixed ( UInt16 * inA2 = B.m_data) {
                            UInt16 * pInA1 = inA1; 
                            UInt16 * pInA2 = inA2;
                            int c = 0; 
                            UInt16 * poutarr = pOutArr;
                            UInt16 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =  (UInt16) ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =  (UInt16)  ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =  (UInt16) ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =  (UInt16)  ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =  (UInt16) ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<UInt16> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<Int64>  multiplyElem ( ILArray<Int64> A,  ILArray<Int64> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<Int64> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<Int64> (new  Int64 [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  Int64 [] retArr = new  Int64 [inDim.NumberOfElements];
                    Int64 [] retArr = ILMemoryPool.Pool.New< Int64 > (inDim.NumberOfElements);
                    Int64 scalarValue = A.GetValue(0); 
                    Int64 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int64 * pOutArr = retArr)
                                fixed ( Int64 * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( Int64 * pOutArr = retArr)
                                    fixed ( Int64 * pInArr = B.m_data) {
                                        Int64 * tmpOut = pOutArr;
                                        Int64 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        Int64 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int64 * pOutArr = retArr)
                            fixed ( Int64 * pInArr = B.m_data) {
                                Int64 * lastElement = pOutArr + retArr.Length;
                                Int64 * tmpOut = pOutArr;
                                Int64 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<Int64> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  Int64 [] retArr = new  Int64 [inDim.NumberOfElements];
                    Int64 [] retArr = ILMemoryPool.Pool.New< Int64 > (inDim.NumberOfElements);
                    Int64 scalarValue = B.GetValue(0); 
                    Int64 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int64 * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( Int64 * pOutArr = retArr)
                                    fixed ( Int64 * pInArr = A.m_data) {
                                        Int64 * tmpOut = pOutArr;
                                        Int64 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        Int64 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int64 * pOutArr = retArr)
                            fixed ( Int64 * pInArr = A.m_data) {
                                Int64 * lastElement = pOutArr + retArr.Length;
                                Int64 * tmpOut = pOutArr;
                                Int64 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<Int64> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    Int64 [] retSystemArr;
                    Int64 tmpValue1; 
                    Int64 tmpValue2; 
                    // retSystemArr = new  Int64 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< Int64 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( Int64 * pOutArr = retSystemArr)
                        fixed ( Int64 * inA1 = A.m_data) 
                        fixed ( Int64 * inA2 = B.m_data) {
                            Int64 * pInA1 = inA1; 
                            Int64 * pInA2 = inA2;
                            int c = 0; 
                            Int64 * poutarr = pOutArr;
                            Int64 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<Int64> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<Int32>  multiplyElem ( ILArray<Int32> A,  ILArray<Int32> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<Int32> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<Int32> (new  Int32 [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  Int32 [] retArr = new  Int32 [inDim.NumberOfElements];
                    Int32 [] retArr = ILMemoryPool.Pool.New< Int32 > (inDim.NumberOfElements);
                    Int32 scalarValue = A.GetValue(0); 
                    Int32 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int32 * pOutArr = retArr)
                                fixed ( Int32 * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( Int32 * pOutArr = retArr)
                                    fixed ( Int32 * pInArr = B.m_data) {
                                        Int32 * tmpOut = pOutArr;
                                        Int32 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        Int32 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int32 * pOutArr = retArr)
                            fixed ( Int32 * pInArr = B.m_data) {
                                Int32 * lastElement = pOutArr + retArr.Length;
                                Int32 * tmpOut = pOutArr;
                                Int32 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<Int32> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  Int32 [] retArr = new  Int32 [inDim.NumberOfElements];
                    Int32 [] retArr = ILMemoryPool.Pool.New< Int32 > (inDim.NumberOfElements);
                    Int32 scalarValue = B.GetValue(0); 
                    Int32 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int32 * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( Int32 * pOutArr = retArr)
                                    fixed ( Int32 * pInArr = A.m_data) {
                                        Int32 * tmpOut = pOutArr;
                                        Int32 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        Int32 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int32 * pOutArr = retArr)
                            fixed ( Int32 * pInArr = A.m_data) {
                                Int32 * lastElement = pOutArr + retArr.Length;
                                Int32 * tmpOut = pOutArr;
                                Int32 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<Int32> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    Int32 [] retSystemArr;
                    Int32 tmpValue1; 
                    Int32 tmpValue2; 
                    // retSystemArr = new  Int32 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< Int32 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( Int32 * pOutArr = retSystemArr)
                        fixed ( Int32 * inA1 = A.m_data) 
                        fixed ( Int32 * inA2 = B.m_data) {
                            Int32 * pInA1 = inA1; 
                            Int32 * pInA2 = inA2;
                            int c = 0; 
                            Int32 * poutarr = pOutArr;
                            Int32 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<Int32> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<Int16>  multiplyElem ( ILArray<Int16> A,  ILArray<Int16> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<Int16> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<Int16> (new  Int16 [1]{ (Int16) (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  Int16 [] retArr = new  Int16 [inDim.NumberOfElements];
                    Int16 [] retArr = ILMemoryPool.Pool.New< Int16 > (inDim.NumberOfElements);
                    Int16 scalarValue = A.GetValue(0); 
                    Int16 tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int16 * pOutArr = retArr)
                                fixed ( Int16 * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (Int16) (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( Int16 * pOutArr = retArr)
                                    fixed ( Int16 * pInArr = B.m_data) {
                                        Int16 * tmpOut = pOutArr;
                                        Int16 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        Int16 * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (Int16) (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int16 * pOutArr = retArr)
                            fixed ( Int16 * pInArr = B.m_data) {
                                Int16 * lastElement = pOutArr + retArr.Length;
                                Int16 * tmpOut = pOutArr;
                                Int16 * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =  (Int16) (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<Int16> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  Int16 [] retArr = new  Int16 [inDim.NumberOfElements];
                    Int16 [] retArr = ILMemoryPool.Pool.New< Int16 > (inDim.NumberOfElements);
                    Int16 scalarValue = B.GetValue(0); 
                    Int16 tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( Int16 * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =  (Int16) (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( Int16 * pOutArr = retArr)
                                    fixed ( Int16 * pInArr = A.m_data) {
                                        Int16 * tmpOut = pOutArr;
                                        Int16 * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        Int16 * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =  (Int16) (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( Int16 * pOutArr = retArr)
                            fixed ( Int16 * pInArr = A.m_data) {
                                Int16 * lastElement = pOutArr + retArr.Length;
                                Int16 * tmpOut = pOutArr;
                                Int16 * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =  (Int16) (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<Int16> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    Int16 [] retSystemArr;
                    Int16 tmpValue1; 
                    Int16 tmpValue2; 
                    // retSystemArr = new  Int16 [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< Int16 > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( Int16 * pOutArr = retSystemArr)
                        fixed ( Int16 * inA1 = A.m_data) 
                        fixed ( Int16 * inA2 = B.m_data) {
                            Int16 * pInA1 = inA1; 
                            Int16 * pInA2 = inA2;
                            int c = 0; 
                            Int16 * poutarr = pOutArr;
                            Int16 * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =  (Int16) ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =  (Int16)  ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =  (Int16) ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =  (Int16)  ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =  (Int16) ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<Int16> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<float>  multiplyElem ( ILArray<float> A,  ILArray<float> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<float> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<float> (new  float [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  float [] retArr = new  float [inDim.NumberOfElements];
                    float [] retArr = ILMemoryPool.Pool.New< float > (inDim.NumberOfElements);
                    float scalarValue = A.GetValue(0); 
                    float tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( float * pOutArr = retArr)
                                fixed ( float * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( float * pOutArr = retArr)
                                    fixed ( float * pInArr = B.m_data) {
                                        float * tmpOut = pOutArr;
                                        float * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        float * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( float * pOutArr = retArr)
                            fixed ( float * pInArr = B.m_data) {
                                float * lastElement = pOutArr + retArr.Length;
                                float * tmpOut = pOutArr;
                                float * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<float> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  float [] retArr = new  float [inDim.NumberOfElements];
                    float [] retArr = ILMemoryPool.Pool.New< float > (inDim.NumberOfElements);
                    float scalarValue = B.GetValue(0); 
                    float tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( float * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( float * pOutArr = retArr)
                                    fixed ( float * pInArr = A.m_data) {
                                        float * tmpOut = pOutArr;
                                        float * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        float * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( float * pOutArr = retArr)
                            fixed ( float * pInArr = A.m_data) {
                                float * lastElement = pOutArr + retArr.Length;
                                float * tmpOut = pOutArr;
                                float * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<float> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    float [] retSystemArr;
                    float tmpValue1; 
                    float tmpValue2; 
                    // retSystemArr = new  float [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< float > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( float * pOutArr = retSystemArr)
                        fixed ( float * inA1 = A.m_data) 
                        fixed ( float * inA2 = B.m_data) {
                            float * pInA1 = inA1; 
                            float * pInA2 = inA2;
                            int c = 0; 
                            float * poutarr = pOutArr;
                            float * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<float> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<fcomplex>  multiplyElem ( ILArray<fcomplex> A,  ILArray<fcomplex> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<fcomplex> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<fcomplex> (new  fcomplex [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  fcomplex [] retArr = new  fcomplex [inDim.NumberOfElements];
                    fcomplex [] retArr = ILMemoryPool.Pool.New< fcomplex > (inDim.NumberOfElements);
                    fcomplex scalarValue = A.GetValue(0); 
                    fcomplex tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( fcomplex * pOutArr = retArr)
                                fixed ( fcomplex * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( fcomplex * pOutArr = retArr)
                                    fixed ( fcomplex * pInArr = B.m_data) {
                                        fcomplex * tmpOut = pOutArr;
                                        fcomplex * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        fcomplex * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( fcomplex * pOutArr = retArr)
                            fixed ( fcomplex * pInArr = B.m_data) {
                                fcomplex * lastElement = pOutArr + retArr.Length;
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<fcomplex> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  fcomplex [] retArr = new  fcomplex [inDim.NumberOfElements];
                    fcomplex [] retArr = ILMemoryPool.Pool.New< fcomplex > (inDim.NumberOfElements);
                    fcomplex scalarValue = B.GetValue(0); 
                    fcomplex tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( fcomplex * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( fcomplex * pOutArr = retArr)
                                    fixed ( fcomplex * pInArr = A.m_data) {
                                        fcomplex * tmpOut = pOutArr;
                                        fcomplex * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        fcomplex * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( fcomplex * pOutArr = retArr)
                            fixed ( fcomplex * pInArr = A.m_data) {
                                fcomplex * lastElement = pOutArr + retArr.Length;
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<fcomplex> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    fcomplex [] retSystemArr;
                    fcomplex tmpValue1; 
                    fcomplex tmpValue2; 
                    // retSystemArr = new  fcomplex [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< fcomplex > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( fcomplex * pOutArr = retSystemArr)
                        fixed ( fcomplex * inA1 = A.m_data) 
                        fixed ( fcomplex * inA2 = B.m_data) {
                            fcomplex * pInA1 = inA1; 
                            fcomplex * pInA2 = inA2;
                            int c = 0; 
                            fcomplex * poutarr = pOutArr;
                            fcomplex * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<fcomplex> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<complex>  multiplyElem ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<complex> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<complex> (new  complex [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  complex [] retArr = new  complex [inDim.NumberOfElements];
                    complex [] retArr = ILMemoryPool.Pool.New< complex > (inDim.NumberOfElements);
                    complex scalarValue = A.GetValue(0); 
                    complex tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( complex * pOutArr = retArr)
                                fixed ( complex * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( complex * pOutArr = retArr)
                                    fixed ( complex * pInArr = B.m_data) {
                                        complex * tmpOut = pOutArr;
                                        complex * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        complex * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( complex * pOutArr = retArr)
                            fixed ( complex * pInArr = B.m_data) {
                                complex * lastElement = pOutArr + retArr.Length;
                                complex * tmpOut = pOutArr;
                                complex * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<complex> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  complex [] retArr = new  complex [inDim.NumberOfElements];
                    complex [] retArr = ILMemoryPool.Pool.New< complex > (inDim.NumberOfElements);
                    complex scalarValue = B.GetValue(0); 
                    complex tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( complex * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( complex * pOutArr = retArr)
                                    fixed ( complex * pInArr = A.m_data) {
                                        complex * tmpOut = pOutArr;
                                        complex * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        complex * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( complex * pOutArr = retArr)
                            fixed ( complex * pInArr = A.m_data) {
                                complex * lastElement = pOutArr + retArr.Length;
                                complex * tmpOut = pOutArr;
                                complex * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<complex> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    complex [] retSystemArr;
                    complex tmpValue1; 
                    complex tmpValue2; 
                    // retSystemArr = new  complex [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< complex > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( complex * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            int c = 0; 
                            complex * poutarr = pOutArr;
                            complex * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<complex> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<char>  multiplyElem ( ILArray<char> A,  ILArray<char> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<char> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<char> (new  char [1]{ (char) (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  char [] retArr = new  char [inDim.NumberOfElements];
                    char [] retArr = ILMemoryPool.Pool.New< char > (inDim.NumberOfElements);
                    char scalarValue = A.GetValue(0); 
                    char tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( char * pOutArr = retArr)
                                fixed ( char * pInArr = B.m_data) {
                                        char * tmpOut = pOutArr;
                                        char * tmpIn = pInArr;
                                        char * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (char) (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( char * pOutArr = retArr)
                                    fixed ( char * pInArr = B.m_data) {
                                        char * tmpOut = pOutArr;
                                        char * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        char * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (char) (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( char * pOutArr = retArr)
                            fixed ( char * pInArr = B.m_data) {
                                char * lastElement = pOutArr + retArr.Length;
                                char * tmpOut = pOutArr;
                                char * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =  (char) (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<char> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  char [] retArr = new  char [inDim.NumberOfElements];
                    char [] retArr = ILMemoryPool.Pool.New< char > (inDim.NumberOfElements);
                    char scalarValue = B.GetValue(0); 
                    char tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( char * pOutArr = retArr)
                                fixed ( char * pInArr = A.m_data) {
                                        char * tmpOut = pOutArr;
                                        char * tmpIn = pInArr;
                                        char * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
                                        int* secDimEnd = secDimStart + idxOffset [secDim].Length;
                                        int* secDimIdx = secDimStart;
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        while (secDimIdx < secDimEnd) {
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOut - tmpOutEnd);
                                            tmpIn = pInArr + *secDimIdx++;
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =  (char) (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( char * pOutArr = retArr)
                                    fixed ( char * pInArr = A.m_data) {
                                        char * tmpOut = pOutArr;
                                        char * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        char * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =  (char) (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( char * pOutArr = retArr)
                            fixed ( char * pInArr = A.m_data) {
                                char * lastElement = pOutArr + retArr.Length;
                                char * tmpOut = pOutArr;
                                char * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =  (char) (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<char> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    char [] retSystemArr;
                    char tmpValue1; 
                    char tmpValue2; 
                    // retSystemArr = new  char [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< char > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( char * pOutArr = retSystemArr)
                        fixed ( char * inA1 = A.m_data) 
                        fixed ( char * inA2 = B.m_data) {
                            char * pInA1 = inA1; 
                            char * pInA2 = inA2;
                            int c = 0; 
                            char * poutarr = pOutArr;
                            char * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =  (char) ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =  (char)  ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =  (char) ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =  (char)  ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =  (char) ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<char> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<byte>  multiplyElem ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<byte> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<byte> (new  byte [1]{ (byte) (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  byte [] retArr = new  byte [inDim.NumberOfElements];
                    byte [] retArr = ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);
                    byte scalarValue = A.GetValue(0); 
                    byte tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( byte * pOutArr = retArr)
                                fixed ( byte * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (byte) (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( byte * pOutArr = retArr)
                                    fixed ( byte * pInArr = B.m_data) {
                                        byte * tmpOut = pOutArr;
                                        byte * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        byte * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =  (byte) (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( byte * pOutArr = retArr)
                            fixed ( byte * pInArr = B.m_data) {
                                byte * lastElement = pOutArr + retArr.Length;
                                byte * tmpOut = pOutArr;
                                byte * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =  (byte) (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<byte> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  byte [] retArr = new  byte [inDim.NumberOfElements];
                    byte [] retArr = ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);
                    byte scalarValue = B.GetValue(0); 
                    byte tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( byte * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =  (byte) (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( byte * pOutArr = retArr)
                                    fixed ( byte * pInArr = A.m_data) {
                                        byte * tmpOut = pOutArr;
                                        byte * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        byte * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =  (byte) (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( byte * pOutArr = retArr)
                            fixed ( byte * pInArr = A.m_data) {
                                byte * lastElement = pOutArr + retArr.Length;
                                byte * tmpOut = pOutArr;
                                byte * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =  (byte) (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<byte> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    byte [] retSystemArr;
                    byte tmpValue1; 
                    byte tmpValue2; 
                    // retSystemArr = new  byte [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            int c = 0; 
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =  (byte) ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =  (byte)  ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =  (byte) ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =  (byte)  ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =  (byte) ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<byte> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Multiply elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise multiplication of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<double>  multiplyElem ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty || B.IsEmpty ) {
                return  ILArray<double> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<double> (new  double [1]{  (A.GetValue(0)  * B.GetValue(0))});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;
                    //  double [] retArr = new  double [inDim.NumberOfElements];
                    double [] retArr = ILMemoryPool.Pool.New< double > (inDim.NumberOfElements);
                    double scalarValue = A.GetValue(0); 
                    double tmpValue2; 
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (B.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = B.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!B.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (B.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( double * pOutArr = retArr)
                                fixed ( double * pInArr = B.m_data) {
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
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*( tmpIn + *leadDimIdx++ )));
                                                tmpOut += incOut;
                                            }
                                        }
                                }
                            }
                            #endregion
                        } else {
                            #region arbitrary size
                            unsafe {
                                int [] curPosition = new int [B.Dimensions.NumberOfDimensions];
                                fixed (int* leadDimStart = idxOffset [leadDim]) {
                                    fixed ( double * pOutArr = retArr)
                                    fixed ( double * pInArr = B.m_data) {
                                        double * tmpOut = pOutArr;
                                        double * tmpOutEnd = tmpOut + retArr.Length;
                                        // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                        double * tmpIn = pInArr + B.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {
                                               
                                                *tmpOut =   (scalarValue  * (*(tmpIn + *leadDimIdx++)));
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( double * pOutArr = retArr)
                            fixed ( double * pInArr = B.m_data) {
                                double * lastElement = pOutArr + retArr.Length;
                                double * tmpOut = pOutArr;
                                double * tmpIn = pInArr;
                                while (tmpOut < lastElement) //HC03
                                    
                                	*tmpOut++ =   (scalarValue  * (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<double> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;
                    //  double [] retArr = new  double [inDim.NumberOfElements];
                    double [] retArr = ILMemoryPool.Pool.New< double > (inDim.NumberOfElements);
                    double scalarValue = B.GetValue(0); 
                    double tmpValue1;
                    int leadDim = 0,leadDimLen = inDim [0];
                    if (A.IsReference) {
                        #region Reference storage
                        // walk along the longest dimension (for performance reasons)
                        ILIndexOffset idxOffset = A.m_indexOffset;
                        int incOut = inDim.SequentialIndexDistance ( leadDim );
                        System.Diagnostics.Debug.Assert(!A.IsVector,"Reference arrays of vector size should not exist!"); 
                        for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                            if (leadDimLen < inDim [i]) {
                                leadDimLen = inDim [i];
                                leadDim = i;
                                incOut = inDim.SequentialIndexDistance ( leadDim );
                            }
                        }
                        if (A.IsMatrix) {
                            #region Matrix
                            ////////////////////////////   MATRIX   ////////////////////
                            int secDim = ( leadDim + 1 ) % 2;
                            unsafe {
                                fixed (int* leadDimStart = idxOffset [leadDim],secDimStart = idxOffset [secDim])
                                fixed ( double * pOutArr = retArr)
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
                                            while (leadDimIdx < leadDimEnd) { //HC04
                                                
                                                *tmpOut =   (*( tmpIn + *leadDimIdx++ )  * scalarValue);
                                                tmpOut += incOut;
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
                                    fixed ( double * pOutArr = retArr)
                                    fixed ( double * pInArr = A.m_data) {
                                        double * tmpOut = pOutArr;
                                        double * tmpOutEnd = tmpOut + retArr.Length;
                                        // init readpointer: add all Dimensions with 0 (except leadDim)
                                        double * tmpIn = pInArr + A.getBaseIndex (0,0);
                                        tmpIn -= idxOffset [leadDim, 0];
                                        int* leadDimIdx = leadDimStart;
                                        int* leadDimEnd = leadDimStart + leadDimLen;
                                        int dimLen = curPosition.Length;
                                        int d, curD;
                                        // start at first element
                                        while (tmpOut < tmpOutEnd) {
                                            leadDimIdx = leadDimStart;
                                            while (leadDimIdx < leadDimEnd) {   //HC05
                                                
                                                *tmpOut =   (*(tmpIn + *leadDimIdx++)  * scalarValue);
                                                tmpOut += incOut;
                                            }
                                            if (tmpOut > tmpOutEnd)
                                                tmpOut = pOutArr + ( tmpOutEnd - tmpOut );

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
                            fixed ( double * pOutArr = retArr)
                            fixed ( double * pInArr = A.m_data) {
                                double * lastElement = pOutArr + retArr.Length;
                                double * tmpOut = pOutArr;
                                double * tmpIn = pInArr;
                                while (tmpOut < lastElement) { //HC06
                                    
                                    *tmpOut++ =   (*tmpIn++  * scalarValue);
                                }
                            }
                        }
                        #endregion
                        //tmpValue1 = 0; 
                    }
                    return new  ILArray<double> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();
                    double [] retSystemArr;
                    double tmpValue1; 
                    double tmpValue2; 
                    // retSystemArr = new  double [inDim.NumberOfElements];
                    retSystemArr = ILMemoryPool.Pool.New< double > (inDim.NumberOfElements);
                    
                    int leadDim = 0, leadDimLen = inDim [0];
                    // this will most probably be not very fast, but .... :|
                    // walk along the longest dimension (for performance reasons)
                    for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                        if (leadDimLen < inDim [i]) {
                            leadDimLen = inDim [i];
                            leadDim = i;
                        }
                    }
                    unsafe {
                        fixed ( double * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            int c = 0; 
                            double * poutarr = pOutArr;
                            double * outEnd = poutarr + retSystemArr.Length;
                            if (A.IsReference) { 
                                if (!B.IsReference) {
                                    while (poutarr < outEnd) {  //HC07
                                        
                                        *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c++))  * (*pInA2++));
                                    }
                                } else {
                                    // optimization for matrix 
                                    if (inDim.NumberOfDimensions < 3) {
                                        fixed (int * pA1idx0 = A.m_indexOffset[0])
                                        fixed (int * pA1idx1 = A.m_indexOffset[1])
                                        fixed (int * pA2idx0 = B.m_indexOffset[0])
                                        fixed (int * pA2idx1 = B.m_indexOffset[1]) {
                                            int r = 0, rLen = A.m_dimensions[0];
                                            int        cLen = A.m_dimensions[1]; 
                                            while (poutarr < outEnd) {   //HC08
                                               
                                                *poutarr++ =    ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) *  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   ( *(pInA1 + A.getBaseIndex(c)) *  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =    ( *pInA1++  *  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   ( *pInA1++ /*HC:*/ *  (*pInA2++));
                                    }
                                }
                            }
                        }
                    }
                    return new  ILArray<double> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
