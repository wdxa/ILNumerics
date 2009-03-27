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
        outArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
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
            if (fnsd < 0) return /*!HC:outCls1*/ ILArray<double> .empty(0,0); 
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
            if (Object.Equals(A,null)) 
                throw new ILArgumentException ("input array must not be null!"); 
            if (leadDim < 0) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return /*!HC:outCls1*/ ILArray<double> .empty(outDims); 
            }
            if (A.IsScalar) return /*!HC:outCls1*/ ILArray<double> .empty(0,0);
            if (A.IsEmpty) {
                int [] retDim = A.Dimensions.ToIntArray(); 
                retDim[leadDim]--; 
                return /*!HC:outCls1*/ ILArray<double> .empty(retDim); 
            }
            if (N == 0) 
                return A.C; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return /*!HC:outCls1*/ ILArray<double> .empty(0,0); 
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
            if (A.IsEmpty) return /*!HC:outCls1*/ ILArray<double> .empty(A.Dimensions);
            if (A.IsScalar) return /*!HC:outCls1*/ ILArray<double> .empty(0,0);
            if (leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return /*!HC:outCls1*/ ILArray<double> .empty(outDims); 
            }
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            /*!HC:singletonDimOp*/
            if (inDim[leadDim] == 1) return /*!HC:outCls1*/ ILArray<double> .empty(0,0);
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
        public static  ILArray<byte> diff( ILArray<byte> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<byte> .empty(0,0); 
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
            if (Object.Equals(A,null)) 
                throw new ILArgumentException ("input array must not be null!"); 
            if (leadDim < 0) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return  ILArray<byte> .empty(outDims); 
            }
            if (A.IsScalar) return  ILArray<byte> .empty(0,0);
            if (A.IsEmpty) {
                int [] retDim = A.Dimensions.ToIntArray(); 
                retDim[leadDim]--; 
                return  ILArray<byte> .empty(retDim); 
            }
            if (N == 0) 
                return A.C; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<byte> .empty(0,0); 
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
            if (A.IsEmpty) return  ILArray<byte> .empty(A.Dimensions);
            if (A.IsScalar) return  ILArray<byte> .empty(0,0);
            if (leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return  ILArray<byte> .empty(outDims); 
            }
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<byte> .empty(0,0);
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
        public static  ILArray<complex> diff( ILArray<complex> A) {
            int fnsd = A.Dimensions.FirstNonSingleton();
            if (fnsd < 0) return  ILArray<complex> .empty(0,0); 
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
            if (Object.Equals(A,null)) 
                throw new ILArgumentException ("input array must not be null!"); 
            if (leadDim < 0) {
                throw new ILArgumentException("diff: leadDim out of range");
            }
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return  ILArray<complex> .empty(outDims); 
            }
            if (A.IsScalar) return  ILArray<complex> .empty(0,0);
            if (A.IsEmpty) {
                int [] retDim = A.Dimensions.ToIntArray(); 
                retDim[leadDim]--; 
                return  ILArray<complex> .empty(retDim); 
            }
            if (N == 0) 
                return A.C; 
            if (N < 1 || N > A.Dimensions[leadDim]) {
                return  ILArray<complex> .empty(0,0); 
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
            if (A.IsEmpty) return  ILArray<complex> .empty(A.Dimensions);
            if (A.IsScalar) return  ILArray<complex> .empty(0,0);
            if (leadDim < 0)
                throw new ILArgumentException("dimension parameter out of range!");
            if (leadDim >= A.Dimensions.NumberOfDimensions) {
                int[] outDims = A.Dimensions.ToIntArray(leadDim+1); 
                outDims[leadDim] = 0; 
                return  ILArray<complex> .empty(outDims); 
            }
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
           
            if (inDim[leadDim] == 1) return  ILArray<complex> .empty(0,0);
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
			return new  ILArray<complex> (retDblArr, newDimension);;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
