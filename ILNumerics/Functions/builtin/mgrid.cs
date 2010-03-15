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

#if IRONPYTHON

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Misc;
using ILNumerics.Exceptions; 

namespace ILNumerics.BuiltInFunctions {
    
    public partial class ILMath
    {
        public static MeshgridCreator mgrid
        {
            get
            {
                return new MeshgridCreator();
            }
        }
    }
    
    /// <summary>
    /// IronPython only: on indexing this object, a List of arrays as returned by the 2d or 3d meshgrid functions is obtained
    /// </summary>
    /// <param name="xslice">Slice defining the x vector</param>
    /// <param name="yslice">Slice defining the y vector</param>
    /// <returns>A List of two arrays or three, the x vector values along the first dimension of the first array,
    /// y vector values along the second dimension of the second array, the z vector values along
    /// the the z vector values along the third dimension of the third array</returns>
    /// <remarks></remarks>
    public class MeshgridCreator
    {
        public IronPython.Runtime.List this[IronPython.Runtime.Slice xslice, IronPython.Runtime.Slice yslice]
        {
            get
            {
                if ((xslice.start == null) || (xslice.stop == null) || (yslice.start == null) || (yslice.stop == null))
                {
                    throw new ILArgumentException("mgrid: start and stop of slices must be provided");
                }
                double xStep = 1, yStep = 1, xStart = 0, yStart = 0, xStop = 1, yStop = 1;
                if (xslice.step == null) { xStep = 1; }
                else
                {
                    if (xslice.step is int) xStep = (double)(int)(xslice.step);
                    if (xslice.step is double) xStep = (double)(xslice.step);
                }
                if (yslice.step == null) { yStep = 1; }
                else
                {
                    if (yslice.step is int) yStep = (double)(int)(yslice.step);
                    if (yslice.step is double) yStep = (double)(yslice.step);
                }
                if (xslice.start is int) xStart = (double)(int)(xslice.start);
                if (xslice.start is double) xStart = (double)(xslice.start);
                if (xslice.stop is int) xStop = (double)(int)(xslice.stop);
                if (xslice.stop is double) xStop = (double)(xslice.stop);
                //
                if (yslice.start is int) yStart = (double)(int)(yslice.start);
                if (yslice.start is double) yStart = (double)(yslice.start);
                if (yslice.stop is int) yStop = (double)(int)(yslice.stop);
                if (yslice.stop is double) yStop = (double)(yslice.stop);
                // 
                IronPython.Runtime.List list = new IronPython.Runtime.List();
                int nx = (int)Math.Floor((xStop - xStart) / xStep) + 1;
                int ny = (int)Math.Floor((yStop - yStart) / yStep) + 1;
                ILArray<double> x = ILMath.counter(xStart, xStep, nx);
                ILArray<double> y = ILMath.counter(yStart, yStep, ny);
                List<ILArray<double>> meshgrid = ILMath.meshgrid(x, y);
                list.Add(meshgrid[0]); list.Add(meshgrid[1]);
                return list;
            }
        }

        public IronPython.Runtime.List this[IronPython.Runtime.Slice xslice, IronPython.Runtime.Slice yslice, IronPython.Runtime.Slice zslice]
        {
            get
            {
                if ((xslice.start == null) || (xslice.stop == null) || (yslice.start == null) || (yslice.stop == null) || (zslice.start == null) || (zslice.stop == null))
                {
                    throw new ILArgumentException("mgrid: start and stop of slices must be provided");
                }
                double xStep = 1, yStep = 1, zStep = 1, xStart = 0, yStart = 0, zStart = 0, xStop = 1, yStop = 1, zStop = 1;
                if (xslice.step == null) { xStep = 1; }
                else
                {
                    if (xslice.step is int) xStep = (double)(int)(xslice.step);
                    if (xslice.step is double) xStep = (double)(xslice.step);
                }
                if (yslice.step == null) { yStep = 1; }
                else
                {
                    if (yslice.step is int) yStep = (double)(int)(yslice.step);
                    if (yslice.step is double) yStep = (double)(yslice.step);
                }
                if (zslice.step == null) { zStep = 1; }
                else
                {
                    if (zslice.step is int) zStep = (double)(int)(zslice.step);
                    if (zslice.step is double) zStep = (double)(zslice.step);
                }
                if (xslice.start is int) xStart = (double)(int)(xslice.start);
                if (xslice.start is double) xStart = (double)(xslice.start);
                if (xslice.stop is int) xStop = (double)(int)(xslice.stop);
                if (xslice.stop is double) xStop = (double)(xslice.stop);
                //
                if (yslice.start is int) yStart = (double)(int)(yslice.start);
                if (yslice.start is double) yStart = (double)(yslice.start);
                if (yslice.stop is int) yStop = (double)(int)(yslice.stop);
                if (yslice.stop is double) yStop = (double)(yslice.stop);
                // 
                if (zslice.start is int) zStart = (double)(int)(zslice.start);
                if (zslice.start is double) zStart = (double)(zslice.start);
                if (zslice.stop is int) zStop = (double)(int)(zslice.stop);
                if (zslice.stop is double) zStop = (double)(zslice.stop);
                //
                IronPython.Runtime.List list = new IronPython.Runtime.List();
                int nx = (int)Math.Floor((xStop - xStart) / xStep) + 1;
                int ny = (int)Math.Floor((yStop - yStart) / yStep) + 1;
                int nz = (int)Math.Floor((zStop - zStart) / zStep) + 1;
                ILArray<double> x = ILMath.counter(xStart, xStep, nx);
                ILArray<double> y = ILMath.counter(yStart, yStep, ny);
                ILArray<double> z = ILMath.counter(zStart, zStep, nz);
                List<ILArray<double>> meshgrid = ILMath.meshgrid(x, y, z);
                list.Add(meshgrid[0]); list.Add(meshgrid[1]); list.Add(meshgrid[2]);
                return list;
            }
        }
    }
}

#endif