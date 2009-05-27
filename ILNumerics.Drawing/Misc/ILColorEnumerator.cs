using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ILNumerics.Drawing.Misc;  

namespace ILNumerics.Drawing.Misc {
    /// <summary>
    /// enumerate colors 
    /// </summary>
    public class ILColorEnumerator {

        List<Color> m_colors;
        int m_curPos; 

        /// <summary>
        /// create new color enumeration based on a specific colormap
        /// </summary>
        /// <param name="basemap"></param>
        public ILColorEnumerator(Colormaps basemap) {
            ILColormap cm = new ILColormap(basemap);
            m_colors = new List<Color>(); 
            for (int i = 0; i < cm.Length; i++) {
                m_colors.Add(cm.Map(i)); 
            }
            m_curPos = 0; 
        }
        /// <summary>
        /// create new color enumerator based on Colormap.Lines
        /// </summary>
        public ILColorEnumerator () : this (Colormaps.Lines) { }

        /// <summary>
        /// return next color and increase internal pointer
        /// </summary>
        /// <returns></returns>
        public Color NextColor() {
            Color ret = m_colors[m_curPos++]; 
            if (m_curPos == m_colors.Count) 
                m_curPos = 0;
            return ret; 
        }
    }
}
