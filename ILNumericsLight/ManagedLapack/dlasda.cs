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
    public static unsafe int dlasda(int icompq, int smlsiz, int n, int sqre, double* d__, double* e, double* u,
        int ldu, double* vt, int* k, double* difl, double* difr, double* z__, double* poles, int* givptr, int* givcol,
        int ldgcol, int* perm, double* givnum, double* c__, double* s, double* work, int* iwork, ref int info)
    {
        /* Table of constant values */
        const int c__0 = 0;
        const double c_b11 = 0.0;
        const double c_b12 = 1.0;
        const int c__1 = 1;
        const int c__2 = 2;

        /* System generated locals */
        int givcol_dim1, givcol_offset, perm_dim1, perm_offset, difl_dim1, 
	        difl_offset, difr_dim1, difr_offset, givnum_dim1, givnum_offset, 
	        poles_dim1, poles_offset, u_dim1, u_offset, vt_dim1, vt_offset, 
	        z_dim1, z_offset, i__1, i__2;

        /* Local variables */
        int i__, j, m, i1, ic, lf, nd=0, ll, nl, vf, nr, vl, im1, ncc, nlf, nrf,
	         vfi, iwk, vli, lvl, nru, ndb1, nlp1, lvl2, nrp1;
        double beta;
        int idxq, nlvl=0;
        double alpha;
        int inode, ndiml, ndimr, idxqi, itemp;
        int sqrei;
        int nwork1, nwork2;
        int smlszp;

        /* Parameter adjustments */
        --d__;
        --e;
        givnum_dim1 = ldu;
        givnum_offset = 1 + givnum_dim1;
        givnum -= givnum_offset;
        poles_dim1 = ldu;
        poles_offset = 1 + poles_dim1;
        poles -= poles_offset;
        z_dim1 = ldu;
        z_offset = 1 + z_dim1;
        z__ -= z_offset;
        difr_dim1 = ldu;
        difr_offset = 1 + difr_dim1;
        difr -= difr_offset;
        difl_dim1 = ldu;
        difl_offset = 1 + difl_dim1;
        difl -= difl_offset;
        vt_dim1 = ldu;
        vt_offset = 1 + vt_dim1;
        vt -= vt_offset;
        u_dim1 = ldu;
        u_offset = 1 + u_dim1;
        u -= u_offset;
        --k;
        --givptr;
        perm_dim1 = ldgcol;
        perm_offset = 1 + perm_dim1;
        perm -= perm_offset;
        givcol_dim1 = ldgcol;
        givcol_offset = 1 + givcol_dim1;
        givcol -= givcol_offset;
        --c__;
        --s;
        --work;
        --iwork;

        /* Function Body */
        info = 0;

        if (icompq < 0 || icompq > 1) {
	    info = -1;
        } else if (smlsiz < 3) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (sqre < 0 || sqre > 1) {
	    info = -4;
        } else if (ldu < n + sqre) {
	    info = -8;
        } else if (ldgcol < n) {
	    info = -17;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASDA", i__1);
	    return 0;
        }

        m = n + sqre;

    /*     If the input matrix is too small, call DLASDQ to find the SVD. */

        if (n <= smlsiz) {
	    if (icompq == 0) {
	        dlasdq('U', sqre, n, c__0, c__0, c__0, &d__[1], &e[1], &vt[
		        vt_offset], ldu, &u[u_offset], ldu, &u[u_offset], ldu, &
		        work[1], ref info);
	    } else {
	        dlasdq('U', sqre, n, m, n, c__0, &d__[1], &e[1], &vt[vt_offset]
    , ldu, &u[u_offset], ldu, &u[u_offset], ldu, &work[1], 
		        ref info);
	    }
	    return 0;
        }

    /*     Book-keeping and  set up the computation tree. */

        inode = 1;
        ndiml = inode + n;
        ndimr = ndiml + n;
        idxq = ndimr + n;
        iwk = idxq + n;

        ncc = 0;
        nru = 0;

        smlszp = smlsiz + 1;
        vf = 1;
        vl = vf + m;
        nwork1 = vl + m;
        nwork2 = nwork1 + smlszp * smlszp;

        dlasdt(n, ref nlvl, ref nd, &iwork[inode], &iwork[ndiml], &iwork[ndimr], 
	        smlsiz);

    /*     for the nodes on bottom level of the tree, solve */
    /*     their subproblems by DLASDQ. */

        ndb1 = (nd + 1) / 2;
        i__1 = nd;
        for (i__ = ndb1; i__ <= i__1; ++i__) {

    /*        IC : center row of each node */
    /*        NL : number of rows of left  subproblem */
    /*        NR : number of rows of right subproblem */
    /*        NLF: starting row of the left   subproblem */
    /*        NRF: starting row of the right  subproblem */

	    i1 = i__ - 1;
	    ic = iwork[inode + i1];
	    nl = iwork[ndiml + i1];
	    nlp1 = nl + 1;
	    nr = iwork[ndimr + i1];
	    nlf = ic - nl;
	    nrf = ic + 1;
	    idxqi = idxq + nlf - 2;
	    vfi = vf + nlf - 1;
	    vli = vl + nlf - 1;
	    sqrei = 1;
	    if (icompq == 0) {
	        dlaset('A', nlp1, nlp1, c_b11, c_b12, &work[nwork1], smlszp);
	        dlasdq('U', sqrei, nl, nlp1, nru, ncc, &d__[nlf], &e[nlf], &
		        work[nwork1], smlszp, &work[nwork2], nl, &work[nwork2], 
		        nl, &work[nwork2], ref info);
	        itemp = nwork1 + nl * smlszp;
	        dcopy(nlp1, &work[nwork1], c__1, &work[vfi], c__1);
	        dcopy(nlp1, &work[itemp], c__1, &work[vli], c__1);
	    } else {
	        dlaset('A', nl, nl, c_b11, c_b12, &u[nlf + u_dim1], ldu);
	        dlaset('A', nlp1, nlp1, c_b11, c_b12, &vt[nlf + vt_dim1], 
		        ldu);
	        dlasdq('U', sqrei, nl, nlp1, nl, ncc, &d__[nlf], &e[nlf], &
		        vt[nlf + vt_dim1], ldu, &u[nlf + u_dim1], ldu, &u[nlf + 
		        u_dim1], ldu, &work[nwork1], ref info);
	        dcopy(nlp1, &vt[nlf + vt_dim1], c__1, &work[vfi], c__1);
	        dcopy(nlp1, &vt[nlf + nlp1 * vt_dim1], c__1, &work[vli], c__1)
		        ;
	    }
	    if (info != 0) {
	        return 0;
	    }
	    i__2 = nl;
	    for (j = 1; j <= i__2; ++j) {
	        iwork[idxqi + j] = j;
    /* L10: */
	    }
	    if (i__ == nd && sqre == 0) {
	        sqrei = 0;
	    } else {
	        sqrei = 1;
	    }
	    idxqi += nlp1;
	    vfi += nlp1;
	    vli += nlp1;
	    nrp1 = nr + sqrei;
	    if (icompq == 0) {
	        dlaset('A', nrp1, nrp1, c_b11, c_b12, &work[nwork1], smlszp);
	        dlasdq('U', sqrei, nr, nrp1, nru, ncc, &d__[nrf], &e[nrf], &
		        work[nwork1], smlszp, &work[nwork2], nr, &work[nwork2], 
		        nr, &work[nwork2], ref info);
	        itemp = nwork1 + (nrp1 - 1) * smlszp;
	        dcopy(nrp1, &work[nwork1], c__1, &work[vfi], c__1);
	        dcopy(nrp1, &work[itemp], c__1, &work[vli], c__1);
	    } else {
	        dlaset('A', nr, nr, c_b11, c_b12, &u[nrf + u_dim1], ldu);
	        dlaset('A', nrp1, nrp1, c_b11, c_b12, &vt[nrf + vt_dim1], 
		        ldu);
	        dlasdq('U', sqrei, nr, nrp1, nr, ncc, &d__[nrf], &e[nrf], &
		        vt[nrf + vt_dim1], ldu, &u[nrf + u_dim1], ldu, &u[nrf + 
		        u_dim1], ldu, &work[nwork1], ref info);
	        dcopy(nrp1, &vt[nrf + vt_dim1], c__1, &work[vfi], c__1);
	        dcopy(nrp1, &vt[nrf + nrp1 * vt_dim1], c__1, &work[vli], c__1)
		        ;
	    }
	    if (info != 0) {
	        return 0;
	    }
	    i__2 = nr;
	    for (j = 1; j <= i__2; ++j) {
	        iwork[idxqi + j] = j;
    /* L20: */
	    }
    /* L30: */
        }

    /*     Now conquer each subproblem bottom-up. */

        j = pow_ii(c__2, nlvl);
        for (lvl = nlvl; lvl >= 1; --lvl) {
	    lvl2 = (lvl << 1) - 1;

    /*        Find the first node LF and last node LL on */
    /*        the current level LVL. */

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
	        nrf = ic + 1;
	        if (i__ == ll) {
		    sqrei = sqre;
	        } else {
		    sqrei = 1;
	        }
	        vfi = vf + nlf - 1;
	        vli = vl + nlf - 1;
	        idxqi = idxq + nlf - 1;
	        alpha = d__[ic];
	        beta = e[ic];
	        if (icompq == 0) {
		    dlasd6(icompq, nl, nr, sqrei, &d__[nlf], &work[vfi], &
			    work[vli], alpha, beta, &iwork[idxqi], &perm[
			    perm_offset], ref givptr[1], &givcol[givcol_offset], 
			    ldgcol, &givnum[givnum_offset], ldu, &poles[
			    poles_offset], &difl[difl_offset], &difr[difr_offset], 
			     &z__[z_offset], ref k[1], ref c__[1], ref s[1], &work[nwork1], 
			     &iwork[iwk], ref info);
	        } else {
		    --j;
		    dlasd6(icompq, nl, nr, sqrei, &d__[nlf], &work[vfi], &
			    work[vli], alpha, beta, &iwork[idxqi], &perm[nlf + 
			    lvl * perm_dim1], ref givptr[j], &givcol[nlf + lvl2 * 
			    givcol_dim1], ldgcol, &givnum[nlf + lvl2 * 
			    givnum_dim1], ldu, &poles[nlf + lvl2 * poles_dim1], &
			    difl[nlf + lvl * difl_dim1], &difr[nlf + lvl2 * 
			    difr_dim1], &z__[nlf + lvl * z_dim1], ref k[j], ref c__[j], 
			    ref s[j], &work[nwork1], &iwork[iwk], ref info);
	        }
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

