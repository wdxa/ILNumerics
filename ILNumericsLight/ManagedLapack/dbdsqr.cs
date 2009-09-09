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
    public static unsafe int dbdsqr(char uplo, int n, int ncvt, int nru, int ncc, double* d__, double* e,
        double* vt, int ldvt, double* u, int ldu, double* c__, int ldc, double* work, ref int info)
    {
        /* Table of constant values */
        const double c_b15 = -.125;
        const int c__1 = 1;
        const double c_b49 = 1.00;
        const double c_b72 = -1.00;

        /* System generated locals */
        int c_dim1, c_offset, u_dim1, u_offset, vt_dim1, vt_offset, i__1, 
	        i__2;
        double d__1, d__2, d__3, d__4;

        /* Local variables */
        double f, g, h__;
        int i__, j, m;
        double r__=0, cs=0;
        int ll;
        double sn=0, mu;
        int nm1, nm12, nm13, lll;
        double eps, sll, tol, abse;
        int idir;
        double abss;
        int oldm;
        double cosl=0;
        int isub, iter;
        double unfl, sinl=0, cosr=0, smin, smax, sinr=0;
        double oldcs;
        int oldll;
        double shift=0, sigmn=0, oldsn=0;
        int maxit;
        double sminl, sigmx=0;
        bool lower;
        double sminoa, thresh;
        bool rotate;
        double tolmul;

        /* Parameter adjustments */
        --d__;
        --e;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        --work;

        /* Function Body */
        info = 0;
        lower = lsame(uplo, 'L');
        if (! lsame(uplo, 'U') && ! lower) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (ncvt < 0) {
	    info = -3;
        } else if (nru < 0) {
	    info = -4;
        } else if (ncc < 0) {
	    info = -5;
        } else if (ncvt == 0 && ldvt < 1 || ncvt > 0 && ldvt < max(1,n)) {
	    info = -9;
        } else if (ldu < max(1,nru)) {
	    info = -11;
        } else if (ncc == 0 && ldc < 1 || ncc > 0 && ldc < max(1,n)) {
	    info = -13;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DBDSQR", i__1);
	    return 0;
        }
        if (n == 0) {
	    return 0;
        }
        if (n == 1) {
	    goto L160;
        }

    /*     ROTATE is true if any singular vectors desired, false otherwise */

        rotate = ncvt > 0 || nru > 0 || ncc > 0;

    /*     If no singular vectors desired, use qd algorithm */

        if (! rotate) {
	    dlasq1(n, &d__[1], &e[1], &work[1], ref info);
	    return 0;
        }

        nm1 = n - 1;
        nm12 = nm1 + nm1;
        nm13 = nm12 + nm1;
        idir = 0;

    /*     Get machine constants */

        eps = dlamch('E');
        unfl = dlamch('S');

    /*     If matrix lower bidiagonal, rotate to be upper bidiagonal */
    /*     by applying Givens rotations on the left */

        if (lower) {
	    i__1 = n - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        dlartg(d__[i__], e[i__], ref cs, ref sn, ref r__);
	        d__[i__] = r__;
	        e[i__] = sn * d__[i__ + 1];
	        d__[i__ + 1] = cs * d__[i__ + 1];
	        work[i__] = cs;
	        work[nm1 + i__] = sn;
    /* L10: */
	    }

    /*        Update singular vectors if desired */

	    if (nru > 0) {
	        dlasr('R', 'V', 'F', nru, n, &work[1], &work[n], &u[u_offset], 
		        ldu);
	    }
	    if (ncc > 0) {
	        dlasr('L', 'V', 'F', n, ncc, &work[1], &work[n], &c__[c_offset], 
		         ldc);
	    }
        }

    /*     Compute singular values to relative accuracy TOL */
    /*     (By setting TOL to be negative, algorithm will compute */
    /*     singular values to absolute accuracy ABS(TOL)*norm(input matrix)) */

    /* Computing MAX */
    /* Computing MIN */
        d__3 = 100.0;
        d__4 = pow_dd(eps, c_b15);
        d__1 = 10.0;
        d__2 = min(d__3,d__4);
        tolmul = max(d__1,d__2);
        tol = tolmul * eps;

    /*     Compute approximate maximum, minimum singular values */

        smax = 0.0;
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing MAX */
	    d__2 = smax;
        d__1 = d__[i__];
        d__3 = ( abs(d__1));
	    smax = max(d__2,d__3);
    /* L20: */
        }
        i__1 = n - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing MAX */
	    d__2 = smax;
            d__1 = e[i__];
            d__3 = ( abs(d__1));
	    smax = max(d__2,d__3);
    /* L30: */
        }
        sminl = 0.0;
        if (tol >= 0.0) {

    /*        Relative accuracy desired */

	    sminoa = abs(d__[1]);
	    if (sminoa == 0.0) {
	        goto L50;
	    }
	    mu = sminoa;
	    i__1 = n;
	    for (i__ = 2; i__ <= i__1; ++i__) {
            d__2 = d__[i__];
            d__1 = e[i__ - 1];
	        mu = (abs(d__2)) * (mu / (mu + (abs(d__1))));
	        sminoa = min(sminoa,mu);
	        if (sminoa == 0.0) {
		    goto L50;
	        }
    /* L40: */
	    }
    L50:
	    sminoa /= sqrt((double) (n));
    /* Computing MAX */
	    d__1 = tol * sminoa;
            d__2 = n * 6 * n * unfl;
	    thresh = max(d__1,d__2);
        } else {

    /*        Absolute accuracy desired */

    /* Computing MAX */
	    d__1 = abs(tol) * smax;
            d__2 = n * 6 * n * unfl;
	    thresh = max(d__1,d__2);
        }

    /*     Prepare for main iteration loop for the singular values */
    /*     (MAXIT is the maximum number of passes through the inner */
    /*     loop permitted before nonconvergence signalled.) */

        maxit = n * 6 * n;
        iter = 0;
        oldll = -1;
        oldm = -1;

    /*     M points to last element of unconverged part of matrix */

        m = n;

    /*     Begin main iteration loop */

    L60:

    /*     Check for convergence or exceeding iteration count */

        if (m <= 1) {
	    goto L160;
        }
        if (iter > maxit) {
	    goto L200;
        }

    /*     Find diagonal block of matrix to work on */

        d__1 = d__[m];
        if (tol < 0.0 && (abs(d__1)) <= thresh) {
	    d__[m] = 0.0;
        }
        d__1 = d__[m];
        smax = (abs(d__1));
        smin = smax;
        i__1 = m - 1;
        for (lll = 1; lll <= i__1; ++lll) {
	    ll = m - lll;
            d__1 = d__[ll];
	    abss = (abs(d__1));
            d__1 = e[ll];
	    abse = (abs(d__1));
	    if (tol < 0.0 && abss <= thresh) {
	        d__[ll] = 0.0;
	    }
	    if (abse <= thresh) {
	        goto L80;
	    }
	    smin = min(smin,abss);
    /* Computing MAX */
	    d__1 = max(smax,abss);
	    smax = max(d__1,abse);
    /* L70: */
        }
        ll = 0;
        goto L90;
    L80:
        e[ll] = 0.0;

    /*     Matrix splits since E(LL) = 0 */

        if (ll == m - 1) {

    /*        Convergence of bottom singular value, return to top of loop */

	    --m;
	    goto L60;
        }
    L90:
        ++ll;

    /*     E(LL) through E(M-1) are nonzero, E(LL-1) is zero */

        if (ll == m - 1) {

    /*        2 by 2 block, handle separately */

	    dlasv2(d__[m - 1], e[m - 1], d__[m], ref sigmn, ref sigmx, ref sinr, ref cosr, 
		     ref sinl, ref cosl);
	    d__[m - 1] = sigmx;
	    e[m - 1] = 0.0;
	    d__[m] = sigmn;

    /*        Compute singular vectors, if desired */

	    if (ncvt > 0) {
	        drot(ncvt, &vt[m - 1 + vt_dim1], ldvt, &vt[m + vt_dim1], ldvt, cosr, sinr);
	    }
	    if (nru > 0) {
	        drot(nru, &u[(m - 1) * u_dim1 + 1], c__1, &u[m * u_dim1 + 1], c__1, cosl, sinl);
	    }
	    if (ncc > 0) {
	        drot(ncc, &c__[m - 1 + c_dim1], ldc, &c__[m + c_dim1], ldc, cosl, sinl);
	    }
	    m += -2;
	    goto L60;
        }

    /*     If working on new submatrix, choose shift direction */
    /*     (from larger end diagonal element towards smaller) */

        if (ll > oldm || m < oldll) {
            d__1 = d__[ll];
	    if ((abs(d__1)) >= (abs(d__[m]))) {

    /*           Chase bulge from top (big end) to bottom (small end) */

	        idir = 1;
	    } else {

    /*           Chase bulge from bottom (big end) to top (small end) */

	        idir = 2;
	    }
        }

    /*     Apply convergence tests */

        if (idir == 1) {

    /*        Run convergence test in forward direction */
    /*        First apply standard test to bottom of matrix */

	    if ((abs(e[m - 1])) <= abs(tol) * abs(d__[m]) || tol < 0.0 && abs(e[m - 1]) <= thresh) 
		    {
	        e[m - 1] = 0.0;
	        goto L60;
	    }

	    if (tol >= 0.0) {

    /*           If relative accuracy desired, */
    /*           apply convergence criterion forward */

            d__1 = d__[ll];
	        mu = ( abs(d__1));
	        sminl = mu;
	        i__1 = m - 1;
	        for (lll = ll; lll <= i__1; ++lll) {
                d__1 = e[lll];
		    if ((abs(d__1)) <= tol * mu) {
		        e[lll] = 0.0;
		        goto L60;
		    }
            d__2 = d__[lll + 1];
		    mu = (abs(d__2)) * (mu / (mu + abs(e[lll])));
		    sminl = min(sminl,mu);
    /* L100: */
	        }
	    }

        } else {

    /*        Run convergence test in backward direction */
    /*        First apply standard test to top of matrix */

	    if ((abs(e[ll])) <= abs(tol) * abs(d__[ll]) || tol < 0.0 && (abs(e[ll])) <= thresh) {
	        e[ll] = 0.0;
	        goto L60;
	    }

	    if (tol >= 0.0) {

    /*           If relative accuracy desired, */
    /*           apply convergence criterion backward */

	        mu = abs(d__[m]);
	        sminl = mu;
	        i__1 = ll;
	        for (lll = m - 1; lll >= i__1; --lll) {
		    if (abs(e[lll]) <= tol * mu) {
		        e[lll] = 0.0;
		        goto L60;
		    }
		    mu = abs(d__[lll]) * (mu / (mu + abs(e[lll])));
		    sminl = min(sminl,mu);
    /* L110: */
	        }
	    }
        }
        oldll = ll;
        oldm = m;

    /*     Compute shift.  First, test if shifting would ruin relative */
    /*     accuracy, and if so set the shift to zero. */

    /* Computing MAX */
        d__1 = eps;
        d__2 = tol * .01;
        if (tol >= 0.0 && n * tol * (sminl / smax) <= max(d__1,d__2)) {

    /*        Use a zero shift to avoid loss of relative accuracy */

	    shift = 0.0;
        } else {

    /*        Compute the shift from 2-by-2 block at end of matrix */

	    if (idir == 1) {
            d__1 = d__[ll];
	        sll = (abs(d__1));
	        dlas2(d__[m - 1], e[m - 1], d__[m], ref shift, ref r__);
	    } else {
            d__1 = d__[m];
	        sll = (abs(d__1));
	        dlas2(d__[ll], e[ll], d__[ll + 1], ref shift, ref r__);
	    }

    /*        Test if shift negligible, and if so set to zero */

	    if (sll > 0.0) {
    /* Computing 2nd power */
	        d__1 = shift / sll;
	        if (d__1 * d__1 < eps) {
		    shift = 0.0;
	        }
	    }
        }

    /*     Increment iteration count */

        iter = iter + m - ll;

    /*     If SHIFT = 0, do simplified QR iteration */

        if (shift == 0.0) {
	    if (idir == 1) {

    /*           Chase bulge from top to bottom */
    /*           Save cosines and sines for later singular vector updates */

	        cs = 1.0;
	        oldcs = 1.0;
	        i__1 = m - 1;
	        for (i__ = ll; i__ <= i__1; ++i__) {
		    d__1 = d__[i__] * cs;
		    dlartg(d__1, e[i__], ref cs, ref sn, ref r__);
		    if (i__ > ll) {
		        e[i__ - 1] = oldsn * r__;
		    }
		    d__1 = oldcs * r__;
		    d__2 = d__[i__ + 1] * sn;
		    dlartg(d__1, d__2, ref oldcs, ref oldsn, ref d__[i__]);
		    work[i__ - ll + 1] = cs;
		    work[i__ - ll + 1 + nm1] = sn;
		    work[i__ - ll + 1 + nm12] = oldcs;
		    work[i__ - ll + 1 + nm13] = oldsn;
    /* L120: */
	        }
	        h__ = d__[m] * cs;
	        d__[m] = h__ * oldcs;
	        e[m - 1] = h__ * oldsn;

    /*           Update singular vectors */

	        if (ncvt > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'F', i__1, ncvt, &work[1], &work[n], &vt[
			    ll + vt_dim1], ldvt);
	        }
	        if (nru > 0) {
		    i__1 = m - ll + 1;
		    dlasr('R', 'V', 'F', nru, i__1, &work[nm12 + 1], &work[nm13 
			    + 1], &u[ll * u_dim1 + 1], ldu);
	        }
	        if (ncc > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'F', i__1, ncc, &work[nm12 + 1], &work[nm13 
			    + 1], &c__[ll + c_dim1], ldc);
	        }

    /*           Test convergence */

	        if (abs(e[m - 1]) <= thresh) {
		    e[m - 1] = 0.0;
	        }

	    } else {

    /*           Chase bulge from bottom to top */
    /*           Save cosines and sines for later singular vector updates */

	        cs = 1.0;
	        oldcs = 1.0;
	        i__1 = ll + 1;
	        for (i__ = m; i__ >= i__1; --i__) {
		    d__1 = d__[i__] * cs;
		    dlartg(d__1, e[i__ - 1], ref cs, ref sn, ref r__);
		    if (i__ < m) {
		        e[i__] = oldsn * r__;
		    }
		    d__1 = oldcs * r__;
		    d__2 = d__[i__ - 1] * sn;
		    dlartg(d__1, d__2, ref oldcs, ref oldsn, ref d__[i__]);
		    work[i__ - ll] = cs;
		    work[i__ - ll + nm1] = -sn;
		    work[i__ - ll + nm12] = oldcs;
		    work[i__ - ll + nm13] = -oldsn;
    /* L130: */
	        }
	        h__ = d__[ll] * cs;
	        d__[ll] = h__ * oldcs;
	        e[ll] = h__ * oldsn;

    /*           Update singular vectors */

	        if (ncvt > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'B', i__1, ncvt, &work[nm12 + 1], &work[
			    nm13 + 1], &vt[ll + vt_dim1], ldvt);
	        }
	        if (nru > 0) {
		    i__1 = m - ll + 1;
		    dlasr('R', 'V', 'B', nru, i__1, &work[1], &work[n], &u[ll *
			     u_dim1 + 1], ldu);
	        }
	        if (ncc > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'B', i__1, ncc, &work[1], &work[n], &c__[
			    ll + c_dim1], ldc);
	        }

    /*           Test convergence */

	        if (abs(e[ll]) <= thresh) {
		    e[ll] = 0.0;
	        }
	    }
        } else {

    /*        Use nonzero shift */

	    if (idir == 1) {

    /*           Chase bulge from top to bottom */
    /*           Save cosines and sines for later singular vector updates */

            d__1 = d__[ll];
	        f = ((abs(d__1)) - shift) * (d_sign(c_b49, d__[ll]) + shift / d__[ll]);
	        g = e[ll];
	        i__1 = m - 1;
	        for (i__ = ll; i__ <= i__1; ++i__) {
		    dlartg(f, g, ref cosr, ref sinr, ref r__);
		    if (i__ > ll) {
		        e[i__ - 1] = r__;
		    }
		    f = cosr * d__[i__] + sinr * e[i__];
		    e[i__] = cosr * e[i__] - sinr * d__[i__];
		    g = sinr * d__[i__ + 1];
		    d__[i__ + 1] = cosr * d__[i__ + 1];
		    dlartg(f, g, ref cosl, ref sinl, ref r__);
		    d__[i__] = r__;
		    f = cosl * e[i__] + sinl * d__[i__ + 1];
		    d__[i__ + 1] = cosl * d__[i__ + 1] - sinl * e[i__];
		    if (i__ < m - 1) {
		        g = sinl * e[i__ + 1];
		        e[i__ + 1] = cosl * e[i__ + 1];
		    }
		    work[i__ - ll + 1] = cosr;
		    work[i__ - ll + 1 + nm1] = sinr;
		    work[i__ - ll + 1 + nm12] = cosl;
		    work[i__ - ll + 1 + nm13] = sinl;
    /* L140: */
	        }
	        e[m - 1] = f;

    /*           Update singular vectors */

	        if (ncvt > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'F', i__1, ncvt, &work[1], &work[n], &vt[
			    ll + vt_dim1], ldvt);
	        }
	        if (nru > 0) {
		    i__1 = m - ll + 1;
		    dlasr('R', 'V', 'F', nru, i__1, &work[nm12 + 1], &work[nm13 
			    + 1], &u[ll * u_dim1 + 1], ldu);
	        }
	        if (ncc > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'F', i__1, ncc, &work[nm12 + 1], &work[nm13 
			    + 1], &c__[ll + c_dim1], ldc);
	        }

    /*           Test convergence */

	        if (abs(e[m - 1]) <= thresh) {
		    e[m - 1] = 0.0;
	        }

	    } else {

    /*           Chase bulge from bottom to top */
    /*           Save cosines and sines for later singular vector updates */

	        f = ((abs(d__[m])) - shift) * (d_sign(c_b49, d__[m]) + shift / d__[m]);
	        g = e[m - 1];
	        i__1 = ll + 1;
	        for (i__ = m; i__ >= i__1; --i__) {
		    dlartg(f, g, ref cosr, ref sinr, ref r__);
		    if (i__ < m) {
		        e[i__] = r__;
		    }
		    f = cosr * d__[i__] + sinr * e[i__ - 1];
		    e[i__ - 1] = cosr * e[i__ - 1] - sinr * d__[i__];
		    g = sinr * d__[i__ - 1];
		    d__[i__ - 1] = cosr * d__[i__ - 1];
		    dlartg(f, g, ref cosl, ref sinl, ref r__);
		    d__[i__] = r__;
		    f = cosl * e[i__ - 1] + sinl * d__[i__ - 1];
		    d__[i__ - 1] = cosl * d__[i__ - 1] - sinl * e[i__ - 1];
		    if (i__ > ll + 1) {
		        g = sinl * e[i__ - 2];
		        e[i__ - 2] = cosl * e[i__ - 2];
		    }
		    work[i__ - ll] = cosr;
		    work[i__ - ll + nm1] = -sinr;
		    work[i__ - ll + nm12] = cosl;
		    work[i__ - ll + nm13] = -sinl;
    /* L150: */
	        }
	        e[ll] = f;

    /*           Test convergence */

	        if ((abs(e[ll])) <= thresh) {
		    e[ll] = 0.0;
	        }

    /*           Update singular vectors if desired */

	        if (ncvt > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'B', i__1, ncvt, &work[nm12 + 1], &work[
			    nm13 + 1], &vt[ll + vt_dim1], ldvt);
	        }
	        if (nru > 0) {
		    i__1 = m - ll + 1;
		    dlasr('R', 'V', 'B', nru, i__1, &work[1], &work[n], &u[ll *
			     u_dim1 + 1], ldu);
	        }
	        if (ncc > 0) {
		    i__1 = m - ll + 1;
		    dlasr('L', 'V', 'B', i__1, ncc, &work[1], &work[n], &c__[
			    ll + c_dim1], ldc);
	        }
	    }
        }

    /*     QR iteration finished, go back and check convergence */

        goto L60;

    /*     All singular values converged, so make them positive */

    L160:
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if (d__[i__] < 0.0) {
	        d__[i__] = -d__[i__];

    /*           Change sign of singular vectors, if desired */

	        if (ncvt > 0) {
		    dscal(ncvt, c_b72, &vt[i__ + vt_dim1], ldvt);
	        }
	    }
    /* L170: */
        }

    /*     Sort the singular values into decreasing order (insertion sort on */
    /*     singular values, but only one transposition per singular vector) */

        i__1 = n - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {

    /*        Scan for smallest D(I) */

	    isub = 1;
	    smin = d__[1];
	    i__2 = n + 1 - i__;
	    for (j = 2; j <= i__2; ++j) {
	        if (d__[j] <= smin) {
		    isub = j;
		    smin = d__[j];
	        }
    /* L180: */
	    }
	    if (isub != n + 1 - i__) {

    /*           Swap singular values and vectors */

	        d__[isub] = d__[n + 1 - i__];
	        d__[n + 1 - i__] = smin;
	        if (ncvt > 0) {
		    dswap(ncvt, &vt[isub + vt_dim1], ldvt, &vt[n + 1 - i__ + 
			    vt_dim1], ldvt);
	        }
	        if (nru > 0) {
		    dswap(nru, &u[isub * u_dim1 + 1], c__1, &u[(n + 1 - i__) * 
			    u_dim1 + 1], c__1);
	        }
	        if (ncc > 0) {
		    dswap(ncc, &c__[isub + c_dim1], ldc, &c__[n + 1 - i__ + 
			    c_dim1], ldc);
	        }
	    }
    /* L190: */
        }
        goto L220;

    /*     Maximum number of iterations exceeded, failure to converge */

    L200:
        info = 0;
        i__1 = n - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if (e[i__] != 0.0) {
	        ++(info);
	    }
    /* L210: */
        }
    L220:
        return 0;
    } 
}

