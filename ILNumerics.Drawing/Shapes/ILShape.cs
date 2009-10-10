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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Labeling;
using ILNumerics.Drawing.Interfaces;  

namespace ILNumerics.Drawing.Shapes {
    #region ILShape<VertexType> class definition
    /// <summary>
    /// shape definition, specific vertex type
    /// </summary>
    /// <typeparam name="VertexType">the internal vertex type, IILVertexDefinition struct</typeparam>
    public abstract class ILShape<VertexType> : ILShape
        where VertexType : struct, IILVertexDefinition {

        #region attributes 
        protected VertexType[] m_vertices; 
        protected VertexType m_sampleVertex = new VertexType(); 
        protected readonly int m_numVerticesPerShape; 
        #endregion

        #region properties
        /// <summary>
        /// access to internal vertex array
        /// </summary>
        public virtual VertexType[] Vertices {
            get {
                return m_vertices; 
            }
        } 
        /// <summary>
        /// number of vertices per shape
        /// </summary>
        public int VerticesPerShape { 
            get { return m_numVerticesPerShape; }
        }
        /// <summary>
        /// get or manually define the center of the shape
        /// </summary>
        /// <remarks>Once an individual (custom) center was assigned to the CustomCenter
        /// property, that point is returned and used on subsequent queries for Center. 
        /// <para>In order to clear the custom center, set the CustomCenter property to ILPoint3Df.Emtpy.</para>
        /// <para>The center is important to position the shape in the scene - according to 
        /// other shapes. This defines the order in which the shapes are rendered, which 
        /// is neccessary for transparency to appear correctly. In general one should
        /// not alter the center. This will compute the center of a shape according to its 
        /// true vertices weight average. However, for certain special shapes it might 
        /// be helpful to override the center to manually determine the rendering order for the scenes' shape.</para></remarks>
        public ILPoint3Df CustomCenter {
            get {
                return m_customCenter;
            }
            set {
                if (value.IsEmtpy()) {
                    m_useCustomCenter = false;
                } else {
                    m_useCustomCenter = true;
                    m_customCenter = value;
                }
                OnChanged();
            }
        }
        /// <summary>
        /// internal vertex definition (readonly)
        /// </summary>
        public override IILVertexDefinition VertexDefinition {
            get {
                return (IILVertexDefinition)m_sampleVertex; 
            }
        }
        public override ILPoint3Df Center {
            get {
                if (m_useCustomCenter) return m_customCenter;
                ILPoint3Df ret = new ILPoint3Df();
                if (m_vertices.Length == 0) return ret;
                // technical problem: if any childs exist here, 
                // we would have to take their centers into account 
                // as well. this would be non-trivial, because
                // we dont easiely know how many childs exist in 
                // whole subtree (without walking them). So we only 
                // take the center of the shape here (as a hack). 
                foreach (IILVertexDefinition vertex in m_vertices) {
                    ret.X += vertex.XPosition;
                    ret.Y += vertex.YPosition;
                    ret.Z += vertex.ZPosition;
                }
                return ret / m_vertices.Length;
            }
        }
        #endregion

        #region constructors
        public ILShape (ILPanel panel, int numberVertices, int verticesPerShape) 
            : base (panel) {
            m_numVerticesPerShape = verticesPerShape; 
            m_vertices = new VertexType[numberVertices];
            m_vertCount = numberVertices; 
            m_renderer = panel.GetCreationFactory().CreateVertexRenderer(typeof(VertexType), this); 
            VertexType a = new VertexType(); 
            m_vertexStoresColor = a.StoresColor; 
        }
        #endregion

        #region public interface 
        public override ILPoint3Df PositionMin() {
            if (m_positionMin.IsEmtpy()) {
                m_positionMin = ILPoint3Df.MaxValue;
                foreach (ILSceneGraphNode node in m_childs) {
                    m_positionMin = ILPoint3Df.Min(node.PositionMin(), m_positionMin);
                }
                foreach (IILVertexDefinition vertex in m_vertices) {
                    if (vertex.XPosition < m_positionMin.X) m_positionMin.X = vertex.XPosition;
                    if (vertex.YPosition < m_positionMin.Y) m_positionMin.Y = vertex.YPosition;
                    if (vertex.ZPosition < m_positionMin.Z) m_positionMin.Z = vertex.ZPosition;
                }
            }
            return m_positionMin;
        }
        public override ILPoint3Df PositionMax() {
            if (m_positionMax.IsEmtpy()) {
                m_positionMax = ILPoint3Df.MinValue;
                foreach (ILSceneGraphNode node in m_childs) {
                    m_positionMax = ILPoint3Df.Max(node.PositionMax(), m_positionMax);
                }
                foreach (IILVertexDefinition vertex in m_vertices) {
                    if (vertex.XPosition > m_positionMax.X) m_positionMax.X = vertex.XPosition;
                    if (vertex.YPosition > m_positionMax.Y) m_positionMax.Y = vertex.YPosition;
                    if (vertex.ZPosition > m_positionMax.Z) m_positionMax.Z = vertex.ZPosition;
                }
            }
            return m_positionMax;
        }
        public override void Draw(ILRenderProperties props) {
            if (! m_visible) return; 
            m_renderer.Draw(props,this);
            if (!String.IsNullOrEmpty(m_label.Text)) 
                m_label.Draw(props, Center); 
        }

        public override IILVertexDefinition GetVertex(int id) {
            return (IILVertexDefinition)m_vertices[id]; 
        }
        public override void SetVertex(int vertexID,IILVertexDefinition vertex) {
            VertexType curVert = m_vertices[vertexID]; 
            if (VertexDefinition.StoresColor && vertex.StoresColor) {
                curVert.Color = vertex.Color; 
            }
            if (VertexDefinition.StoresNormals && vertex.StoresNormals) {
                curVert.Normal = vertex.Normal; 
            }
            curVert.Position = vertex.Position; 
            m_vertices[vertexID] = curVert; 
        }
        public override void SetColor(int vertexID,Color color) {
            if (VertexDefinition.StoresColor) {
                VertexType vert = m_vertices[vertexID]; 
                vert.Color = color; 
                m_vertices[vertexID] = vert; 
            }
        }
        public override void SetPosition(int vertexID,ILPoint3Df position) {
            VertexType vert = m_vertices[vertexID]; 
            vert.Position = position; 
            m_vertices[vertexID] = vert; 
        }
        public override void SetNormal(int vertexID,ILPoint3Df normal) {
            if (VertexDefinition.StoresNormals) {
                VertexType vert = m_vertices[vertexID]; 
                vert.Position = normal; 
                m_vertices[vertexID] = vert; 
            }
        }
        public override void Translate(ILPoint3Df offset) {
            for (int i = 0; i < m_vertCount; i++) {
                VertexType tmp = m_vertices[i]; 
                tmp.Position += offset; 
                m_vertices[i] = tmp; 
			}
        }
        #endregion

    }
    #endregion

    #region ILShape base class definition
    public abstract class ILShape  : ILSceneGraphNode, IDisposable {

        #region events 
        public event EventHandler Changed; 
        protected virtual void OnChanged() {
            if (Changed != null) {
                Changed(this, new EventArgs()); 
            }
        }
        public event EventHandler SizeChanged; 
        protected virtual void OnSizeChanged() {
            if (SizeChanged != null) {
                SizeChanged(this, new EventArgs()); 
            }
        }
        #endregion 

        #region attributes
        protected bool m_useCustomCenter; 
        protected ILPoint3Df m_customCenter; 
        protected Color m_fillColor; 
        protected ShadingStyles m_shading; 
        protected ILShapeLabel m_label; 
        protected bool m_vertexStoresColor; 
        protected bool m_visible; 
        /// <summary>
        /// panel hosting the scene (for current camera position and size updates)
        /// </summary>
        protected int m_vertCount;
        protected ILVertexRenderer m_renderer; 
        #endregion 

        #region properties 

        /// <summary>
        /// Switch visiblility for the shape on/off or reads the visibility value
        /// </summary>
        public bool Visible {
            get { return m_visible; }
            set { m_visible = value; }
        }

        /// <summary>
        /// Get/set method of area filling 
        /// </summary>
        /// <remarks><para>Two methods are available: 'Interpolate' and 'Flat'. For 'Interpolate' mode,
        /// the color and alpha values stored in individual vertices are used for rendering. 
        /// In 'Flat' mode, only the single properties 'FillColor' and 'Opacity' determine 
        /// the color and transparency of the whols shape. Even if vertices store individual
        /// color values, those are ignored in that case.</para></remarks>
        public ShadingStyles Shading {
            get { 
                return m_shading; 
            }
            set {
                if (m_shading == ShadingStyles.Interpolate && !VertexDefinition.StoresColor) {
                    throw new NotSupportedException("The underlying vertex type does not support individual colors! Use shading mode 'Flat' instead!"); 
                }
                m_shading = value; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// fill color for shape areas in flat shading mode
        /// </summary>
        /// <remarks>Setting this value will not alter the alpha value 
        /// (opacity). The alpha of the new value will be ignored.</remarks>
        public virtual Color FillColor { 
            get {
                return m_fillColor; 
            } 
            set {
                m_fillColor = Color.FromArgb(m_fillColor.A, value); 
                m_shading = ShadingStyles.Flat; 
                OnChanged(); 
            }
        }
        /// <summary>
        /// definition of internal vertex type (readonly)
        /// </summary>
        public abstract IILVertexDefinition VertexDefinition { get; }
        /// <summary>
        /// opacity for areas of the shape in flat shading mode 
        /// </summary>
        public byte Opacity { 
            get { return m_fillColor.A; }
            set { m_fillColor = Color.FromArgb(value, m_fillColor); }
        }
        /// <summary>
        /// Shape label
        /// </summary>
        public ILShapeLabel Label {
            get {
                return m_label; 
            }
        }
        /// <summary>
        /// number of vertices contained in this shape
        /// </summary>
        public int VertexCount { 
            get { return m_vertCount; }
        }
        #endregion

        #region constructors
        protected ILShape (ILPanel panel) : base(panel) {
            m_fillColor = Color.White;
            m_label = new ILShapeLabel(panel);
            m_label.Changed += new EventHandler(m_label_Changed); 
            m_label.Text = GetType().Name + " " + GetHashCode();
            m_shading = ShadingStyles.Flat; 
            m_visible = true; 
            Invalidate(); 
        }
        #endregion

        #region public interface
        /// <summary>
        /// may be overwritten in derived classes to clean up ressources
        /// </summary>
        public virtual void Dispose() {}
        /// <summary>
        /// access to an internal vertex
        /// </summary>
        /// <param name="id">number of vertex to be accessed</param>
        /// <returns>generic vertex definition interface instance</returns>
        public abstract IILVertexDefinition GetVertex(int id); 
        public abstract void SetColor(int id,Color color); 
        public abstract void SetPosition(int id,ILPoint3Df position);
        public abstract void SetNormal(int id,ILPoint3Df normal);
        public abstract void SetVertex(int vertexID,IILVertexDefinition vertex); 
        public abstract void Translate(ILPoint3Df offset); 

        #endregion

        #region private helpers
        void m_label_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        #endregion
    }
    #endregion
}
