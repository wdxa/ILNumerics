#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using ILNumerics.Storage;     
using ILNumerics.Exceptions;
using System.Collections.Generic; 

namespace ILNumerics.Misc
{
	/// <summary>
	/// ILDimension - dimensions for ILArray objects (immutable)
	/// </summary>
	/// <remarks>The class internally manages the dimensions of ILArray. 
    /// The class is immutable. Therefore, once created, it informs the user 
    /// about all dimension related properties, but cannot get altered.</remarks>
	[Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(),nq}")]
    public class ILDimension {
        
        #region attributes
        int [] m_dims; 
		int m_nrDims = 0;
		int m_numberOfElements = 0;
        int m_length = 0;
        int [] m_seqDistancesCache; 
        #endregion

        #region constructors
        /// <summary>
		///  create new ILDimension 
		/// </summary>
		/// <param name="dims">variable length dimensions specifier</param>
        /// <remarks>trailing singleton dimensions of dims will be kept.</remarks>
		public ILDimension (params int[] dims) 
            : this(false,dims) {}
        /// <summary>
        /// create new ILDimension, without trimming trailing singleton dimensions
        /// </summary>
        /// <param name="trimSingletons">true: trailing singleton 
        /// dimensions will be trimmed, false: those singleton dimensions will be kept.</param>
        /// <param name="dims">dimension lenght specifiers</param>
        public ILDimension (bool trimSingletons, params int[] dims)  {
			List<int> tmp = new List<int>(dims);
            while(tmp.Count < 2) tmp.Add(1); 
            if (trimSingletons) 
                for (int i = tmp.Count; i-->2;) {
                    if (tmp[i] == 1) tmp.RemoveAt(i); 
                    else break; 
                }
            m_dims = tmp.ToArray(); 
			m_numberOfElements = 1; 
            m_nrDims = m_dims.Length; 
            int t = 0, d; 
			for(; t < m_dims.Length; t++){
				d = m_dims[t]; 
                if (d > m_length) m_length = d;
                m_numberOfElements *= d; 
			}
        }
        /// <summary>		
		/// [obsolete] copy constructor
		/// </summary>
		/// <param name="newDim">ILDimension object to copy this object from</param>
        /// <remarks>This function is obsolete and will be removed in a future version. Resona: 
        /// ILDimension objects are immutable and can therefore savely be reused for 
        /// multiple arrays.</remarks>
        private ILDimension (ILDimension newDim) {
            m_nrDims = newDim.m_nrDims;
            m_numberOfElements = newDim.m_numberOfElements; 
            m_dims = new int[m_nrDims]; 
            m_length = newDim.m_length; 
            for (int i = 0; i < m_nrDims; i++) {
                m_dims[i] = newDim[i]; 
                if (m_length < m_dims[i]) m_length = m_dims[i]; 
            }
        }
        #endregion

        #region properties
        /// <summary>Get number of dimensions.</summary>
		public int NumberOfDimensions {
			get {
				return m_nrDims; 
			}
		}
        /// <summary>
        /// Number of non singleton dimensions this ILDimension is referencing
        /// </summary>
        /// <remarks>non singleton dimensions are dimensions which length is larger than 1. 
        /// Empty dimensions (length = 0) will not be take into account.</remarks>
        public int NonSingletonDimensions {
            get {
                int ret = 0;
                for (int i = 0; i < m_nrDims; i++) {
                    if (m_dims[i] > 1) ret++;
                }
                return ret;
            }
        }
		/// <summary>
		/// The number of elements the dimensions reference in an array of that size
		/// </summary>
		public int NumberOfElements {
			get {
				return m_numberOfElements;
			}
        }
        /// <summary>
		/// return longest dimension length
		/// </summary>
		public int Longest {
			get {
				return m_length; 
			}
		}
        /// <summary>
        /// find first non singleton dimension - if exist
        /// </summary>
        /// <returns>index of first non singleton dimension or -1, if this is a scalar.</returns>
        public int FirstNonSingleton() {
            if (m_numberOfElements <= 1) return -1; 
            for (int i = 0; i < m_nrDims; i++) {
                if (m_dims[i] > 1) return i; 
            }
            return -1; // this should not happen! Test on scalar above 
        }
        #endregion 

        #region public member
        /// <summary>
		/// Marks the number of elements between adjacent elementes of 
		/// each dimension as if the underlying storage was a dense storage.
		/// </summary>
		/// <param name="dim">dimension number to query the element distance for. The
		/// first dimension has index 0 ('zero')!</param>
		/// <returns>number of elements between adjacent elements of dimension dim.
        /// </returns>
        /// <remarks>if dimension index dim is larger than the number of 
        /// dimensions inside this ILDimension, the number of elements will 
        /// be returned (assuming the trailing dimensions to be 1).</remarks>
		public int SequentialIndexDistance(int dim) {
            if (dim == m_nrDims)
                return m_numberOfElements; 
            dim %= m_nrDims; 
            int ret = 1; 
            for (int i = 0; i < dim && i < m_nrDims; i++) {
                ret *= m_dims[i];
            }
			return ret; 
		}
        /// <summary>
        /// distances between adjacent elements for all dimensions
        /// </summary>
        /// <param name="minLength">minimum length of array to be 
        /// returned. If this is larger than the number of dimensions 
        /// in this ILDimension, the array will have minLength elements, 
        /// with elements outside this dimensions repeating the value 
        /// of the last dimension. The length of the array returned will 
        /// be equal or greater than max(minLength,NumberOfDimensions).</param>
        /// <remarks>This is provided for performance reasons and should be 
        /// used internally only. It enables developer of index access routines 
        /// to cache the elements distances directly inside their functions 
        /// without having to query the info on every index access.
        /// <para>Keep in mind, only the distances for the number of my 
        /// dimensions are returned. Higher dimensions must be set to 
        /// NumberOfElements if needed. This is different than querying 
        /// the distances by SequentialIndexDistance(int), which will assume 
        /// and return trailing dimensions to be 1.</para></remarks>
		internal int[] GetSequentialIndexDistances(int minLength) {
            minLength = Math.Max(m_nrDims,minLength);
            if (m_seqDistancesCache == null || m_seqDistancesCache.Length < minLength){
                m_seqDistancesCache = new int[minLength]; 
                int tmp = 1, i = 0; 
                for (; i < m_nrDims; i++) {
                    m_seqDistancesCache[i] = tmp; 
                    tmp *= m_dims[i];
                }
                for (; i < m_seqDistancesCache.Length; i++) {
                    m_seqDistancesCache[i] = tmp; 
                }
            }
	        return m_seqDistancesCache; 
        }
		/// <summary>
		/// transfer my dimensions to integer array 
		/// </summary>
		/// <returns>integer array containing a copy of dimensions length</returns>
		public int[] ToIntArray(){
			return (int[])m_dims.Clone(); 
		}
		/// <summary>
		/// transfer my dimensions to integer array 
		/// </summary>
        /// <param name="length">minimum length of output array. If length 
        /// is larger than my dimensions, trailing ones will be added.</param>
		/// <returns>integer array containing a copy of dimensions length. 
        /// Trailing elements outside my dims will be one.</returns>
		internal int[] ToIntArray (int length) {
			int[] ret; 
            ret = new int[length > m_nrDims ? length : m_nrDims];
			Array.Copy(m_dims,0,ret,0,m_nrDims);
            for (int i = m_nrDims; i < length; i++) {
                ret[i] = 1; 
            }
			return ret; 
		}
		/// <summary>
		/// Translate indices from int[] Array to sequential storage access 
        /// in my dimensions
		/// </summary>
		/// <param name="idx">int array of nrDims length</param>
		/// <returns>Index number pointing to the value's position in 
        /// sequential storage.</returns>
		public int IndexFromArray(int[] idx) {
			try {
				int faktor = m_dims[0]; 
				int ret = idx[0]; 
				if (ret > faktor || ret < 0)
                    throw new Exception("check value at dimension 0!"); 
                int d = 1,tmp;
				if (idx.Length < 2) {
					if (idx.Length == 0) return 0; 
					return ret; 
				}
				for (; d<idx.Length-1; d++) {
                    tmp = idx[d]; 
                    if (tmp > m_dims[d] || tmp < 0)
                        throw new Exception("check value at dimension "+d+"!"); 

					ret += tmp * faktor; 
					faktor *= m_dims[d]; 
				}
				ret += idx[d] * faktor;
				return ret; 			
			} catch (Exception e) {
				throw new ArgumentException ("Indices must match array dimension!",e);
			}
		}
		/// <summary>
		/// Transform dimension position into sequential index, gather expand 
        /// information
		/// </summary>
		/// <param name="idx">int array of arbitrary length</param>
        /// <param name="MustExpand">[output] true, if the indices 
        /// given address an element outside of 
        /// this dimensions size. In this case, the output parameter 
        /// 'Dimensions' carry the sizes 
        /// of new dimensions needed. False otherwise</param>
        /// <param name="Dimensions">sizes of dimension if expansion is needed</param>
		/// <returns>Index number pointing to the value's position in 
        /// sequential storage.</returns>
        /// <remarks>no checks are made for idx to fit inside dimensions! 
        /// This functions is used for left side assignments. Therefore it 
        /// computes the destination index also if it lays outside 
        /// the array bounds.</remarks>
		internal int IndexFromArray(ref bool MustExpand, ref int[] Dimensions, int[] idx) {
            if (idx.Length < m_nrDims) {
                // expanding is allowed for all but the last specified dimension
                int d = 0, tmp = idx[0], faktor = 1; 
			    int ret = 0; 
                while (d < idx.Length-1) {
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_dims[d]) {
                        Dimensions[d] = tmp+1; 
                        MustExpand = true; 
                        ret += (faktor * tmp); 
                        faktor *= tmp+1; 
                    } else {
                        ret += (faktor * tmp); 
                        faktor *= m_dims[d]; 
                    }
                    tmp = idx[++d];
                }
                while (d < m_nrDims) {
                    ret += faktor * ((tmp % m_dims[d])); 
                    tmp /= m_dims[d]; 
                    faktor *= m_dims[d++]; 
                }
                if (tmp > 0) 
                    throw new ILArgumentException("expanding is allowed for explicitly bounded dimensions only! You must specify indices into all existing dimensions."); 
                return ret;
			} else if (idx.Length == m_nrDims) {
                // expanding is allowed for all dimensions 
                int d = 0, tmp, faktor = 1; 
			    int ret = 0; 
                while (d < idx.Length) {
                    tmp = idx[d];
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_dims[d]) {
                        Dimensions[d] = tmp+1; 
                        MustExpand = true; 
                        ret += (faktor * tmp); 
                        faktor *= tmp+1; 
                    } else {
                        ret += (faktor * tmp); 
                        faktor *= m_dims[d]; 
                    }
                    d++; 
                }
                return ret;
			} else {
                // idx dimensions are larger than my dimensions
                int d = 0, tmp = idx[0], faktor = 1; 
			    int ret = 0; 
                while (d < m_nrDims) {
                    tmp = idx[d];
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_dims[d]) {
                        Dimensions[d] = tmp+1; 
                        MustExpand = true; 
                        ret += (faktor * tmp); 
                        faktor *= tmp+1; 
                   } else { 
                        ret += (faktor * tmp); 
                        faktor *= m_dims[d]; 
                    }
                    d++; 
                }
                while (d < idx.Length) {
                    tmp = idx[d]; 
                    if (tmp > 0) {
                        Dimensions[d] = tmp +1; 
                        MustExpand = true; 
                    }
                    d++; 
                    faktor *= tmp; 
                    ret += faktor; 
                }
                return ret; 
            }
		}
		/// <summary>
		/// Unshift dimensions of indices from int[] Array 
        /// and translate to index for sequential storage access 
        /// in my dimensions </summary>
		/// <param name="idx">int array of the same length as 
        /// the number of dimensions of this storage. Indices must 
        /// lay within my dimensions.</param>
		/// <param name="unshift">number of dimensions to unshift 
        /// idx before computing index</param>
		/// <returns>Index number pointing to the value's position 
        /// in sequential storage.</returns>
		/// <remarks> If idx contains elements (indices) larger than 
        /// my dimension bounds, an exception will be thrown. If unshift 
        /// is 0, the length of idx may be smaller than the length of 
        /// my dimensions. However, with unshift &gt; 0 the result 
		/// is undefined.</remarks>
		public int IndexFromArray(int[] idx, int unshift) {
			unshift %= m_nrDims;
			int faktor = m_dims[0];
			int ret = idx[(-unshift) % m_nrDims]; 
			int d = 1;
			for (; d<idx.Length; d++) {
				ret += idx[(-unshift + d) % m_nrDims] * faktor; 
				faktor *= m_dims[d]; 
			}
			return ret; 			
		}
		/// <summary>
		/// Clone ILDimension object. 
		/// </summary>
		/// <return>
		/// New ILDimension object as exact copy of this object.
		/// </return>
		private ILDimension Clone() {
			ILDimension ret = new ILDimension(this); 
			return ret;
		}
		/// <summary>
		/// [deprecated] Shift this ILDimension
		/// </summary>
		/// <param name="shift">number of dimensions to shift.</param>
		/// <remarks>this will not alter this object anymore but return the shifted version!
        /// The function will be removed in a future release! Use 
        /// ILDimension.GetShiftedVersion() instead!</remarks>
		private ILDimension Shift (int shift) {
		    return GetShifted(shift); 
        }
		/// <summary>
		/// return shifted version
		/// </summary>
		/// <param name="shift">number of dimensions to shift. The value
        /// will be considered modules the number of dimensions of 
        /// this ILDimension.</param>
		/// <returns>shifted version of this ILDimension object.</returns>
		public ILDimension GetShifted(int shift){ 
			shift %= m_nrDims; 
			int [] tmp = new int [m_nrDims]; 
			int id;
            for (int d = 0; d < m_nrDims; d++) {
                id = (d + shift) % m_nrDims;
                tmp[d] = m_dims[id];
            }
			return new ILDimension(tmp);
		}
        /// <summary>
        /// Get length for dimension specified (Readonly)
        /// </summary>
        /// <param name="idx">index of dimension</param>
        /// <returns>length of dimension specified by idx</returns>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if idx is negative</exception>
        /// <remarks><para>for idx corresponds to an existing dimension, 
        /// the length of that dimension is returned. If idx is larger than 
        /// the number of dimensions 1 is returned. </para>
        /// </remarks>
        public int this [int idx] {
			get {
				if (idx < 0) 
					throw new ArgumentOutOfRangeException("index","Index out of Range!");
				else if (idx >= m_nrDims) {
                    return 1; 
                }
				return m_dims[idx];
			}
		}
		/// <summary>
		/// Compares the size of this dimension to another dimension object. 
		/// </summary>
		/// <param name="dim2">ILDimension object to compare this to.</param>
		/// <returns>Returns true if the sizes are the same, else returns false. 
		/// The comparison is made by recognizing singleton dimensions. Therefore 
		/// only non singleton dimensions are compared in the order of their 
		/// appearance. </returns>
        /// <remarks>The function reutrns true, if the squeezed dimensions of 
        /// both ILDimensions match.</remarks>
		public bool IsSameSize(ILDimension dim2) { 
			if (dim2.NumberOfElements != m_numberOfElements) return false; 
			for (int d2 = dim2.NumberOfDimensions,d1 = m_nrDims;d1 >= 0;) {
				d1--; d2--;
				while (d1 >= 0 && m_dims[d1]== 1) d1--; 
				while (d2 >= 0 && dim2[d2]  == 1) d2--; 
				if (d1 >= 0 && d2 >= 0) {
					if (m_dims[d1] != dim2[d2]) 
						return false;

				}
			}
			return true;
		}
		/// <summary>
		/// Compares the shape of this dimension to another dimension object 
		/// </summary>
		/// <param name="dim2">ILDimension object to compare this to.</param>
		/// <returns>Returns true if the shapes are the same, else returns false. </returns>
        /// <remarks>This function is more strict than IsSameSize. In order 
        /// for two dimensions to have the same shape, ALL dimensions must match - 
        /// even singleton dimensions.</remarks>
		public bool IsSameShape(ILDimension dim2) { 
            if (dim2.NumberOfElements != m_numberOfElements) return false; 
            if (dim2.NumberOfDimensions != m_nrDims) return false; 
			for (int d1 = m_nrDims;d1-->0;) { 
				if (m_dims[d1] != dim2.m_dims[d1]) 
					return false;
			}
			return true;
		}
		/// <summary>
		/// [deprecated] Create copy of this ILDimension having all singleton 
        /// dimensions removed.
		/// </summary>
		/// <returns>a squeezed copy</returns>
        /// <remarks>This function is deprecated. Use the ILDimension.Squeeze()
        /// memeber instead. </remarks>
		public ILDimension GetSqueezed() {
			return Squeeze();
		}
		/// <summary>
		/// Create and return copy without singleton dimensions
		/// </summary>
		/// <returns>Copy of this ILDimension having all singleton dimensions removed.</returns>
		/// <remarks> This function does not alter this object (since ILDimension is 
        /// immutable).
        /// <para>All arrays in ILNumerics.Net have at least 2 dimensions. 
        /// Therefore all but the first two singleton dimensions can be removed.</para>
        /// </remarks>
		public ILDimension Squeeze() {
            List<int> tmp = new List<int>(); 
            foreach (int d in m_dims) {
                if (d != 1) tmp.Add(d); 
            }
            while (tmp.Count < 2) { 
                tmp.Add(1); 
            }
			return new ILDimension(tmp.ToArray());
		}
		/// <summary>
		/// Return ILDimension having trailing singleton dimensions removed
		/// </summary>
		/// <returns>Copy without trailing singleton dimensions</returns>
		/// <remarks> this object will NOT be altered. As usual for all ILArrays, 
        /// the result wil have at least 2 dimensions.</remarks>
		public ILDimension Trim() {
            if (m_nrDims == 2 || m_dims[m_nrDims-1] != 1) {
                return this; 
            }
            int i = m_nrDims; 
            for (; i-->2; ) if (m_dims[i] != 1) break; 
            int[] newdims = new int[++i]; 
			System.Array.Copy(m_dims,0,newdims,0,i);
            return new ILDimension(newdims);
        }
		/// toString: prints out dimensions 
		public override String ToString (){
			String s = "[";
			for (int t = 0; t < m_nrDims; t++) {
				s = s + m_dims[t];
				if (t < m_nrDims -1 ) 
					s = s + ",";
			}
			s = s + "]"; 
			return s;
        }
        #endregion 

    }
}
