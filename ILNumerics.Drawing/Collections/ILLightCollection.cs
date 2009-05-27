using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Lighting;
using System.Collections; 

namespace ILNumerics.Drawing.Collections {
    /// <summary>
    /// collection of 8 lights, individual configurable
    /// </summary>
    public class ILLightCollection 
        : IEnumerable {

        #region eventing
        public EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this, new EventArgs()); 
            }
        }
        #endregion

        #region attributes
        List<ILLight> m_lights; 
        #endregion

        #region properties
        /// <summary>
        /// set: enable/disable all lights; get: return true, if at least one light is enabled, false else 
        /// </summary>
        public bool Enabled {
            get { 
                foreach (ILLight l in m_lights)
                    if (l.Enabled) return true; 
                return false; 
            }
            set { 
                foreach (ILLight l in m_lights) 
                    l.Enabled = value; 
            }
        }
        #endregion

        #region constructors
        public ILLightCollection () {
            m_lights = new List<ILLight>(8);
            for (int i = 0; i < 8; i++) {
                ILLight light = new ILLight(i); 
                m_lights.Add(light); 
                light.Changed += new EventHandler(lightChanged); 
            }
        }
        #endregion

        #region public interface
        /// <summary>
        /// get light at specific index
        /// </summary>
        /// <param name="i">index of light, valid: 0...7</param>
        /// <returns>Light at index i</returns>
        public ILLight this[int i] {
            get {
                return m_lights[i]; 
            }
        }
        #endregion

        #region private helpers
        protected void lightChanged (object sender, EventArgs args) {
            OnChanged(); 
        }
        #endregion



        #region IEnumerable Member

        public IEnumerator GetEnumerator() {
            for (int i = 0; i < m_lights.Count; i++) {
                yield return m_lights[i]; 
            }
        }

        #endregion
    }
}
