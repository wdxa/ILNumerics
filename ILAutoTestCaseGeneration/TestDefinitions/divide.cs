using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics; 

namespace ILAutoTestCaseGeneration.TestDefinitions {
    internal class divide : ILTestCaseBase {

        public divide(ILTestAutoGenerator generator) : base (generator) {
            #region binary parameterized version
            generator.RelativeTestCasePath = "divide";
            int testCount = 0; 
            ArrayProviders = ILTestPermutingArrayProvider.GetDefaultArrayTypes(2); 
            #region overrides - ML does not recognize complex with imaginary part being zero
            List<ILResultOverride> overrides = new List<ILResultOverride>(); 
            ILCell inputOverride = new ILCell(1,2); 
            inputOverride[0] = (ILArray<complex>)new complex(double.PositiveInfinity,double.PositiveInfinity); 
            ILCell outputOverride = new ILCell(1,2); 
            outputOverride[0] = (ILArray<complex>) new complex(0.0,0.0); 
            ILResultOverride overr = new ILResultOverride(ArrayProviders["complex"],inputOverride,outputOverride);
            
            overrides.Add(overr); 
            #endregion
            ILTestCaseDefinition divide1 = new ILTestCaseDefinition("TEST_ILMath_divide"+(testCount++).ToString(),
                                        "[{2}] = {0} ./ {1};", "{2}=ILMath.divide({0},{1});",
                                        2,1,overrides); 
            CaseDefinitions.Add(divide1); 
            #endregion
        }
    }
}
