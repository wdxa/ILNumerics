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
    public static unsafe int dlasd5(int i__, double* d__, double* z__, double* delta, double rho, double dsigma, double* work)
    {
        /* Local variables */
        double b, c__, w, del, tau, delsq;

        /* Parameter adjustments */
        --work;
        --delta;
        --z__;
        --d__;

        /* Function Body */
        del = d__[2] - d__[1];
        delsq = del * (d__[2] + d__[1]);
        if (i__ == 1) {
	    w = rho * 4.0 * (z__[2] * z__[2] / (d__[1] + d__[2] * 3.0) - z__[1] * 
		    z__[1] / (d__[1] * 3.0 + d__[2])) / del + 1.0;
	    if (w > 0.0) {
	        b = delsq + rho * (z__[1] * z__[1] + z__[2] * z__[2]);
	        c__ = rho * z__[1] * z__[1] * delsq;

    /*           B > ZERO, always */

    /*           The following TAU is DSIGMA * DSIGMA - D( 1 ) * D( 1 ) */

	        tau = c__ * 2.0 / (b + sqrt(abs(b * b - c__ * 4.0)));

    /*           The following TAU is DSIGMA - D( 1 ) */

	        tau /= d__[1] + sqrt(d__[1] * d__[1] + tau);
	        dsigma = d__[1] + tau;
	        delta[1] = -tau;
	        delta[2] = del - tau;
	        work[1] = d__[1] * 2.0 + tau;
	        work[2] = d__[1] + tau + d__[2];
    /*           DELTA( 1 ) = -Z( 1 ) / TAU */
    /*           DELTA( 2 ) = Z( 2 ) / ( DEL-TAU ) */
	    } else {
	        b = -delsq + rho * (z__[1] * z__[1] + z__[2] * z__[2]);
	        c__ = rho * z__[2] * z__[2] * delsq;

    /*           The following TAU is DSIGMA * DSIGMA - D( 2 ) * D( 2 ) */

	        if (b > 0.0) {
		    tau = c__ * -2.0 / (b + sqrt(b * b + c__ * 4.0));
	        } else {
		    tau = (b - sqrt(b * b + c__ * 4.0)) / 2.0;
	        }

    /*           The following TAU is DSIGMA - D( 2 ) */

	        tau /= d__[2] + sqrt(abs(d__[2] * d__[2] + tau));
	        dsigma = d__[2] + tau;
	        delta[1] = -(del + tau);
	        delta[2] = -tau;
	        work[1] = d__[1] + tau + d__[2];
	        work[2] = d__[2] * 2.0 + tau;
    /*           DELTA( 1 ) = -Z( 1 ) / ( DEL+TAU ) */
    /*           DELTA( 2 ) = -Z( 2 ) / TAU */
	    }
    /*        TEMP = SQRT( DELTA( 1 )*DELTA( 1 )+DELTA( 2 )*DELTA( 2 ) ) */
    /*        DELTA( 1 ) = DELTA( 1 ) / TEMP */
    /*        DELTA( 2 ) = DELTA( 2 ) / TEMP */
        } else {

    /*        Now I=2 */

	    b = -delsq + rho * (z__[1] * z__[1] + z__[2] * z__[2]);
	    c__ = rho * z__[2] * z__[2] * delsq;

    /*        The following TAU is DSIGMA * DSIGMA - D( 2 ) * D( 2 ) */

	    if (b > 0.0) {
	        tau = (b + sqrt(b * b + c__ * 4.0)) / 2.0;
	    } else {
	        tau = c__ * 2.0 / (-b + sqrt(b * b + c__ * 4.0));
	    }

    /*        The following TAU is DSIGMA - D( 2 ) */

	    tau /= d__[2] + sqrt(d__[2] * d__[2] + tau);
	    dsigma = d__[2] + tau;
	    delta[1] = -(del + tau);
	    delta[2] = -tau;
	    work[1] = d__[1] + tau + d__[2];
	    work[2] = d__[2] * 2.0 + tau;
    /*        DELTA( 1 ) = -Z( 1 ) / ( DEL+TAU ) */
    /*        DELTA( 2 ) = -Z( 2 ) / TAU */
    /*        TEMP = SQRT( DELTA( 1 )*DELTA( 1 )+DELTA( 2 )*DELTA( 2 ) ) */
    /*        DELTA( 1 ) = DELTA( 1 ) / TEMP */
    /*        DELTA( 2 ) = DELTA( 2 ) / TEMP */
        }
        return 0;
    } 
}

