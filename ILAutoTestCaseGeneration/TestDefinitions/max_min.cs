using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics; 

namespace ILAutoTestCaseGeneration.TestDefinitions {
    internal class max_min : ILTestCaseBase {

        public max_min(ILTestAutoGenerator generator) : base (generator) {
            ArrayProviders.Add("double",new ILTestProviderDouble()); 
            ArrayProviders.Add("float",new ILTestProviderSingle()); 
            ArrayProviders.Add("complex",new ILTestProviderComplex()); 
            ArrayProviders.Add("fcomplex",new ILTestProviderFComplex()); 
            ArrayProviders.Add("int16",new ILTestProviderInt16()); 
            ArrayProviders.Add("int32",new ILTestProviderInt32()); 
            ArrayProviders.Add("uint16",new ILTestProviderUInt16()); 
            ArrayProviders.Add("uint32",new ILTestProviderUInt32()); 
           
            //Matlab produces results of type double on max(char) 
            //arrayProviders.Add("char",new ILTestProviderChar()); 
            ArrayProviders.Add("byte",new ILTestProviderByte()); 
            int count = 0; 
            #region TEST R = max(A)
            #region create overrides (since even ML is not perfect! ;) )
            // here: max should really ignore NaNs in complex array! (Matlab [Rel. 13] does not)
            List<ILResultOverride> overrides = new List<ILResultOverride>(); 
            ILCell correctResultComplex = new ILCell(1,1); 
            correctResultComplex[0,0] = new ILArray<complex>(new complex[]{new complex(double.NegativeInfinity,double.PositiveInfinity)}); 
            ILCell input2override = new ILCell(1,1); 
            input2override[0,0] = ArrayProviders["complex"].GenerateTestArrays()[44,null]; 
            overrides.Add(new ILResultOverride(ArrayProviders["complex"],input2override,correctResultComplex)); 

            ILCell correctResultFcomplex = new ILCell(1,1);
            correctResultFcomplex[0,0] = new ILArray<fcomplex>(new fcomplex[]{new fcomplex(float.NegativeInfinity,float.PositiveInfinity)}); 
            input2override = new ILCell(1,1); 
            input2override[0,0] = ArrayProviders["fcomplex"].GenerateTestArrays()[44,null]; 
            overrides.Add(new ILResultOverride(ArrayProviders["fcomplex"],input2override,correctResultFcomplex)); 
            #endregion
            ILTestCaseDefinition testCaseDef = new ILTestCaseDefinition("TEST_ILMath_max","[{1}] = max({0});", "{1}=ILMath.max({0});", 1, 1,overrides); 
            generator.RelativeTestCasePath = "max" + (count++).ToString("d4"); 
            CaseDefinitions.Add(testCaseDef);
            #endregion


            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim","[{1}] = max({0},[],1);", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1,overrides)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim2","[{1}] = max({0},[],2);", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            Run(false,true); 

            #region TEST min
            generator.RelativeTestCasePath = "min" + (count++).ToString("d4"); 
            overrides = new List<ILResultOverride>(); 
            correctResultComplex = new ILCell(1,1); 
            correctResultComplex[0] = new ILArray<complex>(new complex[] {new complex(0,0)}); 
            input2override = new ILCell(1,1); 
            input2override[0] = ArrayProviders["complex"].GenerateTestArrays()[44,null];
            ILResultOverride overrideMinComplexNan = new ILResultOverride(
                ArrayProviders["complex"],  
                input2override,
                correctResultComplex); 
            overrides.Add(overrideMinComplexNan);
 
            correctResultFcomplex = new ILCell(1,1); 
            correctResultFcomplex[0] = new ILArray<fcomplex>(new fcomplex[]{new fcomplex(0,0)});
            input2override = new ILCell(1,1);
            input2override[0] = ArrayProviders["fcomplex"].GenerateTestArrays()[44,null];
            ILResultOverride overrideMinFComplexNan = new ILResultOverride(
                ArrayProviders["fcomplex"],  
                input2override,
                correctResultFcomplex); 
            overrides.Add(overrideMinFComplexNan);

            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_min","[{1}] = min({0});", "{1}=ILMath.min({0});", 1, 1,overrides));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim","[{1}] = min({0},[],1);", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1,overrides)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim2","[{1}] = min({0},[],2);", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            Run(true,true); 
            #endregion
 
            /////////////////////////// char ////////////////////////////////////
            /* the problem: matlab R13 max() function returns double class on char input, also -v6 is buggy by
             * not storing char as uint16 but as uint8 */
            generator.RelativeTestCasePath = "maxmin32_char" + (count++).ToString("d4"); 
            ArrayProviders.Add("int",new ILTestProviderUInt32MaxChar()); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_max","[{1}] = max({0});", "{1}=ILMath.touint32(ILMath.max(ILMath.tochar({0})));", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim","[{1}] = max({0},[],1);", "{1}=ILMath.touint32(ILMath.max(ILMath.tochar({0}),ref NULL_INPUT_DOUBLE, 0));", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim2","[{1}] = max({0},[],2);", "{1}=ILMath.touint32(ILMath.max(ILMath.tochar({0}),ref NULL_INPUT_DOUBLE, 1));", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_min","[{1}] = min({0});", "{1}=ILMath.touint32(ILMath.min(ILMath.tochar({0})));", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim","[{1}] = min({0},[],1);", "{1}=ILMath.touint32(ILMath.min(ILMath.tochar({0}),ref NULL_INPUT_DOUBLE, 0));", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim2","[{1}] = min({0},[],2);", "{1}=ILMath.touint32(ILMath.min(ILMath.tochar({0}),ref NULL_INPUT_DOUBLE, 1));", 1, 1));
            Run(true,true); 

            /////////////////////////// char ////////////////////////////////////
            /* problem: matlab max() function does not support 64bit integer data types.
             * so we first (in Matlab) convert to int32, do max than and convert back for storage. */
            generator.RelativeTestCasePath = "maxmin64_64" + (count++).ToString("d4"); 
            ArrayProviders.Add("int64",new ILTestProviderInt64MaxInt64()); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_max","[{1}] = int64(max(int32({0})));", "{1}=ILMath.max({0});", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim","[{1}] = int64(max(int32({0}),[],1));", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim2","[{1}] = int64(max(int32({0}),[],2));", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_min","[{1}] = int64(min(int32({0})));", "{1}=ILMath.min({0});", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim","[{1}] = int64(min(int32({0}),[],1));", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim2","[{1}] = int64(min(int32({0}),[],2));", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            Run(true,true); 
            
            generator.RelativeTestCasePath = "maxmin64_32" + (count++).ToString("d4"); 
            ArrayProviders.Add("uint64",new ILTestProviderUInt64MaxUInt32()); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_max","[{1}] = uint64(max(uint32({0})));", "{1}=ILMath.max({0});", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim","[{1}] = uint64(max(uint32({0}),[],1));", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_maxdim2","[{1}] = uint64(max(uint32({0}),[],2));", "{1}=ILMath.max({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_min","[{1}] = uint64(min(uint32({0})));", "{1}=ILMath.min({0});", 1, 1));
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim","[{1}] = uint64(min(uint32({0}),[],1));", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 0);", 1, 1)); 
            CaseDefinitions.Add(new ILTestCaseDefinition("TEST_ILMath_mindim2","[{1}] = uint64(min(uint32({0}),[],2));", "{1}=ILMath.min({0},ref NULL_INPUT_DOUBLE, 1);", 1, 1));
            Run(true,true); 
        }
    }
}
