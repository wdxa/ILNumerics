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
    /// delegate type definition for handler handling algorithms state or progress change events
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">parameter carrying extended algorithm state informations</param>
    public delegate void ILAlgorithmStateChangedEventHandler (object sender, ILAlgorithmEventArgs e); 
    
    /// <summary>
    /// Base class for all ILAlgorithms. User may derive their own algorithms from this class
    /// </summary>
    /// <remarks>ILAlgorithms excecute synchronously. Therefore the callee is responsible for 
    /// any threading / locking model if nesseccary. You should derive your own algorithms 
    /// from this class and call the default constructor ILArgorithm() of the base class from within your constructors. 
    /// ILAlgorithms provide an event handling mechanism for state and prgress information retrieval. 
    /// Developer of algorithms should frequently call versions of SetState and / or SetProgress which will
    /// raise the events for registered listeners.
    /// The actual work is triggered from the Run() method. Therefore this function should be overloaded or at least called 
    /// from derived classes as well. Since ILAlgorithms themself derive from ILMath, all static ILMath members (the core
    /// functions if ILNumerics.Net) are directly callable from within the class. </remarks>
    public abstract class ILAlgorithm : ILMath {
        #region Event handling
        /// <summary>
        /// Fires on state changes
        /// </summary>
        public event ILAlgorithmStateChangedEventHandler StateChanged; 

        /// <summary>
        /// fires on progress changes
        /// </summary>
        public event ILAlgorithmStateChangedEventHandler ProgressChanged; 

        /// <summary>
        /// internal field, holding the current state of algorithm
        /// </summary>
        private ILAlgorithmState m_state = ILAlgorithmState.Initialized; 
        /// <summary>
        /// internal field holding the current progress of algorithm
        /// </summary>
        private double m_progress = 0; 
        
        /// <summary>
        /// set the current state for algorithm
        /// </summary>
        /// <param name="state">state enumeration value</param>
        /// <returns>false: if on of the registrars of the StateChanged event wishes to cancel the operation, true otherwise.</returns>
        /// <remarks><para>calling this method will fire a StateChanged event.</para>
        /// </remarks>
        protected bool SetState(ILAlgorithmState state){
            return SetState(state,""); 
        }
        /// <summary>
        /// set the current state for algorithm and provide message
        /// </summary>
        /// <param name="state">state enumeration value</param>
        /// <param name="message">additional message with reason of state change</param>
        /// <returns>false: if on of the registrars of the StateChanged event wishes to cancel the operation, true otherwise.</returns>
        /// <remarks><para>calling this method will fire a StateChanged event.</para>
        /// <para>the message will be delivered to registrars of the StateChanged event.</para></remarks>
        protected bool SetState(ILAlgorithmState state, string message){
            m_state = state; 
            return OnStateChanged(message); 
        }

        /// <summary>
        /// set the progress value
        /// </summary>
        /// <param name="progress">progress value in range 0...1.0</param>
        /// <returns>false: if on user has requested a cancellation, true otherwise.</returns>
        /// <remarks><para>calling this method will fire a ProgressChanged event.</para></remarks>
        protected bool SetProgress(double progress){
            return SetProgress(progress, ""); 
        }
        
        /// <summary>
        /// get the current progress of the running algorithm 
        /// </summary>
        public double Progress {
            get {
                return m_progress; 
            }
        }

        /// <summary>
        /// set the progress value
        /// </summary>
        /// <param name="progress">progress value in range 0...1.0</param>
        /// <param name="message">additional informational message with reason of progress change or description of current operation</param>
        /// <returns>false: if on user has requested a cancellation, true otherwise.</returns>
        /// <remarks><para>calling this method will fire a ProgressChanged event.</para>
        /// <para>the message given will be carried to registrars of the ProgressChanged event.</para></remarks>
        protected bool SetProgress(double progress, string message) {
            if (progress < 0.0 || progress > 1.0)
                throw new ILArgumentException("SetProgress: progress must be in range 0...1.0!");
            m_progress = progress; 
            return OnProgressChanged(message); 
        }
        /// <summary>
        /// helper function firing the state changed event
        /// </summary>
        /// <param name="message">string to be send within the 
        /// <see cref="ILNumerics.Algorithms.ILAlgorithmEventArgs"/> </param>
        /// <returns>false if a handler of the event has attempted to cancel the 
        /// operation, true if the algorithm should continue normaly.</returns>
        protected virtual bool OnStateChanged (string message) {
            ILAlgorithmEventArgs e = new ILAlgorithmEventArgs(m_progress, "State:" + message, m_state);
            if (StateChanged != null)
                StateChanged(this,e); 
            if (e.Cancel == true) {
                SetState(ILAlgorithmState.Canceled); 
                return false; 
            }
            return true; 
        }
        /// <summary>
        /// helper function firing the progress changed event
        /// </summary>
        /// <param name="message">string to be send within the 
        /// <see cref="ILNumerics.Algorithms.ILAlgorithmEventArgs"/> </param>
        /// <returns>false if a handler of the event has attempted to cancel the 
        /// operation, true if the algorithm should continue normaly.</returns>
        protected virtual bool OnProgressChanged (string message) {
            ILAlgorithmEventArgs e = new ILAlgorithmEventArgs(m_progress, "Progress:" + message, m_state);
            if (ProgressChanged != null)
                ProgressChanged(this,e); 
            if (e.Cancel == true) 
                return false; 
            return true;
        }
        #endregion Event handling 
        /// <summary>
        /// Name of the algorithm (readonly)
        /// </summary>
        public string Name {
            get {
                return m_name;
            }
        }
        /// <summary>
        /// internal field holding the name of this algorithm
        /// </summary>
        protected string m_name; 

        #region constructors 
        /// <summary>
        /// Default constructor 
        /// </summary>
        /// <remarks>Derived classes must call this base class constructor! This will set all 
        /// private attributes to default (inital) values. </remarks>
        public ILAlgorithm() {
            m_state = ILAlgorithmState.Initialized; 
            m_progress = 0.0; 
            m_name = "ILAlgorithm derived class"; 
        }
        #endregion constructors

        #region runtime member 
        /// <summary>
        /// Start running this algorithm synchronously.
        /// </summary>
        /// <remarks>Derived classes must call this member via base() !</remarks>
        protected virtual void Run() {
            SetState (ILAlgorithmState.Running); 
        }

        #endregion runtime member 


    }
}
