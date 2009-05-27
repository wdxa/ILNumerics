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
using System.Drawing;
using System.Windows.Forms;  
using ILNumerics.Drawing.Internal;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Controls;
using ILNumerics.Exceptions;  
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Platform.OpenGL; 

namespace ILNumerics.Drawing.Misc {
    public abstract class ILLegend {

        #region events 
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this,null); 
            }
        }
        void m_border_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        #endregion

        #region attributes
        protected ILPanel m_panel;
        protected Size m_size;
        protected Point m_location; 
        protected Color m_bgColor; 
        protected ILLineProperties m_border; 
        protected float m_opacity; 
        protected Padding m_padding; 
        protected bool m_visible; 
        #endregion

        #region properties
        /// <summary>
        /// get / set visibility for legend
        /// </summary>
        public bool Visible {
            get {
                return m_visible; 
            }
            set {
                m_visible = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get/ set opacity for filled area, values: 0...1.0
        /// </summary>
        public float Opacity {
            get {
                return m_opacity; 
            }
            set {
                m_opacity = value; 
                OnChanged(); 
            }
        }

        /// <summary>
        /// Get / set background color
        /// </summary>
        public Color BackgroundColor {
            get {
                return m_bgColor; 
            } 
            set {
                m_bgColor = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// get/ set location of legend box (upper/left corner), empty for auto mode
        /// </summary>
        public Point Location {
            get {
                return m_location; 
            }
            set {
                m_location = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// get/ set size of legend box, empty for auto mode
        /// </summary>
        public Size Size {
            get { return m_size; }
            set { 
                m_size = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// set properties of legend's border 
        /// </summary>
        public ILLineProperties Border {
            get {
                return m_border; 
            } 
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct new legend object
        /// </summary>
        internal ILLegend (ILPanel panel) {
            m_panel = panel; 
            m_size = Size.Empty; 
            m_border = new ILLineProperties();
            m_border.Antialiasing = false; 
            m_border.Color = Color.FromArgb(0x9f,0x9f,0xbf); 
            m_border.Style = LineStyle.Solid; 
            m_border.Width = 2; 
            m_border.Changed += new EventHandler(m_border_Changed);
            m_location = Point.Empty; 
            m_bgColor = Color.FromArgb(0x4f,0x4f,0x2f);; 
            m_opacity = 0.85f; 
            m_padding = new Padding(5);
            m_visible = false; 
        }
        /// <summary>
        /// Create new instance of ILLegend, depending on graphics device type
        /// </summary>
        /// <param name="panel">panel hosting this legend</param>
        /// <returns>newly created ILLegend object</returns>
        public static ILLegend Create(ILPanel panel) {
            if (panel is ILOGLPanel) {
                return new ILOGLLegend(panel); 
            } else 
                throw new NotImplementedException("Currently only legends for OpenGL are supported"); 
        }
        #endregion

        #region public interface
        /// <summary>
        /// Draw the legend onto a predefined bitmap or into GL context
        /// </summary>
        /// <param name="bitmap">destination bitmap, size must correspond to area. If this 
        /// parameter is null on input, the legend will be output into current GL device context (if any).</param>
        /// <param name="area">rectangle area defines region to draw legend contents into.</param>
        /// <remarks>The case bitmap == null is handled by derived class implementations.</remarks>
        public virtual void Draw(ILRenderProperties p, Rectangle area) {
            if (m_panel == null || m_panel.Graphs == null) return; 
            if (p.Graphics == null) {
                throw new ILArgumentException("ILLegend:Draw: unexpected parameter (bitmap) is null. This should be handled in derived classes!"); 
            }
            // draw bg + border 
            PointF p1,p2; 
            float offsX = Math.Max(m_border.Width / 2.0f,1.0f), offsY; 
            p1 = new PointF(offsX,offsX); 
            p2 = new PointF(m_size.Width-offsX,offsX); 
            Pen pen = new Pen(m_border.Color,m_border.Width); 
            // todo: implement dash styles 
            p.Graphics.Clear(m_bgColor); 
            p.Graphics.DrawLine(pen,p1,p2); 
            p1.X = p2.X; p1.Y = m_size.Height - offsX; 
            p.Graphics.DrawLine(pen,p2,p1); 
            p2.X = offsX; p2.Y = p1.Y; 
            p.Graphics.DrawLine(pen,p1,p2);
            p1.X = offsX; p1.Y = offsX; 
            p.Graphics.DrawLine(pen,p2,p1); 
            List<IILLegendRenderer> providers = new List<IILLegendRenderer>(10); 
            foreach (ILGraph graph in m_panel.Graphs) {
                if (graph is IILLegendRenderer) {
                    providers.Add(graph as IILLegendRenderer); 
                }
            }
            // compute final example sizes to fit into my size
            offsX = m_size.Width * 0.1f; offsY = m_size.Height * 0.1f;
            area.Height = (int)(m_size.Height - 2 * offsY) / providers.Count; 
            area.Width  = (int)(m_size.Width - 2 * offsX) / providers.Count; 
            area.X = (int)offsX; 
            for (int i = 0; i < providers.Count; i++) {
                area.Y = (int)(offsY + i * area.Height); 
                //providers[i].DrawIntoLegend(graphics,area);
            }
        }

        #endregion

        #region helper functions
        protected List<IILLegendRenderer> getRenderers(ref Size labelSize) {
            List<IILLegendRenderer> ret = new List<IILLegendRenderer>(); 
            foreach(ILGraph graph in m_panel.Graphs) {
                IILLegendRenderer rend = graph as IILLegendRenderer; 
                if (rend != null) {
                    ret.Add(rend); 
                    if (rend.Label.Size.Width > labelSize.Width) 
                        labelSize.Width = rend.Label.Size.Width; 
                    labelSize.Height += rend.Label.Size.Height; 
                }
            }
            return ret; 
        }
        #endregion
    }
}
