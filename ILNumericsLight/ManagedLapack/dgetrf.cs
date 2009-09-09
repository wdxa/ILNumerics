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
    public static unsafe int dgetrf(int m, int n, double *a, int lda, int *ipiv, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const double c_b16 = 1.0;
        const double c_b19 = -1.0;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4, i__5;

        /* Local variables */
        int i__, j, jb, nb;
        int iinfo=0;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --ipiv;

        /* Function Body */
        info = 0;
        if (m < 0) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,m)) {
	    info = -4;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGETRF", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    return 0;
        }

    /*     Determine the block size for this environment. */

        nb = ilaenv(c__1, "DGETRF", " ", m, n, c_n1, c_n1);
        if (nb <= 1 || nb >= min(m,n)) {

    /*        Use unblocked code. */

	    dgetf2(m, n, &a[a_offset], lda, &ipiv[1], ref info);
        } else {

    /*        Use blocked code. */

	    i__1 = min(m,n);
	    i__2 = nb;
	    for (j = 1; i__2 < 0 ? j >= i__1 : j <= i__1; j += i__2) {
    /* Computing MIN */
	        i__3 = min(m,n) - j + 1;
	        jb = min(i__3,nb);

    /*           Factor diagonal and subdiagonal blocks and test for exact */
    /*           singularity. */

	        i__3 = m - j + 1;
	        dgetf2(i__3, jb, &a[j + j * a_dim1], lda, &ipiv[j], ref iinfo);

    /*           Adjust INFO and the pivot indices. */

	        if (info == 0 && iinfo > 0) {
		    info = iinfo + j - 1;
	        }
    /* Computing MIN */
            i__4 = m; i__5 = j + jb - 1;
	        i__3 = min(i__4,i__5);
	        for (i__ = j; i__ <= i__3; ++i__) {
		    ipiv[i__] = j - 1 + ipiv[i__];
    /* L10: */
	        }

    /*           Apply interchanges to columns 1:J-1.0 */

	        i__3 = j - 1;
	        i__4 = j + jb - 1;
	        dlaswp(i__3, &a[a_offset], lda, j, i__4, &ipiv[1], c__1);

	        if (j + jb <= n) {

    /*              Apply interchanges to columns J+JB:N. */

		    i__3 = n - j - jb + 1;
		    i__4 = j + jb - 1;
		    dlaswp(i__3, &a[(j + jb) * a_dim1 + 1], lda, j, i__4, &
			    ipiv[1], c__1);

    /*              Compute block row of U. */

		    i__3 = n - j - jb + 1;
		    dtrsm('L', 'L', 'N', 'U', jb, i__3, 
			    c_b16, &a[j + j * a_dim1], lda, &a[j + (j + jb) * 
			    a_dim1], lda);
		    if (j + jb <= m) {

    /*                 Update trailing submatrix. */

		        i__3 = m - j - jb + 1;
		        i__4 = n - j - jb + 1;
		        dgemm('N', 'N', i__3, i__4, jb, 
			        c_b19, &a[j + jb + j * a_dim1], lda, &a[j + (j + 
			        jb) * a_dim1], lda, c_b16, &a[j + jb + (j + jb) *
			         a_dim1], lda);
		    }
	        }
    /* L20: */
	    }
        }
        return 0;
    } 
}

