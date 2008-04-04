using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace ILNumerics.Drawing {
    /// <summary>
    /// Determines properties for markers
    /// </summary>
    public class ILMarker {
        /// <summary>
        /// Fires if the properties were changed
        /// </summary>
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this,new EventArgs()); 
            }
        }

        #region attributes / properties
        private Color m_color; 
        /// <summary>
        /// Marker color
        /// </summary>
        public Color Color {
            get {
                return m_color; 
            }
            set {
                m_color = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Style for markers (default: none)
        /// </summary>
        public MarkerStyle Style {
            get {
                return m_markerStyle; 
            }
            set {
                m_markerStyle = value; 
                OnChanged(); 
            }
        }
        private MarkerStyle m_markerStyle; 
        /// <summary>
        /// Size of markers (default: 4)
        /// </summary>
        public int Size {            
            get {
                return m_markerSize; 
            }
            set {
                m_markerSize = value; 
                OnChanged(); 
            }
        }
        private int m_markerSize; 
        /// <summary>
        /// bitmap for markers if MarkerStyle is set to 'Bitmap'
        /// </summary>
        public Bitmap Bitmap {
            get {
                return m_markerBitmap; 
            }
            set {
                m_markerBitmap = value; 
                OnChanged(); 
            }
        }
        private Bitmap m_markerBitmap; 
        #endregion

        #region constructor
        public ILMarker () {
            m_markerStyle = MarkerStyle.None; 
            m_markerSize = 3;
        }
        #endregion
    }
}
