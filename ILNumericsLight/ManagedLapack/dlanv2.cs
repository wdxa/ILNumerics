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
    public static unsafe int dlanv2(ref double a, ref double b, ref double c__, ref double d__, ref
        double rt1r, ref double rt1i, ref double rt2r, ref double rt2i, ref double cs, ref double sn)
    {
        /* Table of constant values */
        const double c_b4 = 1.0;

        /* System generated locals */
        double d__1, d__2;

        /* Local variables */
        double p, z__, aa, bb, cc, dd, cs1, sn1, sab, sac, eps, tau, temp, 
	        scale, bcmax, bcmis, sigma;

        eps = dlamch('P');
        if (c__ == 0.0) {
	    cs = 1.0;
	    sn = 0.0;
	    goto L10;

        } else if (b == 0.0) {

    /*        Swap rows and columns */

	    cs = 0.0;
	    sn = 1.0;
	    temp = d__;
	    d__ = a;
	    a = temp;
	    b = -(c__);
	    c__ = 0.0;
	    goto L10;
        } else if (a - d__ == 0.0 && d_sign(c_b4, b) != d_sign(c_b4, c__)) {
	    cs = 1.0;
	    sn = 0.0;
	    goto L10;
        } else {

	    temp = a - d__;
	    p = temp * .5;
    /* Computing MAX */
	    d__1 = abs(b);
        d__2 = abs(c__);
	    bcmax = max(d__1,d__2);
    /* Computing MIN */
	    d__1 = abs(b);
        d__2 = abs(c__);
	    bcmis = min(d__1,d__2) * d_sign(c_b4, b) * d_sign(c_b4, c__);
    /* Computing MAX */
	    d__1 = abs(p);
	    scale = max(d__1,bcmax);
	    z__ = p / scale * p + bcmax / scale * bcmis;

    /*        If Z is of the order of the machine accuracy, postpone the */
    /*        decision on the nature of eigenvalues */

	    if (z__ >= eps * 4.0) {

    /*           Real eigenvalues. Compute A and D. */

	        d__1 = sqrt(scale) * sqrt(z__);
	        z__ = p + d_sign(d__1, p);
	        a = d__ + z__;
	        d__ -= bcmax / z__ * bcmis;

    /*           Compute B and the rotation matrix */

	        tau = dlapy2(c__, z__);
	        cs = z__ / tau;
	        sn = c__ / tau;
	        b -= c__;
	        c__ = 0.0;
	    } else {

    /*           Complex eigenvalues, or real (almost) equal eigenvalues. */
    /*           Make diagonal elements equal. */

	        sigma = b + c__;
	        tau = dlapy2(sigma, temp);
	        cs = sqrt((abs(sigma) / tau + 1.0) * .5);
	        sn = -(p / (tau * cs)) * d_sign(c_b4, sigma);

    /*           Compute [ AA  BB ] = [ A  B ] [ CS -SN ] */
    /*                   [ CC  DD ]   [ C  D ] [ SN  CS ] */

	        aa = a * cs + b * sn;
	        bb = -(a) * sn + b * cs;
	        cc = c__ * cs + d__ * sn;
	        dd = -(c__) * sn + d__ * cs;

    /*           Compute [ A  B ] = [ CS  SN ] [ AA  BB ] */
    /*                   [ C  D ]   [-SN  CS ] [ CC  DD ] */

	        a = aa * cs + cc * sn;
	        b = bb * cs + dd * sn;
	        c__ = -aa * sn + cc * cs;
	        d__ = -bb * sn + dd * cs;

	        temp = (a + d__) * .5;
	        a = temp;
	        d__ = temp;

	        if (c__ != 0.0) {
		    if (b != 0.0) {
		        if (d_sign(c_b4, b) == d_sign(c_b4, c__)) {

    /*                    Real eigenvalues: reduce to upper triangular form */

			    sab = sqrt((abs(b)));
			    sac = sqrt((abs(c__)));
			    d__1 = sab * sac;
			    p = d_sign(d__1, c__);
			    tau = 1.0 / sqrt(abs(b + c__));
			    a = temp + p;
			    d__ = temp - p;
			    b -= c__;
			    c__ = 0.0;
			    cs1 = sab * tau;
			    sn1 = sac * tau;
			    temp = cs * cs1 - sn * sn1;
			    sn = cs * sn1 + sn * cs1;
			    cs = temp;
		        }
		    } else {
		        b = -(c__);
		        c__ = 0.0;
		        temp = cs;
		        cs = -(sn);
		        sn = temp;
		    }
	        }
	    }

        }

    L10:

    /*     Store eigenvalues in (RT1R,RT1I) and (RT2R,RT2I). */

        rt1r = a;
        rt2r = d__;
        if (c__ == 0.0) {
	    rt1i = 0.0;
	    rt2i = 0.0;
        } else {
	    rt1i = sqrt((abs(b))) * sqrt((abs(c__)));
	    rt2i = -(rt1i);
        }
        return 0;
    }
}

