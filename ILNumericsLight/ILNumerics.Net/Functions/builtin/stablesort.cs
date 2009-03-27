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
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        /// <summary>
        /// Sorts along first non-singleton dimension in ascending order
        /// </summary>
        /// <param name="toSort">Matrix of items to sort</param>
        /// <param name="indices">Index positions such that sortedArray[indices] = 
        /// originalArray. Most importantly, indices belonging to elements of equivalent
        /// value will be sorted from low to high.</param>
        /// <remarks>This is a stable sort, using a stable Merge Sort algorithm. Use sort
        /// function instead if preservation of order is unnecessary.</remarks>
        /// <returns>Input array sorted along first non-singleton dimension</returns>
        public static ILArray<double> stablesort(ILArray<double> toSort, out ILArray<double> indices)
        {
            if (toSort.IsEmpty)
            {
                indices = new ILArray<double>();
                return new ILArray<double>();
            }

            if (toSort.IsScalar)
            {
                indices = new ILArray<double>(new double[] { 0 });
                return toSort.C;
            }

            double[] keys = (double[])toSort.m_data.Clone();
            double[] values = ILMemoryPool.Pool.New<double>(toSort.m_data.Length);

            for (int i = 0; i < values.Length; i++) values[i] = i;
            toSort.m_dimensions = toSort.m_dimensions.Squeeze();

            if (toSort.IsVector)
            {
                mergesort(0, keys.Length - 1, ref keys, ref values);
            }
            else
            {
                int numRows = toSort.m_dimensions[0];
                int lenRow = toSort.m_dimensions.NumberOfElements / numRows;

                for (int i = 0; i < numRows; i++)
                    mergesort(i * lenRow, i * lenRow + lenRow, ref keys, ref values);
            }

            indices = new ILArray<double>(values);
            return new ILArray<double>(keys, toSort.m_dimensions);
        }

        private static void mergesort(int l, int r, ref double[] keys, ref double[] values)
        {  // Algorithms in Java, Sedgewick 2003

            double[] keyAux = new double[keys.Length];
            double[] valAux = new double[keys.Length];

            for (int m = 1; m <= r - l; m = m + m)
                for (int i = l; i <= r - m; i += m + m)
                    merge(i, i + m - 1, Math.Min(i + m + m - 1, r), ref keyAux, ref valAux, ref keys, ref values);
        }

        private static void merge(int l, int m, int r, ref double[] keyAux, ref double[] valAux, ref double[] keys, ref double[] values)
        { // See Algorithms in Java, Sedgewick 2003

            int i, j, k;

            for (i = l; i <= r; i++)
            {
                keyAux[i] = keys[i];
                valAux[i] = values[i];
            }

            for (i = l, j = m + 1, k = l; i <= m && j <= r; k++)
            {
                if (keyAux[j] < keyAux[i])
                {
                    keys[k] = keyAux[j];
                    values[k] = valAux[j];
                    j++;
                }
                else
                {
                    keys[k] = keyAux[i];
                    values[k] = valAux[i];
                    i++;
                }
            }

            for (; i <= m; i++)
            {
                keys[k] = keyAux[i];
                values[k] = valAux[i];
                k++;
            }

            for (; j <= r; j++)
            {
                keys[k] = keyAux[j];
                values[k] = valAux[j];
                k++;
            }
        }

    }
}
