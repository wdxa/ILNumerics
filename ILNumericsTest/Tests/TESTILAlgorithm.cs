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
using ILNumerics.Misc;
using ILNumerics.Test;
using ILNumerics.BuiltInFunctions;
using ILNumerics.Exceptions;
using ILNumerics.Algorithms; 
using ILDA = ILNumerics.ILArray<double>;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace ILNumerics.Test {
	public class TESTILAlgorithm : ILTest {
		
		public override void Run() {
			// tests: creation
			// =================
			Header();
            //Test_AntonTestMatrix(4,1); 
            //Test_AntonTestMatrix(40,1); 
            //Test_AntonTestMatrix(400,1); 
            //Test_AntonTestMatrix(1000,1); 
            ////Test_AntonTestMatrix(2000,1); 
            //Test_AntonTestMatrix(3000,1); 
            ////Test_AntonTestMatrix(4000,1); 
            //Test_SimpleAsyncAlgorithmSample(); 
            Test_LDA();
            Test_LDA_Performance2000_var(2); 
            int oldRefMin = ILNumerics.Settings.ILSettings.MinimumRefDimensions; 
            ILNumerics.Settings.ILSettings.MinimumRefDimensions = 3;
            Test_LDA_Performance2000_500(); 
            Test_LDA_Performance200k_10(); 
            ILNumerics.Settings.ILSettings.MinimumRefDimensions = 2;
            Test_LDA_Performance1000x2000_100();
            ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldRefMin; 
            //Test_AntonTestMatrix(4,1); 
            //Test_AntonTestMatrix(40,1); 
            //Test_AntonTestMatrix(400,1); 
            //Test_AntonTestMatrix(1000,1); 
            ////Test_AntonTestMatrix(2000,1); 
            //Test_AntonTestMatrix(3000,1); 
            ////Test_AntonTestMatrix(4000,1); 
			Footer();
		}
        //public void Test_SimpleAsyncAlgorithmSample() {
        //    int errorCode = 0; 
        //    try {
        //        SimpleAsyncSample sampleAlg = new SimpleAsyncSample(null, 2.0,50,ILMath.randn(3,2)); 
        //        sampleAlg.RunAsync(); 
        //        while (sampleAlg.State == ILAlgorithmRunningState.Running) {
        //            Info(sampleAlg.Progress * 100 + "\r"); 
        //            System.Threading.Thread.Sleep(300); 
        //        }
        //        Info(sampleAlg.Result.result.ToString()); 
        //        //sampleAlg.Result; 
        //        Success();
        //    } catch(Exception e) {
        //        Error(errorCode,e.Message);
        //    }
        //}

        
        public void Test_LDA() {
            int errorCode = 0; 
            try {
                LDA lda = new LDA();
                lda.StateChanged += new ILAlgorithmStateChangedEventHandler(lda_StateChanged);
                lda.ProgressChanged += new ILAlgorithmStateChangedEventHandler(lda_ProgressChanged);
                ILArray<double> X = new ILArray<double>(new double[]{-2,-2,-3,-3,2,2,3,3},2,4); 
                ILLogicalArray labels = new ILLogicalArray (new byte[8]{0,1,0,1,1,0,1,0},2,4); 
                LDA.Hyperplane C = lda.TrainLDA(X,labels,0.4); 
                if (Object.ReferenceEquals(C,null))
                    throw new Exception ("LDA: result is null!"); 
                if (!(C.w is ILArray<double>) || C.w.Dimensions[0] != 2)
                    throw new Exception("LDA: Results C[0] should be ILArray<double> 2x1");
                if (!(C.b is ILArray<double>) || !C.b.IsScalar)
                    throw new Exception("LDA: Results C[1] should be ILArray<double> 2x1");
                if (ILMath.abs(C.w[0] - -9.3750) > 1e-8)
                    throw new Exception("LDA: invalid result: C.w(1) should be : -9.3750");
                if (ILMath.abs(C.w[1] - -9.3750) > 1e-8)
                    throw new Exception("LDA: invalid result: C.w(2) should be : -9.3750");
                if (ILMath.abs(C.b.GetValue(0)) > 1e-8)
                    throw new Exception("LDA: invalid result: C.b should be : 0.0!");
                Success();
            } catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }

        public void Test_LDA_Performance2000_500() {
            int errorCode = 0; 
            try {
                LDA lda = new LDA();
                ILArray<double> X = ILMath.horzcat(ILMath.randn(2,2000)*2.0,ILMath.randn(2,2000)*-2.0);  
                ILLogicalArray labels = ILMath.tological(ILMath.horzcat(ILMath.ones(1,2000), ILMath.zeros(1,2000))); 
                labels = labels.Concat( ILMath.tological( ILMath.zeros(1,2000).Concat( ILMath.ones(1,2000),1)),0);  
                ILPerformer timer = new ILPerformer(); 
                LDA.Hyperplane C; 
                int rep = 500; 
                timer.Tic();  
                for (int i = 0; i < rep; i ++) {
                   C = lda.TrainLDA(X,labels,0.4);  
                }
                timer.Toc();
                Info("Test_LDA_Performance: data: 2x2000 run " + rep.ToString() + " times in: " + timer.Duration + "ms"); 
                Success();
            }catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
        public void Test_LDA_Performance1000x2000_100() {
            int errorCode = 0; 
            try {
                LDA lda = new LDA();
                ILArray<double> X = ILMath.horzcat(ILMath.randn(1000,2000)*2.0,ILMath.randn(1000,2000)*-2.0);  
                ILLogicalArray labels = ILMath.tological(ILMath.horzcat(ILMath.ones(1,2000), ILMath.zeros(1,2000))); 
                labels = labels.Concat( ILMath.tological( ILMath.zeros(1,2000).Concat( ILMath.ones(1,2000),1)),0);  
                ILPerformer timer = new ILPerformer(); 
                LDA.Hyperplane C; 
                int rep = 1; 
                timer.Tic();  
                for (int i = 0; i < rep; i ++) {
                   C = lda.TrainLDA(X,labels,0.4);  
                }
                timer.Toc();
                Info("Test_LDA_Performance: data: 1000x4000 run " + rep.ToString() + " times in: " + timer.Duration + "ms"); 
                Success();
            }catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
 
        public void Test_LDA_Performance2000_var(int rep) {
            int errorCode = 0; 
            try {
                LDA lda = new LDA();
                ILArray<double> X = ILMath.horzcat(ILMath.randn(2,2000)*2.0,ILMath.randn(2,2000)*-2.0);  
                ILLogicalArray labels = ILMath.tological(ILMath.horzcat(ILMath.ones(1,2000), ILMath.zeros(1,2000))); 
                labels = labels.Concat( ILMath.tological( ILMath.zeros(1,2000).Concat( ILMath.ones(1,2000),1)),0);  
                ILPerformer timer = new ILPerformer(); 
                LDA.Hyperplane C; 
                int oldRefMin = ILNumerics.Settings.ILSettings.MinimumRefDimensions; 
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 2;
                timer.Tic();  
                for (int i = 0; i < rep; i ++) {
                   C = lda.TrainLDA(X,labels,0.4);  
                }
                timer.Toc();
                Info("Test_LDA_Performance: with reference - data: 2x2000 run " + rep.ToString() + " times in: " + timer.Duration + "ms"); 
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = 3; 
                timer.Tic();  
                for (int i = 0; i < rep; i ++) {
                   C = lda.TrainLDA(X,labels,0.4);  
                }
                timer.Toc();
                ILNumerics.Settings.ILSettings.MinimumRefDimensions = oldRefMin; 
                Info("Test_LDA_Performance: without reference - data: 2x2000 run " + rep.ToString() + " times in: " + timer.Duration + "ms"); 
                Success();
            }catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }
 
        public void Test_LDA_Performance200k_10() {
            int errorCode = 0; 
            try {
                LDA lda = new LDA();
                ILArray<double> X = ILMath.horzcat(ILMath.randn(2,200000)*2.0,ILMath.randn(2,200000)*-2.0);  
                ILLogicalArray labels = ILMath.tological(ILMath.horzcat(ILMath.ones(1,100000), ILMath.zeros(1,100000))); 
                labels = labels.Concat( ILMath.tological( ILMath.zeros(1,100000).Concat( ILMath.ones(1,100000),1)),0);  
                ILPerformer timer = new ILPerformer(); 
                timer.Tic();  LDA.Hyperplane C; 
                for (int i = 0; i < 10; i ++) {
                   C = lda.TrainLDA(X,labels,0.4);  
                }
                timer.Toc();
                Info("Test_LDA_Performance2: data: 2x200000 run 10 times in: " + timer.Duration + "ms"); 
                Success();
            }catch(Exception e) {
                Error(errorCode,e.Message);
            }
        }

        void lda_ProgressChanged(object sender, ILAlgorithmEventArgs e) {
            Info("Got state from " + ((ILAlgorithm) sender).Name + Environment.NewLine + 
                 " " + e.Progress + " State: " + e.State); 
            if (e.Progress > 0.5) {
                e.Cancel = true;
                Info("Cancelling excecution..."); 
            }
        }

        void lda_StateChanged(object sender, ILAlgorithmEventArgs e) {
            Info("Got state from " + ((ILAlgorithm) sender).Name + Environment.NewLine + 
                 " " + e.Progress + " State: " + e.State); 
        }
	}
}
