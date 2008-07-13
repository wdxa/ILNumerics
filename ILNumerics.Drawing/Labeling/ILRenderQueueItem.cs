using System;
using System.Drawing; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Single item with rendering instructions, used in ILRenderQueues
    /// </summary>
    public class ILRenderQueueItem { 
        /// <summary>
        /// unique key, identifies the item in the render cache
        /// </summary>
        public string Key; 
        /// <summary>
        /// rendering offset for the item (used for sub-/superscripts etc.)
        /// </summary>
        public Point Offset; 
        /// <summary>
        /// individual color for the item 
        /// </summary>
        /// <remarks>If this property is set to Color.Empty, the item will 
        /// be drawn with the color assigned to hosting element.</remarks>
        public Color Color; 

        /// <summary>
        /// construct a new ILRenderQueueItem
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="xOffset">x coordinate for offset</param>
        /// <param name="yOffset">y coordinate for offset</param>
        /// <param name="color">individual color</param>
        public ILRenderQueueItem (string key, int xOffset, int yOffset, Color color) {
            Key = key; 
            Offset = new Point(xOffset,yOffset); 
            Color = color; 
        }
        /// <summary>
        /// construct a new ILRenderQueueItem
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="offset">offset</param>
        /// <param name="color">individual color</param>
        public ILRenderQueueItem (string key, Point offset, Color color) {
            Key = key; 
            Offset = offset;
            Color = color; 
        }
    }
}
