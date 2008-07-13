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
using OpenTK.Graphics; 
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics.OpenGL.Enums; 
using System.Drawing;
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Platform.OpenGL {
    /// <summary>
    /// OpenGL implementation for ILAxis 
    /// </summary>
    public abstract class ILOGLAxis : ILAxis, IDisposable {

        #region attributes
        ILOGLPanel m_panel; 
        private int m_primitivCount;
        #endregion

        #region constructor
        internal ILOGLAxis (AxisNames name, ILClippingData clippingView,
                            ILLayoutData layoutData,
                            ILOGLPanel panel)
            : base (name,clippingView,layoutData,panel) {
            m_invalidated = true;
            panel.GraphicsDeviceCreated += new ILGraphicsDeviceCreatedEvent(initialize);
            panel.GraphicsDeviceReset += new ILGraphicsDeviceResetEvent(configure);
            m_panel = panel;
        }
        #endregion

        #region helper functions
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
        private void debub_write_mat(string prefix) {
            double[] modmat = new double[16]; 
            GL.GetDouble(GetPName.ProjectionMatrix,modmat); 
            System.Diagnostics.Debug.Write(prefix + new ILArray<double>(modmat,4,4).ToString()); 
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
        #endregion 

        #region ILAxis abstract overrides
        public override void Dispose()
        {
            m_invalidated = true;
            base.Dispose();
        }

        public override void PrepareMeshes(Graphics g) {
            return; 
        }

        public override void PrepareLabels(Graphics g) {
            return; 
        }

        #endregion
         

    }
}
