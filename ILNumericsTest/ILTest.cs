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
using System.Collections.Generic; 
using System.IO; 
using ILNumerics.Misc; 
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Test {
    /// <summary>
    /// Base test case class
    /// </summary>
    /// <remarks>This class serves as base class for all test classes for ILNumerics.Net. It is used as standalone and simple 
    /// test framework in order to make testing easy for non - microsoft systems (mono) also. </remarks>
	public abstract class ILTest {
        
        static string LogName = "ILNumericsTest.LastRun.log"; 
        static string FailedTestsLogName = "ILNumericsTest.FailedTests.log"; 
        protected int m_errorWaitForUserInputSec = 5; 
        protected List<int> m_manualIgnoreIds; 
        private bool m_ignoreAllErrors; 

        static ILTest () {
            // create logfile: ILNumericsTest.LastRun.log
            if (File.Exists(LogName))  
                File.Delete(LogName); 
            if (File.Exists(FailedTestsLogName))  
                File.Delete(FailedTestsLogName); 
            //Console.Beep(); 
            File.AppendAllText(LogName,String.Format("General Test Program for ILNumerics.Net.\r\nDate: {0}\r\n",DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString())); 
        }

        public ILTest() {
            m_failed = 0; 
            m_success = 0; 
            m_failedTestNames = new List<string>(); 
            m_failedTestCases = new Dictionary<string,int>(); 
            m_manualOverrides = new ILCell();      // 6930812  220803
            m_manualIgnoreIds = new List<int>(); 
            m_ignoreAllErrors = false; 
        }
        
        /// <summary>
        /// internal counter for failed tests
        /// </summary>
		protected int m_failed = 0;
        /// <summary>
        /// internal counter for succeeded tests
        /// </summary>
		protected int m_success = 0; 

        protected List<string> m_failedTestNames; 
        protected Dictionary<string,int> m_failedTestCases; 
        protected ILCell m_manualOverrides; 
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
            File.AppendAllText(LogName,"\r\n" + s.ToString());
			Console.ResetColor();
            string lapackInfo = String.Format("[Lapack: {0}]",ILNumerics.BuiltInFunctions.ILMath.Lapack.ToString()); 
            Console.Out.WriteLine(lapackInfo); 
            File.AppendAllText(LogName,"\r\n" + lapackInfo.ToString());
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
            // logfile out
            File.AppendAllText(LogName,String.Format("\r\nSuccess: {0} - Error: {1}\r\n",m_success,m_failed));
            if (m_failed > 0) {
                File.AppendAllText(LogName,String.Format("\r\n!!################!!\r\nFailed Tests: \r\n {0}",String.Join(Environment.NewLine, m_failedTestNames.ToArray()))); 
                File.AppendAllText(LogName,"\r\n\r\n"); 
            }
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
			Console.ForegroundColor = ConsoleColor.Red;
			string message = sf.GetMethod().Name + " failed at: " + code.ToString() + " due:" + Environment.NewLine + msg; 
            Console.Out.WriteLine(message);
			Console.ResetColor();
			m_failedTestNames.Add(message); 
            string className = sf.GetMethod().DeclaringType.FullName; 
            if (!m_failedTestCases.ContainsKey(className)) {
                m_failedTestCases.Add(className,1); 
                File.AppendAllText(FailedTestsLogName,className + Environment.NewLine);
            } else {
                m_failedTestCases[className]++; 
            }
            m_failed++;
            //System.GC.Collect( ); 
       }
        /// <summary>
        /// print simple error information
        /// </summary>
        /// <param name="message">simple descriptive message </param>
		protected virtual void Error(string message) {
            StackTrace st = new StackTrace(); 
            StackFrame sf = st.GetFrame(1);
			Console.ForegroundColor = ConsoleColor.Red;
            message = sf.GetMethod() + ": " + message; 
			Console.Out.WriteLine(message);
			Console.ResetColor();
			m_failedTestNames.Add(message); 
            string className = sf.GetMethod().DeclaringType.FullName; 
            if (!m_failedTestCases.ContainsKey(className)) {
                m_failedTestCases.Add(className,1); 
                File.AppendAllText(FailedTestsLogName,className + Environment.NewLine);
            } else {
                m_failedTestCases[className]++; 
            }
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
        protected static string InfoExt() {
        	StringBuilder s = new StringBuilder(); 
        	s.Append("This is the general test routine for ILNumerics.Net" + Environment.NewLine); 
        	s.Append("" + Environment.OSVersion + ", "); 
        	s.Append("Number of proc: " + Environment.ProcessorCount + ", "+ Environment.NewLine); 
        	s.Append("CLR: " + Environment.Version + ", "); 
        	s.Append("Proc.memory: " + Environment.WorkingSet + ""+ Environment.NewLine);
            ILNumerics.Native.ILCPUID cpuid = new ILNumerics.Native.ILCPUID(); 
            s.Append(String.Format("CPUID:{0}",cpuid.ToString())); 
        	return s.ToString();  
        }  

        protected void CheckManualOverwrite(int waitAutoContinueMs, 
                                            ILMatFile inputs, ILMatFile outputsExt, 
                                            int id, int nrInputParams, int nrOutputParams,
                                            int idFailedOutput, ILBaseArray failedOutputILN) {
            // give extensive error info
            Console.Out.WriteLine("Failure! ####################################"); 
            Console.Out.WriteLine("Should extensive error information be displayed? (y/n)"); 
            if (Console.In.Read() == 1) return; 
            // waits for n msec for user input
            // skip
            // overwrite 
            
        
        }

        protected ErrorHandlerProcessMethod ProcessParameterErrorInfo(int id, ILBaseArray parameter0, 
                                int nrInputParams, int nrOutputParams, int failedResultNo, 
                                ILMatFile inputMatfile, ILMatFile outputMatfile, 
                                string functionDefinition) {
            // determine how to proceed with the error
            if (m_ignoreAllErrors || m_manualIgnoreIds.Contains(id)) {
                if (!m_manualIgnoreIds.Contains(id))
                    m_manualIgnoreIds.Add(id); 
                return ErrorHandlerProcessMethod.IgnoreAll; 
            }
            Console.ResetColor();
            Console.WriteLine("Press 'i' for extended error information! (will continue in " + m_errorWaitForUserInputSec.ToString() + " sec otherwise)");
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(m_errorWaitForUserInputSec);
            while (!Console.KeyAvailable && DateTime.Now < end) {
                System.Threading.Thread.Sleep(100);
            }
            if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.I) {
                // function definition
                Console.WriteLine("Function: {0}",functionDefinition); 
                // write error infos: input parameters
                for (int i = 0; i < nrInputParams; i++) {
                    Console.WriteLine("Input parameter #{0}:\r\n#############################\r\n{1}", i, inputMatfile["input_" + id.ToString() + "_" + i.ToString()].ToString());
                }
                // write error infos: output parameters
                for (int i = 0; i < nrOutputParams; i++) {
                    Console.WriteLine("Expected output parameter #{0}:\r\n#############################\r\n{1}", i, outputMatfile["output_" + id.ToString() + "_" + i.ToString()].ToString());
                }
                Console.WriteLine("Result #{0} returned unexpected value: \r\n ############################\r\n{1}", failedResultNo, parameter0.ToString());
                // ask how to proceed
                ConsoleKey pressedKey = ConsoleKey.NoName;
                while (pressedKey != ConsoleKey.A && 
                        pressedKey != ConsoleKey.I && 
                        pressedKey != ConsoleKey.P && 
                        pressedKey != ConsoleKey.L) {
                    Console.WriteLine("_A_bort / _I_gnore/ _P_ermanently ignore / Ignore al_L_ ");
                    while (!Console.KeyAvailable) {
                        System.Threading.Thread.Sleep(100);
                    }
                    pressedKey = Console.ReadKey(false).Key; 
                }
                if (pressedKey == ConsoleKey.A) {
                    Console.WriteLine("Aborting...");
                    return ErrorHandlerProcessMethod.Abort; 
                } else if (pressedKey == ConsoleKey.L) {
                    Console.WriteLine("All errors will be ignored in future runs of this test ...");
                    m_manualIgnoreIds.Add(id); 
                    m_ignoreAllErrors = true; 
                    return ErrorHandlerProcessMethod.IgnoreAll; 
                } else if (pressedKey == ConsoleKey.I) {
                    Console.WriteLine("The error will be ignored in this test ...");
                    return ErrorHandlerProcessMethod.IgnoreAll; 
                } else if (pressedKey == ConsoleKey.P) {
                    Console.WriteLine("The error will be permanently ignored in this test ...");
                    m_manualIgnoreIds.Add(id); 
                    return ErrorHandlerProcessMethod.IgnoreAll; 
                } 
            }
            return ErrorHandlerProcessMethod.Ignore; 
        }

        protected void StoreIgnoreIds(string outDir) {
            // store ignore ids 
            ILMatFile ignoreIDs = new ILMatFile();
            ILArray<int> ids = new ILArray<int>(m_manualIgnoreIds.ToArray(), m_manualIgnoreIds.Count, 1);
            ignoreIDs["ignored"] = ids;
            using (Stream outStream = new FileStream(outDir + Path.DirectorySeparatorChar + "ignored.mat", FileMode.Create, FileAccess.ReadWrite)) {
                ignoreIDs.Write(outStream);
            }
        }
        protected void LoadIgnoreIds(string path) {
            if (File.Exists(path + Path.DirectorySeparatorChar + "ignored.mat")) {
                ILMatFile ignoreIds = new ILMatFile(path + Path.DirectorySeparatorChar + "ignored.mat"); 
                if (ignoreIds["ignored"] != null && ignoreIds["ignored"] is ILArray<int>) {
                    ILArray<int> ids = (ILArray<int>)ignoreIds["ignored"]; 
                    m_manualIgnoreIds.AddRange(ids.Values); 
                }
            }
        }

	}
}
