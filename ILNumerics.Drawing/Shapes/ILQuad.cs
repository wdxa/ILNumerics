using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc;
using ILNumerics.Drawing.Graphs;  
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// A single simple bordered quad
    /// </summary>
    public class ILQuad : ILBorderedShape<C4bV3f> {

        #region constructors
        public ILQuad (ILPanel panel) 
            : base (panel,4) { } 
        #endregion

    }
}
