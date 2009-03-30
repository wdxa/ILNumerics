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
        /// <summary>Linear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into Y.</param>
        /// <param name="Y">The table values: Y = f(X). Must have the same number of elements as X.</param>
        /// <param name="XI">X components of points to interpolate.</param>
        /// <returns>Values YI interpolated at each XI: YI ~= f(XI). Will be the same size as XI.</returns>
        public static ILArray<double> linearInterp1D(ILArray<double> X, ILArray<double> Y, ILArray<double> XI)
        {
            // 1. Input checking
            if (XI.IsEmpty)
                return new ILArray<double>();

            if (XI.IsScalar)
                return linearInterp1D(X, Y, XI.m_data[0]);

            if (X.m_dimensions.NumberOfElements != Y.m_dimensions.NumberOfElements)
                throw new ILDimensionMismatchException("X and Y must have the same number of elements.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            // 2. Declarations
            double[] xi = (double[])XI.m_data.Clone(); // will be sorted
            double[] x = (double[])X.m_data.Clone(); // will be sorted
            double[] y = Y.m_data;
            
            double[] yi = ILMemoryPool.Pool.New<double>(xi.Length);
            int[] oldXIPos = ILMemoryPool.Pool.New<int>(xi.Length);
            int[] oldXPos = ILMemoryPool.Pool.New<int>(x.Length);

            double xLeft, xRight, yLeft, yRight;
            int j = 0, k = 0;

            // 3. Order xi and x once
            for (int i = 0; i < oldXIPos.Length; i++)
                oldXIPos[i] = i;

            for (int i = 0; i < oldXPos.Length; i++)
                oldXPos[i] = i;

            Array.Sort(xi, oldXIPos);
            Array.Sort(x, oldXPos);

            // 4. Interpolate for each XI
            for (int i = 0; i < xi.Length; i++)
            {
                // 5. Locate grid square
                for (; j < x.Length; j++)
                    if (xi[i] <= x[j])
                        break;

                if (j == x.Length) {
                    yi[oldXIPos[i]] = double.NaN;
                    continue;
                }

                k = (xi[i] == x[j]) ? j : j - 1;

                if (k < 0) {
                    yi[oldXIPos[i]] = double.NaN;
                    continue;
                }

                xRight = x[j]; yRight = y[oldXPos[j]];
                xLeft = x[k];  yLeft = y[oldXPos[k]];

                // 6. Perform linear interpolation calculation
                // TODO: (xi-xLeft).isnan check missing
                if (xLeft != xRight)
                    yi[oldXIPos[i]] = yLeft + ((xi[i] - xLeft) / (xRight - xLeft)) * (yRight - yLeft);
                else
                    yi[oldXIPos[i]] = yLeft;
            }

            return new ILArray<double>(yi, XI.m_dimensions);
        }
        /// <summary>Linear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into Y.</param>
        /// <param name="Y">The table values: Y = f(X). Must have the same number of elements as X.</param>
        /// <param name="XI">X component of point to interpolate.</param>
        /// <returns>Scalar value interpolated at XI: YI ~= f(XI).</returns>
        public static ILArray<double> linearInterp1D(ILArray<double> X, ILArray<double> Y, double xi)
        {
            // 1. Input checking
            if (X.m_dimensions.NumberOfElements != Y.m_dimensions.NumberOfElements)
                throw new ILDimensionMismatchException("X and Y must have the same number of elements.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            // 2. Declarations
            double[] x = X.m_data;
            double[] y = Y.m_data;
            double[] yi = new double[1];

            double xLeft, xRight, yLeft, yRight;
            int xLeftIdx, xRightIdx;

            // 3. Locate grid square
            xRight = smallestElementGreaterThan(xi, x, out xRightIdx);
            xLeft = greatestElementLessThan(xi, x, out xLeftIdx);

            if (xLeftIdx < 0 || xRightIdx < 0) {
                yi[0] = double.NaN;
                goto Finish;
            }

            yRight = y[xRightIdx]; yLeft = y[xLeftIdx];

            // 4. Perform linear interpolation calculation
            // TODO: (xi-xLeft).isnan check missing
            if (xLeft != xRight)
                yi[0] = yLeft + ((xi - xLeft) / (xRight - xLeft)) * (yRight - yLeft);
            else
                yi[0] = yLeft;

        Finish:
            return new ILArray<double>(yi);
        }
        /// <summary>Bilinear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into Z.</param>
        /// <param name="Y">Vector representing possible Y lookups into Z.</param>
        /// <param name="Z">The table values: Z = f(X,Y).
        /// Must be a 2D matrix with X.Count Columns and Y.Count Rows.</param>
        /// 
        /// <param name="XI">X components of points to interpolate.</param>
        /// <param name="YI">Y components of points to interpolate.</param>
        /// 
        /// <returns>Values ZI interpolated at each XI,YI: ZI ~= f(XI,YI).
        /// Will be the same size as XI.Count and YI.Count.</returns>
        public static ILArray<double> linearInterp2D(ILArray<double> X, ILArray<double> Y, ILArray<double> Z, ILArray<double> XI, ILArray<double> YI)
        {
            // 1. Input checking
            if (XI.IsEmpty)
                return new ILArray<double>();

            if (XI.IsScalar)
                return linearInterp2D(X, Y, Z, XI.m_data[0], YI.m_data[0]);

            if (X.m_dimensions.NumberOfElements != Z.m_dimensions[1] || Y.m_dimensions.NumberOfElements != Z.m_dimensions[0])
                throw new ILDimensionMismatchException("Sizes of X and Y must correspond to Z.Cols and Z.Rows respectively.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            if (XI.m_dimensions.NumberOfElements != YI.m_dimensions.NumberOfElements)
                throw new ILDimensionMismatchException("XI and YI must be the same size.");

            // 2. Declarations
            double[] x = (double[])X.m_data.Clone();
            double[] y = (double[])Y.m_data.Clone();
            double[] xi = XI.m_data;
            double[] yi = YI.m_data;

            double[] zi = ILMemoryPool.Pool.New<double>(xi.Length);
            int[] oldXPos = ILMemoryPool.Pool.New<int>(x.Length);
            int[] oldYPos = ILMemoryPool.Pool.New<int>(y.Length);

            double xLeft, xRight, yTop, yBottom;
            double zBottomLeft, zBottomRight, zTopRight, zTopLeft;
            int jx, jy, kx, ky;
            
            // 3. Order x and y once
            for (int i = 0; i < oldXPos.Length; i++)
                oldXPos[i] = i;

            for (int i = 0; i < oldYPos.Length; i++)
                oldYPos[i] = i;

            Array.Sort(x, oldXPos);
            Array.Sort(y, oldYPos);

            // 4. Interpolate for each XI/YI
            for (int i = 0; i < xi.Length; i++)
            {
                // 5. Locate grid square
                for (jx = 0; jx < x.Length; jx++)
                    if (xi[i] <= x[jx])
                        break;

                for (jy = 0; jy < y.Length; jy++)
                    if (yi[i] <= y[jy])
                        break;

                if (jx == x.Length || jy == y.Length) {
                    zi[i] = double.NaN;
                    continue;
                }

                kx = (xi[i] == x[jx]) ? jx : jx - 1;
                ky = (yi[i] == y[jy]) ? jy : jy - 1;

                if (kx < 0 || ky < 0) {
                    zi[i] = double.NaN;
                    continue;
                }

                xRight = x[jx]; xLeft = x[kx];
                yTop = y[jy]; yBottom = y[ky];

                zBottomLeft = Z.GetValue(oldYPos[ky], oldXPos[kx]);
                zBottomRight = Z.GetValue(oldYPos[ky], oldXPos[jx]);
                zTopRight = Z.GetValue(oldYPos[jy], oldXPos[jx]);
                zTopLeft = Z.GetValue(oldYPos[jy], oldXPos[kx]);

                // 6. Perform bilinear interpolation calculation
                double t = (xi[i] - xLeft) / (xRight - xLeft);
                double u = (yi[i] - yBottom) / (yTop - yBottom);

                if (double.IsNaN(t)) t = 1;
                if (double.IsNaN(u)) u = 1;

                zi[i] = (1 - t) * (1 - u) * zBottomLeft + t * (1 - u) * zBottomRight + t * u * zTopRight + (1 - t) * u * zTopLeft;
            }

            return new ILArray<double>(zi, XI.m_dimensions);
        }
        /// <summary>Bilinear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into Z.</param>
        /// <param name="Y">Vector representing possible Y lookups into Z.</param>
        /// <param name="Z">The table values: Z = f(X,Y).
        /// Must be a 2D matrix with X.Count Columns and Y.Count Rows.</param>
        /// 
        /// <param name="XI">X component of point to interpolate.</param>
        /// <param name="YI">Y component of point to interpolate.</param>
        /// <returns>Scalar value ZI interpolated at XI,YI: ZI ~= f(XI,YI).</returns>
        public static ILArray<double> linearInterp2D(ILArray<double> X, ILArray<double> Y, ILArray<double> Z, double xi, double yi)
        {
            // 1. Input checking
            if (X.m_dimensions.NumberOfElements != Z.m_dimensions[1] || Y.m_dimensions.NumberOfElements != Z.m_dimensions[0])
                throw new ILDimensionMismatchException("Sizes of X and Y must correspond to Z.Cols and Z.Rows respectively.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            // 2. Declarations
            double[] x = X.m_data;
            double[] y = Y.m_data;
            double[] zi = new double[1];

            double xLeft, xRight, yTop, yBottom;
            double zBottomLeft, zBottomRight, zTopRight, zTopLeft;
            int xLeftIdx, xRightIdx, yTopIdx, yBottomIdx;

            // 3. Locate grid square
            xRight = smallestElementGreaterThan(xi, x, out xRightIdx);
            xLeft = greatestElementLessThan(xi, x, out xLeftIdx);
            yTop = smallestElementGreaterThan(yi, y, out yTopIdx);
            yBottom = greatestElementLessThan(yi, y, out yBottomIdx);

            if (xLeftIdx < 0 || xRightIdx < 0 || yTopIdx < 0 || yBottomIdx < 0)
            {
                zi[0] = double.NaN;
                goto Finish;
            }

            zBottomLeft = Z.GetValue(yBottomIdx, xLeftIdx);
            zBottomRight = Z.GetValue(yBottomIdx, xRightIdx);
            zTopRight = Z.GetValue(yTopIdx, xRightIdx);
            zTopLeft = Z.GetValue(yTopIdx, xLeftIdx);

            // 4. Perform bilinear interpolation calculation
            double t = (xi - xLeft) / (xRight - xLeft);
            double u = (yi - yBottom) / (yTop - yBottom);

            if (double.IsNaN(t)) t = 1;
            if (double.IsNaN(u)) u = 1;

            zi[0] = (1 - t) * (1 - u) * zBottomLeft + t * (1 - u) * zBottomRight + t * u * zTopRight + (1 - t) * u * zTopLeft;

        Finish:
            return new ILArray<double>(zi);
        }
        /// <summary>Trilinear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into V.</param>
        /// <param name="Y">Vector representing possible Y lookups into V.</param>
        /// <param name="Z">Vector representing possible Z lookups into V.</param>
        /// <param name="V">The table values: V = f(X,Y,Z). Must be a 3D matrix with
        /// X.Count Rows, Y.Count Columns, and Z.Count Slabs.</param>
        /// 
        /// <param name="XI">X components of points to interpolate.</param>
        /// <param name="YI">Y components of points to interpolate.</param>
        /// <param name="ZI">Z components of points to interpolate.</param>
        /// 
        /// <returns>Values VI interpolated at each XI,YI,ZI: VI ~= f(XI,YI,ZI).
        /// Will be the same size as XI.Count, YI.Count, and ZI.Count.</returns>
        public static ILArray<double> linearInterp3D(ILArray<double> X, ILArray<double> Y, ILArray<double> Z, ILArray<double> V, ILArray<double> XI, ILArray<double> YI, ILArray<double> ZI)
        {
            // 1. Input checking
            if (XI.IsEmpty)
                return new ILArray<double>();

            if (XI.IsScalar)
                return linearInterp3D(X, Y, Z, V, XI.m_data[0], YI.m_data[0], ZI.m_data[0]);

            if (X.m_dimensions.NumberOfElements != V.m_dimensions[0] ||
                Y.m_dimensions.NumberOfElements != V.m_dimensions[1] ||
                Z.m_dimensions.NumberOfElements != V.m_dimensions[2])
                throw new ILDimensionMismatchException("Sizes of X,Y,Z must correspond to V.Rows, V.Cols, V.Slabs.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            if (XI.m_dimensions.NumberOfElements != YI.m_dimensions.NumberOfElements ||
                XI.m_dimensions.NumberOfElements != ZI.m_dimensions.NumberOfElements)
                throw new ILDimensionMismatchException("XI,YI,ZI must all be the same size.");

            // 2. Declarations
            double[] x = (double[])X.m_data.Clone();
            double[] y = (double[])Y.m_data.Clone();
            double[] z = (double[])Z.m_data.Clone();

            int[] oldXPos = ILMemoryPool.Pool.New<int>(x.Length);
            int[] oldYPos = ILMemoryPool.Pool.New<int>(y.Length);
            int[] oldZPos = ILMemoryPool.Pool.New<int>(z.Length);

            double[] xi = XI.m_data;
            double[] yi = YI.m_data;
            double[] zi = ZI.m_data;

            double[] vi = ILMemoryPool.Pool.New<double>(xi.Length);

            double xb, xa, yb, ya, zb, za;
            double Vaaa, Vaab, Vaba, Vbaa, Vabb, Vbba, Vbab, Vbbb;
            int jx, jy, kx, ky, jz, kz;

            // 3. Order x, y, and z once
            for (int i = 0; i < oldXPos.Length; i++)
                oldXPos[i] = i;

            for (int i = 0; i < oldYPos.Length; i++)
                oldYPos[i] = i;

            for (int i = 0; i < oldZPos.Length; i++)
                oldZPos[i] = i;

            Array.Sort(x, oldXPos);
            Array.Sort(y, oldYPos);
            Array.Sort(z, oldZPos);

            // 4. Interpolate for each XI/YI
            for (int i = 0; i < xi.Length; i++)
            {
                // 5. Locate grid square
                for (jx = 0; jx < x.Length; jx++)
                    if (xi[i] <= x[jx])
                        break;

                for (jy = 0; jy < y.Length; jy++)
                    if (yi[i] <= y[jy])
                        break;

                for (jz = 0; jz < z.Length; jz++)
                    if (zi[i] <= z[jz])
                        break;

                if (jx == x.Length || jy == y.Length || jz == z.Length)
                {
                    vi[i] = double.NaN;
                    continue;
                }

                kx = (xi[i] == x[jx]) ? jx : jx - 1;
                ky = (yi[i] == y[jy]) ? jy : jy - 1;
                kz = (zi[i] == z[jz]) ? jz : jz - 1;

                if (kx < 0 || ky < 0 || kz < 0)
                {
                    vi[i] = double.NaN;
                    continue;
                }

                xb = x[jx]; xa = x[kx];
                yb = y[jy]; ya = y[ky];
                zb = z[jz]; za = z[kz];

                Vaaa = V.GetValue(oldXPos[kx], oldYPos[ky], oldZPos[kz]);
                Vaab = V.GetValue(oldXPos[kx], oldYPos[ky], oldZPos[jz]);
                Vaba = V.GetValue(oldXPos[kx], oldYPos[jy], oldZPos[kz]);
                Vbaa = V.GetValue(oldXPos[jx], oldYPos[ky], oldZPos[kz]);
                Vabb = V.GetValue(oldXPos[kx], oldYPos[jy], oldZPos[jz]);
                Vbba = V.GetValue(oldXPos[jx], oldYPos[jy], oldZPos[kz]);
                Vbab = V.GetValue(oldXPos[jx], oldYPos[ky], oldZPos[jz]);
                Vbbb = V.GetValue(oldXPos[jx], oldYPos[jy], oldZPos[jz]);

                // 6. Perform trilinear interpolation calculation
                double Xin = (xi[i] - xa) / (xb - xa);
                double Yin = (yi[i] - ya) / (yb - ya);
                double Zin = (zi[i] - za) / (zb - za);

                if (double.IsNaN(Xin)) Xin = 1;
                if (double.IsNaN(Yin)) Yin = 1;
                if (double.IsNaN(Zin)) Zin = 1;

                vi[i] = Vaaa * (1 - Xin) * (1 - Yin) * (1 - Zin) +
                        Vaab * (1 - Xin) * (1 - Yin) * Zin +
                        Vaba * (1 - Xin) * Yin * (1 - Zin) +
                        Vbaa * Xin * (1 - Yin) * (1 - Zin) +
                        Vabb * (1 - Xin) * Yin * Zin +
                        Vbba * Xin * Yin * (1 - Zin) +
                        Vbab * Xin * (1 - Yin) * Zin +
                        Vbbb * Xin * Yin * Zin;
            }

            return new ILArray<double>(vi, XI.m_dimensions);
        }
        /// <summary>Trilinear Interpolation</summary>
        /// <param name="X">Vector representing possible X lookups into V.</param>
        /// <param name="Y">Vector representing possible Y lookups into V.</param>
        /// <param name="Z">Vector representing possible Z lookups into V.</param>
        /// <param name="V">The table values: V = f(X,Y,Z). Must be a 3D matrix with
        /// X.Count Rows, Y.Count Columns, and Z.Count Slabs.</param>
        /// 
        /// <param name="XI">X component of point to interpolate.</param>
        /// <param name="YI">Y component of point to interpolate.</param>
        /// <param name="ZI">Z component of point to interpolate.</param>
        /// 
        /// <returns>Scalar value VI interpolated at XI,YI,ZI: VI ~= f(XI,YI,ZI).</returns>
        public static ILArray<double> linearInterp3D(ILArray<double> X, ILArray<double> Y, ILArray<double> Z, ILArray<double> V, double xi, double yi, double zi)
        {
            // 1. Input checking
            if (X.m_dimensions.NumberOfElements != V.m_dimensions[0] ||
                Y.m_dimensions.NumberOfElements != V.m_dimensions[1] ||
                Z.m_dimensions.NumberOfElements != V.m_dimensions[2])
                throw new ILDimensionMismatchException("Sizes of X,Y,Z must correspond to V.Rows, V.Cols, V.Slabs.");

            if (X.m_data.Length < 2)
                throw new ILArgumentSizeException("There must be at least 2 data points to perform interpolation.");

            // 2. Declarations
            double[] x = X.m_data;
            double[] y = Y.m_data;
            double[] z = Z.m_data;
            double[] vi = new double[1];

            double xb, xa, yb, ya, zb, za;
            double Vaaa, Vaab, Vaba, Vbaa, Vabb, Vbba, Vbab, Vbbb;
            int xbIdx, xaIdx, ybIdx, yaIdx, zbIdx, zaIdx;

            // 3. Locate grid square
            xb = smallestElementGreaterThan(xi, x, out xbIdx);
            xa = greatestElementLessThan(xi, x, out xaIdx);
            yb = smallestElementGreaterThan(yi, y, out ybIdx);
            ya = greatestElementLessThan(yi, y, out yaIdx);
            zb = smallestElementGreaterThan(zi, z, out zbIdx);
            za = greatestElementLessThan(zi, z, out zaIdx);

            if (xaIdx < 0 || xbIdx < 0 || yaIdx < 0 || ybIdx < 0 || za < 0 || zb < 0)
            {
                vi[0] = double.NaN;
                goto Finish;
            }

            Vaaa = V.GetValue(xaIdx, yaIdx, zaIdx);
            Vaab = V.GetValue(xaIdx, yaIdx, zbIdx);
            Vaba = V.GetValue(xaIdx, ybIdx, zaIdx);
            Vbaa = V.GetValue(xbIdx, yaIdx, zaIdx);
            Vabb = V.GetValue(xaIdx, ybIdx, zbIdx);
            Vbba = V.GetValue(xbIdx, ybIdx, zaIdx);
            Vbab = V.GetValue(xbIdx, yaIdx, zbIdx);
            Vbbb = V.GetValue(xbIdx, ybIdx, zbIdx);

            // 4. Perform trilinear interpolation calculation
            double Xin = (xi - xa) / (xb - xa);
            double Yin = (yi - ya) / (yb - ya);
            double Zin = (zi - za) / (zb - za);

            if (double.IsNaN(Xin)) Xin = 1;
            if (double.IsNaN(Yin)) Yin = 1;
            if (double.IsNaN(Zin)) Zin = 1;

            vi[0] = Vaaa * (1 - Xin) * (1 - Yin) * (1 - Zin) +
                    Vaab * (1 - Xin) * (1 - Yin) * Zin +
                    Vaba * (1 - Xin) * Yin * (1 - Zin) +
                    Vbaa * Xin * (1 - Yin) * (1 - Zin) +
                    Vabb * (1 - Xin) * Yin * Zin +
                    Vbba * Xin * Yin * (1 - Zin) +
                    Vbab * Xin * (1 - Yin) * Zin +
                    Vbbb * Xin * Yin * Zin;

        Finish:
            return new ILArray<double>(vi);
        }

        #region Interpolation Helpers
        private static double smallestElementGreaterThan(double x, double[] listToSearch, out int idx)
        {
            double SEGT = double.PositiveInfinity;
            idx = -1;

            for (int i = 0; i < listToSearch.Length; i++) {
                if (listToSearch[i] >= x && listToSearch[i] <= SEGT) {
                    SEGT = listToSearch[i];
                    idx = i;
                }
            }

            return SEGT;
        }
        private static double greatestElementLessThan(double x, double[] listToSearch, out int idx)
        {
            double GELT = double.NegativeInfinity;
            idx = -1;

            for (int i = 0; i < listToSearch.Length; i++)
            {
                if (listToSearch[i] <= x && listToSearch[i] >= GELT)
                {
                    GELT = listToSearch[i];
                    idx = i;
                }
            }

            return GELT;
        }
        #endregion
    }
}