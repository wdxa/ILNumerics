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
using ILNumerics.BuiltInFunctions;
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        TinCls
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source locate="after">
        ToutCls
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILLogicalArray]]></destination>
</type>
<type>
    <source locate="after">
        TindCls
    </source>
    <destination><![CDATA[ILArray<double>]]></destination>
    <destination><![CDATA[ILArray<double>]]></destination>
</type>
<type>
    <source locate="after">
        TinArr
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source locate="after">
        ToutArr
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source locate="after">
        TindArr
    </source>
    <destination>double</destination>
    <destination>double</destination>
</type>
<type>
    <source locate="nextline">
        INIT_VALS
    </source>
    <destination>double result; double curval;</destination>
    <destination>byte result; byte curval;</destination>
</type>
<type>
    <source locate="endregion">
        INIT_COMPLEX
    </source>
    <destination>double curabsval; double curabsmaxval; </destination>
    <destination></destination>
</type>
<type>
    <source locate="endregion">
        #region HYCALPER PRELOOP
    </source>
    <destination>curabsmaxval = double.MaxValue; result = new complex(); </destination>
    <destination>result = byte.MaxValue;</destination>
</type>
<type>
    <source locate="endregion">#region HYCALPER INNERLOOP</source>
    <destination><![CDATA[curabsval = complex.Abs(curval);
                                            if (curabsval < curabsmaxval) {
                                                curabsmaxval = curabsval;
                                                result = curval;
                                            ]]></destination>
    <destination><![CDATA[if (curval < result) {
                                                result = curval;
                                            ]]></destination>
</type>
</hycalper>*/
namespace ILNumerics.BuiltInFunctions  {
	public partial class ILMath {
        #region HYCALPER LOOPSTART R=op(A)
        /// <summary>
        /// Find min value elements along first non singleton dimension
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static /*!HC:ToutCls*/ ILArray<double> min(/*!HC:TinCls*/ ILArray<double> A) {
            if (A.IsScalar)
                return new /*!HC:ToutCls*/ ILArray<double> (A);
            /*!HC:TindCls*/ ILArray<double> dummy = null;  
            return min(A,ref dummy, A.m_dimensions.FirstNonSingleton());
        }
        #endregion HYCALPER LOOPEND R=op(A)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Find min value elements along first non singleton dimension
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static  ILLogicalArray min( ILArray<byte> A) {
            if (A.IsScalar)
                return new  ILLogicalArray (A);
            ILArray<double> dummy = null;  
            return min(A,ref dummy, A.m_dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Find min value elements along first non singleton dimension
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static  ILArray<complex> min( ILArray<complex> A) {
            if (A.IsScalar)
                return new  ILArray<complex> (A);
            ILArray<double> dummy = null;  
            return min(A,ref dummy, A.m_dimensions.FirstNonSingleton());
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART R=op(A, refI, dim)
        /// <summary>
        /// maximum
        /// </summary>
        /// <param name="A">input array, N-dimensional</param>
        /// <param name="I">return value. If this is an instance of an ILArray 
        /// (f.e. 'empty'), on return I will hold the indices into leadDim of  
        /// the maximum values. If, on entering the function, I is null, those indices 
        /// will not be computed and I will be ignored.</param>
        /// <param name="leadDim">index of dimension to operate along</param>
        /// <returns>ILArray of type double. If I was empty  having the dimension 'leadDim' 
        /// reduced to 1 and holding maximum values </returns>
        public static /*!HC:ToutCls*/ ILArray<double> min(/*!HC:TinCls*/ ILArray<double> A, ref /*!HC:TindCls*/ ILArray<double> I, int leadDim) {
			ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            if (leadDim == newDims.Length || inDim[leadDim] == 1)
				// scalar or sum over singleton -> return copy
                return (/*!HC:ToutCls*/ ILArray<double> )A.Clone();

			int newLength;
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
            /*!HC:ToutArr*/ double [] retSystemArr;
            retSystemArr = new /*!HC:ToutArr*/ double [newLength];
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            #region HYCALPER GLOBAL_INIT

            /*!HC:TinArr*/ double result;
            /*!HC:TinArr*/ double curval;
            /*!HC:TindArr*/ double [] indices = null;
            bool createIndices = false; 
            if (!Object.Equals(I,null)) {
                indices = new /*!HC:TindArr*/ double [retSystemArr.Length];
                createIndices = true; 
            } 
            #endregion HYCALPER GLOBAL_INIT
            #region HYCALPER INIT_COMPLEX

            #endregion HYCALPER INIT_COMPLEX

			// physical -> pointer arithmetic
            if (leadDim == 0) {
#region physical along 1st leading dimension
                unsafe {
                    fixed (/*!HC:ToutArr*/ double * pOutArr = retSystemArr)
                    fixed (/*!HC:TinArr*/ double * pInArr = A.m_data)
                    fixed (/*!HC:TindArr*/ double * pIndices = indices) {
                        /*!HC:TinArr*/ double * lastElement; 
                        /*!HC:ToutArr*/ double * tmpOut = pOutArr;
                        /*!HC:TinArr*/ double * tmpIn = pInArr;
                        if (createIndices) {
                            /*!HC:TindArr*/ double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                #region HYCALPER PRELOOP
                                result = /*!HC:LIMITS*/ double.MaxValue;
                                #endregion HYCALPER PRELOOP
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn;
                                    #region HYCALPER INNERLOOP
                                    if (curval < result) {
                                        result = curval;
                                    #endregion HYCALPER INNERLOOP
                                        *tmpInd = (/*!HC:TindArr*/ double )(tmpIn - (lastElement - leadDimLen));
                                    }
                                    tmpIn++; 
                                }
                                *(tmpOut++) = (/*!HC:ToutArr*/ double )result;
                                tmpInd++; 
                            }
                        } else {
                            /*!HC:TindArr*/ double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                #region HYCALPER PRELOOP
                                result = /*!HC:LIMITS*/ double.MaxValue;
                                #endregion HYCALPER PRELOOP
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn++;
                                    #region HYCALPER INNERLOOP
                                    if (curval < result) {
                                        result = curval;
                                    #endregion HYCALPER INNERLOOP
                                    }
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut++) = (/*!HC:ToutArr*/ double )result;
                                #endregion HYCALPER POSTLOOP
                            }
                        }
                    }
                }
#endregion physical along 1st leading dimension
            } else {
#region physical along abitrary dimension
				// sum along abitrary dimension 
                unsafe {
                    fixed (/*!HC:ToutArr*/ double * pOutArr = retSystemArr)
                    fixed (/*!HC:TinArr*/ double * pInArr = A.m_data)
                    fixed (/*!HC:TindArr*/ double * pIndices = indices) {
                        /*!HC:ToutArr*/ double * lastElementOut = newLength + pOutArr - 1;
                        int inLength = inDim.NumberOfElements -1;
                        /*!HC:TinArr*/ double * lastElementIn = pInArr + inLength; 
                        int inc = inDim.SequentialIndexDistance(leadDim);
                        /*!HC:ToutArr*/ double * tmpOut = pOutArr;
                        int outLength = newLength - 1;
                        /*!HC:TinArr*/ double * leadEnd;
                        /*!HC:TinArr*/ double * tmpIn = pInArr;
                        if (createIndices) {
                            /*!HC:TindArr*/ double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                #region HYCALPER PRELOOP
                                result = /*!HC:LIMITS*/ double.MaxValue;
                                #endregion HYCALPER PRELOOP
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    #region HYCALPER INNERLOOP
                                    if (curval < result) {
                                        result = curval;
                                    #endregion HYCALPER INNERLOOP
                                        *tmpInd = (/*!HC:TindArr*/ double )(leadDimLen - (leadEnd - tmpIn) / inc);
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = (/*!HC:ToutArr*/ double ) result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                tmpInd += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                    tmpInd -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        } else {
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                #region HYCALPER PRELOOP
                                result = /*!HC:LIMITS*/ double.MaxValue;
                                #endregion HYCALPER PRELOOP
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    #region HYCALPER INNERLOOP
                                    if (curval < result) {
                                        result = curval;
                                    #endregion HYCALPER INNERLOOP
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = (/*!HC:ToutArr*/ double )result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        }
                    }
				}
#endregion
			}

            if (createIndices) {
                I = new /*!HC:TindCls*/ ILArray<double> (indices, newDims);
            }
            return new /*!HC:ToutCls*/ ILArray<double> (retSystemArr, newDims);  
		}
        #endregion HYCALPER LOOPEND R=op(A,refI,dim)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// maximum
        /// </summary>
        /// <param name="A">input array, N-dimensional</param>
        /// <param name="I">return value. If this is an instance of an ILArray 
        /// (f.e. 'empty'), on return I will hold the indices into leadDim of  
        /// the maximum values. If, on entering the function, I is null, those indices 
        /// will not be computed and I will be ignored.</param>
        /// <param name="leadDim">index of dimension to operate along</param>
        /// <returns>ILArray of type double. If I was empty  having the dimension 'leadDim' 
        /// reduced to 1 and holding maximum values </returns>
        public static  ILLogicalArray min( ILArray<byte> A, ref  ILArray<double> I, int leadDim) {
			ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            if (leadDim == newDims.Length || inDim[leadDim] == 1)
				// scalar or sum over singleton -> return copy
                return ( ILLogicalArray )A.Clone();

			int newLength;
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
            byte [] retSystemArr;
            retSystemArr = new  byte [newLength];
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            #region HYCALPER GLOBAL_INIT

            byte result;
            byte curval;
            double [] indices = null;
            bool createIndices = false; 
            if (!Object.Equals(I,null)) {
                indices = new  double [retSystemArr.Length];
                createIndices = true; 
            } 
            #endregion HYCALPER GLOBAL_INIT
            

			// physical -> pointer arithmetic
            if (leadDim == 0) {
#region physical along 1st leading dimension
                unsafe {
                    fixed ( byte * pOutArr = retSystemArr)
                    fixed ( byte * pInArr = A.m_data)
                    fixed ( double * pIndices = indices) {
                        byte * lastElement; 
                        byte * tmpOut = pOutArr;
                        byte * tmpIn = pInArr;
                        if (createIndices) {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                result = byte.MaxValue;
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn;
                                    if (curval < result) {
                                                result = curval;
                                            
                                        *tmpInd = ( double )(tmpIn - (lastElement - leadDimLen));
                                    }
                                    tmpIn++; 
                                }
                                *(tmpOut++) = ( byte )result;
                                tmpInd++; 
                            }
                        } else {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                result = byte.MaxValue;
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn++;
                                    if (curval < result) {
                                                result = curval;
                                            
                                    }
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut++) = ( byte )result;
                                #endregion HYCALPER POSTLOOP
                            }
                        }
                    }
                }
#endregion physical along 1st leading dimension
            } else {
#region physical along abitrary dimension
				// sum along abitrary dimension 
                unsafe {
                    fixed ( byte * pOutArr = retSystemArr)
                    fixed ( byte * pInArr = A.m_data)
                    fixed ( double * pIndices = indices) {
                        byte * lastElementOut = newLength + pOutArr - 1;
                        int inLength = inDim.NumberOfElements -1;
                        byte * lastElementIn = pInArr + inLength; 
                        int inc = inDim.SequentialIndexDistance(leadDim);
                        byte * tmpOut = pOutArr;
                        int outLength = newLength - 1;
                        byte * leadEnd;
                        byte * tmpIn = pInArr;
                        if (createIndices) {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                result = byte.MaxValue;
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    if (curval < result) {
                                                result = curval;
                                            
                                        *tmpInd = ( double )(leadDimLen - (leadEnd - tmpIn) / inc);
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = ( byte ) result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                tmpInd += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                    tmpInd -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        } else {
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                result = byte.MaxValue;
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    if (curval < result) {
                                                result = curval;
                                            
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = ( byte )result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        }
                    }
				}
#endregion
			}

            if (createIndices) {
                I = new  ILArray<double> (indices, newDims);
            }
            return new  ILLogicalArray (retSystemArr, newDims);  
		}
        /// <summary>
        /// maximum
        /// </summary>
        /// <param name="A">input array, N-dimensional</param>
        /// <param name="I">return value. If this is an instance of an ILArray 
        /// (f.e. 'empty'), on return I will hold the indices into leadDim of  
        /// the maximum values. If, on entering the function, I is null, those indices 
        /// will not be computed and I will be ignored.</param>
        /// <param name="leadDim">index of dimension to operate along</param>
        /// <returns>ILArray of type double. If I was empty  having the dimension 'leadDim' 
        /// reduced to 1 and holding maximum values </returns>
        public static  ILArray<complex> min( ILArray<complex> A, ref  ILArray<double> I, int leadDim) {
			ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            if (leadDim == newDims.Length || inDim[leadDim] == 1)
				// scalar or sum over singleton -> return copy
                return ( ILArray<complex> )A.Clone();

			int newLength;
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
            complex [] retSystemArr;
            retSystemArr = new  complex [newLength];
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            #region HYCALPER GLOBAL_INIT

            complex result;
            complex curval;
            double [] indices = null;
            bool createIndices = false; 
            if (!Object.Equals(I,null)) {
                indices = new  double [retSystemArr.Length];
                createIndices = true; 
            } 
            #endregion HYCALPER GLOBAL_INIT
            double curabsval; double curabsmaxval; 

			// physical -> pointer arithmetic
            if (leadDim == 0) {
#region physical along 1st leading dimension
                unsafe {
                    fixed ( complex * pOutArr = retSystemArr)
                    fixed ( complex * pInArr = A.m_data)
                    fixed ( double * pIndices = indices) {
                        complex * lastElement; 
                        complex * tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        if (createIndices) {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                curabsmaxval = double.MaxValue; result = new complex(); 
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn;
                                    curabsval = complex.Abs(curval);
                                            if (curabsval < curabsmaxval) {
                                                curabsmaxval = curabsval;
                                                result = curval;
                                            
                                        *tmpInd = ( double )(tmpIn - (lastElement - leadDimLen));
                                    }
                                    tmpIn++; 
                                }
                                *(tmpOut++) = ( complex )result;
                                tmpInd++; 
                            }
                        } else {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                lastElement = tmpIn + leadDimLen;
                                curabsmaxval = double.MaxValue; result = new complex(); 
                                while (tmpIn < lastElement) {
                                    curval = *tmpIn++;
                                    curabsval = complex.Abs(curval);
                                            if (curabsval < curabsmaxval) {
                                                curabsmaxval = curabsval;
                                                result = curval;
                                            
                                    }
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut++) = ( complex )result;
                                #endregion HYCALPER POSTLOOP
                            }
                        }
                    }
                }
#endregion physical along 1st leading dimension
            } else {
#region physical along abitrary dimension
				// sum along abitrary dimension 
                unsafe {
                    fixed ( complex * pOutArr = retSystemArr)
                    fixed ( complex * pInArr = A.m_data)
                    fixed ( double * pIndices = indices) {
                        complex * lastElementOut = newLength + pOutArr - 1;
                        int inLength = inDim.NumberOfElements -1;
                        complex * lastElementIn = pInArr + inLength; 
                        int inc = inDim.SequentialIndexDistance(leadDim);
                        complex * tmpOut = pOutArr;
                        int outLength = newLength - 1;
                        complex * leadEnd;
                        complex * tmpIn = pInArr;
                        if (createIndices) {
                            double * tmpInd = pIndices;
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                curabsmaxval = double.MaxValue; result = new complex(); 
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    curabsval = complex.Abs(curval);
                                            if (curabsval < curabsmaxval) {
                                                curabsmaxval = curabsval;
                                                result = curval;
                                            
                                        *tmpInd = ( double )(leadDimLen - (leadEnd - tmpIn) / inc);
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = ( complex ) result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                tmpInd += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                    tmpInd -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        } else {
                            for (int h = nrHigherDims; h-- > 0; ) {
                                leadEnd = tmpIn + leadDimLen * inc;
                                curabsmaxval = double.MaxValue; result = new complex(); 
                                while (tmpIn < leadEnd) {
                                    curval = *tmpIn;
                                    curabsval = complex.Abs(curval);
                                            if (curabsval < curabsmaxval) {
                                                curabsmaxval = curabsval;
                                                result = curval;
                                            
                                    }
                                    tmpIn += inc;
                                }
                                #region HYCALPER POSTLOOP
                                *(tmpOut) = ( complex )result;
                                #endregion HYCALPER POSTLOOP
                                tmpOut += inc;
                                if (tmpOut > lastElementOut) {
                                    tmpOut -= outLength;
                                }
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength);
                            }
                        }
                    }
				}
#endregion
			}

            if (createIndices) {
                I = new  ILArray<double> (indices, newDims);
            }
            return new  ILArray<complex> (retSystemArr, newDims);  
		}

#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// Maximum elements out of both arrays 
        /// </summary>
        /// <param name="inArray1">Input array. may be a scalar</param>
        /// <param name="inArray2">Input array. may be a scalar</param>
        /// <returns>Array of same size as input arrays.</returns>
        /// <remarks>If one of both arrays is scalar, the value will be used 
        /// as second operator for all elements. If both arguments are non scalar arrays, the size 
        /// of both arrays must match. Corresponding elements will be compared than. </remarks>
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>double</destination>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>min</destination>
        <destination>min</destination>
        <destination>min</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILArray<double> (new double[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});]]></destination>
        <destination><![CDATA[return new ILArray<byte> (new byte[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});]]></destination>
        <destination><![CDATA[return new ILArray<complex> (new complex[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute01
        </source>
        <destination><![CDATA[tmpValue2 = B.GetValue(0); *tmpOut = (scalarValue<tmpValue2)?scalarValue:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue2 = B.GetValue(0); *tmpOut = (scalarValue<tmpValue2)?scalarValue:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue2 = B.GetValue(0); *tmpOut = (scalarValue<tmpValue2)?scalarValue:tmpValue2;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute02
        </source>
        <destination><![CDATA[tmpValue2 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue2)? scalarValue:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue2 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue2)? scalarValue:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue2 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue2)? scalarValue:tmpValue2;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute04
        </source>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute05
        </source>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
        <destination><![CDATA[tmpValue1 = *(tmpIn + *leadDimIdx++); *tmpOut = (scalarValue < tmpValue1)? scalarValue:tmpValue1;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
        <destination><![CDATA[{ *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute07
        </source>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < *pInA2)? tmpValue1:*pInA2; pInA2++; ]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < *pInA2)? tmpValue1:*pInA2; pInA2++; ]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < *pInA2)? tmpValue1:*pInA2; pInA2++; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute08
        </source>
        <destination><![CDATA[tmpValue1 = *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)); tmpValue2 = *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)); tmpValue2 = *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2;]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + *(pA1idx0 + r) + *(pA1idx1 + c)); tmpValue2 = *(pInA2+ *(pA2idx0 + r) + *(pA2idx1 + c)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute09
        </source>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c)); tmpValue2 = *(pInA2+B.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2; ]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c)); tmpValue2 = *(pInA2+B.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2; ]]></destination>
        <destination><![CDATA[tmpValue1 = *(pInA1 + A.getBaseIndex(c)); tmpValue2 = *(pInA2+B.getBaseIndex(c++)); *poutarr++ = (tmpValue1 < tmpValue2)?tmpValue1:tmpValue2; ]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute10
        </source>
        <destination><![CDATA[tmpValue2 = *(pInA2 + B.getBaseIndex(c++));*poutarr++ = (*pInA1 < tmpValue2)?*pInA1:tmpValue2; pInA1++;]]></destination>
        <destination><![CDATA[tmpValue2 = *(pInA2 + B.getBaseIndex(c++));*poutarr++ = (*pInA1 < tmpValue2)?*pInA1:tmpValue2; pInA1++;]]></destination>
        <destination><![CDATA[tmpValue2 = *(pInA2 + B.getBaseIndex(c++));*poutarr++ = (*pInA1 < tmpValue2)?*pInA1:tmpValue2; pInA1++;]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}]]></destination>
        <destination><![CDATA[if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}]]></destination>
        <destination><![CDATA[if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}]]></destination>
    </type>
 </hycalper>
 */
        #endregion HYCALPER LOOPEND R=op(A,B)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<complex>  min ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<complex> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILArray<complex> (new complex[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    complex [] retArr =
                        ILMemoryPool.Pool.New< complex > (inDim.NumberOfElements);

                    complex scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( complex * pOutArr = retArr)
                        fixed ( complex * pInArr = B.m_data) {
                            complex * lastElement = pOutArr + retArr.Length;
                            complex * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                        }       
                    }

                    return new  ILArray<complex> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    complex [] retArr = 
                        ILMemoryPool.Pool.New< complex > (A.m_data.Length);

                    complex scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( complex * pOutArr = retArr)
                        fixed ( complex * pInArr = A.m_data) {
                            complex * lastElement = pOutArr + retArr.Length;
                            complex * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                            }
                        }
                    }

                    return new  ILArray<complex> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    complex [] retSystemArr =
                        ILMemoryPool.Pool.New< complex > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( complex * pOutArr = retSystemArr)
                        fixed ( complex * inA1 = A.m_data) 
                        fixed ( complex * inA2 = B.m_data) {
                            complex * pInA1 = inA1; 
                            complex * pInA2 = inA2;
                            complex * poutarr = pOutArr;
                            complex * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}
                            }
                        }
                    }

                    return new  ILArray<complex> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<byte>  min ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<byte> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILArray<byte> (new byte[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    byte [] retArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    byte scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = B.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                        }       
                    }

                    return new  ILArray<byte> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    byte [] retArr = 
                        ILMemoryPool.Pool.New< byte > (A.m_data.Length);

                    byte scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( byte * pOutArr = retArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement = pOutArr + retArr.Length;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                            }
                        }
                    }

                    return new  ILArray<byte> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    byte [] retSystemArr =
                        ILMemoryPool.Pool.New< byte > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( byte * pOutArr = retSystemArr)
                        fixed ( byte * inA1 = A.m_data) 
                        fixed ( byte * inA2 = B.m_data) {
                            byte * pInA1 = inA1; 
                            byte * pInA2 = inA2;
                            byte * poutarr = pOutArr;
                            byte * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}
                            }
                        }
                    }

                    return new  ILArray<byte> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<double>  min ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILArray<double> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<double> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILArray<double> (new double[1]{(A.GetValue(0) < B.GetValue(0))?A.GetValue(0):B.GetValue(0)});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    double [] retArr =
                        ILMemoryPool.Pool.New< double > (inDim.NumberOfElements);

                    double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed ( double * pOutArr = retArr)
                        fixed ( double * pInArr = B.m_data) {
                            double * lastElement = pOutArr + retArr.Length;
                            double * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                        }       
                    }

                    return new  ILArray<double> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    double [] retArr = 
                        ILMemoryPool.Pool.New< double > (A.m_data.Length);

                    double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed ( double * pOutArr = retArr)
                        fixed ( double * pInArr = A.m_data) {
                            double * lastElement = pOutArr + retArr.Length;
                            double * tmpOut = pOutArr;
                            double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                { *tmpOut++ = (scalarValue < *tmpIn)? scalarValue: *tmpIn; tmpIn++; }
                            }
                        }
                    }

                    return new  ILArray<double> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    double [] retSystemArr =
                        ILMemoryPool.Pool.New< double > (inDim.NumberOfElements);

                    unsafe {
                        fixed ( double * pOutArr = retSystemArr)
                        fixed ( double * inA1 = A.m_data) 
                        fixed ( double * inA2 = B.m_data) {
                            double * pInA1 = inA1; 
                            double * pInA2 = inA2;
                            double * poutarr = pOutArr;
                            double * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                if (*pInA1< *pInA2) { *poutarr++ = *pInA1++; pInA2++;} else {*poutarr++ = *pInA2++; pInA1++;}
                            }
                        }
                    }

                    return new  ILArray<double> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
namespace ILNumerics.Untyped {

    public sealed partial class ILUntype {
        /// <summary>
        /// maximum
        /// </summary>
        /// <param name="inParameter"> system.Array of ILBaseArray's. The number of elements 
        /// in inParams specifies the mode of min: 
        /// <list type="bullet">
        /// <item> 1:  Single array element. the function will give the maximum of elements 
        /// along the first non singleton dimension. If the length of outParamter is 2, the
        /// indices of the elements with maximum values found is given back as second return 
        /// value. [Matlab: [i,y] = min(A)]</item>
        /// <item> 2: first element: input Array. Second element: second input array. Either 
        /// one may be a scalar. the function gives back the maximum value of corresponding 
        /// elements of both input arrays as single otuput parameter. [Matlab: y = min(A,B)]</item>
        /// <item> 3: first element: input array. second element will be ignored, third element 
        /// will specify the dimension to operate along. If the length of outParameter specified 
        /// is 2, the indices of maximum elements into the operation dimension will be given back 
        /// also. [MAtlab: [y,i] = min(A,[],d)]</item>
        /// </list>  
        /// </param>
        /// <param name="outParameter">[output] return maximum value as requested. If the number of outParameter
        /// equals 2 on entry, the indices of corresponding maximum valued elements are returned also.</param>
        /// <remarks>Following types are supported: /*!HC:ENUM:TinCls:*/ <![CDATA[ ILArray<complex>, ILArray<byte>]]> /*!HC:/ENUM*/.
        /// The dimension specifier may be any positive (including 0) scalar value inside ILArray 
        /// of type double or int or float. 
        /// The length of outParameter specifies the number of values returned. 
        /// The initial content of outParameter argument will be destroyed on return. </remarks>
        public static void min(ref ILBaseArray[] outParameter, params ILBaseArray[] inParameter) {
            try {
                switch (inParameter.Length) {
                    case 0:
                        throw new ILArgumentTypeException("min: to less arguments supplied!");
                    case 1:
                        switch (outParameter.Length) {
                            case 0:
                            case 1:
                                // y = min(A)
                                if (false) {
                                }
                                #region HYCALPER LOOPSTART
                                else if (inParameter[0] is /*!HC:TinCls*/ ILArray<double> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min((/*!HC:TinCls*/ ILArray<double> )inParameter[0]);
                                    return;
                                }
                                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                                else if (inParameter[0] is  ILArray<byte> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<byte> )inParameter[0]);
                                    return;
                                }
                                else if (inParameter[0] is  ILArray<complex> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<complex> )inParameter[0]);
                                    return;
                                }

#endregion HYCALPER AUTO GENERATED CODE
                                else {
                                    throw new ILArgumentTypeException("min is not supported for arguments of type " + inParameter[0].GetType().Name); 
                                }
                            case 2:
                                // [y,i] = min(A)
                                if (false) {
                                #region HYCALPER LOOPSTART
                                } else if (inParameter[0] is /*!HC:TinCls*/ ILArray<double> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    outParameter[0] = BuiltInFunctions.ILMath.min((/*!HC:TinCls*/ ILArray<double> )inParameter[0], ref I, -1);
                                    outParameter[1] = I;
                                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                                } else if (inParameter[0] is  ILArray<byte> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<byte> )inParameter[0], ref I, -1);
                                    outParameter[1] = I;
                                } else if (inParameter[0] is  ILArray<complex> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<complex> )inParameter[0], ref I, -1);
                                    outParameter[1] = I;

#endregion HYCALPER AUTO GENERATED CODE
                                } else {
                                    throw new ILArgumentTypeException("min(A) is not supported for A of type " + inParameter[0].GetType().Name); 
                                }
                                break;
                            default:
                                throw new ILArgumentNumberException("min: too many output parameter requested for min(A)!");
                        }
                        break;
                    case 2:
                        switch (outParameter.Length) {
                            case 0:
                            case 1:
                                // y = min(A,B)
                                if (false) {
                                #region HYCALPER LOOPSTART
                                } else if (inParameter[0] is /*!HC:TinCls*/ ILArray<double> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min((/*!HC:TinCls*/ ILArray<double> )inParameter[0], (/*!HC:TinCls*/ ILArray<double> )inParameter[1]);
                                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                                } else if (inParameter[0] is  ILArray<byte> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<byte> )inParameter[0], ( ILArray<byte> )inParameter[1]);
                                } else if (inParameter[0] is  ILArray<complex> ) {
                                    outParameter = new ILBaseArray[1];
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<complex> )inParameter[0], ( ILArray<complex> )inParameter[1]);

#endregion HYCALPER AUTO GENERATED CODE
                                } else {
                                    throw new ILArgumentTypeException("min is not supported for input array of type " + inParameter[0].GetType().Name);
                                }
                                break;
                            default:
                                throw new ILArgumentNumberException("min: too many output parameter requested for min(A,B)!");
                        }
                        break;
                    case 3:
                        switch (outParameter.Length) {
                            case 0:
                            case 1:
                                // y = min(A,[],dim)
                                if (false) {
                                #region HYCALPER LOOPSTART
                                } else if (inParameter[0] is /*!HC:TinCls*/ ILArray<double> ) {
                                    ILArray<double> I = null;
                                    outParameter = new ILBaseArray[1];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double> )inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min((/*!HC:TinCls*/ ILArray<double> )inParameter[0], ref I, dimension);
                                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                                } else if (inParameter[0] is  ILArray<byte> ) {
                                    ILArray<double> I = null;
                                    outParameter = new ILBaseArray[1];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double> )inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<byte> )inParameter[0], ref I, dimension);
                                } else if (inParameter[0] is  ILArray<complex> ) {
                                    ILArray<double> I = null;
                                    outParameter = new ILBaseArray[1];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double> )inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<complex> )inParameter[0], ref I, dimension);

#endregion HYCALPER AUTO GENERATED CODE
                                } else {
                                    throw new ILArgumentTypeException("min is not supported for input array of type " + inParameter[0].GetType().Name);
                                }
                                break;
                            case 2:
                                // [y,i] = min(A,[],dim)
                                if (false) {
                                #region HYCALPER LOOPSTART
                                } else if (inParameter[0] is /*!HC:TinCls*/ ILArray<double> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double>)inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min((/*!HC:TinCls*/ ILArray<double> )inParameter[0], ref I, dimension);
                                    outParameter[1] = I;
                                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                                } else if (inParameter[0] is  ILArray<byte> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double>)inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<byte> )inParameter[0], ref I, dimension);
                                    outParameter[1] = I;
                                } else if (inParameter[0] is  ILArray<complex> ) {
                                    ILArray<double> I = ILArray<double>.empty(0,0);
                                    outParameter = new ILBaseArray[2];
                                    if (!inParameter[2].IsScalar)
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    int dimension = 0;
                                    try {
                                        dimension = (int)(((ILArray<double>)inParameter[2])[0, 0]);
                                    } catch (Exception) {
                                        throw new ILArgumentSizeException("min: dimension argument must be positive, scalar double array!");
                                    }
                                    outParameter[0] = BuiltInFunctions.ILMath.min(( ILArray<complex> )inParameter[0], ref I, dimension);
                                    outParameter[1] = I;

#endregion HYCALPER AUTO GENERATED CODE
                                } else {
                                    throw new ILArgumentTypeException("min is not supported for input array of type " + inParameter[0].GetType().Name);
                                }
                                break;
                            default:
                                throw new ILArgumentNumberException("min: wrong number of output parameter requested for min(A,B) !");
                        }
                        break;
                    default:
                        throw new ILArgumentNumberException("min: too many input arguments! ");
                }
            } catch (Exception e) {
                throw new ILException("min: could not complete operation: " + e.Message); 
            }

        }
    }
}

