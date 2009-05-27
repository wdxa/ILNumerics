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
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Shapes {
    public abstract class ILLitCompositeShape<VertexType> : ILCompositeShape<VertexType> 
        where VertexType : struct, IILVertexDefinition {

        #region attributes
        bool m_autoNormals; 
        #endregion

        #region properties
        public bool AutoNormal {
            get { return m_autoNormals; }
            set { 
                if (VerticesPerShape < 3 && value) 
                    throw new InvalidOperationException(
                            "'auto normals' needs at least 3 vertices per primitive!"); 
                m_autoNormals = value;
                if (value) Configure(); 
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
            if (m_autoNormals)
                Computation.CalculateNormals(m_vertices,m_shapeIndices); 
        }
        #endregion

        #region private helpers
        #endregion

        private class Computation : ILNumerics.BuiltInFunctions.ILMath {
            
            public static void CalculateNormals(VertexType[] vertices, ILArray<int> shapeIndices) {
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
                // find all shapes using this vertex
                for (int i = 0; i < vertices.Length; i++) {
                    using (ILArray<double> vertexUser = find(sum(shapeIndices == (double)i,0))) {
                        ILPoint3Df normal = new ILPoint3Df(); 
                        foreach (int shapeIdx in vertexUser.Values) {
                            normal += snormals[shapeIdx];                         
                        }
                        vertices[i].Normal = normal / (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y + normal.Z * normal.Z); 
                    }
                }
            }
        }

    }
}
