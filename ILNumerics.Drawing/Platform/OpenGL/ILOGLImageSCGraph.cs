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
using System.Drawing; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls;
using OpenTK; 
using OpenTK.Graphics; 
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL.Enums; 
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Internal;
using ILNumerics.Drawing.Misc;
using ILNumerics.Misc;   
using VERTEXTYPEDEF = ILNumerics.Drawing.Platform.OpenGL.ILOGLImageSCGraph.VertexC4V2; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// OpenGL implementation for ILImageSCGraph
    /// </summary>
    public class ILOGLImageSCGraph : ILImageSCGraph {

        #region attributes
        protected VERTEXTYPEDEF[] m_vertices;
        #endregion

        #region vertex definition
        /// <summary>
        /// Vertex definition: 4Color (uint), 2 Vertex (float)
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        [System.Diagnostics.DebuggerDisplay("RGBA:{CR},{CG},{CB},{CA} (X,Y)=({Vx},{Vy})", Name="Vertex")]
        public struct VertexC4V2 {
            public byte CR;
            public byte CG;
            public byte CB; 
            public byte CA; 
            public float Vx; 
            public float Vy; 
        }
        #endregion

        #region constructors 
        public ILOGLImageSCGraph (ILOGLPanel panel, ILBaseArray X,
                                  ILBaseArray Y,ILBaseArray Z,ILBaseArray C,  
                                 ILClippingData clippingContainer) 
             : base(panel,X,Y,Z,C, clippingContainer) { 
            m_panel = panel; 
            m_localClipping.m_zMax = 0; 
            m_localClipping.m_zMin = 0; 
            m_localClipping.m_xMax = (float)m_cols+0.5f;
            m_localClipping.m_xMin = -0.5f; 
            m_localClipping.m_yMax = (float)m_rows+0.5f; 
            m_localClipping.m_yMin = -0.5f; 
        }
        #endregion 

        #region helper functions
        protected override void CreateVertices() {
            ILColormap colormap = m_panel.Colormap;  
            if (m_vertices == null) {
                m_vertices = ILMemoryPool.Pool.New<VERTEXTYPEDEF>(m_Vertcount); 
            }
            float val = 0.0f; 
            float minZ = m_sourceArray.MinValue; 
            float maxZ = m_sourceArray.MaxValue; 
            float a = colormap.Length / (maxZ - minZ);
            byte ca = (byte)(m_opacity * 255); 
            VERTEXTYPEDEF curVertex; int i = 0; 
            // first row is special (no color, just for grid)
            for (int c = 0; c < m_cols-1; c++) {
                curVertex = new VERTEXTYPEDEF(); 
                curVertex.Vx = c-0.5f; 
                curVertex.Vy = -0.5f; 
                curVertex.CA = ca; 
                val = m_sourceArray.GetValue(0,c); 
                colormap.Map((val - minZ) * a,
                    out curVertex.CR, out curVertex.CG,out curVertex.CB); 
                m_vertices[i++] = curVertex;  
            }
            // right corner
            curVertex = new VERTEXTYPEDEF(); 
            curVertex.Vx = m_cols-1.5f; 
            curVertex.Vy = -0.5f; 
            curVertex.CA = ca; 
            colormap.Map((val - minZ) * a,
                out curVertex.CR, out curVertex.CG,out curVertex.CB); 
            m_vertices[i++] = curVertex;  
            for (int r = 0; r < m_rows-1; r++) {
                // first col part is special (no color)
                curVertex = new VERTEXTYPEDEF(); 
                curVertex.Vx = -0.5f; 
                curVertex.Vy = r+0.5f; 
                curVertex.CA = ca; 
                colormap.Map((m_sourceArray.GetValue(r,0) - minZ) * a,
                    out curVertex.CR, out curVertex.CG,out curVertex.CB); 
                m_vertices[i++] = curVertex;  
                for (int c = 0; c < m_cols-1; c++) {
                    curVertex = new VERTEXTYPEDEF(); 
                    val = m_sourceArray.GetValue(r,c);
                    // set color values 
                    colormap.Map((val- minZ) * a,
                        out curVertex.CR, out curVertex.CG,out curVertex.CB); 
                    curVertex.CA = ca; 
                    curVertex.Vx = c+0.5f; 
                    curVertex.Vy = r+0.5f; 
                    m_vertices[i++] = curVertex; 
                }
            }
            m_vertexReady = true;
        }
        protected override void m_globalClipping_Changed(object sender, ClippingChangedEventArgs e) {
            base.m_globalClipping_Changed(sender, e);
            //m_vertexReady = false; 
            //m_indexReady = false; 
        }
        #endregion

        #region public interface 
        /// <summary>
        /// Draws the graph into existing context
        /// </summary>
        public override void Draw() {
            if (m_panel.Camera.Rho > Math.PI/2) return; 
            if (!m_isReady)
                Configure(); 
            float zPos = m_zPosition; 
            if (zPos == float.PositiveInfinity) {
                zPos = m_panel.Limits.m_zMax;
            } else if (zPos == float.NegativeInfinity) {
                zPos = m_panel.Limits.m_zMin;
            }
            GL.Translate(0.0f, 0.0f, zPos); 
            GL.Enable(EnableCap.Blend); 
            GL.Disable(EnableCap.DepthTest); 
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha);            
            GL.ShadeModel(ShadingModel.Flat); 
            unsafe {
                fixed (VERTEXTYPEDEF* pVertices = m_vertices) {
                    GL.InterleavedArrays(
                           InterleavedArrayFormat.C4ubV2f,0,(IntPtr)pVertices); 
                    if (m_filled) {
                        fixed (UInt32* pIndices = m_indices) {
                            for (int i = 0; i < m_stripesCount; i++) {
                                GL.DrawElements(BeginMode.Triangles,m_stripesLen,
                                    DrawElementsType.UnsignedInt,
                                    (IntPtr)(pIndices+i*m_stripesLen));
                            }
                            GL.Finish();
                        }
                    }
                    #region draw grid
                    if (m_wireLines.Visible) {
                        if (m_wireLines.Style == LineStyle.Solid) {
                            GL.Disable(EnableCap.LineStipple);
                        } else {
                            int stipFactr = 1;  
                            short stipple; 
                            if (m_wireLines.Style != LineStyle.UserPattern) 
                                stipple = ILPanel.StippleFromLineStyle(
                                          m_wireLines.Style, ref stipFactr);
                            else 
                                stipple = m_wireLines.Pattern; 
                            GL.Enable(EnableCap.LineStipple);
                            GL.LineStipple((int)m_wireLines.PatternScale,stipple);
                        }
                        if (m_wireLines.Antialiasing)
                            GL.Enable(EnableCap.LineSmooth);
                        else
                            GL.Disable(EnableCap.LineSmooth);
                        GL.Disable(EnableCap.Blend); 
                        GL.LineWidth(m_wireLines.Width); 
                        if (m_wireLines.Color != System.Drawing.Color.Empty) {
                            GL.DisableClientState(EnableCap.ColorArray);
                            GL.Color3(m_wireLines.Color); 
                        } 
                        fixed (UInt32* pIndices = m_gridIndices) { 
                            GL.DrawElements(BeginMode.Lines,
                                        m_gridIndicesCount,
                                        DrawElementsType.UnsignedInt,
                                        (IntPtr)pIndices);
                            GL.Finish();
                        }
                    }
                    #endregion
                }
            }
            GL.Translate(0.0f, 0.0f, -zPos); 
        }
        /// <summary>
        /// Dispose off this graph's vertices
        /// </summary>
        public override void Dispose() {
            base.Dispose(); 
            if (m_vertices != null) {
                ILMemoryPool.Pool.RegisterObject<VERTEXTYPEDEF>(m_vertices); 
            }
        }
        /// <summary>
        /// Ensures the recalculation of vertices if neccessary
        /// </summary>
        public override void Invalidate() {
            if (Math.Floor(m_panel.Camera.Phi / (Math.PI / 4.0)) != m_oldSubQuadrant) {    
                //must only recalculate indices, and only if the camera subquadrant has changed
                m_indexReady = false; 
                m_isReady = false; 
            }
        }
        public override void DrawToLegend(Graphics graphics, Rectangle sampleRect, Rectangle labelRect) {
            if (m_filled) {
                // draw inner filled area
                GL.ShadeModel(ShadingModel.Smooth); 
                GL.Begin(BeginMode.TriangleStrip); 
                    GL.Color3(m_panel.Colormap[m_panel.Colormap.Length-1]); 
                    GL.Vertex2(sampleRect.X,sampleRect.Y + sampleRect.Height); 
                    GL.Color3(m_panel.Colormap[(int)(m_panel.Colormap.Length/2)]); 
                    GL.Vertex2(sampleRect.X,sampleRect.Y); 
                    GL.Vertex2(sampleRect.X+sampleRect.Width,sampleRect.Y + sampleRect.Height); 
                    GL.Color3(m_panel.Colormap[0]); 
                    GL.Vertex2(sampleRect.X+sampleRect.Width,sampleRect.Y); 
                GL.End(); 
            } 
            if (m_wireLines.Visible) {
                ILNumerics.Drawing.Platform.OpenGL.ILOGLPanel.SetupLineStyle(m_wireLines); 
                GL.Begin(BeginMode.LineStrip); 
                    GL.Vertex2(sampleRect.X,sampleRect.Y); 
                    GL.Vertex2(sampleRect.X+sampleRect.Width,sampleRect.Y); 
                    GL.Vertex2(sampleRect.X+sampleRect.Width,sampleRect.Y + sampleRect.Height); 
                    GL.Vertex2(sampleRect.X,sampleRect.Y + sampleRect.Height); 
                    GL.Vertex2(sampleRect.X,sampleRect.Y); 
                GL.End(); 
            }
            m_label.m_position.X = labelRect.X + labelRect.Width / 2;
            m_label.m_position.Y = labelRect.Y + labelRect.Height / 2; 
            m_label.m_alignment = TickLabelAlign.center | TickLabelAlign.vertCenter; 
            m_label.Draw(null); 
        }

        #endregion 

    }
}
