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
using ILNumerics.Drawing.Internal; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// graph for drawings into ILPanel - this is not intended for direct instantiating!
    /// </summary>
    /// <remarks>Use the ILGraphCollection returned from ILSubfigure.Graphs member and its Add function to create new graphs.</remarks>
    public abstract class ILGraph : IDisposable {

        #region events 
        
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) 
                Changed(this,new EventArgs());
        }

        #endregion

        #region members / properties
        protected bool m_isReady; 
        protected ILArray<float> m_sourceArray; 
        protected ILClippingData m_localClipping; 
        protected ILClippingData m_globalClipping; 
        protected GraphType m_graphType; 
        protected ILPanel m_panel; 

        /// <summary>
        ///  get a reference to the internal data array
        /// </summary>
        /// <remarks>modifications to the array returned will 
        /// <b>not</b> alter the data the graph is based on.</remarks>
        public ILBaseArray Data {
            get {
                return m_sourceArray.CreateReference(); 
            }
        }
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
        /// The containing panel
        /// </summary>
        public ILPanel Panel {
            get {
                return m_panel; 
            }
        }
        #endregion

        #region constructors
        
        internal ILGraph(ILPanel panel, ILBaseArray sourceArray, ILClippingData clippingContainer) {
            if (object.Equals(sourceArray,null))
                throw new ILArgumentException("CreateGraph: source array must not be null!");
            if (!sourceArray.IsNumeric) 
                throw new ILArgumentException("CreateGraph: source array must be numeric!");
            m_panel = panel; 
            m_localClipping = new ILClippingData();  
            m_globalClipping = clippingContainer;
            m_globalClipping.Changed += new ILClippingDataChangedEvent(m_globalClipping_Changed);
            // store incoming data arrays as ILArray<float>
            //m_sourceArray = sourceArray.CreateReference();
            m_sourceArray = BuiltInFunctions.ILMath.tosingle(sourceArray); 
            m_isReady = false;
        }

        #endregion 

        #region event handler 

        protected virtual void m_globalClipping_Changed(object sender, ClippingChangedEventArgs e) {
            // override this event in derived class, if neccessary
        }
        #endregion

        #region abstract / interface member

        protected abstract void Configure();
        public virtual void Invalidate() {
            m_isReady = false; 
        }
        public virtual void Draw() {
            if (!m_isReady)
                Configure(); 
        }
        public virtual void Dispose() {
            m_globalClipping.Changed -= new ILClippingDataChangedEvent(m_globalClipping_Changed); 
        }

        #endregion
    }
}
