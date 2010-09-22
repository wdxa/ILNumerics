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
    class ILOGLZAxis : ILOGLAxis {
        
        /// <summary>
        /// Constructor - this class should be created only from within ILNumerics assemblies! 
        /// </summary>
        /// <param name="clippingView">panels clipping view</param>
        /// <param name="layout">instance with layout informations</param>
        /// <param name="panel">the panel containing the axis</param>
        internal ILOGLZAxis (ILClippingData clippingView,
                            ILLayoutData layout,
                            ILOGLPanel panel)
            : base (AxisNames.ZAxis,clippingView,layout,panel) { }

        /// <summary>
        /// draw all lines for the axis 
        /// </summary>
        /// <param name="g">graphics object (ignored)</param>
        /// <param name="background">true: draw lines in the back only, false: draw foreground lines</param>
        protected override void iDrawAxis(ILRenderProperties p, bool background) {
            // create vertex data: main axis and ticks 
            if (!m_visible) return;  
            int count = 8; float tickLen;
            float scale, offse, x, y, z
                    , xmin = m_clipping.XMin
                    , xmax = m_clipping.XMax
                    , ymin = m_clipping.YMin
                    , ymax = m_clipping.YMax
                    , zmin = m_clipping.ZMin
                    , zmax = m_clipping.ZMax;
            tickLen = m_labeledTicks.TickFraction
                * ((m_labeledTicks.Direction == TickDirection.Inside) ? m_clipping.WidthF : -m_clipping.WidthF);
            //ConfigureOGLLineProperties(LineStyle.Solid,1); 
            // must draw ticks? 
            bool drawticks,drawlines = false; 
            if (m_labeledTicks.Display == TickDisplay.BothSides) {
                drawticks = true; 
            } else {
                drawticks = (background && !m_layoutData.CameraPosition.LooksFromTop) 
                          ||(!background && m_layoutData.CameraPosition.LooksFromTop);  
            }
            x = xmin; y = ymin; z = zmin; 
            float x2, y2, tickLen2 = tickLen;
            switch (m_layoutData.CameraPosition.Quadrant) {
                case CameraQuadrant.TopLeftFront: // Q1
                case CameraQuadrant.BottomLeftFront:
                    x = xmin;
                    x2 = xmin; 
                    y = ymax; 
                    y2 = ymin;
                    //tickLen2 *= -1.0f; 
                    break;
                case CameraQuadrant.TopLeftBack:  // Q2
                case CameraQuadrant.BottomLeftBack: 
                    x = xmax;
                    y = ymax; 
                    x2 = xmin; 
                    y2 = ymax; 
                    tickLen *= -1.0f; 
                    break;
                case CameraQuadrant.TopRightBack:   // Q3
                case CameraQuadrant.BottomRightBack:
                    x = xmax;
                    x2 = xmax; 
                    y = ymin; 
                    y2 = ymax;
                    tickLen *= -1.0f; 
                    tickLen2 *= -1.0f;
                    break;
                case CameraQuadrant.TopRightFront:
                case CameraQuadrant.BottomRightFront:  // Q4
                default:
                    x = xmin; 
                    x2 = xmax; 
                    y = ymin; 
                    y2 = ymin; 
                    tickLen2 *= -1.0f; 
                    break;
            }
            if (background) {
                if (x == xmin) x = xmax; else x = xmin;
                if (y == ymin) y = ymax; else y = ymin;
                if (x2 == xmin) x2 = xmax; else x2 = xmin;
                if (y2 == ymin) y2 = ymax; else y2 = ymin; 
                GL.Disable(EnableCap.DepthTest);
                if (m_farLines.Visible) {
                    drawlines = true; 
                    ILOGLPanel.SetupLineStyle(m_farLines);
                }
            } else {
                if (m_nearLines.Visible) {
                    drawlines = true; 
                    ILOGLPanel.SetupLineStyle(m_nearLines); 
                }
            }
            if (drawlines) {
                GL.Begin(BeginMode.Lines);
                GL.Vertex3(x,y,z); 
                z = zmax; 
                GL.Vertex3(x,y,z); 
                GL.Vertex3(x2,y2,z); 
                z = zmin; 
                GL.Vertex3(x2,y2,z);
                GL.End();
            }
            if (m_labeledTicks.Display == TickDisplay.BothSides || (!background && drawlines)) {
                #region create ticks 
                GL.Enable(EnableCap.DepthTest);
                if (background) {
                    GL.Color3(m_labeledTicks.FarColor);
                    tickLen *= -1.0f;
                    tickLen2 *= -1.0f;
                } else 
                    GL.Color3(m_labeledTicks.NearColor); 
                GL.Disable(EnableCap.LineStipple); 
                GL.Begin(BeginMode.Lines);
                foreach (LabeledTick tick in m_labeledTicks) {
                    if (tick.Position >= m_clipping.ZMin 
                        && tick.Position <= m_clipping.ZMax) {
                        z = tick.Position; 
                        GL.Vertex3(x,y,z); 
                        x += tickLen; 
                        GL.Vertex3(x,y,z); 
                        x -= tickLen; 
                        GL.Vertex3(x2,y2,z); 
                        x2 += tickLen2;               
                        GL.Vertex3(x2,y2,z); 
                        x2 -= tickLen2; 
                    }
                }
                GL.End();
                #endregion
            }
            if (background && m_grid.Visible) 
                drawGrid();
        }

        /// <summary>
        /// draw all grid lines for axis
        /// </summary>
        protected override void drawGrid() {
            float x1,y1,z;
            float x2,y2,x3,y3;
            float xmin = m_clipping.XMin;
            float ymin = m_clipping.YMin;
            float xmax = m_clipping.XMax;
            float ymax = m_clipping.YMax; 

            ILOGLPanel.SetupLineStyle(m_grid);
            GL.Disable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend); 
            GL.Begin(BeginMode.Lines);
            #region determine which side to draw on
            switch (m_layoutData.CameraPosition.Quadrant)
	        {
		        case CameraQuadrant.TopLeftFront:
                case CameraQuadrant.BottomLeftFront:
                    x1 = xmin; y1 = ymax;
                    x2 = xmax; y2 = ymax;
                    x3 = xmax; y3 = ymin; 
                    break;
                case CameraQuadrant.TopLeftBack:
                case CameraQuadrant.BottomLeftBack:
                    x1 = xmax; y1 = ymax;
                    x2 = xmax; y2 = ymin;
                    x3 = xmin; y3 = ymin; 
                    break;
                case CameraQuadrant.TopRightBack:
                case CameraQuadrant.BottomRightBack:
                    x1 = xmax; y1 = ymin;
                    x2 = xmin; y2 = ymin;
                    x3 = xmin; y3 = ymax; 
                    break;
                default:
                case CameraQuadrant.TopRightFront:
                case CameraQuadrant.BottomRightFront:
                    x1 = xmin; y1 = ymin;
                    x2 = xmin; y2 = ymax;
                    x3 = xmax; y3 = ymax; 
                    break;
	        }
            #endregion
            foreach (LabeledTick tick in m_labeledTicks) {
                if (tick.Position >= m_clipping.ZMin 
                    && tick.Position <= m_clipping.ZMax) {
                    z = tick.Position; 
                    GL.Vertex3(x1,y1,z); 
                    GL.Vertex3(x2,y2,z);
                    GL.Vertex3(x2,y2,z);
                    GL.Vertex3(x3,y3,z);
                }
            }            
            GL.End(); 
        }

    }
}
