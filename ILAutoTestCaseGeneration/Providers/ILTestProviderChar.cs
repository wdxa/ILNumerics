using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderChar : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<char> tmp;
            ret[count++] = ILArray<char>.empty(0, 0);
            ret[count++] = ILArray<char>.empty(1, 0);
            ret[count++] = ILArray<char>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<char>)(char)1; 
            ret[count++] = (ILArray<char>)char.MaxValue; 
            ret[count++] = (ILArray<char>)char.MinValue; 
            ret[count++] = (ILArray<char>)(char)0.0; 
            ret[count++] = (ILArray<char>) ((char)30.0); 
            // vector
            ret[count++] = ILMath.tochar(ILMath.zeros(1,10)); 
            ret[count++] = ILMath.tochar(ILMath.ones(1,10)); 
            ret[count++] = ILMath.tochar(ILMath.zeros(10,1)); 
            ret[count++] = ILMath.tochar(ILMath.ones(10,1)); 
            ret[count++] = ILMath.tochar(ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.tochar(ILMath.vector(-5.0,4.0));

            tmp = ILMath.tochar(ILMath.vector(-5.0,4.0));
            tmp[0] = char.MinValue; 
            tmp["end"] = char.MaxValue; 
            tmp[3] = (char)0;  
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.tochar(ILMath.zeros(3,2));
            ret[count++] = ILMath.tochar(ILMath.rand(2,4));
            ret[count++] = ILMath.tochar(ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.tochar(ILMath.ones(3,2) / 0.0); // inf 
            // 3d array 
            ret[count++] = ILMath.tochar(ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tochar(ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.tochar(0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.tochar(ILMath.ones(4, 3, 2) * char.MinValue);
            ret[count++] = ILMath.tochar(ILMath.rand(4, 3, 2) * char.MaxValue - (char.MaxValue / 2.0)); 
            // 4d array 
            ret[count++] = ILMath.tochar(ILMath.rand(30, 2, 3, 20) * char.MaxValue - (char.MaxValue / 2.0));
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<char>"; 
        }
        public override string GetIdentifierPostfix() {
            return "char"; 
        }
    }
}
