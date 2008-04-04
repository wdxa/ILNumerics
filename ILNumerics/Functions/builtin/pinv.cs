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
using ILNumerics.Settings;

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART 
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outClsRet
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>  
<type>
    <source locate="after">
        outClsOne
    </source>
    <destination>1.0</destination>
    <destination>1.0f</destination>
    <destination>1.0f</destination>
</type><type>
    <source locate="after">
        outClsS
    </source>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outClsU
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outClsV
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        outArrS
    </source>
    <destination>double</destination>
    <destination>float</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        outArrU
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        outArrV
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        HycalpEPS
    </source>
    <destination>ILMath.MachineParameterDouble.eps</destination>
    <destination>ILMath.MachineParameterFloat.eps</destination>
    <destination>ILMath.MachineParameterFloat.eps</destination>
</type>
<type>
    <source locate="nextline">
        lapack_dgesdd
    </source>
    <destination>Lapack.zgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
    <destination>Lapack.cgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
    <destination>Lapack.sgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
</type>
<type>
    <source locate="nextline">
        multiplyCast
    </source>
    <destination>Ret = multiply(multiply(V[":;0:" + (count - 1)], real2complex(S)), U);</destination>
    <destination>Ret = multiply(multiply(V[":;0:" + (count - 1)], real2fcomplex(S)), U);</destination>
    <destination>Ret = multiply(multiply(V[":;0:" + (count - 1)], S), U);</destination>
</type>
</hycalper>
*/

        /// <summary>
        /// pseudo - inverse of input argument M
        /// </summary>
        /// <param name="M">Matrix M</param>
        /// <returns>pseudo inverse of input matrix M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses Lapack's function svd internally. Any singular values less than 
        /// the default tolerance will be set to zero. As tolerance the following equation is used: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// You may use a overloaded function to define an alternative tolerance. 
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.pinv(ILArray&lt;double&gt;, double)"/>
        public static /*!HC:outClsRet*/ ILArray<double> pinv(/*!HC:inCls1*/ ILArray<double> M) {
            return pinv(M, -1); 
        }
        /// <summary>
        /// pseudo inverse of input matrix M
        /// </summary>
        /// <param name="M">matrix M</param>
        /// <param name="tolerance">tolerance, see remarks</param>
        /// <returns>pseudo inverse of M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses LAPACK's function svd internally. Any singular values less than 
        /// tolerance will be set to zero. If tolerance is less than zero, the following equation 
        /// is used as default: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest constructable double precision number greater than zero</item>
        /// </list>
        /// </remarks>
        public static /*!HC:outClsRet*/ ILArray<double> pinv(/*!HC:inCls1*/ ILArray<double> M, /*!HC:inArr1*/ double tolerance) {
            // let svd check the dimensions! 
            //if (M.Dimensions.NumberOfDimensions > 2)
            //   throw new ILDimensionMismatchException("pinv: ...");

            // in order to use the cheap packed version of svd, the matrix must be m x n with m > n! 
            if (M.m_dimensions[0] < M.m_dimensions[1]) {
                /*!HC:outClsRet*/ ILArray<double> ret = pinv(M.T, tolerance);
                return ret.T;
            }
            if (M.IsScalar)
                return new /*!HC:outClsRet*/ ILArray<double> (/*!HC:outClsOne*/ 1.0 / M.GetValue(0)); 

            /*!HC:outClsU*/ ILArray<double> U = /*!HC:outClsU*/ ILArray<double> .empty();
            /*!HC:outClsV*/ ILArray<double> V = /*!HC:outClsV*/ ILArray<double> .empty();
            /*!HC:outClsS*/ ILArray<double> S = svd(M, ref U, ref V, true,false); 

            int m = M.m_dimensions[0]; 
            int n = M.m_dimensions[1]; 

            /*!HC:outClsS*/ ILArray<double> s;
            switch (m) {
                case 0:
                    s =  /*!HC:outClsS*/ ILArray<double> .zeros(1,1);
                    break;
                case 1:
                    s = S[0];
                    break;
                default:
                    s = diag(S); 
                    break;
            }
            if (tolerance < 0) {
                tolerance = (/*!HC:inArr1*/ double )(M.Dimensions.Longest * max(s).GetValue(0) * /*!HC:HycalpEPS*/ MachineParameterDouble.eps );  
            }
            // sum vector elements: ret must (and should) be physical vector returned from svd
            int count = (int)sum(s> (double)tolerance);

            /*!HC:outClsRet*/ ILArray<double> Ret = null; 
            if (count == 0)
                S = /*!HC:outClsS*/ ILArray<double> .zeros(n, m);
            else {
                /*!HC:outClsS*/ ILArray<double> OneVec =  /*!HC:outClsS*/ ILArray<double> .zeros(count,1);
                OneVec = set(OneVec, /*!HC:outClsOne*/ 1.0 ); 
                S = diag(divide( OneVec,s["0:" + (count - 1)])); 
                U = U[(short)1,":;0:" + (count - 1)]; 
                /*!HC:multiplyCast*/
                Ret = multiply(multiply(V[":;0:" + (count - 1)], S), U);
            }
            return Ret;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 


        /// <summary>
        /// pseudo - inverse of input argument M
        /// </summary>
        /// <param name="M">Matrix M</param>
        /// <returns>pseudo inverse of input matrix M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses Lapack's function svd internally. Any singular values less than 
        /// the default tolerance will be set to zero. As tolerance the following equation is used: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// You may use a overloaded function to define an alternative tolerance. 
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.pinv(ILArray&lt;double&gt;, double)"/>
        public static  ILArray<float> pinv( ILArray<float> M) {
            return pinv(M, -1); 
        }
        /// <summary>
        /// pseudo inverse of input matrix M
        /// </summary>
        /// <param name="M">matrix M</param>
        /// <param name="tolerance">tolerance, see remarks</param>
        /// <returns>pseudo inverse of M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses LAPACK's function svd internally. Any singular values less than 
        /// tolerance will be set to zero. If tolerance is less than zero, the following equation 
        /// is used as default: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest constructable double precision number greater than zero</item>
        /// </list>
        /// </remarks>
        public static  ILArray<float> pinv( ILArray<float> M,  float tolerance) {
            // let svd check the dimensions! 
            //if (M.Dimensions.NumberOfDimensions > 2)
            //   throw new ILDimensionMismatchException("pinv: ...");

            // in order to use the cheap packed version of svd, the matrix must be m x n with m > n! 
            if (M.m_dimensions[0] < M.m_dimensions[1]) {
                ILArray<float> ret = pinv(M.T, tolerance);
                return ret.T;
            }
            if (M.IsScalar)
                return new  ILArray<float> ( 1.0f / M.GetValue(0)); 

            ILArray<float> U =  ILArray<float> .empty();
            ILArray<float> V =  ILArray<float> .empty();
            ILArray<float> S = svd(M, ref U, ref V, true,false); 

            int m = M.m_dimensions[0]; 
            int n = M.m_dimensions[1]; 

            ILArray<float> s;
            switch (m) {
                case 0:
                    s =  ILArray<float> .zeros(1,1);
                    break;
                case 1:
                    s = S[0];
                    break;
                default:
                    s = diag(S); 
                    break;
            }
            if (tolerance < 0) {
                tolerance = ( float )(M.Dimensions.Longest * max(s).GetValue(0) *  ILMath.MachineParameterFloat.eps );  
            }
            // sum vector elements: ret must (and should) be physical vector returned from svd
            int count = (int)sum(s> (double)tolerance);

            ILArray<float> Ret = null; 
            if (count == 0)
                S =  ILArray<float> .zeros(n, m);
            else {
                ILArray<float> OneVec =  ILArray<float> .zeros(count,1);
                OneVec = set(OneVec,  1.0f ); 
                S = diag(divide( OneVec,s["0:" + (count - 1)])); 
                U = U[(short)1,":;0:" + (count - 1)]; 
                Ret = multiply(multiply(V[":;0:" + (count - 1)], S), U);
            }
            return Ret;
        }


        /// <summary>
        /// pseudo - inverse of input argument M
        /// </summary>
        /// <param name="M">Matrix M</param>
        /// <returns>pseudo inverse of input matrix M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses Lapack's function svd internally. Any singular values less than 
        /// the default tolerance will be set to zero. As tolerance the following equation is used: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// You may use a overloaded function to define an alternative tolerance. 
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.pinv(ILArray&lt;double&gt;, double)"/>
        public static  ILArray<fcomplex> pinv( ILArray<fcomplex> M) {
            return pinv(M, -1); 
        }
        /// <summary>
        /// pseudo inverse of input matrix M
        /// </summary>
        /// <param name="M">matrix M</param>
        /// <param name="tolerance">tolerance, see remarks</param>
        /// <returns>pseudo inverse of M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses LAPACK's function svd internally. Any singular values less than 
        /// tolerance will be set to zero. If tolerance is less than zero, the following equation 
        /// is used as default: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest constructable double precision number greater than zero</item>
        /// </list>
        /// </remarks>
        public static  ILArray<fcomplex> pinv( ILArray<fcomplex> M,  fcomplex tolerance) {
            // let svd check the dimensions! 
            //if (M.Dimensions.NumberOfDimensions > 2)
            //   throw new ILDimensionMismatchException("pinv: ...");

            // in order to use the cheap packed version of svd, the matrix must be m x n with m > n! 
            if (M.m_dimensions[0] < M.m_dimensions[1]) {
                ILArray<fcomplex> ret = pinv(M.T, tolerance);
                return ret.T;
            }
            if (M.IsScalar)
                return new  ILArray<fcomplex> ( 1.0f / M.GetValue(0)); 

            ILArray<fcomplex> U =  ILArray<fcomplex> .empty();
            ILArray<fcomplex> V =  ILArray<fcomplex> .empty();
            ILArray<float> S = svd(M, ref U, ref V, true,false); 

            int m = M.m_dimensions[0]; 
            int n = M.m_dimensions[1]; 

            ILArray<float> s;
            switch (m) {
                case 0:
                    s =  ILArray<float> .zeros(1,1);
                    break;
                case 1:
                    s = S[0];
                    break;
                default:
                    s = diag(S); 
                    break;
            }
            if (tolerance < 0) {
                tolerance = ( fcomplex )(M.Dimensions.Longest * max(s).GetValue(0) *  ILMath.MachineParameterFloat.eps );  
            }
            // sum vector elements: ret must (and should) be physical vector returned from svd
            int count = (int)sum(s> (double)tolerance);

            ILArray<fcomplex> Ret = null; 
            if (count == 0)
                S =  ILArray<float> .zeros(n, m);
            else {
                ILArray<float> OneVec =  ILArray<float> .zeros(count,1);
                OneVec = set(OneVec,  1.0f ); 
                S = diag(divide( OneVec,s["0:" + (count - 1)])); 
                U = U[(short)1,":;0:" + (count - 1)]; 
                Ret = multiply(multiply(V[":;0:" + (count - 1)], real2fcomplex(S)), U);
            }
            return Ret;
        }


        /// <summary>
        /// pseudo - inverse of input argument M
        /// </summary>
        /// <param name="M">Matrix M</param>
        /// <returns>pseudo inverse of input matrix M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses Lapack's function svd internally. Any singular values less than 
        /// the default tolerance will be set to zero. As tolerance the following equation is used: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest number greater than zero</item>
        /// </list>
        /// You may use a overloaded function to define an alternative tolerance. 
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.pinv(ILArray&lt;double&gt;, double)"/>
        public static  ILArray<complex> pinv( ILArray<complex> M) {
            return pinv(M, -1); 
        }
        /// <summary>
        /// pseudo inverse of input matrix M
        /// </summary>
        /// <param name="M">matrix M</param>
        /// <param name="tolerance">tolerance, see remarks</param>
        /// <returns>pseudo inverse of M</returns>
        /// <remarks>The function returns the pseudo inverse (Moore-Penrose pseudoinverse)
        /// of input matrix M. The return value will be of the same size as 
        /// the transposed of M. it will satisfy the following conditions: 
        /// <list type="bullet">
        /// <item>M * pinv(M) * M  = M </item>
        /// <item>pinv(M) * M * pinv(M) = pinv(M)</item>
        /// <item>pinv(M) * M is hermitian</item>
        /// <item>M * pinv(M) is hermitian</item>
        /// </list>
        /// pinv uses LAPACK's function svd internally. Any singular values less than 
        /// tolerance will be set to zero. If tolerance is less than zero, the following equation 
        /// is used as default: \\
        /// tol = length(M) * norm(M) * Double.epsilon \\
        /// with 
        /// <list type="bullet">
        /// <item>length(M) - the longest dimension of M</item>
        /// <item>norm(M) beeing the largest singular value of M, </item>
        /// <item>Double.epsilon - the smallest constructable double precision number greater than zero</item>
        /// </list>
        /// </remarks>
        public static  ILArray<complex> pinv( ILArray<complex> M,  complex tolerance) {
            // let svd check the dimensions! 
            //if (M.Dimensions.NumberOfDimensions > 2)
            //   throw new ILDimensionMismatchException("pinv: ...");

            // in order to use the cheap packed version of svd, the matrix must be m x n with m > n! 
            if (M.m_dimensions[0] < M.m_dimensions[1]) {
                ILArray<complex> ret = pinv(M.T, tolerance);
                return ret.T;
            }
            if (M.IsScalar)
                return new  ILArray<complex> ( 1.0 / M.GetValue(0)); 

            ILArray<complex> U =  ILArray<complex> .empty();
            ILArray<complex> V =  ILArray<complex> .empty();
            ILArray<double> S = svd(M, ref U, ref V, true,false); 

            int m = M.m_dimensions[0]; 
            int n = M.m_dimensions[1]; 

            ILArray<double> s;
            switch (m) {
                case 0:
                    s =  ILArray<double> .zeros(1,1);
                    break;
                case 1:
                    s = S[0];
                    break;
                default:
                    s = diag(S); 
                    break;
            }
            if (tolerance < 0) {
                tolerance = ( complex )(M.Dimensions.Longest * max(s).GetValue(0) *  ILMath.MachineParameterDouble.eps );  
            }
            // sum vector elements: ret must (and should) be physical vector returned from svd
            int count = (int)sum(s> (double)tolerance);

            ILArray<complex> Ret = null; 
            if (count == 0)
                S =  ILArray<double> .zeros(n, m);
            else {
                ILArray<double> OneVec =  ILArray<double> .zeros(count,1);
                OneVec = set(OneVec,  1.0 ); 
                S = diag(divide( OneVec,s["0:" + (count - 1)])); 
                U = U[(short)1,":;0:" + (count - 1)]; 
                Ret = multiply(multiply(V[":;0:" + (count - 1)], real2complex(S)), U);
            }
            return Ret;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
