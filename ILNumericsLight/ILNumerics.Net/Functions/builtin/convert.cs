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
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source locate="after">
        outCls1 
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source locate="after">
        inTypeName
    </source>
    <destination>NumericType.Complex</destination>
    <destination>NumericType.Byte</destination>
</type>
<type>
    <source locate="after">
        funcName
    </source>
    <destination>tocomplex</destination>
    <destination>tobyte</destination>
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
                        fixed (double * pretA = retA)
                        fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                            double * pStartR = pretA; 
                            double * pEndR = pretA + X.m_data.Length;
                            /*!HC:inType1*/ double * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (double) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        fixed (complex * pretA = retA)
                        fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                            complex * pStartR = pretA; 
                            complex * pEndR = pretA + X.m_data.Length;
                            /*!HC:inType1*/ double * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (complex) (*(pWalkX++)); 
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        fixed (byte * pretA = retA)
                        fixed (/*!HC:inType1*/ double * pX = X.m_data) {
                            byte * pStartR = pretA; 
                            byte * pEndR = pretA + X.m_data.Length;
                            /*!HC:inType1*/ double * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (byte) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
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
        public static ILBaseArray convert(NumericType outputType,  ILArray< byte > X) {
            if (outputType  ==  NumericType.Byte )
                return X; 
            ILBaseArray ret = null; 
            switch (outputType) {
                case NumericType.Double:
                    unsafe {
                        double [] retA = ILMemoryPool.Pool.New<double>(X.Dimensions.NumberOfElements);
                        fixed (double * pretA = retA)
                        fixed ( byte * pX = X.m_data) {
                            double * pStartR = pretA; 
                            double * pEndR = pretA + X.m_data.Length;
                            byte * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (double) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        fixed (complex * pretA = retA)
                        fixed ( byte * pX = X.m_data) {
                            complex * pStartR = pretA; 
                            complex * pEndR = pretA + X.m_data.Length;
                            byte * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (complex) (*(pWalkX++)); 
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        fixed (byte * pretA = retA)
                        fixed ( byte * pX = X.m_data) {
                            byte * pStartR = pretA; 
                            byte * pEndR = pretA + X.m_data.Length;
                            byte * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (byte) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
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
                        fixed (double * pretA = retA)
                        fixed ( complex * pX = X.m_data) {
                            double * pStartR = pretA; 
                            double * pEndR = pretA + X.m_data.Length;
                            complex * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (double) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<double> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Complex:
                    unsafe {
                        complex [] retA = ILMemoryPool.Pool.New<complex>(X.Dimensions.NumberOfElements);
                        fixed (complex * pretA = retA)
                        fixed ( complex * pX = X.m_data) {
                            complex * pStartR = pretA; 
                            complex * pEndR = pretA + X.m_data.Length;
                            complex * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (complex) (*(pWalkX++)); 
                            }
                        }
                        ret = new ILArray<complex> (retA,X.Dimensions); 
                    }
                    return ret; 
                case NumericType.Byte:
                    unsafe {
                        byte [] retA = ILMemoryPool.Pool.New<byte>(X.Dimensions.NumberOfElements);
                        fixed (byte * pretA = retA)
                        fixed ( complex * pX = X.m_data) {
                            byte * pStartR = pretA; 
                            byte * pEndR = pretA + X.m_data.Length;
                            complex * pWalkX = pX; 
                            while (pStartR < pEndR) {
                                *(pStartR++) = (byte) *(pWalkX++); 
                            }
                        }
                        ret = new ILArray<byte> (retA,X.Dimensions); 
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
            } else if (X is ILArray<complex>) {
                return convert(typeName,X as ILArray<complex>);  
            } else if (X is ILArray<byte>) {
                return convert(typeName,X as ILArray<byte>);  
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
        public static ILArray< byte >  tobyte (ILBaseArray X) {
            return (ILArray< byte >)convert( NumericType.Byte ,X); 
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

#endregion HYCALPER AUTO GENERATED CODE

    }

}
