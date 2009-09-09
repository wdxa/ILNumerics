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
    public static int dlamc1(ref int beta, ref int t, ref bool rnd, ref bool ieee1)
    {
        /* Initialized data */
        bool first = true;

        /* System generated locals */
        double d__1, d__2;

        /* Local variables */
        double a, b, c__, f, t1, t2;
        int lt = 0;
        double one, qtr;
        bool lrnd = false;
        int lbeta = 0;
        double savec;
        bool lieee1 = false;

        if (first) {
	    one = 1;

    /*        LBETA,  LIEEE1,  LT and  LRND  are the  local values  of  BETA, */
    /*        IEEE1, T and RND. */

    /*        Throughout this routine  we use the function  DLAMC3  to ensure */
    /*        that relevant values are  stored and not held in registers,  or */
    /*        are not affected by optimizers. */

    /*        Compute  a = 2.0**m  with the  smallest positive int m such */
    /*        that */

    /*           fl( a + 10 ) = a. */

	    a = 1;
	    c__ = 1;

    /* +       WHILE( C.EQ.ONE )LOOP */
    L10:
	    if (c__ == one) {
	        a *= 2;
	        c__ = dlamc3(a, one);
	        d__1 = -a;
	        c__ = dlamc3(c__, d__1);
	        goto L10;
	    }
    /* +       END WHILE */

    /*        Now compute  b = 2.0**m  with the smallest positive int m */
    /*        such that */

    /*           fl( a + b ) .gt. a. */

	    b = 1;
	    c__ = dlamc3(a, b);

    /* +       WHILE( C.EQ.A )LOOP */
    L20:
	    if (c__ == a) {
	        b *= 2;
	        c__ = dlamc3(a, b);
	        goto L20;
	    }
    /* +       END WHILE */

    /*        Now compute the base.  a and c  are neighbouring floating point */
    /*        numbers  in the  interval  ( beta*t, beta**( t + 1 ) )  and so */
    /*        their difference is beta. Adding 0.25 to c is to ensure that it */
    /*        is truncated to beta and not ( beta - 1 ). */

	    qtr = one / 4;
	    savec = c__;
	    d__1 = -a;
	    c__ = dlamc3(c__, d__1);
	    lbeta = (int) (c__ + qtr);

    /*        Now determine whether rounding or chopping occurs,  by adding a */
    /*        bit  less  than  beta/2  and a  bit  more  than  beta/2  to  a. */

	    b = (double) lbeta;
	    d__1 = b / 2;
	    d__2 = -b / 100;
	    f = dlamc3(d__1, d__2);
	    c__ = dlamc3(f, a);
	    if (c__ == a) {
	        lrnd = true;
	    } else {
	        lrnd = false;
	    }
	    d__1 = b / 2;
	    d__2 = b / 100;
	    f = dlamc3(d__1, d__2);
	    c__ = dlamc3(f, a);
	    if (lrnd && c__ == a) {
	        lrnd = false;
	    }

    /*        Try and decide whether rounding is done in the  IEEE  'round to */
    /*        nearest' style. B/2 is half a unit in the last place of the two */
    /*        numbers A and SAVEC. Furthermore, A is even, i.e. has last  bit */
    /*        zero, and SAVEC is odd. Thus adding B/2 to A should not  change */
    /*        A, but adding B/2 to SAVEC should change SAVEC. */

	    d__1 = b / 2;
	    t1 = dlamc3(d__1, a);
	    d__1 = b / 2;
	    t2 = dlamc3(d__1, savec);
	    lieee1 = t1 == a && t2 > savec && lrnd;

    /*        Now find  the  mantissa, t.  It should  be the  int part of */
    /*        log to the base beta of a,  however it is safer to determine  t */
    /*        by powering.  So we find t as the smallest positive int for */
    /*        which */

    /*           fl( beta*t + 10 ) = 10. */

	    lt = 0;
	    a = 1;
	    c__ = 1;

    /* +       WHILE( C.EQ.ONE )LOOP */
    L30:
	    if (c__ == one) {
	        ++lt;
	        a *= lbeta;
	        c__ = dlamc3(a, one);
	        d__1 = -a;
	        c__ = dlamc3(c__, d__1);
	        goto L30;
	    }
    /* +       END WHILE */

        }

        beta = lbeta;
        t = lt;
        rnd = lrnd;
        ieee1 = lieee1;
        first = false;
        return 0;
    } 
}

