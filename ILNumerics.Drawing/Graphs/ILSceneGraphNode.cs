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
using ILNumerics.Drawing.Collections; 
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// abstract base class for all scene graph nodes
    /// </summary>
    public abstract class ILSceneGraphNode : 
                //ICollection<ILSceneGraphNode>,
                IEnumerable<ILSceneGraphNode>
                ,IEnumerable {
        
        #region attributes 
        protected ILSceneGraphNode m_parent; 
        protected ILPoint3Df m_center;
        protected ILPoint3Df m_positionMin; 
        protected ILPoint3Df m_positionMax; 
        protected bool m_invalidated;
        protected bool m_visible;
        protected ILPanel m_panel; // needed for camera position
        #endregion

        #region constructors
        internal ILSceneGraphNode(ILPanel panel) {
            m_panel = panel; 
            m_invalidated = true;
            m_visible = true; 
        }
        #endregion

        #region eventing
        /// <summary>
        /// fires when the size of the cube tigthly enclosing the shape has changed
        /// </summary>
        public event EventHandler SizeChanged;
        protected virtual void OnSizeChanged() {
            if (SizeChanged != null)
                SizeChanged(this, new EventArgs());
        }
        /// <summary>
        /// fires when the (size)cache of the node was invalidated
        /// </summary>
        public event EventHandler Invalidated;
        protected virtual void OnInvalidated() {
            if (Invalidated != null)
                Invalidated(this, new EventArgs());
        }
        #endregion

        #region properties

        /// <summary>
        /// Get/set visiblility for the scene graph branch 
        /// </summary>
        public bool Visible {
            get { return m_visible; }
            set { m_visible = value; 
            }
        }
        /// <summary>
        /// reference to the scene graph node this node is a child of
        /// </summary>
        public ILSceneGraphNode Parent {
            get {
                return m_parent; 
            }
            set {
                m_parent = value; 
            }
        }
        /// <summary>
        /// the minimum coordinate of a cube tightly enclosing the node (and all childs) 
        /// </summary>
        /// <returns></returns>
        public virtual ILPoint3Df PositionMin {
            get {
                if (m_positionMin.IsEmtpy()) {
                    ComputeNodeLimits();
                }
                return m_positionMin;
            }
        }
        /// the maximum coordinate of a cube tightly enclosing the node (and all childs) 
        /// </summary>
        /// <returns></returns>
        public virtual ILPoint3Df PositionMax {
            get {
                if (m_positionMax.IsEmtpy()) {
                    ComputeNodeLimits();
                }
                return m_positionMax;
            }
        }
        /// <summary>
        /// current geometric center according of scene graph branch
        /// </summary>
        public virtual ILPoint3Df Center {
            get {
                if (m_center.IsEmtpy()) {
                    ComputeNodeLimits(); 
                }
                return m_center;
            }
        }
        #endregion

        #region public interface 
        /// <summary>
        /// invalidate geometry cache for this and all nodes up to root
        /// </summary>
        public virtual void Invalidate() {
            m_center = ILPoint3Df.Empty;
            m_positionMin = ILPoint3Df.Empty;
            m_positionMax = ILPoint3Df.Empty;
            m_invalidated = true;
            if (Parent != null) {
                Parent.Invalidate();
            } else {
                OnInvalidated();
            }
        }
        /// <summary>
        /// recompute the size spanned by this node, may fires Changed() event
        /// </summary>
        public abstract void Configure(); 
        /// <summary>
        /// draw all children contained in this node
        /// </summary>
        /// <param name="props">extended rendering properties</param>
        public abstract void Draw(ILRenderProperties props);

        #endregion

        #region private helper 
        /// <summary>
        /// compute limits of the cube tightly enclosing the branch below this node
        /// </summary>
        /// <returns></returns>
        protected abstract void ComputeNodeLimits(); 

        //protected void invalidateChilds(ILSceneGraphNode parent) {
        //    parent.m_center = ILPoint3Df.Empty;
        //    parent.m_positionMin = ILPoint3Df.Empty;
        //    parent.m_positionMax = ILPoint3Df.Empty;
        //    foreach (ILSceneGraphNode child in parent.m_childs) {
        //        child.invalidateChilds(child);
        //    }
        //}
        #endregion

        #region IEnumerable<ILSceneGraphNode> Member

        /// <summary>
        /// Create &amp; returns a typed enumerator
        /// </summary>
        /// <returns>enumerator of all scene graph nodes below this node</returns>
        public IEnumerator<ILSceneGraphNode> GetEnumerator() {
            List<ILSceneGraphNode> ret = new List<ILSceneGraphNode>();
            CollectAllChildren(ret);
            return ret.GetEnumerator(); 
        }
        #endregion

        #region IEnumerable Member
        /// <summary>
        /// Create and return untyped enumerator
        /// </summary>
        /// <returns>IEnumerator of all scene graph nodes below this node</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            List<ILSceneGraphNode> children = new List<ILSceneGraphNode>();
            CollectAllChildren(children);
            foreach (ILSceneGraphNode node in children) {
                yield return node; 
            }
        }
        protected virtual void CollectAllChildren(List<ILSceneGraphNode> nodes) {
            nodes.Add(this); 
        }
        
        #endregion

    }

}
