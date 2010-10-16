using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Algorithms;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Marker; 


namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            ILFigure fig = new ILFigure(); 
            ILPanel panel = fig.ActiveSubfigure.Panel; 
            ILPlot2DGraph[] graphs = panel.Graphs.AddPlot2DGraph(ILSpecialData.sincos1D(30,1.0)); 
            graphs[0].Marker.Shape = @"\yvalue";
            (graphs[0].Marker.Shape as ILTexMarkerShape).ValueFormat = "g2";
            (graphs[0].Marker.Shape as ILTexMarkerShape).MaxLabelsDrawn = 15;
            graphs[1].Marker.Shape = MarkerStyle.Diamond; 
            graphs[1].Marker.Size = 4;
            graphs[1].Marker.Color = Color.Red; 
        }
    }
}