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
    public static unsafe int dpotrf(char uplo, int n, double *a, int lda, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const double c_b13 = -1.0;
        const double c_b14 = 1.0;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4;

        /* Local variables */
        int j, jb, nb;
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
	    xerbla("DPOTRF", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }

    /*     Determine the block size for this environment. */

        nb = ilaenv(c__1, "DPOTRF", uplo.ToString(), n, c_n1, c_n1, c_n1);
        if (nb <= 1 || nb >= n) {

    /*        Use unblocked code. */

	    dpotf2(uplo, n, &a[a_offset], lda, ref info);
        } else {

    /*        Use blocked code. */

	    if (upper) {

    /*           Compute the Cholesky factorization A = U'*U. */

	        i__1 = n;
	        i__2 = nb;
	        for (j = 1; i__2 < 0 ? j >= i__1 : j <= i__1; j += i__2) {

    /*              Update and factorize the current diagonal block and test */
    /*              for non-positive-definiteness. */

    /* Computing MIN */
		    i__3 = nb; i__4 = n - j + 1;
		    jb = min(i__3,i__4);
		    i__3 = j - 1;
		    dsyrk('U', 'T', jb, i__3, c_b13, &a[j * 
			    a_dim1 + 1], lda, c_b14, &a[j + j * a_dim1], lda);
		    dpotf2('U', jb, &a[j + j * a_dim1], lda, ref info);
		    if (info != 0) {
		        goto L30;
		    }
		    if (j + jb <= n) {

    /*                 Compute the current block row. */

		        i__3 = n - j - jb + 1;
		        i__4 = j - 1;
		        dgemm('T', 'N', jb, i__3, i__4, 
			        c_b13, &a[j * a_dim1 + 1], lda, &a[(j + jb) * 
			        a_dim1 + 1], lda, c_b14, &a[j + (j + jb) * 
			        a_dim1], lda);
		        i__3 = n - j - jb + 1;
		        dtrsm('L', 'U', 'T', 'N', jb, 
			        i__3, c_b14, &a[j + j * a_dim1], lda, &a[j + (j 
			        + jb) * a_dim1], lda);
		    }
    /* L10: */
	        }

	    } else {

    /*           Compute the Cholesky factorization A = L*L'. */

	        i__2 = n;
	        i__1 = nb;
	        for (j = 1; i__1 < 0 ? j >= i__2 : j <= i__2; j += i__1) {

    /*              Update and factorize the current diagonal block and test */
    /*              for non-positive-definiteness. */

    /* Computing MIN */
		    i__3 = nb; i__4 = n - j + 1;
		    jb = min(i__3,i__4);
		    i__3 = j - 1;
		    dsyrk('L', 'N', jb, i__3, c_b13, &a[j + 
			    a_dim1], lda, c_b14, &a[j + j * a_dim1], lda);
		    dpotf2('L', jb, &a[j + j * a_dim1], lda, ref info);
		    if (info != 0) {
		        goto L30;
		    }
		    if (j + jb <= n) {

    /*                 Compute the current block column. */

		        i__3 = n - j - jb + 1;
		        i__4 = j - 1;
		        dgemm('N', 'T', i__3, jb, i__4, 
			        c_b13, &a[j + jb + a_dim1], lda, &a[j + a_dim1], 
			        lda, c_b14, &a[j + jb + j * a_dim1], lda);
		        i__3 = n - j - jb + 1;
		        dtrsm('R', 'L', 'T', 'N', i__3, 
			        jb, c_b14, &a[j + j * a_dim1], lda, &a[j + jb + 
			        j * a_dim1], lda);
		    }
    /* L20: */
	        }
	    }
        }
        goto L40;

    L30:
        info = info + j - 1;

    L40:
        return 0;
    } 
}

