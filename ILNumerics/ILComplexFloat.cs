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
    /// floating point complex value data type of float (single) precision
    /// </summary>
    /// <remarks>This class extends the system value types for real numbers to complex float 
    /// values. Besides the publicly available members 'real' and 'imag' it provides all the 
    /// basis functionality the floating point system.double (!) brings (abs, log, sqrt, tan etc.) for 
    /// float precision complex,
    /// as well as it overrides the basic unary and binary operators for all common system value 
    /// types including rarely used types (f.e. UInt16). This includes the basic numerical operations 
    /// like '+','-','/','*' and the relational operators: '==','>','>=' etc. Also there are some 
    /// explicit and some implicit casting operators from / to fcomplex value into system 
    /// value types. </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct fcomplex {
        /// <summary>
        /// Real part of this complex number
        /// </summary>
        public float real;
        /// <summary>
        /// Imaginary part of this complex number
        /// </summary>
        public float imag;
        /// <summary>
        /// imaginary unit 
        /// </summary>
        public static readonly fcomplex i = new fcomplex(0.0f,1.0f); 

        /// <summary>
        /// Construct new float complex number
        /// </summary>
        /// <param name="real">real part</param>
        /// <param name="imag">imaginary part</param>
        public fcomplex(float real, float imag) {
            this.real = real;
            this.imag = imag;
        }
        
        /// <summary>
        /// complex conjugate 
        /// </summary>
        public fcomplex conj {
            get{
                return new fcomplex(real,imag * (-1.0f));
            }
        }

        /// <summary>
        /// positive infinity for real and imag part of complex value
        /// </summary>
        public static fcomplex INF {
            get {
                return new fcomplex(
                    float.PositiveInfinity,
                    float.PositiveInfinity
                );
            }
        }

        /// <summary>
        /// fcomplex quantity, marked as beeing "not a number"
        /// </summary>
        public static fcomplex NaN {
            get {
                return new fcomplex(float.NaN,float.NaN); 
            }
        }

        /// <summary>
        /// are obj's real and imaginary part identical to the real and imaginary parts of this fcomplex
        /// </summary>
        /// <param name="obj">fcomplex object to determine the equality for</param>
        /// <returns>true if obj is of fcomplex type and its real and imag part has the same 
        /// values as the real and imaginary part of this array.</returns>
        public override bool Equals(object obj) {
            if (obj is fcomplex && ((fcomplex)obj) == this)
                return true; 
            return false; 
        }
        
        /// <summary>
        /// Give HashCode of this system object
        /// </summary>
        /// <returns>HashCode of this system object</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #region HYCALPER LOOPSTART OPERATORS_complex+complex@ILComplex.cs
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        TinArr1 
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        TinArr2
    </source>
    <destination>fcomplex</destination>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        FCast
    </source>
    <destination>(float)</destination>
    <destination>(float)</destination>
</type>
<type>
    <source locate="after">
        TRret
    </source>
    <destination>float</destination>
    <destination>float</destination>
</type>
</hycalper>
 */
        #endregion HYCALPER LOOPEND OPERATOR_complex+complex@ILComplex.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  complex in2) {
            fcomplex ret; 
             ret.real =  (float) (in1.real + in2.real );
             ret.imag =  (float) (in1.imag + in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  complex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1.real  - in2.real );
            ret.imag =  (float) (in1.imag - in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  complex in2) {
            fcomplex ret;
            ret.real =  (float) ((in1.real * in2.real ) - (in1.imag * in2.imag ));
            ret.imag =  (float) ((in1.real * in2.imag ) + (in1.imag * in2.real ));
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
        public static  fcomplex operator /( fcomplex in1,  complex in2) {
            if (in2.imag == 0) return in1 / in2.real; 
            return in1 * (1 / in2); 
            if (IsNaN(in1) ||  complex .IsNaN(in2)) return NaN;
            //if ( complex .IsInfinity(in2)) return NaN;            
            //if (in1.real == 0 && in1.imag == 0) return ( fcomplex )0;
            fcomplex ret;
            if (in2.real == 0) {
                ret.imag =  (float) -(in1.real / in2.imag); 
                ret.real =  (float) (in1.imag / in2.imag); 
                return ret; 
            }
            // this would be the naive approach. But it come with to little robustness against overflow
            //double norm2 = in2.real * in2.real + in2.imag * in2.imag;
            //if (norm2 == 0) return INF;    // this may be removed, since division by 0 results in inf anyway ? 
            //ret.real =  (float) (((in1.real  * in2.real ) + (in1.imag  * in2.imag )) / norm2);
            //ret.imag =  (float) (((in1.imag  * in2.real ) - (in1.real  * in2.imag )) / norm2); 
            
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            float tmp1, tmp2; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp1 =  (float) (in2.imag * (1/in2.real)); 
                tmp2 =  (float) (in2.real + in2.imag*tmp1); 
                ret.real =  (float) (in1.real + in1.imag*tmp1)/tmp2; 
                ret.imag =  (float) (in1.imag - in1.real*tmp1)/tmp2; 
            } else {
                tmp1 =  (float) (in2.real * (1/in2.imag));
                tmp2 =  (float) (in2.imag + in2.real*tmp1); 
                ret.real =  (float) (in1.imag + in1.real*tmp1)/tmp2; 
                ret.imag = -  (float) (in1.real - in1.imag*tmp1)/tmp2; 
            }
            return ret;                                            
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  complex in2) {
            return (in1.imag  == in2.imag ) && (in1.real  == in2.real );
        }

        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  complex in2) {
            return (in1.imag  != in2.imag ) || (in1.real  != in2.real );
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  complex in2) {
            return (in1.real > in2.real );
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( fcomplex in1,  complex in2) {
            return (in1.real < in2.real );
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  complex in2) {
            return (in1.real >= in2.real );
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  complex in2) {
            return (in1.real <= in2.real );
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  fcomplex in2) {
            fcomplex ret; 
             ret.real =  (float) (in1.real + in2.real );
             ret.imag =  (float) (in1.imag + in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1.real  - in2.real );
            ret.imag =  (float) (in1.imag - in2.imag );
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) ((in1.real * in2.real ) - (in1.imag * in2.imag ));
            ret.imag =  (float) ((in1.real * in2.imag ) + (in1.imag * in2.real ));
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
        public static  fcomplex operator /( fcomplex in1,  fcomplex in2) {
            if (in2.imag == 0) return in1 / in2.real; 
            return in1 * (1 / in2); 
            if (IsNaN(in1) ||  fcomplex .IsNaN(in2)) return NaN;
            //if ( fcomplex .IsInfinity(in2)) return NaN;            
            //if (in1.real == 0 && in1.imag == 0) return ( fcomplex )0;
            fcomplex ret;
            if (in2.real == 0) {
                ret.imag =  (float) -(in1.real / in2.imag); 
                ret.real =  (float) (in1.imag / in2.imag); 
                return ret; 
            }
            // this would be the naive approach. But it come with to little robustness against overflow
            //double norm2 = in2.real * in2.real + in2.imag * in2.imag;
            //if (norm2 == 0) return INF;    // this may be removed, since division by 0 results in inf anyway ? 
            //ret.real =  (float) (((in1.real  * in2.real ) + (in1.imag  * in2.imag )) / norm2);
            //ret.imag =  (float) (((in1.imag  * in2.real ) - (in1.real  * in2.imag )) / norm2); 
            
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            float tmp1, tmp2; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp1 =  (float) (in2.imag * (1/in2.real)); 
                tmp2 =  (float) (in2.real + in2.imag*tmp1); 
                ret.real =  (float) (in1.real + in1.imag*tmp1)/tmp2; 
                ret.imag =  (float) (in1.imag - in1.real*tmp1)/tmp2; 
            } else {
                tmp1 =  (float) (in2.real * (1/in2.imag));
                tmp2 =  (float) (in2.imag + in2.real*tmp1); 
                ret.real =  (float) (in1.imag + in1.real*tmp1)/tmp2; 
                ret.imag = -  (float) (in1.real - in1.imag*tmp1)/tmp2; 
            }
            return ret;                                            
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  fcomplex in2) {
            return (in1.imag  == in2.imag ) && (in1.real  == in2.real );
        }

        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  fcomplex in2) {
            return (in1.imag  != in2.imag ) || (in1.real  != in2.real );
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  fcomplex in2) {
            return (in1.real > in2.real );
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( fcomplex in1,  fcomplex in2) {
            return (in1.real < in2.real );
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  fcomplex in2) {
            return (in1.real >= in2.real );
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  fcomplex in2) {
            return (in1.real <= in2.real );
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART OPERATORS_complex+noncomplex@ILComplex.cs
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        TinArr1 
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        TinArr2
    </source>
    <destination>double</destination>
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
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
</type>
<type>
    <source locate="after">
        infinity
    </source>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
</type>
<type>
    <source locate="nextline">
        test4inf
    </source>
    <destination>if (double.IsInfinity(in2))</destination>
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
<type>
    <source locate="nextline">
        test4NaNin2 
    </source>
    <destination>if (double.IsNaN(in2)) return NaN;</destination>
    <destination></destination>
    <destination></destination>
    <destination>if (float.IsNaN(in2)) return NaN;</destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
</type>
</hycalper>
 */
        #endregion HYCALPER LOOPEND OPERATOR_complex+noncomplex@ILComplex.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  UInt64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  UInt64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  UInt64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  UInt64 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  UInt64 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  UInt64 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  UInt64 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  UInt64 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  UInt64 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  UInt64 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  UInt32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  UInt32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  UInt32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  UInt32 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  UInt32 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  UInt32 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  UInt32 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  UInt32 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  UInt32 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  UInt32 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  UInt16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  UInt16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  UInt16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  UInt16 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  UInt16 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  UInt16 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  UInt16 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  UInt16 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  UInt16 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  UInt16 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  Int64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  Int64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  Int64 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  Int64 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  Int64 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  Int64 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  Int64 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  Int64 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  Int64 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  Int64 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  Int32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  Int32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  Int32 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  Int32 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  Int32 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  Int32 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  Int32 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  Int32 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  Int32 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  Int32 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  Int16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  Int16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  Int16 in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  Int16 in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  Int16 in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  Int16 in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  Int16 in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  Int16 in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  Int16 in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  Int16 in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  float in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  float in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  float in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  float in2) {
            if (IsNaN(in1)) return NaN;
            if (float.IsNaN(in2)) return NaN;
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (float.IsInfinity(in2))
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  float in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  float in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  float in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  float in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  float in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  float in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  char in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  char in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  char in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  char in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  char in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  char in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  char in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  char in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  char in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  char in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  byte in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  byte in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  byte in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  byte in2) {
            if (IsNaN(in1)) return NaN;
            
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (false)
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  byte in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  byte in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  byte in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  byte in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  byte in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  byte in2) {
            return (in1.real <= in2);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( fcomplex in1,  double in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real + in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( fcomplex in1,  double in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real - in2);
            ret.imag =  (float) in1.imag;
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( fcomplex in1,  double in2) {
            fcomplex ret;
            ret.real =  (float) (in1.real * in2);
            ret.imag =  (float) (in1.imag * in2);
            return ret;
        }
        /// <summary>
        /// Operator dividing the specified inputs.
        /// </summary>
        /// <param name="in1">The divident.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( fcomplex in1,  double in2) {
            if (IsNaN(in1)) return NaN;
            if (double.IsNaN(in2)) return NaN;
            if (in1.real == 0 && in1.imag == 0) {
                if (in2 == 0) return NaN; 
                return ( fcomplex )0;
            } else {
                if (double.IsInfinity(in2))
                {
                    if (IsInfinity(in1)) {
                        return NaN; 
                    } else {
                        return ( fcomplex )0;
                    }
                }
            }
            fcomplex ret;
            if (in2 == 0) return INF ;
            ret.real =  (float) (in1.real / in2);
            ret.imag =  (float) (in1.imag / in2);
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( fcomplex in1,  double in2) {
            return (in1.real == in2 && in1.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( fcomplex in1,  double in2) {
            return (in1.imag != 0.0) || (in1.real != in2);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( fcomplex in1,  double in2) {
            return (in1.real > in2);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <(  fcomplex in1,  double in2) {
            return (in1.real < in2);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( fcomplex in1,  double in2) {
            return (in1.real >= in2);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( fcomplex in1,  double in2) {
            return (in1.real <= in2);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART OPERATORS_noncomplex+complex@ILComplex.cs
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        Tret
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        TinArr2 
    </source>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
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
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
    <destination>(float)</destination>
</type>
<type>
    <source locate="after">
        infinity
    </source>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>fcomplex.INF</destination>
</type>
</hycalper>
 */
        #endregion HYCALPER LOOPEND OPERATOR_noncomplex+complex@ILComplex.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( UInt64 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( UInt64 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( UInt64 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( UInt64 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt64 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt64 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt64 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt64 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt64 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt64 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( UInt32 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( UInt32 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( UInt32 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( UInt32 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt32 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt32 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt32 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt32 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt32 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt32 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( UInt16 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( UInt16 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( UInt16 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( UInt16 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( UInt16 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( UInt16 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( UInt16 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( UInt16 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( UInt16 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( UInt16 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( Int64 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( Int64 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( Int64 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( Int64 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int64 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int64 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int64 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int64 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int64 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int64 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( Int32 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( Int32 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( Int32 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( Int32 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int32 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int32 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int32 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int32 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int32 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int32 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( Int16 in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( Int16 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( Int16 in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( Int16 in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( Int16 in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( Int16 in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( Int16 in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( Int16 in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( Int16 in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( Int16 in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( float in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( float in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( float in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( float in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( float in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( float in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( float in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( float in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( float in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( float in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( char in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( char in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( char in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( char in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( char in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( char in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( char in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( char in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( char in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( char in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }
       
        /// <summary>
        /// Operator adding the values specified.
        /// </summary>
        /// <param name="in1">The first summand.</param>
        /// <param name="in2">The second summand.</param>
        /// <returns>Result of operation in1 + in2</returns>
        public static  fcomplex operator +( byte in1,  fcomplex in2) {
            fcomplex ret; 
            ret.real =  (float) (in1 + in2.real);
            ret.imag =  (float) in2.imag;   // AB080630
            return ret;
        }
        /// <summary>
        /// Operator subtracting the values specified.
        /// </summary>
        /// <param name="in1">The minuend.</param>
        /// <param name="in2">The subtrahend.</param>
        /// <returns>Result of operation in1 - in2</returns>
        public static  fcomplex operator -( byte in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 - in2.real);
            ret.imag = - (float) in2.imag; 
            return ret;
        }
        /// <summary>
        /// Operator multiplicating the values specified.
        /// </summary>
        /// <param name="in1">The first factor.</param>
        /// <param name="in2">The second factor.</param>
        /// <returns>Result of operation in1 * in2</returns>
        public static  fcomplex operator *( byte in1,  fcomplex in2) {
            fcomplex ret;
            ret.real =  (float) (in1 * in2.real);
            ret.imag =  (float) (in1 * in2.imag);
            return ret;
        }
        /// <summary>
        /// Operator dividing a real by a complex.
        /// </summary>
        /// <param name="in1">The dividend.</param>
        /// <param name="in2">The divisor.</param>
        /// <returns>Result of operation in1 / in2</returns>
        public static  fcomplex operator /( byte in1,  fcomplex in2) {
            fcomplex ret; 
            if (in1 == 0) {
                if (IsInfinity(in2)) return NaN; 
            } else {
                if (IsInfinity(in2)) return ( fcomplex )0; 
            }
            if (in2.real == 0 && in2.imag == 0) {
                return INF;
            }
            // this algorithm is taken from [1]. The one described in [2] was not taken. Tests 
            // did not show any advantage when using double precision floating point arithmetic.
            double tmp; 
            if (Math.Abs(in2.real) >= Math.Abs(in2.imag)) {
                tmp =  (float) (in2.imag * (1/in2.real)); 
                ret.imag =  (float) (in2.real + in2.imag*tmp); 
                ret.real =  (float) in1/ret.imag; 
                ret.imag = -  (float) (in1*tmp)/ret.imag; 
            } else {
                tmp =  (float) (in2.real * (1/in2.imag));
                ret.imag =  (float) (in2.imag + in2.real*tmp); 
                ret.real =  (float) (in1*tmp)/ret.imag; 
                ret.imag = -  (float) in1/ret.imag; 
            }
            return ret;
        }
        /// <summary>
        /// Equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are the same. False otherwise.</returns>
        public static bool operator ==( byte in1,  fcomplex in2) {
            return (in2.real == in1 && in2.imag == 0.0);
        }
        /// <summary>
        /// Un-equality comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real and imaginary parts of both inputs are not equal. False otherwise.</returns>
        public static bool operator !=( byte in1,  fcomplex in2) {
            return (in2.imag != 0.0) || (in2.real != in1);
        }
        /// <summary>
        /// Greater than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the greater than operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator > ( byte in1,  fcomplex in2) {
            return (in1 > in2.real);
        }
        /// <summary>
        /// Lower than comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator < ( byte in1,  fcomplex in2) {
            return (in1 < in2.real);
        }
        /// <summary>
        /// Greater than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is greater than or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator >=( byte in1,  fcomplex in2) {
            return (in1 >= in2.real);
        }
        /// <summary>
        /// Lower than or equal comparison for 2 complex numbers.
        /// </summary>
        /// <param name="in1">The first complex number.</param>
        /// <param name="in2">The 2nd complex number.</param>
        /// <returns>true if real part of in1 is lower then or equals the real part of in2. False otherwise.</returns>
        /// <remarks>Keep in mind, since the lower than comparison operator is not defined for complex values, only the real parts are compared.</remarks>
        public static bool operator <=( byte in1,  fcomplex in2) {
            return (in1 <= in2.real);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region unary minus
        /// <summary>
        /// unary minus operator
        /// </summary>
        /// <param name="in1">fcomplex input</param>
        /// <returns>fcomplex number similar to in1, having real and imag part negated</returns>
        public static fcomplex operator -( fcomplex in1) {
            fcomplex ret = new fcomplex(); 
            ret.imag = -in1.imag; 
            ret.real = -in1.real; 
            return ret;
        }
        #endregion

        /// <summary>
        /// Magnitude value of float complex number
        /// </summary>
        /// <param name="input">complex number</param>
        /// <returns>magnitude of input</returns>
        public static float Abs(fcomplex input) {
            return (float) Math.Sqrt ( input.real * input.real + input.imag * input.imag );
        }
        /// <summary>
        /// angle of complex number
        /// </summary>
        /// <param name="input">complex number to compute angle of</param>
        /// <returns>angle of input</returns>
        public static double Angle(fcomplex input) {
            return (float) Math.Atan2 ( input.imag, input.real );
        }
        /// <summary>
        /// Arcus cosinus for float complex number
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>arcus cosinus of input</returns>
        /// <remarks>The arcus cosinus of a complex number is computed by
        /// <para>Log(Sqrt(input^2 - 1) + input) * i </para></remarks>
        public static fcomplex Acos(fcomplex input) {
            fcomplex ret = new fcomplex ( 0, -1 );
            return fcomplex.Log ( fcomplex.Sqrt ( input * input - 1 )
                + input ) * ret;
        }
        /// <summary>
        /// arcus cosinus of real number
        /// </summary>
        /// <param name="input"></param>
        /// <returns>arcus cosinus of input</returns>
        /// <remarks>For input > 1.0, <see cref="ILNumerics.fcomplex.Acos(fcomplex)"/> will be used. </remarks>
        public static fcomplex Acos(float input) {
            if (Math.Abs(input) <= 1.0)
                return new fcomplex((float)Math.Acos(input), 0.0f);
            else {
                return Acos((fcomplex)input);
            }
        }
        /// <summary>
        /// arcus sinus of real number
        /// </summary>
        /// <param name="input"></param>
        /// <returns>arcus sinus of input</returns>
        /// <remarks>For input > 1.0, <see cref="ILNumerics.fcomplex.Asin(fcomplex)"/> will be used. </remarks>
        public static fcomplex Asin(float input) {
            if (Math.Abs(input) <= 1.0)
                return new fcomplex((float)Math.Asin(input), 0.0f);
            else {
                return Asin((fcomplex)input);
            }
        }
        /// <summary>
        /// Arcus sinus for complex number
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>arcus sinus of input</returns>
        public static fcomplex Asin(fcomplex input) {
            fcomplex ret = Acos ( input );
            ret.real = (float) (Math.PI / 2 - ret.real);
            return ret; 
        }
        /// <summary>
        /// Power of base e for float complex number
        /// </summary>
        /// <param name="input">float complex input</param>
        /// <returns>result of Exp(input)</returns>
        public static fcomplex Exp(fcomplex input) {
            return fcomplex.FromPol ( (float) Math.Exp ( input.real ), input.imag );
        }
        /// <summary>
        /// fcomplex power real exponent
        /// </summary>
        /// <param name="input">basis </param>
        /// <param name="exponent">exponent</param>
        /// <returns>new fcomplex number with result</returns>
        public static fcomplex Pow(fcomplex input, double exponent) {
            fcomplex ret = input.Log ();
            ret.imag *= (float) exponent;
            ret.real *= (float) exponent;
            return ret.Exp ();
        }
		/// <summary>
		/// complex power - real basis, real exponent
		/// </summary>
		/// <param name="basis">basis</param>
		/// <param name="exponent">exponent</param>
		/// <returns>complex number.</returns>
		/// <remarks>The result will be a fcomplex number. For negative basis 
		/// the basis will be converted to a fcomplex number and the power 
		/// will be computed in the fcomplex plane.</remarks>
		public static fcomplex Pow(double basis, double exponent) {
            if (basis < 0) {
                return Pow((fcomplex)basis, exponent);
            } else {
                return (fcomplex)Math.Pow(basis, exponent);
            }
        }
        /// <summary>
        /// Power: complex base, complex exponent
        /// </summary>
        /// <param name="basis">basis</param>
        /// <param name="exponent">exponent</param>
        /// <returns>result of basis^exponent</returns>
        public static fcomplex Pow(fcomplex basis, fcomplex exponent) {
            fcomplex ret = ( basis.Log () * exponent );
            return ret.Exp ();
        }
        /// <summary>
        /// Square root of real input
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>square root of input</returns>
        public static fcomplex Sqrt(float input) {
            if (input > 0)
                return new fcomplex((float)Math.Sqrt(input), 0.0f);
            else
                return Sqrt((fcomplex)input); 
        }
        /// <summary>
        /// Square root of complex number
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>square root of input</returns>
        public static fcomplex Sqrt(fcomplex input) {
            // Reference : numerical recipes in C: Appendix C
            fcomplex ret = new fcomplex ();
            double x, y, w, r;
            if (input.real == 0.0 && input.imag == 0.0)
                return ret;
            else {
                x = (float) Math.Abs ( input.real );
                y = (float) Math.Abs ( input.imag );
                if (x >= y) {
                    r = y / x;
                    w = Math.Sqrt ( x ) * Math.Sqrt ( 0.5 * ( 1.0 + Math.Sqrt ( 1.0 + r * r ) ) );
                } else {
                    r = x / y;
                    w = Math.Sqrt ( y ) * Math.Sqrt ( 0.5 * ( r + Math.Sqrt ( 1.0 + r * r ) ) );
                }
                if (input.real >= 0.0) {
                    ret.real = (float) w;
                    ret.imag = (float) (input.imag / ( 2.0 * w ));
                } else {
                    ret.imag = (float) (( input.imag >= 0 ) ? w : -w);
                    ret.real = (float) (input.imag / ( 2.0 * ret.imag ));
                }
                return ret;
            }
        }
        /// <summary>
        /// Tangens of float complex number
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Tangens of input</returns>
        public static fcomplex Tan(fcomplex input) {
            fcomplex ci = Cos(input);
            if (ci.real == (float)0.0 && ci.imag == (float)0.0)
                return INF;
            return (Sin(input) / ci);
        }
        /// <summary>
        /// Tangens hyperbolicus of float complex input
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Tangens hyperbolicus</returns>
        public static fcomplex Tanh(fcomplex input) {
            fcomplex si = Sin(input);
            if (si.real == (float)0.0 && si.imag == (float)0.0)
                return INF;
            return (Cos(input) / si);
        }
        /// <summary>
        /// Logarithm of complex input
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Logarithm of input</returns>
        public static fcomplex Log(fcomplex input) {
            fcomplex ret = new fcomplex ();
            ret.real = (float) Math.Log ( Math.Sqrt ( input.real * input.real + input.imag * input.imag ) );
            ret.imag = (float) Math.Atan2 ( input.imag, input.real );
            return ret;
        }
        /// <summary>
        /// Logarithm to base 10
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Logarithm of input</returns>
        public static fcomplex Log10(fcomplex input) {
            return Log(input) / 2.30258509299405f;
        }
        /// <summary>
        /// Logarithm of base 2
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Logarithm of input</returns>
        public static fcomplex Log2(fcomplex input) {
            return Log(input) / 0.693147180559945f;
        }
        /// <summary>
        /// Logarithm of real input 
        /// </summary>
        /// <param name="input">input value - may be negative</param>
        /// <returns>complex logarithm</returns>
        public static fcomplex Log(float input) {
            return Log (new fcomplex(input,0.0f)); 
        }
        /// <summary>
        /// Logarithm of base 10 of real input 
        /// </summary>
        /// <param name="input">input value - may be negative</param>
        /// <returns>complex logarithm of base 10</returns>
        public static fcomplex Log10(float input) {
            return Log(new fcomplex(input,0.0f)) / 2.30258509299405f;
        }
        /// <summary>
        /// Logarithm of base 2
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>complex logarithm of base 2</returns>
        public static fcomplex Log2(float input) {
            return Log(new fcomplex(input,0.0f)) / 0.693147180559945f;
        }
        /// <summary>
        /// convert from polar to cartesian form
        /// </summary>
        /// <param name="magnitude">magnitude</param>
        /// <param name="angle">angle</param>
        /// <returns>float complex number with magnitude <c>magnitude</c> 
        /// and phase <c>angle</c></returns>
        public static fcomplex FromPol(float magnitude, float angle) {
            return new fcomplex (
                (magnitude * (float)Math.Cos ( angle )),
                (magnitude * (float)Math.Sin ( angle ))
            );
        }
        /// <summary>
        /// Convert this float complex number to string 
        /// </summary>
        /// <returns>string representation of this float complex number</returns>
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
                return String.Format(m_precSpecR+m_precSpecI,real,imag); 
            }
        }
        /// <summary>
        /// Magnitude of this float complex number
        /// </summary>
        /// <returns>Magnitude</returns>
        public float Abs() {
            return (float)Math.Sqrt(real * real + imag * imag);
        }
        /// <summary>
        /// Phase angle of this float complex number
        /// </summary>
        /// <returns>Phase angle </returns>
        public double Angle() {
            return (float)Math.Atan2(imag, real);
        }
        /// <summary>
        /// Arcus cosinus of this float complex number
        /// </summary>
        /// <returns>Arcus cosinus</returns>
        public fcomplex Acos() {
            fcomplex ret = new fcomplex(0, -1);
            return fcomplex.Log(fcomplex.Sqrt(this * this - 1)
                + this) * ret;
        }
        /// <summary>
        /// Arcus sinus of this float complex number
        /// </summary>
        /// <returns>Arcus sinus</returns>
        public fcomplex Asin() {
            fcomplex ret = Acos(this);
            ret.real = (float)(Math.PI / 2 - ret.real);
            return ret;
        }
        /// <summary>
        /// Arcus tangens of float complex number
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Arcus tangens of input</returns>
        public static fcomplex Atan(fcomplex input) {
            fcomplex ret = new fcomplex(0, (float)0.5);
            return (ret * Log((fcomplex.i + input) / (fcomplex.i - input)));
        }
        /// <summary>
        /// Round towards next greater integer
        /// </summary>
        /// <param name="input">float complex input</param>
        /// <returns>rounded float complex number</returns>
        /// <remarks>real and imaginary parts are independently rounded 
        /// towards the next integer value towards positive infinity.</remarks>
        public static fcomplex Ceiling (fcomplex input){
            return new fcomplex(
                    (float)Math.Ceiling(input.real),
                    (float)Math.Ceiling(input.imag)
            );
        }
        /// <summary>
        /// Round towards next lower integer
        /// </summary>
        /// <param name="input">float complex input</param>
        /// <returns>rounded float complex number</returns>
        /// <remarks>real and imaginary parts are independently rounded 
        /// towards the next integer value towards negative infinity.</remarks>
        public static fcomplex Floor (fcomplex input){
            return new fcomplex(
                    (float)Math.Floor(input.real),
                    (float)Math.Floor(input.imag)
            );
        }
        /// <summary>
        /// Round mercantilistic
        /// </summary>
        /// <param name="input">float complex number</param>
        /// <returns>rounded number</returns>
        /// <remarks>real and imaginaty parts are rounded independently. </remarks>
        public static fcomplex Round (fcomplex input){
            return new fcomplex(
                    (float)Math.Round(input.real),
                    (float)Math.Round(input.imag)
            );
        }
        /// <summary>
        /// Signum function
        /// </summary>
        /// <param name="input">float complex input</param>
        /// <returns> Signum of input</returns>
        /// <remarks>
        /// For numbers a = 0.0 + 0.0i, sign(a)'s real and imag parts are 0.0. 
        /// For all other numbers sign(a) is the projection onto the unit circle.</remarks>
        public static fcomplex Sign(fcomplex input){
            if (input.real == 0.0 && input.imag == 0.0)
                return new fcomplex(); 
            else {
                float mag = (float)Math.Sqrt(input.real * input.real + input.imag * input.imag); 
                return new fcomplex(
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
        public static fcomplex Truncate (fcomplex input){
            return new fcomplex(
                    (float)Math.Truncate(input.real),
                    (float)Math.Truncate(input.imag)
            );
        }
        /// <summary>
        /// Cosinus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>cosinus of input</returns>
        /// <remarks><para>The cosinus is computed by the trigonometric euler equation: </para>
        /// <para>0.5 * [exp(i input) + exp(-i input)]</para></remarks>
        public static fcomplex Cos(fcomplex input) {
            fcomplex i = new fcomplex(0, 1.0f);
            fcomplex ni = new fcomplex(0, -1.0f);
            return (Exp(i * input) + Exp(ni * input)) / 2.0f;
        }
        /// <summary>
        /// Cosinus hyperbolicus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>cosinus hyperbolicus of input</returns>
        /// <remarks><para>The cosinus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(input) + Exp(-1.0 * input)) / 2.0</para></remarks>
        public static fcomplex Cosh(fcomplex input) {
            return (Exp(input) + Exp(-1.0f * input)) / 2.0f;
        }
        /// <summary>
        /// Sinus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Sinus of input</returns>
        /// <remarks><para>The sinus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(i * input) - Exp(-1.0 * i * input)) / (2.0 * i)</para></remarks>
        public static fcomplex Sin(fcomplex input) {
            fcomplex i = new fcomplex(0, (float)1.0);
            fcomplex mi = new fcomplex(0, (float)-1.0);
            return (Exp(i * input) - Exp(mi * input)) / (2.0 * i);
        }
        /// <summary>
        /// Sinus hyperbolicus
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Sinus hyperbolicus of input</returns>
        /// <remarks><para>The sinus hyperbolicus is computed by the trigonometric euler equation: </para>
        /// <para>(Exp(input) - Exp(-1.0 * input)) / 2.0</para></remarks>
        public static fcomplex Sinh(fcomplex input) {
            fcomplex ret = new fcomplex(0, 2);
            fcomplex i = new fcomplex(0, (float)1.0);
            fcomplex mi = new fcomplex(0, (float)-1.0);
            return (Exp(input) - Exp(-1.0 * input)) / 2.0;
        }
        /// <summary>
        /// exponential / power of base e
        /// </summary>
        /// <returns>power of base e</returns>
        public fcomplex Exp() {
            return fcomplex.FromPol((float)Math.Exp(real), imag);
        }
        /// <summary>
        /// power of fcomplex number, real exponent
        /// </summary>
        /// <param name="exponent">exponent</param>
        /// <returns>new fcomplex number with result</returns>
        public fcomplex Pow(double exponent) {
            fcomplex ret = Log();
            ret.imag *= (float)exponent;
            ret.real *= (float)exponent;
            return ret.Exp();
        }
        /// <summary>
        /// power of fcomplex number, complex exponent
        /// </summary>
        /// <param name="exponent">exponent</param>
        /// <returns>new fcomplex number with result</returns>
        public fcomplex Pow(fcomplex exponent) {
            fcomplex ret = (Log() * exponent);
            return ret.Exp();
        }
        /// <summary>
        /// square root of fcomplex number
        /// </summary>
        /// <returns>square root</returns>
        public fcomplex Sqrt() {
            // Reference : numerical recipes in C: Appendix C
            fcomplex ret = new fcomplex();
            double x, y, w, r;
            if ( real == 0.0 && imag == 0.0)
                return ret;
            else {
                x = (float)Math.Abs(real);
                y = (float)Math.Abs( imag);
                if (x >= y) {
                    r = y / x;
                    w = Math.Sqrt(x) * Math.Sqrt(0.5 * (1.0 + Math.Sqrt(1.0 + r * r)));
                } else {
                    r = x / y;
                    w = Math.Sqrt(y) * Math.Sqrt(0.5 * (r + Math.Sqrt(1.0 + r * r)));
                }
                if ( real >= 0.0) {
                    ret.real = (float)w;
                    ret.imag = (float)( imag / (2.0 * w));
                } else {
                    ret.imag = (float)(( imag >= 0) ? w : -w);
                    ret.real = (float)( imag / (2.0 * ret.imag));
                }
                return ret;
            }
        }
        /// <summary>
        /// logarithm of fcomplex number
        /// </summary>
        /// <returns>natural logarithm</returns>
        /// <remarks>The logarithm of a complex number A is defined as follows: <br />
        /// <list type="none"><item>real part: log(abs(A))</item>
        /// <item>imag part: Atan2(imag(A),real(A))</item></list>
        /// </remarks>
        public fcomplex Log() {
            fcomplex ret = new fcomplex();
            ret.real = (float)Math.Log(Math.Sqrt( real *  real +  imag *  imag));
            ret.imag = (float)Math.Atan2( imag,  real);
            return ret;
        }
        /// <summary>
        /// test if any of real or imaginary parts are NAN's
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is not a number</returns>
        public static bool IsNaN(fcomplex input) {
            if (Single.IsNaN(input.real) || Single.IsNaN(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are infinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is infinite</returns>
        public static bool IsInfinity(fcomplex input) {  
            if (Single.IsInfinity(input.real) || Single.IsInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are pos. infinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is positive infinite</returns>
        public static bool IsPositiveInfinity(fcomplex input) {  
            if (Single.IsPositiveInfinity(input.real) || Single.IsPositiveInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are neg. infinite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real or imag part is negative infinite</returns>
        public static bool IsNegativeInfinity(fcomplex input) {  
            if (Single.IsNegativeInfinity(input.real) || Single.IsNegativeInfinity(input.imag)) 
                return true; 
            else 
                return false; 
        }
        /// <summary>
        /// test if any of real or imaginary parts are finite
        /// </summary>
        /// <param name="input">complex number to test</param>
        /// <returns>true if any of real and imag part is finite</returns>
        public static bool IsFinite (fcomplex input) {
            if (ILMath.isfinite(input.real) && ILMath.isfinite(input.imag)) 
                return true; 
            else 
                return false; 
        }

        #region CAST_OPERATORS
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(double a) {
            return new fcomplex((float)a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(float a) {
            return new fcomplex(a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(byte a) {
            return new fcomplex(a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(char a) {
            return new fcomplex(a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(Int16 a) {
            return new fcomplex(a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(Int32 a) {
            return new fcomplex((float)a, 0.0F);    
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(Int64 a) {
            return new fcomplex((float)a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(UInt16 a) {
            return new fcomplex((float)a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(UInt32 a) {
            return new fcomplex((float)a, 0.0F);
        }
        /// <summary>
        /// implicit cast real number into complex number
        /// </summary>
        /// <param name="a">real number</param>
        /// <returns>fcomplex number with real part equals a</returns>
        public static implicit operator fcomplex(UInt64 a) {
            return new fcomplex((float)a, 0.0F);
        }

        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator double(fcomplex a) {
            return a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator float(fcomplex a) {
            return (float)a.real;
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator byte(fcomplex a) {
            return (byte) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator char(fcomplex a) {
            return (char) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator Int16(fcomplex a) {
            return (Int16) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator Int32(fcomplex a) {
            return (Int32) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator Int64(fcomplex a) {
            return (Int64) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator UInt16(fcomplex a) {
            return (UInt16) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator UInt32(fcomplex a) {
            return (UInt32) a.real; 
        }
        /// <summary>
        /// explicit cast complex number into real number
        /// </summary>
        /// <param name="a">complex number</param>
        /// <returns>real number with real part of a</returns>
        public static explicit operator UInt64(fcomplex a) {
            return (UInt64) a.real; 
        }
        /// <summary>
        /// test if real and imag part are zero
        /// </summary>
        /// <returns>true if real and imag parts are zero, false else</returns>
        public bool iszero() {
            if (real == 0.0f && imag == 0.0f) 
                return true; 
            else 
                return false; 
        }
        #endregion CAST_OPERATORS

    }
    
}
