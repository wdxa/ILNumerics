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
    public static unsafe int dlarzb(char side, char trans, char direct, char storev, int m, int n, int k, int l,
        double *v, int ldv, double *t, int ldt, double *c__, int ldc, double *work, int ldwork)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b13 = 1.0;
        const double c_b23 = -1.0;

        /* System generated locals */
        int c_dim1, c_offset, t_dim1, t_offset, v_dim1, v_offset, work_dim1, work_offset, i__1, i__2;

        /* Local variables */
        int i__, j, info;
        char transt;

        /* Parameter adjustments */
        v_dim1 = ldv;
        v_offset = 1 + v_dim1;
        v -= v_offset;
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        work_dim1 = ldwork;
        work_offset = 1 + work_dim1;
        work -= work_offset;

        /* Function Body */
        if (m <= 0 || n <= 0) {
	    return 0;
        }

    /*     Check for currently supported options */

        info = 0;
        if (! lsame(direct, 'B')) {
	    info = -3;
        } else if (! lsame(storev, 'R')) {
	    info = -4;
        }
        if (info != 0) {
	    i__1 = -info;
	    xerbla("DLARZB", i__1);
	    return 0;
        }

        if (lsame(trans, 'N')) {
	    transt = 'T';
        } else {
	    transt = 'N';
        }

        if (lsame(side, 'L')) {

    /*        Form  H * C  or  H' * C */

    /*        W( 1:n, 1:k ) = C( 1:k, 1:n )' */

	    i__1 = k;
	    for (j = 1; j <= i__1; ++j) {
	        dcopy(n, &c__[j + c_dim1], ldc, &work[j * work_dim1 + 1], c__1);
    /* L10: */
	    }

    /*        W( 1:n, 1:k ) = W( 1:n, 1:k ) + ... */
    /*                        C( m-l+1:m, 1:n )' * V( 1:k, 1:l )' */

	    if (l > 0) {
	        dgemm('T', 'T', n, k, l, c_b13, &c__[m - l + 
		        1 + c_dim1], ldc, &v[v_offset], ldv, c_b13, &work[
		        work_offset], ldwork);
	    }

    /*        W( 1:n, 1:k ) = W( 1:n, 1:k ) * T'  or  W( 1:m, 1:k ) * T */

	    dtrmm('R', 'L', transt, 'N', n, k, c_b13, &t[
		    t_offset], ldt, &work[work_offset], ldwork);

    /*        C( 1:k, 1:n ) = C( 1:k, 1:n ) - W( 1:n, 1:k )' */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = k;
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    c__[i__ + j * c_dim1] -= work[j + i__ * work_dim1];
    /* L20: */
	        }
    /* L30: */
	    }

    /*        C( m-l+1:m, 1:n ) = C( m-l+1:m, 1:n ) - ... */
    /*                            V( 1:k, 1:l )' * W( 1:n, 1:k )' */

	    if (l > 0) {
	        dgemm('T', 'T', l, n, k, c_b23, &v[v_offset], 
		        ldv, &work[work_offset], ldwork, c_b13, &c__[m - l + 1 
		        + c_dim1], ldc);
	    }

        } else if (lsame(side, 'R')) {

    /*        Form  C * H  or  C * H' */

    /*        W( 1:m, 1:k ) = C( 1:m, 1:k ) */

	    i__1 = k;
	    for (j = 1; j <= i__1; ++j) {
	        dcopy(m, &c__[j * c_dim1 + 1], c__1, &work[j * work_dim1 + 1], 
		        c__1);
    /* L40: */
	    }

    /*        W( 1:m, 1:k ) = W( 1:m, 1:k ) + ... */
    /*                        C( 1:m, n-l+1:n ) * V( 1:k, 1:l )' */

	    if (l > 0) {
	        dgemm('N', 'T', m, k, l, c_b13, &c__[(n - 
		        l + 1) * c_dim1 + 1], ldc, &v[v_offset], ldv, c_b13, &
		        work[work_offset], ldwork);
	    }

    /*        W( 1:m, 1:k ) = W( 1:m, 1:k ) * T  or  W( 1:m, 1:k ) * T' */

	    dtrmm('R', 'L', trans, 'N', m, k, c_b13, &t[t_offset]
    , ldt, &work[work_offset], ldwork);

    /*        C( 1:m, 1:k ) = C( 1:m, 1:k ) - W( 1:m, 1:k ) */

	    i__1 = k;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    c__[i__ + j * c_dim1] -= work[i__ + j * work_dim1];
    /* L50: */
	        }
    /* L60: */
	    }

    /*        C( 1:m, n-l+1:n ) = C( 1:m, n-l+1:n ) - ... */
    /*                            W( 1:m, 1:k ) * V( 1:k, 1:l ) */

	    if (l > 0) {
	        dgemm('N', 'N', m, l, k, c_b23, &work[
		        work_offset], ldwork, &v[v_offset], ldv, c_b13, &c__[(n 
		        - l + 1) * c_dim1 + 1], ldc);
	    }

        }

        return 0;
    } 
}

