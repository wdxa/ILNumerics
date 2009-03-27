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
using System.Text;

namespace ILNumerics.Misc
{
	/// <summary>
	/// Measures time spans.
	/// </summary>
	public class ILPerformer
	{
		private long m_start; 
		private long m_lastDuration; 
		public ILPerformer() {
			Tic();
		}
		public void Tic() {
			m_start = Environment.TickCount;
		}
		public String Toc() {
			long msec = Environment.TickCount;
			if (msec < m_start) 
				msec += Int32.MaxValue;  // recover overflow
			m_lastDuration = (msec - m_start); 
			return ToString();
		}
		public long Duration {
			get {
				return m_lastDuration;
			}
		}
		public override string ToString() {
			return m_lastDuration.ToString();
		}
	}
}
