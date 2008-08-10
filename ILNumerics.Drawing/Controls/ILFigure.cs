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
using System.Windows.Forms; 
using ILNumerics.Exceptions;
using ILNumerics.Drawing.Internal;
using ILNumerics.Drawing.Collections; 

namespace ILNumerics.Drawing.Controls {
    /// <summary>
    /// Stand alone figure form - capable of displaying subfigure(s)
    /// </summary>
    public partial class ILFigure : Form {

        #region attributes
        static int FiguresCount = 0;
        static IDictionary<int,ILFigure> Figures = new Dictionary<int,ILFigure>(); 
        private int m_key; 
        ILControl m_figControl;
        private bool m_wasMaximumSized; 
        #endregion

        #region constructor
        /// <summary>
        /// create new ILFigure form
        /// </summary>
        public ILFigure() {
            InitializeComponent(); 
            register(); 
            Text = "Figure " + m_key.ToString();
            m_wasMaximumSized = (WindowState == FormWindowState.Maximized);
            Tile(1,1,0);
        }
        #endregion

        #region properties
        /// <summary>
        /// get current active subfigure
        /// </summary>
        public ILSubfigure ActiveSubfigure {
            get{
                return m_figControl.Subfigure; 
            }
            set {
                m_figControl.Subfigure = value; 
            }
        }
        /// <summary>
        /// Get collection of subfigures
        /// </summary>
        public ILSubfigureCollection Subfigures {
            get {
                return m_figControl.Subfigures; 
            }
        }
        #endregion
       
        #region public methods
        /// <summary>
        /// Tile this figure into rows and columns to display multiple subfigures 
        /// </summary>
        /// <param name="rows">rows</param>
        /// <param name="columns">columns</param>
        /// <param name="current">newly active subfigure (sequential index)</param>
        /// <returns>newly selected active subfigure</returns>
        public ILSubfigure Tile(int rows, int columns, int current) {
            return m_figControl.Tile(rows,columns,current); 
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
                return m_figControl[row,col]; 
            }
        }
        /// <summary>
        /// query subfigure by index (sequential)
        /// </summary>
        /// <param name="key">key to identify subfigure</param>
        /// <returns>subfigure identified by key</returns>
        public ILSubfigure this[int key] {
            get {
                return m_figControl[key]; 
            }
        }
        //public Bitmap DrawToBitmap() {
        //    Bitmap ret = new Bitmap(this.Width,this.Height); 
        //    Graphics gr = Graphics.FromImage(ret); 
        //    this.Activate(); 
        //    gr.CopyFromScreen(this.Location,new Point(),this.Size); 
        //    gr.Dispose(); 
        //    return ret; 
        //}
        #endregion
        
        #region private helper
        private void InitializeComponent ( ) {
            this.SuspendLayout ( );
            // 
            // ILFigure
            // 
            this.BackColor = System.Drawing.Color.FromArgb ( (( int ) ((( byte ) (244)))),(( int ) ((( byte ) (244)))),(( int ) ((( byte ) (244)))) );
            this.ClientSize = new System.Drawing.Size ( 476,353 );
            this.Name = "ILFigure";
            this.Padding = new System.Windows.Forms.Padding ( 3 );
            this.FormClosed += new FormClosedEventHandler(ILFigure_FormClosed);
            this.Resize += new System.EventHandler ( this.ILFigure_Resize );
            this.Shown += new System.EventHandler ( this.ILFigure_ResizeEnd );
            this.ResizeEnd += new System.EventHandler ( this.ILFigure_ResizeEnd );
            this.ResumeLayout ( false );
            m_figControl = new ILControl(); 
            Controls.Add(m_figControl); 
        }

        void ILFigure_FormClosed(object sender, FormClosedEventArgs e) {
            unregister(); 
        }
        private void ILFigure_ResizeEnd ( object sender,EventArgs e ) {
            resize(); 

        }
        private void ILFigure_Resize ( object sender,EventArgs e ) {
            if (this.WindowState == FormWindowState.Maximized) {
                m_wasMaximumSized = true; 
                resize(); 
            } else {
                if (m_wasMaximumSized) {
                    resize(); 
                    m_wasMaximumSized = false; 
                }
            }
        }
        private void resize() {
            m_figControl.Width = this.ClientSize.Width - this.Padding.Right - this.Padding.Left;
            m_figControl.Height = this.ClientSize.Height - this.Padding.Top - this.Padding.Bottom; 
        }
        private void register() {
            m_key =  ++FiguresCount; 
            Figures[m_key] = this; 
        }
        private void unregister() {
            FiguresCount--; 
            Figures.Remove(m_key); 
        }
        #endregion

    }
}
