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
       
namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART UNARY_ACCU_TEMPLATE1@Functions\builtin\Sum.cs
/*!HC:TYPELIST:
<hycalper>
<type>
    <source>
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<double>]]></destination>
</type>
<type>
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILLogicalArray]]></destination>
    <destination><![CDATA[ILLogicalArray]]></destination>
    <destination><![CDATA[ILLogicalArray]]></destination>
</type>
<type>
    <source>
        funcname
    </source>
    <destination>all</destination>
    <destination>all</destination>
    <destination>all</destination>
</type>
<type>
    <source locate="comment">
        summary
    </source>
    <destination>determine, if all elements are nonzero</destination>
    <destination>determine, if all elements are nonzero</destination>
    <destination>determine, if all elements are nonzero</destination>
</type>
<type>
    <source locate="comment">
        returns
    </source>
    <destination><![CDATA[<para>array of same size as A, having the first non singleton dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para>]]></destination>
    <destination><![CDATA[<para>array of same size as A, having the first non singleton dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para>]]></destination>
    <destination><![CDATA[<para>array of same size as A, having the first non singleton dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para>]]></destination>
</type>
</hycalper>
*/

        #endregion HYCALPER LOOPEND UNARY_ACCU_TEMPLATE1@Sum.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>determine, if all elements are nonzero</summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array of same size as A, having the first non singleton dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para></returns>
		public static  ILLogicalArray  all ( ILArray<double> A) {
            return  all (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>determine, if all elements are nonzero</summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array of same size as A, having the first non singleton dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para></returns>
		public static  ILLogicalArray  all ( ILArray<byte> A) {
            return  all (A, A.Dimensions.FirstNonSingleton());
        }
        /// <summary>determine, if all elements are nonzero</summary>
        /// <param name="A">n-dimensional array</param>
        /// <returns><para>array of same size as A, having the first non singleton dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para></returns>
		public static  ILLogicalArray  all ( ILArray<complex> A) {
            return  all (A, A.Dimensions.FirstNonSingleton());
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART UNARY_ACCU_TEMPLATE2@Functions\builtin\Sum.cs
/*!HC:TYPELIST:
<hycalper>
<type>
    <source>
        inCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<double>]]></destination>
</type>
<type>
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILLogicalArray]]></destination>
    <destination><![CDATA[ILLogicalArray]]></destination>
    <destination><![CDATA[ILLogicalArray]]></destination>
</type>
<type>
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
    <destination>double</destination>
</type>
<type>
    <source>
        inArr2
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
    <destination>double</destination>
</type>
<type>
    <source>
        outArr1
    </source>
    <destination>byte</destination>
    <destination>byte</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        funcname
    </source>
    <destination>all</destination>
    <destination>all</destination>
    <destination>all</destination>
</type>
<type>
    <source locate="nextline">
        singletonDimOp
    </source>
    <destination>int tmpCount = 0; </destination>
    <destination>int tmpCount = 0; </destination>
    <destination>int tmpCount = 0; </destination>
</type>
<type>
    <source>
        tmpOutStorage 
    </source>
    <destination>tmpCount</destination>
    <destination>tmpCount</destination>
    <destination>tmpCount</destination>
</type>
<type>
    <source>
        preEvalOp
    </source>
    <destination>(</destination>
    <destination>(</destination>
    <destination>(</destination>
</type>
<type>
    <source>
        postEvalOp
    </source>
    <destination>.iszero())?0:1; </destination>
    <destination> == 0)?0:1;</destination>
    <destination> == 0.0)?0:1;</destination>
</type>
<type>
    <source locate="nextline">
        HCscalarOp
    </source>
    <destination><![CDATA[return new ILLogicalArray (new byte [1]{(A.GetValue(0).iszero())?(byte)0:(byte)1},1,1);]]></destination>
    <destination><![CDATA[return new ILLogicalArray (new byte [1]{(A.GetValue(0) == 0)?(byte)0:(byte)1},1,1);]]></destination>
    <destination><![CDATA[return new ILLogicalArray (new byte [1]{(A.GetValue(0) == 0.0)?(byte)0:(byte)1},1,1);]]></destination>
</type>
<type>
    <source locate="nextline">
        operationResult
    </source>
    <destination>*tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; </destination>
    <destination>*tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; </destination>
    <destination>*tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; </destination>
</type>
<type>
    <source locate="comment">
        summary
    </source>
    <destination>determine, if all elements are nonzero</destination>
    <destination>determine, if all elements are nonzero</destination>
    <destination>determine, if all elements are nonzero</destination>
</type>
<type>
    <source locate="comment">
        returns
    </source>
    <destination><![CDATA[<para>array of same size as A, having 'leadDim's dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para>]]></destination>
    <destination><![CDATA[<para>array of same size as A, having 'leadDim's dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para>]]></destination>
    <destination><![CDATA[<para>array of same size as A, having 'leadDim's dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para>]]></destination>
</type>
<type>
    <source locate="nextline">
        HCzero
    </source>
    <destination></destination>
    <destination></destination>
    <destination></destination>
</type>
</hycalper>
*/

        #endregion HYCALPER LOOPEND UNARY_ACCU_TEMPLATE2@Sum.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>determine, if all elements are nonzero</summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns><para>array of same size as A, having 'leadDim's dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para></returns>
        public static  ILLogicalArray  all ( ILArray<double> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILLogicalArray .empty(A.Dimensions); 
            if (A.IsScalar)
                return new ILLogicalArray (new byte [1]{(A.GetValue(0) == 0.0)?(byte)0:(byte)1},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            int tmpCount = 0; 
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
                    fixed ( double * pInArr = A.m_data) {
                        double * lastElement;
                        byte * tmpOut = pOutArr;
                        double * tmpIn = pInArr;
                        for (int h = nrHigherDims; h-- > 0; ) {
							lastElement = tmpIn + leadDimLen;
                            
                            while (tmpIn < lastElement) {
                                tmpCount +=  ( (*tmpIn++)   == 0.0)?0:1;
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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
                    fixed ( double * pInArr = A.m_data) {
                        byte * lastElementOut = newLength + pOutArr -1;
                        int inLength = inDim.NumberOfElements -1; 
                        double * lastElementIn = pInArr + inLength; 
                        int inc = inDim.SequentialIndexDistance(leadDim); 
                        byte * tmpOut = pOutArr;
                        int outLength = newLength - 1;
                        double * leadEnd; 
                        double * tmpIn = pInArr;
                        for (int h = nrHigherDims; h--> 0; ) {
							leadEnd = tmpIn + leadDimLen * inc;
                            
                            while (tmpIn < leadEnd) {
                                tmpCount +=  ( (*tmpIn)   == 0.0)?0:1;
                                tmpIn += inc; 
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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

			return new  ILLogicalArray (retDblArr, newDims);;
        }
        /// <summary>determine, if all elements are nonzero</summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns><para>array of same size as A, having 'leadDim's dimension reduced to 1, if all elements along that dimension are nonzero, '0' else. </para></returns>
        public static  ILLogicalArray  all ( ILArray<byte> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILLogicalArray .empty(A.Dimensions); 
            if (A.IsScalar)
                return new ILLogicalArray (new byte [1]{(A.GetValue(0) == 0)?(byte)0:(byte)1},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            int tmpCount = 0; 
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
                            
                            while (tmpIn < lastElement) {
                                tmpCount +=  ( (*tmpIn++)   == 0)?0:1;
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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
                            
                            while (tmpIn < leadEnd) {
                                tmpCount +=  ( (*tmpIn)   == 0)?0:1;
                                tmpIn += inc; 
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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

			return new  ILLogicalArray (retDblArr, newDims);;
        }
        /// <summary>determine, if all elements are nonzero</summary>
		/// <param name="A">N-dimensional array</param>
		/// <param name="leadDim">index of dimension to operate along</param>
		/// <returns><para>array of same size as A, having 'leadDim's dimension reduced to 1, if any elements along that dimension are nonzero, '0' else. </para></returns>
        public static  ILLogicalArray  all ( ILArray<complex> A, int leadDim) {
            if (A.IsEmpty) 
                return  ILLogicalArray .empty(A.Dimensions); 
            if (A.IsScalar)
                return new ILLogicalArray (new byte [1]{(A.GetValue(0).iszero())?(byte)0:(byte)1},1,1);
            if (leadDim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("dimension parameter out of range!");
            ILDimension inDim = A.Dimensions; 
			int[] newDims = inDim.ToIntArray();
            int tmpCount = 0; 
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
                    fixed ( complex * pInArr = A.m_data) {
                        complex * lastElement;
                        byte * tmpOut = pOutArr;
                        complex * tmpIn = pInArr;
                        for (int h = nrHigherDims; h-- > 0; ) {
							lastElement = tmpIn + leadDimLen;
                            
                            while (tmpIn < lastElement) {
                                tmpCount +=  ( (*tmpIn++)  .iszero())?0:1; 
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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
                    fixed ( complex * pInArr = A.m_data) {
                        byte * lastElementOut = newLength + pOutArr -1;
                        int inLength = inDim.NumberOfElements -1; 
                        complex * lastElementIn = pInArr + inLength; 
                        int inc = inDim.SequentialIndexDistance(leadDim); 
                        byte * tmpOut = pOutArr;
                        int outLength = newLength - 1;
                        complex * leadEnd; 
                        complex * tmpIn = pInArr;
                        for (int h = nrHigherDims; h--> 0; ) {
							leadEnd = tmpIn + leadDimLen * inc;
                            
                            while (tmpIn < leadEnd) {
                                tmpCount +=  ( (*tmpIn)  .iszero())?0:1; 
                                tmpIn += inc; 
                            }
                            *tmpOut = (tmpCount == leadDimLen)? (byte)1:(byte)0; tmpCount = 0; 
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

			return new  ILLogicalArray (retDblArr, newDims);;
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
