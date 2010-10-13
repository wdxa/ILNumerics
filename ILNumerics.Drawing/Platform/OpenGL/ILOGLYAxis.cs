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
using OpenTK; 
using OpenTK.Graphics; 
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics.OpenGL.Enums; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling; 


namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// OpenGL implementation of ILAxis (X axis)
    /// </summary>
    class ILOGLYAxis : ILOGLAxis {
        
        /// <summary>
        /// Constructor - this class should be created only from within ILNumerics assemblies! 
        /// </summary>
        /// <param name="clippingView">panels clipping view</param>
        /// <param name="layoutData">instance with layout informations</param>
        /// <param name="panel">the panel containing the axis</param>
        internal ILOGLYAxis (ILClippingData clippingView,
                            ILLayoutData layoutData,
                            ILOGLPanel panel)
            : base (AxisNames.YAxis,clippingView,layoutData,panel) { }

        /// <summary>
        /// draw all lines for the axis 
        /// </summary>
        /// <param name="p">render properties</param>
        /// <param name="background">true: draw lines in the back only, false: draw foreground lines</param>
        protected override void iDrawAxis(ILRenderProperties p, bool background) {
            // create vertex data: main axis and ticks 
            if (m_visible) { 
                float tickLen;
                float x, y, z
                    , xmin = m_clipping.XMin
                    , xmax = m_clipping.XMax
                    , ymin = m_clipping.YMin
                    , ymax = m_clipping.YMax
                    , zmin = m_clipping.ZMin
                    , zmax = m_clipping.ZMax;
                tickLen = m_labeledTicks.TickFraction
                    * ((m_labeledTicks.Direction == TickDirection.Inside) ? -m_clipping.WidthF : m_clipping.WidthF);
                // must draw ticks? 
                bool drawticks = false, drawlines = false; 
                if (m_labeledTicks.Display == TickDisplay.BothSides) {
                    drawticks = true; 
                } else {
                    drawticks = (background ^ m_layoutData.CameraPosition.LooksFromTop); 
                }
                y = ymin; z = zmin; 
                // determine which axis to draw: find front
                if (!m_layoutData.CameraPosition.LooksFromLeft && !m_layoutData.CameraPosition.Is2DView) {
                    x = xmax; 
                } else {
                    x = xmin; 
                    tickLen *= -1.0f; 
                }
                if (background) {
                    if (x == xmin) x = xmax; else x = xmin; 
                    tickLen *= -1.0f;
                    GL.Disable(EnableCap.DepthTest);
                    if (m_farLines.Visible) {
                        ILOGLPanel.SetupLineStyle(m_farLines);
                        drawlines = true; 
                    }
                } else {
                    if (m_nearLines.Visible) {
                        ILOGLPanel.SetupLineStyle(m_nearLines);
                        drawlines = true; 
                    }
                }
                if (drawlines) {
                    GL.Begin(BeginMode.Lines); 
                    GL.Vertex3(x,y,z); 
                    y = ymax; 
                    GL.Vertex3(x,y,z); 
                    if (m_layoutData.CameraPosition.SinRho > 1e-5) {
                        z = zmax; 
                        GL.Vertex3(x,y,z); 
                        y = ymin; 
                        GL.Vertex3(x,y,z); 
                    }
                    GL.End();
                }
                if (drawticks && drawlines) {
                    #region create ticks 
                    if (!m_layoutData.CameraPosition.LooksFromTop) {
                        //tickLen *= -1.0f;
                        //x *= -1.0f;
                        if (background) 
                            GL.Color3(m_labeledTicks.NearColor);
                        else 
                            GL.Color3(m_labeledTicks.FarColor); 
                    } else {
                        if (background) 
                            GL.Color3(m_labeledTicks.FarColor);
                        else 
                            GL.Color3(m_labeledTicks.NearColor); 
                    }
                    //scale = m_clipping.ScaleToUnitCube().Y; 
                    //offse = m_clipping.CenterToUnitCube().Y; 
                    GL.Enable(EnableCap.DepthTest);
                    GL.Disable(EnableCap.LineStipple); 
                    GL.Begin(BeginMode.Lines);
                    foreach (LabeledTick tick in m_labeledTicks) {
                        if (tick.Position >= ymin 
                            && tick.Position <= ymax) {
                            y = tick.Position;
                            if (m_layoutData.CameraPosition.SinRho > 1e-5) {
                                z = zmax;
                                GL.Vertex3(x, y, z);
                                x += tickLen;
                                GL.Vertex3(x, y, z);
                            } else {
                                x += tickLen;
                            }
                            z = zmin; 
                            GL.Vertex3(x,y,z); 
                            x -= tickLen;               
                            GL.Vertex3(x,y,z); 
                        }
                    }
                    GL.End();
                }
                if (background && m_grid.Visible) 
                    drawGrid(); 
                #endregion
            }
        }

        /// <summary>
        /// draw all grid lines for axis
        /// </summary>
        protected override void drawGrid() {
            GL.Color3(m_grid.Color); 
            float x,y,z;
            float zmax = m_clipping.ZMax;
            float zmin = m_clipping.ZMin;
            float xmin = m_clipping.XMin;
            float xmax = m_clipping.XMax;
            bool drawBottom = m_layoutData.CameraPosition.LooksFromTop; 
            ILOGLPanel.SetupLineStyle(m_grid);
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend); 
            GL.Begin(BeginMode.Lines);
            if (!m_layoutData.CameraPosition.LooksFromLeft) {
                x = xmin; 
            } else {
                x = xmax; 
            }
            foreach (LabeledTick tick in m_labeledTicks) {
                if (tick.Position >= m_clipping.YMin 
                    && tick.Position <= m_clipping.YMax) {
                    y = tick.Position;
                    if (!m_layoutData.CameraPosition.Is2DView) {
                        z = zmax;
                        GL.Vertex3(x, y, z);
                        z = zmin;
                        GL.Vertex3(x, y, z);
                    } else {
                        z = zmin; 
                    }
                    if (drawBottom) {
                        GL.Vertex3(x,y,z);
                        if (x == xmin) x = xmax; else x = xmin; 
                        GL.Vertex3(x,y,z);
                        if (x == xmin) x = xmax; else x = xmin;
                    }
                }
            }
            GL.End(); 
        }



    }
}
