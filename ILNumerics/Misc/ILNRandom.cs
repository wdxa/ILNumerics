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

namespace ILNumerics.Misc {
    internal class ILNRandom {
        private double m_spareRand = 0; 
        private bool m_hasSpareRand = false; 
        private Random m_rand; 

        public ILNRandom (int seed) {
            m_rand = new Random(seed); 
        }
        public ILNRandom() {
            m_rand = new Random(Environment.TickCount); 
        }

        public double NextDouble() {
            if (m_hasSpareRand) {
                m_hasSpareRand = false; 
                return m_spareRand; 
            } else {
                double v1 = 0.0, v2, rsq = 0.0, fac = 0.0;  
                do {
                    v1 = 2.0 * m_rand.NextDouble() -1.0; 
                    v2 = 2.0 * m_rand.NextDouble() -1.0; 
                    rsq = v1 * v1 + v2 * v2; 
                } while (rsq >= 1.0 || rsq == 0.0); 
                fac = Math.Sqrt(-2.0 * Math.Log(rsq) / rsq); 
                m_spareRand = v1 * fac; 
                m_hasSpareRand = true; 
                return v2 * fac; 
            }
        }
        
    }
}