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

namespace ILNumerics.Drawing.Lighting {
    public class ILMaterial {

        #region attributes
        byte m_shininess;
        Color m_specular;
        Color m_emission; 
        #endregion

        #region properties
        /// <summary>
        /// shape/intensity for specular reflection, range: 1...128
        /// </summary>
        public byte Shininess {
            get { return m_shininess; }
            set { m_shininess = value; }
        }
        /// <summary>
        /// color for specular reflection
        /// </summary>
        public Color Specular {
            get { return m_specular; }
            set { m_specular = value; }
        }
        /// <summary>
        /// color for emissive reflection
        /// </summary>
        public Color Emission {
            get { return m_emission; }
            set { m_emission = value; }
        }
        #endregion

        #region public interface
        /// <summary>
        /// construct new material object, initialize default values
        /// </summary>
        public ILMaterial() {
            m_shininess = (byte)96;
            m_specular = Color.FromArgb(255, Color.Gray);
            m_emission = Color.FromArgb(255, Color.Black); 
        }
        #endregion

        #region private helpers

        #endregion
    }
}
