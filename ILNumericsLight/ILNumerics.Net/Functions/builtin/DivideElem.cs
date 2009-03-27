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
            outCast
        </source>
        <destination></destination>
        <destination>(byte)</destination>
        <destination></destination>
    </type>
    <type>
        <source locate="after">
            HCoperation
        </source>
        <destination>/</destination>
        <destination>/</destination>
        <destination>/</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>divide</destination>
        <destination>divide</destination>
        <destination>divide</destination>
    </type>
    <type>
        <source locate="comment">
            summary
        </source>
        <destination>Divide elements</destination>
        <destination>Divide elements</destination>
        <destination>Divide elements</destination>
    </type>
    <type>
        <source locate="comment">
            returns
        </source>
        <destination>Array with elementwise division of A and B</destination>
        <destination>Array with elementwise division of A and B</destination>
        <destination>Array with elementwise division of A and B</destination>
    </type>
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {

    public partial class ILMath {         
         
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs

        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE@Add.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>Divide elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise division of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<complex>  divide ( ILArray<complex> A,  ILArray<complex> B) {
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<complex> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<complex> (new  complex [1]{  (A.m_data[0]  / B.m_data[0])});
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
                                
                            	*tmpOut++ =   (scalarValue  / (*tmpIn++));
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
                                
                                *tmpOut++ =   (*tmpIn++  / scalarValue);
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
                                 
                                *poutarr++ =   ( *pInA1++  / (*pInA2++));
                            }
                        }
                    }

                    return new  ILArray<complex> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Divide elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise division of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<byte>  divide ( ILArray<byte> A,  ILArray<byte> B) {
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<byte> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<byte> (new  byte [1]{ (byte) (A.m_data[0]  / B.m_data[0])});
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
                                
                            	*tmpOut++ =  (byte) (scalarValue  / (*tmpIn++));
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
                                
                                *tmpOut++ =  (byte) (*tmpIn++  / scalarValue);
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
                                 
                                *poutarr++ =  (byte) ( *pInA1++  / (*pInA2++));
                            }
                        }
                    }

                    return new  ILArray<byte> ( retSystemArr, inDim );
                    #endregion array + array
                }
            }
        }
        /// <summary>Divide elements</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns>Array with elementwise division of A and B</returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<double>  divide ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILArray<double> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<double> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                   
                    return new  ILArray<double> (new  double [1]{  (A.m_data[0]  / B.m_data[0])});
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
                                
                            	*tmpOut++ =   (scalarValue  / (*tmpIn++));
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
                                
                                *tmpOut++ =   (*tmpIn++  / scalarValue);
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
                                 
                                *poutarr++ =   ( *pInA1++  / (*pInA2++));
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