using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderDouble : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0; 
            // empty 
            ILArray<double> tmp;
            ret[count++] = ILArray<double>.empty(0, 0);
            ret[count++] = ILArray<double>.empty(1, 0);
            ret[count++] = ILArray<double>.empty(0, 1, 0); 
            // scalar 
            ret[count++] = (ILArray<double>)1.0; 
            ret[count++] = (ILArray<double>)double.NaN; 
            ret[count++] = (ILArray<double>)double.PositiveInfinity; 
            ret[count++] = (ILArray<double>)double.NegativeInfinity; 
            ret[count++] = (ILArray<double>)0.0; 
            ret[count++] = (ILArray<double>) (-30.0); 
            // vector
            ret[count++] = ILMath.zeros(1,10); 
            ret[count++] = ILMath.ones(1,10); 
            ret[count++] = ILMath.zeros(10,1); 
            ret[count++] = ILMath.ones(10,1); 
            ret[count++] = ILMath.vector(0.0,10.0);
            ret[count++] = ILMath.vector(-5.0,4.0);

            tmp = ILMath.vector(-5.0,4.0);
            tmp[0] = double.NegativeInfinity; 
            tmp["end"] = double.PositiveInfinity; 
            tmp[3] = double.NaN; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILMath.zeros(3,2);
            ret[count++] = ILMath.rand(2,4);
            ret[count++] = ILMath.ones(2,3) * double.NaN; 
            ret[count++] = ILMath.ones(3,2) / 0.0; // inf 
            tmp = ILMath.ones(3,2); 
            tmp[0] = double.NaN; 
            ret[count++] = tmp; 
            tmp[1] = double.PositiveInfinity; 
            ret[count++] = tmp; 
            tmp[3] = double.NegativeInfinity; 
            ret[count++] = tmp; 
            // 3d array 
            ret[count++] = ILMath.zeros(4, 3, 2);
            ret[count++] = ILMath.ones(4, 3, 2);
            ret[count++] = 0.0 / ILMath.zeros(4, 3, 2);
            ret[count++] = ILMath.ones(4, 3, 2) * double.NaN;
            ret[count++] = ILMath.ones(4, 3, 2) * double.NegativeInfinity;
            ret[count++] = ILMath.rand(4, 3, 2); 
            // 4d array 
            ret[count++] = ILMath.rand(30, 2, 3, 20);

            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<double>"; 
        }
        public override string GetIdentifierPostfix() {
            return "double"; 
        }
    }
}
