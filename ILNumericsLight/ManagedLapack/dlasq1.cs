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
    public static unsafe int dlasq1(int n, double* d__, double* e, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__2 = 2;
        const int c__0 = 0;

        /* System generated locals */
        int i__1, i__2;
        double d__1, d__2, d__3;

        /* Local variables */
        int i__;
        double eps;
        double scale;
        int iinfo=0;
        double sigmn=0;
        double sigmx=0;
        double safmin;

        /* Parameter adjustments */
        --work;
        --e;
        --d__;

        /* Function Body */
        info = 0;
        if (n < 0) {
	    info = -2;
	    i__1 = -(info);
	    xerbla("DLASQ1", i__1);
	    return 0;
        } else if (n == 0) {
	    return 0;
        } else if (n == 1) {
	    d__[1] = abs(d__[1]);
	    return 0;
        } else if (n == 2) {
	    dlas2(d__[1], e[1], d__[2], ref sigmn, ref sigmx);
	    d__[1] = sigmx;
	    d__[2] = sigmn;
	    return 0;
        }

    /*     Estimate the largest singular value. */

        sigmx = 0.0;
        i__1 = n - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {
        d__1 = d__[i__];
	    d__[i__] = abs(d__1);
    /* Computing MAX */
	    d__2 = sigmx;
        d__1 = e[i__];
        d__3 = ( abs(d__1));
	    sigmx = max(d__2,d__3);
    /* L10: */
        }
        d__1 = d__[n];
        d__[n] = (abs(d__1));

    /*     Early return if SIGMX is zero (matrix is already diagonal). */

        if (sigmx == 0.0) {
	    dlasrt('D', n, &d__[1], ref iinfo);
	    return 0;
        }

        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing MAX */
            d__1 = sigmx;
            d__2 = d__[i__];
	    sigmx = max(d__1,d__2);
    /* L20: */
        }

    /*     Copy D and E into WORK (in the Z format) and scale (squaring the */
    /*     input data makes scaling by a power of the radix pointless). */

        eps = dlamch('P');
        safmin = dlamch('S');
        scale = sqrt(eps / safmin);
        dcopy(n, &d__[1], c__1, &work[1], c__2);
        i__1 = n - 1;
        dcopy(i__1, &e[1], c__1, &work[2], c__2);
        i__1 = (n << 1) - 1;
        i__2 = (n << 1) - 1;
        dlascl('G', c__0, c__0, sigmx, scale, i__1, c__1, &work[1], i__2, ref iinfo);

    /*     Compute the q's and e's. */

        i__1 = (n << 1) - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing 2nd power */
	    d__1 = work[i__];
	    work[i__] = d__1 * d__1;
    /* L30: */
        }
        work[n * 2] = 0.0;

        dlasq2(n, &work[1], ref info);

        if (info == 0) {
	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        d__[i__] = sqrt(work[i__]);
    /* L40: */
	    }
	    dlascl('G', c__0, c__0, scale, sigmx, n, c__1, &d__[1], n, ref iinfo);
        }

        return 0;
    } 
}

