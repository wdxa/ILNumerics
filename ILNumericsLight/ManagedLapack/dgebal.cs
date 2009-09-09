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
    public static unsafe int dgebal(char job, int n, double *a, int lda, ref int ilo, ref int ihi, double *scale, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;
        double d__1, d__2;

        /* Local variables */
        double c__, f, g;
        int i__, j, k, l, m;
        double r__, s, ca, ra;
        int ica, ira, iexc;
        double sfmin1, sfmin2, sfmax1, sfmax2;
        bool noconv;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --scale;

        /* Function Body */
        info = 0;
        if (! lsame(job, 'N') && ! lsame(job, 'P') && ! lsame(job, 'S') 
	        && ! lsame(job, 'B')) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (lda < max(1,n)) {
	    info = -4;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEBAL", i__1);
	    return 0;
        }

        k = 1;
        l = n;

        if (n == 0) {
	    goto L210;
        }

        if (lsame(job, 'N')) {
	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        scale[i__] = 1.0;
    /* L10: */
	    }
	    goto L210;
        }

        if (lsame(job, 'S')) {
	    goto L120;
        }

    /*     Permutation to isolate eigenvalues if possible */

        goto L50;

    /*     Row and column exchange. */

    L20:
        scale[m] = (double) j;
        if (j == m) {
	    goto L30;
        }

        dswap(l, &a[j * a_dim1 + 1], c__1, &a[m * a_dim1 + 1], c__1);
        i__1 = n - k + 1;
        dswap(i__1, &a[j + k * a_dim1], lda, &a[m + k * a_dim1], lda);

    L30:
        switch (iexc) {
	    case 1:  goto L40;
	    case 2:  goto L80;
        }

    /*     Search for rows isolating an eigenvalue and push them down. */

    L40:
        if (l == 1) {
	    goto L210;
        }
        --l;

    L50:
        for (j = l; j >= 1; --j) {

	    i__1 = l;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        if (i__ == j) {
		    goto L60;
	        }
	        if (a[j + i__ * a_dim1] != 0.0) {
		    goto L70;
	        }
    L60:
	        ;
	    }

	    m = l;
	    iexc = 1;
	    goto L20;
    L70:
	    ;
        }

        goto L90;

    /*     Search for columns isolating an eigenvalue and push them left. */

    L80:
        ++k;

    L90:
        i__1 = l;
        for (j = k; j <= i__1; ++j) {

	    i__2 = l;
	    for (i__ = k; i__ <= i__2; ++i__) {
	        if (i__ == j) {
		    goto L100;
	        }
	        if (a[i__ + j * a_dim1] != 0.0) {
		    goto L110;
	        }
    L100:
	        ;
	    }

	    m = k;
	    iexc = 2;
	    goto L20;
    L110:
	    ;
        }

    L120:
        i__1 = l;
        for (i__ = k; i__ <= i__1; ++i__) {
	    scale[i__] = 1.0;
    /* L130: */
        }

        if (lsame(job, 'P')) {
	    goto L210;
        }

    /*     Balance the submatrix in rows K to L. */

    /*     Iterative loop for norm reduction */

        sfmin1 = dlamch('S') / dlamch('P');
        sfmax1 = 1.0 / sfmin1;
        sfmin2 = sfmin1 * 2.0;
        sfmax2 = 1.0 / sfmin2;
    L140:
        noconv = false;

        i__1 = l;
        for (i__ = k; i__ <= i__1; ++i__) {
	    c__ = 0.0;
	    r__ = 0.0;

	    i__2 = l;
	    for (j = k; j <= i__2; ++j) {
	        if (j == i__) {
		    goto L150;
	        }
            d__1 = a[j + i__ * a_dim1];
	        c__ += (abs(d__1));
            d__1 = a[i__ + j * a_dim1];
	        r__ += (abs(d__1));
    L150:
	        ;
	    }
	    ica = idamax(l, &a[i__ * a_dim1 + 1], c__1);
        d__1 = a[ica + i__ * a_dim1];
	    ca = (abs(d__1));
	    i__2 = n - k + 1;
	    ira = idamax(i__2, &a[i__ + k * a_dim1], lda);
        d__1 = a[i__ + (ira + k - 1) * a_dim1];
	    ra = (abs(d__1));

    /*        Guard against zero C or R due to underflow. */

	    if (c__ == 0.0 || r__ == 0.0) {
	        goto L200;
	    }
	    g = r__ / 2.0;
	    f = 1.0;
	    s = c__ + r__;
    L160:
    /* Computing MAX */
	    d__1 = max(f,c__);
    /* Computing MIN */
	    d__2 = min(r__,g);
	    if (c__ >= g || max(d__1,ca) >= sfmax2 || min(d__2,ra) <= sfmin2) {
	        goto L170;
	    }
	    f *= 2.0;
	    c__ *= 2.0;
	    ca *= 2.0;
	    r__ /= 2.0;
	    g /= 2.0;
	    ra /= 2.0;
	    goto L160;

    L170:
	    g = c__ / 2.0;
    L180:
        /* Computing MIN */
        d__1 = min(f, c__); d__1 = min(d__1, g);
	    if (g < r__ || max(r__,ra) >= sfmax2 || min(d__1,ca) <= sfmin2) {
	        goto L190;
	    }
	    f /= 2.0;
	    c__ /= 2.0;
	    g /= 2.0;
	    ca /= 2.0;
	    r__ *= 2.0;
	    ra *= 2.0;
	    goto L180;

    /*        Now balance. */

    L190:
	    if (c__ + r__ >= s * .95) {
	        goto L200;
	    }
	    if (f < 1.0 && scale[i__] < 1.0) {
	        if (f * scale[i__] <= sfmin1) {
		    goto L200;
	        }
	    }
	    if (f > 1.0 && scale[i__] > 1.0) {
	        if (scale[i__] >= sfmax1 / f) {
		    goto L200;
	        }
	    }
	    g = 1.0 / f;
	    scale[i__] *= f;
	    noconv = true;

	    i__2 = n - k + 1;
	    dscal(i__2, g, &a[i__ + k * a_dim1], lda);
	    dscal(l, f, &a[i__ * a_dim1 + 1], c__1);

    L200:
	    ;
        }

        if (noconv) {
	    goto L140;
        }

    L210:
        ilo = k;
        ihi = l;

        return 0;
    }
}

