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
using ILNumerics.Drawing.Graphs; 
using ILNumerics.Drawing.Shapes;
using ILNumerics.Drawing.Plots; 

namespace BarGraph2DTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ILPanel m_panel;
        Timer m_timer;
        ILBarGraph2D m_bars;
        long m_lastTickCount; 

        private void Form1_Load(object sender, EventArgs e) {

            m_panel = ILPanel.Create(); 
            Controls.Add(m_panel); 
            
            ILArray<double> data = ILMath.randn(1,100);
            m_bars = new ILBarGraph2D(m_panel, data);
            m_bars.BarWidth = 0.001f;
            m_panel.Graphs.AddPlot(m_bars); 

            m_panel.Legend.Visible = true; 

            m_timer = new Timer();
            m_timer.Tick += new EventHandler(m_timer_Tick);
            m_timer.Interval = 100;
            m_timer.Start();
            m_lastTickCount = Environment.TickCount; 
        }
        static float s_lastDur; 
        void m_timer_Tick(object sender, EventArgs e) {
            m_bars.Queue((float)(Environment.TickCount - m_lastTickCount - s_lastDur));
            s_lastDur = Environment.TickCount - m_lastTickCount; 
            m_lastTickCount = Environment.TickCount; 

            m_panel.Refresh();  
        }
    }
}
