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
using ILNumerics.Exceptions; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO; 
using ILNumerics.Settings;

namespace ILNumerics.Test {
	public class TESTILStorage : ILTest {

		public override void Run() {
			Header();
			// accessing elements 
			Test_setrange();
			Test_setrange_of_reference();
			// simple storage: row vector 1x10
			Test_row_vector1x10();
			// simple storage: column vector 10x1
			Test_col_vector10x1();
			// 1x1 object
			Test_scalar();
			// higher order objects (Matrix/ higher tensors)
			Test_tensor();
			// reference creation : non transposing, full
			Test_reference_full();
			// reference creation: transposing,full
			Test_reference_full_transposing();
			// reference creation: transposing,full: test trims
			Test_reference_full_transposing_trim();
			// reference creation : non transposing, ranged
			Test_reference_ranged();
			// reference creation: transposing,ranged + test trims
			Test_reference_ranged_transposing_trim();
			// reference from reference 
			Test_reference_full_from_reference_ranged_transposed();
			Test_reference_full_transposed_from_reference_full_transposed();
			Test_reference_ranged_from_reference_ranged();
			Test_reference_ranged_transposed_from_reference_ranged();
			Test_reference_ranged_transposing_trim_from_reference_ranged_transposed();
			Test_reference_ranged_transposed_from_reference_full();
			// detaching 
			Test_detach();
			// writeable test 
			Test_readonly();
            Test_serialize();
            Test_Deserialize();
            // trim singleton dimensions
            //Test70();
            //Test_tmpPerfCount(); 
			Test_Iterator_Performance();
			// error handling: non existing dimensions 
			// dimension shift too large
			// range out of bound
			// summary
            Footer();
		}

        public void Test_tmpPerfCount() {
            double [] data = new double[1000*1000*10];
            ILArray<double> A = new ILArray<double>(data, 1000, 1000, 10);
            ILPerformer p = new ILPerformer(); 
                        
            p.Tic();
            for (int i = 0; i < 10000000; i++) {
                A.getBaseIndex(i); 
            }
            p.Toc();
            Info("1000x1000x10: phys GetBaseIndex needed: " + p.Duration + " ms");

            ILIterator<double> it = A.CreateIterator();
            p.Tic();
            do {
                it.Increment(); 
            } while(!it.IsAtStart());
            p.Toc();
            Info("1000x1000x10: phys Iterator needed: " + p.Duration + " ms");
            
            A = (ILArray<double>)A[1,""];
            p.Tic();
            for (int i = 0; i < 10000000; i++) {
                A.getBaseIndex(i);
            }
            p.Toc();
            Info("1000x1000x10: ref. GetBaseIndex needed: " + p.Duration + " ms");

            it = A.CreateIterator();
            p.Tic();
            do {
                it.Increment();
            } while (!it.IsAtStart());
            p.Toc();
            Info("1000x1000x10: ref Iterator needed: " + p.Duration + " ms");
            p.Tic(); 
        }

        public void Test_serialize() {
            int errorCode = 0; 
            try {
                String[] data = new String[1000];
                String filename = "ILFullArray_SerializeTest1.ils"; 
                for (int i = 0; i < data.Length; i++)
                    data[i] = "Datum Nr." + i;
                ILArray<String> A = new ILArray<String>(data, 10, 20, 5);

                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filename , FileMode.Create);
                bf.Serialize(fs, A);
                fs.Close();
                errorCode = 1;
                // create reference storage from smaler range -> should Detach()  
                ILArray<String> AR1 = (ILArray<String>)A[0,"0:8;3:18;0:end"];
                filename = "ILFullArray_SerializeTest2.ils";
                fs = new FileStream(filename, FileMode.Create);
                bf.Serialize(fs,AR1);
                fs.Close(); 
                errorCode = 2;
                
                // if reference storage saved effective memory - keep it as reference
                errorCode = 3;
                ILArray<String> AR2 = (ILArray<String>)A ["0:end,0:end;0:end,0:end;0:end"];
                filename = "ILFullArray_SerializeTest3.ils";
                fs = new FileStream(filename, FileMode.Create);
                bf.Serialize(fs, AR2);
                fs.Close();
 
                // test if small reference would NOT store full data array
                errorCode = 4;
                filename = "ILFullArray_SerializeTest4.ils";
                ILArray<String> AR3 = A[3,3,1];
                fs = new FileStream(filename, FileMode.Create);
                bf.Serialize(fs,AR3);
                fs.Close();
                FileInfo f = new FileInfo(filename);
                if (f.Length > 1024 * 3) 
                    throw new Exception("Small reference storages should detach before serializing!"); 
                errorCode = 5; 
                
                Success(); 
            } catch (Exception e) {
                Error(errorCode, e.Message); 
            }
        }

        public void Test_Deserialize() {
            int errorCode = 0;
            try {
                {
                    String[] data = new String[1000];
                    String filename = "ILFullArray_SerializeTest1.ils";
                    for (int i = 0; i < data.Length; i++)
                        data[i] = "Datum Nr." + i;

                    ILArray<String> A = new ILArray<String>(data, 10, 20, 5);
                    // full storage, was: A 
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    ILArray<String> ADS = (ILArray<String>)bf.Deserialize(fs);
                    fs.Close();
                    
                    if (ADS.Dimensions.NumberOfElements != 1000)
                        throw new Exception("Object has wrong size! Expected: 1000, Found: " + ADS.Dimensions.NumberOfElements);
                    ILIterator<String> I1 = A.CreateIterator(ILIteratorPositions.ILStart,0 );
                    ILIterator<String> I2 = ADS.CreateIterator(ILIteratorPositions.ILStart,0 );
                    for (int i = 0; i < A.Dimensions.NumberOfElements; i++) {
                        if (((String)I1.Value).CompareTo((String)I2.Value) != 0)
                            throw new Exception("Values did not match! ");
                    }

                    // reference storage, was : AR1
                    filename = "ILFullArray_SerializeTest2.ils";
                    fs = new FileStream(filename, FileMode.Open);
                    ILArray<String> AR1DS = (ILArray<String>)bf.Deserialize(fs);
                    fs.Close();
                    ILArray<String> AR1 = (ILArray<String>)A["0:8;3:18;0:end"];

                    if (AR1DS.Dimensions.NumberOfElements != AR1.Dimensions.NumberOfElements)
                        throw new Exception("Object has wrong size! Expected: " 
                            + AR1.Dimensions.NumberOfElements + ", Found: " 
                            + AR1DS.Dimensions.NumberOfElements);
                    I1 = AR1.CreateIterator(ILIteratorPositions.ILStart, 0);
                    I2 = AR1DS.CreateIterator(ILIteratorPositions.ILStart, 0);
                    for (int i = 0; i < AR1.Dimensions.NumberOfElements; i++) {
                        if (((String)I1.Value).CompareTo((String)I2.Value) != 0)
                            throw new Exception("Values did not match! ");
                    }

                    // if reference storage saved effective memory - keep it as reference
                    errorCode = 3;
                    filename = "ILFullArray_SerializeTest3.ils";
                    fs = new FileStream(filename, FileMode.Open);
                    ILArray<String> AR2DS = (ILArray<String>)bf.Deserialize(fs);
                    fs.Close();
                    ILArray<String> AR2 = (ILArray<String>)A["0:end,0:end;0:end,0:end;0:end"];
                    if (AR2DS.Dimensions.NumberOfElements != AR2.Dimensions.NumberOfElements)
                        throw new Exception("Object has wrong size! Expected: "
                            + AR2.Dimensions.NumberOfElements + ", Found: "
                            + AR2DS.Dimensions.NumberOfElements);
                    I1 = AR2.CreateIterator(ILIteratorPositions.ILStart, 0);
                    I2 = AR2DS.CreateIterator(ILIteratorPositions.ILStart, 0);
                    for (int i = 0; i < AR2.Dimensions.NumberOfElements; i++) {
                        if (((String)I1.Value).CompareTo((String)I2.Value) != 0)
                            throw new Exception("Values did not match! ");
                    }

                    // test if small reference would NOT store full data array
                    errorCode = 4;
                    filename = "ILFullArray_SerializeTest4.ils";
                    fs = new FileStream(filename, FileMode.Open);
                    ILArray<String> AR3DS = (ILArray<String>)bf.Deserialize(fs);
                    fs.Close();
                    ILArray<String> AR3 = A[3,3,1];
                    if (AR3DS.m_data.Length != 1 || ((String)AR3DS.m_data[0]).CompareTo("Datum Nr.233") != 0)
                        throw new Exception("Unvalid deserialized scalar storage!");
                    errorCode = 5;
                    // clean up . delete all test files 
                    File.Delete("ILFullArray_SerializeTest1.ils");
                    File.Delete("ILFullArray_SerializeTest2.ils");
                    File.Delete("ILFullArray_SerializeTest3.ils");
                    File.Delete("ILFullArray_SerializeTest4.ils"); 
                }
                Success("Test_Deserialize successfull");
            } catch (SerializationException e) {
                Error("Test_Deserialize failed at errorCode: " + errorCode + " due: " + e.Message);
            } catch (Exception e) {
                Error("Test_Deserialize failed at errorCode: " + errorCode + " due: " + e.Message);
            }
        }
        public void Test_row_vector1x10() {
			int errorCode = 0;
			// success? 
			try {
                ILArray<object> A = new ILArray<object>(new object[10],1,10);
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 1)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[1] != 10)
					throw new Exception();
				errorCode++;
				object[] data = (object[])A.m_data; 
				if (data.Length != 10)
					throw new Exception();
				errorCode++;
				if (data[0] != null)
					throw new Exception();
				errorCode++;
				if (data[9] != null)
					throw new Exception();
				Success("Test_row_vector1x10 successful.");
			}
			catch (Exception e) {
				Error("Test_row_vector1x10 failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// simple storage: column vector 10x1
		public void Test_col_vector10x1() {
			int errorCode = 0;
			// success? 
			try {
                ILArray<object> A = new ILArray<object>(new object[10], 10, 1);
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 10)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[1] != 1)
					throw new Exception();
				errorCode++;
				object[] data = (object[])A.m_data; 
				if (data.Length != 10 || A.Dimensions.NumberOfElements != 10)
					throw new Exception();
				errorCode++;
				if (data[0] != null)
					throw new Exception();
				errorCode++;
				if (data[9] != null)
					throw new Exception();
				Success("Test_col_vector10x1 successful.");
			}
			catch (Exception e) {
				Error("Test_col_vector10x1 failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// simple storage: scalar 1x1
		public void Test_scalar() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = { 1.0 };
                ILArray<object> A = new ILArray<object>(data,1);
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 1)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[1] != 1)
					throw new Exception();
				errorCode = 4;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 1 || A.Dimensions.NumberOfElements != 1)
					throw new Exception();
				errorCode = 5;
				if (mdata[0] != data[0])
					throw new Exception();
				Success("Test_scalar successful.");
			}
			catch (Exception e) {
				Error("Test_scalar failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// higher order tensors
		public void Test_tensor() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> A = new ILArray<object>(data, 5, 4, 3, 2, 1, 1);
				errorCode = 1;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[0] != 5 | A.Dimensions[1] != 4 | A.Dimensions[2] != 3
					| A.Dimensions[3] != 2)
					throw new Exception();
				errorCode = 4;
				object[] mdata = (object[]) A.m_data;
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 120)
					throw new Exception();
				errorCode = 5;
				if (((Double)mdata[3]).CompareTo(3.0) != 0)
					throw new Exception();
				errorCode = 6;
				if (((Double)mdata[119]).CompareTo(119.0) != 0)
					throw new Exception();
				Success("Test_tensor successful.");
			}
			catch (Exception e) {
				Error("Test_tensor failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// reference creation: non transposing, full
		public void Test_reference_full() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 3, 2, 1, 1);
                ILArray<object> A = B.S(0);
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 5 | A.Dimensions[1] != 4 | A.Dimensions[2] != 3
					| A.Dimensions[3] != 2)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 120)
					throw new Exception();
				errorCode++;
				ILIterator<object> It = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (It.Value != data[count++])
						throw new Exception();
					It.Increment();
				} while (!It.IsAtEnd());
				Success("Test_reference_full successful.");
			}
			catch (Exception e) {
				Error("Test_reference_full failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// reference creation: transposing, full
		public void Test_reference_full_transposing() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 3, 2, 1, 1);
                ILArray<object> A = B.S(2);
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 3 | A.Dimensions[1] != 2 | A.Dimensions[2] != 5
					| A.Dimensions[3] != 4)
					throw new Exception();
				errorCode = 3;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 120)					throw new Exception();
				errorCode = 4;
				ILIterator<object> It = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (It.Value != data[count])
						throw new Exception();
					It.Increment();
					count += 20;
					if (count > 119) {
						count = (count % 119);
					}

				} while (!It.IsAtStart());
				Success("Test_reference_full_transposing successful.");
			}
			catch (Exception e) {
				Error("Test_reference_full_transposing failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// reference creation: transposiong, full with inner singleton dimensions
		// (Those SD. only get exposed if the trim moves them 
		// to the end of dimensions. Therefore multiple trims are neccessary for ILFullArray)
		public void Test_reference_full_transposing_trim() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1, 1);
                ILArray<object> A = B.S(3);
				errorCode++;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 3 | A.Dimensions[1] != 2 | A.Dimensions[2] != 5
					| A.Dimensions[3] != 4)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 120)
					throw new Exception();
				errorCode++;
				ILIterator<object> It = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					// compares object references
					if (It.Value != data[count])
						throw new Exception();
					It.Increment();
					count += 20;
					if (count > 119) {
						count = (count % 119);
					}
				} while (!It.IsAtEnd());
				Success("Test_reference_full_transposing_trim successful.");
			}
			catch (Exception e) {
				Error("Test_reference_full_transposing_trim failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// reference creation: ranged, non transposing
		public void Test_reference_ranged() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1, 1);
                B.MinimumRefDimensions = 2; 
                ILArray<object> A = B["0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 2
					| A.Dimensions[2] != 1
					| A.Dimensions[3] != 4)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data;
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode++;
				// soll werte: 
				double[] results = new double[32]{45,46,47,49,55,56,57,59,25,26,27,29
								,35,36,37,39,5,6,7,9,15,16,17,19,25,26,27,29,35,36,37,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged successful.");
			}
			catch (Exception e) {
				Error("Test_reference_ranged failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		// reference creation:ranged, transposing
		public void Test_reference_ranged_transposing_trim() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
                B.MinimumRefDimensions = 2; 
                ILArray<object> A = B[3,"0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 4
					| A.Dimensions[2] != 2)
					throw new Exception();
				errorCode = 3;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode = 4;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged_transposing successful.");
			}
			catch (Exception e) {
				Error("Test_reference_ranged_transposing failed at step: " + errorCode  + " Msg: " + e.Message.ToString());
			}
		}
		// detaching a ranged,shifted storage to new physical storage
		public void Test_detach() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1 );
                ILArray<object> A = B[3,"0:2,4;1,3;0;2,1,0,1"];
				if (B.m_data.GetHashCode() != A.m_data.GetHashCode())
					throw new Exception();
				if (A.GetNumberOfReferences() != 2)
					throw new Exception();
				A.Detach();
				errorCode = 0;
                if (Object.Equals(A, null))
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 4
					| A.Dimensions[2] != 2)
					throw new Exception();
				errorCode = 3;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 32 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode = 4;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception("Values did not match!");
					I.Increment();
				} while (!I.IsAtStart());
				errorCode = 5;
				mdata = (object[])A.m_data; 
				for (int i = 0; i < A.Dimensions.NumberOfElements; i++)
					if (mdata[i] != data[(int)results[i]])
						throw new Exception();
				errorCode = 6;
				if (A.GetNumberOfReferences() != 1)
					throw new Exception();
				errorCode = 7;
				if (B.GetNumberOfReferences() != 1)
					throw new Exception();
				errorCode = 8;
				if (A.m_data == B.m_data)
					throw new Exception();
				Success("Test_detach successful.");
			}
			catch (Exception e) {
				Error("Test_detach failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		public void Test_readonly() {
			int errorCode = 0;
			// after detaching all references but one, that storage is writeable ? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
				errorCode = 1; 
				if (B.IsReadonly() == true)
					throw new Exception();
				errorCode = 2;
                ILArray<object> A1 = B[3,"0:2,4;1,3;0;2,1,0,1"];
				if (A1.IsReadonly() == false | B.IsReadonly() == false)
					throw new Exception();
				errorCode = 3;
                ILArray<object> A2 = B.GetShifted(2);
				if (A1.IsReadonly() == false | B.IsReadonly() == false | A2.IsReadonly() == false)
					throw new Exception();
				errorCode = 4;
				A1.Detach();
				if (A1.IsReadonly() == true | B.IsReadonly() == false | A2.IsReadonly() == false)
					throw new Exception();
				errorCode = 5;
				A2.Detach();
				if (A1.IsReadonly() == true | B.IsReadonly() == true | A2.IsReadonly() == true)
					throw new Exception();
				errorCode = 6;
                ILArray<object> A3 = A2.S(3);
				if (A3.IsReadonly() == false | A2.IsReadonly() == false)
					throw new Exception();
				errorCode = 7;
				A2.Detach();
				if (A3.IsReadonly() == true | A2.IsReadonly() == true)
					throw new Exception();
				errorCode = 8;
				if (Object.Equals(A3,null)) {
                    ILArray<object> A4 = A3[2,"0:2,1"];
					if (A3.IsReadonly() == false | A4.IsReadonly() == false)
						throw new Exception();
					A4.Dispose();
				}
				// after leaving the scope -> A3 is only reference now? 
				// (Is not defined when the GC will clean up A4!)
				if (A3.IsReadonly() == true)
					throw new Exception("A3 should be writable!");
				Success("Test_readonly successful.");
			}
			catch (Exception e) {
				Error("Test_readonly failed at step: " + errorCode  + " Msg: " + e.Message);
			}
		}
		public void Test_reference_full_from_reference_ranged_transposed() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 2; 
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
                ILArray<object> C = B[3,"0:2,4;1,3;0;2,1,0,1"];
                // use referencing for this test...
                ILArray<object> A = C.GetShifted(0);
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 4 | A.Dimensions[1] != 4 | A.Dimensions[2] != 2)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode++;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_full_from_reference_ranged_transposed successful.");
			}
			catch (Exception e) {
				Error("Test_reference_full_from_reference_ranged_transposed failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_reference_full_transposed_from_reference_full_transposed() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> B = new ILArray<object>(data, 5, 4, 3, 2, 1, 1);
				ILArray<object> C = B.S(1);
				ILArray<object> A = C.S(1);
				errorCode = 0;
				if (A.m_data != B.m_data)
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 3 | A.Dimensions[1] != 2 | A.Dimensions[2] != 5
					| A.Dimensions[3] != 4)
					throw new Exception();
				errorCode = 3;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 120)
					throw new Exception();
				errorCode = 4;
				ILIterator<object> It = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (It.Value != data[count])
						throw new Exception();
					It.Increment();
					count += 20;
					if (count > 119) {
						count = (count % 119);
					}

				} while (!It.IsAtStart());
				Success("Test_reference_full_transposed_from_reference_full_transposed successful.");
			}
			catch (Exception e) {
				Error("Test_reference_full_transposed_from_reference_full_transposed failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_reference_ranged_from_reference_ranged() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1, 1);
				// simulate referencing by creating "full" range
				ILArray<object> C = B["0:4;0:3;0;0:2;0,1"];
				ILArray<object> A = C["0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 4)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 2
					| A.Dimensions[2] != 1
					| A.Dimensions[3] != 4)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data;
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode++;
				// soll werte: 
				double[] results = new double[32]{45,46,47,49,55,56,57,59,25,26,27,29
								,35,36,37,39,5,6,7,9,15,16,17,19,25,26,27,29,35,36,37,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged_from_reference_ranged successful.");
			}
			catch (Exception e ) {
				Error("Test_reference_ranged_from_reference_ranged failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_reference_ranged_transposed_from_reference_ranged() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1, 1);
				// simulate referencing by creating "full" range
				ILArray<object> C = B["0:4;0:3;0;0:2;0,1"];
				ILArray<object> A = C[3,"0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 4
					| A.Dimensions[2] != 2)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data; 
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode++;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged_transposed_from_reference_ranged successful.");
			}
			catch (Exception e) {
				Error("Test_reference_ranged_transposed_from_reference_ranged failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		// reference creation: ranged, transposing from ranged + transposed storage
		public void Test_reference_ranged_transposing_trim_from_reference_ranged_transposed() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
				ILArray<object> A = B[3,"0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 4
					| A.Dimensions[2] != 2)
					throw new Exception();
				errorCode = 3;
				object[] mdata = (object[])A.m_data;
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode = 4;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged_transposing successful.");
			}
			catch (Exception e) {
				Error("Test_reference_ranged_transposing failed at step: " + errorCode + " Msg: " + e.Message.ToString());
			}
		}
		public void Test_reference_ranged_transposed_from_reference_full() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1, 1);
				// simulate referencing by creating "full" range
				ILArray<object> C = B.S(0);
				ILArray<object> A = C[3,"0:2,4;1,3;0;2,1,0,1"];
				errorCode = 0;
				if (Object.Equals(A,null))
					throw new Exception();
				errorCode++;
				if (A.Dimensions.NumberOfDimensions != 3)
					throw new Exception();
				errorCode++;
				if (A.Dimensions[0] != 4
					| A.Dimensions[1] != 4
					| A.Dimensions[2] != 2)
					throw new Exception();
				errorCode++;
				object[] mdata = (object[])A.m_data;
				if (mdata.Length != 120 || A.Dimensions.NumberOfElements != 32)
					throw new Exception();
				errorCode++;
				// soll werte: 
				double[] results = new double[32]{45,25,5,25,46,26,6,26,47,27,7,27,49,29
									,9,29,55,35,15,35,56,36,16,36,57,37,17,37,59,39,19,39};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				Success("Test_reference_ranged_transposed_from_reference_full successful.");
			}
			catch (Exception e) {
				Error("Test_reference_ranged_transposed_from_reference_full failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
	   	public void Test_setrange() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
				ILArray<object> A = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
				//ILFullArray A = B.CreateReference(new ILRange("0:2,4;1,3;0;2,1,0,1"), 3);
				errorCode = 1;
				// new values
				double[] vals = new double[12] { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 
												 110, 111 };
				object[] valso = new object[12];
				for (int i = 0; i < 12; i++)
					valso[i] = vals[i];
				ILArray<object> C = new ILArray<object>(valso, 2, 2, 3);
				// should replace missing trailing dimension by 0
				// inner singleton dimensions should be ok! 
				A["1,3;0,2;0;0,1,2"] = C;
				errorCode = 2;
				
				double[] results = new double[120] {0,100,  2,101,  4,  5,  6,  7,  8,  9, 10,
					102, 12,103, 14, 15, 16, 17, 18, 19, 20,104, 22,105, 24, 25, 26, 27, 28, 
					29, 30,106, 32,107, 34, 35, 36, 37, 38, 39, 40,108, 42,109, 44, 45, 46, 
					47, 48, 49, 50, 110, 52, 111, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 
					65, 66, 67, 68, 69, 70, 71,  72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 
					83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99,100,
					101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do
				{
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception();
					I.Increment();
				} while (!I.IsAtStart());
				// complain if dimensions do not match
				errorCode = 3;
				ILArray<object> D = new ILArray<object>(new object[4] { 1, 1, 1, 1 }, 1, 2, 2);
				try {
					A["0,1,0,0:2"] = D;
                    throw new Exception("setrange should complain if dimensions do not match!"); 
				} catch (ILArgumentException) {
					
				}
				errorCode = 4; 
				Success("Test_setrange successful.");
			}
			catch (Exception e) {
				Error("Test_setrange failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_setrange_of_reference() {
			int errorCode = 0;
			// success? 
			try {
				object[] data = new object[120];
				for (int i = 120; i-- > 0; )
					data[i] = (double)i;
                ILArray<object> B = new ILArray<object>(data, 5, 4, 1, 3, 2, 1);
				int oldRefDim = ILSettings.MinimumRefDimensions; 
                ILSettings.MinimumRefDimensions = 2; 
                ILArray<object> A = B[3,"0:2,4;1,3;0;2,1,0,1"];
				// make A writable
				ILArray<object>.DetachReferences = ILDetachingBehavior.DetachNever; 
				B.Detach();
				errorCode = 1;
				// new values
				double[] vals = new double[12] { 101, 102, 103, 104, 105, 106, 107, 
												 108, 109, 110, 111, 112 };
				object[] valso = new object[vals.Length];
				for (int i = 0; i < vals.Length; i++)
					valso[i] = vals[i];
				ILArray<object> C = new ILArray<object>(valso, 3, 2, 2);
				// should replace missing trailing dimension by 0
				// inner singleton dimensions should be ok! 
				ILArray<object>.DetachReferences = ILDetachingBehavior.DetachSave;
				A["0,2,3;0,3;0,1"] = C;
				errorCode = 2;

				double[] results = new double[32] {101,103,102,103,46,26, 6,26,47
						,27, 7,27,104,106,105,106,107,109,108,109,56,36,16,36,57,37,17
						,37,110,112,111,112};
				ILIterator<object> I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				int count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception("Values did not match!");
					I.Increment();
				} while (!I.IsAtStart());
				errorCode = 3; 
				// test detaching before altering 
				ILArray<object>.DetachReferences = ILDetachingBehavior.DetachOnWrite;
				A = B[3,"0:2,4;1,3;0;2,1,0,1"];
				B.Detach();
				A.SetRange(new ILRange(A.Dimensions,RangeSide.Left,"0,2,3;0,3;0,1"), C);
				errorCode = 4;

				results = new double[32] {101,25,102,103,46,26, 6,26,47
						,27, 7,27,104,29,105,106,107,35,108,109,56,36,16,36,57,37,17
						,37,110,39,111,112};
				I = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				count = 0;
				do {
					if (((Double)I.Value).CompareTo(results[count++]) != 0)
						throw new Exception("The values did not match!");
					I.Increment();
				} while (!I.IsAtStart());
				// complain if dimensions do not match
				errorCode = 5;
				ILArray<object> D = new ILArray<object>(new object[4] { 1, 1, 1, 1 }, 1, 2, 2);
				try {
					A["0,1,0,0:2"] = D;
				} catch (ILArgumentSizeException) {
					Info("setrange: dimension mismatch signaled correctly"); 
				}
				errorCode = 4;
                ILSettings.MinimumRefDimensions = oldRefDim; 
				Success();
			} catch (Exception e) {
				Error(errorCode, e.Message);
			}
		}

        public void Test_Iterator_Performance() {
            int errorCode = 0;
            // success? 
            try {
				double[] data = new double[4 * 3 * 2] {0, 1,2,3,4,5,6,7,8,9,10
										,11,12,13,14,15,16,17,18,19,20,21,22,23 };
				ILArray<double> A = new ILArray<double>(data, 4,3,2);
				ILArray<double> Ar = (ILArray<double>)A.GetShifted(2); 
				ILPerformer p = new ILPerformer();
				int counter = 0; 
				ILIterator<double> it = A.CreateIterator(ILIteratorPositions.ILEnd, 0);
				ILIterator<double> it1 = Ar.CreateIterator(ILIteratorPositions.ILEnd, 2);
				double val = 0.0; 
				do {
					if (it.Increment() != counter++)
						throw new Exception("invalid iterator value!"); 
				} while (!it.IsAtEnd());
				// shifted (1) physical
				errorCode = 1; 
				double[] results = new double[24] {0,4,8,12,16,20,1,5,9,13,17,21
										,2,6,10,14,18,22,3,7,11,15,19,23};
				it = A.CreateIterator(ILIteratorPositions.ILEnd, 1);
				counter = 0; 
				do {
					if (it.Increment() != results[counter])
						throw new Exception("invalid phy iterator value!");
					if (it1.Increment() != results[counter++])
						throw new Exception("invalid ref iterator value!");
				} while (!it.IsAtEnd());
				results = new double[24] {0,4,8,12,16,20,1,5,9,13,17,21
										,2,6,10,14,18,22,3,7,11,15,19,23};

				data = new double[1000 * 1000 * 10];
				A = new ILArray<double>(data, 1000, 1000, 10);
                //// test the IEnumerable way of doing this
                //errorCode = 1;
				
                //p.Tic();
                //foreach (double v in A) {
                //    val = v;
                //}
                //p.Toc();
                //Info("[1000 x 1000 x 10] IEnumarable 'foreach' Iterator: " + p.ToString());

				errorCode = 2; 
				// iterate the classic way: 
                val = 2.23;
				double dura = 0.0, dura1= 0.0;
				double itIncCounter = 0.0;
				it = A.CreateIterator(ILIteratorPositions.ILStart, 0);
				it1 = A.CreateIterator(ILIteratorPositions.ILStart, 1);
				ILPerformer p1 = new ILPerformer();
				do {
					p1.Tic();
					val = it1.Increment();
					p1.Toc();
					dura1 += p1.Duration; // outer time needed 
					
					p.Tic();
					val = it.Increment();
					p.Toc();
					//dummy += Environment.TickCount - it.Dummy;  // internal time needed 
					dura += p.Duration; // outer time needed 
					itIncCounter++;
				} while (itIncCounter < data.Length);
				Info("[1000 x 1000 x 10] ILIterator Phys leadDim: 0 ->" 
					+ dura.ToString() + " leadDim: 1 ->" + dura1.ToString() 
					+ " incCount:" + itIncCounter);

				errorCode = 3;
				ILArray<double> B = (ILArray<double>)A.T;
				p.Tic();
				it = B.CreateIterator(ILIteratorPositions.ILStart, 0);
				it1 = B.CreateIterator(ILIteratorPositions.ILStart, 1);
                dura = 0.0; dura1 = 0.0; itIncCounter = 0; 
				do {
					p1.Tic();
					val = it1.Increment();
					p1.Toc();
					dura1 += p1.Duration; // outer time needed 

					p.Tic();
					val = it.Increment();
					p.Toc();
					//dummy += Environment.TickCount - it.Dummy;  // internal time needed 
					dura += p.Duration; // outer time needed 
					itIncCounter++;
				} while (itIncCounter < data.Length);
				p.Toc();
				Info("[1000 x 1000 x 10] ILIterator - Ref. leadDim: 0 ->"
					+ dura.ToString() + " leadDim: 1 ->" + dura1.ToString()
					+ " incCount:" + itIncCounter);


				Success("Test_Iterator_Performance successful.");
            } catch (Exception e) {
                Error("Test_Iterator_Performance failed at step: " + errorCode + " Msg: " + e.Message);
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
                        ILFullArray B = new ILFullArray(new ILDimension(5, 4, 1, 3, 2, 1), data);
                        ILFullArray A = B.CreateReference(new ILRange("0:2,4;1,3;0;2,1,0,1"), 3);
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
