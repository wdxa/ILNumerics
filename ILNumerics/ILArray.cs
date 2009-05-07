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
using System.IO; 
using System.Runtime.Serialization; 
using System.Runtime.CompilerServices;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions; 

[assembly:InternalsVisibleTo("ILNumericsTest, PublicKey=0024000004800000940000000602000000240000525341310004000001000100bb4dc9610b0cfe6f698d933c322979c2c69d17f119c94e6a182426ead00f8972014ef3cf8ba4c2499eaf3c314775b32d152a67375d0a48f4d2617c82b72e0a8fa0684c757366bbda6adc6a0c4fed35e73eece3c55e3dd51636dc32acf0d443a0a8033f9206854cfec8e35b8c8c2f7447cac8c52b6d88fcd3d4f72b64e295e2b2")]

namespace ILNumerics {
    /// <summary>
    /// Main rectangular generic array type. Objects of this class are able to build references.
    /// </summary>
    /// <typeparam name="BaseT">inner type. This will mostly be a system numeric type or a 
    /// complex floating point type.</typeparam>
    /// <remarks> This class serves as the main rectangular array holding arbitrary elements 
    /// in arbitrary dimensions. The most common specialisation will be a numeric array of arbitrary size. 
    /// <para>The most significant property of ILArray's is the ability to create, hold and handle references of other 
    /// ILArray's. Those references act like a solid array to the outside world but consume only a very little 
    /// memory itself. Therefore they directly use the elements of the original array for computations and only 
    /// store access rules in a very economical yet performant way. Write access to any arrays involved is 
    /// controlled by internal reference counting. The references are detached accordingly. That behavior 
    /// may also get flexible adjusted by the user of the library due to the 
    /// <see cref="ILDetachingBehavior">ILDetachingBehavior</see> property. </para>
    /// <para>The inner type of the elements (specified through the generic parameter BaseT)
    /// does not change the general behavior of the ILArray<![CDATA[<>]]>. However, if it comes 
    /// to mathematical operations there is a limited number 
    /// of inner types common mathematical functions and operators are defined for. All basic 
    /// operations (+,-,*,/,<![CDATA[<,>,<=]]>,etc.) are defined for all ILArray's having 
    /// the inner type BaseT of a numeric type (system defined like 'double','int' - or complex, fcomplex).
    /// Some functions are defined for even less types. This is the case mostly for all linear algebraic functions 
    /// explicilty involving matrices or vectors (LAPACK) and for trigonometric functions and those, 
    /// wich explicitly return floating point values (cos, atan etc.). Therefore you may create ILArrays 
    /// of arbitrary types, but might not be able to use them afterwards in other then some basic 
    /// operations defined for all ILArrays - regardless of the inner type - like concatenation, (de)serialization and 
    /// string exports. </para>
    /// </remarks>
    /// <seealso cref="ILBaseArray"/>
    [Serializable]
    [System.Diagnostics.DebuggerTypeProxy(typeof(ILArrayDebuggerProxy<>))]
    [System.Diagnostics.DebuggerDisplay("{debuggerHeadLineDisplay(),nq}")]
    public partial class ILArray<BaseT> : ILBaseArray<BaseT>,IDisposable {

        #region members + properties 
 
        /// <summary>
        /// index mapping for reference arrays. Null if this is not a reference but a solid array.
        /// </summary>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)] 
        internal protected ILIndexOffset m_indexOffset;
        
        /// <summary>
        /// index mapping for reference arrays. Null if this is not a reference but a solid array.
        /// </summary>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)] 
        internal ILIndexOffset IndexOffset {
            get {
                return m_indexOffset;
            }
        }
    
        /// <summary>
        /// Determine if this instance is a reference to another ILArray or 
        /// if it is a physical storage actually holding values itself (called a 'solid array').
        /// </summary>
        /// <return>
        /// True if this ILArray holds a reference storage, false otherwise
        /// </return>
        /// <remarks>
        /// This parameter is readonly. It is useful for estimating the cost for 
        /// operation. Since referencing storages are less performant than solid arrays, this may 
        /// helps planning and optimizing algorithms. 
        /// </remarks>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public virtual bool IsReference {
            get {
                return m_indexOffset != null;
            }
        }
   
        /// <summary>
        /// create transposed version transpose / dimension shift by 1 dimension
        /// </summary>
        /// <remarks>this is an alias for GetShifted(1).
        /// <para><c>T</c> returns an Array of the same size than this array, but 
        /// having the dimensions shifted by 1. This array may be a vector, matrix or n-dimensional array.</para>
        /// <para>For complex arrays the result will <![CDATA[<b>NOT<b/>]]> be the complex conjugate! The 
        /// content of this array will copied only without altering.</para>
        /// </remarks>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ILArray<BaseT> T {
            get {
                return GetShifted(1); 
            }
        }

        /// <summary>
        /// create solid clone of this object
        /// </summary>
        /// <remarks>this is a casting alias for object <![CDATA[ILArray<BaseT>.Clone()]]>.</remarks>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ILArray<BaseT> C {
            get {
                return (ILArray<BaseT>)Clone();  
            }
        }

        /// <summary>
        /// create full reference of this object
        /// </summary>
        /// <remarks>this is a casting alias for object <![CDATA[ILArray<BaseT>.CreateReference()]]>.</remarks>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ILArray<BaseT> R {
            get {
                return (ILArray<BaseT>)CreateReference();   
            }
        }
        
        /// <summary>
        /// Maximum of all elements in this array (if existing)
        /// </summary>
        /// <remarks>For reference types the original element will be returned. No copy will be made!
        /// <para>in order to be comparable, the inner type of this array must implement IComparable. If it does not, 
        /// an exception will be thrown. Note: all numeric System types do implement IComparable.</para>
        /// </remarks>
        /// <exception cref="ILArgumentTypeException"> if the inner type BaseT cannot be compared. Inner types 
        /// must implement IComparable&lt;BaseT&gt; in order to compute the minimum.</exception>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public BaseT MaxValue {
            get {
                if (IsEmpty)
                    return default(BaseT);
                if (IsScalar) 
                    return GetValue(0);
                if ((typeof(BaseT) is IComparable<BaseT>)) {
                    BaseT curMin = GetValue(0); 
                    for (int i = 1; i < m_dimensions.NumberOfElements; i++) {
                        BaseT val = m_data[getBaseIndex(i)];
                        if (((IComparable<BaseT>)val).CompareTo(curMin) > 0) 
                            curMin = val;
                    }
                    return curMin; 
#region HYCALPER LOOPSTART
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="endregion">
        skipNAN1
    </source>
    <destination><![CDATA[while (float.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)float.NaN;]]></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination><![CDATA[while (complex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)complex.NaN;]]></destination>
    <destination><![CDATA[while (fcomplex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)fcomplex.NaN;]]></destination>
</type>
<type>
    <source locate="nextline">
        skipNAN2
    </source>
    <destination>if (float.IsNaN(curVal)) continue;</destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination>if (complex.IsNaN(curVal)) continue;</destination>
    <destination>if (fcomplex.IsNaN(curVal)) continue;</destination>
</type>
</hycalper>
 */                 
                } else if (this is /*!HC:inCls1*/ ILArray<double> ) {    
                    /*!HC:inArr1*/ double [] data = (/*!HC:inArr1*/ double [])(object) m_data; 
                    /*!HC:inArr1*/ double curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    #region !HC:skipNAN1
                    while (double.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)double.NaN;
                    #endregion HYCALPER
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            /*!HC:skipNAN2*/
                            if (double.IsNaN(curVal)) continue; 
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            /*!HC:skipNAN2*/
                            if (double.IsNaN(curVal)) continue; 
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                 
                } else if (this is  ILArray<fcomplex> ) {    
                    fcomplex [] data = ( fcomplex [])(object) m_data; 
                    fcomplex curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (fcomplex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)fcomplex.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (fcomplex.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (fcomplex.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<complex> ) {    
                    complex [] data = ( complex [])(object) m_data; 
                    complex curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (complex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)complex.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (complex.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (complex.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<byte> ) {    
                    byte [] data = ( byte [])(object) m_data; 
                    byte curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<char> ) {    
                    char [] data = ( char [])(object) m_data; 
                    char curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt64> ) {    
                    UInt64 [] data = ( UInt64 [])(object) m_data; 
                    UInt64 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt32> ) {    
                    UInt32 [] data = ( UInt32 [])(object) m_data; 
                    UInt32 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt16> ) {    
                    UInt16 [] data = ( UInt16 [])(object) m_data; 
                    UInt16 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int64> ) {    
                    Int64 [] data = ( Int64 [])(object) m_data; 
                    Int64 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int32> ) {    
                    Int32 [] data = ( Int32 [])(object) m_data; 
                    Int32 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int16> ) {    
                    Int16 [] data = ( Int16 [])(object) m_data; 
                    Int16 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<float> ) {    
                    float [] data = ( float [])(object) m_data; 
                    float curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (float.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)float.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (float.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (float.IsNaN(curVal)) continue;
                            if (curVal > curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;

#endregion HYCALPER AUTO GENERATED CODE
                } else 
                    throw new ILArgumentTypeException("The inner type must be a value tpye or implement ILComparable. These objects cannot be compared!"); 
            }
        }

        /// <summary>
        /// Minimum of all elements in this array (if existing)
        /// </summary>
        /// <remarks>For reference types the original element will be returned. No copy will be made!
        /// <para>in order to be comparable, the inner type of this array must implement IComparable. If it does not, 
        /// an exception will be thrown. Note: all numeric System types do implement IComparable.</para>
        /// </remarks>
        /// <exception cref="ILArgumentTypeException"> if the inner type BaseT cannot be compared. Inner types 
        /// must implement IComparable&lt;BaseT&gt; in order to compute the minimum.</exception>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public BaseT MinValue {
            get {
                if (IsEmpty)
                    return default(BaseT);
                if (IsScalar) 
                    return GetValue(0);
                if ((typeof(BaseT) is IComparable<BaseT>)) {
                    BaseT curMin = GetValue(0); 
                    for (int i = 1; i < m_dimensions.NumberOfElements; i++) {
                        BaseT val = m_data[getBaseIndex(i)];
                        if (((IComparable<BaseT>)val).CompareTo(curMin) < 0) 
                            curMin = val;
                    }
                    return curMin; 
#region HYCALPER LOOPSTART
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="endregion">
        skipNAN1
    </source>
    <destination><![CDATA[while (float.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)float.NaN;]]></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination><![CDATA[while (complex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)complex.NaN;]]></destination>
    <destination><![CDATA[while (fcomplex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)fcomplex.NaN;]]></destination>
</type>
<type>
    <source locate="nextline">
        skipNAN2
    </source>
    <destination>if (float.IsNaN(curVal)) continue;</destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination></destination>
    <destination>if (complex.IsNaN(curVal)) continue;</destination>
    <destination>if (fcomplex.IsNaN(curVal)) continue;</destination>
</type>
</hycalper>
 */                 
                } else if (this is /*!HC:inCls1*/ ILArray<double> ) {    
                    /*!HC:inArr1*/ double [] data = (/*!HC:inArr1*/ double [])(object) m_data; 
                    /*!HC:inArr1*/ double curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    #region !HC:skipNAN1
                    while (double.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)double.NaN;
                    #endregion HYCALPER
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            /*!HC:skipNAN2*/
                            if (double.IsNaN(curVal)) continue; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            /*!HC:skipNAN2*/
                            if (double.IsNaN(curVal)) continue; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                 
                } else if (this is  ILArray<fcomplex> ) {    
                    fcomplex [] data = ( fcomplex [])(object) m_data; 
                    fcomplex curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (fcomplex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)fcomplex.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (fcomplex.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (fcomplex.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<complex> ) {    
                    complex [] data = ( complex [])(object) m_data; 
                    complex curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (complex.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)complex.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (complex.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (complex.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<byte> ) {    
                    byte [] data = ( byte [])(object) m_data; 
                    byte curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<char> ) {    
                    char [] data = ( char [])(object) m_data; 
                    char curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt64> ) {    
                    UInt64 [] data = ( UInt64 [])(object) m_data; 
                    UInt64 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt32> ) {    
                    UInt32 [] data = ( UInt32 [])(object) m_data; 
                    UInt32 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<UInt16> ) {    
                    UInt16 [] data = ( UInt16 [])(object) m_data; 
                    UInt16 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int64> ) {    
                    Int64 [] data = ( Int64 [])(object) m_data; 
                    Int64 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int32> ) {    
                    Int32 [] data = ( Int32 [])(object) m_data; 
                    Int32 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<Int16> ) {    
                    Int16 [] data = ( Int16 [])(object) m_data; 
                    Int16 curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;
                 
                } else if (this is  ILArray<float> ) {    
                    float [] data = ( float [])(object) m_data; 
                    float curVal, curMin = data[getBaseIndex(0)]; 
                    int i = 0;
                    while (float.IsNaN(curMin) && ++i < m_dimensions.NumberOfElements) 
                        curMin = data[getBaseIndex(i)]; 
                    if (i == m_dimensions.NumberOfElements) return (BaseT)(object)float.NaN;
                    if (m_indexOffset != null) {
                        // Reference 
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[m_indexOffset.Map(i)]; 
                            if (float.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    } else {
                        // physical storage
                        for (; i < m_dimensions.NumberOfElements; i++) { 
                            curVal = data[i]; 
                            if (float.IsNaN(curVal)) continue;
                            if (curVal < curMin) { 
                                curMin = curVal; 
                            }
                        }
                    }
                    return (BaseT)(object)curMin;

#endregion HYCALPER AUTO GENERATED CODE
                } else 
                    throw new ILArgumentTypeException("The inner type must be a value tpye or implement ILComparable. These objects cannot be compared!"); 
            }
        }
        
        /// <summary>
        /// Get minimum and maximum value of all elements - if exist
        /// </summary>
        /// <param name="minValue">output: minimum value</param>
        /// <param name="maxValue">output: maximum value</param>
        /// <returns>true if the limits exists and could be computed, false otherwise</returns>
        /// <remarks>Empty arrays will return false. The output parameter will be found as default(type).</remarks>
        public bool GetLimits(out BaseT minValue, out BaseT maxValue) {
            minValue = default(BaseT);   
            maxValue = default(BaseT);
            if (IsEmpty)
                return false; 
            if ((typeof(BaseT) is IComparable<BaseT>)) {
                for (int i = 0; i < m_dimensions.NumberOfElements; i++) {
                    BaseT val = m_data[getBaseIndex(i)];
                    if (((IComparable<BaseT>)val).CompareTo(minValue) < 0) 
                        minValue = val;
                    if (((IComparable<BaseT>)val).CompareTo(minValue) > 0) 
                        maxValue = val;
                }
                return true; 
#region HYCALPER LOOPSTART findLimits
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        negInf
    </source>
    <destination>float.NegativeInfinity</destination>
    <destination>Int16.MinValue</destination>
    <destination>Int32.MinValue</destination>
    <destination>Int64.MinValue</destination>
    <destination>UInt16.MinValue</destination>
    <destination>UInt32.MinValue</destination>
    <destination>UInt64.MinValue</destination>
    <destination>Char.MinValue</destination>
    <destination>Byte.MinValue</destination>
    <destination>new complex(Double.NegativeInfinity,Double.NegativeInfinity)</destination>
    <destination>new fcomplex(float.NegativeInfinity,float.NegativeInfinity)</destination>
</type>
<type>
    <source locate="after">
        posInf
    </source>
    <destination>float.PositiveInfinity</destination>
    <destination>Int16.MaxValue</destination>
    <destination>Int32.MaxValue</destination>
    <destination>Int64.MaxValue</destination>
    <destination>UInt16.MaxValue</destination>
    <destination>UInt32.MaxValue</destination>
    <destination>UInt64.MaxValue</destination>
    <destination>Char.MaxValue</destination>
    <destination>Byte.MaxValue</destination>
    <destination>new complex(Double.PositiveInfinity,Double.PositiveInfinity)</destination>
    <destination>new fcomplex(float.PositiveInfinity,float.PositiveInfinity)</destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
</hycalper>
 */                 
                } else if (this is /*!HC:inCls1*/ ILArray<double> ) {    
                    /*!HC:inArr1*/ double [] data = (/*!HC:inArr1*/ double [])(object) m_data; 
                    /*!HC:inArr1*/ double curVal; 
                    /*!HC:inArr1*/ double curMin = /*!HC:posInf*/ Double.PositiveInfinity ;
                    /*!HC:inArr1*/ double curMax = /*!HC:negInf*/ Double.NegativeInfinity ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                 
                } else if (this is  ILArray<fcomplex> ) {    
                    fcomplex [] data = ( fcomplex [])(object) m_data; 
                    fcomplex curVal; 
                    fcomplex curMin =  new fcomplex(float.PositiveInfinity,float.PositiveInfinity) ;
                    fcomplex curMax =  new fcomplex(float.NegativeInfinity,float.NegativeInfinity) ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<complex> ) {    
                    complex [] data = ( complex [])(object) m_data; 
                    complex curVal; 
                    complex curMin =  new complex(Double.PositiveInfinity,Double.PositiveInfinity) ;
                    complex curMax =  new complex(Double.NegativeInfinity,Double.NegativeInfinity) ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<byte> ) {    
                    byte [] data = ( byte [])(object) m_data; 
                    byte curVal; 
                    byte curMin =  Byte.MaxValue ;
                    byte curMax =  Byte.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<char> ) {    
                    char [] data = ( char [])(object) m_data; 
                    char curVal; 
                    char curMin =  Char.MaxValue ;
                    char curMax =  Char.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<UInt64> ) {    
                    UInt64 [] data = ( UInt64 [])(object) m_data; 
                    UInt64 curVal; 
                    UInt64 curMin =  UInt64.MaxValue ;
                    UInt64 curMax =  UInt64.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<UInt32> ) {    
                    UInt32 [] data = ( UInt32 [])(object) m_data; 
                    UInt32 curVal; 
                    UInt32 curMin =  UInt32.MaxValue ;
                    UInt32 curMax =  UInt32.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<UInt16> ) {    
                    UInt16 [] data = ( UInt16 [])(object) m_data; 
                    UInt16 curVal; 
                    UInt16 curMin =  UInt16.MaxValue ;
                    UInt16 curMax =  UInt16.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<Int64> ) {    
                    Int64 [] data = ( Int64 [])(object) m_data; 
                    Int64 curVal; 
                    Int64 curMin =  Int64.MaxValue ;
                    Int64 curMax =  Int64.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<Int32> ) {    
                    Int32 [] data = ( Int32 [])(object) m_data; 
                    Int32 curVal; 
                    Int32 curMin =  Int32.MaxValue ;
                    Int32 curMax =  Int32.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<Int16> ) {    
                    Int16 [] data = ( Int16 [])(object) m_data; 
                    Int16 curVal; 
                    Int16 curMin =  Int16.MaxValue ;
                    Int16 curMax =  Int16.MinValue ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 
                 
                } else if (this is  ILArray<float> ) {    
                    float [] data = ( float [])(object) m_data; 
                    float curVal; 
                    float curMin =  float.PositiveInfinity ;
                    float curMax =  float.NegativeInfinity ;
                    int curMinInd = 0; 
                    int curMaxInd = 0; 
                    int len = m_dimensions.NumberOfElements; 
                    if (m_indexOffset != null) {
                        // Reference 
                        int curInd = -1; 
                        for (int i = 0; i < len; i++) { 
                            curInd = m_indexOffset.Map(i);
                            curVal = data[curInd]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = curInd; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = curInd; 
                            }
                        }
                    } else {
                        // physical storage
                        for (int i = 0; i < len; i++) { 
                            curVal = data[i]; 
                            if (curVal < curMin) { 
                                curMin = curVal; 
                                curMinInd = i; 
                            }
                            if (curVal > curMax) { 
                                curMax = curVal; 
                                curMaxInd = i; 
                            }
                        }
                    }
                    maxValue = m_data[curMaxInd];
                    minValue = m_data[curMinInd]; 
                    return true; 

#endregion HYCALPER AUTO GENERATED CODE
            } else 
                return false; 
        }

        /// <summary>
        /// Create referencing copy of this array
        /// </summary>
        /// <returns>Reference of this ILArray</returns>
        /// <remarks><para>This function is mainly needed for ILCell. Elements of ILCells given back must be 
        /// detached from their originals in order not to overwrite them on write access. Since ILCell 
        /// may store any types of arrays (ILBaseArray's) and the actual type is not known, ILBaseArrays 
        /// must be capable of creating a copy of themself. For generic ILArray's this is done in the 
        /// <see cref="ILArray&lt;BaseT&gt;.CreateReference()"/>  member. </para>
        /// <para>The actual storage type of the object returned depends on the setting of the member <see cref="ILNumerics.ILArray&lt;BaseT&gt;.MinimumRefDimensions"/>. If the number 
        /// of dimensions of this array is larger or equal its numer, the object returned will be a reference array. Otherwise it will be a physical 
        /// array anyway. This is especially true for scalars and vectors.</para></remarks>
        public override ILBaseArray CreateReference() {
            return ShiftDimensions(0); 
        }

        /// <summary>
        /// Determine if the referencing ILArray must get detached before writing to it
        /// </summary>
        /// <returns>True: the current instance must get detached before writing to it. 
        /// False: one may instntly write to elements of the current instance without detaching it.
        /// </returns>
        /// <remarks>
        /// The result depends on the static attribute DetachingBehavior.</remarks>
        protected bool mustDetach() {
            switch (DetachReferences) {
                case ILDetachingBehavior.DetachOnWrite:
                    if (IsReference) {
                        return true; 
                    } else {
                        if (GetNumberOfReferences() > 1)
                            return true;
                        else
                            return false;
                    }
                case ILDetachingBehavior.DetachAlways:
                    return true;
                case ILDetachingBehavior.DetachNever:
                    return false;
                case ILDetachingBehavior.DetachSave:
                    if (GetNumberOfReferences() > 1)
                        return true;
                    else
                        return false;
                default:
                    return true;
            }
        }
       
        /// <summary>
        /// Detach this storage if it is a referencing storage. Change this into a solid physical copy.
        /// </summary>
        /// <remarks> If this storage is a referencing storage, it will 
        /// be detached. Therefore a (shallow) physical copy of the elements is created.
        /// Keep in mind, for ILArrays of base tpye 'object', only the references to real 
        /// objects are copied, not the referenced objects itself (no 'deep' copy!).
        /// If this storage already is a 'physical' (i.e.solid) storage, the method will have no effect.
        /// <br>For reference storages this will lead to a dereferencing copy. This is 
        /// true for solid ILStorages also. The returned object always is a solid storage. 
        /// Detaching an object will decrease the reference counter of the array formerly 
        /// referenced by it. Detach will not check if other references on the storage array exist.
        /// Therefore it might happen, this storage is the only reference to an storage array and 
        /// detaching may be unnesseccary - or even worse - migth increase the memory needed to
        /// store the data (this only becomes true for referencing storages with repeated entries).
        /// </br></remarks>
        public virtual ILArray<BaseT> Detach() {
            // test if detaching would make sence
            if (m_indexOffset == null
                && GetNumberOfReferences() == 1)
                return this;
            // copy and register data array
            BaseT[] tmpData = new BaseT[m_dimensions.NumberOfElements];
            unsafe {
                if (IsReference) {
                    for (int i = 0; i < tmpData.Length; i++) {
                        tmpData[i] = m_data[getBaseIndex(i)];
                    }
                } else {
                    // physical storage 
                    for (int i = 0; i < tmpData.Length; i++) {
                        tmpData[i] = m_data[i];
                    }
                }
            } 
            DecreaseReference();
            m_data = tmpData;
            IncreaseReference();
            m_indexOffset = null;
            return this;
        }

#endregion

        #region static functions 
        /// <summary>
        /// Create array with all elements initialized to zero
        /// </summary>
        /// <param name="dimensions">length of each dimension. This may be a comma separated 
        /// list of int values</param>
        /// <returns>Solid ILArray of specified size.</returns>
        public static ILArray<BaseT> zeros(params int[] dimensions) {
            ILDimension dim = new ILDimension(dimensions);
            BaseT[] data = new BaseT[dim.NumberOfElements];
            return new ILArray<BaseT>(data, dimensions);
        }
        /// <summary>
        /// Create array with all elements initialized to zero
        /// </summary>
        /// <param name="dimension">ILDimension object</param>
        /// <returns>Solid ILArray of specified size.</returns>
        /// <remarks>The ILDimension given will be cloned before used.</remarks>
        public static ILArray<BaseT> zeros (ILDimension dimension) {
            bool cleared = false; 
            BaseT[] data = ILMemoryPool.Pool.New<BaseT>(dimension.NumberOfElements, true, out cleared);
            return new ILArray<BaseT>(data, dimension);
        }
        /// <summary>
        /// create empty array, size (0 x 0)
        /// </summary>
        /// <returns>Empty ILArray</returns>
        public static ILArray<BaseT> empty(ILDimension dims) {
            return new ILArray<BaseT>(new BaseT [0],dims);
        }
        /// <summary>
        /// create empty array, size (0 x 0)
        /// </summary>
        /// <returns>Empty ILArray</returns>
        public static ILArray<BaseT> empty(params int[] dims) {
            if (dims == null || dims.Length == 0) 
                return empty(0,0); 
            return new ILArray<BaseT>(new BaseT [0],dims);
        }
        #endregion static functions

        #region overriding object . ToString(), Equals()
        /// <summary>
        /// write informations about this ILArray to string
        /// </summary>
        /// <returns>String containing general information about the current instance of 
        /// ILArray and the formated elements values.</returns>
        /// <remarks>If the number of elements exceeds 10000 the writing of all elements will 
        /// be ommitted.</remarks>
        public override string ToString() {
            return ToString("",0);
        }
        /// <summary>
        ///  formated output for this ILArray
        /// </summary>
        /// <param name="s">
        /// predefined string to be prepended to the output. This may be an empty String (not null!).
        /// </param>
        /// <param name="maxLength">maxmum number of characters for the output lines.</param>
        /// <returns>Formated string holding all values of this storage.
        ///  If the number of values exceeds 10.000, the number of elements 
        ///  will be printed only.</returns>
        public virtual String ToString(String s, int maxLength) {
            ILFormatter<BaseT> formater = new ILFormatter<BaseT>(this); 
            return formater.ToString("",0); 
        }
        /// <summary>
        /// here is created, what will be displayed in the headline of the objects if displayed in variable windows
        /// </summary>
        /// <returns>string with the headline - value is depending on the size of the array</returns>
        internal string debuggerHeadLineDisplay () {
            StringBuilder ret = new StringBuilder(20); 
            Type type = GetType(); 
            if (m_data == null)
                return "(disposed)";
            if (!String.IsNullOrEmpty(m_name)) 
                ret.Append(m_name + " "); 
            if (type.GetGenericArguments() != null && type.GetGenericArguments().Length > 0) {
                ret.Append("<"+type.GetGenericArguments()[0].Name+"> "); 
            } else {
                ret.Append(GetType().Name + " ");
            }
            if (IsScalar) 
                ret.Append(GetValue(0)); 
            else if (IsEmpty)
                ret .Append("[empty]"); 
            else 
                ret.Append(m_dimensions.ToString()); 
            return ret.ToString(); 
        }

                

        /// <summary>
        /// print formated values to string (in the 'matlab style')
        /// </summary>
        /// <param name="maxLength">maximum number of characters per line. Set 
        /// to 0 to not limit this length at all.</param>
        /// <returns>StringBuilder object filled with formated value's </returns>
        public override StringBuilder ValuesToString(int maxLength) {
            StringBuilder s = new StringBuilder();
            if (maxLength <= 0) maxLength = int.MaxValue;
            if (m_dimensions.NumberOfElements > 10000) {
                s.Append(String.Format("({0})", m_dimensions.ToString()));
                return s;
            }
            if (m_dimensions.NumberOfElements < 1)
                return new StringBuilder("(Empty array)"); 
            int[] acc = new int[m_dimensions.NumberOfDimensions];
            int d;
            String sElement;
            int elemLength = 10; 
            //string format = "{0,20: E13;-E13; 0.0         } "; 
            int curLineLength = 0;
            if (false) {
#region HYCALPER LOOPSTART valuesToString
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<ILBaseArray>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<object>]]></destination>
</type>
<type>
    <source locate="after">
        HCelemLength
    </source>
    <destination>0</destination>
    <destination>5</destination>
    <destination>5</destination>
    <destination>10</destination>
    <destination>18</destination>
    <destination>5</destination>
    <destination>10</destination>
    <destination>18</destination>
    <destination>3</destination>
    <destination>3</destination>
    <destination>36</destination>
    <destination>24</destination>
    <destination>18</destination>
</type>
<type>
    <source locate="nextline">
        formatedOutput
    </source>
    <destination>sElement = element.Dimensions.ToString().PadRight(elemLength);</destination>
    <destination>sElement = String.Format ("{0:f5} ", element / scaling).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,5:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,10:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,18:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,5:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,10:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,18:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,3:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0,3:G} ", element).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0} ", (element / scaling).ToString(5)).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0} ", (element / scaling).ToString(5)).PadLeft(elemLength);</destination>
    <destination>sElement = String.Format ("{0} ", element).PadLeft(elemLength);</destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>ILBaseArray</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>object</destination>
</type>
<type>
    <source locate="after">
        cast
    </source>
    <destination></destination>
    <destination>(float)(object)</destination>
    <destination>(Int16)(object)</destination>
    <destination>(Int32)(object)</destination>
    <destination>(Int64)(object)</destination>
    <destination>(UInt16)(object)</destination>
    <destination>(UInt32)(object)</destination>
    <destination>(UInt64)(object)</destination>
    <destination>(char)(object)</destination>
    <destination>(byte)(object)</destination>
    <destination>(complex)(object)</destination>
    <destination>(fcomplex)(object)</destination>
    <destination></destination>
</type>
<type>
    <source locate="nextline">
        tscale
    </source>
    <destination><![CDATA[double scaling = 1.0; 
                for (int i = 0; i < this.Dimensions.NumberOfElements; i++) { 
                    element = elements[getBaseIndex(i)]; 
                    int l = (element == null)? 6 : element.Dimensions.ToString().Length; 
                    if (l > elemLength) elemLength = l; 
                }
]]></destination>
    <destination><![CDATA[float scaling = (float)(object)MaxValue; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling  = (float)Math.Pow(10,Math.Floor(Math.Log10(scaling))); ]]></destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination>double scaling = 1.0; </destination>
    <destination><![CDATA[double scaling = ((complex)(object)MaxValue).real; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling = Math.Pow(10,Math.Floor(Math.Log10(scaling))); ]]></destination>
    <destination><![CDATA[float scaling = ((fcomplex)(object)MaxValue).real; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling  = (float)Math.Pow(10,Math.Floor(Math.Log10(scaling)));]]></destination>
    <destination>double scaling = 1.0; </destination>
</type>
<type>
    <source locate="nextline">
        minusCompens
    </source>
    <destination></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination><![CDATA[if (element >= 0) s.Append(" "); ]]></destination>
    <destination></destination>
</type>
</hycalper>
 */
            } else if (this is /*!HC:inCls1*/ ILArray<double> ) {    
                /*!HC:inArr1*/ double element;
                /*!HC:inArr1*/ double [] elements = (this.m_data as /*!HC:inArr1*/ double []);
                elemLength = /*!HC:HCelemLength*/ 5 ; 
                /*!HC:tscale*/ 
                double scaling = (double)(object)MaxValue; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling = Math.Pow(10,Math.Floor(Math.Log10(scaling))); 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                /*!HC:formatedOutput*/
                                sElement = String.Format ("{0:f5} ", element / scaling).PadRight(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            /*!HC:minusCompens*/
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }
 #endregion HYCALPER LOOPEND valuesToString
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

            } else if (this is  ILArray<object> ) {    
                object element;
                object [] elements = (this.m_data as  object []);
                elemLength =  18 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<fcomplex> ) {    
                fcomplex element;
                fcomplex [] elements = (this.m_data as  fcomplex []);
                elemLength =  24 ; 
                float scaling = ((fcomplex)(object)MaxValue).real; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling  = (float)Math.Pow(10,Math.Floor(Math.Log10(scaling)));
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0} ", (element / scaling).ToString(5)).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<complex> ) {    
                complex element;
                complex [] elements = (this.m_data as  complex []);
                elemLength =  36 ; 
                double scaling = ((complex)(object)MaxValue).real; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling = Math.Pow(10,Math.Floor(Math.Log10(scaling))); 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0} ", (element / scaling).ToString(5)).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<byte> ) {    
                byte element;
                byte [] elements = (this.m_data as  byte []);
                elemLength =  3 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,3:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<char> ) {    
                char element;
                char [] elements = (this.m_data as  char []);
                elemLength =  3 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,3:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<UInt64> ) {    
                UInt64 element;
                UInt64 [] elements = (this.m_data as  UInt64 []);
                elemLength =  18 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,18:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<UInt32> ) {    
                UInt32 element;
                UInt32 [] elements = (this.m_data as  UInt32 []);
                elemLength =  10 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,10:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<UInt16> ) {    
                UInt16 element;
                UInt16 [] elements = (this.m_data as  UInt16 []);
                elemLength =  5 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,5:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<Int64> ) {    
                Int64 element;
                Int64 [] elements = (this.m_data as  Int64 []);
                elemLength =  18 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,18:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<Int32> ) {    
                Int32 element;
                Int32 [] elements = (this.m_data as  Int32 []);
                elemLength =  10 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,10:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<Int16> ) {    
                Int16 element;
                Int16 [] elements = (this.m_data as  Int16 []);
                elemLength =  5 ; 
                double scaling = 1.0; 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0,5:G} ", element).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<float> ) {    
                float element;
                float [] elements = (this.m_data as  float []);
                elemLength =  5 ; 
                float scaling = (float)(object)MaxValue; if (scaling < 0) scaling *= -1; if (scaling == 0 || (scaling > 1e-1 && scaling < 1e1)) scaling = 1; scaling  = (float)Math.Pow(10,Math.Floor(Math.Log10(scaling))); 
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = String.Format ("{0:f5} ", element / scaling).PadLeft(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            if (element >= 0) s.Append(" "); 
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

            } else if (this is  ILArray<ILBaseArray> ) {    
                ILBaseArray element;
                ILBaseArray [] elements = (this.m_data as  ILBaseArray []);
                elemLength =  0 ; 
                double scaling = 1.0; 
                for (int i = 0; i < this.Dimensions.NumberOfElements; i++) { 
                    element = elements[getBaseIndex(i)]; 
                    int l = (element == null)? 6 : element.Dimensions.ToString().Length; 
                    if (l > elemLength) elemLength = l; 
                }

                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") " + ((scaling!=1.0)? (scaling.ToString("e0") + " * "):""));
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                sElement = element.Dimensions.ToString().PadRight(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }

#endregion HYCALPER AUTO GENERATED CODE
            } else if (this is ILArray<string> ) {    
                string element;
                string [] elements = (this.m_data as string []);
                while (acc[m_dimensions.NumberOfDimensions - 1] <
                        m_dimensions[m_dimensions.NumberOfDimensions - 1]) {
                    // show only two first dimensions at the same time ... 
                    // print header
                    s.Append(Environment.NewLine + "(:,:");
                    for (d = 2; d < m_dimensions.NumberOfDimensions; d++)
                        s.Append(String.Format(",{0}", acc[d]));
                    s.Append(") "); 
                    s.Append(Environment.NewLine);
                    // show this for 2 leading dimensions 
                    elemLength = 0; 
                    for (int i = 0; i < m_dimensions.NumberOfElements; i++) {
                        element = elements[getBaseIndex(i)]; 
                        if (element != null && element.Length > elemLength) {
                            elemLength = element.Length; 
                        }
                    }
                    for (int d0 = 0; d0 < m_dimensions[0]; d0++) {
                        acc[0] = d0;
                        for (int d1 = 0; d1 < m_dimensions[1]; d1++) {
                            acc[1] = d1;
                            element = elements [getBaseIndex(acc)];
                            if (!Object.ReferenceEquals(element,null)) {
                                /*!HC:formatedOutput*/
                                sElement = elements [getBaseIndex(acc)].PadRight(elemLength);
                            } else {
                                sElement = "(null)".PadRight(elemLength);
                            }
                            if ((curLineLength + sElement.Length) > maxLength) {
                                s.Append(Environment.NewLine);
                                curLineLength = 0;
                            }
                            /*!HC:minusCompens*/
                            s.Append(" " + sElement);
                            curLineLength += sElement.Length;
                        }
                        s.Append(Environment.NewLine);
                    }
                    // increase higher dimension
                    d = 2;
                    while (d <= m_dimensions.NumberOfDimensions - 1) {
                        acc[d]++;
                        if (acc[d] < m_dimensions[d]) break;
                        acc[d] = 0;
                        d++;
                    }
                    if (d >= m_dimensions.NumberOfDimensions) break;      
                }
           } else { 
                return new StringBuilder ("(Unknown data type.)"); 
           } 
            return s;
        }

        private int GetTypedElementStringProperties(out string format) {
            format = "E+00000000000000;0.0;-E+00000000000000";
            if (this is ILArray<double>) {
                return double.MaxValue.ToString().Length;
            } else if (this is ILArray<float>) {
                return double.MaxValue.ToString().Length;
            } else if (this is ILArray<complex>) {
                return double.MaxValue.ToString().Length * 2 + 2;
            } else if (this is ILArray<fcomplex>) {
                return float.MaxValue.ToString().Length * 2 + 2;
            } else if (this is ILArray<char>) {
                return char.MaxValue.ToString().Length;
            } else if (this is ILArray<byte>) {
                return byte.MaxValue.ToString().Length;
            } else if (this is ILArray<Int16>) {
                return Int16.MaxValue.ToString().Length;
            } else if (this is ILArray<Int32>) {
                return Int32.MaxValue.ToString().Length;
            } else if (this is ILArray<Int64>) {
                return Int64.MaxValue.ToString().Length;
            } else if (this is ILArray<UInt16>) {
                return UInt16.MaxValue.ToString().Length;
            } else if (this is ILArray<UInt32>) {
                return UInt32.MaxValue.ToString().Length;
            } else if (this is ILArray<UInt64>) {
                return UInt64.MaxValue.ToString().Length;
            } else
                return 10; 

        }

        /// <summary>
        /// Check if the content of this array equals the content of obj
        /// </summary>
        /// <param name="obj">typed ILArray containing the values to compare this array with</param>
        /// <returns>true if all elements contained in obj are equal to the 
        /// elements of this array. False otherwise.</returns>
        /// <remarks> This method compares the object references of corresponding elements. 
        /// The size and type of both arrays must match. Otherwise false will be returned.</remarks>
        public override bool Equals(object obj) {
            if (obj == null) return false; 
            if (obj is BaseT)
                if (IsScalar && obj.ToString() == GetValue(0).ToString())
                    return true;
                else 
                    return false; 
            ILBaseArray<BaseT> ILObj = obj as ILBaseArray<BaseT>;
            if (object.Equals(ILObj,null))
                return false;
            return Equals(ILObj);
        }
        /// <summary>
        /// test if this ILArray equals another ILBaseArray
        /// </summary>
        /// <param name="obj">ILBaseArray to compare this ILArray with</param>
        /// <returns>true if all elements match, false otherwise</returns>
        public bool Equals(ILBaseArray<BaseT> obj) {
            if (obj == null) return false;
            if (!obj.m_dimensions.IsSameSize(m_dimensions))
                return false;
            int len = m_dimensions.NumberOfElements; 
            if (typeof(BaseT).IsValueType) {
                for (int i = 0; i < len;i++) {
                    if (!GetValue(i).Equals(obj.GetValue(i)))
                        return false; 
                }
            } else {
                for (int i = 0; i < len;i++) {
                    BaseT t1 = GetValue(i); 
                    if (t1 == null || !t1.Equals(obj.GetValue(i))) {
                        return false; 
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Get Hash Code of the current instance.
        /// </summary>
        /// <returns>Hash code of the current instance</returns>
        public override int GetHashCode() {
            return base.GetHashCode(); 
        }
        #endregion

        #region subarray + range get / set 
        /// <summary>
        ///	Alter values specified by range
        /// </summary>
        /// <param name="range">
        /// ILRange specifying the dimensions/indices to be altered
        /// </param>
        /// <param name="values">
        /// ILIterator initialized and pointing to the ILArray 
        /// holding the new values.
        /// </param>
        /// <remarks>
        /// The values pointed to by range will be replaced with the values 
        /// found in 'values'. 
        /// A remarkable situation arises, if this storage is the only 
        /// reference wich is left to an physical storage array and it holds 
        /// multiple (repeated) entries to single array elements. Due to the 
        /// nature of a "reference", altering any values will also update corresponding
        /// entries in the reference storage, pointing to the same underlying elements. 
        /// (In fact, those corresponding values will only point to the updated 
        /// elements also.) Keep in mind, that setting a range for a reference which 
        /// is connected to an array which is referenced by more than one storage, will 
        /// usually lead to a Detach() process - therefore the storage gets disconnected 
        /// and the behavior described will not happen. Since for the user the result 
        /// is not transparent, consider to eather 
        /// <list type="bullet">
        /// <item>
        /// check the state of the storage before calling SetRange() </item>
        /// <item>Detach() the storage manually, if required, or</item>
        /// <item>set the static flag ILDetachingBehavior to DetachAlways or DetachWrite (default)
        /// to detach all reference storages automatically before altering any values on it.</item>
        /// </list> 
        /// However there may be situations, where one may want to alter many values by changing only 
        /// one. Therefore the above mentioned flag might be set to true if needed. 
        /// <para>If range contains indices outside of the my dimensions, this array will be reshaped (expanded)
        /// yccording to those indices. However this might lead to a performance penalty. So you better not 
        /// expand an array by addressing indices outside of my dimensions! Consult the reference manual for hints 
        /// to circumvent this situation.</para>
        /// </remarks>
        public override void SetRange(ILRange range, ILBaseArray<BaseT> values) {
            if (range.Expanding) {
               ExpandArray(range);  
            }
            int[] c;
            int[] rdims;
            int[] tmpIdx;
            int d,idxPos, ldIdx, vpos = 0;
            if (values.IsScalar) {
                #region SCALAR CASE
                BaseT singleValue = values.GetValue(0); 
                if (mustDetach())
                    Detach();
                if (range.NumberOfDimensions == 1) {
                    d = range[0,0]; 
                    if (d < 0) {
                        #region full dimension (sequential / reshaping)
                        if (m_indexOffset == null) {
                            for (ldIdx = 0; ldIdx <= -d; ldIdx++) {
                                m_data[ldIdx] = singleValue; 
                            }
                        } else {
                            for (ldIdx = 0; ldIdx <= -d; ldIdx++) {
                                m_data[getBaseIndex(ldIdx)] = singleValue; 
                            }
                        }
                        #endregion
                    } else {
                        #region explicit single dimension specified
                        if (m_indexOffset == null) {
                            for (ldIdx = 0; ldIdx < range.NumberOfElements; ldIdx++) {
                                m_data[range[0,ldIdx]] = singleValue; 
                            }
                        } else {
                            for (ldIdx = 0; ldIdx < range.NumberOfElements; ldIdx++) {
                                m_data[getBaseIndex(range[0,ldIdx])] = singleValue; 
                            }
                        }
                        #endregion
                    }
                } else {
                    // iterate through range dimensions 
                    c = new int[range.NumberOfDimensions];
                    rdims = range.Limits;
                    tmpIdx = new int[range.NumberOfDimensions]; 
                    ldIdx = range.NumberOfDimensions - 1;
                    for (; c[ldIdx] < rdims[ldIdx]; ) {
                        // copy value(s)
                        m_data[getBaseIndex(range.Map(c,ref tmpIdx))] = singleValue;
                        // increase range pointer
                        d = 0;
                        while (d <= ldIdx) {
                            idxPos = d % m_dimensions.NumberOfDimensions;
                            c[idxPos]++;
                            if (c[idxPos] < rdims[idxPos]) break;
                            c[idxPos] = 0;
                            d++;
                        }
                        if (d > ldIdx) break;
                    }
                }
                return; 
                #endregion
            //} else if (range.nonSingletonDimensions > 1 && !rangeDimensions.IsSameSize(values.Dimensions)) {
            //    throw new ILArgumentSizeException("setrange: shape of source values and destination range must match!");
            } else if (range.NumberOfElements != values.Dimensions.NumberOfElements) 
                throw new ILArgumentSizeException("setrange: size of source and destination range must match!");
            if (mustDetach())
                Detach();
            if (range.NumberOfDimensions == 1) {
                for (ldIdx = 0; ldIdx < range.NumberOfElements; ldIdx++) {
                    m_data[getBaseIndex(range[0,ldIdx])] = values.GetValue(ldIdx); 
                }
            } else {
                // iterate through range dimensions 
                ldIdx = range.NumberOfDimensions - 1;
                c = new int[range.NumberOfDimensions];
                rdims = range.Limits;
                tmpIdx = new int[range.NumberOfDimensions]; 
                for (; c[ldIdx] < rdims[ldIdx]; ) {
                    // copy value(s)
                    m_data[getBaseIndex(range.Map(c,ref tmpIdx))] = values.GetValue(vpos++);
                    // increase range pointer
                    d = 0;
                    while (d <= ldIdx) {
                        idxPos = d % rdims.Length;
                        c[idxPos]++;
                        if (c[idxPos] < rdims[idxPos]) break;
                        c[idxPos] = 0;
                        d++;
                    }
                    if (d > ldIdx) break;
                }
            }
        }
        #region HYCALPER LOOPSTART SetRange Sequential indices 
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange(/*!HC:inCls1*/ ILArray<double> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            /*!HC:inArr1*/ double maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
        #endregion HYCALPER LOOPEND SetRange Sequential indices 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<fcomplex> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            fcomplex maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<complex> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            complex maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<byte> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            byte maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<char> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            char maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<UInt64> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            UInt64 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<UInt32> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            UInt32 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<UInt16> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            UInt16 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<Int64> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            Int64 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<Int32> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            Int32 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<Int16> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            Int16 maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        
       
        /// <summary>
        /// Alter elements of this array adressed by sequential indices 
        /// </summary>
        /// <param name="indices">array specifying the elements to be altered</param>
        /// <param name="values">ILBaseArray of the same type than this array, holding the new values. 
        /// The number of elements of storage must match 
        /// number of elements of indices. The only exception to this rule is if storage is scalar. The 
        /// single value of storage is than used to set all elements addressed by indices.</param>
        /// <remarks><para>For empty arrays, scalar or vectors, indices outside the current bounds for this array will expand this array to the size neccessary. 
        /// For other arrays the sequential indices given must fit inside this arrays dimensions. </para></remarks>
        public void SetRange( ILArray<float> indices, ILBaseArray<BaseT> values) {
            if (object.Equals(indices,null))
                throw new ILArgumentException("SetRange: indices given must not be null!");
            if (indices.IsEmpty)
                return; 
            if (object.Equals(values,null))
                throw new ILArgumentException("SetRange: values given must not be null!");
            if (indices.Dimensions.NumberOfElements != values.Dimensions.NumberOfElements &
                values.Dimensions.NumberOfElements != 1)
                throw new ArgumentException("Number of elements in storage must match specified dimensions.");
            float maxIndex, minIndex;
            indices.GetLimits(out minIndex, out maxIndex); 
            if (minIndex < 0) 
                throw new ILArgumentException("sequential indices can not be negative! ");
            if ((int)maxIndex >= m_dimensions.NumberOfElements) {
                // handle resize
                if (IsScalar || m_dimensions.NumberOfElements == 0 || IsRowVector) {
                    ExpandArray(new int[]{(int)maxIndex+1,1}); 
                } else if (IsColumnVector) {
                    ExpandArray(new int[]{1,(int)maxIndex+1}); 
                } else 
                    throw new ILArgumentException("SetRange: resizing array via sequential index access is supported only for empty,scalar or vector!");
            }
            if (mustDetach())
                Detach();
            try {
                if (values.IsScalar) {
                    // early exit
                    int len = indices.Dimensions.NumberOfElements;
                    BaseT element = values.GetValue(0); 
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i++)] = element;
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i++))] = element;
                        }
                } else {
                    int len = indices.Dimensions.NumberOfElements;
                    if (m_indexOffset == null) 
                        for (int i = 0; i < len;) {
                            m_data[(int)indices.GetValue(i)] = values.GetValue(i++);
                        }
                    else 
                        for (int i = 0; i < len;) {
                            m_data[getBaseIndex((int)indices.GetValue(i))] = values.GetValue(i++);
                        }
                }
            } catch (Exception e) {
                throw new Exception("Error setting values.", e);
            }
        }        

#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// Get / set diagonal elements 
        /// </summary>
        /// <value>vector of same length as number of diagonal elements or scalar. If value is scalar, 
        /// all diagonal elements will be filled with this scalar value.</value>
        public ILArray<BaseT> Diagonal {
            get {
                return BuiltInFunctions.ILMath.diag (this); 
            }
            set {
                if (object.Equals(value, null))
                    throw new ILArgumentException("Diagonal: value given must not be null");
                if (value.IsEmpty)
                    return; 
                if (!IsMatrix)
                    throw new ILArgumentException("Diagonal is only valid for matrices!");
                if (!value.IsVector)
                    throw new ILArgumentException("Diagonal: value given must be vector sized!");
                int diagLen = (m_dimensions[0] > m_dimensions[1])? m_dimensions[0] : m_dimensions[1];
                if (value.Length != diagLen && !value.IsScalar)
                    throw new ILArgumentException("Diagonal: length of vector given must match diagonal length!");
                if (mustDetach()) Detach(); 
                int pos = 0, inc = m_dimensions[0] + 1;
                if (value.IsScalar) {
                    BaseT val = value.GetValue(0); 
                    if (m_indexOffset == null) {
                        for (int i = 0; i < diagLen; i++) {
                            m_data[pos] = val;
                            pos += inc;
                        }
                    } else {
                        for (int i = 0; i < diagLen; i++) {
                            m_data[getBaseIndex(i,i)] = val;                         
                        }
                    }
                } else {
                    if (m_indexOffset == null) {
                        for (int i = 0; i < diagLen; i++) {
                            m_data[pos] = value.GetValue(i);
                            pos += inc;
                        }
                    } else {
                        for (int i = 0; i < diagLen; i++) {
                            m_data[getBaseIndex(i,i)] = value.GetValue(i);                         
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create Reference of the current instance of ILArray and simultanously shift 
        /// dimensions
        /// </summary>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>ILArray pointing to the current instance</returns>
        /// <remarks> <para> the type of array returned will depend on the size of the array and
        /// the setting of the MinimumRefDimensions member.</para></remarks>
		public override ILBaseArray<BaseT> ShiftDimensions (int shift) {
			if (m_dimensions.NonSingletonDimensions 
				>= MinimumRefDimensions) {
				if (IsReference)
                    return CreateReferenceShiftedFromReference(shift); 
                else 
                    return CreateReferenceShiftedFromPhysical(shift); 
            } else {
				if (IsReference)
                    return CreatePhysicalShiftedFromReference(shift); 
                else 
                    return CreatePhysicalShiftedFromPhysical(shift); 
			}
        }
        /// <summary>
        /// Get shifted version of this array
        /// </summary>
        /// <param name="shift">number of dimensions to shift</param>
        /// <returns>ILArray of the same type having its dimensions shifted accordingly.</returns>
        /// <remarks><paramref name="shift"/> may be any integer value. It will be used in modulus 
        /// the number of my dimensions.
        /// <para>This is an alias or shortcut for <see cref="ILNumerics.ILArray&lt;BaseT&gt;.ShiftDimensions(int)"/> </para></remarks>
        public ILArray<BaseT> S(int shift) {
            return (ILArray<BaseT>)ShiftDimensions(shift); 
        }

        /// <summary>
        /// get reference to this array having the dimensions shifted by <c>shiftDimensions</c>.
        /// </summary>
        /// <param name="shiftDimensions">number of dimensions to shift this array (to the left for positive values)</param>
        /// <returns>Referencing ILArray of the same type and size with <c>shiftDimensions</c> dimensions shifted to the left.</returns>
        public ILArray<BaseT> GetShifted(int shiftDimensions) {
            //if (shiftDimensions != 1 || !IsComplex || !IsMatrix) 
                return (ILArray<BaseT>) ShiftDimensions(shiftDimensions);
            // handle complex conjugate transpose
            //if (this is ILArray<complex>) { 
            //    ILArray<complex> A = (ILArray<complex>)ShiftDimensions(shiftDimensions);
            //    return (ILBaseArray<BaseT>) ILMath.ccomplex(ILMath.real(A),-ILMath.imag(A)); 
            //} else if (this is ILArray<fcomplex>) {
            //    ILArray<fcomplex> fA = (ILArray<fcomplex>)ShiftDimensions(shiftDimensions);
            //    return (ILArray<BaseT>) ILMath.ccomplex(ILMath.real(fA),-ILMath.imag(fA)); 
            //}
        }
        #endregion

        #region Reshape, Concat, Repmat  - overriding ILBaseArray<BaseT>

        /// <summary>
        /// Reshape this array
        /// </summary>
        /// <param name="newDimensions">new dimension object</param>
        /// <returns>This array after reshaping.</returns>
        /// <remarks><para>This member changes the current objects dimension. The ILArray will have the 
        /// size and number of dimension specified by newDimensions. </para>
        /// <para>If this is a reference array, it is beeing detached.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the number of elements dont stay the same</exception>
        public ILArray<BaseT> Reshape(ILDimension newDimensions) {
            if (newDimensions.NumberOfElements != m_dimensions.NumberOfElements)
                throw new ILArgumentSizeException ("Reshape: the number of elements must not change!"); 
            if (IsReference) {
                Detach(); 
            }
            m_dimensions = newDimensions; 
            return this; 
        }
        /// <summary>
        /// Reshape this array
        /// </summary>
        /// <param name="dims">new dimension length</param>
        /// <returns>this array after reshaping</returns>
        /// <remarks><para>This member changes the current objects dimension. The ILArray will have the 
        /// size and number of dimension specified by newDimensions. </para>
        /// <para>If this is a reference array, it is beeing detached.</para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the number of elements dont stay the same</exception>
        public ILArray<BaseT> Reshape(params int[] dims) {
            ILDimension newDimension = new ILDimension(dims); 
            return Reshape(newDimension); 
        }


        /// <summary>
        /// Concatenate this array 
        /// </summary>
        /// <param name="inArray">N-dimensional array</param>
        /// <param name="leadDim">index of dimension to concatenate arrays along.
        /// If leadDim is larger than the number of dimensions of one of the arrays
        /// its value will be used in modulus</param>
        /// <returns>array having the size of both input arrays layed behind each 
        /// other along the leadDim's-dimension</returns>
        /// <remarks>The array returned will be a 
        /// <list type="bullet">
        /// <item> reference storage, if inArray is the same as this (object references 
        /// are the same) and ILArray.MinimumRefDimensions is less or equal 
        /// the number of dimensions of the resulting storage, or a 
        /// </item>
        /// <item>physical storage else. 
        /// </item></list>
        /// There are only very few cases where it is possible to reference two arrays in the 
        /// same reference storage. Not only the storages must point to the same underlying 
        /// physical System.Array, but the ILIndexOffset must be suited in a special way. 
        /// Therefore the restriction was made always to create a solid storage, if 
        /// both storages are not the same.</remarks>
        public ILArray<BaseT> Concat(ILArray<BaseT> inArray, int leadDim) {
            ILDimension inDim = inArray.m_dimensions;
            // check input arguments 
            if (inDim.NumberOfDimensions != m_dimensions.NumberOfDimensions)
                throw new ILArgumentSizeException("Both arrays to be concatenated must have the same number of dimensions!");
            leadDim %= m_dimensions.NumberOfDimensions;
            for (int i = 0; i < m_dimensions.NumberOfDimensions; i++) {
                if (i != leadDim)
                    if (m_dimensions[i] != inDim[i])
                        throw new ILArgumentSizeException("The length of dimensions of both arrays (exept the dimension "
                                            + "to be concatenated) must match !");
            }
            // concatenate 
            if (inDim.NumberOfElements == 1 && m_dimensions.NumberOfElements == 1) {
                // both scalars
                int[] dims = new int[2] { 1, 1 };
                dims[leadDim] = 2;
                return new ILArray<BaseT>(new BaseT[2] { GetValue(0), inArray.GetValue(0) },dims);
            }
            // -> erweiter '(true)' mit weiteren Bedingungen fr reference storage creation
            if (inDim.NonSingletonDimensions >= MinimumRefDimensions
                && (Object.ReferenceEquals(this, inArray))) {
                #region Output: Reference
                int [] regularSpacing = new int [m_dimensions.NumberOfDimensions];
                if (IsReference) {
                    // keep in mind: both storages are the same! 
                    #region Reference, Reference -> Reference
                    // create reference: ILIndexOffset will be the same, but 
                    // leadDims dimension will be twice the length 
                    int[][] newIdx = new int[m_dimensions.NumberOfDimensions][];
                    for (int d = 0; d < inDim.NumberOfDimensions; d++) {
                        int lenDim = inDim[d];
                        if (d != leadDim) {
                            newIdx[d] = new int[lenDim];
                            for (int i = 0; i < lenDim; i++)
                                newIdx[d][i] = m_indexOffset[d, i];
                            regularSpacing[d] = m_indexOffset.RegularySpacing(d); 
                        } else {
                            // copy that dimension
                            int tmpVal;
                            newIdx[d] = new int[2 * lenDim];
                            for (int i = 0; i < lenDim; i++) {
                                tmpVal = m_indexOffset[d, i];
                                newIdx[d][i] = tmpVal;
                                newIdx[d][lenDim + i] = tmpVal;
                            }
                            if (lenDim > 1)
                                regularSpacing[d] = (newIdx[d][lenDim] - newIdx[d][lenDim -1] == m_indexOffset.RegularySpacing(d))? 
                                    m_indexOffset.RegularySpacing(d) : int.MinValue; 
                            else 
                                regularSpacing[d] = 1; 
                        }
                    }
                    return new ILArray<BaseT>(this, new ILIndexOffset(newIdx, regularSpacing));
                    #endregion
                } else {
                    #region Physical, Physical -> Reference
                    // make referencing storage out of dimensions  
                    int[][] idxOffset = new int[inDim.NumberOfDimensions][];
                    for (int i = 0; i < inDim.NumberOfDimensions; i++) {
                        if (i != leadDim) {
                            idxOffset[i] = new int[inDim[i]];
                            for (int d = 0; d < inDim[i]; d++)
                                idxOffset[i][d] = inDim.SequentialIndexDistance(i) * d;
                            regularSpacing[i] = 1;
                        } else {
                            // fill double the size
                            int tmpLen = inDim[i];
                            idxOffset[i] = new int[2 * tmpLen];
                            int seqDist = inDim.SequentialIndexDistance(i);
                            for (int d = 0; d < inDim[i]; d++) {
                                idxOffset[i][d] = seqDist * d;
                                idxOffset[i][tmpLen + d] = seqDist * d;
                            }
                            regularSpacing[i] = int.MinValue; 
                        }
                    }
                    return new ILArray<BaseT>(this, new ILIndexOffset(idxOffset,regularSpacing));
                    #endregion
                }
                #endregion
            } else {
                #region Output: Physical
                int lenOutArr = m_dimensions.NumberOfElements + inDim.NumberOfElements;
                BaseT[] retData = new BaseT[lenOutArr];
                int[] retDims = m_dimensions.ToIntArray();
                retDims[leadDim] += inDim[leadDim];
                ILDimension retDimension = new ILDimension(retDims);
                int len1 = m_dimensions.SequentialIndexDistance(leadDim + 1);
                int len2 = inDim.SequentialIndexDistance(leadDim + 1);
                int posOutArr = 0, inPos = 0, myPos = 0;
                BaseT[] inData = inArray.m_data; 
                while (posOutArr < lenOutArr) {
                    if (IsReference) {
                        for (int i = 0; i < len1; i++)
                            retData[posOutArr++] = m_data[getBaseIndex(myPos++)];
                    } else {
                        for (int i = 0; i < len1; i++)
                            retData[posOutArr++] = m_data[myPos++]; 
                    }
                    if (inArray.IsReference) {
                        for (int i = 0; i < len2; i++)
                            retData[posOutArr++] = inData[inArray.getBaseIndex(inPos++)]; 
                    } else {
                        for (int i = 0; i < len2; i++)
                            retData[posOutArr++] = inData[inPos++]; 
                    }
                }
                return new ILArray<BaseT>(retData,retDimension);
                #endregion
            }
        }

        /// <summary>
        /// Replicate this storage. Make large storage out of this
        /// </summary>
        /// <param name="dims">dimensions specifier. This may be a 
        /// list or an array of integer values. If the number of elements in dim is 
        /// less the number of dimensions in this array, the trailing dimensions will 
        /// be set to 1 (singleton dimensions). On the other hand, if the number specified 
        /// is larger then the number of dimension of this array - the result 
        /// will get its number of dimensions extended accordingly. </param>
        /// <returns>large array beeing a multiple (dims) copy of this array along 
        /// arbitrary dimensions</returns>
        /// <remarks>The array returned will be a 
        /// <list type="bullet">
        /// <item> reference array, if the number of resulting dimensions is &lt;= 
        /// MinimumRefDimensions, or a 
        /// </item>
        /// <item>dense array else. 
        /// </item></list>
        /// </remarks>
        public ILArray<BaseT> Repmat(params int[] dims) {
            //build return dimensions
            ILDimension outDim;
            int[] newDim = new int[Math.Max(dims.Length, m_dimensions.NumberOfDimensions)]; 
            int nonSingleDimLen = Math.Min(dims.Length, m_dimensions.NumberOfDimensions); 
            for (int d = 0; d < newDim.Length; d++) {
                if (d < dims.Length) {
                    newDim[d]= m_dimensions[d] * dims[d];
                } else {
                    newDim[d] = m_dimensions[d];
                }
            }
            outDim = new ILDimension(true,newDim);
            // reference storage creation
            #region Create reference storage 
            int [][] newIdx = new int [outDim.NumberOfDimensions][];
            ILArray<BaseT> ret; 
            if (IsReference) {
                // from reference
                int [] regularSpacing = new int [outDim.NumberOfDimensions]; 
                unsafe {
                    for (int d = 0; d < outDim.NumberOfDimensions; d++) {
                        int[] tmpIdx = new int[outDim[d]];
                        int curNrRep = (dims.Length > d) ? dims[d] : 1;
                        if (d < m_dimensions.NumberOfDimensions) {
                            fixed (int* pTmp = tmpIdx) {
                                int* pTmpIdx = pTmp;
                                for (int i = 0; i < curNrRep; i++) {
                                    for (int a = 0; a < m_dimensions[d]; a++)
                                        *pTmpIdx++ = m_indexOffset[d, a];
                                }
                            }
                        }
                        newIdx[d] = tmpIdx; 
                        regularSpacing[d] = (m_indexOffset[d].Length == 1) ? 0:int.MinValue; 
                    }
                }
                ret = new ILArray<BaseT>(this, new ILIndexOffset(newIdx,regularSpacing));
            } else {
                // from physical 
                int [] regularSpacing = new int [outDim.NumberOfDimensions]; 
                unsafe {
                    for (int d = 0; d < outDim.NumberOfDimensions; d++) {
                        int[] tmpIdx = new int[outDim[d]];
                        int curNrRep = (dims.Length > d) ? dims[d] : 1;
                        int seqIdxDist = m_dimensions.SequentialIndexDistance(d); 
                        if (d < m_dimensions.NumberOfDimensions)
                            fixed (int* pTmp = tmpIdx) {
                                int* pTmpIdx = pTmp;
                                if (m_dimensions[d] != 1) {
                                    int limit = m_dimensions[d]; 
                                    for (int i = 0; i < curNrRep; i++) {
                                        for (int a = 0; a < limit; a++)
                                            *pTmpIdx++ = seqIdxDist * a;
                                    }
                                    regularSpacing[d] = (curNrRep == 1)? seqIdxDist : int.MinValue;
                                } else {
                                    regularSpacing[d] = 0;
                                }
                        }
                        newIdx[d] = tmpIdx;
                    }
                }
                ret = new ILArray<BaseT>(this, new ILIndexOffset(newIdx,regularSpacing)); 
            }
            #endregion 
            // which output type? 
            if (outDim.NonSingletonDimensions
                    < MinimumRefDimensions) {
                return ret.Detach();
            } else {
                return ret;
            }
        }
        //// replicate tile from srcArray into outArray. Replicate nrRep times 
        //private void repMatHelper(ref BaseT[] inArr, int srcStart, int SrcLen,
        //                           ref BaseT[] outArr, int destStart, int nrRep) {
        //    for (int r = 0; r < nrRep; r++)  {
        //        System.Array.Copy(inArr,srcStart,outArr,destStart,SrcLen); 
        //    }
        //}
        /// <summary>
        /// Remove dimension indices specified from array
        /// </summary>
        /// <param name="dimension">index of dimension where the <c>indices</c> are located.</param>
        /// <param name="indices">dimension indices to be removed</param>
        /// <remarks>after processing, the dimensions indices specified will be removed 
        /// from all dimensions of this ILArray. The operation is done by building a reference for the 
        /// existing ILArray. For the indices specified by range, the data 
        /// will be excluded. Depending on the value of the property
        /// ILSettings.DetachReferences, this ILArray will be left as solid array (i.e. it 
        /// would be explicitely detached) or left as referencing ILArray - which should be fine for 
        /// most situations.</remarks>
        internal void Remove(int dimension, int[] indices) {
            if (IsScalar) {
                if (dimension < 0 || dimension > 1)
                    throw new ILArgumentException ("error removing: invalid dimension specified!"); 
                if (indices.Length == 1 && indices[0] == 0) {
                    // set to empty 
                    m_data = new BaseT[0]; 
                    m_dimensions = new ILDimension(0,0); 
                    m_indexOffset = null; 
                    return; 
                } else {
                    throw new ILArgumentException("error removing: index out of range!"); 
                }
            }
            // non scalar case 
            int[][] newDimensions = new int[m_dimensions.NumberOfDimensions][]; 
            int usedIdx = m_dimensions[dimension]; 
            int [] regularSpacing = new int [m_dimensions.NumberOfDimensions]; 
            for (int d = 0; d < newDimensions.Length; d++) { 
                regularSpacing[d] = int.MinValue; 
                if (d != dimension) {
                    newDimensions[d] = new int[m_dimensions[d]]; 
                    if (m_indexOffset == null) {
                        for (int i = 0; i < m_dimensions[d]; i++)    
                            newDimensions[d][i]= m_dimensions.SequentialIndexDistance(d) * i; 
                    } else {
                        for (int i = 0; i < m_dimensions[d]; i++)    
                            newDimensions[d][i]= m_indexOffset[d,i]; 
                    }
                } else {
                    bool[] marks = new bool[m_dimensions[d]];
                    for (int i = 0; i < indices.Length; i++) {
                        if (indices [i] >= m_dimensions[d] | indices[i] < 0)
                             throw new ILArgumentException("Index out of range. element " 
                                    + indices[i] + " does not exist for dimension " + d); 
                        if (!marks[indices[i]]) {
                            marks[indices[i]]= true;
                            usedIdx--; 
                        }
                    }
                    // generate dimension to be lighted 
                    newDimensions[d] = new int[usedIdx];
                    int pos = 0; 
                    if (m_indexOffset == null) {
                        for (int i = 0; i < marks.Length; i++) {
                            if (!marks[i]) {
                                newDimensions[d][pos++] = m_dimensions.SequentialIndexDistance(d) * i; 
                            }
                        }
                    } else {
                        for (int i = 0; i < marks.Length; i++) {
                            if (!marks[i]) {
                                newDimensions[d][pos++] = m_indexOffset[d,i];  
                           }
                        }
                    }
                }
            }
            m_indexOffset = new ILIndexOffset (newDimensions,regularSpacing);
            m_dimensions  = m_indexOffset.GetDimensions(); 
            if (m_dimensions.NonSingletonDimensions < MinimumRefDimensions)
                Detach(); 
        }

        #endregion

        #region serialize 
        /// <summary>
        /// Prepare for serialization
        /// </summary>
        /// <param name="context">Streaming Context - provided by the formatter</param>
        /// <remarks>if the is reference storage we save memory/traffic by eventually detaching 
        /// this object for not having to store unused array element data. However the 
        /// serialized version will not reference any other ILStorages/arrays anymore. It will 
        /// be the only instance pointing to - / using the storage array.</remarks>
        [OnSerializing]
        private void OnSerialize(StreamingContext context) {
            if (m_data.Length > m_dimensions.NumberOfElements)
                Detach();
        }

        /// <summary>
        /// post perations after deserializing was finished
        /// </summary>
        /// <param name="context">Streaming context provided by the formatter</param>
        /// <remarks>After the storage was reconstructed, we need to register it 
        /// for reference counting.</remarks>
        [OnDeserialized]
        void OnDeserialized(StreamingContext context) {
            IncreaseReference(); 
        }

        /// <summary>
        /// print values of this instance to stream 
        /// </summary>
        /// <param name="stream">Stream to write the values into</param>
        /// <param name="format">Format string to be used for output. See <see cref="System.String.Format(string,object)"/> for a specification
        /// of valid formating expressions. This flag is only used, when 'method' is set to 'Serial' </param>
        /// <param name="method">a constant out of <see cref="ILArrayStreamSerializationFlags"/>. Specifies the way 
        /// the values will be serialized.</param>
        /// <remarks><para>If for method 'Formated' is used, any occourences of a NewLine character(s) 
        /// will be replaced from the format string before applying to the elements. This is due to 
        /// prevent the format from breaking the 'page' style for the output. </para>
        /// <para>If 'method' is set to 'Matlab', the array will be written as Matfile version 5.0. No compression will be used. The internal 'Name' property will be used as 
        /// array name for writing. This array instance will be the only array in the mat file. If you want to write several arrays bundled into one mat file, use the MatFile class to
        /// create a collection of arrays and write the MatFile to stream than. </para></remarks>
        public override void ToStream(Stream stream, string format, ILArrayStreamSerializationFlags method) {
          try {
            int len; 
            ILIterator<BaseT> it; 
            switch (method) {
                case ILArrayStreamSerializationFlags.Serial: 
                    len = m_dimensions.NumberOfElements;
                    using (TextWriter tw = new StreamWriter(stream)) {
                        for (int i = 0; i < len; i++) {
                            tw.Write(format, GetValue(i));
                        }
                    }
                    break; 
                case ILArrayStreamSerializationFlags.Formatted:
                    format = format.Replace(Environment.NewLine,""); 
                    it = CreateIterator(ILIteratorPositions.ILStart,1); 
                    len = m_dimensions.NumberOfElements / m_dimensions[1]; 
                    using (TextWriter tw = new StreamWriter(stream)) {
                        tw.Write(ValuesToString(0));
                    }
                    break;
                case ILArrayStreamSerializationFlags.Matlab:
                    ILMatFile mf = new ILMatFile(new ILBaseArray [1] { this } ); 
                    mf.Write(stream); 
                    break;
            }
          }catch (Exception e) {
              throw new ILException("ToStream: Could not serialize to stream.",e); 
          }
        }

        /// <summary>
        /// [deprecated] Write data of this ILArray to MATLAB .mat file
        /// </summary>
        /// <param name="fileout">Binary stream receiving the data</param>
        /// <param name="version">(not used)</param>
        /// <remarks>This function is deprecated and will soon be removed. 
        /// Use <see cref="ILNumerics.ILMatFile"/> instead!</remarks>
        protected void exportMatlab(BinaryWriter fileout, float version)
        {
            try
            {
                // write MAT-header      
                StringBuilder headerLine = new StringBuilder("vers. 5.0 MAT-FILE, (c) ILNumerics.Net, 2007");
                while (headerLine.Length < 124)
                    headerLine.Append(' ');
                fileout.Write(headerLine.ToString());
                fileout.Write((short)0x0100);
                fileout.Write((short)0x4d49);
                // write subarray header    
                fileout.Write(14);
                fileout.Write(8 * m_dimensions[1] * m_dimensions[0] + 48);
                fileout.Write(6);
                fileout.Write(8);
                // write array flags    
                fileout.Write(9);
                fileout.Write(0);
                // write dimensions tag     
                fileout.Write(5);
                // mINT32      
                fileout.Write(8);
                // length of dimension tag    
                fileout.Write(m_dimensions[0]);
                // 1st dimens.    
                fileout.Write(m_dimensions[1]);
                // 2nd dimens.     
                // write array name       
                fileout.Write((short)01);
                fileout.Write((short)03);
                fileout.Write(m_name);
                // header of array subdata element      
                fileout.Write(7);
                fileout.Write(m_dimensions[1] * m_dimensions[0] * 8);
                // write matrix elements     
                for (int r = 0; r < m_dimensions[0] * m_dimensions[1]; r++)
                {
                    fileout.Write((double)(object)m_data[r]);
                }
                fileout.Close();
            }
            catch (Exception e)
            {
                throw new ILOutputException("Error writing to matlab format!", e);
            }
        }      

        #endregion 

        #region obsolete methods
        /*		/// <summary>
		/// return unshifted dimension vector according to this storage's dimensions
		/// </summary>
		/// <param name="idx"></param>
		/// <param name="shift"></param>
		/// <returns>unshifted dimension vector</returns>
		protected int[] unshift (int[] idx,int shift) {
			int [] ret = new int[idx.Length]; 
			for (int d = m_dimensions.NumberOfDimensions; d < idx.Length*2; d++) 
				ret[d%m_dimensions.NumberOfDimensions] 
					= idx[(m_dimensions.NumberOfDimensions-shift+d)
						  %m_dimensions.NumberOfDimensions];
			return ret;
		}
*/
/*		/// <summary>
		/// Apply a function to this storage
		/// </summary>
		/// <param name="func">Applyable object. see namespace ILNumerics.Applyable</param>
		/// <remarks>All IILApplyable objects provide an Apply() function which is used to 
		/// alter this storage. The full storage is addressed! The operations will 
		/// happen directly on the data array. This member is not supported for ILRefStorage 
 		///	objects. Therefore thos storages will be (automatically) Detached() before Applying anything. 
		/// This function is capable of modifying the physical storage very efficiently.</remarks>
		public abstract void Apply(Applyable.IILApplyable func);
*/
/*		/// <summary>
		/// Fill a range of this array with values 
		/// </summary> 
		/// <param name="range">ILRange specifying the dimensions to alter</param>
		/// <param name="newStorage">ILArray holding the new values. The size of storage must NOT! match 
		/// dimensions specified by range. If the sizes differ, newStorage's values will be iterated and 
		/// repeatedly used. However, the dimensions specified by range must (of course) fit inside this storage.</param>
        public void FillRange(ILRange range, ILArray<T> valueStorage) {
            if (newStorage is ILPhysicalStorage<T>) {
                SetRange(range, ((ILPhysicalStorage<T>)newStorage).GetData()); 
			} else {				SetRange (range,newStorage.CreateIterator());
			}
		}
		/// <summary>
		/// Fill a range of this array with scalar value 
		/// </summary> 
		/// <param name="range">ILRange specifying the dimensions to alter</param>
		/// <param name="newVal">scalar (T) value to set the range to.</param>
		public void FillRange(ILRange range, T newVal) {
			SetRange (range,new T[1]{newVal}); 
		}
*/
/*		#region Add
				/// <summary>
				/// Add another storage to this storage elementwise.
				/// </summary>
				/// <param name="inp">ILArray to add to this storage.</param>
				/// <returns>New ILPhysicalStorage as the sum of the values of both storages.</returns>
				/// <remarks>The values of this storage will not be altered. The size of inp must match the size of this storage. a.Add(b) is equivalent to a+b</remarks>
				public virtual ILPhysicalStorage<T> Add<U>(ILArray<U> inp)
												  where U : IILBasicMath<U> {
					T tmp = default(T);
					if (!(tmp is IILBasicMath<T>))
						throw new InvalidOperationException("This operation is not supported on current type!");
					if (!m_dimensions.IsSameSize(inp.Dimensions)) 
						throw new Exception("Dimension must match existing object.");
            
					ILPhysicalStorage<T> ret = new ILPhysicalStorage<T>(m_dimensions); 
					T[] data = ret.GetData();
					ILIterator<T> it1 = CreateIterator();
					ILIterator<U> it2 = inp.CreateIterator();
					long retPosition = 0; 
					while (true) {
						data[retPosition++] = ((IILBasicMath<T>)it1.Value).Add(it2.Value); 
						if (it1.IsAtEnd()) break; 
						it1++;
						it2++;
					} 
					return ret;
				}
				#endregion
				#region Subtract
				/// <summary>
				/// Subtract another storage from this storage elementwise.
				/// </summary>
				/// <param name="inp">ILArray to subtract to this storage.</param>
				/// <returns>New ILPhysicalStorage as the difference of the values 
				/// of both storages.</returns>
				/// <remarks>The values of this storage will not be altered. The size 
				/// of inp must match the size of this storage. a.Subtract(b) 
				/// is equivalent to a-b.</remarks>
				public virtual ILPhysicalStorage<T> Subtract<U>(ILArray<U> inp)
																where U : IILBasicMath<U> {
					T tmp = default(T);
					if (!(tmp is IILBasicMath<T>))
						throw new InvalidOperationException("This operation is not supported on current type!");
					if (!m_dimensions.IsSameSize(inp.Dimensions)) 
						throw new Exception("Dimension must match existing object.");
					ILPhysicalStorage<T> ret = new ILPhysicalStorage<T>(m_dimensions); 
					T[] data = ret.GetData();
					ILIterator<T> it1 = CreateIterator();
					ILIterator<U> it2 = inp.CreateIterator();
					long retPosition = 0; 
					while (true) {
						data[retPosition++] = ((IILBasicMath<T>)it1.Value).Subtract(it2.Value); 
						if (it1.IsAtEnd()) break; 
						it1++;
						it2++;
					} 
					return ret;
				}
				#endregion
				#region MultiplyElementwise 
				/// <summary>
				/// Multiply another storage to this storage elementwise.
				/// </summary>
				/// <param name="inp">ILArray to multiply to this storage.</param>
				/// <returns>New ILPhysicalStorage as the product of the values of both storages.</returns>
				/// <remarks>The values of this storage will not be altered. The size of inp must match the size of this storage. a.MultiplyElementwise(b) is equivalent to a.*b</remarks>
				public virtual ILPhysicalStorage<T> MultiplyElementwise<U>(ILArray<U> inp) 
																	where U : IILBasicMath<U> {
					T tmp = default(T);
					if (!(tmp is IILBasicMath<T>))
						throw new InvalidOperationException("This operation is not supported on current type!");
					if (!m_dimensions.IsSameSize(inp.Dimensions)) 
						throw new Exception("Dimension must match existing object.");
					ILPhysicalStorage<T> ret = new ILPhysicalStorage<T>(m_dimensions); 
					T[] data = ret.GetData();
					ILIterator<T> it1 = CreateIterator();
					ILIterator<U> it2 = inp.CreateIterator();
					long retPosition = 0; 
					while (true) {
						data[retPosition++] = ((IILBasicMath<T>)it1.Value).Multiply(it2.Value); 
						if (it1.IsAtEnd()) break; 
						it1++;
						it2++;
					} 
					return ret;
				}
				#endregion
				#region Divide 
				/// <summary>
				/// Divide this storage by input storage elementwise.
				/// </summary>
				/// <param name="inp">ILArray to divide from to this storage.</param>
				/// <returns>New ILPhysicalStorage as the quotient of the values of 
				/// both storages.</returns>
				/// <remarks>The values of this storage will not be altered. The size 
				/// of inp must match the size of this storage. a.DivideElementwise(b)
				/// is equivalent to a./b.</remarks>
				public virtual ILPhysicalStorage<T> Divide<U>(ILArray<U> inp)  
																where U : IILBasicMath<U>, IILKnowsNaN {
					T tmp = default(T);
					if (!(tmp is IILBasicMath<T>))
						throw new InvalidOperationException("This operation is not supported on current type!");
					if (!Dimensions.IsSameSize(inp.Dimensions)) 
						throw new Exception("Dimension must match existing object.");
					ILPhysicalStorage<T> ret = new ILPhysicalStorage<T>(m_dimensions); 
					T [] data = ret.GetData();
					ILIterator<T> it1 = CreateIterator();
					ILIterator<U> it2 = inp.CreateIterator();
					long dataPos = 0; 
					while (true) {
						try {
							data[dataPos++] = ((IILBasicMath<T>)it1.Value).Divide(it2.Value); 
						} catch(DivideByZeroException) {
							((IILKnowsNaN)data[dataPos++]).SetNaN();
						}
						if (it1.IsAtEnd()) break; 
						it1++;
						it2++;
					}
					return ret;
				}
				#endregion
				#region Multiply 
				/// <summary>
				/// Matrix multiply - for 2 dim. storages only! 
				/// </summary>
				/// <param name="inp">ILArray to matrix multiply to this storage. The size must match the size of this storage. See remarks for details.</param>
				/// <returns>New ILPhysicalStorage as the result of matrix multiplication</returns>
				/// <remarks>The values of this storage will not be altered. The number of columns in this storage 
				/// must match the number of rows in inp storage. 
				/// Example: if this storage is of size NxC and inp storage is od size CxM the result will be of size NxM. 
				/// <br>This is defined for Matrices only. Therefore the request should 
				/// be forwarded to corresponding functions inside ILMatrixStorage/ ILRefMatrixStorage respectively.</br></remarks>
				public virtual ILPhysicalStorage<T> Multiply<U>(ILArray<U> inp)
																where U : IILBasicMath<U> {
					T tmp = default(T);
					if (!(tmp is IILBasicMath<T>))
						throw new InvalidOperationException("This operation is not supported on current type!");
					throw new ArgumentException("ILArray|Multiply: This Operation is not defined for storages of more than 2 ns. dimensions!"); 
				}

				#endregion 
		 */
		/*		/// <summary>
		/// Get single value from this storage
		/// </summary>
		/// <param name="idx">Long index number pointing directly to the needed value</param>
		/// <returns>Value on the poition pointed to by idx</returns>
		/// <remarks>this is the fast access method for storages with exact knowledge of the underlying physicalstorage. (ie. Matrix )</remarks>
		protected virtual object GetValue(long idx);

		/// <summary>
		/// Set single value inside this storage
		/// </summary>
		/// <param name="idx">Integer array holding the dimension specifier pointing to the needed location.</param>
		/// <param name="val">Value on the position pointed to by idx</param>
		public abstract void SetValue(int[] idx, object val);
		/// <summary>
		/// Set single value inside this storage
		/// </summary>
		/// <param name="idx">Integer array holding the dimension specifier pointing to the needed location.</param>
		/// <param name="val">Value on the position pointed to by idx</param>
		public abstract void SetValue(long idx, T val);
*/
		#endregion 
	
        #region single element access 

        /// <summary>
        /// Get single value from this storage
        /// </summary>
        /// <param name="idx">Integer array holding the dimension specifier 
        /// pointing to the value</param>
        /// <returns>Object on the position pointed to by idx</returns>
        public override BaseT GetValue(params int[] idx) {
            if (m_indexOffset == null) {
                if (idx.Length == 1)
                    return m_data[idx[0]]; 
                int destIdx = idx[0], d, highDims; 
                if (destIdx >= m_dimensions[0] || destIdx < 0)
                        throw new ILArgumentException("GetValue: index out of bound for dimensions: 0");
                int [] seqDist = m_dimensions.GetSequentialIndexDistances(0); 
                if (idx.Length <= m_dimensions.NumberOfDimensions) {
                    for (d = 1; d < idx.Length - 1; d++) {
                        if (idx[d] >= m_dimensions[d] || idx[d] < 0)
                            throw new ILArgumentException("GetValue: index out of bound for dimensions: " + d.ToString());
                        destIdx += idx[d] * seqDist[d]; 
                    }
                    for (highDims = idx[d]; d<m_dimensions.NumberOfDimensions && highDims > 0; d++) {
                        destIdx += (highDims % m_dimensions[d]) * seqDist[d]; 
                        highDims /= m_dimensions[d]; 
                    }
                    if (highDims > 0) throw new ILArgumentException ("GetValue: index out of bound!"); 
                    return m_data[destIdx];
                } else {
                    highDims = m_dimensions.NumberOfDimensions; 
                    for (d = 1; d < highDims; d++) {
                        if (idx[d] >= m_dimensions[d] || idx[d] < 0)
                            throw new ILArgumentException("GetValue: index out of bound for dimensions: " + d.ToString());
                        destIdx += idx[d] * seqDist[d]; 
                    }
                    for (; d<idx.Length; d++) {
                        if (idx[d] != 0) 
                            throw new ILArgumentException("GetValue: index out of bound for dimension: " + d.ToString() + ". Trailing indices must be 0!");
                    }
                    return m_data[destIdx];
                }
            } else {
                int destIdx = 0, d,highDims;
                if (idx.Length <= m_dimensions.NumberOfDimensions) {
                    for (d = 0; d < idx.Length - 1; d++) {
                        if (idx[d] < 0 || idx[d] >= m_dimensions[d])
                            throw new ILArgumentException("GetValue: index out of bound for dimensions: 0");
                        destIdx += m_indexOffset[d,idx[d]]; 
                    }
                    for (highDims = idx[d]; d<m_indexOffset.Length; d++) {
                        destIdx += m_indexOffset[d,highDims % m_indexOffset[d].Length]; 
                        highDims /= m_indexOffset[d].Length; 
                    }
                    if (highDims > 0) throw new ILArgumentException ("GetValue: index out of bound!"); 
                    return m_data[destIdx];
                } else { 
                    highDims = m_dimensions.NumberOfDimensions; 
                    for (d = 0; d < highDims; d++) {
                        if (idx[d] < 0 || idx[d] >= m_dimensions[d])
                            throw new ILArgumentException("GetValue: index out of bound for dimensions: 0");
                        destIdx += m_indexOffset[d,idx[d]]; 
                    }
                    for (; d<idx.Length; d++) {
                        if (idx[d] != 0) 
                            throw new ILArgumentException("GetValue: index out of bound for dimension: " + d.ToString());
                    }
                    return m_data[destIdx];
                }
            }
        }
        /// <summary>
        /// Get single value from this storage by single sequential access
        /// </summary>
        /// <param name="idx">Integer array holding the dimension specifier 
        /// pointing to the value</param>
        /// <param name="dims">out value: return mapped position in dimensions</param>
        /// <returns>Object on the position pointed to by idx</returns>
        /// <remarks>dims is the final position into the array for the sequential index specification <c>idx</c>.</remarks>
        public BaseT GetValueSeq(int idx, ref int[] dims) {
            if (m_indexOffset == null) {
                int IdxCpy = idx; 
                for (int d = 0; d<m_dimensions.NumberOfDimensions ; d++) {
                    dims[d] = (IdxCpy % m_dimensions[d]); 
                    //if (IdxCpy <= 0) break;  // hm. better clean the ref array, he?
                    IdxCpy /= m_dimensions[d]; 
                }
                return m_data[idx];
            } else {
                int destIdx = 0,d;
                for (d = 0; d<m_dimensions.NumberOfDimensions; d++) {
                    dims[d] = idx % m_dimensions[d]; 
                    destIdx += m_indexOffset[d,dims[d]];
                    idx /= m_dimensions[d]; 
                }
                if (idx > 0) throw new ILArgumentException ("GetValue: index out of bound!"); 
                return m_data[destIdx];
            }
        }
        /// <summary>
        /// Set single value to element at index specified.
        /// </summary>
        /// <param name="value">new value</param>
        /// <param name="idx">index of element to be altered</param>
        public override void SetValue(BaseT value, params int[] idx) {
            if (idx.Length == 0) return; 
            int [] dimensions = m_dimensions.ToIntArray(idx.Length);  
            bool mustExpand = false; 
            int i = getBaseIndex(ref mustExpand, ref dimensions, idx);  
            if (!mustExpand) {
                if (mustDetach())
                    Detach();
                m_data[i] = value;
            } else {
                ExpandArray(dimensions);
                m_data[i] = value;
            }
        }

        /// <summary>
        /// Convert index array into sequential index for storage access.
        /// </summary>
        /// <param name="idx">int array with dimensions specification</param>
        /// <returns>Index of requested value inside the physical storage. This 
        /// value may directly be used to query the value via m_data[return_value].
        /// The value return is valid for physical storages as well as for reference 
        /// storages.
        /// </returns>
        /// <remarks>If the length of idx is smaler than the number of dimensions 
        /// of this storage, the trailing dimensions will be replaced with "0". I.e 
        /// the first index of each non specified dimensions will be used. 
        /// If length of idx is larger than the dimensions of this storage, the behavior
        /// is undefined. Therefore this function should be enclosed in try,catch blocks 
        /// to handle this case!</remarks>
        internal int getBaseIndex(params int[] idx) {
            int destIdx = 0;
            //System.Diagnostics.Debug.Assert(idx.Length > 1,"for single index overloaded function of 'getBaseIndex' should be called."); 
            if (m_indexOffset == null) {
                if (idx.Length == 1)
                    return idx[0];
                return m_dimensions.IndexFromArray(idx);
            } else {
                if (idx.Length == 1) 
                    return m_indexOffset.Map(idx[0]); 
                int d, t;
                for (d = 0; d < idx.Length - 1; d++)
                    destIdx += m_indexOffset[d, idx[d]];
                // keep track of non specified dimensions -> set to '0'
                t = idx[d]; 
                for (; d < m_indexOffset.Length; d++) {
                    destIdx += m_indexOffset[d, t % m_dimensions[d]];
                    t /= m_dimensions[d]; 
                }
                return destIdx;
            }
        }
        /// <summary>
        /// Convert index array into sequential index for storage access. Ommit any bound checking.
        /// </summary>
        /// <param name="idx">int array with dimensions specification</param>
        /// <param name="MustExpand">Output parameter. On return determine, if the index 
        /// specification points outside of the dimensions of this ILArray and the array 
        /// must be expanded before accessing elements on that position</param>
        /// <param name="Dimensions">if the array was found to be expanded, this are the 
        /// needed dimension sizes for the new array. The sizes are computed from the range 
        /// specification given.</param>
        /// <returns>Index of requested value inside the physical storage. This 
        /// value may directly be used to query the value via m_data[return_value].
        /// The value returned is valid for physical storages as well as for reference 
        /// storages.
        /// </returns>
        /// <remarks>
        /// <para>idx must be not null and must contain at least one element.</para>
        /// <para>If the length of idx is smaler than the number of dimensions 
        /// of this storage, the trailing dimensions will be replaced with "0". I.e 
        /// the first index of each non specified dimensions will be used. 
        /// If length of idx is larger than the dimensions of this storage, the index of 
        /// the expanded array will be returned.</para></remarks>
        internal int getBaseIndex(ref bool MustExpand, ref int[] Dimensions, params int[] idx) {
            int destIdx = 0;
            //System.Diagnostics.Debug.Assert(idx.Length > 1,"for single index overloaded function of 'getBaseIndex' should be called."); 
            if (m_indexOffset == null) {
                if (idx.Length == 1) {
                    destIdx = idx[0]; 
                    if (destIdx < 0)
                        throw new ILArgumentException("check index for dimension 0!");
                    if (destIdx >= m_dimensions.NumberOfElements) {
                        MustExpand = true; 
                        Dimensions[0] = destIdx + 1; 
                    }
                    return destIdx;
                }
                return m_dimensions.IndexFromArray(ref MustExpand, ref Dimensions, idx);
            } else {
                destIdx = m_indexOffset.IndexFromArray(idx); 
                if (destIdx < 0) {
                    // must expand
                    return m_dimensions.IndexFromArray(ref MustExpand, ref Dimensions, idx);
                } else {
                    return destIdx; 
                }
            }
        }
        /// <summary>
        /// Convert sequential index into sequential index for physical storage access.
        /// </summary>
        /// <param name="idx">index for this storage. </param>
        /// <returns>Index of requested value inside the physical storage. This 
        /// value may directly be used to query the value via m_data[return_value].
        /// The value return is valid for physical storages as well as for reference 
        /// storages.
        /// </returns>
        /// <remarks>Since the user normally does not know, 
        /// if this storage is a reference storage, this function maps the sequential index 
        /// of this storage to the sequential index of the underlying physical storage (if any).
        /// </remarks>
        internal int getBaseIndex(int idx) {
            if (m_indexOffset == null) {
                return idx;
            } else {
                return m_indexOffset.Map(idx);
            }
        }
        /// <summary>
        /// Copy values of all elements into System.Array
        /// </summary>
        /// <param name="result">System.Array returned, holding all element values of this ILArray</param>
        /// <remarks>The System.Array may be predefined. If its length is sufficient, it will be used and 
        /// corresponding elements with index lower or equal to i will be overwritten. Here i is the number of elements
        /// contained in the ILArray. If 'result' is null or has less than i elements, it will be recreated from the ILMemeoryPool.</remarks>
        public void ExportValues(ref BaseT[] result) {
            if (result == null || result.Length < m_dimensions.NumberOfElements)
                result = ILMemoryPool.Pool.New<BaseT>(m_dimensions.NumberOfElements);
            if (m_indexOffset==null) {
                System.Array.Copy(m_data,result,m_dimensions.NumberOfElements);
            } else {
                int pos = 0; 
                foreach (BaseT v in Values) {
                    result[pos++] = v; 
                }
            }
        }
        #endregion 

        #region index access

        /// <summary>
        /// Subarray access for get/set/removal 
        /// </summary>
        /// <param name="range">range specification</param>
        /// <returns>reference pointing to the elements of this array specified by range. If used for removal: 
        /// the array will be changed to a referencing array having the selected parts removed.</returns>
        /// <remarks>Query access: for N-dimensional arrays and at least 1 dimensions specified, missing trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in range.
        /// <example>
        /// <code>Having a matrix A =     
        /// [0, 1, 2, 3
        /// 4, 5, 6, 7];
        /// So A[":,2"] will lead to 
        /// [2
        ///  6]; 
        /// A["1,:"] gives [4, 5, 6, 7]
        /// A["1"] gives [4]
        /// A["1,1"] gives [5]
        /// </code>
        /// </example>
        /// <para>The indexer may be used for querying or altering single/any elements 
        /// in this array. <c>range</c> may contains complex index specifications for one ... any 
        /// dimension. If more than one dimension is to be specified, the dimensions must be seperated 
        /// by ';' (semicolon).</para>
        /// <para>The indexer may also be used for removing parts of the array. Therefore an empty array 
        /// (of the same type) must be assigned to the range specified by <c>range</c> using the set-access. <c>range</c> 
        /// must contain exactly one dimension specification other than ";". If <c>range</c> applies 
        /// to less dimensions than dimensions existing in the array, the upper dimensions will be 
        /// merged and the array will be reshaped before applying the removal to it.</para>
        /// <para>In case of removal the ILArray returned will be a reference array.</para></remarks>
        public ILArray<BaseT> this[params string[] range] {
            get {
                return (ILArray<BaseT>)Subarray(range);
            }
            set {
                if (Object.ReferenceEquals(value,null) || value.IsEmpty) {
                    ILDimension oldDim = m_dimensions; 
                    ILDimension newdim = null;
                    int dimIdx = -1; 
                    int[] indices = null; 
                    ExtractRemovalParameter(range,out dimIdx,out indices, out newdim); 
                    if (indices.Length == 0)
                        return; 
                    Reshape(newdim);
                    try {
                        Remove(dimIdx,indices); 
                    } catch (ILException e) {
                        // rollback: 
                        Reshape(oldDim); 
                        throw e; 
                    }
                } else {
                    SetRange(new ILRange(m_dimensions, RangeSide.Left,range), value);
                }
            }
        }
        /// <summary>
        /// Subarray access for ILArray and dimension shift
        /// </summary>
        /// <paramref name="dims" value="dimension specification"/>
        /// <value>returns new ILArray as reference subarray to this ILBaseArray</value>
        public ILArray<BaseT> this[Int16 shiftDims, params string[] dims] {
            get {
                if (dims == null || dims.Length == 0)
                    return (ILArray<BaseT>)ShiftDimensions(shiftDims);
                return (ILArray<BaseT>)Subarray(shiftDims,dims);
            }
        }
        /// <summary>
        /// get/set/remove single element 
        /// </summary>
        /// <param name="indices">The type of access depends on the length of indices. 
        /// <list type="bullet">
        /// <item>if indices is a single value: sequential (linear) index of element to access</item>
        /// <item>if indices.Length &gt; 1: index array access </item></list></param>
        /// <returns>scalar ILArray of same type than this array with the only element</returns>
        /// <remarks>If indices contains only one element, the array will be accessed via sequential index access. 
        /// This is sometimes called "linear" index access also. Sequential index access reflects the index of internal storage 
        /// the way the data are actually organized in memory. This access method is mainly convinient for vectors where you are not interested of orientation.
        /// The following example demonstrates sequential index access: 
        /// <example><code>
        /// ILArray&lt;double&gt; A = new  ILArray&lt;double&gt;(1.0,12.0);
        /// A[2] gives: 3.0
        /// </code>But
        /// <code>
        /// A.T[2] gives also: 3.0
        /// </code> 
        /// For matrices and N-dimensional arrays this holds as well: 
        /// <code>
        /// ILArray&lt;double&gt; A = new  ILArray&lt;double&gt;(1.0,12.0);
        /// A = 
        /// [1.0 4.0
        ///  2.0 5.0 
        ///  3.0 6.0 
        /// 
        ///  7.0 10.0
        ///  8.0 11.0
        ///  9.0 12.0]
        /// 
        /// A = ILMath.Reshape(A,3,2,2); 
        /// A[10] gives 11.0
        /// A[10,1] gives ILArgumentException -> out of range
        /// A[2,1,1] gives 12.0
        /// A[2,1] gives 6.0</code>
        /// <para>For get access the array returned will be a scalar solid array.</para></example>
        /// <para>The reason, this indexer return ILArray is that returning BaseT directly would permit 
        /// the use of convinient syntax: A[2] = null; for removal ! There is also the argument of consistency between the indexer. </para></remarks>
        public virtual ILArray<BaseT> this[params int[] indices] {
            get {
                return new ILArray<BaseT>(GetValue(indices)); 
            }
            set {
                if (Object.Equals(value,null) || value.IsEmpty) {
                    // remove attempt - remove matching
                    if (indices.Length != 1)
                        throw new ILArgumentException("error removing: index specification must be scalar!");
                    if (IsRowVector)
                        Remove(1,indices); 
                    else if (IsColumnVector) 
                        Remove(0,indices); 
                    else if (IsScalar) 
                        Remove(0,indices); 
                    else 
                        throw new ILArgumentException("error removing: single index removal is only allowed for vector or scalar arrays!");
                } else {
                    if (!value.IsScalar) 
                        throw new ILArgumentException("set value: scalar value expected"); 
                    SetValue(value.GetValue(0), indices);
                }
            }
        }
        
        /// <summary>
        /// subarray access
        /// </summary>
        /// <param name="range">range specification</param>
        /// <returns>reference pointing to the elements of this array specified by range. If used for removal: 
        /// the array will be changed to a referencing array having the parts requested removed and reshaped accordingly.</returns>
        /// <remarks>Query access: for N-dimensional arrays trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in range.
        /// <para>The indexer may be used for querying or altering single/any elements 
        /// in this array. <c>range</c> may contains index specifications for one ... any 
        /// dimension. The array returned will have the size specified by range.</para>
        /// <para>The indexer may also be used for removing parts of the array. Therefore an empty array 
        /// (of the same type) or 'null' must be assigned to the range specified by <c>range</c> using the set-access. <c>range</c> 
        /// must contain exactly one dimension specification other than null. This may be any vector-sized numeric ILArray of any 
        /// type. If <c>range</c> applies 
        /// to less dimensions than dimensions existing in the array, the upper dimensions will be 
        /// merged and the array will be reshaped before applying the removal to it.</para>
        /// <para>In case of removal the ILArray returned will be a reference array.</para></remarks>
        public ILArray<BaseT> this [params ILBaseArray [] range] {
            get {
                return (ILArray<BaseT>)Subarray(range);
            }
            set {
                if (Object.ReferenceEquals(value,null) || value.IsEmpty) {
                    ILDimension newdim = null;
                    int dimIdx = -1; 
                    int[] indices = null; 
                    ExtractRemovalParameter(range,out dimIdx,out indices, out newdim); 
                    if (indices.Length == 0)
                        return; 
                    ILDimension oldDim = m_dimensions; 
                    try {
                        Reshape(newdim);
                        Remove(dimIdx,indices);
                    } catch (Exception e) {
                        // rollback 
                        Reshape(oldDim); 
                        throw e; 
                    }
                } else {
                    if (range == null || range.Length == 0) {
                        return; 
                    } else if (range.Length > 1) {
                        SetRange ( new ILRange (m_dimensions,RangeSide.Left, range), value );
                    } else if (range[0] is ILArray<double>) {
                        SetRange ( range[0] as ILArray<double>,value);
                    } else if (range[0] is ILArray<float>) {
                        SetRange ( range[0] as ILArray<float>,value);
                    } else if (range[0] is ILArray<complex>) {
                        SetRange ( range[0] as ILArray<complex>,value);
                    } else if (range[0] is ILArray<fcomplex>) {
                        SetRange ( range[0] as ILArray<fcomplex>,value);
                    } else if (range[0] is ILArray<Int16>) {
                        SetRange ( range[0] as ILArray<Int16>,value);
                    } else if (range[0] is ILArray<Int32>) {
                        SetRange ( range[0] as ILArray<Int32>,value);
                    } else if (range[0] is ILArray<Int64>) {
                        SetRange ( range[0] as ILArray<Int64>,value);
                    } else if (range[0] is ILArray<UInt16>) {
                        SetRange ( range[0] as ILArray<UInt16>,value);
                    } else if (range[0] is ILArray<UInt32>) {
                        SetRange ( range[0] as ILArray<UInt32>,value);
                    } else if (range[0] is ILArray<UInt64>) {
                        SetRange ( range[0] as ILArray<UInt64>,value);
                    } else if (range[0] is ILLogicalArray) {
                        SetRange ( ILNumerics.BuiltInFunctions.ILMath.find(range[0] as ILLogicalArray), value); 
                    } else if (range[0] is ILArray<byte>) {
                        SetRange ( range[0] as ILArray<byte>,value);
                    } else 
                        throw new ILArgumentException("unsupported type of range specification!");
                }
            }
        }
        /// <summary>
        /// ranged subarray access
        /// </summary>
        /// <param name="shiftDim">number of dimensions to shift the result</param>
        /// <param name="range">range specification</param>
        /// <returns>reference pointing to the elements of this array specified by range. </returns>
        /// <remarks>For n-dimensional arrays trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in range. However, if range contains only one array, those indices 
        /// are interpreted as sequential index access elements. I.e. the elements in the index vector are allowed to 
        /// range from 0...[NumberOfElements-1]. A vector containing corresponding elements will be returned for this case.
        /// <para>The indexer may be used for querying single/any elements 
        /// in this array. <c>range</c> may contains index specifications for one ... any 
        /// dimension. The array returned will have the size specified by range.</para></remarks>
        public ILArray<BaseT> this [Int16 shiftDim, params ILBaseArray[] range] {
            get {
                   return (ILArray<BaseT>)Subarray(shiftDim,range);
            }
        }
        /// <summary>
        /// helper function to prepare parameters for partial removal 
        /// </summary>
        /// <param name="range">object with index specification.May be of 
        /// type ILBaseArray[] with numeric arrays or a string array according 
        /// to the format of <see cref="ILNumerics.Storage.ILRange"/>. 
        /// </param>
        /// <param name="dimensionIdx">out parameter: number of dimension the indices to be removed lay in</param>
        /// <param name="indices">indices to be removed</param>
        /// <param name="dimensions">dimension structure, may be used if the array must be 
        /// reshaped <b>before</b> the removal.</param>
        /// <remarks>if range consists out of a range specification wich is smaller than 
        /// the actual dimension length of this array, the array must also be reshaped in order to remove 
        /// the data accordingly. This reshape proccess will <b>not</b> be done inside of this function! However 
        /// ther <c>dimension</c> value returned reflect the size of the array before removing and therefore
        /// may comfortable be used for reshaping the array.</remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <list type="bullet">
        /// <item>the length of range exceeds the dimensions of this array</item>
        /// <item>more or less than exactly one dimension of <c>range</c> was not null</item>
        /// <item>the type of range was invalid, or</item>
        /// <item>range is of type array of <see cref="ILNumerics.ILBaseArray"/>, but the elements are non numeric ILArray's</item>
        /// </list></exception>
        private void ExtractRemovalParameter (object range, out int dimensionIdx, out int[] indices, out ILDimension dimensions) {
            dimensionIdx = 0; 
            indices = null;
            dimensions = null;               
            int inDimCount = 0; 
            if (range is ILBaseArray[]) {
                #region ILBaseArray[] input
                ILBaseArray[] rng = (ILBaseArray[]) range; 
                if (rng.Length > m_dimensions.NumberOfDimensions)
                    throw new ILArgumentException("Error removing: dimension specification exceeds matrix dimensions."); 
                int specCount = 0; 
                int tmp = 0; 
                inDimCount = rng.Length;
                for (int i = 0; i < rng.Length; i++) {
                    if (rng[i] != null && !rng[i].IsEmpty) {
                        dimensionIdx = i; 
                        if (specCount++ > 0) 
                            throw new ILArgumentException ("Error removing: only one dimension must be non-empty!");
                        if (false) {
                        } else if (rng[i] is  ILLogicalArray ) {
                            ILArray<double> ind = ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)rng[i]); 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
#region HYCALPER LOOPSTART
/* !HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
</hycalper>
*/
                        } else if (rng[i] is /*!HC:inCls1*/ ILArray<double> ) {
                            /*!HC:inCls1*/ ILArray<double> ind = (/*!HC:inCls1*/ ILArray<double> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<fcomplex> ) {
                            ILArray<fcomplex> ind = ( ILArray<fcomplex> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<complex> ) {
                            ILArray<complex> ind = ( ILArray<complex> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<byte> ) {
                            ILArray<byte> ind = ( ILArray<byte> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<char> ) {
                            ILArray<char> ind = ( ILArray<char> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<UInt64> ) {
                            ILArray<UInt64> ind = ( ILArray<UInt64> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<UInt32> ) {
                            ILArray<UInt32> ind = ( ILArray<UInt32> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<UInt16> ) {
                            ILArray<UInt16> ind = ( ILArray<UInt16> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<Int64> ) {
                            ILArray<Int64> ind = ( ILArray<Int64> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<Int32> ) {
                            ILArray<Int32> ind = ( ILArray<Int32> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<Int16> ) {
                            ILArray<Int16> ind = ( ILArray<Int16> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }
/* !HC:TYPELIST:

*/
                        } else if (rng[i] is  ILArray<float> ) {
                            ILArray<float> ind = ( ILArray<float> )rng[i]; 
                            tmp = ind.Dimensions.NumberOfElements; 
                            indices = new int[tmp]; 
                            for (int p = 0; p < tmp; p++) {
                              indices[p] = (int)ind.GetValue(p);  
                            }

#endregion HYCALPER AUTO GENERATED CODE
                        } else 
                            throw new ILArgumentTypeException("error removing: dimensions specifier must be numeric type!");
                     } 
                }
                if (indices == null) {
                    dimensionIdx = 0; 
                    dimensions = m_dimensions; 
                    indices= new int[0]{}; 
                    return; 
                }
        #endregion 
            } else if (range is string[]) {
                #region string input 
                string[] rng = (string[])range; 
                if (rng.Length == 1) 
                    rng = rng[0].Split(';'); 
                if (rng.Length > m_dimensions.NumberOfDimensions)
                    throw new ILArgumentException("Error removing: dimension specification exceeds matrix dimensions."); 
                int specCount = 0; 
                inDimCount = rng.Length;
                for (int i = 0; i < rng.Length; i++) {
                    if (rng[i] != null && rng[i].Trim() != ":") {
                        dimensionIdx = i; 
                        if (specCount++ > 0) 
                            throw new ILArgumentException ("Error removing: only one dimension must be non-empty!");
                        rng[i] = rng[i].Replace("end",(m_dimensions[i]-1).ToString());
                        string[] tmpIdx = rng[i].Split(','); 
                        List<int> ids = new List<int>(); 
                        try {
                            for (int c = 0; c < tmpIdx.Length; c++) {
                                string[] tmprng = tmpIdx[c].Split(':'); 
                                switch (tmprng.Length) {
                                    case 1: 
                                        // no range spec.
                                        ids.Add(int.Parse(tmprng[0].Trim())); 
                                        break; 
                                    case 2: 
                                        // single range: spacing 1
                                        int start = int.Parse(tmprng[0].Trim()); 
                                        int ende = int.Parse(tmprng[1].Trim()) + 1; 
                                        for (int r = start; r < ende; r++) {
                                            ids.Add (r); 
                                        }
                                        break; 
                                    case 3:
                                        // single range: spacing 1
                                        start = int.Parse(tmprng[0].Trim()); 
                                        ende = int.Parse(tmprng[2].Trim()) + 1; 
                                        int step = int.Parse(tmprng[1].Trim()); 
                                        for (int r = start; r < ende; r += step) {
                                            ids.Add (r); 
                                        }
                                        break; 
                                }
                            }
                            indices = ids.ToArray(); 
                        } catch (FormatException e) {
                            throw new ILArgumentException("remove: invalid index in " + i.ToString() + "th dimension! Did you seperate dimensions by ';'? (" + e.Message + ")"); 
                       }
                    }
                }
                if (indices == null) {
                        dimensionIdx = 0; 
                        dimensions = m_dimensions; 
                        indices= new int[0]{}; 
                        return; 
                }
                #endregion
            } else {
                throw new ILArgumentException("Invalid range specification. The type of indices specified is invalid. Remove failed."); 
            }
            // check if array must be reshaped
            int [] tmpDim = new int[(inDimCount > 1)? inDimCount : 2]; 
            int pos =  0; 
            while (pos < m_dimensions.NumberOfDimensions) {
                if (pos < inDimCount)
                    tmpDim[pos] = m_dimensions[pos]; 
                else {
                    int mult = 1; 
                    int i = pos; 
                    while (i < m_dimensions.NumberOfDimensions) {
                        mult *= m_dimensions[i++];                             
                    }
                    tmpDim[pos-1] *= mult; 
                    break; 
                }
                pos ++; 
            } 
            // if only one dimension specified -> make row vector
            if (pos == 1) {
                tmpDim[1] = tmpDim[0];
                tmpDim[0] = 1;
                dimensionIdx = 1; 
            }
            dimensions = new ILDimension(tmpDim); 
        }
#endregion

        /// <summary>
        /// Create full (shallow) copy of this storage. 
        /// </summary>
        /// <returns>ILFullArray as new (physical) representation of this storages data.</returns>
        /// <remarks>The ILFullArray object returned will be of the same size than this object.
        /// Keep in mind, no reference counters are altered! The new object is just a plain 
        /// copy of the old one which remains unchanged. Also: "copy" means, the m_data array
        /// will be copied, but (of course) not (!) the objects referenced by the array elements!
        /// Therefore this is a 'shallow' copy only! This is necessary, since objects stored inside
        /// ILArray do not have any restrictions. (Especially they do not have to support the IClonable()
        /// interface.) </remarks>
        public override object Clone() {
            if (!IsReference) // SM: Should be not!!!
                return CreatePhysicalShiftedFromPhysical(0); 
            else 
                return CreatePhysicalShiftedFromReference(0); 
        }
        /// <summary>
        /// Create iterator, initialized to run from start over first dimension
        /// </summary>
        /// <returns>Iterator of the same type as the current instance of ILArray, initialized 
        /// to the first element, ready for counting forwards on 
        /// the first dimension.</returns>
        public override ILIterator<BaseT> CreateIterator() {
            return new ILIterator<BaseT>(m_data,m_indexOffset,m_dimensions);
        }
        /// <summary>
        /// Create iterator for the elements of the current instance of ILArray, specify start 
        /// element and dimension to walk along
        /// </summary>
        /// <param name="pos">start position. One out of the ILIteratorPositions: 
        /// ILStart, ILMiddle, ILEnd</param>
        /// <param name="leadingDimension">The dimension index to walk along</param>
        /// <returns>Iterator of the same type as the current instance of ILArray
        /// </returns>
        public override ILIterator<BaseT> CreateIterator(ILIteratorPositions pos, int leadingDimension) {
            return new ILIterator<BaseT>(m_data, m_indexOffset, m_dimensions,pos,leadingDimension);
        }

        #region IEnumerable<ILBaseArray<BaseT>> Member

        /// <summary>
        /// Enumerator creation
        /// </summary>
        /// <returns>Enumerator</returns>
        /// <remarks>This function enables the use of ILArray inside 'foreach' constructs. You 
        /// barely will use it directly.</remarks>
        /// <example>ILArray&lt;T&gt; A = ILMath.rand(5,4,6);
        /// foreach (ILArray&lt;T&gt; element in A) {
        /// // all 'element's are scalar ILArray's
        /// String.Format("Element: {0} ",element.GetValue(0));
        /// }
        /// </example>
        /// <seealso cref="ILNumerics.ILArray&lt;T&gt;.Values"/>
        public override IEnumerator<ILArray<BaseT>> GetEnumerator ( ) {
            int len = m_dimensions.NumberOfElements; 
            if (m_indexOffset != null) {
                for (int i = 0; i < len; i++) 
                    yield return new ILArray<BaseT>(new BaseT[]{GetValue(i)});
            } else {
                for (int i = 0; i < len; i++) 
                    yield return new ILArray<BaseT>(new BaseT[]{m_data[i]});
            }
        }
        /// <summary>
        /// Enumerator returning elements in their natural type
        /// </summary>
        /// <example>ILArray&lt;T&gt; A = ILMath.rand(5,4,6);
        /// foreach (double element in A.Values) {
        /// // all 'element's are scalar double values
        /// String.Format("Element: {0} ",element);
        /// }
        /// </example>
        public override IEnumerable<BaseT> Values {
            get{
                if (m_indexOffset != null) {
                    int len = m_dimensions.NumberOfElements; 
                    for (int i = 0; i < len; i++) 
                        yield return GetValue(i);
                } else {
                    for (int i = 0; i < m_data.Length; i++) 
                        yield return m_data[i];
                }
            }
        }
        #endregion

        #region private helper 
        private void ExtractFullRange(ILBaseArray[] range) {
            int maxDimLen = m_dimensions.NumberOfDimensions; 
            for (int i = 0; i < range.Length; i++) {
                if (i < maxDimLen) {
                    if (Object.ReferenceEquals( range[i],null)) { 
                        int dimLen = m_dimensions[i]; 
                        int[] indices = new int[dimLen]; 
                        for (int n = 0; n < dimLen; n++) 
                            indices[n] = n; 
                        range[i] = new ILArray<int>(indices,1,dimLen); 
                    }
                } else 
                    throw new ILArgumentSizeException("range: index " + i.ToString() + "dimension out of range!"); 
            }
        }
        /// <summary>
        /// Expand this storage for addresses outside my dimensions
        /// </summary>
        /// <param name="range">range to fit inside destination array</param>
        private void ExpandArray (ILRange range) {
            if (!range.Expanding)
                return; 
            int[] outDims; 
            int i= 0;
            ILDimension outDimensions; 
            if (IsEmpty) {
                outDims = new int[range.NumberOfDimensions]; 
                for (; i < range.NumberOfDimensions; i ++) 
                    outDims[i] = range.ExpandDimensions[i]; 
            } else if (range.NumberOfDimensions > m_dimensions.NumberOfDimensions) {
                outDims = new int[range.NumberOfDimensions]; 
                for (; i < m_dimensions.NumberOfDimensions; i ++) {
                    outDims[i] = (range.ExpandDimensions[i] > m_dimensions[i]) ?
                        range.ExpandDimensions[i] : m_dimensions[i]; 
                }
                for(; i < range.NumberOfDimensions; i++) 
                    outDims[i] = range.ExpandDimensions[i];
            } else {
                outDims = new int[m_dimensions.NumberOfDimensions]; 
                for (; i < range.NumberOfDimensions; i ++) {
                    outDims[i] = (range.ExpandDimensions[i] > m_dimensions[i]) ?
                        range.ExpandDimensions[i] : m_dimensions[i]; 
                }
                for(; i < m_dimensions.NumberOfDimensions; i++) 
                    outDims[i] = m_dimensions[i];
            }
            outDimensions = new ILDimension(outDims); 
            BaseT [] outData = new BaseT[outDimensions.NumberOfElements]; 
            // transfer old data to new array
            int [] tmpIdx = new int[outDims.Length]; 
            for (i = 0; i < m_dimensions.NumberOfElements; i++) {
                BaseT tmp = GetValueSeq(i,ref tmpIdx); 
                outData[outDimensions.IndexFromArray(tmpIdx)] = tmp; 
            }
            // exchange this array with newly created
            m_dimensions = outDimensions;
            DecreaseReference();
            m_data = outData; 
            IncreaseReference();
            m_indexOffset = null; 
        }
        /// <summary>
        /// Expand this storage for addressed outside my dimensions
        /// </summary>
        /// <param name="indices">range to fit inside destination array</param>
        /// <remarks>The input parameter <c>indices</c> will directly be used to create new
        /// ILDimension member of the resized array.</remarks>
        private void ExpandArray (int [] indices) {
            if (indices.Length == 2 && (indices[0] * indices[1] == 0)) {
               if (indices[0] > 0) 
                   indices[1] = 1; 
               else if (indices[1] > 0) 
                   indices[0] = 1; 
            }
            ILDimension outDimensions = new ILDimension(indices); 
            BaseT [] outData = new BaseT[outDimensions.NumberOfElements]; 
            //ILArray<BaseT> ret = new ILArray<BaseT>(outData,outDimensions);
            // transfer old data to new array
            int [] tmpIdx = new int[indices.Length]; 
            for (int i = 0; i < m_dimensions.NumberOfElements; i++) {
                BaseT tmpData = GetValueSeq(i,ref tmpIdx); 
                outData[outDimensions.IndexFromArray(tmpIdx)] = tmpData; 
            }
            // exchange this array with newly created
            m_dimensions = outDimensions;
            DecreaseReference();
            m_data = outData; 
            IncreaseReference();
            m_indexOffset = null;
        }
        /// <summary>
        /// copy upper triangular part of this array into new physical array
        /// </summary>
        /// <param name="n">length of first dimension of destination array </param>
        /// <returns>physical array of size [n x {ThisColumnCount})]</returns>
        internal ILArray<BaseT> copyUpperTriangle(int n) {
            BaseT[] arr = new BaseT[n * n];
            if (m_dimensions[0] == n) {
                if (m_indexOffset == null) {
                    for (int rcount = 0 , pos = 0; rcount < n; rcount++) {
                        for (int i = 0; i <= rcount; i++) {
                            arr[pos] = m_data[pos++];
                        }
                        pos += (n - rcount - 1);
                    }
                } else {
                    for (int rcount = 0 , pos = 0; rcount < n; rcount++) {
                        for (int i = 0; i <= rcount; i++) {
                            arr[pos] = m_data[m_indexOffset.Map(pos++)];
                        }
                        pos += (n - rcount - 1);
                    }
                }
            } else {
                if (m_indexOffset == null)
                for (int rcount = 0 , posIn = 0, posOut = 0, lenA = m_dimensions[0]; rcount < n; rcount++) {
                    for (int i = 0; i <= rcount; i++) {
                        arr[posOut++] = m_data[posIn++];
                    }
                    posOut += (n - rcount - 1);
                    posIn += (lenA - rcount - 1);
                }
                else 
                for (int rcount = 0 , posIn = 0, posOut = 0, lenA = m_dimensions[0]; rcount < n; rcount++) {
                    for (int i = 0; i <= rcount; i++) {
                        arr[posOut++] = m_data[m_indexOffset.Map(posIn++)];
                    }
                    posOut += (n - rcount - 1);
                    posIn += (lenA - rcount - 1);
                }
            }
            return new ILArray<BaseT> (arr,n,n);
        }
        /// <summary>
        /// copy lower triangular part of this array into new physical array
        /// </summary>
        /// <returns>physical array of same size than this array</returns>
        /// <remarks>if this is not a 2D array, only the first dimension is referenced.</remarks>
        internal ILArray<BaseT> copyLowerTriangle() {
            int n = m_dimensions[0],pos = 0; 
            BaseT[] arr = new BaseT[n * n];
            if (m_indexOffset == null) {
                for (int c = 0; c < m_dimensions[1]; c++) {
                    pos += c;
                    for (int r = c; r < n; r++,pos++) {
                        arr[pos] = m_data[pos];
                        pos++; 
                    } 
                }
            } else {
                int [] idx0 = m_indexOffset[0]; 
                int [] idx1 = m_indexOffset[1];
                for (int c = 0; c < m_dimensions[1]; c++) {
                    pos += c;
                    for (int r = c; r < n; r++,pos++) {
                        arr[pos] = m_data[idx0[r]+ idx1[c]];
                        pos++; 
                    } 
                }
            }
            return new ILArray<BaseT> (arr,n,n);
        }

        #endregion
    }
}
