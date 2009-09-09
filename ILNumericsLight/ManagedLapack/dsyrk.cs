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
    public static unsafe int dsyrk(char uplo, char trans, int n, int k,
        double alpha, double* a, int lda, double beta, double* c__, int ldc)
    {
        /* System generated locals */
        int a_dim1, a_offset, c_dim1, c_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, j, l, info;
        double temp;
        int nrowa;
        bool upper;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;

        /* Function Body */
        if (lsame(trans, 'N')) {
	    nrowa = n;
        } else {
	    nrowa = k;
        }
        upper = lsame(uplo, 'U');

        info = 0;
        if (! upper && ! lsame(uplo, 'L')) {
	    info = 1;
        } else if (! lsame(trans, 'N') && ! lsame(trans, 
	        'T') && ! lsame(trans, 'C')) {
	    info = 2;
        } else if (n < 0) {
	    info = 3;
        } else if (k < 0) {
	    info = 4;
        } else if (lda < max(1,nrowa)) {
	    info = 7;
        } else if (ldc < max(1,n)) {
	    info = 10;
        }
        if (info != 0) {
	    xerbla("DSYRK ", info);
	    return 0;
        }

    /*     Quick return if possible. */

        if (n == 0 || (alpha == 0.0 || k == 0) && beta == 1.0) {
	    return 0;
        }

    /*     And when  alpha.eq.zero. */

        if (alpha == 0.0) {
	    if (upper) {
	        if (beta == 0.0) {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = j;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = 0.0;
    /* L10: */
		        }
    /* L20: */
		    }
	        } else {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = j;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
    /* L30: */
		        }
    /* L40: */
		    }
	        }
	    } else {
	        if (beta == 0.0) {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = j; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = 0.0;
    /* L50: */
		        }
    /* L60: */
		    }
	        } else {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = j; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
    /* L70: */
		        }
    /* L80: */
		    }
	        }
	    }
	    return 0;
        }

    /*     Start the operations. */

        if (lsame(trans, 'N')) {

    /*        Form  C := alpha*A*A' + beta*C. */

	    if (upper) {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (beta == 0.0) {
		        i__2 = j;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = 0.0;
    /* L90: */
		        }
		    } else if (beta != 1.0) {
		        i__2 = j;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
    /* L100: */
		        }
		    }
		    i__2 = k;
		    for (l = 1; l <= i__2; ++l) {
		        if (a[j + l * a_dim1] != 0.0) {
			    temp = alpha * a[j + l * a_dim1];
			    i__3 = j;
			    for (i__ = 1; i__ <= i__3; ++i__) {
			        c__[i__ + j * c_dim1] += temp * a[i__ + l * 
				        a_dim1];
    /* L110: */
			    }
		        }
    /* L120: */
		    }
    /* L130: */
	        }
	    } else {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (beta == 0.0) {
		        i__2 = n;
		        for (i__ = j; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = 0.0;
    /* L140: */
		        }
		    } else if (beta != 1.0) {
		        i__2 = n;
		        for (i__ = j; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] = beta * c__[i__ + j * c_dim1];
    /* L150: */
		        }
		    }
		    i__2 = k;
		    for (l = 1; l <= i__2; ++l) {
		        if (a[j + l * a_dim1] != 0.0) {
			    temp = alpha * a[j + l * a_dim1];
			    i__3 = n;
			    for (i__ = j; i__ <= i__3; ++i__) {
			        c__[i__ + j * c_dim1] += temp * a[i__ + l * 
				        a_dim1];
    /* L160: */
			    }
		        }
    /* L170: */
		    }
    /* L180: */
	        }
	    }
        } else {

    /*        Form  C := alpha*A'*A + beta*C. */

	    if (upper) {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    i__2 = j;
		    for (i__ = 1; i__ <= i__2; ++i__) {
		        temp = 0.0;
		        i__3 = k;
		        for (l = 1; l <= i__3; ++l) {
			    temp += a[l + i__ * a_dim1] * a[l + j * a_dim1];
    /* L190: */
		        }
		        if (beta == 0.0) {
			    c__[i__ + j * c_dim1] = alpha * temp;
		        } else {
			    c__[i__ + j * c_dim1] = alpha * temp + beta * c__[
				    i__ + j * c_dim1];
		        }
    /* L200: */
		    }
    /* L210: */
	        }
	    } else {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    i__2 = n;
		    for (i__ = j; i__ <= i__2; ++i__) {
		        temp = 0.0;
		        i__3 = k;
		        for (l = 1; l <= i__3; ++l) {
			    temp += a[l + i__ * a_dim1] * a[l + j * a_dim1];
    /* L220: */
		        }
		        if (beta == 0.0) {
			    c__[i__ + j * c_dim1] = alpha * temp;
		        } else {
			    c__[i__ + j * c_dim1] = alpha * temp + beta * c__[
				    i__ + j * c_dim1];
		        }
    /* L230: */
		    }
    /* L240: */
	        }
	    }
        }

        return 0;
    } 
}

