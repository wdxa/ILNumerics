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
    public static unsafe int dlaqr4(bool wantt, bool wantz, int n, int ilo, int ihi,
        double *h__, int ldh, double *wr, double *wi, int iloz, int ihiz, double *z__,
        int ldz, double *work, int lwork, ref int info)
    {
        /* Table of constant values */
        const int c__13 = 13;
        const int c__15 = 15;
        const int c_n1 = -1;
        const int c__12 = 12;
        const int c__14 = 14;
        const int c__16 = 16;
        const bool c_false = false;
        const int c__1 = 1;
        const int c__3 = 3;

        /* System generated locals */
        int h_dim1, h_offset, z_dim1, z_offset, i__1, i__2, i__3, i__4, i__5;

        /* Local variables */
        int i__, k;
        double aa, bb, cc, dd;
        int ld=0;
        double cs=0;
        int nh, it, ks, kt;
        double sn=0;
        int ku, kv, ls=0, ns;
        double ss;
        int nw, inf=0, kdu, nho, nve, kwh, nsr, nwr, kwv, ndfl, kbot, nmin;
        double swap;
        int ktop;
        double* zdum = stackalloc double [1];
        int kacc22;
        bool nwinc=false;
        int itmax, nsmax, nwmax, kwtop;
        int nibble;
        string jbcmpz;
        bool sorted;
        int lwkopt;

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
        info = 0;

    /*     ==== Quick return for N = 0: nothing to do. ==== */

        if (n == 0) {
	    work[1] = 1.0;
	    return 0;
        }

    /*     ==== Set up job flags for ILAENV. ==== */

        if (wantt && wantz) jbcmpz = "SV";
        else if (wantt)     jbcmpz = "SN";
        else if (wantz)     jbcmpz = "EV";
        else                jbcmpz = "EN";

    /*     ==== Tiny matrices must use DLAHQR. ==== */

        if (n <= 11) {

    /*        ==== Estimate optimal workspace. ==== */

	    lwkopt = 1;
	    if (lwork != -1) {
	        dlahqr(wantt, wantz, n, ilo, ihi, &h__[h_offset], ldh, &wr[1], &
		        wi[1], iloz, ihiz, &z__[z_offset], ldz, ref info);
	    }
        } else {

    /*        ==== Use small bulge multi-shift QR with aggressive early */
    /*        .    deflation on larger-than-tiny matrices. ==== */

    /*        ==== Hope for the best. ==== */

	    info = 0;

    /*        ==== NWR = recommended deflation window size.  At this */
    /*        .    point,  N .GT. NTINY = 11, so there is enough */
    /*        .    subdiagonal workspace for NWR.GE.2 as required. */
    /*        .    (In fact, there is enough subdiagonal space for */
    /*        .    NWR.GE.3.) ==== */

	    nwr = ilaenv(c__13, "DLAQR4", jbcmpz, n, ilo, ihi, lwork);
	    nwr = max(2,nwr);
    /* Computing MIN */
	    i__1 = ihi - ilo + 1; i__2 = (n - 1) / 3; i__1 = min(i__1,i__2);
	    nwr = min(i__1,nwr);
	    nw = nwr;

    /*        ==== NSR = recommended number of simultaneous shifts. */
    /*        .    At this point N .GT. NTINY = 11, so there is at */
    /*        .    enough subdiagonal workspace for NSR to be even */
    /*        .    and greater than or equal to two as required. ==== */

	    nsr = ilaenv(c__15, "DLAQR4", jbcmpz, n, ilo, ihi, lwork);
    /* Computing MIN */
        i__1 = nsr; i__2 = (n + 6) / 9; i__1 = min(i__1, i__2); i__2 = ihi - ilo;
	    nsr = min(i__1,i__2);
    /* Computing MAX */
	    i__1 = 2; i__2 = nsr - nsr % 2;
	    nsr = max(i__1,i__2);

    /*        ==== Estimate optimal workspace ==== */

    /*        ==== Workspace query call to DLAQR2 ==== */

	    i__1 = nwr + 1;
	    dlaqr2(wantt, wantz, n, ilo, ihi, i__1, &h__[h_offset], ldh, iloz, 
		    ihiz, &z__[z_offset], ldz, ref ls, ref ld, &wr[1], &wi[1], &h__[
		    h_offset], ldh, n, &h__[h_offset], ldh, n, &h__[h_offset], 
		    ldh, &work[1], c_n1);

    /*        ==== Optimal workspace = MAX(DLAQR5, DLAQR2) ==== */

    /* Computing MAX */
	    i__1 = nsr * 3 / 2; i__2 = (int) work[1];
	    lwkopt = max(i__1,i__2);

    /*        ==== Quick return in case of workspace query. ==== */

	    if (lwork == -1) {
	        work[1] = (double) lwkopt;
	        return 0;
	    }

    /*        ==== DLAHQR/DLAQR0 crossover point ==== */

	    nmin = ilaenv(c__12, "DLAQR4", jbcmpz, n, ilo, ihi, lwork);
	    nmin = max(11,nmin);

    /*        ==== Nibble crossover point ==== */

	    nibble = ilaenv(c__14, "DLAQR4", jbcmpz, n, ilo, ihi, lwork);
	    nibble = max(0,nibble);

    /*        ==== Accumulate reflections during ttswp?  Use block */
    /*        .    2-by-2 structure during matrix-matrix multiply? ==== */

	    kacc22 = ilaenv(c__16, "DLAQR4", jbcmpz, n, ilo, ihi, lwork);
	    kacc22 = max(0,kacc22);
	    kacc22 = min(2,kacc22);

    /*        ==== NWMAX = the largest possible deflation window for */
    /*        .    which there is sufficient workspace. ==== */

    /* Computing MIN */
	    i__1 = (n - 1) / 3; i__2 = lwork / 2;
	    nwmax = min(i__1,i__2);

    /*        ==== NSMAX = the Largest number of simultaneous shifts */
    /*        .    for which there is sufficient workspace. ==== */

    /* Computing MIN */
	    i__1 = (n + 6) / 9; i__2 = (lwork << 1) / 3;
	    nsmax = min(i__1,i__2);
	    nsmax -= nsmax % 2;

    /*        ==== NDFL: an iteration count restarted at deflation. ==== */

	    ndfl = 1;

    /*        ==== ITMAX = iteration limit ==== */

    /* Computing MAX */
	    i__1 = 10; i__2 = ihi - ilo + 1;
	    itmax = max(i__1,i__2) * 30;

    /*        ==== Last row and column in the active block ==== */

	    kbot = ihi;

    /*        ==== Main Loop ==== */

	    i__1 = itmax;
	    for (it = 1; it <= i__1; ++it) {

    /*           ==== Done when KBOT falls below ILO ==== */

	        if (kbot < ilo) {
		    goto L90;
	        }

    /*           ==== Locate active block ==== */

	        i__2 = ilo + 1;
	        for (k = kbot; k >= i__2; --k) {
		    if (h__[k + (k - 1) * h_dim1] == 0.0) {
		        goto L20;
		    }
    /* L10: */
	        }
	        k = ilo;
    L20:
	        ktop = k;

    /*           ==== Select deflation window size ==== */

	        nh = kbot - ktop + 1;
	        if (ndfl < 5 || nh < nw) {

    /*              ==== Typical deflation window.  If possible and */
    /*              .    advisable, nibble the entire active block. */
    /*              .    If not, use size NWR or NWR+1 depending upon */
    /*              .    which has the smaller corresponding subdiagonal */
    /*              .    entry (a heuristic). ==== */

		    nwinc = true;
		    if (nh <= min(nmin,nwmax)) {
		        nw = nh;
		    } else {
    /* Computing MIN */
		        i__2 = min(nwr,nh);
		        nw = min(i__2,nwmax);
		        if (nw < nwmax) {
			    if (nw >= nh - 1) {
			        nw = nh;
			    } else {
			        kwtop = kbot - nw + 1;
			        if ((abs(h__[kwtop + (kwtop - 1) * h_dim1])) > (abs(h__[kwtop - 1 + (kwtop - 2) * h_dim1]))) {
				    ++nw;
			        }
			    }
		        }
		    }
	        } else {

    /*              ==== Exceptional deflation window.  If there have */
    /*              .    been no deflations in KEXNW or more iterations, */
    /*              .    then vary the deflation window size.   At first, */
    /*              .    because, larger windows are, in general, more */
    /*              .    powerful than smaller ones, rapidly increase the */
    /*              .    window up to the maximum reasonable and possible. */
    /*              .    Then maybe try a slightly smaller window.  ==== */

		    if (nwinc && nw < min(nwmax,nh)) {
    /* Computing MIN */
		        i__2 = min(nwmax,nh); i__3 = nw << 1;
		        nw = min(i__2,i__3);
		    } else {
		        nwinc = false;
		        if (nw == nh && nh > 2) {
			    nw = nh - 1;
		        }
		    }
	        }

    /*           ==== Aggressive early deflation: */
    /*           .    split workspace under the subdiagonal into */
    /*           .      - an nw-by-nw work array V in the lower */
    /*           .        left-hand-corner, */
    /*           .      - an NW-by-at-least-NW-but-more-is-better */
    /*           .        (NW-by-NHO) horizontal work array along */
    /*           .        the bottom edge, */
    /*           .      - an at-least-NW-but-more-is-better (NHV-by-NW) */
    /*           .        vertical work array along the left-hand-edge. */
    /*           .        ==== */

	        kv = n - nw + 1;
	        kt = nw + 1;
	        nho = n - nw - 1 - kt + 1;
	        kwv = nw + 2;
	        nve = n - nw - kwv + 1;

    /*           ==== Aggressive early deflation ==== */

	        dlaqr2(wantt, wantz, n, ktop, kbot, nw, &h__[h_offset], ldh, 
		        iloz, ihiz, &z__[z_offset], ldz, ref ls, ref ld, &wr[1], &wi[1], 
		         &h__[kv + h_dim1], ldh, nho, &h__[kv + kt * h_dim1], 
		        ldh, nve, &h__[kwv + h_dim1], ldh, &work[1], lwork);

    /*           ==== Adjust KBOT accounting for new deflations. ==== */

	        kbot -= ld;

    /*           ==== KS points to the shifts. ==== */

	        ks = kbot - ls + 1;

    /*           ==== Skip an expensive QR sweep if there is a (partly */
    /*           .    heuristic) reason to expect that many eigenvalues */
    /*           .    will deflate without it.  Here, the QR sweep is */
    /*           .    skipped if many eigenvalues have just been deflated */
    /*           .    or if the remaining active block is small. */

	        if (ld == 0 || ld * 100 <= nw * nibble && kbot - ktop + 1 > min(
		        nmin,nwmax)) {

    /*              ==== NS = nominal number of simultaneous shifts. */
    /*              .    This may be lowered (slightly) if DLAQR2 */
    /*              .    did not provide that many shifts. ==== */

    /* Computing MIN */
    /* Computing MAX */
		    i__4 = 2; i__5 = kbot - ktop;
		    i__2 = min(nsmax,nsr); i__3 = max(i__4,i__5);
		    ns = min(i__2,i__3);
		    ns -= ns % 2;

    /*              ==== If there have been no deflations */
    /*              .    in a multiple of KEXSH iterations, */
    /*              .    then try exceptional shifts. */
    /*              .    Otherwise use shifts provided by */
    /*              .    DLAQR2 above or from the eigenvalues */
    /*              .    of a trailing principal submatrix. ==== */

		    if (ndfl % 6 == 0) {
		        ks = kbot - ns + 1;
    /* Computing MAX */
		        i__3 = ks + 1; i__4 = ktop + 2;
		        i__2 = max(i__3,i__4);
		        for (i__ = kbot; i__ >= i__2; i__ += -2) {
			    ss = (abs(h__[i__ + (i__ - 1) * h_dim1]))  + (abs(h__[i__ - 1 + (i__ - 2) * h_dim1]));
			    aa = ss * .75 + h__[i__ + i__ * h_dim1];
			    bb = ss;
			    cc = ss * -.4375;
			    dd = aa;
			    dlanv2(ref aa, ref bb, ref cc, ref dd, ref wr[i__ - 1], ref wi[i__ - 1]
    , ref wr[i__], ref wi[i__], ref cs, ref sn);
    /* L30: */
		        }
		        if (ks == ktop) {
			    wr[ks + 1] = h__[ks + 1 + (ks + 1) * h_dim1];
			    wi[ks + 1] = 0.0;
			    wr[ks] = wr[ks + 1];
			    wi[ks] = wi[ks + 1];
		        }
		    } else {

    /*                 ==== Got NS/2 or fewer shifts? Use DLAHQR */
    /*                 .    on a trailing principal submatrix to */
    /*                 .    get more. (Since NS.LE.NSMAX.LE.(N+6)/9, */
    /*                 .    there is enough space below the subdiagonal */
    /*                 .    to fit an NS-by-NS scratch array.) ==== */

		        if (kbot - ks + 1 <= ns / 2) {
			    ks = kbot - ns + 1;
			    kt = n - ns + 1;
			    dlacpy('A', ns, ns, &h__[ks + ks * h_dim1], ldh, &
				    h__[kt + h_dim1], ldh);
			    dlahqr(c_false, c_false, ns, c__1, ns, &h__[kt 
				    + h_dim1], ldh, &wr[ks], &wi[ks], c__1, 
				    c__1, zdum, c__1, ref inf);
			    ks += inf;

    /*                    ==== In case of a rare QR failure use */
    /*                    .    eigenvalues of the trailing 2-by-2 */
    /*                    .    principal submatrix.  ==== */

			    if (ks >= kbot) {
			        aa = h__[kbot - 1 + (kbot - 1) * h_dim1];
			        cc = h__[kbot + (kbot - 1) * h_dim1];
			        bb = h__[kbot - 1 + kbot * h_dim1];
			        dd = h__[kbot + kbot * h_dim1];
			        dlanv2(ref aa, ref bb, ref cc, ref dd, ref wr[kbot - 1], ref wi[
				        kbot - 1], ref wr[kbot], ref wi[kbot], ref cs, ref sn)
				        ;
			        ks = kbot - 1;
			    }
		        }

		        if (kbot - ks + 1 > ns) {

    /*                    ==== Sort the shifts (Helps a little) */
    /*                    .    Bubble sort keeps complex conjugate */
    /*                    .    pairs together. ==== */

			    sorted = false;
			    i__2 = ks + 1;
			    for (k = kbot; k >= i__2; --k) {
			        if (sorted) {
				    goto L60;
			        }
			        sorted = true;
			        i__3 = k - 1;
			        for (i__ = ks; i__ <= i__3; ++i__) {
				    if ((abs(wr[i__])) + (abs(wi[i__])) < (abs(wr[i__ + 1])) + (abs(wi[i__ + 1]))) {
				        sorted = false;

				        swap = wr[i__];
				        wr[i__] = wr[i__ + 1];
				        wr[i__ + 1] = swap;

				        swap = wi[i__];
				        wi[i__] = wi[i__ + 1];
				        wi[i__ + 1] = swap;
				    }
    /* L40: */
			        }
    /* L50: */
			    }
    L60:
			    ;
		        }

    /*                 ==== Shuffle shifts into pairs of real shifts */
    /*                 .    and pairs of complex conjugate shifts */
    /*                 .    assuming complex conjugate shifts are */
    /*                 .    already adjacent to one another. (Yes, */
    /*                 .    they are.)  ==== */

		        i__2 = ks + 2;
		        for (i__ = kbot; i__ >= i__2; i__ += -2) {
			    if (wi[i__] != -wi[i__ - 1]) {

			        swap = wr[i__];
			        wr[i__] = wr[i__ - 1];
			        wr[i__ - 1] = wr[i__ - 2];
			        wr[i__ - 2] = swap;

			        swap = wi[i__];
			        wi[i__] = wi[i__ - 1];
			        wi[i__ - 1] = wi[i__ - 2];
			        wi[i__ - 2] = swap;
			    }
    /* L70: */
		        }
		    }

    /*              ==== If there are only two shifts and both are */
    /*              .    real, then use only one.  ==== */

		    if (kbot - ks + 1 == 2) {
		        if (wi[kbot] == 0.0) {
			    if ((abs(wr[kbot] - h__[kbot + kbot * h_dim1])) < (abs(wr[kbot - 1] - h__[kbot + kbot * h_dim1]))) {
			        wr[kbot - 1] = wr[kbot];
			    } else {
			        wr[kbot] = wr[kbot - 1];
			    }
		        }
		    }

    /*              ==== Use up to NS of the the smallest magnatiude */
    /*              .    shifts.  If there aren't NS shifts available, */
    /*              .    then use them all, possibly dropping one to */
    /*              .    make the number of shifts even. ==== */

    /* Computing MIN */
		    i__2 = ns; i__3 = kbot - ks + 1;
		    ns = min(i__2,i__3);
		    ns -= ns % 2;
		    ks = kbot - ns + 1;

    /*              ==== Small-bulge multi-shift QR sweep: */
    /*              .    split workspace under the subdiagonal into */
    /*              .    - a KDU-by-KDU work array U in the lower */
    /*              .      left-hand-corner, */
    /*              .    - a KDU-by-at-least-KDU-but-more-is-better */
    /*              .      (KDU-by-NHo) horizontal work array WH along */
    /*              .      the bottom edge, */
    /*              .    - and an at-least-KDU-but-more-is-better-by-KDU */
    /*              .      (NVE-by-KDU) vertical work WV arrow along */
    /*              .      the left-hand-edge. ==== */

		    kdu = ns * 3 - 3;
		    ku = n - kdu + 1;
		    kwh = kdu + 1;
		    nho = n - kdu - 3 - (kdu + 1) + 1;
		    kwv = kdu + 4;
		    nve = n - kdu - kwv + 1;

    /*              ==== Small-bulge multi-shift QR sweep ==== */

		    dlaqr5(wantt, wantz, kacc22, n, ktop, kbot, ns, &wr[ks], 
			    &wi[ks], &h__[h_offset], ldh, iloz, ihiz, &z__[
			    z_offset], ldz, &work[1], c__3, &h__[ku + h_dim1], 
			    ldh, nve, &h__[kwv + h_dim1], ldh, nho, &h__[ku + 
			    kwh * h_dim1], ldh);
	        }

    /*           ==== Note progress (or the lack of it). ==== */

	        if (ld > 0) {
		    ndfl = 1;
	        } else {
		    ++ndfl;
	        }

    /*           ==== End of main loop ==== */
    /* L80: */
	    }

    /*        ==== Iteration limit exceeded.  Set INFO to show where */
    /*        .    the problem occurred and exit. ==== */

	    info = kbot;
    L90:
	    ;
        }

    /*     ==== Return the optimal value of LWORK. ==== */

        work[1] = (double) lwkopt;

    /*     ==== End of DLAQR4 ==== */

        return 0;
    }
}

