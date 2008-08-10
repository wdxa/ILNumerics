using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Marker; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Platform.OpenGL; 
using OpenTK.Graphics; 


namespace ILNumerics.Drawing.Platform.OpenGL {
    public class ILOGLTexMarkerShape : ILTexMarkerShape {

        #region attributes
        IILRenderer m_renderer; 
        #endregion

        #region Properties
        #endregion

        #region constructors
        internal ILOGLTexMarkerShape(ILPanel panel, string expression) 
            :   base(panel,expression) {
            m_renderer = new ILOGLWorldRenderer(panel); 
        }
        #endregion

        #region public interface

        internal override void Draw(ILMarker marker, float[] vertices, int vertcount) {
            int inc = Math.Max(1,(vertcount/m_maxLabelsDrawn)); 
            m_renderer.Begin(null); 
            for (int i = 0; i < vertcount; i += inc) {
                #region draw textured points (slow version: textured quads)
                string expr = m_expression.Replace("\\index",i.ToString());
                expr = expr.Replace("\\xvalue",vertices[i*2].ToString(m_valueFormat)); 
                expr = expr.Replace("\\yvalue",vertices[i*2+1].ToString(m_valueFormat)); 
                ILRenderQueue queue = m_interpreter.Transform(expr,m_font,marker.Color,m_renderer); 
                #region determine size for markers in world coords (graph limits)
                float w,h;
                ILClippingData clip = m_panel.Limits; 
                float s05x; 
                float s05y; 
                s05x = Math.Abs(queue.Size.Width * clip.WidthF / 2 / (m_panel.ClientSize.Width - m_panel.m_cubeMargin * 2)); 
                s05y = Math.Abs(queue.Size.Height * clip.HeightF / 2 / (m_panel.ClientSize.Height - m_panel.m_cubeMargin * 2)); 

                #endregion
                // this is slow! Todo: replace by point sprites! 
                w = vertices[i*2]; 
                h = vertices[i*2+1];           
                if (m_panel.ClipViewData && (w < clip.m_xMin || w > clip.m_xMax || h < clip.m_yMin || h > clip.m_yMax)) 
                    continue; 
                m_renderer.Draw(queue,w-s05x,h+s05y,0,w + s05x,h-s05y,0,marker.Color); 
#endregion
            }
            m_renderer.End(); 
        }
        #endregion



    }
}
