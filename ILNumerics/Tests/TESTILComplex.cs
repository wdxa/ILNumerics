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

namespace ILNumerics.Test {
    public class TESTILComplex : ILTest {

        public override void Run() {
            base.Run();
			Header();
            Test_ComplexDiv();
            Test_AccuracyUnderflow(); 
			Footer();
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
            if (y != ILMath.ccomplex(0.5,-0.5)) 
                throw new Exception("complex: 1 / 1+i -> wrong result!"); 
            Success(); 
        }
    
    }
}
