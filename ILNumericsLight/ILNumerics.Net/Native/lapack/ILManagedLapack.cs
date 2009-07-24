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

namespace ILNumerics.Native {
    /// <summary>
    /// Interface to all LAPACK/BLAS functions available
    /// </summary>
    /// <remarks>Each native module must implement this interface explicitly. Calls 
    /// to native functions are made virtual by calling functions of this interface.
    /// Therefore the user can transparently call any function regardless of the 
    /// plattform the assymbly (currently) runs on. The native modules implementing
    /// this interface take care of the details of implementation. 
    /// <para>Usually users of the library will not have to handle with this interface. 
    /// Its functions will be used from inside built in functions and are therefore wrapped 
    /// (mainly from inside <see cref="ILNumerics.BuiltInFunctions.ILMath">ILNumerics.BuiltInFunctions.ILMath</see>).</para>
    /// <para>Every LAPACK/BLAS function is explicitly implemented for any type supported.
    /// F.e. IILLapack includes four functions doing general matrix multiply: dgemm, zgemm, cgemm and sgemm - 
    /// for all four floating point datatypes supported from the LAPACK package.</para>
    /// <para>LAPACK is an open source linear algebra functions package optimized for 
    /// use together with highly natively optimized BLAS functions. A LAPACK guide is 
    /// available in the internet: <see href="http://www.netlib.org/lapack">www.netlib.org</see>.</para>
    /// </remarks>
    public class ILManagedLapack : IILLapack {
        
        #region ?GEMM

        /// <summary>
        /// Wrapper implementiation for ATLAS GeneralMatrixMultiply
        /// </summary>
        /// <param name="TransA">Transposition state for matrix A: one of the constants in enum CBlas_Transpose</param>
        /// <param name="TransB">Transposition state for matrix B: one of the constants in enum CBlas_Transpose</param>
        /// <param name="M">Number of rows in A</param>
        /// <param name="N">Number of columns in B</param>
        /// <param name="K">Number of columns in A and number of rows in B</param>
        /// <param name="alpha">multiplicationi factor for A</param>
        /// <param name="A">pointer to array A</param>
        /// <param name="lda">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix A</param>
        /// <param name="B">pointer to array B</param>
        /// <param name="ldb">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix B</param>
        /// <param name="beta">multiplication faktor for matrix B</param>
        /// <param name="C">pointer to predefined array C of neccessary length</param>
        /// <param name="ldc">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix C</param>
        /// <remarks>All parameters except C are readonly. Only elements of matrix C will be altered. C must be a predefined 
        /// continous array of size MxN</remarks>
        public void dgemm(char TransA, char TransB, int M, int N, int K, double alpha, IntPtr A, int lda, IntPtr B, int ldb, double beta, double[] C, int ldc)
        {
            //-> Operation to perform:

            // C = (alpha*A) x B + (beta*C), where
            // A is MxK, B is KxN, and C is MxN

            //-> Check for unimplemented features:

            if ((TransA != 'n' && TransA != 'N') ||
                (TransB != 'n' && TransB != 'N'))
            {
                throw new NotImplementedException("ILManagedLapack.dgemm. Is lapack_gen.dll on the PATH?");
            }
            
            unsafe
            {
                //-> Input Checking
                if (C.Length != (M * N))
                    throw new ILArgumentSizeException("C must be MxN.");

                double[] aA = new double[M * K];
                double* pA = (double*)A.ToPointer();
                double* pB = (double*)B.ToPointer();

                //-> store alpha * A in aA (don't want to modify A)
                for (int i = 0; i < aA.Length; i++)
                    aA[i] = alpha * pA[i];

                //-> store beta * C in C
                if (beta != 1)
                    for (int i = 0; i < C.Length; i++)
                        C[i] *= beta;

                //-> Matrix Multiply of A and B, added to C
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                        for (int k = 0; k < K; k++)
                            C[j * ldc + i] += aA[k * lda + i] * pB[j * ldb + k];
            }
        }
        /// <summary>
        /// Wrapper implementiation for ATLAS GeneralMatrixMultiply
        /// </summary>
        /// <param name="TransA">Transposition state for matrix A: one of the constants in enum CBlas_Transpose</param>
        /// <param name="TransB">Transposition state for matrix B: one of the constants in enum CBlas_Transpose</param>
        /// <param name="M">Number of rows in A</param>
        /// <param name="N">Number of columns in B</param>
        /// <param name="K">Number of columns in A and number of rows in B</param>
        /// <param name="alpha">multiplicationi factor for A</param>
        /// <param name="A">pointer to array A</param>
        /// <param name="lda">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix A</param>
        /// <param name="B">pointer to array B</param>
        /// <param name="ldb">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix B</param>
        /// <param name="beta">multiplication faktor for matrix B</param>
        /// <param name="C">pointer to predefined array C of neccessary length</param>
        /// <param name="ldc">distance between first elements of each column for column based orientation or 
        /// distance between first elements of each row for row based orientation for matrix C</param>
        /// <remarks>All parameters except C are readonly. Only elements of matrix C will be altered. C must be a predefined 
        /// continous array of size MxN</remarks>
        public void zgemm(char TransA, char TransB, int M, int N, int K, complex alpha, IntPtr A, int lda, IntPtr B, int ldb, complex beta, complex[] C, int ldc)
        {
            throw new NotImplementedException("ILManagedLapack.zgemm. Is lapack_gen.dll on the PATH?");
        }

#endregion 

        #region ?GESDD
        /// <summary>
        /// singular value decomposition, new version, more memory needed
        /// </summary>
        /// <param name="jobz">Specifies options for computing all or part of the matrix U
        /// <list type="table">
        /// <listheader>
        ///     <term>jobz value</term>
        ///     <description>... will result in:</description>
        /// </listheader>
        ///     <item>
        ///         <term>A</term>
        ///         <description>all M columns of U and all N rows of V**T are
        ///                     returned in the arrays U and VT</description>
        ///     </item>
        ///     <item>  <term>S</term>
        ///             <description>the first min(M,N) columns of U and the first
        ///              min(M,N) rows of V**T are returned in the arrays U
        ///              and VT</description>
        ///     </item>
        ///     <item> <term>O</term>  
        ///            <description>If M >= N, the first N columns of U are overwritten
        ///              on the array A and all rows of V**T are returned in
        ///              the array VT,
        ///              otherwise, all columns of U are returned in the
        ///              array U and the first M rows of V**T are overwritten
        ///              in the array VT</description>
        ///     </item>
        ///     <item> <term>N</term> 
        ///            <description>no columns of U or rows of V**T are computed.</description>
        ///     </item>
        /// </list>
        /// </param>
        /// <param name="m">The number of rows of the input matrix A.  M greater or equal to 0.</param>
        /// <param name="n">The number of columns of the input matrix A.  N greater or equal to 0</param>
        /// <param name="a">On entry, the M-by-N matrix A.
        ///          On exit, <list><item>
        ///          if JOBZ = 'O',  A is overwritten with the first N columns
        ///                          of U (the left singular vectors, stored
        ///                          columnwise) if M >= N;
        ///                          A is overwritten with the first M rows
        ///                          of V**T (the right singular vectors, stored
        ///                          rowwise) otherwise.</item>
        ///          <item>if JOBZ .ne. 'O', the contents of A are destroyed.</item></list></param>
        /// <param name="lda">The leading dimension of the array A.  LDA ge max(1,M).</param>
        /// <param name="s">array, dimension (min(M,N)). The singular values of A, sorted so that S(i) ge S(i+1)</param>
        /// <param name="u">array, dimension (LDU,UCOL)
        ///          UCOL = M if JOBZ = 'A' or JOBZ = 'O' and M &lt; N;
        ///          UCOL = min(M,N) if JOBZ = 'S'.
        ///          If JOBZ = 'A' or JOBZ = 'O' and M &lt; N, U contains the M-by-M
        ///          orthogonal matrix U;
        ///          if JOBZ = 'S', U contains the first min(M,N) columns of U
        ///          (the left singular vectors, stored columnwise);
        ///          if JOBZ = 'O' and M &gt;= N, or JOBZ = 'N', U is not referenced.</param>
        /// <param name="ldu">The leading dimension of the array U.  LDU &gt;= 1; if  
        /// JOBZ = 'S' or 'A' or JOBZ = 'O' and M &lt; N, LDU &gt;= M</param>
        /// <param name="vt">array, dimension (LDVT,N). If JOBZ = 'A' or JOBZ = 'O' and 
        /// M >= N, VT contains the N-by-N orthogonal matrix V**T; if JOBZ = 'S', 
        /// VT contains the first min(M,N) rows of V**T 
        /// (the right singular vectors, stored rowwise); if JOBZ = 'O' and M &lt; N, 
        /// or JOBZ = 'N', VT is not referenced</param>
        /// <param name="ldvt">The leading dimension of the array VT.  LDVT &gt; = 1; 
        /// if JOBZ = 'A' or JOBZ = 'O' and M &gt; = N, LDVT &gt;= N; 
        /// if JOBZ = 'S', LDVT &gt; min(M,N).</param>
        /// <param name="info">
        /// <list>
        ///     <item> 0:  successful exit.</item>
        ///     <item> <![CDATA[< 0]]> :  if INFO = -i, the i-th argument had an illegal value.</item>
        ///     <item> <![CDATA[> 0]]> :  ?BGSDD did not converge, updating process failed.</item>
        /// </list>
        /// </param>
        /// <remarks>(From the lapack manual):DGESDD computes the singular value decomposition (SVD) of a real
        ///M-by-N matrix A, optionally computing the left and right singular
        ///vectors.  If singular vectors are desired, it uses a
        ///divide-and-conquer algorithm.
        ///The SVD is written
        ///    <code>A = U * SIGMA * transpose(V)</code> 
        ///where SIGMA is an M-by-N matrix which is zero except for its
        ///min(m,n) diagonal elements, U is an M-by-M orthogonal matrix, and
        ///V is an N-by-N orthogonal matrix.  The diagonal elements of SIGMA
        ///are the singular values of A; they are real and non-negative, and
        ///are returned in descending order.  The first min(m,n) columns of
        ///U and V are the left and right singular vectors of A.
        ///Note that the routine returns VT = V**T, not V.
        ///The divide and conquer algorithm makes very mild assumptions about
        ///floating point arithmetic. It will work on machines with a guard
        ///digit in add/subtract, or on those binary machines without guard
        ///digits which subtract like the Cray X-MP, Cray Y-MP, Cray C-90, or
        ///Cray-2. It could conceivably fail on hexadecimal or decimal machines
        ///without guard digits, but we know of none.</remarks>
        public void dgesdd(char jobz, int m, int n, double[] a, int lda, double[] s, double[] u, int ldu, double[] vt, int ldvt, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgesdd. Is lapack_gen.dll on the PATH?");
        }
       
        /// <summary>
        /// singular value decomposition, new version, more memory needed
        /// </summary>
        /// <param name="jobz">Specifies options for computing all or part of the matrix U
        /// <list type="table">
        /// <listheader>
        ///     <term>jobz value</term>
        ///     <description>... will result in:</description>
        /// </listheader>
        ///     <item>
        ///         <term>A</term>
        ///         <description>all M columns of U and all N rows of V**T are
        ///                     returned in the arrays U and VT</description>
        ///     </item>
        ///     <item>  <term>S</term>
        ///             <description>the first min(M,N) columns of U and the first
        ///              min(M,N) rows of V**T are returned in the arrays U
        ///              and VT</description>
        ///     </item>
        ///     <item> <term>O</term>  
        ///            <description>If M >= N, the first N columns of U are overwritten
        ///              on the array A and all rows of V**T are returned in
        ///              the array VT,
        ///              otherwise, all columns of U are returned in the
        ///              array U and the first M rows of V**T are overwritten
        ///              in the array VT</description>
        ///     </item>
        ///     <item> <term>N</term> 
        ///            <description>no columns of U or rows of V**T are computed.</description>
        ///     </item>
        /// </list>
        /// </param>
        /// <param name="m">The number of rows of the input matrix A.  M greater or equal to 0.</param>
        /// <param name="n">The number of columns of the input matrix A.  N greater or equal to 0</param>
        /// <param name="a">On entry, the M-by-N matrix A.
        ///          On exit, <list><item>
        ///          if JOBZ = 'O',  A is overwritten with the first N columns
        ///                          of U (the left singular vectors, stored
        ///                          columnwise) if M >= N;
        ///                          A is overwritten with the first M rows
        ///                          of V**T (the right singular vectors, stored
        ///                          rowwise) otherwise.</item>
        ///          <item>if JOBZ .ne. 'O', the contents of A are destroyed.</item></list></param>
        /// <param name="lda">The leading dimension of the array A.  LDA ge max(1,M).</param>
        /// <param name="s">array, dimension (min(M,N)). The singular values of A, sorted so that S(i) ge S(i+1)</param>
        /// <param name="u">array, dimension (LDU,UCOL)
        ///          UCOL = M if JOBZ = 'A' or JOBZ = 'O' and M &lt; N;
        ///          UCOL = min(M,N) if JOBZ = 'S'.
        ///          If JOBZ = 'A' or JOBZ = 'O' and M &lt; N, U contains the M-by-M
        ///          orthogonal matrix U;
        ///          if JOBZ = 'S', U contains the first min(M,N) columns of U
        ///          (the left singular vectors, stored columnwise);
        ///          if JOBZ = 'O' and M &gt;= N, or JOBZ = 'N', U is not referenced.</param>
        /// <param name="ldu">The leading dimension of the array U.  LDU &gt;= 1; if  
        /// JOBZ = 'S' or 'A' or JOBZ = 'O' and M &lt; N, LDU &gt;= M</param>
        /// <param name="vt">array, dimension (LDVT,N). If JOBZ = 'A' or JOBZ = 'O' and 
        /// M >= N, VT contains the N-by-N orthogonal matrix V**T; if JOBZ = 'S', 
        /// VT contains the first min(M,N) rows of V**T 
        /// (the right singular vectors, stored rowwise); if JOBZ = 'O' and M &lt; N, 
        /// or JOBZ = 'N', VT is not referenced</param>
        /// <param name="ldvt">The leading dimension of the array VT.  LDVT &gt; = 1; 
        /// if JOBZ = 'A' or JOBZ = 'O' and M &gt; = N, LDVT &gt;= N; 
        /// if JOBZ = 'S', LDVT &gt; min(M,N).</param>
        /// <param name="info">
        /// <list>
        ///     <item> 0:  successful exit.</item>
        ///     <item> <![CDATA[< 0]]> :  if INFO = -i, the i-th argument had an illegal value.</item>
        ///     <item> <![CDATA[> 0]]> :  ?BGSDD did not converge, updating process failed.</item>
        /// </list>
        /// </param>
        /// <remarks>(From the lapack manual):DGESDD computes the singular value decomposition (SVD) of a real
        ///M-by-N matrix A, optionally computing the left and right singular
        ///vectors.  If singular vectors are desired, it uses a
        ///divide-and-conquer algorithm.
        ///The SVD is written
        ///    <code>A = U * SIGMA * transpose(V)</code> 
        ///where SIGMA is an M-by-N matrix which is zero except for its
        ///min(m,n) diagonal elements, U is an M-by-M orthogonal matrix, and
        ///V is an N-by-N orthogonal matrix.  The diagonal elements of SIGMA
        ///are the singular values of A; they are real and non-negative, and
        ///are returned in descending order.  The first min(m,n) columns of
        ///U and V are the left and right singular vectors of A.
        ///Note that the routine returns VT = V**T, not V.
        ///The divide and conquer algorithm makes very mild assumptions about
        ///floating point arithmetic. It will work on machines with a guard
        ///digit in add/subtract, or on those binary machines without guard
        ///digits which subtract like the Cray X-MP, Cray Y-MP, Cray C-90, or
        ///Cray-2. It could conceivably fail on hexadecimal or decimal machines
        ///without guard digits, but we know of none.</remarks>
        public void zgesdd(char jobz, int m, int n, complex[] a, int lda, double[] s, complex[] u, int ldu, complex[] vt, int ldvt, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgesdd. Is lapack_gen.dll on the PATH?");
        }

#endregion 

        #region ?GESVD
        /// <summary>
        /// singular value decomposition, older version, less memory needed 
        /// </summary>
        /// <param name="jobz">Specifies options for computing all or part of the matrix U
        /// <list type="bullet"><item>= 'A':  all M columns of U and all N rows of V**T are
        ///returned in the arrays U and VT</item>
        ///     <item> = 'S':  the first min(M,N) columns of U and the first
        ///              min(M,N) rows of V**T are returned in the arrays U
        ///              and VT</item>
        ///     <item> = 'O':  If M >= N, the first N columns of U are overwritten
        ///              on the array A and all rows of V**T are returned in
        ///              the array VT. Otherwise, all columns of U are returned in the
        ///              array U and the first M rows of V**T are overwritten
        ///              in the array VT</item>
        ///     <item> = 'N':  no columns of U or rows of V**T are computed.</item>
        ///        </list>
        /// </param>
        /// <param name="m">The number of rows of the input matrix A.  M greater or equal to 0.</param>
        /// <param name="n">The number of columns of the input matrix A.  N greater or equal to 0</param>
        /// <param name="a">On entry, the M-by-N matrix A.
        ///          On exit, <list><item>
        ///          if JOBZ = 'O',  A is overwritten with the first N columns
        ///                          of U (the left singular vectors, stored
        ///                          columnwise) if M >= N;
        ///                          A is overwritten with the first M rows
        ///                          of V**T (the right singular vectors, stored
        ///                          rowwise) otherwise.</item>
        ///          <item>if JOBZ .ne. 'O', the contents of A are destroyed.</item></list></param>
        /// <param name="lda">The leading dimension of the array A.  LDA ge max(1,M).</param>
        /// <param name="s">array, dimension (min(M,N)). The singular values of A, sorted so that S(i) ge S(i+1)</param>
        /// <param name="u">array, dimension (LDU,UCOL)
        ///          UCOL = M if JOBZ = 'A' or JOBZ = 'O' and M &lt; N;
        ///          UCOL = min(M,N) if JOBZ = 'S'.
        ///          If JOBZ = 'A' or JOBZ = 'O' and M &lt; N, U contains the M-by-M
        ///          orthogonal matrix U;
        ///          if JOBZ = 'S', U contains the first min(M,N) columns of U
        ///          (the left singular vectors, stored columnwise);
        ///          if JOBZ = 'O' and M &gt;= N, or JOBZ = 'N', U is not referenced.</param>
        /// <param name="ldu">The leading dimension of the array U.  LDU &gt;= 1; if  
        /// JOBZ = 'S' or 'A' or JOBZ = 'O' and M &lt; N, LDU &gt;= M</param>
        /// <param name="vt">array, dimension (LDVT,N). If JOBZ = 'A' or JOBZ = 'O' and 
        /// M >= N, VT contains the N-by-N orthogonal matrix V**T; if JOBZ = 'S', 
        /// VT contains the first min(M,N) rows of V**T 
        /// (the right singular vectors, stored rowwise); if JOBZ = 'O' and M &lt; N, 
        /// or JOBZ = 'N', VT is not referenced</param>
        /// <param name="ldvt">The leading dimension of the array VT.  LDVT &gt; = 1; 
        /// if JOBZ = 'A' or JOBZ = 'O' and M &gt; = N, LDVT &gt;= N; 
        /// if JOBZ = 'S', LDVT &gt; min(M,N).</param>
        /// <param name="info">
        /// <list>
        ///     <item> 0:  successful exit.</item>
        ///     <item> lower 0:  if INFO = -i, the i-th argument had an illegal value.</item>
        ///     <item> greater 0:  DBDSDC did not converge, updating process failed.</item>
        /// </list>
        /// </param>
        /// <remarks>(From the lapack manual):DGESDD computes the singular value decomposition (SVD) of a real
        ///M-by-N matrix A, optionally computing the left and right singular
        ///vectors.  If singular vectors are desired, it uses a
        ///divide-and-conquer algorithm.
        ///The SVD is written
        ///    <br>A = U * SIGMA * transpose(V)</br> 
        ///where SIGMA is an M-by-N matrix which is zero except for its
        ///min(m,n) diagonal elements, U is an M-by-M orthogonal matrix, and
        ///V is an N-by-N orthogonal matrix.  The diagonal elements of SIGMA
        ///are the singular values of A; they are real and non-negative, and
        ///are returned in descending order.  The first min(m,n) columns of
        ///U and V are the left and right singular vectors of A.
        ///Note that the routine returns VT = V**T, not V.
        ///The divide and conquer algorithm makes very mild assumptions about
        ///floating point arithmetic. It will work on machines with a guard
        ///digit in add/subtract, or on those binary machines without guard
        ///digits which subtract like the Cray X-MP, Cray Y-MP, Cray C-90, or
        ///Cray-2. It could conceivably fail on hexadecimal or decimal machines
        ///without guard digits, but we know of none.</remarks>
        public void dgesvd(char jobz, int m, int n, double[] a, int lda, double[] s, double[] u, int ldu, double[] vt, int ldvt, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgesvd. Is lapack_gen.dll on the PATH?");
        }
       
        /// <summary>
        /// singular value decomposition, older version, less memory needed 
        /// </summary>
        /// <param name="jobz">Specifies options for computing all or part of the matrix U
        /// <list type="bullet"><item>= 'A':  all M columns of U and all N rows of V**T are
        ///returned in the arrays U and VT</item>
        ///     <item> = 'S':  the first min(M,N) columns of U and the first
        ///              min(M,N) rows of V**T are returned in the arrays U
        ///              and VT</item>
        ///     <item> = 'O':  If M >= N, the first N columns of U are overwritten
        ///              on the array A and all rows of V**T are returned in
        ///              the array VT. Otherwise, all columns of U are returned in the
        ///              array U and the first M rows of V**T are overwritten
        ///              in the array VT</item>
        ///     <item> = 'N':  no columns of U or rows of V**T are computed.</item>
        ///        </list>
        /// </param>
        /// <param name="m">The number of rows of the input matrix A.  M greater or equal to 0.</param>
        /// <param name="n">The number of columns of the input matrix A.  N greater or equal to 0</param>
        /// <param name="a">On entry, the M-by-N matrix A.
        ///          On exit, <list><item>
        ///          if JOBZ = 'O',  A is overwritten with the first N columns
        ///                          of U (the left singular vectors, stored
        ///                          columnwise) if M >= N;
        ///                          A is overwritten with the first M rows
        ///                          of V**T (the right singular vectors, stored
        ///                          rowwise) otherwise.</item>
        ///          <item>if JOBZ .ne. 'O', the contents of A are destroyed.</item></list></param>
        /// <param name="lda">The leading dimension of the array A.  LDA ge max(1,M).</param>
        /// <param name="s">array, dimension (min(M,N)). The singular values of A, sorted so that S(i) ge S(i+1)</param>
        /// <param name="u">array, dimension (LDU,UCOL)
        ///          UCOL = M if JOBZ = 'A' or JOBZ = 'O' and M &lt; N;
        ///          UCOL = min(M,N) if JOBZ = 'S'.
        ///          If JOBZ = 'A' or JOBZ = 'O' and M &lt; N, U contains the M-by-M
        ///          orthogonal matrix U;
        ///          if JOBZ = 'S', U contains the first min(M,N) columns of U
        ///          (the left singular vectors, stored columnwise);
        ///          if JOBZ = 'O' and M &gt;= N, or JOBZ = 'N', U is not referenced.</param>
        /// <param name="ldu">The leading dimension of the array U.  LDU &gt;= 1; if  
        /// JOBZ = 'S' or 'A' or JOBZ = 'O' and M &lt; N, LDU &gt;= M</param>
        /// <param name="vt">array, dimension (LDVT,N). If JOBZ = 'A' or JOBZ = 'O' and 
        /// M >= N, VT contains the N-by-N orthogonal matrix V**T; if JOBZ = 'S', 
        /// VT contains the first min(M,N) rows of V**T 
        /// (the right singular vectors, stored rowwise); if JOBZ = 'O' and M &lt; N, 
        /// or JOBZ = 'N', VT is not referenced</param>
        /// <param name="ldvt">The leading dimension of the array VT.  LDVT &gt; = 1; 
        /// if JOBZ = 'A' or JOBZ = 'O' and M &gt; = N, LDVT &gt;= N; 
        /// if JOBZ = 'S', LDVT &gt; min(M,N).</param>
        /// <param name="info">
        /// <list>
        ///     <item> 0:  successful exit.</item>
        ///     <item> lower 0:  if INFO = -i, the i-th argument had an illegal value.</item>
        ///     <item> greater 0:  DBDSDC did not converge, updating process failed.</item>
        /// </list>
        /// </param>
        /// <remarks>(From the lapack manual):DGESDD computes the singular value decomposition (SVD) of a real
        ///M-by-N matrix A, optionally computing the left and right singular
        ///vectors.  If singular vectors are desired, it uses a
        ///divide-and-conquer algorithm.
        ///The SVD is written
        ///    <br>A = U * SIGMA * transpose(V)</br> 
        ///where SIGMA is an M-by-N matrix which is zero except for its
        ///min(m,n) diagonal elements, U is an M-by-M orthogonal matrix, and
        ///V is an N-by-N orthogonal matrix.  The diagonal elements of SIGMA
        ///are the singular values of A; they are real and non-negative, and
        ///are returned in descending order.  The first min(m,n) columns of
        ///U and V are the left and right singular vectors of A.
        ///Note that the routine returns VT = V**T, not V.
        ///The divide and conquer algorithm makes very mild assumptions about
        ///floating point arithmetic. It will work on machines with a guard
        ///digit in add/subtract, or on those binary machines without guard
        ///digits which subtract like the Cray X-MP, Cray Y-MP, Cray C-90, or
        ///Cray-2. It could conceivably fail on hexadecimal or decimal machines
        ///without guard digits, but we know of none.</remarks>
        public void zgesvd(char jobz, int m, int n, complex[] a, int lda, double[] s, complex[] u, int ldu, complex[] vt, int ldvt, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgesvd. Is lapack_gen.dll on the PATH?");
        }
        #endregion 
        
        #region ?POTRF - cholesky factorization
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        public void dpotrf(char uplo, int n, double[] A, int lda, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dpotrf. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        public void zpotrf(char uplo, int n, complex[] A, int lda, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zpotrf. Is lapack_gen.dll on the PATH?");
        }
#endregion 

        #region ?POTRI - inverse via cholesky factorization
        /// <summary>
        /// matrix inverse via cholesky factorization (?potrf)
        /// </summary>
        public void dpotri(char uplo, int n, double[] A, int lda, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dpotri. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// matrix inverse via cholesky factorization (?potrf)
        /// </summary>
        public void zpotri(char uplo, int n, complex[] A, int lda, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zpotri. Is lapack_gen.dll on the PATH?");
        }

#endregion 

        #region ?POTRS - Solve via cholesky factors
        /// <summary>
        /// solve equation system via cholesky factorization (?potrs)
        /// </summary>
        public void dpotrs(char uplo, int n, int nrhs, double[] A, int lda, double[] B, int ldb, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dpotrs. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// solve equation system via cholesky factorization (?potrs)
        /// </summary>
        public void zpotrs(char uplo, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zpotrs. Is lapack_gen.dll on the PATH?");
        }
#endregion

        #region ?getrf - LU factorization
        /// <summary>
        /// LU factorization of general matrix
        /// </summary>
        public void dgetrf(int M, int N, double[] A, int LDA, int[] IPIV, ref int info)
        {
            // -> Input checking

            info = 0;
            if (M < 0) { info = -1; return; }
            if (N < 0) { info = -2; return; }
            if (A.Length != M * N) { info = -3; return; }
            if (LDA < 1 || LDA > A.Length) { info = -4; return; }
            if (IPIV.Length != Math.Min(M, N)) { info = -5; return; }

            // -> Initializations

            for (int i = 0; i < IPIV.Length; i++)
                IPIV[i] = i+1;

            // -> For each pivot...
            for (int idx = 0; idx < IPIV.Length; idx++)
            {
                int pivIdx = LDA * idx + idx;

                // -> Find row that would have the greatest pivot, 
                //    then swap with the current pivot row

                int maxIdx = idx;
                for (int i = idx + 1; i < M; i++)
                    if (Math.Abs(A[LDA * idx + i]) > Math.Abs(A[pivIdx]))
                        maxIdx = i;

                if (maxIdx != pivIdx)
                { // swap row maxIdx with pivot row

                    int tmpForPiv = IPIV[idx];
                    IPIV[idx] = IPIV[maxIdx];
                    IPIV[maxIdx] = tmpForPiv;

                    double tmpForSwap;
                    for (int i = 0; i < N; i++)
                    {
                        tmpForSwap = A[idx + LDA * i];
                        A[idx + LDA * i] = A[maxIdx + LDA * i];
                        A[maxIdx + LDA * i] = tmpForSwap;
                    }
                }

                // -> If Pivot is zero, then all below it are zero. Skip.
                if (A[pivIdx] == 0)
                { 
                    info = idx + 1;
                    continue;
                }

                // -> For each row under the pivot...
                for (int jdx = idx + 1; jdx < M; jdx++)
                {
                    // Find L values
                    A[jdx + LDA * idx] = A[jdx + LDA * idx] / A[pivIdx];

                    // Find U values
                    for (int kdx = idx + 1; kdx < N; kdx++)
                        A[jdx + LDA * kdx] = A[jdx + LDA * kdx] - A[jdx + LDA * idx] * A[idx + LDA * kdx];
                }
            }
        }
        /// <summary>
        /// LU factorization of general matrix
        /// </summary>
        public void zgetrf(int M, int N, complex[] A, int LDA, int[] IPIV, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgetrf. Is lapack_gen.dll on the PATH?");
        }
        #endregion 
        
        #region ?getri - inverse via LU factorization
        /// <summary>
        /// inverse of a matrix via LU factorization
        /// </summary>
        public void dgetri(int N, double[] A, int LDA, int[] IPIV, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgetri. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// inverse of a matrix via LU factorization
        /// </summary>
        public void zgetri(int N, complex[] A, int LDA, int[] IPIV, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgetri. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region ORGQR
        /// <summary>
        /// QR factor extraction
        /// </summary>
        public void dorgqr(int M, int N, int K, double[] A, int lda, double[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dorggr. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// QR factor extraction
        /// </summary>
        public void zungqr(int M, int N, int K, complex[] A, int lda, complex[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zunggr. Is lapack_gen.dll on the PATH?");
        }
        #endregion

        #region ?geqrf - QR factorization
        /// <summary>
        /// QR factorization
        /// </summary>
        public void dgeqrf(int M, int N, double[] A, int lda, double[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.gegrf. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// QR factorization
        /// </summary>
        public void zgeqrf(int M, int N, complex[] A, int lda, complex[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgegrf. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region GEQP3
        /// <summary>
        /// QR factorisation with column pivoting
        /// </summary>
        public void dgeqp3(int M, int N, double[] A, int LDA, int[] JPVT, double[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgegp3. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// QR factorisation with column pivoting
        /// </summary>
        public void zgeqp3(int M, int N, complex[] A, int LDA, int[] JPVT, complex[] tau, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgegp3. Is lapack_gen.dll on the PATH?");
        }
        #endregion

        #region ?ormqr - mmult of QR factorization result
        /// <summary>
        /// multipliation for general matrix with QR decomposition factor
        /// </summary>
        public void dormqr(char side, char trans, int m, int n, int k, double[] A, int lda, double[] tau, double[] C, int LDC, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dormgr. Is lapack_gen.dll on the PATH?");
        }

        #endregion 
        
        #region DTRTRS 
        /// <summary>
        /// Solve triangular system of linear equations (forward-/ backward substitution)
        /// </summary>
        /// <param name="uplo">'U': A is upper triangular, 'L': A is lower triangular</param>
        /// <param name="transA">'N':  A * X = B  (No transpose); 'T':  A**T * X = B  (Transpose), 'T':  A**T * X = B  (Transpose)</param>
        /// <param name="diag">'N' arbitrary diagonal elements, 'U' unit diagonal</param>
        /// <param name="N">order of A</param>
        /// <param name="nrhs">number of right hand sides - columns of matrix B</param>
        /// <param name="A">square matrix A</param>
        /// <param name="LDA">spacing between columns for A</param>
        /// <param name="B">(input/output) on input: right hand side, on output: solution x </param>
        /// <param name="LDB">spacing between columns for B</param>
        /// <param name="info">(output) 0: success; &lt; 0: illigal argument, &gt; 0: A is sinular having a zero on the i-th diagonal element. No solution will be computed than. </param>
        public void dtrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dtrtrs. Is lapack_gen.dll on the PATH?");
        }
        /// <summary>
        /// Solve triangular system of linear equations (forward-/ backward substitution)
        /// </summary>
        /// <param name="uplo">'U': A is upper triangular, 'L': A is lower triangular</param>
        /// <param name="transA">'N':  A * X = B  (No transpose); 'T':  A**T * X = B  (Transpose), 'T':  A**T * X = B  (Transpose)</param>
        /// <param name="diag">'N' arbitrary diagonal elements, 'U' unit diagonal</param>
        /// <param name="N">order of A</param>
        /// <param name="nrhs">number of right hand sides - columns of matrix B</param>
        /// <param name="A">square matrix A</param>
        /// <param name="LDA">spacing between columns for A</param>
        /// <param name="B">(input/output) on input: right hand side, on output: solution x </param>
        /// <param name="LDB">spacing between columns for B</param>
        /// <param name="info">(output) 0: success; &lt; 0: illigal argument, &gt; 0: A is sinular having a zero on the i-th diagonal element. No solution will be computed than. </param>
        public void ztrtrs(char uplo, char transA, char diag, int N, int nrhs, IntPtr A, int LDA, IntPtr B, int LDB, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.ztrtrs. Is lapack_gen.dll on the PATH?");
        }
        #endregion

        #region ?GETRS
        /// <summary>
        /// solve system of linear equations by triangular matrices
        /// </summary>
        /// <param name="trans">transpose before work?</param>
        /// <param name="N">number rows</param>
        /// <param name="NRHS">number right hand sides</param>
        /// <param name="A">matrix A</param>
        /// <param name="LDA">spacing between columns: A</param>
        /// <param name="IPIV">pivoting indices</param>
        /// <param name="B">matrix B</param>
        /// <param name="LDB">spacing between columns: B</param>
        /// <param name="info">success info</param>
        public void dgetrs(char trans, int N, int NRHS, double[] A, int LDA, int[] IPIV, double[] B, int LDB, ref int info)
        {
            // -> Check for unimplemented features:

            if ((trans != 'n' && trans != 'N'))
                throw new NotImplementedException("ILManagedLapack.dgetrs. Is lapack_gen.dll on the PATH?");

            // -> Input checking

            info = 0;
            if (N < 0) { info = -2; return; }
            if (NRHS * N != B.Length) { info = -3; return; }
            if (A.Length != N * N) { info = -4; return; }
            if (LDA < 1 || LDA > A.Length) { info = -5; return; }
            if (IPIV.Length != N) { info = -6; return; }
            if (LDB < 1 || LDB > B.Length) { info = -8; return; }

            // -> Initializations

            double[] BSwap = new double[B.Length];
            B.CopyTo(BSwap, 0);

            // -> Permute B using IPIV

            for (int idx = 0; idx < N; idx++)
                if (idx + 1 != IPIV[idx])
                    for (int jdx = 0; jdx < NRHS; jdx++)
                        B[jdx * LDB + idx] = BSwap[IPIV[idx] - 1 + jdx * LDB];

            // -> For each column in B
            for (int idx = 0; idx < NRHS; idx++)
            {
                // -> Perform forward substitution, Ly = b
                for (int jdx = 0; jdx < N; jdx++)
                    for (int kdx = jdx + 1; kdx < N; kdx++)
                        B[idx * LDB + kdx] -= A[jdx * LDA + kdx] * B[idx * LDB + jdx];

                // -> Perform backward substitution, Ux = y
                for (int jdx = N - 1; jdx >= 0; jdx--)
                {
                    B[idx * LDB + jdx] /= A[jdx * LDA + jdx];
                    for (int kdx = jdx - 1; kdx >= 0; kdx--)
                        B[idx * LDB + kdx] -= A[jdx * LDA + kdx] * B[idx * LDB + jdx];
                }
            }
        }
        /// <summary>
        /// solve system of linear equations by triangular matrices
        /// </summary>
        /// <param name="trans">transpose before work?</param>
        /// <param name="N">number rows</param>
        /// <param name="NRHS">number right hand sides</param>
        /// <param name="A">matrix A</param>
        /// <param name="LDA">spacing between columns: A</param>
        /// <param name="IPIV">pivoting indices</param>
        /// <param name="B">matrix B</param>
        /// <param name="LDB">spacing between columns: B</param>
        /// <param name="info">success info</param>
        public void zgetrs(char trans, int N, int NRHS, complex[] A, int LDA, int[] IPIV, complex[] B, int LDB, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgetrs. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region ?GELSD - least square solution, SVD - divide & conquer
        public void dgelsd(int m, int n, int nrhs, double[] A, int lda, double[] B, int ldb, double[] S, double RCond, ref int rank, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgelsd. Is lapack_gen.dll on the PATH?");
        }
        public void zgelsd(int m, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, double[] S, double RCond, ref int rank, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgelsd. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region ?GELSY - least square solution, QRP
        public void dgelsy(int m, int n, int nrhs, double[] A, int lda, double[] B, int ldb, int[] JPVT0, double RCond, ref int rank, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgelsy. Is lapack_gen.dll on the PATH?");
        }
        public void zgelsy(int m, int n, int nrhs, complex[] A, int lda, complex[] B, int ldb, int[] JPVT0, double RCond, ref int rank, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgelsy. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region ?GEEVX - eigenvectors & -values, nonsymmetric A 
        public void dgeevx(char balance, char jobvl, char jobvr, char sense, int n, double[] A, int lda, double[] wr, double[] wi, double[] vl, int ldvl, double[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dgeevx. Is lapack_gen.dll on the PATH?");
        }
        public void zgeevx(char balance, char jobvl, char jobvr, char sense, int n, complex[] A, int lda, complex[] w, complex[] vl, int ldvl, complex[] vr, int ldvr, ref int ilo, ref int ihi, double[] scale, ref double abnrm, double[] rconde, double[] rcondv, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zgeevx. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

        #region ?GEEVR - eigenvectors & -values, symmetric/hermitian A 
        public void dsyevr(char jobz, char range, char uplo, int n, double[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, double[] z, int ldz, int[] isuppz, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dsyevr. Is lapack_gen.dll on the PATH?");
        }
        public void zheevr(char jobz, char range, char uplo, int n, complex[] A, int lda, double vl, double vu, int il, int iu, double abstol, ref int m, double[] w, complex[] z, int ldz, int[] isuppz, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zheevr. Is lapack_gen.dll on the PATH?");
        }
        #endregion 
        
        #region ?SYGV - eigenvectors & -values, symmetric/hermitian A and B, pos.def.B 
        public void dsygv(int itype, char jobz, char uplo, int n, double[] A, int lda, double[] B, int ldb, double[] w, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.dsygv. Is lapack_gen.dll on the PATH?");
        }
        public void zhegv(int itype, char jobz, char uplo, int n, complex[] A, int lda, complex[] B, int ldb, double[] w, ref int info)
        {
            throw new NotImplementedException("ILManagedLapack.zhegv. Is lapack_gen.dll on the PATH?");
        }
        #endregion 

    }
}
