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
    public static unsafe int dlasd4(int n, int i__, double* d__, double* z__, double* delta, double rho, ref double sigma, double* work, ref int info)
    {
        /* System generated locals */
        int i__1;
        double d__1;

        /* Local variables */
        double a, b, c__;
        int j;
        double* dd = stackalloc double[3], zz = stackalloc double[3];
        double w, dw;
        int ii, ip1;
        double eta, phi, eps, tau, psi;
        int iim1, iip1;
        double dphi, dpsi;
        int iter;
        double temp, prew, sg2lb, sg2ub, temp1, temp2, dtiim, delsq, dtiip;
        int niter;
        double dtisq;
        bool swtch;
        double dtnsq;
        double delsq2, dtnsq1;
        bool swtch3;
        bool orgati;
        double erretm, dtipsq, rhoinv;

        /* Parameter adjustments */
        --work;
        --delta;
        --z__;
        --d__;

        /* Function Body */
        info = 0;
        if (n == 1) {

    /*        Presumably, I=1 upon entry */

	    sigma = sqrt(d__[1] * d__[1] + rho * z__[1] * z__[1]);
	    delta[1] = 1.0;
	    work[1] = 1.0;
	    return 0;
        }
        if (n == 2) {
	    dlasd5(i__, &d__[1], &z__[1], &delta[1], rho, sigma, &work[1]);
	    return 0;
        }

    /*     Compute machine epsilon */

        eps = dlamch('E');
        rhoinv = 1.0 / rho;

    /*     The case I = N */

        if (i__ == n) {

    /*        Initialize some basic variables */

	    ii = n - 1;
	    niter = 1;

    /*        Calculate initial guess */

	    temp = rho / 2.0;

    /*        If ||Z||_2 is not one, then TEMP should be set to */
    /*        RHO * ||Z||_2^2 / TWO */

	    temp1 = temp / (d__[n] + sqrt(d__[n] * d__[n] + temp));
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        work[j] = d__[j] + d__[n] + temp1;
	        delta[j] = d__[j] - d__[n] - temp1;
    /* L10: */
	    }

	    psi = 0;
	    i__1 = n - 2;
	    for (j = 1; j <= i__1; ++j) {
	        psi += z__[j] * z__[j] / (delta[j] * work[j]);
    /* L20: */
	    }

	    c__ = rhoinv + psi;
	    w = c__ + z__[ii] * z__[ii] / (delta[ii] * work[ii]) + z__[n] * z__[n] / (delta[n] * work[n]);

	    if (w <= 0) {
	        temp1 = sqrt(d__[n] * d__[n] + rho);
	        temp = z__[n - 1] * z__[n - 1] / ((d__[n - 1] + temp1) * (d__[n] -
                d__[n - 1] + rho / (d__[n] + temp1))) + z__[n] * z__[n] / rho;

    /*           The following TAU is to approximate */
    /*           SIGMA_n^2 - D( N )*D( N ) */

	        if (c__ <= temp) {
		    tau = rho;
	        } else {
		    delsq = (d__[n] - d__[n - 1]) * (d__[n] + d__[n - 1]);
		    a = -c__ * delsq + z__[n - 1] * z__[n - 1] + z__[n] * z__[n];
		    b = z__[n] * z__[n] * delsq;
		    if (a < 0) {
		        tau = b * 2.0 / (sqrt(a * a + b * 4.0 * c__) - a);
		    } else {
		        tau = (a + sqrt(a * a + b * 4.0 * c__)) / (c__ * 2.0);
		    }
	        }

    /*           It can be proved that */
    /*               D(N)^2+RHO/2 <= SIGMA_n^2 < D(N)^2+TAU <= D(N)^2+RHO */

	    } else {
	        delsq = (d__[n] - d__[n - 1]) * (d__[n] + d__[n - 1]);
	        a = -c__ * delsq + z__[n - 1] * z__[n - 1] + z__[n] * z__[n];
	        b = z__[n] * z__[n] * delsq;

    /*           The following TAU is to approximate */
    /*           SIGMA_n^2 - D( N )*D( N ) */

	        if (a < 0) {
		    tau = b * 2.0 / (sqrt(a * a + b * 4.0 * c__) - a);
	        } else {
		    tau = (a + sqrt(a * a + b * 4.0 * c__)) / (c__ * 2.0);
	        }

    /*           It can be proved that */
    /*           D(N)^2 < D(N)^2+TAU < SIGMA(N)^2 < D(N)^2+RHO/2 */

	    }

    /*        The following ETA is to approximate SIGMA_n - D( N ) */

	    eta = tau / (d__[n] + sqrt(d__[n] * d__[n] + tau));

	    sigma = d__[n] + eta;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        delta[j] = d__[j] - d__[i__] - eta;
	        work[j] = d__[j] + d__[i__] + eta;
    /* L30: */
	    }

    /*        Evaluate PSI and the derivative DPSI */

	    dpsi = 0;
	    psi = 0;
	    erretm = 0;
	    i__1 = ii;
	    for (j = 1; j <= i__1; ++j) {
	        temp = z__[j] / (delta[j] * work[j]);
	        psi += z__[j] * temp;
	        dpsi += temp * temp;
	        erretm += psi;
    /* L40: */
	    }
	    erretm = abs(erretm);

    /*        Evaluate PHI and the derivative DPHI */

	    temp = z__[n] / (delta[n] * work[n]);
	    phi = z__[n] * temp;
	    dphi = temp * temp;
	    erretm = (-phi - psi) * 8.0 + erretm - phi + rhoinv + abs(tau) * (dpsi 
		    + dphi);

	    w = rhoinv + phi + psi;

    /*        Test for convergence */

	    if (abs(w) <= eps * erretm) {
	        goto L240;
	    }

    /*        Calculate the new step */

	    ++niter;
	    dtnsq1 = work[n - 1] * delta[n - 1];
	    dtnsq = work[n] * delta[n];
	    c__ = w - dtnsq1 * dpsi - dtnsq * dphi;
	    a = (dtnsq + dtnsq1) * w - dtnsq * dtnsq1 * (dpsi + dphi);
	    b = dtnsq * dtnsq1 * w;
	    if (c__ < 0) {
	        c__ = abs(c__);
	    }
	    if (c__ == 0) {
	        eta = rho - sigma * sigma;
	    } else if (a >= 0) {
	        eta = (a + sqrt((abs(a * a - b * 4.0 * c__)))) / (c__ 
		        * 2.0);
	    } else {
	        eta = b * 2.0 / (a - sqrt((abs(a * a - b * 4.0 * c__)))
		        );
	    }

    /*        Note, eta should be positive if w is negative, and */
    /*        eta should be negative otherwise. However, */
    /*        if for some reason caused by roundoff, eta*w > 0, */
    /*        we simply use one Newton step instead. This way */
    /*        will guarantee eta*w < 0 */

	    if (w * eta > 0) {
	        eta = -w / (dpsi + dphi);
	    }
	    temp = eta - dtnsq;
	    if (temp > rho) {
	        eta = rho + dtnsq;
	    }

	    tau += eta;
	    eta /= sigma + sqrt(eta + sigma * sigma);
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        delta[j] -= eta;
	        work[j] += eta;
    /* L50: */
	    }

	    sigma += eta;

    /*        Evaluate PSI and the derivative DPSI */

	    dpsi = 0;
	    psi = 0;
	    erretm = 0;
	    i__1 = ii;
	    for (j = 1; j <= i__1; ++j) {
	        temp = z__[j] / (work[j] * delta[j]);
	        psi += z__[j] * temp;
	        dpsi += temp * temp;
	        erretm += psi;
    /* L60: */
	    }
	    erretm = abs(erretm);

    /*        Evaluate PHI and the derivative DPHI */

	    temp = z__[n] / (work[n] * delta[n]);
	    phi = z__[n] * temp;
	    dphi = temp * temp;
	    erretm = (-phi - psi) * 8.0 + erretm - phi + rhoinv + abs(tau) * (dpsi 
		    + dphi);

	    w = rhoinv + phi + psi;

    /*        Main loop to update the values of the array   DELTA */

	    iter = niter + 1;

	    for (niter = iter; niter <= 20; ++niter) {

    /*           Test for convergence */

	        if (abs(w) <= eps * erretm) {
		    goto L240;
	        }

    /*           Calculate the new step */

	        dtnsq1 = work[n - 1] * delta[n - 1];
	        dtnsq = work[n] * delta[n];
	        c__ = w - dtnsq1 * dpsi - dtnsq * dphi;
	        a = (dtnsq + dtnsq1) * w - dtnsq1 * dtnsq * (dpsi + dphi);
	        b = dtnsq1 * dtnsq * w;
	        if (a >= 0) {
		    eta = (a + sqrt(( abs(a * a - b * 4.0 * c__)))) / (
			    c__ * 2.0);
	        } else {
		    eta = b * 2.0 / (a - sqrt((abs(a * a - b * 4.0 * c__))));
	        }

    /*           Note, eta should be positive if w is negative, and */
    /*           eta should be negative otherwise. However, */
    /*           if for some reason caused by roundoff, eta*w > 0, */
    /*           we simply use one Newton step instead. This way */
    /*           will guarantee eta*w < 0 */

	        if (w * eta > 0) {
		    eta = -w / (dpsi + dphi);
	        }
	        temp = eta - dtnsq;
	        if (temp <= 0) {
		    eta /= 2.0;
	        }

	        tau += eta;
	        eta /= sigma + sqrt(eta + sigma * sigma);
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    delta[j] -= eta;
		    work[j] += eta;
    /* L70: */
	        }

	        sigma += eta;

    /*           Evaluate PSI and the derivative DPSI */

	        dpsi = 0;
	        psi = 0;
	        erretm = 0;
	        i__1 = ii;
	        for (j = 1; j <= i__1; ++j) {
		    temp = z__[j] / (work[j] * delta[j]);
		    psi += z__[j] * temp;
		    dpsi += temp * temp;
		    erretm += psi;
    /* L80: */
	        }
	        erretm = abs(erretm);

    /*           Evaluate PHI and the derivative DPHI */

	        temp = z__[n] / (work[n] * delta[n]);
	        phi = z__[n] * temp;
	        dphi = temp * temp;
	        erretm = (-phi - psi) * 8.0 + erretm - phi + rhoinv + abs(tau) * (
		        dpsi + dphi);

	        w = rhoinv + phi + psi;
    /* L90: */
	    }

    /*        Return with INFO = 1, NITER = MAXIT and not converged */

	    info = 1;
	    goto L240;

    /*        End for the case I = N */

        } else {

    /*        The case for I < N */

	    niter = 1;
	    ip1 = i__ + 1;

    /*        Calculate initial guess */

	    delsq = (d__[ip1] - d__[i__]) * (d__[ip1] + d__[i__]);
	    delsq2 = delsq / 2.0;
	    temp = delsq2 / (d__[i__] + sqrt(d__[i__] * d__[i__] + delsq2));
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        work[j] = d__[j] + d__[i__] + temp;
	        delta[j] = d__[j] - d__[i__] - temp;
    /* L100: */
	    }

	    psi = 0;
	    i__1 = i__ - 1;
	    for (j = 1; j <= i__1; ++j) {
	        psi += z__[j] * z__[j] / (work[j] * delta[j]);
    /* L110: */
	    }

	    phi = 0;
	    i__1 = i__ + 2;
	    for (j = n; j >= i__1; --j) {
	        phi += z__[j] * z__[j] / (work[j] * delta[j]);
    /* L120: */
	    }
	    c__ = rhoinv + psi + phi;
	    w = c__ + z__[i__] * z__[i__] / (work[i__] * delta[i__]) + z__[
		    ip1] * z__[ip1] / (work[ip1] * delta[ip1]);

	    if (w > 0) {

    /*           d(i)^2 < the ith sigma^2 < (d(i)^2+d(i+1)^2)/2 */

    /*           We choose d(i) as origin. */

	        orgati = true;
	        sg2lb = 0;
	        sg2ub = delsq2;
	        a = c__ * delsq + z__[i__] * z__[i__] + z__[ip1] * z__[ip1];
	        b = z__[i__] * z__[i__] * delsq;
	        if (a > 0) {
		    tau = b * 2.0 / (a + sqrt(( abs(a * a - b * 4.0 * c__))));
	        } else {
		    tau = (a - sqrt((abs(a * a - b * 4.0 * c__)))) / (
			    c__ * 2.0);
	        }

    /*           TAU now is an estimation of SIGMA^2 - D( I )^2.0 The */
    /*           following, however, is the corresponding estimation of */
    /*           SIGMA - D( I ). */

	        eta = tau / (d__[i__] + sqrt(d__[i__] * d__[i__] + tau));
	    } else {

    /*           (d(i)^2+d(i+1)^2)/2 <= the ith sigma^2 < d(i+1)^2/2 */

    /*           We choose d(i+1) as origin. */

	        orgati = false;
	        sg2lb = -delsq2;
	        sg2ub = 0;
	        a = c__ * delsq - z__[i__] * z__[i__] - z__[ip1] * z__[ip1];
	        b = z__[ip1] * z__[ip1] * delsq;
	        if (a < 0) {
		    tau = b * 2.0 / (a - sqrt(( abs(a * a + b * 4.0 * c__))));
	        } else {
		    tau = -(a + sqrt((abs(a * a + b * 4.0 * c__)))) / 
			    (c__ * 2.0);
	        }

    /*           TAU now is an estimation of SIGMA^2 - D( IP1 )^2.0 The */
    /*           following, however, is the corresponding estimation of */
    /*           SIGMA - D( IP1 ). */

	        eta = tau / (d__[ip1] + sqrt((abs(d__[ip1] * d__[ip1] + tau))));
	    }

	    if (orgati) {
	        ii = i__;
	        sigma = d__[i__] + eta;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    work[j] = d__[j] + d__[i__] + eta;
		    delta[j] = d__[j] - d__[i__] - eta;
    /* L130: */
	        }
	    } else {
	        ii = i__ + 1;
	        sigma = d__[ip1] + eta;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    work[j] = d__[j] + d__[ip1] + eta;
		    delta[j] = d__[j] - d__[ip1] - eta;
    /* L140: */
	        }
	    }
	    iim1 = ii - 1;
	    iip1 = ii + 1;

    /*        Evaluate PSI and the derivative DPSI */

	    dpsi = 0;
	    psi = 0;
	    erretm = 0;
	    i__1 = iim1;
	    for (j = 1; j <= i__1; ++j) {
	        temp = z__[j] / (work[j] * delta[j]);
	        psi += z__[j] * temp;
	        dpsi += temp * temp;
	        erretm += psi;
    /* L150: */
	    }
	    erretm = abs(erretm);

    /*        Evaluate PHI and the derivative DPHI */

	    dphi = 0;
	    phi = 0;
	    i__1 = iip1;
	    for (j = n; j >= i__1; --j) {
	        temp = z__[j] / (work[j] * delta[j]);
	        phi += z__[j] * temp;
	        dphi += temp * temp;
	        erretm += phi;
    /* L160: */
	    }

	    w = rhoinv + phi + psi;

    /*        W is the value of the secular function with */
    /*        its ii-th element removed. */

	    swtch3 = false;
	    if (orgati) {
	        if (w < 0) {
		    swtch3 = true;
	        }
	    } else {
	        if (w > 0) {
		    swtch3 = true;
	        }
	    }
	    if (ii == 1 || ii == n) {
	        swtch3 = false;
	    }

	    temp = z__[ii] / (work[ii] * delta[ii]);
	    dw = dpsi + dphi + temp * temp;
	    temp = z__[ii] * temp;
	    w += temp;
	    erretm = (phi - psi) * 8.0 + erretm + rhoinv * 2.0 + abs(temp) * 3.0 + 
		    abs(tau) * dw;

    /*        Test for convergence */

	    if (abs(w) <= eps * erretm) {
	        goto L240;
	    }

	    if (w <= 0) {
	        sg2lb = max(sg2lb,tau);
	    } else {
	        sg2ub = min(sg2ub,tau);
	    }

    /*        Calculate the new step */

	    ++niter;
	    if (! swtch3) {
	        dtipsq = work[ip1] * delta[ip1];
	        dtisq = work[i__] * delta[i__];
	        if (orgati) {
    /* Computing 2nd power */
		    d__1 = z__[i__] / dtisq;
		    c__ = w - dtipsq * dw + delsq * (d__1 * d__1);
	        } else {
    /* Computing 2nd power */
		    d__1 = z__[ip1] / dtipsq;
		    c__ = w - dtisq * dw - delsq * (d__1 * d__1);
	        }
	        a = (dtipsq + dtisq) * w - dtipsq * dtisq * dw;
	        b = dtipsq * dtisq * w;
	        if (c__ == 0) {
		    if (a == 0) {
		        if (orgati) {
			    a = z__[i__] * z__[i__] + dtipsq * dtipsq * (dpsi + 
				    dphi);
		        } else {
			    a = z__[ip1] * z__[ip1] + dtisq * dtisq * (dpsi + 
				    dphi);
		        }
		    }
		    eta = b / a;
	        } else if (a <= 0) {
		    eta = (a - sqrt((abs(a * a - b * 4.0 * c__)))) / (c__ * 2.0);
	        } else {
		    eta = b * 2.0 / (a + sqrt((abs( a * a - b * 4.0 * c__))));
	        }
	    } else {

    /*           Interpolation using THREE most relevant poles */

	        dtiim = work[iim1] * delta[iim1];
	        dtiip = work[iip1] * delta[iip1];
	        temp = rhoinv + psi + phi;
	        if (orgati) {
		    temp1 = z__[iim1] / dtiim;
		    temp1 *= temp1;
		    c__ = temp - dtiip * (dpsi + dphi) - (d__[iim1] - d__[iip1]) *
			     (d__[iim1] + d__[iip1]) * temp1;
		    zz[0] = z__[iim1] * z__[iim1];
		    if (dpsi < temp1) {
		        zz[2] = dtiip * dtiip * dphi;
		    } else {
		        zz[2] = dtiip * dtiip * (dpsi - temp1 + dphi);
		    }
	        } else {
		    temp1 = z__[iip1] / dtiip;
		    temp1 *= temp1;
		    c__ = temp - dtiim * (dpsi + dphi) - (d__[iip1] - d__[iim1]) *
			     (d__[iim1] + d__[iip1]) * temp1;
		    if (dphi < temp1) {
		        zz[0] = dtiim * dtiim * dpsi;
		    } else {
		        zz[0] = dtiim * dtiim * (dpsi + (dphi - temp1));
		    }
		    zz[2] = z__[iip1] * z__[iip1];
	        }
	        zz[1] = z__[ii] * z__[ii];
	        dd[0] = dtiim;
	        dd[1] = delta[ii] * work[ii];
	        dd[2] = dtiip;
	        dlaed6(niter, orgati, c__, dd, zz, w, ref eta, ref info);
	        if (info != 0) {
		    goto L240;
	        }
	    }

    /*        Note, eta should be positive if w is negative, and */
    /*        eta should be negative otherwise. However, */
    /*        if for some reason caused by roundoff, eta*w > 0, */
    /*        we simply use one Newton step instead. This way */
    /*        will guarantee eta*w < 0 */

	    if (w * eta >= 0) {
	        eta = -w / dw;
	    }
	    if (orgati) {
	        temp1 = work[i__] * delta[i__];
	        temp = eta - temp1;
	    } else {
	        temp1 = work[ip1] * delta[ip1];
	        temp = eta - temp1;
	    }
	    if (temp > sg2ub || temp < sg2lb) {
	        if (w < 0) {
		    eta = (sg2ub - tau) / 2.0;
	        } else {
		    eta = (sg2lb - tau) / 2.0;
	        }
	    }

	    tau += eta;
	    eta /= sigma + sqrt(sigma * sigma + eta);

	    prew = w;

	    sigma += eta;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        work[j] += eta;
	        delta[j] -= eta;
    /* L170: */
	    }

    /*        Evaluate PSI and the derivative DPSI */

	    dpsi = 0;
	    psi = 0;
	    erretm = 0;
	    i__1 = iim1;
	    for (j = 1; j <= i__1; ++j) {
	        temp = z__[j] / (work[j] * delta[j]);
	        psi += z__[j] * temp;
	        dpsi += temp * temp;
	        erretm += psi;
    /* L180: */
	    }
	    erretm = abs(erretm);

    /*        Evaluate PHI and the derivative DPHI */

	    dphi = 0;
	    phi = 0;
	    i__1 = iip1;
	    for (j = n; j >= i__1; --j) {
	        temp = z__[j] / (work[j] * delta[j]);
	        phi += z__[j] * temp;
	        dphi += temp * temp;
	        erretm += phi;
    /* L190: */
	    }

	    temp = z__[ii] / (work[ii] * delta[ii]);
	    dw = dpsi + dphi + temp * temp;
	    temp = z__[ii] * temp;
	    w = rhoinv + phi + psi + temp;
	    erretm = (phi - psi) * 8.0 + erretm + rhoinv * 2.0 + abs(temp) * 3.0 + 
		    abs(tau) * dw;

	    if (w <= 0) {
	        sg2lb = max(sg2lb,tau);
	    } else {
	        sg2ub = min(sg2ub,tau);
	    }

	    swtch = false;
	    if (orgati) {
	        if (-w > abs(prew) / 10.0) {
		    swtch = true;
	        }
	    } else {
	        if (w > abs(prew) / 10.0) {
		    swtch = true;
	        }
	    }

    /*        Main loop to update the values of the array   DELTA and WORK */

	    iter = niter + 1;

	    for (niter = iter; niter <= 20; ++niter) {

    /*           Test for convergence */

	        if (abs(w) <= eps * erretm) {
		    goto L240;
	        }

    /*           Calculate the new step */

	        if (! swtch3) {
		    dtipsq = work[ip1] * delta[ip1];
		    dtisq = work[i__] * delta[i__];
		    if (! swtch) {
		        if (orgati) {
    /* Computing 2nd power */
			    d__1 = z__[i__] / dtisq;
			    c__ = w - dtipsq * dw + delsq * (d__1 * d__1);
		        } else {
    /* Computing 2nd power */
			    d__1 = z__[ip1] / dtipsq;
			    c__ = w - dtisq * dw - delsq * (d__1 * d__1);
		        }
		    } else {
		        temp = z__[ii] / (work[ii] * delta[ii]);
		        if (orgati) {
			    dpsi += temp * temp;
		        } else {
			    dphi += temp * temp;
		        }
		        c__ = w - dtisq * dpsi - dtipsq * dphi;
		    }
		    a = (dtipsq + dtisq) * w - dtipsq * dtisq * dw;
		    b = dtipsq * dtisq * w;
		    if (c__ == 0) {
		        if (a == 0) {
			    if (! swtch) {
			        if (orgati) {
				    a = z__[i__] * z__[i__] + dtipsq * dtipsq * 
					    (dpsi + dphi);
			        } else {
				    a = z__[ip1] * z__[ip1] + dtisq * dtisq * (
					    dpsi + dphi);
			        }
			    } else {
			        a = dtisq * dtisq * dpsi + dtipsq * dtipsq * dphi;
			    }
		        }
		        eta = b / a;
		    } else if (a <= 0) {
		        eta = (a - sqrt((abs(a * a - b * 4.0 * c__)))) / (c__ * 2.0);
		    } else {
		        eta = b * 2.0 / (a + sqrt((abs(a * a - b * 4.0 * c__))));
		    }
	        } else {

    /*              Interpolation using THREE most relevant poles */

		    dtiim = work[iim1] * delta[iim1];
		    dtiip = work[iip1] * delta[iip1];
		    temp = rhoinv + psi + phi;
		    if (swtch) {
		        c__ = temp - dtiim * dpsi - dtiip * dphi;
		        zz[0] = dtiim * dtiim * dpsi;
		        zz[2] = dtiip * dtiip * dphi;
		    } else {
		        if (orgati) {
			    temp1 = z__[iim1] / dtiim;
			    temp1 *= temp1;
			    temp2 = (d__[iim1] - d__[iip1]) * (d__[iim1] + d__[
				    iip1]) * temp1;
			    c__ = temp - dtiip * (dpsi + dphi) - temp2;
			    zz[0] = z__[iim1] * z__[iim1];
			    if (dpsi < temp1) {
			        zz[2] = dtiip * dtiip * dphi;
			    } else {
			        zz[2] = dtiip * dtiip * (dpsi - temp1 + dphi);
			    }
		        } else {
			    temp1 = z__[iip1] / dtiip;
			    temp1 *= temp1;
			    temp2 = (d__[iip1] - d__[iim1]) * (d__[iim1] + d__[
				    iip1]) * temp1;
			    c__ = temp - dtiim * (dpsi + dphi) - temp2;
			    if (dphi < temp1) {
			        zz[0] = dtiim * dtiim * dpsi;
			    } else {
			        zz[0] = dtiim * dtiim * (dpsi + (dphi - temp1));
			    }
			    zz[2] = z__[iip1] * z__[iip1];
		        }
		    }
		    dd[0] = dtiim;
		    dd[1] = delta[ii] * work[ii];
		    dd[2] = dtiip;
		    dlaed6(niter, orgati, c__, dd, zz, w, ref eta, ref info);
		    if (info != 0) {
		        goto L240;
		    }
	        }

    /*           Note, eta should be positive if w is negative, and */
    /*           eta should be negative otherwise. However, */
    /*           if for some reason caused by roundoff, eta*w > 0, */
    /*           we simply use one Newton step instead. This way */
    /*           will guarantee eta*w < 0 */

	        if (w * eta >= 0) {
		    eta = -w / dw;
	        }
	        if (orgati) {
		    temp1 = work[i__] * delta[i__];
		    temp = eta - temp1;
	        } else {
		    temp1 = work[ip1] * delta[ip1];
		    temp = eta - temp1;
	        }
	        if (temp > sg2ub || temp < sg2lb) {
		    if (w < 0) {
		        eta = (sg2ub - tau) / 2.0;
		    } else {
		        eta = (sg2lb - tau) / 2.0;
		    }
	        }

	        tau += eta;
	        eta /= sigma + sqrt(sigma * sigma + eta);

	        sigma += eta;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    work[j] += eta;
		    delta[j] -= eta;
    /* L200: */
	        }

	        prew = w;

    /*           Evaluate PSI and the derivative DPSI */

	        dpsi = 0;
	        psi = 0;
	        erretm = 0;
	        i__1 = iim1;
	        for (j = 1; j <= i__1; ++j) {
		    temp = z__[j] / (work[j] * delta[j]);
		    psi += z__[j] * temp;
		    dpsi += temp * temp;
		    erretm += psi;
    /* L210: */
	        }
	        erretm = abs(erretm);

    /*           Evaluate PHI and the derivative DPHI */

	        dphi = 0;
	        phi = 0;
	        i__1 = iip1;
	        for (j = n; j >= i__1; --j) {
		    temp = z__[j] / (work[j] * delta[j]);
		    phi += z__[j] * temp;
		    dphi += temp * temp;
		    erretm += phi;
    /* L220: */
	        }

	        temp = z__[ii] / (work[ii] * delta[ii]);
	        dw = dpsi + dphi + temp * temp;
	        temp = z__[ii] * temp;
	        w = rhoinv + phi + psi + temp;
	        erretm = (phi - psi) * 8.0 + erretm + rhoinv * 2.0 + abs(temp) * 3.0 
		        + abs(tau) * dw;
	        if (w * prew > 0 && abs(w) > abs(prew) / 10.0) {
		    swtch = ! swtch;
	        }

	        if (w <= 0) {
		    sg2lb = max(sg2lb,tau);
	        } else {
		    sg2ub = min(sg2ub,tau);
	        }

    /* L230: */
	    }

    /*        Return with INFO = 1, NITER = MAXIT and not converged */

	    info = 1;

        }

    L240:
        return 0;
    } 
}

