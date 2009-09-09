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
    public static unsafe int dtrexc(char compq, int n, double* t, int ldt, double* q, int ldq, ref int ifst, ref int ilst, double* work, ref int info)
    {
        /* Table of constant values */
        const int c__1 = 1;
        const int c__2 = 2;

        /* System generated locals */
        int q_dim1, q_offset, t_dim1, t_offset, i__1;

        /* Local variables */
        int nbf, nbl, here;
        bool wantq;
        int nbnext;

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
        wantq = lsame(compq, 'V');
        if (! wantq && ! lsame(compq, 'N')) {
	    info = -1;
        } else if (n < 0) {
	    info = -2;
        } else if (ldt < max(1,n)) {
	    info = -4;
        } else if (ldq < 1 || wantq && ldq < max(1,n)) {
	    info = -6;
        } else if (ifst < 1 || ifst > n) {
	    info = -7;
        } else if (ilst < 1 || ilst > n) {
	    info = -8;
        }
        if (info != 0) {
	    i__1 = -(info);
	    xerbla("DTREXC", i__1);
	    return 0;
        }

    /*     Quick return if possible */

        if (n <= 1) {
	    return 0;
        }

    /*     Determine the first row of specified block */
    /*     and find out it is 1 by 1 or 2 by 2. */

        if (ifst > 1) {
	    if (t[ifst + (ifst - 1) * t_dim1] != 0.00) {
	        --(ifst);
	    }
        }
        nbf = 1;
        if (ifst < n) {
	    if (t[ifst + 1 + ifst * t_dim1] != 0.00) {
	        nbf = 2;
	    }
        }

    /*     Determine the first row of the final block */
    /*     and find out it is 1 by 1 or 2 by 2. */

        if (ilst > 1) {
	    if (t[ilst + (ilst - 1) * t_dim1] != 0.00) {
	        --(ilst);
	    }
        }
        nbl = 1;
        if (ilst < n) {
	    if (t[ilst + 1 + ilst * t_dim1] != 0.00) {
	        nbl = 2;
	    }
        }

        if (ifst == ilst) {
	    return 0;
        }

        if (ifst < ilst) {

    /*        Update ILST */

	    if (nbf == 2 && nbl == 1) {
	        --(ilst);
	    }
	    if (nbf == 1 && nbl == 2) {
	        ++(ilst);
	    }

	    here = ifst;

    L10:

    /*        Swap block with next one below */

	    if (nbf == 1 || nbf == 2) {

    /*           Current block either 1 by 1 or 2 by 2 */

	        nbnext = 1;
	        if (here + nbf + 1 <= n) {
		    if (t[here + nbf + 1 + (here + nbf) * t_dim1] != 0.00) {
		        nbnext = 2;
		    }
	        }
	        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, here, 
		        nbf, nbnext, &work[1], ref info);
	        if (info != 0) {
		    ilst = here;
		    return 0;
	        }
	        here += nbnext;

    /*           Test if 2 by 2 block breaks into two 1 by 1 blocks */

	        if (nbf == 2) {
		    if (t[here + 1 + here * t_dim1] == 0.0) {
		        nbf = 3;
		    }
	        }

	    } else {

    /*           Current block consists of two 1 by 1 blocks each of which */
    /*           must be swapped individually */

	        nbnext = 1;
	        if (here + 3 <= n) {
		    if (t[here + 3 + (here + 2) * t_dim1] != 0.0) {
		        nbnext = 2;
		    }
	        }
	        i__1 = here + 1;
	        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, i__1, 
		        c__1, nbnext, &work[1], ref info);
	        if (info != 0) {
		    ilst = here;
		    return 0;
	        }
	        if (nbnext == 1) {

    /*              Swap two 1 by 1 blocks, no problems possible */

		    dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			    here, c__1, nbnext, &work[1], ref info);
		    ++here;
	        } else {

    /*              Recompute NBNEXT in case 2 by 2 split */

		    if (t[here + 2 + (here + 1) * t_dim1] == 0.00) {
		        nbnext = 1;
		    }
		    if (nbnext == 2) {

    /*                 2 by 2 Block did not split */

		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        here, c__1, nbnext, &work[1], ref info);
		        if (info != 0) {
			    ilst = here;
			    return 0;
		        }
		        here += 2;
		    } else {

    /*                 2 by 2 Block did split */

		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        here, c__1, c__1, &work[1], ref info);
		        i__1 = here + 1;
		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        i__1, c__1, c__1, &work[1], ref info);
		        here += 2;
		    }
	        }
	    }
	    if (here < ilst) {
	        goto L10;
	    }

        } else {

	    here = ifst;
    L20:

    /*        Swap block with next one above */

	    if (nbf == 1 || nbf == 2) {

    /*           Current block either 1 by 1 or 2 by 2 */

	        nbnext = 1;
	        if (here >= 3) {
		    if (t[here - 1 + (here - 2) * t_dim1] != 0.0) {
		        nbnext = 2;
		    }
	        }
	        i__1 = here - nbnext;
	        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, i__1, 
		        nbnext, nbf, &work[1], ref info);
	        if (info != 0) {
		    ilst = here;
		    return 0;
	        }
	        here -= nbnext;

    /*           Test if 2 by 2 block breaks into two 1 by 1 blocks */

	        if (nbf == 2) {
		    if (t[here + 1 + here * t_dim1] == 0.0) {
		        nbf = 3;
		    }
	        }

	    } else {

    /*           Current block consists of two 1 by 1 blocks each of which */
    /*           must be swapped individually */

	        nbnext = 1;
	        if (here >= 3) {
		    if (t[here - 1 + (here - 2) * t_dim1] != 0.0) {
		        nbnext = 2;
		    }
	        }
	        i__1 = here - nbnext;
	        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, i__1, 
		        nbnext, c__1, &work[1], ref info);
	        if (info != 0) {
		    ilst = here;
		    return 0;
	        }
	        if (nbnext == 1) {

    /*              Swap two 1 by 1 blocks, no problems possible */

		    dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			    here, nbnext, c__1, &work[1], ref info);
		    --here;
	        } else {

    /*              Recompute NBNEXT in case 2 by 2 split */

		    if (t[here + (here - 1) * t_dim1] == 0.0) {
		        nbnext = 1;
		    }
		    if (nbnext == 2) {

    /*                 2 by 2 Block did not split */

		        i__1 = here - 1;
		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        i__1, c__2, c__1, &work[1], ref info);
		        if (info != 0) {
			    ilst = here;
			    return 0;
		        }
		        here += -2;
		    } else {

    /*                 2 by 2 Block did split */

		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        here, c__1, c__1, &work[1], ref info);
		        i__1 = here - 1;
		        dlaexc(wantq, n, &t[t_offset], ldt, &q[q_offset], ldq, 
			        i__1, c__1, c__1, &work[1], ref info);
		        here += -2;
		    }
	        }
	    }
	    if (here > ilst) {
	        goto L20;
	    }
        }
        ilst = here;

        return 0;
    }
}

