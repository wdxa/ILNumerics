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
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls;  

namespace ILNumerics.Drawing {
    /// <summary>
    /// axis label for subfigures
    /// </summary>
    public class ILAxisLabel {
        /// <summary>
        /// fires when a label's property has changed
        /// </summary>
        public event EventHandler Changed;

        #region attributes / properties
        private string m_text; 
        private Font m_font; 
        private Color m_color; 
        private IILTextRenderer m_textRenderer; 
        private int m_padding; 
        private TextOrientation m_orientation; 
        private AxisLabelAlign m_align; 
        private Size m_size; 

        internal Point m_position = new Point(); 

        /// <summary>
        /// Alignment of the label. Possible values: lower, center, upper
        /// </summary>
        public AxisLabelAlign Alignment {
            get {
                return m_align; 
            }
            set {
                m_align = value; 
                OnChanged(); 
            }
        }

        /// <summary>
        /// Get the orientation for the axis label or sets it
        /// </summary>
        public TextOrientation Orientation {
            get {
                return m_orientation; 
            }
            internal set {
                m_orientation = value;
                m_textRenderer.Orientation = value; 
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

        /// <summary>
        /// font used to display the text for the label
        /// </summary>
        public Font Font {
            get {
                return m_font; 
            }
            set {
                m_font = value; 
                if (m_textRenderer != null) 
                    m_textRenderer.Font = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// text to display on axis
        /// </summary>
        public string Text {
            get {
                return m_text; 
            }
            set {
                m_text = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// color used to display text
        /// </summary>
        public Color Color {
            get {
                return m_color; 
            }
            set {
                m_color = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// TextRenderer used to transform / render text for this label onto panel
        /// </summary>
        public IILTextRenderer TextRenderer {
            get {
                return m_textRenderer; 
            }
            set {
                m_textRenderer = value;
                m_textRenderer.Orientation = Orientation; 
                m_textRenderer.Font = m_font; 
            }
        }

        /// <summary>
        /// Size of the label, includes orientation
        /// </summary>
        public Size Size {
            get {
                //System.Diagnostics.Debug.Assert(m_size != Size.Empty); 
                return m_size; 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create an axis label for rendering
        /// </summary>
        public ILAxisLabel () {
            m_font = new Font(FontFamily.GenericSansSerif,10.0f); 
            m_color = Color.Black;
            m_text = ""; 
            m_textRenderer = null; 
            m_align = AxisLabelAlign.Center; 
            m_padding = 3; 
        }
        #endregion

        #region event handler
        private void OnChanged() {
            if (Changed != null) 
                Changed(this,null); 
        }
        #endregion

        internal void Dispose() {
            if (m_textRenderer != null) 
                m_textRenderer.Free();
        }

        public Size GetSize(Graphics gr) {
            m_size = m_textRenderer.MeasureText(m_text,gr);
            return m_size; 
        }

        #region private helper
 

        #endregion
    }
}
