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

namespace ILNumerics.Algorithms {
    public class ILSpecialData : ILAlgorithm {
        /// <summary>
        /// Generate sinc function in 2D, useful for plotting examples
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">number og columns</param>
        /// <param name="periods">influences the number of periods to be drawn in both directions. 1 will result in 4 zero crossings, higher values result in more, lower values in less zero crossings.</param>
        /// <returns>matrix with sinc data in 2 dimensions</returns>
        public static ILArray<double> sinc (int rows, int cols, float periods) {
            using (ILArray<double> X = repmat(vector(-cols,2,cols-1),1,rows) / (cols/(pi*4)/periods)) 
            using (ILArray<double> Y = repmat(vector(-rows,2,rows-1).T,cols,1) / (rows/(pi*4)/periods)) {
                ILArray<double> ret=sqrt(X * X + Y * Y);
                ret[ret == 0.0] = MachineParameterFloat.eps; 
                ret = sin(ret)/ret; 
                return ret; 
            }
        }
        /// <summary>
        /// Generate sinc function in 2D, useful for plotting examples
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">number of columns</param>
        /// <returns>matrix with sinc data in 2 dimensions</returns>
        /// <remarks>the function generates 4 zero crossings in each direction</remarks>
        public static ILArray<double> sinc (int rows, int cols) {
            return sinc(rows,cols,1.0f); 
        }

        /// <summary>
        /// Create specified periods of sine and cosine data
        /// </summary>
        /// <param name="numSamples">number of samples</param>
        /// <param name="periods">number of (full) periods to be generated, must be &gt; 0</param>
        /// <returns>matrix with sine data in first column, cosine data in second column</returns>
        public static ILArray<double> sincos1D(int numSamples, double periods) {
            ILArray<double> t = linspace(0.0, 2 * pi * periods, numSamples);
            return horzcat(sin(t).T,cos(t).T); 
        }
        /// <summary>
        /// Create demo data for surface plots looking like a waterfall
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">number of columns</param>
        /// <returns>matrix with data showing a waterfall terrain. </returns>
        public static ILArray<double> waterfall (int rows, int cols) {
            ILArray<double> a = rand(rows, cols); 
            using (ILArray<double> bord = rand(1,cols) * 3 + (rows / 2))
            for (int c = 0; c < cols; c++) {
                int b = (int)(bord[c] - sin(c/(double)cols*pi) * cols/5); 
                a[vector(0.0,b),c] += 2.0; 
            }
            return a; 
        }

    }
}
