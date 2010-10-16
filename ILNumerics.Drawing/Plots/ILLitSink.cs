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
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Misc;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Labeling;

namespace ILNumerics.Drawing.Plots {
    /// <summary>
    /// ILNumerics.Drawing plot demonstration, supports multiple shapes, dynamic shape management, light and transparency
    /// </summary>
    public class ILLitSink : ILPlot , ILNumerics.Drawing.Interfaces.IILPanelConfigurator {

        #region eventing
        /// <summary>
        /// timer tick event handler, called for updates of the interval timer
        /// </summary>
        /// <param name="sender">(not used) always this sink plot itself</param>
        /// <param name="e">(not used)</param>
        void m_timer_Tick(object sender, EventArgs e) {
            if (m_timer.Interval > 0 && m_panel != null && m_panel.IsHandleCreated) {
                m_timer.Stop(); 
                LinesPositionOffset += 0.005f * m_gridSpacing;
                //Opacity = (byte)(255 * (LinesPositionOffset / m_gridSpacing)); 
                m_panel.Refresh(); 
                m_timer.Start(); 
            }
        }
        #endregion

        #region attributes
        float m_lowCut; 
        protected int m_res;
        ILLineProperties m_gridProperties;
        protected float m_max;
        protected float m_gridSpacing; 
        protected float m_linesPositionOffset = 0.5f; 
        bool m_linesUpdateNeeded; 
        Timer m_timer; 
        // the shapes and other plots contained in this plot
        ILLitSurface m_surface;
        List<ILLine> m_lines; 
        ILLitSphere m_sphere;
        #endregion

        #region properties
        /// <summary>
        /// get/ set the interval for updates of the moving grid lines [ms]
        /// </summary>
        public int Interval {
            get { return m_timer.Interval; }
            set {
                if (value < int.MaxValue && value > 0) {
                    m_timer.Interval = value;
                    m_timer.Start();  
                } else {
                    m_timer.Stop(); 
                }
            }
        }
        /// <summary>
        /// Overall opacity for the ground 
        /// </summary>
        public byte Opacity {
            get { return m_surface.Opacity; }
            set { 
                m_surface.Opacity = value;
                m_surface.Invalidate(); 
            }
        }
        /// <summary>
        /// colormap used for coloring the ground
        /// </summary>
        public ILColormap Colormap {
            get { return m_surface.Colormap; }
            set {
                m_surface.Colormap = value;
                m_surface.Invalidate();  
            }
        }
        /// <summary>
        /// get reference to the lit sphere 
        /// </summary>
        public ILLitSphere Sphere {
            get  { return m_sphere; }
        }
        /// <summary>
        /// get reference to ILLitSurface (i.e. the ground)
        /// </summary>
        public ILLitSurface Ground {
            get { return m_surface; }
        }
        /// <summary>
        /// offset for the grid lines (for moving effect) 
        /// </summary>
        public float LinesPositionOffset  {
            get { return m_linesPositionOffset; }
            set { 
                m_linesPositionOffset = value;
                if (m_linesPositionOffset > m_gridSpacing) {
                    m_linesPositionOffset = 0; 
                }
                m_linesUpdateNeeded = true;  
                Invalidate(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create new lit sink plot, assign default values 
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        public ILLitSink (ILPanel panel) : this (panel,-10,150) {}
        /// <summary>
        /// create new lit sink
        /// </summary>
        /// <param name="max">lenght of the squared ground</param>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="resolution">horizontal and vertical resolution</param>
        public ILLitSink(ILPanel panel, float max, int resolution)
            : base(panel) {
            m_max = max; 
            m_res = resolution; 
            m_lowCut = -3; 
            m_gridProperties = new ILLineProperties(); 
            m_gridProperties.Color = Color.LightBlue; 
            m_gridProperties.Width = 1; 
            m_gridProperties.Antialiasing = false; 
            m_gridProperties.Style = LineStyle.Solid; 
            m_gridSpacing = 1.0f; 
            m_linesUpdateNeeded = false; 
            m_timer = new Timer(); 
            m_timer.Interval = int.MaxValue;
            m_timer.Tick += new EventHandler(m_timer_Tick);
            createShapes(); 
            Invalidate();
        }
        #endregion

        #region public API
        /// <summary>
        /// called once before rendering the frame, (re)configures the shapes after changes have been made to them
        /// </summary>
        /// <remarks><para>ILPlot plots can (not must) override this method. It is called, right before the scene is 
        /// rendered on screen. Since the containing shapes are independently configured, here (in ILPlot) we
        /// do only need to (re)configure those content of the plot, which must be recreated after changes have been 
        /// applied. In ILSink, f.e., changes to the sphere and the ground (ILLitSurface) are directly distributed 
        /// to the related shapes respectively. This happens, when calling any ILShape.Update() overload or after 
        /// ILShape.Invalidate() has been called. Those shapes will than reconfigure itself and must not be handled here. </para> 
        /// <para>In contrast to that, the (moving) grid lines of the sink plot are constantly created and removed.</para>
        /// </remarks>
        public override void Configure() {
            if (m_linesUpdateNeeded) {
                updateLines(); 
            }
            base.Configure();
        }

        /// <summary>
        /// configure the panel according to default settings of this plot
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <remarks>In order to force a custom configuration of the panel, 
        /// the plot implements the IILPanelConfigurator interface. For every plot 
        /// implementing this interface, the panel will be configured by this 
        /// function once the plot was added to the scene/ to the panel graphs collection.
        /// If the plot does not implement this interface, the panel settings will 
        /// not be altered.</remarks>
        public void ConfigurePanel(ILPanel panel) {
            panel.Projection = Projection.Perspective;
            panel.BackColor = Color.White;
            panel.BackColorCube = Color.White;
            panel.Axes.GridVisible = false;
            panel.Axes.Visible = false; 
            panel.BackgroundFilled = false; 
            panel.AspectRatio = AspectRatioMode.MaintainRatios; 
            panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.Maximum; 
            panel.ClipViewData = false; 
            panel.InteractiveMode = InteractiveModes.Rotating; 
            panel.AutoZoomContent =  AutoZoomOptions.OnStartup; 
            panel.ZoomMode = ZoomModes.Jump;
 
        }
        #endregion

        #region private helper

        private void updateLines() {
            // since we do not want the whole panel to get updated for every line, we disable 
            // eventing for this scene graph node
            EventingSuspend(); 
            // the grid is made out of individual line shapes
            List<ILArray<double>> lines = Computation.CreateLines(-m_max, m_max,
                                        m_lowCut, 0, m_res, m_gridSpacing, m_linesPositionOffset);
            // make sure, we have the exact number of lines needed
            int needCount = lines[0].Dimensions[1] * 2; // x and y direction -> * 2
            if (m_lines.Count > needCount) {
                // if we have to many line shapes, we make unneeded lines invisible
                for (int i = m_lines.Count; i-->needCount;) { 
                    ILLine shape = m_lines[i];
                    shape.Visible = false; 
                }
                // just as well, we could instead have removed the shape from both: 
                // the shape collection of the container (ILSceneGraphInnerNode) and
                // the (convenient but redundant) shape collection of the plot: 
                //Remove(shape);
                //m_lines.Remove(shape);
            }
            while (m_lines.Count < needCount) {
                // we do not have enough lines - so we add new lines here 
                ILLine newLine = new ILLine(m_panel);
                newLine.Properties.Color = m_gridProperties.Color;
                newLine.Label.Text = "";
                newLine.Properties.Width = m_gridProperties.Width;
                newLine.CustomCenter = new ILPoint3Df(0,0,-200); 
                Add(newLine);
                m_lines.Add(newLine);
            }
            // reconfigures all lines 
            for (int i = 0; i < lines[0].Dimensions[1]; i++) {
                // x - grid
                ILLine line = m_lines[i];
                line.Visible = true; 
                line.Update(lines[0][null, i], lines[1][null, i], lines[2][null, i]);
                // y - grid
                line = m_lines[i + lines[0].Dimensions[1]];
                line.Update(lines[1][null, i], lines[0][null, i], lines[2][null, i]);
            }
            // re-enable eventing
            EventingResume(); 
        }
        private void createShapes() {
            // disable eventing, otherwise, for each line added the whole panel would get reconfigured 
            // which would lead to a poor startup performance
            EventingSuspend(); 
            // the ground is a lit surface 
            if (m_surface == null) {
                List<ILArray<double>> mesh = Computation.CreateMesh(-m_max, m_max, m_lowCut, 0, m_res);
                m_surface = new ILLitSurface(m_panel, mesh[0], mesh[1], mesh[2], new ILColormap(Colormaps.Jet));
                m_surface.Opacity = 190;
                Add(m_surface); 
            }
            if (m_lines == null) {
                // we create all individual lines and save them (redundantly) for later convenient reference.
                // (the grid is made out of individual line shapes)
                List<ILArray<double>> lines = Computation.CreateLines(-m_max, m_max,
                                        m_lowCut, 0, m_res, m_gridSpacing, m_linesPositionOffset);
                m_lines = new List<ILLine>();
                for (int i = 0; i < lines[0].Dimensions[1]; i++) {
                    // x - grid
                    ILLine line = new ILLine(m_panel, lines[0][null, i], lines[1][null, i], lines[2][null, i]);
                    line.Properties.Color = m_gridProperties.Color;
                    line.Label.Text = "";
                    line.Properties.Width = m_gridProperties.Width;
                    line.CustomCenter = new ILPoint3Df(0,0,-200); 
                    m_lines.Add(line);
                    Add(line);
                    // y - grid
                    line = new ILLine(m_panel, lines[1][null, i], lines[0][null, i], lines[2][null, i]);
                    line.Properties.Color = m_gridProperties.Color;
                    line.Label.Text = "";
                    line.Properties.Width = m_gridProperties.Width;
                    line.CustomCenter = new ILPoint3Df(0,0,-200); 
                    m_lines.Add(line);
                    Add(line);
                }
            }
            // re-enable eventing, still one shape to be added: the sphere, which will cause a reconfiguration 
            // of the whole panel
            EventingResume(); 
            // lit sphere
            if (m_sphere == null) {
                m_sphere = new ILLitSphere(m_panel, new ILPoint3Df(0,0,1.4f), 1.8f, Color.FromArgb(190,Color.Gold)); 
                Add(m_sphere); 
                m_sphere.Label.Text = ""; 
                m_sphere.Opacity = 190; 
            } 
        }

        private class Computation : ILNumerics.BuiltInFunctions.ILMath {
            /// <summary>
            /// create data needed to create the ground (ILLitSurface)
            /// </summary>
            /// <param name="Min">minimum (x and y)</param>
            /// <param name="Max">maximum (x and y)</param>
            /// <param name="cut">minimum sinkhole level</param>
            /// <param name="zNiveau">overall zero level</param>
            /// <param name="resol">horizontal and vertical resolution</param>
            /// <returns>list of X,Y and Z arrays</returns>
            public static List<ILArray<double>> CreateMesh(
                                            float Min, float Max, 
                                            float cut, float zNiveau, 
                                            int resol) {
                ILArray<double> x = linspace(Min, Max, resol);
                List<ILArray<double>> ret = meshgrid(x, linspace(Max,Min, resol));
                // Z coords
                ret.Add(max(-1.0 / (ret[0] * ret[0] + ret[1] * ret[1]) + zNiveau, cut));
                //ret.Add(find(ret[2] == cut));
                return ret; 
            }
            /// <summary>
            /// create data needed to create grid lines 
            /// </summary>
            /// <param name="Min">minimum (x and y)</param>
            /// <param name="Max">maximum (x and y)</param>
            /// <param name="cut">minimum sinkhole level</param>
            /// <param name="zNiveau">overall zero level</param>
            /// <param name="resol">horizontal and vertical resolution</param>
            /// <param name="gridSpacing">spacing between adjacent grid lines</param>
            /// <param name="gridOffset">starting offset for the grid lines at edges</param>
            /// <returns>list of X,Y and Z arrays<returns>
            /// <remarks>Only the X grid is created. Since we only have squared sink ground, the 
            /// same data can be used for the y grid. </remarks>
            public static List<ILArray<double>> CreateLines(
                                            float Min, float Max, 
                                            float cut, float zNiveau, 
                                            int resol, float gridSpacing,
                                            float gridOffset) {

                List<ILArray<double>> ret = new List<ILArray<double>>();
                // X coords
                ret.Add(repmat(vector(Min + gridOffset, gridSpacing, Max).T, resol, 1)); 
                // Y coords
                ret.Add(repmat(linspace(Min, Max, resol).T, 1, ret[0].Dimensions[1]));
                // Z coords
                ret.Add(max(-1.0 / (ret[0] * ret[0] + ret[1] * ret[1]) + zNiveau, cut) 
                    + MachineParameterFloat.eps);
                //ret.Add(zeros(resol, resol) + 10000);
                //ret[2][0] += 0.01; 
                return ret; 
            }
        }

        #endregion
    }
}
