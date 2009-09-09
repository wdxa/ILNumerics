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
    public static unsafe int dlaqps(int m, int n, int offset, int nb, ref int kb, double *a, int lda,
        int *jpvt, double *tau, double *vn1, double *vn2, double *auxv, double *f, int ldf)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b8 = -1.0;
        const double c_b9 = 1.0;
        const double c_b16 = 0.0;

        /* System generated locals */
        int a_dim1, a_offset, f_dim1, f_offset, i__1, i__2;
        double d__1, d__2;

        /* Local variables */
        int j, k, rk;
        double akk;
        int pvt;
        double temp;
        double temp2, tol3z;
        int itemp;
        int lsticc, lastrk;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --jpvt;
        --tau;
        --vn1;
        --vn2;
        --auxv;
        f_dim1 = ldf;
        f_offset = 1 + f_dim1;
        f -= f_offset;

        /* Function Body */
    /* Computing MIN */
        i__1 = m; i__2 = n + offset;
        lastrk = min(i__1,i__2);
        lsticc = 0;
        k = 0;
        tol3z = sqrt(dlamch('E'));

    /*     Beginning of while loop. */

    L10:
        if (k < nb && lsticc == 0) {
	    ++k;
	    rk = offset + k;

    /*        Determine ith pivot column and swap if necessary */

	    i__1 = n - k + 1;
	    pvt = k - 1 + idamax(i__1, &vn1[k], c__1);
	    if (pvt != k) {
	        dswap(m, &a[pvt * a_dim1 + 1], c__1, &a[k * a_dim1 + 1], c__1);
	        i__1 = k - 1;
	        dswap(i__1, &f[pvt + f_dim1], ldf, &f[k + f_dim1], ldf);
	        itemp = jpvt[pvt];
	        jpvt[pvt] = jpvt[k];
	        jpvt[k] = itemp;
	        vn1[pvt] = vn1[k];
	        vn2[pvt] = vn2[k];
	    }

    /*        Apply previous Householder reflectors to column K: */
    /*        A(RK:M,K) := A(RK:M,K) - A(RK:M,1:K-1)*F(K,1:K-1)'. */

	    if (k > 1) {
	        i__1 = m - rk + 1;
	        i__2 = k - 1;
	        dgemv('N', i__1, i__2, c_b8, &a[rk + a_dim1], lda, 
		        &f[k + f_dim1], ldf, c_b9, &a[rk + k * a_dim1], c__1);
	    }

    /*        Generate elementary reflector H(k). */

	    if (rk < m) {
	        i__1 = m - rk + 1;
	        dlarfg(i__1, ref a[rk + k * a_dim1], &a[rk + 1 + k * a_dim1], 
		        c__1, ref tau[k]);
	    } else {
	        dlarfg(c__1, ref a[rk + k * a_dim1], &a[rk + k * a_dim1], c__1, 
		        ref tau[k]);
	    }

	    akk = a[rk + k * a_dim1];
	    a[rk + k * a_dim1] = 1.0;

    /*        Compute Kth column of F: */

    /*        Compute  F(K+1:N,K) := tau(K)*A(RK:M,K+1:N)'*A(RK:M,K). */

	    if (k < n) {
	        i__1 = m - rk + 1;
	        i__2 = n - k;
	        dgemv('T', i__1, i__2, tau[k], &a[rk + (k + 1) * 
		        a_dim1], lda, &a[rk + k * a_dim1], c__1, c_b16, &f[k + 
		        1 + k * f_dim1], c__1);
	    }

    /*        Padding F(1:K,K) with zeros. */

	    i__1 = k;
	    for (j = 1; j <= i__1; ++j) {
	        f[j + k * f_dim1] = 0.0;
    /* L20: */
	    }

    /*        Incremental updating of F: */
    /*        F(1:N,K) := F(1:N,K) - tau(K)*F(1:N,1:K-1)*A(RK:M,1:K-1)' */
    /*                    *A(RK:M,K). */

	    if (k > 1) {
	        i__1 = m - rk + 1;
	        i__2 = k - 1;
	        d__1 = -tau[k];
	        dgemv('T', i__1, i__2, d__1, &a[rk + a_dim1], lda, &a[
		        rk + k * a_dim1], c__1, c_b16, &auxv[1], c__1);

	        i__1 = k - 1;
	        dgemv('N', n, i__1, c_b9, &f[f_dim1 + 1], ldf, &
		        auxv[1], c__1, c_b9, &f[k * f_dim1 + 1], c__1);
	    }

    /*        Update the current row of A: */
    /*        A(RK,K+1:N) := A(RK,K+1:N) - A(RK,1:K)*F(K+1:N,1:K)'. */

	    if (k < n) {
	        i__1 = n - k;
	        dgemv('N', i__1, k, c_b8, &f[k + 1 + f_dim1], ldf, 
		        &a[rk + a_dim1], lda, c_b9, &a[rk + (k + 1) * a_dim1], 
		        lda);
	    }

    /*        Update partial column norms. */

	    if (rk < lastrk) {
	        i__1 = n;
	        for (j = k + 1; j <= i__1; ++j) {
		    if (vn1[j] != 0.0) {

    /*                 NOTE: The following 4 lines follow from the analysis in */
    /*                 Lapack Working Note 176. */

                d__1 = a[rk + j * a_dim1];
		        temp = ( abs(d__1)) / vn1[j];
    /* Computing MAX */
                d__1 = 0.0;
                d__2 = (temp + 1.0) * (1.0 - temp);
		        temp = max(d__1,d__2);
    /* Computing 2nd power */
		        d__1 = vn1[j] / vn2[j];
		        temp2 = temp * (d__1 * d__1);
		        if (temp2 <= tol3z) {
			    vn2[j] = (double) lsticc;
			    lsticc = j;
		        } else {
			    vn1[j] *= sqrt(temp);
		        }
		    }
    /* L30: */
	        }
	    }

	    a[rk + k * a_dim1] = akk;

    /*        End of while loop. */

	    goto L10;
        }
        kb = k;
        rk = offset + kb;

    /*     Apply the block reflector to the rest of the matrix: */
    /*     A(OFFSET+KB+1:M,KB+1:N) := A(OFFSET+KB+1:M,KB+1:N) - */
    /*                         A(OFFSET+KB+1:M,1:KB)*F(KB+1:N,1:KB)'. */

    /* Computing MIN */
        i__1 = n; i__2 = m - offset;
        if (kb < min(i__1,i__2)) {
	    i__1 = m - rk;
	    i__2 = n - kb;
	    dgemm('N', 'T', i__1, i__2, kb, c_b8, &a[rk + 
		    1 + a_dim1], lda, &f[kb + 1 + f_dim1], ldf, c_b9, &a[rk + 1 
		    + (kb + 1) * a_dim1], lda);
        }

    /*     Recomputation of difficult columns. */

    L40:
        if (lsticc > 0) {
	    itemp = i_dnnt(vn2[lsticc]);
	    i__1 = m - rk;
	    vn1[lsticc] = dnrm2(i__1, &a[rk + 1 + lsticc * a_dim1], c__1);

    /*        NOTE: The computation of VN1( LSTICC ) relies on the fact that */
    /*        SNRM2 does not fail on vectors with norm below the value of */
    /*        SQRT(DLAMCH('S')) */

	    vn2[lsticc] = vn1[lsticc];
	    lsticc = itemp;
	    goto L40;
        }

        return 0;
    } 
}

