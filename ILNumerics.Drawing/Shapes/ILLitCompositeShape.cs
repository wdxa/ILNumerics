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
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Lighting; 
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Shapes {
    public abstract class ILLitCompositeShape<VertexType> 
        : ILCompositeShape<VertexType>, IILSupportsLight
        where VertexType : struct, IILVertexDefinition {

        #region attributes
        bool m_autoNormals;
        Dictionary<int, List<int>> m_shapeIndicesIndex; // used for speedy normal calculation
        ILMaterial m_material; 
        #endregion

        #region properties
        public ILMaterial Material {
            get { return m_material; }
            set { m_material = value; }
        }
        public bool AutoNormals {
            get { return m_autoNormals; }
            set { 
                if (VerticesPerShape < 3 && value) 
                    throw new InvalidOperationException(
                            "'auto normals' needs at least 3 vertices per primitive!"); 
                m_autoNormals = value;
                if (value) Invalidate(); 
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// create light composite shape
        /// </summary>
        /// <param name="panel">scene hosting the scene</param>
        /// <param name="numVertices">number of overall vertices for the shape</param>
        public ILLitCompositeShape (ILPanel panel, int numVertices, int verticesPerShape) 
            : base(panel,numVertices, verticesPerShape) { 
            create(); 
        }

        private void create() {
            if (VerticesPerShape > 2)             
                m_autoNormals = true;  
            else 
                m_autoNormals = false; 
            m_oldCameraPosition = ILPoint3Df.Empty;
            m_material = new ILMaterial(); 
        }
        public ILLitCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray mapping) 
            : base (panel, verticesPerShape, X, Y, Z, mapping) { 
            create(); 
        }
        public ILLitCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z) 
            : base (panel, verticesPerShape, X, Y, Z) {
            create(); 
        }
        public ILLitCompositeShape (ILPanel panel, int verticesPerShape, ILBaseArray X, ILBaseArray Y, ILBaseArray Z, ILBaseArray colors, ILBaseArray mapping) 
            : base (panel, verticesPerShape, X, Y, Z, colors, mapping) {
            create(); 
        }
        #endregion

        #region public interface
        public override void Configure() {
            base.Configure();
            if (m_autoNormals) {
                if (m_shapeIndicesIndex == null)
                    m_shapeIndicesIndex = Computation.CreateShapeIndicesIndex(m_shapeIndices);
                Computation.CalculateNormals(m_vertices, m_shapeIndices, m_shapeIndicesIndex);
            }
        }
        public override void Invalidate() {
            base.Invalidate();
            m_shapeIndicesIndex = null; 
        }
        #endregion

        #region private helpers
        #endregion

        protected class Computation : ILMath {

            public static Dictionary<int, List<int>> CreateShapeIndicesIndex(ILArray<int> shapeIndices) {
                Dictionary<int, List<int>> ret = new Dictionary<int, List<int>>();
                int shapeCount = shapeIndices.Dimensions[1];
                int vertPerShape = shapeIndices.Dimensions[0];
                int curShapeIdx = 0; 
                int curRowIdx = 0; 
                foreach (int i in shapeIndices.Values) {
                    if (!ret.ContainsKey(i)) 
                        ret.Add(i,new List<int>());
                    ret[i].Add(curShapeIdx); 
                    curRowIdx++; 
                    if (curRowIdx >= vertPerShape) {
                        curRowIdx = 0; 
                        curShapeIdx++; 
                    }
                }
                return ret; 
            }
            public static void CalculateNormals(
                        VertexType[] vertices
                        ,ILArray<int> shapeIndices
                        ,Dictionary<int, List<int>> shapeIndicesIndex) {
#if MEASURE_NORMAL_CALCULATION
                DateTime start = DateTime.Now; 
#endif
                System.Diagnostics.Debug.Assert(vertices != null && vertices.Length > 0 && vertices[0].StoresNormals); 
                ILPoint3Df[] snormals = new ILPoint3Df[shapeIndices.Dimensions[1]]; 
                for (int shapeCol = 0; shapeCol < snormals.Length; shapeCol++) {
                    // crossproduct of vertex: (#1 - #0) x (#2 - #0)
                    int vi0 = shapeIndices.GetValue(0,shapeCol); 
                    int vi1 = shapeIndices.GetValue(1,shapeCol); 
                    int vi2 = shapeIndices.GetValue(2,shapeCol); 
                    ILPoint3Df cross = ILPoint3Df.crossN(
                        vertices[vi1].Position-vertices[vi0].Position,
                        vertices[vi1].Position-vertices[vi2].Position);
                    snormals[shapeCol] = cross; 
                }
#if MEASURE_NORMAL_CALCULATION
                TimeSpan crossDone = DateTime.Now - start;
                DateTime startSorting = DateTime.Now; 
                System.Diagnostics.Debug.WriteLine("Normals Calculation: cross products in " + crossDone.TotalMilliseconds.ToString() + "ms"); 
#endif
                // find all facettes using this vertex
                for (int i = 0; i < vertices.Length; i++) {
                    if (!shapeIndicesIndex.ContainsKey(i)) continue;  
                    ILPoint3Df normal = new ILPoint3Df(); 
                    foreach (int shapeIdx in shapeIndicesIndex[i]) {
                        normal += snormals[shapeIdx];                         
                    }
                    // or should we let OpenGL normalize the normals...?
                    vertices[i].Normal = ILPoint3Df.normalize(normal);

                    //System.Diagnostics.Debug.Assert(
                    //    Math.Abs(Math.Sqrt(
                    //    vertices[0].Normal.X * vertices[0].Normal.X +
                    //    vertices[0].Normal.Y * vertices[0].Normal.Y +
                    //    vertices[0].Normal.Z * vertices[0].Normal.Z) - 1.0) < (double)MachineParameterFloat.eps); 
                }
#if MEASURE_NORMAL_CALCULATION
                TimeSpan sortDone = DateTime.Now - startSorting;
                System.Diagnostics.Debug.WriteLine("Normals Calculation: sorting done in " + sortDone.TotalMilliseconds.ToString() + "ms");
#endif

            }
        }

    }
}
