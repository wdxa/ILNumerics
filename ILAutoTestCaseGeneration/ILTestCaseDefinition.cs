using System;
using System.Collections.Generic;
using System.Text;

namespace ILAutoTestCaseGeneration {
    
    /// <summary>
    /// holds all data needed to define auto generated test case
    /// </summary>
    public class ILTestCaseDefinition {

        string m_octaveFunctionDef;
        string m_targetFunctionDef;
        uint m_inputParameterCount;
        uint m_outputParameterCount;
        string m_testCaseName; 
        IEnumerable<ILResultOverride> m_resultOverrides; 

        public string TestCaseName { get { return m_testCaseName; } }
        public string OctaveFunctionDef { get { return m_octaveFunctionDef; } }
        public string TargetFunctionDef   { get { return m_targetFunctionDef; } }
        public uint InputParameterCount  { get { return m_inputParameterCount; } }
        public uint OutputParameterCount { get { return m_outputParameterCount; } }
        public IEnumerable<ILResultOverride> ResultOverrides { get {return m_resultOverrides; } }

        public ILTestCaseDefinition(
                string testCaseName,
                string octaveFunctionDef,
                string targetFunctionDef,
                uint inputParameterCount,
                uint outputParameterCount,
                IEnumerable<ILResultOverride> resultOverrides) {
            m_testCaseName = testCaseName; 
            m_octaveFunctionDef = octaveFunctionDef;
            m_targetFunctionDef = targetFunctionDef;
            m_inputParameterCount = inputParameterCount;
            m_outputParameterCount = outputParameterCount; 
            m_resultOverrides = resultOverrides; 
        }
        public ILTestCaseDefinition(
                string testCaseName,
                string octaveFunctionDef,
                string targetFunctionDef,
                uint inputParameterCount,
                uint outputParameterCount) :
            this (testCaseName,octaveFunctionDef,targetFunctionDef,inputParameterCount,outputParameterCount,null) {
        }
    }
}
