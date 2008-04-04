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
<type>
    <source locate="after">
        negUnityValNoCmplx
    </source>
    <destination>-1.0</destination>
    <destination>-1.0f</destination>
    <destination>-1.0f</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// Determinant of square matrix
        /// </summary>
        /// <param name="A">square input matrix</param>
        /// <returns>determinant of A</returns>
        /// <remarks><para>The determinant is computed by decomposing A into upper and lower triangular part. Therefore LAPACK function ?getrf is used. <br />
        /// Due to the properties of determinants, det(a) is the same as det(L) * det(U),where det(L) can easily be extracted from the permutation indices returned from LU decomposition. det(U) - with U beeing an upper triangular matrix - equals the product of the diagonal elements.</para>
        /// <para>For scalar A, a plain copy of A is returned.</para></remarks>
        /// <example>Creating a nonsingular 4x4 (double) matrix and it's determinant
        /// <code>ILArray&lt;double&gt; A = ILMath.counter(1.0,1.0,4,4);
        ///A[1] = 0.0;  // make A nonsingular
        ///A[14] = 0.0; //(same as: A[2,3] = 0.0;) 
        /// // A is now:
        /// //&lt;Double&gt; [4,4]
        /// //(:,:) 1e+001 * 
        /// // 0,10000   0,50000   0,90000   1,30000 
        /// // 0,00000   0,60000   1,00000   1,40000 
        /// // 0,30000   0,70000   1,10000   0,00000 
        /// // 0,40000   0,80000   1,20000   1,60000 
        /// 
        ///ILMath.det(A) gives:
        /// //&lt;Double&gt; -360
        ///</code></example>
        ///<exception cref="ILNumerics.Exceptions.ILArgumentException">if A is empty or not a square matrix</exception>
        public static /*!HC:inCls1*/ ILArray<double> det(/*!HC:inCls1*/ ILArray<double> A) {
            if (A.IsScalar) 
                return A.C; 
            if (A.IsEmpty) 
                throw new ILArgumentException("det: A must be a matrix"); 
            int m = A.Dimensions[0]; 
            if (m != A.Dimensions[1]) {
                throw new ILArgumentException("det: matrix A must be square"); 
            }

            /*!HC:inCls1*/ ILArray<double> L = A.C; 
            int [] pivInd = new int[m]; 
            int info = 0; 
            /*!HC:lapack_*getrf*/ Lapack.dgetrf (m, m, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("det: illegal parameter error.");
            }
            // determine pivoting: number of exchanges 
            /*!HC:inArr1*/ double retA = /*!HC:unityVal*/ 1.0 ; 
            for (int i = 0; i < m;) {
                retA *= L.m_data[i * m + i]; 
                if (pivInd[i] != ++i) retA *= /*!HC:negUnityValNoCmplx*/ -1.0 ; 
            }
            L.Dispose(); 
            return new /*!HC:inCls1*/ ILArray<double> ( retA ); 
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Determinant of square matrix
        /// </summary>
        /// <param name="A">square input matrix</param>
        /// <returns>determinant of A</returns>
        /// <remarks><para>The determinant is computed by decomposing A into upper and lower triangular part. Therefore LAPACK function ?getrf is used. <br />
        /// Due to the properties of determinants, det(a) is the same as det(L) * det(U),where det(L) can easily be extracted from the permutation indices returned from LU decomposition. det(U) - with U beeing an upper triangular matrix - equals the product of the diagonal elements.</para>
        /// <para>For scalar A, a plain copy of A is returned.</para></remarks>
        /// <example>Creating a nonsingular 4x4 (double) matrix and it's determinant
        /// <code>ILArray&lt;double&gt; A = ILMath.counter(1.0,1.0,4,4);
        ///A[1] = 0.0;  // make A nonsingular
        ///A[14] = 0.0; //(same as: A[2,3] = 0.0;) 
        /// // A is now:
        /// //&lt;Double&gt; [4,4]
        /// //(:,:) 1e+001 * 
        /// // 0,10000   0,50000   0,90000   1,30000 
        /// // 0,00000   0,60000   1,00000   1,40000 
        /// // 0,30000   0,70000   1,10000   0,00000 
        /// // 0,40000   0,80000   1,20000   1,60000 
        /// 
        ///ILMath.det(A) gives:
        /// //&lt;Double&gt; -360
        ///</code></example>
        ///<exception cref="ILNumerics.Exceptions.ILArgumentException">if A is empty or not a square matrix</exception>
        public static  ILArray<float> det( ILArray<float> A) {
            if (A.IsScalar) 
                return A.C; 
            if (A.IsEmpty) 
                throw new ILArgumentException("det: A must be a matrix"); 
            int m = A.Dimensions[0]; 
            if (m != A.Dimensions[1]) {
                throw new ILArgumentException("det: matrix A must be square"); 
            }

            ILArray<float> L = A.C; 
            int [] pivInd = new int[m]; 
            int info = 0; 
            Lapack.sgetrf (m, m, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("det: illegal parameter error.");
            }
            // determine pivoting: number of exchanges 
            float retA =  1.0f ; 
            for (int i = 0; i < m;) {
                retA *= L.m_data[i * m + i]; 
                if (pivInd[i] != ++i) retA *=  -1.0f ; 
            }
            L.Dispose(); 
            return new  ILArray<float> ( retA ); 
        }
        /// <summary>
        /// Determinant of square matrix
        /// </summary>
        /// <param name="A">square input matrix</param>
        /// <returns>determinant of A</returns>
        /// <remarks><para>The determinant is computed by decomposing A into upper and lower triangular part. Therefore LAPACK function ?getrf is used. <br />
        /// Due to the properties of determinants, det(a) is the same as det(L) * det(U),where det(L) can easily be extracted from the permutation indices returned from LU decomposition. det(U) - with U beeing an upper triangular matrix - equals the product of the diagonal elements.</para>
        /// <para>For scalar A, a plain copy of A is returned.</para></remarks>
        /// <example>Creating a nonsingular 4x4 (double) matrix and it's determinant
        /// <code>ILArray&lt;double&gt; A = ILMath.counter(1.0,1.0,4,4);
        ///A[1] = 0.0;  // make A nonsingular
        ///A[14] = 0.0; //(same as: A[2,3] = 0.0;) 
        /// // A is now:
        /// //&lt;Double&gt; [4,4]
        /// //(:,:) 1e+001 * 
        /// // 0,10000   0,50000   0,90000   1,30000 
        /// // 0,00000   0,60000   1,00000   1,40000 
        /// // 0,30000   0,70000   1,10000   0,00000 
        /// // 0,40000   0,80000   1,20000   1,60000 
        /// 
        ///ILMath.det(A) gives:
        /// //&lt;Double&gt; -360
        ///</code></example>
        ///<exception cref="ILNumerics.Exceptions.ILArgumentException">if A is empty or not a square matrix</exception>
        public static  ILArray<fcomplex> det( ILArray<fcomplex> A) {
            if (A.IsScalar) 
                return A.C; 
            if (A.IsEmpty) 
                throw new ILArgumentException("det: A must be a matrix"); 
            int m = A.Dimensions[0]; 
            if (m != A.Dimensions[1]) {
                throw new ILArgumentException("det: matrix A must be square"); 
            }

            ILArray<fcomplex> L = A.C; 
            int [] pivInd = new int[m]; 
            int info = 0; 
            Lapack.cgetrf (m, m, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("det: illegal parameter error.");
            }
            // determine pivoting: number of exchanges 
            fcomplex retA =  new fcomplex(1.0f,0.0f) ; 
            for (int i = 0; i < m;) {
                retA *= L.m_data[i * m + i]; 
                if (pivInd[i] != ++i) retA *=  -1.0f ; 
            }
            L.Dispose(); 
            return new  ILArray<fcomplex> ( retA ); 
        }
        /// <summary>
        /// Determinant of square matrix
        /// </summary>
        /// <param name="A">square input matrix</param>
        /// <returns>determinant of A</returns>
        /// <remarks><para>The determinant is computed by decomposing A into upper and lower triangular part. Therefore LAPACK function ?getrf is used. <br />
        /// Due to the properties of determinants, det(a) is the same as det(L) * det(U),where det(L) can easily be extracted from the permutation indices returned from LU decomposition. det(U) - with U beeing an upper triangular matrix - equals the product of the diagonal elements.</para>
        /// <para>For scalar A, a plain copy of A is returned.</para></remarks>
        /// <example>Creating a nonsingular 4x4 (double) matrix and it's determinant
        /// <code>ILArray&lt;double&gt; A = ILMath.counter(1.0,1.0,4,4);
        ///A[1] = 0.0;  // make A nonsingular
        ///A[14] = 0.0; //(same as: A[2,3] = 0.0;) 
        /// // A is now:
        /// //&lt;Double&gt; [4,4]
        /// //(:,:) 1e+001 * 
        /// // 0,10000   0,50000   0,90000   1,30000 
        /// // 0,00000   0,60000   1,00000   1,40000 
        /// // 0,30000   0,70000   1,10000   0,00000 
        /// // 0,40000   0,80000   1,20000   1,60000 
        /// 
        ///ILMath.det(A) gives:
        /// //&lt;Double&gt; -360
        ///</code></example>
        ///<exception cref="ILNumerics.Exceptions.ILArgumentException">if A is empty or not a square matrix</exception>
        public static  ILArray<complex> det( ILArray<complex> A) {
            if (A.IsScalar) 
                return A.C; 
            if (A.IsEmpty) 
                throw new ILArgumentException("det: A must be a matrix"); 
            int m = A.Dimensions[0]; 
            if (m != A.Dimensions[1]) {
                throw new ILArgumentException("det: matrix A must be square"); 
            }

            ILArray<complex> L = A.C; 
            int [] pivInd = new int[m]; 
            int info = 0; 
            Lapack.zgetrf (m, m, L.m_data, m, pivInd ,ref info); 
            if (info < 0 ) {
                throw new ILArgumentException("det: illegal parameter error.");
            }
            // determine pivoting: number of exchanges 
            complex retA =  new complex(1.0,0.0) ; 
            for (int i = 0; i < m;) {
                retA *= L.m_data[i * m + i]; 
                if (pivInd[i] != ++i) retA *=  -1.0 ; 
            }
            L.Dispose(); 
            return new  ILArray<complex> ( retA ); 
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
