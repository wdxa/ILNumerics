using System;
using System.Collections.Generic;
using System.Text;

namespace ILAutoTestCaseGeneration {
    public class ILTestPermutingArrayProvider : ILTestArrayProvider {

        ILTestArrayProvider m_provider;
        int m_count; 

        public ILTestPermutingArrayProvider (ILTestArrayProvider baseProvider, int count) {
            m_provider = baseProvider; 
            m_count = count; 
        }

        public static Dictionary<string,ILTestArrayProvider> GetDefaultArrayTypes(int count) {
            Dictionary<string,ILTestArrayProvider> arrayProviders 
                            = ILTestArrayProvider.GetDefaultArrayTypes(); 
            Dictionary<string,ILTestArrayProvider> ret = new Dictionary<string,ILTestArrayProvider>(); 
            foreach (ILTestArrayProvider prov in arrayProviders.Values) {
                ret.Add(prov.GetIdentifierPostfix(), new ILTestPermutingArrayProvider(prov,count));
            }
            return ret; 
        }

        public override ILNumerics.ILCell GenerateTestArrays() {
            ILNumerics.ILCell[] inputParameter = new ILNumerics.ILCell[m_count];
            for (int i = 0; i < m_count; i++) {
                inputParameter[i] = m_provider.GenerateTestArrays();                 
            }
            return ILTestArrayProvider.PermuteTestArrays(inputParameter); 
        }

        public override string GetCSharpTypeDefinition() {
            return m_provider.GetCSharpTypeDefinition(); 
        }

        public override string GetIdentifierPostfix() {
            return m_provider.GetIdentifierPostfix(); 
        }
    }
}
