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
    <source>
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
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
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
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
    <source>
        inArr1
    </source>
    <destination>float</destination>
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
    <source>
        outArr1
    </source>
    <destination>float</destination>
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
    <source>
        HCzero
    </source>
    <destination>0.0f</destination>
    <destination>0</destination>
    <destination>(char)0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
    <destination>0</destination>
</type>
</hycalper>
*/
namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART minall
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static /*!HC:outCls1*/ ILArray<double> minall (/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return /*!HC:inCls1*/ ILArray<double> .empty(A.Dimensions); 
            } 
            /*!HC:outArr1*/ double retArr = /*!HC:outArr1*/ double .MaxValue;  
            unsafe {
                fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data) {
                    /*!HC:inArr1*/ double * inArrWalk = inArrStart; 
                    /*!HC:inArr1*/ double * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:outArr1*/ double [1]{retArr},1,1);
        }
        #endregion HYCALPER LOOPEND minall
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt64> minall ( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt64> .empty(A.Dimensions); 
            } 
            UInt64 retArr =  UInt64 .MaxValue;  
            unsafe {
                fixed ( UInt64 * inArrStart = A.m_data) {
                    UInt64 * inArrWalk = inArrStart; 
                    UInt64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<UInt64> (new  UInt64 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt32> minall ( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt32> .empty(A.Dimensions); 
            } 
            UInt32 retArr =  UInt32 .MaxValue;  
            unsafe {
                fixed ( UInt32 * inArrStart = A.m_data) {
                    UInt32 * inArrWalk = inArrStart; 
                    UInt32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<UInt32> (new  UInt32 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt16> minall ( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt16> .empty(A.Dimensions); 
            } 
            UInt16 retArr =  UInt16 .MaxValue;  
            unsafe {
                fixed ( UInt16 * inArrStart = A.m_data) {
                    UInt16 * inArrWalk = inArrStart; 
                    UInt16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<UInt16> (new  UInt16 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int64> minall ( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int64> .empty(A.Dimensions); 
            } 
            Int64 retArr =  Int64 .MaxValue;  
            unsafe {
                fixed ( Int64 * inArrStart = A.m_data) {
                    Int64 * inArrWalk = inArrStart; 
                    Int64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<Int64> (new  Int64 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int32> minall ( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int32> .empty(A.Dimensions); 
            } 
            Int32 retArr =  Int32 .MaxValue;  
            unsafe {
                fixed ( Int32 * inArrStart = A.m_data) {
                    Int32 * inArrWalk = inArrStart; 
                    Int32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<Int32> (new  Int32 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int16> minall ( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int16> .empty(A.Dimensions); 
            } 
            Int16 retArr =  Int16 .MaxValue;  
            unsafe {
                fixed ( Int16 * inArrStart = A.m_data) {
                    Int16 * inArrWalk = inArrStart; 
                    Int16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<Int16> (new  Int16 [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<char> minall ( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<char> .empty(A.Dimensions); 
            } 
            char retArr =  char .MaxValue;  
            unsafe {
                fixed ( char * inArrStart = A.m_data) {
                    char * inArrWalk = inArrStart; 
                    char * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<char> (new  char [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<byte> minall ( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(A.Dimensions); 
            } 
            byte retArr =  byte .MaxValue;  
            unsafe {
                fixed ( byte * inArrStart = A.m_data) {
                    byte * inArrWalk = inArrStart; 
                    byte * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<byte> (new  byte [1]{retArr},1,1);
        }
        /// <summary>
        /// minimum of all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar minimum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.min(ILArray&lt;double&gt;)"/>
        public static  ILArray<float> minall ( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("minall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<float> .empty(A.Dimensions); 
            } 
            float retArr =  float .MaxValue;  
            unsafe {
                fixed ( float * inArrStart = A.m_data) {
                    float * inArrWalk = inArrStart; 
                    float * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        if (retArr > *inArrWalk)
                            retArr = *inArrWalk;
                        inArrWalk++;
                    }
                }
            }
            return new  ILArray<float> (new  float [1]{retArr},1,1);
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
