using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace ILNumerics.Drawing.Marker {
    
    /// <summary>
    /// Class used to enable flexible settings for marker shapes in ILMarker
    /// </summary>
    class ILMarkerShapeProxy : ILMarkerShape {

        #region attributes
        private object m_source; 
        #endregion 

        #region constructors
        public ILMarkerShapeProxy (string expression) : base (null) {
            m_source = expression; 
        }
        public ILMarkerShapeProxy (Bitmap bitmap) : base (null) {
            m_source = bitmap; 
        }
        public ILMarkerShapeProxy (MarkerStyle style) : base (null) {
            m_source = style; 
        }
        #endregion

        #region properties
        internal Object Source {
            get {
                return m_source; 
            }
        }
        #endregion

        #region public interface 
        internal override void Draw(ILMarker marker, float[] vertices, int vertCount) {
            // dummy. Nothing to do! 
        }
        #endregion
    }
}
