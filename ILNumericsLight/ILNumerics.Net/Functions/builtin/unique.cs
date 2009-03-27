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
        /// <summary>Unique and sorted elements of a vector.</summary>
        /// <param name="X">Elements from which to extract unique values (treated as a vector).</param>
        /// <param name="whereResultInX">Indices (same size as retValue) such that x[whereResultInX] = retValue.</param>
        /// <param name="whereXInResult">Indices (same size as x) such that retValue[whereXInResult] = x.</param>
        /// <returns>Sorted row vector with size less than or equal to x where no 2 elements have the same value.</returns>
        public static ILArray<double> unique(ILArray<double> X, out ILArray<double> whereResultInX, out ILArray<double> whereXInResult)
        {
            // 1. Handle empty and singleton cases
            if (X.IsEmpty)
            {
                whereResultInX = new ILArray<double>();
                whereXInResult = new ILArray<double>();
                return new ILArray<double>();
            }

            if (X.IsScalar)
            {
                whereResultInX = new ILArray<double>(new double[] { 0 });
                whereXInResult = new ILArray<double>(new double[] { 0 });
                return X.C;
            }

            // 2. Sort
            double[] x = (double[])X.m_data.Clone();
            int[] oldXInd = ILMemoryPool.Pool.New<int>(x.Length);

            for (int i = 0; i < x.Length; i++)
                oldXInd[i] = i;

            Array.Sort(x, oldXInd);

            // 3. Declarations
            int unqCount = 1;
            for (int i = 1; i < x.Length; i++)
                if (x[i - 1] != x[i])
                    unqCount++;

            double[] unq = ILMemoryPool.Pool.New<double>(unqCount);
            double[] wxnr = ILMemoryPool.Pool.New<double>(x.Length);
            double[] wrnx = ILMemoryPool.Pool.New<double>(unqCount);

            // 4. Unique
            unq[0] = x[0];
            wxnr[oldXInd[0]] = 0;
            wrnx[0] = oldXInd[0];

            for (int i = 1, j = 1; i < x.Length; i++)
            {
                if (x[i - 1] != x[i])
                {
                    unq[j] = x[i];
                    wrnx[j] = oldXInd[i];
                    j++;
                }
                wxnr[oldXInd[i]] = j - 1;
            }

            whereResultInX = new ILArray<double>(wrnx);
            whereXInResult = new ILArray<double>(wxnr);
            return new ILArray<double>(unq);
        }
        /// <summary>Unique and sorted elements of a vector.</summary>
        /// <param name="X">Elements from which to extract unique values (treated as a vector).</param>
        /// <param name="whereResultInX">Indices (same size as retValue) such that x[whereResultInX] = retValue.</param>
        /// <returns>Sorted row vector with size less than or equal to x where no 2 elements have the same value.</returns>
        public static ILArray<double> unique(ILArray<double> X, out ILArray<double> whereResultInX)
        {
            // 1. Handle empty and singleton cases
            if (X.IsEmpty)
            {
                whereResultInX = new ILArray<double>();
                return new ILArray<double>();
            }

            if (X.IsScalar)
            {
                whereResultInX = new ILArray<double>(new double[] { 0 });
                return X.C;
            }

            // 2. Sort
            double[] x = (double[])X.m_data.Clone();
            int[] oldXInd = ILMemoryPool.Pool.New<int>(x.Length);

            for (int i = 0; i < x.Length; i++)
                oldXInd[i] = i;

            Array.Sort(x, oldXInd);

            // 3. Declarations
            int unqCount = 1;
            for (int i = 1; i < x.Length; i++)
                if (x[i - 1] != x[i])
                    unqCount++;

            double[] unq = ILMemoryPool.Pool.New<double>(unqCount);
            double[] wrnx = ILMemoryPool.Pool.New<double>(unqCount);

            // 4. Unique
            unq[0] = x[0];
            wrnx[0] = oldXInd[0];

            for (int i = 1, j = 1; i < x.Length; i++)
            {
                if (x[i - 1] != x[i])
                {
                    unq[j] = x[i];
                    wrnx[j] = oldXInd[i];
                    j++;
                }
            }

            whereResultInX = new ILArray<double>(wrnx);
            return new ILArray<double>(unq);
        }
        /// <summary>Unique and sorted elements of a vector.</summary>
        /// <param name="X">Elements from which to extract unique values (treated as a vector).</param>
        /// <returns>Sorted row vector with size less than or equal to x where no 2 elements have the same value.</returns>
        public static ILArray<double> unique(ILArray<double> X)
        {
            // 1. Handle empty and singleton cases
            if (X.IsEmpty)
                return new ILArray<double>();

            if (X.IsScalar)
                return X.C;

            // 2. Sort
            double[] x = (double[])X.m_data.Clone();
            Array.Sort(x);

            // 3. Declarations
            int unqCount = 1;
            for (int i = 1; i < x.Length; i++)
                if (x[i - 1] != x[i])
                    unqCount++;

            double[] unq = ILMemoryPool.Pool.New<double>(unqCount);

            // 4. Unique
            unq[0] = x[0];
            for (int i = 1, j = 1; i < x.Length; i++)
            {
                if (x[i - 1] != x[i]) {
                    unq[j] = x[i];
                    j++;
                }
            }

            return new ILArray<double>(unq);
        }
    }
}