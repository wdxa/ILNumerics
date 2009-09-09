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

using System;

public partial class ManagedLapack
{
    public static int dlamc2(ref int beta, ref int t, ref bool rnd, ref double eps, ref int emin, ref double rmin, ref int emax, ref double rmax)
    {
        /* Initialized data */

        bool first = true;
        bool iwarn = false;

        /* System generated locals */
        int i__1;
        double d__1, d__2, d__3, d__4, d__5;

        /* Local variables */
        double a, b, c__;
        int i__;
        int lt = 0;
        double one, two;
        bool ieee;
        double half;
        bool lrnd = false;
        double leps = 0;
        double zero;
        int lbeta = 0;
        double rbase;
        int lemin = 0, lemax = 0;
        int gnmin = 0;
        double small;
        int gpmin = 0;
        double third;
        double lrmin = 0, lrmax = 0;
        double sixth;
        int ngnmin = 0, ngpmin = 0;
        bool lieee1 = false;

        if (first) {
	    zero = 0;
	    one = 1;
	    two = 2;

    /*        LBETA, LT, LRND, LEPS, LEMIN and LRMIN  are the local values of */
    /*        BETA, T, RND, EPS, EMIN and RMIN. */

    /*        Throughout this routine  we use the function  DLAMC3  to ensure */
    /*        that relevant values are stored  and not held in registers,  or */
    /*        are not affected by optimizers. */

    /*        DLAMC1 returns the parameters  LBETA, LT, LRND and LIEEE1. */

	    dlamc1(ref lbeta, ref lt, ref lrnd, ref lieee1);

    /*        Start to find EPS. */

	    b = (double) lbeta;
	    i__1 = -lt;
	    a = pow_di(b, i__1);
	    leps = a;

    /*        Try some tricks to see whether or not this is the correct  EPS. */

	    b = two / 3;
	    half = one / 2;
	    d__1 = -half;
	    sixth = dlamc3(b, d__1);
	    third = dlamc3(sixth, sixth);
	    d__1 = -half;
	    b = dlamc3(third, d__1);
	    b = dlamc3(b, sixth);
	    b = abs(b);
	    if (b < leps) {
	        b = leps;
	    }

	    leps = 1;

    /* +       WHILE( ( LEPS.GT.B ).AND.( B.GT.ZERO ) )LOOP */
    L10:
	    if (leps > b && b > zero) {
	        leps = b;
	        d__1 = half * leps;
    /* Computing 5th power */
	        d__3 = two; d__4 = d__3; d__3 *= d__3;
    /* Computing 2nd power */
	        d__5 = leps;
	        d__2 = d__4 * (d__3 * d__3) * (d__5 * d__5);
	        c__ = dlamc3(d__1, d__2);
	        d__1 = -c__;
	        c__ = dlamc3(half, d__1);
	        b = dlamc3(half, c__);
	        d__1 = -b;
	        c__ = dlamc3(half, d__1);
	        b = dlamc3(half, c__);
	        goto L10;
	    }
    /* +       END WHILE */

	    if (a < leps) {
	        leps = a;
	    }

    /*        Computation of EPS complete. */

    /*        Now find  EMIN.  Let A = + or - 1, and + or - (1 + BASE**(-3)). */
    /*        Keep dividing  A by BETA until (gradual) underflow occurs. This */
    /*        is detected when we cannot recover the previous A. */

	    rbase = one / lbeta;
	    small = one;
	    for (i__ = 1; i__ <= 3; ++i__) {
	        d__1 = small * rbase;
	        small = dlamc3(d__1, zero);
    /* L20: */
	    }
	    a = dlamc3(one, small);
	    dlamc4(ref ngpmin, one, lbeta);
	    d__1 = -one;
	    dlamc4(ref ngnmin, d__1, lbeta);
	    dlamc4(ref gpmin, a, lbeta);
	    d__1 = -a;
	    dlamc4(ref gnmin, d__1, lbeta);
	    ieee = false;

	    if (ngpmin == ngnmin && gpmin == gnmin) {
	        if (ngpmin == gpmin) {
		    lemin = ngpmin;
    /*            ( Non twos-complement machines, no gradual underflow; */
    /*              e.g.,  VAX ) */
	        } else if (gpmin - ngpmin == 3) {
		    lemin = ngpmin - 1 + lt;
		    ieee = true;
    /*            ( Non twos-complement machines, with gradual underflow; */
    /*              e.g., IEEE standard followers ) */
	        } else {
		    lemin = min(ngpmin,gpmin);
    /*            ( A guess; no known machine ) */
		    iwarn = true;
	        }

	    } else if (ngpmin == gpmin && ngnmin == gnmin) {
	        if (abs(ngpmin - ngnmin) == 1) {
		    lemin = max(ngpmin,ngnmin);
    /*            ( Twos-complement machines, no gradual underflow; */
    /*              e.g., CYBER 205 ) */
	        } else {
		    lemin = min(ngpmin,ngnmin);
    /*            ( A guess; no known machine ) */
		    iwarn = true;
	        }

	    } else if (abs(ngpmin - ngnmin) == 1 && gpmin == gnmin)
		     {
	        if (gpmin - min(ngpmin,ngnmin) == 3) {
		    lemin = max(ngpmin,ngnmin) - 1 + lt;
    /*            ( Twos-complement machines with gradual underflow; */
    /*              no known machine ) */
	        } else {
		    lemin = min(ngpmin,ngnmin);
    /*            ( A guess; no known machine ) */
		    iwarn = true;
	        }

	    } else {
    /* Computing MIN */
	        i__1 = min(min(ngpmin,ngnmin),gpmin);
	        lemin = min(i__1,gnmin);
    /*         ( A guess; no known machine ) */
	        iwarn = true;
	    }
	    first = false;
    /* ** */
    /* Comment out this if block if EMIN is ok */
	    if (iwarn) {
	        first = true;
	        Console.Write("\n\n WARNING. The value EMIN may be incorrect:- ");
	        Console.Write("EMIN = " + lemin.ToString() + "\n");
	        Console.Write("If, after inspection, the value EMIN looks acceptable");
                Console.Write("please comment out \n the IF block as marked within the"); 
                Console.Write("code of routine DLAMC2, \n otherwise supply EMIN"); 
                Console.Write("explicitly.\n");
             /*
	        s_wsfe(&io___58);
	        do_fio(&c__1, (char *)&lemin, (ftnlen)sizeof(int));
	        e_wsfe();
             */
	    }
    /* ** */

    /*        Assume IEEE arithmetic if we found denormalised  numbers above, */
    /*        or if arithmetic seems to round in the  IEEE style,  determined */
    /*        in routine DLAMC1. A true IEEE machine should have both  things */
    /*        true; however, faulty machines may have one or the other. */

	    ieee = ieee || lieee1;

    /*        Compute  RMIN by successive division by  BETA. We could compute */
    /*        RMIN as BASE**( EMIN - 1 ),  but some machines underflow during */
    /*        this computation. */

	    lrmin = 1;
	    i__1 = 1 - lemin;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        d__1 = lrmin * rbase;
	        lrmin = dlamc3(d__1, zero);
    /* L30: */
	    }

    /*        Finally, call DLAMC5 to compute EMAX and RMAX. */

	    dlamc5(lbeta, lt, lemin, ieee, ref lemax, ref lrmax);
        }

        beta = lbeta;
        t = lt;
        rnd = lrnd;
        eps = leps;
        emin = lemin;
        rmin = lrmin;
        emax = lemax;
        rmax = lrmax;

        return 0;
    } 
}

