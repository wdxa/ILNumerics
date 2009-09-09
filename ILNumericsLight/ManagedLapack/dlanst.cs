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
    public static unsafe double dlanst(char norm, int n, double* d__, double* e)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int i__1;
        double ret_val, d__1, d__2, d__3, d__4, d__5;

        /* Local variables */
        int i__;
        double sum, scale;
        double anorm=0;

        /* Parameter adjustments */
        --e;
        --d__;

        /* Function Body */
        if (n <= 0) {
	    anorm = 0;
        } else if (lsame(norm, 'M')) {

    /*        Find max(abs(A(i,j))). */

        d__1 = d__[n];
	    anorm = ( abs(d__1));
	    i__1 = n - 1;
	    for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing MAX */
	        d__2 = anorm;
            d__1 = d__[i__];
            d__3 = ( abs(d__1));
	        anorm = max(d__2,d__3);
    /* Computing MAX */
	        d__2 = anorm;
            d__1 = e[i__];
            d__3 = (abs(d__1));
	        anorm = max(d__2,d__3);
    /* L10: */
	    }
        } else if (lsame(norm, 'O') || norm == '1' || lsame(norm, 'I')) {

    /*        Find norm1(A). */

	    if (n == 1) {
	        anorm = abs(d__[1]);
	    } else {
    /* Computing MAX */
	        d__3 = abs(d__[1]) + abs(e[1]);
            d__1 = e[n - 1];
            d__2 = d__[n];
            d__4 = (abs(d__1)) + (abs(d__2));
	        anorm = max(d__3,d__4);
	        i__1 = n - 1;
	        for (i__ = 2; i__ <= i__1; ++i__) {
    /* Computing MAX */
		    d__4 = anorm;
            d__1 = d__[i__];
            d__2 = e[i__];
            d__3 = e[i__ - 1];
            d__5 = (abs(d__1)) + (abs(d__2)) + ( abs(d__3));
		    anorm = max(d__4,d__5);
    /* L20: */
	        }
	    }
        } else if (lsame(norm, 'F') || lsame(norm, 'E')) {

    /*        Find normF(A). */

	    scale = 0;
	    sum = 1;
	    if (n > 1) {
	        i__1 = n - 1;
	        dlassq(i__1, &e[1], c__1, ref scale, ref sum);
	        sum *= 2;
	    }
	    dlassq(n, &d__[1], c__1, ref scale, ref sum);
	    anorm = scale * sqrt(sum);
        }

        ret_val = anorm;
        return ret_val;
    } 
}

