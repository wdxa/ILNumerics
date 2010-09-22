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
using System.Threading;
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Misc {
    public class ILZoomAction : ILAction {
        
        ILPoint3Df m_MinCornerStart;
        ILPoint3Df m_MinCornerEnd; 
        ILPoint3Df m_MaxCornerStart; 
        ILPoint3Df m_MaxCornerEnd; 
        ILActionRamp m_ramp; 
        int m_currentStep; 
        ILPanel m_panel; 

        public ILZoomAction(ILPoint3Df MinCornerStart,
                            ILPoint3Df MinCornerEnd,
                            ILPoint3Df MaxCornerStart,
                            ILPoint3Df MaxCornerEnd, 
                            ILActionRamp ramp,
                            ILPanel panel) 
        : base () {
            m_MaxCornerEnd = ILPoint3Df.Max(MinCornerEnd,MaxCornerEnd);
            m_MaxCornerStart = ILPoint3Df.Max(MinCornerStart,MaxCornerStart); 
            m_MinCornerEnd = ILPoint3Df.Min(MinCornerEnd,MaxCornerEnd);
            m_MinCornerStart = ILPoint3Df.Min(MinCornerStart,MaxCornerStart);
            m_ramp = ramp; 
            m_panel = panel; 
        }

        protected override void RunInternal(object parameter) {
            float x1 = m_MinCornerStart.X;
            float y1 = m_MinCornerStart.Y;
            float z1 = m_MinCornerStart.Z;
            float x2 = m_MaxCornerStart.X;
            float y2 = m_MaxCornerStart.Y;
            float z2 = m_MaxCornerStart.Z;
            float aMinX = m_MinCornerEnd.X - x1;
            float aMinY = m_MinCornerEnd.Y - y1;
            float aMinZ = m_MinCornerEnd.Z - z1;
            float aMaxX = m_MaxCornerEnd.X - x2;
            float aMaxY = m_MaxCornerEnd.Y - y2;
            float aMaxZ = m_MaxCornerEnd.Z - z2;
            foreach (ILActionRampElement elem in m_ramp) {
                if (m_canceled) return; 
                ILPoint3Df min = new ILPoint3Df(
                            x1 + aMinX * elem.Value,
                            y1 + aMinY * elem.Value,
                            z1 + aMinZ * elem.Value);
                ILPoint3Df max = new ILPoint3Df(
                            x2 + aMaxX * elem.Value,
                            y2 + aMaxY * elem.Value,
                            z2 + aMaxZ * elem.Value); 
                m_panel.Limits.Set(min,max);
                m_panel.Refresh(); 
                if (m_canceled) return; 
                Thread.Sleep((int)(elem.Duration * 1000)); 
            }


        }
    }
}
