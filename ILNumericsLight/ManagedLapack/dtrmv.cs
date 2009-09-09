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
    public static unsafe int dtrmv(char uplo, char trans, char diag, int n, double* a, int lda, double* x, int incx)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__, j, ix, jx, kx=0, info;
        double temp;
        bool nounit;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --x;

        /* Function Body */
        info = 0;
        if (! lsame(uplo, 'U') && ! lsame(uplo, 'L')) {
	    info = 1;
        } else if (! lsame(trans, 'N') && ! lsame(trans, 
	        'T') && ! lsame(trans, 'C')) {
	    info = 2;
        } else if (! lsame(diag, 'U') && ! lsame(diag, 
	        'N')) {
	    info = 3;
        } else if (n < 0) {
	    info = 4;
        } else if (lda < max(1,n)) {
	    info = 6;
        } else if (incx == 0) {
	    info = 8;
        }
        if (info != 0) {
	    xerbla("DTRMV ", info);
	    return 0;
        }

    /*     Quick return if possible. */

        if (n == 0) {
	    return 0;
        }

        nounit = lsame(diag, 'N');

    /*     Set up the start point in X if the increment is not unity. This */
    /*     will be  ( N - 1 )incx  too small for descending loops. */

        if (incx <= 0) {
	    kx = 1 - (n - 1) * incx;
        } else if (incx != 1) {
	    kx = 1;
        }

    /*     Start the operations. In this version the elements of A are */
    /*     accessed sequentially with one pass through A. */

        if (lsame(trans, 'N')) {

    /*        Form  x := A*x. */

	    if (lsame(uplo, 'U')) {
	        if (incx == 1) {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        if (x[j] != 0.0) {
			    temp = x[j];
			    i__2 = j - 1;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        x[i__] += temp * a[i__ + j * a_dim1];
    /* L10: */
			    }
			    if (nounit) {
			        x[j] *= a[j + j * a_dim1];
			    }
		        }
    /* L20: */
		    }
	        } else {
		    jx = kx;
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        if (x[jx] != 0.0) {
			    temp = x[jx];
			    ix = kx;
			    i__2 = j - 1;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        x[ix] += temp * a[i__ + j * a_dim1];
			        ix += incx;
    /* L30: */
			    }
			    if (nounit) {
			        x[jx] *= a[j + j * a_dim1];
			    }
		        }
		        jx += incx;
    /* L40: */
		    }
	        }
	    } else {
	        if (incx == 1) {
		    for (j = n; j >= 1; --j) {
		        if (x[j] != 0.0) {
			    temp = x[j];
			    i__1 = j + 1;
			    for (i__ = n; i__ >= i__1; --i__) {
			        x[i__] += temp * a[i__ + j * a_dim1];
    /* L50: */
			    }
			    if (nounit) {
			        x[j] *= a[j + j * a_dim1];
			    }
		        }
    /* L60: */
		    }
	        } else {
		    kx += (n - 1) * incx;
		    jx = kx;
		    for (j = n; j >= 1; --j) {
		        if (x[jx] != 0.0) {
			    temp = x[jx];
			    ix = kx;
			    i__1 = j + 1;
			    for (i__ = n; i__ >= i__1; --i__) {
			        x[ix] += temp * a[i__ + j * a_dim1];
			        ix -= incx;
    /* L70: */
			    }
			    if (nounit) {
			        x[jx] *= a[j + j * a_dim1];
			    }
		        }
		        jx -= incx;
    /* L80: */
		    }
	        }
	    }
        } else {

    /*        Form  x := A'*x. */

	    if (lsame(uplo, 'U')) {
	        if (incx == 1) {
		    for (j = n; j >= 1; --j) {
		        temp = x[j];
		        if (nounit) {
			    temp *= a[j + j * a_dim1];
		        }
		        for (i__ = j - 1; i__ >= 1; --i__) {
			    temp += a[i__ + j * a_dim1] * x[i__];
    /* L90: */
		        }
		        x[j] = temp;
    /* L100: */
		    }
	        } else {
		    jx = kx + (n - 1) * incx;
		    for (j = n; j >= 1; --j) {
		        temp = x[jx];
		        ix = jx;
		        if (nounit) {
			    temp *= a[j + j * a_dim1];
		        }
		        for (i__ = j - 1; i__ >= 1; --i__) {
			    ix -= incx;
			    temp += a[i__ + j * a_dim1] * x[ix];
    /* L110: */
		        }
		        x[jx] = temp;
		        jx -= incx;
    /* L120: */
		    }
	        }
	    } else {
	        if (incx == 1) {
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        temp = x[j];
		        if (nounit) {
			    temp *= a[j + j * a_dim1];
		        }
		        i__2 = n;
		        for (i__ = j + 1; i__ <= i__2; ++i__) {
			    temp += a[i__ + j * a_dim1] * x[i__];
    /* L130: */
		        }
		        x[j] = temp;
    /* L140: */
		    }
	        } else {
		    jx = kx;
		    i__1 = n;
		    for (j = 1; j <= i__1; ++j) {
		        temp = x[jx];
		        ix = jx;
		        if (nounit) {
			    temp *= a[j + j * a_dim1];
		        }
		        i__2 = n;
		        for (i__ = j + 1; i__ <= i__2; ++i__) {
			    ix += incx;
			    temp += a[i__ + j * a_dim1] * x[ix];
    /* L150: */
		        }
		        x[jx] = temp;
		        jx += incx;
    /* L160: */
		    }
	        }
	    }
        }

        return 0;
    } 
}

