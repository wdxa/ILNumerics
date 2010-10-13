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
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Labeling; 
using System.Drawing; 

namespace ILNumerics.Drawing.Plots {
    /// <summary>
    /// plot, displaying a simple colored lit 3D box
    /// </summary>
     public class ILLitBox3D : ILPlot {

         #region attributes
         ILLitQuad[] m_quads;
         ILLineProperties m_lineProperties;
         Color m_gradColor;
         Color m_fillColor;
         Color m_topColor; 
         byte m_opacity = 255;
         ILWorldLabel m_valLabel;
         ILShapeLabel m_topLabel; 
         #endregion

         #region properties
         /// <summary>
         /// get the opacity for the box or set it
         /// </summary>
         public byte Opacity {
             get { return m_opacity; }
             set {
                 foreach (ILLitQuad s in m_quads) {
                     s.Opacity = value;
                     for (int i = 0; i < s.Vertices.Length; i++) {
                         s.Vertices[i].Alpha = value;                          
                     }
                 }
                 m_opacity = value; }
         }
         /// <summary>
         /// the color used at one corner for each quad to generate a simple gradient effect 
         /// </summary>
         public Color GradientColor {
             get { return m_gradColor; }
             set {
                m_gradColor = value;
                updateColors(); 
             }
         }
         /// <summary>
         /// properties of the edge lines 
         /// </summary>
         public ILLineProperties Edges {
             get {
                 return m_lineProperties; 
             }
         }
         /// <summary>
         /// overall fill color (bottom and lower area of color gradient) 
         /// </summary>
         public Color FillColor {
             get { return m_fillColor; }
             set {
                 m_fillColor = value; 
                 updateColors(); 
             }
         }
         /// <summary>
         /// top color (top and upper area of color gradient)
         /// </summary>
         public Color TopColor {
             get { return m_topColor; }
             set {
                 m_topColor = value; 
                 updateColors(); 
             }
         }
         /// <summary>
         /// reference to the label which renders the current z-value onto the top area (world coords)
         /// </summary>
         public ILWorldLabel ValueLabel {
             get {
                 return m_valLabel; 
             }
         }
         /// <summary>
         /// label drawn in screen coords on top of the lit box
         /// </summary>
         public ILShapeLabel TopLabel {
             get { return m_topLabel; }
         }
         #endregion

         #region constructor
         /// <summary>
         /// create new lit 3D box
         /// </summary>
         /// <param name="panel">panel hosting the scene</param>
         /// <param name="min">minimum coordinates defining the box' dimensions (x,y,z)</param>
         /// <param name="max">minimum coordinates defining the box' dimensions (x,y,z)</param>
         /// <param name="fillColor">overall color for the box</param>
         /// <param name="topColor">color used to color the top edges of the box</param>
         public ILLitBox3D(ILPanel panel, ILPoint3Df min, ILPoint3Df max, Color fillColor, Color topColor)
             : base(panel) {
             m_lineProperties = new ILLineProperties();
             m_lineProperties.Changed += new EventHandler(m_lineProperties_Changed);
             m_valLabel = new ILWorldLabel(panel);
             m_valLabel.Text = ""; // (max * 1000).Z.ToString("F3");

             ILPoint3Df mi = ILPoint3Df.Min(min, max);
             ILPoint3Df ma = ILPoint3Df.Max(min, max);
             m_valLabel.PositionMax = new ILPoint3Df(ma.X,mi.Y,ma.Z);
             m_valLabel.PositionMin = new ILPoint3Df(mi.X, ma.Y, ma.Z); ;

             m_topLabel = new ILShapeLabel(panel);
             m_topLabel.Color = Color.Blue;
             //m_topLabel.Font = new Font("Arial", 10, FontStyle.Bold);
             string tval = max.Z.ToString("F2");
             m_topLabel.Text =  String.Format("{0}",tval);
             m_topLabel.Anchor = new PointF(0.5f, 1); 

             m_topColor = topColor;

             #region setup quads
             m_quads = new ILLitQuad[6];

             // front
             ILLitQuad quad = new ILLitQuad(m_panel);
             quad.Vertices[0].Position = new ILPoint3Df(min.X, min.Y, min.Z);
             quad.Vertices[1].Position = new ILPoint3Df(min.X, min.Y, max.Z);
             quad.Vertices[2].Position = new ILPoint3Df(max.X, min.Y, max.Z);
             quad.Vertices[3].Position = new ILPoint3Df(max.X, min.Y, min.Z);
             m_quads[QuadIndices.front] = quad; 
             // right
             quad = new ILLitQuad(m_panel);
             quad.Vertices[0].Position = new ILPoint3Df(max.X, min.Y, min.Z);
             quad.Vertices[1].Position = new ILPoint3Df(max.X, min.Y, max.Z);
             quad.Vertices[2].Position = new ILPoint3Df(max.X, max.Y, max.Z);
             quad.Vertices[3].Position = new ILPoint3Df(max.X, max.Y, min.Z);
             m_quads[QuadIndices.right] = quad;
             // back
             quad = new ILLitQuad(m_panel);
             quad.Vertices[0].Position = new ILPoint3Df(max.X, max.Y, min.Z);
             quad.Vertices[1].Position = new ILPoint3Df(max.X, max.Y, max.Z);
             quad.Vertices[2].Position = new ILPoint3Df(min.X, max.Y, max.Z);
             quad.Vertices[3].Position = new ILPoint3Df(min.X, max.Y, min.Z);
             m_quads[QuadIndices.back] = quad;
             // left
             quad = new ILLitQuad(m_panel);
             quad.Vertices[0].Position = new ILPoint3Df(min.X, max.Y, min.Z);
             quad.Vertices[1].Position = new ILPoint3Df(min.X, max.Y, max.Z);
             quad.Vertices[2].Position = new ILPoint3Df(min.X, min.Y, max.Z);
             quad.Vertices[3].Position = new ILPoint3Df(min.X, min.Y, min.Z);
             m_quads[QuadIndices.left] = quad;
             // top
             quad = new ILLitQuad(m_panel); 
             quad.Vertices[0].Position = new ILPoint3Df(min.X, min.Y, max.Z);
             quad.Vertices[1].Position = new ILPoint3Df(max.X, min.Y, max.Z);
             quad.Vertices[2].Position = new ILPoint3Df(max.X, max.Y, max.Z);
             quad.Vertices[3].Position = new ILPoint3Df(min.X, max.Y, max.Z);
             m_quads[QuadIndices.top] = quad;
             // bottom
             quad = new ILLitQuad(m_panel);
             quad.Vertices[0].Position = new ILPoint3Df(min.X, min.Y, min.Z);
             quad.Vertices[1].Position = new ILPoint3Df(max.X, min.Y, min.Z);
             quad.Vertices[2].Position = new ILPoint3Df(max.X, max.Y, min.Z);
             quad.Vertices[3].Position = new ILPoint3Df(min.X, max.Y, min.Z);
             m_quads[QuadIndices.bottom] = quad;
             #endregion
             EventingSuspend();
             foreach (ILLitQuad s in m_quads) {
                 s.Label.Text = "";
                 s.Shading = ShadingStyles.Interpolate;
                 s.Opacity = m_opacity;
                 s.Border.Color = Color.Gray;
                 s.Border.Width = 1;
                 s.Border.Visible = true;
                 s.Border.Antialiasing = false; 
                 Add(s); 
             }
             EventingResume(); 
             m_fillColor = fillColor;
             updateColors();
         }
         #endregion

         #region public interface
         /// <summary>
         /// (internally used) draws the plot 
         /// </summary>
         /// <param name="props"></param>
         public override void Draw(ILRenderProperties props) {
             base.Draw(props);
             m_valLabel.Draw(props);
             ILPoint3Df labPos = m_quads[QuadIndices.top].Center; 
             labPos.Z = Math.Max(m_quads[QuadIndices.top].Center.Z,m_quads[QuadIndices.bottom].Center.Z); 
             m_topLabel.Draw(props,labPos); 
         }
         #endregion

         #region private helpers
         /// <summary>
         /// enum for all 
         /// </summary>
         private static class QuadIndices {
             public static readonly int front = 0;
             public static readonly int right = 1;
             public static readonly int back = 2;
             public static readonly int left = 3;
             public static readonly int top = 4;
             public static readonly int bottom = 5;
         }
         /// <summary>
         /// update all quad borders with new settings
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         void m_lineProperties_Changed(object sender, EventArgs e) {
             foreach (ILLitQuad quad in m_quads) {
                 quad.Border.CopyFrom(m_lineProperties); 
             }

         }
         /// <summary>
         /// distribute changed color settings to all quads 
         /// </summary>
         private void updateColors() {
             SetColorGradient(m_quads[QuadIndices.front], m_fillColor, m_topColor, m_topColor, m_gradColor);
             SetColorGradient(m_quads[QuadIndices.right], m_fillColor, m_topColor, m_topColor, m_gradColor);
             SetColorGradient(m_quads[QuadIndices.back], m_fillColor, m_topColor, m_topColor, m_gradColor);
             SetColorGradient(m_quads[QuadIndices.left], m_fillColor, m_topColor, m_topColor, m_gradColor);
             SetColorGradient(m_quads[QuadIndices.top], m_topColor, m_topColor, m_topColor, m_topColor);
             SetColorGradient(m_quads[QuadIndices.bottom], m_topColor, m_topColor, m_topColor, m_topColor); 
         }
         /// <summary>
         /// color settings helper
         /// </summary>
         /// <param name="quad">quad index</param>
         /// <param name="col0">color 1</param>
         /// <param name="col1">color 2</param>
         /// <param name="col2">color 3</param>
         /// <param name="col3">color 4</param>
         private void SetColorGradient(
                        ILLitQuad quad, Color col0, Color col1, Color col2, Color col3) {
                quad.Vertices[0].Color = col0; 
                quad.Vertices[0].Alpha = m_opacity; 
                quad.Vertices[1].Color = col1; 
                quad.Vertices[1].Alpha = m_opacity; 
                quad.Vertices[2].Color = col2; 
                quad.Vertices[2].Alpha = m_opacity; 
                quad.Vertices[3].Color = col3; 
                quad.Vertices[3].Alpha = m_opacity; 
         }
         #endregion
     }
}
