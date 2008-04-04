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
using ILDA = ILNumerics.ILArray<double>;
using System.Runtime.Serialization.Formatters.Binary;
using ILNumerics.BuiltInFunctions; 
using System.IO;
using System.Runtime.Serialization;

namespace ILNumerics.Test {
	public class TESTILNumericArray : ILTest {
		
		public override void Run() {
			// tests: creation
			// =================
			Header();
			// BasicMath tests
            Test_MatrixMultiply();
            Test_AddDouble();
			Test_SubtractDouble();
			Test_MultiplyElementsDouble();
			Test_DivideDouble();
            Test_Serialize();
            Test_Deserialize(); 
			// summary
			Footer();
		}

        public void Test_Serialize() {
            int errorCode = 0;
            try {
                double[] data = new double[1000 * 1000 * 10];
                String filename = "ILDoubleArray_SerializeTest1.ils";
                for (int i = 0; i < data.Length; i++)
                    data[i] = (double)i;
                ILArray<double> A = new ILArray<double>(data, 1000,1000,10);

                FileStream fs = new FileStream(filename, FileMode.Create);
                Info("Serializing to file: (please wait...)");
                A.Serialize(fs); 
                fs.Close();
                FileInfo fi = new FileInfo(filename);
                Info("Serialized to file: [1000 x 1000 x 10] => " + ((int)(fi.Length/1024)) + "kB");
                
                // create reference storage from smaler range -> should Detach()  
                errorCode = 1;
                filename = "ILDoubleArray_SerializeTest2.ils";
                fs = new FileStream(filename, FileMode.Create);
                ILArray<double> AR1 = (ILArray<double>)A[0,"0:600;30:400;0:end"];
                AR1.Serialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Serialized to file: [600 x 360 x 10] => " + ((int)(fi.Length / 1024)) + "kB");

                // if reference storage saved effective memory - keep it as reference
                errorCode = 2;
                filename = "ILDoubleArray_SerializeTest3.ils";
                fs = new FileStream(filename, FileMode.Create);
                ILArray<double> AR2 = (ILArray<double>)A[0,"0:end,0:end;0:end,0:end;0:end"];
                AR2.Serialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Serialized to file: [2000 x 2000 x 20] => " + ((int)(fi.Length / 1024)) + "kB");


                // test if small reference would NOT store full data array
                errorCode = 4;
                filename = "ILDoubleArray_SerializeTest4.ils";
                fs = new FileStream(filename, FileMode.Create);
                ILArray<double> AR3 = (ILArray<double>)A["3;3;1"];
                AR3.Serialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Serialized to file: [1 x 1] => " + ((int)(fi.Length / 1024)) + "kB");
                if (fi.Length > 1024 * 2)
                    throw new Exception("Small reference storages should get detached before serializing!");
                errorCode = 5;

                Success("Test_serialize successfull");
            } catch (SerializationException e) {
                Error("Test_serialize failed on ErrorCode: "+ errorCode +"due: " + e.Message);
            } catch (Exception e) {
                Error("Test_serialize failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }

        public void Test_Deserialize() {
            int errorCode = 0;
            try {
                double[] data = new double[1000 * 1000 * 10];
                String filename = "ILDoubleArray_SerializeTest1.ils";
                for (int i = 0; i < data.Length; i++)
                    data[i] = (double)i;
                ILArray<double> A = new ILArray<double>(data, 1000,1000,10);
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filename, FileMode.Open);
                Info("Deserializing from file: (please wait...)");
                ILArray<double> ADS = (ILArray<double>)bf.Deserialize(fs);
                fs.Close();
                FileInfo fi = new FileInfo(filename);
                Info("Deserialized from file: [1000 x 1000 x 10] => " + ((int)(fi.Length/1024)) + "kB");
                if (!ADS.Equals(A))
                    throw new Exception("Values did not match! "); 

                // create reference storage from smaler range -> should Detach()  
                errorCode = 1;
                filename = "ILDoubleArray_SerializeTest2.ils";
                fs = new FileStream(filename, FileMode.Open);
                ILArray<double> AR1 = (ILArray<double>)A["0:600;30:400;0:end"];
                ILArray<double> AR1DS = (ILArray<double>)bf.Deserialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Deserialized from file: [600 x 360 x 10] => " + ((int)(fi.Length / 1024)) + "kB");
                if (!AR1DS.Equals(AR1))
                    throw new Exception("Values did not match! "); 

                // if reference storage saved effective memory - keep it as reference
                errorCode = 2;
                filename = "ILDoubleArray_SerializeTest3.ils";
                fs = new FileStream(filename, FileMode.Open);
                ILArray<double> AR2 = (ILArray<double>)A["0:end,0:end;0:end,0:end;0:end"];
                ILArray<double> AR2DS = (ILArray<double>)bf.Deserialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Deserialized from file: [2000 x 2000 x 20] => " + ((int)(fi.Length / 1024)) + "kB");
                if (!AR2DS.Equals(AR2))
                    throw new Exception("Values did not match! "); 

                // test if small reference would NOT store full data array
                errorCode = 4;
                filename = "ILDoubleArray_SerializeTest4.ils";
                fs = new FileStream(filename, FileMode.Open);
                ILArray<double> AR3 = (ILArray<double>)A["3;3;1"];
                ILArray<double> AR3DS = (ILArray<double>)bf.Deserialize(fs);
                fs.Close();
                fi = new FileInfo(filename);
                Info("Deserialized from file: [1 x 1] => " + ((int)(fi.Length / 1024)) + "kB");
                if (!AR3DS.Equals(AR3))
                    throw new Exception("Values did not match! ");
                errorCode = 5;
                File.Delete("ILDoubleArray_SerializeTest1.ils");
                File.Delete("ILDoubleArray_SerializeTest2.ils");
                File.Delete("ILDoubleArray_SerializeTest3.ils");
                File.Delete("ILDoubleArray_SerializeTest4.ils");
                Success("Test_Deserialize successfull");
            } catch (SerializationException e) {
                Error("Test_Deserialize failed on ErrorCode: " + errorCode + "due: " + e.Message);
            } catch (Exception e) {
                Error("Test_Deserialize failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }

        }

		public void Test_AddDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 12,-10,20,28,12,20,14,18,22,120,14,22,12,-10
													,20,28,12,20};
				ILArray<double> C = new ILArray<double>(data1, 2, 5);
				ILArray<double> B = new ILArray<double>(data2, 2, 5);
				ILArray<double> R = new ILArray<double>(results, 6, 3);
				ILArray<double> BR = (ILArray<double>)B[1,"0:1,0;0,1,2,4,0,2"];
				ILArray<double> CR = (ILArray<double>)C[1,"0:1,0;0,1,2,4,0,2"];
				C = CR.R;    // creates reference only 
				B = BR.R;
				C.Detach();
				B.Detach();
				ILArray<double> A = B+C;
				errorCode = 1;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = B+CR;
				errorCode = 2;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR+CR;
				errorCode = 3;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR+CR;
				errorCode = 4;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				Success("Test_AddDouble successful. (" + p.Toc() + "ms needed)");
			}
			catch (Exception e) {
				Error("Test_AddDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_SubtractDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 10,-16,10,10,10,10,10,10,10,100,10
														,10,10,-16,10,10,10,10};
				ILArray<double> C = new ILArray<double>(data1, 2, 5);
				ILArray<double> B = new ILArray<double>(data2, 2, 5);
				ILArray<double> R = new ILArray<double>(results, 6, 3);
				ILArray<double> BR = (ILArray<double>)B[1,"0:1,0;0,1,2,4,0,2"];
				ILArray<double> CR = (ILArray<double>)C[1,"0:1,0;0,1,2,4,0,2"];
				C = (ILArray<double>)CR.T.T;
				B = (ILArray<double>)BR.T.T;
				C.Detach();
				B.Detach();
                ILArray<double> A = B - C;
				errorCode = 1;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = B-CR;
				errorCode = 2;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR-CR;
				errorCode = 3;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR-CR;
				errorCode = 4;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				Success("Test_SubtractDouble successful. (" + p.Toc() + "ms needed)");
			}
			catch (Exception e) {
				Error("Test_SubtractDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}

		public void Test_MultiplyElementsDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 11, -39, 75, 171, 11, 75, 24, 56, 96, 1100
												   ,24, 96, 11, -39, 75, 171, 11, 75 };
				ILArray<double> C = new ILArray<double>(data1, 2, 5);
				ILArray<double> B = new ILArray<double>(data2, 2, 5);
				ILArray<double> R = new ILArray<double>(results, 6, 3);
				ILArray<double> BR = (ILArray<double>)B[1,"0:1,0;0,1,2,4,0,2"];
				ILArray<double> CR = (ILArray<double>)C[1,"0:1,0;0,1,2,4,0,2"];
				C = (ILArray<double>)CR.T.T;
				B = (ILArray<double>)BR.T.T;
				C.Detach();
				B.Detach();
				ILArray<double> A = B*C;
				errorCode = 1;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = B*CR;
				errorCode = 2;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR*CR;
				errorCode = 3;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR*CR;
				errorCode = 4;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				Success("Test_MultiplyElementsDouble successful. (" + p.Toc() + "ms needed)");
			}
			catch (Exception e) {
				Error("Test_MultiplyElementsDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
        public void Test_MatrixMultiply() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				double[] data1 = new double[120]; 
				double[] data2 = new double[120];
                double[] results = new double[36] { 177840,180120,182400,184680,186960,189240,180120,182440,
                    184760,187080,189400,191720,182400,184760,187120,189480,191840,194200,184680,187080,
                    189480,191880,194280,196680,186960,189400,191840,194280,196720,199160,189240,191720,
                    194200,196680,199160,201640};
                for (int i = 0; i < 120; i++) {
                    data1[i] = i;
                    data2[i] = i * 2;
                }
                ILDA A = new ILDA(data1, 6, 20);
                ILDA BR = new ILDA(data2, 6, 20);
                ILDA ResultExpect = new ILDA(results, 6,6);
				ILDA Result = null;
				ILDA AR = A.T.T;
                ILDA B = BR.T;
                B.Detach(); 
				BR = B.T.T;
				errorCode = 0;
                p.Tic(); 
                Result = ILMath.multiply(A , B);
                p.Toc();
				errorCode = 1;
                if (Result.Dimensions.NumberOfDimensions != 2)
					throw new Exception("Wrong number of results dimensions!");
				errorCode = 2;
                if (Result.Dimensions[0] != 6 ||Result.Dimensions[1] != 6)
					throw new Exception("Wrong result's size!");
				errorCode = 3;
                if (!Result.Equals(ResultExpect))
                    throw new Exception("Wrong results values!");
                Info("Test_MatrixMultiplyDouble succeeded: phy/phy " + p.ToString() + "ms needed");
                errorCode = 4;
				p.Tic(); 
				if (!ResultExpect.Equals(ILMath.multiply(AR, BR)))
                    throw new Exception("Wrong data value on ref/ref");
				p.Toc();
				Info("Test_MatrixMultiplyDouble succeeded: ref/ref " + p.ToString() + "ms needed");
                // test if wrong dimensions throw exceptions 
				try {
					ILMath.multiply (A, AR);
					throw new InvalidOperationException();
				} catch (Exception e) {
					if (e is InvalidOperationException)
						throw new Exception("Dimensions should be forced to match!");
				}
                data1 = new double[1000 * 2000];
                A = new ILDA(data1, 1000, 2000);
                B = new ILDA(data1, 2000, 1000);
                p.Tic();
                Result = ILMath.multiply(A, B);
                p.Toc();
                Info("Test_MatrixMultiply 1000x2000: phy/phy " + p.ToString() + "ms needed");
                Info("TODO: Implement test MatrixMultiply with reference storages!!"); 

                errorCode = 5; 
                ILArray<float> fA = new ILArray<float>(new float[12] {1f,2f,3f,4f,5f,6f,7f,8f,9f,10f,11f,12f},4,3); 
                ILArray<float> fB = new ILArray<float>(new float[12] {17f,18f,19f,20f,21f,22f,23f,24f,25f,26f,27f,28f},3,4); 
                ILArray<float> fRes = new ILArray<float>(new float[16] {278f,332f,386f,440f,323f,386f,449f,512f,368f,440,512f,584f,413f,494f,575f,656f},4,4); 
                if (ILMath.norm(fRes - ILMath.multiply(fA, fB)) > 1.0e-10) 
                    throw new Exception ("Test_MatrixMultiply: invalid values detected!");
                
                errorCode = 6; 
                ILArray<complex> zA = ILMath.real2complex(ILMath.vector(1,12),ILMath.vector(-1,-1,-12)); 
                ILArray<complex> zB = ILMath.real2complex(ILMath.vector(17,28),ILMath.vector(-17,-1,-28)); 
                //{new complex (0 , 0.5560), new complex (0, 0.6640), new complex (0, 0.7720), new complex (0, 0.8800), new complex (0,  0.6460), new complex (0,  0.7720), new complex (0,  0.8980), new complex (0,  1.0240), new complex (0,  0.7360), new complex (0,  0.8800),new complex(0,1.0240),new complex(0,1.1680),new complex(0,0.8260),new complex(0,0.9880),new complex(0,1.1500),new complex(0,1.3120)}
                ILArray<complex> zRes = ILMath.real2complex(ILMath.zeros(1,16), new ILArray<double>(new double[]{556,664,772,880,646,772,898,1024,736,880,1024,1168,826,988,1150,1312}) * (-1) ); 
                zA = ILMath.reshape(zA,4,3); 
                zB = ILMath.reshape(zB,3,4); 
                zRes = ILMath.reshape(zRes,4,4); 

                if (ILMath.norm(zRes - ILMath.multiply(zA, zB)) > 1.0e-10) 
                    throw new Exception ("Test_MatrixMultiply: invalid values detected!");
                
                errorCode = 7; 
                ILArray<fcomplex> cA = ILMath.real2fcomplex(ILMath.vector(1,12),ILMath.vector(-1,-1,-12)); 
                ILArray<fcomplex> cB = ILMath.real2fcomplex(ILMath.vector(17,28),ILMath.vector(-17,-1,-28)); 
                ILArray<fcomplex> cRes = ILMath.real2fcomplex(ILMath.zeros(1,16), new ILArray<double>(new double[]{556,664,772,880,646,772,898,1024,736,880,1024,1168,826,988,1150,1312}) * (-1) ); 
                cA = ILMath.reshape(cA,4,3); 
                cB = ILMath.reshape(cB,3,4); 
                cRes = ILMath.reshape(cRes,4,4); 

                if (ILMath.norm(cRes - ILMath.multiply(cA, cB)) > 1.0e-10)
                    throw new Exception ("Test_MatrixMultiply: invalid values detected!");
                
                Success("Test_MatrixMultiply successful.");
			} catch (Exception e) {
                Error("Test_MatrixMultiply failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}

		public void Test_DivideDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double tmp = ((double)13.0) / ((double)3.0); 
                double[] results = new double[18] { 11.0000,(double)-13.0/(double)3.0,15.0/5.0,19.0/9.0,11
								,3.0000,6.0000,3.5000,16.0/6.0,11.0000,6.0000,16.0/6.0,11.0000
													,-13.0/3.0,3.0000,19.0/9.0,11.0000,3.0000};
				ILArray<double> C = new ILArray<double>(data1, 2, 5);
				ILArray<double> B = new ILArray<double>(data2, 2, 5);
				ILArray<double> R = new ILArray<double>(results, 6, 3);
				ILArray<double> BR = (ILArray<double>)B[1,"0:1,0;0,1,2,4,0,2"];
				ILArray<double> CR = (ILArray<double>)C[1,"0:1,0;0,1,2,4,0,2"];
				C = (ILArray<double>)CR.T.T;
				B = (ILArray<double>)BR.T.T;
				C.Detach();
				B.Detach();
				ILArray<double> A = B/C;
				errorCode = 1;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = B/CR;
				errorCode = 2;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR/CR;
				errorCode = 3;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				A = BR/CR;
				errorCode = 4;
				if (!A.Equals(R))
					throw new Exception("Values did not match!");
				Success("Test_DivideDouble successful. (" + p.Toc() + "ms needed)");
			}
			catch (Exception e) {
				Error("Test_DivideDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}


	}
}
