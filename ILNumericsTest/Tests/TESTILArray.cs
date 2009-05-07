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
	public class TESTILArray : ILTest {

        public override void Run() {
			 // tests: creation
			// =================
			Header();
            //Test_ReferenceBugTest();
            //Test_SingleIndexResizingWrite();
            Test_MinValue();
            Test_MaxValue(); 
            Test_Test2(); 
            Test_Expand(); 
            Test_Cast(); 
            Test_TrailingSingletonDimension(); 
            Test_SequentialLogicalAccess(); 
            Test_singleElementWriteAccessReference();
            Test_singleElementWriteAccessPhysical();
            Test_singleElementAccess(); 
            Test_SetRange_RangedPhysical(); 
            Test_Remove();
            Test_TypeAfterRemoval(); 
            Test_CreatePhysicalSubarrayFromReference_stringDef();
            Test_CreateReferenceSubarrayFromReference_stringDef();
            Test_CreatePhysicalSubarrayFromPhysicalShifted_stringDef();
            Test_CreatePhysicalSubarrayFromPhysical_stringDef();
            Test_CreatePhysicalSubarrayFromReferenceShifted_stringDef();
            Test_CreatePhysicalSubarrayFromReferenceSequentialShifted();
            Test_CreatePhysicalSubarrayFromReferenceSequential();
            Test_CreatePhysicalSubarrayFromPhysicalSequentialShifted();
            Test_CreatePhysicalSubarrayFromPhysicalSequential();
            Test_CreateReferenceSubarrayFromReferenceShifted_stringDef();
            Test_CreateReferenceSubarrayFromArraySequential();
            Test_CreateReferenceSubarrayFromArraySequentialShifted(); 
            Test_CreateReferenceSubarrayFromPhysicalShifted_stringDef(); 
            Test_CreateReferenceSubarrayFromPhysical_stringAddr();
            Test_CreateReferenceSubarrayFromArraySequentialShifted(); 
            Test_Subarray_RefShiftedFromPhysical(); 
            Test_Subarray_RefShiftedFromReference(); 
            Test_IndexAccessPhysicalSequential();
            Test_IndexAccessPhysfromPhysShifted();
            Test_IndexAccessPhysfromPhys();
            Test_Shifted(); 
            Test_CopyFromArray();
            Test_IndexAccess(); 
            Test_ReferenceFromArray();
            Test_IsNumeric(); 
            Test_Enumerator(); 
            Test_EnumeratorIT(); 
			Test_EnumeratorPerf(ILMath.rand(100,100,300)); 
			Footer();
		}

        public void Test_Test2() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = new double[,]{{1.0, 2.0, 3.0}, {58.0, -10.0, Math.PI}}; 
                ILArray<double> B = A[null,1.0];  
                B = A["1,2",":"];      
                ILArray<double> I = ILMath.zeros(1,5); 
                A = ILMath.counter(5,4,3); 
                double min, max; 
                A.GetLimits(out min, out max); 
                Success(); 
                int i1, i2; 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_Cast() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = new double[,]{{1.0,2.0,3.0},{5.0,6.0,7.0}};
                if (A.Dimensions[0]!= 3 || A.Dimensions[1] != 2)
                    throw new Exception("invalid shape of implicit cast result: [,]"); 
                A = new double[,,]{{{1.0,2.0,3.0},{4.0,5.0,6.0}},
                                   {{7.0,8.0,9.0},{10.0,11.0,12.0}}};
                if (A.Dimensions[0]!= 3 || A.Dimensions[1] != 2 || A.Dimensions[2] != 2)
                    throw new Exception("invalid shape of implicit cast result: [,,]"); 
                if (!A.Equals(ILMath.counter(3,2,2)))
                    throw new Exception("invalid result: cast from [,,]"); 
                try {
                    ILArray<int> I = new double[,,]{{{1.0,2.0,3.0},{4.0,5.0,6.0}},
                                   {{7.0,8.0,9.0},{10.0,11.0,12.0}}};
                } catch (ILCastException e) {
                    Info ("cast wrong type: exception thrown ok"); 
                }
                ILArray<int> B = new int[]{3,4,5,6,7,8,9}; 
                if (!B.IsRowVector) 
                    throw new Exception("row vector expected: cast[]"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        
        public void Test_MaxValue() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = new double[]{double.NaN,double.NaN,double.NaN};
                double max = A.MaxValue;
                if (!double.IsNaN(max)) 
                    throw new Exception("max value should be NaN for row vector of double.NaN's!");
                ILArray<float> Af = new float[] {float.NaN,float.NaN,float.NaN};
                float maxf = Af.MaxValue; 
                if (!float.IsNaN(maxf)) {
                    throw new Exception("max value should be NaN for row vector of float.NaN's!");
                }
                ILArray<fcomplex> Afc = new fcomplex[] {fcomplex.NaN,fcomplex.NaN,fcomplex.NaN};
                fcomplex maxfc = Afc.MaxValue; 
                if (!fcomplex.IsNaN(maxfc)) {
                    throw new Exception("max value should be NaN for row vector of fcomplex.NaN's!");
                }
                ILArray<complex> Ac = new complex[] {complex.NaN,complex.NaN,complex.NaN};
                complex maxc = Ac.MaxValue; 
                if (!complex.IsNaN(maxc)) {
                    throw new Exception("max value should be NaN for row vector of complex.NaN's!");
                }
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_MinValue() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = new double[]{double.NaN,double.NaN,double.NaN};
                double max = A.MinValue;
                if (!double.IsNaN(max)) 
                    throw new Exception("max value should be NaN for row vector of double.NaN's!");
                ILArray<float> Af = new float[] {float.NaN,float.NaN,float.NaN};
                float maxf = Af.MinValue; 
                if (!float.IsNaN(maxf)) {
                    throw new Exception("MinValue  should be NaN for row vector of float.NaN's!");
                }
                ILArray<fcomplex> Afc = new fcomplex[] {fcomplex.NaN,fcomplex.NaN,fcomplex.NaN};
                fcomplex maxfc = Afc.MinValue; 
                if (!fcomplex.IsNaN(maxfc)) {
                    throw new Exception("MinValue  should be NaN for row vector of fcomplex.NaN's!");
                }
                ILArray<complex> Ac = new complex[] {complex.NaN,complex.NaN,complex.NaN};
                complex maxc = Ac.MinValue; 
                if (!complex.IsNaN(maxc)) {
                    throw new Exception("MinValue should be NaN for row vector of complex.NaN's!");
                }
                A =  new ILArray<double>(new double[]{double.PositiveInfinity,double.PositiveInfinity}); 
                if (ILMath.min(A) != double.PositiveInfinity) 
                    throw new Exception("invalid MinValue returned for: double.PositiveInfinity!"); 
                if (A.MinValue != double.PositiveInfinity) 
                    throw new Exception("invalid MinValue returned for: double.PositiveInfinity!"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_TrailingSingletonDimension() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = ILMath.counter(4,3,2); 
                ILArray<int> idx = new int[]{3,2,1,0}; 
                // single index access
                ILArray<double> Res = A[3,2,1,0]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                Res = A[3,2,1,0,0]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                Res = A[3,2,1,0,0,0,0,0,0]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                errorCode = 2; 
                Res = A["3;2;1;0;0"]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                Res = A["3;2;1;0;0;0"]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                Res = A["3;2;1;0;0;0;0"]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                Res = A["3;2;1;0;0;0;0;0"]; 
                if (!Res.Equals(24.0))
                    throw new Exception("invalid value detected!");
                errorCode = 3; 
                try {
                    Res = A["3;2;1;1"];
                    throw new Exception("invalid index (out of bound) should throw exception"); 
                } catch (ILArgumentException) {
                    Info ("out of bound signaled correctly for dim: 3"); 
                }
                try {
                    Res = A["3;2;1;0;2"];
                    throw new Exception("invalid index (out of bound) should throw exception"); 
                } catch (ILArgumentException) {
                    Info ("out of bound signaled correctly for dim: 4"); 
                }
                errorCode = 4; 
                idx = new int[]{3}; 
                Res = new double[]{16.0,20,24}; 
                if (!Res.Equals(A[idx,null,1,0]))
                    throw new Exception("invalid value detected!");
                if (!Res.Equals(A[idx,null,1,0,0]))
                    throw new Exception("invalid value detected!");
                if (!Res.Equals(A[idx,null,1,0,0,0]))
                    throw new Exception("invalid value detected!");
                if (!Res.Equals(A[idx,null,1,0,0,0,0,0,0,0,0]))
                    throw new Exception("invalid value detected!");
                errorCode = 5; 
                try {
                    Res = A[null,idx,1,2];
                    throw new Exception("invalid index (out of bound) should throw exception"); 
                } catch (ILArgumentException) {
                    Info ("out of bound signaled correctly for dim: 3"); 
                }
                try {
                    Res = A[null,idx,1,0,1];
                    throw new Exception("invalid index (out of bound) should throw exception"); 
                } catch (ILArgumentException) {
                    Info ("out of bound signaled correctly for dim: 4"); 
                }
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_Enumerator() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = ILMath.counter(10,30,20); 
                ILArray<double> Res = ILMath.zeros(10,30,20); 
                int pos = 0; 
                ILPerformer p = new ILPerformer();
                foreach (ILArray<double> a in A) {
                    Res[pos++] = a; 
                }
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                errorCode = 2; 
                Res[":;:;:"] = 0.0; pos = 0; 
                foreach (double a in A) {
                    Res[pos++] = a; 
                }
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                errorCode = 3; 
                Res[":;:;:"] = 0.0; pos = 0; 
                foreach (double a in A.Values) {
                    Res[pos++] = a; 
                }
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                Res[":;:"] = 0.0;  
                int l = A.Dimensions.NumberOfElements; 
                for (int i = 0; i < l; i++) {
                    Res.SetValue(A.GetValue(i),i); 
                }
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        ///// <summary>
        ///// Cosmetic function for website display
        ///// </summary>
        ///// <param name="A">arbitrary input</param>
        ///// <returns>array as result of this test</returns>
        ///// <remarks>This function is for testing 
        ///// only. It's usefull to demonstrate some 
        ///// arrays stuff.</remarks>
        //public ILArray<double> MyTest (ILArray<double> A) {
        //    if (A.IsMatrix && ILMath.ishermitian(A)) {
        //        return A + 0.2 / A * A.T; 
        //    } else if (A.Dimensions[1] > 5) {
        //        ILArray<int> ind = new int[]{3,2,1,5,0,2}; 
        //        return ILMath.randn(1,20,30) * A[0,i,null]; 
        //    }
        //    ILArray<double> ret 
        //        = ILMath.ones(10,20); 
        //    return ret.R;
        //}

        public void Test_EnumeratorIT() {
            int errorCode = 1; 
            try  {
                ILArray<double> A = ILMath.counter(4,3,2); 
                ILArray<double> Res = ILMath.zeros(4,3,2); 
                int pos = 0; 
                ILPerformer p = new ILPerformer();
                foreach (double a in A.Iterator(0)) {
                    Res[pos++] = a; 
                }
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                errorCode = 2; 
                Res[":;:;:"] = 0.0; pos = 0; 
                foreach (double a in A.Iterator(1)) {
                    Res[pos++] = a; 
                }
                Res = Res.Reshape(new ILNumerics.Misc.ILDimension(3,2,4)).S(2); 
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                errorCode = 3; 
                Res[":;:;:"] = 0.0; pos = 0; 
                foreach (double a in A.Iterator(2)) {
                    Res[pos++] = a; 
                }
                Res = Res.Reshape(new ILNumerics.Misc.ILDimension(2,4,3)).S(1); 
                if (!Res.Equals(A))
                    throw new Exception ("Enumerator: invalid values detected!"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_EnumeratorPerf(ILArray<double> A) {
            int errorCode = 1; 
            try  {
                ILPerformer p = new ILPerformer();
                Info("Enumerator test A => " + A.Dimensions); 
                p.Tic();
                foreach (ILArray<double> a in A) { }
                p.Toc();
                Info(" foreach (ILArray<double> a in A){ ... => " + p.ToString() + " ms");
                errorCode = 2; 
                p.Tic(); 
                foreach (double a in A) { }
                p.Toc(); 
                Info(" foreach (double a in A){ }  => " + p.ToString() + " ms");
                errorCode = 3; 
                p.Tic(); 
                foreach (double a in A.Values) { }
                p.Toc();
                Info(" foreach (double a in A.Values){ } [solid] => " + p.ToString() + " ms");
                A = A.R;
                p.Tic(); 
                foreach (double a in A.Values) { }
                p.Toc();
                Info(" foreach (double a in A.Values){ } [Ref] => " + p.ToString() + " ms");
                int l = A.Dimensions.NumberOfElements; 
                double b;
                p.Tic(); 
                for (int i = 0; i < l; i++) { b = A.GetValue(i); }
                p.Toc();
                Info(" for (int i = 0; i < l; i++) { a = A.GetValue(i); } => " + p.ToString() + " ms");
                if (A.IsReference) 
                    A.Detach(); 
                p.Tic(); 
                for (int i = 0; i < l; i++) { b = A.m_data[i]; }
                p.Toc();
                Info(" for (int i = 0; i < l; i++) { a = A.m_data[i]; } => " + p.ToString() + " ms");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_SequentialLogicalAccess () {
            int errorCode = 1; 
            try{
                // test right hand side expression
                ILArray<double> A = ILMath.counter(5,4,3); 
                ILLogicalArray ind = ILMath.counter(4,3) > 3;  
                ILArray<double> res = A[ind]; 
                if (!res.Equals (ILMath.linspace(4.0,12.0,9)))
                    throw new Exception("sequential index access from logical failed: invalid value");
                // test write - left h.s.  expression
                errorCode = 2; 
                ind["9:11"] = false; 
                A[ind] = -1.0;
                res = ILMath.linspace(1.0,60,60).Reshape(A.Dimensions);
                res["3:8"] = -1.0;
                if (!A.Equals (res))
                    throw new Exception("sequential index access from logical failed: invalid value");
                errorCode = 3; 
                // test removal via logicals 
                A[A == -1] = null; 
                res = ILMath.linspace(1.0,3.0,3).Concat(ILMath.linspace(10.0,60.0,51),1); 
                if (!A.Equals (res))
                    throw new Exception("sequential index access from logical failed: invalid value");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }

        public void Test_Test () {
            int errorCode = 1; 
            try{
                ILArray<double> A = new ILArray<double> (200,10000); 
                for (int i = 0; i < 200; i++) {
                    for (int j = 0; j < 10000; j++) {
                        A[i,j] = Double.NaN; 
                    }
                    
                }
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_Expand () {
            int errorCode = 1; 
            try{
                ILArray<double> A = new double[]{1,2,3,4,5,6};
                A = A.T; 
                A["6"] = 7; 
                A[7] = 8; 
                if (A.Dimensions[0] != 8 || A.Dimensions[1] != 1)
                    throw new Exception("invalid dimensions length after resize");
                A[8,1] = 20; 
                if (A.Dimensions[0] != 9 || A.Dimensions[1] != 2)
                    throw new Exception("invalid dimensions length after resize"); 
                /////////////////////
                errorCode = 2; 
                A = ILArray<double>.empty(); 
                A[0] = 4; 
                if (!A.IsScalar)
                    throw new Exception("invalid dimension length after resize");
                if (A[0] != 4)
                    throw new Exception("invalid values detected");
                A[0,1] = 4; 
                if (A.Dimensions[0]!= 1 || A.Dimensions[1] != 2)
                    throw new Exception("invalid dimension length after resize");
                if (A[0] != 4 || A[1] != 4)
                    throw new Exception("invalid values detected");
                ////////////////////
                errorCode = 3; 
                A = ILArray<double>.empty(); 
                ILArray<int> i = new int[]{0}; 
                A[i] = 4; 
                if (!A.IsScalar)
                    throw new Exception("invalid dimension length after resize");
                if (A[0] != 4)
                    throw new Exception("invalid values detected");
                ILArray<int> i2 = new int[]{1}; 
                A[i,i2] = 4; 
                if (A.Dimensions[0]!= 1 || A.Dimensions[1] != 2)
                    throw new Exception("invalid dimension length after resize");
                if (A[0] != 4 || A[1] != 4)
                    throw new Exception("invalid values detected");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_CreatePhysicalSubarrayFromReferenceSequential () {
            int errorCode = 1; 
            try{
                // From 3d array -> 3d Array  
                ILArray<double> A = (ILArray<double>)ILMath.counter(4,3,2).CreateReference();
                ILArray<double> ind = ILMath.counter(23.0,-1,4,3,2); 
                ILArray<double> a = A[ind]; 
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                ILArray<double> Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,3,2);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(23.0,-1,4,6);
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,6);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector 
                ind = ILMath.counter(24,1) * -1 + 24;
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                ind = ILMath.counter(1,24) * -1 + 24;
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // extend into N-d array
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},5,4,3,2,2);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                
                // same thing with indices as reference 
                errorCode = 2; 
                A = (ILArray<double>)ILMath.counter(4,3,2).CreateReference();
                ind = ILMath.counter(4,3,2) * -1 + 24; 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,3,2);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,6);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector - -> not possible for ind beeing reference! <-
                // row vector
                
                // extend dimensions of the destination array 
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},5,4,3,2,2);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[N-d array]"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_CreatePhysicalSubarrayFromPhysicalSequential () {
            int errorCode = 1; 
            try{

                // From 3d array -> 3d Array  
                ILArray<double> A = (ILArray<double>)ILMath.counter(4,3,2);
                ILArray<double> ind = ILMath.counter(23.0,-1,4,3,2); 
                ILArray<double> a = A[ind]; 
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                ILArray<double> Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,3,2);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(23.0,-1,4,6);
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,6);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector 
                ind = ILMath.counter(24,1) * -1 + 24;
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                ind = ILMath.counter(1,24) * -1 + 24;
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // extend into N-d array
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},5,4,3,2,2);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                
                // same thing with indices as reference 
                errorCode = 2; 
                A = (ILArray<double>)ILMath.counter(4,3,2);
                ind = ILMath.counter(4,3,2) * -1 + 24; 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,3,2);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},4,6);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector - -> not possible for ind beeing reference! <-
                // row vector
                
                // extend dimensions of the destination array 
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},5,4,3,2,2);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 

                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_CreatePhysicalSubarrayFromPhysicalSequentialShifted () {
            int errorCode = 1; 
            try{
                // From 3d array -> 3d Array  
                ILArray<double> A = (ILArray<double>)ILMath.counter(4,3,2);
                ILArray<double> ind = ILMath.counter(23.0,-1,4,3,2); 
                ILArray<double> a = A[1,ind]; 
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                ILArray<double> Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},3,2,4);

                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},6,4); 
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector 
                ind = ILMath.counter(24,1) * -1 + 24;
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                ind = ILMath.counter(1,24) * -1 + 24;
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // extend into N-d array
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind];
                Res = new ILArray<double> (new double[] {24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1},4,3,2,2,5);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                
                // same thing with indicex being references 
                errorCode = 2; 
                A = (ILArray<double>)ILMath.counter(4,3,2);
                ind = ILMath.counter(4,3,2) * -1 + 24; 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},3,2,4);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},6,4); 
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector - -> not possible for ind beeing reference! <-
                //ind = ILMath.counter(24,1) * -1 + 24;
                //ind = (ILArray<double>)ind.CreateReference();
                //System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                //System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                //a = A[1,ind]; 
                //Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                //if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                //ind = ILMath.counter(1,24) * -1 + 24;
                //ind = (ILArray<double>)ind.CreateReference();
                //System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                //System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                //a = A[1,ind]; 
                //Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                //if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                
                // extend dimensions of the destination array 
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(!A.IsReference,"Test should implement A as solid!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1},4,3,2,2,5);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 

                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_CreatePhysicalSubarrayFromReferenceSequentialShifted () {
            int errorCode = 1; 
            int oldMinRefDim = ILNumerics.Settings.ILSettings.MinimumRefDimensions; 
            try{
                // From 3d array -> 3d Array  
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 2; 
                ILArray<double> A = (ILArray<double>)ILMath.counter(4,3,2).CreateReference();
                ILArray<double> ind = ILMath.counter(4,3,2) * -1 + 24; 
                ILArray<double> a = A[1,ind]; 
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                ILArray<double> Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},3,2,4);

                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},6,4); 
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector 
                ind = ILMath.counter(24,1) * -1 + 24;
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                ind = ILMath.counter(1,24) * -1 + 24;
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // extend into N-d array
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(!ind.IsReference,"Test should implement ind as solid here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1},4,3,2,2,5);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                
                // same thing with indicex being references 
                errorCode = 2; 
                A = (ILArray<double>)ILMath.counter(4,3,2).CreateReference();
                ind = ILMath.counter(4,3,2) * -1 + 24; 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},3,2,4);
                if (!a.Equals(Res)) throw new Exception("invalid value: A[3d-Array]"); 
                // matrix
                ind = ILMath.counter(4,6) * -1 + 24;
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,20,16,12,8,4,23,19,15,11,7,3,22,18,14,10,6,2,21,17,13,9,5,1},6,4); 
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 
                // column vector - -> not possible for ind beeing reference! <-
                //ind = ILMath.counter(24,1) * -1 + 24;
                //ind = (ILArray<double>)ind.CreateReference();
                //System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                //System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                //a = A[1,ind]; 
                //Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},1,24);
                //if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                // row vector
                //ind = ILMath.counter(1,24) * -1 + 24;
                //ind = (ILArray<double>)ind.CreateReference();
                //System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                //System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                //a = A[1,ind]; 
                //Res = new ILArray<double> (new double[] {24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1},24,1);
                //if (!a.Equals(Res)) throw new Exception ("invalid value: A[Vector]"); 
                
                // extend dimensions of the destination array 
                ind = ILMath.counter(1,24) * -1 + 24;
                ind = ILMath.repmat(ind,1,10);
                ind = ILMath.reshape(ind,5,4,3,2,2); 
                ind = (ILArray<double>)ind.CreateReference();
                System.Diagnostics.Debug.Assert(A.IsReference,"Test should implement A as reference!"); 
                System.Diagnostics.Debug.Assert(ind.IsReference,"Test should implement ind as reference here!"); 
                a = A[1,ind]; 
                Res = new ILArray<double> (new double[] {24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1,20,15,10,5,24,19,14,9,4,23,18,13,8,3,22,17,12,7,2,21,16,11,6,1},4,3,2,2,5);
                if (!a.Equals(Res)) throw new Exception ("invalid value: A[Matrix]"); 

                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            } finally {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldMinRefDim; 
            }
        }
        public void Test_SetRange_RangedPhysical() {
            int errorCode = 0; 
            try {
                ILArray<double> AOrig = ILMath.vector(1,24).Reshape(new ILDimension(4,3,2));  
                ILArray<double> ResOrig = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2);
                ILArray<double> A, Res, indb; 
                // test setrange for single element (sequential access) 
                for (int i = 0; i < 20; i++) {
                    A = (ILArray<double>)AOrig.Clone();  
                    Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                    A[i.ToString()] = 99;
                    Res.m_data[i] = 99;
                    if (!A.Equals(Res)) throw new Exception("A[\"" + i.ToString() + "\"] = 99 failed.");
                    // test setrange via basearray
                    A = (ILArray<double>)AOrig.Clone();  
                    A[new int[]{i}] = 99;
                    if (!A.Equals(Res)) throw new Exception("A[" + i.ToString() + "] = 99 failed.");
                }
                // test setrange for 2 single elements (sequential access) 
                errorCode = 1; 
                for (int i = 0; i < 20; i++) {
                    A = (ILArray<double>)AOrig.Clone();  
                    Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                    indb = new double[]{i,i+3}; 
                    string inds = i.ToString() + "," + (i+3).ToString(); 
                    Res.m_data[i] = 99;
                    Res.m_data[i+3] = 99; 
                    A[inds] = 99;
                    if (!A.Equals(Res)) throw new Exception("A[\"" + i.ToString() + "," + (i+3).ToString() + "\"] = 99 failed.");
                    // test setrange via basearray
                    A = (ILArray<double>)AOrig.Clone();  
                    A[indb] = 99;
                    if (!A.Equals(Res)) throw new Exception("A[" + i.ToString() + "," + (i+3).ToString() + "] = 99 failed.");
                }
                errorCode = 2; 
                A = (ILArray<double>)AOrig.Clone();
                // reshaping range in second dimension 
                A["1;1:end"] = new double []{100,101,102,103,104};
                Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                Res.m_data[5] = 100; 
                Res.m_data[9] = 101; 
                Res.m_data[13] = 102; 
                Res.m_data[17] = 103; 
                Res.m_data[21] = 104;
                if (!A.Equals(Res)) throw new Exception("A[1,1:end] = [100...104] failed.");
                // reshaping range in 2nd dimension - basearray indices
                indb = new double[]{1,2,3,4,5}; 
                A[1.0,indb] = new double[]{100,101,102,103,104};
                Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                Res.m_data[5] = 100; 
                Res.m_data[9] = 101; 
                Res.m_data[13] = 102; 
                Res.m_data[17] = 103; 
                Res.m_data[21] = 104;
                if (!A.Equals(Res)) throw new Exception("A[1,[1,2,3,4,5]] = [100...104] failed.");
                // reshaping range in 2nd dimension - for reference storages 
                errorCode = 2; 
                A = ((ILArray<double>)AOrig.Clone()); 
                ILArray<double>.DetachReferences = ILDetachingBehavior.DetachSave;
                ILArray<double> ARef = (ILArray<double>)A.CreateReference();
                A.Dispose(); 
                // reshaping range in second dimension 
                ARef["1;1:end"] = new double[]{100,101,102,103,104};
                Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                Res.m_data[5] = 100; 
                Res.m_data[9] = 101; 
                Res.m_data[13] = 102; 
                Res.m_data[17] = 103; 
                Res.m_data[21] = 104;
                if (!ARef.Equals(Res) || !ARef.IsReference) throw new Exception("A[1,1:end] = [100...104] failed.");
                // reshaping range in 2nd dimension - basearray indices
                indb = new double[]{1,2,3,4,5}; 
                ARef[1.0,indb] = new double[]{100,101,102,103,104};
                Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                Res.m_data[5] = 100; 
                Res.m_data[9] = 101; 
                Res.m_data[13] = 102; 
                Res.m_data[17] = 103; 
                Res.m_data[21] = 104;
                if (!ARef.Equals(Res)) throw new Exception("A[1,[1,2,3,4,5]] = [100...104] failed.");
                // 
                errorCode = 3; 
                // test single element (sequential) via range for reference array
                for (int i = 0; i < 20; i++) {
                    A = (ILArray<double>)AOrig.Clone(); 
                    ARef = (ILArray<double>)A.CreateReference(); 
                    A.Dispose(); 
                    Res = ((ILArray<double>)ResOrig.Clone()).Detach(); 
                    ARef[i.ToString()] = 99;
                    Res.m_data[i] = 99;
                    if (!ARef.Equals(Res) || !ARef.IsReference) throw new Exception("A[\"" + i.ToString() + "\"] = 99 failed.");
                    // test setrange via basearray
                    A = (ILArray<double>)AOrig.Clone(); 
                    ARef = (ILArray<double>)A.CreateReference(); 
                    A.Dispose(); 
                    ARef[i] = 99;
                    if (!ARef.Equals(Res) || !ARef.IsReference) throw new Exception("A[" + i.ToString() + "] = 99 failed.");
                }
                errorCode = 4; 
                
                // test scalar source - full dimension
                A = (ILArray<double>)AOrig.Clone();
                A.Detach(); 
                A[":"] = 111; 
                Res = ILMath.ones(4,3,2) * 111; 
                if (!A.Equals(Res)) throw new Exception("A[:] = {scalar} for physical array failed!");
                // ... explicit indices 
                Res = ILMath.ones(4,3,2) * 112; 
                A["0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23"] = 112; 
                if (!A.Equals(Res)) throw new Exception("A[0..23] = {scalar} for physical array failed!");
                // .. for reference storages 
                errorCode = 5; 
                A = (ILArray<double>)AOrig.Clone();
                ARef = (ILArray<double>) A.CreateReference(); 
                A.Dispose(); 
                ARef[":"] = 111; 
                Res = ILMath.ones(4,3,2) * 111; 
                if (!ARef.Equals(Res)) throw new Exception();
                Res = ILMath.ones(4,3,2) * 112; 
                ARef["0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23"] = 112; 
                if (!ARef.Equals(Res)) throw new Exception("A[0..23] = {scalar} for physical array failed!");
                
                // test scalar on all dimensions 
                errorCode = 6; 
                A = (ILArray<double>)AOrig.Clone();
                A.Detach(); 
                A[": ; : ; :"] = 113; 
                Res = ILMath.ones(4,3,2) * 113; 
                if (!A.Equals(Res)) throw new Exception("A[:;:;:] = {scalar} for physical array failed!");
                // ... reference 
                ARef = (ILArray<double>)A.CreateReference(); 
                A.Dispose(); 
                ARef[":;:;:"] = 114; 
                Res = ILMath.ones(4,3,2) * 114; 
                if (!ARef.Equals(Res)) throw new Exception("A[:;:;:] = {scalar} for reference array failed!");
                errorCode = 7; 
                
                // test scalar on all dimensions for explicit indices 
                A = (ILArray<double>)AOrig.Clone();
                A.Detach(); 
                A["0:end;0:end;1"] = 114; 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,114,114,114,114,114,114,114,114,114,114,114,114},4,3,2);  
                if (!A.Equals(Res)) throw new Exception("A[0:end;0:end;1] = {scalar} for physical array failed!");
                // ... reference 
                ARef = (ILArray<double>)A.CreateReference(); 
                A.Dispose(); 
                ARef["0:end;0:end;1"] = 115; 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,115,115,115,115,115,115,115,115,115,115,115,115},4,3,2);  
                if (!ARef.Equals(Res)) throw new Exception("A[0:end;0:end;1] = {scalar} for reference array failed!");
                // test extending range
                errorCode = 8; 
                A = ILArray<double>.empty(); 
                A[0] = 1;
                if (A.IsReference || !A.IsScalar || A.GetValue(0) != 1.0) throw new Exception("A[0] = 1 on empty array should extend array!");
                // same test for string definitions
                A = ILArray<double>.empty(); 
                ARef = (ILArray<double>) A.CreateReference(); 
                A["0"] = 1;
                ARef["0"] = 1; 
                if (A.IsReference || !A.IsScalar || A.GetValue(0) != 1.0) throw new Exception("A[0] = 1 on empty array should extend array!");
                if (A.IsReference || !ARef.IsScalar || ARef.GetValue(0) != 1.0) throw new Exception("ARef[0] = 1 on empty array should extend array!");
                Success();
            } catch (Exception e) {
                Error(errorCode, e.Message ); 
            }
        }
        public void Test_singleElementWriteAccessPhysical() {
            int errorCode = 0; 
            try {
                // physical array, non expanding access 
                ILArray<double> AOrig = ILMath.vector(1,24); 
                AOrig.MinimumRefDimensions = 4;   // ensure all arrays are physical arrays
                AOrig = ILMath.reshape(AOrig,4,3,2); 
                ILArray<double> Res; 
                ILArray<double> A;
                int i = 0; 
                // single dimension access (sequential index only)
                for (i = 0; i < 24; i++) {
                    A = (ILArray<double>)AOrig.Clone(); 
                    Res = (ILArray<double>)AOrig.Clone();
                    Res.m_data[i] = 99; 
                    A[i] = 99; 
                    if (!A.Equals(Res)) throw new Exception("A[?] = 99; failed at i=" + i.ToString());
                }
                // 2 dimension access (with/without sequential index access)
                errorCode = 1; 
                i = 0; 
                int [] indices = new int[2]; 
                for (int d1 = 0; d1 < AOrig.Dimensions[1] * AOrig.Dimensions[2]; d1++) {
                    for (int d0 = 0; d0 < AOrig.Dimensions[0]; d0++) {
                        indices[0] = d0; 
                        indices[1] = d1; 
                        A = (ILArray<double>)AOrig.Clone(); 
                        Res = (ILArray<double>)AOrig.Clone();
                        Res.m_data[i++] = 99; 
                        A[indices] = 99; 
                        if (!A.Equals(Res)) throw new Exception("A[m,n] = 99; failed at i=" + i.ToString());
                    }
                }
                // 3 dimension access (with/without sequential index access)
                errorCode = 2; 
                i = 0; 
                indices = new int[3]; 
                for (int d2 = 0; d2 < AOrig.Dimensions[2]; d2++) {
                    for (int d1 = 0; d1 < AOrig.Dimensions[1]; d1++) {
                        for (int d0 = 0; d0 < AOrig.Dimensions[0]; d0++) {
                            indices[0] = d0; 
                            indices[1] = d1; 
                            indices[2] = d2; 
                            A = (ILArray<double>)AOrig.Clone(); 
                            Res = (ILArray<double>)AOrig.Clone();
                            Res.m_data[i++] = 99; 
                            A[indices] = 99; 
                            if (!A.Equals(Res)) throw new Exception("A[m,n] = 99; failed at i=" + i.ToString());
                        }
                    }
                }
                // xpanding access ******************************************************************************
                // single dimension access (sequential index only)
                errorCode = 4; 
                AOrig = ILMath.vector(1,24);   
                AOrig.MinimumRefDimensions = 4; 
                A = (ILArray<double>) AOrig.Clone(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25},25,1);
                A[24] = 25; 
                if (A.IsReference || !A.IsColumnVector || A.Dimensions[0] != 25) throw new Exception("expanding col vector failed");
                if (!A.Equals(Res)) throw new Exception("expanding col vector failed: invalid value.");
                
                // expand vector to matrix
                errorCode = 5; 
                A = (ILArray<double>) AOrig.Clone(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},24,2);
                A[0,1] = 25; 
                if (A.IsReference || !A.IsMatrix || A.Dimensions[0] != 24 || A.Dimensions[1] != 2) throw new Exception("expanding col vector failed");
                if (!A.Equals(Res)) throw new Exception("expanding col vector failed: invalid value.");
                
                // expand vector to matrix - both directions
                errorCode = 6; 
                A = (ILArray<double>) AOrig.Clone(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,52},26,2);
                A[25,1] = 52; 
                if (A.IsReference || !A.IsMatrix || A.Dimensions[0] != 26 || A.Dimensions[1] != 2) throw new Exception("expanding col vector failed");
                if (!A.Equals(Res)) throw new Exception("expanding col vector failed: invalid value.");

                // expand vector to 3d array
                errorCode = 7; 
                A = (ILArray<double>) AOrig.Clone(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},24,1,2);
                A[0,0,1] = 25; 
                if (A.IsReference || A.Dimensions[0] != 24 || A.Dimensions[1] != 1 || A.Dimensions[2] != 2) throw new Exception("expanding col vector failed");
                if (!A.Equals(Res)) throw new Exception("expanding col vector failed: invalid value.");

                // expand scalar to vector 
                errorCode = 8; 
                A = 1.0; 
                Res = new ILArray<double>(new double[]{1.0,2.0},2,1);
                A[1] = 2.0; 
                if (!A.Equals(Res)) throw new Exception("expand scalar failed : A[1] = 2.0");
                A = 1.0; 
                A[0,1] = 2.0; 
                if (!A.Equals(Res.T)) throw new Exception("expand scalar failed : A[0,1] = 2.0");

                // expand scalar to matrix 
                errorCode = 9; 
                A = 1.0; 
                A[1,1] = 4.0; 
                Res = new ILArray<double>(new double[]{1,0,0,4},2,2); 
                if (!A.Equals(Res)) throw new Exception("expand scalar to matrix failed");
                A = 1.0; 
                A[4,2,3] = 10; 
                Res = ILMath.zeros(5,3,4);
                Res.m_data[59] = 10; 
                Res.m_data[0] = 1.0; 
                if (!A.Equals(Res)) throw new Exception("expand scalar to matrix 2 failed");

                // expand from empty array 
                A = ILArray<double>.empty(); 
                A[3] = 5.0; 
                Res = ILMath.zeros(4,1); 
                Res.m_data[3] = 5.0; 
                if (!A.Equals(Res)) throw new Exception("expand from empty array failed.");
                
                // expand empty -> scalar
                A = ILArray<double>.empty(); 
                A[3] = 5.0; 
                Res = ILMath.zeros(4,1);
                Res.m_data[3] = 5.0; 
                if (!A.Equals(Res)) throw new Exception("expand from empty array failed (2).");

                // expand empty -> 2d
                A = ILArray<double>.empty(); 
                A[1,1] = 5.0; 
                Res = ILMath.zeros(4,1);
                Res = ILMath.reshape(Res,2,2); 
                Res.m_data[3] = 5.0; 
                if (!A.Equals(Res)) throw new Exception("expand from empty array failed (2).");

                // expand empty -> 3D
                A = ILArray<double>.empty(); 
                A[1,1,1] = 5.0; 
                Res = ILMath.zeros(8,1);
                Res = ILMath.reshape(Res,2,2,2); 
                Res.m_data[7] = 5.0; 
                if (!A.Equals(Res)) throw new Exception("expand from empty array failed (2).");

                errorCode = 10; 
                // expand matrix -> matrix 1st dimension
                A = ILMath.vector(1,24); 
                A = ILMath.reshape(A,6,4); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,66,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0},7,4); 
                A[6,0] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, 1st dimensions failed");

                // expand matrix -> matrix, 2nd dimensions 
                A = ILMath.vector(1,24); 
                A = ILMath.reshape(A,6,4); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,0,0,0,0,0,66},6,5); 
                A[5,4] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, 2nd dimensions failed");
                
                // expand matrix -> matrix, both dimensions
                A = ILMath.vector(1,24); 
                A = ILMath.reshape(A,6,4); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,0,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0,0,0,0,0,0,0,66},7,5); 
                A[6,4] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, both dimensions failed");
                
                // expand matrix -> 3d
                A = ILMath.vector(1,24); 
                A = ILMath.reshape(A,6,4); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,0,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,66},7,5,2); 
                A[6,4,1] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> 3d failed");
                Success();
            } catch (Exception e) {
                Error(errorCode, e.Message ); 
            }
        }
        public void Test_singleElementWriteAccessReference() {
            int errorCode = 0; 
            try {
                // physical array, non expanding access 
                ILArray<double> AOrig = ILMath.vector(1,24); 
                AOrig.MinimumRefDimensions = 2;   // ensure matrices are built as reference arrays
                AOrig = ILMath.reshape(AOrig,4,3,2); 
                ILArray<double> Res; 
                ILArray<double> A;
                int i = 0; 
                // single dimension access (sequential index only)
                for (i = 0; i < 24; i++) {
                    A = (ILArray<double>)AOrig.CreateReference(); 
                    Res = (ILArray<double>)AOrig.Clone();
                    Res.m_data[i] = 99; 
                    A[i] = 99; 
                    if (!A.Equals(Res)) throw new Exception("A[?] = 99; failed at i=" + i.ToString());
                }
                // 2 dimension access (with/without sequential index access)
                errorCode = 1; 
                i = 0; 
                int [] indices = new int[2]; 
                for (int d1 = 0; d1 < AOrig.Dimensions[1] * AOrig.Dimensions[2]; d1++) {
                    for (int d0 = 0; d0 < AOrig.Dimensions[0]; d0++) {
                        indices[0] = d0; 
                        indices[1] = d1; 
                        A = (ILArray<double>)AOrig.CreateReference(); 
                        Res = (ILArray<double>)AOrig.Clone();
                        Res.m_data[i++] = 99; 
                        A[indices] = 99; 
                        if (!A.Equals(Res)) throw new Exception("A[m,n] = 99; failed at i=" + i.ToString());
                    }
                }
                // 3 dimension access (with/without sequential index access)
                errorCode = 2; 
                i = 0; 
                indices = new int[3]; 
                for (int d2 = 0; d2 < AOrig.Dimensions[2]; d2++) {
                    for (int d1 = 0; d1 < AOrig.Dimensions[1]; d1++) {
                        for (int d0 = 0; d0 < AOrig.Dimensions[0]; d0++) {
                            indices[0] = d0; 
                            indices[1] = d1; 
                            indices[2] = d2; 
                            A = (ILArray<double>)AOrig.CreateReference(); 
                            Res = (ILArray<double>)AOrig.Clone();
                            Res.m_data[i++] = 99; 
                            A[indices] = 99; 
                            if (!A.Equals(Res)) throw new Exception("A[m,n] = 99; failed at i=" + i.ToString());
                        }
                    }
                }
                // xpanding access ******************************************************************************
                // single dimension access (sequential index only)

                errorCode = 10; 
                // expand matrix -> matrix 1st dimension
                A = ILMath.vector(1,24); 
                A = (ILArray<double>)ILMath.reshape(A,6,4).CreateReference(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,66,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0},7,4); 
                A[6,0] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, 1st dimensions failed");

                // expand matrix -> matrix, 2nd dimensions 
                A = ILMath.vector(1,24); 
                A = (ILArray<double>)ILMath.reshape(A,6,4).CreateReference(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,0,0,0,0,0,66},6,5); 
                A[5,4] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, 2nd dimensions failed");
                
                // expand matrix -> matrix, both dimensions
                A = ILMath.vector(1,24); 
                A = (ILArray<double>)ILMath.reshape(A,6,4).CreateReference(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,0,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0,0,0,0,0,0,0,66},7,5); 
                A[6,4] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> matrix, both dimensions failed");
                
                // expand matrix -> 3d
                A = ILMath.vector(1,24); 
                A = (ILArray<double>)ILMath.reshape(A,6,4).CreateReference(); 
                Res = new ILArray<double>(new double[]{1,2,3,4,5,6,0,7,8,9,10,11,12,0,13,14,15,16,17,18,0,19,20,21,22,23,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,66},7,5,2); 
                A[6,4,1] = 66; 
                if (!A.Equals(Res)) throw new Exception("expand matrix -> 3d failed");
                Success();
            } catch (Exception e) {
                Error(errorCode, e.Message ); 
            }
        }
        public void Test_singleElementAccess() {
            int errorCode = 0; 
            try {
                ILArray<int> A = new ILArray<int>(new int[]{1,2,3,4,5,6,7,8,9,10,11,12},3,4); 
                if (!A[0].Equals(1)) throw new Exception("A[0] failed");
                if (!A[1].Equals(2)) throw new Exception("A[1] failed");
                if (!A[2].Equals(3)) throw new Exception("A[2] failed");
                if (!A[3].Equals(4)) throw new Exception("A[3] failed");
                if (!A[4].Equals(5)) throw new Exception("A[4] failed");
                if (!A[5].Equals(6)) throw new Exception("A[5] failed");
                if (!A[6].Equals(7)) throw new Exception("A[6] failed");
                if (!A[7].Equals(8)) throw new Exception("A[7] failed");
                if (!A[8].Equals(9)) throw new Exception("A[8] failed");
                if (!A[9].Equals(10)) throw new Exception("A[9] failed");
                if (!A[10].Equals(11)) throw new Exception("A[10] failed");
                if (!A[11].Equals(12)) throw new Exception("A[11] failed");
                errorCode = 1; 
                try {
                    ILArray<int> B = A[12]; 
                } catch (Exception) {
                    Info ("Out of range signaled ok");
                } 
                errorCode = 2; 
                if (!A[0,0].Equals(1)) throw new Exception("A[0,0] failed");
                if (!A[0,1].Equals(4)) throw new Exception("A[0,1] failed");
                if (!A[0,2].Equals(7)) throw new Exception("A[0,2] failed");
                if (!A[0,3].Equals(10)) throw new Exception("A[0,3] failed");
                if (!A[1,0].Equals(2)) throw new Exception("A[1,0] failed");
                if (!A[1,1].Equals(5)) throw new Exception("A[1,1] failed");
                if (!A[1,2].Equals(8)) throw new Exception("A[1,2] failed");
                if (!A[1,3].Equals(11)) throw new Exception("A[1,3] failed");
                if (!A[2,0].Equals(3)) throw new Exception("A[2,0] failed");
                if (!A[2,1].Equals(6)) throw new Exception("A[2,1] failed");
                if (!A[2,2].Equals(9)) throw new Exception("A[2,2] failed");
                if (!A[2,3].Equals(12)) throw new Exception("A[2,3] failed");
                errorCode = 3; 
                try { 
                    ILArray<int> B = A[3,3]; 
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                try { ILArray<int> B = A[2,4]; 
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                try { ILArray<int> B = A[4,3];  
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                // test reshaping index in last dimension
                errorCode = 4; 
                A = ILMath.toint32(ILMath.vector(1,24));
                A = ILMath.reshape(A,4,3,2); 
                if (!A[1,5].Equals(22)) throw new Exception("A[1,5] failed");
                if (!A[3,5].Equals(24)) throw new Exception("A[1,5] failed");
                errorCode = 5;
                ///////////////  REFERENCE ARRAY /////////////////////////////

                A = new ILArray<int>(new int[]{1,2,3,4,5,6,7,8,9,10,11,12},3,4);
                A.MinimumRefDimensions = 2; 
                A = (ILArray<int>)A.CreateReference(); 
                if (!A[0].Equals(1)) throw new Exception("A[0] failed");
                if (!A[1].Equals(2)) throw new Exception("A[1] failed");
                if (!A[2].Equals(3)) throw new Exception("A[2] failed");
                if (!A[3].Equals(4)) throw new Exception("A[3] failed");
                if (!A[4].Equals(5)) throw new Exception("A[4] failed");
                if (!A[5].Equals(6)) throw new Exception("A[5] failed");
                if (!A[6].Equals(7)) throw new Exception("A[6] failed");
                if (!A[7].Equals(8)) throw new Exception("A[7] failed");
                if (!A[8].Equals(9)) throw new Exception("A[8] failed");
                if (!A[9].Equals(10)) throw new Exception("A[9] failed");
                if (!A[10].Equals(11)) throw new Exception("A[10] failed");
                if (!A[11].Equals(12)) throw new Exception("A[11] failed");
                errorCode = 1; 
                try {
                    ILArray<int> B = A[12]; 
                } catch (Exception) {
                    Info ("Out of range signaled ok");
                } 
                errorCode = 2; 
                if (!A[0,0].Equals(1)) throw new Exception("A[0,0] failed");
                if (!A[0,1].Equals(4)) throw new Exception("A[0,1] failed");
                if (!A[0,2].Equals(7)) throw new Exception("A[0,2] failed");
                if (!A[0,3].Equals(10)) throw new Exception("A[0,3] failed");
                if (!A[1,0].Equals(2)) throw new Exception("A[1,0] failed");
                if (!A[1,1].Equals(5)) throw new Exception("A[1,1] failed");
                if (!A[1,2].Equals(8)) throw new Exception("A[1,2] failed");
                if (!A[1,3].Equals(11)) throw new Exception("A[1,3] failed");
                if (!A[2,0].Equals(3)) throw new Exception("A[2,0] failed");
                if (!A[2,1].Equals(6)) throw new Exception("A[2,1] failed");
                if (!A[2,2].Equals(9)) throw new Exception("A[2,2] failed");
                if (!A[2,3].Equals(12)) throw new Exception("A[2,3] failed");
                errorCode = 3; 
                try { 
                    ILArray<int> B = A[3,3]; 
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                try { ILArray<int> B = A[2,4]; 
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                try { ILArray<int> B = A[4,3];  
                    throw new Exception("out of range should throw exception");
                } catch (Exception e) {
                    if (e.Message == "out of range should throw exception")
                        throw e; 
                }
                // test reshaping index in last dimension
                errorCode = 4; 
                A = ILMath.toint32(ILMath.vector(1,24));
                A = ILMath.reshape(A,4,3,2); 
                if (!A[1,5].Equals(22)) throw new Exception("A[1,5] failed");
                if (!A[3,5].Equals(24)) throw new Exception("A[3,5] failed");
                Success();
            } catch (Exception e) {
                Error(errorCode, e.Message ); 
            }
        }
        public void Test_CreateReferenceSubarrayFromReference_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                A.MinimumRefDimensions = 2; 
                ILArray<float> Res = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                Res = ILMath.reshape(Res,4,6); 
                ILArray<float> B = A[0,":;:"]; 
                if (!B.Equals(Res)) throw new Exception("A[0,\":;:\" failed.");
                errorCode = 9; 
                B = A[0,":;:;:"]; 
                Res = ILMath.reshape(Res,4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A[0,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[0,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,14,15,16,17,18,19,20,21,22,23,24},4,3); 
                if (!B.Equals(Res)) throw new Exception("A[0,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[0,"2,1;:;0"]; 
                Res = new ILArray<float> (new float[]{3,2,7,6,11,10},2,3); 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 3) throw new Exception("A[0,\"2,1;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != -1 || B.m_indexOffset.RegularySpacing(1) != 4) 
                    throw new Exception("A[0,\"2;:;0\"] failed.");
                errorCode = 12; 
                B = A[0,"2,1;1,:;1"]; 
                Res = new ILArray<float> (new float[]{19,18,15,14,19,18,23,22},2,4); 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 4) throw new Exception("A[0,\":;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != -1 || B.m_indexOffset.RegularySpacing(1) != int.MinValue) 
                    throw new Exception("A[0,\"2;1,:;1\"] failed.");
                errorCode = 13; 
                A = ILMath.tosingle(ILMath.vector(1,72)); 
                A = A.Reshape(new ILDimension(3,4,2,3)); 
                A.MinimumRefDimensions = 2; 
                B = A[0,"1;:;1;:"]; 
                Res = new ILArray<float> (new float[]{14,17,20,23,38,41,44,47,62,65,68,71},1,4,1,3); 
                if (!B.Equals(Res)) throw new Exception("0,\"1;:;1;:\"] failed.");
                errorCode = 14; 
                B = A[0,"2;:;:;2"]; 
                Res = new ILArray<float> (new float[]{51,54,57,60,63,66,69,72},1,4,2); 
                if (!B.Equals(Res)) throw new Exception("0,\"2;:;:;2\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 1 
                    || B.m_indexOffset.RegularySpacing(1) != 3 || B.m_indexOffset.RegularySpacing(2) != 12 ) 
                            throw new Exception ("A[0,\"2;:;:;2\"] failed (invalid meta data)"); 
                // test result if matrix 
                B = A[0,"2,1;3,2,1;2"]; 
                Res = new ILArray<float> (new float[]{36,35,33,32,30,29},2,3); 
                if (!B.Equals(Res)) throw new Exception("A[0,\"2,1,0;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -1 || B.m_indexOffset.RegularySpacing(1) != -3) 
                            throw new Exception ("A[4,\"0;1,0;0\"] failed (invalid regSpacing)"); 
                errorCode = 15; 
                A = ILMath.tosingle(ILMath.vector(1.0,1.0,24));
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                B = A[0,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,10,7,6,3,2},2,3); 
                if (!B.Equals(Res)) throw new Exception("A[0,\"2,1,0;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -1 || B.m_indexOffset.RegularySpacing(1) != -4) 
                            throw new Exception ("A[0,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                errorCode = 16; 
                B = A[0,"0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[0,\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 1 || B.m_indexOffset.RegularySpacing(1) != 4) 
                            throw new Exception ("A[0,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreatePhysicalSubarrayFromPhysicalShifted_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A.Detach(); 
                A.MinimumRefDimensions = 6; 
                ILArray<float> B = A[1,":"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                errorCode = 2; 
                B = A[2,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":\"] failed.");
                errorCode = 3; 
                B = A[3,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[3,\":\"] failed.");
                errorCode = 4; 
                // shift outside dims 
                errorCode = 5; 
                B = A[4,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[4,\":\"] failed.");
                errorCode = 6; 
                // shift negative
                B = A[-3,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[-1,\":\"] failed.");
                errorCode = 7; 
                // shift inside dims 
                B = A[1,":,:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},48,1);
                if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                errorCode = 8; 
                B = A[1,":;:"]; 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:\" failed.");
                errorCode = 9; 
                B = A[2,":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[1,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,17,21,14,18,22,15,19,23,16,20,24},3,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[1,"1,2;:;0"]; 
                Res = new ILArray<float> (new float[]{2,6,10,3,7,11},3,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 3 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 12; 
                B = A[1,"1,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{18,14,18,22,19,15,19,23},4,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 4 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                //errorCode = 13; 
                //B = A[4,"2;1;0"]; 
                //Res = new ILArray<float> (7); 
                //if (!B.Equals(Res)) throw new Exception("A[4,\"2;1;0\"] failed.");
                errorCode = 14; 
                B = A[4,"2,1;1,0;0"]; 
                Res = new ILArray<float> (new float[]{7,3,6,2},2,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1;1,0;0\"] failed.");
                // test result if matrix 
                errorCode = 15; 
                B = A[1,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,7,3,10,6,2},3,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1,0;1,0;0\"] failed.");
                errorCode = 16; 
                B = A[1,"0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4);
                if (!B.Equals(Res)) throw new Exception("A[0,\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreatePhysicalSubarrayFromPhysical_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A.Detach(); 
                A.MinimumRefDimensions = 6; 
                ILArray<float> B = A[0,":"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},24,1); 
                if (!B.Equals(Res)) throw new Exception("A[0,\":\"] failed.");
                errorCode = 2; 
                // shift negative
                B = A[-3,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},24,1); 
                if (!B.Equals(Res)) throw new Exception("A[-1,\":\"] failed.");
                errorCode = 7; 
                // shift inside dims 
                B = A[0,":,:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,48);
                if (!B.Equals(Res)) throw new Exception("A[0,\":,:\"] failed.");
                errorCode = 8; 
                B = A[0,":;:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[0,\":;:\" failed.");
                errorCode = 9; 
                B = A[0,":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[0,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,14,15,16,17,18,19,20,21,22,23,24},4,3); 
                if (!B.Equals(Res)) throw new Exception("A[0,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[0,"1,2;:;0"]; 
                Res = new ILArray<float> (new float[]{2,3,6,7,10,11},2,3); 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 3) throw new Exception("A[0,\":;:;1\"] failed.");
                errorCode = 12; 
                B = A[0,"1,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{18,19,14,15,18,19,22,23},2,4); 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 4) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 13; 
                B = A[0,"2;1;0"]; 
                Res = 7; 
                if (!B.Equals(Res)) throw new Exception("A[0,\"2;1;0\"] failed.");
                errorCode = 14; 
                B = A[0,"2,1;1,0;0"]; 
                Res = new ILArray<float> (new float[]{7,6,3,2},2,2); 
                if (!B.Equals(Res)) throw new Exception("A[0,\"2,1;1,0;0\"] failed.");
                // test result if matrix 
                errorCode = 15; 
                B = A[0,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,10,7,6,3,2},2,3); 
                if (!B.Equals(Res)) throw new Exception("A[0,\"2,1,0;1,0;0\"] failed.");
                errorCode = 16; 
                B = A[0,"0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6);
                if (!B.Equals(Res)) throw new Exception("A[0,\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreateReferenceSubarrayFromReferenceShifted_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A.MinimumRefDimensions = 2; 
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                ILArray<float> B = A[1,":;:"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:\" failed.");
                errorCode = 9; 
                B = A[2,":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[1,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,17,21,14,18,22,15,19,23,16,20,24},3,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[1,"2,1;:;0"]; 
                Res = new ILArray<float> (new float[]{3,7,11,2,6,10},3,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 3 || B.Dimensions[1] != 2) throw new Exception("A[1,\"2,1;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != 4 || B.m_indexOffset.RegularySpacing(1) != -1) 
                    throw new Exception("A[1,\"2;:;0\"] failed.");
                errorCode = 12; 
                B = A[1,"2,1;1,:;1"]; 
                Res = new ILArray<float> (new float[]{19,15,19,23,18,14,18,22},4,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 4 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != int.MinValue || B.m_indexOffset.RegularySpacing(1) != -1) 
                    throw new Exception("A[1,\"2;1,:;1\"] failed.");
                errorCode = 13; 
                A = ILMath.tosingle(ILMath.vector(1,72)); 
                A = A.Reshape(new ILDimension(3,4,2,3)); 
                A.MinimumRefDimensions = 2; 
                B = A[1,"1;:;1;:"]; 
                Res = new ILArray<float> (new float[]{14,17,20,23,38,41,44,47,62,65,68,71},4,1,3); 
                if (!B.Equals(Res)) throw new Exception("1,\"1;:;1;:\"] failed.");
                errorCode = 14; 
                B = A[1,"2;:;:;2"]; 
                Res = new ILArray<float> (new float[]{51,54,57,60,63,66,69,72},4,2); 
                if (!B.Equals(Res)) throw new Exception("1,\"2;:;:;2\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 3 || B.m_indexOffset.RegularySpacing(1) != 12) 
                            throw new Exception ("A[4,\"2;:;:;2\"] failed (invalid meta data)"); 
                // test result if matrix 
                B = A[1,"2,1;3,2,1;2"]; 
                Res = new ILArray<float> (new float[]{36,33,30,35,32,29},3,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1,0;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -3 || B.m_indexOffset.RegularySpacing(1) != -1) 
                            throw new Exception ("A[4,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                errorCode = 15; 
                A = ILMath.tosingle(ILMath.vector(1.0,1.0,24));
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                B = A[1,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,7,3,10,6,2},3,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1,0;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -4 || B.m_indexOffset.RegularySpacing(1) != -1) 
                            throw new Exception ("A[4,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                errorCode = 16;
                B = A[1,"0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4);
                if (!B.Equals(Res)) throw new Exception("A[0,\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 4 || B.m_indexOffset.RegularySpacing(1) != 1) 
                            throw new Exception ("A[0,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreatePhysicalSubarrayFromReference_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                A.MinimumRefDimensions = 6; 
                ILArray<float> B = A[":"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},24,1); 
                if (!B.Equals(Res)) throw new Exception("A[:] failed.");
                // shift inside dims 
                B = A[0,":"]; 
                if (!B.Equals(Res)) throw new Exception("A[0,\":\"] failed.");
                B = A[-1,"1:end"]; 
                Res = new ILArray<float> (new float[]{2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},23,1); 
                if (!B.Equals(Res)) throw new Exception("A[-1,\"0:end\"] failed.");
                //B = A[-3,":"]; 
                //if (!B.Equals(Res)) throw new Exception("A[-3,\":\"] failed.");
                //errorCode = 1; 
                // shift inside dims 
                B = A[":;:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[\":;:\" failed.");
                B = A["0:end;0:end"]; 
                if (!B.Equals(Res)) throw new Exception("A[\"0:end;0:end\" failed.");
                errorCode = 9; 
                B = A[":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A[\":;:;:\"] failed.");
                B = A["0:end;0:end;0:end"]; 
                if (!B.Equals(Res)) throw new Exception("A[\"0:end;0:end;0:end\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,14,15,16,17,18,19,20,21,22,23,24},4,3);
                if (!B.Equals(Res)) throw new Exception("A[\":;:;1\"] failed.");
                if (!B.IsMatrix) throw new Exception("wrong shape of A[:;:;1]"); 
                B = A["0:end;0:end;1"]; 
                if (!B.Equals(Res)) throw new Exception("A[\"0:end;0:end;1\"] failed.");
                if (!B.IsMatrix) throw new Exception("wrong shape of A[0:end;0:end;1]"); 
                errorCode = 11; 
                B = A["2,2;:;0"]; 
                Res = new ILArray<float> (new float[]{3,7,11,3,7,11},3,2).T; 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 3) throw new Exception("A[\"2,2;:;0\"] failed.");
                errorCode = 12; 
                B = A["2,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{19,15,19,23,19,15,19,23},4,2).T; 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 4 || B.Dimensions.NumberOfDimensions != 2) throw new Exception("A[\":;:;1\"] failed.");
                errorCode = 13; 
                // scalar
                B = A["2;1;0"]; 
                Res = 7; 
                if (!B.Equals(Res)) throw new Exception("A[\"2;1;0\"] failed.");
                errorCode = 14; 
                // vector
                B = A["2;1,0;0"]; 
                Res = new float[] {7,3}; 
                if (!B.Equals(Res)) throw new Exception("A[\"2;1,0;0\"] failed.");
                // test result if matrix 
                errorCode = 15; 
                B = A["2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,10,7,6,3,2},2,3); 
                if (!B.Equals(Res)) throw new Exception("A[\"2,1;2,1,0;0\"] failed.");
                errorCode = 16;
                B = A["0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreatePhysicalSubarrayFromReferenceShifted_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = (ILArray<float>)ILMath.reshape(A,4,3,2).CreateReference();
                A.MinimumRefDimensions = 6; 
                ILArray<float> B = A[1,":"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                errorCode = 2; 
                B = A[2,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":\"] failed.");
                errorCode = 3; 
                B = A[3,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[3,\":\"] failed.");
                errorCode = 4; 
                // shift outside dims 
                errorCode = 5; 
                B = A[4,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[4,\":\"] failed.");
                errorCode = 6; 
                // shift negative
                B = A[-3,":"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                if (!B.Equals(Res)) throw new Exception("A[-1,\":\"] failed.");
                errorCode = 7; 
                // shift inside dims 
                B = A[1,":,:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},48,1);
                if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                errorCode = 8; 
                B = A[1,":;:"]; 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:\" failed.");
                errorCode = 9; 
                B = A[2,":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[1,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,17,21,14,18,22,15,19,23,16,20,24},3,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[1,"1,2;:;0"]; 
                Res = new ILArray<float> (new float[]{2,6,10,3,7,11},3,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 3 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 12; 
                B = A[1,"1,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{18,14,18,22,19,15,19,23},4,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 4 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 13; 
                B = A[4,"2;1;0"]; 
                Res = 7; 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2;1;0\"] failed.");
                errorCode = 14; 
                B = A[4,"2,1;1,0;0"]; 
                Res = new ILArray<float> (new float[]{7,3,6,2},2,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1;1,0;0\"] failed.");
                // test result if matrix 
                errorCode = 15; 
                B = A[1,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,7,3,10,6,2},3,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1,0;1,0;0\"] failed.");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreateReferenceSubarrayFromArraySequential() {
            int errorCode = 0;
            try {
                // this function is obsolete !! 
                Success("This function is obsolete!");
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreateReferenceSubarrayFromArraySequentialShifted() {
            int errorCode = 0;
            try {
                // this function is obsolete !! 
                Success("This function is obsolete!");
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreateReferenceSubarrayFromPhysical_stringAddr() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A.Detach(); 
                A.MinimumRefDimensions = 2; 
                //ILArray<float> B = A[":"]; 
                //ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},24,1); 
                //if (!B.Equals(Res)) throw new Exception("A[:] failed.");
                //// shift inside dims 
                //B = A[0,":"]; 
                //if (!B.Equals(Res)) throw new Exception("A[0,\":\"] failed.");
                //B = A[-1,":"]; 
                //if (!B.Equals(Res)) throw new Exception("A[-1,\":\"] failed.");
                //B = A[-3,":"]; 
                //if (!B.Equals(Res)) throw new Exception("A[-3,\":\"] failed.");
                //errorCode = 1; 
                //// shift inside dims 
                ILArray<float> B = A[":;:"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[\":;:\" failed.");
                errorCode = 9; 
                B = A[":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A[\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,14,15,16,17,18,19,20,21,22,23,24},4,3);
                if (!B.Equals(Res)) throw new Exception("A[\":;:;1\"] failed.");
                if (!B.IsMatrix) throw new Exception("size of A[:;:;1] was wrong"); 
                errorCode = 11; 
                B = A["2,2;:;0"]; 
                Res = new ILArray<float> (new float[]{3,7,11,3,7,11},3,2).T; 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 3) throw new Exception("A[\"2,2;:;0\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != 0 || B.m_indexOffset.RegularySpacing(1) != 4) 
                    throw new Exception("A[\"2;:;0\"] failed.");
                errorCode = 12; 
                B = A["2,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{19,15,19,23,19,15,19,23},4,2).T; 
                if (!B.Equals(Res) || B.Dimensions[0] != 2 || B.Dimensions[1] != 4 || B.Dimensions.NumberOfDimensions != 2) throw new Exception("A[\":;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(1) != int.MinValue || B.m_indexOffset.RegularySpacing(0) != 0) 
                    throw new Exception("A[\"2;1,:;1\"] failed.");
                errorCode = 13; 
                // scalar - obsolete
                //B = A["2;1;0"]; 
                //Res = new ILArray<float> (7); 
                //if (!B.Equals(Res)) throw new Exception("A[\"2;1;0\"] failed.");
                //errorCode = 14; 
                //// vector
                //B = A["2;1,0;0"]; 
                //Res = new ILArray<float> (7,3); 
                //if (!B.Equals(Res)) throw new Exception("A[\"2;1,0;0\"] failed.");
                //if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 0 || B.m_indexOffset.RegularySpacing(1) != -4) 
                //            throw new Exception ("A[\"2;1,0;0\"] failed (invalid regSpacing)"); 
                // test result if matrix 
                errorCode = 15; 
                B = A["2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,10,7,6,3,2},2,3); 
                if (!B.Equals(Res)) throw new Exception("A[\"2,1;2,1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -1 || B.m_indexOffset.RegularySpacing(1) != -4) 
                            throw new Exception ("A[\"2,1;2,1,0;00\"]: invalid regSpacing)"); 
                errorCode = 16;
                B = A["0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                if (!B.Equals(Res)) throw new Exception("A[\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 1 || B.m_indexOffset.RegularySpacing(1) != 4) 
                            throw new Exception ("A[\"0,1,2,3;0,1,2,3,4,5\"] failed (invalid regSpacing)"); 
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_CreateReferenceSubarrayFromPhysicalShifted_stringDef() {
            int errorCode = 0;
            try {
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A.Detach(); 
                A.MinimumRefDimensions = 2; 
                //ILArray<float> B = A[0,":"]; 
                //ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},24,1); 
                //if (!B.Equals(Res)) throw new Exception("A.S(0) failed.");
                //errorCode = 1; 
                //// shift inside dims 
                //B = A[1,":"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                //if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                //errorCode = 2; 
                //B = A[2,":"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                //if (!B.Equals(Res)) throw new Exception("A[2,\":\"] failed.");
                //errorCode = 3; 
                //B = A[3,":"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                //if (!B.Equals(Res)) throw new Exception("A[3,\":\"] failed.");
                //errorCode = 4; 
                //// shift outside dims 
                //errorCode = 5; 
                //B = A[4,":"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                //if (!B.Equals(Res)) throw new Exception("A[4,\":\"] failed.");
                //errorCode = 6; 
                //// shift negative
                //B = A[-3,":"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},1,24); 
                //if (!B.Equals(Res)) throw new Exception("A[-1,\":\"] failed.");
                //errorCode = 7; 
                //// shift inside dims 
                //B = A[1,":,:"]; 
                //Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},48,1);
                //if (!B.Equals(Res)) throw new Exception("A[1,\":\"] failed.");
                errorCode = 8; 
                ILArray<float> B = A[1,":;:"]; 
                ILArray<float> Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},6,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:\" failed.");
                errorCode = 9; 
                B = A[2,":;:;:"]; 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A[2,\":;:;:\"] failed.");
                errorCode = 10; 
                // check if returned array is trimmed correctly
                // trim singleton at end & check regularity of spacing 
                B = A[1,":;:;1"]; 
                Res = new ILArray<float> (new float[]{13,17,21,14,18,22,15,19,23,16,20,24},3,4); 
                if (!B.Equals(Res)) throw new Exception("A[1,\":;:;1\"] failed.");
                errorCode = 11; 
                B = A[1,"1,2;:;0"]; 
                Res = new ILArray<float> (new float[]{2,6,10,3,7,11},3,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 3 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != 4 || B.m_indexOffset.RegularySpacing(1) != 1) 
                    throw new Exception("A[1,\"1,2;:;0\"] failed.");
                errorCode = 12; 
                B = A[1,"1,2;1,:;1"]; 
                Res = new ILArray<float> (new float[]{18,14,18,22,19,15,19,23},4,2); 
                if (!B.Equals(Res) || B.Dimensions[0] != 4 || B.Dimensions[1] != 2) throw new Exception("A[1,\":;:;1\"] failed.");
                if (!B.IsReference || B.m_indexOffset.RegularySpacing(0) != int.MinValue || B.m_indexOffset.RegularySpacing(1) != 1) 
                    throw new Exception("A[1,\"1,2;1,:;1\"] failed.");
                //errorCode = 13; 
                //B = A[4,"2;1;0"]; 
                //Res = new ILArray<float> (7); 
                //if (!B.Equals(Res)) throw new Exception("A[4,\"2;1;0\"] failed.");
                errorCode = 14; 
                B = A[4,"2,1;1,0;0"]; 
                Res = new ILArray<float> (new float[]{7,3,6,2},2,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -4 || B.m_indexOffset.RegularySpacing(1) != -1) 
                            throw new Exception ("A[4,\"2,1;1,0;0\"] failed (invalid regSpacing)"); 
                // test result if matrix 
                errorCode = 15; 
                B = A[1,"2,1;2,1,0;0"]; 
                Res = new ILArray<float> (new float[]{11,7,3,10,6,2},3,2); 
                if (!B.Equals(Res)) throw new Exception("A[4,\"2,1,0;1,0;0\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != -4 || B.m_indexOffset.RegularySpacing(1) != -1) 
                            throw new Exception ("A[4,\"2;1,0;0\"] failed (invalid regSpacing)"); 
                errorCode = 16; 
                B = A[1,"0,1,2,3;0,1,2,3,4,5"]; 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6).T; 
                if (!B.Equals(Res)) throw new Exception("A[1,\"0,1,2,3;0,1,2,3,4,5\"] failed.");
                if (!B.IsReference ||  B.m_indexOffset.RegularySpacing(0) != 4 || B.m_indexOffset.RegularySpacing(1) != 1) 
                            throw new Exception ("A[1,\"0,1,2,3;0,1,2,3,4,5\"] failed (invalid regSpacing)"); 
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        //public void Test_Subarray_RefShiftedFromPhysicalRanged_ArrayDef() {
        //    int errorCode = 0;
        //    try {
        //        throw new Exception("Test_Subarray_RefShiftedFromPhysicalRanged_ArrayDef needs to be implemented!");
        //        ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
        //        A = ILMath.reshape(A,4,3,2);
        //        A.Detach(); 
        //        A.MinimumRefDimensions = 2; 
        //        // shift = 0 
        //        ILArray<float> B = A.S(0); 
        //        ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(0) failed.");
        //        errorCode = 1; 
        //        // shift inside dims 
        //        B = A.S(1); 
        //        Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(1) failed.");
        //        errorCode = 2; 
        //        B = A.S(2); 
        //        Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(2) failed.");
        //        errorCode = 3; 
        //        B = A.S(3); 
        //        Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(3) failed.");
        //        errorCode = 4; 
        //        // shift outsife dims 
        //        B = A.S(4); 
        //        Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(4) failed.");
        //        errorCode = 5; 
        //        // shift negative
        //        B = A.S(-3); 
        //        Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
        //        if (!B.Equals(Res)) throw new Exception("A.S(-3) failed.");
        //        errorCode = 4; 
        //        Success("Test_Subarray_RefShiftedFromPhysicalRanged_ArrayDef successfull.");
        //    } catch (Exception e) {
        //        Error("Test_Subarray_RefShiftedFromPhysicalRanged_ArrayDef failed on ErrorCode: " + errorCode + "due: " + e.Message);
        //    }
        //}
        public void Test_Subarray_RefShiftedFromPhysical() {
            int errorCode = 0;
            try {
                
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A.Detach(); 
                A.MinimumRefDimensions = 2; 
                // shift = 0 
                ILArray<float> B = A.S(0); 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(0) failed.");
                errorCode = 1; 
                // shift inside dims 
                B = A.S(1); 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
                if (!B.Equals(Res)) throw new Exception("A.S(1) failed.");
                errorCode = 2; 
                B = A.S(2); 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A.S(2) failed.");
                errorCode = 3; 
                B = A.S(3); 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(3) failed.");
                errorCode = 4; 
                // shift outsife dims 
                B = A.S(4); 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
                if (!B.Equals(Res)) throw new Exception("A.S(4) failed.");
                errorCode = 5; 
                // shift negative
                B = A.S(-3); 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(-3) failed.");
                errorCode = 4; 
                Success("Test_Subarray_RefShiftedFromPhysical successfull.");
            } catch (Exception e) {
                Error("Test_Subarray_RefShiftedFromPhysical failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_Subarray_RefShiftedFromReference() {
            int errorCode = 0;
            try {
                
                ILArray<float> A = ILMath.tosingle(ILMath.vector(1.0,1.0,24)); 
                A = ILMath.reshape(A,4,3,2);
                A = (ILArray<float>)A.CreateReference(); 
                // shift = 0 
                ILArray<float> B = A.S(0); 
                ILArray<float> Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(0) failed.");
                errorCode = 1; 
                // shift inside dims 
                B = A.S(1); 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
                if (!B.Equals(Res)) throw new Exception("A.S(1) failed.");
                errorCode = 2; 
                B = A.S(2); 
                Res = new ILArray<float> (new float[]{1,13,2,14,3,15,4,16,5,17,6,18,7,19,8,20,9,21,10,22,11,23,12,24},2,4,3); 
                if (!B.Equals(Res)) throw new Exception("A.S(2) failed.");
                errorCode = 3; 
                B = A.S(3); 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(3) failed.");
                errorCode = 4; 
                // shift outsife dims 
                B = A.S(4); 
                Res = new ILArray<float> (new float[]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
                if (!B.Equals(Res)) throw new Exception("A.S(4) failed.");
                errorCode = 5; 
                // shift negative
                B = A.S(-3); 
                Res = new ILArray<float> (new float[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,3,2); 
                if (!B.Equals(Res)) throw new Exception("A.S(-3) failed.");
                errorCode = 4; 
                Success("Test_Subarray_RefShiftedFromPhysical successfull.");
            } catch (Exception e) {
                Error("Test_Subarray_RefShiftedFromPhysical failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_Remove() {
            int errorCode = 0;
            try {
                ILArray<double> A = ILMath.vector(1.0,1.0,12.0);
                A = ILMath.reshape(A,3,2,2); 
                A.MinimumRefDimensions = 2; 
                ILArray<double> ARes = new ILArray<double>(new double[8]{2.0,3.0,5.0,6.0,8.0,9.0,11.0,12.0},2,4);                                                            
                A[new ILBaseArray[2]{new ILArray<double>(0.0),null}] = ILArray<double>.empty();
                if (!A.Equals(ARes))
                    throw new Exception ("Test_Remove: remove by BaseArray indexer gives wrong result!"); 
                errorCode = 1; 
                A = ILMath.vector(1.0,1.0,12.0);
                A = ILMath.reshape(A,3,2,2); 
                A["0; : "] = null;
                if (!A.Equals(ARes))
                    throw new Exception ("Test_Remove: remove by string indexer gives wrong result!"); 
                ILArray<fcomplex> fcA = (ILArray<fcomplex>)ILMath.ones(NumericType.FComplex,2,3,4); 
                try {
                    fcA["1,1,10:133"] = null; 
                    throw new Exception("invalid range specification should be refused for removal!"); 
                } catch (ILArgumentException) {
                    Info("invalid range specification for removal correctly signaled."); 
                }
                fcA[1,1,2] = new fcomplex(4.0f,5.0f); 
                fcA[":;:;0,1,3"] = null; 
                
                if (fcA.Dimensions.NonSingletonDimensions != 2 || 
                    fcA.Dimensions.NumberOfDimensions != 3 || 
                    fcA.Dimensions[0] != 2 || 
                    fcA.Dimensions[1] != 3)
                    throw new Exception ("Invalid dimension result after removal: fcA"); 
                if (fcA.GetValue(1,1).real != 4.0f || fcA. GetValue(1,1).imag != 5.0f)
                    throw new Exception("Invalid value after removal: expected: 2x3, 1,1 = 4+5i");
                // fcA is [2x3x1] now. 
                fcA[":;0,2"] = null; 
                if (!fcA.IsColumnVector || fcA[1] != new fcomplex(4.0f,5.0f))
                    throw new Exception("Invalid index detected after removal. Expected: 4+5i. Found: " + fcA[1,0].ValuesToString(20)); 
                A = ILMath.vector(1,24); 
                A = ILMath.reshape(A,4,3,2); 
                A["1,2;:"] = null; 
                ARes = new ILArray<double>(new double[] {1,4,5,8,9,12,13,16,17,20,21,24},2,6); 
                if (!A.Equals(ARes)) throw new Exception("remove failed for: A[\"2,3;:\"] = null" );
                if (!A.IsReference || A.m_indexOffset.RegularySpacing(0) != int.MinValue || A.m_indexOffset.RegularySpacing(0) != int.MinValue )
                    throw new Exception("remove failed for: A[\"2,3;:\"] = null -> reg. spacing mismatch" );
                Success();   
            } catch (Exception e) {              
                Error(errorCode,e.Message);
            }
        }
        public void Test_TypeAfterRemoval() {
            int errorCode = 0;
            try {
                ILArray<double> A = ILMath.counter(4,3); 
                // reset reference parameters
                ILArray<double>.DetachReferences = ILDetachingBehavior.DetachSave;
                A.MinimumRefDimensions = 2; 
                // test if after removal no vector was created as reference  - for solid matrix
                A["2:end;:"] = null; 
                if (!A.IsReference || A.Dimensions[0] != 2 || A.Dimensions[1] != 3)
                    throw new Exception("invalid ref type // shape after removal"); 
                A = ILMath.counter(4,3); 
                A.MinimumRefDimensions = 2; 
                A["1:end;:"] = null; 
                if (A.IsReference) 
                    throw new Exception("removal should not create reference vectors!"); 
                if (!A.IsRowVector)
                    throw new Exception("invalid shape after removal"); 
                Success();   
            } catch (Exception e) {              
                Error(errorCode,e.Message);
            }
        }
        public void Test_IndexAccess() {
            int errorCode = 0;
            try {
                ILArray<double> A = ILMath.vector(0,10).T;
                A = A.Repmat(5,1);
                ILArray<double> ind1 = ILMath.vector(1,3,(double) new ILArray<double> (9.0));
                ILArray<double> Res = new ILArray<double> (new double[9]{1,1,1,4,4,4,7,7,7},3,3);
                ILArray<double> B = A[new ILArray<double>(new double[]{1.0, 2.0,4.0}),ind1];
                if (!B.Equals(Res)) {
                    throw new Exception ("Test_IndexAccess: Invalid Values detected!"); 
                }
                errorCode = 1; 
                B = A[ILMath.vector(0,4), ind1 + 2]; 
                Res = new ILArray<double> (new double[15]{3,3,3,3,3,6,6,6,6,6,9,9,9,9,9},5,3);
                if (!B.Equals(Res)) {
                    throw new Exception ("Test_IndexAccess: Invalid Values detected!"); 
                }
                // test for reference index arrays 
                errorCode = 2; 
                B = A[ILMath.vector(0,1,4).T.T, ind1 + 2]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("Test_IndexAccess: Invalid Values detected!"); 
                }
                Success("Test_IndexAccess successfull.");
            } catch (Exception e) {
                Error("Test_IndexAccess failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_IndexAccessPhysfromPhys() {
            // test unshifted copy from physical array
            int errorCode = 0;
            int oldMinRefDIm = ILNumerics.Settings.ILSettings.MinimumRefDimensions;
            try {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 4; 
                ILArray<double> A = ILMath.vector(1,24);
                A = ILMath.reshape(A,4,3,2);
                // test full copy
                ILArray<double> Res = (ILArray<double>)A.Clone(); 
                ILArray<double> B = A[":;:;:"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[:;:;:] - invalid result!"); 
                }
                errorCode = 1; 
                B = A["0:end;0:end;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 2; 
                B = A["0:end;:;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 3; 
                B = A["0:end;0:end;:"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 4; 
                B = A[":;0:end;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 5; 
                B = A["1:end;1:end;1:end"];
                Res = new ILArray<double>(new double[6]{18,19,20,22,23,24},3,2); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1:end;1:end;1:end] - invalid result!"); 
                }
                errorCode = 6; 
                B = A["1,2,3;1:end;1:end"];
                Res = new ILArray<double>(new double[6]{18,19,20,22,23,24},3,2); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,2,3;1:end;1:end] - invalid result!"); 
                }
                errorCode = 7; 
                B = A["1,2,3;end:-1:0;1"];
                Res = new ILArray<double>(new double[9]{22,23,24,18,19,20,14,15,16},3,3); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,2,3;end:-1:0;1] - invalid result!"); 
                }
                Success("Test_IndexAccessPhysfromPhys successfull.");
            } catch (Exception e) {
                Error("Test_IndexAccessPhysfromPhys failed on ErrorCode: " + errorCode + "due: " + e.Message);
            } finally {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldMinRefDIm;
            }
        }
        public void Test_IndexAccessPhysfromPhysShifted() {
            // test unshifted copy from physical array
            int errorCode = 0;
            int oldMinRefDIm = ILNumerics.Settings.ILSettings.MinimumRefDimensions;
            try {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 4; 
                ILArray<double> A = ILMath.vector(1,24);
                A = ILMath.reshape(A,4,3,2);
                // test full copy
                ILArray<double> Res = new ILArray<double>(new double[24]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4);
                ILArray<double> B = A[1,":;:;:"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,:;:;:] - invalid result!"); 
                }
                errorCode = 1; 
                B = A[1,"0:end;0:end;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 2; 
                B = A[1,"0:end;:;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 3; 
                B = A[1,"0:end;0:end;:"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 4; 
                B = A[1,":;0:end;0:end"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[0:end;0:end;0:end] - invalid result!"); 
                }
                errorCode = 5; 
                B = A[1,"1:end;1:end;1:end"];
                Res = new ILArray<double>(new double[6]{18,22,19,23,20,24},2,3); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1:end;1:end;1:end] - invalid result!"); 
                }
                errorCode = 6; 
                B = A[1,"1,2,3;1:end;1:end"];
                Res = new ILArray<double>(new double[6]{18,22,19,23,20,24},2,3); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,2,3;1:end;1:end] - invalid result!"); 
                }
                errorCode = 7; 
                B = A[1,"1,2,3;end:-1:0;1"];
                Res = new ILArray<double>(new double[9]{22,18,14,23,19,15,24,20,16},3,3); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,2,3;end:-1:0;1] - invalid result!"); 
                }
                Res = new ILArray<double>(new double[24]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4); 
                B = A[1,":;:;:"]; 
                if (!B.Equals(Res)) {
                    throw new Exception ("1,A[:;:;:] - invalid result!"); 
                }
                errorCode = 1; 
                Success("Test_IndexAccessPhysfromPhysShifted successfull.");
            } catch (Exception e) {
                Error("Test_IndexAccessPhysfromPhysShifted failed on ErrorCode: " + errorCode + "due: " + e.Message);
            } finally {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldMinRefDIm;
            }
        }
        public void Test_Shifted() {
            // test unshifted copy from physical array
            int errorCode = 0;
            int oldMinRefDIm = ILNumerics.Settings.ILSettings.MinimumRefDimensions;
            try {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 4; 
                ILArray<double> A = ILMath.vector(1,24);
                A = ILMath.reshape(A,4,3,2);
                // test full copy
                ILArray<double> Res = new ILArray<double>(new double[24]{1,5,9,13,17,21,2,6,10,14,18,22,3,7,11,15,19,23,4,8,12,16,20,24},3,2,4);
                ILArray<double> B = A.GetShifted(1); 
                if (!B.Equals(Res)) {
                    throw new Exception ("A[1,:;:;:] - invalid result!"); 
                }
                errorCode = 1; 
                Success("Test_IndexAccessPhysfromPhysShifted successfull.");
            } catch (Exception e) {
                Error("Test_IndexAccessPhysfromPhysShifted failed on ErrorCode: " + errorCode + "due: " + e.Message);
            } finally {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldMinRefDIm;
            }
        }
        public void Test_IsNumeric() {
            int errorCode = 0;
            try {
                string[] data = new string[20];
                for (int i = 0; i < data.Length; i++)
                    data[i] = "Value: " + i;
                ILBaseArray<string> A = new ILArray<string>(data, 4, 5);
                double[] ddata = new double[20] { 
					4,2,5,1,8,9,0,0,1,1,2,3,19,18,17,16,15,14,13,12 };
                ILArray<double> B = new ILArray<double>(ddata, 5, 2, 2);
                if (A.IsNumeric || !B.IsNumeric)
                    throw new Exception("wrong numeric state detected!");
                errorCode = 1;
                Success("Test_IsNumeric successfull.");
            } catch (Exception e) {
                Error("Test_IsNumeric failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_ReferenceFromArray() {
            int errorCode = 0;
            try {
				// B = A[idx,0]
				string[] data = new string[20];
                for (int i = 0; i < data.Length; i++)
                    data[i] = "Value: " + i;
                ILArray<string> A = new ILArray<string>(data, 4,5);
				double[] ddata = new double[20] { 
					4,2,5,1,8,9,0,0,1,1,2,3,19,18,17,16,15,14,13,12 }; 
				ILArray<double> B = new ILArray<double>(ddata, 5, 2, 2); 
				// create unshifted subarray, addressed by matrix -> physical storage
				ILArray<string> C = A[B];
				string[] results = new string[20];
				for (int i = 0; i < results.Length; i++) {
					results[i] = data[(int)ddata[i]];
				}
				ILBaseArray<string> res = new ILArray<string>(results, 5, 2 ,2);
				if (!res.Equals(C))
					throw new Exception("Invalid value of result!"); 
				
				errorCode = 1;
				// elements out of bound error 
				try {
					B[4, 1, 1] = 333.0;
					C = A[10,B]; // ( <= Quatsch!)
					Error("Expected \"Out of bound\" Exception: 333.0"); 
				} catch (Exception) {
					// nothing 
				}

				errorCode = 2;
				// elements out of bound error 
				try {
					B[4, 1, 1] = -1.0;
					C = A[1000,B];
					Error("Expected \"Out of bound\" Exception: -1.0");
				} catch (Exception) {
					Info("Out of bounds signaled correctly.");
				}
				// B = A[idx,2]

				// A[idx] = B
				Success("Test_ReferenceFromArray successfull.");
            } catch (Exception e) {
				Error("Test_ReferenceFromArray failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_CopyFromArray() {
            int errorCode = 0;
            int oldRefMin = ILNumerics.Settings.ILSettings.MinimumRefDimensions;
            try {
				ILNumerics.Settings.ILSettings.MinimumRefDimensions = 4; 
                // B = A[idx,0]
				ILArray<double> A = ILMath.reshape(ILMath.vector(1.0,1.0,24.0),2,3,4);
				ILArray<double> B = A["0,1;0,1,2;0,1,2,3"];  
				if (!B.Equals(A))
					throw new Exception("Invalid value of result!"); 
				errorCode = 1;
                B = A[1,"0,1;0,1,2;0,1,2,3"]; 
                ILArray<double> Res = new ILArray<double>(new double[24]{1,3,5,7,9,11,13,15,17,19,21,23,2,4,6,8,10,12,14,16,18,20,22,24},3,4,2);
                if (!Res.Equals(B))
                    throw new Exception("Copy physical shifted: Invald result detected!");
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldRefMin;
				Success("Test_CopyFromArray successfull.");
            } catch (Exception e) {
				Error("Test_CopyFromArray failed on ErrorCode: " + errorCode + "due: " + e.Message);
            } finally {
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldRefMin;
            }
        }
        public void Test_IndexAccessPhysicalSequential() {
            int errorCode = 1;
            try {
                // B = A[idx,0]
				ILArray<double> A = ILMath.reshape(ILMath.vector(0.0,23.0),2,3,4);
                A.MinimumRefDimensions = 2;
				ILArray<double> ind = new ILArray<double> (2,4,6,8); 
                ILArray<double> B = A[ind];  
				if (!B.Equals(ind))
					throw new Exception("Invalid value of result!"); 
				errorCode = 2;
                // B = A[idx,0]
				A = ILMath.reshape(ILMath.vector(0.0,23.0),2,3,4);
				ind = new ILArray<double> (2,4,6,8); 
				A.MinimumRefDimensions = 4; 
                B = A[ind];  
				if (!B.Equals(ind))
					throw new Exception("Invalid value of result!"); 
				errorCode = 3;
                ind = new ILArray<double> (new double[4]{2,4,6,8},2,2); 
                ILArray<double> Res = (ILArray<double>)ind.Clone(); 
                B = A[ind]; 
				if (!B.Equals(Res))
					throw new Exception("Invalid value of result!"); 
				errorCode = 4;
                ind = new ILArray<double> (new double[4]{2,4,6,8},2,2); 
                Res = (ILArray<double>)ind.T; 
                B = A[1,ind]; 
				if (!B.Equals(Res))
					throw new Exception("Invalid value of result!"); 
				Success();
                
            } catch (Exception e) {
				Error(errorCode,e.Message);
            }
        }
	}
}
