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
using ILNumerics.Drawing;  
using Microsoft.DirectX.Direct3D; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.TextRenderer {
    [ILTextRenderer(GraphicDeviceType.Direct3D,"Direct3D","Simple Direct3D Renderer",true)]
    public class ILDXSimpleTextRenderer : IILTextRenderer {

        Device m_device; 
        System.Drawing.Font m_SysFont; 
        Font m_DXFont; 
        Sprite m_sprite; 
        DrawTextFormat m_format; 
        bool m_isPrepared; 
        TextOrientation m_orientation; 
        
        public ILDXSimpleTextRenderer(object device,System.Drawing.Font font) {
            m_isPrepared = false; 
            m_device = (Device)device; 
            if (font != null) {
                m_SysFont = font; 
            } else {
                m_SysFont = new System.Drawing.Font(
                    System.Drawing.FontFamily.GenericSansSerif,10.0f);
            }
            m_orientation = TextOrientation.Horizontal; 
        }

        #region IILTextRenderer Member

        public string Name {
            get { 
                return "Direct3D (simple)"; 
            }
        }

        public string NameLong {
            get { 
                return "simple Direct3D text renderer"; 
            }
        }

        public CoordSystem CoordsSystem {
            get { 
                return CoordSystem.Screen; 
            }
        }

        public GraphicDeviceType DeviceType {
            get { 
                return GraphicDeviceType.Direct3D; 
            }
        }
        public bool DrawAfterBufferSwapped {
            get { 
                return false;
            }
        }
        /// <summary>
        /// Get/Set alignment for text output from/into internal format
        /// </summary>
        public TickLabelAlign Alignment {
            get {
                TickLabelAlign ret = new TickLabelAlign(); 
                if (0 != (m_format & DrawTextFormat.Center))
                    ret |= TickLabelAlign.center; 
                else if (0 != (m_format & DrawTextFormat.Right)) 
                    ret |= TickLabelAlign.right;      
                else ret |= TickLabelAlign.left; 
                if (0 != (m_format & DrawTextFormat.VerticalCenter)) 
                    ret |= TickLabelAlign.vertCenter; 
                else if (0 != (m_format & DrawTextFormat.Bottom)) 
                    ret |= TickLabelAlign.bottom; 
                else ret |= TickLabelAlign.top; 
                return ret; 
            }
            set {
                m_format = DrawTextFormat.NoClip; 
                if (0 != (value & TickLabelAlign.right)) 
                    m_format |= DrawTextFormat.Right; 
                else if (0 != (value & TickLabelAlign.center))
                    m_format |= DrawTextFormat.Center; 
                else m_format |= DrawTextFormat.Left; 
                if (0 != (value & TickLabelAlign.bottom)) 
                    m_format |= DrawTextFormat.Bottom; 
                else if (0 != (value & TickLabelAlign.vertCenter)) 
                    m_format |= DrawTextFormat.VerticalCenter; 
                else m_format |= DrawTextFormat.Top; 
            }
        }

        public System.Drawing.Font Font {
            get {
                return m_SysFont; 
            }
            set {
                if (m_SysFont != value) {
                    m_SysFont = value; 
                }
            }
        }
        public TextOrientation Orientation {
            get {
                return m_orientation; 
            }
            set {
                if (value != TextOrientation.Horizontal) 
                    throw new NotImplementedException("Only horizontal orientation is implemented for DX devices!"); 
                m_orientation = value; 
            }
        }

        public System.Drawing.Font Prepare(System.Drawing.Graphics g) {
            Free();
            m_sprite = new Sprite(m_device); 
            m_DXFont = new Font(m_device,m_SysFont); 
            m_isPrepared = true; 
            return m_SysFont; 
        }

        public void Draw(string text, System.Drawing.Point position, System.Drawing.Color color) {
            m_sprite.Begin(SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
            m_DXFont.DrawText(m_sprite,text,position,color);     
            m_sprite.End();
        }

        public void Free() {
            if (m_sprite != null)
                m_sprite.Dispose(); 
            if (m_DXFont != null) 
                m_DXFont.Dispose(); 
        }

        public System.Drawing.Size MeasureText(string text, System.Drawing.Graphics gr) {
            return System.Windows.Forms.TextRenderer.MeasureText(text,m_SysFont); 
        }

        #endregion
    }
}
