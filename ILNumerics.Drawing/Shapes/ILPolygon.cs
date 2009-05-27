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
    /// A simple polygon, rendering arbitrary number of corners, bordered
    /// </summary>
    public class ILPolygon : ILBorderedShape<C4bV3f> {

        #region constructors
        public ILPolygon (ILPanel panel, int numVertices) 
            : base (panel,numVertices) { 
            
        }
        #endregion

    }
}
