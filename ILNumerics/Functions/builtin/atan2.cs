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
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            HCscalValT
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCast
        </source>                                                 
        <destination> Math.Atan2</destination>                               
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>,</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>atan2</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {         
         
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs

        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE@Add.cs       
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the 
        /// other array in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.
        /// </para></remarks>
        public static  ILArray<double>  atan2 ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty && B.IsEmpty ) {
                if (!A.Dimensions.IsSameShape(B.Dimensions))
                    throw new ILDimensionMismatchException(); 
                return  ILArray<double> .empty(A.Dimensions); 
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<double> (new  double [1]{  Math.Atan2 (A.GetValue(0)  , B.GetValue(0))}, A.Dimensions);
                } else {
                    if (B.IsEmpty) {
                        return  ILArray<double> .empty(B.Dimensions); 
                    }
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
                                               
                                                *tmpOut =   Math.Atan2 (scalarValue  , (*( tmpIn + *leadDimIdx++ )));
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
                                               
                                                *tmpOut =   Math.Atan2 (scalarValue  , (*(tmpIn + *leadDimIdx++)));
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
                                    
                                	*tmpOut++ =   Math.Atan2 (scalarValue  , (*tmpIn++));
                            }       
                        }
                        #endregion
                    }
                    return new  ILArray<double> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    if (A.IsEmpty) {
                        return  ILArray<double> .empty(A.Dimensions);  
                    }
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
                                                
                                                *tmpOut =   Math.Atan2 (*( tmpIn + *leadDimIdx++ )  , scalarValue);
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
                                                
                                                *tmpOut =   Math.Atan2 (*(tmpIn + *leadDimIdx++)  , scalarValue);
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
                                    
                                    *tmpOut++ =   Math.Atan2 (*tmpIn++  , scalarValue);
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
                    if (!inDim.IsSameShape ( B.Dimensions ))
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
                                        
                                        *poutarr++ =   Math.Atan2 ( *(pInA1 + A.getBaseIndex(c++))  , (*pInA2++));
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
                                               
                                                *poutarr++ =   Math.Atan2  ( *(pInA1 + (*(pA1idx0 + r)) + (*(pA1idx1 + c))) ,  (*(pInA2+ (*(pA2idx0 + r)) + (*(pA2idx1 + c)))));
                                                if (++r == rLen) {
                                                    r = 0; 
                                                    c++; 
                                                }
                                            }
                                        }
                                    } else {
                                         while (poutarr < outEnd) {  //HC09
                                             
                                             *poutarr++ =   Math.Atan2 ( *(pInA1 + A.getBaseIndex(c)) ,  (*(pInA2+B.getBaseIndex(c++))));
                                        }
                                   }
                                   // tmpValue1 = 0; tmpValue2 = 0; 
                                }
                            } else {
                                if (B.IsReference) {
                                    while (poutarr < outEnd) {  //HC10
                                         
                                        *poutarr++ =   Math.Atan2  ( *pInA1++  ,  (*(pInA2 + B.getBaseIndex(c++))));
                                    }
                                } else {
                                    while (poutarr < outEnd) {  //HC11
                                         
                                        *poutarr++ =   Math.Atan2 ( *pInA1++ /*HC:*/ ,  (*pInA2++));
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