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
using System.Runtime.InteropServices; 
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Native;
using ILNumerics.Exceptions;

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {

        #region HYCALPER LOOPSTART WALKER_BINARY
        /*!HC:TYPELIST:
<hycalper>
    <type>
        <source	locate="after">
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
        <source	locate="after">
            inArr2
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
        <source	locate="after">
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
    <type>
        <source	locate="after">
            inCls2
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
    <type>
        <source	locate="after">
            outCls1
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
    <type>
        <source	locate="after">
            outArr1
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
        <source	locate="after">
            delegate_binary
        </source>
        <destination>ILByteFunctionByteByte</destination>
        <destination>ILCharFunctionCharChar</destination>
        <destination>ILComplexFunctionComplexComplex</destination>
        <destination>ILFcomplexFunctionFcomplexFcomplex</destination>
        <destination>ILFloatFunctionFloatFloat</destination>
        <destination>ILInt16FunctionInt16Int16</destination>
        <destination>ILInt32FunctionInt32Int32</destination>
        <destination>ILInt64FunctionInt64Int64</destination>
        <destination>ILUInt16FunctionUInt16UInt16</destination>
        <destination>ILUInt32FunctionUInt32UInt32</destination>
        <destination>ILUInt64FunctionUInt64UInt64</destination>
    </type>
    <type>
        <source	locate="after">
            hcfunctionName
        </source>
        <destination>ByteOperatorByteByte</destination>
        <destination>CharOperatorCharChar</destination>
        <destination>ComplexOperatorComplexComplex</destination>
        <destination>FcomplexOperatorFcomplexFcomplex</destination>
        <destination>FloatOperatorFloatFloat</destination>
        <destination>Int16OperatorInt16Int16</destination>
        <destination>Int32OperatorInt32Int32</destination>
        <destination>Int64OperatorInt64Int64</destination>
        <destination>UInt16OperatorUInt16UInt16</destination>
        <destination>UInt32OperatorUInt32UInt32</destination>
        <destination>UInt64OperatorUInt64UInt64</destination>
    </type>
</hycalper>
*/
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[ /*!HC:outCls1*/ ILArray<double> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static /*!HC:outCls1*/ ILArray<double> /*!HC:hcfunctionName*/ DoubleOperatorDoubleDouble (/*!HC:inCls1*/ ILArray<double> inArray1,/*!HC:inCls2*/ ILArray<double> inArray2,
            /*!HC:delegate_binary*/ ILDoubleFunctionDoubleDouble operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            /*!HC:outArr1*/ double [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new /*!HC:outArr1*/ double [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed (/*!HC:outArr1*/ double * pOutArr = retSystemArr)
                    fixed (/*!HC:inArr1*/ double * inA1 = inArray1.m_data) 
                    fixed (/*!HC:inArr2*/ double * inA2 = inArray2.m_data) {
                        /*!HC:inArr1*/ double * pInA1 = inA1; 
                        /*!HC:inArr2*/ double * pInA2 = inA2;
                        int c = 0; 
                        /*!HC:outArr1*/ double * poutarr = pOutArr;
                        /*!HC:outArr1*/ double * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed (/*!HC:inArr1*/ double * pInArr1 = inArray1.m_data)
                    fixed (/*!HC:inArr2*/ double * pInArr2 = inArray2.m_data)
                    fixed (/*!HC:outArr1*/ double * pOutArr = retSystemArr) {
                        /*!HC:outArr1*/ double * poutarr = pOutArr;
                        /*!HC:outArr1*/ double * poutend = poutarr + newLength;
                        /*!HC:inArr1*/ double * pIn1 = pInArr1;
                        /*!HC:inArr2*/ double * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new /*!HC:outCls1*/ ILArray<double> ( retSystemArr, inDim.ToIntArray () );
        }
        #endregion HYCALPER LOOPEND WALKER_BINARY
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<UInt64> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<UInt64>  UInt64OperatorUInt64UInt64 ( ILArray<UInt64> inArray1, ILArray<UInt64> inArray2,
            ILUInt64FunctionUInt64UInt64 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            UInt64 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  UInt64 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( UInt64 * pOutArr = retSystemArr)
                    fixed ( UInt64 * inA1 = inArray1.m_data) 
                    fixed ( UInt64 * inA2 = inArray2.m_data) {
                        UInt64 * pInA1 = inA1; 
                        UInt64 * pInA2 = inA2;
                        int c = 0; 
                        UInt64 * poutarr = pOutArr;
                        UInt64 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt64 * pInArr1 = inArray1.m_data)
                    fixed ( UInt64 * pInArr2 = inArray2.m_data)
                    fixed ( UInt64 * pOutArr = retSystemArr) {
                        UInt64 * poutarr = pOutArr;
                        UInt64 * poutend = poutarr + newLength;
                        UInt64 * pIn1 = pInArr1;
                        UInt64 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<UInt64> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<UInt32> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<UInt32>  UInt32OperatorUInt32UInt32 ( ILArray<UInt32> inArray1, ILArray<UInt32> inArray2,
            ILUInt32FunctionUInt32UInt32 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            UInt32 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  UInt32 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( UInt32 * pOutArr = retSystemArr)
                    fixed ( UInt32 * inA1 = inArray1.m_data) 
                    fixed ( UInt32 * inA2 = inArray2.m_data) {
                        UInt32 * pInA1 = inA1; 
                        UInt32 * pInA2 = inA2;
                        int c = 0; 
                        UInt32 * poutarr = pOutArr;
                        UInt32 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt32 * pInArr1 = inArray1.m_data)
                    fixed ( UInt32 * pInArr2 = inArray2.m_data)
                    fixed ( UInt32 * pOutArr = retSystemArr) {
                        UInt32 * poutarr = pOutArr;
                        UInt32 * poutend = poutarr + newLength;
                        UInt32 * pIn1 = pInArr1;
                        UInt32 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<UInt32> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<UInt16> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<UInt16>  UInt16OperatorUInt16UInt16 ( ILArray<UInt16> inArray1, ILArray<UInt16> inArray2,
            ILUInt16FunctionUInt16UInt16 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            UInt16 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  UInt16 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( UInt16 * pOutArr = retSystemArr)
                    fixed ( UInt16 * inA1 = inArray1.m_data) 
                    fixed ( UInt16 * inA2 = inArray2.m_data) {
                        UInt16 * pInA1 = inA1; 
                        UInt16 * pInA2 = inA2;
                        int c = 0; 
                        UInt16 * poutarr = pOutArr;
                        UInt16 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt16 * pInArr1 = inArray1.m_data)
                    fixed ( UInt16 * pInArr2 = inArray2.m_data)
                    fixed ( UInt16 * pOutArr = retSystemArr) {
                        UInt16 * poutarr = pOutArr;
                        UInt16 * poutend = poutarr + newLength;
                        UInt16 * pIn1 = pInArr1;
                        UInt16 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<UInt16> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<Int64> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<Int64>  Int64OperatorInt64Int64 ( ILArray<Int64> inArray1, ILArray<Int64> inArray2,
            ILInt64FunctionInt64Int64 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            Int64 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  Int64 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( Int64 * pOutArr = retSystemArr)
                    fixed ( Int64 * inA1 = inArray1.m_data) 
                    fixed ( Int64 * inA2 = inArray2.m_data) {
                        Int64 * pInA1 = inA1; 
                        Int64 * pInA2 = inA2;
                        int c = 0; 
                        Int64 * poutarr = pOutArr;
                        Int64 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int64 * pInArr1 = inArray1.m_data)
                    fixed ( Int64 * pInArr2 = inArray2.m_data)
                    fixed ( Int64 * pOutArr = retSystemArr) {
                        Int64 * poutarr = pOutArr;
                        Int64 * poutend = poutarr + newLength;
                        Int64 * pIn1 = pInArr1;
                        Int64 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<Int64> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<Int32> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<Int32>  Int32OperatorInt32Int32 ( ILArray<Int32> inArray1, ILArray<Int32> inArray2,
            ILInt32FunctionInt32Int32 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            Int32 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  Int32 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( Int32 * pOutArr = retSystemArr)
                    fixed ( Int32 * inA1 = inArray1.m_data) 
                    fixed ( Int32 * inA2 = inArray2.m_data) {
                        Int32 * pInA1 = inA1; 
                        Int32 * pInA2 = inA2;
                        int c = 0; 
                        Int32 * poutarr = pOutArr;
                        Int32 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int32 * pInArr1 = inArray1.m_data)
                    fixed ( Int32 * pInArr2 = inArray2.m_data)
                    fixed ( Int32 * pOutArr = retSystemArr) {
                        Int32 * poutarr = pOutArr;
                        Int32 * poutend = poutarr + newLength;
                        Int32 * pIn1 = pInArr1;
                        Int32 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<Int32> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<Int16> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<Int16>  Int16OperatorInt16Int16 ( ILArray<Int16> inArray1, ILArray<Int16> inArray2,
            ILInt16FunctionInt16Int16 operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            Int16 [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  Int16 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( Int16 * pOutArr = retSystemArr)
                    fixed ( Int16 * inA1 = inArray1.m_data) 
                    fixed ( Int16 * inA2 = inArray2.m_data) {
                        Int16 * pInA1 = inA1; 
                        Int16 * pInA2 = inA2;
                        int c = 0; 
                        Int16 * poutarr = pOutArr;
                        Int16 * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int16 * pInArr1 = inArray1.m_data)
                    fixed ( Int16 * pInArr2 = inArray2.m_data)
                    fixed ( Int16 * pOutArr = retSystemArr) {
                        Int16 * poutarr = pOutArr;
                        Int16 * poutend = poutarr + newLength;
                        Int16 * pIn1 = pInArr1;
                        Int16 * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<Int16> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<float> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<float>  FloatOperatorFloatFloat ( ILArray<float> inArray1, ILArray<float> inArray2,
            ILFloatFunctionFloatFloat operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            float [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  float [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( float * pOutArr = retSystemArr)
                    fixed ( float * inA1 = inArray1.m_data) 
                    fixed ( float * inA2 = inArray2.m_data) {
                        float * pInA1 = inA1; 
                        float * pInA2 = inA2;
                        int c = 0; 
                        float * poutarr = pOutArr;
                        float * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( float * pInArr1 = inArray1.m_data)
                    fixed ( float * pInArr2 = inArray2.m_data)
                    fixed ( float * pOutArr = retSystemArr) {
                        float * poutarr = pOutArr;
                        float * poutend = poutarr + newLength;
                        float * pIn1 = pInArr1;
                        float * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<fcomplex> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<fcomplex>  FcomplexOperatorFcomplexFcomplex ( ILArray<fcomplex> inArray1, ILArray<fcomplex> inArray2,
            ILFcomplexFunctionFcomplexFcomplex operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            fcomplex [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  fcomplex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( fcomplex * pOutArr = retSystemArr)
                    fixed ( fcomplex * inA1 = inArray1.m_data) 
                    fixed ( fcomplex * inA2 = inArray2.m_data) {
                        fcomplex * pInA1 = inA1; 
                        fcomplex * pInA2 = inA2;
                        int c = 0; 
                        fcomplex * poutarr = pOutArr;
                        fcomplex * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( fcomplex * pInArr1 = inArray1.m_data)
                    fixed ( fcomplex * pInArr2 = inArray2.m_data)
                    fixed ( fcomplex * pOutArr = retSystemArr) {
                        fcomplex * poutarr = pOutArr;
                        fcomplex * poutend = poutarr + newLength;
                        fcomplex * pIn1 = pInArr1;
                        fcomplex * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<complex> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<complex>  ComplexOperatorComplexComplex ( ILArray<complex> inArray1, ILArray<complex> inArray2,
            ILComplexFunctionComplexComplex operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            complex [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  complex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( complex * pOutArr = retSystemArr)
                    fixed ( complex * inA1 = inArray1.m_data) 
                    fixed ( complex * inA2 = inArray2.m_data) {
                        complex * pInA1 = inA1; 
                        complex * pInA2 = inA2;
                        int c = 0; 
                        complex * poutarr = pOutArr;
                        complex * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( complex * pInArr1 = inArray1.m_data)
                    fixed ( complex * pInArr2 = inArray2.m_data)
                    fixed ( complex * pOutArr = retSystemArr) {
                        complex * poutarr = pOutArr;
                        complex * poutend = poutarr + newLength;
                        complex * pIn1 = pInArr1;
                        complex * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<complex> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<char> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<char>  CharOperatorCharChar ( ILArray<char> inArray1, ILArray<char> inArray2,
            ILCharFunctionCharChar operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            char [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  char [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( char * pOutArr = retSystemArr)
                    fixed ( char * inA1 = inArray1.m_data) 
                    fixed ( char * inA2 = inArray2.m_data) {
                        char * pInA1 = inA1; 
                        char * pInA2 = inA2;
                        int c = 0; 
                        char * poutarr = pOutArr;
                        char * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( char * pInArr1 = inArray1.m_data)
                    fixed ( char * pInArr2 = inArray2.m_data)
                    fixed ( char * pOutArr = retSystemArr) {
                        char * poutarr = pOutArr;
                        char * poutend = poutarr + newLength;
                        char * pIn1 = pInArr1;
                        char * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<char> ( retSystemArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns><![CDATA[  ILArray<byte> ]]> with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray1 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static  ILArray<byte>  ByteOperatorByteByte ( ILArray<byte> inArray1, ILArray<byte> inArray2,
            ILByteFunctionByteByte operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize ( inArray2.Dimensions ))
                throw new ILDimensionMismatchException ();
            byte [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new  byte [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                unsafe {
                    fixed ( byte * pOutArr = retSystemArr)
                    fixed ( byte * inA1 = inArray1.m_data) 
                    fixed ( byte * inA2 = inArray2.m_data) {
                        byte * pInA1 = inA1; 
                        byte * pInA2 = inA2;
                        int c = 0; 
                        byte * poutarr = pOutArr;
                        byte * outEnd = poutarr + newLength;
                        if (inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c++)), *pInA2++);
                            }
                        else if (!inArray1.IsReference && inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *(pInA2 + inArray2.getBaseIndex(c++)));
                            }
                        else if (!inArray1.IsReference && !inArray2.IsReference)
                            while (poutarr < outEnd) {
                                *poutarr++ = operation ( *pInA1++, *pInA2++);
                            }
                        else if (inArray1.IsReference && inArray2.IsReference)
                            if (inArray1.Dimensions.NumberOfDimensions < 3 && inArray2.Dimensions.NumberOfDimensions < 3) {
                                fixed (int * pA1idx0 = inArray1.m_indexOffset[0])
                                fixed (int * pA1idx1 = inArray1.m_indexOffset[1])
                                fixed (int * pA2idx0 = inArray2.m_indexOffset[0])
                                fixed (int * pA2idx1 = inArray2.m_indexOffset[1]) {
                                    int r = 0, rLen = inArray1.m_dimensions[0];
                                    int        cLen = inArray1.m_dimensions[1]; 
                                    while (poutarr < outEnd) {
                                        *poutarr++ = operation ( *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)), *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)));
                                        if (++r == rLen) {
                                            r = 0; 
                                            c++; 
                                        }
                                    }
                                }
                            } else {
                                 while (poutarr < outEnd) {
                                    *poutarr++ = operation ( *(pInA1 + inArray1.getBaseIndex(c)), *(pInA2+inArray2.getBaseIndex(c++)));
                                }
                           }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( byte * pInArr1 = inArray1.m_data)
                    fixed ( byte * pInArr2 = inArray2.m_data)
                    fixed ( byte * pOutArr = retSystemArr) {
                        byte * poutarr = pOutArr;
                        byte * poutend = poutarr + newLength;
                        byte * pIn1 = pInArr1;
                        byte * pIn2 = pInArr2;
                        while (poutarr < poutend)
                            *poutarr++ = operation ( *pIn1++, *pIn2++ );

                    }
                }
                #endregion
            }
            return new  ILArray<byte> ( retSystemArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART WALKER_UNARY
        /*!HC:TYPELIST:
<hycalper>
    <type>
        <source	locate="after">
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
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>double</destination>
        <destination>float</destination>
    </type>
    <type>
        <source	locate="after">
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
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outCls1
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
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outArr1
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
        <destination>double</destination>
        <destination>float</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source	locate="after">
            delegate_unary
        </source>
        <destination>ILByteFunctionByte</destination>
        <destination>ILCharFunctionChar</destination>
        <destination>ILComplexFunctionComplex</destination>
        <destination>ILFcomplexFunctionFcomplex</destination>
        <destination>ILFloatFunctionFloat</destination>
        <destination>ILInt16FunctionInt16</destination>
        <destination>ILInt32FunctionInt32</destination>
        <destination>ILInt64FunctionInt64</destination>
        <destination>ILUInt16FunctionUInt16</destination>
        <destination>ILUInt32FunctionUInt32</destination>
        <destination>ILUInt64FunctionUInt64</destination>
        <destination>ILDoubleFunctionComplex</destination>
        <destination>ILFloatFunctionFcomplex</destination>
        <destination>ILComplexFunctionDouble</destination>
        <destination>ILFcomplexFunctionFloat</destination>
    </type>
    <type>
        <source	locate="after">
            unaryop
        </source>
        <destination>ByteOperatorByte</destination>
        <destination>CharOperatorChar</destination>
        <destination>ComplexOperatorComplex</destination>
        <destination>FcomplexOperatorFcomplex</destination>
        <destination>FloatOperatorFloat</destination>
        <destination>Int16OperatorInt16</destination>
        <destination>Int32OperatorInt32</destination>
        <destination>Int64OperatorInt64</destination>
        <destination>UInt16OperatorUInt16</destination>
        <destination>UInt32OperatorUInt32</destination>
        <destination>UInt64OperatorUInt64</destination>
        <destination>DoubleOperatorComplex</destination>
        <destination>FloatOperatorFcomplex</destination>
        <destination>ComplexOperatorDouble</destination>
        <destination>FcomplexOperatorFloat</destination>
    </type>
</hycalper>
*/
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[ /*!HC:outCls1*/ ILArray<double> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static /*!HC:outCls1*/ ILArray<double> /*!HC:unaryop*/ DoubleOperatorDouble (/*!HC:inCls1*/ ILArray<double> inArray,
            /*!HC:delegate_unary*/ ILDoubleFunctionDouble operation) {
            ILDimension inDim = inArray.Dimensions;
            /*!HC:outArr1*/ double [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new /*!HC:outArr1*/ double [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                            fixed (/*!HC:inArr1*/ double * pInArr = inArray.m_data) {
                                /*!HC:outArr1*/ double * tmpOut = pOutArr;
                                /*!HC:inArr1*/ double * tmpIn = pInArr;
                                /*!HC:outArr1*/ double * tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                            fixed (/*!HC:inArr1*/ double * pInArr = inArray.m_data) {
                                /*!HC:outArr1*/ double * tmpOut = pOutArr;
                                /*!HC:outArr1*/ double * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                /*!HC:inArr1*/ double * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                    fixed (/*!HC:inArr1*/ double * pInArr = inArray.m_data) {
                        /*!HC:outArr1*/ double * lastElement = pOutArr + retDblArr.Length;
                        /*!HC:outArr1*/ double * tmpOut = pOutArr;
                        /*!HC:inArr1*/ double * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new /*!HC:outCls1*/ ILArray<double> ( retDblArr, inDim.ToIntArray () );
        }
        #endregion HYCALPER LOOPEND WALKER_UNARY
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<fcomplex> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<fcomplex>  FcomplexOperatorFloat ( ILArray<float> inArray,
            ILFcomplexFunctionFloat operation) {
            ILDimension inDim = inArray.Dimensions;
            fcomplex [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  fcomplex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( float * pInArr = inArray.m_data) {
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
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( float * pInArr = inArray.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                float * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( fcomplex * pOutArr = retDblArr)
                    fixed ( float * pInArr = inArray.m_data) {
                        fcomplex * lastElement = pOutArr + retDblArr.Length;
                        fcomplex * tmpOut = pOutArr;
                        float * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<complex> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<complex>  ComplexOperatorDouble ( ILArray<double> inArray,
            ILComplexFunctionDouble operation) {
            ILDimension inDim = inArray.Dimensions;
            complex [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  complex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( double * pInArr = inArray.m_data) {
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
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( double * pInArr = inArray.m_data) {
                                complex * tmpOut = pOutArr;
                                complex * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                double * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( complex * pOutArr = retDblArr)
                    fixed ( double * pInArr = inArray.m_data) {
                        complex * lastElement = pOutArr + retDblArr.Length;
                        complex * tmpOut = pOutArr;
                        double * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<float> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<float>  FloatOperatorFcomplex ( ILArray<fcomplex> inArray,
            ILFloatFunctionFcomplex operation) {
            ILDimension inDim = inArray.Dimensions;
            float [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  float [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = inArray.m_data) {
                                float * tmpOut = pOutArr;
                                fcomplex * tmpIn = pInArr;
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = inArray.m_data) {
                                float * tmpOut = pOutArr;
                                float * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                fcomplex * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( float * pOutArr = retDblArr)
                    fixed ( fcomplex * pInArr = inArray.m_data) {
                        float * lastElement = pOutArr + retDblArr.Length;
                        float * tmpOut = pOutArr;
                        fcomplex * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<double> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<double>  DoubleOperatorComplex ( ILArray<complex> inArray,
            ILDoubleFunctionComplex operation) {
            ILDimension inDim = inArray.Dimensions;
            double [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  double [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( double * pOutArr = retDblArr)
                            fixed ( complex * pInArr = inArray.m_data) {
                                double * tmpOut = pOutArr;
                                complex * tmpIn = pInArr;
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( double * pOutArr = retDblArr)
                            fixed ( complex * pInArr = inArray.m_data) {
                                double * tmpOut = pOutArr;
                                double * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                complex * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( double * pOutArr = retDblArr)
                    fixed ( complex * pInArr = inArray.m_data) {
                        double * lastElement = pOutArr + retDblArr.Length;
                        double * tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<double> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<UInt64> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<UInt64>  UInt64OperatorUInt64 ( ILArray<UInt64> inArray,
            ILUInt64FunctionUInt64 operation) {
            ILDimension inDim = inArray.Dimensions;
            UInt64 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  UInt64 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( UInt64 * pOutArr = retDblArr)
                            fixed ( UInt64 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( UInt64 * pOutArr = retDblArr)
                            fixed ( UInt64 * pInArr = inArray.m_data) {
                                UInt64 * tmpOut = pOutArr;
                                UInt64 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                UInt64 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt64 * pOutArr = retDblArr)
                    fixed ( UInt64 * pInArr = inArray.m_data) {
                        UInt64 * lastElement = pOutArr + retDblArr.Length;
                        UInt64 * tmpOut = pOutArr;
                        UInt64 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<UInt64> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<UInt32> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<UInt32>  UInt32OperatorUInt32 ( ILArray<UInt32> inArray,
            ILUInt32FunctionUInt32 operation) {
            ILDimension inDim = inArray.Dimensions;
            UInt32 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  UInt32 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( UInt32 * pOutArr = retDblArr)
                            fixed ( UInt32 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( UInt32 * pOutArr = retDblArr)
                            fixed ( UInt32 * pInArr = inArray.m_data) {
                                UInt32 * tmpOut = pOutArr;
                                UInt32 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                UInt32 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt32 * pOutArr = retDblArr)
                    fixed ( UInt32 * pInArr = inArray.m_data) {
                        UInt32 * lastElement = pOutArr + retDblArr.Length;
                        UInt32 * tmpOut = pOutArr;
                        UInt32 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<UInt32> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<UInt16> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<UInt16>  UInt16OperatorUInt16 ( ILArray<UInt16> inArray,
            ILUInt16FunctionUInt16 operation) {
            ILDimension inDim = inArray.Dimensions;
            UInt16 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  UInt16 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( UInt16 * pOutArr = retDblArr)
                            fixed ( UInt16 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( UInt16 * pOutArr = retDblArr)
                            fixed ( UInt16 * pInArr = inArray.m_data) {
                                UInt16 * tmpOut = pOutArr;
                                UInt16 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                UInt16 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( UInt16 * pOutArr = retDblArr)
                    fixed ( UInt16 * pInArr = inArray.m_data) {
                        UInt16 * lastElement = pOutArr + retDblArr.Length;
                        UInt16 * tmpOut = pOutArr;
                        UInt16 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<UInt16> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<Int64> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<Int64>  Int64OperatorInt64 ( ILArray<Int64> inArray,
            ILInt64FunctionInt64 operation) {
            ILDimension inDim = inArray.Dimensions;
            Int64 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  Int64 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int64 * pOutArr = retDblArr)
                            fixed ( Int64 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int64 * pOutArr = retDblArr)
                            fixed ( Int64 * pInArr = inArray.m_data) {
                                Int64 * tmpOut = pOutArr;
                                Int64 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                Int64 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int64 * pOutArr = retDblArr)
                    fixed ( Int64 * pInArr = inArray.m_data) {
                        Int64 * lastElement = pOutArr + retDblArr.Length;
                        Int64 * tmpOut = pOutArr;
                        Int64 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<Int64> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<Int32> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<Int32>  Int32OperatorInt32 ( ILArray<Int32> inArray,
            ILInt32FunctionInt32 operation) {
            ILDimension inDim = inArray.Dimensions;
            Int32 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  Int32 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int32 * pOutArr = retDblArr)
                            fixed ( Int32 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int32 * pOutArr = retDblArr)
                            fixed ( Int32 * pInArr = inArray.m_data) {
                                Int32 * tmpOut = pOutArr;
                                Int32 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                Int32 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int32 * pOutArr = retDblArr)
                    fixed ( Int32 * pInArr = inArray.m_data) {
                        Int32 * lastElement = pOutArr + retDblArr.Length;
                        Int32 * tmpOut = pOutArr;
                        Int32 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<Int32> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<Int16> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<Int16>  Int16OperatorInt16 ( ILArray<Int16> inArray,
            ILInt16FunctionInt16 operation) {
            ILDimension inDim = inArray.Dimensions;
            Int16 [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  Int16 [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( Int16 * pOutArr = retDblArr)
                            fixed ( Int16 * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( Int16 * pOutArr = retDblArr)
                            fixed ( Int16 * pInArr = inArray.m_data) {
                                Int16 * tmpOut = pOutArr;
                                Int16 * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                Int16 * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( Int16 * pOutArr = retDblArr)
                    fixed ( Int16 * pInArr = inArray.m_data) {
                        Int16 * lastElement = pOutArr + retDblArr.Length;
                        Int16 * tmpOut = pOutArr;
                        Int16 * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<Int16> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<float> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<float>  FloatOperatorFloat ( ILArray<float> inArray,
            ILFloatFunctionFloat operation) {
            ILDimension inDim = inArray.Dimensions;
            float [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  float [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( float * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( float * pOutArr = retDblArr)
                            fixed ( float * pInArr = inArray.m_data) {
                                float * tmpOut = pOutArr;
                                float * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                float * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( float * pOutArr = retDblArr)
                    fixed ( float * pInArr = inArray.m_data) {
                        float * lastElement = pOutArr + retDblArr.Length;
                        float * tmpOut = pOutArr;
                        float * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<float> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<fcomplex> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<fcomplex>  FcomplexOperatorFcomplex ( ILArray<fcomplex> inArray,
            ILFcomplexFunctionFcomplex operation) {
            ILDimension inDim = inArray.Dimensions;
            fcomplex [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  fcomplex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( fcomplex * pOutArr = retDblArr)
                            fixed ( fcomplex * pInArr = inArray.m_data) {
                                fcomplex * tmpOut = pOutArr;
                                fcomplex * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                fcomplex * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( fcomplex * pOutArr = retDblArr)
                    fixed ( fcomplex * pInArr = inArray.m_data) {
                        fcomplex * lastElement = pOutArr + retDblArr.Length;
                        fcomplex * tmpOut = pOutArr;
                        fcomplex * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<fcomplex> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<complex> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<complex>  ComplexOperatorComplex ( ILArray<complex> inArray,
            ILComplexFunctionComplex operation) {
            ILDimension inDim = inArray.Dimensions;
            complex [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  complex [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( complex * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( complex * pOutArr = retDblArr)
                            fixed ( complex * pInArr = inArray.m_data) {
                                complex * tmpOut = pOutArr;
                                complex * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                complex * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( complex * pOutArr = retDblArr)
                    fixed ( complex * pInArr = inArray.m_data) {
                        complex * lastElement = pOutArr + retDblArr.Length;
                        complex * tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<char> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<char>  CharOperatorChar ( ILArray<char> inArray,
            ILCharFunctionChar operation) {
            ILDimension inDim = inArray.Dimensions;
            char [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  char [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( char * pOutArr = retDblArr)
                            fixed ( char * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( char * pOutArr = retDblArr)
                            fixed ( char * pInArr = inArray.m_data) {
                                char * tmpOut = pOutArr;
                                char * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                char * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( char * pOutArr = retDblArr)
                    fixed ( char * pInArr = inArray.m_data) {
                        char * lastElement = pOutArr + retDblArr.Length;
                        char * tmpOut = pOutArr;
                        char * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<char> ( retDblArr, inDim.ToIntArray () );
        }
       
        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[  ILArray<byte> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<byte>  ByteOperatorByte ( ILArray<byte> inArray,
            ILByteFunctionByte operation) {
            ILDimension inDim = inArray.Dimensions;
            byte [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  byte [newLength];
            int leadDim = 0;
            int leadDimLen = inDim [0];
            if (inArray.IsReference) {
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim [i]) {
                        leadDimLen = inDim [i];
                        leadDim = i;
                    }
                }
                ILIndexOffset idxOffset = inArray.m_indexOffset;
                int incOut = inDim.SequentialIndexDistance ( leadDim );
                // ========================  REFERENCE double Storage ===========
                System.Diagnostics.Debug.Assert(!inArray.IsVector,"Reference arrays of vector size should not exist!"); 
                if (inArray.IsMatrix) {
                    #region Matrix
                    ////////////////////////////   MATRIX   ////////////////////
                    int secDim = ( leadDim + 1 ) % 2;
                    unsafe {
                        fixed (int* leadDimStart = idxOffset [leadDim],
                                secDimStart = idxOffset [secDim]) {
                            fixed ( byte * pOutArr = retDblArr)
                            fixed ( byte * pInArr = inArray.m_data) {
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
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
                                        tmpOut += incOut;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                } else {
                    /////////////////////////////   ARBITRARY DIMENSIONS //////////
                    #region arbitrary size
                    unsafe {
                        int [] curPosition = new int [inArray.Dimensions.NumberOfDimensions];
                        fixed (int* leadDimStart = idxOffset [leadDim]) {
                            fixed ( byte * pOutArr = retDblArr)
                            fixed ( byte * pInArr = inArray.m_data) {
                                byte * tmpOut = pOutArr;
                                byte * tmpOutEnd = tmpOut + retDblArr.Length;
                                // init lesezeiger: add alle Dimensionen mit 0 (auer leadDim)
                                byte * tmpIn = pInArr + inArray.getBaseIndex ( 0, 0 );
                                tmpIn -= idxOffset [leadDim, 0];
                                int* leadDimIdx = leadDimStart;
                                int* leadDimEnd = leadDimStart + leadDimLen;
                                int dimLen = curPosition.Length;
                                int d, curD;
                                // start at first element
                                while (tmpOut < tmpOutEnd) {
                                    leadDimIdx = leadDimStart;
                                    while (leadDimIdx < leadDimEnd) {
                                        *tmpOut = operation ( *( tmpIn + *leadDimIdx++ ) );
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
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed ( byte * pOutArr = retDblArr)
                    fixed ( byte * pInArr = inArray.m_data) {
                        byte * lastElement = pOutArr + retDblArr.Length;
                        byte * tmpOut = pOutArr;
                        byte * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
                #endregion
            }
            return new  ILArray<byte> ( retDblArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
