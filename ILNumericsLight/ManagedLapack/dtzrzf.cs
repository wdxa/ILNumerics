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
    public static unsafe int dtzrzf(int m, int n, double* a, int lda, double* tau, double* work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;

         /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4, i__5;

        /* Local variables */
        int i__, m1, ib, nb=0, ki, kk, mu, nx, iws, nbmin;
        int ldwork=0, lwkopt=0;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < m) {
	    info = -2;
        } else if (lda < max(1,m)) {
	    info = -4;
        }

        if (info == 0) {
	    if (m == 0 || m == n) {
	        lwkopt = 1;
	    } else {

    /*           Determine the block size. */

	        nb = ilaenv(c__1, "DGERQF", " ", m, n, c_n1, c_n1);
	        lwkopt = m * nb;
	    }
	    work[1] = (double) lwkopt;

	    if (lwork < max(1,m) && ! lquery) {
	        info = -7;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DTZRZF", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0) {
	    return 0;
        } else if (m == n) {
	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        tau[i__] = 0.0;
    /* L10: */
	    }
	    return 0;
        }

        nbmin = 2;
        nx = 1;
        iws = m;
        if (nb > 1 && nb < m) {

    /*        Determine when to cross over from blocked to unblocked code. */

    /* Computing MAX */
	    i__1 = 0;
        i__2 = ilaenv(c__3, "DGERQF", " ", m, n, c_n1, c_n1);
	    nx = max(i__1,i__2);
	    if (nx < m) {

    /*           Determine if workspace is large enough for blocked code. */

	        ldwork = m;
	        iws = ldwork * nb;
	        if (lwork < iws) {

    /*              Not enough workspace to use optimal NB:  reduce NB and */
    /*              determine the minimum value of NB. */

		    nb = lwork / ldwork;
    /* Computing MAX */
		    i__1 = 2;
            i__2 = ilaenv(c__2, "DGERQF", " ", m, n, c_n1, c_n1);
		    nbmin = max(i__1,i__2);
	        }
	    }
        }

        if (nb >= nbmin && nb < m && nx < m) {

    /*        Use blocked code initially. */
    /*        The last kk rows are handled by the block method. */

    /* Computing MIN */
	    i__1 = m + 1;
	    m1 = min(i__1,n);
	    ki = (m - nx - 1) / nb * nb;
    /* Computing MIN */
        i__1 = m; i__2 = ki + nb;
	    kk = min(i__1,i__2);

	    i__1 = m - kk + 1;
	    i__2 = -nb;
	    for (i__ = m - kk + ki + 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; 
		    i__ += i__2) {
    /* Computing MIN */
	        i__3 = m - i__ + 1;
	        ib = min(i__3,nb);

    /*           Compute the TZ factorization of the current block */
    /*           A(i:i+ib-1,i:n) */

	        i__3 = n - i__ + 1;
	        i__4 = n - m;
	        dlatrz(ib, i__3, i__4, &a[i__ + i__ * a_dim1], lda, &tau[i__], 
		         &work[1]);
	        if (i__ > 1) {

    /*              Form the triangular factor of the block reflector */
    /*              H = H(i+ib-1) . . . H(i+1) H(i) */

		    i__3 = n - m;
		    dlarzt('B', 'R', i__3, ib, &a[i__ + m1 * 
			    a_dim1], lda, &tau[i__], &work[1], ldwork);

    /*              Apply H to A(1:i-1,i:n) from the right */

		    i__3 = i__ - 1;
		    i__4 = n - i__ + 1;
		    i__5 = n - m;
		    dlarzb('R', 'N', 'B', 'R', i__3, 
			     i__4, ib, i__5, &a[i__ + m1 * a_dim1], lda, &work[
			    1], ldwork, &a[i__ * a_dim1 + 1], lda, &work[ib + 1], 
			     ldwork)
			    ;
	        }
    /* L20: */
	    }
	    mu = i__ + nb - 1;
        } else {
	    mu = m;
        }

    /*     Use unblocked code to factor the last or only block */

        if (mu > 0) {
	    i__2 = n - m;
	    dlatrz(mu, n, i__2, &a[a_offset], lda, &tau[1], &work[1]);
        }

        work[1] = (double) lwkopt;

        return 0;
    } 
}

