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
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Misc; 
using ILNumerics.Native;  

namespace ILNumerics.Test {
    public class TESTILFFT : ILTest {

        public override void Run() {
            base.Run();
			Header();
            try {
                IILFFT oldFFT = ILMath.FFT; 

                IILFFT fft = new ILFFTW3FFT(); 
                TEST_IILFFT_double_complex.TEST_ALL(fft);
                TEST_IILFFT_complex_complex.TEST_ALL(fft); 
                TEST_IILFFT_fcomplex_fcomplex.TEST_ALL(fft);
                TEST_IILFFT_float_fcomplex.TEST_ALL(fft); 
                ILMath.FFT = fft; 
                TEST_ILMath_fft_A.TEST_ALL(); 
                TEST_ILMath_fft_ADim.TEST_ALL();
                TEST_ILMath_fft2_A.TEST_ALL();
                TEST_ILMath_fft2_Amn.TEST_ALL();
                TEST_ILMath_fftN_Amn.TEST_ALL(); 
     

                fft = new ILMKLFFT(); 
                TEST_IILFFT_double_complex.TEST_ALL(fft); 
                TEST_IILFFT_complex_complex.TEST_ALL(fft); 
                TEST_IILFFT_fcomplex_fcomplex.TEST_ALL(fft);
                TEST_IILFFT_float_fcomplex.TEST_ALL(fft); 
                ILMath.FFT = fft; 
                TEST_ILMath_fft_A.TEST_ALL(); 
                TEST_ILMath_fft_ADim.TEST_ALL();
                TEST_ILMath_fft2_A.TEST_ALL();
                TEST_ILMath_fft2_Amn.TEST_ALL();
                TEST_ILMath_fftN_Amn.TEST_ALL(); 


                fft = new ILACMLFFT(); 
                TEST_IILFFT_double_complex.TEST_ALL(fft); 
                TEST_IILFFT_complex_complex.TEST_ALL(fft); 
                TEST_IILFFT_fcomplex_fcomplex.TEST_ALL(fft);
                TEST_IILFFT_float_fcomplex.TEST_ALL(fft); 
                ILMath.FFT = fft; 
                TEST_ILMath_fft_A.TEST_ALL(); 
                TEST_ILMath_fft_ADim.TEST_ALL();
                TEST_ILMath_fft2_A.TEST_ALL();
                TEST_ILMath_fft2_Amn.TEST_ALL();
                TEST_ILMath_fftN_Amn.TEST_ALL(); 

            } catch (Exception e) {
                Error("FFT Test failed: " + e.Message); 
            }   
            Footer();
        }
    }
}
