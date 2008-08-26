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

namespace ILNumerics.Misc
{
	/// <summary>
	/// ILDimension - specify dimensions for ILArray objects.
	/// </summary>
	/// <remarks>The class internally manages the dimensions of ILArray. 
    /// The class is immutable. Therefore, once created, it informs the user 
    /// about all dimension related properties, but cannot be altered.</remarks>
	[Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(),nq}")]
    public class ILDimension
	{
		int [] m_dims; 
		int m_nrDims = 0;
		int m_numberOfElements = 0;
        int m_length = 0; 
		/// <summary>
		///  construct vector dimensions
		/// </summary>
		/// <param name="dims">variable length for dimsensions. 
		/// exmpl: 2,3,2,4 </param>
		public ILDimension (params int[] dims){
            if (dims.Length == 0) 
				throw new ArgumentOutOfRangeException("dims","dimensions must not be empty!");
			else {
				// create dimensions 
                int curDim = 0;  
				if (dims.Length > 1) {
					m_dims  = dims;  // do NOT copy this!! 
					m_nrDims = dims.Length;
				} else if (dims.Length == 1) {
					m_dims  = new int[2]; 
					m_dims[1] = 1; 
                    m_dims[0] = dims[0]; 
					m_nrDims = 2;
				} else {
					m_dims  = new int[2]; 
					m_dims[1] = 0; 
                    m_dims[0] = 0; 
					m_nrDims = 2;
                }
				m_numberOfElements = 1; 
                int t = 0; 
				for(; t < m_dims.Length; t++){
					curDim = m_dims[t]; 
                    if (curDim > m_length) m_length = curDim;
                    m_numberOfElements *= curDim; 
				}
                // if last dimension is singleton -> must be trimmed
                if (m_dims[t-1] == 1) 
                    Trim(); 
                if (m_numberOfElements == 0) {
                    // dimension object for empty array
                    m_nrDims = 2;
                    m_dims = new int[2]; 
                    m_dims[0] = 0; 
                    m_dims[1] = 0; 
                }

			}
		}
		/// <summary>		
		/// copy constructor
		/// </summary>
		/// <param name="newDim">ILDimension object to copy this object from</param>
		public ILDimension (ILDimension newDim) {
			m_nrDims = newDim.m_nrDims;
			m_numberOfElements = newDim.m_numberOfElements; 
			m_dims = new int[m_nrDims]; 
            m_length = newDim.m_length; 
			for (int i = 0; i < m_nrDims; i++) {
				m_dims[i] = newDim[i]; 
                if (m_length < m_dims[i]) m_length = m_dims[i]; 
			}
		}
		
		/// <summary>Get/set Number of Dimensions.</summary>
		/// <description>setting this value will clear the dimension object 
		/// and reinitialize it with all "1" for all dimensions! </description>
		/// <remarks>Make sure to disable write access to this property from outside of 
		/// the library to prevent for storage inconsistency!</remarks>
		public int NumberOfDimensions {
			get {
				return m_nrDims; 
			}
		}
        /// <summary>
        /// Number of non singleton dimensions this ILDimension is holding
        /// </summary>
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
		/// Number of elements this ILDimension will produce in a storage array
		/// </summary>
		public int NumberOfElements {
			get {
				return m_numberOfElements;
			}
		}
		/// <summary>
		/// Marks the number of elements between adjecent elementes of 
		/// each dimension as if the underlying storage was a physical storage.
		/// </summary>
		/// <param name="dim">dimension number to query the distance for. The
		/// first dimension has index 0 (zero)!</param>
		/// <returns>number of elements between adjecent elementes of dimension dim.
        /// </returns>
        /// <remarks>if dimension index dim is larger than the number of 
        /// dimensions inside this ILDimension, the number of elements will 
        /// be returned (assuming the trailing dimensions to be 0).</remarks>
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
        /// distances between adjacent elements for all dimension
        /// </summary>
        /// <remarks>This is provided for performance reasons and should be used internaly only.
        /// It enables developer for index access routines to cache the element distances directly inside 
        /// their functions without having to query the info every for every index.
        /// <para>keep in mind, only the distances for the number of my dimensions are returned. 
        /// Higher dimensions must be set to NumberOfElements by hand. This is different than querying 
        /// the distances by SequentialIndexDistance(int), which will assume trailing dimensions to be set to 0.</para></remarks>
		internal int[] SequentialIndexDistances {
            get{
                int[] ret = new int[m_nrDims];
                int tmp = 1; 
                for (int i = 0; i < m_nrDims; i++) {
                    ret[i] = tmp; 
                    tmp *= m_dims[i];
                }
			    return ret; 
            }
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
        /// <param name="length">minimum length of output array. If length is larger than my dimensions, trailing zeros will be added.</param>
		/// <returns>integer array containing a copy of dimensions length. Trailing elements outside my dims will be zero.</returns>
		internal int[] ToIntArray (int length) {
			int[] ret; 
            ret = new int[length > m_nrDims ? length : m_nrDims];
			Array.Copy(m_dims,0,ret,0,m_nrDims); 
			return ret; 
		}
		/// <summary>
		/// Translate indices from int[] Array to sequential storage access in my dimensions
		/// </summary>
		/// <param name="idx">int array of nrDims length</param>
		/// <returns>Index number pointing to the value's position in sequential storage.</returns>
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
		/// Transform dimension position into sequential index, gather expand information
		/// </summary>
		/// <param name="idx">int array of arbitrary length</param>
        /// <param name="MustExpand">[output] true, if the indices given address an element outside of 
        /// this dimensions size. In this case, the output parameter 'Dimensions' carry the sizes 
        /// of new dimensions needed. False otherwise</param>
        /// <param name="Dimensions">sizes of dimension if expansion is needed</param>
		/// <returns>Index number pointing to the value's position in sequential storage.</returns>
        /// <remarks>no checks are made for idx to fit inside dimensions! This functions is used 
        /// for left side assignments. Therefore it computes the destination index also if it lays outside 
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
		/// Unshift dimensions of indices from int[] Array and translate to index 
		/// for sequential storage access in my dimensions
		/// </summary>
		/// <param name="idx">int array of the same length as the number of dimensions
		/// of this storage. Indices must lay within my dimensions.</param>
		/// <param name="unshift">number of dimensions to unshift idx before computing index</param>
		/// <returns>Index number pointing to the value's position in sequential storage.</returns>
		/// <remarks> If idx contains elements (indices) larger than my dimension bounds, 
		/// an Exception will be thrown. If unshift is 0, the length of idx may be smaller than 
		/// the length of my dimensions. However, with unshift > 0 the result 
		/// of such a case would be undefined.</remarks>
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
		public ILDimension Clone() {
			ILDimension ret = new ILDimension(this); 
			return ret;
		}
		/// <summary>
		/// Shift dimension specification. 
		/// </summary>
		/// <param name="nrs">Number of dimensions to shift.</param>
		/// <remarks>this will only alter the dimensions order. Neither the Number of Elements nor 
		/// the number of dimensions addressed will change.</remarks>
		internal void Shift (int nrs) {
			nrs %= m_nrDims; 
			int [] tmp = new int [m_nrDims]; 
			int id;
            for (int d = 0; d < m_nrDims; d++) {
                id = (d + nrs) % m_nrDims;
                tmp[d] = m_dims[id];
            }
			m_dims = tmp;
		}

		/// <summary>
		/// Create shifted version
		/// </summary>
		/// <param name="shift">number of dimensions to shift</param>
		/// <returns>shifted version of this ILDimension object</returns>
		public ILDimension getShiftedVersion(int shift){ 
			ILDimension ret = new ILDimension(m_dims);
			ret.Shift(shift);
			return ret; 
		}
        ///// <summary>
        ///// test if range fits inside dimensions
        ///// </summary>
        ///// <param name="range">ILRange to test against dimension size</param>
        ///// <returns>true if this range can get applied to this dimensions, or false if not.</returns>
        ///// <remarks>range may be of more dimensions than this dimension if on the end of range only exist "0" dimensions.
        ///// If range is of less dimensions than this dimension, zero will be added -> this is valid also.</remarks>
        //public bool ValidRange(ILRange range){
        //    int d=0; 
        //    for (; d < m_nrDims && d < range.NumberOfDimensions; d++) {
        //        if (range.MaxValue(d) >= m_dims[d] || range.MinValue(d) < 0)
        //                return false;
        //    }
        //    // dimensions at end must be singleton dimensions 
        //    while (d < range.NumberOfDimensions) 
        //        if (range.MaxValue(d) != 0 || range.MinValue(d++) != 0) return false; 
        //    return true;
        //}
		/// Access for ILDimension dimensions with [d]-braces.
		/// alowed is read AND write access 
		/// if d is smaller 1, an ArgumentOutOfRange Exception is thrown
		/// if d is greater as NumberOfDimensions 
		/// <item>on Write Access: the dimensions are extended. 
		/// Empty dimensions are marked as having length '1'. </item>
        /// <item> on Read Access: 1 will be returned</item>
		/// <remarks> Index Access is Zero-based, i.e. the first element start at 0, the 
        /// last element ends at (N-1)
        /// </remarks>
		public int this [int idx] {
			get {
				if (idx < 0) 
					throw new ArgumentOutOfRangeException("index","Index out of Range!");
				else if (idx >= m_nrDims) {
                    return 1; 
                }
					// get specified dimension
				return m_dims[idx];
			}
			internal set{
                // todo: there was a bugreport on this part. Check it, if it's still needed!
				if (idx < 0)
					throw new ArgumentOutOfRangeException("index","Index must be positive!");
				else if (idx >= m_nrDims){
					// extend dimensions 
					int [] tmp = new int[idx+1];
					Array.Copy(m_dims,tmp,m_nrDims);
					// fill with ones between
					for (int t = m_nrDims; t < idx; t++) {
						tmp[t] = 1;
                    }
					// set new Dimension
					tmp[idx] = value;
					m_dims = tmp;
                    m_numberOfElements *= value; 
                    m_nrDims = m_dims.Length; 
				} else if (idx < m_nrDims) {
					m_numberOfElements /= m_dims[idx]; 
                    m_dims[idx] = value; 
                    m_numberOfElements *= value; 
				}
                //m_numberOfElements = 1; 
                //if (m_length < value) m_length = value; 
                //foreach (int tmp in m_dims)
                //    m_numberOfElements *= tmp;
			}
		}
		/// <summary>
		/// Compares the size of this dimension to another dimension object. 
		/// </summary>
		/// <param name="dim2">ILDimension object to compare this to.</param>
		/// <returns>Returns true if the sizes are the same, else returns false. 
		/// The comparison is made by recognizing singleton dimesnions. Therefore 
		/// only non singleton dimesnions are compared in the order of their 
		/// appearence. </returns>
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
		/// Create a copy of this ILDimension object with all singleton dimensions removed.
		/// </summary>
		/// <returns></returns>
		public ILDimension GetSqueezed() {
			ILDimension ret = new ILDimension(this); 
			return ret.Squeeze();
		}
		/// <summary>
		/// Remove singleton dimensions from this ILDimension object.
		/// </summary>
		/// <returns>This object after singleton dimensions have been removed.</returns>
		/// <remarks> this object will be altered AND returned! 
        /// TODO: Check, if this is valid, since 
        /// ILDimension should be immutable! </remarks>
		public ILDimension Squeeze() {
			int p1 = 0; 
			int p2 = 0; 
			while (p1 < m_nrDims) {
				if (m_dims[p1] != 1)
					m_dims[p2++] = m_dims[p1];
				p1++;
			}
			m_nrDims = p2 +1;
			if (m_nrDims < 2) {
				if (m_nrDims == 1) 
					m_dims[1] = 1; 
				if (m_nrDims == 0)
					throw new ArgumentException ("ILDimensions|Squeeze:This dimension does not contain data!"); 
				m_nrDims = 2; 
			}
			int [] newDims = new int[m_nrDims]; 
			System.Array.Copy(m_dims,0,newDims,0,m_nrDims);
			m_dims = newDims; 
			return this;
		}
		/// <summary>
		/// Remove singleton dimensions from this ILDimension objects end.
		/// </summary>
		/// <returns>This object after singleton dimensions have been removed.</returns>
		/// <remarks> this object will be altered AND returned! The result wil have at
        /// least 2 dimensions.</remarks>
		public ILDimension Trim() {
			int p1 = m_nrDims-1; 
			bool hasTrimmed = false; 
            while (p1 > 1) {
				if (m_dims[p1] > 1) break; 
                hasTrimmed = true; 
				p1--;
			}
			if (hasTrimmed) {
                m_nrDims = p1+1;
			    int [] newDims = new int[m_nrDims]; 
			    System.Array.Copy(m_dims,0,newDims,0,m_nrDims);
			    m_dims = newDims; 
			}
            return this;
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
    }
}
