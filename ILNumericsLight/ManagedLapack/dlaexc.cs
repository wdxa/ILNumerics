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
    public static unsafe int dlaexc(bool wantq, int n, double *t, int ldt,
        double *q, int ldq, int j1, int n1, int n2, double *work, ref int info)
    {
        /* Table of constant values */

        const int c__1 = 1;
        const int c__4 = 4;
        const bool c_false = false;
        const int c_n1 = -1;
        const int c__2 = 2;
        const int c__3 = 3;

        /* System generated locals */
        int q_dim1, q_offset, t_dim1, t_offset, i__1;
        double d__1, d__2, d__3;

        /* Local variables */
        double* d__ = stackalloc double[16];
        int k;
        double* u = stackalloc double[3];
        double* x = stackalloc double[4]	/* was [2][2] */;
        int j2, j3, j4;
        double* u1 = stackalloc double[3];
        double* u2 = stackalloc double[3];
        int nd;
        double cs=0, t11, t22, t33, sn=0, wi1=0, wi2=0, wr1=0, wr2=0, eps, tau=0, tau1=0, tau2=0;
        int ierr=0;
        double temp=0;
        double scale=0, dnorm, xnorm=0;
        double thresh, smlnum;

        /* Parameter adjustments */
        t_dim1 = ldt;
        t_offset = 1 + t_dim1;
        t -= t_offset;
        q_dim1 = ldq;
        q_offset = 1 + q_dim1;
        q -= q_offset;
        --work;

        /* Function Body */
        info = 0;

    /*     Quick return if possible */

        if (n == 0 || n1 == 0 || n2 == 0) {
	    return 0;
        }
        if (j1 + n1 > n) {
	    return 0;
        }

        j2 = j1 + 1;
        j3 = j1 + 2;
        j4 = j1 + 3;

        if (n1 == 1 && n2 == 1) {

    /*        Swap two 1-by-1 blocks. */

	    t11 = t[j1 + j1 * t_dim1];
	    t22 = t[j2 + j2 * t_dim1];

    /*        Determine the transformation to perform the interchange. */

	    d__1 = t22 - t11;
	    dlartg(t[j1 + j2 * t_dim1], d__1, ref cs, ref sn, ref temp);

    /*        Apply transformation to the matrix T. */

	    if (j3 <= n) {
	        i__1 = n - j1 - 1;
	        drot(i__1, &t[j1 + j3 * t_dim1], ldt, &t[j2 + j3 * t_dim1], 
		        ldt, cs, sn);
	    }
	    i__1 = j1 - 1;
	    drot(i__1, &t[j1 * t_dim1 + 1], c__1, &t[j2 * t_dim1 + 1], c__1, 
		    cs, sn);

	    t[j1 + j1 * t_dim1] = t22;
	    t[j2 + j2 * t_dim1] = t11;

	    if (wantq) {

    /*           Accumulate transformation in the matrix Q. */

	        drot(n, &q[j1 * q_dim1 + 1], c__1, &q[j2 * q_dim1 + 1], c__1, 
		        cs, sn);
	    }

        } else {

    /*        Swapping involves at least one 2-by-2 block. */

    /*        Copy the diagonal block of order N1+N2 to the local array D */
    /*        and compute its norm. */

	    nd = n1 + n2;
	    dlacpy('F', nd, nd, &t[j1 + j1 * t_dim1], ldt, d__, c__4);
	    dnorm = dlange('M', nd, nd, d__, c__4, &work[1]);

    /*        Compute machine-dependent threshold for test for accepting */
    /*        swap. */

	    eps = dlamch('P');
	    smlnum = dlamch('S') / eps;
    /* Computing MAX */
	    d__1 = eps * 10.0 * dnorm;
	    thresh = max(d__1,smlnum);

    /*        Solve T11*X - X*T22 = scale*T12 for X. */

	    dlasy2(c_false, c_false, c_n1, n1, n2, d__, c__4, &d__[n1 + 1 + 
		    (n1 + 1 << 2) - 5], c__4, &d__[(n1 + 1 << 2) - 4], c__4, 
		    ref scale, x, c__2, ref xnorm, ref ierr);

    /*        Swap the adjacent diagonal blocks. */

	    k = n1 + n1 + n2 - 3;
	    switch (k) {
	        case 1:  goto L10;
	        case 2:  goto L20;
	        case 3:  goto L30;
	    }

    L10:

    /*        N1 = 1, N2 = 2: generate elementary reflector H so that: */

    /*        ( scale, X11, X12 ) H = ( 0, 0, * ) */

	    u[0] = scale;
	    u[1] = x[0];
	    u[2] = x[2];
	    dlarfg(c__3, ref u[2], u, c__1, ref tau);
	    u[2] = 1.0;
	    t11 = t[j1 + j1 * t_dim1];

    /*        Perform swap provisionally on diagonal block in D. */

	    dlarfx('L', c__3, c__3, u, tau, d__, c__4, &work[1]);
	    dlarfx('R', c__3, c__3, u, tau, d__, c__4, &work[1]);

    /*        Test whether to reject swap. */

    /* Computing MAX */
	    d__2 = abs(d__[2]);
        d__3 = abs(d__[6]);
        d__2 = max(d__2,d__3);
        d__1 = d__[10] - t11;
        d__3 = ( abs(d__1));
	    if (max(d__2,d__3) > thresh) {
	        goto L50;
	    }

    /*        Accept swap: apply transformation to the entire matrix T. */

	    i__1 = n - j1 + 1;
	    dlarfx('L', c__3, i__1, u, tau, &t[j1 + j1 * t_dim1], ldt, &
		    work[1]);
	    dlarfx('R', j2, c__3, u, tau, &t[j1 * t_dim1 + 1], ldt, &work[1]);

	    t[j3 + j1 * t_dim1] = 0.0;
	    t[j3 + j2 * t_dim1] = 0.0;
	    t[j3 + j3 * t_dim1] = t11;

	    if (wantq) {

    /*           Accumulate transformation in the matrix Q. */

	        dlarfx('R', n, c__3, u, tau, &q[j1 * q_dim1 + 1], ldq, &work[
		        1]);
	    }
	    goto L40;

    L20:

    /*        N1 = 2, N2 = 1: generate elementary reflector H so that: */

    /*        H (  -X11 ) = ( * ) */
    /*          (  -X21 ) = ( 0 ) */
    /*          ( scale ) = ( 0 ) */

	    u[0] = -x[0];
	    u[1] = -x[1];
	    u[2] = scale;
	    dlarfg(c__3, ref u[0], &u[1], c__1, ref tau);
	    u[0] = 1.0;
	    t33 = t[j3 + j3 * t_dim1];

    /*        Perform swap provisionally on diagonal block in D. */

	    dlarfx('L', c__3, c__3, u, tau, d__, c__4, &work[1]);
	    dlarfx('R', c__3, c__3, u, tau, d__, c__4, &work[1]);

    /*        Test whether to reject swap. */

    /* Computing MAX */
	    d__2 = abs(d__[1]); d__3 = abs(d__[2]); d__2 = max(d__2,d__3);
        d__1 = d__[0] - t33;
        d__3 = ( abs(d__1));
	    if (max(d__2,d__3) > thresh) {
	        goto L50;
	    }

    /*        Accept swap: apply transformation to the entire matrix T. */

	    dlarfx('R', j3, c__3, u, tau, &t[j1 * t_dim1 + 1], ldt, &work[1]);
	    i__1 = n - j1;
	    dlarfx('L', c__3, i__1, u, tau, &t[j1 + j2 * t_dim1], ldt, &work[
		    1]);

	    t[j1 + j1 * t_dim1] = t33;
	    t[j2 + j1 * t_dim1] = 0.0;
	    t[j3 + j1 * t_dim1] = 0.0;

	    if (wantq) {

    /*           Accumulate transformation in the matrix Q. */

	        dlarfx('R', n, c__3, u, tau, &q[j1 * q_dim1 + 1], ldq, &work[
		        1]);
	    }
	    goto L40;

    L30:

    /*        N1 = 2, N2 = 2: generate elementary reflectors H(1) and H(2) so */
    /*        that: */

    /*        H(2) H(1) (  -X11  -X12 ) = (  *  * ) */
    /*                  (  -X21  -X22 )   (  0  * ) */
    /*                  ( scale    0  )   (  0  0 ) */
    /*                  (    0  scale )   (  0  0 ) */

	    u1[0] = -x[0];
	    u1[1] = -x[1];
	    u1[2] = scale;
	    dlarfg(c__3, ref u1[0], &u1[1], c__1, ref tau1);
	    u1[0] = 1.0;

	    temp = -tau1 * (x[2] + u1[1] * x[3]);
	    u2[0] = -temp * u1[1] - x[3];
	    u2[1] = -temp * u1[2];
	    u2[2] = scale;
	    dlarfg(c__3, ref u2[0], &u2[1], c__1, ref tau2);
	    u2[0] = 1.0;

    /*        Perform swap provisionally on diagonal block in D. */

	    dlarfx('L', c__3, c__4, u1, tau1, d__, c__4, &work[1])
		    ;
	    dlarfx('R', c__4, c__3, u1, tau1, d__, c__4, &work[1])
		    ;
	    dlarfx('L', c__3, c__4, u2, tau2, &d__[1], c__4, &work[1]);
	    dlarfx('R', c__4, c__3, u2, tau2, &d__[4], c__4, &work[1]);

    /*        Test whether to reject swap. */

    /* Computing MAX */
	    d__1 = abs(d__[2]); d__2 = abs(d__[6]); d__1 = max(d__1,d__2); d__2 = 
		    abs(d__[3]); d__1 = max(d__1,d__2); d__2 = abs(d__[7]);
	    if (max(d__1,d__2) > thresh) {
	        goto L50;
	    }

    /*        Accept swap: apply transformation to the entire matrix T. */

	    i__1 = n - j1 + 1;
	    dlarfx('L', c__3, i__1, u1, tau1, &t[j1 + j1 * t_dim1], ldt, &
		    work[1]);
	    dlarfx('R', j4, c__3, u1, tau1, &t[j1 * t_dim1 + 1], ldt, &work[
		    1]);
	    i__1 = n - j1 + 1;
	    dlarfx('L', c__3, i__1, u2, tau2, &t[j2 + j1 * t_dim1], ldt, &
		    work[1]);
	    dlarfx('R', j4, c__3, u2, tau2, &t[j2 * t_dim1 + 1], ldt, &work[1]
    );

	    t[j3 + j1 * t_dim1] = 0.0;
	    t[j3 + j2 * t_dim1] = 0.0;
	    t[j4 + j1 * t_dim1] = 0.0;
	    t[j4 + j2 * t_dim1] = 0.0;

	    if (wantq) {

    /*           Accumulate transformation in the matrix Q. */

	        dlarfx('R', n, c__3, u1, tau1, &q[j1 * q_dim1 + 1], ldq, &
		        work[1]);
	        dlarfx('R', n, c__3, u2, tau2, &q[j2 * q_dim1 + 1], ldq, &work[
		        1]);
	    }

    L40:

	    if (n2 == 2) {

    /*           Standardize new 2-by-2 block T11 */

	        dlanv2(ref t[j1 + j1 * t_dim1], ref t[j1 + j2 * t_dim1], ref t[j2 + 
		        j1 * t_dim1], ref t[j2 + j2 * t_dim1], ref wr1, ref wi1, ref wr2, ref
		        wi2, ref cs, ref sn);
	        i__1 = n - j1 - 1;
	        drot(i__1, &t[j1 + (j1 + 2) * t_dim1], ldt, &t[j2 + (j1 + 2) 
		        * t_dim1], ldt, cs, sn);
	        i__1 = j1 - 1;
	        drot(i__1, &t[j1 * t_dim1 + 1], c__1, &t[j2 * t_dim1 + 1], 
		        c__1, cs, sn);
	        if (wantq) {
		    drot(n, &q[j1 * q_dim1 + 1], c__1, &q[j2 * q_dim1 + 1], 
			    c__1, cs, sn);
	        }
	    }

	    if (n1 == 2) {

    /*           Standardize new 2-by-2 block T22 */

	        j3 = j1 + n2;
	        j4 = j3 + 1;
	        dlanv2(ref t[j3 + j3 * t_dim1], ref t[j3 + j4 * t_dim1], ref t[j4 + j3 * 
		        t_dim1], ref t[j4 + j4 * t_dim1], ref wr1, ref wi1, ref wr2, ref wi2, ref
		        cs, ref sn);
	        if (j3 + 2 <= n) {
		    i__1 = n - j3 - 1;
		    drot(i__1, &t[j3 + (j3 + 2) * t_dim1], ldt, &t[j4 + (j3 + 2)
			     * t_dim1], ldt, cs, sn);
	        }
	        i__1 = j3 - 1;
	        drot(i__1, &t[j3 * t_dim1 + 1], c__1, &t[j4 * t_dim1 + 1], 
		        c__1, cs, sn);
	        if (wantq) {
		    drot(n, &q[j3 * q_dim1 + 1], c__1, &q[j4 * q_dim1 + 1], 
			    c__1, cs, sn);
	        }
	    }

        }
        return 0;

    /*     Exit with INFO = 1 if swap was rejected. */

    L50:
        info = 1;
        return 0;
    }
}

