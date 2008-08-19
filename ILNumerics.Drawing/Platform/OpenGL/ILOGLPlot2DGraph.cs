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
using ILNumerics.Drawing.Interfaces; 

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
            if (m_properties.Visible) {
                GL.Color3(m_properties.Color); 
                int stipFactr = 1;  
                LineStyle style = m_properties.Style;
                short stipple; 
                if (m_properties.Style != LineStyle.UserPattern) 
                    stipple = ILNumerics.Drawing.Controls.ILPanel.StippleFromLineStyle(style, ref stipFactr);
                else 
                    stipple = m_properties.Pattern; 
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple((int)m_properties.PatternScale,stipple);
                GL.LineWidth(m_properties.Width); 
                if (m_properties.Antialiasing)
                    GL.Enable(EnableCap.LineSmooth);
                else 
                    GL.Disable(EnableCap.LineSmooth); 
                GL.Disable(EnableCap.Blend); 
                GL.Disable(EnableCap.Texture2D);
                unsafe { 
                    fixed(float* pVertArr = m_vertexArray) {  
                        GL.InterleavedArrays(InterleavedArrayFormat.V2f,0,(IntPtr)(float*)pVertArr); 
                        GL.DrawArrays(BeginMode.LineStrip,0,m_vertCount); 
                    }
                }
            }
            #endregion
            #region draw markers
            if (m_marker.Visible) { 
                m_marker.Shape.Draw(m_marker, m_vertexArray, m_vertCount);
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

        public override void DrawToLegend(Graphics g, Rectangle sampleArea, Rectangle labelArea) {
            if (g != null) {
                // bitmap output is handled by base class
                base.DrawToLegend(g, sampleArea, labelArea);
                return; 
            }
            int sampY = (int)(sampleArea.Top + sampleArea.Height / 2.0f);
            #region draw line
            if (m_properties.Visible) {
                ILNumerics.Drawing.Platform.OpenGL.ILOGLPanel.SetupLineStyle(m_properties); 
                GL.Begin(BeginMode.Lines); 
                GL.Vertex2(sampleArea.Left,sampY); 
                GL.Vertex2(sampleArea.Right,sampY); 
                GL.End();
            }
            #endregion

            #region draw marker 
            if (m_marker.Visible) {
                m_marker.Shape.Draw(m_marker,new float[]{sampleArea.Left + sampleArea.Width / 2.0f,sampY},-1);
            }
            #endregion
            //GL.Vertex2(sampleArea.Right,sampleArea.Bottom); 
            //GL.Vertex2(sampleArea.Left,sampleArea.Bottom); 
            m_label.m_position.X = labelArea.X + labelArea.Width / 2;
            m_label.m_position.Y = labelArea.Y + labelArea.Height / 2; 
            m_label.m_alignment = TickLabelAlign.center | TickLabelAlign.vertCenter; 
            m_label.Draw(null); 
        }
        #endregion
    }
}
