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
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Platform.OpenGL
{
    /// <summary>
    /// OpenGL implementation for ILPlot2DGraph
    /// </summary>
    public class ILOGLPlot2DGraph : ILPlot2DGraph {

        #region attributes 

        protected int m_textureName = 0; 
        protected float[] m_markerQuads; 

        #endregion

        #region constructors 

        internal ILOGLPlot2DGraph  ( ILPanel panel, ILBaseArray sourceArray,
                                  ILClippingData clippingContainer) 
                                : base(panel, sourceArray,clippingContainer) {
        }
        internal ILOGLPlot2DGraph  ( ILPanel panel, ILBaseArray xData, ILBaseArray yData,
                                  ILClippingData clippingContainer) 
                                : base(panel, xData, yData, clippingContainer) {
        }

        #endregion

        #region public (& abstract) interface 

        public override void Draw(ILRenderProperties p) {
            //System.Diagnostics.Debug.WriteLine("ILOGLGraphPlot2D_Draw"); 
            #region draw line
            // draw linestrip - simple case - fast vertex rendering 
            if (m_properties.Visible) {
                GL.Disable(EnableCap.Blend); 
                GL.Disable(EnableCap.Texture2D);
                ILOGLPanel.SetupLineStyle(m_properties); 
                unsafe { 
                    fixed(C4bV3f* pVertArr = m_vertices) {  
                        GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f,0,(IntPtr)pVertArr); 
                        if (m_properties.Color.IsEmpty) {
                            GL.ShadeModel(ShadingModel.Smooth); 
                        } else {
                            GL.ShadeModel(ShadingModel.Flat); 
                            GL.DisableClientState(EnableCap.ColorArray); 
                        }

                        if (m_startID < 2) {
                            GL.DrawArrays(BeginMode.LineStrip, m_startID, m_vertexCount-1);
                        } else {
                            GL.DrawArrays(BeginMode.LineStrip, m_startID, m_vertexCount-m_startID);
                            GL.DrawArrays(BeginMode.LineStrip, 0, m_startID);
                        }
                    }
                }
            }
            #endregion
            #region draw markers
            if (m_marker.Visible) { 
                m_marker.Shape.Draw(p, m_marker, m_vertices,0, m_vertexCount-1);
            }
            #endregion
        }
        public override void Dispose() {
            m_vertices = null;
        }
        /// <summary>
        /// (re)create vertex buffer, line-, texture objects
        /// </summary>
        public override void Configure() {
        }

        public override void DrawToLegend(ILRenderProperties p, Rectangle sampleArea, Rectangle labelArea) {
            if (p.Graphics != null) {
                // bitmap output is handled by base class
                base.DrawToLegend(p, sampleArea, labelArea);
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
                C4bV3f pos = new C4bV3f();
                pos.XPosition = sampleArea.Left + sampleArea.Width / 2.0f; 
                pos.YPosition = sampY; 
                m_marker.Shape.Draw(p, m_marker,new C4bV3f[] {pos},0,-1);
            }
            #endregion
            //GL.Vertex2(sampleArea.Right,sampleArea.Bottom); 
            //GL.Vertex2(sampleArea.Left,sampleArea.Bottom); 
            m_label.m_position.X = labelArea.X + labelArea.Width / 2;
            m_label.m_position.Y = labelArea.Y + labelArea.Height / 2;
            m_label.Anchor = new PointF(.5f, .5f);  //  = TickLabelAlign.center | TickLabelAlign.vertCenter; 
            m_label.Draw(p); 
        }
        #endregion
    }
}
