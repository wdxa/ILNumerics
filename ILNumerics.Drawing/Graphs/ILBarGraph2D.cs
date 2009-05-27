using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Misc; 
using System.Drawing; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling;

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// simple updatable bar graph implementation, fixed number of bars
    /// </summary>
    public class ILBarGraph2D : ILSceneGraph, IILLegendRenderer {

        #region attributes 
        float m_barWidth; 
        ILQuad[] m_quads; 
        ILLabel m_legendLabel; 
        int m_oldestBarIndex; 
        #endregion 

        #region properties
        /// <summary>
        /// padding between graphs 
        /// </summary>
        public float BarWidth {
            get {
                return m_barWidth; 
            }
            set {
                m_barWidth = value;
                OnChanged("BarWidth"); 
            }
        }
        /// <summary>
        /// number of bars in the graph
        /// </summary>
        public int Count {
            get {
                return m_quads.Length; 
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// create new 2D bar graph
        /// </summary>
        /// <param name="panel">hosting panel</param>
        /// <param name="data">numeric vector data, heights + number of bars</param>
        public ILBarGraph2D (ILPanel panel, ILBaseArray data) 
            : base (panel, panel.Graphs.Limits) {
            // spacing between + width of bars
            m_barWidth = 0.6f; 
            // create the bars
            createQuads(data); 
            m_graphType = GraphType.Bar; 
            m_legendLabel = new ILLabel(m_panel);
            m_oldestBarIndex = 0; 
        }
        #endregion

        #region public interface
        /// <summary>
        /// return reference to single bar (ILQuad) by index
        /// </summary>
        /// <param name="index">index of the bar</param>
        /// <returns>the bar shape as ILQuad</returns>
        public ILQuad this [int index] {
            get { return m_quads[index]; }
        }
        /// <summary>
        /// add 'new' bar with new value and remove oldest bar
        /// </summary>
        /// <param name="value">height of new bar</param>
        /// <returns>discarded value</returns>
        public float Queue(float value) {
            // we move all shapes by 1 left
            ILPoint3Df offset = new ILPoint3Df(-1f,0,0);
            for (int i = 0; i < m_quads.Length; i++) {
                m_quads[i].Translate(offset);
                // FADE OUt old barsss .... 
                m_quads[(i + m_oldestBarIndex) % (m_quads.Length - 1)].Opacity 
                    = (byte)(i * 255.0 / m_quads.Length);
            }
            // configure oldest graph
            ILQuad newestQuad = m_quads[m_oldestBarIndex];
            offset.X = m_quads.Length; 
            newestQuad.Translate(offset);
            float ret = newestQuad.Vertices[2].YPosition; 
            newestQuad.Vertices[2].YPosition = value;
            newestQuad.Vertices[3].YPosition = value;
            newestQuad.Opacity = 255; 

            // tell the scene to update its size
            Root.Invalidate(); 

            if (++m_oldestBarIndex >= m_quads.Length) 
                m_oldestBarIndex = 0; 
            return ret;        
        }
        #endregion

        #region IILLegendRenderer Member
        /* In order to show up in the legend, the graph needs to 
         * implement the IILLegendRenderer interface. Here this is 
         * done very simple via 2 labels. The first one simple draws 
         * the text "Bars" in the sample area of the legend. The original 
         * ILLabel of the graph is then used to draw its text into the 
         * label area of the legend. 
         */ 
        public void DrawToLegend(ILRenderProperties p, Rectangle sampleArea, Rectangle labelArea) {
            m_legendLabel.Text = "Bars"; 
            m_legendLabel.Position = sampleArea.Location; 
            m_legendLabel.Draw(p); 
            m_label.Position = labelArea.Location;
            m_label.Draw(p); 
        }
        #endregion

        #region private helper 
        protected void createQuads(ILBaseArray data) {
            if (data == null || data.Length == 0) {
                Root.Clear(); 
                m_quads = new ILQuad[0];
            } else {
                Root.Clear(); 
                m_quads = new ILQuad[data.Length]; 
                ILColorEnumerator colors = new ILColorEnumerator(); 
                ILArray<float> fData = null; 
                if (data is ILArray<float>) {
                    fData = (ILArray<float>)data; 
                } else {
                    fData = ILMath.tosingle(data);
                }
                for (int i = 0; i < m_quads.Length; i++) {
                    m_quads[i] = new ILQuad(Panel); 
                    m_quads[i].Border.Visible = true; 
                    m_quads[i].FillColor = colors.NextColor(); 
                    ILPoint3Df pos = new ILPoint3Df(); 
                    pos.X = i - m_barWidth / 2; 
                    pos.Y = 0; 
                    pos.Z = -0.5f; 
                    m_quads[i].Vertices[0].Position = pos; 
                    pos.X += m_barWidth; 
                    m_quads[i].Vertices[1].Position = pos; 
                    pos.Y += fData.GetValue(i); 
                    m_quads[i].Vertices[2].Position = pos; 
                    pos.X -= m_barWidth; 
                    m_quads[i].Vertices[3].Position = pos; 
                    // label the bar
                    m_quads[i].Label.Text = i.ToString(); 
                    m_quads[i].Label.Alignment = TickLabelAlign.center | TickLabelAlign.top; 
                    // bars will be transparent,oldest fading out
                    m_quads[i].Opacity = (byte)(5 + i * 230f / m_quads.Length); 
                    // add the bar to the (underlying) scene graph
                    AddNode(m_quads[i]); 
                }
            }
        }
        #endregion
    }
}
