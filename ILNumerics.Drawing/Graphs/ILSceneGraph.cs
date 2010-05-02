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
    /// The class implementes a scene graph (tree), capable 
    /// of holding, managing and drawing all kinds of shapes.
    /// </summary>
    public class ILSceneGraph : ILGraph, IEnumerable<ILShape> {

        #region eventing
        void m_root_Invalidated(object sender, EventArgs e) {
            Invalidate();
        }
        #endregion

        #region attributes
        ILSceneGraphRoot m_root; 
        #endregion

        #region properties
        /// <summary>
        /// access to the root node of the scene
        /// </summary>
        public ILSceneGraphInnerNode Root {
            get {return m_root; }
        }
        #endregion

        #region constructors
        public ILSceneGraph (ILPanel panel, ILClippingData clipping) 
            : base(panel,clipping) {
            m_root = new ILSceneGraphRoot(panel);
            m_root.Invalidated += new EventHandler(m_root_Invalidated);
            m_root.SizeChanged += new EventHandler(m_root_SizeChanged);
            m_graphType = GraphType.SceneGraph; 
        }

        void m_root_SizeChanged(object sender, EventArgs e) {
            m_localClipping.Set(m_root.PositionMin,m_root.PositionMax);
        }
        #endregion

        #region public interface
        public override void Draw(ILRenderProperties p) {
            m_root.Draw(p); 
        }
        public override void Configure() {
            if (!m_isReady) {
                m_root.Configure();
                m_isReady = true;
            }
        }
        public void AddNode(ILSceneGraphNode node) {
            AddNode(node, m_root);
        }
        public void AddNode(ILShape shape) {
            ILSceneGraphShapedLeaf node = new ILSceneGraphShapedLeaf(m_panel);
            node.Shape = shape; 
            AddNode(node, m_root);
        }
        public void AddNode(ILSceneGraphNode node, ILSceneGraphInnerNode parent) {
            parent.Add(node);             
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

        public IEnumerator<ILShape> GetEnumerator() {
            List<ILShape> ret = new List<ILShape>(); 
            getAllShapes(m_root,ret); 
            return ret.GetEnumerator();  
        }

        #endregion

        #region IEnumerable Member

        IEnumerator IEnumerable.GetEnumerator() {
            List<ILShape> ret = new List<ILShape>(); 
            getAllShapes(m_root,ret); 
            return ret.GetEnumerator();  
        }

        #endregion
    }
}
