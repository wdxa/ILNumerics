using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Text;

namespace ILNumerics.Drawing.Interfaces {

    /// <summary>
    /// definition of vertex data &amp; properties
    /// </summary>
    public interface IILVertexDefinition {
        bool StoresAlpha { get; }
        bool StoresColor { get; }
        bool StoresNormals { get; }
        byte Alpha { get; set; }
        Color Color { get; set; }
        ILPoint3Df Position { get; set; }
        ILPoint3Df Normal { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }
        float ZPosition { get; set; }
        /// <summary>
        /// size of single vertex in bytes
        /// </summary>
        int VertexSize { get; }
    }

}
