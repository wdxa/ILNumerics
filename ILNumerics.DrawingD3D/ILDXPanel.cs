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

//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX; 
using Microsoft.DirectX.Direct3D; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Internal;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Controls;  

/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILBaseArray<float>]]></destination>
    <destination><![CDATA[ILBaseArray<Int16>]]></destination>
    <destination><![CDATA[ILBaseArray<Int32>]]></destination>
    <destination><![CDATA[ILBaseArray<Int64>]]></destination>
    <destination><![CDATA[ILBaseArray<UInt16>]]></destination>
    <destination><![CDATA[ILBaseArray<UInt32>]]></destination>
    <destination><![CDATA[ILBaseArray<UInt64>]]></destination>
    <destination><![CDATA[ILBaseArray<char>]]></destination>
    <destination><![CDATA[ILBaseArray<byte>]]></destination>
    <destination><![CDATA[ILBaseArray<complex>]]></destination>
    <destination><![CDATA[ILBaseArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inCls2
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
</hycalper>
 */
namespace ILNumerics.Drawing.Internal {
    /// <summary>
    /// panel for drawing with DirectX
    /// </summary>
    public sealed partial class ILDXPanel : ILPanel {

        public override object GetDeviceContext() {
            return m_device; 
        }

        #region private members
        Device m_device = null; 
        Matrix m_world; 
        Matrix m_projectionMat; 
        Matrix m_view; 
        private const float Sqrt2 = 1.4142135623730950488016887242097f; 
        #endregion private members 
        /// <summary>
        /// constructor creating new ILPanel instance for use with DirectX
        /// </summary>
        public ILDXPanel ( ) : base( GraphicDeviceType.Direct3D ) { }

        /// <summary>
        /// initializes device specific parts for this panel
        /// </summary>
        /// <remarks>This method will be called after the handle for the control has been created</remarks>
        protected override void Initialize() {
            base.Initialize(); 
            if (m_device != null && !m_device.Disposed)
                m_device.Dispose(); 
            if (!IsHandleCreated) {
                CreateControl(); 
            }

            //System.Diagnostic.Debug.WriteLine("ILDXPanel_Initialize"); 
            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            pp.EnableAutoDepthStencil = true;
            pp.AutoDepthStencilFormat = DepthFormat.D16;
            try {
                //m_device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp);
                m_device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp);
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("ILDXPanel_Initialize failure: " + e.ToString());
                throw new ILInvalidOperationException("Unable to create DirectX device.");
            }   
            m_device.DeviceReset += new EventHandler(m_device_DeviceReset);
            OnGraphicsDeviceCreated(); 
        }

        void m_device_DeviceReset(object sender, EventArgs e) {
            OnGraphicsDeviceReset(); 
        }
        /// <summary>
        /// configure device specific parts of this panel
        /// </summary>
        protected override void Configure() {
            //System.Diagnostic.Debug.WriteLine("ILDXPanel:ConfigureDevice"); 
            m_device.RenderState.Lighting = false;
            m_device.RenderState.ZBufferEnable = false; 
            m_device.RenderState.CullMode = Cull.CounterClockwise; 
            // set viewport
            //double partH = (double)this.Height /100.0, partW = (double)this.Width/100.0; 
            Viewport vp = new Viewport();
            vp.Height = this.ClientSize.Height; // - 2 * m_margin)); 
            vp.Width = this.ClientSize.Width; // - 2 * m_margin)); 
            vp.X = 0; //(int)(partW * m_margin); 
            vp.Y = 0; //(int)(partH * m_margin); 
            m_device.Viewport = vp; 
            m_ready = true; 
        }
        /// <summary>
        /// draw all axes and graphs onto the panel
        /// </summary>
        protected override void RenderScene(Graphics g) {
            if (m_device == null || (!m_active && !m_drawHidden)) 
                return; 
            //System.Diagnostics.Debug.WriteLine("RenderScene"); 
            try {
            // Render the surfaces
                UpdateMatrices(); 
                //System.Diagnostic.Debug.WriteLine("ILDXPanel_RenderScene_Clear");
			    m_device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, BackColor, 1.0f, 0);
                //m_device.RenderState.MultiSampleAntiAlias = true; 
                m_device.RenderState.ZBufferEnable = true; 
                m_device.RenderState.UseWBuffer = true; 
                m_device.RenderState.CullMode = Cull.None; 
                m_device.BeginScene();
                try {
                    // draw all graphs
                    foreach (ILGraph graph in m_graphs) {
                        graph.Draw();  
                    }
                    // generate & draw axis(es)
                    m_device.Transform.World = Matrix.RotationZ(m_camera.Phi);
                    m_axis[0].RenderState1(g); 
                    m_axis[1].RenderState1(g); 
                    m_axis[2].RenderState1(g); 
                } catch (Exception e) {
                    throw e; 
                } finally {
                    m_device.EndScene();
                }
			    m_device.Present();
                m_axis[0].RenderState3(g); 
                m_axis[1].RenderState3(g); 
                m_axis[2].RenderState3(g); 
                if (m_selectingMode == InteractiveModes.ZoomRectangle && m_isMoving) 
                    drawSelectionRect(PointToClient(MousePosition));
            } catch (DeviceLostException e) {}
              catch (InvalidCallException e) {}
        }
        /// <summary>
        /// recalculate matrices based on current clipping data, -view
        /// </summary>
        protected override void UpdateMatrices() {
            // update projection
            float xSize, ySize; 
            GetTransformedSize(out xSize, out ySize);
            // add label's size to increase margin
            Size labelsSize = m_axis.MaxTicLabelSize; 
            xSize = (xSize * ClientSize.Width) / (ClientSize.Width - 2 * labelsSize.Width);
            ySize = (ySize * ClientSize.Height) / (ClientSize.Height - 2 * labelsSize.Height);
            if (m_projection == Projection.Perspective) {
                float angle = (float)Math.Atan2(xSize / 2.0f, m_camera.Distance) * 2.0f;
                m_projectionMat = Matrix.PerspectiveFovLH(angle, ySize / xSize, 0.0f, 12.0f);
                m_device.Transform.Projection = m_projectionMat; 
                
            } else if (m_projection == Projection.Orthographic) {
                m_projectionMat = Matrix.OrthoLH(xSize, ySize, -10.0f, m_camera.Distance +5.5f);
                m_device.Transform.Projection = m_projectionMat; 
            }
            else
                throw new ILInvalidOperationException("invalid projection: " + m_projection.ToString());
            // update lookat 
            m_view = Matrix.LookAtLH(new Vector3(0.0f,
                                                -(float)Math.Sin(m_camera.Rho) * m_camera.Distance,
                                                -(float)Math.Cos(m_camera.Rho) * m_camera.Distance),
                                     new Vector3(0.0f,0.0f,0.0f),
                                     new Vector3(0.0f, (m_camera.Rho < Math.PI / 2) ? 1.0f : -1.0f, 0.0f)); 
            m_device.Transform.View = m_view; 
            //System.Diagnostics.Debug.Print("Phi: " + m_cameraPhi.ToString() + " Theta: " + m_cameraTheta.ToString()); 
            #region built world (scaling & rotation) matrix 
            ILPoint3Df ab = m_clippingView.ScaleToUnitCube(); 
            m_world = Matrix.Scaling(ab.X,ab.Y,ab.Z); //Identity; //RotationZ(m_cameraPhi);  
            ab = m_clippingView.CenterToUnitCube(); 
            m_world *= Matrix.Translation(ab.X,ab.Y,ab.Z);
            m_world *= Matrix.Scaling(1.0f, 1.0f, -1.0f); 
            //if (m_camera.Phi > Math.PI) ;
                //m_camera.Phi -= (float)(2 * Math.PI); 
            m_world *= Matrix.RotationZ((float)(m_camera.Phi)); 
            m_device.Transform.World = m_world; 
            #endregion
        }
        /// <summary>
        /// dispose this panel
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            m_active = false;
            base.Dispose(disposing);
            if (disposing) {
                // he ? 
            }
            if (m_device != null && disposing)
                m_device.Dispose(); 
        }

        public override Point Transform(ILPoint3Df worldPoint) {
            throw new NotImplementedException(); 
        }
        protected override void world2Screen(ILPoint3Df p1_3D, ILPoint3Df p2_3D, out Point p1_2D, out Point p2_2D ) {
            Matrix mat = m_device.Transform.World;
            mat *= m_device.Transform.View;
            mat *= m_device.Transform.Projection;
            Vector3 s = new Vector3(p1_3D.X, p1_3D.Y, p1_3D.Z);
            Vector3 e = new Vector3(p2_3D.X, p2_3D.Y, p2_3D.Z);
            s.TransformCoordinate(mat);
            e.TransformCoordinate(mat);
            s.X = (s.X / 2.0f + 0.5f);
            e.X = (e.X / 2.0f + 0.5f);
            s.Y = -(s.Y / 2.0f - 0.5f);
            e.Y = -(e.Y / 2.0f - 0.5f);
            // variant with margin over viewport
            //float multMarg = (m_device.Viewport.Width / 100.0f); 
            //startX = (int)(multMarg * (100.0f - 0.0f * m_margin) * s.X + m_margin * multMarg); 
            //endX =   (int)(multMarg * (100.0f - 0.0f * m_margin) * e.X + m_margin * multMarg); 
            //multMarg = (m_device.Viewport.Height / 100.0f); 
            //startY = (int)(multMarg * (100.0f - 0.0f * m_margin) * s.Y + m_margin * multMarg); 
            //endY =   (int)(multMarg * (100.0f - 0.0f * m_margin) * e.Y + m_margin * multMarg); 
            float multMarg = (m_device.Viewport.Width);
            p1_2D = new Point ((int)(multMarg * s.X),(int)(m_device.Viewport.Height * s.Y));
            p2_2D = new Point ((int)(multMarg * e.X),(int)(m_device.Viewport.Height * e.Y));
        }


        /// <summary>
        /// get screen coords for line the labels should be drawn on
        /// </summary>
        /// <param name="axis">axis name, one out of AxisNames enum: XAxis,YAxis,ZAxis</param>
        /// <param name="start">[out] start coords for the label line (screen coords!)</param>
        /// <param name="end">[out] end coords for the label line (screen coords!)</param>
        /// <param name="align">[out] determines optimal alignmnt for text to be written</param>
        /// <returns>true on success, false else</returns>
        /// <remarks>This uses the current projection settings! It should therefore 
        /// be called AFTER all matrices have been set.</remarks>

        /// <summary>
        /// the current D3D device 
        /// </summary>
        internal Device Device {
            get {
                return m_device; 
            }
        }

        #region IILGraphFactory Member
        /// <summary>
        /// create specific graph type for Direct3D use
        /// </summary>
        /// <param name="data">numeric array, shape depends on plot type</param>
        /// <param name="properties">graph properties</param>
        /// <param name="additionalParams">additional parameter, currently not used</param>
        /// <returns>ILGraph object</returns>
        public override ILGraph CreateGraph(ILBaseArray data, GraphType graphType, params object[] additionalParams) {
            switch(graphType) {
                case GraphType.Plot2D:
                    return new ILDXGraphPlot2D(this, data,m_graphs.Clipping); 
                case GraphType.Surf:
                    return new ILDXGraphSurf3D(this, data,m_graphs.Clipping); 
                default: 
                    throw new ILInvalidOperationException("Graph type not supported: " + graphType.ToString()); 
            }
        }
        /// <summary>
        /// create device dependent axis object (Direct3D)
        /// </summary>
        /// <param name="name">axis type: XAxis,YAxis,ZAxis</param>
        /// <param name="parameters">not used</param>
        /// <returns>ILDXAxis object for use with ILDXPanel (Direct3D)</returns>
        public override ILAxis CreateAxis(AxisNames name, ILClippingData clippingView, params object[] parameters) {
            return new ILDXAxis(name,clippingView,m_layoutData,this); 
        }
        #endregion
    }
}