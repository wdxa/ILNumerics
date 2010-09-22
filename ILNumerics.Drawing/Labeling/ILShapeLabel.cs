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
using ILNumerics.Drawing.Interfaces; 


namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// a label used for labeling shapes (screen coords, defined via world coords)
    /// </summary>
    public class ILShapeLabel : ILLabelingElement {
 
        #region attributes 
        ILPanel m_panel;
        CoordSystem m_coordSystem;
        Color m_fringeColor = Color.LightGray;
        ILArray<int> m_fringeOffsets;
        #endregion

        #region propeerties
        /// <summary>
        /// get/set the color used for drawing a fringe around glyphs, empty: no fringe
        /// </summary>
        public Color FringeColor {
            get { return m_fringeColor; }
            set { m_fringeColor = value; }
        }
        #endregion

        #region constructors
        public ILShapeLabel(ILPanel panel) : base(panel, null, Color.Black) {
            m_panel = panel; 
            m_coordSystem = CoordSystem.Screen;
            m_anchor = new PointF(.5f,.5f);  // TickLabelAlign.center | TickLabelAlign.vertCenter;
            m_fringeOffsets = new int[,]{ 
                { -1, -1 },
                { -1,  0 },
                { -1,  1 },
                {  0, -1 },
                {  0,  1 },
                {  1, -1 },
                {  1,  0 },
                {  1,  1 }};
            m_fringeOffsets = m_fringeOffsets.T; 
        }
        public ILShapeLabel(ILPanel panel, CoordSystem coordSystem) 
            : base(panel, null, Color.Black) {
            m_panel = panel;
            m_coordSystem = CoordSystem.Screen;
            m_anchor = new PointF(.5f, .5f);  // TickLabelAlign.center | TickLabelAlign.vertCenter;
            m_renderer.CacheCleared -= new EventHandler(m_renderer_CacheCleared);
            m_renderer = panel.TextRendererManager.GetDefault(coordSystem);
            m_renderer.CacheCleared += new EventHandler(m_renderer_CacheCleared);
        }
        #endregion

        #region public interface
        /// <summary>
        /// (internal use)
        /// </summary>
        /// <param name="p">render properties</param>
        /// <param name="center">center position for the label</param>
        public void Draw(ILRenderProperties p, ILPoint3Df center ) {
            if (!String.IsNullOrEmpty(Text)) {
                if (m_expression != m_cachedExpression) 
                    interprete(m_expression);
                double[] modelview = null;
                m_renderer.Begin(p, ref modelview);
                Point dest = m_panel.World2Screen(center, modelview);
                offsetAlignment(m_size, ref dest);
                if (m_fringeColor.IsEmpty) {
                    m_renderer.Draw(m_renderQueue, dest, TextOrientation.Horizontal, m_color);
                } else {
                    drawFringed(m_renderer, m_renderQueue, dest, TextOrientation.Horizontal, m_color); 
                }
                m_renderer.End(p); 
            }
        }

        /// <summary>
        /// draws a fringe around the render output in fringe color
        /// </summary>
        /// <param name="m_renderer"></param>
        /// <param name="m_rendererQueue"></param>
        /// <param name="dest"></param>
        /// <param name="textOrientation"></param>
        /// <param name="m_color"></param>
        private void drawFringed(IILRenderer m_renderer, object m_rendererQueue, Point dest, TextOrientation textOrientation, Color m_color) {
            m_renderer.ColorOverride = m_fringeColor; 
            for (int i = 0; i < m_fringeOffsets.Dimensions[0]; i++) {
                m_renderer.Draw(m_renderQueue
                                , new Point(dest.X + m_fringeOffsets.GetValue(i,0), dest.Y + m_fringeOffsets.GetValue(i,1))
                                , TextOrientation.Horizontal, m_fringeColor);
            }
            m_renderer.ColorOverride = Color.Empty; 
            m_renderer.Draw(m_renderQueue, dest, TextOrientation.Horizontal, m_color);

        }
        /// <summary>
        /// (internal use)
        /// </summary>
        /// <param name="p">render properties</param>
        /// <param name="min">minimum coord for label area</param>
        /// <param name="max">maximum coord for label area</param>
        public void Draw(ILRenderProperties p, ILPoint3Df min, ILPoint3Df max) {
            if (!String.IsNullOrEmpty(Text)) {
                if (m_expression != m_cachedExpression) 
                    interprete(m_expression);
                m_renderer.Begin(p);
                m_renderer.Draw(m_renderQueue,min.X,min.Y,min.Z,max.X,max.Y,max.Z, m_color);
                m_renderer.End(p);
            }
        }
        #endregion
    }
}
