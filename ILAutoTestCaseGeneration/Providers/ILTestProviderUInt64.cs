using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderUInt64 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<ulong> tmp;
            ret[count++] = ILArray<ulong>.empty(0, 0);
            ret[count++] = ILArray<ulong>.empty(1, 0);
            ret[count++] = ILArray<ulong>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<ulong>)(ulong)1; 
            ret[count++] = (ILArray<ulong>)ulong.MaxValue; 
            ret[count++] = (ILArray<ulong>)ulong.MinValue; 
            ret[count++] = (ILArray<ulong>)(ulong)0; 
            ret[count++] = (ILArray<ulong>) (ulong)(30); 
            // vector
            ret[count++] = ILMath.touint64(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.touint64(ILMath.ones(1,10)); 
            ret[count++] = ILMath.touint64(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.touint64(ILMath.ones(10,1)); 
            ret[count++] = ILMath.touint64(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.touint64(ILMath.vector(0.0,14.0));

            tmp = ILMath.touint64(ILMath.vector(-5.0,4.0));
            tmp[0] = ulong.MinValue; 
            tmp["end"] = ulong.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.touint64(ILMath.zeros(3,2));
            ret[count++] = ILMath.touint64(ILMath.rand(2,4));
            ret[count++] = ILMath.touint64(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.touint64(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.touint64(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint64(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.touint64(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint64(ILMath.ones(4, 3, 2) * ulong.MinValue);
            ret[count++] = ILMath.touint64(ILMath.rand(4, 3, 2) * ulong.MaxValue - (ulong.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.touint64(ILMath.rand(30, 2, 3, 20) * ulong.MaxValue - (ulong.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<ulong>"; 
        }
        public override string GetIdentifierPostfix() {
            return "ulong"; 
        }
    }
}
