using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Interfaces {
    interface IILPanelConfigurator {
        /// <summary>
        /// Implemented by custom graph objects, configures the panel according to requirements of specific plot type
        /// </summary>
        /// <param name="panel">the panel to be configured</param>
        void ConfigurePanel(ILPanel panel); 
    }
}
