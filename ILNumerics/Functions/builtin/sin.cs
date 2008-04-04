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
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>(float)Math.Sin</destination>
        <destination>fcomplex.Sin</destination>
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
        /// <para>The array returned will be a solid array.</para></remarks>
        public static /*!HC:outCls*/ ILArray<double> /*!HC:HCfuncname*/ sin (/*!HC:inCls1*/ ILArray<double> A) {
            if (A.IsEmpty)
                return /*!HC:outCls*/ ILArray<double> .empty(); 
            ILDimension inDim = A.Dimensions;
            /*!HC:outArr*/ double [] retDblArr;
            // build ILDimension    
            int newLength = inDim.NumberOfElements;
            //retDblArr = new /*!HC:outArr*/ double [newLength];
            retDblArr = ILMemoryPool.Pool.New</*!HC:outArr*/ double > (newLength); 
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
                            fixed (/*!HC:outArr*/ double * pOutArr = retDblArr)
                            fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                                /*!HC:outArr*/ double * tmpOut = pOutArr;
                                /*!HC:inArr1*/ double * tmpIn = pInArr;
                                /*!HC:outArr*/ double * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
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
                                        /*!HC:HCCompute00*/
                                        *tmpOut = /*!HC:HCoperation*/ Math.Sin ( *( tmpIn + *leadDimIdx++ ) ) /*!HC:HCpostOp*/ ;
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
                            fixed (/*!HC:outArr*/ double * pOutArr = retDblArr)
                            fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                                /*!HC:outArr*/ double * tmpOut = pOutArr;
                                /*!HC:outArr*/ double * tmpOutEnd = tmpOut + retDblArr.Length;
                                /*!HC:inArr1*/ double * tmpIn = pInArr + A.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {  //HC01
                                        /*!HC:HCCompute01*/
                                        *tmpOut = /*!HC:HCoperation*/ Math.Sin ( *( tmpIn + *leadDimIdx++ ) ) /*!HC:HCpostOp*/ ;
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
                #endregion
            }
            return new /*!HC:outCls*/ ILArray<double> ( retDblArr, inDim.ToIntArray () );
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
        /// <para>The array returned will be a solid array.</para></remarks>
        public static  ILArray<complex>  sin ( ILArray<complex> A) {
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
                                       
                                        *tmpOut =  complex.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                       
                                        *tmpOut =  complex.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                           
                            *tmpOut++ =  complex.Sin ( *tmpIn++ )  ;
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
        public static  ILArray<fcomplex>  sin ( ILArray<fcomplex> A) {
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
                                       
                                        *tmpOut =  fcomplex.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                       
                                        *tmpOut =  fcomplex.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                           
                            *tmpOut++ =  fcomplex.Sin ( *tmpIn++ )  ;
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
        public static  ILArray<float>  sin ( ILArray<float> A) {
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
                                       
                                        *tmpOut =  (float)Math.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                                       
                                        *tmpOut =  (float)Math.Sin ( *( tmpIn + *leadDimIdx++ ) )  ;
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
                           
                            *tmpOut++ =  (float)Math.Sin ( *tmpIn++ )  ;
                        }
                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retDblArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
