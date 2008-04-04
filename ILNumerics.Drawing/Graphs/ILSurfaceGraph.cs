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

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// Surface graph
    /// </summary>
    public abstract class ILSurfaceGraph : ILFilledGraph {

        #region attributes / properties

        /// <summary>
        /// determine, how the color for surface tiles will be drawn
        /// </summary>
        /// <remarks>Interpolated will interpolate the color for the 
        /// tiles between all corner data points. Flat will draw the area of the 
        /// tile in a single color. The color than reflects the average value of 
        /// all corner data points.</remarks>
        public ShadingStyles Shading {
            get {
                return m_shading; 
            }
            set {
                m_shading = value; 
                OnChanged(); 
            }
        }
        protected ShadingStyles m_shading;
        #endregion

        /// <summary>
        /// constructs new surface graph
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="clippingContainer"></param>
        public ILSurfaceGraph ( ILBaseArray sourceArray,
                                ILClippingData clippingContainer)
            : base (sourceArray,clippingContainer) {
            m_graphType = GraphType.Surf; 
            m_wireLines.Width = 1;
            m_wireLines.Antialiasing = false; 
            m_wireLines.Color = System.Drawing.Color.Blue;
            m_opacity = 0.84f;
        }

        /// <summary>
        /// create indices for ILSurfaceGraph triangles 
        /// </summary>
        /// <remarks>If possible, the indices will assemble triangle strips. If not -
        /// the base implementation will be used to create individual triangles.</remarks>
        protected override void CreateIndices() {
            if (m_opacity == 1.0f &&  m_shading == ShadingStyles.Interpolate) {
                #region no transparency
                // simple case: DepthTest on, we can do fast drawing
                // with low number on indices needed (triangle strips)
                checkVertexIndicesLength(m_cols * 2,m_rows-1); 
                int pos1 = 0, pos2 = m_cols, posI = 0; 
                while (posI < m_indicesCount) {
                    m_indices[posI++] = (uint)pos2++; 
                    m_indices[posI++] = (uint)pos1++;
                }
                #endregion
                if (m_wireLines.Visible) {
                    #region looking from front
                    posI = 0; 
                    System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi > 0 (grid front)");
                    checkGridIndicesLength((m_cols-1) * 4 + 2,m_rows-1); 
                    pos1 = m_Vertcount-m_cols; 
                    pos2 = m_Vertcount-m_cols;
                    // first row is special:
                    for (int c = m_cols-1; c-->0;) {
                        m_gridIndices[posI++] = (uint)pos1++; 
                        m_gridIndices[posI++] = (uint)pos1; 
                    }
                    pos1 -= 2*m_cols-1; 
                    for (int r = m_rows-1; r-->0;) {
                        // first column is special: 
                        m_gridIndices[posI++] = (uint)pos2; 
                        m_gridIndices[posI++] = (uint)pos1; 
                        for (int c = m_cols-1; c-->0;) {
                            m_gridIndices[posI++] = (uint)pos1++; 
                            m_gridIndices[posI++] = (uint)pos1; 
                            m_gridIndices[posI++] = (uint)++pos2; 
                            m_gridIndices[posI++] = (uint)pos1; 
                        }
                        pos1 -= (m_cols * 2 - 1); 
                        pos2 -= (m_cols * 2 - 1);
                    }
                    #endregion
                }
            } else {
                // create regular individual triangles 
                base.CreateIndices();
            }
        }
        protected override void OnWireLinesChanged() {
            base.OnWireLinesChanged();
            //if (m_wireLines.Width == 1 && m_wireLines.Antialiasing) {
            //    m_wireLines.m_antialiasing = false; 
            //    m_setAntialiasing = true; 
            //} else if (m_wireLines.Width > 1 && m_setAntialiasing) {
            //    m_setAntialiasing = false; 
            //    m_wireLines.Antialiasing = true; 
            //}
        }

    }
}
