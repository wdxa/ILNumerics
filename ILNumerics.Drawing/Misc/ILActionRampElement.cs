using System;
using System.Collections.Generic;
using System.Text;

namespace ILNumerics.Drawing.Misc {
    public class ILActionRampElement {
        public float Value; 
        public float Duration;

        public ILActionRampElement(float value, float duration) {
            Value = value; 
            Duration = duration; 
        }
    }
}
