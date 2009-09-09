#region ORIGINS, COPYRIGHTS, AND LICENSE
/*

This C# version of LAPACK is derivied from http://www.netlib.org/clapack/,
and the original copyright and license is as follows:

Copyright (c) 1992-2008 The University of Tennessee.  All rights reserved.
$COPYRIGHT$ Additional copyrights may follow $HEADER$

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer. 
  
- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.
  
- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT  
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT  
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion

public partial class ManagedLapack
{
    /// <summary>
    /// Performs one of the matrix-matrix operations
    /// C := alpha*op( A )*op( B ) + beta*C, where  op( X ) is one of
    /// op( X ) = X  or op( X ) = X', alpha and beta are scalars,
    /// and A, B and C are matrices, with op( A ) an m by k matrix, 
    /// op( B )  a  k by n matrix and  C an m by n matrix.
    /// </summary>
    /// <param name="transa">
    /// On entry, TRANSA specifies the form of op( A ) to be used in
    /// the matrix multiplication as follows:
    /// TRANSA = 'N' or 'n',  op( A ) = A.
    /// TRANSA = 'T' or 't',  op( A ) = A'.
    /// TRANSA = 'C' or 'c',  op( A ) = A'.
    /// </param>
    /// <param name="transb">
    /// On entry, TRANSB specifies the form of op( B ) to be used in
    /// the matrix multiplication as follows:
    /// TRANSB = 'N' or 'n',  op( B ) = B.
    /// TRANSB = 'T' or 't',  op( B ) = B'.
    /// TRANSB = 'C' or 'c',  op( B ) = B'.
    /// </param>
    /// <param name="m">
    /// On entry, M specifies the number of rows of the matrix
    /// op( A ) and of the matrix C. M  must be at least zero.
    /// </param>
    /// <param name="n">
    /// On entry,  N  specifies the number  of columns of the matrix
    /// op( B ) and the number of columns of the matrix C. N must be
    /// at least zero.
    /// </param>
    /// <param name="k">
    /// On entry,  K  specifies  the number of columns of the matrix
    /// op( A ) and the number of rows of the matrix op( B ). K must
    /// be at least  zero.
    /// </param>
    /// <param name="alpha">
    /// On entry, ALPHA specifies the scalar alpha.
    /// </param>
    /// <param name="a">
    /// Array of DIMENSION ( LDA, ka ), where ka is
    /// k  when  TRANSA = 'N' or 'n',  and is  m  otherwise.
    /// Before entry with  TRANSA = 'N' or 'n',  the leading  m by k 
    /// part of the array  A  must contain the matrix  A,  otherwise 
    /// the leading  k by m  part of the array  A  must contain  the 
    /// matrix A.
    /// </param>
    /// <param name="lda">
    /// On entry, LDA specifies the first dimension of A as declared
    /// in the calling (sub) program. When  TRANSA = 'N' or 'n' then 
    /// LDA must be at least  max( 1, m ), otherwise  LDA must be at 
    /// least  max( 1, k ). 
    /// </param>
    /// <param name="b">Array of DIMENSION ( LDB, kb ), where kb is 
    /// n  when  TRANSB = 'N' or 'n',  and is  k  otherwise. 
    /// Before entry with  TRANSB = 'N' or 'n',  the leading  k by n 
    /// part of the array  B  must contain the matrix  B,  otherwise 
    /// the leading  n by k  part of the array  B  must contain  the 
    /// matrix B.
    /// </param>
    /// <param name="ldb">
    /// On entry, LDB specifies the first dimension of B as declared 
    /// in the calling (sub) program. When  TRANSB = 'N' or 'n' then 
    /// LDB must be at least  max( 1, k ), otherwise  LDB must be at 
    /// least  max( 1, n ). 
    /// </param>
    /// <param name="beta">
    /// On entry,  BETA  specifies the scalar  beta.  When  BETA  is 
    /// supplied as zero then C need not be set on input. 
    /// </param>
    /// <param name="c__">
    /// Array of DIMENSION ( LDC, n ). 
    /// Before entry, the leading  m by n  part of the array  C must 
    /// contain the matrix  C,  except when  beta  is zero, in which 
    /// case C need not be set on entry. 
    /// On exit, the array  C  is overwritten by the  m by n  matrix 
    /// ( alpha*op( A )*op( B ) + beta*C ).
    /// </param>
    /// <param name="ldc">
    /// On entry, LDC specifies the first dimension of C as declared 
    /// in  the  calling  (sub)  program.   LDC  must  be  at  least 
    /// max( 1, m ). 
    /// </param>
    /// <returns>
    /// Zero.
    /// </returns>
    /// <remarks>
    /// Level 3 Blas routine -- Written on 8-February-1989. 
    /// Jack Dongarra, Argonne National Laboratory. 
    /// Iain Duff, AERE Harwell. 
    /// Jeremy Du Croz, Numerical Algorithms Group Ltd.
    /// Sven Hammarling, Numerical Algorithms Group Ltd.
    /// </remarks>
    public static unsafe int dgemm(char transa, char transb, int m, int n, int k, double alpha, double* a, int lda,
        double* b, int ldb, double beta, double* c__, int ldc)
    {
        /* System generated locals */
        int a_dim1, a_offset, b_dim1, b_offset, c_dim1, c_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, j, l, info;
        bool nota, notb;
        double temp;
        int ncola;
        int nrowa, nrowb;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        b_dim1 = ldb;
        b_offset = 1 + b_dim1;
        b -= b_offset;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;

        /* Function Body */
        nota = lsame(transa, 'N');
        notb = lsame(transb, 'N');

        if (nota)
        {
	        nrowa = m;
	        ncola = k;
        }
        else
        {
	        nrowa = k;
	        ncola = m;
        }

        if (notb)
        {
	        nrowb = k;
        }
        else
        {
	        nrowb = n;
        }

        /*     Test the input parameters. */

        info = 0;
        if (! nota && ! lsame(transa, 'C') && ! lsame(transa, 'T')) { info = 1; }
        else if (! notb && ! lsame(transb, 'C') && !lsame(transb, 'T')) { info = 2; }
        else if (m < 0) { info = 3; }
        else if (n < 0) { info = 4; }
        else if (k < 0) { info = 5; }
        else if (lda < max(1,nrowa)) { info = 8; }
        else if (ldb < max(1,nrowb)) { info = 10; }
        else if (ldc < max(1, m)) { info = 13; }

        if (info != 0)
            return 0;

        // Quick return if possible
        if (m == 0 || n == 0 || (alpha == 0 || k == 0) && beta == 1.0)
	        return 0;

        // And if  alpha.eq.zero.
        if (alpha == 0)
        {
	        if (beta == 0)
            {
	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            i__2 = m;
		            for (i__ = 1; i__ <= i__2; ++i__)
		                c__[i__ + j * c_dim1] = 0;
	            }
	        }
            else
            {
	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            i__2 = m;
		            for (i__ = 1; i__ <= i__2; ++i__)
		                c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
		        }
            }

	        return 0;
        }

        // Start the operations.
        if (notb)
        {
	        if (nota)
            {
                // Form  C := alpha*A*B + beta*C.
	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            if (beta == 0.0)
                    {
		                i__2 = m;
		                for (i__ = 1; i__ <= i__2; ++i__)
			                c__[i__ + j * c_dim1] = 0.0;

		            }
                    else if (beta != 1.0)
                    {
		                i__2 = m;
		                for (i__ = 1; i__ <= i__2; ++i__) 
			                c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
		            }
		            i__2 = k;
		            for (l = 1; l <= i__2; ++l)
                    {
		                if (b[l + j * b_dim1] != 0.0)
                        {
			                temp = alpha * b[l + j * b_dim1];
			                i__3 = m;
			                for (i__ = 1; i__ <= i__3; ++i__)
			                    c__[i__ + j * c_dim1] += temp * a[i__ + l * a_dim1];
		                }
		            }
	            }
	        }
            else
            {
                // Form  C := alpha*A'*B + beta*C
	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            i__2 = m;
		            for (i__ = 1; i__ <= i__2; ++i__)
                    {
		                temp = 0.0;
		                i__3 = k;

		                for (l = 1; l <= i__3; ++l)
			                temp += a[l + i__ * a_dim1] * b[l + j * b_dim1];

		                if (beta == 0.0)
			                c__[i__ + j * c_dim1] = alpha * temp;
                        else
			                c__[i__ + j * c_dim1] = alpha * temp + beta * c__[i__ + j * c_dim1];

		            }
	            }
	        }
        }
        else
        {
	        if (nota)
            {
                // Form  C := alpha*A*B' + beta*C */

	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            if (beta == 0.0)
                    {
		                i__2 = m;
		                for (i__ = 1; i__ <= i__2; ++i__)
			                c__[i__ + j * c_dim1] = 0.0;

		            } else if (beta != 1) {
		                i__2 = m;
		                for (i__ = 1; i__ <= i__2; ++i__)
			                c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];

		            }
		            i__2 = k;
		            for (l = 1; l <= i__2; ++l)
                    {
		                if (b[j + l * b_dim1] != 0)
                        {
			                temp = alpha * b[j + l * b_dim1];
			                i__3 = m;
			                for (i__ = 1; i__ <= i__3; ++i__)
			                    c__[i__ + j * c_dim1] += temp * a[i__ + l * a_dim1];
		                }
		            }
	            }
	        }
            else
            {

                // Form  C := alpha*A'*B' + beta*C */

	            i__1 = n;
	            for (j = 1; j <= i__1; ++j)
                {
		            i__2 = m;
		            for (i__ = 1; i__ <= i__2; ++i__)
                    {
		                temp = 0.0;
		                i__3 = k;
		                for (l = 1; l <= i__3; ++l)
			                temp += a[l + i__ * a_dim1] * b[j + l * b_dim1];

		                if (beta == 0.0)
			                c__[i__ + j * c_dim1] = alpha * temp;
                        else
			                c__[i__ + j * c_dim1] = alpha * temp + beta * c__[i__ + j * c_dim1];
		            }
	            }
	        }
        }

        return 0;
    } 
}

