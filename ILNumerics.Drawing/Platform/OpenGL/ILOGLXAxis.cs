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
    class ILOGLXAxis : ILOGLAxis {
        
        /// <summary>
        /// Constructor - this class should be created only from within ILNumerics assemblies! 
        /// </summary>
        /// <param name="clippingView">panels clipping view</param>
        /// <param name="layout">instance with layout informations</param>
        /// <param name="panel">the panel containing the axis</param>
        internal ILOGLXAxis (ILClippingData clippingView,
                            ILLayoutData layout,
                            ILOGLPanel panel)
            : base (AxisNames.XAxis,clippingView,layout,panel) {}

        /// <summary>
        /// draw all lines for the x axis 
        /// </summary>
        /// <param name="g">graphics object (ignored)</param>
        /// <param name="background">true: draw lines in the back only, false: draw foreground lines</param>
        protected override void iDrawAxis(ILRenderProperties p, bool background) {
            // create vertex data: main axis and ticks 
            if (m_visible) { 
                int count = 8; float tickLen;
                float scale,offse,x,y,z;
                tickLen = m_labeledTicks.TickFraction 
                    * ((m_labeledTicks.Direction == TickDirection.Inside)? 1.0f : -1.0f);
                // must draw ticks? 
                bool drawticks,drawLines = false; 
                if (m_labeledTicks.Display == TickDisplay.BothSides) {
                    drawticks = true; 
                } else {
                    drawticks = (background && !m_layoutData.CameraPosition.LooksFromTop) 
                              ||(!background && m_layoutData.CameraPosition.LooksFromTop);  
                }
                x = -0.5f; z = -0.5f; 
                // determine which axis to draw: find front
                if (!m_layoutData.CameraPosition.LooksFromFront) {
                    tickLen *= -1.0f; 
                    y = 0.5f; 
                } else {
                    y = -0.5f; 
                }
                if (background) {
                    if (m_farLines.Visible) {
                        ILOGLPanel.SetupLineStyle(m_farLines);
                        drawLines = true; 
                    }
                    y *= -1.0f; 
                    GL.Disable(EnableCap.DepthTest);
                    tickLen *= -1.0f;
                } else {
                    if (m_nearLines.Visible) {
                        ILOGLPanel.SetupLineStyle(m_nearLines); 
                        drawLines = true; 
                    }
                }
                if (drawLines) {
                    GL.Begin(BeginMode.Lines); 
                    GL.Vertex3(x,y,z); 
                    x = 0.5f;
                    GL.Vertex3(x,y,z); 
                    if (m_layoutData.CameraPosition.SinRho > 1e-5) {
                        z = 0.5f; 
                        GL.Vertex3(x,y,z); 
                        x = -0.5f;
                        GL.Vertex3(x,y,z); 
                    }
                    GL.End();
                }
                GL.Enable(EnableCap.DepthTest);
                if (drawticks) {
                    #region create ticks 
                    if (!m_layoutData.CameraPosition.LooksFromTop) {
                        //tickLen *= -1.0f;
                        //y *= -1.0f;
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
                    scale = m_clipping.ScaleToUnitCube().X; 
                    offse = m_clipping.CenterToUnitCube().X; 
                    GL.Disable(EnableCap.LineStipple); 
                    GL.Begin(BeginMode.Lines);
                    foreach (LabeledTick tick in m_labeledTicks) {
                        if (tick.Position >= m_clipping.XMin 
                            && tick.Position <= m_clipping.XMax) {
                            x = tick.Position * scale + offse; 
                            z = 0.5f; 
                            GL.Vertex3(x,y,z); 
                            y += tickLen; 
                            GL.Vertex3(x,y,z); 
                            z = -0.5f; 
                            GL.Vertex3(x,y,z); 
                            y -= tickLen; 
                            GL.Vertex3(x,y,z);
                        }
                    }
                    GL.End();
                    #endregion
                }
                if (background && m_grid.Visible) 
                    drawGrid();
            }
        }

        /// <summary>
        /// draw all grid lines for axis
        /// </summary>
        protected override void drawGrid() {
            float x,y,z;
            float scale, offset; 
            bool drawBottom = m_layoutData.CameraPosition.LooksFromTop; 
            ILOGLPanel.SetupLineStyle(m_grid); 
            GL.Disable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend); 
            GL.Begin(BeginMode.Lines);
            if (m_layoutData.CameraPosition.LooksFromFront) {
                y = 0.5f; 
            } else {
                y = -0.5f; 
            }
            scale = m_clipping.ScaleToUnitCube().X; 
            offset = m_clipping.CenterToUnitCube().X; 
            foreach (LabeledTick tick in m_labeledTicks) {
                if (tick.Position > m_clipping.XMin 
                    && tick.Position < m_clipping.XMax) {
                    x = tick.Position * scale + offset; 
                    z = 0.5f; 
                    GL.Vertex3(x,y,z); 
                    z = -0.5f; 
                    GL.Vertex3(x,y,z);
                    if (drawBottom) {
                        GL.Vertex3(x,y,z);
                        y *= -1.0f; 
                        GL.Vertex3(x,y,z); 
                        y *= -1.0f; 
                    }
                }
            }            
            GL.End(); 
        }



    }
}
