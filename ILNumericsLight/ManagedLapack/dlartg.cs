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
    public static int dlartg(double f, double g, ref double cs, ref double sn, ref double r__)
    {
        /* System generated locals */
        int i__1;
        double d__1, d__2;

        /* Local variables */
        int i__;
        double f1, g1, eps, scale;
        int count;
        double safmn2, safmx2;
        double safmin;

    /*     IF( FIRST ) THEN */
        safmin = dlamch('S');
        eps = dlamch('E');
        d__1 = dlamch('B');
        i__1 = (int) (log(safmin / eps) / log(dlamch('B')) / 2.0);
        safmn2 = pow_di(d__1, i__1);
        safmx2 = 1.0 / safmn2;
    /*        FIRST = .FALSE. */
    /*     END IF */
        if (g == 0.0) {
	    cs = 1.0;
	    sn = 0.0;
	    r__ = f;
        } else if (f == 0.0) {
	    cs = 0.0;
	    sn = 1.0;
	    r__ = g;
        } else {
	    f1 = f;
	    g1 = g;
    /* Computing MAX */
	    d__1 = abs(f1);
        d__2 = abs(g1);
	    scale = max(d__1,d__2);
	    if (scale >= safmx2) {
	        count = 0;
    L10:
	        ++count;
	        f1 *= safmn2;
	        g1 *= safmn2;
    /* Computing MAX */
            d__1 = abs(f1);
            d__2 = abs(g1);
	        scale = max(d__1,d__2);
	        if (scale >= safmx2) {
		    goto L10;
	        }
    /* Computing 2nd power */
	        d__1 = f1;
    /* Computing 2nd power */
	        d__2 = g1;
	        r__ = sqrt(d__1 * d__1 + d__2 * d__2);
	        cs = f1 / r__;
	        sn = g1 / r__;
	        i__1 = count;
	        for (i__ = 1; i__ <= i__1; ++i__) {
		    r__ *= safmx2;
    /* L20: */
	        }
	    } else if (scale <= safmn2) {
	        count = 0;
    L30:
	        ++count;
	        f1 *= safmx2;
	        g1 *= safmx2;
    /* Computing MAX */
	        d__1 = abs(f1);
            d__2 = abs(g1);
	        scale = max(d__1,d__2);
	        if (scale <= safmn2) {
		    goto L30;
	        }
    /* Computing 2nd power */
	        d__1 = f1;
    /* Computing 2nd power */
	        d__2 = g1;
	        r__ = sqrt(d__1 * d__1 + d__2 * d__2);
	        cs = f1 / r__;
	        sn = g1 / r__;
	        i__1 = count;
	        for (i__ = 1; i__ <= i__1; ++i__) {
		    r__ *= safmn2;
    /* L40: */
	        }
	    } else {
    /* Computing 2nd power */
	        d__1 = f1;
    /* Computing 2nd power */
	        d__2 = g1;
	        r__ = sqrt(d__1 * d__1 + d__2 * d__2);
	        cs = f1 / r__;
	        sn = g1 / r__;
	    }
	    if (abs(f) > abs(g) && cs < 0.0) {
	        cs = -(cs);
	        sn = -(sn);
	        r__ = -(r__);
	    }
        }
        return 0;
    } 
}

