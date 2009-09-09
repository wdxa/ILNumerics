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
    public static int dlamc4(ref int emin, double start, int _base)
    {
        /* System generated locals */
        int i__1;
        double d__1;

        /* Local variables */
        double a;
        int i__;
        double b1, b2, c1, c2, d1, d2, one, zero, rbase;

        a = start;
        one = 1;
        rbase = one / _base;
        zero = 0;
        emin = 1;
        d__1 = a * rbase;
        b1 = dlamc3(d__1, zero);
        c1 = a;
        c2 = a;
        d1 = a;
        d2 = a;
    /* +    WHILE( ( C1EQ.A ).AND.( C2.EQ.A ).AND. */
    /*    $       ( D1EQ.A ).AND.( D2.EQ.A )      )LOOP */
    L10:
        if (c1 == a && c2 == a && d1 == a && d2 == a) {
	    --(emin);
	    a = b1;
	    d__1 = a / _base;
	    b1 = dlamc3(d__1, zero);
	    d__1 = b1 * _base;
	    c1 = dlamc3(d__1, zero);
	    d1 = zero;
	    i__1 = _base;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        d1 += b1;
    /* L20: */
	    }
	    d__1 = a * rbase;
	    b2 = dlamc3(d__1, zero);
	    d__1 = b2 / rbase;
	    c2 = dlamc3(d__1, zero);
	    d2 = zero;
	    i__1 = _base;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        d2 += b2;
    /* L30: */
	    }
	    goto L10;
        }
    /* +    END WHILE */

        return 0;
    } 
}

