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
using ILNumerics;
using ILNumerics.Exceptions; 
using ILNumerics.Storage; 
using ILNumerics.Misc;
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
        </source>
        <destination>double</destination>
    </type>
    <type>
        <source locate="after">
            HCFuncName
        </source>
        <destination>atan2</destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute00
        </source>
        <destination><![CDATA[return new ILArray<double>(new double[1] {Math.Atan2(A.m_data[0], B.m_data[0])});]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute03
        </source>
        <destination><![CDATA[{ *tmpOut++ = Math.Atan2(scalarValue, *tmpIn); tmpIn++; }]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute06
        </source>
        <destination><![CDATA[{ *tmpOut++ = Math.Atan2(*tmpIn, scalarValue); }]]></destination>
    </type>
    <type>
        <source locate="nextline">
            HCCompute11
        </source>
        <destination><![CDATA[*poutarr++ = Math.Atan2(*pInA1++, *pInA2++);]]></destination>
    </type>
</hycalper>
*/

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        #region HYCALPER LOOPSTART BINARY_OPERATOR_TEMPLATE@Functions\builtin\Add.cs

        #endregion HYCALPER LOOPEND BINARY_OPERATOR_TEMPLATE@Add.cs
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary> sum two arrays elementwise</summary>
        /// <param name="A">input 1</param>
        /// <param name="B">input 2</param>
        /// <returns> Array with elementwise sum of A and B </returns>
        /// <remarks><para>On empty input - empty array will be returned.</para>
        /// <para>A and / or B may be scalar. The scalar value will operate on all elements of the other arrays in this case.</para>
        /// <para>If neither of A or B is scalar or empty, the dimensions of both arrays must match.</para></remarks>
        public static  ILArray<double>  atan2 ( ILArray<double> A,  ILArray<double> B) {
            if (A.IsEmpty) {
                return  ILArray<double> .empty(A.Dimensions); 
            }
            if (B.IsEmpty) {
                return  ILArray<double> .empty(B.Dimensions);
            }
            if (A.IsScalar) {
                if (B.IsScalar) {
                    return new ILArray<double>(new double[1] {Math.Atan2(A.m_data[0], B.m_data[0])});
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
                                { *tmpOut++ = Math.Atan2(scalarValue, *tmpIn); tmpIn++; }
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
                                { *tmpOut++ = Math.Atan2(*tmpIn, scalarValue); }
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
                                *poutarr++ = Math.Atan2(*pInA1++, *pInA2++);
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
