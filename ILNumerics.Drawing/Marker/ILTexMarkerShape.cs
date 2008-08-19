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

namespace ILNumerics.Drawing.Marker {
    public abstract class ILTexMarkerShape : ILMarkerShape {

        #region attributes 
        protected string m_expression; 
        protected IILTextInterpreter m_interpreter; 
        protected Font m_font; 
        protected int m_maxLabelsDrawn; 
        protected string m_valueFormat; 
        #endregion

        #region constructors 
        internal ILTexMarkerShape (ILPanel panel, string expression) 
            :base (panel) {
            m_expression = expression; 
            m_interpreter = new ILSimpleTexInterpreter(); 
            m_font = new Font(FontFamily.GenericSansSerif,10.0f); 
            m_maxLabelsDrawn = 50; 
            m_valueFormat = "f"; 
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

        #endregion

    }
}
