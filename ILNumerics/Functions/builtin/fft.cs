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
using ILNumerics.Exceptions; 
using ILNumerics.Misc; 

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {

        #region HYCALPER LOOPSTART DOUBLE FFT interface 
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArrR
        </source>
        <destination>float</destination>
    </type>
    <type>
        <source locate="after">
            HCretArrC
        </source>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            HCinArrR
        </source>
        <destination>float</destination>
    </type>
    <type>
        <source locate="after">
            HCinArrC
        </source>
        <destination>fcomplex</destination>
    </type>
 </hycalper>
 */

        #region fft(A)
        /// <summary>
        /// fast fourier transform (1D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformed output array</returns>
        /// <remarks><para>The transformation is computed along the first 
        /// non singleton dimension.</para>
        /// <para>The output array returned will be complex hermitian. I.e. the real 
        /// part beeing even and the imaginary part beeing odd symmetrical.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fft(ILArray</*!HC:HCinArrR*/ double > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return new /*!HC:HCretArrC*/ complex (A.GetValue(0),0); 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTForward1D(A,fnsd); 
        }
        /// <summary>
        /// fast fourier transform (1D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformed output array</returns>
        /// <remarks>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fft(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTForward1D(A,fnsd); 
        }
        /// <summary>
        /// fast inverse fourier transform (1D)
        /// </summary>
        /// <param name="A">input (frequency domain)</param>
        /// <returns>inverse transformed output array</returns>
        /// <remarks>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > ifft(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTBackward1D(A,fnsd); 
        }
        /// <summary>
        /// Inverse fast fourier transform, complex hermitian input
        /// </summary>
        /// <param name="A">complex hermitian input array</param>
        /// <returns>real output array, same size as A</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in 
        /// the output having all imaginary part equal zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrR*/ double > ifftsym(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTBackwSym1D(A,fnsd);
        }
        #endregion

        #region fft(A, dim)
        /// <summary>
        /// fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">real input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The output array returned will be complex hermitian. I.e. the real 
        /// part beeing even and the imaginary part beeing odd symmetrical.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if 
        /// the dim parameter is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fft(ILArray</*!HC:HCinArrR*/ double > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return new /*!HC:HCretArrC*/ complex (A.GetValue(0),0); 
            return ILMath.FFT.FFTForward1D(A,dim); 
        }
        /// <summary>
        /// fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if 
        /// the dim parameter is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fft(ILArray</*!HC:HCinArrC*/ complex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return ILMath.FFT.FFTForward1D(A,dim); 
        }
        /// <summary>
        /// inverse fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the dim parameter is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > ifft(ILArray</*!HC:HCinArrC*/ complex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return ILMath.FFT.FFTBackward1D(A,dim); 
        }
        /// <summary>
        /// Inverse fast fourier transform, complex hermitian input
        /// </summary>
        /// <param name="A">complex hermitian input array (frequency domain)</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>real output array, same size as A</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the dim parameter is negative</exception>
        public static ILArray</*!HC:HCretArrR*/ double > ifftsym(ILArray</*!HC:HCinArrC*/ complex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            return ILMath.FFT.FFTBackwSym1D(A,dim);
        }
        #endregion

        #region fft2(A)
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The 2D transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The output array returned will be complex hermitian.</para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fft2(ILArray</*!HC:HCinArrR*/ double > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return new /*!HC:HCretArrC*/ complex (A.GetValue(0),0); 
            return FFT.FFTForward(A,2); 
        }
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fft2(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return FFT.FFTForward(A,2); 
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > ifft2(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return FFT.FFTBackward(A,2); 
        }
        /// <summary>
        /// inverse fast fourier transform (2D, hermitian input)
        /// </summary>
        /// <param name="A">complex hermitian input array (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrR*/ double > ifft2sym(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            return FFT.FFTBackwSym(A,2);
        }
        #endregion

        #region fft2(A,m,n)
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result, complex hermitian</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the A array) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fft2(ILArray</*!HC:HCinArrR*/ double > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray</*!HC:HCinArrR*/ double > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTForward(resizedA, 2);
        }
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the A array) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fft2(ILArray</*!HC:HCinArrC*/ complex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTForward(resizedA, 2);
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the array A) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > ifft2(ILArray</*!HC:HCinArrC*/ complex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTBackward(resizedA, 2);
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">complex hermitian input array, symmetric in first 2 dimensions</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. The 
        /// lengths of those trailing dimensions are not altered.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The data to be transformed (based on the array A) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray</*!HC:HCretArrR*/ double > ifft2sym(ILArray</*!HC:HCinArrC*/ complex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTBackwSym(resizedA, 2);
        }
        #endregion

        #region fftn(A)
        /// <summary>
        /// fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <returns>transformation result, complex hermitian</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fftn(ILArray</*!HC:HCinArrR*/ double > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions); 
            return FFT.FFTForward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > fftn(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions); 
            return FFT.FFTForward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// inverse fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional inverse transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrC*/ complex > ifftn(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions); 
            return FFT.FFTBackward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// inverse fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D, complex hermitian (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional inverse transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray</*!HC:HCretArrR*/ double > ifftnsym(ILArray</*!HC:HCinArrC*/ complex > A) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions); 
            return FFT.FFTBackwSym(A,A.Dimensions.NumberOfDimensions);
        }
        #endregion

        #region fftn(A, params dims)
        /// <summary>
        /// fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter, complex hermitian</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fftn(ILArray</*!HC:HCinArrR*/ double > A, params int[] dims) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            ILArray</*!HC:HCinArrR*/ double > resizedA = resize4Transform(A,dims); 
            return FFT.FFTForward(resizedA, dims.Length);
        }
        /// <summary>
        /// fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > fftn(ILArray</*!HC:HCinArrC*/ complex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTForward(resizedA, dims.Length);
        }
        /// <summary>
        /// inverse fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray</*!HC:HCretArrC*/ complex > ifftn(ILArray</*!HC:HCinArrC*/ complex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrC*/ complex >.empty(A.Dimensions);
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTBackward(resizedA, dims.Length);
        }
        /// <summary>
        /// inverse fast fourier transform (n-D, complex hermitian, specific size)
        /// </summary>
        /// <param name="A">complex hermitian input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result, real array of the size specified by the 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray</*!HC:HCretArrR*/ double > ifftnsym(ILArray</*!HC:HCinArrC*/ complex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray</*!HC:HCretArrR*/ double >.empty(A.Dimensions);
            ILArray</*!HC:HCinArrC*/ complex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTBackwSym(resizedA, dims.Length);
        }
        #endregion

        #endregion HYCALPER LOOPEND DOUBLE FFT interface
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 


        #region fft(A)
        /// <summary>
        /// fast fourier transform (1D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformed output array</returns>
        /// <remarks><para>The transformation is computed along the first 
        /// non singleton dimension.</para>
        /// <para>The output array returned will be complex hermitian. I.e. the real 
        /// part beeing even and the imaginary part beeing odd symmetrical.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fft(ILArray< float > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return new  fcomplex (A.GetValue(0),0); 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTForward1D(A,fnsd); 
        }
        /// <summary>
        /// fast fourier transform (1D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformed output array</returns>
        /// <remarks>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fft(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTForward1D(A,fnsd); 
        }
        /// <summary>
        /// fast inverse fourier transform (1D)
        /// </summary>
        /// <param name="A">input (frequency domain)</param>
        /// <returns>inverse transformed output array</returns>
        /// <remarks>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > ifft(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTBackward1D(A,fnsd); 
        }
        /// <summary>
        /// Inverse fast fourier transform, complex hermitian input
        /// </summary>
        /// <param name="A">complex hermitian input array</param>
        /// <returns>real output array, same size as A</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in 
        /// the output having all imaginary part equal zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The transformation is computed along the first non 
        /// singleton dimension.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< float > ifftsym(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            return ILMath.FFT.FFTBackwSym1D(A,fnsd);
        }
        #endregion

        #region fft(A, dim)
        /// <summary>
        /// fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">real input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The output array returned will be complex hermitian. I.e. the real 
        /// part beeing even and the imaginary part beeing odd symmetrical.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if 
        /// the dim parameter is negative</exception>
        public static ILArray< fcomplex > fft(ILArray< float > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return new  fcomplex (A.GetValue(0),0); 
            return ILMath.FFT.FFTForward1D(A,dim); 
        }
        /// <summary>
        /// fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if 
        /// the dim parameter is negative</exception>
        public static ILArray< fcomplex > fft(ILArray< fcomplex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return ILMath.FFT.FFTForward1D(A,dim); 
        }
        /// <summary>
        /// inverse fast fourier transform along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL 
        /// (included), AMD ACML and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the dim parameter is negative</exception>
        public static ILArray< fcomplex > ifft(ILArray< fcomplex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return ILMath.FFT.FFTBackward1D(A,dim); 
        }
        /// <summary>
        /// Inverse fast fourier transform, complex hermitian input
        /// </summary>
        /// <param name="A">complex hermitian input array (frequency domain)</param>
        /// <param name="dim">dimension to compute FFT along. This parameter
        /// must be non-negative. </param>
        /// <returns>real output array, same size as A</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the dim parameter is negative</exception>
        public static ILArray< float > ifftsym(ILArray< fcomplex > A, int dim) {
            if (dim < 0) throw new ILArgumentException("the 'dim' parameter must point to an existing dimension index of A"); 
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            return ILMath.FFT.FFTBackwSym1D(A,dim);
        }
        #endregion

        #region fft2(A)
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The 2D transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The output array returned will be complex hermitian.</para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fft2(ILArray< float > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return new  fcomplex (A.GetValue(0),0); 
            return FFT.FFTForward(A,2); 
        }
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fft2(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return FFT.FFTForward(A,2); 
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > ifft2(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            if (A.IsScalar) return A.C; 
            return FFT.FFTBackward(A,2); 
        }
        /// <summary>
        /// inverse fast fourier transform (2D, hermitian input)
        /// </summary>
        /// <param name="A">complex hermitian input array (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< float > ifft2sym(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions);
            if (A.IsScalar) return real(A); 
            return FFT.FFTBackwSym(A,2);
        }
        #endregion

        #region fft2(A,m,n)
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result, complex hermitian</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the A array) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray< fcomplex > fft2(ILArray< float > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray< float > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTForward(resizedA, 2);
        }
        /// <summary>
        /// fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the A array) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray< fcomplex > fft2(ILArray< fcomplex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray< fcomplex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTForward(resizedA, 2);
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. </para>
        /// <para>The data to be transformed (based on the array A) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray< fcomplex > ifft2(ILArray< fcomplex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray< fcomplex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTBackward(resizedA, 2);
        }
        /// <summary>
        /// inverse fast fourier transform (2D)
        /// </summary>
        /// <param name="A">complex hermitian input array, symmetric in first 2 dimensions</param>
        /// <param name="m">transformation column length</param>
        /// <param name="n">transformation row length</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The transformation is computed for the first 2 dimensions, regardless 
        /// of those dimensions beeing singleton or non-singleton. If A is an n-d array, 
        /// the transformation is repeated for trailing dimensions of A respectively. The 
        /// lengths of those trailing dimensions are not altered.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The data to be transformed (based on the array A) are resized according to 
        /// the length parameter m and n. If m or n is larger then the length of the corresponding 
        /// dimension of A, zeros will be padded, otherwise the dimensions are truncated respectively. </para>
        /// <para>The two dimensional transformation is equivalent to repeatedly transforming 
        /// the columns and after that transforming the rows of A. However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if one of n or m is negative</exception>
        public static ILArray< float > ifft2sym(ILArray< fcomplex > A, int m, int n) {
            if (m < 0 || n < 0) throw new ILArgumentException("dimension length specifier 'm' and 'n' must be non-negative!"); 
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions);
            int[] Asize = A.Dimensions.ToIntArray(); 
            Asize[0] = m; Asize[1] = n; 
            ILArray< fcomplex > resizedA = resize4Transform(A,Asize); 
            return FFT.FFTBackwSym(resizedA, 2);
        }
        #endregion

        #region fftn(A)
        /// <summary>
        /// fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <returns>transformation result, complex hermitian</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fftn(ILArray< float > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            return FFT.FFTForward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > fftn(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            return FFT.FFTForward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// inverse fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional inverse transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< fcomplex > ifftn(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            return FFT.FFTBackward(A,A.Dimensions.NumberOfDimensions); 
        }
        /// <summary>
        /// inverse fast fourier transform (n-D)
        /// </summary>
        /// <param name="A">input array, n-D, complex hermitian (frequency domain)</param>
        /// <returns>transformation result</returns>
        /// <remarks>
        /// <para>The n-dimensional inverse transformation is computed for the n-dimensional array A. 
        /// This is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        public static ILArray< float > ifftnsym(ILArray< fcomplex > A) {
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions); 
            return FFT.FFTBackwSym(A,A.Dimensions.NumberOfDimensions);
        }
        #endregion

        #region fftn(A, params dims)
        /// <summary>
        /// fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter, complex hermitian</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray< fcomplex > fftn(ILArray< float > A, params int[] dims) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            ILArray< float > resizedA = resize4Transform(A,dims); 
            return FFT.FFTForward(resizedA, dims.Length);
        }
        /// <summary>
        /// fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray< fcomplex > fftn(ILArray< fcomplex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            ILArray< fcomplex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTForward(resizedA, dims.Length);
        }
        /// <summary>
        /// inverse fast fourier transform (n-D, specific size)
        /// </summary>
        /// <param name="A">input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result of size specified by 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray< fcomplex > ifftn(ILArray< fcomplex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions);
            ILArray< fcomplex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTBackward(resizedA, dims.Length);
        }
        /// <summary>
        /// inverse fast fourier transform (n-D, complex hermitian, specific size)
        /// </summary>
        /// <param name="A">complex hermitian input array, n-D</param>
        /// <param name="dims">transformation lengths, specifies the length of the dimensions 
        /// for the transformation array. The length of dims must be &ge; the number of 
        /// dimensions of A. For elements in dim beeing smaller than corresponding dimension 
        /// length in A, the dimensions will be truncated, otherwise zeros will be padded.</param>
        /// <returns>transformation result, real array of the size specified by the 'dims' parameter</returns>
        /// <remarks>
        /// <para>The n-dimensional transformation is computed for the n-dimensional array A. 
        /// Before the transform, the input is resized according to the 'dims' parameter. 
        /// Dimensions larger than corresponding entries in 'dim' are truncated, dimensions
        /// smaller than corresponding entries in 'dim' are zero padded.</para>
        /// <para>The n-dimensional transformation is equivalent to repeatedly (inplace) 
        /// computing one dimensional transformations along all dimensions of A.
        /// However, using this 
        /// function may be of magnitudes faster than using 1D transformations. This 
        /// depends on the algorithm and API provided by the underlying native library.</para>
        /// <para>Since a transform of complex hermitian input data results in the 
        /// output having the imaginary part equals zero, only the real part is 
        /// returned for convenience reasons.</para>
        /// <para>No check is made for A beeing hermitian! If A is not hermitian (by means 
        /// of round-off errors), the result will be wrong!</para>
        /// <para>The forward fourier transform and the inverse fourier transform of 
        /// a given data array A are mathematically equivalent. It's only a 
        /// scaling factor which is needed to make sure, A equals ifft(fft(A)). That 
        /// scaling is introduced in the inverse transform.</para>
        /// <para>The transformation is computed by use of the native library 
        /// which currently is set up for your processor and OS version. The underlying 
        /// library is automatically choosen at ILNumerics.Net startup and accessed via the 
        /// static member ILMath.FFT. See the online documentation for more 
        /// details in how to tune/configure and select dedicated native libraries. 
        /// Currently supported libraries are: Intel MKL (included), AMD ACML 
        /// and FFTW3 (prepared, optional modules, not included due to licensing conflicts).</para>
        /// </remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">is thrown if the 
        /// dim parameter is null, its length is less then the number of dimensions of A 
        /// or any element of dims is non-negative</exception>
        public static ILArray< float > ifftnsym(ILArray< fcomplex > A, params int[] dims) {
            if (A.IsEmpty) return ILArray< float >.empty(A.Dimensions);
            ILArray< fcomplex > resizedA = resize4Transform(A,dims); 
            return FFT.FFTBackwSym(resizedA, dims.Length);
        }
        #endregion


#endregion HYCALPER AUTO GENERATED CODE


        #region private helper
        internal static ILArray<T> resize4Transform<T>(ILArray<T> A, params int[] size) {
            if (size == null || size.Length < A.Dimensions.NumberOfDimensions) 
                throw new ILArgumentException("length of output dimensions must be &ge; number of dimensions of input array!"); 
            if (A.Dimensions.IsSameShape(new ILDimension(size))) {
                return A;
            } else {
                ILArray<T> tmp = new ILArray<T>(size);
                if (tmp.IsEmpty) return ILArray<T>.empty(tmp.Dimensions); 
                int minDimsLen = Math.Min(size.Length,A.Dimensions.NumberOfDimensions); 
                string[] indices = new string[minDimsLen];
                for (int i = 0; i < minDimsLen; i++) {
                    if (size[i] < 0) 
                        throw new ILArgumentException("all dimension lengths of 'size' must be non-negative!"); 
                    if (size[i] == 0) return ILArray<T>.empty(size); 
                    indices[i] = "0:" + Math.Min(A.Dimensions[i]-1,size[i]-1); 
                }
                tmp[indices] = A[indices];
                return tmp;
            }
        }

        #endregion

    }
}
