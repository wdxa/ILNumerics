using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public enum ParameterDirection {
        input, 
        output
    }
    
    public class ILTestParameterDefinition {

        ILCell m_array; 
        ParameterDirection m_direction; 
        string m_castName; 

        public ILCell Array {
            get { return m_array; }
            set { m_array = value; }
        }
        public ParameterDirection Direction {
            get { return m_direction; }
            set { m_direction = value; }
        }
        public string CastName {
            get { return m_castName; }
            set { m_castName = value; }
        }
    }
}
