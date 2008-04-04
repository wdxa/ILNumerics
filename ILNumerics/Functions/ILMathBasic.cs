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
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
        inArrSkalar
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
    <source locate="after">
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
    <source locate="after">
        out1ArrCast
    </source>
    <destination>(byte)</destination>
    <destination>(char)</destination>
    <destination>(complex)</destination>
    <destination>(fcomplex)</destination>
    <destination>(float)</destination>
    <destination>(Int16)</destination>
    <destination>(Int32)</destination>
    <destination>(Int64)</destination>
    <destination>(UInt16)</destination>
    <destination>(UInt32)</destination>
    <destination>(UInt64)</destination>
</type>
<type>
    <source locate="after">
        cls2Name 
    </source>
    <destination>opbyte_bytebyte</destination>
    <destination>opchar_charchar</destination>
    <destination>opcomplex_complexcomplex</destination>
    <destination>opfcomplex_fcomplexfcomplex</destination>
    <destination>opfloat_floatfloat</destination>
    <destination>opint16_int16int16</destination>
    <destination>opint32_int32int32</destination>
    <destination>opint64_int64int64</destination>
    <destination>opuint16_uint16uint16</destination>
    <destination>opuint32_uint32uint32</destination>
    <destination>opuint64_uint64uint64</destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opchar_char</destination>
    <destination>opcomplex_complex</destination>
    <destination>opfcomplex_fcomplex</destination>
    <destination>opfloat_float</destination>
    <destination>opint16_int16</destination>
    <destination>opint32_int32</destination>
    <destination>opint64_int64</destination>
    <destination>opuint16_uint16</destination>
    <destination>opuint32_uint32</destination>
    <destination>opuint64_uint64</destination>
</type>
<type>
    <source locate="after">
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
    <source locate="after">
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
</type>
<type>
    <source locate="after">
        unaryop
    </source>
    <destination>ByteUnaryByteOperator</destination>
    <destination>CharUnaryCharOperator</destination>
    <destination>ComplexUnaryComplexOperator</destination>
    <destination>FcomplexUnaryFcomplexOperator</destination>
    <destination>FloatUnaryFloatOperator</destination>
    <destination>Int16UnaryInt16Operator</destination>
    <destination>Int32UnaryInt32Operator</destination>
    <destination>Int64UnaryInt64Operator</destination>
    <destination>UInt16UnaryUInt16Operator</destination>
    <destination>UInt32UnaryUInt32Operator</destination>
    <destination>UInt64UnaryUInt64Operator</destination>
</type>
<type>
    <source locate="after">
        TpositiveINF
    </source>
    <destination>127</destination>
    <destination>(char)127</destination>
    <destination>complex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>float.PositiveInfinity</destination>
    <destination>Int16.MaxValue</destination>
    <destination>Int32.MaxValue</destination>
    <destination>Int64.MaxValue</destination>
    <destination>UInt16.MaxValue</destination>
    <destination>UInt32.MaxValue</destination>
    <destination>UInt64.MaxValue</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

	public partial class ILMath {

        #region HYCALPER LOOPSTART INNERFUNCTION:DELEGATES_UNARY
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
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
</hycalper>
 */
        private delegate /*!HC:outArr1*/ double /*!HC:delegate_unary*/ ILDoubleFunctionDouble (/*!HC:inArr1*/ double in1);
        #endregion HYCALPER LOOPEND INNERFUNCTION:DELEGATES_UNARY
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        private delegate  fcomplex  ILFcomplexFunctionFloat ( float in1);
       
        private delegate  complex  ILComplexFunctionDouble ( double in1);
       
        private delegate  float  ILFloatFunctionFcomplex ( fcomplex in1);
       
        private delegate  double  ILDoubleFunctionComplex ( complex in1);
       
        private delegate  UInt64  ILUInt64FunctionUInt64 ( UInt64 in1);
       
        private delegate  UInt32  ILUInt32FunctionUInt32 ( UInt32 in1);
       
        private delegate  UInt16  ILUInt16FunctionUInt16 ( UInt16 in1);
       
        private delegate  Int64  ILInt64FunctionInt64 ( Int64 in1);
       
        private delegate  Int32  ILInt32FunctionInt32 ( Int32 in1);
       
        private delegate  Int16  ILInt16FunctionInt16 ( Int16 in1);
       
        private delegate  float  ILFloatFunctionFloat ( float in1);
       
        private delegate  fcomplex  ILFcomplexFunctionFcomplex ( fcomplex in1);
       
        private delegate  complex  ILComplexFunctionComplex ( complex in1);
       
        private delegate  char  ILCharFunctionChar ( char in1);
       
        private delegate  byte  ILByteFunctionByte ( byte in1);

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART INNERFUNCTION:DELEGATES_BINARY
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
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
    <destination>double</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
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
    <destination>double</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
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
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
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
    <destination>ILComplexFunctionDoubleDouble</destination>
    <destination>ILFcomplexFunctionFloatFloat</destination>
</type>
</hycalper>
 */
        private delegate /*!HC:outArr1*/ double /*!HC:delegate_binary*/ ILDoubleFunctionDoubleDouble (/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2);
        #endregion HYCALPER LOOPEND INNERFUNCTION:DELEGATES
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        private delegate  fcomplex  ILFcomplexFunctionFloatFloat ( float in1, float in2);
       
        private delegate  complex  ILComplexFunctionDoubleDouble ( double in1, double in2);
       
        private delegate  UInt64  ILUInt64FunctionUInt64UInt64 ( UInt64 in1, UInt64 in2);
       
        private delegate  UInt32  ILUInt32FunctionUInt32UInt32 ( UInt32 in1, UInt32 in2);
       
        private delegate  UInt16  ILUInt16FunctionUInt16UInt16 ( UInt16 in1, UInt16 in2);
       
        private delegate  Int64  ILInt64FunctionInt64Int64 ( Int64 in1, Int64 in2);
       
        private delegate  Int32  ILInt32FunctionInt32Int32 ( Int32 in1, Int32 in2);
       
        private delegate  Int16  ILInt16FunctionInt16Int16 ( Int16 in1, Int16 in2);
       
        private delegate  float  ILFloatFunctionFloatFloat ( float in1, float in2);
       
        private delegate  fcomplex  ILFcomplexFunctionFcomplexFcomplex ( fcomplex in1, fcomplex in2);
       
        private delegate  complex  ILComplexFunctionComplexComplex ( complex in1, complex in2);
       
        private delegate  char  ILCharFunctionCharChar ( char in1, char in2);
       
        private delegate  byte  ILByteFunctionByteByte ( byte in1, byte in2);

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART INNERFUNCTION:TYPE_TYPE1,TYPE2
        private class /*!HC:cls2Name*/ opdouble_doubledouble {
            internal /*!HC:outArr1*/ double add(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                // TODO: a + b = a if abs(b) < eps
                return /*!HC:out1ArrCast*/ (double) (in1 + in2); 
            }
            internal /*!HC:outArr1*/ double subtract(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                // TODO: a - b = a if abs(b) < eps
                return /*!HC:out1ArrCast*/ (double) (in1 - in2); 
            }
            internal /*!HC:outArr1*/ double multiply(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                return /*!HC:out1ArrCast*/ (double) (in1 * in2); 
            }
            internal /*!HC:outArr1*/ double divide(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                if (in2 != 0.0)
                    return /*!HC:out1ArrCast*/ (double) (in1 / in2);
                return /*!HC:TpositiveINF*/ double.PositiveInfinity ; 
            }
            internal /*!HC:outArr1*/ double min(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                return /*!HC:out1ArrCast*/ (double) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal /*!HC:outArr1*/ double max(/*!HC:inArr1*/ double in1, /*!HC:inArr2*/ double in2) {
                return /*!HC:out1ArrCast*/ (double) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        #endregion HYCALPER LOOPEND INNERFUNCTION:TYPE_TYPE1,TYPE2
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        private class  opuint64_uint64uint64 {
            internal  UInt64 add( UInt64 in1,  UInt64 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (UInt64) (in1 + in2); 
            }
            internal  UInt64 subtract( UInt64 in1,  UInt64 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (UInt64) (in1 - in2); 
            }
            internal  UInt64 multiply( UInt64 in1,  UInt64 in2) {
                return  (UInt64) (in1 * in2); 
            }
            internal  UInt64 divide( UInt64 in1,  UInt64 in2) {
                if (in2 != 0.0)
                    return  (UInt64) (in1 / in2);
                return  UInt64.MaxValue ; 
            }
            internal  UInt64 min( UInt64 in1,  UInt64 in2) {
                return  (UInt64) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  UInt64 max( UInt64 in1,  UInt64 in2) {
                return  (UInt64) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opuint32_uint32uint32 {
            internal  UInt32 add( UInt32 in1,  UInt32 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (UInt32) (in1 + in2); 
            }
            internal  UInt32 subtract( UInt32 in1,  UInt32 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (UInt32) (in1 - in2); 
            }
            internal  UInt32 multiply( UInt32 in1,  UInt32 in2) {
                return  (UInt32) (in1 * in2); 
            }
            internal  UInt32 divide( UInt32 in1,  UInt32 in2) {
                if (in2 != 0.0)
                    return  (UInt32) (in1 / in2);
                return  UInt32.MaxValue ; 
            }
            internal  UInt32 min( UInt32 in1,  UInt32 in2) {
                return  (UInt32) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  UInt32 max( UInt32 in1,  UInt32 in2) {
                return  (UInt32) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opuint16_uint16uint16 {
            internal  UInt16 add( UInt16 in1,  UInt16 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (UInt16) (in1 + in2); 
            }
            internal  UInt16 subtract( UInt16 in1,  UInt16 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (UInt16) (in1 - in2); 
            }
            internal  UInt16 multiply( UInt16 in1,  UInt16 in2) {
                return  (UInt16) (in1 * in2); 
            }
            internal  UInt16 divide( UInt16 in1,  UInt16 in2) {
                if (in2 != 0.0)
                    return  (UInt16) (in1 / in2);
                return  UInt16.MaxValue ; 
            }
            internal  UInt16 min( UInt16 in1,  UInt16 in2) {
                return  (UInt16) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  UInt16 max( UInt16 in1,  UInt16 in2) {
                return  (UInt16) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opint64_int64int64 {
            internal  Int64 add( Int64 in1,  Int64 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (Int64) (in1 + in2); 
            }
            internal  Int64 subtract( Int64 in1,  Int64 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (Int64) (in1 - in2); 
            }
            internal  Int64 multiply( Int64 in1,  Int64 in2) {
                return  (Int64) (in1 * in2); 
            }
            internal  Int64 divide( Int64 in1,  Int64 in2) {
                if (in2 != 0.0)
                    return  (Int64) (in1 / in2);
                return  Int64.MaxValue ; 
            }
            internal  Int64 min( Int64 in1,  Int64 in2) {
                return  (Int64) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  Int64 max( Int64 in1,  Int64 in2) {
                return  (Int64) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opint32_int32int32 {
            internal  Int32 add( Int32 in1,  Int32 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (Int32) (in1 + in2); 
            }
            internal  Int32 subtract( Int32 in1,  Int32 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (Int32) (in1 - in2); 
            }
            internal  Int32 multiply( Int32 in1,  Int32 in2) {
                return  (Int32) (in1 * in2); 
            }
            internal  Int32 divide( Int32 in1,  Int32 in2) {
                if (in2 != 0.0)
                    return  (Int32) (in1 / in2);
                return  Int32.MaxValue ; 
            }
            internal  Int32 min( Int32 in1,  Int32 in2) {
                return  (Int32) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  Int32 max( Int32 in1,  Int32 in2) {
                return  (Int32) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opint16_int16int16 {
            internal  Int16 add( Int16 in1,  Int16 in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (Int16) (in1 + in2); 
            }
            internal  Int16 subtract( Int16 in1,  Int16 in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (Int16) (in1 - in2); 
            }
            internal  Int16 multiply( Int16 in1,  Int16 in2) {
                return  (Int16) (in1 * in2); 
            }
            internal  Int16 divide( Int16 in1,  Int16 in2) {
                if (in2 != 0.0)
                    return  (Int16) (in1 / in2);
                return  Int16.MaxValue ; 
            }
            internal  Int16 min( Int16 in1,  Int16 in2) {
                return  (Int16) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  Int16 max( Int16 in1,  Int16 in2) {
                return  (Int16) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opfloat_floatfloat {
            internal  float add( float in1,  float in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (float) (in1 + in2); 
            }
            internal  float subtract( float in1,  float in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (float) (in1 - in2); 
            }
            internal  float multiply( float in1,  float in2) {
                return  (float) (in1 * in2); 
            }
            internal  float divide( float in1,  float in2) {
                if (in2 != 0.0)
                    return  (float) (in1 / in2);
                return  float.PositiveInfinity ; 
            }
            internal  float min( float in1,  float in2) {
                return  (float) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  float max( float in1,  float in2) {
                return  (float) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opfcomplex_fcomplexfcomplex {
            internal  fcomplex add( fcomplex in1,  fcomplex in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (fcomplex) (in1 + in2); 
            }
            internal  fcomplex subtract( fcomplex in1,  fcomplex in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (fcomplex) (in1 - in2); 
            }
            internal  fcomplex multiply( fcomplex in1,  fcomplex in2) {
                return  (fcomplex) (in1 * in2); 
            }
            internal  fcomplex divide( fcomplex in1,  fcomplex in2) {
                if (in2 != 0.0)
                    return  (fcomplex) (in1 / in2);
                return  fcomplex.INF ; 
            }
            internal  fcomplex min( fcomplex in1,  fcomplex in2) {
                return  (fcomplex) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  fcomplex max( fcomplex in1,  fcomplex in2) {
                return  (fcomplex) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opcomplex_complexcomplex {
            internal  complex add( complex in1,  complex in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (complex) (in1 + in2); 
            }
            internal  complex subtract( complex in1,  complex in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (complex) (in1 - in2); 
            }
            internal  complex multiply( complex in1,  complex in2) {
                return  (complex) (in1 * in2); 
            }
            internal  complex divide( complex in1,  complex in2) {
                if (in2 != 0.0)
                    return  (complex) (in1 / in2);
                return  complex.INF ; 
            }
            internal  complex min( complex in1,  complex in2) {
                return  (complex) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  complex max( complex in1,  complex in2) {
                return  (complex) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opchar_charchar {
            internal  char add( char in1,  char in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (char) (in1 + in2); 
            }
            internal  char subtract( char in1,  char in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (char) (in1 - in2); 
            }
            internal  char multiply( char in1,  char in2) {
                return  (char) (in1 * in2); 
            }
            internal  char divide( char in1,  char in2) {
                if (in2 != 0.0)
                    return  (char) (in1 / in2);
                return  (char)127 ; 
            }
            internal  char min( char in1,  char in2) {
                return  (char) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  char max( char in1,  char in2) {
                return  (char) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }
        private class  opbyte_bytebyte {
            internal  byte add( byte in1,  byte in2) {
                // TODO: a + b = a if abs(b) < eps
                return  (byte) (in1 + in2); 
            }
            internal  byte subtract( byte in1,  byte in2) {
                // TODO: a - b = a if abs(b) < eps
                return  (byte) (in1 - in2); 
            }
            internal  byte multiply( byte in1,  byte in2) {
                return  (byte) (in1 * in2); 
            }
            internal  byte divide( byte in1,  byte in2) {
                if (in2 != 0.0)
                    return  (byte) (in1 / in2);
                return  127 ; 
            }
            internal  byte min( byte in1,  byte in2) {
                return  (byte) ( ( in1 < in2 ) ? in1 : in2 );
            }
            internal  byte max( byte in1,  byte in2) {
                return  (byte) ( ( in1 > in2 ) ? in1 : in2 );
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART INNERFUNCTION:TYPE_TYPE1
        private class /*!HC:Tcls3Name*/ opdouble_double {
            private /*!HC:inArr2*/ double m_parameter;
            /*!HC:delegate_binary*/ ILDoubleFunctionDoubleDouble  m_applyFun;

            internal /*!HC:Tcls3Name*/ opdouble_double (/*!HC:inArr2*/ double parameter,
                     /*!HC:delegate_binary*/ ILDoubleFunctionDoubleDouble applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal /*!HC:outArr1*/ double operate(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) (m_applyFun(in1, m_parameter));
			}
            internal /*!HC:outArr1*/ double add(/*!HC:inArr1*/ double in1) {
				return /*!HC:out1ArrCast*/ (double) (in1 + m_parameter);
			}
            internal /*!HC:outArr1*/ double subtractL(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) (in1 - m_parameter);
            } 
            internal /*!HC:outArr1*/ double subtractR(/*!HC:inArr1*/ double in1) {
               return  /*!HC:out1ArrCast*/ (double) (m_parameter - in1);
            }
            internal /*!HC:outArr1*/ double divideL(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) (in1 / m_parameter);
            }
            internal /*!HC:outArr1*/ double divideR(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) (m_parameter / in1);
            }
            internal /*!HC:outArr1*/ double multiply(/*!HC:inArr1*/ double in1) {
				return /*!HC:out1ArrCast*/ (double) (in1 * m_parameter);
			}
            internal /*!HC:outArr1*/ double set(/*!HC:inArr1*/ double discard) {
				return /*!HC:out1ArrCast*/ (double) m_parameter; 
			}
            internal /*!HC:outArr1*/ double max(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal /*!HC:outArr1*/ double min(/*!HC:inArr1*/ double in1) {
                return /*!HC:out1ArrCast*/ (double) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        #endregion HYCALPER LOOPEND INNERFUNCTION:TYPE_TYPE1
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        private class  opuint64_uint64 {
            private  UInt64 m_parameter;
            ILUInt64FunctionUInt64UInt64  m_applyFun;

            internal  opuint64_uint64 ( UInt64 parameter,
                     ILUInt64FunctionUInt64UInt64 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  UInt64 operate( UInt64 in1) {
                return  (UInt64) (m_applyFun(in1, m_parameter));
			}
            internal  UInt64 add( UInt64 in1) {
				return  (UInt64) (in1 + m_parameter);
			}
            internal  UInt64 subtractL( UInt64 in1) {
                return  (UInt64) (in1 - m_parameter);
            } 
            internal  UInt64 subtractR( UInt64 in1) {
               return  (UInt64) (m_parameter - in1);
            }
            internal  UInt64 divideL( UInt64 in1) {
                return  (UInt64) (in1 / m_parameter);
            }
            internal  UInt64 divideR( UInt64 in1) {
                return  (UInt64) (m_parameter / in1);
            }
            internal  UInt64 multiply( UInt64 in1) {
				return  (UInt64) (in1 * m_parameter);
			}
            internal  UInt64 set( UInt64 discard) {
				return  (UInt64) m_parameter; 
			}
            internal  UInt64 max( UInt64 in1) {
                return  (UInt64) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  UInt64 min( UInt64 in1) {
                return  (UInt64) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opuint32_uint32 {
            private  UInt32 m_parameter;
            ILUInt32FunctionUInt32UInt32  m_applyFun;

            internal  opuint32_uint32 ( UInt32 parameter,
                     ILUInt32FunctionUInt32UInt32 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  UInt32 operate( UInt32 in1) {
                return  (UInt32) (m_applyFun(in1, m_parameter));
			}
            internal  UInt32 add( UInt32 in1) {
				return  (UInt32) (in1 + m_parameter);
			}
            internal  UInt32 subtractL( UInt32 in1) {
                return  (UInt32) (in1 - m_parameter);
            } 
            internal  UInt32 subtractR( UInt32 in1) {
               return  (UInt32) (m_parameter - in1);
            }
            internal  UInt32 divideL( UInt32 in1) {
                return  (UInt32) (in1 / m_parameter);
            }
            internal  UInt32 divideR( UInt32 in1) {
                return  (UInt32) (m_parameter / in1);
            }
            internal  UInt32 multiply( UInt32 in1) {
				return  (UInt32) (in1 * m_parameter);
			}
            internal  UInt32 set( UInt32 discard) {
				return  (UInt32) m_parameter; 
			}
            internal  UInt32 max( UInt32 in1) {
                return  (UInt32) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  UInt32 min( UInt32 in1) {
                return  (UInt32) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opuint16_uint16 {
            private  UInt16 m_parameter;
            ILUInt16FunctionUInt16UInt16  m_applyFun;

            internal  opuint16_uint16 ( UInt16 parameter,
                     ILUInt16FunctionUInt16UInt16 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  UInt16 operate( UInt16 in1) {
                return  (UInt16) (m_applyFun(in1, m_parameter));
			}
            internal  UInt16 add( UInt16 in1) {
				return  (UInt16) (in1 + m_parameter);
			}
            internal  UInt16 subtractL( UInt16 in1) {
                return  (UInt16) (in1 - m_parameter);
            } 
            internal  UInt16 subtractR( UInt16 in1) {
               return  (UInt16) (m_parameter - in1);
            }
            internal  UInt16 divideL( UInt16 in1) {
                return  (UInt16) (in1 / m_parameter);
            }
            internal  UInt16 divideR( UInt16 in1) {
                return  (UInt16) (m_parameter / in1);
            }
            internal  UInt16 multiply( UInt16 in1) {
				return  (UInt16) (in1 * m_parameter);
			}
            internal  UInt16 set( UInt16 discard) {
				return  (UInt16) m_parameter; 
			}
            internal  UInt16 max( UInt16 in1) {
                return  (UInt16) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  UInt16 min( UInt16 in1) {
                return  (UInt16) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opint64_int64 {
            private  Int64 m_parameter;
            ILInt64FunctionInt64Int64  m_applyFun;

            internal  opint64_int64 ( Int64 parameter,
                     ILInt64FunctionInt64Int64 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  Int64 operate( Int64 in1) {
                return  (Int64) (m_applyFun(in1, m_parameter));
			}
            internal  Int64 add( Int64 in1) {
				return  (Int64) (in1 + m_parameter);
			}
            internal  Int64 subtractL( Int64 in1) {
                return  (Int64) (in1 - m_parameter);
            } 
            internal  Int64 subtractR( Int64 in1) {
               return  (Int64) (m_parameter - in1);
            }
            internal  Int64 divideL( Int64 in1) {
                return  (Int64) (in1 / m_parameter);
            }
            internal  Int64 divideR( Int64 in1) {
                return  (Int64) (m_parameter / in1);
            }
            internal  Int64 multiply( Int64 in1) {
				return  (Int64) (in1 * m_parameter);
			}
            internal  Int64 set( Int64 discard) {
				return  (Int64) m_parameter; 
			}
            internal  Int64 max( Int64 in1) {
                return  (Int64) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  Int64 min( Int64 in1) {
                return  (Int64) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opint32_int32 {
            private  Int32 m_parameter;
            ILInt32FunctionInt32Int32  m_applyFun;

            internal  opint32_int32 ( Int32 parameter,
                     ILInt32FunctionInt32Int32 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  Int32 operate( Int32 in1) {
                return  (Int32) (m_applyFun(in1, m_parameter));
			}
            internal  Int32 add( Int32 in1) {
				return  (Int32) (in1 + m_parameter);
			}
            internal  Int32 subtractL( Int32 in1) {
                return  (Int32) (in1 - m_parameter);
            } 
            internal  Int32 subtractR( Int32 in1) {
               return  (Int32) (m_parameter - in1);
            }
            internal  Int32 divideL( Int32 in1) {
                return  (Int32) (in1 / m_parameter);
            }
            internal  Int32 divideR( Int32 in1) {
                return  (Int32) (m_parameter / in1);
            }
            internal  Int32 multiply( Int32 in1) {
				return  (Int32) (in1 * m_parameter);
			}
            internal  Int32 set( Int32 discard) {
				return  (Int32) m_parameter; 
			}
            internal  Int32 max( Int32 in1) {
                return  (Int32) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  Int32 min( Int32 in1) {
                return  (Int32) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opint16_int16 {
            private  Int16 m_parameter;
            ILInt16FunctionInt16Int16  m_applyFun;

            internal  opint16_int16 ( Int16 parameter,
                     ILInt16FunctionInt16Int16 applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  Int16 operate( Int16 in1) {
                return  (Int16) (m_applyFun(in1, m_parameter));
			}
            internal  Int16 add( Int16 in1) {
				return  (Int16) (in1 + m_parameter);
			}
            internal  Int16 subtractL( Int16 in1) {
                return  (Int16) (in1 - m_parameter);
            } 
            internal  Int16 subtractR( Int16 in1) {
               return  (Int16) (m_parameter - in1);
            }
            internal  Int16 divideL( Int16 in1) {
                return  (Int16) (in1 / m_parameter);
            }
            internal  Int16 divideR( Int16 in1) {
                return  (Int16) (m_parameter / in1);
            }
            internal  Int16 multiply( Int16 in1) {
				return  (Int16) (in1 * m_parameter);
			}
            internal  Int16 set( Int16 discard) {
				return  (Int16) m_parameter; 
			}
            internal  Int16 max( Int16 in1) {
                return  (Int16) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  Int16 min( Int16 in1) {
                return  (Int16) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opfloat_float {
            private  float m_parameter;
            ILFloatFunctionFloatFloat  m_applyFun;

            internal  opfloat_float ( float parameter,
                     ILFloatFunctionFloatFloat applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  float operate( float in1) {
                return  (float) (m_applyFun(in1, m_parameter));
			}
            internal  float add( float in1) {
				return  (float) (in1 + m_parameter);
			}
            internal  float subtractL( float in1) {
                return  (float) (in1 - m_parameter);
            } 
            internal  float subtractR( float in1) {
               return  (float) (m_parameter - in1);
            }
            internal  float divideL( float in1) {
                return  (float) (in1 / m_parameter);
            }
            internal  float divideR( float in1) {
                return  (float) (m_parameter / in1);
            }
            internal  float multiply( float in1) {
				return  (float) (in1 * m_parameter);
			}
            internal  float set( float discard) {
				return  (float) m_parameter; 
			}
            internal  float max( float in1) {
                return  (float) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  float min( float in1) {
                return  (float) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opfcomplex_fcomplex {
            private  fcomplex m_parameter;
            ILFcomplexFunctionFcomplexFcomplex  m_applyFun;

            internal  opfcomplex_fcomplex ( fcomplex parameter,
                     ILFcomplexFunctionFcomplexFcomplex applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  fcomplex operate( fcomplex in1) {
                return  (fcomplex) (m_applyFun(in1, m_parameter));
			}
            internal  fcomplex add( fcomplex in1) {
				return  (fcomplex) (in1 + m_parameter);
			}
            internal  fcomplex subtractL( fcomplex in1) {
                return  (fcomplex) (in1 - m_parameter);
            } 
            internal  fcomplex subtractR( fcomplex in1) {
               return  (fcomplex) (m_parameter - in1);
            }
            internal  fcomplex divideL( fcomplex in1) {
                return  (fcomplex) (in1 / m_parameter);
            }
            internal  fcomplex divideR( fcomplex in1) {
                return  (fcomplex) (m_parameter / in1);
            }
            internal  fcomplex multiply( fcomplex in1) {
				return  (fcomplex) (in1 * m_parameter);
			}
            internal  fcomplex set( fcomplex discard) {
				return  (fcomplex) m_parameter; 
			}
            internal  fcomplex max( fcomplex in1) {
                return  (fcomplex) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  fcomplex min( fcomplex in1) {
                return  (fcomplex) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opcomplex_complex {
            private  complex m_parameter;
            ILComplexFunctionComplexComplex  m_applyFun;

            internal  opcomplex_complex ( complex parameter,
                     ILComplexFunctionComplexComplex applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  complex operate( complex in1) {
                return  (complex) (m_applyFun(in1, m_parameter));
			}
            internal  complex add( complex in1) {
				return  (complex) (in1 + m_parameter);
			}
            internal  complex subtractL( complex in1) {
                return  (complex) (in1 - m_parameter);
            } 
            internal  complex subtractR( complex in1) {
               return  (complex) (m_parameter - in1);
            }
            internal  complex divideL( complex in1) {
                return  (complex) (in1 / m_parameter);
            }
            internal  complex divideR( complex in1) {
                return  (complex) (m_parameter / in1);
            }
            internal  complex multiply( complex in1) {
				return  (complex) (in1 * m_parameter);
			}
            internal  complex set( complex discard) {
				return  (complex) m_parameter; 
			}
            internal  complex max( complex in1) {
                return  (complex) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  complex min( complex in1) {
                return  (complex) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opchar_char {
            private  char m_parameter;
            ILCharFunctionCharChar  m_applyFun;

            internal  opchar_char ( char parameter,
                     ILCharFunctionCharChar applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  char operate( char in1) {
                return  (char) (m_applyFun(in1, m_parameter));
			}
            internal  char add( char in1) {
				return  (char) (in1 + m_parameter);
			}
            internal  char subtractL( char in1) {
                return  (char) (in1 - m_parameter);
            } 
            internal  char subtractR( char in1) {
               return  (char) (m_parameter - in1);
            }
            internal  char divideL( char in1) {
                return  (char) (in1 / m_parameter);
            }
            internal  char divideR( char in1) {
                return  (char) (m_parameter / in1);
            }
            internal  char multiply( char in1) {
				return  (char) (in1 * m_parameter);
			}
            internal  char set( char discard) {
				return  (char) m_parameter; 
			}
            internal  char max( char in1) {
                return  (char) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  char min( char in1) {
                return  (char) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }

        private class  opbyte_byte {
            private  byte m_parameter;
            ILByteFunctionByteByte  m_applyFun;

            internal  opbyte_byte ( byte parameter,
                     ILByteFunctionByteByte applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			} 
            internal  byte operate( byte in1) {
                return  (byte) (m_applyFun(in1, m_parameter));
			}
            internal  byte add( byte in1) {
				return  (byte) (in1 + m_parameter);
			}
            internal  byte subtractL( byte in1) {
                return  (byte) (in1 - m_parameter);
            } 
            internal  byte subtractR( byte in1) {
               return  (byte) (m_parameter - in1);
            }
            internal  byte divideL( byte in1) {
                return  (byte) (in1 / m_parameter);
            }
            internal  byte divideR( byte in1) {
                return  (byte) (m_parameter / in1);
            }
            internal  byte multiply( byte in1) {
				return  (byte) (in1 * m_parameter);
			}
            internal  byte set( byte discard) {
				return  (byte) m_parameter; 
			}
            internal  byte max( byte in1) {
                return  (byte) ((in1 > m_parameter) ? in1 : m_parameter);
            }
            internal  byte min( byte in1) {
                return  (byte) ((in1 < m_parameter) ? in1 : m_parameter);
            }
        }


#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART UNARY_ARRAY_FUNCTIONS_REALRETURN
 /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
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
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
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
        innerFunction
    </source>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
    <destination>BasicTypeExtensions</destination>
</type>
<type>
    <source locate="after">
        HCunaryOperator
    </source>
    <destination>ByteOperatorByte</destination>
    <destination>CharOperatorChar</destination>
    <destination>DoubleOperatorComplex</destination>
    <destination>FloatOperatorFcomplex</destination>
    <destination>FloatOperatorFloat</destination>
    <destination>Int16OperatorInt16</destination>
    <destination>Int32OperatorInt32</destination>
    <destination>Int64OperatorInt64</destination>
    <destination>UInt16OperatorUInt16</destination>
    <destination>UInt32OperatorUInt32</destination>
    <destination>UInt64OperatorUInt64</destination>
</type>
</hycalper>
 */
       //public static /*!HC:outCls1*/ ILArray<double> abs(/*!HC:inCls1*/ ILArray<double> A) {
       //     return /*!HC:HCunaryOperator*/ DoubleOperatorDouble (A,/*!HC:innerFunction*/ Math .Abs );
       // }
        #endregion HYCALPER LOOPEND UNARY_ARRAY_FUNCTIONS_REALRETURN
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
 
       //public static  ILArray<UInt64> abs( ILArray<UInt64> A) {
       //     return  UInt64OperatorUInt64 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<UInt32> abs( ILArray<UInt32> A) {
       //     return  UInt32OperatorUInt32 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<UInt16> abs( ILArray<UInt16> A) {
       //     return  UInt16OperatorUInt16 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<Int64> abs( ILArray<Int64> A) {
       //     return  Int64OperatorInt64 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<Int32> abs( ILArray<Int32> A) {
       //     return  Int32OperatorInt32 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<Int16> abs( ILArray<Int16> A) {
       //     return  Int16OperatorInt16 (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<float> abs( ILArray<float> A) {
       //     return  FloatOperatorFloat (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<float> abs( ILArray<fcomplex> A) {
       //     return  FloatOperatorFcomplex (A, fcomplex .Abs );
       // }
 
       //public static  ILArray<double> abs( ILArray<complex> A) {
       //     return  DoubleOperatorComplex (A, complex .Abs );
       // }
 
       //public static  ILArray<char> abs( ILArray<char> A) {
       //     return  CharOperatorChar (A, BasicTypeExtensions .Abs );
       // }
 
       //public static  ILArray<byte> abs( ILArray<byte> A) {
       //     return  ByteOperatorByte (A, BasicTypeExtensions .Abs );
       // }

#endregion HYCALPER AUTO GENERATED CODE
        
        #region HYCALPER LOOPSTART UNARY_ARRAY_FUNCTIONS
 /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
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
</type>
<type>
    <source locate="after">
        innerFunction
    </source>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
    <destination>ILMath.BasicTypeExtensions</destination>
</type>
</hycalper>
 */
        //public static /*!HC:outCls1*/ ILArray<double> ceil(/*!HC:inCls1*/ ILArray<double> A) {
        //    return /*!HC:unaryop*/ DoubleOperatorDouble (A,/*!HC:innerFunction*/ Math .Ceiling );
        //}
        //public static /*!HC:outCls1*/ ILArray<double> floor(/*!HC:inCls1*/ ILArray<double> A) {
        //    return /*!HC:unaryop*/ DoubleOperatorDouble (A,/*!HC:innerFunction*/ Math .Floor );
        //}
        //public static /*!HC:outCls1*/ ILArray<double> round(/*!HC:inCls1*/ ILArray<double> A) {
        //    return /*!HC:unaryop*/ DoubleOperatorDouble ( A,/*!HC:innerFunction*/ Math .Round );
        //}
        //public static /*!HC:outCls1*/ ILArray<double> sign(/*!HC:inCls1*/ ILArray<double> A) {
        //    return /*!HC:unaryop*/ DoubleOperatorDouble (A,/*!HC:innerFunction*/ ILMath.BasicTypeExtensions .Sign);
        //}
        //public static /*!HC:outCls1*/ ILArray<double> truncate(/*!HC:inCls1*/ ILArray<double> A) {
        //    return /*!HC:unaryop*/ DoubleOperatorDouble (A,/*!HC:innerFunction*/ Math .Truncate );
        //}
        #endregion HYCALPER LOOPEND UNARY_ARRAY_FUNCTIONS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
 
        //public static  ILArray<UInt64> ceil( ILArray<UInt64> A) {
        //    return  UInt64OperatorUInt64 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<UInt64> floor( ILArray<UInt64> A) {
        //    return  UInt64OperatorUInt64 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<UInt64> round( ILArray<UInt64> A) {
        //    return  UInt64OperatorUInt64 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<UInt64> sign( ILArray<UInt64> A) {
        //    return  UInt64OperatorUInt64 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<UInt64> truncate( ILArray<UInt64> A) {
        //    return  UInt64OperatorUInt64 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<UInt32> ceil( ILArray<UInt32> A) {
        //    return  UInt32OperatorUInt32 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<UInt32> floor( ILArray<UInt32> A) {
        //    return  UInt32OperatorUInt32 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<UInt32> round( ILArray<UInt32> A) {
        //    return  UInt32OperatorUInt32 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<UInt32> sign( ILArray<UInt32> A) {
        //    return  UInt32OperatorUInt32 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<UInt32> truncate( ILArray<UInt32> A) {
        //    return  UInt32OperatorUInt32 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<UInt16> ceil( ILArray<UInt16> A) {
        //    return  UInt16OperatorUInt16 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<UInt16> floor( ILArray<UInt16> A) {
        //    return  UInt16OperatorUInt16 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<UInt16> round( ILArray<UInt16> A) {
        //    return  UInt16OperatorUInt16 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<UInt16> sign( ILArray<UInt16> A) {
        //    return  UInt16OperatorUInt16 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<UInt16> truncate( ILArray<UInt16> A) {
        //    return  UInt16OperatorUInt16 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<Int64> ceil( ILArray<Int64> A) {
        //    return  Int64OperatorInt64 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<Int64> floor( ILArray<Int64> A) {
        //    return  Int64OperatorInt64 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<Int64> round( ILArray<Int64> A) {
        //    return  Int64OperatorInt64 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<Int64> sign( ILArray<Int64> A) {
        //    return  Int64OperatorInt64 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<Int64> truncate( ILArray<Int64> A) {
        //    return  Int64OperatorInt64 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<Int32> ceil( ILArray<Int32> A) {
        //    return  Int32OperatorInt32 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<Int32> floor( ILArray<Int32> A) {
        //    return  Int32OperatorInt32 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<Int32> round( ILArray<Int32> A) {
        //    return  Int32OperatorInt32 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<Int32> sign( ILArray<Int32> A) {
        //    return  Int32OperatorInt32 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<Int32> truncate( ILArray<Int32> A) {
        //    return  Int32OperatorInt32 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<Int16> ceil( ILArray<Int16> A) {
        //    return  Int16OperatorInt16 (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<Int16> floor( ILArray<Int16> A) {
        //    return  Int16OperatorInt16 (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<Int16> round( ILArray<Int16> A) {
        //    return  Int16OperatorInt16 ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<Int16> sign( ILArray<Int16> A) {
        //    return  Int16OperatorInt16 (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<Int16> truncate( ILArray<Int16> A) {
        //    return  Int16OperatorInt16 (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<float> ceil( ILArray<float> A) {
        //    return  FloatOperatorFloat (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<float> floor( ILArray<float> A) {
        //    return  FloatOperatorFloat (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<float> round( ILArray<float> A) {
        //    return  FloatOperatorFloat ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<float> sign( ILArray<float> A) {
        //    return  FloatOperatorFloat (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<float> truncate( ILArray<float> A) {
        //    return  FloatOperatorFloat (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<fcomplex> ceil( ILArray<fcomplex> A) {
        //    return  FcomplexOperatorFcomplex (A, fcomplex .Ceiling );
        //}
        //public static  ILArray<fcomplex> floor( ILArray<fcomplex> A) {
        //    return  FcomplexOperatorFcomplex (A, fcomplex .Floor );
        //}
        //public static  ILArray<fcomplex> round( ILArray<fcomplex> A) {
        //    return  FcomplexOperatorFcomplex ( A, fcomplex .Round );
        //}
        //public static  ILArray<fcomplex> sign( ILArray<fcomplex> A) {
        //    return  FcomplexOperatorFcomplex (A, fcomplex .Sign);
        //}
        //public static  ILArray<fcomplex> truncate( ILArray<fcomplex> A) {
        //    return  FcomplexOperatorFcomplex (A, fcomplex .Truncate );
        //}
 
        //public static  ILArray<complex> ceil( ILArray<complex> A) {
        //    return  ComplexOperatorComplex (A, complex .Ceiling );
        //}
        //public static  ILArray<complex> floor( ILArray<complex> A) {
        //    return  ComplexOperatorComplex (A, complex .Floor );
        //}
        //public static  ILArray<complex> round( ILArray<complex> A) {
        //    return  ComplexOperatorComplex ( A, complex .Round );
        //}
        //public static  ILArray<complex> sign( ILArray<complex> A) {
        //    return  ComplexOperatorComplex (A, complex .Sign);
        //}
        //public static  ILArray<complex> truncate( ILArray<complex> A) {
        //    return  ComplexOperatorComplex (A, complex .Truncate );
        //}
 
        //public static  ILArray<char> ceil( ILArray<char> A) {
        //    return  CharOperatorChar (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<char> floor( ILArray<char> A) {
        //    return  CharOperatorChar (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<char> round( ILArray<char> A) {
        //    return  CharOperatorChar ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<char> sign( ILArray<char> A) {
        //    return  CharOperatorChar (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<char> truncate( ILArray<char> A) {
        //    return  CharOperatorChar (A, ILMath.BasicTypeExtensions .Truncate );
        //}
 
        //public static  ILArray<byte> ceil( ILArray<byte> A) {
        //    return  ByteOperatorByte (A, ILMath.BasicTypeExtensions .Ceiling );
        //}
        //public static  ILArray<byte> floor( ILArray<byte> A) {
        //    return  ByteOperatorByte (A, ILMath.BasicTypeExtensions .Floor );
        //}
        //public static  ILArray<byte> round( ILArray<byte> A) {
        //    return  ByteOperatorByte ( A, ILMath.BasicTypeExtensions .Round );
        //}
        //public static  ILArray<byte> sign( ILArray<byte> A) {
        //    return  ByteOperatorByte (A, ILMath.BasicTypeExtensions .Sign);
        //}
        //public static  ILArray<byte> truncate( ILArray<byte> A) {
        //    return  ByteOperatorByte (A, ILMath.BasicTypeExtensions .Truncate );
        //}

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART BINARY_SKALAR_FUNCTIONS
 /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArrSkalar
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
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
        hcwalkerop
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
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opchar_char</destination>
    <destination>opcomplex_complex</destination>
    <destination>opfcomplex_fcomplex</destination>
    <destination>opfloat_float</destination>
    <destination>opint16_int16</destination>
    <destination>opint32_int32</destination>
    <destination>opint64_int64</destination>
    <destination>opuint16_uint16</destination>
    <destination>opuint32_uint32</destination>
    <destination>opuint64_uint64</destination>
</type>
</hycalper>
 */
        //private static /*!HC:outCls1*/ ILArray<double> add(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
        //    /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
        //    return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.add);
        //}
        //private static /*!HC:outCls1*/ ILArray<double> subtractL(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
        //    /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
        //    return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.subtractL);
        //}
        //private static /*!HC:outCls1*/ ILArray<double> subtractR(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
        //    /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
        //    return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.subtractR);
        //}
        //private static /*!HC:outCls1*/ ILArray<double> divideL(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
        //    /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
        //    return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.divideL);
        //}
        //private static /*!HC:outCls1*/ ILArray<double> divideR(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
        //    /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
        //    return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.divideR);
        //}
        private static /*!HC:outCls1*/ ILArray<double> multiply(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
            /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
            return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.multiply);
		}
        private static /*!HC:outCls1*/ ILArray<double> set(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
            /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
            return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.set);
		}
        private static /*!HC:outCls1*/ ILArray<double> max(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
            /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
            return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.max);
        }
        private static /*!HC:outCls1*/ ILArray<double> min(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArrSkalar*/ double parameter) {
            /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double (parameter, null);
            return /*!HC:hcwalkerop*/ DoubleOperatorDouble (A, helper.min);
        }
        #endregion HYCALPER LOOPEND BINARY_SKALAR_FUNCTIONS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
 
        //private static  ILArray<UInt64> add( ILArray<UInt64> A, UInt64 parameter) {
        //    opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
        //    return  UInt64OperatorUInt64 (A, helper.add);
        //}
        //private static  ILArray<UInt64> subtractL( ILArray<UInt64> A, UInt64 parameter) {
        //    opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
        //    return  UInt64OperatorUInt64 (A, helper.subtractL);
        //}
        //private static  ILArray<UInt64> subtractR( ILArray<UInt64> A, UInt64 parameter) {
        //    opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
        //    return  UInt64OperatorUInt64 (A, helper.subtractR);
        //}
        //private static  ILArray<UInt64> divideL( ILArray<UInt64> A, UInt64 parameter) {
        //    opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
        //    return  UInt64OperatorUInt64 (A, helper.divideL);
        //}
        //private static  ILArray<UInt64> divideR( ILArray<UInt64> A, UInt64 parameter) {
        //    opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
        //    return  UInt64OperatorUInt64 (A, helper.divideR);
        //}
        private static  ILArray<UInt64> multiply( ILArray<UInt64> A, UInt64 parameter) {
            opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
            return  UInt64OperatorUInt64 (A, helper.multiply);
		}
        private static  ILArray<UInt64> set( ILArray<UInt64> A, UInt64 parameter) {
            opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
            return  UInt64OperatorUInt64 (A, helper.set);
		}
        private static  ILArray<UInt64> max( ILArray<UInt64> A, UInt64 parameter) {
            opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
            return  UInt64OperatorUInt64 (A, helper.max);
        }
        private static  ILArray<UInt64> min( ILArray<UInt64> A, UInt64 parameter) {
            opuint64_uint64 helper = new  opuint64_uint64 (parameter, null);
            return  UInt64OperatorUInt64 (A, helper.min);
        }
 
        //private static  ILArray<UInt32> add( ILArray<UInt32> A, UInt32 parameter) {
        //    opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
        //    return  UInt32OperatorUInt32 (A, helper.add);
        //}
        //private static  ILArray<UInt32> subtractL( ILArray<UInt32> A, UInt32 parameter) {
        //    opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
        //    return  UInt32OperatorUInt32 (A, helper.subtractL);
        //}
        //private static  ILArray<UInt32> subtractR( ILArray<UInt32> A, UInt32 parameter) {
        //    opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
        //    return  UInt32OperatorUInt32 (A, helper.subtractR);
        //}
        //private static  ILArray<UInt32> divideL( ILArray<UInt32> A, UInt32 parameter) {
        //    opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
        //    return  UInt32OperatorUInt32 (A, helper.divideL);
        //}
        //private static  ILArray<UInt32> divideR( ILArray<UInt32> A, UInt32 parameter) {
        //    opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
        //    return  UInt32OperatorUInt32 (A, helper.divideR);
        //}
        private static  ILArray<UInt32> multiply( ILArray<UInt32> A, UInt32 parameter) {
            opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
            return  UInt32OperatorUInt32 (A, helper.multiply);
		}
        private static  ILArray<UInt32> set( ILArray<UInt32> A, UInt32 parameter) {
            opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
            return  UInt32OperatorUInt32 (A, helper.set);
		}
        private static  ILArray<UInt32> max( ILArray<UInt32> A, UInt32 parameter) {
            opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
            return  UInt32OperatorUInt32 (A, helper.max);
        }
        private static  ILArray<UInt32> min( ILArray<UInt32> A, UInt32 parameter) {
            opuint32_uint32 helper = new  opuint32_uint32 (parameter, null);
            return  UInt32OperatorUInt32 (A, helper.min);
        }
 
        //private static  ILArray<UInt16> add( ILArray<UInt16> A, UInt16 parameter) {
        //    opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
        //    return  UInt16OperatorUInt16 (A, helper.add);
        //}
        //private static  ILArray<UInt16> subtractL( ILArray<UInt16> A, UInt16 parameter) {
        //    opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
        //    return  UInt16OperatorUInt16 (A, helper.subtractL);
        //}
        //private static  ILArray<UInt16> subtractR( ILArray<UInt16> A, UInt16 parameter) {
        //    opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
        //    return  UInt16OperatorUInt16 (A, helper.subtractR);
        //}
        //private static  ILArray<UInt16> divideL( ILArray<UInt16> A, UInt16 parameter) {
        //    opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
        //    return  UInt16OperatorUInt16 (A, helper.divideL);
        //}
        //private static  ILArray<UInt16> divideR( ILArray<UInt16> A, UInt16 parameter) {
        //    opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
        //    return  UInt16OperatorUInt16 (A, helper.divideR);
        //}
        private static  ILArray<UInt16> multiply( ILArray<UInt16> A, UInt16 parameter) {
            opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
            return  UInt16OperatorUInt16 (A, helper.multiply);
		}
        private static  ILArray<UInt16> set( ILArray<UInt16> A, UInt16 parameter) {
            opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
            return  UInt16OperatorUInt16 (A, helper.set);
		}
        private static  ILArray<UInt16> max( ILArray<UInt16> A, UInt16 parameter) {
            opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
            return  UInt16OperatorUInt16 (A, helper.max);
        }
        private static  ILArray<UInt16> min( ILArray<UInt16> A, UInt16 parameter) {
            opuint16_uint16 helper = new  opuint16_uint16 (parameter, null);
            return  UInt16OperatorUInt16 (A, helper.min);
        }
 
        //private static  ILArray<Int64> add( ILArray<Int64> A, Int64 parameter) {
        //    opint64_int64 helper = new  opint64_int64 (parameter, null);
        //    return  Int64OperatorInt64 (A, helper.add);
        //}
        //private static  ILArray<Int64> subtractL( ILArray<Int64> A, Int64 parameter) {
        //    opint64_int64 helper = new  opint64_int64 (parameter, null);
        //    return  Int64OperatorInt64 (A, helper.subtractL);
        //}
        //private static  ILArray<Int64> subtractR( ILArray<Int64> A, Int64 parameter) {
        //    opint64_int64 helper = new  opint64_int64 (parameter, null);
        //    return  Int64OperatorInt64 (A, helper.subtractR);
        //}
        //private static  ILArray<Int64> divideL( ILArray<Int64> A, Int64 parameter) {
        //    opint64_int64 helper = new  opint64_int64 (parameter, null);
        //    return  Int64OperatorInt64 (A, helper.divideL);
        //}
        //private static  ILArray<Int64> divideR( ILArray<Int64> A, Int64 parameter) {
        //    opint64_int64 helper = new  opint64_int64 (parameter, null);
        //    return  Int64OperatorInt64 (A, helper.divideR);
        //}
        private static  ILArray<Int64> multiply( ILArray<Int64> A, Int64 parameter) {
            opint64_int64 helper = new  opint64_int64 (parameter, null);
            return  Int64OperatorInt64 (A, helper.multiply);
		}
        private static  ILArray<Int64> set( ILArray<Int64> A, Int64 parameter) {
            opint64_int64 helper = new  opint64_int64 (parameter, null);
            return  Int64OperatorInt64 (A, helper.set);
		}
        private static  ILArray<Int64> max( ILArray<Int64> A, Int64 parameter) {
            opint64_int64 helper = new  opint64_int64 (parameter, null);
            return  Int64OperatorInt64 (A, helper.max);
        }
        private static  ILArray<Int64> min( ILArray<Int64> A, Int64 parameter) {
            opint64_int64 helper = new  opint64_int64 (parameter, null);
            return  Int64OperatorInt64 (A, helper.min);
        }
 
        //private static  ILArray<Int32> add( ILArray<Int32> A, Int32 parameter) {
        //    opint32_int32 helper = new  opint32_int32 (parameter, null);
        //    return  Int32OperatorInt32 (A, helper.add);
        //}
        //private static  ILArray<Int32> subtractL( ILArray<Int32> A, Int32 parameter) {
        //    opint32_int32 helper = new  opint32_int32 (parameter, null);
        //    return  Int32OperatorInt32 (A, helper.subtractL);
        //}
        //private static  ILArray<Int32> subtractR( ILArray<Int32> A, Int32 parameter) {
        //    opint32_int32 helper = new  opint32_int32 (parameter, null);
        //    return  Int32OperatorInt32 (A, helper.subtractR);
        //}
        //private static  ILArray<Int32> divideL( ILArray<Int32> A, Int32 parameter) {
        //    opint32_int32 helper = new  opint32_int32 (parameter, null);
        //    return  Int32OperatorInt32 (A, helper.divideL);
        //}
        //private static  ILArray<Int32> divideR( ILArray<Int32> A, Int32 parameter) {
        //    opint32_int32 helper = new  opint32_int32 (parameter, null);
        //    return  Int32OperatorInt32 (A, helper.divideR);
        //}
        private static  ILArray<Int32> multiply( ILArray<Int32> A, Int32 parameter) {
            opint32_int32 helper = new  opint32_int32 (parameter, null);
            return  Int32OperatorInt32 (A, helper.multiply);
		}
        private static  ILArray<Int32> set( ILArray<Int32> A, Int32 parameter) {
            opint32_int32 helper = new  opint32_int32 (parameter, null);
            return  Int32OperatorInt32 (A, helper.set);
		}
        private static  ILArray<Int32> max( ILArray<Int32> A, Int32 parameter) {
            opint32_int32 helper = new  opint32_int32 (parameter, null);
            return  Int32OperatorInt32 (A, helper.max);
        }
        private static  ILArray<Int32> min( ILArray<Int32> A, Int32 parameter) {
            opint32_int32 helper = new  opint32_int32 (parameter, null);
            return  Int32OperatorInt32 (A, helper.min);
        }
 
        //private static  ILArray<Int16> add( ILArray<Int16> A, Int16 parameter) {
        //    opint16_int16 helper = new  opint16_int16 (parameter, null);
        //    return  Int16OperatorInt16 (A, helper.add);
        //}
        //private static  ILArray<Int16> subtractL( ILArray<Int16> A, Int16 parameter) {
        //    opint16_int16 helper = new  opint16_int16 (parameter, null);
        //    return  Int16OperatorInt16 (A, helper.subtractL);
        //}
        //private static  ILArray<Int16> subtractR( ILArray<Int16> A, Int16 parameter) {
        //    opint16_int16 helper = new  opint16_int16 (parameter, null);
        //    return  Int16OperatorInt16 (A, helper.subtractR);
        //}
        //private static  ILArray<Int16> divideL( ILArray<Int16> A, Int16 parameter) {
        //    opint16_int16 helper = new  opint16_int16 (parameter, null);
        //    return  Int16OperatorInt16 (A, helper.divideL);
        //}
        //private static  ILArray<Int16> divideR( ILArray<Int16> A, Int16 parameter) {
        //    opint16_int16 helper = new  opint16_int16 (parameter, null);
        //    return  Int16OperatorInt16 (A, helper.divideR);
        //}
        private static  ILArray<Int16> multiply( ILArray<Int16> A, Int16 parameter) {
            opint16_int16 helper = new  opint16_int16 (parameter, null);
            return  Int16OperatorInt16 (A, helper.multiply);
		}
        private static  ILArray<Int16> set( ILArray<Int16> A, Int16 parameter) {
            opint16_int16 helper = new  opint16_int16 (parameter, null);
            return  Int16OperatorInt16 (A, helper.set);
		}
        private static  ILArray<Int16> max( ILArray<Int16> A, Int16 parameter) {
            opint16_int16 helper = new  opint16_int16 (parameter, null);
            return  Int16OperatorInt16 (A, helper.max);
        }
        private static  ILArray<Int16> min( ILArray<Int16> A, Int16 parameter) {
            opint16_int16 helper = new  opint16_int16 (parameter, null);
            return  Int16OperatorInt16 (A, helper.min);
        }
 
        //private static  ILArray<float> add( ILArray<float> A, float parameter) {
        //    opfloat_float helper = new  opfloat_float (parameter, null);
        //    return  FloatOperatorFloat (A, helper.add);
        //}
        //private static  ILArray<float> subtractL( ILArray<float> A, float parameter) {
        //    opfloat_float helper = new  opfloat_float (parameter, null);
        //    return  FloatOperatorFloat (A, helper.subtractL);
        //}
        //private static  ILArray<float> subtractR( ILArray<float> A, float parameter) {
        //    opfloat_float helper = new  opfloat_float (parameter, null);
        //    return  FloatOperatorFloat (A, helper.subtractR);
        //}
        //private static  ILArray<float> divideL( ILArray<float> A, float parameter) {
        //    opfloat_float helper = new  opfloat_float (parameter, null);
        //    return  FloatOperatorFloat (A, helper.divideL);
        //}
        //private static  ILArray<float> divideR( ILArray<float> A, float parameter) {
        //    opfloat_float helper = new  opfloat_float (parameter, null);
        //    return  FloatOperatorFloat (A, helper.divideR);
        //}
        private static  ILArray<float> multiply( ILArray<float> A, float parameter) {
            opfloat_float helper = new  opfloat_float (parameter, null);
            return  FloatOperatorFloat (A, helper.multiply);
		}
        private static  ILArray<float> set( ILArray<float> A, float parameter) {
            opfloat_float helper = new  opfloat_float (parameter, null);
            return  FloatOperatorFloat (A, helper.set);
		}
        private static  ILArray<float> max( ILArray<float> A, float parameter) {
            opfloat_float helper = new  opfloat_float (parameter, null);
            return  FloatOperatorFloat (A, helper.max);
        }
        private static  ILArray<float> min( ILArray<float> A, float parameter) {
            opfloat_float helper = new  opfloat_float (parameter, null);
            return  FloatOperatorFloat (A, helper.min);
        }
 
        //private static  ILArray<fcomplex> add( ILArray<fcomplex> A, fcomplex parameter) {
        //    opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
        //    return  FcomplexOperatorFcomplex (A, helper.add);
        //}
        //private static  ILArray<fcomplex> subtractL( ILArray<fcomplex> A, fcomplex parameter) {
        //    opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
        //    return  FcomplexOperatorFcomplex (A, helper.subtractL);
        //}
        //private static  ILArray<fcomplex> subtractR( ILArray<fcomplex> A, fcomplex parameter) {
        //    opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
        //    return  FcomplexOperatorFcomplex (A, helper.subtractR);
        //}
        //private static  ILArray<fcomplex> divideL( ILArray<fcomplex> A, fcomplex parameter) {
        //    opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
        //    return  FcomplexOperatorFcomplex (A, helper.divideL);
        //}
        //private static  ILArray<fcomplex> divideR( ILArray<fcomplex> A, fcomplex parameter) {
        //    opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
        //    return  FcomplexOperatorFcomplex (A, helper.divideR);
        //}
        private static  ILArray<fcomplex> multiply( ILArray<fcomplex> A, fcomplex parameter) {
            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
            return  FcomplexOperatorFcomplex (A, helper.multiply);
		}
        private static  ILArray<fcomplex> set( ILArray<fcomplex> A, fcomplex parameter) {
            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
            return  FcomplexOperatorFcomplex (A, helper.set);
		}
        private static  ILArray<fcomplex> max( ILArray<fcomplex> A, fcomplex parameter) {
            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
            return  FcomplexOperatorFcomplex (A, helper.max);
        }
        private static  ILArray<fcomplex> min( ILArray<fcomplex> A, fcomplex parameter) {
            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (parameter, null);
            return  FcomplexOperatorFcomplex (A, helper.min);
        }
 
        //private static  ILArray<complex> add( ILArray<complex> A, complex parameter) {
        //    opcomplex_complex helper = new  opcomplex_complex (parameter, null);
        //    return  ComplexOperatorComplex (A, helper.add);
        //}
        //private static  ILArray<complex> subtractL( ILArray<complex> A, complex parameter) {
        //    opcomplex_complex helper = new  opcomplex_complex (parameter, null);
        //    return  ComplexOperatorComplex (A, helper.subtractL);
        //}
        //private static  ILArray<complex> subtractR( ILArray<complex> A, complex parameter) {
        //    opcomplex_complex helper = new  opcomplex_complex (parameter, null);
        //    return  ComplexOperatorComplex (A, helper.subtractR);
        //}
        //private static  ILArray<complex> divideL( ILArray<complex> A, complex parameter) {
        //    opcomplex_complex helper = new  opcomplex_complex (parameter, null);
        //    return  ComplexOperatorComplex (A, helper.divideL);
        //}
        //private static  ILArray<complex> divideR( ILArray<complex> A, complex parameter) {
        //    opcomplex_complex helper = new  opcomplex_complex (parameter, null);
        //    return  ComplexOperatorComplex (A, helper.divideR);
        //}
        private static  ILArray<complex> multiply( ILArray<complex> A, complex parameter) {
            opcomplex_complex helper = new  opcomplex_complex (parameter, null);
            return  ComplexOperatorComplex (A, helper.multiply);
		}
        private static  ILArray<complex> set( ILArray<complex> A, complex parameter) {
            opcomplex_complex helper = new  opcomplex_complex (parameter, null);
            return  ComplexOperatorComplex (A, helper.set);
		}
        private static  ILArray<complex> max( ILArray<complex> A, complex parameter) {
            opcomplex_complex helper = new  opcomplex_complex (parameter, null);
            return  ComplexOperatorComplex (A, helper.max);
        }
        private static  ILArray<complex> min( ILArray<complex> A, complex parameter) {
            opcomplex_complex helper = new  opcomplex_complex (parameter, null);
            return  ComplexOperatorComplex (A, helper.min);
        }
 
        //private static  ILArray<char> add( ILArray<char> A, char parameter) {
        //    opchar_char helper = new  opchar_char (parameter, null);
        //    return  CharOperatorChar (A, helper.add);
        //}
        //private static  ILArray<char> subtractL( ILArray<char> A, char parameter) {
        //    opchar_char helper = new  opchar_char (parameter, null);
        //    return  CharOperatorChar (A, helper.subtractL);
        //}
        //private static  ILArray<char> subtractR( ILArray<char> A, char parameter) {
        //    opchar_char helper = new  opchar_char (parameter, null);
        //    return  CharOperatorChar (A, helper.subtractR);
        //}
        //private static  ILArray<char> divideL( ILArray<char> A, char parameter) {
        //    opchar_char helper = new  opchar_char (parameter, null);
        //    return  CharOperatorChar (A, helper.divideL);
        //}
        //private static  ILArray<char> divideR( ILArray<char> A, char parameter) {
        //    opchar_char helper = new  opchar_char (parameter, null);
        //    return  CharOperatorChar (A, helper.divideR);
        //}
        private static  ILArray<char> multiply( ILArray<char> A, char parameter) {
            opchar_char helper = new  opchar_char (parameter, null);
            return  CharOperatorChar (A, helper.multiply);
		}
        private static  ILArray<char> set( ILArray<char> A, char parameter) {
            opchar_char helper = new  opchar_char (parameter, null);
            return  CharOperatorChar (A, helper.set);
		}
        private static  ILArray<char> max( ILArray<char> A, char parameter) {
            opchar_char helper = new  opchar_char (parameter, null);
            return  CharOperatorChar (A, helper.max);
        }
        private static  ILArray<char> min( ILArray<char> A, char parameter) {
            opchar_char helper = new  opchar_char (parameter, null);
            return  CharOperatorChar (A, helper.min);
        }
 
        //private static  ILArray<byte> add( ILArray<byte> A, byte parameter) {
        //    opbyte_byte helper = new  opbyte_byte (parameter, null);
        //    return  ByteOperatorByte (A, helper.add);
        //}
        //private static  ILArray<byte> subtractL( ILArray<byte> A, byte parameter) {
        //    opbyte_byte helper = new  opbyte_byte (parameter, null);
        //    return  ByteOperatorByte (A, helper.subtractL);
        //}
        //private static  ILArray<byte> subtractR( ILArray<byte> A, byte parameter) {
        //    opbyte_byte helper = new  opbyte_byte (parameter, null);
        //    return  ByteOperatorByte (A, helper.subtractR);
        //}
        //private static  ILArray<byte> divideL( ILArray<byte> A, byte parameter) {
        //    opbyte_byte helper = new  opbyte_byte (parameter, null);
        //    return  ByteOperatorByte (A, helper.divideL);
        //}
        //private static  ILArray<byte> divideR( ILArray<byte> A, byte parameter) {
        //    opbyte_byte helper = new  opbyte_byte (parameter, null);
        //    return  ByteOperatorByte (A, helper.divideR);
        //}
        private static  ILArray<byte> multiply( ILArray<byte> A, byte parameter) {
            opbyte_byte helper = new  opbyte_byte (parameter, null);
            return  ByteOperatorByte (A, helper.multiply);
		}
        private static  ILArray<byte> set( ILArray<byte> A, byte parameter) {
            opbyte_byte helper = new  opbyte_byte (parameter, null);
            return  ByteOperatorByte (A, helper.set);
		}
        private static  ILArray<byte> max( ILArray<byte> A, byte parameter) {
            opbyte_byte helper = new  opbyte_byte (parameter, null);
            return  ByteOperatorByte (A, helper.max);
        }
        private static  ILArray<byte> min( ILArray<byte> A, byte parameter) {
            opbyte_byte helper = new  opbyte_byte (parameter, null);
            return  ByteOperatorByte (A, helper.min);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART BINARY_ARRAY_FUNCTIONS
 /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
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
    <source locate="after">
        hcWalkerOpUnary
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
</type>
<type>
    <source	locate="after">
        hcWalkerOpBinary
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
<type>
    <source locate="after">
        hchelperunary 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opchar_char</destination>
    <destination>opcomplex_complex</destination>
    <destination>opfcomplex_fcomplex</destination>
    <destination>opfloat_float</destination>
    <destination>opint16_int16</destination>
    <destination>opint32_int32</destination>
    <destination>opint64_int64</destination>
    <destination>opuint16_uint16</destination>
    <destination>opuint32_uint32</destination>
    <destination>opuint64_uint64</destination>
</type>
<type>
    <source locate="after">
        hchelperbinary 
    </source>
    <destination>opbyte_bytebyte</destination>
    <destination>opchar_charchar</destination>
    <destination>opcomplex_complexcomplex</destination>
    <destination>opfcomplex_fcomplexfcomplex</destination>
    <destination>opfloat_floatfloat</destination>
    <destination>opint16_int16int16</destination>
    <destination>opint32_int32int32</destination>
    <destination>opint64_int64int64</destination>
    <destination>opuint16_uint16uint16</destination>
    <destination>opuint32_uint32uint32</destination>
    <destination>opuint64_uint64uint64</destination>
</type>
<type>
    <source locate="after">
        TpositiveINF
    </source>
    <destination>127</destination>
    <destination>(char)127</destination>
    <destination>complex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>float.PositiveInfinity</destination>
    <destination>Int16.MaxValue</destination>
    <destination>Int32.MaxValue</destination>
    <destination>Int64.MaxValue</destination>
    <destination>UInt16.MaxValue</destination>
    <destination>UInt32.MaxValue</destination>
    <destination>UInt64.MaxValue</destination>
</type>
</hycalper>
 */
        //public static ILArray</*!HC:outArr1*/ double > add(ILArray</*!HC:inArr1*/ double > Array1, ILArray</*!HC:inArr2*/ double > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray</*!HC:outArr1*/ double >(new /*!HC:outArr1*/ double [1] { (/*!HC:outArr1*/ double )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double ((/*!HC:outArr1*/ double )Array1[0, 0], null);
        //            return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array2.GetValue(0), null);
        //        return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array1, helper.add);
        //    } else {
        //        /*!HC:hchelperbinary*/ opdouble_doubledouble helper = new /*!HC:hchelperbinary*/ opdouble_doubledouble ();
        //        return /*!HC:hcWalkerOpBinary*/ DoubleOperatorDoubleDouble (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray</*!HC:outArr1*/ double > subtract(ILArray</*!HC:inArr1*/ double > Array1, ILArray</*!HC:inArr2*/ double > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray</*!HC:outArr1*/ double >(new /*!HC:outArr1*/ double [1] { (/*!HC:outArr1*/ double )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array1.GetValue(0), null);
        //            return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array2.GetValue(0), null);
        //        return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array1, helper.subtractL);
        //    } else {
        //        /*!HC:hchelperbinary*/ opdouble_doubledouble helper = new /*!HC:hchelperbinary*/ opdouble_doubledouble ();
        //        return /*!HC:hcWalkerOpBinary*/ DoubleOperatorDoubleDouble (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray</*!HC:outArr1*/ double > multiplyElements(ILArray</*!HC:inArr1*/ double > Array1, ILArray</*!HC:inArr2*/ double > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray</*!HC:outArr1*/ double >(new /*!HC:outArr1*/ double [1] { (/*!HC:outArr1*/ double )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array1.GetValue(0),null);
        //            return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array2.GetValue(0), null);
        //        return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array1, helper.multiply);
        //    } else {
        //        /*!HC:hchelperbinary*/ opdouble_doubledouble  helper = new /*!HC:hchelperbinary*/ opdouble_doubledouble ();
        //        return /*!HC:hcWalkerOpBinary*/ DoubleOperatorDoubleDouble (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray</*!HC:outArr1*/ double > divide(ILArray</*!HC:inArr1*/ double > Array1, ILArray</*!HC:inArr2*/ double > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            /*!HC:inArr2*/ double tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray</*!HC:outArr1*/ double >(new /*!HC:outArr1*/ double [1] { (/*!HC:outArr1*/ double )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray</*!HC:outArr1*/ double >(new /*!HC:outArr1*/ double [1] { /*!HC:TpositiveINF*/ double.PositiveInfinity }, 1, 1);
        //        } else {
        //            /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array1.GetValue(0), null);
        //            return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        /*!HC:hchelperunary*/ opdouble_double helper = new /*!HC:hchelperunary*/ opdouble_double (Array2.GetValue(0), null);
        //        return /*!HC:hcWalkerOpUnary*/ DoubleOperatorDouble (Array1, helper.divideL);
        //    } else {
        //        /*!HC:hchelperbinary*/ opdouble_doubledouble  helper = new /*!HC:hchelperbinary*/ opdouble_doubledouble ();
        //        return /*!HC:hcWalkerOpBinary*/ DoubleOperatorDoubleDouble (Array1, Array2, helper.divide);
        //    }
        //}
        #endregion HYCALPER LOOPEND BINARY_ARRAY_FUNCTIONS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
 
        //public static ILArray< UInt64 > add(ILArray< UInt64 > Array1, ILArray< UInt64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt64 >(new  UInt64 [1] { ( UInt64 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint64_uint64 helper = new  opuint64_uint64 (( UInt64 )Array1[0, 0], null);
        //            return  UInt64OperatorUInt64 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint64_uint64 helper = new  opuint64_uint64 (Array2.GetValue(0), null);
        //        return  UInt64OperatorUInt64 (Array1, helper.add);
        //    } else {
        //        opuint64_uint64uint64 helper = new  opuint64_uint64uint64 ();
        //        return  UInt64OperatorUInt64UInt64 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< UInt64 > subtract(ILArray< UInt64 > Array1, ILArray< UInt64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt64 >(new  UInt64 [1] { ( UInt64 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opuint64_uint64 helper = new  opuint64_uint64 (Array1.GetValue(0), null);
        //            return  UInt64OperatorUInt64 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint64_uint64 helper = new  opuint64_uint64 (Array2.GetValue(0), null);
        //        return  UInt64OperatorUInt64 (Array1, helper.subtractL);
        //    } else {
        //        opuint64_uint64uint64 helper = new  opuint64_uint64uint64 ();
        //        return  UInt64OperatorUInt64UInt64 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< UInt64 > multiplyElements(ILArray< UInt64 > Array1, ILArray< UInt64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt64 >(new  UInt64 [1] { ( UInt64 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint64_uint64 helper = new  opuint64_uint64 (Array1.GetValue(0),null);
        //            return  UInt64OperatorUInt64 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint64_uint64 helper = new  opuint64_uint64 (Array2.GetValue(0), null);
        //        return  UInt64OperatorUInt64 (Array1, helper.multiply);
        //    } else {
        //        opuint64_uint64uint64  helper = new  opuint64_uint64uint64 ();
        //        return  UInt64OperatorUInt64UInt64 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< UInt64 > divide(ILArray< UInt64 > Array1, ILArray< UInt64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            UInt64 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< UInt64 >(new  UInt64 [1] { ( UInt64 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< UInt64 >(new  UInt64 [1] {  UInt64.MaxValue }, 1, 1);
        //        } else {
        //            opuint64_uint64 helper = new  opuint64_uint64 (Array1.GetValue(0), null);
        //            return  UInt64OperatorUInt64 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint64_uint64 helper = new  opuint64_uint64 (Array2.GetValue(0), null);
        //        return  UInt64OperatorUInt64 (Array1, helper.divideL);
        //    } else {
        //        opuint64_uint64uint64  helper = new  opuint64_uint64uint64 ();
        //        return  UInt64OperatorUInt64UInt64 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< UInt32 > add(ILArray< UInt32 > Array1, ILArray< UInt32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt32 >(new  UInt32 [1] { ( UInt32 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint32_uint32 helper = new  opuint32_uint32 (( UInt32 )Array1[0, 0], null);
        //            return  UInt32OperatorUInt32 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint32_uint32 helper = new  opuint32_uint32 (Array2.GetValue(0), null);
        //        return  UInt32OperatorUInt32 (Array1, helper.add);
        //    } else {
        //        opuint32_uint32uint32 helper = new  opuint32_uint32uint32 ();
        //        return  UInt32OperatorUInt32UInt32 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< UInt32 > subtract(ILArray< UInt32 > Array1, ILArray< UInt32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt32 >(new  UInt32 [1] { ( UInt32 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opuint32_uint32 helper = new  opuint32_uint32 (Array1.GetValue(0), null);
        //            return  UInt32OperatorUInt32 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint32_uint32 helper = new  opuint32_uint32 (Array2.GetValue(0), null);
        //        return  UInt32OperatorUInt32 (Array1, helper.subtractL);
        //    } else {
        //        opuint32_uint32uint32 helper = new  opuint32_uint32uint32 ();
        //        return  UInt32OperatorUInt32UInt32 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< UInt32 > multiplyElements(ILArray< UInt32 > Array1, ILArray< UInt32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt32 >(new  UInt32 [1] { ( UInt32 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint32_uint32 helper = new  opuint32_uint32 (Array1.GetValue(0),null);
        //            return  UInt32OperatorUInt32 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint32_uint32 helper = new  opuint32_uint32 (Array2.GetValue(0), null);
        //        return  UInt32OperatorUInt32 (Array1, helper.multiply);
        //    } else {
        //        opuint32_uint32uint32  helper = new  opuint32_uint32uint32 ();
        //        return  UInt32OperatorUInt32UInt32 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< UInt32 > divide(ILArray< UInt32 > Array1, ILArray< UInt32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            UInt32 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< UInt32 >(new  UInt32 [1] { ( UInt32 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< UInt32 >(new  UInt32 [1] {  UInt32.MaxValue }, 1, 1);
        //        } else {
        //            opuint32_uint32 helper = new  opuint32_uint32 (Array1.GetValue(0), null);
        //            return  UInt32OperatorUInt32 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint32_uint32 helper = new  opuint32_uint32 (Array2.GetValue(0), null);
        //        return  UInt32OperatorUInt32 (Array1, helper.divideL);
        //    } else {
        //        opuint32_uint32uint32  helper = new  opuint32_uint32uint32 ();
        //        return  UInt32OperatorUInt32UInt32 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< UInt16 > add(ILArray< UInt16 > Array1, ILArray< UInt16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt16 >(new  UInt16 [1] { ( UInt16 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint16_uint16 helper = new  opuint16_uint16 (( UInt16 )Array1[0, 0], null);
        //            return  UInt16OperatorUInt16 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint16_uint16 helper = new  opuint16_uint16 (Array2.GetValue(0), null);
        //        return  UInt16OperatorUInt16 (Array1, helper.add);
        //    } else {
        //        opuint16_uint16uint16 helper = new  opuint16_uint16uint16 ();
        //        return  UInt16OperatorUInt16UInt16 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< UInt16 > subtract(ILArray< UInt16 > Array1, ILArray< UInt16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt16 >(new  UInt16 [1] { ( UInt16 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opuint16_uint16 helper = new  opuint16_uint16 (Array1.GetValue(0), null);
        //            return  UInt16OperatorUInt16 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint16_uint16 helper = new  opuint16_uint16 (Array2.GetValue(0), null);
        //        return  UInt16OperatorUInt16 (Array1, helper.subtractL);
        //    } else {
        //        opuint16_uint16uint16 helper = new  opuint16_uint16uint16 ();
        //        return  UInt16OperatorUInt16UInt16 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< UInt16 > multiplyElements(ILArray< UInt16 > Array1, ILArray< UInt16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< UInt16 >(new  UInt16 [1] { ( UInt16 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opuint16_uint16 helper = new  opuint16_uint16 (Array1.GetValue(0),null);
        //            return  UInt16OperatorUInt16 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint16_uint16 helper = new  opuint16_uint16 (Array2.GetValue(0), null);
        //        return  UInt16OperatorUInt16 (Array1, helper.multiply);
        //    } else {
        //        opuint16_uint16uint16  helper = new  opuint16_uint16uint16 ();
        //        return  UInt16OperatorUInt16UInt16 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< UInt16 > divide(ILArray< UInt16 > Array1, ILArray< UInt16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            UInt16 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< UInt16 >(new  UInt16 [1] { ( UInt16 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< UInt16 >(new  UInt16 [1] {  UInt16.MaxValue }, 1, 1);
        //        } else {
        //            opuint16_uint16 helper = new  opuint16_uint16 (Array1.GetValue(0), null);
        //            return  UInt16OperatorUInt16 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opuint16_uint16 helper = new  opuint16_uint16 (Array2.GetValue(0), null);
        //        return  UInt16OperatorUInt16 (Array1, helper.divideL);
        //    } else {
        //        opuint16_uint16uint16  helper = new  opuint16_uint16uint16 ();
        //        return  UInt16OperatorUInt16UInt16 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< Int64 > add(ILArray< Int64 > Array1, ILArray< Int64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int64 >(new  Int64 [1] { ( Int64 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint64_int64 helper = new  opint64_int64 (( Int64 )Array1[0, 0], null);
        //            return  Int64OperatorInt64 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint64_int64 helper = new  opint64_int64 (Array2.GetValue(0), null);
        //        return  Int64OperatorInt64 (Array1, helper.add);
        //    } else {
        //        opint64_int64int64 helper = new  opint64_int64int64 ();
        //        return  Int64OperatorInt64Int64 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< Int64 > subtract(ILArray< Int64 > Array1, ILArray< Int64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int64 >(new  Int64 [1] { ( Int64 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opint64_int64 helper = new  opint64_int64 (Array1.GetValue(0), null);
        //            return  Int64OperatorInt64 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint64_int64 helper = new  opint64_int64 (Array2.GetValue(0), null);
        //        return  Int64OperatorInt64 (Array1, helper.subtractL);
        //    } else {
        //        opint64_int64int64 helper = new  opint64_int64int64 ();
        //        return  Int64OperatorInt64Int64 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< Int64 > multiplyElements(ILArray< Int64 > Array1, ILArray< Int64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int64 >(new  Int64 [1] { ( Int64 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint64_int64 helper = new  opint64_int64 (Array1.GetValue(0),null);
        //            return  Int64OperatorInt64 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint64_int64 helper = new  opint64_int64 (Array2.GetValue(0), null);
        //        return  Int64OperatorInt64 (Array1, helper.multiply);
        //    } else {
        //        opint64_int64int64  helper = new  opint64_int64int64 ();
        //        return  Int64OperatorInt64Int64 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< Int64 > divide(ILArray< Int64 > Array1, ILArray< Int64 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            Int64 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< Int64 >(new  Int64 [1] { ( Int64 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< Int64 >(new  Int64 [1] {  Int64.MaxValue }, 1, 1);
        //        } else {
        //            opint64_int64 helper = new  opint64_int64 (Array1.GetValue(0), null);
        //            return  Int64OperatorInt64 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint64_int64 helper = new  opint64_int64 (Array2.GetValue(0), null);
        //        return  Int64OperatorInt64 (Array1, helper.divideL);
        //    } else {
        //        opint64_int64int64  helper = new  opint64_int64int64 ();
        //        return  Int64OperatorInt64Int64 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< Int32 > add(ILArray< Int32 > Array1, ILArray< Int32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int32 >(new  Int32 [1] { ( Int32 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint32_int32 helper = new  opint32_int32 (( Int32 )Array1[0, 0], null);
        //            return  Int32OperatorInt32 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint32_int32 helper = new  opint32_int32 (Array2.GetValue(0), null);
        //        return  Int32OperatorInt32 (Array1, helper.add);
        //    } else {
        //        opint32_int32int32 helper = new  opint32_int32int32 ();
        //        return  Int32OperatorInt32Int32 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< Int32 > subtract(ILArray< Int32 > Array1, ILArray< Int32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int32 >(new  Int32 [1] { ( Int32 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opint32_int32 helper = new  opint32_int32 (Array1.GetValue(0), null);
        //            return  Int32OperatorInt32 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint32_int32 helper = new  opint32_int32 (Array2.GetValue(0), null);
        //        return  Int32OperatorInt32 (Array1, helper.subtractL);
        //    } else {
        //        opint32_int32int32 helper = new  opint32_int32int32 ();
        //        return  Int32OperatorInt32Int32 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< Int32 > multiplyElements(ILArray< Int32 > Array1, ILArray< Int32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int32 >(new  Int32 [1] { ( Int32 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint32_int32 helper = new  opint32_int32 (Array1.GetValue(0),null);
        //            return  Int32OperatorInt32 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint32_int32 helper = new  opint32_int32 (Array2.GetValue(0), null);
        //        return  Int32OperatorInt32 (Array1, helper.multiply);
        //    } else {
        //        opint32_int32int32  helper = new  opint32_int32int32 ();
        //        return  Int32OperatorInt32Int32 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< Int32 > divide(ILArray< Int32 > Array1, ILArray< Int32 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            Int32 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< Int32 >(new  Int32 [1] { ( Int32 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< Int32 >(new  Int32 [1] {  Int32.MaxValue }, 1, 1);
        //        } else {
        //            opint32_int32 helper = new  opint32_int32 (Array1.GetValue(0), null);
        //            return  Int32OperatorInt32 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint32_int32 helper = new  opint32_int32 (Array2.GetValue(0), null);
        //        return  Int32OperatorInt32 (Array1, helper.divideL);
        //    } else {
        //        opint32_int32int32  helper = new  opint32_int32int32 ();
        //        return  Int32OperatorInt32Int32 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< Int16 > add(ILArray< Int16 > Array1, ILArray< Int16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int16 >(new  Int16 [1] { ( Int16 )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint16_int16 helper = new  opint16_int16 (( Int16 )Array1[0, 0], null);
        //            return  Int16OperatorInt16 (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint16_int16 helper = new  opint16_int16 (Array2.GetValue(0), null);
        //        return  Int16OperatorInt16 (Array1, helper.add);
        //    } else {
        //        opint16_int16int16 helper = new  opint16_int16int16 ();
        //        return  Int16OperatorInt16Int16 (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< Int16 > subtract(ILArray< Int16 > Array1, ILArray< Int16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int16 >(new  Int16 [1] { ( Int16 )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opint16_int16 helper = new  opint16_int16 (Array1.GetValue(0), null);
        //            return  Int16OperatorInt16 (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint16_int16 helper = new  opint16_int16 (Array2.GetValue(0), null);
        //        return  Int16OperatorInt16 (Array1, helper.subtractL);
        //    } else {
        //        opint16_int16int16 helper = new  opint16_int16int16 ();
        //        return  Int16OperatorInt16Int16 (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< Int16 > multiplyElements(ILArray< Int16 > Array1, ILArray< Int16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< Int16 >(new  Int16 [1] { ( Int16 )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opint16_int16 helper = new  opint16_int16 (Array1.GetValue(0),null);
        //            return  Int16OperatorInt16 (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint16_int16 helper = new  opint16_int16 (Array2.GetValue(0), null);
        //        return  Int16OperatorInt16 (Array1, helper.multiply);
        //    } else {
        //        opint16_int16int16  helper = new  opint16_int16int16 ();
        //        return  Int16OperatorInt16Int16 (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< Int16 > divide(ILArray< Int16 > Array1, ILArray< Int16 > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            Int16 tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< Int16 >(new  Int16 [1] { ( Int16 )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< Int16 >(new  Int16 [1] {  Int16.MaxValue }, 1, 1);
        //        } else {
        //            opint16_int16 helper = new  opint16_int16 (Array1.GetValue(0), null);
        //            return  Int16OperatorInt16 (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opint16_int16 helper = new  opint16_int16 (Array2.GetValue(0), null);
        //        return  Int16OperatorInt16 (Array1, helper.divideL);
        //    } else {
        //        opint16_int16int16  helper = new  opint16_int16int16 ();
        //        return  Int16OperatorInt16Int16 (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< float > add(ILArray< float > Array1, ILArray< float > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< float >(new  float [1] { ( float )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opfloat_float helper = new  opfloat_float (( float )Array1[0, 0], null);
        //            return  FloatOperatorFloat (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfloat_float helper = new  opfloat_float (Array2.GetValue(0), null);
        //        return  FloatOperatorFloat (Array1, helper.add);
        //    } else {
        //        opfloat_floatfloat helper = new  opfloat_floatfloat ();
        //        return  FloatOperatorFloatFloat (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< float > subtract(ILArray< float > Array1, ILArray< float > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< float >(new  float [1] { ( float )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opfloat_float helper = new  opfloat_float (Array1.GetValue(0), null);
        //            return  FloatOperatorFloat (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfloat_float helper = new  opfloat_float (Array2.GetValue(0), null);
        //        return  FloatOperatorFloat (Array1, helper.subtractL);
        //    } else {
        //        opfloat_floatfloat helper = new  opfloat_floatfloat ();
        //        return  FloatOperatorFloatFloat (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< float > multiplyElements(ILArray< float > Array1, ILArray< float > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< float >(new  float [1] { ( float )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opfloat_float helper = new  opfloat_float (Array1.GetValue(0),null);
        //            return  FloatOperatorFloat (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfloat_float helper = new  opfloat_float (Array2.GetValue(0), null);
        //        return  FloatOperatorFloat (Array1, helper.multiply);
        //    } else {
        //        opfloat_floatfloat  helper = new  opfloat_floatfloat ();
        //        return  FloatOperatorFloatFloat (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< float > divide(ILArray< float > Array1, ILArray< float > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            float tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< float >(new  float [1] { ( float )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< float >(new  float [1] {  float.PositiveInfinity }, 1, 1);
        //        } else {
        //            opfloat_float helper = new  opfloat_float (Array1.GetValue(0), null);
        //            return  FloatOperatorFloat (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfloat_float helper = new  opfloat_float (Array2.GetValue(0), null);
        //        return  FloatOperatorFloat (Array1, helper.divideL);
        //    } else {
        //        opfloat_floatfloat  helper = new  opfloat_floatfloat ();
        //        return  FloatOperatorFloatFloat (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< fcomplex > add(ILArray< fcomplex > Array1, ILArray< fcomplex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< fcomplex >(new  fcomplex [1] { ( fcomplex )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (( fcomplex )Array1[0, 0], null);
        //            return  FcomplexOperatorFcomplex (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array2.GetValue(0), null);
        //        return  FcomplexOperatorFcomplex (Array1, helper.add);
        //    } else {
        //        opfcomplex_fcomplexfcomplex helper = new  opfcomplex_fcomplexfcomplex ();
        //        return  FcomplexOperatorFcomplexFcomplex (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< fcomplex > subtract(ILArray< fcomplex > Array1, ILArray< fcomplex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< fcomplex >(new  fcomplex [1] { ( fcomplex )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array1.GetValue(0), null);
        //            return  FcomplexOperatorFcomplex (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array2.GetValue(0), null);
        //        return  FcomplexOperatorFcomplex (Array1, helper.subtractL);
        //    } else {
        //        opfcomplex_fcomplexfcomplex helper = new  opfcomplex_fcomplexfcomplex ();
        //        return  FcomplexOperatorFcomplexFcomplex (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< fcomplex > multiplyElements(ILArray< fcomplex > Array1, ILArray< fcomplex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< fcomplex >(new  fcomplex [1] { ( fcomplex )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array1.GetValue(0),null);
        //            return  FcomplexOperatorFcomplex (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array2.GetValue(0), null);
        //        return  FcomplexOperatorFcomplex (Array1, helper.multiply);
        //    } else {
        //        opfcomplex_fcomplexfcomplex  helper = new  opfcomplex_fcomplexfcomplex ();
        //        return  FcomplexOperatorFcomplexFcomplex (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< fcomplex > divide(ILArray< fcomplex > Array1, ILArray< fcomplex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            fcomplex tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< fcomplex >(new  fcomplex [1] { ( fcomplex )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< fcomplex >(new  fcomplex [1] {  fcomplex.INF }, 1, 1);
        //        } else {
        //            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array1.GetValue(0), null);
        //            return  FcomplexOperatorFcomplex (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opfcomplex_fcomplex helper = new  opfcomplex_fcomplex (Array2.GetValue(0), null);
        //        return  FcomplexOperatorFcomplex (Array1, helper.divideL);
        //    } else {
        //        opfcomplex_fcomplexfcomplex  helper = new  opfcomplex_fcomplexfcomplex ();
        //        return  FcomplexOperatorFcomplexFcomplex (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< complex > add(ILArray< complex > Array1, ILArray< complex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< complex >(new  complex [1] { ( complex )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opcomplex_complex helper = new  opcomplex_complex (( complex )Array1[0, 0], null);
        //            return  ComplexOperatorComplex (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opcomplex_complex helper = new  opcomplex_complex (Array2.GetValue(0), null);
        //        return  ComplexOperatorComplex (Array1, helper.add);
        //    } else {
        //        opcomplex_complexcomplex helper = new  opcomplex_complexcomplex ();
        //        return  ComplexOperatorComplexComplex (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< complex > subtract(ILArray< complex > Array1, ILArray< complex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< complex >(new  complex [1] { ( complex )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opcomplex_complex helper = new  opcomplex_complex (Array1.GetValue(0), null);
        //            return  ComplexOperatorComplex (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opcomplex_complex helper = new  opcomplex_complex (Array2.GetValue(0), null);
        //        return  ComplexOperatorComplex (Array1, helper.subtractL);
        //    } else {
        //        opcomplex_complexcomplex helper = new  opcomplex_complexcomplex ();
        //        return  ComplexOperatorComplexComplex (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< complex > multiplyElements(ILArray< complex > Array1, ILArray< complex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< complex >(new  complex [1] { ( complex )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opcomplex_complex helper = new  opcomplex_complex (Array1.GetValue(0),null);
        //            return  ComplexOperatorComplex (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opcomplex_complex helper = new  opcomplex_complex (Array2.GetValue(0), null);
        //        return  ComplexOperatorComplex (Array1, helper.multiply);
        //    } else {
        //        opcomplex_complexcomplex  helper = new  opcomplex_complexcomplex ();
        //        return  ComplexOperatorComplexComplex (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< complex > divide(ILArray< complex > Array1, ILArray< complex > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            complex tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< complex >(new  complex [1] { ( complex )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< complex >(new  complex [1] {  complex.INF }, 1, 1);
        //        } else {
        //            opcomplex_complex helper = new  opcomplex_complex (Array1.GetValue(0), null);
        //            return  ComplexOperatorComplex (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opcomplex_complex helper = new  opcomplex_complex (Array2.GetValue(0), null);
        //        return  ComplexOperatorComplex (Array1, helper.divideL);
        //    } else {
        //        opcomplex_complexcomplex  helper = new  opcomplex_complexcomplex ();
        //        return  ComplexOperatorComplexComplex (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< char > add(ILArray< char > Array1, ILArray< char > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< char >(new  char [1] { ( char )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opchar_char helper = new  opchar_char (( char )Array1[0, 0], null);
        //            return  CharOperatorChar (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opchar_char helper = new  opchar_char (Array2.GetValue(0), null);
        //        return  CharOperatorChar (Array1, helper.add);
        //    } else {
        //        opchar_charchar helper = new  opchar_charchar ();
        //        return  CharOperatorCharChar (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< char > subtract(ILArray< char > Array1, ILArray< char > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< char >(new  char [1] { ( char )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opchar_char helper = new  opchar_char (Array1.GetValue(0), null);
        //            return  CharOperatorChar (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opchar_char helper = new  opchar_char (Array2.GetValue(0), null);
        //        return  CharOperatorChar (Array1, helper.subtractL);
        //    } else {
        //        opchar_charchar helper = new  opchar_charchar ();
        //        return  CharOperatorCharChar (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< char > multiplyElements(ILArray< char > Array1, ILArray< char > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< char >(new  char [1] { ( char )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opchar_char helper = new  opchar_char (Array1.GetValue(0),null);
        //            return  CharOperatorChar (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opchar_char helper = new  opchar_char (Array2.GetValue(0), null);
        //        return  CharOperatorChar (Array1, helper.multiply);
        //    } else {
        //        opchar_charchar  helper = new  opchar_charchar ();
        //        return  CharOperatorCharChar (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< char > divide(ILArray< char > Array1, ILArray< char > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            char tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< char >(new  char [1] { ( char )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< char >(new  char [1] {  (char)127 }, 1, 1);
        //        } else {
        //            opchar_char helper = new  opchar_char (Array1.GetValue(0), null);
        //            return  CharOperatorChar (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opchar_char helper = new  opchar_char (Array2.GetValue(0), null);
        //        return  CharOperatorChar (Array1, helper.divideL);
        //    } else {
        //        opchar_charchar  helper = new  opchar_charchar ();
        //        return  CharOperatorCharChar (Array1, Array2, helper.divide);
        //    }
        //}
 
        //public static ILArray< byte > add(ILArray< byte > Array1, ILArray< byte > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< byte >(new  byte [1] { ( byte )(Array1.GetValue(0) + Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opbyte_byte helper = new  opbyte_byte (( byte )Array1[0, 0], null);
        //            return  ByteOperatorByte (Array2, helper.add);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opbyte_byte helper = new  opbyte_byte (Array2.GetValue(0), null);
        //        return  ByteOperatorByte (Array1, helper.add);
        //    } else {
        //        opbyte_bytebyte helper = new  opbyte_bytebyte ();
        //        return  ByteOperatorByteByte (Array1, Array2, helper.add);
        //    }
        //}
        //public static ILArray< byte > subtract(ILArray< byte > Array1, ILArray< byte > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< byte >(new  byte [1] { ( byte )(Array1.GetValue(0) - Array2.GetValue(0))}, 1, 1);
        //        else {
        //            opbyte_byte helper = new  opbyte_byte (Array1.GetValue(0), null);
        //            return  ByteOperatorByte (Array2, helper.subtractR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opbyte_byte helper = new  opbyte_byte (Array2.GetValue(0), null);
        //        return  ByteOperatorByte (Array1, helper.subtractL);
        //    } else {
        //        opbyte_bytebyte helper = new  opbyte_bytebyte ();
        //        return  ByteOperatorByteByte (Array1, Array2, helper.subtract);
        //    }
        //}
        //public static ILArray< byte > multiplyElements(ILArray< byte > Array1, ILArray< byte > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar)
        //            return new ILArray< byte >(new  byte [1] { ( byte )(Array1.GetValue(0) * Array2.GetValue(0)) }, 1, 1);
        //        else {
        //            opbyte_byte helper = new  opbyte_byte (Array1.GetValue(0),null);
        //            return  ByteOperatorByte (Array2, helper.multiply);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opbyte_byte helper = new  opbyte_byte (Array2.GetValue(0), null);
        //        return  ByteOperatorByte (Array1, helper.multiply);
        //    } else {
        //        opbyte_bytebyte  helper = new  opbyte_bytebyte ();
        //        return  ByteOperatorByteByte (Array1, Array2, helper.multiply);
        //    }
        //}
        //public static ILArray< byte > divide(ILArray< byte > Array1, ILArray< byte > Array2) {
        //    if (Array1.IsScalar) {
        //        if (Array2.IsScalar) {
        //            byte tmp = Array2.GetValue(0);
        //            if (tmp != 0)
        //                return new ILArray< byte >(new  byte [1] { ( byte )(Array1.GetValue(0) / tmp) }, 1, 1);
        //            else
        //                return new ILArray< byte >(new  byte [1] {  127 }, 1, 1);
        //        } else {
        //            opbyte_byte helper = new  opbyte_byte (Array1.GetValue(0), null);
        //            return  ByteOperatorByte (Array2, helper.divideR);
        //        }
        //    } else if (Array2.IsScalar) {
        //        opbyte_byte helper = new  opbyte_byte (Array2.GetValue(0), null);
        //        return  ByteOperatorByte (Array1, helper.divideL);
        //    } else {
        //        opbyte_bytebyte  helper = new  opbyte_bytebyte ();
        //        return  ByteOperatorByteByte (Array1, Array2, helper.divide);
        //    }
        //}

#endregion HYCALPER AUTO GENERATED CODE

    }
}
