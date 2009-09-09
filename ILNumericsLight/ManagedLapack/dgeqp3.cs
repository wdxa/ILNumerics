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
    public static unsafe int dgeqp3(int m, int n, double *a, int lda,
        int *jpvt, double *tau, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;

        /* Local variables */
        int j, jb, na, nb, sm, sn, nx, fjb=0, iws=0, nfxd;
        int nbmin, minmn=0;
        int minws;
        int topbmn, sminmn;
        int lwkopt;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --jpvt;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,m)) {
	    info = -4;
        }

        if (info == 0) {
	    minmn = min(m,n);
	    if (minmn == 0) {
	        iws = 1;
	        lwkopt = 1;
	    } else {
	        iws = n * 3 + 1;
	        nb = ilaenv(c__1, "DGEQRF", " ", m, n, c_n1, c_n1);
	        lwkopt = (n << 1) + (n + 1) * nb;
	    }
	    work[1] = (double) lwkopt;

	    if (lwork < iws && ! lquery) {
	        info = -8;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEQP3", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible. */

        if (minmn == 0) {
	    return 0;
        }

    /*     Move initial columns up front. */

        nfxd = 1;
        i__1 = n;
        for (j = 1; j <= i__1; ++j) {
	    if (jpvt[j] != 0) {
	        if (j != nfxd) {
		    dswap(m, &a[j * a_dim1 + 1], c__1, &a[nfxd * a_dim1 + 1], 
			    c__1);
		    jpvt[j] = jpvt[nfxd];
		    jpvt[nfxd] = j;
	        } else {
		    jpvt[j] = j;
	        }
	        ++nfxd;
	    } else {
	        jpvt[j] = j;
	    }
    /* L10: */
        }
        --nfxd;

    /*     Factorize fixed columns */
    /*     ======================= */

    /*     Compute the QR factorization of fixed columns and update */
    /*     remaining columns. */

        if (nfxd > 0) {
	    na = min(m,nfxd);
    /* CC      CALL DGEQR2( M, NA, A, LDA, TAU, WORK, INFO ) */
	    dgeqrf(m, na, &a[a_offset], lda, &tau[1], &work[1], lwork, ref info);
    /* Computing MAX */
	    i__1 = iws; i__2 = (int) work[1];
	    iws = max(i__1,i__2);
	    if (na < n) {
    /* CC         CALL DORM2R( 'Left', 'Transpose', M, N-NA, NA, A, LDA, */
    /* CC  $                   TAU, A( 1, NA+1 ), LDA, WORK, INFO ) */
	        i__1 = n - na;
	        dormqr('L', 'T', m, i__1, na, &a[a_offset], lda, &
		        tau[1], &a[(na + 1) * a_dim1 + 1], lda, &work[1], lwork, 
		        ref info);
    /* Computing MAX */
	        i__1 = iws; i__2 = (int) work[1];
	        iws = max(i__1,i__2);
	    }
        }

    /*     Factorize free columns */
    /*     ====================== */

        if (nfxd < minmn) {

	    sm = m - nfxd;
	    sn = n - nfxd;
	    sminmn = minmn - nfxd;

    /*        Determine the block size. */

	    nb = ilaenv(c__1, "DGEQRF", " ", sm, sn, c_n1, c_n1);
	    nbmin = 2;
	    nx = 0;

	    if (nb > 1 && nb < sminmn) {

    /*           Determine when to cross over from blocked to unblocked code. */

    /* Computing MAX */
	        i__1 = 0;
            i__2 = ilaenv(c__3, "DGEQRF", " ", sm, sn, c_n1, c_n1);
	        nx = max(i__1,i__2);


	        if (nx < sminmn) {

    /*              Determine if workspace is large enough for blocked code. */

		    minws = (sn << 1) + (sn + 1) * nb;
		    iws = max(iws,minws);
		    if (lwork < minws) {

    /*                 Not enough workspace to use optimal NB: Reduce NB and */
    /*                 determine the minimum value of NB. */

		        nb = (lwork - (sn << 1)) / (sn + 1);
    /* Computing MAX */
		        i__1 = 2;
                i__2 = ilaenv(c__2, "DGEQRF", " ", sm, sn, c_n1, c_n1);
		        nbmin = max(i__1,i__2);


		    }
	        }
	    }

    /*        Initialize partial column norms. The first N elements of work */
    /*        store the exact column norms. */

	    i__1 = n;
	    for (j = nfxd + 1; j <= i__1; ++j) {
	        work[j] = dnrm2(sm, &a[nfxd + 1 + j * a_dim1], c__1);
	        work[n + j] = work[j];
    /* L20: */
	    }

	    if (nb >= nbmin && nb < sminmn && nx < sminmn) {

    /*           Use blocked code initially. */

	        j = nfxd + 1;

    /*           Compute factorization: while loop. */


	        topbmn = minmn - nx;
    L30:
	        if (j <= topbmn) {
    /* Computing MIN */
            i__1 = nb; i__2 = topbmn - j + 1;
		    jb = min(i__1,i__2);

    /*              Factorize JB columns among columns J:N. */

		    i__1 = n - j + 1;
		    i__2 = j - 1;
		    i__3 = n - j + 1;
		    dlaqps(m, i__1, i__2, jb, ref fjb, &a[j * a_dim1 + 1], lda, &
			    jpvt[j], &tau[j], &work[j], &work[n + j], &work[(n 
			    << 1) + 1], &work[(n << 1) + jb + 1], i__3);

		    j += fjb;
		    goto L30;
	        }
	    } else {
	        j = nfxd + 1;
	    }

    /*        Use unblocked code to factor the last or only block. */


	    if (j <= minmn) {
	        i__1 = n - j + 1;
	        i__2 = j - 1;
	        dlaqp2(m, i__1, i__2, &a[j * a_dim1 + 1], lda, &jpvt[j], &tau[
		        j], &work[j], &work[n + j], &work[(n << 1) + 1]);
	    }

        }

        work[1] = (double) iws;
        return 0;
    } 
}

