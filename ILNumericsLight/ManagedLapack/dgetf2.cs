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
    public static unsafe int dgetf2(int m, int n, double *a, int lda, int *ipiv, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b8 = -1.0;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;
        double d__1;

        /* Local variables */
        int i__, j, jp;
        double sfmin;

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
	    xerbla("DGETF2", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    return 0;
        }

    /*     Compute machine safe minimum */

        sfmin = dlamch('S');

        i__1 = min(m,n);
        for (j = 1; j <= i__1; ++j) {

    /*        Find pivot and test for singularity. */

	    i__2 = m - j + 1;
	    jp = j - 1 + idamax(i__2, &a[j + j * a_dim1], c__1);
	    ipiv[j] = jp;
	    if (a[jp + j * a_dim1] != 0.0) {

    /*           Apply the interchange to columns 1:N. */

	        if (jp != j) {
		    dswap(n, &a[j + a_dim1], lda, &a[jp + a_dim1], lda);
	        }

    /*           Compute elements J+1:M of J-th column. */

	        if (j < m) {
		    if ((abs(a[j + j * a_dim1])) >= sfmin) {
		        i__2 = m - j;
		        d__1 = 1.0 / a[j + j * a_dim1];
		        dscal(i__2, d__1, &a[j + 1 + j * a_dim1], c__1);
		    } else {
		        i__2 = m - j;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    a[j + i__ + j * a_dim1] /= a[j + j * a_dim1];
    /* L20: */
		        }
		    }
	        }

	    } else if (info == 0) {

	        info = j;
	    }

	    if (j < min(m,n)) {

    /*           Update trailing submatrix. */

	        i__2 = m - j;
	        i__3 = n - j;
	        dger(i__2, i__3, c_b8, &a[j + 1 + j * a_dim1], c__1, &a[j + (
		        j + 1) * a_dim1], lda, &a[j + 1 + (j + 1) * a_dim1], lda);
	    }
    /* L10: */
        }
        return 0;
    } 
}

