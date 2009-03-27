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
using ILNumerics;
using ILNumerics.Exceptions;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// convert subscript indices to sequential index
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="subscripts">subscripts</param>
        /// <returns>sequential index for subscript indices</returns>
        /// <remarks>the function returns the sequential index i into A referencing the same element as would be referenced by the subscript indices. <br />This is an alias for A.getBaseIndex(in[])</remarks>
        public static int sub2ind(ILArray<double>  A, int [] subscripts) {  
            if (object.Equals(A,null) || A.IsEmpty || subscripts == null || subscripts.Length == 0) 
                throw new ILArgumentException("sub2ind: both A and subscripts must be non-empty!");
            return A.getBaseIndex(subscripts);  
        }
        /// <summary>
        /// convert subscript indices to sequential index
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="subscripts"></param>
        /// <returns>sequential index for subscript indices</returns>
        /// <remarks>the function returns the sequential index i into A referencing the same element as would be referenced by the subscript indices. <br />This is an alias for A.getBaseIndex(in[])</remarks>
        public static int sub2ind(ILArray<complex>  A,int [] subscripts) {              
            if (object.Equals(A,null) || A.IsEmpty || subscripts == null || subscripts.Length == 0) 
                throw new ILArgumentException("sub2ind: both A and subscripts must be non-empty!");
            return A.getBaseIndex(subscripts);  
        }
        /// <summary>
        /// convert subscript indices to sequential index
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="subscripts"></param>
        /// <returns>sequential index for subscript indices</returns>
        /// <remarks>the function returns the sequential index i into A referencing the same element as would be referenced by the subscript indices. <br />This is an alias for A.getBaseIndex(in[])</remarks>
        public static int sub2ind(ILArray<byte>     A,int [] subscripts) {              
            if (object.Equals(A,null) || A.IsEmpty || subscripts == null || subscripts.Length == 0) 
                throw new ILArgumentException("sub2ind: both A and subscripts must be non-empty!");
            return A.getBaseIndex(subscripts);  
        }
    }
}
