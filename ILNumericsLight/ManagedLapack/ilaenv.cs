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
    public static int ilaenv(int ispec, string name__, string opts, int n1, int n2, int n3, int n4)
    {
        // System generated locals
        int ret_val;

        // Local variables
        char c1;
        string c2, c3, c4;
        int nb, nx;
        bool cname;
        int nbmin;
        bool sname;
        string subnam;

        switch (ispec)
        {
	        case 1:  goto L10;
	        case 2:  goto L10;
	        case 3:  goto L10;
	        case 4:  goto L80;
	        case 5:  goto L90;
	        case 6:  goto L100;
	        case 7:  goto L110;
	        case 8:  goto L120;
	        case 9:  goto L130;
	        case 10:  goto L140;
	        case 11:  goto L150;
	        case 12:  goto L160;
	        case 13:  goto L160;
	        case 14:  goto L160;
	        case 15:  goto L160;
	        case 16:  goto L160;
        }

        // Invalid value for ISPEC
        ret_val = -1;
        return ret_val;

L10:

        // Convert NAME to upper case if the first character is lower case.

        ret_val = 1;
        subnam = name__.Substring(0,6).ToUpper();

        c1 = subnam[0];
        sname = c1 == 'S' || c1 == 'D';
        cname = c1 == 'C' || c1 == 'Z';

        if (! (cname || sname)) return ret_val;

        c2 = subnam.Substring(1,2);
        c3 = subnam.Substring(3,3);
        c4 = c3.Substring(1,2);

        switch (ispec)
        {
	        case 1:  goto L50;
	        case 2:  goto L60;
	        case 3:  goto L70;
        }

L50:

        /* ISPEC = 1:  block size */

        /* In these examples, separate code is provided for setting NB for */
        /* real and complex.  We assume that NB will take the same value in */
        /* single or double precision. */

        nb = 1;

        if (c2 == "GE")
        {
	        if (c3 == "TRF")
            {
	            if (sname) nb = 64;
	            else nb = 64;
	        }
            else if (c3 == "QRF" || c3 == "RQF" || c3 == "LQF" || c3 == "QLF") 
	        {
	            if (sname) nb = 32;
	            else nb = 32;
	        }
            else if (c3 == "HRD")
            {
	            if (sname) nb = 32;
	            else nb = 32;
	        }
            else if (c3 == "BRD")
            {
	            if (sname) nb = 32;
                else nb = 32;
	        }
            else if (c3 == "TRI")
            {
	            if (sname) nb = 64;
	            else nb = 64;
	        }
        }
        else if (c2 == "PO")
        {
	        if (c3 == "TRF") {
	            if (sname) {
		        nb = 64;
	            } else {
		        nb = 64;
	            }
	        }
        }
        else if (c2 == "SY")
        {
	        if (c3 == "TRF") {
	            if (sname) {
		        nb = 64;
	            } else {
		        nb = 64;
	            }
	        } else if (sname && c3 == "TRD") {
	            nb = 32;
	        } else if (sname && c3 == "GST") {
	            nb = 64;
	        }
        }
        else if (cname && c2 == "HE")
        {
	        if (c3 == "TRF") {
	            nb = 64;
	        } else if (c3 == "TRD") {
	            nb = 32;
	        } else if (c3 == "GST") {
	            nb = 64;
	        }
        }
        else if (sname && c2 == "OR")
        {
	        if (c3[0] == 'G') {
	            if (c4 == "QR" ||c4 == "RQ" || c4 == "LQ" || c4 == "QL" || c4 == "HR" || c4 == "TR" || c4 == "BR") {
		            nb = 32;
	            }
	        } else if (c3[0] == 'M') {
	            if (c4 == "QR" || c4 == "RQ" || c4 == "LQ" || c4 == "QL" || c4 == "HR" || c4 == "TR" || c4 == "BR") {
		            nb = 32;
	            }
	        }
        }
        else if (cname && c2=="UN")
        {
	        if (c3[0] == 'G') {
	            if (c4 == "QR" || c4 == "RQ" || c4 == "LQ" || c4 == "QL" || c4 == "HR" || c4 == "TR" || c4 == "BR") {
		        nb = 32;
	            }
	        } else if (c3[0] == 'M') {
	            if (c4 == "QR" ||c4 == "RQ" || c4 == "LQ" || c4 == "QL" || c4 == "HR" || c4 == "TR" || c4 == "BR") {
		        nb = 32;
	            }
	        }
        }
        else if (c2 == "GB")
        {
	        if (c3 == "TRF") {
	            if (sname) {
		        if (n4 <= 64) {
		            nb = 1;
		        } else {
		            nb = 32;
		        }
	            } else {
		            if (n4 <= 64) {
		                nb = 1;
		            } else {
		                nb = 32;
		            }
	            }
	        }
        }
        else if (c2 == "PB")
        {
	        if (c3 == "TRF") {
	            if (sname) {
		        if (n2 <= 64) {
		            nb = 1;
		        } else {
		            nb = 32;
		        }
	            } else {
		        if (n2 <= 64) {
		            nb = 1;
		        } else {
		            nb = 32;
		        }
	            }
	        }
        }
        else if (c2 == "TR")
        {
	        if (c3 == "TRI") {
	            if (sname) {
		        nb = 64;
	            } else {
		        nb = 64;
	            }
	        }
        }
        else if (c2 == "LA")
        {
	        if (c3 == "UUM") {
	            if (sname) {
		        nb = 64;
	            } else {
		        nb = 64;
	            }
	        }
        }
        else if (sname && c2 == "ST")
        {
	        if (c3 == "EBZ") {
	            nb = 1;
	        }
        }
        ret_val = nb;
        return ret_val;

L60:

        /* ISPEC = 2:  minimum block size */

        nbmin = 2;
        if (c2 == "GE")
        {
	        if (c3 == "QRF" || c3 == "RQF" || c3 == "LQF" || c3 == "QLF")
		    {
	            if (sname) {
		        nbmin = 2;
	            } else {
		        nbmin = 2;
	            }
	        } else if (c3 == "HRD") {
	            if (sname) {
		        nbmin = 2;
	            } else {
		        nbmin = 2;
	            }
	        } else if (c3=="BRD") {
	            if (sname) {
		        nbmin = 2;
	            } else {
		        nbmin = 2;
	            }
	        } else if (c3=="TRI") {
	            if (sname) {
		        nbmin = 2;
	            } else {
		        nbmin = 2;
	            }
	        }
        }
        else if (c2=="SY")
        {
	        if (c3=="TRF") {
	            if (sname) {
		        nbmin = 8;
	            } else {
		        nbmin = 8;
	            }
	        } else if (sname && c3=="TRD") {
	            nbmin = 2;
	        }
        }
        else if (cname && c2=="HE")
        {
	        if (c3=="TRD") {
	            nbmin = 2;
	        }
        }
        else if (sname && c2=="OR")
        {
	        if (c3[0] == 'G') {
	            if (c4=="QR"|| c4=="RQ"|| c4=="LQ"|| c4== "QL" || c4=="HR" || c4=="TR" || c4=="BR") {
		        nbmin = 2;
	            }
	        } else if (c3[0] == 'M') {
	            if (c4=="QR" ||c4== "RQ"|| c4=="LQ"|| c4== "QL"|| c4=="HR" || c4== "TR" || c4=="BR") {
		        nbmin = 2;
	            }
	        }
        }
        else if (cname && c2=="UN")
        {
	        if (c3[0] == 'G') {
	            if (c4=="QR" || c4== "RQ" || c4=="LQ"|| c4=="QL" || c4=="HR" || c4=="TR" || c4=="BR") {
		        nbmin = 2;
	            }
	        } else if (c3[0] == 'M') {
	            if (c4=="QR"||c4=="RQ"||c4== "LQ"|| c4=="QL"|| c4=="HR" || c4=="TR" || c4=="BR") {
		        nbmin = 2;
	            }
	        }
        }
        ret_val = nbmin;
        return ret_val;

L70:

        /* ISPEC = 3:  crossover point */

        nx = 0;
        if (c2=="GE")
        {
	        if (c3=="QRF" || c3=="RQF"|| c3== "LQF"|| c3== "QLF")
		         {
	            if (sname) {
		        nx = 128;
	            } else {
		        nx = 128;
	            }
	        } else if (c3=="HRD") {
	            if (sname) {
		        nx = 128;
	            } else {
		        nx = 128;
	            }
	        } else if (c3=="BRD") {
	            if (sname) {
		        nx = 128;
	            } else {
		        nx = 128;
	            }
	        }
        }
        else if (c2=="SY")
        {
	        if (sname && c3=="TRD") {
	            nx = 32;
	        }
        }
        else if (cname && c2== "HE")
        {
	        if (c3=="TRD") {
	            nx = 32;
	        }
        }
        else if (sname && c2=="OR")
        {
	        if (c3[0] == 'G') {
	            if (c4== "QR"||c4=="RQ"|| c4=="LQ"|| c4== "QL" || c4=="HR" || c4== "TR" || c4=="BR") {
		        nx = 128;
	            }
	        }
        }
        else if (cname && c2=="UN")
        {
	        if (c3[0] == 'G') {
	            if (c4=="QR" || c4=="RQ" || c4=="LQ"|| c4=="QL"||c4=="HR" || c4=="TR"|| c4=="BR") {
		        nx = 128;
	            }
	        }
        }
        ret_val = nx;
        return ret_val;

L80:

        /* ISPEC = 4:  number of shifts (used by xHSEQR) */

        ret_val = 6;
        return ret_val;

L90:

        /*  ISPEC = 5:  minimum column dimension (not used) */

        ret_val = 2;
        return ret_val;

    L100:

        /* ISPEC = 6:  crossover point for SVD (used by xGELSS and xGESVD) */

        ret_val = (int)((float)min(n1, n2) * 1.6f);
        return ret_val;

L110:

        /* ISPEC = 7:  number of processors (not used) */

        ret_val = 1;
        return ret_val;

L120:

        /* ISPEC = 8:  crossover point for multishift (used by xHSEQR) */

        ret_val = 50;
        return ret_val;

L130:

        /*     ISPEC = 9:  maximum size of the subproblems at the bottom of the */
        /*                 computation tree in the divide-and-conquer algorithm */
        /*                 (used by xGELSD and xGESDD) */

        ret_val = 25;
        return ret_val;

L140:

        /*     ISPEC = 10: ieee NaN arithmetic can be trusted not to trap */

        /*     ILAENV = 0 */
        ret_val = 1;
        if (ret_val == 1) {
	    ret_val = 1;
        }
        return ret_val;

L150:

        /*     ISPEC = 11: infinity arithmetic can be trusted not to trap */

        /*     ILAENV = 0 */
        ret_val = 1;
        if (ret_val == 1) {
	    ret_val = 1;
        }
        return ret_val;

L160:

        /* 12 <= ISPEC <= 16: xHSEQR or one of its subroutines. */

        ret_val = iparmq(ispec, name__, opts, n1, n2, n3, n4);
        return ret_val;
    }
}

