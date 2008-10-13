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
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
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
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
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
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
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
    <source>
        outArr1
    </source>
    <destination>complex</destination>
    <destination>float</destination>
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
    <source>
        HCzero
    </source>
    <destination>new complex(0.0,0.0)</destination>
    <destination>0.0f</destination>
    <destination>new fcomplex(0.0f,0.0f)</destination>
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
        #region HYCALPER LOOPSTART sumall
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static /*!HC:outCls1*/ ILArray<double> sumall (/*!HC:inCls1*/ ILArray<double> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return /*!HC:inCls1*/ ILArray<double> .empty(0,0); 
            } 
            /*!HC:outArr1*/ double retArr = /*!HC:HCzero*/ 0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data) {
                        /*!HC:inArr1*/ double * inArrWalk = inArrStart; 
                        /*!HC:inArr1*/ double * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new /*!HC:outCls1*/ ILArray<double> (new /*!HC:outArr1*/ double [1]{retArr},1,1);
        }
        #endregion HYCALPER LOOPEND sumall
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt64> sumall ( ILArray<UInt64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt64> .empty(0,0); 
            } 
            UInt64 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt64 * inArrStart = A.m_data) {
                        UInt64 * inArrWalk = inArrStart; 
                        UInt64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( UInt64 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<UInt64> (new  UInt64 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt32> sumall ( ILArray<UInt32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt32> .empty(0,0); 
            } 
            UInt32 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt32 * inArrStart = A.m_data) {
                        UInt32 * inArrWalk = inArrStart; 
                        UInt32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( UInt32 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<UInt32> (new  UInt32 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<UInt16> sumall ( ILArray<UInt16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<UInt16> .empty(0,0); 
            } 
            UInt16 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( UInt16 * inArrStart = A.m_data) {
                        UInt16 * inArrWalk = inArrStart; 
                        UInt16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( UInt16 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<UInt16> (new  UInt16 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int64> sumall ( ILArray<Int64> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int64> .empty(0,0); 
            } 
            Int64 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int64 * inArrStart = A.m_data) {
                        Int64 * inArrWalk = inArrStart; 
                        Int64 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( Int64 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<Int64> (new  Int64 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int32> sumall ( ILArray<Int32> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int32> .empty(0,0); 
            } 
            Int32 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int32 * inArrStart = A.m_data) {
                        Int32 * inArrWalk = inArrStart; 
                        Int32 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( Int32 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<Int32> (new  Int32 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<Int16> sumall ( ILArray<Int16> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<Int16> .empty(0,0); 
            } 
            Int16 retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( Int16 * inArrStart = A.m_data) {
                        Int16 * inArrWalk = inArrStart; 
                        Int16 * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( Int16 * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<Int16> (new  Int16 [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<char> sumall ( ILArray<char> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<char> .empty(0,0); 
            } 
            char retArr =  (char)0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( char * inArrStart = A.m_data) {
                        char * inArrWalk = inArrStart; 
                        char * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( char * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<char> (new  char [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<byte> sumall ( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(0,0); 
            } 
            byte retArr =  0 ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( byte * inArrStart = A.m_data) {
                        byte * inArrWalk = inArrStart; 
                        byte * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( byte * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<byte> (new  byte [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<fcomplex> sumall ( ILArray<fcomplex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<fcomplex> .empty(0,0); 
            } 
            fcomplex retArr =  new fcomplex(0.0f,0.0f) ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( fcomplex * inArrStart = A.m_data) {
                        fcomplex * inArrWalk = inArrStart; 
                        fcomplex * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( fcomplex * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<fcomplex> (new  fcomplex [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<float> sumall ( ILArray<float> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<float> .empty(0,0); 
            } 
            float retArr =  0.0f ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( float * inArrStart = A.m_data) {
                        float * inArrWalk = inArrStart; 
                        float * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( float * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<float> (new  float [1]{retArr},1,1);
        }
        /// <summary>
        /// sum all elements of array A
        /// </summary>
        /// <param name="A">n-dim array</param>
        /// <returns><para>scalar sum of all elements of A.</para>
        /// <para>If A is empty, an empty array will be returned.</para></returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if A was null.</exception>
        /// <seealso cref="ILNumerics.BuiltInFunctions.ILMath.sum(ILArray&lt;double&gt;)"/>
        public static  ILArray<complex> sumall ( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(0,0); 
            } 
            complex retArr =  new complex(0.0,0.0) ; 
            if (A.m_indexOffset == null) {
                unsafe {
                    fixed ( complex * inArrStart = A.m_data) {
                        complex * inArrWalk = inArrStart; 
                        complex * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                        while (inArrWalk < inArrEnd) {
                            retArr += *inArrWalk++; 
                        }
                    }
                }
            } else {
                unsafe {
                    fixed ( complex * inArrStart = A.m_data)  {
                        for (int i = A.Dimensions.NumberOfElements; i -->0;) {
                            retArr += *(inArrStart + A.getBaseIndex(i)); 
                        }
                    }
                }
            }
            return new  ILArray<complex> (new  complex [1]{retArr},1,1);
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
