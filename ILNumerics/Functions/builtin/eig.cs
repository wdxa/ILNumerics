//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
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
using ILNumerics.Exceptions; 
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        HCCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        HCClsCmplx
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        HCClsReal
    </source>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        HCToComplex
    </source>
    <destination>ILMath.tocomplex</destination>
    <destination>ILMath.tofcomplex</destination>
    <destination>ILMath.tofcomplex</destination>
</type>
<type>
    <source locate="after">
        HCArr1
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        HCArrReal
    </source>
    <destination>double</destination>
    <destination>float</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        HCArrCmplx
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        HCCls2Cmplx
    </source>
    <destination></destination>
    <destination></destination>
    <destination>ILMath.tofcomplex</destination>
</type>
<type>
    <source locate="after">
        HCClsConv3
    </source>
    <destination>ILMath.tocomplex</destination>
    <destination>ILMath.tofcomplex</destination>
    <destination></destination>
</type>
<type>
    <source locate="nextline">
        HCArrWI
    </source>
    <destination></destination>
    <destination></destination>
    <destination><![CDATA[float[] wi = ILMemoryPool.Pool.New< float>(n);]]></destination>
</type>
<type>
    <source locate="nextline">
        HCSortEVal
    </source>
    <destination>retArr[i] = wr[i]; </destination>
    <destination>retArr[i] = wr[i]; </destination>
    <destination>retArr[i].real = wr[i]; retArr[i].imag = wi[i];</destination>
</type>
<type>
    <source locate="endregion">
        HCSortEVec 
    </source>
    <destination><![CDATA[V = new ILArray<complex> (vr,n,n);]]></destination>
    <destination><![CDATA[V = new ILArray<fcomplex> (vr,n,n);]]></destination>
    <destination><![CDATA[fcomplex [] VArr = ILMemoryPool.Pool.New< fcomplex >(n * n);
                    for (int c = 0; c < n; c++) {
                        if (wi[c] != 0 && wi[c+1] != 0 && c < n-1) {
                            ilo = n * c; ihi = ilo + n;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                VArr[ilo].imag = vr[ihi];  
                                VArr[ihi].real = vr[ilo];  
                                VArr[ihi].imag = -vr[ihi]; 
                                ilo++; ihi++; 
                            }
                            c++; 
                        } else {
                            ilo = n * c;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                ilo++; 
                            }
                        }
                    }
                    V = new ILArray<fcomplex> (VArr,n,n);  ]]></destination>
</type>
<type>
    <source locate="after">
        lapack_???evr
    </source>
    <destination>Lapack.zheevr</destination>
    <destination>Lapack.cheevr</destination>
    <destination>Lapack.ssyevr</destination>
</type>
<type>
    <source locate="nextline">
        HC?geevx
    </source>
    <destination>Lapack.zgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,   new complex [1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   </destination>
    <destination>Lapack.cgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,   new fcomplex[1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   </destination>
    <destination>Lapack.sgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,wi,new float   [1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   </destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART standard eigenproblems
        
        /// <summary>
        /// compute eigenvalues of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <returns>vector of eigenvalues of A. Size [n x 1]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The vector returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static /*!HC:HCClsCmplx*/ ILArray<complex> eig(/*!HC:HCCls1*/ ILArray<double> A) {
            /*!HC:HCClsCmplx*/ ILArray<complex> V = null; 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        /// <summary>
        /// compute eigenvalues and eigenvectors of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <param name="V">output matrix, eigenvectors EV of size [n x n]. May be null on input. If not null, content of V will be destroyed.</param>
        /// <returns>diagonal matrix with eigenvalues of A. Size [n x n]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The matrices returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static /*!HC:HCClsCmplx*/ ILArray<complex> eig(/*!HC:HCCls1*/ ILArray<double> A, ref /*!HC:HCClsCmplx*/ ILArray<complex> V) {
            if (object.Equals(V,null)) 
                V = /*!HC:HCClsCmplx*/ ILArray<complex> .empty(); 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        
        /// <summary>
        /// find eigenvalues  and eigenvectors 
        /// </summary>
        /// <param name="A">input: square matrix, size [n x n]</param>
        /// <param name="V">output (optional): eigenvectors</param>   
        /// <param name="propsA">matrix properties, on input - if specified, will be used to choose the proper method of solution. On exit will be filled according to the properties of A.</param>
        /// <param name="balance">true: permute A in order to increase the numerical stability, false: do not permute A.</param>
        /// <returns>eigenvalues as vector (if V is null) or as diagonoal matrix (if V was requested, i.e. not equaled null).</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The arrays returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>Depending on the parameter <paramref name="balance"/>, A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if a is not square</exception>
        public static /*!HC:HCClsCmplx*/ ILArray<complex> eig(/*!HC:HCCls1*/ ILArray<double> A, ref /*!HC:HCClsCmplx*/ ILArray<complex> V, ref MatrixProperties propsA, bool balance) {
            if (A.IsEmpty) {
                return /*!HC:HCClsCmplx*/ ILArray<complex> .empty(); 
            }
            /*!HC:HCClsCmplx*/ ILArray<complex> ret = null;  
            int n = A.Dimensions[0]; 
            bool createVR = (object.Equals(V,null))? false:true; 
            if (n != A.Dimensions[1]) 
                throw new ILArgumentException("eig: matrix A must be square!");
            propsA |= MatrixProperties.Square; 
            if (((propsA & MatrixProperties.Hermitian) != 0 || ILMath.ishermitian(A))) {
                propsA |= MatrixProperties.Hermitian; 
                /*!HC:HCCls1*/ ILArray<double> Vd = null; 
                if (createVR) 
                    Vd = /*!HC:HCCls1*/ ILArray<double> .empty();
                /*!HC:HCCls1*/ ILArray<double> tmpRet = eigSymm(A,ref Vd);
                if (createVR)
                    V = /*!HC:HCCls2Cmplx*/ ILMath.tocomplex (Vd); 
                ret = /*!HC:HCCls2Cmplx*/ ILMath.tocomplex (tmpRet);
            } else {
                // nonsymmetric case
                char bal = (balance)? 'B':'N', jobvr;  
                /*!HC:HCCls1*/ ILArray<double> tmpA = (/*!HC:HCCls1*/ ILArray<double> )A.Clone(); 
                /*!HC:HCArr1*/ double [] vr = null;
                /*!HC:HCArr1*/ double [] wr = ILMemoryPool.Pool.New</*!HC:HCArr1*/ double >(n); 
                /*!HC:HCArrWI*/ 
                double[] wi = ILMemoryPool.Pool.New<double>(n); 
                /*!HC:HCArrReal*/ double [] scale  = ILMemoryPool.Pool.New</*!HC:HCArrReal*/ double >(n);
                /*!HC:HCArrReal*/ double [] rconde = ILMemoryPool.Pool.New</*!HC:HCArrReal*/ double >(n); 
                /*!HC:HCArrReal*/ double [] rcondv = ILMemoryPool.Pool.New</*!HC:HCArrReal*/ double >(n); 
                /*!HC:HCArrReal*/ double abnrm = 0; 
                int ldvr, ilo = 0, ihi = 0, info = 0;
                if (createVR) {
                    ldvr = n;
                    vr = ILMemoryPool.Pool.New</*!HC:HCArr1*/ double >(n * n);
                    jobvr = 'V'; 
                } else {
                    ldvr = 1; 
                    vr = new /*!HC:HCArr1*/ double [1]; 
                    jobvr = 'N'; 
                }
                /*!HC:HC?geevx*/
                Lapack.dgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,wi,new /*!HC:HCArr1*/ double [1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   
                if (info != 0) 
                    throw new ILArgumentException("eig: error in Lapack '?geevx': (" + info + ")");
                // create eigenvalues 
                /*!HC:HCArrCmplx*/ complex [] retArr = ILMemoryPool.Pool.New</*!HC:HCArrCmplx*/ complex >(n); 
                for (int i = 0; i < n; i++) {
                    /*!HC:HCSortEVal*/
                    retArr[i].real = wr[i]; retArr[i].imag = wi[i]; 
                }
                ret = new /*!HC:HCClsCmplx*/ ILArray<complex> (retArr,n,1);
                if (createVR) {
                    #region HCSortEVec
                    complex [] VArr = ILMemoryPool.Pool.New< complex >(n * n);
                    for (int c = 0; c < n; c++) {
                        if (wi[c] != 0 && wi[c+1] != 0 && c < n-1) {
                            ilo = n * c; ihi = ilo + n;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                VArr[ilo].imag = vr[ihi];  
                                VArr[ihi].real = vr[ilo];  
                                VArr[ihi].imag = -vr[ihi]; 
                                ilo++; ihi++; 
                            }
                            c++; 
                        } else {
                            ilo = n * c;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                ilo++; 
                            }
                        }
                    }
                    V = new ILArray<complex> (VArr,n,n); 
                    #endregion HYCALPER
                    if (createVR) 
                        ret = ILMath.diag(ret); 
                }
            }
            return ret; 
        }

        /// <summary>
        /// find all eigenvalues of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <returns>array of size [n,1] with eigenvalues of A.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static /*!HC:HCCls1*/ ILArray<double> eigSymm (/*!HC:HCCls1*/ ILArray<double> A) {
            if (A.IsEmpty) {
                return /*!HC:HCCls1*/ ILArray<double> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            /*!HC:HCCls1*/ ILArray<double> ret = null; 
            int m = 0,info = 0; 
            /*!HC:HCCls1*/ ILArray<double> tmpA = A.copyUpperTriangle(n); 
            /*!HC:HCClsReal*/ ILArray<double> w = new /*!HC:HCClsReal*/ ILArray<double> (new /*!HC:HCArrReal*/ double [n],1,n); 
            /*!HC:HCArr1*/ double [] z = new /*!HC:HCArr1*/ double [1]; ; 
            int [] isuppz = new int[2 * n];
            /*!HC:lapack_???evr*/ Lapack.dsyevr ('N','A','U',n,tmpA.m_data,n,0,0,0,0,0,ref m,w.m_data,z,1,isuppz,ref info);
            ret = /*!HC:HCClsConv3*/ /**/ (w); 
            return ret; 
        }
        /// <summary>
        /// find all eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static /*!HC:HCCls1*/ ILArray<double> eigSymm (/*!HC:HCCls1*/ ILArray<double> A, ref /*!HC:HCCls1*/ ILArray<double> V) {
            if (A.IsEmpty) {
                V = /*!HC:HCCls1*/ ILArray<double> .empty(); 
                return /*!HC:HCCls1*/ ILArray<double> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            /*!HC:HCCls1*/ ILArray<double> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            /*!HC:HCCls1*/ ILArray<double> tmpA = A.copyUpperTriangle(n); 
            /*!HC:HCClsReal*/ ILArray<double> w = new /*!HC:HCClsReal*/ ILArray<double> (new /*!HC:HCArrReal*/ double [n],n,1); 
            /*!HC:HCArr1*/ double [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new /*!HC:HCArr1*/ double [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new /*!HC:HCArr1*/ double [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            /*!HC:lapack_???evr*/ Lapack.dsyevr (jobz,'A','U',n,tmpA.m_data,n,1,n,0,0,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            if (info != 0) 
                throw new ILException("eigSymm: error returned from lapack: " + info); 
            if (jobz == 'V') {
                V =  new  /*!HC:HCCls1*/ ILArray<double> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
                ret = ILMath.diag(/*!HC:HCClsConv3*/ /**/ (w)); 
            } else {
                ret = /*!HC:HCClsConv3*/ /**/ (w);
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">specify the lowest limit for the range of eigenvalues to be queried.</param>
        /// <param name="rangeEnd">specify the upper limit for the range of eigenvalues to be queried.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/></exception>
        public static /*!HC:HCCls1*/ ILArray<double> eigSymm (/*!HC:HCCls1*/ ILArray<double> A, ref /*!HC:HCCls1*/ ILArray<double> V, int rangeStart, int rangeEnd) {
            if (A.IsEmpty) {
                V = /*!HC:HCCls1*/ ILArray<double> .empty(); 
                return /*!HC:HCCls1*/ ILArray<double> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            /*!HC:HCCls1*/ ILArray<double> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeEnd < rangeStart || rangeStart < 1) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            /*!HC:HCCls1*/ ILArray<double> tmpA = A.copyUpperTriangle(n); 
            /*!HC:HCClsReal*/ ILArray<double> w = new /*!HC:HCClsReal*/ ILArray<double> (new /*!HC:HCArrReal*/ double [n],1,n); 
            /*!HC:HCArr1*/ double [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new /*!HC:HCArr1*/ double [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new /*!HC:HCArr1*/ double [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            /*!HC:lapack_???evr*/ Lapack.dsyevr (jobz,'I','U',n,tmpA.m_data,n,0,0,rangeStart,rangeEnd,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag(/*!HC:HCClsConv3*/ /**/ (w)); 
            if (jobz == 'V') {
                V =  new  /*!HC:HCCls1*/ ILArray<double> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">The eigenvalues will be returned by increasing size. This will determine the number of the first eigenvalue to be returned.</param>
        /// <param name="rangeEnd">Determine the number of the last eigenvalue to be returned.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/> or if either one is &lt;= 0.</exception>
        public static /*!HC:HCCls1*/ ILArray<double> eigSymm (/*!HC:HCCls1*/ ILArray<double> A, ref /*!HC:HCCls1*/ ILArray<double> V, /*!HC:HCArrReal*/ double rangeStart, /*!HC:HCArrReal*/ double rangeEnd) {
            if (A.IsEmpty) {
                V = /*!HC:HCCls1*/ ILArray<double> .empty(); 
                return /*!HC:HCCls1*/ ILArray<double> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            /*!HC:HCCls1*/ ILArray<double> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeStart > rangeEnd) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            /*!HC:HCCls1*/ ILArray<double> tmpA = A.copyUpperTriangle(n); 
            /*!HC:HCClsReal*/ ILArray<double> w = new /*!HC:HCClsReal*/ ILArray<double> (new /*!HC:HCArrReal*/ double [n],1,n); 
            /*!HC:HCArr1*/ double [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new /*!HC:HCArr1*/ double [1]; 
                jobz = 'N';             
                ldz = 1; 
            } else {
                z = new /*!HC:HCArr1*/ double [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            /*!HC:lapack_???evr*/ Lapack.dsyevr (jobz,'V','U',n,tmpA.m_data,n,rangeStart,rangeEnd,0,0,0, ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag(/*!HC:HCClsConv3*/ /**/ (w)); 
            if (jobz == 'V') {
                V =  new  /*!HC:HCCls1*/ ILArray<double> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        
        /// <summary>
        /// compute eigenvalues of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <returns>vector of eigenvalues of A. Size [n x 1]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The vector returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<fcomplex> eig( ILArray<float> A) {
            ILArray<fcomplex> V = null; 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        /// <summary>
        /// compute eigenvalues and eigenvectors of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <param name="V">output matrix, eigenvectors EV of size [n x n]. May be null on input. If not null, content of V will be destroyed.</param>
        /// <returns>diagonal matrix with eigenvalues of A. Size [n x n]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The matrices returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<fcomplex> eig( ILArray<float> A, ref  ILArray<fcomplex> V) {
            if (object.Equals(V,null)) 
                V =  ILArray<fcomplex> .empty(); 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        
        /// <summary>
        /// find eigenvalues  and eigenvectors 
        /// </summary>
        /// <param name="A">input: square matrix, size [n x n]</param>
        /// <param name="V">output (optional): eigenvectors</param>   
        /// <param name="propsA">matrix properties, on input - if specified, will be used to choose the proper method of solution. On exit will be filled according to the properties of A.</param>
        /// <param name="balance">true: permute A in order to increase the numerical stability, false: do not permute A.</param>
        /// <returns>eigenvalues as vector (if V is null) or as diagonoal matrix (if V was requested, i.e. not equaled null).</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The arrays returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>Depending on the parameter <paramref name="balance"/>, A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if a is not square</exception>
        public static  ILArray<fcomplex> eig( ILArray<float> A, ref  ILArray<fcomplex> V, ref MatrixProperties propsA, bool balance) {
            if (A.IsEmpty) {
                return  ILArray<fcomplex> .empty(); 
            }
            ILArray<fcomplex> ret = null;  
            int n = A.Dimensions[0]; 
            bool createVR = (object.Equals(V,null))? false:true; 
            if (n != A.Dimensions[1]) 
                throw new ILArgumentException("eig: matrix A must be square!");
            propsA |= MatrixProperties.Square; 
            if (((propsA & MatrixProperties.Hermitian) != 0 || ILMath.ishermitian(A))) {
                propsA |= MatrixProperties.Hermitian; 
                ILArray<float> Vd = null; 
                if (createVR) 
                    Vd =  ILArray<float> .empty();
                ILArray<float> tmpRet = eigSymm(A,ref Vd);
                if (createVR)
                    V =  ILMath.tofcomplex (Vd); 
                ret =  ILMath.tofcomplex (tmpRet);
            } else {
                // nonsymmetric case
                char bal = (balance)? 'B':'N', jobvr;  
                ILArray<float> tmpA = ( ILArray<float> )A.Clone(); 
                float [] vr = null;
                float [] wr = ILMemoryPool.Pool.New< float >(n); 
                float[] wi = ILMemoryPool.Pool.New< float>(n);
                float [] scale  = ILMemoryPool.Pool.New< float >(n);
                float [] rconde = ILMemoryPool.Pool.New< float >(n); 
                float [] rcondv = ILMemoryPool.Pool.New< float >(n); 
                float abnrm = 0; 
                int ldvr, ilo = 0, ihi = 0, info = 0;
                if (createVR) {
                    ldvr = n;
                    vr = ILMemoryPool.Pool.New< float >(n * n);
                    jobvr = 'V'; 
                } else {
                    ldvr = 1; 
                    vr = new  float [1]; 
                    jobvr = 'N'; 
                }
                Lapack.sgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,wi,new float   [1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   
                if (info != 0) 
                    throw new ILArgumentException("eig: error in Lapack '?geevx': (" + info + ")");
                // create eigenvalues 
                fcomplex [] retArr = ILMemoryPool.Pool.New< fcomplex >(n); 
                for (int i = 0; i < n; i++) {
                    retArr[i].real = wr[i]; retArr[i].imag = wi[i];
                }
                ret = new  ILArray<fcomplex> (retArr,n,1);
                if (createVR) {
                    fcomplex [] VArr = ILMemoryPool.Pool.New< fcomplex >(n * n);
                    for (int c = 0; c < n; c++) {
                        if (wi[c] != 0 && wi[c+1] != 0 && c < n-1) {
                            ilo = n * c; ihi = ilo + n;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                VArr[ilo].imag = vr[ihi];  
                                VArr[ihi].real = vr[ilo];  
                                VArr[ihi].imag = -vr[ihi]; 
                                ilo++; ihi++; 
                            }
                            c++; 
                        } else {
                            ilo = n * c;
                            for (int r = 0; r < n; r++) {
                                VArr[ilo].real = vr[ilo];
                                ilo++; 
                            }
                        }
                    }
                    V = new ILArray<fcomplex> (VArr,n,n);  
                    if (createVR) 
                        ret = ILMath.diag(ret); 
                }
            }
            return ret; 
        }

        /// <summary>
        /// find all eigenvalues of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <returns>array of size [n,1] with eigenvalues of A.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<float> eigSymm ( ILArray<float> A) {
            if (A.IsEmpty) {
                return  ILArray<float> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<float> ret = null; 
            int m = 0,info = 0; 
            ILArray<float> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            float [] z = new  float [1]; ; 
            int [] isuppz = new int[2 * n];
            Lapack.ssyevr ('N','A','U',n,tmpA.m_data,n,0,0,0,0,0,ref m,w.m_data,z,1,isuppz,ref info);
            ret =   (w); 
            return ret; 
        }
        /// <summary>
        /// find all eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<float> eigSymm ( ILArray<float> A, ref  ILArray<float> V) {
            if (A.IsEmpty) {
                V =  ILArray<float> .empty(); 
                return  ILArray<float> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<float> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            ILArray<float> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],n,1); 
            float [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  float [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  float [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.ssyevr (jobz,'A','U',n,tmpA.m_data,n,1,n,0,0,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            if (info != 0) 
                throw new ILException("eigSymm: error returned from lapack: " + info); 
            if (jobz == 'V') {
                V =  new  ILArray<float> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
                ret = ILMath.diag(  (w)); 
            } else {
                ret =   (w);
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">specify the lowest limit for the range of eigenvalues to be queried.</param>
        /// <param name="rangeEnd">specify the upper limit for the range of eigenvalues to be queried.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/></exception>
        public static  ILArray<float> eigSymm ( ILArray<float> A, ref  ILArray<float> V, int rangeStart, int rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<float> .empty(); 
                return  ILArray<float> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<float> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeEnd < rangeStart || rangeStart < 1) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<float> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            float [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  float [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  float [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.ssyevr (jobz,'I','U',n,tmpA.m_data,n,0,0,rangeStart,rangeEnd,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag(  (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<float> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">The eigenvalues will be returned by increasing size. This will determine the number of the first eigenvalue to be returned.</param>
        /// <param name="rangeEnd">Determine the number of the last eigenvalue to be returned.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/> or if either one is &lt;= 0.</exception>
        public static  ILArray<float> eigSymm ( ILArray<float> A, ref  ILArray<float> V,  float rangeStart,  float rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<float> .empty(); 
                return  ILArray<float> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<float> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeStart > rangeEnd) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<float> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            float [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  float [1]; 
                jobz = 'N';             
                ldz = 1; 
            } else {
                z = new  float [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.ssyevr (jobz,'V','U',n,tmpA.m_data,n,rangeStart,rangeEnd,0,0,0, ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag(  (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<float> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        
        /// <summary>
        /// compute eigenvalues of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <returns>vector of eigenvalues of A. Size [n x 1]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The vector returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<fcomplex> eig( ILArray<fcomplex> A) {
            ILArray<fcomplex> V = null; 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        /// <summary>
        /// compute eigenvalues and eigenvectors of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <param name="V">output matrix, eigenvectors EV of size [n x n]. May be null on input. If not null, content of V will be destroyed.</param>
        /// <returns>diagonal matrix with eigenvalues of A. Size [n x n]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The matrices returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<fcomplex> eig( ILArray<fcomplex> A, ref  ILArray<fcomplex> V) {
            if (object.Equals(V,null)) 
                V =  ILArray<fcomplex> .empty(); 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        
        /// <summary>
        /// find eigenvalues  and eigenvectors 
        /// </summary>
        /// <param name="A">input: square matrix, size [n x n]</param>
        /// <param name="V">output (optional): eigenvectors</param>   
        /// <param name="propsA">matrix properties, on input - if specified, will be used to choose the proper method of solution. On exit will be filled according to the properties of A.</param>
        /// <param name="balance">true: permute A in order to increase the numerical stability, false: do not permute A.</param>
        /// <returns>eigenvalues as vector (if V is null) or as diagonoal matrix (if V was requested, i.e. not equaled null).</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The arrays returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>Depending on the parameter <paramref name="balance"/>, A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if a is not square</exception>
        public static  ILArray<fcomplex> eig( ILArray<fcomplex> A, ref  ILArray<fcomplex> V, ref MatrixProperties propsA, bool balance) {
            if (A.IsEmpty) {
                return  ILArray<fcomplex> .empty(); 
            }
            ILArray<fcomplex> ret = null;  
            int n = A.Dimensions[0]; 
            bool createVR = (object.Equals(V,null))? false:true; 
            if (n != A.Dimensions[1]) 
                throw new ILArgumentException("eig: matrix A must be square!");
            propsA |= MatrixProperties.Square; 
            if (((propsA & MatrixProperties.Hermitian) != 0 || ILMath.ishermitian(A))) {
                propsA |= MatrixProperties.Hermitian; 
                ILArray<fcomplex> Vd = null; 
                if (createVR) 
                    Vd =  ILArray<fcomplex> .empty();
                ILArray<fcomplex> tmpRet = eigSymm(A,ref Vd);
                if (createVR)
                    V =   (Vd); 
                ret =   (tmpRet);
            } else {
                // nonsymmetric case
                char bal = (balance)? 'B':'N', jobvr;  
                ILArray<fcomplex> tmpA = ( ILArray<fcomplex> )A.Clone(); 
                fcomplex [] vr = null;
                fcomplex [] wr = ILMemoryPool.Pool.New< fcomplex >(n); 
                
                float [] scale  = ILMemoryPool.Pool.New< float >(n);
                float [] rconde = ILMemoryPool.Pool.New< float >(n); 
                float [] rcondv = ILMemoryPool.Pool.New< float >(n); 
                float abnrm = 0; 
                int ldvr, ilo = 0, ihi = 0, info = 0;
                if (createVR) {
                    ldvr = n;
                    vr = ILMemoryPool.Pool.New< fcomplex >(n * n);
                    jobvr = 'V'; 
                } else {
                    ldvr = 1; 
                    vr = new  fcomplex [1]; 
                    jobvr = 'N'; 
                }
                Lapack.cgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,   new fcomplex[1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   
                if (info != 0) 
                    throw new ILArgumentException("eig: error in Lapack '?geevx': (" + info + ")");
                // create eigenvalues 
                fcomplex [] retArr = ILMemoryPool.Pool.New< fcomplex >(n); 
                for (int i = 0; i < n; i++) {
                    retArr[i] = wr[i]; 
                }
                ret = new  ILArray<fcomplex> (retArr,n,1);
                if (createVR) {
                    V = new ILArray<fcomplex> (vr,n,n);
                    if (createVR) 
                        ret = ILMath.diag(ret); 
                }
            }
            return ret; 
        }

        /// <summary>
        /// find all eigenvalues of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <returns>array of size [n,1] with eigenvalues of A.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<fcomplex> eigSymm ( ILArray<fcomplex> A) {
            if (A.IsEmpty) {
                return  ILArray<fcomplex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<fcomplex> ret = null; 
            int m = 0,info = 0; 
            ILArray<fcomplex> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            fcomplex [] z = new  fcomplex [1]; ; 
            int [] isuppz = new int[2 * n];
            Lapack.cheevr ('N','A','U',n,tmpA.m_data,n,0,0,0,0,0,ref m,w.m_data,z,1,isuppz,ref info);
            ret =  ILMath.tofcomplex (w); 
            return ret; 
        }
        /// <summary>
        /// find all eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<fcomplex> eigSymm ( ILArray<fcomplex> A, ref  ILArray<fcomplex> V) {
            if (A.IsEmpty) {
                V =  ILArray<fcomplex> .empty(); 
                return  ILArray<fcomplex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<fcomplex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            ILArray<fcomplex> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],n,1); 
            fcomplex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  fcomplex [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  fcomplex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.cheevr (jobz,'A','U',n,tmpA.m_data,n,1,n,0,0,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            if (info != 0) 
                throw new ILException("eigSymm: error returned from lapack: " + info); 
            if (jobz == 'V') {
                V =  new  ILArray<fcomplex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
                ret = ILMath.diag( ILMath.tofcomplex (w)); 
            } else {
                ret =  ILMath.tofcomplex (w);
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">specify the lowest limit for the range of eigenvalues to be queried.</param>
        /// <param name="rangeEnd">specify the upper limit for the range of eigenvalues to be queried.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/></exception>
        public static  ILArray<fcomplex> eigSymm ( ILArray<fcomplex> A, ref  ILArray<fcomplex> V, int rangeStart, int rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<fcomplex> .empty(); 
                return  ILArray<fcomplex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<fcomplex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeEnd < rangeStart || rangeStart < 1) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<fcomplex> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            fcomplex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  fcomplex [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  fcomplex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.cheevr (jobz,'I','U',n,tmpA.m_data,n,0,0,rangeStart,rangeEnd,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag( ILMath.tofcomplex (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<fcomplex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">The eigenvalues will be returned by increasing size. This will determine the number of the first eigenvalue to be returned.</param>
        /// <param name="rangeEnd">Determine the number of the last eigenvalue to be returned.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/> or if either one is &lt;= 0.</exception>
        public static  ILArray<fcomplex> eigSymm ( ILArray<fcomplex> A, ref  ILArray<fcomplex> V,  float rangeStart,  float rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<fcomplex> .empty(); 
                return  ILArray<fcomplex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<fcomplex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeStart > rangeEnd) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<fcomplex> tmpA = A.copyUpperTriangle(n); 
            ILArray<float> w = new  ILArray<float> (new  float [n],1,n); 
            fcomplex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  fcomplex [1]; 
                jobz = 'N';             
                ldz = 1; 
            } else {
                z = new  fcomplex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.cheevr (jobz,'V','U',n,tmpA.m_data,n,rangeStart,rangeEnd,0,0,0, ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag( ILMath.tofcomplex (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<fcomplex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        
        /// <summary>
        /// compute eigenvalues of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <returns>vector of eigenvalues of A. Size [n x 1]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The vector returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<complex> eig( ILArray<complex> A) {
            ILArray<complex> V = null; 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        /// <summary>
        /// compute eigenvalues and eigenvectors of general square matrix A
        /// </summary>
        /// <param name="A">input matrix A. Size [n x n]</param>
        /// <param name="V">output matrix, eigenvectors EV of size [n x n]. May be null on input. If not null, content of V will be destroyed.</param>
        /// <returns>diagonal matrix with eigenvalues of A. Size [n x n]</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The matrices returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        public static  ILArray<complex> eig( ILArray<complex> A, ref  ILArray<complex> V) {
            if (object.Equals(V,null)) 
                V =  ILArray<complex> .empty(); 
            MatrixProperties props = MatrixProperties.None; 
            return eig(A,ref V, ref props, true); 
        }
        
        /// <summary>
        /// find eigenvalues  and eigenvectors 
        /// </summary>
        /// <param name="A">input: square matrix, size [n x n]</param>
        /// <param name="V">output (optional): eigenvectors</param>   
        /// <param name="propsA">matrix properties, on input - if specified, will be used to choose the proper method of solution. On exit will be filled according to the properties of A.</param>
        /// <param name="balance">true: permute A in order to increase the numerical stability, false: do not permute A.</param>
        /// <returns>eigenvalues as vector (if V is null) or as diagonoal matrix (if V was requested, i.e. not equaled null).</returns>
        /// <remarks><para>The eigenvalues of A are found by use of the Lapack functions dgeevx, sgeevx, cgeevx and zgeevx. </para>
        /// <para>The arrays returned will be of complex inner type, since no further constraints are set on the structure of A (it may be nonsymmetric). Use <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;)"/> or <see cref="ILNumerics.BuiltInFunctions.ILMath.eigSymm(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> functions for computing the real eigenvalues of symmetric matrices explicitly.</para>
        /// <para>Depending on the parameter <paramref name="balance"/>, A will be balanced first. This includes permutations and scaling of A in order to improve the conditioning of the eigenvalues.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.eig(ILArray&lt;double&gt;,ref ILArray&lt;complex&gt;,ref MatrixProperties,bool)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if a is not square</exception>
        public static  ILArray<complex> eig( ILArray<complex> A, ref  ILArray<complex> V, ref MatrixProperties propsA, bool balance) {
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(); 
            }
            ILArray<complex> ret = null;  
            int n = A.Dimensions[0]; 
            bool createVR = (object.Equals(V,null))? false:true; 
            if (n != A.Dimensions[1]) 
                throw new ILArgumentException("eig: matrix A must be square!");
            propsA |= MatrixProperties.Square; 
            if (((propsA & MatrixProperties.Hermitian) != 0 || ILMath.ishermitian(A))) {
                propsA |= MatrixProperties.Hermitian; 
                ILArray<complex> Vd = null; 
                if (createVR) 
                    Vd =  ILArray<complex> .empty();
                ILArray<complex> tmpRet = eigSymm(A,ref Vd);
                if (createVR)
                    V =   (Vd); 
                ret =   (tmpRet);
            } else {
                // nonsymmetric case
                char bal = (balance)? 'B':'N', jobvr;  
                ILArray<complex> tmpA = ( ILArray<complex> )A.Clone(); 
                complex [] vr = null;
                complex [] wr = ILMemoryPool.Pool.New< complex >(n); 
                
                double [] scale  = ILMemoryPool.Pool.New< double >(n);
                double [] rconde = ILMemoryPool.Pool.New< double >(n); 
                double [] rcondv = ILMemoryPool.Pool.New< double >(n); 
                double abnrm = 0; 
                int ldvr, ilo = 0, ihi = 0, info = 0;
                if (createVR) {
                    ldvr = n;
                    vr = ILMemoryPool.Pool.New< complex >(n * n);
                    jobvr = 'V'; 
                } else {
                    ldvr = 1; 
                    vr = new  complex [1]; 
                    jobvr = 'N'; 
                }
                Lapack.zgeevx(bal,'N',jobvr,'N',n,tmpA.m_data,n,wr,   new complex [1],1,vr,ldvr,ref ilo,ref ihi,scale,ref abnrm,rconde,rcondv,ref info);   
                if (info != 0) 
                    throw new ILArgumentException("eig: error in Lapack '?geevx': (" + info + ")");
                // create eigenvalues 
                complex [] retArr = ILMemoryPool.Pool.New< complex >(n); 
                for (int i = 0; i < n; i++) {
                    retArr[i] = wr[i]; 
                }
                ret = new  ILArray<complex> (retArr,n,1);
                if (createVR) {
                    V = new ILArray<complex> (vr,n,n);
                    if (createVR) 
                        ret = ILMath.diag(ret); 
                }
            }
            return ret; 
        }

        /// <summary>
        /// find all eigenvalues of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <returns>array of size [n,1] with eigenvalues of A.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<complex> eigSymm ( ILArray<complex> A) {
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<complex> ret = null; 
            int m = 0,info = 0; 
            ILArray<complex> tmpA = A.copyUpperTriangle(n); 
            ILArray<double> w = new  ILArray<double> (new  double [n],1,n); 
            complex [] z = new  complex [1]; ; 
            int [] isuppz = new int[2 * n];
            Lapack.zheevr ('N','A','U',n,tmpA.m_data,n,0,0,0,0,0,ref m,w.m_data,z,1,isuppz,ref info);
            ret =  ILMath.tocomplex (w); 
            return ret; 
        }
        /// <summary>
        /// find all eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square.</exception>
        public static  ILArray<complex> eigSymm ( ILArray<complex> A, ref  ILArray<complex> V) {
            if (A.IsEmpty) {
                V =  ILArray<complex> .empty(); 
                return  ILArray<complex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<complex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            ILArray<complex> tmpA = A.copyUpperTriangle(n); 
            ILArray<double> w = new  ILArray<double> (new  double [n],n,1); 
            complex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  complex [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  complex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.zheevr (jobz,'A','U',n,tmpA.m_data,n,1,n,0,0,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            if (info != 0) 
                throw new ILException("eigSymm: error returned from lapack: " + info); 
            if (jobz == 'V') {
                V =  new  ILArray<complex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
                ret = ILMath.diag( ILMath.tocomplex (w)); 
            } else {
                ret =  ILMath.tocomplex (w);
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">specify the lowest limit for the range of eigenvalues to be queried.</param>
        /// <param name="rangeEnd">specify the upper limit for the range of eigenvalues to be queried.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/></exception>
        public static  ILArray<complex> eigSymm ( ILArray<complex> A, ref  ILArray<complex> V, int rangeStart, int rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<complex> .empty(); 
                return  ILArray<complex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<complex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeEnd < rangeStart || rangeStart < 1) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<complex> tmpA = A.copyUpperTriangle(n); 
            ILArray<double> w = new  ILArray<double> (new  double [n],1,n); 
            complex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  complex [1]; 
                jobz = 'N';
                ldz = 1; 
            } else {
                z = new  complex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.zheevr (jobz,'I','U',n,tmpA.m_data,n,0,0,rangeStart,rangeEnd,0,ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag( ILMath.tocomplex (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<complex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }
        /// <summary>
        /// find some eigenvalues and -vectors of symmetric (hermitian) matrix
        /// </summary>
        /// <param name="A">input matrix, Size [n x n], symmetric (hermitian for complex A) </param> 
        /// <param name="V">output: n eigenvectors as columns. Size [n x n]. If V is null on input, the eigenvectors will not be computed and V is not changed. </param>
        /// <param name="rangeStart">The eigenvalues will be returned by increasing size. This will determine the number of the first eigenvalue to be returned.</param>
        /// <param name="rangeEnd">Determine the number of the last eigenvalue to be returned.</param>
        /// <returns>diagonal matrix of size [n,n] with eigenvalues of A on the main diagonal.</returns>
        /// <remarks><para>For computation the Lapack functions dsyevr, ssyevr, chesvr and zheesv are used. </para>
        /// <para>Since A is symmetric, the eigenvalues will always be real. Therefore the return value will be of the same inner type as A.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A is not square or <paramref name="rangeEnd"/> &lt; <paramref name="rangeStart"/> or if either one is &lt;= 0.</exception>
        public static  ILArray<complex> eigSymm ( ILArray<complex> A, ref  ILArray<complex> V,  double rangeStart,  double rangeEnd) {
            if (A.IsEmpty) {
                V =  ILArray<complex> .empty(); 
                return  ILArray<complex> .empty(); 
            }
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrix A must be square and symmetric/hermitian.");
            ILArray<complex> ret = null; 
            int m = 0,ldz = 0,info = 0; 
            if (rangeStart > rangeEnd) 
                throw new ILArgumentException("eigSymm: invalid range of eigenvalues requested");
            ILArray<complex> tmpA = A.copyUpperTriangle(n); 
            ILArray<double> w = new  ILArray<double> (new  double [n],1,n); 
            complex [] z; 
            char jobz;
            if (object.Equals(V,null)) {
                z = new  complex [1]; 
                jobz = 'N';             
                ldz = 1; 
            } else {
                z = new  complex [n * n];
                jobz = 'V';
                ldz = n; 
            } 
            int [] isuppz = new int[2 * n];
            Lapack.zheevr (jobz,'V','U',n,tmpA.m_data,n,rangeStart,rangeEnd,0,0,0, ref m,w.m_data,z,ldz,isuppz,ref info);
            ret = ILMath.diag( ILMath.tocomplex (w)); 
            if (jobz == 'V') {
                V =  new  ILArray<complex> (z,n,n);
                V = V[null,ILMath.vector(0,m-1)]; 
            }
            return ret; 
        }

#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// Specifies the type of eigenproblem 
        /// </summary>
        /// <remarks>The enumeration describes possible problem definitions for generelized eigenproblems:
        /// <list type="bullet">
        /// <item>Ax_eq_lambBx: A*V = r*B*V</item>
        /// <item>ABx_eq_lambx: A*B*V = r*V</item>
        /// <item>BAx_eq_lambx: B*A*V = r*V</item>
        /// </list></remarks>
        public enum GenEigenType {
            /// <summary>
            /// A*V = r*B*V
            /// </summary>
            Ax_eq_lambBx,
            /// <summary>
            /// A*B*V = r*V
            /// </summary>
            ABx_eq_lambx,
            /// <summary>
            /// B*A*V = r*V
            /// </summary>
            BAx_eq_lambx
        }

        #region HYCALPER LOOPSTART generalized eigenproblems
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        InClsA
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        InClsB
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        RetCls
    </source>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        OutClsV
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        InArrA
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        InArrB
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        OutArrW
    </source>
    <destination>double</destination>
    <destination>float</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        lapack_func
    </source>
    <destination>Lapack.zhegv</destination>
    <destination>Lapack.chegv</destination>
    <destination>Lapack.ssygv</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// compute eigenvalues <it>lambda</it> of symmetrical/hermitian inputs A and B: A*V=lamda*B*V
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <returns>Vector of eigenvalues. size [n x 1]</returns>
        /// <remarks>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static /*!HC:RetCls*/ ILArray<double> eigSymm(/*!HC:InClsA*/ ILArray<double> A,/*!HC:InClsB*/  ILArray<double> B) {
            /*!HC:OutClsV*/ ILArray<double> V = null; 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,false); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) returns eigenvectors in columns (size [n x n]). </param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. The return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static /*!HC:RetCls*/ ILArray<double> eigSymm(/*!HC:InClsA*/ ILArray<double> A,/*!HC:InClsB*/  ILArray<double> B, out /*!HC:OutClsV*/  ILArray<double> V, bool skipSymmCheck) {
            V = /*!HC:OutClsV*/ ILArray<double> .empty(); 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,skipSymmCheck); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors (optional) of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) if on input not null-> returns eigenvectors in columns (size [n x n]). If null on input -> eigenvectors will not get computed.</param>
        /// <param name="type">Determine the type of problem. This is one of the following types:
        /// <list type="bullet">
        /// <item>Ax_eq_lambBx: A*V = r*B*V</item>
        /// <item>ABx_eq_lambx: A*B*V = r*V</item>
        /// <item>BAx_eq_lambx: B*A*V = r*V</item>
        /// </list>Here 'r' is the eigenvalue corresponding to the eigenvector 'V'.</param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. If the eigenvectors are requested as well (V not null on input), 
        /// the return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static /*!HC:RetCls*/ ILArray<double> eigSymm(/*!HC:InClsA*/ ILArray<double> A,/*!HC:InClsB*/  ILArray<double> B, ref /*!HC:OutClsV*/  ILArray<double> V, GenEigenType type, bool skipSymmCheck) {
            // check input arguments
            if (A == null || B == null) 
                throw new ILArgumentException("eigSymm: neither of A or B can be null!"); 
            if (!A.IsMatrix || !B.IsMatrix) 
                throw new ILArgumentException("eigSymm: A & B must be matrices!"); 
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrices must be square!"); 
            if (!A.Dimensions.IsSameSize(B.Dimensions))
                throw new ILArgumentException("eigSymm: A and B must be have the same size!");
            if (A.IsEmpty) {
                if (object.Equals(V,null)) 
                    return /*!HC:RetCls*/ ILArray<double> .empty();
                else {
                    V = A.C; 
                    return /*!HC:RetCls*/ ILArray<double> .empty();
                }
            }
            if (!skipSymmCheck && !ILMath.ishermitian(A)) {
                throw new ILArgumentException("eig: A must be hermitian!"); 
            }
            if (!skipSymmCheck && !ILMath.ishermitian(B)) {
                throw new ILArgumentException("eig: B must be hermitian!"); 
            }
            int info = -1; 
            int itype = 1;
            switch (type) {
                case GenEigenType.Ax_eq_lambBx:
                    itype = 1; 
                    break;
                case GenEigenType.ABx_eq_lambx:
                    itype = 2; 
                    break;
                case GenEigenType.BAx_eq_lambx:
                    itype = 3; 
                    break;
            }
            char jobz = 'N'; 
            if (!object.Equals(V,null)) {
                jobz = 'V';    
            }
            // prepare data parameter 
            V = copyUpperTriangle(A,n,n); 
            int spac0; char trans; 
            ILArray</*!HC:InArrB*/ double > BC = B.C; 
            /*!HC:OutArrW*/ double [] w = ILMemoryPool.Pool.New</*!HC:OutArrW*/ double >(n); 
            /*!HC:lapack_func*/ Lapack.dsygv (itype,jobz,'U',n,V.m_data,n,BC.m_data,BC.Dimensions[0],w,ref info);
            if (info == 0) {
                if (jobz == 'N')
                    return new ILArray</*!HC:OutArrW*/ double >(w,1,n); 
                else 
                    return ILMath.diag(new ILArray</*!HC:OutArrW*/ double >(w,1,n)); 
            } else if (info < 0) {
                throw new ILArgumentException("eigSymm: invalid parameter #" + (-info)); 
            } else {
                if (info <= n) {
                    throw new ILArgumentException(String.Format("eigSymm: did not converge! {0} off-diagonal elements unequal 0",info)); 
                } else if (info < 2*n) {
                    throw new ILArgumentException("eigSymm: B must be positive definite!");
                } else {
                    throw new ILArgumentException("eigSymm: unknown error"); 
                }
            }
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        /// <summary>
        /// compute eigenvalues <it>lambda</it> of symmetrical/hermitian inputs A and B: A*V=lamda*B*V
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <returns>Vector of eigenvalues. size [n x 1]</returns>
        /// <remarks>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<float> A,  ILArray<float> B) {
            ILArray<float> V = null; 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,false); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) returns eigenvectors in columns (size [n x n]). </param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. The return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<float> A,  ILArray<float> B, out   ILArray<float> V, bool skipSymmCheck) {
            V =  ILArray<float> .empty(); 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,skipSymmCheck); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors (optional) of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) if on input not null-> returns eigenvectors in columns (size [n x n]). If null on input -> eigenvectors will not get computed.</param>
        /// <param name="type">Determine the type of problem. This is one of the following types:
        /// <list type="bullet">
        /// <item>Ax_eq_lambBx: A*V = r*B*V</item>
        /// <item>ABx_eq_lambx: A*B*V = r*V</item>
        /// <item>BAx_eq_lambx: B*A*V = r*V</item>
        /// </list>Here 'r' is the eigenvalue corresponding to the eigenvector 'V'.</param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. If the eigenvectors are requested as well (V not null on input), 
        /// the return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<float> A,  ILArray<float> B, ref   ILArray<float> V, GenEigenType type, bool skipSymmCheck) {
            // check input arguments
            if (A == null || B == null) 
                throw new ILArgumentException("eigSymm: neither of A or B can be null!"); 
            if (!A.IsMatrix || !B.IsMatrix) 
                throw new ILArgumentException("eigSymm: A & B must be matrices!"); 
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrices must be square!"); 
            if (!A.Dimensions.IsSameSize(B.Dimensions))
                throw new ILArgumentException("eigSymm: A and B must be have the same size!");
            if (A.IsEmpty) {
                if (object.Equals(V,null)) 
                    return  ILArray<float> .empty();
                else {
                    V = A.C; 
                    return  ILArray<float> .empty();
                }
            }
            if (!skipSymmCheck && !ILMath.ishermitian(A)) {
                throw new ILArgumentException("eig: A must be hermitian!"); 
            }
            if (!skipSymmCheck && !ILMath.ishermitian(B)) {
                throw new ILArgumentException("eig: B must be hermitian!"); 
            }
            int info = -1; 
            int itype = 1;
            switch (type) {
                case GenEigenType.Ax_eq_lambBx:
                    itype = 1; 
                    break;
                case GenEigenType.ABx_eq_lambx:
                    itype = 2; 
                    break;
                case GenEigenType.BAx_eq_lambx:
                    itype = 3; 
                    break;
            }
            char jobz = 'N'; 
            if (!object.Equals(V,null)) {
                jobz = 'V';    
            }
            // prepare data parameter 
            V = copyUpperTriangle(A,n,n); 
            int spac0; char trans; 
            ILArray< float > BC = B.C; 
            float [] w = ILMemoryPool.Pool.New< float >(n); 
            Lapack.ssygv (itype,jobz,'U',n,V.m_data,n,BC.m_data,BC.Dimensions[0],w,ref info);
            if (info == 0) {
                if (jobz == 'N')
                    return new ILArray< float >(w,1,n); 
                else 
                    return ILMath.diag(new ILArray< float >(w,1,n)); 
            } else if (info < 0) {
                throw new ILArgumentException("eigSymm: invalid parameter #" + (-info)); 
            } else {
                if (info <= n) {
                    throw new ILArgumentException(String.Format("eigSymm: did not converge! {0} off-diagonal elements unequal 0",info)); 
                } else if (info < 2*n) {
                    throw new ILArgumentException("eigSymm: B must be positive definite!");
                } else {
                    throw new ILArgumentException("eigSymm: unknown error"); 
                }
            }
        }

        /// <summary>
        /// compute eigenvalues <it>lambda</it> of symmetrical/hermitian inputs A and B: A*V=lamda*B*V
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <returns>Vector of eigenvalues. size [n x 1]</returns>
        /// <remarks>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<fcomplex> A,  ILArray<fcomplex> B) {
            ILArray<fcomplex> V = null; 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,false); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) returns eigenvectors in columns (size [n x n]). </param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. The return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<fcomplex> A,  ILArray<fcomplex> B, out   ILArray<fcomplex> V, bool skipSymmCheck) {
            V =  ILArray<fcomplex> .empty(); 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,skipSymmCheck); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors (optional) of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) if on input not null-> returns eigenvectors in columns (size [n x n]). If null on input -> eigenvectors will not get computed.</param>
        /// <param name="type">Determine the type of problem. This is one of the following types:
        /// <list type="bullet">
        /// <item>Ax_eq_lambBx: A*V = r*B*V</item>
        /// <item>ABx_eq_lambx: A*B*V = r*V</item>
        /// <item>BAx_eq_lambx: B*A*V = r*V</item>
        /// </list>Here 'r' is the eigenvalue corresponding to the eigenvector 'V'.</param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. If the eigenvectors are requested as well (V not null on input), 
        /// the return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<float> eigSymm( ILArray<fcomplex> A,  ILArray<fcomplex> B, ref   ILArray<fcomplex> V, GenEigenType type, bool skipSymmCheck) {
            // check input arguments
            if (A == null || B == null) 
                throw new ILArgumentException("eigSymm: neither of A or B can be null!"); 
            if (!A.IsMatrix || !B.IsMatrix) 
                throw new ILArgumentException("eigSymm: A & B must be matrices!"); 
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrices must be square!"); 
            if (!A.Dimensions.IsSameSize(B.Dimensions))
                throw new ILArgumentException("eigSymm: A and B must be have the same size!");
            if (A.IsEmpty) {
                if (object.Equals(V,null)) 
                    return  ILArray<float> .empty();
                else {
                    V = A.C; 
                    return  ILArray<float> .empty();
                }
            }
            if (!skipSymmCheck && !ILMath.ishermitian(A)) {
                throw new ILArgumentException("eig: A must be hermitian!"); 
            }
            if (!skipSymmCheck && !ILMath.ishermitian(B)) {
                throw new ILArgumentException("eig: B must be hermitian!"); 
            }
            int info = -1; 
            int itype = 1;
            switch (type) {
                case GenEigenType.Ax_eq_lambBx:
                    itype = 1; 
                    break;
                case GenEigenType.ABx_eq_lambx:
                    itype = 2; 
                    break;
                case GenEigenType.BAx_eq_lambx:
                    itype = 3; 
                    break;
            }
            char jobz = 'N'; 
            if (!object.Equals(V,null)) {
                jobz = 'V';    
            }
            // prepare data parameter 
            V = copyUpperTriangle(A,n,n); 
            int spac0; char trans; 
            ILArray< fcomplex > BC = B.C; 
            float [] w = ILMemoryPool.Pool.New< float >(n); 
            Lapack.chegv (itype,jobz,'U',n,V.m_data,n,BC.m_data,BC.Dimensions[0],w,ref info);
            if (info == 0) {
                if (jobz == 'N')
                    return new ILArray< float >(w,1,n); 
                else 
                    return ILMath.diag(new ILArray< float >(w,1,n)); 
            } else if (info < 0) {
                throw new ILArgumentException("eigSymm: invalid parameter #" + (-info)); 
            } else {
                if (info <= n) {
                    throw new ILArgumentException(String.Format("eigSymm: did not converge! {0} off-diagonal elements unequal 0",info)); 
                } else if (info < 2*n) {
                    throw new ILArgumentException("eigSymm: B must be positive definite!");
                } else {
                    throw new ILArgumentException("eigSymm: unknown error"); 
                }
            }
        }

        /// <summary>
        /// compute eigenvalues <it>lambda</it> of symmetrical/hermitian inputs A and B: A*V=lamda*B*V
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <returns>Vector of eigenvalues. size [n x 1]</returns>
        /// <remarks>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<double> eigSymm( ILArray<complex> A,  ILArray<complex> B) {
            ILArray<complex> V = null; 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,false); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) returns eigenvectors in columns (size [n x n]). </param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. The return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<double> eigSymm( ILArray<complex> A,  ILArray<complex> B, out   ILArray<complex> V, bool skipSymmCheck) {
            V =  ILArray<complex> .empty(); 
            return eigSymm(A,B,ref V,GenEigenType.Ax_eq_lambBx,skipSymmCheck); 
        }

        /// <summary>
        /// compute eigenvalues and eigenvectors (optional) of symmetric/hermitian input
        /// </summary>
        /// <param name="A">square, symmetric/hermitian input matrix, size [n x n]</param>
        /// <param name="B">square, symmetric/hermitian and positive definite matrix, size [n x n]</param>
        /// <param name="V">(output) if on input not null-> returns eigenvectors in columns (size [n x n]). If null on input -> eigenvectors will not get computed.</param>
        /// <param name="type">Determine the type of problem. This is one of the following types:
        /// <list type="bullet">
        /// <item>Ax_eq_lambBx: A*V = r*B*V</item>
        /// <item>ABx_eq_lambx: A*B*V = r*V</item>
        /// <item>BAx_eq_lambx: B*A*V = r*V</item>
        /// </list>Here 'r' is the eigenvalue corresponding to the eigenvector 'V'.</param>
        /// <param name="skipSymmCheck">true: skip tests for A and B beeing hermitian.</param>
        /// <returns>Vector of eigenvalues. If the eigenvectors are requested as well (V not null on input), 
        /// the return value will be a diagonal matrix with the eigenvalues on the main diagonal.</returns>
        /// <remarks><para>The eigenvectors in 'V' are not normalized!</para>
        /// <para>Internally, the generalized eigenproblem A*V = r*B*V will be reduced to B<sup>-1</sup>*A*V = r*V using cholesky factorization. The 
        /// computations are handled by LAPACK functions DSYGV,SSYGV,CHEGV and ZHEGV.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if B was not positive definite</exception> 
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A and B was not of the same size</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <paramref name="skipSymmCheck"/> is false and either A and/or B was found not to be symmetric/hermitian</exception>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the algorithm did not converge. All exceptions will contain an informational message describing the problem verbosely.</exception>
        public static  ILArray<double> eigSymm( ILArray<complex> A,  ILArray<complex> B, ref   ILArray<complex> V, GenEigenType type, bool skipSymmCheck) {
            // check input arguments
            if (A == null || B == null) 
                throw new ILArgumentException("eigSymm: neither of A or B can be null!"); 
            if (!A.IsMatrix || !B.IsMatrix) 
                throw new ILArgumentException("eigSymm: A & B must be matrices!"); 
            int n = A.Dimensions[0]; 
            if (n != A.Dimensions[1])
                throw new ILArgumentException("eigSymm: input matrices must be square!"); 
            if (!A.Dimensions.IsSameSize(B.Dimensions))
                throw new ILArgumentException("eigSymm: A and B must be have the same size!");
            if (A.IsEmpty) {
                if (object.Equals(V,null)) 
                    return  ILArray<double> .empty();
                else {
                    V = A.C; 
                    return  ILArray<double> .empty();
                }
            }
            if (!skipSymmCheck && !ILMath.ishermitian(A)) {
                throw new ILArgumentException("eig: A must be hermitian!"); 
            }
            if (!skipSymmCheck && !ILMath.ishermitian(B)) {
                throw new ILArgumentException("eig: B must be hermitian!"); 
            }
            int info = -1; 
            int itype = 1;
            switch (type) {
                case GenEigenType.Ax_eq_lambBx:
                    itype = 1; 
                    break;
                case GenEigenType.ABx_eq_lambx:
                    itype = 2; 
                    break;
                case GenEigenType.BAx_eq_lambx:
                    itype = 3; 
                    break;
            }
            char jobz = 'N'; 
            if (!object.Equals(V,null)) {
                jobz = 'V';    
            }
            // prepare data parameter 
            V = copyUpperTriangle(A,n,n); 
            int spac0; char trans; 
            ILArray< complex > BC = B.C; 
            double [] w = ILMemoryPool.Pool.New< double >(n); 
            Lapack.zhegv (itype,jobz,'U',n,V.m_data,n,BC.m_data,BC.Dimensions[0],w,ref info);
            if (info == 0) {
                if (jobz == 'N')
                    return new ILArray< double >(w,1,n); 
                else 
                    return ILMath.diag(new ILArray< double >(w,1,n)); 
            } else if (info < 0) {
                throw new ILArgumentException("eigSymm: invalid parameter #" + (-info)); 
            } else {
                if (info <= n) {
                    throw new ILArgumentException(String.Format("eigSymm: did not converge! {0} off-diagonal elements unequal 0",info)); 
                } else if (info < 2*n) {
                    throw new ILArgumentException("eigSymm: B must be positive definite!");
                } else {
                    throw new ILArgumentException("eigSymm: unknown error"); 
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}

