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
        lapack_*potrf
    </source>
    <destination>Lapack.zpotrf</destination>
    <destination>Lapack.cpotrf</destination>
    <destination>Lapack.spotrf</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        /// <param name="A">hermitian matrix A. A must be a symmetric matrix. Therefore the upper triangular part of A must be 
        /// <param name="throwException">throw an ILArgumentException if A is found not to be positive definite.</param>
        /// the (complex conjugate) of the lower triangular part. No check is made for that! <br/> 
        /// The elements of A will not be altered.</param>
        /// <returns>cholesky factorization</returns>
        /// <remarks><para>if <paramref name="throwException"/> is true and A is found not to be positive definite, an ILArgumentException will be thrown and the operation will be canceled.</para>
        /// <para> If <paramref name="throwException"/> is false, check the return value's dimension to determine the success of the operation (unless you are sure, A was positive definite). If A was found not pos.def. the matrix returned 
        /// will be of dimension [k x k] and the result of the cholesky factorization of A[0:k-1;0:k-1]. Here k is the first leading minor of A which was found to be not positive definite.  </para>
        /// The factorization is carried out by use of the LAPACK functions DPOTRF, ZPOTRF, SPOTRF or CPOTRF respectively. </remarks>
        public static /*!HC:inCls1*/ ILArray<double> chol(/*!HC:inCls1*/ ILArray<double> A, bool throwException) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("chol is defined for matrices only!");
            int n = A.Dimensions[0], info = 0; 
            if (A.Dimensions[1] != n) 
                throw new ILArgumentException("chol: input matrix must be square!");
            /*!HC:inCls1*/ ILArray<double> ret = A.copyUpperTriangle(n);
            /*!HC:lapack_*potrf*/ Lapack.dpotrf ('U', n, ret.m_data, n, ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("chol: illegal parameter error.");
            } else if (info > 0) {
                // not pos.definite 
                if (! throwException) {
                    if (info > 1) {
                        int newDim = info - 1;
                        ret = A.copyUpperTriangle(newDim); 
                        /*!HC:lapack_*potrf*/  Lapack.dpotrf ('U',newDim,ret.m_data, newDim, ref info);
                        if (info != 0) 
                            throw new ILArgumentException("chol: the original matrix given was not pos. definit. An attempt to decompose the submatrix of order " + (newDim + 1).ToString() + " failed."); 
                        return ret; 
                    } else {
                        return /*!HC:inCls1*/ ILArray<double> .empty(); 
                    } 
                } else {
                    throw new ILArgumentException("chol: the matrix given is not positive definite!"); 
                }
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        /// <param name="A">hermitian matrix A. A must be a symmetric matrix. Therefore the upper triangular part of A must be 
        /// <param name="throwException">throw an ILArgumentException if A is found not to be positive definite.</param>
        /// the (complex conjugate) of the lower triangular part. No check is made for that! <br/> 
        /// The elements of A will not be altered.</param>
        /// <returns>cholesky factorization</returns>
        /// <remarks><para>if <paramref name="throwException"/> is true and A is found not to be positive definite, an ILArgumentException will be thrown and the operation will be canceled.</para>
        /// <para> If <paramref name="throwException"/> is false, check the return value's dimension to determine the success of the operation (unless you are sure, A was positive definite). If A was found not pos.def. the matrix returned 
        /// will be of dimension [k x k] and the result of the cholesky factorization of A[0:k-1;0:k-1]. Here k is the first leading minor of A which was found to be not positive definite.  </para>
        /// The factorization is carried out by use of the LAPACK functions DPOTRF, ZPOTRF, SPOTRF or CPOTRF respectively. </remarks>
        public static  ILArray<float> chol( ILArray<float> A, bool throwException) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("chol is defined for matrices only!");
            int n = A.Dimensions[0], info = 0; 
            if (A.Dimensions[1] != n) 
                throw new ILArgumentException("chol: input matrix must be square!");
            ILArray<float> ret = A.copyUpperTriangle(n);
            Lapack.spotrf ('U', n, ret.m_data, n, ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("chol: illegal parameter error.");
            } else if (info > 0) {
                // not pos.definite 
                if (! throwException) {
                    if (info > 1) {
                        int newDim = info - 1;
                        ret = A.copyUpperTriangle(newDim); 
                         Lapack.spotrf ('U',newDim,ret.m_data, newDim, ref info);
                        if (info != 0) 
                            throw new ILArgumentException("chol: the original matrix given was not pos. definit. An attempt to decompose the submatrix of order " + (newDim + 1).ToString() + " failed."); 
                        return ret; 
                    } else {
                        return  ILArray<float> .empty(); 
                    } 
                } else {
                    throw new ILArgumentException("chol: the matrix given is not positive definite!"); 
                }
            }
            return ret; 
        }
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        /// <param name="A">hermitian matrix A. A must be a symmetric matrix. Therefore the upper triangular part of A must be 
        /// <param name="throwException">throw an ILArgumentException if A is found not to be positive definite.</param>
        /// the (complex conjugate) of the lower triangular part. No check is made for that! <br/> 
        /// The elements of A will not be altered.</param>
        /// <returns>cholesky factorization</returns>
        /// <remarks><para>if <paramref name="throwException"/> is true and A is found not to be positive definite, an ILArgumentException will be thrown and the operation will be canceled.</para>
        /// <para> If <paramref name="throwException"/> is false, check the return value's dimension to determine the success of the operation (unless you are sure, A was positive definite). If A was found not pos.def. the matrix returned 
        /// will be of dimension [k x k] and the result of the cholesky factorization of A[0:k-1;0:k-1]. Here k is the first leading minor of A which was found to be not positive definite.  </para>
        /// The factorization is carried out by use of the LAPACK functions DPOTRF, ZPOTRF, SPOTRF or CPOTRF respectively. </remarks>
        public static  ILArray<fcomplex> chol( ILArray<fcomplex> A, bool throwException) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("chol is defined for matrices only!");
            int n = A.Dimensions[0], info = 0; 
            if (A.Dimensions[1] != n) 
                throw new ILArgumentException("chol: input matrix must be square!");
            ILArray<fcomplex> ret = A.copyUpperTriangle(n);
            Lapack.cpotrf ('U', n, ret.m_data, n, ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("chol: illegal parameter error.");
            } else if (info > 0) {
                // not pos.definite 
                if (! throwException) {
                    if (info > 1) {
                        int newDim = info - 1;
                        ret = A.copyUpperTriangle(newDim); 
                         Lapack.cpotrf ('U',newDim,ret.m_data, newDim, ref info);
                        if (info != 0) 
                            throw new ILArgumentException("chol: the original matrix given was not pos. definit. An attempt to decompose the submatrix of order " + (newDim + 1).ToString() + " failed."); 
                        return ret; 
                    } else {
                        return  ILArray<fcomplex> .empty(); 
                    } 
                } else {
                    throw new ILArgumentException("chol: the matrix given is not positive definite!"); 
                }
            }
            return ret; 
        }
        /// <summary>
        /// cholesky factorization 
        /// </summary>
        /// <param name="A">hermitian matrix A. A must be a symmetric matrix. Therefore the upper triangular part of A must be 
        /// <param name="throwException">throw an ILArgumentException if A is found not to be positive definite.</param>
        /// the (complex conjugate) of the lower triangular part. No check is made for that! <br/> 
        /// The elements of A will not be altered.</param>
        /// <returns>cholesky factorization</returns>
        /// <remarks><para>if <paramref name="throwException"/> is true and A is found not to be positive definite, an ILArgumentException will be thrown and the operation will be canceled.</para>
        /// <para> If <paramref name="throwException"/> is false, check the return value's dimension to determine the success of the operation (unless you are sure, A was positive definite). If A was found not pos.def. the matrix returned 
        /// will be of dimension [k x k] and the result of the cholesky factorization of A[0:k-1;0:k-1]. Here k is the first leading minor of A which was found to be not positive definite.  </para>
        /// The factorization is carried out by use of the LAPACK functions DPOTRF, ZPOTRF, SPOTRF or CPOTRF respectively. </remarks>
        public static  ILArray<complex> chol( ILArray<complex> A, bool throwException) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("chol is defined for matrices only!");
            int n = A.Dimensions[0], info = 0; 
            if (A.Dimensions[1] != n) 
                throw new ILArgumentException("chol: input matrix must be square!");
            ILArray<complex> ret = A.copyUpperTriangle(n);
            Lapack.zpotrf ('U', n, ret.m_data, n, ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("chol: illegal parameter error.");
            } else if (info > 0) {
                // not pos.definite 
                if (! throwException) {
                    if (info > 1) {
                        int newDim = info - 1;
                        ret = A.copyUpperTriangle(newDim); 
                         Lapack.zpotrf ('U',newDim,ret.m_data, newDim, ref info);
                        if (info != 0) 
                            throw new ILArgumentException("chol: the original matrix given was not pos. definit. An attempt to decompose the submatrix of order " + (newDim + 1).ToString() + " failed."); 
                        return ret; 
                    } else {
                        return  ILArray<complex> .empty(); 
                    } 
                } else {
                    throw new ILArgumentException("chol: the matrix given is not positive definite!"); 
                }
            }
            return ret; 
        }

#endregion HYCALPER AUTO GENERATED CODE


    }
}
