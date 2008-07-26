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
using System.Drawing.Imaging; 
using System.Data;
using System.Windows.Forms;
using ILNumerics.Exceptions; 
using System.Resources; 
using OpenTK.Graphics; 
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL.Enums;
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Labeling; 
using System.Resources; 

namespace ILNumerics.Drawing.Platform.OpenGL
{
    /// <summary>
    /// OpenGL implementation for ILPlot2DGraph
    /// </summary>
    public class ILOGLPlot2DGraph : ILPlot2DGraph {

        #region attributes 

        protected float[] m_vertexArray;
        protected int m_vertCount;
        protected int m_primCount; 
        protected int m_textureName = 0; 
        protected float[] m_markerQuads; 

        #endregion

        #region constructors 

        internal ILOGLPlot2DGraph  ( ILPanel panel, ILBaseArray sourceArray,
                                  ILClippingData clippingContainer) 
                                : base(panel, sourceArray,clippingContainer) {
            create();
        }
        internal ILOGLPlot2DGraph  ( ILPanel panel, ILBaseArray xData, ILBaseArray yData,
                                  ILClippingData clippingContainer) 
                                : base(panel, xData, yData, clippingContainer) {
            create();
        }

        #endregion

        #region helper functions 

        private void create() {
            if (m_sourceArray.Length == 0) {
                m_vertCount = 0;
                m_primCount = 0;
            } else if (m_sourceArray.Length == 1) {
                m_vertCount = 1;
                m_primCount = 1;
            } else {
                m_vertCount = m_sourceArray.Length;
                m_primCount = m_sourceArray.Length - 1;
            }
            // marker's ressources will get configured once a marker was set (via properties)
            Configure();
        }

        private void Transform2D() {
            m_localClipping.Reset(); 
            float valY = 0.0f; 
            int len = m_sourceArray.Length; 
            if (!m_sourceArray.IsScalar) {
                for (int i = 0; i < len; i++) {
                    valY = m_sourceArray.GetValue(i);
                    if (m_localClipping.YMax < valY) m_localClipping.m_yMax = valY; 
                    if (m_localClipping.YMin > valY) m_localClipping.m_yMin = valY; 
                    m_vertexArray[2*i]  = m_xData.GetValue(i); 
                    m_vertexArray[2*i+1]= valY; 
                }
                m_localClipping.m_zMax = 0.0f; 
                m_localClipping.m_zMin = 0.0f; 
                m_localClipping.m_xMin = m_xData.MinValue; 
                m_localClipping.m_xMax = m_xData.MaxValue;
            } else {
                // scalar case 
                valY = m_sourceArray.GetValue(0);
                m_localClipping.m_yMax = valY; 
                m_localClipping.m_yMin = valY; 
                m_localClipping.m_xMax = m_xData.GetValue(0); 
                m_localClipping.m_xMin = m_localClipping.m_xMax; 
                m_localClipping.m_zMax = 0.0f; 
                m_localClipping.m_zMin = 0.0f; 
                m_vertexArray[0] = 0.0f; 
                m_vertexArray[1] = (float)(valY); 
           }
           m_isReady = true; 
        }

        #endregion 

        #region public (& abstract) interface 

        public override void Draw() {
            base.Draw(); 
            //System.Diagnostics.Debug.WriteLine("ILOGLGraphPlot2D_Draw"); 
            #region draw line
            // draw linestrip - simple case - fast vertex rendering 
            GL.Color3(m_properties.Color); 
            int stipFactr = 1;  
            LineStyle style = m_properties.Style;
            short stipple; 
            if (m_properties.Style != LineStyle.UserPattern) 
                stipple = ILNumerics.Drawing.Controls.ILPanel.StippleFromLineStyle(style, ref stipFactr);
            else 
                stipple = m_properties.Pattern; 
            GL.Enable(EnableCap.LineStipple);
            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.Blend); 
            GL.LineStipple((int)m_properties.PatternScale,stipple);
            GL.LineWidth(m_properties.Width); 
            unsafe { 
                fixed(float* pVertArr = m_vertexArray) {  
                    GL.InterleavedArrays(InterleavedArrayFormat.V2f,0,(IntPtr)(float*)pVertArr); 
                    GL.DrawArrays(BeginMode.LineStrip,0,m_vertCount); 
                }
            }
            #endregion
            #region draw markers
            if (m_marker.Style != MarkerStyle.None) {
                if (m_marker.Style == MarkerStyle.Dot || m_marker.Style == MarkerStyle.Square) {
                    ILOGLPanel.SetupMarkerStyle(m_marker);
                    unsafe { 
                        fixed(float* pVertArr = m_vertexArray) {
                            //GL.TexCoord2(0.5,0.5); 
                            GL.InterleavedArrays(InterleavedArrayFormat.V2f,0,(IntPtr)(float*)pVertArr); 
                            GL.DrawArrays(BeginMode.Points,0,m_vertCount); 
                        }
                    }
                } else {
                    #region draw textured points (slow version: textured quads)
                    string markerTexKey = ILMarker.Hash(m_marker.Style,m_marker.Bitmap); 
                    ILTextureData texData; 
                    if (!m_panel.TextureManager.Exists(markerTexKey)) {
                        CacheMarkerBitmap();
                    }
                    texData = m_panel.TextureManager.GetTextureItem(markerTexKey,true); 
System.Diagnostics.Debug.Assert(texData != null,"The texture for marker was expected to exist in texture storage, but it was not found!"); 
                    // prepare for plotting
                    GL.Enable(EnableCap.Texture2D); 
                    GL.Color3(m_marker.Color); 
                    GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);

                    GL.Enable(EnableCap.Texture2D);
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    GL.Disable(EnableCap.DepthTest);
                    RectangleF rectF = texData.TextureRectangle; 
                    float w,h;
                    #region determine size for markers in world coords (graph limits)
                    // this does not work out, needs to take rotation and modelview into account
                    //ILOGLPanel opan = m_panel as ILOGLPanel; 
                    //OpenTK.Math.Vector3 tmp1 = new OpenTK.Math.Vector3(m_panel.ClientSize.Width/2-m_marker.Size,m_panel.ClientSize.Height/2-m_marker.Size,0.5f); 
                    //OpenTK.Math.Vector3 tmp2 = new OpenTK.Math.Vector3(m_panel.ClientSize.Width/2+m_marker.Size,m_panel.ClientSize.Height/2+m_marker.Size,0.5f); 
                    //ILPoint3Df tmp1 = m_panel.Screen2World2D(m_panel.Width/2,m_panel.Height/2,0.5f); 
                    //ILPoint3Df tmp2 = m_panel.Screen2World2D(m_panel.Width/2+m_marker.Size,m_panel.Height/2+m_marker.Size,0.5f); 
                    //Glu.UnProject(tmp1,opan.ModelviewMatrix,opan.ProjectionMatrix,opan.ViewMatrix,out tmp1); 
                    //Glu.UnProject(tmp2,opan.ModelviewMatrix,opan.ProjectionMatrix,opan.ViewMatrix,out tmp2); 
                    ILClippingData clip = m_panel.Limits; 
                    float s05x = Math.Abs(m_marker.Size * clip.WidthF / (m_panel.ClientSize.Width - m_panel.m_cubeMargin * 2)); 
                    float s05y = Math.Abs(m_marker.Size * clip.HeightF / (m_panel.ClientSize.Height - m_panel.m_cubeMargin * 2)); 

                    #endregion
                    // draw all markers using quads. 
                    // this is slow! Todo: replace by point sprites! 
                    GL.Begin(BeginMode.Quads); 
                    for (int i = 0; i < m_vertCount; i++) {
                        w = m_vertexArray[i*2]; 
                        h = m_vertexArray[i*2+1];           
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
            }
            #endregion
        }
        public override void Dispose() {
            m_isReady = false; 
            if (m_vertexArray != null)
                ILNumerics.Misc.ILMemoryPool.Pool.RegisterObject(m_vertexArray); 
            m_vertexArray = null;
        }
        /// <summary>
        /// (re)create vertex buffer, line-, texture objects
        /// </summary>
        protected override void Configure() {
            // create data array 
            //System.Diagnostics.Debug.WriteLine("ILOGLGraphPlot2D_configure"); 
            Dispose(); 
            //IGraphicsContext context = (m_panel as ILOGLPanel).Context; 
            //if ( context == null || !context.IsCurrent)
            //    return; 
            try {
                // construct data suitable for GL.InterleavedArrays (V2F) -> 
                // each vertex has only 2 coords: x,y
                // layed behind each other sequentially (interleaved)
                m_vertexArray = ILNumerics.Misc.ILMemoryPool.Pool.New<float>(m_vertCount * 2); 
                Transform2D(); 
            } catch (Exception) {}
        }

        protected override void m_marker_Changed(object sender, EventArgs e) {
            base.m_marker_Changed(sender, e);
        }

        private void CacheMarkerBitmap() {
            ILTextureManager mana = m_panel.TextureManager;
            string key = ILMarker.Hash(m_marker.Style,m_marker.Bitmap);
            Bitmap markerbmp = ILMarker.BitmapFromStyle(m_marker);
            // we need it in format Argb!
            mana.StoreTextureItem(key, markerbmp);
        }


        #endregion
    }
}
