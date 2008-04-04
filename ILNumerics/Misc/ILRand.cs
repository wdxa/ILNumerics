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
using System.IO; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Misc {
    internal class ILRand {

        private bool m_istrial = false;

        public bool Istrial {
            get { return m_istrial; }
            set { m_istrial = value; }
        }
        private bool m_ispaid = false;

        public bool Ispaid {
            get { return m_ispaid; }
            set { m_ispaid = value; }
        }
        private DateTime m_expires = DateTime.Now;

        public DateTime Expires {
            get { return m_expires; }
            set { m_expires = value; }
        } 

        internal ILRand (string s) {
            evaluate(s.ToCharArray()); 
        }

        private void evaluate(char[] chars) {
            if (chars.Length < 10) 
                throw new ILInvalidOperationException("unable to read licensing information!");
            // algo to decompile information
            m_ispaid = true; 
            m_expires = DateTime.MaxValue; 
        }

    }
}
