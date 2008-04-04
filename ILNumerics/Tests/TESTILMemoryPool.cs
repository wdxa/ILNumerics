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
	public class TESTILMemoryPool : ILTest {

		public override void Run() {
			Header();
            Test_Basic(); 
            MeasurePool(); 
            Footer();
		}
        public void MeasurePool() {
            Info("Measuring memory pool performance");
            Info("---------------------------------"); 
            ILArray<int> Lengths  = ILMath.toint32(ILMath.vector(1000000,1000,1000000)); 
            ILArray<int> PoolSizes  = ILMath.toint32(ILMath.vector(00,10,250)); 
            ILArray<double> result = ILMath.zeros(Lengths.Length, PoolSizes.Length);
            ILArray<double> dataA = ILMath.ones(1000,1000); 
            ILArray<double> dataB = ILMath.ones(1000,1000); 
            int counter = 1, countAll = Lengths.Length * PoolSizes.Length; 
            for (int p = 0; p < PoolSizes.Length; p++) {
                for (int s = 0; s < Lengths.Length; s++) {
                    result[s,p] = MeasurePoolParameter((int)Lengths[s],(int)PoolSizes[p],100,dataA,dataB);     
                    Console.Out.Write(String.Format("\r... step {0} of {1} completed",counter++,countAll));
                }
            }
            result.Name = "results"; 
            ILMatFile mf = new ILMatFile();
            mf["results"] = result; 
            mf["lengths"] = Lengths; 
            mf["poolSizes"] = PoolSizes;
            mf.Write(new FileStream("memoryPoolTestPerf.mat",FileMode.Create)); 
        }
        public long MeasurePoolParameter(int minArraySize, int maxPoolSize, int iter, ILArray<double> A, ILArray<double> B) {
            ILMemoryPool.Pool.Collect(); 
            ILMemoryPool.Pool.Reset(minArraySize,maxPoolSize);
            ILPerformer mon = new ILPerformer(); 
            ILArray<double> C = ILMath.zeros(A.Dimensions); 
            ILArray<double> t1,t2; 
            mon.Tic(); 
            for (int i = 0; i < iter; i++) {
                t1 = A + B; 
                t2 = C + t1; 
                t1.Dispose(); 
                C.Dispose(); 
                C = t2; 
            }  
            mon.Toc(); 
            return mon.Duration;  
        }
        public void Test_Basic() {
            int errorCode = 0; 
            try {
                ILMemoryPool.Pool.Reset(100,200); 
                ILArray<double> A = ILMath.rand(30,30); 
                double[] aArr = A.m_data; 
                ILArray<double> B = A.C; 
                A.Dispose(); 
                // A's array should be in pool now - query
                double[] retArr = ILMemoryPool.Pool.New<double>(B.Dimensions.NumberOfElements); 
                ILArray<double> Res = new ILArray<double>(retArr,B.Dimensions.Clone()); 
                if (!Res.Equals(B) || aArr != retArr) {
                    throw new Exception("the expected array was not returned from pool!"); 
                }
                // query again - should return new array 
                aArr = ILMemoryPool.Pool.New<double>(B.Dimensions.NumberOfElements);
                if (aArr == retArr) 
                    throw new Exception("after reclaiming array should be removed from pool!"); 
                // test if zero cleares everything; 
                Res.Dispose(); 
                Res = ILMath.zeros(B.Dimensions); 
                // Res should have the same array, but cleared ? 
                if (Res.m_data != retArr)
                    throw new Exception("unexpected array returned from pool"); 
                B = new ILArray<double>(new double[30*30],30,30);
                if (!Res.Equals(B))
                    throw new Exception("invalid values - ILMath.zeros should return zeros!"); 
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
						if (1 == 1)
							throw new Exception();
						Success();
					}
					catch (Exception e) {
						Error(errorCode, e.Message);
					}
				}
		*/
	}
}
