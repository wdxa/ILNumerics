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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ILNumerics.Exceptions; 
using System.Runtime.Serialization; 
using ILNumerics.Drawing.Internal;
using ILNumerics.Drawing.Collections; 

namespace ILNumerics.Drawing.Controls {
    /// <summary>
    /// Main ILNumerics.Net figure control - capable of displaying multiple subfigures.
    /// </summary>
    [Serializable]
    public partial class ILControl : UserControl, ISerializable {

        #region properties
        private TableLayoutPanel m_tableLayout; 
        private int m_rows; 
        private int m_cols;
        /// <summary>
        /// Get / set active subfigure
        /// </summary>
        /// <value>the ILSubfigure value to be the newly active subfigure</value>
        public ILSubfigure Subfigure {
            get{
                checkCreateSubfigure(); 
                return m_subfigures[m_activeSubfigure];
            }
            set {
                if (value == null)
                    throw new ILArgumentException("Active subfigure must not be null!"); 
                for (int i = 0; i < m_subfigures.Count; i++) {
                    if (m_subfigures[i] == value) { 
                        m_activeSubfigure = i; 
                        return; 
                    }
                }
                throw new ILArgumentException("The subfigure was not found! It might have been removed from the collection?"); 
            }
        }
        private int m_activeSubfigure = -1;
        private ILSubfigureCollection m_subfigures;  
        /// <summary>
        /// Get the subfigures as subfigure collection (readonly)
        /// </summary>
        public ILSubfigureCollection Subfigures {
            get {
                return m_subfigures; 
            } 
        }
        #endregion
 
        /// <summary>
        /// create new figure control
        /// </summary>
        public ILControl() {
            InitializeComponent();               
            m_subfigures = new ILSubfigureCollection(); 
            m_tableLayout = new TableLayoutPanel(); 
            m_tableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
            m_tableLayout.AutoSize = true; 
            m_tableLayout.Dock = DockStyle.None; 
            m_tableLayout.Padding = new Padding(0); 
            m_tableLayout.Margin = new Padding(0); 
            this.Controls.Add(m_tableLayout); 
            //Tile(1,1,0); 
        }
        
        /// <summary>
        /// Tile this figure control to display mltiple subfigures in rows and columns
        /// </summary>
        /// <param name="rows">number of rows </param>
        /// <param name="columns">number of columns</param>
        /// <param name="current">the index of the subfigure to be set as active subfigure. (sequential index)</param>
        /// <returns>newly selected active subfigure</returns>
        /// <remarks>existing subfigures will remain in the figure control - if possible. If the number of subfigures requested (rows * columns) is larger than the number of subfigures existing, new subfigures will be created. </remarks>
        public ILSubfigure Tile(int rows, int columns, int current) {
            if (rows < 0 || columns < 0) 
                throw new ILArgumentException("invalid number of rows or columns specified!");
            if (current >= rows * columns || current < 0)
                throw new ILArgumentException("invalid selection for current panel. The value of 'current' must be inside the range of panels specified!");
            // if nessecary: add new subfigures to collection
            while (columns * rows > m_subfigures.Count) {
                m_subfigures.Add(m_subfigures.Count,new ILSubfigure()); //m_subfigures.Count+1).ToString())); 
            }
            // reduce if nesseccary
            m_subfigures.Purge(columns * rows); 
            // rebuilt table layout
            m_tableLayout.Controls.Clear(); 
            Dictionary<int,ILSubfigure>.KeyCollection.Enumerator keys = m_subfigures.Keys.GetEnumerator(); 
            keys.MoveNext(); 
            for (int c = 0; c < columns; c++) {
                m_tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
                for (int r = 0; r < rows; r++) {
                    if (c == 0) {
                        m_tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / rows ));
                    }
                    m_tableLayout.Controls.Add(m_subfigures[keys.Current],c,r);
                    keys.MoveNext(); 
                }
            }
            m_activeSubfigure = current; 
            m_rows = rows; 
            m_cols = columns; 
            return m_subfigures[m_activeSubfigure]; 
        }
        /// <summary>
        /// query a subfigure and set result as active subfigure
        /// </summary>
        /// <param name="key">the key of the subfigure</param>
        /// <returns>the subfigure</returns>
        public ILSubfigure this[int key] {
            get {
                if (m_subfigures.Contains(key)) {
                    //m_activeSubfigure = key; 
                    return m_subfigures[key];
                }
                throw new ILArgumentException("index outside of subfigure bounds!");
            }
        }
        /// <summary>
        /// Get subfigure by row and column and select as current subfigure
        /// </summary>
        /// <param name="row">location: row</param>
        /// <param name="col">location: column</param>
        /// <returns>subfigure on location specified. If row and/or column lay outside of bounds, 
        /// an exception will be thrown.</returns>
        public ILSubfigure this[int row, int col] {
            get {
                if (row * col < m_subfigures.Count) { 
                    m_activeSubfigure = m_rows * col + row;
                    return m_subfigures[m_activeSubfigure]; 
                } else 
                    throw new ILArgumentException("invalid key for subfigure!");
            }
        }
 
        #region ISerializable Member

        public void GetObjectData ( SerializationInfo info,StreamingContext context ) {
            //throw new Exception ( "The method or operation is not implemented." );
        }

        #endregion
                       
        #region private helper 

        private void ILFigureControl_Resize(object sender, EventArgs e) {
            ResizeSubfigures(ClientSize); 
        }
        private void ResizeSubfigures(System.Drawing.Size figureClientSize) {
            if (m_cols == 0 || m_rows == 0) return; 

            System.Drawing.Size isize = new System.Drawing.Size(
                                        ClientSize.Width / m_cols - Padding.Left - Padding.Right, 
                                        ClientSize.Height / m_rows - Padding.Top - Padding.Bottom); 
            foreach (ILSubfigure fig in m_subfigures.Figures) {
                fig.Size = isize-Padding.Size; 
            }
        }
        private void checkCreateSubfigure() {
            if (m_activeSubfigure < 0 || m_subfigures.Count == 0) {
                Tile(1,1,0); 
            }
        }

        #endregion
    }
}
