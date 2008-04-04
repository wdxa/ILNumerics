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
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>double</destination>
        <destination>float</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>double</destination>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>Math.Sqrt</destination>
        <destination>(float)Math.Sqrt</destination>
        <destination>fcomplex.Sqrt</destination>
        <destination>complex.Sqrt</destination>
        <destination>complex.Sqrt</destination>
        <destination>fcomplex.Sqrt</destination>
    </type>
    <type>
        <source locate="after">
            HCfuncname
        </source>
        <destination>sqrt</destination>
        <destination>sqrt</destination>
        <destination>sqrt</destination>
        <destination>sqrt</destination>
        <destination>sqrtc</destination>
        <destination>sqrtc</destination>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination>Square root of array elements - real output</destination>
        <destination>Square root of array elements - real output</destination>
        <destination>Square root of array elements</destination>
        <destination>Square root of array elements</destination>
        <destination>Square root of array elements - complex output</destination>
        <destination>Square root of array elements - complex output</destination>
    </type>
    <type>
        <source locate="comment">
            <![CDATA[param name="inArray"]]>        
        </source>
        <destination>input array - only positive values are allowed.</destination>
        <destination>input array - only positive values are allowed.</destination>
        <destination>input array</destination>
        <destination>input array</destination>
        <destination>input array - positive and negative values allowed</destination>
        <destination>input array - positive and negative values allowed</destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination>Cosine of array elements - real output</destination>
        <destination>Cosine of array elements - real output</destination>
        <destination>Cosine of array elements</destination>
        <destination>Cosine of array elements</destination>
        <destination>Cosine of array elements - complex output</destination>
        <destination>Cosine of array elements - complex output</destination>
    </type>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs

        #endregion HYCALPER LOOPEND UNARY_OPERATOR_TEMPLATE@Functions\builtin\sin.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<fcomplex>  sqrtc ( ILArray<float> A) {
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
                            fixed ( float * pInArr = A.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                float * tmpIn = pInArr;
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
                                       
                                        *tmpOut =  fcomplex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                            fixed ( float * pInArr = A.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpOutEnd = tmpOut + retDblArr.Length;
                                float * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  fcomplex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( fcomplex * pOutArr = retDblArr)
                    fixed ( float * pInArr = A.m_data) {
                        fcomplex * lastElement = pOutArr + retDblArr.Length;
                        fcomplex * tmpOut = pOutArr;
                        float * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  fcomplex.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<complex>  sqrtc ( ILArray<double> A) {
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
                            fixed ( double * pInArr = A.m_data) {
                                complex * tmpOut = pOutArr;
                                double * tmpIn = pInArr;
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
                                       
                                        *tmpOut =  complex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                            fixed ( double * pInArr = A.m_data) {
                                complex * tmpOut = pOutArr;
                                complex * tmpOutEnd = tmpOut + retDblArr.Length;
                                double * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  complex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( complex * pOutArr = retDblArr)
                    fixed ( double * pInArr = A.m_data) {
                        complex * lastElement = pOutArr + retDblArr.Length;
                        complex * tmpOut = pOutArr;
                        double * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  complex.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<complex>  sqrt ( ILArray<complex> A) {
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
                                       
                                        *tmpOut =  complex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                complex * tmpOutEnd = tmpOut + retDblArr.Length;
                                complex * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  complex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( complex * pOutArr = retDblArr)
                    fixed ( complex * pInArr = A.m_data) {
                        complex * lastElement = pOutArr + retDblArr.Length;
                        complex * tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  complex.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<fcomplex>  sqrt ( ILArray<fcomplex> A) {
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
                                       
                                        *tmpOut =  fcomplex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                fcomplex * tmpOutEnd = tmpOut + retDblArr.Length;
                                fcomplex * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  fcomplex.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( fcomplex * pOutArr = retDblArr)
                    fixed ( fcomplex * pInArr = A.m_data) {
                        fcomplex * lastElement = pOutArr + retDblArr.Length;
                        fcomplex * tmpOut = pOutArr;
                        fcomplex * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  fcomplex.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<float>  sqrt ( ILArray<float> A) {
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
                                       
                                        *tmpOut =  (float)Math.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                float * tmpOutEnd = tmpOut + retDblArr.Length;
                                float * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  (float)Math.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( float * pOutArr = retDblArr)
                    fixed ( float * pInArr = A.m_data) {
                        float * lastElement = pOutArr + retDblArr.Length;
                        float * tmpOut = pOutArr;
                        float * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  (float)Math.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retDblArr, inDim.ToIntArray () );
        }
        /// <summary>
        /// Sinus of array elements 
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>Sinus of elements from input array</returns>
        /// <remarks><para>If the input array is empty, an empty array will be returned.</para>
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<double>  sqrt ( ILArray<double> A) {
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
                                       
                                        *tmpOut =  Math.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                double * tmpOutEnd = tmpOut + retDblArr.Length;
                                double * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                       
                                        *tmpOut =  Math.Sqrt ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                    fixed ( double * pOutArr = retDblArr)
                    fixed ( double * pInArr = A.m_data) {
                        double * lastElement = pOutArr + retDblArr.Length;
                        double * tmpOut = pOutArr;
                        double * tmpIn = pInArr;
                        while (tmpOut < lastElement) { // HC02
                           
                            *tmpOut++ =  Math.Sqrt ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<double> ( retDblArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
