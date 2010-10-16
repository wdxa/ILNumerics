using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILResultOverride : Dictionary<string,ILBaseArray>{ 
        ILTestArrayProvider m_testArrayProvider; 
        ILCell m_outputs; 
        ILCell m_inputs; 

        public ILTestArrayProvider TestArrayProvider {
            get { return m_testArrayProvider; }
        }
        public ILCell Outputs {
            get { return m_outputs; }
        }
        public ILCell Inputs {
            get { return m_inputs; }
        }

        public ILResultOverride (ILTestArrayProvider testArrayProvider, ILCell inputs, ILCell outputs) {
            m_outputs = outputs; 
            m_inputs = inputs; 
            m_testArrayProvider = testArrayProvider; 
        }

    }
}
