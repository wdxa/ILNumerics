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
    public static unsafe int dgesdd(char jobz, int m, int n, double * a, int lda, double *s,
        double *u, int ldu, double *vt, int ldvt, double *work, int lwork, int *iwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__0 = 0;
        const double c_b227 = 0.00;
        const double c_b248 = 1.00;

        /* System generated locals */
        int a_dim1, a_offset, u_dim1, u_offset, vt_dim1, vt_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, ie, il=0, ir=0, iu, blk;
        double* dum = stackalloc double[1];
        double eps;
        int ivt, iscl;
        double anrm;
        int* idum = stackalloc int[1];
        int ierr=0, itau;
        int chunk=0, minmn, wrkbl, itaup, itauq, mnthr=0;
        bool wntqa;
        int nwork;
        bool wntqn, wntqo, wntqs;
        int bdspac=0;
        double bignum;
        int ldwrkl, ldwrkr=0, minwrk, ldwrku, maxwrk=0, ldwkvt;
        double smlnum;
        bool wntqas, lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --s;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        --work;
        --iwork;

        /* Function Body */
        info = 0;
        minmn = min(m,n);
        wntqa = lsame(jobz, 'A');
        wntqs = lsame(jobz, 'S');
        wntqas = wntqa || wntqs;
        wntqo = lsame(jobz, 'O');
        wntqn = lsame(jobz, 'N');
        lquery = lwork == -1;

        if (! (wntqa || wntqs || wntqo || wntqn)) {
	    info = -1;
        } else if (m < 0) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (lda < max(1,m)) {
	    info = -5;
        } else if (ldu < 1 || wntqas && ldu < m || wntqo && m < n && ldu < 
	        m) {
	    info = -8;
        } else if (ldvt < 1 || wntqa && ldvt < n || wntqs && ldvt < minmn || 
	        wntqo && m >= n && ldvt < n) {
	    info = -10;
        }

    /*     Compute workspace */
    /*      (Note: Comments in the code beginning "Workspace:" describe the */
    /*       minimal amount of workspace needed at that point in the code, */
    /*       as well as the preferred amount for good performance. */
    /*       NB refers to the optimal block size for the immediately */
    /*       following subroutine, as returned by ILAENV.) */

        if (info == 0) {
	    minwrk = 1;
	    maxwrk = 1;
	    if (m >= n && minmn > 0) {

    /*           Compute space needed for DBDSDC */

	        mnthr = (int) (minmn * 11.0 / 6.0);
	        if (wntqn) {
		    bdspac = n * 7;
	        } else {
		    bdspac = n * 3 * n + (n << 2);
	        }
	        if (m >= mnthr) {
		    if (wntqn) {

    /*                 Path 1 (M much larger than N, JOBZ='N') */

		        wrkbl = n + n * ilaenv(c__1, "DGEQRF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + (n << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", n, n, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n;
		        maxwrk = max(i__1,i__2);
		        minwrk = bdspac + n;
		    } else if (wntqo) {

    /*                 Path 2 (M much larger than N, JOBZ='O') */

		        wrkbl = n + n * ilaenv(c__1, "DGEQRF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n + n * ilaenv(c__1, "DORGQR", 
			        " ", m, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + (n << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", n, n, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "QLN", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + (n << 1) * n;
		        minwrk = bdspac + (n << 1) * n + n * 3;
		    } else if (wntqs) {

    /*                 Path 3 (M much larger than N, JOBZ='S') */

		        wrkbl = n + n * ilaenv(c__1, "DGEQRF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n + n * ilaenv(c__1, "DORGQR", 
			        " ", m, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + (n << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", n, n, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "QLN", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + n * n;
		        minwrk = bdspac + n * n + n * 3;
		    } else if (wntqa) {

    /*                 Path 4 (M much larger than N, JOBZ='A') */

		        wrkbl = n + n * ilaenv(c__1, "DGEQRF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n + m * ilaenv(c__1, "DORGQR", 
			        " ", m, m, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + (n << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", n, n, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "QLN", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + n * n;
		        minwrk = bdspac + n * n + n * 3;
		    }
	        } else {

    /*              Path 5 (M at least N, but not much larger) */

		    wrkbl = n * 3 + (m + n) * ilaenv(c__1, "DGEBRD", " ", m, 
			    n, c_n1, c_n1);
		    if (wntqn) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = n * 3 + max(m,bdspac);
		    } else if (wntqo) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "QLN", m, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + m * n;
    /* Computing MAX */
		        i__1 = m; i__2 = n * n + bdspac;
		        minwrk = n * 3 + max(i__1,i__2);
		    } else if (wntqs) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "QLN", m, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + n * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = n * 3 + max(m,bdspac);
		    } else if (wntqa) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = n * 3 + n * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = maxwrk; i__2 = bdspac + n * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = n * 3 + max(m,bdspac);
		    }
	        }
	    } else if (minmn > 0) {

    /*           Compute space needed for DBDSDC */

	        mnthr = (int) (minmn * 11.0 / 6.0);
	        if (wntqn) {
		    bdspac = m * 7;
	        } else {
		    bdspac = m * 3 * m + (m << 2);
	        }
	        if (n >= mnthr) {
		    if (wntqn) {

    /*                 Path 1t (N much larger than M, JOBZ='N') */

		        wrkbl = m + m * ilaenv(c__1, "DGELQF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + (m << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", m, m, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m;
		        maxwrk = max(i__1,i__2);
		        minwrk = bdspac + m;
		    } else if (wntqo) {

    /*                 Path 2t (N much larger than M, JOBZ='O') */

		        wrkbl = m + m * ilaenv(c__1, "DGELQF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m + m * ilaenv(c__1, "DORGLQ", 
			        " ", m, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + (m << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", m, m, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + (m << 1) * m;
		        minwrk = bdspac + (m << 1) * m + m * 3;
		    } else if (wntqs) {

    /*                 Path 3t (N much larger than M, JOBZ='S') */

		        wrkbl = m + m * ilaenv(c__1, "DGELQF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m + m * ilaenv(c__1, "DORGLQ", 
			        " ", m, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + (m << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", m, m, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + m * m;
		        minwrk = bdspac + m * m + m * 3;
		    } else if (wntqa) {

    /*                 Path 4t (N much larger than M, JOBZ='A') */

		        wrkbl = m + m * ilaenv(c__1, "DGELQF", " ", m, n, 
			        c_n1, c_n1);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m + n * ilaenv(c__1, "DORGLQ", 
			        " ", n, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + (m << 1) * ilaenv(c__1, 
			        "DGEBRD", " ", m, m, c_n1, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", m, m, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + m * m;
		        minwrk = bdspac + m * m + m * 3;
		    }
	        } else {

    /*              Path 5t (N greater than M, but not much larger) */

		    wrkbl = m * 3 + (m + n) * ilaenv(c__1, "DGEBRD", " ", m, 
			    n, c_n1, c_n1);
		    if (wntqn) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = m * 3 + max(n,bdspac);
		    } else if (wntqo) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", m, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        wrkbl = max(i__1,i__2);
		        maxwrk = wrkbl + m * n;
    /* Computing MAX */
		        i__1 = n; i__2 = m * m + bdspac;
		        minwrk = m * 3 + max(i__1,i__2);
		    } else if (wntqs) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", m, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = m * 3 + max(n,bdspac);
		    } else if (wntqa) {
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "QLN", m, m, n, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = m * 3 + m * ilaenv(c__1, "DORMBR"
    , "PRT", n, n, m, c_n1);
		        wrkbl = max(i__1,i__2);
    /* Computing MAX */
		        i__1 = wrkbl; i__2 = bdspac + m * 3;
		        maxwrk = max(i__1,i__2);
		        minwrk = m * 3 + max(n,bdspac);
		    }
	        }
	    }
	    maxwrk = max(maxwrk,minwrk);
	    work[1] = (double) maxwrk;

	    if (lwork < minwrk && ! lquery) {
	        info = -12;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGESDD", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    return 0;
        }

    /*     Get machine constants */

        eps = dlamch('P');
        smlnum = sqrt(dlamch('S')) / eps;
        bignum = 1.0 / smlnum;

    /*     Scale A if max element outside range [SMLNUM,BIGNUM] */

        anrm = dlange('M', m, n, &a[a_offset], lda, dum);
        iscl = 0;
        if (anrm > 0.0 && anrm < smlnum) {
	    iscl = 1;
	    dlascl('G', c__0, c__0, anrm, smlnum, m, n, &a[a_offset], lda, 
		   ref ierr);
        } else if (anrm > bignum) {
	    iscl = 1;
	    dlascl('G', c__0, c__0, anrm, bignum, m, n, &a[a_offset], lda, 
		    ref ierr);
        }

        if (m >= n) {

    /*        A has at least as many rows as columns. If A has sufficiently */
    /*        more rows than columns, first reduce using the QR */
    /*        decomposition (if sufficient workspace available) */

	    if (m >= mnthr) {

	        if (wntqn) {

    /*              Path 1 (M much larger than N, JOBZ='N') */
    /*              No singular vectors to be computed */

		    itau = 1;
		    nwork = itau + n;

    /*              Compute A=Q*R */
    /*              (Workspace: need 2n, prefer N+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dgeqrf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__1, ref ierr);

    /*              Zero out below R */

		    i__1 = n - 1;
		    i__2 = n - 1;
		    dlaset('L', i__1, i__2, c_b227, c_b227, &a[a_dim1 + 2], 
			    lda);
		    ie = 1;
		    itauq = ie + n;
		    itaup = itauq + n;
		    nwork = itaup + n;

    /*              Bidiagonalize R in A */
    /*              (Workspace: need 4n, prefer 3n+2n*NB) */

		    i__1 = lwork - nwork + 1;
		    dgebrd(n, n, &a[a_offset], lda, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__1, ref ierr);
		    nwork = ie + n;

    /*              Perform bidiagonal SVD, computing singular values only */
    /*              (Workspace: need N+BDSPAC) */

		    dbdsdc('U', 'N', n, &s[1], &work[ie], dum, c__1, dum, c__1, 
			     dum, idum, &work[nwork], &iwork[1], ref info);

	        } else if (wntqo) {

    /*              Path 2 (M much larger than N, JOBZ = 'O') */
    /*              N left singular vectors to be overwritten on A and */
    /*              N right singular vectors to be computed in VT */

		    ir = 1;

    /*              WORK(IR) is LDWRKR by N */

		    if (lwork >= lda * n + n * n + n * 3 + bdspac) {
		        ldwrkr = lda;
		    } else {
		        ldwrkr = (lwork - n * n - n * 3 - bdspac) / n;
		    }
		    itau = ir + ldwrkr * n;
		    nwork = itau + n;

    /*              Compute A=Q*R */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dgeqrf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__1, ref ierr);

    /*              Copy R to WORK(IR), zeroing out below it */

		    dlacpy('U', n, n, &a[a_offset], lda, &work[ir], ldwrkr);
		    i__1 = n - 1;
		    i__2 = n - 1;
		    dlaset('L', i__1, i__2, c_b227, c_b227, &work[ir + 1], 
			    ldwrkr);

    /*              Generate Q in A */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dorgqr(m, n, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			     i__1, ref ierr);
		    ie = itau;
		    itauq = ie + n;
		    itaup = itauq + n;
		    nwork = itaup + n;

    /*              Bidiagonalize R in VT, copying result to WORK(IR) */
    /*              (Workspace: need Nn+4n, prefer Nn+3n+2n*NB) */

		    i__1 = lwork - nwork + 1;
		    dgebrd(n, n, &work[ir], ldwrkr, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__1, ref ierr);

    /*              WORK(IU) is N by N */

		    iu = nwork;
		    nwork = iu + n * n;

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in WORK(IU) and computing right */
    /*              singular vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+Nn+BDSPAC) */

		    dbdsdc('U', 'I', n, &s[1], &work[ie], &work[iu], n, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Overwrite WORK(IU) by left singular vectors of R */
    /*              and VT by right singular vectors of R */
    /*              (Workspace: need 2nn+3n, prefer 2nn+2n+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', n, n, n, &work[ir], ldwrkr, &work[
			    itauq], &work[iu], n, &work[nwork], i__1, ref ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, n, &work[ir], ldwrkr, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__1, 
			   ref ierr);

    /*              Multiply Q in A by left singular vectors of R in */
    /*              WORK(IU), storing result in WORK(IR) and copying to A */
    /*              (Workspace: need 2nn, prefer Nn+Mn) */

		    i__1 = m;
		    i__2 = ldwrkr;
		    for (i__ = 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += 
			    i__2) {
    /* Computing MIN */
		        i__3 = m - i__ + 1;
		        chunk = min(i__3,ldwrkr);
		        dgemm('N', 'N', chunk, n, n, c_b248, &a[i__ + a_dim1], 
			        lda, &work[iu], n, c_b227, &work[ir], ldwrkr);
		        dlacpy('F', chunk, n, &work[ir], ldwrkr, &a[i__ + 
			        a_dim1], lda);
    /* L10: */
		    }

	        } else if (wntqs) {

    /*              Path 3 (M much larger than N, JOBZ='S') */
    /*              N left singular vectors to be computed in U and */
    /*              N right singular vectors to be computed in VT */

		    ir = 1;

    /*              WORK(IR) is N by N */

		    ldwrkr = n;
		    itau = ir + ldwrkr * n;
		    nwork = itau + n;

    /*              Compute A=Q*R */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dgeqrf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__2, ref ierr);

    /*              Copy R to WORK(IR), zeroing out below it */

		    dlacpy('U', n, n, &a[a_offset], lda, &work[ir], ldwrkr);
		    i__2 = n - 1;
		    i__1 = n - 1;
		    dlaset('L', i__2, i__1, c_b227, c_b227, &work[ir + 1], 
			    ldwrkr);

    /*              Generate Q in A */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dorgqr(m, n, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			     i__2, ref ierr);
		    ie = itau;
		    itauq = ie + n;
		    itaup = itauq + n;
		    nwork = itaup + n;

    /*              Bidiagonalize R in WORK(IR) */
    /*              (Workspace: need Nn+4n, prefer Nn+3n+2n*NB) */

		    i__2 = lwork - nwork + 1;
		    dgebrd(n, n, &work[ir], ldwrkr, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__2, ref ierr);

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagoal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+BDSPAC) */

		    dbdsdc('U', 'I', n, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			   ref info);

    /*              Overwrite U by left singular vectors of R and VT */
    /*              by right singular vectors of R */
    /*              (Workspace: need Nn+3n, prefer Nn+2n+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', n, n, n, &work[ir], ldwrkr, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__2, ref ierr);

		    i__2 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, n, &work[ir], ldwrkr, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__2, 
			    ref ierr);

    /*              Multiply Q in A by left singular vectors of R in */
    /*              WORK(IR), storing result in U */
    /*              (Workspace: need Nn) */

		    dlacpy('F', n, n, &u[u_offset], ldu, &work[ir], ldwrkr);
		    dgemm('N', 'N', m, n, n, c_b248, &a[a_offset], lda, &work[
			    ir], ldwrkr, c_b227, &u[u_offset], ldu);

	        } else if (wntqa) {

    /*              Path 4 (M much larger than N, JOBZ='A') */
    /*              M left singular vectors to be computed in U and */
    /*              N right singular vectors to be computed in VT */

		    iu = 1;

    /*              WORK(IU) is N by N */

		    ldwrku = n;
		    itau = iu + ldwrku * n;
		    nwork = itau + n;

    /*              Compute A=Q*R, copying result to U */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dgeqrf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__2, ref ierr);
		    dlacpy('L', m, n, &a[a_offset], lda, &u[u_offset], ldu);

    /*              Generate Q in U */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */
		    i__2 = lwork - nwork + 1;
		    dorgqr(m, m, n, &u[u_offset], ldu, &work[itau], &work[nwork], 
			    i__2, ref ierr);

    /*              Produce R in A, zeroing out other entries */

		    i__2 = n - 1;
		    i__1 = n - 1;
		    dlaset('L',i__2, i__1, c_b227, c_b227, &a[a_dim1 + 2], 
			    lda);
		    ie = itau;
		    itauq = ie + n;
		    itaup = itauq + n;
		    nwork = itaup + n;

    /*              Bidiagonalize R in A */
    /*              (Workspace: need Nn+4n, prefer Nn+3n+2n*NB) */

		    i__2 = lwork - nwork + 1;
		    dgebrd(n, n, &a[a_offset], lda, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__2, ref ierr);

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in WORK(IU) and computing right */
    /*              singular vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+Nn+BDSPAC) */

		    dbdsdc('U', 'I', n, &s[1], &work[ie], &work[iu], n, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			   ref info);

    /*              Overwrite WORK(IU) by left singular vectors of R and VT */
    /*              by right singular vectors of R */
    /*              (Workspace: need Nn+3n, prefer Nn+2n+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', n, n, n, &a[a_offset], lda, &work[
			    itauq], &work[iu], ldwrku, &work[nwork], i__2, 
			    ref ierr);
		    i__2 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, n, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__2, 
			    ref ierr);

    /*              Multiply Q in U by left singular vectors of R in */
    /*              WORK(IU), storing result in A */
    /*              (Workspace: need Nn) */

		    dgemm('N', 'N', m, n, n, c_b248, &u[u_offset], ldu, &work[
			    iu], ldwrku, c_b227, &a[a_offset], lda);

    /*              Copy left singular vectors of A from A to U */

		    dlacpy('F', m, n, &a[a_offset], lda, &u[u_offset], ldu);

	        }

	    } else {

    /*           M .LT. MNTHR */

    /*           Path 5 (M at least N, but not much larger) */
    /*           Reduce to bidiagonal form without QR decomposition */

	        ie = 1;
	        itauq = ie + n;
	        itaup = itauq + n;
	        nwork = itaup + n;

    /*           Bidiagonalize A */
    /*           (Workspace: need 3n+M, prefer 3n+(M+N)*NB) */

	        i__2 = lwork - nwork + 1;
	        dgebrd(m, n, &a[a_offset], lda, &s[1], &work[ie], &work[itauq], &
		        work[itaup], &work[nwork], i__2, ref ierr);
	        if (wntqn) {

    /*              Perform bidiagonal SVD, only computing singular values */
    /*              (Workspace: need N+BDSPAC) */

		    dbdsdc('U', 'N', n, &s[1], &work[ie], dum, c__1, dum, c__1, 
			     dum, idum, &work[nwork], &iwork[1], ref info);
	        } else if (wntqo) {
		    iu = nwork;
		    if (lwork >= m * n + n * 3 + bdspac) {

    /*                 WORK( IU ) is M by N */

		        ldwrku = m;
		        nwork = iu + ldwrku * n;
		        dlaset('F', m, n, c_b227, c_b227, &work[iu], ldwrku);
		    } else {

    /*                 WORK( IU ) is N by N */

		        ldwrku = n;
		        nwork = iu + ldwrku * n;

    /*                 WORK(IR) is LDWRKR by N */

		        ir = nwork;
		        ldwrkr = (lwork - n * n - n * 3) / n;
		    }
		    nwork = iu + ldwrku * n;

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in WORK(IU) and computing right */
    /*              singular vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+Nn+BDSPAC) */

		    dbdsdc('U', 'I', n, &s[1], &work[ie], &work[iu], ldwrku, &
			    vt[vt_offset], ldvt, dum, idum, &work[nwork], &iwork[
			    1], ref info);

    /*              Overwrite VT by right singular vectors of A */
    /*              (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, n, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__2, 
			   ref ierr);

		    if (lwork >= m * n + n * 3 + bdspac) {

    /*                 Overwrite WORK(IU) by left singular vectors of A */
    /*                 (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		        i__2 = lwork - nwork + 1;
		        dormbr('Q', 'L', 'N', m, n, n, &a[a_offset], lda, &work[
			        itauq], &work[iu], ldwrku, &work[nwork],i__2, 
			       ref ierr);

    /*                 Copy left singular vectors of A from WORK(IU) to A */

		        dlacpy('F', m, n, &work[iu], ldwrku, &a[a_offset], lda);
		    } else {

    /*                 Generate Q in A */
    /*                 (Workspace: need Nn+2n, prefer Nn+N+N*NB) */

		        i__2 = lwork - nwork + 1;
		        dorgbr('Q', m, n, n, &a[a_offset], lda, &work[itauq], &
			        work[nwork], i__2, ref ierr);

    /*                 Multiply Q in A by left singular vectors of */
    /*                 bidiagonal matrix in WORK(IU), storing result in */
    /*                 WORK(IR) and copying to A */
    /*                 (Workspace: need 2nn, prefer Nn+Mn) */

		        i__2 = m;
		        i__1 = ldwrkr;
		        for (i__ = 1; i__1 < 0 ? i__ >= i__2 : i__ <= i__2; i__ +=
			         i__1) {
    /* Computing MIN */
			    i__3 = m - i__ + 1;
			    chunk = min(i__3,ldwrkr);
			    dgemm('N', 'N', chunk, n, n, c_b248, &a[i__ + 
				    a_dim1], lda, &work[iu], ldwrku, c_b227, &
				    work[ir], ldwrkr);
			    dlacpy('F', chunk, n, &work[ir], ldwrkr, &a[i__ + 
				    a_dim1], lda);
    /* L20: */
		        }
		    }

	        } else if (wntqs) {

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+BDSPAC) */

		    dlaset('F', m, n, c_b227, c_b227, &u[u_offset], ldu);
		    dbdsdc('U', 'I', n, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Overwrite U by left singular vectors of A and VT */
    /*              by right singular vectors of A */
    /*              (Workspace: need 3n, prefer 2n+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, n, n, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__1, ref ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, n, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__1, 
			    ref ierr);
	        } else if (wntqa) {

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need N+BDSPAC) */

		    dlaset('F', m, m, c_b227, c_b227, &u[u_offset], ldu);
		    dbdsdc('U', 'I', n, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Set the right corner of U to identity matrix */

		    if (m > n) {
		        i__1 = m - n;
		        i__2 = m - n;
		        dlaset('F', i__1, i__2, c_b227, c_b248, &u[n + 1 + (
			        n + 1) * u_dim1], ldu);
		    }

    /*              Overwrite U by left singular vectors of A and VT */
    /*              by right singular vectors of A */
    /*              (Workspace: need Nn+2n+M, prefer Nn+2n+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, n, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__1, ref ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, m, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__1, 
			   ref ierr);
	        }

	    }

        } else {

    /*        A has more columns than rows. If A has sufficiently more */
    /*        columns than rows, first reduce using the LQ decomposition (if */
    /*        sufficient workspace available) */

	    if (n >= mnthr) {

	        if (wntqn) {

    /*              Path 1t (N much larger than M, JOBZ='N') */
    /*              No singular vectors to be computed */

		    itau = 1;
		    nwork = itau + m;

    /*              Compute A=L*Q */
    /*              (Workspace: need 2m, prefer M+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dgelqf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__1, ref ierr);

    /*              Zero out above L */

		    i__1 = m - 1;
		    i__2 = m - 1;
		    dlaset('U', i__1, i__2, c_b227, c_b227, &a[(a_dim1 << 1) 
			    + 1], lda);
		    ie = 1;
		    itauq = ie + m;
		    itaup = itauq + m;
		    nwork = itaup + m;

    /*              Bidiagonalize L in A */
    /*              (Workspace: need 4m, prefer 3m+2m*NB) */

		    i__1 = lwork - nwork + 1;
		    dgebrd(m, m, &a[a_offset], lda, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__1, ref ierr);
		    nwork = ie + m;

    /*              Perform bidiagonal SVD, computing singular values only */
    /*              (Workspace: need M+BDSPAC) */

		    dbdsdc('U', 'N', m, &s[1], &work[ie], dum, c__1, dum, c__1, 
			     dum, idum, &work[nwork], &iwork[1], ref info);

	        } else if (wntqo) {

    /*              Path 2t (N much larger than M, JOBZ='O') */
    /*              M right singular vectors to be overwritten on A and */
    /*              M left singular vectors to be computed in U */

		    ivt = 1;

    /*              IVT is M by M */

		    il = ivt + m * m;
		    if (lwork >= m * n + m * m + m * 3 + bdspac) {

    /*                 WORK(IL) is M by N */

		        ldwrkl = m;
		        chunk = n;
		    } else {
		        ldwrkl = m;
		        chunk = (lwork - m * m) / m;
		    }
		    itau = il + ldwrkl * m;
		    nwork = itau + m;

    /*              Compute A=L*Q */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dgelqf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__1, ref ierr);

    /*              Copy L to WORK(IL), zeroing about above it */

		    dlacpy('L', m, m, &a[a_offset], lda, &work[il], ldwrkl);
		    i__1 = m - 1;
		    i__2 = m - 1;
		    dlaset('U', i__1, i__2, c_b227, c_b227, &work[il + 
			    ldwrkl], ldwrkl);

    /*              Generate Q in A */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dorglq(m, n, m, &a[a_offset], lda, &work[itau], &work[nwork], 
			     i__1, ref ierr);
		    ie = itau;
		    itauq = ie + m;
		    itaup = itauq + m;
		    nwork = itaup + m;

    /*              Bidiagonalize L in WORK(IL) */
    /*              (Workspace: need Mm+4m, prefer Mm+3m+2m*NB) */

		    i__1 = lwork - nwork + 1;
		    dgebrd(m, m, &work[il], ldwrkl, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__1, ref ierr);

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U, and computing right singular */
    /*              vectors of bidiagonal matrix in WORK(IVT) */
    /*              (Workspace: need M+Mm+BDSPAC) */

		    dbdsdc('U', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &
			    work[ivt], m, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Overwrite U by left singular vectors of L and WORK(IVT) */
    /*              by right singular vectors of L */
    /*              (Workspace: need 2mm+3m, prefer 2mm+2m+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, m, &work[il], ldwrkl, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__1, ref ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', m, m, m, &work[il], ldwrkl, &work[
			    itaup], &work[ivt], m, &work[nwork], i__1, ref ierr);

    /*              Multiply right singular vectors of L in WORK(IVT) by Q */
    /*              in A, storing result in WORK(IL) and copying to A */
    /*              (Workspace: need 2mm, prefer Mm+Mn) */

		    i__1 = n;
		    i__2 = chunk;
		    for (i__ = 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += 
			    i__2) {
    /* Computing MIN */
		        i__3 = n - i__ + 1;
		        blk = min(i__3,chunk);
		        dgemm('N', 'N', m, blk, m, c_b248, &work[ivt], m, &a[
			        i__ * a_dim1 + 1], lda, c_b227, &work[il], 
			        ldwrkl);
		        dlacpy('F', m, blk, &work[il], ldwrkl, &a[i__ * a_dim1 
			        + 1], lda);
    /* L30: */
		    }

	        } else if (wntqs) {

    /*              Path 3t (N much larger than M, JOBZ='S') */
    /*              M right singular vectors to be computed in VT and */
    /*              M left singular vectors to be computed in U */

		    il = 1;

    /*              WORK(IL) is M by M */

		    ldwrkl = m;
		    itau = il + ldwrkl * m;
		    nwork = itau + m;

    /*              Compute A=L*Q */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dgelqf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__2, ref ierr);

    /*              Copy L to WORK(IL), zeroing out above it */

		    dlacpy('L', m, m, &a[a_offset], lda, &work[il], ldwrkl);
		    i__2 = m - 1;
		    i__1 = m - 1;
		    dlaset('U', i__2, i__1, c_b227, c_b227, &work[il + 
			    ldwrkl], ldwrkl);

    /*              Generate Q in A */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dorglq(m, n, m, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__2, ref ierr);
		    ie = itau;
		    itauq = ie + m;
		    itaup = itauq + m;
		    nwork = itaup + m;

    /*              Bidiagonalize L in WORK(IU), copying result to U */
    /*              (Workspace: need Mm+4m, prefer Mm+3m+2m*NB) */

		    i__2 = lwork - nwork + 1;
		    dgebrd(m, m, &work[il],ldwrkl, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__2, ref ierr);

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need M+BDSPAC) */

		    dbdsdc('U', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Overwrite U by left singular vectors of L and VT */
    /*              by right singular vectors of L */
    /*              (Workspace: need Mm+3m, prefer Mm+2m+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, m, &work[il], ldwrkl, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__2, ref ierr);
		    i__2 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', m, m, m, &work[il], ldwrkl, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__2, 
			    ref ierr);

    /*              Multiply right singular vectors of L in WORK(IL) by */
    /*              Q in A, storing result in VT */
    /*              (Workspace: need Mm) */

		    dlacpy('F', m, m, &vt[vt_offset], ldvt, &work[il], ldwrkl);
		    dgemm('N', 'N', m, n, m, c_b248, &work[il], ldwrkl, &a[
			    a_offset], lda, c_b227, &vt[vt_offset], ldvt);

	        } else if (wntqa) {

    /*              Path 4t (N much larger than M, JOBZ='A') */
    /*              N right singular vectors to be computed in VT and */
    /*              M left singular vectors to be computed in U */

		    ivt = 1;

    /*              WORK(IVT) is M by M */

		    ldwkvt = m;
		    itau = ivt + ldwkvt * m;
		    nwork = itau + m;

    /*              Compute A=L*Q, copying result to VT */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dgelqf(m, n, &a[a_offset], lda, &work[itau], &work[nwork], 
			    i__2, ref ierr);
		    dlacpy('U', m, n, &a[a_offset], lda, &vt[vt_offset], ldvt);

    /*              Generate Q in VT */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dorglq(n, n, m, &vt[vt_offset], ldvt, &work[itau], &work[
			    nwork], i__2, ref ierr);

    /*              Produce L in A, zeroing out other entries */

		    i__2 = m - 1;
		    i__1 = m - 1;
		    dlaset('U', i__2, i__1, c_b227, c_b227, &a[(a_dim1 << 1) 
			    + 1], lda);
		    ie = itau;
		    itauq = ie + m;
		    itaup = itauq + m;
		    nwork = itaup + m;

    /*              Bidiagonalize L in A */
    /*              (Workspace: need Mm+4m, prefer Mm+3m+2m*NB) */

		    i__2 = lwork - nwork + 1;
		    dgebrd(m, m, &a[a_offset], lda, &s[1], &work[ie], &work[
			    itauq], &work[itaup], &work[nwork], i__2, ref ierr);

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in WORK(IVT) */
    /*              (Workspace: need M+Mm+BDSPAC) */

		    dbdsdc('U', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &
			    work[ivt], ldwkvt, dum, idum, &work[nwork], &iwork[1]
    , ref info);

    /*              Overwrite U by left singular vectors of L and WORK(IVT) */
    /*              by right singular vectors of L */
    /*              (Workspace: need Mm+3m, prefer Mm+2m+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, m, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__2,ref  ierr);
		    i__2 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', m, m, m, &a[a_offset], lda, &work[
			    itaup], &work[ivt], ldwkvt, &work[nwork], i__2, 
			    ref ierr);

    /*              Multiply right singular vectors of L in WORK(IVT) by */
    /*              Q in VT, storing result in A */
    /*              (Workspace: need Mm) */

		    dgemm('N', 'N', m, n, m, c_b248, &work[ivt], ldwkvt, &vt[
			    vt_offset], ldvt, c_b227, &a[a_offset], lda);

    /*              Copy right singular vectors of A from A to VT */

		    dlacpy('F', m, n, &a[a_offset], lda, &vt[vt_offset], ldvt);

	        }

	    } else {

    /*           N .LT. MNTHR */

    /*           Path 5t (N greater than M, but not much larger) */
    /*           Reduce to bidiagonal form without LQ decomposition */

	        ie = 1;
	        itauq = ie + m;
	        itaup = itauq + m;
	        nwork = itaup + m;

    /*           Bidiagonalize A */
    /*           (Workspace: need 3m+N, prefer 3m+(M+N)*NB) */

	        i__2 = lwork - nwork + 1;
	        dgebrd(m, n, &a[a_offset], lda, &s[1], &work[ie], &work[itauq], &
		        work[itaup], &work[nwork], i__2, ref ierr);
	        if (wntqn) {

    /*              Perform bidiagonal SVD, only computing singular values */
    /*              (Workspace: need M+BDSPAC) */

		    dbdsdc('L', 'N', m, &s[1], &work[ie], dum, c__1, dum, c__1, 
			     dum, idum, &work[nwork], &iwork[1], ref info);
	        } else if (wntqo) {
		    ldwkvt = m;
		    ivt = nwork;
		    if (lwork >= m * n + m * 3 + bdspac) {

    /*                 WORK( IVT ) is M by N */

		        dlaset('F', m, n, c_b227, c_b227, &work[ivt], ldwkvt);
		        nwork = ivt + ldwkvt * n;
		    } else {

    /*                 WORK( IVT ) is M by M */

		        nwork = ivt + ldwkvt * m;
		        il = nwork;

    /*                 WORK(IL) is M by CHUNK */

		        chunk = (lwork - m * m - m * 3) / m;
		    }

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in WORK(IVT) */
    /*              (Workspace: need Mm+BDSPAC) */

		    dbdsdc('L', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &
			    work[ivt], ldwkvt, dum, idum, &work[nwork], &iwork[1]
    , ref info);

    /*              Overwrite U by left singular vectors of A */
    /*              (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		    i__2 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, n, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__2, ref ierr);

		    if (lwork >= m * n + m * 3 + bdspac) {

    /*                 Overwrite WORK(IVT) by left singular vectors of A */
    /*                 (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		        i__2 = lwork - nwork + 1;
		        dormbr('P', 'R', 'T', m, n, m, &a[a_offset], lda, &work[
			        itaup], &work[ivt], ldwkvt, &work[nwork], i__2, 
			        ref ierr);

    /*                 Copy right singular vectors of A from WORK(IVT) to A */

		        dlacpy('F', m, n, &work[ivt], ldwkvt, &a[a_offset], lda);
		    } else {

    /*                 Generate P**T in A */
    /*                 (Workspace: need Mm+2m, prefer Mm+M+M*NB) */

		        i__2 = lwork - nwork + 1;
		        dorgbr('P', m, n, m, &a[a_offset], lda, &work[itaup], &
			        work[nwork], i__2, ref ierr);

    /*                 Multiply Q in A by right singular vectors of */
    /*                 bidiagonal matrix in WORK(IVT), storing result in */
    /*                 WORK(IL) and copying to A */
    /*                 (Workspace: need 2mm, prefer Mm+Mn) */

		        i__2 = n;
		        i__1 = chunk;
		        for (i__ = 1; i__1 < 0 ? i__ >= i__2 : i__ <= i__2; i__ +=
			         i__1) {
    /* Computing MIN */
			    i__3 = n - i__ + 1;
			    blk = min(i__3,chunk);
			    dgemm('N', 'N', m, blk, m, c_b248, &work[ivt], 
				    ldwkvt, &a[i__ * a_dim1 + 1], lda, c_b227, &
				    work[il], m);
			    dlacpy('F', m, blk, &work[il], m, &a[i__ * a_dim1 + 
				    1], lda);
    /* L40: */
		        }
		    }
	        } else if (wntqs) {

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need M+BDSPAC) */

		    dlaset('F', m, n, c_b227, c_b227, &vt[vt_offset], ldvt);
		    dbdsdc('L', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Overwrite U by left singular vectors of A and VT */
    /*              by right singular vectors of A */
    /*              (Workspace: need 3m, prefer 2m+M*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, n, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__1, ref ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', m, n, m, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__1, 
			    ref ierr);
	        } else if (wntqa) {

    /*              Perform bidiagonal SVD, computing left singular vectors */
    /*              of bidiagonal matrix in U and computing right singular */
    /*              vectors of bidiagonal matrix in VT */
    /*              (Workspace: need M+BDSPAC) */

		    dlaset('F', n, n, c_b227, c_b227, &vt[vt_offset], ldvt);
		    dbdsdc('L', 'I', m, &s[1], &work[ie], &u[u_offset], ldu, &vt[
			    vt_offset], ldvt, dum, idum, &work[nwork], &iwork[1], 
			    ref info);

    /*              Set the right corner of VT to identity matrix */

		    if (n > m) {
		        i__1 = n - m;
		        i__2 = n - m;
		        dlaset('F', i__1, i__2, c_b227, c_b248, &vt[m + 1 + 
			        (m + 1) * vt_dim1], ldvt);
		    }

    /*              Overwrite U by left singular vectors of A and VT */
    /*              by right singular vectors of A */
    /*              (Workspace: need 2m+N, prefer 2m+N*NB) */

		    i__1 = lwork - nwork + 1;
		    dormbr('Q', 'L', 'N', m, m, n, &a[a_offset], lda, &work[
			    itauq], &u[u_offset], ldu, &work[nwork], i__1,ref  ierr);
		    i__1 = lwork - nwork + 1;
		    dormbr('P', 'R', 'T', n, n, m, &a[a_offset], lda, &work[
			    itaup], &vt[vt_offset], ldvt, &work[nwork], i__1, 
			    ref ierr);
	        }

	    }

        }

    /*     Undo scaling if necessary */

        if (iscl == 1) {
	    if (anrm > bignum) {
	        dlascl('G', c__0, c__0, bignum, anrm, minmn, c__1, &s[1], 
		        minmn, ref ierr);
	    }
	    if (anrm < smlnum) {
	        dlascl('G', c__0, c__0, smlnum, anrm, minmn, c__1, &s[1], 
		        minmn, ref ierr);
	    }
        }

    /*     Return optimal workspace in WORK(1) */

        work[1] = (double) maxwrk;

        return 0;
    }
}

