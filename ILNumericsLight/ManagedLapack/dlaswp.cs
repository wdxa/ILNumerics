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
    public static unsafe int dlaswp(int n, double *a, int lda, int k1, int k2, int *ipiv, int incx)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4;

        /* Local variables */
        int i__, j, k, i1, i2, n32, ip, ix, ix0, inc;
        double temp;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --ipiv;

        /* Function Body */
        if (incx > 0) {
	    ix0 = k1;
	    i1 = k1;
	    i2 = k2;
	    inc = 1;
        } else if (incx < 0) {
	    ix0 = (1 - k2) * incx + 1;
	    i1 = k2;
	    i2 = k1;
	    inc = -1;
        } else {
	    return 0;
        }

        n32 = n / 32 << 5;
        if (n32 != 0) {
	    i__1 = n32;
	    for (j = 1; j <= i__1; j += 32) {
	        ix = ix0;
	        i__2 = i2;
	        i__3 = inc;
	        for (i__ = i1; i__3 < 0 ? i__ >= i__2 : i__ <= i__2; i__ += i__3) 
		        {
		    ip = ipiv[ix];
		    if (ip != i__) {
		        i__4 = j + 31;
		        for (k = j; k <= i__4; ++k) {
			    temp = a[i__ + k * a_dim1];
			    a[i__ + k * a_dim1] = a[ip + k * a_dim1];
			    a[ip + k * a_dim1] = temp;
    /* L10: */
		        }
		    }
		    ix += incx;
    /* L20: */
	        }
    /* L30: */
	    }
        }
        if (n32 != n) {
	    ++n32;
	    ix = ix0;
	    i__1 = i2;
	    i__3 = inc;
	    for (i__ = i1; i__3 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__3) {
	        ip = ipiv[ix];
	        if (ip != i__) {
		    i__2 = n;
		    for (k = n32; k <= i__2; ++k) {
		        temp = a[i__ + k * a_dim1];
		        a[i__ + k * a_dim1] = a[ip + k * a_dim1];
		        a[ip + k * a_dim1] = temp;
    /* L40: */
		    }
	        }
	        ix += incx;
    /* L50: */
	    }
        }

        return 0;
    } 
}

