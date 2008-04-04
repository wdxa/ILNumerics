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
using ILNumerics.Storage;
using ILNumerics.Misc;
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
</hycalper>
 */
namespace ILNumerics {
    /// <summary>
    /// Extensive numerical machine parameter infos - single precision
    /// </summary>
    public struct MachineParameterSingle {
        /// <summary>
        /// radix
        /// </summary>
        public int ibeta; 
        /// <summary>
        /// number of base digits(bits) in the mantissa
        /// </summary>
        public int it;
        /// <summary>
        /// rounding and underflow information.  
        /// </summary>
        /// <remarks><list type="bullet"><listheader>rounding properties</listheader>
        /// <item>2,5: IEEE rounding conform </item>
        /// <item>1,4: not IEEE conform rounding </item>
        /// <item>0,3: truncating - no rounding </item></list>
        /// <list type="bullet"><listheader>under-/ overflow. numbers below xmin will be interpreted as... </listheader>
        /// <item>0,1,2: zero</item>
        /// <item>3,4,5: xmin (IEEE conform)</item></list></remarks>
        public int irnd; 
        /// <summary>
        /// number of guard digits in the product of 2 mantissas
        /// </summary>
        public int ngrd; 
        /// <summary>
        /// exponent of the smalles number ibeta^machep &gt; 1.0
        /// </summary>
        public int machep; 
        /// <summary>
        /// exponent of smallest number ibeta^negep wich may be substracted from 1.0, giving a result not equal to 1.0
        /// </summary>
        public int negep; 
        /// <summary>
        /// number of exponent bits 
        /// </summary>
        public int iexp; 
        /// <summary>
        /// smallest power of ibeta without leading zeros in the mantissa
        /// </summary>
        public int minexp; 
        /// <summary>
        /// smalles power of ibeta where overflow occours
        /// </summary>
        public int maxexp; 
        /// <summary>
        /// distance between the smallest number &gt; 1.0, distinguishable from 1.0 and 1.0
        /// </summary>
        /// <remarks>This number is computed by ibeta <sup>machep</sup>.</remarks>
        public float eps; 
        /// <summary>
        /// alternative eps. ibeta <sup>negep</sup>
        /// </summary>
        public float epsneg; 
        /// <summary>
        /// smallest floating point number
        /// </summary>
        public float xmin; 
        /// <summary>
        /// largest floating point number
        /// </summary>
        public float xmax;
    }
    /// <summary>
    /// Extensive numerical machine parameter infos - double precision
    /// </summary>
    public struct MachineParameterDouble {
        /// <summary>
        /// radix
        /// </summary>
        public int ibeta; 
        /// <summary>
        /// number of base digits(bits) in the mantissa
        /// </summary>
        public int it;
        /// <summary>
        /// rounding and underflow information.  
        /// </summary>
        /// <remarks><list type="bullet"><listheader>rounding properties</listheader>
        /// <item>2,5: IEEE rounding conform </item>
        /// <item>1,4: not IEEE conform rounding </item>
        /// <item>0,3: truncating - no rounding </item></list>
        /// <list type="bullet"><listheader>under-/ overflow. numbers below xmin will be interpreted as... </listheader>
        /// <item>0,1,2: zero</item>
        /// <item>3,4,5: xmin (IEEE conform)</item></list></remarks>
        public int irnd; 
        /// <summary>
        /// number of guard digits in the product of 2 mantissas
        /// </summary>
        public int ngrd; 
        /// <summary>
        /// exponent of the smalles number ibeta^machep &gt; 1.0
        /// </summary>
        public int machep; 
        /// <summary>
        /// exponent of smallest number ibeta^negep wich may be substracted from 1.0, giving a result not equal to 1.0
        /// </summary>
        public int negep; 
        /// <summary>
        /// number of exponent bits 
        /// </summary>
        public int iexp; 
        /// <summary>
        /// smallest power of ibeta without leading zeros in the mantissa
        /// </summary>
        public int minexp; 
        /// <summary>
        /// smalles power of ibeta where overflow occours
        /// </summary>
        public int maxexp; 
        /// <summary>
        /// distance between the smallest number &gt; 1.0, distinguishable from 1.0 and 1.0
        /// </summary>
        /// <remarks>This number is computed by ibeta <sup>machep</sup>.</remarks>
        public double eps; 
        /// <summary>
        /// alternative eps. ibeta <sup>negep</sup>
        /// </summary>
        public double epsneg; 
        /// <summary>
        /// smallest floating point number
        /// </summary>
        public double xmin; 
        /// <summary>
        /// largest floating point number
        /// </summary>
        public double xmax;
    }
}


namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {

        /// <summary>
        /// Definition of pi
        /// </summary>
        /// <remarks>this is an alias for Math.PI - supplied for convinience only</remarks>
        public static readonly double pi = Math.PI; 

        private static MachineParameterDouble m_machparDouble; 
        /// <summary>
        /// give extensive numerical machine parameter informations - double precision
        /// </summary>
        public static MachineParameterDouble MachineParameterDouble {
            get {
                return m_machparDouble;
            }
        }
        private static MachineParameterSingle m_machparFloat; 
        /// <summary>
        /// give extensive numerical machine parameter informations - single precision
        /// </summary>
        public static MachineParameterSingle MachineParameterFloat {
            get {
                return m_machparFloat; 
            }
        }
        /// <summary>
        /// Determine machine specific parameter
        /// </summary>
        /// <remarks>Source: Numerical Recipes in C, p.892</remarks>
        internal static void macharF(ref int ibeta, ref int it, ref int irnd, ref int ngrd, ref int machep, ref int negep,
                        ref int iexp, ref int minexp, ref int maxexp, ref float eps, ref float epsneg, ref float xmin, ref float xmax) {
            int i, itemp, iz, j, k, mx, nxres; 
            float a,b,beta,betah,betain,one,t,temp,temp1,tempa,two,y,z,zero;

            one= (float)1; 
            two = one + one; 
            zero = one - one; 
            a = one; 
            do {
                a += a; 
                temp = a+one; 
                temp1= temp-a; 
            } while (temp1-one == zero); 
            b = one; 
            do {
                b += b; 
                temp=a+b; 
                itemp=(int)(temp-a); 
            } while (itemp == 0); 
            ibeta = itemp; 
            beta = (float)ibeta; 
            it = 0; 
            b = one; 
            do {
                ++it; 
                b *= beta;
                temp = b +one; 
                temp1 = temp -b; 
            }while (temp1-one == zero);
            irnd = 0; 
            betah = beta / two; 
            temp = a + betah; 
            if (temp-a != zero) irnd = 1; 
            tempa = a + beta; 
            temp = tempa + betah; 
            if (irnd == 0 && temp - tempa != zero) irnd = 2; 
            negep = it + 3; 
            betain = one / beta; 
            a = one; 
            for (i = 1; i <= negep; i++) a *= betain; 
            b =a; 
            for (;;) {
                temp = one -a; 
                if (temp-one != zero)  break; 
                a *= beta; 
                --negep; 
            } 
            negep = -negep; 
            epsneg = a; 
            machep = -it -3; 
            a = b; 
            for (;;) {
                temp = one +a; 
                if (temp - one != zero) break; 
                a *= beta; 
                ++machep; 
            }
            eps = a; 
            ngrd =0; 
            temp = one + eps;
            if (irnd == 0 && temp * one - one != zero) ngrd = 1;
            i = 0; 
            k = 1; 
            z = betain; 
            t = one + eps; 
            nxres = 0; 
            for (;;) {
                y = z; 
                z = y *y;
                a = z * one; 
                temp = z * t; 
                if (a + a == zero || (float)Math.Abs(z) >= y) break; 
                temp1 = temp * betain; 
                if (temp1 * beta == z) break; 
                ++i; 
                k += k; 
            }
            if (ibeta != 10) {
                iexp = i+1; 
                mx = k + k; 
            }else {
                iexp = 2; 
                iz = ibeta; 
                while (k >= iz) {
                    iz *= ibeta; 
                    ++iexp; 
                }
                mx = iz + iz-1; 
            }
            for (;;) {
                xmin = y; 
                y *= betain;
                a = y * one; 
                temp = y * t; 
                if (a+a != zero && (float)Math.Abs(y) < xmin) {
                    ++k; 
                    temp1 = temp* betain; 
                    if (temp1 * beta == y && temp != y) {
                        nxres = 3; 
                        xmin = y; 
                        break; 
                    }
                }
                else break; 
            }
            minexp = -k; 
            if (mx <= k + k - 3 && ibeta != 10) {
                mx += mx; 
                ++iexp; 
            }
            maxexp = mx + minexp; 
            irnd += nxres; 
            if (irnd >= 2) maxexp -= 2; 
            i = maxexp + minexp; 
            if (ibeta == 2 && i != 0) --maxexp; 
            if (i > 20) --maxexp; 
            if (a != y) maxexp -= 2;
            xmax = one -epsneg; 
            if (maxexp * one != xmax) xmax = one - beta * epsneg; 
            xmax /= xmin * beta * beta * beta; 
            i = maxexp + minexp + 3; 
            for (j = 1; j <= i; j++){ 
                if (ibeta == 2) xmax += xmax; 
                else xmax *= beta; 
            }
        }

        /// <summary>
        /// Determine machine specific parameter (double precision)
        /// </summary>
        /// <remarks>Source: Numerical Recipes in C, p.892</remarks>
        internal static void macharD(ref int ibeta, ref int it, ref int irnd, ref int ngrd, ref int machep, ref int negep,
                        ref int iexp, ref int minexp, ref int maxexp, ref double eps, ref double epsneg, ref double xmin, ref double xmax) {
            int i, itemp, iz, j, k, mx, nxres; 
            double a,b,beta,betah,betain,one,t,temp,temp1,tempa,two,y,z,zero;

            one= (double)1; 
            two = one + one; 
            zero = one - one; 
            a = one; 
            do {
                a += a; 
                temp = a+one; 
                temp1= temp-a; 
            } while (temp1-one == zero); 
            b = one; 
            do {
                b += b; 
                temp=a+b; 
                itemp=(int)(temp-a); 
            } while (itemp == 0); 
            ibeta = itemp; 
            beta = (double)ibeta; 
            it = 0; 
            b = one; 
            do {
                ++it; 
                b *= beta;
                temp = b +one; 
                temp1 = temp -b; 
            }while (temp1-one == zero);
            irnd = 0; 
            betah = beta / two; 
            temp = a + betah; 
            if (temp-a != zero) irnd = 1; 
            tempa = a + beta; 
            temp = tempa + betah; 
            if (irnd == 0 && temp - tempa != zero) irnd = 2; 
            negep = it + 3; 
            betain = one / beta; 
            a = one; 
            for (i = 1; i <= negep; i++) a *= betain; 
            b =a; 
            for (;;) {
                temp = one -a; 
                if (temp-one != zero)  break; 
                a *= beta; 
                --negep; 
            } 
            negep = -negep; 
            epsneg = a; 
            machep = -it -3; 
            a = b; 
            for (;;) {
                temp = one +a; 
                if (temp - one != zero) break; 
                a *= beta; 
                ++machep; 
            }
            eps = a; 
            ngrd =0; 
            temp = one + eps;
            if (irnd == 0 && temp * one - one != zero) ngrd = 1;
            i = 0; 
            k = 1; 
            z = betain; 
            t = one + eps; 
            nxres = 0; 
            for (;;) {
                y = z; 
                z = y *y;
                a = z * one; 
                temp = z * t; 
                if (a + a == zero || (double)Math.Abs(z) >= y) break; 
                temp1 = temp * betain; 
                if (temp1 * beta == z) break; 
                ++i; 
                k += k; 
            }
            if (ibeta != 10) {
                iexp = i+1; 
                mx = k + k; 
            }else {
                iexp = 2; 
                iz = ibeta; 
                while (k >= iz) {
                    iz *= ibeta; 
                    ++iexp; 
                }
                mx = iz + iz-1; 
            }
            for (;;) {
                xmin = y; 
                y *= betain;
                a = y * one; 
                temp = y * t; 
                if (a+a != zero && (double)Math.Abs(y) < xmin) {
                    ++k; 
                    temp1 = temp* betain; 
                    if (temp1 * beta == y && temp != y) {
                        nxres = 3; 
                        xmin = y; 
                        break; 
                    }
                }
                else break; 
            }
            minexp = -k; 
            if (mx <= k + k - 3 && ibeta != 10) {
                mx += mx; 
                ++iexp; 
            }
            maxexp = mx + minexp; 
            irnd += nxres; 
            if (irnd >= 2) maxexp -= 2; 
            i = maxexp + minexp; 
            if (ibeta == 2 && i != 0) --maxexp; 
            if (i > 20) --maxexp; 
            if (a != y) maxexp -= 2;
            xmax = one -epsneg; 
            if (maxexp * one != xmax) xmax = one - beta * epsneg; 
            xmax /= xmin * beta * beta * beta; 
            i = maxexp + minexp + 3; 
            for (j = 1; j <= i; j++){ 
                if (ibeta == 2) xmax += xmax; 
                else xmax *= beta; 
            }
        }

    }
}
