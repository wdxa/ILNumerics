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
        inArr2
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
<type>
    <source>
        preEvalOp
    </source>
    <destination>(complex)</destination>
    <destination>(float)</destination>
    <destination>(fcomplex)</destination>
    <destination>(byte)</destination>
    <destination>(char)</destination>
    <destination>(Int16)</destination>
    <destination>(Int32)</destination>
    <destination>(Int64)</destination>
    <destination>(UInt16)</destination>
    <destination>(UInt32)</destination>
    <destination>(UInt64)</destination>
</type>
<type>
    <source locate="nextline">
        HCzero
    </source>
    <destination>*tmpOut = 0.0;</destination>
    <destination>*tmpOut = 0.0f;</destination>
    <destination>*tmpOut = 0.0f;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = (char)0;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = 0;</destination>
    <destination>*tmpOut = 0;</destination>
</type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions  {
	public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_ACCU_TEMPLATE1
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static /*!HC:outCls1*/ ILArray<double> /*!HC:funcname*/ sum (/*!HC:inCls1*/ ILArray<double> A) {
            return /*!HC:funcname*/ sum (A, A.Dimensions.FirstNonSingleton());
        }
        #endregion HYCALPER LOOPEND UNARY_ACCU_TEMPLATE1
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<UInt64>  sum ( ILArray<UInt64> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<UInt32>  sum ( ILArray<UInt32> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<UInt16>  sum ( ILArray<UInt16> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<Int64>  sum ( ILArray<Int64> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<Int32>  sum ( ILArray<Int32> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<Int16>  sum ( ILArray<Int16> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<char>  sum ( ILArray<char> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<byte>  sum ( ILArray<byte> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<fcomplex>  sum ( ILArray<fcomplex> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<float>  sum ( ILArray<float> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>
        /// Sum array elements along first non singleton dimension
        /// </summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array having the first non singleton dimension 
		/// reduced to the length 1 with the sum of 
		/// all elements along that dimension.</para>
		/// <para>The result will have the same number of dimensions as 
		/// A, but the first non singleton dimension will have the 
		/// size 1.</para></returns>
		public static  ILArray<complex>  sum ( ILArray<complex> A) {
            return  sum (A, A.Dimensions.FirstNonSingleton());
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART UNARY_ACCU_TEMPLATE2
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static /*!HC:outCls1*/ ILArray<double> /*!HC:funcname*/ sum (/*!HC:inCls1*/ ILArray<double> A, int leadDim) {
            if (A.IsEmpty) 
                return /*!HC:outCls1*/ ILArray<double> .empty(); 
            if (A.IsScalar)
                /*!HC:HCscalarOp*/
                return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:inArr1*/ double []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            /*!HC:singletonDimOp*/
            if (inDim[leadDim] == 1) return (/*!HC:outCls1*/ ILArray<double> )A.Clone();
			int newLength;
			/*!HC:outArr1*/ double [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New</*!HC:outArr1*/ double >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
						    fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
								/*!HC:outArr1*/ double * tmpOut = pOutArr;
								/*!HC:outArr1*/ double * lastElementOut = tmpOut + retDblArr.Length;
								/*!HC:inArr1*/ double * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    /*!HC:HCzero*/ 
                                    *tmpOut = 0.0; 
									while (leadDimIdx <= leadDimEnd)
										/*!HC:tmpOutStorage*/ *tmpOut += /*!HC:preEvalOp*/ (double) (*(tmpIn + *leadDimIdx++)) /*!HC:postEvalOp*/ ;
									/*!HC:operationResult*/ 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
							fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
								/*!HC:outArr1*/ double * tmpOut = pOutArr;
								/*!HC:outArr1*/ double * lastElementOut = tmpOut + retDblArr.Length;
								/*!HC:inArr1*/ double * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    /*!HC:HCzero*/ 
                                    *tmpOut = 0.0; 
									while (leadDimIdx < leadDimEnd)
										/*!HC:tmpOutStorage*/ *tmpOut += /*!HC:preEvalOp*/ (double) (*(tmpIn + *leadDimIdx++)) /*!HC:postEvalOp*/ ;
									/*!HC:operationResult*/ 
                                    /**/
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
                        fixed (/*!HC:outArr1*/ double * pOutArr = retDblArr)
                        fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                            /*!HC:inArr1*/ double * lastElement;
                            /*!HC:outArr1*/ double * tmpOut = pOutArr;
                            /*!HC:inArr1*/ double * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                /*!HC:HCzero*/ 
                                *tmpOut = 0.0; 
                                while (tmpIn < lastElement) {
                                    /*!HC:tmpOutStorage*/ *tmpOut += /*!HC:preEvalOp*/ (double) (*tmpIn++) /*!HC:postEvalOp*/ ;
                                }
							    /*!HC:operationResult*/ 
                                /**/
                                tmpOut++;
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
                                /*!HC:HCzero*/ 
                                *tmpOut = 0.0; 
                                while (tmpIn < leadEnd) {
                                    /*!HC:tmpOutStorage*/ *tmpOut += /*!HC:preEvalOp*/ (double) (*tmpIn) /*!HC:postEvalOp*/ ;
                                    tmpIn += inc; 
                                }
								/*!HC:operationResult*/ 
                                /**/
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
			return new /*!HC:outCls1*/ ILArray<double> (retDblArr, newDims);;
        }
        #endregion HYCALPER LOOPEND UNARY_ACCU_TEMPLATE2
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<UInt64>  sum ( ILArray<UInt64> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<UInt64> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<UInt64> (new  UInt64 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<UInt64> )A.Clone();
			int newLength;
			 UInt64 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< UInt64 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( UInt64 * pOutArr = retDblArr)
						    fixed ( UInt64 * pInArr = A.m_data) {
								 UInt64 * tmpOut = pOutArr;
								 UInt64 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt64 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (UInt64) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( UInt64 * pOutArr = retDblArr)
							fixed ( UInt64 * pInArr = A.m_data) {
								 UInt64 * tmpOut = pOutArr;
								 UInt64 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt64 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (UInt64) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( UInt64 * pOutArr = retDblArr)
                        fixed ( UInt64 * pInArr = A.m_data) {
                            UInt64 * lastElement;
                            UInt64 * tmpOut = pOutArr;
                            UInt64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (UInt64) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (UInt64) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<UInt64> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<UInt32>  sum ( ILArray<UInt32> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<UInt32> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<UInt32> (new  UInt32 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<UInt32> )A.Clone();
			int newLength;
			 UInt32 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< UInt32 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( UInt32 * pOutArr = retDblArr)
						    fixed ( UInt32 * pInArr = A.m_data) {
								 UInt32 * tmpOut = pOutArr;
								 UInt32 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt32 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (UInt32) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( UInt32 * pOutArr = retDblArr)
							fixed ( UInt32 * pInArr = A.m_data) {
								 UInt32 * tmpOut = pOutArr;
								 UInt32 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt32 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (UInt32) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( UInt32 * pOutArr = retDblArr)
                        fixed ( UInt32 * pInArr = A.m_data) {
                            UInt32 * lastElement;
                            UInt32 * tmpOut = pOutArr;
                            UInt32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (UInt32) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (UInt32) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<UInt32> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<UInt16>  sum ( ILArray<UInt16> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<UInt16> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<UInt16> (new  UInt16 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<UInt16> )A.Clone();
			int newLength;
			 UInt16 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< UInt16 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( UInt16 * pOutArr = retDblArr)
						    fixed ( UInt16 * pInArr = A.m_data) {
								 UInt16 * tmpOut = pOutArr;
								 UInt16 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt16 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (UInt16) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( UInt16 * pOutArr = retDblArr)
							fixed ( UInt16 * pInArr = A.m_data) {
								 UInt16 * tmpOut = pOutArr;
								 UInt16 * lastElementOut = tmpOut + retDblArr.Length;
								 UInt16 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (UInt16) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( UInt16 * pOutArr = retDblArr)
                        fixed ( UInt16 * pInArr = A.m_data) {
                            UInt16 * lastElement;
                            UInt16 * tmpOut = pOutArr;
                            UInt16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (UInt16) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (UInt16) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<UInt16> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<Int64>  sum ( ILArray<Int64> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<Int64> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<Int64> (new  Int64 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<Int64> )A.Clone();
			int newLength;
			 Int64 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< Int64 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( Int64 * pOutArr = retDblArr)
						    fixed ( Int64 * pInArr = A.m_data) {
								 Int64 * tmpOut = pOutArr;
								 Int64 * lastElementOut = tmpOut + retDblArr.Length;
								 Int64 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (Int64) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( Int64 * pOutArr = retDblArr)
							fixed ( Int64 * pInArr = A.m_data) {
								 Int64 * tmpOut = pOutArr;
								 Int64 * lastElementOut = tmpOut + retDblArr.Length;
								 Int64 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (Int64) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( Int64 * pOutArr = retDblArr)
                        fixed ( Int64 * pInArr = A.m_data) {
                            Int64 * lastElement;
                            Int64 * tmpOut = pOutArr;
                            Int64 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (Int64) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (Int64) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<Int64> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<Int32>  sum ( ILArray<Int32> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<Int32> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<Int32> (new  Int32 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<Int32> )A.Clone();
			int newLength;
			 Int32 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< Int32 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( Int32 * pOutArr = retDblArr)
						    fixed ( Int32 * pInArr = A.m_data) {
								 Int32 * tmpOut = pOutArr;
								 Int32 * lastElementOut = tmpOut + retDblArr.Length;
								 Int32 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (Int32) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( Int32 * pOutArr = retDblArr)
							fixed ( Int32 * pInArr = A.m_data) {
								 Int32 * tmpOut = pOutArr;
								 Int32 * lastElementOut = tmpOut + retDblArr.Length;
								 Int32 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (Int32) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( Int32 * pOutArr = retDblArr)
                        fixed ( Int32 * pInArr = A.m_data) {
                            Int32 * lastElement;
                            Int32 * tmpOut = pOutArr;
                            Int32 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (Int32) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (Int32) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<Int32> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<Int16>  sum ( ILArray<Int16> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<Int16> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<Int16> (new  Int16 []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<Int16> )A.Clone();
			int newLength;
			 Int16 [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< Int16 >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( Int16 * pOutArr = retDblArr)
						    fixed ( Int16 * pInArr = A.m_data) {
								 Int16 * tmpOut = pOutArr;
								 Int16 * lastElementOut = tmpOut + retDblArr.Length;
								 Int16 * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (Int16) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( Int16 * pOutArr = retDblArr)
							fixed ( Int16 * pInArr = A.m_data) {
								 Int16 * tmpOut = pOutArr;
								 Int16 * lastElementOut = tmpOut + retDblArr.Length;
								 Int16 * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (Int16) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( Int16 * pOutArr = retDblArr)
                        fixed ( Int16 * pInArr = A.m_data) {
                            Int16 * lastElement;
                            Int16 * tmpOut = pOutArr;
                            Int16 * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (Int16) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (Int16) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<Int16> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<char>  sum ( ILArray<char> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<char> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<char> (new  char []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<char> )A.Clone();
			int newLength;
			 char [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< char >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( char * pOutArr = retDblArr)
						    fixed ( char * pInArr = A.m_data) {
								 char * tmpOut = pOutArr;
								 char * lastElementOut = tmpOut + retDblArr.Length;
								 char * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = (char)0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (char) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( char * pOutArr = retDblArr)
							fixed ( char * pInArr = A.m_data) {
								 char * tmpOut = pOutArr;
								 char * lastElementOut = tmpOut + retDblArr.Length;
								 char * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = (char)0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (char) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( char * pOutArr = retDblArr)
                        fixed ( char * pInArr = A.m_data) {
                            char * lastElement;
                            char * tmpOut = pOutArr;
                            char * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = (char)0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (char) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = (char)0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (char) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<char> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<byte>  sum ( ILArray<byte> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<byte> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<byte> (new  byte []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<byte> )A.Clone();
			int newLength;
			 byte [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< byte >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( byte * pOutArr = retDblArr)
						    fixed ( byte * pInArr = A.m_data) {
								 byte * tmpOut = pOutArr;
								 byte * lastElementOut = tmpOut + retDblArr.Length;
								 byte * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (byte) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( byte * pOutArr = retDblArr)
							fixed ( byte * pInArr = A.m_data) {
								 byte * tmpOut = pOutArr;
								 byte * lastElementOut = tmpOut + retDblArr.Length;
								 byte * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (byte) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( byte * pOutArr = retDblArr)
                        fixed ( byte * pInArr = A.m_data) {
                            byte * lastElement;
                            byte * tmpOut = pOutArr;
                            byte * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (byte) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (byte) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<byte> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<fcomplex>  sum ( ILArray<fcomplex> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<fcomplex> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<fcomplex> (new  fcomplex []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<fcomplex> )A.Clone();
			int newLength;
			 fcomplex [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< fcomplex >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( fcomplex * pOutArr = retDblArr)
						    fixed ( fcomplex * pInArr = A.m_data) {
								 fcomplex * tmpOut = pOutArr;
								 fcomplex * lastElementOut = tmpOut + retDblArr.Length;
								 fcomplex * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0f;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (fcomplex) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( fcomplex * pOutArr = retDblArr)
							fixed ( fcomplex * pInArr = A.m_data) {
								 fcomplex * tmpOut = pOutArr;
								 fcomplex * lastElementOut = tmpOut + retDblArr.Length;
								 fcomplex * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0f;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (fcomplex) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( fcomplex * pOutArr = retDblArr)
                        fixed ( fcomplex * pInArr = A.m_data) {
                            fcomplex * lastElement;
                            fcomplex * tmpOut = pOutArr;
                            fcomplex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0.0f;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (fcomplex) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0.0f;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (fcomplex) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<fcomplex> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<float>  sum ( ILArray<float> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<float> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<float> (new  float []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<float> )A.Clone();
			int newLength;
			 float [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< float >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( float * pOutArr = retDblArr)
						    fixed ( float * pInArr = A.m_data) {
								 float * tmpOut = pOutArr;
								 float * lastElementOut = tmpOut + retDblArr.Length;
								 float * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0f;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (float) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( float * pOutArr = retDblArr)
							fixed ( float * pInArr = A.m_data) {
								 float * tmpOut = pOutArr;
								 float * lastElementOut = tmpOut + retDblArr.Length;
								 float * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0f;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (float) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( float * pOutArr = retDblArr)
                        fixed ( float * pInArr = A.m_data) {
                            float * lastElement;
                            float * tmpOut = pOutArr;
                            float * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0.0f;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (float) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0.0f;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (float) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<float> (retDblArr, newDims);;
        }
        /// <summary>
		/// Sum elements of A along dimension specified.
		/// </summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns>array, same size as A, but having the 'leadDim's dimension 
		/// reduced to the length 1 with the sum of all
		/// elements along that dimension.</returns>
        public static  ILArray<complex>  sum ( ILArray<complex> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<complex> .empty(); 
            if (A.IsScalar)
               
                return new  ILArray<complex> (new  complex []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("the dimension parameter was out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<complex> )A.Clone();
			int newLength;
			 complex [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< complex >(newLength);
            int leadDimLen = inDim[leadDim];
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;
            if (A.IsReference) {
#region Reference storage
				// ========================  REFERENCE double Storage ===========
				if (A.IsMatrix) {
#region Matrix
					////////////////////////////   MATRIX   ///////////////////////
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int secDim = (leadDim + 1) % 2;
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed ( complex * pOutArr = retDblArr)
						    fixed ( complex * pInArr = A.m_data) {
								 complex * tmpOut = pOutArr;
								 complex * lastElementOut = tmpOut + retDblArr.Length;
								 complex * tmpIn = pInArr;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length - 1;
								int* secDimIdx = secDimStart; 
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen - 1;
								// start at first element
								while (secDimIdx <= secDimEnd) {
									tmpIn = pInArr + *secDimIdx++; 
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0;
									while (leadDimIdx <= leadDimEnd)
										 *tmpOut +=  (complex) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
                                    tmpOut++;
								}
							}
						}
					} 
#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
#region arbitrary size
					unsafe {
						ILIndexOffset idxOffset = A.m_indexOffset;
						int[] curPosition = new int[A.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed ( complex * pOutArr = retDblArr)
							fixed ( complex * pInArr = A.m_data) {
								 complex * tmpOut = pOutArr;
								 complex * lastElementOut = tmpOut + retDblArr.Length;
								 complex * tmpIn = pInArr;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < lastElementOut) {
									leadDimIdx = leadDimStart;
                                    *tmpOut = 0.0;
									while (leadDimIdx < leadDimEnd)
										 *tmpOut +=  (complex) (*(tmpIn + *leadDimIdx++))  ;
									 
                                    /**/
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
                        fixed ( complex * pOutArr = retDblArr)
                        fixed ( complex * pInArr = A.m_data) {
                            complex * lastElement;
                            complex * tmpOut = pOutArr;
                            complex * tmpIn = pInArr;
                            for (int h = nrHigherDims; h-- > 0; ) {
								lastElement = tmpIn + leadDimLen;
                                *tmpOut = 0.0;
                                while (tmpIn < lastElement) {
                                    *tmpOut +=  (complex) (*tmpIn++)  ;
                                }
							    
                                /**/
                                tmpOut++;
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
                                *tmpOut = 0.0;
                                while (tmpIn < leadEnd) {
                                    *tmpOut +=  (complex) (*tmpIn)  ;
                                    tmpIn += inc; 
                                }
								 
                                /**/
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
			return new  ILArray<complex> (retDblArr, newDims);;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
