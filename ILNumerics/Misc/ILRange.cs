//////////////////////////////////////////////////////////////////
//                                                              //
//  This is an auto - manipulated source file.                  //
//  Edits inside regions of HYCALPER AUTO GENERATED CODE        //
//  will be lost and overwritten on the next build!             //
//                                                              //
//////////////////////////////////////////////////////////////////
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
using ILNumerics; 
using ILNumerics.Misc; 
using ILNumerics.Exceptions;

/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
</type>
<type>
    <source locate="after">
        inCls2
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
</type>
<type>
    <source locate="after">
        outCls1
    </source>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
</type>
<type>
    <source locate="after">
        inArr2
    </source>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source locate="after">
        inArrSkalar
    </source>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source locate="after">
        outArr1
    </source>
    <destination>byte</destination>
    <destination>char</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
</type>
<type>
    <source locate="after">
        out1ArrCast
    </source>
    <destination>(byte)</destination>
    <destination>(char)</destination>
    <destination>(complex)</destination>
    <destination>(fcomplex)</destination>
    <destination>(float)</destination>
    <destination>(Int16)</destination>
    <destination>(Int32)</destination>
    <destination>(Int64)</destination>
    <destination>(UInt16)</destination>
    <destination>(UInt32)</destination>
    <destination>(UInt64)</destination>
</type>
<type>
    <source locate="after">
        cls2Name 
    </source>
    <destination>opbyte_bytebyte</destination>
    <destination>opchar_charchar</destination>
    <destination>opcomplex_complexcomplex</destination>
    <destination>opfcomplex_fcomplexfcomplex</destination>
    <destination>opfloat_floatfloat</destination>
    <destination>opint16_int16int16</destination>
    <destination>opint32_int32int32</destination>
    <destination>opint64_int64int64</destination>
    <destination>opuint16_uint16uint16</destination>
    <destination>opuint32_uint32uint32</destination>
    <destination>opuint64_uint64uint64</destination>
</type>
<type>
    <source locate="after">
        Tcls3Name 
    </source>
    <destination>opbyte_byte</destination>
    <destination>opchar_char</destination>
    <destination>opcomplex_complex</destination>
    <destination>opfcomplex_fcomplex</destination>
    <destination>opfloat_float</destination>
    <destination>opint16_int16</destination>
    <destination>opint32_int32</destination>
    <destination>opint64_int64</destination>
    <destination>opuint16_uint16</destination>
    <destination>opuint32_uint32</destination>
    <destination>opuint64_uint64</destination>
</type>
<type>
    <source locate="after">
        delegate_binary
    </source>
    <destination>ILByteFunctionByteByte</destination>
    <destination>ILCharFunctionCharChar</destination>
    <destination>ILComplexFunctionComplexComplex</destination>
    <destination>ILFcomplexFunctionFcomplexFcomplex</destination>
    <destination>ILFloatFunctionFloatFloat</destination>
    <destination>ILInt16FunctionInt16Int16</destination>
    <destination>ILInt32FunctionInt32Int32</destination>
    <destination>ILInt64FunctionInt64Int64</destination>
    <destination>ILUInt16FunctionUInt16UInt16</destination>
    <destination>ILUInt32FunctionUInt32UInt32</destination>
    <destination>ILUInt64FunctionUInt64UInt64</destination>
</type>
<type>
    <source locate="after">
        delegate_unary
    </source>
    <destination>ILByteFunctionByte</destination>
    <destination>ILCharFunctionChar</destination>
    <destination>ILComplexFunctionComplex</destination>
    <destination>ILFcomplexFunctionFcomplex</destination>
    <destination>ILFloatFunctionFloat</destination>
    <destination>ILInt16FunctionInt16</destination>
    <destination>ILInt32FunctionInt32</destination>
    <destination>ILInt64FunctionInt64</destination>
    <destination>ILUInt16FunctionUInt16</destination>
    <destination>ILUInt32FunctionUInt32</destination>
    <destination>ILUInt64FunctionUInt64</destination>
</type>
<type>
    <source locate="after">
        unaryop
    </source>
    <destination>ByteUnaryByteOperator</destination>
    <destination>CharUnaryCharOperator</destination>
    <destination>ComplexUnaryComplexOperator</destination>
    <destination>FcomplexUnaryFcomplexOperator</destination>
    <destination>FloatUnaryFloatOperator</destination>
    <destination>Int16UnaryInt16Operator</destination>
    <destination>Int32UnaryInt32Operator</destination>
    <destination>Int64UnaryInt64Operator</destination>
    <destination>UInt16UnaryUInt16Operator</destination>
    <destination>UInt32UnaryUInt32Operator</destination>
    <destination>UInt64UnaryUInt64Operator</destination>
</type>
<type>
    <source locate="after">
        TpositiveINF
    </source>
    <destination>127</destination>
    <destination>(char)127</destination>
    <destination>complex.INF</destination>
    <destination>fcomplex.INF</destination>
    <destination>float.PositiveInfinity</destination>
    <destination>Int16.MaxValue</destination>
    <destination>Int32.MaxValue</destination>
    <destination>Int64.MaxValue</destination>
    <destination>UInt16.MaxValue</destination>
    <destination>UInt32.MaxValue</destination>
    <destination>UInt64.MaxValue</destination>
</type>
</hycalper>
 */

namespace ILNumerics.Storage {
    /// <summary>
    /// Helper class defining ranges for subarray access (internal use only)
    /// </summary>
    public enum RangeSide {
        /// <summary>
        /// Right side range for subarray creation. limited to dimension length 
        /// </summary>
        Right, 
        /// <summary>
        /// left side range for assignment. may exeeds dimension length.
        /// </summary>
        Left
    }

	/// <summary>
	/// ILRange specify the dimensions for an ILArray object if it is a reference.
	/// </summary>
	/// <description>ILRange is used to specify the parts of the original dimensions
	/// the ILArray objects referes to if it is a reference to another ILArray object. 
	/// ILRange objects do not know about a 'maximum size'. They dont know the dimensions of the objects,
	/// they get applied to. Therefore the 'colon' specifier will get stored and evaluated at the 
	/// time, the range gets assigned to an ILArray Object. </description>
	public partial class ILRange {
        /// <summary>
        /// number of dimensions defined by this range
        /// </summary>
		protected int m_nrDims = 0; 
        /// <summary>
        /// array defining, if the dimensions of this range are regulary spaced and which spacing the have
        /// </summary>
		protected int[] m_regularSpaced;
        
        
        /// <summary>
        /// true for left side ranges, if at least one dimension must be expanded
        /// </summary>
        public bool Expanding {
            get {
                return m_expanding;
            }
            set {
                if (m_expandDimensions == null) {
                    m_expandDimensions = new int[m_nrDims]; 
                }
                m_expanding = value; 
            }
        }
        /// <summary>
        /// internal field, stores expanding flag
        /// </summary>
        protected bool m_expanding; 
        /// <summary>
        /// array with sizes of dimensions to be expanded
        /// </summary>
        public int[] ExpandDimensions {
            get {
                return m_expandDimensions; 
            }
        }
        /// <summary>
        /// internal field, stores sizes of dimensions to be expanded
        /// </summary>
        protected int[] m_expandDimensions; 

        /// <summary>
        /// Get number of dimensions described by this ILRange
        /// </summary>
		public int NumberOfDimensions {
			get {
				return m_nrDims;
			}
		}
        /// <summary>
        /// internal field stores the number of elements addressed by this ILRange 
        /// </summary>
		private int m_numberOfElements = 0; 
        /// <summary>
        /// Number of elements addressed by this ILRange
        /// </summary>
		public int NumberOfElements {
			get {
				return m_numberOfElements; 
			}
		}
        /// <summary>
        /// internal field, caches the number of non singleton dimensions
        /// </summary>
		private int m_nonSingletonDimensions = 0; 
        /// <summary>
		/// Number of non singleton Dimensions in this range object 
		/// </summary>
		/// <remarks>may be used to verify the space needed to store values referenced by this range</remarks>
		public int nonSingletonDimensions {
			get {
                return m_nonSingletonDimensions; 
            }
		}

		/// <summary>
		/// hold ranges as a simple Array of int[] Arrays.
		/// </summary>
		protected int [][] m_range; 
        /// <summary>
        /// for performance reasons: give reference to internal array
        /// </summary>
        internal int[][] RangeArray {
            get{
                return m_range;
            }
        }
		/// <summary>
		/// Index access for ILRange objects. Set/returns Index array for specifyied dimension.
        /// </summary>
        /// <remarks>the reference of the internal onject will be returned!</remarks>
		public int[] this [int idx] {
			get {
				return m_range[idx];
			} set {
                if (idx < m_range.Length && idx >= 0){
    				m_numberOfElements /= m_range[idx].Length;   
                    m_range[idx] = value;
                    m_numberOfElements *= value.Length; 
				}  
			}
		}
		/// <summary>
		/// Index access for ILRange objects. returns the destIndex destination dimension for dimension specifyied by dimNr.
		/// </summary>
		/// <remarks>This acces is readonly!</remarks>
		public int this [int dimNr,int destIndx ] {
			get {
				try {
					return m_range[dimNr][destIndx];
				} catch (Exception e) {
					throw new IndexOutOfRangeException (String.Format("[ILRange:Index] Index out of range: [{0}:{1}]",dimNr,destIndx),e);
				}
			}
		}

		/// <summary>
		/// Copy Constructor
		/// </summary>
		/// <param name="oldRange">Create new instance from existing ILRange</param>
		public ILRange(ILRange oldRange) {
			Resize(oldRange.NumberOfDimensions);
			for (int d = 0; d < NumberOfDimensions; d++) {
				// copy main Data 
				int [] remDim = oldRange[d]; 
				m_range[d] = new int[remDim.Length];
				for (int r = 0; r < remDim.Length; r++) {
					m_range[d][r] =  remDim[r];
				}
				// copy other member
                //m_maxValues[d] = oldRange.MaxValue(d);
                //m_minValues[d] = oldRange.MinValue(d);
				m_regularSpaced[d] = oldRange.m_regularSpaced[d]; 
			}
			// detemine misc information
            m_numberOfElements = oldRange.m_numberOfElements; 
            m_nonSingletonDimensions = oldRange.m_nonSingletonDimensions; 
            m_expandDimensions = oldRange.m_expandDimensions; 
            m_expanding = oldRange.m_expanding; 
		}

        /// <summary>
        /// Construct ILRange from arrays of indices.
        /// </summary>
        /// <param name="ranges">Array of indices. Each element of ranges corresponds to
        /// one dimension for the new range. ranges must be vector or scalar arrays.</param>
        /// <param name="side">specifies if the range is intended for left side (assignment) 
        /// or ride side (subarray creation).</param>
        /// <param name="dimensions">dimension for destination array. Needed for limit information. </param>
        /// <remarks>the elements of ranges must either be scalar or vectors (row- or column doesn't matter) or 'null'. Elements 
        /// inside the ILBaseArrays will be interpreted as indices into the dimension with the same 
        /// index number. The indices may be of any numeric value type.</remarks>
        public ILRange(ILDimension dimensions, RangeSide side, ILBaseArray[] ranges) {
            if (ranges.Length < 1){
                Resize(0); 
                return; 
            }
			int rngLenUse = (ranges.Length <= dimensions.NumberOfDimensions)?ranges.Length:dimensions.NumberOfDimensions;
			Resize(rngLenUse);
            // step through dimensions 
            int[] outDims = new int[m_nrDims]; 
            if (ranges.Length == 1) {
                outDims[0] = dimensions.NumberOfElements;
            } else {
                for (m_numberOfElements = 0; m_numberOfElements < m_nrDims; m_numberOfElements++) {
                    outDims[m_numberOfElements] = dimensions[m_numberOfElements];
                }
                for (; m_numberOfElements < dimensions.NumberOfDimensions; m_numberOfElements++) {
                    outDims[m_nrDims-1] *= dimensions[m_numberOfElements];
                }
                if (rngLenUse < ranges.Length) {
                    ILBaseArray ba = ranges[m_numberOfElements]; 
                    for (m_numberOfElements = m_nrDims; m_numberOfElements < ranges.Length; m_numberOfElements++) {
                        // SM: a trailing "null" is fine and just equals the selection of all, i.e. 0.0
                        if (Object.Equals(ba, null))
                            ba = ILArray<double>.zeros(1, 1);
                        if (!ba.IsScalar){
                            throw new ILArgumentException("For subarray access, trailing dimensions must be singleton!");
                        #region scalar array as index specification
                        } else if (ba is ILArray<double>) {
                            if (((ILArray<double>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<int>) {
                            if (((ILArray<int>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<complex>) {
                            if (((ILArray<complex>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<fcomplex>) {
                            if (((ILArray<double>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<float>) {
                            if (((ILArray<float>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<Int16>) {
                            if (((ILArray<Int16>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<byte>) {
                            if (((ILArray<byte>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<char>) {
                            if (((ILArray<char>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<UInt16>) {
                            if (((ILArray<UInt16>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<UInt32>) {
                            if (((ILArray<UInt32>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<UInt64>) {
                            if (((ILArray<UInt64>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        } else if (ba is ILArray<Int64>) {
                            if (((ILArray<Int64>)ba).GetValue(0) != 0.0)
                                throw new ILArgumentException("Index out of bounds for dimension" + m_numberOfElements);
                        #endregion
                        } else {
                            throw new ILArgumentException("Invalid type for subarray index access"); 
                        }
                    }
                }
            }
            m_numberOfElements = 1; 
            for (int d = 0; d < rngLenUse; d++) {
                int dimsd = outDims[d]; 
                if (Object.Equals(ranges[d],null)) {
                    // take full dimension
                    m_range[d] = new int[1]; 
                    m_range[d][0] = - dimsd + 1; // store dimension length only
                    m_regularSpaced[d] = 1; 
                    m_numberOfElements *= dimsd; 
                    if (dimsd > 1) 
                        m_nonSingletonDimensions++; 
                } else if (ranges[d].IsEmpty) {
                    m_range[d] = new int[0]; 
                    m_regularSpaced[d] = 0; 
                    m_numberOfElements = 0; 
                } else if (!(ranges[d].IsVector || ranges[d].IsScalar)) {
                    throw new ILArgumentException("range: index " + d + " invalid! expected vector or scalar!" );
                } else {
                    int curLen = ranges[d].Dimensions.NumberOfElements;
                    m_range[d] = new int[curLen]; 
                    int tmpVal, spacing = 0; 
                    if (false) {
#region HYCALPER LOOPSTART 
                    } else if (ranges[d] is /*!HC:inCls1*/ ILArray<double> ) {
			            /*!HC:inCls1*/ ILArray<double> srcArray = (/*!HC:inCls1*/ ILArray<double> ) ranges[d]; 
                        /*!HC:inArr1*/ double [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
#endregion HYCALPER LOOPEND 
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                    } else if (ranges[d] is  ILArray<UInt64> ) {
			            ILArray<UInt64> srcArray = ( ILArray<UInt64> ) ranges[d]; 
                        UInt64 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<UInt32> ) {
			            ILArray<UInt32> srcArray = ( ILArray<UInt32> ) ranges[d]; 
                        UInt32 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<UInt16> ) {
			            ILArray<UInt16> srcArray = ( ILArray<UInt16> ) ranges[d]; 
                        UInt16 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<Int64> ) {
			            ILArray<Int64> srcArray = ( ILArray<Int64> ) ranges[d]; 
                        Int64 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<Int32> ) {
			            ILArray<Int32> srcArray = ( ILArray<Int32> ) ranges[d]; 
                        Int32 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<Int16> ) {
			            ILArray<Int16> srcArray = ( ILArray<Int16> ) ranges[d]; 
                        Int16 [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<float> ) {
			            ILArray<float> srcArray = ( ILArray<float> ) ranges[d]; 
                        float [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<fcomplex> ) {
			            ILArray<fcomplex> srcArray = ( ILArray<fcomplex> ) ranges[d]; 
                        fcomplex [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<complex> ) {
			            ILArray<complex> srcArray = ( ILArray<complex> ) ranges[d]; 
                        complex [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<char> ) {
			            ILArray<char> srcArray = ( ILArray<char> ) ranges[d]; 
                        char [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 
                    } else if (ranges[d] is  ILArray<byte> ) {
			            ILArray<byte> srcArray = ( ILArray<byte> ) ranges[d]; 
                        byte [] mdata = srcArray.m_data; 
                        if (curLen > 1) {
                            m_nonSingletonDimensions++; 
                            // determine spacing also 
                            int n = 0;
                            for (; n < 2; n++) {
                                tmpVal = (int) srcArray.GetValue(n);
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                            }
                            int tmpValOld = m_range[d][1];
                            bool flag = true; 
                            m_regularSpaced[d] = spacing = tmpValOld - m_range[d][0];
                            for (; n < curLen; n++) {
                                tmpVal = (int) srcArray.GetValue(n); 
                                if (tmpVal < 0)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                if (tmpVal >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal+1; 
                                    }
                                }
                                m_range[d][n] = tmpVal; 
                                if (flag && tmpVal - tmpValOld != spacing) {
                                    m_regularSpaced[d] = int.MinValue; 
                                    flag = false; 
                                }
                                tmpValOld = tmpVal; 
                            }
                        } else if (curLen == 1) {
                            // curlen <= 1
                            m_regularSpaced[d] = 1; 
                            tmpVal = (int) srcArray.GetValue(0); 
                            if (tmpVal < 0)
                                throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                            if (tmpVal >= dimsd) {
                                if (side == RangeSide.Right)
                                    throw new ILArgumentException("index out of bound for dimension: " + d.ToString());
                                else {
                                    Expanding = true; 
                                    if (m_expandDimensions[d] <= tmpVal) 
                                        m_expandDimensions[d] = tmpVal+1; 
                                }
                            }
                            m_range[d][0] = tmpVal; 
                        } else {
                            // curLen = 0
                            m_regularSpaced[d] = 1; 
                        }
                        m_numberOfElements *= curLen; 

#endregion HYCALPER AUTO GENERATED CODE
                    } else {
                        throw new ILArgumentTypeException ("the type of the " + d + "-th parameter is not supported!" );
                    }
                    // prepare m_regularSpaced infos 
                }
            }
        }

		/// <summary>
		/// Creates ILRange from string array. Replace all occurences of "end" with corrensponding 
		/// dimension length. Replace all dimensions consisting only out off ":" with "1:end"
		/// </summary>
		/// <param name="dims">dimension specification</param>
		/// <param name="rng">String array with range specification (may contains "end")</param>
        /// <param name="side">determine, if this range is applied to left side or right side expressions</param>
		public ILRange(ILDimension dims, RangeSide side, params string[] rng) {
			if (rng.Length == 1) 
				rng = rng[0].Split(';');
            //if (rng.Length > dims.NumberOfDimensions && side == RangeSide.Right) 
            //    throw new ArgumentException ("range does not fit in dimensions!");
            if (rng.Length < 1){
                Resize(0); 
                return; 
            }
			// expand string range definition to multidimensional array m_range
            /* 
             * Note: by specifying a range definition for less dimension than
             * dimensions in the dims, subsequent trailing dimensions will be 
             * merged and added to the last dimension of range. The 'reshaped'
             * dimension is than considered for output. The decision, if that 
             * dimension must get expanded is determined by the limits of those
             * output dimensions.
             */
			int start,ende,step;
            int rngLenUse = rng.Length; //(rng.Length <= dims.NumberOfDimensions)? rng.Length:dims.NumberOfDimensions;
			int tmpValue;
			Resize(rngLenUse);
            #region prepare out dimension length
            int[] outDims = new int[m_nrDims]; 
            if (rng.Length == 1) {
                outDims[0] = dims.NumberOfElements;
            } else {
                if (rng.Length <= dims.NumberOfDimensions) {
                    for (start = 0; start < m_nrDims; start++) {
                        outDims[start] = dims[start];
                    }
                    for (; start < dims.NumberOfDimensions; start++) {
                        outDims[m_nrDims-1] *= dims[start];
                    }
                } else {
                    for (start = 0; start < dims.NumberOfDimensions; start++) {
                        outDims[start] = dims[start];
                    }
                    for (; start < rng.Length; start++) {                        
                        outDims[start] = 1;
                        //string[] ranges = rng[start].Split(',');
                        //if (ranges.Length != 1 || !int.TryParse(ranges[0].Trim(),out step) || step != 0)
                        //    throw new ILArgumentException("For right side subarray access, trailing dimensions must be singleton! Check dimension " + start.ToString() + "!");
                    }
                }
            }
            #endregion
            m_numberOfElements = 1; 
			RegularSpacedList idxList = new RegularSpacedList(2);
			for (int d = 0; d < rngLenUse; d++) {
                // parse this dimension string for single int/range definitions seperated by ','
				string[] ranges = rng[d].Split(',');
				int dimsd = outDims[d]; 
                idxList.Clear();
                if (ranges.Length == 1 && ranges[0].Trim() == ":") {
                    #region full dimension
                    m_range[d] = new int[1]{-(dimsd-1)}; 
                    m_numberOfElements *= dimsd; 
                    m_regularSpaced[d] = 1; 
                    if (dimsd > 1)
                        m_nonSingletonDimensions++; 
                    continue;
                    #endregion
                } else {
                    // parse all partial ranges 
                    #region parse complex range
                    foreach (string range in ranges) {
					    // step through each single range spec.
					    string[] rngitems = range.Split(':');
					    switch (rngitems.Length) {
						    case 1:
							    // single number specified 
                                if (rngitems[0].Trim().ToLower() == "end") {
                                    tmpValue = (dimsd-1);
                                } else if (! int.TryParse(rngitems[0].Trim(),out tmpValue)) 
                                    throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
							    if (tmpValue < 0)
                                    throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                if (tmpValue >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                    else {
                                        Expanding = true; 
                                        if (m_expandDimensions[d] <= tmpValue) 
                                            m_expandDimensions[d] = tmpValue + 1; 
                                    }
                                }  
                                idxList.Add (tmpValue);
							    break;
						    case 2: 
							    // unstepped range specified 
                                rngitems[0] = rngitems[0].Trim(); 
                                rngitems[1] = rngitems[1].Trim(); 
                                // check valid or full 
                                if (rngitems[0].Length == 0 || rngitems[1].Length == 0) {
                                    // "full" must be filtered in advance! (see above)
                                   start = 0; ende = dimsd - 1; 
                                } else if(rngitems[1].ToLower() == "end") {
                                    ende = dimsd-1;
                                    if (! int.TryParse(rngitems[0],out start)) {
                                        throw new ILArgumentException("invalid index near ':' for dimension " + d.ToString());                                        
                                    }
                                } else {
                                    if (! int.TryParse(rngitems[0],out start) || 
							            ! int.TryParse(rngitems[1],out ende)) {
                                        throw new ILArgumentException("invalid index near ':' for dimension " + d.ToString());
                                    }
                                }
							    if (start < 0 || ende < 0)   
                                    throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                if (start >= dimsd || ende >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                    else {
                                        Expanding = true; 
                                        int tmpVal = (start > ende) ? start : ende;  
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal + 1; 
                                    }
                                }  
                                if (start<=ende) {
							        for (int t = start; t <= ende;) {
								        idxList.Add (t++);
							        }
						        } else {
							        for (int t = start; t >= ende;) {
								        idxList.Add (t--);
							        }
						        }
						        break;
						    case 3:
							    // stepped range specified
                                rngitems[0] = rngitems[0].Trim(); 
                                rngitems[1] = rngitems[1].Trim(); 
                                rngitems[2] = rngitems[2].Trim();
							    if (rngitems[0].ToLower() == "end") {
                                    start = dimsd - 1; 
                                    if (! int.TryParse(rngitems[1],out step) ||
                                        ! int.TryParse(rngitems[2],out ende)) 
                                        throw new ILArgumentException("invalid index for dimension " + d.ToString());
							    } else if (rngitems[2].ToLower() == "end") {
                                    ende = dimsd - 1; 
                                    if (! int.TryParse(rngitems[0],out start) ||
                                        ! int.TryParse(rngitems[1],out step)) 
                                        throw new ILArgumentException("invalid index specification for dimension " + d.ToString());
                                } else {
                                    if (! int.TryParse(rngitems[0],out start) ||
                                        ! int.TryParse(rngitems[1],out step)  || 
                                        ! int.TryParse(rngitems[2],out ende)) 
                                        throw new ILArgumentException("invalid index for dimension " + d.ToString());
                                }
							    if (start < 0 || ende < 0) 
                                    throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                if (start >= dimsd || ende >= dimsd) {
                                    if (side == RangeSide.Right)
                                        throw new ILArgumentException("invalid index for dimension " + d.ToString()); 
                                    else {
                                        Expanding = true; 
                                        int tmpVal = (start > ende) ? start : ende; 
                                        if (m_expandDimensions[d] <= tmpVal) 
                                            m_expandDimensions[d] = tmpVal + 1; 
                                    }
                                }  
                                if (start<=ende) {
								    if (step > 0) {
									    for (int t = start; t <= ende;t += step) {
										    idxList.Add(t);
									    }
								    }
							    } else {
								    if (step < 0) {
									    for (int t = start; t >= ende;t += step) {
										    idxList.Add(t); 
									    }
								    }
							    }
							    break;
						    default: 
							    throw new ArgumentException("invalid range for dimension " +d.ToString());
					    } // case :,::,:::
				    } // foreach range
                    #endregion
                    // what if range > dims specified?
                    //if (d >= m_nrDims) { 
                    //    if (idxList.Count == 1) {
                    //        if (idxList[0] != 0)
                    //            throw new ILArgumentException("invalid range for dimension: " + d.ToString());
                    //    } else if (idxList.Count > 1) {
                    //        m_nonSingletonDimensions++ ;
                    //        if (idxList[0] != 0 || idxList[1] != 0 || !idxList.IsRegularSpaced)
                    //            throw new ILArgumentException("invalid range for dimension: " + d.ToString());
                    //    }
                    //    continue; 
                    //}
				    m_range[d] = (int[])idxList.ToArray();
                    int idxlistcount = idxList.Count;
                    m_numberOfElements *= idxlistcount;
                    m_regularSpaced[d] = (idxList.IsRegularSpaced)? idxList.RegularSpacing : int.MinValue; 
                    if (idxlistcount > 1) 
                        m_nonSingletonDimensions++; 
                }
			} // for d < rng.Length
		}

		/// <summary>
		/// Evaluates (maps) index array on my range. 
		/// </summary>
		/// <param name="idx">int array indexing location inside this range</param>
        /// <param name="retIdx">(output) also return the result into array given</param>
		/// <returns>Mapped int[] array. It can be used for direct addressing the physical storage object.</returns>
        /// <remarks>retIdx must be at least of length m_nrDims. No check is made for that!</remarks>
		public int[] Map(int[] idx, ref int [] retIdx) {
            int tmpVal; 
			for (int d = 0; d < m_nrDims; d++) {
				tmpVal = m_range[d][0]; 
                if (tmpVal < 0)
                    retIdx[d] = idx[d];
                else 
                    retIdx[d] = m_range[d][idx[d]];
			} 
            return retIdx; 
		}
	    /// <summary>
	    /// copy constructor
	    /// </summary>
	    /// <returns></returns>
		public ILRange Copy () {
			return new ILRange(this);
		}
		/// <summary>
		/// Create trimmed ILDimension from indices in ILRange object
		/// </summary>
		/// <returns>new ILDimension object with the neccessary size to 
		/// hold all indices in this range</returns>
		public ILDimension GetDimensions() {
            return new ILDimension(true,Limits); 
		}
        /// <summary>
        /// length of all dimensions of this range
        /// </summary>
        /// <remarks>This property is readonly. Keep in mind, it does not cache the values.</remarks>
        public int[] Limits {
			get{
                int[] dims = new int[m_nrDims]; 
			    for (int d = 0; d < m_nrDims; d ++) { 
                    if (m_range[d][0] < 0)
                        dims[d] = - m_range[d][0] + 1; 
                    else 
				        dims[d] = m_range[d].Length; 
			    }
                return dims;
            }
		}

		/// <summary>
		/// built a plain physical copy of the ranges stored in m_range in sequential order
		/// </summary>
		/// <returns>int array holding the whole m_range information in sequential order</returns>
		/// <remarks>This reordering is convinient for "marshaling" the multidimensional array to C.
		/// The format of the returned (1 dim.) array is: 
		/// <list type="bullet">
		/// <item>1 int : the number of dimensions</item>
		/// <item>X int : [nrOfDimensions] int holding the number of int for each dimension</item>
		/// <item>Y int : all the int values for each dimension after each other </item></list> 
		/// The overall size of the returned array is therefore: nrOfElements + nrOfDimensions + 1, 
		/// where nrOfElements is the sum of all elements in each dimension of m_range.</remarks>
		public int[] BuildSequentialArray() {
			int [] ret = new int [NumberOfElements + 1 + m_nrDims];
			ret[0] = m_nrDims; 
			int counter = m_nrDims + 1; // start of values in return array
			for (int d=0; d < m_nrDims; d++) {
				ret[d+1] = m_range[d].Length; 
				for (int c = 0; c < m_range[d].Length; c ++)
					ret[counter ++] = m_range[d][c]; 
			}
			return ret;
		}
	
		/// <summary>
		/// Distance between adjecent samples for this range
		/// </summary>
		/// <param name="dimIdx">dimension index to get spacing for</param>
		/// <returns>Spacing of samples inside the dimension if range would be applyied to 
		/// it or negative value if the range cannot produce an 
		/// "BLAS-able" reference storage.</returns>
        /// <remarks><para>For solid arrays, this always reflects the storage 
        /// structure of the array. I.e. 1  will be returned for the first 
        /// dimension (dimIdx = 0), for the second (dimIdx = 1) etc.</para> 
        /// <para>For reference storages this may or may not hold. It does 
        /// however only hold, if the range the array was constructed of 
        /// was regulary spaced.</para></remarks>
		internal int Spacing(int dimIdx) {
			return m_regularSpaced[dimIdx]; 
		}

        /// <summary>
        /// determine if the indices of each dimension are equally spaced (important for ATLAS use)
        /// </summary>
        /// this was replaced with cached version  -> now obsolete: delete!
        //private void isRegularySpaced() {
        //    // run through non singleton dimensions
        //    int spacing;
        //    for (int t = 0; t < m_nrDims; t++) {
        //        if (m_range[t].Length > 1 ) {
        //            m_regularSpaced[t] = spacing = m_range[t][1] - m_range[t][0]; 
        //            for (int r = 1; r < m_range[t].Length; r++) {
        //                if (m_range[t][r] - m_range[t][r-1] != spacing) {
        //                    m_regularSpaced[t] = int.MinValue; 
        //                    break; 
        //                }
        //            }
        //        } else {
        //            m_regularSpaced[t] = 1; 
        //        }
        //    }
        //}

        /// <summary>
        /// resize the number of dimensions this ILRange holds
        /// </summary>
        /// <param name="nrDims">new number of dimensions</param>
		protected void Resize(int nrDims) 
		{
            //if (nrDims < 2) 
            //    nrDims = 2; 
            m_range = new int[nrDims][]; 
			m_regularSpaced = new int[nrDims];
			m_nrDims = nrDims; 
            m_numberOfElements = 0; 
		}

	}
    /// <summary>
    /// helper class used to collect range entries for one dimension and 
    /// check for regular spacing while adding items
    /// </summary>
    internal class RegularSpacedList : System.Collections.Generic.List<int> {
        /// <summary>
        /// internal field, stored the current value of regular spacing
        /// </summary>
        private int m_regularSpacing = 1;
        /// <summary>
        /// Give the spacing between elements of this list
        /// </summary>
        public int RegularSpacing {
            get {
                return m_regularSpacing; 
            }
        }
        /// <summary>
        /// internal field, stores flag on regular spacing
        /// </summary>
        private bool m_isRegularSpaced = true; 
        /// <summary>
        /// Get if all elements of this list are regulary spaced (in incoming order)
        /// </summary>
        public bool IsRegularSpaced {
            get {
                return m_isRegularSpaced; 
            }
        }
        /// <summary>
        /// internal field, keeps the last value for comparison
        /// </summary>
        private int m_lastValue = int.MaxValue; 
        /// <summary>
        /// Constructor creating emtpy ILRegularSpacedList
        /// </summary>
        public RegularSpacedList() : base() {}
        /// <summary>
        /// Constructor creating emtpy ILRegularSpacedList, given capacity
        /// </summary>
        public RegularSpacedList(int capacity) : base (capacity) {}
        /// <summary>
        /// Add elements to this list
        /// </summary>
        /// <param name="value">new element</param>
        public new void Add(int value) {
            base.Add(value);
            if (Count == 1) {
                m_lastValue = value; 
            } else if (Count == 2) {
                m_regularSpacing = value - m_lastValue;   
                m_lastValue = value; 
            } else if(m_isRegularSpaced) {
                if (value - m_lastValue != m_regularSpacing)
                    m_isRegularSpaced = false;
                m_lastValue = value; 
            }
        }
        /// <summary>
        /// reset / clear this list
        /// </summary>
        public new void Clear() {
            base.Clear();
            m_lastValue = int.MaxValue; 
            m_regularSpacing = 1; 
            m_isRegularSpaced = true; 
        }
    }
}
