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
    public static unsafe int dlascl(char type__, int kl, int ku, double cfrom, double cto, int m, int n, double* a, int lda, ref int info)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3, i__4, i__5;

        /* Local variables */
        int i__, j, k1, k2, k3, k4;
        double mul, cto1;
        bool done;
        double ctoc;
        int itype;
        double cfrom1;
        double cfromc;
        double bignum, smlnum;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;

        /* Function Body */
        info = 0;

        if (lsame(type__, 'G')) {
	    itype = 0;
        } else if (lsame(type__, 'L')) {
	    itype = 1;
        } else if (lsame(type__, 'U')) {
	    itype = 2;
        } else if (lsame(type__, 'H')) {
	    itype = 3;
        } else if (lsame(type__, 'B')) {
	    itype = 4;
        } else if (lsame(type__, 'Q')) {
	    itype = 5;
        } else if (lsame(type__, 'Z')) {
	    itype = 6;
        } else {
	    itype = -1;
        }

        if (itype == -1) {
	    info = -1;
        } else if (cfrom == 0) {
	    info = -4;
        } else if (m < 0) {
	    info = -6;
        } else if (n < 0 || itype == 4 && n != m || itype == 5 && n != m) {
	    info = -7;
        } else if (itype <= 3 && lda < max(1,m)) {
	    info = -9;
        } else if (itype >= 4) {
    /* Computing MAX */
	    i__1 = m - 1;
	    if (kl < 0 || kl > max(i__1,0)) {
	        info = -2;
	    } else /* if(complicated condition) */ {
    /* Computing MAX */
	        i__1 = n - 1;
	        if (ku < 0 || ku > max(i__1,0) || (itype == 4 || itype == 5) && 
		        kl != ku) {
		    info = -3;
	        } else if (itype == 4 && lda < kl + 1 || itype == 5 && lda < 
                ku + 1 || itype == 6 && lda < (kl << 1) + ku + 1) {
		    info = -9;
	        }
	    }
        }

        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DLASCL", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n == 0 || m == 0) {
	    return 0;
        }

    /*     Get machine parameters */

        smlnum = dlamch('S');
        bignum = 1.0 / smlnum;

        cfromc = cfrom;
        ctoc = cto;

    L10:
        cfrom1 = cfromc * smlnum;
        cto1 = ctoc / bignum;
        if (abs(cfrom1) > abs(ctoc) && ctoc != 0) {
	    mul = smlnum;
	    done = false;
	    cfromc = cfrom1;
        } else if (abs(cto1) > abs(cfromc)) {
	    mul = bignum;
	    done = false;
	    ctoc = cto1;
        } else {
	    mul = ctoc / cfromc;
	    done = true;
        }

        if (itype == 0) {

    /*        Full matrix */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L20: */
	        }
    /* L30: */
	    }

        } else if (itype == 1) {

    /*        Lower triangular matrix */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = m;
	        for (i__ = j; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L40: */
	        }
    /* L50: */
	    }

        } else if (itype == 2) {

    /*        Upper triangular matrix */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
	        i__2 = min(j,m);
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L60: */
	        }
    /* L70: */
	    }

        } else if (itype == 3) {

    /*        Upper Hessenberg matrix */

	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
    /* Computing MIN */
	        i__3 = j + 1;
	        i__2 = min(i__3,m);
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L80: */
	        }
    /* L90: */
	    }

        } else if (itype == 4) {

    /*        Lower half of a symmetric band matrix */

	    k3 = kl + 1;
	    k4 = n + 1;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
    /* Computing MIN */
	        i__3 = k3;
            i__4 = k4 - j;
	        i__2 = min(i__3,i__4);
	        for (i__ = 1; i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L100: */
	        }
    /* L110: */
	    }

        } else if (itype == 5) {

    /*        Upper half of a symmetric band matrix */

	    k1 = ku + 2;
	    k3 = ku + 1;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
    /* Computing MAX */
	        i__2 = k1 - j;
	        i__3 = k3;
	        for (i__ = max(i__2,1); i__ <= i__3; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L120: */
	        }
    /* L130: */
	    }

        } else if (itype == 6) {

    /*        Band matrix */

	    k1 = kl + ku + 2;
	    k2 = kl + 1;
	    k3 = (kl << 1) + ku + 1;
	    k4 = kl + ku + 1 + m;
	    i__1 = n;
	    for (j = 1; j <= i__1; ++j) {
    /* Computing MAX */
	        i__3 = k1 - j;
    /* Computing MIN */
            i__4 = k3;
            i__5 = k4 - j;
	        i__2 = min(i__4,i__5);
	        for (i__ = max(i__3,k2); i__ <= i__2; ++i__) {
		    a[i__ + j * a_dim1] *= mul;
    /* L140: */
	        }
    /* L150: */
	    }

        }

        if (! done) {
	    goto L10;
        }

        return 0;
    } 
}

