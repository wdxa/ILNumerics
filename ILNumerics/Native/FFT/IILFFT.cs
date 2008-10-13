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
using ILNumerics; 

namespace ILNumerics.Native {

    /// <summary>
    /// Interface for all FFT methods supported
    /// </summary>
    public interface IILFFT {
        /// <summary>
        /// performs backward n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimensions of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTBackward(ILArray<complex> A, int nDims);
        /// <summary>
        /// performs backward n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimensions of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTBackward(ILArray<fcomplex> A, int nDims);
        /// <summary>
        /// performs backward 1-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimensions to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTBackward1D(ILArray<fcomplex> A, int alongDim);
        /// <summary>
        /// performs backward 1-dimensional fft 
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimensions to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTBackward1D(ILArray<complex> A, int alongDim);
        /// <summary>
        /// performs backward n-dimensional fft on hermitian sequence
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimensions of fft</param>
        /// <returns>result, same size as A</returns>
        /// <remarks>This function brings increased performance if the implementation supports it. 
        /// If not, the method will be implemented by repeated calls of (inplace) 1D fft.</remarks>
        ILArray<float> FFTBackwSym(ILArray<fcomplex> A, int nDims);
        /// <summary>
        /// performs backward n-dimensional fft on hermitian sequence
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimensions of fft</param>
        /// <returns>result, same size as A</returns>
        /// <remarks>This function brings increased performance if the implementation supports it. 
        /// If not, the method will be implemented by repeated calls of (inplace) 1D fft.</remarks>
        ILArray<double> FFTBackwSym(ILArray<complex> A, int nDims);
        /// <summary>
        /// performs backward 1-dimensional fft on hermitian sequence
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        /// <remarks>This function brings increased performance if the implementation supports it. 
        /// If not, the method will be implemented by repeated calls of (inplace) 1D fft.</remarks>
        ILArray<float> FFTBackwSym1D(ILArray<fcomplex> A, int alongDim);
        /// <summary>
        /// performs backward 1-dimensional fft on hermitian sequence
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        /// <remarks>This function brings increased performance if the implementation supports it. 
        /// If not, the method will be implemented by repeated calls of (inplace) 1D fft.</remarks>
        ILArray<double> FFTBackwSym1D(ILArray<complex> A, int alongDim);
        /// <summary>
        /// performs n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimension of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTForward(ILArray<fcomplex> A, int nDims);
        /// <summary>
        /// performs n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimension of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTForward(ILArray<double> A, int nDims);
        /// <summary>
        /// performs n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimension of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTForward(ILArray<complex> A, int nDims);
        /// <summary>
        /// performs n-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">number of dimension of fft</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTForward(ILArray<float> A, int nDims);
        /// <summary>
        /// performs 1-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTForward1D(ILArray<complex> A, int alongDim);
        /// <summary>
        /// performs 1-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<complex> FFTForward1D(ILArray<double> A, int alongDim);
        /// <summary>
        /// performs 1-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTForward1D(ILArray<fcomplex> A, int alongDim);
        /// <summary>
        /// performs 1-dimensional fft
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="nDims">dimension to perform fft along</param>
        /// <returns>result, same size as A</returns>
        ILArray<fcomplex> FFTForward1D(ILArray<float> A, int alongDim);
        /// <summary>
        /// true, if the implementation caches plans between subsequent calls
        /// </summary>
        bool CachePlans { get; }
        /// <summary>
        /// Clear all currently cached plans
        /// </summary>
        void FreePlans();
        /// <summary>
        /// true, if the implementation efficiently transforms from/to hermitian sequences (hermitian symmetry). 
        /// </summary>
        /// <remarks>If this property returns 'true', the implementation brings increased performance. 
        /// If not, the symmetry methods will bring no performance advantage over the 1D transforms. </remarks>
        bool SpeedyHermitian { get; }

    }
}
