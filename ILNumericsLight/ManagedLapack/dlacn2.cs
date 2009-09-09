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
    public static unsafe int dlacn2(int n, double* v, double* x, int* isgn, ref double est, ref int kase, int* isave)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b11 = 1.0;

        /* System generated locals */
        int i__1;
        double d__1;

        /* Local variables */
        int i__;
        double temp;
        int jlast;
        double altsgn, estold;

        /* Parameter adjustments */
        --isave;
        --isgn;
        --x;
        --v;

        /* Function Body */
        if (kase == 0) {
	    i__1 = n;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        x[i__] = 1.0 / (double) (n);
    /* L10: */
	    }
	    kase = 1;
	    isave[1] = 1;
	    return 0;
        }

        switch (isave[1]) {
	    case 1:  goto L20;
	    case 2:  goto L40;
	    case 3:  goto L70;
	    case 4:  goto L110;
	    case 5:  goto L140;
        }

    /*     ................ ENTRY   (ISAVE( 1 ) = 1) */
    /*     FIRST ITERATION.  X HAS BEEN OVERWRITTEN BY A*X. */

    L20:
        if (n == 1) {
	    v[1] = x[1];
	    est = abs(v[1]);
    /*        ... QUIT */
	    goto L150;
        }
        est = dasum(n, &x[1], c__1);

        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    x[i__] = d_sign(c_b11, x[i__]);
	    isgn[i__] = i_dnnt(x[i__]);
    /* L30: */
        }
        kase = 2;
        isave[1] = 2;
        return 0;

    /*     ................ ENTRY   (ISAVE( 1 ) = 2) */
    /*     FIRST ITERATION.  X HAS BEEN OVERWRITTEN BY TRANSPOSE(A)*X. */

    L40:
        isave[2] = idamax(n, &x[1], c__1);
        isave[3] = 2;

    /*     MAIN LOOP - ITERATIONS 2,3,...,ITMAX. */

    L50:
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    x[i__] = 0.0;
    /* L60: */
        }
        x[isave[2]] = 1.0;
        kase = 1;
        isave[1] = 3;
        return 0;

    /*     ................ ENTRY   (ISAVE( 1 ) = 3) */
    /*     X HAS BEEN OVERWRITTEN BY A*X. */

    L70:
        dcopy(n, &x[1], c__1, &v[1], c__1);
        estold = est;
        est = dasum(n, &v[1], c__1);
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    d__1 = d_sign(c_b11, x[i__]);
	    if (i_dnnt(d__1) != isgn[i__]) {
	        goto L90;
	    }
    /* L80: */
        }
    /*     REPEATED SIGN VECTOR DETECTED, HENCE ALGORITHM HAS CONVERGED. */
        goto L120;

    L90:
    /*     TEST FOR CYCLING. */
        if (est <= estold) {
	    goto L120;
        }

        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    x[i__] = d_sign(c_b11, x[i__]);
	    isgn[i__] = i_dnnt(x[i__]);
    /* L100: */
        }
        kase = 2;
        isave[1] = 4;
        return 0;

    /*     ................ ENTRY   (ISAVE( 1 ) = 4) */
    /*     X HAS BEEN OVERWRITTEN BY TRANSPOSE(A)*X. */

    L110:
        jlast = isave[2];
        isave[2] = idamax(n, &x[1], c__1);
        if (x[jlast] != (abs(x[isave[2]])) && isave[3] < 5) {
	    ++isave[3];
	    goto L50;
        }

    /*     ITERATION COMPLETE.  FINAL STAGE. */

    L120:
        altsgn = 1.0;
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    x[i__] = altsgn * ((double) (i__ - 1) / (double) (n - 1) + 
		    1.0);
	    altsgn = -altsgn;
    /* L130: */
        }
        kase = 1;
        isave[1] = 5;
        return 0;

    /*     ................ ENTRY   (ISAVE( 1 ) = 5) */
    /*     X HAS BEEN OVERWRITTEN BY A*X. */

    L140:
        temp = dasum(n, &x[1], c__1) / (double) (n * 3) * 2.0;
        if (temp > est) {
	    dcopy(n, &x[1], c__1, &v[1], c__1);
	    est = temp;
        }

    L150:
        kase = 0;
        return 0;
    }
}

