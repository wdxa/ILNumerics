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


namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// Provides access to all (device dependent) ILRenderer available 
    /// </summary>
    public class ILRendererManager {

        #region members / properties 
        
        Dictionary<string,string> m_rendererCollection; 
        Dictionary<string,IILTextRenderer> m_rendererCache; 
        GraphicDeviceType m_graphicsDevice;
        string m_defaultRendererScreen; 
        string m_defaultRendererWorld; 
        ILPanel m_panel; 
        #endregion 
        
        #region constructor
        /// <summary>
        /// create manager instance, device dependent
        /// </summary>
        /// <param name="panel">the hosting panel, will give access to this manager instance</param>
        /// <remarks>While creating ILTextRendereManager instances, the executing assembly will be queried for 
        /// available classes matching the device. Corresponding types are than provided by calling the GetRenderer() method.</remarks>
        public ILRendererManager (ILPanel panel) 
            : this(panel,new Assembly[] { Assembly.GetExecutingAssembly()} ) {
        }
        /// <summary>
        /// create manager instance, device dependent
        /// </summary>
        /// <param name="panel">The hosting panel, giving access to his manager instance</param>
        /// <param name="assemblies">assemblies to query for matching ILRenderer types</param>
        /// <remarks>While creating ILRendererManager instances, the given assemblies will be queried for 
        /// available classes matching the device. Corresponding types are than provided by calling the 
        /// GetRenderer() method.</remarks>
        public ILRendererManager (ILPanel panel, Assembly[] assemblies) {
            m_graphicsDevice = panel.GraphicDeviceType; 
            m_panel = panel; 
            m_rendererCollection = new Dictionary<string,string>();
            m_rendererCache = new Dictionary<string,IILTextRenderer>(); 
            foreach (Assembly ass in assemblies) {
                AddAssemblyTypes(ass); 
            }
            if (m_rendererCollection.Count == 0) 
                throw new InvalidOperationException("No valid ILRenderer found!"); 
        }
        #endregion

        #region public interface 

        /// <summary>
        /// Create a new ILRenderer instance, matching the current graphics device
        /// </summary>
        /// <param name="typeName">full class name of the new text renderer</param>
        /// <param name="assembly">assembly hosting the textrenderer, null for executing assembly</param>
        /// <returns>newly created ILRenderer instance from assembly</returns>
        public IILTextRenderer CreateInstance (string typeName, Assembly assembly) {
            if (typeName == null) 
                throw new ILArgumentException ("The type must be a valid ILTextRenderer!"); 
            string key = (assembly==null) 
                ? typeName : assembly.FullName +  "|" + typeName; 
            if (m_rendererCache.ContainsKey(key))
                return m_rendererCache[key]; 
            if (assembly == null) 
                assembly = Assembly.GetExecutingAssembly(); 
            Type type = assembly.GetType(typeName);
            if (type == null  || type.GetInterface("IILTextRenderer") == null)
                throw new ILArgumentException (String.Format(
                            "The type '{0}' was not found in assembly {1} or is not a valid IILTextRenderer!"
                            ,typeName,assembly)); 
            queryAddRenderer(type); 
            if (!m_rendererCollection.ContainsKey(key)) 
                throw new ILArgumentException("The renderer could not be loaded. Make sure, to specify the correct assembly and the type is properly decorated by the ILRendererAttribute!");
            IILTextRenderer ret = (IILTextRenderer)type.InvokeMember(
                          typeName, BindingFlags.DeclaredOnly | 
                          BindingFlags.Public | BindingFlags.NonPublic | 
                          BindingFlags.Instance | BindingFlags.CreateInstance, null, null, 
                          new object[] {m_panel});
            if (!m_rendererCache.ContainsKey(typeName)) {
                m_rendererCache[typeName] = ret;  
            }
            return ret; 
        }
        /// <summary>
        /// Create the default instance of IILTextRenderer for 
        /// the current graphics device and a coord system
        /// </summary>
        /// <param name="coords">coord system, the renderer is 
        /// specialized and the default renderer for</param>
        /// <returns>default IILTextRenderer object</returns>
        public IILTextRenderer GetDefault(CoordSystem coords) {
            string key = (coords == CoordSystem.World3D)  
                 ? m_defaultRendererWorld : m_defaultRendererScreen; 
            if (m_rendererCache.ContainsKey(key) && m_rendererCache[key] != null) 
                return m_rendererCache[key]; 
            // must create a new instance 
            IILTextRenderer ret; 
            switch (coords) {
                case CoordSystem.World3D:
                    ret = CreateInstance(m_defaultRendererWorld,null);
                    break; 
                default:
                    ret = CreateInstance(m_defaultRendererScreen,null);
                    break; 
            }
            m_rendererCache[key] = ret; 
            return ret; 
        }
        /// <summary>
        /// Get a collection of all IILTextRenderer types and corresponding displayNames available
        /// </summary>
        public IDictionary<string,string> RendererNames {
            get {
                IDictionary<string,string> ret = new Dictionary<string,string>(); 
                foreach (KeyValuePair<string,string> v in m_rendererCollection) {
                    ret.Add(v); 
                }
                return ret; 
            }
        }
        #endregion

        #region private helper
        /// <summary>
        /// iterate over types attribute, select IILTextRenderer attribute, 
        /// register for later reference, add/overwrite default renderers
        /// </summary>
        /// <param name="t">IILTextRenderer type</param>
        private void queryAddRenderer(Type t)
        {
            foreach (object att in t.GetCustomAttributes(false)) {
                if (att is ILRendererAttribute) {
                    ILRendererAttribute trAttr = (ILRendererAttribute)att; 
                    if (trAttr.GraphicDeviceType == m_graphicsDevice ||
                        trAttr.GraphicDeviceType == GraphicDeviceType.GDI) {
                        if (t.GetInterface("IILTextRenderer") == null)
                            continue; 
                        if (m_rendererCollection.ContainsKey(t.FullName)) 
                            m_rendererCollection[t.FullName] = trAttr.Name; 
                        else 
                            m_rendererCollection.Add(t.FullName,trAttr.Name); 
                        if (trAttr.IsDefault) {
                            if (trAttr.Coords == CoordSystem.Screen) 
                                m_defaultRendererScreen = t.FullName; 
                            else if (trAttr.Coords == CoordSystem.World3D)
                                m_defaultRendererWorld = t.FullName; 
                        }
                        break; 
                    }
                }
            }
        }

        private void AddAssemblyTypes (Assembly assembly) {
            try {
                Type[] types = assembly.GetTypes(); 
                foreach (Type t in types) {
                    queryAddRenderer(t);
                }
            } catch (Exception e) {
                m_rendererCollection.Add("ILNumerics.Drawing.Labeling.ILGDIRenderer","GDI Renderer"); 
                m_defaultRendererScreen = "GDI Renderer"; 
            }
        }

        #endregion
    }
}
