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
    
    public class ILTriangles 
        : ILCompositeShape<C4bV3f> {
 
        #region eventing 
        #endregion

        #region attributes
        #endregion

        #region properties
        #endregion

        #region constructors
        public ILTriangles (ILPanel panel, int numTriangles) 
            : base (panel, numTriangles * 3, 3) {
            m_fillColor = Color.Blue;    
        }
        public ILTriangles (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel,3, X,Y,Z) { }
        public ILTriangles (ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel, 3,X,Y,Z) { }
        #endregion

    }
}
