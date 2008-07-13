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
using ILNumerics.Drawing.Graphs;

namespace ILNumerics.Drawing {

    /// <summary>
    /// tick provider function delegate definition
    /// </summary>
    /// <param name="min">minimum axis limit</param>
    /// <param name="max">maximum axis limit</param>
    /// <param name="maxCount">maximum number of ticks to create</param>
    /// <returns>list of tick position to be drawn</returns>
    /// <remarks>User defined tick providers must fulfill this delegates signature. 
    /// </remarks>
    public delegate List<float> ILLabeledTickProvider (float min, float max, int maxCount);  

    /// <summary>
    /// occours if the clipping data for an subfigure have changed
    /// </summary>
    /// <param name="sender">object which changed the data</param>
    /// <param name="e">arguments containing the new clipping data</param>
    public delegate void ILClippingDataChangedEvent (object sender, ClippingChangedEventArgs e); 
    
    /// <summary>
    /// delegate used to measure text, device dependent
    /// </summary>
    /// <param name="text">text to be measured</param>
    /// <param name="font">Font used for rendering</param>
    /// <returns>Size in screen coords</returns>
    public delegate Size MeasureTextDelegate(string text, Font font); 

    /// <summary>
    /// arguments on ClippinChangedEvents
    /// </summary>
    public class ClippingChangedEventArgs : EventArgs {
        /// <summary>
        /// creates a new ClippingChangedEventArgs object
        /// </summary>
        /// <param name="clippingData"></param>
        public ClippingChangedEventArgs(ILClippingData clippingData) {
            ClippingData = clippingData; 
        }
        /// <summary>
        /// the current (new) clipping data
        /// </summary>
        public ILClippingData ClippingData;
    }
    /// <summary>
    /// occours if a graphics device has been reset by the underlying graphics framework
    /// </summary>
    /// <param name="sender">objects who hosts the graphics device</param>
    /// <param name="eventArgs"></param>
    public delegate void ILGraphicsDeviceResetEvent(object sender, EventArgs eventArgs); 
    /// <summary>
    /// occours if a graphics device has been (re)created by an output panel
    /// </summary>
    /// <param name="sender">objects who hosts the graphics device</param>
    /// <param name="eventArgs"></param>
    public delegate void ILGraphicsDeviceCreatedEvent(object sender, EventArgs eventArgs); 
    /// <summary>
    /// arguements for ILGraphCollectionChanged events
    /// </summary>
    public class ILGraphCollectionChangedEventArgs: EventArgs {
        public readonly GraphCollectionChangeReason Reason; 
        public readonly ILGraph Graph; 
        public ILGraphCollectionChangedEventArgs (ILGraph graph, GraphCollectionChangeReason reason) {
            this.Graph = graph; 
            this.Reason = reason; 
        }
    }
    /// <summary>
    /// occurs on changes to the graph collection: add, delete
    /// </summary>
    /// <param name="sender">graph collection</param>
    /// <param name="args"></param>
    public delegate void ILGraphCollectionChangedEvent(object sender, ILGraphCollectionChangedEventArgs args);  

    /// <summary>
    /// Event handler handling LabeledTickAdding events 
    /// </summary>
    public class ILLabeledTickAddingArgs : EventArgs {
        public bool Cancel; 
        public float Value; 
        public string Expression; 
        public int Index; 

        public ILLabeledTickAddingArgs (float value, string expression, int index) {
            Value = value; 
            Expression = expression; 
            Cancel = false; 
            Index = index; 
        }
    }
    /// <summary>
    /// Delegate definition for function handling LabeledTickAdding events
    /// </summary>
    /// <param name="sender">the sender of the event (f.e. ILTickCollection)</param>
    /// <param name="args">arguments </param>
    public delegate void LabeledTickAddingHandler (object sender, ILLabeledTickAddingArgs args); 

    /// <summary>
    /// Event arguments for axis changed events
    /// </summary>
    public class ILAxisChangedEventArgs : EventArgs {
        /// <summary>
        /// Name of changed axis (X-,Y-,ZAxis)
        /// </summary>
        public AxisNames AxisName;
        /// <summary>
        /// construct a new instance 
        /// </summary>
        /// <param name="name"></param>
        public ILAxisChangedEventArgs (AxisNames name) {
            AxisName = name; 
        }
    }
    /// <summary>
    /// delegate for functions handling AxisChanged events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void AxisChangedEventHandler (object sender, ILAxisChangedEventArgs args); 

}
