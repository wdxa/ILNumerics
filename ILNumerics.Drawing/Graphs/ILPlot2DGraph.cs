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
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Marker;
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// 2D line &amp; point graph
    /// </summary>
    public abstract class ILPlot2DGraph : ILGraph, IILLegendRenderer, IILPanelConfigurator {

        #region attributes
        protected C4bV3f[] m_vertices; 
        protected int m_vertexCount; 
        protected ILLineProperties m_properties; 
        protected ILMarker m_marker;
        int m_autoLimitsUpdateCount = 0;
        int m_updateCount = 0; 
        protected int m_startID;

        #endregion

        #region properties
        /// <summary>
        /// number of subsequent updates ('Queue') before limits get recalculated. Default: 0 (recalculate on every update)
        /// </summary>
        public int AutoLimitsUpdateCount {
            get { return m_autoLimitsUpdateCount; }
            set { m_autoLimitsUpdateCount = value; }
        } 
        /// <summary>
        /// Get properties of lines
        /// </summary>
        public ILLineProperties Line {
            get {
                return m_properties; 
            }
        }
        /// <summary>
        /// Get properties of markers
        /// </summary>
        public ILMarker Marker {
            get {
                return m_marker; 
            }
        }
        /// <summary>
        /// access to internal vertex array
        /// </summary>
        /// <remarks><para>after altering vertex data, one must call 
        /// Invalidate() to signal those changes.</para></remarks>
        public C4bV3f[] Vertices {
            get {
                return m_vertices; 
            }
        }
        /// <summary>
        /// Invalidate the graph after vertex data have been changed.
        /// </summary>
        public override void Invalidate() {
            base.Invalidate(); 
            updateClipping();  
            OnChanged("Data"); 
        }
        /// <summary>
        /// draws a small example of the visual output 
        /// </summary>
        /// <param name="p">render properties</param>
        /// <param name="sampleArea">area to draw the line + marker into</param>
        /// <param name="labelArea">area to draw corresponding label into</param>
        /// <remarks>derived classes implement this for current device contexts</remarks>
        public virtual void DrawToLegend(ILRenderProperties p, Rectangle sampleArea, Rectangle labelArea) {
            //if (g == null) throw new ILArgumentException ("ILGraph: DrawIntoLegend: invalid graphics object (null)"); 
            //throw new NotImplementedException ("ILGraph cannot draw to bitmap yet!"); 
        }

        /// <summary>
        /// Size of label
        /// </summary>
        /// <value>size</value>
        public Size LabelSize { get { return m_label.Size; } }
        #endregion

        #region constructor
        /// <summary>
        /// [internal] constructor - do not use this! Use ILPanel.Graphs.Add...() instead!
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="sourceArray">data array</param>
        /// <param name="clippingContainer">hosting panels clipping data</param>
        public ILPlot2DGraph (ILPanel panel, ILBaseArray sourceArray,
                              ILClippingData clippingContainer) 
            : base (panel,clippingContainer) {
            if (object.Equals(sourceArray,null) || !sourceArray.IsVector || !sourceArray.IsNumeric) 
                throw new ILArgumentException ("Plot2D: supplied data must be numeric (real valued) vector!");
            int pos = 0; 
            ILArray<float> data; 
            C4bV3f vert = new C4bV3f(); 
            if (sourceArray is ILArray<float>) {
                data = (ILArray<float>)sourceArray; 
            } else {
                data = ILMath.tosingle(sourceArray); 
            }
            m_vertices = new C4bV3f[data.Length+1]; 
            m_vertexCount = m_vertices.Length; 
            m_updateCount = 0; 
            m_startID = 0; 
            m_properties = new ILLineProperties(); 
            m_properties.Color = Color.DarkBlue; 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            foreach (float val in data.Values) {
                vert.Position = new ILPoint3Df(pos,val,0); 
                vert.Color = Color.Red; 
                m_vertices[pos++] = vert; 
            }
            m_marker = new ILMarker(panel); 
            m_marker.Changed += new EventHandler(m_properties_Changed);
            m_graphType = GraphType.Plot2D; 
            m_localClipping.Set(new ILPoint3Df(0,data.MinValue,0),new ILPoint3Df(data.Length-1,data.MaxValue,0));
        }
        /// <summary>
        /// [internal] constructor - do not use this! Use ILPanel.Graphs.Add...() instead!
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="XData">x data array</param>
        /// <param name="YData">y data array</param>
        /// <param name="clippingContainer">hosting panels clipping data</param>
        public ILPlot2DGraph (ILPanel panel, ILBaseArray XData, ILBaseArray YData,
                              ILClippingData clippingContainer) 
            : base (panel,clippingContainer) {
            if (!XData.IsVector)
                throw new ILArgumentException ("Plot2D: supplied data must be a real vector!"); 
            if (!YData.IsVector)
                throw new ILArgumentException ("Plot2D: XData and YData must be real vectors!"); 
            if (YData.Length != XData.Length) 
                throw new ILArgumentException ("Plot2D: XData and YData must have the same length!"); 
            int pos = 0; 
            ILArray<float> dataX, dataY; 
            C4bV3f vert = new C4bV3f(); 
            if (XData is ILArray<float>) {
                dataX = (ILArray<float>)XData; 
            } else {
                dataX = ILMath.tosingle(XData); 
            }
            if (YData is ILArray<float>) {
                dataY = (ILArray<float>)YData; 
            } else {
                dataY = ILMath.tosingle(YData); 
            }
            m_vertices = new C4bV3f[dataX.Length + 1]; 
            m_vertexCount = m_vertices.Length; 
            m_startID = m_vertexCount-1;
            m_updateCount = 0; 
            m_properties = new ILLineProperties(); 
            m_properties.Color = Color.DarkBlue; 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            foreach (float val in dataX.Values) {
                vert.Position = new ILPoint3Df(val,dataY.GetValue(pos),0); 
                vert.Color = m_properties.Color; 
                m_vertices[pos++] = vert; 
            }
            m_marker = new ILMarker(panel);
            m_marker.Changed += new EventHandler(m_marker_Changed);
            m_graphType = GraphType.Plot2D;
            updateClipping();
        }
        public void Queue(IILVertexDefinition vertex) {
            if (m_startID == 0) {
                SetVertex(m_vertexCount-1,vertex); 
                m_startID = 1; 
            } else {
                SetVertex(m_startID,vertex);
                m_vertices[0] = m_vertices[m_vertexCount-1]; 
                m_startID++;
            }
            if (m_startID == m_vertexCount-1) {
                m_startID = 0; 
            }
            if (m_updateCount++ < m_autoLimitsUpdateCount) {
                m_localClipping.Update(vertex.Position,vertex.Position); 
            } else {
                m_updateCount = 0; 
                Invalidate();
            }
        }

        #endregion

        #region private helper 
        public void SetVertex(int vertexID,IILVertexDefinition vertex) {
            C4bV3f curVert = m_vertices[vertexID]; 
            if (vertex.StoresColor) {
                curVert.Color = vertex.Color; 
            }
            curVert.Position = vertex.Position; 
            m_vertices[vertexID] = curVert; 
        }

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
            ILPoint3Df max = ILPoint3Df.MinValue; 
            ILPoint3Df min = ILPoint3Df.MaxValue;
            for (int i = 0; i < m_vertexCount; i++) {
                C4bV3f vert = m_vertices[i]; 
                max = ILPoint3Df.Max(vert.Position,max); 
                min = ILPoint3Df.Min(vert.Position,min); 
            }
            m_localClipping.Set ( min, max ); 
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
        public override bool Is3DGraph() {
            return false;
        }
        #endregion

        #region IILPanelConfigurator
        public void ConfigurePanel(ILPanel panel) {
            panel.InteractiveMode = InteractiveModes.ZoomRectangle;
            panel.AspectRatio = AspectRatioMode.StretchToFill;
            panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.StrictOptimal;
            panel.ClipViewData = true;
            panel.DefaultView.Set(0f, 0f, panel.DefaultView.Distance);
        }
        #endregion

    }
}
