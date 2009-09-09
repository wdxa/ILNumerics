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
    public static unsafe int dgeevx(char balanc, char jobvl, char jobvr, char sense, int n, double* a, int lda,
        double* wr, double* wi, double* vl, int ldvl, double* vr, int ldvr, ref int ilo, ref int ihi, double* scale,
        ref double abnrm, double* rconde, double* rcondv, double* work, int lwork, int* iwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__0 = 0;
        const int c_n1 = -1;

        /* System generated locals */
        int a_dim1, a_offset, vl_dim1, vl_offset, vr_dim1, vr_offset, i__1, i__2, i__3;
        double d__1, d__2;

        /* Local variables */
        int i__, k;
        double r__=0, cs=0, sn=0;
        char job, side=' ';
        double* dum = stackalloc double[1];
        bool* select = stackalloc bool[1];
        double scl, eps;
        double anrm;
        int ierr=0, itau;
        int iwrk, nout=0;
        int icond;
        bool scalea;
        double cscale=0;
        double bignum;
        int minwrk, maxwrk=0;
        bool wantvl, wntsnb;
        int hswork;
        bool wntsne;
        double smlnum;
        bool lquery, wantvr, wntsnn, wntsnv;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --wr;
        --wi;
        vl_dim1 = ldvl;
        vl_offset = 1 + vl_dim1;
        vl -= vl_offset;
        vr_dim1 = ldvr;
        vr_offset = 1 + vr_dim1;
        vr -= vr_offset;
        --scale;
        --rconde;
        --rcondv;
        --work;
        --iwork;

        /* Function Body */
        info = 0;
        lquery = lwork == -1;
        wantvl = lsame(jobvl, 'V');
        wantvr = lsame(jobvr, 'V');
        wntsnn = lsame(sense, 'N');
        wntsne = lsame(sense, 'E');
        wntsnv = lsame(sense, 'V');
        wntsnb = lsame(sense, 'B');
        if (! (lsame(balanc, 'N') || lsame(balanc, 'S') || lsame(balanc, 'P') 
	        || lsame(balanc, 'B'))) {
	    info = -1;
        } else if (! wantvl && ! lsame(jobvl, 'N')) {
	    info = -2;
        } else if (! wantvr && ! lsame(jobvr, 'N')) {
	    info = -3;
        } else if (! (wntsnn || wntsne || wntsnb || wntsnv) || (wntsne || wntsnb) 
	        && ! (wantvl && wantvr)) {
	    info = -4;
        } else if (n < 0) {
	    info = -5;
        } else if (lda < max(1,n)) {
	    info = -7;
        } else if (ldvl < 1 || wantvl && ldvl < n) {
	    info = -11;
        } else if (ldvr < 1 || wantvr && ldvr < n) {
	    info = -13;
        }

    /*     Compute workspace */
    /*      (Note: Comments in the code beginning 'Workspace:' describe the */
    /*       minimal amount of workspace needed at that point in the code, */
    /*       as well as the preferred amount for good performance. */
    /*       NB refers to the optimal block size for the immediately */
    /*       following subroutine, as returned by ILAENV. */
    /*       HSWORK refers to the workspace preferred by DHSEQR, as */
    /*       calculated below. HSWORK is computed assuming ILO=1 and IHI=N, */
    /*       the worst case.) */

        if (info == 0) {
	    if (n == 0) {
	        minwrk = 1;
	        maxwrk = 1;
	    } else {
	        maxwrk = n + n * ilaenv(c__1, "DGEHRD", " ", n, c__1, n, 
		        c__0);

	        if (wantvl) {
		    dhseqr('S', 'V', n, c__1, n, &a[a_offset], lda, &wr[1], &wi[
			    1], &vl[vl_offset], ldvl, &work[1], c_n1, ref info);
	        } else if (wantvr) {
		    dhseqr('S', 'V', n, c__1, n, &a[a_offset], lda, &wr[1], &wi[
			    1], &vr[vr_offset], ldvr, &work[1], c_n1, ref info);
	        } else {
		    if (wntsnn) {
		        dhseqr('E', 'N', n, c__1, n, &a[a_offset], lda, &wr[1], 
			        &wi[1], &vr[vr_offset], ldvr, &work[1], c_n1, 
			        ref info);
		    } else {
		        dhseqr('S', 'N', n, c__1, n, &a[a_offset], lda, &wr[1], 
			        &wi[1], &vr[vr_offset], ldvr, &work[1], c_n1, 
			        ref info);
		    }
	        }
	        hswork = (int) work[1];

	        if (! wantvl && ! wantvr) {
		    minwrk = n << 1;
		    if (! wntsnn) {
    /* Computing MAX */
		        i__1 = minwrk; i__2 = n * n + n * 6;
		        minwrk = max(i__1,i__2);
		    }
		    maxwrk = max(maxwrk,hswork);
		    if (! wntsnn) {
    /* Computing MAX */
		        i__1 = maxwrk; i__2 = n * n + n * 6;
		        maxwrk = max(i__1,i__2);
		    }
	        } else {
		    minwrk = n * 3;
		    if (! wntsnn && ! wntsne) {
    /* Computing MAX */
		        i__1 = minwrk; i__2 = n * n + n * 6;
		        minwrk = max(i__1,i__2);
		    }
		    maxwrk = max(maxwrk,hswork);
    /* Computing MAX */
		    i__1 = maxwrk;
            i__2 = n + (n - 1) * ilaenv(c__1, "DORGHR", " ", n, c__1, n, c_n1);
		    maxwrk = max(i__1,i__2);
		    if (! wntsnn && ! wntsne) {
    /* Computing MAX */
		        i__1 = maxwrk;
                i__2 = n * n + n * 6;
		        maxwrk = max(i__1,i__2);
		    }
    /* Computing MAX */
            i__1 = maxwrk; i__2 = n * 3;
		    maxwrk = max(i__1,i__2);
	        }
	        maxwrk = max(maxwrk,minwrk);
	    }
	    work[1] = (double) maxwrk;

	    if (lwork < minwrk && ! lquery) {
	        info = -21;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEEVX", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }

    /*     Get machine constants */

        eps = dlamch('P');
        smlnum = dlamch('S');
        bignum = 1.0 / smlnum;
        dlabad(ref smlnum, ref bignum);
        smlnum = sqrt(smlnum) / eps;
        bignum = 1.0 / smlnum;

    /*     Scale A if max element outside range [SMLNUM,BIGNUM] */

        icond = 0;
        anrm = dlange('M', n, n, &a[a_offset], lda, dum);
        scalea = false;
        if (anrm > 0.0 && anrm < smlnum) {
	    scalea = true;
	    cscale = smlnum;
        } else if (anrm > bignum) {
	    scalea = true;
	    cscale = bignum;
        }
        if (scalea) {
	    dlascl('G', c__0, c__0, anrm, cscale, n, n, &a[a_offset], lda, 
		    ref ierr);
        }

    /*     Balance the matrix and compute ABNRM */

        dgebal(balanc, n, &a[a_offset], lda, ref ilo, ref ihi, &scale[1], ref ierr);
        abnrm = dlange('1', n, n, &a[a_offset], lda, dum);
        if (scalea) {
	    dum[0] = abnrm;
	    dlascl('G', c__0, c__0, cscale, anrm, c__1, c__1, dum, c__1, ref ierr);
	    abnrm = dum[0];
        }

    /*     Reduce to upper Hessenberg form */
    /*     (Workspace: need 2n, prefer N+N*NB) */

        itau = 1;
        iwrk = itau + n;
        i__1 = lwork - iwrk + 1;
        dgehrd(n, ilo, ihi, &a[a_offset], lda, &work[itau], &work[iwrk], i__1, ref ierr);

        if (wantvl) {

    /*        Want left eigenvectors */
    /*        Copy Householder vectors to VL */

	    side = 'L';
	    dlacpy('L', n, n, &a[a_offset], lda, &vl[vl_offset], ldvl);

    /*        Generate orthogonal matrix in VL */
    /*        (Workspace: need 2n-1, prefer N+(N-1)*NB) */

	    i__1 = lwork - iwrk + 1;
	    dorghr(n, ilo, ihi, &vl[vl_offset], ldvl, &work[itau], &work[iwrk], 
		    i__1, ref ierr);

    /*        Perform QR iteration, accumulating Schur vectors in VL */
    /*        (Workspace: need 1, prefer HSWORK (see comments) ) */

	    iwrk = itau;
	    i__1 = lwork - iwrk + 1;
	    dhseqr('S', 'V', n, ilo, ihi, &a[a_offset], lda, &wr[1], &wi[1], &vl[
		    vl_offset], ldvl, &work[iwrk], i__1, ref info);

	    if (wantvr) {

    /*           Want left and right eigenvectors */
    /*           Copy Schur vectors to VR */

	        side = 'B';
	        dlacpy('F', n, n, &vl[vl_offset], ldvl, &vr[vr_offset], ldvr);
	    }

        } else if (wantvr) {

    /*        Want right eigenvectors */
    /*        Copy Householder vectors to VR */

	    side = 'R';
	    dlacpy('L', n, n, &a[a_offset], lda, &vr[vr_offset], ldvr);

    /*        Generate orthogonal matrix in VR */
    /*        (Workspace: need 2n-1, prefer N+(N-1)*NB) */

	    i__1 = lwork - iwrk + 1;
	    dorghr(n, ilo, ihi, &vr[vr_offset], ldvr, &work[itau], &work[iwrk], 
		    i__1, ref ierr);

    /*        Perform QR iteration, accumulating Schur vectors in VR */
    /*        (Workspace: need 1, prefer HSWORK (see comments) ) */

	    iwrk = itau;
	    i__1 = lwork - iwrk + 1;
	    dhseqr('S', 'V', n, ilo, ihi, &a[a_offset], lda, &wr[1], &wi[1], &vr[
		    vr_offset], ldvr, &work[iwrk], i__1, ref info);

        } else {

    /*        Compute eigenvalues only */
    /*        If condition numbers desired, compute Schur form */

	    if (wntsnn) {
	        job = 'E';
	    } else {
	        job = 'S';
	    }

    /*        (Workspace: need 1, prefer HSWORK (see comments) ) */

	    iwrk = itau;
	    i__1 = lwork - iwrk + 1;
	    dhseqr(job, 'N', n, ilo, ihi, &a[a_offset], lda, &wr[1], &wi[1], &vr[
		    vr_offset], ldvr, &work[iwrk], i__1, ref info);
        }

    /*     If INFO > 0 from DHSEQR, then quit */

        if (info > 0) {
	    goto L50;
        }

        if (wantvl || wantvr) {

    /*        Compute left and/or right eigenvectors */
    /*        (Workspace: need 3n) */

	    dtrevc(side, 'B', select, n, &a[a_offset], lda, &vl[vl_offset], ldvl, 
		     &vr[vr_offset], ldvr, n, ref nout, &work[iwrk], ref ierr);
        }

    /*     Compute condition numbers if desired */
    /*     (Workspace: need Nn+6n unless SENSE = 'E') */

        if (! wntsnn) {
	    dtrsna(sense, 'A', select, n, &a[a_offset], lda, &vl[vl_offset], 
		    ldvl, &vr[vr_offset], ldvr, &rconde[1], &rcondv[1], n, ref nout, 
		    &work[iwrk], n, &iwork[1], ref icond);
        }

        if (wantvl) {

    /*        Undo balancing of left eigenvectors */

	    dgebak(balanc, 'L', n, ilo, ihi, &scale[1], n, &vl[vl_offset], ldvl, 
		    ref ierr);

    /*        Normalize left eigenvectors and make largest component real */

	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        if (wi[i__] == 0.0) {
		    scl = 1.0 / dnrm2(n, &vl[i__ * vl_dim1 + 1], c__1);
		    dscal(n, scl, &vl[i__ * vl_dim1 + 1], c__1);
	        } else if (wi[i__] > 0.0) {
		    d__1 = dnrm2(n, &vl[i__ * vl_dim1 + 1], c__1);
		    d__2 = dnrm2(n, &vl[(i__ + 1) * vl_dim1 + 1], c__1);
		    scl = 1.0 / dlapy2(d__1, d__2);
		    dscal(n, scl, &vl[i__ * vl_dim1 + 1], c__1);
		    dscal(n, scl, &vl[(i__ + 1) * vl_dim1 + 1], c__1);
		    i__2 = n;
		    for (k = 1; k <= i__2; ++k) {
    /* Computing 2nd power */
		        d__1 = vl[k + i__ * vl_dim1];
    /* Computing 2nd power */
		        d__2 = vl[k + (i__ + 1) * vl_dim1];
		        work[k] = d__1 * d__1 + d__2 * d__2;
    /* L10: */
		    }
		    k = idamax(n, &work[1], c__1);
		    dlartg(vl[k + i__ * vl_dim1], vl[k + (i__ + 1) * vl_dim1], 
			    ref cs, ref sn, ref r__);
		    drot(n, &vl[i__ * vl_dim1 + 1], c__1, &vl[(i__ + 1) * 
			    vl_dim1 + 1], c__1, cs, sn);
		    vl[k + (i__ + 1) * vl_dim1] = 0.0;
	        }
    /* L20: */
	    }
        }

        if (wantvr) {

    /*        Undo balancing of right eigenvectors */

	    dgebak(balanc, 'R', n, ilo, ihi, &scale[1], n, &vr[vr_offset], ldvr, 
		    ref ierr);

    /*        Normalize right eigenvectors and make largest component real */

	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        if (wi[i__] == 0.0) {
		    scl = 1.0 / dnrm2(n, &vr[i__ * vr_dim1 + 1], c__1);
		    dscal(n, scl, &vr[i__ * vr_dim1 + 1], c__1);
	        } else if (wi[i__] > 0.0) {
		    d__1 = dnrm2(n, &vr[i__ * vr_dim1 + 1], c__1);
		    d__2 = dnrm2(n, &vr[(i__ + 1) * vr_dim1 + 1], c__1);
		    scl = 1.0 / dlapy2(d__1, d__2);
		    dscal(n, scl, &vr[i__ * vr_dim1 + 1], c__1);
		    dscal(n, scl, &vr[(i__ + 1) * vr_dim1 + 1], c__1);
		    i__2 = n;
		    for (k = 1; k <= i__2; ++k) {
    /* Computing 2nd power */
		        d__1 = vr[k + i__ * vr_dim1];
    /* Computing 2nd power */
		        d__2 = vr[k + (i__ + 1) * vr_dim1];
		        work[k] = d__1 * d__1 + d__2 * d__2;
    /* L30: */
		    }
		    k = idamax(n, &work[1], c__1);
		    dlartg(vr[k + i__ * vr_dim1], vr[k + (i__ + 1) * vr_dim1], 
			    ref cs, ref sn, ref r__);
		    drot(n, &vr[i__ * vr_dim1 + 1], c__1, &vr[(i__ + 1) * 
			    vr_dim1 + 1], c__1, cs, sn);
		    vr[k + (i__ + 1) * vr_dim1] = 0.0;
	        }
    /* L40: */
	    }
        }

    /*     Undo scaling if necessary */

    L50:
        if (scalea) {
	    i__1 = n - info;
    /* Computing MAX */
	    i__3 = n - info;
	    i__2 = max(i__3,1);
	    dlascl('G', c__0, c__0, cscale, anrm, i__1, c__1, &wr[info + 
		    1], i__2, ref ierr);
	    i__1 = n - info;
    /* Computing MAX */
	    i__3 = n - info;
	    i__2 = max(i__3,1);
	    dlascl('G', c__0, c__0, cscale, anrm, i__1, c__1, &wi[info + 
		    1], i__2, ref ierr);
	    if (info == 0) {
	        if ((wntsnv || wntsnb) && icond == 0) {
		    dlascl('G', c__0, c__0, cscale, anrm, n, c__1, &rcondv[
			    1], n, ref ierr);
	        }
	    } else {
	        i__1 = ilo - 1;
	        dlascl('G', c__0, c__0, cscale, anrm, i__1, c__1, &wr[1], 
		        n, ref ierr);
	        i__1 = ilo - 1;
	        dlascl('G', c__0, c__0, cscale, anrm, i__1, c__1, &wi[1], 
		        n, ref ierr);
	    }
        }

        work[1] = (double) maxwrk;
        return 0;
    }
}

