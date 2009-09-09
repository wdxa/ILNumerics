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
    public static unsafe int dlarfb(char side, char trans, char direct, char storev, int m, int n,
        int k, double *v, int ldv, double *t, int ldt, double *c__, int ldc, double *work, int ldwork)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const double c_b14 = 1.0;
        const double c_b25 = -1.0;

        /* System generated locals */
        int c_dim1, c_offset, t_dim1, t_offset, v_dim1, v_offset, work_dim1, 
	        work_offset, i__1, i__2;

        /* Local variables */
        int i__, j;
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

        if (lsame(trans, 'N')) {
	    transt = 'T';
        } else {
	    transt = 'N';
        }

        if (lsame(storev, 'C')) {

	    if (lsame(direct, 'F')) {

    /*           Let  V =  ( V1 )    (first K rows) */
    /*                     ( V2 ) */
    /*           where  V1  is unit lower triangular. */

	        if (lsame(side, 'L')) {

    /*              Form  H * C  or  H' * C  where  C = ( C1 ) */
    /*                                                  ( C2 ) */

    /*              W := C' * V  =  (C1'*V1 + C2'*V2)  (stored in WORK) */

    /*              W := C1' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(n, &c__[j + c_dim1], ldc, &work[j * work_dim1 + 1], 
			         c__1);
    /* L10: */
		    }

    /*              W := W * V1 */

		    dtrmm('R', 'L', 'N', 'U', n, k, c_b14, 
			     &v[v_offset], ldv, &work[work_offset], ldwork);
		    if (m > k) {

    /*                 W := W + C2'*V2 */

		        i__1 = m - k;
		        dgemm('T', 'N', n, k, i__1, c_b14, &
			        c__[k + 1 + c_dim1], ldc, &v[k + 1 + v_dim1], 
			        ldv, c_b14, &work[work_offset], ldwork);
		    }

    /*              W := W * T'  or  W * T */

		    dtrmm('R', 'U', transt, 'N', n, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - V * W' */

		    if (m > k) {

    /*                 C2 := C2 - V2 * W' */

		        i__1 = m - k;
		        dgemm('N', 'T', i__1, n, k, c_b25, &
			        v[k + 1 + v_dim1], ldv, &work[work_offset], 
			        ldwork, c_b14, &c__[k + 1 + c_dim1], ldc);
		    }

    /*              W := W * V1' */

		    dtrmm('R', 'L', 'T', 'U', n, k, c_b14, &
			    v[v_offset], ldv, &work[work_offset], ldwork);

    /*              C1 := C1 - W' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[j + i__ * c_dim1] -= work[i__ + j * work_dim1];
    /* L20: */
		        }
    /* L30: */
		    }

	        } else if (lsame(side, 'R')) {

    /*              Form  C * H  or  C * H'  where  C = ( C1  C2 ) */

    /*              W := C * V  =  (C1*V1 + C2*V2)  (stored in WORK) */

    /*              W := C1 */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(m, &c__[j * c_dim1 + 1], c__1, &work[j * 
			        work_dim1 + 1], c__1);
    /* L40: */
		    }

    /*              W := W * V1 */

		    dtrmm('R', 'L', 'N', 'U', m, k, c_b14, 
			     &v[v_offset], ldv, &work[work_offset], ldwork);
		    if (n > k) {

    /*                 W := W + C2 * V2 */

		        i__1 = n - k;
		        dgemm('N', 'N', m, k, i__1, 
			        c_b14, &c__[(k + 1) * c_dim1 + 1], ldc, &v[k + 
			        1 + v_dim1], ldv, c_b14, &work[work_offset], 
			        ldwork);
		    }

    /*              W := W * T  or  W * T' */

		    dtrmm('R', 'U', trans, 'N', m, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - W * V' */

		    if (n > k) {

    /*                 C2 := C2 - W * V2' */

		        i__1 = n - k;
		        dgemm('N', 'T', m, i__1, k, c_b25, &
			        work[work_offset], ldwork, &v[k + 1 + v_dim1], 
			        ldv, c_b14, &c__[(k + 1) * c_dim1 + 1], ldc);
		    }

    /*              W := W * V1' */

		    dtrmm('R', 'L', 'T', 'U', m, k, c_b14, &
			    v[v_offset], ldv, &work[work_offset], ldwork);

    /*              C1 := C1 - W */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] -= work[i__ + j * work_dim1];
    /* L50: */
		        }
    /* L60: */
		    }
	        }

	    } else {

    /*           Let  V =  ( V1 ) */
    /*                     ( V2 )    (last K rows) */
    /*           where  V2  is unit upper triangular. */

	        if (lsame(side, 'L')) {

    /*              Form  H * C  or  H' * C  where  C = ( C1 ) */
    /*                                                  ( C2 ) */

    /*              W := C' * V  =  (C1'*V1 + C2'*V2)  (stored in WORK) */

    /*              W := C2' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(n, &c__[m - k + j + c_dim1], ldc, &work[j * 
			        work_dim1 + 1], c__1);
    /* L70: */
		    }

    /*              W := W * V2 */

		    dtrmm('R', 'U', 'N', 'U', n, k, c_b14, 
			     &v[m - k + 1 + v_dim1], ldv, &work[work_offset], 
			    ldwork);
		    if (m > k) {

    /*                 W := W + C1'*V1 */

		        i__1 = m - k;
		        dgemm('T', 'N', n, k, i__1, c_b14, &
			        c__[c_offset], ldc, &v[v_offset], ldv, c_b14, &
			        work[work_offset], ldwork);
		    }

    /*              W := W * T'  or  W * T */

		    dtrmm('R', 'L', transt, 'N', n, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - V * W' */

		    if (m > k) {

    /*                 C1 := C1 - V1 * W' */

		        i__1 = m - k;
		        dgemm('N', 'T', i__1, n, k, c_b25, &
			        v[v_offset], ldv, &work[work_offset], ldwork, 
			        c_b14, &c__[c_offset], ldc)
			        ;
		    }

    /*              W := W * V2' */

		    dtrmm('R', 'U', 'T', 'U', n, k, c_b14, &
			    v[m - k + 1 + v_dim1], ldv, &work[work_offset], 
			    ldwork);

    /*              C2 := C2 - W' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[m - k + j + i__ * c_dim1] -= work[i__ + j * 
				    work_dim1];
    /* L80: */
		        }
    /* L90: */
		    }

	        } else if (lsame(side, 'R')) {

    /*              Form  C * H  or  C * H'  where  C = ( C1  C2 ) */

    /*              W := C * V  =  (C1*V1 + C2*V2)  (stored in WORK) */

    /*              W := C2 */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(m, &c__[(n - k + j) * c_dim1 + 1], c__1, &work[
			        j * work_dim1 + 1], c__1);
    /* L100: */
		    }

    /*              W := W * V2 */

		    dtrmm('R', 'U', 'N', 'U', m, k, c_b14, 
			     &v[n - k + 1 + v_dim1], ldv, &work[work_offset], 
			    ldwork);
		    if (n > k) {

    /*                 W := W + C1 * V1 */

		        i__1 = n - k;
		        dgemm('N', 'N', m, k, i__1, 
			        c_b14, &c__[c_offset], ldc, &v[v_offset], ldv, 
			        c_b14, &work[work_offset], ldwork);
		    }

    /*              W := W * T  or  W * T' */

		    dtrmm('R', 'L', trans, 'N', m, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - W * V' */

		    if (n > k) {

    /*                 C1 := C1 - W * V1' */

		        i__1 = n - k;
		        dgemm('N', 'T', m, i__1, k, c_b25, &
			        work[work_offset], ldwork, &v[v_offset], ldv, 
			        c_b14, &c__[c_offset], ldc)
			        ;
		    }

    /*              W := W * V2' */

		    dtrmm('R', 'U', 'T', 'U', m, k, c_b14, &
			    v[n - k + 1 + v_dim1], ldv, &work[work_offset], 
			    ldwork);

    /*              C2 := C2 - W */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + (n - k + j) * c_dim1] -= work[i__ + j * 
				    work_dim1];
    /* L110: */
		        }
    /* L120: */
		    }
	        }
	    }

        } else if (lsame(storev, 'R')) {

	    if (lsame(direct, 'F')) {

    /*           Let  V =  ( V1  V2 )    (V1: first K columns) */
    /*           where  V1  is unit upper triangular. */

	        if (lsame(side, 'L')) {

    /*              Form  H * C  or  H' * C  where  C = ( C1 ) */
    /*                                                  ( C2 ) */

    /*              W := C' * V'  =  (C1'*V1' + C2'*V2') (stored in WORK) */

    /*              W := C1' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(n, &c__[j + c_dim1], ldc, &work[j * work_dim1 + 1], 
			         c__1);
    /* L130: */
		    }

    /*              W := W * V1' */

		    dtrmm('R', 'U', 'T', 'U', n, k, c_b14, &
			    v[v_offset], ldv, &work[work_offset], ldwork);
		    if (m > k) {

    /*                 W := W + C2'*V2' */

		        i__1 = m - k;
		        dgemm('T', 'T', n, k, i__1, c_b14, &
			        c__[k + 1 + c_dim1], ldc, &v[(k + 1) * v_dim1 + 
			        1], ldv, c_b14, &work[work_offset], ldwork);
		    }

    /*              W := W * T'  or  W * T */

		    dtrmm('R', 'U', transt, 'N', n, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - V' * W' */

		    if (m > k) {

    /*                 C2 := C2 - V2' * W' */

		        i__1 = m - k;
		        dgemm('T', 'T', i__1, n, k, c_b25, &v[(
			        k + 1) * v_dim1 + 1], ldv, &work[work_offset], 
			        ldwork, c_b14, &c__[k + 1 + c_dim1], ldc);
		    }

    /*              W := W * V1 */

		    dtrmm('R', 'U', 'N', 'U', n, k, c_b14, 
			     &v[v_offset], ldv, &work[work_offset], ldwork);

    /*              C1 := C1 - W' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[j + i__ * c_dim1] -= work[i__ + j * work_dim1];
    /* L140: */
		        }
    /* L150: */
		    }

	        } else if (lsame(side, 'R')) {

    /*              Form  C * H  or  C * H'  where  C = ( C1  C2 ) */

    /*              W := C * V'  =  (C1*V1' + C2*V2')  (stored in WORK) */

    /*              W := C1 */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(m, &c__[j * c_dim1 + 1], c__1, &work[j * 
			        work_dim1 + 1], c__1);
    /* L160: */
		    }

    /*              W := W * V1' */

		    dtrmm('R', 'U', 'T', 'U', m, k, c_b14, &
			    v[v_offset], ldv, &work[work_offset], ldwork);
		    if (n > k) {

    /*                 W := W + C2 * V2' */

		        i__1 = n - k;
		        dgemm('N', 'T', m, k, i__1, c_b14, &
			        c__[(k + 1) * c_dim1 + 1], ldc, &v[(k + 1) * 
			        v_dim1 + 1], ldv, c_b14, &work[work_offset], 
			        ldwork);
		    }

    /*              W := W * T  or  W * T' */

		    dtrmm('R', 'U', trans, 'N', m, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - W * V */

		    if (n > k) {

    /*                 C2 := C2 - W * V2 */

		        i__1 = n - k;
		        dgemm('N', 'N', m, i__1, k, 
			        c_b25, &work[work_offset], ldwork, &v[(k + 1) * 
			        v_dim1 + 1], ldv, c_b14, &c__[(k + 1) * c_dim1 
			        + 1], ldc);
		    }

    /*              W := W * V1 */

		    dtrmm('R', 'U', 'N', 'U', m, k, c_b14, 
			     &v[v_offset], ldv, &work[work_offset], ldwork);

    /*              C1 := C1 - W */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + j * c_dim1] -= work[i__ + j * work_dim1];
    /* L170: */
		        }
    /* L180: */
		    }

	        }

	    } else {

    /*           Let  V =  ( V1  V2 )    (V2: last K columns) */
    /*           where  V2  is unit lower triangular. */

	        if (lsame(side, 'L')) {

    /*              Form  H * C  or  H' * C  where  C = ( C1 ) */
    /*                                                  ( C2 ) */

    /*              W := C' * V'  =  (C1'*V1' + C2'*V2') (stored in WORK) */

    /*              W := C2' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(n, &c__[m - k + j + c_dim1], ldc, &work[j * 
			        work_dim1 + 1], c__1);
    /* L190: */
		    }

    /*              W := W * V2' */

		    dtrmm('R', 'L', 'T', 'U', n, k, c_b14, &
			    v[(m - k + 1) * v_dim1 + 1], ldv, &work[work_offset]
    , ldwork);
		    if (m > k) {

    /*                 W := W + C1'*V1' */

		        i__1 = m - k;
		        dgemm('T', 'T', n, k, i__1, c_b14, &
			        c__[c_offset], ldc, &v[v_offset], ldv, c_b14, &
			        work[work_offset], ldwork);
		    }

    /*              W := W * T'  or  W * T */

		    dtrmm('R', 'L', transt, 'N', n, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - V' * W' */

		    if (m > k) {

    /*                 C1 := C1 - V1' * W' */

		        i__1 = m - k;
		        dgemm('T', 'T', i__1, n, k, c_b25, &v[
			        v_offset], ldv, &work[work_offset], ldwork, 
			        c_b14, &c__[c_offset], ldc);
		    }

    /*              W := W * V2 */

		    dtrmm('R', 'L', 'N', 'U', n, k, c_b14, 
			     &v[(m - k + 1) * v_dim1 + 1], ldv, &work[
			    work_offset], ldwork);

    /*              C2 := C2 - W' */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = n;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[m - k + j + i__ * c_dim1] -= work[i__ + j * 
				    work_dim1];
    /* L200: */
		        }
    /* L210: */
		    }

	        } else if (lsame(side, 'R')) {

    /*              Form  C * H  or  C * H'  where  C = ( C1  C2 ) */

    /*              W := C * V'  =  (C1*V1' + C2*V2')  (stored in WORK) */

    /*              W := C2 */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        dcopy(m, &c__[(n - k + j) * c_dim1 + 1], c__1, &work[
			        j * work_dim1 + 1], c__1);
    /* L220: */
		    }

    /*              W := W * V2' */

		    dtrmm('R', 'L', 'T', 'U', m, k, c_b14, &
			    v[(n - k + 1) * v_dim1 + 1], ldv, &work[work_offset]
    , ldwork);
		    if (n > k) {

    /*                 W := W + C1 * V1' */

		        i__1 = n - k;
		        dgemm('N', 'T', m, k, i__1, c_b14, &
			        c__[c_offset], ldc, &v[v_offset], ldv, c_b14, &
			        work[work_offset], ldwork);
		    }

    /*              W := W * T  or  W * T' */

		    dtrmm('R', 'L', trans, 'N', m, k, c_b14, &t[
			    t_offset], ldt, &work[work_offset], ldwork);

    /*              C := C - W * V */

		    if (n > k) {

    /*                 C1 := C1 - W * V1 */

		        i__1 = n - k;
		        dgemm('N', 'N', m, i__1, k, 
			        c_b25, &work[work_offset], ldwork, &v[v_offset], 
			        ldv, c_b14, &c__[c_offset], ldc);
		    }

    /*              W := W * V2 */

		    dtrmm('R', 'L', 'N', 'U', m, k, c_b14, 
			     &v[(n - k + 1) * v_dim1 + 1], ldv, &work[
			    work_offset], ldwork);

    /*              C1 := C1 - W */

		    i__1 = k;
		    for (j = 1; j <= i__1; ++j) {
		        i__2 = m;
		        for (i__ = 1; i__ <= i__2; ++i__) {
			    c__[i__ + (n - k + j) * c_dim1] -= work[i__ + j * 
				    work_dim1];
    /* L230: */
		        }
    /* L240: */
		    }

	        }

	    }
        }

        return 0;
    } 
}

