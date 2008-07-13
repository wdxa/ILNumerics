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

namespace ILNumerics.Drawing {
    /// <summary>
    /// Drawing exception
    /// </summary>
    public class ILDrawingException : Exception {
        /// <summary>
        /// create new drawing exception
        /// </summary>
        /// <param name="message">message</param>
        public ILDrawingException(string message) : base(message) { }
        /// <summary>
        /// create new drawing exception
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">inner (nested) exception</param>
        public ILDrawingException(string message, Exception innerException) : base(message,innerException) { }
    }
}
