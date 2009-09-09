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
    public static unsafe int dtrsna(char job, char howmny, bool *select, int n, double *t, int ldt,
        double *vl, int ldvl, double *vr, int ldvr, double *s, double *sep, int mm, ref int m,
        double *work, int ldwork, int* iwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const bool c_true = true;
        const bool c_false = false;

        /* System generated locals */
        int t_dim1, t_offset, vl_dim1, vl_offset, vr_dim1, vr_offset, work_dim1, work_offset, i__1, i__2;
        double d__1, d__2;

        /* Local variables */
        int i__, j, k, n2;
        double cs;
        int nn, ks;
        double sn, mu=0, eps, est;
        int kase;
        double cond;
        bool pair;
        int ierr=0;
        double dumm=0, prod;
        int ifst;
        double lnrm;
        int ilst;
        double rnrm;
        double prod1, prod2, scale=0, delta;
        int* isave = stackalloc int[3];
        bool wants;
        double* dummy = stackalloc double[1];
        double bignum;
        bool wantbh;
        bool somcon;
        double smlnum;
        bool wantsp;

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
        --s;
        --sep;
        work_dim1 = ldwork;
        work_offset = 1 + work_dim1;
        work -= work_offset;
        --iwork;

        /* Function Body */
        wantbh = lsame(job, 'B');
        wants = lsame(job, 'E') || wantbh;
        wantsp = lsame(job, 'V') || wantbh;

        somcon = lsame(howmny, 'S');

        info = 0;
        if (! wants && ! wantsp) {
	    info = -1;
        } else if (! lsame(howmny, 'A') && ! somcon) {
	    info = -2;
        } else if (n < 0) {
	    info = -4;
        } else if (ldt < max(1,n)) {
	    info = -6;
        } else if (ldvl < 1 || wants && ldvl < n) {
	    info = -8;
        } else if (ldvr < 1 || wants && ldvr < n) {
	    info = -10;
        } else {

    /*        Set M to the number of eigenpairs for which condition numbers */
    /*        are required, and test MM. */

	    if (somcon) {
	        m = 0;
	        pair = false;
	        i__1 = n;
	        for (k = 1; k <= i__1; ++k) {
		    if (pair) {
		        pair = false;
		    } else {
		        if (k < n) {
			    if (t[k + 1 + k * t_dim1] == 0.0) {
			        if (select[k]) {
				    ++(m);
			        }
			    } else {
			        pair = true;
			        if (select[k] || select[k + 1]) {
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
	        info = -13;
	    } else if (ldwork < 1 || wantsp && ldwork < n) {
	        info = -16;
	    }
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DTRSNA", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }

        if (n == 1) {
	    if (somcon) {
	        if (! select[1]) {
		    return 0;
	        }
	    }
	    if (wants) {
	        s[1] = 1.0;
	    }
	    if (wantsp) {
            d__1 = t[t_dim1 + 1];
	        sep[1] = ( abs(d__1));
	    }
	    return 0;
        }

    /*     Get machine constants */

        eps = dlamch('P');
        smlnum = dlamch('S') / eps;
        bignum = 1.0 / smlnum;
        dlabad(ref smlnum, ref bignum);

        ks = 0;
        pair = false;
        i__1 = n;
        for (k = 1; k <= i__1; ++k) {

    /*        Determine whether T(k,k) begins a 1-by-1 or 2-by-2 block. */

	    if (pair) {
	        pair = false;
	        goto L60;
	    } else {
	        if (k < n) {
		    pair = t[k + 1 + k * t_dim1] != 0.0;
	        }
	    }

    /*        Determine whether condition numbers are required for the k-th */
    /*        eigenpair. */

	    if (somcon) {
	        if (pair) {
		    if (! select[k] && ! select[k + 1]) {
		        goto L60;
		    }
	        } else {
		    if (! select[k]) {
		        goto L60;
		    }
	        }
	    }

	    ++ks;

	    if (wants) {

    /*           Compute the reciprocal condition number of the k-th */
    /*           eigenvalue. */

	        if (! pair) {

    /*              Real eigenvalue. */

		    prod = ddot(n, &vr[ks * vr_dim1 + 1], c__1, &vl[ks * 
			    vl_dim1 + 1], c__1);
		    rnrm = dnrm2(n, &vr[ks * vr_dim1 + 1], c__1);
		    lnrm = dnrm2(n, &vl[ks * vl_dim1 + 1], c__1);
		    s[ks] = abs(prod) / (rnrm * lnrm);
	        } else {

    /*              Complex eigenvalue. */

		    prod1 = ddot(n, &vr[ks * vr_dim1 + 1], c__1, &vl[ks * 
			    vl_dim1 + 1], c__1);
		    prod1 += ddot(n, &vr[(ks + 1) * vr_dim1 + 1], c__1, &vl[(ks 
			    + 1) * vl_dim1 + 1], c__1);
		    prod2 = ddot(n, &vl[ks * vl_dim1 + 1], c__1, &vr[(ks + 1) * 
			    vr_dim1 + 1], c__1);
		    prod2 -= ddot(n, &vl[(ks + 1) * vl_dim1 + 1], c__1, &vr[ks *
			     vr_dim1 + 1], c__1);
		    d__1 = dnrm2(n, &vr[ks * vr_dim1 + 1], c__1);
		    d__2 = dnrm2(n, &vr[(ks + 1) * vr_dim1 + 1], c__1);
		    rnrm = dlapy2(d__1, d__2);
		    d__1 = dnrm2(n, &vl[ks * vl_dim1 + 1], c__1);
		    d__2 = dnrm2(n, &vl[(ks + 1) * vl_dim1 + 1], c__1);
		    lnrm = dlapy2(d__1, d__2);
		    cond = dlapy2(prod1, prod2) / (rnrm * lnrm);
		    s[ks] = cond;
		    s[ks + 1] = cond;
	        }
	    }

	    if (wantsp) {

    /*           Estimate the reciprocal condition number of the k-th */
    /*           eigenvector. */

    /*           Copy the matrix T to the array WORK and swap the diagonal */
    /*           block beginning at T(k,k) to the (1,1) position. */

	        dlacpy('F', n, n, &t[t_offset], ldt, &work[work_offset], 
		        ldwork);
	        ifst = k;
	        ilst = 1;
	        dtrexc('N', n, &work[work_offset], ldwork, dummy, c__1, 
		        ref ifst, ref ilst, &work[(n + 1) * work_dim1 + 1], ref ierr);

	        if (ierr == 1 || ierr == 2) {

    /*              Could not swap because blocks not well separated */

		    scale = 1.0;
		    est = bignum;
	        } else {

    /*              Reordering successful */

		    if (work[work_dim1 + 2] == 0.0) {

    /*                 Form C = T22 - lambda*I in WORK(2:N,2:N). */

		        i__2 = n;
		        for (i__ = 2; i__ <= i__2; ++i__) {
			    work[i__ + i__ * work_dim1] -= work[work_dim1 + 1];
    /* L20: */
		        }
		        n2 = 1;
		        nn = n - 1;
		    } else {

    /*                 Triangularize the 2 by 2 block by unitary */
    /*                 transformation U = [  cs   i*ss ] */
    /*                                    [ i*ss   cs  ]. */
    /*                 such that the (1,1) position of WORK is complex */
    /*                 eigenvalue lambda with positive imaginary part. (2,2) */
    /*                 position of WORK is the complex eigenvalue lambda */
    /*                 with negative imaginary  part. */

                d__1 = work[(work_dim1 << 1) + 1];
                d__2 = work[work_dim1 + 2];
		        mu = sqrt(( abs(d__1))) * sqrt(( abs(d__2)));
		        delta = dlapy2(mu, work[work_dim1 + 2]);
		        cs = mu / delta;
		        sn = -work[work_dim1 + 2] / delta;

    /*                 Form */

    /*                 C' = WORK(2:N,2:N) + i*[rwork(1) ..... rwork(n-1) ] */
    /*                                        [   mu                     ] */
    /*                                        [         ..               ] */
    /*                                        [             ..           ] */
    /*                                        [                  mu      ] */
    /*                 where C' is conjugate transpose of complex matrix C, */
    /*                 and RWORK is stored starting in the N+1-st column of */
    /*                 WORK. */

		        i__2 = n;
		        for (j = 3; j <= i__2; ++j) {
			    work[j * work_dim1 + 2] = cs * work[j * work_dim1 + 2]
				    ;
			    work[j + j * work_dim1] -= work[work_dim1 + 1];
    /* L30: */
		        }
		        work[(work_dim1 << 1) + 2] = 0.0;

		        work[(n + 1) * work_dim1 + 1] = mu * 2.0;
		        i__2 = n - 1;
		        for (i__ = 2; i__ <= i__2; ++i__) {
			    work[i__ + (n + 1) * work_dim1] = sn * work[(i__ + 1)
				     * work_dim1 + 1];
    /* L40: */
		        }
		        n2 = 2;
		        nn = n - 1 << 1;
		    }

    /*              Estimate norm(inv(C')) */

		    est = 0.0;
		    kase = 0;
    L50:
		    dlacn2(nn, &work[(n + 2) * work_dim1 + 1], &work[(n + 4) *
			     work_dim1 + 1], &iwork[1], ref est, ref kase, isave);
		    if (kase != 0) {
		        if (kase == 1) {
			    if (n2 == 1) {

    /*                       Real eigenvalue: solve C'*x = scale*c. */

			        i__2 = n - 1;
			        dlaqtr(c_true, c_true, i__2, &work[(work_dim1 
				        << 1) + 2], ldwork, dummy, dumm, ref scale, 
				        &work[(n + 4) * work_dim1 + 1], &work[(
				        n + 6) * work_dim1 + 1], ref ierr);
			    } else {

    /*                       Complex eigenvalue: solve */
    /*                       C'*(p+iq) = scale*(c+id) in real arithmetic. */

			        i__2 = n - 1;
			        dlaqtr(c_true, c_false, i__2, &work[(
				        work_dim1 << 1) + 2], ldwork, &work[(n + 
				        1) * work_dim1 + 1], mu, ref scale, &work[(
				        n + 4) * work_dim1 + 1], &work[(n + 6) * 
				        work_dim1 + 1], ref ierr);
			    }
		        } else {
			    if (n2 == 1) {

    /*                       Real eigenvalue: solve C*x = scale*c. */

			        i__2 = n - 1;
			        dlaqtr(c_false, c_true, i__2, &work[(
				        work_dim1 << 1) + 2], ldwork, dummy, 
				        dumm, ref scale, &work[(n + 4) * work_dim1 
				        + 1], &work[(n + 6) * work_dim1 + 1], 
				        ref ierr);
			    } else {

    /*                       Complex eigenvalue: solve */
    /*                       C*(p+iq) = scale*(c+id) in real arithmetic. */

			        i__2 = n - 1;
			        dlaqtr(c_false, c_false, i__2, &work[(
				        work_dim1 << 1) + 2], ldwork, &work[(n + 
				        1) * work_dim1 + 1], mu, ref scale, &work[(
				        n + 4) * work_dim1 + 1], &work[(n + 6) * 
				        work_dim1 + 1], ref ierr);

			    }
		        }

		        goto L50;
		    }
	        }

	        sep[ks] = scale / max(est,smlnum);
	        if (pair) {
		    sep[ks + 1] = sep[ks];
	        }
	    }

	    if (pair) {
	        ++ks;
	    }

    L60:
	    ;
        }
        return 0;
    }
}

