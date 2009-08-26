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

namespace ILNumerics.Exceptions
{
	/// <summary>
	/// generic exception, base class for all exceptions thrown by ILNumerics.Net
	/// </summary>
	public class ILException : System.Exception
	{
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILException(String message) : base(message) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILException(String message, Exception innerException) 
                : base(message, innerException) { }
	}
    /// <summary>
    /// Base class for mathematical exceptions. Needed e.g. in interpreter for propoer error
    /// messages
    /// </summary>
    public class ILMathException : ILException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILMathException(String message) : base(message) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILMathException(String message, Exception innerException) 
                : base(message, innerException) { }
    }

    /// <summary>
    /// One of the most common exceptions: The matrix sizes do not match
    /// </summary>
    public class ILDimensionMismatchException : ILMathException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ILDimensionMismatchException() : base("Matrix dimensions must match") { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILDimensionMismatchException(String message, Exception innerException) 
                : base(message, innerException) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILDimensionMismatchException(string message) : base(message) { }
    }

    /// <summary>
    /// something was wrong with the arguments overgiven 
    /// </summary>
    public class ILArgumentException : ILException {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILArgumentException(String message)
            : base(message) {}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILArgumentException(String message, Exception innerException) 
                : base(message, innerException) { }
    }
    /// <summary>
    /// a function was called with the wrong number of arguments
    /// </summary>
    public class ILArgumentNumberException : ILArgumentException {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILArgumentNumberException(String message)
            : base(message) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILArgumentNumberException(String message, Exception innerException)
            : base(message, innerException) { }
    }
    /// <summary>
    /// a function argument has the wrong size
    /// </summary>
    public class ILArgumentSizeException : ILArgumentException {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILArgumentSizeException(String message)
            : base(message) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILArgumentSizeException(String message, Exception innerException)
            : base(message, innerException) { }
    }
    /// <summary>
    /// a function was called with a wrong argument type
    /// </summary>
    /// <remarks>this exception might be thrown if the size or inner 
    /// type of a argument is invalid. (f.e. matrix expected, but 3D array found)
    /// </remarks>
    public class ILArgumentTypeException : ILArgumentException {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILArgumentTypeException(String message)
            : base(message) {}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
         public ILArgumentTypeException(String message, Exception innerException) 
                : base(message, innerException) { }
    }
    
    /// <summary>
    /// a request could not be completed due to not enough memory available
    /// </summary>
    public class ILMemoryException : ILException {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILMemoryException(String message)
            : base(message) {}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILMemoryException(String message, Exception innerException) 
                : base(message, innerException) { }
    }
    /// <summary>
    /// Thrown on illigal casts 
    /// </summary>
    public class ILCastException : ILException
    {
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="message">aditional message to be included into the exception</param>
        public ILCastException(String message)
            : base(message) { }
        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="message">aditional message to be included into the exception</param>
        /// <param name="innerException">on cascaded exception handling, the exception catched before</param>
        public ILCastException(String message, Exception innerException)
            : base(message, innerException) { }
    }
    /// <summary>
    /// ILOutputException, thrown if an I/O attempt fails
    /// </summary>
    public class ILOutputException : ILException
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILOutputException(String message)
            : base(message) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILOutputException(String message, Exception innerException)
            : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown if an operation could not completed
    /// </summary>
    public class ILInvalidOperationException : ILException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        public ILInvalidOperationException(String message)
            : base(message) {}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">additional message to be included</param>
        /// <param name="innerException">inner Exception</param>
        public ILInvalidOperationException(String message, Exception innerException) 
                : base(message, innerException) { }
    }

    /// <summary>
    /// Exception thrown if an unimplemented part of ILManagedLapack is called
    /// </summary>
    public class ILManagedLapackNotDoneException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">LAPACK routine where error is found</param>
        public ILManagedLapackNotDoneException(String routineName)
            : base("Routine " + routineName + " Is still under construction. You may need to use a native version of LAPACK instead. " +
            "Specifiy with ILNumericsLight.dll.config.") { }
    }

    /// <summary>
    /// Exception thrown if an unimplemented part of ILManagedFFT is called
    /// </summary>
    public class ILManagedFFTNotDoneException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">FFT routine where error is found</param>
        public ILManagedFFTNotDoneException(String routineName)
            : base("Routine " + routineName + " Is still under construction. You may need to use a native version of FFT instead. " +
            "Specifiy with ILNumericsLight.dll.config.") { }
    }
}
