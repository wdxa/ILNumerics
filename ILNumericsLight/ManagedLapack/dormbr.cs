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
    public static unsafe int dormbr(char vect, char side, char trans, int m, int n, int k,
        double* a, int lda, double* tau, double* c__, int ldc, double* work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;

         /* System generated locals */
        int a_dim1, a_offset, c_dim1, c_offset, i__1, i__2;

        /* Local variables */
        int i1, i2, nb, mi, ni, nq, nw;
        bool left;
        int iinfo=0;
        bool notran;
        bool applyq;
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
        applyq = lsame(vect, 'Q');
        left = lsame(side, 'L');
        notran = lsame(trans, 'N');
        lquery = lwork == -1;

    /*     NQ is the order of Q or P and NW is the minimum dimension of WORK */

        if (left) {
	    nq = m;
	    nw = n;
        } else {
	    nq = n;
	    nw = m;
        }
        if (! applyq && ! lsame(vect, 'P')) {
	    info = -1;
        } else if (! left && ! lsame(side, 'R')) {
	    info = -2;
        } else if (! notran && ! lsame(trans, 'T')) {
	    info = -3;
        } else if (m < 0) {
	    info = -4;
        } else if (n < 0) {
	    info = -5;
        } else if (k < 0) {
	    info = -6;
        } else /* if(complicated condition) */ {
    /* Computing MAX */
	    i__1 = 1;
        i__2 = min(nq,k);
	    if (applyq && lda < max(1,nq) || ! applyq && lda < max(i__1,i__2)) {
	        info = -8;
	    } else if (ldc < max(1,m)) {
	        info = -11;
	    } else if (lwork < max(1,nw) && ! lquery) {
	        info = -13;
	    }
        }

        if (info == 0) {
	    if (applyq) {
	        if (left) {
    /* Writing concatenation */
		    i__1 = m - 1;
		    i__2 = m - 1;
		    nb = ilaenv(c__1, "DORMQR", side.ToString()+trans.ToString(), i__1, n, i__2, c_n1);
	        } else {
    /* Writing concatenation */
		    i__1 = n - 1;
		    i__2 = n - 1;
		    nb = ilaenv(c__1, "DORMQR", side.ToString()+trans.ToString(), m, i__1, i__2, c_n1);
	        }
	    } else {
	        if (left) {
    /* Writing concatenation */
		    i__1 = m - 1;
		    i__2 = m - 1;
		    nb = ilaenv(c__1, "DORMLQ", side.ToString()+trans.ToString(), i__1, n, i__2, c_n1);
	        } else {
    /* Writing concatenation */
		    i__1 = n - 1;
		    i__2 = n - 1;
		    nb = ilaenv(c__1, "DORMLQ", side.ToString()+trans.ToString(), m, i__1, i__2, c_n1);
	        }
	    }
	    lwkopt = max(1,nw) * nb;
	    work[1] = (double) lwkopt;
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORMBR", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        work[1] = 1.0;
        if (m == 0 || n == 0) {
	    return 0;
        }

        if (applyq) {

    /*        Apply Q */

	    if (nq >= k) {

    /*           Q was determined by a call to DGEBRD with nq >= k */

	        dormqr(side, trans, m, n, k, &a[a_offset], lda, &tau[1], &c__[
		        c_offset], ldc, &work[1], lwork, ref iinfo);
	    } else if (nq > 1) {

    /*           Q was determined by a call to DGEBRD with nq < k */

	        if (left) {
		    mi = m - 1;
		    ni = n;
		    i1 = 2;
		    i2 = 1;
	        } else {
		    mi = m;
		    ni = n - 1;
		    i1 = 1;
		    i2 = 2;
	        }
	        i__1 = nq - 1;
	        dormqr(side, trans, mi, ni, i__1, &a[a_dim1 + 2], lda, &tau[1]
    , &c__[i1 + i2 * c_dim1], ldc, &work[1], lwork, ref iinfo);
	    }
        } else {

    /*        Apply P */

	    if (notran) {
	        transt = 'T';
	    } else {
	        transt = 'N';
	    }
	    if (nq > k) {

    /*           P was determined by a call to DGEBRD with nq > k */

	        dormlq(side, transt, m, n, k, &a[a_offset], lda, &tau[1], &c__[
		        c_offset], ldc, &work[1], lwork, ref iinfo);
	    } else if (nq > 1) {

    /*           P was determined by a call to DGEBRD with nq <= k */

	        if (left) {
		    mi = m - 1;
		    ni = n;
		    i1 = 2;
		    i2 = 1;
	        } else {
		    mi = m;
		    ni = n - 1;
		    i1 = 1;
		    i2 = 2;
	        }
	        i__1 = nq - 1;
	        dormlq(side, transt, mi, ni, i__1, &a[(a_dim1 << 1) + 1], lda, 
		         &tau[1], &c__[i1 + i2 * c_dim1], ldc, &work[1], lwork, ref
		        iinfo);
	    }
        }
        work[1] = (double) lwkopt;
        return 0;
    } 
}

