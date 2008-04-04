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
using ILNumerics.Data; 
using ILNumerics.Misc; 

namespace ILNumerics.Test {
    public class TESTBucketSort : ILTest {
        
        System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();  
        
        public override void Run() {
            base.Run();

            TestBucketSort(new string [] {"d","a","aba","aaaa","cab"}, new string[] {"a","aaaa","aba","cab","d"}); 
            TestBucketSort_Performance(generateStringsRandom(2000,1000)); 
            TestBucketSortArrayMatrixRow(); 
        }
        private void TestBucketSortArrayMatrixRow() {
            try {
                ILArray<string> A = new ILArray<string>(3,4); 
                A[0,0] = "abc"; 
                A[0,1] = "rtu"; 
                A[0,2] = "sfkw"; 
                A[0,3] = "lsdkfi"; 
                A[1,0] = "iowejkc"; 
                A[1,1] = "cjks"; 
                A[1,2] = "wokys"; 
                A[1,3] = "suem,"; 
                A[2,0] = "fgj"; 
                A[2,1] = "JKSF"; 
                A[2,2] = "SEs"; 
                A[2,3] = "SEFsr"; 
                ILArray<double> ind; 
                ILArray<string> res = ILMath.sort(A,out ind,0,false); 
                if (!res.Equals(A[ind]))
                    throw new Exception("invalid indices/values detected");
                ILArray<Int16> indI = ILMath.toint16(ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray())); 
                res = ILMath.sort(A,ref indI, 0, true, new ILASCIIKeyMapper()); 
                if (!res.Equals(A[indI]))
                    throw new Exception("invalid indices/values detected");

                Success(" elapsed: " + m_stopwatch.ElapsedMilliseconds + " ms"); 
            } catch (Exception e) {
                Error(0, e.Message); 
            }
        }
        private void TestBucketSort(string[] p, string[] p_2) {
            int errCode = 0; 
            try {
                ILQueueList<string,byte> res = ILBucketSort.BucketSort<string,char,byte>(p,null,new ILASCIIKeyMapper(), ILBucketSort.SortMethod.VariableLenth);
                
                if (!StringsEqual(p_2,res.ToArray()))
                    throw new Exception("invalid values detected!");
                Success(PrintStrings(p)); 
            } catch (Exception e) {
                Error(errCode,e.Message + "(" + PrintStrings(p) + ")"); 
            }
        }
        private void TestBucketSort_Performance(string[] p) {
            int errCode = 0; 
            try {
                // test constant length method
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                ILQueueList<string,byte> res1 = ILBucketSort.BucketSort<string,char,byte>(p,null,new ILASCIIKeyMapper(), ILBucketSort.SortMethod.ConstantLength);
                sw.Stop(); 
                Info("sorting variable length: " + sw.ElapsedMilliseconds + " ms needed."); 
                string [] res = res1.ToArray(); 
                // test variable length method
                sw.Reset();
                sw.Start(); 
                ILQueueList<string,byte> res2 = ILBucketSort.BucketSort<string,char,byte>(p,null,new ILASCIIKeyMapper(), ILBucketSort.SortMethod.VariableLenth);
                sw.Stop(); 
                if (!StringsEqual(res1.ToArray(),res2.ToArray())) {
                    throw new Exception("different result for methods detected!");
                }
                Success("Sorted " + p.Length + " strings."); 
            } catch (Exception e) {
                Error(errCode,e.Message + "(" + PrintStrings(p) + ")"); 
            }
        }

        void bsortConstant_StateChanged(object sender, ILAlgorithmEventArgs e) {
            if (m_stopwatch == null) {
                m_stopwatch = new System.Diagnostics.Stopwatch(); 
            }
            switch (e.State) {
                case ILAlgorithmState.Running: 
                    m_stopwatch.Reset(); 
                    m_stopwatch.Start();
                    break; 
                case ILAlgorithmState.Finished:
                    m_stopwatch.Stop(); 
                    Info("Last operation finished in: " + m_stopwatch.ElapsedMilliseconds + " ms" + Environment.NewLine); 
                    break;
                default: 
                    m_stopwatch.Stop(); 
                    break; 
            }
        }
        private string PrintStrings (string [] stringArr) {
            StringBuilder sb = new StringBuilder(); 
            foreach (string s in stringArr) {
                sb.Append("\"" + s + "\",");                 
            }
            return sb.ToString(); 
        }

        private bool StringsEqual(string[] p1, string[] p2) {
            if (p1.Length != p2.Length) 
                return false; 

            for (int i = 0; i < p1.Length; i++)
			{
                if (p1[i].CompareTo(p2[i]) != 0) 
                    return false; 
			}
            return true; 
        }

        private string[] generateStringsRandom(int count, int maxLen) {
            string [] ret = new string[count];
            ILArray<int> r = ILMath.toint32(ILMath.rand(maxLen,count) * 26)+ (int)'a'; 
            ILArray<int> lens = ILMath.toint32(ILMath.rand(1,count) * (maxLen-1));
            for (int i = 0; i < count; i++) {
                ILArray<double> rang = ILMath.vector(0,lens.GetValue(i)); 
                ILArray<char> chars = ILMath.tochar(r[rang,i]);
                ret[i] = new String(chars.Detach().m_data); 
            }
            return ret; 
        }
    }
}
