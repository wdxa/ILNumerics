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
using ILNumerics.Storage;
using ILNumerics.Native;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions;


namespace ILNumerics.BuiltInFunctions
{
    public partial class ILMath
    {
        /// <summary>Polynomial interpolation, first derivative continuity</summary>
        /// <param name="X">Vector representing possible X lookups into Y.</param>
        /// <param name="Y">The table values: Y = f(X). Must have the same number of elements as X.</param>
        /// <param name="XI">X components of points to interpolate.</param>
        /// <returns>Values YI interpolated at each XI: YI ~= f(XI). Will be the same size as XI.</returns>
        /// <seealso cref="linearInterp1D"/>
        /// <remarks>
        /// Smoother than linearInterp1D since continuity is achieved on the first derivative; however,
        /// continutiy is not guarenteed on the second derivative. (Note: It's possible to make this faster
        /// by lazily evaluating slopes, but it probably wouldn't make much difference seeings how it is
        /// linear time to evaluate them all.)
        /// 
        /// Reference:
        /// -Moler, Cleve B. Numerical Computing with Matlab.
        ///  Society for the Industrial and Applied Mathematics:
        ///  Philadelphia, PA, 2004. Interpolation, Chapter 3.
        ///  http://www.mathworks.com/moler/index_ncm.html
        /// </remarks>
        public static ILArray<double> pchip(ILArray<double> X, ILArray<double> Y, ILArray<double> XI)
        {
            //// 1. Input checking
            if (XI.IsEmpty)
                return new ILArray<double>();

            int n = X.m_dimensions.NumberOfElements;

            if (n != Y.m_dimensions.NumberOfElements)
                throw new ILDimensionMismatchException("X and Y must have the same number of elements.");

            if (n < 3)
                throw new ILArgumentSizeException("There must be at least 3 data points" + 
                    " to perform interpolation (due to the way end-slopes are selected).");

            //// 2. Declarations
            double[] x = (double[])X.m_data.Clone(); // will be sorted
            double[] y = (double[])Y.m_data.Clone(); // will be sorted
            double[] xi = XI.m_data;

            double[] h = ILMemoryPool.Pool.New<double>(n - 1);
            double[] delta = ILMemoryPool.Pool.New<double>(n - 1);

            double[] slopes = ILMemoryPool.Pool.New<double>(n);
            double[] yi = ILMemoryPool.Pool.New<double>(xi.Length);

            //// 3. Ensure X is sorted
            Array.Sort(x, y);

            //// 4. Some definitions
            for (int i = 0; i < h.Length; i++)
            {
                h[i] = x[i + 1] - x[i];
                delta[i] = (y[i + 1] - y[i]) / h[i];
            }

            //// 5. Find slopes

                // ->endpoints
                slopes[0] = ((2 * h[0] + h[1]) * delta[0] - h[0] * delta[1]) / (h[0] + h[1]);
                slopes[n-1] = ((2 * h[n-2] + h[n-3]) * delta[n-2] - h[n-2] * delta[n-3]) / (h[n-2] + h[n-3]);

                if (Math.Sign(slopes[0]) != Math.Sign(delta[0]))
                    slopes[0] = 0;
                else if (Math.Sign(delta[0]) != Math.Sign(delta[1]) && Math.Abs(slopes[0]) > Math.Abs(3 * delta[0]))
                    slopes[0] = delta[0] * 3;

                if (Math.Sign(slopes[n-1]) != Math.Sign(delta[n-2]))
                    slopes[n-1] = 0;
                else if (Math.Sign(delta[n-2]) != Math.Sign(delta[n-3]) && Math.Abs(slopes[n-1]) > Math.Abs(3 * delta[n-2]))
                    slopes[n-1] = delta[n-2] * 3;
                
                // ->middles
                for (int i = 1; i <= n - 2; i++)
                {
                    if (delta[i] == 0 || delta[i - 1] == 0 || Math.Sign(delta[i]) != Math.Sign(delta[i - 1]))
                    {
                        slopes[i] = 0;
                    }
                    else
                    {
                        double w1 = 2 * h[i] + h[i - 1];
                        double w2 = h[i] + 2 * h[i - 1];

                        slopes[i] = (w1 + w2) / (w1 / delta[i - 1] + w2 / delta[i]);
                    }
                }

            //// 6. Evaluate interpolating polynomial
            for (int i = 0, k; i < xi.Length; i++)
            {
                if (xi[i] > x[n - 1] || xi[i] < x[0])
                {
                    yi[i] = double.NaN;
                    continue;
                }
                if (xi[i] == x[n - 1])
                {
                    yi[i] = y[n - 1];
                    continue;
                }

                greatestElementLessThan(xi[i], x, out k); // TODO: Loop could assume x is sorted, but doesn't

                double s = xi[i] - x[k];
                double s2 = s * s;
                double s3 = s2 * s;
                double h1 = h[k];
                double h2 = h1 * h1;
                double h3 = h2 * h1;

                yi[i] = (3 * h1 * s2 - 2 * s3) / h3 * y[k + 1] +
                        (h3 - 3 * h1 * s2 + 2 * s3) / h3 * y[k] +
                        (s2 * (s - h1)) / h2 * slopes[k + 1] +
                        (s * (s - h1) * (s - h1)) / h2 * slopes[k];
            }

            return new ILArray<double>(yi, XI.m_dimensions);
        }

        #region More Interpolation Helpers
        #endregion
    }
}