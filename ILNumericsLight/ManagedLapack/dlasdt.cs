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
    public static unsafe int dlasdt(int n, ref int lvl, ref int nd, int* inode, int* ndiml, int* ndimr, int msub)
    {
        /* System generated locals */
        int i__1, i__2;

        /* Local variables */
        int i__, il, ir, maxn;
        double temp;
        int nlvl, llst, ncrnt;
         
    /*     Find the number of levels on the tree. */

        /* Parameter adjustments */
        --ndimr;
        --ndiml;
        --inode;

        /* Function Body */
        maxn = max(1,n);
        temp = log((double) maxn / (double) (msub + 1)) / log(2.0);
        lvl = (int) temp + 1;

        i__ = n / 2;
        inode[1] = i__ + 1;
        ndiml[1] = i__;
        ndimr[1] = n - i__ - 1;
        il = 0;
        ir = 1;
        llst = 1;
        i__1 = lvl - 1;
        for (nlvl = 1; nlvl <= i__1; ++nlvl) {

    /*        Constructing the tree at (NLVL+1)-st level. The number of */
    /*        nodes created on this level is LLST * 2.0 */

	    i__2 = llst - 1;
	    for (i__ = 0; i__ <= i__2; ++i__) {
	        il += 2;
	        ir += 2;
	        ncrnt = llst + i__;
	        ndiml[il] = ndiml[ncrnt] / 2;
	        ndimr[il] = ndiml[ncrnt] - ndiml[il] - 1;
	        inode[il] = inode[ncrnt] - ndimr[il] - 1;
	        ndiml[ir] = ndimr[ncrnt] / 2;
	        ndimr[ir] = ndimr[ncrnt] - ndiml[ir] - 1;
	        inode[ir] = inode[ncrnt] + ndiml[ir] + 1;
    /* L10: */
	    }
	    llst <<= 1;
    /* L20: */
        }
        nd = (llst << 1) - 1;

        return 0;
    } 
}

