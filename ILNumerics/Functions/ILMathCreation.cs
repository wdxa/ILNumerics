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

namespace ILNumerics.BuiltInFunctions {

	public partial class ILMath {

        #region Array Creation
        #region ONES / ZEROS / EMPTY 
        /// <summary>
        /// Create new ILArray&lt;double&gt;, setting initial element values to one.
        /// </summary>
        /// <returns>Physical ILArray&lt;double&gt; with all elements set to one.</returns>
        public static ILArray<double> ones(params int[] dimensions) {
	        ILDimension dim = new ILDimension(dimensions);
	        double[] data = ILMemoryPool.Pool.New<double>(dim.NumberOfElements);
	        ILArray<double> ret = new ILArray<double>(data, dimensions);
	        return set(ret, 1.0); 
	        {/* unsafe {
		        fixed(double* pData = data) {
			        double* ende = pData + data.Length; 
			        double* curr = pData; 
			        while (curr < ende) 
				        *curr++ = 1.0; 
	        }*/
	        }
        }
        /// <summary>
        /// Create new ILArray&lt;double&gt;, setting initial element values to one.
        /// </summary>
        /// <returns>Physical ILArray&lt;double&gt; with all elements set to one. </returns>
        public static ILArray<double> ones (ILDimension dimensions) {
            return ones(dimensions.ToIntArray());     
        }
        
        /// <summary>
        /// Create array initialized with all elements set to zero.
        /// </summary>
        /// <param name="dimensions">Dimension specification.</param>
        /// <returns>Zeros-filled array.</returns>
        /// <remarks>The memory for the array is reclaimed from the memory pool, if possible.</remarks>
        public static ILArray<double> zeros(params int[] dimensions) {
            ILDimension retDims = new ILDimension(dimensions); 
            bool cleared = false; 
            double[] retArr = ILMemoryPool.Pool.New<double>(retDims.NumberOfElements,false,out cleared); 
            if (!cleared) {
                unsafe {
                    fixed (double * pRetArr = retArr) {
                        double * walk = pRetArr; 
                        double * end = pRetArr + retArr.Length; 
                        while (walk < end)
                            *(walk++) = 0.0; 
                    }
                }
            }
            return new ILArray<double>(retArr,retDims); 
        }
        /// <summary>
        /// Create array initialized with all elements set to zero.
        /// </summary>
        /// <param name="dimensions">Dimension specification.</param>
        /// <returns>Zeros-filled array.</returns>
        public static ILArray<double> zeros(ILDimension dimensions) {
            return zeros(dimensions.ToIntArray()); 
        }

        /// <summary>
        /// Create empty array of size 0,0.
        /// </summary>
        /// <returns>ILArray of inner type double which is empty.</returns>
        public static ILArray<double> empty() {
            return ILArray<double>.empty(0,0);
        }
        #endregion

        /// <summary>
        /// Create matrix having unity diagonal values.  
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        /// <returns>Diagonal unity matrix.</returns>
        public static ILArray<double> eye(int rows, int columns) {
            ILArray<double> ret = zeros(rows, columns);
            int diagLen = Math.Min(rows, columns);
            for (int i = 0; i < diagLen; i++)
                ret[i, i] = 1.0;
            return ret;
        }
        /// <summary>
        /// Random number generator used for any generation of random numbers.
        /// </summary>
        /// <remarks>One may override this value with their own implementation, derived from <c>Random</c>.</remarks>
        protected static Random m_randomGenerator; 
        /// <summary>
        /// Pseudo random N-dimensional array elements.
        /// </summary>
        /// <param name="dimensions">int array or single int paramters specifying 
        /// dimensions for new array to be created.</param>
        /// <returns>N-dimensional array filled with random numbers.</returns>
        /// <remarks><para>The elements lie within the range 0.0 ... 1.0 and are uniformly 
        /// distributed.</para>
        /// <para>The initial seed will be set to Environment.TickCount on the first call.</para></remarks>
        public static ILArray<double> rand(params int[] dimensions) {
            ILDimension dim = new ILDimension(dimensions);
            double[] data = ILMemoryPool.Pool.New<double>(dim.NumberOfElements);
            if (m_randomGenerator == null) {
                m_randomGenerator = new Random(System.Environment.TickCount);
            } 
            unsafe {
                fixed (double* pRetArray = data) {
                    double* pCurIdx = pRetArray;
                    double* pLastElement = pCurIdx + dim.NumberOfElements;
                    while (pCurIdx < pLastElement)
                        *pCurIdx++ = m_randomGenerator.NextDouble();
                }
            }
            return new ILArray<double>(data, dimensions);
        }
        internal static ILNRandom m_nrandomGenerator; 
        /// <summary>
        /// Normal randomly-distributed N-dimensional array elements.
        /// </summary>
        /// <param name="dimensions">int array or single int paramters specifying 
        /// dimensions for new array to be created.</param>
        /// <returns>N-dimensional array filled with random numbers.</returns>
        /// <remarks>The elements lie within the range 0.0 ... 1.0 and are choosen to be normally 
        /// distributed.</remarks>
        public static ILArray<double> randn(params int[] dimensions) {
            ILDimension dim; 
            if (dimensions.Length == 1) 
                dim = new ILDimension(dimensions[0],dimensions[0]);
            else 
                dim = new ILDimension(dimensions);
            if (m_nrandomGenerator == null)
                m_nrandomGenerator = new ILNRandom(Environment.TickCount); 
            double[] data = ILMemoryPool.Pool.New<double>(dim.NumberOfElements);
            unsafe {
                fixed (double* pRetArray = data) {
                    double* pCurIdx = pRetArray;
                    double* pLastElement = pCurIdx + dim.NumberOfElements;
                    while (pCurIdx < pLastElement)
                        *pCurIdx++ = m_nrandomGenerator.NextDouble();
                }
            }
            return new ILArray<double>(data, dim);
        }
        /// <summary>
        /// Create regulary spaced vector.
        /// </summary>
        /// <param name="start">Start value.</param>
        /// <param name="end">End value.</param>
        /// <returns>Row vector of size 1xN, where N is the number of elements 
        /// between start and end, all equally spaced with interval 1. The last element 
        /// of the returned vector will be less than or equal to end, if start <![CDATA[<]]> end. If start 
        /// <![CDATA[>]]> end, the elements in the vector will regularly decrease from 
        /// start to end. In this case, step must be negative.</returns>
        /// <remarks>This is the same as vector (start,[-]1,end).</remarks>
        public static ILArray<double> vector (double start, double end) {
            return vector (start, Math.Sign(end-start),end);
        }
        /// <summary>
        /// Create N-dimensional array with elements counting from 1.
        /// </summary>
        /// <param name="dimensions">Variable int array with dimension specification</param>
        /// <returns>Array with elements counting from 1 ... dimensions.NumberOfElements</returns>
        /// <remarks>This function may be used for the convenient creation of arrays for testing purposes.</remarks>
        public static ILArray<double> counter (params int[] dimensions) {
            ILDimension dimRet = new ILDimension(dimensions); 
            double [] retArr = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements); 
            for (int i = 0; i < retArr.Length; )
                retArr[i] = ++i; 
            return new ILArray<double>(retArr,dimRet); 
        }
        /// <summary>
        /// Create N-dimensional array with elements counting from 1 and specified interval.
        /// </summary>
        /// <param name="start">Initial value.</param>
        /// <param name="increment">Increment for each element.</param>
        /// <param name="dimensions">Variable int array with dimension specification.</param>
        /// <returns>Array with elements counting from 1 ... dimensions.NumberOfElements.</returns>
        /// <remarks><para>Counter is a fast alternative to the creation of arrays via <see cref="ILNumerics.BuiltInFunctions.ILMath.ones(int[])"/>
        /// or <see cref="ILNumerics.BuiltInFunctions.ILMath.zeros(int[])"/> with subsequent modification. 
        /// Counter is more general. It can create arrays of all constants (zeros, ones, twos ...) if <paramref name="increment"/> is 0, regularly 
        /// incrementing elements if <paramref name="increment"/> is positive or negative.</para>
        /// This function may also be used for the convenient creation of arrays for testing purposes.
        /// <para>Keep in mind: in order to distingush this function from the overloaded version <see cref="ILNumerics.BuiltInFunctions.ILMath.counter(int[])"/>
        /// you need to specify parameters <paramref name="start"/> and <paramref name="increments"/> explicitly as double value:</para>
        /// <example><code>
        /// // This will create elements counting from 1...24: 
        /// <![CDATA[ILArray<double>]]> A = ILMath.counter(4,3,2); 
        /// // This will create elements counting from 1...48 with intervals of 2.0: 
        /// <![CDATA[ILArray<double>]]> A = ILMath.counter(1.0,2.0,4,3,2); 
        /// // ... but this will (by mistake) call the wrong function:
        /// <![CDATA[ILArray<double>]]> A = ILMath.counter(1,2,4,3,2); 
        /// // ... and therefore create an array of size [1,2,4,3,2] with elements counting from one!
        /// </code></example>  </remarks>
        public static ILArray<double> counter (double start, double increment, params int[] dimensions) {
            ILDimension dimRet = new ILDimension(dimensions); 
            double [] retArr = ILMemoryPool.Pool.New<double>(dimRet.NumberOfElements); 
            double val = start; 
            unsafe {
                fixed (double* pRetArr = retArr) {
                    double* pRetArray = pRetArr;
                    double* pEnd = pRetArr + retArr.Length; 
                    while (pRetArray < pEnd) {
                        *pRetArray++ = val; 
                        val += increment; 
                    }
                }
            }
            return new ILArray<double>(retArr,dimRet); 
        }

        /// <summary>
        /// Create regularly spaced vector.
        /// </summary>
        /// <param name="start">Start value.</param>
        /// <param name="step">Step size.</param>
        /// <param name="end">End value.</param>
        /// <returns>Row vector of size 1xN, where N is the number of elements 
        /// between start and end, all equally spaced with interval step. The last element 
        /// of the returned vector will be less than or equal to end, if start <![CDATA[<]]> end. If start 
        /// <![CDATA[>]]> end, the elements in the vector will regularly decrease from 
        /// start to end. In this case, step must be negative.</returns>
        public static ILArray<double> vector(double start, double step, double end) {
            if (start == end) 
                return new ILArray<double>(start); 
            if (step == 0) 
                throw new ILArgumentException("vector: step may not be 0!"); 
            if (start > end && step > 0) 
                throw new ILArgumentException("vector: if start > end: step must be negativ!"); 
            if (start < end && step < 0)
                throw new ILArgumentException("vector: if start < end: step must be positiv!"); 
            int nrElements = (int)Math.Floor((end - start) / step) +1 ;  
            double [] data; 
            try {
                data = ILMemoryPool.Pool.New<double>(nrElements); 
                unsafe {
                    double val = start; 
                    fixed (double * pDataConst = data) {
                        double * pData = pDataConst; 
                        double * lastElement = pDataConst + nrElements; 
                        while (pData < lastElement) {
                            *pData++ = val;
                            val += step;
                        }
                    }
                }
            } catch (Exception e){
                if (e is OutOfMemoryException)
                    throw new ILMemoryException("Not enough memory for: vector(" + start + "," + step + "," + end + ")"); 
                throw new Exception ("vector:" , e); 
            }
            return new ILArray<double> (data,nrElements,1);  
        }

        #endregion
        #region other types than 'double' creation
        /// <summary>
        /// Create array initialized with all elements set to one.
        /// </summary>
        /// <param name="type">Numeric type specification. One value out of the types listed in the <see cred="ILNumerics.NumericType"/>
        /// enum.</param>
        /// <param name="dimensions">Dimension specification. At least one dimension must be specified.</param>
        /// <returns>ILArray&lt;BaseT&gt; of inner type corresponding to <paramref name="type"/> argument.</returns>
        /// <remarks>The array returned may be cast to the appropriate actual type afterwards. 
        /// <para>
        /// <list type="number"> 
        /// <listheader>The following types are supported: </listheader>
        /// <item>Double</item>
        /// <item>Single</item>
        /// <item>Complex</item>
        /// <item>FComplex</item>
        /// <item>Byte</item>
        /// <item>Char</item>
        /// <item>Int16</item>
        /// <item>Int32</item>
        /// <item>Int64</item>
        /// <item>UInt16</item>
        /// <item>UInt32</item>
        /// <item>UInt64</item>
        /// </list>
        /// </para>
        /// </remarks>
        public static ILBaseArray ones(NumericType type, params int[] dimensions) {
            if (dimensions.Length < 1)
                throw new ILArgumentException("ones: invalid dimension specified!"); 
            switch (type) {
                case NumericType.Double: 
                    return ones(dimensions); 
                case NumericType.Single: 
	                ILDimension dim = new ILDimension(dimensions);
                    unsafe {
                        float[] data = null; 
                        data = new float[dim.NumberOfElements];
                        fixed(float* pD = data) {
                            float* pStart = pD; 
                            float* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1.0f; 
                            }
                        }
                        return new ILArray<float>(data, dimensions);
                    }
                case NumericType.Complex: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        complex[] data = null; 
                        data = new complex[dim.NumberOfElements];
                        fixed(complex* pD = data) {
                            complex* pStart = pD; 
                            complex* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = new complex(1.0,1.0); 
                            }
                        }
	                    return new ILArray<complex>(data, dimensions);
                    }
                case NumericType.FComplex: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        fcomplex[] data = null; 
                        data = new fcomplex[dim.NumberOfElements];
                        fixed(fcomplex* pD = data) {
                            fcomplex* pStart = pD; 
                            fcomplex* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = new fcomplex(1.0f,1.0f); 
                            }
                        }
	                    return new ILArray<fcomplex>(data, dimensions);
                    }
                case NumericType.Byte: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        byte[] data =  null; 
                        data = new byte[dim.NumberOfElements];
                        fixed(byte* pD = data) {
                            byte* pStart = pD; 
                            byte* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
 	                    return new ILArray<byte>(data, dimensions);
                   }
                case NumericType.Char: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        char[] data =  null; 
                        data = new char[dim.NumberOfElements];
                        fixed(char* pD = data) {
                            char* pStart = pD; 
                            char* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = Char.MinValue; 
                            }
                        }
	                    return new ILArray<char>(data, dimensions);
                    }
                case NumericType.Int16: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        Int16[] data =  null; 
                        data = new Int16[dim.NumberOfElements];
                        fixed(Int16* pD = data) {
                            Int16* pStart = pD; 
                            Int16* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
	                    return new ILArray<Int16>(data, dimensions);
                    }
                case NumericType.Int32: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        Int32[] data =  null; 
                        data = new Int32[dim.NumberOfElements];
                        fixed(Int32* pD = data) {
                            Int32* pStart = pD; 
                            Int32* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
	                    return new ILArray<Int32>(data, dimensions);
                    }
                case NumericType.Int64: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        Int64[] data =  null; 
                        data = new Int64[dim.NumberOfElements];
                        fixed(Int64* pD = data) {
                            Int64* pStart = pD; 
                            Int64* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
 	                    return new ILArray<Int64>(data, dimensions);
                   }
                case NumericType.UInt16: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        UInt16[] data =  null; 
                        data = new UInt16[dim.NumberOfElements];
                        fixed(UInt16* pD = data) {
                            UInt16* pStart = pD; 
                            UInt16* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
	                    return new ILArray<UInt16>(data, dimensions);
                    }
                case NumericType.UInt32: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        UInt32[] data =  null; 
                        data = new UInt32[dim.NumberOfElements];
                        fixed(UInt32* pD = data) {
                            UInt32* pStart = pD; 
                            UInt32* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
 	                    return new ILArray<UInt32>(data, dimensions);
                   }
                case NumericType.UInt64: 
	                dim = new ILDimension(dimensions);
                    unsafe {
                        UInt64[] data =  null; 
                        data = new UInt64[dim.NumberOfElements];
                        fixed(UInt64* pD = data) {
                            UInt64* pStart = pD; 
                            UInt64* pEnd = pD + data.Length; 
                            while (pEnd > pStart) {
                                *(--pEnd) = 1; 
                            }
                        }
	                    return new ILArray<UInt64>(data, dimensions);
                    }
            }
            return null; 
        }
        #endregion 

        /// <summary>
        /// Create complex array from real and imaginary parts. 
        /// </summary>
        /// <param name="real">Array with real part elements.</param>
        /// <param name="imag">Array with imaginary part elements.</param>
        /// <returns>Complex array constructed out of real and imaginary parts given.</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">If the size of both arguments is not the same.</exception>
        public static ILArray<complex> ccomplex(ILArray<double> real, ILArray<double> imag) {
            if (!real.Dimensions.IsSameSize(imag.Dimensions)) 
                throw new ILArgumentException("complex: input arrays must have the same size!");
            ILArray<complex> ret = ILMath.tocomplex(real);
            int nelem = real.Dimensions.NumberOfElements; 
            // here 'ret' is assumed to be physical (NOT reference storage!)
            for (int i = 0; i < nelem; i++) {
                ret.m_data[i].imag = imag.GetValue(i); 
            }
            return ret; 
        }
        /// <summary>
        /// Create complex array from real and imaginary parts. 
        /// </summary>
        /// <param name="real">Array with real part elements.</param>
        /// <param name="imag">Array with imaginary part elements.</param>
        /// <returns>Complex array constructed out of real and imaginary parts supplied.</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">If the size of both arguments is not the same.</exception>
        public static ILArray<fcomplex> ccomplex(ILArray<float> real, ILArray<float> imag) {
            if (!real.Dimensions.IsSameSize(imag.Dimensions)) 
                throw new ILArgumentException("fcomplex: input arrays must have the same size!");
            ILArray<fcomplex> ret = ILMath.tofcomplex(real);
            int nelem = real.Dimensions.NumberOfElements; 
            int baseIdxRet; 
            for (int i = 0; i < nelem; i++) {
                baseIdxRet = real.getBaseIndex(i); 
                ret.m_data[baseIdxRet].imag = imag.GetValue(i); 
            }
            return ret; 
        }

    }
}
