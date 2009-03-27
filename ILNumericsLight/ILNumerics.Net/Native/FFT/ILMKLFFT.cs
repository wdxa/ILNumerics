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
    /// MKL configuration parameters (constant definitions)
    /// </summary>
    internal sealed class MKLParameter {
        /* Domain for forward transform. No default value */
        public static readonly int FORWARD_DOMAIN = 0;

        /* Dimensionality; or rank. No default value */
        public static readonly int DIMENSION = 1;

        /* Length(s) of transform. No default value */
        public static readonly int LENGTHS = 2;

        /* Floating point precision. No default value */
        public static readonly int PRECISION = 3;

        /* Scale factor for forward transform [1.0] */
        public static readonly int FORWARD_SCALE  = 4;

        /* Scale factor for backward transform [1.0] */
        public static readonly int BACKWARD_SCALE = 5;

        /* Exponent sign for forward transform [NEGATIVE]  */
        /* FORWARD_SIGN = 6; ## NOT IMPLEMENTED */

        /* Number of data sets to be transformed [1] */
        public static readonly int NUMBER_OF_TRANSFORMS = 7;

        /* Storage of finite complex-valued sequences in complex domain
           [COMPLEX_COMPLEX] */
        public static readonly int COMPLEX_STORAGE = 8;

        /* Storage of finite real-valued sequences in real domain
           [REAL_REAL] */
        public static readonly int REAL_STORAGE = 9;

        /* Storage of finite complex-valued sequences in conjugate-even
           domain [COMPLEX_REAL] */
        public static readonly int CONJUGATE_EVEN_STORAGE = 10;

        /* Placement of result [INPLACE] */
        public static readonly int PLACEMENT = 11;

        /* Generalized strides for input data layout [tigth; row-major for
           C] */
        public static readonly int INPUT_STRIDES = 12;

        /* Generalized strides for output data layout [tight; row-major
           for C] */
        public static readonly int OUTPUT_STRIDES = 13;

        /* Distance between first input elements for multiple transforms
           [0] */
        public static readonly int INPUT_DISTANCE = 14;

        /* Distance between first output elements for multiple transforms
           [0] */
        public static readonly int OUTPUT_DISTANCE = 15;

        /* Ordering of the result [ORDERED] */
        public static readonly int ORDERING = 18;

        /* Possible transposition of result [NONE] */
        public static readonly int TRANSPOSE = 19;

        /* User-settable descriptor name [""] */
        public static readonly int DESCRIPTOR_NAME = 20; /* DEPRECATED */

        /* Packing format for COMPLEX_REAL storage of finite
           conjugate-even sequences [CCS_FORMAT] */
        public static readonly int PACKED_FORMAT = 21;

        /* Commit status of the descriptor - R/O parameter */
        public static readonly int COMMIT_STATUS = 22;

        /* Version string for this DFTI implementation - R/O parameter */
        public static readonly int VERSION = 23;

        /* Number of user threads that share the descriptor [1] */
        public static readonly int NUMBER_OF_USER_THREADS = 26;
    }
    /// <summary>
    /// MKL configuration values (constant definitions) 
    /// </summary>
    internal sealed class MKLValues {
        /* Values of the descriptor configuration parameters */
        /* COMMIT_STATUS */
        public static readonly int COMMITTED = 30;
        public static readonly int UNCOMMITTED = 31;

        /* FORWARD_DOMAIN */
        public static readonly int COMPLEX = 32;
        public static readonly int REAL = 33;
            /* CONJUGATE_EVEN = 34;   ## NOT IMPLEMENTED */

        /* PRECISION */
        public static readonly int SINGLE = 35;
        public static readonly int DOUBLE = 36;

        /* COMPLEX_STORAGE and CONJUGATE_EVEN_STORAGE */
        public static readonly int COMPLEX_COMPLEX = 39;
        public static readonly int COMPLEX_REAL = 40;

        /* REAL_STORAGE */
        public static readonly int REAL_COMPLEX = 41;
        public static readonly int REAL_REAL = 42;

        /* PLACEMENT */
        public static readonly int INPLACE = 43;          /* Result overwrites input */
        public static readonly int NOT_INPLACE = 44;      /* Have another place for result */

        /* ORDERING */
        public static readonly int ORDERED = 48;
        public static readonly int BACKWARD_SCRAMBLED = 49;

        /* Allow/avoid certain usages */
        public static readonly int ALLOW = 51;            /* Allow transposition or workspace */
        public static readonly int NONE = 53;

        /* PACKED_FORMAT (for storing congugate-even finite sequence
           in real array) */
        public static readonly int CCS_FORMAT = 54;       /* Complex conjugate-symmetric */
        public static readonly int PACK_FORMAT = 55;      /* Pack format for real DFT */
        public static readonly int PERM_FORMAT = 56;      /* Perm format for real DFT */
        public static readonly int CCE_FORMAT = 57;       /* Complex conjugate-even */
        
        /* Error classes */
        public static readonly int  NO_ERROR = 0; 
        public static readonly int  MEMORY_ERROR = 1;
        public static readonly int  INVALID_CONFIGURATION = 2;
        public static readonly int  INCONSISTENT_CONFIGURATION = 3;
        public static readonly int  MULTITHREADED_ERROR = 4;
        public static readonly int  BAD_DESCRIPTOR = 5;
        public static readonly int  UNIMPLEMENTED = 6;
        public static readonly int  MKL_INTERNAL_ERROR = 7;
        public static readonly int  NUMBER_OF_THREADS_ERROR = 8;
        public static readonly int  ONED_LENGTH_EXCEEDS_INT32 = 9;

        public static readonly int  MAX_MESSAGE_LENGTH = 40; /* Maximum length of error string */
        public static readonly int  MAX_NAME_LENGTH = 10;    /* Maximum length of descriptor name */
        public static readonly int  VERSION_LENGTH = 198;    /* Maximum length of MKL version string */
    }
    /// <summary>
    /// import functions (pinvoke)
    /// </summary>
    internal sealed class MKLImports {

        #region pinvoke definitions 
        
        [DllImport("mkl_custom", EntryPoint = "DftiCreateDescriptor",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        public static extern int DftiCreateDescriptor(ref IntPtr pDescriptor, int precision, int domain, int dimCount, int dim1);
        [DllImport("mkl_custom", EntryPoint = "DftiCreateDescriptor",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
        public static extern int DftiCreateDescriptor(ref IntPtr pDescriptor, int precision, int domain, int dimCount, int[] dims);
        [DllImport("mkl_custom", EntryPoint = "DftiFreeDescriptor",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiFreeDescriptor(IntPtr pDescriptor);
        [DllImport("mkl_custom", EntryPoint = "DftiCommitDescriptor",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiCommitDescriptor(IntPtr pDescriptor);
        [DllImport("mkl_custom", EntryPoint = "DftiErrorClass",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiErrorClass(int status, int ERROR_CLASS);
        [DllImport("mkl_custom", EntryPoint = "DftiSetValue",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiSetValue(IntPtr pDescriptor, int parameter, __arglist);
        [DllImport("mkl_custom", EntryPoint = "DftiGetValue",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiGetValue(IntPtr pDescriptor, int parameter, int value);
        [DllImport("mkl_custom", EntryPoint = "DftiComputeForward",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiComputeForward(IntPtr pDescriptor, __arglist);
        [DllImport("mkl_custom", EntryPoint = "DftiComputeBackward",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern int DftiComputeBackward(IntPtr pDescriptor, __arglist);
        [DllImport("mkl_custom", EntryPoint = "DftiErrorMessage",CallingConvention =CallingConvention.Cdecl),SuppressUnmanagedCodeSecurity]
		public static extern string DftiErrorMessage(int errID);

        #endregion
    }
    
    /// <summary>
    /// Wrapper for FFT interface using MKL 10_03
    /// </summary>
    public class ILMKLFFT : IILFFT, IDisposable {

        #region attributes 
        Dictionary<string,IntPtr> m_descriptors; 
        object _lockobject = new object(); 
        int[] m_tmpDims = new int[10]; 
        #endregion

        #region constructor 
        public ILMKLFFT () {
            m_descriptors = new Dictionary<string,IntPtr>(10); 
        }
        #endregion

        #region IILFFT Member - 1-D

        #region HYCALPER LOOPSTART 1D complex
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
        <destination>complex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            funcName
        </source>
        <destination>FFTForward1D</destination>
        <destination>FFTBackward1D</destination>
    </type>
    <type>
        <source locate="after">
            inArr
        </source>
        <destination>complex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            convRet
        </source>
        <destination>A.C</destination>
        <destination>A.C</destination>
    </type>
    <type>
        <source locate="after">
            mklPrec
        </source>
        <destination>MKLValues.DOUBLE</destination>
        <destination>MKLValues.DOUBLE</destination>
    </type>
    <type>
        <source locate="after">
            dftiFunc
        </source>
        <destination>MKLImports.DftiComputeForward</destination>
        <destination>MKLImports.DftiComputeBackward</destination>
    </type>               
    <type>
        <source locate="nextline">
            HCbackwScale
        </source>
        <destination></destination>
        <destination><![CDATA[MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0 / inDim));]]></destination>
    </type>               
 </hycalper>
 */
        public ILArray</*!HC:HCretArr*/ complex > /*!HC:funcName*/ FFTForward1D (ILArray</*!HC:inArr*/ double > A, int dim) {
            if (object.Equals(A,null) || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ complex >.empty(A.Dimensions); 
            if (dim >= A.Dimensions.NumberOfDimensions || A.Dimensions[dim] == 1) 
                return /*!HC:convRet*/ ILMath.tocomplex(A) ; 
            // prepare output array 
            ILArray</*!HC:HCretArr*/ complex > ret = /*!HC:convRet*/ ILMath.tocomplex(A) ;
            string hash = hashPlan(/*!HC:mklPrec*/ MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, A.Dimensions[dim]); 
            IntPtr descriptor = IntPtr.Zero;
            int error, inDim = A.Dimensions[dim];   
            // try to reuse existing descriptor
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor,/*!HC:mklPrec*/ MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, inDim);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // spacing between elements
            int tmp = A.Dimensions.SequentialIndexDistance(dim); 
            int[] stride = new int[]{0,tmp}; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(stride)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(stride)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // storage of subsequent transformations
            tmp = inDim * tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp)); 
            // how many transformations ? 
            tmp = A.Dimensions.NumberOfElements / tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            /*!HC:HCbackwScale*/

            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                tmp = A.Dimensions.SequentialIndexDistance(dim); 
                fixed (/*!HC:HCretArr*/ complex * retArr = ret.m_data) {
                    for (int i = 0; i < tmp && error == 0; i++)
                        error =  /*!HC:dftiFunc*/ MKLImports.DftiComputeForward (descriptor, __arglist(retArr + i));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        public ILArray< complex >  FFTBackward1D (ILArray< complex > A, int dim) {
            if (object.Equals(A,null) || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (dim >= A.Dimensions.NumberOfDimensions || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            string hash = hashPlan( MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, A.Dimensions[dim]); 
            IntPtr descriptor = IntPtr.Zero;
            int error, inDim = A.Dimensions[dim];   
            // try to reuse existing descriptor
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor, MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, inDim);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // spacing between elements
            int tmp = A.Dimensions.SequentialIndexDistance(dim); 
            int[] stride = new int[]{0,tmp}; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(stride)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(stride)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // storage of subsequent transformations
            tmp = inDim * tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp)); 
            // how many transformations ? 
            tmp = A.Dimensions.NumberOfElements / tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0 / inDim));
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                tmp = A.Dimensions.SequentialIndexDistance(dim); 
                fixed ( complex * retArr = ret.m_data) {
                    for (int i = 0; i < tmp && error == 0; i++)
                        error =  MKLImports.DftiComputeBackward (descriptor, __arglist(retArr + i));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }

        public ILArray< complex >  FFTForward1D (ILArray< complex > A, int dim) {
            if (object.Equals(A,null) || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray< complex >.empty(A.Dimensions); 
            if (dim >= A.Dimensions.NumberOfDimensions || A.Dimensions[dim] == 1) 
                return  A.C ; 
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            string hash = hashPlan( MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, A.Dimensions[dim]); 
            IntPtr descriptor = IntPtr.Zero;
            int error, inDim = A.Dimensions[dim];   
            // try to reuse existing descriptor
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor, MKLValues.DOUBLE ,MKLValues.COMPLEX, 1, inDim);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // spacing between elements
            int tmp = A.Dimensions.SequentialIndexDistance(dim); 
            int[] stride = new int[]{0,tmp}; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(stride)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(stride)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // storage of subsequent transformations
            tmp = inDim * tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp)); 
            // how many transformations ? 
            tmp = A.Dimensions.NumberOfElements / tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                tmp = A.Dimensions.SequentialIndexDistance(dim); 
                fixed ( complex * retArr = ret.m_data) {
                    for (int i = 0; i < tmp && error == 0; i++)
                        error =  MKLImports.DftiComputeForward (descriptor, __arglist(retArr + i));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART 1D real (backward only)

/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
    </type>
    <type>
        <source locate="after">
            inArr
        </source>
    </type>
    <type>
        <source locate="after">
            mklPrec
        </source>
    </type>
 </hycalper>
 */

        public ILArray</*!HC:HCretArr*/ double > FFTBackwSym1D(ILArray</*!HC:inArr*/ complex > A, int dim) {
            if (A == null || dim < 0) 
                throw new ILArgumentException("invalid parameter!"); 
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ double >.empty(A.Dimensions); 
            if (A.IsScalar || A.Dimensions[dim] == 1) 
                return ILMath.real(A); 
            // prepare output array, if we query the memory directly from
            // memory pool, we prevent from clearing the elements since every 
            // single one will be overwritten by fft anyway
            int error = 0,inDim = A.Dimensions[dim];   
            /*!HC:HCretArr*/ double [] retArr = ILMemoryPool.Pool.New</*!HC:HCretArr*/ double >(A.Dimensions.NumberOfElements); 
            ILArray</*!HC:HCretArr*/ double > ret = new ILArray</*!HC:HCretArr*/ double >(retArr,A.Dimensions); 
            string hash = hashPlan(/*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.REAL, 1, inDim); 
            IntPtr descriptor = IntPtr.Zero;
            // try to reuse existing descriptor
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor,/*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.REAL, 1, inDim);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // spacing between elements
            int tmp = A.Dimensions.SequentialIndexDistance(dim); 
            int[] stride = new int[]{0,tmp}; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(stride)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(stride)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // storage of subsequent transformations
            tmp = inDim * tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp)); 
            // how many transformations ? 
            tmp = A.Dimensions.NumberOfElements / tmp; 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(tmp)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,__arglist(MKLValues.NOT_INPLACE)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.REAL_STORAGE, __arglist(MKLValues.REAL_REAL)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.CONJUGATE_EVEN_STORAGE, __arglist(MKLValues.COMPLEX_COMPLEX)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0 / inDim)); 
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            tmp = A.Dimensions.SequentialIndexDistance(dim); 
            unsafe {
                fixed (/*!HC:HCretArr*/ double * retArrP = ret.m_data) 
                fixed (/*!HC:inArr*/ complex * pA = A.m_data) {
                    for (int i = 0; i < tmp && error == 0; i++) 
                        error = MKLImports.DftiComputeBackward(descriptor, __arglist(pA + i,retArrP + i));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

#endregion HYCALPER AUTO GENERATED CODE

        #endregion

        #region IILFFT Member - n-D

        #region HYCALPER LOOPSTART ND-TRANSFORMS 
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
        <destination>complex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            funcName
        </source>
        <destination>FFTForward</destination>
        <destination>FFTBackward</destination>
    </type>
    <type>
        <source locate="after">
            inArr
        </source>
        <destination>complex</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            convRet
        </source>
        <destination>A.C</destination>
        <destination>A.C</destination>
    </type>
    <type>
        <source locate="after">
            mklPrec
        </source>
        <destination>MKLValues.DOUBLE</destination>
        <destination>MKLValues.DOUBLE</destination>
    </type>
    <type>
        <source locate="after">
            dftiFunc
        </source>
        <destination>MKLImports.DftiComputeForward</destination>
        <destination>MKLImports.DftiComputeBackward</destination>
    </type>               
    <type>
        <source locate="nextline">
            HCbackwScale
        </source>
        <destination></destination>
        <destination><![CDATA[MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0/tmp));]]></destination>
    </type>               
    <type>
        <source locate="nextline">
            limit3D
        </source>
        <destination></destination>
        <destination></destination>
    </type>               
 </hycalper>
 */
        public ILArray</*!HC:HCretArr*/ complex > /*!HC:funcName*/ FFTForward (ILArray</*!HC:HCinArr*/ double > A, int nDims) {
            if (A == null || nDims <= 0 ) 
                throw new ILArgumentException("invalid argument!");
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ complex > .empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1)) 
                return /*!HC:convRet*/ ILMath.tocomplex(A) ; 
            if (nDims > A.Dimensions.NumberOfDimensions) 
                nDims = A.Dimensions.NumberOfDimensions; 
            /*!HC:limit3D*/
            if (nDims > 3) return FFTForward(ILMath.tocomplex(A),nDims); 
            // prepare output array 
            ILArray</*!HC:HCretArr*/ complex > ret = /*!HC:convRet*/ ILMath.tocomplex(A) ;
            IntPtr descriptor = IntPtr.Zero;
            int error = -1;   
            int[] tmpDims = A.Dimensions.ToIntArray(nDims+1);
            string hash = hashPlan(/*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
            lock (_lockobject) {
            // try to reuse existing descriptor
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor, /*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // how many transformations ? 
            int tmp = A.Dimensions.SequentialIndexDistance(nDims); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(A.Dimensions.NumberOfElements / tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.REAL_STORAGE, MKLValues.REAL_COMPLEX); 
            // storage of subsequent transformations
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp));
            /*!HC:HCbackwScale*/
             
            // spacing between elements
            tmpDims[0] = 0; 
            for (int i = 0; i < nDims; i++) {
                tmpDims[i+1] = A.Dimensions.SequentialIndexDistance(i); 
            }
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(tmpDims)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(tmpDims)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                fixed (/*!HC:HCretArr*/ complex * retArr = ret.m_data) {
                    error = /*!HC:dftiFunc*/ MKLImports.DftiComputeForward (descriptor, __arglist(retArr));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        public ILArray< complex >  FFTBackward (ILArray< complex > A, int nDims) {
            if (A == null || nDims <= 0 ) 
                throw new ILArgumentException("invalid argument!");
            if (A.IsEmpty) return ILArray< complex > .empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1)) 
                return  A.C ; 
            if (nDims > A.Dimensions.NumberOfDimensions) 
                nDims = A.Dimensions.NumberOfDimensions; 
            
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            IntPtr descriptor = IntPtr.Zero;
            int error = -1;   
            int[] tmpDims = A.Dimensions.ToIntArray(nDims+1);
            string hash = hashPlan( MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
            lock (_lockobject) {
            // try to reuse existing descriptor
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor,  MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // how many transformations ? 
            int tmp = A.Dimensions.SequentialIndexDistance(nDims); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(A.Dimensions.NumberOfElements / tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.REAL_STORAGE, MKLValues.REAL_COMPLEX); 
            // storage of subsequent transformations
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp));
            MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0/tmp));
            // spacing between elements
            tmpDims[0] = 0; 
            for (int i = 0; i < nDims; i++) {
                tmpDims[i+1] = A.Dimensions.SequentialIndexDistance(i); 
            }
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(tmpDims)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(tmpDims)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                fixed ( complex * retArr = ret.m_data) {
                    error =  MKLImports.DftiComputeBackward (descriptor, __arglist(retArr));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }

        public ILArray< complex >  FFTForward (ILArray< complex > A, int nDims) {
            if (A == null || nDims <= 0 ) 
                throw new ILArgumentException("invalid argument!");
            if (A.IsEmpty) return ILArray< complex > .empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1)) 
                return  A.C ; 
            if (nDims > A.Dimensions.NumberOfDimensions) 
                nDims = A.Dimensions.NumberOfDimensions; 
            
            // prepare output array 
            ILArray< complex > ret =  A.C ;
            IntPtr descriptor = IntPtr.Zero;
            int error = -1;   
            int[] tmpDims = A.Dimensions.ToIntArray(nDims+1);
            string hash = hashPlan( MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
            lock (_lockobject) {
            // try to reuse existing descriptor
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor,  MKLValues.DOUBLE , MKLValues.COMPLEX, nDims, tmpDims);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }
            }
            // how many transformations ? 
            int tmp = A.Dimensions.SequentialIndexDistance(nDims); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(A.Dimensions.NumberOfElements / tmp)); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,MKLValues.NOT_INPLACE); 
            //error = MKLImports.DftiSetValue(descriptor,MKLParameter.REAL_STORAGE, MKLValues.REAL_COMPLEX); 
            // storage of subsequent transformations
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp));
            
            // spacing between elements
            tmpDims[0] = 0; 
            for (int i = 0; i < nDims; i++) {
                tmpDims[i+1] = A.Dimensions.SequentialIndexDistance(i); 
            }
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(tmpDims)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(tmpDims)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                fixed ( complex * retArr = ret.m_data) {
                    error =  MKLImports.DftiComputeForward (descriptor, __arglist(retArr));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE
        
        #region HYCALPER LOOPSTART BACKWARD SYM ND 
        /*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            HCretArr
        </source>
    </type>
    <type>
        <source locate="after">
            HCinArr
        </source>
    </type>
    <type>
        <source locate="after">
            mklPrec
        </source>
    </type>
 </hycalper>
 */
        public ILArray</*!HC:HCretArr*/ double > FFTBackwSym(ILArray</*!HC:HCinArr*/ complex > A, int nDims) {
            if (A == null || nDims <= 0 ) 
                throw new ILArgumentException("invalid argument!");
            if (A.IsEmpty) return ILArray</*!HC:HCretArr*/ double > .empty(A.Dimensions); 
            if (A.IsScalar || (A.Dimensions[0] == 1 && nDims == 1)) 
                return ILMath.real(A); 
            if (nDims > A.Dimensions.NumberOfDimensions) 
                nDims = A.Dimensions.NumberOfDimensions; 
            // MKL currently does not handle more than 3 dimensions this way
            if (nDims > 3) {
                return ILMath.real(FFTBackward(A,nDims)); 
            }
            // prepare output array, if we query the memory directly from
            // memory pool, we prevent from clearing the elements since every 
            // single one will be overwritten by fft anyway
            /*!HC:HCretArr*/ double [] retArr = ILMemoryPool.Pool.New</*!HC:HCretArr*/ double >(A.Dimensions.NumberOfElements); 
            ILArray</*!HC:HCretArr*/ double > ret = new ILArray</*!HC:HCretArr*/ double >(retArr,A.Dimensions); 
            IntPtr descriptor = IntPtr.Zero;
            int error = -1;   
            int[] tmpDims = A.Dimensions.ToIntArray(nDims+1);
            string hash = hashPlan(/*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.REAL, nDims, tmpDims);
            // try to reuse existing descriptor
            lock (_lockobject) {
                if (!m_descriptors.TryGetValue(hash, out descriptor)) {
                    error = MKLImports.DftiCreateDescriptor(ref descriptor, /*!HC:mklPrec*/ MKLValues.DOUBLE , MKLValues.REAL, nDims, tmpDims);
                    if (isMKLError(error)) {
                        throw new ILInvalidOperationException ("error creating descriptor: " + MKLImports.DftiErrorMessage(error)); 
                    }
                    m_descriptors[hash] = descriptor; 
                }                                                                                                                     
            }
            // how many transformations ? 
            int tmp = A.Dimensions.SequentialIndexDistance(nDims); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.NUMBER_OF_TRANSFORMS, __arglist(A.Dimensions.NumberOfElements / tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_DISTANCE, __arglist(tmp)); 
            MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_DISTANCE, __arglist(tmp)); 

            error = MKLImports.DftiSetValue(descriptor,MKLParameter.PLACEMENT,__arglist(MKLValues.NOT_INPLACE)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.REAL_STORAGE, __arglist(MKLValues.REAL_REAL)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.CONJUGATE_EVEN_STORAGE, __arglist(MKLValues.COMPLEX_COMPLEX)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.BACKWARD_SCALE, __arglist(1.0 / tmp)); 
            // spacing between elements
            tmpDims[0] = 0; 
            for (int i = 0; i < nDims; i++) {
                tmpDims[i+1] = A.Dimensions.SequentialIndexDistance(i); 
            }
            MKLImports.DftiSetValue(descriptor,MKLParameter.INPUT_STRIDES, __arglist(tmpDims)); 
            error = MKLImports.DftiSetValue(descriptor,MKLParameter.OUTPUT_STRIDES, __arglist(tmpDims)); 
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            error = MKLImports.DftiCommitDescriptor(descriptor);
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            // do the transform(s)
            unsafe {
                fixed (/*!HC:HCretArr*/ double * retArrP = ret.m_data) 
                fixed (/*!HC:HCinArr*/ complex * inArr = A.m_data) {
                    error = MKLImports.DftiComputeBackward(descriptor, __arglist(inArr,retArrP));
                }
            }
            if (isMKLError(error)) {
                throw new ILInvalidOperationException ("error: " + MKLImports.DftiErrorMessage(error)); 
            }
            return ret;
        }
        #endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

#endregion HYCALPER AUTO GENERATED CODE

        #endregion
        
        #region IILFFT Member - Misc
        
        public bool CachePlans {
            get {
                return true; 
            }
        }

        public void FreePlans() {
            FreeAllDescriptors(); 
        }

        public bool SpeedyHermitian {
            get { return true; }
        }

        #endregion

        #region private helper
        private static string hashPlan(int p, int p_2, int p_3, int p_4) {
            return String.Format("{0}|{1}|{2}|{3}",p, p_2,p_3,p_4); 
        }
        private static string hashPlan(int prec, int domain, int dimCount, int[] dims) {
            System.Diagnostics.Debug.Assert(dimCount <= dims.Length); 
            StringBuilder sb = new StringBuilder(prec + "|" + domain + "|" + dimCount + "|" + dims[0]);
            for (int i = 1; i < dimCount; i++) {
			    sb.Append("|" + dims[i]);          
			}
            return sb.ToString(); 
        }
        private static bool isMKLError(int error) {
            // TODO check! only the first 32 bits seem to be relevant for error!
            //return MKLImports.DftiErrorClass(error, MKLValues.NO_ERROR) != 1;
            return error != MKLValues.NO_ERROR; 
        }
        private void FreeAllDescriptors() {
            lock (_lockobject) {
                if (m_descriptors != null) {
                    foreach (IntPtr p in m_descriptors.Values) {
                        MKLImports.DftiFreeDescriptor(p); 
                    }
                    m_descriptors.Clear(); 
                }
            }
        }   
        #endregion

        #region IDisposable Member

        public void Dispose() {
            Dispose(true); 
            GC.SuppressFinalize(this); 
        }

        public virtual void Dispose (bool manual) {
            if (m_descriptors != null && m_descriptors.Count > 0) {
                if (manual) {
                    FreeAllDescriptors();             
                }
            }
        }

        ~ILMKLFFT () {
            Dispose(true);     
        }
        #endregion

    }
}
