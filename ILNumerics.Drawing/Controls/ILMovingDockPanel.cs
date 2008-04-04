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
    public class ILMovingDockPanel : Panel {
        private DockStyle m_dockStyle; 
        private TextOrientation m_standardOrientation = TextOrientation.Horizontal; 
        private BorderStyle m_borderStyle; 
        private bool m_isMoving; 
        private Size m_oldSize; 
        private System.Drawing.Point m_moveStart;
        private float m_bgGradientDeg = 0.0f;
        private byte m_bgGradientStrength = 30;
        protected Color m_backColor = SystemColors.Info; 
        private Button m_buttonClose; 

        /// <summary>
        /// Intensity of lighting / darkner effect for background color
        /// </summary>
        public byte BackgroundGradientStrength {
            get { return m_bgGradientStrength; }
            set { 
                m_bgGradientStrength = value; 
                Invalidate(); 
            }
        } 
        /// <summary>
        /// orientation for background gradient effect
        /// </summary>
        public float BackgroundGradientDeg {
            get { return m_bgGradientDeg; }
            set { 
                m_bgGradientDeg = value; 
                Invalidate(); 
            }
        } 


        protected TextOrientation m_orientation = TextOrientation.Horizontal;
        /// <summary>
        /// set the orientation of text (Horizontal/Vertical)
        /// </summary>
        public TextOrientation Orientation {
            get { 
                return m_orientation; 
            }
            set { 
                m_orientation = value; 
            }
        }
        /// <summary>
        /// The type of orientation (hor./ vert) if the control is not docked
        /// </summary>
        /// <remarks>Setting this value will not alter the way the display is
        /// currently drawn until the control returns from a docked state the next time.</remarks>
        public TextOrientation StandardOrientation {
            get {
                return m_standardOrientation; 
            }
            set {
                m_standardOrientation = value; 
                OnOrientationChanged();
            }
        }

        public new BorderStyle BorderStyle {
            get {
                return m_borderStyle; 
            }
            set {
                m_borderStyle = value; 
            }
        }
        
        public System.Drawing.Point LocationMoveStart {
            get {
                return m_moveStart; 
            }
            set {
                m_moveStart = value; 
            }
        }
        /// <summary>
        /// True, if the control is currently moved around by the user
        /// </summary>
        public bool IsMoving {
            get {
                return m_isMoving; 
            }
            set {
                m_isMoving = value; 
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Pen pen = new Pen(new SolidBrush(ForeColor),1.0f);  
            if (BorderStyle == BorderStyle.FixedSingle) {
                Rectangle rect = ClientRectangle; 
                rect.Width -= 1; 
                rect.Height -= 1; 
                e.Graphics.DrawRectangle( pen,rect); 
            }
        }

        public ILMovingDockPanel() {
            m_dockStyle = DockStyle.None;
            m_borderStyle = BorderStyle.None; 
            this.Padding = new Padding(2); 
            this.MouseDoubleClick += new MouseEventHandler(ILMovingDockPanel_MouseDoubleClick);
            this.MouseDown += new MouseEventHandler(ILMovingDockPanel_MouseDown);
            this.MouseUp += new MouseEventHandler(ILMovingDockPanel_MouseUp);
            this.MouseMove += new MouseEventHandler(ILMovingDockPanel_MouseMove);
            Cursor = Cursors.SizeAll; 
            BackColor = SystemColors.Info;
            // create close button
            m_buttonClose = new Button(); 
            Bitmap bmpClose = Resources.Images.close;
            m_buttonClose.BackgroundImage = bmpClose; 
            m_buttonClose.Height = bmpClose.Height; 
            m_buttonClose.Width = bmpClose.Width; 
            Controls.Add(m_buttonClose); 
            m_buttonClose.FlatAppearance.BorderSize = 2;
            m_buttonClose.Cursor = Cursors.Default; 
            m_buttonClose.Visible = false;
            m_buttonClose.Click += new EventHandler(m_buttonClose_Click);
            positionButtonClose(); 
        }

        #region handle close button
        void m_buttonClose_Click(object sender, EventArgs e) {
            this.Visible = false; 
        }

        private void positionButtonClose() {
            if (m_orientation == TextOrientation.Horizontal) {
                
            } else {

            }
            m_buttonClose.Left = 2; 
            m_buttonClose.Top = 2; 
        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            m_buttonClose.Visible = true; 
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            Point p = this.PointToClient(MousePosition); 
            if (p.X < 0 || p.Y < 0 || p.Y > ClientSize.Height || p.X > ClientSize.Width) 
                m_buttonClose.Visible = false; 
        }
        

        #endregion

        void ILMovingDockPanel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) 
                return; 
            if (!m_isMoving && (Math.Abs(e.X - m_moveStart.X) > 2 || Math.Abs(e.Y - m_moveStart.Y) > 2)) {
                m_isMoving = true;
                this.BorderStyle = BorderStyle.FixedSingle; 
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e) {
            //System.Diagnostic.Debug.WriteLine("ILBordFtLbl: paintbg");
            base.OnPaintBackground(e);  
            Color c1 = BackColor; 
            int c1r = Math.Max(Math.Max(c1.R,c1.G),c1.B); 
            c1r = Math.Min(255-c1r,m_bgGradientStrength); 
            c1 = Color.FromArgb(100,c1.R+c1r,c1.G+c1r,c1.B+c1r); 
            Color c2 = BackColor; 
            c1r = Math.Min(Math.Min(c2.R,c2.G),c2.B); 
            if (c1r > m_bgGradientStrength) c1r = m_bgGradientStrength; 
            c2 = Color.FromArgb(200,c2.R-c1r,c2.G-c1r,c2.B-c1r); 
            Point p = new Point(ClientRectangle.Size.Width / 2, ClientRectangle.Height / 2); 
            System.Drawing.Drawing2D.LinearGradientBrush br = 
                new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,c1,c2,m_bgGradientDeg); 
            e.Graphics.FillRegion(br,new Region(ClientRectangle)); 
        }

        void ILMovingDockPanel_MouseUp(object sender, MouseEventArgs e) {
            m_isMoving = false; 
        }

        void ILMovingDockPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                m_moveStart = e.Location; 
            }
        }

        void ILMovingDockPanel_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                System.Array ds = Enum.GetValues(typeof(DockStyle)); 
                int cds = (int)Dock;
                DockStyle dos = (DockStyle)((cds + 1) % ds.Length); 
                while (dos == DockStyle.Fill) {
                    cds++; 
                    dos = (DockStyle)((cds + 1) % ds.Length);
                }
                SuspendLayout(); 
                Dock = dos;
                ResumeLayout(); 
            }
        }

        public override DockStyle Dock {
            get {
                return m_dockStyle;
            }
            set {
                if (m_dockStyle == value) return; 
                if (m_dockStyle == DockStyle.None) {
                    m_oldSize = this.Size;  
                }
                this.BorderStyle = BorderStyle.None; 
                switch (value) {
                    case DockStyle.Left:
                        m_orientation = TextOrientation.Vertical;
                        break;
                    case DockStyle.Right:
                        m_orientation = TextOrientation.Vertical;
                        break;
                    case DockStyle.Top:
                        m_orientation = TextOrientation.Horizontal;
                        break;
                    case DockStyle.Bottom:
                        m_orientation = TextOrientation.Horizontal;
                        break;
                    case DockStyle.Fill:
                        m_orientation = m_standardOrientation;
                        break;
                    case DockStyle.None:
                        this.BorderStyle = BorderStyle.FixedSingle;
                        m_orientation = m_standardOrientation;
                        break;
                    default:
                        m_orientation = m_standardOrientation;
                        break;
                }
                m_dockStyle = value;
                if (m_dockStyle == DockStyle.None && m_oldSize.Width > 0 && m_oldSize.Height > 0) {
                    this.Size = m_oldSize; 
                }
                if (Parent != null && Parent is ILSubfigure)
                    ((ILSubfigure)Parent).PerformLayout();
            }
        }

        protected virtual void OnOrientationChanged () {
            
        }
    }
}
