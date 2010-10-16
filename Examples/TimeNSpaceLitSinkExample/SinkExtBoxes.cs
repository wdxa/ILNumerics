using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILNumerics; 
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Plots; 
using ILNumerics.Drawing.Shapes; 
using ILNumerics.Drawing.Controls; 

namespace TimeNSpaceTest {
    public class SinkExtBoxes : ILLitSink {

        List<ILLitBox3D> m_boxes; 
        int m_nrBoxes = 10; 

        public SinkExtBoxes(ILPanel panel, float max, int resolution) 
            : base(panel, max, resolution) {
            createBoxes();
            
        }

        private void createBoxes() {

            ILNumerics.Drawing.Misc.ILColormap cm = new ILNumerics.Drawing.Misc.ILColormap(Colormaps.Hsv); 
            m_boxes = new List<ILLitBox3D>(); 
            float [] xPos = new float[] {12,12,12,13,13,13,14,14,14,15,15,15,16,16,16,17,17,17,17,18,18,18,18,19,19,19,20,20,20}; 
            float [] yPos = new float[] {28,29,30,28,29,30,28,29,30,28,29,30,28,29,30,28,29,30,31,28,29,30,31,29,30,31,29,30,31}; 
            float [] zVal = new float[] {0.02f,0.316f,0.523f,0.0223f,0.283f,0.471f,0.0074f,0.17f,0.409f,0.021f,0.3f,0.5f,0.0191f,0.187f,0.337f,0.02f,0.07f,0.52f,0.64f,0.06f,0.22f,0.3f,0.48f,0.17f,0.21f,0.63f,0.1f,0.17f,0.3f};
            byte [] tran = new byte[] {30,30,30,70,70,70,190,190,190};  
            for (int i = 0; i < xPos.Length; i++) {
                ILLitBox3D box; 
                ILPoint3Df min = new ILPoint3Df(
                        -m_max + xPos[i]+0.05 + 4 + m_linesPositionOffset, 
                        -m_max + yPos[i]+0.05 - 2 + m_linesPositionOffset, 
                        -zVal[i]); 
                ILPoint3Df max = new ILPoint3Df(
                        -m_max + xPos[i]+0.9 + 4 + m_linesPositionOffset, 
                        -m_max + yPos[i]+0.9 - 2 + m_linesPositionOffset, 
                        zVal[i]); 
                box = new ILLitBox3D(m_panel, min, max, cm.Map((double)zVal[i]*cm.Length), cm.Map((double)zVal[i]*cm.Length));
                box.TopLabel.Text = ""; 
                box.GradientColor = box.TopColor; 
                box.Edges.Color = Color.DarkGray;
                if (tran.Length > i) {
                    //box.Opacity = tran[i]; 
                }
                box.Quads[ILLitBox3D.QuadIndices.bottom].CustomCenter = new ILPoint3Df(0,0,3000);  
                box.Quads[ILLitBox3D.QuadIndices.top].CustomCenter = new ILPoint3Df(0,0,3000);  
                m_boxes.Add(box); 
                Add(box); 
            }
        }
    }
}
