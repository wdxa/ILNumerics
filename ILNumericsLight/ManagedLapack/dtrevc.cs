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
    public static unsafe int dtrevc(char side, char howmny, bool *select, int n, double *t, int ldt,
        double *vl, int ldvl, double *vr, int ldvr, int mm, ref int m, double *work, ref int info)
    {
        /* Table of constant values */
        const bool c_false = false;
        const int c__1 = 1;
        const double c_b22 = 1.0;
        const double c_b25 = 0.0;
        const int c__2 = 2;
        const bool c_true = true;

        /* System generated locals */
        int t_dim1, t_offset, vl_dim1, vl_offset, vr_dim1, vr_offset, i__1, i__2, i__3;
        double d__1, d__2, d__3, d__4;

        /* Local variables */
        int i__, j, k;
        double* x = stackalloc double[4];
        int j1, j2, n2, ii, ki, ip, _is;
        double wi, wr, rec, ulp, beta, emax;
        bool pair;
        bool allv;
        int ierr=0;
        double unfl, ovfl, smin;
        bool over;
        double vmax;
        int jnxt;
        double scale=0;
        double remax;
        bool leftv, bothv;
        double vcrit;
        bool somev;
        double xnorm=0;
        double bignum;
        bool rightv;
        double smlnum;

        /* Parameter adjustments */
        --select;
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        vl_dim1 = ldvl;
        vl_offset = 1 + vl_dim1;
        vl -= vl_offset;
        vr_dim1 = ldvr;
        vr_offset = 1 + vr_dim1;
        vr -= vr_offset;
        --work;

        /* Function Body */
        bothv = lsame(side, 'B');
        rightv = lsame(side, 'R') || bothv;
        leftv = lsame(side, 'L') || bothv;

        allv = lsame(howmny, 'A');
        over = lsame(howmny, 'B');
        somev = lsame(howmny, 'S');

        info = 0;
        if (! rightv && ! leftv) {
	    info = -1;
        } else if (! allv && ! over && ! somev) {
	    info = -2;
        } else if (n < 0) {
	    info = -4;
        } else if (ldt < max(1,n)) {
	    info = -6;
        } else if (ldvl < 1 || leftv && ldvl < n) {
	    info = -8;
        } else if (ldvr < 1 || rightv && ldvr < n) {
	    info = -10;
        } else {

    /*        Set M to the number of columns required to store the selected */
    /*        eigenvectors, standardize the array SELECT if necessary, and */
    /*        test MM. */

	    if (somev) {
	        m = 0;
	        pair = false;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (pair) {
		        pair = false;
		        select[j] = false;
		    } else {
		        if (j < n) {
			    if (t[j + 1 + j * t_dim1] == 0.0) {
			        if (select[j]) {
				    ++(m);
			        }
			    } else {
			        pair = true;
			        if (select[j] || select[j + 1]) {
				    select[j] = true;
				    m += 2;
			        }
			    }
		        } else {
			    if (select[n]) {
			        ++(m);
			    }
		        }
		    }
    /* L10: */
	        }
	    } else {
	        m = n;
	    }

	    if (mm < m) {
	        info = -11;
	    }
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DTREVC", i__1);
	    return 0;
        }

    /*     Quick return if possible. */

        if (n == 0) {
	    return 0;
        }

    /*     Set the constants to control overflow. */

        unfl = dlamch('S');
        ovfl = 1.0 / unfl;
        dlabad(ref unfl, ref ovfl);
        ulp = dlamch('P');
        smlnum = unfl * (n / ulp);
        bignum = (1.0 - ulp) / smlnum;

    /*     Compute 1-norm of each column of strictly upper triangular */
    /*     part of T to control overflow in triangular solver. */

        work[1] = 0.0;
        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    work[j] = 0.0;
	    i__2 = j - 1;
	    for (i__ = 1; i__ <= i__2; ++i__) {
            d__1 = t[i__ + j * t_dim1];
	        work[j] += ( abs(d__1));
    /* L20: */
	    }
    /* L30: */
        }

    /*     Index IP _is used to specify the real or complex eigenvalue: */
    /*       IP = 0, real eigenvalue, */
    /*            1, first of conjugate complex pair: (wr,wi) */
    /*           -1, second of conjugate complex pair: (wr,wi) */

        n2 = n << 1;

        if (rightv) {

    /*        Compute right eigenvectors. */

	    ip = 0;
	    _is = m;
	    for (ki = n; ki >= 1; --ki) {

	        if (ip == 1) {
		    goto L130;
	        }
	        if (ki == 1) {
		    goto L40;
	        }
	        if (t[ki + (ki - 1) * t_dim1] == 0.0) {
		    goto L40;
	        }
	        ip = -1;

    L40:
	        if (somev) {
		    if (ip == 0) {
		        if (! select[ki]) {
			    goto L130;
		        }
		    } else {
		        if (! select[ki - 1]) {
			    goto L130;
		        }
		    }
	        }

    /*           Compute the KI-th eigenvalue (WR,WI). */

	        wr = t[ki + ki * t_dim1];
	        wi = 0.0;
	        if (ip != 0) {
            d__1 = t[ki + (ki - 1) * t_dim1];
            d__2 = t[ki - 1 + ki * t_dim1];
		    wi = sqrt(( abs(d__1))) * sqrt((abs(d__2)));
	        }
    /* Computing MAX */
	        d__1 = ulp * (abs(wr) + abs(wi));
	        smin = max(d__1,smlnum);

	        if (ip == 0) {

    /*              Real right eigenvector */

		    work[ki + n] = 1.0;

    /*              Form right-hand side */

		    i__1 = ki - 1;
		    for (k = 1; k <= i__1; ++k) {
		        work[k + n] = -t[k + ki * t_dim1];
    /* L50: */
		    }

    /*              Solve the upper quasi-triangular system: */
    /*                 (T(1:KI-1,1:KI-1) - WR)*X = SCALE*WORK. */

		    jnxt = ki - 1;
		    for (j = ki - 1; j >= 1; --j) {
		        if (j > jnxt) {
			    goto L60;
		        }
		        j1 = j;
		        j2 = j;
		        jnxt = j - 1;
		        if (j > 1) {
			    if (t[j + (j - 1) * t_dim1] != 0.0) {
			        j1 = j - 1;
			        jnxt = j - 2;
			    }
		        }

		        if (j1 == j2) {

    /*                    1-by-1 diagonal block */

			    dlaln2(c_false, c__1, c__1, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
				    n], n, wr, c_b25, x, c__2, ref scale, ref xnorm, 
				    ref ierr);

    /*                    Scale X(1,1) to avoid overflow when updating */
    /*                    the right-hand side. */

			    if (xnorm > 1.0) {
			        if (work[j] > bignum / xnorm) {
				    x[0] /= xnorm;
				    scale /= xnorm;
			        }
			    }

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        dscal(ki, scale, &work[n + 1], c__1);
			    }
			    work[j + n] = x[0];

    /*                    Update right-hand side */

			    i__1 = j - 1;
			    d__1 = -x[0];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n + 1], c__1);

		        } else {

    /*                    2-by-2 diagonal block */

			    dlaln2(c_false, c__2, c__1, smin, c_b22, &t[j - 
				    1 + (j - 1) * t_dim1], ldt, c_b22, c_b22, 
				    &work[j - 1 + n], n, wr, c_b25, x, c__2, 
				   ref scale, ref xnorm, ref ierr);

    /*                    Scale X(1,1) and X(2,1) to avoid overflow when */
    /*                    updating the right-hand side. */

			    if (xnorm > 1.0) {
    /* Computing MAX */
			        d__1 = work[j - 1]; d__2 = work[j];
			        beta = max(d__1,d__2);
			        if (beta > bignum / xnorm) {
				    x[0] /= xnorm;
				    x[1] /= xnorm;
				    scale /= xnorm;
			        }
			    }

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        dscal(ki, scale, &work[n + 1], c__1);
			    }
			    work[j - 1 + n] = x[0];
			    work[j + n] = x[1];

    /*                    Update right-hand side */

			    i__1 = j - 2;
			    d__1 = -x[0];
			    daxpy(i__1, d__1, &t[(j - 1) * t_dim1 + 1], c__1, 
				    &work[n + 1], c__1);
			    i__1 = j - 2;
			    d__1 = -x[1];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n + 1], c__1);
		        }
    L60:
		        ;
		    }

    /*              Copy the vector x or Q*x to VR and normalize. */

		    if (! over) {
		        dcopy(ki, &work[n + 1], c__1, &vr[_is * vr_dim1 + 1], 
			        c__1);

		        ii = idamax(ki, &vr[_is * vr_dim1 + 1], c__1);
                d__1 = vr[ii + _is * vr_dim1];
		        remax = 1.0 / ( abs(d__1));
		        dscal(ki, remax, &vr[_is * vr_dim1 + 1], c__1);

		        i__1 = n;
		        for (k = ki + 1; k <= i__1; ++k) {
			    vr[k + _is * vr_dim1] = 0.0;
    /* L70: */
		        }
		    } else {
		        if (ki > 1) {
			    i__1 = ki - 1;
			    dgemv('N', n, i__1, c_b22, &vr[vr_offset], ldvr, &
				    work[n + 1], c__1, work[ki + n], &vr[ki * 
				    vr_dim1 + 1], c__1);
		        }

		        ii = idamax(n, &vr[ki * vr_dim1 + 1], c__1);
                d__1 = vr[ii + ki * vr_dim1];
		        remax = 1.0 / ( abs(d__1));
		        dscal(n, remax, &vr[ki * vr_dim1 + 1], c__1);
		    }

	        } else {

    /*              Complex right eigenvector. */

    /*              Initial solve */
    /*                [ (T(KI-1,KI-1) T(KI-1,KI) ) - (WR + I* WI)]*X = 0.0 */
    /*                [ (T(KI,KI-1)   T(KI,KI)   )               ] */

		    if (abs(t[ki - 1 + ki * t_dim1]) >= abs(t[ki + (ki - 1) * t_dim1])) {
		        work[ki - 1 + n] = 1.0;
		        work[ki + n2] = wi / t[ki - 1 + ki * t_dim1];
		    } else {
		        work[ki - 1 + n] = -wi / t[ki + (ki - 1) * t_dim1];
		        work[ki + n2] = 1.0;
		    }
		    work[ki + n] = 0.0;
		    work[ki - 1 + n2] = 0.0;

    /*              Form right-hand side */

		    i__1 = ki - 2;
		    for (k = 1; k <= i__1; ++k) {
		        work[k + n] = -work[ki - 1 + n] * t[k + (ki - 1) * 
			        t_dim1];
		        work[k + n2] = -work[ki + n2] * t[k + ki * t_dim1];
    /* L80: */
		    }

    /*              Solve upper quasi-triangular system: */
    /*              (T(1:KI-2,1:KI-2) - (WR+i*WI))*X = SCALE*(WORK+i*WORK2) */

		    jnxt = ki - 2;
		    for (j = ki - 2; j >= 1; --j) {
		        if (j > jnxt) {
			    goto L90;
		        }
		        j1 = j;
		        j2 = j;
		        jnxt = j - 1;
		        if (j > 1) {
			    if (t[j + (j - 1) * t_dim1] != 0.0) {
			        j1 = j - 1;
			        jnxt = j - 2;
			    }
		        }

		        if (j1 == j2) {

    /*                    1-by-1 diagonal block */

			    dlaln2(c_false, c__1, c__2, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
                    n], n, wr, wi, x, c__2, ref scale, ref xnorm, 
				    ref ierr);

    /*                    Scale X(1,1) and X(1,2) to avoid overflow when */
    /*                    updating the right-hand side. */

			    if (xnorm > 1.0) {
			        if (work[j] > bignum / xnorm) {
				    x[0] /= xnorm;
				    x[2] /= xnorm;
				    scale /= xnorm;
			        }
			    }

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        dscal(ki, scale, &work[n + 1], c__1);
			        dscal(ki, scale, &work[n2 + 1], c__1);
			    }
			    work[j + n] = x[0];
			    work[j + n2] = x[2];

    /*                    Update the right-hand side */

			    i__1 = j - 1;
			    d__1 = -x[0];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n + 1], c__1);
			    i__1 = j - 1;
			    d__1 = -x[2];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n2 + 1], c__1);

		        } else {

    /*                    2-by-2 diagonal block */

			    dlaln2(c_false, c__2, c__2, smin, c_b22, &t[j - 
				    1 + (j - 1) * t_dim1], ldt, c_b22, c_b22, &
				    work[j - 1 + n], n, wr, wi, x, c__2, 
				    ref scale, ref xnorm, ref ierr);

    /*                    Scale X to avoid overflow when updating */
    /*                    the right-hand side. */

			    if (xnorm > 1.0) {
    /* Computing MAX */
			        d__1 = work[j - 1]; d__2 = work[j];
			        beta = max(d__1,d__2);
			        if (beta > bignum / xnorm) {
				    rec = 1.0 / xnorm;
				    x[0] *= rec;
				    x[2] *= rec;
				    x[1] *= rec;
				    x[3] *= rec;
				    scale *= rec;
			        }
			    }

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        dscal(ki, scale, &work[n + 1], c__1);
			        dscal(ki, scale, &work[n2 + 1], c__1);
			    }
			    work[j - 1 + n] = x[0];
			    work[j + n] = x[1];
			    work[j - 1 + n2] = x[2];
			    work[j + n2] = x[3];

    /*                    Update the right-hand side */

			    i__1 = j - 2;
			    d__1 = -x[0];
			    daxpy(i__1, d__1, &t[(j - 1) * t_dim1 + 1], c__1, 
				    &work[n + 1], c__1);
			    i__1 = j - 2;
			    d__1 = -x[1];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n + 1], c__1);
			    i__1 = j - 2;
			    d__1 = -x[2];
			    daxpy(i__1, d__1, &t[(j - 1) * t_dim1 + 1], c__1, 
				    &work[n2 + 1], c__1);
			    i__1 = j - 2;
			    d__1 = -x[3];
			    daxpy(i__1, d__1, &t[j * t_dim1 + 1], c__1, &work[
				    n2 + 1], c__1);
		        }
    L90:
		        ;
		    }

    /*              Copy the vector x or Q*x to VR and normalize. */

		    if (! over) {
		        dcopy(ki, &work[n + 1], c__1, &vr[(_is - 1) * vr_dim1 
			        + 1], c__1);
		        dcopy(ki, &work[n2 + 1], c__1, &vr[_is * vr_dim1 + 1], 
			        c__1);

		        emax = 0.0;
		        i__1 = ki;
		        for (k = 1; k <= i__1; ++k) {
    /* Computing MAX */
			    d__3 = emax;
                d__1 = vr[k + (_is - 1) * vr_dim1];
                d__2 = vr[k + _is * vr_dim1];
                d__4 = ( abs(d__1)) + ( abs(d__2));
			    emax = max(d__3,d__4);
    /* L100: */
		        }

		        remax = 1.0 / emax;
		        dscal(ki, remax, &vr[(_is - 1) * vr_dim1 + 1], c__1);
		        dscal(ki, remax, &vr[_is * vr_dim1 + 1], c__1);

		        i__1 = n;
		        for (k = ki + 1; k <= i__1; ++k) {
			    vr[k + (_is - 1) * vr_dim1] = 0.0;
			    vr[k + _is * vr_dim1] = 0.0;
    /* L110: */
		        }

		    } else {

		        if (ki > 2) {
			    i__1 = ki - 2;
			    dgemv('N', n, i__1, c_b22, &vr[vr_offset], ldvr, &
				    work[n + 1], c__1, work[ki - 1 + n], &vr[(
				    ki - 1) * vr_dim1 + 1], c__1);
			    i__1 = ki - 2;
			    dgemv('N', n, i__1, c_b22, &vr[vr_offset], ldvr, &
				    work[n2 + 1], c__1, work[ki + n2], &vr[ki * 
				    vr_dim1 + 1], c__1);
		        } else {
			    dscal(n, work[ki - 1 + n], &vr[(ki - 1) * vr_dim1 
				    + 1], c__1);
			    dscal(n, work[ki + n2], &vr[ki * vr_dim1 + 1], 
				    c__1);
		        }

		        emax = 0.0;
		        i__1 = n;
		        for (k = 1; k <= i__1; ++k) {
    /* Computing MAX */
			    d__3 = emax;
                d__1 = vr[k + (ki - 1) * vr_dim1];
                d__2 = vr[k + ki * vr_dim1];
                d__4 = ( abs(d__1)) + ( abs(d__2));
			    emax = max(d__3,d__4);
    /* L120: */
		        }
		        remax = 1.0 / emax;
		        dscal(n, remax, &vr[(ki - 1) * vr_dim1 + 1], c__1);
		        dscal(n, remax, &vr[ki * vr_dim1 + 1], c__1);
		    }
	        }

	        --_is;
	        if (ip != 0) {
		    --_is;
	        }
    L130:
	        if (ip == 1) {
		    ip = 0;
	        }
	        if (ip == -1) {
		    ip = 1;
	        }
    /* L140: */
	    }
        }

        if (leftv) {

    /*        Compute left eigenvectors. */

	    ip = 0;
	    _is = 1;
	    i__1 = n;
	    for (ki = 1; ki <= i__1; ++ki) {

	        if (ip == -1) {
		    goto L250;
	        }
	        if (ki == n) {
		    goto L150;
	        }
	        if (t[ki + 1 + ki * t_dim1] == 0.0) {
		    goto L150;
	        }
	        ip = 1;

    L150:
	        if (somev) {
		    if (! select[ki]) {
		        goto L250;
		    }
	        }

    /*           Compute the KI-th eigenvalue (WR,WI). */

	        wr = t[ki + ki * t_dim1];
	        wi = 0.0;
	        if (ip != 0) {
            d__1 = t[ki + (ki + 1) * t_dim1];
            d__2 = t[ki + 1 + ki * t_dim1];
		    wi = sqrt(( abs(d__1))) * sqrt(( abs(d__2)));
	        }
    /* Computing MAX */
	        d__1 = ulp * (abs(wr) + abs(wi));
	        smin = max(d__1,smlnum);

	        if (ip == 0) {

    /*              Real left eigenvector. */

		    work[ki + n] = 1.0;

    /*              Form right-hand side */

		    i__2 = n;
		    for (k = ki + 1; k <= i__2; ++k) {
		        work[k + n] = -t[ki + k * t_dim1];
    /* L160: */
		    }

    /*              Solve the quasi-triangular system: */
    /*                 (T(KI+1:N,KI+1:N) - WR)'*X = SCALE*WORK */

		    vmax = 1.0;
		    vcrit = bignum;

		    jnxt = ki + 1;
		    i__2 = n;
		    for (j = ki + 1; j <= i__2; ++j) {
		        if (j < jnxt) {
			    goto L170;
		        }
		        j1 = j;
		        j2 = j;
		        jnxt = j + 1;
		        if (j < n) {
			    if (t[j + 1 + j * t_dim1] != 0.0) {
			        j2 = j + 1;
			        jnxt = j + 2;
			    }
		        }

		        if (j1 == j2) {

    /*                    1-by-1 diagonal block */

    /*                    Scale if necessary to avoid overflow when forming */
    /*                    the right-hand side. */

			    if (work[j] > vcrit) {
			        rec = 1.0 / vmax;
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n], c__1);
			        vmax = 1.0;
			        vcrit = bignum;
			    }

			    i__3 = j - ki - 1;
			    work[j + n] -= ddot(i__3, &t[ki + 1 + j * t_dim1], 
				    c__1, &work[ki + 1 + n], c__1);

    /*                    Solve (T(J,J)-WR)'*X = WORK */

			    dlaln2(c_false, c__1, c__1, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
				    n], n, wr, c_b25, x, c__2, ref scale, ref xnorm, 
				    ref ierr);

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n], c__1);
			    }
			    work[j + n] = x[0];
    /* Computing MAX */
                d__1 = work[j + n];
			    d__2 = ( abs(d__1));
			    vmax = max(d__2,vmax);
			    vcrit = bignum / vmax;

		        } else {

    /*                    2-by-2 diagonal block */

    /*                    Scale if necessary to avoid overflow when forming */
    /*                    the right-hand side. */

    /* Computing MAX */
			    d__1 = work[j]; d__2 = work[j + 1];
			    beta = max(d__1,d__2);
			    if (beta > vcrit) {
			        rec = 1.0 / vmax;
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n], c__1);
			        vmax = 1.0;
			        vcrit = bignum;
			    }

			    i__3 = j - ki - 1;
			    work[j + n] -= ddot(i__3, &t[ki + 1 + j * t_dim1], 
				    c__1, &work[ki + 1 + n], c__1);

			    i__3 = j - ki - 1;
			    work[j + 1 + n] -= ddot(i__3, &t[ki + 1 + (j + 1) *
				     t_dim1], c__1, &work[ki + 1 + n], c__1);

    /*                    Solve */
    /*                      [T(J,J)-WR   T(J,J+1)     ]'* X = SCALE*( WORK1 ) */
    /*                      [T(J+1,J)    T(J+1,J+1)-WR]             ( WORK2 ) */

			    dlaln2(c_true, c__2, c__1, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
				    n], n, wr, c_b25, x, c__2, ref scale, ref xnorm, 
				    ref ierr);

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n], c__1);
			    }
			    work[j + n] = x[0];
			    work[j + 1 + n] = x[1];

    /* Computing MAX */
                d__1 = work[j + n];
			    d__3 = ( abs(d__1));
                d__2 = work[j + 1 + n];
                d__4 = ( abs(d__2));
                d__3 = max(d__3,d__4);
			    vmax = max(d__3,vmax);
			    vcrit = bignum / vmax;

		        }
    L170:
		        ;
		    }

    /*              Copy the vector x or Q*x to VL and normalize. */

		    if (! over) {
		        i__2 = n - ki + 1;
		        dcopy(i__2, &work[ki + n], c__1, &vl[ki + _is * 
			        vl_dim1], c__1);

		        i__2 = n - ki + 1;
		        ii = idamax(i__2, &vl[ki + _is * vl_dim1], c__1) + ki - 
			        1;
                d__1 = vl[ii + _is * vl_dim1];
		        remax = 1.0 / ( abs(d__1));
		        i__2 = n - ki + 1;
		        dscal(i__2, remax, &vl[ki + _is * vl_dim1], c__1);

		        i__2 = ki - 1;
		        for (k = 1; k <= i__2; ++k) {
			    vl[k + _is * vl_dim1] = 0.0;
    /* L180: */
		        }

		    } else {

		        if (ki < n) {
			    i__2 = n - ki;
			    dgemv('N', n, i__2, c_b22, &vl[(ki + 1) * vl_dim1 
				    + 1], ldvl, &work[ki + 1 + n], c__1, work[
				    ki + n], &vl[ki * vl_dim1 + 1], c__1);
		        }

		        ii = idamax(n, &vl[ki * vl_dim1 + 1], c__1);
                d__1 = vl[ii + ki * vl_dim1];
		        remax = 1.0 / ( abs(d__1));
		        dscal(n, remax, &vl[ki * vl_dim1 + 1], c__1);

		    }

	        } else {

    /*              Complex left eigenvector. */

    /*               Initial solve: */
    /*                 ((T(KI,KI)    T(KI,KI+1) )' - (WR - I* WI))*X = 0.0 */
    /*                 ((T(KI+1,KI) T(KI+1,KI+1))                ) */

		    if ((abs(t[ki + (ki + 1) * t_dim1])) >= (abs(t[ki + 1 + ki * t_dim1]))) {
		        work[ki + n] = wi / t[ki + (ki + 1) * t_dim1];
		        work[ki + 1 + n2] = 1.0;
		    } else {
		        work[ki + n] = 1.0;
		        work[ki + 1 + n2] = -wi / t[ki + 1 + ki * t_dim1];
		    }
		    work[ki + 1 + n] = 0.0;
		    work[ki + n2] = 0.0;

    /*              Form right-hand side */

		    i__2 = n;
		    for (k = ki + 2; k <= i__2; ++k) {
		        work[k + n] = -work[ki + n] * t[ki + k * t_dim1];
		        work[k + n2] = -work[ki + 1 + n2] * t[ki + 1 + k * t_dim1]
			        ;
    /* L190: */
		    }

    /*              Solve complex quasi-triangular system: */
    /*              ( T(KI+2,N:KI+2,N) - (WR-i*WI) )*X = WORK1+i*WORK2 */

		    vmax = 1.0;
		    vcrit = bignum;

		    jnxt = ki + 2;
		    i__2 = n;
		    for (j = ki + 2; j <= i__2; ++j) {
		        if (j < jnxt) {
			    goto L200;
		        }
		        j1 = j;
		        j2 = j;
		        jnxt = j + 1;
		        if (j < n) {
			    if (t[j + 1 + j * t_dim1] != 0.0) {
			        j2 = j + 1;
			        jnxt = j + 2;
			    }
		        }

		        if (j1 == j2) {

    /*                    1-by-1 diagonal block */

    /*                    Scale if necessary to avoid overflow when */
    /*                    forming the right-hand side elements. */

			    if (work[j] > vcrit) {
			        rec = 1.0 / vmax;
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n], c__1);
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n2], c__1);
			        vmax = 1.0;
			        vcrit = bignum;
			    }

			    i__3 = j - ki - 2;
			    work[j + n] -= ddot(i__3, &t[ki + 2 + j * t_dim1], 
				    c__1, &work[ki + 2 + n], c__1);
			    i__3 = j - ki - 2;
			    work[j + n2] -= ddot(i__3, &t[ki + 2 + j * t_dim1], 
				    c__1, &work[ki + 2 + n2], c__1);

    /*                    Solve (T(J,J)-(WR-i*WI))*(X11+i*X12)= WK+I*WK2 */

			    d__1 = -wi;
			    dlaln2(c_false, c__1, c__2, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
				    n], n, wr, d__1, x, c__2, ref scale, ref xnorm, ref
				    ierr);

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n], c__1);
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n2], c__1);
			    }
			    work[j + n] = x[0];
			    work[j + n2] = x[2];
    /* Computing MAX */
                d__1 = work[j + n];
			    d__3 = ( abs(d__1));
                d__2 = work[j + n2];
                d__4 = ( abs(d__2));
                d__3 = max(d__3, d__4);
			    vmax = max(d__3,vmax);
			    vcrit = bignum / vmax;

		        } else {

    /*                    2-by-2 diagonal block */

    /*                    Scale if necessary to avoid overflow when forming */
    /*                    the right-hand side elements. */

    /* Computing MAX */
			    d__1 = work[j]; d__2 = work[j + 1];
			    beta = max(d__1,d__2);
			    if (beta > vcrit) {
			        rec = 1.0 / vmax;
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n], c__1);
			        i__3 = n - ki + 1;
			        dscal(i__3, rec, &work[ki + n2], c__1);
			        vmax = 1.0;
			        vcrit = bignum;
			    }

			    i__3 = j - ki - 2;
			    work[j + n] -= ddot(i__3, &t[ki + 2 + j * t_dim1], 
				    c__1, &work[ki + 2 + n], c__1);

			    i__3 = j - ki - 2;
			    work[j + n2] -= ddot(i__3, &t[ki + 2 + j * t_dim1], 
				    c__1, &work[ki + 2 + n2], c__1);

			    i__3 = j - ki - 2;
			    work[j + 1 + n] -= ddot(i__3, &t[ki + 2 + (j + 1) *
				     t_dim1], c__1, &work[ki + 2 + n], c__1);

			    i__3 = j - ki - 2;
			    work[j + 1 + n2] -= ddot(i__3, &t[ki + 2 + (j + 1) *
				     t_dim1], c__1, &work[ki + 2 + n2], c__1);

    /*                    Solve 2-by-2 complex linear equation */
    /*                      ([T(j,j)   T(j,j+1)  ]'-(wr-i*wi)*I)*X = SCALE*B */
    /*                      ([T(j+1,j) T(j+1,j+1)]             ) */

			    d__1 = -wi;
			    dlaln2(c_true, c__2, c__2, smin, c_b22, &t[j + 
				    j * t_dim1], ldt, c_b22, c_b22, &work[j + 
				    n], n, wr, d__1, x, c__2, ref scale, ref xnorm, ref
				    ierr);

    /*                    Scale if necessary */

			    if (scale != 1.0) {
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n], c__1);
			        i__3 = n - ki + 1;
			        dscal(i__3, scale, &work[ki + n2], c__1);
			    }
			    work[j + n] = x[0];
			    work[j + n2] = x[2];
			    work[j + 1 + n] = x[1];
			    work[j + 1 + n2] = x[3];
    /* Computing MAX */
			    d__1 = abs(x[0]);
                d__2 = abs(x[2]);
                d__1 = max(d__1, d__2);
                d__2 = abs(x[1]);
                d__1 = max(d__1,d__2);
                d__2 = abs(x[3]);
                d__1 = max(d__1,d__2);
			    vmax = max(d__1,vmax);
			    vcrit = bignum / vmax;

		        }
    L200:
		        ;
		    }

    /*              Copy the vector x or Q*x to VL and normalize. */

		    if (! over) {
		        i__2 = n - ki + 1;
		        dcopy(i__2, &work[ki + n], c__1, &vl[ki + _is * 
			        vl_dim1], c__1);
		        i__2 = n - ki + 1;
		        dcopy(i__2, &work[ki + n2], c__1, &vl[ki + (_is + 1) * 
			        vl_dim1], c__1);

		        emax = 0.0;
		        i__2 = n;
		        for (k = ki; k <= i__2; ++k) {
    /* Computing MAX */
			    d__3 = emax;
                d__1 = vl[k + _is * vl_dim1];
                d__2 = vl[k + (_is + 1) * vl_dim1];
                d__4 = ( abs(d__1)) + ( abs(d__2));
			    emax = max(d__3,d__4);
    /* L220: */
		        }
		        remax = 1.0 / emax;
		        i__2 = n - ki + 1;
		        dscal(i__2, remax, &vl[ki + _is * vl_dim1], c__1);
		        i__2 = n - ki + 1;
		        dscal(i__2, remax, &vl[ki + (_is + 1) * vl_dim1], c__1)
			        ;

		        i__2 = ki - 1;
		        for (k = 1; k <= i__2; ++k) {
			    vl[k + _is * vl_dim1] = 0.0;
			    vl[k + (_is + 1) * vl_dim1] = 0.0;
    /* L230: */
		        }
		    } else {
		        if (ki < n - 1) {
			    i__2 = n - ki - 1;
			    dgemv('N', n, i__2, c_b22, &vl[(ki + 2) * vl_dim1 
				    + 1], ldvl, &work[ki + 2 + n], c__1, work[
				    ki + n], &vl[ki * vl_dim1 + 1], c__1);
			    i__2 = n - ki - 1;
			    dgemv('N', n, i__2, c_b22, &vl[(ki + 2) * vl_dim1 
				    + 1], ldvl, &work[ki + 2 + n2], c__1, work[
				    ki + 1 + n2], &vl[(ki + 1) * vl_dim1 + 1], 
				    c__1);
		        } else {
			    dscal(n, work[ki + n], &vl[ki * vl_dim1 + 1], 
				    c__1);
			    dscal(n, work[ki + 1 + n2], &vl[(ki + 1) * vl_dim1 
				    + 1], c__1);
		        }

		        emax = 0.0;
		        i__2 = n;
		        for (k = 1; k <= i__2; ++k) {
    /* Computing MAX */
			    d__3 = emax;
                d__1 = vl[k + ki * vl_dim1];
                d__2 = vl[k + (ki + 1) * vl_dim1];
                d__4 = ( abs(d__1)) + ( abs(d__2));
			    emax = max(d__3,d__4);
    /* L240: */
		        }
		        remax = 1.0 / emax;
		        dscal(n, remax, &vl[ki * vl_dim1 + 1], c__1);
		        dscal(n, remax, &vl[(ki + 1) * vl_dim1 + 1], c__1);

		    }

	        }

	        ++_is;
	        if (ip != 0) {
		    ++_is;
	        }
    L250:
	        if (ip == -1) {
		    ip = 0;
	        }
	        if (ip == 1) {
		    ip = -1;
	        }

    /* L260: */
	    }

        }

        return 0;
    }
}

