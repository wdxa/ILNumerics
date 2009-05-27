using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.Labeling {
    public class ILShapeLabel : ILLabelingElement {
 
        #region attributes 
        ILPanel m_panel;
        #endregion

        #region constructors
        public ILShapeLabel(ILPanel panel) : base(panel, null, Color.Black) {
            m_panel = panel; 
            m_alignment = TickLabelAlign.center | TickLabelAlign.vertCenter; 
        }
        #endregion

        #region public interface 
        public void Draw(ILRenderProperties p, ILPoint3Df center ) {
            if (!String.IsNullOrEmpty(Text)) {
                if (m_expression != m_cachedExpression) 
                    interprete(m_expression); 
                double[] modelview = null; 
                m_renderer.Begin(p, ref modelview);
                Point dest = m_panel.Transform(center,modelview); 
                offsetAlignment(m_size,ref dest);
                m_renderer.Draw(m_renderQueue,dest,TextOrientation.Horizontal,m_color); 
                m_renderer.End(p); 
            }
        }
        #endregion
    }
}
