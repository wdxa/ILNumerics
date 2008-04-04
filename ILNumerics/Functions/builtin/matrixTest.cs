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
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        zeroVal
    </source>
    <destination>0.0f</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>'0'</destination>
    <destination>0</destination>
    <destination>new complex(0.0,0.0)</destination>
    <destination>new fcomplex(0.0f,0.0f)</destination>
</type>
<type>
    <source locate="after">
        testReal
    </source>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination>if (A.GetValue(c,c).imag != 0.0) return false;</destination>
    <destination>if (A.GetValue(c,c).imag != 0.0f) return false; </destination>
</type>
<type>
    <source locate="nextline">
        compareComplx
    </source>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>if (A.GetValue(r,c) != A.GetValue(c,r)) return false; </destination>
    <destination>complex val1 = A.GetValue(r,c); complex val2 = A.GetValue(c,r); if (val1.real != val2.real || val1.imag + val2.imag != 0.0) return false;</destination>
    <destination>fcomplex val1 = A.GetValue(r,c); fcomplex val2 = A.GetValue(c,r); if (val1.real != val2.real || val1.imag + val2.imag != 0.0f) return false;</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

        #region HYCALPER LOOPSTART 
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow(/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) != /*!HC:zerosVal*/ 0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup(/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) != /*!HC:zerosVal*/ 0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow(/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) != /*!HC:zerosVal*/ 0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup(/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) != /*!HC:zerosVal*/ 0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian(/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                /*!HC:testReal*/  //
                for (int r = c+1; r < n; r++){
                    /*!HC:compareComplx*/
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 if (A.GetValue(c,c).imag != 0.0f) return false; 
                for (int r = c+1; r < n; r++){
                    fcomplex val1 = A.GetValue(r,c); fcomplex val2 = A.GetValue(c,r); if (val1.real != val2.real || val1.imag + val2.imag != 0.0f) return false;
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 if (A.GetValue(c,c).imag != 0.0) return false;
                for (int r = c+1; r < n; r++){
                    complex val1 = A.GetValue(r,c); complex val2 = A.GetValue(c,r); if (val1.real != val2.real || val1.imag + val2.imag != 0.0) return false;
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istrilow( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istrilow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istrilow: A must be a matrix!"); 
            int n = A.Dimensions[1]; 
            for (int c = 1; c < n; c++) {
                for (int r = 0; r < c; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        
        /// <summary>
        /// Determine if matrix A is upper triangular matrix
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper triangular matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was not a matrix or if A was null</exception>
        public static bool istriup( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("istriup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)
                throw new ILArgumentException ("istriup: A must be matrix or scalar!"); 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            for (int c = 0; c < n; c++) {
                for (int r = c+1; r < m; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is lower Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a lower Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishesslow( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishesslow: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int m = A.Dimensions[0]; 
            int n = A.Dimensions[1]; 
            if (m != n)         return false; 
            for (int c = 2; c < n; c++) {
                for (int r = 0; r < c-1; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is upper Hessenberg matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a upper Hessenberg matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishessup( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n-2; c++) {
                for (int r = c+2; r < n; r++){
                    if (A.GetValue(r,c) !=  0.0 ) return false; 
			    }       
			}
            return true; 
        }
        /// <summary>
        /// Determine if matrix A is Hermitian matrix 
        /// </summary>
        /// <param name="A">Matrix or scalar A of numeric inner type</param>
        /// <returns>true if A is a Hermitian matrix, false otherwise</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null</exception>
        public static bool ishermitian( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException ("ishessup: A must not be null!"); 
            if (A.IsScalar) {   return true;    }
            if (A.IsEmpty)  {   return false;   }
            if (!A.IsMatrix)    return false; 
            int n = A.Dimensions[1]; 
            if (n != A.Dimensions[0]) return false; 
            for (int c = 0; c < n; c++) {
                 
                for (int r = c+1; r < n; r++){
                    if (A.GetValue(r,c) != A.GetValue(c,r)) return false; 
			    }       
			}
            return true; 
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
