using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace ILNumerics.Drawing.Misc {
    public abstract class ILAction {

        #region attributes
        TimeSpan m_duration; 
        Thread m_workerThread; 
        protected bool m_canceled; 
        #endregion

        #region properties
        #endregion

        #region constructor
        public ILAction() {
            m_canceled = false; 
            m_workerThread = new Thread(new ParameterizedThreadStart(RunInternal)); 
        }
        #endregion

        #region public interface 
        // Run
        public void Run() {
            if (m_workerThread.ThreadState != ThreadState.Running) {
                m_canceled = false; 
                m_workerThread.Start();
            }
        }
        // Cancel
        public void Cancel() {
            m_canceled = true; 
        }

        protected abstract void RunInternal(object parameter); 
        #endregion 

        #region private helper

        #endregion
    }
}
