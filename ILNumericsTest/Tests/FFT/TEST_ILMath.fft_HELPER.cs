using System;
using ILNumerics.BuiltInFunctions;
using ILNumerics.Misc;
using ILNumerics.Test;
using ILNumerics.Native;

namespace ILNumerics.Test {
    public partial class TEST_ILMath_fft_HELPER : ILMath {
        public static void forwBackwCheck1D(ILArray<double> A, ILArray<complex> Result) {
            try {
                ILArray<complex> B = fft(A);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                double errMult = Math.Pow(0.1,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (double)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<double> ResultR = ifftsym(B);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                B = ifft(B);
                if (ILMath.sumall(ILMath.abs(ILMath.tocomplex(A) - B)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
        public static void forwBackwCheck1D(ILArray<float> A, ILArray<fcomplex> Result) {
            try {
                ILArray<fcomplex> B = fft(A);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                float errMult = (float)Math.Pow(0.1f,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (float)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<float> ResultR = ifftsym(B);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                B = ifft(B);
                if (ILMath.sumall(ILMath.abs(ILMath.tofcomplex(A) - B)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }

        public static void forwBackwCheck1DAlongD(ILArray<double> A, ILArray<complex> Result, int p) {
            try {
                ILArray<complex> B = fft(A,p);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                double errMult = Math.Pow(0.1,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (double)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<double> ResultR = ifftsym(B,p);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                B = ifft(B,p);
                if (ILMath.sumall(ILMath.abs(ILMath.tocomplex(A) - B)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
        public static void forwBackwCheck1DAlongD(ILArray<float> A, ILArray<fcomplex> Result, int p) {
            try {
                ILArray<fcomplex> B = fft(A,p);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                float errMult = (float)Math.Pow(0.1f,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (float)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<float> ResultR = ifftsym(B,p);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                B = ifft(B,p);
                if (ILMath.sumall(ILMath.abs(ILMath.tofcomplex(A) - B)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }

        public static void forwBackwCheck2D(ILArray<double> A, ILArray<complex> Result) {
            try {
                ILArray<complex> B = fft2(A);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                double errMult = Math.Pow(0.1,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (double)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<double> ResultR = ifft2sym(B);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                B = ifft2(B);
                if (ILMath.sumall(ILMath.abs(ILMath.tocomplex(A) - B)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
        public static void forwBackwCheck2D(ILArray<float> A, ILArray<fcomplex> Result) {
            try {
                ILArray<fcomplex> B = fft2(A);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                float errMult = (float)Math.Pow(0.1f,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (float)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<float> ResultR = ifft2sym(B);
                if (ILMath.sumall(ILMath.abs(ResultR - A)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                B = ifft2(B);
                if (ILMath.sumall(ILMath.abs(ILMath.tofcomplex(A) - B)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }

        public static void forwBackwCheck2Dmn(ILArray<double> A, ILArray<complex> Result, ILArray<double> ResRA, ILArray<complex> ResIA, int m, int n) {
            try {
                ILArray<complex> B = fft2(A,m,n);
                int[] sizes = A.Dimensions.ToIntArray(); 
                sizes[0] = m; sizes[1] = n; 
                double errMult = Math.Pow(0.1,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (double)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (m == 0 || n == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<double> ResultR = ifft2sym(B);
                if (m == 0 || n == 0) {
                    if (!ResultR.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultR - ILMath.resize4Transform( A , sizes))) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<complex> ResultC = ifft2(tocomplex(A),m,n);
                if (m == 0 || n == 0) {
                    if (!ResultC.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResIA - ResultC)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
        public static void forwBackwCheck2Dmn(ILArray<float> A, ILArray<fcomplex> Result, ILArray<float> ResRA, ILArray<fcomplex> ResIA,  int m, int n) {
            try {
                ILArray<fcomplex> B = fft2(A,m,n);
                int[] sizes = A.Dimensions.ToIntArray(); 
                sizes[0] = m; sizes[1] = n; 
                float errMult = (float)Math.Pow(0.1f,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (float)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (m == 0 || n == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<float> ResultR = ifft2sym(B);
                if (m == 0 || n == 0) {
                    if (!ResultR.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultR - ILMath.resize4Transform( A , sizes))) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<fcomplex> ResultC = ifft2(tofcomplex(A),m,n);
                if (m == 0 || n == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultC - ResIA)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }

        public static void forwBackwCheckNDmn(ILArray<double> A, ILArray<complex> Result, ILArray<double> ResRA, ILArray<complex> ResIA, int m, int n, int q) {
            try {
                int[] sizes = A.Dimensions.ToIntArray(3); 
                sizes[0] = m; sizes[1] = n; sizes[2] = q; 
                ILArray<complex> B = fftn(A,sizes);
                
                double errMult = Math.Pow(0.1,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (double)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (m == 0 || n == 0 || q == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<double> ResultR = ifftnsym(B);
                if (m == 0 || n == 0 || q == 0) {
                    if (!ResultR.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultR - ILMath.resize4Transform( A , sizes))) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
                ILArray<complex> ResultC = ifftn(tocomplex(A),sizes);
                if (m == 0 || n == 0 || q == 0) {
                    if (!ResultC.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResIA - ResultC)) * errMult > (double)ILMath.MachineParameterDouble.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
        public static void forwBackwCheckNDmn(ILArray<float> A, ILArray<fcomplex> Result, ILArray<float> ResRA, ILArray<fcomplex> ResIA,  int m, int n, int q) {
            try {
                int[] sizes = A.Dimensions.ToIntArray(3); 
                sizes[0] = m; sizes[1] = n; sizes[2] = q; 
                ILArray<fcomplex> B = fftn(A,sizes);
                //double errMult = 1/(A.Dimensions.NumberOfElements * Math.Pow(10,A.Dimensions.NumberOfDimensions));
                float errMult = (float)Math.Pow(0.1f,A.Dimensions.NumberOfDimensions) / A.Dimensions.NumberOfElements;
                if (!A.IsScalar) 
                    errMult /= (float)A.Dimensions[A.Dimensions.FirstNonSingleton()]; 
                if (m == 0 || n == 0 || q == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (sumall(abs(subtract(Result, B))) * errMult > (double)MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<float> ResultR = ifftnsym(B);
                if (m == 0 || n == 0 || q == 0) {
                    if (!ResultR.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultR - ILMath.resize4Transform( A , sizes))) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
                ILArray<fcomplex> ResultC = ifftn(tofcomplex(A),sizes);
                if (m == 0 || n == 0 || q == 0) {
                    if (!B.IsEmpty) { throw new Exception("empty matrix should return empty!"); }
                } else if (ILMath.sumall(ILMath.abs(ResultC - ResIA)) * errMult > (double)ILMath.MachineParameterFloat.eps)
                    throw new Exception("invalid value");
            } catch (ILNumerics.Exceptions.ILArgumentException) {
                throw new Exception("unexpected exception was thrown -> error!");
            }
        }
    }
}
