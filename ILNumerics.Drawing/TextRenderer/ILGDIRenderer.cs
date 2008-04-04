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
using System.Drawing;
using System.Windows.Forms; 
using ILNumerics.Drawing.Controls;  

namespace ILNumerics.Drawing.TextRenderer {
    [ILTextRenderer(GraphicDeviceType.GDI,"GDI Renderer","render text using System.Drawings.Graphics",false)] 
    public class ILGDIRenderer : IILTextRenderer {

        #region member / properties
        Graphics m_graphics; 
        TickLabelAlign m_alignment; 
        Font m_font; 
        TextOrientation m_orientation; 
        private StringFormat m_verticalStringFormat 
            = new StringFormat(StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft); 
        private bool m_isRunningMono; 
        #endregion

        #region constructors
        public ILGDIRenderer (object device, Font font) {
            if (font != null) {
                m_font = new Font(font.FontFamily,font.Size, font.Style); 
            } else {
                m_font = new Font(FontFamily.GenericSansSerif,10.0f);
            }
            m_orientation = TextOrientation.Horizontal; 
            m_isRunningMono = IsRunningOnMono(); 
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
            get { return "System.Drawing.Graphics renderer(GDI)"; }
        }

        public CoordSystem CoordsSystem {
            get { return CoordSystem.Screen; }
        }

        public GraphicDeviceType DeviceType {
            get { return GraphicDeviceType.GDI; }
        }
        public bool DrawAfterBufferSwapped {
            get { return true; }
        }
        public Font Font {
            get {
                return m_font; 
            }
            set {
                if (m_font != value) {
                    m_font = new Font(value.FontFamily,value.Size, value.Style); ; 
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
            m_graphics = g; 
            return m_font; 
        }

        public void Draw(string text, System.Drawing.Point location, Color color) {
            using (Brush brush = new SolidBrush(color)) {
                float w = location.X,h;
                SizeF tmp = MeasureText(text,m_graphics); 
                if (m_orientation == TextOrientation.Vertical) {
                    if (0 != (TickLabelAlign.right & m_alignment)) {
                        w = location.X; 
                    } else if (0 != (TickLabelAlign.center & m_alignment)) {
                        w = location.X + tmp.Height / 2; 
                    } else 
                        w = location.X + tmp.Height; 
                    if (0 != (TickLabelAlign.bottom & m_alignment)) {
                        h = location.Y - tmp.Width;     
                    } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                        h = location.Y - tmp.Width / 2.0f; 
                    } else 
                        h = location.Y; 
                    m_graphics.DrawString(text,m_font,brush,w,h,m_verticalStringFormat); 
                }else {
                    if (0 != (TickLabelAlign.right & m_alignment)) {
                        w = location.X - tmp.Width; 
                    } else if (0 != (TickLabelAlign.center & m_alignment)) {
                        w = location.X - tmp.Width / 2; 
                    } else 
                        w = location.X; 
                    if (0 != (TickLabelAlign.bottom & m_alignment)) {
                        h = location.Y - tmp.Height;     
                    } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                        h = location.Y - tmp.Height / 2.0f; 
                    } else 
                        h = location.Y; 
                    m_graphics.DrawString(text,m_font,brush,w,h);
                }
            }
        }

        public void Free() {
            //if (m_font != null)
            //    m_font.Dispose(); 
        }
        /// <summary>
        /// the size of the string after rendering with the current font
        /// </summary>
        /// <param name="text">text to be measured</param>
        /// <param name="g">graphics object - may or may not be used to measure text</param>
        /// <returns>System Size (pixels)</returns>
        /// <remarks>The measurement will NOT take the current orientation into account!. 
        /// Therefore the size will reflect the size for horizontal orientation.</remarks>
        public System.Drawing.Size MeasureText(string text, Graphics g) {
            //if (m_orientation == TextOrientation.Vertical) 
            //    return new Size(ret.Height,ret.Width); 
            // compensate for inexact mono measures
            if (Environment.OSVersion.Platform == PlatformID.Unix) {
                System.Diagnostics.Debug.Assert(g != null,"Invalid call to GDITextRenderer.MeasureText: graphics is null"); 
                SizeF sizF = g.MeasureString(text,m_font,int.MaxValue,StringFormat.GenericDefault);
                return new Size((int)sizF.Width,(int)sizF.Height);
            } else {
                // expect windows platform; todo: implement test againgst MacOS etc.
                Size propSize = new Size(int.MaxValue, int.MaxValue); 
                Size ret = System.Windows.Forms.TextRenderer.MeasureText(text,m_font,propSize,TextFormatFlags.NoPadding);
                if (m_isRunningMono) {
                    ret.Width += 3;  
                }
                return ret; 
            }
        }
        #endregion

        public static bool IsRunningOnMono () {
            return Type.GetType ("Mono.Runtime") != null;
        }
        private StringFormat align2format(TickLabelAlign align) {
            StringFormat ret = new StringFormat(); 
            if (0 != (TickLabelAlign.right & align)) {
                ret.LineAlignment = StringAlignment.Far;     
            } else if (0 != (TickLabelAlign.center & align)) {
                ret.LineAlignment = StringAlignment.Center; 
            } else 
                ret.LineAlignment = StringAlignment.Near;  
            if (0 != (TickLabelAlign.bottom & align)) {
                ret.Alignment = StringAlignment.Far;    
            } else if (0 != (TickLabelAlign.vertCenter & align)) {
                ret.Alignment = StringAlignment.Center;  
            } else 
                ret.Alignment = StringAlignment.Near;  
            return ret; 
        }
        private TickLabelAlign format2align(StringFormat format) {
            TickLabelAlign ret = new TickLabelAlign(); 
            if (0 != (format.LineAlignment & StringAlignment.Far)) {
                ret = TickLabelAlign.right;      
            } else if (0 != (format.LineAlignment & StringAlignment.Center)) {
                ret = TickLabelAlign.center; 
            } else 
                ret = TickLabelAlign.left;  
            if (0 != (format.Alignment & StringAlignment.Far)) {
                ret |= TickLabelAlign.bottom;     
            } else if (0 != (format.Alignment & StringAlignment.Center)) {
                ret |= TickLabelAlign.vertCenter;  
            } else 
                ret |= TickLabelAlign.top;  
            return ret; 
        }
    }
}
