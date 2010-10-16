using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderSingle : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<float> tmp;
            ret[count++] = ILMath.tosingle(ILArray<float>.empty(0, 0));
            ret[count++] = ILMath.tosingle(ILArray<float>.empty(1, 0));
            ret[count++] = ILMath.tosingle(ILArray<float>.empty(0, 1, 0)); 
            // scalar 
            ret[count++] = (ILArray<float>)1.0f; 
            ret[count++] = (ILArray<float>)float.NaN; 
            ret[count++] = (ILArray<float>)float.PositiveInfinity; 
            ret[count++] = (ILArray<float>)float.NegativeInfinity; 
            ret[count++] = (ILArray<float>)0.0f; 
            ret[count++] = (ILArray<float>) (-30.0f); 
            // vector
            ret[count++] = ILMath.tosingle(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.tosingle(ILMath.ones(1,10)); 
            ret[count++] = ILMath.tosingle(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.tosingle(ILMath.ones(10,1)); 
            ret[count++] = ILMath.tosingle(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.tosingle(ILMath.vector(-5.0,4.0));

            tmp = ILMath.tosingle(ILMath.vector(-5.0,4.0));
            tmp[0] = float.NegativeInfinity; 
            tmp["end"] = float.PositiveInfinity; 
            tmp[3] = float.NaN; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.tosingle(ILMath.zeros(3,2));
            ret[count++] = ILMath.tosingle(ILMath.rand(2,4));
            ret[count++] = ILMath.tosingle(ILMath.ones(2,3) * float.NaN); 
            ret[count++] = ILMath.tosingle(ILMath.ones(3,2) / 0.0); // inf 
            tmp = ILMath.tosingle(ILMath.ones(3,2)); 
            tmp[0] = float.NaN; 
            ret[count++] = tmp; 
            tmp[1] = float.PositiveInfinity; 
            ret[count++] = tmp; 
            tmp[3] = float.NegativeInfinity; 
            ret[count++] = tmp; 
            // 3d array 
            ret[count++] = ILMath.tosingle(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tosingle(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.tosingle(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tosingle(ILMath.ones(4, 3, 2) * float.NaN);
            ret[count++] = ILMath.tosingle(ILMath.ones(4, 3, 2) * float.NegativeInfinity);
            ret[count++] = ILMath.tosingle(ILMath.rand(4, 3, 2)); 
            // 4d array 
            ret[count++] = ILMath.tosingle(ILMath.rand(30, 2, 3, 20));

            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<float>"; 
        }
        public override string GetIdentifierPostfix() {
            return "single"; 
        }
    }
}
