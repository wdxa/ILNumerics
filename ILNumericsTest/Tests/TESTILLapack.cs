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
using ILNumerics.Native;
using ILNumerics;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Test {
    public class TESTILLapack : ILTest {
        public override void Run() {
            base.Run();
            Header();
            Test_Temp();
            Test_PINV();
            Test_slashUpperTriag(); 
            Test_slashQRRankDeficient();
            Test_det(); 
            Test_slashQRSpecialShapes(); 
            Test_slash_mNEQn(ILMath.counter(1.0,1.0,1,5),ILMath.counter(1.0,2.0,1,4), 1e-4); 
            Test_slash_mNEQn(ILMath.counter(1.0,1.0,5,1),new ILArray<double>(new double[]{1,2,3,4,5,10,20,30,40,50,20,40,60,80,100,200,400,600,800,1000},5,4), 1e-3); 
            Test_slash_mNEQn(ILMath.counter(4,10),ILMath.counter(3.0,2.0,4,15), 1e-3); 
            Test_slash_mNEQn(ILMath.counter(10,4),ILMath.counter(3.0,2.0,10,5), 1e-4); 
            Test_slash(new ILArray<double>(new double[]{1,1,1,1,1,2,3,4,1,3,6,10,1,4,10,20},4,4),new ILArray<double>(new double[]{1,2,3,4,5,6,7,8},4,2),MatrixProperties.Square,1e-6); 
            Test_slash(ILMath.rand(150,150),ILMath.rand(150,100),MatrixProperties.Square,1e-2); 
            Test_slashMatrProp(); 
            Test_eigNonSymm(ILMath.counter(4,4),1e-4,true);
            Test_eigNonSymm(ILMath.counter(4,4),1e-4,false);
            // test complex eigenvalues / -vectors
            Test_eigNonSymm(new ILArray<double> (new double[]{0.304617,  0.189654,  0.193431,  0.682223,  0.302764,  0.541674,  0.150873,  0.697898,  0.378373,  0.860012,  0.853655,  0.593563,  0.496552,  0.899769,  0.821629,   0.64491},4,4),1e-4,false);
            Test_eigNonSymm(ILMath.randn(4),1e-4,true);
            Test_eigNonSymm(ILMath.randn(0),1e-4,false);
            Test_eigNonSymm(ILMath.randn(1),1e-4,false);
            Test_eigNonSymm(ILMath.randn(2),1e-4,false);
            Test_eigSymmRangeVal(new ILArray<double>(new double[]{1, 2, 3, 4, 2, 3, 5, 7, 3, 5, 6, 9, 4, 7, 9, 10},4,4),1e-4,-1.0,3.0);
            Test_eigSymmRangeIdx(new ILArray<double>(new double[]{1, 2, 3, 4, 2, 3, 5, 7, 3, 5, 6, 9, 4, 7, 9, 10},4,4),1e-4,1,3);
            Test_eigSymmFull(new ILArray<double>(new double[]{1, 2, 3, 4, 2, 3, 5, 7, 3, 5, 6, 9, 4, 7, 9, 10},4,4),1e-4);
            Test_eigSymmGeneralized(); 
            Test_QR_QR(ILMath.counter(5,4),1e-5); 
            Test_QR_QR(ILMath.counter(5,5),1e-5); 
            Test_QR_QR(ILMath.counter(4,5),1e-5); 
            Test_QR_QR(ILArray<double>.empty(),1e-5); 
            Test_QR_QRecoSize(ILMath.counter(5,4),1e-5); 
            Test_QR_QRecoSize(ILMath.counter(5,5),1e-5); 
            Test_QR_QRecoSize(ILMath.counter(4,5),1e-5); 
            Test_QR_QRecoSize(ILArray<double>.empty(),1e-6); 
            Test_QR_QREecoSize(ILMath.counter(5,4),1e-5); 
            Test_QR_QREecoSize(ILMath.counter(5,5),1e-5); 
            Test_QR_QREecoSize(ILMath.counter(4,5),1e-5); 
            Test_QR_QREecoSize(ILArray<double>.empty(),1e-6); 
            Test_QR_rawLapackForm(); 
            Test_QR_QRE(ILMath.counter(5,4),1e-5); 
            Test_QR_QRE(ILMath.counter(5,5),1e-5); 
            Test_QR_QRE(ILMath.counter(4,5),1e-5); 
            Test_QR_QR(ILArray<double>.empty(),1e-5); 
            Test_LU_rawLapackForm(); 
            Test_LU_retLU(); 
            Test_LU_retLUP(); 
            Test_SVD();
            Test_CholNonPosDef(); 
            Test_CholPosDef(); 
            Footer();
        }

        private void Test_Temp() {
            int errorCode = 0; 
            try {
                ILArray<complex> A = new ILArray<complex>(3, 3);

                A[0, 0] = new complex(0.1, 0);
                A[0, 1] = new complex();
                A[0, 2] = new complex();

                A[1, 0] = new complex(0, 0);
                A[1, 1] = new complex(0.1, 0);
                A[1, 2] = new complex(-0.1, 0);

                A[2, 0] = new complex(0, 0);
                A[2, 1] = new complex(-0.1, 0);
                A[2, 2] = new complex(0.1, 0);

                Console.WriteLine("{0}", A);

                ILArray<complex> b = new complex[]{ new complex(0.1, 0), new complex(-0.1, 0), new complex(0.1, 0) };
                b[0] = new complex(0.1, 0);
                b[1] = new complex(-0.1, 0);
                b[2] = new complex(0.1, 0);

                Console.WriteLine(b);

                ILArray<complex> x;
                x = ILMath.linsolve(A, b.T);
                Console.WriteLine("LinSolve Diretto:\n",x.ToString()); //<---------- ERROR!!!

                //Can you help me?
                //Is this the best way to solve this kind of system? If I don't use Linsolve but I try:

                ILArray<complex> Q;
                ILArray<complex> R = new ILArray<complex>(3, 3);
                Q = ILMath.qr(A, ref R, true);
                x=ILMath.linsolve(R, ILMath.multiply(Q.T, b.T));

                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }


        private void Test_slashUpperTriag() {
            int errorCode = 0; 
            try {
                // construct 4 x 4 matrix, upper triagonal
                ILArray<double> A = ILMath.zeros(4,4); 
                A["0;:"] = new double[]{1.0,2.0,3.0,4.0}; 
                A["1;:"] = new double[]{0.0,2.0,3.0,4.0};
                A["2;:"] = new double[]{0.0,0.0,3.0,4.0};
                A["3;:"] = new double[]{0.0,0.0,0.0,4.0};
                
                // now construct a right side and solve the equations: 
                ILArray<double> B = new double[] {1.0,2.0,3.0,4.0}; 
                ILArray<double> x = ILMath.linsolve(A,B.T); 
                ILArray<double> bTest = ILMath.multiply(A,x);
                ILArray<double> err = ILMath.norm(bTest - B.T);
                if (err > ILMath.MachineParameterDouble.eps) throw new Exception("invalid results!");
                Success();
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_slashMatrProp() {
            int errorCode = 0; 
            try {
                
                // construct 4 x 4 matrix, symmetric, positiv definite
                ILArray<double> A = ILMath.randn(4,4);
                A = A + A.T;                  // <- construct symmetry
                A.Diagonal = ILMath.abs(A.Diagonal * 100); // <- construct pos.def.
                
                // now construct a right side and solve the equations: 
                ILArray<double> B = new double[] {1.0,2.0,3.0,4.0}; 
                MatrixProperties prop = new MatrixProperties(); 
                prop |= MatrixProperties.Hermitian; 
                prop |= MatrixProperties.PositivDefinite; 
                ILArray<double> x = ILMath.linsolve(A,B.T,ref prop); 
                //[test: if A was not symm.,pos.def. linsolve returnes null]
                System.Diagnostics.Debug.Assert(!Object.Equals(x,null)); 
                ILArray<double> bTest = ILMath.multiply(A,x);
                ILArray<double> err = ILMath.norm(bTest - B.T); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_eigNonSymm(ILArray<double> A,double tol, bool bal) {
            int errorCode = 0; 
            try {
                MatrixProperties props = MatrixProperties.None; 
                ILArray<complex> V = null;  
                ILArray<complex> res1 = ILMath.eig(A,ref V, ref props, bal);
                V = ILArray<complex>.empty();  
                ILArray<complex> res2 = ILMath.eig(A,ref V, ref props, bal);
                if (!A.IsEmpty) {
                    if (!res1.Equals(ILMath.diag(res2))) 
                        throw new ILArgumentException ("eig.values differ betw. e = eig(A) and [e,v] = eig(A)! - (double)"); 
                    if (ILMath.norm(V)< tol || ILMath.norm(res1) < tol) 
                        throw new Exception("result too small! trivial solution? (double)");
                    if (ILMath.norm(ILMath.multiply(ILMath.tocomplex(A),V) - ILMath.multiply(V,res2)) > tol)
                        throw new ILArgumentException("wrong result detected (double)");
                    V.Dispose(); V = null; 
                }

                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<fcomplex> Vf = null;  
                ILArray<fcomplex> res1f = ILMath.eig(Af,ref Vf, ref props, bal);
                Vf = ILArray<fcomplex>.empty();  
                ILArray<fcomplex> res2f = ILMath.eig(Af,ref Vf, ref props, bal);
                if (!A.IsEmpty) {
                    if (!res1f.Equals(ILMath.diag(res2f))) 
                        throw new ILArgumentException ("eig.values differ betw. e = eig(A) and [e,v] = eig(A)! - (float)"); 
                    if (ILMath.norm(Vf)< tol || ILMath.norm(res1f) < tol) 
                        throw new Exception("result too small! trivial solution? (float)");
                    if (ILMath.norm(ILMath.multiply(ILMath.tofcomplex(Af),Vf) - ILMath.multiply(Vf,res2f)) > tol)
                        throw new ILArgumentException("wrong result detected (float)");
                    Vf.Dispose(); Vf = null; 
                }
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> Vfc = null;  
                ILArray<fcomplex> res1fc = ILMath.eig(Afc,ref Vfc, ref props, bal);
                Vfc = ILArray<fcomplex>.empty();  
                ILArray<fcomplex> res2fc = ILMath.eig(Afc,ref Vfc, ref props, bal);
                if (!A.IsEmpty) {
                    if (!res1fc.Equals(ILMath.diag(res2fc))) 
                        throw new ILArgumentException ("eig.values differ betw. e = eig(A) and [e,v] = eig(A)! - (fcomplex)"); 
                    if (ILMath.norm(Vfc)< tol || ILMath.norm(res1fc) < tol) 
                        throw new Exception("result too small! trivial solution? (fcomplex)");
                    if (ILMath.norm(ILMath.multiply(ILMath.tofcomplex(Afc),Vfc) - ILMath.multiply(Vfc,res2fc)) > tol)
                        throw new ILArgumentException("wrong result detected (fcomplex)");
                    Vfc.Dispose(); Vfc = null; 
                }
                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> Vc = null;  
                ILArray<complex> res1c = ILMath.eig(Ac,ref Vc, ref props, bal);
                Vc = ILArray<complex>.empty();  
                ILArray<complex> res2c = ILMath.eig(Ac,ref Vc, ref props, bal);
                if (!A.IsEmpty) {
                    if (!res1c.Equals(ILMath.diag(res2c))) 
                        throw new ILArgumentException ("eig.values differ betw. e = eig(A) and [e,v] = eig(A)! - (complex)"); 
                    if (ILMath.norm(Vc)< tol || ILMath.norm(res1c) < tol) 
                        throw new Exception("result too small! trivial solution? (complex)");
                    if (ILMath.norm(ILMath.multiply(ILMath.tocomplex(Ac),Vc) - ILMath.multiply(Vc,res2c)) > tol)
                        throw new ILArgumentException("wrong result detected (complex)");
                    Vc.Dispose(); Vc = null; 
                }
                Success("(balanced = " + bal + ")"); 
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_eigSymmRangeVal(ILArray<double> A,double tol,double start, double end) {
            int errorCode = 0; 
            try {
                ILArray<double> V = ILArray<double>.empty(); 
                ILArray<double> res = ILMath.eigSymm(A,ref V, start,end);
                if (ILMath.norm(V)< tol || ILMath.norm(res) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < V.Dimensions[1]; i++) {
                    if (ILMath.norm(ILMath.multiply(A,V[null,i]) - V[null,i] * res[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - double"); 
                        }
                }
                V.Dispose(); V = null; 
                if (ILMath.norm(res - ILMath.eigSymm(A,ref V,start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - double"); 

                ILArray<float> Vf = ILArray<float>.empty();
                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> resf = ILMath.eigSymm(Af,ref Vf, (float)start,(float)end); 
                if (ILMath.norm(Vf)< tol || ILMath.norm(resf) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < Vf.Dimensions[1]; i++) {
                    if (ILMath.norm(ILMath.multiply(Af,Vf[null,i]) - Vf[null,i] * resf[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - float"); 
                        }
                }
                Vf.Dispose(); Vf = null; 
                if (ILMath.norm(resf - ILMath.eigSymm(Af,ref Vf,(float)start,(float)end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - float"); 
                ILArray<fcomplex> Vfc = ILArray<fcomplex>.empty();
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> resfc = ILMath.eigSymm(Afc,ref Vfc, (float)start,(float)end); 
                if (ILMath.norm(Vfc)< tol || ILMath.norm(resfc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < Vfc.Dimensions[1]; i++) {
                    if (ILMath.norm(ILMath.multiply(Afc,Vfc[null,i]) - Vfc[null,i] * resfc[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - fcomplex"); 
                        }
                }
                Vfc.Dispose(); Vfc = null; 
                if (ILMath.norm(resfc - ILMath.eigSymm(Afc,ref Vfc,(float)start,(float)end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                ILArray<complex> Vc = ILArray<complex>.empty();
                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> resc = ILMath.eigSymm(Ac,ref Vc, start,end); 
                if (ILMath.norm(Vc)< tol || ILMath.norm(resc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < Vc.Dimensions[1]; i++) {
                    if (ILMath.norm(ILMath.multiply(Ac,Vc[null,i]) - Vc[null,i] * resc[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - complex"); 
                        }
                }
                Vc.Dispose(); Vc = null; 
                if (ILMath.norm(resc - ILMath.eigSymm(Ac,ref Vc, start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_eigSymmRangeIdx(ILArray<double> A,double tol,int start, int end) {
            int errorCode = 0; 
            try {
                ILArray<double> V = ILArray<double>.empty(); 
                ILArray<double> res = ILMath.eigSymm(A,ref V, start,end);
                if (ILMath.norm(V)< tol || ILMath.norm(res) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < end - start + 1; i++) {
                    if (ILMath.norm(ILMath.multiply(A,V[null,i]) - V[null,i] * res[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - double"); 
                        }
                }
                V.Dispose(); V = null; 
                if (ILMath.norm(res - ILMath.eigSymm(A,ref V,start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - double"); 

                ILArray<float> Vf = ILArray<float>.empty();
                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> resf = ILMath.eigSymm(Af,ref Vf, start,end); 
                if (ILMath.norm(Vf)< tol || ILMath.norm(resf) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < end - start + 1; i++) {
                    if (ILMath.norm(ILMath.multiply(Af,Vf[null,i]) - Vf[null,i] * resf[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - float"); 
                        }
                }
                Vf.Dispose(); Vf = null; 
                if (ILMath.norm(resf - ILMath.eigSymm(Af,ref Vf,start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - float"); 
                ILArray<fcomplex> Vfc = ILArray<fcomplex>.empty();
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> resfc = ILMath.eigSymm(Afc,ref Vfc, start,end); 
                if (ILMath.norm(Vfc)< tol || ILMath.norm(resfc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < end - start + 1; i++) {
                    if (ILMath.norm(ILMath.multiply(Afc,Vfc[null,i]) - Vfc[null,i] * resfc[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - fcomplex"); 
                        }
                }
                Vfc.Dispose(); Vfc = null; 
                if (ILMath.norm(resfc - ILMath.eigSymm(Afc,ref Vfc,start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                ILArray<complex> Vc = ILArray<complex>.empty();
                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> resc = ILMath.eigSymm(Ac,ref Vc, start,end); 
                if (ILMath.norm(Vc)< tol || ILMath.norm(resc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                for (int i = 0; i < end - start + 1; i++) {
                    if (ILMath.norm(ILMath.multiply(Ac,Vc[null,i]) - Vc[null,i] * resc[i,i])> tol) { 
                                throw new Exception("invalid values (out of tolerance) - complex"); 
                        }
                }
                Vc.Dispose(); Vc = null; 
                if (ILMath.norm(resc - ILMath.eigSymm(Ac,ref Vc, start,end)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_eigSymmFull(ILArray<double> A,double tol) {
            int errorCode = 0; 
            try {
                ILArray<double> V = ILArray<double>.empty(); 
                ILArray<double> res = ILMath.eigSymm(A,ref V);
                if (ILMath.norm(V)< tol || ILMath.norm(res) < tol) 
                    throw new Exception("result too small! trivial solution?");
                if (ILMath.norm(ILMath.multiply(A,V) - ILMath.multiply(V,res))> tol) { 
                        throw new Exception("invalid values (out of tolerance) - double"); 
                }
                V.Dispose(); V = null; 
                if (ILMath.norm(ILMath.diag(res) - ILMath.eigSymm(A,ref V)) > tol)
                    throw new Exception("invalid values (out of tolerance) - double"); 

                ILArray<float> Vf = ILArray<float>.empty();
                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> resf = ILMath.eigSymm(Af,ref Vf); 
                if (ILMath.norm(Vf)< tol || ILMath.norm(resf) < tol) 
                    throw new Exception("result too small! trivial solution?");
                if (ILMath.norm(ILMath.multiply(Af,Vf) - ILMath.multiply(Vf,resf))> tol) { 
                        throw new Exception("invalid values (out of tolerance) - float"); 
                }
                Vf.Dispose(); Vf = null; 
                if (ILMath.norm(ILMath.diag(resf) - ILMath.eigSymm(Af,ref Vf)) > tol)
                    throw new Exception("invalid values (out of tolerance) - float"); 
                ILArray<fcomplex> Vfc = ILArray<fcomplex>.empty();
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> resfc = ILMath.eigSymm(Afc,ref Vfc); 
                if (ILMath.norm(Vfc)< tol || ILMath.norm(resfc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                if (ILMath.norm(ILMath.multiply(Afc,Vfc) - ILMath.multiply(Vfc,resfc))> tol) { 
                        throw new Exception("invalid values (out of tolerance) - fcomplex"); 
                }
                Vfc.Dispose(); Vfc = null; 
                if (ILMath.norm(ILMath.diag(resfc) - ILMath.eigSymm(Afc,ref Vfc)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                ILArray<complex> Vc = ILArray<complex>.empty();
                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> resc = ILMath.eigSymm(Ac,ref Vc); 
                if (ILMath.norm(Vc)< tol || ILMath.norm(resc) < tol) 
                    throw new Exception("result too small! trivial solution?");
                if (ILMath.norm(ILMath.multiply(Ac,Vc) - ILMath.multiply(Vc,resc))> tol) { 
                        throw new Exception("invalid values (out of tolerance) - complex"); 
                }
                Vc.Dispose(); Vc = null; 
                if (ILMath.norm(ILMath.diag(resc) - ILMath.eigSymm(Ac,ref Vc)) > tol)
                    throw new Exception("invalid values (out of tolerance) - complex"); 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_eigSymmGeneralized() {
            int errorCode = 0; 
            try {
                ILArray<double> A = new double[,]{{1,2,3,4},{5,6,7,8},{8,7,6,5},{5,4,3,1}}; 
                A = (A * A.T) / 2.0; 
                ILArray<double> B = new ILArray<double>(new double[]{9,2,3,4,2,9,4,5,3,4,9,6,4,5,6,9},4,4);
 
                ILArray<double> V = null; 
                ILArray<double> W = ILMath.eigSymm(A,B,ref V,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                // save eigenvalues for later comparison
                ILArray<double> oldEigVals = W.C; 
                V = ILArray<double>.empty(); 
                W = ILMath.eigSymm(A,B,ref V,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                if (ILMath.any((W.Diagonal.T - oldEigVals) > ILMath.MachineParameterDouble.eps * 100)) 
                    throw new Exception("Eigenvalues did not match for 'EV only' <=> 'EV & EVectors'");
                // test for A*V = V*D
                ILArray<double> res = ILMath.multiply(A,V) - ILMath.multiply(B,ILMath.multiply(V,W)); 
                if (ILMath.find(res>ILMath.MachineParameterDouble.eps * 100).Length > 0) 
                    throw new Exception("result should solve for: A*V = V*W"); 
                
                ////////////////// float //////////////////////////////////////////////
                errorCode = 1; 
                ILArray<float> Af = new float[,]{{1f,2f,3f,4f},{5f,6f,7f,8f},{8f,7f,6f,5f},{5f,4f,3f,1f}}; 
                Af = (Af * Af.T) / 2.0f; 
                ILArray<float> Bf = new ILArray<float>(new float[]{9f,2f,3f,4f,2f,9f,4f,5f,3f,4f,9f,6f,4f,5f,6f,9f},4,4);
 
                ILArray<float> Vf = null; 
                ILArray<float> Wf = ILMath.eigSymm(Af,Bf,ref Vf,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                // save eigenvalues for later comparison
                ILArray<float> oldEigValsf = Wf.C; 
                Vf = ILArray<float>.empty(); 
                Wf = ILMath.eigSymm(Af,Bf,ref Vf,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                if (ILMath.any((Wf.Diagonal.T - oldEigValsf) > (double)ILMath.MachineParameterFloat.eps * 100f)) 
                    throw new Exception("Eigenvalues did not match for 'EV only' <=> 'EV & EVectors'");
                // test for A*V = V*D
                ILArray<float> resf = ILMath.multiply(Af,Vf) - ILMath.multiply(Bf,ILMath.multiply(Vf,Wf)); 
                if (ILMath.find(resf> (double)ILMath.MachineParameterFloat.eps * 100f).Length > 0) 
                    throw new Exception("result should solve for: A*V = V*W (float)"); 
                
                ////////////////// fcomplex //////////////////////////////////////////////
                errorCode = 2; 
                ILArray<fcomplex> Afc = ILMath.ccomplex(Af,
                                        new float[,]{{0f,-1f,-2f,3f},{1f,0f,-2.5f,-1f},{2f,2.5f,0f,0.81f},{-3f,1f,-0.81f,0f}}); 
                ILArray<fcomplex> Bfc = ILMath.ccomplex(Bf,
                                        new float[,]{{0f,-5f,-4f,-3f},{5f,0f,-2f,-1f},{4f,2f,0f,1f},{3f,1f,-1f,0f}});
                ILArray<fcomplex> Vfc = null; 
                ILArray<float> Wfc = ILMath.eigSymm(Afc,Bfc,ref Vfc,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                // save eigenvalues for later comparison
                ILArray<float> oldEigValsfc = Wfc.C; 
                Vfc = ILArray<fcomplex>.empty(); 
                Wfc = ILMath.eigSymm(Afc,Bfc,ref Vfc,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                if (ILMath.any((Wfc.Diagonal.T - oldEigValsfc) > (double)ILMath.MachineParameterFloat.eps * 100f)) 
                    throw new Exception("Eigenvalues did not match for 'EV only' <=> 'EV & EVectors'");
                // test for A*V = V*D
                ILArray<fcomplex> resfc = ILMath.multiply(Afc,Vfc) - ILMath.multiply(Bfc,ILMath.multiply(Vfc,ILMath.tofcomplex(Wfc))); 
                if (ILMath.find(resfc> (double)ILMath.MachineParameterFloat.eps * 100f).Length > 0) 
                    throw new Exception("result should solve for: A*V = V*W (float)"); 
                
                ///////////////////////////// complex /////////////////////////////////
                errorCode = 3; 
                ILArray<complex> Ac = ILMath.tocomplex(Afc); 
                ILArray<complex> Bc = ILMath.tocomplex(Bfc);
 
                ILArray<complex> Vc = null; 
                ILArray<double> Wc = ILMath.eigSymm(Ac,Bc,ref Vc,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                // save eigenvalues for later comparison
                ILArray<double> oldEigValsc = Wc.C; 
                Vc = ILArray<complex>.empty(); 
                Wc = ILMath.eigSymm(Ac,Bc,ref Vc,ILMath.GenEigenType.Ax_eq_lambBx,false); 
                if (ILMath.any((Wc.Diagonal.T - oldEigValsc) > (double)ILMath.MachineParameterDouble.eps * 100)) 
                    throw new Exception("Eigenvalues did not match for 'EV only' <=> 'EV & EVectors'");
                // test for A*V = V*D
                ILArray<complex> resc = ILMath.multiply(Ac,Vc) - ILMath.multiply(Bc,ILMath.multiply(Vc,ILMath.tocomplex(Wc))); 
                if (ILMath.find(resc> (double)ILMath.MachineParameterDouble.eps * 100).Length > 0) 
                    throw new Exception("result should solve for: A*V = V*W (float)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }

        private void Test_slashQRSpecialShapes() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILArray<double>.empty(); 
                ILArray<double> B = ILArray<double>.empty(); 
                ILArray<double> Res = ILMath.linsolve(A,B); 
                if (!Res.IsEmpty)
                    throw new Exception("Result should be empty!"); 
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_det() {
            int errorCode = 0; 
            try {
                ILArray<double> A = ILMath.counter(1.0,1.0,4,4);
                A[1] = 0.0;  // makes A nonsingular ..
                A[14] = 0.0; // - '' - 
                if (!ILMath.det(A).Equals(-360.0))
                    throw new Exception("invalid result"); 
                // float 
                errorCode = 2; 
                ILArray<float> Af = ILMath.tosingle(A); 
                if (!ILMath.det(Af).Equals(-360.0f)) 
                    throw new Exception("invalid result: float"); 
                // complex 
                errorCode = 3; 
                ILArray<complex> Ac = ILMath.real2complex(A,A); 
                if (!ILMath.det(Ac).Equals(new complex(1440,0.0))) 
                    throw new Exception("invalid result: complex"); 
                Ac.SetValue(new complex(3,-4.0),0);
                if (ILMath.det(Ac).GetValue(0) - new complex(7.2000e+002, -1.6800e+003) >= 10e-5) {
                    throw new Exception("invalid result: complex (2)"); 
                }
                // fcomplex 
                errorCode = 5; 
                ILArray<fcomplex> Afc = ILMath.real2fcomplex(A,A); 
                if (!ILMath.det(Afc).Equals(new fcomplex(1440.0f,0.0f))) 
                    throw new Exception("invalid result: fcomplex"); 
                // special shapes 
                errorCode = 6; 
                A = ILArray<double>.empty(); 
                try {
                    ILMath.det(A); 
                } catch (ILArgumentException) {
                    Info("det: empty matrix threw exception - ok"); 
                }
                A = -4.70;
                if (!ILMath.det(A).Equals(A)) {
                    throw new Exception("det: scalar double: invalid result");
                }
                Af = -4.70f;
                if (!ILMath.det(Af).Equals(Af)) {
                    throw new Exception("det: scalar float: invalid result");
                }
                Ac = new complex(-4.70,45.0);
                if (!ILMath.det(Ac).Equals(Ac)) {
                    throw new Exception("det: scalar complex: invalid result");
                }
                Afc = new fcomplex(-4.70f,-234.0f); 
                if (!ILMath.det(Afc).Equals(Afc)) {
                    throw new Exception("det: scalar fcomplex: invalid result");
                }
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_slashQRRankDeficient() {
            int errorCode = 0; 
            try {
                double tol = 1e-5;     
                ILArray<double> A = ILMath.zeros(5,4);
                A[":;0"] = 1.0; 
                ILArray<double> B = ILMath.ones(5,10); 
                MatrixProperties props = 0; 
                ILArray<double> Res = ILMath.linsolve(A,B,ref props); 
                if (ILMath.norm(ILMath.multiply(A,Res) - B) > tol) 
                    throw new Exception("result out of tolerance (double)");
                if ((props & MatrixProperties.RankDeficient) == 0) 
                    throw new Exception("linsolve should signal rank deficiency! (double)"); 
                props = MatrixProperties.None; 
                ILArray<float> Af = ILMath.tosingle(A);
                ILArray<float> Bf = ILMath.tosingle(B);
                ILArray<float> retf = ILMath.linsolve (Af,Bf,ref props);
                if (ILMath.norm(ILMath.multiply(Af,retf) - Bf) > tol) 
                    throw new Exception("result out of tolerance (float)");
                if ((props & MatrixProperties.RankDeficient) == 0) 
                    throw new Exception("linsolve should signal rank deficiency! (float)"); 
                props = MatrixProperties.None; 
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A);
                ILArray<fcomplex> Bfc = ILMath.tofcomplex(B);
                ILArray<fcomplex> retFc = ILMath.linsolve (Afc,Bfc,ref props);
                if (ILMath.norm(ILMath.multiply(Afc,retFc) - Bfc) > tol) 
                    throw new Exception("result out of tolerance (fcomplex)");
                if ((props & MatrixProperties.RankDeficient) == 0) 
                    throw new Exception("linsolve should signal rank deficiency! (fcomplex)"); 
                props = MatrixProperties.None; 
                ILArray<complex> Ac = ILMath.tocomplex(A);
                ILArray<complex> Bc = ILMath.tocomplex(B);
                ILArray<complex> retc = ILMath.linsolve (Ac,Bc,ref props);
                if (ILMath.norm(ILMath.multiply(Ac,retc) - Bc) > tol) 
                    throw new Exception("result out of tolerance (complex)");
                if ((props & MatrixProperties.RankDeficient) == 0) 
                    throw new Exception("linsolve should signal rank deficiency! (complex)"); 
                Success("Test_slash_mNEQn: A " + A.Dimensions.ToString() + " * x = B " + B.Dimensions.ToString());
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_slash_mNEQn(ILArray<double> A, ILArray<double> B, double tol) {
            int errorCode = 0; 
            try {
                ILArray<double> ret = ILMath.linsolve (A,B);
                if (ILMath.norm(ILMath.multiply(A,ret) - B) > tol) 
                    throw new Exception("result out of tolerance (double)");
                if (ret.Dimensions[0] != A.Dimensions[1] || ret.Dimensions[1] != B.Dimensions[1])
                    throw new Exception("invalid size of result (double)");
                ILArray<float> Af = ILMath.tosingle(A);
                ILArray<float> Bf = ILMath.tosingle(B);
                ILArray<float> retf = ILMath.linsolve (Af,Bf);
                if (ILMath.norm(ILMath.multiply(Af,retf) - Bf) > tol) 
                    throw new Exception("result out of tolerance (float)");
                if (retf.Dimensions[0] != Af.Dimensions[1] || retf.Dimensions[1] != Bf.Dimensions[1])
                    throw new Exception("invalid size of result (float)");
                ILArray<fcomplex> Afc = ILMath.tofcomplex(A);
                ILArray<fcomplex> Bfc = ILMath.tofcomplex(B);
                ILArray<fcomplex> retFc = ILMath.linsolve (Afc,Bfc);
                if (ILMath.norm(ILMath.multiply(Afc,retFc) - Bfc) > tol) 
                    throw new Exception("result out of tolerance (fcomplex)");
                if (retFc.Dimensions[0] != Afc.Dimensions[1] || retFc.Dimensions[1] != Bfc.Dimensions[1])
                    throw new Exception("invalid size of result (fcomplex)");
                ILArray<complex> Ac = ILMath.tocomplex(A);
                ILArray<complex> Bc = ILMath.tocomplex(B);
                ILArray<complex> retc = ILMath.linsolve (Ac,Bc);
                if (ILMath.norm(ILMath.multiply(Ac,retc) - Bc) > tol) 
                    throw new Exception("result out of tolerance (complex)");
                if (retc.Dimensions[0] != Ac.Dimensions[1] || retc.Dimensions[1] != Bc.Dimensions[1])
                    throw new Exception("invalid size of result (complex)");
                Success("Test_slash_mNEQn: A " + A.Dimensions.ToString() + " * x = B " + B.Dimensions.ToString());
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_slash(ILArray<double> A, ILArray<double> B, MatrixProperties props, double tol) {
            int errorCode = 0; 
            try {
                ILArray<double> Res = ILMath.linsolve(A,B,ref props); 
                if (ILMath.norm(ILMath.multiply(A, Res) - B) > tol)
                    throw new Exception("Test_slash: invalid result (double)");
                ILArray<float> AF = ILMath.tosingle(A); 
                ILArray<float> BF = ILMath.tosingle(B); 
                ILArray<float> ResF = ILMath.linsolve(AF,BF,ref props); 
                if (ILMath.norm(ILMath.multiply(AF, ResF) - BF) > tol)
                    throw new Exception("Test_slash: invalid result (float)");
                ILArray<fcomplex> AFc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> BFc = ILMath.tofcomplex(B); 
                ILArray<fcomplex> ResFc = ILMath.linsolve(AFc,BFc,ref props); 
                if (ILMath.norm(ILMath.multiply(AFc, ResFc) - BFc) > tol)
                    throw new Exception("Test_slash: invalid result (fcomplex)");
                ILArray<complex> AC = ILMath.tocomplex(A); 
                ILArray<complex> BC = ILMath.tocomplex(B); 
                ILArray<complex> ResC = ILMath.linsolve(AC,BC,ref props); 
                if (ILMath.norm(ILMath.multiply(AC, ResC) - BC) > tol)
                    throw new Exception("Test_slash: invalid result (complex)");
                Success("Test_slash: A " + A.Dimensions.ToString() + " * x = B " + B.Dimensions.ToString() + " (" + props.ToString() + ")");
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_QR_QREecoSize(ILArray<double> A,double tol) {
            int errorCode = 0; 
            try {
                if (A.Dimensions[0] < A.Dimensions[1]) {
                    Info("QREecoSize: for matrices m < n, qr(A,ref R,ref E,false) is used!"); 
                    return; 
                }
                ILArray<double> R = ILArray<double>.empty(); 
                ILArray<double> E = ILArray<double>.empty(); 
                ILArray<double> Q = ILMath.qr(A, ref R, ref E, true);
                if (Q.Dimensions[0] != A.Dimensions[0] || Q.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (R.Dimensions[0] != A.Dimensions[1] || R.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (E.Dimensions[0] != 1 || E.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.norm(ILMath.multiply(Q,R) - A[null,E]) > tol).Length > 0) 
                    throw new Exception("values did not match (double)!"); 

                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> Rf = ILArray<float>.empty(); 
                ILArray<float> Ef = ILArray<float>.empty(); 
                ILArray<float> Qf = ILMath.qr(Af,ref Rf, ref Ef, true); 
                if (Qf.Dimensions[0] != A.Dimensions[0] || Qf.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rf.Dimensions[0] != A.Dimensions[1] || Rf.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (Ef.Dimensions[0] != 1 || Ef.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qf,Rf) - Af[null,Ef] > tol).Length > 0) 
                    throw new Exception("values did not match (float)!"); 

                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> Rfc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Efc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Qfc = ILMath.qr(Afc,ref Rfc, ref Efc, true); 
                if (Qfc.Dimensions[0] != A.Dimensions[0] || Qfc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rfc.Dimensions[0] != A.Dimensions[1] || Rfc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (Efc.Dimensions[0] != 1 || Efc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qfc,Rfc) - Afc[null,Efc] > tol).Length > 0) 
                    throw new Exception("values did not match (fcomplex)!"); 

                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> Rc = ILArray<complex>.empty(); 
                ILArray<complex> Ec = ILArray<complex>.empty(); 
                ILArray<complex> Qc = ILMath.qr(Ac, ref Rc, ref Ec, true ); 
                if (Qc.Dimensions[0] != A.Dimensions[0] || Qc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rc.Dimensions[0] != A.Dimensions[1] || Rc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (Ec.Dimensions[0] != 1 || Ec.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qc,Rc) - Ac[null,Ec] > tol).Length > 0) 
                    throw new Exception("values did not match (complex)!"); 
                Success("Test_QR_QREecoSize successfull. input size:" + A.Dimensions.ToString()); 
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_QR_QRecoSize(ILArray<double> A,double tol) {
            int errorCode = 0; 
            try {
                if (A.Dimensions[0] < A.Dimensions[1]) {
                    Info("QRecoSize: for matrices m < n, qr(A,ref R,false) is used!"); 
                    return; 
                }
                ILArray<double> R = ILArray<double>.empty(); 
                ILArray<double> Q = ILMath.qr(A, ref R, true); 
                if (Q.Dimensions[0] != A.Dimensions[0] || Q.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (R.Dimensions[0] != A.Dimensions[1] || R.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (ILMath.find(ILMath.norm(ILMath.multiply(Q,R) - A) > tol).Length > 0) 
                    throw new Exception("values did not match (double)!"); 

                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> Rf = ILArray<float>.empty(); 
                ILArray<float> Qf = ILMath.qr(Af, ref Rf, true); 
                if (Qf.Dimensions[0] != A.Dimensions[0] || Qf.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rf.Dimensions[0] != A.Dimensions[1] || Rf.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (ILMath.find(ILMath.multiply(Qf,Rf) - Af > tol).Length > 0) 
                    throw new Exception("values did not match (float)!"); 

                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> Rfc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Qfc = ILMath.qr(Afc, ref Rfc, true); 
                if (Qfc.Dimensions[0] != A.Dimensions[0] || Qfc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rfc.Dimensions[0] != A.Dimensions[1] || Rfc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (ILMath.find(ILMath.multiply(Qfc,Rfc) - Afc > tol).Length > 0) 
                    throw new Exception("values did not match (fcomplex)!"); 

                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> Rc = ILArray<complex>.empty(); 
                ILArray<complex> Qc = ILMath.qr(Ac, ref Rc, true); 
                if (Qc.Dimensions[0] != A.Dimensions[0] || Qc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: Q matrix"); 
                if (Rc.Dimensions[0] != A.Dimensions[1] || Rc.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: R matrix"); 
                if (ILMath.find(ILMath.multiply(Qc,Rc) - Ac > tol).Length > 0) 
                    throw new Exception("values did not match (complex)!"); 
                Success("Test_QR_QRecoSize successfull. input size:" + A.Dimensions.ToString()); 
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_QR_QRE(ILArray<double> A,double tol) {
            int errorCode = 0; 
            try {
                ILArray<double> R = ILArray<double>.empty(); 
                ILArray<double> E = ILArray<double>.empty(); 
                ILArray<double> Q = ILMath.qr(A, ref R, ref E);
                if (Q.Dimensions[0] != A.Dimensions[0] || Q.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (E.Dimensions[0] != A.Dimensions[1] || E.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.norm(ILMath.multiply(Q,R) - ILMath.multiply(A,E)) > tol).Length > 0) 
                    throw new Exception("values did not match (double)!"); 

                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> Rf = ILArray<float>.empty(); 
                ILArray<float> Ef = ILArray<float>.empty(); 
                ILArray<float> Qf = ILMath.qr(Af,ref Rf, ref Ef); 
                if (Qf.Dimensions[0] != A.Dimensions[0] || Qf.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (E.Dimensions[0] != A.Dimensions[1] || E.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qf,Rf) - ILMath.multiply(Af,Ef) > tol).Length > 0) 
                    throw new Exception("values did not match (float)!"); 

                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> Rfc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Efc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Qfc = ILMath.qr(Afc,ref Rfc, ref Efc); 
                if (Qfc.Dimensions[0] != A.Dimensions[0] || Qfc.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (E.Dimensions[0] != A.Dimensions[1] || E.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qfc,Rfc) - ILMath.multiply(Afc,Efc) > tol).Length > 0) 
                    throw new Exception("values did not match (fcomplex)!"); 

                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> Rc = ILArray<complex>.empty(); 
                ILArray<complex> Ec = ILArray<complex>.empty(); 
                ILArray<complex> Qc = ILMath.qr(Ac, ref Rc, ref Ec); 
                if (Qc.Dimensions[0] != A.Dimensions[0] || Qc.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (E.Dimensions[0] != A.Dimensions[1] || E.Dimensions[1] != A.Dimensions[1])
                    throw new Exception("invalid size of: E matrix"); 
                if (ILMath.find(ILMath.multiply(Qc,Rc) - ILMath.multiply(Ac,Ec) > tol).Length > 0) 
                    throw new Exception("values did not match (complex)!"); 
                Success("Test_QR_QRE successfull. input size:" + A.Dimensions.ToString()); 
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_QR_QR(ILArray<double> A,double tol) {
            int errorCode = 0; 
            try {
                ILArray<double> R = ILArray<double>.empty(); 
                ILArray<double> Q = ILMath.qr(A,ref R); 
                if (Q.Dimensions[0] != A.Dimensions[0] || Q.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (ILMath.find(ILMath.norm(ILMath.multiply(Q,R) - A) > tol).Length > 0) 
                    throw new Exception("values did not match (double)!"); 

                ILArray<float> Af = ILMath.tosingle(A); 
                ILArray<float> Rf = ILArray<float>.empty(); 
                ILArray<float> Qf = ILMath.qr(Af,ref Rf); 
                if (Qf.Dimensions[0] != A.Dimensions[0] || Qf.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (ILMath.find(ILMath.multiply(Qf,Rf) - Af > tol).Length > 0) 
                    throw new Exception("values did not match (float)!"); 

                ILArray<fcomplex> Afc = ILMath.tofcomplex(A); 
                ILArray<fcomplex> Rfc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> Qfc = ILMath.qr(Afc,ref Rfc); 
                if (Qfc.Dimensions[0] != A.Dimensions[0] || Qfc.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (ILMath.find(ILMath.multiply(Qfc,Rfc) - Afc > tol).Length > 0) 
                    throw new Exception("values did not match (fcomplex)!"); 

                ILArray<complex> Ac = ILMath.tocomplex(A); 
                ILArray<complex> Rc = ILArray<complex>.empty(); 
                ILArray<complex> Qc = ILMath.qr(Ac,ref Rc); 
                if (Qc.Dimensions[0] != A.Dimensions[0] || Qc.Dimensions[1] != A.Dimensions[0])
                    throw new Exception("invalid size of: Q matrix"); 
                if (ILMath.find(ILMath.multiply(Qc,Rc) - Ac > tol).Length > 0) 
                    throw new Exception("values did not match (complex)!"); 
                Success("Test_QR_QR successfull. input size:" + A.Dimensions.ToString()); 
            } catch(Exception e) {
                Error(errorCode,e.Message + " input size:" + A.Dimensions.ToString()); 
            }
        }
        private void Test_QR_rawLapackForm() {
            int errorCode = 0; 
            try {
                // create rank deficient matrix: rank(A) is 2
                ILArray<double> A = ILMath.counter(5,4); 
                ILArray<double> RawRes = new ILArray<double>(new double[]{-7.416198,  0.237637,  0.356455,  0.475274,  0.594092,-17.529196, -4.767313, -0.062681, -0.353440, -0.644200,-27.642194, -9.534626,  0.000000,  0.200000,  0.600000,-37.755192,-14.301939, -0.000000, -0.000000, -0.491996},5,4); 
                if (ILMath.find(ILMath.norm(ILMath.qr(A) - RawRes) > 1e-6).Length > 0) 
                    throw new Exception("values did not match (double)!"); 
                ILArray<complex> AC = ILMath.tocomplex(ILMath.counter(5,4)); 
                ILArray<complex> RawResC = ILMath.tocomplex(RawRes); 
                if (ILMath.find(ILMath.norm(ILMath.qr(AC) - RawResC) > 1e-6).Length > 0) 
                    throw new Exception("values did not match (complex)!"); 
                ILArray<float> AF = ILMath.tosingle(A);
                ILArray<float> RawResF = new ILArray<float> (new float[]{-7.416199f,  0.237637f,  0.356455f,  0.475274f,  0.594092f,-17.529196f, -4.767312f, -0.062681f, -0.353440f, -0.644200f,-27.642193f, -9.534623f,  0.000001f,  0.5288425f,  0.8431941f, -37.755192f,-14.301935f,  4.278799E-07f, 6.74691E-07f, 0.6276464f},5,4);
                if (ILMath.find(ILMath.qr(AF) - RawResF > 1e-5).Length > 0) 
                    Info("Test_QR_rawLapackForm (float): " + ILMath.find(ILMath.qr(AF) - RawResF > 1e-5).Length + " value(s) did not match expected result. continuing... "); 
                if (ILMath.find(ILMath.qr(AF) - RawResF > 1e-5).Length > 2) 
                    throw new Exception("values did not match (float)!"); 
                ILArray<fcomplex> AFc = ILMath.tofcomplex(AF);  
                
                ILArray<fcomplex> RawResFc = ILMath.tofcomplex(new ILArray<float> (new float[]{-7.416199f,  0.237637f,  0.356455f,  0.475274f,  0.594092f,-17.529196f, -4.767312f, -0.062681f, -0.353440f, -0.644200f,-27.642193f, -9.534623f,  0.000001f,  0.7308314f,  0.8431941f, -37.755192f,-14.301935f,  1.783777E-06f, 6.74691E-07f, 0.6276464f},5,4));
                if (ILMath.find(ILMath.qr(AFc) - RawResFc > 1e-5).Length > 0) 
                    Info("Test_QR_rawLapackForm(fcomplex): " + ILMath.find(ILMath.qr(AFc) - RawResFc > 1e-5).Length + " value(s) did not match expected result. continuing... "); 
                if (ILMath.find(ILMath.qr(AFc) - RawResFc > 1e-5).Length > 2) 
                    throw new Exception("values did not match (fcomplex)!"); 
                Success(); 
            } catch(Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_LU_retLUP() {
            int errorCode = 0; 
            try {
                // double
                ILArray<double> U = ILArray<double>.empty(); 
                ILArray<double> A = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                ILArray<double> P = ILArray<double>.empty(); 
                ILArray<double> L = ILMath.lu(A, ref U, ref P);
                if (ILMath.find(ILMath.multiply (L,U) - ILMath.multiply(P,A) > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (double,L)"); 
                // complex 
                ILArray<complex> UC = ILArray<complex>.empty(); 
                ILArray<complex> PC = ILArray<complex>.empty(); 
                ILArray<complex> AC = (ILArray<complex>)ILMath.convert(NumericType.Complex,A); 
                ILArray<complex> LC = ILMath.lu(AC, ref UC, ref PC);
                if (ILMath.find(ILMath.multiply (LC,UC) - ILMath.multiply(PC,AC) > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (complex,L)"); 
                // float 
                ILArray<float> UF = ILArray<float>.empty(); 
                ILArray<float> PF = ILArray<float>.empty(); 
                ILArray<float> AF = (ILArray<float>)ILMath.convert(NumericType.Single,A); 
                ILArray<float> LF = ILMath.lu(AF, ref UF, ref PF);
                if (ILMath.find(ILMath.multiply (LF,UF) - ILMath.multiply(PF,AF) > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (float,L)"); 
                // fcomplex 
                ILArray<fcomplex> UFc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> PFc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> AFc = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,A); 
                ILArray<fcomplex> LFc = ILMath.lu(AFc,ref UFc, ref PFc); 
                if (ILMath.find(ILMath.multiply (LFc,UFc) - ILMath.multiply(PFc,AFc) > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (fcomplex,L)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_LU_retLU() {
            int errorCode = 0; 
            try {
                // double
                ILArray<double> U = ILArray<double>.empty(); 
                ILArray<double> A = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                ILArray<double> L = ILMath.lu(A,ref U);
                if (ILMath.find(ILMath.multiply (L,U) - A > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (double,L)"); 
                // complex 
                ILArray<complex> UC = ILArray<complex>.empty(); 
                ILArray<complex> AC = (ILArray<complex>)ILMath.convert(NumericType.Complex,A); 
                ILArray<complex> LC = ILMath.lu(AC, ref UC);
                if (ILMath.find(ILMath.multiply (LC,UC) - AC > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (complex,L)"); 
                // float 
                ILArray<float> UF = ILArray<float>.empty(); 
                ILArray<float> AF = (ILArray<float>)ILMath.convert(NumericType.Single,A); 
                ILArray<float> LF = ILMath.lu(AF, ref UF);
                if (ILMath.find(ILMath.multiply (LF,UF) - AF > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (float,L)"); 
                // fcomplex 
                ILArray<fcomplex> UFc = ILArray<fcomplex>.empty(); 
                ILArray<fcomplex> AFc = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,A); 
                ILArray<fcomplex> LFc = ILMath.lu(AFc,ref UFc); 
                if (ILMath.find(ILMath.multiply (LFc,UFc) - AFc > 1e-6).Length > 0)
                    throw new Exception("lu: invalid result (fcomplex,L)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_LU_rawLapackForm() {
            int errorCode = 0; 
            try {
                // double
                ILArray<double> A = new ILArray<double>(new double[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24},4,6); 
                ILArray<double> ResRaw = new ILArray<double>(new double[]{4.000000,  0.250000,  0.750000,  0.500000,  8.000000,  3.000000,  0.333333,  0.666667, 12.000000,  6.000000,  0.000000,  0.000000, 16.000000,  9.000000,  0.000000,  0.000000, 20.000000, 12.000000,  0.000000,  0.000000, 24.000000, 15.000000,  0.000000,  0.000000},4,6); 
                ILArray<double> L = ILMath.lu(A);
                if (ILMath.find(L - ResRaw > 1e-6).Length > 0)
                    Info("Test_LU_rawLapackForm: unexpected result (double,L) - this might be ok!? (check return values)"); 
                // complex 
                ILArray<complex> AC = (ILArray<complex>)ILMath.convert(NumericType.Complex,A); 
                ILArray<complex> ResRawC = (ILArray<complex>)ILMath.convert(NumericType.Complex,ResRaw);
                ILArray<complex> LC = ILMath.lu(AC);
                if (ILMath.find(LC - ResRawC > 1e-6).Length > 0)
                    Info("Test_LU_rawLapackForm: unexpected result (complex,L) - this might be ok!? (check return values)"); 
                // float 
                ResRaw = new ILArray<double>(new double[]{4.000000,  0.250000,  0.500000,  0.750000,  8.000000,  3.000000,  0.666667,  0.333333, 12.000000,  6.000000, -0.000000,  0.500000, 16.000000,  9.000000, -0.000000,  0.000000, 20.000000, 12.000000, -0.000000,  0.000000, 24.000000, 15.000000, -0.000000,  0.000000},4,6); 
                ILArray<float> AF = (ILArray<float>)ILMath.convert(NumericType.Single,A); 
                ILArray<float> ResRawF = ILMath.tosingle(ResRaw);
                ILArray<float> LF = ILMath.lu(AF);
                if (ILMath.find(LF - ResRawF > 1e-6).Length > 0)
                    Info("Test_LU_rawLapackForm: unexpected result (float,L) - this might be ok!? (check return values)"); 
                // fcomplex 
                ILArray<fcomplex> AFc = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,A); 
                ILArray<fcomplex> ResRawFc = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,ResRawF);
                ILArray<fcomplex> LFc = ILMath.lu(AFc);
                if (ILMath.find(LFc - ResRawFc > 1e-6).Length > 0)
                    Info("Test_LU_rawLapackForm: unexpected result (fcomplex,L) - this might be ok!? (check return values)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_CholPosDef() {
            int errorCode = 0; 
            try {
                ILArray<double> A = new ILArray<double>(new double[]{1,1,1,1,1,2,3,4,1,3,6,10,1,4,10,20},4,4); 
                ILArray<double> Res = new ILArray<double>(new double[]{1,0,0,0,1,1,0,0,1,2,1,0,1,3,3,1},4,4);
                ILArray<double> B = ILMath.chol(A,true);
                if (!B.Equals(Res))
                    throw new Exception("chol: invalid result (double)"); 
                ILArray<float> AF = (ILArray<float>) ILMath.convert(NumericType.Single, A); 
                ILArray<float> ResF = (ILArray<float>) ILMath.convert(NumericType.Single, Res); 
                ILArray<float> BF = ILMath.chol(AF,true);
                if (!BF.Equals(ResF))
                    throw new Exception("chol: invalid result (float)"); 
                ILArray<fcomplex> AC = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,A);
                ILArray<fcomplex> ResC = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,Res);
                ILArray<fcomplex> BC = ILMath.chol(AC,true);
                if (!BC.Equals(ResC))
                    throw new Exception("chol: invalid result (fcomplex)"); 
                ILArray<complex> AfC = (ILArray<complex>)ILMath.convert(NumericType.Complex,A);
                ILArray<complex> ResfC = (ILArray<complex>)ILMath.convert(NumericType.Complex,Res);
                ILArray<complex> BfC = ILMath.chol(AfC,true);
                if (!BfC.Equals(ResfC))
                    throw new Exception("chol: invalid result (complex)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        private void Test_CholNonPosDef() {
            // test non pos def. matrix - last column 
            int errorCode = 0; 
            try {
                ILArray<double> A = new ILArray<double>(new double[]{1,1,1,1,1,2,3,4,1,3,6,10,1,4,10,19},4,4); 
                ILArray<double> Res = new ILArray<double>(new double[]{1,0,0,1,1,0,1,2,1},3,3);
                ILArray<double> B; 
                try { 
                    B = ILMath.chol(A,true);
                } catch (ILArgumentException ) {
                    Info("chol: test for positive definiteness successfull. Exception was thrown."); 
                }
                B = ILMath.chol(A,false); 
                if (!B.Equals(Res))
                    throw new Exception("chol: invalid result (double)"); 

                ILArray<float> AF = (ILArray<float>) ILMath.convert(NumericType.Single, A); 
                ILArray<float> ResF = (ILArray<float>) ILMath.convert(NumericType.Single, Res); 
                ILArray<float> BF; 
                try { 
                    BF = ILMath.chol(AF,true);
                } catch (ILArgumentException ) {
                    Info("chol: test for positive definiteness successfull. Exception was thrown."); 
                }
                BF = ILMath.chol(AF,false); 
                if (!BF.Equals(ResF))
                    throw new Exception("chol: invalid result (float)"); 
                ILArray<fcomplex> AC = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,A);
                ILArray<fcomplex> ResC = (ILArray<fcomplex>)ILMath.convert(NumericType.FComplex,Res);
                ILArray<fcomplex> BC; 
                try { 
                    BC = ILMath.chol(AC,true);
                } catch (ILArgumentException ) {
                    Info("chol: test for positive definiteness successfull. Exception was thrown."); 
                }
                BC = ILMath.chol(AC,false); 
                if (!BC.Equals(ResC))
                    throw new Exception("chol: invalid result (fcomplex)"); 
                ILArray<complex> AfC = (ILArray<complex>)ILMath.convert(NumericType.Complex,A);
                ILArray<complex> ResfC = (ILArray<complex>)ILMath.convert(NumericType.Complex,Res);
                ILArray<complex> BfC; 
                try { 
                    BfC = ILMath.chol(AfC,true);
                } catch (ILArgumentException ) {
                    Info("chol: test for positive definiteness successfull. Exception was thrown."); 
                }
                BfC = ILMath.chol(AfC,false); 
                if (!BfC.Equals(ResfC))
                    throw new Exception("chol: invalid result (complex)"); 
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }

        private void Test_SVD() {
            int errorCode = 0;
            try {
                errorCode = 1;
                ILArray<double> A = ILMath.ones(10, 10);
                ILArray<double> ResS = ILMath.zeros(10, 1);
                ResS[0, 0] = 10.0;
                ILArray<double> U = ILMath.empty();
                ILArray<double> V = ILMath.empty();

                ILArray<double> B = ILMath.svd(A);
                if (ILMath.norm(B - ResS) > 1e-10)
                    throw new Exception("Invalid values detected!");

                A = ILMath.ones(3, 3);
                ILArray<double> ResU = new ILArray<double>(
                    new double[9] { -0.577350, -0.577350, -0.577350, -0.577350, -0.211325, 0.788675, -0.577350, 0.788675, -0.211325}, 3, 3);
                ILArray<double> ResV = new ILArray<double>(
                    new double[9] { -0.5773503, -0.5773503, -0.5773503, 0, -0.7071068, 0.7071068, 0.8164966, -0.4082483, -0.4082483 }, 3, 3);
                ResS = ILMath.zeros(3, 3);
                ResS[0, 0] = 3.0;
                B = ILMath.svd(A, ref U, ref V);
                if (ILMath.norm(B - ResS) > 1e-10)
                    throw new Exception("Invalid values detected!");
                if (ILMath.norm(ILMath.abs(U - ResU)) > 1e-6)
                    throw new Exception("Invalid values detected!");
                if (ILMath.norm(ILMath.abs(V - ResV)) > 1e-6)
                    throw new Exception("Invalid values detected!");
                ///////////////////////////////   float ///////////////////////////////////////
                errorCode = 2;
                ILArray<float> fA = ILMath.single (ILMath.ones(10, 10));
                ILArray<float> fResS = ILMath.single(ILMath.zeros(10, 1));
                fResS[0, 0] = 10.0f;
                ILArray<float> fU = ILMath.single(ILMath.empty());
                ILArray<float> fV = ILMath.single(ILMath.empty());

                ILArray<float> fB = ILMath.svd(fA);
                if (ILMath.norm(fB - fResS) > 1e-5)
                    throw new Exception("Invalid values detected!");

                fA = ILMath.single(ILMath.reshape(ILMath.vector(1, 9),3,3));
                //ILArray<float> fResU = new ILArray<float>(
                //    new float[9] { -0.577350f, -0.577350f, -0.577350f,0.8164966f, -0.4082483f, -0.4082483f, 3.441276e-08f, -0.7071068f, 0.7071068f
                //                 }, 3, 3);
                //ILArray<float> fResV = new ILArray<float>(
                //    new float[9] { -0.5773503f, -0.5773503f, -0.5773503f, -0.8164966f,0.4082483f, 0.4082483f, 0.0f, 0.7071068f,-0.7071068f
                //                  }, 3, 3);
                //if (ILMath.Lapack is ILLapackGeneric)
                //{
                //    fResV = fResV.T; 
                //}
                //fResS = ILMath.single( ILMath.zeros(3, 3));
                //fResS[0, 0] = 3.0f;
                fB = ILMath.svd(fA, ref fU, ref fV);
                if (ILMath.norm(ILMath.multiply(ILMath.multiply(fU,fB), fV.T) - fA) > 1e-5) 
                    throw new Exception ("invalid values detected:ILMath.svd(fA, ref fU, ref fV);"); 

                ///////////////////////////////   complex ///////////////////////////////////////
                errorCode = 3;
                ILArray<complex> cA = ILMath.real2complex(ILMath.ones(10, 10));
                ResS = ILMath.zeros(10, 1);
                ResS[0, 0] = 10.0;
                ILArray<complex> cU = ILMath.real2complex(ILMath.empty());
                ILArray<complex> cV = ILMath.real2complex(ILMath.empty());

                B = ILMath.svd(cA);
                if (ILMath.norm(B - ResS) > 1e-6)
                    throw new Exception("Invalid values detected!");

                cA = ILMath.real2complex(ILMath.ones(3, 3));
                //ILArray<complex> cResU = new ILArray<complex>(
                //    new complex[9] { -0.577350, -0.577350, -0.577350, -0.577350, -0.211325, 0.788675, -0.577350, 0.788675, -0.211325
                //                 }, 3, 3);
                //ILArray<complex> cResV = new ILArray<complex>(
                //    new complex[9] { -0.5773503, -0.5773503, -0.5773503, 0, -0.7071068, 0.7071068, 0.8164966, -0.4082483, -0.4082483
                //                  }, 3, 3);
                //ResS = ILMath.zeros(3, 3);
                //ResS[0, 0] = 3.0;
                B = ILMath.svd(cA, ref cU, ref cV);
                if (ILMath.norm(ILMath.multiply(ILMath.multiply(cU,ILMath.real2complex(B)),cV.T) - cA) > 1e-6)
                    throw new Exception("Invalid values detected!");
                //if (ILMath.norm(ILMath.abs(cU - cResU)) > 1e-6)
                //    throw new Exception("Invalid values detected!");
                //if (ILMath.norm(ILMath.abs(cV - cResV)) > 1e-6)
                //    throw new Exception("Invalid values detected!");
                Success("Test_SVD successfull");
            } catch (Exception e) {
                Error("svd failed at errorCode " + errorCode + " due to: " + e.Message);
            }
        }

        private void Test_PINV() {
            int errorCode = 0;
            try {
                ILArray<double> A = ILMath.ones(10,5);
                ILArray<double> ResS = ILMath.ones(5,10) * 0.02;
                ILArray<double> B = ILMath.pinv(A);
                if (ILMath.norm(B - ResS)> 1e-10)
                    throw new Exception("Invalid values detected!");

                // test case m < n 
                errorCode = 1;
                B = ILMath.pinv(ILMath.ones(10, 5));
                ResS = ResS[0];
                if (ILMath.norm(B - ResS) > 1e-10)
                    throw new Exception("Invalid values detected!");

                // test len(diag(s)) > 1 
                errorCode = 2; 
                double[] results = new double[20] { -0.2300000000, -0.1450000000, -0.0600000000, 0.0250000000, 0.1100000000, -0.0850000000, -0.0525000000, -0.0200000000, 0.0125000000, 0.0450000000, 0.0600000000, 0.0400000000, 0.0200000000, -0.0000000000, -0.0200000000, 0.2050000000, 0.1325000000, 0.0600000000, -0.0125000000, -0.0850000000 };
                ResS = new ILArray<double>(results, 5, 4);
                double[] data = new double[20] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 };
                A = new ILArray<double>(data, 4, 5);
                B = ILMath.pinv(A);
                if (ILMath.norm(B - ResS) > 1e-10)
                    throw new Exception("Invalid values detected!");
                // test scalar 
                errorCode = 3;
                ResS = 0.0294117647;
                if (ILMath.norm(ILMath.pinv(34.0) - ResS) > 1e-8)
                    throw new Exception("Invalid values detected!");
                // test complex 
                ILArray<fcomplex> fA = ILMath.tofcomplex(ILMath.ccomplex(ILMath.ones(10,20),ILMath.ones(10,20)*0.5f)); 
                ILArray<fcomplex> fRes = ILMath.pinv(fA); 
                if (ILMath.sumall(ILMath.multiply(fA,ILMath.multiply(fRes,fA))-fA > 2e-5) > 0.0) {
                    throw new Exception("Invalid result: fcomplex a*res*a-a"); 
                }
                if (ILMath.sumall(ILMath.multiply(fRes,ILMath.multiply(fA,fRes))-fRes > 2e-5) > 0.0) {
                    throw new Exception("Invalid result: fcomplex a*res*a-a"); 
                }
                Success("Test_PINV successfull"); 
            } catch (Exception e) {
                Error("Test_PINV failed at errorCode " + errorCode + " due to: " + e.Message);
            }
        }

    }
}
