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
    public unsafe class ILOGLLinesRendererC4bV3f : ILVertexRenderer {

        #region attributes
        #endregion

        #region properties
        #endregion

        public ILOGLLinesRendererC4bV3f () {
            CloseLines = false; 
        }
        public override void Draw(ILRenderProperties props, ILShape shape) {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            GL.Enable(EnableCap.DepthTest);
            ILLines lines = (shape as ILLines);
            ILOGLPanel.SetupLineStyle(lines.Properties);
            fixed (C4bV3f* pVertices = lines.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (lines.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(lines.FillColor);  
                }
                GL.DrawArrays(BeginMode.LineStrip, 0, lines.VertexCount);
            }

        }
        public override void Draw(ILRenderProperties props, ILShape shape, ILArray<int> indices) {
            System.Diagnostics.Debug.Assert(indices != null && indices.IsVector); 
            GL.Enable(EnableCap.DepthTest);
            if (indices.IsReference) indices.Detach(); 
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            ILShape<C4bV3f> cShape = (shape as ILShape<C4bV3f>);
            if (cShape is ILLines) {
                ILOGLPanel.SetupLineStyle((cShape as ILLines).Properties);
                GL.Disable(EnableCap.DepthTest); 
            } 
            fixed (int* pIndices = indices.InternalArray4Experts) 
            fixed (C4bV3f* pVertices = cShape.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (cShape.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                }
                GL.DrawElements(BeginMode.Lines, indices.Length,
                                DrawElementsType.UnsignedInt, (IntPtr)pIndices);
            }

        }

    }
}
