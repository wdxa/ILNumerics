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
using ILNumerics.Drawing.Graphs; 

namespace ILNumerics.Drawing.Misc {
    public class ILGraphComparer : IComparer<ILGraph> {

        ILPoint3Df m_camera; 
        public ILGraphComparer (ILPoint3Df camera) {
            m_camera = camera; 
        }

        #region IComparer<ILGraph> Member

        /// <summary>
        /// sort graphs regarding their Z order 
        /// </summary>
        /// <param name="x">first graph</param>
        /// <param name="y">second graph</param>
        /// <returns></returns>
        public int Compare(ILGraph x, ILGraph y) {
            if (m_camera.Z > 0)
                return Comparer<float>.Default.Compare(x.Limits.CenterF.Z,y.Limits.CenterF.Z); 
            else     
                return Comparer<float>.Default.Compare(y.Limits.CenterF.Z,x.Limits.CenterF.Z); 
            // if finer control over sorting is needed, try the following code instead! 
            //ILPoint3Df cent1 = x.Limits.CenterF; 
            //ILPoint3Df cent2 = y.Limits.CenterF; 
            //float distX = cent1.X - m_camera.X; 
            //float distY = cent1.Y - m_camera.Y; 
            //float distZ = cent1.Z - m_camera.Z; 
            //float dist1 = distX * distX + distY * distY + distZ * distZ; 
            //distX = cent2.X - m_camera.X;
            //distY = cent2.Y - m_camera.Y;
            //distZ = cent2.Z - m_camera.Z;
            //float dist2 = distX * distX + distY * distY + distZ * distZ; 
            //if (dist2 > dist1) {
            //    return 1; 
            //} else if (dist2 == dist1) {
            //    return 0; 
            //} else 
            //    return -1; 
        }
        #endregion
    }
}
