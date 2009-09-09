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
    public static unsafe int dgemv(char trans, int m, int n, double alpha, double* a, int lda,
        double* x, int incx, double beta, double* y, int incy)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__, j, ix, iy, jx, jy, kx, ky, info;
        double temp;
        int lenx, leny;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --x;
        --y;

        /* Function Body */
        info = 0;
        if (! lsame(trans, 'N') && ! lsame(trans, 'T') && ! lsame(trans, 'C')
	        ) {
	    info = 1;
        } else if (m < 0) {
	    info = 2;
        } else if (n < 0) {
	    info = 3;
        } else if (lda < max(1,m)) {
	    info = 6;
        } else if (incx == 0) {
	    info = 8;
        } else if (incy == 0) {
	    info = 11;
        }
        if (info != 0) {
	    xerbla("DGEMV ", info);
	    return 0;
        }

    /*     Quick return if possible. */

        if (m == 0 || n == 0 || alpha == 0.0 && beta == 1.0) {
	    return 0;
        }

    /*     Set  LENX  and  LENY, the lengths of the vectors x and y, and set */
    /*     up the start points in  X  and  Y. */

        if (lsame(trans, 'N')) {
	    lenx = n;
	    leny = m;
        } else {
	    lenx = m;
	    leny = n;
        }
        if (incx > 0) {
	    kx = 1;
        } else {
	    kx = 1 - (lenx - 1) * incx;
        }
        if (incy > 0) {
	    ky = 1;
        } else {
	    ky = 1 - (leny - 1) * incy;
        }

    /*     Start the operations. In this version the elements of A are */
    /*     accessed sequentially with one pass through A. */

    /*     First form  y := beta*y. */

        if (beta != 1.0) {
	    if (incy == 1) {
	        if (beta == 0.0) {
		    i__1 = leny;
		    for (i__ = 1; i__ <= i__1; ++i__) {
		        y[i__] = 0.0;
    /* L10: */
		    }
	        } else {
		    i__1 = leny;
		    for (i__ = 1; i__ <= i__1; ++i__) {
		        y[i__] = beta * y[i__];
    /* L20: */
		    }
	        }
	    } else {
	        iy = ky;
	        if (beta == 0.0) {
		    i__1 = leny;
		    for (i__ = 1; i__ <= i__1; ++i__) {
		        y[iy] = 0.0;
		        iy += incy;
    /* L30: */
		    }
	        } else {
		    i__1 = leny;
		    for (i__ = 1; i__ <= i__1; ++i__) {
		        y[iy] = beta * y[iy];
		        iy += incy;
    /* L40: */
		    }
	        }
	    }
        }
        if (alpha == 0.0) {
	    return 0;
        }
        if (lsame(trans, 'N')) {

    /*        Form  y := alpha*A*x + y. */

	    jx = kx;
	    if (incy == 1) {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (x[jx] != 0.0) {
		        temp = alpha * x[jx];
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    y[i__] += temp * a[i__ + j * a_dim1];
    /* L50: */
		        }
		    }
		    jx += incx;
    /* L60: */
	        }
	    } else {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (x[jx] != 0.0) {
		        temp = alpha * x[jx];
		        iy = ky;
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    y[iy] += temp * a[i__ + j * a_dim1];
			    iy += incy;
    /* L70: */
		        }
		    }
		    jx += incx;
    /* L80: */
	        }
	    }
        } else {

    /*        Form  y := alpha*A'*x + y. */

	    jy = ky;
	    if (incx == 1) {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    temp = 0.0;
		    i__2 = m;
		    for (i__ = 1; i__ <= i__2; ++i__) {
		        temp += a[i__ + j * a_dim1] * x[i__];
    /* L90: */
		    }
		    y[jy] += alpha * temp;
		    jy += incy;
    /* L100: */
	        }
	    } else {
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    temp = 0.0;
		    ix = kx;
		    i__2 = m;
		    for (i__ = 1; i__ <= i__2; ++i__) {
		        temp += a[i__ + j * a_dim1] * x[ix];
		        ix += incx;
    /* L110: */
		    }
		    y[jy] += alpha * temp;
		    jy += incy;
    /* L120: */
	        }
	    }
        }

        return 0;
    } 
}

