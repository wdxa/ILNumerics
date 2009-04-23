#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using ILNumerics;
using ILNumerics.Misc;
using ILNumerics.Exceptions;

namespace ILNumerics.BuiltInFunctions
{
    public partial class ILMath
    {
        /// <summary>Find integral using Lobatto Rule</summary>
        /// <param name="f">Function to integrate. Must be of the
        /// form y = f(x) where x and y are of type "double".</param>
        /// <param name="a">Lower bound of integral</param>
        /// <param name="b">Upper bound of integral</param>
        /// <returns>Area under funciton curve with an error of +- 1e-6</returns>
        /// 
        /// <remarks>
        /// Derived from "W. Gander and W. Gautschi: Adaptive Quadrature - 
        /// Revisited, BIT Vol. 40, No. 1, March 2000, pp. 84--101. CS technical 
        /// report: Report (gzipped, 82K). Programs: adaptsim.m, adaptlob.m", which
        /// can be found at: http://www.inf.ethz.ch/personal/gander/.
        /// 
        /// The defualt error of 1e-6 was chosen in order to give results
        /// comparible in speed and precision to Matlab R2009a.
        /// </remarks>
        public static double quadl(MulticastDelegate f, double a, double b)
        {
            double tol = 1e-6; // to have the same level of precision as Matlab
            // in the future, this could be an input?
            
            double m = (a + b) / 2.0;
            double h = (b - a) / 2.0;
            double alpha = Math.Sqrt(2.0 / 3.0);
            double beta = 1.0 / Math.Sqrt(5.0);

            double c1 = 0.942882415695480;
            double c2 = 0.641853342345781;
            double c3 = 0.236383199662150;

            double y1 = (double)f.DynamicInvoke(a),
                   y2 = (double)f.DynamicInvoke(m - c1 * h),
                   y3 = (double)f.DynamicInvoke(m - alpha * h),
                   y4 = (double)f.DynamicInvoke(m - c2 * h),
                   y5 = (double)f.DynamicInvoke(m - beta * h),
                   y6 = (double)f.DynamicInvoke(m - c3 * h),
                   y7 = (double)f.DynamicInvoke(m),
                   y8 = (double)f.DynamicInvoke(m + c3 * h),
                   y9 = (double)f.DynamicInvoke(m + beta * h),
                   y10= (double)f.DynamicInvoke(m + c2 * h),
                   y11= (double)f.DynamicInvoke(m + alpha * h),
                   y12= (double)f.DynamicInvoke(m + c1 * h),
                   y13= (double)f.DynamicInvoke(b);

            double fa = y1;
            double fb = y13;

            double i2 = (h / 6.0) * (y1 + y13 + 5 * (y5 + y9));
            double i1 = (h / 1470.0) * (77 * (y1 + y13) + 432 * (y3 + y11) + 625 * (y5 + y9) + 672 * y7);

            double i0 = h * (
                0.0158271919734802 * (y1 + y13) +
                0.0942738402188500 * (y2 + y12) +
                0.155071987336585 * (y3 + y11) +
                0.188821573960182 * (y4 + y10) +
                0.199773405226859 * (y5 + y9) +
                0.224926465333340 * (y6 + y8) +
                0.242611071901408 * y7);

            double s = (i0 >= 0) ? 1 : -1;

            double erri1 = Math.Abs(i1 - i0);
            double erri2 = Math.Abs(i2 - i0);

            double R = (erri2 == 0) ? 1 : erri1 / erri2;

            i0 = s * Math.Abs(i0) * tol / double.Epsilon;
            if (i0 == 0) i0 = b - a;

            return quadlStep(f, a, b, fa, fb, i0);
        }

        #region QUADL Helper(s)
        /// <summary>Recursive component of quadl</summary>
        /// <remarks>This funciton was also taken from Gander and Gautschi,
        /// http://www.inf.ethz.ch/personal/gander/ .</remarks>
        private static double quadlStep(MulticastDelegate f, double a, double b, double fa, double fb, double i0)
        {
            double h = (b - a) / 2.0;
            double m = (a + b) / 2.0;
            double alpha = Math.Sqrt(2.0 / 3.0);
            double beta = 1.0 / Math.Sqrt(5.0);

            double mll = m - alpha * h;
            double ml = m - beta * h;
            double mr = m + beta * h;
            double mrr = m + alpha * h;

            double fmll = (double)f.DynamicInvoke(mll),
                   fml  = (double)f.DynamicInvoke(ml),
                   fm   = (double)f.DynamicInvoke(m),
                   fmr  = (double)f.DynamicInvoke(mr),
                   fmrr = (double)f.DynamicInvoke(mrr);

            double i2 = (h / 6.0) * (fa + fb + 5 * (fml + fmr));
            double i1 = (h / 1470.0) * (77 * (fa + fb) + 432 * (fmll + fmrr) + 625 * (fml + fmr) + 672 * fm);

            if ((i0 + (i1 - i2) == i0) || (mll <= a) || (b <= mrr))
            {
                return i1;
            }
            else
            {
                return quadlStep(f, a, mll, fa, fmll, i0) +
                       quadlStep(f, mll, ml, fmll, fml, i0) +
                       quadlStep(f, ml, m, fml, fm, i0) +
                       quadlStep(f, m, mr, fm, fmr, i0) +
                       quadlStep(f, mr, mrr, fmr, fmrr, i0) +
                       quadlStep(f, mrr, b, fmrr, fb, i0);
            }
        }
        #endregion
    }
}