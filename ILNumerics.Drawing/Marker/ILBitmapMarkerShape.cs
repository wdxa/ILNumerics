using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Labeling; 

namespace ILNumerics.Drawing.Marker {
    public abstract class ILBitmapMarkerShape : ILMarkerShape {

        #region attributes
        protected Bitmap m_bitmap; 
        #endregion

        #region constructors
        internal ILBitmapMarkerShape (ILPanel panel, Bitmap bitmap) : base(panel) {
            m_bitmap = bitmap;     
        }
        #endregion

        #region properties
        public Bitmap Bitmap {
            get {
                return m_bitmap; 
            }
            set {
                m_bitmap = value; 
                storeBitmap(m_bitmap); 
            }
        }
        #endregion

        #region public interface
        public string Hash() {
            // create hash based on the width, height & middle scanline of bitmap
            StringBuilder sb = new StringBuilder(
                        String.Format("M:{0}W{1}H{2}:","BMP",m_bitmap.Width,m_bitmap.Height)); 
            int h = m_bitmap.Height / 2; 
            for (int x = 0; x < Math.Min(m_bitmap.Width,30);x++) {
                sb.Append(m_bitmap.GetPixel(x,h).ToArgb().ToString());
            }
            return sb.ToString(); 
        }

        #endregion

        #region private helper
        protected virtual void storeBitmap(Bitmap bitmap) {
            string key = Hash(); 
            ILTextureManager mana = m_panel.TextureManager; 
            mana.StoreTextureItem(key,m_bitmap); 
        }
        #endregion
    }
}
