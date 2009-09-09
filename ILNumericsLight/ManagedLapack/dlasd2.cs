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
    public static unsafe int dlasd2(int nl, int nr, int sqre, ref int k, double* d__, double* z__, double alpha, double beta,
        double* u, int ldu, double* vt, int ldvt, double* dsigma, double* u2, int ldu2, double* vt2, int ldvt2, int* idxp,
        int* idx, int* idxc, int* idxq, int* coltyp, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b30 = 0;

        /* System generated locals */
        int u_dim1, u_offset, u2_dim1, u2_offset, vt_dim1, vt_offset, vt2_dim1, vt2_offset, i__1;
        double d__1, d__2;

        /* Local variables */
        double c__ = 0;
        int i__, j, m, n;
        double s = 0;
        int k2;
        double z1;
        int ct, jp;
        double eps, tau, tol;
        int[] psm = new int[4], ctot = new int[4];
        int nlp1, nlp2, idxi, idxj;
        int idxjp;
        int jprev = 0;
        double hlftol;

        /* Parameter adjustments */
        --d__;
        --z__;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        --dsigma;
        u2_dim1 = ldu2;
        u2_offset = 1 + u2_dim1;
        u2 -= u2_offset;
        vt2_dim1 = ldvt2;
        vt2_offset = 1 + vt2_dim1;
        vt2 -= vt2_offset;
        --idxp;
        --idx;
        --idxc;
        --idxq;
        --coltyp;

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

        if (ldu < n) {
	    info = -10;
        } else if (ldvt < m) {
	    info = -12;
        } else if (ldu2 < n) {
	    info = -15;
        } else if (ldvt2 < m) {
	    info = -17;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD2", i__1);
	    return 0;
        }

        nlp1 = nl + 1;
        nlp2 = nl + 2;

    /*     Generate the first part of the vector Z; and move the singular */
    /*     values in the first part of D one position backward. */

        z1 = alpha * vt[nlp1 + nlp1 * vt_dim1];
        z__[1] = z1;
        for (i__ = nl; i__ >= 1; --i__) {
	    z__[i__ + 1] = alpha * vt[i__ + nlp1 * vt_dim1];
	    d__[i__ + 1] = d__[i__];
	    idxq[i__ + 1] = idxq[i__] + 1;
    /* L10: */
        }

    /*     Generate the second part of the vector Z. */

        i__1 = m;
        for (i__ = nlp2; i__ <= i__1; ++i__) {
	    z__[i__] = beta * vt[i__ + nlp2 * vt_dim1];
    /* L20: */
        }

    /*     Initialize some reference arrays. */

        i__1 = nlp1;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    coltyp[i__] = 1;
    /* L30: */
        }
        i__1 = n;
        for (i__ = nlp2; i__ <= i__1; ++i__) {
	    coltyp[i__] = 2;
    /* L40: */
        }

    /*     Sort the singular values into increasing order */

        i__1 = n;
        for (i__ = nlp2; i__ <= i__1; ++i__) {
	    idxq[i__] += nlp1;
    /* L50: */
        }

    /*     DSIGMA, IDXC, IDXC, and the first column of U2 */
    /*     are used as storage space. */

        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    dsigma[i__] = d__[idxq[i__]];
	    u2[i__ + u2_dim1] = z__[idxq[i__]];
	    idxc[i__] = coltyp[idxq[i__]];
    /* L60: */
        }

        dlamrg(nl, nr, &dsigma[2], c__1, c__1, &idx[2]);

        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    idxi = idx[i__] + 1;
	    d__[i__] = dsigma[idxi];
	    z__[i__] = u2[idxi + u2_dim1];
	    coltyp[i__] = idxc[idxi];
    /* L70: */
        }

    /*     Calculate the allowable deflation tolerance */

        eps = dlamch('E');
    /* Computing MAX */
        tol = max(abs(alpha),abs(beta));
    /* Computing MAX */
        d__1 = d__[n];
        d__2 = abs(d__1);
        tol = eps * 8.0 * max(d__2,tol);

    /*     There are 2 kinds of deflation -- first a value in the z-vector */
    /*     is small, second two (or more) singular values are very close */
    /*     together (their difference is small). */

    /*     If the value in the z-vector is small, we simply permute the */
    /*     array so that the corresponding singular value is moved to the */
    /*     end. */

    /*     If two values in the D-vector are close, we perform a two-sided */
    /*     rotation designed to make one of the corresponding z-vector */
    /*     entries zero, and then permute the array so that the deflated */
    /*     singular value is moved to the end. */

    /*     If there are multiple singular values then the problem deflates. */
    /*     Here the number of equal singular values are found.  As each equal */
    /*     singular value is found, an elementary reflector is computed to */
    /*     rotate the corresponding singular subspace so that the */
    /*     corresponding components of Z are zero in this new basis. */

        k = 1;
        k2 = n + 1;
        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    if (abs(z__[j]) <= tol) {

    /*           Deflate due to small z component. */

	        --k2;
	        idxp[k2] = j;
	        coltyp[j] = 4;
	        if (j == n) {
		    goto L120;
	        }
	    } else {
	        jprev = j;
	        goto L90;
	    }
    /* L80: */
        }
    L90:
        j = jprev;
    L100:
        ++j;
        if (j > n) {
	    goto L110;
        }
        if (abs(z__[j]) <= tol) {

    /*        Deflate due to small z component. */

	    --k2;
	    idxp[k2] = j;
	    coltyp[j] = 4;
        } else {

    /*        Check if singular values are close enough to allow deflation. */

	    if (abs(d__[j] - d__[jprev]) <= tol) {

    /*           Deflation is possible. */

	        s = z__[jprev];
	        c__ = z__[j];

    /*           Find sqrt(a**2+b**2) without overflow or */
    /*           destructive underflow. */

	        tau = dlapy2(c__, s);
	        c__ /= tau;
	        s = -s / tau;
	        z__[j] = tau;
	        z__[jprev] = 0;

    /*           Apply back the Givens rotation to the left and right */
    /*           singular vector matrices. */

	        idxjp = idxq[idx[jprev] + 1];
	        idxj = idxq[idx[j] + 1];
	        if (idxjp <= nlp1) {
		    --idxjp;
	        }
	        if (idxj <= nlp1) {
		    --idxj;
	        }
	        drot(n, &u[idxjp * u_dim1 + 1], c__1, &u[idxj * u_dim1 + 1], 
		        c__1, c__, s);
	        drot(m, &vt[idxjp + vt_dim1], ldvt, &vt[idxj + vt_dim1], ldvt, 
		        c__, s);
	        if (coltyp[j] != coltyp[jprev]) {
		    coltyp[j] = 3;
	        }
	        coltyp[jprev] = 4;
	        --k2;
	        idxp[k2] = jprev;
	        jprev = j;
	    } else {
	        ++(k);
	        u2[k + u2_dim1] = z__[jprev];
	        dsigma[k] = d__[jprev];
	        idxp[k] = jprev;
	        jprev = j;
	    }
        }
        goto L100;
    L110:

    /*     Record the last singular value. */

        ++(k);
        u2[k + u2_dim1] = z__[jprev];
        dsigma[k] = d__[jprev];
        idxp[k] = jprev;

    L120:

    /*     Count up the total number of the various types of columns, then */
    /*     form a permutation which positions the four column types into */
    /*     four groups of uniform structure (although one or more of these */
    /*     groups may be empty). */

        for (j = 1; j <= 4; ++j) {
	    ctot[j - 1] = 0;
    /* L130: */
        }
        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    ct = coltyp[j];
	    ++ctot[ct - 1];
    /* L140: */
        }

    /*     PSM(*) = Position in SubMatrix (of types 1 through 4) */

        psm[0] = 2;
        psm[1] = ctot[0] + 2;
        psm[2] = psm[1] + ctot[1];
        psm[3] = psm[2] + ctot[2];

    /*     Fill out the IDXC array so that the permutation which it induces */
    /*     will place all type-1 columns first, all type-2 columns next, */
    /*     then all type-3's, and finally all type-4's, starting from the */
    /*     second column. This applies similarly to the rows of VT. */

        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    jp = idxp[j];
	    ct = coltyp[jp];
	    idxc[psm[ct - 1]] = j;
	    ++psm[ct - 1];
    /* L150: */
        }

    /*     Sort the singular values and corresponding singular vectors into */
    /*     DSIGMA, U2, and VT2 respectively.  The singular values/vectors */
    /*     which were not deflated go into the first K slots of DSIGMA, U2, */
    /*     and VT2 respectively, while those which were deflated go into the */
    /*     last N - K slots, except that the first column/row will be treated */
    /*     separately. */

        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    jp = idxp[j];
	    dsigma[j] = d__[jp];
	    idxj = idxq[idx[idxp[idxc[j]]] + 1];
	    if (idxj <= nlp1) {
	        --idxj;
	    }
	    dcopy(n, &u[idxj * u_dim1 + 1], c__1, &u2[j * u2_dim1 + 1], c__1);
	    dcopy(m, &vt[idxj + vt_dim1], ldvt, &vt2[j + vt2_dim1], ldvt2);
    /* L160: */
        }

    /*     Determine DSIGMA(1), DSIGMA(2) and Z(1) */

        dsigma[1] = 0;
        hlftol = tol / 2;
        if (abs(dsigma[2]) <= hlftol) {
	    dsigma[2] = hlftol;
        }
        if (m > n) {
	    z__[1] = dlapy2(z1, z__[m]);
	    if (z__[1] <= tol) {
	        c__ = 1;
	        s = 0;
	        z__[1] = tol;
	    } else {
	        c__ = z1 / z__[1];
	        s = z__[m] / z__[1];
	    }
        } else {
	    if (abs(z1) <= tol) {
	        z__[1] = tol;
	    } else {
	        z__[1] = z1;
	    }
        }

    /*     Move the rest of the updating row to Z. */

        i__1 = k - 1;
        dcopy(i__1, &u2[u2_dim1 + 2], c__1, &z__[2], c__1);

    /*     Determine the first column of U2, the first row of VT2 and the */
    /*     last row of VT. */

        dlaset('A', n, c__1, c_b30, c_b30, &u2[u2_offset], ldu2);
        u2[nlp1 + u2_dim1] = 1;
        if (m > n) {
	    i__1 = nlp1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        vt[m + i__ * vt_dim1] = -s * vt[nlp1 + i__ * vt_dim1];
	        vt2[i__ * vt2_dim1 + 1] = c__ * vt[nlp1 + i__ * vt_dim1];
    /* L170: */
	    }
	    i__1 = m;
	    for (i__ = nlp2; i__ <= i__1; ++i__) {
	        vt2[i__ * vt2_dim1 + 1] = s * vt[m + i__ * vt_dim1];
	        vt[m + i__ * vt_dim1] = c__ * vt[m + i__ * vt_dim1];
    /* L180: */
	    }
        } else {
	    dcopy(m, &vt[nlp1 + vt_dim1], ldvt, &vt2[vt2_dim1 + 1], ldvt2);
        }
        if (m > n) {
	    dcopy(m, &vt[m + vt_dim1], ldvt, &vt2[m + vt2_dim1], ldvt2);
        }

    /*     The deflated singular values and their corresponding vectors go */
    /*     into the back of D, U, and V respectively. */

        if (n > k) {
	    i__1 = n - k;
	    dcopy(i__1, &dsigma[k + 1], c__1, &d__[k + 1], c__1);
	    i__1 = n - k;
	    dlacpy('A', n, i__1, &u2[(k + 1) * u2_dim1 + 1], ldu2, &u[(k + 1)
		     * u_dim1 + 1], ldu);
	    i__1 = n - k;
	    dlacpy('A', i__1, m, &vt2[k + 1 + vt2_dim1], ldvt2, &vt[k + 1 + 
		    vt_dim1], ldvt);
        }

    /*     Copy CTOT into COLTYP for referencing in DLASD3. */

        for (j = 1; j <= 4; ++j) {
	    coltyp[j] = ctot[j - 1];
    /* L190: */
        }

        return 0;
    } 
}

