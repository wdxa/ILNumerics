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
    /// interface for a painter factory, capable of creating device dependend axis painters and graphs
    /// </summary>
    public interface IILCreationFactory {
        ILAxis CreateAxis(AxisNames name, ILClippingData clippingView, params object[] parameters);
        ILGraph CreateGraph(ILBaseArray data, GraphType graphType, params object[] additionalParams);
    }
}
