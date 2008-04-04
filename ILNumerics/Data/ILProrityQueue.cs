#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace ILNumerics.Data {
    /// <summary>
    /// experimental performant priority queue implementation (WORK IN PROGRESS!)
    /// </summary>
    /// <typeparam name="T">inner type for elements (arbitrary)</typeparam>
    public class ILProrityQueue<T> : ILBinTree<T> where T:IComparable {
        /// <summary>
        /// add an element to the queue
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element) {
            ILBinTreeNode<T> cur = null; // m_root; 
            while (cur != null) {
                
            }
            m_count++; 
        }

        private void createHeap() {
            
        }
        private void heapify(ILBinTreeNode<T> top) {
            System.Diagnostics.Debug.Assert(top != null && top.Data != null); 
            int res; 
            ILBinTreeNode<T> child; 
            if (top.LeftSon != null) {
                System.Diagnostics.Debug.Assert(top.LeftSon.Data != null);
                T ls = top.LeftSon.Data; 
                if (top.RightSon != null) {
                    System.Diagnostics.Debug.Assert(top.RightSon.Data != null);
                    T rs = top.RightSon.Data; 
                    if (ls.CompareTo(rs) > 0) 
                        child = top.LeftSon; 
                    else 
                        child = top.RightSon;
                } else {
                    child = top.LeftSon; 
                }
            } else {
                if (top.RightSon != null) {
                    System.Diagnostics.Debug.Assert(top.RightSon.Data != null);
                    child = top.RightSon; 
                } else {
                    return; 
                }
            }
            // may exchange this data with largest node's value 
            if (child.m_data.CompareTo(top.m_data) > 0) {
                T tmp = child.m_data; 
                child.m_data = top.m_data; 
                top.m_data = tmp; 
                heapify(child); 
            }   
        }
    }
}
