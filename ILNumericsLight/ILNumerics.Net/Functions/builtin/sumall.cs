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
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source>
        outCls1
    </source>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source>
        inArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        outArr1
    </source>
    <destination>complex</destination>
    <destination>byte</destination>
</type>
<type>
    <source>
        HCzero
    </source>
    <destination>new complex(0.0,0.0)</destination>
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

            unsafe {
                fixed (/*!HC:inArr1*/ double * inArrStart = A.m_data) {
                    /*!HC:inArr1*/ double * inArrWalk = inArrStart; 
                    /*!HC:inArr1*/ double * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        retArr += *inArrWalk++; 
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
        public static  ILArray<byte> sumall ( ILArray<byte> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<byte> .empty(0,0); 
            } 
            byte retArr =  0 ; 

            unsafe {
                fixed ( byte * inArrStart = A.m_data) {
                    byte * inArrWalk = inArrStart; 
                    byte * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        retArr += *inArrWalk++; 
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
        public static  ILArray<complex> sumall ( ILArray<complex> A) {
            if (object.Equals(A,null))
                throw new ILArgumentException("sumall: argument must not be null!");
            if (A.IsEmpty) {
                return  ILArray<complex> .empty(0,0); 
            } 
            complex retArr =  new complex(0.0,0.0) ; 

            unsafe {
                fixed ( complex * inArrStart = A.m_data) {
                    complex * inArrWalk = inArrStart; 
                    complex * inArrEnd = inArrStart + A.Dimensions.NumberOfElements; 
                    while (inArrWalk < inArrEnd) {
                        retArr += *inArrWalk++; 
                    }
                }
            }
            return new  ILArray<complex> (new  complex [1]{retArr},1,1);
        }

#endregion HYCALPER AUTO GENERATED CODE

    }
}
