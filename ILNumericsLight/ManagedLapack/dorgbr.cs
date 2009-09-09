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
    public static unsafe int dorgbr(char vect, int m, int n, int k, double *a, int lda, double *tau, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__, j, nb, mn;
        int iinfo=0;
        bool wantq;
        int lwkopt=0;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        wantq = lsame(vect, 'Q');
        mn = min(m,n);
        lquery = lwork == -1;
        if (! wantq && ! lsame(vect, 'P')) {
	    info = -1;
        } else if (m < 0) {
	    info = -2;
        } else if (n < 0 || wantq && (n > m || n < min(m,k)) || ! wantq && (
	        m > n || m < min(n,k))) {
	    info = -3;
        } else if (k < 0) {
	    info = -4;
        } else if (lda < max(1,m)) {
	    info = -6;
        } else if (lwork < max(1,mn) && ! lquery) {
	    info = -9;
        }

        if (info == 0) {
	    if (wantq) {
	        nb = ilaenv(c__1, "DORGQR", " ", m, n, k, c_n1);
	    } else {
	        nb = ilaenv(c__1, "DORGLQ", " ", m, n, k, c_n1);
	    }
	    lwkopt = max(1,mn) * nb;
	    work[1] = (double) lwkopt;
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORGBR", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    work[1] = 1.0;
	    return 0;
        }

        if (wantq) {

    /*        Form Q, determined by a call to DGEBRD to reduce an m-by-k */
    /*        matrix */

	    if (m >= k) {

    /*           If m >= k, assume m >= n >= k */

	        dorgqr(m, n, k, &a[a_offset], lda, &tau[1], &work[1], lwork, ref iinfo);

	    } else {

    /*           If m < k, assume m = n */

    /*           Shift the vectors which define the elementary reflectors one */
    /*           column to the right, and set the first row and column of Q */
    /*           to those of the unit matrix */

	        for (j = m; j >= 2; --j) {
		    a[j * a_dim1 + 1] = 0.0;
		    i__1 = m;
		    for (i__ = j + 1; i__ <= i__1; ++i__) {
		        a[i__ + j * a_dim1] = a[i__ + (j - 1) * a_dim1];
    /* L10: */
		    }
    /* L20: */
	        }
	        a[a_dim1 + 1] = 1.0;
	        i__1 = m;
	        for (i__ = 2; i__ <= i__1; ++i__) {
		    a[i__ + a_dim1] = 0.0;
    /* L30: */
	        }
	        if (m > 1) {

    /*              Form Q(2:m,2:m) */

		    i__1 = m - 1;
		    i__2 = m - 1;
		    i__3 = m - 1;
		    dorgqr(i__1, i__2, i__3, &a[(a_dim1 << 1) + 2], lda, &tau[
			    1], &work[1], lwork, ref iinfo);
	        }
	    }
        } else {

    /*        Form P', determined by a call to DGEBRD to reduce a k-by-n */
    /*        matrix */

	    if (k < n) {

    /*           If k < n, assume k <= m <= n */

	        dorglq(m, n, k, &a[a_offset], lda, &tau[1], &work[1], lwork, ref iinfo);

	    } else {

    /*           If k >= n, assume m = n */

    /*           Shift the vectors which define the elementary reflectors one */
    /*           row downward, and set the first row and column of P' to */
    /*           those of the unit matrix */

	        a[a_dim1 + 1] = 1.0;
	        i__1 = n;
	        for (i__ = 2; i__ <= i__1; ++i__) {
		    a[i__ + a_dim1] = 0.0;
    /* L40: */
	        }
	        i__1 = n;
	        for (j = 2; j <= i__1; ++j) {
		    for (i__ = j - 1; i__ >= 2; --i__) {
		        a[i__ + j * a_dim1] = a[i__ - 1 + j * a_dim1];
    /* L50: */
		    }
		    a[j * a_dim1 + 1] = 0.0;
    /* L60: */
	        }
	        if (n > 1) {

    /*              Form P'(2:n,2:n) */

		    i__1 = n - 1;
		    i__2 = n - 1;
		    i__3 = n - 1;
		    dorglq(i__1, i__2, i__3, &a[(a_dim1 << 1) + 2], lda, &tau[
			    1], &work[1], lwork, ref iinfo);
	        }
	    }
        }
        work[1] = (double) lwkopt;
        return 0;
    } 
}

