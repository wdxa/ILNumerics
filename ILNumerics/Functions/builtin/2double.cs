//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using de.idalab.ILLibrary.Storage;
using de.idalab.ILLibrary.Misc;
using de.idalab.ILLibrary.Exceptions;
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
</type>
</hycalper>
 */

namespace de.idalab.ILLibrary.BuiltInFunctions  {
    public partial class ILMath {
        #region HYCALPER LOOPSTART
        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double (/*!HC:inCls1*/ ILArray<float> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator</*!HC:inArr1*/ double > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex (/*!HC:inCls1*/ ILArray<double> real,/*!HC:inCls1*/ ILArray<double> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator</*!HC:inArr1*/ double > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator</*!HC:inArr1*/ double > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        #endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<byte> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< byte > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<byte> real, ILArray<byte> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< byte > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< byte > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<char> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< char > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<char> real, ILArray<char> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< char > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< char > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<UInt64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< UInt64 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<UInt64> real, ILArray<UInt64> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< UInt64 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< UInt64 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<UInt32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< UInt32 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<UInt32> real, ILArray<UInt32> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< UInt32 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< UInt32 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<UInt16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< UInt16 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<UInt16> real, ILArray<UInt16> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< UInt16 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< UInt16 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<Int64> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< Int64 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<Int64> real, ILArray<Int64> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< Int64 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< Int64 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<Int32> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< Int32 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<Int32> real, ILArray<Int32> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< Int32 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< Int32 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<Int16> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< Int16 > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<Int16> real, ILArray<Int16> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< Int16 > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< Int16 > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }

        /// <summary>
        /// convert real array to complex array
        /// </summary>
        /// <param name="X">complex input array</param>
        /// <returns>real part of complex array</returns>
        /// <remarks> the newly created array will have a imaginary part of zero.</remarks>
        public static ILArray<double> double ( ILArray<float> X) {
            int nrX = X.m_dimensions.NumberOfElements; 
            double [] retArr = new double [nrX]; 
            ILArray<double> ret = new ILArray<complex> (retArr,X.m_dimensions); 
            ILIterator< float > it = X.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i] = new  complex ((double) it.Increment(),(double) 0.0); 
            }
            return ret; 
        }
        /// <summary>
        /// create complex array out of real and imaginary part
        /// </summary>
        /// <param name="real">real array for real part</param>
        /// <param name="imag">real array for imaginary part</param>
        /// <returns>complex array having the real- and part imaginary parts constructed out of 
        /// real and imag.</returns>
        /// <remarks>real and imag must have the same number of elements.
        /// The array returned will be the same size as real.</remarks>
        public static ILArray<complex> real2complex ( ILArray<float> real, ILArray<float> imag) {
            int nrX = real.m_dimensions.NumberOfElements; 
            if (nrX != imag.m_dimensions.NumberOfElements)
                    throw new ILArgumentSizeException("real2complex: size of real and imag input arrays must match!"); 
            complex [] retArr = new complex [nrX]; 
            ILArray<complex> ret = new ILArray<complex> (retArr,real.m_dimensions); 
            ILIterator< float > itR = real.CreateIterator(ILIteratorPositions.ILEnd,0); 
            ILIterator< float > itI = imag.CreateIterator(ILIteratorPositions.ILEnd,0); 
            for (int i= 0; i < nrX; i++) {
                retArr[i].real =  (double) itR.Increment();
                retArr[i].imag =  (double) itI.Increment(); 
            }
            return ret; 
        }


#endregion HYCALPER AUTO GENERATED CODE
    }

}
