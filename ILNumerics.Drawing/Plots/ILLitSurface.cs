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
using ILNumerics.Drawing.Labeling; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// Surface graph supporting light and transparency
    /// </summary>
    public class ILLitSurface : ILSceneGraphInnerNode {

        protected ILColormap m_colorMap;
        protected ILBaseArray m_data;
        ILLitQuads m_quads;

        /// <summary>
        /// colormap used for coloring the surface 
        /// </summary>
        public ILColormap Colormap {
            get { return m_colorMap; }
            set {
                m_colorMap = value;
                Invalidate();
            }
        }
        /// <summary>
        /// reference to the label for the surface
        /// </summary>
        public ILShapeLabel Label {
            get { return m_quads.Label; }
        }
        /// <summary>
        /// get a reference to the data values or sets it, used for updates to the plot
        /// </summary>
        public ILBaseArray Data {
            get { return m_data; }
            set {
                if (value != null && value.Dimensions.IsSameSize(m_data.Dimensions)) {
                    m_data = value.CreateReference();
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// get reference to IILLitQuads lit composite shape used for rendering the surface
        /// </summary>
        public ILLitQuads Quads {
            get { return m_quads; }
        }
        /// <summary>
        /// create new lit surface, provide data array A
        /// </summary>
        /// <param name="panel">the panel hosting the scene</param>
        /// <param name="A">data matrix, at lease 2 rows, 2 columns</param>
        /// <param name="colormap">colormap used for auto coloring surface</param>
        public ILLitSurface(ILPanel panel, ILBaseArray A, ILColormap colormap)
            : base(panel) {
            m_quads = new ILLitQuads(panel, A.Dimensions.NumberOfElements);
            m_quads.Shading = ShadingStyles.Interpolate;
            Add(m_quads);
            m_colorMap = colormap;
            m_data = A.CreateReference();
            Invalidate();
        }
        /// <summary>
        /// create new lit surface, provide data array A
        /// </summary>
        /// <param name="panel">the panel hosting the scene</param>
        /// <param name="A">data matrix, at lease 2 rows, 2 columns</param>
        public ILLitSurface(ILPanel panel, ILBaseArray A)
            : this(panel, A, new ILColormap(Colormaps.ILNumerics)) { }

        public override void Configure() {
            if (m_invalidated) {
                m_quads.Indices = Computation.configureVertices(
                                m_data, m_colorMap, m_quads.Vertices);
                m_quads.Invalidate();
                m_quads.Configure();
                m_invalidated = false; 
            }
            base.Configure();
        }

        private class Computation : ILMath {
            public static ILArray<int> configureVertices(ILBaseArray data, ILColormap cmap, C4fN3fV3f[] Vertices) {
                int i = 0, x, y;
                double z;
                double minZ, maxZ;
                ILArray<double> A = todouble(data); 
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
