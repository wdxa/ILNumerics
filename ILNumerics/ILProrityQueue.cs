using System;
using System.Collections.Generic;
using System.Text;

namespace ILNumerics.Data {
    public class ILProrityQueue<T> : ILBinTree<T> where T:IComparable {
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
