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
using System.Text;

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// attribute used to identify IILRenderer types within assemblies 
    /// </summary>
    public class ILRendererAttribute : Attribute {
        /// <summary>
        /// the type of graphic device, the renderer is able to handle
        /// </summary>
        public readonly GraphicDeviceType GraphicDeviceType; 
        /// <summary>
        /// short name describing the renderer
        /// </summary>
        public readonly string Name; 
        /// <summary>
        /// long name describing the renderer
        /// </summary>
        public readonly string NameLong; 
        /// <summary>
        /// determine, if this renderer should be used as default 
        /// renderer for the graphic device and the coord system
        /// </summary>
        public readonly bool IsDefault; 

        /// <summary>
        /// Detemine the coord system the renderer is based on
        /// </summary>
        public readonly CoordSystem Coords; 

        /// <summary>
        /// Constructor for a new attribute describing non-default renderer
        /// </summary>
        /// <param name="type">graphic device type </param>
        /// <param name="Name">short name</param>
        /// <param name="NameLong">long name</param>
        public ILRendererAttribute(GraphicDeviceType type, string Name, string NameLong) {
            this.GraphicDeviceType = type; 
            this.Name = Name; 
            this.NameLong = NameLong; 
            this.IsDefault = false;
            this.Coords = CoordSystem.Screen; 
        }
        /// <summary>
        /// Constructor creating a new renderer attribute
        /// </summary>
        /// <param name="type">graphic device type </param>
        /// <param name="Name">short name</param>
        /// <param name="NameLong">long name</param>
        /// <param name="Default">'default' flag</param>
        public ILRendererAttribute(GraphicDeviceType type, string Name, string NameLong, bool Default, CoordSystem coords) {
            this.GraphicDeviceType = type; 
            this.Name = Name; 
            this.NameLong = NameLong; 
            this.IsDefault = Default;
            this.Coords = coords;
        }
    }
}
