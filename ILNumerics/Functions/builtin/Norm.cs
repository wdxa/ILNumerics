//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
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
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>double</destination>
    <destination>float</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="nextline">
        cmplxDiag
    </source>
    <destination>return sqrt(sum(real(diag(multiply(X, X[1])))));</destination>
    <destination>return sqrt(sum(diag(multiply(X, X[1]))));</destination>
    <destination>return sqrt(sum(real(diag(multiply(X, X[1])))));</destination>
</type></hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <returns> for matrices: </returns>
        /// <remarks>this internally calls: norm(X,2)</remarks>
        public static /*!HC:outCls1*/ ILArray<double> norm(/*!HC:inCls1*/ ILArray<double> X) {
            return norm(X, 2);
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <param name="degree">degree of norm. For vectors this must be one of: 
        /// <list type="bullet">
        /// <item>arbitrary double value : returns sum(pow(abs(X),degree))^(1/degree)</item>
        /// <item>System.double.PositiveInfinity: return Max(abs(X))</item>
        /// <item>System.double.NegativeInfinity: return Min(abs(X))</item>
        /// </list>
        /// For matrices this must be one of: 
        /// <list type="bullet">
        /// <item>0: returns Frobenius norm: sqrt(sum(diag(multiply(X, X[1]))))</item>
        /// <item>1: returns 1-norm, max(sum(abs(X)))</item>
        /// <item>2: returns the largest singular value of X, max(svd(X))</item>
        /// <item>PositiveInfinity: returns max(sum(abs(X), 2)), the largest value of the sums along the rows.</item>
        /// </list>
        /// </param>
        /// <returns>new solid Array of same type as input array X with the norm.
        /// This function is supported for the following ILArray<![CDATA[<>]]> types: /*!HC:ENUM:inCls1*/ <![CDATA[ ILArray<complex>, ILArray<float>, ILArray<fcomplex>]]> /*!HC:/ENUM*/</returns>
        public static /*!HC:outCls1*/ ILArray<double> norm(/*!HC:inCls1*/ ILArray<double> X, double degree) {
            if (Object.Equals(X, null) || X.Dimensions.NumberOfDimensions > 2)
                throw new ILArgumentSizeException("norm: input array must be matrix or vector.");
            if (X.IsEmpty) 
                return /*!HC:outCls1*/ ILArray<double> .zeros(1,1); 
            else if (X.IsVector) {
                if (degree == Double.PositiveInfinity) {
                    return max(abs(X));
                } else if (degree == Double.NegativeInfinity) {
                    return min(abs(X));
                } else {
                    if (degree == 0.0) 
                        return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:outArr1*/ double [1]{( /*!HC:outArr1*/ double )Double.PositiveInfinity},1,1); 
                    return pow(sum(pow(abs(X),( /*!HC:outArr1*/ double )degree)),( /*!HC:outArr1*/ double )(1/degree)); 
                }
            } else {
                if (degree == 1.0) {
                    return max(sum(abs(X)));
                } else if (degree == 2.0) {
                    return max(svd(X));
                } else if (degree == Double.PositiveInfinity) {
                    return max(sum(abs(X), 2));
                } else if (degree == 0.0) {
                    /*!HC:cmplxDiag*/
                    return sqrt(sum(diag(multiply(X, X[1]))));
                } else {
                    throw new ILArgumentException("norm: Invalid argument 'degree' supplied. valid for matrices: 0,1,2,Double.PositiveInfinity");
                }
            }
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <returns> for matrices: </returns>
        /// <remarks>this internally calls: norm(X,2)</remarks>
        public static  ILArray<float> norm( ILArray<fcomplex> X) {
            return norm(X, 2);
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <param name="degree">degree of norm. For vectors this must be one of: 
        /// <list type="bullet">
        /// <item>arbitrary double value : returns sum(pow(abs(X),degree))^(1/degree)</item>
        /// <item>System.double.PositiveInfinity: return Max(abs(X))</item>
        /// <item>System.double.NegativeInfinity: return Min(abs(X))</item>
        /// </list>
        /// For matrices this must be one of: 
        /// <list type="bullet">
        /// <item>0: returns Frobenius norm: sqrt(sum(diag(multiply(X, X[1]))))</item>
        /// <item>1: returns 1-norm, max(sum(abs(X)))</item>
        /// <item>2: returns the largest singular value of X, max(svd(X))</item>
        /// <item>PositiveInfinity: returns max(sum(abs(X), 2)), the largest value of the sums along the rows.</item>
        /// </list>
        /// </param>
        /// <returns>new solid Array of same type as input array X with the norm.
        /// This function is supported for the following ILArray<![CDATA[<>]]> types:  <![CDATA[ ILArray<complex>, ILArray<float>, ILArray<fcomplex>]]> </returns>
        public static  ILArray<float> norm( ILArray<fcomplex> X, double degree) {
            if (Object.Equals(X, null) || X.Dimensions.NumberOfDimensions > 2)
                throw new ILArgumentSizeException("norm: input array must be matrix or vector.");
            if (X.IsEmpty) 
                return  ILArray<float> .zeros(1,1); 
            else if (X.IsVector) {
                if (degree == Double.PositiveInfinity) {
                    return max(abs(X));
                } else if (degree == Double.NegativeInfinity) {
                    return min(abs(X));
                } else {
                    if (degree == 0.0) 
                        return new  ILArray<float> (new  float [1]{(  float )Double.PositiveInfinity},1,1); 
                    return pow(sum(pow(abs(X),(  float )degree)),(  float )(1/degree)); 
                }
            } else {
                if (degree == 1.0) {
                    return max(sum(abs(X)));
                } else if (degree == 2.0) {
                    return max(svd(X));
                } else if (degree == Double.PositiveInfinity) {
                    return max(sum(abs(X), 2));
                } else if (degree == 0.0) {
                    return sqrt(sum(real(diag(multiply(X, X[1])))));
                } else {
                    throw new ILArgumentException("norm: Invalid argument 'degree' supplied. valid for matrices: 0,1,2,Double.PositiveInfinity");
                }
            }
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <returns> for matrices: </returns>
        /// <remarks>this internally calls: norm(X,2)</remarks>
        public static  ILArray<float> norm( ILArray<float> X) {
            return norm(X, 2);
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <param name="degree">degree of norm. For vectors this must be one of: 
        /// <list type="bullet">
        /// <item>arbitrary double value : returns sum(pow(abs(X),degree))^(1/degree)</item>
        /// <item>System.double.PositiveInfinity: return Max(abs(X))</item>
        /// <item>System.double.NegativeInfinity: return Min(abs(X))</item>
        /// </list>
        /// For matrices this must be one of: 
        /// <list type="bullet">
        /// <item>0: returns Frobenius norm: sqrt(sum(diag(multiply(X, X[1]))))</item>
        /// <item>1: returns 1-norm, max(sum(abs(X)))</item>
        /// <item>2: returns the largest singular value of X, max(svd(X))</item>
        /// <item>PositiveInfinity: returns max(sum(abs(X), 2)), the largest value of the sums along the rows.</item>
        /// </list>
        /// </param>
        /// <returns>new solid Array of same type as input array X with the norm.
        /// This function is supported for the following ILArray<![CDATA[<>]]> types:  <![CDATA[ ILArray<complex>, ILArray<float>, ILArray<fcomplex>]]> </returns>
        public static  ILArray<float> norm( ILArray<float> X, double degree) {
            if (Object.Equals(X, null) || X.Dimensions.NumberOfDimensions > 2)
                throw new ILArgumentSizeException("norm: input array must be matrix or vector.");
            if (X.IsEmpty) 
                return  ILArray<float> .zeros(1,1); 
            else if (X.IsVector) {
                if (degree == Double.PositiveInfinity) {
                    return max(abs(X));
                } else if (degree == Double.NegativeInfinity) {
                    return min(abs(X));
                } else {
                    if (degree == 0.0) 
                        return new  ILArray<float> (new  float [1]{(  float )Double.PositiveInfinity},1,1); 
                    return pow(sum(pow(abs(X),(  float )degree)),(  float )(1/degree)); 
                }
            } else {
                if (degree == 1.0) {
                    return max(sum(abs(X)));
                } else if (degree == 2.0) {
                    return max(svd(X));
                } else if (degree == Double.PositiveInfinity) {
                    return max(sum(abs(X), 2));
                } else if (degree == 0.0) {
                    return sqrt(sum(diag(multiply(X, X[1]))));
                } else {
                    throw new ILArgumentException("norm: Invalid argument 'degree' supplied. valid for matrices: 0,1,2,Double.PositiveInfinity");
                }
            }
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <returns> for matrices: </returns>
        /// <remarks>this internally calls: norm(X,2)</remarks>
        public static  ILArray<double> norm( ILArray<complex> X) {
            return norm(X, 2);
        }
        /// <summary>
        /// vector or matrix norm
        /// </summary>
        /// <param name="X">matrix/ vector</param>
        /// <param name="degree">degree of norm. For vectors this must be one of: 
        /// <list type="bullet">
        /// <item>arbitrary double value : returns sum(pow(abs(X),degree))^(1/degree)</item>
        /// <item>System.double.PositiveInfinity: return Max(abs(X))</item>
        /// <item>System.double.NegativeInfinity: return Min(abs(X))</item>
        /// </list>
        /// For matrices this must be one of: 
        /// <list type="bullet">
        /// <item>0: returns Frobenius norm: sqrt(sum(diag(multiply(X, X[1]))))</item>
        /// <item>1: returns 1-norm, max(sum(abs(X)))</item>
        /// <item>2: returns the largest singular value of X, max(svd(X))</item>
        /// <item>PositiveInfinity: returns max(sum(abs(X), 2)), the largest value of the sums along the rows.</item>
        /// </list>
        /// </param>
        /// <returns>new solid Array of same type as input array X with the norm.
        /// This function is supported for the following ILArray<![CDATA[<>]]> types:  <![CDATA[ ILArray<complex>, ILArray<float>, ILArray<fcomplex>]]> </returns>
        public static  ILArray<double> norm( ILArray<complex> X, double degree) {
            if (Object.Equals(X, null) || X.Dimensions.NumberOfDimensions > 2)
                throw new ILArgumentSizeException("norm: input array must be matrix or vector.");
            if (X.IsEmpty) 
                return  ILArray<double> .zeros(1,1); 
            else if (X.IsVector) {
                if (degree == Double.PositiveInfinity) {
                    return max(abs(X));
                } else if (degree == Double.NegativeInfinity) {
                    return min(abs(X));
                } else {
                    if (degree == 0.0) 
                        return new  ILArray<double> (new  double [1]{(  double )Double.PositiveInfinity},1,1); 
                    return pow(sum(pow(abs(X),(  double )degree)),(  double )(1/degree)); 
                }
            } else {
                if (degree == 1.0) {
                    return max(sum(abs(X)));
                } else if (degree == 2.0) {
                    return max(svd(X));
                } else if (degree == Double.PositiveInfinity) {
                    return max(sum(abs(X), 2));
                } else if (degree == 0.0) {
                    return sqrt(sum(real(diag(multiply(X, X[1])))));
                } else {
                    throw new ILArgumentException("norm: Invalid argument 'degree' supplied. valid for matrices: 0,1,2,Double.PositiveInfinity");
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
    }

}
