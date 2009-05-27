using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Interfaces; 

namespace ILNumerics.Drawing.Shapes {
    public abstract class ILVertexRenderer {
        public abstract void Draw(ILRenderProperties props, ILShape shape); 
        public abstract void Draw(ILRenderProperties props, ILShape shape, ILArray<int> indices); 
        public bool UseLight = false; 
        public bool CloseLines = true; 
    }
}
