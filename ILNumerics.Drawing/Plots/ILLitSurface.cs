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

namespace ILNumerics.Drawing.Plots {
    /// <summary>
    /// Surface graph supporting light and transparency
    /// </summary>
    public class ILLitSurface : ILSceneGraphInnerNode {

        protected ILColormap m_colorMap;
        protected ILArray<float> m_xVals;
        protected ILArray<float> m_yVals; 
        protected ILArray<float> m_zVals;
        protected byte m_opacity = 255;  
        ILLitQuads m_quads;

        /// <summary>
        /// Overall opacity for the surface 
        /// </summary>
        public byte Opacity {
            get { return m_opacity; }
            set { 
                m_opacity = value;
                Invalidate(); 
            }
        }
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
        public ILBaseArray XValues {
            get { return m_xVals; }
            set {
                if (value != null && value.Dimensions.IsSameSize(m_zVals.Dimensions)) {
                    if (value is ILArray<float>)
                        m_xVals = ((ILArray<float>)value).R;
                    else
                        m_xVals = ILMath.tosingle(value);
                    Invalidate();
                } else {
                    throw new ArgumentException("invalid size of data array"); 
                }
            }
        }
        /// <summary>
        /// get a reference to the data values or sets it, used for updates to the plot
        /// </summary>
        public ILBaseArray YValues {
            get { return m_yVals; }
            set {
                if (value != null && value.Dimensions.IsSameSize(m_zVals.Dimensions)) {
                    if (value is ILArray<float>)
                        m_yVals = ((ILArray<float>)value).R;
                    else
                        m_yVals = ILMath.tosingle(value);
                    Invalidate();
                } else {
                    throw new ArgumentException("invalid size of data array");
                }
            }
        }
        /// <summary>
        /// get a reference to the data values or sets it, used for updates to the plot
        /// </summary>
        public ILBaseArray ZValues {
            get { return m_zVals; }
            set {
                if (value != null && (m_zVals == null || value.Dimensions.IsSameSize(m_zVals.Dimensions))) {
                    if (value is ILArray<float>)
                        m_zVals = ((ILArray<float>)value).R;
                    else
                        m_zVals = ILMath.tosingle(value);
                    Invalidate();
                } else {
                    throw new ArgumentException("invalid size of data array");
                }
            }
        }
        /// <summary>
        /// [deprecated] Z coordinate values, use ZValues instead!
        /// </summary>
        public ILBaseArray Data {
            get { return m_zVals; }
            set {
                ZValues = value; 
            }
        }
        /// <summary>
        /// get reference to IILLitQuads lit composite shape used for rendering the surface
        /// </summary>
        public ILLitQuads Quads {
            get { return m_quads; }
        }

        /// <summary>
        /// create new lit surface, provide data array Z
        /// </summary>
        /// <param name="panel">the panel hosting the scene</param>
        /// <param name="Z">data matrix, at lease 2 rows, 2 columns</param>
        /// <param name="colormap">colormap used for auto coloring surface</param>
        public ILLitSurface(ILPanel panel, ILBaseArray Z, ILColormap colormap)
            : base(panel) {
            if (Z == null || Z.Dimensions[0] < 2 || Z.Dimensions[1] < 2)
                throw new ArgumentException("invalid parameter size: Z");
            m_quads = new ILLitQuads(panel, Z.Dimensions.NumberOfElements);
            m_quads.Label.Text = ""; 
            m_quads.Shading = ShadingStyles.Interpolate;
            Add(m_quads);
            m_colorMap = colormap;
            ZValues = Z; 
            Invalidate();
        }
        /// <summary>
        /// create new lit surface, provide data for X,Y and Z coordinates
        /// </summary>
        /// <param name="panel">the panel hosting the scene</param>
        /// <param name="X">X coordinates matrix, same size as Z or null</param>
        /// <param name="Y">Y coordinates matrix, same size as Z or null</param>
        /// <param name="Z">Z data matrix, at lease 2 rows, 2 columns</param>
        /// <param name="colormap">colormap used for auto coloring surface</param>
        public ILLitSurface(ILPanel panel, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILColormap colormap)
            : base(panel) {
            if (Z == null || Z.Dimensions[0] < 2 || Z.Dimensions[1] < 2)
                throw new ArgumentException("invalid parameter size: Z");
            if (X == null || !X.Dimensions.IsSameSize(Z.Dimensions))
                throw new ArgumentException("invalid parameter size: X");
            if (Y == null || !Y.Dimensions.IsSameSize(Z.Dimensions))
                throw new ArgumentException("invalid parameter size: Y");
            m_quads = new ILLitQuads(panel, Z.Dimensions.NumberOfElements);
            m_quads.Label.Text = ""; 
            m_quads.Shading = ShadingStyles.Interpolate;
            Add(m_quads);
            m_colorMap = colormap;
            ZValues = Z; 
            XValues = X;
            YValues = Y;

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
                                m_xVals,m_yVals,
                                m_zVals, m_colorMap, m_quads.Vertices, m_opacity);
                m_quads.Invalidate();
                m_quads.Configure();
                m_invalidated = false; 
            }
            base.Configure();
        }

        private class Computation : ILMath {
            public static ILArray<int> configureVertices(
                    ILArray<float> xVals, ILArray<float> yVals,
                    ILArray<float> zVals, ILColormap cmap, C4fN3fV3f[] Vertices, byte opacity) {
                int i = 0, x, y;
                float minZ, maxZ;
                if (!zVals.GetLimits(out minZ, out maxZ))
                    minZ = maxZ = 1.0f;
                x = 0;
                y = zVals.Dimensions[0] - 1;
                ILArray<float> colors = (tosingle((zVals - minZ) / (maxZ - minZ)))[":"] * (cmap.Length - 1);
                colors[isnan(colors)] = 0;
                bool useXvals = (xVals != null && !xVals.IsEmpty);
                bool useYvals = (yVals != null && !yVals.IsEmpty);
                foreach (float a in zVals.Values) {
                    C4fN3fV3f v = new C4fN3fV3f();
                    v.Position = new ILPoint3Df(
                         (useXvals)? xVals.GetValue(y,x): x 
                        ,(useYvals)? yVals.GetValue(y,x): y
                        , a);
                    byte r, g, b;
                    cmap.Map(colors.GetValue(i), out r, out g, out b);
                    v.Color = Color.FromArgb(255, r, g, b);
                    v.Alpha = opacity; 
                    Vertices[i++] = v;
                    // set next position
                    y--;
                    if (y < 0) {
                        x++;
                        y = zVals.Dimensions[0] - 1;
                    }
                }

                // create quad indices
                int numQuad = (zVals.Dimensions[0] - 1) * (zVals.Dimensions[1] - 1);
                x = 0; y = 0;
                ILArray<double> ret = zeros(4, numQuad);
                ILArray<double> mult = counter(0.0, 1.0, zVals.Dimensions.ToIntArray());
                mult = mult["0:" + (zVals.Dimensions[0] - 2), "0:" + (zVals.Dimensions[1] - 2)];
                mult = mult[":"].T; 

                ret["0;:"] = mult;
                ret["1;:"] = mult + 1;
                mult = mult + zVals.Dimensions.SequentialIndexDistance(1); 
                ret["2;:"] = mult + 1;
                ret["3;:"] = mult; 
                return toint32(ret); 
            }
        }
    }
}
