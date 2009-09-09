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
    public static unsafe int dlarfx(char side, int m, int n, double* v, double tau, double *c__, int ldc, double *work)
    {
        /* Table of constant values */
        const double c_b14 = 1;
        const int c__1 = 1;
        const double c_b16 = 0;

         /* System generated locals */
        int c_dim1, c_offset, i__1;
        double d__1;

        /* Local variables */
        int j;
        double t1, t2, t3, t4, t5, t6, t7, t8, t9, v1, v2, v3, v4, v5, v6, v7, v8, v9, t10, v10, sum;

        /* Parameter adjustments */
        --v;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        --work;

        /* Function Body */
        if (tau == 0.0) {
	    return 0;
        }
        if (lsame(side, 'L')) {

    /*        Form  H * C, where H has order m. */

	    switch (m) {
	        case 1:  goto L10;
	        case 2:  goto L30;
	        case 3:  goto L50;
	        case 4:  goto L70;
	        case 5:  goto L90;
	        case 6:  goto L110;
	        case 7:  goto L130;
	        case 8:  goto L150;
	        case 9:  goto L170;
	        case 10:  goto L190;
	    }

    /*        Code for general M */

    /*        w := C'*v */

	    dgemv('T', m, n, c_b14, &c__[c_offset], ldc, &v[1], c__1, 
		    c_b16, &work[1], c__1);

    /*        C := C - tau * v * w' */

	    d__1 = -(tau);
	    dger(m, n, d__1, &v[1], c__1, &work[1], c__1, &c__[c_offset], ldc)
		    ;
	    goto L410;
    L10:

    /*        Special code for 1 x 1 Householder */

	    t1 = 1.0 - tau * v[1] * v[1];
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        c__[j * c_dim1 + 1] = t1 * c__[j * c_dim1 + 1];
    /* L20: */
	    }
	    goto L410;
    L30:

    /*        Special code for 2 x 2 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
    /* L40: */
	    }
	    goto L410;
    L50:

    /*        Special code for 3 x 3 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
    /* L60: */
	    }
	    goto L410;
    L70:

    /*        Special code for 4 x 4 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
    /* L80: */
	    }
	    goto L410;
    L90:

    /*        Special code for 5 x 5 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
    /* L100: */
	    }
	    goto L410;
    L110:

    /*        Special code for 6 x 6 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5] + v6 * c__[j * c_dim1 + 6];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
	        c__[j * c_dim1 + 6] -= sum * t6;
    /* L120: */
	    }
	    goto L410;
    L130:

    /*        Special code for 7 x 7 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5] + v6 * c__[j * c_dim1 + 6] + v7 * c__[j * 
		        c_dim1 + 7];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
	        c__[j * c_dim1 + 6] -= sum * t6;
	        c__[j * c_dim1 + 7] -= sum * t7;
    /* L140: */
	    }
	    goto L410;
    L150:

    /*        Special code for 8 x 8 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5] + v6 * c__[j * c_dim1 + 6] + v7 * c__[j * 
		        c_dim1 + 7] + v8 * c__[j * c_dim1 + 8];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
	        c__[j * c_dim1 + 6] -= sum * t6;
	        c__[j * c_dim1 + 7] -= sum * t7;
	        c__[j * c_dim1 + 8] -= sum * t8;
    /* L160: */
	    }
	    goto L410;
    L170:

    /*        Special code for 9 x 9 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    v9 = v[9];
	    t9 = tau * v9;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5] + v6 * c__[j * c_dim1 + 6] + v7 * c__[j * 
		        c_dim1 + 7] + v8 * c__[j * c_dim1 + 8] + v9 * c__[j * 
		        c_dim1 + 9];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
	        c__[j * c_dim1 + 6] -= sum * t6;
	        c__[j * c_dim1 + 7] -= sum * t7;
	        c__[j * c_dim1 + 8] -= sum * t8;
	        c__[j * c_dim1 + 9] -= sum * t9;
    /* L180: */
	    }
	    goto L410;
    L190:

    /*        Special code for 10 x 10 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    v9 = v[9];
	    t9 = tau * v9;
	    v10 = v[10];
	    t10 = tau * v10;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j * c_dim1 + 1] + v2 * c__[j * c_dim1 + 2] + v3 * 
		        c__[j * c_dim1 + 3] + v4 * c__[j * c_dim1 + 4] + v5 * c__[
		        j * c_dim1 + 5] + v6 * c__[j * c_dim1 + 6] + v7 * c__[j * 
		        c_dim1 + 7] + v8 * c__[j * c_dim1 + 8] + v9 * c__[j * 
		        c_dim1 + 9] + v10 * c__[j * c_dim1 + 10];
	        c__[j * c_dim1 + 1] -= sum * t1;
	        c__[j * c_dim1 + 2] -= sum * t2;
	        c__[j * c_dim1 + 3] -= sum * t3;
	        c__[j * c_dim1 + 4] -= sum * t4;
	        c__[j * c_dim1 + 5] -= sum * t5;
	        c__[j * c_dim1 + 6] -= sum * t6;
	        c__[j * c_dim1 + 7] -= sum * t7;
	        c__[j * c_dim1 + 8] -= sum * t8;
	        c__[j * c_dim1 + 9] -= sum * t9;
	        c__[j * c_dim1 + 10] -= sum * t10;
    /* L200: */
	    }
	    goto L410;
        } else {

    /*        Form  C * H, where H has order n. */

	    switch (n) {
	        case 1:  goto L210;
	        case 2:  goto L230;
	        case 3:  goto L250;
	        case 4:  goto L270;
	        case 5:  goto L290;
	        case 6:  goto L310;
	        case 7:  goto L330;
	        case 8:  goto L350;
	        case 9:  goto L370;
	        case 10:  goto L390;
	    }

    /*        Code for general N */

    /*        w := C * v */

	    dgemv('N', m, n, c_b14, &c__[c_offset], ldc, &v[1], 
		    c__1, c_b16, &work[1], c__1);

    /*        C := C - tau * w * v' */

	    d__1 = -(tau);
	    dger(m, n, d__1, &work[1], c__1, &v[1], c__1, &c__[c_offset], ldc)
		    ;
	    goto L410;
    L210:

    /*        Special code for 1 x 1 Householder */

	    t1 = 1.0 - tau * v[1] * v[1];
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        c__[j + c_dim1] = t1 * c__[j + c_dim1];
    /* L220: */
	    }
	    goto L410;
    L230:

    /*        Special code for 2 x 2 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
    /* L240: */
	    }
	    goto L410;
    L250:

    /*        Special code for 3 x 3 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
    /* L260: */
	    }
	    goto L410;
    L270:

    /*        Special code for 4 x 4 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
    /* L280: */
	    }
	    goto L410;
    L290:

    /*        Special code for 5 x 5 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
    /* L300: */
	    }
	    goto L410;
    L310:

    /*        Special code for 6 x 6 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5] + v6 * c__[j + c_dim1 * 6];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
	        c__[j + c_dim1 * 6] -= sum * t6;
    /* L320: */
	    }
	    goto L410;
    L330:

    /*        Special code for 7 x 7 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5] + v6 * c__[j + c_dim1 * 6] + v7 * c__[
		        j + c_dim1 * 7];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
	        c__[j + c_dim1 * 6] -= sum * t6;
	        c__[j + c_dim1 * 7] -= sum * t7;
    /* L340: */
	    }
	    goto L410;
    L350:

    /*        Special code for 8 x 8 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5] + v6 * c__[j + c_dim1 * 6] + v7 * c__[
		        j + c_dim1 * 7] + v8 * c__[j + (c_dim1 << 3)];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
	        c__[j + c_dim1 * 6] -= sum * t6;
	        c__[j + c_dim1 * 7] -= sum * t7;
	        c__[j + (c_dim1 << 3)] -= sum * t8;
    /* L360: */
	    }
	    goto L410;
    L370:

    /*        Special code for 9 x 9 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    v9 = v[9];
	    t9 = tau * v9;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5] + v6 * c__[j + c_dim1 * 6] + v7 * c__[
		        j + c_dim1 * 7] + v8 * c__[j + (c_dim1 << 3)] + v9 * c__[
		        j + c_dim1 * 9];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
	        c__[j + c_dim1 * 6] -= sum * t6;
	        c__[j + c_dim1 * 7] -= sum * t7;
	        c__[j + (c_dim1 << 3)] -= sum * t8;
	        c__[j + c_dim1 * 9] -= sum * t9;
    /* L380: */
	    }
	    goto L410;
    L390:

    /*        Special code for 10 x 10 Householder */

	    v1 = v[1];
	    t1 = tau * v1;
	    v2 = v[2];
	    t2 = tau * v2;
	    v3 = v[3];
	    t3 = tau * v3;
	    v4 = v[4];
	    t4 = tau * v4;
	    v5 = v[5];
	    t5 = tau * v5;
	    v6 = v[6];
	    t6 = tau * v6;
	    v7 = v[7];
	    t7 = tau * v7;
	    v8 = v[8];
	    t8 = tau * v8;
	    v9 = v[9];
	    t9 = tau * v9;
	    v10 = v[10];
	    t10 = tau * v10;
	    i__1 = m;
	    for (j = 1; j <= i__1; ++j) {
	        sum = v1 * c__[j + c_dim1] + v2 * c__[j + (c_dim1 << 1)] + v3 * 
		        c__[j + c_dim1 * 3] + v4 * c__[j + (c_dim1 << 2)] + v5 * 
		        c__[j + c_dim1 * 5] + v6 * c__[j + c_dim1 * 6] + v7 * c__[
		        j + c_dim1 * 7] + v8 * c__[j + (c_dim1 << 3)] + v9 * c__[
		        j + c_dim1 * 9] + v10 * c__[j + c_dim1 * 10];
	        c__[j + c_dim1] -= sum * t1;
	        c__[j + (c_dim1 << 1)] -= sum * t2;
	        c__[j + c_dim1 * 3] -= sum * t3;
	        c__[j + (c_dim1 << 2)] -= sum * t4;
	        c__[j + c_dim1 * 5] -= sum * t5;
	        c__[j + c_dim1 * 6] -= sum * t6;
	        c__[j + c_dim1 * 7] -= sum * t7;
	        c__[j + (c_dim1 << 3)] -= sum * t8;
	        c__[j + c_dim1 * 9] -= sum * t9;
	        c__[j + c_dim1 * 10] -= sum * t10;
    /* L400: */
	    }
	    goto L410;
        }
    L410:
        return 0;
    }
}

