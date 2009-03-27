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
        public static ILArray<double> cumsum(ILArray<double> X)
        {
            double[] outArray = ILMemoryPool.Pool.New<double>(X.m_dimensions.NumberOfElements);
            double tally = 0;

            for (int i = 0; i < outArray.Length; i++)
            {
                tally += X.m_data[i];
                outArray[i] = tally;
            }

            return new ILArray<double>(outArray, X.m_dimensions);
        }


        public static ILArray<double> cumsum(ILArray<double> X, int dim)
        {
            ILDimension outDims = X.m_dimensions;
            double[] outArray = ILMemoryPool.Pool.New<double>(outDims.NumberOfElements);

            if (dim < 0) throw new ILDimensionMismatchException();

            int SID = outDims.SequentialIndexDistance(dim);
            int vectLength = outDims[dim];
            int nVects = outDims.NumberOfElements / outDims[dim];

            for (int i = 0; i < nVects; i++)
            {
                double tally = 0;
                for (int j = 0; j < vectLength; j++)
                {
                    int idx = (j * SID) + (i * vectLength);
                    tally += X.m_data[idx];
                    outArray[idx] = tally;
                }
            }

            return new ILArray<double>(outArray, outDims);
        }

    }
}