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
    public static unsafe int dlasy2(bool ltranl, bool ltranr, int isgn, int n1, int n2, double* tl, int ldtl,
        double* tr, int ldtr, double* b, int ldb, ref double scale, double* x, int ldx, ref double xnorm, ref int info)
    {
        /* Table of constant values */
        const int c__4 = 4;
        const int c__1 = 1;
        const int c__16 = 16;
        const int c__0 = 0;

        /* Initialized data */
        int[] locu12 = { 3,4,1,2 };
        int[] locl21 = { 2,1,4,3 };
        int[] locu22 = { 4,3,2,1 };
        bool[] xswpiv = { false,false,true,true };
        bool[] bswpiv = { false,true,false,true };

        /* System generated locals */
        int b_dim1, b_offset, tl_dim1, tl_offset, tr_dim1, tr_offset, x_dim1, 
	        x_offset;
        double d__1, d__2, d__3, d__4, d__5, d__6, d__7, d__8;

        /* Local variables */
        int i__, j, k;
        double* x2 = stackalloc double[2];
        double l21, u11, u12;
        int ip, jp;
        double* t16 = stackalloc double[16]	/* was [4][4] */;
        double* tmp = stackalloc double[4];
        double* btmp = stackalloc double[4];
        double u22, gam, bet, eps, sgn, tau1, smin;
        int ipiv;
        double temp;
        int* jpiv = stackalloc int[4];
        double xmax;
        int ipsv=0, jpsv=0;
        bool bswap;
        bool xswap;
        double smlnum;

        /* Parameter adjustments */
        tl_dim1 = ldtl;
        tl_offset = 1 + tl_dim1;
        tl -= tl_offset;
        tr_dim1 = ldtr;
        tr_offset = 1 + tr_dim1;
        tr -= tr_offset;
        b_dim1 = ldb;
        b_offset = 1 + b_dim1;
        b -= b_offset;
        x_dim1 = ldx;
        x_offset = 1 + x_dim1;
        x -= x_offset;

        /* Function Body */
    /*     .. */
    /*     .. Executable Statements .. */

    /*     Do not check the input parameters for errors */

        info = 0;

    /*     Quick return if possible */

        if (n1 == 0 || n2 == 0) {
	    return 0;
        }

    /*     Set constants to control overflow */

        eps = dlamch('P');
        smlnum = dlamch('S') / eps;
        sgn = (double) (isgn);

        k = n1 + n1 + n2 - 2;
        switch (k) {
	    case 1:  goto L10;
	    case 2:  goto L20;
	    case 3:  goto L30;
	    case 4:  goto L50;
        }

    /*     1 by 1: TL11*X + SGN*X*TR11 = B11 */

    L10:
        tau1 = tl[tl_dim1 + 1] + sgn * tr[tr_dim1 + 1];
        bet = abs(tau1);
        if (bet <= smlnum) {
	    tau1 = smlnum;
	    bet = smlnum;
	    info = 1;
        }

        scale = 1.0;
        d__1 = b[b_dim1 + 1];
        gam = (abs(d__1));
        if (smlnum * gam > bet) {
	    scale = 1.0 / gam;
        }

        x[x_dim1 + 1] = b[b_dim1 + 1] * scale / tau1;
        d__1 = x[x_dim1 + 1];
        xnorm = (abs(d__1));
        return 0;

    /*     1 by 2: */
    /*     TL11*[X11 X12] + ISGN*[X11 X12]*op[TR11 TR12]  = [B11 B12] */
    /*                                       [TR21 TR22] */

    L20:

    /* Computing MAX */
    /* Computing MAX */
        d__1 = tl[tl_dim1 + 1];
        d__7 = (abs(d__1));
        d__2 = tr[tr_dim1 + 1];
        d__8 = (abs(d__2));
        d__7 = max(d__7,d__8);
        d__3 = tr[(tr_dim1 << 1) + 1];
        d__8 = ( abs(d__3));
        d__7 = max(d__7,d__8);
        d__4 = tr[tr_dim1 + 2];
        d__8 = (abs(d__4));
        d__7 = max(d__7,d__8);
        d__5 = tr[(tr_dim1 << 1) + 2];
        d__8 = (abs(d__5));
        d__6 = eps * max(d__7,d__8);
        smin = max(d__6,smlnum);
        tmp[0] = tl[tl_dim1 + 1] + sgn * tr[tr_dim1 + 1];
        tmp[3] = tl[tl_dim1 + 1] + sgn * tr[(tr_dim1 << 1) + 2];
        if (ltranr) {
	    tmp[1] = sgn * tr[tr_dim1 + 2];
	    tmp[2] = sgn * tr[(tr_dim1 << 1) + 1];
        } else {
	    tmp[1] = sgn * tr[(tr_dim1 << 1) + 1];
	    tmp[2] = sgn * tr[tr_dim1 + 2];
        }
        btmp[0] = b[b_dim1 + 1];
        btmp[1] = b[(b_dim1 << 1) + 1];
        goto L40;

    /*     2 by 1: */
    /*          op[TL11 TL12]*[X11] + ISGN* [X11]*TR11  = [B11] */
    /*            [TL21 TL22] [X21]         [X21]         [B21] */

    L30:
    /* Computing MAX */
    /* Computing MAX */
        d__1 = tr[tr_dim1 + 1];
        d__7 = (abs(d__1));
        d__2 = tl[tl_dim1 + 1];
        d__8 = ( abs(d__2));
        d__7 = max(d__7,d__8);
        d__3 = tl[(tl_dim1 << 1) + 1];
        d__8 = (abs(d__3));
        d__7 = max(d__7,d__8);
        d__4 = tl[tl_dim1 + 2];
        d__8 = (abs(d__4));
        d__7 = max(d__7,d__8);
        d__5 = tl[(tl_dim1 << 1) + 2];
        d__8 = (abs(d__5));
        d__6 = eps * max(d__7,d__8);
        smin = max(d__6,smlnum);
        tmp[0] = tl[tl_dim1 + 1] + sgn * tr[tr_dim1 + 1];
        tmp[3] = tl[(tl_dim1 << 1) + 2] + sgn * tr[tr_dim1 + 1];
        if (ltranl) {
	    tmp[1] = tl[(tl_dim1 << 1) + 1];
	    tmp[2] = tl[tl_dim1 + 2];
        } else {
	    tmp[1] = tl[tl_dim1 + 2];
	    tmp[2] = tl[(tl_dim1 << 1) + 1];
        }
        btmp[0] = b[b_dim1 + 1];
        btmp[1] = b[b_dim1 + 2];
    L40:

    /*     Solve 2 by 2 system using complete pivoting. */
    /*     Set pivots less than SMIN to SMIN. */

        ipiv = idamax(c__4, tmp, c__1);
        u11 = tmp[ipiv - 1];
        if (abs(u11) <= smin) {
	    info = 1;
	    u11 = smin;
        }
        u12 = tmp[locu12[ipiv - 1] - 1];
        l21 = tmp[locl21[ipiv - 1] - 1] / u11;
        u22 = tmp[locu22[ipiv - 1] - 1] - u12 * l21;
        xswap = xswpiv[ipiv - 1];
        bswap = bswpiv[ipiv - 1];
        if (abs(u22) <= smin) {
	    info = 1;
	    u22 = smin;
        }
        if (bswap) {
	    temp = btmp[1];
	    btmp[1] = btmp[0] - l21 * temp;
	    btmp[0] = temp;
        } else {
	    btmp[1] -= l21 * btmp[0];
        }
        scale = 1.0;
        if (smlnum * 2.0 * abs(btmp[1]) > abs(u22) || smlnum * 2.0 * abs(btmp[0]) > 
	        abs(u11)) {
    /* Computing MAX */
        d__1 = abs(btmp[0]);
        d__2 = abs(btmp[1]);
	    scale = .5 / max(d__1,d__2);
	    btmp[0] *= scale;
	    btmp[1] *= scale;
        }
        x2[1] = btmp[1] / u22;
        x2[0] = btmp[0] / u11 - u12 / u11 * x2[1];
        if (xswap) {
	    temp = x2[1];
	    x2[1] = x2[0];
	    x2[0] = temp;
        }
        x[x_dim1 + 1] = x2[0];
        if (n1 == 1) {
	    x[(x_dim1 << 1) + 1] = x2[1];
        d__1 = x[x_dim1 + 1];
        d__2 = x[(x_dim1 << 1) + 1];
	    xnorm = (abs(d__1)) + (abs(d__2));
        } else {
	    x[x_dim1 + 2] = x2[1];
    /* Computing MAX */
        d__1 = x[x_dim1 + 1];
	    d__3 = (abs(d__1));
        d__4 = (abs(d__2));
        d__2 = x[x_dim1 + 2];
	    xnorm = max(d__3,d__4);
        }
        return 0;

    /*     2 by 2: */
    /*     op[TL11 TL12]*[X11 X12] +ISGN* [X11 X12]*op[TR11 TR12] = [B11 B12] */
    /*       [TL21 TL22] [X21 X22]        [X21 X22]   [TR21 TR22]   [B21 B22] */

    /*     Solve equivalent 4 by 4 system using complete pivoting. */
    /*     Set pivots less than SMIN to SMIN. */

    L50:
    /* Computing MAX */
        d__1 = tr[tr_dim1 + 1];
        d__5 = (abs(d__1));
        d__2 = tr[(tr_dim1 << 1) + 1];
        d__6 = (abs(d__2));
        d__5 = max(d__5,d__6);
        d__3 = tr[tr_dim1 + 2];
        d__6 = (abs(d__3));
        d__5 = max(d__5,d__6);
        d__4 = tr[(tr_dim1 << 1) + 2];
        d__6 = (abs(d__4));
        smin = max(d__5,d__6);
    /* Computing MAX */
        d__5 = smin;
        d__1 = tl[tl_dim1 + 1];
        d__6 = (abs(d__1));
        d__5 = max(d__5, d__6);
        d__2 = tl[(tl_dim1 << 1) + 1];
        d__6 = (abs(d__2));
        d__5 = max(d__5,d__6);
        d__3 = tl[tl_dim1 + 2];
        d__6 = (abs(d__3));
        d__5 = max(d__5,d__6);
        d__4 = tl[(tl_dim1 << 1) + 2];
        d__6 = (abs(d__4));
        smin = max(d__5,d__6);
    /* Computing MAX */
        d__1 = eps * smin;
        smin = max(d__1,smlnum);
        btmp[0] = 0.0;
        dcopy(c__16, btmp, c__0, t16, c__1);
        t16[0] = tl[tl_dim1 + 1] + sgn * tr[tr_dim1 + 1];
        t16[5] = tl[(tl_dim1 << 1) + 2] + sgn * tr[tr_dim1 + 1];
        t16[10] = tl[tl_dim1 + 1] + sgn * tr[(tr_dim1 << 1) + 2];
        t16[15] = tl[(tl_dim1 << 1) + 2] + sgn * tr[(tr_dim1 << 1) + 2];
        if (ltranl) {
	    t16[4] = tl[tl_dim1 + 2];
	    t16[1] = tl[(tl_dim1 << 1) + 1];
	    t16[14] = tl[tl_dim1 + 2];
	    t16[11] = tl[(tl_dim1 << 1) + 1];
        } else {
	    t16[4] = tl[(tl_dim1 << 1) + 1];
	    t16[1] = tl[tl_dim1 + 2];
	    t16[14] = tl[(tl_dim1 << 1) + 1];
	    t16[11] = tl[tl_dim1 + 2];
        }
        if (ltranr) {
	    t16[8] = sgn * tr[(tr_dim1 << 1) + 1];
	    t16[13] = sgn * tr[(tr_dim1 << 1) + 1];
	    t16[2] = sgn * tr[tr_dim1 + 2];
	    t16[7] = sgn * tr[tr_dim1 + 2];
        } else {
	    t16[8] = sgn * tr[tr_dim1 + 2];
	    t16[13] = sgn * tr[tr_dim1 + 2];
	    t16[2] = sgn * tr[(tr_dim1 << 1) + 1];
	    t16[7] = sgn * tr[(tr_dim1 << 1) + 1];
        }
        btmp[0] = b[b_dim1 + 1];
        btmp[1] = b[b_dim1 + 2];
        btmp[2] = b[(b_dim1 << 1) + 1];
        btmp[3] = b[(b_dim1 << 1) + 2];

    /*     Perform elimination */

        for (i__ = 1; i__ <= 3; ++i__) {
	    xmax = 0.0;
	    for (ip = i__; ip <= 4; ++ip) {
	        for (jp = i__; jp <= 4; ++jp) {
		    if ((abs(t16[ip + (jp << 2) - 5])) >= xmax) {
		        xmax = (abs(t16[ip + (jp << 2) - 5]));
		        ipsv = ip;
		        jpsv = jp;
		    }
    /* L60: */
	        }
    /* L70: */
	    }
	    if (ipsv != i__) {
	        dswap(c__4, &t16[ipsv - 1], c__4, &t16[i__ - 1], c__4);
	        temp = btmp[i__ - 1];
	        btmp[i__ - 1] = btmp[ipsv - 1];
	        btmp[ipsv - 1] = temp;
	    }
	    if (jpsv != i__) {
	        dswap(c__4, &t16[(jpsv << 2) - 4], c__1, &t16[(i__ << 2) - 4], 
		        c__1);
	    }
	    jpiv[i__ - 1] = jpsv;
	    if ((abs(t16[i__ + (i__ << 2) - 5])) < smin) {
	        info = 1;
	        t16[i__ + (i__ << 2) - 5] = smin;
	    }
	    for (j = i__ + 1; j <= 4; ++j) {
	        t16[j + (i__ << 2) - 5] /= t16[i__ + (i__ << 2) - 5];
	        btmp[j - 1] -= t16[j + (i__ << 2) - 5] * btmp[i__ - 1];
	        for (k = i__ + 1; k <= 4; ++k) {
		    t16[j + (k << 2) - 5] -= t16[j + (i__ << 2) - 5] * t16[i__ + (
			    k << 2) - 5];
    /* L80: */
	        }
    /* L90: */
	    }
    /* L100: */
        }
        if (abs(t16[15]) < smin) {
	    t16[15] = smin;
        }
        scale = 1.0;
        if (smlnum * 8.0 * abs(btmp[0]) > abs(t16[0]) || smlnum * 8.0 * abs(btmp[1])
	         > abs(t16[5]) || smlnum * 8.0 * abs(btmp[2]) > abs(t16[10]) || 
	        smlnum * 8.0 * abs(btmp[3]) > abs(t16[15])) {
    /* Computing MAX */
	    d__1 = abs(btmp[0]);
        d__2 = abs(btmp[1]);
        d__1 = max(d__1,d__2);
        d__2 = abs(btmp[2]);
        d__1 = max(d__1,d__2);
        d__2 = abs(btmp[3]);
	    scale = .125 / max(d__1,d__2);
	    btmp[0] *= scale;
	    btmp[1] *= scale;
	    btmp[2] *= scale;
	    btmp[3] *= scale;
        }
        for (i__ = 1; i__ <= 4; ++i__) {
	    k = 5 - i__;
	    temp = 1.0 / t16[k + (k << 2) - 5];
	    tmp[k - 1] = btmp[k - 1] * temp;
	    for (j = k + 1; j <= 4; ++j) {
	        tmp[k - 1] -= temp * t16[k + (j << 2) - 5] * tmp[j - 1];
    /* L110: */
	    }
    /* L120: */
        }
        for (i__ = 1; i__ <= 3; ++i__) {
	    if (jpiv[4 - i__ - 1] != 4 - i__) {
	        temp = tmp[4 - i__ - 1];
	        tmp[4 - i__ - 1] = tmp[jpiv[4 - i__ - 1] - 1];
	        tmp[jpiv[4 - i__ - 1] - 1] = temp;
	    }
    /* L130: */
        }
        x[x_dim1 + 1] = tmp[0];
        x[x_dim1 + 2] = tmp[1];
        x[(x_dim1 << 1) + 1] = tmp[2];
        x[(x_dim1 << 1) + 2] = tmp[3];
    /* Computing MAX */
        d__1 = abs(tmp[0]) + abs(tmp[2]);
        d__2 = abs(tmp[1]) + abs(tmp[3]);
        xnorm = max(d__1,d__2);
        return 0;
    }
}

