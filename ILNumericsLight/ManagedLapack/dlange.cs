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
    public static unsafe double dlange(char norm, int m, int n, double* a, int lda, double* work)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;
        double ret_val, d__1, d__2, d__3;

        /* Local variables */
        int i__, j;
        double sum, scale;
        double value=0;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --work;

        /* Function Body */
        if (min(m,n) == 0) {
	    value = 0.0;
        } else if (lsame(norm, 'M')) {

    /*        Find max(abs(A(i,j))). */

	    value = 0.0;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
    /* Computing MAX */
		    d__2 = value;
            d__1 = a[i__ + j * a_dim1];
            d__3 = (abs(d__1));
		    value = max(d__2,d__3);
    /* L10: */
	        }
    /* L20: */
	    }
        } else if (lsame(norm, 'O') || norm == '1') {

    /*        Find norm1(A). */

	    value = 0.0;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        sum = 0.0;
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
            d__1 = a[i__ + j * a_dim1];
		    sum += (abs(d__1));
    /* L30: */
	        }
	        value = max(value,sum);
    /* L40: */
	    }
        } else if (lsame(norm, 'I')) {

    /*        Find normI(A). */

	    i__1 = m;
	    for (i__ = 1; i__ <= i__1; ++i__) {
	        work[i__] = 0.0;
    /* L50: */
	    }
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
            d__1 = a[i__ + j * a_dim1];
		    work[i__] += (abs(d__1));
    /* L60: */
	        }
    /* L70: */
	    }
	    value = 0.0;
	    i__1 = m;
	    for (i__ = 1; i__ <= i__1; ++i__) {
    /* Computing MAX */
	        d__1 = value;
            d__2 = work[i__];
	        value = max(d__1,d__2);
    /* L80: */
	    }
        } else if (lsame(norm, 'F') || lsame(norm, 'E')) {

    /*        Find normF(A). */

	    scale = 0.0;
	    sum = 1.0;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        dlassq(m, &a[j * a_dim1 + 1], c__1, ref scale, ref sum);
    /* L90: */
	    }
	    value = scale * sqrt(sum);
        }

        ret_val = value;
        return ret_val;
    }
}

