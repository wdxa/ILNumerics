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
    public static unsafe int dgeqrf(int m, int n, double* a, int lda, double* tau, double* work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4;

        /* Local variables */
        int i__, k, ib, nb, nx, iws, nbmin, iinfo=0;
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
        nb = ilaenv(c__1, "DGEQRF", " ", m, n, c_n1, c_n1);
        lwkopt = n * nb;
        work[1] = (double) lwkopt;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,m)) {
	    info = -4;
        } else if (lwork < max(1,n) && ! lquery) {
	    info = -7;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEQRF", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        k = min(m,n);
        if (k == 0) {
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
        i__2 = ilaenv(c__3, "DGEQRF", " ", m, n, c_n1, c_n1);
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
            i__2 = ilaenv(c__2, "DGEQRF", " ", m, n, c_n1, 
                 c_n1);
		    nbmin = max(i__1,i__2);
	        }
	    }
        }

        if (nb >= nbmin && nb < k && nx < k) {

    /*        Use blocked code initially */

	    i__1 = k - nx;
	    i__2 = nb;
	    for (i__ = 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {
    /* Computing MIN */
	        i__3 = k - i__ + 1;
	        ib = min(i__3,nb);

    /*           Compute the QR factorization of the current block */
    /*           A(i:m,i:i+ib-1) */

	        i__3 = m - i__ + 1;
	        dgeqr2(i__3, ib, &a[i__ + i__ * a_dim1], lda, &tau[i__], &work[
		        1], ref iinfo);
	        if (i__ + ib <= n) {

    /*              Form the triangular factor of the block reflector */
    /*              H = H(i) H(i+1) . . . H(i+ib-1) */

		    i__3 = m - i__ + 1;
		    dlarft('F', 'C', i__3, ib, &a[i__ + i__ * 
			    a_dim1], lda, &tau[i__], &work[1], ldwork);

    /*              Apply H' to A(i:m,i+ib:n) from the left */

		    i__3 = m - i__ + 1;
		    i__4 = n - i__ - ib + 1;
		    dlarfb('L', 'T', 'F', 'C', i__3, 
			    i__4, ib, &a[i__ + i__ * a_dim1], lda, &work[1], 
			    ldwork, &a[i__ + (i__ + ib) * a_dim1], lda, &work[ib 
			    + 1], ldwork);
	        }
    /* L10: */
	    }
        } else {
	    i__ = 1;
        }

    /*     Use unblocked code to factor the last or only block. */

        if (i__ <= k) {
	    i__2 = m - i__ + 1;
	    i__1 = n - i__ + 1;
	    dgeqr2(i__2, i__1, &a[i__ + i__ * a_dim1], lda, &tau[i__], &work[1]
    , ref iinfo);
        }

        work[1] = (double) iws;
        return 0;
    } 
}

