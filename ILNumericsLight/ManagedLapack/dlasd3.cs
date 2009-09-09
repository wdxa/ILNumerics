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
    public static unsafe int dlasd3(int nl, int nr, int sqre, int k, double* d__, double* q, int ldq, double* dsigma,
        double* u, int ldu, double* u2, int ldu2, double* vt, int ldvt, double* vt2, int ldvt2,
        int* idxc, int* ctot, double* z__, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__0 = 0;
        const double c_b13 = 1.0;
        const double c_b26 = 0.0;

        /* System generated locals */
        int q_dim1, q_offset, u_dim1, u_offset, u2_dim1, u2_offset, vt_dim1, vt_offset, vt2_dim1, vt2_offset, i__1, i__2;
        double d__2;

        /* Local variables */
        int i__, j, m, n, jc;
        double rho;
        int nlp1, nlp2, nrp1;
        double temp;
        int ctemp;
        int ktemp;

        /* Parameter adjustments */
        --d__;
        q_dim1 = ldq;
        q_offset = 1 + q_dim1;
        q -= q_offset;
        --dsigma;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        u2_dim1 = ldu2;
        u2_offset = 1 + u2_dim1;
        u2 -= u2_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        vt2_dim1 = ldvt2;
        vt2_offset = 1 + vt2_dim1;
        vt2 -= vt2_offset;
        --idxc;
        --ctot;
        --z__;

        /* Function Body */
        info = 0;

        if (nl < 1) {
	    info = -1;
        } else if (nr < 1) {
	    info = -2;
        } else if (sqre != 1 && sqre != 0) {
	    info = -3;
        }

        n = nl + nr + 1;
        m = n + sqre;
        nlp1 = nl + 1;
        nlp2 = nl + 2;

        if (k < 1 || k > n) {
	    info = -4;
        } else if (ldq < k) {
	    info = -7;
        } else if (ldu < n) {
	    info = -10;
        } else if (ldu2 < n) {
	    info = -12;
        } else if (ldvt < m) {
	    info = -14;
        } else if (ldvt2 < m) {
	    info = -16;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD3", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (k == 1) {
	    d__[1] = abs(z__[1]);
	    dcopy(m, &vt2[vt2_dim1 + 1], ldvt2, &vt[vt_dim1 + 1], ldvt);
	    if (z__[1] > 0.0) {
	        dcopy(n, &u2[u2_dim1 + 1], c__1, &u[u_dim1 + 1], c__1);
	    } else {
	        i__1 = n;
	        for (i__ = 1; i__ <= i__1; ++i__) {
		    u[i__ + u_dim1] = -u2[i__ + u2_dim1];
    /* L10: */
	        }
	    }
	    return 0;
        }

    /*     Modify values DSIGMA(i) to make sure all DSIGMA(i)-DSIGMA(j) can */
    /*     be computed with high relative accuracy (barring over/underflow). */
    /*     This is a problem on machines without a guard digit in */
    /*     add/subtract (Cray XMP, Cray YMP, Cray C 90 and Cray 2). */
    /*     The following code replaces DSIGMA(I) by 2*DSIGMA(I)-DSIGMA(I), */
    /*     which on any of these machines zeros out the bottommost */
    /*     bit of DSIGMA(I) if it is 1; this makes the subsequent */
    /*     subtractions DSIGMA(I)-DSIGMA(J) unproblematic when cancellation */
    /*     occurs. On binary machines with a guard digit (almost all */
    /*     machines) it does not change DSIGMA(I) at all. On hexadecimal */
    /*     and decimal machines with a guard digit, it slightly */
    /*     changes the bottommost bits of DSIGMA(I). It does not account */
    /*     for hexadecimal or decimal machines without guard digits */
    /*     (we know of none). We use a subroutine call to compute */
    /*     2*DSIGMA(I) to prevent optimizing compilers from eliminating */
    /*     this code. */

        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    dsigma[i__] = dlamc3(dsigma[i__], dsigma[i__]) - dsigma[i__];
    /* L20: */
        }

    /*     Keep a copy of Z. */

        dcopy(k, &z__[1], c__1, &q[q_offset], c__1);

    /*     Normalize Z. */

        rho = dnrm2(k, &z__[1], c__1);
        dlascl('G', c__0, c__0, rho, c_b13, k, c__1, &z__[1], k, ref info);
        rho *= rho;

    /*     Find the new singular values. */

        i__1 = k;
        for (j = 1; j <= i__1; ++j) {
	    dlasd4(k, j, &dsigma[1], &z__[1], &u[j * u_dim1 + 1], rho, ref d__[j], 
		     &vt[j * vt_dim1 + 1], ref info);

    /*        If the zero finder fails, the computation is terminated. */

	    if (info != 0) {
	        return 0;
	    }
    /* L30: */
        }

    /*     Compute updated Z. */

        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    z__[i__] = u[i__ + k * u_dim1] * vt[i__ + k * vt_dim1];
	    i__2 = i__ - 1;
	    for (j = 1; j <= i__2; ++j) {
	        z__[i__] *= u[i__ + j * u_dim1] * vt[i__ + j * vt_dim1] / (dsigma[
		        i__] - dsigma[j]) / (dsigma[i__] + dsigma[j]);
    /* L40: */
	    }
	    i__2 = k - 1;
	    for (j = i__; j <= i__2; ++j) {
	        z__[i__] *= u[i__ + j * u_dim1] * vt[i__ + j * vt_dim1] / (dsigma[
		        i__] - dsigma[j + 1]) / (dsigma[i__] + dsigma[j + 1]);
    /* L50: */
	    }
	    d__2 = sqrt((abs(z__[i__])));
	    z__[i__] = d_sign(d__2, q[i__ + q_dim1]);
    /* L60: */
        }

    /*     Compute left singular vectors of the modified diagonal matrix, */
    /*     and store related information for the right singular vectors. */

        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    vt[i__ * vt_dim1 + 1] = z__[1] / u[i__ * u_dim1 + 1] / vt[i__ * 
		    vt_dim1 + 1];
	    u[i__ * u_dim1 + 1] = -1.0;
	    i__2 = k;
	    for (j = 2; j <= i__2; ++j) {
	        vt[j + i__ * vt_dim1] = z__[j] / u[j + i__ * u_dim1] / vt[j + i__ 
		        * vt_dim1];
	        u[j + i__ * u_dim1] = dsigma[j] * vt[j + i__ * vt_dim1];
    /* L70: */
	    }
	    temp = dnrm2(k, &u[i__ * u_dim1 + 1], c__1);
	    q[i__ * q_dim1 + 1] = u[i__ * u_dim1 + 1] / temp;
	    i__2 = k;
	    for (j = 2; j <= i__2; ++j) {
	        jc = idxc[j];
	        q[j + i__ * q_dim1] = u[jc + i__ * u_dim1] / temp;
    /* L80: */
	    }
    /* L90: */
        }

    /*     Update the left singular vector matrix. */

        if (k == 2) {
	    dgemm('N', 'N', n, k, k, c_b13, &u2[u2_offset], ldu2, &q[q_offset], 
		     ldq, c_b26, &u[u_offset], ldu);
	    goto L100;
        }
        if (ctot[1] > 0) {
	    dgemm('N', 'N', nl, k, ctot[1], c_b13, &u2[(u2_dim1 << 1) + 1], 
		    ldu2, &q[q_dim1 + 2], ldq, c_b26, &u[u_dim1 + 1], ldu);
	    if (ctot[3] > 0) {
	        ktemp = ctot[1] + 2 + ctot[2];
	        dgemm('N', 'N', nl, k, ctot[3], c_b13, &u2[ktemp * u2_dim1 + 1]
    , ldu2, &q[ktemp + q_dim1], ldq, c_b13, &u[u_dim1 + 1], 
		        ldu);
	    }
        } else if (ctot[3] > 0) {
	    ktemp = ctot[1] + 2 + ctot[2];
	    dgemm('N', 'N', nl, k, ctot[3], c_b13, &u2[ktemp * u2_dim1 + 1], 
		    ldu2, &q[ktemp + q_dim1], ldq, c_b26, &u[u_dim1 + 1], ldu);
        } else {
	    dlacpy('F', nl, k, &u2[u2_offset], ldu2, &u[u_offset], ldu);
        }
        dcopy(k, &q[q_dim1 + 1], ldq, &u[nlp1 + u_dim1], ldu);
        ktemp = ctot[1] + 2;
        ctemp = ctot[2] + ctot[3];
        dgemm('N', 'N', nr, k, ctemp, c_b13, &u2[nlp2 + ktemp * u2_dim1], ldu2, 
	         &q[ktemp + q_dim1], ldq, c_b26, &u[nlp2 + u_dim1], ldu);

    /*     Generate the right singular vectors. */

    L100:
        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    temp = dnrm2(k, &vt[i__ * vt_dim1 + 1], c__1);
	    q[i__ + q_dim1] = vt[i__ * vt_dim1 + 1] / temp;
	    i__2 = k;
	    for (j = 2; j <= i__2; ++j) {
	        jc = idxc[j];
	        q[i__ + j * q_dim1] = vt[jc + i__ * vt_dim1] / temp;
    /* L110: */
	    }
    /* L120: */
        }

    /*     Update the right singular vector matrix. */

        if (k == 2) {
	    dgemm('N', 'N', k, m, k, c_b13, &q[q_offset], ldq, &vt2[vt2_offset]
    , ldvt2, c_b26, &vt[vt_offset], ldvt);
	    return 0;
        }
        ktemp = ctot[1] + 1;
        dgemm('N', 'N', k, nlp1, ktemp, c_b13, &q[q_dim1 + 1], ldq, &vt2[
	        vt2_dim1 + 1], ldvt2, c_b26, &vt[vt_dim1 + 1], ldvt);
        ktemp = ctot[1] + 2 + ctot[2];
        if (ktemp <= ldvt2) {
	    dgemm('N', 'N', k, nlp1, ctot[3], c_b13, &q[ktemp * q_dim1 + 1], 
		    ldq, &vt2[ktemp + vt2_dim1], ldvt2, c_b13, &vt[vt_dim1 + 1], 
		    ldvt);
        }

        ktemp = ctot[1] + 1;
        nrp1 = nr + sqre;
        if (ktemp > 1) {
	    i__1 = k;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        q[i__ + ktemp * q_dim1] = q[i__ + q_dim1];
    /* L130: */
	    }
	    i__1 = m;
	    for (i__ = nlp2; i__ <= i__1; ++i__) {
	        vt2[ktemp + i__ * vt2_dim1] = vt2[i__ * vt2_dim1 + 1];
    /* L140: */
	    }
        }
        ctemp = ctot[2] + 1 + ctot[3];
        dgemm('N', 'N', k, nrp1, ctemp, c_b13, &q[ktemp * q_dim1 + 1], ldq, &
	        vt2[ktemp + nlp2 * vt2_dim1], ldvt2, c_b26, &vt[nlp2 * vt_dim1 + 
	        1], ldvt);

        return 0;
    } 
}

