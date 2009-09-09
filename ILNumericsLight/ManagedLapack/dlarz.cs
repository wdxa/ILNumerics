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
    public static unsafe int dlarz(char side, int m, int n, int l, double *v,
        int incv, double tau, double *c__, int ldc, double *work)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b5 = 1.0;

        /* System generated locals */
        int c_dim1, c_offset;
        double d__1;

        /* Parameter adjustments */
        --v;
        c_dim1 = ldc;
        c_offset = 1 + c_dim1;
        c__ -= c_offset;
        --work;

        /* Function Body */
        if (lsame(side, 'L')) {

    /*        Form  H * C */

	    if (tau != 0.0) {

    /*           w( 1:n ) = C( 1, 1:n ) */

	        dcopy(n, &c__[c_offset], ldc, &work[1], c__1);

    /*           w( 1:n ) = w( 1:n ) + C( m-l+1:m, 1:n )' * v( 1:l ) */

	        dgemv('T', l, n, c_b5, &c__[m - l + 1 + c_dim1], ldc, 
		        &v[1], incv, c_b5, &work[1], c__1);

    /*           C( 1, 1:n ) = C( 1, 1:n ) - tau * w( 1:n ) */

	        d__1 = -(tau);
	        daxpy(n, d__1, &work[1], c__1, &c__[c_offset], ldc);

    /*           C( m-l+1:m, 1:n ) = C( m-l+1:m, 1:n ) - ... */
    /*                               tau * v( 1:l ) * w( 1:n )' */

	        d__1 = -(tau);
	        dger(l, n, d__1, &v[1], incv, &work[1], c__1, &c__[m - l + 1 
		        + c_dim1], ldc);
	    }

        } else {

    /*        Form  C * H */

	    if (tau != 0.0) {

    /*           w( 1:m ) = C( 1:m, 1 ) */

	        dcopy(m, &c__[c_offset], c__1, &work[1], c__1);

    /*           w( 1:m ) = w( 1:m ) + C( 1:m, n-l+1:n, 1:n ) * v( 1:l ) */

	        dgemv('N', m, l, c_b5, &c__[(n - l + 1) * c_dim1 + 
		        1], ldc, &v[1], incv, c_b5, &work[1], c__1);

    /*           C( 1:m, 1 ) = C( 1:m, 1 ) - tau * w( 1:m ) */

	        d__1 = -(tau);
	        daxpy(m, d__1, &work[1], c__1, &c__[c_offset], c__1);

    /*           C( 1:m, n-l+1:n ) = C( 1:m, n-l+1:n ) - ... */
    /*                               tau * w( 1:m ) * v( 1:l )' */

	        d__1 = -(tau);
	        dger(m, l, d__1, &work[1], c__1, &v[1], incv, &c__[(n - l + 
		        1) * c_dim1 + 1], ldc);

	    }

        }

        return 0;
    } 
}

