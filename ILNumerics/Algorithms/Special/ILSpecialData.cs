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
            using (ILArray<double> X = repmat(vector(-cols,2,cols-1).T,rows,1) / cols*pi*2*periods) 
            using (ILArray<double> Y = repmat(vector(-rows,2,rows-1),1,cols) / rows*pi*2*periods) {
                ILArray<double> ret=sqrt(X * X + Y * Y);
                ret[ret == 0.0] = MachineParameterDouble.eps; 
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

        /// <summary>
        /// Create surface data of a sphere
        /// </summary>
        /// <param name="n">number of facettes per angle</param>
        /// <param name="X">[output] X coords</param>
        /// <param name="Y">[output] Y coords</param>
        /// <param name="Z">[output] Z coords</param>
        public static void sphere(int n, out ILArray<double> X,out ILArray<double> Y,out ILArray<double> Z) {
            ILArray<double> phi = repmat(linspace(-pi,pi,n).T,1,n);
            ILArray<double> rho = repmat(linspace(0,pi,n),n,1); 
            Y = sin(phi) * sin(rho); 
            X = cos(phi) * sin(rho);
            Z = cos(rho); 
        }
        /// <summary>
        /// Create surface data for a Möbius strip 
        /// </summary>
        /// <param name="n">granularity (number of facettes)</param>
        /// <param name="w">width</param>
        /// <param name="R">radius</param>
        /// <param name="X">[output] X coords</param>
        /// <param name="Y">[output] Y coords</param>
        /// <param name="Z">[output] Z coords</param>
        /// <remarks>Möbius strip is a surfcae, crated by cutting a regular strip, twisting one end by 180 deg and glueing 
        /// both ends together again.</remarks>
        public static void moebius(int n, double w, double R, out ILArray<double> X,out ILArray<double> Y,out ILArray<double> Z) {
            ILArray<double> s = repmat(linspace(-w,w,n),n,1); 
            ILArray<double> t = repmat(linspace(0,2*pi,n).T,1,n); 
            X = (R + s* cos(0.5*t)) * cos(t); 
            Y = (R + s* cos(0.5*t)) * sin(t); 
            Z = s * sin(0.5*t); 
        }


    }
}
