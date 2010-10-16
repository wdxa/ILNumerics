using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderUInt32 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<uint> tmp;
            ret[count++] = ILArray<uint>.empty(0, 0);
            ret[count++] = ILArray<uint>.empty(1, 0);
            ret[count++] = ILArray<uint>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<uint>)(uint)1; 
            ret[count++] = (ILArray<uint>)uint.MaxValue; 
            ret[count++] = (ILArray<uint>)uint.MinValue; 
            ret[count++] = (ILArray<uint>)(uint)0; 
            ret[count++] = (ILArray<uint>) (uint)(30); 
            // vector
            ret[count++] = ILMath.touint32(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.touint32(ILMath.ones(1,10)); 
            ret[count++] = ILMath.touint32(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.touint32(ILMath.ones(10,1)); 
            ret[count++] = ILMath.touint32(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.touint32(ILMath.vector(-5.0,4.0));

            tmp = ILMath.touint32(ILMath.vector(-5.0,4.0));
            tmp[0] = uint.MinValue; 
            tmp["end"] = uint.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.touint32(ILMath.zeros(3,2));
            ret[count++] = ILMath.touint32(ILMath.rand(2,4));
            ret[count++] = ILMath.touint32(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.touint32(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.touint32(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint32(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.touint32(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint32(ILMath.ones(4, 3, 2) * uint.MinValue);
            ret[count++] = ILMath.touint32(ILMath.rand(4, 3, 2) * uint.MaxValue - (uint.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.touint32(ILMath.rand(30, 2, 3, 20) * uint.MaxValue - (uint.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<uint>"; 
        }
        public override string GetIdentifierPostfix() {
            return "uint"; 
        }
    }
}
