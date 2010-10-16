using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderFComplex : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILTestProviderComplex().GenerateTestArrays();
            for (int i = 0; i < ret.Dimensions[0]; i++) {
                ret[i] = ILMath.tofcomplex(ret[i]); 
            }
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<fcomplex>"; 
        }
        public override string GetIdentifierPostfix() {
            return "fcomplex"; 
        }
    }
}
