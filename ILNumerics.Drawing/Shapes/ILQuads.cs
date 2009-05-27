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


namespace ILNumerics.Drawing.Shapes {
    
    public class ILQuads 
        : ILCompositeShape<C4bV3f> {

        #region constructors
        public ILQuads (ILPanel panel, int numQuads) 
            : base (panel, numQuads * 4, 4) {
            m_fillColor = Color.Green;    
        }
        public ILQuads (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,4,X,Y,Z) { 
            m_fillColor = Color.Green;    
        }
        public ILQuads (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel,4,X,Y,Z,mapping) { 
            m_fillColor = Color.Green;    
        }
        #endregion

    }
}
