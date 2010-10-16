using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics; 

namespace ILAutoTestCaseGeneration.TestDefinitions {
    internal class multiplyElements : ILTestCaseBase {

        public multiplyElements(ILTestAutoGenerator generator) : base (generator) {
            #region binary parameterized version
            int testCount = 0; 
            generator.RelativeTestCasePath = "multiplyElem";
            ILTestCaseDefinition multiplyElements1 = new ILTestCaseDefinition("TEST_ILMath_multiplyElem"+(testCount++).ToString(),"[{2}] = {0} .* {1};", "{2}=ILMath.multiplyElem({0},{1});",2,1,null); 
            ArrayProviders = ILTestPermutingArrayProvider.GetDefaultArrayTypes(2); 
            CaseDefinitions.Add(multiplyElements1); 
            #endregion
        }
    }
}
