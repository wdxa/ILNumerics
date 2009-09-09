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
    public static unsafe int dlasd1(int nl, int nr, int sqre, double* d__, ref double alpha, ref double beta,
        double* u, int ldu, double* vt, int ldvt, int* idxq, int* iwork, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__0 = 0;
        const double c_b7 = 1.0;
        const int c__1 = 1;
        const int c_n1 = -1;

        /* System generated locals */
        int u_dim1, u_offset, vt_dim1, vt_offset, i__1;
        double d__1, d__2;

        /* Local variables */
        int i__, k = 0, m, n, n1, n2, iq, iz, iu2, ldq, idx, ldu2, ivt2, idxc, idxp, ldvt2;
        int isigma;
        double orgnrm;
        int coltyp;

        /* Parameter adjustments */
        --d__;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        --idxq;
        --iwork;
        --work;

        /* Function Body */
        info = 0;

        if (nl < 1) {
	    info = -1;
        } else if (nr < 1) {
	    info = -2;
        } else if (sqre < 0 || sqre > 1) {
	    info = -3;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD1", i__1);
	    return 0;
        }

        n = nl + nr + 1;
        m = n + sqre;

    /*     The following values are for bookkeeping purposes only.  They are */
    /*     int pointers which indicate the portion of the workspace */
    /*     used by a particular array in DLASD2 and DLASD3. */

        ldu2 = n;
        ldvt2 = m;

        iz = 1;
        isigma = iz + m;
        iu2 = isigma + n;
        ivt2 = iu2 + ldu2 * n;
        iq = ivt2 + ldvt2 * m;

        idx = 1;
        idxc = idx + n;
        coltyp = idxc + n;
        idxp = coltyp + n;

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

    /*     Deflate singular values. */

        dlasd2(nl, nr, sqre, ref k, &d__[1], &work[iz], alpha, beta, &u[u_offset], 
	        ldu, &vt[vt_offset], ldvt, &work[isigma], &work[iu2], ldu2, &
	        work[ivt2], ldvt2, &iwork[idxp], &iwork[idx], &iwork[idxc], &
	        idxq[1], &iwork[coltyp], ref info);

    /*     Solve Secular Equation and update singular vectors. */

        ldq = k;
        dlasd3(nl, nr, sqre, k, &d__[1], &work[iq], ldq, &work[isigma], &u[
	        u_offset], ldu, &work[iu2], ldu2, &vt[vt_offset], ldvt, &work[
	        ivt2], ldvt2, &iwork[idxc], &iwork[coltyp], &work[iz], ref info);
        if (info != 0) {
	    return 0;
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

