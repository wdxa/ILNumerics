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

#pragma warning disable 1570
using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Native;
using System.Runtime.InteropServices;
using ILNumerics.Exceptions;
using System.Security; 
using ILNumerics.Misc; 

namespace ILNumerics.Native  {
    /// <summary>
    /// Generic LAPACK implementation, unsupported processor types
    /// </summary>
	public class ILLapackMKL10_0 : IILLapack {

        #region DLL INCLUDES 
        /*
        [DllImport("mkl_intel_thread", EntryPoint = "MKL_Set_Num_Threads")] 
        private static extern void mkl_set_num_threads(ref int num);
        [DllImport("libiomp5md", EntryPoint = "omp_set_num_threads")] 
        private static extern void omp_set_num_threads(ref int num);
        */

        [DllImport("mkl_custom", EntryPoint = "ilaenv",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern int mkl_ilaenv(ref int ispec, ref string name, ref string opts, ref int n1, ref int n2, ref int n3, ref int n4);

        ///////////////////////////   DOUBLE LAPACK /////////////////////////////////
        [DllImport("mkl_custom", EntryPoint = "DGEMM",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgemm(ref char TransA, ref char TransB, ref int M,ref int N, ref int K, ref  double alpha, IntPtr A, ref int lda, IntPtr B, ref int ldb, ref double beta, double[] C, ref int ldc);
        [DllImport("mkl_custom", EntryPoint = "ZGEMM",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		private static extern void mkl_zgemm(ref char TransA, ref char TransB, ref int M, ref int N, ref int K, ref complex alpha, IntPtr A, ref int lda, IntPtr B, ref int ldb, ref complex beta,[In,Out] complex [] C, ref int ldc);

        [DllImport("mkl_custom", EntryPoint = "DGESDD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		private static extern void mkl_dgesdd(ref char jobz, ref int m, ref int n,double[] a, ref int lda, double[] s,double[] u, ref int ldu, double[] vt,ref int ldvt, double[] work, ref int lwork,int[] iwork, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZGESDD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		private static extern void mkl_zgesdd(ref char jobz, ref int m, ref int n,[In, Out] complex[] a, ref int lda, double[] s,[In, Out] complex[] u, ref int ldu, [In, Out] complex[] vt,ref int ldvt, [In, Out] complex[] work, ref int lwork,[In,Out] double[] rwork, int[] iwork, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGESVD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		private static extern void mkl_dgesvd(ref char jobu, ref  char jobvt, ref int m, ref int n,double[] a, ref int lda, double[] s,double[] u, ref int ldu, double[] vt,ref int ldvt, double[] work, ref int lwork,int[] iwork,ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZGESVD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		private static extern void mkl_zgesvd(ref char jobu, ref  char jobvt, ref int m, ref int n,[In, Out] complex[] a, ref int lda, double[] s,[In, Out] complex[] u, ref int ldu, [In, Out] complex[] vt,ref int ldvt, [In, Out]  complex[] work, ref int lwork,int[] iwork,ref int info);

        [DllImport("mkl_custom", EntryPoint = "DPOTRF",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dpotrf (ref char uplo, ref int n, double [] A, ref int lda, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZPOTRF",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zpotrf (ref char uplo, ref int n, [In,Out] complex [] A, ref int lda, ref int info);
        
        [DllImport("mkl_custom", EntryPoint = "DPOTRI",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dpotri (ref char uplo,ref  int n, double [] A, ref int lda, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZPOTRI",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zpotri (ref char uplo, ref int n, [In,Out] complex [] A, ref int lda,ref int info);

        [DllImport("mkl_custom", EntryPoint = "DPOTRS",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dpotrs (ref char uplo,ref  int n, ref int NRHS, double [] A, ref int lda, double[] B, ref int ldb, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZPOTRS",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zpotrs (ref char uplo,ref  int n, ref int NRHS, [In,Out] complex [] A, ref int lda, [In,Out] complex[] B, ref int ldb, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGETRF",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgetrf (ref int M, ref int N, double [] A, ref int LDA, int[] IPIV, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZGETRF",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgetrf (ref int M, ref int N, [In,Out] complex [] A, ref int LDA, int [] IPIV, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGETRI",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgetri (ref int N, double[] A,ref  int LDA, int[] IPIV, double[] work, ref int lwork, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZGETRI",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgetri (ref int N, [In,Out] complex [] A, ref int LDA, int [] IPIV, [In,Out] complex[] work, ref int lwork, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGEQRF",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgeqrf (ref int M, ref int N, double [] A, ref int lda, double [] tau, double[] work, ref int lwork, ref int info);
        [DllImport("mkl_custom", EntryPoint = "CGEQRF", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgeqrf(ref int M, ref int N, [In, Out] complex[] A, ref int lda, [In, Out] complex[] tau, [In, Out] complex[] work, ref int lwork, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGEQP3",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgeqp3 (ref int M, ref int N, double [] A, ref int LDA, int [] JPVT, double [] tau, double [] work, ref int lwork, ref int info );
        [DllImport("mkl_custom", EntryPoint = "ZGEQP3",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgeqp3 (ref int M, ref int N, [In,Out] complex [] A, ref int LDA, [In,Out] int [] JPVT, [In,Out] complex [] tau, [In,Out] complex [] work, ref int lwork, [In,Out] double [] rwork, ref int info );

        [DllImport("mkl_custom", EntryPoint = "DORMQR",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dormqr (ref char side, ref char trans, ref int m, ref int n, ref int k, double[] A, int lda, double[] tau, double[] C, ref int ldc, ref int info);
        
        [DllImport("mkl_custom", EntryPoint = "DORGQR",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dorgqr (ref int m, ref int n, ref int k, double[] A,ref int lda, double[] tau, double[] work, ref int lwork, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZUNGQR",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zungqr (ref int m, ref int n, ref int k, [In,Out] complex[] A,ref int lda, [In,Out] complex[] tau, [In,Out] complex[] work, ref int lwork, ref int info);
        
        [DllImport("mkl_custom", EntryPoint = "DTRTRS", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dtrtrs (ref char uplo, ref char transA, ref char diag, ref int N, ref int nrhs, IntPtr A, ref int LDA, IntPtr B, ref int LDB, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZTRTRS",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_ztrtrs (ref char uplo, ref char transA, ref char diag, ref int N, ref int nrhs, IntPtr A, ref int LDA, IntPtr B, ref int LDB, ref int info);
        
        [DllImport("mkl_custom", EntryPoint = "DGETRS",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgetrs(ref char trans, ref int N, ref int NRHS, double[] A, ref int LDA, int[] IPIV, double[] B, ref int LDB, ref int info);
        [DllImport("mkl_custom", EntryPoint = "ZGETRS",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgetrs(ref char trans, ref int N, ref int NRHS, [In,Out] complex[] A, ref int LDA, int[] IPIV, [In,Out] complex[] B, ref int LDB, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DGELSD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgelsd (ref int m,ref int n,ref int nrhs, double[] A,ref int lda, double[] B,ref int ldb, double[] S, ref double RCond, ref int rank, double[] work,ref int lwork, int[] iwork, ref int info); 
        [DllImport("mkl_custom", EntryPoint = "ZGELSD",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgelsd (ref int m,ref int n,ref int nrhs, [In,Out] complex[] A,ref int lda, [In,Out] complex[] B,ref int ldb, double[] S, ref double RCond, ref int rank, [In,Out]  complex[] work,ref int lwork, double[] rwork, int[] iwork, ref int info); 
        
        [DllImport("mkl_custom", EntryPoint = "DGELSY",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgelsy (ref int m,ref int n,ref int nrhs, double[] A,ref int lda, double[] B,ref int ldb, int[] JPVT0, ref double RCond, ref int rank, double[] work, ref int lwork, ref int info); 
        [DllImport("mkl_custom", EntryPoint = "ZGELSY",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zgelsy (ref int m,ref int n,ref int nrhs, [In,Out] complex[] A,ref int lda, [In,Out] complex[] B,ref int ldb, int[] JPVT0, ref double RCond, ref int rank, [In,Out]  complex[] work, ref int lwork, double[] rwork, ref int info); 
        
        [DllImport("mkl_custom", EntryPoint = "DGEEVX",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dgeevx (ref char balance, ref char jobvl, ref char jobvr, ref char sense, ref int n,            double[] A, ref int lda,          double[] wr, double[] wi, double[] vl, ref int ldvl,            double[] vr, ref int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, double[] work, ref int lwork, int [] iwork, ref int info); 
        [DllImport("mkl_custom", EntryPoint = "ZGEEVX",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]       
        private static extern void mkl_zgeevx (ref char balance, ref char jobvl, ref char jobvr, ref char sense, ref int n, [In,Out]  complex[] A, ref int lda, [In,Out] complex[]  w,   [In,Out] complex[] vl, ref int ldvl, [In,Out]  complex[] vr, ref int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, [In,Out] complex[] work, ref int lwork, double[] rwork, ref int info);

        [DllImport("mkl_custom", EntryPoint = "DSYEVR",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dsyevr (ref char jobz, ref char range, ref char uplo, ref int n,          double  [] A, ref int lda, ref double vl, ref double vu, ref int il, ref int iu, ref double abstol, ref int m, double[] w,          double  [] z, ref int ldz, int[] isuppz, double[] work, ref int lwork, int[] iwork, ref int liwork, ref int info); 
        [DllImport("mkl_custom", EntryPoint = "ZHEEVR",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zheevr (ref char jobz, ref char range, ref char uplo, ref int n, [In,Out] complex [] A, ref int lda, ref double vl, ref double vu, ref int il, ref int iu, ref double abstol, ref int m, double[] w, [In,Out] complex [] z, ref int ldz, int[] isuppz, [In,Out] complex[] work, ref int lwork, double[] rwork, ref int lrwork, int[] iwork, ref int liwork, ref int info); 

        [DllImport("mkl_custom", EntryPoint = "DSYGV",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_dsygv (ref int itype, ref char jobz, ref char uplo, ref int n, double  [] A, ref int lda, double  [] B, ref int ldb, double [] w, double [] work, ref int lwork, ref int info); 
        [DllImport("mkl_custom", EntryPoint = "ZHEGV",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        private static extern void mkl_zhegv (ref int itype, ref char jobz, ref char uplo, ref int n, [In,Out] complex [] A, ref int lda, [In,Out] complex  [] B, ref int ldb, double [] w, [In,Out]  complex[] work , ref int lwork, double[] rwork, ref int info); 
         
#endregion DLL INCLUDES 

        public ILLapackMKL10_0() {
            //int num = Environment.ProcessorCount; 
            //omp_set_num_threads(ref num); 
            //omp_set_num_threads(ref num); 
            //mkl_set_num_threads(ref num); 
        }

        #region ILLAPACK INTERFACE 

        private int ILAENV (int ispec, string name, string opts, int n1, int n2, int n3, int n4) {
            return mkl_ilaenv(ref ispec, ref name, ref opts, ref n1, ref n2, ref n3, ref n4); 
        }

        /// <summary>
        /// Implement wrapper for ATLAS GeneralMatrixMultiply
        /// </summary>
        /// <param name="TransA">Transposition state for matrix A: one of the constants in enum CBlas_Transpose</param>
        /// <param name="TransB">Transposition state for matrix B: one of the constants in enum CBlas_Transpose</param>
        /// <param name="M">Number of rows in A</param>
        /// <param name="N">Number of columns in B</param>
        /// <param name="K">Number of columns in A and number of rows in B</param>
        /// <param name="alpha">multiplicationi factor for A</param>
        /// <param name="A">pointer to double array A</param>
        /// <param name="lda">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix B</param>
        /// <param name="B">pointer to double array B</param>
        /// <param name="ldb">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix A</param>
        /// <param name="beta">multiplication faktor for matrix B</param>
        /// <param name="C">pointer to predefined double array C of neccessary length</param>
        /// <param name="ldc">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix C</param>
        /// <remarks>All parameters except C are readonly. Only elements of matrix C will be altered. C must be a predefined 
        /// continous double array of size MxN</remarks>
        public void dgemm(char TransA, char TransB, int M, int N, int K, double alpha, IntPtr A, int lda, IntPtr B, int ldb, double beta, double[] C, int ldc) {
            mkl_dgemm(ref TransA, ref TransB, ref M, ref  N, ref  K, ref  alpha, A, ref lda, B, ref ldb, ref  beta, C, ref  ldc);
        }
        /// <summary>
        /// Implement wrapper for ATLAS GeneralMatrixMultiply
        /// </summary>
        /// <param name="TransA">Transposition state for matrix A: one of the constants in enum CBlas_Transpose</param>
        /// <param name="TransB">Transposition state for matrix B: one of the constants in enum CBlas_Transpose</param>
        /// <param name="M">Number of rows in A</param>
        /// <param name="N">Number of columns in B</param>
        /// <param name="K">Number of columns in A and number of rows in B</param>
        /// <param name="alpha">multiplicationi factor for A</param>
        /// <param name="A">pointer to double array A</param>
        /// <param name="lda">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix B</param>
        /// <param name="B">pointer to double array B</param>
        /// <param name="ldb">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix A</param>
        /// <param name="beta">multiplication faktor for matrix B</param>
        /// <param name="C">pointer to predefined double array C of neccessary length</param>
        /// <param name="ldc">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix C</param>
        /// <remarks>All parameters except C are readonly. Only elements of matrix C will be altered. C must be a predefined 
        /// continous double array of size MxN</remarks>
        public void zgemm(char TransA, char TransB, int M, int N, int K, complex alpha, IntPtr A, int lda, IntPtr B, int ldb, complex beta, complex[] C, int ldc) {
            mkl_zgemm(ref TransA, ref TransB, ref M, ref  N, ref  K, ref  alpha, A, ref lda, B, ref ldb, ref  beta, C, ref  ldc);
        }

        public void dgesdd (char jobz, int m, int n, double [] a, int lda, double [] s, double [] u, int ldu, double [] vt, int ldvt, ref int info) {
            try {
                double [] work = new double [1] { ( double )0.0 };
                int lwork = -1;
                int[] iwork = new int[((m < n) ? m : n) * 8];
                mkl_dgesdd (ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                if (work[0] != 0) {
                    work = new double [(int)work[0]];
                    lwork = work.Length;
                    mkl_dgesdd (ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                }
            } catch (Exception e) {
                if (e is OutOfMemoryException) {
                    dgesvd (jobz, m, n, a, lda, s, u, ldu, vt, ldvt, ref info); 
                }
                throw new ILException("Unable to do " + "dgesdd"  + ".", e); 
            }
        }

        public void zgesdd (char jobz, int m, int n, complex [] a, int lda, double [] s, complex [] u, int ldu, complex [] vt, int ldvt, ref int info)
        {
            try {
                complex [] work = new complex [1] { ( complex )0.0 };
                double [] rwork; 
                int minMN = (m < n) ? m : n;
                if (jobz == 'N') {
                    rwork = new double [minMN * 7];  
                } else {
                    rwork = new double [5 * minMN * minMN + 5 * minMN];  
                }
                int lwork = -1;
                int[] iwork = new int[minMN * 8];
                mkl_zgesdd (ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, rwork, iwork, ref info);
                if (work[0] != 0) {
                    work = new complex [(int)work[0].real];
                    lwork = work.Length;
                    mkl_zgesdd (ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork,rwork, iwork, ref info);
                }
            } catch (Exception e) {
                if (e is OutOfMemoryException) {
                    zgesvd (jobz, m, n, a, lda, s, u, ldu, vt, ldvt, ref info); 
                }
                throw new ILException("Unable to do " +  "zgesdd"  + ".", e); 
            }
        }

        #region HYCALPER LOOPSTART GESVD
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        outArrS
    </source>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        outArrU
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zgesvd</destination>
</type>
<type>
    <source locate="after">
        dll1func
    </source>
    <destination>mkl_zgesvd</destination>
</type>
</hycalper>
*/

        /// <summary>
        /// singular value decomposition
        /// </summary>
        /// <param name="jobz"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="lda"></param>
        /// <param name="s"></param>
        /// <param name="u"></param>
        /// <param name="ldu"></param>
        /// <param name="vt"></param>
        /// <param name="ldvt"></param>
        /// <param name="info"></param>
        public void /*!HC:dllfunc*/ dgesvd (char jobz, int m, int n, /*!HC:inArr1*/ double [] a, int lda,
                           /*!HC:outArrS*/ double [] s, /*!HC:outArrU*/ double [] u, int ldu, /*!HC:outArrU*/ double [] vt, int ldvt, ref int info) {
            if (jobz != 'A' && jobz != 'S' && jobz != 'N')
                throw new ILArgumentException("Argument jobz must be one of 'A','S' or 'N'"); 
            try {
                /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1] { (/*!HC:inArr1*/ double )0.0 };
                int lwork = -1;
                int[] iwork = new int[((m < n) ? m : n) * 8];
                /*!HC:dll1func*/ mkl_dgesvd (ref jobz, ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                if (work[0] != 0) {
                    work = new /*!HC:inArr1*/ double [(int)work[0]];
                    lwork = work.Length; 
                    /*!HC:dll1func*/ mkl_dgesvd (ref jobz, ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                }
            } catch (Exception e) {
                if (e is OutOfMemoryException) {
                    throw new ILMemoryException("Not enough memory for given arguments."); 
                }
                throw new ILException("Unable to do gesvd.", e);
            }
        }
        #endregion HYCALPER LOOPEND GESVD
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       

        /// <summary>
        /// singular value decomposition
        /// </summary>
        /// <param name="jobz"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="lda"></param>
        /// <param name="s"></param>
        /// <param name="u"></param>
        /// <param name="ldu"></param>
        /// <param name="vt"></param>
        /// <param name="ldvt"></param>
        /// <param name="info"></param>
        public void  zgesvd (char jobz, int m, int n,  complex [] a, int lda,
                           double [] s,  complex [] u, int ldu,  complex [] vt, int ldvt, ref int info) {
            if (jobz != 'A' && jobz != 'S' && jobz != 'N')
                throw new ILArgumentException("Argument jobz must be one of 'A','S' or 'N'"); 
            try {
                complex [] work = new  complex [1] { ( complex )0.0 };
                int lwork = -1;
                int[] iwork = new int[((m < n) ? m : n) * 8];
                mkl_zgesvd (ref jobz, ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                if (work[0] != 0) {
                    work = new  complex [(int)work[0]];
                    lwork = work.Length; 
                    mkl_zgesvd (ref jobz, ref jobz, ref m, ref n, a, ref lda, s, u, ref ldu, vt, ref ldvt, work, ref lwork, iwork, ref info);
                }
            } catch (Exception e) {
                if (e is OutOfMemoryException) {
                    throw new ILMemoryException("Not enough memory for given arguments."); 
                }
                throw new ILException("Unable to do gesvd.", e);
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        public void dpotrf(char uplo, int n, double[] A, int lda, ref int info) {
            mkl_dpotrf(ref uplo, ref n, A, ref lda, ref info);
        }
        public void zpotrf(char uplo, int n, complex[] A, int lda, ref int info) {
            mkl_zpotrf(ref uplo, ref n, A, ref lda, ref info);
        }


        public void dpotri(char uplo, int n, double[] A, int lda, ref int info) {
            mkl_dpotri(ref uplo, ref n, A, ref lda, ref info);
        }
        public void zpotri(char uplo, int n, complex[] A, int lda, ref int info) {
            mkl_zpotri(ref uplo, ref n, A, ref lda, ref info);
        }


        public void dgetrf(int M, int N, double[] A, int LDA, int[] IPIV, ref int info) {
            mkl_dgetrf(ref M, ref N, A, ref LDA, IPIV, ref info);
        }
        public void zgetrf(int M, int N, complex[] A, int LDA, int[] IPIV, ref int info) {
            mkl_zgetrf(ref M, ref N, A, ref LDA, IPIV, ref info);
        }

        #region HYCALPER LOOPSTART ?GETRI 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        outArrS
    </source>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        outArrU
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zgetri</destination>
</type>
<type>
    <source locate="after">
        dll1func
    </source>
    <destination>mkl_zgetri</destination>
</type>
</hycalper>
*/
        public void /*!HC:dllfunc*/ dgetri (int N, /*!HC:inArr1*/ double [] A, int LDA, int[] IPIV, ref int info) {
            /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1];  
            int lwork = -1; 
            try {
                /*!HC:dll1func*/ mkl_dgetri (ref N, A, ref LDA, IPIV, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new /*!HC:inArr1*/ double [lwork]; 
                    /*!HC:dll1func*/ mkl_dgetri (ref N, A, ref LDA, IPIV, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_dgetri"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on dgetri. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }
        #endregion HYCALPER LOOPEND ?GETRI
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        public void  zgetri (int N,  complex [] A, int LDA, int[] IPIV, ref int info) {
            complex [] work = new  complex [1];  
            int lwork = -1; 
            try {
                mkl_zgetri (ref N, A, ref LDA, IPIV, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new  complex [lwork]; 
                    mkl_zgetri (ref N, A, ref LDA, IPIV, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_dgetri"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on dgetri. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART ?GEQRF 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zgeqrf</destination>
</type>
<type>
    <source locate="after">
        dll1func
    </source>
    <destination>mkl_zgeqrf</destination>
</type>
</hycalper>
*/
        public void /*!HC:dllfunc*/ dgeqrf (int M, int N, /*!HC:inArr1*/ double [] A, int lda, /*!HC:inArr1*/ double [] tau, ref int info) {
            /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1];  
            int lwork = -1; 
            try {
                /*!HC:dll1func*/ mkl_dgeqrf (ref M, ref N, A, ref lda, tau, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new /*!HC:inArr1*/ double [lwork]; 
                    /*!HC:dll1func*/ mkl_dgeqrf (ref M, ref N, A, ref lda, tau, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_?geqrf"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?geqrf. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }
        #endregion HYCALPER LOOPEND GEQRF
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        public void  zgeqrf (int M, int N,  complex [] A, int lda,  complex [] tau, ref int info) {
            complex [] work = new  complex [1];  
            int lwork = -1; 
            try {
                mkl_zgeqrf (ref M, ref N, A, ref lda, tau, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new  complex [lwork]; 
                    mkl_zgeqrf (ref M, ref N, A, ref lda, tau, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_?geqrf"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?geqrf. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        public void dormqr(char side, char trans, int m, int n, int k, double[] A, int lda, double[] tau, double[] C, int LDC, ref int info) {
            throw new Exception("The method or operation is not implemented.");
        }

        #region HYCALPER LOOPSTART ?ORGQR  / UNGQR 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zungqr</destination>
</type>
<type>
    <source locate="after">
        mkl_***gqr
    </source>
    <destination>mkl_zungqr</destination>
</type>
</hycalper>
*/
        public void /*!HC:dllfunc*/ dorgqr (int M, int N, int K, /*!HC:inArr1*/ double [] A, int lda, /*!HC:inArr1*/ double [] tau, ref int info) {
            /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1];  
            int lwork = -1; 
            try {
                /*!HC:mkl_***gqr*/ mkl_dorgqr (ref M, ref N, ref K, A, ref lda, tau, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new /*!HC:inArr1*/ double [lwork]; 
                    /*!HC:mkl_***gqr*/ mkl_dorgqr (ref M, ref N, ref K, A, ref lda, tau, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_?[un/or]gqr"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?[un/or]gqr. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }
        #endregion HYCALPER LOOPEND ?ORGQR / UNGQR
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        public void  zungqr (int M, int N, int K,  complex [] A, int lda,  complex [] tau, ref int info) {
            complex [] work = new  complex [1];  
            int lwork = -1; 
            try {
                mkl_zungqr (ref M, ref N, ref K, A, ref lda, tau, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = new  complex [lwork]; 
                    mkl_zungqr (ref M, ref N, ref K, A, ref lda, tau, work, ref lwork, ref info);
                } else {
                    throw new ILException("error in mkl_?[un/or]gqr"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?[un/or]gqr. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART ?GEQP3 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zgeqp3</destination>
</type>
<type>
    <source locate="nextline">
        dll1func
    </source>
    <destination>mkl_zgeqp3 (ref M, ref N, A, ref LDA, JPVT, tau, work, ref lwork, rwork, ref info);</destination>
</type>
<type>
    <source locate="nextline">
        cmplxRwork
    </source>
    <destination>double[] rwork = new double[2 * N];</destination>
</type>
</hycalper>
*/
        public void /*!HC:dllfunc*/ dgeqp3 ( int M,int N,/*!HC:inArr1*/ double [] A,int LDA,int [] JPVT,/*!HC:inArr1*/ double [] tau, ref int info ) {
            /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1];
            int lwork = -1; 
            try {
                /*!HC:cmplxRwork*/ 
                /*dummy*/
                /*!HC:dll1func*/ 
                mkl_dgeqp3 (ref M, ref N, A, ref LDA, JPVT, tau, work, ref lwork, ref info); 
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = ILMemoryPool.Pool.New< /*!HC:inArr1*/ double >(lwork); 
                    /*!HC:dll1func*/ 
                    mkl_dgeqp3 (ref M, ref N, A, ref LDA, JPVT, tau, work, ref lwork, ref info);
                    ILMemoryPool.Pool.RegisterObject(work); 
                } else {
                    throw new ILException("error in mkl_?geqp3"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?geqp3. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }
        #endregion HYCALPER LOOPEND GEQP3
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        public void  zgeqp3 ( int M,int N, complex [] A,int LDA,int [] JPVT, complex [] tau, ref int info ) {
            complex [] work = new  complex [1];
            int lwork = -1; 
            try {
                double[] rwork = new double[2 * N];
                mkl_zgeqp3 (ref M, ref N, A, ref LDA, JPVT, tau, work, ref lwork, rwork, ref info);
                lwork = (int)work[0]; 
                if (lwork > 0 && info == 0) {
                    work = ILMemoryPool.Pool.New<  complex >(lwork); 
                    mkl_zgeqp3 (ref M, ref N, A, ref LDA, JPVT, tau, work, ref lwork, rwork, ref info);
                    ILMemoryPool.Pool.RegisterObject(work); 
                } else {
                    throw new ILException("error in mkl_?geqp3"); 
                }
            } catch (OutOfMemoryException e) {
                throw new ILException("error on ?geqp3. Not enough memory! " + (lwork * Marshal.SizeOf( work[0] )).ToString() + " bytes has been requested.",e); 
            }
        }

#endregion HYCALPER AUTO GENERATED CODE

        public void dtrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info) {
            mkl_dtrtrs(ref uplo, ref transA, ref diag, ref N, ref nrhs, A, ref LDA, B, ref LDB, ref info); 
        }
        public void ztrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info) {
            mkl_ztrtrs(ref uplo, ref transA, ref diag, ref N, ref nrhs, A, ref LDA, B, ref LDB, ref info); 
        }

        public void dgetrs(char trans, int N, int NRHS, double[] A, int LDA, int[] IPIV, double[] B, int LDB, ref int info) {
            mkl_dgetrs(ref trans,ref N,ref NRHS, A, ref LDA, IPIV, B, ref LDB, ref info);     
        }
        public void zgetrs(char trans, int N, int NRHS, complex[] A, int LDA, int[] IPIV, complex[] B, int LDB, ref int info) {
            mkl_zgetrs(ref trans,ref N,ref NRHS, A, ref LDA, IPIV, B, ref LDB, ref info);
        }
        
        public void dpotrs(char uplo, int n, int nrhs, double[] A, int lda, double[] B, int ldb, ref int info) {
            mkl_dpotrs(ref uplo, ref n, ref nrhs, A, ref lda, B, ref ldb, ref info); 
        }
        public void zpotrs(char uplo, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, ref int info) {
            mkl_zpotrs(ref uplo, ref n, ref nrhs, A, ref lda, B, ref ldb, ref info); 
        }

        #region HYCALPER LOOPSTART ?gelsd 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        dllfunc
    </source>
    <destination>zgelsd </destination>
</type>
<type>
    <source locate="after">
        dll1func
    </source>
    <destination>mkl_zgeqrf</destination>
</type>
<type>
    <source locate="after">
        mkl_?gelsd
    </source>
    <destination>mkl_zgelsd</destination>
</type>
<type>
    <source locate="nextline">
        HycalpTag1
    </source>
    <destination>double [] rwork = new double [1];  mkl_zgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, rwork, iwork, ref info);</destination>
</type>
<type>
    <source locate="nextline">
        HycalpTag2
    </source>
    <destination>rwork = new double [(int)rwork[0]];  mkl_zgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, rwork, iwork, ref info);</destination>
</type>
</hycalper>
*/
        public void /*!HC:dllfunc*/ dgelsd (int m, int n, int nrhs, /*!HC:inArr1*/ double [] A, int lda, /*!HC:inArr1*/ double [] B, int ldb, /*!HC:inArr2*/ double [] S, /*!HC:inArr2*/ double RCond, ref int rank, ref int info) {
            /*!HC:inArr1*/ double [] work = new /*!HC:inArr1*/ double [1]; 
            int [] iwork = new int[1]; 
            int lwork = -1; 
            /*HC:HycalpTag1*/
            mkl_dgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, iwork, ref info);
            if (info != 0) 
                throw new ILArgumentException("dgelsd: invalid parameter: #" + (-info).ToString());
            lwork = (int)work[0]; //ILAENV(9, "dgelsd", " ",0,0,0,0); 
            if (lwork <= 0)
                throw new ILArgumentException("dgelsd: unknown error determining working size lwork");
            iwork = new int[lwork * 1000];
            
            work = ILMemoryPool.Pool.New< /*!HC:inArr1*/ double >(lwork); 
            /*HC:HycalpTag2*/
            mkl_dgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, iwork, ref info);
            ILMemoryPool.Pool.RegisterObject(work);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        public void  zgelsd  (int m, int n, int nrhs,  complex [] A, int lda,  complex [] B, int ldb,  double [] S,  double RCond, ref int rank, ref int info) {
            complex [] work = new  complex [1]; 
            int [] iwork = new int[1]; 
            int lwork = -1; 
            double [] rwork = new double [1];  mkl_zgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, rwork, iwork, ref info);
            if (info != 0) 
                throw new ILArgumentException("dgelsd: invalid parameter: #" + (-info).ToString());
            lwork = (int)work[0]; //ILAENV(9, "dgelsd", " ",0,0,0,0); 
            if (lwork <= 0)
                throw new ILArgumentException("dgelsd: unknown error determining working size lwork");
            iwork = new int[lwork * 1000];
            
            work = ILMemoryPool.Pool.New<  complex >(lwork); 
            rwork = new double [(int)rwork[0]];  mkl_zgelsd (ref m, ref n, ref nrhs, A, ref lda, B, ref ldb, S,ref RCond, ref rank, work, ref lwork, rwork, iwork, ref info);
            ILMemoryPool.Pool.RegisterObject(work);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region ?gelsy  
        public void dgelsy (int m, int n, int nrhs, double [] A, int lda, double [] B, int ldb, int[] JPVT0, double RCond, ref int rank, ref int info) {
            int lwork = -1;
            double [] work = new double [1]; 
            mkl_dgelsy (ref m,ref n,ref nrhs,A,ref lda,B,ref ldb,JPVT0,ref RCond,ref rank,work,ref lwork,ref info);
            if (info != 0)
                throw new ILArgumentException("?gelsy: unable to determine optimal block size. cancelling...");
            lwork = (int) work[0];
            work = ILMemoryPool.Pool.New<double>(lwork);
            mkl_dgelsy (ref m,ref n,ref nrhs,A,ref lda,B,ref ldb,JPVT0,ref RCond,ref rank,work,ref lwork,ref info);
            ILMemoryPool.Pool.RegisterObject(work); 
        }
        public void  zgelsy  (int m, int n, int nrhs,  complex [] A, int lda,  complex [] B, int ldb, int[] JPVT0,  double RCond, ref int rank, ref int info) {
            int lwork = -1;
            complex [] work = new  complex [1]; 
            double[] rwork = new double[1];
            mkl_zgelsy (ref m,ref n,ref nrhs,A,ref lda,B,ref ldb,JPVT0,ref RCond,ref rank,work,ref lwork, rwork, ref info);
            if (info != 0)
                throw new ILArgumentException("?gelsy: unable to determine optimal block size. cancelling...");
            lwork = (int) work[0];
            work = ILMemoryPool.Pool.New<complex>(lwork);
            rwork = ILMemoryPool.Pool.New<double>(lwork);
            mkl_zgelsy (ref m,ref n,ref nrhs,A,ref lda,B,ref ldb,JPVT0,ref RCond,ref rank,work,ref lwork, rwork, ref info);
            ILMemoryPool.Pool.RegisterObject(work); 
            ILMemoryPool.Pool.RegisterObject(rwork); 
        }
       
#endregion

        #region ?GEEVX
        public void dgeevx(char balance, char jobvl, char jobvr, char sense, int n, double[] A, int lda, double[] wr, double[] wi, double[] vl, int ldvl, double[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info) {
            double [] work = new double[1]; 
            int lwork = -1;
            int [] iwork = ILMemoryPool.Pool.New<int>(2 * n - 2);
            mkl_dgeevx(ref balance, ref jobvl, ref jobvr, ref sense, ref n, A, ref lda, wr, wi, vl, ref ldvl, vr, ref ldvr, ref ilo, ref ihi, scale, ref abnrm, rconde, rcondv, work, ref lwork, iwork, ref info);
            if (info != 0) 
                throw new ILArgumentException("error in lapack call: ?geevx. (" + info + ")");
            lwork = (int)work[0]; 
            work = ILMemoryPool.Pool.New<double>(lwork); 
            mkl_dgeevx(ref balance, ref jobvl, ref jobvr, ref sense, ref n, A, ref lda, wr, wi, vl, ref ldvl, vr, ref ldvr, ref ilo, ref ihi, scale, ref abnrm, rconde, rcondv, work, ref lwork, iwork, ref info);
            ILMemoryPool.Pool.RegisterObject(work);
            ILMemoryPool.Pool.RegisterObject(iwork);
        }
        public void zgeevx(char balance, char jobvl, char jobvr, char sense, int n, complex[] A, int lda, complex[] w, complex[] vl, int ldvl, complex[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info) {
            complex [] work = new complex[1]; 
            int lwork = -1;
            double[] rwork = ILMemoryPool.Pool.New<double>(2 * n); 
            mkl_zgeevx(ref balance, ref jobvl, ref jobvr, ref sense, ref n, A, ref lda, w, vl, ref ldvl, vr, ref ldvr, ref ilo, ref ihi, scale, ref abnrm, rconde, rcondv, work, ref lwork, rwork, ref info);
            if (info != 0) 
                throw new ILArgumentException("error in lapack call: ?geevx. (" + info + ")");
            lwork = (int)work[0]; 
            work = ILMemoryPool.Pool.New<complex>(lwork); 
            mkl_zgeevx(ref balance, ref jobvl, ref jobvr, ref sense, ref n, A, ref lda, w, vl, ref ldvl, vr, ref ldvr, ref ilo, ref ihi, scale, ref abnrm, rconde, rcondv, work, ref lwork, rwork, ref info);
            ILMemoryPool.Pool.RegisterObject(work);
            ILMemoryPool.Pool.RegisterObject(rwork);
        }
        #endregion

        #region ?syevr
        public void dsyevr(char jobz, char range, char uplo, int n, double[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, double[] z, int ldz, int[] isuppz, ref int info) {
            double [] work = new double[1]; 
            int lwork = -1, liwork = -1; 
            int [] iwork = new int[1]; 
            //byte jz = (byte)jobz,rn = (byte) range,ul = (byte)uplo; 
            mkl_dsyevr(ref jobz,ref range,ref uplo,ref n, A,ref lda, ref vl, ref vu, ref il, ref iu, ref abstol,ref m, w,z,ref ldz,isuppz, work,ref lwork,iwork,ref liwork,ref info);
            if (info != 0) {
                throw new ILArgumentException("?syevr: error returned from lapack: " + info);
            }
            lwork = (int)work[0]; 
            bool dummy; 
            work = ILMemoryPool.Pool.New<double>(lwork,true, out dummy);
            liwork = (int) iwork[0]; 
            iwork = ILMemoryPool.Pool.New<int>(liwork,true, out dummy);
            mkl_dsyevr(ref jobz,ref range,ref uplo,ref n, A,ref lda, ref vl, ref vu, ref il, ref iu, ref abstol,ref m, w,z,ref ldz,isuppz, work,ref lwork,iwork,ref liwork,ref info);
            ILMemoryPool.Pool.RegisterObject(iwork); 
            ILMemoryPool.Pool.RegisterObject(work); 
        }
        public void zheevr(char jobz, char range, char uplo, int n, complex[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, complex[] z, int ldz, int[] isuppz, ref int info) {
            complex[] work = new complex[1]; 
            double [] rwork = new double[1]; 
            int [] iwork = new int[1]; 
            int lrwork = -1, liwork = -1, lwork = -1; 
            mkl_zheevr(ref jobz,ref range,ref uplo,ref n, A,ref lda, ref vl, ref vu, ref il, ref iu, ref abstol,ref m, w,z,ref ldz,isuppz, work,ref lwork,rwork,ref lrwork, iwork,ref liwork,ref info);
            if (info != 0) {
                throw new ILArgumentException("?syevr: error returned from lapack: " + info);
            }
            lrwork = (int)rwork[0]; 
            rwork = ILMemoryPool.Pool.New<double>(lrwork);
            lwork = (int) work[0]; 
            work = ILMemoryPool.Pool.New<complex>(lwork); 
            liwork = (int) iwork[0]; 
            iwork = ILMemoryPool.Pool.New<int>(liwork); 
            mkl_zheevr(ref jobz,ref range,ref uplo,ref n, A,ref lda, ref vl, ref vu, ref il, ref iu, ref abstol,ref m, w,z,ref ldz,isuppz, work,ref lwork,rwork,ref lrwork,iwork,ref liwork,ref info);
            ILMemoryPool.Pool.RegisterObject(iwork); 
            ILMemoryPool.Pool.RegisterObject(work); 
            ILMemoryPool.Pool.RegisterObject(rwork); 
        }
        #endregion 

        #region ?[he/sy]gv - generalized eigenproblem
        public void dsygv (int itype, char jobz, char uplo, int n, double  [] A, int lda, double  [] B, int ldb, double [] w, ref int info) {
            // query workspace 
            int lwork = -1; 
            double [] work = new double[1] {0.0}; 
            mkl_dsygv (ref itype,ref jobz,ref uplo,ref n, A,ref lda, B,ref ldb, w, work, ref lwork, ref info); 
            if (info != 0 || work[0] <= 0.0) return; 
            // create temporary array(s)
            lwork = (int) work[0]; 
            work = ILMemoryPool.Pool.New<double>(lwork); 
            mkl_dsygv (ref itype,ref jobz,ref uplo,ref n, A,ref lda, B,ref ldb, w, work, ref lwork, ref info); 
            ILMemoryPool.Pool.RegisterObject(work); 
        }        
        public void zhegv (int itype, char jobz, char uplo, int n, complex [] A, int lda, complex [] B, int ldb, double [] w, ref int info) { 
            // query workspace 
            int lwork = -1; 
            complex [] work = new complex[1] {0.0f}; 
            double [] rwork = ILMemoryPool.Pool.New<double>(Math.Max(1,3*n-2)); 
            mkl_zhegv(ref itype,ref  jobz,ref  uplo,ref  n, A,ref  lda, B,ref  ldb, w, work, ref lwork, rwork, ref info); 
            if (info != 0 || work[0] <= 0.0) return; 
            // create temporary array(s)
            lwork = (int) work[0]; 
            work = ILMemoryPool.Pool.New<complex>(lwork); 
            mkl_zhegv (ref itype,ref  jobz,ref  uplo,ref  n, A,ref  lda, B,ref  ldb, w, work, ref lwork, rwork, ref info); 
            ILMemoryPool.Pool.RegisterObject(rwork); 
            ILMemoryPool.Pool.RegisterObject(work); 
        }
        #endregion 

        #endregion
    }
}
