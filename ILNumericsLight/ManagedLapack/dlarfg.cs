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
    public static unsafe int dlarfg(int n, ref double alpha, double* x, int incx, ref double tau)
    {
        /* System generated locals */
        int i__1;
        double d__1;

        /* Local variables */
        int j, knt;
        double beta;
        double xnorm;
        double safmin, rsafmn;

        /* Parameter adjustments */
        --x;

        /* Function Body */
        if (n <= 1) {
	    tau = 0.0;
	    return 0;
        }

        i__1 = n - 1;
        xnorm = dnrm2(i__1, &x[1], incx);

        if (xnorm == 0.0) {

    /*        H  =  I */

	    tau = 0.0;
        } else {

    /*        general case */

	    d__1 = dlapy2(alpha, xnorm);
	    beta = -d_sign(d__1, alpha);
	    safmin = dlamch('S') / dlamch('E');
	    if (abs(beta) < safmin) {

    /*           XNORM, BETA may be inaccurate; scale X and recompute them */

	        rsafmn = 1.0 / safmin;
	        knt = 0;
    L10:
	        ++knt;
	        i__1 = n - 1;
	        dscal(i__1, rsafmn, &x[1], incx);
	        beta *= rsafmn;
	        alpha *= rsafmn;
	        if (abs(beta) < safmin) {
		    goto L10;
	        }

    /*           New BETA is at most 1, at least SAFMIN */

	        i__1 = n - 1;
	        xnorm = dnrm2(i__1, &x[1], incx);
	        d__1 = dlapy2(alpha, xnorm);
	        beta = -d_sign(d__1, alpha);
	        tau = (beta - alpha) / beta;
	        i__1 = n - 1;
	        d__1 = 1.0 / (alpha - beta);
	        dscal(i__1, d__1, &x[1], incx);

    /*           If ALPHA is subnormal, it may lose relative accuracy */

	        alpha = beta;
	        i__1 = knt;
	        for (j = 1; j <= i__1; ++j) {
		    alpha *= safmin;
    /* L20: */
	        }
	    } else {
	        tau = (beta - alpha) / beta;
	        i__1 = n - 1;
	        d__1 = 1.0 / (alpha - beta);
	        dscal(i__1, d__1, &x[1], incx);
	        alpha = beta;
	    }
        }

        return 0;
    } 
}

