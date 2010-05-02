#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details.
//
#endregion

using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Text;

namespace ILNumerics.Drawing.Interfaces {

    /// <summary>
    /// definition of vertex data &amp; properties
    /// </summary>
    public interface IILVertexDefinition {
        /// <summary>
        /// determine, if the vertex is able to store individual alpha values
        /// </summary>
        bool StoresAlpha { get; }
        /// <summary>
        /// determine, if the vertex is able to store individual color values
        /// </summary>
        bool StoresColor { get; }
        /// <summary>
        /// determine, if the vertex is able to store normal data 
        /// </summary>
        bool StoresNormals { get; }
        /// <summary>
        /// Get/set the alpha value for the vertex
        /// </summary>
        byte Alpha { get; set; }
        /// <summary>
        /// Set the color for the vertex, alpha value is not modified!
        /// </summary>
        Color Color { get; set; }
        /// <summary>
        /// get/set position (X,Y,Z values) for the vertex 
        /// </summary>
        ILPoint3Df Position { get; set; }
        /// <summary>
        /// Get/set the normal vector for the value (see also: AutoCalculateNormals) 
        /// </summary>
        ILPoint3Df Normal { get; set; }
        /// <summary>
        /// get/set the X coordinate value for the vertex
        /// </summary>
        float XPosition { get; set; }
        /// <summary>
        /// get/set the Y coordinate value for the vertex
        /// </summary>
        float YPosition { get; set; }
        /// <summary>
        /// get/set the Z coordinate value for the vertex
        /// </summary>
        float ZPosition { get; set; }
        /// <summary>
        /// size of single vertex in bytes
        /// </summary>
        int VertexSize { get; }
    }

}
