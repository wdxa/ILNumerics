using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Shapes;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Drawing.Shapes; 

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// The class implementes a scene graph (tree), capable 
    /// of holding, managing and drawing all kinds of shapes.
    /// </summary>
    public class ILSceneGraph : ILGraph, IEnumerable<ILShape> {

        #region eventing
        void m_root_Invalidated(object sender, EventArgs e) {
            Invalidate();
        }
        #endregion

        #region attributes
        ILSceneGraphNode m_root; 
        #endregion

        #region properties
        /// <summary>
        /// access to the root node of the scene
        /// </summary>
        public ILSceneGraphNode Root {
            get {return m_root; }
        }
        #endregion

        #region constructors
        public ILSceneGraph (ILPanel panel, ILClippingData clipping) 
            : base(panel,clipping) {
            m_root = new ILSceneGraphRoot(panel);
            m_root.Invalidated += new EventHandler(m_root_Invalidated);
            m_root.SizeChanged += new EventHandler(m_root_SizeChanged);
            m_graphType = GraphType.SceneGraph; 
        }

        void m_root_SizeChanged(object sender, EventArgs e) {
            m_localClipping.Set(m_root.PositionMin(),m_root.PositionMax());
        }
        #endregion

        #region public interface
        public override void Draw(ILRenderProperties p) {
            m_root.Draw(p); 
        }
        public override void Configure() {
            if (!m_isReady) {
                m_root.Configure();
                m_isReady = true;
            }
        }
        public void AddNode(ILSceneGraphNode node) {
            AddNode(node, m_root); 
        }
        public void AddNode(ILSceneGraphNode node, ILSceneGraphNode parent) {
            parent.Add(node);             
        }
        #endregion

        #region private helpers
        private void getAllShapes(ILSceneGraphNode node, List<ILShape> ret) {
            foreach (ILSceneGraphNode n in node) {
                if (n is ILShape) 
                    ret.Add(n as ILShape); 
                getAllShapes(n,ret); 
            }
        }

        #endregion

        #region IEnumerable<ILShape> Member

        public IEnumerator<ILShape> GetEnumerator() {
            List<ILShape> ret = new List<ILShape>(); 
            getAllShapes(m_root,ret); 
            return ret.GetEnumerator();  
        }

        #endregion

        #region IEnumerable Member

        IEnumerator IEnumerable.GetEnumerator() {
            List<ILShape> ret = new List<ILShape>(); 
            getAllShapes(m_root,ret); 
            return ret.GetEnumerator();  
        }

        #endregion
    }

    internal class ILSceneGraphRoot : ILSceneGraphNode { 
        public ILSceneGraphRoot (ILPanel panel) : base(panel) {}
    }
}
