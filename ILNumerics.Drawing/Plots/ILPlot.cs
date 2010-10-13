using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Controls;
using ILNumerics.Drawing.Graphs; 

namespace ILNumerics.Drawing.Plots {
    /// <summary>
    /// (abstract) base class for all higher level plot objects
    /// </summary>
    public abstract class ILPlot : ILSceneGraphInnerNode {

        public ILPlot(ILPanel panel)
            : base(panel) {

        }
    }
}
