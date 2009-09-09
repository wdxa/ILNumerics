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
    public static unsafe int dorg2r(int m, int n, int k, double* a, int lda, double* tau, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;
        double d__1;

        /* Local variables */
        int i__, j, l;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        if (m < 0) {
	    info = -1;
        } else if (n < 0 || n > m) {
	    info = -2;
        } else if (k < 0 || k > n) {
	    info = -3;
        } else if (lda < max(1,m)) {
	    info = -5;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORG2R", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n <= 0) {
	    return 0;
        }

    /*     Initialise columns k+1:n to columns of the unit matrix */

        i__1 = n;
        for (j = k + 1; j <= i__1; ++j) {
	    i__2 = m;
	    for (l = 1; l <= i__2; ++l) {
	        a[l + j * a_dim1] = 0.0;
    /* L10: */
	    }
	    a[j + j * a_dim1] = 1.0;
    /* L20: */
        }

        for (i__ = k; i__ >= 1; --i__) {

    /*        Apply H(i) to A(i:m,i:n) from the left */

	    if (i__ < n) {
	        a[i__ + i__ * a_dim1] = 1.0;
	        i__1 = m - i__ + 1;
	        i__2 = n - i__;
	        dlarf('R', i__1, i__2, &a[i__ + i__ * a_dim1], c__1, tau[
		        i__], &a[i__ + (i__ + 1) * a_dim1], lda, &work[1]);
	    }
	    if (i__ < m) {
	        i__1 = m - i__;
	        d__1 = -tau[i__];
	        dscal(i__1, d__1, &a[i__ + 1 + i__ * a_dim1], c__1);
	    }
	    a[i__ + i__ * a_dim1] = 1.0 - tau[i__];

    /*        Set A(1:i-1,i) to zero */

	    i__1 = i__ - 1;
	    for (l = 1; l <= i__1; ++l) {
	        a[l + i__ * a_dim1] = 0.0;
    /* L30: */
	    }
    /* L40: */
        }
        return 0;
    } 
}

