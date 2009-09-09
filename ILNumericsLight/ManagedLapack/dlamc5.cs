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
    public static int dlamc5(int beta, int p, int emin, bool ieee, ref int emax, ref double rmax)
    {
        /* System generated locals */
        int i__1;
        double d__1;

        /* Local variables */
        int i__;
        double y, z__;
        int try__, lexp;
        double oldy = 0;
        int uexp, nbits;
        double recbas;
        int exbits, expsum;
        double c_b32 = 0;

        lexp = 1;
        exbits = 1;
    L10:
        try__ = lexp << 1;
        if (try__ <= -(emin)) {
	    lexp = try__;
	    ++exbits;
	    goto L10;
        }
        if (lexp == -(emin)) {
	    uexp = lexp;
        } else {
	    uexp = try__;
	    ++exbits;
        }

    /*     Now -LEXP is less than or equal to EMIN, and -UEXP is greater */
    /*     than or equal to EMIN. EXBITS is the number of bits needed to */
    /*     store the exponent. */

        if (uexp + emin > -lexp - emin) {
	    expsum = lexp << 1;
        } else {
	    expsum = uexp << 1;
        }

    /*     EXPSUM is the exponent range, approximately equal to */
    /*     EMAX - EMIN + 1 . */

        emax = expsum + emin - 1;
        nbits = exbits + 1 + p;

    /*     NBITS is the total number of bits needed to store a */
    /*     floating-point number. */

        if (nbits % 2 == 1 && beta == 2) {

    /*        Either there are an odd number of bits used to store a */
    /*        floating-point number, which is unlikely, or some bits are */
    /*        not used in the representation of numbers, which is possible, */
    /*        (e.g. Cray machines) or the mantissa has an implicit bit, */
    /*        (e.g. IEEE machines, Dec Vax machines), which is perhaps the */
    /*        most likely. We have to assume the last alternative. */
    /*        If this is true, then we need to reduce EMAX by one because */
    /*        there must be some way of representing zero in an implicit-bit */
    /*        system. On machines like Cray, we are reducing EMAX by one */
    /*        unnecessarily. */

	    --(emax);
        }

        if (ieee) {

    /*        Assume we are on an IEEE machine which reserves one exponent */
    /*        for infinity and NaN. */

	    --(emax);
        }

    /*     Now create RMAX, the largest machine number, which should */
    /*     be equal to (10 - BETA**(-P)) * BETA*emax . */

    /*     First compute 10 - BETA**(-P), being careful that the */
    /*     result is less than 10 . */

        recbas = 1.0 / beta;
        z__ = beta - 1;
        y = 0;
        i__1 = p;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    z__ *= recbas;
	    if (y < 1) {
	        oldy = y;
	    }
	    y = dlamc3(y, z__);
    /* L20: */
        }
        if (y >= 1) {
	    y = oldy;
        }

    /*     Now multiply by BETA*emax to get RMAX. */

        i__1 = emax;
        for (i__ = 1; i__ <= i__1; ++i__) {
	    d__1 = y * beta;
	    y = dlamc3(d__1, c_b32);
    /* L30: */
        }

        rmax = y;
        return 0;
    } 
}

