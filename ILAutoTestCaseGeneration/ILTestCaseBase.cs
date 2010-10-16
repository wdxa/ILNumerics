using System;
using System.Collections.Generic;
using System.Text;

namespace ILAutoTestCaseGeneration {
    public abstract class ILTestCaseBase {

        ILTestAutoGenerator m_generator;
        List<ILTestCaseDefinition> m_caseDefinitions;
        Dictionary<string, ILTestArrayProvider> m_arrayProviders;

        public Dictionary<string, ILTestArrayProvider> ArrayProviders {
            get { return m_arrayProviders; }
            set { m_arrayProviders = value; }
        } 

        public List<ILTestCaseDefinition> CaseDefinitions {
            get { return m_caseDefinitions; }
        }

        public ILTestAutoGenerator Generator {
            get { return m_generator; }
        } 

        public ILTestCaseBase (ILTestAutoGenerator generator) {
            m_generator = generator; 
            m_caseDefinitions = new List<ILTestCaseDefinition>();
            m_arrayProviders = new Dictionary<string,ILTestArrayProvider>(); 
        }
        public virtual void Run() {
            Generator.BatchCreateTests(ArrayProviders.Values,CaseDefinitions); 
        }
        public virtual void Run(bool clearArrays, bool clearTestCases) {
            Run(); 
            if (clearArrays) ArrayProviders.Clear(); 
            if (clearTestCases) CaseDefinitions.Clear(); 
        }
    }
}
