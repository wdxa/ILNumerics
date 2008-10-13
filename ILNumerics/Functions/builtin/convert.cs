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
        inType1 
    </source>
    <destination>float</destination>
    <destination>complex</destination>
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
    <source locate="after">
        outCls1 
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
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
    <source locate="after">
        inTypeName
    </source>
    <destination>NumericType.Single</destination>
    <destination>NumericType.Complex</destination>
    <destination>NumericType.FComplex</destination>
    <destination>NumericType.Byte</destination>
    <destination>NumericType.Char</destination>
    <destination>NumericType.Int16</destination>
    <destination>NumericType.Int32</destination>
    <destination>NumericType.Int64</destination>
    <destination>NumericType.UInt16</destination>
    <destination>NumericType.UInt32</destination>
    <destination>NumericType.UInt64</destination>
</type>
<type>
    <source locate="after">
        funcName
    </source>
    <destination>tosingle</destination>
    <destination>tocomplex</destination>
    <destination>tofcomplex</destination>
    <destination>tobyte</destination>
    <destination>tochar</destination>
    <destination>toint16</destination>
    <destination>toint32</destination>
    <destination>toint64</destination>
    <destination>touint16</destination>
    <destination>touint32</destination>
    <destination>touint64</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray</*!HC:inType1*/ double > X) {
            if (outputType  == /*!HC:inTypeName*/ NumericType.Double )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                /*!HC:inType1*/ double * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray</*!HC:inType1*/ double > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray</*!HC:inType1*/ double > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< UInt64 > X) {
            if (outputType  ==  NumericType.UInt64 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( UInt64 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                UInt64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< UInt64 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< UInt64 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< UInt64 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< UInt64 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< UInt64 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< UInt64 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< UInt64 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< UInt64 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< UInt64 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< UInt64 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< UInt64 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< UInt64 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< UInt64 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< UInt32 > X) {
            if (outputType  ==  NumericType.UInt32 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( UInt32 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                UInt32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< UInt32 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< UInt32 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< UInt32 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< UInt32 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< UInt32 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< UInt32 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< UInt32 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< UInt32 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< UInt32 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< UInt32 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< UInt32 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< UInt32 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< UInt32 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< UInt16 > X) {
            if (outputType  ==  NumericType.UInt16 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( UInt16 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                UInt16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< UInt16 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< UInt16 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< UInt16 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< UInt16 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< UInt16 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< UInt16 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< UInt16 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< UInt16 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< UInt16 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< UInt16 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< UInt16 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< UInt16 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< UInt16 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< Int64 > X) {
            if (outputType  ==  NumericType.Int64 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( Int64 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                Int64 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< Int64 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< Int64 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< Int64 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< Int64 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< Int64 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< Int64 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< Int64 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< Int64 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< Int64 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< Int64 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< Int64 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< Int64 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< Int64 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< Int32 > X) {
            if (outputType  ==  NumericType.Int32 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( Int32 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                Int32 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< Int32 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< Int32 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< Int32 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< Int32 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< Int32 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< Int32 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< Int32 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< Int32 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< Int32 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< Int32 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< Int32 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< Int32 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< Int32 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< Int16 > X) {
            if (outputType  ==  NumericType.Int16 )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( Int16 * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                Int16 * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< Int16 > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< Int16 > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< Int16 > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< Int16 > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< Int16 > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< Int16 > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< Int16 > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< Int16 > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< Int16 > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< Int16 > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< Int16 > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< Int16 > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< Int16 > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< char > X) {
            if (outputType  ==  NumericType.Char )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( char * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                char * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< char > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< char > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< char > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< char > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< char > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< char > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< char > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< char > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< char > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< char > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< char > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< char > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< char > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< byte > X) {
            if (outputType  ==  NumericType.Byte )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( byte * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                byte * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< byte > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< byte > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< byte > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< byte > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< byte > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< byte > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< byte > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< byte > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< byte > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< byte > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< byte > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< byte > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< byte > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< fcomplex > X) {
            if (outputType  ==  NumericType.FComplex )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( fcomplex * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                fcomplex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< fcomplex > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< fcomplex > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< fcomplex > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< fcomplex > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< fcomplex > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< fcomplex > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< fcomplex > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< fcomplex > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< fcomplex > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< fcomplex > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< fcomplex > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< fcomplex > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< fcomplex > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< complex > X) {
            if (outputType  ==  NumericType.Complex )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( complex * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                complex * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< complex > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< complex > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< complex > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< complex > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< complex > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< complex > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< complex > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< complex > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< complex > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< complex > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< complex > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< complex > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< complex > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }

        /// <summary>
        /// convert arbitrary numeric array to arbitrary numeric type
        /// </summary>
        /// <param name="X">input array</param>
        /// <param name="outputType">type description for return type</param>
        /// <returns>converted array</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILBaseArray convert(NumericType outputType,  ILArray< float > X) {
            if (outputType  ==  NumericType.Single )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            fixed (double * pretA = retA) {
                                int c = 0; 
                                double * pStart = pretA; 
                                double * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (double) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (double * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                double * pStartR = pretA; 
                                double * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (double) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Single:
                    unsafe {
                        float [] retA = ILMemoryPool.Pool.New<float>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (float * pretA = retA) {
                                float * pStart = pretA; 
                                float * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (float) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (float * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                float * pStartR = pretA; 
                                float * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (float) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<float> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (complex * pretA = retA) {
                                complex * pStart = pretA; 
                                complex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (complex * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                complex * pStartR = pretA; 
                                complex * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (complex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.FComplex:
                    unsafe {
                        fcomplex [] retA = ILMemoryPool.Pool.New<fcomplex>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (fcomplex * pretA = retA) {
                                fcomplex * pStart = pretA; 
                                fcomplex * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (fcomplex) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (fcomplex * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                fcomplex * pStartR = pretA; 
                                fcomplex * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (fcomplex) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<fcomplex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (byte * pretA = retA) {
                                byte * pStart = pretA; 
                                byte * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (byte) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (byte * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                byte * pStartR = pretA; 
                                byte * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (byte) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Char:
                    unsafe {
                        char [] retA = ILMemoryPool.Pool.New<char>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (char * pretA = retA) {
                                char * pStart = pretA; 
                                char * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (char) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (char * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                char * pStartR = pretA; 
                                char * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (char) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<char> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Int16:
                    unsafe {
                        Int16 [] retA = ILMemoryPool.Pool.New<Int16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int16 * pretA = retA) {
                                Int16 * pStart = pretA; 
                                Int16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int16 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                Int16 * pStartR = pretA; 
                                Int16 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (short) *(pWalkX++); 
                                }
                            }
                        }
                        ret = new ILArray<Int16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int32:
                    unsafe {
                        Int32 [] retA = ILMemoryPool.Pool.New<Int32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int32 * pretA = retA) {
                                Int32 * pStart = pretA; 
                                Int32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int32 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                Int32 * pStartR = pretA; 
                                Int32 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.Int64:
                    unsafe {
                        Int64 [] retA = ILMemoryPool.Pool.New<Int64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (Int64 * pretA = retA) {
                                Int64 * pStart = pretA; 
                                Int64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (Int64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (Int64 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                Int64 * pStartR = pretA; 
                                Int64 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (Int64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<Int64> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt16:
                    unsafe {
                        UInt16 [] retA = ILMemoryPool.Pool.New<UInt16>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt16 * pretA = retA) {
                                UInt16 * pStart = pretA; 
                                UInt16 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt16) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt16 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                UInt16 * pStartR = pretA; 
                                UInt16 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt16) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt16> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt32:
                    unsafe {
                        UInt32 [] retA = ILMemoryPool.Pool.New<UInt32>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt32 * pretA = retA) {
                                UInt32 * pStart = pretA; 
                                UInt32 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt32) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt32 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                UInt32 * pStartR = pretA; 
                                UInt32 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt32) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt32> (retA,X.Dimensions); 
                    }
                    return ret; 
                 case NumericType.UInt64:
                    unsafe {
                        UInt64 [] retA = ILMemoryPool.Pool.New<UInt64>(X.Dimensions.NumberOfElements);
                        if (X.IsReference) {
                            int c = 0; 
                            fixed (UInt64 * pretA = retA) {
                                UInt64 * pStart = pretA; 
                                UInt64 * pEnd = pretA + retA.Length; 
                                while (pStart < pEnd) {
                                    *(pStart++) = (UInt64) X.GetValue(c++);
                                }
                            }
                        } else {
                            fixed (UInt64 * pretA = retA)
                            fixed ( float * pX = X.m_data) {
                                UInt64 * pStartR = pretA; 
                                UInt64 * pEndR = pretA + X.m_data.Length;
                                float * pWalkX = pX; 
                                while (pStartR < pEndR) {
                                    *(pStartR++) = (UInt64) (*(pWalkX++)); 
                                }
                            }
                        }
                        ret = new ILArray<UInt64> (retA,X.Dimensions); 
                    }
                    return ret; 
            }
            return ret; 
        }
        
        /// <summary>
        /// convert numeric array to double
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; double &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<double> todouble(ILArray< float > X) {
             return (ILArray<double>)convert(NumericType.Double,X); 
        }
        /// <summary>
        /// convert numeric array to inner type float (single precision)
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; float &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<float> tosingle(ILArray< float > X) {
             return (ILArray<float>)convert(NumericType.Single,X); 
        }
        /// <summary>
        /// convert numeric array to inner type complex 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; complex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<complex> tocomplex(ILArray< float > X) {
             return (ILArray<complex>)convert(NumericType.Complex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type fcomplex
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; fcomplex &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<fcomplex> tofcomplex(ILArray< float > X) {
             return (ILArray<fcomplex>)convert(NumericType.FComplex,X); 
        }
        /// <summary>
        /// convert numeric array to inner type byte
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; byte &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<byte> tobyte(ILArray< float > X) {
             return (ILArray<byte>)convert(NumericType.Byte,X); 
        }
        /// <summary>
        /// convert numeric array to inner type logical
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILLogicalArray</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILLogicalArray tological(ILArray< float > X) {
             return new ILLogicalArray ((ILArray<byte>)convert(NumericType.Byte,X)); 
        }
        /// <summary>
        /// convert numeric array to inner type char
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; char &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<char> tochar(ILArray< float > X) {
             return (ILArray<char>)convert(NumericType.Char,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int16> toint16(ILArray< float > X) {
             return (ILArray<Int16>)convert(NumericType.Int16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int32
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int32> toint32(ILArray< float > X) {
             return (ILArray<Int32>)convert(NumericType.Int32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type Int64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; Int64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<Int64> toint64(ILArray< float > X) {
             return (ILArray<Int64>)convert(NumericType.Int64,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt 16
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt16 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt16> touint16(ILArray< float > X) {
             return (ILArray<UInt16>)convert(NumericType.UInt16,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt32 
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt32 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt32> touint32(ILArray< float > X) {
             return (ILArray<UInt32>)convert(NumericType.UInt32,X); 
        }
        /// <summary>
        /// convert numeric array to inner type UInt64
        /// </summary>
        /// <param name="X">input array </param>
        /// <returns>ILArray &lt; UInt64 &gt;</returns>
        /// <remarks> The newly created array will be converted to the type requested. 
        /// <para>Important note: if X matches the type requested, NO COPY will be made for it and the SAME array will be returned!</para></remarks>
        public static ILArray<UInt64> touint64(ILArray< float > X) {
             return (ILArray<UInt64>)convert(NumericType.UInt64,X); 
        }


#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// Convert arbitrary (numeric) array to other inner type
        /// </summary>
        /// <param name="typeName">Numeric type for output</param>
        /// <param name="X">input array, arbitrary inner type</param>
        /// <returns>Numeric array with specified inner element type</returns>
        public static ILBaseArray convert(NumericType typeName, ILBaseArray X) {
            if (X is ILArray<double>) {
                return convert(typeName,X as ILArray<double>);  
            } else if (X is ILArray<float>) {
                return convert(typeName,X as ILArray<float>); 
            } else if (X is ILArray<complex>) {
                return convert(typeName,X as ILArray<complex>);  
            } else if (X is ILArray<fcomplex>) {
                return convert(typeName,X as ILArray<fcomplex>);
            } else if (X is ILArray<byte>) {
                return convert(typeName,X as ILArray<byte>);  
            } else if (X is ILArray<char>) {
                return convert(typeName,X as ILArray<char>);
            } else if (X is ILArray<Int16>) {
                return convert(typeName,X as ILArray<Int16>);  
            } else if (X is ILArray<Int32>) {
                return convert(typeName,X as ILArray<Int32>);  
            } else if (X is ILArray<Int64>) {
                return convert(typeName,X as ILArray<Int64>);  
            } else if (X is ILArray<UInt16>) {
                return convert(typeName,X as ILArray<UInt16>); 
            } else if (X is ILArray<UInt32>) {
                return convert(typeName,X as ILArray<UInt32>);  
            } else if (X is ILArray<UInt64>) {
                return convert(typeName,X as ILArray<UInt64>);  
            } else 
                throw new ILArgumentException("convert: cannot convert invalid (non numeric) inner data type: '" + X.GetType().GetGenericArguments()[0].Name + "'");
        }

        #region HYCALPER LOOPSTART generic_numeric_2_specific
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray</*!HC:inType1*/ double > /*!HC:funcName*/ todouble (ILBaseArray X) {
            return (ILArray</*!HC:inType1*/ double >)convert(/*!HC:inTypeName*/ NumericType.Double ,X); 
        }
        #endregion HYCALPER LOOPEND generic_numeric_2_specific
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< UInt64 >  touint64 (ILBaseArray X) {
            return (ILArray< UInt64 >)convert( NumericType.UInt64 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< UInt32 >  touint32 (ILBaseArray X) {
            return (ILArray< UInt32 >)convert( NumericType.UInt32 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< UInt16 >  touint16 (ILBaseArray X) {
            return (ILArray< UInt16 >)convert( NumericType.UInt16 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< Int64 >  toint64 (ILBaseArray X) {
            return (ILArray< Int64 >)convert( NumericType.Int64 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< Int32 >  toint32 (ILBaseArray X) {
            return (ILArray< Int32 >)convert( NumericType.Int32 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< Int16 >  toint16 (ILBaseArray X) {
            return (ILArray< Int16 >)convert( NumericType.Int16 ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< char >  tochar (ILBaseArray X) {
            return (ILArray< char >)convert( NumericType.Char ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< byte >  tobyte (ILBaseArray X) {
            return (ILArray< byte >)convert( NumericType.Byte ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< fcomplex >  tofcomplex (ILBaseArray X) {
            return (ILArray< fcomplex >)convert( NumericType.FComplex ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< complex >  tocomplex (ILBaseArray X) {
            return (ILArray< complex >)convert( NumericType.Complex ,X); 
        }
        /// <summary>
        /// Convert arbitrary numeric array to specific type
        /// </summary>
        /// <param name="X">numeric array, arbitrary numeric type</param>
        /// <returns>Array of specific inner type</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if X is not numeric</exception>
        public static ILArray< float >  tosingle (ILBaseArray X) {
            return (ILArray< float >)convert( NumericType.Single ,X); 
        }

#endregion HYCALPER AUTO GENERATED CODE

    }

}
