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
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>complex</destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>double</destination>
</type>
<type>
    <source locate="after">
        unityVal
    </source>
    <destination>new complex(1.0,0.0)</destination>
</type>
<type>
    <source locate="after">
        posInfty
    </source>
    <destination>new complex(double.PositiveInfinity,double.PositiveInfinity)</destination>
</type>
<type>
    <source locate="after">
        unityValNoCmplx
    </source>
    <destination>1.0</destination>
</type>
<type>
    <source locate="after">
        zeroVal
    </source>
    <destination>new complex(0.0,0.0)</destination>
</type>
<type>
    <source locate="after">
        lapack.?trtrs
    </source>
    <destination>Lapack.ztrtrs</destination>
</type>
<type>
    <source locate="after">
        notANumber
    </source>
    <destination>new complex(double.NaN,double.NaN)</destination>
</type>
<type>
    <source locate="after">
        lapack_*getrf
    </source>
    <destination>Lapack.zgetrf</destination>
</type>
<type>
    <source locate="after">
        lapack_*getrs
    </source>
    <destination>Lapack.zgetrs</destination>
</type>
<type>
    <source locate="after">
        lapack_*potrs
    </source>
    <destination>Lapack.zpotrs</destination>
</type>
<type>
    <source locate="after">
        lapack_*potrf
    </source>
    <destination>Lapack.zpotrf</destination>
</type>
<type>
    <source locate="after">
        Lapack.?gelsy
    </source>
    <destination>Lapack.zgelsy</destination>
</type>
<type>
    <source locate="after">
        HycalpEPS
    </source>
    <destination>ILMath.MachineParameterDouble.eps</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        
        /// <summary>
        /// Solve linear equation system
        /// </summary>
        /// <param name="A">Matrix A. Size [n x q]</param>
        /// <param name="B">'rigth hand side' B. Size [n x m]</param>
        /// <returns> solution x solving the equation system: multiply(A, x) = B. Size [n x m]</returns>
        /// <remarks><para>depending on the structure and properties of A, the equation system will be solved in different ways:
        /// <list type="bullet">
        /// <item>If A is square (q == n) and an <b>upper or lower triangular</b> matrix, the system will directly be solved via backward- or forward substitution. Therefore the Lapack function ?trtrs will be used, whenever the memory layout of A is suitable. This may be the case even for reference ILArray's! 
        /// <example><![CDATA[ILArray<double> A = ILMath.randn(4); // construct 4 x 4 matrix 
        /// A = A.T; // A is a reference array now! The transpose is fast and does not consume much memory
        /// // now construct a right side and solve the equations: 
        /// ILArray<double> B = new ILArray<double> (1.0,2.0,3.0).T; 
        /// ILMath.linsolve(A,B); // ... will be carried out via Lapack, even for all arrays involved beeing reference arrays! ]]></example></item>
        /// <item><para>if A is square and symmetric or hermitian, A will be decomposed into a triangular equation system using cholesky factorization and Lapack. The system is than solved using performant Lapack routines.</para>
        /// <para>if during the cholesky factorization A was found to be <b>not positive definite</b> - the cholesky factorization is canceled. </para></item>
        /// <item>otherwise, if A is square only, it will be decomposed into upper and lower triangular martices using LU decomposition and Lapack. The triangular system is than solved using performant Lapack routines.</item>
        /// <item>otherwise, if A is of size [q x n] and q != n, the system is solved using QR decomposition. A may be rank deficient. The solution is computed by use of the Lapack routine '?gelsy' and may be a reference array.</item>
        /// </list></para>
        /// <para>Compatibility with Matlab<sup>(R)</sup>: If A is square, the algorithm used follows the same logic as Matlab up to Rel 14, with the exception of Hessenberg matrices wich are solved via LU factorization here. The un-squared case is handled differently. A direct Lapack driver function (?gelsy) is used here. Therefore the solutions might differ! However, the solution will of course fullfill the equation A * x = B without round off errrors. </para>
        /// <para>For specifiying the rank of A in the unsquare case (q != n), the eps member from <see cref="ILNumerics.Settings.ILSettings"/> class is used.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> linsolve(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls1*/ ILArray<double> B) {
            if (object.Equals(A,null) || object.Equals(B,null))
                throw new ILArgumentException("linsolve: parameter must not be null!");
            MatrixProperties props = MatrixProperties.None;
            if (A.Dimensions[0] == A.Dimensions[1]) {
                props |= MatrixProperties.Square; 
                if (ILMath.istriup(A)) {
                    props |= MatrixProperties.UpperTriangular; 
                    return linsolve(A,B,ref props); 
                } 
                if (ILMath.istrilow(A)) {
                    props |= MatrixProperties.LowerTriangular; 
                    return linsolve(A,B,ref props); 
                }
                if (ILMath.ishermitian(A)) {
                    // give cholesky a try
                    props |= MatrixProperties.Hermitian; 
                    props |= MatrixProperties.PositivDefinite;
                    /*!HC:inCls1*/ ILArray<double> ret = linsolve(A,B,ref props); 
                    if (!object.Equals(ret,null)) {
                        return ret;
                    } else {
                        props ^= MatrixProperties.PositivDefinite;
                    }
                }
            }
            return linsolve(A,B,ref props); 
        }

        /// <summary>
        /// Solve linear equation system
        /// </summary>
        /// <param name="A">Matrix A. Size [n x q]</param>
        /// <param name="B">'rigth hand side' B. Size [n x m]</param>
        /// <param name="props">Matrix properties. If defined, no checks are made for the structure of A. If the matrix A was found to be (close to or) singular, the 'MatrixProperties.Singular' flag in props will be set. This flag should be tested on return, in order to verify the reliability of the solution.</param>
        /// <returns>the solution x solving multiply(A,x) = B. Size [n x m]</returns>
        /// <remarks><para>depending on the <paramref name="props"/> parameter the equation system will be solved differently for special structures of A:
        /// <list type="bullet">
        /// <item>If A is square (q == n) and an <b>upper or lower triangular</b> matrix, the system will directly be solved via backward- or forward substitution. Therefore the Lapack function ?trtrs will be used, whenever the memory layout of A is suitable. This may be the case even for reference ILArray's! 
        /// <example><![CDATA[ILArray<double> A = ILMath.randn(4); // construct 4 x 4 matrix 
        /// A = A.T; // A is a reference array now! The transpose is fast and does not consume much memory
        /// // now construct a right side and solve the equations: 
        /// ILArray<double> B = new ILArray<double> (1.0,2.0,3.0).T; 
        /// ILMath.linsolve(A,B); // ... will be carried out via Lapack, even for all arrays involved beeing reference arrays! ]]></example></item>
        /// <item><para>if A is square and symmetric or hermitian, A will be decomposed into a triangular equation system using cholesky factorization and Lapack. The system is than solved using performant Lapack routines.</para>
        /// <para>if during the cholesky factorization A was found to be <b>not positive definite</b> - the corresponding flag in props will be cleaned and <c>null</c> will be returned.</para></item>
        /// <item>otherwise if A is square only, it will be decomposed into upper and lower triangular matrices using LU decomposition and Lapack. The triangular system is than solved using performant Lapack routines.</item>
        /// <item>otherwise, if A is of size [q x n] and q != n, the system is solved using QR decomposition. A may be rank deficient. The solution is computed by use of the Lapack routine '?gelsy' and may be a reference array.</item>
        /// </list></para>
        /// <para>Compatibility with Matlab<sup>(R)</sup>: If A is square, the algorithm used follows the same logic as Matlab up to Rel 14, with the exception of Hessenberg matrices wich are solved via LU factorization here. The un-squared case is handled differently. A direct Lapack driver function (?gelsy) is used here. Therefore the solutions might differ! However, the solution will of course fullfill the equation A * x = B without round off errrors. </para>
        /// <para>For specifiying the rank of A in the unsquare case (q != n), the eps member from <see cref="ILNumerics.Settings.ILSettings"/> class is used.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> linsolve(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls1*/ ILArray<double> B, ref MatrixProperties props) {
            if (object.Equals(A,null)) 
                throw new ILArgumentException("linsolve: input argument A must not be null!"); 
            if (object.Equals(B,null))
                throw new ILArgumentException("linsolve: input argument B must not be null!"); 
            if (A.IsEmpty || B.IsEmpty)
                return /*!HC:inCls1*/ ILArray<double> .empty(A.Dimensions); 
            if (A.Dimensions[0] != B.Dimensions[0])
                throw new ILArgumentException("linsolve: number of rows for matrix A must match number of rows for RHS!");
            int info = 0, m = A.Dimensions[0]; 
            /*!HC:inCls1*/ ILArray<double> ret; 
            if (m == A.Dimensions[1]) {
                props |= MatrixProperties.Square; 
                if ((props & MatrixProperties.LowerTriangular) != 0) {
                    ret = solveLowerTriangularSystem(A,B,ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                    return ret;
                } 
                if ((props & MatrixProperties.UpperTriangular) != 0) {
                    ret = solveUpperTriangularSystem(A,B, ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                   return ret; 
                } 
                if ((props & MatrixProperties.Hermitian) != 0) {
                    /*!HC:inCls1*/ ILArray<double> cholFact = A.copyUpperTriangle(m);
                    /*!HC:lapack_*potrf*/ Lapack.dpotrf ('U', m, cholFact.m_data, m, ref info); 
                    if (info > 0) {
                        props ^= MatrixProperties.Hermitian; 
                        return null; 
                    }  else {
                        // solve 
                        ret = (/*!HC:inCls1*/ ILArray<double> )B.Clone(); 
                        /*!HC:lapack_*potrs*/ Lapack.dpotrs ('U',m,B.Dimensions[1],cholFact.m_data,m,ret.m_data,m,ref info);   
                        return ret; 
                    } 
                } else {
                    // attempt complete (expensive) LU factorization 
                    /*!HC:inCls1*/ ILArray<double> L = (/*!HC:inCls1*/ ILArray<double> )A.Clone();  
                    int [] pivInd = new int[m]; 
                    /*!HC:lapack_*getrf*/ Lapack.dgetrf (m, m, L.m_data, m, pivInd ,ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                    ret = (/*!HC:inCls1*/ ILArray<double> )B.Clone(); 
                    /*!HC:lapack_*getrs*/ Lapack.dgetrs ('N',m,B.Dimensions[1],L.m_data,m,pivInd,ret.m_data,m,ref info); 
                    if (info < 0) 
                        throw new ILArgumentException("linsolve: failed to solve via lapack dgetrs");
                    return ret; 
                }
            } else {
                // under- / overdetermined system
                int n = A.Dimensions[1], rank = 0, minMN = (m < n)? m:n, maxMN = (m > n)? m:n;
                int nrhs = B.Dimensions[1];
                if (B.Dimensions[0] != m) 
                    throw new ILArgumentException("linsolve: right hand side matrix B must match input A!"); 
                /*!HC:inCls1*/ ILArray<double> tmpA = (/*!HC:inCls1*/ ILArray<double> )A.Clone();
                if (m < n) {
                    ret = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [n * nrhs],n,nrhs);
                    ret["0:"+(m-1)+";:"] = B;
                } else {
                    ret = (/*!HC:inCls1*/ ILArray<double> )B.Clone();
                }
                int [] JPVT = new int [n]; 
                /*!HC:Lapack.?gelsy*/ Lapack.dgelsy (m, n, B.Dimensions[1], tmpA.m_data, m, ret.m_data, 
                                    maxMN, JPVT, /*!HC:HycalpEPS*/ ILMath.MachineParameterDouble.eps ,
                                    ref rank, ref info); 
                if (n < m) {
                    ret = ret[ILMath.vector(0,n-1),null];
                }
                if (rank < minMN)
                    props |= MatrixProperties.RankDeficient; 
                return ret; 
            }
        }
        
        /// <summary>
        /// Solve system of linear equations A*x = b, with A beeing a upper triangular matrix
        /// </summary>
        /// <param name="A">input matrix of Size [n x n], must be upper triangular. No check is made for that!</param>
        /// <param name="B">solution vector or matrix. Size [n x m]</param>
        /// <param name="singularityDetect">output: this value gives the row of A, where a singularity has been detected (if any). If A is not singular, this will be a negative value.</param>
        /// <returns>Solution x solving A * x = b.</returns>
        /// <remarks><para>The solution will be determined via backward substitution</para>
        /// <para>Make sure, A and b are of correct size, since no checks are made for that!</para>
        /// <para>This function is used by ILMath.linsolve. There should be rare need for you to call this function directly.</para>
        /// <para>Elements of A below the main diagonal will not be accessed.</para>
        /// <para>If A has been found to be singular, the array returned will contain NaN values for corresponding elements!</para></remarks>
        internal static /*!HC:inCls1*/ ILArray<double> solveUpperTriangularSystem (/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls1*/ ILArray<double> B, ref int singularityDetect) {
            //System.Diagnostics.Debug.Assert(B.Dimensions[1] >= 0); 
            //System.Diagnostics.Debug.Assert(B.Dimensions[0] == A.Dimensions[1]); 
            //System.Diagnostics.Debug.Assert(A.Dimensions[0] == A.Dimensions[1]); 
            //singularityDetect = -1; 
            //int n = A.Dimensions[0]; 
            //int m = B.Dimensions[1]; 
            //int spacingA0, spacingA1, info = 0; 
            //char transA; 
            ///*!HC:inCls1*/ ILArray<double> ret = (/*!HC:inCls1*/ ILArray<double> )B.Clone();
            ///*!HC:inArr1*/ double [] retArr = ret.m_data;  
            //if (isSuitableForLapack(A,out spacingA0,out spacingA1,out transA)) {
            //    // solve using Lapack
            //    unsafe {
            //        fixed (/*!HC:inArr1*/ double * ptrA = A.m_data) 
            //        fixed (/*!HC:inArr1*/ double * ptrB = ret.m_data) {
            //            /*!HC:inArr1*/ double * pA = ptrA + A.getBaseIndex(0); 
            //            /*!HC:lapack.?trtrs*/ Lapack.dtrtrs ((transA == 'T')? 'L':'U',transA,'N',A.Dimensions[0],ret.Dimensions[1],(IntPtr)pA,spacingA1,(IntPtr)ptrB,n,ref info);
            //            if (info < 0) 
            //                throw new ILArgumentException ("linsolve: error inside Lapack function ?trtrs for argument: " + (-info));
            //            if (info > 0) {
            //                singularityDetect = info-1;
            //                for (spacingA0 = 0; spacingA0 < ret.Dimensions[1]; spacingA0++) {
            //                    info = spacingA0 * n; 
            //                    for (spacingA1 = singularityDetect; spacingA1 --> 0;) {
            //                        retArr[info++] = /*!HC:notANumber*/ double.NaN ;     
            //                    }
            //                }
            //            } else {
            //                singularityDetect = -1; 
            //            }
            //        }
            //    }
            //    return ret; 
            //}
            //// must do it manually.... 
            //int[] Adim0 = A.m_indexOffset[0]; 
            //int[] Adim1 = A.m_indexOffset[1];    
            ///*!HC:inArr1*/ double diagVal = /*!HC:zeroVal*/ 0.0 ;
            ///*!HC:inArr1*/ double tmpVal;
            //for (int b = 0; b < m; b++) {
            //    for (int r = n; r --> 0;) {
            //        tmpVal = /*!HC:zeroVal*/ 0.0 ; 
            //        diagVal = A.GetValue(r,r); 
            //        if (diagVal == /*!HC:zeroVal*/ 0.0 ) {
            //            singularityDetect = r; 
            //            for (; r --> 0;)
            //                retArr[r + b * n] = /*!HC:posInfty*/ double.PositiveInfinity ; 
            //        } else {
            //            for (int c = r+1; c < n; c++) {
            //                tmpVal += A.m_data[Adim0[r] + Adim1[c]] * retArr[c + b * n]; 
            //            }
            //            retArr[r + b * n] = (retArr[r + b * n] - tmpVal) / diagVal; 
            //        }
            //    }
            //}
            //ret = new /*!HC:inCls1*/ ILArray<double> (retArr,n,m); 
            //return ret; 

            throw new NotImplementedException();
        }

        /// <summary>
        /// Solve system of linear equations A*x = b, with A beeing a lower triangular matrix
        /// </summary>
        /// <param name="A">input matrix of Size [n x n], must be lower triangular. No check is made for that!</param>
        /// <param name="B">solution vector. Size [n x 1]</param>
        /// <param name="singularityDetect">output: this value gives the row of A, where a singularity has been detected (if any). If A is not singular, this will be a negative value.</param>
        /// <returns>Solution x solving A * x = b.</returns>
        /// <remarks><para>The solution will be determined via forward substitution</para>
        /// <para>Make sure, A and b are of correct size, since no checks are made for that!</para>
        /// <para>This function is used by ILMath.linsolve. There should be rare need for you to call this function directly.</para>
        /// <para>Elements of A above the main diagonal will not be accessed.</para>
        /// <para>If A has been found to be singular, the array returned will contain NaN values for corresponding elements!</para></remarks>
        internal static /*!HC:inCls1*/ ILArray<double> solveLowerTriangularSystem (/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls1*/ ILArray<double> B, ref int singularityDetect) {
            //System.Diagnostics.Debug.Assert(B.Dimensions[1] >= 0); 
            //System.Diagnostics.Debug.Assert(B.Dimensions[0] == A.Dimensions[1]); 
            //System.Diagnostics.Debug.Assert(A.Dimensions[0] == A.Dimensions[1]); 
            //singularityDetect = -1; 
            //int n = A.Dimensions[0]; 
            //int m = B.Dimensions[1]; 
            //int spacingA0, spacingA1, info = 0; 
            //char transA; 
            ///*!HC:inCls1*/ ILArray<double> ret = (/*!HC:inCls1*/ ILArray<double> )B.Clone(); 
            ///*!HC:inArr1*/ double [] retArr = ret.m_data;  
            //if (isSuitableForLapack(A,out spacingA0,out spacingA1,out transA)) {
            //    // solve using Lapack
            //    unsafe {
            //        fixed (/*!HC:inArr1*/ double * ptrA = A.m_data) 
            //        fixed (/*!HC:inArr1*/ double * ptrB = ret.m_data) {
            //            /*!HC:inArr1*/ double * pA = ptrA + A.getBaseIndex(0); 
            //            /*!HC:lapack.?trtrs*/ Lapack.dtrtrs ((transA == 'T')? 'U':'L',transA,'N',A.Dimensions[0],ret.Dimensions[1],(IntPtr)pA,spacingA1,(IntPtr)ptrB,n,ref info);
            //            if (info < 0) 
            //                throw new ILArgumentException ("linsolve: error inside Lapack function ?trtrs for argument: " + (-info));
            //            if (info > 0) {
            //                singularityDetect = info-1;
            //                retArr = ret.m_data; 
            //                for (spacingA0 = 0; spacingA0 < ret.Dimensions[1]; spacingA0++) {
            //                    info = spacingA0 * n + singularityDetect; 
            //                    for (spacingA1 = singularityDetect; spacingA1 < n; spacingA1++) {
            //                        retArr[info++] = /*!HC:notANumber*/ double.NaN ;     
            //                    }
            //                }
            //            } else {
            //                singularityDetect = -1; 
            //            }
            //        }
            //    }
            //    return ret; 
            //}
            //// must do it manually.... 
            //int[] Adim0 = A.m_indexOffset[0]; 
            //int[] Adim1 = A.m_indexOffset[1];    
            ///*!HC:inArr1*/ double diagVal = /*!HC:zeroVal*/ 0.0 ;
            ///*!HC:inArr1*/ double tmpVal;
            //for (int b = 0; b < m; b++) {
            //    for (int r = 0; r < n; r++) {
            //        tmpVal = /*!HC:zeroVal*/ 0.0 ; 
            //        diagVal = A.GetValue(r,r); 
            //        if (diagVal == /*!HC:zeroVal*/ 0.0 ) {
            //            singularityDetect = r; 
            //            for (; r < n; r++)
            //                retArr[r + b * n] = /*!HC:posInfty*/ double.PositiveInfinity ; 
            //        } else {
            //            for (int c = 0; c < r; c++) {
            //                tmpVal +=  A.m_data[Adim0[r] + Adim1[c]] * retArr[c + b * n]; 
            //            }
            //            retArr[r + b * n] = (retArr[r + b * n] - tmpVal) / diagVal; 
            //        }
            //    }
            //}
            //ret = new /*!HC:inCls1*/ ILArray<double> (retArr,n,m); 
            //return ret; 

            throw new NotImplementedException();
        }

        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        
        /// <summary>
        /// Solve linear equation system
        /// </summary>
        /// <param name="A">Matrix A. Size [n x q]</param>
        /// <param name="B">'rigth hand side' B. Size [n x m]</param>
        /// <returns> solution x solving the equation system: multiply(A, x) = B. Size [n x m]</returns>
        /// <remarks><para>depending on the structure and properties of A, the equation system will be solved in different ways:
        /// <list type="bullet">
        /// <item>If A is square (q == n) and an <b>upper or lower triangular</b> matrix, the system will directly be solved via backward- or forward substitution. Therefore the Lapack function ?trtrs will be used, whenever the memory layout of A is suitable. This may be the case even for reference ILArray's! 
        /// <example><![CDATA[ILArray<double> A = ILMath.randn(4); // construct 4 x 4 matrix 
        /// A = A.T; // A is a reference array now! The transpose is fast and does not consume much memory
        /// // now construct a right side and solve the equations: 
        /// ILArray<double> B = new ILArray<double> (1.0,2.0,3.0).T; 
        /// ILMath.linsolve(A,B); // ... will be carried out via Lapack, even for all arrays involved beeing reference arrays! ]]></example></item>
        /// <item><para>if A is square and symmetric or hermitian, A will be decomposed into a triangular equation system using cholesky factorization and Lapack. The system is than solved using performant Lapack routines.</para>
        /// <para>if during the cholesky factorization A was found to be <b>not positive definite</b> - the cholesky factorization is canceled. </para></item>
        /// <item>otherwise, if A is square only, it will be decomposed into upper and lower triangular martices using LU decomposition and Lapack. The triangular system is than solved using performant Lapack routines.</item>
        /// <item>otherwise, if A is of size [q x n] and q != n, the system is solved using QR decomposition. A may be rank deficient. The solution is computed by use of the Lapack routine '?gelsy' and may be a reference array.</item>
        /// </list></para>
        /// <para>Compatibility with Matlab<sup>(R)</sup>: If A is square, the algorithm used follows the same logic as Matlab up to Rel 14, with the exception of Hessenberg matrices wich are solved via LU factorization here. The un-squared case is handled differently. A direct Lapack driver function (?gelsy) is used here. Therefore the solutions might differ! However, the solution will of course fullfill the equation A * x = B without round off errrors. </para>
        /// <para>For specifiying the rank of A in the unsquare case (q != n), the eps member from <see cref="ILNumerics.Settings.ILSettings"/> class is used.</para></remarks>
        public static  ILArray<complex> linsolve( ILArray<complex> A,  ILArray<complex> B) {
            if (object.Equals(A,null) || object.Equals(B,null))
                throw new ILArgumentException("linsolve: parameter must not be null!");
            MatrixProperties props = MatrixProperties.None;
            if (A.Dimensions[0] == A.Dimensions[1]) {
                props |= MatrixProperties.Square; 
                if (ILMath.istriup(A)) {
                    props |= MatrixProperties.UpperTriangular; 
                    return linsolve(A,B,ref props); 
                } 
                if (ILMath.istrilow(A)) {
                    props |= MatrixProperties.LowerTriangular; 
                    return linsolve(A,B,ref props); 
                }
                if (ILMath.ishermitian(A)) {
                    // give cholesky a try
                    props |= MatrixProperties.Hermitian; 
                    props |= MatrixProperties.PositivDefinite;
                    ILArray<complex> ret = linsolve(A,B,ref props); 
                    if (!object.Equals(ret,null)) {
                        return ret;
                    } else {
                        props ^= MatrixProperties.PositivDefinite;
                    }
                }
            }
            return linsolve(A,B,ref props); 
        }

        /// <summary>
        /// Solve linear equation system
        /// </summary>
        /// <param name="A">Matrix A. Size [n x q]</param>
        /// <param name="B">'rigth hand side' B. Size [n x m]</param>
        /// <param name="props">Matrix properties. If defined, no checks are made for the structure of A. If the matrix A was found to be (close to or) singular, the 'MatrixProperties.Singular' flag in props will be set. This flag should be tested on return, in order to verify the reliability of the solution.</param>
        /// <returns>the solution x solving multiply(A,x) = B. Size [n x m]</returns>
        /// <remarks><para>depending on the <paramref name="props"/> parameter the equation system will be solved differently for special structures of A:
        /// <list type="bullet">
        /// <item>If A is square (q == n) and an <b>upper or lower triangular</b> matrix, the system will directly be solved via backward- or forward substitution. Therefore the Lapack function ?trtrs will be used, whenever the memory layout of A is suitable. This may be the case even for reference ILArray's! 
        /// <example><![CDATA[ILArray<double> A = ILMath.randn(4); // construct 4 x 4 matrix 
        /// A = A.T; // A is a reference array now! The transpose is fast and does not consume much memory
        /// // now construct a right side and solve the equations: 
        /// ILArray<double> B = new ILArray<double> (1.0,2.0,3.0).T; 
        /// ILMath.linsolve(A,B); // ... will be carried out via Lapack, even for all arrays involved beeing reference arrays! ]]></example></item>
        /// <item><para>if A is square and symmetric or hermitian, A will be decomposed into a triangular equation system using cholesky factorization and Lapack. The system is than solved using performant Lapack routines.</para>
        /// <para>if during the cholesky factorization A was found to be <b>not positive definite</b> - the corresponding flag in props will be cleaned and <c>null</c> will be returned.</para></item>
        /// <item>otherwise if A is square only, it will be decomposed into upper and lower triangular matrices using LU decomposition and Lapack. The triangular system is than solved using performant Lapack routines.</item>
        /// <item>otherwise, if A is of size [q x n] and q != n, the system is solved using QR decomposition. A may be rank deficient. The solution is computed by use of the Lapack routine '?gelsy' and may be a reference array.</item>
        /// </list></para>
        /// <para>Compatibility with Matlab<sup>(R)</sup>: If A is square, the algorithm used follows the same logic as Matlab up to Rel 14, with the exception of Hessenberg matrices wich are solved via LU factorization here. The un-squared case is handled differently. A direct Lapack driver function (?gelsy) is used here. Therefore the solutions might differ! However, the solution will of course fullfill the equation A * x = B without round off errrors. </para>
        /// <para>For specifiying the rank of A in the unsquare case (q != n), the eps member from <see cref="ILNumerics.Settings.ILSettings"/> class is used.</para></remarks>
        public static  ILArray<complex> linsolve( ILArray<complex> A,  ILArray<complex> B, ref MatrixProperties props) {
            if (object.Equals(A,null)) 
                throw new ILArgumentException("linsolve: input argument A must not be null!"); 
            if (object.Equals(B,null))
                throw new ILArgumentException("linsolve: input argument B must not be null!"); 
            if (A.IsEmpty || B.IsEmpty)
                return  ILArray<complex> .empty(A.Dimensions); 
            if (A.Dimensions[0] != B.Dimensions[0])
                throw new ILArgumentException("linsolve: number of rows for matrix A must match number of rows for RHS!");
            int info = 0, m = A.Dimensions[0]; 
            ILArray<complex> ret; 
            if (m == A.Dimensions[1]) {
                props |= MatrixProperties.Square; 
                if ((props & MatrixProperties.LowerTriangular) != 0) {
                    ret = solveLowerTriangularSystem(A,B,ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                    return ret;
                } 
                if ((props & MatrixProperties.UpperTriangular) != 0) {
                    ret = solveUpperTriangularSystem(A,B, ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                   return ret; 
                } 
                if ((props & MatrixProperties.Hermitian) != 0) {
                    ILArray<complex> cholFact = A.copyUpperTriangle(m);
                    Lapack.zpotrf ('U', m, cholFact.m_data, m, ref info); 
                    if (info > 0) {
                        props ^= MatrixProperties.Hermitian; 
                        return null; 
                    }  else {
                        // solve 
                        ret = ( ILArray<complex> )B.Clone(); 
                        Lapack.zpotrs ('U',m,B.Dimensions[1],cholFact.m_data,m,ret.m_data,m,ref info);   
                        return ret; 
                    } 
                } else {
                    // attempt complete (expensive) LU factorization 
                    ILArray<complex> L = ( ILArray<complex> )A.Clone();  
                    int [] pivInd = new int[m]; 
                    Lapack.zgetrf (m, m, L.m_data, m, pivInd ,ref info); 
                    if (info > 0)
                        props |= MatrixProperties.Singular; 
                    ret = ( ILArray<complex> )B.Clone(); 
                    Lapack.zgetrs ('N',m,B.Dimensions[1],L.m_data,m,pivInd,ret.m_data,m,ref info); 
                    if (info < 0) 
                        throw new ILArgumentException("linsolve: failed to solve via lapack dgetrs");
                    return ret; 
                }
            } else {
                // under- / overdetermined system
                int n = A.Dimensions[1], rank = 0, minMN = (m < n)? m:n, maxMN = (m > n)? m:n;
                int nrhs = B.Dimensions[1];
                if (B.Dimensions[0] != m) 
                    throw new ILArgumentException("linsolve: right hand side matrix B must match input A!"); 
                ILArray<complex> tmpA = ( ILArray<complex> )A.Clone();
                if (m < n) {
                    ret = new  ILArray<complex> (new  complex [n * nrhs],n,nrhs);
                    ret["0:"+(m-1)+";:"] = B;
                } else {
                    ret = ( ILArray<complex> )B.Clone();
                }
                int [] JPVT = new int [n]; 
                Lapack.zgelsy (m, n, B.Dimensions[1], tmpA.m_data, m, ret.m_data, 
                                    maxMN, JPVT,  ILMath.MachineParameterDouble.eps ,
                                    ref rank, ref info); 
                if (n < m) {
                    ret = ret[ILMath.vector(0,n-1),null];
                }
                if (rank < minMN)
                    props |= MatrixProperties.RankDeficient; 
                return ret; 
            }
        }
        
        /// <summary>
        /// Solve system of linear equations A*x = b, with A beeing a upper triangular matrix
        /// </summary>
        /// <param name="A">input matrix of Size [n x n], must be upper triangular. No check is made for that!</param>
        /// <param name="B">solution vector or matrix. Size [n x m]</param>
        /// <param name="singularityDetect">output: this value gives the row of A, where a singularity has been detected (if any). If A is not singular, this will be a negative value.</param>
        /// <returns>Solution x solving A * x = b.</returns>
        /// <remarks><para>The solution will be determined via backward substitution</para>
        /// <para>Make sure, A and b are of correct size, since no checks are made for that!</para>
        /// <para>This function is used by ILMath.linsolve. There should be rare need for you to call this function directly.</para>
        /// <para>Elements of A below the main diagonal will not be accessed.</para>
        /// <para>If A has been found to be singular, the array returned will contain NaN values for corresponding elements!</para></remarks>
        internal static  ILArray<complex> solveUpperTriangularSystem ( ILArray<complex> A,  ILArray<complex> B, ref int singularityDetect) {
            //System.Diagnostics.Debug.Assert(B.Dimensions[1] >= 0); 
            //System.Diagnostics.Debug.Assert(B.Dimensions[0] == A.Dimensions[1]); 
            //System.Diagnostics.Debug.Assert(A.Dimensions[0] == A.Dimensions[1]); 
            //singularityDetect = -1; 
            //int n = A.Dimensions[0]; 
            //int m = B.Dimensions[1]; 
            //int spacingA0, spacingA1, info = 0; 
            //char transA; 
            // ILArray<complex> ret = ( ILArray<complex> )B.Clone();
            // complex [] retArr = ret.m_data;  
            //if (isSuitableForLapack(A,out spacingA0,out spacingA1,out transA)) {
            //    // solve using Lapack
            //    unsafe {
            //        fixed ( complex * ptrA = A.m_data) 
            //        fixed ( complex * ptrB = ret.m_data) {
            //            complex * pA = ptrA + A.getBaseIndex(0); 
            //            Lapack.ztrtrs ((transA == 'T')? 'L':'U',transA,'N',A.Dimensions[0],ret.Dimensions[1],(IntPtr)pA,spacingA1,(IntPtr)ptrB,n,ref info);
            //            if (info < 0) 
            //                throw new ILArgumentException ("linsolve: error inside Lapack function ?trtrs for argument: " + (-info));
            //            if (info > 0) {
            //                singularityDetect = info-1;
            //                for (spacingA0 = 0; spacingA0 < ret.Dimensions[1]; spacingA0++) {
            //                    info = spacingA0 * n; 
            //                    for (spacingA1 = singularityDetect; spacingA1 --> 0;) {
            //                        retArr[info++] =  new complex(double.NaN,double.NaN) ;     
            //                    }
            //                }
            //            } else {
            //                singularityDetect = -1; 
            //            }
            //        }
            //    }
            //    return ret; 
            //}
            //// must do it manually.... 
            //int[] Adim0 = A.m_indexOffset[0]; 
            //int[] Adim1 = A.m_indexOffset[1];    
            // complex diagVal =  new complex(0.0,0.0) ;
            // complex tmpVal;
            //for (int b = 0; b < m; b++) {
            //    for (int r = n; r --> 0;) {
            //        tmpVal =  new complex(0.0,0.0) ; 
            //        diagVal = A.GetValue(r,r); 
            //        if (diagVal ==  new complex(0.0,0.0) ) {
            //            singularityDetect = r; 
            //            for (; r --> 0;)
            //                retArr[r + b * n] =  new complex(double.PositiveInfinity,double.PositiveInfinity) ; 
            //        } else {
            //            for (int c = r+1; c < n; c++) {
            //                tmpVal += A.m_data[Adim0[r] + Adim1[c]] * retArr[c + b * n]; 
            //            }
            //            retArr[r + b * n] = (retArr[r + b * n] - tmpVal) / diagVal; 
            //        }
            //    }
            //}
            //ret = new  ILArray<complex> (retArr,n,m); 
            //return ret; 

            throw new NotImplementedException();
        }

        /// <summary>
        /// Solve system of linear equations A*x = b, with A beeing a lower triangular matrix
        /// </summary>
        /// <param name="A">input matrix of Size [n x n], must be lower triangular. No check is made for that!</param>
        /// <param name="B">solution vector. Size [n x 1]</param>
        /// <param name="singularityDetect">output: this value gives the row of A, where a singularity has been detected (if any). If A is not singular, this will be a negative value.</param>
        /// <returns>Solution x solving A * x = b.</returns>
        /// <remarks><para>The solution will be determined via forward substitution</para>
        /// <para>Make sure, A and b are of correct size, since no checks are made for that!</para>
        /// <para>This function is used by ILMath.linsolve. There should be rare need for you to call this function directly.</para>
        /// <para>Elements of A above the main diagonal will not be accessed.</para>
        /// <para>If A has been found to be singular, the array returned will contain NaN values for corresponding elements!</para></remarks>
        internal static  ILArray<complex> solveLowerTriangularSystem ( ILArray<complex> A,  ILArray<complex> B, ref int singularityDetect) {
            //System.Diagnostics.Debug.Assert(B.Dimensions[1] >= 0); 
            //System.Diagnostics.Debug.Assert(B.Dimensions[0] == A.Dimensions[1]); 
            //System.Diagnostics.Debug.Assert(A.Dimensions[0] == A.Dimensions[1]); 
            //singularityDetect = -1; 
            //int n = A.Dimensions[0]; 
            //int m = B.Dimensions[1]; 
            //int spacingA0, spacingA1, info = 0; 
            //char transA; 
            // ILArray<complex> ret = ( ILArray<complex> )B.Clone(); 
            // complex [] retArr = ret.m_data;  
            //if (isSuitableForLapack(A,out spacingA0,out spacingA1,out transA)) {
            //    // solve using Lapack
            //    unsafe {
            //        fixed ( complex * ptrA = A.m_data) 
            //        fixed ( complex * ptrB = ret.m_data) {
            //            complex * pA = ptrA + A.getBaseIndex(0); 
            //            Lapack.ztrtrs ((transA == 'T')? 'U':'L',transA,'N',A.Dimensions[0],ret.Dimensions[1],(IntPtr)pA,spacingA1,(IntPtr)ptrB,n,ref info);
            //            if (info < 0) 
            //                throw new ILArgumentException ("linsolve: error inside Lapack function ?trtrs for argument: " + (-info));
            //            if (info > 0) {
            //                singularityDetect = info-1;
            //                retArr = ret.m_data; 
            //                for (spacingA0 = 0; spacingA0 < ret.Dimensions[1]; spacingA0++) {
            //                    info = spacingA0 * n + singularityDetect; 
            //                    for (spacingA1 = singularityDetect; spacingA1 < n; spacingA1++) {
            //                        retArr[info++] =  new complex(double.NaN,double.NaN) ;     
            //                    }
            //                }
            //            } else {
            //                singularityDetect = -1; 
            //            }
            //        }
            //    }
            //    return ret; 
            //}
            //// must do it manually.... 
            //int[] Adim0 = A.m_indexOffset[0]; 
            //int[] Adim1 = A.m_indexOffset[1];    
            // complex diagVal =  new complex(0.0,0.0) ;
            // complex tmpVal;
            //for (int b = 0; b < m; b++) {
            //    for (int r = 0; r < n; r++) {
            //        tmpVal =  new complex(0.0,0.0) ; 
            //        diagVal = A.GetValue(r,r); 
            //        if (diagVal ==  new complex(0.0,0.0) ) {
            //            singularityDetect = r; 
            //            for (; r < n; r++)
            //                retArr[r + b * n] =  new complex(double.PositiveInfinity,double.PositiveInfinity) ; 
            //        } else {
            //            for (int c = 0; c < r; c++) {
            //                tmpVal +=  A.m_data[Adim0[r] + Adim1[c]] * retArr[c + b * n]; 
            //            }
            //            retArr[r + b * n] = (retArr[r + b * n] - tmpVal) / diagVal; 
            //        }
            //    }
            //}
            //ret = new  ILArray<complex> (retArr,n,m); 
            //return ret; 

            throw new NotImplementedException();
        }


#endregion HYCALPER AUTO GENERATED CODE
    }
}
