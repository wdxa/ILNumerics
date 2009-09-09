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
    public static unsafe int dpotf2(char uplo, int n, double *a, int lda, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b10 = -1.0;
        const double c_b12 = 1.0;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;
        double d__1;

        /* Local variables */
        int j;
        double ajj;
        bool upper;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;

        /* Function Body */
        info = 0;
        upper = lsame(uplo, 'U');
        if (! upper && ! lsame(uplo, 'L')) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,n)) {
	    info = -4;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DPOTF2", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }

        if (upper) {

    /*        Compute the Cholesky factorization A = U'*U. */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {

    /*           Compute U(J,J) and test for non-positive-definiteness. */

	        i__2 = j - 1;
	        ajj = a[j + j * a_dim1] - ddot(i__2, &a[j * a_dim1 + 1], c__1, 
		        &a[j * a_dim1 + 1], c__1);
	        if (ajj <= 0.0) {
		    a[j + j * a_dim1] = ajj;
		    goto L30;
	        }
	        ajj = sqrt(ajj);
	        a[j + j * a_dim1] = ajj;

    /*           Compute elements J+1:N of row J. */

	        if (j < n) {
		    i__2 = j - 1;
		    i__3 = n - j;
		    dgemv('T', i__2, i__3, c_b10, &a[(j + 1) * a_dim1 
			    + 1], lda, &a[j * a_dim1 + 1], c__1, c_b12, &a[j + (
			    j + 1) * a_dim1], lda);
		    i__2 = n - j;
		    d__1 = 1.0 / ajj;
		    dscal(i__2, d__1, &a[j + (j + 1) * a_dim1], lda);
	        }
    /* L10: */
	    }
        } else {

    /*        Compute the Cholesky factorization A = L*L'. */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {

    /*           Compute L(J,J) and test for non-positive-definiteness. */

	        i__2 = j - 1;
	        ajj = a[j + j * a_dim1] - ddot(i__2, &a[j + a_dim1], lda, &a[j 
		        + a_dim1], lda);
	        if (ajj <= 0.0) {
		    a[j + j * a_dim1] = ajj;
		    goto L30;
	        }
	        ajj = sqrt(ajj);
	        a[j + j * a_dim1] = ajj;

    /*           Compute elements J+1:N of column J. */

	        if (j < n) {
		    i__2 = n - j;
		    i__3 = j - 1;
		    dgemv('N', i__2, i__3, c_b10, &a[j + 1 + 
			    a_dim1], lda, &a[j + a_dim1], lda, c_b12, &a[j + 1 + 
			    j * a_dim1], c__1);
		    i__2 = n - j;
		    d__1 = 1.0 / ajj;
		    dscal(i__2, d__1, &a[j + 1 + j * a_dim1], c__1);
	        }
    /* L20: */
	    }
        }
        goto L40;

    L30:
        info = j;

    L40:
        return 0;
    } 
}

