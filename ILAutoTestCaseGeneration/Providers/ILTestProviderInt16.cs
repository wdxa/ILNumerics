using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderInt16 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<short> tmp;
            ret[count++] = ILArray<short>.empty(0, 0);
            ret[count++] = ILArray<short>.empty(1, 0);
            ret[count++] = ILArray<short>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<short>)(short)1; 
            ret[count++] = (ILArray<short>)short.MaxValue; 
            ret[count++] = (ILArray<short>)short.MinValue; 
            ret[count++] = (ILArray<short>)(short)0; 
            ret[count++] = (ILArray<short>) (short)(-30); 
            // vector
            ret[count++] = ILMath.toint16(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.toint16(ILMath.ones(1,10)); 
            ret[count++] = ILMath.toint16(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.toint16(ILMath.ones(10,1)); 
            ret[count++] = ILMath.toint16(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.toint16(ILMath.vector(-5.0,4.0));

            tmp = ILMath.toint16(ILMath.vector(-5.0,4.0));
            tmp[0] = short.MinValue; 
            tmp["end"] = short.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.toint16(ILMath.zeros(3,2));
            ret[count++] = ILMath.toint16(ILMath.rand(2,4));
            ret[count++] = ILMath.toint16(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.toint16(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.toint16(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint16(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.toint16(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint16(ILMath.ones(4, 3, 2) * short.MinValue);
            ret[count++] = ILMath.toint16(ILMath.rand(4, 3, 2) * short.MaxValue - (short.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.toint16(ILMath.rand(30, 2, 3, 20) * short.MaxValue - (short.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<short>"; 
        }
        public override string GetIdentifierPostfix() {
            return "short"; 
        }
    }
}
