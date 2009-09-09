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
    public static unsafe int dorghr(int n, int ilo, int ihi, double *a, int lda, double *tau, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__, j, nb, nh, iinfo=0;
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
        nh = ihi - ilo;
        lquery = lwork == -1;
        if (n < 0) {
	    info = -1;
        } else if (ilo < 1 || ilo > max(1,n)) {
	    info = -2;
        } else if (ihi < min(ilo,n) || ihi > n) {
	    info = -3;
        } else if (lda < max(1,n)) {
	    info = -5;
        } else if (lwork < max(1,nh) && ! lquery) {
	    info = -8;
        }

        if (info == 0) {
	    nb = ilaenv(c__1, "DORGQR", " ", nh, nh, nh, c_n1);
	    lwkopt = max(1,nh) * nb;
	    work[1] = (double) lwkopt;
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DORGHR", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    work[1] = 1.0;
	    return 0;
        }

    /*     Shift the vectors which define the elementary reflectors one */
    /*     column to the right, and set the first ilo and the last n-ihi */
    /*     rows and columns to those of the unit matrix */

        i__1 = ilo + 1;
        for (j = ihi; j >= i__1; --j) {
	    i__2 = j - 1;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        a[i__ + j * a_dim1] = 0.0;
    /* L10: */
	    }
	    i__2 = ihi;
	    for (i__ = j + 1; i__ <= i__2; ++i__) {
	        a[i__ + j * a_dim1] = a[i__ + (j - 1) * a_dim1];
    /* L20: */
	    }
	    i__2 = n;
	    for (i__ = ihi + 1; i__ <= i__2; ++i__) {
	        a[i__ + j * a_dim1] = 0.0;
    /* L30: */
	    }
    /* L40: */
        }
        i__1 = ilo;
        for (j = 1; j <= i__1; ++j) {
	    i__2 = n;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        a[i__ + j * a_dim1] = 0.0;
    /* L50: */
	    }
	    a[j + j * a_dim1] = 1.0;
    /* L60: */
        }
        i__1 = n;
        for (j = ihi + 1; j <= i__1; ++j) {
	    i__2 = n;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        a[i__ + j * a_dim1] = 0.0;
    /* L70: */
	    }
	    a[j + j * a_dim1] = 1.0;
    /* L80: */
        }

        if (nh > 0) {

    /*        Generate Q(ilo+1:ihi,ilo+1:ihi) */

	    dorgqr(nh, nh, nh, &a[ilo + 1 + (ilo + 1) * a_dim1], lda, &tau[
		    ilo], &work[1], lwork, ref iinfo);
        }
        work[1] = (double) lwkopt;
        return 0;
    }
}

