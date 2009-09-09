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
    public static unsafe int dlazq3(int i0, int n0, double* z__, int pp, ref double dmin__, ref double sigma,
        ref double desig, double qmax, ref int nfail, ref int iter, ref int ndiv, bool ieee, ref int ttype,
        ref double dmin1, ref double dmin2, ref double dn, ref double dn1, ref double dn2, ref double tau)
    {
        /* System generated locals */
        int i__1;
        double d__1, d__2;

        /* Local variables */
        double g, s, t;
        int j4, nn;
        double eps, tol;
        int n0in, ipn4;
        double tol2, temp;
        double safmin;

        /* Parameter adjustments */
        --z__;

        /* Function Body */
        n0in = n0;
        eps = dlamch('P');
        safmin = dlamch('S');
        tol = eps * 100.0;
    /* Computing 2nd power */
        d__1 = tol;
        tol2 = d__1 * d__1;
        g = 0.0;

    /*     Check for deflation. */

    L10:

        if (n0 < i0) {
	    return 0;
        }
        if (n0 == i0) {
	    goto L20;
        }
        nn = (n0 << 2) + pp;
        if (n0 == i0 + 1) {
	    goto L40;
        }

    /*     Check whether E(N0-1) is negligible, 1 eigenvalue. */

        if (z__[nn - 5] > tol2 * (sigma + z__[nn - 3]) && z__[nn - (pp << 1) - 
	        4] > tol2 * z__[nn - 7]) {
	    goto L30;
        }

    L20:

        z__[(n0 << 2) - 3] = z__[(n0 << 2) + pp - 3] + sigma;
        --(n0);
        goto L10;

    /*     Check  whether E(N0-2) is negligible, 2 eigenvalues. */

    L30:

        if (z__[nn - 9] > tol2 * sigma && z__[nn - (pp << 1) - 8] > tol2 * z__[
	        nn - 11]) {
	    goto L50;
        }

    L40:

        if (z__[nn - 3] > z__[nn - 7]) {
	    s = z__[nn - 3];
	    z__[nn - 3] = z__[nn - 7];
	    z__[nn - 7] = s;
        }
        if (z__[nn - 5] > z__[nn - 3] * tol2) {
	    t = (z__[nn - 7] - z__[nn - 3] + z__[nn - 5]) * .5;
	    s = z__[nn - 3] * (z__[nn - 5] / t);
	    if (s <= t) {
	        s = z__[nn - 3] * (z__[nn - 5] / (t * (sqrt(s / t + 1.0) + 1.0)));
	    } else {
	        s = z__[nn - 3] * (z__[nn - 5] / (t + sqrt(t) * sqrt(t + s)));
	    }
	    t = z__[nn - 7] + (s + z__[nn - 5]);
	    z__[nn - 3] *= z__[nn - 7] / t;
	    z__[nn - 7] = t;
        }
        z__[(n0 << 2) - 7] = z__[nn - 7] + sigma;
        z__[(n0 << 2) - 3] = z__[nn - 3] + sigma;
        n0 += -2;
        goto L10;

    L50:

    /*     Reverse the qd-array, if warranted. */

        if (dmin__ <= 0.0 || n0 < n0in) {
	    if (z__[(i0 << 2) + pp - 3] * 1.05 < z__[(n0 << 2) + pp - 3]) {
	        ipn4 = i0 + n0 << 2;
	        i__1 = i0 + n0 - 1 << 1;
	        for (j4 = i0 << 2; j4 <= i__1; j4 += 4) {
		    temp = z__[j4 - 3];
		    z__[j4 - 3] = z__[ipn4 - j4 - 3];
		    z__[ipn4 - j4 - 3] = temp;
		    temp = z__[j4 - 2];
		    z__[j4 - 2] = z__[ipn4 - j4 - 2];
		    z__[ipn4 - j4 - 2] = temp;
		    temp = z__[j4 - 1];
		    z__[j4 - 1] = z__[ipn4 - j4 - 5];
		    z__[ipn4 - j4 - 5] = temp;
		    temp = z__[j4];
		    z__[j4] = z__[ipn4 - j4 - 4];
		    z__[ipn4 - j4 - 4] = temp;
    /* L60: */
	        }
	        if (n0 - i0 <= 4) {
		    z__[(n0 << 2) + pp - 1] = z__[(i0 << 2) + pp - 1];
		    z__[(n0 << 2) - pp] = z__[(i0 << 2) - pp];
	        }
    /* Computing MIN */
	        d__1 = dmin2;
            d__2 = z__[(n0 << 2) + pp - 1];
	        dmin2 = min(d__1,d__2);
    /* Computing MIN */
	        d__1 = z__[(n0 << 2) + pp - 1];
            d__2 = z__[(i0 << 2) + pp - 1];
		    d__1 = min(d__1,d__2);
            d__2 = z__[(i0 << 2) + pp + 3];
	        z__[(n0 << 2) + pp - 1] = min(d__1,d__2);
    /* Computing MIN */
	        d__1 = z__[(n0 << 2) - pp];
            d__2 = z__[(i0 << 2) - pp];
            d__1 = min(d__1,d__2);
            d__2 = z__[(i0 << 2) - pp + 4];
	        z__[(n0 << 2) - pp] = min(d__1,d__2);
    /* Computing MAX */
	        d__1 = qmax;
            d__2 = z__[(i0 << 2) + pp - 3];
            d__1 = max(d__1, d__2);
            d__2 = z__[(i0 << 2) + pp + 1];
	        qmax = max(d__1,d__2);
	        dmin__ = -0.0;
	    }
        }

    /* Computing MIN */
        d__1 = z__[(n0 << 2) + pp - 1];
        d__2 = z__[(n0 << 2) + pp - 9];
        d__1 = min(d__1,d__2);
        d__2 = dmin2 + z__[(n0 << 2) - pp];
        if (dmin__ < 0.0 || safmin * qmax < min(d__1,d__2)) {

    /*        Choose a shift. */

	    dlazq4(i0, n0, &z__[1], pp, n0in, dmin__, dmin1, dmin2, dn, dn1, 
		    dn2, ref tau, ref ttype, ref g);

    /*        Call dqds until DMIN > 0.0 */

    L80:

	    dlasq5(i0, n0, &z__[1], pp, tau, dmin__, ref dmin1,
            ref dmin2, ref dn, ref dn1, ref dn2, ieee);

	    ndiv += n0 - i0 + 2;
	    ++(iter);

    /*        Check status. */

	    if (dmin__ >= 0.0 && dmin1 > 0.0) {

    /*           Success. */

	        goto L100;

	    } else if (dmin__ < 0.0 && dmin1 > 0.0 && z__[(n0 - 1 << 2) - pp] < 
		    tol * (sigma + dn1) && abs(dn) < tol * sigma) {

    /*           Convergence hidden by negative DN. */

	        z__[(n0 - 1 << 2) - pp + 2] = 0.0;
	        dmin__ = 0.0;
	        goto L100;
	    } else if (dmin__ < 0.0) {

    /*           TAU too big. Select new TAU and try again. */

	        ++(nfail);
	        if (ttype < -22) {

    /*              Failed twice. Play it safe. */

		    tau = 0.0;
	        } else if (dmin1 > 0.0) {

    /*              Late failure. Gives excellent shift. */

		    tau = (tau + dmin__) * (1.0 - eps * 2.0);
		    ttype += -11;
	        } else {

    /*              Early failure. Divide by 4. */

		    tau *= .25;
		    ttype += -12;
	        }
	        goto L80;
	    } else if (double.IsNaN(dmin__)) {

    /*           NaN. */

	        tau = 0.0;
	        goto L80;
	    } else {

    /*           Possible underflow. Play it safe. */

	        goto L90;
	    }
        }

    /*     Risk of underflow. */

    L90:
        dlasq6(i0, n0, &z__[1], pp, ref dmin__, ref dmin1, ref dmin2, ref dn, ref dn1, ref dn2);
        ndiv += n0 - i0 + 2;
        ++(iter);
        tau = 0.0;

    L100:
        if (tau < sigma) {
	    desig += tau;
	    t = sigma + desig;
	    desig -= t - sigma;
        } else {
	    t = sigma + tau;
	    desig = sigma - (t - tau) + desig;
        }
        sigma = t;

        return 0;
    } 
}

