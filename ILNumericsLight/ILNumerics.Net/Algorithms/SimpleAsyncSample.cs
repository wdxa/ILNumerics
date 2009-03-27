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
using ILNumerics; 
using System.Windows.Forms; 

namespace ILNumerics.Algorithms {
    /// <summary>
    /// Sample class for user defined asynchronous algorithm
    /// </summary>
    public class SimpleAsyncSample : ILAsyncAlgorithm {
        // define sample input structs
        private struct InputParamStruct {
            public double parameter1; 
            public int iterationCount; 
            public ILArray<double> parameter3; 
        }
        // define sample output struct
        public struct SimpleAsyncSampleResult {
            public string message; 
            public ILArray<double> result; 
        }
        // hold the imput parameter 
        private InputParamStruct m_inputParameter; 
        // property to cast the underlying 'object' result back to specific result struct
        public SimpleAsyncSampleResult Result {
            get {
                object res = base.GetResult(); 
                return (SimpleAsyncSampleResult)res; 
            }
        }
        // Implement a constructor receiving all parameter nesseccary 
        // for your specific algorithm here.
        // Do not forget to call the base class here! 
        public SimpleAsyncSample(Control control, double param1, int itCounter, ILArray<double> param3)
        : base (control) {
            m_inputParameter.parameter1 = param1; 
            m_inputParameter.iterationCount = itCounter; 
            m_inputParameter.parameter3 = param3; 
        }
        // the actual calculation - here it's a time consumer only 
        protected override object AlgorithmFunction(object parameter) {
            InputParamStruct input = (InputParamStruct)parameter; 
            SimpleAsyncSampleResult ret; 
            ret.message = "The algorithm has finished!";
            ret.result = randn(100,10,200); 
            for (int i = 0; i < input.iterationCount ; i++) {
                // simulate delay for 1 sec with an inner loop 
                for (int t = 0; t < 10; t ++) {
                    if (CancelPending) 
                        return -1.0; 
                    SetProgress((double)i / (double)input.iterationCount,"calculating..."); 
                    System.Threading.Thread.Sleep(100);
                }
            }
            return ret; 
        }
        // provides the parameter struct to the algorithm function
        protected override object CompileParameter() {
            return m_inputParameter; 
        }
    }
}
