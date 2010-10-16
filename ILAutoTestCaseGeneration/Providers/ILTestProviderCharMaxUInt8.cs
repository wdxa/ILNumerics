using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderCharMaxUInt8 : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell byteCell = new ILTestProviderByte().GenerateTestArrays(); 
            ILCell ret = new ILCell(byteCell.Dimensions[0],byteCell.Dimensions[1]); 
            int counter = 0; 
            foreach (ILBaseArray arr in byteCell.Values) {
                if (arr is ILArray<byte>) {
                    ILArray<byte> arrB = arr as ILArray<byte>; 
                    ret[counter++,0] = ILMath.tochar(arrB); 
                }
            }
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
