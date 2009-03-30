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

using ILNumerics.Exceptions;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// vertical concatenation for arbitrary arrays
        /// </summary>
        /// <param name="inArrays"> arrays to be concatenated with each other. All
        /// arrays must be of the same inner type. The dimensions of all arrays 
        /// must match - except the first dimension.</param>
        /// <returns>large array having all arrays in 'inArrays' placed beneath each other.
        /// </returns>
        /// <remarks>The array returned may be a reference array if all elements of 'inArrays' 
        /// point to the same object instance, or a solid array otherwise. In the case of
        /// all elements pointing to the same object, the static member 
        /// ILNumerics.ILSettings.MinimumRefDimensions will be taken into account too.
        /// 
        /// Vertical concatenation means concatenation along the first dimension.
        /// </remarks>
        public static ILArray<T> vertcat<T>(params ILArray<T>[] toCat)
        {
            // Input checking
            int nElementsOut = 0;
            int nRowsOut = 0;

            ILDimension aValidDim = null;
            int[] seqDist = new int[toCat.Length];
            int[] posInEachToCat = new int[toCat.Length];

            for (int i = 0; i < toCat.Length; i++)
            {
                if (!toCat[i].IsEmpty)
                {
                    nElementsOut += toCat[i].m_dimensions.NumberOfElements;
                    nRowsOut += toCat[i].m_dimensions[0];

                    seqDist[i] = toCat[i].m_dimensions.SequentialIndexDistance(1);

                    if (aValidDim == null)
                    {
                        aValidDim = toCat[i].m_dimensions;
                        continue;
                    }

                    if (aValidDim.NumberOfDimensions != toCat[i].m_dimensions.NumberOfDimensions)
                        throw new ILArgumentSizeException("vertcat: Both arrays to be concatenated must have the same number of dimensions!");

                    for (int j = 1; j < aValidDim.NumberOfDimensions; j++)
                        if (aValidDim[j] != toCat[i].m_dimensions[j])
                            throw new Exception("vertcat: all but the second dimensions of all arrays must match!");
                }
            }

            if (nElementsOut == 0)
                return new ILArray<T>();

            // Allocate
            T[] outArray = ILMemoryPool.Pool.New<T>(nElementsOut);

            // Concat
            int posInOutArray = 0, posInToCat = 0;
            while (posInOutArray < nElementsOut)
            {
                if (posInToCat >= toCat.Length)
                    posInToCat = 0;

                int thisSeqDist = seqDist[posInToCat];
                T[] thisArray = toCat[posInToCat].m_data;

                for (int i = 0; i < thisSeqDist; i++)
                    outArray[posInOutArray++] = thisArray[posInEachToCat[posInToCat]++];

                posInToCat++;
            }

            int[] retDimArray = aValidDim.ToIntArray();
            retDimArray[0] = nRowsOut;

            return new ILArray<T>(outArray, new ILDimension(retDimArray));
        }

    }
}
