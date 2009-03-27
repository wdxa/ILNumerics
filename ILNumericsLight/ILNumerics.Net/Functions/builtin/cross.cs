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
        public static ILArray<double> cross(ILArray<double> A, ILArray<double> B, int dim)
        {
            // Input checking
            if (!A.m_dimensions.IsSameShape(B.m_dimensions))
                throw new ILDimensionMismatchException("Inputs must have the same size and shape.");

            ILDimension outDims = A.m_dimensions;
            double[] outArray = ILMemoryPool.Pool.New<double>(outDims.NumberOfElements);

            if (dim >= outDims.NumberOfDimensions || dim < 0)
                throw new Exception("Specified dim is out of bounds of the array!");

            if (outDims[dim] != 3)
                throw new Exception("Must have length 3 in the dimension where the cross product is taken.");

            // Cross Product
            int SID = outDims.SequentialIndexDistance(dim);
            int crosses = outDims.NumberOfElements / 3;
            int SID2 = 2 * SID;

            for (int i = 0; i < crosses; i++)
            {
                outArray[i] = A.m_data[SID + i] * B.m_data[SID2 + i] - A.m_data[SID2 + i] * B.m_data[SID + i];
                outArray[SID + i] = A.m_data[SID2 + i] * B.m_data[i] - A.m_data[i] * B.m_data[SID2 + i];
                outArray[SID2 + i] = A.m_data[i] * B.m_data[SID + i] - A.m_data[SID + i] * B.m_data[i];
            }

            return new ILArray<double>(outArray, outDims);
        }
    }
}