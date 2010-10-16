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
using ILNumerics.Drawing;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Plots; 


namespace ILBarGraph3DTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ILPanel m_panel; 
        private void Form1_Load(object sender, EventArgs e) {
            m_panel = ILPanel.Create();
            Controls.Add(m_panel);

            ILArray<double> data = ILMath.rand(5, 7); 
            ILBarGraph3D bars = new ILBarGraph3D(m_panel, data);
            m_panel.Graphs.AddPlot(bars);
            bars.SetLabels(m_panel, "X-Label", "Y-Label", "",
                    new string[] { "Column 1", "Column 2", "Column 3", "Column 4", "Column 5", "Column 6", "Column 7" },
                    new string[] { "Row 1", "Row 2", "Row 3", "Row 4", "Row 5"});
            m_panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.StrictOptimal;
            m_panel.AspectRatio = AspectRatioMode.StretchToFill; 
        }
    }
}
