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
    public static unsafe int dlasd8(int icompq, int k, double* d__, double* z__, double* vf, double* vl,
        double* difl, double* difr, int lddifr, double* dsigma, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__0 = 0;
        const double c_b8 = 1.00;

        /* System generated locals */
        int difr_dim1, difr_offset, i__1, i__2;
        double d__1, d__2;

        /* Local variables */
        int i__, j;
        double dj, rho;
        int iwk1, iwk2, iwk3;
        double temp;
        int iwk2i, iwk3i;
        double diflj, difrj=0, dsigj;
        double dsigjp=0;

        /* Parameter adjustments */
        --d__;
        --z__;
        --vf;
        --vl;
        --difl;
        difr_dim1 = lddifr;
        difr_offset = 1 + difr_dim1;
        difr -= difr_offset;
        --dsigma;
        --work;

        /* Function Body */
        info = 0;

        if (icompq < 0 || icompq > 1) {
	    info = -1;
        } else if (k < 1) {
	    info = -2;
        } else if (lddifr < k) {
	    info = -9;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASD8", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (k == 1) {
	    d__[1] = abs(z__[1]);
	    difl[1] = d__[1];
	    if (icompq == 1) {
	        difl[2] = 1.0;
	        difr[(difr_dim1 << 1) + 1] = 1.0;
	    }
	    return 0;
        }

    /*     Modify values DSIGMA(i) to make sure all DSIGMA(i)-DSIGMA(j) can */
    /*     be computed with high relative accuracy (barring over/underflow). */
    /*     This is a problem on machines without a guard digit in */
    /*     add/subtract (Cray XMP, Cray YMP, Cray C 90 and Cray 2). */
    /*     The following code replaces DSIGMA(I) by 2*DSIGMA(I)-DSIGMA(I), */
    /*     which on any of these machines zeros out the bottommost */
    /*     bit of DSIGMA(I) if it is 1; this makes the subsequent */
    /*     subtractions DSIGMA(I)-DSIGMA(J) unproblematic when cancellation */
    /*     occurs. On binary machines with a guard digit (almost all */
    /*     machines) it does not change DSIGMA(I) at all. On hexadecimal */
    /*     and decimal machines with a guard digit, it slightly */
    /*     changes the bottommost bits of DSIGMA(I). It does not account */
    /*     for hexadecimal or decimal machines without guard digits */
    /*     (we know of none). We use a subroutine call to compute */
    /*     2*DSIGMA(I) to prevent optimizing compilers from eliminating */
    /*     this code. */

        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    dsigma[i__] = dlamc3(dsigma[i__], dsigma[i__]) - dsigma[i__];
    /* L10: */
        }

    /*     Book keeping. */

        iwk1 = 1;
        iwk2 = iwk1 + k;
        iwk3 = iwk2 + k;
        iwk2i = iwk2 - 1;
        iwk3i = iwk3 - 1;

    /*     Normalize Z. */

        rho = dnrm2(k, &z__[1], c__1);
        dlascl('G', c__0, c__0, rho, c_b8, k, c__1, &z__[1], k, ref info);
        rho *= rho;

    /*     Initialize WORK(IWK3). */

        dlaset('A', k, c__1, c_b8, c_b8, &work[iwk3], k);

    /*     Compute the updated singular values, the arrays DIFL, DIFR, */
    /*     and the updated Z. */

        i__1 = k;
        for (j = 1; j <= i__1; ++j) {
	    dlasd4(k, j, &dsigma[1], &z__[1], &work[iwk1], rho, ref d__[j], &work[
		    iwk2], ref info);

    /*        If the root finder fails, the computation is terminated. */

	    if (info != 0) {
	        return 0;
	    }
	    work[iwk3i + j] = work[iwk3i + j] * work[j] * work[iwk2i + j];
	    difl[j] = -work[j];
	    difr[j + difr_dim1] = -work[j + 1];
	    i__2 = j - 1;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        work[iwk3i + i__] = work[iwk3i + i__] * work[i__] * work[iwk2i + 
		        i__] / (dsigma[i__] - dsigma[j]) / (dsigma[i__] + dsigma[
		        j]);
    /* L20: */
	    }
	    i__2 = k;
	    for (i__ = j + 1; i__ <= i__2; ++i__) {
	        work[iwk3i + i__] = work[iwk3i + i__] * work[i__] * work[iwk2i + 
		        i__] / (dsigma[i__] - dsigma[j]) / (dsigma[i__] + dsigma[
		        j]);
    /* L30: */
	    }
    /* L40: */
        }

    /*     Compute updated Z. */

        i__1 = k;
        for (i__ = 1; i__ <= i__1; ++i__) {
        d__1 = work[iwk3i + i__];
	    d__2 = sqrt(( abs(d__1)));
	    z__[i__] = d_sign(d__2, z__[i__]);
    /* L50: */
        }

    /*     Update VF and VL. */

        i__1 = k;
        for (j = 1; j <= i__1; ++j) {
	    diflj = difl[j];
	    dj = d__[j];
	    dsigj = -dsigma[j];
	    if (j < k) {
	        difrj = -difr[j + difr_dim1];
	        dsigjp = -dsigma[j + 1];
	    }
	    work[j] = -z__[j] / diflj / (dsigma[j] + dj);
	    i__2 = j - 1;
	    for (i__ = 1; i__ <= i__2; ++i__) {
	        work[i__] = z__[i__] / (dlamc3(dsigma[i__], dsigj) - diflj) / (
		        dsigma[i__] + dj);
    /* L60: */
	    }
	    i__2 = k;
	    for (i__ = j + 1; i__ <= i__2; ++i__) {
	        work[i__] = z__[i__] / (dlamc3(dsigma[i__], dsigjp) + difrj) / 
		        (dsigma[i__] + dj);
    /* L70: */
	    }
	    temp = dnrm2(k, &work[1], c__1);
	    work[iwk2i + j] = ddot(k, &work[1], c__1, &vf[1], c__1) / temp;
	    work[iwk3i + j] = ddot(k, &work[1], c__1, &vl[1], c__1) / temp;
	    if (icompq == 1) {
	        difr[j + (difr_dim1 << 1)] = temp;
	    }
    /* L80: */
        }

        dcopy(k, &work[iwk2], c__1, &vf[1], c__1);
        dcopy(k, &work[iwk3], c__1, &vl[1], c__1);

        return 0;
    } 
}

