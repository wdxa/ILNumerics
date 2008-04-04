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
using ILNumerics.Test;
using ILNumerics.Algorithms; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Storage; 

namespace ILNumerics.Test {
    public class TESTQuickSort : ILTest {
        
        System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();  
        
        public override void Run() {
            base.Run();
            TestQuickSortDesc();
            TestQuickSortAsc(); 
            TestQuickSortDescIDX();
            TestQuickSortAscIDX(); 
            TestQuickSortGen(ILMath.rand(2000,1000) * 10,1,true); 
            TestQuickSortGen(ILMath.rand(1,1000000) * 1000000.0,1,true); 
            TestQuickSortLoop(1000,1000); 
            TestQuickSort(ILMath.rand(1,10).m_data); 
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
                if (!ind.Equals(ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray())[":;3,2,1,0;:"]))
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
        private void TestQuickSortAscIDX() {
            try {
                ILArray<double> A = ILMath.counter(5,4,3); 
                System.Diagnostics.Debug.Assert(!A.IsReference); 
                ILArray<double> ind; 
                ILArray<double> result = ILMath.sort(A,out ind, 1,false); 
                ILArray<double> expect = A[":;:;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                if (!ind.Equals(ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray())[":;:;:"]))
                    throw new Exception("invalid indices"); 
                // true sortable values... 
                A = ILMath.counter(60.0,-1.0,5,4,3); 
                result = ILMath.sort(A,out ind, 1,false); 
                expect = A[":;3,2,1,0;:"]; 
                if (!result.Equals(expect))
                    throw new Exception("invalid values"); 
                if (!ind.Equals(ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray())[":;3,2,1,0;:"]))
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
                Success(); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }

        private void TestQuickSortGen(ILArray<double> input,int dim, bool desc) {
            try {
                ILArray<int> A = ILMath.toint32( input ); 
                ILArray<int> result;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); 
                sw.Start();
                result = ILMath.sort(A,dim,desc); 
                sw.Stop(); 
                if (!isSorted(ILMath.todouble(result),dim,desc))
                    throw new Exception("invalid values"); 
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
                    ILQuickSort.QuickSortAscSolid(p,0,len-1,1);
                    m_stopwatch.Stop(); 
                    if (! ILMath.IsSorted(p,false))
                        throw new Exception("unsorted values detected (asc). Size: " + p.Length);
                    // descending 
                    ILQuickSort.QuickSortDescSolid(p,0,len-1,1);
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
                ILQuickSort.QuickSortAscSolid(p,0,p.Length-1,1);
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