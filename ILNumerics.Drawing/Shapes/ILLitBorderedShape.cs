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
using ILNumerics.Drawing.Lighting;
using ILNumerics.Drawing.Controls;
using ILNumerics.Exceptions; 

namespace ILNumerics.Drawing.Shapes {
    public class ILLitBorderedShape<VertexType>
        : ILBorderedShape<VertexType>, IILSupportsLight
        where VertexType : struct, IILVertexDefinition {

        #region attributes
        ILMaterial m_material;
        bool m_autoNormals;
        bool m_mustCalcNormals; 
        #endregion

        #region properties
        public ILMaterial Material {
            get {
                return m_material; 
            }
        }
        public bool AutoNormals {
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

        public ILLitBorderedShape(ILPanel panel, int numVertices)
        : base(panel, numVertices) {
            if (!VertexDefinition.StoresNormals)
                throw new ILInvalidOperationException("The generic vertex type does not support ligthing operations. Choose a vertext type which is able to store individual normal vectors!"); 
            m_autoNormals = true;
            m_material = new ILMaterial();
            m_mustCalcNormals = true; 
        }

        #region public
        public override void Configure() {
            base.Configure();
            if (m_mustCalcNormals && m_autoNormals) {
                Computation.CalculateNormals(m_vertices);
            }
        }
        public override void Invalidate() {
            base.Invalidate();
            m_mustCalcNormals = true; 
        }
        #endregion

        private class Computation : ILNumerics.BuiltInFunctions.ILMath {
            public static void CalculateNormals (VertexType[] vertices) {
                if (vertices.Length < 3) return;
                // crossproduct of vertex: (#1 - #0) x (#2 - #0)
                ILPoint3Df cross = ILPoint3Df.crossN(
                    vertices[1].Position - vertices[0].Position,
                    vertices[1].Position - vertices[2].Position);
                for (int i = 0; i < vertices.Length; i++) {
                    vertices[i].Normal = cross;  
                }

            }
        }
    }

}
