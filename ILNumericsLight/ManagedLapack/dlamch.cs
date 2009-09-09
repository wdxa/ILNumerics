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
    public static unsafe double dlamch(char cmach)
    {
        /* Initialized data */
        bool first = true;

        /* System generated locals */
        int i__1;
        double ret_val;

        /* Local variables */
        double t = 0;
        int it = 0;
        double rnd = 0, eps = 0, _base = 0;
        int beta = 0;
        double emin = 0, prec = 0, emax = 0;
        int imin = 0, imax = 0;
        bool lrnd = false;
        double rmin = 0, rmax = 0;
        double rmach = 0;
        double small;
        double sfmin = 0;

        if (first) {
	    dlamc2(ref beta, ref it, ref lrnd, ref eps, ref imin, ref rmin, ref imax, ref rmax);
	    _base = (double) beta;
	    t = (double) it;
	    if (lrnd) {
	        rnd = 1;
	        i__1 = 1 - it;
	        eps = pow_di(_base, i__1) / 2;
	    } else {
	        rnd = 0;
	        i__1 = 1 - it;
	        eps = pow_di(_base, i__1);
	    }
	    prec = eps * _base;
	    emin = (double) imin;
	    emax = (double) imax;
	    sfmin = rmin;
	    small = 1 / rmax;
	    if (small >= sfmin) {

    /*           Use SMALL plus a bit, to avoid the possibility of rounding */
    /*           causing overflow when computing  1/sfmin. */

	        sfmin = small * (eps + 1);
	    }
        }

        if (lsame(cmach, 'E')) {
	    rmach = eps;
        } else if (lsame(cmach, 'S')) {
	    rmach = sfmin;
        } else if (lsame(cmach, 'B')) {
	    rmach = _base;
        } else if (lsame(cmach, 'P')) {
	    rmach = prec;
        } else if (lsame(cmach, 'N')) {
	    rmach = t;
        } else if (lsame(cmach, 'R')) {
	    rmach = rnd;
        } else if (lsame(cmach, 'M')) {
	    rmach = emin;
        } else if (lsame(cmach, 'U')) {
	    rmach = rmin;
        } else if (lsame(cmach, 'L')) {
	    rmach = emax;
        } else if (lsame(cmach, 'O')) {
	    rmach = rmax;
        }

        ret_val = rmach;
        first = false;
        return ret_val;
    } 
}

