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
using System.Text;
using System.Drawing;  
using System.Collections.Generic;
using ILNumerics.Drawing.Interfaces; 
using OpenTK; 
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics.OpenGL.Enums; 
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Labeling;  

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// Basic OpenGL implementation for IILRenderer
    /// </summary>
    [ILRenderer(GraphicDeviceType.OpenGL,"Outline","OpenGL cached, outlined textures",true)] 
    public class ILOGLRenderer : IILRenderer {

        #region event handling
        /// <summary>
        /// (IILRenderer) Event firing if the texture storage has been cleared 
        /// </summary>
        public event EventHandler CacheCleared; 
        void m_textureManager_TextureCacheCleared(object sender, EventArgs e) {
            if (CacheCleared != null) 
                CacheCleared(this,null);
        }
        #endregion

        #region member / properties
        ILTextureManager m_textureManager; 
        float[] m_curPosition = new float[16]; 
        #endregion

        #region constructors

        public ILOGLRenderer (ILPanel panel) {
            m_textureManager = panel.TextureManager;
            m_textureManager.TextureCacheCleared += new EventHandler(m_textureManager_TextureCacheCleared);
        }
           
        #endregion

        #region IILTextRenderer Member
        public bool Cached { 
            get {
                return true; 
            }
        }

        public string Name {
            get { return "Outline fonts"; }
        }

        public string NameLong {
            get { return "OpenGL outline fonts (OpenTK)"; }
        }

        public GraphicDeviceType DeviceType {
            get { return GraphicDeviceType.OpenGL; }
        }

        public bool DrawAfterBufferSwapped {
            get { return false; }
        }

        public void Begin(System.Drawing.Graphics g) {
            if (GraphicsContext.CurrentContext == null)
                throw new GraphicsContextException("No GraphicsContext is current in the calling thread.");

            float[] viewport = new float[4]; 
            GL.GetFloat(GetPName.Viewport, viewport);

            // Prepare to draw text. We want pixel perfect precision, so we setup a 2D mode,
            // with size equal to the window (in pixels). 
            // While we could also render text in 3D mode, it would be very hard to get
            // pixel-perfect precision.
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();     
            GL.LoadIdentity();
            GL.Ortho(viewport[0], viewport[2], viewport[3], viewport[1], -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Disable(EnableCap.DepthTest);
        }

        public void End() {
            GL.PopAttrib();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
        }
        #endregion

        #region IILRenderer Member
        /// <summary>
        /// Place a new item into the texture cache 
        /// </summary>
        /// <param name="key">unique key to identify the item for later reference</param>
        /// <param name="bmp">bitmap containing the item data</param>
        /// <param name="rect">area in <paramref name="bmp"/> containing the item's data</param>
        public void Cache(string key, Bitmap bmp, RectangleF rect) {
            m_textureManager.StoreTextureItem(key,bmp,rect); 
        }

        /// <summary>
        /// Test if the cache contains an item with a specific key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>true if the item was cached, false otherwise</returns>
        public bool ExistsKey(string key) {
            return m_textureManager.Exists(key); 
        }

        /// <summary>
        /// try to get the size (screen pixels) of an item
        /// </summary>
        /// <param name="key">unique key identifying the item</param>
        /// <param name="size">[output] size of the item (if found)</param>
        /// <returns>true, if the item was found, false otherwise</returns>
        public bool TryGetSize(string key, ref Size size) {
            ILTextureData item; 
            if (m_textureManager.TryGetTextureItem(key,out item)) {
                size = new Size(item.Width,item.Height); 
                return true; 
            } else {
                return false; 
            }
        }

        /// <summary>
        /// Draws all items contained in a given render queue
        /// </summary>
        /// <param name="queue">render queue</param>
        /// <param name="location">starting point</param>
        /// <param name="orientation">orientation for the whole queues output</param>
        /// <param name="color">starting color</param>
        /// <remarks><para>The render queue must contain only keys for already cached items!</para>
        /// <para>The color parameter serves as a global color definition. It may be overridem 
        /// by individual color specifications of the queue items.</para>
        /// </remarks>
        public void Draw(ILRenderQueue queue, 
                        System.Drawing.Point location, 
                        TextOrientation orientation,
                        Color color) {
            float w, h;
            w = queue.Size.Width; 
            h = queue.Size.Height; 
            // compensate for unexact glx.MeasureString results... (to be fixed!)
            //w *= 1.09f;
            //h *= 1.09f;
            if (orientation == TextOrientation.Vertical) {
                GL.Rotate(90,0,0,1);
            }
            GL.GetFloat(GetPName.ModelviewMatrix,m_curPosition); 
            m_curPosition[12] = location.X; 
            m_curPosition[13] = location.Y; 

            GL.LoadMatrix(m_curPosition);
            m_textureManager.Reset(); 
            w = 0.5f; h = 0.5f; 
            int lineHeight = 0; 
            GL.Color3(color); 
            foreach (ILRenderQueueItem item in queue) {
                // special symbols & control sequences 
                switch (item.Key) {
                case "\r":
                    w = 0.5f; 
                    break; 
                case "\n": 
                    w = 0.5f; 
                    h += lineHeight; 
                    lineHeight = 0; 
                    break; 
                default: 
                    //since textures (may) lay on different sheets in GL memory,
                    // we cannot switch them in between Begin() and End(), 
                    // we must start a new Begin with each Quad :(
                    // possible workaround: If only one sheet is used, draw all 
                    // quads at once.
                    ILTextureData textData = m_textureManager.GetTextureItem(item.Key,true); 
                    if (item.Color != Color.Empty) {
                        GL.Color3(item.Color); 
                    } else {
                        GL.Color3(color); 
                    }
                    GL.Begin(BeginMode.Quads); 
                    RectangleF rectF = textData.TextureRectangle; 
                    GL.TexCoord2(rectF.Left,rectF.Bottom);   
                    GL.Vertex2(w,h + textData.Height + item.Offset.Y-1);      // ul
                    GL.TexCoord2(rectF.Left,rectF.Top); 
                    GL.Vertex2(w,h + item.Offset.Y);                    // bl
                    w += textData.Width-1; 
                    GL.TexCoord2(rectF.Right,rectF.Top); 
                    GL.Vertex2(w,h+ item.Offset.Y);                    // br
                    GL.TexCoord2(rectF.Right,rectF.Bottom); 
                    GL.Vertex2(w,h + textData.Height+ item.Offset.Y-1);      // tr
                    if (textData.Height > lineHeight)
                        lineHeight = textData.Height; 
                    GL.End(); 
#if BOUNDINGBOXES_ITEM
            // define DEBUG symbol to draw bouning box around each item (debug feature)
            GL.Color3(Color.Red); 
            GL.Begin(BeginMode.LineLoop); 
                w-= textData.Width; 
                GL.Vertex2(w,h + textData.Height);      // ul
                GL.Vertex2(w,h);                    // bl
                w += textData.Width; 
                GL.Vertex2(w,h);                    // br
                GL.Vertex2(w,h + textData.Height);      // tr
            GL.End();
#endif
                        break; 
                }
            }
#if BOUNDINGBOXES
            // define debugsymbol "BOUNDINGBOXES", to draw bounding box around whole expression
            GL.Disable(EnableCap.Texture2D); 
            GL.Color3(Color.Red); 
            GL.LineWidth(1); 
            GL.Begin(BeginMode.LineLoop); 
                GL.Vertex2(0,0);      // ul
                GL.Vertex2(0,queue.Size.Height);                    // bl
                GL.Vertex2(queue.Size.Width,queue.Size.Height);                    // br
                GL.Vertex2(queue.Size.Width,0);      // tr
            GL.End();
            GL.Enable(EnableCap.Texture2D); 
#endif
        }

        public void Draw(ILRenderQueue renderQueue, float x1, float y1, float z1, float x2, float y2, float z2, Color color) {
            Draw(renderQueue,new Point((int)x1,(int)y1),TextOrientation.Horizontal,color); 
        }

        #endregion
    }
}
