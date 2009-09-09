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
    public static unsafe int idamax(int n, double *dx, int incx)
    {
        /* System generated locals */
        int ret_val, i__1;

        /* Local variables */
        int i__, ix;
        double dmax__;

        /* Parameter adjustments */
        --dx;

        /* Function Body */
        ret_val = 0;
        if (n < 1 || incx <= 0) {
	    return ret_val;
        }
        ret_val = 1;
        if (n == 1) {
	    return ret_val;
        }
        if (incx == 1) {
	    goto L20;
        }

    /*        code for increment not equal to 1 */

        ix = 1;
        dmax__ = abs(dx[1]);
        ix += incx;
        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    if (abs(dx[ix]) <= dmax__) {
	        goto L5;
	    }
	    ret_val = i__;
	    dmax__ = abs(dx[ix]);
    L5:
	    ix += incx;
    /* L10: */
        }
        return ret_val;

    /*        code for increment equal to 1 */

    L20:
        dmax__ = abs(dx[1]);
        i__1 = n;
        for (i__ = 2; i__ <= i__1; ++i__) {
	    if (abs(dx[i__]) <= dmax__) {
	        goto L30;
	    }
	    ret_val = i__;
	    dmax__ = abs(dx[i__]);
    L30:
	    ;
        }
        return ret_val;
    }
}

