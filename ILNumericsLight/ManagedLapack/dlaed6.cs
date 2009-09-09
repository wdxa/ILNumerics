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
    public static unsafe int dlaed6(int kniter, bool orgati, double rho, double* d__, double* z__, double finit, ref double tau, ref int info)
    {
        /* System generated locals */
        int i__1;
        double d__1, d__2, d__3, d__4;

        /* Local variables */
        double a, b, c__, f;
        int i__;
        double fc, df, ddf, lbd, eta, ubd, eps, _base;
        int iter;
        double temp, temp1, temp2, temp3, temp4;
        bool scale;
        int niter;
        double small1, small2, sminv1, sminv2;
        double[] dscale = new double[3], zscale = new double[3];
        double sclfac, erretm, sclinv = 0;

        /* Parameter adjustments */
        --z__;
        --d__;

        /* Function Body */
        info = 0;

        if (orgati) {
	    lbd = d__[2];
	    ubd = d__[3];
        } else {
	    lbd = d__[1];
	    ubd = d__[2];
        }
        if (finit < 0) {
	    lbd = 0;
        } else {
	    ubd = 0;
        }

        niter = 1;
        tau = 0;
        if (kniter == 2) {
	    if (orgati) {
	        temp = (d__[3] - d__[2]) / 2;
	        c__ = rho + z__[1] / (d__[1] - d__[2] - temp);
	        a = c__ * (d__[2] + d__[3]) + z__[2] + z__[3];
	        b = c__ * d__[2] * d__[3] + z__[2] * d__[3] + z__[3] * d__[2];
	    } else {
	        temp = (d__[1] - d__[2]) / 2;
	        c__ = rho + z__[3] / (d__[3] - d__[2] - temp);
	        a = c__ * (d__[1] + d__[2]) + z__[1] + z__[2];
	        b = c__ * d__[1] * d__[2] + z__[1] * d__[2] + z__[2] * d__[1];
	    }
    /* Computing MAX */
	    d__1 = abs(a);
        d__2 = abs(b);
        d__1 = max(d__1,d__2);
        d__2 = abs(c__);
	    temp = max(d__1,d__2);
	    a /= temp;
	    b /= temp;
	    c__ /= temp;
	    if (c__ == 0) {
	        tau = b / a;
	    } else if (a <= 0) {
            d__1 = a * a - b * 4.0 * c__;
	        tau = (a - sqrt((abs(d__1)))) / (
		        c__ * 2);
	    } else {
            d__1 = a * a - b * 4.0 * c__;
	        tau = b * 2 / (a + sqrt(( abs(d__1))));
	    }
	    if (tau < lbd || tau > ubd) {
	        tau = (lbd + ubd) / 2;
	    }
	    if (d__[1] == tau || d__[2] == tau || d__[3] == tau) {
	        tau = 0;
	    } else {
	        temp = finit + tau * z__[1] / (d__[1] * (d__[1] - tau)) + tau 
		        * z__[2] / (d__[2] * (d__[2] - tau)) + tau * z__[3] / (
		        d__[3] * (d__[3] - tau));
	        if (temp <= 0) {
		    lbd = tau;
	        } else {
		    ubd = tau;
	        }
	        if (abs(finit) <= abs(temp)) {
		    tau = 0;
	        }
	    }
        }

    /*     get machine parameters for possible scaling to avoid overflow */

    /*     modified by Sven: parameters SMALL1, SMINV1, SMALL2, */
    /*     SMINV2, EPS are not SAVEd anymore between one call to the */
    /*     others but recomputed at each call */

        eps = dlamch('E');
        _base = dlamch('B');
        i__1 = (int) (log(dlamch('S')) / log(_base) / 3);
        small1 = pow_di(_base, i__1);
        sminv1 = 1.0 / small1;
        small2 = small1 * small1;
        sminv2 = sminv1 * sminv1;

    /*     Determine if scaling of inputs necessary to avoid overflow */
    /*     when computing 1/TEMP**3 */

        if (orgati) {
    /* Computing MIN */
        d__1 = d__[2] - tau;
	    d__3 = abs(d__1);
        d__2 = d__[3] - tau;
        d__4 = abs(d__2);
	    temp = min(d__3,d__4);
        } else {
    /* Computing MIN */
        d__1 = d__[1] - tau;
	    d__3 = abs(d__1);
        d__2 = d__[2] - tau;
        d__4 = abs(d__2);
	    temp = min(d__3,d__4);
        }
        scale = false;
        if (temp <= small1) {
	    scale = true;
	    if (temp <= small2) {

    /*        Scale up by power of radix nearest 1/SAFMIN**(2/3) */

	        sclfac = sminv2;
	        sclinv = small2;
	    } else {

    /*        Scale up by power of radix nearest 1/SAFMIN**(1/3) */

	        sclfac = sminv1;
	        sclinv = small1;
	    }

    /*        Scaling up safe because D, Z, TAU scaled elsewhere to be O(1) */

	    for (i__ = 1; i__ <= 3; ++i__) {
	        dscale[i__ - 1] = d__[i__] * sclfac;
	        zscale[i__ - 1] = z__[i__] * sclfac;
    /* L10: */
	    }
	    tau *= sclfac;
	    lbd *= sclfac;
	    ubd *= sclfac;
        } else {

    /*        Copy D and Z to DSCALE and ZSCALE */

	    for (i__ = 1; i__ <= 3; ++i__) {
	        dscale[i__ - 1] = d__[i__];
	        zscale[i__ - 1] = z__[i__];
    /* L20: */
	    }
        }

        fc = 0;
        df = 0;
        ddf = 0;
        for (i__ = 1; i__ <= 3; ++i__) {
	    temp = 1.0 / (dscale[i__ - 1] - tau);
	    temp1 = zscale[i__ - 1] * temp;
	    temp2 = temp1 * temp;
	    temp3 = temp2 * temp;
	    fc += temp1 / dscale[i__ - 1];
	    df += temp2;
	    ddf += temp3;
    /* L30: */
        }
        f = finit + tau * fc;

        if (abs(f) <= 0) {
	    goto L60;
        }
        if (f <= 0) {
	    lbd = tau;
        } else {
	    ubd = tau;
        }

    /*        Iteration begins -- Use Gragg-Thornton-Warner cubic convergent */
    /*                            scheme */

    /*     It is not hard to see that */

    /*           1) Iterations will go up monotonically */
    /*              if FINIT < 0; */

    /*           2) Iterations will go down monotonically */
    /*              if FINIT > 0 */

        iter = niter + 1;

        for (niter = iter; niter <= 40; ++niter) {

	    if (orgati) {
	        temp1 = dscale[1] - tau;
	        temp2 = dscale[2] - tau;
	    } else {
	        temp1 = dscale[0] - tau;
	        temp2 = dscale[1] - tau;
	    }
	    a = (temp1 + temp2) * f - temp1 * temp2 * df;
	    b = temp1 * temp2 * f;
	    c__ = f - (temp1 + temp2) * df + temp1 * temp2 * ddf;
    /* Computing MAX */
	    d__1 = abs(a);
        d__2 = abs(b);
        d__1 = max(d__1,d__2);
        d__2 = abs(c__);
	    temp = max(d__1,d__2);
	    a /= temp;
	    b /= temp;
	    c__ /= temp;
	    if (c__ == 0) {
	        eta = b / a;
	    } else if (a <= 0) {
            d__1 = a * a - b * 4.0 * c__;
	        eta = (a - sqrt(( abs(d__1)))) / (c__ * 2);
	    } else {
            d__1 = a * a - b * 4.0 * c__;
	        eta = b * 2 / (a + sqrt(( abs(d__1))));
	    }
	    if (f * eta >= 0) {
	        eta = -f / df;
	    }

	    tau += eta;
	    if (tau < lbd || tau > ubd) {
	        tau = (lbd + ubd) / 2;
	    }

	    fc = 0;
	    erretm = 0;
	    df = 0;
	    ddf = 0;
	    for (i__ = 1; i__ <= 3; ++i__) {
	        temp = 1.0 / (dscale[i__ - 1] - tau);
	        temp1 = zscale[i__ - 1] * temp;
	        temp2 = temp1 * temp;
	        temp3 = temp2 * temp;
	        temp4 = temp1 / dscale[i__ - 1];
	        fc += temp4;
	        erretm += abs(temp4);
	        df += temp2;
	        ddf += temp3;
    /* L40: */
	    }
	    f = finit + tau * fc;
	    erretm = (abs(finit) + abs(tau) * erretm) * 8 + abs(tau) * df;
	    if (abs(f) <= eps * erretm) {
	        goto L60;
	    }
	    if (f <= 0) {
	        lbd = tau;
	    } else {
	        ubd = tau;
	    }
    /* L50: */
        }
        info = 1;
    L60:

    /*     Undo scaling */

        if (scale) {
	    tau *= sclinv;
        }
        return 0;
    } 
}

