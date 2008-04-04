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
        inCls1
    </source>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>fcomplex</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>float</destination>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static /*!HC:outCls1*/ ILArray<double> real (/*!HC:inCls1*/ ILArray<complex> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            /*!HC:outArr1*/ double [] retArr = new /*!HC:outArr1*/ double [nrX]; 
            /*!HC:outCls1*/ ILArray<double> ret = new /*!HC:outCls1*/ ILArray<double> (retArr,X.m_dimensions); 
            ILIterator</*!HC:inArr1*/ complex > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = it.Increment().real; 
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// real part of complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        public static  ILArray<float> real ( ILArray<fcomplex> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            float [] retArr = new  float [nrX]; 
            ILArray<float> ret = new  ILArray<float> (retArr,X.m_dimensions); 
            ILIterator< fcomplex > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = it.Increment().real; 
            }
            return ret; 
        }

#endregion HYCALPER AUTO GENERATED CODE
    }

}
