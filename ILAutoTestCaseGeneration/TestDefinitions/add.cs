using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics; 

namespace ILAutoTestCaseGeneration.TestDefinitions {
    internal class add : ILTestCaseBase {

        public add(ILTestAutoGenerator generator) : base (generator) {
            #region binary parameterized version
            int testCount = 0; 
            generator.RelativeTestCasePath = "add";
            ILTestCaseDefinition add1 = new ILTestCaseDefinition("TEST_ILMath_add"+(testCount++).ToString(),"[{2}] = {0} + {1};", "{2}=ILMath.add({0},{1});",2,1,null); 
            ArrayProviders = ILTestPermutingArrayProvider.GetDefaultArrayTypes(2); 
            CaseDefinitions.Add(add1); 
            #endregion
        }
    }
}
