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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Labeling;  
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Collections {
    /// <summary>
    /// List of labeled ticks for an axis
    /// </summary>
    public class ILTickCollection : ILLabelingElement, 
                                    IDisposable, 
                                    IEnumerable<LabeledTick> {

        #region events 
        /// <summary>
        /// Fires, when the collection of ticks has changed 
        /// </summary>
        public new event AxisChangedEventHandler Changed;
        /// <summary>
        /// fires, if a new labeled tick is about to be added to the collection
        /// </summary>
        public event LabeledTickAddingHandler LabeledTickAdding; 
        #endregion

        #region event handler 
        /// <summary>
        /// fires the change event
        /// </summary>
        protected void OnChange() {
            if (Changed != null)
                Changed(this,new ILAxisChangedEventArgs(m_axisName));
        }
        /// <summary>
        /// fires LabeledTickAdding event
        /// </summary>
        /// <param name="value">existing value</param>
        /// <param name="label">existing label</param>
        /// <param name="index">index of new tick in collection</param>
        /// <returns>true: a registrar requested to cancel the adding, false otherwise</returns>
        protected bool OnLabeledTickAdding(ref float value, ref string label, int index) {
            if (LabeledTickAdding != null) {
                ILLabeledTickAddingArgs args = new ILLabeledTickAddingArgs(value,label,index); 
                LabeledTickAdding(this,args); 
                label = args.Expression; 
                value = args.Value; 
                return args.Cancel; 
            }
            return false; 
        }
        #endregion

        #region attributes
        private int m_ticksAllowOverlap = 10; 
        private List<LabeledTick> m_ticks; 
        private TickDisplay m_tickDisplay; 
        private AxisNames m_axisName;
        private TickDirection m_tickDirection;
        private byte m_precision; 
        private int m_padding; 
        private Color m_tickColorNear; 
        private Color m_tickColorFar; 
        private TickMode m_tickMode; 
        private float m_tickFraction; 
        //internal properties 
        internal Point m_lineStart; 
        internal Point m_lineEnd;
        private TickLabelRenderingHint m_renderingHint; 
        private ILPanel m_panel; 
        #endregion

        #region properties
        /// <summary>
        /// determine the max number of pixels allowing a tic labels to be rendered inside the padding area of the next label 
        /// </summary>
        public int TicksAllowOverlap {
            get { return m_ticksAllowOverlap; }
            set { m_ticksAllowOverlap = value; }
        }

        /// <summary>
        /// Get the prefered placement for tick labels or sets it
        /// </summary>
        /// <remarks>Tick labels will not stricly rely on this setting, but rather 
        /// try to find the optimal tick positions depending on the current 
        /// rendering situation, taking the hint into account.</remarks>
        public TickLabelRenderingHint RenderingHint {
            get {
                return m_renderingHint; 
            } 
            set {
                m_renderingHint = value; 
                OnChange();
            }
        }
        
        /// <summary>
        /// Positioning mode for ticks ([Auto],Manual)
        /// </summary>
        public TickMode Mode {
            get {
                return m_tickMode; 
            }
            set {
                m_tickMode = value; 
                OnChange(); 
            }
        }

        /// <summary>
        /// get / set the color for near ticks (label side)
        /// </summary>
        public Color NearColor {
            get {
                return m_tickColorNear; 
            }
            set {
                m_tickColorNear = value; 
                OnChange(); 
            }
        }

        /// <summary>
        /// get / set the color for backside ticks
        /// </summary>
        public Color FarColor {
            get {
                return m_tickColorFar; 
            }
            set {
                m_tickColorFar = value; 
                OnChange(); 
            }
        }

        /// <summary>
        ///  Get/ set the default color for tick labels 
        /// </summary>
        /// <remarks>The color may be overwritten for individual labels</remarks>
        public Color LabelColor {
            get {
                return m_color; 
            }
            set {
                m_color = value; 
                OnChange(); 
            }
        }

        /// <summary>
        /// padding between ticks
        /// </summary>
        public int Padding {
            get {
                return m_padding; 
            }
            set {
                m_padding = value; 
                OnChange();
            }
        }

        /// <summary>
        /// number of digits to be displayed in axis ticks
        /// </summary>
        public byte Precision {
            get {
                return m_precision; 
            }
            set {
                if (value < 16 && value > 0)
                    m_precision = value;
                else 
                    throw new ILNumerics.Exceptions.ILArgumentException("precision must be in range 1..15!"); 
                // caching: since tick labels will be redrawn every
                // render frame, we do not invalidate the label's queues here
                OnChange(); 
            }
        }

        /// <summary>
        /// Get/ set which sides ticks for axis will be displayed on
        /// </summary>
        public TickDisplay Display {
            get {
                return m_tickDisplay; 
            }
            set {
                m_tickDisplay = value;
                OnChange();
            }
        }

        /// <summary>
        /// How ticks are displayed (inside/outside)
        /// </summary>
        public TickDirection Direction {
            get {
                return m_tickDirection; 
            }
            set {
                m_tickDirection = value; 
                OnChange();
            }
        }

        /// <summary>
        /// length for ticks, fraction of the overall axis length. Default: 0.02
        /// </summary>
        public float TickFraction {
            get {
                return m_tickFraction; 
            }
            set {
                m_tickFraction = value; 
                OnChange(); 
            }
        }
        
        /// <summary>
        /// Number of ticks currently stored into the collection
        /// </summary>
        public int Count {
            get {
                return m_ticks.Count; 
            }
        }

        /// <summary>
        /// The axis this tick collection is assigned to
        /// </summary>
        public ILAxis Axis {
            get {
                return m_panel.Axes[m_axisName]; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// creates new ILTickCollection
        /// </summary>
        /// <param name="axisName"></param>
        public ILTickCollection (ILPanel panel, AxisNames axisName) 
            : base(panel,new Font(FontFamily.GenericMonospace, 10.0f),Color.Black) {
            m_panel = panel; 
            m_ticks = new List<LabeledTick>(); 
            m_axisName = axisName; 
            m_precision = 4;
            m_padding = 5; 
            m_tickColorFar = Color.Black; 
            m_tickColorNear = Color.Black; 
            m_tickDisplay = TickDisplay.LabelSide; 
            m_tickMode = TickMode.Auto; 
            m_tickFraction = 0.015f; 
            m_renderingHint = TickLabelRenderingHint.Auto; 
        }
        #endregion

        #region public methods
        /// <summary>
        /// Clear the collection of labeled ticks
        /// </summary>
        public void Clear() {
            m_ticks.Clear(); 
            m_size = Size.Empty; 
        }

        /// <summary>
        /// replace current collection of labeled ticks with a new one
        /// </summary>
        /// <param name="ticks"></param>
        /// <remarks>This will fire a Change event.</remarks>
        public void Replace (List<float> ticks) {
            Clear(); 
            Size tmpSize = Size.Empty; 
            foreach (float tick in ticks) {
                Add(tick); 
            }
            OnChange(); 
        }
        /// <summary>
        /// Add a labeled tick to the ticks collection.
        /// </summary>
        /// <param name="value">current position</param>
        /// <param name="label">current value</param>
        /// <remarks>This function will fire the LabeledTickAdding event. This 
        /// gives users the chance to modify the tick and/or the label before 
        /// it gets added. She can also cancel the adding for the tick at all. <br/>
        /// No Change event for the axis will be fired from this method.</remarks>
        public void Add(float value, string label) {
            if (OnLabeledTickAdding(ref value, ref label, m_ticks.Count)) {
                return; 
            }
            ILRenderQueue queue = m_interpreter.Transform(label,
                                  m_font,m_color,m_renderer); 
            m_ticks.Add(new LabeledTick(value,queue)); 
            if (m_size.Height < queue.Size.Height)
                m_size.Height = queue.Size.Height; 
            if (m_size.Width < queue.Size.Width) 
                m_size.Width = queue.Size.Width; 
            //m_tickMode = TickMode.Manual; 
        }
        /// <summary>
        /// Add a labeled tick to the ticks collection
        /// </summary>
        /// <param name="value">position for tick</param>
        /// <remarks>No Change event will be fired</remarks>
        public void Add(float value) {
            this.Add(value,value.ToString("g"+m_precision)); 
        }
        /// <summary>
        /// Get maximum size of 
        /// all tick labels in pixels on screen
        /// </summary>
        /// <remarks>This property does not take the orientation into account. The size 
        /// of the content will be returned as if the orientation was straight horizontally.</remarks>
        public override Size Size {
            get {
               // if (m_tickMode == TickMode.Auto && m_ticks.Count == 0) {
               //     // first time: no labels have been added? -> assume maximum 
               //     // size determined by precision
               //     Graphics g = Graphics.FromImage(new Bitmap(1,1));
               //     string measString = String.Format(".-e08" + new String('0',m_precision)); 
               //     m_size = g.MeasureString(measString,m_font).ToSize(); 
               //}
               return m_size; 
            }
        }
        /// <summary>
        /// (Re-)measures the maximum size for all labels contained in the collection
        /// </summary>
        /// <param name="gr">graphics object, _may_ be used to measure texts (on some platforms)</param>
        /// <returns>maximum size</returns>
        /// <remarks>This function recomputes the true size for all labels and updates the internal cache. The cached value can 
        /// than queried by the property 'ScreenSize'.
        /// <para>Note: if no tick labels have been stored into the collection yet, the 
        /// maximum size possible for a label is returned. Therefore, the Precision member is 
        /// taken into account.</para></remarks>
        //public Size MeasureMaxScreenSize(Graphics gr) {
        //    if (m_ticks.Count == 0) {
        //        SizeF sf = gr.MeasureString (
        //            "-e.08" + new String('0', m_precision),m_font);
        //        m_screenSize = new Size((int)sf.Width,(int)sf.Height); 
        //    } else {
        //        m_screenSize = new Size(); 
        //        Size tmp; 
        //        foreach (LabeledTick tick in this) {
        //            tmp = tick.Queue.Size; 
        //            if (tmp.Height > m_screenSize.Height) 
        //                m_screenSize.Height = tmp.Height; 
        //            if (tmp.Width > m_screenSize.Width) 
        //                m_screenSize.Width = tmp.Width; 
        //        }
        //    }
        //    return m_screenSize;
        //}
        /// <summary>
        /// fill (replace) labels with nice labels for range  
        /// </summary>
        /// <param name="min">lower limit</param>
        /// <param name="max">upper limit</param>
        /// <param name="tickCount">maximum number of ticks</param>
        public void CreateAuto(float min, float max, int tickCount) {
            float dist = max - min;
            tickCount = 50;
            string format = String.Format("g{0}",m_precision); 
            // find the range for values we are dealing with.
            // ( 'ex' is the power of 10, which should be varied )
            double ex; 
            // how many ticks will (really) fit on the label line? 
            if (tickCount > 1) {
                Replace(NiceLabels(min,max,tickCount,m_renderingHint)); 
                if (Count > 0) 
                    return; 
                // else: no ticks could be found at all -> fallback: show only center
                tickCount = 1; 
            } 
            Clear();
            float relevExp = (float)Math.Round(Math.Log10((max - min)));
            if (!float.IsNaN(relevExp) && !float.IsInfinity(relevExp)) { 
                float multRound; 
                if (relevExp < 1) {
                    multRound = (float) (1 / Math.Pow(10,relevExp-1)); 
                } else {
                    multRound = (float) Math.Pow(10,relevExp-1);
                }
                if (tickCount <= 1) {
                    // If tickCount is 1, only the middle of Axis will be drawn.
                    float ls = (float)(Math.Ceiling((max + min) / 2 / multRound) * multRound);
                    if (ls != 0) 
                        Add(ls,ls.ToString(format));
                    else 
                        Add(min,min.ToString(format));
                } else if (tickCount == 3) {
                    // draw max, min and the approx. center of range
                    Add(min,min.ToString(format));
                    Add(max,max.ToString(format));
                    float ls = (float)(Math.Round((max + min) / 2 / multRound) * multRound);  
                    Add(ls,ls.ToString(format)); 
                } else { //if (tickCount == 2) {
                    // If tickCount is less than 3 - only the max and the min will be drawn. 
                    Add(min,min.ToString(format));
                    Add(max,max.ToString(format));
                }
            } else {
                Add(max,max.ToString(format));
            }
        }

        /// <summary>
        /// Determine nice looking label positions for range specified
        /// </summary>
        /// <param name="min">lower limit</param>
        /// <param name="max">upper limit</param>
        /// <param name="numMaxLabels">maximum number of labels </param>
        /// <param name="format">format string used to convert numbers to strings</param>
        /// <param name="hint">rendering hint, specifies preferred method</param>
        /// <returns>list of tick labels</returns>
        public static List<float> NiceLabels(float min, float max, int numMaxLabels, TickLabelRenderingHint hint) {
            List<float> ret; 
            switch (hint) {
                case TickLabelRenderingHint.Filled:
                    ret = NiceLabelsFill(min,max,numMaxLabels); 
                    break;
                case TickLabelRenderingHint.Multiple1:
                    ret = NiceLabelsEven(min,max,numMaxLabels,1.0f);
                    break;
                case TickLabelRenderingHint.Multiple2:
                    ret = NiceLabelsEven(min,max,numMaxLabels,2.0f);
                    break;
                case TickLabelRenderingHint.Multiple5:
                    ret = NiceLabelsEven(min,max,numMaxLabels,5.0f);
                    break;
                default:
                    //ret = NiceLabelsAuto(min,max,numMaxLabels,format);
                    ret = loose_label(min,max,numMaxLabels);
                    break; 
            }
            return ret; 
        }

        public void Draw(ILRenderProperties p, float min, float max) {
            m_renderer.Begin(p); 
            float clipRange = max - min; 
            
            ILPoint3Df mult = new ILPoint3Df(
                        ((float)(m_lineEnd.X - m_lineStart.X) / clipRange),
                        ((float)(m_lineEnd.Y - m_lineStart.Y) / clipRange),
                        0);
            float tmp;
            Point point = new Point(0,0); 
            Point oldMidPoint = new Point(int.MinValue,int.MinValue); 
            Point newMidPoint = new Point(int.MinValue,int.MinValue);
            Point oldHSize = new Point(), newHSize = new Point(); 
            foreach (LabeledTick lt in m_ticks) {
                if (lt.Queue.Count > 0
                    && lt.Position >= min 
                    && lt.Position <= max) {
                    tmp = lt.Position-min; 
                    point.X = (int)(m_lineStart.X + mult.X * tmp);
                    point.Y = (int)(m_lineStart.Y + mult.Y * tmp);
                    offsetAlignment(lt.Queue.Size, ref point); 
                    newHSize.X = (int)(lt.Queue.Size.Width / 2.0f); 
                    newHSize.Y = (int)(lt.Queue.Size.Height / 2.0f);
                    newMidPoint.X = point.X + newHSize.X; 
                    newMidPoint.Y = point.Y + newHSize.Y; 
                    // check distance to last drawn label for tickmode auto (padding)
                    if (m_tickMode == TickMode.Auto) {
                        if (oldMidPoint.X != int.MinValue 
                            && oldMidPoint.Y != int.MinValue) {

                            float distX = Math.Abs(newMidPoint.X - oldMidPoint.X);
                            float distY = Math.Abs(newMidPoint.Y - oldMidPoint.Y);
                            if (distX < (m_padding + oldHSize.X + newHSize.X) - m_ticksAllowOverlap &&
                                distY < (m_padding + oldHSize.Y + newHSize.Y) - m_ticksAllowOverlap) {
                                //m_ticks.Remove(lt); 
                                continue;
                            }
                        } 
                        // bookmark outer rendering limits 
                        if (newMidPoint.X - newHSize.X < p.MinX)
                            p.MinX = newMidPoint.X - newHSize.X;
                        if (newMidPoint.Y - newHSize.Y < p.MinY)
                            p.MinY = newMidPoint.Y - newHSize.Y;
                        if (newMidPoint.X + newHSize.X > p.MaxX)
                            p.MaxX = newMidPoint.X + newHSize.X;
                        if (newMidPoint.Y + newHSize.Y > p.MaxY)
                            p.MaxY = newMidPoint.Y + newHSize.Y;
                    }
                    m_renderer.Draw(lt.Queue, point, m_orientation, m_color);
                    oldMidPoint = newMidPoint;
                    oldHSize = newHSize;
                }
            } 
            m_renderer.End(p); 
        }
        #endregion

        #region IDisposable Member
        public new void Dispose() {
            if (m_renderer != null) { 
                // ???
            }
        }
        #endregion

        #region private helper

        /// <summary>
        /// Create nice labels, prefere even numbers over best optimal tick count
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <param name="numMaxLabels">max labels count</param>
        /// <param name="format">format string used to convert numbers to strings</param>
        /// <returns>nice label list</returns>
        private static List<float> NiceLabelsAuto(float min, float max, int numMaxLabels, string format) {
            float[] divisors = new float[3] {5.0f, 2.0f, 1.0f}; 
            List<float>[] ticks = new List<float>[divisors.Length]; 
            int count = 0, bestMatch = int.MaxValue, tmp = 0, bestMatchIdx = -1; 
            foreach (float div in divisors) {
                ticks[count] = NiceLabelsEven(min,max,numMaxLabels,div);  
                if (ticks[count].Count == numMaxLabels) {
                    return ticks[count]; 
                } 
                tmp = (int)Math.Abs(Math.Min(numMaxLabels,10) - ticks[count].Count); 
                if (tmp < bestMatch) {
                    bestMatch = tmp; 
                    bestMatchIdx = count; 
                }
                count ++; 
            }
            // its possible for limits to exceed the resolution for float 
            // no ticks are returned in this case 
            return ticks[bestMatchIdx]; 
        }
        /// <summary>
        /// find tick labels by distinct divisors (10,5,2). Chooses the divisor which best produces the best number according to numberTicks
        /// </summary>
        /// <param name="min">minimum</param>
        /// <param name="max">maximum</param>
        /// <param name="numberTicks">maximum number of ticks</param>
        /// <param name="format">format string for string conversion</param>
        /// <returns>list of tick labels</returns>
        private static List<float> NiceLabelsFill(float min, float max, int numberTicks) {
            // spacing may happen by divisors of 5,2,1. We test every case and choose the 
            // one producing the best match on the number of ticks requested than. 
            float[] divisors = new float[3] {5.0f, 2.0f, 1.0f}; 
            List<float>[] ticks = new List<float>[divisors.Length]; 
            int count = 0, bestMatch = int.MaxValue, tmp = 0, bestMatchIdx = -1; 
            foreach (float div in divisors) {
                ticks[count] = NiceLabelsEven(min,max,numberTicks,div);  
                tmp = (int)Math.Abs(Math.Min(numberTicks,10) - ticks[count].Count); 
                if (ticks[count].Count == numberTicks) {
                    return ticks[count]; 
                } else if (tmp <= bestMatch) {
                    bestMatch = tmp; 
                    bestMatchIdx = count; 
                }
                count ++; 
            }
            System.Diagnostics.Debug.Assert(bestMatchIdx >= 0,"No best divisor has been found. Tick creation failed.");
            if (bestMatchIdx >= 0)
                return ticks[bestMatchIdx]; 
            else 
                return ticks[0];  // rescue plan
        }
        private static List<float> NiceLabelsEven(float min, float max, int numberTicks, float divisor) {
            //minimal distance required for ticks
            float minDist = (max - min) / (numberTicks + 1); 
            // determine prominent range for optimal spacing
            if (Math.Abs(minDist) < 1e-10) return new List<float>(); 
            float relevExp = (float)Math.Log10((max - min));
            if (float.IsNaN(relevExp)) {
                return new List<float>();    
            }
            float multRound; 
            if (relevExp >= 1) {
                return NiceLabelsEvenGE10(min,max,numberTicks,divisor); 
            }
            List<float> ticks = new List<float>(); 
            relevExp = (float)Math.Round(relevExp);
            multRound = (float) (1 / Math.Pow(10,relevExp-1)); 
            //float step = divisor / multRound, cur = min, origStep = step;
            float step = multRound/ divisor, cur = min, origStep = step; 
            // TODO: check for step beeing too small for resonable min..max distance! 
            // OR: prevent for infinite loop!
            while (step < minDist) {
                step += origStep; 
            }
            // find the first auto tick value, matching the divisor
            cur = (float)(Math.Round((min + minDist) * multRound / divisor) / multRound * divisor); 
            ticks.Add(cur); 
            cur += step; 
            // add all ticks in _between_, keep margin to axis limits!
            while (cur < max) {
                cur = (float)(Math.Round(cur * multRound) / multRound); 
                ticks.Add(cur);
                cur += step;
                if (ticks.Count > numberTicks) {
                    // emergency break - float cannot handle this distance!
                    ticks.Clear(); 
                    break; 
                }
            }
            return ticks; 
        }
        private static List<float> NiceLabelsEvenGE10(float min, float max, int numberTicks, float divisor) {
            //minimal distance required for ticks
            float minDist = (max - min) / (numberTicks + 1); 
            // determine prominent range for optimal spacing
            List<float> ticks = new List<float>(); 
            // has been checked, if comming from NiceLabelsEven: 
            //if (Math.Abs(minDist) < 1e-10) return ticks; 
            float relevExp = (float)Math.Log10((max - min));
            if (float.IsNaN(relevExp)) {
                return ticks;    
            }
            float multRound; 
            relevExp = (float) (Math.Sign(relevExp) * Math.Floor(Math.Abs(relevExp)));
            multRound = (float) Math.Pow(10,relevExp-1);
            //float step = divisor / multRound, cur = min, origStep = step;
            float step = multRound/ divisor, cur = min, origStep = step; 
            // TODO: check for step beeing too small for resonable min..max distance! 
            // OR: prevent for infinite loop!
            while (step < minDist) {
                // increase the multRRound by factor 10 
                relevExp ++; 
                multRound = (float) (Math.Pow(10,relevExp-1));
                step = multRound/ divisor; 
            }
            // find the first auto tick value, matching the divisor
            cur = (float)niceNumber(min,false); 
            ticks.Add(cur); 
            // add all ticks in _between_, keep margin to axis limits!
            while (cur < max) {
                cur = (float)niceNumber(cur + step,false); 
                ticks.Add(cur);
                if (ticks.Count > numberTicks) {
                    // emergency break - float cannot handle this distance!
                    ticks.Clear(); 
                    break; 
                }
            }
            return ticks; 
        }

        /// <summary>
        /// create "nice" number in fractions of 2 or 5
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>This code was adopted from Paul Heckbert
        /// from "Graphics Gems", Academic Press, 1990. </returns>
        private static double niceNumber(double val, bool round) {
            int expv; 
            double f;                                /* fractional part of x */
            double nf;                               /* nice, rounded fraction */
            double aval = Math.Abs(val); 
            double sign = Math.Sign(val); 

            expv = (int)Math.Floor(Math.Log10(aval));
            f = aval/Math.Pow(10, expv);                /* between 1 and 10 */
            if (round) {
                if (f<1.5) nf = 1;
                else if (f<3) nf = 2;
                else if (f<7) nf = 5;
                else nf = 10;
            } else {
                if (f<=1) nf = 1;
                else if (f<=2) nf = 2;
                else if (f<=5) nf = 5;
                else nf = 10;
            }
            return (nf * Math.Pow(10, expv) * sign);
        }
        private static List<float> loose_label(float min,float max, int numberTicks) {
            double d;                                /* tick mark spacing */
            double graphmin, graphmax;                /* graph range min and max */
            double range, x;

            /* we expect min!=max */
            range = niceNumber(max-min, false);
            d = niceNumber(range/(Math.Min(numberTicks,10)-1), true);
            double exp = Math.Pow(10,Math.Floor(Math.Log10(max - min)));
            graphmin = Math.Floor(min / exp) * exp;  

                // Math.Min(niceNumber(min - d,true),niceNumber(min - d,false));
            //graphmax = Math.Min(niceNumber(max - d, true), niceNumber(max + d, false));
            List<float> ticks = new List<float>();  
            //ticks.Add(nfrac);
            for (x = graphmin; x <= max; x = (float)(Math.Round((x + d) / d) * d)) {
                //x = (float)(Math.Round(x/d)*d); 
                ticks.Add((float)x);
                if (ticks.Count > 20) break; //emergency exit if range is in floating point range
            }
            return ticks;
        }

        #region Oli's labels implementaion (incomplete)
        private static List<float> niceLabels (float start, float end, int maxNumbers,string format) {
            float[] labelPositions = berechneLabel(start,end,maxNumbers);
            List<float> ret = new List<float>(); 
            foreach (float pos in labelPositions) {
                ret.Add(pos);     
            }
            return ret; 
        }
        private static float[] berechneLabel(float start, float end, int maxNumbers)
        {
            if (end <= start)
                return null;
            float strecke = Math.Abs(end - start);
            maxNumbers++;//Überprüfen!
            int n = 0;
            while (strecke < maxNumbers)
            {
                strecke *= 10;
                n++;                
            }
            while (strecke > 100)
            {
                strecke /= 10;
                n--;
            }
            start *= (float)Math.Pow(10, n);
            int streckeIntValue = getStreckeAsNiceInt(strecke, maxNumbers);
            /*
            if (isPrimzahl(streckeIntValue) && streckeIntValue != maxNumbers)
            {          
                streckeIntValue++; //Kann zu Problemen führen! -- ist aber auch Mist.
            }
            */

            float step = 0;
            int stepCount;
            for (stepCount = maxNumbers; stepCount > 0; stepCount--)
            {
                step = streckeIntValue / stepCount;
                int rest = streckeIntValue % stepCount;
                if(rest < step && (step == 1 || step == 2 || step == 5 || step == 10 || step == 25 || step == 50 ))
                        break;
            }         
            int startInt = (int)Math.Round(start, 0);
            startInt = startInt - (startInt % (int)step);
            if (n != 0)
            {
                step /= (float)(Math.Pow(10, n));
                start = (float)startInt / (float)Math.Pow(10, n);
            }
            else
                start = startInt;
            if (!(start + stepCount * step < end))
                stepCount--;
            float[] ret = new float[stepCount];
            for (int i = 1; i <= stepCount; i++)
            {
                ret[i - 1] = start + i * step;
            }
            return ret;
        }
        private static int getStreckeAsNiceInt(float strecke, int maxNumbers)
        {
            int streckeIntValue = (int)Math.Round(strecke, 0);
            if (streckeIntValue <= 10)
                return streckeIntValue;
            if (streckeIntValue / 2 <= maxNumbers)
                return streckeIntValue;

            streckeIntValue = streckeIntValue - streckeIntValue % 5;
            return streckeIntValue;
        }
        #endregion

        #endregion

        #region IEnumerable<LabeledTick> Member
        /// <summary>
        /// Get Enumerator, enumerating over all labeled ticks
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<LabeledTick> GetEnumerator() {
            return m_ticks.GetEnumerator(); 
        }

        #endregion

        #region IEnumerable Member

        /// <summary>
        /// Get enumerator enumerating over labeled ticks
        /// </summary>
        /// <returns>enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            foreach (LabeledTick lt in m_ticks)
                yield return lt; 
        }

        #endregion

    }
}
