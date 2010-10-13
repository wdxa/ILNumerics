#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Internal; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Misc; 
using ILNumerics.Drawing.Labeling; 
using ILNumerics.Drawing.Interfaces; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// graph for drawings into ILPanel
    /// </summary>
    /// <remarks>Use the ILGraphCollection returned from ILPanel.Graphs and its Add... functions to create new graphs.</remarks>
    public abstract class ILGraph : IDisposable {

        #region events 
        
        public event ILGraphChangedEvent Changed; 
        protected virtual void OnChanged(string source) {
            if (Changed != null) 
                Changed(this, new ILGraphChangedEventArgs(source));
        }

        #endregion

        #region members / properties
        protected bool m_isReady; 
        protected ILClippingData m_localClipping; 
        protected ILClippingData m_globalClipping; 
        protected GraphType m_graphType; 
        protected ILPanel m_panel; 
        protected ILLabel m_label; 

        /// <summary>
        ///  the label of the graph (readonly)
        /// </summary>
        public ILLabel Label {
            get { 
                return m_label; 
            }
        }
        /// <summary>
        /// data limits of the graphs current data (readonly)
        /// </summary>
        public ILClippingData Limits {
            get { 
                return m_localClipping;
            }
            internal set {
                m_localClipping = value; 
            }
        }
        /// <summary>
        /// The type of graph (Plot2D, Surf, ImageSC, ...)
        /// </summary>
        public GraphType Type {
            get {
                return m_graphType; 
            }
        }
        /// <summary>
        /// The hosting panel
        /// </summary>
        public ILPanel Panel {
            get {
                return m_panel; 
            }
        }
        #endregion

        #region constructors
        
        internal ILGraph(ILPanel panel, ILClippingData clippingContainer) {
            m_panel = panel; 
            m_localClipping = new ILClippingData();
            m_localClipping.Changed += new ILClippingDataChangedEvent(m_localClipping_Changed);
            m_globalClipping = clippingContainer;
            m_globalClipping.Changed += new ILClippingDataChangedEvent(m_globalClipping_Changed);
            // store incoming data arrays as ILArray<float>
            //m_sourceArray = sourceArray.CreateReference();
            m_label = new ILLabel(m_panel);
            m_label.Color = Color.Black; 
            m_label.Changed += new EventHandler(m_label_Changed);
            m_isReady = false;
        }


        #endregion 

        #region event handler 
        
        protected virtual void m_localClipping_Changed(object sender, ClippingChangedEventArgs e) {
            // override this event in derived class, if neccessary
        }
        protected virtual void m_globalClipping_Changed(object sender, ClippingChangedEventArgs e) {
            // override this event in derived class, if neccessary
        }
        protected virtual void m_label_Changed(object sender, EventArgs e) {
            // override this event in derived class, if neccessary
        }

        #endregion

        #region abstract / interface member
        /// <summary>
        /// configures all parameters + cache, called before drawing
        /// </summary>
        public abstract void Configure();
        /// <summary>
        /// invalidate and recalculate this graphs data, this must be called after changes to relevant graph properties
        /// </summary>
        public virtual void Invalidate() {
            m_isReady = false; 
        }
        /// <summary>
        /// draws the graph into the panel
        /// </summary>
        /// <param name="p">extended drawing properties</param>
        public abstract void Draw(ILRenderProperties p); 
        /// <summary>
        /// clear ressources of the graph
        /// </summary>
        public virtual void Dispose() {
            m_globalClipping.Changed -= new ILClippingDataChangedEvent(m_globalClipping_Changed); 
            if (m_label != null) {
                m_label.Changed -= m_label_Changed; 
                m_label.Dispose(); 
            }
        }
        /// <summary>
        /// determine general type of graph (2D/3D) 
        /// </summary>
        /// <returns>true for 3D graphs (f.e. surf, scene graph) and false for 2D graphs (plot2D)</returns>
        public abstract bool Is3DGraph();

        #endregion

    }
}
