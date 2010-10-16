using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILNumerics; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Algorithms; 

namespace WindowsApplication4 {
    public partial class Form1 : Form {
        
        private ILPanel m_panel; 
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            m_panel = ILPanel.Create(); 
            Controls.Add(m_panel); 

            ILArray<double> B = ILSpecialData.sinc(40,50) + 1;  
            ILSurfaceGraph sgr = m_panel.Graphs.AddSurfGraph(B); 
            ILImageSCGraph igr = m_panel.Graphs.AddImageSCGraph(B); 

            igr.ZPosition = float.NegativeInfinity; 
            sgr.Opacity = 0.8f; 
            sgr.Wireframe.Visible = false; 
            sgr.Shading = ShadingStyles.Interpolate; 
            m_panel.Axes.XAxis.Label.Text = "\\Omega, a \\bfgreek \\resetLetter"; 
        }
    }
}