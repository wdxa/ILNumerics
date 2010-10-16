using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderInt32 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<int> tmp;
            ret[count++] = ILArray<int>.empty(0, 0);
            ret[count++] = ILArray<int>.empty(1, 0);
            ret[count++] = ILArray<int>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<int>)1; 
            ret[count++] = (ILArray<int>)int.MaxValue; 
            ret[count++] = (ILArray<int>)int.MinValue; 
            ret[count++] = (ILArray<int>)0; 
            ret[count++] = (ILArray<int>) (-30); 
            // vector
            ret[count++] = ILMath.toint32(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.toint32(ILMath.ones(1,10)); 
            ret[count++] = ILMath.toint32(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.toint32(ILMath.ones(10,1)); 
            ret[count++] = ILMath.toint32(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.toint32(ILMath.vector(-5.0,4.0));

            tmp = ILMath.toint32(ILMath.vector(-5.0,4.0));
            tmp[0] = int.MinValue; 
            tmp["end"] = int.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.toint32(ILMath.zeros(3,2));
            ret[count++] = ILMath.toint32(ILMath.rand(2,4));
            ret[count++] = ILMath.toint32(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.toint32(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.toint32(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint32(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.toint32(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.toint32(ILMath.ones(4, 3, 2) * int.MinValue);
            ret[count++] = ILMath.toint32(ILMath.rand(4, 3, 2) * int.MaxValue - (int.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.toint32(ILMath.rand(30, 2, 3, 20) * int.MaxValue - (int.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<int>"; 
        }
        public override string GetIdentifierPostfix() {
            return "int"; 
        }
    }
}
