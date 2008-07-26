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
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// 2D line &amp; point graph
    /// </summary>
    public abstract class ILPlot2DGraph : ILGraph {

        #region attributes
        protected ILLineProperties m_properties; 
        protected ILMarker m_marker; 
        protected ILArray<float> m_xData;
        #endregion

        #region properties
        /// <summary>
        /// Get properties of lines
        /// </summary>
        public ILLineProperties Line {
            get {
                return m_properties; 
            }
        }
        /// <summary>
        /// Get properties of markers (not yet implemented)
        /// </summary>
        public ILMarker Marker {
            get {
                return m_marker; 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// [internal] constructor - do not use this! Use ILPanel.Graphs.Add...() instead!
        /// </summary>
        /// <param name="sourceArray">data array</param>
        /// <param name="clippingContainer">hosting panels clipping data</param>
        public ILPlot2DGraph (ILPanel panel, ILBaseArray sourceArray,
                              ILClippingData clippingContainer) 
            : base (panel,sourceArray,clippingContainer) {
            if (!sourceArray.IsVector)
                throw new ILArgumentException ("Plot2D: supplied data must be a real vector!"); 
            m_xData = ILMath.tosingle(ILMath.counter(sourceArray.Length,1));
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_marker = new ILMarker(); 
            m_marker.Changed += new EventHandler(m_properties_Changed);
            m_graphType = GraphType.Plot2D; 
            updateClipping(); 
        }
        /// <summary>
        /// [internal] constructor - do not use this! Use ILPanel.Graphs.Add...() instead!
        /// </summary>
        /// <param name="XData">x data array</param>
        /// <param name="YData">y data array</param>
        /// <param name="clippingContainer">hosting panels clipping data</param>
        public ILPlot2DGraph (ILPanel panel, ILBaseArray XData, ILBaseArray YData,
                              ILClippingData clippingContainer) 
            : base (panel,YData,clippingContainer) {
            if (!XData.IsVector)
                throw new ILArgumentException ("Plot2D: supplied data must be a real vector!"); 
            if (!YData.IsVector)
                throw new ILArgumentException ("Plot2D: XData and YData must be real vectors!"); 
            if (YData.Length != XData.Length) 
                throw new ILArgumentException ("Plot2D: XData and YData must have the same length!"); 
            m_xData = ILMath.tosingle(XData);
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_marker = new ILMarker();
            m_marker.Changed += new EventHandler(m_marker_Changed);
            m_graphType = GraphType.Plot2D;
            updateClipping();
        }

        #endregion

        #region private helper 
        /// <summary>
        /// called, if a property for markers have changed
        /// </summary>
        /// <param name="sender">this graph instance</param>
        /// <param name="e">(no args)</param>
        /// <remarks>derived classes should override this function in order to 
        /// (re-)configure vertex ressources etc.</remarks>
        protected virtual void m_marker_Changed(object sender, EventArgs e) {
            m_isReady = false; 
        }
        private void updateClipping() {
            m_localClipping.Update (
                new ILPoint3Df(m_xData.MinValue,m_sourceArray.MinValue,0.0f),
                new ILPoint3Df(m_xData.MaxValue,m_sourceArray.MaxValue,0.0f)); 
        }
        /// <summary>
        /// called, if a property for lines have changed
        /// </summary>
        /// <param name="sender">this graph instance</param>
        /// <param name="e">(no args)</param>
        /// <remarks>derived classes should override this function in order to 
        /// (re-)configure vertex ressources etc.</remarks>
        protected virtual void m_properties_Changed(object sender, EventArgs e) {
            m_isReady = false;
        }
        #endregion
    }
}
