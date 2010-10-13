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
using ILNumerics.Drawing.Collections; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Misc; 
using System.Diagnostics; 

namespace ILNumerics.Drawing.Controls {

    /// <summary>
    /// Basic abstract base class for GL dependent display.
    /// </summary>
    /// <remarks>This control is the main plot control of ILNumerics.Net.</remarks>
    public abstract class ILPanel : Control {

        #region attributes 
        protected ILRendererManager m_textRendererManager; 
        protected ILClippingData m_clippingView; 
        protected ILAxisCollection m_axes;
        protected ILGraphCollection m_graphs;
        protected ILTextureManager m_textureManager; 
        protected Point m_mouseStart; 
        protected bool m_isDragging; 
        protected bool m_active = false; 
        protected bool m_drawHidden = true; 
        protected bool m_ready = false; 
        private bool m_isStartingUp = true; 
        protected ILCamera m_camera;
        protected ILCamera m_defaultView;
        protected bool m_autoDefaultView = true; 
        protected InteractiveModes m_selectingMode = InteractiveModes.Rotating; 
        protected InteractiveModes m_oldSelectingMode; 
        protected bool m_isCtrlKeyDown; 
        protected ILPoint3Df m_scaling;
        protected Projection m_projection = Projection.Orthographic; 
        protected Color m_backColor = Color.FromKnownColor(KnownColor.Control);
        protected Color m_cubeBGColor = Color.Snow; 
        protected ILColormap m_colormap; 
        protected ILLegend m_legend; 
        protected ZoomModes m_zoomMode = ZoomModes.RollHard; 
        protected ILZoomAction m_zoomAction; 
        protected float m_zoomOffset = 50f;
        protected GraphicDeviceType m_graphicsDevice; 
        protected ILLineProperties m_selectionRectangle; 
        protected bool m_fillBackground = true; 
        private AutoZoomOptions m_autoZoomOptions = AutoZoomOptions.OnDataChanges; 
        protected ILLayoutData m_layoutData = new ILLayoutData(); 
        protected ILLightCollection m_lights = new ILLightCollection(); 
        protected ILRenderProperties m_renderProperties; 
        protected ILAction m_action;
        protected List<ILGraph> m_sortingCacheList = new List<ILGraph>(); 
        /// <summary>
        /// pixel size of the current PlotCubeScreenRectangle
        /// </summary>
        protected RectangleF m_plotBoxScreenRectF;
        protected PlotBoxScreenSizeMode m_plotBoxScreenSizeMode;
        protected AspectRatioMode m_aspectRatio; 
        protected double[] m_clipplanes = new double[24]; 
        
        private const int MAXRENDERPASSES = 2; 
        private const float LABELS_VERTICAL_MIN_RHO = 0.8f; 
        protected const float pi05 = (float) Math.PI / 2; 
        protected const float pi2 = (float) Math.PI * 2; 
        protected const float pi32 = (float) Math.PI / 2 * 3; 
        protected const float pi4 = (float) Math.PI / 4; 
        protected const float pi8 = (float) Math.PI / 8; 
        #endregion

        #region properties
        public bool AutoDefaultView { 
            get { return m_autoDefaultView; }
            set { m_autoDefaultView = value; }
        }
        /// <summary>
        /// Determines how the projected data plots are mapped to PlotCubeScreenRectF
        /// </summary>
        public AspectRatioMode AspectRatio {
            get { return m_aspectRatio; }
            set { m_aspectRatio = value; }
        }
        /// <summary>
        /// the normalizes projected size (range 0..1) of plot cube on 2D client area, set: sets PlotCubeScreenMode -> Manual
        /// </summary>
        public RectangleF PlotBoxScreenRect {
            get { return m_plotBoxScreenRectF; }
            set { 
                m_plotBoxScreenRectF = value;
                m_plotBoxScreenSizeMode = PlotBoxScreenSizeMode.Manual; 
                //Invalidate(); 
            }
        }
        /// <summary>
        /// options for determining the size of the plot cube on the 2D screen client area, default: optimal
        /// </summary>
        public PlotBoxScreenSizeMode PlotBoxScreenSizeMode {
            get { return m_plotBoxScreenSizeMode; }
            set {
                m_plotBoxScreenSizeMode = value;
                if (value == PlotBoxScreenSizeMode.Maximum) {
                    m_plotBoxScreenRectF = new RectangleF(0, 0, 1f, 1f);
                }
            }
        }
        /// <summary>
        /// Access collection of lights for configuration
        /// </summary>
        public ILLightCollection Lights {
            get { return m_lights; }
        }
        /// <summary>
        /// Legend for panel's graphs
        /// </summary>
        public ILLegend Legend {
            get {
                return m_legend; 
            }
        }
        /// <summary>
        /// Get texture manager instance, storing all textures used in the scene
        /// </summary>
        internal ILTextureManager TextureManager {
            get {
                return m_textureManager; 
            }
        }
        /// <summary>
        /// Colormap used to translate color indices into true colors
        /// </summary>
        public ILColormap Colormap {
            get {
                return m_colormap; 
            }
            set {
                m_colormap = value;
                OnColormapChanged(); 
            }
        }
        /// <summary>
        /// Determines if background of the rendering cube will be filled with the CubeBackgroundColor property value
        /// </summary>
        public bool BackgroundFilled {
            get {
                return m_fillBackground; 
            }
            set {
                m_fillBackground = value; 
                //Invalidate(); 
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
                //Invalidate(); 
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
                //Invalidate();
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
                //Invalidate();
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
                //Invalidate();
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
                m_oldSelectingMode = value;
                //if (value == InteractiveModes.Rotating)
                //    m_axes[AxisNames.ZAxis].Visible = true;
                //else if (value == InteractiveModes.ZoomRectangle) 
                //    m_axes[AxisNames.ZAxis].Visible = false; 
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
        /// (experimental) content for graphs will be clipped outside the unit cube
        /// </summary>
        /// <remarks>For 2D plots, not clipping the vertex data may lead to hiding 
        /// the labels drawn next to axes. For 3D plots Clipping may cause unexpected behavior. 
        /// <para>Therefore Clipping will be activated for 2D plots by default and 
        /// deactivated for 3D plots by default.</para></remarks>
        public bool ClipViewData {
            get {
                return m_renderProperties.Clipping; 
            }
            set {
                m_renderProperties.Clipping = value; 
            }
        }
        /// <summary>
        /// Manager providing collection of available IILTextRenderer types
        /// </summary>
        /// <remarks>IILTextRenderer are used to draw labels for axis of this panel (device specific).
        /// <para>Text renderer objects must be instantiated through the ILTextRendererManager instance's
        /// CreateInstance() method.</para></remarks>
        public ILRendererManager TextRendererManager {
            get {
                return m_textRendererManager; 
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
            protected set {
                if (value != null) {
                    m_defaultView = value;
                    m_autoDefaultView = false; 
                } else {
                    m_autoDefaultView = true; 
                }
            }
        }
        /// <summary>
        /// Options for the view cube adapting data limit changes 
        /// </summary>
        public AutoZoomOptions AutoZoomContent {
            get {
                return m_autoZoomOptions; 
            }
            set {
                m_autoZoomOptions = value;
            }
        }
        /// <summary>
        /// choose the ramp for zooming
        /// </summary>
        public ZoomModes ZoomMode {
            get { return m_zoomMode; }
            set { m_zoomMode = value; }
        }
        /// <summary>
        /// How much the view cube will be shrinked/expanded on zooming operations (percent)
        /// </summary>
        public float ZoomOffset {
            set { m_zoomOffset = value; }
            get { return m_zoomOffset; }

        }
        protected ILZoomAction ZoomAction {
            get {
                return m_zoomAction; 
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
            m_plotBoxScreenSizeMode = PlotBoxScreenSizeMode.Optimal; 
            m_graphicsDevice = graphicsDevice; 
            m_textureManager = new ILTextureManager(m_graphicsDevice);
            m_textureManager.DefaultHeight = 500; 
            m_textureManager.DefaultWidth = 500; 
            m_selectionRectangle = new ILLineProperties();
            m_selectionRectangle.Antialiasing = false; 
            m_selectionRectangle.Color = Color.Blue; 
            m_selectionRectangle.Width = 1; 
            m_selectionRectangle.Style = LineStyle.Solid; 
            m_selectionRectangle.Changed += new EventHandler(m_selectionRectangle_Changed);
            m_camera = new ILCamera((float)0.0f,0.0f,10.0f);
            m_defaultView = new ILCamera(m_camera);
            m_defaultView.Changed += new EventHandler(m_defaultView_Changed);
            m_renderProperties = new ILRenderProperties ();
            m_renderProperties.Camera = Camera; 
            m_textRendererManager = new ILRendererManager(this); 
            m_clippingView = new ILClippingData();
            m_clippingView.AllowZeroVolume = false; 
            m_layoutData = new ILLayoutData(m_camera);
            m_clippingView.Changed += new ILClippingDataChangedEvent(m_viewLimits_Changed);
            m_colormap = new ILColormap();
            m_colormap.Changed += new EventHandler(m_colormap_Changed);
            Padding = new Padding(5);
            BackColor = Color.White;
            Dock = DockStyle.Fill; 
            m_legend = ILLegend.Create(this);
            m_legend.Changed += new EventHandler(m_legend_Changed);
            m_active = false;
            m_ready = false; 
        }

        #endregion

        #region public interface function 
        /// <summary>
        /// Dispose this panel, frees all devices, graph- and axis collection
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
            if (m_textureManager != null)
                m_textureManager.Dispose(); 
            base.Dispose(disposing);
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.Dispose(bool) end",DateTime.Now, Environment.TickCount); 
#endif
        }

        /// <summary>
        /// causes the panel to redraw
        /// </summary>
        public override void Refresh() {
            if (InvokeRequired) {
                Invoke((MethodInvoker) delegate () { Refresh(); }); 
            } else {
                base.Refresh(); 
            }
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
        /// fires, if the current colormap has changed
        /// </summary>
        public event EventHandler ColormapChanged; 
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
        protected void m_defaultView_Changed(object sender, EventArgs e) {
            m_autoDefaultView = false;
        }
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
            if (m_zoomAction != null) m_zoomAction.Cancel(); 
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
            m_graphs.Limits.Changed += new ILClippingDataChangedEvent(m_dataLimits_Changed);
            m_graphs.GraphChanged += new ILGraphChangedEvent(m_graphs_GraphChanged);
            m_axes = new ILAxisCollection(m_clippingView,graphFact); 
            if (GraphicsDeviceCreated!= null) {
                GraphicsDeviceCreated(this,null);
            }
            //Invalidate(); 
#if TRACE 
            Trace.Unindent(); 
            Trace.TraceInformation("{0},{1} ILPanel.OnGraphicsDeviceCreated() end",DateTime.Now, Environment.TickCount); 
#endif
        }

        protected virtual void OnColormapChanged() {
            if (ColormapChanged != null) 
                ColormapChanged(this,null); 
            m_graphs.Invalidate(); 
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
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            base.Invalidate(); 
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (m_selectingMode == InteractiveModes.Rotating) {
                #region rotation
                if (m_isDragging || (e.Button == System.Windows.Forms.MouseButtons.Left 
                    && Math.Sqrt(Math.Pow(Math.Abs(e.X - m_mouseStart.X),2) + Math.Pow(Math.Abs(e.Y - m_mouseStart.Y),2)) > 3.0)) {
                    m_isDragging = true; 
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
                    m_mouseStart = e.Location; 
                    Refresh(); 
                }
                #endregion
            } else if (m_selectingMode == InteractiveModes.ZoomRectangle) {
                #region selection rectangle
                if (m_isDragging || (e.Button == System.Windows.Forms.MouseButtons.Left 
                    && Math.Sqrt(Math.Pow(Math.Abs(e.X - m_mouseStart.X),2) + Math.Pow(Math.Abs(e.Y - m_mouseStart.Y),2)) > 3.0)) {
                    m_isDragging = true; 
                    Cursor = Cursors.Cross; 
                    Refresh();
                }
                #endregion
            } else if (m_selectingMode == InteractiveModes.Translating) {
                if (m_isDragging || (e.Button == System.Windows.Forms.MouseButtons.Left 
                    && Math.Sqrt(Math.Pow(Math.Abs(e.X - m_mouseStart.X),2) + Math.Pow(Math.Abs(e.Y - m_mouseStart.Y),2)) > 1.0)) {
                    ILPoint3Df p1,p2,dummy; 
                    Screen2World(m_mouseStart.X,Height - m_mouseStart.Y, out p1, out dummy);
                    Screen2World(e.X, Height - e.Y, out p2, out dummy);
                    if (m_projection == Projection.Perspective) {
                        p1 = ILPoint3Df.normalize(p1 - m_camera.Position) * m_camera.Distance;
                        p2 = ILPoint3Df.normalize(p2 - m_camera.Position) * m_camera.Distance;
                    }
                    p1 = p2 - p1; 
                    m_camera.LookAt -= p1;  
                    m_mouseStart = e.Location; 
                    Refresh(); 
                }
            
            }
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            //System.Diagnostic.Debug.WriteLine("MouseUp");
            if (m_selectingMode == InteractiveModes.ZoomRectangle && m_isDragging) {
                Zoom(Screen2World2D(m_mouseStart.X,Height - m_mouseStart.Y),Screen2World2D(e.X, Height - e.Y));
            }
            m_isDragging = false; 
            Cursor = Cursors.Default; 
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            m_mouseStart = e.Location; 
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);
            //System.Diagnostic.Debug.WriteLine("Click");
            if (m_isDragging == false && (m_selectingMode == InteractiveModes.ZoomRectangle 
                || m_selectingMode == InteractiveModes.Rotating)) {
                // determine new center coords
                ILPoint3Df near, far; 
                Screen2World(e.X,Height - e.Y, out near, out far); //Limits.CenterF.Z);
                if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                    Zoom(near,far,m_zoomOffset / 100); 
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    Zoom(near,far,- m_zoomOffset / 100);
            }
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e) {
            base.OnMouseDoubleClick(e);
            ResetView(true);
            Refresh(); 
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.Control && !m_isCtrlKeyDown) {
                m_oldSelectingMode = m_selectingMode; 
                m_selectingMode = InteractiveModes.Translating; 
                m_isCtrlKeyDown = true; 
                Cursor = Cursors.NoMove2D; 
                //m_isDragging = false; 
            }
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e) {
            if (!e.Control) {
                if (m_isCtrlKeyDown) {
                    m_isCtrlKeyDown = false; 
                    m_selectingMode = m_oldSelectingMode; 
                }
                Cursor = Cursors.Default; 
                //m_isDragging = false; 
            }
            base.OnKeyUp(e);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            if (DesignMode) {
                e.Graphics.Clear(Color.LightGray); 
                return; 
            }
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
#if TRACE 
                    Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): started (re-)configure",DateTime.Now, Environment.TickCount); 
                    Trace.Indent(); 
#endif
                    Configure();
                    if (m_isStartingUp && (m_autoZoomOptions != AutoZoomOptions.Never)) {
                        ResetView(true);
                    }
#if TRACE 
                Trace.Unindent(); 
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
                m_renderProperties.Graphics = e.Graphics;
                m_renderProperties.Reason = RenderReason.PaintEvent;
                m_renderProperties.MinX = int.MaxValue;
                m_renderProperties.MinY = int.MaxValue;
                m_renderProperties.MaxX = int.MinValue;
                m_renderProperties.MaxY = int.MinValue; 
                RenderScene(m_renderProperties.Reset());
#if TRACE 
                Trace.Unindent(); 
                Trace.TraceInformation("{0},{1} ILPanel.OnPaint(): rendering ended",DateTime.Now, Environment.TickCount); 
#endif
                if (m_isStartingUp) {
                    m_isStartingUp = false;
                    Refresh();
                }
            } catch (Exception exc) {
#if TRACE 
                Trace.TraceWarning("{0},{1} ILPanel.OnPaint(): rendering failed. reason: {2}",DateTime.Now, Environment.TickCount,exc.ToString()); 
                Trace.Indent(); 
#endif
                System.Diagnostics.Debug.WriteLine("ILPanel.OnPaint failed: " + exc.ToString()); 
            }
        }
        void m_legend_Changed(object sender, EventArgs e) {
            Invalidate(); 
        }

        void m_graphs_GraphChanged(object sender, ILGraphChangedEventArgs args) {
            ResetView(false); 
        }
        protected void m_graphs_OnCollectionChanged(object sender, ILGraphCollectionChangedEventArgs args) {
            if (args.Reason == GraphCollectionChangeReason.Added) {
                if (AutoDefaultView && (args.Configurator != null)) {
                    args.Configurator.ConfigurePanel(this);
                }
            }
       }
        protected void m_viewLimits_Changed(object sender, ClippingChangedEventArgs e) {
            if (this.InvokeRequired && IsHandleCreated) {
                try {
                    Invoke(new ILClippingDataChangedEvent(m_viewLimits_Changed), sender, e);
                } catch (Exception) { }
            } else {
                m_camera.LookAt = m_clippingView.CenterF; 
                OnViewLimitsChanged(e);
            }
        }
        protected void m_dataLimits_Changed(object sender, ClippingChangedEventArgs e) {
            m_defaultView.EventingSuspend();
            m_defaultView.LookAt = m_graphs.Limits.CenterF;
            m_defaultView.Distance = m_graphs.Limits.SphereRadius * 2;
            m_defaultView.EventingResume(false);
            if (m_autoZoomOptions == AutoZoomOptions.OnDataChanges) 
                ResetView(false); 
            OnDataLimitsChanged(e);  
        }

        protected void m_colormap_Changed(object sender, EventArgs e) {
            OnColormapChanged(); 
        }
        void m_selectionRectangle_Changed(object sender, EventArgs e) {
            // nothing to do here
        }

        #endregion event handler 

        #region virtual abstract interface
        /// <summary>
        /// Get current rendering device (implementation dependent)
        /// </summary>
        /// <returns></returns>
        public abstract object GetDeviceContext(); 
        /// <summary>
        /// Causes a reconfiguration of all axes and graphs on the next paint event
        /// </summary>
        /// <remarks>Call this method after any changes to vertex relevant data. It causes all drawable objects to clear their caches and recalculate all vertex data.</remarks>
        protected new void Invalidate() {
            if (!m_ready) return;
            m_ready = false; 
            m_graphs.Invalidate(); 
            m_axes.Invalidate();
            //base.Invalidate(this.ClientRectangle, true); <- this would cause an immediate redraw also. Use Refresh() for this!
        }
        /// <summary>
        /// update viewing limits to show all data, rotate the scene to default (-> DefaultView)
        /// </summary>
        public virtual void ResetView() {
            ResetView(true);
        }
        /// <summary>
        /// update viewing limits to show all data, optionally reset the scene rotation
        /// </summary>
        /// <param name="resetRotation">true: rotate the scene to the default (-> DefaultView)</param>
        public virtual void ResetView(bool resetRotation) {
            if (m_zoomAction != null)
                m_zoomAction.Cancel();
            m_clippingView.EventingSuspend(); 
            m_clippingView.CopyFrom(m_graphs.Limits); 
            m_clippingView.Update(m_clippingView.CenterF,1.1f); 
            m_clippingView.EventingResume(); 
            if (m_defaultView != null && resetRotation) {
                m_camera.LookAt = m_defaultView.LookAt; 
                m_camera.Phi = m_defaultView.Phi;
                m_camera.Rho = m_defaultView.Rho;
                m_camera.Distance = m_defaultView.Distance;
            }
        }
        /// <summary>
        /// Move &amp; shrink/expand current view cube along a given line
        /// </summary>
        /// <param name="nearLineEnd"></param>
        /// <param name="farLineEnd"></param>
        /// <param name="offset"></param>
        protected virtual void Zoom(ILPoint3Df nearLineEnd, ILPoint3Df farLineEnd, float offset) {
            ILPoint3Df minCorner, maxCorner; 
            m_clippingView.GetZoomParameter(nearLineEnd,farLineEnd,offset, out minCorner, out maxCorner);
            Zoom(minCorner,maxCorner);
            //m_camera.LookAt = m_clippingView.CenterF; 
        }
        /// <summary>
        /// move the center of the viewing cube and expand / shrink the volume by offset
        /// </summary>
        /// <param name="center">new center</param>
        /// <param name="offset">offset multiplicator, 1f means: no change</param>
        protected virtual void Zoom(ILPoint3Df center, float offset) {
            m_clippingView.Update(center,offset);
            Refresh();
        }
        /// <summary>
        /// Zoome the scene to new limits
        /// </summary>
        /// <param name="luCorner">'upper left' (first) corner of the new viewing cube</param>
        /// <param name="rbCorner">'bottom right' (opposed) corner of the viewing cube</param>
        protected virtual void Zoom(ILPoint3Df luCorner, ILPoint3Df rbCorner) {
            if (m_zoomAction != null)
                m_zoomAction.Cancel();
            ILActionRamp ramp;
            switch (m_zoomMode) {
                case ZoomModes.Jump:
                    ramp = ILActionRamp.NoRamp; 
                    break;
                case ZoomModes.RollSoft:
                    ramp = ILActionRamp.Soft; 
                    break;
                case ZoomModes.RollHard:
                    ramp = ILActionRamp.Hard; 
                    break;
                case ZoomModes.RollOverride:
                    ramp = ILActionRamp.Override; 
                    break;
                default:
                    ramp = ILActionRamp.Linear;
                    break;
            }
            m_zoomAction = new ILZoomAction(m_clippingView.Min, luCorner, m_clippingView.Max, rbCorner, ramp, this);
            m_zoomAction.Run();
        }


        /// <summary>
        /// Transform two coordinates for a line from world to screen coordinates
        /// </summary>
        /// <param name="start">1st coordinate (world)</param>
        /// <param name="end">2nd coordinate (world)</param>
        /// <param name="start2D">[output] 1st coordinate (screen pixels)</param>
        /// <param name="end2D">[output] 2nd coordinate (screen pixels)</param>
        /// <remarks>This function is provided by the concrete derived class, using the
        /// current rendering framework.</remarks>
        public abstract void World2Screen(ILPoint3Df start, ILPoint3Df end, out Point start2D, out Point end2D);

        /// <summary>
        /// Transform from a point on screen into world coordinates [depricated]
        /// </summary>
        /// <param name="x">screen x</param>
        /// <param name="y">screen y: GL viewport coord! -> (0,0) is lower left corner!</param>
        /// <returns>world coordinate point</returns>
        public abstract ILPoint3Df Screen2World2D(int x, int y);
        /// <summary>
        /// gives the line in world coords, a specific point on screen lays on
        /// </summary>
        /// <param name="x">screen x</param>
        /// <param name="y">screen y: GL viewport coord! -> (0,0) is lower left corner</param>
        /// <param name="farClip">far end point of the resulting line in world coords</param>
        /// <param name="nearClip">near end point of the resulting line in world coords</param>
        public abstract void Screen2World(int x, int y, out ILPoint3Df nearClip, out ILPoint3Df farClip); 
        
        /// <summary>
        /// Transform world coordinate to screen coordinate under current transformation
        /// </summary>
        /// <param name="worldPoint">world coordinate</param>
        /// <returns>screen location</returns>
        /// <remarks>the actual transform is carried out in the derived specialized class,
        /// where the current transformation matrices are known</remarks>
        public abstract Point World2Screen(ILPoint3Df worldPoint);
        /// <summary>
        /// Transform world coordinate to screen coordinate, provide (custom) modelview matrix
        /// </summary>
        /// <param name="worldPoint"></param>
        /// <param name="modelview">(custom) model view matrix. The parameter must match the format required by the deriving concrete ILPanel class. ILOGLPanel: double[16]</param>
        /// <returns>screen location</returns>
        /// <remarks>the actual transform is carried out in the derived specialized class,
        /// where the current transformation matrices are known</remarks>
        public abstract Point World2Screen(ILPoint3Df worldPoint, double[] modelview); 

        /// <summary>
        /// Draws content of this subfigure into predefined bitmap
        /// </summary>
        /// <param name="bitmap">predefined bitmap to draw content into. The size must have been initialized according to 'bounds'.</param>
        /// <param name="bounds">Rectangle specifying the region to be copied.</param>
        public new abstract void DrawToBitmap(Bitmap bitmap, Rectangle bounds); 
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
        private void calculateDefaultView(bool setPositions, bool setDirection) {
            m_defaultView.EventingSuspend();
            if (setPositions) {
                m_defaultView.LookAt = m_graphs.Limits.CenterF;
                m_defaultView.Distance = m_clippingView.SphereRadius * 2f;
            }
            if (setDirection) {
                m_defaultView.Phi = 0; // -(float)Math.PI / 2;
                m_defaultView.Rho = 0;
            }
            m_defaultView.EventingResume(false);
        }
        #endregion

        #region private rendering setup helper
        protected void helperUpdateMatrices(float width2D, float height2D, out float worldSceneWidth, out float worldSceneHeight, out ILPoint3Df top, out ILPoint3Df moveOffset)
        {
            float localPlotCubeScreenRectLeft;
            float localPlotCubeScreenRectWidth;

            float localPlotCubeScreenRectTop;
            float localPlotCubeScreenRectHeight;

            float offsetX;
            float offsetY;

            localPlotCubeScreenRectHeight = m_plotBoxScreenRectF.Height;
            localPlotCubeScreenRectWidth = m_plotBoxScreenRectF.Width;
            localPlotCubeScreenRectTop = m_plotBoxScreenRectF.Top;
            localPlotCubeScreenRectLeft = m_plotBoxScreenRectF.Left;

            if (AspectRatio == AspectRatioMode.StretchToFill)
            {
                worldSceneWidth = width2D / localPlotCubeScreenRectWidth;
                worldSceneHeight = height2D / localPlotCubeScreenRectHeight;
            }
            else
            { //if (RenderAspectRatioMode == RenderAspectRatioMode.MaintainRatios) {
                float plotCubeScreenRectAspectRatio =
                    (m_plotBoxScreenRectF.Width * ClientSize.Width)
                    / (m_plotBoxScreenRectF.Height * ClientSize.Height);
                float dataAspectRatio = width2D / height2D;
                if (plotCubeScreenRectAspectRatio > dataAspectRatio)
                {
                    // width > height
                    worldSceneHeight = height2D;
                    worldSceneWidth = worldSceneHeight * dataAspectRatio;
                    // enlarge the scene, so we have rendering margin outside the data cube
                    worldSceneHeight /= localPlotCubeScreenRectHeight;
                    worldSceneWidth /= (localPlotCubeScreenRectWidth * (dataAspectRatio / plotCubeScreenRectAspectRatio));
                }
                else
                {
                    // height >= width
                    worldSceneWidth = width2D;
                    worldSceneHeight = worldSceneWidth / dataAspectRatio;
                    // enlarge the scene, so we have rendering margin outside the data cube
                    worldSceneWidth /= localPlotCubeScreenRectWidth;
                    worldSceneHeight /= (localPlotCubeScreenRectHeight / (dataAspectRatio / plotCubeScreenRectAspectRatio));
                }
            }
            // one more pixel please...
            worldSceneHeight = (worldSceneHeight / ClientSize.Height * (ClientSize.Height + 1));
            worldSceneWidth = (worldSceneWidth / ClientSize.Width * (ClientSize.Width + 1));
            // if PlotCubeScreenRect is not centered, we move the scene out of center accordingly (..further down)
            top = new ILPoint3Df(-m_camera.SinPhi * m_camera.CosRho, m_camera.CosPhi * m_camera.CosRho, m_camera.SinRho);
            ILPoint3Df moveX = ILPoint3Df.crossN(m_camera.Position - m_camera.LookAt, top);
            offsetX = -(localPlotCubeScreenRectLeft + (localPlotCubeScreenRectWidth / 2f) - 0.5f) * worldSceneWidth;
            offsetY = -(localPlotCubeScreenRectTop + (localPlotCubeScreenRectHeight / 2f) - 0.5f) * worldSceneHeight;
            moveOffset = top * offsetY + moveX * offsetX;
        }
        protected virtual void RenderScene(ILRenderProperties p) {
            //System.Diagnostics.Debug.Print("m_camera:{0}", m_camera); 
            int countRenderPasses = 2; 
            if (!DesignMode) {
                lock (m_sortingCacheList) {
                    iRenderingState1(p); //make current 
                    // configure axes (determine tick labels in mode 'auto')
                    m_axes.XAxis.Configure(p);
                    m_axes.YAxis.Configure(p);
                    m_axes.ZAxis.Configure(p);


                    //computeLayoutData(p);
                    float rotatedViewLimitX, rotatedViewLimitY, rotatedViewLimitZ;
                    GetTransformedSize(out rotatedViewLimitX, out rotatedViewLimitY, out rotatedViewLimitZ);

                    // determine needed margins according to current tic label collections (which are left over from last rendering run or empty) 
                    Size ticLabelsMargins = GetMaxTicLabelSize(p.Graphics);
                    updatePlotCubeScreenRect(rotatedViewLimitX, rotatedViewLimitY, ticLabelsMargins);
                    p.PassCount = 0;
                    for (; p.PassCount < MAXRENDERPASSES; p.PassCount++) {
                        UpdateMatrices(rotatedViewLimitX, rotatedViewLimitY, rotatedViewLimitZ);

                        updateTickLabelLines();
                        updateLabelPositions(p);
                        if (p.PassCount == 0) {
                        }
                        iRenderingState2(p);  // do the actual drawing
                        //iRenderingState3(p); 
                        #region check if we can fit the plot cube more precisely
                        if (m_plotBoxScreenSizeMode == PlotBoxScreenSizeMode.StrictOptimal) {
                            float t = m_plotBoxScreenRectF.Top;
                            float l = m_plotBoxScreenRectF.Left;
                            float r = m_plotBoxScreenRectF.Right;
                            float b = m_plotBoxScreenRectF.Bottom, tmp;
                            bool resize = false;
                            tmp = (float)p.MinX / ClientSize.Width;
                            if (tmp < l) {
                                if (p.MinX != 0) {
                                    l -= tmp;
                                    resize = true;
                                }
                            } else if (l > 0) {
                                l = 0;
                                resize = true;
                            }
                            tmp = (float)p.MaxX / ClientSize.Width;
                            if (tmp > r) {
                                if (p.MaxX != (ClientSize.Width - 1)) {
                                    r += (1 - tmp);
                                    resize = true;
                                }
                            } else if (r < 1) {
                                r = (float)(ClientSize.Width - 1) / ClientSize.Width;
                                resize = true;
                            }
                            tmp = (float)p.MinY / ClientSize.Height;
                            if (tmp < t) {
                                if (p.MinY != 0) {
                                    t -= tmp;
                                    resize = true;
                                }
                            } else if (t > 0) {
                                t = 0;
                                resize = true;
                            }
                            tmp = (float)p.MaxY / ClientSize.Height;
                            if (tmp > b) {
                                if (p.MaxY != (ClientSize.Height - 1)) {
                                    b += (1 - tmp);
                                    resize = true;
                                }
                            } else if (b < 1) {
                                b = (float)(ClientSize.Height - 1) / ClientSize.Height;
                                resize = true;
                            }
                            if (resize) {
                                // ... there is still room left we can use for enlarging the render cube
                                m_plotBoxScreenRectF = new RectangleF(l, t, r - l, b - t);
                                p.Reason = RenderReason.RecalcLabels;
                                p.MaxY = int.MinValue;
                                p.MaxX = int.MinValue;
                                p.MinY = int.MaxValue;
                                p.MinX = int.MaxValue;
                            }
                            continue;
                        }
                        #endregion
                        break;
                    }
                    iRenderingState3(p);
                }

            }
        }
        protected abstract void iRenderingState1(ILRenderProperties p); 
        /// <summary>
        /// [internal] Configure this panel, to make it ready for output, set "m_ready = true" at end!
        /// </summary>
        protected virtual void Configure() {
            foreach (ILGraph graph in m_graphs) {
                graph.Configure();
            }
            // update clipping view 
            m_clipplanes[0] = -1.0; m_clipplanes[3] = m_clippingView.Max.X;
            m_clipplanes[4] = 1.0; m_clipplanes[7] = -m_clippingView.Min.X;
            m_clipplanes[9] = -1.0; m_clipplanes[11] = m_clippingView.Max.Y;
            m_clipplanes[13] = 1.0; m_clipplanes[15] = -m_clippingView.Min.Y;
            m_clipplanes[18] = -1.0; m_clipplanes[19] = m_clippingView.Max.Z;
            m_clipplanes[22] = 1.0; m_clipplanes[23] = -m_clippingView.Min.Z;

            m_ready = true;
        }
        /// <summary>
        /// draw the scene: all axes, graphs, background etc. (device dependant)
        /// </summary>
        /// <param name="p"></param>
        protected abstract void iRenderingState2(ILRenderProperties p);
        protected abstract void iRenderingState3(ILRenderProperties p);
        protected abstract void UpdateMatrices(float width2D, float height2D, float depth2D);
        /// <summary>
        /// initialize all device specific classes, first called after the panel has been created
        /// </summary>
        /// <remarks>derived types should init all devices here</remarks>
        protected virtual void Initialize() { }
        protected PointF GetXTickLabelLine(out Point start2D, out Point end2D) {
            PointF anchor = new PointF(0,0); // TickLabelAlign.left;
            ILPoint3Df start = new ILPoint3Df(), end = new ILPoint3Df();
            ILTickCollection ticks = m_axes[0].LabeledTicks;
            float tickLen = (ticks.Direction == TickDirection.Outside) ?
                             ticks.TickFraction : 0f;
            float padX = ticks.Padding, padY = padX;
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopLeftFront:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(0,0); //TickLabelAlign.left | TickLabelAlign.top;
                    padX = -m_camera.SinPhi * padX;
                    padY = (m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * (padY) + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopLeftBack:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(1,0); //TickLabelAlign.right | TickLabelAlign.top;
                    padX *= m_camera.SinPhi;
                    padY = (-m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopRightBack:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(0,0); //TickLabelAlign.left | TickLabelAlign.top;
                    padX *= m_camera.SinPhi;
                    padY = (-m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.TopRightFront:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    if (m_camera.Is2DView) {
                        anchor = new PointF(.5f, 0); //TickLabelAlign.center | TickLabelAlign.top;
                    } else {
                        anchor = new PointF(1,0); //TickLabelAlign.right | TickLabelAlign.top;
                    }
                    padX *= -m_camera.SinPhi;
                    padY = (m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftFront:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(1,0); //TickLabelAlign.right | TickLabelAlign.top;
                    padX *= m_camera.SinPhi;
                    padY = (m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomLeftBack:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(0,0); //TickLabelAlign.left | TickLabelAlign.top;
                    padX *= -m_camera.SinPhi;
                    padY = (-m_camera.CosPhi - m_camera.SinRho * m_camera.SinPhi) * padY + m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                case CameraQuadrant.BottomRightBack:
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(1,0); //TickLabelAlign.right | TickLabelAlign.top;
                    padX *= -m_camera.SinPhi;
                    padY = (-m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
                default:    // BottomRightFront
                    start.X = m_clippingView.Min.X;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    start.Z = m_clippingView.Min.Z;
                    end.X = m_clippingView.Max.X;
                    end.Y = start.Y;
                    end.Z = start.Z;
                    anchor = new PointF(0,0); //TickLabelAlign.left | TickLabelAlign.top;
                    padX *= m_camera.SinPhi;
                    padY = (m_camera.CosPhi + m_camera.SinRho * m_camera.SinPhi) * padY - m_camera.SinPhi * ticks.Font.Height / 2;
                    break;
            }
            World2Screen(start, end, out start2D, out end2D);
            // align in screen coords 
            int offY = (int)((m_camera.SinRho - (m_camera.SinPhi % Math.PI))
                        * m_axes[0].LabeledTicks.Font.Height / 2
                        + padY);
            // add padding 
            //System.Diagnostics.Debug.WriteLine(m_camera.Phi); 
            start2D.Y += (int)padY + 1;
            end2D.Y += (int)padY + 1;
            start2D.X += (int)(padX + 1);
            end2D.X += (int)(padX + 1);
            return anchor;
        }
        protected PointF GetYTickLabelLine(out Point start2D, out Point end2D) {
            PointF anchor; // = new PointF(0,0); // TickLabelAlign.left;
            ILPoint3Df start = new ILPoint3Df(), end = new ILPoint3Df();
            ILTickCollection ticks = m_axes[1].LabeledTicks;
            float tickLen = (ticks.Direction == TickDirection.Outside) ?
                ticks.TickFraction : 0f;
            float padX = ticks.Padding, padY = padX;
            if (m_camera.Is2DView) {
                start.X = m_clippingView.Min.X - tickLen;
                start.Y = m_clippingView.Min.Y;
                start.Z = m_clippingView.Min.Z;
                end.X = start.X;
                end.Y = m_clippingView.Max.Y;
                end.Z = start.Z;
                anchor = new PointF(1, 0); // TickLabelAlign.right | TickLabelAlign.top;
                padX *= -m_camera.CosPhi;
                padY = (-m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
            } else {
                switch (m_camera.Quadrant) {
                    case CameraQuadrant.TopLeftFront:
                        start.X = m_clippingView.Min.X - tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(1, 0); // TickLabelAlign.right | TickLabelAlign.top;
                        padX *= -m_camera.CosPhi;
                        padY = (-m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.TopLeftBack:
                        start.X = m_clippingView.Min.X - tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(0, 0); // TickLabelAlign.left | TickLabelAlign.top;
                        padX *= -m_camera.CosPhi;
                        padY = (-m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.TopRightBack:
                        start.X = m_clippingView.Max.X + tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(1,0); // TickLabelAlign.right | TickLabelAlign.top;
                        padX *= m_camera.CosPhi;
                        padY = (m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.TopRightFront:
                        start.X = m_clippingView.Max.X + tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(0,0); // TickLabelAlign.left | TickLabelAlign.top;
                        padX *= m_camera.CosPhi;
                        padY = (m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.BottomLeftFront:
                        start.X = m_clippingView.Max.X + tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(0,0); //  TickLabelAlign.left | TickLabelAlign.top;
                        padX *= m_camera.CosPhi;
                        padY = (-m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.BottomLeftBack:
                        start.X = m_clippingView.Max.X + tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(1,0); // TickLabelAlign.right | TickLabelAlign.top;
                        padX *= m_camera.CosPhi;
                        padY = (-m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    case CameraQuadrant.BottomRightBack:
                        start.X = m_clippingView.Min.X - tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(0,0); // TickLabelAlign.left | TickLabelAlign.top;
                        padX *= -m_camera.CosPhi;
                        padY = (m_camera.SinPhi - m_camera.SinRho * m_camera.CosPhi) * padY + m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                    default:    // BottomRightFront
                        start.X = m_clippingView.Min.X - tickLen;
                        start.Y = m_clippingView.Min.Y;
                        start.Z = m_clippingView.Min.Z;
                        end.X = start.X;
                        end.Y = m_clippingView.Max.Y;
                        end.Z = start.Z;
                        anchor = new PointF(1,0); // TickLabelAlign.right | TickLabelAlign.top;
                        padX *= -m_camera.CosPhi;
                        padY = (m_camera.SinPhi + m_camera.SinRho * m_camera.CosPhi) * padY - m_camera.CosPhi * ticks.Font.Height / 2;
                        break;
                }
            }
            World2Screen(start, end, out start2D, out end2D);
            // align in screen coords 
            //int offY = (int)(Math.Abs(m_camera.CosPhi) * ticks.Font.Height / 2);
            //offY -= (int)(Math.Sin(m_camera.Rho) * ticks.Font.Height / 2); 
            start2D.Y += (int)padY;
            end2D.Y += (int)padY;
            start2D.X += (int)padX;
            end2D.X += (int)padX;
            return anchor;
        }
        protected PointF GetZTickLabelLine(out Point start2D, out Point end2D) {
            PointF anchor = new PointF(1, .5f); // TickLabelAlign.vertCenter | TickLabelAlign.right;
            ILPoint3Df start = new ILPoint3Df(), end = new ILPoint3Df();
            ILTickCollection ticks = m_axes[2].LabeledTicks;
            float tickLen = 0;
            if (ticks.Direction == TickDirection.Outside)
                tickLen = ticks.TickFraction;
            start.Z = m_clippingView.Min.Z;
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopLeftFront:
                    start.X = m_clippingView.Min.X - tickLen;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    break;
                case CameraQuadrant.TopLeftBack:
                    start.X = m_clippingView.Max.X + tickLen;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    break;
                case CameraQuadrant.TopRightBack:
                    start.X = m_clippingView.Max.X + tickLen;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    break;
                case CameraQuadrant.TopRightFront:
                    start.X = m_clippingView.Min.X - tickLen;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    break;
                case CameraQuadrant.BottomLeftFront:
                    start.X = m_clippingView.Min.X - tickLen;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    break;
                case CameraQuadrant.BottomLeftBack:
                    start.X = m_clippingView.Max.X + tickLen;
                    start.Y = m_clippingView.Max.Y + tickLen;
                    break;
                case CameraQuadrant.BottomRightBack:
                    start.X = m_clippingView.Max.X + tickLen;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    break;
                case CameraQuadrant.BottomRightFront:
                    start.X = m_clippingView.Min.X - tickLen;
                    start.Y = m_clippingView.Min.Y - tickLen;
                    break;
                default:
                    break;
            }
            end = start;
            end.Z = m_clippingView.Max.Z;
            World2Screen(start, end, out start2D, out end2D);
            start2D.X -= (ticks.Padding - 1);
            end2D.X -= (ticks.Padding - 1);
            return anchor;
        }
        /// <summary>
        /// Get size of projected view cube - after (!) rotation but before projection -> world space
        /// includes the bounding box, tightly enclosing the current view limits setting 
        /// No labels, No ticks included!! Just the data cube with roatation!
        /// </summary>
        /// <param name="x">out, screen size for X</param>
        /// <param name="y">out, screen size for Y</param>
        /// <param name="z">out, screen size for Z</param>
        protected virtual void GetTransformedSize(out float x, out float y, out float z) {
            float xSize = m_clippingView.WidthF;   // the unrotated width - without labels size
            float ySize = m_clippingView.HeightF;  // dito for height
            float zSize = m_clippingView.DepthF;
            if (m_camera.Rho != 0.0f || m_camera.Phi != 0.0f) { // standard 2D view?
                float cosPhi = Math.Abs(m_camera.CosPhi);
                float sinPhi = Math.Abs(m_camera.SinPhi);
                x = (cosPhi * xSize + sinPhi * ySize); //zSize * Math.Abs(m_camera.SinRho) + (Math.Abs(m_camera.CosRho) * 
                y = zSize * Math.Abs(m_camera.SinRho)
                          + (Math.Abs(m_camera.CosRho) * (sinPhi * xSize + cosPhi * ySize));
                z = zSize * Math.Abs(m_camera.CosRho)
                          + (Math.Abs(m_camera.SinRho) * (sinPhi * xSize + cosPhi * ySize));
            } else {
                x = xSize;
                y = ySize;
                z = zSize;
            }
        }

        private void axisLabelVertical2D(ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            label.Orientation = TextOrientation.Vertical;
            label.Anchor = new PointF(.5f, 0); 
            label.m_position.X = ticks.m_lineEnd.X - tickSize.Width - ticks.Padding - label.Padding;
            switch (label.Alignment) {
                case LabelAlign.Center:
                    label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                    break;
                case LabelAlign.Upper:
                    label.m_position.Y = ticks.m_lineEnd.Y + labelSize.Width / 2;
                    break;
                default:        // lower 
                    label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width / 2;
                    break;
            }
            if (label.m_position.Y < labelSize.Width / 2) {
                label.m_position.Y = labelSize.Width / 2;
            }
            if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width / 2) {
                label.m_position.Y = ClientSize.Height - 1 - labelSize.Width / 2;
            }
        }
        private void positionZAxisLabel(ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            label.Orientation = TextOrientation.Vertical;
            label.Anchor = new PointF(.5f, 0); 
            switch (label.Alignment) {
                case LabelAlign.Center:
                    label.m_position.Y = (ticks.m_lineStart.Y + ticks.m_lineEnd.Y) / 2;
                    break;
                case LabelAlign.Upper:
                    label.m_position.Y = ticks.m_lineEnd.Y - labelSize.Width / 2;
                    break;
                default:        // lower 
                    label.m_position.Y = ticks.m_lineStart.Y + labelSize.Width / 2 ;
                    break;
            }
            label.m_position.X = ticks.m_lineStart.X - tickSize.Width - ticks.Padding - label.Padding;
            if (label.m_position.Y < labelSize.Width / 2) {
                label.m_position.Y = labelSize.Width / 2; 
            }
            if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width / 2) {
                label.m_position.Y = ClientSize.Height - 1 - labelSize.Width / 2;
                //label.Orientation = TextOrientation.Horizontal;
                //label.m_position.X = label.Padding;
                //label.m_position.Y = label.Padding;
            }
        }
        private void axisLabel_BottomRightTopLeft(ILRenderProperties p, ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            label.Anchor = new PointF(.5f, 0);
            bool horiz = decideLabelHorizontalOrientation(p, m_camera, axis);
            if (horiz) {
                #region Horizontal
                label.Orientation = TextOrientation.Horizontal;
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.X = (ticks.m_lineStart.X + ticks.m_lineEnd.X) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.X = ticks.m_lineEnd.X + labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.X = ticks.m_lineStart.X - labelSize.Width / 2;
                        break;
                }
                label.m_position.Y = ticks.m_lineStart.Y + tickSize.Height + ticks.Padding + label.Padding;
                if (label.m_position.X < labelSize.Width / 2) {
                    label.m_position.X = labelSize.Width / 2; 
                }
                #endregion
            } else {
                #region Vertical
                label.Orientation = TextOrientation.Vertical; 
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.Y = (ticks.m_lineStart.Y + ticks.m_lineEnd.Y) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.Y = ticks.m_lineEnd.Y + labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width / 2;
                        break;
                }
                label.m_position.X = ticks.m_lineEnd.X - tickSize.Width - label.Padding - ticks.Padding;
                if (label.m_position.Y < labelSize.Width / 2)
                    label.m_position.Y = labelSize.Width / 2;
                if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width / 2) {
                    label.m_position.Y = ClientSize.Height - 1 - labelSize.Width / 2;
                }
                #endregion
            }
        }
        private void axisLabel_BottomLeftTopRight(ILRenderProperties p,  ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            bool horiz = decideLabelHorizontalOrientation(p, m_camera, axis);
            if (horiz) {
                #region Horizontal
                label.Orientation = TextOrientation.Horizontal;
                label.Anchor = new PointF(0.5f,0); 
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.X = ticks.m_lineEnd.X - label.Size.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.X = ticks.m_lineStart.X + label.Size.Width / 2;
                        break;
                }
                label.m_position.Y = ticks.m_lineStart.Y + tickSize.Height + ticks.Padding + label.Padding;
                if (label.m_position.X > ClientSize.Width - labelSize.Width / 2) {
                    label.m_position.X = ClientSize.Width - labelSize.Width / 2;
                }
                #endregion
            } else {
                #region Vertical
                label.Orientation = TextOrientation.Vertical;
                label.Anchor = new PointF(0.5f, 1);
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.Y = ticks.m_lineEnd.Y + labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.Y = ticks.m_lineStart.Y - labelSize.Width / 2;
                        break;
                }
                label.m_position.X = ticks.m_lineEnd.X + tickSize.Width + ticks.Padding + label.Padding;
                if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width / 2) {
                    label.m_position.Y = ClientSize.Height - 1 - labelSize.Width / 2;
                }
                #endregion
            }
        }
        private void axisLabel_TopRightBottomLeft(ILRenderProperties p, ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            bool horiz = decideLabelHorizontalOrientation(p, m_camera, axis);
            label.Anchor = new PointF(.5f, 0); 
            if (horiz) {
                #region Horizontal
                label.Orientation = TextOrientation.Horizontal;
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.X = ticks.m_lineEnd.X + labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.X = ticks.m_lineStart.X - labelSize.Width / 2;
                        break;
                }
                label.m_position.Y = ticks.m_lineEnd.Y + tickSize.Height + ticks.Padding + label.Padding;
                if (label.m_position.X < labelSize.Width / 2)
                    label.m_position.X = labelSize.Width / 2; 
                if (label.m_position.X > ClientSize.Width - labelSize.Width / 2 - 1)
                    label.m_position.X = ClientSize.Width - labelSize.Width / 2 - 1; 
                #endregion
            } else {
                #region Vertical 
                label.Orientation = TextOrientation.Vertical; 
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.Y = ticks.m_lineEnd.Y - labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.Y = ticks.m_lineStart.Y + labelSize.Width / 2; 
                        break;
                }
                label.m_position.X = ticks.m_lineStart.X + tickSize.Width + ticks.Padding + label.Padding;
                if (label.m_position.Y < labelSize.Width / 2) {
                    label.m_position.Y = labelSize.Width / 2;
                }
                if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width  / 2) {
                    label.m_position.Y = ClientSize.Height - 1 - labelSize.Width  / 2;
                }
                #endregion
            }
        }
        private void axisLabel_TopLeftBottomRight(ILRenderProperties p, ILAxis axis) {
            ILLabel label = axis.Label;
            ILTickCollection ticks = axis.LabeledTicks;
            Size tickSize = ticks.Size, labelSize = label.Size;
            bool horiz = decideLabelHorizontalOrientation(p, m_camera, axis);
            label.Anchor = new PointF(.5f, 0); 
            if (horiz) {
                #region Horizontal
                label.Orientation = TextOrientation.Horizontal;
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.X = (ticks.m_lineEnd.X + ticks.m_lineStart.X) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.X = ticks.m_lineEnd.X - labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.X = ticks.m_lineStart.X + labelSize.Width / 2;
                        break;
                }
                label.m_position.Y = ticks.m_lineEnd.Y + tickSize.Height + ticks.Padding + label.Padding;
                if (label.m_position.X < labelSize.Width / 2) {
                    label.m_position.X = labelSize.Width / 2;
                }
                #endregion
            } else {
                #region Vertical
                label.Orientation = TextOrientation.Vertical;
                switch (label.Alignment) {
                    case LabelAlign.Center:
                        label.m_position.Y = (ticks.m_lineEnd.Y + ticks.m_lineStart.Y) / 2;
                        break;
                    case LabelAlign.Upper:
                        label.m_position.Y = ticks.m_lineEnd.Y - labelSize.Width / 2;
                        break;
                    default:        // lower 
                        label.m_position.Y = ticks.m_lineStart.Y + labelSize.Width / 2;
                        break;
                }
                label.m_position.X = ticks.m_lineStart.X - tickSize.Width - ticks.Padding - label.Padding;
                if (label.m_position.Y < labelSize.Width / 2) {
                    label.m_position.Y = labelSize.Width / 2;
                }
                if (label.m_position.Y > ClientSize.Height - 1 - labelSize.Width / 2) {
                    label.m_position.Y = ClientSize.Height - 1 - labelSize.Width / 2;
                }
                #endregion
            }
        }

        // return true if the label needs horizontal orientation
        private bool decideLabelHorizontalOrientation(ILRenderProperties p, ILCamera m_camera, ILAxis axis) {
            if (p.Reason == RenderReason.RecalcLabels) {
                return axis.Label.Orientation == TextOrientation.Horizontal; 
            }
            float offX = axis.LabeledTicks.m_lineStart.X - axis.LabeledTicks.m_lineEnd.X;
            float offY = axis.LabeledTicks.m_lineStart.Y - axis.LabeledTicks.m_lineEnd.Y;
            return offY * offY < offX * offX;  
            //if (axis.Index == 0) {
            //    b = (float)((1.0 - m_camera.SinRho * 0.9) * Math.Sin(m_camera.Phi * 2.0f)); 
            //} else if (axis.Index == 1) {

            //}
            //return (m_camera.SinRho >= LABELS_VERTICAL_MIN_RHO
            //    || Math.Sign(Math.Cos(m_camera.Phi * 2.0)) != (axis.Index * 2 - 1));
        }
        private int GetMargin4OptimalLabelX() {
            return 0; 
        }
        private int GetMargin4OptimalLabelY() {
            return 0;
        }
        private Size GetMaxTicLabelSize(Graphics gr) {
            Size ret = m_axes.MeasureMaxTickLabelSize(gr);    
            // add label sizes 
            int maxHeight = 0; 
            if (m_axes[0].Label.Visible && !String.IsNullOrEmpty(m_axes[0].Label.Text)) {
                maxHeight = m_axes[0].Label.Size.Height;
            }
            if (m_axes[1].Label.Visible && !String.IsNullOrEmpty(m_axes[1].Label.Text)) {
                if (maxHeight < m_axes[1].Label.Size.Height)
                    maxHeight = m_axes[1].Label.Size.Height;
            }
            if (m_axes[2].Label.Visible && !String.IsNullOrEmpty(m_axes[2].Label.Text)) {
                if (maxHeight < m_axes[2].Label.Size.Height)
                    maxHeight = m_axes[2].Label.Size.Height;
            }
            ret = new Size(ret.Width + maxHeight, ret.Height + maxHeight); 
            return ret; 
        }

        /// <summary>
        /// calculate the real pixels of the plot cube rectangle for drawing into
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        private void updatePlotCubeScreenRect(float xSize, float ySize, Size tickLabelMargins) {
            switch (PlotBoxScreenSizeMode) {
                //case PlotCubeScreenSizeMode.Maximum: // <- will be done in PlotCubeScreenSizeMode.set()
                //    m_plotCubeScreenRectF = new RectangleF(0.0f, 0.0f, 1.0f, 1.0f); 
                //    break;
                case PlotBoxScreenSizeMode.Optimal:
                case PlotBoxScreenSizeMode.StrictOptimal:
                    float saveX, saveY;
                    saveX = ((float)tickLabelMargins.Width / ClientSize.Width);
                    if (saveX < 0) saveX = 0;
                    if (saveX > 1) saveX = 1;
                    saveY = ((float)tickLabelMargins.Height / ClientSize.Height);
                    if (saveY < 0) saveY = 0;
                    if (saveY > 1) saveY = 1; 
                    m_plotBoxScreenRectF = new RectangleF(saveX, saveY, 1f - (2 * saveX), 1f - (2 * saveY));
                    break;
                default: // manual: use predefined PlotCubeScreenRectF
                    break;
            }
        }

        private void updateLabelPositions(ILRenderProperties p) {
            positionZAxisLabel(m_axes[2]);
            switch (m_camera.Quadrant) {
                case CameraQuadrant.TopRightFront:
                    axisLabel_TopLeftBottomRight(p, m_axes[0]);
                    // special case: 2D view? 
                    if (m_camera.SinPhi < 1e-5 && m_camera.SinRho < 1e-5) {
                        axisLabelVertical2D(m_axes[1]);
                    } else {
                        axisLabel_BottomLeftTopRight(p, m_axes[1]);
                    }
                    break;
                case CameraQuadrant.TopRightBack:
                    axisLabel_TopRightBottomLeft(p, m_axes[0]);
                    axisLabel_TopLeftBottomRight(p, m_axes[1]);
                    break;
                case CameraQuadrant.TopLeftFront:
                    axisLabel_BottomLeftTopRight(p, m_axes[0]);
                    axisLabel_BottomRightTopLeft(p, m_axes[1]);
                    break;
                case CameraQuadrant.TopLeftBack:
                    axisLabel_BottomRightTopLeft(p, m_axes[0]);
                    axisLabel_TopRightBottomLeft(p, m_axes[1]);
                    break;
                case CameraQuadrant.BottomLeftFront:
                    axisLabel_TopLeftBottomRight(p, m_axes[0]);
                    axisLabel_TopRightBottomLeft(p, m_axes[1]);
                    break;
                case CameraQuadrant.BottomLeftBack:
                    axisLabel_TopRightBottomLeft(p, m_axes[0]);
                    axisLabel_BottomRightTopLeft(p, m_axes[1]);
                    break;
                case CameraQuadrant.BottomRightBack:
                    axisLabel_BottomRightTopLeft(p, m_axes[0]);
                    axisLabel_BottomLeftTopRight(p, m_axes[1]);
                    break;
                case CameraQuadrant.BottomRightFront:
                    axisLabel_BottomLeftTopRight(p, m_axes[0]);
                    axisLabel_TopLeftBottomRight(p, m_axes[1]);
                    break;
                default:
                    break;
            }
        }

        private void updateTickLabelLines() {
            // determine tick label lines
            ILTickCollection ticks = m_axes[2].LabeledTicks;
            ticks.m_anchor = GetZTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd);
            ticks = m_axes[1].LabeledTicks;
            ticks.m_anchor = GetYTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd);
            ticks = m_axes[0].LabeledTicks;
            ticks.m_anchor = GetXTickLabelLine(out ticks.m_lineStart, out ticks.m_lineEnd);
        }
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
                    panelType = assembly.GetType("ILNumerics.Drawing.Platform.OpenGL.ILDXPanel"); 
                    ret = (ILPanel)panelType.InvokeMember("ILDXPanel", 
                            BindingFlags.DeclaredOnly | BindingFlags.Public 
                            | BindingFlags.NonPublic | BindingFlags.Instance 
                            | BindingFlags.CreateInstance, 
                            null, null, null);
                    return ret; 
                default:
                    // the default is to use OpenGL, which is included into the main assembly (this one)
                    assembly = Assembly.LoadFile(Path.Combine(myPath,"ILNumerics.Drawing.dll")); 
                    panelType = assembly.GetType("ILNumerics.Drawing.Platform.OpenGL.ILOGLPanel"); 
                    ret = (ILPanel)panelType.InvokeMember("ILOGLPanel", 
                            BindingFlags.DeclaredOnly | BindingFlags.Public 
                            | BindingFlags.NonPublic | BindingFlags.Instance 
                            | BindingFlags.CreateInstance, 
                            null, null, null);
                    return ret; 
            }
        }

        /// <summary>
        /// Create GL dependend graph factory 
        /// </summary>
        /// <returns>ILGraphFactory,will be used for creating all graphs</returns>
        /// <remarks>derived types may return GL dependend factory</remarks>
        public abstract IILCreationFactory GetCreationFactory(); 
        #endregion


    }
}
