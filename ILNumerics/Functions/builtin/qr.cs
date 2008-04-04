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
        lapack_*geqrf
    </source>
    <destination>Lapack.zgeqrf</destination>
    <destination>Lapack.cgeqrf</destination>
    <destination>Lapack.sgeqrf</destination>
</type>
<type>
    <source locate="after">
        lapack_*orgqr
    </source>
    <destination>Lapack.zungqr</destination>
    <destination>Lapack.cungqr</destination>
    <destination>Lapack.sorgqr</destination>
</type>
<type>
    <source locate="after">
        lapack_*gegqr
    </source>
    <destination>Lapack.zgegqr</destination>
    <destination>Lapack.cgegqr</destination>
    <destination>Lapack.sgegqr</destination>
</type>
<type>
    <source locate="after">
        lapack_*geqp3
    </source>
    <destination>Lapack.zgeqp3</destination>
    <destination>Lapack.cgeqp3</destination>
    <destination>Lapack.sgeqp3</destination>
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
        unityValNoCmplx
    </source>
    <destination>1.0</destination>
    <destination>1.0f</destination>
    <destination>1.0f</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// QR decomposition - raw Lapack output
        /// </summary>
        /// <param name="A">general input matrix A</param>
        /// <returns>orthonormal / unitary matrix Q and upper triangular matrix R packed into single matrix. This is the output of the lapack function ?geqrf.</returns>
        /// <remarks><para>Input matrix A will not be altered. </para>
        /// <para>The matrix returned is the direct output of the lapack function [d,s,c,z]geqrf respectively. This mean that it contains the decomposition factors Q and R, but they are cmbined into a single matrix for performance reasons. If you need one of the factors, 
        /// you would use the overloaded function <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> instead, which returns those factors seperately.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> qr(/*!HC:inCls1*/ ILArray<double> A) {
            if (!A.IsMatrix) 
                throw new ILArgumentException("qr decomposition: A must be a matrix"); 
            int m = A.Dimensions[0], n = A.Dimensions[1]; 
            /*!HC:inCls1*/ ILArray<double> ret = (/*!HC:inCls1*/ ILArray<double> )A.Clone();  
            /*!HC:inArr1*/ double [] tau = new /*!HC:inArr1*/ double [(m<n)?m:n];  
            int info = 0; 
            /*!HC:lapack_*geqrf*/ Lapack.dgeqrf (m,n,ret.m_data,m,tau,ref info); 
            if (info < 0)
                throw new ILArgumentException("qr: an error occoured during decomposition"); 
            return ret; 
        }
        /// <summary>
        /// QR decomposition, returning Q and R
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m]</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> qr(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> R) {
            return qr(A,ref R,false); 
        }
        /// <summary>
        /// QR decomposition, returning Q and R, as economical sized (if choosen)
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="economySize">if true, the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect. </param>
        /// <returns>Orthonormal real / unitary complex matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> qr(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> R, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            /*!HC:inCls1*/ ILArray<double> ret;
            if (m == 0 || n == 0) { 
                R = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [0],m,n); 
                return /*!HC:inCls1*/ ILArray<double> .empty();  
            }
            int minMN = (m<n)?m:n;
            int info = 0; 
            /*!HC:inArr1*/ double [] tau = new /*!HC:inArr1*/ double [minMN];  
            /*!HC:inArr1*/ double [] QArr;
            if (m >= n) {
                ret = new /*!HC:inCls1*/ ILArray<double> (
                                    new /*!HC:inArr1*/ double [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new /*!HC:inCls1*/ ILArray<double> (
                                    new /*!HC:inArr1*/ double [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            /*!HC:lapack_*geqrf*/ Lapack.dgeqrf (m,n,QArr,m,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                /*!HC:lapack_*orgqr*/ Lapack.dorgqr (m,minMN,tau.Length,QArr,m,tau,ref info); 
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                /*!HC:lapack_*orgqr*/ Lapack.dorgqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }
        /// <summary>
        /// QR decomposition with pivoting
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q, R and E such that the equation 
        /// <para>A * E = Q * R</para> holds with roundoff errors, where '*' denotes matrix multiplication. I.e. E reflects the pivoting done inside LAPACK in order to give R increasingly diagonal elements.  
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,bool)"/>
        public static /*!HC:inCls1*/ ILArray<double> qr(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> R, ref /*!HC:inCls1*/ ILArray<double> E) {
            return qr(A, ref R, ref E, false); 
        }
        /// <summary>
        /// QR decomposition with pivoting, possibly economical sized
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] depending on <paramref name="economySize"/> (see remarks). </param>
        /// <param name="economySize"><para>if true, <list type="bullet">
        /// <item>the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect on those sizes.</item>
        /// <item>the output parameter E will be returned as row permutation vector rather than as permutation matrix</item></list></para>
        /// <para>if false, this function acts exactly as its overload <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/></para>
        /// </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]. If this is not null, the permutation matrix/ vector E will be returned.
        /// <para>E is of size [n x n], if <paramref name="economySize"/> is true, a row vector of length n otherwise</para></param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks><para> If <paramref name="economySize"/> is false, the function returns Q, R and E such that the equation A * E = Q * R holds except roundoff errors. </para>
        /// <para>If <paramref name="economySize"/> is true, E will be a permutation vector and the equation A[null,E] == Q * R holds (except roundoff).</para>
        /// <para>E reflects the pivoting of A done inside LAPACK in order to give R increasingly diagonal elements.</para>
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        public static /*!HC:inCls1*/ ILArray<double> qr(/*!HC:inCls1*/ ILArray<double> A, ref /*!HC:inCls1*/ ILArray<double> R, ref /*!HC:inCls1*/ ILArray<double> E, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            /*!HC:inCls1*/ ILArray<double> ret;
            if (m == 0 || n == 0) { 
                R = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [0],m,n); 
                E = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [0],1,0); 
                return /*!HC:inCls1*/ ILArray<double> .empty();  
            }
            // prepare IPVT
            if (object.Equals(E,null)) 
                return qr(A,ref R,economySize); 
            if (!economySize) {
                E = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [n * n],n,n);  
            } else {
                E = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [n],1,n);  
            }
            int [] ipvt = new int[n];
            int minMN = (m<n)?m:n;
            int info = 0; 
            /*!HC:inArr1*/ double [] tau = new /*!HC:inArr1*/ double [minMN];  
            /*!HC:inArr1*/ double [] QArr;
            if (m >= n) {
                ret = new /*!HC:inCls1*/ ILArray<double> (
                                    new /*!HC:inArr1*/ double [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new /*!HC:inCls1*/ ILArray<double> (
                                    new /*!HC:inArr1*/ double [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            /*!HC:lapack_*geqp3*/ Lapack.dgeqp3 (m,n,QArr,m,ipvt,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                /*!HC:lapack_*orgqr*/ Lapack.dorgqr (m,minMN,tau.Length,QArr,m,tau,ref info);
                // transform E into out typed vector
                for (int i = 0; i < n; i++) {
                     E.m_data[i] = ipvt[i] - 1; 
                }
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                /*!HC:lapack_*orgqr*/ Lapack.dorgqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
                // transform E into matrix
                for (int i = 0; i < n; i++) {
                     E.m_data[(ipvt[i]-1) + n * i] = /*!HC:unityValNoCmplx*/ 1.0 ; 
                }
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }

        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// QR decomposition - raw Lapack output
        /// </summary>
        /// <param name="A">general input matrix A</param>
        /// <returns>orthonormal / unitary matrix Q and upper triangular matrix R packed into single matrix. This is the output of the lapack function ?geqrf.</returns>
        /// <remarks><para>Input matrix A will not be altered. </para>
        /// <para>The matrix returned is the direct output of the lapack function [d,s,c,z]geqrf respectively. This mean that it contains the decomposition factors Q and R, but they are cmbined into a single matrix for performance reasons. If you need one of the factors, 
        /// you would use the overloaded function <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> instead, which returns those factors seperately.</para></remarks>
        public static  ILArray<float> qr( ILArray<float> A) {
            if (!A.IsMatrix) 
                throw new ILArgumentException("qr decomposition: A must be a matrix"); 
            int m = A.Dimensions[0], n = A.Dimensions[1]; 
            ILArray<float> ret = ( ILArray<float> )A.Clone();  
            float [] tau = new  float [(m<n)?m:n];  
            int info = 0; 
            Lapack.sgeqrf (m,n,ret.m_data,m,tau,ref info); 
            if (info < 0)
                throw new ILArgumentException("qr: an error occoured during decomposition"); 
            return ret; 
        }
        /// <summary>
        /// QR decomposition, returning Q and R
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m]</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<float> qr( ILArray<float> A, ref  ILArray<float> R) {
            return qr(A,ref R,false); 
        }
        /// <summary>
        /// QR decomposition, returning Q and R, as economical sized (if choosen)
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="economySize">if true, the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect. </param>
        /// <returns>Orthonormal real / unitary complex matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<float> qr( ILArray<float> A, ref  ILArray<float> R, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<float> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<float> (new  float [0],m,n); 
                return  ILArray<float> .empty();  
            }
            int minMN = (m<n)?m:n;
            int info = 0; 
            float [] tau = new  float [minMN];  
            float [] QArr;
            if (m >= n) {
                ret = new  ILArray<float> (
                                    new  float [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<float> (
                                    new  float [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.sgeqrf (m,n,QArr,m,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.sorgqr (m,minMN,tau.Length,QArr,m,tau,ref info); 
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.sorgqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }
        /// <summary>
        /// QR decomposition with pivoting
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q, R and E such that the equation 
        /// <para>A * E = Q * R</para> holds with roundoff errors, where '*' denotes matrix multiplication. I.e. E reflects the pivoting done inside LAPACK in order to give R increasingly diagonal elements.  
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,bool)"/>
        public static  ILArray<float> qr( ILArray<float> A, ref  ILArray<float> R, ref  ILArray<float> E) {
            return qr(A, ref R, ref E, false); 
        }
        /// <summary>
        /// QR decomposition with pivoting, possibly economical sized
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] depending on <paramref name="economySize"/> (see remarks). </param>
        /// <param name="economySize"><para>if true, <list type="bullet">
        /// <item>the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect on those sizes.</item>
        /// <item>the output parameter E will be returned as row permutation vector rather than as permutation matrix</item></list></para>
        /// <para>if false, this function acts exactly as its overload <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/></para>
        /// </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]. If this is not null, the permutation matrix/ vector E will be returned.
        /// <para>E is of size [n x n], if <paramref name="economySize"/> is true, a row vector of length n otherwise</para></param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks><para> If <paramref name="economySize"/> is false, the function returns Q, R and E such that the equation A * E = Q * R holds except roundoff errors. </para>
        /// <para>If <paramref name="economySize"/> is true, E will be a permutation vector and the equation A[null,E] == Q * R holds (except roundoff).</para>
        /// <para>E reflects the pivoting of A done inside LAPACK in order to give R increasingly diagonal elements.</para>
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        public static  ILArray<float> qr( ILArray<float> A, ref  ILArray<float> R, ref  ILArray<float> E, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<float> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<float> (new  float [0],m,n); 
                E = new  ILArray<float> (new  float [0],1,0); 
                return  ILArray<float> .empty();  
            }
            // prepare IPVT
            if (object.Equals(E,null)) 
                return qr(A,ref R,economySize); 
            if (!economySize) {
                E = new  ILArray<float> (new  float [n * n],n,n);  
            } else {
                E = new  ILArray<float> (new  float [n],1,n);  
            }
            int [] ipvt = new int[n];
            int minMN = (m<n)?m:n;
            int info = 0; 
            float [] tau = new  float [minMN];  
            float [] QArr;
            if (m >= n) {
                ret = new  ILArray<float> (
                                    new  float [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<float> (
                                    new  float [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.sgeqp3 (m,n,QArr,m,ipvt,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.sorgqr (m,minMN,tau.Length,QArr,m,tau,ref info);
                // transform E into out typed vector
                for (int i = 0; i < n; i++) {
                     E.m_data[i] = ipvt[i] - 1; 
                }
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.sorgqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
                // transform E into matrix
                for (int i = 0; i < n; i++) {
                     E.m_data[(ipvt[i]-1) + n * i] =  1.0f ; 
                }
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }

        /// <summary>
        /// QR decomposition - raw Lapack output
        /// </summary>
        /// <param name="A">general input matrix A</param>
        /// <returns>orthonormal / unitary matrix Q and upper triangular matrix R packed into single matrix. This is the output of the lapack function ?geqrf.</returns>
        /// <remarks><para>Input matrix A will not be altered. </para>
        /// <para>The matrix returned is the direct output of the lapack function [d,s,c,z]geqrf respectively. This mean that it contains the decomposition factors Q and R, but they are cmbined into a single matrix for performance reasons. If you need one of the factors, 
        /// you would use the overloaded function <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> instead, which returns those factors seperately.</para></remarks>
        public static  ILArray<fcomplex> qr( ILArray<fcomplex> A) {
            if (!A.IsMatrix) 
                throw new ILArgumentException("qr decomposition: A must be a matrix"); 
            int m = A.Dimensions[0], n = A.Dimensions[1]; 
            ILArray<fcomplex> ret = ( ILArray<fcomplex> )A.Clone();  
            fcomplex [] tau = new  fcomplex [(m<n)?m:n];  
            int info = 0; 
            Lapack.cgeqrf (m,n,ret.m_data,m,tau,ref info); 
            if (info < 0)
                throw new ILArgumentException("qr: an error occoured during decomposition"); 
            return ret; 
        }
        /// <summary>
        /// QR decomposition, returning Q and R
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m]</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<fcomplex> qr( ILArray<fcomplex> A, ref  ILArray<fcomplex> R) {
            return qr(A,ref R,false); 
        }
        /// <summary>
        /// QR decomposition, returning Q and R, as economical sized (if choosen)
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="economySize">if true, the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect. </param>
        /// <returns>Orthonormal real / unitary complex matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<fcomplex> qr( ILArray<fcomplex> A, ref  ILArray<fcomplex> R, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<fcomplex> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<fcomplex> (new  fcomplex [0],m,n); 
                return  ILArray<fcomplex> .empty();  
            }
            int minMN = (m<n)?m:n;
            int info = 0; 
            fcomplex [] tau = new  fcomplex [minMN];  
            fcomplex [] QArr;
            if (m >= n) {
                ret = new  ILArray<fcomplex> (
                                    new  fcomplex [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<fcomplex> (
                                    new  fcomplex [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.cgeqrf (m,n,QArr,m,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.cungqr (m,minMN,tau.Length,QArr,m,tau,ref info); 
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.cungqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }
        /// <summary>
        /// QR decomposition with pivoting
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q, R and E such that the equation 
        /// <para>A * E = Q * R</para> holds with roundoff errors, where '*' denotes matrix multiplication. I.e. E reflects the pivoting done inside LAPACK in order to give R increasingly diagonal elements.  
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,bool)"/>
        public static  ILArray<fcomplex> qr( ILArray<fcomplex> A, ref  ILArray<fcomplex> R, ref  ILArray<fcomplex> E) {
            return qr(A, ref R, ref E, false); 
        }
        /// <summary>
        /// QR decomposition with pivoting, possibly economical sized
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] depending on <paramref name="economySize"/> (see remarks). </param>
        /// <param name="economySize"><para>if true, <list type="bullet">
        /// <item>the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect on those sizes.</item>
        /// <item>the output parameter E will be returned as row permutation vector rather than as permutation matrix</item></list></para>
        /// <para>if false, this function acts exactly as its overload <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/></para>
        /// </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]. If this is not null, the permutation matrix/ vector E will be returned.
        /// <para>E is of size [n x n], if <paramref name="economySize"/> is true, a row vector of length n otherwise</para></param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks><para> If <paramref name="economySize"/> is false, the function returns Q, R and E such that the equation A * E = Q * R holds except roundoff errors. </para>
        /// <para>If <paramref name="economySize"/> is true, E will be a permutation vector and the equation A[null,E] == Q * R holds (except roundoff).</para>
        /// <para>E reflects the pivoting of A done inside LAPACK in order to give R increasingly diagonal elements.</para>
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        public static  ILArray<fcomplex> qr( ILArray<fcomplex> A, ref  ILArray<fcomplex> R, ref  ILArray<fcomplex> E, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<fcomplex> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<fcomplex> (new  fcomplex [0],m,n); 
                E = new  ILArray<fcomplex> (new  fcomplex [0],1,0); 
                return  ILArray<fcomplex> .empty();  
            }
            // prepare IPVT
            if (object.Equals(E,null)) 
                return qr(A,ref R,economySize); 
            if (!economySize) {
                E = new  ILArray<fcomplex> (new  fcomplex [n * n],n,n);  
            } else {
                E = new  ILArray<fcomplex> (new  fcomplex [n],1,n);  
            }
            int [] ipvt = new int[n];
            int minMN = (m<n)?m:n;
            int info = 0; 
            fcomplex [] tau = new  fcomplex [minMN];  
            fcomplex [] QArr;
            if (m >= n) {
                ret = new  ILArray<fcomplex> (
                                    new  fcomplex [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<fcomplex> (
                                    new  fcomplex [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.cgeqp3 (m,n,QArr,m,ipvt,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.cungqr (m,minMN,tau.Length,QArr,m,tau,ref info);
                // transform E into out typed vector
                for (int i = 0; i < n; i++) {
                     E.m_data[i] = ipvt[i] - 1; 
                }
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.cungqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
                // transform E into matrix
                for (int i = 0; i < n; i++) {
                     E.m_data[(ipvt[i]-1) + n * i] =  new fcomplex(1.0f,0.0f) ; 
                }
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }

        /// <summary>
        /// QR decomposition - raw Lapack output
        /// </summary>
        /// <param name="A">general input matrix A</param>
        /// <returns>orthonormal / unitary matrix Q and upper triangular matrix R packed into single matrix. This is the output of the lapack function ?geqrf.</returns>
        /// <remarks><para>Input matrix A will not be altered. </para>
        /// <para>The matrix returned is the direct output of the lapack function [d,s,c,z]geqrf respectively. This mean that it contains the decomposition factors Q and R, but they are cmbined into a single matrix for performance reasons. If you need one of the factors, 
        /// you would use the overloaded function <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/> instead, which returns those factors seperately.</para></remarks>
        public static  ILArray<complex> qr( ILArray<complex> A) {
            if (!A.IsMatrix) 
                throw new ILArgumentException("qr decomposition: A must be a matrix"); 
            int m = A.Dimensions[0], n = A.Dimensions[1]; 
            ILArray<complex> ret = ( ILArray<complex> )A.Clone();  
            complex [] tau = new  complex [(m<n)?m:n];  
            int info = 0; 
            Lapack.zgeqrf (m,n,ret.m_data,m,tau,ref info); 
            if (info < 0)
                throw new ILArgumentException("qr: an error occoured during decomposition"); 
            return ret; 
        }
        /// <summary>
        /// QR decomposition, returning Q and R
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m]</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<complex> qr( ILArray<complex> A, ref  ILArray<complex> R) {
            return qr(A,ref R,false); 
        }
        /// <summary>
        /// QR decomposition, returning Q and R, as economical sized (if choosen)
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="economySize">if true, the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect. </param>
        /// <returns>Orthonormal real / unitary complex matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q and R such that the equation 
        /// <para>A = Q * R</para> holds with roundoff errors. ('*' denotes matrix multiplication.) 
        /// <para>Q and R will be solid ILArray's.</para></remarks>
        public static  ILArray<complex> qr( ILArray<complex> A, ref  ILArray<complex> R, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<complex> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<complex> (new  complex [0],m,n); 
                return  ILArray<complex> .empty();  
            }
            int minMN = (m<n)?m:n;
            int info = 0; 
            complex [] tau = new  complex [minMN];  
            complex [] QArr;
            if (m >= n) {
                ret = new  ILArray<complex> (
                                    new  complex [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<complex> (
                                    new  complex [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.zgeqrf (m,n,QArr,m,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.zungqr (m,minMN,tau.Length,QArr,m,tau,ref info); 
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.zungqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }
        /// <summary>
        /// QR decomposition with pivoting
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] (see remarks). </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]</param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks>The function returns Q, R and E such that the equation 
        /// <para>A * E = Q * R</para> holds with roundoff errors, where '*' denotes matrix multiplication. I.e. E reflects the pivoting done inside LAPACK in order to give R increasingly diagonal elements.  
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;, ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,bool)"/>
        public static  ILArray<complex> qr( ILArray<complex> A, ref  ILArray<complex> R, ref  ILArray<complex> E) {
            return qr(A, ref R, ref E, false); 
        }
        /// <summary>
        /// QR decomposition with pivoting, possibly economical sized
        /// </summary>
        /// <param name="A">general input matrix A of size [m x n]</param>
        /// <param name="R">output parameter. Upper triangular matrix R as result of decomposition. Size [m x n] or [min(m,n) x n] depending on <paramref name="economySize"/> (see remarks). </param>
        /// <param name="economySize"><para>if true, <list type="bullet">
        /// <item>the size of Q and R will be [m x m] and [m x n] respectively. However, if m &lt; n, the economySize parameter has no effect on those sizes.</item>
        /// <item>the output parameter E will be returned as row permutation vector rather than as permutation matrix</item></list></para>
        /// <para>if false, this function acts exactly as its overload <see cref="ILNumerics.BuiltInFunctions.ILMath.qr(ILArray&lt;double&gt;,ref ILArray&lt;double&gt;,ref ILArray&lt;double&gt;)"/></para>
        /// </param>
        /// <param name="E">permutation matrix from pivoting. Size [m x m]. If this is not null, the permutation matrix/ vector E will be returned.
        /// <para>E is of size [n x n], if <paramref name="economySize"/> is true, a row vector of length n otherwise</para></param>
        /// <returns>Orthonormal / unitary matrix Q as result of decomposition. Size [m x m] or [m x min(m,n)], depending on <paramref name="economySize"/> (see remarks below)</returns>
        /// <remarks><para> If <paramref name="economySize"/> is false, the function returns Q, R and E such that the equation A * E = Q * R holds except roundoff errors. </para>
        /// <para>If <paramref name="economySize"/> is true, E will be a permutation vector and the equation A[null,E] == Q * R holds (except roundoff).</para>
        /// <para>E reflects the pivoting of A done inside LAPACK in order to give R increasingly diagonal elements.</para>
        /// <para>Q, R and E will be solid ILArray's.</para></remarks>
        public static  ILArray<complex> qr( ILArray<complex> A, ref  ILArray<complex> R, ref  ILArray<complex> E, bool economySize) {
            if (Object.Equals(R,null)) {
                return qr(A); 
            }
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m < n && economySize) return qr(A,ref R, false); 
            ILArray<complex> ret;
            if (m == 0 || n == 0) { 
                R = new  ILArray<complex> (new  complex [0],m,n); 
                E = new  ILArray<complex> (new  complex [0],1,0); 
                return  ILArray<complex> .empty();  
            }
            // prepare IPVT
            if (object.Equals(E,null)) 
                return qr(A,ref R,economySize); 
            if (!economySize) {
                E = new  ILArray<complex> (new  complex [n * n],n,n);  
            } else {
                E = new  ILArray<complex> (new  complex [n],1,n);  
            }
            int [] ipvt = new int[n];
            int minMN = (m<n)?m:n;
            int info = 0; 
            complex [] tau = new  complex [minMN];  
            complex [] QArr;
            if (m >= n) {
                ret = new  ILArray<complex> (
                                    new  complex [(economySize)? minMN * m : m * m],
                                    m,(economySize)? minMN: m); 
            } else {
                // economySize is always false ... !
                // a temporary array is needed for extraction of the compact lapack Q (?geqrf)
                ret = new  ILArray<complex> (
                                    new  complex [m * n],m,n); 
            }
            QArr = ret.m_data;
            for (int i = m*n; i-->0;) {
                QArr[i] = A.GetValue(i); 
            }
            Lapack.zgeqp3 (m,n,QArr,m,ipvt,tau,ref info);
            if (info != 0) {
                throw new ILArgumentException("qr: error inside lapack library (?geqrf). info=" + info.ToString());
            }
            // extract R, Q
            if (economySize) {
                R = copyUpperTriangle(QArr,m,n,minMN); 
                Lapack.zungqr (m,minMN,tau.Length,QArr,m,tau,ref info);
                // transform E into out typed vector
                for (int i = 0; i < n; i++) {
                     E.m_data[i] = ipvt[i] - 1; 
                }
            } else {
                R = copyUpperTriangle(QArr,m,n,m); 
                Lapack.zungqr (m,m,tau.Length,QArr,m,tau,ref info); 
                if (m < n) 
                    ret = ret[":;0:" + (m-1)]; 
                // transform E into matrix
                for (int i = 0; i < n; i++) {
                     E.m_data[(ipvt[i]-1) + n * i] =  new complex(1.0,0.0) ; 
                }
            }
            if (info != 0) 
                throw new ILArgumentException("qr: error in lapack library (???gqr). info=" + info.ToString());
            return ret; 
        }


#endregion HYCALPER AUTO GENERATED CODE
    }
}
