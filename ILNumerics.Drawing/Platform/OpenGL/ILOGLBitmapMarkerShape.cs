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
using OpenTK.Graphics; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Shapes; 


namespace ILNumerics.Drawing.Platform.OpenGL {
    public class ILOGLBitmapMarkerShape : ILBitmapMarkerShape {

        #region constructors
        internal ILOGLBitmapMarkerShape(ILPanel panel, Bitmap bitmap) 
            : base(panel,bitmap) {}
        #endregion

        #region public interface
        internal override void Draw(ILRenderProperties p, ILMarker marker, C4bV3f[] vertices, int startID, int vertCount) {
            if (vertCount == 0 && vertCount != -1) return; 
            string texKey = Hash();                
            ILTextureData texData; 
            if (!m_panel.TextureManager.Exists(texKey)) {
                storeBitmap(m_bitmap);
            }
            texData = m_panel.TextureManager.GetTextureItem(texKey,true); 
    System.Diagnostics.Debug.Assert(texData != null,"The texture key for the bitmap was expected to exist in texture storage, but it was not found!"); 
            // prepare for plotting
            GL.Color3(marker.Color); 
            GL.PushAttrib(AttribMask.AllAttribBits);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Disable(EnableCap.DepthTest);
            RectangleF rectF = texData.TextureRectangle; 
            float w,h;
            if (vertCount > 0) {
                #region draw textured points (slow version: textured quads)
                #region determine size for markers in world coords (graph limits)
                ILClippingData clip = m_panel.Limits; 
                float s05x; 
                float s05y; 
                //if (m_marker.)
                s05x = Math.Abs(marker.Size * clip.WidthF / (m_panel.ClientSize.Width)); 
                s05y = Math.Abs(marker.Size * clip.HeightF / (m_panel.ClientSize.Height)); 

                #endregion
                // draw all markers using quads. 
                // this is slow! Todo: replace by point sprites! 
                GL.Begin(BeginMode.Quads); 
                for (int i = 0; i < vertCount; i++) {
                    w = vertices[i].Position.X; 
                    h = vertices[i].Position.Y;           
                    if (m_panel.ClipViewData && (w < clip.XMin || w > clip.XMax || h < clip.YMin || h > clip.YMax)) 
                        continue; 
                    w -= s05x;             
                    h -= s05y; 
                    GL.TexCoord2(rectF.Left,rectF.Bottom);              
                    GL.Vertex2(w,h);                                        // ul
                    GL.TexCoord2(rectF.Left,rectF.Top);                 
                    GL.Vertex2(w,h + 2 * s05y);                             // bl
                    w += 2 * s05x;                                
                    GL.TexCoord2(rectF.Right,rectF.Top);                
                    GL.Vertex2(w,h + 2 * s05y);                             // br
                    GL.TexCoord2(rectF.Right,rectF.Bottom);             
                    GL.Vertex2(w,h);                                        // tr
                }
                GL.End(); 
                #endregion
            } else if (vertCount == -1) {
                #region render to legend 
                // draw all markers using quads. 
                // this is slow! Todo: replace by point sprites! 
                GL.Begin(BeginMode.Quads); 
                    w = vertices[0].XPosition - m_bitmap.Width / 2; 
                    h = vertices[0].YPosition - m_bitmap.Height / 2;           
                    GL.TexCoord2(rectF.Left,rectF.Top);              
                    GL.Vertex2(w,h);                                        // ul
                    GL.TexCoord2(rectF.Left,rectF.Bottom);                 
                    GL.Vertex2(w,h + m_bitmap.Height);                      // bl
                    w += m_bitmap.Width;                                
                    GL.TexCoord2(rectF.Right,rectF.Bottom);                
                    GL.Vertex2(w,h + m_bitmap.Height);                      // br
                    GL.TexCoord2(rectF.Right,rectF.Top);             
                    GL.Vertex2(w,h);                                        // tr
                GL.End(); 
                #endregion
            }
            GL.PopAttrib();
        }

        #endregion
    }
}
