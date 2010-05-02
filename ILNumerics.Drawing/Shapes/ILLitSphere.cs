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
    
    public class ILLitSphere 
        : ILLitCompositeShape<C4fN3fV3f> {

        #region attributes 
        ILPoint3Df m_center; 
        float m_radius; 
        int m_horRes = 20; 
        int m_vertRes = 10; 
        #endregion

        #region properties 
        #endregion 

        #region constructors
        public ILLitSphere (ILPanel panel, ILPoint3Df center, float radius, Color color) 
            : this (panel, 20,10, center, radius, color) {
            
        }
        public ILLitSphere (ILPanel panel, int horResolution, int vertResolution, ILPoint3Df center, float radius, Color color) 
            : base (panel,(horResolution+1)*(vertResolution+1), 4) {
            m_fillColor = color;    
            m_center = center;
            m_radius = radius;
            m_vertRes = vertResolution; 
            m_horRes = horResolution; 
            AutoNormals = false; 
            createVertices(m_horRes,m_vertRes); 
            colorVertices(color); 
        }

        #endregion

        private void createVertices(int horRes, int vertRes) {
            ILArray<float> vertData = Computation.CreateVertices(
                        m_center,m_radius,horRes++,vertRes++, out m_shapeIndices);
            ILPoint3Df tmp = new ILPoint3Df (); 
            for (int r = 0,pos = 0; r < vertRes; r++) {
                for (int c = 0; c < horRes; c++) {
                    m_vertices[pos].XPosition = vertData.GetValue(r,c,0); 
                    m_vertices[pos].YPosition = vertData.GetValue(r,c,1); 
                    m_vertices[pos].ZPosition = vertData.GetValue(r,c,2); 
                    tmp.X = vertData.GetValue(r,c,3);
                    tmp.Y = vertData.GetValue(r,c,4);
                    tmp.Z = vertData.GetValue(r,c,5);
                    m_vertices[pos++].Normal = tmp;      
                }
            }
        }
        private void colorVertices(Color color) {
            for (int i = 0; i < m_vertices.Length; i++) {
                m_vertices[i].Color = color; 
                m_vertices[i].Alpha = color.A; 
            }
        }


        private class Computation : ILMath {
            /// <summary>
            /// create vertex data
            /// </summary>
            /// <param name="center"></param>
            /// <param name="radius"></param>
            /// <param name="horRes"></param>
            /// <param name="vertRes"></param>
            /// <param name="indices"></param>
            /// <returns></returns>
            public static ILArray<float> CreateVertices (ILPoint3Df center, float radius, int horRes, int vertRes, out ILArray<int> indices) {
                ILArray<float> phi = repmat(tosingle(linspace(-pi,pi,horRes+1)),vertRes+1,1);
                ILArray<float> rho = repmat(tosingle(linspace(0,pi,vertRes+1)).T,1,horRes+1); 
                bool dummy; 
                float[] retArr = ILNumerics.Misc.ILMemoryPool.Pool.New<float>((horRes+1)*(vertRes+1),false, out dummy); 
                ILArray<float> ret = new ILArray<float>(retArr,vertRes+1,horRes+1); 
                // create normals 
                ret[":;:;3"] = sin(phi) * sin(rho); 
                ret[":;:;4"] = cos(phi) * sin(rho);
                ret[":;:;5"] = cos(rho);
                // translate + scale vertices
                ret[":;:;0"] = (ILArray<float>)radius * ret[":;:;3"] + center.X; 
                ret[":;:;1"] = (ILArray<float>)radius * ret[":;:;4"] + center.Y; 
                ret[":;:;2"] = (ILArray<float>)radius * ret[":;:;5"] + center.Z; 
                // create index mappings 
                //horRes--; vertRes--; 
                indices = new ILArray<int>(4,(horRes)*(vertRes)); 
                for (int r = 0,pos = 0; r < vertRes; r++) {
                    for (int c = 0; c < horRes; c++) {
                        indices.SetValue(c+r*(horRes+1),pos++);  
                        indices.SetValue(c+(r+1)*(horRes+1),pos++);  
                        indices.SetValue((c+1)+(r+1)*(horRes+1),pos++);  
                        indices.SetValue((c+1)+r*(horRes+1),pos++);  
                    }
                }
                System.Diagnostics.Debug.Assert(maxall(indices) <= (double)ret[":;:;0"].Dimensions.NumberOfElements); 
                System.Diagnostics.Debug.Assert(minall(indices) >= 0.0); 
                return ret; 
            }
        }
    }
}
