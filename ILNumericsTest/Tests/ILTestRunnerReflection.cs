using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection; 
using System.IO; 

namespace ILNumerics.Test {
    public class ILTestRunnerReflection {
    
        public ILTestRunnerReflection() {
        }
        public List<Type> LoadAllTestCaseNames(string startingWith) {
            Assembly ass = Assembly.GetCallingAssembly(); 
            Type[] types = ass.GetTypes(); 
            List<Type> ret = new List<Type>(); 
            foreach (Type type in types) {
                object[] attr = type.GetCustomAttributes(false); 
                bool found = false; 
                foreach (object at in attr) {
                    if (at is ILTestAutoCreateAttribute) {
                        found = true; 
                        break; 
                    }
                }
                if (!found) continue; 
                if (type.Name.StartsWith(startingWith)) 
                    ret.Add(type); 
            }
            return ret; 
        }

        public void RunAll(string patternStartsWith) {
            List<Type> names = LoadAllTestCaseNames(patternStartsWith); 
            foreach (Type caseType in names) {
                ILTest caseTest = (ILTest)caseType.InvokeMember(
                        caseType.Name,BindingFlags.CreateInstance,null,null,null); 
                if (caseTest != null) {
                    caseTest.Run(); 
                }
            }
            
        }
    }
}
