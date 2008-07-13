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
using System.Collections; 
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// the class collects renderable items which define 
    /// the graphical output for a render expression
    /// </summary>
    /// <remarks>ILRenderQueues are semi-immutable. Instances - once created - can only be cleared and 
    /// re-created, but not altered. Therefore, they keep the size of the output cached over their livetime.</remarks>
    public class ILRenderQueue : IEnumerable {

        #region attributes 
        Size m_size; 
        List<ILRenderQueueItem> m_list; 
        String m_expression;
        #endregion

        #region constructor
        /// <summary>
        ///  constructor, creates a new render queue with content
        /// </summary>
        /// <param name="expression">expression, which led to this queue</param>
        /// <param name="queue">prepared queue</param>
        /// <param name="size">size of content after rendering</param>
        public ILRenderQueue(string expression, List<ILRenderQueueItem> queue, Size size) : base () {
            m_size = size; 
            m_list = queue; 
            m_expression = expression;
        }
        #endregion 

        #region properties 
        /// <summary>
        /// size of content defined by this render queue
        /// </summary>
        public Size Size {
            get {
                return m_size;     
            }
        }

        /// <summary>
        /// Expression which led to this queue
        /// </summary>
        public string Expression {
            get { return m_expression; }
        }
        #endregion

        #region IList<ILRenderQueueItem> Member

        public int IndexOf(ILRenderQueueItem item) {
            return m_list.IndexOf(item); 
        }

        //public void Insert(int index, ILRenderQueueItem item) {
        //    m_list.Insert(index,item); 
        //}

        //public void RemoveAt(int index) {
        //    m_list.RemoveAt(index); 
        //}

        public ILRenderQueueItem this[int index] {
            get {
                return m_list[index]; 
            }
            //set {
            //    m_list[index] = value; 
            //}
        }

        #endregion

        #region ICollection<ILRenderQueueItem> Member

        //public void Add(ILRenderQueueItem item) {
        //    // todo: implement pooling of render queue item objects! 
        //    m_list.Add(item); 
        //}

        public void Clear() {
            // todo: implement pooling of render queue item objects! 
            m_list.Clear(); 
        }

        public bool Contains(ILRenderQueueItem item) {
            return m_list.Contains(item); 
        }

        public void CopyTo(ILRenderQueueItem[] array, int arrayIndex) {
            m_list.CopyTo(array,arrayIndex); 
        }

        public int Count {
            get { return m_list.Count;  }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        //public bool Remove(ILRenderQueueItem item) {
        //    return m_list.Remove(item); 
        //}

        #endregion

        #region IEnumerable<ILRenderQueueItem> Member

        public IEnumerator<ILRenderQueueItem> GetEnumerator() {
            foreach (ILRenderQueueItem item in m_list) 
                yield return item; 
        }

        #endregion

        #region IEnumerable Member

        IEnumerator IEnumerable.GetEnumerator() {
            return m_list.GetEnumerator(); 
        }

        #endregion

    }
}
