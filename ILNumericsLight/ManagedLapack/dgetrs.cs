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
    public static unsafe int dgetrs(char trans, int n, int nrhs, double *a,
        int lda, int *ipiv, double *b, int ldb, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b12 = 1.0;
        const int c_n1 = -1;

        /* System generated locals */
        int a_dim1, a_offset, b_dim1, b_offset, i__1;

        /* Local variables */
        bool notran;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --ipiv;
        b_dim1 = ldb;
        b_offset = 1 + b_dim1;
        b -= b_offset;

        /* Function Body */
        info = 0;
        notran = lsame(trans, 'N');
        if (! notran && ! lsame(trans, 'T') && ! lsame(trans, 'C')) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (nrhs < 0) {
	    info = -3;
        } else if (lda < max(1,n)) {
	    info = -5;
        } else if (ldb < max(1,n)) {
	    info = -8;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DGETRS", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0 || nrhs == 0) {
	    return 0;
        }

        if (notran) {

    /*        Solve A * X = B. */

    /*        Apply row interchanges to the right hand sides. */

	    dlaswp(nrhs, &b[b_offset], ldb, c__1, n, &ipiv[1], c__1);

    /*        Solve L*X = B, overwriting B with X. */

	    dtrsm('L', 'L', 'N', 'U', n, nrhs, c_b12, &a[
		    a_offset], lda, &b[b_offset], ldb);

    /*        Solve U*X = B, overwriting B with X. */

	    dtrsm('L', 'U', 'N', 'N', n, nrhs, c_b12, &
		    a[a_offset], lda, &b[b_offset], ldb);
        } else {

    /*        Solve A' * X = B. */

    /*        Solve U'*X = B, overwriting B with X. */

	    dtrsm('L', 'U', 'T', 'N', n, nrhs, c_b12, &a[
		    a_offset], lda, &b[b_offset], ldb);

    /*        Solve L'*X = B, overwriting B with X. */

	    dtrsm('L', 'L', 'T', 'U', n, nrhs, c_b12, &a[
		    a_offset], lda, &b[b_offset], ldb);

    /*        Apply row interchanges to the solution vectors. */

	    dlaswp(nrhs, &b[b_offset], ldb, c__1, n, &ipiv[1], c_n1);
        }

        return 0;
    } 
}

