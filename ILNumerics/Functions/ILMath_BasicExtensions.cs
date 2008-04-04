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

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {
        internal class BasicTypeExtensions {
            internal static float  Abs(float in1) { return (float)Math.Abs(in1); }
            internal static UInt64 Abs(UInt64 in1) { return in1; }
            internal static UInt32 Abs(UInt32 in1) { return in1; }
            internal static UInt16 Abs(UInt16 in1) { return in1; }
            internal static Int64  Abs(Int64 in1) { if (in1 < 0) return -in1; else return in1;  }
            internal static Int32  Abs(Int32 in1) { if (in1 < 0) return -in1; else return in1; }
            internal static Int16  Abs(Int16 in1) { if (in1 < 0) return (Int16)(-1 * in1); else return in1; }
            internal static byte   Abs(byte in1) { if (in1 < 0) return (byte)-in1; else return in1; }
            internal static char   Abs(char in1) { if (in1 < 0) return (char)-in1; else return in1; }

            internal static float  Ceiling(float in1) { return (float)Math.Ceiling(in1); }
            internal static UInt64 Ceiling(UInt64 in1) { return in1; }
            internal static UInt32 Ceiling(UInt32 in1) { return in1; }
            internal static UInt16 Ceiling(UInt16 in1) { return in1; }
            internal static Int64  Ceiling(Int64 in1) { return in1; }
            internal static Int32  Ceiling(Int32 in1) { return in1; }
            internal static Int16  Ceiling(Int16 in1) { return in1; }
            internal static byte   Ceiling(byte in1) { return in1; }
            internal static char   Ceiling(char in1) { return in1; }

            internal static float  Floor(float in1) { return (float)Math.Floor(in1); }
            internal static UInt64 Floor(UInt64 in1) { return in1; }
            internal static UInt32 Floor(UInt32 in1) { return in1; }
            internal static UInt16 Floor(UInt16 in1) { return in1; }
            internal static Int64  Floor(Int64 in1) { return in1; }
            internal static Int32  Floor(Int32 in1) { return in1; }
            internal static Int16  Floor(Int16 in1) { return in1; }
            internal static byte   Floor(byte in1) { return in1; }
            internal static char   Floor(char in1) { return in1; }

            internal static float  Round(float in1) { return (float)Math.Round(in1); }
            internal static UInt64 Round(UInt64 in1) { return in1; }
            internal static UInt32 Round(UInt32 in1) { return in1; }
            internal static UInt16 Round(UInt16 in1) { return in1; }
            internal static Int64  Round(Int64 in1) { return in1; }
            internal static Int32  Round(Int32 in1) { return in1; }
            internal static Int16  Round(Int16 in1) { return in1; }
            internal static byte   Round(byte in1) { return in1; }
            internal static char   Round(char in1) { return in1; }

            internal static double Sign(double in1) { return (double)Math.Sign(in1); }
            internal static float Sign(float in1) { return (float)Math.Sign(in1); }
            internal static UInt64 Sign(UInt64 in1) { return (UInt64)Math.Sign((float)in1); }
            internal static UInt32 Sign(UInt32 in1) { return (UInt32)Math.Sign(in1); }
            internal static UInt16 Sign(UInt16 in1) { return (UInt16)Math.Sign(in1); }
            internal static Int64  Sign(Int64 in1) { return (Int64)Math.Sign(in1); }
            internal static Int32  Sign(Int32 in1) { return (Int32)Math.Sign(in1); }
            internal static Int16  Sign(Int16 in1) { return (Int16)Math.Sign(in1); }
            internal static byte   Sign(byte in1) { return (byte)Math.Sign(in1); }
            internal static char   Sign(char in1) { return (char)Math.Sign(in1); }

            internal static float  Truncate(float in1) { return (float)Math.Truncate(in1); }
            internal static UInt64 Truncate(UInt64 in1) { return (UInt64)Math.Truncate((double)in1); }
            internal static UInt32 Truncate(UInt32 in1) { return (UInt32)Math.Truncate((double)in1); }
            internal static UInt16 Truncate(UInt16 in1) { return (UInt16)Math.Truncate((double)in1); }
            internal static Int64 Truncate(Int64 in1) { return (Int64)Math.Truncate((double)in1); }
            internal static Int32 Truncate(Int32 in1) { return (Int32)Math.Truncate((double)in1); }
            internal static Int16 Truncate(Int16 in1) { return (Int16)Math.Truncate((double)in1); }
            internal static byte Truncate(byte in1) { return (byte)Math.Truncate((double)in1); }
            internal static char Truncate(char in1) { return (char)Math.Truncate((double)in1); }

            // trigonometric float
            internal static float Acos(float inp) { return (float)Math.Acos(inp); }
            internal static float Asin(float inp) { return (float)Math.Asin(inp); }
            internal static float Atan(float inp) { return (float)Math.Atan(inp); }
            internal static float Cos(float inp) { return (float)Math.Cos(inp); }
            internal static float Cosh(float inp) { return (float)Math.Cosh(inp); }
            internal static float Exp(float inp) { return (float)Math.Exp(inp); }
            internal static float Log(float inp) { return (float)Math.Log(inp); }
            internal static float Log10(float inp) { return (float)Math.Log10(inp); }
            internal static float Sin(float inp) { return (float)Math.Sin(inp); }
            internal static float Sinh(float inp) { return (float)Math.Sinh(inp); }
            internal static float Sqrt(float inp) { return (float)Math.Sqrt(inp); }
            internal static float Tan(float inp) { return (float)Math.Tan(inp); }
            internal static float Tanh(float inp) { return (float)Math.Tanh(inp); }
            internal static float Pow(float inp, float parameter) { return (float)Math.Pow(inp, parameter); }
        }
    }
}
