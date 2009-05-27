using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc;
using ILNumerics.Drawing.Graphs;  
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// A simple single line
    /// </summary>
    public class ILLine : ILBorderedShape<C4bV3f> {

        #region attributes 
        ILLineProperties m_properties;
        int m_autoLimitsUpdateCount = 0;
        int m_updateCount = 0; 

        public int AutoLimitsUpdateCount {
            get { return m_autoLimitsUpdateCount; }
            set { m_autoLimitsUpdateCount = value; }
        } 
        int m_startID; 
        #endregion

        #region properties
        public ILLineProperties Properties {
            get { return m_properties; }
            set { m_properties = value; }
        } 
        internal int StartID {
            get { return m_startID; }
        }
        #endregion

        #region constructors
        public ILLine (ILPanel panel) 
            : this (panel,2) { }

        public ILLine (ILPanel panel, int numVertices) 
            : base (panel,numVertices+1) {
            if (numVertices < 2) 
                throw new ILArgumentException("line must have at least 2 points!"); 
            m_fillColor = Color.Black; 
            m_border.Visible = false; 
            m_startID = 0;  
            m_properties = new ILLineProperties(); 
            m_properties.Changed += new EventHandler(m_properties_Changed);
            m_autoLimitsUpdateCount = numVertices; 
        }
        #endregion

        #region private helpers 
        void m_properties_Changed(object sender, EventArgs e) {
            OnChanged();
        }

        #endregion

        #region public interface
        public override void Draw(ILRenderProperties props) {
            if (m_vertCount == 0 || m_vertCount >= VerticesPerShape) {
                m_renderer.Draw(props,this);
                if (!String.IsNullOrEmpty(m_label.Text) && m_vertCount > 1) {
                    ILPoint3Df cent = m_vertices[0].Position + m_vertices[1].Position;
                    m_label.Draw(props, cent / 2); 
                }
            }
        }
        public void Queue(IILVertexDefinition vertex) {
            if (m_startID == 0) {
                SetVertex(m_vertCount-1,vertex); 
                m_startID = 1; 
            } else {
                SetVertex(m_startID,vertex);
                m_vertices[0] = m_vertices[m_vertCount-1]; 
                m_startID++;
            }
            if (m_startID == m_vertCount-1) {
                m_startID = 0; 
            }
            if (m_updateCount++ < m_autoLimitsUpdateCount) {
                bool signal = false;
                m_positionMax = ILPoint3Df.Max(m_positionMax, vertex.Position, ref signal);
                m_positionMin = ILPoint3Df.Min(m_positionMin, vertex.Position, ref signal); 
                if (signal) {
                    OnSizeChanged(); 
                }
            } else {
                m_updateCount = 0; 
                Invalidate();
            }
        }

        #endregion


    }
}
