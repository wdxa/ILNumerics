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
        inArr1
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
    <source locate="nextline">
        HCnullValue
    </source>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0).real != 0.0 || X.GetValue(0,0).imag != 0.0)</destination>
    <destination>if (X.GetValue(0,0).real != 0.0 || X.GetValue(0,0).imag != 0.0)</destination>
    <destination>if (X.GetValue(0,0) != 0.0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
    <destination>if (X.GetValue(0,0) != 0)</destination>
</type>
<type>
    <source locate="nextline">
        HCcompare0
    </source>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)</destination>
    <destination>if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)</destination>
    <destination>if (*tmpIn != 0.0f)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
</type>
<type>
    <source locate="nextline">
        HCreferenceComp
    </source>
    <destination>if (*(pInArr + idxOffset.Map(i)) != 0.0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)</destination>
    <destination>if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)</destination>
    <destination>if (*tmpIn != 0.0f)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
    <destination>if (*tmpIn != 0)</destination>
</type>
<type>
    <source locate="nextline">
        locicalAbbrev
    </source>
    <destination>if (X is ILLogicalArray) nrElements = ((ILLogicalArray)X).NumberTrues;</destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
</type></hycalper>
 */

namespace ILNumerics.Untyped {
    /// <summary>
    /// general math class. This is in an experimental state! 
    /// </summary>
    public partial class ILMath {
        #region untyped object handler interface
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outValue">Array of BaseArray of output parameter. outValue must be 
        /// at least of lenght 1, at most of length 3. The meanings are: 
        /// <list type="bullet">
        /// <item>One parameter: the sequential indices of all nonzero elements of X are returned.</item>
        /// <item>Two parameter: The first BaseArray returned in 'outValue' will hold the row indices of 
        /// nonzero elements of X, the second BaseArray will hold the column indices of those nonzero elements.</item>
        /// <item>If Length of outValue is 3, the rows and columns of nonzero elements are returned as the 
        /// first and second BaseArray elements. The third array will hold a (shallow) copy of those 
        /// nonzero elements found.</item>
        /// </list>
        /// </param>
        /// <param name="X">Array of input parameter. This must be at least 1 BaseArray holding 
        /// the input array for evaluation. If this array has length of 2, the second element must 
        /// be a scalar array of type <![CDATA[ILArray<double> or ILArray<int> or ILArray<float> or ILArray<byte>]]> 
        /// specifying the integer number of values to be returned. If this value is smaller 0, Find will 
        /// return that number of nonzero elements of X from the end of X.</param>
        /// <remarks>In order to specify the mode of Find, the length of the arrays 'outValue' and 
        /// 'X' will be recognized only. Any initial values of elements in 'outValue' will 
        /// be destroyed. The elements of X will not be altered.</remarks>
        public static void Find(ILBaseArray [] outValue, params ILBaseArray [] X) {
            if (outValue.Length > 3)
                throw new ILException ( "Find: Too many out parameters specified." );
            if (outValue.Length < 1)
                throw new ILException ( "Find: Too less out parameters specified." );
            if (X.Length < 1)
                throw new ILException ( "Find: Input array must be specified." );
            if (X.Length > 2)
                throw new ILException ( "Find: Too many parameters specified. At most 2 parameters allowed." );
            int limit = 0;
            if (X.Length == 2) {
                if (!X[1].IsScalar)
                    throw new ILArgumentSizeException ( "Find: the 'limit' parameter must be integer and scalar!" );
                if (X [1] is ILArray<double>)
                    limit = (int) ( (ILArray<double>) X [1] ).GetValue(0);
                else if (X [1] is ILArray<float>)
                    limit = (int) ( (ILArray<float>) X [1] ).GetValue(0);
                else if (X [1] is ILArray<int>)
                    limit = ( (ILArray<int>) X[1]).GetValue(0);
                else if (X [1] is ILArray<Int32>)
                    limit = (int) ( (ILArray<Int32>) X [1] ).GetValue(0);
                else if (X [1] is ILArray<Int64>)
                    limit = (int) ( (ILArray<Int64>) X [1] ).GetValue(0);
                else if (X [1] is ILArray<byte>)
                    limit = (int) ( (ILArray<byte>) X [1] ).GetValue(0);
                else if (X [1] is ILArray<char>)
                    limit = (int) ( (ILArray<char>) X [1] ).GetValue(0);
                else
                    throw new ILArgumentTypeException ( "Find: Limit parameter must be of any signed numeric type and must not be complex." );
            }  
            ILArray<double> C = null; 
            if (outValue.Length > 1) C = ILArray<double>.empty(); 
            if (false) {
            #region HYCALPER LOOPSTART UNTYPED 
            } else if (X[0] is /*!HC:inCls1*/ ILArray<double> )  {
                /*!HC:inCls1*/ ILArray<double> V = null; 
                if (outValue.Length == 3)
                    V = /*!HC:inCls1*/ ILArray<double> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( (/*!HC:inCls1*/ ILArray<double> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            #endregion HYCALPER LOOPEND UNTYPED
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
            } else if (X[0] is  ILArray<UInt64> )  {
                ILArray<UInt64> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<UInt64> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<UInt64> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<UInt32> )  {
                ILArray<UInt32> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<UInt32> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<UInt32> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<UInt16> )  {
                ILArray<UInt16> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<UInt16> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<UInt16> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<Int64> )  {
                ILArray<Int64> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<Int64> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<Int64> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<Int32> )  {
                ILArray<Int32> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<Int32> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<Int32> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<Int16> )  {
                ILArray<Int16> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<Int16> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<Int16> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<float> )  {
                ILArray<float> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<float> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<float> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<fcomplex> )  {
                ILArray<fcomplex> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<fcomplex> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<fcomplex> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<complex> )  {
                ILArray<complex> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<complex> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<complex> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<char> )  {
                ILArray<char> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<char> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<char> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 
            } else if (X[0] is  ILArray<byte> )  {
                ILArray<byte> V = null; 
                if (outValue.Length == 3)
                    V =  ILArray<byte> .empty();
                outValue[0] = ILNumerics.BuiltInFunctions.ILMath.find ( ( ILArray<byte> ) X [0], limit, ref C, ref V);
                if (outValue.Length > 1) 
                    outValue[1] = C; 
                if (outValue.Length == 3)
                    outValue[2] = V; 
                return; 

#endregion HYCALPER AUTO GENERATED CODE

            } else {
                throw new ILException ( "Function 'Find' is not defined for Arrays of Type "
                    + X [0].GetType ().ToString () );
            }
        }
        #endregion untyped object handler interface
    }
}

namespace ILNumerics.BuiltInFunctions {
	public partial class ILMath {
        #region HYCALPER LOOPSTART FIND(X)
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find(/*!HC:inCls1*/ ILArray<double> X) {
            ILArray<double> R = null; 
            /*!HC:inCls1*/ ILArray<double> V = null;
            return find(X,0,ref R,ref V);
        }
        #endregion HYCALPER LOOPEND FIND(X)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<UInt64> X) {
            ILArray<double> R = null; 
            ILArray<UInt64> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<UInt32> X) {
            ILArray<double> R = null; 
            ILArray<UInt32> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<UInt16> X) {
            ILArray<double> R = null; 
            ILArray<UInt16> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<Int64> X) {
            ILArray<double> R = null; 
            ILArray<Int64> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<Int32> X) {
            ILArray<double> R = null; 
            ILArray<Int32> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<Int16> X) {
            ILArray<double> R = null; 
            ILArray<Int16> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<float> X) {
            ILArray<double> R = null; 
            ILArray<float> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<fcomplex> X) {
            ILArray<double> R = null; 
            ILArray<fcomplex> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<complex> X) {
            ILArray<double> R = null; 
            ILArray<complex> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<char> X) {
            ILArray<double> R = null; 
            ILArray<char> V = null;
            return find(X,0,ref R,ref V);
        }
        /// <summary>
        /// Find nonzero elements of X
        /// </summary>
        /// <param name="X">N-dimensional double array</param>
        /// <returns>vector with sequential indices of X elements 
        /// having a value not equal to 0.0. 
        /// </returns>
        public static ILArray<double> find( ILArray<byte> X) {
            ILArray<double> R = null; 
            ILArray<byte> V = null;
            return find(X,0,ref R,ref V);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART FIND(X,limit)
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find(/*!HC:inCls1*/ ILArray<double> X, int limit) {
            ILArray<double> C = null; 
            /*!HC:inCls1*/ ILArray<double> V = null;
            return find(X,limit,ref C,ref V);
        }
        #endregion HYCALPER LOOPEND FIND(X,limit)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<UInt64> X, int limit) {
            ILArray<double> C = null; 
            ILArray<UInt64> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<UInt32> X, int limit) {
            ILArray<double> C = null; 
            ILArray<UInt32> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<UInt16> X, int limit) {
            ILArray<double> C = null; 
            ILArray<UInt16> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<Int64> X, int limit) {
            ILArray<double> C = null; 
            ILArray<Int64> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<Int32> X, int limit) {
            ILArray<double> C = null; 
            ILArray<Int32> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<Int16> X, int limit) {
            ILArray<double> C = null; 
            ILArray<Int16> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<float> X, int limit) {
            ILArray<double> C = null; 
            ILArray<float> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<fcomplex> X, int limit) {
            ILArray<double> C = null; 
            ILArray<fcomplex> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<complex> X, int limit) {
            ILArray<double> C = null; 
            ILArray<complex> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<char> X, int limit) {
            ILArray<double> C = null; 
            ILArray<char> V = null;
            return find(X,limit,ref C,ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        public static ILArray<double> find( ILArray<byte> X, int limit) {
            ILArray<double> C = null; 
            ILArray<byte> V = null;
            return find(X,limit,ref C,ref V);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART FIND(X,limit,C)
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find(/*!HC:inCls1*/ ILArray<double> X, int limit, ref ILArray<double> C) {
            /*!HC:inCls1*/ ILArray<double> V = null; 
            return find(X, limit, ref C, ref V);
        }
        #endregion HYCALPER LOOPEND FIND(X,limit,C)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<UInt64> X, int limit, ref ILArray<double> C) {
            ILArray<UInt64> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<UInt32> X, int limit, ref ILArray<double> C) {
            ILArray<UInt32> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<UInt16> X, int limit, ref ILArray<double> C) {
            ILArray<UInt16> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<Int64> X, int limit, ref ILArray<double> C) {
            ILArray<Int64> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<Int32> X, int limit, ref ILArray<double> C) {
            ILArray<Int32> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<Int16> X, int limit, ref ILArray<double> C) {
            ILArray<Int16> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<float> X, int limit, ref ILArray<double> C) {
            ILArray<float> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<fcomplex> X, int limit, ref ILArray<double> C) {
            ILArray<fcomplex> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<complex> X, int limit, ref ILArray<double> C) {
            ILArray<complex> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<char> X, int limit, ref ILArray<double> C) {
            ILArray<char> V = null; 
            return find(X, limit, ref C, ref V);
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        public static ILArray<double> find( ILArray<byte> X, int limit, ref ILArray<double> C) {
            ILArray<byte> V = null; 
            return find(X, limit, ref C, ref V);
        }

#endregion HYCALPER AUTO GENERATED CODE

        #region HYCALPER LOOPSTART FIND(X,limit,C,V)
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find(/*!HC:inCls1*/ ILArray<double> X, int limit,
                      ref ILArray<double> C, ref /*!HC:inCls1*/ ILArray<double> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                /*!HC:HCnullValue*/
                if (X.GetValue(0, 0) != 0.0) 
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new /*!HC:inCls1*/ ILArray<double> (new /*!HC:inArr1*/ double [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V = /*!HC:inCls1*/ ILArray<double> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            /*!HC:locicalAbbrev*/

            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed (/*!HC:inArr1*/ double * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                                /*!HC:HCrefComp0*/
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed (/*!HC:inArr1*/ double * pX = X.m_data) {
                            /*!HC:inArr1*/ double * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                                /*!HC:HCrefComp0*/
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed (/*!HC:inArr1*/ double * pX = X.m_data) {
                            /*!HC:inArr1*/ double * lastElement = pX + inDim.NumberOfElements;
                            /*!HC:inArr1*/ double * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                /*!HC:HCcompare0*/
                                if (*tmpIn != 0.0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed (/*!HC:inArr1*/ double * pX = X.m_data) {
                            /*!HC:inArr1*/ double * lastElementX = pX; 
                            /*!HC:inArr1*/ double * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                /*!HC:HCcompare0*/
                                if (*tmpIn != 0.0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new /*!HC:inCls1*/ ILArray<double> ( ILMemoryPool.Pool.New< /*!HC:inArr1*/ double >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed (/*!HC:inArr1*/ double * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            /*!HC:inArr1*/ double * pV = pValues;
                            /*!HC:inArr1*/ double * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed (/*!HC:inArr1*/ double * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND FIND(X,limit,C,V)
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<UInt64> X, int limit,
                      ref ILArray<double> C, ref  ILArray<UInt64> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<UInt64> (new  UInt64 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<UInt64> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt64 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt64 * pX = X.m_data) {
                            UInt64 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt64 * pX = X.m_data) {
                            UInt64 * lastElement = pX + inDim.NumberOfElements;
                            UInt64 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt64 * pX = X.m_data) {
                            UInt64 * lastElementX = pX; 
                            UInt64 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<UInt64> ( ILMemoryPool.Pool.New<  UInt64 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt64 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            UInt64 * pV = pValues;
                            UInt64 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt64 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<UInt32> X, int limit,
                      ref ILArray<double> C, ref  ILArray<UInt32> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<UInt32> (new  UInt32 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<UInt32> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt32 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt32 * pX = X.m_data) {
                            UInt32 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt32 * pX = X.m_data) {
                            UInt32 * lastElement = pX + inDim.NumberOfElements;
                            UInt32 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt32 * pX = X.m_data) {
                            UInt32 * lastElementX = pX; 
                            UInt32 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<UInt32> ( ILMemoryPool.Pool.New<  UInt32 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt32 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            UInt32 * pV = pValues;
                            UInt32 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt32 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<UInt16> X, int limit,
                      ref ILArray<double> C, ref  ILArray<UInt16> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<UInt16> (new  UInt16 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<UInt16> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt16 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt16 * pX = X.m_data) {
                            UInt16 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt16 * pX = X.m_data) {
                            UInt16 * lastElement = pX + inDim.NumberOfElements;
                            UInt16 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( UInt16 * pX = X.m_data) {
                            UInt16 * lastElementX = pX; 
                            UInt16 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<UInt16> ( ILMemoryPool.Pool.New<  UInt16 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt16 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            UInt16 * pV = pValues;
                            UInt16 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( UInt16 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<Int64> X, int limit,
                      ref ILArray<double> C, ref  ILArray<Int64> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<Int64> (new  Int64 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<Int64> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int64 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int64 * pX = X.m_data) {
                            Int64 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int64 * pX = X.m_data) {
                            Int64 * lastElement = pX + inDim.NumberOfElements;
                            Int64 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int64 * pX = X.m_data) {
                            Int64 * lastElementX = pX; 
                            Int64 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<Int64> ( ILMemoryPool.Pool.New<  Int64 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int64 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            Int64 * pV = pValues;
                            Int64 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int64 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<Int32> X, int limit,
                      ref ILArray<double> C, ref  ILArray<Int32> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<Int32> (new  Int32 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<Int32> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int32 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int32 * pX = X.m_data) {
                            Int32 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int32 * pX = X.m_data) {
                            Int32 * lastElement = pX + inDim.NumberOfElements;
                            Int32 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int32 * pX = X.m_data) {
                            Int32 * lastElementX = pX; 
                            Int32 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<Int32> ( ILMemoryPool.Pool.New<  Int32 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int32 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            Int32 * pV = pValues;
                            Int32 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int32 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<Int16> X, int limit,
                      ref ILArray<double> C, ref  ILArray<Int16> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<Int16> (new  Int16 [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<Int16> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int16 * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int16 * pX = X.m_data) {
                            Int16 * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int16 * pX = X.m_data) {
                            Int16 * lastElement = pX + inDim.NumberOfElements;
                            Int16 * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( Int16 * pX = X.m_data) {
                            Int16 * lastElementX = pX; 
                            Int16 * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<Int16> ( ILMemoryPool.Pool.New<  Int16 >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int16 * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            Int16 * pV = pValues;
                            Int16 * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( Int16 * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<float> X, int limit,
                      ref ILArray<double> C, ref  ILArray<float> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0.0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<float> (new  float [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<float> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( float * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( float * pX = X.m_data) {
                            float * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( float * pX = X.m_data) {
                            float * lastElement = pX + inDim.NumberOfElements;
                            float * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0.0f)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( float * pX = X.m_data) {
                            float * lastElementX = pX; 
                            float * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0.0f)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<float> ( ILMemoryPool.Pool.New<  float >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( float * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            float * pV = pValues;
                            float * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( float * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<fcomplex> X, int limit,
                      ref ILArray<double> C, ref  ILArray<fcomplex> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0).real != 0.0 || X.GetValue(0,0).imag != 0.0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<fcomplex> (new  fcomplex [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<fcomplex> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( fcomplex * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( fcomplex * pX = X.m_data) {
                            fcomplex * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( fcomplex * pX = X.m_data) {
                            fcomplex * lastElement = pX + inDim.NumberOfElements;
                            fcomplex * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( fcomplex * pX = X.m_data) {
                            fcomplex * lastElementX = pX; 
                            fcomplex * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<fcomplex> ( ILMemoryPool.Pool.New<  fcomplex >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( fcomplex * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            fcomplex * pV = pValues;
                            fcomplex * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( fcomplex * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<complex> X, int limit,
                      ref ILArray<double> C, ref  ILArray<complex> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0).real != 0.0 || X.GetValue(0,0).imag != 0.0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<complex> (new  complex [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<complex> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( complex * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( complex * pX = X.m_data) {
                            complex * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( complex * pX = X.m_data) {
                            complex * lastElement = pX + inDim.NumberOfElements;
                            complex * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( complex * pX = X.m_data) {
                            complex * lastElementX = pX; 
                            complex * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if ((*tmpIn).real != 0.0 || (*tmpIn).imag != 0.0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<complex> ( ILMemoryPool.Pool.New<  complex >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( complex * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            complex * pV = pValues;
                            complex * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( complex * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<char> X, int limit,
                      ref ILArray<double> C, ref  ILArray<char> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<char> (new  char [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<char> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( char * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( char * pX = X.m_data) {
                            char * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( char * pX = X.m_data) {
                            char * lastElement = pX + inDim.NumberOfElements;
                            char * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( char * pX = X.m_data) {
                            char * lastElementX = pX; 
                            char * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<char> ( ILMemoryPool.Pool.New<  char >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( char * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            char * pV = pValues;
                            char * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( char * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }
        /// <summary>
        /// Find nonzero elements in X
        /// </summary>
        /// <param name="X">input array to be evaluated</param>
        /// <param name="limit">number of elements to search for. If this value is <![CDATA[< 0]]> the function 
        /// will return at most 'limit' nonzero elements from the end of the array ordered by ascending index.
        /// Set to 0 to search full array.</param>
        /// <param name="C">If not null, the function will return the row indices of nonzero elements 
        /// as main return value. C will therefore hold the column indices of those elements. If X
        /// has more than 2 dimensions, the column indices will go along the 2nd dimension.</param>
        /// <param name="V">if not null on entrance, V will hold a copy of the values of nonzero elements returned.</param>
        /// <returns>Vector containing (sequential) indices of nonzero elements in X. If C was 
        /// not null, return value will contain row indices of nonzero elements. </returns>
        /// <remarks>The return type of the index vectors is always 'double'. The return type 
        /// of the element vector 'V' depends on the type of input array X. V and C may be null on 
        /// entrance, indicating their information is not needed. If V is not null (f.e. 'empty()') C must be 
        /// not null also. Any initial data of V or C will be lost.</remarks>
        public static ILArray<double> find( ILArray<byte> X, int limit,
                      ref ILArray<double> C, ref  ILArray<byte> V) {
            double[] retArray;
            bool create_row_columns = !Object.Equals(C, null);
            bool return_values = !Object.Equals(V, null); 
            ILArray<double> ret = null;
            ILDimension inDim = X.Dimensions;
            if (inDim.NumberOfElements == 1) {
                #region SCALAR
                // scalar -> return copy
                if (X.GetValue(0,0) != 0)
                {
                    retArray = new double[1] { 0 };
                    if (create_row_columns) {
                        C = new ILArray<double>(0.0); 
                    }
                    if (return_values) {
                        V = new  ILArray<byte> (new  byte [1]{X.GetValue(0, 0)}); 
                    }
                    return new ILArray<double>(retArray, 1, 1);
                } else {
                    if (create_row_columns) {
                        C = ILArray<double>.empty();
                    }
                    if (return_values) {
                        V =  ILArray<byte> .empty();
                    }
                    return ILArray<double>.empty();
                }
                #endregion SCALAR
            }
            double[] indices;
            int nrElements = inDim.NumberOfElements;
            if (X is ILLogicalArray) nrElements = ((ILLogicalArray)X).NumberTrues;
            if (limit != 0) {
                int lim = Math.Abs ( limit );
                if (lim < nrElements)
                    nrElements = lim;
            }
            indices = ILMemoryPool.Pool.New<double>(nrElements); // init return array with most elements for non logical inarray -> shorten afterwards 
            int foundIdx = 0;
            if (X.IsReference) {
                #region Reference storage
                // ========================  REFERENCE Storage ===========
                ILIndexOffset idxOffset = X.m_indexOffset;
                if (limit >= 0) {
                     unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( byte * pX = X.m_data) {
                            double* pI = pIndices;
                            double* pFoundLast = pIndices + indices.Length;
                            int i = 0; 
                            int nrX = inDim.NumberOfElements;
                            while (i < nrX && pI < pFoundLast) {
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *pI++ = i;
                                i++;
                            }
                            foundIdx = (int)( pI - pIndices );
                        }
                    }
               } else {
                   // search backwards 
                   unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( byte * pX = X.m_data) {
                            byte * lastElementX = pX; 
                            double* pI = pIndices + indices.Length;
                            int i = inDim.NumberOfElements; 
                            while (i > 0 && pI > pIndices) {
                                i--;
                               
                                if (*(pX + idxOffset.Map(i)) != 0.0)
                                    *(--pI) = i;
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }                
                #endregion
            } else {
                #region physical
                // physical -> pointer arithmetic
                if (limit >= 0) {
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( byte * pX = X.m_data) {
                            byte * lastElement = pX + inDim.NumberOfElements;
                            byte * tmpIn = pX;
                            double* pI = pIndices;
                            double* pFoundLast = pI + indices.Length;
                            while (tmpIn < lastElement && pI < pFoundLast) {
                                if (*tmpIn != 0)
                                    *pI++ = (double) ( tmpIn - pX );
                                tmpIn++;
                            }
                            foundIdx = (int) ( pI - pIndices );
                        }
                    }
                } else {
                    // search backwards 
                    unsafe {
                        fixed (double* pIndices = indices)
                        fixed ( byte * pX = X.m_data) {
                            byte * lastElementX = pX; 
                            byte * tmpIn = pX + inDim.NumberOfElements;
                            double* pI = pIndices + indices.Length;
                            while (tmpIn > lastElementX && pI > pIndices) {
                                tmpIn--;
                                if (*tmpIn != 0)
                                    *(--pI) = (double) ( tmpIn - pX );
                            }
                            foundIdx = (int) ( pIndices + indices.Length - pI );
                        }
                    }
                }
                #endregion
            }
            if (foundIdx == 0) {
                // return empty array
                return ILArray<double>.empty();
            }
            // transform to row / columns; extract values if needed
            int leadDimLen = inDim[0]; 
            if (create_row_columns) {
                #region RETURN ROWS / COLUMNS /VALUES
                C = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                if (return_values) {
                    V = new  ILArray<byte> ( ILMemoryPool.Pool.New<  byte >(foundIdx), foundIdx, 1 );
                    // copy values, transform to row/columns
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( byte * pValues = V.m_data, pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            byte * pV = pValues;
                            byte * pX = pInput;
                            if (!X.IsReference) {
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + (int) *pI++ );
                                }
                            } else {
                                ILIndexOffset idxOffset = X.m_indexOffset; 
                                while (pI < pLastIndex) {
                                    *pR++ = *( pI ) % leadDimLen;
                                    *pC++ = (int) *( pI ) / leadDimLen;
                                    *pV++ = *( pInput + idxOffset.Map((int)*pI++) );
                                }
                            }
                        }
                    }
                } else {
                    // just return row / columns 
                    unsafe {
                        fixed (double* pIndices = indices,
                               pRows = ret.m_data, pCols = C.m_data)
                        fixed ( byte * pInput = X.m_data) {
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            double* pC = pCols;
                            while (pI < pLastIndex) {
                                *pR++ = *(pI) % leadDimLen; 
                                *pC++ = (int)(*(pI++) / leadDimLen); 
                            }
                        }
                    }
                }
                #endregion RETURN ROWS / COLUMNS 
            } else {
                #region RETURN INDICES ONLY 
                if (foundIdx != indices.Length) {
                    ret = new ILArray<double> ( ILMemoryPool.Pool.New<double>(foundIdx), foundIdx, 1 );
                    unsafe {
                        fixed (double* pIndices = indices, pRows = ret.m_data){
                            double* pI = (limit >= 0) ? 
                                    pIndices : (pIndices + indices.Length - foundIdx);
                            double* pLastIndex = pIndices + foundIdx;
                            double* pR = pRows;
                            while (pI < pLastIndex) {
                                *pR++ = *pI++;
                            }
                        }
                    }
                } else {
                    ret = new ILArray<double> (indices, foundIdx, 1);
                }
                #endregion RETURN INDICES ONLY
            }
            return ret; 
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
