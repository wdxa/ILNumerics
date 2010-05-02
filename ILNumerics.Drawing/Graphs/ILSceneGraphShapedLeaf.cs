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
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Graphs {

    /// <summary>
    /// a scene graph node, holding a single shape
    /// </summary>
    public class ILSceneGraphShapedLeaf : ILSceneGraphNode {

        #region attributes
        ILShape m_shape; 
        #endregion

        /// <summary>
        /// create a new shaped leaf
        /// </summary>
        /// <param name="panel"></param>
        public ILSceneGraphShapedLeaf(ILPanel panel) : base(panel) { }

        #region properties
        /// <summary>
        /// Get / set the shape of the scene graph node
        /// </summary>
        public ILShape Shape {
            get {
                return m_shape;
            }
            set {
                m_shape = value;
                if (value != null) {
                    value.SceneGraphNode = this; 
                }
            }
        }
        #endregion
        /// <summary>
        /// the minimum position of contained shape 
        /// </summary>
        public override ILPoint3Df PositionMin {
            get {
                if (m_shape != null)
                    return m_shape.PositionMin;
                else {
                    return ILPoint3Df.Empty; 
                }
            }
        }
        /// <summary>
        /// the maximum position of contained shape 
        /// </summary>
        public override ILPoint3Df PositionMax {
            get {
                if (m_shape != null)
                    return m_shape.PositionMax;
                else {
                    return ILPoint3Df.Empty;
                }
            }
        }
        /// <summary>
        /// the computed center of contained shape 
        /// </summary>
        public override ILPoint3Df Center {
            get {
                if (m_shape != null)
                    return m_shape.Center;
                else {
                    return ILPoint3Df.Empty;
                }
            }
        }
        /// <summary>
        /// invalidate this and all nodes up to root
        /// </summary>
        public override void Invalidate() {
            Invalidate(false);         
        }
        /// <summary>
        /// invalidate this node and all nodes up to root
        /// </summary>
        /// <param name="invalidateShape">true: invalidate the shape also</param>
        public void Invalidate(bool invalidateShape) {
            base.Invalidate();
            if (invalidateShape && m_shape != null) {
                m_shape.Invalidate(); 
            }
        }
        /// <summary>
        /// recompute the size spanned by this node, may fires Changed() event
        /// </summary>
        public override void Configure() {
            if (m_invalidated && m_shape != null) {
                bool sizechanged = false;
                m_shape.Configure();
                if (m_shape.PositionMin != m_positionMin) sizechanged = true;
                if (m_shape.PositionMax != m_positionMax) sizechanged = true;
                m_positionMax = m_shape.PositionMax;
                m_positionMin = m_shape.PositionMin; 
                m_invalidated = false;
                if (sizechanged)
                    OnSizeChanged();
            }
        }
        /// <summary>
        /// Draw this shape contained in this node (internal use)  
        /// </summary>
        /// <param name="props"></param>
        public override void Draw(ILRenderProperties props) {
            if (m_shape != null) {
                m_shape.Draw(props); 
            }
        }
        /// <summary>
        /// compute limits of the cube tightly enclosing the branch below this node
        /// </summary>
        /// <returns></returns>
        protected override void ComputeNodeLimits() {
            if (m_shape != null) {
                m_positionMin = m_shape.PositionMin;
                m_positionMax = m_shape.PositionMax;
            } else {
                m_positionMax = ILPoint3Df.Empty;
                m_positionMin = ILPoint3Df.Empty; 
            }
        }

    }
}
