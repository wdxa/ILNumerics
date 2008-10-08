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
    [ILRenderer(GraphicDeviceType.OpenGL,"Outline","OpenGL cached, outlined textures, world coords",true,CoordSystem.World3D)] 
    public class ILOGLWorldRenderer : IILRenderer {

        #region event handling
        /// <summary>
        /// fires when the texture storage has been cleared 
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

        public ILOGLWorldRenderer (ILPanel panel) {
            m_textureManager = panel.TextureManager;
            m_textureManager.TextureCacheCleared += new EventHandler(m_textureManager_TextureCacheCleared);
        }
           
        #endregion

        #region IILTextRenderer Member
        
        public CoordSystem CoordSystem {
            get { return CoordSystem.World3D; }
        }

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

            GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Disable(EnableCap.DepthTest);
        }

        public void End() {
            GL.PopAttrib();
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
        /// <param name="x1">x1-position</param>
        /// <param name="y1">y1-position</param>
        /// <param name="z1">z1-position (not used)</param>
        /// <param name="x2">x2-position</param>
        /// <param name="y2">y2-position</param>
        /// <param name="z2">z2-position (not used)</param>
        /// <param name="color">base color for items not containing individual colors</param>
        /// <remarks><para>The render queue must contain only keys for already cached items!</para>
        /// <para>The color parameter serves as a global color definition. It may be overwritten 
        /// by individual color specifications of the queue items.</para>
        /// <para>Use this function to draw the render queue in world coords. The position parameters mark the upper left 
        /// and lower right corner of the quads to contain the render queue content.</para>
        /// </remarks>
        public void Draw(ILRenderQueue queue, 
                        float x1, float y1, float z1, float x2, float y2, float z2, 
                        Color color) {
            float x, y, xm, ym, zm;

            xm = (x2 - x1)/(queue.Size.Width);
            ym = (y2 - y1)/(queue.Size.Height); 
            x = 0.5f; y = 0.5f; 
            int lineHeight = 0; 
            m_textureManager.Reset(); 
            GL.Color3(color); 
            foreach (ILRenderQueueItem item in queue) {
                // special symbols & control sequences 
                switch (item.Key) {
                case "\r":
                    x = 0.5f; 
                    break; 
                case "\n": 
                    x = 0.5f; 
                    y += lineHeight; 
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
                    GL.Vertex2(x*xm + x1,(y + textData.Height + item.Offset.Y-1)*ym+y1);      // ul
                    GL.TexCoord2(rectF.Left,rectF.Top); 
                    GL.Vertex2(x*xm + x1,(y+ item.Offset.Y)*ym+y1);                    // bl
                    x += textData.Width-1; 
                    GL.TexCoord2(rectF.Right,rectF.Top); 
                    GL.Vertex2(x*xm + x1,(y+ item.Offset.Y)*ym+y1);                    // br
                    GL.TexCoord2(rectF.Right,rectF.Bottom); 
                    GL.Vertex2(x*xm + x1,(y + textData.Height+ item.Offset.Y-1)*ym+y1);      // tr
                    if (textData.Height > lineHeight)
                        lineHeight = textData.Height; 
                    GL.End(); 
#if BOUNDINGBOXES_ITEM
            //// define DEBUG symbol to draw bounding box around each item (debug feature)
            // todo: modify to draw in world coords if needed!!
            //GL.Color3(Color.Red); 
            //GL.Begin(BeginMode.LineLoop); 
            //    w-= textData.Width; 
            //    GL.Vertex2(w,h + textData.Height);      // ul
            //    GL.Vertex2(w,h);                    // bl
            //    w += textData.Width; 
            //    GL.Vertex2(w,h);                    // br
            //    GL.Vertex2(w,h + textData.Height);      // tr
            //GL.End();
#endif
                    break; 
                }
            }
#if BOUNDINGBOXES
            //// define debugsymbol "BOUNDINGBOXES", to draw bounding box around whole expression
            // todo: modify to draw in world coords if needed!!
            //GL.Disable(EnableCap.Texture2D); 
            //GL.Color3(Color.Red); 
            //GL.LineWidth(1); 
            //GL.Begin(BeginMode.LineLoop); 
            //    GL.Vertex2(0,0);      // ul
            //    GL.Vertex2(0,queue.Size.Height);                    // bl
            //    GL.Vertex2(queue.Size.Width,queue.Size.Height);                    // br
            //    GL.Vertex2(queue.Size.Width,0);      // tr
            //GL.End();
            //GL.Enable(EnableCap.Texture2D); 
#endif
        }

        public void Draw(ILRenderQueue renderQueue, Point position, TextOrientation orientation, Color color) {
            Draw(renderQueue,position.X,position.Y,0,position.X + renderQueue.Size.Width,position.Y+renderQueue.Size.Height,0,color); 
        }

        #endregion
    }
}
