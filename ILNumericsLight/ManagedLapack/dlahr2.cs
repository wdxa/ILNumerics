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
    public static unsafe int dlahr2(int n, int k, int nb, double* a, int lda,
        double *tau, double *t, int ldt, double *y, int ldy)
    {
        /* Table of constant values */
        const double c_b4 = -1.0;
        const double c_b5 = 1.0;
        const int c__1 = 1;
        const double c_b38 = 0.0;

        /* System generated locals */
        int a_dim1, a_offset, t_dim1, t_offset, y_dim1, y_offset, i__1, i__2, 
	        i__3;
        double d__1;

        /* Local variables */
        int i__;
        double ei=0;

        /* Parameter adjustments */
        --tau;
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        y_dim1 = ldy;
        y_offset = 1 + y_dim1;
        y -= y_offset;

        /* Function Body */
        if (n <= 1) {
	    return 0;
        }

        i__1 = nb;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if (i__ > 1) {

    /*           Update A(K+1:N,I) */

    /*           Update I-th column of A - Y * V' */

	        i__2 = n - k;
	        i__3 = i__ - 1;
	        dgemv('N', i__2, i__3, c_b4, &y[k + 1 + y_dim1], 
		        ldy, &a[k + i__ - 1 + a_dim1], lda, c_b5, &a[k + 1 + 
		        i__ * a_dim1], c__1);

    /*           Apply I - V * T' * V' to this column (call it b) from the */
    /*           left, using the last column of T as workspace */

    /*           Let  V = ( V1 )   and   b = ( b1 )   (first I-1 rows) */
    /*                    ( V2 )             ( b2 ) */

    /*           where V1 is unit lower triangular */

    /*           w := V1' * b1 */

	        i__2 = i__ - 1;
	        dcopy(i__2, &a[k + 1 + i__ * a_dim1], c__1, &t[nb * t_dim1 + 
		        1], c__1);
	        i__2 = i__ - 1;
	        dtrmv('L', 'T', 'U', i__2, &a[k + 1 + a_dim1], 
		        lda, &t[nb * t_dim1 + 1], c__1);

    /*           w := w + V2'*b2 */

	        i__2 = n - k - i__ + 1;
	        i__3 = i__ - 1;
	        dgemv('T', i__2, i__3, c_b5, &a[k + i__ + a_dim1], 
		        lda, &a[k + i__ + i__ * a_dim1], c__1, c_b5, &t[nb * 
		        t_dim1 + 1], c__1);

    /*           w := T'*w */

	        i__2 = i__ - 1;
	        dtrmv('U', 'T', 'N', i__2, &t[t_offset], ldt, 
		         &t[nb * t_dim1 + 1], c__1);

    /*           b2 := b2 - V2*w */

	        i__2 = n - k - i__ + 1;
	        i__3 = i__ - 1;
	        dgemv('N', i__2, i__3, c_b4, &a[k + i__ + a_dim1], 
		         lda, &t[nb * t_dim1 + 1], c__1, c_b5, &a[k + i__ + 
		        i__ * a_dim1], c__1);

    /*           b1 := b1 - V1*w */

	        i__2 = i__ - 1;
	        dtrmv('L', 'N', 'U', i__2, &a[k + 1 + a_dim1]
    , lda, &t[nb * t_dim1 + 1], c__1);
	        i__2 = i__ - 1;
	        daxpy(i__2, c_b4, &t[nb * t_dim1 + 1], c__1, &a[k + 1 + i__ 
		        * a_dim1], c__1);

	        a[k + i__ - 1 + (i__ - 1) * a_dim1] = ei;
	    }

    /*        Generate the elementary reflector H(I) to annihilate */
    /*        A(K+I+1:N,I) */

	    i__2 = n - k - i__ + 1;
    /* Computing MIN */
	    i__3 = k + i__ + 1;
	    dlarfg(i__2, ref a[k + i__ + i__ * a_dim1], &a[min(i__3, n)+ i__ * 
		    a_dim1], c__1, ref tau[i__]);
	    ei = a[k + i__ + i__ * a_dim1];
	    a[k + i__ + i__ * a_dim1] = 1.0;

    /*        Compute  Y(K+1:N,I) */

	    i__2 = n - k;
	    i__3 = n - k - i__ + 1;
	    dgemv('N', i__2, i__3, c_b5, &a[k + 1 + (i__ + 1) * 
		    a_dim1], lda, &a[k + i__ + i__ * a_dim1], c__1, c_b38, &y[
		    k + 1 + i__ * y_dim1], c__1);
	    i__2 = n - k - i__ + 1;
	    i__3 = i__ - 1;
	    dgemv('T', i__2, i__3, c_b5, &a[k + i__ + a_dim1], lda, &
		    a[k + i__ + i__ * a_dim1], c__1, c_b38, &t[i__ * t_dim1 + 
		    1], c__1);
	    i__2 = n - k;
	    i__3 = i__ - 1;
	    dgemv('N', i__2, i__3, c_b4, &y[k + 1 + y_dim1], ldy, 
		    &t[i__ * t_dim1 + 1], c__1, c_b5, &y[k + 1 + i__ * y_dim1], 
		     c__1);
	    i__2 = n - k;
	    dscal(i__2, tau[i__], &y[k + 1 + i__ * y_dim1], c__1);

    /*        Compute T(1:I,I) */

	    i__2 = i__ - 1;
	    d__1 = -tau[i__];
	    dscal(i__2, d__1, &t[i__ * t_dim1 + 1], c__1);
	    i__2 = i__ - 1;
	    dtrmv('U', 'N', 'N', i__2, &t[t_offset], ldt, 
		    &t[i__ * t_dim1 + 1], c__1)
		    ;
	    t[i__ + i__ * t_dim1] = tau[i__];

    /* L10: */
        }
        a[k + nb + nb * a_dim1] = ei;

    /*     Compute Y(1:K,1:NB) */

        dlacpy('A', k, nb, &a[(a_dim1 << 1) + 1], lda, &y[y_offset], ldy);
        dtrmm('R', 'L', 'N', 'U', k, nb, c_b5, &a[k + 1 
	        + a_dim1], lda, &y[y_offset], ldy);
        if (n > k + nb) {
	    i__1 = n - k - nb;
	    dgemm('N', 'N', k, nb, i__1, c_b5, &a[(nb + 
		    2) * a_dim1 + 1], lda, &a[k + 1 + nb + a_dim1], lda, c_b5, 
		    &y[y_offset], ldy);
        }
        dtrmm('R', 'U', 'N', 'N', k, nb, c_b5, &t[
	        t_offset], ldt, &y[y_offset], ldy);

        return 0;
    }
}

