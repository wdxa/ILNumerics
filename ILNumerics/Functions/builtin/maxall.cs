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
        #region HYCALPER LOOPSTART maxall
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static /*!HC:outCls1*/ ILArray<double> maxall (/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return /*!HC:inCls1*/ ILArray<double> .empty(); 
            } 
            /*!HC:outArr1*/ double retArr = /*!HC:outArr1*/ double .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data) {
                        /*!HC:inArr1*/ double * inArrWalk = inArrStart; 
                        /*!HC:inArr1*/ double * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                /*!HC:outArr1*/ double tmp; 
                unsafe {
                    fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:outArr1*/ double [1]{retArr},1,1);
        }
        #endregion HYCALPER LOOPEND maxall
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt64> maxall ( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt64> .empty(); 
            } 
            UInt64 retArr =  UInt64 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt64 * inArrStart = A.m_data) {
                        UInt64 * inArrWalk = inArrStart; 
                        UInt64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                UInt64 tmp; 
                unsafe {
                    fixed ( UInt64 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<UInt64> (new  UInt64 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt32> maxall ( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt32> .empty(); 
            } 
            UInt32 retArr =  UInt32 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt32 * inArrStart = A.m_data) {
                        UInt32 * inArrWalk = inArrStart; 
                        UInt32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                UInt32 tmp; 
                unsafe {
                    fixed ( UInt32 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<UInt32> (new  UInt32 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt16> maxall ( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt16> .empty(); 
            } 
            UInt16 retArr =  UInt16 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt16 * inArrStart = A.m_data) {
                        UInt16 * inArrWalk = inArrStart; 
                        UInt16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                UInt16 tmp; 
                unsafe {
                    fixed ( UInt16 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<UInt16> (new  UInt16 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int64> maxall ( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int64> .empty(); 
            } 
            Int64 retArr =  Int64 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int64 * inArrStart = A.m_data) {
                        Int64 * inArrWalk = inArrStart; 
                        Int64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                Int64 tmp; 
                unsafe {
                    fixed ( Int64 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<Int64> (new  Int64 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int32> maxall ( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int32> .empty(); 
            } 
            Int32 retArr =  Int32 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int32 * inArrStart = A.m_data) {
                        Int32 * inArrWalk = inArrStart; 
                        Int32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                Int32 tmp; 
                unsafe {
                    fixed ( Int32 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<Int32> (new  Int32 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int16> maxall ( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int16> .empty(); 
            } 
            Int16 retArr =  Int16 .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int16 * inArrStart = A.m_data) {
                        Int16 * inArrWalk = inArrStart; 
                        Int16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                Int16 tmp; 
                unsafe {
                    fixed ( Int16 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<Int16> (new  Int16 [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<char> maxall ( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<char> .empty(); 
            } 
            char retArr =  char .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( char * inArrStart = A.m_data) {
                        char * inArrWalk = inArrStart; 
                        char * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                char tmp; 
                unsafe {
                    fixed ( char * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<char> (new  char [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<byte> maxall ( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(); 
            } 
            byte retArr =  byte .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( byte * inArrStart = A.m_data) {
                        byte * inArrWalk = inArrStart; 
                        byte * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                byte tmp; 
                unsafe {
                    fixed ( byte * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<byte> (new  byte [1]{retArr},1,1);
        }
        /// <summary>
        /// maximum of all elements for array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar maximum of all elements for A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.max(ILArray&lt;double&gt;)"/>
        public static  ILArray<float> maxall ( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("maxall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<float> .empty(); 
            } 
            float retArr =  float .MinValue;  
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( float * inArrStart = A.m_data) {
                        float * inArrWalk = inArrStart; 
                        float * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            if (retArr < *inArrWalk)
                                retArr = *inArrWalk;
                            inArrWalk++;
                        }
                    }
                }
            } else {
                float tmp; 
                unsafe {
                    fixed ( float * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            tmp = *(inArrStart + A.getBaseIndex(i));
                            if (retArr < tmp)
                                retArr = tmp; 
                        }
                    }
                }
            }
            return new  ILArray<float> (new  float [1]{retArr},1,1);
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
