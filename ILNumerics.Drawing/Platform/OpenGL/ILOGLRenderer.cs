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
    /// OpenGL text renderer in screen coords
    /// </summary>
    [ILRenderer(GraphicDeviceType.OpenGL,"Outline","OpenGL cached, outlined textures",true,CoordSystem.Screen)] 
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
        Color m_colorOverride = Color.Empty;
        float m_xMin, m_xMax, m_yMin, m_yMax; 
        #endregion

        #region constructors

        public ILOGLRenderer (ILPanel panel) {
            m_textureManager = panel.TextureManager;
            m_textureManager.TextureCacheCleared += new EventHandler(m_textureManager_TextureCacheCleared);
        }
           
        #endregion

        #region IILTextRenderer Member

        public CoordSystem CoordSystem {
            get { return CoordSystem.Screen; }
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

        public void Begin(ILRenderProperties p) {
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
            if (p.Clipping) {
                GL.Disable(EnableCap.ClipPlane0); 
                GL.Disable(EnableCap.ClipPlane1); 
                GL.Disable(EnableCap.ClipPlane2); 
                GL.Disable(EnableCap.ClipPlane3); 
                GL.Disable(EnableCap.ClipPlane4); 
                GL.Disable(EnableCap.ClipPlane5); 
            }
            if (p.PassCount == 0) {
                m_xMin = float.MaxValue;
                m_xMax = float.MinValue;
                m_yMin = float.MaxValue;
                m_yMax = float.MinValue;
            }
        }
        
        public void Begin (ILRenderProperties p, ref double[] modelview) {
            if (modelview == null || modelview.Length < 16) {
                modelview = new double[16]; 
            }
            GL.GetDouble(GetPName.ModelviewMatrix,modelview);
            Begin(p); 
        }
        public void End(ILRenderProperties p) {
            if (p.Clipping) {
                GL.Enable(EnableCap.ClipPlane0); 
                GL.Enable(EnableCap.ClipPlane1); 
                GL.Enable(EnableCap.ClipPlane2); 
                GL.Enable(EnableCap.ClipPlane3); 
                GL.Enable(EnableCap.ClipPlane4); 
                GL.Enable(EnableCap.ClipPlane5); 
            }
            GL.PopAttrib();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            if (p.PassCount == 0) {
                if (p.MinX > m_xMin) p.MinX = (int)m_xMin;
                if (p.MaxX < m_xMax) p.MaxX = (int)m_xMax;
                if (p.MaxY < m_yMax) p.MaxY = (int)m_yMax;
                if (p.MinY > m_yMin) p.MinY = (int)m_yMin;
            }
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
            if (String.IsNullOrEmpty(queue.Expression.Trim())) return; 
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
            float drawPosX, drawPosY;
            float xMin = float.MaxValue; // relative to label (include rotation)
            float yMin = float.MaxValue;
            float xMax = float.MinValue;
            float yMax = float.MinValue; 
            GLColor3(color); 
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
                        GLColor3(item.Color); 
                    } else {
                        GLColor3(color); 
                    }
                    drawPosY = h + item.Offset.Y; 

                    GL.Begin(BeginMode.Quads); 
                    RectangleF rectF = textData.TextureRectangle; 
                    GL.TexCoord2(rectF.Left,rectF.Bottom);
                    GL.Vertex2(w, drawPosY + textData.Height - 1);      // bl
                    GL.TexCoord2(rectF.Left,rectF.Top);
                    GL.Vertex2(w, drawPosY);                    // tl
                    if (xMin > w) xMin = w;
                    if (yMin > drawPosY) yMin = drawPosY;

                    w += textData.Width-1; 
                    GL.TexCoord2(rectF.Right,rectF.Top);
                    GL.Vertex2(w, drawPosY);                    // tr
                    GL.TexCoord2(rectF.Right,rectF.Bottom);
                    GL.Vertex2(w, drawPosY + textData.Height - 1);      // br
                    if (textData.Height > lineHeight)
                        lineHeight = textData.Height; 
                    GL.End();
                    if (xMax < w) xMax = w;
                    if (yMax < drawPosY + textData.Height - 1) 
                        yMax = drawPosY + textData.Height - 1;

#if BOUNDINGBOXES_ITEM
            // define DEBUG symbol to draw bounding box around each item (debug feature)
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
            GL.Disable(EnableCap.LineStipple);
            GL.Begin(BeginMode.LineLoop); 
                GL.Vertex2(0,0);      // ul
                GL.Vertex2(0,queue.Size.Height);                    // bl
                GL.Vertex2(queue.Size.Width,queue.Size.Height);                    // br
                GL.Vertex2(queue.Size.Width,0);      // tr
            GL.End();
            GL.Enable(EnableCap.Texture2D); 
#endif
            // check outer limits 
            if (orientation == TextOrientation.Horizontal) {
                if (m_xMin > location.X + xMin) m_xMin = location.X + xMin;
                if (m_xMax < location.X + xMax) m_xMax = location.X + xMax;
                if (m_yMin > location.Y + yMin) m_yMin = location.Y + yMin;
                if (m_yMax < location.Y + yMax) m_yMax = location.Y + yMax;
            } else if (orientation == TextOrientation.Vertical) {
                if (m_xMin > location.X - yMax) m_xMin = location.X - yMax;
                if (m_xMax < location.X - yMin) m_xMax = location.X - yMin;
                if (m_yMin > location.Y - xMin) m_yMin = location.Y - xMin;
                if (m_yMax < location.Y - xMax) m_yMax = location.Y - xMax;
            }
        }

        public void Draw(ILRenderQueue renderQueue, float x1, float y1, float z1, float x2, float y2, float z2, Color color) {
            Draw(renderQueue,new Point((int)x1,(int)y1),TextOrientation.Horizontal,color); 
        }
        public Color ColorOverride {
            get {
                return m_colorOverride; 
            }
            set {
                m_colorOverride = value; 
            }
        }

        #endregion

        private void GLColor3(Color color) {
            if (m_colorOverride.IsEmpty) {
                GL.Color3(color);
            } else {
                GL.Color3(m_colorOverride);
            }
        }

    }
}
