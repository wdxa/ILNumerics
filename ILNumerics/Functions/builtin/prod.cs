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

namespace ILNumerics.BuiltInFunctions  {
	public partial class ILMath {
        /// <summary>
        /// multiply and fold array elements along first non singleton dimension
        /// </summary>
        /// <param name="inArray">N-dimensional double array</param>
        /// <returns>array having the first non singleton dimension 
		/// reduced to the length 1 with the result of the products of 
		/// corresponding elements of inArray in that dimension.
		/// The result will have the same number of dimensions as 
		/// inArray, but the first non singleton dimension having the 
		/// size 1.</returns>
		public static ILArray<double> prod(ILArray<double> inArray) {
            int[] newDims = inArray.Dimensions.ToIntArray();
            int nsDim = 0;
            while (nsDim < newDims.Length && newDims[nsDim] < 2)
                nsDim++;
            if (nsDim == newDims.Length)
                // scalar -> return copy
                return (ILArray<double>)inArray.Clone();
            return prod(inArray, nsDim);
        }
		/// <summary>
		/// Multiply elements of inArray along specified dimension.
		/// </summary>
		/// <param name="inArray">N-dimensional double array</param>
		/// <param name="leadDim">index of dimension to multiply elements along</param>
		/// <returns>array having the 'leadDim's dimension 
		/// reduced to the length of 1 with the result of the product of 
		/// corresponding elements of inArray of that dimension.</returns>
        public static ILArray<double> prod(ILArray<double> inArray, int leadDim) {
			ILDimension inDim = inArray.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            if (leadDim == newDims.Length || inDim[leadDim] == 1)
				// scalar or sum over singleton -> return copy
                return (ILArray<double>)inArray.Clone();

            int newLength;
			double[] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New<double>(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (inArray.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (inArray.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = inArray.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* lastElementOut = tmpOut + retDblArr.Length;
								double* tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 1.0; 
									while (leadDimIdx <= leadDimEnd)
										*tmpOut *= *(tmpIn + *leadDimIdx++);
									tmpOut++;
								}
							}
						}
					} 
#endregion
				} else if (inArray.IsVector) {
#region Vector
					////////////////////////////   VECTOR   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = inArray.m_indexOffset;
						int[] curPosition = new int[2];
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								// start at first element
                                *tmpOut = 1.0; 
                                while (leadDimIdx < leadDimEnd)
									*tmpOut *= *(tmpIn + *leadDimIdx++);
							}
						}
					}
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = inArray.m_indexOffset;
						int[] curPosition = new int[inArray.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* lastElementOut = tmpOut + retDblArr.Length;
								double* tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
                                while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 1.0; 
                                    while (leadDimIdx < leadDimEnd)
										*tmpOut *= *(tmpIn + *leadDimIdx++);
									tmpOut++;
									// increment higher dimensions 
									d = 1;
									while (d < dimLen) {
										curD = (d + leadDim) % dimLen;
										tmpIn -= idxOffset[curD, curPosition[curD]];
										curPosition[curD]++;
										if (curPosition[curD] < idxOffset[curD].Length) {
											tmpIn += idxOffset[curD, curPosition[curD]];
											break;
										}
										curPosition[curD] = 0;
										tmpIn += idxOffset[curD, curPosition[curD]];
										d++;
									}
								}
							}
						}
					}
#endregion
				}
				// ==============================================================
#endregion
			} else {
				// physical -> pointer arithmetic
                if (leadDim == 0) {
#region physical along 1st leading dimension
                    unsafe {
                        fixed (double* pOutArr = retDblArr,
                                pInArr = inArray.m_data) {
                            double* lastElement;
                            double* tmpOut = pOutArr;
                            double* tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 1.0;
                                while (tmpIn < lastElement) {
                                    *tmpOut *= *tmpIn++;
                                }
                                tmpOut++;
                            }
                        }
					}
#endregion
				} else {
#region physical along abitrary dimension
					// sum along abitrary dimension 
                    unsafe {
                        fixed (double* pOutArr = retDblArr,
                                pInArr = inArray.m_data) {
                            double* lastElementOut = newLength + pOutArr -1;
                            int inLength = inDim.NumberOfElements -1; 
                            double* lastElementIn = pInArr + inLength; 
                            int inc = inDim.SequentialIndexDistance(leadDim); 
                            double* tmpOut = pOutArr;
                            int outLength = newLength - 1;
                            double* leadEnd; 
                            double* tmpIn = pInArr;
                            for (int h = nrHigherDims; h--> 0; ) {
								leadEnd = tmpIn + leadDimLen * inc;
                                *tmpOut = 1.0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut *= *tmpIn;
                                    tmpIn += inc; 
                                }
                                tmpOut  += inc;
                                if (tmpOut > lastElementOut)
                                    tmpOut = pOutArr + ((tmpOut - pOutArr) - outLength);
                                if (tmpIn > lastElementIn)
                                    tmpIn = pInArr + ((tmpIn - pInArr) - inLength); 
                            }
                        }
					}
#endregion
				}
			}
			return new ILArray<double>(retDblArr, newDims);;  
		}
	}
}
