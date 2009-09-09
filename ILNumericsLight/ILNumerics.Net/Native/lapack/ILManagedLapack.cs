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
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions;

namespace ILNumerics.Native
{
    public class ILManagedLapack : IILLapack
    {
        #region ?GEMM
        public void dgemm(char transa, char transb, int m, int n, int k, double alpha, IntPtr a, int lda, IntPtr b, int ldb, double beta, double[] c, int ldc)
        {
            unsafe
            {
                fixed (double* pc = c)
                    ManagedLapack.dgemm(transa, transb, m, n, k, alpha, (double*)a.ToPointer(),
                        lda, (double*)b.ToPointer(), ldb, beta, pc, ldc);
            }
        }
        public void zgemm(char transa, char transb, int m, int n, int k, complex alpha, IntPtr a, int lda, IntPtr b, int ldb, complex beta, complex[] c, int ldc)
        {
            throw new ILManagedLapackNotDoneException("zgemm");
        }
        #endregion 

        #region ?GESDD
        public void dgesdd(char jobz, int m, int n, double[] a, int lda, double[] s, double[] u, int ldu, double[] vt, int ldvt, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a, ps = s, pu = u, pvt = vt)
                {
                    fixed (int* pinfo = &info)
                    {
                        /* -first have to determine size of and allocate memory for work- */
                        double* work = stackalloc double[1];
                        int* iwork = stackalloc int[((m < n) ? m : n) * 8];

                        int lwork = -1;

                        ManagedLapack.dgesdd(jobz, m, n, pa, lda, ps, pu, ldu, pvt, ldvt, work, lwork, iwork, ref info);
                        lwork = (int)work[0];

                        if (lwork != 0)
                        {
                            double* dtmp = stackalloc double[lwork]; work = dtmp;
                            /* --------------------------------------------------------------------- */

                            ManagedLapack.dgesdd(jobz, m, n, pa, lda, ps, pu, ldu, pvt, ldvt, work, lwork, iwork, ref info);
                        }
                    }
                }
            }
        }
        public void zgesdd(char jobz, int m, int n, complex[] a, int lda, double[] s, complex[] u, int ldu, complex[] vt, int ldvt, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgesdd");
        }
        #endregion 

        #region ?GESVD
        public void dgesvd(char jobz, int m, int n, double[] a, int lda, double[] s, double[] u, int ldu, double[] vt, int ldvt, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgesvd");
        }
        public void zgesvd(char jobz, int m, int n, complex[] a, int lda, double[] s, complex[] u, int ldu, complex[] vt, int ldvt, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgesvd");
        }
        #endregion 
        
        #region ?POTRF - cholesky factorization
        public void dpotrf(char uplo, int n, double[] a, int lda, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a)
                    ManagedLapack.dpotrf(uplo, n, pa, lda, ref info);
            }
        }
        public void zpotrf(char uplo, int n, complex[] a, int lda, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zpotrf");
        }
        #endregion 

        #region ?POTRI - inverse via cholesky factorization
        public void dpotri(char uplo, int n, double[] A, int lda, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dpotri");
        }
        public void zpotri(char uplo, int n, complex[] A, int lda, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zpotri");
        }
        #endregion 

        #region ?POTRS - Solve via cholesky factors
        public void dpotrs(char uplo, int n, int nrhs, double[] a, int lda, double[] b, int ldb, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a, pb = b)
                    ManagedLapack.dpotrs(uplo, n, nrhs, pa, lda, pb, ldb, ref info);
            }
        }
        public void zpotrs(char uplo, int n, int nrhs, complex[] a, int lda, complex[] b, int ldb, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zpotrs");
        }
        #endregion

        #region ?getrf - LU factorization
        public void dgetrf(int m, int n, double[] a, int lda, int[] ipiv, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a)
                fixed (int* pipiv = ipiv)
                    ManagedLapack.dgetrf(m, n, pa, lda, pipiv, ref info);
            }
        }
        public void zgetrf(int m, int n, complex[] a, int lda, int[] ipiv, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgetrf");
        }
        #endregion 
        
        #region ?getri - inverse via LU factorization
        public void dgetri(int N, double[] A, int LDA, int[] IPIV, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgetri");
        }
        public void zgetri(int N, complex[] A, int LDA, int[] IPIV, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgetri");
        }
        #endregion 

        #region ORGQR
        public void dorgqr(int M, int N, int K, double[] A, int lda, double[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dorgqr");
        }
        public void zungqr(int M, int N, int K, complex[] A, int lda, complex[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zungqr");
        }
        #endregion

        #region ?geqrf - QR factorization
        public void dgeqrf(int M, int N, double[] A, int lda, double[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgeqrf");
        }
        public void zgeqrf(int M, int N, complex[] A, int lda, complex[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgeqrf");
        }
        #endregion 

        #region GEQP3
        public void dgeqp3(int M, int N, double[] A, int LDA, int[] JPVT, double[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgeqp3");
        }
        public void zgeqp3(int M, int N, complex[] A, int LDA, int[] JPVT, complex[] tau, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgeqp3");
        }
        #endregion

        #region ?ormqr - mmult of QR factorization result
        public void dormqr(char side, char trans, int m, int n, int k, double[] A, int lda, double[] tau, double[] C, int LDC, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dormqr");
        }
        #endregion 
        
        #region DTRTRS 
        public void dtrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dtrtrs");
        }
        public void ztrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info)
        {
            throw new ILManagedLapackNotDoneException("ztrtrs");
        }
        #endregion

        #region ?GETRS
        public void dgetrs(char trans, int n, int nrhs, double[] a, int lda, int[] ipiv, double[] b, int ldb, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a, pb = b)
                fixed (int* pipiv = ipiv)
                    ManagedLapack.dgetrs(trans, n, nrhs, pa, lda, pipiv, pb, ldb, ref info);
            }
        }
        public void zgetrs(char trans, int n, int nrhs, complex[] a, int lda, int[] ipiv, complex[] b, int ldb, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgetrs");
        }
        #endregion 

        #region ?GELSD - least square solution, SVD - divide & conquer
        public void dgelsd(int m, int n, int nrhs, double[] A, int lda, double[] B, int ldb, double[] S, double RCond, ref int rank, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgelsd");
        }
        public void zgelsd(int m, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, double[] S, double RCond, ref int rank, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgelsd");
        }
        #endregion 

        #region ?GELSY - least square solution, QRP
        public void dgelsy(int m, int n, int nrhs, double[] a, int lda, double[] b, int ldb, int[] jvpt0, double rcond, ref int rank, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a, pb = b)
                fixed (int* pjvpt0 = jvpt0)
                {
                    int lwork = -1;
                    double* work = stackalloc double[1];

                    ManagedLapack.dgelsy(m, n, nrhs, pa, lda, pb, ldb, pjvpt0, rcond, ref rank, work, lwork, ref info);

                    if (info != 0)
                        throw new ILArgumentException("?gelsy: unable to determine optimal block size. cancelling...");

                    lwork = (int)work[0];
                    double* tmp = stackalloc double[lwork]; work = tmp;

                    ManagedLapack.dgelsy(m, n, nrhs, pa, lda, pb, ldb, pjvpt0, rcond, ref rank, work, lwork, ref info);
                }
            }
        }
        public void zgelsy(int m, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, int[] JPVT0, double RCond, ref int rank, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgelsy");
        }
        #endregion 

        #region ?GEEVX - eigenvectors & -values, nonsymmetric A
        public void dgeevx(char balance, char jobvl, char jobvr, char sense, int n, double[] a, int lda, double[] wr, double[] wi, double[] vl, int ldvl, double[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info)
        {
            unsafe
            {
                fixed (double* pa = a, pwr = wr, pwi = wi, pvl = vl, pvr = vr, pscale = scale, prconde = rconde, prcondv = rcondv, pabnrm = &abnrm)
                {
                    /* -first have to determine size of and allocate memory for work- */
                    double* work = stackalloc double[1];
                    int* iwork = stackalloc int[2 * n - 2];

                    int lwork = -1;

                    ManagedLapack.dgeevx(balance, jobvl, jobvr, sense, n, pa, lda, pwr, pwi, pvl, ldvl, pvr, ldvr,
                        ref ilo, ref ihi, pscale, ref abnrm, prconde, prcondv, work, lwork, iwork, ref info);

                    if (info != 0) return;
                    lwork = (int)work[0];
                    double* tmp = stackalloc double[lwork]; work = tmp;
                    /* --------------------------------------------------------------------- */

                    ManagedLapack.dgeevx(balance, jobvl, jobvr, sense, n, pa, lda, pwr, pwi, pvl, ldvl, pvr, ldvr,
                        ref ilo, ref ihi, pscale, ref abnrm, prconde, prcondv, work, lwork, iwork, ref info);
                }
            }
        }
        public void zgeevx(char balance, char jobvl, char jobvr, char sense, int n, complex[] A, int lda, complex[] w, complex[] vl, int ldvl, complex[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zgeevx");
        }
        #endregion 

        #region ?GEEVR - eigenvectors & -values, symmetric/hermitian A 
        public void dsyevr(char jobz, char range, char uplo, int n, double[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, double[] z, int ldz, int[] isuppz, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dgsyevr");
        }
        public void zheevr(char jobz, char range, char uplo, int n, complex[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, complex[] z, int ldz, int[] isuppz, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zheevr");
        }
        #endregion 
        
        #region ?SYGV - eigenvectors & -values, symmetric/hermitian A and B, pos.def.B 
        public void dsygv(int itype, char jobz, char uplo, int n, double[] A, int lda, double[] B, int ldb, double[] w, ref int info)
        {
            throw new ILManagedLapackNotDoneException("dsygv");
        }
        public void zhegv(int itype, char jobz, char uplo, int n, complex[] A, int lda, complex[] B, int ldb, double[] w, ref int info)
        {
            throw new ILManagedLapackNotDoneException("zhegv");
        }
        #endregion 

    }
}
