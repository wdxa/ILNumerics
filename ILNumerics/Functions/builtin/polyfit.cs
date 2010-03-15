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
        /// <summary>
        /// Polynomial curve fitting of degree n
        /// </summary>
        /// <param name="x">Vector of X values</param>
        /// <param name="y">Vector of Y values</param>
        /// <param name="n">Degress of polynomial to fit</param>
        /// <returns>Vector of polynomial coefficients [p1, p2, .., pn+1], fit is p(x) = p1*x^n + p2*x^(n-1) + ...</returns>
        public static ILArray<double> polyfit(ILArray<double> x, ILArray<double> y, int n)
        {
            // Create Vandermonde matrix [[x0^n, x0^(n-1), ..., 1], [x1^n, x1^(n-1), ..., 1], ...]
            if (!x.IsVector || !y.IsVector)
                throw new ILArgumentException("x and y must be vectors");
            if (x.Length != y.Length)
                throw new ILArgumentException("x and y must have the same length");
            int m = x.Length;
            ILArray<double> V = new ILArray<double>(m, n + 1);
            for (int i = 0; i < m; ++i)
            {
                double vElement = 1;
                double currentX = x.GetValue(i);
                for (int j = n; j >= 0; --j)
                {
                    V[i, j] = vElement;
                    vElement *= currentX;
                }
            }
            ILArray<double> coefficients = ILMath.linsolve(V, y);
            return coefficients;
        }
    }
}
