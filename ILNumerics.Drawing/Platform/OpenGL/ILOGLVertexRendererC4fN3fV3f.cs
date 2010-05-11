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
using ILNumerics.Drawing.Interfaces; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// An OpenGL vertex renderer, capable of rendering
    /// vertex arrays of type C4fN3fV3f (for lit shapes).
    /// </summary>
    public unsafe class ILOGLVertexRendererC4fN3fV3f : ILVertexRenderer {

        #region attributes
        BeginMode m_primitiveType; 
        InterleavedArrayFormat m_vertexFormat; 
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

        public ILOGLVertexRendererC4fN3fV3f (BeginMode primitiveType) {
            m_primitiveType = primitiveType; 
        }

        public override void Draw(ILRenderProperties props, ILShape shape) {
            if (shape.VertexCount == 0) return; 
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            GL.Enable(EnableCap.DepthTest);
            //GL.Disable(EnableCap.PolygonOffsetFill); 
            ILShape<C4fN3fV3f> cShape = (shape as ILShape<C4fN3fV3f>);
            fixed (C4fN3fV3f* pVertices = cShape.Vertices) {
                if (UseLight && (cShape is IILSupportsLight)) {
                    setupLight(cShape as IILSupportsLight);  
                } else {
                    GL.Disable(EnableCap.Lighting); 
                }
                GL.InterleavedArrays(InterleavedArrayFormat.C4fN3fV3f, 0, (IntPtr)pVertices);
                if (cShape.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(shape.FillColor);  
                }
                GL.DrawArrays(m_primitiveType, 0, cShape.VertexCount);
            }
            GL.Disable(EnableCap.Lighting); 
            ILBorderedShape<C4fN3fV3f> bShape = (shape as ILBorderedShape<C4fN3fV3f>); 
            if (bShape != null && bShape.Border.Visible) {
                fixed (C4fN3fV3f* pVertices = bShape.Vertices) {
                    ILOGLPanel.SetupLineStyle(bShape.Border);
                    GL.InterleavedArrays(InterleavedArrayFormat.C4fN3fV3f, 0, (IntPtr)pVertices);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.DrawArrays(BeginMode.LineLoop, 0, bShape.VertexCount);
                }
            }
        }
        public override void Draw(ILRenderProperties props, ILShape shape, ILArray<int> indices) {
            System.Diagnostics.Debug.Assert(indices != null && indices.IsVector); 
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend); 
            if (indices.IsReference) indices.Detach(); 
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            // draw shape
            ILShape<C4fN3fV3f> cShape = (shape as ILShape<C4fN3fV3f>);
            fixed (int* pIndices = indices.InternalArray4Experts) 
            fixed (C4fN3fV3f* pVertices = cShape.Vertices) {
                if (UseLight && (cShape is ILLitCompositeShape<C4fN3fV3f>)) {
                    setupLight(cShape as ILLitCompositeShape<C4fN3fV3f>);
                } else {
                    GL.Disable(EnableCap.Lighting);
                }
                GL.InterleavedArrays(InterleavedArrayFormat.C4fN3fV3f, 0, (IntPtr)pVertices);
                if (cShape.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(shape.FillColor); 
                }
                GL.DrawElements(m_primitiveType, indices.Length,DrawElementsType.UnsignedInt, (IntPtr)pIndices);
                //IntPtr pObj = Glu.NewQuadric();
                //GL.MatrixMode(MatrixMode.Modelview);
                //GL.PushMatrix();
                //GL.Translate(cShape.Vertices[0].Position.X, cShape.Vertices[0].Position.Y, cShape.Vertices[0].Position.Z);
                //Glu.QuadricDrawStyle(pObj, QuadricDrawStyle.Fill);
                //Glu.Sphere(pObj, 2, 20, 10);
                //GL.PopMatrix(); 
            }
            // draw border 
            ILBorderedShape<C4fN3fV3f> bShape = (shape as ILBorderedShape<C4fN3fV3f>); 
            if (bShape != null && bShape.Border.Visible) {
                fixed (int* pIndices = indices.InternalArray4Experts) 
                fixed (C4fN3fV3f* pVertices = bShape.Vertices) {
                    ILOGLPanel.SetupLineStyle(bShape.Border);
                    GL.InterleavedArrays(
                                    InterleavedArrayFormat.C4fN3fV3f, 0, (IntPtr)pVertices);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.DrawElements(BeginMode.LineLoop, indices.Length, 
                                    DrawElementsType.UnsignedInt, (IntPtr)pIndices);
                }
            }

#if RENDERER_DRAW_NORMALS
            #region DEBUG_DRAW_NORMALS 
            GL.Color3(0,0,0); 
            GL.Begin(BeginMode.Lines);
            for (int i = 0; i < shape.VertexCount; i++) {
                GL.Vertex3(cShape.Vertices[i].XPosition,cShape.Vertices[i].YPosition,cShape.Vertices[i].ZPosition); 
                GL.Vertex3( cShape.Vertices[i].XPosition+cShape.Vertices[i].Normal.X,
                            cShape.Vertices[i].YPosition+cShape.Vertices[i].Normal.Y,
                            cShape.Vertices[i].ZPosition+cShape.Vertices[i].Normal.Z); 
            }
            GL.End(); 
            #endregion
#endif
            GL.Disable(EnableCap.Lighting); 

        }
        private void setupLight(IILSupportsLight shape) {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Normalize); 
            GL.ColorMaterial(MaterialFace.FrontAndBack,ColorMaterialParameter.AmbientAndDiffuse);
            
            //GL.LightModel(LightModelParameter.LightModelAmbient, 0.2f);
            float[] tmp = new float[4] { 
                  shape.Material.Specular.R / 255f
                , shape.Material.Specular.G / 255f
                , shape.Material.Specular.B / 255f
                , shape.Material.Specular.A / 255f};
            GL.Materialv(MaterialFace.FrontAndBack, MaterialParameter.Specular, tmp);

            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, shape.Material.Shininess );

            tmp = new float[4] { 
                  shape.Material.Emission.R / 255f
                , shape.Material.Emission.G / 255f
                , shape.Material.Emission.B / 255f
                , shape.Material.Emission.A / 255f};
            GL.Materialv(MaterialFace.FrontAndBack, MaterialParameter.Emission, tmp); 
            
        }

    }
}
