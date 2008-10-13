using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Test;
using ILNumerics.BuiltInFunctions; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ILNumerics.Data; 

namespace ILNumerics.Test {
	public class TESTILBinTreeNode : ILTest {

		public override void Run() {
			Header();
            Test_Create(); 
            Footer();
		}
        public void Test_Create() {
            int errorCode = 0; 
            try {
				ILBinTreeNode<int> root = new ILBinTreeNode<int>(1);
                root.LeftSon = new ILBinTreeNode<int>(2); 
                root.RightSon = new ILBinTreeNode<int>(3); 
                root.LeftSon.LeftSon = new ILBinTreeNode<int>(4); 
                root.LeftSon.RightSon = new ILBinTreeNode<int>(5); 
                Console.Out.Write(root.ToString());
                if (root.Height() != 2) throw new Exception("invalid heigth detected"); 
                if (root.LeftSon.Height() != 1) throw new Exception("invalid heigth detected"); 
                if (root.RightSon.Height() != 0) throw new Exception("invalid heigth detected"); 
                if (root.LeftSon.RightSon.Height() != 0) throw new Exception("invalid heigth detected"); 

			} catch (Exception e) {
				Error(errorCode ,e.Message);
			}
		}

	}
}
