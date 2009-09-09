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
    public static unsafe int dlarzt(char direct, char storev, int n,
        int k, double* v, int ldv, double* tau, double* t, int ldt)
    {
        /* Table of constant values */
        const double c_b8 = 0.00;
        const int c__1 = 1;

        /* System generated locals */
        int t_dim1, t_offset, v_dim1, v_offset, i__1;
        double d__1;

        /* Local variables */
        int i__, j, info;

        /* Parameter adjustments */
        v_dim1 = ldv;
        v_offset = 1 + v_dim1;
        v -= v_offset;
        --tau;
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;

        /* Function Body */
        info = 0;
        if (! lsame(direct, 'B')) {
	    info = -1;
        } else if (! lsame(storev, 'R')) {
	    info = -2;
        }
        if (info != 0) {
	    i__1 = -info;
	    xerbla("DLARZT", i__1);
	    return 0;
        }

        for (i__ = k; i__ >= 1; --i__) {
	    if (tau[i__] == 0.0) {

    /*           H(i)  =  I */

	        i__1 = k;
	        for (j = i__; j <= i__1; ++j) {
		    t[j + i__ * t_dim1] = 0.0;
    /* L10: */
	        }
	    } else {

    /*           general case */

	        if (i__ < k) {

    /*              T(i+1:k,i) = - tau(i) * V(i+1:k,1:n) * V(i,1:n)' */

		    i__1 = k - i__;
		    d__1 = -tau[i__];
		    dgemv('N', i__1, n, d__1, &v[i__ + 1 + v_dim1], 
			    ldv, &v[i__ + v_dim1], ldv, c_b8, &t[i__ + 1 + i__ * 
			    t_dim1], c__1);

    /*              T(i+1:k,i) = T(i+1:k,i+1:k) * T(i+1:k,i) */

		    i__1 = k - i__;
		    dtrmv('L', 'N', 'N', i__1, &t[i__ + 1 
			    + (i__ + 1) * t_dim1], ldt, &t[i__ + 1 + i__ * t_dim1]
    , c__1);
	        }
	        t[i__ + i__ * t_dim1] = tau[i__];
	    }
    /* L20: */
        }
        return 0;
    } 
}

