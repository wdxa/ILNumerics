using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.Marker {
    public abstract class ILMarkerShape {

        #region attributes
        protected ILPanel m_panel;  
        #endregion

        #region constructors 
        internal ILMarkerShape (ILPanel panel) { 
            m_panel = panel; 
        }
        #endregion

        #region cast operators
        public static implicit operator ILMarkerShape(string content) {
            return new ILMarkerShapeProxy(content);
        }
        public static implicit operator ILMarkerShape(MarkerStyle style) {
            return new ILMarkerShapeProxy(style);
        }
        public static implicit operator ILMarkerShape(Bitmap bitmap) {
            return new ILMarkerShapeProxy(bitmap);
        }
        #endregion 


        #region public interface 
        internal abstract void Draw(ILMarker marker, float[] vertices, int vertCount);
        #endregion
    }
}
