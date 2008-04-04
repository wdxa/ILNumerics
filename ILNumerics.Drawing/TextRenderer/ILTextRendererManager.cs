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
using System.Reflection; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Exceptions; 
using ILNumerics.Drawing.Controls; 


namespace ILNumerics.Drawing.TextRenderer {
    /// <summary>
    /// Provides access to all (device dependent) TextRenderer available for plotting
    /// </summary>
    public class ILTextRendererManager {

        #region members / properties 
        
        Dictionary<string,string> m_textRendererCollection; 
        GraphicDeviceType m_graphicsDevice;
        string m_defaultRenderer; 
        object m_glContext; 
        #endregion 
        
        #region constructor
        /// <summary>
        /// create manager instance, device dependent
        /// </summary>
        /// <param name="type">graphics device, only TextRenderer mathing this device will be available</param>
        /// <remarks>While creating ILTextRendereManager instances, the executing assembly will be queried for 
        /// available classes matching the device. Corresponding types are than provided by calling the GetTextRenderer() method.</remarks>
        public ILTextRendererManager (ILPanel panel, object gContext) 
            : this(panel,gContext,new Assembly[] { Assembly.GetExecutingAssembly()} ) {
        }
        /// <summary>
        /// create manager instance, device dependent
        /// </summary>
        /// <param name="graphicsdevice">graphics device, only TextRenderer mathing this device will be available</param>
        /// <param name="assemblies">assemblies to query for matching TextRenderer types</param>
        /// <remarks>While creating ILTextRendererManager instances, the given assemblies will be queried for 
        /// available classes matching the device. Corresponding types are than provided by calling the 
        /// GetTextRenderer() method.</remarks>
        public ILTextRendererManager (ILPanel panel, object gContext, Assembly[] assemblies) {
            m_graphicsDevice = panel.GraphicDeviceType; 
            m_glContext = gContext; 
            m_textRendererCollection = new Dictionary<string,string>();
            foreach (Assembly ass in assemblies) {
                AddAssemblyTypes(ass); 
            }
            if (m_textRendererCollection.Count == 0) 
                throw new InvalidOperationException("No valid TextRenderer found!"); 
        }
        #endregion

        #region public interface 

        /// <summary>
        /// Create a new TextRenderer instance, matching the current graphics device
        /// </summary>
        /// <param name="typeName">full class name of the new text renderer</param>
        /// <param name="assembly">assembly hosting the textrenderer, null for executing assembly</param>
        /// <returns>newly created TextRenderer instance from assembly</returns>
        public IILTextRenderer CreateInstance (string typeName, Assembly assembly) {
            if (typeName == null) 
                throw new ILArgumentException ("The type must be a valid TextRenderer!"); 
            if (assembly == null) 
                assembly = Assembly.GetExecutingAssembly(); 
            Type type = assembly.GetType(typeName); 
            if (type == null  || type.GetInterface("IILTextRenderer") == null)
                throw new ILArgumentException (String.Format(
                            "The type '{0}' was not found in assembly {1} or is not a valid TextRenderer!"
                            ,typeName,assembly)); 
            if (!m_textRendererCollection.ContainsKey(typeName))
                throw new ILArgumentException ("The type is not a valid TextRenderer!"); 
            return (IILTextRenderer)type.InvokeMember(
                typeName, BindingFlags.DeclaredOnly | 
                          BindingFlags.Public | BindingFlags.NonPublic | 
                          BindingFlags.Instance | BindingFlags.CreateInstance, null, null, 
                          new object[] {m_glContext,null});
        }
        /// <summary>
        /// Create the default instance of ILTextRenderer for this graphics device
        /// </summary>
        /// <returns>default ILTextRenderer object</returns>
        public IILTextRenderer GetDefault() {
            return CreateInstance(m_defaultRenderer,null);         
        }
        /// <summary>
        /// Get a collection of all TextRenderer types and corresponding displayNames available
        /// </summary>
        public IDictionary<string,string> RendererNames {
            get {
                IDictionary<string,string> ret = new Dictionary<string,string>(); 
                foreach (KeyValuePair<string,string> v in m_textRendererCollection) {
                    ret.Add(v); 
                }
                return ret; 
            }
        }
        #endregion

        #region private helper

        private void AddAssemblyTypes (Assembly assembly) {
            try {
                Type[] types = assembly.GetTypes(); 
                foreach (Type t in types) {
                    foreach (object att in t.GetCustomAttributes(false)) {
                        if (att is ILTextRendererAttribute) {
                            ILTextRendererAttribute trAttr = (ILTextRendererAttribute)att; 
                            if (trAttr.GraphicDeviceType == m_graphicsDevice ||
                                trAttr.GraphicDeviceType == GraphicDeviceType.GDI) {
                                if (t.GetInterface("IILTextRenderer") == null)
                                    continue; 
                                if (m_textRendererCollection.ContainsKey(t.FullName)) 
                                    throw new InvalidOperationException(String.Format("multiple types for TextRenderer found! The type {0} is already loaded.",t.FullName)); 
                                m_textRendererCollection.Add(t.FullName,trAttr.Name); 
                                if (trAttr.IsDefault || m_defaultRenderer == null) 
                                    m_defaultRenderer = t.FullName; 
                                break; 
                            }
                        }
                    }
                }
            } catch (Exception e) {
                m_textRendererCollection.Add("ILNumerics.Drawing.TextRenderer.ILGDIRenderer","GDI Renderer"); 
                m_defaultRenderer = "GDI Renderer"; 
            }
        }
        #endregion
    }
}
