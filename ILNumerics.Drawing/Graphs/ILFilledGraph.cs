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
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.BuiltInFunctions;
using ILNumerics.Drawing.Misc; 
using ILNumerics.Misc;  

namespace ILNumerics.Drawing.Graphs {
    /// <summary>
    /// Class representing abstract implementation of filled graphs
    /// </summary>
    public abstract class ILFilledGraph : ILGraph {
    
        #region attributes / properties 
        protected float[] m_xCoords; 
        protected float[] m_yCoords; 
        protected ILArray<float> m_colors;
        protected ILArray<float> m_sourceArray; 
        protected int m_Vertcount;
        protected int m_rows, m_cols;  
        protected bool m_vertexReady, m_indexReady;
        protected uint[] m_indices; 
        protected uint[] m_gridIndices; 
        protected int m_gridIndicesCount; 
        protected int m_indicesCount;
        protected int m_oldSubQuadrant; 
        protected int m_stripesCount; 
        protected int m_stripesLen; 
        protected int m_gridStripsLen; 
        protected int m_gridStripsLenOnce; 
        protected int m_gridStripsCount; 
        protected bool m_shadeVertexDirectionLowHigh = false; 
        protected static readonly float MAXHUEVALUE = Internal.ILColorProvider.MAXHUEVALUE;
        protected static readonly float CAMERA_ANG_OFFSET = - (float)(Math.PI / 4);  
        // visible properties
        protected float m_opacity;
        protected bool m_filled; 
        protected ILLineProperties m_wireLines; 
        /// <summary>
        /// Wireframe line properties
        /// </summary>
        public ILLineProperties Wireframe {
            get {
                return m_wireLines; 
            }
        }

        /// <summary>
        /// Get / set the transparency for the graph (percent)
        /// </summary>
        /// <remarks>1.0f (opaque) ... 0.0f (transparent)</remarks>
        public float Opacity {
            get {
                return m_opacity;
            }
            set {
                m_opacity = value; 
                Invalidate(); 
                OnChanged("Opacity"); 
            }
        }
        /// <summary>
        /// Determine, if the tiles (rectangle areas between data points) 
        /// constructing the surface will be filled or invisible
        /// </summary>
        public bool Filled {
            get {
                return m_filled; 
            }
            set {
                m_filled = value;
                OnChanged("Filled"); 
            }
        }
        /// <summary>
        ///  get a reference to the internal data array
        /// </summary>
        /// <remarks>modifications to the array returned will 
        /// <b>not</b> alter the data the graph is based on.</remarks>
        public ILBaseArray Data {
            get {
                return m_sourceArray.CreateReference(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct new filled graph
        /// </summary>
        /// <param name="panel">panel hosting the graph</param>
        /// <param name="X">X coords, if null, range 0..[cols of Z] will be created</param>
        /// <param name="Y">Y coords, if null, range 0..[rows of Z] will be created</param>
        /// <param name="Z">Z coords (heights)</param>
        /// <param name="C">Colors for Z</param>
        /// <param name="clippingContainer">gloabal limits of panel</param>
        public ILFilledGraph (ILPanel panel, ILBaseArray X, ILBaseArray Y,
                              ILBaseArray Z, ILBaseArray C, ILClippingData clippingContainer) 
                : base (panel, clippingContainer) {
            #region argument checking
            m_localClipping.EventingSuspend(); 
            if (Z == null || !Z.IsMatrix) 
                throw new ILArgumentException ("ILFilledGraph: Z must be matrix!"); 
            if (!Z.IsNumeric) 
                throw new ILArgumentException ("ILFilledGraph: Z must be numeric!"); 
            m_sourceArray = ILMath.tosingle(Z); 
            m_rows = m_sourceArray.Dimensions[0]; 
            m_cols = m_sourceArray.Dimensions[1]; 
            ILArray<float> tmp; 
            if (!object.Equals (X,null) && !X.IsEmpty) {
                if (!X.IsMatrix || !X.IsNumeric) {
                    throw new ILArgumentException ("ILFilledGraph: X must be numeric matrix!"); 
                }
                if (X.Dimensions.IsSameSize(Z.Dimensions)) {
                    tmp = ILMath.tosingle(X); 
                    tmp.ExportValues(ref m_xCoords); 
                    m_localClipping.XMax = tmp.MaxValue; 
                    m_localClipping.XMin = tmp.MinValue; 
                } else {
                    throw new ILArgumentException ("ILFilledGraph: X must be of same size than Z!"); 
                }
            } else {
                ILMath.tosingle(ILMath.repmat(ILMath.counter(0.0,1.0,1,m_cols),m_rows,1)).ExportValues(ref m_xCoords); 
                m_localClipping.XMin = 0; 
                m_localClipping.XMax = m_cols-1; 
            }
            if (!object.Equals(Y,null) && !Y.IsEmpty) {
                if (!Y.IsMatrix || !Y.IsNumeric) {
                    throw new ILArgumentException ("ILFilledGraph: Y must be numeric matrix!"); 
                }
                if (Y.Dimensions.IsSameSize(Z.Dimensions)) {
                    tmp = ILMath.tosingle(Y); 
                    tmp.ExportValues(ref m_yCoords); 
                    m_localClipping.YMax = tmp.MaxValue; 
                    m_localClipping.YMin = tmp.MinValue; 
                } else {
                    throw new ILArgumentException ("ILFilledGraph: Y must be same size than Z!"); 
                }
            } else {
                ILMath.tosingle(ILMath.repmat(ILMath.counter(0.0,1.0,m_rows,1),1,m_cols)).ExportValues(ref m_yCoords); 
                m_localClipping.YMax = m_rows-1; 
                m_localClipping.YMin = 0; 
            }
            if (object.Equals(C,null) || C.IsEmpty) {
                m_colors = null; 
            } else {
                m_colors = ILMath.tosingle(C);
            }  
            m_localClipping.ZMax = m_sourceArray.MaxValue; 
            m_localClipping.ZMin = m_sourceArray.MinValue; 
            #endregion
            m_Vertcount = m_rows * m_cols; 
            m_vertexReady = false;
            m_indexReady = false; 
            // default view properties
            m_opacity = 1.0f; 
            m_wireLines = new ILLineProperties();
            m_wireLines.Changed += new EventHandler(m_wireLines_Changed);
            m_filled = true; 
            m_localClipping.EventingResume(); 
        }
        #endregion

        #region protected/private helper
                
        protected virtual void CreateVertices() {}
        
        /// <summary>
        /// Create indices for filled graphs
        /// </summary>
        /// <remarks>Indices will be ordered to assemble individual triangles.</remarks>
        protected virtual void CreateIndices() {
            #region interpolate shading faster, less exact (obsolete)
            //if (m_panel.Camera.CosPhiShift  > 0) {
            //    if (m_panel.Camera.SinPhiShift > 0) {
            //        System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi > 0 (front)");
            //        // looking from front
            //        checkVertexIndicesLength(m_cols * 2, m_rows-1);
            //        if (m_panel.Camera.LooksFromLeft) {
            //            pos1 = m_Vertcount-1; pos2 = pos1 - m_cols;
            //            for (int r = m_rows-1; r --> 0;) {
            //                for (int c = m_cols; c--> 0;) {
            //                    m_indices[posI++] = (uint)pos1--; 
            //                    m_indices[posI++] = (uint)pos2--; 
            //                }
            //            }
            //        } else {
            //            // looks from right
            //            pos1 = m_Vertcount-m_cols; pos2 = pos1 - m_cols;
            //            for (int r = m_rows-1; r --> 0;) {
            //                for (int c = m_cols; c--> 0;) {
            //                    m_indices[posI++] = (uint)pos2++; 
            //                    m_indices[posI++] = (uint)pos1++; 
            //                }
            //                pos1 -= (m_cols * 2); 
            //                pos2 -= (m_cols * 2); 
            //            }
            //        }
            //    } else {
            //        System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi < 0 (left)"); 
            //        // looking from left
            //        checkVertexIndicesLength(m_rows * 2, m_cols-1);
            //        pos1 = m_Vertcount-1; pos2 = m_Vertcount-2;
            //        for (int c = m_cols-1; c --> 0;) {
            //            for (int r = m_rows; r --> 0;) {
            //                m_indices[posI++] = (uint)pos1; 
            //                m_indices[posI++] = (uint)pos2; 
            //                pos1 -= m_cols; 
            //                pos2 -= m_cols; 
            //            }
            //            pos1 += (m_Vertcount-1); 
            //            pos2 = pos1-1; 
            //        }
            //    }
            //} else {
            //    if (m_panel.Camera.SinPhiShift > 0) {
            //        // looking from right
            //        System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi > 0 (right)"); 
            //        checkVertexIndicesLength(m_rows * 2, m_cols-1);
            //        pos1 = m_Vertcount-1; pos2 = m_Vertcount-2;
            //        for (int c = m_cols-1; c --> 0;) {
            //            for (int r = m_rows-1; r --> 0;) {
            //                m_indices[posI++] = (uint)pos1; 
            //                m_indices[posI++] = (uint)pos2; 
            //                pos1 -= m_cols; 
            //                pos2 -= m_cols; 
            //            }
            //            pos1 += m_Vertcount; 
            //            pos2 += m_Vertcount; 
            //        }
            //    } else {
            //        // looking from back
            //        System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi < 0 (back)"); 
            //        checkVertexIndicesLength(m_cols * 2, m_rows-1);
            //        pos1 = m_cols-1; pos2 = pos1+m_cols;
            //        for (int r = m_rows-1; r-->0;) {
            //            for (int c = m_cols; c-->0;) {
            //                m_indices[posI++] = (uint)pos2--; 
            //                m_indices[posI++] = (uint)pos1--; 
            //            }                  
            //            pos1 += m_cols*2; 
            //            pos2 += m_cols*2; 
            //        }
            //    }
            //} 
            //
            #endregion
            #region both shading modes WITH transparency, draws individual triangles 
            // DrawMode "trianglestrips" will not work here! -> 
            // We must specify each triangle seperately!
            // Also we must divide the whole camera angle range in 8 (!) areas 
            // and handle each individually by different index arrays. 
            // This all is more exact but less performant ...
            int pos1,pos2,posI = 0;
            if (m_panel.Camera.CosPhiShift > 0) {
                if (m_panel.Camera.SinPhiShift > 0) {
                    #region looking from front
                    //System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi > 0 (front)");
                    checkVertexIndicesLength((m_cols - 1) * 6,m_rows-1);
                    if (m_panel.Camera.LooksFromLeft) {
                        m_oldSubQuadrant = 7; 
                        pos1 = m_Vertcount-1; pos2 = pos1-m_cols;
                        for (int r = m_rows-1; r --> 0; ) {
                            for (int c = m_cols-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1-1; 
                                m_indices[posI++] = (uint)pos2-1; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2--; 
                                m_indices[posI++] = (uint)pos2; 
                                m_indices[posI++] = (uint)pos1--; 
                            }
                            pos1--; 
                            pos2--; 
                        }
                    } else {
                        m_oldSubQuadrant = 0; 
                        pos1 = m_Vertcount-2*m_cols; pos2 = m_Vertcount-m_cols;
                        for (int r = m_rows-1; r --> 0; ) {
                            for (int c = m_cols-1; c-->0;) {
                                m_indices[posI++] = (uint)pos2++; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2; 
                                m_indices[posI++] = (uint)pos1+1; 
                                m_indices[posI++] = (uint)pos1++; 
                                m_indices[posI++] = (uint)pos2; 
                            }
                            pos1 -= (m_cols * 2 - 1); 
                            pos2 -= (m_cols * 2 - 1); 
                        }
                    }
                    #endregion
                } else {
                    #region looking from left 
                    //System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi < 0 (left)"); 
                    checkVertexIndicesLength((m_rows - 1) * 6,m_cols-1);
                    if (m_panel.Camera.LooksFromFront) {
                        m_oldSubQuadrant = 6; 
                        pos1 = m_Vertcount-2; pos2 = pos1 + 1;
                        for (int r = m_cols-1; r --> 0; ) {
                            for (int c = m_rows-1; c-->0;) {
                                m_indices[posI++] = (uint)(pos2-m_cols); 
                                m_indices[posI++] = (uint)(pos1-m_cols); 
                                m_indices[posI++] = (uint)pos2; 
                                m_indices[posI++] = (uint)pos1; pos1 -= m_cols; 
                                m_indices[posI++] = (uint)pos1;
                                m_indices[posI++] = (uint)pos2; pos2 -= m_cols; 
                            }
                            pos1 += (m_Vertcount - m_cols - 1); 
                            pos2 += (m_Vertcount - m_cols - 1); 
                        }
                    } else {
                        m_oldSubQuadrant = 5; 
                        pos1 = m_cols-2; pos2 = pos1 + 1;
                        for (int r = m_cols-1; r --> 0; ) {
                            for (int c = m_rows-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2; pos2 += m_cols;  
                                m_indices[posI++] = (uint)pos2;
                                m_indices[posI++] = (uint)pos1; pos1 += m_cols; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2; 
                            }
                            pos1 -= (m_Vertcount - m_cols + 1); 
                            pos2 -= (m_Vertcount - m_cols + 1);
                        }
                    }
                    #endregion
                }
            } else {
                if (m_panel.Camera.SinPhiShift > 0) {
                    #region looking from right
                    checkVertexIndicesLength((m_rows - 1) * 6,m_cols-1);
                    //System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi > 0 (right)");
                    if (m_panel.Camera.LooksFromFront) {
                        m_oldSubQuadrant = 1; 
                        pos1 = m_Vertcount-m_cols; pos2 = pos1+1;
                        for (int r = m_cols-1; r --> 0; ) {
                            for (int c = m_rows-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1; pos1 -= m_cols; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)(pos2-m_cols);
                                m_indices[posI++] = (uint)pos2; pos2 -= m_cols; 
                            }
                            pos1 += (m_Vertcount - m_cols + 1); 
                            pos2 += (m_Vertcount - m_cols + 1);
                        }
                    } else {
                        m_oldSubQuadrant = 2; 
                        pos1 = 0; pos2 = 1;
                        for (int r = m_cols-1; r --> 0; ) {
                            for (int c = m_rows-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)(pos1+m_cols); 
                                m_indices[posI++] = (uint)(pos2+m_cols); 
                                m_indices[posI++] = (uint)pos1; pos1 += m_cols; 
                                m_indices[posI++] = (uint)pos2; pos2 += m_cols; 
                                m_indices[posI++] = (uint)pos2; 
                            }
                            pos1 -= (m_Vertcount - m_cols - 1); 
                            pos2 -= (m_Vertcount - m_cols - 1);
                        }
                    }
                    #endregion
                } else {
                    #region looking from back
                    //System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi < 0 (back)"); 
                    checkVertexIndicesLength((m_cols - 1) * 6,m_rows-1);
                    if (m_panel.Camera.LooksFromLeft) {
                        m_oldSubQuadrant = 4; 
                        pos1 = m_cols-1; pos2 = pos1+m_cols;
                        for (int r = m_rows-1; r --> 0; ) {
                            for (int c = m_cols-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1--; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2; 
                                m_indices[posI++] = (uint)pos2-1; 
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos2--; 
                            }
                            pos1 += (2*m_cols-1); 
                            pos2 += (2*m_cols-1); 
                        }
                    } else {
                        m_oldSubQuadrant = 3; 
                        pos1 = 0; pos2 = pos1+m_cols;
                        for (int r = m_rows-1; r --> 0; ) {
                            for (int c = m_cols-1; c-->0;) {
                                m_indices[posI++] = (uint)pos1; 
                                m_indices[posI++] = (uint)pos1+1; 
                                m_indices[posI++] = (uint)pos2+1; 
                                m_indices[posI++] = (uint)pos1++; 
                                m_indices[posI++] = (uint)pos2++; 
                                m_indices[posI++] = (uint)pos2; 
                            }
                            pos1 ++; 
                            pos2 ++; 
                        }
                    }
                    #endregion
                }
            } 
            #endregion
            if (m_wireLines.Visible) {
                #region create grid line indices
                posI = 0; 
                if (m_panel.Camera.CosPhiShift > 0) {
                    if (m_panel.Camera.SinPhiShift > 0) {
                        #region looking from front
                        //System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi > 0 (front)");
                        checkGridIndicesLength((m_cols-1) * 4 + 2,m_rows-1); 
                        pos1 = m_Vertcount-m_cols; 
                        pos2 = m_Vertcount-m_cols;
                        // first row is special:
                        for (int c = m_cols-1; c-->0;) {
                            m_gridIndices[posI++] = (uint)pos1++; 
                            m_gridIndices[posI++] = (uint)pos1; 
                        }
                        pos1 -= 2*m_cols-1; 
                        for (int r = m_rows-1; r-->0;) {
                            // first column is special: 
                            m_gridIndices[posI++] = (uint)pos1; 
                            m_gridIndices[posI++] = (uint)pos2; 
                            for (int c = m_cols-1; c-->0;) {
                                m_gridIndices[posI++] = (uint)pos1++; 
                                m_gridIndices[posI++] = (uint)pos1; 
                                m_gridIndices[posI++] = (uint)pos1; 
                                m_gridIndices[posI++] = (uint)++pos2; 
                            }
                            pos1 -= (m_cols * 2 - 1); 
                            pos2 -= (m_cols * 2 - 1);
                        }
                        #endregion
                    } else {
                        #region looking from left
                        //System.Diagnostics.Debug.WriteLine("CosPhi > 0 & SinPhi < 0 (left)"); 
                        checkGridIndicesLength((m_rows-1) * 4 + 2,m_cols-1); 
                        pos1 = m_Vertcount-1; 
                        pos2 = m_Vertcount-1-m_cols;
                        // first col is special:
                        for (int c = m_rows-1; c-->0;) {
                            m_gridIndices[posI++] = (uint)pos2; pos2 -= m_cols; 
                            m_gridIndices[posI++] = (uint)pos1; pos1 -= m_cols; 
                        }
                        pos2 = m_Vertcount - 1 - m_cols; 
                        pos1 = m_Vertcount - 2; 
                        for (int r = m_cols-1; r-->0;) {
                            // first row is special: 
                            m_gridIndices[posI++] = (uint)pos1; 
                            m_gridIndices[posI++] = (uint)pos1+1; 
                            for (int c = m_rows-1; c-->0;) {
                                m_gridIndices[posI++] = (uint)(pos1-m_cols);  
                                m_gridIndices[posI++] = (uint)pos1; pos1 -= m_cols; 
                                m_gridIndices[posI++] = (uint)pos1; 
                                m_gridIndices[posI++] = (uint)pos2; pos2 -= m_cols;  
                            }
                            pos1 += (m_Vertcount - m_cols -1);
                            pos2 += (m_Vertcount - m_cols -1);
                        }
                        #endregion
                    }
                } else {
                    if (m_panel.Camera.SinPhiShift > 0) {
                        #region looking from right
                        //System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi > 0 (right)"); 
                        checkGridIndicesLength((m_rows-1) * 4 + 2,m_cols-1); 
                        pos1 = 0; 
                        pos2 = 1; 
                        // first col is special:
                        for (int c = m_rows-1; c-->0;) {
                            m_gridIndices[posI++] = (uint)pos1; pos1 += m_cols; 
                            m_gridIndices[posI++] = (uint)pos1; 
                        }
                        pos1 = m_cols; 
                        for (int r = m_cols-1; r-->0;) {
                            // first row is special: 
                            m_gridIndices[posI++] = (uint)pos2-1; 
                            m_gridIndices[posI++] = (uint)pos2; 
                            for (int c = m_rows-1; c-->0;) {
                                m_gridIndices[posI++] = (uint)pos1;   
                                m_gridIndices[posI++] = (uint)pos1+1; pos1 += m_cols;  
                                m_gridIndices[posI++] = (uint)pos2; pos2 += m_cols;  
                                m_gridIndices[posI++] = (uint)pos2; 
                            }
                            pos1 -= (m_Vertcount - m_cols -1);
                            pos2 -= (m_Vertcount - m_cols -1);
                        }
                          #endregion
                    } else {
                        #region looking from back 
                        //System.Diagnostics.Debug.WriteLine("CosPhi < 0 & SinPhi < 0 (back)"); 
                        checkGridIndicesLength((m_cols-1) * 4 + 2,m_rows-1); 
                        pos1 = m_cols-1; pos2 = pos1-1;
                        for (int c = m_cols-1; c-->0;) {
                            m_gridIndices[posI++] = (uint)pos2--; 
                            m_gridIndices[posI++] = (uint)pos1--; 
                        }
                        pos2 = m_cols*2-1; 
                        pos1 = m_cols-1; 
                        for (int r = m_rows-1; r-->0;) {
                            // first column is special: 
                            m_gridIndices[posI++] = (uint)pos1; 
                            m_gridIndices[posI++] = (uint)pos2; 
                            for (int c = m_cols-1; c-->0;) {
                                m_gridIndices[posI++] = (uint)(pos2-1); 
                                m_gridIndices[posI++] = (uint)pos2--; 
                                m_gridIndices[posI++] = (uint)--pos1; 
                                m_gridIndices[posI++] = (uint)pos2; 
                            }
                            pos1 += (2*m_cols-1); 
                            pos2 += (2*m_cols-1);
                        }
                        #endregion
                    }
                } 
                #endregion
                }
            m_indexReady = true; 
        }
        /// <summary>
        /// checks the length of index vector and allocate more memory if needed
        /// </summary>
        /// <param name="vertStrCount">Number of stripes to be drawn</param>
        /// <param name="vertStrLen">Number of indices for each stripe</param>
        protected void checkVertexIndicesLength(int vertStrLen, int vertStrCount) {
            m_indicesCount = vertStrCount * vertStrLen;
            if (m_indices != null && m_indices.Length < m_indicesCount) {
                ILMemoryPool.Pool.RegisterObject(m_indices);
            }
            if (m_indices == null || m_indices.Length < m_indicesCount) {
                m_indices = ILMemoryPool.Pool.New<uint>(m_indicesCount);
            }
            m_stripesCount = vertStrCount; 
            m_stripesLen = vertStrLen; 
        }
        /// <summary>
        /// checks the length of grid index vector and allocate more if needed
        /// </summary>
        /// <param name="gridStrCount">Number of stripes to be drawn</param>
        /// <param name="gridStrLen">Number of indices for each stripe</param>
        protected void checkGridIndicesLength(int gridStrLen, int gridStrCount) {
            m_gridStripsLenOnce = (gridStrLen -2) / 2 + 2; 
            m_gridIndicesCount = gridStrLen * gridStrCount + m_gridStripsLenOnce; 
            if (m_gridIndices != null && m_gridIndices.Length < m_gridIndicesCount) {
                ILMemoryPool.Pool.RegisterObject(m_gridIndices);
            }
            if (m_gridIndices == null || m_gridIndices.Length < m_gridIndicesCount) {
                m_gridIndices = ILMemoryPool.Pool.New<uint>(m_gridIndicesCount);
            }
            m_gridStripsCount = gridStrCount; 
            m_gridStripsLen = gridStrLen; 
        }
        /// <summary>
        /// Dispose off this filled graph (grid-)indices
        /// </summary>
        public override void Dispose() {
            if (m_indices != null) {
                ILMemoryPool.Pool.RegisterObject<uint>(m_indices); 
            }
            if (m_gridIndices != null) {
                ILMemoryPool.Pool.RegisterObject<uint>(m_gridIndices); 
            }
            base.Dispose();
        }
        /// <summary>
        /// checks &amp; if neccessary triggers recreation of all vertices and indices
        /// </summary>
        /// <remarks>This function is called by the enclosing panel, f.e. when rotation
        /// occours, which makes a reconfiguration neccessary. It internally calls CreateVertices() 
        /// and CreateIndices().</remarks>
        public override void Configure() {
            m_isReady = false; 
            if (!m_vertexReady) CreateVertices(); 
            if (!m_indexReady) CreateIndices(); 
            m_isReady = true; 
        }

        protected override void OnChanged(string source) {
            base.OnChanged(source);
            if (source == "Shading")    
                m_vertexReady = false; 
        }

        protected void m_wireLines_Changed(object sender, EventArgs args) {
            OnWireLinesChanged(); 
        }
        protected virtual void OnWireLinesChanged () {
            m_indexReady = false; 
            OnChanged("Wirelines"); 
        }
        #endregion

     }
}
