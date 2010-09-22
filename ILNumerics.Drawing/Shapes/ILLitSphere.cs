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
        : ILLitCompositeShape<C4fN3fV3f>
    {

        #region attributes
        ILPoint3Df m_center; 
        float m_radius; 
        int m_detail = 1;
        #endregion

        #region properties 
        #endregion 

        #region constructors
        /// <summary>
        /// create new lit sphere, resolution of 3 
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="center">center position</param>
        /// <param name="radius">radius of the sphere</param>
        /// <param name="color">color of the sphere</param>
        public ILLitSphere (ILPanel panel, ILPoint3Df center, float radius, Color color) 
            : this (panel, center, radius, color, 3) {
        }
        /// <summary>
        /// create new lit sphere for a scene graph
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="center">center position</param>
        /// <param name="radius">radius of the sphere</param>
        /// <param name="color">color of the sphere</param>
        /// <param name="detail">number of triangularization iterations, typical: 0..4</param>
        public ILLitSphere (ILPanel panel, ILPoint3Df center, float radius, Color color, int detail) 
            : base (panel,3,3) {
            m_fillColor = color;
            m_center = center;
            m_radius = radius;
            m_detail = detail;
            Material.Shininess = 60;
            AutoNormals = true;
            m_shading = ShadingStyles.Interpolate; 
            createVertices(detail);
        }
        #endregion

        #region public interface
        #endregion
        
        private void createVertices(int detail) {
            //ILArray<float> vertData = Computation.CreateVertices(
            //            m_center,m_radius,horRes,vertRes, out m_shapeIndices); 
            ILArray<float> vertData = Computation.CreateVerticesTri(
                        detail, out m_shapeIndices);
            Resize(vertData.Dimensions[1]);
            for (int r = 0, pos = 0; r < VertexCount; r++) {
                m_vertices[pos].XPosition = vertData.GetValue(0,r) + m_center.X; 
                m_vertices[pos].YPosition = vertData.GetValue(1,r) + m_center.Y; 
                m_vertices[pos].ZPosition = vertData.GetValue(2,r) + m_center.Z; 
                m_vertices[pos].Color = m_fillColor;
                m_vertices[pos++].Alpha = m_fillColor.A; 
            }
        }

        private new class Computation : ILMath {

            private static Dictionary<int, ILCell> s_vertexCache = new Dictionary<int, ILCell>(); 
            /// <summary>
            /// increase the number of triangles by doubling existing triangles
            /// </summary>
            /// <param name="vertices">vertices</param>
            /// <param name="indices">triangle index definitions</param>
            /// <returns>increased number of vertices and triangles</returns>
            /// <remarks><para>Incoming triangles are expected not to be degenerated. This means: 
            /// Every edge is used only twice at most. No triangle shares more than 2 
            /// corners with some other triangle. </para>
            /// <para>Incoming arrays will not be altered.</para></remarks>
            public static void Triangularize(ILArray<float> vertices, ILArray<int> triangles,
                                            int iterations,
                                            out ILArray<float> outVertices, 
                                            out ILArray<int> outTriangles) {
                int numVertices = vertices.Dimensions[1];
                int numTriangles = triangles.Dimensions[1];
                outVertices = vertices.C; 
                outTriangles = triangles.C;
                // beeing pessimistic: expect to create a larger number of vertices than probable
                outVertices[0, numVertices * 2] = 0;
                outTriangles[0, numTriangles * 2] = 0;

                int triIndLast = numTriangles-1; 
                int vertIndLast = numVertices-1; 
                for (int it = 0; it < iterations; it++) {
                    int triIndItEnd = triIndLast;

                    for (int triInd = 0; triInd <= triIndItEnd; triInd++) {
                        int vertInd0 = outTriangles.GetValue(0, triInd);
                        int vertInd1 = outTriangles.GetValue(1, triInd);
                        int vertInd2 = outTriangles.GetValue(2, triInd); 
                        // create new vertices
                        float v0x = (outVertices.GetValue(0, vertInd0) + outVertices.GetValue(0, vertInd1)) / 2f;
                        float v0y = (outVertices.GetValue(1, vertInd0) + outVertices.GetValue(1, vertInd1)) / 2f;
                        float v0z = (outVertices.GetValue(2, vertInd0) + outVertices.GetValue(2, vertInd1)) / 2f;
                        float v1x = (outVertices.GetValue(0, vertInd1) + outVertices.GetValue(0, vertInd2)) / 2f;
                        float v1y = (outVertices.GetValue(1, vertInd1) + outVertices.GetValue(1, vertInd2)) / 2f;
                        float v1z = (outVertices.GetValue(2, vertInd1) + outVertices.GetValue(2, vertInd2)) / 2f;
                        float v2x = (outVertices.GetValue(0, vertInd2) + outVertices.GetValue(0, vertInd0)) / 2f;
                        float v2y = (outVertices.GetValue(1, vertInd2) + outVertices.GetValue(1, vertInd0)) / 2f;
                        float v2z = (outVertices.GetValue(2, vertInd2) + outVertices.GetValue(2, vertInd0)) / 2f;
                        #region new vertex exists already? TODO: This needs to be replaced (with a b-tree implementation?)!!
                        int newVertID0 = -1; 
                        int newVertID1 = -1; 
                        int newVertID2 = -1; 
                        for (int vi = 0; vi <= vertIndLast; vi++) {
                            float tmpX = outVertices.GetValue(0, vi);
                            float tmpY = outVertices.GetValue(1, vi);
                            float tmpZ = outVertices.GetValue(2, vi);
                            if (tmpX == v0x && tmpY == v0y && tmpZ == v0z) {
                                newVertID0 = vi;
                            }
                            if (tmpX == v1x && tmpY == v1y && tmpZ == v1z) {
                                newVertID1 = vi;
                            }
                            if (tmpX == v2x && tmpY == v2y && tmpZ == v2z) {
                                newVertID2 = vi;
                            }
                            if (newVertID0 >= 0 && newVertID1 >= 0 && newVertID2 >= 0)
                                break;
                        }
                        #endregion
                        
                        if (newVertID0 < 0) {
                            newVertID0 = ++vertIndLast;
                            outVertices[0, newVertID0] = v0x;
                            outVertices[1, newVertID0] = v0y;
                            outVertices[2, newVertID0] = v0z;
                        } 
                        if (newVertID1 < 0) {
                            newVertID1 = ++vertIndLast;
                            outVertices[0, newVertID1] = v1x;
                            outVertices[1, newVertID1] = v1y;
                            outVertices[2, newVertID1] = v1z;
                        } 
                        if (newVertID2 < 0) {
                            newVertID2 = ++vertIndLast;
                            outVertices[0, newVertID2] = v2x;
                            outVertices[1, newVertID2] = v2y;
                            outVertices[2, newVertID2] = v2z;
                        } 

                        // create new triangles 
                        outTriangles.SetValue(newVertID0, 1, triInd);
                        outTriangles.SetValue(newVertID2, 2, triInd);

                        outTriangles.SetValue(newVertID2, 0, ++triIndLast);
                        outTriangles.SetValue(newVertID1, 1, triIndLast);
                        outTriangles.SetValue(vertInd2, 2, triIndLast);

                        outTriangles.SetValue(newVertID2, 0, ++triIndLast);
                        outTriangles.SetValue(newVertID0, 1, triIndLast);
                        outTriangles.SetValue(newVertID1, 2, triIndLast);

                        outTriangles.SetValue(newVertID0, 0, ++triIndLast);
                        outTriangles.SetValue(vertInd1, 1, triIndLast);
                        outTriangles.SetValue(newVertID1, 2, triIndLast);
                    }
                    
                }
                outVertices = outVertices[":;0:" + vertIndLast];
                outTriangles = outTriangles[":;0:" + triIndLast]; 
            }

            /// <summary>
            /// create vertex data [unevenly distributed, depricated]
            /// </summary>
            /// <param name="center"></param>
            /// <param name="radius"></param>
            /// <param name="horRes"></param>
            /// <param name="vertRes"></param>
            /// <param name="indices"></param>
            /// <returns></returns>
            public static ILArray<float> CreateVertices(ILPoint3Df center, float radius, int horRes, int vertRes, out ILArray<int> indices) {
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
            /// <summary>
            /// create vertices by triangularization, starting from icosahedron and subseq. creating finer grained details
            /// </summary>
            /// <param name="detail">number of iterations for triangularization</param>
            /// <param name="indices">out param: return triangles</param>
            /// <returns>vertex data</returns>
            public static ILArray<float> CreateVerticesTri(int detail, out ILArray<int> indices) {

                if (s_vertexCache.ContainsKey(detail) && s_vertexCache[detail] != null) {
                    ILCell data = s_vertexCache[detail];
                    indices = (ILArray<int>)data[1];
                    return (ILArray<float>)data[0];
                } else {


                    // regular octahedron
                    //float[,] pos = new float[,] {
                    //    {1, 0, 0}, {-1, 0, 0}, 
                    //    {0, 1, 0}, {0, -1, 0},
                    //    {0, 0, 1}, {0, 0, -1}
                    //}; 
                    //int[,] ind = new int[,] { 
                    //   {4, 0, 3}, {4, 3, 1}, {4 ,1 ,2}, {4, 2 ,0},
                    //   {0, 2, 5}, {3, 0, 5}, {1, 3, 5}, {1, 5, 2}
                    //};
                    //// regular icosahedron
                    float X = 0.525731112119133606f;
                    float Z = 0.850650808352039932f;

                    float[,] pos = new float[,] {
                   {-X, 0, Z}, {X, 0, Z}, {-X, 0, -Z}, {X, 0, -Z},
                   {0, Z, X}, {0, Z, -X}, {0, -Z, X}, {0, -Z, -X},
                   {Z, X, 0}, {-Z, X, 0}, {Z, -X, 0}, {-Z, -X, 0}
                };
                    int[,] ind = new int[,] { 
                   {0,4,1}, {0,9,4}, {9,5,4}, {4,5,8}, {4,8,1},
                   {8,10,1}, {8,3,10},{5,3,8}, {5,2,3}, {2,7,3},
                   {7,10,3}, {7,6,10}, {7,11,6}, {11,0,6}, {0,1,6},
                   {6,1,10}, {9,0,11}, {9,11,2}, {9,2,5}, {7,2,11}
                };
                    ILArray<float> vertices = pos;
                    indices = ((ILArray<int>)ind);
                    //vertices = vertices[":;0:2"];
                    //indices = new int[] { 0, 1, 2 };
                    //indices = indices.T; 
                    ILArray<float> outVertices;
                    Triangularize(vertices, indices, detail, out outVertices, out indices);
                    // normalize vertices 
                    outVertices = Normalize(outVertices);
                    // store in cache
                    s_vertexCache.Add(detail, new ILCell( new ILBaseArray[] { outVertices.C, indices.C },2,1)); 
                    return outVertices;
                }
            }

            private static ILArray<float> Normalize(ILArray<float> vertices)
            {
                return vertices / repmat(sqrt(sum(vertices * vertices, 0)), 3, 1); 
            }
        }
    }
}
