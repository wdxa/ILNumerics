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
    public static unsafe int dlasv2(double f, double g, double h__, ref double ssmin,
        ref double ssmax, ref double snr, ref double csr, ref double snl, ref double csl)
    {
        /* Table of constant values */
        const double c_b3 = 2;
        const double c_b4 = 1;

        /* System generated locals */
        double d__1;

        /* Local variables */
        double a, d__, l, m, r__, s, t, fa, ga, ha, ft, gt, ht, mm, tt, clt=0, crt=0, slt=0, srt=0;
        int pmax;
        double temp;
        bool swap;
        double tsign=0;
        bool gasmal;

        ft = f;
        fa = abs(ft);
        ht = h__;
        ha = abs(h__);

    /*     PMAX points to the maximum absolute element of matrix */
    /*       PMAX = 1 if F largest in absolute values */
    /*       PMAX = 2 if G largest in absolute values */
    /*       PMAX = 3 if H largest in absolute values */

        pmax = 1;
        swap = ha > fa;
        if (swap) {
	    pmax = 3;
	    temp = ft;
	    ft = ht;
	    ht = temp;
	    temp = fa;
	    fa = ha;
	    ha = temp;

    /*        Now FA .ge. HA */

        }
        gt = g;
        ga = abs(gt);
        if (ga == 0.0) {

    /*        Diagonal matrix */

	    ssmin = ha;
	    ssmax = fa;
	    clt = 1.0;
	    crt = 1.0;
	    slt = 0.0;
	    srt = 0.0;
        } else {
	    gasmal = true;
	    if (ga > fa) {
	        pmax = 2;
	        if (fa / ga < dlamch('E')) {

    /*              Case of very large GA */

		    gasmal = false;
		    ssmax = ga;
		    if (ha > 1.0) {
		        ssmin = fa / (ga / ha);
		    } else {
		        ssmin = fa / ga * ha;
		    }
		    clt = 1.0;
		    slt = ht / gt;
		    srt = 1.0;
		    crt = ft / gt;
	        }
	    }
	    if (gasmal) {

    /*           Normal case */

	        d__ = fa - ha;
	        if (d__ == fa) {

    /*              Copes with infinite F or H */

		    l = 1.0;
	        } else {
		    l = d__ / fa;
	        }

    /*           Note that 0 .le. L .le. 1 */

	        m = gt / ft;

    /*           Note that abs(M) .le. 1/macheps */

	        t = 2.0 - l;

    /*           Note that T .ge. 1 */

	        mm = m * m;
	        tt = t * t;
	        s = sqrt(tt + mm);

    /*           Note that 1 .le. S .le. 1 + 1/macheps */

	        if (l == 0.0) {
		    r__ = abs(m);
	        } else {
		    r__ = sqrt(l * l + mm);
	        }

    /*           Note that 0 .le. R .le. 1 + 1/macheps */

	        a = (s + r__) * .5;

    /*           Note that 1 .le. A .le. 1 + abs(M) */

	        ssmin = ha / a;
	        ssmax = fa * a;
	        if (mm == 0.0) {

    /*              Note that M is very tiny */

		    if (l == 0.0) {
		        t = d_sign(c_b3, ft) * d_sign(c_b4, gt);
		    } else {
		        t = gt / d_sign(d__, ft) + m / t;
		    }
	        } else {
		    t = (m / (s + t) + m / (r__ + l)) * (a + 1.0);
	        }
	        l = sqrt(t * t + 4.0);
	        crt = 2.0 / l;
	        srt = t / l;
	        clt = (crt + srt * m) / a;
	        slt = ht / ft * srt / a;
	    }
        }
        if (swap) {
	    csl = srt;
	    snl = crt;
	    csr = slt;
	    snr = clt;
        } else {
	    csl = clt;
	    snl = slt;
	    csr = crt;
	    snr = srt;
        }

    /*     Correct signs of SSMAX and SSMIN */

        if (pmax == 1) {
	    tsign = d_sign(c_b4, csr) * d_sign(c_b4, csl) * d_sign(c_b4, f);
        }
        if (pmax == 2) {
	    tsign = d_sign(c_b4, snr) * d_sign(c_b4, csl) * d_sign(c_b4, g);
        }
        if (pmax == 3) {
	    tsign = d_sign(c_b4, snr) * d_sign(c_b4, snl) * d_sign(c_b4, h__);
        }
        ssmax = d_sign(ssmax, tsign);
        d__1 = tsign * d_sign(c_b4, f) * d_sign(c_b4, h__);
        ssmin = d_sign(ssmin, d__1);
        return 0;
    } 
}

