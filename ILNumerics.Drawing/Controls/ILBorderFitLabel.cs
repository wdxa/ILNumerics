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
using System.Windows.Forms; 
using System.Drawing; 
using ILNumerics.Drawing.Internal; 

namespace ILNumerics.Drawing.Controls {
    /// <summary>
    /// Label with flexible configurable orientation of it's text 
    /// </summary>
    public class ILBorderFitLabel : ILMovingDockPanel {
        private SizeF m_textSize = SizeF.Empty; 
        private ContextMenu m_menu; 
        private ILTextBoxAutoHide m_textBox; 

        private void autoSize() {
            // sets the height or width according to orientation & font
            if (m_orientation == TextOrientation.Vertical) {
                Width = Font.Height + Padding.Left + Padding.Right; 
            } else {
                Height = Font.Height + Padding.Top + Padding.Bottom; 
            }
        }

        private string m_text;
        public override string Text {
            get {
                return m_text;
            }
            set {
                m_text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The labels text
        /// </summary>
        public string Caption {
            get { return m_text; }
            set { 
                m_text = value; 
                Invalidate(); 
            }
        }
        private VerticalAlignment m_valign; 
        /// <summary>
        /// vertical alignment for the text
        /// </summary>
        public VerticalAlignment VerticalAlign {
            get {
                return m_valign; 
            }
            set {
                m_valign = value; 
                Invalidate(); 
           }
        }
        private HorizontalAlignment m_halign = HorizontalAlignment.Center; 
        /// <summary>
        /// horizontal alignment for the text
        /// </summary>
        public HorizontalAlignment HorizontalAlign {
            get {
                return m_halign; 
            }
            set {
                m_halign = value; 
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            PointF pointF = new PointF();
            StringFormat sf; 
            if (m_orientation == TextOrientation.Vertical)
                sf = new StringFormat(StringFormatFlags.DirectionVertical); 
            else 
                sf = new StringFormat(); 
            m_textSize = e.Graphics.MeasureString(m_text,Font,pointF,sf);
            #region compute horizontal position
            switch (m_halign) {
                case HorizontalAlignment.Center:
                    pointF.X = (ClientSize.Width - m_textSize.Width - Padding.Horizontal) / 2 - 1; 
                    break;
                case HorizontalAlignment.Left:
                    pointF.X = Padding.Left; 
                    break;
                case HorizontalAlignment.Right:
                    pointF.X = ClientSize.Width - Padding.Right - m_textSize.Width - 1; 
                    break;
                default:
                    break;
            }
            if (m_orientation == TextOrientation.Vertical) 
                pointF.X += Font.Height; 
            #endregion
            #region compute vertical position
            switch (m_valign) {
                case VerticalAlignment.Middle:
                    pointF.Y = (ClientSize.Height - m_textSize.Height - Padding.Top - Padding.Bottom) / 2; 
                    break;
                case VerticalAlignment.Upper:
                    pointF.Y = Padding.Top; 
                    break;
                case VerticalAlignment.Lower:
                    pointF.Y = ClientSize.Height - Padding.Bottom - m_textSize.Height; 
                    break;
                default:
                    break;
            }
            #endregion
            SolidBrush solidBrush = new SolidBrush(ForeColor);
            e.Graphics.DrawString(m_text, this.Font, solidBrush, pointF, sf); 
        }
        protected override void OnResize(EventArgs eventargs) {
            base.OnResize(eventargs);
            Invalidate(); 
        }
        public ILBorderFitLabel() {
            m_text = "Title"; 
            m_orientation = TextOrientation.Horizontal;
            m_halign = HorizontalAlignment.Center; 
            m_valign = VerticalAlignment.Middle; 
            Height = Font.Height + Padding.Top + Padding.Bottom; 
            Width = 150;
            this.Padding = new Padding(2); 
            this.ForeColor = Color.White; 
            m_menu = new ContextMenu(); 
            MenuItem mi = new MenuItem("Edit",new EventHandler(Edit_Click)); 
            m_menu.MenuItems.Add(mi);
            mi.DefaultItem = true; 
            mi.Shortcut = Shortcut.CtrlE; 
            mi.ShowShortcut = true; 
            
        }
        protected void Edit_Click(object sender, EventArgs e) {
            EditShow(); 
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Right)  {
                m_menu.Show(this,e.Location); 
            }
        }
        private void EditShow() {
            if (m_textBox == null) {
                m_textBox = new ILTextBoxAutoHide(); 
                if (Parent != null) 
                    Parent.Controls.Add(m_textBox);
                m_textBox.Committing += new EventHandler(m_textBox_Committing);
            }
            m_textBox.Text = m_text; 
            if (m_orientation == TextOrientation.Horizontal) {
                m_textBox.Size = Size; 
                m_textBox.Left = Location.X;
                m_textBox.Top = Top + (Height - m_textBox.Height) / 2; 
            } else {
                if (Parent != null) {
                    m_textBox.Top = Parent.Padding.Top; 
                    m_textBox.Left = Parent.Padding.Left; 
                    m_textBox.Width = Parent.Width - Parent.Padding.Horizontal; 
                    m_textBox.Height = Parent.Height - Parent.Padding.Vertical; 
                }
            }
            m_textBox.Font = Font; 
            m_textBox.Show(); 
            m_textBox.BringToFront(); 
            m_textBox.Focus();
            m_textBox.SelectAll(); 
        }

        void m_textBox_Committing(object sender, EventArgs e) {
            m_text = m_textBox.Text; 
            Invalidate();
        }
    }
}
