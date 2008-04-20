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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Exceptions; 
using System.Drawing; 

namespace ILNumerics.Drawing.Collections {
    /// <summary>
    /// List of labeled ticks for an axis
    /// </summary>
    public class ILTickCollection : List<LabeledTick>,IDisposable {

        #region events 
        /// <summary>
        /// Fires, when the collection of ticks has changed 
        /// </summary>
        public event AxisChangedEventHandler Changed;
        #endregion

        #region event handler 
        private void OnChange() {
            if (Changed != null)
                Changed(this,new ILAxisChangedEventArgs(m_axisName));
        }
        #endregion

        #region members / attributes
        private TickDisplay m_tickDisplay; 
        private AxisNames m_axisName;
        private TickDirection m_tickDirection;
        private byte m_precision; 
        private Size m_tickLabelScreenSize; 
        private int m_padding; 
        private Color m_tickLabelColor; 
        private Color m_tickColorNear; 
        private Color m_tickColorFar; 
        private TickMode m_tickMode; 
        private float m_tickFraction; 
        private IILTextRenderer m_textRenderer; 
        private Font m_font; 
        //internal properties 
        internal Point m_lineStart; 
        internal Point m_lineEnd;
        internal TickLabelAlign m_align; 
        private Size m_screenSize; 
        private TickLabelRenderingHint m_renderingHint; 

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
        /// get the alignment for tick labels, determined automatically, readonly
        /// </summary>
        public TickLabelAlign Alignment {
            get {
                return m_align; 
            }
        }
        
        /// <summary>
        /// Gets the font used for drawing the tick labels or sets it
        /// </summary>
        public Font Font {
            get{
                return m_font; 
            }
            set {
                m_font = value; 
                m_textRenderer.Font = value;
                OnChange(); 
            }
        }

        /// <summary>
        /// Positioning mode for ticks
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
        ///  Get/ set the color for tick labels 
        /// </summary>
        public Color LabelColor {
            get {
                return m_tickLabelColor; 
            }
            set {
                m_tickLabelColor = value; 
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
                m_tickLabelScreenSize = Size.Empty; 
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
        /// Renderer type used to transform / render labels to panel
        /// </summary>
        public IILTextRenderer TextRenderer {
            get {
                return m_textRenderer; 
            }
            set {
                if (value == null) 
                    throw new ILArgumentException("TextRenderer must not be null!"); 
                if (m_textRenderer != null) 
                    m_textRenderer.Free(); 
                m_textRenderer = value; 
                m_textRenderer.Font = Font;
                OnChange(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// creates new ILTickCollection
        /// </summary>
        /// <param name="axisName"></param>
        public ILTickCollection (AxisNames axisName) : base() {
            m_axisName = axisName; 
            m_precision = 6;
            m_padding = 4; 
            m_tickLabelColor = Color.Black; 
            m_tickColorFar = Color.Black; 
            m_tickColorNear = Color.Black; 
            m_tickDisplay = TickDisplay.LabelSide; 
            m_tickMode = TickMode.Auto; 
            m_tickFraction = 0.02f; 
            m_font = new Font(FontFamily.GenericMonospace, 10.0f);
            m_renderingHint = TickLabelRenderingHint.Auto; 
        }
        #endregion

        #region public methods
        /// <summary>
        /// replace current collection of labeled ticks with a new one
        /// </summary>
        /// <param name="ticks"></param>
        public void Replace (List<LabeledTick> ticks) {
            this.Clear(); 
            foreach (LabeledTick tick in ticks) 
                Add(tick);
            OnChange(); 
        }
        /// <summary>
        /// Add a value to the tick collection.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="label"></param>
        public void Add(float value, string label) {
            base.Add(new LabeledTick(value,label)); 
        }
        /// <summary>
        /// Get maximum size of 
        /// all tick labels in pixels on screen
        /// </summary>
        /// <remarks>This property returns a cached value only! -> Before querying 
        /// this property, MeasureMaxScreenSize() must have been called, or wrong values 
        /// may be returned!</remarks>
        public Size ScreenSize {
            get {
                return m_screenSize; 
            }
        }
        /// <summary>
        /// (Re-)measures the maximum size for all labels contained in the collection
        /// </summary>
        /// <param name="gr">graphics object, _may_ be used to measure texts (on some platforms)</param>
        /// <returns>maximum size</returns>
        /// <remarks>This function recomputes the true size for all labels and updates the internal cache. The cached value can 
        /// than queried by the property 'ScreenSize'.</remarks>
        public Size MeasureMaxScreenSize(Graphics gr) {
            m_screenSize = m_textRenderer.MeasureText(
                    "-e.08" + new String('0', m_precision),gr);
            //m_screenSize = new Size(); 
            //Size tmp; 
            //foreach (LabeledTick tick in this) {
            //    tmp = m_textRenderer.MeasureText(tick.Label,gr);
            //    if (tmp.Height > m_screenSize.Height) 
            //        m_screenSize.Height = tmp.Height; 
            //    if (tmp.Width > m_screenSize.Width) 
            //        m_screenSize.Width = tmp.Width; 
            //}
            return m_screenSize;
        }
        /// <summary>
        /// fill (replace) labels with nice labels for range  
        /// </summary>
        /// <param name="min">lower limit</param>
        /// <param name="max">upper limit</param>
        /// <param name="tickCount">maximum number of ticks</param>
        public void CreateAuto(float min, float max, int tickCount) {
            float dist = max - min;
            string format = String.Format("g{0}",m_precision); 
            // find the range for values we are dealing with.
            // ( 'ex' is the power of 10, which should be varied )
            double ex; 
            // how many ticks will (really) fit on the label line? 
            if (tickCount > 3) {
                Replace(NiceLabels(min,max,tickCount,format,m_renderingHint)); 
                if (Count > 0) 
                    return; 
                // else: no ticks could be found -> rescue plan: show only middle
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
                        Add(new LabeledTick(ls,ls.ToString(format)));
                    else 
                        Add(new LabeledTick(min,min.ToString(format)));
                } else if (tickCount == 3) {
                    // draw max, min and the approx. center of range
                    Add(new LabeledTick(min,min.ToString(format)));
                    Add(new LabeledTick(max,max.ToString(format)));
                    float ls = (float)(Math.Round((max + min) / 2 / multRound) * multRound);  
                    Add(new LabeledTick(ls,ls.ToString(format))); 
                } else { //if (tickCount == 2) {
                    // If tickCount is less than 3 - only the max and the min will be drawn. 
                    Add(new LabeledTick(min,min.ToString(format)));
                    Add(new LabeledTick(max,max.ToString(format)));
                }
            } else {
                Add(new LabeledTick(max,max.ToString(format)));
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
        public static List<LabeledTick> NiceLabels(float min, float max, int numMaxLabels, string format, TickLabelRenderingHint hint) {
            List<LabeledTick> ret; 
            switch (hint) {
                case TickLabelRenderingHint.Filled:
                    ret = NiceLabelsFill(min,max,numMaxLabels,format); 
                    break;
                case TickLabelRenderingHint.Multiple1:
                    ret = NiceLabelsEven(min,max,numMaxLabels,format,1.0f);
                    break;
                case TickLabelRenderingHint.Multiple2:
                    ret = NiceLabelsEven(min,max,numMaxLabels,format,2.0f);
                    break;
                case TickLabelRenderingHint.Multiple5:
                    ret = NiceLabelsEven(min,max,numMaxLabels,format,5.0f);
                    break;
                default:
                    //ret = NiceLabelsAuto(min,max,numMaxLabels,format);
                    ret = loose_label(min,max,numMaxLabels,format);
                    break; 
            }
            return ret; 
        }

        #endregion

        #region IDisposable Member
        public void Dispose() {
            if (m_textRenderer != null) 
                m_textRenderer.Free(); 
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
        private static List<LabeledTick> NiceLabelsAuto(float min, float max, int numMaxLabels, string format) {
            float[] divisors = new float[3] {5.0f, 2.0f, 1.0f}; 
            List<LabeledTick>[] ticks = new List<LabeledTick>[divisors.Length]; 
            int count = 0, bestMatch = int.MaxValue, tmp = 0, bestMatchIdx = -1; 
            foreach (float div in divisors) {
                ticks[count] = NiceLabelsEven(min,max,numMaxLabels,format,div);  
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
        private static List<LabeledTick> NiceLabelsFill(float min, float max, int numberTicks, string format) {
            // spacing may happen by divisors of 5,2,1. We test every case and choose the 
            // one producing the best match on the number of ticks requested than. 
            float[] divisors = new float[3] {5.0f, 2.0f, 1.0f}; 
            List<LabeledTick>[] ticks = new List<LabeledTick>[divisors.Length]; 
            int count = 0, bestMatch = int.MaxValue, tmp = 0, bestMatchIdx = -1; 
            foreach (float div in divisors) {
                ticks[count] = NiceLabelsEven(min,max,numberTicks,format,div);  
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
        private static List<LabeledTick> NiceLabelsEven(float min, float max, int numberTicks, string format, float divisor) {
            //minimal distance required for ticks
            float minDist = (max - min) / (numberTicks + 1); 
            // determine prominent range for optimal spacing
            if (Math.Abs(minDist) < 1e-10) return new List<LabeledTick>(); 
            float relevExp = (float)Math.Log10((max - min));
            if (float.IsNaN(relevExp)) {
                return new List<LabeledTick>();    
            }
            float multRound; 
            if (relevExp >= 1) {
                return NiceLabelsEvenGE10(min,max,numberTicks,format,divisor); 
            }
            List<LabeledTick> ticks = new List<LabeledTick>(); 
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
            ticks.Add(new LabeledTick(cur,cur.ToString(format))); 
            cur += step; 
            // add all ticks in _between_, keep margin to axis limits!
            while (cur < max) {
                cur = (float)(Math.Round(cur * multRound) / multRound); 
                ticks.Add(new LabeledTick(cur,cur.ToString(format)));
                cur += step;
                if (ticks.Count > numberTicks) {
                    // emergency break - float cannot handle this distance!
                    ticks.Clear(); 
                    break; 
                }
            }
            return ticks; 
        }
        private static List<LabeledTick> NiceLabelsEvenGE10(float min, float max, int numberTicks, string format, float divisor) {
            //minimal distance required for ticks
            float minDist = (max - min) / (numberTicks + 1); 
            // determine prominent range for optimal spacing
            List<LabeledTick> ticks = new List<LabeledTick>(); 
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
            ticks.Add(new LabeledTick(cur,cur.ToString(format))); 
            // add all ticks in _between_, keep margin to axis limits!
            while (cur < max) {
                cur = (float)niceNumber(cur + step,false); 
                ticks.Add(new LabeledTick(cur,cur.ToString(format)));
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
            double nf;                                /* nice, rounded fraction */

            expv = (int)Math.Floor(Math.Log10(val));
            f = val/Math.Pow(10, expv);                /* between 1 and 10 */
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
            return (nf* Math.Pow(10, expv));
        }
        private static List<LabeledTick> loose_label(float min,float max, int numberTicks, string format) {
            int nfrac;
            double d;                                /* tick mark spacing */
            double graphmin, graphmax;                /* graph range min and max */
            double range, x;

            /* we expect min!=max */
            range = niceNumber(max-min, false);
            d = niceNumber(range/(Math.Min(numberTicks,10)-1), true);
            graphmin = Math.Floor(min/d)*d;
            graphmax = Math.Ceiling(max/d)*d;
            nfrac = (int)Math.Max(-Math.Floor(Math.Log10(d)), 0);
            List<LabeledTick> ticks = new List<LabeledTick>(); 
            ticks.Add(new LabeledTick(nfrac,nfrac.ToString(format)));
            for (x=graphmin; x<graphmax+.5*d; x+=d) {
                ticks.Add(new LabeledTick((float)x,((float)x).ToString(format)));
            }
            return ticks;
        }



        #region Oli's labels implementaion (incomplete)
        private static List<LabeledTick> niceLabels (float start, float end, int maxNumbers,string format) {
            float[] labelPositions = berechneLabel(start,end,maxNumbers);
            List<LabeledTick> ret = new List<LabeledTick>(); 
            foreach (float pos in labelPositions) {
                ret.Add(new LabeledTick(pos,pos.ToString(format)));     
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

    }
}
