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
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Misc;
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics;
using System.Drawing;
using System.Drawing.Imaging;

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// OpenGL implementation of ILTextureStorage
    /// </summary>
    public class ILOGLTextureStorage : ILTextureStorage {

        #region attributes
        int [] m_tmpData = new int[20*20];
        #endregion

        #region constructor
        public ILOGLTextureStorage (int width, int height) : base (width, height) { }
        #endregion

        #region abstract overrides 
        /// <summary>
        /// Select this storage to be current in GL
        /// </summary>
        public override void MakeCurrent() {
            GL.BindTexture(TextureTarget.Texture2D,m_textureId);  
            System.Diagnostics.Debug.WriteLine(String.Format("ILOGLTextureStorage: switched to ID#{0}",m_textureId)); 
        }
        /// <summary>
        /// initialize texture sheet 
        /// </summary>
        protected override void InitTexture() {
            GL.GenTextures(1, out m_textureId);
            System.Diagnostics.Debug.WriteLine(String.Format("ILTextureStorage{2}: TextureID={0}, Thread={1}"
                    ,m_textureId, System.Threading.Thread.CurrentThread.ManagedThreadId,this.GetHashCode())); 
            GL.BindTexture(TextureTarget.Texture2D, m_textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Alpha, m_width, m_height, 0,
                OpenTK.Graphics.PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            // todo: error handling! 
        }
        /// <summary>
        /// store item in texture sheet in GL
        /// </summary>
        /// <param name="bmp">new item bitmap data</param>
        /// <param name="location">upper,left corner for region in bitmap</param>
        /// <param name="rect">rectangle specifying area to store the data into, 
        /// texture coords: range from 0...1.0</param>
        protected override void Store(Bitmap bmp,PointF location, RectangleF rect) {
            if (m_disposed) 
                throw new InvalidOperationException("the texture storage has been disposed already! (Need to create a new storage)"); 
            if (rect.Size.Width == 0 || rect.Size.Height == 0) return; 
            GL.BindTexture(TextureTarget.Texture2D, m_textureId);
            Rectangle usedArea = new Rectangle ((int)rect.Left,
                                                (int)rect.Top,
                                                (int)Math.Min(Math.Floor(rect.Width),bmp.Width - Math.Ceiling(location.X)),
                                                (int)Math.Min(Math.Floor(rect.Height),bmp.Height - Math.Ceiling(location.Y))); 
            BitmapData bmp_data = bmp.LockBits(
                new Rectangle((int)Math.Ceiling(location.X),(int)Math.Ceiling(location.Y), usedArea.Width, usedArea.Height), 
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (usedArea.Size == bmp.Size) {
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bmp.Width, bmp.Height,
                     OpenTK.Graphics.PixelFormat.Rgba, PixelType.UnsignedByte, bmp_data.Scan0);
            } else {
                // must copy to new data array
                if (m_tmpData.Length < usedArea.Height * usedArea.Width) {
                    if (m_tmpData != null) 
                        ILMemoryPool.Pool.RegisterObject(m_tmpData); 
                    m_tmpData = ILMemoryPool.Pool.New<int>(usedArea.Height * usedArea.Width);    
                }
                unsafe {
                fixed (int* tmpDataP = m_tmpData) {
                    int* pOut = tmpDataP; 
                    int* pIn; 
                    int* pInEnd;
                    for (int r = 0; r < usedArea.Height; r++) {
                        //pIn = (int*)bitmap_data.Scan0 + (r+(int)location.Y) * data.Width + (int)location.X; 
                        pIn = ((int*)bmp_data.Scan0) + r * (bmp_data.Stride / 4); 
                        pInEnd = pIn + usedArea.Width; 
                        while (pIn < pInEnd) {
                            *(pOut++) = *(pIn++);     
                        }
                    }
                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, usedArea.Left, usedArea.Top, usedArea.Width, usedArea.Height,
                         OpenTK.Graphics.PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)tmpDataP);
#if EXPORTBMP
                    Bitmap outB = new Bitmap(usedArea.Width, usedArea.Height);
                    for (int i = 0; i < usedArea.Width * usedArea.Height; i++)
                        outB.SetPixel(i%usedArea.Width,(int)(i/usedArea.Width),Color.FromArgb(m_tmpData[i]));
                    outB.Save("EXPORTBMP_textureCached.bmp",ImageFormat.Bmp); 
                    outB.Dispose(); 
                    string dbTrOut = String.Format("usedArea:{0}:{1}:{2}:{3} data:{4} bmp_data: {5}:{6} stride:{7} Loc:{8}"
                                    ,usedArea.Left, usedArea.Top, usedArea.Width, usedArea.Height
                                    ,bmp.Size.ToString()
                                    ,bmp_data.Width,bmp_data.Height
                                    ,bmp_data.Stride
                                    ,location); 

                    Console.Out.WriteLine(dbTrOut); 
                    System.Diagnostics.Debug.WriteLine(dbTrOut); 
#endif
                }
                }
            }
            bmp.UnlockBits(bmp_data);
        }
        /// <summary>
        /// dispose off the texture storage's ressources
        /// </summary>
        /// <param name="manual"></param>
        public override void Dispose(bool manual) {
            if (!m_disposed) {
                if (manual) {
                    // free texture from OGL 
                    GL.DeleteTextures(1, ref m_textureId);
                }
                m_disposed = true; 
            }
        }
        #endregion

    }
}
