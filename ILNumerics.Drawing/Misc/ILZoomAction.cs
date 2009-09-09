using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace ILNumerics.Drawing.Misc {
    public class ILZoomAction : ILAction {
        
        ILPoint3Df m_MinCornerStart;
        ILPoint3Df m_MinCornerEnd; 
        ILPoint3Df m_MaxCornerStart; 
        ILPoint3Df m_MaxCornerEnd; 
        ILActionRamp m_ramp; 
        int m_currentStep; 
        ILClippingData m_target; 

        public ILZoomAction(ILPoint3Df MinCornerStart,
                            ILPoint3Df MinCornerEnd,
                            ILPoint3Df MaxCornerStart,
                            ILPoint3Df MaxCornerEnd, 
                            ILActionRamp ramp,
                            ILClippingData target) 
        : base () {
            m_MaxCornerEnd = ILPoint3Df.Max(MinCornerEnd,MaxCornerEnd);
            m_MaxCornerStart = ILPoint3Df.Max(MinCornerStart,MaxCornerStart); 
            m_MinCornerEnd = ILPoint3Df.Min(MinCornerEnd,MaxCornerEnd);
            m_MinCornerStart = ILPoint3Df.Min(MinCornerStart,MaxCornerStart);
            m_ramp = ramp; 
            m_target = target; 
        }

        protected override void RunInternal(object parameter) {
            float x1 = m_MinCornerStart.X;
            float y1 = m_MinCornerStart.Y;
            float z1 = m_MinCornerStart.Z;
            float x2 = m_MaxCornerStart.X;
            float y2 = m_MaxCornerStart.Y;
            float z2 = m_MaxCornerStart.Z;
            float aMinX = m_MinCornerEnd.X - x1;
            float aMinY = m_MinCornerEnd.Y - y1;
            float aMinZ = m_MinCornerEnd.Z - z1;
            float aMaxX = m_MaxCornerEnd.X - x2;
            float aMaxY = m_MaxCornerEnd.Y - y2;
            float aMaxZ = m_MaxCornerEnd.Z - z2;
            foreach (ILActionRampElement elem in m_ramp) {
                if (m_canceled) return; 
                ILPoint3Df min = new ILPoint3Df(
                            x1 + aMinX * elem.Value,
                            y1 + aMinY * elem.Value,
                            z1 + aMinZ * elem.Value);
                ILPoint3Df max = new ILPoint3Df(
                            x2 + aMaxX * elem.Value,
                            y2 + aMaxY * elem.Value,
                            z2 + aMaxZ * elem.Value); 
                m_target.Set(min,max); 
                if (m_canceled) return; 
                Thread.Sleep((int)(elem.Duration * 1000)); 
            }


        }
    }
}
