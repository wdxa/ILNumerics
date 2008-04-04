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
using OpenTK;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics.OpenGL.Enums; 
using OpenTK.Math; 
using System.Drawing;
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.TextRenderer; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Internal {
    public abstract class ILOGLAxis : ILAxis, IDisposable {
        ILOGLPanel m_panel; 
        private int m_primitivCount; 

        internal ILOGLAxis (AxisNames name, ILClippingData clippingView,
                            ILLayoutData layoutData,
                            ILOGLPanel panel)
            : base (name,clippingView,layoutData) {
            m_invalidated = true;
            m_labeledTicks.TextRenderer = panel.TextRendererManager.GetDefault(); 
            m_label.TextRenderer = panel.TextRendererManager.GetDefault(); 

            panel.GraphicsDeviceCreated += new ILGraphicsDeviceCreatedEvent(initialize);
            panel.GraphicsDeviceReset += new ILGraphicsDeviceResetEvent(configure);
            m_panel = panel; 
        }

        private void initialize(object sender, EventArgs eventArgs) {
            if (m_panel == null || m_panel.GetDeviceContext() == null)
                return; 
            Dispose(); 
            // todo: setup font + sprite objects for OpenGL ?
            m_primitivCount = countPrimitves(); 
            //m_labeledTicks.TextRenderer = m_panel.TextRendererManager.CreateInstance(
            //            "ILNumerics.Drawing.TextRenderer.ILGDIRenderer" ,null); 
            //m_label.TextRenderer = m_panel.TextRendererManager.CreateInstance(
            //            "ILNumerics.Drawing.TextRenderer.ILGDIRenderer" ,null); 
        }

        void configure(object sender, EventArgs eventArgs) {       
        }

        public override void Dispose()
        {
            m_invalidated = true;
            base.Dispose();
        }

        #region ILAxis abstract overrides
        
        private void debub_write_mat(string prefix) {
            double[] modmat = new double[16]; 
            GL.GetDouble(GetPName.ProjectionMatrix,modmat); 
            System.Diagnostics.Debug.Write(prefix + new ILArray<double>(modmat,4,4).ToString()); 
        }
        
        internal void UpdateMeshes(ILAxis axis, ILClippingData clipping) {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PrepareMeshes(Graphics g) {
            return; 
        }

        public override void PrepareLabels(Graphics g) {
            return; 
        }

        #endregion

        protected override void iDrawLabel(Graphics g) {
            if (!m_visible) return; 
            // draw the main axis label 
            m_label.TextRenderer.Prepare(g); 
            m_label.TextRenderer.Draw(m_label.Text,m_label.m_position,m_label.Color);
            m_label.TextRenderer.Free(); 
        }
 
        protected override void iDrawTickLabels(Graphics g) {
            if (!m_visible) return; 
            int axisIdx = Index; 
            Point start = new Point(), end = new Point(); 
            TickLabelAlign align = m_labeledTicks.m_align;
            m_labeledTicks.TextRenderer.Alignment = align;
            m_labeledTicks.TextRenderer.Prepare(g); 
            start = m_labeledTicks.m_lineStart; 
            end = m_labeledTicks.m_lineEnd;
            float clipRange = m_clipping.Max[axisIdx] - m_clipping.Min[axisIdx]; 

            ILPoint3Df mult = new ILPoint3Df(
                        ((float)(end.X - start.X) / clipRange),
                        ((float)(end.Y - start.Y) / clipRange),
                        0);
            float tmp;
            Point point = new Point(0,0); 
            Color col = m_labeledTicks.LabelColor; 
            float min = m_clipping.Min[Index], max = m_clipping.Max[Index]; 
            foreach (LabeledTick lt in m_labeledTicks) {
                if (! String.IsNullOrEmpty( lt.Label)
                    && lt.Position >= min 
                    && lt.Position <= max) {
                    tmp = lt.Position-m_clipping.Min[axisIdx]; 
                    point.X = (int)(start.X + mult.X * tmp);
                    point.Y = (int)(start.Y + mult.Y * tmp); 
                    m_labeledTicks.TextRenderer.Draw(lt.Label,point,col); 
                }
            } 
            m_labeledTicks.TextRenderer.Free(); 
        }
        
        protected void ConfigureOGLLineProperties(LineStyle style, int width) { 
            int stipFact = 0; 
            short stipple = ILPanel.StippleFromLineStyle(style,ref stipFact); 
            GL.LineWidth(width); 
            if (style == LineStyle.Solid || style == LineStyle.None) {
                GL.Disable(EnableCap.LineStipple); 
            } else {
                GL.Enable(EnableCap.LineStipple); 
                GL.LineStipple (stipFact,stipple); 
            }
        }

    }
}
