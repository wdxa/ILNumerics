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
    public static unsafe int dlazq4(int i0, int n0, double* z__, int pp, int n0in, double dmin__,
        double dmin1, double dmin2, double dn, double dn1, double dn2, ref double tau, ref int ttype, ref double g)
    {
        /* System generated locals */
        int i__1;
        double d__1, d__2;

        /* Local variables */
        double s=0, a2, b1, b2;
        int i4, nn, np;
        double gam, gap1, gap2;

        /* Parameter adjustments */
        --z__;

        /* Function Body */
        if (dmin__ <= 0.0) {
	    tau = -(dmin__);
	    ttype = -1;
	    return 0;
        }

        nn = (n0 << 2) + pp;
        if (n0in == n0) {

    /*        No eigenvalues deflated. */

	    if (dmin__ == dn || dmin__ == dn1) {

	        b1 = sqrt(z__[nn - 3]) * sqrt(z__[nn - 5]);
	        b2 = sqrt(z__[nn - 7]) * sqrt(z__[nn - 9]);
	        a2 = z__[nn - 7] + z__[nn - 5];

    /*           Cases 2 and 3.0 */

	        if (dmin__ == dn && dmin1 == dn1) {
		    gap2 = dmin2 - a2 - dmin2 * .25;
		    if (gap2 > 0.0 && gap2 > b2) {
		        gap1 = a2 - dn - b2 / gap2 * b2;
		    } else {
		        gap1 = a2 - dn - (b1 + b2);
		    }
		    if (gap1 > 0.0 && gap1 > b1) {
    /* Computing MAX */
		        d__1 = dn - b1 / gap1 * b1;
                d__2 = dmin__ * .5;
		        s = max(d__1,d__2);
		        ttype = -2;
		    } else {
		        s = 0.0;
		        if (dn > b1) {
			    s = dn - b1;
		        }
		        if (a2 > b1 + b2) {
    /* Computing MIN */
			    d__1 = s;
                d__2 = a2 - (b1 + b2);
			    s = min(d__1,d__2);
		        }
    /* Computing MAX */
		        d__1 = s;
                d__2 = dmin__ * 0.333;
		        s = max(d__1,d__2);
		        ttype = -3;
		    }
	        } else {

    /*              Case 4.0 */

		    ttype = -4;
		    s = dmin__ * .25;
		    if (dmin__ == dn) {
		        gam = dn;
		        a2 = 0.0;
		        if (z__[nn - 5] > z__[nn - 7]) {
			    return 0;
		        }
		        b2 = z__[nn - 5] / z__[nn - 7];
		        np = nn - 9;
		    } else {
		        np = nn - (pp << 1);
		        b2 = z__[np - 2];
		        gam = dn1;
		        if (z__[np - 4] > z__[np - 2]) {
			    return 0;
		        }
		        a2 = z__[np - 4] / z__[np - 2];
		        if (z__[nn - 9] > z__[nn - 11]) {
			    return 0;
		        }
		        b2 = z__[nn - 9] / z__[nn - 11];
		        np = nn - 13;
		    }

    /*              Approximate contribution to norm squared from I < NN-1.0 */

		    a2 += b2;
		    i__1 = (i0 << 2) - 1 + pp;
		    for (i4 = np; i4 >= i__1; i4 += -4) {
		        if (b2 == 0.0) {
			    goto L20;
		        }
		        b1 = b2;
		        if (z__[i4] > z__[i4 - 2]) {
			    return 0;
		        }
		        b2 *= z__[i4] / z__[i4 - 2];
		        a2 += b2;
		        if (max(b2,b1) * 100.0 < a2 || 0.563 < a2) {
			    goto L20;
		        }
    /* L10: */
		    }
    L20:
		    a2 *= 1.005;

    /*              Rayleigh quotient residual bound. */

		    if (a2 < .563) {
		        s = gam * (1.0 - sqrt(a2)) / (a2 + 1.0);
		    }
	        }
	    } else if (dmin__ == dn2) {

    /*           Case 5.0 */

	        ttype = -5;
	        s = dmin__ * .25;

    /*           Compute contribution to norm squared from I > NN-2.0 */

	        np = nn - (pp << 1);
	        b1 = z__[np - 2];
	        b2 = z__[np - 6];
	        gam = dn2;
	        if (z__[np - 8] > b2 || z__[np - 4] > b1) {
		    return 0;
	        }
	        a2 = z__[np - 8] / b2 * (z__[np - 4] / b1 + 1.0);

    /*           Approximate contribution to norm squared from I < NN-2.0 */

	        if (n0 - i0 > 2) {
		    b2 = z__[nn - 13] / z__[nn - 15];
		    a2 += b2;
		    i__1 = (i0 << 2) - 1 + pp;
		    for (i4 = nn - 17; i4 >= i__1; i4 += -4) {
		        if (b2 == 0.0) {
			    goto L40;
		        }
		        b1 = b2;
		        if (z__[i4] > z__[i4 - 2]) {
			    return 0;
		        }
		        b2 *= z__[i4] / z__[i4 - 2];
		        a2 += b2;
		        if (max(b2,b1) * 100.0 < a2 || .563 < a2) {
			    goto L40;
		        }
    /* L30: */
		    }
    L40:
		    a2 *= 1.005;
	        }

	        if (a2 < .563) {
		    s = gam * (1.0 - sqrt(a2)) / (a2 + 1.0);
	        }
	    } else {

    /*           Case 6, no information to guide us. */

	        if (ttype == -6) {
		    g += (1.0 - g) * .333;
	        } else if (ttype == -18) {
		    g = .083250000000000005;
	        } else {
		    g = .25;
	        }
	        s = g * dmin__;
	        ttype = -6;
	    }

        } else if (n0in == n0 + 1) {

    /*        One eigenvalue just deflated. Use DMIN1, DN1 for DMIN and DN. */

	    if (dmin1 == dn1 && dmin2 == dn2) {

    /*           Cases 7 and 8.0 */

	        ttype = -7;
	        s = dmin1 * .333;
	        if (z__[nn - 5] > z__[nn - 7]) {
		    return 0;
	        }
	        b1 = z__[nn - 5] / z__[nn - 7];
	        b2 = b1;
	        if (b2 == 0.0) {
		    goto L60;
	        }
	        i__1 = (i0 << 2) - 1 + pp;
	        for (i4 = (n0 << 2) - 9 + pp; i4 >= i__1; i4 += -4) {
		    a2 = b1;
		    if (z__[i4] > z__[i4 - 2]) {
		        return 0;
		    }
		    b1 *= z__[i4] / z__[i4 - 2];
		    b2 += b1;
		    if (max(b1,a2) * 100.0 < b2) {
		        goto L60;
		    }
    /* L50: */
	        }
    L60:
	        b2 = sqrt(b2 * 1.005);
    /* Computing 2nd power */
	        d__1 = b2;
	        a2 = dmin1 / (d__1 * d__1 + 1.0);
	        gap2 = dmin2 * .5 - a2;
	        if (gap2 > 0.0 && gap2 > b2 * a2) {
    /* Computing MAX */
		    d__1 = s;
            d__2 = a2 * (1.0 - a2 * 1.001 * (b2 / gap2) * b2);
		    s = max(d__1,d__2);
	        } else {
    /* Computing MAX */
		    d__1 = s;
            d__2 = a2 * (1.0 - b2 * 1.001);
		    s = max(d__1,d__2);
		    ttype = -8;
	        }
	    } else {

    /*           Case 9. */

	        s = dmin1 * .25;
	        if (dmin1 == dn1) {
		    s = dmin1 * .5;
	        }
	        ttype = -9;
	    }

        } else if (n0in == n0 + 2) {

    /*        Two eigenvalues deflated. Use DMIN2, DN2 for DMIN and DN. */

    /*        Cases 10 and 11. */

	    if (dmin2 == dn2 && z__[nn - 5] * 2.0 < z__[nn - 7]) {
	        ttype = -10;
	        s = dmin2 * .333;
	        if (z__[nn - 5] > z__[nn - 7]) {
		    return 0;
	        }
	        b1 = z__[nn - 5] / z__[nn - 7];
	        b2 = b1;
	        if (b2 == 0.0) {
		    goto L80;
	        }
	        i__1 = (i0 << 2) - 1 + pp;
	        for (i4 = (n0 << 2) - 9 + pp; i4 >= i__1; i4 += -4) {
		    if (z__[i4] > z__[i4 - 2]) {
		        return 0;
		    }
		    b1 *= z__[i4] / z__[i4 - 2];
		    b2 += b1;
		    if (b1 * 100.0 < b2) {
		        goto L80;
		    }
    /* L70: */
	        }
    L80:
	        b2 = sqrt(b2 * 1.005);
    /* Computing 2nd power */
	        d__1 = b2;
	        a2 = dmin2 / (d__1 * d__1 + 1.0);
	        gap2 = z__[nn - 7] + z__[nn - 9] - sqrt(z__[nn - 11]) * sqrt(z__[
		        nn - 9]) - a2;
	        if (gap2 > 0.0 && gap2 > b2 * a2) {
    /* Computing MAX */
		    d__1 = s;
            d__2 = a2 * (1.0 - a2 * 1.001 * (b2 / gap2) * b2);
		    s = max(d__1,d__2);
	        } else {
    /* Computing MAX */
		    d__1 = s;
            d__2 = a2 * (1.0 - b2 * 1.001);
		    s = max(d__1,d__2);
	        }
	    } else {
	        s = dmin2 * .25;
	        ttype = -11;
	    }
        } else if (n0in > n0 + 2) {

    /*        Case 12, more than two eigenvalues deflated. No information. */

	    s = 0.0;
	    ttype = -12;
        }

        tau = s;
        return 0;
    }
}

