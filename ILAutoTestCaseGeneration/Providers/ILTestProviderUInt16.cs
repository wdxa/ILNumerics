using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderUInt16 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<ushort> tmp;
            ret[count++] = ILArray<ushort>.empty(0, 0);
            ret[count++] = ILArray<ushort>.empty(1, 0);
            ret[count++] = ILArray<ushort>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<ushort>)(ushort)1; 
            ret[count++] = (ILArray<ushort>)ushort.MaxValue; 
            ret[count++] = (ILArray<ushort>)ushort.MinValue; 
            ret[count++] = (ILArray<ushort>)(ushort)0; 
            ret[count++] = (ILArray<ushort>) (ushort)(30); 
            // vector
            ret[count++] = ILMath.touint16(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.touint16(ILMath.ones(1,10)); 
            ret[count++] = ILMath.touint16(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.touint16(ILMath.ones(10,1)); 
            ret[count++] = ILMath.touint16(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.touint16(ILMath.vector(0.0,14.0));

            tmp = ILMath.touint16(ILMath.vector(1.0,14.0));
            tmp[0] = ushort.MinValue; 
            tmp["end"] = ushort.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.touint16(ILMath.zeros(3,2));
            ret[count++] = ILMath.touint16(ILMath.rand(2,4));
            ret[count++] = ILMath.touint16(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.touint16(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.touint16(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint16(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.touint16(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.touint16(ILMath.ones(4, 3, 2) * ushort.MinValue);
            ret[count++] = ILMath.touint16(ILMath.rand(4, 3, 2) * ushort.MaxValue - (ushort.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.touint16(ILMath.rand(30, 2, 3, 20) * ushort.MaxValue - (ushort.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<ushort>"; 
        }
        public override string GetIdentifierPostfix() {
            return "ushort"; 
        }
    }
}
