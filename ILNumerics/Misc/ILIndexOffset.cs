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
using ILNumerics.Misc;
using ILNumerics.Exceptions; 
using System.Text; 


namespace ILNumerics.Storage
{
    /// <summary>
    /// Jagged array for 'fast' random access to full physical storages.
    /// </summary>
    /// <remarks>m_indexOffset maps the access indices for each dimension 
    /// of this object to the indices in the dimensions of the physical 
    /// storage. This is not the same mor has anything to do with the range object! 
    /// m_indexOffset rather serves as a fast reference for computing the actual index 
    /// of an element inside the sequential (physical) storage. 
    /// Therefore m_indexOffset is assembled out of 
    /// <list type="bullet">
    /// <item>
    ///		an array of int arrays reflecting the entries in m_dimension,
    ///		i.e. the shifted + trimmed dimensions this storage makes public. 
    ///	</item>
    /// <item>
    ///		each array element stands for each dimension of THIS 
    ///		reference storage. Dimensions at the end are abbreviated.
    ///	</item>
    /// <item>
    ///		for each dimension there is an int[] array holding the 
    ///		offsets for each element of that dimension inside the 
    ///		underlying physical storage.
    ///	</item>
    ///	</list>
    /// In order to compute the element index for an element of this storage 
    /// inside the physical storage, it is only neccessary to add all corresponding 
    /// entries for each dimension of m_indexOffset: 
    /// <code>
    /// ILRefStorage b = a.CreateReference();
    /// ...
    /// double val = b["1,5,3"]; // will result in: 
    ///	val = a.m_data(  m_indexOffset.Data[0][1] 
    ///				   + m_indexOffset.Data[1][5] 
    ///				   + m_indexOffset.Data[2][3]) // to be queried
    /// </code>
    /// the dimensions (i.e. int[] array elements) of m_indexOffset 
    /// are shifted according to the dimensions this storage is shifted 
    /// in relation to its referenced storage. 
    /// Therefore they do NOT neccessarily correspond to the order 
    /// in which the dimension of the physical storage exist. Due to 
    /// performance reasons there is no need to (un)shift incoming 
    /// indexing requests in order to map to physical storage indices.
    /// Those request must always be in the dimension order, which is 
    /// reflected from this storage to the outside world.
    /// </remarks>
    [Serializable]
    [System.Diagnostics.DebuggerTypeProxy(typeof(ILIndexOffset.ILIndexOffsetTypeProxy))]
    public class ILIndexOffset {
		int[][] m_idxOffset; 
		int[] m_isRegularySpaced; 
		// number of elements per dimension
		int[] m_seqIdxDist; 
		int m_nrNonSingleton; 
		long m_nrElements;
		/// <summary>
		/// Constructor creating ILIndexOffset from jagged int[][] array
		/// </summary>
		/// <param name="idxOffset">Jagged int[][] array by reference. This parameter 
		/// will be copied into the internal array. </param>
        /// <param name="regularySpacing">regulary spacing for each dimension</param>
		public ILIndexOffset(int[][] idxOffset, int[] regularySpacing) {
			commonConstruct(idxOffset,regularySpacing);
		}
        /// <summary>
        /// Copy construcotr
        /// </summary>
        /// <param name="idxOffset">ILIndexOffset to be copied</param>
		public ILIndexOffset(ILIndexOffset idxOffset) {
            int[][] srcIDXs = idxOffset.m_idxOffset;
            m_idxOffset = new int[srcIDXs.Length][]; 
            for (int d = 0; d < m_idxOffset.Length; d++) {
                System.Array.Copy(srcIDXs[d],m_idxOffset[d],srcIDXs[d].Length); 
            }
            m_isRegularySpaced = new int[srcIDXs.Length]; 
            System.Array.Copy(idxOffset.m_isRegularySpaced,m_isRegularySpaced,m_isRegularySpaced.Length); 
            m_seqIdxDist = new int[srcIDXs.Length]; 
            System.Array.Copy(idxOffset.m_seqIdxDist,m_seqIdxDist,m_seqIdxDist.Length); 
            m_nrNonSingleton = idxOffset.m_nrNonSingleton; 
            m_nrElements = idxOffset.m_nrElements; 
        }

		private void commonConstruct(int[][] idxOffset, int[] regularSpacing) {
			m_nrNonSingleton = 0; 
			m_nrElements = 1;
			m_idxOffset = idxOffset; 
			m_seqIdxDist = new int[idxOffset.Length];
			m_isRegularySpaced = regularSpacing; 
			for (int t = 0; t<idxOffset.Length; t++) {
                if (idxOffset[t].Length > 1) {
                    m_nrNonSingleton++; 
                }
				m_seqIdxDist[t] = (int) m_nrElements;
				m_nrElements *= idxOffset[t].Length;
			}
		}
		
        /// <summary>
        /// index acces for ILIndexOffset
        /// </summary>
        /// <param name="dim">dimension. if this is larger than the number of (trimmed)
        /// dimensions currently referenced by this ILIndexOffset, 0 will be returned. 
        /// THis corresponds to a singleton dimension. </param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int this [int dim, int idx] {
			get {
                //if (dim >= m_idxOffset.Length) {
                //    if (idx > 0)
                //        throw new Exception("Index out of bounds!");
                //    return 0;
                //}
                return m_idxOffset[dim][idx];
			}
		}
        /// <summary>
        /// Get all index offsets for dimension specified
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
		public int[] this [int dim] {
			get {
				return m_idxOffset[dim];
			}
		}
		/// <summary>
		/// Are the elements of dimension specified regulary spaced? 
		/// </summary>
		/// <param name="dim">Dimension index (zero based)</param>
		/// <returns>if the elements are regulary spaced, returns the spacing.
		/// If the elements are unregulary spaced, the return value will be int.MinValue.</returns>
		public int RegularySpacing (int dim) {
			return m_isRegularySpaced[dim];
		}
		
		/// <summary>
		/// number of dimensions this ILIndexOffset is referencing
		/// </summary>
		public int Length {
			get {
				return m_idxOffset.Length;
			}
		}
		/// <summary>
		/// Dimension represented by this ILIndexOffset
		/// </summary>
		/// <returns>Dimension object</returns>
        /// <remarks>This function will introduce a performance penalty, 
        /// since the dimension object will get reconstructed every time called. 
        /// One should therefore cache the dimension externally, if needed.</remarks>
		public ILDimension GetDimensions() {
			ILDimension ret; 
			int[] dims = new int[m_idxOffset.Length]; 
			for (int d = m_idxOffset.Length; d-->0;)
				dims[d] = m_idxOffset[d].Length; 
			ret = new ILDimension(dims); 
			return ret; 
		}
		/// <summary>
		/// number of non-singleton dimensions
		/// </summary>
		public int NonSingleton {
			get {
				return m_nrNonSingleton; 
			}
		}
		/// <summary>
		/// give number of elements for arrays described by this ILIndexOffset
		/// </summary>
		public long NumberOfElements {
			get {
				return m_nrElements; 
			}
		}
		/// <summary>
		/// Evaluates (maps) ILRange on my IndexOffsets and return shifted version. 
		/// </summary>
		/// <param name="range">range object specifying the selection to be addressed 
		/// relative to my indices. Range's dimensions may be the same size or less than my  
		/// dimensions. If range is null, the full storage will be addressed. </param>
		/// <param name="shift">Number of dimensions to shift mapped range</param>
		/// <returns>Mapped ILIndexOffset object. It may be used for direct addressing the 
		/// data positions inside the physical storage. </returns>
		/// <remarks>TODO : prevent the global offset inside physicalStorage, holded in the 
		/// first dimensions of m_indexOffset 
		/// to be shifted to another position if shift != 0!!!</remarks>
		public ILIndexOffset Map(ILRange range, int shift) {
			int [][] idx; 
			try {
				// ****************************      Map full storage ***********************************
				if (range == null) {
                    if (shift == 0)
                        // early exit 
                        return new ILIndexOffset (this); 
                    // return full shifted version
					bool stop = false; int addSingletonValue = 0; 
					int nonSingletonDims = 0; 
					int rngPos;  int idxPos = m_idxOffset.Length - 1; 
					idx = new int[m_idxOffset.Length][];
					for (int d = m_idxOffset.Length; d-->0;) {
						rngPos = (d + shift) % m_idxOffset.Length; 
						// recognize "second end" after shift -> remove non singleton dimensions 
						if (rngPos == m_idxOffset.Length-1) stop = false; 
						if (m_idxOffset[rngPos].Length == 1 && !stop) {
							// save singleton dimensions values for later sum
							addSingletonValue += m_idxOffset[rngPos][0]; 
						} else {
							stop = true;
							nonSingletonDims++;
							idx[idxPos] = new int [m_idxOffset[rngPos].Length]; 
							for (int i = 0; i < m_idxOffset[rngPos].Length; i++) {
								idx[idxPos][i] = m_idxOffset[rngPos][i];
							} 
							idxPos--;
						}
					} 
					// move int[][] to start in case of non singleton dimensions beeing removed
					if (idx != null && idxPos >= 0) {
						int [][] tmp1 = new int[nonSingletonDims][]; 
						System.Array.Copy(idx,idxPos+1,tmp1,0,nonSingletonDims);
						idx = tmp1; 
					}
					// add (removed) singleton dimensions to first dimension
					if (addSingletonValue > 0 && idx != null && idx.Length > 0)  {
						for (int d = idx[0].Length; d-->0;) {
							idx[0][d] += addSingletonValue;
						}
					}
					return new ILIndexOffset(idx,(int[])m_isRegularySpaced.Clone()); 
				}	
			} catch (Exception e) {
				throw new ILArgumentException ("error mapping ILRange to ILIndexOffset.",e);
			}
			if (range.NumberOfDimensions > m_idxOffset.Length)
				throw new ArgumentException("invalid range specification");
			idx = new int[range.NumberOfDimensions][];
			try {
				// ****************************      Map ranged storage ***********************************
				bool stop = false; int addSingletonValue = 0; 
				int nonSingletonDims = 0; 
				int rngPos;  int idxPos = range.NumberOfDimensions - 1; 
                int [] regularSpacing = new int [range.NumberOfDimensions]; 
				for (int d = range.NumberOfDimensions; d-->0;) {
					rngPos = (d + shift) % range.NumberOfDimensions; 
					// recognize "second end" after shift -> remove non singleton dimensions 
					if (rngPos == range.NumberOfDimensions-1) stop = false; 
					if (range[rngPos].Length == 1 && !stop && range[rngPos,0] >= 0) {
						// save singleton dimensions values for later sum
						addSingletonValue += m_idxOffset[rngPos][range[rngPos,0]]; 
					} else if (range[rngPos].Length == 1 && range[rngPos,0]<0 ) {
                        #region full dimension addressed 
                        stop = true; 
                        nonSingletonDims++; 
                        if (rngPos == range.NumberOfDimensions-1 && -range[rngPos,0] > m_idxOffset[idxPos].Length-1) {
                            // resulting array must be reshaped -> add trailing dimensions to last dimensions 
                            int curDimLen = m_idxOffset[rngPos].Length;
                            int myDimsNr = m_idxOffset.Length;  
                            int limit = (-1)*range[rngPos,0]+1; 
                            int [] posArr = new int[m_idxOffset.Length]; 
                            int higherDims = 0; 
                            for (int i = rngPos; i < myDimsNr; i++)
                                higherDims += m_idxOffset[i][posArr[i]];  
                            idx[idxPos] = new int [limit]; 
                            int curPos = 0; 
                            int[] curidxOffsDim = m_idxOffset[rngPos]; 
                            while (curPos < limit) {
                                // sum higher dims 
                                higherDims = 0; 
                                for (int i = rngPos +1; i < myDimsNr; i++)
                                    higherDims += m_idxOffset[i][posArr[i]]; 
                                // current dimension
                                for (int i = 0; i < curDimLen; i++) {
                                    idx[idxPos][curPos++] = curidxOffsDim[i]+higherDims; 
                                }
                                // increase higher dimensions 
                                int di = rngPos + 1; 
                                while (di < myDimsNr) {
                                    posArr[di]++; 
                                    if (posArr[di] >= m_idxOffset[di].Length) {
                                        posArr[di++] = 0; 
                                    } else {
                                        break; 
                                    }
                                }
                            }
                            // todo: it might be possible to determine, if result is regulary spaced. Simple case would be 
                            // to scan the entries while filling. But...
                            regularSpacing[idxPos] = int.MinValue; 
                       } else {
                            idx[idxPos] = new int [(-1) * range[rngPos,0] + 1]; 
						    for (int i = 0; i < idx[idxPos].Length; i++) {
							    idx[idxPos][i] = m_idxOffset[rngPos][i];
						    } 
                            regularSpacing[idxPos] = (range.Spacing(rngPos) > int.MinValue && m_isRegularySpaced[rngPos] > int.MinValue) ? 
                                range.Spacing(rngPos) * m_isRegularySpaced[rngPos] : int.MinValue; 
                        }
                        #endregion full dimension addressed 
					    idxPos--;
                    } else {
                        // arbitrary indices inside dimension 
						stop = true;
						nonSingletonDims++;
                        idx[idxPos] = new int [range[rngPos].Length]; 
                        if (rngPos == range.NumberOfDimensions - 1 
                            && range.NumberOfDimensions < m_idxOffset.Length) {
                            // allow for indices > dimlen
                            for (int i = 0; i < range[rngPos].Length; i++) {
							    int destVal = 0; 
                                int secIdx = range[rngPos,i];   
                                for (int idxInd = rngPos; idxInd < m_idxOffset.Length;) {
                                    destVal += m_idxOffset[idxInd][secIdx % m_idxOffset[idxInd].Length];
                                    secIdx /= m_idxOffset[idxInd++].Length; 
                                }
                                if (secIdx > 0)
                                    throw new ILArgumentException("index " + range[rngPos,i].ToString() 
                                        + " out of range for dimension " + d.ToString()); 
                                idx[idxPos][i] = destVal; 
						    } 
                        } else {      						    
                            // only indices in dimension range allowed
                            for (int i = 0; i < range[rngPos].Length; i++) {
							    int secIdx = range[rngPos,i];  
                                idx[idxPos][i] = m_idxOffset[rngPos][secIdx];
						    } 
                        }

                        regularSpacing[idxPos] = (range.Spacing(rngPos) > int.MinValue && m_isRegularySpaced[rngPos] > int.MinValue) ? 
                            range.Spacing(rngPos) * m_isRegularySpaced[rngPos] : int.MinValue; 
					    idxPos--;
					}
				}
				// move int[][] to start in case of non singleton dimensions beeing removed
                if (nonSingletonDims < 2) {
                    // create matrix at least
                    System.Diagnostics.Debug.Assert(false,"reference dimensions too small. At least 2 dimensions required.");
                    if (nonSingletonDims == 0) {
                        // range is 0D
                        idx = new int[2][];
                        idx[0] = new int[1] { addSingletonValue };
                        idx[1] = new int[1] { 0 };
                    } else {
                        // range is 1D 
                        int[][] tmp1 = new int[2][];
                        int size = idx[idxPos + 1].Length;
                        tmp1[0] = new int[size]; 
                        for (int d = size; d-->0; ) 
                            tmp1[0][d] = idx[idxPos + 1][d];
                        tmp1[1] = new int[1] { addSingletonValue }; // öurhg! ugly hack !
						idx = tmp1; 
                    }
                } else {
                    if (idxPos >= 0) {
                        int newLen = idx.Length - idxPos - 1; 
                        int[][] tmp1 = new int[newLen][];
                        System.Array.Copy(idx, idxPos + 1, tmp1, 0, newLen);
                        idx = tmp1;
                        int[] tmp2 = new int[newLen];
                        System.Array.Copy(regularSpacing, idxPos + 1, tmp2, 0, newLen);
                        regularSpacing = tmp2; 
                    }
                    if (addSingletonValue > 0 && idx.Length > 0) {
                        for (int d = idx[0].Length; d-- > 0; ) {
                            idx[0][d] += addSingletonValue;
                        }
                    }
                }
				return new ILIndexOffset(idx,regularSpacing); 
			} catch (Exception e) {
				throw new ArgumentException ("Invalid Range specification:",e);
			} 
		}

		/// <summary>
		/// map incoming long index to destination index of physical storage 
		/// </summary>
		/// <param name="idxIn">Index relative to this IndexOffset storage. 
		/// ILIndexOffset reflects an sequential storage to the outside world. 
		/// Therefore idxIn is as this was an sequential storage too.</param>
		/// <returns>Index in underlying physical storage.</returns>
		public int Map(int idxIn) {
            unsafe {
                int ret = 0; 
                for (int d = 0; d < m_idxOffset.Length; d++) {
                    ret += m_idxOffset[d][idxIn % m_idxOffset[d].Length]; 
                    idxIn /= m_idxOffset[d].Length; 
                }
                return ret; 
            }
		}

        /// <summary>
		/// Transform dimension position into sequential index
		/// </summary>
		/// <param name="idx">int array of arbitrary length</param>
		/// <returns>Index number pointing to the value's position in sequential storage if it exist. Negative value otherwise.</returns>
		internal int IndexFromArray(int[] idx) {
            if (idx.Length < m_idxOffset.Length) {
                // expanding is allowed for all but the last specified dimension
                int d = 0, tmp = idx[0]; 
			    int ret = 0; 
                while (d < idx.Length-1) {
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_idxOffset[d].Length) {
                        return -1; 
                    } else {
                        ret += m_idxOffset[d][tmp]; 
                    }
                    tmp = idx[++d];
                }
                while (d < m_idxOffset.Length) {
                    ret += m_idxOffset[d][tmp % m_idxOffset[d].Length];
                    tmp /= m_idxOffset[d++].Length; 
                }
                if (tmp > 0) 
                    throw new ILArgumentException("expanding is allowed for explicitly bounded dimensions only! You must specify indices into all existing dimensions."); 
                return ret;
			} else if (idx.Length == m_idxOffset.Length) {
                // expanding is allowed for all dimensions 
                int d = 0, tmp; 
			    int ret = 0; 
                while (d < idx.Length) {
                    tmp = idx[d];
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_idxOffset[d].Length) {
                        return -1; 
                    } else {
                        ret += m_idxOffset[d][tmp]; 
                    }
                    d++; 
                }
                return ret;
			} else {
                // idx dimensions are larger than my dimensions
                int d = 0, tmp = idx[0]; 
			    int ret = 0; 
                while (d < m_idxOffset.Length) {
                    tmp = idx[d];
                    if (tmp < 0)
                        throw new ILArgumentException("check index at dimension " + d.ToString() + "!");
                    if (tmp >= m_idxOffset[d].Length) {
                        return -1; 
                    } else { 
                        ret += m_idxOffset[d][tmp]; 
                    }
                    d++; 
                }
                while (d < idx.Length) {
                    tmp = idx[d++]; 
                    if (tmp > 0) {
                        return -1; 
                    }
                }
                return ret; 
            }
		}
        /// <summary>
        /// Give string representation for this ILIndexOffset
        /// </summary>
        /// <returns>string representing this ILIndexOffset</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int d = 0;d < m_idxOffset.Length; d++) {
                sb.Append("["); 
                if (m_idxOffset[d].Length < 30) {
                    int i = 0; 
                    for (; i < m_idxOffset[d].Length-1; i++ ) { 
                        sb.Append(m_idxOffset[d][i] + ","); 
                    }
                    sb.Append (m_idxOffset[d][i] + "]" + Environment.NewLine); 
                } else {
                    int i = 0; 
                    for (; i < 10; i++ ) { 
                        sb.Append(m_idxOffset[d][i] + ","); 
                    }
                    sb.Append("..."); 
                    sb.Append (m_idxOffset[d][m_idxOffset[d].Length-2] + "," + m_idxOffset[d][m_idxOffset[d].Length-1] + "]" + Environment.NewLine); 
                }
            }
            return sb.ToString(); 
        }

        internal class ILIndexOffsetTypeProxy {
            private ILIndexOffset m_idxOffset; 
            public ILIndexOffsetTypeProxy(ILIndexOffset idxOffset) {
                m_idxOffset = idxOffset; 
            }
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
            public int[][] Elements {
                get{
                    return m_idxOffset.m_idxOffset; 
                }
            }
            public int[] RegularSpacing {
                get{ 
                    return m_idxOffset.m_isRegularySpaced;
                }
            }
            public int[] SequentialDist {
                get{
                    return m_idxOffset.m_seqIdxDist; 
                }
            }
        }
    }
}
