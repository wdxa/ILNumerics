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
    public static unsafe int dlabrd(int m, int n, int nb, double *a, int lda, double *d__, double *e,
        double *tauq, double *taup, double *x, int ldx, double *y, int ldy)
    {
        /* Table of constant values */
        const double c_b4 = -1.0;
        const double c_b5 = 1.0;
        const int c__1 = 1;
        const double c_b16 = 0.0;

        /* System generated locals */
        int a_dim1, a_offset, x_dim1, x_offset, y_dim1, y_offset, i__1, i__2, 
	        i__3;

        /* Local variables */
        int i__;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --d__;
        --e;
        --tauq;
        --taup;
        x_dim1 = ldx;
        x_offset = 1 + x_dim1;
        x -= x_offset;
        y_dim1 = ldy;
        y_offset = 1 + y_dim1;
        y -= y_offset;

        /* Function Body */
        if (m <= 0 || n <= 0) {
	    return 0;
        }

        if (m >= n) {

    /*        Reduce to upper bidiagonal form */

	    i__1 = nb;
	    for (i__ = 1; i__ <= i__1; ++i__) {

    /*           Update A(i:m,i) */

	        i__2 = m - i__ + 1;
	        i__3 = i__ - 1;
	        dgemv('N', i__2, i__3, c_b4, &a[i__ + a_dim1], lda, 
		         &y[i__ + y_dim1], ldy, c_b5, &a[i__ + i__ * a_dim1], c__1);
	        i__2 = m - i__ + 1;
	        i__3 = i__ - 1;
	        dgemv('N', i__2, i__3, c_b4, &x[i__ + x_dim1], ldx, 
		         &a[i__ * a_dim1 + 1], c__1, c_b5, &a[i__ + i__ * 
		        a_dim1], c__1);

    /*           Generate reflection Q(i) to annihilate A(i+1:m,i) */

	        i__2 = m - i__ + 1;
    /* Computing MIN */
	        i__3 = i__ + 1;
	        dlarfg(i__2, ref a[i__ + i__ * a_dim1], &a[min(i__3, m)+ i__ * 
		        a_dim1], c__1, ref tauq[i__]);
	        d__[i__] = a[i__ + i__ * a_dim1];
	        if (i__ < n) {
		    a[i__ + i__ * a_dim1] = 1.0;

    /*              Compute Y(i+1:n,i) */

		    i__2 = m - i__ + 1;
		    i__3 = n - i__;
		    dgemv('T', i__2, i__3, c_b5, &a[i__ + (i__ + 1) * 
			    a_dim1], lda, &a[i__ + i__ * a_dim1], c__1, c_b16, &
			    y[i__ + 1 + i__ * y_dim1], c__1);
		    i__2 = m - i__ + 1;
		    i__3 = i__ - 1;
		    dgemv('T', i__2, i__3, c_b5, &a[i__ + a_dim1], 
			    lda, &a[i__ + i__ * a_dim1], c__1, c_b16, &y[i__ * 
			    y_dim1 + 1], c__1);
		    i__2 = n - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &y[i__ + 1 + 
			    y_dim1], ldy, &y[i__ * y_dim1 + 1], c__1, c_b5, &y[
			    i__ + 1 + i__ * y_dim1], c__1);
		    i__2 = m - i__ + 1;
		    i__3 = i__ - 1;
		    dgemv('T', i__2, i__3, c_b5, &x[i__ + x_dim1], 
			    ldx, &a[i__ + i__ * a_dim1], c__1, c_b16, &y[i__ * 
			    y_dim1 + 1], c__1);
		    i__2 = i__ - 1;
		    i__3 = n - i__;
		    dgemv('T', i__2, i__3, c_b4, &a[(i__ + 1) * 
			    a_dim1 + 1], lda, &y[i__ * y_dim1 + 1], c__1, c_b5, 
			    &y[i__ + 1 + i__ * y_dim1], c__1);
		    i__2 = n - i__;
		    dscal(i__2, tauq[i__], &y[i__ + 1 + i__ * y_dim1], c__1);

    /*              Update A(i,i+1:n) */

		    i__2 = n - i__;
		    dgemv('N', i__2, i__, c_b4, &y[i__ + 1 + 
			    y_dim1], ldy, &a[i__ + a_dim1], lda, c_b5, &a[i__ + (
			    i__ + 1) * a_dim1], lda);
		    i__2 = i__ - 1;
		    i__3 = n - i__;
		    dgemv('T', i__2, i__3, c_b4, &a[(i__ + 1) * 
			    a_dim1 + 1], lda, &x[i__ + x_dim1], ldx, c_b5, &a[
			    i__ + (i__ + 1) * a_dim1], lda);

    /*              Generate reflection P(i) to annihilate A(i,i+2:n) */

		    i__2 = n - i__;
    /* Computing MIN */
		    i__3 = i__ + 2;
		    dlarfg(i__2, ref a[i__ + (i__ + 1) * a_dim1], &a[i__ + min(
			    i__3, n)* a_dim1], lda, ref taup[i__]);
		    e[i__] = a[i__ + (i__ + 1) * a_dim1];
		    a[i__ + (i__ + 1) * a_dim1] = 1.0;

    /*              Compute X(i+1:m,i) */

		    i__2 = m - i__;
		    i__3 = n - i__;
		    dgemv('N', i__2, i__3, c_b5, &a[i__ + 1 + (i__ 
			    + 1) * a_dim1], lda, &a[i__ + (i__ + 1) * a_dim1], 
			    lda, c_b16, &x[i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = n - i__;
		    dgemv('T', i__2, i__, c_b5, &y[i__ + 1 + y_dim1], 
			    ldy, &a[i__ + (i__ + 1) * a_dim1], lda, c_b16, &x[
			    i__ * x_dim1 + 1], c__1);
		    i__2 = m - i__;
		    dgemv('N', i__2, i__, c_b4, &a[i__ + 1 + 
			    a_dim1], lda, &x[i__ * x_dim1 + 1], c__1, c_b5, &x[
			    i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = i__ - 1;
		    i__3 = n - i__;
		    dgemv('N', i__2, i__3, c_b5, &a[(i__ + 1) * 
			    a_dim1 + 1], lda, &a[i__ + (i__ + 1) * a_dim1], lda, 
			    c_b16, &x[i__ * x_dim1 + 1], c__1);
		    i__2 = m - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &x[i__ + 1 + 
			    x_dim1], ldx, &x[i__ * x_dim1 + 1], c__1, c_b5, &x[
			    i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = m - i__;
		    dscal(i__2, taup[i__], &x[i__ + 1 + i__ * x_dim1], c__1);
	        }
    /* L10: */
	    }
        } else {

    /*        Reduce to lower bidiagonal form */

	    i__1 = nb;
	    for (i__ = 1; i__ <= i__1; ++i__) {

    /*           Update A(i,i:n) */

	        i__2 = n - i__ + 1;
	        i__3 = i__ - 1;
	        dgemv('N', i__2, i__3, c_b4, &y[i__ + y_dim1], ldy, 
		         &a[i__ + a_dim1], lda, c_b5, &a[i__ + i__ * a_dim1], 
		        lda);
	        i__2 = i__ - 1;
	        i__3 = n - i__ + 1;
	        dgemv('T', i__2, i__3, c_b4, &a[i__ * a_dim1 + 1], 
		        lda, &x[i__ + x_dim1], ldx, c_b5, &a[i__ + i__ * a_dim1], 
		         lda);

    /*           Generate reflection P(i) to annihilate A(i,i+1:n) */

	        i__2 = n - i__ + 1;
    /* Computing MIN */
	        i__3 = i__ + 1;
	        dlarfg(i__2, ref a[i__ + i__ * a_dim1], &a[i__ + min(i__3, n)* 
		        a_dim1], lda, ref taup[i__]);
	        d__[i__] = a[i__ + i__ * a_dim1];
	        if (i__ < m) {
		    a[i__ + i__ * a_dim1] = 1.0;

    /*              Compute X(i+1:m,i) */

		    i__2 = m - i__;
		    i__3 = n - i__ + 1;
		    dgemv('N', i__2, i__3, c_b5, &a[i__ + 1 + i__ *
			     a_dim1], lda, &a[i__ + i__ * a_dim1], lda, c_b16, &
			    x[i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = n - i__ + 1;
		    i__3 = i__ - 1;
		    dgemv('T', i__2, i__3, c_b5, &y[i__ + y_dim1], 
			    ldy, &a[i__ + i__ * a_dim1], lda, c_b16, &x[i__ * 
			    x_dim1 + 1], c__1);
		    i__2 = m - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &a[i__ + 1 + 
			    a_dim1], lda, &x[i__ * x_dim1 + 1], c__1, c_b5, &x[
			    i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = i__ - 1;
		    i__3 = n - i__ + 1;
		    dgemv('N', i__2, i__3, c_b5, &a[i__ * a_dim1 + 
			    1], lda, &a[i__ + i__ * a_dim1], lda, c_b16, &x[i__ *
			     x_dim1 + 1], c__1);
		    i__2 = m - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &x[i__ + 1 + 
			    x_dim1], ldx, &x[i__ * x_dim1 + 1], c__1, c_b5, &x[
			    i__ + 1 + i__ * x_dim1], c__1);
		    i__2 = m - i__;
		    dscal(i__2, taup[i__], &x[i__ + 1 + i__ * x_dim1], c__1);

    /*              Update A(i+1:m,i) */

		    i__2 = m - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &a[i__ + 1 + 
			    a_dim1], lda, &y[i__ + y_dim1], ldy, c_b5, &a[i__ + 
			    1 + i__ * a_dim1], c__1);
		    i__2 = m - i__;
		    dgemv('N', i__2, i__, c_b4, &x[i__ + 1 + 
			    x_dim1], ldx, &a[i__ * a_dim1 + 1], c__1, c_b5, &a[
			    i__ + 1 + i__ * a_dim1], c__1);

    /*              Generate reflection Q(i) to annihilate A(i+2:m,i) */

		    i__2 = m - i__;
    /* Computing MIN */
		    i__3 = i__ + 2;
		    dlarfg(i__2, ref a[i__ + 1 + i__ * a_dim1], &a[min(i__3, m)+ 
			    i__ * a_dim1], c__1, ref tauq[i__]);
		    e[i__] = a[i__ + 1 + i__ * a_dim1];
		    a[i__ + 1 + i__ * a_dim1] = 1.0;

    /*              Compute Y(i+1:n,i) */

		    i__2 = m - i__;
		    i__3 = n - i__;
		    dgemv('T', i__2, i__3, c_b5, &a[i__ + 1 + (i__ + 
			    1) * a_dim1], lda, &a[i__ + 1 + i__ * a_dim1], c__1, 
			    c_b16, &y[i__ + 1 + i__ * y_dim1], c__1);
		    i__2 = m - i__;
		    i__3 = i__ - 1;
		    dgemv('T', i__2, i__3, c_b5, &a[i__ + 1 + a_dim1], 
			     lda, &a[i__ + 1 + i__ * a_dim1], c__1, c_b16, &y[
			    i__ * y_dim1 + 1], c__1);
		    i__2 = n - i__;
		    i__3 = i__ - 1;
		    dgemv('N', i__2, i__3, c_b4, &y[i__ + 1 + 
			    y_dim1], ldy, &y[i__ * y_dim1 + 1], c__1, c_b5, &y[
			    i__ + 1 + i__ * y_dim1], c__1);
		    i__2 = m - i__;
		    dgemv('T', i__2, i__, c_b5, &x[i__ + 1 + x_dim1], 
			    ldx, &a[i__ + 1 + i__ * a_dim1], c__1, c_b16, &y[
			    i__ * y_dim1 + 1], c__1);
		    i__2 = n - i__;
		    dgemv('T', i__, i__2, c_b4, &a[(i__ + 1) * a_dim1 
			    + 1], lda, &y[i__ * y_dim1 + 1], c__1, c_b5, &y[i__ 
			    + 1 + i__ * y_dim1], c__1);
		    i__2 = n - i__;
		    dscal(i__2, tauq[i__], &y[i__ + 1 + i__ * y_dim1], c__1);
	        }
    /* L20: */
	    }
        }
        return 0;
    } 
}

