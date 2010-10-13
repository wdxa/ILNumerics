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
using System.Data;
using System.Windows.Forms;
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions;
using ILNumerics.Drawing.Controls;
using System.Resources; 
using OpenTK; 
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics; 
using OpenTK.Graphics.OpenGL.Enums; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Platform.OpenGL; 
using ILNumerics.Drawing.Internal; 
using ILNumerics.Drawing.Misc; 
using ILNumerics.Misc; 
using VERTEXTYPEDEF = ILNumerics.Drawing.Platform.OpenGL.ILOGLSurfaceGraph.VertexC4N3V3; 

namespace ILNumerics.Drawing.Platform.OpenGL
{
    /// <summary>
    /// OpenGL implementation for ILSurfaceGraph
    /// </summary>
    public class ILOGLSurfaceGraph : ILSurfaceGraph {
        
        #region attributes
        protected float[] m_vertices;
        protected ShadingStyles m_oldShading; 
        protected ILColormap m_oldColormap; 
        #endregion


        #region vertex definition
        /// <summary>
        /// Vertex definition: 4Color, 3Normal, 3 Vertex - all float
        /// </summary>
        /// <remarks>CAUTION! The vertex is not usable with OpenGL via vartex arrays this way!
        /// We had to recognize sporadic crashs when drawing this way! Todo: ... to be investigated.</remarks>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct VertexC4N3V3 {
            public float CR;
            public float CG;
            public float CB; 
            public float CA; 
            public float Nx; 
            public float Ny;
            public float Nz; 
            public float Vx; 
            public float Vy; 
            public float Vz; 
        }

        protected override void CreateVertices() {
            ILColormap colormap = m_panel.Colormap; 
            if (m_vertices == null) {
                m_vertices = ILMemoryPool.Pool.New<float>(m_Vertcount*40); 
            }
            float val = 0.0f; 
            float minZ = m_globalClipping.ZMin, minC = (m_colors == null)? 0.0f : m_colors.MinValue; 
            float maxZ = m_globalClipping.ZMax; 
            bool useColorArray = !object.Equals(m_colors,null); 
            float a;
            if (useColorArray)
                a = colormap.Length / (m_colors.MaxValue - minC);
            else {
                if (maxZ - minZ != 0.0f)
                    a = colormap.Length / (maxZ - minZ);
                else
                    a = 0.0f;
            }
            int curVertPos = 0, curVecPos = 0; 
            if (m_shading == ShadingStyles.Interpolate) {
                #region shading interpolate
                for (int r = 0; r < m_rows; r++) {
                    for (int c = 0; c < m_cols; c++) {
                        curVecPos = r + c * m_rows; 
                        val = m_sourceArray.GetValue(r,c);
                        // set color values 
                        if (useColorArray)
                            colormap.Map((m_colors.GetValue(curVecPos) - minC) * a, m_vertices, ref curVertPos);
                        else {
                            if (a != 0) {
                                colormap.Map((val - minZ) * a, m_vertices, ref curVertPos);
                            } else {
                                // plane: minz == maxz
                                colormap.Map(colormap.Length / 2, m_vertices, ref curVertPos);
                            }
                        }
                        m_vertices[curVertPos++] = m_opacity;
                        curVertPos += 3; 
                        m_vertices[curVertPos++] = m_xCoords[curVecPos]; 
                        m_vertices[curVertPos++] = m_yCoords[curVecPos]; 
                        m_vertices[curVertPos++] = val;
                    }
                }
                #endregion
            } else if (m_shading == ShadingStyles.Flat) {
                #region shading flat
                /**  Consider a surface area like this: 
                 * 
                 *  8 - 9 -10 -11
                 *  | / | / | / |
                 *  4 - 5 - 6 - 7
                 *  | / | / | / | 
                 *  0 - 1 - 2 - 3
                 * 
                 *  The rectangle surrounded by 0-1-4-5 is than colored by the 
                 *  vertex 5. This rectangle will be assembled by 2 triangles: 
                 *  0-1-5 and 0-4-5. Therefore the color for both rectangles 
                 *  is the same and must be stored in the vertex No.5. 
                 *  The vertices can be assembled in natural order, beginning 
                 *  with 0 and approching m_vertexCount-1. The color for flat 
                 *  shading is averaged over the neighbor corners of each
                 *  rectangle. In our Example the color stored in 5 is averaged 
                 *  over the values of the vertices 0,1,4 and 5. The first row 
                 *  and the first column are not used for the surface. However
                 *  it may _be_ used for the wireframe grid if that is drawn with 
                 *  interpolated colors (Wireframe.Color.IsEmpty). So we must 
                 *  prepare the color for it -> here we just take the value itself.
                 */
                // first row: no color average
                for (int c = 0; c < m_cols; c++) {
                    val = m_sourceArray.GetValue(0,c);
                    if (useColorArray)
                        colormap.Map((m_colors.GetValue(0,c) - minC) * a, m_vertices,ref curVertPos); 
                    else 
                        colormap.Map((val - minZ) * a, m_vertices,ref curVertPos); 
                    m_vertices[curVertPos++] = m_opacity;
                    curVertPos += 3; 
                    m_vertices[curVertPos++] = m_xCoords[m_rows*c]; 
                    m_vertices[curVertPos++] = m_yCoords[m_rows*c]; 
                    m_vertices[curVertPos++] = val;
                }
                for (int r = 1; r < m_rows; r++) {
                    val = m_sourceArray.GetValue(r,0);
                    if (useColorArray)
                        colormap.Map((m_colors.GetValue(r) - minC) * a, m_vertices,ref curVertPos); 
                    else 
                        colormap.Map((val - minZ) * a, m_vertices,ref curVertPos); 
                    m_vertices[curVertPos++] = m_opacity;
                    curVertPos += 3; 
                    m_vertices[curVertPos++] = m_xCoords[r]; 
                    m_vertices[curVertPos++] = m_yCoords[r]; 
                    m_vertices[curVertPos++] = val;
                    // next columns: average color over precomputed corners
                    for (int c = 1; c < m_cols; c++) {
                        curVecPos = r + c * m_rows; 
                        val = m_sourceArray.GetValue(r,c);
                        val += m_sourceArray.GetValue(r-1,c); 
                        val += m_sourceArray.GetValue(r,c-1); 
                        val += m_sourceArray.GetValue(r-1,c-1); 
                        val /= 4;
                        if (useColorArray)
                            colormap.Map((m_colors.GetValue(curVecPos) - minC) * a, m_vertices,ref curVertPos); 
                        else 
                            colormap.Map((val - minZ) * a, m_vertices,ref curVertPos); 
                        m_vertices[curVertPos++] = m_opacity; 
                        curVertPos += 3; 
                        m_vertices[curVertPos++] = m_xCoords[curVecPos]; 
                        m_vertices[curVertPos++] = m_yCoords[curVecPos]; 
                        m_vertices[curVertPos++] = m_sourceArray.GetValue(r,c); 
                    }
                }
                #endregion
                m_oldColormap = colormap; 
            }
            #region create normals 
            // todo: depends on lighting enabled or not...! 
            // reset vertices pointer and start all over 
            curVertPos = 0; float nx,ny,nz;
            for (int r = 0; r < m_rows; r++) {
                for (int c = 0; c < m_cols; c++) {
                    nx= m_vertices[curVertPos+7];
                    ny= m_vertices[curVertPos+8];
                    nz= m_vertices[curVertPos+9];
                    if (c > 0) {
                        nx += m_vertices[curVertPos-3];
                        ny += m_vertices[curVertPos-2];
                        nz += m_vertices[curVertPos-1];
                    }
                    if (c < m_cols-1) { 
                        nx += m_vertices[curVertPos+17];
                        ny += m_vertices[curVertPos+18];
                        nz += m_vertices[curVertPos+19];
                    }
                    if (r > 0 && r < m_rows) {
                        nx += m_vertices[curVertPos-m_cols*10+10];
                        ny += m_vertices[curVertPos-m_cols*10+11];
                        nz += m_vertices[curVertPos-m_cols*10+12];
                    }
                    if (r < m_rows - 1) { 
                        nx += m_vertices[curVertPos+m_cols*10+10];
                        ny += m_vertices[curVertPos+m_cols*10+11];
                        nz += m_vertices[curVertPos+m_cols*10+12];
                    }
                    // normalize
                    float len = (float)Math.Sqrt(nx*nx+ny*ny+nz*nz); 
                    m_vertices[curVertPos+4] = nx / len; 
                    m_vertices[curVertPos+5] = ny / len; 
                    m_vertices[curVertPos+6] = nz / len; 
                    curVertPos+=10; 
                }
            }
            #endregion
            m_oldShading = m_shading; 
            m_vertexReady = true;
        }


        #endregion

        #region constructor
        public ILOGLSurfaceGraph (  ILOGLPanel panel, ILBaseArray X,
                                    ILBaseArray Y, ILBaseArray Z, ILBaseArray C,
                                    ILClippingData clippingContainer) 
                              : base(panel,X,Y,Z,C,clippingContainer) {
            m_indexReady = false; 
            m_vertexReady = false; 
        }

        #endregion

        #region abstract interface
        /// <summary>
        /// Dispose off this graph's vertices
        /// </summary>
        public override void Dispose() {
            base.Dispose(); 
            if (m_vertices != null) {
                ILMemoryPool.Pool.RegisterObject<float>(m_vertices); 
            }
        }
        /// <summary>
        /// Draw the graph
        /// </summary>
        public override void Draw(ILRenderProperties p) {
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha);            
            ILLineProperties wireprops = m_wireLines;
            ILOGLPanel.SetupLineStyle(wireprops);
            unsafe {
                fixed (float* pVertices = m_vertices) {
                    // populate vertex array to GL
                    GL.InterleavedArrays(InterleavedArrayFormat.C4fN3fV3f
                                         ,0,(IntPtr)pVertices); 
                    // general setup shading & transparency
                    if (m_shading == ShadingStyles.Interpolate) {                      
                        GL.ShadeModel(ShadingModel.Smooth);
                        //GL.Disable(EnableCap.DepthTest);
                    } else {
                        GL.ShadeModel(ShadingModel.Flat); 
                        //if (m_opacity < 1.0f) 
                        //else
                        //    GL.Enable(EnableCap.DepthTest);
                    }
                    GL.Enable(EnableCap.DepthTest);
                    
                    
                    if (m_opacity == 1.0f && m_shading == ShadingStyles.Interpolate) {
                        #region no transpareny
                        GL.Disable(EnableCap.Blend); 
                        GL.Enable(EnableCap.DepthTest); 
                        fixed (UInt32* pGridIndices = m_gridIndices)
                        fixed (UInt32* pIndices = m_indices) {
                            UInt32* pGridIndWalk = pGridIndices; 
                            // first surface strip
                            if (m_filled) {
                                GL.DrawElements(BeginMode.TriangleStrip,m_stripesLen,
                                                DrawElementsType.UnsignedInt,
                                                (IntPtr)pIndices);
                            }    
                            // first grid strip
                            if (m_wireLines.Visible) {
                                if (!wireprops.Color.IsEmpty) {
                                    // if a color was specified, use it for wireframes!
                                    GL.DisableClientState(EnableCap.ColorArray);
                                    //GL.Color3(wireprops.ForeColor); // color for grid lines  
                                }
                                GL.DrawElements(BeginMode.Lines,
                                            m_gridStripsLen + m_gridStripsLenOnce, // 2*(m_cols-1),
                                            DrawElementsType.UnsignedInt,
                                            (IntPtr)pGridIndWalk);
                                pGridIndWalk += (m_gridStripsLen + m_gridStripsLenOnce); 
                                if (!wireprops.Color.IsEmpty) {
                                    GL.EnableClientState(EnableCap.ColorArray); 
                                }
                            }
                            for (int i = 1; i < m_stripesCount; i++) {
                                // subsequent surface strips
                                if (m_filled) {
                                    GL.DrawElements(BeginMode.TriangleStrip,
                                                    m_stripesLen,
                                                    DrawElementsType.UnsignedInt,
                                                    (IntPtr)(pIndices+i*m_stripesLen));
                                }
                                // subsequent grid strips 
                                if (m_wireLines.Visible) {
                                    GL.Disable(EnableCap.Blend); 
                                    if (!wireprops.Color.IsEmpty) {
                                        // if a color was specified, use it for wireframes!
                                        GL.DisableClientState(EnableCap.ColorArray);
                                        //GL.Color3(wireprops.ForeColor); // color for grid lines  
                                    }
                                    GL.DrawElements(BeginMode.Lines,
                                                m_gridStripsLen,
                                                DrawElementsType.UnsignedInt,
                                                (IntPtr)(pGridIndWalk));
                                    pGridIndWalk += m_gridStripsLen; 
                                    if (!wireprops.Color.IsEmpty) {
                                        GL.EnableClientState(EnableCap.ColorArray); 
                                    }
                                }
                            }
                            GL.Finish(); 
                        }
                        #endregion
                    } else {
                        #region transparency or flat shading 
                        GL.Enable(EnableCap.Blend); 
                        fixed (UInt32* pGridIndices = m_gridIndices)
                        fixed (UInt32* pIndices = m_indices) {
                            UInt32* pGridIndWalk = pGridIndices; 
                            // first surface strip
                            if (m_filled) {
                                GL.DrawElements(BeginMode.Triangles,m_stripesLen,
                                                DrawElementsType.UnsignedInt,
                                                (IntPtr)pIndices);
                            }    
                            // first grid strip
                            if (m_wireLines.Visible) {
                                GL.Disable(EnableCap.Blend); 
                                if (!wireprops.Color.IsEmpty) {
                                    // if a color was specified, use it for wireframes!
                                    GL.DisableClientState(EnableCap.ColorArray);
                                    GL.Color3(m_wireLines.Color); 
                                }
                                GL.DrawElements(BeginMode.Lines,
                                            m_gridStripsLen + m_gridStripsLenOnce,
                                            DrawElementsType.UnsignedInt,
                                            (IntPtr)pGridIndWalk);
                                pGridIndWalk += m_gridStripsLen + m_gridStripsLenOnce; 
                                if (!wireprops.Color.IsEmpty) {
                                    // if a color was specified, use it for wireframes!
                                    GL.EnableClientState(EnableCap.ColorArray); 
                                }
                                GL.Enable(EnableCap.Blend); 
                            }
                            for (int i = 1; i < m_stripesCount; i++) {
                                // subsequent surface strips
                                if (m_filled) {
                                    GL.DrawElements(BeginMode.Triangles,
                                                    m_stripesLen,
                                                    DrawElementsType.UnsignedInt,
                                                    (IntPtr)(pIndices+i*m_stripesLen));
                                }
                                // subsequent grid strips 
                                if (m_wireLines.Visible) {
                                    GL.Disable(EnableCap.Blend); 
                                    if (!wireprops.Color.IsEmpty) {
                                        // if a color was specified, use it for wireframes!
                                        GL.DisableClientState(EnableCap.ColorArray);
                                        GL.Color3(m_wireLines.Color); 
                                    }
                                    GL.DrawElements(BeginMode.Lines,
                                                m_gridStripsLen,
                                                DrawElementsType.UnsignedInt,
                                                (IntPtr)(pGridIndWalk));
                                    if (!wireprops.Color.IsEmpty) {
                                        GL.EnableClientState(EnableCap.ColorArray); 
                                    }
                                    GL.Enable(EnableCap.Blend); 
                                    pGridIndWalk += m_gridStripsLen; 
                                }
                            }
                            GL.Finish(); 
                        }
                        #endregion
                    }
                }
            }
            //GL.Disable(EnableCap.Lighting);
            //GL.PopMatrix(); 
        }
        /// <summary>
        /// Ensures the recreation of the graph if neccessary
        /// </summary>
        public override void Invalidate() {
            if (m_panel == null) return; 
            if (Math.Floor(m_panel.Camera.Phi / (Math.PI / 4.0)) != m_oldSubQuadrant) {    
                //must only recalculate indices, and only if the camera subquadrant has changed
                m_indexReady = false; 
                m_isReady = false; 
            } 
            if (m_oldShading != m_shading) {
                m_indexReady = false; 
                m_vertexReady = false; 
                m_isReady = false; 
            }
            if (m_oldColormap != m_panel.Colormap) {
                m_vertexReady = false; 
                m_isReady = false; 
            }
        }
        public override void DrawToLegend(ILRenderProperties p, Rectangle sampleRect, Rectangle labelRect) {
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
            m_label.Anchor = new PointF(.5f,0);  //  = TickLabelAlign.center | TickLabelAlign.vertCenter; 
            m_label.Draw(p); 
        }
        #endregion

        #region helper function 

        protected override void m_globalClipping_Changed(object sender, ClippingChangedEventArgs e) {
            base.m_globalClipping_Changed(sender, e);
            m_vertexReady = false; 
            m_indexReady = false; 
            Configure(); 
        }
        
        #endregion
    }
}
