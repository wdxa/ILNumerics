using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderComplex : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell ret = new ILCell(); 
            int count = 0;
            complex[] elements = new complex[] {
                    new complex(0.0,0.0),
                    new complex(1.0,0.0), 
                    new complex(1.0,1.0), 
                    new complex(0.0,1.0), 
                    new complex(-1.0,0.0), 
                    new complex(-1.0,-1.0), 
                    new complex(0.0,-1.0), 
                    new complex(double.NaN,0.0), 
                    new complex(double.NaN,1.0), 
                    new complex(0.0,double.NaN), 
                    new complex(1.0,double.NaN), 
                    new complex(double.NaN,double.NaN),     // 11
                    new complex(double.PositiveInfinity,0.0), 
                    new complex(double.PositiveInfinity,1.0), 
                    new complex(0.0,double.PositiveInfinity), 
                    new complex(1.0,double.PositiveInfinity), 
                    new complex(double.PositiveInfinity,double.PositiveInfinity), 
                    new complex(double.NegativeInfinity,0.0), 
                    new complex(double.NegativeInfinity,1.0), 
                    new complex(0.0,double.NegativeInfinity), 
                    new complex(1.0,double.NegativeInfinity), 
                    new complex(double.NegativeInfinity,double.NegativeInfinity), 
                    // mixed
                    new complex(double.NaN,double.NegativeInfinity), 
                    new complex(double.NaN,double.PositiveInfinity), 
                    new complex(double.PositiveInfinity,double.NegativeInfinity), 
                    new complex(double.NegativeInfinity,double.PositiveInfinity), 
                    new complex(double.NaN,double.PositiveInfinity), 
                    new complex(double.NegativeInfinity,double.NaN), 
                    new complex(double.PositiveInfinity,double.NaN), 
                    new complex(double.MaxValue,double.NaN), 
                    new complex(double.MinValue,double.NaN), 
                    new complex(double.MaxValue,double.MinValue), 
                    new complex(double.NaN,double.MaxValue), 
                    new complex(double.NaN,double.MinValue), 
                    new complex(double.MaxValue,double.MinValue)
            };

                // empty 
            ILArray<complex> tmp;
            ret[count++] = ILArray<complex>.empty(0,0);
            ret[count++] = ILArray<complex>.empty(1, 0);
            ret[count++] = ILArray<complex>.empty(0, 1, 0); 
            // scalar 
            foreach (complex elem in elements) 
                ret[count++] = (ILArray<complex>)elem; 
            // vector
            ret[count++] = ILArray<complex>.zeros(1,10); 
            ret[count++] = ILArray<complex>.zeros(1,10) + elements[2]; 
            ret[count++] = ILArray<complex>.zeros(10,1); 
            ret[count++] = ILArray<complex>.zeros(10,1) + elements[2];  
            ret[count++] = ILMath.ccomplex(ILMath.vector(0.0,10.0),ILMath.vector(0.0,10.0));
            ret[count++] = ILMath.ccomplex(ILMath.vector(-5.0,4.0),-ILMath.vector(-5.0,4.0));

            tmp = ILMath.ccomplex(ILMath.vector(-5.0,4.0),-ILMath.vector(-5.0,4.0));
            tmp[0] = elements[22]; 
            tmp["end"] = elements[25]; 
            tmp[3] = elements[26]; 
            ret[count++] = tmp; 
            // matrix
            ret[count++] = ILArray<complex>.zeros(3,2);
            ret[count++] = ILMath.ccomplex(ILMath.rand(3,4),ILMath.rand(3,4));
            ret[count++] = ILMath.ccomplex(ILMath.ones(2,3) * double.NaN,ILMath.ones(2,3) * double.NaN); 
            ret[count++] = ILMath.ccomplex(ILMath.ones(3,2) / 0.0,ILMath.ones(3,2) / 0.0); // inf 
            tmp = ILArray<complex>.zeros(3,2) + elements[2]; 
            tmp[0] = elements[11];     // nans
            ret[count++] = tmp; 
            tmp[1] = elements[15]; 
            ret[count++] = tmp; 
            tmp[3] = elements[20];    // neg inf
            ret[count++] = tmp; 
            // 3d array 
            ret[count++] = ILMath.ccomplex(ILMath.zeros(4, 3, 2),ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.ccomplex(ILMath.ones(4, 3, 2),ILMath.ones(4, 3, 2));
            ret[count++] = ILMath.ccomplex(0.0 / ILMath.zeros(4, 3, 2),0.0 / ILMath.zeros(4, 3, 2));
            ret[count++] = ILMath.ccomplex(ILMath.ones(4, 3, 2) * float.NaN,ILMath.ones(4, 3, 2) * float.NaN);
            ret[count++] = ILMath.ccomplex(ILMath.ones(4, 3, 2) * float.NegativeInfinity,ILMath.ones(4, 3, 2) * float.NegativeInfinity);
            ret[count++] = ILMath.ccomplex(ILMath.rand(4, 3, 2),ILMath.rand(4, 3, 2)); 
            // 4d array 
            ret[count++] = ILMath.ccomplex(ILMath.rand(15, 12, 3, 10),ILMath.rand(15, 12, 3, 10));

            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<complex>"; 
        }
        public override string GetIdentifierPostfix() {
            return "complex"; 
        }
    }
}
