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
using Microsoft.DirectX; 
using Microsoft.DirectX.Direct3D; 
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions;
using ILNumerics.Drawing.Controls;
using System.Resources; 
using ILNumerics.Drawing.Graphs; 
using VERTEX_FORMAT = Microsoft.DirectX.Direct3D.CustomVertex.PositionNormalColored; 

namespace ILNumerics.Drawing.Internal
{
    public class ILDXGraphSurf3D : ILFilledGraph {
        
        #region members / properties
        protected VertexBuffer m_vertexBuffer;
        protected IndexBuffer m_indexBuffer; 
        protected PrimitiveType m_primitiveType;

        protected ILDXPanel m_dxPanel; 
        protected int m_vertexStride; 
        protected int m_rowsInChunk;  // number of rows to draw at once 
        protected int m_primsInChunk; // number of primitives (for full rows) to draw at once 
        public VertexBuffer VertexBuffer { get { return m_vertexBuffer; } }
        public PrimitiveType PrimitiveType {
            get {
                return m_primitiveType; 
            }
        }
        public int VertexStride {
            get {
                return m_vertexStride; 
            }
        }

        #endregion

        #region constructor
        public ILDXGraphSurf3D (  ILDXPanel panel, ILBaseArray sourceArray,
                                     ILClippingData clippingContainer) 
                                   : base(sourceArray,clippingContainer) {
            m_localClipping = new ILClippingData(); 
            if (!sourceArray.IsMatrix) 
                throw new ILArgumentException ("source arrray must be matrix!"); 
            if (!sourceArray.IsNumeric) 
                throw new ILArgumentException ("source arrray must be numeric!"); 
            m_dxPanel = panel;
            m_dxPanel.GraphicsDeviceReset += new ILGraphicsDeviceResetEvent(m_dxPanel_GraphicsDeviceReset);
            m_cols = m_sourceArray.Dimensions[0]; 
            m_rows = m_sourceArray.Dimensions[1]; 
            m_Vertcount = m_rows * m_cols; 
            m_primitiveType = PrimitiveType.TriangleList; 
            m_vertexReady = false;
            m_indexReady = false; 
            m_rowsInChunk = 1; // primitives per chunk
            m_primsInChunk = m_cols * 2 * m_rowsInChunk; 
            updateClipping();
            Configure(); 
        }

        #endregion

        #region event handlers creating vertex buffers
        void m_dxPanel_GraphicsDeviceReset(object sender, EventArgs eventArgs) {
            Invalidate(); 
        }
        protected void CreateIndices(object sender, EventArgs e) {
            IndexBuffer buffer = (IndexBuffer)sender; 
            short[] indices = (short[])buffer.Lock(0,0);
            int pos = 0; 
            for (int i = 0; i < m_primsInChunk / 2; i++) {
			    if (i % m_cols == (m_cols-1))
                    continue; 
                indices[pos++] = (short)i;
                indices[pos++] = (short)(i + m_cols + 1); 
                indices[pos++] = (short)(i+1);
                // 2nd triangle
                indices[pos++] = (short)i; 
                indices[pos++] = (short)(i + m_cols); 
                indices[pos++] = (short)(i + m_cols + 1); 
			}
            buffer.Unlock();
            m_indexReady = true; 
        }

        protected void CreateVertices(object sender, EventArgs e) {
            VertexBuffer buffer = (VertexBuffer)sender; 
            VERTEX_FORMAT[] vertices = (VERTEX_FORMAT[])buffer.Lock(0,0);  
            float val = 0.0f; 
            float minZ = m_globalClipping.ZMin; 
            float maxZ = m_globalClipping.ZMax; 
            float a = MAXHUEVALUE / (maxZ - minZ);
            float b = -minZ * a; 
            int i=0;
            ILColorProvider colHelp = new ILColorProvider(0.0f,0.5f,1.0f);
            for (int r = 0; r < m_rows; r++) {
                for (int c = 0; c < m_cols; c++) {
                    val = m_sourceArray.GetValue(c,r);
                    vertices[i].X = c; 
                    vertices[i].Y = r; 
                    vertices[i].Z = val;
                    vertices[i++].Color = colHelp.H2RGB(MAXHUEVALUE - val * a - b);
                }
            }
            #region create normals 
            // 
            Vector3 normal; 
            i = 0; 
            for (int r = 0; r < m_rows; r++) {
                for (int c = 0; c < m_cols; c++,i++) {
                    normal = new Vector3();  
                    if (c > 0 && c < m_cols) 
                       normal.Add(vertices[i-1].Position);  
                    if (c < m_cols-1) 
                        normal.Add(vertices[i+1].Position); 
                    if (r > 0 && r < m_rows) 
                        normal.Add(vertices[i-m_cols].Position); 
                    if (r < m_rows - 1) 
                        normal.Add(vertices[i+m_cols].Position); 
                    normal.Normalize(); 
                    vertices[i].Normal = normal;
                }
            }
            #endregion
            buffer.Unlock();
            m_vertexReady = true; 
        }
        #endregion

        #region abstract interface
        public override void Dispose() {
            if (m_vertexBuffer != null && !m_vertexBuffer.Disposed) {
                m_vertexBuffer.Dispose();
            }
            m_vertexBuffer = null;
            if (m_indexBuffer != null && !m_indexBuffer.Disposed) 
                m_indexBuffer.Dispose(); 
            m_indexBuffer = null; 
        }
        public override void Draw() {
            base.Draw(); 
            if (!(m_indexReady && m_vertexReady)) return; 
            m_dxPanel.Device.SetStreamSource( 0, m_vertexBuffer, 0);
            m_dxPanel.Device.VertexFormat = m_vertexBuffer.Description.VertexFormat; 
            m_dxPanel.Device.Indices = m_indexBuffer; 
            m_dxPanel.Device.RenderState.CullMode = Cull.None; 
            m_dxPanel.Device.RenderState.FillMode = FillMode.Solid;
            m_dxPanel.Device.RenderState.Lighting = false;
            //m_dxPanel.Device.RenderState.ZBufferEnable = false; 
            // draw primitives in chunks
            for (int row = 0; row  < m_rows - 1; row += 1) {
                m_dxPanel.Device.DrawIndexedPrimitives(m_primitiveType,row * m_cols,0,m_cols * 2,0,(m_cols - 1) * 2);    
            }
        }
        protected override void m_globalClipping_Changed(object sender, ClippingChangedEventArgs e) {
            base.m_globalClipping_Changed(sender, e);
            Configure(); 
        }
        protected override void Configure() {
            if (m_vertexBuffer != null && !m_vertexBuffer.Disposed)
                m_vertexBuffer.Dispose(); 
            m_vertexBuffer = new VertexBuffer(typeof(VERTEX_FORMAT), 
                             m_Vertcount, m_dxPanel.Device, Usage.None, VERTEX_FORMAT.Format,Pool.Default);
            if (m_vertexBuffer == null) {
                throw new ILMemoryException("unable to create vertex buffer for Direct3D device!"); 
            }
            if (m_indexBuffer != null && !m_indexBuffer.Disposed) 
                m_indexBuffer.Dispose(); 
            m_indexBuffer = new IndexBuffer(typeof(short),m_primsInChunk * 3, m_dxPanel.Device,Usage.None,Pool.Default); 
            if (m_indexBuffer == null || m_indexBuffer.Disposed)
                throw new ILMemoryException("unable to create index buffer for D3D device."); 
            m_isReady = false; 
            m_vertexReady = false; 
            m_indexReady = false; 
            m_vertexStride = VERTEX_FORMAT.StrideSize;
            m_vertexBuffer.Created += new EventHandler(CreateVertices);
            m_indexBuffer.Created += new EventHandler(CreateIndices); 
            CreateVertices(m_vertexBuffer,null);
            CreateIndices(m_indexBuffer,null);
            m_isReady = true; 
        }
        #endregion
    }
}
