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
using System.Collections; 
using System.Text;
using ILNumerics.Test;
using ILNumerics.Algorithms; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Storage;
using ILNumerics.Misc; 

namespace ILNumerics.Test {
    public class TESTQuickSort : ILTest {
        
        System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();  
        
        public override void Run() {
            Header(); 
            base.Run();
            TestQuickSortAscIDX(0,15); 
            TestQuickSortAscIDX(1,12); 
            TestQuickSortAscIDX(2,100); 
            TestQuickSortAscIDX(3,1000); 
            TestQuickSortDescIDX(0,15); 
            TestQuickSortDescIDX(1,12); 
            TestQuickSortDescIDX(2,100); 
            TestQuickSortDescIDX(3,1000); 
            TestQuickSortGen(ILMath.rand(2000,1000) * 10,1,true); 
            TestQuickSortDesc();
            TestQuickSortAsc(); 
            Test_SortSpeed (100000); 
            TestQuickSortDescIDX();
            TestQuickSortGen(ILMath.rand(1,1000000) * 1000000.0,1,true); 
            TestQuickSortLoop(1000,1000); 
            TestQuickSort(ILMath.rand(1,10).m_data); 
            Footer(); 
        }

        public class DescComparerDouble : IComparer {
            public int Compare(object x, object y) {
                return -1 * ((double)x).CompareTo((double)y); 
            }
        }

        private void Test_SortSpeed(int length) {
            try {
                ILArray<double> ResILN = null, ResCLR = null, A = null; 
                long durILN = 0, durCLR = 0; 
                Misc.ILPerformer p = new ILNumerics.Misc.ILPerformer(); 
                for (int i = 0; i < 10; i++) {
                    A = ILMath.randn(length,1);
                    p.Tic(); 
                    ILMath.sort(A); 
                    p.Toc(); 
                    durILN += p.Duration; 
                    ResCLR = A.C; 
                    p.Tic(); 
                    Array.Sort(ResCLR.m_data); 
                    p.Toc(); 
                    durCLR += p.Duration; 
                }
                ResILN = ILMath.sort(A);
                if (!ResCLR.Equals(ResILN)) 
                    throw new Exception("invalid values!"); 
                Info(String.Format("ILNumerics.Net sort {1} needed: {0}ms",durILN / 10,A.Dimensions.ToString())); 
                Info(String.Format("CLR Array.Sort {1} needed: {0}ms",durCLR / 10,A.Dimensions.ToString())); 
                // descending 
                durCLR = 0; durILN = 0; 
                IComparer comparer = new DescComparerDouble(); 
                for (int i = 0; i < 10; i++) {
                    A = ILMath.randn(length,1);
                    p.Tic(); 
                    ResILN = ILMath.sort(A,true); 
                    p.Toc(); 
                    durILN += p.Duration; 
                    ResCLR = A.C; 
                    p.Tic(); 
                    Array.Sort(ResCLR.m_data,comparer); 
                    p.Toc(); 
                    durCLR += p.Duration; 
                }
                if (!ResCLR.Equals(ResILN)) 
                    throw new Exception("invalid values!"); 
 
                Info(String.Format("ILNumerics.Net sort {1} desc, needed: {0}ms",durILN / 10,A.Dimensions.ToString())); 
                Info(String.Format("CLR Array.Sort {1} desc, needed: {0}ms",durCLR / 10,A.Dimensions.ToString())); 


            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }
        private void TestQuickSortDescIDX() {
            try {
                ILArray<double> A = ILMath.counter(5,4,3); 
                System.Diagnostics.Debug.Assert(!A.IsReference); 
                ILArray<double> ind; 
                ILArray<double> result = ILMath.sort(A,out ind, 1,true); 
                ILArray<double> expect = A[":;3,2,1,0;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                expect = ILMath.repmat(new ILArray<double>(new double[]{3,2,1,0}),5,1,3); 
                if (!ind.Equals(expect))
                    throw new Exception("invalid indices"); 
                // test scalar 
                A = 3.0; 
                result = ILMath.sort(A,out ind,0,true); 
                if (result != 3.0) {
                    throw new Exception("invalid values: scalar");
                }
                if (ind != 0.0) 
                    throw new Exception("invalid indices"); 
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.sort(A,out ind, 0,true).IsEmpty)
                    throw new Exception("invalid values: empty");
                if (!ind.IsEmpty) {
                    throw new Exception("invalid indices"); 
                }
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }
        private void TestQuickSortAscIDX(int dim, int len) {
            try {
                // asc along dimension (already ordered values) 
                int[] dims = new int[4] {5,4,3,2}; 
                dims[dim] = len; 
                ILArray<double> A = ILMath.counter(dims); 
                ILArray<double> ind; 
                ILArray<double> result = ILMath.sort(A,out ind, dim, false); 
                ILArray<double> expect = A.C; 
                ILArray<double> expectInd; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                int [] dimsEx = new int[dims.Length]; int i; 
                expectInd = ILMath.counter(0.0,1.0,1, A.Dimensions[dim]);
                expectInd = ILMath.repmat(expectInd,A.Dimensions.SequentialIndexDistance(dim),1);
                for (i = 0; i < dimsEx.Length; i++) {
                    if (i <= dim) dimsEx[i] = dims[i]; 
                    else dimsEx[i] = 1; 
                }
                expectInd = ILMath.reshape(expectInd,dimsEx); 
                for (i = 0; i < dimsEx.Length; i++) {
                    if (i <= dim) dimsEx[i] = 1; 
                    else dimsEx[i] = dims[i]; 
                }
                expectInd = ILMath.repmat(expectInd,dimsEx); 
                if (!ind.Equals(expectInd))
                    throw new Exception("invalid indices"); 
                // reverse values ... 
                A = ILMath.counter(A.Dimensions.NumberOfElements, -1.0, dims); 
                result = ILMath.sort(A,out ind, dim ,false); 
                expectInd = ILMath.counter(A.Dimensions[dim]-1,-1.0,1, A.Dimensions[dim]);
                ILBaseArray[] revDims = new ILBaseArray[dims.Length];
                revDims[dim] = expectInd; 

                expect = A[revDims]; 
                expectInd = ILMath.repmat(expectInd,A.Dimensions.SequentialIndexDistance(dim),1);
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                for (i = 0; i < dimsEx.Length; i++) {
                    if (i <= dim) dimsEx[i] = dims[i]; 
                    else dimsEx[i] = 1; 
                }
                expectInd = ILMath.reshape(expectInd,dimsEx); 
                for (i = 0; i < dimsEx.Length; i++) {
                    if (i <= dim) dimsEx[i] = 1; 
                    else dimsEx[i] = dims[i]; 
                }
                expectInd = ILMath.repmat(expectInd,dimsEx); 
                if (!ind.Equals(expectInd))
                    throw new Exception("invalid indices"); 
                // test scalar 
                A = 3.0; 
                result = ILMath.sort(A,out ind,0,false); 
                if (result != 3.0) {
                    throw new Exception("invalid values: scalar");
                }
                if (ind != 0.0) 
                    throw new Exception("invalid indices"); 
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.sort(A,out ind, 0,false).IsEmpty)
                    throw new Exception("invalid values: empty");
                if (!ind.IsEmpty) {
                    throw new Exception("invalid indices"); 
                }
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }
        private void TestQuickSortDescIDX(int dim, int len) {
            try {
                // asc along dimension (already ordered values) 
                int[] dims = new int[4] {5,4,3,2}; 
                dims[dim] = len; 
                ILArray<double> A = ILMath.counter(dims); 
                ILArray<double> ind; 
                ILArray<double> result = ILMath.sort(A, out ind, dim, true); 
                ILArray<double> expect = null; 
                ILArray<double> expectInd; 
                expectInd = ILMath.counter(A.Dimensions[dim]-1,-1.0,1, A.Dimensions[dim]);
                ILBaseArray[] revDims = new ILBaseArray[dims.Length];
                revDims[dim] = expectInd; 
                expect = A[revDims]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 

                int [] dimsEx = new int[dims.Length];
                expectInd = ILMath.repmat(expectInd,A.Dimensions.SequentialIndexDistance(dim),1);
                sortIDXTestHelper001(dim, dims, ref expectInd, dimsEx);
                expectInd = ILMath.repmat(expectInd,dimsEx); 
                if (!ind.Equals(expectInd))
                    throw new Exception("invalid indices"); 
                // reverse values ... 
                A = ILMath.counter(A.Dimensions.NumberOfElements, -1.0, dims); 
                result = ILMath.sort(A,out ind, dim ,true); 
                if (!result.Equals(A.C))
                    throw new Exception("invalid values"); 

                expectInd = ILMath.counter(0.0,1.0,1, A.Dimensions[dim]);
                expectInd = ILMath.repmat(expectInd,A.Dimensions.SequentialIndexDistance(dim),1);
                sortIDXTestHelper001(dim, dims, ref expectInd, dimsEx);
                expectInd = ILMath.repmat(expectInd,dimsEx); 
                if (!ind.Equals(expectInd))
                    throw new Exception("invalid indices"); 
                // test scalar 
                A = 3.0; 
                result = ILMath.sort(A,out ind,0,true); 
                if (result != 3.0) {
                    throw new Exception("invalid values: scalar");
                }
                if (ind != 0.0) 
                    throw new Exception("invalid indices"); 
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.sort(A,out ind, 0,true).IsEmpty)
                    throw new Exception("invalid values: empty");
                if (!ind.IsEmpty) {
                    throw new Exception("invalid indices"); 
                }
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }

        private static void sortIDXTestHelper001(int dim, int[] dims, ref ILArray<double> expectInd, int[] dimsEx) {
            int i;
            for (i = 0; i < dimsEx.Length; i++) {
                if (i <= dim) dimsEx[i] = dims[i];
                else dimsEx[i] = 1;
            }
            expectInd = ILMath.reshape(expectInd, dimsEx);
            for (i = 0; i < dimsEx.Length; i++) {
                if (i <= dim) dimsEx[i] = 1;
                else dimsEx[i] = dims[i];
            }
        }
        private void TestQuickSortDesc() {
            try {
                ILArray<double> A = ILMath.counter(5,4,3); 
                System.Diagnostics.Debug.Assert(!A.IsReference); 
                ILArray<double> result = ILMath.sort(A,1,true); 
                ILArray<double> expect = A[":;3,2,1,0;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                // test scalar 
                A = 3.0; 
                result = ILMath.sort(A,0,true); 
                if (result != 3.0) {
                    throw new Exception("invalid values: scalar");
                }
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.sort(A,0,true).IsEmpty)
                    throw new Exception("invalid values: empty");
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }
        private void TestQuickSortAsc() {
            try {
                ILArray<double> A = ILMath.counter(5,4,3); 
                System.Diagnostics.Debug.Assert(!A.IsReference); 
                ILArray<double> result = ILMath.sort(A,1,false); 
                ILArray<double> expect = A[":;:;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                // test real sortable values
                A = ILMath.counter(60.0,-1.0,5,4,3);
                result = ILMath.sort(A,1,false); 
                expect = A[":;3,2,1,0;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values");
                // test ascending values to sort ascending
                A = ILMath.counter(1.0,1.0,11,2); 
                result = ILMath.sort(A,0,false); 
                if (!result.Equals(A)) {
                    throw new Exception("invalid values"); 
                }
                // test descending values to sort ascending
                A = ILMath.counter(22.0,-1,11,2); 
                result = ILMath.sort(A,0,false); 
                expect = ILMath.counter(1.0,1.0,11,2)[":;1,0"]; 
                if (!result.Equals(expect)) {
                    throw new Exception("invalid values"); 
                }
                // test scalar 
                A = 3.0; 
                result = ILMath.sort(A,0,false); 
                if (result != 3.0) {
                    throw new Exception("invalid values: scalar");
                }
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.sort(A,0,false).IsEmpty)
                    throw new Exception("invalid values: empty");
                // test nan
                A = ILMath.counter(1.0,1.0,20,2); 
                A[2] = double.NaN; 
                A[4] = double.PositiveInfinity; 
                A[8] = double.NegativeInfinity; 
                A[18] = double.NegativeInfinity; 
                A[14] = double.NaN; 
                result = ILMath.sort(A,0,false); 
                expect = ILMath.counter(1.0,1.0,20,2);
                expect[":;0"] = new double[] { 
                    double.NegativeInfinity, 
                    double.NegativeInfinity,
                    1,2,4,6,7,8,10,11,12,13,14,16,17,18,20,
                    double.PositiveInfinity,
                    double.NaN,
                    double.NaN
                }; 
                if (!result.Equals(expect)) {
                    throw new Exception("invalid values"); 
                }
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }

        private void TestQuickSortGen(ILArray<double> input,int dim, bool desc) {
            try {
                ILArray<int> A = ILMath.toint32( input ); 
                try {
                    ILMatFile f1 = new ILMatFile("tempADebugQuickSort.mat");
                    A = (ILArray<int>)f1["DebugQuickSort"]; 
                } catch (Exception) {}

                ILArray<int> result;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); 
                sw.Start();
                result = ILMath.sort(A,dim,desc); 
                sw.Stop(); 
                if (!isSorted(ILMath.todouble(result),dim,desc)) {
                    //ILMatFile f = new ILMatFile(); 
                    //A.Name = "DebugQuickSort"; 
                    //f.Add(A); 
                    //System.IO.Stream s = new System.IO.FileStream("tempADebugQuickSort.mat",System.IO.FileMode.CreateNew); 
                    //f.Write(s); 
                    throw new Exception("invalid values"); 
                }
                Success(input.Dimensions.ToString() + "(Int32) needed: " + sw.ElapsedMilliseconds + " ms"); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }

        private bool isSorted(ILArray<double> input, int dim, bool descending) {
            if (input.IsEmpty || input.IsScalar) return true; 
            ILIterator<double> it = input.CreateIterator(ILIteratorPositions.ILStart,dim); 
            double tmpold = it.Value;
            double tmpnew = it.Increment(); 
            int dimpos = 1; 
            while (!it.IsAtStart()) {
                if (++dimpos % input.Dimensions[dim] != 1) {
                    if (descending) {
                        if (tmpnew > tmpold) return false; 
                    } else {
                        if (tmpnew < tmpold) return false; 
                    }
                }
                tmpold = tmpnew; 
                tmpnew = it.Increment(); 
            }
            return true; 
        }

        private void TestQuickSortLoop(int len, int rep) {
            try {
                m_stopwatch.Stop(); 
                m_stopwatch.Reset();
                for (int r = 0; r < rep; r++) {
                    double[] p = ILMath.rand(1,len).m_data; 
                    m_stopwatch.Start(); 
                    ILQuickSort.QuickSortAscSolid_IT(p,0,len-1,1);
                    m_stopwatch.Stop(); 
                    if (! ILMath.IsSorted(p,false))
                        throw new Exception("unsorted values detected (asc). Size: " + p.Length);
                    // descending 
                    ILQuickSort.QuickSortDescSolid_IT(p,0,len-1,1);
                    if (! ILMath.IsSorted(p,true))
                        throw new Exception("unsorted values detected (desc). Size: " + p.Length);

                }
                Success(" elapsed: " + m_stopwatch.ElapsedMilliseconds + " ms"); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }

        private void TestQuickSort(double[] p) {
            int errCode = 0; 
            try {
                m_stopwatch.Reset(); 
                ILQuickSort.QuickSortAscSolid_IT(p,0,p.Length-1,1);
                m_stopwatch.Stop(); 
                if (!ILMath.IsSorted(p,false)) 
                    throw new Exception("unsorted values detected. Size: " + p.Length); 
                Success(); 
            } catch (Exception e) {
                Error(errCode,e.Message); 
            }
        }

    }
}