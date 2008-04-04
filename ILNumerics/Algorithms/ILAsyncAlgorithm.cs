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
using System.Threading; 
using System.Windows.Forms; 
using ILNumerics; 
using ILNumerics.Algorithms; 
using ILNumerics.BuiltInFunctions; 


namespace ILNumerics.Algorithms {
    /// <summary>
    /// base class for asynchronous algorithms
    /// </summary>
    /// <remarks>the abstract class implements an asynchronous algorithm class. It 
    /// fires events for all state changes and for progress information. Algorithms 
    /// derived from this class are capable of cancelling on user rewuest and to transparently 
    /// invoke event signals in the context of a calling System.Windows.Form - even from the internal 
    /// worker thread.</remarks>
    public abstract class ILAsyncAlgorithm : ILMath {

        /// <summary>
        /// fires whenever the state of the algorithm changes
        /// </summary>
        public event ILAlgorithmStateChangedEventHandler StateChanged; 
        /// <summary>
        /// fires if the progress of the algorithm changes 
        /// </summary>
        public event ILAlgorithmStateChangedEventHandler ProgressChanged; 
        private delegate object ILAsyncAlgorithmWorker(object parameter); 
 
        #region properties
        /// <summary>
        /// The current state of the algorithm. One out of the enumeration <see cref="ILNumerics.ILAlgorithmState"/>.
        /// </summary>
        public ILAlgorithmState State {
            get {
                return m_state; 
            }
        }
        private ILAlgorithmState m_state = ILAlgorithmState.Initialized; 
        private object m_result = null; 
        private Thread m_thread = null; 
        private object m_lockObject = new object(); 
        private double m_progress = 0.0;
        private string m_lastMessage = ""; 
        private Control m_control; 
        private bool m_cancelPending = false; 
        private bool m_waitforRunning = false; 
        /// <summary>
        /// informs about a pending cancelation
        /// </summary>
        /// <remarks>
        /// <para>This will be set to true, if an algorithm is running and the user of the class called the <see cref="ILNumerics.Algorithms.ILAsyncAlgorithm.Cancel(int)"/> method.</para>
        /// <para>Class designer of derived classes should frequently check this property. If a cancellatioin was 
        /// requested, the algorithm should close as fast as possible. This is the 'good way' out of the algorithm. If the algorithm 
        /// does not respond fast enough, the user might kill the thread, which will not give the algorithm the chance to exit cleanly.</para></remarks>
        protected bool CancelPending {
            get {
                return m_cancelPending;
            }
        }
    
        /// <summary>
        /// query algorithm result 
        /// </summary>
        /// <remarks><para>if the algorithm has not finished yet, the method waits for the thread to end. 
        /// If the algorithm has not started yet, null will be returned.</para>
        /// <para>You may query the state of the algorithm before calling this property, in order to prevent for the lock.</para>
        /// <para>Class designer of derived classes use this property to get the result object after an algorithm has finnished. The 
        /// return value is the return value of the abstract method <see cref="ILNumerics.Algorithms.ILAsyncAlgorithm.AlgorithmFunction"/>. The type 
        /// of the result object depends on the actual implementation of the derived class.</para> </remarks>
        protected object GetResult() {
            if (m_result == null && m_thread != null && m_thread.ThreadState == ThreadState.Running) {
                    m_thread.Join();  
            }
            return m_result; 
        }

        private void SetResult(object result) {
            lock (m_lockObject) {
                m_result = result; 
            }
        }
        /// <summary>
        /// Set the current progress of the algorithm. 
        /// </summary>
        /// <param name="progress">progress value. 0 &lt;= progress &lt;= 1.0</param>
        /// <param name="message">additional message.</param>
        /// <remarks><para>Calling this methos will fire an <see cref="ILNumerics.Algorithms.ILAsyncAlgorithm.ProgressChanged">ProgressChanged</see> event.</para></remarks>
        protected void SetProgress(double progress, string message) {
            m_progress = progress; 
            m_lastMessage = message; 
            OnProgressChanged(); 
        }
        private void SetState(ILAlgorithmState state) {
            m_state = state; 
            m_lastMessage = "State: '" + m_state.ToString() + "'"; 
            OnStateChanged(); 
        }
        /// <summary>
        /// current progress value.
        /// </summary>
        public double Progress {
            get {
                return m_progress; 
            }
        }
        #endregion 
        /// <summary>
        /// constructor creating a new ILAsyncAlgorithm object.
        /// </summary>
        /// <param name="control">if not null, events fired from this class will be 
        /// executed in the context of the thread owning the control. This is specifically 
        /// important for Windows.Forms.Control user interfaces, which require this in order to allow 
        /// direct manipulation of the control from inside the event handlers.</param>
        public ILAsyncAlgorithm(Control control) {
            m_control = control; 
        }
        /// <summary>
        /// Kills this algorithm thread. 
        /// </summary>
        /// <param name="msec">waits for at most <paramref name="msec"/> milliseconds before returning</param>
        /// <returns>true: the thread has been successfully canceled. false: the thread has acknowledged the 
        /// cancellation request after msec milliseconds.</returns>
        /// <remarks><para>This method kills the algorithm thread without waiting for the algorithm to end. It 
        /// waits for at most msec milliseconds for the algorithm thread to respond and acknowledge the cancellation.</para>
        /// <para>You should always prefer the Cancel() method for the Kill() method. This gives the algorithm the chance 
        /// to exit cleanly.</para>
        /// <para>Calling this function will <b>NOT</b> call any StateChanged events.</para></remarks>
        public bool Kill(int msec) {
            if (m_thread == null) return true;
            if (m_thread.ThreadState == ThreadState.Suspended)
                m_thread.Resume(); 
            DateTime end = DateTime.Now + TimeSpan.FromMilliseconds(msec); 
            m_thread.Abort(); 
            while (end > DateTime.Now && m_thread != null 
                && (m_thread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) != 0) {
                System.Threading.Thread.Sleep(100);
            }
            if (m_thread != null && (m_thread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) != 0) 
                return false; 
            m_thread = null;
            return true; 
        }
        /// <summary>
        /// Cancel the algorithm.
        /// </summary>
        /// <param name="timeout">waits for at most msec milliseconds after the cancelation request was published.</param>
        /// <returns>true: the algorithm has finished/ cancelled successfully. false otherwise</returns>
        public bool Cancel (int timeout) {
            if (m_thread == null) return true; 
            m_cancelPending = true; 
            if (m_thread.ThreadState == ThreadState.Suspended)
                Resume(); 
            DateTime end = DateTime.Now + TimeSpan.FromMilliseconds(timeout); 
            while (end > DateTime.Now && (m_thread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) != 0) {
                System.Threading.Thread.Sleep(50);
            }
            if ((m_thread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) != 0) 
                return false; 
            m_thread = null;
            SetState(ILAlgorithmState.Canceled); 
            return true; 
        }
        /// <summary>
        /// halt the algorithm
        /// </summary>
        /// <returns>true if the algorithm was suspended successfully. False otherwise.</returns>
        /// <remarks>An algorithm which has suspended may later be resumed. Calling this 
        /// method on an algorithm which is not running will have no effect and return true.
        /// <para>This method will be called in the context of the algorithm caller thread.</para></remarks>
        public bool Suspend() {
            if (m_thread == null) return false; 
            if (m_state != ILAlgorithmState.Running) return true; 
            SetState(ILAlgorithmState.Suspended); 
            m_thread.Suspend(); 
            return true; 
        }
        /// <summary>
        /// Resume algorithm
        /// </summary>
        /// <remarks>If the algorithm is in state 'Suspended', calling this method will 
        /// resume execution for this thread. Calling this method for an algorithm which is 
        /// not in state 'Suspended' will have no effect.
        /// <para>This method will be called in the context of the algorithm caller thread.</para></remarks>
        public void Resume() {
            if (m_thread == null) return;
            if (m_state != ILAlgorithmState.Suspended) return; 
            SetState(ILAlgorithmState.Running); 
            m_thread.Resume(); 
        }
        private void AlgorithmFunctionTryWrapper(object parameter) {
            try {
                // ack the thread is running - signal to return async to callee
                m_waitforRunning = true; 
                SetState(ILAlgorithmState.Running); 
                object result = AlgorithmFunction(parameter); 
                SetResult(result); 
                if (m_cancelPending) 
                    SetState(ILAlgorithmState.Canceled); 
                else 
                    SetState(ILAlgorithmState.Finished); 
                m_cancelPending = false; 
                m_thread = null; 
                OnAlgorithmFinished(); 
            } catch (ThreadAbortException) {
                m_state = ILAlgorithmState.Canceled; 
                m_thread = null; 
                //throw new ILNumerics.Exceptions.ILException("The thread #" + m_thread.Name + "was interrupted."); 
            }
        }

        /// <summary>
        /// this function serves as a placeholder for your derived class method wich does the actual computing 
        /// </summary>
        /// <remarks>Algorithm class designer must implement their algorithms in this function. Make sure, to 
        /// frequently check the CancelPending member of the base class, to determine if a cancellation was requested.
        /// <para>This method will be called in the context of the algorithm worker thread.</para></remarks>
        protected abstract object AlgorithmFunction (object parameter); 
        /// <summary>
        /// assemble parameter object i.o. to overgive to thread worker
        /// </summary>
        /// <returns>parameter object</returns>
        /// <remarks>This function must be implemented by algorithm class designers. It compiles all neccessary 
        /// input parameter for the computation function. The output of this method will later be the only input 
        /// parameter for the <see cref="ILNumerics.Algorithms.ILAsyncAlgorithm.AlgorithmFunction(object)">AlgorithmFunction</see> 
        /// on a seperate thread.</remarks>
        protected abstract object CompileParameter ();
        /// <summary>
        /// Additionally clean up after the algorithm has finished successfully.
        /// </summary>
        /// <remarks>This method will be called in the context of the algorithm worker thread.</remarks>
        protected virtual void OnAlgorithmFinished() {

        }
        /// <summary>
        /// Start algorithm asynchronously
        /// </summary>
        /// <remarks>The algorithm will be started in a new thread. the state of the algorithm will be set to 'Running'.</remarks>
        public void RunAsync() {
            if (m_thread == null) {
                m_waitforRunning = false; 
                ParameterizedThreadStart ptstart = new ParameterizedThreadStart( AlgorithmFunctionTryWrapper ); 
                m_thread = new Thread(ptstart); 
                m_thread.Start(CompileParameter()); 
                while (!m_waitforRunning) {
                    Thread.Sleep(50); 
                }
            } 
        }
        /// <summary>
        /// Execute this algorithm and wait for finish 
        /// </summary>
        public void RunSync() {
            RunAsync(); 
            while (State == ILAlgorithmState.Running) {
                Thread.Sleep(50); 
            }
        }
        /// <summary>
        /// Fires the StateChanged event.
        /// </summary>
        /// <remarks><para>If the control parameter was given in the constructor of the class, the 
        /// event is fired in the context of the calling thread and not of the worker thread.</para></remarks>
        protected virtual void OnStateChanged () {
            ILAlgorithmEventArgs evargs = new ILAlgorithmEventArgs(m_progress,"State: " + m_state.ToString(), m_state);
            if (m_control != null && m_control.InvokeRequired) {
                if (!m_control.Disposing && !m_control.IsDisposed && StateChanged != null) {
                    m_control.Invoke(StateChanged,this, evargs);
                }
            } else {
                if (StateChanged != null)
                    StateChanged(this, evargs); 
            }
        }
        /// <summary>
        /// Fires the ProgressChanged event.
        /// </summary>
        /// <remarks><para>If the control parameter was given in the constructor of the class, the 
        /// event is fired in the context of the calling thread and not of the worker thread.</para></remarks>
        protected virtual void OnProgressChanged () {
            //if (m_state == ILAlgorithmState.Unloaded) return; 
            ILAlgorithmEventArgs evargs; 
            if (String.IsNullOrEmpty(m_lastMessage))
                evargs = new ILAlgorithmEventArgs(m_progress,"Progress: " + ((int)(m_progress * 100)) + "%", m_state);
            else 
                evargs = new ILAlgorithmEventArgs(m_progress,m_lastMessage, m_state);
            if (m_control != null && m_control.InvokeRequired && ProgressChanged != null) {
                if (!m_control.Disposing && !m_control.IsDisposed && ProgressChanged != null) {
                    m_control.Invoke(ProgressChanged,this, evargs);
                }
            } else {
                if (ProgressChanged != null)
                    ProgressChanged(this, evargs); 
            }
        }

    }
}
