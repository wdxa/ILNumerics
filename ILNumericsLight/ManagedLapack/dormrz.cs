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
    public static unsafe int dormrz(char side, char trans, int m, int n, int k, int l, double* a, int lda,
        double* tau, double* c__, int ldc, double* work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__2 = 2;
        const int c__65 = 65;

        /* System generated locals */
        int a_dim1, a_offset, c_dim1, c_offset, i__1, i__2, i__4, i__5;

        /* Local variables */
        int i__;
        double* t = stackalloc double[4160];
        int i1, i2, i3, ib, ic=0, ja, jc=0, nb=0, mi=0, ni=0, nq, nw, iws;
        bool left;
        int nbmin, iinfo=0;
        bool notran;
        int ldwork;
        char transt;
        int lwkopt=0;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        --work;

        /* Function Body */
        info = 0;
        left = lsame(side, 'L');
        notran = lsame(trans, 'N');
        lquery = lwork == -1;

    /*     NQ is the order of Q and NW is the minimum dimension of WORK */

        if (left) {
	    nq = m;
	    nw = max(1,n);
        } else {
	    nq = n;
	    nw = max(1,m);
        }
        if (! left && ! lsame(side, 'R')) {
	    info = -1;
        } else if (! notran && ! lsame(trans, 'T')) {
	    info = -2;
        } else if (m < 0) {
	    info = -3;
        } else if (n < 0) {
	    info = -4;
        } else if (k < 0 || k > nq) {
	    info = -5;
        } else if (l < 0 || left && l > m || ! left && l > n) {
	    info = -6;
        } else if (lda < max(1,k)) {
	    info = -8;
        } else if (ldc < max(1,m)) {
	    info = -11;
        }

        if (info == 0) {
	    if (m == 0 || n == 0) {
	        lwkopt = 1;
	    } else {

    /*           Determine the block size.  NB may be at most NBMAX, where */
    /*           NBMAX is used to define the local array T. */

    /* Computing MIN */
    /* Writing concatenation */
	        i__1 = 64;
            i__2 = ilaenv(c__1, "DORMRQ", side.ToString()+trans.ToString(), m, n, k, c_n1);
	        nb = min(i__1,i__2);
	        lwkopt = nw * nb;
	    }
	    work[1] = (double) lwkopt;

	    if (lwork < max(1,nw) && ! lquery) {
	        info = -13;
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORMRZ", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    work[1] = 1.0;
	    return 0;
        }

        nbmin = 2;
        ldwork = nw;
        if (nb > 1 && nb < k) {
	    iws = nw * nb;
	    if (lwork < iws) {
	        nb = lwork / ldwork;
    /* Computing MAX */
    /* Writing concatenation */
	        i__1 = 2;
            i__2 = ilaenv(c__2, "DORMRQ", side.ToString() + trans.ToString(), m, n, k, c_n1);
	        nbmin = max(i__1,i__2);
	    }
        } else {
	    iws = nw;
        }

        if (nb < nbmin || nb >= k) {

    /*        Use unblocked code */

	    dormr3(side, trans, m, n, k, l, &a[a_offset], lda, &tau[1], &c__[
		    c_offset], ldc, &work[1], ref iinfo);
        } else {

    /*        Use blocked code */

	    if (left && ! notran || ! left && notran) {
	        i1 = 1;
	        i2 = k;
	        i3 = nb;
	    } else {
	        i1 = (k - 1) / nb * nb + 1;
	        i2 = 1;
	        i3 = -nb;
	    }

	    if (left) {
	        ni = n;
	        jc = 1;
	        ja = m - l + 1;
	    } else {
	        mi = m;
	        ic = 1;
	        ja = n - l + 1;
	    }

	    if (notran) {
	        transt = 'T';
	    } else {
	        transt = 'N';
	    }

	    i__1 = i2;
	    i__2 = i3;
	    for (i__ = i1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {
    /* Computing MIN */
	        i__4 = nb; i__5 = k - i__ + 1;
	        ib = min(i__4,i__5);

    /*           Form the triangular factor of the block reflector */
    /*           H = H(i+ib-1) . . . H(i+1) H(i) */

	        dlarzt('B', 'R', l, ib, &a[i__ + ja * a_dim1], lda, 
		         &tau[i__], t, c__65);

	        if (left) {

    /*              H or H' is applied to C(i:m,1:n) */

		    mi = m - i__ + 1;
		    ic = i__;
	        } else {

    /*              H or H' is applied to C(1:m,i:n) */

		    ni = n - i__ + 1;
		    jc = i__;
	        }

    /*           Apply H or H' */

	        dlarzb(side, transt, 'B', 'R', mi, ni, ib, l, &a[
		        i__ + ja * a_dim1], lda, t, c__65, &c__[ic + jc * c_dim1]
    , ldc, &work[1], ldwork);
    /* L10: */
	    }

        }

        work[1] = (double) lwkopt;

        return 0;
    } 
}

