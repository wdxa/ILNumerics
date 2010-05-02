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
using ILNumerics.Drawing.Collections; 

namespace ILNumerics.Drawing.Lighting {
    public class ILLight {

        #region eventing
        public EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this, new EventArgs()); 
            }
        }
        #endregion

        #region attributes
        private bool m_enabled;
        private int m_index;
        private ILPoint3Df m_position;
        private Color m_specular;
        private Color m_emission;
        private Color m_ambient;
        private Color m_diffuse;
        #endregion

        #region properties
        public bool Enabled {
            get { return m_enabled; }
            set { 
                m_enabled = value; 
                OnChanged(); 
            }
        }
        public int Index {
            get { return m_index; }
        }
        public ILPoint3Df Position {
            get { return m_position; }
            set { 
                m_position = value;  
                OnChanged(); 
            }
        }
        public Color Specular {
            get { return m_specular; }
            set { 
                m_specular = value;  
                OnChanged(); 
            }
        }
        public Color Ambient {
            get {
                return m_ambient; 
            } 
            set {
                m_ambient = value; 
                OnChanged(); 
            }
        }
        public Color Diffuse {
            get {
                return m_diffuse; 
            } 
            set {
                m_diffuse = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructors
        public ILLight (int index) {
            m_enabled = index == 0; 
            m_index = index; 
            Position = new ILPoint3Df(-10f,-100f,200);
            Specular = Color.FromArgb(255,255,255);
            Ambient = Color.FromArgb(90,90,90); 
            Diffuse = Color.FromArgb(160,160,160);  
        }
        #endregion

        #region public interface

        #endregion

        #region private helpers

        #endregion



    }
}
