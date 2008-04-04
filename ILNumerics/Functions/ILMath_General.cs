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
using System.Runtime.InteropServices;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Native;
using ILNumerics.Exceptions;
using System.IO; 

namespace ILNumerics.BuiltInFunctions {

    /// <summary>
    /// Main math class. provides all explicit static math functions 
    /// </summary>
    public partial class ILMath {
		/// <summary>
		/// concrete interface wrapper class providing the native LAPACK functions
		/// </summary>
		/// <remarks>The LAPACK wrapper will be initialized the first time, 
		/// a call to any static method of ILMath is made. The decision, which 
		/// native module to load is done by use of native CPUID assembly statements.
		/// If the current processor does not support those calls or is not recognizable
		/// by ILNumerics.Net, a generic - not optimized - version of native LAPACK code will
		/// be used.</remarks>
        public static IILLapack Lapack;
        static ILMath() {
            #region initialize LAPACK
            ILCPUID cpuid; 
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Unix:
                    Lapack = new ILLapackGenLinux(); 
                    break; 
                default: 
                    if (Lapack == null) {
                        cpuid = new ILCPUID(); 
                        switch (cpuid.vendor) {
                            case "AuthenticAMD":
                                //Lapack = new ILACMLWrapper();
                                Lapack = new ILACML3_6(); 
                                break; 
                            case "GenuineIntel":
                                Lapack = new ILLapackMKL10_0();    // ILLapackMKL() <-> ILLapackGeneric()
                                break; 
                            default:
                                Lapack = new ILLapackGeneric(); 
                                break;
                        }
                    }
                    break; 
            }
            #endregion 
            #region initialize machine parameter infos 
            macharD(ref m_machparDouble.ibeta, ref m_machparDouble.it,ref m_machparDouble.irnd,ref m_machparDouble.ngrd,ref m_machparDouble.machep,ref m_machparDouble.negep,ref m_machparDouble.iexp,ref m_machparDouble.minexp,ref m_machparDouble.maxexp,ref m_machparDouble.eps,ref m_machparDouble.epsneg,ref m_machparDouble.xmin,ref m_machparDouble.xmax); 
            macharF(ref m_machparFloat.ibeta, ref m_machparFloat.it,ref m_machparFloat.irnd,ref m_machparFloat.ngrd,ref m_machparFloat.machep,ref m_machparFloat.negep,ref m_machparFloat.iexp,ref m_machparFloat.minexp,ref m_machparFloat.maxexp,ref m_machparFloat.eps,ref m_machparFloat.epsneg,ref m_machparFloat.xmin,ref m_machparFloat.xmax); 
            #endregion

        }
		/// <summary>
		/// Minimal size of dimensions, expensive operations will be carried out dur native LAPACK libs. 
		/// </summary>
		/// <remarks>This property is not implemented yet. All arrays will be using LAPACK.
		/// </remarks>
        internal static readonly int ILAtlasMinimumElementSize = 1;
    }
}
