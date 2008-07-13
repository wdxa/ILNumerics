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
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Collections; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing {
    /// <summary>
    /// Axis object for subfigures - Do not directly instantiate this class!
    /// </summary>
    public abstract class ILAxis : IDisposable {

        #region attributes
        
        public event EventHandler Changed; 
        protected ILTickCollection m_labeledTicks; 
        protected ICollection<UnlabeledTick> m_unLabeledTicks; 
        protected ILLineProperties m_grid; 
        protected ILLineProperties m_nearLines; 
        protected ILLineProperties m_farLines; 
        protected ILClippingData m_clipping; 
        protected ILAxisLabel m_label; 
        protected AxisType m_axisType;
        protected AxisNames m_axisName; 
        protected bool m_visible = true; 
        protected bool m_invalidated = true; 
        protected ILLayoutData m_layoutData; 
        private ILLabeledTickProvider m_labelProvider; 
        #endregion 

        #region properties
        /// <summary>
        /// Used to retrieve/specify the delegate computing nice labels for axis
        /// </summary>
        /// <remarks>One can replace the default tick provider by a user 
        /// defined labeled tick computation function. Therefore simply set this property to
        /// your own ILLabeledTickProvider function.
        /// </remarks>
        public ILLabeledTickProvider LabeledTickProvider {
            get {
                return m_labelProvider; 
            }
            set {
                if (value == null) return; 
                m_labelProvider = value; 
            }
        }
        /// <summary>
        /// get properties for far axis lines (opposite label side) or sets it
        /// </summary>
        public ILLineProperties FarLines {
            get {
                return m_farLines; 
            }
            set {
                m_farLines = value; 
                OnChange();
            }
        }
        /// <summary>
        /// get properties for near axis lines (opposite label side) or sets it
        /// </summary>
        public ILLineProperties NearLines {
            get {
                return m_nearLines; 
            }
            set {
                m_nearLines = value; 
                OnChange(); 
            }
        }
        /// <summary>
        /// label to be displayed next to this axis
        /// </summary>
        public ILAxisLabel Label {
            get {
                return m_label; 
            }
            set {
                m_label = value; 
                OnChange(); 
            }
        }
        /// <summary>
        /// Switch visibility on/ off
        /// </summary>
        public bool Visible { 
            get {
                return m_visible;
            }
            set {
                m_visible = value; 
                OnChange(); 
            }
        }
        /// <summary>
        /// axis type
        /// </summary>
        public AxisType AxisType {
            get {
                return m_axisType; 
            }
            set {
                m_axisType = value; 
                OnChange(); 
            }
        }
        /// <summary>
        /// Gives access to the collection of labeled ticks
        /// </summary>
        public ILTickCollection LabeledTicks {
           get { 
               return m_labeledTicks; 
           }
        }
        /// <summary>
        /// access to the collection of unlabeled ticks (not used)
        /// </summary>
        public ICollection<UnlabeledTick> UnlabeledTicks {
            get {
                return m_unLabeledTicks; 
            }
        }
        /// <summary>
        /// access to a specific axis by number 
        /// </summary>
        public int Index {
            get {
                return (int)m_axisName;
            }
        }
        /// <summary>
        /// access grid lines properties 
        /// </summary>
        public ILLineProperties Grid {
            get {
                return m_grid;
            }
        }
        /// <summary>
        /// access axis limits 
        /// </summary>
        public ILClippingData Limits {
            get {
                return m_clipping; 
            }
        }

        #endregion

        #region Event handling
        /// <summary>
        /// fires a changed event
        /// </summary>
        protected void OnChange() {
            Invalidate();
            if (Changed != null) {
                Changed(this,null); 
            }
        }
        /// <summary>
        /// occures if the registered clipping data have changed
        /// </summary>
        /// <param name="sender">ILClipping data</param>
        /// <param name="e">clipping changed event args</param>
        void m_clipping_Changed(object sender, ClippingChangedEventArgs e) {
            Invalidate(); 
        }
        void m_labeledTicks_Changed(object sender, ILAxisChangedEventArgs args) {
            Invalidate();
        }
        void m_grid_Changed(object sender, EventArgs e) {
            Invalidate(); 
        }
        void m_label_Changed(object sender, EventArgs e) {
            Invalidate(); 
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct ILAxis object. This contructor is not to be called directly. 
        /// </summary>
        /// <param name="name">type of the axis: XAxis,YAxis,ZAxis</param>
        /// <param name="clippingView">Clipping data to be registered into the axis.</param>
        /// <remarks>ILAxis objects are created GL-device dependend by use of a device dependend ILPanel instance's 
        /// member ILPanel.CreateAxis(). This acts like a factory pattern. The specific axis derivate will be 
        /// created by the derived ILPanel object (ILDXPanel or ILOGLPanel).</remarks>
        public ILAxis (AxisNames name, ILClippingData clippingView,
                       ILLayoutData layoutData,ILPanel panel) {
            m_axisName = name; 
            m_labeledTicks = new ILTickCollection(panel,m_axisName);
            m_layoutData = layoutData; 
            m_labelProvider = null; 
            m_labeledTicks.Changed += new AxisChangedEventHandler(m_labeledTicks_Changed);
            m_unLabeledTicks = new List<UnlabeledTick>(10); 
            m_grid = new ILLineProperties();
            m_grid.Style = LineStyle.Dashed; 
            m_grid.Changed += new EventHandler(m_grid_Changed);
            m_clipping = clippingView; 
            m_axisType = AxisType.Linear;
            m_nearLines = new ILLineProperties(); 
            m_nearLines.Color = Color.Gray; 
            m_nearLines.Width = 1; 
            m_nearLines.Antialiasing = true; 
            m_nearLines.Changed +=new EventHandler(m_grid_Changed);
            m_farLines = new ILLineProperties(); 
            m_farLines.Color = Color.Gray; 
            m_farLines.Width = 1; 
            m_farLines.Antialiasing = true; 
            m_farLines.Changed +=new EventHandler(m_grid_Changed);
            m_label = new ILAxisLabel(panel);
            m_label.Changed += new EventHandler(m_label_Changed);
            m_clipping.Changed += new ILClippingDataChangedEvent(m_clipping_Changed);
            m_invalidated = true; 
        }
        #endregion

        #region abstract interface 
        /// <summary>
        /// this function does the drawing of the axis lines 
        /// </summary>
        /// <param name="g">current System.Drawings.Graphics object. Use this with care! Some 
        /// graphics devices (like D3D) may block rendering surface exclusively.</param>
        /// <param name="background">true: draw background only, false: draw foreground only</param>
        /// <param name="camera">current camera paremeter, may needed to determine which axis are front/back</param>
        /// <remarks>This function is called in the general rendering algorithm. I.e. <b>before</b> the surface buffers has been swapped.</remarks>
        protected abstract void iDrawAxis(Graphics g, bool background); 
        /// <summary>
        /// do the drawing of axis' label 
        /// </summary>
        /// <param name="g">current System.Drawings.Graphics object. Use this with care! Some 
        /// graphics devices (like D3D) may block rendering surface exclusively.</param>
        /// <remarks>When this function is called, depends on the DrawAfterBufferSwaped setting 
        /// of the current TextRenderer.</remarks>
        protected virtual void iDrawLabel(Graphics g) {
            m_label.Draw(g);
        }

        protected virtual void iDrawTickLabels(Graphics g) {
            if (m_visible)
                m_labeledTicks.Draw(g,m_clipping.Min[Index],m_clipping.Max[Index]); 
        }
        /// <summary>
        /// Do all rendering for the grid of the axis
        /// </summary>
        /// <param name="camera">current camera settings</param>
        protected abstract void drawGrid(); 

        /// <summary>
        /// draw this axis in the back (behind the graphs)
        /// </summary>
        /// <remarks>This method is used internally. There should be no need to call it directly.</remarks>
        public virtual void RenderState1(Graphics g) {
            if (m_invalidated) 
                Configure(g); 
            if (!m_labeledTicks.Renderer.DrawAfterBufferSwapped)
                iDrawTickLabels(g); 
            if (!m_label.Renderer.DrawAfterBufferSwapped) 
                iDrawLabel(g); 
            iDrawAxis(g,true); 
        } 
        /// <summary>
        /// Do rendering of foreground (before the graphs)
        /// </summary>
        /// <param name="g"></param>
        public virtual void RenderState2(Graphics g) {
            if (m_invalidated) 
                Configure(g); 
            iDrawAxis(g,false); 
        }
        /// <summary>
        /// do rendering after the buffers have been swapped
        /// </summary>
        /// <param name="g"></param>
        public virtual void RenderState3(Graphics g) {
            if (m_labeledTicks.Renderer.DrawAfterBufferSwapped)
                iDrawTickLabels(g); 
            if (m_label.Renderer.DrawAfterBufferSwapped) 
                iDrawLabel(g); 
        }
 
        /// <summary>
        /// update axis (recalculate number &amp; position of labels in auto mode, recreate vertices)
        /// </summary>
        /// <remarks>This method is used internally. There should be no need to call it directly.</remarks>
        internal virtual void Configure(Graphics g) {
            if (m_labeledTicks.Mode == TickMode.Auto) {
                int tickCount = GetOptimalTickNumber(g); 
                if (m_labelProvider != null) {
                    string format = String.Format("g{0}",m_labeledTicks.Precision); 
                    m_labeledTicks.Replace(
                        m_labelProvider(m_clipping.Min[Index],m_clipping.Max[Index],tickCount));
                } else {
                    m_labeledTicks.CreateAuto(m_clipping.Min[Index],m_clipping.Max[Index],tickCount);
                }
            }
            PrepareMeshes(g); 
            PrepareLabels(g); 
            m_invalidated = false; 
        }
        /// <summary>
        /// recreate vertices
        /// </summary>
        public abstract void PrepareMeshes(Graphics g);
        /// <summary>
        /// recreate labels
        /// </summary>
        public virtual void PrepareLabels(Graphics g) {
            // prepare textrenderer
        }

        /// <summary>
        /// number of ticks optimally fitting on screen 
        /// </summary>
        /// <returns>optimal number of ticks for this axis</returns>
        internal int GetOptimalTickNumber(Graphics g) {
            System.Diagnostics.Debug.Assert(m_labeledTicks.Mode == TickMode.Auto); 
            SizeF rect = m_labeledTicks.Size; 
            Point s = new Point(),e = new Point();
            s = m_labeledTicks.m_lineStart; 
            e = m_labeledTicks.m_lineEnd; 
            s.X = (int)(Math.Floor((float)Math.Abs(e.X - s.X) / (float)(rect.Width + m_labeledTicks.Padding))); 
            s.Y = (int)(Math.Floor((float) Math.Abs(e.Y - s.Y) / (float)(rect.Height + m_labeledTicks.Padding))); 
            return (int)Math.Floor(Math.Max((double)s.X,s.Y) + 1); 
        }
        
        /// <summary>
        /// determine number of primitives (lines) to be drawn for this axis
        /// </summary>
        /// <returns>number of primitives</returns>
        internal int countPrimitves() {
            return (m_visible)? 
                (m_labeledTicks.Count + 1 + m_unLabeledTicks.Count) * 4 : 4; 
        }

        /// <summary>
        /// Invalidate this axis, leads to recreation on next render
        /// </summary>
        public virtual void Invalidate() {
            m_invalidated = true; 
        }

        /// <summary>
        /// dispose off this axis' elements
        /// </summary>
        public virtual void Dispose() {
            if (m_labeledTicks != null) 
                m_labeledTicks.Dispose(); 
            if (m_label != null) {
                m_label.Dispose(); 
            }
        }

        #endregion

        #region private helper 
        #endregion
    }
}
