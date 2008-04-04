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
using ILNumerics.Native;
using System.Runtime.InteropServices;

namespace ILNumerics.Native {
    /// <summary>
    /// CPUID class - determine machine properties, wraps ILCPUID binary with C/assembler helper
    /// </summary>
    /// <remarks>This class will determine extended processor properties once classes of 
    /// ILNumerics.Net are first time used. It helps choosing the right processor 
    /// specific binaries for LAPACK and BLAS. 
    /// </remarks>
    public class ILCPUID {
        /// <summary>
        /// interop call to ILCPUID binary, get machine properties
        /// </summary>
        /// <param name="vendorString">[output] vendor string</param>
        /// <param name="eax">[output] register a</param>
        /// <param name="ebx">[output] register b</param>
        /// <param name="ecx">[output] register c</param>
        /// <param name="edx">[output] register d</param>
        [DllImport("ILCPUID", EntryPoint = "check_IDProc")]
        private static extern void check_IDProc(
            ref string vendorString, ref UInt32 eax, ref UInt32 ebx, ref UInt32 ecx, ref UInt32 edx);

        /// <summary>
        /// internal field, caches vendor string
        /// </summary>
        private string m_vendor = "(unknown)";
        /// <summary>
        /// Vendor string
        /// </summary>
        public string vendor {
            get {
                return m_vendor;
            }
        }
        /// <summary>
        /// internal field, caches processor familiy name
        /// </summary>
        private string m_family = "(unknown)";
        /// <summary>
        /// Processor family name
        /// </summary>
        public string family {
            get {
                return m_family;
            }
        }
        /// <summary>
        /// internal field, caches extended processor familiy name
        /// </summary>
        private string m_extFamily = "(unknown)";
        /// <summary>
        /// extended processor familiy description
        /// </summary>
        public string ExtFamily {
            get {
                return m_extFamily;
            }
        }
        /// <summary>
        /// internal field, caches model
        /// </summary>
        private string m_model = "(unknown)";
        /// <summary>
        /// Processor model
        /// </summary>
        public string Model {
            get {
                return m_model;
            }
        }
        /// <summary>
        /// internal field, caches brand
        /// </summary>
        private int m_brand = -1;
        /// <summary>
        /// Processor brand
        /// </summary>
        public int Brand {
            get {
                return m_brand;
            }
        }
        /// <summary>
        /// internal field, caches number of processors
        /// </summary>
        private int m_cpuCount = -1;
        /// <summary>
        /// Number of processors
        /// </summary>
        public int CPUCount {
            get {
                return m_cpuCount;
            }
        }
        /// <summary>
        /// internal field, caches if MMX extension is available
        /// </summary>
        private bool m_MMX = false;
        /// <summary>
        /// Get, if MMX extensions are available
        /// </summary>
        public bool MMX {
            get {
                return m_MMX;
            }
        }
        /// <summary>
        /// internal field, caches if SSE extension is available
        /// </summary>
        private bool m_SSE = false;
        /// <summary>
        /// Get, if SSE extensions are available
        /// </summary>
        public bool SSE {
            get {
                return m_SSE;
            }
        }
        /// <summary>
        /// internal field, caches if SSE2 extensions are available
        /// </summary>
        private bool m_SSE2 = false;
        /// <summary>
        /// Get, if SSE2 extensions are available
        /// </summary>
        public bool SSE2 {
            get {
                return m_SSE2;
            }
        }
        /// <summary>
        /// Get, if SSE3 extensions are available
        /// </summary>
        private bool m_SSE3 = false;
        /// <summary>
        /// internal field, caches if SSE3 extensions are available
        /// </summary>
        public bool SSE3 {
            get {
                return m_SSE3;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ILCPUID() {
            try {
                string vendor = "------------";
                UInt32 cpuEAX = 0;
                UInt32 cpuEBX = 0;
                UInt32 cpuECX = 0;
                UInt32 cpuEDX = 0;
                check_IDProc(ref vendor, ref cpuEAX, ref cpuEBX, ref cpuECX, ref cpuEDX);
                m_vendor = vendor;
                UInt32 family = (cpuEAX & 3840) / 256;
                UInt32 model = (cpuEAX & 240) / 16;
                UInt32 extfamily = (cpuEAX & 267386880) / (2 ^ 28);
                switch (m_vendor) {
                    case "AuthenticAMD":
                        switch (family) {
                            case 4:
                                m_family = "AMD 5x86";
                                break;
                            case 5:
                                m_family = "AMD K5,K6";
                                break;
                            case 6:
                                m_family = "AMD K7";
                                break;
                            default:
                                if (extfamily == 0)
                                    m_family = "AMD K8";
                                else
                                    m_family = "(unknown)";
                                break;
                        }
                        break;
                    case "GenuineIntel":
                        switch (family) {
                            case 4:
                                m_family = "486";
                                break;
                            case 5:
                                m_family = "Intel P5, P54C, P55C, P24T";
                                break;
                            case 6:
                                m_family = "Intel P6, P2, P3, PM";
                                break;
                            case 7:
                                m_family = "Intel Itanium (IA-64)";
                                break; 
                            default:
                                switch (extfamily) {
                                    case 0:
                                        m_family = "Intel P4";
                                        break; 
                                    case 1:
                                        m_family = "Intel Itanium 2 (IA-64)";
                                        break; 
                                    case 2:
                                        m_family = "Intel Itanium 2 DC (IA-64)";                                            
                                        break; 
                                }
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception) {
                // no error handling -> properties will stay on "(unkonwn)" ... 
            }
        }
    }
}
