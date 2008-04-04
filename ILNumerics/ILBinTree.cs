using System;
using System.Collections.Generic;
using System.Text;


namespace ILNumerics.Data {
    public class ILBinTree<T> {
        
        protected int m_count; 
        protected ILBinTreeNode<T> m_root;
        public virtual bool Contains (T data) {
            return Contains(m_root,data); 
        }
        private bool Contains(ILBinTreeNode<T> _root, T data) {
            if (object.Equals(_root.Data,data)) return true;  
            if (_root.LeftSon != null && Contains(_root.LeftSon,data)) return true; 
            if (_root.RightSon != null && Contains(_root.RightSon,data)) return true; 
            return false;      
        }
        //public ILBinTreeNode<T> Find(T data) {
                
        //}
        //public ILBinTreeNode<T> AddLeftSon (ILBinTreeNode<T> node, T) {
        //    T ret = null; 
        //    if (node.LeftSon == null) {

        //    } else {

        //        return 
        //    }
        //}

    }
    public class ILBinTreeNode<T> {
        internal T m_data; 
        internal ILBinTreeNode<T> m_father; 
        internal ILBinTreeNode<T> m_leftSon; 
        internal ILBinTreeNode<T> m_rightSon; 

        public T Data {
            get {
                return m_data; 
            }
            set {
                m_data = value; 
            }
        }
        public ILBinTreeNode<T> Father {
            get {
                return m_father; 
            }
            set {
                m_father = value; 
            }
        }
        public ILBinTreeNode<T> LeftSon {
            get {
                return m_leftSon; 
            }
            set {
                m_leftSon = value; 
            }
        }
        public ILBinTreeNode<T> RightSon {
            get {
                return m_rightSon; 
            }
            set {
                m_rightSon = value; 
            }
        }
        public ILBinTreeNode() {}
        public ILBinTreeNode(T data) {
            m_data = data; 
        }

        public bool IsLeaf() {
            return m_leftSon == null && m_rightSon == null; 
        }
        public int Height () {
            if (IsLeaf()) return 0; 
            int lh = (m_leftSon != null) ? m_leftSon.Height() : 0; 
            int rh = (m_rightSon != null) ? m_rightSon.Height() : 0; 
            if (lh > rh) return lh + 1; else return rh + 1; 
        }
        public override string  ToString() {
 	        return ToString(0, '-', BinTreeWalkingMode.PreOrder);
        }
        public string ToString(int indent, char indentChar, BinTreeWalkingMode walkingMode) {
            StringBuilder sb = new StringBuilder(); 
            switch (walkingMode) {
                case BinTreeWalkingMode.PreOrder:
                    #region PreOrder
                    string s; 
                    if (m_data != null) {
                        s = m_data.ToString(); 
                    } else {
                        s = "(null)"; 
                    }
                    sb.Append(s); indent += s.Length; 
                    sb.Append(indentChar); 
                    if (m_leftSon != null) {
                        sb.Append(m_leftSon.ToString(indent + 1, indentChar,walkingMode)); 
                    } else {
                        sb.Append(Environment.NewLine); 
                    }
                    sb.Append(new String(' ',indent) + indentChar); 
                    if (m_rightSon != null) {
                        sb.Append(m_rightSon.ToString(indent + 1, indentChar,walkingMode)); 
                    } else {
                        sb.Append(Environment.NewLine); 
                    } 
                    break;
                    #endregion
                default: 
                    throw new InvalidOperationException(); 
            }
            return sb.ToString();
        }
        
    
    }
    public enum BinTreeWalkingMode {
        PreOrder,
        PostOrder,
        InOrder
    }

}
