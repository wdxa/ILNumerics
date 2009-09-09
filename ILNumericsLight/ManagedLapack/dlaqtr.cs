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
    public static unsafe int dlaqtr(bool ltran, bool lreal, int n, double *t, int ldt,
        double *b, double w, ref double scale, double *x, double *work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const bool c_false = false;
        const int c__2 = 2;
        const double c_b21 = 1.0;
        const double c_b25 = 0.0;
        const bool c_true = true;

        /* System generated locals */
        int t_dim1, t_offset, i__1, i__2;
        double d__1, d__2, d__3, d__4, d__5, d__6;

        /* Local variables */
        double* d__ = stackalloc double[4];
        int i__, j, k;
        double* v = stackalloc double[4];
        double z__;
        int j1, j2, n1, n2;
        double si=0, xj, sr=0, rec, eps, tjj, tmp;
        int ierr=0;
        double smin, xmax;
        int jnext;
        double sminw, xnorm;
        double scaloc=0;
        double bignum;
        bool notran;
        double smlnum;

        /* Parameter adjustments */
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        --b;
        --x;
        --work;

        /* Function Body */
        notran = ! (ltran);
        info = 0;

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }

    /*     Set constants to control overflow */

        eps = dlamch('P');
        smlnum = dlamch('S') / eps;
        bignum = 1.0 / smlnum;

        xnorm = dlange('M', n, n, &t[t_offset], ldt, d__);
        if (! (lreal)) {
    /* Computing MAX */
	    d__1 = xnorm; d__2 = abs(w); d__1 = max(d__1,d__2);
        d__2 = dlange('M', n, c__1, &b[1], n, d__);
	    xnorm = max(d__1,d__2);
        }
    /* Computing MAX */
        d__1 = smlnum; d__2 = eps * xnorm;
        smin = max(d__1,d__2);

    /*     Compute 1-norm of each column of strictly upper triangular */
    /*     part of T to control overflow in triangular solver. */

        work[1] = 0.0;
        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    i__2 = j - 1;
	    work[j] = dasum(i__2, &t[j * t_dim1 + 1], c__1);
    /* L10: */
        }

        if (! (lreal)) {
	    i__1 = n;
	    for (i__ = 2; i__ <= i__1; ++i__) {
            d__1 = b[i__];
	        work[i__] += ( abs(d__1));
    /* L20: */
	    }
        }

        n2 = n << 1;
        n1 = n;
        if (! (lreal)) {
	    n1 = n2;
        }
        k = idamax(n1, &x[1], c__1);
        d__1 = x[k];
        xmax = ( abs(d__1));
        scale = 1.0;

        if (xmax > bignum) {
	    scale = bignum / xmax;
	    dscal(n1, scale, &x[1], c__1);
	    xmax = bignum;
        }

        if (lreal) {

	    if (notran) {

    /*           Solve T*p = scale*c */

	        jnext = n;
	        for (j = n; j >= 1; --j) {
		    if (j > jnext) {
		        goto L30;
		    }
		    j1 = j;
		    j2 = j;
		    jnext = j - 1;
		    if (j > 1) {
		        if (t[j + (j - 1) * t_dim1] != 0.0) {
			    j1 = j - 1;
			    jnext = j - 2;
		        }
		    }

		    if (j1 == j2) {

    /*                 Meet 1 by 1 diagonal block */

    /*                 Scale to avoid overflow when computing */
    /*                     x(j) = b(j)/T(j,j) */

                d__1 = x[j1];
		        xj = ( abs(d__1));
                d__1 = t[j1 + j1 * t_dim1];
		        tjj = ( abs(d__1));
		        tmp = t[j1 + j1 * t_dim1];
		        if (tjj < smin) {
			    tmp = smin;
			    tjj = smin;
			    info = 1;
		        }

		        if (xj == 0.0) {
			    goto L30;
		        }

		        if (tjj < 1.0) {
			    if (xj > bignum * tjj) {
			        rec = 1.0 / xj;
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }
                d__1 = x[j1];
		        x[j1] /= tmp;
		        xj = ( abs(d__1));

    /*                 Scale x if necessary to avoid overflow when adding a */
    /*                 multiple of column j1 of T. */

		        if (xj > 1.0) {
			    rec = 1.0 / xj;
			    if (work[j1] > (bignum - xmax) * rec) {
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			    }
		        }
		        if (j1 > 1) {
			    i__1 = j1 - 1;
			    d__1 = -x[j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[1]
    , c__1);
			    i__1 = j1 - 1;
			    k = idamax(i__1, &x[1], c__1);
                d__1 = x[k];
			    xmax = ( abs(d__1));
		        }

		    } else {

    /*                 Meet 2 by 2 diagonal block */

    /*                 Call 2 by 2 linear system solve, to take */
    /*                 care of possible overflow by scaling factor. */

		        d__[0] = x[j1];
		        d__[1] = x[j2];
		        dlaln2(c_false, c__2, c__1, smin, c_b21, &t[j1 + j1 
			        * t_dim1], ldt, c_b21, c_b21, d__, c__2, 
			        c_b25, c_b25, v, c__2, ref scaloc, ref xnorm, ref ierr);
		        if (ierr != 0) {
			    info = 2;
		        }

		        if (scaloc != 1.0) {
			    dscal(n, scaloc, &x[1], c__1);
			    scale *= scaloc;
		        }
		        x[j1] = v[0];
		        x[j2] = v[1];

    /*                 Scale V(1,1) (= X(J1)) and/or V(2,1) (=X(J2)) */
    /*                 to avoid overflow in updating right-hand side. */

    /* Computing MAX */
		        d__1 = abs(v[0]); d__2 = abs(v[1]);
		        xj = max(d__1,d__2);
		        if (xj > 1.0) {
			    rec = 1.0 / xj;
    /* Computing MAX */
			    d__1 = work[j1]; d__2 = work[j2];
			    if (max(d__1,d__2) > (bignum - xmax) * rec) {
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			    }
		        }

    /*                 Update right-hand side */

		        if (j1 > 1) {
			    i__1 = j1 - 1;
			    d__1 = -x[j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[1]
    , c__1);
			    i__1 = j1 - 1;
			    d__1 = -x[j2];
			    daxpy(i__1, d__1, &t[j2 * t_dim1 + 1], c__1, &x[1]
    , c__1);
			    i__1 = j1 - 1;
			    k = idamax(i__1, &x[1], c__1);
                d__1 = x[k];
			    xmax = ( abs(d__1));
		        }

		    }

    L30:
		    ;
	        }

	    } else {

    /*           Solve T'*p = scale*c */

	        jnext = 1;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (j < jnext) {
		        goto L40;
		    }
		    j1 = j;
		    j2 = j;
		    jnext = j + 1;
		    if (j < n) {
		        if (t[j + 1 + j * t_dim1] != 0.0) {
			    j2 = j + 1;
			    jnext = j + 2;
		        }
		    }

		    if (j1 == j2) {

    /*                 1 by 1 diagonal block */

    /*                 Scale if necessary to avoid overflow in forming the */
    /*                 right-hand side element by inner product. */

                d__1 = x[j1];
		        xj = (abs(d__1));
		        if (xmax > 1.0) {
			    rec = 1.0 / xmax;
			    if (work[j1] > (bignum - xj) * rec) {
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }

		        i__2 = j1 - 1;
		        x[j1] -= ddot(i__2, &t[j1 * t_dim1 + 1], c__1, &x[1], 
			        c__1);

                d__1 = x[j1];
		        xj = ( abs(d__1));
                d__1 = t[j1 + j1 * t_dim1];
		        tjj = ( abs(d__1));
		        tmp = t[j1 + j1 * t_dim1];
		        if (tjj < smin) {
			    tmp = smin;
			    tjj = smin;
			    info = 1;
		        }

		        if (tjj < 1.0) {
			    if (xj > bignum * tjj) {
			        rec = 1.0 / xj;
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }
		        x[j1] /= tmp;
    /* Computing MAX */
                d__1 = x[j1];
		        d__2 = xmax; d__3 = ( abs(d__1));
		        xmax = max(d__2,d__3);

		    } else {

    /*                 2 by 2 diagonal block */

    /*                 Scale if necessary to avoid overflow in forming the */
    /*                 right-hand side elements by inner product. */

    /* Computing MAX */
                d__1 = x[j1];
                d__2 = x[j2];
		        d__3 = ( abs(d__1)); d__4 = ( abs(d__2));
		        xj = max(d__3,d__4);
		        if (xmax > 1.0) {
			    rec = 1.0 / xmax;
    /* Computing MAX */
			    d__1 = work[j2]; d__2 = work[j1];
			    if (max(d__1,d__2) > (bignum - xj) * rec) {
			        dscal(n, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }

		        i__2 = j1 - 1;
		        d__[0] = x[j1] - ddot(i__2, &t[j1 * t_dim1 + 1], c__1, 
			        &x[1], c__1);
		        i__2 = j1 - 1;
		        d__[1] = x[j2] - ddot(i__2, &t[j2 * t_dim1 + 1], c__1, 
			        &x[1], c__1);

		        dlaln2(c_true, c__2, c__1, smin, c_b21, &t[j1 + j1 *
			         t_dim1], ldt, c_b21, c_b21, d__, c__2, c_b25, 
			         c_b25, v, c__2, ref scaloc, ref xnorm, ref ierr);
		        if (ierr != 0) {
			    info = 2;
		        }

		        if (scaloc != 1.0) {
			    dscal(n, scaloc, &x[1], c__1);
			    scale *= scaloc;
		        }
		        x[j1] = v[0];
		        x[j2] = v[1];
    /* Computing MAX */
                d__1 = x[j1];
		        d__3 = ( abs(d__1));
                d__2 = x[j2];
                d__4 = (abs(d__2)); d__3 = max(d__3,d__4);
		        xmax = max(d__3,xmax);

		    }
    L40:
		    ;
	        }
	    }

        } else {

    /* Computing MAX */
	    d__1 = eps * abs(w);
	    sminw = max(d__1,smin);
	    if (notran) {

    /*           Solve (T + iB)*(p+iq) = c+id */

	        jnext = n;
	        for (j = n; j >= 1; --j) {
		    if (j > jnext) {
		        goto L70;
		    }
		    j1 = j;
		    j2 = j;
		    jnext = j - 1;
		    if (j > 1) {
		        if (t[j + (j - 1) * t_dim1] != 0.0) {
			    j1 = j - 1;
			    jnext = j - 2;
		        }
		    }

		    if (j1 == j2) {

    /*                 1 by 1 diagonal block */

    /*                 Scale if necessary to avoid overflow in division */

		        z__ = w;
		        if (j1 == 1) {
			    z__ = b[1];
		        }
                d__1 = x[j1];
                d__2 = x[n + j1];
		        xj = (abs(d__1)) + (abs( d__2));
                d__1 = t[j1 + j1 * t_dim1];
		        tjj = ( abs(d__1)) + abs(z__);
		        tmp = t[j1 + j1 * t_dim1];
		        if (tjj < sminw) {
			    tmp = sminw;
			    tjj = sminw;
			    info = 1;
		        }

		        if (xj == 0.0) {
			    goto L70;
		        }

		        if (tjj < 1.0) {
			    if (xj > bignum * tjj) {
			        rec = 1.0 / xj;
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }
		        dladiv(x[j1], x[n + j1], tmp, z__, ref sr, ref si);
		        x[j1] = sr;
		        x[n + j1] = si;
                d__1 = x[j1];
                d__2 = x[n + j1];
		        xj = ( abs(d__1)) + ( abs( d__2));

    /*                 Scale x if necessary to avoid overflow when adding a */
    /*                 multiple of column j1 of T. */

		        if (xj > 1.0) {
			    rec = 1.0 / xj;
			    if (work[j1] > (bignum - xmax) * rec) {
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			    }
		        }

		        if (j1 > 1) {
			    i__1 = j1 - 1;
			    d__1 = -x[j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[1], c__1);
			    i__1 = j1 - 1;
			    d__1 = -x[n + j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[
				    n + 1], c__1);

			    x[1] += b[j1] * x[n + j1];
			    x[n + 1] -= b[j1] * x[j1];

			    xmax = 0.0;
			    i__1 = j1 - 1;
			    for (k = 1; k <= i__1; ++k) {
    /* Computing MAX */
			        d__3 = xmax;
                    d__1 = x[k];
                    d__2 = x[k + n];
                    d__4 = ( abs(d__1)) + ( abs(d__2));
			        xmax = max(d__3,d__4);
    /* L50: */
			    }
		        }

		    } else {

    /*                 Meet 2 by 2 diagonal block */

		        d__[0] = x[j1];
		        d__[1] = x[j2];
		        d__[2] = x[n + j1];
		        d__[3] = x[n + j2];
		        d__1 = -(w);
		        dlaln2(c_false, c__2, c__2, sminw, c_b21, &t[j1 + 
			        j1 * t_dim1], ldt, c_b21, c_b21, d__, c__2, 
			        c_b25, d__1, v, c__2, ref scaloc, ref xnorm, ref ierr);
		        if (ierr != 0) {
			    info = 2;
		        }

		        if (scaloc != 1.0) {
			    i__1 = n << 1;
			    dscal(i__1, scaloc, &x[1], c__1);
			    scale = scaloc * scale;
		        }
		        x[j1] = v[0];
		        x[j2] = v[1];
		        x[n + j1] = v[2];
		        x[n + j2] = v[3];

    /*                 Scale X(J1), .... to avoid overflow in */
    /*                 updating right hand side. */

    /* Computing MAX */
		        d__1 = abs(v[0]) + abs(v[2]); d__2 = abs(v[1]) + abs(v[3])
			        ;
		        xj = max(d__1,d__2);
		        if (xj > 1.0) {
			    rec = 1.0 / xj;
    /* Computing MAX */
			    d__1 = work[j1]; d__2 = work[j2];
			    if (max(d__1,d__2) > (bignum - xmax) * rec) {
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			    }
		        }

    /*                 Update the right-hand side. */

		        if (j1 > 1) {
			    i__1 = j1 - 1;
			    d__1 = -x[j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[1]
    , c__1);
			    i__1 = j1 - 1;
			    d__1 = -x[j2];
			    daxpy(i__1, d__1, &t[j2 * t_dim1 + 1], c__1, &x[1]
    , c__1);

			    i__1 = j1 - 1;
			    d__1 = -x[n + j1];
			    daxpy(i__1, d__1, &t[j1 * t_dim1 + 1], c__1, &x[
				    n + 1], c__1);
			    i__1 = j1 - 1;
			    d__1 = -x[n + j2];
			    daxpy(i__1, d__1, &t[j2 * t_dim1 + 1], c__1, &x[
				    n + 1], c__1);

			    x[1] = x[1] + b[j1] * x[n + j1] + b[j2] * x[n + j2];
			    x[n + 1] = x[n + 1] - b[j1] * x[j1] - b[j2] * x[j2];

			    xmax = 0.0;
			    i__1 = j1 - 1;
			    for (k = 1; k <= i__1; ++k) {
    /* Computing MAX */
                    d__1 = x[k];
                    d__2 = x[k + n];
			        d__3 = ( abs(d__1)) + ( abs(d__2));
			        xmax = max(d__3,xmax);
    /* L60: */
			    }
		        }

		    }
    L70:
		    ;
	        }

	    } else {

    /*           Solve (T + iB)'*(p+iq) = c+id */

	        jnext = 1;
	        i__1 = n;
	        for (j = 1; j <= i__1; ++j) {
		    if (j < jnext) {
		        goto L80;
		    }
		    j1 = j;
		    j2 = j;
		    jnext = j + 1;
		    if (j < n) {
		        if (t[j + 1 + j * t_dim1] != 0.0) {
			    j2 = j + 1;
			    jnext = j + 2;
		        }
		    }

		    if (j1 == j2) {

    /*                 1 by 1 diagonal block */

    /*                 Scale if necessary to avoid overflow in forming the */
    /*                 right-hand side element by inner product. */

                d__1 = x[j1];
                d__2 = x[j1 + n];
		        xj = (abs(d__1)) + ( abs(d__2));
		        if (xmax > 1.0) {
			    rec = 1.0 / xmax;
			    if (work[j1] > (bignum - xj) * rec) {
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }

		        i__2 = j1 - 1;
		        x[j1] -= ddot(i__2, &t[j1 * t_dim1 + 1], c__1, &x[1], 
			        c__1);
		        i__2 = j1 - 1;
		        x[n + j1] -= ddot(i__2, &t[j1 * t_dim1 + 1], c__1, &x[
			        n + 1], c__1);
		        if (j1 > 1) {
			    x[j1] -= b[j1] * x[n + 1];
			    x[n + j1] += b[j1] * x[1];
		        }
                d__1 = x[j1];
                d__2 = x[j1 + n];
		        xj = (abs(d__1)) + ( abs(d__2));

		        z__ = w;
		        if (j1 == 1) {
			    z__ = b[1];
		        }

    /*                 Scale if necessary to avoid overflow in */
    /*                 complex division */

                d__1 = t[j1 + j1 * t_dim1];
		        tjj = ( abs(d__1)) + abs(z__);
		        tmp = t[j1 + j1 * t_dim1];
		        if (tjj < sminw) {
			    tmp = sminw;
			    tjj = sminw;
			    info = 1;
		        }

		        if (tjj < 1.0) {
			    if (xj > bignum * tjj) {
			        rec = 1.0 / xj;
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }
		        d__1 = -z__;
		        dladiv(x[j1], x[n + j1], tmp, d__1, ref sr, ref si);
		        x[j1] = sr;
		        x[j1 + n] = si;
    /* Computing MAX */
                d__1 = x[j1];
                d__2 = x[j1 + n];
		        d__3 = ( abs(d__1)) + ( abs(d__2));
		        xmax = max(d__3,xmax);

		    } else {

    /*                 2 by 2 diagonal block */

    /*                 Scale if necessary to avoid overflow in forming the */
    /*                 right-hand side element by inner product. */

    /* Computing MAX */
                d__1 = x[j1];
                d__2 = x[n + j1];
		        d__5 = (abs(d__1)) + (abs(d__2));
                d__3 = x[j2];
                d__4 = x[n + j2];
                d__6 = ( abs(d__3)) + ( abs(d__4));
		        xj = max(d__5,d__6);
		        if (xmax > 1.0) {
			    rec = 1.0 / xmax;
    /* Computing MAX */
			    d__1 = work[j1]; d__2 = work[j2];
			    if (max(d__1,d__2) > (bignum - xj) / xmax) {
			        dscal(n2, rec, &x[1], c__1);
			        scale *= rec;
			        xmax *= rec;
			    }
		        }

		        i__2 = j1 - 1;
		        d__[0] = x[j1] - ddot(i__2, &t[j1 * t_dim1 + 1], c__1, 
			        &x[1], c__1);
		        i__2 = j1 - 1;
		        d__[1] = x[j2] - ddot(i__2, &t[j2 * t_dim1 + 1], c__1, 
			        &x[1], c__1);
		        i__2 = j1 - 1;
		        d__[2] = x[n + j1] - ddot(i__2, &t[j1 * t_dim1 + 1], 
			        c__1, &x[n + 1], c__1);
		        i__2 = j1 - 1;
		        d__[3] = x[n + j2] - ddot(i__2, &t[j2 * t_dim1 + 1], 
			        c__1, &x[n + 1], c__1);
		        d__[0] -= b[j1] * x[n + 1];
		        d__[1] -= b[j2] * x[n + 1];
		        d__[2] += b[j1] * x[1];
		        d__[3] += b[j2] * x[1];

		        dlaln2(c_true, c__2, c__2, sminw, c_b21, &t[j1 + j1 
			        * t_dim1], ldt, c_b21, c_b21, d__, c__2, 
			        c_b25, w, v, c__2, ref scaloc, ref xnorm, ref ierr);
		        if (ierr != 0) {
			    info = 2;
		        }

		        if (scaloc != 1.0) {
			    dscal(n2, scaloc, &x[1], c__1);
			    scale = scaloc * scale;
		        }
		        x[j1] = v[0];
		        x[j2] = v[1];
		        x[n + j1] = v[2];
		        x[n + j2] = v[3];
    /* Computing MAX */
                d__1 = x[j1];
                d__2 = x[n + j1];
		        d__5 = ( abs(d__1)) + (abs(d__2));
                d__3 = x[j2];
                d__4 = x[n + j2];
                d__6 = ( abs(d__3)) + (abs(d__4));
                d__5 = max(d__5,d__6);
		        xmax = max(d__5,xmax);

		    }

    L80:
		    ;
	        }

	    }

        }

        return 0;
    }
}

