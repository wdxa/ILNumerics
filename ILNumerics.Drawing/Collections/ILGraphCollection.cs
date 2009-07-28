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
using ILNumerics.Exceptions;
using ILNumerics.Drawing.Internal;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Graphs; 

namespace ILNumerics.Drawing.Collections {
    /// <summary>
    /// Collection of graph objects - all graphs currently contained in a subfigure
    /// </summary>
    public class ILGraphCollection : List<ILGraph>, IDisposable {

        public event ILGraphCollectionChangedEvent CollectionChanged;
        public event ILGraphChangedEvent GraphChanged; 
        /// <summary>
        /// triggers the ILGraphCollectionChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reason"></param>
        void OnChange (ILGraph sender, GraphCollectionChangeReason reason, ILGraphChangedEventArgs graphArgs ) {
            if (CollectionChanged != null) 
                CollectionChanged(this, new ILGraphCollectionChangedEventArgs((ILGraph)sender,reason,graphArgs));
        }
        /// <summary>
        /// triggers GraphChanged event, bubbles from single graph
        /// </summary>
        /// <param name="graphArgs">event arguments from graph</param>
        protected void OnGraphChanged(ILGraph sender, ILGraphChangedEventArgs graphArgs) {
            if (GraphChanged != null) {
                GraphChanged(sender,graphArgs); 
            }
        }

        #region members / properties
        private IILCreationFactory m_graphFact; 
        private ILClippingData m_clippingData;
        /// <summary>
        /// Clippping volume for data in all graphs of the collection
        /// </summary>
        /// <remarks>This gives back the real ILClippingData object (no copy)</remarks>
        public ILClippingData Limits {
            get {
                return m_clippingData;
            }
        }
        #endregion 

        #region constructor / disposal
        /// <summary>
        /// Create new ILGraphCollection
        /// </summary>
        /// <param name="panel">Output panel </param>
        /// <param name="clippingData"></param>
        internal ILGraphCollection(IILCreationFactory vPainterFact) : base() {
            m_graphFact = vPainterFact; 
            m_clippingData = new ILClippingData();
        }
        /// <summary>
        /// dispose all graphs contained in this collection
        /// </summary>
        public void Dispose() {
            foreach (ILGraph graph in this) {
                if (graph != null) 
                    graph.Dispose(); 
            }
        }
        #endregion

        #region event handling
        ///// <summary>
        ///// signaled when one/some of the ILGraphs have changed
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Graph_Changed(object sender, ILGraphChangedEventArgs e) {
        //    OnGraphChanged(sender as ILGraph,e); 
        //}
        /// <summary>
        /// called when the limits of a graph have changed
        /// </summary>
        /// <param name="sender">graph</param>
        /// <param name="e">event args, holding a reference to the clipping data</param>
        void Limits_Changed(object sender, ClippingChangedEventArgs e) {
            ILPoint3Df max = ILPoint3Df.MinValue; 
            ILPoint3Df min = ILPoint3Df.MaxValue; 
            foreach (ILGraph graph in this) {
                max = ILPoint3Df.Max(max,graph.Limits.Max); 
                min = ILPoint3Df.Min(min,graph.Limits.Min); 
            }
            m_clippingData.Set(min,max); 
        }
        #endregion

        #region Collection manager
        /// <summary>
        /// clear all graphs from the collection
        /// </summary>
        public new void Clear() {
            lock (this) {
                foreach (ILGraph g in this) {
                    g.Dispose(); 
                }
                base.Clear(); 
            }
            m_clippingData.Reset();  
            Invalidate(); 
            OnChange(null,GraphCollectionChangeReason.Deleted,null); 
        }
        /// <summary>
        /// Add a new surface graph, provide all coordinate data
        /// </summary>
        /// <param name="Z">matrix holding Z coordinates (heights)</param>
        /// <returns>reference to newly created surface graph</returns>
        public ILSurfaceGraph AddSurfGraph(ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray C) {
            ILSurfaceGraph ret; 
            ret = (ILSurfaceGraph)m_graphFact.CreateGraph(Z,GraphType.Surf,X,Y,C);
            m_clippingData.Update(ret.Limits);
            Add(ret);
            ret.Changed += new ILGraphChangedEvent(GraphChanged);
            // trigger change event
            OnChange(ret,GraphCollectionChangeReason.Added,null); 
            return ret; 
        }
        /// <summary>
        /// Add a new surface graph to collection
        /// </summary>
        /// <param name="data">matrix holding data to be plotted</param>
        /// <returns>reference to newly created surface graph</returns>
        public ILSurfaceGraph AddSurfGraph(ILBaseArray data) {
            return (ILSurfaceGraph)Add(data,GraphType.Surf)[0]; 
        }
        /// <summary>
        /// Add a new scene graph to collection
        /// </summary>
        /// <param name="data">matrix holding data to be plotted</param>
        /// <returns>reference to newly created surface graph</returns>
        public ILSceneGraph AddSceneGraph() {
            ILSceneGraph newGraph = m_graphFact.CreateSceneGraph();  
            Add(newGraph); 
            newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
            newGraph.Limits.Changed += new ILClippingDataChangedEvent(Limits_Changed);
            // the scene graph is added as empty - no limits yet
            //m_clippingData.Update(newGraph.Limits); 
            return newGraph;
        }
        /// <summary>
        /// add an newly created scene graph instance to the collection of graphs 
        /// </summary>
        /// <param name="sceneGraph">exisisting instance of scene graph</param>
        /// <remarks><para>This overload may be used to add user defined graphs to 
        /// the collection of graphs in order to use them in ILPanels. The user 
        /// defined graph needs to derive from scene graph. It may uses all shapes 
        /// compatible with ILSceneGraph. (ILLine,ILPolygon,ILLitBox,ILQuads,ILTriangles, etc...)
        /// </para></remarks>
        public void AddSceneGraph(ILSceneGraph sceneGraph) { 
            if (sceneGraph == null) throw new ILArgumentException("scene graph must not be null!"); 
            Add(sceneGraph); 
            sceneGraph.Changed += new ILGraphChangedEvent(GraphChanged);
            sceneGraph.Limits.Changed += new ILClippingDataChangedEvent(Limits_Changed);
        }

        /// <summary>
        /// Add a new imagesc graph to collection
        /// </summary>
        /// <param name="data">matrix holding data to be drawn</param>
        /// <returns>newly created graph</returns>
        public ILImageSCGraph AddImageSCGraph(ILBaseArray data) {
            return (ILImageSCGraph)Add(data,GraphType.Imagesc)[0]; 
        }
        /// <summary>
        /// Add new line graph(s) (2D) to collection
        /// </summary>
        /// <param name="data">vector/array with date to be plotted. For arrays, the columns will be used.</param>
        /// <returns>Array of newly created graph(s)</returns>
        public ILPlot2DGraph[] AddPlot2DGraph(ILBaseArray data) {
            List<ILGraph> graphs = Add(data,GraphType.Plot2D);    
            List<ILPlot2DGraph> ret = new List<ILPlot2DGraph>(); 
            foreach (ILGraph g in graphs) 
                ret.Add((ILPlot2DGraph)g); 
            ILColorProvider.Colorize(ret);
            return ret.ToArray(); 
        }
        /// <summary>
        /// Add new X/Y 2D line graph(s), provide X and Y coordinates
        /// </summary>
        /// <param name="X">X coordinates. If this is a matrix, every column will produce an individual graph.</param>
        /// <param name="Y">Y coordinates. Same size than 'X'.</param>
        /// <returns>Array of newly created graph(s)</returns>
        public ILPlot2DGraph[] AddPlot2DGraph(ILBaseArray XData, ILBaseArray YData) {
            List<ILGraph> graphs = Add(XData,YData,GraphType.Plot2D);    
            List<ILPlot2DGraph> ret = new List<ILPlot2DGraph>(); 
            foreach (ILGraph g in graphs) 
                ret.Add((ILPlot2DGraph)g); 
            ILColorProvider.Colorize(ret);
            return ret.ToArray(); 
        }
        /// <summary>
        /// Add new numeric graph(s) of arbitrary (math) type
        /// </summary>
        /// <param name="data">data to be plotted</param>
        /// <param name="properties">determine GraphType</param>
        /// <returns>List with newly created graph(s)</returns>
        public List<ILGraph> Add (ILBaseArray data, GraphType graphType) {
            if (!data.IsNumeric) 
                throw new ILArgumentException("Add graph: data array must be numeric!");
            List<ILGraph> ret = new List<ILGraph>();
            ILGraph newGraph; 
            ILArray<float> tmpData;
            lock (this) {
                #region add each graph type seperately
                switch (graphType) {
                    case GraphType.Plot2D: 
                        if (data.IsVector || data.IsScalar) {
                            newGraph = m_graphFact.CreateGraph(data,graphType); 
                            Add(newGraph); 
                            newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                            m_clippingData.Update(newGraph.Limits);
                            newGraph.Limits.Changed += new ILClippingDataChangedEvent(Limits_Changed);
                            ret.Add(newGraph);
                        } else if (data.IsMatrix) {
                            // plot columns
                            m_clippingData.EventingSuspend();
                            tmpData = ILMath.tosingle(data); 
                            for (int c = 0; c < tmpData.Dimensions[1]; c++) {
                                newGraph = m_graphFact.CreateGraph(tmpData[null,c],graphType);  
                                Add(newGraph);
                                newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                                ret.Add(newGraph); 
                                m_clippingData.Update(newGraph.Limits); 
                                newGraph.Limits.Changed += new ILClippingDataChangedEvent(Limits_Changed);
                            } 
                            m_clippingData.EventingResume(); 
                        }
                        // trigger change event
                        OnChange(ret[0],GraphCollectionChangeReason.Added,null); 
                        break; 
                    case GraphType.Surf: 
                        if (!data.IsMatrix) 
                            throw new ILArgumentException("Surf: source data must be a matrix!"); 
                        tmpData = ILMath.tosingle(data); 
                        m_clippingData.EventingSuspend(); 
                        // margin for Z-Direction
                        float min = tmpData.MinValue; 
                        float max = tmpData.MaxValue; 
                        float zmarg = (max - min > 0)? (float)(Math.Abs(max-min)/10.0) : 0.0f; 
                        m_clippingData.Update(new ILPoint3Df(0,0,min - zmarg),new ILPoint3Df(data.Dimensions[1]-1,data.Dimensions[0]-1,max+zmarg)); 
                        m_clippingData.EventingResume(); 
                        newGraph = m_graphFact.CreateGraph(tmpData,graphType);
                        Add(newGraph);
                        newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                        // trigger change event
                        ret.Add(newGraph);
                        OnChange(newGraph,GraphCollectionChangeReason.Added,null); 
                        break;
                    case GraphType.Imagesc:
                        if (!data.IsMatrix) 
                            throw new ILArgumentException("Surf: source data must be a matrix!"); 
                        tmpData = ILMath.tosingle(data); 
                        // note, ImageSC does not contribute to global clipping, except that the clipping 
                        // will be updated to include z = 0! 
                        m_clippingData.EventingSuspend(); 
                        m_clippingData.Update(new ILPoint3Df(-0.5f,-.5f,0),new ILPoint3Df(data.Dimensions[1]-0.5f,data.Dimensions[0]-0.5f,0)); 
                        m_clippingData.EventingResume(); 
                        newGraph = m_graphFact.CreateGraph(tmpData,graphType);
                        Add(newGraph);
                        newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                        // trigger change event
                        OnChange(newGraph,GraphCollectionChangeReason.Added,null); 
                        ret.Add(newGraph);
                        break;
                    default: 
                        throw new ILDrawingException ("the type of drawing is not supported!");
                }
                #endregion
            }
            return ret; 
        }
        /// <summary>
        /// Add new graph(s) of arbitrary type, provide both axis data
        /// </summary>
        /// <param name="xData">x coordinates </param>
        /// <param name="graphType">type of graph to be added</param>
        /// <param name="yData">y coordinates</param>
        /// <returns>List with newly created graph(s)</returns>
        /// <remarks>The return value will be a list of all graphs created (and added),
        /// since more than one graph may have been specified. This depends on the 
        /// shape of the data provided.
        /// <para>Currently only Plot2D graphs are supported as GraphType! </para></remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if the data provided are nor 
        /// numeric or the size for one of the arrays <typeparamref name="xData"/> or <typeparamref name="yData"/> 
        /// do not match. </exception>
        public List<ILGraph> Add (ILBaseArray xData, ILBaseArray yData, GraphType graphType) {
            if (!yData.IsNumeric || !xData.IsNumeric) 
                throw new ILArgumentException("Add graph: data arrays must be numeric!");
            List<ILGraph> ret = new List<ILGraph>();
            ILGraph newGraph; 
            ILArray<float> tmpDataY, tmpDataX;
            lock (this) {
                #region add each graph type seperately
                switch (graphType) {
                    case GraphType.Plot2D: 
                        if (!yData.Dimensions.IsSameSize(xData.Dimensions))
                            throw new ILArgumentException("Add graph: for X/Y plots, the size of X and Y must be equal!");
                        if (yData.IsVector || yData.IsScalar) {
                            newGraph = m_graphFact.CreateGraph(yData,graphType,xData); 
                            Add(newGraph); 
                            newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                            m_clippingData.Update(newGraph.Limits); 
                            ret.Add(newGraph);
                        } else if (yData.IsMatrix) {
                            // plot columns
                            m_clippingData.EventingSuspend();
                            tmpDataY = ILMath.tosingle(yData); 
                            tmpDataX = ILMath.tosingle(xData); 
                            for (int c = 0; c < tmpDataY.Dimensions[1]; c++) {
                                newGraph = m_graphFact.CreateGraph(tmpDataY[null,c],graphType,tmpDataX[null,c]);  
                                Add(newGraph);
                                newGraph.Changed += new ILGraphChangedEvent(GraphChanged);
                                ret.Add(newGraph); 
                                m_clippingData.Update(newGraph.Limits); 
                            } 
                            m_clippingData.EventingResume(); 
                        }
                        // trigger change event
                        OnChange(ret[0],GraphCollectionChangeReason.Added,null); 
                        break; 
                    default: 
                        throw new ILDrawingException ("graph type is not supported in that mode yet!");
                }
                #endregion
            }
            return ret; 
        }
        /// <summary>
        /// Remove a graph from the collection and rescale data limits
        /// </summary>
        /// <param name="key">key of graph to be removed</param>
        /// <returns>the ILGraph removed or null, if the key does not exist</returns>
        /// <remarks>If the graph has been removed, the clipping data will be updated and a change event will be fired. </remarks>
        public new bool Remove(ILGraph graph) {
            lock (this) {
                if (!Contains(graph)) return false; 
                base.Remove(graph); 
                // recreate clipping regions 
                m_clippingData.EventingSuspend(); 
                m_clippingData.Reset();  
                foreach (ILGraph gr in this) {
                    m_clippingData.Update (gr.Limits); 
                }
                m_clippingData.EventingResume(); 
                OnChange(graph,GraphCollectionChangeReason.Deleted,null); 
                Invalidate();
                return true;
            }
        }
        
        #endregion

        #region public interface 
        public void Invalidate() {
            foreach (ILGraph g in this) {
                g.Invalidate(); 
            }
        }
        #endregion

        #region private helper
        #endregion

    }
}
