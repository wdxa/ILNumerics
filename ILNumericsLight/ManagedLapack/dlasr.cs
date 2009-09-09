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
    public static unsafe int dlasr(char side, char pivot, char direct, int m, int n, double* c__, double* s, double* a, int lda)
    {
        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2;

        /* Local variables */
        int i__, j, info;
        double temp;
        double ctemp, stemp;

        /*     Test the input parameters */

        /* Parameter adjustments */
        --c__;
        --s;
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;

        /* Function Body */
        info = 0;
        if (! (lsame(side, 'L') || lsame(side, 'R'))) {
	    info = 1;
        } else if (! (lsame(pivot, 'V') || lsame(pivot, 
	        'T') || lsame(pivot, 'B'))) {
	    info = 2;
        } else if (! (lsame(direct, 'F') || lsame(direct, 
	        'B'))) {
	    info = 3;
        } else if (m < 0) {
	    info = 4;
        } else if (n < 0) {
	    info = 5;
        } else if (lda < max(1,m)) {
	    info = 9;
        }
        if (info != 0) {
	    xerbla("DLASR ", info);
	    return 0;
        }

        /*     Quick return if possible */

        if (m == 0 || n == 0) {
	    return 0;
        }
        if (lsame(side, 'L')) {

    /*        Form  P * A */

	    if (lsame(pivot, 'V')) {
	        if (lsame(direct, 'F')) {
		    i__1 = m - 1;
		    for (j = 1; j <= i__1; ++j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = n;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[j + 1 + i__ * a_dim1];
			        a[j + 1 + i__ * a_dim1] = ctemp * temp - stemp * 
				        a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = stemp * temp + ctemp * a[j 
				        + i__ * a_dim1];
    /* L10: */
			    }
		        }
/* L20: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = m - 1; j >= 1; --j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = n;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[j + 1 + i__ * a_dim1];
			        a[j + 1 + i__ * a_dim1] = ctemp * temp - stemp * 
				        a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = stemp * temp + ctemp * a[j 
				        + i__ * a_dim1];
    /* L30: */
			    }
		        }
    /* L40: */
		    }
	        }
	    } else if (lsame(pivot, 'T')) {
	        if (lsame(direct, 'F')) {
		    i__1 = m;
		    for (j = 2; j <= i__1; ++j) {
		        ctemp = c__[j - 1];
		        stemp = s[j - 1];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = n;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = ctemp * temp - stemp * a[
				        i__ * a_dim1 + 1];
			        a[i__ * a_dim1 + 1] = stemp * temp + ctemp * a[
				        i__ * a_dim1 + 1];
    /* L50: */
			    }
		        }
    /* L60: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = m; j >= 2; --j) {
		        ctemp = c__[j - 1];
		        stemp = s[j - 1];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = n;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = ctemp * temp - stemp * a[
				        i__ * a_dim1 + 1];
			        a[i__ * a_dim1 + 1] = stemp * temp + ctemp * a[
				        i__ * a_dim1 + 1];
    /* L70: */
			    }
		        }
    /* L80: */
		    }
	        }
	    } else if (lsame(pivot, 'B')) {
	        if (lsame(direct, 'F')) {
		    i__1 = m - 1;
		    for (j = 1; j <= i__1; ++j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = n;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = stemp * a[m + i__ * a_dim1]
				         + ctemp * temp;
			        a[m + i__ * a_dim1] = ctemp * a[m + i__ * 
				        a_dim1] - stemp * temp;
    /* L90: */
			    }
		        }
    /* L100: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = m - 1; j >= 1; --j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = n;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[j + i__ * a_dim1];
			        a[j + i__ * a_dim1] = stemp * a[m + i__ * a_dim1]
				         + ctemp * temp;
			        a[m + i__ * a_dim1] = ctemp * a[m + i__ * 
				        a_dim1] - stemp * temp;
    /* L110: */
			    }
		        }
    /* L120: */
		    }
	        }
	    }
        } else if (lsame(side, 'R')) {

    /*        Form A * P' */

	    if (lsame(pivot, 'V')) {
	        if (lsame(direct, 'F')) {
		    i__1 = n - 1;
		    for (j = 1; j <= i__1; ++j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = m;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[i__ + (j + 1) * a_dim1];
			        a[i__ + (j + 1) * a_dim1] = ctemp * temp - stemp *
				         a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = stemp * temp + ctemp * a[
				        i__ + j * a_dim1];
    /* L130: */
			    }
		        }
    /* L140: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = n - 1; j >= 1; --j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = m;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[i__ + (j + 1) * a_dim1];
			        a[i__ + (j + 1) * a_dim1] = ctemp * temp - stemp *
				         a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = stemp * temp + ctemp * a[
				        i__ + j * a_dim1];
    /* L150: */
			    }
		        }
    /* L160: */
		    }
	        }
	    } else if (lsame(pivot, 'T')) {
	        if (lsame(direct, 'F')) {
		    i__1 = n;
		    for (j = 2; j <= i__1; ++j) {
		        ctemp = c__[j - 1];
		        stemp = s[j - 1];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = m;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = ctemp * temp - stemp * a[
				        i__ + a_dim1];
			        a[i__ + a_dim1] = stemp * temp + ctemp * a[i__ + 
				        a_dim1];
    /* L170: */
			    }
		        }
    /* L180: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = n; j >= 2; --j) {
		        ctemp = c__[j - 1];
		        stemp = s[j - 1];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = m;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = ctemp * temp - stemp * a[
				        i__ + a_dim1];
			        a[i__ + a_dim1] = stemp * temp + ctemp * a[i__ + 
				        a_dim1];
    /* L190: */
			    }
		        }
    /* L200: */
		    }
	        }
	    } else if (lsame(pivot, 'B')) {
	        if (lsame(direct, 'F')) {
		    i__1 = n - 1;
		    for (j = 1; j <= i__1; ++j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__2 = m;
			    for (i__ = 1; i__ <= i__2; ++i__) {
			        temp = a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = stemp * a[i__ + n * a_dim1]
				         + ctemp * temp;
			        a[i__ + n * a_dim1] = ctemp * a[i__ + n * 
				        a_dim1] - stemp * temp;
    /* L210: */
			    }
		        }
    /* L220: */
		    }
	        } else if (lsame(direct, 'B')) {
		    for (j = n - 1; j >= 1; --j) {
		        ctemp = c__[j];
		        stemp = s[j];
		        if (ctemp != 1 || stemp != 0) {
			    i__1 = m;
			    for (i__ = 1; i__ <= i__1; ++i__) {
			        temp = a[i__ + j * a_dim1];
			        a[i__ + j * a_dim1] = stemp * a[i__ + n * a_dim1]
				         + ctemp * temp;
			        a[i__ + n * a_dim1] = ctemp * a[i__ + n * 
				        a_dim1] - stemp * temp;
    /* L230: */
			    }
		        }
    /* L240: */
		    }
	        }
	    }
        }

        return 0;
    }
}

