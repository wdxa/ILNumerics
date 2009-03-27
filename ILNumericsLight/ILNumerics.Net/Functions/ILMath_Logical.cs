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
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
</type>
<type>
    <source locate="after">
        inCls2
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        ClsName 
    </source>
    <destination>oplogical_bytebyte</destination>
    <destination>oplogical_complexcomplex</destination>
</type>
<type>
    <source locate="after">
        TclsRelopUnary 
    </source>
    <destination>oplogical__byte</destination>
    <destination>oplogical__complex</destination>
</type>
<type>
    <source locate="after">
        delegate_logicalbinary
    </source>
    <destination>ILLogicalFunctionByteByte</destination>
    <destination>ILLogicalFunctionComplexComplex</destination>
</type>
<type>
    <source locate="after">
        delegate_logicalunary
    </source>
    <destination>ILLogicalFunctionByte</destination>
    <destination>ILLogicalFunctionComplex</destination>
</type>
<type>
    <source locate="after">
        logicalbinaryop
    </source>
    <destination>LogicalBinaryByteOperator</destination>
    <destination>LogicalBinaryComplexOperator</destination>
</type>
<type>
    <source locate="after">
        logicalunaryop
    </source>
    <destination>LogicalUnaryByteOperator</destination>
    <destination>LogicalUnaryComplexOperator</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

	public partial class ILMath {

        #region HYCALPER LOOPSTART INNER_FUNCTION_DELEGATES
        private delegate byte /*!HC:delegate_logicalunary*/ ILLogicalFunctionDouble (/*!HC:inArr1*/ double in1);
        private delegate byte /*!HC:delegate_logicalbinary*/ ILLogicalFunctionDoubleDouble (/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2);
        #endregion HYCALPER LOOPEND INNER_FUNCTION_DELEGATES
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        private delegate byte  ILLogicalFunctionComplex ( complex in1);
        private delegate byte  ILLogicalFunctionComplexComplex ( complex in1, complex in2);
        private delegate byte  ILLogicalFunctionByte ( byte in1);
        private delegate byte  ILLogicalFunctionByteByte ( byte in1, byte in2);

#endregion HYCALPER AUTO GENERATED CODE

        // binary elementwise functions returning logical
        #region HYCALPER LOOPSTART LOGICAL_TYPE1,TYPE2
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        ClsName 
    </source>
    <destination>oplogical_bytebyte</destination>
    <destination>oplogical_complexcomplex</destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="nextline">
        EvalAND
    </source>
    <destination><![CDATA[return ((in1 != 0.0) && (in2 != 0.0)) ? (byte)1 : (byte)0;]]></destination>
    <destination><![CDATA[return ((in1.real != 0.0) && (in2.real != 0.0) && (in1.imag != 0.0) && (in2.imag != 0.0)) ? (byte)1 : (byte)0;]]></destination>
</type>
<type>
    <source locate="nextline">
        EvalOR
    </source>
    <destination><![CDATA[return ((in1 != 0.0) || (in2 != 0.0)) ? (byte)1 : (byte)0;]]></destination>
    <destination><![CDATA[return ((in1.real != 0.0) || (in2.real != 0.0) || (in1.imag != 0.0) || (in2.imag != 0.0)) ? (byte)1 : (byte)0;]]></destination>
</type>
</hycalper>
*/
        private class /*!HC:ClsName*/ oplogical_doubledouble {
            internal byte eq(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                // TODO Pruefen auf 0.0 (oder Gleichheit) kann gefaehrlich sein wegen maximaler 
                // double Praezision.
                // Man muss besser auf ein (am besten einstellbares) eps = ca. 1e-16 prfen!
                // Siehe auch matlabs eps
                // Der logische default Wert in C# ist wohl Double.Epsilon bzw. Single.Epsilon, je nach Typ...

                // TODO: a == b <-> abs(a-b) <= eps
                // Probalby computationally too demanding? Check what matlab does!
                return (in1 == in2) ? (byte)1 : (byte)0;
            }
            internal byte neq(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                // TODO: a != b <-> abs(a-b) > eps
                return (in1 != in2) ? (byte)1 : (byte)0;
            }
            internal byte lt(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                // TODO: a < b <-> b-a > eps
                return (in1 < in2) ? (byte)1 : (byte)0;
            }
            internal byte gt(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                // TODO: a > b <-> a-b > eps
                return (in1 > in2) ? (byte)1 : (byte)0;
            }
            internal byte le(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                return (in1 <= in2) ? (byte)1 : (byte)0;
            }
            internal byte ge(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                return (in1 >= in2) ? (byte)1 : (byte)0;
            }
            internal byte and(/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2) {
                /*!HC:EvalAND*/
                return ((in1 != 0.0) && (in2 != 0.0)) ? (byte)1 : (byte)0;
            }
            internal byte or(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                /*!HC:EvalOR*/
                return ((in1 != 0.0) || (in2 != 0.0)) ? (byte)1 : (byte)0;
            }
        }
        #endregion HYCALPER LOOPEND LOGICAL_TYPE1,TYPE2
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        private class  oplogical_complexcomplex {
            internal byte eq( complex in1, complex in2) {
                // TODO Pruefen auf 0.0 (oder Gleichheit) kann gefaehrlich sein wegen maximaler 
                // double Praezision.
                // Man muss besser auf ein (am besten einstellbares) eps = ca. 1e-16 prfen!
                // Siehe auch matlabs eps
                // Der logische default Wert in C# ist wohl Double.Epsilon bzw. Single.Epsilon, je nach Typ...

                // TODO: a == b <-> abs(a-b) <= eps
                // Probalby computationally too demanding? Check what matlab does!
                return (in1 == in2) ? (byte)1 : (byte)0;
            }
            internal byte neq( complex in1, complex in2) {
                // TODO: a != b <-> abs(a-b) > eps
                return (in1 != in2) ? (byte)1 : (byte)0;
            }
            internal byte lt( complex in1, complex in2) {
                // TODO: a < b <-> b-a > eps
                return (in1 < in2) ? (byte)1 : (byte)0;
            }
            internal byte gt( complex in1, complex in2) {
                // TODO: a > b <-> a-b > eps
                return (in1 > in2) ? (byte)1 : (byte)0;
            }
            internal byte le( complex in1, complex in2) {
                return (in1 <= in2) ? (byte)1 : (byte)0;
            }
            internal byte ge( complex in1, complex in2) {
                return (in1 >= in2) ? (byte)1 : (byte)0;
            }
            internal byte and( complex in1, complex in2) {
                return ((in1.real != 0.0) && (in2.real != 0.0) && (in1.imag != 0.0) && (in2.imag != 0.0)) ? (byte)1 : (byte)0;
            }
            internal byte or( complex in1,  complex in2) {
                return ((in1.real != 0.0) || (in2.real != 0.0) || (in1.imag != 0.0) || (in2.imag != 0.0)) ? (byte)1 : (byte)0;
            }
        }
       
        private class  oplogical_bytebyte {
            internal byte eq( byte in1, byte in2) {
                // TODO Pruefen auf 0.0 (oder Gleichheit) kann gefaehrlich sein wegen maximaler 
                // double Praezision.
                // Man muss besser auf ein (am besten einstellbares) eps = ca. 1e-16 prfen!
                // Siehe auch matlabs eps
                // Der logische default Wert in C# ist wohl Double.Epsilon bzw. Single.Epsilon, je nach Typ...

                // TODO: a == b <-> abs(a-b) <= eps
                // Probalby computationally too demanding? Check what matlab does!
                return (in1 == in2) ? (byte)1 : (byte)0;
            }
            internal byte neq( byte in1, byte in2) {
                // TODO: a != b <-> abs(a-b) > eps
                return (in1 != in2) ? (byte)1 : (byte)0;
            }
            internal byte lt( byte in1, byte in2) {
                // TODO: a < b <-> b-a > eps
                return (in1 < in2) ? (byte)1 : (byte)0;
            }
            internal byte gt( byte in1, byte in2) {
                // TODO: a > b <-> a-b > eps
                return (in1 > in2) ? (byte)1 : (byte)0;
            }
            internal byte le( byte in1, byte in2) {
                return (in1 <= in2) ? (byte)1 : (byte)0;
            }
            internal byte ge( byte in1, byte in2) {
                return (in1 >= in2) ? (byte)1 : (byte)0;
            }
            internal byte and( byte in1, byte in2) {
                return ((in1 != 0.0) && (in2 != 0.0)) ? (byte)1 : (byte)0;
            }
            internal byte or( byte in1,  byte in2) {
                return ((in1 != 0.0) || (in2 != 0.0)) ? (byte)1 : (byte)0;
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART LOGICAL_TYPE1
        private class /*!HC:TclsRelopUnary*/ oplogical_double {
            private /*!HC:inArr2*/ double m_parameter;
            /*!HC:delegate_logicalbinary*/ ILLogicalFunctionDoubleDouble m_applyFun;

            internal /*!HC:TclsRelopUnary*/ oplogical_double (/*!HC:inArr2*/ double parameter,
                     /*!HC:delegate_logicalbinary*/ ILLogicalFunctionDoubleDouble applyFunc) {
                m_parameter = parameter;
                m_applyFun = applyFunc;
            }
            internal byte operate(/*!HC:inArr1*/ double in1) {
                return m_applyFun(in1, m_parameter);
            }
            internal byte eq(/*!HC:inArr1*/ double in1) {
                return (in1 == m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte neq(/*!HC:inArr1*/ double in1) {
                return (in1 != m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte gt(/*!HC:inArr1*/ double in1) {
                return (in1 > m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte lt(/*!HC:inArr1*/ double in1) {
                return (in1 < m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte ge(/*!HC:inArr1*/ double in1) {
                return (in1 >= m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte le(/*!HC:inArr1*/ double in1) {
                return (in1 <= m_parameter) ? (byte)1 : (byte)0;
            }
        }
        #endregion HYCALPER LOOPEND LOGICAL_TYPE1
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        private class  oplogical__complex {
            private  complex m_parameter;
            ILLogicalFunctionComplexComplex m_applyFun;

            internal  oplogical__complex ( complex parameter,
                     ILLogicalFunctionComplexComplex applyFunc) {
                m_parameter = parameter;
                m_applyFun = applyFunc;
            }
            internal byte operate( complex in1) {
                return m_applyFun(in1, m_parameter);
            }
            internal byte eq( complex in1) {
                return (in1 == m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte neq( complex in1) {
                return (in1 != m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte gt( complex in1) {
                return (in1 > m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte lt( complex in1) {
                return (in1 < m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte ge( complex in1) {
                return (in1 >= m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte le( complex in1) {
                return (in1 <= m_parameter) ? (byte)1 : (byte)0;
            }
        }
        private class  oplogical__byte {
            private  byte m_parameter;
            ILLogicalFunctionByteByte m_applyFun;

            internal  oplogical__byte ( byte parameter,
                     ILLogicalFunctionByteByte applyFunc) {
                m_parameter = parameter;
                m_applyFun = applyFunc;
            }
            internal byte operate( byte in1) {
                return m_applyFun(in1, m_parameter);
            }
            internal byte eq( byte in1) {
                return (in1 == m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte neq( byte in1) {
                return (in1 != m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte gt( byte in1) {
                return (in1 > m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte lt( byte in1) {
                return (in1 < m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte ge( byte in1) {
                return (in1 >= m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte le( byte in1) {
                return (in1 <= m_parameter) ? (byte)1 : (byte)0;
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART OPERATORS
        private static ILLogicalArray /*!HC:logicalbinaryop*/ LogicalBinaryDoubleOperator (
            /*!HC:inCls1*/ ILArray<double> A,
            /*!HC:inCls2*/ ILArray<double> B,
            /*!HC:delegate_logicalbinary*/ ILLogicalFunctionDoubleDouble operation) {
            ILDimension inDim = A.m_dimensions;
            if (!inDim.IsSameSize ( B.m_dimensions ))
                throw new ILDimensionMismatchException ();
            byte [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new byte [newLength];
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe {
                fixed (/*!HC:inArr1*/ double * pInArr1 = A.m_data)
                fixed (/*!HC:inArr2*/ double * pInArr2 = B.m_data)
                fixed (byte* pOutArr = retSystemArr) {
                    byte* poutarr = pOutArr;
                    byte* poutend = poutarr + newLength;
                    /*!HC:inArr1*/ double * pIn1 = pInArr1;
                    /*!HC:inArr2*/ double * pIn2 = pInArr2;
                    while (poutarr < poutend)
                        *poutarr++ = operation ( *pIn1++, *pIn2++ );
                }
            }

            return new ILLogicalArray ( retSystemArr, inDim.ToIntArray () );
        }

        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to be apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[ILArray<>]]> with result</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static ILLogicalArray /*!HC:logicalunaryop*/ LogicalUnaryDoubleOperator (ILArray</*!HC:inArr1*/ double > inArray,
            /*!HC:delegate_logicalunary*/ ILLogicalFunctionDouble operation) {
            ILDimension inDim = inArray.Dimensions;
            byte [] retByteArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retByteArr = new byte [newLength];
            int leadDimLen = inDim [0];
            
            // physical -> pointer arithmetic
            unsafe {
                fixed (byte* pOutArr = retByteArr) {
                    fixed (/*!HC:inArr1*/ double * pInArr = inArray.m_data) {
                        byte* lastElement = pOutArr + retByteArr.Length;
                        byte* tmpOut = pOutArr;
                        /*!HC:inArr1*/ double * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
            }

            return new ILLogicalArray ( retByteArr, inDim.ToIntArray () );
        }
        #endregion HYCALPER LOOPEND OPERATORS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        private static ILLogicalArray  LogicalBinaryComplexOperator (
            ILArray<complex> A,
            ILArray<complex> B,
            ILLogicalFunctionComplexComplex operation) {
            ILDimension inDim = A.m_dimensions;
            if (!inDim.IsSameSize ( B.m_dimensions ))
                throw new ILDimensionMismatchException ();
            byte [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new byte [newLength];
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe {
                fixed ( complex * pInArr1 = A.m_data)
                fixed ( complex * pInArr2 = B.m_data)
                fixed (byte* pOutArr = retSystemArr) {
                    byte* poutarr = pOutArr;
                    byte* poutend = poutarr + newLength;
                    complex * pIn1 = pInArr1;
                    complex * pIn2 = pInArr2;
                    while (poutarr < poutend)
                        *poutarr++ = operation ( *pIn1++, *pIn2++ );
                }
            }

            return new ILLogicalArray ( retSystemArr, inDim.ToIntArray () );
        }

        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to be apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[ILArray<>]]> with result</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static ILLogicalArray  LogicalUnaryComplexOperator (ILArray< complex > inArray,
            ILLogicalFunctionComplex operation) {
            ILDimension inDim = inArray.Dimensions;
            byte [] retByteArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retByteArr = new byte [newLength];
            int leadDimLen = inDim [0];
            
            // physical -> pointer arithmetic
            unsafe {
                fixed (byte* pOutArr = retByteArr) {
                    fixed ( complex * pInArr = inArray.m_data) {
                        byte* lastElement = pOutArr + retByteArr.Length;
                        byte* tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
            }

            return new ILLogicalArray ( retByteArr, inDim.ToIntArray () );
        }
        private static ILLogicalArray  LogicalBinaryByteOperator (
            ILArray<byte> A,
            ILArray<byte> B,
            ILLogicalFunctionByteByte operation) {
            ILDimension inDim = A.m_dimensions;
            if (!inDim.IsSameSize ( B.m_dimensions ))
                throw new ILDimensionMismatchException ();
            byte [] retSystemArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retSystemArr = new byte [newLength];
            int leadDimLen = inDim [0];

            // physical -> pointer arithmetic
            unsafe {
                fixed ( byte * pInArr1 = A.m_data)
                fixed ( byte * pInArr2 = B.m_data)
                fixed (byte* pOutArr = retSystemArr) {
                    byte* poutarr = pOutArr;
                    byte* poutend = poutarr + newLength;
                    byte * pIn1 = pInArr1;
                    byte * pIn2 = pInArr2;
                    while (poutarr < poutend)
                        *poutarr++ = operation ( *pIn1++, *pIn2++ );
                }
            }

            return new ILLogicalArray ( retSystemArr, inDim.ToIntArray () );
        }

        /// <summary>
        /// Applys the function (delegate) given to all elements of the storage
        /// </summary>
        /// <param name="inArray">storage array to be apply the function to</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new <![CDATA[ILArray<>]]> with result</returns>
        /// <remarks> the values of inArray will not be altered.</remarks>
        private static ILLogicalArray  LogicalUnaryByteOperator (ILArray< byte > inArray,
            ILLogicalFunctionByte operation) {
            ILDimension inDim = inArray.Dimensions;
            byte [] retByteArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retByteArr = new byte [newLength];
            int leadDimLen = inDim [0];
            
            // physical -> pointer arithmetic
            unsafe {
                fixed (byte* pOutArr = retByteArr) {
                    fixed ( byte * pInArr = inArray.m_data) {
                        byte* lastElement = pOutArr + retByteArr.Length;
                        byte* tmpOut = pOutArr;
                        byte * tmpIn = pInArr;
                        while (tmpOut < lastElement)
                            *tmpOut++ = operation ( *tmpIn++ );
                    }
                }
            }

            return new ILLogicalArray ( retByteArr, inDim.ToIntArray () );
        }

#endregion HYCALPER AUTO GENERATED CODE

 		        ////////////////////////////////  RELOP //////////////////////////////////
       #region Relational_(binary)_Operators
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs EQ
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>eq</destination>
        <destination>eq</destination>
        <destination>eq</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue == B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue == *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) == *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) == *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) == *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) == *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) == *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) == *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) == *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) == *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) == *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'equal' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for equal elements in A and B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for equal elements in A and B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for equal elements in A and B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND eq
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for equal elements in A and B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  eq ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for equal elements in A and B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  eq ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for equal elements in A and B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  eq ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) == B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue == *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ == *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
        
        /// <summary>
        /// Elementwise logical 'equal' operator
        /// </summary>
        /// <param name="A">input array 1</param>
        /// <param name="B">input array 2</param>
        /// <returns>Logical array having '1' for equal elements in A and B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if neither of A or B is scalar and the size of both arrays does not match</exception>
        public static ILLogicalArray eq (ILArray<String> A, ILArray<String> B) {
            if (object.Equals(A,null)) 
                throw new ILArgumentException("eq: input argurment A must not be null!");
            if (object.Equals(B,null)) 
                throw new ILArgumentException("eq: input argurment B must not be null!");
            if (!A.Dimensions.IsSameShape(B.Dimensions)) 
                throw new ILArgumentException("input arrays must have the same size"); 
            if (A.IsEmpty || B.IsEmpty)
                return ILLogicalArray.empty(A.Dimensions); 
            string scalarValue; 
            ILDimension retDim = null; 
            byte[] retArr = null; 
            if (A.IsScalar) {
                if (B.IsScalar) {
                    retDim = new ILDimension(1,1); 
                    return new ILLogicalArray(new byte[1]{(A.GetValue(0) == B.GetValue(0))?(byte)1:(byte)0},1,1); 
                } else {
                    retDim = B.Dimensions; 
                    int len = B.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    scalarValue = A.GetValue(0); 
                    for (int i = 0; i < len; i++) {
                        if (scalarValue == B.GetValue(i)) {
                            retArr[i] = 1; 
                        }
                    }
                }
            } else {
                retDim = A.Dimensions; 
                if (B.IsScalar) {
                    int len = A.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    scalarValue = B.GetValue(0); 
                    for (int i = 0; i < len; i++) {
                        if (scalarValue == A.GetValue(i))
                            retArr[i] = 1; 
                    }
                } else {
                    if (!A.Dimensions.IsSameSize(B.Dimensions))
                        throw new ILDimensionMismatchException("eq: size of arrays must match!");
                    int len = A.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    for (int i = 0; i < len; i++) {
                        if (A.GetValue(i) == B.GetValue(i))
                            retArr[i] = 1; 
                    }
                }
            }
            return new ILLogicalArray(retArr,retDim); 
        }
        /// <summary>
        /// Elementwise logical 'not equal' operator
        /// </summary>
        /// <param name="A">input array 1</param>
        /// <param name="B">input array 2</param>
        /// <returns>Logical array having '1' for elements in A not equal elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if neither of A or B is scalar and the size of both arrays does not match</exception>
        public static ILLogicalArray neq (ILArray<String> A, ILArray<String> B) {
            if (object.Equals(A,null)) 
                throw new ILArgumentException("neq: input argurment A must not be null!");
            if (object.Equals(B,null)) 
                throw new ILArgumentException("neq: input argurment B must not be null!");
            if (!A.Dimensions.IsSameShape(B.Dimensions)) 
                throw new ILArgumentException("input arrays must have the same size"); 
            if (A.IsEmpty || B.IsEmpty)
                return ILLogicalArray.empty(A.Dimensions); 
            ILLogicalArray ret = null; 
            string scalarValue; 
            ILDimension retDim = null; 
            byte[] retArr = null; 
            if (A.IsScalar) {
                if (B.IsScalar) {
                    retDim = new ILDimension(1,1); 
                    ret = new ILLogicalArray(new byte[1]{(A.GetValue(0) != B.GetValue(0))?(byte)1:(byte)0},1,1); 
                } else {
                    retDim = B.Dimensions; 
                    int len = B.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    scalarValue = A.GetValue(0); 
                    for (int i = 0; i < len; i++) {
                        if (scalarValue != B.GetValue(i)) {
                            retArr[i] = 1; 
                        }
                    }
                }
            } else {
                retDim = A.Dimensions; 
                if (B.IsScalar) {
                    int len = A.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    scalarValue = B.GetValue(0); 
                    for (int i = 0; i < len; i++) {
                        if (scalarValue != A.GetValue(i))
                            retArr[i] = 1; 
                    }
                } else {
                    if (!A.Dimensions.IsSameSize(B.Dimensions))
                        throw new ILDimensionMismatchException("neq: size of arrays must match!");
                    int len = A.Dimensions.NumberOfElements; 
                    retArr = new byte[len]; 
                    for (int i = 0; i < len; i++) {
                        if (A.GetValue(i) != B.GetValue(i))
                            retArr[i] = 1; 
                    }
                }
            }
            return new ILLogicalArray(retArr,retDim); 
        }

        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs NEQ
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>neq</destination>
        <destination>neq</destination>
        <destination>neq</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue != B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>                                       
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue != *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) != *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) != *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) != *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) != *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) != *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) != *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) != *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) != *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) != *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'not equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'not equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'not equal' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for elements in A not equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A not equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A not equal corresponding elements in B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND neq
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'not equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A not equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  neq ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'not equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A not equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  neq ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'not equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A not equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  neq ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) != B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue != *tmpIn++)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ != *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs LE
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>le</destination>
        <destination>le</destination>
        <destination>le</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue <= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue <= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue <= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue <= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue <= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue <= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>                                       
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) <= scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) <= *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) <= *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) <= *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) <= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) <= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) <= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) <= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) <= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) <= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'lower or equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'lower or equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'lower or equal' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND le
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'lower or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  le ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'lower or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  le ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'lower or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  le ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) <= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue <= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ <= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ <= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs GE
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>ge</destination>
        <destination>ge</destination>
        <destination>ge</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue >= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue >= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue >= B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue >= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue >= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue >= *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>                                       
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++)>= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++)>= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++)>= scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) >= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) >= scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) >= scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) >= *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) >= *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) >= *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) >= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) >= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) >= *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) >= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) >= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) >= *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'greater or equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'greater or equal' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'greater or equal' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND ge
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'greater or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  ge ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'greater or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  ge ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'greater or equal' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater or equal corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  ge ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) >= B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue >= *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ >= scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ >= *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
 
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs LT
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>lt</destination>
        <destination>lt</destination>
        <destination>lt</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue < B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue < B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue < B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue < *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue < *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue < *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>                                       
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) < scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) < *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) < *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) < *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) < *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) < *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) < *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) < *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) < *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) < *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <  *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <  *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ <  *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'lower than' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'lower than' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'lower than' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND lt
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'lower than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  lt ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'lower than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  lt ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'lower than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing lower than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  lt ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) < B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ < scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ < *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
        
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs GT
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
        <destination><![CDATA[ILLogicalArray]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>byte</destination>
        <destination>byte</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>gt</destination>
        <destination>gt</destination>
        <destination>gt</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});]]></destination>
        <destination><![CDATA[return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue > B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue > B.GetValue(0))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue > B.GetValue(0))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[*tmpOut = (scalarValue > *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue > *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (scalarValue > *(tmpIn + *leadDimIdx++))? (byte)1:(byte)0;]]></destination>
    </type>                                       
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*tmpOut = (*(tmpIn + *leadDimIdx++) > scalarValue)? (byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) > *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) > *pInA2++)? (byte)1:(byte)0; ]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c++)) > *pInA2++)? (byte)1:(byte)0; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) > *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) > *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)) > *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) > *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) > *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*(pInA1 + A.getBaseIndex(c)) > *(pInA2+B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *(pInA2 + B.getBaseIndex(c++)))?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;]]></destination>
        <destination><![CDATA[*poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;]]></destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination><![CDATA[Elementwise logical 'greater than' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'greater than' operator]]></destination>
        <destination><![CDATA[Elementwise logical 'greater than' operator]]></destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else]]></destination>
        <destination><![CDATA[Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND gt
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Elementwise logical 'greater than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  gt ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'greater than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  gt ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Elementwise logical 'greater than' operator</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Logical array having '1' for elements in A beeing greater than corresponding elements in B, '0' else</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILLogicalArray  gt ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILLogicalArray .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILLogicalArray .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILLogicalArray (new byte[1]{(A.GetValue(0) > B.GetValue(0))? (byte)1: (byte)0});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue > *tmpIn++)? (byte)1:(byte)0;}
                        }       
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (*tmpIn++ > scalarValue)? (byte)1:(byte)0;}
                            }
                        }
                    }

                    return new  ILLogicalArray ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                *poutarr++ = (*pInA1++ > *pInA2++)?(byte)1:(byte)0;
                            }
                        }
                    }

                    return new  ILLogicalArray ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART AND &  OR
        /// <summary>
        /// elementwise logical 'and' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'and'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar. If one of A or B is empty, 
        /// an empty array of the same inner element type is returned.</remarks>
        public static ILLogicalArray and(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls2*/ ILArray<double> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray();
            if (A.IsScalar) {
                if (A.GetValue(0) != 0) return B != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(B.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, B.Dimensions,0); 
            }
            if (B.IsScalar) {
                if (B.GetValue(0) != 0) return A != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(A.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, A.Dimensions,0);
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            /*!HC:ClsName*/ oplogical_doubledouble helper = new /*!HC:ClsName*/ oplogical_doubledouble ();
            return /*!HC:logicalbinaryop*/ LogicalBinaryDoubleOperator (A, B, helper.and);
        }
        /// <summary>
        /// elementwise logical 'or' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'or'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar.</remarks>
        public static ILLogicalArray or(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls2*/ ILArray<double> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray(); 
            if (A.IsScalar) {
                if (A.GetValue(0) == 0) return B != 0.0; 
                return tological(ones(B.Dimensions));  
            } else if (B.IsScalar) {
                if (B.GetValue(0) == 0) return A != 0.0; 
                return tological(ones(A.Dimensions));  
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            /*!HC:ClsName*/ oplogical_doubledouble helper = new /*!HC:ClsName*/ oplogical_doubledouble ();
            return /*!HC:logicalbinaryop*/ LogicalBinaryDoubleOperator (A, B, helper.or);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// elementwise logical 'and' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'and'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar. If one of A or B is empty, 
        /// an empty array of the same inner element type is returned.</remarks>
        public static ILLogicalArray and( ILArray<complex> A,  ILArray<complex> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray();
            if (A.IsScalar) {
                if (A.GetValue(0) != 0) return B != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(B.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, B.Dimensions,0); 
            }
            if (B.IsScalar) {
                if (B.GetValue(0) != 0) return A != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(A.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, A.Dimensions,0);
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            oplogical_complexcomplex helper = new  oplogical_complexcomplex ();
            return  LogicalBinaryComplexOperator (A, B, helper.and);
        }
        /// <summary>
        /// elementwise logical 'or' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'or'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar.</remarks>
        public static ILLogicalArray or( ILArray<complex> A,  ILArray<complex> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray(); 
            if (A.IsScalar) {
                if (A.GetValue(0) == 0) return B != 0.0; 
                return tological(ones(B.Dimensions));  
            } else if (B.IsScalar) {
                if (B.GetValue(0) == 0) return A != 0.0; 
                return tological(ones(A.Dimensions));  
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            oplogical_complexcomplex helper = new  oplogical_complexcomplex ();
            return  LogicalBinaryComplexOperator (A, B, helper.or);
        }
        /// <summary>
        /// elementwise logical 'and' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'and'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar. If one of A or B is empty, 
        /// an empty array of the same inner element type is returned.</remarks>
        public static ILLogicalArray and( ILArray<byte> A,  ILArray<byte> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray();
            if (A.IsScalar) {
                if (A.GetValue(0) != 0) return B != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(B.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, B.Dimensions,0); 
            }
            if (B.IsScalar) {
                if (B.GetValue(0) != 0) return A != 0.0; 
                byte[] ret = ILMemoryPool.Pool.New<byte>(A.Dimensions.NumberOfElements); 
                return new ILLogicalArray(ret, A.Dimensions,0);
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            oplogical_bytebyte helper = new  oplogical_bytebyte ();
            return  LogicalBinaryByteOperator (A, B, helper.and);
        }
        /// <summary>
        /// elementwise logical 'or' operator 
        /// </summary>
        /// <param name="A">input array A</param>
        /// <param name="B">input array B</param>
        /// <returns>logical array of same size as A and B, elements with result of logical 'or'.</returns>
        /// <remarks>A and B must have the same size or either one may be scalar.</remarks>
        public static ILLogicalArray or( ILArray<byte> A,  ILArray<byte> B) {
            if (A == null || B == null) 
                throw new ILArgumentException ("ILMath.and: A and B must be matrices and cannot be null!");
            if (A.IsEmpty || B.IsEmpty)
                return new ILLogicalArray(); 
            if (A.IsScalar) {
                if (A.GetValue(0) == 0) return B != 0.0; 
                return tological(ones(B.Dimensions));  
            } else if (B.IsScalar) {
                if (B.GetValue(0) == 0) return A != 0.0; 
                return tological(ones(A.Dimensions));  
            }
            if (!A.Dimensions.IsSameShape(B.Dimensions))
                throw new ILArgumentException("input arrays must have the same size");
            oplogical_bytebyte helper = new  oplogical_bytebyte ();
            return  LogicalBinaryByteOperator (A, B, helper.or);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #endregion Relational_(binary)_Operators

    }
}
