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

#pragma warning disable 162 
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ILNumerics.BuiltInFunctions; 
/*!HC:TYPELIST:
<hycalper>
</hycalper>
 */

namespace ILNumerics {
    /// <summary>
    /// floating point complex value data type of double precision
    /// </summary>
    /// <remarks>This class extends the system value types for real numbers to complex double 
    /// values. Besides the publicly available members 'real' and 'imag' it provides all the 
    /// basis functionality the floating point system.double brings (abs, log, sqrt, tan etc.),
    /// as well as it overrides the basic unary and binary operators for all common system value 
    /// types including rarely used types (f.e. UInt16). This includes the basic numerical operations 
    /// like '+','-','/','*' and the relational operators: '==','>','>=' etc. Also there are some 
    /// explicit and some implicit casting operators from / to complex value into system 
    /// value types.</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct complex {
        /// <summary>
        /// Real part of this complex number
        /// </summary>
        public double real;
        /// <summary>
        /// Imaginary part of this complex number
        /// </summary>
        public double imag;
        /// <summary>
        /// imaginary unit 
        /// </summary>
        public static readonly complex i = new complex(0.0f,1.0f); 

        /// <summary>
        /// Constructor creating a new complex value
        /// </summary>
        /// <param name="real">real part</param>
        /// <param name="imag">imagginary part</param>
        public complex(double real, double imag) {
            this.real = real; 
            this.imag = imag; 
        }
        /// <summary>
        /// complex conjugate 
        /// </summary>
        public complex conj {
            get{
                return new complex(real,-imag);
            }
        }

        /// <summary>
        /// positive infinity for real and imag part of complex value
        /// </summary>
       public static complex INF {
            get {
                return new complex(
                    double.PositiveInfinity,
                    double.PositiveInfinity
                );
            }
        }

        /// <summary>
        /// complex quantity, marked as beeing "not a number"
        /// </summary>
        public static complex NaN {
            get {
                return new complex(double.NaN,double.NaN); 
            }
        }

        /// <summary>
        /// are obj's real and imaginary part identical to the real and imaginary parts of this fcomplex
        /// </summary>
        /// <param name="obj">fcomplex object to determine the equality for</param>
        /// <returns>true if obj is of fcomplex type and its real and imag part has the same 
        /// values as the real and imaginary part of this array.</returns>
        public override bool Equals(object obj) {
            if (obj is complex && ((complex)obj) == this)
                return true; 
            return false; 
        }

        /// <summary>
        /// Hash code of this system object
        /// </summary>
        /// <returns>Hash code of this system object</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #region HYCALPER LOOPSTART OPERATORS_complex+complex
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr1 
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr2
    </source>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        FCast
    </source>
    <destination>(double)</destination>
</type>
<type>
    <source locate="after">
        infinity
    </source>
    <destination>complex.INF</destination>
</type>
<type>
    <source locate="after">
        TRret
    </source>
    <destination>double</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static /*!HC:Tret*/ complex operator +(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret; 
             ret.real =  /*!HC:FCast*/ (double) (in1.real + in2.real );
             ret.imag =  /*!HC:FCast*/ (double) (in1.imag + in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static /*!HC:Tret*/ complex operator -(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret; 
            ret.real = /*!HC:FCast*/ (double) (in1.real  - in2.real );
            ret.imag = /*!HC:FCast*/ (double) (in1.imag - in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static /*!HC:Tret*/ complex operator *(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) ((in1.real * in2.real ) - (in1.imag * in2.imag ));
            ret.imag = /*!HC:FCast*/ (double) ((in1.real * in2.imag ) + (in1.imag * in2.real ));
            return ret; 
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        /// <remarks><para>Unless the operator must handle special inputs (Inf or 0 values), 
        /// the algorithm described in [1] is used for division. This is considered to be 
        /// more robust against floating point overflow than the naive approach of simple 
        /// cartesian division.</para>
        /// <para>References: [1]: Smith, R.L., Algorithm 116: Complex division. Commun.ACM 5,8 (1962),435 <br />
        /// [2]: Stewart, G.W., A note on complex division, ACM trans.on math software, Vol.11, N.3 (1985)</para></remarks>
        public static /*!HC:Tret*/ complex operator /(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (/*!HC:TinArr2*/ complex .IsInfinity(in2)) return NaN;
                else return (/*!HC:Tret*/ complex )0;
            } else {
                if (/*!HC:TinArr2*/ complex .IsInfinity(in2)) return (/*!HC:Tret*/ complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF; 
            }
            /*!HC:Tret*/ complex ret;
            // this would be the naive approach. But it come with to little robustness against overflow
            //double norm2 = in2.real * in2.real + in2.imag * in2.imag;
            //if (norm2 == 0) return INF;    // this may be removed, since division by 0 results in inf anyway ? 
            //ret.real = /*!HC:FCast*/ (double) (((in1.real  * in2.real ) + (in1.imag  * in2.imag )) / norm2);
            //ret.imag = /*!HC:FCast*/ (double) (((in1.imag  * in2.real ) - (in1.real  * in2.imag )) / norm2); 
            
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            /*!HC:TRret*/ double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp = /*!HC:FCast*/ (double) (in2.imag * (1/in2.real)); 
                ret.imag = /*!HC:FCast*/ (double) (in2.real + in2.imag*tmp); 
                ret.real = /*!HC:FCast*/ (double) (in1.real + in1.imag*tmp)/ret.imag; 
                ret.imag = /*!HC:FCast*/ (double) (in1.imag - in1.real*tmp)/ret.imag; 
            } else {
                tmp = /*!HC:FCast*/ (double) (in2.real * (1/in2.imag));
                ret.imag = /*!HC:FCast*/ (double) (in2.imag + in2.real*tmp); 
                ret.real = /*!HC:FCast*/ (double) (in1.imag + in1.real*tmp)/ret.imag; 
                ret.imag = - /*!HC:FCast*/ (double) (in1.real - in1.imag*tmp)/ret.imag; 
            }
            return ret;                                            
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.imag  == in2.imag ) && (in1.real  == in2.real );
        }

        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.imag  != in2.imag ) || (in1.real  != in2.real );
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > (/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.real > in2.real );
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < (/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.real < in2.real );
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.real >= in2.real );
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ complex in2) {
            return (in1.real <= in2.real );
        }
        #endregion HYCALPER LOOPEND OPERATOR_complex+complex
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  fcomplex in2) {
            complex ret; 
             ret.real =  (double) (in1.real + in2.real );
             ret.imag =  (double) (in1.imag + in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  fcomplex in2) {
            complex ret; 
            ret.real =  (double) (in1.real  - in2.real );
            ret.imag =  (double) (in1.imag - in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  fcomplex in2) {
            complex ret;
            ret.real =  (double) ((in1.real * in2.real ) - (in1.imag * in2.imag ));
            ret.imag =  (double) ((in1.real * in2.imag ) + (in1.imag * in2.real ));
            return ret; 
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        /// <remarks><para>Unless the operator must handle special inputs (Inf or 0 values), 
        /// the algorithm described in [1] is used for division. This is considered to be 
        /// more robust against floating point overflow than the naive approach of simple 
        /// cartesian division.</para>
        /// <para>References: [1]: Smith, R.L., Algorithm 116: Complex division. Commun.ACM 5,8 (1962),435 <br />
        /// [2]: Stewart, G.W., A note on complex division, ACM trans.on math software, Vol.11, N.3 (1985)</para></remarks>
        public static  complex operator /( complex in1,  fcomplex in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if ( fcomplex .IsInfinity(in2)) return NaN;
                else return ( complex )0;
            } else {
                if ( fcomplex .IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF; 
            }
            complex ret;
            // this would be the naive approach. But it come with to little robustness against overflow
            //double norm2 = in2.real * in2.real + in2.imag * in2.imag;
            //if (norm2 == 0) return INF;    // this may be removed, since division by 0 results in inf anyway ? 
            //ret.real =  (double) (((in1.real  * in2.real ) + (in1.imag  * in2.imag )) / norm2);
            //ret.imag =  (double) (((in1.imag  * in2.real ) - (in1.real  * in2.imag )) / norm2); 
            
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) (in1.real + in1.imag*tmp)/ret.imag; 
                ret.imag =  (double) (in1.imag - in1.real*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1.imag + in1.real*tmp)/ret.imag; 
                ret.imag = -  (double) (in1.real - in1.imag*tmp)/ret.imag; 
            }
            return ret;                                            
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  fcomplex in2) {
            return (in1.imag  == in2.imag ) && (in1.real  == in2.real );
        }

        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  fcomplex in2) {
            return (in1.imag  != in2.imag ) || (in1.real  != in2.real );
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  fcomplex in2) {
            return (in1.real > in2.real );
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( complex in1,  fcomplex in2) {
            return (in1.real < in2.real );
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  fcomplex in2) {
            return (in1.real >= in2.real );
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  fcomplex in2) {
            return (in1.real <= in2.real );
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART OPERATORS_complex+noncomplex
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr1 
    </source>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr2
    </source>
    <destination>byte</destination>
    <destination>char</destination>
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
        FCast
    </source>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
</type>
<type>
    <source locate="after">
        infinity
    </source>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
</type>
<type>
    <source locate="nextline">
        test4inf
    </source>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
    <destination>if (float.IsInfinity(in2))</destination>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
    <destination>if (false)</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static /*!HC:Tret*/ complex operator +(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) (in1.real + in2);
            ret.imag = /*!HC:FCast*/ (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static /*!HC:Tret*/ complex operator -(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) (in1.real - in2);
            ret.imag = /*!HC:FCast*/ (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static /*!HC:Tret*/ complex operator *(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) (in1.real * in2);
            ret.imag = /*!HC:FCast*/ (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static /*!HC:Tret*/ complex operator /(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            if (in1.real == 0 && in1.imag == 0) {
                /*!HC:test4inf*/ 
                if (double.IsInfinity(in2)) 
                    return NaN; 
                else return (/*!HC:Tret*/ complex )0;
            } else {
                /*!HC:test4inf*/ 
                if (double.IsInfinity(in2)) 
                    return (/*!HC:Tret*/ complex )0;
            }
            if (in2 == 0) return INF; 
            /*!HC:Tret*/ complex ret;
            if (in2 == 0.0) return INF ;
            ret.real = /*!HC:FCast*/ (double) (in1.real / in2);
            ret.imag = /*!HC:FCast*/ (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > (/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <( /*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=(/*!HC:TinArr1*/ complex in1, /*!HC:TinArr2*/ double in2) {
            return (in1.real <= in2);
        }
        #endregion HYCALPER LOOPEND OPERATOR_complex+noncomplex
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  UInt64 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  UInt64 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  UInt64 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  UInt64 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  UInt64 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  UInt64 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  UInt64 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  UInt64 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  UInt64 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  UInt64 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  UInt32 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  UInt32 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  UInt32 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  UInt32 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  UInt32 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  UInt32 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  UInt32 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  UInt32 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  UInt32 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  UInt32 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  UInt16 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  UInt16 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  UInt16 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  UInt16 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  UInt16 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  UInt16 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  UInt16 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  UInt16 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  UInt16 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  UInt16 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  Int64 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  Int64 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  Int64 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  Int64 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  Int64 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  Int64 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  Int64 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  Int64 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  Int64 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  Int64 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  Int32 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  Int32 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  Int32 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  Int32 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  Int32 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  Int32 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  Int32 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  Int32 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  Int32 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  Int32 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  Int16 in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  Int16 in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  Int16 in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  Int16 in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  Int16 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  Int16 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  Int16 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  Int16 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  Int16 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  Int16 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  float in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  float in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  float in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  float in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (float.IsInfinity(in2))
                    return NaN; 
                else return ( complex )0;
            } else {
                if (float.IsInfinity(in2))
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  float in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  float in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  float in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  float in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  float in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  float in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  char in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  char in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  char in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  char in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  char in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  char in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  char in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  char in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  char in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  char in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( complex in1,  byte in2) {
            complex ret;
            ret.real =  (double) (in1.real + in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( complex in1,  byte in2) {
            complex ret;
            ret.real =  (double) (in1.real - in2);
            ret.imag =  (double) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( complex in1,  byte in2) {
            complex ret;
            ret.real =  (double) (in1.real * in2);
            ret.imag =  (double) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( complex in1,  byte in2) {
            if (in1.real == 0 && in1.imag == 0) {
                if (false)
                    return NaN; 
                else return ( complex )0;
            } else {
                if (false)
                    return ( complex )0;
            }
            if (in2 == 0) return INF; 
            complex ret;
            if (in2 == 0.0) return INF ;
            ret.real =  (double) (in1.real / in2);
            ret.imag =  (double) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( complex in1,  byte in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( complex in1,  byte in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( complex in1,  byte in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  complex in1,  byte in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( complex in1,  byte in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( complex in1,  byte in2) {
            return (in1.real <= in2);
        }

#endregion HYCALPER AUTO GENERATED CODE
       
        #region HYCALPER LOOPSTART OPERATORS_noncomplex+complex
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr2 
    </source>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        TinArr1
    </source>
    <destination>byte</destination>
    <destination>char</destination>
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
        FCast
    </source>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
    <destination>(double)</destination>
</type>
<type>
    <source locate="after">
        infinity
    </source>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
    <destination>complex.INF</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static /*!HC:Tret*/ complex operator +(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret; 
            ret.real = /*!HC:FCast*/ (double) (in1 + in2.real);
            ret.imag = /*!HC:FCast*/ (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static /*!HC:Tret*/ complex operator -(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) (in1 - in2.real);
            ret.imag = /*!HC:FCast*/ (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static /*!HC:Tret*/ complex operator *(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret;
            ret.real = /*!HC:FCast*/ (double) (in1 * in2.real);
            ret.imag = /*!HC:FCast*/ (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static /*!HC:Tret*/ complex operator /(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            /*!HC:Tret*/ complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return (/*!HC:Tret*/ complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            /*!HC:TRret*/ double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp = /*!HC:FCast*/ (double) (in2.imag * (1/in2.real)); 
                ret.imag = /*!HC:FCast*/ (double) (in2.real + in2.imag*tmp); 
                ret.real = /*!HC:FCast*/ (double) in1/ret.imag; 
                ret.imag = /*!HC:FCast*/ (double) (in1*tmp)/ret.imag; 
            } else {
                tmp = /*!HC:FCast*/ (double) (in2.real * (1/in2.imag));
                ret.imag = /*!HC:FCast*/ (double) (in2.imag + in2.real*tmp); 
                ret.real = /*!HC:FCast*/ (double) (in1*tmp)/ret.imag; 
                ret.imag = /*!HC:FCast*/ (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > (/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < (/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=(/*!HC:TinArr1*/ double in1, /*!HC:TinArr2*/ complex in2) {
            return (in1 <= in2.real);
        }
        #endregion HYCALPER LOOPEND OPERATOR_noncomplex+complex
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( UInt64 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( UInt64 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( UInt64 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( UInt64 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt64 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt64 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt64 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt64 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt64 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt64 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( UInt32 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( UInt32 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( UInt32 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( UInt32 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt32 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt32 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt32 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt32 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt32 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt32 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( UInt16 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( UInt16 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( UInt16 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( UInt16 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt16 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt16 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt16 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt16 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt16 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt16 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( Int64 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( Int64 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( Int64 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( Int64 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int64 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int64 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int64 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int64 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int64 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int64 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( Int32 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( Int32 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( Int32 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( Int32 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int32 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int32 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int32 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int32 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int32 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int32 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( Int16 in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( Int16 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( Int16 in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( Int16 in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int16 in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int16 in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int16 in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int16 in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int16 in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int16 in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( float in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( float in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( float in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( float in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( float in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( float in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( float in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( float in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( float in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( float in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( char in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( char in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( char in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( char in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( char in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( char in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( char in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( char in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( char in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( char in1,  complex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  complex operator +( byte in1,  complex in2) {
            complex ret; 
            ret.real =  (double) (in1 + in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  complex operator -( byte in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 - in2.real);
            ret.imag =  (double) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  complex operator *( byte in1,  complex in2) {
            complex ret;
            ret.real =  (double) (in1 * in2.real);
            ret.imag =  (double) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  complex operator /( byte in1,  complex in2) {
            complex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( complex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (double) (in2.imag * (1/in2.real)); 
                ret.imag =  (double) (in2.real + in2.imag*tmp); 
                ret.real =  (double) in1/ret.imag; 
                ret.imag =  (double) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (double) (in2.real * (1/in2.imag));
                ret.imag =  (double) (in2.imag + in2.real*tmp); 
                ret.real =  (double) (in1*tmp)/ret.imag; 
                ret.imag =  (double) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( byte in1,  complex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( byte in1,  complex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( byte in1,  complex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( byte in1,  complex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( byte in1,  complex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( byte in1,  complex in2) {
            return (in1 <= in2.real);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region CAST_OPERATORS
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(double a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as the a and the imaginary part is 0.</returns>
        public static implicit operator complex(float a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number beeing a copy of the real and imaginary parts of a.</returns>
        public static implicit operator complex(fcomplex a) {
            return new complex(a.real, a.imag);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(byte a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(char a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(Int16 a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(Int32 a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(Int64 a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(UInt16 a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(UInt32 a) {
            return new complex(a, 0.0);
        }
        /// <summary>
        /// cast value to complex number
        /// </summary>
        /// <param name="a">value to cast</param>
        /// <returns>complex number with the real part having the same value as a and the imaginary part is 0.</returns>
        public static implicit operator complex(UInt64 a) {
            return new complex(a, 0.0);
        }

        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>double number with the real part of a </returns>
        public static explicit operator double(complex a) {
            return a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast from double to float.</remarks>
        public static explicit operator float(complex a) {
            return (float)a.real;
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>float complex number with the real and imaginary parts beeing a copy of a </returns>
        /// <remarks>The real and imaginary parts are the result of a cast to float.</remarks>
        public static explicit operator fcomplex(complex a) {
            return new fcomplex((float)a.real, (float)a.imag);
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to byte.</remarks>
        public static explicit operator byte(complex a) {
            return (byte) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to char.</remarks>
        public static explicit operator char(complex a) {
            return (char) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to Int16.</remarks>
        public static explicit operator Int16(complex a) {
            return (Int16) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to Int32.</remarks>
        public static explicit operator Int32(complex a) {
            return (Int32) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to Int64.</remarks>
        public static explicit operator Int64(complex a) {
            return (Int64) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to UInt16.</remarks>
        public static explicit operator UInt16(complex a) {
            return (UInt16) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of a </returns>
        /// <remarks>the return value is the result of a cast to UInt32.</remarks>
        public static explicit operator UInt32(complex a) {
            return (UInt32) a.real; 
        }
        /// <summary>
        /// cast value from complex number
        /// </summary>
        /// <param name="a">complex value to cast</param>
        /// <returns>number with the real part of input </returns>
        /// <remarks>the return value is the result of a cast to UInt64.</remarks>
        public static explicit operator UInt64(complex a) {
            return (UInt64) a.real; 
        }
#endregion CAST_OPERATORS

        #region Functions Basic Math
        /// <summary>
        /// Absolute value of input
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>The absolute value of the input</returns>
        public static double Abs(complex input) {
            return Math.Sqrt(input.real * input.real + input.imag * input.imag);
        }
        /// <summary>
        /// Phase angle of complex number
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>The phase angle of the input</returns>
        /// <remarks>For the result the Atan2 function of the <see cref="Math"/> class is used.</remarks>
        public static double Angle(complex input) {
            return Math.Atan2(input.imag, input.real);
        }
        /// <summary>
        /// Arcus tangens of complex input
        /// </summary>
        /// <param name="input">complex input</param>
        /// <returns>Arcus tangens of complex input</returns>
        /// <remarks></remarks>
        public static complex Atan(complex input) {
            complex ret = new complex(0, (float)0.5);
            return (ret * Log((complex.i + input) / (complex.i - input)));
        }
        /// <summary>
        /// Arcus cosinus of complex input
        /// </summary>
        /// <param name="input">complex input</param>
        /// <returns>Arcus cosinus of input</returns>
        public static complex Acos(complex input) {
            complex ni = complex.i * -1.0;
            return complex.Log(complex.Sqrt(input * input - 1)
                + input) * ni;
        }
        /// <summary>
        /// Arcus cosinus of input
        /// </summary>
        /// <param name="input"> input value</param>
        /// <returns>Arcus cosinus of input</returns>
        public static complex Acos(double input) {
            if (Math.Abs(input) <= 1.0)
                return new complex(Math.Acos(input), 0.0);
            else {
                return Acos((complex)input);
            }
        }
        /// <summary>
        /// Arcus sinus of complex input
        /// </summary>
        /// <param name="input"> input value</param>
        /// <returns>Arcus sinus of input</returns>
        public static complex Asin(double input) {
            if (Math.Abs(input) <= 1.0)
                return new complex(Math.Asin(input), 0.0);
            else {
                return Asin((complex)input);
            }
        }
        /// <summary>
        /// Arcus sinus of input
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>Arcus sinus of  input</returns>
        public static complex Asin(complex input) {
            complex ret = Acos(input);
            ret.real = Math.PI / 2 - ret.real;
            return ret;
        }
        /// <summary>
        /// round towards positive infinity
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>result is the next integer value greater then input</returns>
        /// <remarks>ILMath.Ceiling operates in both: real and imaginary parts seperately</remarks>
        public static complex Ceiling (complex input){
            return new complex(
                    Math.Ceiling(input.real),
                    Math.Ceiling(input.imag)
            );
        }
        /// <summary>
        /// round towards negative infinity
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>result is the next integer value lower then input</returns>
        /// <remarks>ILMath.Floor operates in both: real and imaginary parts seperately</remarks>
        public static complex Floor (complex input){
            return new complex(
                    Math.Floor(input.real),
                    Math.Floor(input.imag)
            );
        }
        /// <summary>
        /// rounds towards nearest integer
        /// </summary>
        /// <param name="input">input value</param>
        /// <returns>result is the nearest integer value for input</returns>
        /// <remarks>ILMath.Round operates in both: real and imaginary parts deperately</remarks>
        public static complex Round (complex input){
            return new complex(
                    Math.Round(input.real),
                    Math.Round(input.imag)
            );
        }
        /// <summary>
        /// Signum function
        /// </summary>
        /// <param name="input">complex input </param>
        /// <returns>result as input / Abs(input)</returns>
        /// <remarks>Sign(input) with input beeing complex returns the projection onto
        /// the unit circle. If input is 0+0i the result will be 0+0i.</remarks>
        public static complex Sign (complex input){
            if (input.real == 0.0 && input.imag == 0.0)
                return new complex(); 
            else {
                double mag = Math.Sqrt(input.real * input.real + input.imag * input.imag); 
                return new complex(
                    input.real / mag,
                    input.imag / mag);
            }
        }
        /// <summary>
        /// truncate a floating point complex value
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>integer part of input</returns>
        /// <remarks>Operates on real and imaginary parts seperately.</remarks>
        public static complex Truncate (complex input){
            return new complex(
                    Math.Truncate(input.real),
                    Math.Truncate(input.imag)
            );
        }
        /// <summary>
        /// Cosinus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>cosinus of input</returns>
        /// <remarks><para>The cosinus is computed by the trigonometric euler equation: </para>
        /// <para>0.5 * [exp(i input) + exp(-i input)]</para></remarks>
        public static complex Cos(complex input) {
            complex i = new complex(0, 1.0);
            complex mi = new complex(0, -1.0);
            return (Exp(i * input) + Exp(mi * input)) / 2.0;
        }
        /// <summary>
        /// Cosinus hyperbolicus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>cosinus hyperbolicus of input</returns>
        /// <remarks><para>The cosinus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(input) + Exp(-1.0 * input)) / 2.0</para></remarks>
        public static complex Cosh(complex input) {
            return (Exp(input) + Exp(-1.0 * input)) / 2.0;
        }
        /// <summary>
        /// Sinus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Sinus of input</returns>
        /// <remarks><para>The sinus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(i * input) - Exp(-1.0 * i * input)) / (2.0 * i)</para></remarks>
        public static complex Sin(complex input) {
            complex i = new complex(0, 1.0);
            complex mi = new complex(0, -1.0);
            return (Exp(i * input) - Exp(mi * input)) / (2.0 * i);
        }
        /// <summary>
        /// Sinus hyperbolicus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Sinus hyperbolicus of input</returns>
        /// <remarks><para>The sinus hyperbolicus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(input) - Exp(-1.0 * input)) / 2.0</para></remarks>
        public static complex Sinh(complex input) {
            return (Exp(input) - Exp(-1.0 * input)) / 2.0;
        }
        /// <summary>
        /// complex exponent
        /// </summary>
        /// <param name="exponent">exponent</param>
        /// <returns>result of exp(exponent)</returns>
        /// <remarks>For complex exponents, exp(exponent) is computed by
        /// <para>complex.FromPol(Math.Exp(exponent.real), exponent.imag)</para></remarks>
        public static complex Exp(complex exponent) {
            return complex.FromPol(Math.Exp(exponent.real), exponent.imag);
        }
        /// <summary>
        /// complex power for real exponent
        /// </summary>
        /// <param name="input">basis </param>
        /// <param name="exponent">exponent</param>
        /// <returns>result of input power exponent</returns>
        /// <remarks>the computation will be carried out by 
        /// <para>exp(log(input) * exponent)</para></remarks>
        public static complex Pow(complex input, double exponent) {
            complex ret = input.Log();
            ret.imag *= exponent;
            ret.real *= exponent;
            return ret.Exp();
        }
		/// <summary>
		/// complex power - real basis, real exponent
		/// </summary>
		/// <param name="basis">basis</param>
		/// <param name="exponent">exponent</param>
		/// <returns>complex number.</returns>
		/// <remarks>The result will be a complex number. For negative basis 
		/// the basis will be converted to a complex number and the power 
		/// will be computed in the complex plane.</remarks>
		public static complex Pow(double basis, double exponent) {
			if (basis >= 0.0)
				return Math.Pow(basis, exponent);
            else
				return Pow((complex)basis, exponent);
        }
		/// <summary>
		/// complex power - complex exponent
		/// </summary>
		/// <param name="basis">basis</param>
		/// <param name="exponent">exponent</param>
		/// <returns>complex number exp(log(basis) * exponent).</returns>
		/// <remarks>The result will be the complex number exp(log(basis) * exponent). </remarks>
		public static complex Pow(complex basis, complex exponent) {
			complex ret = (basis.Log() * exponent);
            return ret.Exp();
        }
		/// <summary>
		/// Square root
		/// </summary>
		/// <param name="input">input</param>
		/// <returns>the square root of input</returns>
        /// <remarks>If input is smaller than 0.0, the computation will be done in the complex plane. </remarks>
        public static complex Sqrt(double input) {
			if (input > 0.0)
				return new complex(Math.Sqrt(input), 0.0);
			else
				return Sqrt(input);
		}
		/// <summary>
		/// Square root
		/// </summary>
		/// <param name="input">input</param>
		/// <returns>the square root of input</returns>
        /// <remarks>numerical recipes in C: Appendix C </remarks>
		public static complex Sqrt(complex input) {
            // Reference : numerical recipes in C: Appendix C
            complex ret = new complex();
            double x, y, w, r;
            if (input.real == 0.0 && input.imag == 0.0)
                return ret;
            else {
                x = (double)Math.Abs(input.real);
                y = (double)Math.Abs(input.imag);
                if (x >= y) {
                    r = y / x;
                    w = Math.Sqrt(x) * Math.Sqrt(0.5 * (1.0 + Math.Sqrt(1.0 + r * r)));
                } else {
                    r = x / y;
                    w = Math.Sqrt(y) * Math.Sqrt(0.5 * (r + Math.Sqrt(1.0 + r * r)));
                }
                if (input.real >= 0.0) {
                    ret.real = w;
                    ret.imag = input.imag / (2.0 * w);
                } else {
                    ret.imag = (input.imag >= 0) ? w : -w;
                    ret.real = input.imag / (2.0 * ret.imag);
                }
                return ret;
            }
        }
        /// <summary>
        /// Tangens
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Tangens of input</returns>
        /// <remarks>the tangens is 
        /// <para>sin(input) / cos(input)</para>
        /// if cos(input) == 0.0+0.0i, INF will be returned.</remarks>
        public static complex Tan(complex input) {
            complex ci = Cos(input);
            if (ci.real == 0.0 && ci.imag == 0.0)
                return INF;
            return (Sin(input) / ci);
        }
        /// <summary>
        /// Tangens hyperbolicus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Tangens hyperbolicus</returns>
        /// <remarks>the tangens hyperbolicus is 
        /// <para>sinh(input) / cosh(input)</para>
        /// if cosh(input) == 0.0+0.0i, INF will be returned.</remarks>
        public static complex Tanh(complex input) {
            complex si = Cosh(input);
            if (si.real == 0.0 && si.imag == 0.0)
                return INF;
            return (Sinh(input) / si);
        }
        /// <summary>
        /// complex logarithm 
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>complex logarithm of input</returns>
        /// <remarks>the real part of the logarithm is computed by 
        /// <para>log (abs (input))</para>
        /// <para>The imaginary part holds the phase of input.</para>
        /// </remarks>
        public static complex Log(complex input) {
            complex ret = new complex();
            ret.real = Math.Log(Math.Sqrt(input.real * input.real + input.imag * input.imag));
            ret.imag = Math.Atan2(input.imag, input.real);
            return ret;
        }
        /// <summary>
        /// Logarithm of real input 
        /// </summary>
        /// <param name="input">input value - may be negative</param>
        /// <returns>complex logarithm</returns>
        public static complex Log(double input) {
            return Log (new complex(input,0.0)); 
        }
        /// <summary>
        /// Logarithm of base 10 of real input 
        /// </summary>
        /// <param name="input">input value - may be negative</param>
        /// <returns>complex logarithm of base 10</returns>
        public static complex Log10(double input) {
            return Log(new complex(input,0.0)) * 0.43429448190325176;
        }
        /// <summary>
        /// Logarithm of base 2 of real input 
        /// </summary>
        /// <param name="input">input value - may be negative</param>
        /// <returns>complex logarithm of base 2</returns>
        public static complex Log2(double input) {
            return Log(new complex(input,0.0)) * 1.4426950408889641;
        }
        /// <summary>
        /// Logarithm of base 10
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>logarithm of base 10</returns>
        /// <seealso cref="ILNumerics.complex.Log(complex)"/>
        public static complex Log10(complex input) {
            return Log(input) * 0.43429448190325176;
        }
        /// <summary>
        /// Logarithm of base 2
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>logarithm of base 2.</returns>
        /// <seealso cref="ILNumerics.complex.Log(complex)"/>
        public static complex Log2(complex input) {
            return Log(input) * 1.4426950408889634;
        }
        /// <summary>
        /// convert polar notation into cartesian notation
        /// </summary>
        /// <param name="magnitude">magnitude</param>
        /// <param name="angle">phase</param>
        /// <returns>complex value having magnitude and phase</returns>
        public static complex FromPol(double magnitude, double angle) {
            return new complex(
                magnitude * Math.Cos(angle),
                magnitude * Math.Sin(angle)
            );
        }
        /// <summary>
        /// convert to string
        /// </summary>
        /// <returns>string displaying the comlex number (full precision)</returns>
        public override String ToString() {
            if (imag>=0)
                return String.Format("{0} + {1}i",real,imag);
            else 
                return String.Format("{0} {1}i",real,imag);
        }
        private static string m_precSpecI = ""; 
        private static string m_precSpecR = ""; 
        private static int m_lastDigits = 0; 
        /// <summary>
        /// print formated output of this number, determine number of digits
        /// </summary>
        /// <param name="digits">number of digits</param>
        /// <returns>formated output</returns>
        public string ToString(int digits) {
            if (digits < 1) return ""; 
            if (digits != m_lastDigits) {
                m_lastDigits = digits; 
                m_precSpecR = String.Format("{{0:f{0}}}",digits);
                m_precSpecI = String.Format("{{1:f{0}}}i",digits);
            }
            if (imag >= 0) {
                return String.Format(m_precSpecR+"+"+m_precSpecI,real,imag); 
            } else {
                return String.Format(m_precSpecR+" "+m_precSpecI,real,imag); 
            }
        }
        /// <summary>
        /// magnitude of this complex instance
        /// </summary>
        /// <returns>magnitude</returns>
        public double Abs() {
            return Math.Sqrt(real * real + imag * imag);
        }
        /// <summary>
        /// Phase of this complex instance
        /// </summary>
        /// <returns>phase</returns>
        public double Angle() {
            return Math.Atan2(imag, real);
        }
        /// <summary>
        /// Arcus cosinus of this complex instance
        /// </summary>
        /// <returns>Arcus cosinus</returns>
        public complex Acos() {
            complex ret = new complex(0, -1);
            return complex.Log(complex.Sqrt(this * this - 1)
                + this) * ret;
        }
        /// <summary>
        /// Arcus sinus of this complex instance
        /// </summary>
        /// <returns>arcus sinus</returns>
        public complex Asin() {
            complex ret = Acos(this);
            ret.real = Math.PI / 2 - ret.real;
            return ret;
        }
        /// <summary>
        /// exponential / power of base e
        /// </summary>
        /// <returns>power of base e</returns>
        public complex Exp() {
            return complex.FromPol(Math.Exp(real), imag);
        }
        /// <summary>
        /// complex power real exponent
        /// </summary>
        /// <param name="exponent">exponent</param>
        /// <returns>new complex number with result</returns>
		/// <remarks>If this instance is a and the exponent is e than 
		/// the result will be the complex number exp(log(a) * e). </remarks>
        public complex Pow(double exponent) {
            complex ret = Log();
            ret.imag *= exponent;
            ret.real *= exponent;
            return ret.Exp();
        }
		/// <summary>
		/// complex power - complex exponent
		/// </summary>
		/// <param name="exponent">exponent</param>
		/// <returns>complex number exp(log(this) * exponent).</returns>
		/// <remarks>If this instance is a than 
		/// the result will be the complex number exp(log(a) * exponent). </remarks>
        public complex Pow(complex exponent) {
            complex ret = (Log() * exponent);
            return ret.Exp();
        }
        /// <summary>
        /// Square root of this complex value
        /// </summary>
        /// <returns>square root of this complex value</returns>
        public complex Sqrt() {
            // Reference : numerical recipes in C: Appendix C
            complex ret = new complex();
            double x, y, w, r;
            if (real == 0.0 && imag == 0.0)
                return ret;
            else {
                x = (double)Math.Abs(real);
                y = (double)Math.Abs(imag);
                if (x >= y) {
                    r = y / x;
                    w = Math.Sqrt(x) * Math.Sqrt(0.5 * (1.0 + Math.Sqrt(1.0 + r * r)));
                } else {
                    r = x / y;
                    w = Math.Sqrt(y) * Math.Sqrt(0.5 * (r + Math.Sqrt(1.0 + r * r)));
                }
                if (real >= 0.0) {
                    ret.real = w;
                    ret.imag = imag / (2.0 * w);
                } else {
                    ret.imag = (imag >= 0) ? w : -w;
                    ret.real = imag / ( 2.0 * ret.imag );
                }
                return ret;
            }
        }
        /// <summary>
        /// logarithm of base e
        /// </summary>
        /// <returns>logarithm of base e</returns>
        /// <remarks>The logarithm of a complex number A is defined as follows: <br />
        /// <list type="none"><item>real part: log(abs(A))</item>
        /// <item>imag part: Atan2(imag(A),real(A))</item></list>
        /// </remarks>
        public complex Log() {
            complex ret = new complex();
            ret.real = Math.Log(Math.Sqrt(real * real + imag * imag));
            ret.imag = Math.Atan2(imag, real);
            return ret;
        }
        /// <summary>
        /// test if any of real or imaginary parts are NAN's
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is not a number</returns>
        public static bool IsNaN(complex input) {
            if (double.IsNaN(input.real) || double.IsNaN(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are infinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is infinite</returns>
        public static bool IsInfinity(complex input) {  
            if (double.IsInfinity(input.real) || double.IsInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are pos.nfinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is positive infinite</returns>
        public static bool IsPositiveInfinity(complex input) {  
            if (double.IsPositiveInfinity(input.real) || double.IsPositiveInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are neg. infinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is negative infinite</returns>
        public static bool IsNegativeInfinity(complex input) {  
            if (double.IsNegativeInfinity(input.real) || double.IsNegativeInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are finite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real and imag part is finite</returns>
        public static bool IsFinite (complex input) {
            if (ILMath.isfinite(input.real) && ILMath.isfinite(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if both of real or imaginary parts are 0
        /// </summary>
        /// <returns>true if real and imag part is 0</returns>
        public bool iszero() {
            if (real == 0.0 && imag == 0.0) 
                return true; 
            else 
                return false; 
        }
        #endregion Functions Basic Math
    }
    
}
