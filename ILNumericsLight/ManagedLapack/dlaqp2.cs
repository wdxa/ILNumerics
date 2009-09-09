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
    public static unsafe int dlaqp2(int m, int n, int offset, double *a, int lda,
        int *jpvt, double *tau, double *vn1, double *vn2, double *work)
    {
        /* Table of constant values */
        const int c__1 = 1;

        /* System generated locals */
        int a_dim1, a_offset, i__1, i__2, i__3;
        double d__1, d__2;

        /* Local variables */
        int i__, j, mn;
        double aii;
        int pvt;
        double temp;
        double temp2, tol3z;
        int offpi, itemp;

        /* Parameter adjustments */
        a_dim1 = lda;
        a_offset = 1 + a_dim1;
        a -= a_offset;
        --jpvt;
        --tau;
        --vn1;
        --vn2;
        --work;

        /* Function Body */
    /* Computing MIN */
        i__1 = m - offset;
        mn = min(i__1,n);
        tol3z = sqrt(dlamch('E'));

    /*     Compute factorization. */

        i__1 = mn;
        for (i__ = 1; i__ <= i__1; ++i__) {

	    offpi = offset + i__;

    /*        Determine ith pivot column and swap if necessary. */

	    i__2 = n - i__ + 1;
	    pvt = i__ - 1 + idamax(i__2, &vn1[i__], c__1);

	    if (pvt != i__) {
	        dswap(m, &a[pvt * a_dim1 + 1], c__1, &a[i__ * a_dim1 + 1], 
		        c__1);
	        itemp = jpvt[pvt];
	        jpvt[pvt] = jpvt[i__];
	        jpvt[i__] = itemp;
	        vn1[pvt] = vn1[i__];
	        vn2[pvt] = vn2[i__];
	    }

    /*        Generate elementary reflector H(i). */

	    if (offpi < m) {
	        i__2 = m - offpi + 1;
	        dlarfg(i__2, ref a[offpi + i__ * a_dim1], &a[offpi + 1 + i__ * 
		        a_dim1], c__1, ref tau[i__]);
	    } else {
	        dlarfg(c__1, ref a[m + i__ * a_dim1], &a[m + i__ * a_dim1], 
		        c__1, ref tau[i__]);
	    }

	    if (i__ < n) {

    /*           Apply H(i)' to A(offset+i:m,i+1:n) from the left. */

	        aii = a[offpi + i__ * a_dim1];
	        a[offpi + i__ * a_dim1] = 1.0;
	        i__2 = m - offpi + 1;
	        i__3 = n - i__;
	        dlarf('L', i__2, i__3, &a[offpi + i__ * a_dim1], c__1, 
		        tau[i__], &a[offpi + (i__ + 1) * a_dim1], lda, &work[1]);
	        a[offpi + i__ * a_dim1] = aii;
	    }

    /*        Update partial column norms. */

	    i__2 = n;
	    for (j = i__ + 1; j <= i__2; ++j) {
	        if (vn1[j] != 0.0) {

    /*              NOTE: The following 4 lines follow from the analysis in */
    /*              Lapack Working Note 176. */

    /* Computing 2nd power */
            d__1 = a[offpi + j * a_dim1];
		    d__2 = ( abs(d__1)) / vn1[j];
		    temp = 1.0 - d__2 * d__2;
		    temp = max(temp,0.0);
    /* Computing 2nd power */
		    d__1 = vn1[j] / vn2[j];
		    temp2 = temp * (d__1 * d__1);
		    if (temp2 <= tol3z) {
		        if (offpi < m) {
			    i__3 = m - offpi;
			    vn1[j] = dnrm2(i__3, &a[offpi + 1 + j * a_dim1], 
				    c__1);
			    vn2[j] = vn1[j];
		        } else {
			    vn1[j] = 0.0;
			    vn2[j] = 0.0;
		        }
		    } else {
		        vn1[j] *= sqrt(temp);
		    }
	        }
    /* L10: */
	    }

    /* L20: */
        }

        return 0;
    } 
}

