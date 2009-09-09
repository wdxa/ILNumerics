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
    public static unsafe int dlaln2(bool ltrans, int na, int nw, double smin, double ca,
        double* a, int lda, double d1, double d2, double* b, int ldb, double wr, double wi,
        double* x, int ldx, ref double scale, ref double xnorm, ref int info)
    {
        /* Initialized data */

        bool[] zswap = { false,false,true,true };
        bool[] rswap = { false,true,false,true };
        int[] ipivot  = { 1,2,3,4,2,1,4,3,3,4,1,2,4,3,2,1 };

        /* System generated locals */
        int a_dim1, a_offset, b_dim1, b_offset, x_dim1, x_offset;
        double d__1, d__2, d__3, d__4, d__5, d__6;

        double* equiv_0 = stackalloc double[4], equiv_1 = stackalloc double[4];

        /* Local variables */
        int j;
        double bi1, bi2, br1, br2, xi1, xi2=0, xr1=0, xr2=0, ci21, ci22, cr21, cr22;
        double li21, csi, ui11, lr21, ui12, ui22, csr, ur11, ur12, ur22;
        double bbnd, cmax, ui11r, ui12s, temp, ur11r, ur12s, u22abs;
        int icmax;
        double bnorm, cnorm, smini;
        double bignum, smlnum;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        b_dim1 = ldb;
        b_offset = 1 + b_dim1;
        b -= b_offset;
        x_dim1 = ldx;
        x_offset = 1 + x_dim1;
        x -= x_offset;

        /* Function Body */
    /*     .. */
    /*     .. Executable Statements .. */

    /*     Compute BIGNUM */

        smlnum = 2.0 * dlamch('S');
        bignum = 1.0 / smlnum;
        smini = max(smin,smlnum);

    /*     Don't check for input errors */

        info = 0;

    /*     Standard Initializations */

        scale = 1.0;

        if (na == 1) {

    /*        1 x 1  (i.e., scalar) system   C X = B */

	    if (nw == 1) {

    /*           Real 1x1 system. */

    /*           C = ca A - w D */

	        csr = ca * a[a_dim1 + 1] - wr * d1;
	        cnorm = abs(csr);

    /*           If | C | < SMINI, use C = SMINI */

	        if (cnorm < smini) {
		    csr = smini;
		    cnorm = smini;
		    info = 1;
	        }

    /*           Check scaling for  X = B / C */

            d__1 = b[b_dim1 + 1];
	        bnorm = ( abs(d__1));
	        if (cnorm < 1.0 && bnorm > 1.0) {
		    if (bnorm > bignum * cnorm) {
		        scale = 1.0 / bnorm;
		    }
	        }

    /*           Compute X */

	        x[x_dim1 + 1] = b[b_dim1 + 1] * scale / csr;
            d__1 = x[x_dim1 + 1];
	        xnorm = ( abs(d__1));
	    } else {

    /*           Complex 1x1 system (w is complex) */

    /*           C = ca A - w D */

	        csr = ca * a[a_dim1 + 1] - wr * d1;
	        csi = -(wi) * d1;
	        cnorm = abs(csr) + abs(csi);

    /*           If | C | < SMINI, use C = SMINI */

	        if (cnorm < smini) {
		    csr = smini;
		    csi = 0.0;
		    cnorm = smini;
		    info = 1;
	        }

    /*           Check scaling for  X = B / C */

            d__1 = b[b_dim1 + 1];
            d__2 = b[(b_dim1 << 1) + 1];
	        bnorm = ( abs(d__1)) + ( abs(d__2));
	        if (cnorm < 1.0 && bnorm > 1.0) {
		    if (bnorm > bignum * cnorm) {
		        scale = 1.0 / bnorm;
		    }
	        }

    /*           Compute X */

	        d__1 = scale * b[b_dim1 + 1];
	        d__2 = scale * b[(b_dim1 << 1) + 1];
	        dladiv(d__1, d__2, csr, csi, ref x[x_dim1 + 1], ref x[(x_dim1 << 1)
		         + 1]);
            d__1 = x[x_dim1 + 1];
            d__2 = x[(x_dim1 << 1) + 1];
	        xnorm = ( abs(d__1)) + ( abs(d__2));
	    }

        } else {

    /*        2x2 System */

    /*        Compute the real part of  C = ca A - w D  (or  ca A' - w D ) */

	    equiv_1[0] = ca * a[a_dim1 + 1] - wr * d1;
	    equiv_1[3] = ca * a[(a_dim1 << 1) + 2] - wr * d2;
	    if (ltrans) {
	        equiv_1[2] = ca * a[a_dim1 + 2];
	        equiv_1[1] = ca * a[(a_dim1 << 1) + 1];
	    } else {
	        equiv_1[1] = ca * a[a_dim1 + 2];
	        equiv_1[2] = ca * a[(a_dim1 << 1) + 1];
	    }

	    if (nw == 1) {

    /*           Real 2x2 system  (w is real) */

    /*           Find the largest element in C */

	        cmax = 0.0;
	        icmax = 0;

	        for (j = 1; j <= 4; ++j) {
		    if ((abs(equiv_1[j - 1])) > cmax) {
                d__1 = equiv_1[j - 1];
		        cmax = ( abs(d__1));
		        icmax = j;
		    }
    /* L10: */
	        }

    /*           If norm(C) < SMINI, use SMINI*identity. */

	        if (cmax < smini) {
    /* Computing MAX */
            d__1 = b[b_dim1 + 1];
		    d__3 = ( abs(d__1));
            d__2 = b[b_dim1 + 2];
            d__4 = (abs(d__2));
		    bnorm = max(d__3,d__4);
		    if (smini < 1.0 && bnorm > 1.0) {
		        if (bnorm > bignum * smini) {
			    scale = 1.0 / bnorm;
		        }
		    }
		    temp = scale / smini;
		    x[x_dim1 + 1] = temp * b[b_dim1 + 1];
		    x[x_dim1 + 2] = temp * b[b_dim1 + 2];
		    xnorm = temp * bnorm;
		    info = 1;
		    return 0;
	        }

    /*           Gaussian elimination with complete pivoting. */

	        ur11 = equiv_1[icmax - 1];
	        cr21 = equiv_1[ipivot[(icmax << 2) - 3] - 1];
	        ur12 = equiv_1[ipivot[(icmax << 2) - 2] - 1];
	        cr22 = equiv_1[ipivot[(icmax << 2) - 1] - 1];
	        ur11r = 1.0 / ur11;
	        lr21 = ur11r * cr21;
	        ur22 = cr22 - ur12 * lr21;

    /*           If smaller pivot < SMINI, use SMINI */

	        if (abs(ur22) < smini) {
		    ur22 = smini;
		    info = 1;
	        }
	        if (rswap[icmax - 1]) {
		    br1 = b[b_dim1 + 2];
		    br2 = b[b_dim1 + 1];
	        } else {
		    br1 = b[b_dim1 + 1];
		    br2 = b[b_dim1 + 2];
	        }
	        br2 -= lr21 * br1;
    /* Computing MAX */
            d__1 = br1 * (ur22 * ur11r);
	        d__2 = (abs(d__1)); d__3 = abs(br2);
	        bbnd = max(d__2,d__3);
	        if (bbnd > 1.0 && abs(ur22) < 1.0) {
		    if (bbnd >= bignum * abs(ur22)) {
		        scale = 1.0 / bbnd;
		    }
	        }

	        xr2 = br2 * scale / ur22;
	        xr1 = scale * br1 * ur11r - xr2 * (ur11r * ur12);
	        if (zswap[icmax - 1]) {
		    x[x_dim1 + 1] = xr2;
		    x[x_dim1 + 2] = xr1;
	        } else {
		    x[x_dim1 + 1] = xr1;
		    x[x_dim1 + 2] = xr2;
	        }
    /* Computing MAX */
	        d__1 = abs(xr1); d__2 = abs(xr2);
	        xnorm = max(d__1,d__2);

    /*           Further scaling if  norm(A) norm(X) > overflow */

	        if (xnorm > 1.0 && cmax > 1.0) {
		    if (xnorm > bignum / cmax) {
		        temp = cmax / bignum;
		        x[x_dim1 + 1] = temp * x[x_dim1 + 1];
		        x[x_dim1 + 2] = temp * x[x_dim1 + 2];
		        xnorm = temp * xnorm;
		        scale = temp * scale;
		    }
	        }
	    } else {

    /*           Complex 2x2 system  (w is complex) */

    /*           Find the largest element in C */

	        equiv_0[0] = -(wi) * d1;
	        equiv_0[1] = 0.0;
	        equiv_0[2] = 0.0;
	        equiv_0[3] = -(wi) * d2;
	        cmax = 0.0;
	        icmax = 0;

	        for (j = 1; j <= 4; ++j) {
		    if ((abs(equiv_1[j - 1])) + (abs(equiv_0[j - 1])) > cmax) {
                d__1 = equiv_1[j - 1];
                d__2 = equiv_0[j - 1];
		        cmax = (abs(d__1)) + ( abs(d__2));
		        icmax = j;
		    }
    /* L20: */
	        }

    /*           If norm(C) < SMINI, use SMINI*identity. */

	        if (cmax < smini) {
    /* Computing MAX */
            d__1 = b[b_dim1 + 1];
            d__2 = b[(b_dim1 << 1) + 1];
		    d__5 = ( abs(d__1)) + ( abs(d__2));
            d__3 = b[b_dim1 + 2];
            d__4 = b[(b_dim1 << 1) + 2];
            d__6 = ( abs(d__3)) + (abs(d__4));
		    bnorm = max(d__5,d__6);
		    if (smini < 1.0 && bnorm > 1.0) {
		        if (bnorm > bignum * smini) {
			    scale = 1.0 / bnorm;
		        }
		    }
		    temp = scale / smini;
		    x[x_dim1 + 1] = temp * b[b_dim1 + 1];
		    x[x_dim1 + 2] = temp * b[b_dim1 + 2];
		    x[(x_dim1 << 1) + 1] = temp * b[(b_dim1 << 1) + 1];
		    x[(x_dim1 << 1) + 2] = temp * b[(b_dim1 << 1) + 2];
		    xnorm = temp * bnorm;
		    info = 1;
		    return 0;
	        }

    /*           Gaussian elimination with complete pivoting. */

	        ur11 = equiv_1[icmax - 1];
	        ui11 = equiv_0[icmax - 1];
	        cr21 = equiv_1[ipivot[(icmax << 2) - 3] - 1];
	        ci21 = equiv_0[ipivot[(icmax << 2) - 3] - 1];
	        ur12 = equiv_1[ipivot[(icmax << 2) - 2] - 1];
	        ui12 = equiv_0[ipivot[(icmax << 2) - 2] - 1];
	        cr22 = equiv_1[ipivot[(icmax << 2) - 1] - 1];
	        ci22 = equiv_0[ipivot[(icmax << 2) - 1] - 1];
	        if (icmax == 1 || icmax == 4) {

    /*              Code when off-diagonals of pivoted C are real */

		    if (abs(ur11) > abs(ui11)) {
		        temp = ui11 / ur11;
    /* Computing 2nd power */
		        d__1 = temp;
		        ur11r = 1.0 / (ur11 * (d__1 * d__1 + 1.0));
		        ui11r = -temp * ur11r;
		    } else {
		        temp = ur11 / ui11;
    /* Computing 2nd power */
		        d__1 = temp;
		        ui11r = -1.0 / (ui11 * (d__1 * d__1 + 1.0));
		        ur11r = -temp * ui11r;
		    }
		    lr21 = cr21 * ur11r;
		    li21 = cr21 * ui11r;
		    ur12s = ur12 * ur11r;
		    ui12s = ur12 * ui11r;
		    ur22 = cr22 - ur12 * lr21;
		    ui22 = ci22 - ur12 * li21;
	        } else {

    /*              Code when diagonals of pivoted C are real */

		    ur11r = 1.0 / ur11;
		    ui11r = 0.0;
		    lr21 = cr21 * ur11r;
		    li21 = ci21 * ur11r;
		    ur12s = ur12 * ur11r;
		    ui12s = ui12 * ur11r;
		    ur22 = cr22 - ur12 * lr21 + ui12 * li21;
		    ui22 = -ur12 * li21 - ui12 * lr21;
	        }
	        u22abs = abs(ur22) + abs(ui22);

    /*           If smaller pivot < SMINI, use SMINI */

	        if (u22abs < smini) {
		    ur22 = smini;
		    ui22 = 0.0;
		    info = 1;
	        }
	        if (rswap[icmax - 1]) {
		    br2 = b[b_dim1 + 1];
		    br1 = b[b_dim1 + 2];
		    bi2 = b[(b_dim1 << 1) + 1];
		    bi1 = b[(b_dim1 << 1) + 2];
	        } else {
		    br1 = b[b_dim1 + 1];
		    br2 = b[b_dim1 + 2];
		    bi1 = b[(b_dim1 << 1) + 1];
		    bi2 = b[(b_dim1 << 1) + 2];
	        }
	        br2 = br2 - lr21 * br1 + li21 * bi1;
	        bi2 = bi2 - li21 * br1 - lr21 * bi1;
    /* Computing MAX */
	        d__1 = (abs(br1) + abs(bi1)) * (u22abs * (abs(ur11r) + abs(ui11r))); d__2 = abs(br2) + abs(bi2);
	        bbnd = max(d__1,d__2);
	        if (bbnd > 1.0 && u22abs < 1.0) {
		    if (bbnd >= bignum * u22abs) {
		        scale = 1.0 / bbnd;
		        br1 = scale * br1;
		        bi1 = scale * bi1;
		        br2 = scale * br2;
		        bi2 = scale * bi2;
		    }
	        }

	        dladiv(br2, bi2, ur22, ui22, ref xr2, ref xi2);
	        xr1 = ur11r * br1 - ui11r * bi1 - ur12s * xr2 + ui12s * xi2;
	        xi1 = ui11r * br1 + ur11r * bi1 - ui12s * xr2 - ur12s * xi2;
	        if (zswap[icmax - 1]) {
		    x[x_dim1 + 1] = xr2;
		    x[x_dim1 + 2] = xr1;
		    x[(x_dim1 << 1) + 1] = xi2;
		    x[(x_dim1 << 1) + 2] = xi1;
	        } else {
		    x[x_dim1 + 1] = xr1;
		    x[x_dim1 + 2] = xr2;
		    x[(x_dim1 << 1) + 1] = xi1;
		    x[(x_dim1 << 1) + 2] = xi2;
	        }
    /* Computing MAX */
	        d__1 = abs(xr1) + abs(xi1); d__2 = abs(xr2) + abs(xi2);
	        xnorm = max(d__1,d__2);

    /*           Further scaling if  norm(A) norm(X) > overflow */

	        if (xnorm > 1.0 && cmax > 1.0) {
		    if (xnorm > bignum / cmax) {
		        temp = cmax / bignum;
		        x[x_dim1 + 1] = temp * x[x_dim1 + 1];
		        x[x_dim1 + 2] = temp * x[x_dim1 + 2];
		        x[(x_dim1 << 1) + 1] = temp * x[(x_dim1 << 1) + 1];
		        x[(x_dim1 << 1) + 2] = temp * x[(x_dim1 << 1) + 2];
		        xnorm = temp * xnorm;
		        scale = temp * scale;
		    }
	        }
	    }
        }

        return 0;
    }
}

