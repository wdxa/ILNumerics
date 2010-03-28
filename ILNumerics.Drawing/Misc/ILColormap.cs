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
using ILNumerics.Drawing.Internal;
using ILNumerics.BuiltInFunctions; 

namespace ILNumerics.Drawing.Misc {
    public class ILColormap {

        #region events 
        public event EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this,null); 
            }
        }
        #endregion

        #region attributes
        ILArray<float> m_map; 
        Colormaps m_type; 
        #endregion

        #region properties
        /// <summary>
        /// number of colors in the colormap
        /// </summary>
        public int Length {
            get {
                return m_map.Dimensions[0]; 
            }
        }
        /// <summary>
        /// The colormap type this colormap is based on (readonly)
        /// </summary>
        public Colormaps Type {
            get {
                return m_type; 
            }
        }
        /// <summary>
        /// retrieve / set internal data for color indices
        /// </summary>
        /// <remarks>colors will be a matrix of exactly 3 columns. Each element will range between 0.0 ... 1.0. 
        /// If in set access the matrix provided contains elements outside the range, the matrix will be normalized to fit into 0.0 ... 1.0.
        /// <para>The array returned will be a reference of the internal data only. It cannot be used to alter internal color table! In order to alter the color table, one can query the table, alter it outside and store it back than.</para></remarks>
        public ILArray<float> Data {
            get {
                return m_map.R;
            }
            set {
                if (! object.Equals (value,null) && !value.IsEmpty && value.IsMatrix && value.Dimensions[0] > 1 && value.Dimensions[1] == 3) {
                    ILArray<float> max = ILMath.maxall(value); 
                    ILArray<float> min = ILMath.minall(value); 
                    m_map = ((value - min) / (max-min)).C; 
                    OnChanged(); 
                }
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// construct new colormap, based on HLS model
        /// </summary>
        internal ILColormap () {
            m_map = MapCreator.CreateMap(Colormaps.Hsv);   
            m_type = Colormaps.Hsv; 
        }
        /// <summary>
        ///  create specific colormap
        /// </summary>
        /// <param name="map"></param>
        public ILColormap (Colormaps map) {
            m_map = MapCreator.CreateMap(map,128);
            m_type = map; 
        }
        /// <summary>
        /// create colormap based on predefined colors
        /// </summary>
        /// <param name="colors"></param>
        public ILColormap (ILArray<float> colors) {
            m_map = colors.R; 
            m_type = Colormaps.ILNumerics; 
        }
        #endregion

        #region public interface
        public Color this[double index] {
            get {
                return Map(index); 
            }
        }
        public Color Map(int index) {
            return Color.FromArgb(255,
                                (int)(m_map.GetValue(index,0)*255),
                                (int)(m_map.GetValue(index,1)*255),
                                (int)(m_map.GetValue(index,2)*255));
        }
        public Color Map(double index) {
            if (index >= m_map.Dimensions[0]-1) 
                return Map(m_map.Dimensions[0]-1); 
            if (index < 0) return Map(0); 
            int find = (int)Math.Floor(index); 
            if (find == index) 
                return Map(find); 
            // interpolate
            index = index - find; 
            float r1 = m_map.GetValue(find,0);
            float g1 = m_map.GetValue(find,1); 
            float b1 = m_map.GetValue(find,2); 
            r1 = (float)(index*(m_map.GetValue(find+1,0)-r1)+r1); 
            g1 = (float)(index*(m_map.GetValue(find+1,1)-g1)+g1); 
            b1 = (float)(index*(m_map.GetValue(find+1,2)-b1)+b1); 
            return Color.FromArgb(255,(int)(r1*255),(int)(g1*255),(int)(b1*255)); 
        }
        /// <summary>
        /// map all elements in A into final colors
        /// </summary>
        /// <param name="A">array with elements to map</param>
        /// <returns>colors as ILArray, the i-th row represents the color for the i-th element of A as RGB tripel.</returns>
        public ILArray<float> Map (ILArray<float> A) {
            ILArray<float> ret = new ILArray<float>(A.Dimensions.NumberOfElements,3); 
            float min = A.MinValue; 
            float dist = m_map.Dimensions[0] / (A.MaxValue - min);
            for (int i = 0; i < ret.Dimensions[0]; i++) {
                double index = (double)(A.GetValue(i)-min)*dist; 
                int find = (int)Math.Floor(index); 
                if (find == index) { 
                    ret[i,null] = m_map[i,null]; 
                }
                // interpolate
                index = index - find; 
                float r1 = m_map.GetValue(find,0);
                float g1 = m_map.GetValue(find,1); 
                float b1 = m_map.GetValue(find,2); 
                r1 = (float)(index*(m_map.GetValue(find+1,0)-r1)+r1); 
                g1 = (float)(index*(m_map.GetValue(find+1,1)-g1)+g1); 
                b1 = (float)(index*(m_map.GetValue(find+1,2)-b1)+b1); 
                ret.SetValue(r1,i,0); 
                ret.SetValue(g1,i,1); 
                ret.SetValue(b1,i,2); 
            }
            return ret; 
        }
        public void Map(double value, float[] vertices,ref int offset) {
            if (value >= m_map.Dimensions[0]-1) {
                vertices[offset++] = m_map.GetValue(m_map.Dimensions[0]-1,0); 
                vertices[offset++] = m_map.GetValue(m_map.Dimensions[0]-1,1); 
                vertices[offset++] = m_map.GetValue(m_map.Dimensions[0]-1,2); 
                return; 
            }
            if (value < 0) {
                vertices[offset++] = m_map.GetValue(0,0); 
                vertices[offset++] = m_map.GetValue(0,1); 
                vertices[offset++] = m_map.GetValue(0,2);
                return; 
            }
            int find = (int)Math.Floor(value); 
            if (find == value) {
                vertices[offset++] = m_map.GetValue(find,0); 
                vertices[offset++] = m_map.GetValue(find,1); 
                vertices[offset++] = m_map.GetValue(find,2); 
                return; 
            }
            // interpolate
            value = value - find; 
            float r1 = m_map.GetValue(find,0);
            float g1 = m_map.GetValue(find,1); 
            float b1 = m_map.GetValue(find,2); 
            r1 = (float)(value*(m_map.GetValue(find+1,0)-r1)+r1); 
            g1 = (float)(value*(m_map.GetValue(find+1,1)-g1)+g1); 
            b1 = (float)(value*(m_map.GetValue(find+1,2)-b1)+b1); 
            vertices[offset++] = r1; 
            vertices[offset++] = g1; 
            vertices[offset++] = b1; 
        }
        /// <summary>
        /// convert index value to color, interpolating
        /// </summary>
        /// <param name="value">index, position into color table, range 0...(Length-1). Values outer limits will be truncated.</param>
        /// <param name="r">out value: red component</param>
        /// <param name="g">out value: green component</param>
        /// <param name="b">out value: blue component</param>
        public void Map(double value, out byte r, out byte g, out byte b) {
            if (value >= m_map.Dimensions[0]-1) {
                r = (byte)(m_map.GetValue(m_map.Dimensions[0]-1,0)*255); 
                g = (byte)(m_map.GetValue(m_map.Dimensions[0]-1,1)*255); 
                b = (byte)(m_map.GetValue(m_map.Dimensions[0]-1,2)*255); 
                return; 
            }
            if (value < 0) {
                r = (byte)(m_map.GetValue(0,0)*255); 
                g = (byte)(m_map.GetValue(0,1)*255); 
                b = (byte)(m_map.GetValue(0,2)*255); 
                return; 
            }
            int find = (int)Math.Floor(value); 
            if (find == value) {
                r = (byte)(m_map.GetValue(find,0)*255); 
                g = (byte)(m_map.GetValue(find,1)*255); 
                b = (byte)(m_map.GetValue(find,2)*255); 
                return; 
            }
            // interpolate
            value = value - find; 
            float r1 = m_map.GetValue(find,0);
            float g1 = m_map.GetValue(find,1); 
            float b1 = m_map.GetValue(find,2); 
            r = (byte)((value*(m_map.GetValue(find+1,0)-r1)+r1)*255); 
            g = (byte)((value*(m_map.GetValue(find+1,1)-g1)+g1)*255); 
            b = (byte)((value*(m_map.GetValue(find+1,2)-b1)+b1)*255); 
            return; 
        }
        #endregion

        #region create maps
        internal class MapCreator : ILNumerics.BuiltInFunctions.ILMath {
            /// <summary>
            /// create colorpam of length 128
            /// </summary>
            /// <param name="map">map specification</param>
            /// <returns>colormap (matrix with size [len,3])</returns>
            internal static ILArray<float> CreateMap(Colormaps map) {
                return CreateMap(map,128); 
            }
            /// <summary>
            /// create colormap
            /// </summary>
            /// <param name="map">map specification</param>
            /// <param name="len">len of colormap</param>
            /// <returns>colormap (matrix with size [len,3])</returns>
            internal static ILArray<float> CreateMap(Colormaps map, int len) {
                ILArray<float> ret = null; 
                ILArray<double> retd; // helper var 
                int n; 
                switch (map) {
                    case Colormaps.Autumn:
                        ret = tosingle(horzcat(ones(len,1),linspace(0,1.0,len).T,zeros(len,1))); 
                        break;
                    case Colormaps.Bone:
                        ret = CreateMap( Colormaps.Hot)[":;end:-1:0"]; 
                        ret = (tosingle(repmat(linspace(0,1.0,len).T,1,3)*7.0) + ret)/8.0f;                        
                        break;
                    case Colormaps.Colorcube:
                        throw new NotImplementedException("ILColormap: sorry, colorcube must be implemented!"); 
                        break;
                    case Colormaps.Cool:
                        retd = horzcat(linspace(0,1.0,len).T,linspace(1.0,0.0,len).T,ones(len,1));
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.Copper:
                        retd = linspace(0,1.0,len).T; 
                        ret = ILArray<float>.empty(); 
                        ret = tosingle(min(1.0,retd*1.25)); 
                        ret[":;1"] = tosingle(retd*0.782); 
                        ret[":;2"] = tosingle(retd*0.4975); 
                        break;
                    case Colormaps.Flag:
                        retd = new double[,]{{1, 0, 0},{1, 1, 1},{0, 0, 1},{0, 0, 0}}; 
                        retd = repmat(retd.T,(int)ceil((double)len/retd.Dimensions[1]),1); 
                        ret = tosingle(retd[vector(0,len-1),null]); 
                        break;
                    case Colormaps.Gray:
                        ret = tosingle(repmat(linspace(0,1.0,len).T,1,3)); 
                        break;
                    case Colormaps.Hot:
                        n = (int)fix(len/8.0*3);
                        retd = zeros(len,3); 
                        ILArray<double> rng = vector(0,n-1); 
                        retd[rng,0] = linspace (0,1.0,n); 
                        retd[vector(n,len-1),0] = 1.0;
                        retd[rng+n,1] = linspace (0,1.0,n); 
                        retd[vector(2*n,len-1),1] = 1.0;
                        rng = vector(len-2*n,len-1); 
                        retd[rng,2] = linspace (0,1.0,rng.Length); 
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.Hsv:
                        n = len / 6; 
                        // red 
                        ILArray<double> peak = 2.0-abs(linspace(2,-2,4*n)); 
                        retd = zeros(len,3); 
                        retd[vector(len - peak.Length,len-1),0] = peak;
                        retd[vector(0  ,4*n-1),1] = peak;
                        retd[vector(0  ,2*n-1),2] = peak[vector(2*n,4*n-1)];  
                        retd[vector(len - 2*n,len-1),2] = peak[vector(0  ,2*n-1)];  
                        retd[retd > 1] = 1; 
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.ILNumerics:
                        ret = new ILArray<float>(len,3); 
                        int tmp; 
                        ILColorProvider cprov = new ILColorProvider(0.0f,0.5f,1.0f); 
                        rng = linspace(ILColorProvider.MAXHUEVALUE,0.0,len);
                        for (int i = 0; i < len; i++) {
                            tmp = cprov.H2RGB((float)rng[i]); 
                            ret.SetValue((float)(tmp>>16 & 255),i,0); 
                            ret.SetValue((float)(tmp>>8 & 255),i,1); 
                            ret.SetValue((float)(tmp & 255),i,2); 
                        }
                        ret /= 255.0f; 
                        break; 
                    case Colormaps.Jet:
                        n = len / 8; 
                        // red 
                        peak = 1.5-abs(linspace(1.5,-1.5,6*n)); 
                        retd = zeros(len,3); 
                        retd[vector(0  ,5*n-1),0] = peak[vector(n,6*n-1)];
                        retd[vector(n  ,7*n-1),1] = peak;
                        retd[vector(3*n,8*n-1),2] = peak[vector(0,5*n-1)];  
                        retd[retd > 1] = 1; 
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.Lines:
                        retd = randn(len,3); 
                        retd /= maxall(abs(retd)); 
                        ret = tosingle(1.0-abs(retd)); 
                        break;
                    case Colormaps.Pink:
                        ret = CreateMap(Colormaps.Hot,len); 
                        ret = sqrt((repmat(tosingle(linspace(0,1.0,len).T),1,3)*2.0f + ret)/3.0f); 
                        break;
                    case Colormaps.Prism:
                        retd = new double[,]{{1, 0, 0},{1, 0.5, 0},{1, 1, 0},{0, 1, 0},{0, 0, 1},{2/3.0, 0, 1}}; 
                        retd = repmat(retd.T,(int)ceil((double)len/retd.Dimensions[1]),1); 
                        ret = tosingle(retd[vector(0,len-1),null]); 
                        break;
                    case Colormaps.Spring:
                        retd = ones(len,1); 
                        retd[":;1"] = linspace(0.0,1.0,len); 
                        retd[":;2"] = linspace(1.0,0.0,len); 
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.Summer:
                        retd = linspace(0.0,1.0,len).T; 
                        retd[":;1"] = 0.5+retd/2.0;; 
                        retd[":;2"] = ones(len,1)*0.4; 
                        ret = tosingle(retd); 
                        break;
                    case Colormaps.White:
                        ret = tosingle(ones(len,3)); 
                        break;
                    case Colormaps.Winter:
                        retd = zeros(len,1); 
                        retd[":;2"] = 0.5+(1.0-linspace(0.0,1.0,len))/2.0; 
                        retd[":;1"] = linspace(0.0,1.0,len); 
                        ret = tosingle(retd); 
                        break;
                }
                return ret; 
            }
        }
        #endregion
    }
}
