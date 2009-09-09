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
    public static unsafe int dgebrd(int m, int n, double *a, int lda, double *d__, double *e,
        double *tauq, double* taup, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const int c__3 = 3;
        const int c__2 = 2;
        const double c_b21 = -1;
        const double c_b22 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4;

        /* Local variables */
        int i__, j, nb, nx;
        double ws;
        int nbmin, iinfo=0, minmn;
        int ldwrkx, ldwrky, lwkopt;
        bool lquery;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --d__;
        --e;
        --tauq;
        --taup;
        --work;

        /* Function Body */
        info = 0;
    /* Computing MAX */
        i__1 = 1;
        i__2 = ilaenv(c__1, "DGEBRD", " ", m, n, c_n1, c_n1);
        nb = max(i__1,i__2);
        lwkopt = (m + n) * nb;
        work[1] = (double) lwkopt;
        lquery = lwork == -1;
        if (m < 0) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,m)) {
	    info = -4;
        } else /* if(complicated condition) */ {
    /* Computing MAX */
	    i__1 = max(1,m);
	    if (lwork < max(i__1,n) && ! lquery) {
	        info = -10;
	    }
        }
        if (info < 0) {
	    i__1 = -(info);
	    xerbla("DGEBRD", i__1);
	    return 0;
        } else if (lquery) {
	    return 0;
        }

    /*     Quick return if possible */

        minmn = min(m,n);
        if (minmn == 0) {
	    work[1] = 1.0;
	    return 0;
        }

        ws = (double) max(m,n);
        ldwrkx = m;
        ldwrky = n;

        if (nb > 1 && nb < minmn) {

    /*        Set the crossover point NX. */

    /* Computing MAX */
        i__1 = nb;
        i__2 = ilaenv(c__3, "DGEBRD", " ", m, n, c_n1, c_n1);
	    nx = max(i__1,i__2);

    /*        Determine when to switch from blocked to unblocked code. */

	    if (nx < minmn) {
	        ws = (double) ((m + n) * nb);
	        if ((double) (lwork) < ws) {

    /*              Not enough work space for the optimal NB, consider using */
    /*              a smaller block size. */

		    nbmin = ilaenv(c__2, "DGEBRD", " ", m, n, c_n1, c_n1);
		    if (lwork >= (m + n) * nbmin) {
		        nb = lwork / (m + n);
		    } else {
		        nb = 1;
		        nx = minmn;
		    }
	        }
	    }
        } else {
	    nx = minmn;
        }

        i__1 = minmn - nx;
        i__2 = nb;
        for (i__ = 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {

    /*        Reduce rows and columns i:i+nb-1 to bidiagonal form and return */
    /*        the matrices X and Y which are needed to update the unreduced */
    /*        part of the matrix */

	    i__3 = m - i__ + 1;
	    i__4 = n - i__ + 1;
	    dlabrd(i__3, i__4, nb, &a[i__ + i__ * a_dim1], lda, &d__[i__], &e[
		    i__], &tauq[i__], &taup[i__], &work[1], ldwrkx, &work[ldwrkx 
		    * nb + 1], ldwrky);

    /*        Update the trailing submatrix A(i+nb:m,i+nb:n), using an update */
    /*        of the form  A := A - V*Y' - X*U' */

	    i__3 = m - i__ - nb + 1;
	    i__4 = n - i__ - nb + 1;
	    dgemm('N', 'T', i__3, i__4, nb, c_b21, &a[i__ 
		    + nb + i__ * a_dim1], lda, &work[ldwrkx * nb + nb + 1], 
		    ldwrky, c_b22, &a[i__ + nb + (i__ + nb) * a_dim1], lda);
	    i__3 = m - i__ - nb + 1;
	    i__4 = n - i__ - nb + 1;
	    dgemm('N', 'N', i__3, i__4, nb, c_b21, &
		    work[nb + 1], ldwrkx, &a[i__ + (i__ + nb) * a_dim1], lda, 
		    c_b22, &a[i__ + nb + (i__ + nb) * a_dim1], lda);

    /*        Copy diagonal and off-diagonal elements of B back into A */

	    if (m >= n) {
	        i__3 = i__ + nb - 1;
	        for (j = i__; j <= i__3; ++j) {
		    a[j + j * a_dim1] = d__[j];
		    a[j + (j + 1) * a_dim1] = e[j];
    /* L10: */
	        }
	    } else {
	        i__3 = i__ + nb - 1;
	        for (j = i__; j <= i__3; ++j) {
		    a[j + j * a_dim1] = d__[j];
		    a[j + 1 + j * a_dim1] = e[j];
    /* L20: */
	        }
	    }
    /* L30: */
        }

    /*     Use unblocked code to reduce the remainder of the matrix */

        i__2 = m - i__ + 1;
        i__1 = n - i__ + 1;
        dgebd2(i__2, i__1, &a[i__ + i__ * a_dim1], lda, &d__[i__], &e[i__], &
	        tauq[i__], &taup[i__], &work[1], ref iinfo);
        work[1] = ws;
        return 0;
    } 
}

