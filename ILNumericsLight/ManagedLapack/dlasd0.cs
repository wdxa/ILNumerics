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
    public static unsafe int dlasd0(int n, int sqre, double* d__, double* e, double* u, int ldu, double* vt, int ldvt, int smlsiz, int* iwork, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__0 = 0;
        const int c__2 = 2;

        /* System generated locals */
        int u_dim1, u_offset, vt_dim1, vt_offset, i__1, i__2;

        /* Local variables */
        int i__, j, m, i1, ic, lf, nd=0, ll, nl, nr, im1, ncc, nlf, nrf, iwk, lvl, ndb1, nlp1, nrp1;
        double beta;
        int idxq, nlvl=0;
        double alpha;
        int inode, ndiml, idxqc, ndimr, itemp, sqrei;

        /* Parameter adjustments */
        --d__;
        --e;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        vt_dim1 = ldvt;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        --iwork;
        --work;

        /* Function Body */
        info = 0;

        if (n < 0) {
	    info = -1;
        } else if (sqre < 0 || sqre > 1) {
	    info = -2;
        }

        m = n + sqre;

        if (ldu < n) {
	    info = -6;
        } else if (ldvt < m) {
	    info = -8;
        } else if (smlsiz < 3) {
	    info = -9;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD0", i__1);
	    return 0;
        }

    /*     If the input matrix is too small, call DLASDQ to find the SVD. */

        if (n <= smlsiz) {
	    dlasdq('U', sqre, n, m, n, c__0, &d__[1], &e[1], &vt[vt_offset], 
		    ldvt, &u[u_offset], ldu, &u[u_offset], ldu, &work[1], ref info);
	    return 0;
        }

    /*     Set up the computation tree. */

        inode = 1;
        ndiml = inode + n;
        ndimr = ndiml + n;
        idxq = ndimr + n;
        iwk = idxq + n;
        dlasdt(n, ref nlvl, ref nd, &iwork[inode], &iwork[ndiml], &iwork[ndimr], 
	        smlsiz);

    /*     For the nodes on bottom level of the tree, solve */
    /*     their subproblems by DLASDQ. */

        ndb1 = (nd + 1) / 2;
        ncc = 0;
        i__1 = nd;
        for (i__ = ndb1; i__ <= i__1; ++i__) {

    /*     IC : center row of each node */
    /*     NL : number of rows of left  subproblem */
    /*     NR : number of rows of right subproblem */
    /*     NLF: starting row of the left   subproblem */
    /*     NRF: starting row of the right  subproblem */

	    i1 = i__ - 1;
	    ic = iwork[inode + i1];
	    nl = iwork[ndiml + i1];
	    nlp1 = nl + 1;
	    nr = iwork[ndimr + i1];
	    nrp1 = nr + 1;
	    nlf = ic - nl;
	    nrf = ic + 1;
	    sqrei = 1;
	    dlasdq('U', sqrei, nl, nlp1, nl, ncc, &d__[nlf], &e[nlf], &vt[
		    nlf + nlf * vt_dim1], ldvt, &u[nlf + nlf * u_dim1], ldu, &u[
		    nlf + nlf * u_dim1], ldu, &work[1], ref info);
	    if (info != 0) {
	        return 0;
	    }
	    itemp = idxq + nlf - 2;
	    i__2 = nl;
	    for (j = 1; j <= i__2; ++j) {
	        iwork[itemp + j] = j;
    /* L10: */
	    }
	    if (i__ == nd) {
	        sqrei = sqre;
	    } else {
	        sqrei = 1;
	    }
	    nrp1 = nr + sqrei;
	    dlasdq('U', sqrei, nr, nrp1, nr, ncc, &d__[nrf], &e[nrf], &vt[
		    nrf + nrf * vt_dim1], ldvt, &u[nrf + nrf * u_dim1], ldu, &u[
		    nrf + nrf * u_dim1], ldu, &work[1], ref info);
	    if (info != 0) {
	        return 0;
	    }
	    itemp = idxq + ic;
	    i__2 = nr;
	    for (j = 1; j <= i__2; ++j) {
	        iwork[itemp + j - 1] = j;
    /* L20: */
	    }
    /* L30: */
        }

    /*     Now conquer each subproblem bottom-up. */

        for (lvl = nlvl; lvl >= 1; --lvl) {

    /*        Find the first node LF and last node LL on the */
    /*        current level LVL. */

	    if (lvl == 1) {
	        lf = 1;
	        ll = 1;
	    } else {
	        i__1 = lvl - 1;
	        lf = pow_ii(c__2, i__1);
	        ll = (lf << 1) - 1;
	    }
	    i__1 = ll;
	    for (i__ = lf; i__ <= i__1; ++i__) {
	        im1 = i__ - 1;
	        ic = iwork[inode + im1];
	        nl = iwork[ndiml + im1];
	        nr = iwork[ndimr + im1];
	        nlf = ic - nl;
	        if (sqre == 0 && i__ == ll) {
		    sqrei = sqre;
	        } else {
		    sqrei = 1;
	        }
	        idxqc = idxq + nlf - 1;
	        alpha = d__[ic];
	        beta = e[ic];
	        dlasd1(nl, nr, sqrei, &d__[nlf], ref alpha, ref beta, &u[nlf + nlf *
		         u_dim1], ldu, &vt[nlf + nlf * vt_dim1], ldvt, &iwork[
		        idxqc], &iwork[iwk], &work[1], ref info);
	        if (info != 0) {
		    return 0;
	        }
    /* L40: */
	    }
    /* L50: */
        }

        return 0;
    } 
}

