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
using System.Runtime.InteropServices; 
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Native;
using ILNumerics.Exceptions;
/*!HC:TYPELIST:
<hycalper>
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
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opcomplex_complex</destination>
    <destination>opfcomplex_fcomplex</destination>
    <destination>opfloat_float</destination>
</type>
<type>
    <source locate="after">
        anonMethodBase
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>Float</destination>
</type>
<type>
    <source locate="after">
        unaryop
    </source>
    <destination>ComplexOperatorComplex</destination>
    <destination>FcomplexOperatorFcomplex</destination>
    <destination>FloatOperatorFloat</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {

	public partial class ILMath {
        // helper class for (auto casting) float delegates 
        internal class Float {
            internal static float Acos(float inp) { return (float) Math.Acos ( inp ); }
            internal static float Asin(float inp) { return (float) Math.Asin ( inp ); }
            internal static float Atan(float inp) { return (float) Math.Atan ( inp ); }
            internal static float Cos(float inp) { return (float) Math.Cos ( inp ); }
            internal static float Cosh(float inp) { return (float) Math.Cosh ( inp ); }
            internal static float Exp(float inp) { return (float) Math.Exp ( inp ); }
            internal static float Log(float inp) { return (float) Math.Log ( inp ); }
            internal static float Log10(float inp) { return (float)Math.Log10(inp); }
            internal static float Sin(float inp) { return (float)Math.Sin(inp); }
            internal static float Sinh(float inp) { return (float) Math.Sinh ( inp ); }
            internal static float Sqrt(float inp) { return (float) Math.Sqrt ( inp ); }
            internal static float Tan(float inp) { return (float) Math.Tan ( inp ); }
            internal static float Tanh(float inp) { return (float) Math.Tanh ( inp ); }
            internal static float Pow(float inp, float parameter) { return (float) Math.Pow ( inp, parameter ); }
        }

        private class opcomplex_double {
            private double m_parameter;
            ILComplexFunctionDoubleDouble m_applyFun;

            internal opcomplex_double(double parameter,
                                      ILComplexFunctionDoubleDouble applyFunc) {
                m_parameter = parameter;
                m_applyFun = applyFunc;
            }
            internal complex operate(double in1) {
                return m_applyFun(in1, m_parameter);
            }
            internal complex pow(double in1) {
                return complex.Pow(in1, m_parameter);
            }
        }
        private class opfcomplex_float {
            private float m_parameter;
            ILFcomplexFunctionFloatFloat m_applyFun;
            internal opfcomplex_float(float parameter,
                                      ILFcomplexFunctionFloatFloat applyFunc) {
                m_parameter = parameter;
                m_applyFun = applyFunc;
            }
            internal fcomplex operate(float in1) {
                return m_applyFun(in1, m_parameter);
            }
            internal fcomplex pow(float in1) {
                return fcomplex.Pow(in1, m_parameter);
            }
        }

        #region HYCALPER LOOPSTART complex_real_functions
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opfloat_fcomplex</destination>
</type>
<type>
    <source locate="after">
        anonMethodBase
    </source>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        unaryop
    </source>
    <destination>FcomplexOperatorFloat</destination>
</type>
<type>
    <source locate="after">
        hchelper
    </source>
    <destination>opfcomplex_float</destination>
</type>
</hycalper>
*/
        /// <summary>
        /// power function - complex return
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>complex array</returns>
        /// <remarks>The complex array returned will hold result of power function for corresponding elements of A<sub>i,j,...</sub><sup>exponent</sup></remarks>
        public static /*!HC:outCls1*/ ILArray<complex> powc(/*!HC:inCls1*/ ILArray<double> A,/*!HC:inArr1*/ double exponent) {
            /*!HC:hchelper*/ opcomplex_double helper = new /*!HC:hchelper*/ opcomplex_double (exponent, null);
            return /*!HC:unaryop*/ ComplexOperatorDouble (A, helper.pow);
        }
        #endregion HYCALPER LOOPEND complex_real_functions
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// power function - complex return
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>complex array</returns>
        /// <remarks>The complex array returned will hold result of power function for corresponding elements of A<sub>i,j,...</sub><sup>exponent</sup></remarks>
        public static  ILArray<fcomplex> powc( ILArray<float> A, float exponent) {
            opfcomplex_float helper = new  opfcomplex_float (exponent, null);
            return  FcomplexOperatorFloat (A, helper.pow);
        }

#endregion HYCALPER AUTO GENERATED CODE


        #region HYCALPER LOOPSTART Unary Functions Floating Point Types
        /// <summary>
        /// power function - returns same type
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>array of same type as A, with corresponding elements filled with: A<sub>i,j,...</sub><sup>exponent</sup>.</returns>
        public static /*!HC:outCls1*/ ILArray<double> pow(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inArr1*/ double exponent) {
            /*!HC:Tcls3Name*/ opdouble_double helper = new /*!HC:Tcls3Name*/ opdouble_double ( exponent, /*!HC:anonMethodBase*/ Math .Pow );
            return /*!HC:unaryop*/ DoubleOperatorDouble ( A, helper.operate );
        }
        #endregion HYCALPER LOOPEND Unary Functions Basic Math special types
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// power function - returns same type
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>array of same type as A, with corresponding elements filled with: A<sub>i,j,...</sub><sup>exponent</sup>.</returns>
        public static  ILArray<float> pow( ILArray<float> A,  float exponent) {
            opfloat_float helper = new  opfloat_float ( exponent,  Float .Pow );
            return  FloatOperatorFloat ( A, helper.operate );
        }
        /// <summary>
        /// power function - returns same type
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>array of same type as A, with corresponding elements filled with: A<sub>i,j,...</sub><sup>exponent</sup>.</returns>
        public static  ILArray<fcomplex> pow( ILArray<fcomplex> A,  fcomplex exponent) {
            opfcomplex_fcomplex helper = new  opfcomplex_fcomplex ( exponent,  fcomplex .Pow );
            return  FcomplexOperatorFcomplex ( A, helper.operate );
        }
        /// <summary>
        /// power function - returns same type
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="exponent">real exponent</param>
        /// <returns>array of same type as A, with corresponding elements filled with: A<sub>i,j,...</sub><sup>exponent</sup>.</returns>
        public static  ILArray<complex> pow( ILArray<complex> A,  complex exponent) {
            opcomplex_complex helper = new  opcomplex_complex ( exponent,  complex .Pow );
            return  ComplexOperatorComplex ( A, helper.operate );
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART Matrix_multiply
        /*!HC:TYPELIST:
<hycalper>
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
        inArr2
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
</type>
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
        inCls2
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        lapackfunc
    </source>
    <destination>Lapack.zgemm</destination>
    <destination>Lapack.cgemm</destination>
    <destination>Lapack.sgemm</destination>
</type>
</hycalper>
*/

        /// <summary>
        /// GEneral Matrix Multiply this array
        /// </summary>
        /// <overloads>General Matrix Multiply for double, float, complex and fcomplex arrays</overloads>
        /// <param name="A"><![CDATA[ILArray<>]]> matrix A</param>
        /// <param name="B"><![CDATA[ILArray<>]]> matrix B</param>
        /// <returns><![CDATA[ILArray<double>]]> new array - result of matrix multiplication</returns>
        /// <remarks>Both arrays must be matrices. The matrix will be multiplied only 
        /// if dimensions match accordingly. Therefore B's number of rows must 
        /// equal A's number of columns. An Exception will be thrown otherwise. 
        /// The multiplication will carried out on BLAS libraries, if availiable and the 
        /// storage memory structure meets BLAS's requirements. If not it will be done inside .NET's 
        /// framework 'by hand'. This is especially true for referencing storages with 
        /// irregular dimensions. However, even GEMM on those reference storages linking into 
        /// a physical storage can (an will) be carried out via BLAS dll's, if the spacing 
        /// into dimensions matches the requirements of BLAS. Those are: 
        /// <list>
        /// <item>the elements of one dimension will be adjecently layed out, and</item>
        /// <item>the elements of the second dimension must be regular (evenly) spaced</item>
        /// </list>
        /// <para>For reference arrays where the spacing between adjecent elements do not meet the 
        /// requirements above, the matrix multiplication will be made without optimization and  
        /// therefore suffer from low performance in relation to solid arrays. See <a href="http://ilnumerics.net?site=5142">online documentation: referencing for ILNumerics.Net</a></para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException">if at least one arrays is not a matrix</exception>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if the size of both matrices do not match</exception>
        public static /*!HC:outCls1*/ ILArray<double> multiply(/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls2*/ ILArray<double> B) {
            /*!HC:outCls1*/ ILArray<double> ret = null; 
            if (A.Dimensions.NumberOfDimensions != 2
                || B.Dimensions.NumberOfDimensions != 2)
                throw new ILArgumentSizeException("Matrix multiply: arguments must be 2-d.");
            if (A.Dimensions[1] != B.Dimensions[0])
                throw new ILDimensionMismatchException("Matrix multiply: inner matrix dimensions must match.");
            // decide wich method to use
            // test auf Regelmigkeit der Dimensionen 
            int spacingA0;
            int spacingA1;
            int spacingB0;
            int spacingB1;
            char transA, transB; 
            /*!HC:inArr1*/ double [] retArr = null;
            isSuitableForLapack(A, B, out spacingA0, out spacingA1, out spacingB0, out spacingB1, out transA, out transB);
            if (A.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize ||
                B.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize) {
                    // do BLAS GEMM 
                    retArr = new /*!HC:inArr1*/ double [A.m_dimensions[0] * B.m_dimensions[1]];
                    if (((spacingA0 == 1 && spacingA1 > int.MinValue) || (spacingA1 == 1 && spacingA0 > int.MinValue))
                        && ((spacingB0 == 1 && spacingB1 > int.MinValue) || (spacingB1 == 1 && spacingB0 > int.MinValue))) {
                        ret = new /*!HC:outCls1*/ ILArray<double> (retArr, new ILDimension(A.m_dimensions[0], B.m_dimensions[1]));
                        if (transA == 't') spacingA1 = spacingA0; 
                        if (transB == 't') spacingB1 = spacingB0;
                        unsafe {
                            fixed (/*!HC:outArr1*/ double * ptrC = retArr)
                            fixed (/*!HC:inArr1*/ double * pA = A.m_data )
                            fixed (/*!HC:inArr2*/ double * pB = B.m_data ) {
                                /*!HC:inArr1*/ double * ptrA = pA + A.getBaseIndex(0);
                                /*!HC:inArr2*/ double * ptrB = pB + B.getBaseIndex(0);  
                                if (transA == 't') spacingA1 = spacingA0; 
                                if (transB == 't') spacingB1 = spacingB0; 
                                /*!HC:lapackfunc*/ Lapack.dgemm (transA,transB,A.m_dimensions[0], B.m_dimensions[1],
                                                A.m_dimensions[1], (/*!HC:inArr1*/ double )1.0, (IntPtr)ptrA, spacingA1,
                                                (IntPtr)ptrB, spacingB1, (/*!HC:inArr1*/ double )1.0, retArr,A.m_dimensions[0]);
                            }
                        }
                        return ret; 
                    } 
            } 
            // do GEMM by hand 
            retArr = new /*!HC:outArr1*/ double [A.m_dimensions[0] * B.m_dimensions[1]];
            ret = new /*!HC:outCls1*/ ILArray<double> (retArr, A.m_dimensions[0], B.m_dimensions[1]);
            unsafe {
                int in2Len1 = B.m_dimensions[1];
                int in1Len0 = A.m_dimensions[0];
                int in1Len1 = A.m_dimensions[1];
                fixed (/*!HC:outArr1*/ double * ptrC = retArr) {
                    /*!HC:outArr1*/ double * pC = ptrC;
                    for (int c = 0; c < in2Len1; c++) {
                        for (int r = 0; r < in1Len0; r++) {
                            for (int n = 0; n < in1Len1; n++) {
                                *pC += A.GetValue(r, n) * B.GetValue(n, c);
                            }
                            pC++;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion HYCALPER LOOPEND Matrix_multiply
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       

        /// <summary>
        /// GEneral Matrix Multiply this array
        /// </summary>
        /// <overloads>General Matrix Multiply for double, float, complex and fcomplex arrays</overloads>
        /// <param name="A"><![CDATA[ILArray<>]]> matrix A</param>
        /// <param name="B"><![CDATA[ILArray<>]]> matrix B</param>
        /// <returns><![CDATA[ILArray<double>]]> new array - result of matrix multiplication</returns>
        /// <remarks>Both arrays must be matrices. The matrix will be multiplied only 
        /// if dimensions match accordingly. Therefore B's number of rows must 
        /// equal A's number of columns. An Exception will be thrown otherwise. 
        /// The multiplication will carried out on BLAS libraries, if availiable and the 
        /// storage memory structure meets BLAS's requirements. If not it will be done inside .NET's 
        /// framework 'by hand'. This is especially true for referencing storages with 
        /// irregular dimensions. However, even GEMM on those reference storages linking into 
        /// a physical storage can (an will) be carried out via BLAS dll's, if the spacing 
        /// into dimensions matches the requirements of BLAS. Those are: 
        /// <list>
        /// <item>the elements of one dimension will be adjecently layed out, and</item>
        /// <item>the elements of the second dimension must be regular (evenly) spaced</item>
        /// </list>
        /// <para>For reference arrays where the spacing between adjecent elements do not meet the 
        /// requirements above, the matrix multiplication will be made without optimization and  
        /// therefore suffer from low performance in relation to solid arrays. See <a href="http://ilnumerics.net?site=5142">online documentation: referencing for ILNumerics.Net</a></para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException">if at least one arrays is not a matrix</exception>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if the size of both matrices do not match</exception>
        public static  ILArray<float> multiply( ILArray<float> A,  ILArray<float> B) {
            ILArray<float> ret = null; 
            if (A.Dimensions.NumberOfDimensions != 2
                || B.Dimensions.NumberOfDimensions != 2)
                throw new ILArgumentSizeException("Matrix multiply: arguments must be 2-d.");
            if (A.Dimensions[1] != B.Dimensions[0])
                throw new ILDimensionMismatchException("Matrix multiply: inner matrix dimensions must match.");
            // decide wich method to use
            // test auf Regelmigkeit der Dimensionen 
            int spacingA0;
            int spacingA1;
            int spacingB0;
            int spacingB1;
            char transA, transB; 
            float [] retArr = null;
            isSuitableForLapack(A, B, out spacingA0, out spacingA1, out spacingB0, out spacingB1, out transA, out transB);
            if (A.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize ||
                B.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize) {
                    // do BLAS GEMM 
                    retArr = new  float [A.m_dimensions[0] * B.m_dimensions[1]];
                    if (((spacingA0 == 1 && spacingA1 > int.MinValue) || (spacingA1 == 1 && spacingA0 > int.MinValue))
                        && ((spacingB0 == 1 && spacingB1 > int.MinValue) || (spacingB1 == 1 && spacingB0 > int.MinValue))) {
                        ret = new  ILArray<float> (retArr, new ILDimension(A.m_dimensions[0], B.m_dimensions[1]));
                        if (transA == 't') spacingA1 = spacingA0; 
                        if (transB == 't') spacingB1 = spacingB0;
                        unsafe {
                            fixed ( float * ptrC = retArr)
                            fixed ( float * pA = A.m_data )
                            fixed ( float * pB = B.m_data ) {
                                float * ptrA = pA + A.getBaseIndex(0);
                                float * ptrB = pB + B.getBaseIndex(0);  
                                if (transA == 't') spacingA1 = spacingA0; 
                                if (transB == 't') spacingB1 = spacingB0; 
                                Lapack.sgemm (transA,transB,A.m_dimensions[0], B.m_dimensions[1],
                                                A.m_dimensions[1], ( float )1.0, (IntPtr)ptrA, spacingA1,
                                                (IntPtr)ptrB, spacingB1, ( float )1.0, retArr,A.m_dimensions[0]);
                            }
                        }
                        return ret; 
                    } 
            } 
            // do GEMM by hand 
            retArr = new  float [A.m_dimensions[0] * B.m_dimensions[1]];
            ret = new  ILArray<float> (retArr, A.m_dimensions[0], B.m_dimensions[1]);
            unsafe {
                int in2Len1 = B.m_dimensions[1];
                int in1Len0 = A.m_dimensions[0];
                int in1Len1 = A.m_dimensions[1];
                fixed ( float * ptrC = retArr) {
                    float * pC = ptrC;
                    for (int c = 0; c < in2Len1; c++) {
                        for (int r = 0; r < in1Len0; r++) {
                            for (int n = 0; n < in1Len1; n++) {
                                *pC += A.GetValue(r, n) * B.GetValue(n, c);
                            }
                            pC++;
                        }
                    }
                }
            }
            return ret;
        }

       

        /// <summary>
        /// GEneral Matrix Multiply this array
        /// </summary>
        /// <overloads>General Matrix Multiply for double, float, complex and fcomplex arrays</overloads>
        /// <param name="A"><![CDATA[ILArray<>]]> matrix A</param>
        /// <param name="B"><![CDATA[ILArray<>]]> matrix B</param>
        /// <returns><![CDATA[ILArray<double>]]> new array - result of matrix multiplication</returns>
        /// <remarks>Both arrays must be matrices. The matrix will be multiplied only 
        /// if dimensions match accordingly. Therefore B's number of rows must 
        /// equal A's number of columns. An Exception will be thrown otherwise. 
        /// The multiplication will carried out on BLAS libraries, if availiable and the 
        /// storage memory structure meets BLAS's requirements. If not it will be done inside .NET's 
        /// framework 'by hand'. This is especially true for referencing storages with 
        /// irregular dimensions. However, even GEMM on those reference storages linking into 
        /// a physical storage can (an will) be carried out via BLAS dll's, if the spacing 
        /// into dimensions matches the requirements of BLAS. Those are: 
        /// <list>
        /// <item>the elements of one dimension will be adjecently layed out, and</item>
        /// <item>the elements of the second dimension must be regular (evenly) spaced</item>
        /// </list>
        /// <para>For reference arrays where the spacing between adjecent elements do not meet the 
        /// requirements above, the matrix multiplication will be made without optimization and  
        /// therefore suffer from low performance in relation to solid arrays. See <a href="http://ilnumerics.net?site=5142">online documentation: referencing for ILNumerics.Net</a></para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException">if at least one arrays is not a matrix</exception>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if the size of both matrices do not match</exception>
        public static  ILArray<fcomplex> multiply( ILArray<fcomplex> A,  ILArray<fcomplex> B) {
            ILArray<fcomplex> ret = null; 
            if (A.Dimensions.NumberOfDimensions != 2
                || B.Dimensions.NumberOfDimensions != 2)
                throw new ILArgumentSizeException("Matrix multiply: arguments must be 2-d.");
            if (A.Dimensions[1] != B.Dimensions[0])
                throw new ILDimensionMismatchException("Matrix multiply: inner matrix dimensions must match.");
            // decide wich method to use
            // test auf Regelmigkeit der Dimensionen 
            int spacingA0;
            int spacingA1;
            int spacingB0;
            int spacingB1;
            char transA, transB; 
            fcomplex [] retArr = null;
            isSuitableForLapack(A, B, out spacingA0, out spacingA1, out spacingB0, out spacingB1, out transA, out transB);
            if (A.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize ||
                B.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize) {
                    // do BLAS GEMM 
                    retArr = new  fcomplex [A.m_dimensions[0] * B.m_dimensions[1]];
                    if (((spacingA0 == 1 && spacingA1 > int.MinValue) || (spacingA1 == 1 && spacingA0 > int.MinValue))
                        && ((spacingB0 == 1 && spacingB1 > int.MinValue) || (spacingB1 == 1 && spacingB0 > int.MinValue))) {
                        ret = new  ILArray<fcomplex> (retArr, new ILDimension(A.m_dimensions[0], B.m_dimensions[1]));
                        if (transA == 't') spacingA1 = spacingA0; 
                        if (transB == 't') spacingB1 = spacingB0;
                        unsafe {
                            fixed ( fcomplex * ptrC = retArr)
                            fixed ( fcomplex * pA = A.m_data )
                            fixed ( fcomplex * pB = B.m_data ) {
                                fcomplex * ptrA = pA + A.getBaseIndex(0);
                                fcomplex * ptrB = pB + B.getBaseIndex(0);  
                                if (transA == 't') spacingA1 = spacingA0; 
                                if (transB == 't') spacingB1 = spacingB0; 
                                Lapack.cgemm (transA,transB,A.m_dimensions[0], B.m_dimensions[1],
                                                A.m_dimensions[1], ( fcomplex )1.0, (IntPtr)ptrA, spacingA1,
                                                (IntPtr)ptrB, spacingB1, ( fcomplex )1.0, retArr,A.m_dimensions[0]);
                            }
                        }
                        return ret; 
                    } 
            } 
            // do GEMM by hand 
            retArr = new  fcomplex [A.m_dimensions[0] * B.m_dimensions[1]];
            ret = new  ILArray<fcomplex> (retArr, A.m_dimensions[0], B.m_dimensions[1]);
            unsafe {
                int in2Len1 = B.m_dimensions[1];
                int in1Len0 = A.m_dimensions[0];
                int in1Len1 = A.m_dimensions[1];
                fixed ( fcomplex * ptrC = retArr) {
                    fcomplex * pC = ptrC;
                    for (int c = 0; c < in2Len1; c++) {
                        for (int r = 0; r < in1Len0; r++) {
                            for (int n = 0; n < in1Len1; n++) {
                                *pC += A.GetValue(r, n) * B.GetValue(n, c);
                            }
                            pC++;
                        }
                    }
                }
            }
            return ret;
        }

       

        /// <summary>
        /// GEneral Matrix Multiply this array
        /// </summary>
        /// <overloads>General Matrix Multiply for double, float, complex and fcomplex arrays</overloads>
        /// <param name="A"><![CDATA[ILArray<>]]> matrix A</param>
        /// <param name="B"><![CDATA[ILArray<>]]> matrix B</param>
        /// <returns><![CDATA[ILArray<double>]]> new array - result of matrix multiplication</returns>
        /// <remarks>Both arrays must be matrices. The matrix will be multiplied only 
        /// if dimensions match accordingly. Therefore B's number of rows must 
        /// equal A's number of columns. An Exception will be thrown otherwise. 
        /// The multiplication will carried out on BLAS libraries, if availiable and the 
        /// storage memory structure meets BLAS's requirements. If not it will be done inside .NET's 
        /// framework 'by hand'. This is especially true for referencing storages with 
        /// irregular dimensions. However, even GEMM on those reference storages linking into 
        /// a physical storage can (an will) be carried out via BLAS dll's, if the spacing 
        /// into dimensions matches the requirements of BLAS. Those are: 
        /// <list>
        /// <item>the elements of one dimension will be adjecently layed out, and</item>
        /// <item>the elements of the second dimension must be regular (evenly) spaced</item>
        /// </list>
        /// <para>For reference arrays where the spacing between adjecent elements do not meet the 
        /// requirements above, the matrix multiplication will be made without optimization and  
        /// therefore suffer from low performance in relation to solid arrays. See <a href="http://ilnumerics.net?site=5142">online documentation: referencing for ILNumerics.Net</a></para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException">if at least one arrays is not a matrix</exception>
        /// <exception cref="ILNumerics.Exceptions.ILDimensionMismatchException">if the size of both matrices do not match</exception>
        public static  ILArray<complex> multiply( ILArray<complex> A,  ILArray<complex> B) {
            ILArray<complex> ret = null; 
            if (A.Dimensions.NumberOfDimensions != 2
                || B.Dimensions.NumberOfDimensions != 2)
                throw new ILArgumentSizeException("Matrix multiply: arguments must be 2-d.");
            if (A.Dimensions[1] != B.Dimensions[0])
                throw new ILDimensionMismatchException("Matrix multiply: inner matrix dimensions must match.");
            // decide wich method to use
            // test auf Regelmigkeit der Dimensionen 
            int spacingA0;
            int spacingA1;
            int spacingB0;
            int spacingB1;
            char transA, transB; 
            complex [] retArr = null;
            isSuitableForLapack(A, B, out spacingA0, out spacingA1, out spacingB0, out spacingB1, out transA, out transB);
            if (A.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize ||
                B.m_dimensions.NumberOfElements > ILAtlasMinimumElementSize) {
                    // do BLAS GEMM 
                    retArr = new  complex [A.m_dimensions[0] * B.m_dimensions[1]];
                    if (((spacingA0 == 1 && spacingA1 > int.MinValue) || (spacingA1 == 1 && spacingA0 > int.MinValue))
                        && ((spacingB0 == 1 && spacingB1 > int.MinValue) || (spacingB1 == 1 && spacingB0 > int.MinValue))) {
                        ret = new  ILArray<complex> (retArr, new ILDimension(A.m_dimensions[0], B.m_dimensions[1]));
                        if (transA == 't') spacingA1 = spacingA0; 
                        if (transB == 't') spacingB1 = spacingB0;
                        unsafe {
                            fixed ( complex * ptrC = retArr)
                            fixed ( complex * pA = A.m_data )
                            fixed ( complex * pB = B.m_data ) {
                                complex * ptrA = pA + A.getBaseIndex(0);
                                complex * ptrB = pB + B.getBaseIndex(0);  
                                if (transA == 't') spacingA1 = spacingA0; 
                                if (transB == 't') spacingB1 = spacingB0; 
                                Lapack.zgemm (transA,transB,A.m_dimensions[0], B.m_dimensions[1],
                                                A.m_dimensions[1], ( complex )1.0, (IntPtr)ptrA, spacingA1,
                                                (IntPtr)ptrB, spacingB1, ( complex )1.0, retArr,A.m_dimensions[0]);
                            }
                        }
                        return ret; 
                    } 
            } 
            // do GEMM by hand 
            retArr = new  complex [A.m_dimensions[0] * B.m_dimensions[1]];
            ret = new  ILArray<complex> (retArr, A.m_dimensions[0], B.m_dimensions[1]);
            unsafe {
                int in2Len1 = B.m_dimensions[1];
                int in1Len0 = A.m_dimensions[0];
                int in1Len1 = A.m_dimensions[1];
                fixed ( complex * ptrC = retArr) {
                    complex * pC = ptrC;
                    for (int c = 0; c < in2Len1; c++) {
                        for (int r = 0; r < in1Len0; r++) {
                            for (int n = 0; n < in1Len1; n++) {
                                *pC += A.GetValue(r, n) * B.GetValue(n, c);
                            }
                            pC++;
                        }
                    }
                }
            }
            return ret;
        }


#endregion HYCALPER AUTO GENERATED CODE

        private static bool isSuitableForLapack<T>(ILArray<T> in1, out int spacing0, out int spacing1, out char trans) {
            trans = 'n';
            if (!in1.IsReference) {
                spacing0 = in1.m_dimensions.SequentialIndexDistance(0);
                spacing1 = in1.m_dimensions.SequentialIndexDistance(1);
                return true;
            } else {
                spacing0 = in1.m_indexOffset.RegularySpacing(0);
                spacing1 = in1.m_indexOffset.RegularySpacing(1);
                if (spacing0 > 0 && spacing1 > 0) {
                    if (spacing0 == 1)                     
                        return true;
                    if (spacing1 == 1) {
                        spacing1 = spacing0; 
                        spacing0 = 1; 
                        trans = 'T'; 
                        return true; 
                    } 
                }
                return false; 
            }
        }
        private static void isSuitableForLapack<T>(ILArray<T> in1, ILArray<T> in2, out int spacingA0, out int spacingA1, out int spacingB0, out int spacingB1, out char transA, out char transB) {
            transA = 'n'; transB = 'n';
            if (!in1.IsReference) {
                spacingA0 = in1.m_dimensions.SequentialIndexDistance(0);
                spacingA1 = in1.m_dimensions.SequentialIndexDistance(1);
            } else {
                spacingA0 = in1.m_indexOffset.RegularySpacing(0);
                spacingA1 = in1.m_indexOffset.RegularySpacing(1);
                if (spacingA1 == 1) transA = 't';
            }
            if (!in2.IsReference) {
                spacingB0 = in2.Dimensions.SequentialIndexDistance(0);
                spacingB1 = in2.Dimensions.SequentialIndexDistance(1);
            } else {
                spacingB0 = in2.m_indexOffset.RegularySpacing(0);
                spacingB1 = in2.m_indexOffset.RegularySpacing(1);
                if (spacingB1 == 1) transB = 't';
            }
        }
    }
}
