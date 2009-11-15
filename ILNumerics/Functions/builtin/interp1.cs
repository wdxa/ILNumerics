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
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;

namespace ILNumerics.BuiltInFunctions
{
    public enum InterpolationMethod { Linear, CubicSpline, MonotoneHermiteCubicSpline }

    public partial class ILMath
    {
        /// <summary>
        /// 1D interpolation
        /// </summary>
        /// <param name="x">Vector of X values of the function to interpolate</param>
        /// <param name="y">Vector of Y values of the function to interpolate</param>
        /// <param name="xi">Vector of X values at which interpolated Y values are required</param>
        /// <param name="method">Interpolation method: InterpolationMethod.Linear, HermiteCubic or MonotoneHermiteCubicSpline</param>
        /// <returns>Numeric array with specified inner element type</returns>
        public static ILArray<double> interp1(ILArray<double> x, ILArray<double> y, ILArray<double> xi, InterpolationMethod method)
        {
            ILCurve<double> curve = new ILCurve<double>(x, y);
            switch (method)
            {
                case InterpolationMethod.Linear:
                    return curve.GetValuesLinear(xi);
                case InterpolationMethod.CubicSpline:
                    return curve.GetValuesCubicSpline(xi);
                case InterpolationMethod.MonotoneHermiteCubicSpline:
                    return curve.GetValuesCubicSpline(xi);
                default:
                    return curve.GetValuesLinear(xi);
            }
        }
    }
}

