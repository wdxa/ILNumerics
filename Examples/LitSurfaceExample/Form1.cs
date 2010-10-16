using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Resources; 
using System.Reflection; 
using ILNumerics;
using ILNumerics.BuiltInFunctions;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Misc;
using ILNumerics.Misc;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Plots; 

namespace LitSurfaceTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ILPanel m_panel; 
        private void Form1_Load(object sender, EventArgs e) {
            m_panel = ILPanel.Create(); 
            Controls.Add(m_panel);

            ILLitSurface litSurf = new ILLitSurface(m_panel, Computation.CreateData(600,600)
                                    ,new ILColormap(Colormaps.ILNumerics));
            m_panel.Graphs.AddPlot(litSurf);
            m_panel.Lights[0].Position = new ILPoint3Df(150, 90,550);
            m_panel.AspectRatio = AspectRatioMode.MaintainRatios; 
            m_panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.Maximum; 
            m_panel.Axes.Visible = false; 
            
        }

        private class Computation : ILMath {
            public static ILArray<float> CreateData(int rX, int rY) {
                
                Bitmap heightmap = Resource1.saltlake;
                int x = Math.Min(heightmap.Size.Width,rX); 
                int y = Math.Min(heightmap.Size.Height,rY);
                ILArray<float> ret = new ILArray<float>(rX, rY); 
                for (int c = 0; c < x; c++) {
                    for (int r = 0; r < y; r++) {
                        Color val = heightmap.GetPixel(c,r);
                        ret.SetValue(val.GetBrightness(),r,c); 
                    }
                }
                float maxVal = (float)maxall(abs(ret)); 
                if (maxVal != 0)
                    ret /= maxVal; 
                ret *= 50; 
                return ret; // ["0:2:end;0:2:end"]; 
            }

        }
    }
}
