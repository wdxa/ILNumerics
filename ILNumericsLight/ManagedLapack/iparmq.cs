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
    public static int iparmq(int ispec, string name__, string opts, int n, int ilo, int ihi, int lwork)
    {
        // System generated locals
        int ret_val, i__1, i__2;
        float r__1;

        // Local variables
        int nh = 0, ns = 0;

        // .. Executable Statements ..
        if (ispec == 15 || ispec == 13 || ispec == 16)
        { // ==== Set the number simultaneous shifts ==== 

	        nh = ihi - ilo + 1;
	        ns = 2;

	        if (nh >= 30) {
	            ns = 4;
	        }
	        if (nh >= 60) {
	            ns = 10;
	        }
	        if (nh >= 150)
            { // Computing MAX

	            r__1 = log(nh) / log(2);
	            i__1 = 10;
                i__2 = nh / i_nint(r__1);
	            ns = max(i__1, i__2);
	        }
	        if (nh >= 590) {
	            ns = 64;
	        }
	        if (nh >= 3000) {
	            ns = 128;
	        }
	        if (nh >= 6000) {
	            ns = 256;
	        }
            // Computing MAX
            i__1 = 2;
            i__2 = ns - ns % 2;
            ns = max(i__1, i__2);
        }

        if (ispec == 12)
        {
            // ===== Matrices of order smaller than NMIN get sent to xLAHQR,
               // the classic double shift algorithm. This must be at least 11. ====

	        ret_val = 75;
        }
        else if (ispec == 14)
        {
            // ==== INIBL: skip a multi-shift qr iteration and whenever aggressive early
                // deflation finds at least (NIBBLE*(window size)/100) deflations. ====

	        ret_val = 14;

        }
        else if (ispec == 15)
        {
            // ==== NSHFTS: The number of simultaneous shifts =====

	        ret_val = ns;
        }
        else if (ispec == 13)
        {
            // ==== NW: deflation window size.  ====

	        if (nh <= 500) ret_val = ns;
            else ret_val = ns * 3 / 2;
        }
        else if (ispec == 16)
        {

           // ==== IACC22: Whether to accumulate reflections
           //      before updating the far-from-diagonal elements
           //      and whether to use 2-by-2 block structure while
           //      doing it.  A small amount of work could be saved
           //      by making this choice dependent also upon the
           //      NH=IHI-ILO+1.

	        ret_val = 0;
	        if (ns >= 14) ret_val = 1;
	        if (ns >= 14) ret_val = 2;

        }
        else
        {// ===== invalid value of ispec =====
	        ret_val = -1;
        }

        return ret_val;
    }
}

