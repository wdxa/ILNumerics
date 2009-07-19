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
using System.Drawing.Drawing2D; 
using System.Drawing; 
using System.Windows.Forms; 
using System.Resources; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Internal; 
using ILNumerics.Drawing.Misc; 


namespace ILNumerics.Drawing.Controls {
    public class ILColorBar : ILMovingDockPanel {
        private float m_minValue; 
        private float m_maxValue;
        private int m_precision = 5;
        private int m_tickLabelsPadding = 2;
        private ILColormap m_colormap; 

        /// <summary>
        /// Colormap used to translate colors indices
        /// </summary>
        public ILColormap Colormap {
            get {
                return m_colormap;
            }
            internal set { 
                m_colormap = value; 
            }
        }

        /// <summary>
        /// padding (in pixels) between the tick labels 
        /// </summary>
        public int TickLabelsPadding {
            get { return m_tickLabelsPadding; }
            set { m_tickLabelsPadding = value; }
        } 

        /// <summary>
        /// Number of digits to be displayed for values 
        /// </summary>
        public int Precision {
            get { return m_precision; }
            set { m_precision = value; }
        } 


        /// <summary>
        /// get / set minimum value for the values range
        /// </summary>
        public float MinValue {
            get {
                return m_minValue; 
            }
            set {
                m_minValue = value; 
            }
        }
        /// <summary>
        /// get / set maximum value for the values range
        /// </summary>
        public float MaxValue {
            get {
                return m_maxValue; 
            }
            set {
                m_maxValue = value; 
            }
        }

        /// <summary>
        /// register clipping range object as source for range and its changes
        /// </summary>
        /// <param name="clipping">clipping data object</param>
        /// <returns>true, if the source was registered successfully</returns>
        public bool RegisterRangeSource(ILClippingData clipping) {
            if (object.Equals(clipping,null)) return false; 
            clipping.Changed += new ILClippingDataChangedEvent(clipping_Changed); 
            return true; 
        }

        private void clipping_Changed(object sender, ClippingChangedEventArgs e) {
            m_minValue = e.ClippingData.ZMin; 
            m_maxValue = e.ClippingData.ZMax;
        }
        /// <summary>
        /// update range for color bar, supply color provider
        /// </summary>
        /// <param name="minValue">min value</param>
        /// <param name="maxValue">max value</param>
        /// <param name="colorProvider">color provider (not implemented)</param>
        public void Update(float minValue, float maxValue, ILColormap colormap) {
            m_minValue = minValue; 
            m_maxValue = maxValue; 
            m_colormap = colormap; 
        }
        /// <summary>
        /// update data range for the color bar
        /// </summary>
        /// <param name="minValue">min value</param>
        /// <param name="maxValue">max value</param>
        public void Update(float minValue, float maxValue) {
            m_minValue = minValue; 
            m_maxValue = maxValue; 
        }


        public ILColorBar(ILColormap colormap) : base() {
            base.BorderStyle = BorderStyle.FixedSingle; 
            Padding = new Padding(4); 
            StandardOrientation = TextOrientation.Vertical;
            m_orientation = TextOrientation.Vertical;
            Visible = true; 
            BackColor = SystemColors.Info; 
            m_colormap = colormap; 
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!Visible || (m_minValue == m_maxValue)) return;
            base.OnPaint(e);
            // draw border 
            Brush br = new SolidBrush(ForeColor) ;
            Rectangle drawSpace = ClientRectangle;
            Pen pen = new Pen(br); 
            // draw labels 
            drawSpace.Location = new Point (Padding.Left,Padding.Top); 
            drawSpace.Width = ClientRectangle.Width - Padding.Horizontal;
            drawSpace.Height = ClientRectangle.Height- Padding.Vertical; 
            string format = String.Format("g{0}",m_precision); 
            SizeF labsize = e.Graphics.MeasureString(String.Format(".-e08" + new String('0',m_precision)),Font); 
            int tickCount;
            if (m_orientation == TextOrientation.Vertical) {
                tickCount = (int)Math.Floor((double)(drawSpace.Height - labsize.Height) / (labsize.Height + m_tickLabelsPadding));
            } else {
                tickCount = (int)Math.Floor((double)(drawSpace.Width - labsize.Width) / (labsize.Width + m_tickLabelsPadding));
            }
            List<float> labels = 
                Collections.ILTickCollection.NiceLabels(m_minValue,m_maxValue,tickCount,TickLabelRenderingHint.Auto); 
            tickCount = labels.Count; 
            // draw labels
            RectangleF dR; List<int> tickPositions = new List<int>(tickCount); 
            if (m_orientation == TextOrientation.Vertical) {
                dR = new RectangleF(drawSpace.Left,drawSpace.Top + drawSpace.Height - labsize.Height, labsize.Width,labsize.Height); 
                StringFormat sf = new StringFormat(); 
                sf.Alignment = StringAlignment.Far; 
                sf.LineAlignment = StringAlignment.Near; 
                // draw all values in between
                float offsY = drawSpace.Top + drawSpace.Height;
                float mult = (drawSpace.Height) / (m_maxValue - m_minValue);
                foreach (float curVal in labels) {
                    // translate into screen coords
                    dR.Y = (int)(offsY - (curVal - m_minValue) * mult); 
                    tickPositions.Add((int)dR.Y);
                    dR.Y -= (labsize.Height/2);
                    e.Graphics.DrawString(curVal.ToString(format),Font,br,dR,sf);
                }
                // prepare remaining space for gradient scale
                drawSpace.X += (int)(labsize.Width + 2 * m_tickLabelsPadding); 
                drawSpace.Width -= (int)(labsize.Width + 2 * m_tickLabelsPadding); 
            } else {
                // draw labels above gradient scale
                dR = new RectangleF(drawSpace.Left,drawSpace.Top,labsize.Width,labsize.Height); 
                StringFormat sf = new StringFormat(); 
                sf.Alignment = StringAlignment.Near; 
                e.Graphics.DrawString(m_minValue.ToString(format),Font,br,dR,sf); 
                tickPositions.Add(drawSpace.Left); 
                // draw maximum 
                sf.Alignment = StringAlignment.Far;
                dR.X = drawSpace.Left + drawSpace.Width - labsize.Width; 
                e.Graphics.DrawString(m_maxValue.ToString(format),Font,br,dR,sf); 
                tickPositions.Add(drawSpace.Left + drawSpace.Width); 
                sf.Alignment = StringAlignment.Center;
                // draw all values in between
                float mult = (drawSpace.Width) / (m_maxValue - m_minValue);
                foreach (float curVal in labels) { // = ls; curVal <= m_maxValue - m/2; curVal = (float) (curVal + m)) {
                    // translate into screen coords
                    dR.X = (int)((curVal - m_minValue) * mult); 
                    if (dR.X < drawSpace.Left + labsize.Width) continue; 
                    if (dR.X > drawSpace.Left + drawSpace.Width - labsize.Width) continue; 
                    tickPositions.Add((int)dR.X); 
                    dR.X -= (labsize.Width/2);
                    e.Graphics.DrawString(curVal.ToString(format),Font,br,dR,sf);
                }
                // prep. rem. space for gradient scale
                drawSpace.Y += (int)(labsize.Height + 2 * m_tickLabelsPadding); 
                drawSpace.Height -= (int)(labsize.Height + 2 * m_tickLabelsPadding); 
            }

            // draw color gradient: border (gray)
            pen.Color = Color.FromArgb(180,180,180); 
            e.Graphics.DrawRectangle(pen,drawSpace);
            drawSpace.X += 1; drawSpace.Y += 1; 
            drawSpace.Width -= 1; drawSpace.Height -= 1; 
            Internal.ILColorProvider hls = new Internal.ILColorProvider(0.0f,0.5f,1.0f); 
            if (m_orientation == TextOrientation.Vertical) {
                for (int i = drawSpace.Height; i -->0;) {
                    pen.Color = m_colormap.Map((drawSpace.Height - i) / (double)drawSpace.Height * m_colormap.Length);
                    e.Graphics.DrawLine(pen,drawSpace.Left, drawSpace.Top+i, drawSpace.Left + drawSpace.Width,drawSpace.Top + i);
                }
                // draw tick bars 
                int le = drawSpace.Left, re = drawSpace.Left + drawSpace.Width, le2 = le + (re - le) / 4, re2 = re - (re - le) / 4; 
                pen.Color = ForeColor; 
                foreach (int y in tickPositions) {
                    e.Graphics.DrawLine(pen,le,y,le2,y); 
                    e.Graphics.DrawLine(pen,re2,y,re,y); 
                }
            } else {
                for (int i = drawSpace.Width; i -->0;) {
                    pen.Color = m_colormap.Map(i / (double)drawSpace.Width * m_colormap.Length);
                    e.Graphics.DrawLine(pen,drawSpace.Left+i, drawSpace.Top, drawSpace.Left + i,drawSpace.Top + drawSpace.Height);
                }
                // draw tick bars 
                int up = drawSpace.Top, bot = drawSpace.Top + drawSpace.Height, up2 = up + (bot - up) / 4, bot2 = bot - (bot - up) / 4; 
                pen.Color = ForeColor; 
                foreach (int x in tickPositions) {
                    e.Graphics.DrawLine(pen,x,up,x,up2); 
                    e.Graphics.DrawLine(pen,x,bot2,x,bot); 
                }
            }
        }
        protected override void OnOrientationChanged() {
            base.OnOrientationChanged();
            //reposition the close button
            if (m_orientation == TextOrientation.Horizontal) {
                
            } else {

            }
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
