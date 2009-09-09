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
    public static unsafe int dlasq2(int n, double* z__, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__2 = 2;
        const int c__10 = 10;
        const int c__3 = 3;
        const int c__4 = 4;
        const int c__11 = 11;

        /* System generated locals */
        int i__1, i__2, i__3;
        double d__1, d__2;

        /* Local variables */
        double d__, e;
        int k;
        double s, t;
        int i0, i4, n0;
        double dn;
        int pp;
        double dn1, dn2, eps, tau, tol;
        int ipn4;
        double tol2;
        bool ieee;
        int nbig;
        double dmin__, emin, emax;
        int ndiv, iter;
        double qmin, temp, qmax, zmax;
        int splt;
        double dmin1, dmin2;
        int nfail;
        double desig, trace, sigma;
        int iinfo=0, ttype;
        int iwhila, iwhilb;
        double oldemn, safmin;

        /* Parameter adjustments */
        --z__;

        /* Function Body */
        info = 0;
        eps = dlamch('P');
        safmin = dlamch('S');
        tol = eps * 100.0;
    /* Computing 2nd power */
        d__1 = tol;
        tol2 = d__1 * d__1;

        if (n < 0) {
	    info = -1;
	    xerbla("DLASQ2", c__1);
	    return 0;
        } else if (n == 0) {
	    return 0;
        } else if (n == 1) {

    /*        1-by-1 case. */

	    if (z__[1] < 0.0) {
	        info = -201;
	        xerbla("DLASQ2", c__2);
	    }
	    return 0;
        } else if (n == 2) {

    /*        2-by-2 case. */

	    if (z__[2] < 0.0 || z__[3] < 0.0) {
	        info = -2;
	        xerbla("DLASQ2", c__2);
	        return 0;
	    } else if (z__[3] > z__[1]) {
	        d__ = z__[3];
	        z__[3] = z__[1];
	        z__[1] = d__;
	    }
	    z__[5] = z__[1] + z__[2] + z__[3];
	    if (z__[2] > z__[3] * tol2) {
	        t = (z__[1] - z__[3] + z__[2]) * .5;
	        s = z__[3] * (z__[2] / t);
	        if (s <= t) {
		    s = z__[3] * (z__[2] / (t * (sqrt(s / t + 1.0) + 1.0)));
	        } else {
		    s = z__[3] * (z__[2] / (t + sqrt(t) * sqrt(t + s)));
	        }
	        t = z__[1] + (s + z__[2]);
	        z__[3] *= z__[1] / t;
	        z__[1] = t;
	    }
	    z__[2] = z__[3];
	    z__[6] = z__[2] + z__[1];
	    return 0;
        }

    /*     Check for negative data and compute sums of q's and e's. */

        z__[n * 2] = 0.0;
        emin = z__[2];
        qmax = 0.0;
        zmax = 0.0;
        d__ = 0.0;
        e = 0.0;

        i__1 = n - 1 << 1;
        for (k = 1; k <= i__1; k += 2) {
	    if (z__[k] < 0.0) {
	        info = -(k + 200);
	        xerbla("DLASQ2", c__2);
	        return 0;
	    } else if (z__[k + 1] < 0.0) {
	        info = -(k + 201);
	        xerbla("DLASQ2", c__2);
	        return 0;
	    }
	    d__ += z__[k];
	    e += z__[k + 1];
    /* Computing MAX */
	    d__1 = qmax;
        d__2 = z__[k];
	    qmax = max(d__1,d__2);
    /* Computing MIN */
	    d__1 = emin;
        d__2 = z__[k + 1];
	    emin = min(d__1,d__2);
    /* Computing MAX */
	    d__1 = max(qmax,zmax);
        d__2 = z__[k + 1];
	    zmax = max(d__1,d__2);
    /* L10: */
        }
        if (z__[(n << 1) - 1] < 0.0) {
	    info = -((n << 1) + 199);
	    xerbla("DLASQ2", c__2);
	    return 0;
        }
        d__ += z__[(n << 1) - 1];
    /* Computing MAX */
        d__1 = qmax;
        d__2 = z__[(n << 1) - 1];
        qmax = max(d__1,d__2);
        zmax = max(qmax,zmax);

    /*     Check for diagonality. */

        if (e == 0.0) {
	    i__1 = n;
	    for (k = 2; k <= i__1; ++k) {
	        z__[k] = z__[(k << 1) - 1];
    /* L20: */
	    }
	    dlasrt('D', n, &z__[1], ref iinfo);
	    z__[(n << 1) - 1] = d__;
	    return 0;
        }

        trace = d__ + e;

    /*     Check for zero data. */

        if (trace == 0.0) {
	    z__[(n << 1) - 1] = 0.0;
	    return 0;
        }

    /*     Check whether the machine is IEEE conformable. */

        ieee = ilaenv(c__10, "DLASQ2", "N", c__1, c__2, c__3, c__4) == 1 && ilaenv(c__11, "DLASQ2", "N", c__1, c__2, c__3, c__4) == 1;

    /*     Rearrange data for locality: Z=(q1,qq1,e1,ee1,q2,qq2,e2,ee2,...). */

        for (k = n << 1; k >= 2; k += -2) {
	    z__[k * 2] = 0.0;
	    z__[(k << 1) - 1] = z__[k];
	    z__[(k << 1) - 2] = 0.0;
	    z__[(k << 1) - 3] = z__[k - 1];
    /* L30: */
        }

        i0 = 1;
        n0 = n;

    /*     Reverse the qd-array, if warranted. */

        if (z__[(i0 << 2) - 3] * 1.05 < z__[(n0 << 2) - 3]) {
	    ipn4 = i0 + n0 << 2;
	    i__1 = i0 + n0 - 1 << 1;
	    for (i4 = i0 << 2; i4 <= i__1; i4 += 4) {
	        temp = z__[i4 - 3];
	        z__[i4 - 3] = z__[ipn4 - i4 - 3];
	        z__[ipn4 - i4 - 3] = temp;
	        temp = z__[i4 - 1];
	        z__[i4 - 1] = z__[ipn4 - i4 - 5];
	        z__[ipn4 - i4 - 5] = temp;
    /* L40: */
	    }
        }

    /*     Initial split checking via dqd and Li's test. */

        pp = 0;

        for (k = 1; k <= 2; ++k) {

	    d__ = z__[(n0 << 2) + pp - 3];
	    i__1 = (i0 << 2) + pp;
	    for (i4 = (n0 - 1 << 2) + pp; i4 >= i__1; i4 += -4) {
	        if (z__[i4 - 1] <= tol2 * d__) {
		    z__[i4 - 1] = -0.0;
		    d__ = z__[i4 - 3];
	        } else {
		    d__ = z__[i4 - 3] * (d__ / (d__ + z__[i4 - 1]));
	        }
    /* L50: */
	    }

    /*        dqd maps Z to ZZ plus Li's test. */

	    emin = z__[(i0 << 2) + pp + 1];
	    d__ = z__[(i0 << 2) + pp - 3];
	    i__1 = (n0 - 1 << 2) + pp;
	    for (i4 = (i0 << 2) + pp; i4 <= i__1; i4 += 4) {
	        z__[i4 - (pp << 1) - 2] = d__ + z__[i4 - 1];
	        if (z__[i4 - 1] <= tol2 * d__) {
		    z__[i4 - 1] = -0.0;
		    z__[i4 - (pp << 1) - 2] = d__;
		    z__[i4 - (pp << 1)] = 0.0;
		    d__ = z__[i4 + 1];
	        } else if (safmin * z__[i4 + 1] < z__[i4 - (pp << 1) - 2] && 
		        safmin * z__[i4 - (pp << 1) - 2] < z__[i4 + 1]) {
		    temp = z__[i4 + 1] / z__[i4 - (pp << 1) - 2];
		    z__[i4 - (pp << 1)] = z__[i4 - 1] * temp;
		    d__ *= temp;
	        } else {
		    z__[i4 - (pp << 1)] = z__[i4 + 1] * (z__[i4 - 1] / z__[i4 - (
			    pp << 1) - 2]);
		    d__ = z__[i4 + 1] * (d__ / z__[i4 - (pp << 1) - 2]);
	        }
    /* Computing MIN */
	        d__1 = emin;
            d__2 = z__[i4 - (pp << 1)];
	        emin = min(d__1,d__2);
    /* L60: */
	    }
	    z__[(n0 << 2) - pp - 2] = d__;

    /*        Now find qmax. */

	    qmax = z__[(i0 << 2) - pp - 2];
	    i__1 = (n0 << 2) - pp - 2;
	    for (i4 = (i0 << 2) - pp + 2; i4 <= i__1; i4 += 4) {
    /* Computing MAX */
	        d__1 = qmax;
            d__2 = z__[i4];
	        qmax = max(d__1,d__2);
    /* L70: */
	    }

    /*        Prepare for the next iteration on K. */

	    pp = 1 - pp;
    /* L80: */
        }

    /*     Initialise variables to pass to DLAZQ3 */

        ttype = 0;
        dmin1 = 0.0;
        dmin2 = 0.0;
        dn = 0.0;
        dn1 = 0.0;
        dn2 = 0.0;
        tau = 0.0;

        iter = 2;
        nfail = 0;
        ndiv = n0 - i0 << 1;

        i__1 = n + 1;
        for (iwhila = 1; iwhila <= i__1; ++iwhila) {
	    if (n0 < 1) {
	        goto L150;
	    }

    /*        While array unfinished do */

    /*        E(N0) holds the value of SIGMA when submatrix in I0:N0 */
    /*        splits from the rest of the array, but is negated. */

	    desig = 0.0;
	    if (n0 == n) {
	        sigma = 0.0;
	    } else {
	        sigma = -z__[(n0 << 2) - 1];
	    }
	    if (sigma < 0.0) {
	        info = 1;
	        return 0;
	    }

    /*        Find last unreduced submatrix's top index I0, find QMAX and */
    /*        EMIN. Find Gershgorin-type bound if Q's much greater than E's. */

	    emax = 0.0;
	    if (n0 > i0) {
	        emin = (abs(z__[(n0 << 2) - 5]));
	    } else {
	        emin = 0.0;
	    }
	    qmin = z__[(n0 << 2) - 3];
	    qmax = qmin;
	    for (i4 = n0 << 2; i4 >= 8; i4 += -4) {
	        if (z__[i4 - 5] <= 0.0) {
		    goto L100;
	        }
	        if (qmin >= emax * 4.0) {
    /* Computing MIN */
		    d__1 = qmin;
            d__2 = z__[i4 - 3];
		    qmin = min(d__1,d__2);
    /* Computing MAX */
		    d__1 = emax;
            d__2 = z__[i4 - 5];
		    emax = max(d__1,d__2);
	        }
    /* Computing MAX */
	        d__1 = qmax;
            d__2 = z__[i4 - 7] + z__[i4 - 5];
	        qmax = max(d__1,d__2);
    /* Computing MIN */
	        d__1 = emin;
            d__2 = z__[i4 - 5];
	        emin = min(d__1,d__2);
    /* L90: */
	    }
	    i4 = 4;

    L100:
	    i0 = i4 / 4;

    /*        Store EMIN for passing to DLAZQ3. */

	    z__[(n0 << 2) - 1] = emin;

    /*        Put -(initial shift) into DMIN. */

    /* Computing MAX */
	    d__1 = 0.0;
        d__2 = qmin - sqrt(qmin) * 2.0 * sqrt(emax);
	    dmin__ = -max(d__1,d__2);

    /*        Now I0:N0 is unreduced. PP = 0 for ping, PP = 1 for pong. */

	    pp = 0;

	    nbig = (n0 - i0 + 1) * 30;
	    i__2 = nbig;
	    for (iwhilb = 1; iwhilb <= i__2; ++iwhilb) {
	        if (i0 > n0) {
		    goto L130;
	        }

    /*           While submatrix unfinished take a good dqds step. */

	        dlazq3(i0, n0, &z__[1], pp, ref dmin__, ref sigma, ref desig, qmax, ref nfail,
                ref iter, ref ndiv, ieee, ref ttype, ref dmin1, ref dmin2, ref dn, ref dn1, ref dn2, ref tau);

	        pp = 1 - pp;

    /*           When EMIN is very small check for splits. */

	        if (pp == 0 && n0 - i0 >= 3) {
		    if (z__[n0 * 4] <= tol2 * qmax || z__[(n0 << 2) - 1] <= tol2 *
			     sigma) {
		        splt = i0 - 1;
		        qmax = z__[(i0 << 2) - 3];
		        emin = z__[(i0 << 2) - 1];
		        oldemn = z__[i0 * 4];
		        i__3 = n0 - 3 << 2;
		        for (i4 = i0 << 2; i4 <= i__3; i4 += 4) {
			    if (z__[i4] <= tol2 * z__[i4 - 3] || z__[i4 - 1] <= 
				    tol2 * sigma) {
			        z__[i4 - 1] = -sigma;
			        splt = i4 / 4;
			        qmax = 0.0;
			        emin = z__[i4 + 3];
			        oldemn = z__[i4 + 4];
			    } else {
    /* Computing MAX */
			        d__1 = qmax;
                    d__2 = z__[i4 + 1];
			        qmax = max(d__1,d__2);
    /* Computing MIN */
			        d__1 = emin;
                    d__2 = z__[i4 - 1];
			        emin = min(d__1,d__2);
    /* Computing MIN */
                    d__1 = oldemn;
                    d__2 = z__[i4];
			        oldemn = min(d__1,d__2);
			    }
    /* L110: */
		        }
		        z__[(n0 << 2) - 1] = emin;
		        z__[n0 * 4] = oldemn;
		        i0 = splt + 1;
		    }
	        }

    /* L120: */
	    }

	    info = 2;
	    return 0;

    /*        end IWHILB */

    L130:

    /* L140: */
	    ;
        }

        info = 3;
        return 0;

    /*     end IWHILA */

    L150:

    /*     Move q's to the front. */

        i__1 = n;
        for (k = 2; k <= i__1; ++k) {
	    z__[k] = z__[(k << 2) - 3];
    /* L160: */
        }

    /*     Sort and compute sum of eigenvalues. */

        dlasrt('D', n, &z__[1], ref iinfo);

        e = 0.0;
        for (k = n; k >= 1; --k) {
	    e += z__[k];
    /* L170: */
        }

    /*     Store trace, sum(eigenvalues) and information on performance. */

        z__[(n << 1) + 1] = trace;
        z__[(n << 1) + 2] = e;
        z__[(n << 1) + 3] = (double) iter;
    /* Computing 2nd power */
        i__1 = n;
        z__[(n << 1) + 4] = (double) ndiv / (double) (i__1 * i__1);
        z__[(n << 1) + 5] = nfail * 100.0 / (double) iter;
        return 0;
    } 
}

