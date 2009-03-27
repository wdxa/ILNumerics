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
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        inArr2
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        outArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        preEvalOp
    </source>
    <destination>(complex)</destination>
    <destination>(byte)</destination>
</type>
<type>
    <source locate="nextline">
        HCzero
    </source>
    <destination>*tmpOut = 0.0;</destination>
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
                return /*!HC:outCls1*/ ILArray<double> .empty(A.Dimensions); 
            if (A.IsScalar)
                /*!HC:HCscalarOp*/
                return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:inArr1*/ double []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
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
            ILDimension newDimension = new ILDimension(newDims); 
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            int leadDimLen = inDim[leadDim]; 
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;

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
        public static  ILArray<byte>  sum ( ILArray<byte> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<byte> .empty(A.Dimensions); 
            if (A.IsScalar)
               
                return new  ILArray<byte> (new  byte []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<byte> )A.Clone();
			int newLength;
			 byte [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< byte >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            int leadDimLen = inDim[leadDim]; 
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;

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
        public static  ILArray<complex>  sum ( ILArray<complex> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILArray<complex> .empty(A.Dimensions); 
            if (A.IsScalar)
               
                return new  ILArray<complex> (new  complex []{A.GetValue(0)},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return ( ILArray<complex> )A.Clone();
			int newLength;
			 complex [] retDblArr;
			// build ILDimension
			newLength = inDim.NumberOfElements / newDims[leadDim];
			newDims[leadDim] = 1;
			retDblArr = ILMemoryPool.Pool.New< complex >(newLength);
            ILDimension newDimension = new ILDimension(newDims); 
            int incOut = newDimension.SequentialIndexDistance(leadDim); 
            int leadDimLen = inDim[leadDim]; 
			int nrHigherDims = inDim.NumberOfElements / leadDimLen;

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

			return new  ILArray<complex> (retDblArr, newDims);;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
