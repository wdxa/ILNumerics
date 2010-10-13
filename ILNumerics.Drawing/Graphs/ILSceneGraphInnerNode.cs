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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Shapes;

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// scene graph inner node, collection of children
    /// </summary>
    public class ILSceneGraphInnerNode : ILSceneGraphNode, ICollection<ILSceneGraphNode>,
            IList<ILSceneGraphNode> {

        #region attributes
        private List<ILSceneGraphNode> m_childs;
        private ILArray<float> m_centers;
        #endregion

        #region constructors
        public ILSceneGraphInnerNode(ILPanel panel) 
        :base (panel) {

            m_centers = ILArray<float>.empty(0, 3);
            m_childs = new List<ILSceneGraphNode>(); 

        }

        #endregion

        #region public interface
        /// <summary>
        /// recompute the size spanned by this node, may fires Changed() event
        /// </summary>
        public override void Configure() {
            if (m_invalidated) {
                // configure childs (compute limits) first
                foreach (ILSceneGraphNode child in m_childs) {
                    child.Configure();
                }
                bool sizechanged = false;
                ILPoint3Df oldMin = m_positionMin;
                ILPoint3Df oldMax = m_positionMax;
                ComputeNodeLimits();
                if (oldMin != m_positionMin) sizechanged = true;
                if (oldMax != m_positionMax) sizechanged = true;
                m_invalidated = false;
                if (sizechanged)
                    OnSizeChanged();
            }
        }
        public override void Draw(ILRenderProperties props) {
            if (!m_visible) {
                return;
            }
            if (m_childs != null && m_childs.Count > 0) {
                ILArray<int> indices = Computation.GetSortedIndices(
                                     m_centers, m_panel.Camera.Position);
                foreach (int i in indices.Values) {
                    if (m_childs[i].Visible)
                        m_childs[i].Draw(props);
                }
            }
        }
        public override void Invalidate() {
            base.Invalidate();
            m_centers = null; 
        }
        /// <summary>
        /// compute limits of the cube tightly enclosing the branch below this node
        /// </summary>
        /// <returns></returns>
        protected override void ComputeNodeLimits() {
            if (m_childs == null || m_childs.Count == 0) {
                m_positionMin = ILPoint3Df.Empty;
                m_positionMax = ILPoint3Df.Empty;
                return; 
            }
            // acquire maximum position
            ILPoint3Df curMax = ILPoint3Df.MinValue;
            ILPoint3Df curMin = ILPoint3Df.MaxValue;
            foreach (ILSceneGraphNode node in m_childs) {
                curMin = ILPoint3Df.Min(node.PositionMin, curMin);
            }
            curMax = ILPoint3Df.MinValue;
            foreach (ILSceneGraphNode node in m_childs) {
                curMax = ILPoint3Df.Max(node.PositionMax, curMax);
            }
            m_positionMax = curMax;
            m_positionMin = curMin;
            m_center = (m_positionMax + m_positionMin) / 2;
            // stores childs centers for sorting
            if (m_centers == null)
                m_centers = new ILArray<float>(); 
            for (int i = m_childs.Count; i-- > 0; ) {
                ILPoint3Df center = m_childs[i].Center;
                m_centers.SetValue(center.X, i, 0);
                m_centers.SetValue(center.Y, i, 1);
                m_centers.SetValue(center.Z, i, 2);
            }
        }
        protected override void CollectAllChildren(List<ILSceneGraphNode> nodes) {
            base.CollectAllChildren(nodes);
            if (m_childs != null) {
                foreach (ILSceneGraphNode child in m_childs) {
                    CollectAllChildren(nodes);
                }
            }
        }
        public virtual void Add(ILShape shape) {
            ILSceneGraphShapedLeaf node = new ILSceneGraphShapedLeaf(m_panel);
            node.Parent = this; 
            node.Shape = shape;
            m_childs.Add(node);
            Invalidate(); 
            OnNodeAdded(node); 
        }
        public virtual void Remove(ILShape shape) {
            ILSceneGraphNode node = null; 
            foreach (ILSceneGraphNode n in m_childs) {
                if (n is ILSceneGraphShapedLeaf) { 
                    if (object.Equals((n as ILSceneGraphShapedLeaf).Shape,shape)) {
                        node = n; 
                        break; 
                    }
                }
            }
            if (node != null) {
                m_childs.Remove(node); 
                OnNodeRemoved(node); 
            }
        }      
        #endregion

        #region IList<ILSceneGraphNode> Member

        public virtual ILSceneGraphNode this[int i] {
            get {
                return m_childs[i];
            }
            set {
                m_childs[i] = value;
                Invalidate(); 
            }
        }

        public virtual int IndexOf(ILSceneGraphNode item) {
            return m_childs.IndexOf(item);
        }

        public virtual void Insert(int index, ILSceneGraphNode item) {
            m_childs.Insert(index, item);
            Invalidate(); 
        }

        public virtual void RemoveAt(int index) {
            m_childs.RemoveAt(index);
            Invalidate(); 
        }
        #endregion

        #region ICollection<ILSceneGraphNode> Member
        /// <summary>
        /// add a single node to the end of child collection
        /// </summary>
        /// <param name="item">node to add </param>
        public virtual void Add(ILSceneGraphNode item) {
            m_childs.Add(item);
            item.Parent = this;
            item.Invalidate();
            OnNodeAdded(item);
        }
        /// <summary>
        /// wipe all nodes from the collection 
        /// </summary>
        public virtual void Clear() {
            m_childs.Clear();
            Invalidate(); 
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
            m_childs.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Number of children contained in this node
        /// </summary>
        public virtual int Count {
            get { return m_childs.Count; }
        }
        /// <summary>
        /// determine if this collection is readonly, (returns 'false')
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }
        /// <summary>
        /// remove a single child node from the collection
        /// </summary>
        /// <param name="item">node to be removed</param>
        /// <returns>true</returns>
        public virtual bool Remove(ILSceneGraphNode item) {
            m_childs.Remove(item);
            Invalidate();
            return true; 
        }

        #endregion

        #region private helpers

        private class Computation : ILNumerics.BuiltInFunctions.ILMath {
            /// <summary>
            /// compute distance to camera and return sorted indices for rendering
            /// </summary>
            /// <param name="centers">current primitive centers</param>
            /// <param name="position">current camera position</param>
            /// <returns>sorted indices of primitives in descending order</returns>
            internal static ILArray<int> GetSortedIndices(ILArray<float> centers,
                                            ILPoint3Df position) {
                ILArray<float> pos = new float[] { -position.X, -position.Y, -position.Z };
                // move camera outside of centers
                pos *= maxall(abs(centers));
                pos = repmat(pos, centers.Dimensions[0], 1);
                // compute distances
                ILArray<float> dist = sum(pow(centers - pos, 2), 1);
                ILArray<double> ret;
                sort(dist, out ret, 0, false);
                return toint32(ret);
            }
        }

        #endregion

    }
}
