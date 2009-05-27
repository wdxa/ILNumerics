using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc; 


namespace ILNumerics.Drawing.Shapes {
    
    public class ILLines 
        : ILCompositeShape<C4bV3f> {

        #region attributes 
        ILLineProperties m_properties;
        void m_properties_Changed(object sender, EventArgs e) {
            OnChanged(); 
        }
        #endregion

        #region properties
        public ILLineProperties Properties {
            get { return m_properties; }
        } 
        #endregion

        #region constructors
        public ILLines (ILPanel panel, int numLines) 
            : base (panel, numLines * 2, 2) {
            m_fillColor = Color.Blue;   
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }

        public ILLines (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,2,X,Y,Z) { 
            m_fillColor = Color.Blue;    
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
        }
        public ILLines (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel,2,X,Y,Z,mapping) { 
            m_fillColor = Color.Blue; 
            m_properties = new ILLineProperties();
            m_properties.Changed += new EventHandler(m_properties_Changed);
            ILColorEnumerator colors = new ILColorEnumerator();
            for (int i = 0; i < m_vertCount; i++) {
                m_vertices[i].Color = colors.NextColor(); 
            }
        }
        #endregion

    }
}
