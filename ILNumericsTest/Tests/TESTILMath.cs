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
using ILNumerics.Exceptions;
using ILDA = ILNumerics.ILArray<double>;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace ILNumerics.Test {
	public class TESTILMath : ILTest {
		
		public override void Run() {
			// tests: creation
			// =================
			Header();
            Test_horzcat(); 
            Test_Cat(); 
            Test_solve(); 
			Test_Apply(); 
            Test_abs(); 
            Test_diff(); 
			Test_Sum();
            Test_MMult(); 
            Test_Max();
            Test_sumall(); 
            Test_basicOps(); 
            Test_any();
            Test_empty(); 
            Test_ind2sub(); 
            Test_sub2ind(); 
            Test_linspace(); 
            Test_solveLowerTriag(); 
            Test_solveUpperTriag();
            Test_ishermitian(); 
            Test_istriup();
            Test_istrilow(); 
            Test_Find();
            Test_vector(); 
            Test_Basic(); 
            Test_Prod(); 
            Test_Min(); 
            Test_Repmat(); 
			Test_Relop();
			Test_Eye();
			// summary
			Footer();
		}

        private void Test_abs() {
            int errorCode = 0; 
            try {
                ILArray<double> A = new double[,]{
                    {-1,-2,-3,-4},
                    {-5,-6,-7,-8},
                    {-9,-10,-11,-12}};
                ILArray<double> ARes = new double[,]{
                    {1,2,3,4},
                    {5,6,7,8},
                    {9,10,11,12}};
                if (!ARes.Equals(ILMath.abs(A))) 
                    throw new Exception("dense matrix: wrong result"); 
                if (!ARes.Equals(ILMath.abs(A.R)))
                    throw new Exception("reference matrix: wrong result"); 
                // test dense 2x2x3
                A.Reshape(new ILDimension(2,2,3)); 
                ARes.Reshape(new ILDimension(2,2,3)); 
                if (A.IsReference || ARes.IsReference) 
                    throw new Exception("unable to create dense: 2x2x3"); 
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("dense 2x2x3 array: wrong result"); 
                // test reference 2x2x3
                A = A.R; ARes = ARes.R; 
                if (!A.IsReference || !ARes.IsReference) 
                    throw new Exception("unable to create reference: 2x2x3"); 
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("reference 2x2x3 array: wrong result"); 
                // test reference 2x3x2
                A = A.T; ARes = ARes.T;
                if (!A.IsReference || !ARes.IsReference) 
                    throw new Exception("unable to create reference: 2x3x2"); 
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("reference 2x2x3 array: wrong result"); 
                // test reference 3x2x2
                A = A.T; ARes = ARes.T;
                if (!A.IsReference || !ARes.IsReference) 
                    throw new Exception("unable to create reference: 3x2x2"); 
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("reference 2x2x3 array: wrong result"); 
                // test vector (dense)
                A = A[":"]; ARes = ARes[":"]; 
                if (A.IsReference || ARes.IsReference) 
                    throw new Exception("unable to create dense vector: 1x12");
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("reference 2x2x3 array: wrong result"); 
                // test scalar
                A = A[2]; ARes = ARes[2]; 
                if (!ARes.Equals(ILMath.abs(A)))
                    throw new Exception("scalar: wrong result"); 
                // test empty 
                A = ILArray<double>.empty(); 
                if (!ILMath.abs(A).IsEmpty) 
                    throw new Exception("empty: wrong result"); 
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }

        public void Test_diff() {
            int errorCode = 0;
            try {
                // test vector
                ILArray<double> A = ILMath.pow(ILMath.vector(1,10),2);
                ILArray<double> B = ILMath.diff(A); 
                ILArray<double> Res = new double[]{3,5,7,9,11,13,15,17,19}; 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (dense, vector)");
                B = ILMath.diff((ILArray<double>)A.CreateReference()); 
                if (!B.Equals(Res))
                    throw new Exception("diff: invalid results (reference, vector)");
                // test matrix 
                A = ILMath.pow(ILMath.counter(1.0,1.0,4,6),2);
                B = ILMath.diff(A); 
                Res = ILMath.counter(3.0,2.0,4,6)["0:2;:"]; 
                if (!Res.Equals(B))
                    throw new Exception("diff: invalid results (dense, matrix)");
                B = ILMath.diff(A.R); 
                if (!Res.Equals(B))
                    throw new Exception("diff: invalid results (reference, matrix)");
                // matrx along 2nd dimension
                Res = ILMath.counter(24.0,8.0,4,5); 
                B= ILMath.diff(A,1,1); 
                if (!B.Equals(Res))
                    throw new Exception("diff: invalid results (dense, matrix, leadDim:1)");
                B= ILMath.diff(A.R,1,1); 
                if (!B.Equals(Res))
                    throw new Exception("diff: invalid results (reference, matrix, leadDim:1)");
                // test n-dim array
                A = ILMath.pow(ILMath.counter(4,3,2),2); 
                Res = ILMath.counter(3.0,2.0,4,3,2)["0:2;:;:"];
                B = ILMath.diff(A); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (dense, n-d)");
                B = ILMath.diff(A.R); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (reference, n-d)");
                // along non-first dimension
                Res = new double[]{24,32,40,48,56,64,72,80,120,128,136,144,152,160,168,176}; 
                Res = ILMath.reshape(Res,4,2,2); 
                B = ILMath.diff(A,1,1); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (dense, n-d, leadDim:1)");
                B = ILMath.diff(A.R,1,1); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (reference, n-d, leadDim:1)");
                // along 3rd dimension
                Res = new ILArray<double>(new double[]{168,192,216,240,264,288,312,336,360,384,408,432},4,3); 
                B = ILMath.diff(A,1,2); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (dense, n-d, leadDim:2)");
                B = ILMath.diff(A.R,1,2); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (reference, n-d, leadDim:2)");
                // 2nd derivative
                Res = ILMath.ones(4,1,2) * 32.0; 
                B = ILMath.diff(A,2,1); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (dense, n-d, leadDim:1, deriv:2)");
                B = ILMath.diff(A.R,2,1); 
                if (!B.Equals(Res)) 
                    throw new Exception("diff: invalid results (reference, n-d, leadDim:1, deriv:2)");
                // test empty, scalar -> should return empty
                A = 1.0; 
                if (!(ILMath.diff(A)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([scalar]) should return empty array");
                A[0] = null; // makes A an empty array
                if (!(ILMath.diff(A)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([empty]) should return empty array");
                A = 1.0; 
                if (!(ILMath.diff(A,1,0)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([scalar]) should return empty array");
                A[0] = null; // makes A an empty array
                if (!(ILMath.diff(A,1,0)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([empty]) should return empty array");
                A = 1.0; 
                if (!(ILMath.diff(A,1,2)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([scalar]) should return empty array");
                A[0] = null; // makes A an empty array
                if (!(ILMath.diff(A,1,2)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([empty]) should return empty array");
                A = 1.0; 
                if (!(ILMath.diff(A,3,2)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([scalar]) should return empty array");
                A[0] = null; // makes A an empty array
                if (!(ILMath.diff(A,3,2)).IsEmpty) 
                    throw new Exception("diff: invalid result: diff([empty]) should return empty array");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_basicOps() {
            int errorCode = 0; 
            try {
                ILArray<double> I = ILMath.counter(4,3);
                I[":;1:end"] = null; 
                ILArray<double> res = I - 1.0;
                if (!res.IsVector || res.IsReference || ILMath.sum(res) != 6.0)
                    throw new Exception("invalid result");
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_sumall() {
            int errorCode = 0; 
            try {
                // solid arrays: 
                ILArray<double> A = ILArray<double>.empty(); 
                if (!ILMath.sumall(A).IsEmpty)
                    throw new Exception("empty array should return empty array!"); 
                A = ILMath.counter(4.0,1.0,1,1); 
                if (ILMath.sumall(A) != 4.0)
                    throw new Exception("invalid result");
                A = ILMath.counter(4.0,1.0,10,1); 
                if (ILMath.sumall(A) != 85.0)
                    throw new Exception("invalid result");
                A = ILMath.counter(4.0,1.0,1,10); 
                if (ILMath.sumall(A) != 85.0)
                    throw new Exception("invalid result");
                A = ILMath.counter(4.0,1.0,10,10); 
                if (ILMath.sumall(A) != 5350.0)
                    throw new Exception("invalid result");
                A = ILMath.counter(4.0,-1.0,10,10,10); 
                if (ILMath.sumall(A) != -495500)
                    throw new Exception("invalid result");
                // for reference arrays: 
                A = ILMath.counter(4.0,1.0,10,10).R; 
                if (ILMath.sumall(A) != 5350.0)
                    throw new Exception("invalid result");
                A = ILMath.counter(4.0,-1.0,10,10,10).R; 
                if (ILMath.sumall(A) != -495500)
                    throw new Exception("invalid result");
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_any() {
            int errorCode = 0; 
            try {
                ILArray<int> I = ILMath.toint32(ILMath.counter(4,3,2));
                I[":;1"] = 0; 
                ILLogicalArray res = new ILLogicalArray (new byte[]{1,0,1,1,1,1},1,3,2); 
                if (!ILMath.any(I).Equals(res))
                    throw new Exception("invalid result");
                res["0;:;0"] = 0; 
                ILLogicalArray res2 = new ILLogicalArray (new byte[]{0,1},1,1,2);
                if (!ILMath.any(res).Equals(res2))
                    throw new Exception("invalid result");
                if (!ILMath.any(res2).Equals((byte)1))
                    throw new Exception("invalid result");
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_empty() {
            int errorCode = 0; 
            try {
                Info("Ignore errors on this Test -Test ! "); 
//                ILCell C = new ILCell(5,4); 
//                ILCell Ci = new ILCell(20,3); 
//                ILArray<double> A = ILMath.counter(4,3,2);
//                ILArray<int> I = new int[]{0,2,3,4};
//                C[I,3] = C[I,0]; 
//                C[0,0] = A; C[02,0] = Ci; 
//                C = new ILCell(2,3); 
//// store another cell into the first cell element of C
//Ci = new ILCell(2,4); 
//Ci[0] = ILMath.rand(4,5);
//C[0] = Ci; 
//// now store a ILArray&lt;double&gt; into the inner cell
//Ci[0] = ILMath.rand(4,5);
//                ILArray<double> fromC = (ILArray<double>)C[0,0]; 
//                C[I,null] = A; 
//                fromC[1,1,1] = 333; 
//                Double d1 = 2.0; Double d2 = d1; 
//                d1 = 3.0; 
                Info("Ignore errors on this Test -Test ! "); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_ind2sub() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                try {
                    if (ILMath.ind2sub(A,5).Length != 0)  
                        throw new ILArgumentException("ind2sub: on empty should return empty int[] array");
                } catch (System.IndexOutOfRangeException) {
                    // on empty throw exception
                }
                A = ILMath.counter(5,4,3); 
                try {
                    ILMath.ind2sub(A,-1);
                    throw new ILArgumentException("ind2sub on out of range shouold throw exception!"); 
                } catch (System.IndexOutOfRangeException) {
                    // on empty throw exception
                }
                int [] ret = ILMath.ind2sub(A,0); 
                if (ret.Length != 3 || ret[0] != 0 || ret[1] != 0 || ret[2] != 0)
                    throw new ILArgumentException("invalid value detected!");
                ret = ILMath.ind2sub(A,1); 
                if (ret.Length != 3 || ret[0] != 1 || ret[1] != 0 || ret[2] != 0)
                    throw new ILArgumentException("invalid value detected!");
                ret = ILMath.ind2sub(A,7); 
                if (ret.Length != 3 || ret[0] != 2 || ret[1] != 1 || ret[2] != 0)
                    throw new ILArgumentException("invalid value detected!");
                ret = ILMath.ind2sub(A,38); 
                if (ret.Length != 3 || ret[0] != 3 || ret[1] != 3 || ret[2] != 1)
                    throw new ILArgumentException("invalid value detected!");
                try {
                    ILMath.ind2sub(A,180);
                    throw new ILArgumentException("ind2sub on out of range shouold throw exception!"); 
                } catch (System.IndexOutOfRangeException) {

                }
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_sub2ind() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                try {
                    ILMath.sub2ind(A,new int[]{3,2,5});
                } catch (Exception) {
                    // on empty throw exception
                }
                A = ILMath.counter(5,4,3); 
                try {
                    ILMath.sub2ind(A,new int[0]);
                } catch (Exception) {
                    // on empty throw exception
                }
                if (ILMath.sub2ind(A,new int[]{0}) != 0)
                    throw new ILArgumentException("invalid value detected!");
                if (ILMath.sub2ind(A,new int[]{6}) != 6)
                    throw new ILArgumentException("invalid value detected!");
                if (ILMath.sub2ind(A,new int[]{0,0}) != 0)
                    throw new ILArgumentException("invalid value detected!");
                if (ILMath.sub2ind(A,new int[]{0,1}) != 5)
                    throw new ILArgumentException("invalid value detected!");
                if (ILMath.sub2ind(A,new int[]{0,1,1}) != 25)
                    throw new ILArgumentException("invalid value detected!");
                if (ILMath.sub2ind(A,new int[]{4,3,2}) != 59)
                    throw new ILArgumentException("invalid value detected!");
                try {
                    if (ILMath.sub2ind(A,new int[]{4,3,3}) != 79 || ILMath.sub2ind(A,new int[]{4,3,2,2}) != 179)
                        Info ("sub2ind: subscripts out of range gave false value");
                } catch (Exception) {
                    Info("sub2ind: subscript out of range threw exception."); 
                }
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveUpperTriag() {
            int errorCode = 0; 
            try {
                ILArray<double> A = new ILArray<double> (new double[]{1,2,3,0,4,5,0,0,6},3,3).T; 
                ILArray<double> B = new ILArray<double> (new double[]{1,2,3},3,1); 
                ILArray<double> Res = new ILArray<double> (new double[]{-0.250000, -0.125000,  0.500000},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (double)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveUpperTriangularSystem has found singularity!");
                A = new ILArray<double> (new double[]{3,5,6,2,4,0,1,0,0},3,3);
                A = A[":;2,1,0"];
                info = 0; 
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (double)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveUpperTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<double>(new double[]{1,2,3,0,0,5,0,0,6},3,3).T;
                Res = new ILArray<double> (new double[]{double.PositiveInfinity, double.PositiveInfinity,  0.500000},3,1);
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(singular)->[3 x 3] (double)");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveUpperTriangularSystem has found no singularity!");
 
                Test_solveUpperTriagFloat(); 
                Test_solveUpperTriagFComplex();
                Test_solveUpperTriagComplex();
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveUpperTriagComplex() {
            int errorCode = 0; 
            try {
                ILArray<complex> A = new ILArray<complex> (new complex[]{1,2,3,0,4,5,0,0,6},3,3).T; 
                ILArray<complex> B = new ILArray<complex> (new complex[]{1,2,3},3,1); 
                ILArray<complex> Res = new ILArray<complex> (new complex[]{new complex(-0.250000f,0), new complex(-0.125000f,0),  new complex(0.500000f,0)},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (complex)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveUpperTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<complex>(new complex[]{1,2,3,0,0,5,0,0,6},3,3).T;
                Res = new ILArray<complex> (new complex[]{new complex(double.PositiveInfinity,0.0f),new complex(double.PositiveInfinity,0.0f), new complex(0.500000f,0.0f)},3,1);
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(complex,singular)->[3 x 3]");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveUpperTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveUpperTriagFComplex() {
            int errorCode = 0; 
            try {
                ILArray<fcomplex> A = new ILArray<fcomplex> (new fcomplex[]{1,2,3,0,4,5,0,0,6},3,3).T; 
                ILArray<fcomplex> B = new ILArray<fcomplex> (new fcomplex[]{1,2,3},3,1); 
                ILArray<fcomplex> Res = new ILArray<fcomplex> (new fcomplex[]{new fcomplex(-0.250000f,0), new fcomplex(-0.125000f,0),  new fcomplex(0.500000f,0)},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (fcomplex)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveUpperTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<fcomplex>(new fcomplex[]{1,2,3,0,0,5,0,0,6},3,3).T;
                Res = new ILArray<fcomplex> (new fcomplex[]{new fcomplex(float.PositiveInfinity,0.0f),new fcomplex(float.PositiveInfinity,0.0f), new fcomplex(0.500000f,0.0f)},3,1);
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(fcomplex,singular)->[3 x 3]");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveUpperTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveUpperTriagFloat() {
            int errorCode = 0; 
            try {
                ILArray<float> A = new ILArray<float> (new float[]{1,2,3,0,4,5,0,0,6},3,3).T; 
                ILArray<float> B = new ILArray<float> (new float[]{1,2,3},3,1); 
                ILArray<float> Res = new ILArray<float> (new float[]{-0.250000f, -0.125000f,  0.500000f},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (float)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveUpperTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<float>(new float[]{1,2,3,0,0,5,0,0,6},3,3).T;
                Res = new ILArray<float> (new float[]{float.PositiveInfinity, float.PositiveInfinity,  0.500000f},3,1);
                if (ILMath.norm(ILMath.solveUpperTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(float,singular)->[3 x 3]");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveUpperTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }

        public void Test_solve() {
            int errorCode = 0; 
            try {
                // this test is due the bugreport by Zafer.
                // TODO: it is by no means complete! Only testing lower triangul. matrix... 
                // some test data: upper triangular
                ILArray<double> A = new double[,]{{1,0,8,0},{2,3,8,0},{6,7,8,8},{4,5,8,6}};
                // delete 3rd row & column
                A[null,2] = null; A[2.0,null] = null;
                // make sure, we are handling a reference array
                if (!A.IsReference) A = A.R;
                // create right hand side
                ILArray<double> x = new double[]{16,-1,2};
                // solve via linsolve
                MatrixProperties props = MatrixProperties.LowerTriangular;
                A = A.C; 
                ILArray<double> y = ILMath.linsolve(A.T,x.T,ref props);
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveLowerTriag() {
            int errorCode = 0; 
            try {
                ILArray<double> A = new ILArray<double> (new double[]{1,0,0,2,3,0,4,5,6},3,3).T; 
                ILArray<double> B = new ILArray<double> (new double[]{1,2,3},3,1); 
                ILArray<double> Res = new ILArray<double> (new double[]{1.000000,  0.000000, -0.166667},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (double)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveLowerTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<double>(new double[]{1,0,0,2,0,0,4,5,6},3,3).T;
                Res = new ILArray<double> (new double[]{1.0, double.PositiveInfinity, double.PositiveInfinity},3,1);
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(singular)->[3 x 3] (double)");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveLowerTriangularSystem has found no singularity!");
                Test_solveLowerTriagFloat(); 
                Test_solveLowerTriagFComplex();
                Test_solveLowerTriagComplex();
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveLowerTriagComplex() {
            int errorCode = 0; 
            try {
                ILArray<complex> A = new ILArray<complex> (new complex[]{1,0,0,2,3,0,4,5,6},3,3).T; 
                ILArray<complex> B = new ILArray<complex> (new complex[]{1,2,3},3,1); 
                ILArray<complex> Res = new ILArray<complex> (new complex[]{new complex(1.0f,0), new complex(0.0f,0),  new complex(-0.166667f,0)},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (complex)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveLowerTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<complex>(new complex[]{1,0,0,2,0,0,4,5,6},3,3).T;
                Res = new ILArray<complex> (new complex[]{1.0, float.PositiveInfinity, 0.500000f},3,1);
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(complex,singular)->[3 x 3]");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveLowerTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveLowerTriagFComplex() {
            int errorCode = 0; 
            try {
                ILArray<fcomplex> A = new ILArray<fcomplex> (new fcomplex[]{1,0,0,2,3,0,4,5,6},3,3).T; 
                ILArray<fcomplex> B = new ILArray<fcomplex> (new fcomplex[]{1,2,3},3,1); 
                ILArray<fcomplex> Res = new ILArray<fcomplex> (new fcomplex[]{new fcomplex(1.0f,0), new fcomplex(0.0f,0),  new fcomplex(-0.166667f,0)},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (fcomplex)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveLowerTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<fcomplex>(new fcomplex[]{1,0,0,2,0,0,4,5,6},3,3).T;
                Res = new ILArray<fcomplex> (new fcomplex[]{1.0, float.PositiveInfinity, 0.500000f},3,1);
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(fcomplex,singular)->[3 x 3]");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveLowerTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_solveLowerTriagFloat() {
            int errorCode = 0; 
            try {
                ILArray<float> A = new ILArray<float> (new float[]{1,0,0,2,3,0,4,5,6},3,3).T; 
                ILArray<float> B = new ILArray<float> (new float[]{1,2,3},3,1); 
                ILArray<float> Res = new ILArray<float> (new float[]{1.000000f,  0.000000f, -0.166667f},3,1); 
                int info = 0; 
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A->[3 x 3] (float)");
                if (info >= 0) 
                    throw new Exception("matrix A is not singular, but solveLowerTriangularSystem has found singularity!");
                errorCode = 1; 
                A = new ILArray<float>(new float[]{1,0,0,2,0,0,4,5,6},3,3).T;
                Res = new ILArray<float> (new float[]{1.0f, float.PositiveInfinity, float.PositiveInfinity},3,1);
                if (ILMath.norm(ILMath.solveLowerTriangularSystem(A,B,ref info) - Res) > 1e-6)
                    throw new Exception("invalid values detected: A(singular)->[3 x 3] (float)");
                if (info < 0) 
                    throw new Exception("matrix A is singular, but solveLowerTriangularSystem has found no singularity!");
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }

        private void Test_ishermitianComplex() {
            int errorCode = 0; 
            try {
                ILArray<complex> A = ILArray<complex>.empty(); 
                if (ILMath.ishermitian(A))
                    throw new Exception("ishermitian on empty array should return false"); 
                A = new complex(1.0,1.0); 
                if (!ILMath.ishermitian(A))
                    throw new Exception("ishermitian on scalar array should return true"); 
                A = ILMath.tocomplex( ILMath.vector(1,5));
                if (ILMath.ishermitian(A))
                    throw new Exception("ishermitian on scalar array should return false"); 
                errorCode = 1; 
                A = ILMath.tocomplex(ILMath.randn (4,4));
                for (int i = 0; i < 16; i++)
                    A.SetValue(new complex(A.GetValue(i).real,A.GetValue(i).real),i); 
                A[1,0] = A.GetValue(0,1).conj; 
                A[2,0] = A.GetValue(0,2).conj; 
                A[2,1] = A.GetValue(1,2).conj; 
                A[3,0] = A.GetValue(0,3).conj; 
                A[3,1] = A.GetValue(1,3).conj; 
                A[3,2] = A.GetValue(2,3).conj; 
                A[0,0] = (complex)A.GetValue(0,0).real;
                A[1,1] = (complex)A.GetValue(1,1).real;
                A[2,2] = (complex)A.GetValue(2,2).real;
                A[3,3] = (complex)A.GetValue(3,3).real;

                if (!ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was Hermitian but detected as not");
                A[3,2] += new complex(1.0,0.0); 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                A[3,2] -= new complex(1.0,0.0);
                A[1,0] += new complex(1.0,0.0); 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                A[1,0] -= new complex(1.0,0.0);
                A[3,0] += new complex(1.0,0.0); 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                errorCode = 2; 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_ishermitian() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                if (ILMath.ishermitian(A))
                    throw new Exception("ishermitian on empty array should return false"); 
                A = 1.0; 
                if (!ILMath.ishermitian(A))
                    throw new Exception("ishermitian on scalar array should return true"); 
                A = ILMath.vector(1,5);
                if (ILMath.ishermitian(A))
                    throw new Exception("ishermitian on scalar array should return false"); 
                errorCode = 1; 
                A = ILMath.randn (4,4);
                A[1,0] = A[0,1]; 
                A[2,0] = A[0,2]; 
                A[2,1] = A[1,2]; 
                A[3,0] = A[0,3]; 
                A[3,1] = A[1,3]; 
                A[3,2] = A[2,3]; 
                if (!ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was Hermitian but detected as not");
                A[3,2] += 1; 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                A[3,2] -= 1;
                A[1,0] += 1; 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                A[1,0] -= 1;
                A[3,0] += 3; 
                if (ILMath.ishermitian(A)) 
                    throw new Exception("ishermitian: A was not Hermitian but detected as true");
                errorCode = 2; 
                Test_ishermitianComplex();
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_istriup() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                if (ILMath.istriup (A))
                    throw new Exception("istriup on empty array should return false"); 
                A = 1.0; 
                if (!ILMath.istriup (A))
                    throw new Exception("istriup on scalar array should return true"); 
                A = ILMath.vector(1,5);
                if (ILMath.istriup(A)) 
                    throw new Exception("istriup on this vector should return false"); 
                errorCode = 1; 
                A = ILMath.ones (4,4);
                A[1,0] = 0; 
                A[2,0] = 0; 
                A[2,1] = 0; 
                A[3,0] = 0; 
                A[3,1] = 0; 
                A[3,2] = 0; 
                if (!ILMath.istriup(A)) 
                    throw new Exception("trilow: A was triangular but detected as not");
                A[3,2] = 2; 
                if (ILMath.istriup(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[3,2] = 0;
                A[1,0] = 2; 
                if (ILMath.istriup(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[1,0] = 0;
                A[3,0] = 3; 
                if (ILMath.istriup(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                errorCode = 2; 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_istrilow() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                if (ILMath.istrilow (A))
                    throw new Exception("istrilow on empty array should return false"); 
                A = 1.0; 
                if (!ILMath.istrilow (A))
                    throw new Exception("istrilow on scalar array should return true"); 
                A = ILMath.vector(1,5);
                if (!ILMath.istrilow(A))  
                    throw new Exception("istrilow on this vector should return false!"); 
                errorCode = 1; 
                A = ILMath.ones (4,4);
                A[0,1] = 0; 
                A[0,2] = 0; 
                A[0,3] = 0; 
                A[1,2] = 0; 
                A[1,3] = 0; 
                A[2,3] = 0; 
                if (!ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was triangular but detected as not");
                A[2,3] = 2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[2,3] = 0;
                A[0,1] = 2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[0,1] = 0;
                A[0,3] = 3; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                Test_istrilowFloat(); 
                Test_istrilowFComplex();
                Test_istrilowChar();
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        private void Test_istrilowFloat() {
            int errorCode = 0; 
            try {
                ILArray<float> A = ILArray<float>.empty(); 
                if (ILMath.istrilow (A))
                    throw new Exception("istrilow on empty array should return false"); 
                A = 1.0f; 
                if (!ILMath.istrilow (A))
                    throw new Exception("istrilow on scalar array should return true"); 
                A = ILMath.tosingle(ILMath.vector(1,5));
                if (!ILMath.istrilow(A))  
                    throw new Exception("istrilow on vector should throw Exception!"); 
                errorCode = 1; 
                A = (ILArray<float>) ILMath.ones (NumericType.Single,4,4);
                A[0,1] = 0; 
                A[0,2] = 0; 
                A[0,3] = 0; 
                A[1,2] = 0; 
                A[1,3] = 0; 
                A[2,3] = 0; 
                if (!ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was triangular but detected as not");
                A[2,3] = 2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[2,3] = 0;
                A[0,1] = 2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[0,1] = 0;
                A[0,3] = 3; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        private void Test_istrilowFComplex() {
            int errorCode = 0; 
            try {
                ILArray<fcomplex> A = ILArray<fcomplex>.empty(); 
                if (ILMath.istrilow (A))
                    throw new Exception("istrilow on empty array should return false"); 
                A = (fcomplex)1.0f; 
                if (!ILMath.istrilow (A))
                    throw new Exception("istrilow on scalar array should return true"); 
                A = ILMath.tofcomplex(ILMath.vector(1,5));
                if (!ILMath.istrilow(A))  
                    throw new Exception("istrilow on vector should throw Exception!"); 
                errorCode = 1; 
                A = (ILArray<fcomplex>) ILMath.ones (NumericType.FComplex,4,4);
                A[0,1] = (fcomplex)0; 
                A[0,2] = (fcomplex)0; 
                A[0,3] = (fcomplex)0; 
                A[1,2] = (fcomplex)0; 
                A[1,3] = (fcomplex)0; 
                A[2,3] = (fcomplex)0; 
                if (!ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was triangular but detected as not");
                A[2,3] = (fcomplex)2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[2,3] = (fcomplex)0;
                A[0,1] = (fcomplex)2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[0,1] = (fcomplex)0;
                A[0,3] = (fcomplex)3; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        private void Test_istrilowChar() {
            int errorCode = 0; 
            try {
                ILArray<char> A = ILArray<char>.empty(); 
                if (ILMath.istrilow (A))
                    throw new Exception("istrilow on empty array should return false"); 
                A = (char)1; 
                if (!ILMath.istrilow (A))
                    throw new Exception("istrilow on scalar array should return true"); 
                A = ILMath.tochar(ILMath.vector(1,5));
                if (!ILMath.istrilow(A)) 
                    throw new Exception("istrilow on vector should throw Exception!"); 
                errorCode = 1; 
                A = (ILArray<char>) ILMath.ones (NumericType.Char,4,4);
                A[0,1] = (char)0; 
                A[0,2] = (char)0; 
                A[0,3] = (char)0; 
                A[1,2] = (char)0; 
                A[1,3] = (char)0; 
                A[2,3] = (char)0; 
                if (!ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was triangular but detected as not");
                A[2,3] = (char)2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[2,3] = (char)0;
                A[0,1] = (char)2; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
                A[0,1] = (char)0;
                A[0,3] = (char)3; 
                if (ILMath.istrilow(A)) 
                    throw new Exception("trilow: A was not triangular but detected as true");
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_vector() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILMath.vector(20.2,3.2,31.9); 
                ILArray <double> Res = new ILArray<double>(new double [4] {20.2000 , 23.4000 ,  26.6000 ,  29.8000},1,4); 
                if (ILMath.sum(ILMath.norm(Res - A.T)) > 1e-10)
                    throw new Exception ("Test_vector: invalid values detected!"); 
                errorCode = 1; 
                A = ILMath.vector(2.2,-1.2,-3.9); 
                Res = new ILArray<double>(new double [6] {2.2000 ,   1.0000  , -0.2000  , -1.4000,   -2.6000  , -3.8000},1,6); 
                if (ILMath.sum(ILMath.norm(Res - A.T)) > 1e-10)
                    throw new Exception ("Test_vector: invalid values detected!"); 
                errorCode = 2; 
                try {
                    A = ILMath.vector(4,2,2);
                } catch (Exception e) {
                    if (!(e is ILArgumentException )) 
                        throw new Exception ("vector: invalid parameter should throw ILArgumentException!");
                }
                errorCode = 3; 
                A = ILMath.vector (4,10);
                Res = new ILArray<double>(new double[7] {4,5,6,7,8,9,10},1,7); 
                if (ILMath.sum(ILMath.norm(Res - A.T)) > 1e-10)
                    throw new Exception ("Test_vector: invalid values detected!"); 

                errorCode = 4; 
                A = ILMath.vector (6,-2);
                Res = new ILArray<double>(new double[9] {6,5,4,3,2,1,0,-1,-2},1,9); 
                if (ILMath.sum(ILMath.norm(Res - A.T)) > 1e-10)
                    throw new Exception ("Test_vector: invalid values detected!"); 

                Success("Test_vector successfull.");
            }catch(Exception e) {
                Error("Test_vector failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_linspace() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILMath.linspace(20.2,3.2,-1); 
                ILArray <double> Res = new ILArray<double>(3.2); 
                if (!Res.Equals(A))
                    throw new Exception ("Test_linspace: invalid values detected!"); 
                if (!Res.Equals(ILMath.linspace(20.2,3.2,0)))
                    throw new Exception ("Test_linspace: invalid values detected!"); 
                if (!Res.Equals(ILMath.linspace(20.2,3.2,1)))
                    throw new Exception ("Test_linspace: invalid values detected!"); 
                errorCode = 1; 
                A = ILMath.linspace(20.2,3.2,6);  
                Res = new ILArray<double>(new double[]{20.20000,   16.80000,   13.40000,   10.00000,   6.60000,   3.20000}); 
                if (ILMath.norm(A - Res) > ILMath.MachineParameterDouble.eps * 10)
                    throw new Exception ("Test_linspace: invalid values detected!"); 
                errorCode = 2; 
                A = ILMath.linspace(20.2,3.2);
                if (A.Length != 100)
                    throw new ILArgumentException("linspace (start,end) should return 100 elements"); 
                Success();
            }catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
 
        
        public void Test_Basic() {
            int errorCode = 0;
            try {
                ILArray<double> D = 0.3;
                ILArray<float> F = new ILArray<float>(new float[1] { 0.3F }, 1, 1);
                ILArray<complex> DC = new ILArray<complex>(new complex[1] { 
                                        new complex(0.3, 0.3) }, 1, 1);
                ILArray<fcomplex> FC = new ILArray<fcomplex>(new fcomplex[1] { 
                                        new fcomplex(0.300000011920929F, 0.300000011920929F) }, 1, 1);
                ILArray<double> RD = 1.2661036727795;
                ILArray<float> RF = new ILArray<float>(new float[1] { 1.2661036727795F }, 1, 1);
                ILArray<complex> RDC = new ILArray<complex>(new complex[1] { 
                                        new complex(1.2804390679875, -0.308203530781578) }, 1, 1);
                ILArray<fcomplex> RFC = new ILArray<fcomplex>(new fcomplex[1] { 
                                        new fcomplex(0.300000011920929F,0.300000011920929F) }, 1, 1);

                if (ILMath.norm(ILMath.acos(D) - RD) > 1e-10)
                    throw new Exception("wrong values detected!");
                //if (ILMath.norm(ILMath.acos(F) - RF) > 1e-10)
                //    throw new Exception("wrong values detected!");
                //if (ILMath.norm(ILMath.acos(DC) - RDC) > 1e-10)
                //    throw new Exception("wrong values detected!");
                //if (ILMath.norm(ILMath.acos(FC) - RFC) > 1e-10)
                //    throw new Exception("wrong values detected!");
                Success("Test_Basic successfull");
            } catch (Exception e) {
                Error("Test_Basic failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_Max() {
            int errorCode = 0;
            try {
                ILArray<double> A = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 6, 4);
                ILArray<double> B = ILMath.ones(6, 4);

                ILArray<double> Res = new ILArray<double>(new double[24] {5,5,5,5,5,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 6, 4);
                ILArray<double> C;
                C = ILMath.max(A, B + 4);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Max: Wrong results 'Max(A, B+4)'");

                Res = new ILArray<double>(new double[6] { 18,19,20,21,22,23 }, 6, 1);
                // matlab: min(a,[],2)
                ILArray<double> dummy = ILArray<double>.empty(); 
                C = ILMath.max(A,ref dummy, 1);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Max: Wrong results 'Max(A, 1)'");

                Res = new ILArray<double>(new double[4] { 8,14,20,26 }, 1, 4);
                C = ILMath.max(A + 3);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Max: Wrong results 'Max(A + 3)'");

                Res = new ILArray<double>(new double[24] {2,2,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 6, 4);
                C = ILMath.max(A, 2.0);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Max: Wrong results 'Max(A, 2.0)'");

                A = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 2,3,4);
                A = A.T;
                Res = new ILArray<double>(new double[6] {18,20,22,19,21,23}, 3,1,2);
                if (!ILMath.Equals(ILMath.max(A,ref dummy,1), Res))
                    throw new Exception("ILMath.Max: Wrong results 'Max(A,[], 2)' (A == Ref)");
                
                Success("Test_Max successfull");
            } catch (Exception e) {
                Error("Test_Max failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_Min() {
            int errorCode = 0;
            try {
                ILArray<double> A = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 6, 4);
                ILArray<double> B = ILMath.ones(6, 4);

                ILArray<double> Res = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,15,15,15,15,15,15,15,15}, 6, 4);
                ILArray<double> C;
                C = ILMath.min(A, B+14);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Min: Wrong results 'Min(A, B+14)'");

                Res = new ILArray<double>(new double[6] {0,1,2,3,4,5}, 6, 1);
                // matlab: min(a,[],2)
                ILArray<double> dummy = null; 
                C = ILMath.min(A, ref dummy, 1);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Min: Wrong results 'Min(A, 1)'");

                Res = new ILArray<double>(new double[4] {3,9,15,21 }, 1, 4);
                C = ILMath.min(A + 3);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Min: Wrong results 'Min(A + 3)'");

                Res = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,20,20,20}, 6, 4);
                C = ILMath.min(A, 20.0);
                if (!ILMath.Equals(C, Res))
                    throw new Exception("ILMath.Min: Wrong results 'Min(A, 20.0)'");

                Success("Test_Min successfull");
            } catch (Exception e) {
                Error("Test_Min failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_Repmat() {
            int errorCode = 0;
            try {
                ILArray<double> A = new ILArray<double>(new double[24] {0,1,2,3,4,5,6,7,8,9
                                                ,10,11,12,13,14,15,16,17,18,19,20,21,22,23}, 6, 4);
                ILArray<double> B = A.Repmat(1, 1);

                Info("Test_Repmat needs to be implemented!");

                Success("Test_Repmat successfull");
            } catch (Exception e) {
                Error("Test_Repmat failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }

        }

		public void Test_Apply() {
			int errorCode = 0;
			try {
				double[] data = new double [24];
				for (int i = 0; i < data.Length; i++)
					data[i] = i; 
				ILArray<double> A = new ILArray<double>(data, 2, 3, 4);
				ILArray<double> B = (ILArray<double>)A[1,"1,1;2,1,0;2:end"]; 
				ILArray<double> Res = new ILArray<double>(new double[24] {
				0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
				}, 2, 3, 4);
				// apply on physical storage
				ILArray<double> C = ILMath.ceil(ILMath.tanh(A) - 0.5); 
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Apply result! ");

				// apply on reference arbitrary storage
				errorCode = 1; 
				Res = new ILArray<double>(new double[12] {
				 -1,0,0,-1,0,0,-1,0,0,-1,0,0
				}, 3, 2, 2);
				C = ILMath.floor(ILMath.sin(B));
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Apply result! ");

				// apply on row reference vector 
				errorCode = 2;
				B.MinimumRefDimensions = 2; 
				C = (ILArray<double>) B["1,1;0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"+
				"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0;0"];
				C = ILMath.pow(C, 2.3); 
				Res = ILMath.ones(2, 36) * 507.00226068959716;
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Apply result! ");

				// apply on column reference vector 
				errorCode = 3; 
				C = (ILArray<double>)B[1,"1,1;0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"+
				"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0;0"];
				C = ILMath.sqrt(C) + 2.4432112354;       
				Res = ILMath.ones(36, 2) * 6.3161945816074176;
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Apply result! ");

				// apply large array -> performance test
				errorCode = 4; 
				ILPerformer p = new ILPerformer();
				A = ILMath.ones(1000, 1000, 10);
				long durationsMath = 0;
				ILPerformer p2 = new ILPerformer(); 
				long durationsGC = 0;
				int cycles = 20; p2.Tic();
				for (int i = 0; i < cycles; i++) {
					durationsGC += p.Duration;
                    p.Tic();
						A = A + 3.4;
					p.Toc();
					durationsMath += p.Duration;

					p.Tic();
						System.GC.Collect();
					p.Toc(); 
				}
				p2.Toc(); 
				durationsMath /= cycles;
				durationsGC /= cycles;
				Info("Apply(1000x1000x10)[Phy] needed: " + durationsMath.ToString() +"/GC: "+ durationsGC.ToString() + "/All: " +p2.Duration.ToString());

				errorCode = 5;
				durationsMath = 0;
				durationsGC = 0;
				cycles = 20;
				A = (ILArray<double>)A.T;
				p2.Tic();
				for (int i = 0; i < cycles; i++) {
					p.Tic();
					B = A + 3.4;
					p.Toc();
					durationsMath += p.Duration;

					p.Tic();
					System.GC.Collect();
					p.Toc();
					durationsGC += p.Duration;
				}
				p2.Toc();
				durationsMath /= cycles;
				durationsGC /= cycles;
				Info("Apply(1000x1000x10)[Ref] needed: " + durationsMath.ToString() + "/GC: " + durationsGC.ToString() + "/All: " +p2.Duration.ToString());
				 
				Success();
            } catch (Exception e) {
				Error(errorCode, e.Message);
            }
		}
		public void Test_Relop() {
            int errorCode = 0;
            try {
                
				byte[] data = new byte[120];
				for (int i = 0; i < data.Length; i++)
					data[i] = (i % 2 == 1) ? (byte)1 : (byte)0;
 				ILLogicalArray A = new ILLogicalArray(data, 6, 5, 4);
				double[] data2 = new double[120];
				for (int i = 0; i < data.Length; i++)
					data2[i] = (i % 2) ;
				ILArray<double> B = new ILArray<double>(data2,6,5,4);
				ILArray<double> C = ILMath.ones(6,5,4); 
				ILLogicalArray Res = ILMath.eq(B,C);
				if (!A.Equals(Res))
					throw new Exception("Invalid result values!");
				errorCode = 1;
				B = ILMath.ones(1000, 1000, 10);
				C = ILMath.zeros(1000, 1000, 10);
				ILPerformer pEq = new ILPerformer();
				ILPerformer pAll = new ILPerformer();
				long durationGC = 0, durationEq = 0;
				int cycles = 20; 
				pAll.Tic(); 
				for (int i = 0; i < cycles; i++) {
					pEq.Tic(); 
					Res = B == C;
					pEq.Toc();
					durationEq += pEq.Duration;

					pEq.Tic();
					//System.GC.Collect();
					pEq.Toc();
					durationGC += pEq.Duration; 
				}
				pAll.Toc(); 
				durationEq /= cycles;
				durationGC /= cycles;
				Info("Test Eq[ual] phys. Arrays: [1000 x 1000 x 10] needed :" + durationEq + " /GC: "
							+ durationGC + " /All: " + pAll.Duration);

				errorCode = 3;
				B = (ILArray<double>)B[1,"0:end;0:end;0:end"];
				C = (ILArray<double>)C.T;
				durationGC = 0; durationEq = 0;
				cycles = 3;
				pAll.Tic();
				for (int i = 0; i < cycles; i++) {
					pEq.Tic();
					Res = B == C;
					pEq.Toc();
					durationEq += pEq.Duration;

					pEq.Tic();
					//System.GC.Collect();
					pEq.Toc();
					durationGC += pEq.Duration;
				}
				pAll.Toc();
				durationEq /= cycles;
				durationGC /= cycles;
				Info("Test Eq[ual] Ref. Arrays: [1000 x 1000 x 10] needed :" + durationEq + " /GC: "
							+ durationGC + " /All: " + pAll.Duration); 

				/*if (S.Dimensions.NonSingletonDimensions != 2)
					throw new Exception("Wrong size of Sum result! ");
				if (S.Dimensions.NumberOfDimensions != 3)
					throw new Exception("Wrong size of Sum result! ");
				if (S.Dimensions[0] != 1)
					throw new Exception("Wrong size of leading Dimension of Sum result! ");
				if (S.Dimensions[1] != 5)
					throw new Exception("Wrong size of 2. Dimension of Sum result! ");
				if (S.Dimensions[2] != 4)
					throw new Exception("Wrong size of 3. Dimension of Sum result! ");
				if (S.Dimensions.NumberOfElements != 20)
					throw new Exception("Wrong number of elements of Sum result! ");
				if (! Res.Equals(S))
					throw new Exception("Wrong values of Sum result! ");

				ILArray<double> B = (ILArray<double>)A["1:end;1:end;2", 1];
				double [] data2 = new double[4] { 350,380,410,440 };
				Res = new ILArray<double>(data2, 4, 1); 
				if (!Res.Equals(ILMath.Sum(B,1)))
					throw new Exception("Wrong values of Sum result! ");
				
				errorCode = 1;
				ILArray<double> C = new ILArray<double>(data, 1, 1, 4, 5, 6);
				Res = new ILArray<double>(new double[30] {
					10,26,42,58,74,90,106,122,138,154,170,186,202,218,234,250,266
					,282,298,314,330,346,362,378,394,410,426,442,458,474},1,1,1,5,6);
                p.Tic(); 
                S = ILMath.Sum(C,2);
                p.Toc();
                if (!Res.Equals(S)) 
					throw new Exception("Wrong values of Sum result! ");
                Info("Sum(1x1x4x5x6)[phy] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(C);
                p.Toc();
                Info("Sum(1x1x4x5x6)[phy ohne Zuweisung] needed: " + p.ToString());
				
                errorCode = 2;
                C = (ILArray<double>)A.T;
                p.Tic();
                B = ILMath.Sum(C);
                p.Toc();
                Info("Sum(5x4x6)[Ref] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(C);
                p.Toc();
                Info("Sum(5x4x6)[Ref ohne Zuweisung] needed: " + p.ToString());
				
				data = new double[24]{65,215,365,515,70,220,370,520,75,225
					,375,525,80,230,380,530,85,235,385,535,90,240,390,540};
				Res = new ILArray<double>(data,1,4,6);
				if (!Res.Equals(B))
					throw new Exception("Wrong values of Sum result! ");
				
				errorCode = 3; 
				// big array: 
				data = new double[1000 * 1000 * 10]; 
				A = new ILArray<double>(data,1000,1000,10);
                p.Tic();
                C = ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000x1000x10) [phy] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000x1000x10) [phy ohne Zuweisung] needed: " + p.ToString());

				errorCode = 4;
				data = new double[1000 * 1000 * 10];
				A = new ILArray<double>(data, 1000000, 10);
                p.Tic();
                C = ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000000x10) [phy] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000000x10) [phy ohne Zuweisung] needed: " + p.ToString());

				errorCode = 5;
				data = new double[10 * 1000000];
				A = new ILArray<double>(data, 10, 1000000);
                p.Tic();
                C = ILMath.Sum(A);
                p.Toc();
                Info("Sum(10 x 1000000) [Phy] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(A);
                p.Toc();
                Info("Sum(10 x 1000000) [Phy ohne Zuweisung] needed: " + p.ToString());

                errorCode = 6;
				data = new double[1000 * 1000 * 10];
				data[1] = 1.0;
                A = (ILArray<double>)A.T;
                p.Tic();
                C = ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000000 x 10) [Ref] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(A);
                p.Toc();
                Info("Sum(1000000 x 10) [Ref ohne Zuweisung] needed: " + p.ToString());


                errorCode = 7;
                data = new double[120];
                for (int i = 0; i < data.Length; i++)
                    data[i] = i + 1;
                A = new ILArray<double>(data, 6, 5, 4); 
                data = new double[24]{65,70,75,80,85,90,215,220,225,230,235,240,365
                                        ,370,375,380,385,390,515,520,525,530,535,540};
                Res = new ILArray<double>(data, 6, 1, 4);
                p.Tic();
                C = ILMath.Sum(A,1);
                p.Toc();
                Info("Sum(6, 5, 4) [phy, dim 2] needed: " + p.ToString());
                p.Tic();
                ILMath.Sum(A,1);
                p.Toc();
                Info("Sum(6, 5, 4) [phy ohne Zuweisung] needed: " + p.ToString());
                if (!Res.Equals(C))
					throw new Exception("Wrong values of Sum result! ");

				errorCode = 8;
				data = new double[20000000];
				for (int i = 0; i < data.Length; i++)
					data[i] = 2;
				A = new ILArray<double>(data, 20000000);
				Res = new ILArray<double>(new double[1] { 4.0e+07 }, 1);
				p.Tic();
				C = ILMath.Sum(A);
				p.Toc();
				Info("Sum(20000000,1) [phy] needed: " + p.ToString());
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Sum result! ");
				p.Tic();
				ILMath.Sum(A);
				p.Toc();
				Info("Sum(20000000,1) [phy ohne Zuw.] needed: " + p.ToString());

				errorCode = 9;
				ILArray<double>.MinimumRefDimensions = 1;
				A = (ILArray<double>)A.T;
				p.Tic();
				C = ILMath.Sum(A);
				p.Toc();
				Info("Sum(1,20000000) [ref vector] needed: " + p.ToString());
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Sum result! ");
				p.Tic();
				ILMath.Sum(A);
				p.Toc();
				Info("Sum(1,20000000) [ref vector ohne Zuw.] needed: " + p.ToString());
				A = null;
				B = null;
				C = null;
				Res = null; 
*/				System.GC.Collect();
				Success("Test_Relop successfull");
            } catch (SerializationException e) {
				Error("Test_Relop failed at errorCode: " + errorCode + " Reason: " + e.Message);
            } catch (Exception e) {
				Error("Test_Relop failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_Prod() {
            int errorCode = 0;
            try {
                // test vector
                ILArray<double> A = ILMath.ones(1, 4) * 2.0;
                ILArray<double> RefA = A.T.T;
                if (ILMath.prod(A) != 16.0)
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 2;
                if (ILMath.prod(RefA) != 16.0)
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 3;
                RefA = A.T;
                A = ILMath.ones(4, 1) * 2.0;
                if (ILMath.prod(A) != 16.0)
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 4;
                if (ILMath.prod(RefA) != 16.0)
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 5;
                ILArray<double> res = new ILArray<double>(new double[4] { 2.0, 2.0, 2.0, 2.0 }, 4, 1);
                if (!ILMath.prod(A, 1).Equals(res))
                    throw new Exception("Test_prod: Invalid value detected.");
                
                // test matrix 
                errorCode = 6; 
                A = ILMath.ones(3, 4) * 2.0;
                RefA = A.T.T;
                res = new ILArray<double>(new double[4] { 8.0, 8.0, 8.0, 8.0 }, 1,4);
                if (!ILMath.prod(A).Equals(res))
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 7;
                res = new ILArray<double>(new double[4] { 8.0, 8.0, 8.0, 8.0 }, 1, 4);
                if (!ILMath.prod(RefA).Equals(res))
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 8;
                res = new ILArray<double>(new double[3] { 16.0, 16.0, 16.0 }, 3, 1);
                if (!ILMath.prod(A, 1).Equals(res))
                    throw new Exception("Test_prod: Invalid value detected.");

                errorCode = 9;
                if (!ILMath.prod(RefA, 1).Equals(res))
                    throw new Exception("Test_prod: Invalid value detected.");
                Success("Test_Prod successfull");
            } catch (Exception e) {
                Error("Test_Prod failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }

        public void Test_Sum() {
            int errorCode = 0;
            try {
                double[] data = new double[120];
				for (int i = 0; i < data.Length; i++)
					data[i] = i+1;
				ILArray<double> A = new ILArray<double>(data, 6, 5, 4);
				ILArray<double> Res = new ILArray<double>(new double[20] {
					21,57,93,129,165,201,237,273,309,345,381,417,453,489,525,561,597,633,669,705}, 1, 5, 4);
				ILArray<double> S = ILMath.sum(A);
                ILPerformer p = new ILPerformer();
                if (S.Dimensions.NonSingletonDimensions != 2)
					throw new Exception("Wrong size of Sum result! ");
				if (S.Dimensions.NumberOfDimensions != 3)
					throw new Exception("Wrong size of Sum result! ");
				if (S.Dimensions[0] != 1)
					throw new Exception("Wrong size of leading Dimension of Sum result! ");
				if (S.Dimensions[1] != 5)
					throw new Exception("Wrong size of 2. Dimension of Sum result! ");
				if (S.Dimensions[2] != 4)
					throw new Exception("Wrong size of 3. Dimension of Sum result! ");
				if (S.Dimensions.NumberOfElements != 20)
					throw new Exception("Wrong number of elements of Sum result! ");
				if (! Res.Equals(S))
					throw new Exception("Wrong values of Sum result! ");

				ILArray<double> B = (ILArray<double>)A[1,"1:end;1:end;2"];
				double [] data2 = new double[4] { 350,380,410,440 };
				Res = new ILArray<double>(data2, 4, 1); 
				if (!Res.Equals(ILMath.sum(B,1)))
					throw new Exception("Wrong values of Sum result! ");
				
				errorCode = 1;
                // test non-matrix, reference case 
                A = (ILArray<double>)ILMath.counter(4,3,2).CreateReference();
                if (!A.IsReference) 
                    throw new Exception("sum: test data creation failed: A should be reference array!"); 
                Res = new double[,]{{15,18,21,24},{51,54,57,60}};  
                Res = ILMath.reshape(Res ,4,1,2);
                B = ILMath.sum(A,1); 
                if (!Res.Equals(B)) 
                    throw new Exception("sum: invalid result (n-d, reference)"); 

				
                ILArray<double> C = new ILArray<double>(data, 1, 1, 4, 5, 6);
				Res = new ILArray<double>(new double[30] {
					10,26,42,58,74,90,106,122,138,154,170,186,202,218,234,250,266
					,282,298,314,330,346,362,378,394,410,426,442,458,474},1,1,1,5,6);
                p.Tic(); 
                S = ILMath.sum(C,2);
                p.Toc();
                if (!Res.Equals(S)) 
					throw new Exception("Wrong values of Sum result! ");
                Info("Sum(1x1x4x5x6)[phy] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(C);
                p.Toc();
                Info("Sum(1x1x4x5x6)[phy ohne Zuweisung] needed: " + p.ToString());
				
                errorCode = 2;
                C = (ILArray<double>)A.T;
                p.Tic();
                B = ILMath.sum(C);
                p.Toc();
                Info("Sum(5x4x6)[Ref] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(C);
                p.Toc();
                Info("Sum(5x4x6)[Ref ohne Zuweisung] needed: " + p.ToString());
				
				data = new double[8]{15,51,18,54,21,57,24,60};
				Res = new ILArray<double>(data,1,2,4);
				if (!Res.Equals(B))
					throw new Exception("Wrong values of Sum result! ");
				
				errorCode = 3; 
				// big array: 
				data = new double[1000 * 1000 * 10]; 
				A = new ILArray<double>(data,1000,1000,10);
                p.Tic();
                C = ILMath.sum(A);
                p.Toc();
                Info("Sum(1000x1000x10) [phy] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(A);
                p.Toc();
                Info("Sum(1000x1000x10) [phy ohne Zuweisung] needed: " + p.ToString());

				errorCode = 4;
				data = new double[1000 * 1000 * 10];
				A = new ILArray<double>(data, 1000000, 10);
                p.Tic();
                C = ILMath.sum(A);
                p.Toc();
                Info("Sum(1000000x10) [phy] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(A);
                p.Toc();
                Info("Sum(1000000x10) [phy ohne Zuweisung] needed: " + p.ToString());

				errorCode = 5;
				data = new double[10 * 1000000];
				A = new ILArray<double>(data, 10, 1000000);
                p.Tic();
                C = ILMath.sum(A);
                p.Toc();
                Info("Sum(10 x 1000000) [Phy] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(A);
                p.Toc();
                Info("Sum(10 x 1000000) [Phy ohne Zuweisung] needed: " + p.ToString());

                errorCode = 6;
				data = new double[1000 * 1000 * 10];
				data[1] = 1.0;
                A = (ILArray<double>)A.T;
                p.Tic();
                C = ILMath.sum(A);
                p.Toc();
                Info("Sum(1000000 x 10) [Ref] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(A);
                p.Toc();
                Info("Sum(1000000 x 10) [Ref ohne Zuweisung] needed: " + p.ToString());


                errorCode = 7;
                data = new double[120];
                for (int i = 0; i < data.Length; i++)
                    data[i] = i + 1;
                A = new ILArray<double>(data, 6, 5, 4); 
                data = new double[24]{65,70,75,80,85,90,215,220,225,230,235,240,365
                                        ,370,375,380,385,390,515,520,525,530,535,540};
                Res = new ILArray<double>(data, 6, 1, 4);
                p.Tic();
                C = ILMath.sum(A,1);
                p.Toc();
                Info("Sum(6, 5, 4) [phy, dim 2] needed: " + p.ToString());
                p.Tic();
                ILMath.sum(A,1);
                p.Toc();
                Info("Sum(6, 5, 4) [phy ohne Zuweisung] needed: " + p.ToString());
                if (!Res.Equals(C))
					throw new Exception("Wrong values of Sum result! ");

				errorCode = 8;
                //data = new double[20000000];
                //for (int i = 0; i < data.Length; i++)
                //    data[i] = 2;
				A = ILMath.zeros(1,20000000) + 2.0; 
				Res = 4.0e+07;
				p.Tic();
				C = ILMath.sum(A);
				p.Toc();
				Info("Sum(20000000,1) [phy] needed: " + p.ToString());
				if (!Res.Equals(C))
					throw new Exception("Wrong values of Sum result! ");
				p.Tic();
				ILMath.sum(A);
				p.Toc();
				Info("Sum(20000000,1) [phy ohne Zuw.] needed: " + p.ToString());

				errorCode = 9;
                A.MinimumRefDimensions = 2;
				A.Dispose();
				A = new ILArray<double>(ILMemoryPool.Pool.New<double>(20000000),1,20000000).R; 
				p.Tic();
				C = ILMath.sum(A);
				p.Toc();
				Info("Sum(2,10000000) [ref 'vector'] needed: " + p.ToString());
				p.Tic();
				ILMath.sum(A);
				p.Toc();
				Info("Sum(1,20000000) [ref vector ohne Zuw.] needed: " + p.ToString());
				A = null;
				B = null;
				C = null;
				Res = null; 
                errorCode = 10; 
				Success("Test_Sum successfull");
            } catch (SerializationException e) {
				Error("Test_Sum failed at errorCode: "+errorCode +" Reason: " + e.Message);
            } catch (Exception e) {
				Error("Test_Sum failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }
        public void Test_MMult() {
            int errorCode = 0;
            try {
                double[] data = new double[20];
				for (int i = 0; i < data.Length; i++)
					data[i] = i+1;
                ILArray<double> origA = new ILArray<double>(data,5,4); 
				ILArray<double> A = new ILArray<double>(origA);
                ILArray<double> B = new ILArray<double>(origA.T).Detach();

                ILArray<double> Res = new ILArray<double>(new double[] {414,448,482,516,550,448,486,524,562,600,482,524,566,608,650,516,562,608,654,700,550,600,650,700,750} ,5,5); 
                // test phy * phy
                if (!ILMath.Equals (ILMath.multiply(A,B),Res) )
                    throw new Exception ("Test MathBasic: MMult failed at A*B (phys * phys) due: invalid values"); 
                B = new ILArray<double> (origA.T);
                // test phy * ref 
                if (!ILMath.Equals (ILMath.multiply(A,B),Res) )
                    throw new Exception ("Test MathBasic: MMult failed at A*B (phys * ref) due: invalid values"); 
                // test ref * ref 
                A = origA.T.Detach().T; 
                if (!ILMath.Equals (ILMath.multiply(A,B),Res) )
                    throw new Exception ("Test MathBasic: MMult failed at A*B (ref * phys) due: invalid values"); 
                // test ref * phy 
                A = A.Detach(); 
                B = B.Detach(); 
                if (!ILMath.Equals (ILMath.multiply(A,B),Res) )
                    throw new Exception ("Test MathBasic: MMult failed at A*B (ref * ref) due: invalid values"); 
                ILPerformer p = new ILPerformer(); 
                data = new double[1000000];
                A = ILMath.ones(1000,1000); 
                p.Tic(); 
                    B = ILMath.multiply (A,A.T); 
                p.Toc(); 
                Info("MMult 1000x1000 procceeded in " + p.ToString() + "msec.");
                Success("MMult finished successfully"); 
            } catch (Exception e) {
				Error("Test_MMult failed at errorCode: " + errorCode + " Reason: " + e.Message);
            }
        }
		/*		public void Test_Eye() {
					int errorCode = 0;
					try {
						double[] data = new double[24];
						for (int i = 0; i < data.Length; i++)
							data[i] = i;
						ILArray<double> A = new ILArray<double>(data, 2, 3, 4);
						Success("Test_Apply successfull");
					}
					catch (Exception e) {
						Error("Test_Apply failed at errorCode: " + errorCode + " Reason: " + e.Message);
					}
				}
		*/
        public void Test_Cat() {
			int errorCode = 0;
			try {
				double[] data = new double[24];
				for (int i = 0; i < data.Length; i++)
					data[i] = i;
				ILArray<double> A = new ILArray<double>(data, 2, 3, 4);
				ILArray<double> B = A.GetShifted(3);
                ILArray<double> C = ILMath.horzcat(A, A);
                ILArray<double> CRef = ILMath.horzcat(B, B);
                double[] result = new double[48] { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 18, 19, 20, 21, 22, 23 };
                ILArray<double> Result = new ILArray<double>(result, 2, 6, 4);
                if (!Result.Equals(C)) {
                    throw new Exception("Test Cat: Test result failed: invalid values detected."); 
                }
                errorCode = 2; 
                if (!Result.Equals(CRef)) {
                    throw new Exception("Test Cat: Test result failed: invalid values detected."); 
                }
                errorCode = 3; 
                // test vertcat 
                result = new double[72] { 0, 1, 0, 1, 0, 1, 2, 3, 2, 3, 2, 3, 4, 5, 4, 5, 4, 5, 6, 7, 6, 7, 6, 7, 8, 9, 8, 9, 8, 9, 10, 11, 10, 11, 10, 11, 12, 13, 12, 13, 12, 13, 14, 15, 14, 15, 14, 15, 16, 17, 16, 17, 16, 17, 18, 19, 18, 19, 18, 19, 20, 21, 20, 21, 20, 21, 22, 23, 22, 23, 22, 23 };
                Result = new ILArray<double>(result, 6, 3, 4); 
                C = ILMath.vertcat(A,A,A); 
                if (!Result.Equals(C)) {
                    throw new Exception("Test Cat: Test result failed: invalid values detected."); 
                }
                errorCode = 4; 
                CRef = ILMath.vertcat(B,B,B); 
                if (!Result.Equals(C)) {
                    throw new Exception("Test Cat: Test result failed: invalid values detected."); 
                }
                // test large 
                errorCode = 5; 
                A = (ILArray<double>)ILMath.ones(1000, 1000, 10);
                Result = A.Concat(A, 2); 
                if (Result.m_dimensions.NumberOfDimensions != 3 || Result.m_dimensions[0] != 1000 || Result.m_dimensions[1] != 1000
                    || Result.m_dimensions[2] != 20) {
                    throw new Exception("Test Cat: Result dimension mismatch!");
                }
                ILArray<double> dummy = ILMath.sum(Result); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");
                
                dummy = ILMath.sum(dummy); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");
                
                dummy = ILMath.sum(dummy); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");

                if (ILMath.sum(ILMath.sum(ILMath.sum(Result))) != 20000000) {
                    throw new Exception ("Test Cat: Invalid values detected."); 
                }
                // test Reference Concatenation
                errorCode = 6;
                B = A.GetShifted(3); 
                Result = B.Concat(B,2);
                if (Result.m_dimensions.NumberOfDimensions != 3 || Result.m_dimensions[0] != 1000 || Result.m_dimensions[1] != 1000
                    || Result.m_dimensions[2] != 20) {
                    throw new Exception("Test Cat: Result dimension mismatch!");
                }
                dummy = ILMath.sum(Result); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");
                
                dummy = ILMath.sum(dummy); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");
                
                dummy = ILMath.sum(dummy); 
                if (ILMath.sumall(dummy)!= 20000000) 
                    throw new Exception("sum partially wrong!");
                
                if (ILMath.sum(ILMath.sum(ILMath.sum(Result))) != 20000000) {
                    throw new Exception ("Test Cat: Invalid values detected."); 
                }
                Success("Test_Cat successfull");
			} catch (Exception e) {
                Error("Test_Cat failed at errorCode: " + errorCode + " Reason: " + e.Message);
			}
		}

        public void Test_horzcat() {
			int errorCode = 0;
			try {

                ILArray<double> A = ILMath.counter(3, 4);
				ILArray<double> B = ILMath.counter(3, 6);
                ILArray<double> C = ILMath.horzcat(A, B);
                ILArray<double> CRef = ILMath.horzcat(A.R, B.R, A.R, A.C);
                CRef = ILMath.horzcat(A.C, B.R);
                CRef = ILMath.horzcat(A.R, B.C);
                ILArray<double> Result = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18},3,4+6); 
                if (!C.Equals(Result)) 
                    throw new Exception("Test horzcat: invalid result"); 
                Success();
			} catch (Exception e) {
                Error("errorCode: " + errorCode + " Reason: " + e.Message);
			}
		}
        
        public void Test_Find() {
			int errorCode = 0;
			try {
				double[] data = new double[24];
				for (int i = 0; i < data.Length; i++)
					data[i] = i;
				ILArray<double> A = new ILArray<double>(data, 2, 3, 4);
                ILArray<double> B = null; 
				ILArray<double> Res = A[ILMath.find(A > 10)];
                // test emtpy 
                Res = A[ILMath.find(A > 50)];
                if (!Res.IsEmpty) 
					Error("Test_Find: empty index array should throw an exception! "); 
                errorCode = 1; 
                ILArray<double> ResI = new ILArray<double>(new double[12] {0,2,4,6,8,10,12,14,16,18,20,22},1,12);
                ILArray<double> ResR = ILMath.zeros(1,12); 
                ILArray<double> ResC = new ILArray<double>(new double[12] {0,1,2,3,4,5,6,7,8,9,10,11},1,12);
                ILArray<byte> ResV = new ILArray<byte>(new byte[12] {1,1,1,1,1,1,1,1,1,1,1,1},1,12);

                // Test physical storage forward, no limit
                ILArray<double> Rows = ILMath.empty(); 
                ILArray<double> Cols = ILMath.empty(); 
                ILArray<byte> Vals = ILArray<byte>.empty(); 
                Rows = ILMath.find(A/2 == ILMath.round(A/2)); 
                if (!Rows.Equals(ResI)) 
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2)); A - physical");
                Rows = ILMath.find(A/2 == ILMath.round(A/2),2);
                if (!Rows.Equals(ResI["0;0,1"]))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),2); A - physical");
                Rows = ILMath.find(A/2 == ILMath.round(A/2),-2);
                if (!Rows.Equals(ResI["0;10:end"]))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),-2); A - physical");
                // Test physical, backward, no limit
                Rows = ILMath.find(A/2 == ILMath.round(A/2),-200);
                if (!Rows.Equals(ResI))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),-200); A - physical");
                Rows = ILMath.find(A/2 == ILMath.round(A/2),0,ref Cols, ref Vals); 
                if (!Rows.Equals(ResR) || !Cols.Equals(ResC) || ILMath.find(Vals != ResV.T).Length > 0)
                    throw new Exception ("Invalid values: [r,c,v] = Find(A/2 == ILMath.round(A/2),-200); A - physical");
                Rows = ILMath.find(A/2 == ILMath.round(A/2),-3,ref Cols, ref Vals); 
                if (!Rows.Equals(ResR["0;9,10,11"]) || !Cols.Equals(ResC["0;9,10,11"]) || !Vals.Equals(ResV["0;9,10,11"]))
                    throw new Exception ("Invalid values: [r,c,v] = Find(A/2 == ILMath.round(A/2),-3); A - physical");
                // Test reference storage, forward, no limit
                errorCode = 2; 

                ILLogicalArray A1 = (A/2 == ILMath.round(A/2));
                A1 = A1.GetShifted(3);
                Rows = ILMath.find(A1); 
                if (!Rows.Equals(ResI)) 
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2)); A - reference");
                Rows = ILMath.find(A1,2);
                if (!Rows.Equals(ResI["0;0,1"]))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),2); A - reference");
                Rows = ILMath.find(A1,-2);
                if (!Rows.Equals(ResI["0;10:end"]))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),-2); A - reference");
                // Test physical, backward, no limit
                Rows = ILMath.find(A1,-200);
                if (!Rows.Equals(ResI))
                    throw new Exception ("Invalid values: Find(A/2 == ILMath.round(A/2),-200); A - reference");
                Rows = ILMath.find(A1,0,ref Cols, ref Vals); 
                if (!Rows.Equals(ResR) || !Cols.Equals(ResC) || ILMath.find(Vals != ResV.T).Length > 0)
                    throw new Exception ("Invalid values: [r,c,v] = Find(A/2 == ILMath.round(A/2),-200); A - reference");
                Rows = ILMath.find(A1,-3,ref Cols, ref Vals); 
                if (!Rows.Equals(ResR["0;9,10,11"]) || !Cols.Equals(ResC["0;9,10,11"]) || !Vals.Equals(ResV["0;9,10,11"]))
                    throw new Exception ("Invalid values: [r,c,v] = Find(A/2 == ILMath.round(A/2),-3); A - reference");

                errorCode = 3;
                float[] data2 = new float[24];
                for (int i = 0; i < data2.Length; i++)
					data2[i] = (float)(i%2.0f);
                ResI = new ILArray<double>(new double[4]{18,20,22,24},4,1) - 1.0; 
                ILArray<float> A2 = new ILArray<float>(data2,2,3,4);
                Rows = ILMath.find(A2,-4);
                if (!Rows.Equals(ResI))
                    throw new Exception ("Invalid values: Find(A2,-4); A - phys., float");

                errorCode = 4; 
                // test large 
                A = ILMath.ones(500, 500, 10);
                A["200:300;200:300;0:end"] = (ILArray<double>)0.0;
                A = A["0:end;0:end;0:end"];
                ILLogicalArray L = A != 0; 
                ILPerformer p = new ILPerformer();
                // Matlab Code: 
                // a = ones(1000,1000,10); a(200:300,200:300,:) = 0; tic; b = a(find(a~=0)); toc; 
                Info("Test_Find (testing performance please wait...) ");
                int cycles = 20;
                long duration = 0;
                for (int i = 0; i < cycles; i++) {
                    p.Tic();
                    B = ILMath.find(L); 
                    p.Toc();
                    duration += p.Duration;
                    //System.GC.Collect();
                }
                duration /= cycles;
                Info("Test_Find [500,500,10] " + (L.IsReference ? "Ref: " : "Phy: ") + "'B = Find(A != 0)' avg. needed: " + p.ToString() + " ms");

                errorCode = 5; 
                cycles = 4;
                duration = 0;
                L = L["0:end;0:end;0:end"]; 
                for (int i = 0; i < cycles; i++) {
                    p.Tic();
                    B = ILMath.find(L);
                    p.Toc();
                    duration += p.Duration;
                    System.GC.Collect(); 
                }
                duration /= cycles;
                Info("Test_Find [500,500,10] " + (L.IsReference ? "Ref: " : "Phy: ") + "'B = Find(L)' avg. needed: " + p.ToString() + " ms");

                errorCode = 6; 
                // value ok? 
                if (ILMath.sum(ILMath.sum(B)) != 2997460747500)
                    throw new Exception("TEst_Find: wrong value of result!"); 

				Success();
			} catch (Exception e) {
				Error(errorCode, e.Message);
			}
		}
		public void Test_Eye() {
			int errorCode = 0;
			try {
				ILArray<double> A = ILMath.eye(7, 4);
				double[] data = new double[28];
				for (int i = 0; i < data.Length; i += 8)
					data[i] = 1;
				ILArray<double> Res = new ILArray<double>(data, 7, 4);
				if (!Res.Equals(A))
					throw new Exception("Invalid value result: Eye should give diagonal matrix.");
				Success("Test_Eye successfull");
			}
			catch (Exception e) {
				Error("Test_Eye failed at errorCode: " + errorCode + " Reason: " + e.Message);
			}
		}
	}
}
