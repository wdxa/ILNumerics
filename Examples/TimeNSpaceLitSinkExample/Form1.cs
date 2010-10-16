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
using ILNumerics.Drawing.Plots;
using ILNumerics.Drawing.Misc; 

namespace TimeNSpaceTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ILPanel m_panel; 
        ILLitSink m_sink; 
        private void Form1_Load(object sender, EventArgs e) {
            m_panel = ILPanel.Create();
            Controls.Add(m_panel);
            m_sink = new SinkExtBoxes(m_panel,20,300); 
            // add the plot directly to the panel
            m_panel.Graphs.AddPlot(m_sink);
            // tune the update interval
            m_sink.Interval = 0;

            // ILLitSink implements IILPanelConfigurator. 
            // Therefore most settings of ILPanel are configured 
            // by the plot, but it is still possible to override them here
            m_panel.Lights[0].Position = new ILPoint3Df(40, -10, 50.5);
            m_panel.Lights[1].Position = new ILPoint3Df(00, -00, -50.5);
            m_panel.Lights[1].Diffuse = Color.Black;
            m_panel.Lights[1].Ambient = Color.FromArgb(55,10,0); 
            m_panel.Lights[1].Enabled = true; 
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, (int)(Screen.PrimaryScreen.Bounds.Width / 3.7931034482758620689655172413793)); 
            m_panel.DefaultView.SetDeg(-10,30,20);
            m_panel.Projection = Projection.Perspective; 

        }
    }
}
