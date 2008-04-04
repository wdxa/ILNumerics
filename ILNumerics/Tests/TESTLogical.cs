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
using ILNumerics.BuiltInFunctions;
using ILNumerics.Misc;
using ILNumerics.Test;
using ILNumerics.Exceptions; 
using ILDA = ILNumerics.ILArray<double>;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
 

namespace ILNumerics.Test {
	public class TESTLogical : ILTest {

        public override void Run() {
			 // tests: creation
			// =================
			Header();
            Test_NumberNonZero(); 
            Test_Invert(); 
			Footer();
		} 

        public void Test_Invert () {
            int errorCode = 1; 
            try{
                ILArray<double> A = new double[]{1,2,3,4,5,6};
                ILLogicalArray d = A > 1; 
                ILLogicalArray Res = !d; 
                if (Res.NumberTrues != 1) 
                    throw new Exception("invalid number of non zeros detected");
                ILLogicalArray result = new byte[]{1,0,0,0,0,0};  
                if (!Res.Equals(result))  
                    throw new Exception("invalid values detected");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }

        public void  Test_NumberNonZero() {
            int errorCode = 1; 
            try{
                ILArray<double> A = new double[]{1,2,3,4,5,6};
                ILLogicalArray d = A > 1; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                // check after setvalue : current '1'
                d[1] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                d[1] = false; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d[0] = false; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d[0] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                d[2] = null; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d[0] = null; 
                if (d.NumberTrues != 3) 
                    throw new Exception("invalid number of non zero elements");
                d[8,1] = true; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                // test string index access 
                errorCode = 2; 
                d = A > 1; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                // check after setvalue : current '1'
                d["1"] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                d["1"] = false; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d["0"] = false; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d["0"] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                d["2"] = null; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                d["0"] = null; 
                if (d.NumberTrues != 3) 
                    throw new Exception("invalid number of non zero elements");
                d["8;1"] = true; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                // array index access 
                errorCode = 3; 
                ILArray<double> ind = new double[]{1};
                d = A > 1; 
                d[ind] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                // check after setvalue : current '1'
                ind = 0.0; 
                d[ind] = true; 
                if (d.NumberTrues != 6) 
                    throw new Exception("invalid number of non zero elements");
                ind = 1; 
                d[ind] = false; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                ind = 0; 
                d[ind] = false; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                ind = 0; 
                d[ind] = true; 
                if (d.NumberTrues != 5) 
                    throw new Exception("invalid number of non zero elements");
                ind = 2; 
                d[ind] = null; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                ind = 0; 
                d[ind] = null; 
                if (d.NumberTrues != 3) 
                    throw new Exception("invalid number of non zero elements");
                ind[1] = 8; 
                d[ind,1] = true; 
                if (d.NumberTrues != 4) 
                    throw new Exception("invalid number of non zero elements");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
	}
}
