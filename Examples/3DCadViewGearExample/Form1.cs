using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.BuiltInFunctions;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Shapes;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plots; 
using ILNumerics.Drawing.Misc; 

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        
        // we use 3 distinct ILPanel in our form
        ILPanel m_panel1;
        ILPanel m_panel2;
        ILPanel m_panel3;

        public Form1() {
            InitializeComponent();
            this.Size = new Size(622, 570); 
            // create the first panel
            m_panel1 = ILPanel.Create();
            m_tableLayout.Controls.Add(m_panel1,0,0);
            // create triangles 3D shape, we will reuse it for all panels later
            ILLitTriangles triangles = Computation.LoadSTL(
                        m_panel1
                        , ""); // path to your STL (ASCII) text file here ... 
            
            // use vertices colors
            triangles.Shading = ShadingStyles.Interpolate; 
            // some tuning for light
            triangles.Material.Specular = Color.Gray; 
            triangles.Label.Text = "";

            // setup 3 panels
            m_panel1.Graphs.AddSceneGraph().AddNode(triangles);
            m_panel1.Dock = DockStyle.Fill;
            m_panel1.Lights[1].Enabled = true;
            m_panel1.Lights[1].Position = new ILPoint3Df(-100, 0, 10);
            m_panel1.Lights[1].Diffuse = Color.Blue;
            m_panel1.Lights[0].Ambient = Color.FromArgb(30, 30, 30);
            m_panel1.Lights[1].Ambient = Color.Black;
            m_panel1.AspectRatio = AspectRatioMode.MaintainRatios;
            m_panel1.DefaultView.SetDeg(285,105,700);
            m_panel1.Projection = Projection.Perspective;
            m_panel1.BackColorCube = Color.LightGray; 

            // front view
            m_panel2 = ILPanel.Create();
            m_tableLayout.Controls.Add(m_panel2,1,0);
            m_panel2.Dock = DockStyle.Fill;
            m_panel2.Graphs.AddSceneGraph().AddNode(triangles); 
            m_panel2.PlotBoxScreenRect = new RectangleF(0.25f, 0.2f, 0.7f, 0.8f);
            m_panel2.DefaultView.SetDeg(90, 90, 300);
            m_panel2.Axes.YAxis.Visible = false;
            m_panel2.Axes.ZAxis.Label.Text = "Z - Axis";
            m_panel2.Lights[0].Ambient = Color.Gray;
            m_panel2.Lights[0].Diffuse = Color.Green;
            m_panel2.Lights[0].Specular = Color.White;
            m_panel2.Lights[0].Position = new ILPoint3Df(90, 12, 22); 

            // top view
            m_panel3 = ILPanel.Create();
            m_tableLayout.Controls.Add(m_panel3,1,1);
            m_panel3.Dock = DockStyle.Fill;
            m_panel3.Graphs.AddSceneGraph().AddNode(triangles); 
            m_panel3.PlotBoxScreenRect = new RectangleF(0.25f, 0f, 0.7f, 0.75f);
            m_panel3.Axes.XAxis.Label.Text = "X - Axis";
            m_panel3.Axes.YAxis.Label.Text = "Y - Axis II";
            m_panel3.Lights[0].Ambient = Color.FromArgb(250,50,50);
            m_panel3.Lights[0].Diffuse = Color.Yellow;
            m_panel3.Lights[0].Specular = Color.Gray;
            m_panel3.Lights[0].Position = new ILPoint3Df(50, 12, 22);
            m_panel3.Lights[1].Enabled = true;
            m_panel3.Lights[1].Position = new ILPoint3Df(25, 42, 32);
            m_panel3.Lights[1].Ambient = Color.Yellow; 

            // info
            Label label = new Label(); 
            m_tableLayout.Controls.Add(label, 0, 1);
            label.Font = new Font("Sans Serif", 11, FontStyle.Bold);
            label.Text = @"ILNumerics.Drawing.ILPanel example: 
Based on a TableLayoutControl, 3 ILPanel controls are arranged in a tablular sense. 
The properties 'PlotCubeScreenRect' is used on the panels in the right column. Setting 
this rectangle allows for exact pixel alignment of multiple panels. Note also, each panel 
has its own default view (rotation) and colormap assigned to it.
However, they all three do share the same ILLitTriangles composite shape.";
            label.Dock = DockStyle.Fill;
        }

        private class Computation {

            public static ILLitTriangles LoadSTL(ILPanel panel, string par1) {
                string[] lines; 
                // modify according the number format in the stl file! Here: 0.12345
                System.Globalization.NumberFormatInfo nfi =
                    new System.Globalization.CultureInfo("en-US").NumberFormat;
                if (String.IsNullOrEmpty(par1.Trim()) || !System.IO.File.Exists(par1)) {
                    par1 = Resource1.gear; 
                    lines = par1.Split('\n'); 
                } else {
                    lines = System.IO.File.ReadAllLines(par1);
                }
                #region parse and load vertices
                // predefine array (for performance)
                ILArray<float> vertexData = new ILArray<float>(6, (int)(lines.Length / 2.0));
                int count = 0;
                float NX = 0, NY = 0, NZ = 0;
                foreach (string line in lines) {
                    int start = line.IndexOf("vertex");
                    if (start >= 0) {
                        // vertex found
                        start += 6;
                        string[] valsS = line.Substring(start).Trim().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                        if (valsS != null && valsS.Length >= 3) {
                            float X, Y, Z;
                            // vertex is valid (may be..) 
                            X = float.Parse(valsS[0], nfi);
                            Y = float.Parse(valsS[1], nfi);
                            Z = float.Parse(valsS[2], nfi);
                            // store for later 
                            vertexData.SetValue(X, 0, count);
                            vertexData.SetValue(Y, 1, count);
                            vertexData.SetValue(Z, 2, count);
                            vertexData.SetValue(NX, 3, count);
                            vertexData.SetValue(NY, 4, count);
                            vertexData.SetValue(NZ, 5, count);
                            count++;
                        }
                    } else {
                        start = line.IndexOf("normal");
                        if (start >= 0) {
                            // normal entry found
                            start += 6;
                            string[] valsN = line.Substring(start).Trim().Split(' ');
                            if (valsN != null && valsN.Length == 3) {
                                // normal is valid, cache it
                                NX = float.Parse(valsN[0], nfi);
                                NY = float.Parse(valsN[1], nfi);
                                NZ = float.Parse(valsN[2], nfi);
                            }
                        }
                    }
                }
                // truncate temp array, remove trail not needed 
                vertexData = vertexData[":;0:" + (count - 1)];
                #endregion

                #region create + configure composite shape
                ILLitTriangles ret = new ILLitTriangles(
                        panel  // panel hosting the scene
                        , vertexData["0;:"] // X components
                        , vertexData["1;:"] // Y components 
                        , vertexData["2;:"]); // Z components
                ret.AutoNormals = false;
                for (int i = 0; i < ret.Vertices.Length; i++) {
                    ret.Vertices[i].Normal = new ILPoint3Df(
                                   vertexData.GetValue(3, i)
                                  , vertexData.GetValue(4, i)
                                  , vertexData.GetValue(5, i));
                    ret.Vertices[i].Color = Color.FromArgb(255, 100, 100, 100);
                    ret.Vertices[i].Alpha = 255;
                }
                #endregion
                return ret;
            }
    
        }

    }
}
