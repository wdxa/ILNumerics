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
    /// abstract generic shape, specific vertex type
    /// </summary>
    /// <typeparam name="VertexType">the internal vertex type, IILVertexDefinition</typeparam>
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
        /// not alter the center. This will compute the center of a shape accordingly to its 
        /// real vertices weight average. However, for certain special shapes it might 
        /// be helpful to override the center to manually determine the rendering order in the scene.</para></remarks>
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
        /// <summary>
        /// Query single vertex via IILVertexDefinition interface 
        /// </summary>
        /// <param name="i">index of vertex in vertex array</param>
        /// <returns>vertex definition</returns>
        public override IILVertexDefinition GetVertex(int i) {
            return (IILVertexDefinition)m_vertices[i]; 
        }
        /// <summary>
        /// alter single vertex via IILVertexDefinition interface
        /// </summary>
        /// <param name="vertexIdx">index of vertex in vertex array</param>
        /// <param name="vertex">new vertex definition</param>
        public override void SetVertex(int vertexIdx,IILVertexDefinition vertex) {
            VertexType curVert = m_vertices[vertexIdx]; 
            if (VertexDefinition.StoresColor && vertex.StoresColor) {
                curVert.Color = vertex.Color; 
            }
            if (VertexDefinition.StoresNormals && vertex.StoresNormals) {
                curVert.Normal = vertex.Normal; 
            }
            curVert.Position = vertex.Position;
            m_vertices[vertexIdx] = curVert; 
        }
        /// <summary>
        /// set color for single vertex (color only, no alpha!)
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="color">new color</param>
        public override void SetColor(int vertexID,Color color) {
            if (VertexDefinition.StoresColor) {
                VertexType vert = m_vertices[vertexID]; 
                vert.Color = color; 
                m_vertices[vertexID] = vert; 
            }
        }
        /// <summary>
        /// set position if single vertex 
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="position">new position </param>
        public override void SetPosition(int vertexID,ILPoint3Df position) {
            VertexType vert = m_vertices[vertexID]; 
            vert.Position = position; 
            m_vertices[vertexID] = vert; 
        }
        /// <summary>
        /// set normal vector for single vertex
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="normal">new normal vector</param>
        public override void SetNormal(int vertexID,ILPoint3Df normal) {
            if (VertexDefinition.StoresNormals) {
                VertexType vert = m_vertices[vertexID]; 
                vert.Normal = normal; 
                m_vertices[vertexID] = vert; 
            }
        }
        /// <summary>
        /// translate all vertices of the shape
        /// </summary>
        /// <param name="offset">offset, all vertices will be moved by that amount</param>
        public override void Translate(ILPoint3Df offset) {
            for (int i = 0; i < m_vertCount; i++) {
                VertexType tmp = m_vertices[i]; 
                tmp.Position += offset; 
                m_vertices[i] = tmp; 
			}
        }
        #endregion

        #region private helper 
        protected override void ComputeLimits() {
            ILPoint3Df cent = new ILPoint3Df();
            if (m_vertices.Length == 0) {
                // fast exit
                m_positionCenter = cent;
                m_positionMin = cent;
                m_positionMax = cent;
                return;
            }
            ILPoint3Df max = ILPoint3Df.MinValue, min = ILPoint3Df.MaxValue, cur;
            foreach (IILVertexDefinition vertex in m_vertices) {
                cur = vertex.Position;
                cent = cent + cur;
                max = ILPoint3Df.Max(max, cur);
                min = ILPoint3Df.Min(min, cur);
            }
            m_positionCenter = cent / m_vertices.Length;
            m_positionMax = max;
            m_positionMin = min;
        }
        #endregion

    }
    #endregion

    #region ILShape base class definition
    /// <summary>
    /// abstract base class for all shapes 
    /// </summary>
    public abstract class ILShape  :  IDisposable {

        #region events 
        /// <summary>
        /// fires, when any properties of the shape have changed
        /// </summary>
        public event EventHandler Changed; 
        protected virtual void OnChanged() {
            if (Changed != null) {
                Changed(this, new EventArgs()); 
            }
        }
        /// <summary>
        /// fires when the size of the shape has changed
        /// </summary>
        public event EventHandler SizeChanged; 
        protected virtual void OnSizeChanged() {
            if (SizeChanged != null) {
                SizeChanged(this, new EventArgs()); 
            }
        }
        #endregion 

        #region attributes
        protected ILPanel m_panel; 
        protected bool m_useCustomCenter; 
        protected ILPoint3Df m_customCenter;
        protected ILPoint3Df m_positionMin;
        protected ILPoint3Df m_positionMax;
        protected ILPoint3Df m_positionCenter; 
        protected Color m_fillColor; 
        protected ShadingStyles m_shading; 
        protected ILShapeLabel m_label; 
        protected bool m_vertexStoresColor; 
        /// <summary>
        /// panel hosting the scene (for current camera position and size updates)
        /// </summary>
        protected int m_vertCount;
        protected ILVertexRenderer m_renderer;
        protected ILSceneGraphShapedLeaf m_sceneNode; 
        #endregion 

        #region properties 
        /// <summary>
        /// returns the scene graph node holding this shape
        /// </summary>
        public ILSceneGraphShapedLeaf SceneGraphNode {
            get {
                return m_sceneNode; 
            }
            set {
                m_sceneNode = value; 
            }
        }
        /// <summary>
        /// Get minimum coordinate of the cube enclosing the shape
        /// </summary>
        public ILPoint3Df PositionMin {
            get {
                if (m_positionMin.IsEmtpy())
                    ComputeLimits();
                return m_positionMin;
            }
        }
        /// <summary>
        /// Get maximum coordinate of the cube enclosing the shape
        /// </summary>
        public ILPoint3Df PositionMax {
            get {
                if (m_positionMax.IsEmtpy())
                    ComputeLimits();
                return m_positionMax;
            }
        }
        /// <summary>
        /// Get weight center of vertices 
        /// </summary>
        public ILPoint3Df Center {
            get {
                if (m_positionCenter.IsEmtpy())
                    ComputeLimits();
                return m_positionCenter;
            }
        }
        /// <summary>
        /// Get/set method of area filling 
        /// </summary>
        /// <remarks><para>Two methods are available: 'Interpolate' and 'Flat'. For 'Interpolate' mode,
        /// the color and alpha values stored in individual vertices are used for rendering. 
        /// In 'Flat' mode, only the single properties 'FillColor' and 'Opacity' determine 
        /// the color and transparency of the whole shape. Even if vertices store individual
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
        protected ILShape (ILPanel panel) {
            m_panel = panel; 
            m_fillColor = Color.White;
            m_label = new ILShapeLabel(panel);
            m_label.Changed += new EventHandler(m_label_Changed); 
            m_label.Text = GetType().Name + " " + GetHashCode();
            m_shading = ShadingStyles.Flat; 
            Invalidate(); 
        }
        #endregion

        #region public interface
        /// <summary>
        /// may be overwritten in derived classes to clean up ressources
        /// </summary>
        public virtual void Dispose() {}
        /// <summary>
        /// Query single vertex via IILVertexDefinition interface 
        /// </summary>
        /// <param name="i">index of vertex in vertex array</param>
        /// <returns>vertex definition</returns>
        public abstract IILVertexDefinition GetVertex(int id);
        /// <summary>
        /// set color for single vertex (color only, no alpha!)
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="color">new color</param>
        public abstract void SetColor(int id, Color color);
        /// <summary>
        /// set position if single vertex 
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="position">new position </param>
        public abstract void SetPosition(int id, ILPoint3Df position);
        /// <summary>
        /// set normal vector for single vertex
        /// </summary>
        /// <param name="vertexID">index of vertex in vertex array</param>
        /// <param name="normal">new normal vector</param>
        public abstract void SetNormal(int id, ILPoint3Df normal);
        /// <summary>
        /// alter single vertex via IILVertexDefinition interface
        /// </summary>
        /// <param name="vertexIdx">index of vertex in vertex array</param>
        /// <param name="vertex">new vertex definition</param>
        public abstract void SetVertex(int vertexID, IILVertexDefinition vertex);
        /// <summary>
        /// translate all vertices of the shape
        /// </summary>
        /// <param name="offset">offset, all vertices will be moved by that amount</param>
        public abstract void Translate(ILPoint3Df offset); 
        /// <summary>
        /// draw this shape (internal use) 
        /// </summary>
        /// <param name="props"></param>
        public void Draw (ILRenderProperties props) {
            IntDrawShape(props); 
            IntDrawLabel(props); 
        }
        /// <summary>
        /// configure this shape (internal use)
        /// </summary>
        public virtual void Configure() { }
        /// <summary>
        /// Invalidates this shape, needed after altering any vertex data
        /// </summary>
        public virtual void Invalidate() {

            m_positionMin = ILPoint3Df.Empty;
            m_positionMax = ILPoint3Df.Empty;
            m_positionCenter = ILPoint3Df.Empty;
            if (m_sceneNode != null) {
                m_sceneNode.Invalidate(false); 
            }
        }
        #endregion

        #region private helpers
        void m_label_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        protected virtual void IntDrawLabel(ILRenderProperties p) {
            if (!String.IsNullOrEmpty(m_label.Text)) 
                m_label.Draw(p, Center); 
        }
        protected virtual void IntDrawShape(ILRenderProperties p) {
            m_renderer.Draw(p,this);
        }
        protected abstract void ComputeLimits();
        #endregion
    }
    #endregion
}
