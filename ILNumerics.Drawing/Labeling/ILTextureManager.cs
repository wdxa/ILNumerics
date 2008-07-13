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
using ILNumerics.Drawing.Platform.OpenGL; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    ///  manages multiple texture sheets for storage and rendering
    /// </summary>
    public class ILTextureManager {

        #region events
        /// <summary>
        /// Fires, when the managed texture sheets are cleared. Registrars must rebuild needed items afterwards
        /// </summary>
        public event EventHandler TextureCacheCleared; 
        #endregion

        #region attributes / properties
        protected int m_lastTextureSheet = -1; 
        private List<ILTextureStorage> m_textureSheets; 
        /// <summary>
        /// All texture sheets must conform to this graphics device
        /// </summary>
        /// <remarks>the graphics device type must be the same as 
        /// the one used by the panel!</remarks>
        public GraphicDeviceType DeviceType {
            get { return m_deviceType; }
            set { m_deviceType = value; }
        }
        private GraphicDeviceType m_deviceType;
        /// <summary>
        /// Default height for new texture sheets
        /// </summary>
        public int DefaultHeight {
            get { return m_defaultHeight; }
            set { m_defaultHeight = value; }
        } 
        private int m_defaultHeight;
        /// <summary>
        /// Default width for new texture sheets
        /// </summary>
        public int DefaultWidth {
            get { return m_defaultWidth; }
            set { m_defaultWidth = value; }
        } 
        private int m_defaultWidth;
        private static object m_lock = new object(); 
        #endregion 

        #region constructor
        internal ILTextureManager(GraphicDeviceType deviceType) {
            m_textureSheets = new List<ILTextureStorage>(); 
            m_deviceType = deviceType;
            if (m_deviceType != GraphicDeviceType.OpenGL) {
                throw new NotImplementedException("Only OpenGL contexts can be handled so far!"); 
            }
            m_defaultHeight = 500; 
            m_defaultWidth = 500; 
        }
        #endregion

        #region public interface
        /// <summary>
        /// Clear all texture sheets and free their memory (cache) from GL. 
        /// </summary>
        /// <remarks> This will also fire the TextureCacheCleared event.</remarks>
        public void Clear() {
            lock (m_lock) {
                foreach(ILTextureStorage storage in m_textureSheets) {
                    storage.Dispose(true);
                }
                m_textureSheets.Clear(); 
                if (TextureCacheCleared != null) {
                    TextureCacheCleared(this, new EventArgs()); 
                }
            }
        }
        
        /// <summary>
        /// Reset any caching may beeing active for this texture manager. Call this once to begin rendering.
        /// </summary>
        public void Reset() {
            m_lastTextureSheet = -1; 
        }
        /// <summary>
        /// retrieve rendering information for texture item
        /// </summary>
        /// <param name="key">key used to identify the texture item</param>
        /// <returns>texture item data</returns>
        /// <remarks>If the key has been found in one of the texture sheets, the
        /// corresponding texture sheet will be set as current</remarks>
        public ILTextureData GetTextureItem(string key) {
            return GetTextureItem(key,true); 
        }
        /// <summary>
        /// retrieve rendering information for texture item
        /// </summary>
        /// <param name="key">key used to identify the texture item</param>
        /// <param name="makeCurrent">if true: sets the corresponding texture sheet 
        /// as 'current' for subsequent rendering</param>
        /// <returns>texture item data</returns>
        public ILTextureData GetTextureItem(string key, bool makeCurrent) {
            ILTextureData ret; 
            lock (m_lock) {
                foreach (ILTextureStorage storage in m_textureSheets) {
                    ret = storage.Get(key); 
                    if (ret != null) {
                        if (makeCurrent && m_lastTextureSheet != storage.TextureID) {
#if PRINTTEXTURESHEETSWITCH
            Console.Out.WriteLine(String.Format("TSheet switching from {0} to {1}",m_lastTextureSheet,storage.TextureID)); 
#endif
                            storage.MakeCurrent();
                            m_lastTextureSheet = storage.TextureID; 
                        }
                        return ret; 
                    }
                }
            }
            throw new ArgumentException("The key was not found in any texture sheet");
        }
        /// <summary>
        /// retrieve rendering information for texture item
        /// </summary>
        /// <param name="key">key used to identify the texture item</param>
        /// <param name="makeCurrent">if true: sets the corresponding texture sheet 
        /// as 'current' for subsequent rendering</param>
        /// <param name="textureID">returns the texture sheet key of the item, 
        /// used to identify the texture in the graphic system</param>
        /// <returns>texture item data</returns>
        public ILTextureData GetTextureItem(string key, bool makeCurrent, out int textureID) {
            ILTextureData ret; 
            lock (m_lock) {
                foreach (ILTextureStorage storage in m_textureSheets) {
                    ret = storage.Get(key); 
                    if (ret != null) {
                        if (makeCurrent) {
                            storage.MakeCurrent(); 
                        }
                        textureID = storage.TextureID; 
                        return ret; 
                    }
                }
            }
            throw new ArgumentException("The key was not found in any texture sheet");
        }
        public bool StoreTextureItem(string key, Bitmap item, Rectangle rect) {
            lock (m_lock) {
                foreach (ILTextureStorage storage in m_textureSheets) {
                    if (storage.Store(key,item,rect)) {
                        return true; 
                    }
                }
                ILTextureStorage stor = CreateStorage(); 
                m_textureSheets.Add(stor); 
                return stor.Store(key,item,rect); 
            }
        }
        public bool StoreTextureItem(string key, Bitmap item, RectangleF usedArea) {
            lock (m_lock) {
                foreach (ILTextureStorage storage in m_textureSheets) {
                    if (storage.Store(key,item,usedArea)) {
                        return true; 
                    }
                }
                ILTextureStorage stor = CreateStorage(); 
                m_textureSheets.Add(stor); 
                return stor.Store(key,item,usedArea);
            }
        }
        /// <summary>
        /// test, if a texture item for the given key exists 
        /// in any texture storage sheets
        /// </summary>
        /// <param name="key">unique key to be tested for</param>
        /// <returns>true, if a corresponding texture item exists, otherwise false</returns>
        public bool Exists (string key) {
            lock (m_lock) { 
                foreach (ILTextureStorage storage in m_textureSheets) {
                    if (storage.Exists(key)) {
                        return true; 
                    }
                }
                return false;
            }
        }
        public bool TryGetTextureItem (string key, out ILTextureData item) {
            lock (m_lock) {
                foreach (ILTextureStorage storage in m_textureSheets) {
                    if (storage.TryGetTextureItem(key, out item)) {
                        return true; 
                    }
                }
                item = null; 
                return false; 
            }
        }

        internal void Dispose() {                                                   
            Clear(); 
        }

        #endregion

        #region helper functions

        private ILTextureStorage CreateStorage () {
            switch (m_deviceType) {
                case GraphicDeviceType.OpenGL:
                    return new ILOGLTextureStorage(m_defaultWidth,m_defaultHeight); 
                default:
                    throw new NotImplementedException(); 
                    break;
            }
        }
        #endregion

    }
}
