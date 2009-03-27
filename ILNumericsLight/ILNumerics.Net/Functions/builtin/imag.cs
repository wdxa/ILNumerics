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
</type>
<type>
    <source locate="after">
        outCls1
    </source>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
</type>
</hycalper>
 */

namespace ILNumerics.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// imaginary part of complex array elements
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>imaginary part of complex array</returns>
        public static /*!HC:outCls1*/ ILArray<double> imag (/*!HC:inCls1*/ ILArray<complex> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            /*!HC:outArr1*/ double [] retArr = new /*!HC:outArr1*/ double [nrX]; 
            /*!HC:outCls1*/ ILArray<double> ret = new /*!HC:outCls1*/ ILArray<double> (retArr,X.m_dimensions); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = X.GetValue(i).imag; 
            }
            return ret; 
        }
        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

#endregion HYCALPER AUTO GENERATED CODE
    }

}
