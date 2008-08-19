#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details. 
//
#endregion

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
        /// <summary>
        /// draw all markers (graph / legend)
        /// </summary>
        /// <param name="marker">the marker object (for properties)</param>
        /// <param name="vertices">coords, interleaved</param>
        /// <param name="vertcount">number of coords, special: -1 for legend rendering</param>
        /// <remarks>This function is reused for both: drawing in word coords (graph) and drawing in
        /// screen coords (legend). Letter case requires vertcount to be -1, vertices must contain
        /// at least 2 float values than!</remarks>
        internal override void Draw(ILMarker marker, float[] vertices, int vertcount) {
            if (vertcount > 0) {
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
            } else if (vertcount == -1) {
                #region render for legend
                m_renderer.Begin(null); 
                string expr = m_expression.Replace("\\index","0");
                expr = expr.Replace("\\xvalue","0.2"); 
                expr = expr.Replace("\\yvalue","0.4"); 
                ILRenderQueue queue = m_interpreter.Transform(expr,m_font,marker.Color,m_renderer); 
                #region determine size for markers in SCREEN COORDS
                float w,h;
                ILClippingData clip = m_panel.Limits; 
                float s05x; 
                float s05y; 
                s05x = Math.Abs(queue.Size.Width / 2 ); 
                s05y = Math.Abs(queue.Size.Height / 2); 

                #endregion
                // this is slow! Todo: replace by point sprites! 
                w = vertices[0]; 
                h = vertices[1];
                
                m_renderer.Draw(queue,w-s05x,h-s05y,0,w + s05x,h+s05y,0,marker.Color); 
                m_renderer.End();
                #endregion
            }

        }
        #endregion



    }
}
