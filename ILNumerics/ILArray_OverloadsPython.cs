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

#if IRONPYTHON

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
        <destination><![CDATA[ILArray<char>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<UInt16>]]></destination>
        <destination><![CDATA[ILArray<UInt32>]]></destination>
        <destination><![CDATA[ILArray<UInt64>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<char>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<UInt16>]]></destination>
        <destination><![CDATA[ILArray<UInt32>]]></destination>
        <destination><![CDATA[ILArray<UInt64>]]></destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>byte</destination>
        <destination>char</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>UInt16</destination>
        <destination>UInt32</destination>
        <destination>UInt64</destination>
    </type>
    <type>
        <source locate="after">
            outArr1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<char>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<UInt16>]]></destination>
        <destination><![CDATA[ILArray<UInt32>]]></destination>
        <destination><![CDATA[ILArray<UInt64>]]></destination>
    </type>
 </hycalper>
 */

namespace ILNumerics
{

    public partial class ILArray<BaseT> : ILBaseArray<BaseT>
    {

        #region HYCALPER LOOPSTART PLUS
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1, /*!HC:inArr2*/ double in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(/*!HC:inArr2*/ double in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        #endregion HYCALPER LOOPEND PLUS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  UInt64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( UInt64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  UInt32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( UInt32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  UInt16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( UInt16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  Int64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( Int64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  Int32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( Int32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  Int16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( Int16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  float in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( float in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  fcomplex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( fcomplex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  complex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( complex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  char in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( char in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        
        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +(ILArray<BaseT> in1,  byte in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads plus operator for ILArrays of numeric type
        /// </summary>
        /// <param name="in1">First summand</param>
        /// <param name="in2">Second summand</param>
        /// <returns>New solid ILArray of same type as input array with sum of elements of 
        /// <code>in1 + in2 </code>
        /// </returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator +( byte in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.add(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.add(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.add(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.add(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.add(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.add(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.add(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.add(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.add(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.add(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.add(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.add(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator + not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }
        

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART MINUS
        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1, /*!HC:inArr2*/ double in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(/*!HC:inArr2*/ double in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        #endregion HYCALPER LOOPEND MINUS
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  UInt64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( UInt64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  UInt32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( UInt32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  UInt16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( UInt16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  Int64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( Int64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  Int32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( Int32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  Int16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( Int16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  float in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( float in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  fcomplex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( fcomplex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  complex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( complex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  char in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( char in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1,  byte in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Overloads minus operator for subtracting two ILArrays of numeric type elementwise
        /// </summary>
        /// <param name="in1">Minuend</param>
        /// <param name="in2">Subtrahend</param>
        /// <returns>New ILArray of same type as in1 with difference of elements for 
        /// <code>in1 - in2</code></returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator -( byte in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.subtract(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.subtract(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.subtract(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.subtract(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.subtract(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.subtract(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.subtract(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.subtract(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.subtract(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.subtract(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.subtract(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.subtract(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator - not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }


#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART MULTIPLICATE
        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1, /*!HC:inArr2*/ double in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(/*!HC:inArr2*/ double in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        #endregion HYCALPER LOOPEND MULTIPLICATE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  UInt64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( UInt64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  UInt32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( UInt32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  UInt16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( UInt16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  Int64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( Int64 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  Int32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( Int32 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  Int16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( Int16 in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  float in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( float in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  fcomplex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( fcomplex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  complex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( complex in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  char in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( char in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *(ILArray<BaseT> in1,  byte in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// Elementwise multiplication
        /// </summary>
        /// <param name="in1">first factor</param>
        /// <param name="in2">second factor</param>
        /// <returns>New ILArray of same type as the first input array of the same size than in1 and in2 holding 
        /// the elementwise products of both arrays</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>]]></remarks>
        public static ILArray<BaseT> operator *( byte in2, ILArray<BaseT> in1)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.multiplyElem(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.multiplyElem(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.multiplyElem(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.multiplyElem(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.multiplyElem(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.multiplyElem(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator * not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }


#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART DIVISION
        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1, /*!HC:inArr2*/ double in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        #endregion HYCALPER LOOPEND DIVISION
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  UInt64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  UInt32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  UInt16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  Int64 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  Int32 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  Int16 in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  float in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  fcomplex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  complex in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  char in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <overloads>This operator is overloaded for all numeric types.</overloads>
        /// <summary>
        /// Elementwise division
        /// </summary>
        /// <param name="in1">dividend</param>
        /// <param name="in2">divisor</param>
        /// <returns>New ILArray of same type as in1 of the same size than in1 and in2 holding 
        /// the elementwise division of both arrays: (return array = dividend ./ in2)</returns>
        /// <remarks>This operator is overloaded for all numeric datatypes: <![CDATA[ILArray<double>,ILArray<float>,ILArray<complex>,ILArray<fcomplex>,ILArray<byte>,ILArray<char>,ILArray<Int16>,ILArray<Int32>,ILArray<Int64>,ILArray<UInt16>,ILArray<UInt32>,ILArray<UInt64>,]]></remarks>
        public static ILArray<BaseT> operator /(ILArray<BaseT> in1,  byte in2)
        {
            if (in1 is ILArray<double>)
            {
                ILArray<double> temp = new ILArray<double>(1);
                temp.m_data[0] = (double)in2;
                return (ILMath.divide(in1 as ILArray<double>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<byte>)
            {
                ILArray<byte> temp = new ILArray<byte>(1);
                temp.m_data[0] = (byte)in2;
                return (ILMath.divide(in1 as ILArray<byte>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<char>)
            {
                ILArray<char> temp = new ILArray<char>(1);
                temp.m_data[0] = (char)in2;
                return (ILMath.divide(in1 as ILArray<char>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<complex>)
            {
                ILArray<complex> temp = new ILArray<complex>(1);
                temp.m_data[0] = (complex)in2;
                return (ILMath.divide(in1 as ILArray<complex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<fcomplex>)
            {
                ILArray<fcomplex> temp = new ILArray<fcomplex>(1);
                temp.m_data[0] = (fcomplex)in2;
                return (ILMath.divide(in1 as ILArray<fcomplex>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<float>)
            {
                ILArray<float> temp = new ILArray<float>(1);
                temp.m_data[0] = (float)in2;
                return (ILMath.divide(in1 as ILArray<float>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int16>)
            {
                ILArray<Int16> temp = new ILArray<Int16>(1);
                temp.m_data[0] = (Int16)in2;
                return (ILMath.divide(in1 as ILArray<Int16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int32>)
            {
                ILArray<Int32> temp = new ILArray<Int32>(1);
                temp.m_data[0] = (Int32)in2;
                return (ILMath.divide(in1 as ILArray<Int32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<Int64>)
            {
                ILArray<Int64> temp = new ILArray<Int64>(1);
                temp.m_data[0] = (Int64)in2;
                return (ILMath.divide(in1 as ILArray<Int64>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt16>)
            {
                ILArray<UInt16> temp = new ILArray<UInt16>(1);
                temp.m_data[0] = (UInt16)in2;
                return (ILMath.divide(in1 as ILArray<UInt16>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt32>)
            {
                ILArray<UInt32> temp = new ILArray<UInt32>(1);
                temp.m_data[0] = (UInt32)in2;
                return (ILMath.divide(in1 as ILArray<UInt32>, temp) as ILArray<BaseT>);
            }
            else if (in1 is ILArray<UInt64>)
            {
                ILArray<UInt64> temp = new ILArray<UInt64>(1);
                temp.m_data[0] = (UInt64)in2;
                return (ILMath.divide(in1 as ILArray<UInt64>, temp) as ILArray<BaseT>);
            }
            throw new Exception("Operator / not defined for "
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }

        /// <summary>
        /// implicit cast IronPython list to ILArray (vector)
        /// </summary>
        /// <param name="list">IronPython list</param>
        /// <returns>ILArray</returns>
        //public static implicit operator ILArray<BaseT>(IronPython.Runtime.List list)
        //{
        //    return new ILArray<BaseT>(list);
        //}


#endregion HYCALPER AUTO GENERATED CODE

    }
}

#endif