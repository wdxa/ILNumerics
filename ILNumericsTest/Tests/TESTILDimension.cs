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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ILNumerics.Test {
	public class TESTILDimension : ILTest {

		public override void Run() {
			Header();
            Test_Squeeze(); 
            Footer();
		}

        private void Test_Squeeze() {
            int errorCode = 0; 
            try {
                ILDimension dim = new ILDimension(0,1,1,2); 
                ILDimension result = dim.Squeeze(); 
                if (result.NonSingletonDimensions != 1) 
                    throw new Exception("Squeeze failed"); 
                if (result.NumberOfDimensions != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[0] != 0) 
                    throw new Exception("Squeeze failed"); 
                if (result[1] != 2) 
                    throw new Exception("Squeeze failed"); 
                dim = new ILDimension(1,0,2,1);
                result = dim.Squeeze(); 
                if (result.NumberOfDimensions != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[0] != 0) 
                    throw new Exception("Squeeze failed"); 
                if (result[1] != 2) 
                    throw new Exception("Squeeze failed"); 
                dim = new ILDimension(2,1,2,1,2,3,3,1);
                result = dim.Squeeze(); 
                if (result.NumberOfDimensions != 5) 
                    throw new Exception("Squeeze failed"); 
                if (result[0] != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[1] != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[2] != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[3] != 3) 
                    throw new Exception("Squeeze failed"); 
                if (result[4] != 3) 
                    throw new Exception("Squeeze failed"); 
                dim = new ILDimension(0); 
                result = dim.Squeeze();
                if (result.NumberOfDimensions != 2) 
                    throw new Exception("Squeeze failed"); 
                if (result[0] != 0) 
                    throw new Exception("Squeeze failed"); 
                if (result[1] != 1) 
                    throw new Exception("Squeeze failed"); 
                Success();
			} catch (Exception e) {
				Error(errorCode ,e.Message);
			}
        }
	}
}
