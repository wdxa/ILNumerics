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
using System.Drawing; 
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Misc;
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// Surface graph supporting light
    /// </summary>
    public class ILLitSurfaceShape : ILLitQuads {

        protected ILColormap m_colorMap; 
        /// <summary>
        /// create new lit surface, provide data array A
        /// </summary>
        /// <param name="panel">the panel hosting the scene</param>
        /// <param name="A">data matrix, at lease 2 rows, 2 columns</param>
        public ILLitSurfaceShape(ILPanel panel, ILArray<double> A)
            : base(panel, A.Dimensions.NumberOfElements) {
            m_colorMap = new ILColormap(Colormaps.ILNumerics); 
            m_shapeIndices = Computation.configureVertices(A, m_colorMap, Vertices);
            Invalidate(); 
        }

        private class Computation : ILMath {
            public static ILArray<int> configureVertices(ILArray<double> A, ILColormap cmap, C4fN3fV3f[] Vertices) {
                int i = 0, x, y;
                double z;
                double minZ, maxZ;
                if (!A.GetLimits(out minZ, out maxZ))
                    minZ = maxZ = 1.0;
                x = 0;
                y = A.Dimensions[0] - 1;
                ILArray<float> colors = (tosingle((A - minZ) / (maxZ - minZ)))[":"] * (cmap.Length-1);
                colors[isnan(colors)] = 0;
                foreach (double a in A.Values) {
                    C4fN3fV3f v = new C4fN3fV3f();
                    v.Position = new ILPoint3Df(x, y, (float)a);
                    byte r, g, b;
                    cmap.Map(colors.GetValue(i), out r, out g, out b);
                    v.Color = Color.FromArgb(255, r, g, b);
                    v.Alpha = 255; 
                    Vertices[i++] = v;
                    // set next position
                    y--;
                    if (y < 0) {
                        x++;
                        y = A.Dimensions[0] - 1;
                    }
                }

                // create quad indices
                int numQuad = (A.Dimensions[0] - 1) * (A.Dimensions[1] - 1);
                x = 0; y = 0;
                ILArray<double> ret = zeros(4, numQuad); 
                ILArray<double> mult = counter(0.0,1.0,A.Dimensions.ToIntArray());
                mult = mult["0:" + (A.Dimensions[0] - 2), "0:" + (A.Dimensions[1] - 2)];
                mult = mult[":"].T; 

                ret["0;:"] = mult;
                ret["3;:"] = mult + 1;
                mult = mult + A.Dimensions.SequentialIndexDistance(1); 
                ret["2;:"] = mult + 1;
                ret["1;:"] = mult; 
                return toint32(ret); 
            }
        }
    }
}
