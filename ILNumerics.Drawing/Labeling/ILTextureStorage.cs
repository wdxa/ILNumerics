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
using System.Drawing.Imaging; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// The class provides texture storage for a single class of texures (f.e. one font)
    /// </summary>
    /// <remarks>The texture items are stored in a single texture sheet 
    /// and organized via a simple binary tree.</remarks>
    public abstract class ILTextureStorage {

        #region attributes / properties
        protected Dictionary<string,ILTextureData> m_items;
        protected int m_height;
        protected int m_width;
        protected int m_textureId; 
        /// <summary>
        ///  cache, which texture has been bound at last
        /// </summary>
        protected bool m_disposed = true; 
        protected static int[] m_tmpData; 
        protected Node m_root; 

        /// <summary>
        /// overall height of the internal texture sheet
        /// </summary>
        public int Height {
            get { return m_height; }
        }

        /// <summary>
        /// current width of the internal texture sheet
        /// </summary>
        public int Width {
            get { return m_width; }
        } 
        /// <summary>
        /// Key used to identify the texure in the graphic system 
        /// </summary>
        public int TextureID {
            get {
                return m_textureId; 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct new storage
        /// </summary>
        /// <param name="height">absolute height (permanent)</param>
        /// <param name="width">absolute width (permanent)</param>
        /// <remarks>Suggested size parameter will be increased to the next power of two.</remarks>
        public ILTextureStorage(int height, int width) {
            m_items = new Dictionary<string,ILTextureData>();
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("width & height ", width, "Must be greater than zero.");
            // make size a power of 2
            m_height = (int)Math.Pow(2,Math.Ceiling(Math.Log(height,2)));
            m_width = (int)Math.Pow(2,Math.Ceiling(Math.Log(width,2)));
            if (m_height > 1024) m_height = 1024; // limit to 1024 for compatibility reasons 
            if (m_width > 1024) m_width = 1024; 
            m_root = new Node();
            m_root.Rect = new Rectangle(0,0,m_width,m_height); 
            InitTexture(); 
            m_disposed = false; 
#if DEBUG
            System.Diagnostics.Debug.WriteLine("ILTextureStorage (constr) ThreadID:" 
                + System.Threading.Thread.CurrentThread.ManagedThreadId);
#endif
        }
        #endregion

        #region public / abstract interface
        /// <summary>
        /// fetch texture item from storage
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual ILTextureData Get (string key) {
            ILTextureData ret = null; 
            if (!m_items.TryGetValue(key,out ret)) {
                return null; //throw new ArgumentException("no texture item has been found for key: " + key); 
            }
            return ret;
        }
        /// <summary>
        /// try to fetch item by key
        /// </summary>
        /// <param name="key">unique key</param>
        /// <param name="item">[output] item found</param>
        /// <returns>true: item was found, false otherwise</returns>
        public virtual bool TryGetTextureItem(string key, out ILTextureData item) {
            if (m_items.ContainsKey(key)) {
                item = m_items[key]; 
                return true; 
            }
            item = null; 
            return false; 
        }
        /// <summary>
        /// test, if a key exists in the texture storage
        /// </summary>
        /// <param name="key">unique key to be tested for</param>
        /// <returns>true if a texture item associated with that key exists, false otherwise</returns>
        public bool Exists (string key) {
            return m_items.ContainsKey(key); 
        }
        /// <summary>
        /// store bitmap into texture sheet
        /// </summary>
        /// <param name="key">unique key for item</param>
        /// <param name="data">item bitmap data</param>
        public virtual bool Store (string key, Bitmap data, Rectangle rect) {
            if (data.Height > m_height || data.Width > m_width) 
                throw new ArgumentException("texture size is too large for this packer!");
            // add to packer  
            ILTextureData item; 
            if (m_items.TryGetValue(key,out item)) {
                item.Height = data.Height; 
                item.Width = data.Width; 
                // todo: remove item from packer & from texture sheet (somehow...[?])
            } else {
                item = new ILTextureData(rect.Height,rect.Width); 
                m_items.Add(key, item);
            }
            Node node = m_root.Insert(item); 
            if (node == null) 
                return false; 
            item.TextureRectangle = RectangleF.FromLTRB( (0.5f + node.Rect.Left) / m_width,
                                                    (0.5f + node.Rect.Top) / m_height,
                                                    (node.Rect.Right - 0.5f) / m_width,
                                                    (node.Rect.Bottom - 0.5f) /m_height);
            Store(data,rect, node.Rect); 
            return true; 
        }
        /// <summary>
        /// store bitmap into texture sheet
        /// </summary>
        /// <param name="key">unique key for item</param>
        /// <param name="data">item bitmap data</param>
        /// <param name="bmpRect">used rectangle in data bitmap</param>
        public virtual bool Store (string key, Bitmap data, RectangleF bmpRect) {
            if (bmpRect.Height > m_height || bmpRect.Width > m_width) 
                throw new ArgumentException("texture size is too large for this packer!");
            // add to packer  
            ILTextureData item; Node node;
            int h = (int)bmpRect.Height; 
            int w = (int)bmpRect.Width; 
            if (m_items.TryGetValue(key,out item)) {
                item.Height = h; 
                item.Width = w; 
                // todo: remove item from packer & from texture sheet (somehow...[?])
                node = m_root.Insert(item);
                if (node == null) 
                    return false; 
            } else {
                item = new ILTextureData(h,w); 
                node = m_root.Insert(item); 
                if (node == null) 
                    return false; 
                m_items.Add(key, item);
            }
            item.TextureRectangle = RectangleF.FromLTRB( (0.5f + node.Rect.Left) / m_width,
                                                    (0.5f + node.Rect.Top) / m_height,
                                                    (node.Rect.Right - 0.5f) / m_width,
                                                    (node.Rect.Bottom - 0.5f) /m_height);
            //item.TextureRectangle = RectangleF.FromLTRB( (0f + node.Rect.Left) / m_width,
            //                                        (0f + node.Rect.Top) / m_height,
            //                                        (node.Rect.Right - 0f) / m_width,
            //                                        (node.Rect.Bottom - 0f) /m_height);            
            Store(data,bmpRect,node.Rect); 
            return true; 
        }
        /// <summary>
        /// initialize texture sheet 
        /// </summary>
        protected abstract void InitTexture();
        /// <summary>
        /// store item in texture sheet in GL
        /// </summary>
        /// <param name="data">new item bitmap data</param>
        /// <param name="rect">rectangle specifying area to store the data into, 
        /// texture coords: range from 0...1.0</param>
        protected abstract void Store(Bitmap data, RectangleF location, RectangleF rect);
        /// <summary>
        /// select the texture storage as current in the GL
        /// </summary>
        /// <remarks>Calling this function before an storage / render operation is 
        /// obligatory in specific rendering machines (f.e. OpenGL). For GL's, where 
        /// it is not neccessary, the implementation must ignore any calls to this function.</remarks>
        public abstract void MakeCurrent(); 
        /// <summary>
        /// Dispose off any texture storage's ressources
        /// </summary>
        public void Dispose() {
            GC.SuppressFinalize(this);
            Dispose(true); 
        }
        /// <summary>
        /// Dispose off manually
        /// </summary>
        /// <param name="manual"></param>
        /// <remarks>The true disposing is done in the concrete implementation.</remarks>
        public virtual void Dispose(bool manual) {
            if (!m_disposed) {
                if (manual) {
                    // free texture from GL 
                }
                m_disposed = true; 
            }
        }
        /// <summary>
        /// Finalizer, disposing ressources
        /// </summary>
        ~ILTextureStorage() {
            Dispose(false); 
        }

        #endregion

        #region helper functions

        #endregion 

        #region Node - binary tree
        /// <summary>
        /// class representing a binary tree, used to manage the items on the texture sheet
        /// </summary>
        /// <remarks>This code is a slightly modified version of the OpenTK.Utilities framework
        /// TextPrinter/TextureStorage classes. See http://opentk.com for details.</remarks>
        protected class Node
        {
            public Node()
            {
            }

            Node left, right;
            Rectangle rect;
            int use_count;

            public Rectangle Rect { get { return rect; } set { rect = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            #region --- Constructor ---

            public bool Leaf
            {
                get { return left == null && right == null; }
            }

            #endregion

            #region public Node Insert(ILTextureData item)

            public Node Insert(ILTextureData item)
            {
                if (!this.Leaf)
                {
                    // Recurse towards left child, and if that fails, towards the right.
                    Node new_node = left.Insert(item);
                    return new_node ?? right.Insert(item);
                }
                else
                {
                    // We have recursed to a leaf.

                    // If it is not empty go back.
                    if (use_count != 0)
                        return null;

                    // If this leaf is too small go back.
                    if (rect.Width < item.Width || rect.Height < item.Height)
                        return null;

                    // If this leaf is the right size, insert here.
                    if (rect.Width == item.Width && rect.Height == item.Height)
                    {
                        use_count = 1;
                        return this;
                    }

                    // This leaf is too large, split it up. We'll decide which way to split
                    // by checking the width and height difference between this rectangle and
                    // out item's bounding box. If the width difference is larger, we'll split
                    // horizontaly, else verticaly.
                    left = new Node();
                    right = new Node();

                    int dw = this.rect.Width - item.Width + 1;
                    int dh = this.rect.Height - item.Height + 1;

                    if (dw > dh)
                    {
                        left.rect = new Rectangle(rect.Left, rect.Top, item.Width, rect.Height);
                        right.rect = new Rectangle(rect.Left + item.Width, rect.Top, rect.Width - item.Width, rect.Height);
                    }
                    else
                    {
                        left.rect = new Rectangle(rect.Left, rect.Top, rect.Width, item.Height);
                        right.rect = new Rectangle(rect.Left, rect.Top + item.Height, rect.Width, rect.Height - item.Height);
                    }

                    return left.Insert(item);
                }
            }

            #endregion

            #region public void Clear()
            
            public void Clear()
            {
                if (left != null)
                    left.Clear();
                if (right != null)
                    right.Clear();

                left = right = null;
            }

            #endregion
        }

        #endregion

    }
}
