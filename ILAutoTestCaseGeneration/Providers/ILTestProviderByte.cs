using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderByte : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<byte> tmp;
            ret[count++] = ILArray<byte>.empty(0, 0);
            ret[count++] = ILArray<byte>.empty(1, 0);
            ret[count++] = ILArray<byte>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<byte>)(byte)1; 
            ret[count++] = (ILArray<byte>)byte.MaxValue; 
            ret[count++] = (ILArray<byte>)byte.MinValue; 
            ret[count++] = (ILArray<byte>)(byte)0; 
            ret[count++] = (ILArray<byte>) (byte)(30); 
            // vector
            ret[count++] = ILMath.tobyte(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.tobyte(ILMath.ones(1,10)); 
            ret[count++] = ILMath.tobyte(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.tobyte(ILMath.ones(10,1)); 
            ret[count++] = ILMath.tobyte(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.tobyte(ILMath.vector(-5.0,4.0));

            tmp = ILMath.tobyte(ILMath.vector(-5.0,4.0));
            tmp[0] = byte.MinValue; 
            tmp["end"] = byte.MaxValue; 
            tmp[3] = 0; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.tobyte(ILMath.zeros(3,2));
            ret[count++] = ILMath.tobyte(ILMath.rand(2,4));
            ret[count++] = ILMath.tobyte(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.tobyte(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.tobyte(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tobyte(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.tobyte(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tobyte(ILMath.ones(4, 3, 2) * byte.MinValue);
            ret[count++] = ILMath.tobyte(ILMath.rand(4, 3, 2) * byte.MaxValue - (byte.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.tobyte(ILMath.rand(30, 2, 3, 20) * byte.MaxValue - (byte.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<byte>"; 
        }
        public override string GetIdentifierPostfix() {
            return "byte"; 
        }
    }
}
