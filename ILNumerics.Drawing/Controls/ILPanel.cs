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
using System.Drawing; 
using System.Reflection; 
using System.Windows.Forms;
using System.IO; 
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Interfaces;
using ILNumerics.Drawing.TextRenderer; 
using ILNumerics.Drawing.Internal;
using ILNumerics.Drawing.Collections; 
using ILNumerics.Drawing.Graphs; 
using System.Diagnostics; 

namespace ILNumerics.Drawing.Controls {

    /// <summary>
    /// Basic abstract base class for GL dependent display.
    /// </summary>
    /// <remarks>This control is the main plot control of ILNumerics.Net.</remarks>
    public abstract class ILPanel : Control,IILCreationFactory {

        public float tempParameter; 

        #region member / properties 
        protected ILTextRendererManager m_textRendererManager; 
        protected ILClippingData m_clippingView; 
        protected ILAxisCollection m_axes;
        protected ILGraphCollection m_graphs;
        protected Point m_mouseStart; 
        protected bool m_isMoving; 
        protected bool m_active = false; 
        protected bool m_drawHidden = true; 
        protected bool m_ready = false; 
        protected ILCamera m_camera;
        protected ILCamera m_defaultView; 
        protected InteractiveModes m_selectingMode = InteractiveModes.Rotating; 
        protected ILPoint3Df m_scaling;
        protected Projection m_projection = Projection.Orthographic; 
        protected Color m_backColor = Color.FromKnownColor(KnownColor.Control);
        protected Color m_cubeBGColor = Color.Snow; 
        protected GraphicDeviceType m_graphicsDevice; 
        protected ILLineProperties m_selectionRectangle; 
        protected bool m_clipOutsideUnitCube = false; 
        protected bool m_fillBackground = true; 
        protected const float pi05 = (float) Math.PI / 2; 
        protected const float pi2 = (float) Math.PI * 2; 
        protected const float pi32 = (float) Math.PI / 2 * 3; 
        protected const float pi4 = (float) Math.PI / 4; 
        protected const float pi8 = (float) Math.PI / 8; 
        protected Internal.ILLayoutData m_layoutData = new ILLayoutData(); 
        internal float m_cubeWidth;  // used to propagate view size to matrices in derived classes
        internal float m_cubeHeight; 

        public abstract object GetDeviceContext(); 

        /// <summary>
        /// Determines if background of the rendering cube will be filled with the CubeBackgroundColor property value
        /// </summary>
        public bool BackgroundFilled {
            get {
                return m_fillBackground; 
            }
            set {
                m_fillBackground = value; 
                Invalidate(); 
            }
        }
        /// <summary>
        /// true: the control will always be drawn, even if it does not own the focus
        /// </summary>
        public bool DrawInactive {
            get {
                return m_drawHidden; 
            }
            set {
                m_drawHidden = value; 
                Invalidate(); 
            }
        }
        /// <summary>
        /// Get/set the background color for the inner cube drawing 
        /// </summary>
        public Color BackColorCube {
            get {
                return m_cubeBGColor; 
            }
            set {
                m_cubeBGColor = value; 
                Invalidate();
            }
        }
        /// <summary>
        /// View settings, get access to the clipping limits for all axises 
        /// </summary>
        public ILClippingData Limits {
            get {
                return m_clippingView; 
            } 
        }
        /// <summary>
        /// Get the type of device currently used for rendering
        /// </summary>
        public GraphicDeviceType GraphicDeviceType {
            get {
                return m_graphicsDevice; 
            }
        }
        /// <summary>
        /// Get/set properties for selection rectangle, drawn when zooming with the mouse
        /// </summary>
        public ILLineProperties SelectionRectangle {
            get {
                return m_selectionRectangle; 
            }
        }
        /// <summary>
        /// color of the figure background
        /// </summary>
        public override Color BackColor {
            get {
                return m_backColor; 
            }
            set {
                m_backColor = value; 
                Invalidate();
            }
        }
        /// <summary>
        /// type of projection: orthographic (default) or perspective
        /// </summary>
        public Projection Projection {
            get {
                return m_projection; 
            }
            set {
                m_projection = value; 
                Invalidate();
            }
        }
        /// <summary>
        /// Get or set viewport properties (distance &amp; angles)
        /// </summary>
        /// <remarks>Changing </remarks>
        public ILCamera Camera {
            get {
                return m_camera; 
            }
        }
        /// <summary>
        /// Get the current mode for mouse interaction or set's it
        /// </summary>
        public InteractiveModes InteractiveMode {
            get {
                return m_selectingMode; 
            } 
            set {
                m_selectingMode = value;
                if (value == InteractiveModes.Rotating)
                    m_axes[AxisNames.ZAxis].Visible = true;
                else if (value == InteractiveModes.ZoomRectangle) 
                    m_axes[AxisNames.ZAxis].Visible = false; 
            }
        }
        /// <summary>
        /// Gives all graphs as value collection (readonly)
        /// </summary>
        public ILGraphCollection Graphs {
            get { 
                if (m_graphs == null) 
                    CreateControl(); 
                return m_graphs;
            }
        }
        /// <summary>
        /// Get axes collection - holds all 3 axes
        /// </summary>
        public ILAxisCollection Axes {
            get {
                if (m_axes == null) 
                    CreateControl();
                return m_axes; 
            }
        }
        /// <summary>
        /// content for graphs will be clipped outside the unit cube
        /// </summary>
        /// <remarks>For 2D plots, not clipping the vertex data may lead to hiding 
        /// the labels drawn next to axes. For 3D plots Clipping may cause unexpected behavior. 
        /// <para>Therefore Clipping will be activated for 2D plots by default and 
        /// deactivated for 3D plots by default.</para></remarks>
        public bool ClipViewData {
            get {
                return m_clipOutsideUnitCube; 
            }
            set {
                m_clipOutsideUnitCube = value; 
            }
        }
        /// <summary>
        /// Manager providing collection of available IILTextRenderer types
        /// </summary>
        /// <remarks>IILTextRenderer are used to draw labels for axis of this panel (device specific).
        /// <para>Text renderer objects must be instantiated through the ILTextRendererManager instance's
        /// CreateInstance() method.</para></remarks>
        public ILTextRendererManager TextRendererManager {
            get {
                return m_textRendererManager; 
            }
        }

        /// <summary>
        /// actual width (X-direction) of the scene before (!) rotating. Including axis, ticks - without labels. 
        /// </summary>
        /// <remarks>Since the labels will not get rotated, their size must be determind on other ways</remarks>
        protected float ViewWidth {
            get {
                float ret = 1.0f; 
                if (m_axes[1].LabeledTicks.Direction == TickDirection.Outside)
                    ret += m_axes[1].LabeledTicks.TickFraction * 2.0f; 
                return ret; 
            } 
        }
        /// <summary>
        /// actual height (Y-direction) of the scene before (!) rotating. Including axis, ticks and labels. 
        /// </summary>
        protected float ViewHeight {
            get {
                float ret = 1.0f; 
                if (m_axes[0].LabeledTicks.Direction == TickDirection.Outside)
                    ret += m_axes[0].LabeledTicks.TickFraction * 2.0f; 
                return ret; 
            } 
        }
        /// <summary>
        /// actual depth (Z-direction) of the scene before (!) rotating. Including axis, ticks and labels. 
        /// </summary>
        protected float ViewDepth {
            get {
                float ret = 1.0f;   // TODO! check which outside ticks contribute to Z-direction!
                //if (m_axis[2].LabeledTicks.Direction == TickDirection.Outside)
                //    ret += m_axis[2].LabeledTicks.TickFraction * 2.0f; 
                return ret; 
            } 
        }

        /// <summary>
        /// Get or set default camera position for reset of the scene
        /// </summary>
        /// <remarks>The default position is used when the scene is reset. That
        /// reset is usually triggered by double clicking the panel with the mouse.
        /// <para>setting this value to null will make the panel ignore any double
        /// clicks, which enables the user to manually react to double click via the 
        /// common DoubleClick event of the panel and reset the camera position from
        /// outside the component.</para></remarks>
        public ILCamera DefaultView {
            get {
                return m_defaultView; 
            }
            set {
                m_defaultView = value; 
            }
        }

        #endregion

        #region constructors

        protected ILPanel(GraphicDeviceType graphicsDevice) : base () {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.ctor()",DateTime.Now, Environment.TickCount); 
#endif
            this.DoubleBuffered = false; 
            //BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_graphicsDevice = graphicsDevice; 
            m_selectionRectangle = new ILLineProperties();
            m_selectionRectangle.Antialiasing = false; 
            m_selectionRectangle.Color = Color.Blue; 
            m_selectionRectangle.Width = 1; 
            m_selectionRectangle.Style = LineStyle.Solid; 
            m_selectionRectangle.Changed += new EventHandler(m_selectionRectangle_Changed);
            m_textRendererManager = new ILTextRendererManager(this,GetDeviceContext()); 
            m_clippingView = new ILClippingData();
            m_camera = new ILCamera(0.0f,0.0f,5.0f);
            m_defaultView = new ILCamera(0.0f,0.0f,5.0f); 
            m_layoutData = new ILLayoutData(m_camera);
            m_camera.Changed += new EventHandler(m_camera_Change);
            m_clippingView.Changed += new ILClippingDataChangedEvent(m_clippingView_Changed);
            m_active = false;
            m_ready = false; 
        }

        #endregion

        #region public interface function 
        /// <summary>
        /// Dispose this panel, frees all devicec, graph- and axis collection
        /// </summary>
        public new void Dispose () {
            Dispose(false); 
        }
        /// <summary>
        /// dispose this panel
        /// </summary>
        /// <param name="disposing">manual disposing</param>
        /// <remarks>derived classed (ILDXPanel,ILOGLPanel) free their resources here</remarks>
        protected override void Dispose(bool disposing) {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.Dispose(bool) start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif
            m_ready = false; 
            if (m_graphs != null)
                m_graphs.Dispose(); 
            if (m_axes != null)
                m_axes.Dispose(); 
            base.Dispose(disposing);
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.Dispose(bool) end",DateTime.Now, Environment.TickCount); 
#endif
        }

        public override void Refresh() {
            base.Refresh();
            Invalidate();
        }

        #endregion

        #region events
        /// <summary>
        /// fired, if the data limits of any graphs changed
        /// </summary>
        public event ILClippingDataChangedEvent DataLimitsChanged; 
        /// <summary>
        /// fired, if the clipping rectangle for viewing graphs changed
        /// </summary>
        public event ILClippingDataChangedEvent ViewLimitsChanged; 

        
        /// <summary>
        /// fired, if the internal graphics device reset (Direct3D devices only)
        /// </summary>
        public event ILGraphicsDeviceResetEvent GraphicsDeviceReset;
        /// <summary>
        /// fired, if the internal graphics device has been (re)created
        /// </summary>
        public event ILGraphicsDeviceCreatedEvent GraphicsDeviceCreated;

        #endregion

        #region event handlers

        protected override void OnHandleCreated(EventArgs e) {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.OnHandleCreated() start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif
            base.OnHandleCreated(e);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            this.SetStyle(ControlStyles.UserPaint,true);
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.OnHandleCreated() end",DateTime.Now, Environment.TickCount); 
#endif
        }
        protected override void OnHandleDestroyed(EventArgs e) {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.OnHandleDestroyed() start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif
            Dispose(); 
            base.OnHandleDestroyed(e);
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.OnHandleDestroyed() end",DateTime.Now, Environment.TickCount); 
#endif

        }
        protected virtual void OnViewLimitsChanged(ClippingChangedEventArgs e) {
            if (ViewLimitsChanged != null) 
                ViewLimitsChanged(this,e);  
        }
        protected virtual void OnDataLimitsChanged(ClippingChangedEventArgs e) {
            if (DataLimitsChanged != null) 
                DataLimitsChanged(this,e);  
        }
        protected virtual void OnGraphicsDeviceReset() {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.OnGraphicsDeviceReset() start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif
            Configure(); 
            if (GraphicsDeviceReset != null) {
                GraphicsDeviceReset(this,null);
            }
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.OnGraphicsDeviceReset() end",DateTime.Now, Environment.TickCount); 
#endif
        }
        protected virtual void OnGraphicsDeviceCreated() {
#if TRACE 
            Trace.TraceInformation("{0},{1} ILPanel.OnGraphicsDeviceCreated() start",DateTime.Now, Environment.TickCount); 
            Trace.Indent(); 
#endif
            IILCreationFactory graphFact = GetCreationFactory(); 
            m_graphs = new ILGraphCollection(graphFact);
            m_graphs.CollectionChanged += new ILGraphCollectionChangedEvent(m_graphs_OnCollectionChanged);
            m_graphs.Clipping.Changed += new ILClippingDataChangedEvent(m_clippingData_Changed);
            m_axes = new ILAxisCollection(m_clippingView,graphFact); 
            if (GraphicsDeviceCreated!= null) {
                GraphicsDeviceCreated(this,null);
            }
            Invalidate(); 
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.OnGraphicsDeviceCreated() end",DateTime.Now, Environment.TickCount); 
#endif
        }

        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            m_active = false; 
        }
        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            m_active = true; 
        }
        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            if (Visible) 
                m_active = true; 
            else 
                m_active = false; 
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (m_selectingMode == InteractiveModes.Rotating) {
                #region rotation
                if (m_isMoving || (e.Button == System.Windows.Forms.MouseButtons.Left 
                    && Math.Sqrt(Math.Pow(Math.Abs(e.X - m_mouseStart.X),2) + Math.Pow(Math.Abs(e.Y - m_mouseStart.Y),2)) > 3.0)) {
                    m_isMoving = true; 
                    m_camera.EventingSuspend(); 
                    int distX = e.Location.X - m_mouseStart.X; 
                    int distY = e.Location.Y - m_mouseStart.Y;
                    float tmp = m_camera.Phi - distX / 200.0f;
                    // if alt is pressed, lock on even angles 
                    if (((Control.ModifierKeys & Keys.Alt) != 0)
                        && (Math.Abs(Math.Round(tmp/pi4) - (tmp / pi4)) < 0.05)) {
                        tmp = (float)(Math.Round(tmp / pi4) * pi4); 
                    }
                    m_camera.Phi = tmp; 
                    tmp = m_camera.Rho - distY / 200.0f;
                    // if alt is pressed, lock on even angles 
                    if (((Control.ModifierKeys & Keys.Alt) != 0)
                        && (Math.Abs(Math.Round(tmp/pi8) - (tmp / pi8)) < 0.05)) {
                        tmp = (float)(Math.Round(tmp / pi8) * pi8); 
                    }
                    m_camera.Rho = tmp; 
                    if (m_camera.Rho > Math.PI) m_camera.Rho = (float)Math.PI; 
                    if (m_camera.Rho < 0) m_camera.Rho = 0.0f; 
                    m_camera.EventingResume();
                    m_camera.OnChange(); 
                    Invalidate(); 
                    m_mouseStart = e.Location; 
                }
                #endregion
            } else if (m_selectingMode == InteractiveModes.ZoomRectangle) {
                if (m_isMoving || (e.Button == System.Windows.Forms.MouseButtons.Left 
                    && Math.Sqrt(Math.Pow(Math.Abs(e.X - m_mouseStart.X),2) + Math.Pow(Math.Abs(e.Y - m_mouseStart.Y),2)) > 3.0)) {
                    m_isMoving = true; 
                    Invalidate();
                    #region render targeting rectangle
                    //drawSelectionRect(new Point(e.X,e.Y));
                    #endregion
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            //System.Diagnostic.Debug.WriteLine("MouseUp");
            if (m_selectingMode == InteractiveModes.ZoomRectangle && m_isMoving) {
                Zoom(Screen2World2D(m_mouseStart.X,m_mouseStart.Y,0),Screen2World2D(e.X,e.Y,0));

            }
            m_isMoving = false; 
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            m_mouseStart = e.Location; 
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);
            //System.Diagnostic.Debug.WriteLine("Click");
            if (m_isMoving == false && (m_selectingMode == InteractiveModes.ZoomRectangle 
                || m_selectingMode == InteractiveModes.Rotating)) {
                // determine new center coords
                ILPoint3Df center = Screen2World2D(e.X,e.Y,0.5f);
                if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                    Zoom(center,0.8f); 
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    Zoom(center,1.2f);
            }
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e) {
            base.OnMouseDoubleClick(e);
            ResetView(true); 
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            if (e.ClipRectangle.Width == 0 || e.ClipRectangle.Height == 0) {
#if TRACE 
                Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): ClipRectangle.Size = empty -> skipping",DateTime.Now, Environment.TickCount); 
#endif
                return; 
            } 
/* THIS IS PRELIMINARY IMPLEMENTATION! REASON: While using GDI renderer, 
 * it is importatnt, to have the whole (visible) surface area invalidated
 * and available for clipping of the graphics objects in 'e'. Otherwise 
 * rendered objects will not show, after the buffers have swapped. The 
 * following code helps pick those situations, where the clipping region 
 * is only a subregion of the controls surface, but it introduces new 
 * problems, if the whole control is (partially) obscured by other controls. 
 * Since the GDI Renderer currently is not the recommended method of rendering,
 * this code is commented until a better solution was found. */
//            if (e.ClipRectangle.X > 0 || e.ClipRectangle.Y > 0) {
//#if TRACE 
//                Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): partial clipping detected -> refreshing whole controls area",DateTime.Now, Environment.TickCount); 
//#endif
//                Refresh();
//                return; 
//            }
            try {
                if (!m_ready) {
#if TRACE 
                    Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): started (re-)configure",DateTime.Now, Environment.TickCount); 
                    Trace.Indent(); 
#endif
                    Configure();
#if TRACE 
                    Trace.Unindent(); 
#endif
                }
#if TRACE 
                Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): rendering started",DateTime.Now, Environment.TickCount); 
                Trace.Indent();
                Trace.TraceInformation(String.Format("this: {1}, ClipRectangle: {0}, Graphics.ClipBounds: L:{2} T:{3} W:{4} H:{5}"
                    ,e.ClipRectangle.ToString()
                    ,this.ClientRectangle.ToString()
                    ,e.Graphics.VisibleClipBounds.Left
                    ,e.Graphics.VisibleClipBounds.Top
                    ,e.Graphics.VisibleClipBounds.Width
                    ,e.Graphics.VisibleClipBounds.Height)); 
#endif
                RenderScene(e.Graphics);
#if TRACE 
                Trace.Unindent(); 
                Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): rendering ended",DateTime.Now, Environment.TickCount); 
#endif

            } catch (Exception exc) {
#if TRACE 
                Trace.TraceWarning("{0},{1} ILPanel.OnPaint(): rendering failed. reason: {2}",DateTime.Now, Environment.TickCount,exc.ToString()); 
                Trace.Indent(); 
#endif
                System.Diagnostics.Debug.WriteLine("ILPanel.OnPaint failed: " + exc.ToString()); 
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent) {
            //base.OnPaintBackground(pevent);
        }
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_ready) {
                // Configure() will be called from device_reset event handler!
                Invalidate();
            }
        }

        protected void m_camera_Change(object sender, EventArgs e) {
            Invalidate(); 
        }
        protected void m_graphs_OnCollectionChanged(object sender, ILGraphCollectionChangedEventArgs args) {
            switch (args.Reason) {
                case GraphCollectionChangeReason.Added:
                    switch (args.Graph.Type) {
                        case GraphType.Plot2D:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            ClipViewData = true; 
                            ResetView(true); 
                            break;
                        case GraphType.Plot3D:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Surf:
                            InteractiveMode = InteractiveModes.Rotating;
                            m_camera.Phi = 5.8f;
                            m_camera.Rho = 1.17f; 
                            ResetView(false);
                            break;
                        case GraphType.Mesh:
                            InteractiveMode = InteractiveModes.Rotating; 
                            break;
                        case GraphType.Waterfall:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Ribbon:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Image:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Imagesc:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.PColor:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Contour:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.CountourFilled:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.ContourSlice:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Scatter:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Scatter3:
                            InteractiveMode = InteractiveModes.Rotating; 
                            break;
                        case GraphType.Errorbar:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Stem:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Stairs:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Stem3:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.Bar:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        case GraphType.BarHorizontal:
                            InteractiveMode = InteractiveModes.ZoomRectangle; 
                            break;
                        default:
                            InteractiveMode = InteractiveModes.Rotating; 
                            break;
                    }
                    break;
                case GraphCollectionChangeReason.Deleted:
                    break;
                default:
                    break;
            }
            // reset clipping view  (but not the rotation)
            //OnGraphicsDeviceReset(); 
        }
        protected void m_clippingView_Changed(object sender, ClippingChangedEventArgs e) {
            OnViewLimitsChanged(e); 
            Invalidate();
        }
        protected void m_clippingData_Changed(object sender, ClippingChangedEventArgs e) {
            ResetView(false);
            OnDataLimitsChanged(e);  
        }
        void m_selectionRectangle_Changed(object sender, EventArgs e) {
            // nothing to do here
        }

        #endregion event handler 

        #region virtual abstract interface

        /// <summary>
        /// Cause a reconfiguration of all axes and graphs on the next paint event
        /// </summary>
        protected new void Invalidate() {
            if (!m_ready) return; 
            m_graphs.Invalidate(); 
            m_axes.Invalidate();
            base.Invalidate(this.ClientRectangle, true);
        }
        /// <summary>
        /// Confgure all panel, to make them ready for output, set "m_ready = true" at end!
        /// </summary>
        protected abstract void Configure(); 

        /// <summary>
        /// Get size of projected view cube - after (!) rotation but before projection -> world space
        /// includes bounding box and ticks for all axis respectively
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected virtual void GetTransformedSize(out float x, out float y) {
            x = ViewWidth;   // the unrotated width - without labels size
            y = ViewHeight;  // dito for height
            if (m_camera.Rho == 0.0f && m_camera.Phi == 0.0f) {
            } else {
                float cosPhi = (float)Math.Abs(m_camera.CosPhi);// % (Math.PI / 2.0));
                float sinPhi = (float)Math.Abs(m_camera.SinPhi);// % (Math.PI / 2.0));
                float z = ViewDepth;
                z = (float)(z * Math.Sin(m_camera.Rho) + cosPhi * y + sinPhi * x);
                x = (float)(cosPhi * x + sinPhi * y);
                y = z;
            }
        }
        
        protected abstract void UpdateMatrices();

        protected virtual void RenderScene(Graphics g) {
            computeLayoutData(g);
        }

        /// <summary>
        /// initialize all device specific classes, first called after the panel has been created
        /// </summary>
        /// <remarks>derived types should init all devices here</remarks>
        protected virtual void Initialize() {}

        protected virtual void ResetView() {
            ResetView(true);
        }

        protected virtual void ResetView (bool resetRotation) {
            if (m_defaultView != null && resetRotation) {
                m_camera.Phi = m_defaultView.Phi; 
                m_camera.Rho = m_defaultView.Rho;
                m_camera.Distance = m_defaultView.Distance; 
                //UpdateMatrices(); 
            }
            m_clippingView.CopyFrom(m_graphs.Clipping);
        }

        protected virtual void Zoom(ILPoint3Df center, float offset) {
            m_clippingView.Update(center,offset); 
        }

        protected virtual void Zoom(ILPoint3Df luCorner, ILPoint3Df rbCorner) {
            m_clippingView.Set(luCorner,rbCorner); 
        }

        protected TickLabelAlign GetXTickLabelLine(
                                        out Point start2D, 
                                        out Point end2D) {
            TickLabelAlign align = TickLabelAlign.left;
            ILPoint3Df start = new ILPoint3Df(),end = new ILPoint3Df(); 
            ILTickCollection ticks = m_axes[0].LabeledTicks; 
            float tickLen = (ticks.Direction == TickDirection.Outside)? 
                             ticks.TickFraction : 0f;
            float padX = ticks.Padding, padY = padX; 
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopLeftFront:
                    start.X = -0.5f; 
                    start.Y = -0.5f - tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left | TickLabelAlign.top;
                    padX *= -m_camera.SinPhi; 
                    padY = (m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2; 
                    break;
                case CameraQuadrant.TopLeftBack:
                    start.X = -0.5f; 
                    start.Y = 0.5f + tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= m_camera.SinPhi; 
                    padY = (-m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2; 
                    break;
                case CameraQuadrant.TopRightBack:
                    start.X = -0.5f; 
                    start.Y = 0.5f + tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= m_camera.SinPhi; 
                    padY = (-m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2; 
                    break;
                case CameraQuadrant.TopRightFront:
                    start.X = -0.5f; 
                    start.Y = -0.5f - tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    if (m_camera.Is2DView) {
                        align = TickLabelAlign.center | TickLabelAlign.top; 
                    } else {
                        align = TickLabelAlign.right | TickLabelAlign.top; 
                    }
                    padX *= -m_camera.SinPhi; 
                    padY = (m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftFront:
                    start.X = -0.5f; 
                    start.Y = 0.5f + tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= m_camera.SinPhi; 
                    padY = (m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftBack:
                    start.X = -0.5f; 
                    start.Y = -0.5f - tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= -m_camera.SinPhi; 
                    padY = (-m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomRightBack:
                    start.X = -0.5f; 
                    start.Y = -0.5f - tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= -m_camera.SinPhi; 
                    padY = (-m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                default:    // BottomRightFront
                    start.X = -0.5f; 
                    start.Y = 0.5f + tickLen; 
                    start.Z = -0.5f; 
                    end.X = 0.5f; 
                    end.Y = start.Y; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= m_camera.SinPhi; 
                    padY = (m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                  break;
            }
            World2Screen(start,end,out start2D, out end2D); 
            // align in screen coords 
            int offY = (int)((m_camera.SinRho - (m_camera.SinPhi % Math.PI)) 
                        * m_axes[0].LabeledTicks.Font.Height / 2 
                        + padY);
            // add padding 
            //System.Diagnostics.Debug.WriteLine(m_camera.Phi); 
            start2D.Y += (int)padY;
            end2D.Y += (int)padY;
            start2D.X += (int)padX; 
            end2D.X += (int)padX;
            return align;
        }
        protected TickLabelAlign GetYTickLabelLine(
                                        out Point start2D, 
                                        out Point end2D) {
            TickLabelAlign align = TickLabelAlign.left;
            ILPoint3Df start = new ILPoint3Df(),end = new ILPoint3Df(); 
            ILTickCollection ticks = m_axes[1].LabeledTicks; 
            float tickLen = (ticks.Direction == TickDirection.Outside)? 
                ticks.TickFraction : 0f; 
            float padX = ticks.Padding, padY = padX; 
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopLeftFront:
                    start.X = -0.5f - tickLen; 
                    start.Y = -0.5f;  
                    start.Z = -0.5f; 
                    end.X = start.X;  
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right | TickLabelAlign.top; 
                    padX *= -m_camera.CosPhi; 
                    padY = (-m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopLeftBack:
                    start.X = -0.5f - tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= -m_camera.CosPhi; 
                    padY = (-m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopRightBack:
                    start.X = 0.5f + tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= m_camera.CosPhi; 
                    padY = (m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopRightFront:
                    start.X = 0.5f + tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left | TickLabelAlign.top; 
                    padX *= m_camera.CosPhi; 
                    padY = (m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftFront:
                    start.X = 0.5f + tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= m_camera.CosPhi; 
                    padY = (-m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftBack:
                    start.X = 0.5f + tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= m_camera.CosPhi; 
                    padY = (-m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomRightBack:
                    start.X = -0.5f - tickLen; 
                    start.Y = -0.5f; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.left 
                            | TickLabelAlign.top; 
                    padX *= -m_camera.CosPhi; 
                    padY = (m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                 break;
                default:    // BottomRightFront
                    start.X = - 0.5f - tickLen; 
                    start.Y = - 0.5f ; 
                    start.Z = -0.5f; 
                    end.X = start.X; 
                    end.Y = 0.5f; 
                    end.Z = start.Z; 
                    align = TickLabelAlign.right 
                            | TickLabelAlign.top; 
                    padX *= -m_camera.CosPhi; 
                    padY = (m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                    break;
            }
            World2Screen(start,end,out start2D, out end2D); 
            // align in screen coords 
            //int offY = (int)(Math.Abs(m_camera.CosPhi) * ticks.Font.Height / 2);
            //offY -= (int)(Math.Sin(m_camera.Rho) * ticks.Font.Height / 2); 
            start2D.Y += (int)padY;
            end2D.Y += (int)padY; 
            start2D.X += (int)padX; 
            end2D.X += (int)padX; 
            return align;
        }
        protected TickLabelAlign GetZTickLabelLine(
                                        out Point start2D, 
                                        out Point end2D) {
            TickLabelAlign align = TickLabelAlign.bottom | TickLabelAlign.right;
            ILPoint3Df start = new ILPoint3Df(),end = new ILPoint3Df(); 
            ILTickCollection ticks = m_axes[2].LabeledTicks; 
            float tickLen = 0; 
            if (ticks.Direction == TickDirection.Outside)
                 tickLen = ticks.TickFraction; 
            start.Z = -0.5f;
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopLeftFront:
                    start.X = -0.5f - tickLen;
                    start.Y = 0.5f + tickLen;
                    break;
                case CameraQuadrant.TopLeftBack:
                    start.X = 0.5f + tickLen;
                    start.Y = 0.5f + tickLen;
                    break;
                case CameraQuadrant.TopRightBack:
                    start.X = 0.5f + tickLen;
                    start.Y = -0.5f - tickLen;
                    break;
                case CameraQuadrant.TopRightFront:
                    start.X = -0.5f - tickLen;
                    start.Y = -0.5f - tickLen;
                    break;
                case CameraQuadrant.BottomLeftFront:
                    start.X = -0.5f - tickLen;
                    start.Y = 0.5f + tickLen;
                    break;
                case CameraQuadrant.BottomLeftBack:
                    start.X = 0.5f + tickLen;
                    start.Y = 0.5f + tickLen;
                    break;
                case CameraQuadrant.BottomRightBack:
                    start.X = 0.5f + tickLen;
                    start.Y = -0.5f - tickLen;
                    break;
                case CameraQuadrant.BottomRightFront:
                    start.X = -0.5f - tickLen;
                    start.Y = -0.5f - tickLen;
                    break;
                default:
                    break;
            }
            end = start;
            end.Z = 0.5f;
            World2Screen(start,end,out start2D,out end2D); 
            start2D.X -= ticks.Padding; 
            end2D.X -= ticks.Padding; 
            return align;
        }

        
        //public virtual void OptimalTickLabelLine(AxisNames axis, out Point start, out Point end, out AxisLabelAlign align) {
        //    ILPoint3Df start3F = new ILPoint3Df(); 
        //    ILPoint3Df end3F = new ILPoint3Df(); 
        //    align = GetXTickLabelLine(axis, ref start3F, ref end3F);
        //    world2Screen(start3F, end3F, out start, out end);
        //    //// include tick label padding 
        //    //if ((align & AxisLabelAlign.bottom) != 0) {
        //    //    start.Y -= m_axis[axis].LabeledTicks.Padding;   
        //    //    end.Y -= m_axis[axis].LabeledTicks.Padding;  
        //    //} else if ((align & AxisLabelAlign.vertCenter) != 0) {
        //    //    start.Y += m_axis[axis].LabeledTicks.Padding; 
        //    //    end.Y += m_axis[axis].LabeledTicks.Padding;  
        //    //} else { // top
        //    //    start.Y += m_axis[axis].LabeledTicks.Padding; 
        //    //    end.Y += m_axis[axis].LabeledTicks.Padding;  
        //    //}
        //    //if ((align & AxisLabelAlign.right) != 0) {
        //    //    start.X -= m_axis[axis].LabeledTicks.Padding;   
        //    //    end.X -= m_axis[axis].LabeledTicks.Padding;  
        //    //} else if ((align & AxisLabelAlign.center) != 0) {
        //    //} else {
        //    //    start.X += m_axis[axis].LabeledTicks.Padding;   
        //    //    end.X += m_axis[axis].LabeledTicks.Padding;  
        //    //}
        //}

        public abstract void World2Screen(ILPoint3Df start, ILPoint3Df end, out Point start2D, out Point end2D);

        /// <summary>
        /// Transform from a point on screen into world coordinates
        /// </summary>
        /// <param name="x">screen x</param>
        /// <param name="y">screen y</param>
        /// <param name="z">z directly transferred to output</param>
        /// <returns>world coordinate point</returns>
        protected virtual ILPoint3Df Screen2World2D(int x, int y, float z) {
            ILPoint3Df center = new ILPoint3Df();
            Size labelsSize = m_axes.MaxTicLabelSize;
            // map to world coords
            x -= labelsSize.Width; 
            y = ClientSize.Height - y - labelsSize.Height; 
            center.X = ((float)x) / (ClientRectangle.Width - 2 * labelsSize.Width) * (1.0f + 2 * m_axes[0].LabeledTicks.TickFraction) - m_axes[0].LabeledTicks.TickFraction;
            center.Y = ((float)y) / (ClientRectangle.Height - 2 * labelsSize.Height) * (1.0f + 2 * m_axes[1].LabeledTicks.TickFraction) - m_axes[1].LabeledTicks.TickFraction;
            center.Z = z;
            // map to view coords
            center.X = center.X * m_clippingView.WidthF + m_clippingView.XMin; 
            center.Y = center.Y * m_clippingView.HeightF + m_clippingView.YMin; 
            return center; 
        }
        
        /// <summary>
        /// Transform world coordinates to screen coordinates under current transformation
        /// </summary>
        /// <param name="worldPoint">input: world coordinates</param>
        /// <returns>screen location</returns>
        /// <remarks>the actual transform is carried out in the derived specialized class,
        /// where the current transformation matrices are known</remarks>
        public abstract Point Transform(ILPoint3Df worldPoint); 
        #endregion

        #region helper functions 
        /// <summary>
        /// draws the selection rectangle with GDI functions
        /// </summary>
        /// <param name="endPoint">end point</param>
        /// <remarks>The start point is stored in the member m_mouseStart.</remarks>
        protected virtual void drawSelectionRect(Point endPoint) {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Pen pen = new Pen(m_selectionRectangle.Color, 1.0f);
            Point[] points = new Point[3];
            // upper left corner
            points[0] = new Point(m_mouseStart.X, m_mouseStart.Y + (endPoint.Y - m_mouseStart.Y) / 4);
            points[1] = new Point(m_mouseStart.X, m_mouseStart.Y);
            points[2] = new Point(m_mouseStart.X + (endPoint.X - m_mouseStart.X) / 4, m_mouseStart.Y);
            g.DrawLines(pen, points);
            // lower left corner 
            points[0] = new Point(m_mouseStart.X, endPoint.Y - (endPoint.Y - m_mouseStart.Y) / 4);
            points[1] = new Point(m_mouseStart.X, endPoint.Y);
            points[2] = new Point(m_mouseStart.X + (endPoint.X - m_mouseStart.X) / 4, endPoint.Y);
            g.DrawLines(pen, points);
            // lower right corner 
            points[0] = new Point(endPoint.X, endPoint.Y - (endPoint.Y - m_mouseStart.Y) / 4);
            points[1] = new Point(endPoint.X, endPoint.Y);
            points[2] = new Point(endPoint.X - (endPoint.X - m_mouseStart.X) / 4, endPoint.Y);
            g.DrawLines(pen, points);
            // upper right corner 
            points[0] = new Point(endPoint.X, m_mouseStart.Y + (endPoint.Y - m_mouseStart.Y) / 4);
            points[1] = new Point(endPoint.X, m_mouseStart.Y);
            points[2] = new Point(endPoint.X - (endPoint.X - m_mouseStart.X) / 4, m_mouseStart.Y);
            g.DrawLines(pen, points);
        }

        public static short StippleFromLineStyle(LineStyle style, ref int stipFactr) {
            short ret = 1; 
            switch (style) {
                case LineStyle.Dashed:
                    ret = (short)255;
                    stipFactr = 2;
                    break;
                case LineStyle.PointDash:
                    ret = (short)255 + 4096;
                    stipFactr = 1;
                    break;
                case LineStyle.Dotted:
                    ret = (short)13107; // 3 + 48 + 768 + 8192 + 4096;
                    stipFactr = 2;
                    break;
                case LineStyle.UserPattern:
                    break;
                    ret = 0; 
                case LineStyle.None:
                    break;
                default:      // solid
                    ret = (short)-1;
                    break;
            }
            return ret; 
        }

        internal void computeLayoutData (Graphics gr) {
            // compute size of viewport/ projection 
            float xSize, ySize;
            GetTransformedSize(out xSize, out ySize);   // returns world coords: cube + ticks

            // add label's size to increase margin
            Size ticksSize = m_axes.MeasureMaxTickLabelSize(gr); 
            Size xLabelSize = m_axes.XAxis.Label.GetSize(gr); 
            Size yLabelSize = m_axes.YAxis.Label.GetSize(gr);
            int padX = m_axes[0].LabeledTicks.Padding + m_axes[0].Label.Padding * 2; 
            int padY = m_axes[1].LabeledTicks.Padding + m_axes[1].Label.Padding * 2; 
            int padZ = m_axes[2].LabeledTicks.Padding + m_axes[2].Label.Padding * 2; 
            int xHeight = xLabelSize.Height + padX; 
            int yHeight = yLabelSize.Height + padY; 
            int zHeight =  m_axes.ZAxis.Label.GetSize(gr).Height + padZ; 
            if (xHeight < yHeight) 
                xHeight = yHeight; 
            ticksSize.Width += xHeight; 
            ticksSize.Height += xHeight; 
            // include Z-Axis, if showing
            if (m_axes[2].Visible && m_camera.SinRho > 1e-5) {
                if (xHeight < zHeight) {
                    ticksSize.Width += (zHeight - xHeight);
                    ticksSize.Height += (zHeight - xHeight);
                }
            }
            //m_cubeWidth = 1.0f / (xSize * ((ClientSize.Width-2) - 2 * ticksSize.Width) / (ClientSize.Width-2));
            //m_cubeHeight = 1.0f / (ySize * ((ClientSize.Height-2) - 2 * ticksSize.Height) / (ClientSize.Height-2));
            m_cubeWidth = ((xSize * (ClientSize.Width-2)) / ((ClientSize.Width-2) - 2 * ticksSize.Width));
            m_cubeHeight = ((ySize * (ClientSize.Height-2)) / ((ClientSize.Height-2) - 2 * ticksSize.Height));
            //m_cubeHeight = ySize; m_cubeWidth = xSize; 
            // setup matrices (must do before world2screen is called in OptimalTickLabelLine()!) 
            UpdateMatrices(); 
            // determine tick label lines
            ILTickCollection ticks = m_axes[2].LabeledTicks; 
            ticks.m_align = GetZTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd); 
            ticks = m_axes[1].LabeledTicks; 
            ticks.m_align = GetYTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd); 
            ticks = m_axes[0].LabeledTicks; 
            ticks.m_align = GetXTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd);

            #region determine axis label position & limits 
            positionZAxisLabel(m_axes[2]); 
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopRightFront:
                    axisLabel_TopLeftBottomRight(m_axes[0]);
                    // special case: 2D view? 
                    if (m_camera.SinPhi < 1e-5 && m_camera.SinRho < 1e-5) {
                        axisLabelVertical2D(m_axes[1]); 
                    } else {
                        axisLabel_BottomLeftTopRight(m_axes[1]);
                    }
                    break;
                case CameraQuadrant.TopRightBack:
                    axisLabel_TopRightBottomLeft(m_axes[0]);
                    axisLabel_TopLeftBottomRight(m_axes[1]);
                    break; 
                case CameraQuadrant.TopLeftFront:
                    axisLabel_BottomLeftTopRight(m_axes[0]);
                    axisLabel_BottomRightTopLeft(m_axes[1]);
                    break;
                case CameraQuadrant.TopLeftBack:
                    axisLabel_BottomRightTopLeft(m_axes[0]);
                    axisLabel_TopRightBottomLeft(m_axes[1]);
                    break;
                case CameraQuadrant.BottomLeftFront:
                    axisLabel_TopLeftBottomRight(m_axes[0]);
                    axisLabel_TopRightBottomLeft(m_axes[1]); 
                    break;
                case CameraQuadrant.BottomLeftBack:
                    axisLabel_TopRightBottomLeft(m_axes[0]);
                    axisLabel_BottomRightTopLeft(m_axes[1]);
                    break;
                case CameraQuadrant.BottomRightBack:
                    axisLabel_BottomRightTopLeft(m_axes[0]);
                    axisLabel_BottomLeftTopRight(m_axes[1]);
                    break; 
                case CameraQuadrant.BottomRightFront:
                    axisLabel_BottomLeftTopRight(m_axes[0]);
                    axisLabel_TopLeftBottomRight(m_axes[1]);
                    break;
                default:
                    break;
            }
            #endregion
            System.Diagnostics.Debug.WriteLine(m_camera.Quadrant); 
        }

        private void axisLabelVertical2D(ILAxis axis) {
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size;
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.Orientation = TextOrientation.Vertical;
                    label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                    label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                    label.m_position.Y -= (int)(0.5 * labelSize.Width);
                    if (label.m_position.Y < ticks.m_lineEnd.Y) {
                        label.m_position.Y = ticks.m_lineEnd.Y;
                    }
                    if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                        label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                    }
                    break;
                case AxisLabelAlign.Upper:
                    label.Orientation = TextOrientation.Vertical;
                    label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                    label.m_position.Y = ticks.m_lineEnd.Y;
                    if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                        label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                    }
                    break;
                default:        // lower 
                    label.Orientation = TextOrientation.Vertical;
                    label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                    label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width;
                    if (label.m_position.Y < ticks.m_lineEnd.Y) {
                        label.m_position.Y = ticks.m_lineEnd.Y;
                    }
                    if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                        label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                    }
                    break;
            }
        }
        private void positionZAxisLabel(ILAxis axis) {
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size; 
            label.Orientation = TextOrientation.Vertical;
            label.m_position.X = ticks.m_lineStart.X - tickSize.Width - labelSize.Height; 
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.m_position.Y = (ticks.m_lineStart.Y + ticks.m_lineEnd.X ) / 2;
                    break; 
                case AxisLabelAlign.Upper:
                    label.m_position.Y = ticks.m_lineEnd.Y - tickSize.Width;
                    break;
                default:        // lower 
                    label.m_position.Y = ticks.m_lineStart.Y;
                    break;
            }
            if (label.m_position.Y + labelSize.Width >  ticks.m_lineStart.Y ) {
                label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width;
            }
            if (label.m_position.Y < label.Padding) {
                label.Orientation = TextOrientation.Horizontal; 
                label.m_position.X = label.Padding; 
                label.m_position.Y = label.Padding; 
            }
        }
        private void axisLabel_BottomRightTopLeft(ILAxis axis) {
            #region Bottom Right -> Top Left
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size; 
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.m_position.X = (ticks.m_lineStart.X + ticks.m_lineEnd.X) / 2;
                    label.m_position.Y = ticks.m_lineStart.Y + tickSize.Height;
                    if (axis.Index == 0) { // X Axis
                        label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Sin(m_camera.Phi % Math.PI)) * labelSize.Width);
                    } else if (axis.Index == 1) {
                        if (m_camera.Rho <= pi05) 
                            label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                        else 
                            label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                    } 
                    if (label.m_position.X < label.Padding) {
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X - tickSize.Width - labelSize.Height;
                        label.m_position.Y = (ticks.m_lineStart.Y + ticks.m_lineEnd.Y) / 2;
                        label.m_position.Y -= (int)(0.5 * labelSize.Width);
                        if (label.m_position.Y < ticks.m_lineEnd.Y) {
                            label.m_position.Y = ticks.m_lineEnd.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                case AxisLabelAlign.Upper:
                    label.m_position.X = ticks.m_lineEnd.X;
                    label.m_position.Y = ticks.m_lineStart.Y
                                            + tickSize.Height + label.Padding;
                    if (label.m_position.X + labelSize.Width > ticks.m_lineStart.X) {
                        label.m_position.X = ticks.m_lineStart.X - labelSize.Width;
                    }
                    if (label.m_position.X < label.Padding) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X - tickSize.Width - labelSize.Height;
                        label.m_position.Y = ticks.m_lineEnd.Y;
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                default:        // lower 
                    label.m_position.X = ticks.m_lineStart.X - labelSize.Width;
                    label.m_position.Y = ticks.m_lineStart.Y
                                            + tickSize.Height + label.Padding;
                    label.Orientation = TextOrientation.Horizontal;
                    if (label.m_position.X < label.Padding) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X - tickSize.Width - labelSize.Height;
                        label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width;
                        if (label.m_position.Y < ticks.m_lineEnd.Y) {
                            label.m_position.Y = ticks.m_lineEnd.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    }
                    break;
            }
            #endregion
        }
        private void axisLabel_BottomLeftTopRight(ILAxis axis) {
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size;
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                    label.m_position.Y = ticks.m_lineStart.Y + tickSize.Height;
                    if (axis.Index == 0) { // X Axis
                        label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Sin(m_camera.Phi % Math.PI)) * labelSize.Width);
                    } else if (axis.Index == 1) {
                        if (m_camera.Rho <= pi05) 
                            label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                        else 
                            label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                    } 
                    if (label.m_position.X > ClientSize.Width - label.Padding - labelSize.Width) {
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                        label.m_position.Y -= (int)(0.5 * labelSize.Width);
                        if (label.m_position.Y < ticks.m_lineEnd.Y) {
                            label.m_position.Y = ticks.m_lineEnd.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                case AxisLabelAlign.Upper:
                    label.m_position.X = ticks.m_lineEnd.X - labelSize.Width;
                    label.m_position.Y = ticks.m_lineStart.Y
                                            + tickSize.Height + label.Padding;
                    if (label.m_position.X < ticks.m_lineStart.X) {
                        label.m_position.X = ticks.m_lineStart.X;
                    }
                    label.Orientation = TextOrientation.Horizontal;
                    if (label.m_position.X > ClientSize.Width - 1 - label.Padding - labelSize.Width) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                        label.m_position.Y = ticks.m_lineEnd.Y;
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    }
                    break;
                default:        // lower 
                    label.m_position.X = ticks.m_lineStart.X;
                    label.m_position.Y = ticks.m_lineStart.Y
                                            + tickSize.Height + label.Padding;
                    if (label.m_position.X > ClientSize.Width - label.Padding - labelSize.Width) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineEnd.X + tickSize.Width;
                        label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width;
                        if (label.m_position.Y < ticks.m_lineEnd.Y) {
                            label.m_position.Y = ticks.m_lineEnd.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
            }
        }
        private void axisLabel_TopRightBottomLeft(ILAxis axis) {
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size;
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                    label.m_position.Y = ticks.m_lineEnd.Y + tickSize.Height;
                    //System.Diagnostics.Debug.WriteLine(m_camera.Quadrant + " - " + m_camera.SinPhi); 
                    if (axis.Index == 0)
                        label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Sin(m_camera.Phi % Math.PI)) * labelSize.Width);
                    else {    
                        if (m_camera.Rho <= pi05) 
                            label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                        else 
                            label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                        //System.Diagnostics.Debug.WriteLine( Math.Cos(m_camera.Phi % Math.PI)); 
                    }
                    if (label.m_position.X > ClientSize.Width - label.Padding - labelSize.Width) {
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineStart.X + tickSize.Width;
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y - labelSize.Width) / 2;
                        if (label.m_position.Y < ticks.m_lineStart.Y) {
                            label.m_position.Y = ticks.m_lineStart.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        axis.Label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                case AxisLabelAlign.Upper:
                    label.m_position.X = ticks.m_lineEnd.X;
                    label.m_position.Y = ticks.m_lineEnd.Y
                                            + tickSize.Height + label.Padding;
                    if (label.m_position.X > ClientSize.Width - label.Padding - labelSize.Width) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineStart.X + tickSize.Width;
                        label.m_position.Y = ticks.m_lineEnd.Y - labelSize.Width;
                        if (label.m_position.Y < ticks.m_lineStart.Y) {
                            label.m_position.Y = ticks.m_lineStart.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                default:        // lower 
                    label.m_position.X = ticks.m_lineStart.X - labelSize.Width;
                    label.m_position.Y = ticks.m_lineEnd.Y
                                            + tickSize.Height + label.Padding;
                    label.Orientation = TextOrientation.Horizontal;
                    if (label.m_position.X < ticks.m_lineEnd.X) {
                        // move left until bound is reached
                        label.m_position.X = ticks.m_lineEnd.X;
                        if (label.m_position.X > ClientSize.Width - label.Padding - labelSize.Width) {
                            // vertical 
                            label.Orientation = TextOrientation.Vertical;
                            label.m_position.X = ticks.m_lineStart.X + tickSize.Width;
                            label.m_position.Y = ticks.m_lineStart.Y;
                            if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                                label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                            }
                        }
                    }
                    break;
            }
        }
        private void axisLabel_TopLeftBottomRight(ILAxis axis) {
            ILAxisLabel label = axis.Label; 
            ILTickCollection ticks = axis.LabeledTicks; 
            Size tickSize = ticks.ScreenSize, labelSize = label.Size;
            switch (label.Alignment) {
                case AxisLabelAlign.Center:
                    label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                    label.m_position.Y = ticks.m_lineEnd.Y + tickSize.Height;
                    //System.Diagnostics.Debug.WriteLine(Math.Sin(m_camera.Phi %Math.PI));
                    if (axis.Index == 0)
                        label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Sin(m_camera.Phi % Math.PI)) * labelSize.Width);
                    else if (axis.Index == 1) {
                        if (m_camera.Rho <= pi05) 
                            label.m_position.X -= (int)Math.Round((0.5 - 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                        else 
                            label.m_position.X -= (int)Math.Round((0.5 + 0.5 * Math.Cos(m_camera.Phi % Math.PI)) * labelSize.Width);
                    }
                    if (label.m_position.X < label.Padding) {
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineStart.X - tickSize.Width - labelSize.Height;
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                        label.m_position.Y -= (int)(0.5 * labelSize.Width);
                        if (label.m_position.Y < ticks.m_lineStart.Y) {
                            label.m_position.Y = ticks.m_lineStart.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) { 
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        axis.Label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                case AxisLabelAlign.Upper:
                    label.m_position.X = ticks.m_lineEnd.X - labelSize.Width;
                    label.m_position.Y = ticks.m_lineEnd.Y
                                            + tickSize.Height + label.Padding;
                    if (label.m_position.X < label.Padding) {
                        // vertical 
                        label.Orientation = TextOrientation.Vertical;
                        label.m_position.X = ticks.m_lineStart.X - tickSize.Width - labelSize.Height;
                        label.m_position.Y = ticks.m_lineEnd.Y - labelSize.Width + tickSize.Height;
                        if (label.m_position.Y < ticks.m_lineStart.Y) {
                            label.m_position.Y = ticks.m_lineStart.Y;
                        }
                        if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                            label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                        }
                    } else {
                        label.Orientation = TextOrientation.Horizontal;
                    }
                    break;
                default:        // lower 
                    label.m_position.X = ticks.m_lineStart.X;
                    label.m_position.Y = ticks.m_lineEnd.Y
                                            + tickSize.Height + label.Padding;
                    label.Orientation = TextOrientation.Horizontal;
                    if (label.m_position.X + labelSize.Width > ticks.m_lineEnd.X) {
                        // move left until bound is reached
                        label.m_position.X = ticks.m_lineEnd.X - labelSize.Width;
                        if (label.m_position.X < label.Padding) {
                            // vertical 
                            label.Orientation = TextOrientation.Vertical;
                            label.m_position.X = ticks.m_lineStart.X - tickSize.Width - labelSize.Height;
                            label.m_position.Y = ticks.m_lineStart.Y;
                            if (label.m_position.Y < ticks.m_lineStart.Y) {
                                label.m_position.Y = ticks.m_lineStart.Y;
                            }
                            if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width - label.Padding) {
                                label.m_position.Y = ClientSize.Height - 1 - labelSize.Width - label.Padding;
                            }
                        }
                    }
                    break;
            }
        }
        ///// <summary>
        ///// write part of current call stack info to current trace listener
        ///// </summary>
        ///// <param name="frameCount">number of frames to print (without the frame for the method)</param>
        //private void traceOutFrames(int frameCount) {
        //    StringBuilder sb = new StringBuilder(); 
        //    StackFrame[] frames = new StackTrace().GetFrames(); 
        //    for (int i = 1; i < frameCount + 1 && i < frames.Length; i++) {
        //        sb.Append("called from: "); 
        //        sb.Append(frames[1].GetMethod().ReflectedType.Name); 
        //        sb.Append("." + frames[i].GetMethod().Name); 
        //        sb.Append(" -- ");
        //    } 
        //    Trace.TraceInformation(sb.ToString()); 
        //}

        #endregion

        #region factory member

        /// <summary>
        /// create OpenGL panel 
        /// </summary>
        /// <returns>OpenGL panel</returns>
        public static ILPanel Create () {
            return Create(GraphicDeviceType.OpenGL); 
        }
        /// <summary>
        /// create graphic device specific panel 
        /// </summary>
        /// <param name="type">specify GL type. Supported are: OpenGL (recommended) or Direct3D (alpha state)</param>
        /// <returns>GL specific panel</returns>
        public static ILPanel Create (GraphicDeviceType type) {
            ILPanel ret; Type panelType; Assembly assembly; 
            string myPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
            switch (type) {
                case GraphicDeviceType.Direct3D:
                    //must create DXPanel dynamically ? 
                    // actually not, because DX is split into individual assembly
                    // but under mono it seems the runtime tries to load the d3d part 
                    // anyway, so we do without a compile time reference.
                    assembly = Assembly.LoadFile(Path.Combine(myPath,"ILNumerics.DrawingD3D.dll")); 
                    panelType = assembly.GetType("ILNumerics.Drawing.Internal.ILDXPanel"); 
                    ret = (ILPanel)panelType.InvokeMember("ILDXPanel", 
                            BindingFlags.DeclaredOnly | BindingFlags.Public 
                            | BindingFlags.NonPublic | BindingFlags.Instance 
                            | BindingFlags.CreateInstance, 
                            null, null, null);
                    return ret; 
                default:
                    // the default is to use OpenGL, which is included into the main assembly (this one)
                    assembly = Assembly.LoadFile(Path.Combine(myPath,"ILNumerics.Drawing.dll")); 
                    panelType = assembly.GetType("ILNumerics.Drawing.Internal.ILOGLPanel"); 
                    ret = (ILPanel)panelType.InvokeMember("ILOGLPanel", 
                            BindingFlags.DeclaredOnly | BindingFlags.Public 
                            | BindingFlags.NonPublic | BindingFlags.Instance 
                            | BindingFlags.CreateInstance, 
                            null, null, null);
                    return ret; 
            }
        }
        /// <summary>
        /// Create Axis (device dependent)
        /// </summary>
        /// <param name="name">specfies axis name (X,Y,ZAxis)</param>
        /// <param name="clippingView">the global clipping view object for the axis</param>
        /// <param name="parameters">user defined parameters (implementation dependent)</param>
        /// <returns>ILAXis object</returns>
        /// <remarks>Since this is an abstract method, it is not called directly but by only from derived classes.</remarks>
        public abstract ILAxis CreateAxis(AxisNames name, ILClippingData clippingView, params object[] parameters); 

        /// <summary>
        /// Create specific graph (device dependent)
        /// </summary>
        /// <param name="data">numeric data to be visualized, any numeric type is accepted</param>
        /// <param name="type">type of graph to be created</param>
        /// <param name="additionalParams">user defined parameter, depend on concrete device type</param>
        /// <returns>Concrete ILGraph object</returns>
        /// <remarks>Since this is an abstract method, it is not called directly but by only from derived classes.</remarks>
        public abstract ILGraph CreateGraph(ILBaseArray data, GraphType type, params object[] additionalParams); 

        /// <summary>
        /// Create GL dependend graph factory 
        /// </summary>
        /// <returns>ILGraphFactory,will be used for creating all graphs</returns>
        /// <remarks>derived types may return GL dependend factory</remarks>
        public virtual IILCreationFactory GetCreationFactory() {
            return this;
        }

        #endregion
    }
}
