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
    public static unsafe int dlaset(char uplo, int m, int n, double alpha, double beta, double* a, int lda)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, j;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;

        /* Function Body */
        if (lsame(uplo, 'U')) {

    /*        Set the strictly upper triangular or trapezoidal part of the */
    /*        array to ALPHA. */

	    i__1 = n;
	    for (j = 2; j <= i__1; ++j) {
    /* Computing MIN */
	        i__3 = j - 1;
	        i__2 = min(i__3,m);
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] = alpha;
    /* L10: */
	        }
    /* L20: */
	    }

        } else if (lsame(uplo, 'L')) {

    /*        Set the strictly lower triangular or trapezoidal part of the */
    /*        array to ALPHA. */

	    i__1 = min(m,n);
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = j + 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] = alpha;
    /* L30: */
	        }
    /* L40: */
	    }

        } else {

    /*        Set the leading m-by-n submatrix to ALPHA. */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] = alpha;
    /* L50: */
	        }
    /* L60: */
	    }
        }

    /*     Set the first min(M,N) diagonal elements to BETA. */

        i__1 = min(m,n);
        for (i__ = 1; i__ <= i__1; ++i__) {
	    a[i__ + i__ * a_dim1] = beta;
    /* L70: */
        }

        return 0;
    } 
}

