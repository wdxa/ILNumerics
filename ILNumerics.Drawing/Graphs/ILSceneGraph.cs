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
using System.Collections; 
using System.Text;
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes;
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// The class implements a scene graph (tree), capable 
    /// of holding, managing and drawing all kinds of shapes.
    /// </summary>
    public class ILSceneGraph : ILGraph {

        #region eventing
        /// <summary>
        /// fires, once somewhere in the graph a node was added
        /// </summary>
        public event SceneGraphNodeHandler NodeAdded; 
        void OnNodeAdded(ILSceneGraphNodeEventArgs args) {
            if (NodeAdded != null) {
                NodeAdded(this, args);  
            }
        }
        public event SceneGraphNodeHandler NodeRemoved; 
        void OnNodeRemoved(ILSceneGraphNodeEventArgs args) {
            if (NodeRemoved != null) {
                NodeRemoved(this, args);  
            }
        }

        void m_root_Invalidated(object sender, EventArgs e) {
            base.Invalidate();
        }
        void m_root_SizeChanged(object sender, EventArgs e) {
            m_localClipping.Set(m_root.PositionMin, m_root.PositionMax);
        }
        void m_root_NodeAdded(object sender, ILSceneGraphNodeEventArgs args) {
            OnNodeAdded(args); 
        }
        void m_root_NodeRemoved(object sender, ILSceneGraphNodeEventArgs args) {
            OnNodeRemoved(args);
        }

        #endregion

        #region attributes
        private ILSceneGraphRoot m_root; 
        #endregion

        #region properties
        /// <summary>
        /// root node of the scene graph
        /// </summary>
        public ILSceneGraphInnerNode Root {
            get {return m_root; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// (internal) create new scene graph 
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="clipping">clipping data object, usually member of the panel</param>
        internal ILSceneGraph (ILPanel panel, ILClippingData clipping) 
            : base(panel,clipping) {
            m_root = new ILSceneGraphRoot(panel);
            m_root.Invalidated += new EventHandler(m_root_Invalidated);
            m_root.SizeChanged += new EventHandler(m_root_SizeChanged);
            m_root.NodeAdded += new SceneGraphNodeHandler(m_root_NodeAdded);
            m_root.NodeRemoved += new SceneGraphNodeHandler(m_root_NodeRemoved);
            m_graphType = GraphType.SceneGraph; 
        }

        #endregion

        #region public interface
        /// <summary>
        /// Determines if this graph renders in 3D, may overridden in derived class
        /// </summary>
        /// <returns></returns>
        public override bool Is3DGraph() {
            return true;
        }
        /// <summary>
        /// (internal use) draws the whole scene graph
        /// </summary>
        /// <param name="p"></param>
        public override void Draw(ILRenderProperties p) {
            m_root.Draw(p); 
        }
        /// <summary>
        /// (internal use) configures and prepares the scene graph for rendering
        /// </summary>
        public override void Configure() {
            if (!m_isReady) {
                m_root.Configure();
                m_isReady = true;
            }
        }
        /// <summary>
        /// add new node to root node
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(ILSceneGraphNode node) {
            AddNode(node, m_root);
        }
        /// <summary>
        /// add a shape to the root node
        /// </summary>
        /// <param name="shape"></param>
        public void AddNode(ILShape shape) {
            ILSceneGraphShapedLeaf node = new ILSceneGraphShapedLeaf(m_panel);
            node.Shape = shape; 
            AddNode(node, m_root);
        }
        /// <summary>
        /// add new node as child of another node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void AddNode(ILSceneGraphNode node, ILSceneGraphInnerNode parent) {
            parent.Add(node);             
        }
        /// <summary>
        /// collect all shapes contained in any scene graph nodes
        /// </summary>
        /// <returns></returns>
        public List<ILShape> GetAllShapes() {
            List<ILShape> ret = new List<ILShape>();
            getAllShapes(m_root, ret);
            return ret;  
        }
        #endregion

        #region private helpers
        private void getAllShapes(ILSceneGraphNode node, List<ILShape> ret) {
            foreach (ILSceneGraphNode n in node) {
                if (n is ILSceneGraphShapedLeaf) {
                    ILSceneGraphShapedLeaf snode = n as ILSceneGraphShapedLeaf;
                    if (snode.Shape != null)
                        ret.Add(snode.Shape);
                }
                getAllShapes(n,ret); 
            }
        }

        #endregion

        #region IEnumerable<ILShape> Member

        //public IEnumerator<ILShape> GetEnumerator() {
        //    List<ILShape> ret = new List<ILShape>(); 
        //    getAllShapes(m_root,ret); 
        //    return ret.GetEnumerator();  
        //}

        //#endregion

        //#region IEnumerable Member

        //IEnumerator GetEnumerator() {
        //    List<ILShape> ret = new List<ILShape>(); 
        //    getAllShapes(m_root,ret); 
        //    return ret.GetEnumerator();  
        //}

        //#endregion

        //#region IILPanelConfigurator
        //public override void ConfigurePanel(ILPanel panel) {
        //    panel.InteractiveMode = InteractiveModes.Rotating;
        //    panel.DefaultView.Set(5.8f, 1.17f, panel.DefaultView.Distance);
        //}
        #endregion

    }
}
