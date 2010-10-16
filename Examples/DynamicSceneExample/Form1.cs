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
using ILNumerics.Drawing.Shapes; 

namespace DynamicScene {
    /**
     *  The example demonstrates dynamic updates of shapes in a scene graph. 
     *  
     *  The scene will consist out of a pendula weight, slowly moving 
     *  from left to right with slowly decreasing amplitude. 
     *  The weight is made ouf of 2 similar lit polygons for the bottom 
     *  and the top. The edges are made out of lit quads. 
     *  A scale persists in the back which is made out of simple lines. 
     *  The scene is frequently updated by a timer control. In the event
     *  handler, the pendula weights data are recalculated and the shapes 
     *  are updated. 
     *  Experiment with the ILPanel settings: AspectRatio, 
     **/
    
    // the main form 
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        // attributes: the panel and the shapes used.
        // since we reference the shapes on every update, 
        // it is easier to have them defined in class scope. 
        ILPanel m_panel; 
        ILLitPolygon m_poly1,m_poly2; 
        ILLitQuads m_quads; 
        ILLines m_lines; 
        Timer m_timer; 
        
        // in Form_Load the panel and all shapes should be created 
        // and initialized. 
        private void Form1_Load(object sender, EventArgs e) {
            // the ILPanel is created ... 
            m_panel = ILPanel.Create(); 
            // and added to the Controls collection of the form
            Controls.Add(m_panel); 
            // a scene graph will hold our shapes 
            ILSceneGraph scene = m_panel.Graphs.AddSceneGraph();
            
            // data for the shapes are best created in the Computation
            // helper - keeping the GUI code clean
            ILCell data = Computation.CreatePendulaWeight();
            // setup the first polygon. For creation we do 
            // not specify vertex data yet. This will be done 
            // later in the UpdateShapes function
            m_poly1 = new ILLitPolygon(m_panel, data[0].Dimensions[1]);
            m_poly1.Border.Width = 2; 
            m_poly1.Border.Color = Color.Gray; 
            m_poly1.Opacity = 180; 
            m_poly1.CustomCenter = new ILPoint3Df(0,0,1); 
            m_poly1.Label.Text = ""; 
            // and add it to the scene. We create an individual node 
            // for the weight' shapes.
            ILSceneGraphInnerNode weightNode = new ILSceneGraphInnerNode(m_panel); 
            scene.AddNode(weightNode); 
            weightNode.Add(m_poly1);

            // setup the 2nd polygon. The same size is here used as 
            // for the first polygon. 
            m_poly2 = new ILLitPolygon(m_panel, data[0].Dimensions[1]);
            m_poly2.Border.Width = 2; 
            m_poly2.Border.Color = Color.Gray; 
            m_poly2.Opacity = 180; 
            m_poly2.Label.Text = ""; 
            m_poly2.CustomCenter = new ILPoint3Df(0,0,1); 
            weightNode.Add(m_poly2); 

            // the same for the quads: only give the number 
            // of vertices needed. Data are updated later
            m_quads = new ILLitQuads(m_panel, data[0].Dimensions[1] * 2); 
            m_quads.FillColor = Color.Red;
            m_quads.Opacity = 180; 
            m_quads.Label.Text = ""; 
            m_quads.CustomCenter = new ILPoint3Df(0,0,1); 
            // add the quads to the scene
            weightNode.Add(m_quads); 

            // create the scale below the pendula weight
            ILCell lData = Computation.CreateScale(); 
            ILArray<double> vert = lData[0] as ILArray<double>; 
            ILArray<double> maps = lData[1] as ILArray<double>; 
            m_lines = new ILLines(m_panel, vert[0.0,null], vert[1.0,null], vert[2.0,null], maps);
            m_lines.Label.Text = ""; 
            m_lines.Properties.Color = Color.Black; 
            m_lines.Shading = ShadingStyles.Flat; 
            // the scale lines we put directly in the root node 
            // (no need to create an extra inner node for them)  
            scene.AddNode(m_lines); 
            
            // initialize the shapes
            UpdateShapes(data);
            
            // Experiment with these panel settings! They get clear than! 
            //m_panel.PlotBoxScreenSizeMode = PlotBoxScreenSizeMode.StrictOptimal; // default: Optimal 
            //m_panel.AutoZoomContent = false; // (default: true)  
            m_panel.AspectRatio = AspectRatioMode.MaintainRatios;
            //m_panel.Projection = Projection.Perspective; 
            m_panel.InteractiveMode = InteractiveModes.Rotating; 
            
            // setup the timer control
            m_timer = new Timer(); 
            m_timer.Interval = 40;
            m_timer.Tick += new EventHandler(m_timer_Tick);
            m_timer.Start(); 

        }
        // in the event handler, new data are created on every tick
        void m_timer_Tick(object sender, EventArgs e) {
            UpdateShapes(Computation.CreatePendulaWeight()); 
            // do not to forget to refresh the panel after all updates are done
            m_panel.Refresh(); 
        }
        
        // update the shapes with new data. Data are made by the helper class 
        // "Computation" and are provided as ILCell, holding the coords for the 
        // pendula weigth (one circle only) and the corresponding indices (mapping). 
        private void UpdateShapes(ILCell data) {
            // get the data out of the cell
            ILArray<double> circ = (ILArray<double>)data[0];
            ILArray<double> mapping = (ILArray<double>)data[1];
            // update the pendula weight edges (lit quads)
            // Data contains only one circle, since we need two, we concatenate
            // the array: x and y are simply doubled, z is added with 0.4 to 
            // create a volume. 
            m_quads.Update(circ[0.0, null].Concat(circ[0.0, null], 1),
                            circ[1.0, null].Concat(circ[1.0, null], 1),
                            circ[2.0, null].Concat(circ[2.0, null] + 0.4, 1),
            // mapping contains the indices referencing the vertices in circ
                            mapping);
            // the polygon updates are even easier: since ILPolygon is a simple (bordered) 
            // shape, no mappings are needed, we just pass the vertex data: 
            m_poly1.Update(circ[0.0, null], circ[1.0, null], circ[2.0, null]);
            m_poly2.Update(circ[0.0, null], circ[1.0, null], circ[2.0, null] + 0.4);

            // note, calling Update on any ILShape will at the same time invalidate the shape. 
            // this is important to signal the scene (panel) for the size of the scene and the 
            // position(s) of shape(s) may have changed. Latter is important for the order in which
            // shapes are drawn in case of transparent shapes. Since Update() already does this for us, 
            // we do not have to call [shape].Invalidate() manually. 
            // However, if we would use the low-level interface for scene updates and manipulate the
            // shapes vertices directly, we would need to call Invalidate() afterwards.
        }
        // a private computation class is very convenient in many sitatuations. It enables to 
        // keep the code clean and to derive from ILNumerics.BuiltInFunctions.ILMath. Therefore, all 
        // static functions of ILMath are directly be accessible, which gives nice short syntax on 
        // your algorithms:
        private class Computation : ILMath {
            // some tuning parameters. These of course may also be function parameters 
            static double pLength = 10, maxAlpha = pi / 4; 
            static int vLen = 200;
            
            // code to create vertex data for the scale lines 
            internal static ILCell CreateScale() {
                // the arcs angle limits, resolution: 60 steps
                ILArray<double> tmp = linspace(-pi/3, pi/3,60);
 
                // make x,y and z coords out of the angles
                ILArray<double> vert = vertcat(
                                            pLength * sin(tmp), 
                                            pLength * (1.0 - cos(tmp)), 
                                            zeros(1,tmp.Length)-0.2); 
                // add some more vertices for the ticks 
                vert = horzcat(vert, vert[":;0:2:end"] + vertcat(
                            sin(tmp[":;0:2:end"]) * .4,
                            -cos(tmp[":;0:2:end"]) * .4,
                            zeros(1,tmp.Length / 2)-0.1)); 
                // create mapping indices 
                ILArray<double> maps = counter(0.0,1.0,1,tmp.Length-2); 
                maps = 
                    horzcat(
                        // mappings for the long scale line and ..
                        vertcat(maps,
                                maps+1),
                        // .. mappings for the ticks are horizontaly concatenated
                        vertcat(counter(0.0,2.0,1,tmp.Length / 2),
                                counter(tmp.Length,1.0,1,tmp.Length / 2))); 
                // put everything into a ILCell and return
                return new ILCell(new ILBaseArray[] {vert, maps}, 1,2); 
            }
            // code to create the weight
            // Basically only a circle is created and corresponding indices for the quad mappings
            internal static ILCell CreatePendulaWeight() {

                // weigth midpoint 
                maxAlpha *= 0.999999; 
                double a1 = Math.Sin(DateTime.Now.TimeOfDay.TotalMilliseconds / 1000) * maxAlpha;
                double xPos = pLength * Math.Sin(a1); 
                double yPos = pLength * Math.Cos(a1); 


                // create circle for weight
                ILArray<double> alpha = linspace(0, 2*pi, vLen); 
                ILArray<double> coord = vertcat(
                                    cos(alpha) + xPos,
                                    pLength - sin(alpha) - yPos,
                                    zeros(1, vLen));

                // create mapping for weight edges (quads)
                ILArray<double> maps = counter(0.0,1.0,1,vLen-1); 
                maps = vertcat(maps,maps+1,maps+vLen+1,maps+vLen); 

                // wrap all arrays into an ILCell
                return new ILCell(new ILBaseArray[] {coord , maps},1,2); 
            }
        }
    }
}
