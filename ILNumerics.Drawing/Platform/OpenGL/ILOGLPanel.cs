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
using System.ComponentModel;
using System.Diagnostics; 
using System.Drawing;
using System.Drawing.Imaging; 
using System.Data;
using System.Text;
using System.Windows.Forms;
using ILNumerics.Exceptions;
using ILNumerics.Drawing.Controls;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Platform.OpenGL; 
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL.Enums;
using OpenTK.Graphics;
using OpenTK.Platform; 
using OpenTK; 
using OpenTK.Math; 
 
namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// OpenGL implementation for ILPanel
    /// </summary>
    public partial class ILOGLPanel : ILPanel {

        #region members / properties 
        GraphicsMode m_format;
        IWindowInfo m_window_info;
        IGraphicsContext m_context;
        IGLControl m_implementation; 
        private const float Sqrt2 = 1.4142135623730950488016887242097f;
        double[] m_projMatrix = new double[16]; 
        double[] m_modelViewMatrix = new double[16];
        double[] m_tmpresult = new double[24]; 
        int[] m_viewMatrix = new int[16]; 
        float[] m_selectionVertices = new float[32];  // V2F format, interleaved
        int m_errorCount = 0; 
        private readonly int MAXERRORLOGCOUNT = 100; 
        /// <summary>
        /// Gets an interface to the underlying GraphicsContext used by this GLControl.
        /// </summary>
        public override object GetDeviceContext() {
            return m_context; 
        }

        internal double[] ProjectionMatrix {
            get {
                return m_projMatrix; 
            }
        }
        internal double[] ModelviewMatrix {
            get {
                return m_modelViewMatrix; 
            }
        }
        internal int[] ViewMatrix {
            get {
                return m_viewMatrix; 
            }
        }

        #endregion private members

        #region constructors 
 
        internal ILOGLPanel() : base( GraphicDeviceType.OpenGL ) {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILOGLPanel.ctor(mode) start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif

            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            m_format = GraphicsMode.Default;

            if (Configuration.RunningOnWindows)
                m_implementation = new OpenTK.Platform.Windows.WinGLControl(m_format, this);
            else if (Configuration.RunningOnX11)
                m_implementation = new OpenTK.Platform.X11.X11GLControl(m_format, this);
            else if (Configuration.RunningOnOSX)
                throw new PlatformNotSupportedException("Refer to http://www.opentk.com for more information.");

            this.CreateControl();

#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.ctor(mode) end",DateTime.Now, Environment.TickCount); 
#endif
        }

        #endregion

        #region panel setup / destroy 

        /// <summary>
        /// will get called after the handle has been created
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (DesignMode)
                m_context = new DummyGLContext(null);
            else
                m_context = m_implementation.CreateContext();

            m_window_info = m_implementation.WindowInfo;
            this.MakeCurrent();
            ((IGraphicsContextInternal)m_context).LoadAll();
            OnGraphicsDeviceCreated(); 
        }
        /// <summary>
        /// gets called, after the handle has been destroyed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (m_context != null)
            {
                m_context.Dispose();
                m_context = null;
            }
            m_window_info = null;
        }
        /// <summary>
        /// Dispose off the panels resources
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            m_active = false;
            base.Dispose(disposing);
            if (disposing) {
                // he ? 
            }
            if (m_context != null && disposing) {
                m_context.Dispose();
                m_context = null;
            }
        }

        #endregion

        #region rendering related

        /// <summary>
        /// set up viewport, projection and modelview matrices
        /// </summary>
        protected override void UpdateMatrices() {
            MakeCurrent();
            #region projection 
            GL.MatrixMode(MatrixMode.Projection); 
            GL.LoadIdentity(); 
            // at this point, the semi-global layout data's object cubeWorld parameter must have been updated already!!
            if (m_projection == Projection.Perspective) {
                float angle = (float)Math.Atan2(m_cubeHeight / 2.0f, (m_camera.Distance - 0.5)) * 2.0f;
                Glu.Perspective( angle / Math.PI * 180, (double) m_cubeWidth / m_cubeHeight,
                                 0.01,m_camera.Distance+2.0f); 
                //GL.Frustum(-xSize/2.0,xSize/2.0,-ySize/2.0,ySize/2.0,0.0,2.0);
                //Glu.LookAt(new Vector3(0f,0f,2f),new Vector3(0f,0f,0f),new Vector3(0f,1f,0f));
            } else {
                GL.Ortho(-m_cubeWidth/2.0 ,m_cubeWidth/2.0
                    ,-m_cubeHeight/2.0 ,m_cubeHeight/2.0
                    ,-10.0,12.0);
            }
            GL.GetDouble(GetPName.ProjectionMatrix,m_projMatrix);
            // set viewport 
            GL.Viewport(0,0,ClientSize.Width,ClientSize.Height);
            GL.GetInteger(GetPName.Viewport,m_viewMatrix);
            #endregion
            #region modelview
            GL.MatrixMode(MatrixMode.Modelview); 
            GL.LoadIdentity();
            GL.Translate(0.0f,0.0f,-m_camera.Distance); 
            GL.Rotate(-m_camera.Rho/Math.PI * 180,1.0,0.0,0.0); 
            GL.Rotate(-m_camera.Phi/Math.PI * 180,0.0,0.0,1.0); 
            GL.Scale(1.0f,1.0f,1.0f); 
            GL.GetDouble(GetPName.ModelviewMatrix,m_modelViewMatrix); 
            #endregion
        }
        
        /// <summary>
        /// Render the OpenGL scene
        /// </summary>
        /// <param name="g"></param>
        protected override void RenderScene(Graphics g) {
            MakeCurrent(); 
            // update layoutData object, call UpdateMatrices() 
            base.RenderScene(g); 
            if (m_context == null || (!m_active && !m_drawHidden))
                return;
            try {
                System.Diagnostics.Debug.WriteLine(String.Format("ILOGLPanel{0}: RenderScene, Thread={1}"
                        ,this.GetHashCode(), System.Threading.Thread.CurrentThread.GetHashCode())); 
                // draw background
                GL.ClearColor(m_backColor);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                // draw back axis
                GL.Enable(EnableCap.DepthTest); 
                if (m_fillBackground)
                    renderBackground(); 
                GL.Enable(EnableCap.LineSmooth);
                GL.Enable(EnableCap.Blend);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.PolygonOffset(1.0f,10.0f);
                //GL.Enable(EnableCap.PolygonOffsetFill); 

                m_axes.XAxis.RenderState1(g);
                m_axes.YAxis.RenderState1(g);
                if (m_camera.SinRho > 1e-5)
                    m_axes.ZAxis.RenderState1(g);
                // draw all graphs
                GL.MatrixMode(MatrixMode.Modelview);
                ILPoint3Df ab = m_clippingView.CenterToUnitCube();
                GL.Translate(ab.X, ab.Y, ab.Z);
                ab = m_clippingView.ScaleToUnitCube();
                GL.Scale(ab.X, ab.Y, ab.Z); //Identity; //RotationZ(m_cameraPhi); 
                // update model matrix (to be avilable for zooming etc.)
                //GL.GetDouble(GetPName.ModelviewMatrix,m_modelViewMatrix);
                #region lighting  - not implemented yet
                //GL.Enable(EnableCap.Lighting);
                //GL.Enable(EnableCap.Light0);
                ////GL.Enable(EnableCap.DepthTest); 
                //GL.Enable(EnableCap.ColorMaterial);
                ////GL.LightModelv(LightModelParameter.LightModelAmbient,new float [4]{0.2f, 0.2f, 0.2f, 1.0f});
                ////GL.Materialv(MaterialFace.FrontAndBack, MaterialParameter.Specular,new float[]{0.3f, 0.3f, 1.0f, 0.2f});
                ////GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess,25f);
                //GL.ColorMaterial(MaterialFace.FrontAndBack,ColorMaterialParameter.Diffuse); 
                //GL.Materialv(MaterialFace.FrontAndBack,MaterialParameter.Diffuse,
                //             new float[]{0.1f, 0.1f, 0.1f, 0.0f});

                //float[] lpos = new float[]{1f,1f, 0.2f,0};
                //GL.Lightv(LightName.Light0,LightParameter.Position,lpos);
                //lpos[0] = tempParameter; lpos[1] = tempParameter; lpos[2] = tempParameter; lpos[3] = 1.0f;
                //GL.Lightv(LightName.Light0,LightParameter.Specular,lpos);
                //lpos = new float[]{-10.0f,1.0f,1.0f,0.0f};
                //GL.Lightv(LightName.Light0,LightParameter.LinearAttenuation,lpos);
                #endregion
                #region enable clipping planes
                if (m_clipOutsideUnitCube) {
                    m_tmpresult[0] = -1.0; m_tmpresult[3] = 0.5; 
                    m_tmpresult[4] = 1.0; m_tmpresult[7] = 0.5;
                    m_tmpresult[9] = 1.0; m_tmpresult[11] = 0.5;
                    m_tmpresult[13] = -1.0; m_tmpresult[15] = 0.5;
                    //m_tmpresult[18] = ab.Z * 2; m_tmpresult[19] = ab.Z;
                    //m_tmpresult[22] = ab.Z * 2; m_tmpresult[23] = ab.Z;
                    unsafe { fixed (double* p = m_tmpresult) {
                        GL.ClipPlane(ClipPlaneName.ClipPlane0,p);
                        GL.ClipPlane(ClipPlaneName.ClipPlane1,p+4);
                        GL.ClipPlane(ClipPlaneName.ClipPlane2,p+8);
                        GL.ClipPlane(ClipPlaneName.ClipPlane3,p+12);
                        //GL.ClipPlane(ClipPlaneName.ClipPlane4,p+16);
                        //GL.ClipPlane(ClipPlaneName.ClipPlane5,p+20);
                        GL.Enable(EnableCap.ClipPlane0); 
                        GL.Enable(EnableCap.ClipPlane1); 
                        GL.Enable(EnableCap.ClipPlane2); 
                        GL.Enable(EnableCap.ClipPlane3);
                    }} 
                    //GL.Enable(EnableCap.ClipPlane4); 
                    //GL.Enable(EnableCap.ClipPlane5);
                }
                #endregion
                foreach (ILGraph graph in m_graphs) {
                    try {
                        graph.Draw();
                    } catch (Exception e) {
#if TRACE
                        m_errorCount++; 
                        if (m_errorCount < MAXERRORLOGCOUNT) {
                            System.Diagnostics.Trace.TraceError(String.Format("[{0}].Draw() failed: {1}",graph.GetType().Name,e.ToString()));       
                        } else if (m_errorCount == MAXERRORLOGCOUNT) {
                            System.Diagnostics.Trace.TraceError(String.Format("(more than {0} errors. Further reporting disabled.)",m_errorCount)); 
                        }
#endif
                    }
                }
                #region disable clipping planes 
                GL.Disable(EnableCap.ClipPlane0); 
                GL.Disable(EnableCap.ClipPlane1); 
                GL.Disable(EnableCap.ClipPlane2); 
                GL.Disable(EnableCap.ClipPlane3); 
                //GL.Disable(EnableCap.ClipPlane4); 
                //GL.Disable(EnableCap.ClipPlane5); 
                #endregion disable clipping planes
                // render front axis 
                GL.MatrixMode(MatrixMode.Modelview); 
                GL.PopMatrix(); 
                GL.Enable(EnableCap.Blend);
                GL.Enable(EnableCap.LineSmooth);
                m_axes.XAxis.RenderState2(g);
                m_axes.YAxis.RenderState2(g);
                if (m_camera.SinRho > 1e-5)
                    m_axes.ZAxis.RenderState2(g);
                GL.MatrixMode(MatrixMode.Modelview);
                if (m_selectingMode == InteractiveModes.ZoomRectangle && m_isMoving) 
                    drawSelectionRect(PointToClient(MousePosition));
                //GL.Finish();
                // update model matrix (to be avilable for zooming etc.)
                GL.GetDouble(GetPName.ModelviewMatrix,m_modelViewMatrix);

                #region DEBUG texture drawing
#if DRAWTEXTURESHEET
                // prepare GL
                float[] viewport = new float[4]; 
                GL.GetFloat(GetPName.Viewport, viewport);
                GL.MatrixMode(MatrixMode.Projection);
                GL.PushMatrix();     
                GL.LoadIdentity();
                GL.Ortho(viewport[0], viewport[2], viewport[3], viewport[1], -1.0, 1.0);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.LoadIdentity();
                GL.PushAttrib(AttribMask.TextureBit | AttribMask.EnableBit | AttribMask.ColorBufferBit);
                GL.Enable(EnableCap.Texture2D);
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.Disable(EnableCap.DepthTest);
                // draw one large quad with whole texture sheet
                GL.Begin(BeginMode.Quads); 
                GL.TexCoord2(0,1);   
                GL.Vertex2(0,ClientSize.Height/2);      // ul
                GL.TexCoord2(0,0); 
                GL.Vertex2(0,0);                    // bl
                GL.TexCoord2(1,0); 
                GL.Vertex2(ClientSize.Width,0);                    // br
                GL.TexCoord2(1,1); 
                GL.Vertex2(ClientSize.Width,ClientSize.Height/2);      // tr
                GL.End();
#endif
                #endregion

                SwapBuffers();
                m_axes.XAxis.RenderState3(g);
                m_axes.YAxis.RenderState3(g);
                if (m_camera.SinRho > 1e-5)
                    m_axes.ZAxis.RenderState3(g);

                if (false) {
                    g.DrawLine(new Pen(new SolidBrush(Color.Red)),m_axes[0].Label.m_position,m_axes[0].Label.m_position);  
                    g.DrawLine(new Pen(new SolidBrush(Color.Green)),m_axes[1].Label.m_position,m_axes[0].Label.m_position);  
                    g.DrawLine(new Pen(new SolidBrush(Color.Blue)),m_axes[2].Label.m_position,m_axes[0].Label.m_position);  
                }
            } catch (Exception e) { 
                // TODO: implement exception handling 
            } 
        }
        /// <summary>
        /// draws the selection rectangle va OpenGL (rather than GDI in base class)
        /// </summary>
        /// <param name="endPoint"></param>
        protected override void drawSelectionRect(Point endPoint) {
            float [] viewport = new float[4]; 
            GL.GetFloat(GetPName.Viewport, viewport);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();     
            GL.LoadIdentity();
            GL.Ortho(viewport[0], viewport[2], viewport[3], viewport[1], -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            //GL.Enable(EnableCap.Texture2D);
            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Disable(EnableCap.DepthTest);
            SetupLineStyle(m_selectionRectangle); 
            //// upper left corner
            m_selectionVertices[0] = m_mouseStart.X;
            m_selectionVertices[1] = m_mouseStart.Y + (endPoint.Y - m_mouseStart.Y) / 4;
            m_selectionVertices[2] = m_mouseStart.X;
            m_selectionVertices[3] = m_mouseStart.Y;
            m_selectionVertices[4] = m_mouseStart.X;
            m_selectionVertices[5] = m_mouseStart.Y;
            m_selectionVertices[6] = m_mouseStart.X + (endPoint.X - m_mouseStart.X) / 4;
            m_selectionVertices[7] = m_mouseStart.Y;
            // lower left corner 
            m_selectionVertices[8] = m_mouseStart.X;
            m_selectionVertices[9] = endPoint.Y - (endPoint.Y - m_mouseStart.Y) / 4;
            m_selectionVertices[10] = m_mouseStart.X;
            m_selectionVertices[11] = endPoint.Y;
            m_selectionVertices[12] = m_mouseStart.X;
            m_selectionVertices[13] = endPoint.Y;
            m_selectionVertices[14] = m_mouseStart.X + (endPoint.X - m_mouseStart.X) / 4;
            m_selectionVertices[15] = endPoint.Y;
            // lower right corner 
            m_selectionVertices[16] = endPoint.X;
            m_selectionVertices[17] = endPoint.Y - (endPoint.Y - m_mouseStart.Y) / 4;
            m_selectionVertices[18] = endPoint.X;
            m_selectionVertices[19] = endPoint.Y;
            m_selectionVertices[20] = endPoint.X;
            m_selectionVertices[21] = endPoint.Y;
            m_selectionVertices[22] = endPoint.X - (endPoint.X - m_mouseStart.X) / 4;
            m_selectionVertices[23] = endPoint.Y;
            // upper right corner 
            m_selectionVertices[24] = endPoint.X;
            m_selectionVertices[25] = m_mouseStart.Y + (endPoint.Y - m_mouseStart.Y) / 4;
            m_selectionVertices[26] = endPoint.X;
            m_selectionVertices[27] = m_mouseStart.Y;
            m_selectionVertices[28] = endPoint.X;
            m_selectionVertices[29] = m_mouseStart.Y;
            m_selectionVertices[30] = endPoint.X - (endPoint.X - m_mouseStart.X) / 4;
            m_selectionVertices[31] = m_mouseStart.Y;
            // draw them
            unsafe {
                fixed (float* verticesP = m_selectionVertices) {
                    GL.InterleavedArrays(InterleavedArrayFormat.V2f,8,(IntPtr)verticesP);
                    GL.DrawArrays(BeginMode.Lines,0,16);
                }
            }
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
        }
        /// <summary>
        /// Swaps the front and back buffers, presenting the rendered scene to the screen.
        /// </summary>
        protected void SwapBuffers() {
            if (m_context != null)
                m_context.SwapBuffers();
        }
        /// <summary>
        /// Makes the underlying this GLControl current in the calling thread.
        /// All OpenGL commands issued are hereafter interpreted by this GLControl.
        /// </summary>
        protected void MakeCurrent() {
            if (m_context != null)
                m_context.MakeCurrent(m_implementation.WindowInfo);
        }

        public override void DrawToBitmap(Bitmap bitmap, Rectangle bounds) {
            RenderScene(null);
            BitmapData bmpData = bitmap.LockBits(bounds,ImageLockMode.ReadWrite,
                                 System.Drawing.Imaging.PixelFormat.Format24bppRgb); 
            // reset any changes to pixel store
            GL.PixelStore(PixelStoreParameter.UnpackAlignment,4.0f); 
            GL.PixelStore(PixelStoreParameter.UnpackRowLength,bmpData.Width); 
            GL.PixelStore(PixelStoreParameter.UnpackSkipRows,bounds.Y); 
            GL.PixelStore(PixelStoreParameter.UnpackSkipPixels,bounds.X); 
            GL.ReadPixels(0,0,bounds.Width,bounds.Height,OpenTK.Graphics.PixelFormat.Bgr,
                          PixelType.UnsignedByte,(IntPtr)bmpData.Scan0); 
            bitmap.UnlockBits(bmpData); 
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY); 
        }
        #endregion

        #region IILGraphFactory member

        public override ILGraph CreateGraph(ILBaseArray data, GraphType graphType, params object[] parameter) {
            switch (graphType) {
                case GraphType.Plot2D:
                    if (parameter != null && parameter.Length == 1 
                        && parameter[0] != null && parameter[0] is ILBaseArray) {
                        return new ILOGLPlot2DGraph(this,parameter[0] as ILBaseArray,
                                                    data,m_graphs.Clipping); 
                    } else {
                        return new ILOGLPlot2DGraph(this, data,m_graphs.Clipping);
                    }
                case GraphType.Surf:
                    if (parameter == null || parameter.Length == 0) 
                        return new ILOGLSurfaceGraph(this,null,null,data,null,m_graphs.Clipping); 
                    if (parameter.Length == 2) {
                        return new ILOGLSurfaceGraph(this,data,parameter[0] as ILBaseArray,
                                                     parameter[1] as ILBaseArray ,null,m_graphs.Clipping); 
                    } else if (parameter.Length == 1) {
                        return new ILOGLSurfaceGraph(this,null,null,data, 
                                                     parameter[0] as ILBaseArray,m_graphs.Clipping);
                    } else if (parameter.Length == 3) {
                        return new ILOGLSurfaceGraph(this,parameter[0] as ILBaseArray, parameter[1] as ILBaseArray, 
                                                     data,parameter[2] as ILBaseArray, m_graphs.Clipping); 
                    } else 
                        throw new ILArgumentException ("graph creation: invalid number of arguments! (surface)"); 
                case GraphType.Imagesc:
                    return new ILOGLImageSCGraph(this,null,null,data,null,m_graphs.Clipping);
                default:
                    throw new ILInvalidOperationException("Graph type not supported: " + graphType.ToString());
            }
        }

        public override ILAxis CreateAxis(AxisNames name, ILClippingData clippingView, params object[] parameters) {
            switch (name) {
                case AxisNames.XAxis:
                    return new ILOGLXAxis(clippingView, m_layoutData, this);
                    break;
                case AxisNames.YAxis:
                    return new ILOGLYAxis(clippingView, m_layoutData, this);
                    break;
                default:
                    return new ILOGLZAxis(clippingView, m_layoutData, this);
                    break;
            } 
        }
        #endregion

        #region public methods

        public override Point Transform(ILPoint3Df worldPoint) {
            Vector3 e = new Vector3();
            Glu.Project(new Vector3(worldPoint.X, worldPoint.Y, worldPoint.Z),
                        m_modelViewMatrix, m_projMatrix, m_viewMatrix, out e);
            return new Point((int)e.X,(int)(ClientSize.Height - e.Y));
        }

        protected override void Configure() {
            // todo: implement me, pleaze!
            m_ready = true; 
        }

        public static void SetupLineStyle(ILLineProperties wireprops) {
            if (wireprops.Style == LineStyle.Solid) {
                GL.Disable(EnableCap.LineStipple);
            } else {
                int stipFactr = 1;
                short stipple;
                if (wireprops.Style != LineStyle.UserPattern)
                    stipple = ILPanel.StippleFromLineStyle(
                                    wireprops.Style, ref stipFactr);
                else {
                    stipple = wireprops.Pattern;
                    stipFactr = (int)wireprops.PatternScale; 
                }
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(stipFactr, stipple);
            }
            if (wireprops.Antialiasing)
                GL.Enable(EnableCap.LineSmooth);
            else
                GL.Disable(EnableCap.LineSmooth);
            GL.LineWidth(wireprops.Width);
            GL.Color3(wireprops.Color);
        }

        /// <summary>
        /// Transform 2 world coordinates into screen coords under current matrices
        /// </summary>
        /// <param name="p1_3D">world coord point 1</param>
        /// <param name="p2_3D">world coord point 2</param>
        /// <param name="p1_2D">(output) screen coord point 1</param>
        /// <param name="p2_2D">(output) screen coord point 2</param>
        public override void World2Screen(ILPoint3Df p1_3D, ILPoint3Df p2_3D, out Point p1_2D, out Point p2_2D) {
            Vector3 s = new Vector3();
            Vector3 e = new Vector3();
            Glu.Project(new Vector3(p1_3D.X, p1_3D.Y, p1_3D.Z),
                        m_modelViewMatrix, m_projMatrix, m_viewMatrix, out s);
            Glu.Project(new Vector3(p2_3D.X, p2_3D.Y, p2_3D.Z),
                        m_modelViewMatrix, m_projMatrix, m_viewMatrix, out e);
            p1_2D = new Point((int)s.X,(int)(ClientSize.Height - s.Y));
            p2_2D = new Point((int)e.X,(int)(ClientSize.Height - e.Y));
        }
        /// <summary>
        /// transform from screen space into world space using OpenGL
        /// </summary>
        /// <param name="x">screen X</param>
        /// <param name="y">screen Y</param>
        /// <returns>world coord</returns>
        public override ILPoint3Df Screen2World2D(int x, int y, float z) {
            Vector3 ret; 
            // TODO: check the Z coord values. 0.68 here was result of trial only! 
            Glu.UnProject(new Vector3(x,y,z),m_modelViewMatrix,m_projMatrix,m_viewMatrix, out ret); 
            // transform back from unit cube
            ILPoint3Df retF = m_clippingView.Map(ret.X,-ret.Y,ret.Z); 
            //retF.Z = 0.0f; 
            return retF; 
        }
        
        #endregion

        #region private helper 
        private void renderBackground () {
            //determine, which edges are in the back, fill with cube background color
            GL.Begin(BeginMode.TriangleStrip);
            GL.Color3(m_cubeBGColor);
            if (!m_camera.LooksFromLeft) {
                if (m_camera.LooksFromFront) {
                    // left & back border
                    GL.Vertex3(-0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(-0.5f,-0.5f,0.5f);       
                    GL.Vertex3(-0.5f,0.5f,-0.5f);       
                    GL.Vertex3(-0.5f,0.5f,0.5f);       
                    GL.Vertex3(0.5f,0.5f,-0.5f);       
                    GL.Vertex3(0.5f,0.5f,0.5f);       
                } else {
                    GL.Vertex3(-0.5f,0.5f,-0.5f);    //   
                    GL.Vertex3(-0.5f,0.5f,0.5f);       
                    GL.Vertex3(-0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(-0.5f,-0.5f,0.5f);       
                    GL.Vertex3(0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(0.5f,-0.5f,0.5f);       
                }
            } else {
                if (!m_camera.LooksFromFront) {
                    GL.Vertex3(-0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(-0.5f,-0.5f,0.5f);       
                    GL.Vertex3(0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(0.5f,-0.5f,0.5f);       
                    GL.Vertex3(0.5f,0.5f,-0.5f);       
                    GL.Vertex3(0.5f,0.5f,0.5f);       
                } else {
                    GL.Vertex3(-0.5f,0.5f,-0.5f);       
                    GL.Vertex3(-0.5f,0.5f,0.5f);       
                    GL.Vertex3(0.5f,0.5f,-0.5f);       
                    GL.Vertex3(0.5f,0.5f,0.5f);       
                    GL.Vertex3(0.5f,-0.5f,-0.5f);       
                    GL.Vertex3(0.5f,-0.5f,0.5f);       
                }
            }
            GL.End();
            // draw bottom 
            if (m_camera.LooksFromTop) {
                GL.Begin(BeginMode.TriangleStrip); 
                GL.Vertex3(-0.5f,-0.5f,-0.5f); 
                GL.Vertex3(0.5f,-0.5f,-0.5f); 
                GL.Vertex3(-0.5f,0.5f,-0.5f); 
                GL.Vertex3(0.5f,0.5f,-0.5f); 
                GL.End(); 
            }
        }
        #endregion 
    
    }
}