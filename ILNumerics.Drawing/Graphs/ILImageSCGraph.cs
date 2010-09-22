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

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// class rendering plain color-coded area graphs
    /// </summary>
    /// <remarks>This class derives from ILFilledGraph and adds a ZPosition property.</remarks>
    public abstract class ILImageSCGraph : ILFilledGraph, IILLegendRenderer {

        #region attributes 
        protected float m_zPosition;
        #endregion

        #region Properties
        /// <summary>
        /// Z position for ImageSC graph (default: -Inf)
        /// </summary>
        /// <remarks>The position of the ImageSC plane is specified by a Z coordinate.
        /// The coordinate can set to the following values: 
        /// <list type="bullet">
        /// <item>any single precision value, will position the plane on that specific value</item>
        /// <item><i>negative infinity</i>, will position the plane on the bottom of the viewing cube</item>
        /// <item><i>positive infinity</i>, position the plane on top of the unit cube.</item></list>
        /// </remarks>
        public float ZPosition {
            get {
                return m_zPosition; 
            }
            set {
                m_zPosition = value; 
                OnChanged("ZPosition"); 
            }
        }
        #endregion

        #region constructor
        public ILImageSCGraph (ILPanel panel, ILBaseArray X, ILBaseArray Y,
                                ILBaseArray Z,ILBaseArray C,
                                ILClippingData clippingContainer)
            : base (panel, X,Y,Z,C, clippingContainer) {
            m_cols = m_sourceArray.Dimensions[1]+1; 
            m_rows = m_sourceArray.Dimensions[0]+1; 
            m_Vertcount = m_rows * m_cols;
            // defaults
            m_zPosition = float.NegativeInfinity;
        }
        public abstract void DrawToLegend(ILRenderProperties p, Rectangle sampleRect, Rectangle labelRect);         
        #endregion

        public override bool Is3DGraph() {
            return true;
        }

        #region IILPanelConfigurator
        public override void ConfigurePanel(ILPanel panel) {
            panel.InteractiveMode = InteractiveModes.ZoomRectangle;
            panel.AspectRatio = AspectRatioMode.StretchToFill;
            panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.StrictOptimal;
            panel.ClipViewData = false;
            panel.DefaultView.Set(0f, 0f, panel.DefaultView.Distance);
        }
        #endregion



    }
}
