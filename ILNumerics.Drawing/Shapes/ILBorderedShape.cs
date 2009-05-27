using System;
using System.Drawing; 
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Interfaces;  
using ILNumerics.Drawing.Controls; 
namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// Base class for all simple shapes, rendering a primitive 
    /// with a border, which is independantly configurable. 
    /// </summary>
    /// <typeparam name="VertexType">inner vertex element type (struct)</typeparam>
    public abstract class ILBorderedShape<VertexType> : ILShape<VertexType> 
        where VertexType : struct, IILVertexDefinition {

        #region eventing 
        #endregion

        #region attributes
        protected ILLineProperties m_border; 
        #endregion

        #region properties 

        public ILLineProperties Border {
            get {
                return m_border; 
            }
        }
        #endregion

        public ILBorderedShape (ILPanel panel, int numVertices) 
            : base(panel,numVertices,numVertices) {
            m_border = new ILLineProperties();
            m_border.Changed += new EventHandler(m_border_Changed);
            m_fillColor = Color.Yellow;
            m_border.Width = 1; 
            m_border.Antialiasing = false; 
            m_border.Color = Color.Bisque; 
            m_shading = ShadingStyles.Flat; 
            m_vertexStoresColor = false; 
        }

        void m_border_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        public override void Draw(ILRenderProperties props) {
            if (m_vertCount == 0 || m_vertCount >= VerticesPerShape) {
                m_renderer.Draw(props,this);
                if (!String.IsNullOrEmpty(m_label.Text) && m_vertCount > 1) {
                    ILPoint3Df cent = m_vertices[0].Position + m_vertices[1].Position;
                    m_label.Draw(props, cent / 2); 
                }
            }
        }
    }
}
