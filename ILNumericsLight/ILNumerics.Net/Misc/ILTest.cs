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
using System.Diagnostics; 
using ILNumerics.Misc; 

namespace ILNumerics.Test {
    /// <summary>
    /// Base test case class
    /// </summary>
    /// <remarks>This class serves as base class for all test classes for ILNumerics.Net. It is used as standalone and simple 
    /// test framework in order to make testing easy for non - microsoft systems (mono) also. </remarks>
	public abstract class ILTest {
        /// <summary>
        /// internal counter for failed tests
        /// </summary>
		protected int m_failed = 0;
        /// <summary>
        /// internal counter for succeeded tests
        /// </summary>
		protected int m_success = 0; 

		/// <summary>
		/// Start running the test
		/// </summary>
        public virtual void Run() {
			Console.Out.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Out.Write("Success: " + m_success);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.Write(" - ");
			if (m_failed > 0)
				Console.ForegroundColor = ConsoleColor.Red;
			Console.Out.WriteLine("Failed: " + m_failed);
			Console.ResetColor();
		}
		/// <summary>
		/// Print default header information to console. May be overwritten by derived classes
		/// </summary>
		protected virtual void Header() {
			StringBuilder s = new StringBuilder(); 
			s.Append(	GetType().ToString() ); 
			s.Append(   Environment.NewLine ); 
            int l = s.Length; 
			for (int i = 0; i < l; i++) 
				s.Append ("=");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.WriteLine();
			Console.Out.WriteLine(s);
			Console.ResetColor();
            Console.Out.WriteLine(String.Format("[Lapack: {0}]",ILNumerics.BuiltInFunctions.ILMath.Lapack.ToString())); 
		}
        /// <summary>
        /// write information about current state of ILMemoryPool
        /// </summary>
        private void WriteMemoryPoolStats() {
            //Console.Out.WriteLine(String.Format("MemoryPool stats: {0}kb reclaimed, {1} objects",ILMemoryPool.Pool.ReclaimedBytesCount / 1024, ILMemoryPool.Pool.ReclaimedObjectsCount));   
            Console.Out.Write(ILMemoryPool.Pool.Info(false));
        }
		/// <summary>
		/// Print default footer information. May be overwritten by derived classes. 
		/// </summary>
        protected virtual void Footer() {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Out.Write("Success: " + m_success);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.Write(" - ");
			if (m_failed > 0)
				Console.ForegroundColor = ConsoleColor.Red;
			Console.Out.WriteLine("Failed: " + m_failed);
			Console.ResetColor();
            WriteMemoryPoolStats();
		}
        /// <summary>
        /// handles printing of error informateion
        /// </summary>
        /// <param name="code">error code at time the test failed. This value depends only on the specifi test function implementation.</param>
        /// <param name="msg">Descriptive error message.</param>
        /// <remarks><para>The function will prepend the name of the function and stack trace information to the message</para>
        /// <para>A garbage collector run is initialized. </para></remarks>
        protected virtual void Error(int code, string msg) {
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(1);
            Error(sf.GetMethod().Name + " failed at: " + code.ToString() + " due:" + Environment.NewLine + msg);
            System.GC.Collect( ); 
       }
        /// <summary>
        /// print simple error information
        /// </summary>
        /// <param name="message">simple descriptive message </param>
		protected virtual void Error(string message) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Out.WriteLine(message);
			Console.ResetColor();
			m_failed++;
		}
        /// <summary>
        /// print succes information to console
        /// </summary>
        /// <param name="message">descripive information message</param>
		protected virtual void Success(string message) {
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.WriteLine(GetMethodName() + " " + message);
			Console.ResetColor();
			m_success++;
            System.GC.Collect( ); 
		}
        /// <summary>
        /// print simple success information to console
        /// </summary>
        protected virtual void Success() {
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.WriteLine(GetMethodName());
			Console.ResetColor();
			m_success++;
        }
        /// <summary>
        /// query the name of the calling method for output
        /// </summary>
        /// <returns>name of the function this call came from</returns>
        private static string GetMethodName() {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            string msg = sf.GetMethod().Name + " successfull.";
            return msg;
        }
        /// <summary>
        /// outputs informational message
        /// </summary>
        /// <param name="message">message</param>
		protected virtual void Info(string message) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Out.WriteLine("[INFO]" + message);
			Console.ResetColor();
		}
	}
}
