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
        <destination>complex</destination>
    </type>
    <type>
        <source	locate="after">
            inArr2
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source	locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source	locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outArr1
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source	locate="after">
            delegate_binary
        </source>
        <destination>ILByteFunctionByteByte</destination>
        <destination>ILComplexFunctionComplexComplex</destination>
    </type>
    <type>
        <source	locate="after">
            hcfunctionName
        </source>
        <destination>ByteOperatorByteByte</destination>
        <destination>ComplexOperatorComplexComplex</destination>
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
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
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
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
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

            return new  ILArray<complex> ( retSystemArr, inDim.ToIntArray () );
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
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
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
        <destination>complex</destination>
        <destination>complex</destination>
        <destination>double</destination>
    </type>
    <type>
        <source	locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source	locate="after">
            outArr1
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
        <destination>double</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source	locate="after">
            delegate_unary
        </source>
        <destination>ILByteFunctionByte</destination>
        <destination>ILComplexFunctionComplex</destination>
        <destination>ILDoubleFunctionComplex</destination>
        <destination>ILComplexFunctionDouble</destination>
    </type>
    <type>
        <source	locate="after">
            unaryop
        </source>
        <destination>ByteOperatorByte</destination>
        <destination>ComplexOperatorComplex</destination>
        <destination>DoubleOperatorComplex</destination>
        <destination>ComplexOperatorDouble</destination>
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
            int leadDimLen = inDim [0];

            unsafe
            {
                fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                fixed (/*!HC:inArr1*/ double * pInArr = inArray.m_data) {
                    /*!HC:outArr1*/ double * lastElement = pOutArr + retDblArr.Length;
                    /*!HC:outArr1*/ double * tmpOut = pOutArr;
                    /*!HC:inArr1*/ double * tmpIn = pInArr;
                    while (tmpOut < lastElement)
                        *tmpOut++ = operation ( *tmpIn++ );
                }
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
        /// <returns>new <![CDATA[  ILArray<complex> ]]> with result of operation</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static  ILArray<complex>  ComplexOperatorDouble ( ILArray<double> inArray,
            ILComplexFunctionDouble operation) {
            ILDimension inDim = inArray.Dimensions;
            complex [] retDblArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retDblArr = new  complex [newLength];
            int leadDimLen = inDim [0];

            unsafe
            {
                fixed ( complex * pOutArr = retDblArr)
                fixed ( double * pInArr = inArray.m_data) {
                    complex * lastElement = pOutArr + retDblArr.Length;
                    complex * tmpOut = pOutArr;
                    double * tmpIn = pInArr;
                    while (tmpOut < lastElement)
                        *tmpOut++ = operation ( *tmpIn++ );
                }
            }

            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
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
            int leadDimLen = inDim [0];

            unsafe
            {
                fixed ( double * pOutArr = retDblArr)
                fixed ( complex * pInArr = inArray.m_data) {
                    double * lastElement = pOutArr + retDblArr.Length;
                    double * tmpOut = pOutArr;
                    complex * tmpIn = pInArr;
                    while (tmpOut < lastElement)
                        *tmpOut++ = operation ( *tmpIn++ );
                }
            }

            return new  ILArray<double> ( retDblArr, inDim.ToIntArray () );
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
            int leadDimLen = inDim [0];

            unsafe
            {
                fixed ( complex * pOutArr = retDblArr)
                fixed ( complex * pInArr = inArray.m_data) {
                    complex * lastElement = pOutArr + retDblArr.Length;
                    complex * tmpOut = pOutArr;
                    complex * tmpIn = pInArr;
                    while (tmpOut < lastElement)
                        *tmpOut++ = operation ( *tmpIn++ );
                }
            }

            return new  ILArray<complex> ( retDblArr, inDim.ToIntArray () );
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
            int leadDimLen = inDim [0];

            unsafe
            {
                fixed ( byte * pOutArr = retDblArr)
                fixed ( byte * pInArr = inArray.m_data) {
                    byte * lastElement = pOutArr + retDblArr.Length;
                    byte * tmpOut = pOutArr;
                    byte * tmpIn = pInArr;
                    while (tmpOut < lastElement)
                        *tmpOut++ = operation ( *tmpIn++ );
                }
            }

            return new  ILArray<byte> ( retDblArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
