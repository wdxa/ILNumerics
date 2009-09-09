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
    public static unsafe double dasum(int n, double *dx, int incx)
    {
        /* System generated locals */
        int i__1, i__2;
        double ret_val, d__1, d__2, d__3, d__4, d__5, d__6;

        /* Local variables */
        int i__, m, mp1;
        double dtemp;
        int nincx;

        /* Parameter adjustments */
        --dx;

        /* Function Body */
        ret_val = 0.0;
        dtemp = 0.0;
        if (n <= 0 || incx <= 0) {
	    return ret_val;
        }
        if (incx == 1) {
	    goto L20;
        }

    /*        code for increment not equal to 1 */

        nincx = n * incx;
        i__1 = nincx;
        i__2 = incx;
        for (i__ = 1; i__2 < 0 ? i__ >= i__1 : i__ <= i__1; i__ += i__2) {
        d__1 = dx[i__];
	    dtemp += ( abs(d__1));
    /* L10: */
        }
        ret_val = dtemp;
        return ret_val;

    /*        code for increment equal to 1 */


    /*        clean-up loop */

    L20:
        m = n % 6;
        if (m == 0) {
	    goto L40;
        }
        i__2 = m;
        for (i__ = 1; i__ <= i__2; ++i__) {
        d__1 = dx[i__];
	    dtemp += ( abs(d__1));
    /* L30: */
        }
        if (n < 6) {
	    goto L60;
        }
    L40:
        mp1 = m + 1;
        i__2 = n;
        for (i__ = mp1; i__ <= i__2; i__ += 6) {
        d__1 = dx[i__];
        d__2 = dx[i__ + 1];
        d__3 = dx[i__ + 2];
        d__4 = dx[i__ + 3];
        d__5 = dx[i__ + 4];
        d__6 = dx[i__ + 5];
	    dtemp = dtemp + ( abs(d__1)) + (abs(d__2)) + (abs(d__3)) + (abs(d__4)) + (abs(d__5)) + (abs(d__6));
    /* L50: */
        }
    L60:
        ret_val = dtemp;
        return ret_val;
    }
}

