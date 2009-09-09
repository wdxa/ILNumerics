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
    public static unsafe int dlaqr1(int n, double* h__, int ldh, double sr1, double si1, double sr2, double si2, double* v)
    {
        /* System generated locals */
        int h_dim1, h_offset;
        double d__1, d__2, d__3;

        /* Local variables */
        double s, h21s, h31s;

        /* Parameter adjustments */
        h_dim1 = ldh;
        h_offset = 1 + h_dim1;
        h__ -= h_offset;
        --v;

        /* Function Body */
        if (n == 2) {
        d__1 = h__[h_dim1 + 1] - sr2;
        d__2 = h__[h_dim1 + 2];
	    s = (abs(d__1)) + abs(si2) + (abs(d__2));
	    if (s == 0.0) {
	        v[1] = 0.0;
	        v[2] = 0.0;
	    } else {
	        h21s = h__[h_dim1 + 2] / s;
	        v[1] = h21s * h__[(h_dim1 << 1) + 1] + (h__[h_dim1 + 1] - sr1) * 
		        ((h__[h_dim1 + 1] - sr2) / s) - sr1 * (si2 / s);
	        v[2] = h21s * (h__[h_dim1 + 1] + h__[(h_dim1 << 1) + 2] - sr1 - 
		        sr2);
	    }
        } else {
        d__1 = h__[h_dim1 + 1] - sr2;
        d__2 = h__[h_dim1 + 2];
        d__3 = h__[h_dim1 + 3];
	    s = (abs(d__1)) + abs(si2) + (abs(d__2)) + (abs(d__3));
	    if (s == 0.0) {
	        v[1] = 0.0;
	        v[2] = 0.0;
	        v[3] = 0.0;
	    } else {
	        h21s = h__[h_dim1 + 2] / s;
	        h31s = h__[h_dim1 + 3] / s;
	        v[1] = (h__[h_dim1 + 1] - sr1) * ((h__[h_dim1 + 1] - sr2) / s) 
		        - sr1 * (si2 / s) + h__[(h_dim1 << 1) + 1] * h21s + h__[
		        h_dim1 * 3 + 1] * h31s;
	        v[2] = h21s * (h__[h_dim1 + 1] + h__[(h_dim1 << 1) + 2] - sr1 - 
		        sr2) + h__[h_dim1 * 3 + 2] * h31s;
	        v[3] = h31s * (h__[h_dim1 + 1] + h__[h_dim1 * 3 + 3] - sr1 - 
		        sr2) + h21s * h__[(h_dim1 << 1) + 3];
	    }
        }
        return 0;
    }
}

