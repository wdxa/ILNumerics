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
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
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
    <source locate="nextline">
        lapack_dgesdd
    </source>
    <destination>Lapack.zgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
    <destination>Lapack.cgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
    <destination>Lapack.sgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);</destination>
</type>
<type>
    <source locate="nextline">
        complxConj
    </source>
    <destination><![CDATA[V = conj(new  ILArray<complex> (dVT,N,dVT.Length / N).T);]]></destination>
    <destination><![CDATA[V = conj(new  ILArray<fcomplex> (dVT,N,dVT.Length / N).T);]]></destination>
    <destination><![CDATA[V = new  ILArray<float> (dVT,N,dVT.Length / N).T;]]></destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <returns>vector with min(M,N) singular values of X as column vector</returns>
        public static /*!HC:outClsS*/ ILArray<double> svd(/*!HC:inCls1*/ ILArray<double> X) {
            /*!HC:outClsU*/ ILArray<double> U = null;
            /*!HC:outClsV*/ ILArray<double> VT = null; 
            return svd(X, ref U, ref VT, false, false);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <returns>vector with min(M,N) singular values of X as column vector</returns>
        public static  ILArray<float> svd( ILArray<float> X) {
            ILArray<float> U = null;
            ILArray<float> VT = null; 
            return svd(X, ref U, ref VT, false, false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <returns>vector with min(M,N) singular values of X as column vector</returns>
        public static  ILArray<float> svd( ILArray<fcomplex> X) {
            ILArray<fcomplex> U = null;
            ILArray<fcomplex> VT = null; 
            return svd(X, ref U, ref VT, false, false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <returns>vector with min(M,N) singular values of X as column vector</returns>
        public static  ILArray<double> svd( ILArray<complex> X) {
            ILArray<complex> U = null;
            ILArray<complex> VT = null; 
            return svd(X, ref U, ref VT, false, false);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        public static /*!HC:outClsS*/ ILArray<double> svd(/*!HC:inCls1*/ ILArray<double> X, ref /*!HC:outClsU*/ ILArray<double> U) {
            /*!HC:outClsV*/ ILArray<double> VT = null;
            return svd(X, ref U, ref VT, false,false);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        public static  ILArray<float> svd( ILArray<float> X, ref  ILArray<float> U) {
            ILArray<float> VT = null;
            return svd(X, ref U, ref VT, false,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        public static  ILArray<float> svd( ILArray<fcomplex> X, ref  ILArray<fcomplex> U) {
            ILArray<fcomplex> VT = null;
            return svd(X, ref U, ref VT, false,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        public static  ILArray<double> svd( ILArray<complex> X, ref  ILArray<complex> U) {
            ILArray<complex> VT = null;
            return svd(X, ref U, ref VT, false,false);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors VT will be returned as reference array.</remarks>
        public static /*!HC:outClsS*/ ILArray<double> svd(/*!HC:inCls1*/ ILArray<double> X, ref /*!HC:outClsU*/ ILArray<double> U, bool small) {
            /*!HC:outClsV*/ ILArray<double> VT = null; 
            return svd(X, ref U, ref VT, small,false);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors VT will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<float> X, ref  ILArray<float> U, bool small) {
            ILArray<float> VT = null; 
            return svd(X, ref U, ref VT, small,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors VT will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<fcomplex> X, ref  ILArray<fcomplex> U, bool small) {
            ILArray<fcomplex> VT = null; 
            return svd(X, ref U, ref VT, small,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors VT will be returned as reference array.</remarks>
        public static  ILArray<double> svd( ILArray<complex> X, ref  ILArray<complex> U, bool small) {
            ILArray<complex> VT = null; 
            return svd(X, ref U, ref VT, small,false);
        }

#endregion HYCALPER AUTO GENERATED CODE
        
        #region HYCALPER LOOPSTART 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static /*!HC:outClsS*/ ILArray<double> svd(/*!HC:inCls1*/ ILArray<double> X, ref /*!HC:outClsU*/ ILArray<double> U, ref /*!HC:outClsV*/ ILArray<double> V) {
            return svd(X, ref U, ref V, false,false);
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<float> X, ref  ILArray<float> U, ref  ILArray<float> V) {
            return svd(X, ref U, ref V, false,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<fcomplex> X, ref  ILArray<fcomplex> U, ref  ILArray<fcomplex> V) {
            return svd(X, ref U, ref V, false,false);
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<double> svd( ILArray<complex> X, ref  ILArray<complex> U, ref  ILArray<complex> V) {
            return svd(X, ref U, ref V, false,false);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <param name="discardFiniteTest">if true: the matrix given will not be checked for infinte or NaN values. If such elements 
        /// are contained nevertheless, this may result in failing convergence or error. In worst case 
        /// the function may hang inside the Lapack lib. Use with care! </param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static /*!HC:outClsS*/ ILArray<double> svd(/*!HC:inCls1*/ ILArray<double> X, ref /*!HC:outClsU*/ ILArray<double> U, ref /*!HC:outClsV*/ ILArray<double> V, bool small, bool discardFiniteTest) {
            if (!X.IsMatrix)
                throw new ILArgumentSizeException("svd is defined for matrices only!");
            // early exit for small matrices
            if (X.Dimensions[1] < 4 && X.Dimensions[0] == X.Dimensions[1]) { 
                switch (X.Dimensions[0]) {
                    case 1: 
                        if (!Object.Equals(U,null))
                            U = (/*!HC:outArrU*/ double ) 1.0; 
                        if (!Object.Equals(V,null))
                            V = (/*!HC:outArrV*/ double ) 1.0; 
                        return new /*!HC:outClsS*/ ILArray<double> ( ILMath.abs(X)); 
                    //case 2:
                    //    return -1; 
                    //case 3: 
                    //    return -1; 
                }
            }
            if (!discardFiniteTest && !all(all(isfinite( X )))) 
                throw new ILArgumentException("svd: input must have only finite elements!");
            if (Lapack == null)
                throw new ILMathException("No Lapack package available.");
            // parameter evaluation
            int M = X.Dimensions[0]; int N = X.Dimensions[1];
            int minMN = (M < N) ? M : N;
            int LDU = M; int LDVT = N;
            int LDA = M;
            /*!HC:outArrS*/ double [] dS = new /*!HC:outArrS*/ double [minMN];
            char jobz = (small) ? 'S' : 'A';
            /*!HC:outArrU*/ double [] dU = null;
            /*!HC:outArrV*/ double [] dVT = null;
            int info = 0;
            if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                // need to return U and VT 
                if (small) {
                    dU = new /*!HC:outArrU*/ double  [M * minMN];
                    dVT = new /*!HC:outArrV*/ double [N * minMN];
                } else {
                    dU = new /*!HC:outArrU*/ double [M * M];
                    dVT = new /*!HC:outArrV*/ double [N * N];
                }
            } else {
                jobz = 'N';
            }

            if (X.IsReference) {
                X.Detach();
            }
            // must create copy of input ! 
            /*!HC:inArr1*/ double [] dInput = new /*!HC:inArr1*/ double [X.m_data.Length]; 
            System.Array.Copy(X.m_data, dInput, X.m_data.Length);
            /*!HC:lapack_dgesdd*/
            Lapack.dgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);
            if (info < 0) 
                throw new ILArgumentException ("ILMath.svd: the " + (-info).ToString() +"th argument was invalid.");
            if (info > 0)
                throw new ILArgumentException("svd was not converging!");
            /*!HC:outClsS*/ ILArray<double> ret = null; 
            if (info == 0) {
                // success
                if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                    if (small) {
                        ret = /*!HC:outClsS*/ ILArray<double> .zeros(minMN,minMN);
                    } else {
                        ret = /*!HC:outClsS*/ ILArray<double> .zeros(M, N);
                    }
                    for (int i = 0; i < minMN; i++) {
                        ret.SetValue(dS[i],i,i); 
                    }
                    if (!Object.Equals(U, null))
                        U = new /*!HC:outClsU*/ ILArray<double> (dU,M,dU.Length / M);
                    if (!Object.Equals(V, null)) {
                        /*!HC:complxConj*/
                        V = new  ILArray<double> (dVT,N,dVT.Length / N).T;  
                    }
                } else {
                    ret = new /*!HC:outClsS*/ ILArray<double> (dS,minMN,1); 
                }
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <param name="discardFiniteTest">if true: the matrix given will not be checked for infinte or NaN values. If such elements 
        /// are contained nevertheless, this may result in failing convergence or error. In worst case 
        /// the function may hang inside the Lapack lib. Use with care! </param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<float> X, ref  ILArray<float> U, ref  ILArray<float> V, bool small, bool discardFiniteTest) {
            if (!X.IsMatrix)
                throw new ILArgumentSizeException("svd is defined for matrices only!");
            // early exit for small matrices
            if (X.Dimensions[1] < 4 && X.Dimensions[0] == X.Dimensions[1]) { 
                switch (X.Dimensions[0]) {
                    case 1: 
                        if (!Object.Equals(U,null))
                            U = ( float ) 1.0; 
                        if (!Object.Equals(V,null))
                            V = ( float ) 1.0; 
                        return new  ILArray<float> ( ILMath.abs(X)); 
                    //case 2:
                    //    return -1; 
                    //case 3: 
                    //    return -1; 
                }
            }
            if (!discardFiniteTest && !all(all(isfinite( X )))) 
                throw new ILArgumentException("svd: input must have only finite elements!");
            if (Lapack == null)
                throw new ILMathException("No Lapack package available.");
            // parameter evaluation
            int M = X.Dimensions[0]; int N = X.Dimensions[1];
            int minMN = (M < N) ? M : N;
            int LDU = M; int LDVT = N;
            int LDA = M;
            float [] dS = new  float [minMN];
            char jobz = (small) ? 'S' : 'A';
            float [] dU = null;
            float [] dVT = null;
            int info = 0;
            if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                // need to return U and VT 
                if (small) {
                    dU = new  float  [M * minMN];
                    dVT = new  float [N * minMN];
                } else {
                    dU = new  float [M * M];
                    dVT = new  float [N * N];
                }
            } else {
                jobz = 'N';
            }

            if (X.IsReference) {
                X.Detach();
            }
            // must create copy of input ! 
            float [] dInput = new  float [X.m_data.Length]; 
            System.Array.Copy(X.m_data, dInput, X.m_data.Length);
            Lapack.sgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);
            if (info < 0) 
                throw new ILArgumentException ("ILMath.svd: the " + (-info).ToString() +"th argument was invalid.");
            if (info > 0)
                throw new ILArgumentException("svd was not converging!");
            ILArray<float> ret = null; 
            if (info == 0) {
                // success
                if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                    if (small) {
                        ret =  ILArray<float> .zeros(minMN,minMN);
                    } else {
                        ret =  ILArray<float> .zeros(M, N);
                    }
                    for (int i = 0; i < minMN; i++) {
                        ret.SetValue(dS[i],i,i); 
                    }
                    if (!Object.Equals(U, null))
                        U = new  ILArray<float> (dU,M,dU.Length / M);
                    if (!Object.Equals(V, null)) {
                        V = new  ILArray<float> (dVT,N,dVT.Length / N).T;
                    }
                } else {
                    ret = new  ILArray<float> (dS,minMN,1); 
                }
            }
            return ret;
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <param name="discardFiniteTest">if true: the matrix given will not be checked for infinte or NaN values. If such elements 
        /// are contained nevertheless, this may result in failing convergence or error. In worst case 
        /// the function may hang inside the Lapack lib. Use with care! </param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<float> svd( ILArray<fcomplex> X, ref  ILArray<fcomplex> U, ref  ILArray<fcomplex> V, bool small, bool discardFiniteTest) {
            if (!X.IsMatrix)
                throw new ILArgumentSizeException("svd is defined for matrices only!");
            // early exit for small matrices
            if (X.Dimensions[1] < 4 && X.Dimensions[0] == X.Dimensions[1]) { 
                switch (X.Dimensions[0]) {
                    case 1: 
                        if (!Object.Equals(U,null))
                            U = ( fcomplex ) 1.0; 
                        if (!Object.Equals(V,null))
                            V = ( fcomplex ) 1.0; 
                        return new  ILArray<float> ( ILMath.abs(X)); 
                    //case 2:
                    //    return -1; 
                    //case 3: 
                    //    return -1; 
                }
            }
            if (!discardFiniteTest && !all(all(isfinite( X )))) 
                throw new ILArgumentException("svd: input must have only finite elements!");
            if (Lapack == null)
                throw new ILMathException("No Lapack package available.");
            // parameter evaluation
            int M = X.Dimensions[0]; int N = X.Dimensions[1];
            int minMN = (M < N) ? M : N;
            int LDU = M; int LDVT = N;
            int LDA = M;
            float [] dS = new  float [minMN];
            char jobz = (small) ? 'S' : 'A';
            fcomplex [] dU = null;
            fcomplex [] dVT = null;
            int info = 0;
            if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                // need to return U and VT 
                if (small) {
                    dU = new  fcomplex  [M * minMN];
                    dVT = new  fcomplex [N * minMN];
                } else {
                    dU = new  fcomplex [M * M];
                    dVT = new  fcomplex [N * N];
                }
            } else {
                jobz = 'N';
            }

            if (X.IsReference) {
                X.Detach();
            }
            // must create copy of input ! 
            fcomplex [] dInput = new  fcomplex [X.m_data.Length]; 
            System.Array.Copy(X.m_data, dInput, X.m_data.Length);
            Lapack.cgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);
            if (info < 0) 
                throw new ILArgumentException ("ILMath.svd: the " + (-info).ToString() +"th argument was invalid.");
            if (info > 0)
                throw new ILArgumentException("svd was not converging!");
            ILArray<float> ret = null; 
            if (info == 0) {
                // success
                if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                    if (small) {
                        ret =  ILArray<float> .zeros(minMN,minMN);
                    } else {
                        ret =  ILArray<float> .zeros(M, N);
                    }
                    for (int i = 0; i < minMN; i++) {
                        ret.SetValue(dS[i],i,i); 
                    }
                    if (!Object.Equals(U, null))
                        U = new  ILArray<fcomplex> (dU,M,dU.Length / M);
                    if (!Object.Equals(V, null)) {
                        V = conj(new  ILArray<fcomplex> (dVT,N,dVT.Length / N).T);
                    }
                } else {
                    ret = new  ILArray<float> (dS,minMN,1); 
                }
            }
            return ret;
        }
        /// <summary>
        /// singular value decomposition 
        /// </summary>
        /// <param name="X">matrix X. The elements of X will not be altered.</param>
        /// <param name="U">(return value) left singular vectors of X as columns of matrix U. 
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="V">right singular vectors of X as rows of matrix V.
        /// If this parameter is set, it must be not null. It might be an empty array. On return
        /// it will be set to a physical array accordingly.</param>
        /// <param name="small">if true: return only first min(M,N) columns of U and S will be 
        /// of size [min(M,N),min(M,N)]</param>
        /// <param name="discardFiniteTest">if true: the matrix given will not be checked for infinte or NaN values. If such elements 
        /// are contained nevertheless, this may result in failing convergence or error. In worst case 
        /// the function may hang inside the Lapack lib. Use with care! </param>
        /// <returns>singluar values as diagonal matrix of same size as X</returns>
        /// <remarks>the right singular vectors V will be returned as reference array.</remarks>
        public static  ILArray<double> svd( ILArray<complex> X, ref  ILArray<complex> U, ref  ILArray<complex> V, bool small, bool discardFiniteTest) {
            if (!X.IsMatrix)
                throw new ILArgumentSizeException("svd is defined for matrices only!");
            // early exit for small matrices
            if (X.Dimensions[1] < 4 && X.Dimensions[0] == X.Dimensions[1]) { 
                switch (X.Dimensions[0]) {
                    case 1: 
                        if (!Object.Equals(U,null))
                            U = ( complex ) 1.0; 
                        if (!Object.Equals(V,null))
                            V = ( complex ) 1.0; 
                        return new  ILArray<double> ( ILMath.abs(X)); 
                    //case 2:
                    //    return -1; 
                    //case 3: 
                    //    return -1; 
                }
            }
            if (!discardFiniteTest && !all(all(isfinite( X )))) 
                throw new ILArgumentException("svd: input must have only finite elements!");
            if (Lapack == null)
                throw new ILMathException("No Lapack package available.");
            // parameter evaluation
            int M = X.Dimensions[0]; int N = X.Dimensions[1];
            int minMN = (M < N) ? M : N;
            int LDU = M; int LDVT = N;
            int LDA = M;
            double [] dS = new  double [minMN];
            char jobz = (small) ? 'S' : 'A';
            complex [] dU = null;
            complex [] dVT = null;
            int info = 0;
            if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                // need to return U and VT 
                if (small) {
                    dU = new  complex  [M * minMN];
                    dVT = new  complex [N * minMN];
                } else {
                    dU = new  complex [M * M];
                    dVT = new  complex [N * N];
                }
            } else {
                jobz = 'N';
            }

            if (X.IsReference) {
                X.Detach();
            }
            // must create copy of input ! 
            complex [] dInput = new  complex [X.m_data.Length]; 
            System.Array.Copy(X.m_data, dInput, X.m_data.Length);
            Lapack.zgesdd(jobz, M, N, dInput, LDA, dS, dU, LDU, dVT, LDVT, ref info);
            if (info < 0) 
                throw new ILArgumentException ("ILMath.svd: the " + (-info).ToString() +"th argument was invalid.");
            if (info > 0)
                throw new ILArgumentException("svd was not converging!");
            ILArray<double> ret = null; 
            if (info == 0) {
                // success
                if (!Object.Equals(U, null) || !Object.Equals(V, null)) {
                    if (small) {
                        ret =  ILArray<double> .zeros(minMN,minMN);
                    } else {
                        ret =  ILArray<double> .zeros(M, N);
                    }
                    for (int i = 0; i < minMN; i++) {
                        ret.SetValue(dS[i],i,i); 
                    }
                    if (!Object.Equals(U, null))
                        U = new  ILArray<complex> (dU,M,dU.Length / M);
                    if (!Object.Equals(V, null)) {
                        V = conj(new  ILArray<complex> (dVT,N,dVT.Length / N).T);
                    }
                } else {
                    ret = new  ILArray<double> (dS,minMN,1); 
                }
            }
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
