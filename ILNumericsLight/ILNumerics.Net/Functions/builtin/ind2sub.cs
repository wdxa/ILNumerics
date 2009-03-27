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
        /// convert sequential index into subscript indices
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="seqindex">sequential index</param>
        /// <returns>subscript indices</returns>
        /// <remarks><para>the length of the value returned will be the number of dimensions of A</para>
        /// <para>if A is null or empty array, the return value will be of length 0</para>
        /// </remarks>
        /// <exception cref="System.IndexOutOfRangeException">if seqindex is &lt; 0 or &gt; numel(A)</exception>
        public static int[] ind2sub(ILArray<double>   A, int seqindex) {  
            if (object.Equals(A,null) || A.IsEmpty)
                return new int[0]; 
            int [] ret = new int[A.Dimensions.NumberOfDimensions]; 
            A.GetValueSeq(seqindex,ref ret); 
            return ret; 
        }
        
        /// <summary>
        /// convert sequential index into subscript indices
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="seqindex">sequential index</param>
        /// <returns>subscript indices</returns>
        /// <remarks><para>the length of the value returned will be the number of dimensions of A</para>
        /// <para>if A is null or empty array, the return value will be of length 0</para>
        /// </remarks>
        /// <exception cref="System.IndexOutOfRangeException">if seqindex is &lt; 0 or &gt; numel(A)</exception>
        public static int[] ind2sub(ILArray<complex>   A, int seqindex) {  
            if (object.Equals(A,null) || A.IsEmpty)
                return new int[0]; 
            int [] ret = new int[A.Dimensions.NumberOfDimensions]; 
            A.GetValueSeq(seqindex,ref ret); 
            return ret; 
        }
        
        /// <summary>
        /// convert sequential index into subscript indices
        /// </summary>
        /// <param name="A">input array</param>
        /// <param name="seqindex">sequential index</param>
        /// <returns>subscript indices</returns>
        /// <remarks><para>the length of the value returned will be the number of dimensions of A</para>
        /// <para>if A is null or empty array, the return value will be of length 0</para>
        /// </remarks>
        /// <exception cref="System.IndexOutOfRangeException">if seqindex is &lt; 0 or &gt; numel(A)</exception>
        public static int[] ind2sub(ILArray<byte>   A, int seqindex) {  
            if (object.Equals(A,null) || A.IsEmpty)
                return new int[0]; 
            int [] ret = new int[A.Dimensions.NumberOfDimensions]; 
            A.GetValueSeq(seqindex,ref ret); 
            return ret; 
        }
    }
}
