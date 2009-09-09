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
    public static unsafe int dhseqr(char job, char compz, int n, int ilo, int ihi, double *h__, int ldh,
        double *wr, double *wi, double *z__, int ldz, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const double c_b11 = 0.0;
        const double c_b12 = 1.0;
        const int c__12 = 12;
        const int c__49 = 49;

        /* System generated locals */
        int h_dim1, h_offset, z_dim1, z_offset, i__1, i__3;
        double d__1;

        /* Local variables */
        int i__;
        double* hl = stackalloc double[2401];
        int kbot, nmin;
        bool initz;
        double* workl = stackalloc double[49];
        bool wantt, wantz;
        bool lquery;

        /* Parameter adjustments */
        h_dim1 = ldh;
        h_offset = 1 + h_dim1;
        h__ -= h_offset;
        --wr;
        --wi;
        z_dim1 = ldz;
        z_offset = 1 + z_dim1;
        z__ -= z_offset;
        --work;

        /* Function Body */
        wantt = lsame(job, 'S');
        initz = lsame(compz, 'I');
        wantz = initz || lsame(compz, 'V');
        work[1] = (double) max(1,n);
        lquery = lwork == -1;

        info = 0;
        if (! lsame(job, 'E') && ! wantt) {
	    info = -1;
        } else if (! lsame(compz, 'N') && ! wantz) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (ilo < 1 || ilo > max(1,n)) {
	    info = -4;
        } else if (ihi < min(ilo,n) || ihi > n) {
	    info = -5;
        } else if (ldh < max(1,n)) {
	    info = -7;
        } else if (ldz < 1 || wantz && ldz < max(1,n)) {
	    info = -11;
        } else if (lwork < max(1,n) && ! lquery) {
	    info = -13;
        }

        if (info != 0) {

    /*        ==== Quick return in case of invalid argument. ==== */

	    i__1 = -(info);
	    xerbla("DHSEQR", i__1);
	    return 0;

        } else if (n == 0) {

    /*        ==== Quick return in case N = 0; nothing to do. ==== */

	    return 0;

        } else if (lquery) {

    /*        ==== Quick return in case of a workspace query ==== */

	    dlaqr0(wantt, wantz, n, ilo, ihi, &h__[h_offset], ldh, &wr[1], &wi[
		    1], ilo, ihi, &z__[z_offset], ldz, &work[1], lwork, ref info);
    /*        ==== Ensure reported workspace size is backward-compatible with */
    /*        .    previous LAPACK versions. ==== */
    /* Computing MAX */
	    d__1 = (double) max(1,n);
	    work[1] = max(d__1,work[1]);
	    return 0;

        } else {

    /*        ==== copy eigenvalues isolated by DGEBAL ==== */

	    i__1 = ilo - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        wr[i__] = h__[i__ + i__ * h_dim1];
	        wi[i__] = 0.0;
    /* L10: */
	    }
	    i__1 = n;
	    for (i__ = ihi + 1; i__ <= i__1; ++i__) {
	        wr[i__] = h__[i__ + i__ * h_dim1];
	        wi[i__] = 0.0;
    /* L20: */
	    }

    /*        ==== Initialize Z, if requested ==== */

	    if (initz) {
	        dlaset('A', n, n, c_b11, c_b12, &z__[z_offset], ldz)
		        ;
	    }

    /*        ==== Quick return if possible ==== */

	    if (ilo == ihi) {
	        wr[ilo] = h__[ilo + ilo * h_dim1];
	        wi[ilo] = 0.0;
	        return 0;
	    }

    /*        ==== DLAHQR/DLAQR0 crossover point ==== */

    /* Writing concatenation */
	    nmin = ilaenv(c__12, "DHSEQR", job.ToString() + compz.ToString(), n, ilo, ihi, lwork);
	    nmin = max(11,nmin);

    /*        ==== DLAQR0 for big matrices; DLAHQR for small ones ==== */

	    if (n > nmin) {
	        dlaqr0(wantt, wantz, n, ilo, ihi, &h__[h_offset], ldh, &wr[1], 
		        &wi[1], ilo, ihi, &z__[z_offset], ldz, &work[1], lwork, 
		        ref info);
	    } else {

    /*           ==== Small matrix ==== */

	        dlahqr(wantt, wantz, n, ilo, ihi, &h__[h_offset], ldh, &wr[1], 
		        &wi[1], ilo, ihi, &z__[z_offset], ldz, ref info);

	        if (info > 0) {

    /*              ==== A rare DLAHQR failure!  DLAQR0 sometimes succeeds */
    /*              .    when DLAHQR fails. ==== */

		    kbot = info;

		    if (n >= 49) {

    /*                 ==== Larger matrices have enough subdiagonal scratch */
    /*                 .    space to call DLAQR0 directly. ==== */

		        dlaqr0(wantt, wantz, n, ilo, kbot, &h__[h_offset], 
			        ldh, &wr[1], &wi[1], ilo, ihi, &z__[z_offset], 
			        ldz, &work[1], lwork, ref info);

		    } else {

    /*                 ==== Tiny matrices don't have enough subdiagonal */
    /*                 .    scratch space to benefit from DLAQR0.  Hence, */
    /*                 .    tiny matrices must be copied into a larger */
    /*                 .    array before calling DLAQR0. ==== */

		        dlacpy('A', n, n, &h__[h_offset], ldh, hl, c__49);
		        hl[n + 1 + n * 49 - 50] = 0.0;
		        i__1 = 49 - n;
		        dlaset('A', c__49, i__1, c_b11, c_b11, &hl[(n + 1) *
			         49 - 49], c__49);
		        dlaqr0(wantt, wantz, c__49, ilo, kbot, hl, c__49, &
			        wr[1], &wi[1], ilo, ihi, &z__[z_offset], ldz, 
			        workl, c__49, ref info);
		        if (wantt || info != 0) {
			    dlacpy('A', n, n, hl, c__49, &h__[h_offset], ldh);
		        }
		    }
	        }
	    }

    /*        ==== Clear out the trash, if necessary. ==== */

	    if ((wantt || info != 0) && n > 2) {
	        i__1 = n - 2;
	        i__3 = n - 2;
	        dlaset('L', i__1, i__3, c_b11, c_b11, &h__[h_dim1 + 3], ldh);
	    }

    /*        ==== Ensure reported workspace size is backward-compatible with */
    /*        .    previous LAPACK versions. ==== */

    /* Computing MAX */
	    d__1 = (double) max(1,n);
	    work[1] = max(d__1,work[1]);
        }

    /*     ==== End of DHSEQR ==== */

        return 0;
    }
}

