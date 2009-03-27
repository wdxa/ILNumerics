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
        outCls1
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
        inArrSkalar
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        out1ArrCast
    </source>
    <destination>(byte)</destination>
    <destination>(complex)</destination>
</type>
<type>
    <source locate="after">
        cls2Name 
    </source>
    <destination>opbyte_bytebyte</destination>
    <destination>opcomplex_complexcomplex</destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opcomplex_complex</destination>
</type>
<type>
    <source locate="after">
        delegate_binary
    </source>
    <destination>ILByteFunctionByteByte</destination>
    <destination>ILComplexFunctionComplexComplex</destination>
</type>
<type>
    <source locate="after">
        delegate_unary
    </source>
    <destination>ILByteFunctionByte</destination>
    <destination>ILComplexFunctionComplex</destination>
</type>
<type>
    <source locate="after">
        unaryop
    </source>
    <destination>ByteUnaryByteOperator</destination>
    <destination>ComplexUnaryComplexOperator</destination>
</type>
<type>
    <source locate="after">
        TpositiveINF
    </source>
    <destination>127</destination>
    <destination>complex.INF</destination>
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
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>double</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        delegate_unary
    </source>
    <destination>ILByteFunctionByte</destination>
    <destination>ILComplexFunctionComplex</destination>
    <destination>ILDoubleFunctionComplex</destination>
    <destination>ILComplexFunctionDouble</destination>
</type>
</hycalper>
 */
        private delegate /*!HC:outArr1*/ double /*!HC:delegate_unary*/ ILDoubleFunctionDouble (/*!HC:inArr1*/ double in1);
        #endregion HYCALPER LOOPEND INNERFUNCTION:DELEGATES_UNARY
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        private delegate  complex  ILComplexFunctionDouble ( double in1);
       
        private delegate  double  ILDoubleFunctionComplex ( complex in1);
       
        private delegate  complex  ILComplexFunctionComplex ( complex in1);
       
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
    <destination>complex</destination>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        delegate_binary
    </source>
    <destination>ILByteFunctionByteByte</destination>
    <destination>ILComplexFunctionComplexComplex</destination>
    <destination>ILComplexFunctionDoubleDouble</destination>
</type>
</hycalper>
 */
        private delegate /*!HC:outArr1*/ double /*!HC:delegate_binary*/ ILDoubleFunctionDoubleDouble (/*!HC:inArr1*/ double in1,/*!HC:inArr2*/ double in2);
        #endregion HYCALPER LOOPEND INNERFUNCTION:DELEGATES
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        private delegate  complex  ILComplexFunctionDoubleDouble ( double in1, double in2);
       
        private delegate  complex  ILComplexFunctionComplexComplex ( complex in1, complex in2);
       
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

        #region HYCALPER LOOPSTART BINARY_SKALAR_FUNCTIONS
 /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArrSkalar
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
        outCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
</type>
<type>
    <source locate="after">
        hcwalkerop
    </source>
    <destination>ByteOperatorByte</destination>
    <destination>ComplexOperatorComplex</destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opcomplex_complex</destination>
</type>
</hycalper>
 */
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
    }
}
