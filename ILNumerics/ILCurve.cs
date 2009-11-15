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
using System.IO; 
using System.Runtime.Serialization; 
using System.Runtime.CompilerServices;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions; 


namespace ILNumerics
{
    /// <summary>
    /// An association of an ILArray<double> X and ILArray<double> Y for interpolation,
    /// curve fitting, etc.
    /// </summary>
    /// <typeparam name="BaseT">Inner type. This will mostly be a system numeric type or a 
    /// complex floating point type.</typeparam>
    /// <remarks>
    /// Class is generic, but is typically only useful for floats and complex float types
    /// because the class is to provide interpolation and fitting functionality
    /// </remarks>
    [Serializable]
    public class ILCurve<BaseT>
    {
        #region Common
        protected ILArray<BaseT> x, y;
        protected int n;

        /// <summary>
        /// Constructor for ILCurve
        /// </summary>
        /// <param name="x">Vector of X values for the Curve</param>
        /// <param name="y">Vector of Y values for the Curve</param>
        /// <remarks></remarks>
        public ILCurve(ILArray<BaseT> x, ILArray<BaseT> y)
        {
            this.x = x; this.y = y;
            Validate();
            n = x.Length;
        }

        /// <summary>
        /// X vector of Curve
        /// </summary>
        /// <returns>X vector as ILArray
        /// </returns>
        /// <remarks></remarks>
        public ILArray<BaseT> X
        {
            get { return x; }
        }

        /// <summary>
        /// Y vector of Curve
        /// </summary>
        /// <returns>Y vector as ILArray
        /// </returns>
        /// <remarks></remarks>
        public ILArray<BaseT> Y
        {
            get { return y; }
        }

        /// <summary>
        /// Length
        /// </summary>
        /// <returns>Length of Curve
        /// </returns>
        /// <remarks></remarks>
        public int Length
        {
            get { return n; }
        }

        protected void Validate()
        {
            if (!x.IsVector || !y.IsVector)
            {
                throw new ILArgumentException("Components must be vectors");
            }
            else if (x.Length != y.Length)
            {
                throw new ILArgumentException("Component vector's lengths must be equal");
            }
        }
        #endregion

        /// <summary>Boundary types for Curve interpolation</summary>
        /// <remarks>
        /// </remarks>
        public enum BoundaryType { Parabolic, FirstDerivativeSpecified, SecondDerivativeSpecified }

        /// <summary>Sort a curve ascending in preparation for interpolation</summary>
        /// <remarks><para></para>
        /// </remarks>
        public void Sort()
        {
            if (this is ILCurve<double>)
            {
                ILArray<double> indices;
                ILArray<double> xSorted = ILMath.sort(x as ILArray<double>, out indices, 0, false);
                ILArray<double> ySorted = (y as ILArray<double>)[indices];
                x = xSorted as ILArray<BaseT>;
                x = ySorted as ILArray<BaseT>;
            }
        }

        // Calculation coefficients once, interpolate multiple times
        // Different sets for different interpolation types to allow simultaneous use
        private double[] linearSplineCoefficients = null;
        private double[] cubicSplineCoefficients = null;
        private double[] monotoneCubicSplineCoefficients = null;
        private double[] hermiteSplineCoefficients = null;

        /// <summary>Calculates interpolated values using Linear Interpolation</summary>
        /// <param name="x">X values at which interpolated values are required</param>
        /// <returns>Interpolated Y values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesLinear(ILArray<double> xi)
        {
            if (this is ILCurve<double>)
            {
                if (linearSplineCoefficients == null) UpdateLinearSplineCoefficients();

                ILArray<double> interpolatedValues = new ILArray<double>(xi.Length);
                double[] interpolatedValuesInternal = interpolatedValues.InternalArray4Experts;
                double[] xiInternal = xi.InternalArray4Experts;
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                for (int i = 0; i < xi.Length; ++i)
                {
                    double xit = xiInternal[i];
                    int p = 0; int r = n - 1; int q = 0;
                    while (p != r - 1)
                    {
                        q = (p + r) / 2;
                        if (xInternal[q] >= xit) r = q;
                        else p = q;
                    }
                    xit = xit - xInternal[p];
                    q = p * 2;
                    interpolatedValuesInternal[i] = linearSplineCoefficients[q] + xit * linearSplineCoefficients[q + 1];
                }
                return interpolatedValues;
            }
            else return new ILArray<double>();
        }

        /// <summary>Calculates interpolated values using default cubic interpolation which is Monotone Piecewise Cubic Hermite Interpolation</summary>
        /// <param name="xi">X values at which interpolated values are required</param>
        /// <returns>Interpolated Y values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesCubic(ILArray<double> xi)
        {
            return GetValuesMonotoneCubicSpline(xi);
        }

        /// <summary>Calculates interpolated values using Cubic Spline Interpolation</summary>
        /// <param name="xi">X values at which interpolated values are required</param>
        /// <returns>Interpolated Y values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesSpline(ILArray<double> xi)
        {
            return GetValuesCubicSpline(xi);
        }

        /// <summary>Calculates interpolated values using 'natural' Cubic Spline Interpolation</summary>
        /// <param name="xi">X values at which interpolated values are required</param>
        /// <returns>Interpolated values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesCubicSpline(ILArray<double> xi)
        {
            return GetValuesCubicSpline(xi, BoundaryType.SecondDerivativeSpecified, 0.0,
            BoundaryType.SecondDerivativeSpecified, 0.0);
        }

        /// <summary>Calculates interpolated values using Cubic Spline Interpolation</summary>
        /// <param name="xi">X values at which interpolated values are required</param>
        /// <param name="leftBoundaryType">BoundaryType enumeration (Parabolic, FirstDerivative Specified, SecondDerivative Specified)</param>
        /// <param name="leftBoundaryTypeParameter">Parameter required (ignored if Parabolic)</param>
        /// <param name="rightBoundaryType">BoundaryType enumeration (Parabolic, FirstDerivative Specified, SecondDerivative Specified)</param>
        /// <param name="rightBoundaryTypeParameter">Parameter required (ignored if Parabolic)</param>
        /// <returns>Interpolated values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesCubicSpline(ILArray<double> xi, BoundaryType leftBoundaryType, double leftBoundaryTypeParameter,
            BoundaryType rightBoundaryType, double rightBoundaryTypeParameter)
        {
            if (this is ILCurve<double>)
            {
                if (cubicSplineCoefficients == null) UpdateCubicSplineCoefficients(leftBoundaryType, leftBoundaryTypeParameter, rightBoundaryType, rightBoundaryTypeParameter);

                ILArray<double> interpolatedValues = new ILArray<double>(xi.Length);
                double[] interpolatedValuesInternal = interpolatedValues.InternalArray4Experts;
                double[] xiInternal = xi.InternalArray4Experts;
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                for (int i = 0; i < xi.Length; ++i)
                {
                    double xit = xiInternal[i];
                    int p = 0; int r = n - 1; int q = 0;
                    while (p != r - 1)
                    {
                        q = (p + r) / 2;
                        if (xInternal[q] >= xit) r = q;
                        else p = q;
                    }
                    xit = xit - xInternal[p];
                    q = p * 4;
                    interpolatedValuesInternal[i] = cubicSplineCoefficients[q] + xit * (cubicSplineCoefficients[q + 1]
                        + xit * (cubicSplineCoefficients[q + 2] + xit * cubicSplineCoefficients[q + 3]));
                }
                return interpolatedValues;
            }
            else return new ILArray<double>();
        }

        /// <summary>Calculates interpolated values using Monotone Piecewise Cubic Hermite Interpolation</summary>
        /// <param name="xi">X values at which interpolated values are required</param>
        /// <returns>Interpolated values </returns>
        /// <remarks><para></para>
        /// </remarks>
        public ILArray<double> GetValuesMonotoneCubicSpline(ILArray<double> xi)
        {
            if (this is ILCurve<double>)
            {
                if (monotoneCubicSplineCoefficients == null) UpdateMonotoneCubicSplineCoefficients();

                ILArray<double> interpolatedValues = new ILArray<double>(xi.Length);
                double[] interpolatedValuesInternal = interpolatedValues.InternalArray4Experts;
                double[] xiInternal = xi.InternalArray4Experts;
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                for (int i = 0; i < xi.Length; ++i)
                {
                    double xit = xiInternal[i];
                    int p = 0; int r = n - 1; int q = 0;
                    while (p != r - 1)
                    {
                        q = (p + r) / 2;
                        if (xInternal[q] >= xit) r = q;
                        else p = q;
                    }
                    xit = xit - xInternal[p];
                    q = p * 4;
                    interpolatedValuesInternal[i] = monotoneCubicSplineCoefficients[q] + xit * (monotoneCubicSplineCoefficients[q + 1]
                        + xit * (monotoneCubicSplineCoefficients[q + 2] + xit * monotoneCubicSplineCoefficients[q + 3]));
                }
                return interpolatedValues;
            }
            else return new ILArray<double>();
        }

        /// <summary>Update or create coefficients for linear spline</summary>
        public void UpdateLinearSplineCoefficients()
        {
            if (this is ILCurve<double>)
            {
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                double[] yInternal = (y as ILArray<double>).InternalArray4Experts;
                linearSplineCoefficients = new double[2 * n];
                for (int i = 0; i <= n - 2; i++)
                {
                    linearSplineCoefficients[2 * i + 0] = yInternal[i];
                    linearSplineCoefficients[2 * i + 1] = (yInternal[i + 1] - yInternal[i]) / (xInternal[i + 1] - xInternal[i]);
                }
            }
        }

        /// <summary>Update or create coefficients for cubic spline</summary>
        public void UpdateCubicSplineCoefficients(BoundaryType leftBoundaryType, double leftBoundaryTypeParameter,
            BoundaryType rightBoundaryType, double rightBoundaryTypeParameter)
        {
            if (this is ILCurve<double>)
            {
                // TODO Raise error if < 2 points

                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                double[] yInternal = (y as ILArray<double>).InternalArray4Experts;

                double[] a1 = new double[n];
                double[] a2 = new double[n];
                double[] a3 = new double[n];
                double[] b = new double[n];
                double[] deriv = new double[n];

                // If 2 points, apply parabolic end conditions
                if (n == 2)
                {
                    leftBoundaryType = BoundaryType.Parabolic;
                    rightBoundaryType = BoundaryType.Parabolic;
                }

                #region LeftBoundary
                if (leftBoundaryType == BoundaryType.Parabolic)
                {
                    a1[0] = 0;
                    a2[0] = 1;
                    a3[0] = 1;
                    b[0] = 2 * (yInternal[1] - yInternal[0]) / (xInternal[1] - xInternal[0]);
                }
                if (leftBoundaryType == BoundaryType.FirstDerivativeSpecified)
                {
                    a1[0] = 0;
                    a2[0] = 1;
                    a3[0] = 0;
                    b[0] = leftBoundaryTypeParameter;
                }
                if (leftBoundaryType == BoundaryType.SecondDerivativeSpecified)
                {
                    a1[0] = 0;
                    a2[0] = 2;
                    a3[0] = 1;
                    b[0] = 3 * (yInternal[1] - yInternal[0]) / (xInternal[1] - xInternal[0]) - 0.5 * leftBoundaryTypeParameter * (xInternal[1] - xInternal[0]);
                }
                #endregion

                for (int i = 1; i <= n - 2; i++)
                {
                    a1[i] = xInternal[i + 1] - xInternal[i];
                    a2[i] = 2 * (xInternal[i + 1] - xInternal[i - 1]);
                    a3[i] = xInternal[i] - xInternal[i - 1];
                    b[i] = 3 * ((yInternal[i] - yInternal[i - 1]) / a3[i]) * a1[i]
                        + 3 * ((yInternal[i + 1] - yInternal[i]) / a1[i]) * a3[i];
                }

                #region RightBoundary
                if (rightBoundaryType == BoundaryType.Parabolic)
                {
                    a1[n - 1] = 1;
                    a2[n - 1] = 1;
                    a3[n - 1] = 0;
                    b[n - 1] = 2 * (yInternal[n - 1] - yInternal[n - 2]) / (xInternal[n - 1] - xInternal[n - 2]);
                }
                if (rightBoundaryType == BoundaryType.FirstDerivativeSpecified)
                {
                    a1[n - 1] = 0;
                    a2[n - 1] = 1;
                    a3[n - 1] = 0;
                    b[n - 1] = rightBoundaryTypeParameter;
                }
                if (rightBoundaryType == BoundaryType.SecondDerivativeSpecified)
                {
                    a1[n - 1] = 1;
                    a2[n - 1] = 2;
                    a3[n - 1] = 0;
                    b[n - 1] = 3 * (yInternal[n - 1] - yInternal[n - 2]) / (xInternal[n - 1] - xInternal[n - 2])
                        + 0.5 * rightBoundaryTypeParameter * (xInternal[n - 1] - xInternal[n - 2]);
                }
                #endregion

                double temp = 0;

                a1[0] = 0;
                a3[n - 1] = 0;
                for (int i = 1; i <= n - 1; i++)
                {
                    temp = a1[i] / a2[i - 1];
                    a2[i] = a2[i] - temp * a3[i - 1];
                    b[i] = b[i] - temp * b[i - 1];
                }
                deriv[n - 1] = b[n - 1] / a2[n - 1];
                for (int i = n - 2; i >= 0; i--)
                {
                    deriv[i] = (b[i] - a3[i] * deriv[i + 1]) / a2[i];
                }

                cubicSplineCoefficients = GetHermiteSplineCoefficients(deriv);
            }
        }

        protected double[] GetHermiteSplineCoefficients(double[] deriv)
        {
            if (this is ILCurve<double>)
            {
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                double[] yInternal = (y as ILArray<double>).InternalArray4Experts;
                double delta = 0;
                double delta2 = 0;
                double delta3 = 0;
                double[] coeffs = new double[(n - 1) * 4];
                for (int i = 0; i <= n - 2; i++)
                {
                    delta = xInternal[i + 1] - xInternal[i];
                    delta2 = delta * delta;
                    delta3 = delta * delta2;
                    coeffs[4 * i + 0] = yInternal[i];
                    coeffs[4 * i + 1] = deriv[i];
                    coeffs[4 * i + 2] = (3 * (yInternal[i + 1] - yInternal[i]) - 2 * deriv[i] * delta - deriv[i + 1] * delta) / delta2;
                    coeffs[4 * i + 3] = (2 * (yInternal[i] - yInternal[i + 1]) + deriv[i] * delta + deriv[i + 1] * delta) / delta3;
                }
                return coeffs;
            }
            else return null;
        }

        /// <summary>Update or create coefficients for monotone cubic spline</summary>
        public void UpdateMonotoneCubicSplineCoefficients()
        {
            if (this is ILCurve<double>)
            {
                double[] xInternal = (x as ILArray<double>).InternalArray4Experts;
                double[] yInternal = (y as ILArray<double>).InternalArray4Experts;
                double[] a1 = new double[n]; // secant
                double[] a2 = new double[n]; // derivative
                a1[0] = (yInternal[1] - yInternal[0]) / (xInternal[1] - xInternal[0]);
                a2[0] = a1[0];
                for (int i = 1; i < n - 3; i++)
                {
                    a1[i] = (yInternal[i + 1] - yInternal[i]) / (xInternal[i + 1] - xInternal[i]);
                    a2[i] = (a1[i - 1] + a1[i]) / 2.0;
                }
                a1[n - 2] = (yInternal[n - 1] - yInternal[n - 2]) / (xInternal[n - 1] - xInternal[n - 2]);
                a2[n - 2] = (a1[n - 3] + a1[n - 2]) / 2.0;
                a2[n - 1] = a1[n - 2];
                double alpha, beta, dist, tau;
                for (int i = 0; i < n - 2; i++)
                {
                    alpha = a2[i] / a1[i];
                    beta = a2[i + 1] / a1[i];
                    dist = alpha * alpha + beta * beta;
                    if (dist > 9.0)
                    {
                        tau = 3.0 / Math.Sqrt(dist);
                        a2[i] = tau * alpha * a1[i];
                        a2[i + 1] = tau * beta * a1[i];
                    }
                }
                monotoneCubicSplineCoefficients = GetHermiteSplineCoefficients(a2);
            }
        }
    }
}
