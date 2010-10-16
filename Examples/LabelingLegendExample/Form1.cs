using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Graphs; 


namespace WindowsApplication5 {
    public partial class Form1 : Form {
        ILPanel m_panel; 
        
        public Form1() {
            InitializeComponent();
            m_panel = ILPanel.Create(); 
            this.Controls.Add(m_panel); 
        }

        private void Form1_Load(object sender, EventArgs e) {
            ILArray<double> B = ILNumerics.Algorithms.ILSpecialData.sinc(40,50); 
            ILSurfaceGraph surfg = m_panel.Graphs.AddSurfGraph(B);
            surfg.Wireframe.Style = LineStyle.PointDash; 
            surfg.Wireframe.Color = Color.Cornsilk; 
            surfg.Wireframe.Visible = false; 
            surfg.Opacity = 0.4f; 
            surfg.Label.Text = @"B\bfu\fontsize{+3}b\color{red}b\resetle";
            surfg.Label.Padding = 30; 
            m_panel.Axes.XAxis.Label.Text = @"\Omega ist \color{red} schön."; 
            m_panel.Projection = Projection.Orthographic; 
            m_panel.Legend.Visible = true; 
            //m_panel.Legend.BackgroundColor = Color.Wheat; 
            //m_panel.Legend.Border.Style = LineStyle.Dotted; 
        }
    }
}