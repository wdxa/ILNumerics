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
    public static unsafe int dlasdq(char uplo, int sqre, int n, int ncvt, int nru, int ncc, double* d__,
        double* e, double* vt, int ldvt, double* u, int ldu, double* c__, int ldc, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int c_dim1, c_offset, u_dim1, u_offset, vt_dim1, vt_offset, i__1, i__2;

        /* Local variables */
        int i__, j;
        double r__=0, cs=0, sn=0;
        int np1, isub;
        double smin;
        int sqre1;
        int iuplo;
        bool rotate;

        /* Parameter adjustments */
        --d__;
        --e;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        --work;

        /* Function Body */
        info = 0;
        iuplo = 0;
        if (lsame(uplo, 'U')) {
	    iuplo = 1;
        }
        if (lsame(uplo, 'L')) {
	    iuplo = 2;
        }
        if (iuplo == 0) {
	    info = -1;
        } else if (sqre < 0 || sqre > 1) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (ncvt < 0) {
	    info = -4;
        } else if (nru < 0) {
	    info = -5;
        } else if (ncc < 0) {
	    info = -6;
        } else if (ncvt == 0 && ldvt < 1 || ncvt > 0 && ldvt < max(1,n)) {
	    info = -10;
        } else if (ldu < max(1,nru)) {
	    info = -12;
        } else if (ncc == 0 && ldc < 1 || ncc > 0 && ldc < max(1,n)) {
	    info = -14;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASDQ", i__1);
	    return 0;
        }
        if (n == 0) {
	    return 0;
        }

    /*     ROTATE is true if any singular vectors desired, false otherwise */

        rotate = ncvt > 0 || nru > 0 || ncc > 0;
        np1 = n + 1;
        sqre1 = sqre;

    /*     If matrix non-square upper bidiagonal, rotate to be lower */
    /*     bidiagonal.  The rotations are on the right. */

        if (iuplo == 1 && sqre1 == 1) {
	    i__1 = n - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        dlartg(d__[i__], e[i__], ref cs, ref sn, ref r__);
	        d__[i__] = r__;
	        e[i__] = sn * d__[i__ + 1];
	        d__[i__ + 1] = cs * d__[i__ + 1];
	        if (rotate) {
		    work[i__] = cs;
		    work[n + i__] = sn;
	        }
    /* L10: */
	    }
	    dlartg(d__[n], e[n], ref cs, ref sn, ref r__);
	    d__[n] = r__;
	    e[n] = 0.0;
	    if (rotate) {
	        work[n] = cs;
	        work[n + n] = sn;
	    }
	    iuplo = 2;
	    sqre1 = 0;

    /*        Update singular vectors if desired. */

	    if (ncvt > 0) {
	        dlasr('L', 'V', 'F', np1, ncvt, &work[1], &work[np1], &vt[
		        vt_offset], ldvt);
	    }
        }

    /*     If matrix lower bidiagonal, rotate to be upper bidiagonal */
    /*     by applying Givens rotations on the left. */

        if (iuplo == 2) {
	    i__1 = n - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        dlartg(d__[i__], e[i__], ref cs, ref sn, ref r__);
	        d__[i__] = r__;
	        e[i__] = sn * d__[i__ + 1];
	        d__[i__ + 1] = cs * d__[i__ + 1];
	        if (rotate) {
		    work[i__] = cs;
		    work[n + i__] = sn;
	        }
    /* L20: */
	    }

    /*        If matrix (N+1)-by-N lower bidiagonal, one additional */
    /*        rotation is needed. */

	    if (sqre1 == 1) {
	        dlartg(d__[n], e[n], ref cs, ref sn, ref r__);
	        d__[n] = r__;
	        if (rotate) {
		    work[n] = cs;
		    work[n + n] = sn;
	        }
	    }

    /*        Update singular vectors if desired. */

	    if (nru > 0) {
	        if (sqre1 == 0) {
		    dlasr('R', 'V', 'F', nru, n, &work[1], &work[np1], &u[
			    u_offset], ldu);
	        } else {
		    dlasr('R', 'V', 'F', nru, np1, &work[1], &work[np1], &u[
			    u_offset], ldu);
	        }
	    }
	    if (ncc > 0) {
	        if (sqre1 == 0) {
		    dlasr('L', 'V', 'F', n, ncc, &work[1], &work[np1], &c__[
			    c_offset], ldc);
	        } else {
		    dlasr('L', 'V', 'F', np1, ncc, &work[1], &work[np1], &c__[
			    c_offset], ldc);
	        }
	    }
        }

    /*     Call DBDSQR to compute the SVD of the reduced real */
    /*     N-by-N upper bidiagonal matrix. */

        dbdsqr('U', n, ncvt, nru, ncc, &d__[1], &e[1], &vt[vt_offset], ldvt, &u[
	        u_offset], ldu, &c__[c_offset], ldc, &work[1], ref info);

    /*     Sort the singular values into ascending order (insertion sort on */
    /*     singular values, but only one transposition per singular vector) */

        i__1 = n;
        for (i__ = 1; i__ <= i__1; ++i__) {

    /*        Scan for smallest D(I). */

	    isub = i__;
	    smin = d__[i__];
	    i__2 = n;
	    for (j = i__ + 1; j <= i__2; ++j) {
	        if (d__[j] < smin) {
		    isub = j;
		    smin = d__[j];
	        }
    /* L30: */
	    }
	    if (isub != i__) {

    /*           Swap singular values and vectors. */

	        d__[isub] = d__[i__];
	        d__[i__] = smin;
	        if (ncvt > 0) {
		    dswap(ncvt, &vt[isub + vt_dim1], ldvt, &vt[i__ + vt_dim1], 
			    ldvt);
	        }
	        if (nru > 0) {
		    dswap(nru, &u[isub * u_dim1 + 1], c__1, &u[i__ * u_dim1 + 1], c__1);
	        }
	        if (ncc > 0) {
		    dswap(ncc, &c__[isub + c_dim1], ldc, &c__[i__ + c_dim1], ldc);
	        }
	    }
    /* L40: */
        }

        return 0;
    } 
}

