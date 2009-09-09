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
    public static unsafe int dormr3(char side, char trans, int m, int n, int k, int l,
        double* a, int lda, double* tau, double* c__, int ldc, double* work, ref int info)
    {
        /* System generated locals */
        int a_dim1, a_offset, c_dim1, c_offset, i__1, i__2;

        /* Local variables */
        int i__, i1, i2, i3, ja, ic=0, jc=0, mi=0, ni=0, nq;
        bool left;
        bool notran;

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

    /*     NQ is the order of Q */

        if (left) {
	    nq = m;
        } else {
	    nq = n;
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
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORMR3", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (m == 0 || n == 0 || k == 0) {
	    return 0;
        }

        if (left && ! notran || ! left && notran) {
	    i1 = 1;
	    i2 = k;
	    i3 = 1;
        } else {
	    i1 = k;
	    i2 = 1;
	    i3 = -1;
        }

        if (left) {
	    ni = n;
	    ja = m - l + 1;
	    jc = 1;
        } else {
	    mi = m;
	    ja = n - l + 1;
	    ic = 1;
        }

        i__1 = i2;
        i__2 = i3;
        for (i__ = i1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {
	    if (left) {

    /*           H(i) or H(i)' is applied to C(i:m,1:n) */

	        mi = m - i__ + 1;
	        ic = i__;
	    } else {

    /*           H(i) or H(i)' is applied to C(1:m,i:n) */

	        ni = n - i__ + 1;
	        jc = i__;
	    }

    /*        Apply H(i) or H(i)' */

	    dlarz(side, mi, ni, l, &a[i__ + ja * a_dim1], lda, tau[i__], &c__[
		    ic + jc * c_dim1], ldc, &work[1]);

    /* L10: */
        }

        return 0;
    } 
}

