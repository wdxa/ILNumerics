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
using ILNumerics.Drawing.Internal; 
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Interfaces {
    /// <summary>
    /// interface for a painter factory, capable of creating device dependend axes and graphs 
    /// </summary>
    /// <remarks>The interface is implemented by (device dependent) panel implementations. 
    /// It is used to create the ILPanel's object hirarchy on startup. </remarks>
    public interface IILCreationFactory {
        /// <summary>
        /// create an axis according to the current 
        /// </summary>
        /// <param name="name">axis name</param>
        /// <param name="clippingView">clipping of the host</param>
        /// <param name="parameters">additional parameters</param>
        /// <returns>newly created axis object</returns>
        ILAxis CreateAxis(AxisNames name, ILClippingData clippingView, params object[] parameters);
        /// <summary>
        /// Create a new specific ILGraph object (device dependent)
        /// </summary>
        /// <param name="data">numeric data for the new graph</param>
        /// <param name="graphType">type of graph</param>
        /// <param name="additionalParams">additional parameter</param>
        /// <returns>newly created graph instance</returns>
        ILGraph CreateGraph(ILBaseArray data, GraphType graphType, params object[] additionalParams);
    }
}
