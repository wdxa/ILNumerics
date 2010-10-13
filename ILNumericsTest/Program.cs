// $Id: Program.cs 690 2009-05-05 22:07:59Z ho $
using System;
using System.Globalization; 
using System.Collections.Generic;
using System.Text;
using ILNumerics.Test;
using ILNumerics.Misc; 
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Exceptions;
using ILNumerics.Native;  

namespace ILNumerics.Test {
	class Program : ILNumerics.Algorithms.ILAlgorithm {
        // (Un)comment needed or not needed tests!
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args) {
        	Console.Out.Write(Info());
            
            new TESTQuickSort().Run(); 

            #region manual test invocation list
            //new TEST_ILMath_max_double().Run(); 
            //new TEST_ILMath_max_single().Run(); 
            //new TEST_ILMath_max_complex().Run(); 
            //new TEST_ILMath_max_fcomplex().Run(); 
            //new TEST_ILMath_max_int().Run(); 
            //new TEST_ILMath_max_uint().Run(); 
            //new TEST_ILMath_max_short().Run(); 
            //new TEST_ILMath_max_ushort().Run(); 
            //new TEST_ILMath_max_char().Run(); 
            //new TEST_ILMath_max_byte().Run(); 

            //new TEST_ILMath_maxdim_double().Run(); 
            //new TEST_ILMath_maxdim_single().Run(); 
            //new TEST_ILMath_maxdim_complex().Run(); 
            //new TEST_ILMath_maxdim_fcomplex().Run(); 
            //new TEST_ILMath_maxdim_int().Run(); 
            //new TEST_ILMath_maxdim_uint().Run(); 
            //new TEST_ILMath_maxdim_short().Run(); 
            //new TEST_ILMath_maxdim_ushort().Run(); 
            //new TEST_ILMath_maxdim_char().Run(); 
            //new TEST_ILMath_maxdim_byte().Run(); 

            //new TEST_ILMath_maxdim2_double().Run(); 
            //new TEST_ILMath_maxdim2_single().Run(); 
            //new TEST_ILMath_maxdim2_complex().Run(); 
            //new TEST_ILMath_maxdim2_fcomplex().Run(); 
            //new TEST_ILMath_maxdim2_int().Run(); 
            //new TEST_ILMath_maxdim2_uint().Run(); 
            //new TEST_ILMath_maxdim2_short().Run(); 
            //new TEST_ILMath_maxdim2_ushort().Run(); 
            //new TEST_ILMath_maxdim2_char().Run(); 
            //new TEST_ILMath_maxdim2_byte().Run(); 

            //new TEST_ILMath_min_double().Run(); 
            //new TEST_ILMath_min_single().Run(); 
            //new TEST_ILMath_min_complex().Run(); 
            //new TEST_ILMath_min_fcomplex().Run(); 
            //new TEST_ILMath_min_int().Run(); 
            //new TEST_ILMath_min_uint().Run(); 
            //new TEST_ILMath_min_short().Run(); 
            //new TEST_ILMath_min_ushort().Run(); 
            //new TEST_ILMath_min_byte().Run(); 
            //new TEST_ILMath_min_char().Run(); 

            //new TEST_ILMath_mindim_double().Run(); 
            //new TEST_ILMath_mindim_single().Run(); 
            //new TEST_ILMath_mindim_complex().Run(); 
            //new TEST_ILMath_mindim_fcomplex().Run(); 
            //new TEST_ILMath_mindim_int().Run();
            //new TEST_ILMath_mindim_uint().Run();
            //new TEST_ILMath_mindim_short().Run();
            //new TEST_ILMath_mindim_ushort().Run();
            //new TEST_ILMath_mindim_char().Run();
            //new TEST_ILMath_mindim_byte().Run();
 
            //new TEST_ILMath_mindim2_double().Run(); 
            //new TEST_ILMath_mindim2_single().Run(); 
            //new TEST_ILMath_mindim2_complex().Run(); 
            //new TEST_ILMath_mindim2_fcomplex().Run(); 
            //new TEST_ILMath_mindim2_int().Run(); 
            //new TEST_ILMath_mindim2_uint().Run(); 
            //new TEST_ILMath_mindim2_short().Run(); 
            //new TEST_ILMath_mindim2_ushort().Run(); 
            //new TEST_ILMath_mindim2_char().Run(); 
            //new TEST_ILMath_mindim2_byte().Run(); 
            #endregion

            ILTestRunnerReflection runner = new ILTestRunnerReflection(); 
            runner.RunAll("TEST_ILMath"); 

            IILLapack oldLapack = Lapack; 
            Lapack = new ILLapackMKL10_0(); 
            new TESTILLapack().Run();
            
            Lapack = new ILLapackGeneric(); 
            new TESTILLapack().Run();
            Lapack = new ILACML4_1(); 
            new TESTILLapack().Run();
            Lapack = oldLapack;
            
            new TESTILComplex().Run(); 
            new TESTILMemoryPool().Run(); 

            new TESTILStorage().Run();
            new TESTILMatFile().Run();
            new TESTILCell().Run();
            new TESTBucketSort().Run();
            new TESTILAlgorithm().Run();
            new TESTILNumericArray().Run();
            new TESTLogical().Run(); 
            new TESTILDimension().Run(); 
            
            new TESTILArray().Run();
            new TESTILMath().Run();
            new TESTILFFT().Run(); 

            Console.Out.WriteLine("Done.");
			Console.In.ReadLine();
		}
        
        
        private static string Info() {
        	StringBuilder s = new StringBuilder(); 
        	s.Append("This is the general test routine for ILNumerics.Net" + Environment.NewLine); 
        	s.Append("" + Environment.OSVersion + ", "); 
        	s.Append("Number of proc: " + Environment.ProcessorCount + ", "+ Environment.NewLine); 
        	s.Append("CLR: " + Environment.Version + ", "); 
        	s.Append("Proc.memory: " + Environment.WorkingSet + ""+ Environment.NewLine);
            ILMath.rand(1); 
            ILCPUID cpuid = new ILCPUID(); 
            s.Append(String.Format("CPUID:{0}",cpuid.ToString())); 
        	return s.ToString();  
        }

        /// <summary>
        /// compute esnesnon34 - conv implace
        /// </summary>
        /// <param name="A">reliability convolution sum</param>
        /// <param name="B">process integration factors</param>
        /// <returns>MaxConv34 weights as interop solution</returns>
        /// <remarks>A &amp; B must have the same size</remarks>
        public static ILArray<double> MaxConv34 (ILArray<double> A, ILArray<double> B) {
            if (!B.Dimensions.IsSameSize(A.Dimensions) ) 
                throw new ILArgumentException("Input argument B must have the same size as A!");
            ILArray<double> ret = zeros(A.Dimensions); 
            ret = eigSymm(B);
            ret += repmat(B[null,0],4,A.Dimensions[1]);
            ret = diag(diag(ret) * exp(A["end;:"]));
            return ret;
        }
	}
}
