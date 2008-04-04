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

namespace ILNumerics {

    public partial class ILArray<BaseT> : ILBaseArray<BaseT> {
         
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
		public static /*!HC:outArr1*/ ILArray<double> operator +(/*!HC:inCls1*/ ILArray<double> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is /*!HC:inCls2*/ ILArray<double> ) {
                return ILMath.add(in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
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
		public static  ILArray<UInt64> operator +( ILArray<UInt64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt64> ) {
                return ILMath.add(in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
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
		public static  ILArray<UInt32> operator +( ILArray<UInt32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt32> ) {
                return ILMath.add(in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
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
		public static  ILArray<UInt16> operator +( ILArray<UInt16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt16> ) {
                return ILMath.add(in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
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
		public static  ILArray<Int64> operator +( ILArray<Int64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int64> ) {
                return ILMath.add(in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
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
		public static  ILArray<Int32> operator +( ILArray<Int32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int32> ) {
                return ILMath.add(in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
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
		public static  ILArray<Int16> operator +( ILArray<Int16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int16> ) {
                return ILMath.add(in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
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
		public static  ILArray<float> operator +( ILArray<float> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<float> ) {
                return ILMath.add(in1 as  ILArray<float> , in2 as  ILArray<float> );
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
		public static  ILArray<fcomplex> operator +( ILArray<fcomplex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<fcomplex> ) {
                return ILMath.add(in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
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
		public static  ILArray<complex> operator +( ILArray<complex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<complex> ) {
                return ILMath.add(in1 as  ILArray<complex> , in2 as  ILArray<complex> );
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
		public static  ILArray<char> operator +( ILArray<char> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<char> ) {
                return ILMath.add(in1 as  ILArray<char> , in2 as  ILArray<char> );
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
		public static  ILArray<byte> operator +( ILArray<byte> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<byte> ) {
                return ILMath.add(in1 as  ILArray<byte> , in2 as  ILArray<byte> );
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
        public static /*!HC:outArr1*/ ILArray<double> operator -(/*!HC:inCls1*/ ILArray<double> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is /*!HC:inCls2*/ ILArray<double> ) {
                return ILMath.subtract(in1, in2 as /*!HC:inCls2*/ ILArray<double> );
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
        public static  ILArray<UInt64> operator -( ILArray<UInt64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt64> ) {
                return ILMath.subtract(in1, in2 as  ILArray<UInt64> );
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
        public static  ILArray<UInt32> operator -( ILArray<UInt32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt32> ) {
                return ILMath.subtract(in1, in2 as  ILArray<UInt32> );
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
        public static  ILArray<UInt16> operator -( ILArray<UInt16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt16> ) {
                return ILMath.subtract(in1, in2 as  ILArray<UInt16> );
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
        public static  ILArray<Int64> operator -( ILArray<Int64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int64> ) {
                return ILMath.subtract(in1, in2 as  ILArray<Int64> );
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
        public static  ILArray<Int32> operator -( ILArray<Int32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int32> ) {
                return ILMath.subtract(in1, in2 as  ILArray<Int32> );
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
        public static  ILArray<Int16> operator -( ILArray<Int16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int16> ) {
                return ILMath.subtract(in1, in2 as  ILArray<Int16> );
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
        public static  ILArray<float> operator -( ILArray<float> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<float> ) {
                return ILMath.subtract(in1, in2 as  ILArray<float> );
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
        public static  ILArray<fcomplex> operator -( ILArray<fcomplex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<fcomplex> ) {
                return ILMath.subtract(in1, in2 as  ILArray<fcomplex> );
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
        public static  ILArray<complex> operator -( ILArray<complex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<complex> ) {
                return ILMath.subtract(in1, in2 as  ILArray<complex> );
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
        public static  ILArray<char> operator -( ILArray<char> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<char> ) {
                return ILMath.subtract(in1, in2 as  ILArray<char> );
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
        public static  ILArray<byte> operator -( ILArray<byte> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<byte> ) {
                return ILMath.subtract(in1, in2 as  ILArray<byte> );
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
		public static /*!HC:outArr1*/ ILArray<double> operator *(/*!HC:inCls1*/ ILArray<double> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is /*!HC:inCls2*/ ILArray<double> ) {
                return ILMath.multiplyElem(in1, in2 as /*!HC:inCls2*/ ILArray<double> );
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
		public static  ILArray<UInt64> operator *( ILArray<UInt64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt64> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<UInt64> );
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
		public static  ILArray<UInt32> operator *( ILArray<UInt32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt32> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<UInt32> );
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
		public static  ILArray<UInt16> operator *( ILArray<UInt16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt16> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<UInt16> );
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
		public static  ILArray<Int64> operator *( ILArray<Int64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int64> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<Int64> );
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
		public static  ILArray<Int32> operator *( ILArray<Int32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int32> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<Int32> );
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
		public static  ILArray<Int16> operator *( ILArray<Int16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int16> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<Int16> );
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
		public static  ILArray<float> operator *( ILArray<float> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<float> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<float> );
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
		public static  ILArray<fcomplex> operator *( ILArray<fcomplex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<fcomplex> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<fcomplex> );
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
		public static  ILArray<complex> operator *( ILArray<complex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<complex> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<complex> );
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
		public static  ILArray<char> operator *( ILArray<char> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<char> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<char> );
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
		public static  ILArray<byte> operator *( ILArray<byte> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<byte> ) {
                return ILMath.multiplyElem(in1, in2 as  ILArray<byte> );
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
		public static /*!HC:outArr1*/ ILArray<double> operator /(/*!HC:inCls1*/ ILArray<double> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is /*!HC:inCls2*/ ILArray<double> ) {
                return ILMath.divide(in1, in2 as /*!HC:inCls2*/ ILArray<double> );
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
		public static  ILArray<UInt64> operator /( ILArray<UInt64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt64> ) {
                return ILMath.divide(in1, in2 as  ILArray<UInt64> );
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
		public static  ILArray<UInt32> operator /( ILArray<UInt32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt32> ) {
                return ILMath.divide(in1, in2 as  ILArray<UInt32> );
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
		public static  ILArray<UInt16> operator /( ILArray<UInt16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<UInt16> ) {
                return ILMath.divide(in1, in2 as  ILArray<UInt16> );
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
		public static  ILArray<Int64> operator /( ILArray<Int64> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int64> ) {
                return ILMath.divide(in1, in2 as  ILArray<Int64> );
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
		public static  ILArray<Int32> operator /( ILArray<Int32> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int32> ) {
                return ILMath.divide(in1, in2 as  ILArray<Int32> );
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
		public static  ILArray<Int16> operator /( ILArray<Int16> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<Int16> ) {
                return ILMath.divide(in1, in2 as  ILArray<Int16> );
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
		public static  ILArray<float> operator /( ILArray<float> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<float> ) {
                return ILMath.divide(in1, in2 as  ILArray<float> );
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
		public static  ILArray<fcomplex> operator /( ILArray<fcomplex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<fcomplex> ) {
                return ILMath.divide(in1, in2 as  ILArray<fcomplex> );
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
		public static  ILArray<complex> operator /( ILArray<complex> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<complex> ) {
                return ILMath.divide(in1, in2 as  ILArray<complex> );
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
		public static  ILArray<char> operator /( ILArray<char> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<char> ) {
                return ILMath.divide(in1, in2 as  ILArray<char> );
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
		public static  ILArray<byte> operator /( ILArray<byte> in1, ILArray<BaseT> in2) {
			if (false) {
            } else if (in2 is  ILArray<byte> ) {
                return ILMath.divide(in1, in2 as  ILArray<byte> );
            }
			throw new Exception("Operator / not defined for " 
                     + in1.GetType().Name + " and " + in2.GetType().Name);
        }


#endregion HYCALPER AUTO GENERATED CODE

        
		/// <summary>
        /// Equalty operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1">first input array</param>
        /// <param name="in2">second input array</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 equal in2's elements, false if they are not equal.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is valid for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentTypeException">thrown if the types 
        /// of input arguments do not match or the operator does not support the ILArray inner type.
        /// </exception>
		public static ILLogicalArray operator ==(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (object.Equals(in1,null)) {
                if (object.Equals(in2,null)) {
                    return true;
                } else {
                    return false; 
                }
            } else {
                if (object.Equals(in2,null)) {
                    return false;
                }
            }
            if (false) {
                #region HYCALPER LOOPSTART EQ
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.eq ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND EQ
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.eq ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.eq ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.eq ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.eq ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.eq ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.eq ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.eq ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.eq ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else if (in1 is ILArray<String> && in2 is ILArray<String>) {
                    return ILMath.eq(in1 as ILArray<String>, in2 as ILArray<String>); 
            } else {
                throw new ILArgumentTypeException("Operator '==' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}

		/// <summary>
        /// Unequalty operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1"><![CDATA[ILArray<>]]></param>
        /// <param name="in2"><![CDATA[ILArray<>]]></param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 and in2 beeing unequal, false if they are equal.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
		public static ILLogicalArray operator !=(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (object.Equals(in1,null)) {
                if (object.Equals(in2,null)) {
                    return false;
                } else {
                    return true; 
                }
           } else {
                if (object.Equals(in2,null)) {
                    return true;
                }
           }
           if (false) {
                #region HYCALPER LOOPSTART NEQ
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.neq ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND NEQ
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.neq ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.neq ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.neq ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.neq ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.neq ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.neq ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.neq ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.neq ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else if (in1 is ILArray<String> && in2 is ILArray<String>) {
                    return ILMath.neq(in1 as ILArray<String>, in2 as ILArray<String>); 
            } else {
                throw new ILArgumentTypeException("Operator '!=' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}
		
        /// <summary>
        /// Greater or equal operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1"><![CDATA[ILArray<>]]></param>
        /// <param name="in2"><![CDATA[ILArray<>]]></param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 are greater or equal in2's elements, false else.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
		public static ILLogicalArray operator >=(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (false) {
                #region HYCALPER LOOPSTART GE
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.ge ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND GE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.ge ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.ge ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.ge ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.ge ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.ge ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.ge ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.ge ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.ge ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '>=' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}
		
        /// <summary>
        /// smaller or equal operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1"><![CDATA[ILArray<>]]></param>
        /// <param name="in2"><![CDATA[ILArray<>]]></param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 smaller or equal in2's elements, false if they are not.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
        public static ILLogicalArray operator <=(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (false) {
                #region HYCALPER LOOPSTART LE
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.le ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND LE
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.le ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.le ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.le ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.le ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.le ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.le ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.le ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.le ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.le ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.le ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.le ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '<=' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}
		
        /// <summary>
        /// greater operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1"><![CDATA[ILArray<>]]></param>
        /// <param name="in2"><![CDATA[ILArray<>]]></param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 greater in2's elements, false if they are not.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
		public static ILLogicalArray operator >(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (false) {
                #region HYCALPER LOOPSTART GT
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.gt ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND GT
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.gt ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.gt ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.gt ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.gt ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.gt ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.gt ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.gt ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.gt ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '>' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}
		
        /// <summary>
        /// smaller operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
        /// </summary>
        /// <param name="in1"><![CDATA[ILArray<>]]></param>
        /// <param name="in2"><![CDATA[ILArray<>]]></param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 smaller as in2's elements, false if they are not.
        /// </returns>
        /// <remarks>Dimension of in1 and in2 must match. This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
        /// type of in2.</remarks>
		public static ILLogicalArray operator <(ILArray<BaseT> in1, ILArray<BaseT> in2) {
            if (false) {
                #region HYCALPER LOOPSTART LT
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
                    return ILMath.lt ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
                #endregion HYCALPER LOOPEND LT
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
                    return ILMath.lt ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
                    return ILMath.lt ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
                    return ILMath.lt ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
                    return ILMath.lt ( in1 as  ILArray<float> , in2 as  ILArray<float> );
            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
                    return ILMath.lt ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
                    return ILMath.lt ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
                    return ILMath.lt ( in1 as  ILArray<char> , in2 as  ILArray<char> );
            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
                    return ILMath.lt ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '<' is not defined for ILArrays of type " 
                        + in1.GetType().Name + " and " + in2.GetType().Name );
            }
		}
		
//        /// <summary>
//        /// and operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
//        /// </summary>
//        /// <param name="in1"><![CDATA[ILArray<>]]></param>
//        /// <param name="in2"><![CDATA[ILArray<>]]></param>
//        /// <returns>ILLogicalArray of same size than in1 or in2, with the rsult of in1 & in2.
//        /// </returns>
//        /// <remarks>Dimension of in1 and in2 must match with the exception of scalar values. This operator is overloaded for 
//        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
//        /// type of in2.</remarks>
//        public static ILLogicalArray operator &(ILArray<BaseT> in1, ILArray<BaseT> in2) {
//            if (false) {
//                #region HYCALPER LOOPSTART LT
//            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
//                    return ILMath.and ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
//                #endregion HYCALPER LOOPEND LT
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
//            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
//                    return ILMath.and ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
//            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
//                    return ILMath.and ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
//            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
//                    return ILMath.and ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
//            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
//                    return ILMath.and ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
//            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
//                    return ILMath.and ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
//            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
//                    return ILMath.and ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
//            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
//                    return ILMath.and ( in1 as  ILArray<float> , in2 as  ILArray<float> );
//            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
//                    return ILMath.and ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
//            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
//                    return ILMath.and ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
//            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
//                    return ILMath.and ( in1 as  ILArray<char> , in2 as  ILArray<char> );
//            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
//                    return ILMath.and ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
//            } else {
//                throw new ILArgumentTypeException("Operator '&' is not defined for ILArrays of type " 
//                        + in1.GetType().Name + " and " + in2.GetType().Name );
//            }
//        }
		
//        /// <summary>
//        /// or operator of <![CDATA[ILArray<>]]> with <![CDATA[ILArray<>]]>
//        /// </summary>
//        /// <param name="in1"><![CDATA[ILArray<>]]></param>
//        /// <param name="in2"><![CDATA[ILArray<>]]></param>
//        /// <returns>ILLogicalArray of same size than in1 or in2, with result of in1 | in2's.
//        /// </returns>
//        /// <remarks>Dimension of in1 and in2 must match with the exception of scalar values. This operator is overloaded for 
//        /// all numeric types of <![CDATA[ILArray<>]]>. The type of in1 must be the same as the 
//        /// type of in2.</remarks>
//        public static ILLogicalArray operator |(ILArray<BaseT> in1, ILArray<BaseT> in2) {
//            if (false) {
//                #region HYCALPER LOOPSTART LT
//            } else if (in1 is /*!HC:inCls1*/ ILArray<double> && in2 is /*!HC:inCls2*/ ILArray<double> ) {
//                    return ILMath.or ( in1 as /*!HC:inCls1*/ ILArray<double> , in2 as /*!HC:inCls2*/ ILArray<double> );
//                #endregion HYCALPER LOOPEND LT
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
//            } else if (in1 is  ILArray<UInt64> && in2 is  ILArray<UInt64> ) {
//                    return ILMath.or ( in1 as  ILArray<UInt64> , in2 as  ILArray<UInt64> );
//            } else if (in1 is  ILArray<UInt32> && in2 is  ILArray<UInt32> ) {
//                    return ILMath.or ( in1 as  ILArray<UInt32> , in2 as  ILArray<UInt32> );
//            } else if (in1 is  ILArray<UInt16> && in2 is  ILArray<UInt16> ) {
//                    return ILMath.or ( in1 as  ILArray<UInt16> , in2 as  ILArray<UInt16> );
//            } else if (in1 is  ILArray<Int64> && in2 is  ILArray<Int64> ) {
//                    return ILMath.or ( in1 as  ILArray<Int64> , in2 as  ILArray<Int64> );
//            } else if (in1 is  ILArray<Int32> && in2 is  ILArray<Int32> ) {
//                    return ILMath.or ( in1 as  ILArray<Int32> , in2 as  ILArray<Int32> );
//            } else if (in1 is  ILArray<Int16> && in2 is  ILArray<Int16> ) {
//                    return ILMath.or ( in1 as  ILArray<Int16> , in2 as  ILArray<Int16> );
//            } else if (in1 is  ILArray<float> && in2 is  ILArray<float> ) {
//                    return ILMath.or ( in1 as  ILArray<float> , in2 as  ILArray<float> );
//            } else if (in1 is  ILArray<fcomplex> && in2 is  ILArray<fcomplex> ) {
//                    return ILMath.or ( in1 as  ILArray<fcomplex> , in2 as  ILArray<fcomplex> );
//            } else if (in1 is  ILArray<complex> && in2 is  ILArray<complex> ) {
//                    return ILMath.or ( in1 as  ILArray<complex> , in2 as  ILArray<complex> );
//            } else if (in1 is  ILArray<char> && in2 is  ILArray<char> ) {
//                    return ILMath.or ( in1 as  ILArray<char> , in2 as  ILArray<char> );
//            } else if (in1 is  ILArray<byte> && in2 is  ILArray<byte> ) {
//                    return ILMath.or ( in1 as  ILArray<byte> , in2 as  ILArray<byte> );

#endregion HYCALPER AUTO GENERATED CODE
//            } else {
//                throw new ILArgumentTypeException("Operator '|' is not defined for ILArrays of type " 
//                        + in1.GetType().Name + " and " + in2.GetType().Name );
//            }
//        }
		
        
        /// <summary>
        /// Equalty operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 equal in2, false if they are not.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator ==(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.eq ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.eq ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.eq ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.eq ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.eq ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.eq ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.eq ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.eq ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.eq ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.eq ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '==' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}
        
        /// <summary>
        /// Unequalty operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 not equal in2, false if they are equal.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator !=(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.neq ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.neq ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.neq ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.neq ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.neq ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.neq ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.neq ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.neq ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.neq ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.neq ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '!=' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}
        
        /// <summary>
        /// Greater or equal operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 are greater or equal in2, false if they are not.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator >=(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.ge ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.ge ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.ge ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.ge ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.ge ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.ge ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.ge ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.ge ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.ge ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.ge ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '>=' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}
        
        /// <summary>
        /// Smaller or equal operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 beeing smaller or equal in2, false if they are not.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator <=(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.le ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.le ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.le ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.le ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.le ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.le ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.le ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.le ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.le ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.le ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.le ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.le ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '<=' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}
        
        /// <summary>
        /// Greater operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 beeing greater in2, false if they are not.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator >(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.gt ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.gt ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.gt ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.gt ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.gt ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.gt ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.gt ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.gt ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.gt ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.gt ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '>' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}
        
        /// <summary>
        /// Smaller operator of <![CDATA[ILArray<>]]> with scalar
        /// </summary>
        /// <param name="in1">ILArray</param>
        /// <param name="in2">Scalar</param>
        /// <returns>ILLogicalArray of same size than in1, with elements having 'true' values 
        /// for all corresponding elements of in1 beeing smaller in2, false if they are not.
        /// </returns>
        /// <remarks>This operator is overloaded for 
        /// all numeric types of <![CDATA[ILArray<>]]> for in1. The type of in2 is always double. </remarks>
		public static ILLogicalArray operator <(ILArray<BaseT> in1, double in2) {
            if (false) {
                #region HYCALPER LOOPSTART
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                    return ILMath.lt ( in1 as /*!HC:inCls1*/ ILArray<double> , (/*!HC:inArr2*/ double ) in2 );
                #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (in1 is  ILArray<UInt64> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt64> , ( UInt64 ) in2 );
            } else if (in1 is  ILArray<UInt32> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt32> , ( UInt32 ) in2 );
            } else if (in1 is  ILArray<UInt16> ) {
                    return ILMath.lt ( in1 as  ILArray<UInt16> , ( UInt16 ) in2 );
            } else if (in1 is  ILArray<Int64> ) {
                    return ILMath.lt ( in1 as  ILArray<Int64> , ( Int64 ) in2 );
            } else if (in1 is  ILArray<Int32> ) {
                    return ILMath.lt ( in1 as  ILArray<Int32> , ( Int32 ) in2 );
            } else if (in1 is  ILArray<Int16> ) {
                    return ILMath.lt ( in1 as  ILArray<Int16> , ( Int16 ) in2 );
            } else if (in1 is  ILArray<float> ) {
                    return ILMath.lt ( in1 as  ILArray<float> , ( float ) in2 );
            } else if (in1 is  ILArray<fcomplex> ) {
                    return ILMath.lt ( in1 as  ILArray<fcomplex> , ( fcomplex ) in2 );
            } else if (in1 is  ILArray<complex> ) {
                    return ILMath.lt ( in1 as  ILArray<complex> , ( complex ) in2 );
            } else if (in1 is  ILArray<char> ) {
                    return ILMath.lt ( in1 as  ILArray<char> , ( char ) in2 );
            } else if (in1 is  ILArray<byte> ) {
                    return ILMath.lt ( in1 as  ILArray<byte> , ( byte ) in2 );

#endregion HYCALPER AUTO GENERATED CODE
            } else {
                throw new ILArgumentTypeException("Operator '<' is not defined for ILArrays of type " 
                        + in1.GetType().Name);
            }
		}

        /// <summary>
		/// Implicitly convert scalar to ILArray of size 1x1 (scalar).
		/// </summary>
		/// <param name="val">System type of size scalar</param>
        /// <returns> New ILArray of type ILArray <![CDATA[<typeof(val)>]]> of size 1x1 
        /// holding the only element with value of val.
        /// </returns>
		public static implicit operator ILArray<BaseT> (BaseT val) {
            return new ILArray<BaseT>(new BaseT[1]{val});
		}
        /// <summary>
        /// implicit cast 1-dim. system array to ILArray (vector)
        /// </summary>
        /// <param name="vector_elements">1d system array arbitrary type</param>
        /// <returns>ILArray of same type as elements - built as row vector. Empty array if input is null.</returns>
        public static implicit operator ILArray<BaseT> (BaseT[] vector_elements) {
            if (vector_elements == null) {
                return ILArray<BaseT>.empty();
            }
            return new ILArray<BaseT>(vector_elements,1,vector_elements.Length); 
        }
        /// <summary>
        /// implicit cast n-dim. system array to ILArray
        /// </summary>
        /// <param name="elements">arbitrary sized System.Array</param>
        /// <returns>If elements is null: empty array. Else: ILArray of same size as elements</returns>
        /// <remarks>The inner type of input array <paramref name="elements"/> must match the requested type <typeparamref name="BaseT"/>. The resulting ILArray will reflect all dimensions of the input. Elements of input array will get copied to elements of output array (shallow copy).</remarks>
        /// <exception cref="ILNumerics.Exceptions.ILCastException"> if type of input does not match requested type BaseT</exception>
        public static implicit operator ILArray<BaseT> (Array elements) {
            if (elements == null) {
                return ILArray<BaseT>.empty();
            }
            if (elements.GetType().GetElementType() != typeof(BaseT)) 
                throw new ILCastException("cast: inner type of System.Array must match!"); 
            int [] dims = new int[elements.Rank]; 
            BaseT [] retArr = ILMemoryPool.Pool.New<BaseT>(elements.Length);
            int posArr = 0; 
            for (int i = 0; i < dims.Length; i++) {
                dims[i] = elements.GetLength(dims.Length-i-1);
            }
            foreach (BaseT item in elements) 
                retArr[posArr++] = item; 
            return new ILArray<BaseT>(retArr,dims);
        }
        /// <summary>
		/// Explicitly convert ILArray of size 1x1 (scalar) to system value type.
		/// </summary>
		/// <param name="val">ILArray of type ILArray <![CDATA[BaseT]]> of size 1x1</param>
        /// <returns> System type of size scalar holding the only element with value of val.
        /// </returns>
        /// <exception cref="ILNumerics.Exceptions.ILCastException"> if input ILArray is not scalar</exception>
		public static explicit operator BaseT (ILArray<BaseT> val) {
            if (! val.IsScalar) 
                throw new ILCastException("Cannot convert array to scalar!"); 
            return val.GetValue(0);
		}
        /// <summary>
        /// negate elements of array - if applicable
        /// </summary>
        /// <param name="in1">input array</param>
        /// <returns>new solid arrray having the elements of in1 negated</returns>
        public static ILArray<BaseT> operator -(ILArray<BaseT> in1) {
            if (object.Equals(in1,null))
                throw new ILArgumentException("operator -(): parameter must not be null!");
            BaseT[] retArr = ILMemoryPool.Pool.New<BaseT>(in1.Dimensions.NumberOfElements);
            ILArray<BaseT> ret = new ILArray<BaseT>(retArr,in1.Dimensions.Clone()); 
            if (false) {
            } else if (in1 is /*!HC:inCls1*/ ILArray<double> ) {
                ILMath.invert (in1 as ILArray<double>,ret as ILArray<double>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<float> ) {
                ILMath.invert (in1 as ILArray<float>,ret as ILArray<float>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<complex> ) {
                ILMath.invert (in1 as ILArray<complex>,ret as ILArray<complex>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<fcomplex> ) {
                ILMath.invert (in1 as ILArray<fcomplex>,ret as ILArray<fcomplex>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<Int16> ) {
                ILMath.invert (in1 as ILArray<Int16>,ret as ILArray<Int16>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<Int32> ) {
                ILMath.invert (in1 as ILArray<Int32>,ret as ILArray<Int32>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<Int64> ) {
                ILMath.invert (in1 as ILArray<Int64>,ret as ILArray<Int64>);  
            } else if (in1 is /*!HC:inCls1*/ ILArray<byte> ) {
                ILMath.invert (in1 as ILArray<byte>,ret as ILArray<byte>);  
            } else {
                throw new ILArgumentException("unary - operator not defined for arrays of type '" + in1.GetType().Name + "'!"); 
            }
            return ret; 
        }
 	}
}