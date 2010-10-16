using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Shapes; 

namespace LightExampleSphereSpecular {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            Color Specular = Color.FromArgb(255, 255, 255);
            Color Ambient = Color.FromArgb(90, 90, 90);
            Color Diffuse = Color.FromArgb(160, 160, 160);

            label1.Text = String.Format(@"
Sphere:
===========
Specular: White
Color: White
Shininess: 96");
            label2.Text = String.Format(@"
Panel.Lights[0]:   
============
Ambient: {0}       
Diffuse: {1}              
Specular: {2}", Ambient, "s.b.", Specular);

            this.Size = new Size(450, 300); 
            //byte[] values = new byte[] {5,20,100}; 
            Color[] colors = new Color[3] { Color.LightGray, Color.Black, Color.Blue }; 
            for (int i = 0; i < 3; i++) {
                ILPanel panel = ILPanel.Create();
                tableLayoutPanel1.Controls.Add(panel, i, 1);
                panel.Dock = DockStyle.Fill;
                //panel.Lights[0].Diffuse = colors[i]; 
                ILSceneGraph scene = panel.Graphs.AddSceneGraph();
                ILLitSphere sphere = new ILLitSphere(panel, new ILPoint3Df(), 1f, Color.Green,3);
                sphere.Label.Text = "";
                sphere.Label.Anchor = new PointF(1, 0); 
//                sphere.Material.Specular = Color.White;
//                sphere.Material.Shininess = 96;
                sphere.Label.Text = String.Format(@"\itLight.Diffuse:
{0}", colors[i]);
                sphere.Label.Orientation = TextOrientation.Vertical; 
                scene.AddNode(sphere);
                //panel.Axes.XAxis.Label.
                panel.BackgroundFilled = false;
                panel.AspectRatio = AspectRatioMode.MaintainRatios;
                panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.StrictOptimal; 
                
            }

        }

    }
}
