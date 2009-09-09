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
    public static unsafe int dgehrd(int n, int ilo, int ihi, double *a, int lda, double *tau, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;
        const int c__65 = 65;
        const double c_b25 = -1.0;
        const double c_b26 = 1.0;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4;

        /* Local variables */
        int i__, j;
        double* t = stackalloc double[4160]	/* was [65][64] */;
        int ib;
        double ei;
        int nb, nh, nx=0, iws;
        int nbmin, iinfo=0;
        int ldwork, lwkopt;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --tau;
        --work;

        /* Function Body */
        info = 0;
    /* Computing MIN */
        i__1 = 64; i__2 = ilaenv(c__1, "DGEHRD", " ", n, ilo, ihi, c_n1);
        nb = min(i__1,i__2);
        lwkopt = n * nb;
        work[1] = (double) lwkopt;
        lquery = lwork == -1;
        if (n < 0) {
	    info = -1;
        } else if (ilo < 1 || ilo > max(1,n)) {
	    info = -2;
        } else if (ihi < min(ilo,n) || ihi > n) {
	    info = -3;
        } else if (lda < max(1,n)) {
	    info = -5;
        } else if (lwork < max(1,n) && ! lquery) {
	    info = -8;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEHRD", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Set elements 1:ILO-1 and IHI:N-1 of TAU to zero */

        i__1 = ilo - 1;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    tau[i__] = 0.0;
    /* L10: */
        }
        i__1 = n - 1;
        for (i__ = max(1,ihi); i__ <= i__1; ++i__) {
	    tau[i__] = 0.0;
    /* L20: */
        }

    /*     Quick return if possible */

        nh = ihi - ilo + 1;
        if (nh <= 1) {
	    work[1] = 1.0;
	    return 0;
        }

    /*     Determine the block size */

    /* Computing MIN */
        i__1 = 64; i__2 = ilaenv(c__1, "DGEHRD", " ", n, ilo, ihi, c_n1);
        nb = min(i__1,i__2);
        nbmin = 2;
        iws = 1;
        if (nb > 1 && nb < nh) {

    /*        Determine when to cross over from blocked to unblocked code */
    /*        (last block is always handled by unblocked code) */

    /* Computing MAX */
	    i__1 = nb; i__2 = ilaenv(c__3, "DGEHRD", " ", n, ilo, ihi, c_n1);
	    nx = max(i__1,i__2);
	    if (nx < nh) {

    /*           Determine if workspace is large enough for blocked code */

	        iws = n * nb;
	        if (lwork < iws) {

    /*              Not enough workspace to use optimal NB:  determine the */
    /*              minimum value of NB, and reduce NB or force use of */
    /*              unblocked code */

    /* Computing MAX */
		    i__1 = 2; i__2 = ilaenv(c__2, "DGEHRD", " ", n, ilo, ihi, c_n1);
		    nbmin = max(i__1,i__2);
		    if (lwork >= n * nbmin) {
		        nb = lwork / n;
		    } else {
		        nb = 1;
		    }
	        }
	    }
        }
        ldwork = n;

        if (nb < nbmin || nb >= nh) {

    /*        Use unblocked code below */

	    i__ = ilo;

        } else {

    /*        Use blocked code */

	    i__1 = ihi - 1 - nx;
	    i__2 = nb;
	    for (i__ = ilo; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {
    /* Computing MIN */
            i__3 = nb; i__4 = ihi - i__;
	        ib = min(i__3,i__4);

    /*           Reduce columns i:i+ib-1 to Hessenberg form, returning the */
    /*           matrices V and T of the block reflector H = I - V*T*V' */
    /*           which performs the reduction, and also the matrix Y = A*V*T */

	        dlahr2(ihi, i__, ib, &a[i__ * a_dim1 + 1], lda, &tau[i__], t, 
		        c__65, &work[1], ldwork);

    /*           Apply the block reflector H to A(1:ihi,i+ib:ihi) from the */
    /*           right, computing  A := A - Y * V'. V(i+ib,ib-1) must be set */
    /*           to 1 */

	        ei = a[i__ + ib + (i__ + ib - 1) * a_dim1];
	        a[i__ + ib + (i__ + ib - 1) * a_dim1] = 1.0;
	        i__3 = ihi - i__ - ib + 1;
	        dgemm('N', 'T', ihi, i__3, ib, c_b25, &
		        work[1], ldwork, &a[i__ + ib + i__ * a_dim1], lda, 
		        c_b26, &a[(i__ + ib) * a_dim1 + 1], lda);
	        a[i__ + ib + (i__ + ib - 1) * a_dim1] = ei;

    /*           Apply the block reflector H to A(1:i,i+1:i+ib-1) from the */
    /*           right */

	        i__3 = ib - 1;
	        dtrmm('R', 'L', 'T', 'U', i__, i__3, c_b26, 
		         &a[i__ + 1 + i__ * a_dim1], lda, &work[1], ldwork);
	        i__3 = ib - 2;
	        for (j = 0; j <= i__3; ++j) {
		    daxpy(i__, c_b25, &work[ldwork * j + 1], c__1, &a[(i__ + 
			    j + 1) * a_dim1 + 1], c__1);
    /* L30: */
	        }

    /*           Apply the block reflector H to A(i+1:ihi,i+ib:n) from the */
    /*           left */

	        i__3 = ihi - i__;
	        i__4 = n - i__ - ib + 1;
	        dlarfb('L', 'T', 'F', 'C', i__3, 
		        i__4, ib, &a[i__ + 1 + i__ * a_dim1], lda, t, c__65, &a[
		        i__ + 1 + (i__ + ib) * a_dim1], lda, &work[1], ldwork);
    /* L40: */
	    }
        }

    /*     Use unblocked code to reduce the rest of the matrix */

        dgehd2(n, i__, ihi, &a[a_offset], lda, &tau[1], &work[1], ref iinfo);
        work[1] = (double) iws;

        return 0;
    }
}

