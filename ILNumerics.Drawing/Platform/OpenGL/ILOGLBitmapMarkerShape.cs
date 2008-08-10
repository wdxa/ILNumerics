using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Marker; 
using ILNumerics.Drawing.Controls; 
using OpenTK.Graphics; 
using ILNumerics.Drawing.Labeling; 


namespace ILNumerics.Drawing.Platform.OpenGL {
    public class ILOGLBitmapMarkerShape : ILBitmapMarkerShape {

        #region constructors
        internal ILOGLBitmapMarkerShape(ILPanel panel, Bitmap bitmap) 
            : base(panel,bitmap) {}
        #endregion

        #region public interface
        internal override void Draw(ILMarker marker, float[] vertices, int vertCount) {
            #region draw textured points (slow version: textured quads)
            string texKey = Hash(); 
            ILTextureData texData; 
            if (!m_panel.TextureManager.Exists(texKey)) {
                storeBitmap(m_bitmap);
            }
            texData = m_panel.TextureManager.GetTextureItem(texKey,true); 
System.Diagnostics.Debug.Assert(texData != null,"The texture key for the bitmao was expected to exist in texture storage, but it was not found!"); 
            // prepare for plotting
            GL.Enable(EnableCap.Texture2D); 
            GL.Color3(marker.Color); 
            GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Disable(EnableCap.DepthTest);
            RectangleF rectF = texData.TextureRectangle; 
            float w,h;
            #region determine size for markers in world coords (graph limits)
            ILClippingData clip = m_panel.Limits; 
            float s05x; 
            float s05y; 
            //if (m_marker.)
            s05x = Math.Abs(marker.Size * clip.WidthF / (m_panel.ClientSize.Width - m_panel.m_cubeMargin * 2)); 
            s05y = Math.Abs(marker.Size * clip.HeightF / (m_panel.ClientSize.Height - m_panel.m_cubeMargin * 2)); 

            #endregion
            // draw all markers using quads. 
            // this is slow! Todo: replace by point sprites! 
            GL.Begin(BeginMode.Quads); 
            for (int i = 0; i < vertCount; i++) {
                w = vertices[i*2]; 
                h = vertices[i*2+1];           
                if (m_panel.ClipViewData && (w < clip.m_xMin || w > clip.m_xMax || h < clip.m_yMin || h > clip.m_yMax)) 
                    continue; 
                w -= s05x;             
                h -= s05y; 
                GL.TexCoord2(rectF.Left,rectF.Bottom);              
                GL.Vertex2(w,h);                                     // ul
                GL.TexCoord2(rectF.Left,rectF.Top);                 
                GL.Vertex2(w,h + 2 * s05y);                             // bl
                w += 2 * s05x;                                
                GL.TexCoord2(rectF.Right,rectF.Top);                
                GL.Vertex2(w,h + 2 * s05y);                             // br
                GL.TexCoord2(rectF.Right,rectF.Bottom);             
                GL.Vertex2(w,h);                                     // tr
            }
            GL.End(); 
            GL.PopAttrib();
            #endregion
        }

        #endregion
    }
}
