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
using System.Reflection; 
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.DirectX; 
using Microsoft.DirectX.Direct3D; 
using ILNumerics.Exceptions; 
using System.Resources; 
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Graphs; 

namespace ILNumerics.Drawing.Internal
{
    public class ILDXGraphPlot2D : ILPlot2DGraph
    {
        protected VertexBuffer m_vertexBuffer;
        protected PrimitiveType m_primitiveType;
        protected int m_Vertcount;
        protected int m_primCount; 
        protected ILDXPanel m_dxPanel; 
        protected int m_vertexStride; 
        protected Line m_line; 
        protected Texture m_pointShape; 

        public ILDXGraphPlot2D  ( ILDXPanel panel, ILBaseArray sourceArray,
                                  ILClippingData clippingContainer) 
                                : base(sourceArray,clippingContainer) {
            m_dxPanel = panel;
            m_graphType = GraphType.Plot2D; 
            m_dxPanel.GraphicsDeviceReset += new ILGraphicsDeviceResetEvent(m_dxPanel_GraphicsDeviceReset);
            create();
        }

        #region helper functions
        protected void Transform2D(object sender, EventArgs e) {
            //System.Diagnostics.StackFrame sf = new System.Diagnostics.StackTrace().GetFrame(1);
            //System.Diagnostics.Debug.WriteLine("ILDXGraphPlot2D_Transform called from: " + sf.GetMethod().Name + " (" + sf.GetMethod().Module.Assembly.FullName + ")"); 
            VertexBuffer buffer = (VertexBuffer)sender; 
            int numVert = m_sourceArray.Length;
            CustomVertex.PositionColored[] vertices = (CustomVertex.PositionColored[])buffer.Lock(0,0);  
            m_localClipping.Reset(); 
            float valY = 0.0f; 
            if (!m_sourceArray.IsScalar) {
                for (int i = 0; i < m_sourceArray.Length; i++) {
                    valY = m_sourceArray.GetValue(i);
                    if (m_localClipping.YMax < valY) m_localClipping.YMax = valY; 
                    if (m_localClipping.YMin > valY) m_localClipping.YMin = valY; 
                    vertices[i].X = i; 
                    vertices[i].Y = valY; 
                    vertices[i].Z = 0.0f; 
                    vertices[i].Color = m_properties.Color.ToArgb(); 
                }
                m_localClipping.ZMax = 0.0f; 
                m_localClipping.ZMin = 0.0f; 
                m_localClipping.XMin = 0; 
                m_localClipping.XMax = numVert-1;
            } else {
                // scalar case 
                valY = m_sourceArray.GetValue(0);
                m_localClipping.YMax = valY; 
                m_localClipping.YMin = valY; 
                m_localClipping.XMax = 0.0f; 
                m_localClipping.XMin = 0.0f; 
                m_localClipping.ZMax = 0.0f; 
                m_localClipping.ZMin = 0.0f; 
                vertices[0].X = 0.0f; 
                vertices[0].Y = valY; 
                vertices[0].Z = 0.0f;
                vertices[0].Color = m_properties.Color.ToArgb(); 
           }
            buffer.Unlock();
            m_isReady = true; 
        }

        private void create() {
            if (m_sourceArray.Length == 0) {
                m_Vertcount = 0;
                m_primCount = 0;
                m_primitiveType = PrimitiveType.PointList;
            } else if (m_sourceArray.Length == 1) {
                m_Vertcount = 1;
                m_primCount = 1;
                m_primitiveType = PrimitiveType.PointList;
            } else {
                m_Vertcount = m_sourceArray.Length;
                m_primCount = m_sourceArray.Length - 1;
                m_primitiveType = PrimitiveType.LineStrip;
            }
            Configure(); 
        }
        #endregion

        #region event handler 
        void m_dxPanel_GraphicsDeviceReset(object sender, EventArgs eventArgs) {
            Invalidate(); 
        }
        void Device_Disposing(object sender, EventArgs e) {
            Dispose();
        }
        #endregion 

        #region public (&abstract) interface 
        public override void Draw() {
            base.Draw(); 
            System.Diagnostics.Debug.WriteLine("ILDXGraphPlot2D_Draw"); 
            bool antAlias = m_dxPanel.Device.RenderState.AntiAliasedLineEnable; 
            m_dxPanel.Device.RenderState.AntiAliasedLineEnable = true;
            #region draw line
            // draw linestrip - simple case - fast vertex rendering 
            if (m_properties.Style == LineStyle.Solid && m_properties.Width == 1) {
                m_dxPanel.Device.SetStreamSource( 0, m_vertexBuffer, 0);
                m_dxPanel.Device.VertexFormat = m_vertexBuffer.Description.VertexFormat; 
                m_dxPanel.Device.DrawPrimitives(m_primitiveType, 0, m_primCount); 
            } else if (m_properties.Style == LineStyle.None){
            } else {
                // generate line pattern 
                if (m_properties.Style == LineStyle.UserPattern)
                    m_line.Pattern = m_properties.Pattern; 
                else 
                    m_line.Pattern = (int)m_properties.Style; 
                m_line.PatternScale = m_properties.PatternScale; 
                m_line.Width = m_properties.Width; 
                // extract points 
                CustomVertex.PositionColored[] vertices = (CustomVertex.PositionColored[])m_vertexBuffer.Lock(0,0); 
                Vector3[] pointCoords = new Vector3[m_Vertcount];
                for (int i = 0; i < m_Vertcount; i++) {
                    pointCoords[i] = new Vector3(vertices[i].X,vertices[i].Y,vertices[i].Z);
                }
                m_vertexBuffer.Unlock(); 
                vertices = null; 
                // extract trafo matrix(/-ces)
                Matrix mat = Matrix.Identity; 
                mat *= m_dxPanel.Device.Transform.World;
                mat *= m_dxPanel.Device.Transform.View; 
                mat *= m_dxPanel.Device.Transform.Projection; 
                m_line.Antialias = false; 
                // draw all lines 
                //m_line.Antialias = true;
                m_line.Begin(); 
                for (int i = 0; i < m_primCount; i++) {
                    m_line.DrawTransform(pointCoords,mat,m_properties.Color); 
                }
                m_line.End();
            }
            #endregion
            #region draw points
            if (m_marker.Style == MarkerStyle.Square) {
                float pSize = m_dxPanel.Device.RenderState.PointSize; 
                m_dxPanel.Device.RenderState.PointSize = m_marker.Size;  
                m_dxPanel.Device.SetStreamSource( 0, m_vertexBuffer, 0);
                m_dxPanel.Device.VertexFormat = m_vertexBuffer.Description.VertexFormat; 
                m_dxPanel.Device.DrawPrimitives(PrimitiveType.PointList, 0, m_primCount + 1); 
                m_dxPanel.Device.RenderState.PointSize = pSize; 
            } else if (m_marker.Style == MarkerStyle.None){ 
            } else {
                // draw all other marker styles as bitmap
                float pSize = m_dxPanel.Device.RenderState.PointSize; 
                TextureStateManager oldStage = m_dxPanel.Device.TextureState[0]; 
                m_dxPanel.Device.RenderState.PointSize = m_marker.Size;  
                m_dxPanel.Device.SetTexture(0,m_pointShape);
    
                m_dxPanel.Device.RenderState.PointSpriteEnable = true; 
                m_dxPanel.Device.RenderState.SourceBlend = Blend.InvSourceColor; 
                m_dxPanel.Device.RenderState.DestinationBlend = Blend.BothSourceAlpha; 
                m_dxPanel.Device.RenderState.AlphaBlendEnable = true;

                m_dxPanel.Device.SetStreamSource( 0, m_vertexBuffer, 0);
                m_dxPanel.Device.VertexFormat = m_vertexBuffer.Description.VertexFormat; 
                m_dxPanel.Device.DrawPrimitives(PrimitiveType.PointList, 0, m_primCount + 1); 
                m_dxPanel.Device.RenderState.PointSize = pSize;
                m_dxPanel.Device.RenderState.AlphaBlendEnable = false;
            }
            #endregion
            m_dxPanel.Device.RenderState.AntiAliasedLineEnable = antAlias; 
        }

        public override void Dispose() {
            m_isReady = false; 
            if (m_vertexBuffer != null && !m_vertexBuffer.Disposed)
                m_vertexBuffer.Dispose();
            m_vertexBuffer = null;
            if (m_line != null && !m_line.Disposed)
                m_line.Dispose();
        }

        protected override void Configure() {
            System.Diagnostics.Debug.WriteLine("ILDXGraphPlot2D_configure"); 
            Dispose(); 
            if (m_dxPanel == null || m_dxPanel.Device == null 
                || m_dxPanel.Device.Disposed)
                return; 
            try {
                m_vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 
                                                  m_Vertcount, m_dxPanel.Device, 
                                                  Usage.None, 
                                                  CustomVertex.PositionColored.Format,
                                                  Pool.Default);
            } catch (Exception) {
                throw new ILInvalidOperationException("ILDXGraphPlot2D: failed to create vertex buffer!"); 
            }
            m_line = new Line(m_dxPanel.Device); 
            switch (m_marker.Style) {
                case MarkerStyle.Bitmap:
                    if (m_marker.Bitmap != null) {
                        m_pointShape = Texture.FromBitmap(m_dxPanel.Device,m_marker.Bitmap,0,Pool.Managed);
                    }
                    break; 
                case MarkerStyle.Triangle:
                    Assembly ilfigure = Assembly.GetAssembly(typeof(ILNumerics.Drawing.Controls.ILPanel)); 
                    Bitmap bmp = new Bitmap(ilfigure.GetManifestResourceStream("Markers.Triangle")); 
                    m_pointShape = Texture.FromBitmap(m_dxPanel.Device,bmp,0,Pool.Managed);
                    break; 
                default:
                    break;
            }
            m_vertexStride = CustomVertex.PositionColored.StrideSize;
            //m_vertexBuffer.Created += new EventHandler(Transform2D);
            Transform2D(m_vertexBuffer,null); 
        }
        #endregion 
    }
}
