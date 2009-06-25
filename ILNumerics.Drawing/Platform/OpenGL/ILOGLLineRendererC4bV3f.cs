using System;
using ILNumerics.Drawing.Shapes; 
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// An OpenGL vertex renderer, capable of rendering
    /// vertex arrays of type C4bV3f (simple /-primitive shapes).
    /// </summary>
    public unsafe class ILOGLLineRendererC4bV3f : ILVertexRenderer {

        #region attributes
        uint[] m_closeLoopIndices; 
        #endregion

        #region properties
        #endregion

        public ILOGLLineRendererC4bV3f (int numVertices) {
            CloseLines = false; 
            m_closeLoopIndices = new uint[2] {(uint)numVertices-1,0}; 
        }
        public override void Draw(ILRenderProperties props, ILShape shape) {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc (BlendingFactorSrc.SrcAlpha,
                          BlendingFactorDest.OneMinusSrcAlpha); 
            GL.Enable(EnableCap.DepthTest);
            ILLine line = (shape as ILLine);
            if (line != null && line.Border.Visible) {
                fixed (C4bV3f* pVertices = line.Vertices) {
                    ILOGLPanel.SetupLineStyle(line.Border);
                    GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                    GL.DisableClientState(EnableCap.ColorArray);
                    if (line.OldestVertexID == 0) {
                        GL.DrawArrays(BeginMode.LineStrip, 0, line.VertexCount);
                    } else {
                        GL.DrawArrays(BeginMode.LineStrip, line.OldestVertexID, line.VertexCount - line.OldestVertexID);
                        GL.DrawElements(BeginMode.Lines,2,DrawElementsType.UnsignedInt, m_closeLoopIndices);
                        GL.DrawArrays(BeginMode.LineStrip, 0, line.OldestVertexID);
                    }
                }
            }
            ILOGLPanel.SetupLineStyle(line.Properties);
            fixed (C4bV3f* pVertices = line.Vertices) {
                GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, (IntPtr)pVertices);
                if (line.Shading == ShadingStyles.Interpolate)
                    GL.ShadeModel(ShadingModel.Smooth);
                else {
                    GL.ShadeModel(ShadingModel.Flat);
                    GL.DisableClientState(EnableCap.ColorArray);
                    GL.Color4(line.FillColor);  
                }
                if (line.OldestVertexID == 0) {
                    GL.DrawArrays(BeginMode.LineStrip, 0, line.VertexCount);
                } else {
                    GL.DrawArrays(BeginMode.LineStrip, line.OldestVertexID, line.VertexCount - line.OldestVertexID);
                    GL.DrawElements(BeginMode.Lines, 2, DrawElementsType.UnsignedInt, m_closeLoopIndices);
                    GL.DrawArrays(BeginMode.LineStrip, 0, line.OldestVertexID);
                }
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
                GL.DrawElements(BeginMode.LineStrip, indices.Length,
                                DrawElementsType.UnsignedInt, (IntPtr)pIndices);
            }

        }

    }
}
