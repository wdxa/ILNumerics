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

/////   this is a template for unary - implace functions 

/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>

        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>*(-1.0)</destination>
        <destination>*(-1.0f)</destination>
        <destination>*(-1.0f)</destination>
        <destination>*(-1)</destination>
        <destination>*(-1)</destination>
        <destination>*(-1)</destination>
        <destination>*(-1)</destination>
    </type>
    <type>
        <source locate="after">
            outCast
        </source>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination>(Int16)</destination>
        <destination></destination>
        <destination></destination>
        <destination>(byte)</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {         
         
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE_implace
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void /*!HC:HCFuncName*/ invert (/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls2*/ ILArray<double> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed (/*!HC:inArr1*/ double * inA1 = A.m_data) 
                fixed (/*!HC:inArr2*/ double * inA2 = outArray.m_data) {
                    /*!HC:inArr1*/ double * pInA1 = inA1; 
                    /*!HC:inArr2*/ double * pInA2 = inA2;
                    int c = 0; 
                    /*!HC:inArr2*/ double * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            /*!HC:HCCompute07*/ 
                            *pInA2++ = /*!HC:outCast*/ /**/ ( *(pInA1 + A.getBaseIndex(c++)) /*!HC:HCoperation*/ *-1.0 );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                            /*!HC:HCCompute11*/  
                            *pInA2++ = /*!HC:outCast*/ /**/ ( *pInA1++ /*HC:HCoperation*/ *(-1.0) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<byte> A,  ILArray<byte> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( byte * inA1 = A.m_data) 
                fixed ( byte * inA2 = outArray.m_data) {
                    byte * pInA1 = inA1; 
                    byte * pInA2 = inA2;
                    int c = 0; 
                    byte * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =  (byte) ( *(pInA1 + A.getBaseIndex(c++))  *(-1) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =  (byte) ( *pInA1++ /*HC:*/ *(-1) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<Int64> A,  ILArray<Int64> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( Int64 * inA1 = A.m_data) 
                fixed ( Int64 * inA2 = outArray.m_data) {
                    Int64 * pInA1 = inA1; 
                    Int64 * pInA2 = inA2;
                    int c = 0; 
                    Int64 * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =   ( *(pInA1 + A.getBaseIndex(c++))  *(-1) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =   ( *pInA1++ /*HC:*/ *(-1) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<Int32> A,  ILArray<Int32> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( Int32 * inA1 = A.m_data) 
                fixed ( Int32 * inA2 = outArray.m_data) {
                    Int32 * pInA1 = inA1; 
                    Int32 * pInA2 = inA2;
                    int c = 0; 
                    Int32 * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =   ( *(pInA1 + A.getBaseIndex(c++))  *(-1) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =   ( *pInA1++ /*HC:*/ *(-1) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<Int16> A,  ILArray<Int16> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( Int16 * inA1 = A.m_data) 
                fixed ( Int16 * inA2 = outArray.m_data) {
                    Int16 * pInA1 = inA1; 
                    Int16 * pInA2 = inA2;
                    int c = 0; 
                    Int16 * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =  (Int16) ( *(pInA1 + A.getBaseIndex(c++))  *(-1) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =  (Int16) ( *pInA1++ /*HC:*/ *(-1) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<float> A,  ILArray<float> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( float * inA1 = A.m_data) 
                fixed ( float * inA2 = outArray.m_data) {
                    float * pInA1 = inA1; 
                    float * pInA2 = inA2;
                    int c = 0; 
                    float * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =   ( *(pInA1 + A.getBaseIndex(c++))  *(-1.0f) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =   ( *pInA1++ /*HC:*/ *(-1.0f) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<fcomplex> A,  ILArray<fcomplex> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( fcomplex * inA1 = A.m_data) 
                fixed ( fcomplex * inA2 = outArray.m_data) {
                    fcomplex * pInA1 = inA1; 
                    fcomplex * pInA2 = inA2;
                    int c = 0; 
                    fcomplex * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =   ( *(pInA1 + A.getBaseIndex(c++))  *(-1.0f) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =   ( *pInA1++ /*HC:*/ *(-1.0f) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }
        /// <summary>
        /// invert elements of A, return result as out argument
        /// </summary>
        /// <param name="A"></param>
        /// <param name="outArray"></param>
        public static void  invert ( ILArray<complex> A,  ILArray<complex> outArray) {
            #region array + array
            ILDimension inDim = A.Dimensions;
            if (!inDim.IsSameSize ( outArray.Dimensions ))
                throw new ILDimensionMismatchException ();
            int leadDim = 0, leadDimLen = inDim [0];
            // walk along the longest dimension (for performance reasons)
            for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                if (leadDimLen < inDim [i]) {
                    leadDimLen = inDim [i];
                    leadDim = i;
                }
            }
            unsafe {
                fixed ( complex * inA1 = A.m_data) 
                fixed ( complex * inA2 = outArray.m_data) {
                    complex * pInA1 = inA1; 
                    complex * pInA2 = inA2;
                    int c = 0; 
                    complex * outEnd = inA2 + outArray.m_data.Length;
                    if (A.IsReference) { 
                        while (pInA2 < outEnd) {  //HC07
                            
                            *pInA2++ =   ( *(pInA1 + A.getBaseIndex(c++))  *(-1.0) );
                        }
                    } else {
                        while (pInA2 < outEnd) {  //HC11
                             
                            *pInA2++ =   ( *pInA1++ /*HC:*/ *(-1.0) );
                        }
                    }
                }
                #endregion array + array
            }
            return;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}