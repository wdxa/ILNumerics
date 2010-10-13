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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Misc;
using ILNumerics.Drawing.Graphs;  
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Shapes {
    /// <summary>
    /// points rendering shape, to be used in scene graphs
    /// </summary>
    public class ILPoints : ILCompositeShape<C4bV3f> {

        #region attributes
        int m_width; 
        #endregion

        #region properties 
        /// <summary>
        /// size (of all points)
        /// </summary>
        public int Width {
            get { return m_width; }
            set { 
                m_width = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// create new points 
        /// </summary>
        /// <param name="panel">panel hosting the scene graph</param>
        /// <param name="numPoints">number of points to create</param>
        public ILPoints (ILPanel panel, int numPoints) 
            : base (panel, numPoints, 1) { 
            m_fillColor = Color.Black; 
            // colors 
            ILColorEnumerator colors = new ILColorEnumerator(); 
            for (int i = 0; i < numPoints; i++) {
                m_vertices[i].Color = colors.NextColor(); 
            }
        }
        /// <summary>
        /// create point collection 
        /// </summary>
        /// <param name="panel">panel hosting the scene graph</param>
        /// <param name="data">numeric matrix with 1,2 or 3 rows, holding X,Y and Z values respectively</param>
        /// <param name="colors">3 rowed matrix with RGB values in columns. Values must lay in range 0...255. 
        /// If a 4th row is provided, it specifys the alpha value for the points (0...255). Otherwise the points will
        /// be fully opaque. </param>
        public ILPoints (ILPanel panel, ILBaseArray data, ILBaseArray colors) 
            : base (panel, data.Dimensions[1],1) {
            ILArray<float> fData;
            #region x coords
            if (data != null) {
                if (data is ILArray<float>) 
                    fData = (ILArray<float>)data; 
                else 
                    fData = ILNumerics.BuiltInFunctions.ILMath.tosingle(data); 
                switch (fData.Dimensions[0]) {
                    case 1:
                        for (int i = 0; i < m_vertCount; i++) {
                            m_vertices[i].XPosition = fData.GetValue(i); 
                        }
                        break; 
                    case 2: 
                        for (int i = 0; i < m_vertCount; i++) {
                            m_vertices[i].XPosition = fData.GetValue(0,i); 
                            m_vertices[i].YPosition = fData.GetValue(1,i); 
                        }
                        break; 
                    case 3: 
                        for (int i = 0; i < m_vertCount; i++) {
                            m_vertices[i].XPosition = fData.GetValue(0,i); 
                            m_vertices[i].YPosition = fData.GetValue(1,i); 
                            m_vertices[i].ZPosition = fData.GetValue(2,i); 
                        }
                        break; 
                }
            }
            #endregion

            #region colors 
            if (colors != null) {
                ILArray<byte> bCols; 
                if (!colors.IsMatrix || !colors.IsNumeric || (colors.Dimensions[0]!= 3 && colors.Dimensions[0]!= 4)) {
                    throw new ILArgumentException("invalid argument: colors must be numeric matrix, 3 rows with R,G,B values!"); 
                }
                if (colors is ILArray<byte>) 
                    bCols = (ILArray<byte>)colors; 
                else 
                    bCols = ILNumerics.BuiltInFunctions.ILMath.tobyte(colors); 
                if (colors.Dimensions[0] == 3) { 
                    for (int i = 0; i < m_vertCount; i++) {
                        m_vertices[i].Color = Color.FromArgb(bCols.GetValue(0,i),bCols.GetValue(1,i),bCols.GetValue(2,i)); 
                    }
                } else {
                    for (int i = 0; i < m_vertCount; i++) {
                        m_vertices[i].Color = Color.FromArgb(bCols.GetValue(3,i),bCols.GetValue(0,i),bCols.GetValue(1,i),bCols.GetValue(2,i)); 
                    }
                }
            }
            #endregion
            m_width = 4; 
            m_shading = ShadingStyles.Interpolate; 
        }
        #endregion

    }
}
