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
using System.Text;
using ILNumerics.Misc;
using System.Collections.Generic;
using System.Threading;
using ILNumerics.Exceptions;


namespace ILNumerics.Storage {
	/// <summary>
	/// Iterator positions, used for creating ILIterators and specifying initial 
    /// positions of the current element.
	/// </summary>
	public enum ILIteratorPositions {
		/// <summary>
		/// position the iterator at the first element
		/// </summary>
        ILStart,
        /// <summary>
        /// position the iterator at the last element
        /// </summary>
		ILEnd,
        /// <summary>
        /// position the iterator at the middle element
        /// </summary>
		ILMiddle
	}

	/// <summary>
	/// High performance iterator for ILArray's 
	/// </summary>
	/// <remarks>This iterator is optimized for physical storages as well as 
	/// for reference storages. However, the iteration for reference storage 
	/// is (and will always be) couple of times slower than for physical storages.
    /// <para>This type is marked as <b>deprecated</b> and may be removed in a 
    /// future release. Use foreach constructs for read access and SetValue(seqIdx) for write 
    /// access instead. Those functions - however - may not reach the performance of the 
    /// iterator for write access in certain situations.</para>
    /// </remarks>
	/// <typeparam name="BaseT">the base type of the storage's instance.</typeparam>
	public class ILIterator<BaseT>
    {
		// current sequential index into m_data
		// for physical storages this is the only index needed!
		int m_pos; 
		// copy of leading dimensions indices
        int[] m_leadDimIdx;
		// current index into leading dimension
		int m_curLeadIdx;
        // positions into higher dimensions
        int[] m_higherDimsIdx;
        // current index into higher dimensions
        int m_curHighDim;
		// ref pointer to data
		BaseT[] m_data;
        // is this storage writeable ? Or are any references set?  
        bool m_readonly; 
        /// <summary>
        /// readonly state of the storage attached to this iterator
        /// </summary>
        public bool IsReadonly {
            get {
                return m_readonly;
            }
        }

		int m_dataLenghtMinus1; 
		int m_increment;
		int m_leadDim;
		ILPerformer p = new ILPerformer(); 

        /// <summary>
        /// create ILIterator - this is not for public use! Use <see cref="ILNumerics.ILArray&lt;T&gt;.CreateIterator()"/> instead!
        /// </summary>
        /// <param name="data">storage of source array</param>
        /// <param name="indexOffset">ILIndexOffset mapping for reference arrays</param>
        /// <param name="dimensions">Dimension specification</param>
		public ILIterator(BaseT[] data, ILDimension dimensions) {
			commonConstruct(data, dimensions, ILIteratorPositions.ILStart, 0);
		}
        /// <summary>
        /// create ILIterator - this is not for public use! Use <see cref="ILNumerics.ILArray&lt;T&gt;.CreateIterator()"/> instead!
        /// </summary>
        /// <param name="data">storage of source array</param>
        /// <param name="indexOffset">ILIndexOffset mapping for reference arrays</param>
        /// <param name="dimensions">Dimension specification</param>
        /// <param name="startPos">enumeration value where to set the initial element position </param>
        /// <param name="leadingDimension">the dimension, the iterator is going to walk along</param>
        public ILIterator(BaseT[] data, ILDimension dimensions, ILIteratorPositions startPos, int leadingDimension) {
			commonConstruct(data, dimensions, startPos, leadingDimension);
		}
        /// <summary>
        /// this helper function is used from all constructors
        /// </summary>
        /// <param name="data">storage of source array</param>
        /// <param name="indexOffset">ILIndexOffset mapping for reference arrays</param>
        /// <param name="dimensions">Dimension specification</param>
        /// <param name="startPos">enumeration value where to set the initial element position </param>
        /// <param name="leadingDimension">the dimension, the iterator is going to walk along</param>
		private void commonConstruct(BaseT[] data, ILDimension dimensions, ILIteratorPositions startPos, int leadingDimension)
        {
			m_data = data;
			m_leadDim = leadingDimension % dimensions.NumberOfDimensions;
			m_dataLenghtMinus1 = m_data.Length - 1; 

			m_increment = dimensions.SequentialIndexDistance(leadingDimension);
			switch (startPos) {
				case ILIteratorPositions.ILStart:
				m_pos = 0;
				break;
				case ILIteratorPositions.ILMiddle:
				m_pos = (int)(m_data.Length / 2);
				break;
				case ILIteratorPositions.ILEnd:
				m_pos = m_dataLenghtMinus1;
				break;
			}

            // determine if this storage can be altered 
            m_readonly = false;
		}

		/// <summary>
		/// determine, if the current element is the last element
		/// </summary>
		/// <returns>true if the current element is the last element in the array, false otherwise</returns>
        public bool IsAtEnd() {
			if (m_increment > 0)
				return m_pos == m_dataLenghtMinus1; 
			return m_curHighDim == m_higherDimsIdx.Length-1 
				   && m_curLeadIdx == m_leadDimIdx.Length-1;
		}
		/// <summary>
		/// determine, if the current element is the first element
		/// </summary>
		/// <returns>true if the current element is the first element in the array, false otherwise</returns>
		public bool IsAtStart() {
			if (m_increment > 0)
				return m_pos == 0;
			return m_curHighDim == 0 && m_curLeadIdx == 0;
		}
		//
		/// <summary>
		/// increment to next position and return value at new position
		/// </summary>
		/// <returns>Value of element at new position</returns>
		public BaseT Increment() {
			unsafe {
				switch (m_increment) {
					case 0:
						// reference storage
						m_curLeadIdx++;
						if (m_curLeadIdx == m_leadDimIdx.Length) {
							m_curLeadIdx = 0;
							m_curHighDim = (m_curHighDim + 1)
											% m_higherDimsIdx.Length;
						}
						m_pos = m_leadDimIdx[m_curLeadIdx]
								+ m_higherDimsIdx[m_curHighDim];
						break;
					case 1:
						// physical first dimension
						m_pos = (++m_pos % m_data.Length);
						break;
					default:
						// physical arbitr. dimension
						if (m_pos == m_dataLenghtMinus1) {
							m_pos = 0;
							break;
						}
						m_pos += m_increment;
						if (m_pos > m_dataLenghtMinus1) {
							m_pos %= m_dataLenghtMinus1;
						}
						break;
				}
				return m_data[m_pos];
			}
		}
        /// <summary>
        /// get/set value at current position
        /// </summary>
        /// <exception cref="ILInvalidOperationException">if the storage was readonly, while 
        /// attempting to alter elements</exception>
		public BaseT Value {
            get {
				return m_data[m_pos];
			}
			set {
                if (m_readonly)
                    throw new ILInvalidOperationException("Iterator: write access denied. array is readonly"); 
				m_data[m_pos] = value;
			}
		}
	}
}