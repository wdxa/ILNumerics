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

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART
/*!HC:TYPELIST:
<hycalper>
<type>
    <source>
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source>
        inCls2
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
    <destination>fcomplex</destination>
</type>
</hycalper>
*/
        public static bool isequalwithequalnans(/*HC:inCls1*/ ILArray<double> A,/*HC:inCls2*/ ILArray<double> B) {
            if (object.Equals(A,null) || object.Equals(B,null)) {
                return !(object.Equals(A,null) ^ object.Equals(B,null)); 
            }
            if (A.IsEmpty && B.IsEmpty) return true; 
            if (!A.Dimensions.IsSameSize(B.Dimensions)) return false; 
            int pos = 0; 
            foreach (/*!HC:inArr1*/ double a in A.Values) {
                /*!HC:inArr1*/ double b = B.GetValue(pos++); 
                if (/*!HC:inArr1*/ double .IsNaN(a) && /*!HC:inArr1*/ double .IsNaN(b)) continue; 
                if (/*!HC:inArr1*/ double .IsInfinity(a) && /*!HC:inArr1*/ double .IsInfinity(b)) continue; 
                if (b != a) return false; 
            }
            return true;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        public static bool isequalwithequalnans(/*HC:*/ ILArray<fcomplex> A,/*HC:*/ ILArray<fcomplex> B) {
            if (object.Equals(A,null) || object.Equals(B,null)) {
                return !(object.Equals(A,null) ^ object.Equals(B,null)); 
            }
            if (A.IsEmpty && B.IsEmpty) return true; 
            if (!A.Dimensions.IsSameSize(B.Dimensions)) return false; 
            int pos = 0; 
            foreach ( fcomplex a in A.Values) {
                fcomplex b = B.GetValue(pos++); 
                if ( fcomplex .IsNaN(a) &&  fcomplex .IsNaN(b)) continue; 
                if ( fcomplex .IsInfinity(a) &&  fcomplex .IsInfinity(b)) continue; 
                if (b != a) return false; 
            }
            return true;
        }

        public static bool isequalwithequalnans(/*HC:*/ ILArray<float> A,/*HC:*/ ILArray<float> B) {
            if (object.Equals(A,null) || object.Equals(B,null)) {
                return !(object.Equals(A,null) ^ object.Equals(B,null)); 
            }
            if (A.IsEmpty && B.IsEmpty) return true; 
            if (!A.Dimensions.IsSameSize(B.Dimensions)) return false; 
            int pos = 0; 
            foreach ( float a in A.Values) {
                float b = B.GetValue(pos++); 
                if ( float .IsNaN(a) &&  float .IsNaN(b)) continue; 
                if ( float .IsInfinity(a) &&  float .IsInfinity(b)) continue; 
                if (b != a) return false; 
            }
            return true;
        }

        public static bool isequalwithequalnans(/*HC:*/ ILArray<complex> A,/*HC:*/ ILArray<complex> B) {
            if (object.Equals(A,null) || object.Equals(B,null)) {
                return !(object.Equals(A,null) ^ object.Equals(B,null)); 
            }
            if (A.IsEmpty && B.IsEmpty) return true; 
            if (!A.Dimensions.IsSameSize(B.Dimensions)) return false; 
            int pos = 0; 
            foreach ( complex a in A.Values) {
                complex b = B.GetValue(pos++); 
                if ( complex .IsNaN(a) &&  complex .IsNaN(b)) continue; 
                if ( complex .IsInfinity(a) &&  complex .IsInfinity(b)) continue; 
                if (b != a) return false; 
            }
            return true;
        }

#endregion HYCALPER AUTO GENERATED CODE

        public static bool isequalwithequalnans(ILBaseArray A, ILBaseArray B) {
            if (A is ILArray<double>) {
                if (B is ILArray<double>) {
                    return isequalwithequalnans(A as ILArray<double>,B as ILArray<double>); 
                } else if (B is ILArray<complex>) {
                    ILArray<complex> Bc = B as ILArray<complex>; 
                    if (Bc == null) return false; 
                    if (any(imag(Bc)).NumberTrues > 0) return false; 
                    return isequalwithequalnans(A as ILArray<double>, real(Bc)); 
                } return false; 
            } else if (A is ILArray<float>) {
                if (B is ILArray<float>) {
                    return isequalwithequalnans(A as ILArray<float>,B as ILArray<float>); 
                } else if (B is ILArray<fcomplex>) {
                    ILArray<fcomplex> Bf = B as ILArray<fcomplex>; 
                    if (Bf == null) return false; 
                    if (any(imag(Bf)).NumberTrues > 0) return false; 
                    return isequalwithequalnans(A as ILArray<fcomplex>, real(Bf)); 
                } return false; 
            } else if (A is ILArray<complex>) {
                if (B is ILArray<complex>) {
                    return isequalwithequalnans(A as ILArray<complex>, B as ILArray<complex>); 
                } else if (B is ILArray<double>) {
                    ILArray<complex> Ac = A as ILArray<complex>; 
                    if (A == null) return false; 
                    if (any(imag(Ac)).NumberTrues > 0) return false; 
                    return isequalwithequalnans(real(Ac),B as ILArray<double>); 
                } else return false; 
            } else if (A is ILArray<fcomplex>) {
                if (B is ILArray<fcomplex>) {
                    return isequalwithequalnans(A as ILArray<fcomplex>, B as ILArray<fcomplex>); 
                } else if (B is ILArray<float>) {
                    ILArray<fcomplex> Af = A as ILArray<fcomplex>; 
                    if (Af == null) return false; 
                    if (any(imag(Af)).NumberTrues > 0) return false; 
                    return isequalwithequalnans(real(Af),B as ILArray<float>); 
                } else return false; 
            } else {
                return A.Equals(B); 
            }
        }
    }
}
