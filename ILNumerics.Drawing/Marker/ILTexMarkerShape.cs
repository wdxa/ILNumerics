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
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Marker {
    public class ILTexMarkerShape : ILMarkerShape {

        #region attributes 
        protected string m_expression; 
        protected IILTextInterpreter m_interpreter; 
        protected Font m_font; 
        protected int m_maxLabelsDrawn; 
        protected string m_valueFormat;
        protected IILRenderer m_renderer; 
        #endregion

        #region constructors 
        internal ILTexMarkerShape (ILPanel panel, string expression) 
            :base (panel) {
            m_expression = expression; 
            m_interpreter = new ILSimpleTexInterpreter(); 
            m_font = new Font(FontFamily.GenericSansSerif,10.0f); 
            m_maxLabelsDrawn = 50; 
            m_valueFormat = "f"; 
            m_renderer = panel.TextRendererManager.GetDefault(CoordSystem.World3D); 
        }
        #endregion

        #region properties
        /// <summary>
        /// Interpreter instance usedt to convert expression into visual output
        /// </summary>
        public IILTextInterpreter Interpreter {
            get {
                return m_interpreter; 
            }
            set {
                m_interpreter = value; 
            }
        }
        /// <summary>
        /// maximum number of labels to be drawn
        /// </summary>
        /// <remarks>If the graph contains more datapoints, only <i>MaxLabelsDrawn</i> markers 
        /// will be shown. This is for performance reasons only. Default is 50.</remarks>
        public int MaxLabelsDrawn {
            get { return m_maxLabelsDrawn; }
            set { 
                if (value >= 0) 
                    m_maxLabelsDrawn = value; 
            }
        }
        /// <summary>
        /// Format string used to convert value numbers into string 
        /// </summary>
        /// <remarks>Default: 'f'</remarks>
        public string ValueFormat {
            get { return m_valueFormat; }
            set {
                if (!String.IsNullOrEmpty(value)) {
                    m_valueFormat = value; 
                }
            }
        }
        /// <summary>
        /// Expression defining the marker tex shape
        /// </summary>
        /// <remarks>The expression may uses markups interpretable by the current interpreter. This is - by default - an simple Tex interpreter. 
        /// In addition to all partial tex commands, one may uses placeholders '\\index', '\\xvalue' and/or '\\yvalue'. Those placeholders will be 
        /// replaces for every marker individually with its real values at runtime.
        /// <para>This property is readonly. In order to change the expression, assign the new expression string to the Shape property of the 
        /// containing ILMarker class.</para></remarks>
        public string Expression {
            get {
                return m_expression; 
            }
        }
        #endregion

        #region public interface 
        public string Hash() {
            return String.Format("M:{0}",m_expression); 
        }

        /// <summary>
        /// draw all markers (graph / legend)
        /// </summary>
        /// <param name="marker">the marker object (for properties)</param>
        /// <param name="vertices">coords, interleaved</param>
        /// <param name="vertcount">number of coords, special: -1 for legend rendering</param>
        /// <remarks>This function is reused for both: drawing in world coords (graph) and drawing in
        /// screen coords (legend). Latter case requires vertcount to be -1, vertices must contain
        /// at least 2 float values than!</remarks>
        internal override void Draw(ILRenderProperties p, ILMarker marker, C4bV3f[] vertices, int startID, int vertcount) {
            if (vertcount > 0) {
                int inc = Math.Max(1,(vertcount/m_maxLabelsDrawn)); 
                m_renderer.Begin(p); 
                for (int i = 0; i < vertcount; i += inc) {
                    #region draw textured points (slow version: textured quads)
                    string expr = m_expression.Replace("\\index",i.ToString());
                    expr = expr.Replace("\\xvalue",vertices[i].XPosition.ToString(m_valueFormat)); 
                    expr = expr.Replace("\\yvalue",vertices[i].YPosition.ToString(m_valueFormat)); 
                    ILRenderQueue queue = m_interpreter.Transform(expr,m_font,marker.Color,m_renderer); 
                    #region determine size for markers in world coords (graph limits)
                        float w,h;
                        ILClippingData clip = m_panel.Limits; 
                        float s05x; 
                        float s05y; 
                        s05x = Math.Abs(queue.Size.Width * clip.WidthF / 2 / (m_panel.ClientSize.Width)); 
                        s05y = Math.Abs(queue.Size.Height * clip.HeightF / 2 / (m_panel.ClientSize.Height)); 
                    #endregion
                    // this is slow! Todo: replace by point sprites! 
                    w = vertices[i].XPosition; 
                    h = vertices[i].YPosition;           
                    if (m_panel.ClipViewData && (w < clip.XMin || w > clip.XMax || h < clip.YMin || h > clip.YMax)) {
                        continue; 
                    }
                    m_renderer.Draw(queue,w-s05x,h+s05y,vertices[i].ZPosition,
                                    w + s05x,h-s05y,vertices[i].ZPosition,marker.Color); 
                    #endregion
                }
                m_renderer.End(p);
            } else if (vertcount == -1) {
                #region render for legend
                m_renderer.Begin(p); 
                string expr = m_expression.Replace("\\index","0");
                expr = expr.Replace("\\xvalue","0.2"); 
                expr = expr.Replace("\\yvalue","0.4"); 
                ILRenderQueue queue = m_interpreter.Transform(expr,m_font,marker.Color,m_renderer); 
                #region determine size for markers in SCREEN COORDS
                float w,h;
                ILClippingData clip = m_panel.Limits; 
                float s05x; 
                float s05y; 
                s05x = Math.Abs(queue.Size.Width / 2 ); 
                s05y = Math.Abs(queue.Size.Height / 2); 

                #endregion
                // this is slow! Todo: replace by point sprites! 
                w = vertices[0].XPosition; 
                h = vertices[0].YPosition;
                
                m_renderer.Draw(queue,w-s05x,h-s05y,0,w + s05x,h+s05y,0,marker.Color); 
                m_renderer.End(p);
                #endregion
            }

        }
        #endregion

    }
}
