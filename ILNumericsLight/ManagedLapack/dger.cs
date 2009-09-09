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
    public static unsafe int dger(int m, int n, double alpha, double* x, int incx, double* y, int incy, double* a, int lda)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__, j, ix, jy, kx, info;
        double temp;

        /* Parameter adjustments */
        --x;
        --y;
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;

        /* Function Body */
        info = 0;
        if (m < 0) {
	    info = 1;
        } else if (n < 0) {
	    info = 2;
        } else if (incx == 0) {
	    info = 5;
        } else if (incy == 0) {
	    info = 7;
        } else if (lda < max(1,m)) {
	    info = 9;
        }
        if (info != 0) {
	    xerbla("DGER  ", info);
	    return 0;
        }

    /*     Quick return if possible. */

        if (m == 0 || n == 0 || alpha == 0) {
	    return 0;
        }

    /*     Start the operations. In this version the elements of A are */
    /*     accessed sequentially with one pass through A. */

        if (incy > 0) {
	    jy = 1;
        } else {
	    jy = 1 - (n - 1) * incy;
        }
        if (incx == 1) {
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        if (y[jy] != 0) {
		    temp = alpha * y[jy];
		    i__2 = m;
		    for (i__ = 1; i__ <= i__2; ++i__) {
		        a[i__ + j * a_dim1] += x[i__] * temp;
    /* L10: */
		    }
	        }
	        jy += incy;
    /* L20: */
	    }
        } else {
	    if (incx > 0) {
	        kx = 1;
	    } else {
	        kx = 1 - (m - 1) * incx;
	    }
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        if (y[jy] != 0) {
		    temp = alpha * y[jy];
		    ix = kx;
		    i__2 = m;
		    for (i__ = 1; i__ <= i__2; ++i__) {
		        a[i__ + j * a_dim1] += x[ix] * temp;
		        ix += incx;
    /* L30: */
		    }
	        }
	        jy += incy;
    /* L40: */
	    }
        }

        return 0;
    } 
}

