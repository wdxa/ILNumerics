using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderInt64 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<long> tmp;
            ret[count++] = ILArray<long>.empty(0, 0);
            ret[count++] = ILArray<long>.empty(1, 0);
            ret[count++] = ILArray<long>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<long>)(long)1; 
            ret[count++] = (ILArray<long>)long.MaxValue; 
            ret[count++] = (ILArray<long>)long.MinValue; 
            ret[count++] = (ILArray<long>)(long)0; 
            ret[count++] = (ILArray<long>) (long)(-30); 
            // vector
            ret[count++] = ILMath.toint64(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.toint64(ILMath.ones(1,10)); 
            ret[count++] = ILMath.toint64(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.toint64(ILMath.ones(10,1)); 
            ret[count++] = ILMath.toint64(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.toint64(ILMath.vector(-5.0,4.0));

            tmp = ILMath.toint64(ILMath.vector(-5.0,4.0));
            tmp[0] = long.MinValue; 
            tmp["end"] = long.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.toint64(ILMath.zeros(3,2));
            ret[count++] = ILMath.toint64(ILMath.rand(2,4));
            ret[count++] = ILMath.toint64(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.toint64(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.toint64(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint64(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.toint64(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint64(ILMath.ones(4, 3, 2) * long.MinValue);
            ret[count++] = ILMath.toint64(ILMath.rand(4, 3, 2) * long.MaxValue - (long.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.toint64(ILMath.rand(30, 2, 3, 20) * long.MaxValue - (long.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<long>"; 
        }
        public override string GetIdentifierPostfix() {
            return "long"; 
        }
    }
}
