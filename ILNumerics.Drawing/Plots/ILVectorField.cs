using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Graphs;
using ILNumerics.Drawing.Shapes;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Misc;
using ILNumerics.Exceptions;
using ILNumerics.Drawing.Interfaces;
using ILNumerics.Drawing.Collections; 

namespace ILNumerics.Drawing.Plots {
    /// <summary>
    /// Class used to visualize a vector field in 2D
    /// </summary>
    public class ILVectorField : ILSceneGraphInnerNode, IILPanelConfigurator {

        #region attributes
        ILLines m_lines;
        double m_beta = 5 * Math.PI / 180;
        double m_scaling = 0.9;
        ILBaseArray m_data;
        ICollection<string> m_xLabels;
        ICollection<string> m_yLabels;
        #endregion

        #region properties
        private ILColormap m_colormap;
        /// <summary>
        /// get reference to data of all vectors or alter data (restricted to same size)
        /// </summary>
        public ILBaseArray Data {
            get {
                return m_data.CreateReference();
            }
            set {
                if (value != null && value.Dimensions.IsSameSize(m_data.Dimensions)) {
                    m_data = value.CreateReference();
                    Invalidate(); 
                }
            }
        }

        /// <summary>
        /// get the colormap used for coloring the arrows or sets it
        /// </summary>
        public ILColormap Colormap {
            get { return m_colormap; }
            set {
                m_colormap = value;
                Invalidate();
            }
        }
        /// <summary>
        /// opening angle for the arrow heads, default: 5 deg
        /// </summary>
        public double ArrowHeadAngle {
            get { return m_beta; }
            set {
                m_beta = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Scaling of arrow length, 1.0: full size; default: 0.9
        /// </summary>
        public double ArrowScale {
            get { return m_scaling; }
            set {
                m_scaling = value;
                Invalidate();
            }
        }

        /// <summary>
        /// enables access to the lines composite shape used for rendering
        /// </summary>
        public ILLines LinesShape {
            get {
                return m_lines; 
            }
        }

        /// <summary>
        /// collection of label texts for x axis
        /// </summary>
        public ICollection<string> XLabels {
            get { return m_xLabels; }
            set { 
                m_xLabels = value;
                Invalidate();
            }
        }

        /// <summary>
        /// collection of label texts for y axis
        /// </summary>
        public ICollection<string> YLabels {
            get { return m_yLabels; }
            set { 
                m_yLabels = value;
                Invalidate();
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// create new vector field scene graph plot
        /// </summary>
        /// <param name="panel">panel hosting the scene</param>
        /// <param name="data">3d data array: :;:;0 - X coords of vectors, :;:;1 - Y coords</param>
        /// <param name="colormap">Colormap used for coloring, on Null: Colormaps.ILNumerics is used as default</param>
        /// <param name="XLabels">labels for X axis, on Null: auto labeling</param>
        /// <param name="YLabels">labels for Y axis, on Null: auto labeling</param>
        public ILVectorField(ILPanel panel, ILBaseArray data
            , ILColormap colormap, ICollection<string> XLabels
            , ICollection<string> YLabels ) 
        : base (panel) {
            if (data == null || data.Dimensions[2] != 2 || data.IsEmpty) {
                throw new ILArgumentException("Invalid parameter: data");
            }
            m_data = data;
            m_xLabels = XLabels;
            m_yLabels = YLabels; 
            m_colormap = colormap;
            m_lines = new ILLines(m_panel,data.Dimensions[0]*data.Dimensions[1]*4);
            m_lines.Shading = ShadingStyles.Interpolate;
            m_lines.Properties.Width = 2;
            m_lines.Properties.Antialiasing = true;
            m_lines.Label.Text = "";
            ArrowHeadAngle = 10 * Math.PI / 180; 
            Invalidate(); 
            Add(m_lines);
        }
        #endregion

        #region public interface
        public override void Invalidate() {
            base.Invalidate();
            m_invalidated = true;
        }
        public override void Configure() {
            if (m_invalidated) {
                ILArray<double> indices;
                ILArray<double> vertices = Computation.CreateVertices(
                    m_data, out indices, m_beta, m_scaling / 2, m_colormap);
                m_lines.Update(vertices["0;:"], vertices["1;:"], vertices["2;:"]
                        , vertices["3:5;:"].T, indices);
                // configure axes
                configureAxis(AxisNames.XAxis, XLabels);
                configureAxis(AxisNames.YAxis, YLabels);
            }
            base.Configure();

        }
        #endregion

        #region IILPanelConfigurator Members

        public void ConfigurePanel(ILPanel panel) {
            panel.DefaultView = new ILCamera(0, 0, -10);
        }

        #endregion

        #region private helper
        private void configureAxis(AxisNames axis
                                    , ICollection<string> values) {
            ILTickCollection labels = m_panel.Axes[axis].LabeledTicks;
            if (values != null) {
                labels.Mode = TickMode.Manual;
                labels.Clear();
                int pos = 1;
                int axisIdx = (axis == AxisNames.XAxis) ?
                    1 : (axis == AxisNames.YAxis) ?
                    0 : 1; 
                foreach (string labelString in values) {
                    if (pos > m_data.Dimensions[axisIdx])
                        break;
                    labels.Add(pos++, labelString); 
                }
            } else {
                labels.Mode = TickMode.Auto; 
            }
        }
        #endregion

        #region computation
        private class Computation : ILNumerics.BuiltInFunctions.ILMath {

            public static ILArray<double> CreateVertices(ILBaseArray dataInput 
                                            ,out ILArray<double> indices
                                            ,double beta, double scaling
                                            , ILColormap colormap) {
                // each arrow needs 4 vertices (indexed rendering)
                ILArray<double> data = todouble(dataInput);
                int numRows = data.Dimensions[0];
                int numCols = data.Dimensions[1];
                ILArray<double> ret = new ILArray<double>(4, numCols * numRows, 2);
                // prepare indices
                indices = repmat(new ILArray<double>(new double[] { 0, 2, 1, 2, 3, 2 }, 6, 1), 1, numCols * numRows);
                indices = indices + repmat(counter(0.0, 4.0, 1, numCols * numRows), 6, 1);
                indices = indices.Reshape(2, numRows * numCols * 3);
                // normalize incoming data to length 1.0 
                ILArray<double> l = sqrt(sum(data * data, 2));
                double maxL = (double)max(maxall(l),MachineParameterDouble.eps);
                l = (l / maxL)[":"].T * scaling;
                ILArray<double> alpha = atan2(data[":;:;1"], data[":;:;0"]);
                alpha = alpha[":"].T;
                ILArray<double> x = data[":;:;0"][":"].T * scaling;
                ILArray<double> y = data[":;:;1"][":"].T * scaling;
                ILArray<double> xO = repmat(linspace(1, numCols, numCols), numRows, 1)[":"].T;
                ILArray<double> yO = repmat(linspace(numRows, 1, numRows).T, 1, numCols)[":"].T;
                ret["0;:;0"] = xO - x;
                ret["1;:;0"] = xO + x - l / 2 * cos(alpha + beta);
                ret["2;:;0"] = xO + x;
                ret["3;:;0"] = xO + x - l / 2 * cos(alpha - beta);

                ret["0;:;1"] = yO - y;
                ret["1;:;1"] = yO + y - l / 2 * sin(alpha + beta);
                ret["2;:;1"] = yO + y;
                ret["3;:;1"] = yO + y - l / 2 * sin(alpha - beta);

                ret["0;0;2"] = 0.0;
                // prepare colors 
                ret[":;:;3:5"] = todouble(
                    repmat(colormap.Map
                            (tosingle(l) * colormap.Length).Reshape(1, l.Length, 3) * 255, 4, 1, 1));
                return ret.Reshape(4 * numRows * numCols, 6).T;
            }

            internal static ILArray<double> CreateTestData(int numRows, int numCols) {
                ILArray<double> Y = repmat(linspace(0, pi * 2, numCols), numRows, 1);
                ILArray<double> X = cos(Y);
                X[":;:;1"] = sin(Y);
                // scale vector length
                X = X * repmat(0.6 + sin(Y) * 0.4, 1, 1, 2);
                return X;
            }
        }
        #endregion

    }
}
