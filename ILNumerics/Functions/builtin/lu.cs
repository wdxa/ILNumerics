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
        lapack_*getrf
    </source>
    <destination>Lapack.zgetrf</destination>
    <destination>Lapack.cgetrf</destination>
    <destination>Lapack.sgetrf</destination>
</type>
<type>
    <source locate="after">
        unityVal
    </source>
    <destination>new complex(1.0,0.0)</destination>
    <destination>new fcomplex(1.0f,0.0f)</destination>
    <destination>1.0f</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part. 
        /// </summary>
        /// <param name="A">general matrix. Size [m x n]</param>
        /// <returns>triangular matrices L and U composed into a single matrix as returned from LAPACK function ?getrf. Size [m x n]</returns>
        /// <remarks><para> The matrix returned is composed out of the lower triangular matrix L with unit diagonal and the strict upper triangular matrix U.</para>
        /// <code>
        /// :'''''''|
        /// |1 \    |
        /// | 1 \ R |
        /// |  1 \  |
        /// | L 1 \ |
        /// |    1 \|
        /// '''''''''
        /// </code>
        /// <para>This overload is mainly needed for further operations via Lapack libraries. If you need the 
        /// L and U matrices directly, you'd better use one of the overloaded versions 
        /// <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        ///  or <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> instead.</para>
        /// <para>The matrix L will be a solid ILArray.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static /*!HC:inCls1*/ ILArray<double> lu(/*!HC:inCls1*/ ILArray<double> A) {
            /*!HC:inCls1*/ ILArray<double> U = null;
            /*!HC:inCls1*/ ILArray<double> P = null; 
            return lu(A,ref U, ref P); 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part.
        /// </summary>
        /// <param name="A">general matrix to be decomposed. Size [m x n]</param>
        /// <param name="U">[output] reference to U. On return this will be the strict upper triangular matrix of size [min(m,n) x n]. Must not be null on input.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that ILMath.multiply (L,U) will result in A.
        /// <para>L will only be a permuted version of a true triangular matrix. I.e. the rows of L will be permuted in order 
        /// to fullfill <code>ILMath.multiply(L,U) == A</code></para>
        /// <example> <code>
        /// //we construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct reference on U and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,20000  -1,00000  1,00000 
        /// // 0,80000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// // and U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// Pay attention to the structure of L. In the example above the first and third row are exchanged. This permutation reflects the pivoting done during the decomposition inside the Lapack function ?getrf. </example>
        /// <para>In order to access the permutation of L, one can use the overloaded version <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> which returns the permuation matrix P also.</para>
        /// <para>All of the matrices U and L returned will be solid ILArrays.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static /*!HC:inCls1*/ ILArray<double> lu(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> U) {
            /*!HC:inCls1*/ ILArray<double> P = null; 
            return lu(A,ref U,ref P); 
        }
        /// <summary>
        /// Decompose matrix A into uper and lower triangular part. Returns permutation matrix also. 
        /// </summary>
        /// <param name="A">general input matrix. Size [m x n]</param>
        /// <param name="U">[output] reference to upper triangular matrix. Size [min(m,n) x n]. Must not be null.</param>
        /// <param name="P">[output] reference to permutation matrix. Size [min(m,n) x min(m,n)]. Must not be null.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that the equation 
        /// <code>ILMath.multiply(L,U) == ILMath.multiply(P,A)</code> 
        /// will hold except for round off error.
        /// <para>L and U will be true lower triangular matrices.</para>
        /// <example> <code>
        /// //Let's construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct references on U and P and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; P = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U, ref P); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 1,00000   0,00000   0,00000 
        /// // 0,80000   1,00000   0,00000 
        /// // 0,20000  -1,00000   1,00000 
        /// //}
        /// // U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// // and P is: 
        /// //{&lt;Double&gt; 2192437 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  1,00000 
        /// // 0,00000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// In order to reflect the pivoting done during the decomposition inside ?getrf, the matrix P may be used on A:
        /// <code>
        /// (ILMath.multiply(P,A) - ILMath.multiply(L,U)).ToString();
        /// // will give:
        /// //{&lt;Double&gt; 59192235 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// </example>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// <para>All of the matrices U,L,P returned will be solid ILArrays.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static /*!HC:inCls1*/ ILArray<double> lu(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> U, ref /*!HC:inCls1*/ ILArray<double> P) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("lu is defined for matrices only!");
            int m = A.Dimensions[0], n = A.Dimensions[1], info = 0,minMN = (m < n)? m : n; 
            /*!HC:inCls1*/ ILArray<double> L = (/*!HC:inCls1*/ ILArray<double> )A.Clone();  
            int [] pivInd = ILMemoryPool.Pool.New<int>(minMN); 
            /*!HC:lapack_*getrf*/ Lapack.dgetrf (m, n, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                ILMemoryPool.Pool.RegisterObject(pivInd); 
                throw new ILArgumentException("lu: illegal parameter error.");
            //} else if (info > 0) {
            //    // singular diagonal entry found 
                
            } else {
                // completed successfuly 
                if (!Object.Equals(U,null)) {
                    if (!Object.Equals(P,null)) {
                        pivInd = perm2indicesForward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTriangle(L,m,minMN,/*!HC:unityVal*/ 1.0 );
                        P = /*!HC:inCls1*/ ILArray<double> .zeros(minMN,minMN); 
                        // construct permutation matrix P 
                        for (int r = 0; r < m; r++) {
                            P[r,pivInd[r]] = /*!HC:unityVal*/ 1.0 ; 
                        }
                    } else {
                        pivInd = perm2indicesBackward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTrianglePerm(L,m,minMN,/*!HC:unityVal*/ 1.0 ,pivInd);
                    }
                }
            }
            ILMemoryPool.Pool.RegisterObject(pivInd); 
            return L; 
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part. 
        /// </summary>
        /// <param name="A">general matrix. Size [m x n]</param>
        /// <returns>triangular matrices L and U composed into a single matrix as returned from LAPACK function ?getrf. Size [m x n]</returns>
        /// <remarks><para> The matrix returned is composed out of the lower triangular matrix L with unit diagonal and the strict upper triangular matrix U.</para>
        /// <code>
        /// :'''''''|
        /// |1 \    |
        /// | 1 \ R |
        /// |  1 \  |
        /// | L 1 \ |
        /// |    1 \|
        /// '''''''''
        /// </code>
        /// <para>This overload is mainly needed for further operations via Lapack libraries. If you need the 
        /// L and U matrices directly, you'd better use one of the overloaded versions 
        /// <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        ///  or <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> instead.</para>
        /// <para>The matrix L will be a solid ILArray.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<float> lu( ILArray<float> A) {
            ILArray<float> U = null;
            ILArray<float> P = null; 
            return lu(A,ref U, ref P); 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part.
        /// </summary>
        /// <param name="A">general matrix to be decomposed. Size [m x n]</param>
        /// <param name="U">[output] reference to U. On return this will be the strict upper triangular matrix of size [min(m,n) x n]. Must not be null on input.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that ILMath.multiply (L,U) will result in A.
        /// <para>L will only be a permuted version of a true triangular matrix. I.e. the rows of L will be permuted in order 
        /// to fullfill <code>ILMath.multiply(L,U) == A</code></para>
        /// <example> <code>
        /// //we construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct reference on U and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,20000  -1,00000  1,00000 
        /// // 0,80000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// // and U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// Pay attention to the structure of L. In the example above the first and third row are exchanged. This permutation reflects the pivoting done during the decomposition inside the Lapack function ?getrf. </example>
        /// <para>In order to access the permutation of L, one can use the overloaded version <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> which returns the permuation matrix P also.</para>
        /// <para>All of the matrices U and L returned will be solid ILArrays.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<float> lu( ILArray<float> A, ref  ILArray<float> U) {
            ILArray<float> P = null; 
            return lu(A,ref U,ref P); 
        }
        /// <summary>
        /// Decompose matrix A into uper and lower triangular part. Returns permutation matrix also. 
        /// </summary>
        /// <param name="A">general input matrix. Size [m x n]</param>
        /// <param name="U">[output] reference to upper triangular matrix. Size [min(m,n) x n]. Must not be null.</param>
        /// <param name="P">[output] reference to permutation matrix. Size [min(m,n) x min(m,n)]. Must not be null.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that the equation 
        /// <code>ILMath.multiply(L,U) == ILMath.multiply(P,A)</code> 
        /// will hold except for round off error.
        /// <para>L and U will be true lower triangular matrices.</para>
        /// <example> <code>
        /// //Let's construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct references on U and P and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; P = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U, ref P); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 1,00000   0,00000   0,00000 
        /// // 0,80000   1,00000   0,00000 
        /// // 0,20000  -1,00000   1,00000 
        /// //}
        /// // U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// // and P is: 
        /// //{&lt;Double&gt; 2192437 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  1,00000 
        /// // 0,00000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// In order to reflect the pivoting done during the decomposition inside ?getrf, the matrix P may be used on A:
        /// <code>
        /// (ILMath.multiply(P,A) - ILMath.multiply(L,U)).ToString();
        /// // will give:
        /// //{&lt;Double&gt; 59192235 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// </example>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// <para>All of the matrices U,L,P returned will be solid ILArrays.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<float> lu( ILArray<float> A, ref  ILArray<float> U, ref  ILArray<float> P) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("lu is defined for matrices only!");
            int m = A.Dimensions[0], n = A.Dimensions[1], info = 0,minMN = (m < n)? m : n; 
            ILArray<float> L = ( ILArray<float> )A.Clone();  
            int [] pivInd = ILMemoryPool.Pool.New<int>(minMN); 
            Lapack.sgetrf (m, n, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                ILMemoryPool.Pool.RegisterObject(pivInd); 
                throw new ILArgumentException("lu: illegal parameter error.");
            //} else if (info > 0) {
            //    // singular diagonal entry found 
                
            } else {
                // completed successfuly 
                if (!Object.Equals(U,null)) {
                    if (!Object.Equals(P,null)) {
                        pivInd = perm2indicesForward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTriangle(L,m,minMN, 1.0f );
                        P =  ILArray<float> .zeros(minMN,minMN); 
                        // construct permutation matrix P 
                        for (int r = 0; r < m; r++) {
                            P[r,pivInd[r]] =  1.0f ; 
                        }
                    } else {
                        pivInd = perm2indicesBackward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTrianglePerm(L,m,minMN, 1.0f ,pivInd);
                    }
                }
            }
            ILMemoryPool.Pool.RegisterObject(pivInd); 
            return L; 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part. 
        /// </summary>
        /// <param name="A">general matrix. Size [m x n]</param>
        /// <returns>triangular matrices L and U composed into a single matrix as returned from LAPACK function ?getrf. Size [m x n]</returns>
        /// <remarks><para> The matrix returned is composed out of the lower triangular matrix L with unit diagonal and the strict upper triangular matrix U.</para>
        /// <code>
        /// :'''''''|
        /// |1 \    |
        /// | 1 \ R |
        /// |  1 \  |
        /// | L 1 \ |
        /// |    1 \|
        /// '''''''''
        /// </code>
        /// <para>This overload is mainly needed for further operations via Lapack libraries. If you need the 
        /// L and U matrices directly, you'd better use one of the overloaded versions 
        /// <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        ///  or <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> instead.</para>
        /// <para>The matrix L will be a solid ILArray.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<fcomplex> lu( ILArray<fcomplex> A) {
            ILArray<fcomplex> U = null;
            ILArray<fcomplex> P = null; 
            return lu(A,ref U, ref P); 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part.
        /// </summary>
        /// <param name="A">general matrix to be decomposed. Size [m x n]</param>
        /// <param name="U">[output] reference to U. On return this will be the strict upper triangular matrix of size [min(m,n) x n]. Must not be null on input.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that ILMath.multiply (L,U) will result in A.
        /// <para>L will only be a permuted version of a true triangular matrix. I.e. the rows of L will be permuted in order 
        /// to fullfill <code>ILMath.multiply(L,U) == A</code></para>
        /// <example> <code>
        /// //we construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct reference on U and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,20000  -1,00000  1,00000 
        /// // 0,80000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// // and U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// Pay attention to the structure of L. In the example above the first and third row are exchanged. This permutation reflects the pivoting done during the decomposition inside the Lapack function ?getrf. </example>
        /// <para>In order to access the permutation of L, one can use the overloaded version <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> which returns the permuation matrix P also.</para>
        /// <para>All of the matrices U and L returned will be solid ILArrays.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<fcomplex> lu( ILArray<fcomplex> A, ref  ILArray<fcomplex> U) {
            ILArray<fcomplex> P = null; 
            return lu(A,ref U,ref P); 
        }
        /// <summary>
        /// Decompose matrix A into uper and lower triangular part. Returns permutation matrix also. 
        /// </summary>
        /// <param name="A">general input matrix. Size [m x n]</param>
        /// <param name="U">[output] reference to upper triangular matrix. Size [min(m,n) x n]. Must not be null.</param>
        /// <param name="P">[output] reference to permutation matrix. Size [min(m,n) x min(m,n)]. Must not be null.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that the equation 
        /// <code>ILMath.multiply(L,U) == ILMath.multiply(P,A)</code> 
        /// will hold except for round off error.
        /// <para>L and U will be true lower triangular matrices.</para>
        /// <example> <code>
        /// //Let's construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct references on U and P and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; P = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U, ref P); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 1,00000   0,00000   0,00000 
        /// // 0,80000   1,00000   0,00000 
        /// // 0,20000  -1,00000   1,00000 
        /// //}
        /// // U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// // and P is: 
        /// //{&lt;Double&gt; 2192437 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  1,00000 
        /// // 0,00000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// In order to reflect the pivoting done during the decomposition inside ?getrf, the matrix P may be used on A:
        /// <code>
        /// (ILMath.multiply(P,A) - ILMath.multiply(L,U)).ToString();
        /// // will give:
        /// //{&lt;Double&gt; 59192235 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// </example>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// <para>All of the matrices U,L,P returned will be solid ILArrays.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<fcomplex> lu( ILArray<fcomplex> A, ref  ILArray<fcomplex> U, ref  ILArray<fcomplex> P) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("lu is defined for matrices only!");
            int m = A.Dimensions[0], n = A.Dimensions[1], info = 0,minMN = (m < n)? m : n; 
            ILArray<fcomplex> L = ( ILArray<fcomplex> )A.Clone();  
            int [] pivInd = ILMemoryPool.Pool.New<int>(minMN); 
            Lapack.cgetrf (m, n, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                ILMemoryPool.Pool.RegisterObject(pivInd); 
                throw new ILArgumentException("lu: illegal parameter error.");
            //} else if (info > 0) {
            //    // singular diagonal entry found 
                
            } else {
                // completed successfuly 
                if (!Object.Equals(U,null)) {
                    if (!Object.Equals(P,null)) {
                        pivInd = perm2indicesForward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTriangle(L,m,minMN, new fcomplex(1.0f,0.0f) );
                        P =  ILArray<fcomplex> .zeros(minMN,minMN); 
                        // construct permutation matrix P 
                        for (int r = 0; r < m; r++) {
                            P[r,pivInd[r]] =  new fcomplex(1.0f,0.0f) ; 
                        }
                    } else {
                        pivInd = perm2indicesBackward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTrianglePerm(L,m,minMN, new fcomplex(1.0f,0.0f) ,pivInd);
                    }
                }
            }
            ILMemoryPool.Pool.RegisterObject(pivInd); 
            return L; 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part. 
        /// </summary>
        /// <param name="A">general matrix. Size [m x n]</param>
        /// <returns>triangular matrices L and U composed into a single matrix as returned from LAPACK function ?getrf. Size [m x n]</returns>
        /// <remarks><para> The matrix returned is composed out of the lower triangular matrix L with unit diagonal and the strict upper triangular matrix U.</para>
        /// <code>
        /// :'''''''|
        /// |1 \    |
        /// | 1 \ R |
        /// |  1 \  |
        /// | L 1 \ |
        /// |    1 \|
        /// '''''''''
        /// </code>
        /// <para>This overload is mainly needed for further operations via Lapack libraries. If you need the 
        /// L and U matrices directly, you'd better use one of the overloaded versions 
        /// <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        ///  or <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> instead.</para>
        /// <para>The matrix L will be a solid ILArray.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<complex> lu( ILArray<complex> A) {
            ILArray<complex> U = null;
            ILArray<complex> P = null; 
            return lu(A,ref U, ref P); 
        }
        /// <summary>
        /// LU matrix decomposition. Decompose general matrix A into strictly upper part and lower part.
        /// </summary>
        /// <param name="A">general matrix to be decomposed. Size [m x n]</param>
        /// <param name="U">[output] reference to U. On return this will be the strict upper triangular matrix of size [min(m,n) x n]. Must not be null on input.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that ILMath.multiply (L,U) will result in A.
        /// <para>L will only be a permuted version of a true triangular matrix. I.e. the rows of L will be permuted in order 
        /// to fullfill <code>ILMath.multiply(L,U) == A</code></para>
        /// <example> <code>
        /// //we construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct reference on U and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,20000  -1,00000  1,00000 
        /// // 0,80000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// // and U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// Pay attention to the structure of L. In the example above the first and third row are exchanged. This permutation reflects the pivoting done during the decomposition inside the Lapack function ?getrf. </example>
        /// <para>In order to access the permutation of L, one can use the overloaded version <see cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/> which returns the permuation matrix P also.</para>
        /// <para>All of the matrices U and L returned will be solid ILArrays.</para>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<complex> lu( ILArray<complex> A, ref  ILArray<complex> U) {
            ILArray<complex> P = null; 
            return lu(A,ref U,ref P); 
        }
        /// <summary>
        /// Decompose matrix A into uper and lower triangular part. Returns permutation matrix also. 
        /// </summary>
        /// <param name="A">general input matrix. Size [m x n]</param>
        /// <param name="U">[output] reference to upper triangular matrix. Size [min(m,n) x n]. Must not be null.</param>
        /// <param name="P">[output] reference to permutation matrix. Size [min(m,n) x min(m,n)]. Must not be null.</param>
        /// <returns>lower triangular matrix L of size [m x min(m,n)]</returns>
        /// <remarks>A is decomposed into L and U, so that the equation 
        /// <code>ILMath.multiply(L,U) == ILMath.multiply(P,A)</code> 
        /// will hold except for round off error.
        /// <para>L and U will be true lower triangular matrices.</para>
        /// <example> <code>
        /// //Let's construct a matrix X: 
        /// ILArray&lt;double&gt; X = new ILArray&lt;double&gt;(new double[]{1, 2, 3, 4, 4, 4, 5, 6, 7},3,3).T;
        /// // now X.ToString() will give something like:
        /// // {&lt;Double&gt; 63238509 [3x3] Ref(2) 
        /// //(:,:) 
        /// // 1,00000  2,00000  3,00000 
        /// // 4,00000  4,00000  4,00000 
        /// // 5,00000  6,00000  7,00000 
        /// //}
        /// // construct references on U and P and call the decomposition
        /// ILArray&lt;double&gt; U = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; P = new ILArray&lt;double&gt;.empty();
        /// ILArray&lt;double&gt; L = ILMath.lu(X, ref U, ref P); 
        /// 
        /// // L.ToString() is now: 
        /// // {&lt;Double&gt; 19634871 [3x3] Phys. 
        /// //(:,:) 
        /// // 1,00000   0,00000   0,00000 
        /// // 0,80000   1,00000   0,00000 
        /// // 0,20000  -1,00000   1,00000 
        /// //}
        /// // U is now: 
        /// //{&lt;Double&gt; 22584602 [3x3] Phys. 
        /// //(:,:) 
        /// // 5,00000  6,00000  7,00000 
        /// // 0,00000  -0,80000  -1,60000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// // and P is: 
        /// //{&lt;Double&gt; 2192437 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  1,00000 
        /// // 0,00000  1,00000  0,00000 
        /// // 1,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// In order to reflect the pivoting done during the decomposition inside ?getrf, the matrix P may be used on A:
        /// <code>
        /// (ILMath.multiply(P,A) - ILMath.multiply(L,U)).ToString();
        /// // will give:
        /// //{&lt;Double&gt; 59192235 [3x3] Phys. 
        /// //(:,:) 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// // 0,00000  0,00000  0,00000 
        /// //}
        /// </code>
        /// </example>
        /// <para>lu uses the Lapack function ?getrf.</para>
        /// <para>All of the matrices U,L,P returned will be solid ILArrays.</para>
        /// </remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;)"/>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.lu(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;)"/>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException"> if input A is not a matrix.</exception>
        public static  ILArray<complex> lu( ILArray<complex> A, ref  ILArray<complex> U, ref  ILArray<complex> P) {
            if (!A.IsMatrix)
                throw new ILArgumentSizeException("lu is defined for matrices only!");
            int m = A.Dimensions[0], n = A.Dimensions[1], info = 0,minMN = (m < n)? m : n; 
            ILArray<complex> L = ( ILArray<complex> )A.Clone();  
            int [] pivInd = ILMemoryPool.Pool.New<int>(minMN); 
            Lapack.zgetrf (m, n, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                ILMemoryPool.Pool.RegisterObject(pivInd); 
                throw new ILArgumentException("lu: illegal parameter error.");
            //} else if (info > 0) {
            //    // singular diagonal entry found 
                
            } else {
                // completed successfuly 
                if (!Object.Equals(U,null)) {
                    if (!Object.Equals(P,null)) {
                        pivInd = perm2indicesForward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTriangle(L,m,minMN, new complex(1.0,0.0) );
                        P =  ILArray<complex> .zeros(minMN,minMN); 
                        // construct permutation matrix P 
                        for (int r = 0; r < m; r++) {
                            P[r,pivInd[r]] =  new complex(1.0,0.0) ; 
                        }
                    } else {
                        pivInd = perm2indicesBackward(pivInd); 
                        U = copyUpperTriangle(L,minMN,n);
                        L = copyLowerTrianglePerm(L,m,minMN, new complex(1.0,0.0) ,pivInd);
                    }
                }
            }
            ILMemoryPool.Pool.RegisterObject(pivInd); 
            return L; 
        }

#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// copy upper triangle from PHYSICAL array A
        /// </summary>
        /// <typeparam name="T">arbitrary inner type </typeparam>
        /// <param name="A">PHYSICAL ILArray</param>
        /// <param name="m">number of rows</param>
        /// <param name="n">number of columns</param>
        /// <returns>newly created physical array with the upper triangle of A</returns>
        /// <remarks>no checks are made for m,n fit inside A!</remarks>
        internal static ILArray<T> copyUpperTriangle<T>(ILArray<T> A, int m, int n) {
            T[] arr = ILMemoryPool.Pool.New <T>(m * n);
            for (int r = 0; r < m; r++) {
                for (int c = r; c < n; c++) {
                    arr[r + c * m] = A.GetValue(r,c);
                }
            }
            return new ILArray<T> (arr,m,n);
        }
        /// <summary>
        /// copy upper triangle from system array A
        /// </summary>
        /// <typeparam name="T">arbitrary inner type </typeparam>
        /// <param name="arrIn">system array, size (m x n), column wise ordered</param>
        /// <param name="arrInM">number of rows</param>
        /// <param name="arrInN">number of columns</param>
        /// <param name="outM">number of rows in output matrix</param>
        /// <returns>newly created physical array with the upper triangle of A</returns>
        /// <remarks>no checks are made for m,n fit inside A! copies the main diagonal also.
        /// the array returned will be of size (min(m,n) x n)</remarks>
        private static ILArray<T> copyUpperTriangle<T>(T[] arrIn, int arrInM, int arrInN, int outM) {
            T[] arrOu = ILMemoryPool.Pool.New<T>(outM * arrInN);
            for (int c = 0; c < arrInN; c++) {
                for (int r = 0; r <= c && r < outM; r++) {
                    arrOu[c * outM + r] = arrIn[c * arrInM + r];
                }
            }
            return new ILArray<T> (arrOu,outM,arrInN);
        }
        /// <summary>
        /// copy lower triangle from PHYSICAL array A, set diagonal to val
        /// </summary>
        /// <typeparam name="T">arbitrary inner type </typeparam>
        /// <param name="A">PHYSICAL ILArray</param>
        /// <param name="m">number of rows</param>
        /// <param name="n">number of columns</param>
        /// <param name="val">value for diagonal entries</param>
        /// <returns>newly created physical array with the lower triangle of A</returns>
        /// <remarks>no checks are made for m,n fit inside A!</remarks>
        private static ILArray<T> copyLowerTriangle<T>(ILArray<T> A, int m, int n, T val) {
            T[] arr = ILMemoryPool.Pool.New<T>(m * n);
            for (int r = 0; r < m; r++) {
                for (int c = r + 1; c -->0;) {
                    arr[r + m * c] = A.GetValue(r,c);
                }
                arr[r + m * r] = val;     
            }
            return new ILArray<T> (arr,m,n);
        }
        /// <summary>
        /// copy lower triangle from PHYSICAL array A, set diagonal to val, permuted version
        /// </summary>
        /// <typeparam name="T">arbitrary inner type </typeparam>
        /// <param name="A">PHYSICAL ILArray</param>
        /// <param name="m">number of rows</param>
        /// <param name="n">number of columns</param>
        /// <param name="perm">mapping for rows, must be converted fom LAPACK version to single indices </param>
        /// <param name="val">value for diagonal entries</param>
        /// <returns>newly created physical array with the lower triangle of A</returns>
        /// <remarks>no checks are made for m,n fit inside A!</remarks>
        private static ILArray<T> copyLowerTrianglePerm<T>(ILArray<T> A, int m, int n, T val, int[] perm) {
            T[] arr = ILMemoryPool.Pool.New<T>(m * n);
            int trueRow;  
            for (int r = 0; r < perm.Length; r++) {
                trueRow = perm[r]; 
                for (int c = 0; c < trueRow; c++) {
                    arr[r + c * m] = A.GetValue(trueRow,c); 
                }
                arr[r + m * trueRow] = val; 
            }
            return new ILArray<T> (arr,m,n);
        }

        /// <summary>
        /// relabel permutation indices from LAPACK ?getrf
        /// </summary>
        /// <param name="perm">lapack pivoting permutation array</param>
        /// <returns>index mapping for direct addressing the rows </returns>
        /// <remarks>exchange the row labels in the same manner as LAPACK did for pivoting</remarks>
        private static int[] perm2indicesForward(int[] perm) {
            int [] ret = ILMemoryPool.Pool.New<int>(perm.Length);
            for (int i = 0; i < ret.Length; i++) {
                ret[i] = i; 
            }
            int tmp; 
            for (int i = 0; i < ret.Length; i++) {
                if (perm[i] != i+1) {
                    tmp = ret[perm[i]-1]; 
                    ret[perm[i]-1] = i; 
                    ret[i] = tmp; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// relabel permutation indices from LAPACK ?getrf - backward version
        /// </summary>
        /// <param name="perm">lapack pivoting permutation array</param>
        /// <returns>index mapping for direct addressing the rows </returns>
        /// <remarks>exchange the row labels in the same manner as LAPACK did for pivoting, but backwards</remarks>
        private static int[] perm2indicesBackward(int[] perm) {
            int [] ret = ILMemoryPool.Pool.New<int>(perm.Length);
            for (int i = 0; i < ret.Length; i++) {
                ret[i] = i; 
            }
            int tmp; 
            for (int i = ret.Length - 1; i-->0;) {
                if (perm[i] != i+1) {
                    tmp = ret[perm[i]-1]; 
                    ret[perm[i]-1] = i; 
                    ret[i] = tmp; 
                }
            }
            return ret; 
        }

    }
}
