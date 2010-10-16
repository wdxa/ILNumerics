using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions;
using ILNumerics; 

namespace ILAutoTestCaseGeneration {
    public class ILTestProviderUInt32MaxChar : ILTestArrayProvider {
        public override ILCell GenerateTestArrays() {
            ILCell byteCell = new ILTestProviderUInt16().GenerateTestArrays(); 
            ILCell ret = new ILCell(byteCell.Dimensions[0],byteCell.Dimensions[1]); 
            int counter = 0; 
            foreach (ILBaseArray arr in byteCell.Values) {
                if (arr is ILArray<UInt16>) {
                    ILArray<UInt16> arrB = arr as ILArray<UInt16>; 
                    ret[counter++,0] = ILMath.touint32(arrB); 
                }
            }
            return ret; 
        }
        public override string GetCSharpTypeDefinition() {
            return "ILArray<uint>"; 
        }
        public override string GetIdentifierPostfix() {
            return "char"; 
        }
    }
}
