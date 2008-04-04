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
using ILNumerics.Test;
using ILNumerics.BuiltInFunctions; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ILNumerics.Test {
	public class TESTILCell : ILTest {

		public override void Run() {
			Header();
            Test_Empty(); 
			Test_Addressing();
			//Test_Test();
			//Test_serialize(); 
            Footer();
		}

        private void Test_Test() {
            int errorCode = 0; 
            try {
                ILCell C = new ILCell(2,3); 
                // than create another cell holding an ILArray<double>,
                ILCell Ci = new ILCell(2,4); 
                Ci[0] = ILMath.rand(4,5);
                // store this as inner cell of C
                C[0] = Ci;                 
                Success();
			} catch (Exception e) {
				Error(errorCode ,e.Message);
			}
        }
        public void Test_Empty() {
            int errorCode = 0; 
            try {
				ILBaseArray[] data = new ILBaseArray[60]; 
				for (int i = 0; i < data.Length; i++)
					data[i] = new ILArray<Int16>(new Int16[1]{(Int16)i}); 
				ILCell A = new ILCell(data,20,3);
                ILArray<double> ind = new double[0]{};
                ILBaseArray elem = A[null,ind]; 
                if (!(elem is ILCell)) 
                    throw new Exception("empty return from ILCell should be ILCell");
                Success();
			} catch (Exception e) {
				Error(errorCode ,e.Message);
			}
		}

        public void Test_Addressing() {
            int errorCode = 0; 
            try {
				ILBaseArray[] data = new ILBaseArray[60]; 
				for (int i = 0; i < data.Length; i++)
					data[i] = new ILArray<Int16>(new Int16[1]{(Int16)i}); 
				ILCell A = new ILCell(data,20,3);
                A.Name = "A"; 
				errorCode = 1;
                A[1,1] = ILMath.vector(10,100);
                A[2,1] = ILMath.vector(-10,-1,-100); 
                errorCode = 2; 
                // test subarray access: single
                ILBaseArray ret = A[23]; 
                ret.Name = "ret"; 
                errorCode = 3;
                // single element returned should be inner ILBaseArray
                if (!(ret is ILArray<Int16>))
                    throw new Exception("ILCell: single element returned should be of ILArray<double> type");
                ILArray<Int16> a23 = (ILArray<Int16>)ret; 
                a23.Name = "a23"; 
                if (!a23.IsScalar || a23 != 23.0) 
                    throw new Exception("ILCell: returned element value mismatch! Expected: 23, found:" + a23.GetValue(0));
                errorCode = 4;
                // test subarray access: multiple via vector (sequential)
                // - put Cell into cell 
                ILArray<double> element1 = ILMath.vector(10,2,20); 
                element1.Name = "element1"; 
                ILArray<double> element2 = ILMath.vector(20,2,30); 
                element2.Name = "element2"; 
                ILCell innerCell = new ILCell(new ILBaseArray[]{element1,element2},2,1); 
                A[3,1] = innerCell; 
                ILArray<double> ind = new ILArray<double>(new double[]{20.0,21.0,22.0,23.0,24.0}); 
                ind.Name = "ind"; 
                ILCell cellresult_vect = (ILCell)A[ind]; 
                cellresult_vect.Name = "cellresult_vect";
                if (!cellresult_vect.IsRowVector || cellresult_vect.Dimensions[0] != 1 
                    ||cellresult_vect.Dimensions[1] != 5) 
                    throw new Exception("ILCell: index access dimension mismatch: should be ILCell 1x5! ");
                if (!(cellresult_vect[0,0] is ILArray<short>) || !(cellresult_vect[0,1] is ILArray<double>)
                    || !(cellresult_vect[0,2] is ILArray<double>) || !(cellresult_vect[0,3] is ILCell)
                    || !(cellresult_vect[0,4] is ILArray<short>))
                    throw new Exception("ILCell: index access failed. Inner element mismatch for vector indices.");
                errorCode = 5;
                // test if elements returned are properly referenced (detached from original)
                ILArray<short> tmps = (ILArray<short>) cellresult_vect[0,0]; 
                tmps.Name = "tmps"; 
                if (!tmps.IsScalar || (tmps != 20.0)) 
                    throw new Exception("ILCell: invalid value returned: expected:20, found:" + tmps.GetValue(0));
                ILArray<double> tmp = (ILArray<double>) cellresult_vect[1]; 
                tmp.Name = "tmp"; 
                if (!tmp.IsVector || (bool)(tmp.Length != 91) || (bool)(tmp[0] != 10) || (bool)(tmp["end"] != 100))
                    throw new Exception("ILCell: invalid value returned: expected double vector 10:2:20");
                tmp = (ILArray<double>) cellresult_vect[2]; 
                if (!tmp.IsVector || (bool)(tmp.Length != 91) || (bool)(tmp[0] != -10) || (bool)(tmp["end"] != -100)) 
                    throw new Exception("ILCell: invalid value returned: expected vector 20:2:30");
                tmps = (ILArray<short>) cellresult_vect[4]; 
                if (!tmps.IsScalar || (bool)(tmps["end"] != 24.0)) 
                    throw new Exception("ILCell: invalid value returned: expected short 24, found: " + tmps.GetValue(0));
                cellresult_vect[0,3,1,0,1] = -111.0; 
                if ((ILArray<double>)cellresult_vect[0,3,1,0,1] != -111.0) 
                    throw new Exception("ILCell: invalid result of inner element index access: expected: -111.0, found: "+ ((ILArray<double>)cellresult_vect[0,3,1,0,1]).GetValue(0)); 
                errorCode = 6;
                // test if original still intact 
                if (!A[3,1,1,0,1].IsScalar || (ILArray<double>)A[3,1,1,0,1] != 22.0) 
                    throw new Exception("ILCell: original should not be altered if reference was altered! A[3,1,1,0,1] = " + ((ILArray<double>)A[3,1,1,0,1]).GetValue(0)); 
                // test subarray access: matrix (sequential)   **********************************************
                errorCode = 7;
                ind = new ILArray<double>(new double[6]{20.0,21.0,22.0,23.0,24.0,25.0},3,2); 
                ind.Name = "ind"; 
                cellresult_vect = (ILCell)A[ind]; 
                cellresult_vect.Name = "cellresult_vect";
                if (!cellresult_vect.IsMatrix || cellresult_vect.Dimensions[0] != 3 
                    ||cellresult_vect.Dimensions[1] != 2) 
                    throw new Exception("ILCell: index access dimension mismatch: should be ILCell 3x2! ");
                if (   !(cellresult_vect[0,0] is ILArray<short>)  || !(cellresult_vect[1,0] is ILArray<double>)
                    || !(cellresult_vect[2,0] is ILArray<double>) || !(cellresult_vect[0,1] is ILCell)
                    || !(cellresult_vect[1,1] is ILArray<short>)  || !(cellresult_vect[2,1] is ILArray<short>))
                    throw new Exception("ILCell: index access failed. Inner element mismatch for vector indices.");
                if (   !(cellresult_vect[0] is ILArray<short>)  || !(cellresult_vect[1] is ILArray<double>)
                    || !(cellresult_vect[2] is ILArray<double>) || !(cellresult_vect[3] is ILCell)
                    || !(cellresult_vect[4] is ILArray<short>)  || !(cellresult_vect[5] is ILArray<short>))
                    throw new Exception("ILCell: index access failed. Inner element mismatch for vector indices.");
                errorCode = 8;
                // test if elements returned are properly referenced (detached from original)
                tmps = (ILArray<short>) cellresult_vect[0,0]; 
                tmps.Name = "tmps"; 
                if (!tmps.IsScalar || (byte)tmps != 20.0) 
                    throw new Exception("ILCell: invalid value returned: expected:20, found:" + tmps.GetValue(0));
                tmp = (ILArray<double>) cellresult_vect[1]; 
                tmp.Name = "tmp"; 
                if (!tmp.IsVector || tmp.Length != 91 || tmp[0]!=10.0 || tmp["end"]!=100.0) 
                    throw new Exception("ILCell: invalid value returned: expected double vector 10:2:20");
                tmp = (ILArray<double>) cellresult_vect[2]; 
                if (!tmp.IsVector || tmp.Length != 91 || tmp[0]!=-10.0 || tmp["end"]!=-100.0) 
                    throw new Exception("ILCell: invalid value returned: expected vector 20:2:30");
                tmps = (ILArray<short>) cellresult_vect[4]; 
                if (!tmps.IsScalar || (byte)tmps["end"] != 24.0) 
                    throw new Exception("ILCell: invalid value returned: expected short 24, found: " + tmps.GetValue(0));
                cellresult_vect[0,1,1,0,1] = -111.0; 
                if ((double)(ILArray<double>)cellresult_vect[0,1,1,0,1] != -111.0) 
                    throw new Exception("ILCell: invalid result of inner element index access: expected: -111.0, found: "+ ((ILArray<double>)cellresult_vect[0,3,1,0,1]).GetValue(0)); 
                errorCode = 9;
                // test if original still untouched 
                if ((ILArray<double>)A[3,1,1,0,1] != 22.0) 
                    throw new Exception("ILCell: original should not be altered if reference was altered! A[3,1,1,0,1] = " + ((ILArray<double>)A[3,1,1,0,1]).GetValue(0)); 
                // test sequential index array set acces 
                innerCell = new ILCell(4,3,2); 
                innerCell[0] = ILMath.vector(20,-3,-100); 
                innerCell[1] = ((ILArray<double>)innerCell[0] < 0.0); 
                ILCell rangedsource = new ILCell(new ILBaseArray [] {
                        new ILArray<int>(3333), 
                        new ILLogicalArray(1), 
                        ILMath.vector(1000,2000),
                        innerCell},2,2); 
                ILArray<double> range = new ILArray<double>(new double[]{0,51,52,59}); 
                A[range] = rangedsource; 
                if (!(A[0] is ILArray<int>)) throw new Exception ("ILCell: seq.ranged set mismatch. index 0"); 
                if (!(A[51] is ILLogicalArray)) throw new Exception ("ILCell: seq.ranged set mismatch. index 1"); 
                if (!(A[52] is ILArray<double>)) throw new Exception ("ILCell: seq.ranged set mismatch. index 2"); 
                if (!(A[59] is ILCell)) throw new Exception ("ILCell: seq.ranged set mismatch. index 3"); 
                errorCode = 10;
                // test detached referencing (alter elements of query result)
                // test index access for ranges via ILBaseArray[]
                data = new ILBaseArray[60]; 
				for (int i = 0; i < data.Length; i++)
					data[i] = new ILArray<Int16>(new Int16[]{(Int16)i}); 
				A = new ILCell(data,20,3);
                A.Name = "A"; 
                ILArray<double> r = ILMath.vector(0,2); 
                ILArray<short> c = (ILArray<short>)ILMath.ones(NumericType.Int16,1); 
                ILCell rangeGet = (ILCell) A[r,c]; 
                if (rangeGet.Dimensions[0] != 3 || rangeGet.Dimensions[1] != 1)
                    throw new Exception("ILCell: ranged index get access via ILBaseArray failed. Wrong dimension returned."); 
                if ((ILArray<short>)rangeGet[0,0] != 20.0) throw new Exception("ILCell: invalid index returned: exp.20, found:" + ((ILArray<int>)rangeGet[0,0]).GetValue(0)); 
                A[0,1] = new ILArray<double>(17,18,1000); 
                if ((ILArray<short>)rangeGet[0,0] != 20.0) throw new Exception("ILCell: invalid index returned: exp.20, found:" + ((ILArray<double>)rangeGet[0,0]).GetValue(0) + ". The reference returned was not detached properly!"); 
                errorCode = 11;
                // test ranged setter 
                A[c,r] = A[c+10,r]; 
                if ((ILArray<short>)A[1,1] != 31.0) throw new Exception("Wrong value found after copying part of cell to other position.");
                A[1,1] = -1122.0; 
                if ((ILArray<short>)A[11,1] != 31.0 || (ILArray<double>)A[1,1] != -1122.0) throw new Exception ("wrong value stored or reference not properly un-linked in ILCell."); 
                // test removal of elements 
                errorCode = 12; 
                A[new ILArray<double>(new double[]{4.0,5.0,11.0}),null] = null; 
                if (A.Dimensions[0] != 17 || A.Dimensions[1] != 3) throw new Exception("ILCell removal via ILBaseArray[] failed.");
                A[new ILArray<double>(new double[]{4.0,5.0,11.0})] = null; 
                if (A.Dimensions[0] != 1 || A.Dimensions[1] != 48) throw new Exception("ILCell removal via sequential indexes failed!");
                errorCode = 13; 
                // test if error on removal will restore old dimensions 
                A = new ILCell(2,3,2); 
                ind = new double[]{15,16,22,223}; 
                try {
                    A[ind] = null;
                    throw new Exception("ILCell remove: index out of range not signaled!");
                } catch(Exception) {}
                if (A.Dimensions[0] != 2 || A.Dimensions[1] != 3 || A.Dimensions[2]!= 2) 
                    throw  new Exception("ILCell: error on remove should restore old dimensions!");

                Success();
			} catch (Exception e) {
				Error(errorCode ,e.Message);
			}
		}
		/*  basic method stub for tests 
			public void Test_XXX() {
					int errorCode = 0;
					// success? 
					try {
						// not implemented yet!
						throw new Exception();
						object[] data = new object[120];
						for (int i = 120; i-- > 0; )
							data[i] = (double)i;
						ILArray B = new ILArray(new ILDimension(5, 4, 1, 3, 2, 1), data);
						ILArray A = B.CreateReference(new ILRange("0:2,4;1,3;0;2,1,0,1"), 3);
						errorCode = 8;
						if (1 == 1)
							throw new Exception();
						Success("Test_XXX successful.");
					}
					catch (Exception e) {
						Error("Test_XXX failed at step: " + errorCode  + " Msg: " + e.Message);
					}
				}
		*/
	}
}
