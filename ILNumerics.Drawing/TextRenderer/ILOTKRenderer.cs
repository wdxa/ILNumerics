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
using ILNumerics.Drawing.Interfaces; 
using OpenTK; 
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics.OpenGL.Enums; 
using OpenTK.Graphics;
using OpenTK.Math; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.TextRenderer {
    [ILTextRenderer(GraphicDeviceType.OpenGL,"Outline","OpenGL outlined text",true)] 
    public class ILOTKRenderer : IILTextRenderer {

        #region member / properties
        TickLabelAlign m_alignment; 
        TextureFont m_font; 
        TextPrinter m_textPrinter;
        IGraphicsContext m_context; 
        float[] m_curPosition = new float[16]; 
        //float[] m_oldProjection = new float[16]; 
        //float[] m_oldModelView = new float[16]; 
        System.Drawing.Font m_sysFont; 
        TextOrientation m_orientation; 
        #endregion

        #region constructors
        public ILOTKRenderer (object context,System.Drawing.Font font) {
            System.Diagnostics.Debug.WriteLine("ILOTKRenderer.ctor"); 
            m_context = (GraphicsContext)context; 
            if (font != null) {
                m_sysFont = font; 
            } else {
                m_sysFont = new System.Drawing.Font(
                    System.Drawing.FontFamily.GenericSansSerif,10.0f);
            }
            m_font = new TextureFont(m_sysFont);
            m_orientation = TextOrientation.Horizontal; 
            m_textPrinter = new TextPrinter(); 
        } 
        #endregion


        #region IILTextRenderer Member

        /// <summary>
        /// Get or set the alignment for text inside rectangle to be drawn (optional, if supported by device)
        /// </summary>
        public TickLabelAlign Alignment { 
            get { 
                return m_alignment; 
            }
            set {
                m_alignment = value; 
            }
        }

        public string Name {
            get { return "Outline fonts"; }
        }

        public string NameLong {
            get { return "OpenGL outline fonts (OpenTK)"; }
        }

        public CoordSystem CoordsSystem {
            get { return CoordSystem.Screen; }
        }

        public GraphicDeviceType DeviceType {
            get { return GraphicDeviceType.OpenGL; }
        }
        public bool DrawAfterBufferSwapped {
            get { return false; }
        }
        public System.Drawing.Font Font {
            get {
                return m_sysFont; 
            }
            set {
                if (m_sysFont != value) {
                    m_sysFont = value; 
                    try {
                        if (m_font != null) {
                            //m_font.Dispose();
                        }
                    } catch (Exception) {}
                    m_font = new TextureFont(m_sysFont);
                }
            }
        }
        /// <summary>
        /// Get the orientation for the text or set it
        /// </summary>
        public TextOrientation Orientation {
            get {
                return m_orientation; 
            }
            set {
                m_orientation = value; 
            }
        }
        public System.Drawing.Font Prepare(System.Drawing.Graphics g) {
            //// clean up
            //if (m_textPrinter != null)
            //    m_textPrinter.End(); 
            
            //GL.MatrixMode(MatrixMode.Modelview); GL.PushMatrix(); 
            //GL.MatrixMode(MatrixMode.Projection); GL.PushMatrix(); 

            //m_textPrinter.Begin(); 
            //if (m_orientation == TextOrientation.Vertical) {
            //    GL.Rotate(90,0,0,1);
            //}
            //GL.GetFloat(GetPName.ModelviewMatrix,m_curPosition); 
            return m_sysFont; 
        }

        public void Draw(string text, System.Drawing.Point location, System.Drawing.Color color) {
            float w, h; 
            // compute proper alignment manually 
            m_font.MeasureString(text,out w, out h);
            // compensate for unexact glx.MeasureString results... (to be fixed!)
            w *= 1.09f;
            h *= 1.09f;
#if DEBUG
            //m_curPosition[12] = 0; 
            //m_curPosition[13] = 0; 
            //GL.LoadMatrix(m_curPosition); 
            //GL.Begin(BeginMode.LineStrip); 
            //GL.Color3(255,0,0); 
            //GL.Vertex3(location.X,location.Y+h/2,0);
            //GL.Vertex3(location.X-w,location.Y+h/2,0);
            //GL.Vertex3(location.X-w,location.Y-h/2,0);
            //GL.Vertex3(location.X,location.Y-h/2,0);
            //GL.End(); 
#endif
            TextHandle handle; 
            m_textPrinter.Prepare(text,m_font,out handle);
            m_textPrinter.Begin(); 
            if (m_orientation == TextOrientation.Vertical) {
                GL.Rotate(90,0,0,1);
            }
            GL.GetFloat(GetPName.ModelviewMatrix,m_curPosition); 
            if (m_orientation == TextOrientation.Vertical) {
                if (0 != (TickLabelAlign.right & m_alignment)) {
                    w = location.X; 
                } else if (0 != (TickLabelAlign.center & m_alignment)) {
                    w = location.X + h / 2; 
                } else 
                    w = location.X + h; 
                if (0 != (TickLabelAlign.bottom & m_alignment)) {
                    h = location.Y - h;     
                } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                    h = location.Y - h / 2.0f; 
                } else 
                    h = location.Y; 
            } else {
                if (0 != (TickLabelAlign.right & m_alignment)) {
                    w = location.X - w;     
                } else if (0 != (TickLabelAlign.center & m_alignment)) {
                    w = location.X - w / 2.0f; 
                } else 
                    w = location.X; 
                if (0 != (TickLabelAlign.bottom & m_alignment)) {
                    h = location.Y - h;     
                } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                    h = location.Y - h / 2.0f; 
                } else 
                    h = location.Y; 
            }
            m_curPosition[12] = w; 
            m_curPosition[13] = h; 

            GL.LoadMatrix(m_curPosition);
            GL.Color3(color); 
            using (handle) {
                m_textPrinter.Draw(handle); 
            }
            m_textPrinter.End(); 
        }

        public void Free() {
            //GL.MatrixMode(MatrixMode.Projection); GL.PopMatrix(); // GL.LoadMatrix(m_oldProjection);
            //GL.MatrixMode(MatrixMode.Modelview); GL.PopMatrix(); // GL.LoadMatrix(m_oldModelView); 
            //m_textPrinter.End();
        }
        /// <summary>
        /// the size of the string after rendering with the current font
        /// </summary>
        /// <param name="text">text to be measured</param>
        /// <returns>System Size (pixels)</returns>
        /// <remarks>The measurement will NOT take the current orientation into account! (-> always horizontal)</remarks>
        public System.Drawing.Size MeasureText(string text, System.Drawing.Graphics g) {
            System.Diagnostics.Debug.Assert(m_font != null,"OTKFont was null!"); 
            float w,h; 
            m_font.MeasureString(text,out w,out h); 
            return new System.Drawing.Size((int)w,(int)h); 
        }

        #endregion

    }
}
