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
using System.Security; 
using System.Runtime.InteropServices;
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Misc; 

namespace ILNumerics.Native {
    
    /// <summary>
    /// Wrapper for FFT interface using ACML ver. 3.6
    /// </summary>
    public unsafe class ILACMLFFT : IILFFT, IDisposable {

        #region pinvoke definitions 
        
        [DllImport("libacml_dll"),SuppressUnmanagedCodeSecurity]
		private static extern void zfft1mx(int MODE, double SCALE, int INPL, int NSEQ, int N, IntPtr X, int INCX1, int INCX2, IntPtr Y, int INCY1, int INCY2, IntPtr COMM, ref int INFO);
        [DllImport("libacml_dll"),SuppressUnmanagedCodeSecurity]
		private static extern void cfft1mx(int MODE, float SCALE, int INPL, int NSEQ, int N,  IntPtr X, int INCX1, int INCX2, IntPtr Y, int INCY1, int INCY2, IntPtr COMM, ref int INFO);
        [DllImport("libacml_dll"),SuppressUnmanagedCodeSecurity]
		private static extern void zfft2dx(int MODE, double SCALE, int LTRANS, int INPL, int M, int N, IntPtr X, int INCX1, int INCX2, IntPtr Y, int INCY1, int INCY2, IntPtr COMM, ref int INFO);
        [DllImport("libacml_dll"),SuppressUnmanagedCodeSecurity]
		private static extern void cfft2dx(int MODE, float SCALE,  int LTRANS, int INPL, int M, int N, IntPtr X, int INCX1, int INCX2, IntPtr Y, int INCY1, int INCY2, IntPtr COMM, ref int INFO);

        #endregion

        #region value constants
        private class ACMLValues {
            public static readonly int Double = 8; 
            public static readonly int Single = 4; 
            public static readonly int Real = 1; 
            public static readonly int Complex = 2; 
            public static readonly int Backwards = 1; 
            public static readonly int Forward = -1; 
        }
        #endregion

        #region attributes 
        Dictionary<string,IntPtr> m_descriptors; 
        object _lockobject = new object(); 
        #endregion

        #region constructor 
        public ILACMLFFT () {
            m_descriptors = new Dictionary<string,IntPtr>(10); 
        }
        #endregion

        #region IILFFT Member - 1-D
        
#region HYCALPER LOOPSTART FORWARD 1D 
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            funcName
        </source>
        <destination>FFTForward1D</destination>
        <destination>FFTForward1D</destination>
        <destination>FFTForward1D</destination>
        <destination>FFTBackward1D</destination>
        <destination>FFTBackward1D</destination>
    </type>
    <type>
        <source locate="after">
            inArr
        </source>
        <destination>complex</destination>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            HCmapInOut
        </source>
        <destination>A.C</destination>
        <destination>ILMath.tofcomplex(A)</destination>
        <destination>A.C</destination>
        <destination>A.C</destination>
        <destination>A.C</destination>
    </type>
    <type>
        <source locate="after">
            HCdir
        </source>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Backwards</destination>
        <destination>ACMLValues.Backwards</destination>
    </type>
 </hycalper>
 */
        public ILArray</*!HC:HCretArr*/ complex > /*!HC:funcName*/ FFTForward1D (ILArray</*!HC:HCinArr*/ double > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ complex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return /*!HC:HCmapInOut*/ ILMath.tocomplex(A) ; 
            // prepare output array 
            ILArray</*!HC:HCretArr*/ complex > ret = /*!HC:HCmapInOut*/ ILMath.tocomplex(A) ;
            fft1dInplace(dim, ret,/*!HC:HCdir*/ ACMLValues.Forward );
            return ret;
        }
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        public ILArray< fcomplex >  FFTBackward1D (ILArray< fcomplex > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< fcomplex > ret =  A.C ;
            fft1dInplace(dim, ret, ACMLValues.Backwards );
            return ret;
        }

        public ILArray< complex >  FFTBackward1D (ILArray< complex > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            fft1dInplace(dim, ret, ACMLValues.Backwards );
            return ret;
        }

        public ILArray< fcomplex >  FFTForward1D (ILArray< fcomplex > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< fcomplex > ret =  A.C ;
            fft1dInplace(dim, ret, ACMLValues.Forward );
            return ret;
        }

        public ILArray< fcomplex >  FFTForward1D (ILArray< float > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return  ILMath.tofcomplex(A) ; 
            // prepare output array 
            ILArray< fcomplex > ret =  ILMath.tofcomplex(A) ;
            fft1dInplace(dim, ret, ACMLValues.Forward );
            return ret;
        }

        public ILArray< complex >  FFTForward1D (ILArray< complex > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            fft1dInplace(dim, ret, ACMLValues.Forward );
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE

        public ILArray<double> FFTBackwSym1D(ILArray<complex> A, int dim) {
            return ILMath.real(FFTBackward1D(A,dim));    
        }

        public ILArray<float> FFTBackwSym1D(ILArray<fcomplex> A, int dim) {
            return ILMath.real(FFTBackward1D(A,dim));    
        }

        #endregion

        #region IILFFT Member n-D

        #region HYCALPER LOOPSTART ND 
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            funcName
        </source>
        <destination>FFTForward</destination>
        <destination>FFTForward</destination>
        <destination>FFTForward</destination>
        <destination>FFTBackward</destination>
        <destination>FFTBackward</destination>
    </type>
    <type>
        <source locate="after">
            inArr
        </source>
        <destination>complex</destination>
        <destination>float</destination>
        <destination>fcomplex</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
    </type>
    <type>
        <source locate="after">
            HCmapInOut
        </source>
        <destination>A.C</destination>
        <destination>ILMath.tofcomplex(A)</destination>
        <destination>A.C</destination>
        <destination>A.C</destination>
        <destination>A.C</destination>
    </type>
    <type>
        <source locate="after">
            HCdir
        </source>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Forward</destination>
        <destination>ACMLValues.Backwards</destination>
        <destination>ACMLValues.Backwards</destination>
    </type>
 </hycalper>
 */
        public ILArray</*!HC:HCretArr*/ complex > /*!HC:funcName*/ FFTForward (ILArray</*!HC:HCinArr*/ double > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ complex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return /*!HC:HCmapInOut*/ ILMath.tocomplex(A) ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return /*!HC:funcName*/ FFTForward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray</*!HC:HCretArr*/ complex > ret = /*!HC:HCmapInOut*/ ILMath.tocomplex(A) ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret,/*!HC:HCdir*/ ACMLValues.Forward ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret,/*!HC:HCdir*/ ACMLValues.Forward ); 
                    }
                    break; 
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        public ILArray< fcomplex >  FFTBackward (ILArray< fcomplex > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return  A.C ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return  FFTBackward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray< fcomplex > ret =  A.C ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret, ACMLValues.Backwards ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret, ACMLValues.Backwards ); 
                    }
                    break; 
            }
            return ret;
        }

        public ILArray< complex >  FFTBackward (ILArray< complex > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return  A.C ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return  FFTBackward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray< complex > ret =  A.C ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret, ACMLValues.Backwards ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret, ACMLValues.Backwards ); 
                    }
                    break; 
            }
            return ret;
        }

        public ILArray< fcomplex >  FFTForward (ILArray< fcomplex > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return  A.C ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return  FFTForward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray< fcomplex > ret =  A.C ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret, ACMLValues.Forward ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret, ACMLValues.Forward ); 
                    }
                    break; 
            }
            return ret;
        }

        public ILArray< fcomplex >  FFTForward (ILArray< float > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< fcomplex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return  ILMath.tofcomplex(A) ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return  FFTForward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray< fcomplex > ret =  ILMath.tofcomplex(A) ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret, ACMLValues.Forward ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret, ACMLValues.Forward ); 
                    }
                    break; 
            }
            return ret;
        }

        public ILArray< complex >  FFTForward (ILArray< complex > A, int nDims) {
            if (A == null || nDims <= 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1))
                return  A.C ;
            if (nDims > A.Dimensions.NumberOfDimensions) 
                return  FFTForward (A,A.Dimensions.NumberOfDimensions); 

            // prepare output array + transform each dimension inplace 
            ILArray< complex > ret =  A.C ;
            switch (nDims) {
                case 2:
                    fft2dInplace(ret, ACMLValues.Forward ); 
                    break; 
                default: 
                    for (int i = 0; i < nDims; i++) {
                        fft1dInplace(i,ret, ACMLValues.Forward ); 
                    }
                    break; 
            }
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE

        public ILArray<float> FFTBackwSym(ILArray<fcomplex> A, int nDims) {
            return ILMath.real(FFTBackward(A,nDims)); 
        }

        public ILArray<double> FFTBackwSym(ILArray<complex> A, int nDims) {
            return ILMath.real(FFTBackward(A,nDims)); 
        }

        public bool CachePlans {
            get { return true; }
        }

        public void FreePlans() {
            FreeAllDescriptors();
        }

        public bool SpeedyHermitian {
            get { return false; }
        }

        #endregion

        #region private helper

        private void fft1dInplace(int dim, ILArray<complex> ret, int mode) {
            System.Diagnostics.Debug.Assert(!ret.IsReference);
            int N = ret.Dimensions[dim], info = 0;
            // spacing between elements
            int incx1 = ret.Dimensions.SequentialIndexDistance(dim);
            // storage of subsequent transformations
            int incx2 = incx1 * N;
            // number of transformations
            int nseq = ret.Dimensions.NumberOfElements / incx2;
            double scale = (mode == ACMLValues.Backwards) ? 1.0 / N : 1.0; 
            string hash = hashPlan(ACMLValues.Double, ACMLValues.Complex, N, "zfft1mx");
            IntPtr descriptor; 
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    int commLength = (3 * N + 100) * ACMLValues.Double * 2;
                    try {
                        descriptor = Marshal.AllocCoTaskMem(commLength);
                        zfft1mx(0, scale, 1, nseq, N, IntPtr.Zero, incx1, incx2, IntPtr.Zero, 0, 0, descriptor, ref info);
                        if (info != 0)
                            throw new ILInvalidOperationException("error creating fft-plan");
                        m_descriptors[hash] = descriptor;
                    } catch (OutOfMemoryException exc) {
                        if (m_descriptors.Count > 0) {
                            FreeAllDescriptors();
                            descriptor = Marshal.AllocCoTaskMem(commLength);
                            zfft1mx(0, scale, 1, nseq, N, IntPtr.Zero, incx1, incx2, IntPtr.Zero, 0, 0, descriptor, ref info);
                            if (info != 0)
                                throw new ILInvalidOperationException("error creating fft-plan");
                            m_descriptors[hash] = descriptor;
                        }
                        throw exc;
                    }
                }
                // do the transform(s)
                fixed (complex* start = ret.m_data) {
                    for (int i = 0; i < incx1 && info == 0; i++)
                        zfft1mx(mode, scale, 1, nseq, N, (IntPtr)(start + i), incx1, incx2, IntPtr.Zero, 0, 0, descriptor, ref info);
                }
            }
            if (info != 0) {
                throw new ILInvalidOperationException(String.Format("error: {0}th parameter was invalid", -info));
            }
        }
        private void fft2dInplace(ILArray<complex> ret, int mode) {
            System.Diagnostics.Debug.Assert(!ret.IsReference);
            System.Diagnostics.Debug.Assert(ret.Dimensions.NumberOfDimensions >= 2);
            int N = ret.Dimensions[1], M = ret.Dimensions[0], info = 0;
            int MN = M*N;
            // number of transformations
            int nseq = ret.Dimensions.NumberOfElements / (MN);
            double scale = (mode == ACMLValues.Backwards) ? 1.0 / MN : 1.0; 
            string hash = hashPlan(ACMLValues.Double, ACMLValues.Complex, M, N, "zfft2dx");
            IntPtr descriptor; 
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    int commLength = (3 * (N + M) + MN + 200) * ACMLValues.Double * 2;
                    try {
                        descriptor = Marshal.AllocCoTaskMem(commLength);
                        zfft2dx(0, scale, 1, 1, M, N, IntPtr.Zero, 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                        if (info != 0)
                            throw new ILInvalidOperationException("error creating fft-plan");
                        m_descriptors[hash] = descriptor;
                    } catch (OutOfMemoryException exc) {
                        if (m_descriptors.Count > 0) {
                            FreeAllDescriptors();
                            descriptor = Marshal.AllocCoTaskMem(commLength);
                            zfft2dx(0, scale, 1, 1, M, N, IntPtr.Zero, 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                            if (info != 0)
                                throw new ILInvalidOperationException("error creating fft-plan");
                            m_descriptors[hash] = descriptor;
                        }
                        throw exc;
                    }
                }
                // do the transform(s)
                fixed (complex* start = ret.m_data) {
                    for (int i = 0; i < nseq && info == 0; i++)
                        zfft2dx(mode, scale, 1, 1, M, N, (IntPtr)(start + i*MN), 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                }
            }
            if (info != 0) {
                throw new ILInvalidOperationException(String.Format("error: {0}th parameter was invalid", -info));
            }
        }

        private void fft1dInplace(int dim, ILArray<fcomplex> ret, int mode) {
            System.Diagnostics.Debug.Assert(!ret.IsReference);
            int N = ret.Dimensions[dim], info = 0;
            // spacing between elements
            int incx1 = ret.Dimensions.SequentialIndexDistance(dim);
            // storage of subsequent transformations
            int incx2 = incx1 * N;
            // number of transformations
            int nseq = ret.Dimensions.NumberOfElements / incx2;
            float scale = (mode == ACMLValues.Backwards) ? 1.0f / N : 1.0f; 
            string hash = hashPlan(ACMLValues.Single, ACMLValues.Complex, N, "cfft1mx");
            IntPtr descriptor; 
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    int commLength = (3 * N + 100) * ACMLValues.Single * 2;
                    try {
                        descriptor = Marshal.AllocCoTaskMem(commLength);
                        cfft1mx(0, 1.0f, 1, 1, N, IntPtr.Zero, 1, 1, IntPtr.Zero, 0, 0, descriptor, ref info);
                        if (info != 0)
                            throw new ILInvalidOperationException("error creating fft-plan");
                        m_descriptors[hash] = descriptor;
                    } catch (OutOfMemoryException exc) {
                        if (m_descriptors.Count > 0) {
                            FreeAllDescriptors();
                            descriptor = Marshal.AllocCoTaskMem(commLength);
                            cfft1mx(0, 1.0f, 1, 1, N, IntPtr.Zero, 1, 1, IntPtr.Zero, 0, 0, descriptor, ref info);
                            if (info != 0)
                                throw new ILInvalidOperationException("error creating fft-plan");
                            m_descriptors[hash] = descriptor;
                        }
                        throw exc;
                    }
                }
                // do the transform(s)
                fixed (fcomplex* start = ret.m_data) {
                    for (int i = 0; i < incx1 && info == 0; i++)
                        cfft1mx(mode, scale, 1, nseq, N, (IntPtr)(start + i), incx1, incx2, IntPtr.Zero, 0, 0, descriptor, ref info);
                }
            }
            if (info != 0) {
                throw new ILInvalidOperationException(String.Format("error: {0}th parameter was invalid", -info));
            }
        }
        private void fft2dInplace(ILArray<fcomplex> ret, int mode) {
            System.Diagnostics.Debug.Assert(!ret.IsReference);
            System.Diagnostics.Debug.Assert(ret.Dimensions.NumberOfDimensions >= 2);
            int N = ret.Dimensions[1], M = ret.Dimensions[0], info = 0;
            int MN = M*N;
            // number of transformations
            int nseq = ret.Dimensions.NumberOfElements / (MN);
            float scale = (mode == ACMLValues.Backwards) ? 1.0f / MN : 1.0f; 
            string hash = hashPlan(ACMLValues.Single, ACMLValues.Complex, M, N, "cfft2dx");
            IntPtr descriptor; 
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    int commLength = (3 * (N + M) + MN + 200) * ACMLValues.Single * 2;
                    try {
                        descriptor = Marshal.AllocCoTaskMem(commLength);
                        cfft2dx(0, scale, 1, 1, M, N, IntPtr.Zero, 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                        if (info != 0)
                            throw new ILInvalidOperationException("error creating fft-plan");
                        m_descriptors[hash] = descriptor;
                    } catch (OutOfMemoryException exc) {
                        if (m_descriptors.Count > 0) {
                            FreeAllDescriptors();
                            descriptor = Marshal.AllocCoTaskMem(commLength);
                            cfft2dx(0, scale, 1, 1, M, N, IntPtr.Zero, 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                            if (info != 0)
                                throw new ILInvalidOperationException("error creating fft-plan");
                            m_descriptors[hash] = descriptor;
                        }
                        throw exc;
                    }
                }
                // do the transform(s)
                fixed (fcomplex* start = ret.m_data) {
                    for (int i = 0; i < nseq && info == 0; i++)
                        cfft2dx(mode, scale, 1, 1, M, N, (IntPtr)(start + i*MN), 1, M, IntPtr.Zero, 0, 0, descriptor, ref info);
                }
            }
            if (info != 0) {
                throw new ILInvalidOperationException(String.Format("error: {0}th parameter was invalid", -info));
            }
        }

        private static string hashPlan(int precision, int realcomplex, int N, string funcname) {
            return hashPlan(precision,realcomplex,0,N,funcname); 
        }
        private static string hashPlan(int precision, int realcomplex, int M, int N, string funcname) {
            return String.Format("{0}|{1}|{2}|{3}|{4}",precision, realcomplex,M,N,funcname); 
        }
        private void FreeAllDescriptors() {
            lock (_lockobject) {
                if (m_descriptors != null) {
                    foreach (IntPtr p in m_descriptors.Values) {
                        if (p != IntPtr.Zero)
                            Marshal.FreeCoTaskMem(p); 
                    }
                    m_descriptors.Clear(); 
                }
            }
        }   
        
        #endregion

        #region IDisposable Member

        public void Dispose() {
            Dispose(true); 
            /* we cannot supress finalize,since the class will only wipe all 
             * cached cotask memory. Supsequent calls will again allocate those. 
             * Therefore the finalizer must be check at the end again. 
             */ 
            // GC.SuppressFinalize(this); 
        }

        public virtual void Dispose (bool manual) {
            if (m_descriptors != null && m_descriptors.Count > 0) {
                if (manual) {
                    FreeAllDescriptors();             
                }
            }
        }

        ~ILACMLFFT () {
            Dispose(true);     
        }
        #endregion

    }
}
