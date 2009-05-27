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
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing; 
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.Shapes {
    
    public class ILLitBox 
        : ILLitCompositeShape<C4fN3fV3f> {

        #region attributes 
        ILPoint3Df m_min; 
        ILPoint3Df m_max; 
        #endregion

        #region properties 
        public ILPoint3Df Max {
            get { return m_max; } 
            set { 
                m_max = value; 
                Invalidate(); 
            }
        }
        public ILPoint3Df Min {
            get { return m_min; } 
            set { 
                m_min = value; 
                Invalidate(); 
            }
        }
        #endregion 

        #region constructors
        public ILLitBox (ILPanel panel, ILPoint3Df min, ILPoint3Df max) 
            : base (panel,8, 4) {
            m_fillColor = Color.Green;    
            m_max = max;
            m_min = min; 
            m_shading = ShadingStyles.Flat; 
            AutoNormal = false; 
            createVertices();
            Configure(); 
        }
        #endregion

        private void createVertices() {
            m_vertices[0].XPosition = m_min.X; 
            m_vertices[1].XPosition = m_max.X; 
            m_vertices[2].XPosition = m_max.X; 
            m_vertices[3].XPosition = m_min.X; 
            m_vertices[4].XPosition = m_min.X; 
            m_vertices[5].XPosition = m_max.X; 
            m_vertices[6].XPosition = m_max.X; 
            m_vertices[7].XPosition = m_min.X; 

            m_vertices[0].YPosition = m_min.Y; 
            m_vertices[1].YPosition = m_min.Y; 
            m_vertices[2].YPosition = m_max.Y; 
            m_vertices[3].YPosition = m_max.Y; 
            m_vertices[4].YPosition = m_min.Y; 
            m_vertices[5].YPosition = m_min.Y; 
            m_vertices[6].YPosition = m_max.Y; 
            m_vertices[7].YPosition = m_max.Y; 

            m_vertices[0].ZPosition = m_min.Z; 
            m_vertices[1].ZPosition = m_min.Z; 
            m_vertices[2].ZPosition = m_min.Z;
            m_vertices[3].ZPosition = m_min.Z; 
            m_vertices[4].ZPosition = m_max.Z; 
            m_vertices[5].ZPosition = m_max.Z; 
            m_vertices[6].ZPosition = m_max.Z; 
            m_vertices[7].ZPosition = m_max.Z; 

            m_shapeIndices = new ILArray<int>(6,4); 
            m_shapeIndices["0;:"] = new int[] {0,3,2,1};  // bottom
            m_shapeIndices["1;:"] = new int[] {1,5,4,0};  // side 1
            m_shapeIndices["2;:"] = new int[] {3,7,6,2};  // side 2
            m_shapeIndices["3;:"] = new int[] {7,3,0,4};  // side 3
            m_shapeIndices["4;:"] = new int[] {6,7,4,5};  // top
            m_shapeIndices["5;:"] = new int[] {5,1,2,6};  // side 4
            m_shapeIndices = m_shapeIndices.T;   

            m_vertices[0].Normal = new ILPoint3Df(0,-1f,0); 
            m_vertices[1].Normal = new ILPoint3Df(0, 0f,-1f); 
            m_vertices[2].Normal = new ILPoint3Df(0, 1f,0); 
            m_vertices[3].Normal = new ILPoint3Df(0, 0f, 1f); // not used 
            m_vertices[4].Normal = new ILPoint3Df(-1f, 0f, 0f); 
            m_vertices[5].Normal = new ILPoint3Df(0, 0f, 1f); 
            m_vertices[6].Normal = new ILPoint3Df(1f,0,0); 
            m_vertices[7].Normal = new ILPoint3Df(0,-1f,0); // not used  
        }
    }
}
