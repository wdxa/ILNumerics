using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics; 

namespace ILAutoTestCaseGeneration.TestDefinitions {
    internal class subtract : ILTestCaseBase {

        public subtract(ILTestAutoGenerator generator) : base (generator) {
            #region binary parameterized version
            int testCount = 0; 
            generator.RelativeTestCasePath = "subtract";
            ILTestCaseDefinition subtract1 = new ILTestCaseDefinition("TEST_ILMath_subtract"+(testCount++).ToString(),"[{2}] = {0} - {1};", "{2}=ILMath.subtract({0},{1});",2,1,null); 
            ArrayProviders = ILTestPermutingArrayProvider.GetDefaultArrayTypes(2); 
            CaseDefinitions.Add(subtract1); 
            #endregion
        }
    }
}
