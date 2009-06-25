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
    /// Base class for all scene graph nodes. A node
    /// can contain an arbitrary number of other nodes, building 
    /// the graph. 
    /// </summary>
    public abstract class ILSceneGraphNode : 
                ICollection<ILSceneGraphNode>, IEnumerable<ILSceneGraphNode>, IEnumerable {
        
        #region attributes 
        protected ILSceneGraphNode m_parent; 
        protected ILPoint3Df m_center;
        protected ILPoint3Df m_positionMin; 
        protected ILPoint3Df m_positionMax; 
        protected List<ILSceneGraphNode> m_childs = new List<ILSceneGraphNode>(); 
        protected ILArray<float> m_centers;
        protected ILPanel m_panel;
        protected bool m_invalidated; 
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
        /// the minimum coordinate of a cube tightly enclosing the shape
        /// </summary>
        /// <returns></returns>
        public virtual ILPoint3Df PositionMin() {
            if (m_positionMin.IsEmtpy()) {
                m_positionMin = ILPoint3Df.MaxValue; 
                foreach (ILSceneGraphNode node in m_childs) {
                    m_positionMin = ILPoint3Df.Min(node.PositionMin(),m_positionMin); 
                }
            } 
            return m_positionMin;
        }
        /// <summary>
        /// the maximum coordinate of a cube tightly enclosing the shape
        /// </summary>
        /// <returns></returns>
        public virtual ILPoint3Df PositionMax () {
            if (m_positionMax.IsEmtpy()) {
                m_positionMax = ILPoint3Df.MinValue; 
                foreach (ILSceneGraphNode node in m_childs) {
                    m_positionMax = ILPoint3Df.Max(node.PositionMax(),m_positionMax); 
                }
            }
            return m_positionMax; 
        }
        /// <summary>
        /// current center according to shapes vertices 
        /// </summary>
        public virtual ILPoint3Df Center {
            get {
                if (m_center.IsEmtpy()) {
                    m_center = new ILPoint3Df();
                    for (int i = 0; i < m_childs.Count; i++) {
                        ILPoint3Df center = m_childs[i].Center;
                        m_center += center;
                        m_centers.SetValue(center.X, i, 0);
                        m_centers.SetValue(center.Y, i, 1);
                        m_centers.SetValue(center.Z, i, 2);
                    }
                    m_center /= (m_childs.Count);
                }
                return m_center;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct a new scene graph node 
        /// </summary>
        /// <param name="panel">the hosting panel</param>
        public ILSceneGraphNode (ILPanel panel) {
            m_centers = new ILArray<float>(0,3); 
            m_panel = panel; 
            m_center = ILPoint3Df.Empty; 
            m_positionMin = ILPoint3Df.Empty; 
            m_positionMax = ILPoint3Df.Empty; 
            m_invalidated = true; 
        }
        #endregion

        #region public interface 
        /// <summary>
        /// invalidate nodes cache, may or may not for childs also
        /// </summary>
        /// <param name="invalidChilds">true: clear the size cache for all childs also</param>
        public void Invalidate(bool invalidChilds) {
            m_center = ILPoint3Df.Empty;
            m_positionMin = ILPoint3Df.Empty;
            m_positionMax = ILPoint3Df.Empty;
            if (invalidChilds) {
                invalidateChilds(this);
            }
            if (Parent != null) {
                Parent.Invalidate(false);
            } else {
                OnInvalidated();
            }
            m_invalidated = true;
        }
        /// <summary>
        /// Invalidate nodes cache, recompute size spanned by this node on next redraw
        /// </summary>
        public void Invalidate() {
            Invalidate(true);
        }
        /// <summary>
        /// recompute the size spanned by this node, may fires Changed() event
        /// </summary>
        public virtual void Configure() {
            if (m_invalidated) {
                bool sizechanged = false; 
                ILPoint3Df oldPoint = m_positionMin; 
                m_positionMin = PositionMin();
                if (oldPoint != m_positionMin) sizechanged = true; 
                oldPoint = m_positionMax; 
                m_positionMax = PositionMax();
                if (!sizechanged && oldPoint != m_positionMax) sizechanged = true;
                m_center = Center;
                m_invalidated = false;
                if (sizechanged) 
                    OnSizeChanged(); 
            }
        }
        /// <summary>
        /// draw a childs contained by this node
        /// </summary>
        /// <param name="props">extended rendering properties</param>
        public virtual void Draw(ILRenderProperties props) { 
            if (m_childs != null && m_childs.Count > 0) {
                ILArray<int> indices = Computation.GetSortedIndices(
                                     m_centers,m_panel.Camera.Position); 
                foreach (int i in indices.Values) {
                    m_childs[i].Draw(props); 
                }
            }
        }
        #endregion

        #region private helper 
        protected void invalidateChilds(ILSceneGraphNode parent) {
            parent.m_center = ILPoint3Df.Empty;
            parent.m_positionMin = ILPoint3Df.Empty;
            parent.m_positionMax = ILPoint3Df.Empty;
            foreach (ILSceneGraphNode child in parent.m_childs) {
                child.invalidateChilds(child);
            }
        }
        #endregion

        #region IList<ILSceneGraphNode> Member

        public virtual int IndexOf(ILSceneGraphNode item) {
            return m_childs.IndexOf(item); 
        }

        public virtual void Insert(int index, ILSceneGraphNode item) {
            m_childs.Insert(index,item); 
        }

        public virtual void RemoveAt(int index) {
            m_childs.RemoveAt(index); 
        }
        #endregion

        #region ICollection<ILSceneGraphNode> Member
        /// <summary>
        /// add a single node to the end of child collection
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(ILSceneGraphNode item) {
            m_childs.Add(item);
            item.Parent = this; 
        }
        /// <summary>
        /// wipe all nodes from the collection 
        /// </summary>
        public virtual void Clear() {
            m_childs.Clear(); 
        }
        /// <summary>
        /// Determine, if this collection contains a specific node item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ILSceneGraphNode item) {
            return m_childs.Contains(item); 
        }

        public void CopyTo(ILSceneGraphNode[] array, int arrayIndex) {
            m_childs.CopyTo(array,arrayIndex); 
        }
        /// <summary>
        /// Number of childs this node contains
        /// </summary>
        public int Count {
            get { return m_childs.Count;  }
        }
        /// <summary>
        /// determine if this collection is readonly, always returns false
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }
        /// <summary>
        /// remove a single child node from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Remove(ILSceneGraphNode item) {
            return m_childs.Remove(item); 
        }

        #endregion

        #region IEnumerable<ILSceneGraphNode> Member
        /// <summary>
        /// Create &amp; returns a typed enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ILSceneGraphNode> GetEnumerator() {
            return m_childs.GetEnumerator(); 
        }

        #endregion

        #region IEnumerable Member
        /// <summary>
        /// Create and return untyped enumerator
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            foreach (ILSceneGraphNode node in m_childs) {
                yield return node; 
            }
        }

        #endregion

    private class Computation : ILNumerics.BuiltInFunctions.ILMath {
        /// <summary>
        /// compute distance to camera and return sorted indices for rendering
        /// </summary>
        /// <param name="centers">current primitive centers</param>
        /// <param name="position">current camera position</param>
        /// <returns>sorted indices of primitives in descending order</returns>
        internal static ILArray<int> GetSortedIndices(ILArray<float> centers, 
                                        ILPoint3Df position) {
            ILArray<float> pos = new float[]{ -position.X, -position.Y, -position.Z }; 
            // move camera outside of centers
            pos *= maxall(abs(centers)); 
            pos = repmat(pos,centers.Dimensions[0],1); 
            // compute distances
            ILArray<float> dist = sum(pow(centers-pos,2),1); 
            ILArray<double> ret; 
            sort(dist,out ret, 0,false); 
            return toint32(ret); 
        }
    }

    }

}
