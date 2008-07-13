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
    <source>
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
</type>
<type>
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
</type>
<type>
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
    <destination>fcomplex</destination>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source>
        outArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
    <destination>fcomplex</destination>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions  {
	public partial class ILMath {
        #region HYCALPER LOOPSTART 
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static /*!HC:outCls1*/ ILArray<double> diff(/*!HC:inCls1*/ ILArray<double> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return /*!HC:outCls1*/ ILArray<double> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static /*!HC:outCls1*/ ILArray<double> diff(/*!HC:inCls1*/ ILArray<double> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return /*!HC:outCls1*/ ILArray<double> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return /*!HC:outCls1*/ ILArray<double> .empty(); 
            }
            /*!HC:outCls1*/ ILArray<double> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static /*!HC:outCls1*/ ILArray<double> diff(int leadDim, /*!HC:inCls1*/ ILArray<double> A) {
            if (A.IsEmpty || A.IsScalar) return /*!HC:outCls1*/ ILArray<double> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            /*!HC:outCls1*/ ILArray<double> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            /*!HC:singletonDimOp*/
            if (inDim[leadDim] == 1) return /*!HC:outCls1*/ ILArray<double> .empty();
			int newLength;
			/*!HC:outArr1*/ double [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New</*!HC:outArr1*/ double >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            /*!HC:inArr1*/ double firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
						fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
							/*!HC:outArr1*/ double * tmpOut = pOutArr;
							/*!HC:outArr1*/ double * lastElementOut = tmpOut + retDblArr.Length - 1;
							/*!HC:inArr1*/ double * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                /*!HC:HCzero*/ 
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = (/*!HC:inArr1*/ double )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                        fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                            /*!HC:inArr1*/ double * lastElement;
                            /*!HC:outArr1*/ double * tmpOut = pOutArr;
                            /*!HC:inArr1*/ double * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                /*!HC:HCzero*/ 
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = (/*!HC:inArr1*/ double )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                        fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                            /*!HC:outArr1*/ double * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            /*!HC:inArr1*/ double * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            /*!HC:outArr1*/ double * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            /*!HC:inArr1*/ double * leadEnd; 
                            /*!HC:inArr1*/ double * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = (/*!HC:inArr1*/ double )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new /*!HC:outCls1*/ ILArray<double> (retDblArr, newDimension);;
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<UInt64> diff( ILArray<UInt64> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<UInt64> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<UInt64> diff( ILArray<UInt64> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<UInt64> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<UInt64> .empty(); 
            }
            ILArray<UInt64> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<UInt64> diff(int leadDim,  ILArray<UInt64> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<UInt64> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<UInt64> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<UInt64> .empty();
			int newLength;
			 UInt64 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< UInt64 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            UInt64 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( UInt64 * pOutArr = retDblArr)
						fixed ( UInt64 * pInArr = A.m_data) {
							 UInt64 * tmpOut = pOutArr;
							 UInt64 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 UInt64 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( UInt64 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( UInt64 * pOutArr = retDblArr)
                        fixed ( UInt64 * pInArr = A.m_data) {
                            UInt64 * lastElement;
                            UInt64 * tmpOut = pOutArr;
                            UInt64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( UInt64 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( UInt64 * pOutArr = retDblArr)
                        fixed ( UInt64 * pInArr = A.m_data) {
                            UInt64 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            UInt64 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            UInt64 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            UInt64 * leadEnd; 
                            UInt64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( UInt64 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<UInt64> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<UInt32> diff( ILArray<UInt32> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<UInt32> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<UInt32> diff( ILArray<UInt32> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<UInt32> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<UInt32> .empty(); 
            }
            ILArray<UInt32> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<UInt32> diff(int leadDim,  ILArray<UInt32> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<UInt32> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<UInt32> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<UInt32> .empty();
			int newLength;
			 UInt32 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< UInt32 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            UInt32 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( UInt32 * pOutArr = retDblArr)
						fixed ( UInt32 * pInArr = A.m_data) {
							 UInt32 * tmpOut = pOutArr;
							 UInt32 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 UInt32 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( UInt32 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( UInt32 * pOutArr = retDblArr)
                        fixed ( UInt32 * pInArr = A.m_data) {
                            UInt32 * lastElement;
                            UInt32 * tmpOut = pOutArr;
                            UInt32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( UInt32 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( UInt32 * pOutArr = retDblArr)
                        fixed ( UInt32 * pInArr = A.m_data) {
                            UInt32 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            UInt32 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            UInt32 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            UInt32 * leadEnd; 
                            UInt32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( UInt32 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<UInt32> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<UInt16> diff( ILArray<UInt16> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<UInt16> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<UInt16> diff( ILArray<UInt16> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<UInt16> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<UInt16> .empty(); 
            }
            ILArray<UInt16> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<UInt16> diff(int leadDim,  ILArray<UInt16> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<UInt16> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<UInt16> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<UInt16> .empty();
			int newLength;
			 UInt16 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< UInt16 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            UInt16 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( UInt16 * pOutArr = retDblArr)
						fixed ( UInt16 * pInArr = A.m_data) {
							 UInt16 * tmpOut = pOutArr;
							 UInt16 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 UInt16 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( UInt16 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( UInt16 * pOutArr = retDblArr)
                        fixed ( UInt16 * pInArr = A.m_data) {
                            UInt16 * lastElement;
                            UInt16 * tmpOut = pOutArr;
                            UInt16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( UInt16 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( UInt16 * pOutArr = retDblArr)
                        fixed ( UInt16 * pInArr = A.m_data) {
                            UInt16 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            UInt16 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            UInt16 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            UInt16 * leadEnd; 
                            UInt16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( UInt16 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<UInt16> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<Int64> diff( ILArray<Int64> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<Int64> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<Int64> diff( ILArray<Int64> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<Int64> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<Int64> .empty(); 
            }
            ILArray<Int64> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<Int64> diff(int leadDim,  ILArray<Int64> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<Int64> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<Int64> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<Int64> .empty();
			int newLength;
			 Int64 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< Int64 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            Int64 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( Int64 * pOutArr = retDblArr)
						fixed ( Int64 * pInArr = A.m_data) {
							 Int64 * tmpOut = pOutArr;
							 Int64 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 Int64 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( Int64 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( Int64 * pOutArr = retDblArr)
                        fixed ( Int64 * pInArr = A.m_data) {
                            Int64 * lastElement;
                            Int64 * tmpOut = pOutArr;
                            Int64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( Int64 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( Int64 * pOutArr = retDblArr)
                        fixed ( Int64 * pInArr = A.m_data) {
                            Int64 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            Int64 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            Int64 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            Int64 * leadEnd; 
                            Int64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( Int64 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<Int64> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<Int32> diff( ILArray<Int32> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<Int32> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<Int32> diff( ILArray<Int32> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<Int32> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<Int32> .empty(); 
            }
            ILArray<Int32> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<Int32> diff(int leadDim,  ILArray<Int32> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<Int32> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<Int32> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<Int32> .empty();
			int newLength;
			 Int32 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< Int32 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            Int32 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( Int32 * pOutArr = retDblArr)
						fixed ( Int32 * pInArr = A.m_data) {
							 Int32 * tmpOut = pOutArr;
							 Int32 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 Int32 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( Int32 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( Int32 * pOutArr = retDblArr)
                        fixed ( Int32 * pInArr = A.m_data) {
                            Int32 * lastElement;
                            Int32 * tmpOut = pOutArr;
                            Int32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( Int32 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( Int32 * pOutArr = retDblArr)
                        fixed ( Int32 * pInArr = A.m_data) {
                            Int32 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            Int32 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            Int32 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            Int32 * leadEnd; 
                            Int32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( Int32 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<Int32> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<Int16> diff( ILArray<Int16> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<Int16> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<Int16> diff( ILArray<Int16> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<Int16> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<Int16> .empty(); 
            }
            ILArray<Int16> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<Int16> diff(int leadDim,  ILArray<Int16> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<Int16> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<Int16> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<Int16> .empty();
			int newLength;
			 Int16 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< Int16 >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            Int16 firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( Int16 * pOutArr = retDblArr)
						fixed ( Int16 * pInArr = A.m_data) {
							 Int16 * tmpOut = pOutArr;
							 Int16 * lastElementOut = tmpOut + retDblArr.Length - 1;
							 Int16 * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( Int16 )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( Int16 * pOutArr = retDblArr)
                        fixed ( Int16 * pInArr = A.m_data) {
                            Int16 * lastElement;
                            Int16 * tmpOut = pOutArr;
                            Int16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( Int16 )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( Int16 * pOutArr = retDblArr)
                        fixed ( Int16 * pInArr = A.m_data) {
                            Int16 * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            Int16 * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            Int16 * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            Int16 * leadEnd; 
                            Int16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( Int16 )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<Int16> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<char> diff( ILArray<char> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<char> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<char> diff( ILArray<char> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<char> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<char> .empty(); 
            }
            ILArray<char> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<char> diff(int leadDim,  ILArray<char> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<char> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<char> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<char> .empty();
			int newLength;
			 char [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< char >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            char firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( char * pOutArr = retDblArr)
						fixed ( char * pInArr = A.m_data) {
							 char * tmpOut = pOutArr;
							 char * lastElementOut = tmpOut + retDblArr.Length - 1;
							 char * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( char )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( char * pOutArr = retDblArr)
                        fixed ( char * pInArr = A.m_data) {
                            char * lastElement;
                            char * tmpOut = pOutArr;
                            char * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( char )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( char * pOutArr = retDblArr)
                        fixed ( char * pInArr = A.m_data) {
                            char * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            char * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            char * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            char * leadEnd; 
                            char * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( char )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<char> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<byte> diff( ILArray<byte> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<byte> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<byte> diff( ILArray<byte> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<byte> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<byte> .empty(); 
            }
            ILArray<byte> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<byte> diff(int leadDim,  ILArray<byte> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<byte> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<byte> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<byte> .empty();
			int newLength;
			 byte [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< byte >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            byte firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( byte * pOutArr = retDblArr)
						fixed ( byte * pInArr = A.m_data) {
							 byte * tmpOut = pOutArr;
							 byte * lastElementOut = tmpOut + retDblArr.Length - 1;
							 byte * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( byte )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( byte * pOutArr = retDblArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( byte )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( byte * pOutArr = retDblArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            byte * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            byte * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            byte * leadEnd; 
                            byte * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( byte )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<byte> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<fcomplex> diff( ILArray<fcomplex> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<fcomplex> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<fcomplex> diff( ILArray<fcomplex> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<fcomplex> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<fcomplex> .empty(); 
            }
            ILArray<fcomplex> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<fcomplex> diff(int leadDim,  ILArray<fcomplex> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<fcomplex> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<fcomplex> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<fcomplex> .empty();
			int newLength;
			 fcomplex [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< fcomplex >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            fcomplex firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( fcomplex * pOutArr = retDblArr)
						fixed ( fcomplex * pInArr = A.m_data) {
							 fcomplex * tmpOut = pOutArr;
							 fcomplex * lastElementOut = tmpOut + retDblArr.Length - 1;
							 fcomplex * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( fcomplex )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( fcomplex * pOutArr = retDblArr)
                        fixed ( fcomplex * pInArr = A.m_data) {
                            fcomplex * lastElement;
                            fcomplex * tmpOut = pOutArr;
                            fcomplex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( fcomplex )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( fcomplex * pOutArr = retDblArr)
                        fixed ( fcomplex * pInArr = A.m_data) {
                            fcomplex * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            fcomplex * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            fcomplex * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            fcomplex * leadEnd; 
                            fcomplex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( fcomplex )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<fcomplex> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<float> diff( ILArray<float> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<float> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<float> diff( ILArray<float> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<float> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<float> .empty(); 
            }
            ILArray<float> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<float> diff(int leadDim,  ILArray<float> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<float> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<float> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<float> .empty();
			int newLength;
			 float [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< float >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            float firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( float * pOutArr = retDblArr)
						fixed ( float * pInArr = A.m_data) {
							 float * tmpOut = pOutArr;
							 float * lastElementOut = tmpOut + retDblArr.Length - 1;
							 float * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( float )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( float * pOutArr = retDblArr)
                        fixed ( float * pInArr = A.m_data) {
                            float * lastElement;
                            float * tmpOut = pOutArr;
                            float * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( float )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( float * pOutArr = retDblArr)
                        fixed ( float * pInArr = A.m_data) {
                            float * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            float * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            float * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            float * leadEnd; 
                            float * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( float )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<float> (retDblArr, newDimension);;
        }
        /// <summary>
        /// numeric derivative and differences 
        /// </summary>
        /// <param name="A">N-dimensional array</param>
        /// <returns>derivative of elements along first non singleton dimension</returns>
        /// <remarks>The array returned will: 
        /// <list type="bullte">
        /// <item>have the same inner type as A,</item>
        /// <item>be of the same size as A, but the first non singleton dimension decreased by 1.</item>
        /// </list>
        /// <para>For A beeing scalar or empty, an empty result will be returned.</para></remarks>
        public static  ILArray<complex> diff( ILArray<complex> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<complex> .empty(); 
            return diff(A,1,fnsd); 
        }
        /// <summary>
        /// Nth - derivative along specified dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimension to create derivative along</param>
        /// <param name="N">degree of derivates</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        /// <remarks>N must be a number in range 1..L, where L is the length of A.Dimensions[leadDim]. 
        /// Otherwise an empty array will be returned.
        /// <para>If A is empty or scalar, or if N exceeds the length the specified dimension of A, 
        /// an empty array will be returned.</para></remarks>
        public static  ILArray<complex> diff( ILArray<complex> A, int N, int leadDim) {
            if (A.IsEmpty || A.IsScalar) 
                return  ILArray<complex> .empty(); 
            if (leadDim < 0 || leadDim >= A.Dimensions.NumberOfDimensions) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (N == 0) 
                return A.R; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<complex> .empty(); 
            }
            ILArray<complex> ret = A; 
            for (int n = 0; n < N; n++) {
                ret = diff(leadDim,ret);      
            }
            return ret; 
        }
        /// <summary>
        /// First derivative along specific dimension
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="leadDim">dimensions to create derivative along</param>
        /// <returns>array with first derivative of A along dimension <code>lieadDim</code></returns>
        private static  ILArray<complex> diff(int leadDim,  ILArray<complex> A) {
            if (A.IsEmpty || A.IsScalar) return  ILArray<complex> .empty(); 
            if (leadDim >= A.Dimensions.NumberOfDimensions || leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            ILArray<complex> ret; 
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<complex> .empty();
			int newLength;
			 complex [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] --;
            newLength = newLength * newDims[leadDim];
			retDblArr = ILMemoryPool.Pool.New< complex >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            complex firstVal, secVal; 
			if (A.IsVector) 
                return A["1:end"] - A[vector(0,A.Length-2)];     
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE Storage ===========
				/////////////////////////////   ARBITRARY DIMENSIONS //////////
				unsafe {
					ILIndexOffset idxOffset = A.m_indexOffset;
					int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
					fixed (int* leadDimStart = idxOffset[leadDim]) {
						fixed ( complex * pOutArr = retDblArr)
						fixed ( complex * pInArr = A.m_data) {
							 complex * tmpOut = pOutArr;
							 complex * lastElementOut = tmpOut + retDblArr.Length - 1;
							 complex * tmpIn = pInArr + A.m_indexOffset.Map(0);
							int* leadDimIdx = leadDimStart;
							int* leadDimEnd = leadDimStart + leadDimLen;
							int dimLen = curPosition.Length;
							int d, curD, posCounter = A.Dimensions.NumberOfElements / leadDimLen;
							// start at first element
							while (posCounter --> 0) {
								leadDimIdx = leadDimStart;
                                
                                firstVal = *(tmpIn + *leadDimIdx++); 
								while (leadDimIdx < leadDimEnd) {
									secVal = *(tmpIn + *leadDimIdx++);
                                    *tmpOut = ( complex )(secVal - firstVal); 
                                    tmpOut += incOut;
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut) 
                                    tmpOut -= (retDblArr.Length - 1); 
								// increment higher dimensions 
								d = 1;
								while (d < dimLen) {
									curD = (d + leadDim) % dimLen;
									curPosition[curD]++;
									if (curPosition[curD] < idxOffset[curD].Length) {
										break;
									}
									curPosition[curD] = 0;
									d++;
								}
                                tmpIn = pInArr + A.m_indexOffset.IndexFromArray(curPosition); 
							}
						}
					}
			    }
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed ( complex * pOutArr = retDblArr)
                        fixed ( complex * pInArr = A.m_data) {
                            complex * lastElement;
                            complex * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                
                                firstVal = *tmpIn++;
                                while (tmpIn < lastElement) {
                                    secVal = *tmpIn++;
                                    *(tmpOut++) = ( complex )(secVal-firstVal);
                                    firstVal = secVal; 
                                }
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed ( complex * pOutArr = retDblArr)
                        fixed ( complex * pInArr = A.m_data) {
                            complex * lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            complex * lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            complex * tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            complex * leadEnd; 
                            complex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                firstVal = *tmpIn; 
                                tmpIn += inc; 
                                while (tmpIn < leadEnd) {
                                    secVal = *tmpIn; 
                                    *tmpOut = ( complex )(secVal - firstVal);
                                    tmpIn += inc;
                                    tmpOut += incOut; 
                                    firstVal = secVal; 
                                }
                                if (tmpOut > lastElementOut)
                                    tmpOut -= outLength;
                                if (tmpIn > lastElementIn)
                                    tmpIn -= inLength; 
                            }
                        }
					}
#endregion
				}
			}
			return new  ILArray<complex> (retDblArr, newDimension);;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
