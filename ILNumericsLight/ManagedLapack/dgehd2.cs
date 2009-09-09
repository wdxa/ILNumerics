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
    public static unsafe int dgehd2(int n, int ilo, int ihi, double *a, int lda, double *tau, double *work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;

        /* Local variables */
        int i__;
        double aii;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
        if (n < 0) {
	    info = -1;
        } else if (ilo < 1 || ilo > max(1,n)) {
	    info = -2;
        } else if (ihi < min(ilo,n) || ihi > n) {
	    info = -3;
        } else if (lda < max(1,n)) {
	    info = -5;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEHD2", i__1);
	    return 0;
        }

        i__1 = ihi - 1;
        for (i__ = ilo; i__ <= i__1; ++i__) {

    /*        Compute elementary reflector H(i) to annihilate A(i+2:ihi,i) */

	    i__2 = ihi - i__;
    /* Computing MIN */
	    i__3 = i__ + 2;
	    dlarfg(i__2, ref a[i__ + 1 + i__ * a_dim1], &a[min(i__3, n)+ i__ * 
		    a_dim1], c__1, ref tau[i__]);
	    aii = a[i__ + 1 + i__ * a_dim1];
	    a[i__ + 1 + i__ * a_dim1] = 1.0;

    /*        Apply H(i) to A(1:ihi,i+1:ihi) from the right */

	    i__2 = ihi - i__;
	    dlarf('R', ihi, i__2, &a[i__ + 1 + i__ * a_dim1], c__1, tau[
		    i__], &a[(i__ + 1) * a_dim1 + 1], lda, &work[1]);

    /*        Apply H(i) to A(i+1:ihi,i+1:n) from the left */

	    i__2 = ihi - i__;
	    i__3 = n - i__;
	    dlarf('L', i__2, i__3, &a[i__ + 1 + i__ * a_dim1], c__1, tau[
		    i__], &a[i__ + 1 + (i__ + 1) * a_dim1], lda, &work[1]);

	    a[i__ + 1 + i__ * a_dim1] = aii;
    /* L10: */
        }

        return 0;
    }
}

