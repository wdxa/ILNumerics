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
using System.Windows.Forms; 

namespace ILNumerics.Drawing.Controls {
    public class ILTextBoxAutoHide : TextBox {

        public event EventHandler Committing; 
        protected void OnCommit() {
            if (Committing != null) {
                Committing(this,new EventArgs()); 
            }
        }

        public ILTextBoxAutoHide () : base () {
            BorderStyle = BorderStyle.None; 
            TextAlign = HorizontalAlignment.Center; 
        }
        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            SelectAll(); 
        }
        
        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            this.Hide(); 
        }
        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Enter) { 
                OnCommit(); 
                Hide();
            } else if (e.KeyChar == (char)Keys.Escape) {
                Hide();     
            }

        }
    }
}
