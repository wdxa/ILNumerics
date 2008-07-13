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

namespace ILNumerics.Drawing.Collections {
    
    /// <summary>
    /// Collection of all subfigures contained in an ILFigureControl
    /// </summary>
    [Serializable]
    public class ILSubfigureCollection {

        #region attributes 
        private Dictionary<int,ILSubfigure> m_subfigures;
        #endregion

        #region constructor
        /// <summary>
        /// create new ILSubfigureCollection
        /// </summary>
        public ILSubfigureCollection() {
            m_subfigures = new Dictionary<int,ILSubfigure>();
        }
        #endregion

        #region indexer
        /// <summary>
        /// Get / set subfigure by key
        /// </summary>
        /// <param name="key">key of subfigure</param>
        /// <returns>subfigure specified by key</returns>
        /// <value>subfigure to be stored into the collection</value>
        public ILSubfigure this[int key] {
            get {
                if (!m_subfigures.ContainsKey(key)) 
                    throw new ILArgumentException("ILSubfigureCollection: subfigure key not found!");
                return m_subfigures[key]; 
            } 
            set {
                if (!m_subfigures.ContainsKey(key)) 
                    m_subfigures.Add(key, value); 
                else 
                    m_subfigures[key] = value; 
            }
        }
        #endregion

        #region properties
        /// <summary>
        /// number of subfigures currently stored in the collection
        /// </summary>
        public int Count {
            get {
                return m_subfigures.Count; 
            }
        }
        #endregion

        #region public interface 
        /// <summary>
        /// Add subfigure to subfigure collection
        /// </summary>
        /// <param name="key">the key to identify the new subfigure</param>
        /// <param name="subfigure">the new subfigure</param>
        /// <remarks>If a subfigure with the key already exist in the collection, 
        /// it will be replaced by the new subfigure</remarks>
        public void Add(int key, ILSubfigure subfigure) {
            if (!m_subfigures.ContainsKey(key))
                m_subfigures.Add(key,subfigure); 
            else 
                m_subfigures[key] = subfigure; 
        }
        /// <summary>
        /// get all keys for all subfigures as key collection
        /// </summary>
        public Dictionary<int,ILSubfigure>.KeyCollection Keys {
            get {
                return m_subfigures.Keys;
            }
        }
        /// <summary>
        /// Get all subfigures as value collection
        /// </summary>
        public Dictionary<int, ILSubfigure>.ValueCollection Figures {
            get {
                return m_subfigures.Values; 
            }
        }
        /// <summary>
        /// Determine if a subfigure with the key given exist
        /// </summary>
        /// <param name="key">key of subfigure</param>
        /// <returns>true if a subfigure with the given key exists, false otherwise</returns>
        public bool Contains (int key) {
            return m_subfigures.ContainsKey(key); 
        }
        /// <summary>
        /// Reduce the number of subfigures to the given number
        /// </summary>
        /// <param name="number">number of subfigures to remain</param>
        /// <remarks>If more than number subfigures exist, they will be removed. Highest keys will be removed first.</remarks>
        public void Purge (int number) {
            int[] keys = new int[m_subfigures.Count];
            m_subfigures.Keys.CopyTo(keys,0);  
            System.Array.Sort(keys); 
            for (int i = number; i < keys.Length; i++) {
                m_subfigures.Remove(keys[i]); 
            }
        }
        #endregion
    }
}
