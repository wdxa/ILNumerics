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

namespace ILNumerics.Drawing.Internal
{
    public class ILOGLPlot2DGraph : ILPlot2DGraph {

        #region attributes 

        protected float[] m_vertexArray;
        protected int m_vertCount;
        protected int m_primCount; 
        protected IGraphicsContext m_context;  
        protected int m_textureName = 0; 

        #endregion

        #region constructors 

        internal ILOGLPlot2DGraph  ( IGraphicsContext context, ILBaseArray sourceArray,
                                  ILClippingData clippingContainer) 
                                : base(sourceArray,clippingContainer) {
            m_context = context; 
            if (sourceArray.Dimensions.NonSingletonDimensions != 1)
                throw new ILArgumentException ("Plot2D: supplied data must be a real vector!"); 
            create();
        }
        internal ILOGLPlot2DGraph  ( IGraphicsContext context, ILBaseArray xData, ILBaseArray yData,
                                  ILClippingData clippingContainer) 
                                : base(xData, yData, clippingContainer) {
            m_context = context; 
            if (yData.Dimensions.NonSingletonDimensions != 1)
                throw new ILArgumentException ("Plot2D: supplied data must be a real vector!"); 
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
                m_localClipping.m_xMin = m_xData.GetValue(0); 
                m_localClipping.m_zMax = 0.0f; 
                m_localClipping.m_zMin = 0.0f; 
                m_vertexArray[0] = 0.0f; 
                m_vertexArray[1] = (float)(valY); 
           }
           m_isReady = true; 
        }

        private void uploadTextures() {
            // assumes the GL context to be current
            Bitmap marker = Resources.Markers.Triangle; 
            GL.GenTextures(1, out m_textureName);
            GL.BindTexture(TextureTarget.Texture2D, m_textureName);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            BitmapData markerData = marker.LockBits(new Rectangle(0,0,marker.Size.Width,marker.Height),System.Drawing.Imaging.ImageLockMode.ReadOnly,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Alpha, 
                            marker.Size.Width, marker.Size.Height, 0,
                            OpenTK.Graphics.OpenGL.PixelFormat.Rgba, 
                            PixelType.UnsignedByte, (IntPtr)markerData.Scan0);
            marker.UnlockBits(markerData); 
            //unsafe {
            //int[] textureData = new int[marker.Size * marker.Height]; 
                //fixed (int* pMarkerData = (int*)markerData.Scan0)
                //fixed (int* pTextureData = (int*)textureData) {
                //    int pos = 0; 
                //    for (int r = 0; r < marker.Size.Height; r++) {
                //        for (int c = 0; c < marker.Size.Width; c++) {
                //            pos = r * marker.Size.Width + c; 
                //            *(pTextureData + pos) = *(pMarkerData + pos); 
                //        }
                //    }
                //GL.TexSubImage2D(TextureTarget.Texture2D, 0, rect.Left, rect.Top, rect.Width, rect.Height,
                //                 PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)markerData.Scan0);

                //}
            //}

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
            #region draw points
            if (m_marker.Style != MarkerStyle.None) {
                ILOGLPanel.SetupMarkerStyle(m_marker); 
                //if (m_textureName == 0) {
                //    uploadTextures(); 
                //}
                //if (m_marker.Style == MarkerStyle.Triangle) {
                //    GL.BindTexture(TextureTarget.Texture2D,m_textureName); 
                //    //GL.PointParameter(PointParameterName.PointSpriteCoordOrigin,4);
                //    //GL.Enable(EnableCap.Texture2D); 
                //}
                unsafe { 
                    fixed(float* pVertArr = m_vertexArray) {
                        GL.TexCoord2(0.5,0.5); 
                        GL.InterleavedArrays(InterleavedArrayFormat.V2f,0,(IntPtr)(float*)pVertArr); 
                        GL.DrawArrays(BeginMode.Points,0,m_vertCount); 
                    }
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
            if (m_context == null || !m_context.IsCurrent)
                return; 
            try {
                // construct data suitable for GL.InterleavedArrays (V2F) -> 
                // each vertex has only 2 coords: x,y
                // layed behind each other sequentially (interleaved)
                m_vertexArray = ILNumerics.Misc.ILMemoryPool.Pool.New<float>(m_vertCount * 2); 
                Transform2D(); 
            } catch (Exception) {}
        }
        #endregion
    }
}
