using System;
using System.Collections.Generic;
using System.Text;

namespace ILNumerics.Drawing {
    /// <summary>
    /// extended drawing properties 
    /// </summary>
    /// <remarks>the class collects flags for special 
    /// rendering states (vector exports, picking). 
    /// </remarks>
    public class ILRenderProperties {  
        public ILCamera Camera; 
        public bool Clipping; 
        public System.Drawing.Graphics Graphics; 
    }
}
