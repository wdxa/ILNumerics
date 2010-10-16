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

namespace ILVectorFieldTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ILPanel m_panel;
        ILVectorField2D m_vectorField;
        Timer m_timer = new Timer();
        float m_offset = 0; 
        private void Form1_Load(object sender, EventArgs e) {
            m_panel = ILPanel.Create();
            Controls.Add(m_panel);

            m_vectorField = new ILVectorField2D(m_panel,
                            ILVectorField2D.Computation.CreateTestData(10, 15, 0),
                            new ILNumerics.Drawing.Misc.ILColormap(Colormaps.ILNumerics),
                            null, null);
            m_panel.Graphs.AddPlot(m_vectorField);

            m_timer = new Timer();
            m_timer.Tick += new EventHandler(m_timer_Tick);
            m_timer.Interval = 100; 
            m_timer.Start(); 
        }

        void m_timer_Tick(object sender, EventArgs e) {
            m_offset += (float)(Math.PI / 100); 
            m_vectorField.Data = ILVectorField2D.Computation.CreateTestData(10, 15, m_offset);
            m_panel.Refresh();
        }
    }
}
