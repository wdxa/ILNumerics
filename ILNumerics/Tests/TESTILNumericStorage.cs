using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Test;
using ILDA = ILNumerics.ILDoubleArray;
using ILIterator = ILNumerics.Storage.ILStorage.ILIterator<double>;


namespace ILNumerics.Test {
	public class TESTILNumericStorage : ILTest {
		
		public override void Run() {
			// tests: creation
			// =================
			Header();
			// BasicMath tests
			Test_AddDouble();
			Test_SubtractDouble();
			Test_MultiplyElementsDouble();
			Test_PerformLarge();
			Test_DivideDouble();
            // summary
			Footer();
		}

		public void Test_AddDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				ILRange r = new ILRange("0:1,0;0,1,2,4,0,2");
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 12,-10,20,28,12,20,14,18,22,120,14,22,12,-10
													,20,28,12,20};
				ILDoubleStorage C = new ILDoubleStorage(new ILDimension(2, 5), data1);
				ILDoubleStorage B = new ILDoubleStorage(new ILDimension(2, 5), data2);
				ILDoubleStorage BR = (ILDoubleStorage)B.CreateReference(r, 1);
				ILDoubleStorage CR = (ILDoubleStorage)C.CreateReference(r, 1);
				C = (ILDoubleStorage)CR.CreateReference(null, 0);
				C.Detach();
				B = (ILDoubleStorage)BR.CreateReference(null, 0);
				B.Detach();
				ILDoubleStorage A = (ILDoubleStorage)C.Add(B);
				ILIterator it1;
				errorCode = 0;
				if (C == null)
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 4;
				double[] data = (double[])A.m_data;
				if (data.Length != 18)
					throw new Exception();
				errorCode = 5;
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 6;
				// test Add_RefRef
				A = CR.Add(BR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 7;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 8;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 9;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 10;
				// test Add_PhyRef
				A = C.Add(BR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 11;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 12;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 13;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 14;
				// test Add_RefPhy
				A = CR.Add(B);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 19;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 20;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 21;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 22;
				// test if unknown types throw exceptions 
				try {
					ILStorage<String> gehtNet = new ILStorage<string>(
						new ILDimension(2, 6), new String[] { "hal", "llo1"
						, "hal", "llo2", "hal", "llo3", "hal", "llo4", "hal", "llo5" });
					gehtNet = gehtNet.CreateReference(r, 1);
					A.Add(gehtNet);
					throw new InvalidOperationException();
				}
				catch (Exception e) {
					if (e is InvalidOperationException)
						throw new Exception("Unsupported types should throw exception!");
				}
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
				ILRange r = new ILRange("0:1,0;0,1,2,4,0,2");
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 10,-16,10,10,10,10,10,10,10,100,10
														,10,10,-16,10,10,10,10};
				ILDoubleStorage C = new ILDoubleStorage(new ILDimension(2, 5), data1);
				ILDoubleStorage B = new ILDoubleStorage(new ILDimension(2, 5), data2);
				ILDoubleStorage BR = (ILDoubleStorage)B.CreateReference(r, 1);
				ILDoubleStorage CR = (ILDoubleStorage)C.CreateReference(r, 1);
				C = (ILDoubleStorage)CR.CreateReference(null, 0);
				C.Detach();
				B = (ILDoubleStorage)BR.CreateReference(null, 0);
				B.Detach();
				ILDoubleStorage A = B.Subtract(C);
				ILIterator it1;
				errorCode = 0;
				if (C == null)
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 4;
				double[] data = (double[])A.m_data;
				if (data.Length != 18)
					throw new Exception();
				errorCode = 5;
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 6;
				// test Add_RefRef
				A = BR.Subtract(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 7;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 8;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 9;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 10;
				// test Add_PhyRef
				A = B.Subtract(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 11;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 12;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 13;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 14;
				// test Add_RefPhy
				A = BR.Subtract(C);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 19;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 20;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 21;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 22;
				// test if unknown types throw exceptions 
				try {
					ILStorage<String> gehtNet = new ILStorage<string>(
						new ILDimension(2, 6), new String[] { "hal", "llo1"
						, "hal", "llo2", "hal", "llo3", "hal", "llo4", "hal", "llo5" });
					gehtNet = gehtNet.CreateReference(r, 1);
					A.Subtract(gehtNet);
					throw new InvalidOperationException();
				}
				catch (Exception e) {
					if (e is InvalidOperationException)
						throw new Exception("Unsupported types should throw exception!");
				}
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
				ILRange r = new ILRange("0:1,0;0,1,2,4,0,2");
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 11,-39,75,171,11,75,24,56,96,1100,24,96,11,-39,75,171,11,75};
				ILDoubleStorage C = new ILDoubleStorage(new ILDimension(2, 5), data1);
				ILDoubleStorage B = new ILDoubleStorage(new ILDimension(2, 5), data2);
				ILDoubleStorage BR = (ILDoubleStorage)B.CreateReference(r, 1);
				ILDoubleStorage CR = (ILDoubleStorage)C.CreateReference(r, 1);
				C = (ILDoubleStorage)CR.CreateReference(null, 0);
				C.Detach();
				B = (ILDoubleStorage)BR.CreateReference(null, 0);
				B.Detach();
				ILDoubleStorage A = B.MultiplyElements(C);
				ILIterator it1;
				errorCode = 0;
				if (C == null)
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 4;
				double[] data = (double[])A.m_data;
				if (data.Length != 18)
					throw new Exception();
				errorCode = 5;
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 6;
				// test RefRef
				A = BR.MultiplyElements(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 7;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 8;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 9;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 10;
				// test PhyRef
				A = B.MultiplyElements(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 11;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 12;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 13;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 14;
				// test RefPhy
				A = BR.MultiplyElements(C);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 19;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 20;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 21;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 22;
				// test if unknown types throw exceptions 
				try {
					ILStorage<String> gehtNet = new ILStorage<string>(
						new ILDimension(2, 6), new String[] { "hal", "llo1"
						, "hal", "llo2", "hal", "llo3", "hal", "llo4", "hal", "llo5" });
					gehtNet = gehtNet.CreateReference(r, 1);
					A.MultiplyElements(gehtNet);
					throw new InvalidOperationException();
				} catch (Exception e) {
					if (e is InvalidOperationException)
						throw new Exception("Unsupported types should throw exception!");
				}
				Success("Test_MultiplyElementsDouble successful.");
			} catch (Exception e) {
				Error("Test_MultiplyElementsDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}


		public void Test_DivideDouble() {
			int errorCode = 0;
			// success? 
			try {
				ILPerformer p = new ILPerformer();
				ILRange r = new ILRange("0:1,0;0,1,2,4,0,2");
				double[] data1 = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
				double[] data2 = new double[10] { 11, 12, -13, 14, 15, 16, -17, 18, 19, 110 };
				double[] results = new double[18] { 11.0000,-13.0/3.0,15/5,19.0/9.0,11
								,3.0000,6.0000,3.5000,16.0/6.0,11.0000,6.0000,16.0/6.0,11.0000
													,-13.0/3.0,3.0000,19.0/9.0,11.0000,3.0000};
				ILDoubleStorage C = new ILDoubleStorage(new ILDimension(2, 5), data1);
				ILDoubleStorage B = new ILDoubleStorage(new ILDimension(2, 5), data2);
				// c = reshape(1:10,2,5);
				// c = shiftdim(c([1,2,1],[1,2,3,5,1,3]),1);
				// b = reshape([11, 12, -13, 14, 15, 16, -17, 18, 19, 110],2,5); 
				// b = shiftdim(b([1,2,1],[1,2,3,5,1,3]),1);
				ILDoubleStorage BR = (ILDoubleStorage)B.CreateReference(r, 1);
				ILDoubleStorage CR = (ILDoubleStorage)C.CreateReference(r, 1);
				C = (ILDoubleStorage)CR.CreateReference(null, 0);
				C.Detach();
				B = (ILDoubleStorage)BR.CreateReference(null, 0);
				B.Detach();
				ILDoubleStorage A = B.Divide(C);
				ILIterator it1;
				errorCode = 0;
				if (C == null)
					throw new Exception();
				errorCode = 1;
				if (A.Dimensions.NumberOfDimensions != 2)
					throw new Exception();
				errorCode = 2;
				if (A.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 3;
				if (A.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 4;
				double[] data = (double[])A.m_data;
				if (data.Length != 18)
					throw new Exception();
				errorCode = 5;
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 6;
				// test Add_RefRef
				A = BR.Divide(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 7;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 8;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 9;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 10;
				// test PhyRef
				A = B.Divide(CR);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 11;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 12;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 13;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 14;
				// test RefPhy
				A = BR.Divide(C);
				it1 = A.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < results.Length; i++) {
					if (it1.Value != results[i])
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				errorCode = 19;
				if (A.Dimensions[0] != 6 | B.Dimensions[0] != 6)
					throw new Exception();
				errorCode = 20;
				if (A.Dimensions[1] != 3 | B.Dimensions[1] != 3)
					throw new Exception();
				errorCode = 21;
				if (A.m_data.Length != 18)
					throw new Exception();
				errorCode = 22;
				// test if unknown types throw exceptions 
				try {
					ILStorage<String> gehtNet = new ILStorage<string>(
						new ILDimension(2, 6), new String[] { "hal", "llo1"
						, "hal", "llo2", "hal", "llo3", "hal", "llo4", "hal", "llo5" });
					gehtNet = gehtNet.CreateReference(r, 1);
					A.Divide(gehtNet);
					throw new InvalidOperationException();
				}
				catch (Exception e) {
					if (e is InvalidOperationException)
						throw new Exception("Unsupported types should throw exception!");
				}
				errorCode = 23; 
				ILDimension d = new ILDimension(1000,1000,10);
				data1 = new double[d.NumberOfElements];
				data2 = new double[d.NumberOfElements];
				for (int i = 0; i < d.NumberOfElements-1; i ++) {
					data1[i] = 3; 
					data2[i] = 2; 
				}
				data1[data1.Length - 1] = 3;
				data2[data2.Length - 1] = 0;  // test auf NaN 
				ILDoubleStorage large1 = new ILDoubleStorage(d, data1);
				ILDoubleStorage large2 = new ILDoubleStorage(d, data2);
				p.Tic();
				ILDoubleStorage large3 = large1.Divide(large2);
				p.Toc();
				it1 = large3.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < data1.Length - 1; i++) {
					if (it1.Value != 1.5)
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				Info("  " + d.ToString() + "phy/phy: " + p.ToString() + "ms needed...");
				errorCode = 24;  // test ref/ref
				if (! Double.IsInfinity(it1.Value))
					throw new Exception("NaN expected.");
				errorCode = 25;
				large2 = (ILDoubleStorage)large1.CreateReference(null, 1);
				large1 = (ILDoubleStorage)large1.CreateReference(null, 1);
				p.Tic();
				large3 = large1.Divide(large2);
				p.Toc();
				it1 = large3.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < data1.Length; i++) {
					if (it1.Value != 1.0)
						throw new Exception("Values did not match!");
					it1.Increment();
				} 
				Info("  " + d.ToString() + "ref/ref: " + p.ToString() + "ms needed...");
				errorCode = 26;
				large1.Detach();
				p.Tic();
				large3 = large1.Divide(large2);
				p.Toc();
				it1 = large3.CreateIterator(0, ILIteratorPositions.ILStart);
				for (int i = 0; i < data1.Length; i++) {
					if (it1.Value != 1.0)
						throw new Exception("Values did not match!");
					it1.Increment();
				}
				Info("  " + d.ToString() + "phy/ref: " + p.ToString() + "ms needed...");

				Success("Test_DivideDouble successful.");
			}
			catch (Exception e) {
				Error("Test_DivideDouble failed at step: " + errorCode + " Msg: " + e.Message);
			}
		}
		public void Test_PerformLarge() {
            int errorCode = 0;
            try
            {
                double[] data1 = new double[1000000];
                double[] data2 = new double[1000000];

                for (int i = 0; i < data1.Length; i++)
                {
                    data1[i] = i;
                    data2[i] = i + 2;
                }
                ILDoubleArray A = new ILDoubleArray(data1, 1000000, 1);
                ILDoubleArray B = new ILDoubleArray(data2, 1000000, 1);
                ILPerformer p = new ILPerformer();
                errorCode = 1;
                ILDoubleArray C = A.Add(B);
                p.Toc();
                Info("  Dim: 1 000 000x1 phy/phy: " + p.ToString() + "ms needed... ");
                errorCode = 2;

                ILDoubleArray BR = (ILDoubleArray)B[null, 1];
                p.Tic();
                C = ((ILDA)A[null, 1]).Add(BR);
                p.Toc();
                Info("  Dim: 1 000 000x1 ref/ref: " + p.ToString() + "ms needed... ");
                errorCode = 3;

                A = (ILDA)A[null, 1].Detach();
                p.Tic();
                C = A.Add(BR);
                p.Toc();
                Info("  Dim: 1 000 000x1 phy/ref: " + p.ToString() + "ms needed... ");
                errorCode = 4;

                BR = (ILDoubleArray)B["1:end", 1];
                p.Tic();
                C = ((ILDA)A["0;1:end", 0]).Add(BR);
                p.Toc();
                Info("  Dim: 999 999x1,1 ref/ref: " + p.ToString() + "ms needed... ");
                errorCode = 5;

                A = (ILDA)A["0;1:end", 1].Detach();
                p.Tic();
                C = A.Add(BR);
                p.Toc();
                Info("  Dim: 999 999x1,1 phy/ref: " + p.ToString() + "ms needed... ");
                Success("Test_PerformLarge successful.");
            }
            catch (Exception e)
            {
                Error("Test_PerformLarge: Error processing at error Code: " + errorCode + " Msg: " + e.Message);
            }


		}

	}
}
