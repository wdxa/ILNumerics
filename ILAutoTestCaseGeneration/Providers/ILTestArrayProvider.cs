using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.BuiltInFunctions; 
using ILNumerics;

namespace ILAutoTestCaseGeneration {
    public abstract class ILTestArrayProvider {
        
        private Type[] m_types; 
        public ILTestArrayProvider (params Type[] types) {
            m_types = types; 
        }
        
        public abstract ILCell GenerateTestArrays ();

        public abstract string GetCSharpTypeDefinition(); 
        public abstract string GetIdentifierPostfix(); 

        public static Dictionary<string,ILTestArrayProvider> GetDefaultArrayTypes() {
            Dictionary<string,ILTestArrayProvider> arrayProviders = new Dictionary<string,ILTestArrayProvider>(); 
            arrayProviders.Add("double",new ILTestProviderDouble()); 
            arrayProviders.Add("float",new ILTestProviderSingle()); 
            arrayProviders.Add("complex",new ILTestProviderComplex()); 
            arrayProviders.Add("fcomplex",new ILTestProviderFComplex()); 
            arrayProviders.Add("int16",new ILTestProviderInt16()); 
            arrayProviders.Add("int32",new ILTestProviderInt32()); 
            arrayProviders.Add("uint16",new ILTestProviderUInt16()); 
            arrayProviders.Add("uint32",new ILTestProviderUInt32()); 
            arrayProviders.Add("byte",new ILTestProviderByte()); 
            return arrayProviders; 
        }

        public static ILCell PermuteTestArrays(params ILCell[] inputParameter) {
            if (inputParameter == null || inputParameter.Length == 0) 
                throw new Exception("no input parameter specified!");
            for (int i = 0; i < inputParameter.Length; i++) {
                if (inputParameter[i] == null || inputParameter[i].IsEmpty || !inputParameter[i].IsColumnVector)
                    throw new Exception("input parameter #" + i + " has wrong format. All parameters must be column vectors!"); 
            }
            ILCell ret = new ILCell(inputParameter[0].Length,inputParameter.Length); 
            int[] curPos = new int[inputParameter.Length];
            int p = 0, d = 0; 
            while (d < curPos.Length) {
                for (int i = 0; i < curPos.Length; i++) {
                    ret[p,i] = inputParameter[i][curPos[i],0]; 
			    }
                p++; d = 0; 
                while (d < curPos.Length) { 
                    if (curPos[d] < inputParameter[d].Length - 1) {
                        curPos[d]++; 
                        break; 
                    }
                    curPos[d++] = 0;
                }
            }
            return ret; 
        }

    }
}
