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
        /// <summary>Evaluate the polynomial c*x^n + c*x^n-1 + ... + c</summary>
        /// <param name="coeffs">Coefficients of polynomial</param>
        /// <param name="x">Variable of polynomial</param>
        /// <returns>Array same size as x with result of polynomial evaluation at x</returns>
        public static ILArray<double> polyval(ILArray<double> coeffs, ILArray<double> x)
        {
            if (!coeffs.IsVector)
                throw new Exception("Coefficients input must be a vector.");

            if (coeffs.IsEmpty)
                return zeros(x.Dimensions);

            double[] cArray = coeffs.m_data;
            double[] xArray = x.m_data;
            double[] yArray = ILMemoryPool.Pool.New<double>(x.Dimensions.NumberOfElements);

            for (int i = 0; i < yArray.Length; i++)
                yArray[i] = cArray[0];

            for (int i = 1; i < cArray.Length; i++)
                for (int j = 0; j < yArray.Length; j++)
                    yArray[j] = xArray[j] * yArray[j] + cArray[i];

            return new ILArray<double>(yArray, x.Dimensions);
        }
        
    }
}