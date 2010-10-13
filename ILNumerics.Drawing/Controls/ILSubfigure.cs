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
using System.Windows.Forms; 
using System.Drawing; 
using System.Configuration; 
using System.Reflection; 
using ILNumerics.Algorithms; 
using System.Diagnostics; 
using System.IO; 

namespace ILNumerics.Drawing.Controls {
    /// <summary>
    /// Plot control, provides ILPanel, colorbar and title
    /// </summary>
    public class ILSubfigure : UserControl {

        #region attributes 
        private ILPanel m_panel; 
        private ILColorBar m_colorbar;
        private ILBorderFitLabel m_title; 
        private bool m_isInitializing; 
        #endregion

        #region properties
        public override System.Drawing.Color BackColor {
            get {
                return base.BackColor;
            }
            set {
                base.BackColor = value;
                m_panel.BackColor = value; 
            }
        }
        /// <summary>
        /// Gives access to the panel of the figure
        /// </summary>
        public ILPanel Panel {
            get {
                return m_panel; 
            }
        }
        /// <summary>
        /// Gives access to the colorbar of the figure
        /// </summary>
        public ILColorBar ColorBar {
            get {
                return m_colorbar; 
            }
        }
        /// <summary>
        /// Gives the title control
        /// </summary>
        public ILBorderFitLabel Title {
            get {
                return m_title; 
            }
        }
        #endregion

        #region constructors 
        public ILSubfigure () {
            m_isInitializing = true; 
            // setup trace listener 
            string logfile = System.Configuration.ConfigurationManager.AppSettings["logfile"];
            if (!String.IsNullOrEmpty(logfile)) {
                File.Delete(logfile); 
                DefaultTraceListener defTraceListener = new DefaultTraceListener();
                Trace.Listeners.Add(defTraceListener); 
                defTraceListener.LogFileName = logfile; 
                Trace.WriteLine(String.Format("{0} - ILSubfigure.ctor()",DateTime.Now));
            }
            this.Size = new Size(500,400);
            m_panel = ILPanel.Create(getDefaultDeviceType()); 
            m_panel.DrawInactive = true; 
            if (Trace.IndentLevel > 0) 
                Trace.TraceInformation("{0} - ILSubfigure.ctor() - panel created {1}",DateTime.Now,m_panel.GraphicDeviceType);
            m_colorbar = new ILColorBar(m_panel.Colormap); 
            m_colorbar.RegisterRangeSource(m_panel.Graphs.Limits);
            m_panel.ColormapChanged += new EventHandler(m_panel_ColormapChanged);
            m_title = new ILBorderFitLabel();
            m_panel.Graphs.CollectionChanged += new ILGraphCollectionChangedEvent(Graphs_CollectionChanged);
            SetDefaults(); 
            m_panel.Invalidate();
            m_isInitializing = false; 
        }

        void m_panel_ColormapChanged(object sender, EventArgs e) {
            m_colorbar.Colormap = m_panel.Colormap; 
            m_colorbar.Invalidate(); 
        }

        void Graphs_CollectionChanged(object sender, ILGraphCollectionChangedEventArgs args) {
            switch (args.Reason) {
                case GraphCollectionChangeReason.Added:
                    if (args.Graph.Type == GraphType.Plot2D) {
                        m_colorbar.Visible = false; 
                        m_panel.ClipViewData = true; 
                    } else if (args.Graph.Type == GraphType.Surf) {
                        m_colorbar.Visible = true; 
                        m_panel.ClipViewData = false; 
                    } else if (args.Graph.Type == GraphType.Imagesc) {
                        m_colorbar.Visible = false; 
                        m_panel.ClipViewData = false; 
                    }
                    break;
                case GraphCollectionChangeReason.Deleted:
                    break;
                case GraphCollectionChangeReason.Changed:
                    break;
                default:
                    break;
            }

        }
        #endregion

        #region overrides 
        protected override void OnLayout(LayoutEventArgs e) {
            if (m_isInitializing) return; 
            base.OnLayout(e);
#if TRACE             
            Trace.TraceInformation("{0},{1} ILSubfigure.OnLayout(), m_isInitializing is false",DateTime.Now,Environment.TickCount); 
#endif

            layoutChilds(); 
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
#if TRACE             
            Trace.TraceInformation("{0},{1} ILSubfigure.OnLoad ",DateTime.Now,Environment.TickCount); 
#endif
            SuspendLayout(); 
            Controls.Add(m_colorbar);
            Controls.Add(m_title); 
            Controls.Add(m_panel);
#if TRACE             
            Trace.TraceInformation("{0},{1} ILSubfigure.OnLoad ",DateTime.Now,Environment.TickCount); 
#endif

            ResumeLayout(); 
            m_isInitializing = false; 
            if (DesignMode) {
#if TRACE             
                Trace.TraceInformation("{0},{1} ILSubfigure.OnLoad: DesignMode detected",DateTime.Now,Environment.TickCount); 
#endif
                try {
                    SetStyle(ControlStyles.Opaque, true);
                    SetStyle(ControlStyles.ResizeRedraw, true);
                    m_panel.Graphs.AddSurfGraph(ILSpecialData.sinc(14,20));
#if TRACE             
                    Trace.TraceInformation("{0},{1} ILSubfigure.OnLoad:DesignMode: SurfGraph added",DateTime.Now,Environment.TickCount); 
#else 
                } catch (Exception) {
#endif
#if TRACE             
                } catch (Exception exc) {
                    Trace.TraceWarning("{0},{1} ILSubfigure.OnLoad:DesignMode: failure added surf graph: {2}",DateTime.Now,Environment.TickCount,exc.ToString()); 
#endif
                }
            }
            Invalidate(true);
        }
        protected void SetDefaults () {
            BackColor = System.Drawing.Color.FromArgb(179,220,244); 
            m_title.Text = "ILSubfigure"; 
            m_title.Visible = true; 
            m_title.Dock = DockStyle.Top; 
            m_title.BackColor = Color.CornflowerBlue; 
            m_title.ForeColor = Color.Cornsilk; 
            m_colorbar.Dock = DockStyle.Left; 
        }
        /// <summary>
        /// Draws content of this subfigure into proedefined bitmap
        /// </summary>
        /// <param name="bitmap">predefined bitmap to draw content into. The size must have been initialized according to 'bounds'.</param>
        /// <param name="bounds">Rectangle specifying the region to be copied.</param>
        public virtual new void DrawToBitmap(Bitmap bitmap, Rectangle bounds) {
            base.DrawToBitmap(bitmap,bounds);
            Bitmap tmpbmp = new Bitmap(m_panel.Size.Width,m_panel.Size.Height); 
            m_panel.DrawToBitmap(tmpbmp,new Rectangle(0,0,tmpbmp.Width,tmpbmp.Height)); 
            // merge both bitmaps 
            using (Graphics gr = Graphics.FromImage( bitmap )) {
                gr.DrawImage(tmpbmp,m_panel.Location); 
            }
        }
        #endregion

        #region helper functions 
        private GraphicDeviceType getDefaultDeviceType () {
            GraphicDeviceType ret = GraphicDeviceType.OpenGL; 
            // lets see, if a configuration for the app is found
            string useD3D = ConfigurationManager.AppSettings["useDirect3D"];
            if (String.IsNullOrEmpty(useD3D)) {
                // look for an ILNumerics.Drawing.dll.config file and probe this for the setting
                string path = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                Configuration c = ConfigurationManager.OpenExeConfiguration(path);
                KeyValueConfigurationElement kvelem = c.AppSettings.Settings["useDirect3D"];
                if (kvelem != null) 
                    useD3D = kvelem.Value; 
            }

            if (String.IsNullOrEmpty(useD3D)) 
                return ret;
            if (useD3D.Trim() == "1") {
                switch (Environment.OSVersion.Platform) {
                    case PlatformID.Unix:
                        System.Diagnostics.Debug.WriteLine("The Direct3D device is not available on Unix platform! Switching to OpenGL."); 
                        break;
                    default:
                        ret = GraphicDeviceType.Direct3D; 
                        break;
                }
            }
            return ret; 
        }

        private void layoutMovingDock(ref Rectangle crect, ILMovingDockPanel panel
                                ,int width ,int height) {
            panel.Visible = false;
            switch (panel.Dock) {
                case DockStyle.Bottom:
                    panel.Height = height;
                    panel.Width = crect.Width;
                    panel.Top = crect.Top + crect.Height - panel.Height;
                    panel.Left = crect.X;
                    crect.Height -= panel.Height;
                    break;
                case DockStyle.Left:
                    panel.Height = crect.Height;
                    panel.Width = width;
                    panel.Top = crect.Y;
                    panel.Left = crect.X;
                    crect.Width -= panel.Width;
                    crect.X += panel.Width;
                    break;
                case DockStyle.None:
                    //panel.Top = (int)(ClientSize.Height / 4); 
                    //panel.Left = (int)(ClientSize.Width / 4);
                    //panel.Width = width;
                    //panel.Height = height;
                    break;
                case DockStyle.Right:
                    panel.Width = width;
                    panel.Height = crect.Height;
                    panel.Top = crect.Y;
                    panel.Left = crect.Left + crect.Width - panel.Width;
                    crect.Width -= panel.Width;
                    break;
                case DockStyle.Top:
                    panel.Height = height;
                    panel.Width = crect.Width;
                    panel.Top = crect.Y;
                    panel.Left = crect.X;
                    crect.Height -= panel.Height;
                    crect.Y += panel.Height;
                    break;
                default:
                    break;
            }
            panel.Visible = true;
        }

        private void layoutChilds() {
            Rectangle crect = this.ClientRectangle;
            if (m_title.Visible) {
                layoutMovingDock(ref crect, m_title, m_title.Padding.Horizontal + m_title.Font.Height, m_title.Padding.Vertical + m_title.Font.Height);
            }
            if (m_colorbar.Visible) {
                layoutMovingDock(ref crect, m_colorbar, 100, 40);
            }

            if (m_panel != null && crect.Width - Padding.Vertical > 2 && crect.Height - Padding.Horizontal > 2) {
                m_panel.Location = crect.Location;
                m_panel.Size = crect.Size;
            }
        }

        #endregion

    }
}
