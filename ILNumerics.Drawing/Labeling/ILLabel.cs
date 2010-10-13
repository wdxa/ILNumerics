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
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// general label, mainly used for ILAxis
    /// </summary>
    public class ILLabel : ILLabelingElement {

        #region attributes
        private int m_padding; 
        private LabelAlign m_align; 
        internal Point m_position = new Point();
        private bool m_visible; 
        #endregion

        #region properties 
        /// <summary>
        /// get/set visibility for the label
        /// </summary>
        public bool Visible {
            get { return m_visible; }
            set { m_visible = value; }
        }
        /// <summary>
        /// get/ set the position for the label
        /// </summary>
        public Point Position {
            get {
                return m_position; 
            }
            set {
                m_position = value; 
            }
        }
        /// <summary>
        /// Alignment along the axis value range. Possible values: lower, center, upper
        /// </summary>
        public LabelAlign Alignment {
            get {
                return m_align; 
            }
            set {
                m_align = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// Get/ set the padding used to seperate the label from the elements around it
        /// </summary>
        public int Padding {
            get {
                return m_padding; 
            }
            set {
                m_padding = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create a label for rendering
        /// </summary>
        public ILLabel (ILPanel panel) 
            : base(panel,new Font(FontFamily.GenericSansSerif,10.0f),Color.DarkBlue) {
            m_align = LabelAlign.Center; 
            m_padding = 3;
            m_visible = true; 
        }
        #endregion

        #region abstract overrides

        /// <summary>
        /// draws the whole rendering queue
        /// </summary>
        public override void Draw(ILRenderProperties p) {
            if (!m_visible || String.IsNullOrEmpty(m_expression)) return; 
            if (m_expression != m_cachedExpression) 
                interprete(m_expression); 
            m_renderer.Begin(p);
            Point renderPoint = offsetAlignment(m_size, m_position);
            m_renderer.Draw(m_renderQueue, renderPoint ,m_orientation, m_color); 
            m_renderer.End(p); 
        }

        #endregion

        #region private helper


        #endregion
    }
}
