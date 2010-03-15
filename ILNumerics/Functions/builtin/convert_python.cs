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

namespace ILNumerics.BuiltInFunctions  {
    
    // IronPython-specific conversions

    public partial class ILMath
    {
        public static ILBaseArray convert(object type, ILArray<Int32> X)
        {
            if (type.GetType() == typeof(IronPython.Runtime.Types.PythonType))
            {
                if (((IronPython.Runtime.Types.PythonType)type).__clrtype__() == typeof(Double))
                {
                    return convert(NumericType.Double, X);
                }
                else return X;
            }
            else return X;
        }

        public static ILBaseArray convert(object type, ILArray<Double> X)
        {
            if (type.GetType() == typeof(IronPython.Runtime.Types.PythonType))
            {
                if (((IronPython.Runtime.Types.PythonType)type).__clrtype__() == typeof(Int32))
                {
                    return convert(NumericType.Int32, X);
                }
                else return X;
            }
            else return X;
        }

        public static ILArray<Int32> toint(ILArray<Double> X)
        {
            return convert(NumericType.Int32, X) as ILArray<Int32>;
        }

        public static ILArray<Double> tofloat(ILArray<Int32> X)
        {
            return convert(NumericType.Double, X) as ILArray<Double>;
        }
    }
}

#endif