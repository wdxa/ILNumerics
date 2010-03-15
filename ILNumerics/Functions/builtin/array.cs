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

#if IRONPYTHON

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics;
using ILNumerics.Exceptions;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
    
    public partial class ILMath
    {
        /// <summary>
        /// Convert IronPython List into ILBaseArray
        /// </summary>
        /// <param name="list">IronPython List (must be filled with Python ints or floats)</param>
        /// <returns>ILBaseArray</returns>
        public static ILBaseArray array(IronPython.Runtime.List list)
        {
            List<int> size = new List<int>();
            Type type = typeof(double);
            PythonListHelper.GetListDimensionsAndType(ref size, list, ref type);
            if (!PythonListHelper.CheckList(ref size, list, 0, ref type))
            {
                throw new ArgumentException("List is not rectangular or not of constant type!");
            }
            if (type == typeof(Double))
            {
                return new ILArray<Double>(list);
            }
            else if (type == typeof(Int32))
            {
                return new ILArray<Int32>(list);
            }
            else throw new ArgumentException("List type is not int or float");
        }
    }
}

#endif