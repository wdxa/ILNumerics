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
    public static unsafe int dlasrt(char id, int n, double* d__, ref int info)
    {
        /* System generated locals */
        int i__1, i__2;

        /* Local variables */
        int i__, j;
        double d1, d2, d3;
        int dir;
        double tmp;
        int endd;
        int[] stack = new int[64]	/* was [2][32] */;
        double dmnmx;
        int start;
        int stkpnt;

        /* Parameter adjustments */
        --d__;

        /* Function Body */
        info = 0;
        dir = -1;
        if (lsame(id, 'D')) {
	    dir = 0;
        } else if (lsame(id, 'I')) {
	    dir = 1;
        }
        if (dir == -1) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASRT", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n <= 1) {
	    return 0;
        }

        stkpnt = 1;
        stack[0] = 1;
        stack[1] = n;
    L10:
        start = stack[(stkpnt << 1) - 2];
        endd = stack[(stkpnt << 1) - 1];
        --stkpnt;
        if (endd - start <= 20 && endd - start > 0) {

    /*        Do Insertion sort on D( START:ENDD ) */

	    if (dir == 0) {

    /*           Sort into decreasing order */

	        i__1 = endd;
	        for (i__ = start + 1; i__ <= i__1; ++i__) {
		    i__2 = start + 1;
		    for (j = i__; j >= i__2; --j) {
		        if (d__[j] > d__[j - 1]) {
			    dmnmx = d__[j];
			    d__[j] = d__[j - 1];
			    d__[j - 1] = dmnmx;
		        } else {
			    goto L30;
		        }
    /* L20: */
		    }
    L30:
		    ;
	        }

	    } else {

    /*           Sort into increasing order */

	        i__1 = endd;
	        for (i__ = start + 1; i__ <= i__1; ++i__) {
		    i__2 = start + 1;
		    for (j = i__; j >= i__2; --j) {
		        if (d__[j] < d__[j - 1]) {
			    dmnmx = d__[j];
			    d__[j] = d__[j - 1];
			    d__[j - 1] = dmnmx;
		        } else {
			    goto L50;
		        }
    /* L40: */
		    }
    L50:
		    ;
	        }

	    }

        } else if (endd - start > 20) {

    /*        Partition D( START:ENDD ) and stack parts, largest one first */

    /*        Choose partition entry as median of 3 */

	    d1 = d__[start];
	    d2 = d__[endd];
	    i__ = (start + endd) / 2;
	    d3 = d__[i__];
	    if (d1 < d2) {
	        if (d3 < d1) {
		    dmnmx = d1;
	        } else if (d3 < d2) {
		    dmnmx = d3;
	        } else {
		    dmnmx = d2;
	        }
	    } else {
	        if (d3 < d2) {
		    dmnmx = d2;
	        } else if (d3 < d1) {
		    dmnmx = d3;
	        } else {
		    dmnmx = d1;
	        }
	    }

	    if (dir == 0) {

    /*           Sort into decreasing order */

	        i__ = start - 1;
	        j = endd + 1;
    L60:
    L70:
	        --j;
	        if (d__[j] < dmnmx) {
		    goto L70;
	        }
    L80:
	        ++i__;
	        if (d__[i__] > dmnmx) {
		    goto L80;
	        }
	        if (i__ < j) {
		    tmp = d__[i__];
		    d__[i__] = d__[j];
		    d__[j] = tmp;
		    goto L60;
	        }
	        if (j - start > endd - j - 1) {
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = start;
		    stack[(stkpnt << 1) - 1] = j;
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = j + 1;
		    stack[(stkpnt << 1) - 1] = endd;
	        } else {
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = j + 1;
		    stack[(stkpnt << 1) - 1] = endd;
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = start;
		    stack[(stkpnt << 1) - 1] = j;
	        }
	    } else {

    /*           Sort into increasing order */

	        i__ = start - 1;
	        j = endd + 1;
    L90:
    L100:
	        --j;
	        if (d__[j] > dmnmx) {
		    goto L100;
	        }
    L110:
	        ++i__;
	        if (d__[i__] < dmnmx) {
		    goto L110;
	        }
	        if (i__ < j) {
		    tmp = d__[i__];
		    d__[i__] = d__[j];
		    d__[j] = tmp;
		    goto L90;
	        }
	        if (j - start > endd - j - 1) {
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = start;
		    stack[(stkpnt << 1) - 1] = j;
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = j + 1;
		    stack[(stkpnt << 1) - 1] = endd;
	        } else {
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = j + 1;
		    stack[(stkpnt << 1) - 1] = endd;
		    ++stkpnt;
		    stack[(stkpnt << 1) - 2] = start;
		    stack[(stkpnt << 1) - 1] = j;
	        }
	    }
        }
        if (stkpnt > 0) {
	    goto L10;
        }
        return 0;
    }
}

