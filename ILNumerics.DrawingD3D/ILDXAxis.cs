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
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.Internal {
    public sealed class ILDXAxis : ILAxis, IDisposable {
        private VertexBuffer m_vertexBuffer; 
        private int m_primitivCount; 
        private ILDXPanel m_dxPanel;

        public ILDXAxis (AxisNames name, ILClippingData clippingView, 
                        ILLayoutData layoutData,ILDXPanel panel) 
            : base (name,clippingView, layoutData) {
            m_dxPanel = panel; 
            m_dxPanel.GraphicsDeviceReset += new ILGraphicsDeviceResetEvent(recreateVertexBuffer);
            m_dxPanel.GraphicsDeviceCreated += new ILGraphicsDeviceCreatedEvent(initialize);
        }

        private void initialize(object sender, EventArgs args) {
            if (m_dxPanel == null || m_dxPanel.Device == null || m_dxPanel.Device.Disposed)
                return; 
            Dispose(); 
            m_primitivCount = (m_visible)? 
                (m_labeledTicks.Count + 1 + m_unLabeledTicks.Count) * 4 : 4;
        }

        public void Dispose()
        {
            m_invalidated = true; 
            if (m_vertexBuffer != null && !m_vertexBuffer.Disposed) {
                m_vertexBuffer.Dispose(); 
            }
            base.Dispose(); 
        }

        void recreateVertexBuffer(object sender, EventArgs e) {
            if (m_primitivCount > 0) {          
                createVertexBuffer(m_primitivCount);
                vertexBuffer_Created(this, null); 
            }
        }

        void  vertexBuffer_Created(object sender, EventArgs e) {
            // create vertex data: main axis and ticks 
            if (m_visible) { 
                int count = 8; float tickLen;
                CustomVertex.PositionColored vert; 
                CustomVertex.PositionColored[] vertices = (CustomVertex.PositionColored[]) m_vertexBuffer.Lock(0,0); 
                float scale,offse; 
                tickLen = m_labeledTicks.TickFraction; 
                switch (m_axisName) {
                    case AxisNames.XAxis:  
                        #region x axis 
                        vert.Color = m_nearLines.Color.ToArgb();
                        vert.X = -0.5f; // v u  
                        vert.Y = -0.5f;
                        vert.Z = -0.5f; 
                        vertices[0] = vert; 
                        vert.X = 0.5f;
                        vertices[1] = vert; 
                        vert.Y = 0.5f;
                        vertices[2] = vert; 
                        vert.X = -0.5f;
                        vertices[3] = vert; 
                        vert.Z = 0.5f; 
                        vertices[4] = vert; 
                        vert.X = 0.5f;
                        vertices[5] = vert; 
                        vert.Y = -0.5f;
                        vertices[6] = vert; 
                        vert.X = -0.5f;
                        vertices[7] = vert; 
                        // create ticks 
                        if (m_visible) {
                            scale = m_clipping.ScaleToUnitCube().X; 
                            offse = m_clipping.CenterToUnitCube().X; 
                            foreach (LabeledTick tick in m_labeledTicks) {
                                vert.X = tick.Position * scale + offse; 
                                vert.Y = 0.5f; 
                                vert.Z = 0.5f; 
                                vertices[count++] = vert; 
                                vert.Y += tickLen; 
                                vertices[count++] = vert; 
                                vert.Z = -0.5f; 
                                vertices[count++] = vert; 
                                vert.Y -= tickLen; 
                                vertices[count++] = vert; 
                                vert.Y = -0.5f; 
                                vertices[count++] = vert; 
                                vert.Y -= tickLen; 
                                vertices[count++] = vert; 
                                vert.Z = 0.5f; 
                                vertices[count++] = vert; 
                                vert.Y += tickLen; 
                                vertices[count++] = vert; 
                            }
                        }
                        break;
                        #endregion 
                    case AxisNames.YAxis: // y axis 
                        #region y axis 
                        vert.Color = m_nearLines.Color.ToArgb();  // l v 
                        vert.X = -0.5f; 
                        vert.Y = -0.5f;
                        vert.Z = -0.5f; 
                        vertices[0] = vert; 
                        vert.Y = 0.5f; 
                        vertices[1] = vert; 
                        vert.X = 0.5f; 
                        vertices[2] = vert; 
                        vert.Y = -0.5f; 
                        vertices[3] = vert; 
                        vert.Z = 0.5f; 
                        vertices[4] = vert; 
                        vert.Y = 0.5f; 
                        vertices[5] = vert; 
                        vert.X = -0.5f; 
                        vertices[6] = vert; 
                        vert.Y = -0.5f; 
                        vertices[7] = vert; 
                        // create ticks                           
                        if (m_visible) {
                            scale = m_clipping.ScaleToUnitCube().Y; 
                            offse = m_clipping.CenterToUnitCube().Y; 
                            foreach (LabeledTick tick in m_labeledTicks) {
                                vert.Color = m_nearLines.Color.ToArgb(); 
                                vert.X = 0.5f; 
                                vert.Y = tick.Position * scale + offse; 
                                vert.Z = 0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                                vert.X = -0.5f; 
                                vertices[count++] = vert; 
                                vert.X -= tickLen;               
                                vertices[count++] = vert; 
                                vert.Z = -0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                                vert.X = 0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                            }
                        }
                        break;
                        #endregion
                    case AxisNames.ZAxis: // z axis
                        #region z axis 
                        vert.Color = m_nearLines.Color.ToArgb();  // l u
                        vert.X = -0.5f;
                        vert.Y = -0.5f;
                        vert.Z = -0.5f;
                        vertices[0] = vert; 
                        vert.Z = 0.5f; 
                        vertices[1] = vert; 
                        vert.X = 0.5f; 
                        vertices[2] = vert; 
                        vert.Z = -0.5f; 
                        vertices[3] = vert; 
                        vert.Y = 0.5f; 
                        vertices[4] = vert; 
                        vert.Z = 0.5f; 
                        vertices[5] = vert; 
                        vert.X = -0.5f; 
                        vertices[6] = vert; 
                        vert.Z = -0.5f; 
                        vertices[7] = vert; 
                        // create ticks 
                        if (m_visible) {
                            scale = m_clipping.ScaleToUnitCube().Z; 
                            offse = m_clipping.CenterToUnitCube().Z; 
                            foreach (LabeledTick tick in m_labeledTicks) {
                                vert.Color = m_nearLines.Color.ToArgb(); 
                                vert.X = 0.5f; 
                                vert.Z = tick.Position * scale + offse; 
                                vert.Y = 0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                                vert.X = -0.5f; 
                                vertices[count++] = vert; 
                                vert.X -= tickLen;               
                                vertices[count++] = vert; 
                                vert.Y = -0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                                vert.X = 0.5f; 
                                vertices[count++] = vert; 
                                vert.X += tickLen; 
                                vertices[count++] = vert; 
                            }
                        }
                        break;
                        #endregion
                }
                m_vertexBuffer.Unlock();
                m_invalidated = false; 
            }
        }
        #region IILAxisPainter Members

        protected override void iDrawAxis(Graphics g, bool background)
        {
            // TODO: split rendering of background / foreground 
            // draw regular vertices 
            m_dxPanel.Device.RenderState.AntiAliasedLineEnable = true; 
            m_dxPanel.Device.SetStreamSource( 0, m_vertexBuffer, 0);
            m_dxPanel.Device.VertexFormat = CustomVertex.PositionColored.Format; 
            //m_DXdevice.RenderState.ZBufferEnable = true; 
            m_dxPanel.Device.DrawPrimitives(PrimitiveType.LineList,0,m_primitivCount);
        }
        /// <summary>
        /// hook called after the buffer has been swapped
        /// </summary>
        /// <param name="g"></param>
        protected override void iDrawLabel(Graphics g) {
            throw new NotImplementedException(); 
        }
        /// <summary>
        /// draw the labels for ticks 
        /// </summary>
        /// <param name="g">current graphics object</param>
        protected override void iDrawTickLabels(Graphics g) {
            // draw numbers
            if (m_visible) {
                // determine width & heigth of labels 
                System.Drawing.Point rect = new System.Drawing.Point(); 
                Point start = new Point(), end = new Point(); 
                TickLabelAlign align;
                //m_transformer.OptimalTickLabelLine(m_axisName,out start,out end, out align); 
                m_labeledTicks.TextRenderer.Alignment = m_labeledTicks.Alignment; 
                // draw labels 
                int axisIdx = Index; 
                float clipRange = m_clipping.Max[axisIdx] - m_clipping.Min[axisIdx]; 
                float multX = ((float)(end.X - start.X) / clipRange);
                float multY = ((float)(end.Y - start.Y) / clipRange);
                float tmp; Color c = m_labeledTicks.LabelColor;  
                foreach (LabeledTick lt in m_labeledTicks) {
                    if (! String.IsNullOrEmpty( lt.Label)) {
                        tmp = lt.Position-m_clipping.Min[axisIdx]; 
                        rect.X = (int)(start.X + multX * tmp); 
                        rect.Y = (int)(start.Y + multY * tmp); 
                        m_labeledTicks.TextRenderer.Draw(lt.Label,rect,c);
                    }
                } 
            }
            return; 
        }
        
        public override void PrepareLabels(Graphics g) {
            m_labeledTicks.TextRenderer.Prepare(g); 
        }

        public override void PrepareMeshes(Graphics g) {
            System.Diagnostics.Debug.Assert(m_clipping != null); 
            int numPrim = (m_visible)? 
                (m_labeledTicks.Count + 1 + m_unLabeledTicks.Count) * 4 : 4;
            if (numPrim == 0)
                return; 
            createVertexBuffer(numPrim);
            vertexBuffer_Created(m_vertexBuffer,null); 
        }

        protected override void drawGrid() {
            // TODO: to be implemented !
        }

        private void createVertexBuffer(int numPrim) {
            m_invalidated = true;
            if (m_vertexBuffer != null && !m_vertexBuffer.Disposed) {
                m_vertexBuffer.Dispose();
                m_vertexBuffer = null;
            }
            m_vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored),
                                    numPrim * 2, m_dxPanel.Device, Usage.WriteOnly,
                                    CustomVertex.PositionColored.Format, Pool.Default);
            m_vertexBuffer.Created += new EventHandler(vertexBuffer_Created);
            m_primitivCount = numPrim;
        }

        #endregion
 
    }
}
