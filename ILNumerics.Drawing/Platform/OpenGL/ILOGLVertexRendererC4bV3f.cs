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
        public override void Draw(ILRenderProperties props, ILShape shape, ILArray<int> indices) {
            System.Diagnostics.Debug.Assert(indices != null && indices.IsVector); 
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend); 
            if (indices.IsReference) indices.Detach(); 
            ILBorderedShape<C4bV3f> bShape = (shape as ILBorderedShape<C4bV3f>); 
            if (bShape != null && bShape.Border.Visible) {
                fixed (int* pIndices = indices.InternalArray4Experts) 
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
            fixed (int* pIndices = indices.InternalArray4Experts) 
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
