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
    public static unsafe int dlaic1(int job, int j, double *x, double sest, double *w,
        double gamma, ref double sestpr, ref double s, ref double c__)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b5 = 1.0;

        /* System generated locals */
        double d__1, d__2, d__3, d__4;

        /* Local variables */
        double b, t, s1, s2, eps, tmp;
        double sine, test, zeta1, zeta2, alpha, norma;
        double absgam, absalp, cosine, absest;

        /* Parameter adjustments */
        --w;
        --x;

        /* Function Body */
        eps = dlamch('E');
        alpha = ddot(j, &x[1], c__1, &w[1], c__1);

        absalp = abs(alpha);
        absgam = abs(gamma);
        absest = abs(sest);

        if (job == 1) {

    /*        Estimating largest singular value */

    /*        special cases */

	    if (sest == 0.0) {
	        s1 = max(absgam,absalp);
	        if (s1 == 0.0) {
		    s = 0.0;
		    c__ = 1.0;
		    sestpr = 0.0;
	        } else {
		    s = alpha / s1;
		    c__ = gamma / s1;
		    tmp = sqrt(s * s + c__ * c__);
		    s /= tmp;
		    c__ /= tmp;
		    sestpr = s1 * tmp;
	        }
	        return 0;
	    } else if (absgam <= eps * absest) {
	        s = 1.0;
	        c__ = 0.0;
	        tmp = max(absest,absalp);
	        s1 = absest / tmp;
	        s2 = absalp / tmp;
	        sestpr = tmp * sqrt(s1 * s1 + s2 * s2);
	        return 0;
	    } else if (absalp <= eps * absest) {
	        s1 = absgam;
	        s2 = absest;
	        if (s1 <= s2) {
		    s = 1.0;
		    c__ = 0.0;
		    sestpr = s2;
	        } else {
		    s = 0.0;
		    c__ = 1.0;
		    sestpr = s1;
	        }
	        return 0;
	    } else if (absest <= eps * absalp || absest <= eps * absgam) {
	        s1 = absgam;
	        s2 = absalp;
	        if (s1 <= s2) {
		    tmp = s1 / s2;
		    s = sqrt(tmp * tmp + 1.0);
		    sestpr = s2 * s;
		    c__ = gamma / s2 / s;
		    s = d_sign(c_b5, alpha) / s;
	        } else {
		    tmp = s2 / s1;
		    c__ = sqrt(tmp * tmp + 1.0);
		    sestpr = s1 * c__;
		    s = alpha / s1 / c__;
		    c__ = d_sign(c_b5, gamma) / c__;
	        }
	        return 0;
	    } else {

    /*           normal case */

	        zeta1 = alpha / absest;
	        zeta2 = gamma / absest;

	        b = (1.0 - zeta1 * zeta1 - zeta2 * zeta2) * .5;
	        c__ = zeta1 * zeta1;
	        if (b > 0.0) {
		    t = c__ / (b + sqrt(b * b + c__));
	        } else {
		    t = sqrt(b * b + c__) - b;
	        }

	        sine = -zeta1 / t;
	        cosine = -zeta2 / (t + 1.0);
	        tmp = sqrt(sine * sine + cosine * cosine);
	        s = sine / tmp;
	        c__ = cosine / tmp;
	        sestpr = sqrt(t + 1.0) * absest;
	        return 0;
	    }

        } else if (job == 2) {

    /*        Estimating smallest singular value */

    /*        special cases */

	    if (sest == 0.0) {
	        sestpr = 0.0;
	        if (max(absgam,absalp) == 0.0) {
		    sine = 1.0;
		    cosine = 0.0;
	        } else {
		    sine = -(gamma);
		    cosine = alpha;
	        }
    /* Computing MAX */
	        d__1 = abs(sine); d__2 = abs(cosine);
	        s1 = max(d__1,d__2);
	        s = sine / s1;
	        c__ = cosine / s1;
	        tmp = sqrt(s * s + c__ * c__);
	        s /= tmp;
	        c__ /= tmp;
	        return 0;
	    } else if (absgam <= eps * absest) {
	        s = 0.0;
	        c__ = 1.0;
	        sestpr = absgam;
	        return 0;
	    } else if (absalp <= eps * absest) {
	        s1 = absgam;
	        s2 = absest;
	        if (s1 <= s2) {
		    s = 0.0;
		    c__ = 1.0;
		    sestpr = s1;
	        } else {
		    s = 1.0;
		    c__ = 0.0;
		    sestpr = s2;
	        }
	        return 0;
	    } else if (absest <= eps * absalp || absest <= eps * absgam) {
	        s1 = absgam;
	        s2 = absalp;
	        if (s1 <= s2) {
		    tmp = s1 / s2;
		    c__ = sqrt(tmp * tmp + 1.0);
		    sestpr = absest * (tmp / c__);
		    s = -(gamma / s2) / c__;
		    c__ = d_sign(c_b5, alpha) / c__;
	        } else {
		    tmp = s2 / s1;
		    s = sqrt(tmp * tmp + 1.0);
		    sestpr = absest / s;
		    c__ = alpha / s1 / s;
		    s = -d_sign(c_b5, gamma) / s;
	        }
	        return 0;
	    } else {

    /*           normal case */

	        zeta1 = alpha / absest;
	        zeta2 = gamma / absest;

    /* Computing MAX */
            d__1 = zeta1 * zeta2;
	        d__3 = zeta1 * zeta1 + 1.0 + ( abs(d__1));
            d__2 = zeta1 * zeta2;
            d__4 = ( abs(d__2)) + zeta2 * zeta2;
	        norma = max(d__3,d__4);

    /*           See if root is closer to zero or to ONE */

	        test = (zeta1 - zeta2) * 2.0 * (zeta1 + zeta2) + 1.0;
	        if (test >= 0.0) {

    /*              root is close to zero, compute directly */

		    b = (zeta1 * zeta1 + zeta2 * zeta2 + 1.0) * .5;
		    c__ = zeta2 * zeta2;
            d__1 = b * b - c__;
		    t = c__ / (b + sqrt(( abs(d__1))));
		    sine = zeta1 / (1.0 - t);
		    cosine = -zeta2 / t;
		    sestpr = sqrt(t + eps * 4.0 * eps * norma) * absest;
	        } else {

    /*              root is closer to ONE, shift by that amount */

		    b = (zeta2 * zeta2 + zeta1 * zeta1 - 1.0) * .5;
		    c__ = zeta1 * zeta1;
		    if (b >= 0.0) {
		        t = -(c__) / (b + sqrt(b * b + c__));
		    } else {
		        t = b - sqrt(b * b + c__);
		    }
		    sine = -zeta1 / t;
		    cosine = -zeta2 / (t + 1.0);
		    sestpr = sqrt(t + 1.0 + eps * 4.0 * eps * norma) * absest;
	        }
	        tmp = sqrt(sine * sine + cosine * cosine);
	        s = sine / tmp;
	        c__ = cosine / tmp;
	        return 0;

	    }
        }
        return 0;
    } 
}

