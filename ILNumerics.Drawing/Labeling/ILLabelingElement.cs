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
using System.Drawing; 
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Base class for text elements 
    /// </summary>
    public abstract class ILLabelingElement {

#region event handler

        /// <summary>
        /// fires when an element's property has changed
        /// </summary>
        public event EventHandler Changed;
        
        protected virtual void OnChanged() {
            if (Changed != null) 
                Changed(this,null); 
        }

#endregion

#region attributes

        protected String m_expression; 
        protected String m_cachedExpression; 
        protected Color m_color; 
        protected Font m_font; 
        protected Size m_size; 
        internal TickLabelAlign m_alignment; 
        protected TextOrientation m_orientation; 
        protected IILTextInterpreter m_interpreter; 
        protected IILRenderer m_renderer;
        protected ILRenderQueue m_renderQueue; 


#endregion

#region properties 

        /// <summary>
        /// Size of the label for rendering, regardless of orientation
        /// </summary>
        public virtual Size Size {
            get {
                if (m_cachedExpression != m_expression) {
                    interprete(m_expression); 
                }
                return m_size; 
            }
        }
        /// <summary>
        /// color used to display the element
        /// </summary>
        public virtual Color Color {
            get { return m_color; }
            set { 
                m_color = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get/set system font used to draw the text
        /// </summary>
        public virtual Font Font { 
            get { return m_font; }
            set { 
                if (m_font != null && 
                    (m_font.Name != value.Name || 
                    m_font.Style != value.Style ||
                    m_font.Size != value.Size)) { 
                    m_font = value;
                    interprete(m_expression);  
                    OnChanged();
                }
            }
        }
        /// <summary>
        /// Get the orientation for the labeling element or sets it
        /// </summary>
        public virtual TextOrientation Orientation {
            get { return m_orientation; }
            set { 
                m_orientation = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get/set the alignment relative to render location for the label content
        /// </summary>
        public TickLabelAlign Alignment {
            get {
                return m_alignment; 
            }
            set {
                m_alignment = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Text interpreter used to transform labeling source into bitmap
        /// </summary>
        public IILTextInterpreter Interpreter {
            get { return m_interpreter; }
            set { 
                if (value != null) {
                    m_interpreter = value; 
                    OnChanged(); 
                }
            }
        }
        /// <summary>
        /// device dependent renderer, used to draw the labeling bitmap onto panel
        /// </summary>
        public IILRenderer Renderer {
            get { return m_renderer; }
            set { 
                if (value != null) {
                    m_renderer = value; 
                    OnChanged(); 
                }
            }
        }
        /// <summary>
        /// Get / set the text expression defining the content to be displayed 
        /// </summary>
        /// <remarks><para>The expression may contain markups according to 
        /// the specific interpreter instance.</para></remarks>
        public string Text {
            get {
                return m_expression; 
            }
            set {
                if (value != m_expression) {
                    m_expression = value; 
                    // (clean up, interpret & cache: when drawing)
                    OnChanged(); 
                }
            }
        }

#endregion

#region constructor

        /// <summary>
        /// [abstract] Create a new labeling element 
        /// </summary>
        /// <param name="panel">panel hosting the element</param>
        /// <param name="font">default font for the element</param>
        /// <param name="color">default color for the element</param>
        public ILLabelingElement (ILPanel panel, Font font, Color color) {
            if (font != null) {
                m_font = font; 
            } else {
                m_font = new System.Drawing.Font(
                    System.Drawing.FontFamily.GenericSansSerif,10.0f);
            }
            m_color = color; 
            m_orientation = TextOrientation.Horizontal; 
            m_renderQueue = null; 
            m_size = Size.Empty; 
            m_expression = string.Empty; 
            // init interpreter & renderer
            m_renderer = panel.TextRendererManager.GetDefault(CoordSystem.Screen);
            m_renderer.CacheCleared += new EventHandler(m_renderer_CacheCleared);
            m_interpreter = new ILSimpleTexInterpreter(); 
        }

#endregion

#region public methods 

        /// <summary>
        /// Dispose off this element's ressources
        /// </summary>
        internal void Dispose() {
            if (m_renderer != null) {
                m_renderer.CacheCleared -= m_renderer_CacheCleared;
                if (m_renderer is IDisposable) {
                    (m_renderer as IDisposable).Dispose();
                }
                m_renderer = null; 
            }
        }
        /// <summary>
        /// draws the whole rendering queue
        /// </summary>
        public virtual void Draw(ILRenderProperties p) {
            if (m_expression != m_cachedExpression) 
                interprete(m_expression); 
            m_renderer.Begin(p);
            m_renderer.Draw(m_renderQueue,offsetAlignment(m_renderQueue.Size),m_orientation,m_color); 
            m_renderer.End(p); 
        }

#endregion

#region helper methods
        
        /// <summary>
        /// if the renderer cleares its cache, the expression needs to be re-interpreted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_renderer_CacheCleared(object sender, EventArgs e) {
            m_cachedExpression = ""; 
        }
        /// <summary>
        /// add offset to an existing point according to internal alignment
        /// </summary>
        /// <param name="size">size of content to be aligned</param>
        /// <param name="point">original point</param>
        protected void offsetAlignment(Size size, ref Point point) {
            if (m_orientation == TextOrientation.Vertical) {
                if (0 != (TickLabelAlign.right & m_alignment)) {
                    // point.X = point.X; 
                } else if (0 != (TickLabelAlign.center & m_alignment)) {
                    point.X = point.X - size.Height / 2; 
                } else 
                    point.X = point.X + size.Height; 
                if (0 != (TickLabelAlign.bottom & m_alignment)) {
                    point.Y = point.Y - size.Width;     
                } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                    point.Y = point.Y - size.Width / 2; 
                } //else point.Y = point.Y; 
            } else {
                if (0 != (TickLabelAlign.right & m_alignment)) { 
                    point.X = point.X - size.Width;     
                } else if (0 != (TickLabelAlign.center & m_alignment)) {
                    point.X = point.X - size.Width / 2; 
                } // else point.X = point.X; 
                if (0 != (TickLabelAlign.bottom & m_alignment)) {
                    point.Y = point.Y - size.Height;     
                } else if (0 != (TickLabelAlign.vertCenter & m_alignment)) {
                    point.Y = point.Y - size.Height / 2; 
                } // else point.Y = point.Y; 
            }
        }
        /// <summary>
        /// return offset according to current setting of m_alingment
        /// </summary>
        /// <param name="size">size of an element to align</param>
        /// <returns>offset according to Alignment property</returns>
        protected Point offsetAlignment(Size size) {
            Point ret = new Point(); 
            offsetAlignment(size, ref ret); 
            return ret; 
        }
        /// <summary>
        /// interprete the expression and cache render queue
        /// </summary>
        /// <param name="expression"></param>
        protected void interprete(string expression) {
            if (m_renderQueue != null)
                m_renderQueue.Clear(); 
            m_renderQueue = 
                m_interpreter.Transform(expression,m_font,m_color,m_renderer);
            m_size = m_renderQueue.Size; 
            m_cachedExpression = expression; 
        }

#endregion

    }
}
