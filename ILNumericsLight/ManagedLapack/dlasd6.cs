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
    public static unsafe int dlasd6(int icompq, int nl, int nr, int sqre, double *d__, double *vf, double *vl,
        double alpha, double beta, int *idxq, int *perm, ref int givptr, int *givcol, int ldgcol, double *givnum,
        int ldgnum, double *poles, double *difl, double *difr, double *z__, ref int k, ref double c__, ref double s,
        double *work, int *iwork, ref int info)
    {
        /* Table of constant values */
        const int c__0 = 0;
        const double c_b7 = 1.0;
        const int c__1 = 1;
        const int c_n1 = -1;

        /* System generated locals */
        int givcol_dim1, givcol_offset, givnum_dim1, givnum_offset, poles_dim1, poles_offset, i__1;
        double d__1, d__2;

        /* Local variables */
        int i__, m, n, n1, n2, iw, idx, idxc, idxp, ivfw, ivlw;
        int isigma;
        double orgnrm;

        /* Parameter adjustments */
        --d__;
        --vf;
        --vl;
        --idxq;
        --perm;
        givcol_dim1 = ldgcol;
        givcol_offset = 1 + givcol_dim1;
        givcol -= givcol_offset;
        poles_dim1 = ldgnum;
        poles_offset = 1 + poles_dim1;
        poles -= poles_offset;
        givnum_dim1 = ldgnum;
        givnum_offset = 1 + givnum_dim1;
        givnum -= givnum_offset;
        --difl;
        --difr;
        --z__;
        --work;
        --iwork;

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
	    info = -14;
        } else if (ldgnum < n) {
	    info = -16;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD6", i__1);
	    return 0;
        }

    /*     The following values are for bookkeeping purposes only.  They are */
    /*     int pointers which indicate the portion of the workspace */
    /*     used by a particular array in DLASD7 and DLASD8. */

        isigma = 1;
        iw = isigma + n;
        ivfw = iw + m;
        ivlw = ivfw + m;

        idx = 1;
        idxc = idx + n;
        idxp = idxc + n;

    /*     Scale. */

    /* Computing MAX */
        d__1 = abs(alpha);
        d__2 = abs(beta);
        orgnrm = max(d__1,d__2);
        d__[nl + 1] = 0.0;
        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if ((abs(d__[i__])) > orgnrm) {
	        orgnrm = (abs(d__[i__]));
	    }
    /* L10: */
        }
        dlascl('G', c__0, c__0, orgnrm, c_b7, n, c__1, &d__[1], n, ref info);
        alpha /= orgnrm;
        beta /= orgnrm;

    /*     Sort and Deflate singular values. */

        dlasd7(icompq, nl, nr, sqre, k, &d__[1], &z__[1], &work[iw], &vf[1], &
	        work[ivfw], &vl[1], &work[ivlw], alpha, beta, &work[isigma], &
	        iwork[idx], &iwork[idxp], &idxq[1], &perm[1], ref givptr, &givcol[
	        givcol_offset], ldgcol, &givnum[givnum_offset], ldgnum, ref c__, ref s, 
	        ref info);

    /*     Solve Secular Equation, compute DIFL, DIFR, and update VF, VL. */

        dlasd8(icompq, k, &d__[1], &z__[1], &vf[1], &vl[1], &difl[1], &difr[1], 
	        ldgnum, &work[isigma], &work[iw], ref info);

    /*     Save the poles if ICOMPQ = 1.0 */

        if (icompq == 1) {
	    dcopy(k, &d__[1], c__1, &poles[poles_dim1 + 1], c__1);
	    dcopy(k, &work[isigma], c__1, &poles[(poles_dim1 << 1) + 1], c__1);
        }

    /*     Unscale. */

        dlascl('G', c__0, c__0, c_b7, orgnrm, n, c__1, &d__[1], n, ref info);

    /*     Prepare the IDXQ sorting permutation. */

        n1 = k;
        n2 = n - k;
        dlamrg(n1, n2, &d__[1], c__1, c_n1, &idxq[1]);

        return 0;
    } 
}

