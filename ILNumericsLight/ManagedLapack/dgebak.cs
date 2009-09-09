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
    public static unsafe int dgebak(char job, char side, int n, int ilo, int ihi, double* scale, int m, double* v, int ldv, ref int info)
    {
        /* System generated locals */
        int v_dim1, v_offset, i__1;

        /* Local variables */
        int i__, k;
        double s;
        int ii;
        bool leftv;
        bool rightv;

        /* Parameter adjustments */
        --scale;
        v_dim1 = ldv;
        v_offset = 1 + v_dim1;
        v -= v_offset;

        /* Function Body */
        rightv = lsame(side, 'R');
        leftv = lsame(side, 'L');

        info = 0;
        if (! lsame(job, 'N') && ! lsame(job, 'P') && ! lsame(job, 'S') 
	        && ! lsame(job, 'B')) {
	    info = -1;
        } else if (! rightv && ! leftv) {
	    info = -2;
        } else if (n < 0) {
	    info = -3;
        } else if (ilo < 1 || ilo > max(1,n)) {
	    info = -4;
        } else if (ihi < min(ilo,n) || ihi > n) {
	    info = -5;
        } else if (m < 0) {
	    info = -7;
        } else if (ldv < max(1,n)) {
	    info = -9;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGEBAK", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0) {
	    return 0;
        }
        if (m == 0) {
	    return 0;
        }
        if (lsame(job, 'N')) {
	    return 0;
        }

        if (ilo == ihi) {
	    goto L30;
        }

    /*     Backward balance */

        if (lsame(job, 'S') || lsame(job, 'B')) {

	    if (rightv) {
	        i__1 = ihi;
	        for (i__ = ilo; i__ <= i__1; ++i__) {
		    s = scale[i__];
		    dscal(m, s, &v[i__ + v_dim1], ldv);
    /* L10: */
	        }
	    }

	    if (leftv) {
	        i__1 = ihi;
	        for (i__ = ilo; i__ <= i__1; ++i__) {
		    s = 1.0 / scale[i__];
		    dscal(m, s, &v[i__ + v_dim1], ldv);
    /* L20: */
	        }
	    }

        }

    /*     Backward permutation */

    /*     For  I = ILO-1 step -1 until 1, */
    /*              IHI+1 step 1 until N do -- */

    L30:
        if (lsame(job, 'P') || lsame(job, 'B')) {
	    if (rightv) {
	        i__1 = n;
	        for (ii = 1; ii <= i__1; ++ii) {
		    i__ = ii;
		    if (i__ >= ilo && i__ <= ihi) {
		        goto L40;
		    }
		    if (i__ < ilo) {
		        i__ = ilo - ii;
		    }
		    k = (int) scale[i__];
		    if (k == i__) {
		        goto L40;
		    }
		    dswap(m, &v[i__ + v_dim1], ldv, &v[k + v_dim1], ldv);
    L40:
		    ;
	        }
	    }

	    if (leftv) {
	        i__1 = n;
	        for (ii = 1; ii <= i__1; ++ii) {
		    i__ = ii;
		    if (i__ >= ilo && i__ <= ihi) {
		        goto L50;
		    }
		    if (i__ < ilo) {
		        i__ = ilo - ii;
		    }
		    k = (int) scale[i__];
		    if (k == i__) {
		        goto L50;
		    }
		    dswap(m, &v[i__ + v_dim1], ldv, &v[k + v_dim1], ldv);
    L50:
		    ;
	        }
	    }
        }

        return 0;
    }
}

