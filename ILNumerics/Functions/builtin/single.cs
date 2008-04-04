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
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single (/*!HC:inCls1*/ ILArray<double> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed (/*!HC:inArr1*/ double * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        /*!HC:inArr1*/ double * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<byte> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( byte * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        byte * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<char> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( char * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        char * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<UInt64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( UInt64 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        UInt64 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<UInt32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( UInt32 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        UInt32 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<UInt16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( UInt16 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        UInt16 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<Int64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( Int64 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        Int64 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<Int32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( Int32 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        Int32 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// convert numerical ILArray to single precision floating point precision
        /// </summary>
        /// <param name="X">numeric input array</param>
        /// <returns><![CDATA[ILArray<float>]]> of same size as X having all elements converted to 
        /// single precision floating point format.</returns>
        /// <remarks>All overloads of this function will return a solid physical copy 
        /// of the input array X.</remarks>
        public static ILArray<float> single ( ILArray<Int16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new float [nrX]; 
            ILArray<float> ret = new ILArray<float> (retArr,X.m_dimensions); 
            if (X.IsReference) {
                for (int i= 0; i < nrX; i++) {
                    retArr[i] = (float) X.GetValue(i); 
                }
            } else {
                unsafe {
                    fixed (float * outArr = ret.m_data)
                    fixed ( Int16 * inArr = X.m_data) {
                        float* lastElementAfter = outArr + nrX;
                        float* outArrP = outArr; 
                        Int16 * inArrP = inArr; 
                        while (outArrP < lastElementAfter){
                            *outArrP++ = (float)*inArrP++; 
                        }
                    }
                }
            }
            return ret; 
        }

#endregion HYCALPER AUTO GENERATED CODE
    }

}
