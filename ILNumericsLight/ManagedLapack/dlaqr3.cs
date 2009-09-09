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
    public static unsafe int dlaqr3(bool wantt, bool wantz, int n, int ktop, int kbot, int nw,
        double *h__, int ldh, int iloz, int ihiz, double *z__, int ldz, ref int ns, ref int nd,
        double *sr, double *si, double* v, int ldv, int nh, double *t, int ldt, int nv, double *wv,
        int ldwv, double *work, int lwork)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c_n1 = -1;
        const bool c_true = true;
        const double c_b15 = 0.0;
        const double c_b16 = 1.0;
        const int c__12 = 12;

        /* System generated locals */
        int h_dim1, h_offset, t_dim1, t_offset, v_dim1, v_offset, wv_dim1, 
	        wv_offset, z_dim1, z_offset, i__1, i__2, i__3, i__4;
        double d__1, d__2, d__3, d__4, d__5, d__6;

        /* Local variables */
        int i__, j, k;
        double s, aa, bb, cc, dd, cs=0, sn=0;
        int jw;
        double evi, evk, foo;
        int kln;
        double tau=0, ulp;
        int lwk1, lwk2, lwk3;
        double beta;
        int kend, kcol, info=0, nmin, ifst, ilst, ltop, krow;
        bool bulge;
        int infqr=0, kwtop;
        double safmin;
        double safmax;
        bool sorted;
        double smlnum;
        int lwkopt;

        /* Parameter adjustments */
        h_dim1 = ldh;
        h_offset = 1 + h_dim1;
        h__ -= h_offset;
        z_dim1 = ldz;
        z_offset = 1 + z_dim1;
        z__ -= z_offset;
        --sr;
        --si;
        v_dim1 = ldv;
        v_offset = 1 + v_dim1;
        v -= v_offset;
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        wv_dim1 = ldwv;
        wv_offset = 1 + wv_dim1;
        wv -= wv_offset;
        --work;

        /* Function Body */
    /* Computing MIN */
        i__1 = nw; i__2 = kbot - ktop + 1;
        jw = min(i__1,i__2);
        if (jw <= 2) {
	    lwkopt = 1;
        } else {

    /*        ==== Workspace query call to DGEHRD ==== */

	    i__1 = jw - 1;
	    dgehrd(jw, c__1, i__1, &t[t_offset], ldt, &work[1], &work[1], 
		    c_n1, ref info);
	    lwk1 = (int) work[1];

    /*        ==== Workspace query call to DORGHR ==== */

	    i__1 = jw - 1;
	    dorghr(jw, c__1, i__1, &t[t_offset], ldt, &work[1], &work[1], 
		    c_n1, ref info);
	    lwk2 = (int) work[1];

    /*        ==== Workspace query call to DLAQR4 ==== */

	    dlaqr4(c_true, c_true, jw, c__1, jw, &t[t_offset], ldt, &sr[1], 
		    &si[1], c__1, jw, &v[v_offset], ldv, &work[1], c_n1, 
		    ref infqr);
	    lwk3 = (int) work[1];

    /*        ==== Optimal workspace ==== */

    /* Computing MAX */
	    i__1 = jw + max(lwk1,lwk2);
	    lwkopt = max(i__1,lwk3);
        }

    /*     ==== Quick return in case of workspace query. ==== */

        if (lwork == -1) {
	    work[1] = (double) lwkopt;
	    return 0;
        }

    /*     ==== Nothing to do ... */
    /*     ... for an empty active block ... ==== */
        ns = 0;
        nd = 0;
        if (ktop > kbot) {
	    return 0;
        }
    /*     ... nor for an empty deflation window. ==== */
        if (nw < 1) {
	    return 0;
        }

    /*     ==== Machine constants ==== */

        safmin = dlamch('S');
        safmax = 1.0 / safmin;
        dlabad(ref safmin, ref safmax);
        ulp = dlamch('P');
        smlnum = safmin * ((double) (n) / ulp);

    /*     ==== Setup deflation window ==== */

    /* Computing MIN */
        i__1 = nw; i__2 = kbot - ktop + 1;
        jw = min(i__1,i__2);
        kwtop = kbot - jw + 1;
        if (kwtop == ktop) {
	    s = 0.0;
        } else {
	    s = h__[kwtop + (kwtop - 1) * h_dim1];
        }

        if (kbot == kwtop) {

    /*        ==== 1-by-1 deflation window: not much to do ==== */

	    sr[kwtop] = h__[kwtop + kwtop * h_dim1];
	    si[kwtop] = 0.0;
	    ns = 1;
	    nd = 0;
    /* Computing MAX */
        d__1 = h__[kwtop + kwtop * h_dim1];
	    d__2 = smlnum; d__3 = ulp * ( abs(d__1));
	    if (abs(s) <= max(d__2,d__3)) {
	        ns = 0;
	        nd = 1;
	        if (kwtop > ktop) {
		    h__[kwtop + (kwtop - 1) * h_dim1] = 0.0;
	        }
	    }
	    return 0;
        }

    /*     ==== Convert to spike-triangular form.  (In case of a */
    /*     .    rare QR failure, this routine continues to do */
    /*     .    aggressive early deflation using that part of */
    /*     .    the deflation window that converged using INFQR */
    /*     .    here and there to keep track.) ==== */

        dlacpy('U', jw, jw, &h__[kwtop + kwtop * h_dim1], ldh, &t[t_offset], 
	        ldt);
        i__1 = jw - 1;
        i__2 = ldh + 1;
        i__3 = ldt + 1;
        dcopy(i__1, &h__[kwtop + 1 + kwtop * h_dim1], i__2, &t[t_dim1 + 2], 
	        i__3);

        dlaset('A', jw, jw, c_b15, c_b16, &v[v_offset], ldv);
        nmin = ilaenv(c__12, "DLAQR3", "SV", jw, c__1, jw, lwork);
        if (jw > nmin) {
	    dlaqr4(c_true, c_true, jw, c__1, jw, &t[t_offset], ldt, &sr[
		    kwtop], &si[kwtop], c__1, jw, &v[v_offset], ldv, &work[1], 
		    lwork, ref infqr);
        } else {
	    dlahqr(c_true, c_true, jw, c__1, jw, &t[t_offset], ldt, &sr[
		    kwtop], &si[kwtop], c__1, jw, &v[v_offset], ldv, ref infqr);
        }

    /*     ==== DTREXC needs a clean margin near the diagonal ==== */

        i__1 = jw - 3;
        for (j = 1; j <= i__1; ++j) {
	    t[j + 2 + j * t_dim1] = 0.0;
	    t[j + 3 + j * t_dim1] = 0.0;
    /* L10: */
        }
        if (jw > 2) {
	    t[jw + (jw - 2) * t_dim1] = 0.0;
        }

    /*     ==== Deflation detection loop ==== */

        ns = jw;
        ilst = infqr + 1;
    L20:
        if (ilst <= ns) {
	    if (ns == 1) {
	        bulge = false;
	    } else {
	        bulge = t[ns + (ns - 1) * t_dim1] != 0.0;
	    }

    /*        ==== Small spike tip test for deflation ==== */

	    if (! bulge) {

    /*           ==== Real eigenvalue ==== */

            d__1 = t[ns + ns * t_dim1];
	        foo = ( abs(d__1));
	        if (foo == 0.0) {
		    foo = abs(s);
	        }
    /* Computing MAX */
	        d__2 = smlnum; d__3 = ulp * foo;
	        if ((abs(s * v[ns * v_dim1 + 1])) <= max(d__2,d__3))
		         {

    /*              ==== Deflatable ==== */

		    --(ns);
	        } else {

    /*              ==== Undeflatable.   Move it up out of the way. */
    /*              .    (DTREXC can not fail in this case.) ==== */

		    ifst = ns;
		    dtrexc('V', jw, &t[t_offset], ldt, &v[v_offset], ldv, ref ifst, 
			     ref ilst, &work[1], ref info);
		    ++ilst;
	        }
	    } else {

    /*           ==== Complex conjugate pair ==== */

            d__3 = t[ns + ns * t_dim1];
            d__1 = t[ns + (ns - 1) * t_dim1];
            d__2 = t[ns - 1 + ns * t_dim1];
	        foo = ( abs(d__3)) + sqrt((abs(d__1))) * sqrt(( abs(d__2)));
	        if (foo == 0.0) {
		    foo = abs(s);
	        }
    /* Computing MAX */
            d__1 = s * v[ns * v_dim1 + 1];
	        d__3 = ( abs(d__1));
            d__2 = s * v[(ns - 1) * v_dim1 + 1];
            d__4 = (abs(d__2));
            /* Computing MAX */
            d__5 = smlnum; d__6 = ulp * foo;
	        if (max(d__3,d__4) <= max(d__5,d__6)) {

    /*              ==== Deflatable ==== */

		    ns += -2;
	        } else {

    /*              ==== Undflatable. Move them up out of the way. */
    /*              .    Fortunately, DTREXC does the right thing with */
    /*              .    ILST in case of a rare exchange failure. ==== */

		    ifst = ns;
		    dtrexc('V', jw, &t[t_offset], ldt, &v[v_offset], ldv, ref ifst, 
			     ref ilst, &work[1], ref info);
		    ilst += 2;
	        }
	    }

    /*        ==== End deflation detection loop ==== */

	    goto L20;
        }

    /*        ==== Return to Hessenberg form ==== */

        if (ns == 0) {
	    s = 0.0;
        }

        if (ns < jw) {

    /*        ==== sorting diagonal blocks of T improves accuracy for */
    /*        .    graded matrices.  Bubble sort deals well with */
    /*        .    exchange failures. ==== */

	    sorted = false;
	    i__ = ns + 1;
    L30:
	    if (sorted) {
	        goto L50;
	    }
	    sorted = true;

	    kend = i__ - 1;
	    i__ = infqr + 1;
	    if (i__ == ns) {
	        k = i__ + 1;
	    } else if (t[i__ + 1 + i__ * t_dim1] == 0.0) {
	        k = i__ + 1;
	    } else {
	        k = i__ + 2;
	    }
    L40:
	    if (k <= kend) {
	        if (k == i__ + 1) {
            d__1 = t[i__ + i__ * t_dim1];
		    evi = ( abs(d__1));
	        } else {
            d__3 = t[i__ + i__ * t_dim1];
            d__1 = t[i__ + 1 + i__ * t_dim1];
            d__2 = t[i__ + (i__ + 1) * t_dim1];
		    evi = ( abs(d__3)) + sqrt(( abs(d__1))) * sqrt(( abs(d__2)));
	        }

	        if (k == kend) {
            d__1 = t[k + k * t_dim1];
		    evk = ( abs(d__1));
	        } else if (t[k + 1 + k * t_dim1] == 0.0) {
            d__1 = t[k + k * t_dim1];
		    evk = ( abs(d__1));
	        } else {
            d__3 = t[k + k * t_dim1];
            d__1 = t[k + 1 + k * t_dim1];
            d__2 = t[k + (k + 1) * t_dim1];
		    evk = (abs(d__3)) + sqrt((abs(d__1))) * sqrt(( abs(d__2)));
	        }

	        if (evi >= evk) {
		    i__ = k;
	        } else {
		    sorted = false;
		    ifst = i__;
		    ilst = k;
		    dtrexc('V', jw, &t[t_offset], ldt, &v[v_offset], ldv, ref ifst, 
			     ref ilst, &work[1], ref info);
		    if (info == 0) {
		        i__ = ilst;
		    } else {
		        i__ = k;
		    }
	        }
	        if (i__ == kend) {
		    k = i__ + 1;
	        } else if (t[i__ + 1 + i__ * t_dim1] == 0.0) {
		    k = i__ + 1;
	        } else {
		    k = i__ + 2;
	        }
	        goto L40;
	    }
	    goto L30;
    L50:
	    ;
        }

    /*     ==== Restore shift/eigenvalue array from T ==== */

        i__ = jw;
    L60:
        if (i__ >= infqr + 1) {
	    if (i__ == infqr + 1) {
	        sr[kwtop + i__ - 1] = t[i__ + i__ * t_dim1];
	        si[kwtop + i__ - 1] = 0.0;
	        --i__;
	    } else if (t[i__ + (i__ - 1) * t_dim1] == 0.0) {
	        sr[kwtop + i__ - 1] = t[i__ + i__ * t_dim1];
	        si[kwtop + i__ - 1] = 0.0;
	        --i__;
	    } else {
	        aa = t[i__ - 1 + (i__ - 1) * t_dim1];
	        cc = t[i__ + (i__ - 1) * t_dim1];
	        bb = t[i__ - 1 + i__ * t_dim1];
	        dd = t[i__ + i__ * t_dim1];
	        dlanv2(ref aa, ref bb, ref cc, ref dd, ref sr[kwtop + i__ - 2],ref si[kwtop + i__ 
		        - 2], ref sr[kwtop + i__ - 1],ref si[kwtop + i__ - 1],ref cs,ref sn);
	        i__ += -2;
	    }
	    goto L60;
        }

        if (ns < jw || s == 0.0) {
	    if (ns > 1 && s != 0.0) {

    /*           ==== Reflect spike back into lower triangle ==== */

	        dcopy(ns, &v[v_offset], ldv, &work[1], c__1);
	        beta = work[1];
	        dlarfg(ns, ref beta, &work[2], c__1, ref tau);
	        work[1] = 1.0;

	        i__1 = jw - 2;
	        i__2 = jw - 2;
	        dlaset('L', i__1, i__2, c_b15, c_b15, &t[t_dim1 + 3], ldt);

	        dlarf('L', ns, jw, &work[1], c__1, tau, &t[t_offset], ldt, &
		        work[jw + 1]);
	        dlarf('R', ns, ns, &work[1], c__1, tau, &t[t_offset], ldt, &
		        work[jw + 1]);
	        dlarf('R', jw, ns, &work[1], c__1, tau, &v[v_offset], ldv, &
		        work[jw + 1]);

	        i__1 = lwork - jw;
	        dgehrd(jw, c__1, ns, &t[t_offset], ldt, &work[1], &work[jw + 1]
    , i__1, ref info);
	    }

    /*        ==== Copy updated reduced window into place ==== */

	    if (kwtop > 1) {
	        h__[kwtop + (kwtop - 1) * h_dim1] = s * v[v_dim1 + 1];
	    }
	    dlacpy('U', jw, jw, &t[t_offset], ldt, &h__[kwtop + kwtop * h_dim1]
    , ldh);
	    i__1 = jw - 1;
	    i__2 = ldt + 1;
	    i__3 = ldh + 1;
	    dcopy(i__1, &t[t_dim1 + 2], i__2, &h__[kwtop + 1 + kwtop * h_dim1], 
		     i__3);

    /*        ==== Accumulate orthogonal matrix in order update */
    /*        .    H and Z, if requested.  (A modified version */
    /*        .    of  DORGHR that accumulates block Householder */
    /*        .    transformations into V directly might be */
    /*        .    marginally more efficient than the following.) ==== */

	    if (ns > 1 && s != 0.0) {
	        i__1 = lwork - jw;
	        dorghr(jw, c__1, ns, &t[t_offset], ldt, &work[1], &work[jw + 1]
    , i__1, ref info);
	        dgemm('N', 'N', jw, ns, ns, c_b16, &v[v_offset], ldv, &t[
		        t_offset], ldt, c_b15, &wv[wv_offset], ldwv);
	        dlacpy('A', jw, ns, &wv[wv_offset], ldwv, &v[v_offset], ldv);
	    }

    /*        ==== Update vertical slab in H ==== */

	    if (wantt) {
	        ltop = 1;
	    } else {
	        ltop = ktop;
	    }
	    i__1 = kwtop - 1;
	    i__2 = nv;
	    for (krow = ltop; i__2 < 0 ? krow >= i__1 : krow <= i__1; krow += 
		    i__2) {
    /* Computing MIN */
	        i__3 = nv; i__4 = kwtop - krow;
	        kln = min(i__3,i__4);
	        dgemm('N', 'N', kln, jw, jw, c_b16, &h__[krow + kwtop * 
		        h_dim1], ldh, &v[v_offset], ldv, c_b15, &wv[wv_offset], 
		        ldwv);
	        dlacpy('A', kln, jw, &wv[wv_offset], ldwv, &h__[krow + kwtop * 
		        h_dim1], ldh);
    /* L70: */
	    }

    /*        ==== Update horizontal slab in H ==== */

	    if (wantt) {
	        i__2 = n;
	        i__1 = nh;
	        for (kcol = kbot + 1; i__1 < 0 ? kcol >= i__2 : kcol <= i__2; 
		        kcol += i__1) {
    /* Computing MIN */
		    i__3 = nh; i__4 = n - kcol + 1;
		    kln = min(i__3,i__4);
		    dgemm('C', 'N', jw, kln, jw, c_b16, &v[v_offset], ldv, &
			    h__[kwtop + kcol * h_dim1], ldh, c_b15, &t[t_offset], 
			     ldt);
		    dlacpy('A',jw, kln, &t[t_offset], ldt, &h__[kwtop + kcol *
			     h_dim1], ldh);
    /* L80: */
	        }
	    }

    /*        ==== Update vertical slab in Z ==== */

	    if (wantz) {
	        i__1 = ihiz;
	        i__2 = nv;
	        for (krow = iloz; i__2 < 0 ? krow >= i__1 : krow <= i__1; krow +=
		         i__2) {
    /* Computing MIN */
		    i__3 = nv; i__4 = ihiz - krow + 1;
		    kln = min(i__3,i__4);
		    dgemm('N', 'N', kln, jw, jw, c_b16, &z__[krow + kwtop * 
			    z_dim1], ldz, &v[v_offset], ldv, c_b15, &wv[
			    wv_offset], ldwv);
		    dlacpy('A', kln, jw, &wv[wv_offset], ldwv, &z__[krow + 
			    kwtop * z_dim1], ldz);
    /* L90: */
	        }
	    }
        }

    /*     ==== Return the number of deflations ... ==== */

        nd = jw - ns;

    /*     ==== ... and the number of shifts. (Subtracting */
    /*     .    INFQR from the spike length takes care */
    /*     .    of the case of a rare QR failure while */
    /*     .    calculating eigenvalues of the deflation */
    /*     .    window.)  ==== */

        ns -= infqr;

    /*      ==== Return optimal workspace. ==== */

        work[1] = (double) lwkopt;

    /*     ==== End of DLAQR3 ==== */

        return 0;
    }
}

