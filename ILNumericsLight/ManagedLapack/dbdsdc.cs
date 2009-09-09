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
    public static unsafe int dbdsdc(char uplo, char compq, int n, double* d__, double* e, double* u, int ldu,
        double* vt, int ldvt, double* q, int* iq, double* work, int* iwork, ref int info)
    {
        /* Table of constant values */
        const int c__9 = 9;
        const int c__0 = 0;
        const double c_b15 = 1.0;
        const int c__1 = 1;
        const double c_b29 = 0.0;

        /* System generated locals */
        int u_dim1, u_offset, vt_dim1, vt_offset, i__1, i__2;

        /* Local variables */
        int i__, j, k=0;
        double p, r__=0;
        int z__=0, ic=0, ii, kk;
        double cs=0;
        int _is=0, iu=0;
        double sn=0;
        int nm1;
        double eps;
        int ivt=0, difl=0, difr=0, ierr=0, perm=0, mlvl, sqre;
        int poles=0, iuplo, nsize, start;
        int givcol=0;
        int icompq;
        double orgnrm;
        int givnum=0, givptr=0, qstart, smlsiz, wstart, smlszp;

        /* Parameter adjustments */
        --d__;
        --e;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        --q;
        --iq;
        --work;
        --iwork;

        /* Function Body */
        info = 0;

        iuplo = 0;
        if (lsame(uplo, 'U')) {
	    iuplo = 1;
        }
        if (lsame(uplo, 'L')) {
	    iuplo = 2;
        }
        if (lsame(compq, 'N')) {
	    icompq = 0;
        } else if (lsame(compq, 'P')) {
	    icompq = 1;
        } else if (lsame(compq, 'I')) {
	    icompq = 2;
        } else {
	    icompq = -1;
        }
        if (iuplo == 0) {
	    info = -1;
        } else if (icompq < 0) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (ldu < 1 || icompq == 2 && ldu < n) {
	    info = -7;
        } else if (ldvt < 1 || icompq == 2 && ldvt < n) {
	    info = -9;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DBDSDC", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }
        smlsiz = ilaenv(c__9, "DBDSDC", " ", c__0, c__0, c__0, c__0);
        if (n == 1) {
	    if (icompq == 1) {
	        q[1] = d_sign(c_b15, d__[1]);
	        q[smlsiz * n + 1] = 1.0;
	    } else if (icompq == 2) {
	        u[u_dim1 + 1] = d_sign(c_b15, d__[1]);
	        vt[vt_dim1 + 1] = 1.0;
	    }
	    d__[1] = abs(d__[1]);
	    return 0;
        }
        nm1 = n - 1;

    /*     If matrix lower bidiagonal, rotate to be upper bidiagonal */
    /*     by applying Givens rotations on the left */

        wstart = 1;
        qstart = 3;
        if (icompq == 1) {
	    dcopy(n, &d__[1], c__1, &q[1], c__1);
	    i__1 = n - 1;
	    dcopy(i__1, &e[1], c__1, &q[n + 1], c__1);
        }
        if (iuplo == 2) {
	    qstart = 5;
	    wstart = (n << 1) - 1;
	    i__1 = n - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        dlartg(d__[i__], e[i__], ref cs, ref sn, ref r__);
	        d__[i__] = r__;
	        e[i__] = sn * d__[i__ + 1];
	        d__[i__ + 1] = cs * d__[i__ + 1];
	        if (icompq == 1) {
		    q[i__ + (n << 1)] = cs;
		    q[i__ + n * 3] = sn;
	        } else if (icompq == 2) {
		    work[i__] = cs;
		    work[nm1 + i__] = -sn;
	        }
    /* L10: */
	    }
        }

    /*     If ICOMPQ = 0, use DLASDQ to compute the singular values. */

        if (icompq == 0) {
	    dlasdq('U', c__0, n, c__0, c__0, c__0, &d__[1], &e[1], &vt[
		    vt_offset], ldvt, &u[u_offset], ldu, &u[u_offset], ldu, &work[
		    wstart], ref info);
	    goto L40;
        }

    /*     If N _is smaller than the minimum divide size SMLSIZ, then solve */
    /*     the problem with another solver. */

        if (n <= smlsiz) {
	    if (icompq == 2) {
	        dlaset('A', n, n, c_b29, c_b15, &u[u_offset], ldu);
	        dlaset('A', n, n, c_b29, c_b15, &vt[vt_offset], ldvt);
	        dlasdq('U', c__0, n, n, n, c__0, &d__[1], &e[1], &vt[vt_offset]
    , ldvt, &u[u_offset], ldu, &u[u_offset], ldu, &work[
		        wstart], ref info);
	    } else if (icompq == 1) {
	        iu = 1;
	        ivt = iu + n;
	        dlaset('A', n, n, c_b29, c_b15, &q[iu + (qstart - 1) * n], n);
	        dlaset('A', n, n, c_b29, c_b15, &q[ivt + (qstart - 1) * n], n);
	        dlasdq('U', c__0, n, n, n, c__0, &d__[1], &e[1], &q[ivt + (
		        qstart - 1) * n], n, &q[iu + (qstart - 1) * n], n, &q[
		        iu + (qstart - 1) * n], n, &work[wstart], ref info);
	    }
	    goto L40;
        }

        if (icompq == 2) {
	    dlaset('A', n, n, c_b29, c_b15, &u[u_offset], ldu);
	    dlaset('A', n, n, c_b29, c_b15, &vt[vt_offset], ldvt);
        }

    /*     Scale. */

        orgnrm = dlanst('M', n, &d__[1], &e[1]);
        if (orgnrm == 0.0) {
	    return 0;
        }
        dlascl('G', c__0, c__0, orgnrm, c_b15, n, c__1, &d__[1], n, ref ierr);
        dlascl('G', c__0, c__0, orgnrm, c_b15, nm1, c__1, &e[1], nm1, ref ierr);

        eps = dlamch('E');

        mlvl = (int) (log((double) (n) / (double) (smlsiz + 1)) / 
	        log(2.0)) + 1;
        smlszp = smlsiz + 1;

        if (icompq == 1) {
	    iu = 1;
	    ivt = smlsiz + 1;
	    difl = ivt + smlszp;
	    difr = difl + mlvl;
	    z__ = difr + (mlvl << 1);
	    ic = z__ + mlvl;
	    _is = ic + 1;
	    poles = _is + 1;
	    givnum = poles + (mlvl << 1);

	    k = 1;
	    givptr = 2;
	    perm = 3;
	    givcol = perm + mlvl;
        }

        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if (abs(d__[i__]) < eps) {
	        d__[i__] = d_sign(eps, d__[i__]);
	    }
    /* L20: */
        }

        start = 1;
        sqre = 0;

        i__1 = nm1;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    if ((abs(e[i__])) < eps || i__ == nm1) {

    /*        Subproblem found. First determine its size and then */
    /*        apply divide and conquer on it. */

	        if (i__ < nm1) {

    /*        A subproblem with E(I) small for I < NM1. */

		    nsize = i__ - start + 1;
	        } else if ((abs(e[i__])) >= eps) {

    /*        A subproblem with E(NM1) not too small but I = NM1. */

		    nsize = n - start + 1;
	        } else {

    /*        A subproblem with E(NM1) small. This implies an */
    /*        1-by-1 subproblem at D(N). Solve this 1-by-1 problem */
    /*        first. */

		    nsize = i__ - start + 1;
		    if (icompq == 2) {
		        u[n + n * u_dim1] = d_sign(c_b15, d__[n]);
		        vt[n + n * vt_dim1] = 1.0;
		    } else if (icompq == 1) {
		        q[n + (qstart - 1) * n] = d_sign(c_b15, d__[n]);
		        q[n + (smlsiz + qstart - 1) * n] = 1.0;
		    }
		    d__[n] = (abs(d__[n]));
	        }
	        if (icompq == 2) {
		    dlasd0(nsize, sqre, &d__[start], &e[start], &u[start + 
			    start * u_dim1], ldu, &vt[start + start * vt_dim1], 
			    ldvt, smlsiz, &iwork[1], &work[wstart], ref info);
	        } else {
		    dlasda(icompq, smlsiz, nsize, sqre, &d__[start], &e[
			    start], &q[start + (iu + qstart - 2) * n], n, &q[
			    start + (ivt + qstart - 2) * n], &iq[start + k * n], 
			     &q[start + (difl + qstart - 2) * n], &q[start + (
			    difr + qstart - 2) * n], &q[start + (z__ + qstart - 
			    2) * n], &q[start + (poles + qstart - 2) * n], &iq[
			    start + givptr * n], &iq[start + givcol * n], n, &
			    iq[start + perm * n], &q[start + (givnum + qstart - 
			    2) * n], &q[start + (ic + qstart - 2) * n], &q[
			    start + (_is + qstart - 2) * n], &work[wstart], &
			    iwork[1], ref info);
		    if (info != 0) {
		        return 0;
		    }
	        }
	        start = i__ + 1;
	    }
    /* L30: */
        }

    /*     Unscale */

        dlascl('G', c__0, c__0, c_b15, orgnrm, n, c__1, &d__[1], n, ref ierr);
    L40:

    /*     Use Selection Sort to minimize swaps of singular vectors */

        i__1 = n;
        for (ii = 2; ii <= i__1; ++ii) {
	    i__ = ii - 1;
	    kk = i__;
	    p = d__[i__];
	    i__2 = n;
	    for (j = ii; j <= i__2; ++j) {
	        if (d__[j] > p) {
		    kk = j;
		    p = d__[j];
	        }
    /* L50: */
	    }
	    if (kk != i__) {
	        d__[kk] = d__[i__];
	        d__[i__] = p;
	        if (icompq == 1) {
		    iq[i__] = kk;
	        } else if (icompq == 2) {
		    dswap(n, &u[i__ * u_dim1 + 1], c__1, &u[kk * u_dim1 + 1], c__1);
		    dswap(n, &vt[i__ + vt_dim1], ldvt, &vt[kk + vt_dim1], ldvt);
	        }
	    } else if (icompq == 1) {
	        iq[i__] = i__;
	    }
    /* L60: */
        }

    /*     If ICOMPQ = 1, use IQ(N,1) as the indicator for UPLO */

        if (icompq == 1) {
	    if (iuplo == 1) {
	        iq[n] = 1;
	    } else {
	        iq[n] = 0;
	    }
        }

    /*     If B _is lower bidiagonal, update U by those Givens rotations */
    /*     which rotated B to be upper bidiagonal */

        if (iuplo == 2 && icompq == 2) {
	    dlasr('L', 'V', 'B', n, n, &work[1], &work[n], &u[u_offset], ldu);
        }

        return 0;
    } 
}

