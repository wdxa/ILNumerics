#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.BuiltInFunctions;
using ILNumerics.Misc;
using ILNumerics.Test;
using ILNumerics.Exceptions; 
using ILDA = ILNumerics.ILArray<double>;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
 

namespace ILNumerics.Test {
    /// <summary>
    /// Ttest class for ILMatFile
    /// </summary>
	public class TESTILMatFile : ILTest {
        /// <summary>
        /// run all tests for ILMatFile
        /// </summary>
        public override void Run() {
			 // tests: creation
			// =================
			Header();
            Test_TestMatlab(); 
            Test_StreamMatlab("testarray1.mat",ILMath.empty()); 
            Test_StreamMatlab("testarray1.mat",ILMath.ones(1,1)); 
            Test_StreamMatlab("testarray1.mat",ILMath.rand(10,1)); 
            Test_StreamMatlab("testarray1.mat",ILMath.rand(1,10)); 
            Test_StreamMatlab("testarray1.mat",ILMath.rand(0,1)); 
            Test_StreamMatlab("testarray1.mat",ILMath.rand(10,100,4)); 

            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.ones(1,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.rand(1,10))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.rand(0,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tosingle(ILMath.rand(10,100,4)));
 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.ones(1,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.rand(1,10))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.rand(0,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tological(ILMath.rand(10,100,4))); 

            Test_StreamMatlab("testarray1.mat",new ILArray<complex>(new complex[]{new complex(1.0,2.0)})); 
            Test_StreamMatlab("testarray1.mat",ILMath.tocomplex(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tocomplex(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tocomplex(ILMath.rand(1,10))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tocomplex(ILMath.rand(0,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tocomplex(ILMath.rand(10,100,4))); 

            Test_StreamMatlab("testarray1.mat",new ILArray<fcomplex>(new fcomplex[]{new fcomplex(1.0f,2.0f)})); 
            Test_StreamMatlab("testarray1.mat",ILMath.tofcomplex(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tofcomplex(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tofcomplex(ILMath.rand(1,10))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tofcomplex(ILMath.rand(0,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tofcomplex(ILMath.rand(10,100,4))); 

            Test_StreamMatlab("testarray1.mat",new ILArray<char>(new char[]{'A','B','F'})); 
            Test_StreamMatlab("testarray1.mat",new ILArray<char>(new char[]{'A','B','F'}).T); 
            Test_StreamMatlab("testarray1.mat",ILMath.tochar(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tochar(ILMath.rand(10,1)*250)); 
            Test_StreamMatlab("testarray1.mat",ILMath.tochar(ILMath.rand(1,10)*250)); 
            Test_StreamMatlab("testarray1.mat",ILMath.tochar(ILMath.rand(0,1)*250)); 
            Test_StreamMatlab("testarray1.mat",ILMath.tochar(ILMath.rand(10,100,4)*250)); 

            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.ones(1,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.rand(1,10) * 255)); 
            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.rand(0,1) * 255)); 
            Test_StreamMatlab("testarray1.mat",ILMath.tobyte(ILMath.rand(10,100,4) * 255)); 

            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.ones(1,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.empty())* 16000); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.rand(10,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.rand(1,10)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.rand(0,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint16(ILMath.rand(10,100,4)* 16000));
 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.ones(1,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.empty()* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.rand(10,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.rand(1,10)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.rand(0,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.toint32(ILMath.rand(10,100,4)* 16000)); 
 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.ones(1,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.empty()* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.rand(10,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.rand(1,10)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.rand(0,1)* 16000)); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint16(ILMath.rand(10,100,4)* 16000)); 
 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.ones(1,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.empty())); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.rand(10,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.rand(1,10))); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.rand(0,1))); 
            Test_StreamMatlab("testarray1.mat",ILMath.touint32(ILMath.rand(10,100,4))); 
            Test_ImportMatlab2();
            Test_ImportMatlab();
			Test_NameRestrictions(); 
            // summary
			Footer();
		} 
        public void Test_NameRestrictions () {
            int errorCode = 0; 
            try {
                ILMatFile ml = new ILMatFile();
                ILArray<double> A = ILMath.rand(3,23,2); 
                ml["hallo"] = A; 
                ILBaseArray res = ml["hallo"]; 
                if (!res.Equals(A))
                    throw new Exception("invalid array returned for : 'hallo'");
                try {
                    ml[""] = A+1;
                    throw new Exception("empty names are not allowed!"); 
                } catch (ILArgumentException ) {
                    Info("empty name signaled correctly"); 
                }   
                try {
                    ml["1fsdf"] = A+1;
                    throw new Exception("names starting with numbers are not allowed!"); 
                } catch (ILArgumentException ) {
                    Info("names starting with numbers signaled correctly"); 
                }  
                try {
                    ml["invaldi name"] = A+1;
                    throw new Exception("names with blank space are not allowed!"); 
                } catch (ILArgumentException ) {
                    Info("names with blank space signaled correctly"); 
                }  
                try {
                    ml["a$me"] = A+1;
                    throw new Exception("names with invalid characters are not allowed!"); 
                } catch (ILArgumentException e) {
                    Info("names with invalid characters signaled correctly"); 
                }  
                try {
                    A = (ILArray<double>)ml["hallo_"];
                    throw new Exception("key not found expected"); 
                } catch (ILArgumentException e) {
                    Info("missing key signaled correctly"); 
                } 
                errorCode = 2; 
                ml["hallo"] = null; 
                if (ml.Arrays.Length != 0)
                    throw new Exception("unable to remove array from MatFile");
                Success(); 
            } catch (Exception e) {
                Error(errorCode,e.Message); 
            }
        }
        public void Test_StreamMatlab(string filename, ILBaseArray arr) {
            int errorCode = 0;
            try {
                using (FileStream s = new FileStream(filename,FileMode.Create)) {
                    arr.ToStream(s,"",ILArrayStreamSerializationFlags.Matlab);    
                }
                // test -> read back 
                ILMatFile inp = new ILMatFile(filename); 
                if (inp.Arrays.Length != 1)
                    throw new Exception("invalid number of arrays after read back from matfile!");
                ILBaseArray reread = inp.Arrays[0]; 
                if (!reread.Equals (arr)) 
                    throw new Exception("invalid values after re-reading from mat file!");
                string msg = ""; 
                if (arr.GetType().GetGenericArguments().Length > 0)
                    msg = "<" + arr.GetType().GetGenericArguments()[0].Name + "> " + arr.Dimensions.ToString(); 
                else if (arr is ILLogicalArray)
                    msg = "<logical> " + arr.Dimensions.ToString(); 
                else 
                    msg = "<???l> " + arr.Dimensions.ToString(); 
                Success(msg);
            } catch (Exception e) {
                Error(errorCode, e.Message);
            }
        }
        public void Test_ImportMatlab() {
            int errorCode = 0;
            try {
                ILMatFile matFile = new ILMatFile("MATLAB_2ArrTest.mat"); 
                ILBaseArray [] arraysFromMatFile =  matFile.Arrays; 
                if (arraysFromMatFile.Length != 2)
                    throw new Exception("Test_ImportMatlab failed: invalid number of arrays returned."); 
                if (arraysFromMatFile[0].Dimensions.NumberOfElements != 100)
                    throw new Exception("Test_ImportMatlab failed: invalid size of first array returned.");
                if (arraysFromMatFile[1].Dimensions.NumberOfElements != 12)
                    throw new Exception("Test_ImportMatlab failed: invalid size of 2. array returned.");
                Success("Test_ImportMatlab successfull.");
            } catch (Exception e) {
                Error("Test_ImportMatlab failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_TestMatlab() {
            int errorCode = 0;
            try {
                ILMatFile matFile = new ILMatFile("test_matfile.mat"); 
                ILBaseArray [] arraysFromMatFile =  matFile.Arrays; 
                if (arraysFromMatFile.Length != 2)
                    throw new Exception("Test_ImportMatlab failed: invalid number of arrays returned."); 
                if (arraysFromMatFile[0].Dimensions.NumberOfElements != 100)
                    throw new Exception("Test_ImportMatlab failed: invalid size of first array returned.");
                if (arraysFromMatFile[1].Dimensions.NumberOfElements != 12)
                    throw new Exception("Test_ImportMatlab failed: invalid size of 2. array returned.");
                Success("Test_ImportMatlab successfull.");
            } catch (Exception e) {
                Error("Test_ImportMatlab failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
        public void Test_ImportMatlab2() {
            int errorCode = 0;
            try {
                ILMatFile matFile = new ILMatFile(@"C:\inst\TD_evidence_regression.mat"); 
                ILBaseArray [] arraysFromMatFile =  matFile.Arrays; 
                matFile = new ILMatFile(@"C:\inst\test-v6.mat"); 
                arraysFromMatFile =  matFile.Arrays; 
                Success("Test_ImportMatlab successfull.");
            } catch (Exception e) {
                Error("Test_ImportMatlab failed on ErrorCode: " + errorCode + "due: " + e.Message);
            }
        }
	}
}
