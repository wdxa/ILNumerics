using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Test {
    public class TestHelper : ILMath {
            
        public static bool TestEqualSloppy (ILBaseArray A, ILBaseArray B) {
            if (A is ILArray<double>) {
                if (B is ILArray<double>) {
                    return isequalwithequalnans(A as ILArray<double>,B as ILArray<double>); 
                } else if (B is ILArray<complex>) {
                    ILArray<complex> Bc = B as ILArray<complex>; 
                    if (Bc == null) return false;
                    if (any(imag(Bc)).NumberTrues > 0) {
                        //if (any(isinf(imag(Bc)) != isinf(real(Bc))).NumberTrues > 0) return false;  
                        if (any(imag(Bc)[find(!isinf(Bc))]).NumberTrues > 0) return false; 
                    }
                    return isequalwithequalnans(A as ILArray<double>, real(Bc)); 
                } return false; 
            } else if (A is ILArray<float>) {
                if (B is ILArray<float>) {
                    return isequalwithequalnans(A as ILArray<float>,B as ILArray<float>); 
                } else if (B is ILArray<fcomplex>) {
                    ILArray<fcomplex> Bf = B as ILArray<fcomplex>; 
                    if (Bf == null) return false; 
                    if (any(imag(Bf)).NumberTrues > 0) {
                        //if (any(isinf(imag(Bf)) != isinf(real(Bf))).NumberTrues > 0) return false;  
                        if (any(imag(Bf)[find(!isinf(Bf))]).NumberTrues > 0) return false; 
                    }
                    return isequalwithequalnans(A as ILArray<fcomplex>, real(Bf)); 
                } return false; 
            } else if (A is ILArray<complex>) {
                if (B is ILArray<complex>) {
                    return isequalwithequalnans(A as ILArray<complex>, B as ILArray<complex>); 
                } else if (B is ILArray<double>) {
                    ILArray<complex> Ac = A as ILArray<complex>; 
                    if (A == null) return false; 
                    if (any(imag(Ac)).NumberTrues > 0) {
                        //if (any(isinf(imag(Ac)) != isinf(real(Ac))).NumberTrues > 0) return false;  
                        if (any(imag(Ac)[find(!isinf(Ac))]).NumberTrues > 0) return false; 
                    }
                    return isequalwithequalnans(real(Ac),B as ILArray<double>); 
                } else return false; 
            } else if (A is ILArray<fcomplex>) {
                if (B is ILArray<fcomplex>) {
                    return isequalwithequalnans(A as ILArray<fcomplex>, B as ILArray<fcomplex>); 
                } else if (B is ILArray<float>) {
                    ILArray<fcomplex> Af = A as ILArray<fcomplex>; 
                    if (Af == null) return false; 
                    if (any(imag(Af)).NumberTrues > 0) {
                        //if (any(isinf(imag(Af)) != isinf(real(Af))).NumberTrues > 0) return false;  
                        if (any(imag(Af)[find(!isinf(Af))]).NumberTrues > 0) return false; 
                    }
                    return isequalwithequalnans(real(Af),B as ILArray<float>); 
                } else return false; 
            } else {
                return A.Equals(B); 
            }
        }
    }
}
