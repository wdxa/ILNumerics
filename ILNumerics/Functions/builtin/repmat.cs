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

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        /// <summary>
        /// array replication
        /// </summary>
        /// <param name="X">input array to be replicated</param>
        /// <param name="rows">number of rows</param>
        /// <param name="sizeEx">number of columns and higher dimensions</param>
        /// <returns>reference ILArray as replication of X</returns>
        public static ILArray<T> repmat<T>(ILArray<T> X, int rows, params int[] sizeEx) {
            int [] size = new int[1+sizeEx.Length]; 
            size[0] = rows; 
            for (int i = 0; i < sizeEx.Length; i++)
                size[i+1] = sizeEx[i]; 
            return X.Repmat(size); 
        }
    }
}
namespace ILNumerics.Untyped {
    public partial class ILUntype {
        /// <summary>
        /// array replication _ : TODO : implement correctly! 
        /// </summary>
        /// <param name="X">input array to be replicated</param>
        /// <param name="rows">number of rows</param>
        /// <param name="sizeEx">number of columns and higher dimensions</param>
        /// <returns>reference ILArray as replication of X</returns>
        public static ILArray<T> repmat<T>(ILArray<T> X, object rows, params object[] sizeEx) {
            int [] size = new int[1+sizeEx.Length]; 
            if (rows is ILArray<double>) {
                size[0] = (int)((ILArray<double>)rows).GetValue(0); 
            } else if(rows is ILArray<float>) {
                size[0] = (int)((ILArray<float>)rows).GetValue(0); 
            } else if(rows is ILArray<complex>) {
                size[0] = (int)((ILArray<complex>)rows).GetValue(0); 
            } else if(rows is ILArray<fcomplex>) {
                size[0] = (int)((ILArray<fcomplex>)rows).GetValue(0); 
            } else if(rows is ILArray<Int16>) {
                size[0] = (int)((ILArray<Int16>)rows).GetValue(0); 
            } else if(rows is ILArray<Int32>) {
                size[0] = (int)((ILArray<Int32>)rows).GetValue(0); 
            } else if(rows is ILArray<Int64>) {
                size[0] = (int)((ILArray<Int64>)rows).GetValue(0); 
            } else if(rows is ILArray<UInt16>) {
                size[0] = (int)((ILArray<UInt16>)rows).GetValue(0); 
            } else if(rows is ILArray<UInt32>) {
                size[0] = (int)((ILArray<UInt32>)rows).GetValue(0); 
            } else if(rows is ILArray<UInt64>) {
                size[0] = (int)((ILArray<UInt64>)rows).GetValue(0); 
            } else if(rows is ILArray<char>) {
                size[0] = (int)((ILArray<char>)rows).GetValue(0); 
            } else if(rows is ILArray<byte>) {
                size[0] = (int)((ILArray<byte>)rows).GetValue(0); 
            }
            for (int i = 0; i < sizeEx.Length; i++)
                size[i+1] = 0; // TODO: implement general parameter conversion routine! sizeEx[i]; 
            return X.Repmat(size); 
        }
    }
}
