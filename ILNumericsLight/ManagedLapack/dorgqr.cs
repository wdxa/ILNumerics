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
    public static unsafe int dorgqr(int m, int n, int k, double* a, int lda, double* tau, double* work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, j, l, ib, nb, ki=0, kk, nx, iws, nbmin, iinfo=0;
        int ldwork=0, lwkopt;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        nb = ilaenv(c__1, "DORGQR", " ", m, n, k, c_n1);
        lwkopt = max(1,n) * nb;
        work[1] = (double) lwkopt;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < 0 || n > m) {
	    info = -2;
        } else if (k < 0 || k > n) {
	    info = -3;
        } else if (lda < max(1,m)) {
	    info = -5;
        } else if (lwork < max(1,n) && ! lquery) {
	    info = -8;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORGQR", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (n <= 0) {
	    work[1] = 1.0;
	    return 0;
        }

        nbmin = 2;
        nx = 0;
        iws = n;
        if (nb > 1 && nb < k) {

    /*        Determine when to cross over from blocked to unblocked code. */

    /* Computing MAX */
	    i__1 = 0;
        i__2 = ilaenv(c__3, "DORGQR", " ", m, n, k, c_n1);
	    nx = max(i__1,i__2);
	    if (nx < k) {

    /*           Determine if workspace is large enough for blocked code. */

	        ldwork = n;
	        iws = ldwork * nb;
	        if (lwork < iws) {

    /*              Not enough workspace to use optimal NB:  reduce NB and */
    /*              determine the minimum value of NB. */

		    nb = lwork / ldwork;
    /* Computing MAX */
		    i__1 = 2;
            i__2 = ilaenv(c__2, "DORGQR", " ", m, n, k, c_n1);
		    nbmin = max(i__1,i__2);
	        }
	    }
        }

        if (nb >= nbmin && nb < k && nx < k) {

    /*        Use blocked code after the last block. */
    /*        The first kk columns are handled by the block method. */

	    ki = (k - nx - 1) / nb * nb;
    /* Computing MIN */
	    i__1 = k;
        i__2 = ki + nb;
	    kk = min(i__1,i__2);

    /*        Set A(1:kk,kk+1:n) to zero. */

	    i__1 = n;
	    for (j = kk + 1; j <= i__1; ++j) {
	        i__2 = kk;
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] = 0.0;
    /* L10: */
	        }
    /* L20: */
	    }
        } else {
	    kk = 0;
        }

    /*     Use unblocked code for the last or only block. */

        if (kk < n) {
	    i__1 = m - kk;
	    i__2 = n - kk;
	    i__3 = k - kk;
	    dorg2r(i__1, i__2, i__3, &a[kk + 1 + (kk + 1) * a_dim1], lda, &
		    tau[kk + 1], &work[1], ref iinfo);
        }

        if (kk > 0) {

    /*        Use blocked code */

	    i__1 = -nb;
	    for (i__ = ki + 1; i__1 < 0 ? i__ >= 1 : i__ <= 1; i__ += i__1) {
    /* Computing MIN */
	        i__2 = nb;
            i__3 = k - i__ + 1;
	        ib = min(i__2,i__3);
	        if (i__ + ib <= n) {

    /*              Form the triangular factor of the block reflector */
    /*              H = H(i) H(i+1) . . . H(i+ib-1) */

		    i__2 = m - i__ + 1;
		    dlarft('F', 'C', i__2, ib, &a[i__ + i__ * 
			    a_dim1], lda, &tau[i__], &work[1], ldwork);

    /*              Apply H to A(i:m,i+ib:n) from the left */

		    i__2 = m - i__ + 1;
		    i__3 = n - i__ - ib + 1;
		    dlarfb('L', 'N', 'F', 'C', 
			    i__2, i__3, ib, &a[i__ + i__ * a_dim1], lda, &work[
			    1], ldwork, &a[i__ + (i__ + ib) * a_dim1], lda, &
			    work[ib + 1], ldwork);
	        }

    /*           Apply H to rows i:m of current block */

	        i__2 = m - i__ + 1;
	        dorg2r(i__2, ib, ib, &a[i__ + i__ * a_dim1], lda, &tau[i__], &
		        work[1], ref iinfo);

    /*           Set rows 1:i-1 of current block to zero */

	        i__2 = i__ + ib - 1;
	        for (j = i__; j <= i__2; ++j) {
		    i__3 = i__ - 1;
		    for (l = 1; l <= i__3; ++l) {
		        a[l + j * a_dim1] = 0.0;
    /* L30: */
		    }
    /* L40: */
	        }
    /* L50: */
	    }
        }

        work[1] = (double) iws;
        return 0;
    } 
}

