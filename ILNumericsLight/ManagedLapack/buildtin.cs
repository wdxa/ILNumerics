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

using System;

public partial class ManagedLapack
{
    private static double abs(double x)
    {
        return Math.Abs(x);
    }

    public static double d_lg10(double x)
    {
        return Math.Log10(x);
    }

    private static double d_sign(double a, double b)
    {
        double x = (a >= 0 ? a : -a);
        return (b >= 0 ? x : -x);
    }

    private static double floor(double x)
    {
        return Math.Floor(x);
    }

    private static int i_dnnt(double x)
    {
        return (int)(x >= 0.0 ? floor(x + 0.5) : -floor(0.5 - x));
    }

    private static int i_nint(float x)
    {
        return (int)(x >= 0 ? floor(x + 0.5) : -floor(0.5 - x));
    }

    public static double log(double x)
    {
        return Math.Log(x);
    }

    public static float log(float x)
    {
        return (float)Math.Log(x);
    }

    private static double max(double a, double b)
    {
        return Math.Max(a, b);
    }

    private static int max(int a, int b)
    {
        return (int)Math.Max(a, b);
    }

    private static double min(double a, double b)
    {
        return Math.Min(a, b);
    }

    private static int min(int a, int b)
    {
        return (int)Math.Min(a, b);
    }

    private static double pow_dd(double a, double b)
    {
        return Math.Pow(a, b);
    }

    private static double pow_di(double a, int b)
    {
        return Math.Pow(a, b);
    }

    private static int pow_ii(int a, int b)
    {
    	return (int)Math.Pow(a, b);
    }

    //private static string s_cat(string[] strs2cat)
    //{
    //    string s = "";

    //    for (int i = 0; i < strs2cat.Length; i++)
    //        s += strs2cat[i];

    //    return s;
    //}

    private static int s_cmp(string a, string b)
    {
        return a.CompareTo(b);
	}

    private static double sqrt(double x)
    {
        return Math.Sqrt(x);
    }
}

