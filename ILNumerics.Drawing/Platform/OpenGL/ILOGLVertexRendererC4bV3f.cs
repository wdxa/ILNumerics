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
    public unsafe class ILOGLVertexRendererC4bV3f : ILVertexRenderer {

        #region attributes
        BeginMode m_primitiveType; 
        #endregion

        #region properties
        public BeginMode PrimitiveType {
            get {
                return m_primitiveType; 
            } 
            set {
                m_primitiveType = value; 
            }
        }
        #endregion

        public ILOGLVertexRendererC4bV3f (BeginMode primitiveType) {
            m_primitiveType = primitiveType; 
        }
        public override void Draw(ILRenderProperties props, ILShape shape) {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            GL.Enable(EnableCap.DepthTest);
            //GL.Disable(EnableCap.PolygonOffsetFill); 
            GL.Disable(EnableCap.LineSmooth); 
            ILShape<C4bV3f> cShape = (shape as ILShape<C4bV3f>);
            ILBorderedShape<C4bV3f> bShape = (shape as ILBorderedShape<C4bV3f>); 
            if (bShape != null && bShape.Border.Visible) {
                fixed (C4bV3f* pVertices = bShape.Vertices) {
                    ILOGLPanel.SetupLineStyle(bShape.Border);
                    GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                    GL.DisableClientState(EnableCap.ColorArray);
                    if (CloseLines)
                        GL.DrawArrays(BeginMode.LineLoop, 0, bShape.VertexCount);
                    else 
                        GL.DrawArrays(BeginMode.LineStrip, 0, bShape.VertexCount);
                }
            }
            if (cShape is ILLine) {
                ILOGLPanel.SetupLineStyle((cShape as ILLine).Properties);
                GL.Disable(EnableCap.DepthTest); 
            }
            fixed (C4bV3f* pVertices = cShape.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (cShape.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(shape.FillColor);  
                }
                GL.DrawArrays(m_primitiveType, 0, cShape.VertexCount);
            }

        }
        public override void Draw(ILRenderProperties props, ILShape shape, int[] indices) {
            System.Diagnostics.Debug.Assert(indices != null); 
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend); 
            ILBorderedShape<C4bV3f> bShape = (shape as ILBorderedShape<C4bV3f>); 
            if (bShape != null && bShape.Border.Visible) {
                fixed (int* pIndices = indices) 
                fixed (C4bV3f* pVertices = bShape.Vertices) {
                    ILOGLPanel.SetupLineStyle(bShape.Border);
                    GL.InterleavedArrays(
                                    InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                    GL.DisableClientState(EnableCap.ColorArray);
                    if (CloseLines)
                        GL.DrawElements(BeginMode.LineLoop, indices.Length, 
                                    DrawElementsType.UnsignedInt, (IntPtr)pIndices);
                    else 
                        GL.DrawElements(BeginMode.LineStrip, indices.Length, 
                                    DrawElementsType.UnsignedInt, (IntPtr)pIndices);
                }
            }
            
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            ILShape<C4bV3f> cShape = (shape as ILShape<C4bV3f>);
            if (cShape is ILLine) {
                ILOGLPanel.SetupLineStyle((cShape as ILLine).Properties);
                GL.Disable(EnableCap.DepthTest); 
            } else {
                GL.Disable(EnableCap.LineSmooth);
            }
            fixed (int* pIndices = indices) 
            fixed (C4bV3f* pVertices = cShape.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (cShape.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(shape.FillColor); 
                }
                GL.DrawElements(m_primitiveType, indices.Length,
                                DrawElementsType.UnsignedInt, (IntPtr)pIndices);
            }

        }

    }
}
