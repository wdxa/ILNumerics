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
using ILNumerics;
using ILNumerics.Misc;
using ILNumerics.Storage;
using ILNumerics.Native;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions;
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            outCast
        </source>
        <destination>(byte)</destination>
        <destination></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>+</destination>
        <destination>+</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {         
         
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static /*!HC:outCls*/ ILArray<double> /*!HC:HCFuncName*/ add (/*!HC:inCls1*/ ILArray<double> A, /*!HC:inCls2*/ ILArray<double> B) {
            if (A.IsEmpty) {
                return /*!HC:outCls*/ ILArray<double> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return /*!HC:outCls*/ ILArray<double> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    /*!HC:HCCompute00*/
                    return new /*!HC:outCls*/ ILArray<double> (new /*!HC:outArr*/ double [1]{/*!HC:outCast*/ /**/ (A.m_data[0] /*!HC:HCoperation*/ + B.m_data[0])});
                } else {
                    #region scalar + array  
                    ILDimension inDim = B.Dimensions;

                    /*!HC:outArr*/ double [] retArr =
                        ILMemoryPool.Pool.New</*!HC:outArr*/ double > (inDim.NumberOfElements);

                    /*!HC:inArr1*/ double scalarValue = A.m_data[0]; 
                    
                    unsafe {
                        fixed (/*!HC:outArr*/ double * pOutArr = retArr)
                        fixed (/*!HC:inArr2*/ double * pInArr = B.m_data) {
                            /*!HC:outArr*/ double * lastElement = pOutArr + retArr.Length;
                            /*!HC:outArr*/ double * tmpOut = pOutArr;
                            /*!HC:inArr2*/ double * tmpIn = pInArr;
                            while (tmpOut < lastElement) //HC03
                                /*!HC:HCCompute03*/ 
                            	*tmpOut++ = /*!HC:outCast*/ /**/ (scalarValue /*!HC:HCoperation*/ + (*tmpIn++));
                        }       
                    }

                    return new /*!HC:outCls*/ ILArray<double> ( retArr, inDim );
                    #endregion scalar + array
                }
            } else {
                if (B.IsScalar) {
                    #region array + scalar
                    ILDimension inDim = A.Dimensions;

                    /*!HC:outArr*/ double [] retArr = 
                        ILMemoryPool.Pool.New</*!HC:outArr*/ double > (A.m_data.Length);

                    /*!HC:inArr2*/ double scalarValue = B.m_data[0]; 

                    unsafe {
                        fixed (/*!HC:outArr*/ double * pOutArr = retArr)
                        fixed (/*!HC:inArr1*/ double * pInArr = A.m_data) {
                            /*!HC:outArr*/ double * lastElement = pOutArr + retArr.Length;
                            /*!HC:outArr*/ double * tmpOut = pOutArr;
                            /*!HC:inArr1*/ double * tmpIn = pInArr;
                            while (tmpOut < lastElement) { //HC06
                                /*!HC:HCCompute06*/ 
                                *tmpOut++ = /*!HC:outCast*/ /**/ (*tmpIn++  /*!HC:HCoperation*/ + scalarValue);
                            }
                        }
                    }

                    return new /*!HC:outCls*/ ILArray<double> ( retArr, inDim );
                    #endregion array + scalar
                } else {
                    #region array + array
                    ILDimension inDim = A.Dimensions;
                    if (!inDim.IsSameSize ( B.Dimensions ))
                        throw new ILDimensionMismatchException ();

                    /*!HC:outArr*/ double [] retSystemArr =
                        ILMemoryPool.Pool.New</*!HC:outArr1*/ double > (inDim.NumberOfElements);

                    unsafe {
                        fixed (/*!HC:outArr*/ double * pOutArr = retSystemArr)
                        fixed (/*!HC:inArr1*/ double * inA1 = A.m_data) 
                        fixed (/*!HC:inArr2*/ double * inA2 = B.m_data) {
                            /*!HC:inArr1*/ double * pInA1 = inA1; 
                            /*!HC:inArr2*/ double * pInA2 = inA2;
                            /*!HC:outArr*/ double * poutarr = pOutArr;
                            /*!HC:outArr*/ double * outEnd = poutarr + retSystemArr.Length;
                            while (poutarr < outEnd) {  //HC11
                                /*!HC:HCCompute11*/  
                                *poutarr++ = /*!HC:outCast*/ /**/ ( *pInA1++ /*!HC:HCoperation*/ + (*pInA2++));
                            }
                        }
                    }

                    return new /*!HC:outCls*/ ILArray<double> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<complex>  add ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<complex> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<complex> (new  complex [1]{  (A.m_data[0]  + B.m_data[0])});
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
                                
                            	*tmpOut++ =   (scalarValue  + (*tmpIn++));
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
                                
                                *tmpOut++ =   (*tmpIn++  + scalarValue);
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
                                 
                                *poutarr++ =   ( *pInA1++  + (*pInA2++));
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
        public static  ILArray<byte>  add ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<byte> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<byte> (new  byte [1]{ (byte) (A.m_data[0]  + B.m_data[0])});
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
                                
                            	*tmpOut++ =  (byte) (scalarValue  + (*tmpIn++));
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
                                
                                *tmpOut++ =  (byte) (*tmpIn++  + scalarValue);
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
                                 
                                *poutarr++ =  (byte) ( *pInA1++  + (*pInA2++));
                            }
                        }
                    }

                    return new  ILArray<byte> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }

#endregion HYCALPER AUTO GENERATED CODE
    }
}
