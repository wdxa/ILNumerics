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
using ILNumerics.Misc; 
using System.Diagnostics; 

namespace ILNumerics {
    public partial class ILArray<BaseT> {

        public class ILFormatter<T> {                
            
            ILArray<T> m_array; 
            public ILFormatter (ILArray<T> array) {
                m_array = array; 
                //GetClientSize(); 
            }

            public string ToString(string s, int maxLength) {
                StringBuilder sb = new StringBuilder(s);
                sb.Append(m_array.debuggerHeadLineDisplay()); 
                sb.Append(Environment.NewLine);
                if (m_array.Dimensions.NumberOfElements > 1)
                    sb.Append(m_array.ValuesToString(maxLength));
                return sb.ToString();
            }

        }
    }
    /// <summary>
    /// This class is for internal use only. Do not instantiate from this class!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ILArrayDebuggerProxy<T>  {
        private ILArray<T> m_array; 
        public bool IsReference {
            get {
                return m_array.m_indexOffset != null;
            }
        }
        private ILDimension Dimensions {
            get {
                return m_array.Dimensions;
            }
        }
        [System.Diagnostics.DebuggerDisplay("{valuesToString,nq}")]
        public string Values {
            get {
                return m_array.ValuesToString(-1).ToString();
            }
        }
        private string valuesToString {
            get {
                return m_array.ValuesToString(-1).ToString(); 
            }
        }
        public string[] Rows {
            get {
                return m_array.ValuesToString(-1).ToString().Split(new string[1]{Environment.NewLine},StringSplitOptions.None ); 
            }
        }

        private void GetContext() {
            Console.Out.WriteLine("In GetContext().."); 
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(1);
            if (sf != null) 
                Console.Out.WriteLine("Debug proxy called from:" + sf.GetMethod()); 
        }
        public ILArrayDebuggerProxy (ILArray<T> array) {
            m_array = array; 
        }
    }

}
