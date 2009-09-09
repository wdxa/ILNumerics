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
    public static unsafe int dlasd7(int icompq, int nl, int nr, int sqre, int k, double* d__,
        double* z__, double* zw, double* vf, double* vfw, double* vl, double* vlw, double alpha,
        double beta, double* dsigma, int* idx, int* idxp, int* idxq, int* perm, ref int givptr, int* givcol,
        int ldgcol, double* givnum, int ldgnum, ref double c__, ref double s, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int givcol_dim1, givcol_offset, givnum_dim1, givnum_offset, i__1;
        double d__1, d__2;

        /* Local variables */
        int i__, j, m, n, k2;
        double z1;
        int jp;
        double eps, tau, tol;
        int nlp1, nlp2, idxi, idxj;
        int idxjp;
        int jprev = 0;
        double hlftol;

        /* Parameter adjustments */
        --d__;
        --z__;
        --zw;
        --vf;
        --vfw;
        --vl;
        --vlw;
        --dsigma;
        --idx;
        --idxp;
        --idxq;
        --perm;
        givcol_dim1 = ldgcol;
        givcol_offset = 1 + givcol_dim1;
        givcol -= givcol_offset;
        givnum_dim1 = ldgnum;
        givnum_offset = 1 + givnum_dim1;
        givnum -= givnum_offset;

        /* Function Body */
        info = 0;
        n = nl + nr + 1;
        m = n + sqre;

        if (icompq < 0 || icompq > 1) {
	    info = -1;
        } else if (nl < 1) {
	    info = -2;
        } else if (nr < 1) {
	    info = -3;
        } else if (sqre < 0 || sqre > 1) {
	    info = -4;
        } else if (ldgcol < n) {
	    info = -22;
        } else if (ldgnum < n) {
	    info = -24;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD7", i__1);
	    return 0;
        }

        nlp1 = nl + 1;
        nlp2 = nl + 2;
        if (icompq == 1) {
	    givptr = 0;
        }

    /*     Generate the first part of the vector Z and move the singular */
    /*     values in the first part of D one position backward. */

        z1 = alpha * vl[nlp1];
        vl[nlp1] = 0.0;
        tau = vf[nlp1];
        for (i__ = nl; i__ >= 1; --i__) {
	    z__[i__ + 1] = alpha * vl[i__];
	    vl[i__] = 0.0;
	    vf[i__ + 1] = vf[i__];
	    d__[i__ + 1] = d__[i__];
	    idxq[i__ + 1] = idxq[i__] + 1;
    /* L10: */
        }
        vf[1] = tau;

    /*     Generate the second part of the vector Z. */

        i__1 = m;
        for (i__ = nlp2; i__ <= i__1; ++i__) {
	    z__[i__] = beta * vf[i__];
	    vf[i__] = 0.0;
    /* L20: */
        }

    /*     Sort the singular values into increasing order */

        i__1 = n;
        for (i__ = nlp2; i__ <= i__1; ++i__) {
	    idxq[i__] += nlp1;
    /* L30: */
        }

    /*     DSIGMA, IDXC, IDXC, and ZW are used as storage space. */

        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    dsigma[i__] = d__[idxq[i__]];
	    zw[i__] = z__[idxq[i__]];
	    vfw[i__] = vf[idxq[i__]];
	    vlw[i__] = vl[idxq[i__]];
    /* L40: */
        }

        dlamrg(nl, nr, &dsigma[2], c__1, c__1, &idx[2]);

        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    idxi = idx[i__] + 1;
	    d__[i__] = dsigma[idxi];
	    z__[i__] = zw[idxi];
	    vf[i__] = vfw[idxi];
	    vl[i__] = vlw[idxi];
    /* L50: */
        }

    /*     Calculate the allowable deflation tolerence */

        eps = dlamch('E');
    /* Computing MAX */
        d__1 = abs(alpha);
        d__2 = abs(beta);
        tol = max(d__1,d__2);
    /* Computing MAX */
        d__1 = d__[n];
        d__2 = ( abs(d__1));
        tol = eps * 64.0 * max(d__2,tol);

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
	    if ((abs(z__[j])) <= tol) {

    /*           Deflate due to small z component. */

	        --k2;
	        idxp[k2] = j;
	        if (j == n) {
		    goto L100;
	        }
	    } else {
	        jprev = j;
	        goto L70;
	    }
    /* L60: */
        }
    L70:
        j = jprev;
    L80:
        ++j;
        if (j > n) {
	    goto L90;
        }
        if ((abs(z__[j])) <= tol) {

    /*        Deflate due to small z component. */

	    --k2;
	    idxp[k2] = j;
        } else {

    /*        Check if singular values are close enough to allow deflation. */

	    if ((abs(d__[j] - d__[jprev])) <= tol) {

    /*           Deflation is possible. */

	        s = z__[jprev];
	        c__ = z__[j];

    /*           Find sqrt(a**2+b**2) without overflow or */
    /*           destructive underflow. */

	        tau = dlapy2(c__, s);
	        z__[j] = tau;
	        z__[jprev] = 0.0;
	        c__ /= tau;
	        s = -(s) / tau;

    /*           Record the appropriate Givens rotation */

	        if (icompq == 1) {
		    ++(givptr);
		    idxjp = idxq[idx[jprev] + 1];
		    idxj = idxq[idx[j] + 1];
		    if (idxjp <= nlp1) {
		        --idxjp;
		    }
		    if (idxj <= nlp1) {
		        --idxj;
		    }
		    givcol[givptr + (givcol_dim1 << 1)] = idxjp;
		    givcol[givptr + givcol_dim1] = idxj;
		    givnum[givptr + (givnum_dim1 << 1)] = c__;
		    givnum[givptr + givnum_dim1] = s;
	        }
	        drot(c__1, &vf[jprev], c__1, &vf[j], c__1, c__, s);
	        drot(c__1, &vl[jprev], c__1, &vl[j], c__1, c__, s);
	        --k2;
	        idxp[k2] = jprev;
	        jprev = j;
	    } else {
	        ++(k);
	        zw[k] = z__[jprev];
	        dsigma[k] = d__[jprev];
	        idxp[k] = jprev;
	        jprev = j;
	    }
        }
        goto L80;
    L90:

    /*     Record the last singular value. */

        ++(k);
        zw[k] = z__[jprev];
        dsigma[k] = d__[jprev];
        idxp[k] = jprev;

    L100:

    /*     Sort the singular values into DSIGMA. The singular values which */
    /*     were not deflated go into the first K slots of DSIGMA, except */
    /*     that DSIGMA(1) is treated separately. */

        i__1 = n;
        for (j = 2; j <= i__1; ++j) {
	    jp = idxp[j];
	    dsigma[j] = d__[jp];
	    vfw[j] = vf[jp];
	    vlw[j] = vl[jp];
    /* L110: */
        }
        if (icompq == 1) {
	    i__1 = n;
	    for (j = 2; j <= i__1; ++j) {
	        jp = idxp[j];
	        perm[j] = idxq[idx[jp] + 1];
	        if (perm[j] <= nlp1) {
		    --perm[j];
	        }
    /* L120: */
	    }
        }

    /*     The deflated singular values go back into the last N - K slots of */
    /*     D. */

        i__1 = n - k;
        dcopy(i__1, &dsigma[k + 1], c__1, &d__[k + 1], c__1);

    /*     Determine DSIGMA(1), DSIGMA(2), Z(1), VF(1), VL(1), VF(M), and */
    /*     VL(M). */

        dsigma[1] = 0.0;
        hlftol = tol / 2.0;
        if (abs(dsigma[2]) <= hlftol) {
	    dsigma[2] = hlftol;
        }
        if (m > n) {
	    z__[1] = dlapy2(z1, z__[m]);
	    if (z__[1] <= tol) {
	        c__ = 1.0;
	        s = 0.0;
	        z__[1] = tol;
	    } else {
	        c__ = z1 / z__[1];
	        s = -z__[m] / z__[1];
	    }
	    drot(c__1, &vf[m], c__1, &vf[1], c__1, c__, s);
	    drot(c__1, &vl[m], c__1, &vl[1], c__1, c__, s);
        } else {
	    if (abs(z1) <= tol) {
	        z__[1] = tol;
	    } else {
	        z__[1] = z1;
	    }
        }

    /*     Restore Z, VF, and VL. */

        i__1 = k - 1;
        dcopy(i__1, &zw[2], c__1, &z__[2], c__1);
        i__1 = n - 1;
        dcopy(i__1, &vfw[2], c__1, &vf[2], c__1);
        i__1 = n - 1;
        dcopy(i__1, &vlw[2], c__1, &vl[2], c__1);

        return 0;

    }
}

