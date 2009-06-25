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
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.Labeling {
    public class ILShapeLabel : ILLabelingElement {
 
        #region attributes 
        ILPanel m_panel;
        #endregion

        #region constructors
        public ILShapeLabel(ILPanel panel) : base(panel, null, Color.Black) {
            m_panel = panel; 
            m_alignment = TickLabelAlign.center | TickLabelAlign.vertCenter; 
        }
        #endregion

        #region public interface 
        public void Draw(ILRenderProperties p, ILPoint3Df center ) {
            if (!String.IsNullOrEmpty(Text)) {
                if (m_expression != m_cachedExpression) 
                    interprete(m_expression); 
                double[] modelview = null; 
                m_renderer.Begin(p, ref modelview);
                Point dest = m_panel.Transform(center,modelview); 
                offsetAlignment(m_size,ref dest);
                m_renderer.Draw(m_renderQueue,dest,TextOrientation.Horizontal,m_color); 
                m_renderer.End(p); 
            }
        }
        #endregion
    }
}