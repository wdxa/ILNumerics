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
using ILNumerics.Misc;
using ILNumerics.Exceptions; 

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath
    {
        /// <summary>
        /// Create two 2D arrays for the valuation and visualization of functions of two variables 
        /// </summary>
        /// <param name="x">Vector of x values</param>
        /// <param name="y">Vector of y values</param>
        /// <returns>A List of two arrays, the x vector values along the first dimension of the first array, 
        /// and y vector values along the second dimension of the second array</returns>
        /// <remarks></remarks>
        public static List<ILArray<double>> meshgrid(ILArray<double> x, ILArray<double> y)
        {
            if (!x.IsVector || !y.IsVector)
            {
                throw new ILArgumentException("meshgrid: inputs must be vectors");
            }
            int xLength = x.Length;
            int yLength = y.Length;
            //ILDimension dimRet = new ILDimension(xLength, yLength);
            //double[] retArrX = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements);
            //double[] retArrY = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements);
            //unsafe
            //{
            //    fixed (double* pRetArrX = retArrX)
            //    fixed (double* pRetArrY = retArrY)
            //    fixed (double* pX = x.m_data)
            //    fixed (double* pY = y.m_data)
            //    {
            //        double* pRetArrayX = pRetArrX;
            //        double* pRetArrayY = pRetArrY;
            //        double* pArrayX;
            //        double* pArrayY = pY;
            //        double* pXEnd = pX + xLength;
            //        double* pYEnd = pY + yLength;
            //        while (pArrayY < pYEnd)
            //        {
            //            pArrayX = pX;
            //            while (pArrayX < pXEnd)
            //            {
            //                *pRetArrayX = *pArrayX;
            //                *pRetArrayY = *pArrayY;
            //                pArrayX++;
            //                pRetArrayX++;
            //                pRetArrayY++;
            //            }
            //            pArrayY++;
            //        }

            //    }
            //}
            List<ILArray<double>> retList = new List<ILArray<double>>();
            if (!x.IsRowVector) x = x.T; 
            if (!y.IsColumnVector) y = y.T; 
            retList.Add(repmat(x,y.Length,1));
            retList.Add(repmat(y,1,x.Length));
            return retList;
        }

        /// <summary>
        /// Create three 3D arrays for the valuation and visualization of functions of three variables 
        /// </summary>
        /// <param name="x">Vector of x values</param>
        /// <param name="y">Vector of y values</param>
        /// <param name="z">Vector of z values</param>
        /// <returns>A List of three arrays, the rows of the first comprising the x vector values and the columns of the second comprising the y vector values</returns>
        /// <remarks></remarks>
        public static List<ILArray<double>> meshgrid(ILArray<double> x, ILArray<double> y, ILArray<double> z)
        {
            if (!x.IsVector || !y.IsVector || !z.IsVector)
            {
                throw new ILArgumentException("meshgrid: inputs must be vectors");
            }
            int xLength = x.Length;
            int yLength = y.Length;
            int zLength = z.Length;
            //ILDimension dimRet = new ILDimension(xLength, yLength, zLength);
            //double[] retArrX = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements);
            //double[] retArrY = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements);
            //double[] retArrZ = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements);
            //unsafe
            //{
            //    fixed (double* pRetArrX = retArrX)
            //    fixed (double* pRetArrY = retArrY)
            //    fixed (double* pRetArrZ = retArrZ)
            //    fixed (double* pX = x.m_data)
            //    fixed (double* pY = y.m_data)
            //    fixed (double* pZ = z.m_data)
            //    {
            //        double* pRetArrayX = pRetArrX;
            //        double* pRetArrayY = pRetArrY;
            //        double* pRetArrayZ = pRetArrZ;
            //        double* pArrayX;
            //        double* pArrayY;
            //        double* pArrayZ = pZ;
            //        double* pXEnd = pX + xLength;
            //        double* pYEnd = pY + yLength;
            //        double* pZEnd = pZ + zLength;
            //        while (pArrayZ < pZEnd)
            //        {
            //            pArrayY = pY;
            //            while (pArrayY < pYEnd)
            //            {
            //                pArrayX = pX;
            //                while (pArrayX < pXEnd)
            //                {
            //                    *pRetArrayX = *pArrayX;
            //                    *pRetArrayY = *pArrayY;
            //                    *pRetArrayZ = *pArrayZ;
            //                    pArrayX++;
            //                    pRetArrayX++;
            //                    pRetArrayY++;
            //                    pRetArrayZ++;
            //                }
            //                pArrayY++;
            //            }
            //            pArrayZ++;
            //        }

            //    }
            //}

            List<ILArray<double>> retList = new List<ILArray<double>>();
            if (!x.IsRowVector) x.Reshape(1,x.Length); 
            if (!y.IsColumnVector) y.Reshape(y.Length,1);  
            z = z[":"].Reshape(1,1,z.Dimensions.NumberOfElements); 

            retList.Add(repmat(x,yLength,1,zLength));
            retList.Add(repmat(y,1,xLength,zLength));
            retList.Add(repmat(z,yLength,xLength,1));
            return retList;
        }
    }
}
