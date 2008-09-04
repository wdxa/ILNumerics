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
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Misc; 

namespace ILNumerics.Test {
    public class TESTILComplex : ILTest {

        public override void Run() {
            base.Run();
			Header();
            Test_conj();
            Test_COnjComplexTranspose.Run(); 
            Test_ComplexDiv();
            Test_AccuracyUnderflow(); 
			Footer();
        }

        private void Test_conj() {
            // test for common matrix 4x3
            ILArray<complex> A = new complex[,] {
                {new complex(1,2), new complex(3,4), new complex(5,6)},
                {new complex(7,8), new complex(9,10), new complex(11,12)},
                {new complex(13,14), new complex(15,16), new complex(17,18)},
                {new complex(19,20), new complex(21,22), new complex(23,24)}};
            ILArray<fcomplex> Af = ILMath.tofcomplex(A); 
            Test_isConj(A,ILMath.conj(A)); 
            Test_isfConj(Af,ILMath.conj(Af));
            // test on reference matrix
            Test_isConj(A,ILMath.conj(A.R)); 
            Test_isfConj(Af,ILMath.conj(Af.R));
            // test on 2x2x3 matrix (reference)
            A = A.Reshape(new ILDimension(2,2,3)).R;
            if (!A.IsReference) 
                throw new Exception("Unable to test conj() for reference 2x2x3!"); 
            Af = Af.Reshape(new ILDimension(2,2,3)).R; 
            if (!Af.IsReference) 
                throw new Exception("Unable to test conj() for reference 2x2x3!"); 
            Test_isConj(A,ILMath.conj(A)); 
            Test_isfConj(Af,ILMath.conj(Af));
            // test those on dense array 
            Test_isConj(A,ILMath.conj(A.C)); 
            Test_isfConj(Af,ILMath.conj(Af.C));
            // test for empty
            A = ILArray<complex>.empty();
            Af = ILArray<fcomplex>.empty();
            Test_isConj(A,ILMath.conj(A)); 
            Test_isfConj(Af,ILMath.conj(Af)); 
            // test on vector
            A = new complex[] { new complex(1,2), new complex(3,4), new complex(5,6)}; 
            Af = ILMath.tofcomplex(A); 
            Test_isConj(A,ILMath.conj(A)); 
            Test_isfConj(Af,ILMath.conj(Af)); 
            // transpose 
            Test_isConj(A.T,ILMath.conj(A.T)); 
            Test_isfConj(Af.T,ILMath.conj(Af.T)); 
            // test on scalar 
            A = A[2]; Af = Af[2]; 
            Test_isConj(A,ILMath.conj(A)); 
            Test_isfConj(Af,ILMath.conj(Af)); 

        }

        private void Test_isConj(ILArray<complex> A, ILArray<complex> conjA) {
            try {
                if (A.IsEmpty) {
                    if (!conjA.IsEmpty) 
                        throw new Exception("conj of empty array must be empty!");
                    else {
                        Success(); 
                        return; 
                    }
                }
                if (!A.Dimensions.IsSameSize(conjA.Dimensions))
                    throw new Exception("dimensions must match!"); 
                if (ILMath.sumall(ILMath.real(A) != ILMath.real(conjA)) > 0.0) 
                    throw new Exception("real parts must match!");
                if (ILMath.sumall(-ILMath.imag(A) != ILMath.imag(conjA)) > 0.0) 
                    throw new Exception("imag parts must be the inverse of each other!");
                Success(); 
            } catch (Exception exc) {
                Error(exc.Message); 
            }
        }
        private void Test_isfConj(ILArray<fcomplex> A, ILArray<fcomplex> conjA) {
            try {
                if (A.IsEmpty) {
                    if (!conjA.IsEmpty) 
                        throw new Exception("conj of empty array must be empty!");
                    else { 
                        Success(); 
                        return; 
                    }
                }
                if (!A.Dimensions.IsSameSize(conjA.Dimensions))
                    throw new Exception("dimensions must match!"); 
                if (ILMath.sumall(ILMath.real(A) != ILMath.real(conjA)) > 0.0) 
                    throw new Exception("real parts must match!");
                if (ILMath.sumall(-ILMath.imag(A) != ILMath.imag(conjA)) > 0.0) 
                    throw new Exception("imag parts must be the inverse of each other!");
                Success(); 
            } catch (Exception exc) {
                Error(exc.Message); 
            }
        }

        private void Test_AccuracyUnderflow() {
            float c = 10e37f, d = 10e-37f, e = 10e29f, f = 10e-29f; 
            fcomplex A = new fcomplex(c,d);
            fcomplex B = new fcomplex(e,f); 
            fcomplex C = A / B; 
            double cd = 10e70, dd = 10e-70, ed = 10e56, fd = 10e-56; 
            complex Ad = new complex(cd,dd);
            complex Bd = new complex(ed,fd); 
            complex Cd = Ad / Bd; 
            // Smith(1) formula
            fcomplex t1 = f * 1/e; 
            fcomplex t2 = f * t1; 
            fcomplex t3 = e + t2; // 10^56 ?
            fcomplex t4 = c * t1; 
            fcomplex t5 = d - t4; // 10^-56 ? 
            fcomplex b = t5 / t3; 
            Success(); 
        }
        private void Test_ComplexDiv() {
            complex a = new complex(1,1); 
            complex b = new complex(1,0); 
            complex y = 1 / a; 
            ILArray<complex> A = new complex[]{new complex(1,1),new complex(4,5)}; 
            A = A.T; 
            if (y != ILMath.ccomplex(0.5,-0.5)) 
                throw new Exception("complex: 1 / 1+i -> wrong result!"); 
            Success(); 
        }
        private class Test_COnjComplexTranspose : ILMath {
            public static void Run() {
                ILArray<complex> A = 1 / new complex(1,1); 
                if (!A.Equals (ccomplex(0.5,-0.5))) 
                    throw new Exception("complex: 1 / 1+i -> wrong result!");  
                ILArray<complex> y = ccomplex(real(A), -imag(A)).T; 
                if (!y.Equals (conj(A))) // it's a scalar!
                    throw new Exception("conj(complex) -> wrong result!");  
            }
        }
    
    }
}
