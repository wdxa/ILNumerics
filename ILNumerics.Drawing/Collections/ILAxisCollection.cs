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
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Internal;
using System.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.TextRenderer;
using System.Reflection;  


namespace ILNumerics.Drawing.Collections {
        
    /// <summary>
    /// Collection of all 3 axes contained in each subfigure
    /// </summary>
    public class ILAxisCollection {

        #region event + trigger
        public event AxisChangedEventHandler Changed; 
        internal void OnChanged(ILAxis sender, AxisNames axis) {
            if (Changed != null) 
                Changed(sender ,new ILAxisChangedEventArgs(axis));
        }
        #endregion

        #region  attributes / properties

        private ILAxis[] m_axes; 
        private Size m_maximumSize; 
        /// <summary>
        /// Get / set ILAxis by index
        /// </summary>
        /// <param name="index">index of axis: XAxis = 0, YAxis = 1, ZAxis = 2</param>
        /// <returns>ILAxis specified by index</returns>
        /// <value>new ILAxis to be stored into the collection</value>
        public ILAxis this[int index] {
            get {
                if (index < 0 || index > 2) 
                    throw new ILArgumentException("ILAxisCollection: axis index out of bounds!");
                return m_axes[index]; 
            } 
            set {
                if (index < 0 || index > 2) 
                    throw new ILArgumentException("ILAxisCollection: axis index out of bounds!");
                m_axes [index] = value; 
                Invalidate(); 
            }
        }
        /// <summary>
        /// Get / set ILAxis by name enum
        /// </summary>
        /// <param name="name">one of the enum values: XAxis, YAxis, ZAxis</param>
        /// <returns>ILAxis specified by name</returns>
        /// <value>new ILAxis to be stored into the collection</value>
        public ILAxis this[AxisNames name] {
            get {
                switch (name) {
                    case AxisNames.XAxis:
                        return m_axes[0];
                        break;
                    case AxisNames.YAxis:
                        return m_axes[1];
                        break;
                    default:
                        return m_axes[2];
                        break;
                }
            } 
            set {
                m_axes [(int)name] = value; 
                Invalidate(); 
            }
        }
        /// <summary>
        /// Get access to the X-axis
        /// </summary>
        public ILAxis XAxis {
            get {
                return m_axes[0]; 
            }
        }
        /// <summary>
        /// Get access to the Y-axis
        /// </summary>
        public ILAxis YAxis {
            get {
                return m_axes[1]; 
            }
        }
        /// <summary>
        /// Get access to the Z-axis
        /// </summary>
        public ILAxis ZAxis {
            get {
                return m_axes[2]; 
            }
        }
        /// <summary>
        /// Maximum size of all axes contained in the collection
        /// </summary>
        public Size MaxTicLabelSize {
            get {
                System.Diagnostics.Debug.Assert(m_maximumSize.Width >= 0); 
                return m_maximumSize; 
            }
        }
        /// <summary>
        /// Set visibility for all axes simultaneously
        /// </summary>
        public bool Visible {
            set {
                m_axes[0].Visible = value; 
                m_axes[1].Visible = value; 
                m_axes[2].Visible = value; 
            }
        }

        #endregion

        #region contructor
        /// <summary>
        /// create new ILAxisCollection
        /// </summary>
        public ILAxisCollection(ILClippingData clippingView, IILCreationFactory factory) {
            m_axes = new ILAxis[3];
            m_axes[0] = factory.CreateAxis(AxisNames.XAxis,clippingView); 
            m_axes[1] = factory.CreateAxis(AxisNames.YAxis,clippingView); 
            m_axes[2] = factory.CreateAxis(AxisNames.ZAxis,clippingView); 
            EventHandler handler = new EventHandler(Axis_Changed); 
            m_axes[0].Changed += handler;
            m_axes[1].Changed += handler;
            m_axes[2].Changed += handler;
        }
        #endregion

        #region public methods  
        public void Initialize()  {

        }
        public void Invalidate() {
            m_maximumSize = Size.Empty; 
            m_axes[0].Invalidate(); 
            m_axes[1].Invalidate(); 
            m_axes[2].Invalidate();
        }

        public void Dispose() {
            if (m_axes.Length > 0 && m_axes[0] != null)
                m_axes[0].Dispose(); 
            if (m_axes.Length > 1 && m_axes[1] != null)
                m_axes[1].Dispose(); 
            if (m_axes.Length > 2 && m_axes[2] != null)
                m_axes[2].Dispose();
        }
        #endregion

        #region helper
        protected void Axis_Changed(object sender, EventArgs e) {
            Invalidate();
            if (sender is ILAxis && sender != null) {
                ILAxis ax = (ILAxis)sender; 
                OnChanged(ax,(AxisNames)ax.Index); 
            }
        }
        internal Size MeasureMaxTickLabelSize(Graphics gr) {
            for (int i = 0; i < m_axes.Length; i++) {
                Size tmp = m_axes[i].LabeledTicks.MeasureMaxScreenSize(gr); 
                if (tmp.Height > m_maximumSize.Height) {
                    m_maximumSize.Height = tmp.Height; 
                }
                if (tmp.Width > m_maximumSize.Width) {
                    m_maximumSize.Width = tmp.Width; 
                }
            }
            return m_maximumSize;
        }
        #endregion
    }
}
