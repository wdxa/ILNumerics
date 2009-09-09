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
    public static unsafe int dlahqr(bool wantt, bool wantz, int n, int ilo, int ihi, double *h__,
        int ldh, double *wr, double *wi, int iloz, int ihiz, double *z__, int ldz, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int h_dim1, h_offset, z_dim1, z_offset, i__1, i__2, i__3;
        double d__1, d__2, d__3, d__4;

        /* Local variables */
        int i__, j, k, l, m;
        double* v = stackalloc double[3];
        double s=0;
        int i1=0, i2=0;
        double t1=0, t2, t3, v2, v3, aa, ab, ba, bb, h11, h12, h21, h22, cs=0;
        int nh;
        double sn=0;
        int nr;
        double tr;
        int nz;
        double det, h21s;
        int its;
        double ulp, sum, tst, rt1i, rt2i, rt1r, rt2r;
        double safmin, safmax, rtdisc, smlnum;

        /* Parameter adjustments */
        h_dim1 = ldh;
        h_offset = 1 + h_dim1;
        h__ -= h_offset;
        --wr;
        --wi;
        z_dim1 = ldz;
        z_offset = 1 + z_dim1;
        z__ -= z_offset;

        /* Function Body */
        info = 0;

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }
        if (ilo == ihi) {
	    wr[ilo] = h__[ilo + ilo * h_dim1];
	    wi[ilo] = 0.0;
	    return 0;
        }

    /*     ==== clear out the trash ==== */
        i__1 = ihi - 3;
        for (j = ilo; j <= i__1; ++j) {
	    h__[j + 2 + j * h_dim1] = 0.0;
	    h__[j + 3 + j * h_dim1] = 0.0;
    /* L10: */
        }
        if (ilo <= ihi - 2) {
	    h__[ihi + (ihi - 2) * h_dim1] = 0.0;
        }

        nh = ihi - ilo + 1;
        nz = ihiz - iloz + 1;

    /*     Set machine-dependent constants for the stopping criterion. */

        safmin = dlamch('S');
        safmax = 1.0 / safmin;
        dlabad(ref safmin, ref safmax);
        ulp = dlamch('P');
        smlnum = safmin * ((double) nh / ulp);

    /*     I1 and I2 are the indices of the first row and last column of H */
    /*     to which transformations must be applied. If eigenvalues only are */
    /*     being computed, I1 and I2 are set inside the main loop. */

        if (wantt) {
	    i1 = 1;
	    i2 = n;
        }

    /*     The main loop begins here. I is the loop index and decreases from */
    /*     IHI to ILO in steps of 1 or 2. Each iteration of the loop works */
    /*     with the active submatrix in rows and columns L to I. */
    /*     Eigenvalues I+1 to IHI have already converged. Either L = ILO or */
    /*     H(L,L-1) is negligible so that the matrix splits. */

        i__ = ihi;
    L20:
        l = ilo;
        if (i__ < ilo) {
	    goto L160;
        }

    /*     Perform QR iterations on rows and columns ILO to I until a */
    /*     submatrix of order 1 or 2 splits off at the bottom because a */
    /*     subdiagonal element has become negligible. */

        for (its = 0; its <= 30; ++its) {

    /*        Look for a single small subdiagonal element. */

	    i__1 = l + 1;
	    for (k = i__; k >= i__1; --k) {
	        if ((abs(h__[k + (k - 1) * h_dim1])) <= smlnum) {
		    goto L40;
	        }
            d__2 = h__[k + k * h_dim1];
	        tst = (abs(h__[k - 1 + (k - 1) * h_dim1])) + (abs(d__2));
	        if (tst == 0.0) {
		    if (k - 2 >= ilo) {
                d__1 = h__[k - 1 + (k - 2) * h_dim1];
		        tst += (abs(d__1));
		    }
		    if (k + 1 <= ihi) {
                d__1 = h__[k + 1 + k * h_dim1];
		        tst += (abs(d__1));
		    }
	        }
    /*           ==== The following is a conservative small subdiagonal */
    /*           .    deflation  criterion due to Ahues & Tisseur (LAWN 122, */
    /*           .    1997). It has better mathematical foundation and */
    /*           .    improves accuracy in some cases.  ==== */
	        if ((abs(h__[k + (k - 1) * h_dim1])) <= ulp * tst) {
    /* Computing MAX */
		    d__3 = (abs(h__[k + (k - 1) * h_dim1]));
            d__2 = h__[k - 1 + k * h_dim1];
            d__4 = (abs(d__2));
		    ab = max(d__3,d__4);
    /* Computing MIN */
            d__1 = h__[k + (k - 1) * h_dim1];
		    d__3 = (abs(d__1));
            d__2 = h__[k - 1 + k * h_dim1];
            d__4 = (abs(d__2));
		    ba = min(d__3,d__4);
    /* Computing MAX */
            d__1 = h__[k + k * h_dim1];
		    d__3 = (abs(d__1));
            d__2 = h__[k - 1 + (k - 1) * h_dim1] - h__[k + k * h_dim1];
            d__4 = (  abs(d__2));
		    aa = max(d__3,d__4);
    /* Computing MIN */
            d__1 = h__[k + k * h_dim1];
		    d__3 = (abs(d__1));
            d__2 = h__[k - 1 + (k - 1) * h_dim1] - h__[k + k * h_dim1];
            d__4 = (abs(d__2));
		    bb = min(d__3,d__4);
		    s = aa + ab;
    /* Computing MAX */
		    d__1 = smlnum; d__2 = ulp * (bb * (aa / s));
		    if (ba * (ab / s) <= max(d__1,d__2)) {
		        goto L40;
		    }
	        }
    /* L30: */
	    }
    L40:
	    l = k;
	    if (l > ilo) {

    /*           H(L,L-1) is negligible */

	        h__[l + (l - 1) * h_dim1] = 0.0;
	    }

    /*        Exit from loop if a submatrix of order 1 or 2 has split off. */

	    if (l >= i__ - 1) {
	        goto L150;
	    }

    /*        Now the active submatrix is in rows and columns L to I. If */
    /*        eigenvalues only are being computed, only the active submatrix */
    /*        need be transformed. */

	    if (! (wantt)) {
	        i1 = l;
	        i2 = i__;
	    }

	    if (its == 10 || its == 20) {

    /*           Exceptional shift. */

	        h11 = s * .75 + h__[i__ + i__ * h_dim1];
	        h12 = s * -.4375;
	        h21 = s;
	        h22 = h11;
	    } else {

    /*           Prepare to use Francis' double shift */
    /*           (i.e. 2nd degree generalized Rayleigh quotient) */

	        h11 = h__[i__ - 1 + (i__ - 1) * h_dim1];
	        h21 = h__[i__ + (i__ - 1) * h_dim1];
	        h12 = h__[i__ - 1 + i__ * h_dim1];
	        h22 = h__[i__ + i__ * h_dim1];
	    }
	    s = abs(h11) + abs(h12) + abs(h21) + abs(h22);
	    if (s == 0.0) {
	        rt1r = 0.0;
	        rt1i = 0.0;
	        rt2r = 0.0;
	        rt2i = 0.0;
	    } else {
	        h11 /= s;
	        h21 /= s;
	        h12 /= s;
	        h22 /= s;
	        tr = (h11 + h22) / 2.0;
	        det = (h11 - tr) * (h22 - tr) - h12 * h21;
	        rtdisc = sqrt((abs(det)));
	        if (det >= 0.0) {

    /*              ==== complex conjugate shifts ==== */

		    rt1r = tr * s;
		    rt2r = rt1r;
		    rt1i = rtdisc * s;
		    rt2i = -rt1i;
	        } else {

    /*              ==== real shifts (use only one of them)  ==== */

		    rt1r = tr + rtdisc;
		    rt2r = tr - rtdisc;
		    if ((abs(rt1r - h22)) <= (abs(rt2r - h22))) {
		        rt1r *= s;
		        rt2r = rt1r;
		    } else {
		        rt2r *= s;
		        rt1r = rt2r;
		    }
		    rt1i = 0.0;
		    rt2i = 0.0;
	        }
	    }

    /*        Look for two consecutive small subdiagonal elements. */

	    i__1 = l;
	    for (m = i__ - 2; m >= i__1; --m) {
    /*           Determine the effect of starting the double-shift QR */
    /*           iteration at row M, and see if this would make H(M,M-1) */
    /*           negligible.  (The following uses scaling to avoid */
    /*           overflows and most underflows.) */

	        h21s = h__[m + 1 + m * h_dim1];
            d__1 = h__[m + m * h_dim1] - rt2r;
	        s = (abs(d__1)) + abs(rt2i) + abs(h21s);
	        h21s = h__[m + 1 + m * h_dim1] / s;
	        v[0] = h21s * h__[m + (m + 1) * h_dim1] + (h__[m + m * h_dim1] - 
		        rt1r) * ((h__[m + m * h_dim1] - rt2r) / s) - rt1i * (rt2i 
		        / s);
	        v[1] = h21s * (h__[m + m * h_dim1] + h__[m + 1 + (m + 1) * h_dim1]
		         - rt1r - rt2r);
	        v[2] = h21s * h__[m + 2 + (m + 1) * h_dim1];
	        s = abs(v[0]) + abs(v[1]) + abs(v[2]);
	        v[0] /= s;
	        v[1] /= s;
	        v[2] /= s;
	        if (m == l) {
		    goto L60;
	        }
	        if ((abs(h__[m + (m - 1) * h_dim1])) * (abs(v[1]) + 
		    abs(v[2])) <= ulp * abs(v[0]) * ((abs(h__[m - 1 + (m - 
		    1) * h_dim1])) + (abs(h__[m + m * h_dim1])) + (abs(
		    h__[m + 1 + (m + 1) * h_dim1])))) {
		    goto L60;
	        }
    /* L50: */
	    }
    L60:

    /*        Double-shift QR step */

	    i__1 = i__ - 1;
	    for (k = m; k <= i__1; ++k) {

    /*           The first iteration of this loop determines a reflection G */
    /*           from the vector V and applies it from left and right to H, */
    /*           thus creating a nonzero bulge below the subdiagonal. */

    /*           Each subsequent iteration determines a reflection G to */
    /*           restore the Hessenberg form in the (K-1)th column, and thus */
    /*           chases the bulge one step toward the bottom of the active */
    /*           submatrix. NR is the order of G. */

    /* Computing MIN */
            i__2 = 3;  i__3 = i__ - k + 1;
	        nr = min(i__2,i__3);
	        if (k > m) {
		    dcopy(nr, &h__[k + (k - 1) * h_dim1], c__1, v, c__1);
	        }
	        dlarfg(nr, ref v[0], &v[1], c__1, ref t1);
	        if (k > m) {
		    h__[k + (k - 1) * h_dim1] = v[0];
		    h__[k + 1 + (k - 1) * h_dim1] = 0.0;
		    if (k < i__ - 1) {
		        h__[k + 2 + (k - 1) * h_dim1] = 0.0;
		    }
	        } else if (m > l) {
		    h__[k + (k - 1) * h_dim1] = -h__[k + (k - 1) * h_dim1];
	        }
	        v2 = v[1];
	        t2 = t1 * v2;
	        if (nr == 3) {
		    v3 = v[2];
		    t3 = t1 * v3;

    /*              Apply G from the left to transform the rows of the matrix */
    /*              in columns K to I2. */

		    i__2 = i2;
		    for (j = k; j <= i__2; ++j) {
		        sum = h__[k + j * h_dim1] + v2 * h__[k + 1 + j * h_dim1] 
			        + v3 * h__[k + 2 + j * h_dim1];
		        h__[k + j * h_dim1] -= sum * t1;
		        h__[k + 1 + j * h_dim1] -= sum * t2;
		        h__[k + 2 + j * h_dim1] -= sum * t3;
    /* L70: */
		    }

    /*              Apply G from the right to transform the columns of the */
    /*              matrix in rows I1 to min(K+3,I). */

    /* Computing MIN */
		    i__3 = k + 3;
		    i__2 = min(i__3,i__);
		    for (j = i1; j <= i__2; ++j) {
		        sum = h__[j + k * h_dim1] + v2 * h__[j + (k + 1) * h_dim1]
			         + v3 * h__[j + (k + 2) * h_dim1];
		        h__[j + k * h_dim1] -= sum * t1;
		        h__[j + (k + 1) * h_dim1] -= sum * t2;
		        h__[j + (k + 2) * h_dim1] -= sum * t3;
    /* L80: */
		    }

		    if (wantz) {

    /*                 Accumulate transformations in the matrix Z */

		        i__2 = ihiz;
		        for (j = iloz; j <= i__2; ++j) {
			    sum = z__[j + k * z_dim1] + v2 * z__[j + (k + 1) * 
				    z_dim1] + v3 * z__[j + (k + 2) * z_dim1];
			    z__[j + k * z_dim1] -= sum * t1;
			    z__[j + (k + 1) * z_dim1] -= sum * t2;
			    z__[j + (k + 2) * z_dim1] -= sum * t3;
    /* L90: */
		        }
		    }
	        } else if (nr == 2) {

    /*              Apply G from the left to transform the rows of the matrix */
    /*              in columns K to I2. */

		    i__2 = i2;
		    for (j = k; j <= i__2; ++j) {
		        sum = h__[k + j * h_dim1] + v2 * h__[k + 1 + j * h_dim1];
		        h__[k + j * h_dim1] -= sum * t1;
		        h__[k + 1 + j * h_dim1] -= sum * t2;
    /* L100: */
		    }

    /*              Apply G from the right to transform the columns of the */
    /*              matrix in rows I1 to min(K+3,I). */

		    i__2 = i__;
		    for (j = i1; j <= i__2; ++j) {
		        sum = h__[j + k * h_dim1] + v2 * h__[j + (k + 1) * h_dim1]
			        ;
		        h__[j + k * h_dim1] -= sum * t1;
		        h__[j + (k + 1) * h_dim1] -= sum * t2;
    /* L110: */
		    }

		    if (wantz) {

    /*                 Accumulate transformations in the matrix Z */

		        i__2 = ihiz;
		        for (j = iloz; j <= i__2; ++j) {
			    sum = z__[j + k * z_dim1] + v2 * z__[j + (k + 1) * 
				    z_dim1];
			    z__[j + k * z_dim1] -= sum * t1;
			    z__[j + (k + 1) * z_dim1] -= sum * t2;
    /* L120: */
		        }
		    }
	        }
    /* L130: */
	    }

    /* L140: */
        }

    /*     Failure to converge in remaining number of iterations */

        info = i__;
        return 0;

    L150:

        if (l == i__) {

    /*        H(I,I-1) is negligible: one eigenvalue has converged. */

	    wr[i__] = h__[i__ + i__ * h_dim1];
	    wi[i__] = 0.0;
        } else if (l == i__ - 1) {

    /*        H(I-1,I-2) is negligible: a pair of eigenvalues have converged. */

    /*        Transform the 2-by-2 submatrix to standard Schur form, */
    /*        and compute and store the eigenvalues. */

	    dlanv2(ref h__[i__ - 1 + (i__ - 1) * h_dim1], ref h__[i__ - 1 + i__ * 
		    h_dim1], ref h__[i__ + (i__ - 1) * h_dim1], ref h__[i__ + i__ * 
		    h_dim1], ref wr[i__ - 1], ref wi[i__ - 1], ref wr[i__], ref wi[i__], ref cs, 
		    ref sn);

	    if (wantt) {

    /*           Apply the transformation to the rest of H. */

	        if (i2 > i__) {
		    i__1 = i2 - i__;
		    drot(i__1, &h__[i__ - 1 + (i__ + 1) * h_dim1], ldh, &h__[
			    i__ + (i__ + 1) * h_dim1], ldh, cs, sn);
	        }
	        i__1 = i__ - i1 - 1;
	        drot(i__1, &h__[i1 + (i__ - 1) * h_dim1], c__1, &h__[i1 + i__ *
		         h_dim1], c__1, cs, sn);
	    }
	    if (wantz) {

    /*           Apply the transformation to Z. */

	        drot(nz, &z__[iloz + (i__ - 1) * z_dim1], c__1, &z__[iloz + 
		        i__ * z_dim1], c__1, cs, sn);
	    }
        }

    /*     return to start of the main loop with new value of I. */

        i__ = l - 1;
        goto L20;

    L160:
        return 0;
    }
}

