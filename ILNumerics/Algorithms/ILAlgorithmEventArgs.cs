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
using ILNumerics.Exceptions; 

namespace ILNumerics.Algorithms {
    /// <summary>
    /// Information arguments for events to be fired from within ILAlgorithms
    /// </summary>
    /// <remarks>ILAlgorithmEventArgs carry some additional parameter to inform 
    /// clients of ILAlgorithms in case of state changes. </remarks>
    public class ILAlgorithmEventArgs : EventArgs {
        /// <summary>
        /// current progess state. This number is in the range 0 ... 1.0
        /// </summary>
        public readonly double Progress;
        /// <summary>
        /// A textual message associated with the current event
        /// </summary>
        public readonly string Message;
        /// <summary>
        /// The state of the ILAlgorithm. This is a constant out of the enum ILAlgorithmRunningStates
        /// </summary>
        public readonly ILAlgorithmState State; 
        /// <summary>
        /// Cancel the excecution of the sender of the event. 
        /// </summary>
        /// <remarks>If set to true, the sender (a ILAlgorith) will cancel and return from excecution.</remarks>
        public bool Cancel;
        /// <summary>
        /// Additional user defined data to be transferred to event registrar
        /// </summary>
        public object Parameter; 
        
        /// <summary>
        /// Construct a new ILAlgorithmEventArgs object for delivery
        /// </summary>
        /// <param name="progress">Current progress</param>
        /// <param name="message">A message to be included for the receiver of the event.</param>
        /// <param name="state">The state of the algorithm. Must be one out of the enum <typeparamref name="ILAlgorithmRunningState"/></param>
        public ILAlgorithmEventArgs (double progress,
                            string message, 
                            ILAlgorithmState state) {
            Progress = progress; 
            Message = message; 
            State = state;
            Cancel = false;
            Parameter = null; 
        }
        
        /// <summary>
        /// Construct a new ILAlgorithmEventArgs object for delivery
        /// </summary>
        /// <param name="progress">Current progress</param>
        /// <param name="message">A message to be included for the receiver of the event.</param>
        /// <param name="parameter">Additional user defined data to be transferred to event registrar</param>
        /// <param name="state">The state of the algorithm. Must be one out of the enum <typeparamref name="ILAlgorithmRunningState"/></param>
        public ILAlgorithmEventArgs(double progress,
                                    string message,
                                    ILAlgorithmState state,
                                    object parameter) {
            Progress = progress;
            Message = message;
            State = state;
            Cancel = false;

        }
    }
}
