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
using ILNumerics.Drawing.Shapes; 
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// An OpenGL vertex renderer, capable of rendering
    /// vertex arrays of type C4bV3f (simple /-primitive shapes).
    /// </summary>
    public unsafe class ILOGLPointsRendererC4bV3f : ILVertexRenderer {

        #region attributes
        #endregion

        #region properties
        #endregion

        public ILOGLPointsRendererC4bV3f () {
        }
        public override void Draw(ILRenderProperties props, ILShape shape) {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            GL.Enable(EnableCap.DepthTest);
            ILPoints points = (shape as ILPoints);
            
            fixed (C4bV3f* pVertices = points.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (points.Shading == ShadingStyles.Flat) {
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(points.FillColor);  
                }
                GL.Enable(EnableCap.PointSmooth); 
                GL.PointSize(points.Width); 
                GL.DrawArrays(BeginMode.Points, 0, points.VertexCount);
            }
        }
        public override void Draw(ILRenderProperties props, ILShape shape, ILArray<int> indices) {
            GL.Enable(EnableCap.DepthTest);
            if (indices.IsReference) indices.Detach(); 
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            ILPoints points = shape as ILPoints;
            fixed (int* pIndices = indices.InternalArray4Experts) 
            fixed (C4bV3f* pVertices = points.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (points.Shading == ShadingStyles.Flat) {
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(points.FillColor);  
                }
                GL.Enable(EnableCap.PointSmooth); 
                GL.PointSize(points.Width); 
                GL.DrawElements(BeginMode.Points, indices.Length,
                                DrawElementsType.UnsignedInt, (IntPtr)pIndices);
            }

        }

    }
}
