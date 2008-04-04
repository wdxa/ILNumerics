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

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {

        /// <summary>
        /// Rank of matrix inArray
        /// </summary>
        /// <param name="inArray">Matrix</param>
        /// <returns>rank of matrix inArray</returns>
        /// <remarks>The rank is the number of singular values greater than 
        /// the default tolerance. As tolerance the following equation is used: \\
        /// tol = length(inArray) * norm(inArray) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(inArray) - the longest dimension of inArray</item>
        /// <item>norm(inArray) beeing the largest singular value of inArray, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// </remarks>
        public static ILArray<double> rank(ILArray<double> inArray) {
            return rank (inArray,-1.0); 
        }

        /// <summary>
        /// Rank of matrix inArray
        /// </summary>
        /// <param name="inArray">Matrix</param>
        /// <param name="tolerance">tolerance used to decide, if a singular value is 
        /// treated as zero</param>
        /// <returns>rank of matrix inArray</returns>
        /// <remarks>The rank is the number of singular values greater than 
        /// tolerance. If tolerance is smaller than zero, the following equation is used as 
        /// default: \\
        /// tol = length(inArray) * norm(inArray) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(inArray) - the longest dimension of inArray</item>
        /// <item>norm(inArray) beeing the largest singular value of inArray, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// </remarks>
        public static ILArray<double> rank(ILArray<double> inArray, double tolerance) {
            if (inArray.Dimensions.NumberOfDimensions > 2)
                throw new ILArgumentSizeException("rank: the input array must be matrix or vector!");
            ILArray<double> ret = svd(inArray); 
            if (tolerance < 0) {
                tolerance = inArray.Dimensions.Longest * max(ret).GetValue(0) * System.Double.Epsilon; 
            }
            // sum vector elements: ret must (and should) be physical vector returned from svd
            double tmpsum = 0.0;
            double tmpval = 0.0;
            int len = ret.Length;
            double[] d = ret.m_data; 
            for (int i = 0; i < d.Length; i++) {
                tmpval = d[i];
                if (tmpval > tolerance)
                    tmpsum += tmpval;
            }
            return new ILArray<double>(tmpsum);
        }
    }
}
