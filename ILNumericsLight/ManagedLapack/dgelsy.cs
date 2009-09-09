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
    public static unsafe int dgelsy(int m, int n, int nrhs, double *a, int lda, double *b, int ldb,
        int* jpvt, double rcond, ref int rank, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__0 = 0;
        const double c_b31 = 0.0;
        const int c__2 = 2;
        const double c_b54 = 1.0;

        /* System generated locals */
        int a_dim1, a_offset, b_dim1, b_offset, i__1, i__2;
        double d__1, d__2;

        /* Local variables */
        int i__, j;
        double c1=0, c2=0, s1=0, s2=0;
        int nb, mn, nb1, nb2, nb3, nb4;
        double anrm, bnrm, smin, smax;
        int iascl, ibscl;
        int ismin, ismax;
        double wsize;
        double bignum;
        int lwkmin;
        double sminpr=0, smaxpr=0, smlnum;
        int lwkopt=0;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        b_dim1 = ldb;
        b_offset = 1 + b_dim1;
        b -= b_offset;
        --jpvt;
        --work;

        /* Function Body */
        mn = min(m,n);
        ismin = mn + 1;
        ismax = (mn << 1) + 1;

    /*     Test the input arguments. */

        info = 0;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (nrhs < 0) {
	    info = -3;
        } else if (lda < max(1,m)) {
	    info = -5;
        } else /* if(complicated condition) */ {
    /* Computing MAX */
	    i__1 = max(1,m);
	    if (ldb < max(i__1,n)) {
	        info = -7;
	    }
        }

    /*     Figure out optimal block size */

        if (info == 0) {
	    if (mn == 0 || nrhs == 0) {
	        lwkmin = 1;
	        lwkopt = 1;
	    } else {
	        nb1 = ilaenv(c__1, "DGEQRF", " ", m, n, c_n1, c_n1);
	        nb2 = ilaenv(c__1, "DGERQF", " ", m, n, c_n1, c_n1);
	        nb3 = ilaenv(c__1, "DORMQR", " ", m, n, nrhs, c_n1);
	        nb4 = ilaenv(c__1, "DORMRQ", " ", m, n, nrhs, c_n1);
    /* Computing MAX */
	        i__1 = max(nb1,nb2);
            i__1 = max(i__1,nb3);
	        nb = max(i__1,nb4);
    /* Computing MAX */
	        i__1 = mn << 1;
            i__2 = n + 1;
            i__1 = max(i__1,i__2);
            i__2 = mn + nrhs;
	        lwkmin = mn + max(i__1,i__2);
    /* Computing MAX */
	        i__1 = lwkmin;
            i__2 = mn + (n << 1) + nb * (n + 1);
            i__1 = max(i__1,i__2);
            i__2 = (mn << 1) + nb * nrhs;
	        lwkopt = max(i__1,i__2);
	    }
	    work[1] = (double) lwkopt;

	    if (lwork < lwkmin && ! lquery) {
	        info = -12;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGELSY", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (mn == 0 || nrhs == 0) {
	    rank = 0;
	    return 0;
        }

    /*     Get machine parameters */

        smlnum = dlamch('S') / dlamch('P');
        bignum = 1.0 / smlnum;
        dlabad(ref smlnum, ref bignum);

    /*     Scale A, B if max entries outside range [SMLNUM,BIGNUM] */

        anrm = dlange('M', m, n, &a[a_offset], lda, &work[1]);
        iascl = 0;
        if (anrm > 0.0 && anrm < smlnum) {

    /*        Scale matrix norm up to SMLNUM */

	    dlascl('G', c__0, c__0, anrm, smlnum, m, n, &a[a_offset], lda, 
		    ref info);
	    iascl = 1;
        } else if (anrm > bignum) {

    /*        Scale matrix norm down to BIGNUM */

	    dlascl('G', c__0, c__0, anrm, bignum, m, n, &a[a_offset], lda, 
		    ref info);
	    iascl = 2;
        } else if (anrm == 0.0) {

    /*        Matrix all zero. Return zero solution. */

	    i__1 = max(m,n);
	    dlaset('F', i__1, nrhs, c_b31, c_b31, &b[b_offset], ldb);
	    rank = 0;
	    goto L70;
        }

        bnrm = dlange('M', m, nrhs, &b[b_offset], ldb, &work[1]);
        ibscl = 0;
        if (bnrm > 0.0 && bnrm < smlnum) {

    /*        Scale matrix norm up to SMLNUM */

	    dlascl('G', c__0, c__0, bnrm, smlnum, m, nrhs, &b[b_offset], ldb, 
		     ref info);
	    ibscl = 1;
        } else if (bnrm > bignum) {

    /*        Scale matrix norm down to BIGNUM */

	    dlascl('G', c__0, c__0, bnrm, bignum, m, nrhs, &b[b_offset], ldb, 
		     ref info);
	    ibscl = 2;
        }

    /*     Compute QR factorization with column pivoting of A: */
    /*        A * P = Q * R */

        i__1 = lwork - mn;
        dgeqp3(m, n, &a[a_offset], lda, &jpvt[1], &work[1], &work[mn + 1], i__1, 
	         ref info);
        wsize = mn + work[mn + 1];

    /*     workspace: MN+2n+NB*(N+1). */
    /*     Details of Householder rotations stored in WORK(1:MN). */

    /*     Determine RANK using incremental condition estimation */

        work[ismin] = 1.0;
        work[ismax] = 1.0;
        d__1 = a[a_dim1 + 1];
        smax = ( abs(d__1));
        smin = smax;
        if ((abs(a[a_dim1 + 1])) == 0.0) {
	    rank = 0;
	    i__1 = max(m,n);
	    dlaset('F', i__1, nrhs, c_b31, c_b31, &b[b_offset], ldb);
	    goto L70;
        } else {
	    rank = 1;
        }

    L10:
        if (rank < mn) {
	    i__ = rank + 1;
	    dlaic1(c__2, rank, &work[ismin], smin, &a[i__ * a_dim1 + 1], a[
		    i__ + i__ * a_dim1], ref sminpr, ref s1, ref c1);
	    dlaic1(c__1, rank, &work[ismax], smax, &a[i__ * a_dim1 + 1], a[
		    i__ + i__ * a_dim1], ref smaxpr, ref s2, ref c2);

	    if (smaxpr * rcond <= sminpr) {
	        i__1 = rank;
	        for (i__ = 1; i__ <= i__1; ++i__) {
		    work[ismin + i__ - 1] = s1 * work[ismin + i__ - 1];
		    work[ismax + i__ - 1] = s2 * work[ismax + i__ - 1];
    /* L20: */
	        }
	        work[ismin + rank] = c1;
	        work[ismax + rank] = c2;
	        smin = sminpr;
	        smax = smaxpr;
	        ++(rank);
	        goto L10;
	    }
        }

    /*     workspace: 3*MN. */

    /*     Logically partition R = [ R11 R12 ] */
    /*                             [  0  R22 ] */
    /*     where R11 = R(1:RANK,1:RANK) */

    /*     [R11,R12] = [ T11, 0 ] * Y */

        if (rank < n) {
	    i__1 = lwork - (mn << 1);
	    dtzrzf(rank, n, &a[a_offset], lda, &work[mn + 1], &work[(mn << 1) + 
		    1], i__1, ref info);
        }

    /*     workspace: 2*MN. */
    /*     Details of Householder rotations stored in WORK(MN+1:2*MN) */

    /*     B(1:M,1:NRHS) := Q' * B(1:M,1:NRHS) */

        i__1 = lwork - (mn << 1);
        dormqr('L', 'T', m, nrhs, mn, &a[a_offset], lda, &work[1], &
	        b[b_offset], ldb, &work[(mn << 1) + 1], i__1, ref info);
    /* Computing MAX */
        d__1 = wsize;
        d__2 = (mn << 1) + work[(mn << 1) + 1];
        wsize = max(d__1,d__2);

    /*     workspace: 2*MN+NBnrhs. */

    /*     B(1:RANK,1:NRHS) := inv(T11) * B(1:RANK,1:NRHS) */

        dtrsm('L', 'U', 'N', 'N', rank, nrhs, c_b54, &
	        a[a_offset], lda, &b[b_offset], ldb);

        i__1 = nrhs;
        for (j = 1; j <= i__1; ++j) {
	    i__2 = n;
	    for (i__ = rank + 1; i__ <= i__2; ++i__) {
	        b[i__ + j * b_dim1] = 0.0;
    /* L30: */
	    }
    /* L40: */
        }

    /*     B(1:N,1:NRHS) := Y' * B(1:N,1:NRHS) */

        if (rank < n) {
	    i__1 = n - rank;
	    i__2 = lwork - (mn << 1);
	    dormrz('L', 'T', n, nrhs, rank, i__1, &a[a_offset], lda, 
		    &work[mn + 1], &b[b_offset], ldb, &work[(mn << 1) + 1], i__2, 
		     ref info);
        }

    /*     workspace: 2*MN+NRHS. */

    /*     B(1:N,1:NRHS) := P * B(1:N,1:NRHS) */

        i__1 = nrhs;
        for (j = 1; j <= i__1; ++j) {
	    i__2 = n;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        work[jpvt[i__]] = b[i__ + j * b_dim1];
    /* L50: */
	    }
	    dcopy(n, &work[1], c__1, &b[j * b_dim1 + 1], c__1);
    /* L60: */
        }

    /*     workspace: N. */

    /*     Undo scaling */

        if (iascl == 1) {
	    dlascl('G', c__0, c__0, anrm, smlnum, n, nrhs, &b[b_offset], ldb, 
		     ref info);
	    dlascl('U', c__0, c__0, smlnum, anrm, rank, rank, &a[a_offset], 
		    lda, ref info);
        } else if (iascl == 2) {
	    dlascl('G', c__0, c__0, anrm, bignum, n, nrhs, &b[b_offset], ldb, 
		     ref info);
	    dlascl('U', c__0, c__0, bignum, anrm, rank, rank, &a[a_offset], 
		    lda, ref info);
        }
        if (ibscl == 1) {
	    dlascl('G', c__0, c__0, smlnum, bnrm, n, nrhs, &b[b_offset], ldb, 
		     ref info);
        } else if (ibscl == 2) {
	    dlascl('G', c__0, c__0, bignum, bnrm, n, nrhs, &b[b_offset], ldb, 
		     ref info);
        }

    L70:
        work[1] = (double) lwkopt;

        return 0;
    } 
}

