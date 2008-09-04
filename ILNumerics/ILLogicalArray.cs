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
using ILNumerics.Storage;
using ILNumerics.Native;
using ILNumerics.BuiltInFunctions;
using System.Text; 

namespace ILNumerics {
	/// <summary>
	/// Boolean array for high performance relational operations on arbitrary arrays 
	/// </summary>
	/// <remarks>
	/// logical arrays are derived from <![CDATA[ILArray<byte>]]>. It consumes
	/// 1 byte per element and is the output parameter of all relational comparisons
	/// as well as the input parameter for all functions consuming <![CDATA[ILArray<byte>]]>.
    /// The difference between <![CDATA[<byte>]]> and an ILLogicalArray is, the ILLogicalArray 
    /// storing a integer value with the number of nonzero elements as additional information. 
    /// Therefore functions like 'find' are able to determine the lenght of output array to 
    /// be created omitting the need of multiple walks through the array. Therefore ILLogicalArrays 
    /// consume (a little) more time while construction but are much more performand on functions like 
    /// 'find'.
	/// </remarks>
    [Serializable]
    public class ILLogicalArray : ILArray<byte> {
        #region  
        /// <summary>
        /// internal field, caches the number of 'true' elements
        /// </summary>
        protected int m_numberNonZero;
        /// <summary>
        /// Number of 'true' elements in this array
        /// </summary>
        /// <remarks> this value caches the number of 'true' elements in this ILLogicalArray. 
        /// It may be used for information purposes but is actually needed for performance 
        /// reasons.</remarks>
        public int NumberTrues {
            get {
                return m_numberNonZero;
            }
        }
        /// <summary>
		///	constructor - create ILLogicalArray of type <code>Byte</code> of specified size
		/// </summary>
		/// <param name="size">
		/// Variable length int array specifying the number and size of dimensions to 
		/// be created.
		/// </param>
		/// <remarks>
		/// The size parameter may not be null or an empty array! An Exception will be 
		/// thrown in this case. The dimensions will be trimmed before processing 
		/// (removing trailing non singleton dimensions). 
        /// Depending on the requested size an ILArray &lt; byte &gt; of the specified dimensions 
		/// will be created. The type of storage will be <code>bool</code>.
		/// </remarks>
		public ILLogicalArray(params int[] size)
										   : base(size) {
            m_numberNonZero = sumElements(); 
		}
        /// <summary>
        /// Constructor creating ILLogicalArray from <![CDATA[ILArray<byte>]]>
        /// </summary>
        /// <param name="A">input array, the storage of this ILArray will directly be used for 
        /// storage of the new ILLogicalArray</param>
		public ILLogicalArray(ILArray<byte> A)
			: base(A) {
			m_numberNonZero = sumElements();
		}
        /// <summary>
        /// Constructor creating ILLogicalArray from <![CDATA[ILArray<byte>]]>
        /// </summary>
        /// <param name="A">input array, the storage of this ILArray will directly be used for 
        /// storage of the new ILLogicalArray</param>
        /// <param name="numberNonZero">number of nonzero elements in A. Must be positive or 0.</param>
        /// <remarks> Providing this parameter prevents the constructor from having to count the 
        /// 'true' elements in A.</remarks>
		public ILLogicalArray(ILArray<byte> A, int numberNonZero)
			: base(A) {
            if (numberNonZero < 0) 
                throw new ILNumerics.Exceptions.ILArgumentException("invalid number of non-zero-elements given!");
			m_numberNonZero = numberNonZero;
		}
		/// <summary>
		///	constructor - create ILLogicalArray of specified size 
		/// from data array
		/// </summary>
		/// <param name="size">
		/// Variable length int array specifying the number and size of dimensions to 
		/// be created.
		/// </param>
		/// <param name="data"> byte array matching the size of the dimensions 
		/// specified. The data will directly be used as storage! No copy will be made!</param>
		/// <remarks>
		/// The size parameter may not be null or an empty array! An Exception will be 
		/// thrown in this case. The dimensions will be trimmed before processing 
		/// (removing trailing non singleton dimensions). 
		/// Depending on the requested size an ILLogicalArray of the specified size 
		/// will be created. The type of storage will be <code>byte</code>.
		/// </remarks>
        public ILLogicalArray(byte[] data, params int[] size)
										   : base (data,size) {
            m_numberNonZero = sumElements(); 
		}
        /// <summary>
        /// Constructor creating ILLogicalArray, provide predefined storage
        /// </summary>
        /// <param name="data">predefined storage elements. The array will directly be used 
        /// as underlying storage. No copy will be made! </param>
        /// <param name="dimension">Dimensions specification.</param>
        public ILLogicalArray (byte[] data, ILDimension dimension) 
                                            : base (data,dimension ) {
            m_numberNonZero = sumElements();    
        }
        /// <summary>
        /// Constructor creating ILLogicalArray, predefined storage (fast version)
        /// </summary>
        /// <param name="data">predefined storage elements. The array will directly be used 
        /// as underlying storage. No copy will be made! </param>
        /// <param name="dimension">Dimensions specification.</param>
        /// <param name="nonZeroCount">number of nonzero elements in <paramref name="data"/>. 
        /// Providing this parameter prevents from counting the 'true' elements (again). </param>
        public ILLogicalArray (byte[] data, ILDimension dimension, int nonZeroCount) 
                                            : base (data,dimension ) {
            if (nonZeroCount < 0) 
                throw new ILNumerics.Exceptions.ILArgumentException("invalid number of non-zero-elements given!");
            m_numberNonZero = nonZeroCount;     
        }

        ///// <summary>
        /////		'Copy' Constructor. creates a new ILLogicalArray as reference to given ILLogicalArray
        ///// </summary>
        ///// <param name="data">
        ///// ILArray object to create a reference to
        ///// </param>
        ///// <remarks>
        ///// The ILArray given will not really be copied, but a reference will be
        ///// created for it.
        ///// </remarks>
        //public ILLogicalArray(ILLogicalArray data)
        //                                   : base(data) {
        //    m_numberNonZero = sumElements();
        //}

        /// <summary>
        ///  sum all elements of this storage. 
        /// </summary>
        /// <returns>Number of non zero elements</returns>
        private int sumElements() {
            int ret = 0; 
            int nrElements = m_dimensions.NumberOfElements; 
            if (IsReference) { 
                byte[] data = m_data; 
                // reference storage 
                int curIdx = 0;
                while (curIdx < nrElements)
                    ret += data[m_indexOffset.Map(curIdx++)]; 
            } else {
                // physical storage 
                unsafe {
                    fixed (byte* pInArray = m_data) {
                        byte* pCurData = pInArray;
                        byte* pLastElement = pInArray + nrElements;
                        while (pCurData < pLastElement)
                            ret += *pCurData++;
                    }
                }
            }
            return ret; 
        }
        #endregion
 
        #region Subarray overloading
        /// <summary>
        /// Concatenate this array
        /// </summary>
        /// <param name="inArray">N-dimensional storage. Except for dimensions leadDim 
        /// the dimensions must match the dimensions of this storage.</param>
        /// <param name="leadDim">index of dimension to concatenate arrays along.
        /// If leadDim is larger than the number of dimensions of any of the arrays
        /// its value will be used in modulus</param>
        /// <returns>logical array having the size 
        /// of both input arrays layed behind each other along the leadDim's-dimension</returns>
        /// <remarks>The array returned will be a 
        /// <list type="bullet">
        /// <item> reference storage, if inArray is the same as this array (object references 
        /// are the same) and ILArray.MinimumRefDimensions is less or equal 
        /// the number of dimensions of the resulting storage, or a 
        /// </item>
        /// <item>physical storage else. 
        /// </item></list>
        /// There are only very few cases where it is possible to reference two arrays in the 
        /// same reference storage. Not only the storages must point to the same underlying 
        /// physical System.Array, but the ILIndexOffset must be suited in a special way. 
        /// Therefore the restriction was made always to create a reference storage, if 
        /// both storages are not the same.</remarks>
        public new  ILLogicalArray Concat(ILArray<byte> inArray, int leadDim) {
            return new ILLogicalArray (base.Concat(inArray, leadDim));
        }
        /// <summary>
        /// Replicate this ILArray. Make large ILLogicalArray out of it.
        /// </summary>
        /// <param name="dims">dimensions specifier. This may be a comma sep.
        /// list or an array of integer values. If the number of elements in dim is 
        /// less the number of dimensions in this ILArray, the trailing dimensions will 
        /// be set to 1 (singleton dimensions). On the other hand, if the number specified 
        /// is larger then the number of dimension stored inside the storge the resulting 
        /// storage will get its number of dimensions extended accordingly. </param>
        /// <returns>large array beeing a multiple (dims) copy of this array along 
        /// arbitrary dimensions</returns>
        /// <remarks>The array returned will be a 
        /// <list type="bullet">
        /// <item> reference storage, if the number of dimensions resulting is more or equal 
        /// to ILArray.MinimumRefDimensions, or a 
        /// </item>
        /// <item>physical storage else. 
        /// </item></list>
        /// </remarks>
        public new ILLogicalArray Repmat(params int[] dims) {
            return new ILLogicalArray(base.Repmat(dims));
        }

        /// <summary>
        ///	Subarray from this array
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public new ILLogicalArray Subarray (params ILBaseArray[] range) {
           return new ILLogicalArray((ILArray<byte>)base.Subarray(range)); 
        }
        /// <summary>
        ///	Subarray from this ILArray + dimension shift
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public new ILLogicalArray Subarray (int shift, ILBaseArray[] range) {
            return new ILLogicalArray((ILArray<byte>)base.Subarray(shift,range));         
        }
        /// <summary>
        ///	Subarray to this array + dimension shift
        /// </summary>
        /// <param name="range"> string specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public new ILLogicalArray Subarray (int shift, params string [] range){
            return new ILLogicalArray((ILArray<byte>)base.Subarray(shift,range));         
        }
        /// <summary>
        ///	Subarray from this array
        /// </summary>
        /// <param name="range"> strings specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public new ILLogicalArray Subarray (params string [] range){
            return new ILLogicalArray((ILArray<byte>)base.Subarray(range));         
        }
        #endregion

		/// <summary>
		/// Check if the content of this array equals the content of obj
		/// </summary>
		/// <param name="obj">typed ILArray containing the values to compare this array with</param>
		/// <returns>true if all elements contained in obj are equal to the 
		/// elements of this array. False otherwise.</returns>
		/// <remarks> This method compares the object references of corresponding elements. 
		/// The size and type of both arrays must match. Otherwise false will be returned.</remarks>
		public override bool Equals(object obj) {
			ILLogicalArray ILObj;
			if (!(obj is ILLogicalArray))
				return base.Equals(obj);
			ILObj = obj as ILLogicalArray; 
			if (!ILObj.Dimensions.IsSameSize(Dimensions))
				return false;
			for (int i = 0; i < m_dimensions.NumberOfElements; i++) {
                if (GetValue(i) != ILObj.GetValue(i)) return false; 
            } 
			return true;
        }
        /// <summary>
        /// give the HashCode for this ILLogicalArray
        /// </summary>
        /// <returns>HashCode as given from base class</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        
        #region operator overloading 
        /// <summary>
        /// Implicitly convert Byte scalar to ILLogicalArray of size 1x1 (scalar).
        /// </summary>
        /// <param name="val">Byte scalar</param>
        /// <returns>New ILLogicalArray of size 1x1 holding the only element of type Byte 
        /// with value of val.</returns>
        public static implicit operator ILLogicalArray(bool val) {
            ILLogicalArray ret = new ILLogicalArray(new byte[1] { val ? (byte)1 : (byte)0 }, 1, 1);
            return ret;
        }
        /// <summary>
        /// Implicit cast System.Array of type byte[] to ILLogicalArray
        /// </summary>
        /// <param name="vector_elements">predefined elements values</param>
        /// <returns>new ILLogicalArray using the System.Array given as storage.</returns>
        /// <remarks><para>Since the System.Type 'byte' can address more then 2 values used by ILLogicalArray (i.e. '0' and '1'), 
        /// and the given array is directly be used as storage for the newly created array, undefined behavior can result, if 
        /// the System.Array given contains values other then 0 or 1. No check is made for this!</para></remarks>
        public static implicit operator ILLogicalArray (byte[] vector_elements) {
            return new ILLogicalArray(vector_elements,1,vector_elements.Length); 
        }

        
        /// <summary>
        /// Implicitly convert ILLogicalArray of size 1x1 to bool/byte (scalar).
        /// </summary>
        /// <param name="A">scalar ILLogicalArray</param>
        /// <returns>true if A is scalar array holding the only element '01', false otherwise 
        /// </returns>
        /// <remarks> if A is null, the function will always return false. If 'A' is empty or not scalar,
        /// an ILArgumentException will be thrown.</remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentSizeException"> if A is not scalar</exception>
        public static implicit operator bool(ILLogicalArray A) {
            // this operator is implicit for convenience reasons: 
            // if(tmp[0]!=-10.0) { ... is only possible this way
            if (object.Equals(A,null))
                return false;
            if (A.IsScalar)
                return A.GetValue(0, 0) == 1; 
            throw new ILNumerics.Exceptions.ILArgumentException(String.Format("cast to bool: array given must be scalar. Was: {0}",A.Dimensions.ToString()));
        }
        /// <summary>
		/// Implicitly convert integer scalar to ILLogicalArray of size 1x1 (scalar).
		/// </summary>
		/// <param name="val">scalar value</param>
		/// <returns>New ILLogicalArray of size 1x1 holding the only element of type Byte 
		/// with value of val.</returns>
		public static implicit operator ILLogicalArray(int val) {
			ILLogicalArray ret = new ILLogicalArray(new Byte[1] { 
								 val != 0 ? (byte)1:(byte)0 }, 1, 1);
			return ret;
        }
        /// <summary>
        /// invert values of array elements 
        /// </summary>
        /// <param name="in1">input array</param>
        /// <returns>new solid ILLogicalArray, inverted element values</returns>
        public static ILLogicalArray operator !(ILLogicalArray in1) {
            if (object.Equals(in1,null))
                throw new ILArgumentException("operator -(): parameter must not be null!");
            return (in1 != 1.0);  
        }

        #endregion
   
        #region serialization

        /// <summary>
        /// Serialize this ILLogicalArray into stream. 
        /// </summary>
        /// <param name="outStream">System.IO.Stream to receive/store this objects data</param>
        /// <returns>true on success, false on error.</returns>
        /// <remarks>Use this member to convert the data of this array 
        /// to persistant state. The storage will automatically determine the 
        /// state wich will consume less memory and detach itself accordingly. 
        /// </remarks>
        /// <example>
        /// <code>
        /// FileStream fs = new FileStream("filename", FileMode.Create);
        /// A.Serialize(fs); 
        /// fs.Close();
        /// </code></example>
        public override bool Serialize(System.IO.Stream outStream) {
            return  base.Serialize(outStream);
        }
        /// <summary>
        /// Deserialize an ILLogicalArray from stream 
        /// </summary>
        /// <param name="inStream">strem to read from</param>
        /// <returns>ILLogicalArray deserialized from stream</returns>
        public new static ILLogicalArray Deserialize(System.IO.Stream inStream) {
            return (ILLogicalArray)ILBaseArray<Byte>.Deserialize(inStream); 
        }
        #endregion 

        #region index access
		/// <summary>
		/// Subarray access for ILArray. Get: Create referencing subarray, 
		/// Set: alter range of this ILArray with new value elements.
		/// </summary>
		/// <paramref name="dims" value="Range specification for subarray elements"/>
		public new ILLogicalArray this[params string[] dims] {
			get {
				return new ILLogicalArray(base[dims]);
			}
			set {
				base[dims] = value;
                // ugly hack: this will diminish performance, should be integrated into setrange()
                m_numberNonZero = sumElements(); 
			}
		}
		/// <summary>
		/// Subarray access for ILArray and dimension shift
		/// </summary>
		/// <paramref name="dims" value="dimension specification"/>
		/// <value>returns new ILArray as reference subarray to this ILBaseArray</value>
		public new ILLogicalArray this[Int16 shiftDims, params string[] dims] {
			get {
				return new ILLogicalArray( base[shiftDims, dims]);
			}
		}
        /// <summary>
        /// subarray access
        /// </summary>
        /// <param name="range">range specification</param>
        /// <returns>reference pointing to the elements of this array specified by range. If used for removal: 
        /// the array will be changed to a referencing array having the parts requested removed and reshaped accordingly.</returns>
        /// <remarks>Query access: for N-dimensional arrays trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in range.
        /// <para>The indexer may be used for querying or altering single/any elements 
        /// in this array. <c>range</c> may contains index specifications for one ... any 
        /// dimension. The array returned will have the size specified by range.</para>
        /// <para>The indexer may also be used for removing parts of the array. Therefore an empty array 
        /// (of the same type) or 'null' must be assigned to the range specified by <c>range</c> using the set-access. <c>range</c> 
        /// must contain exactly one dimension specification other than null. This may be any vector-sized numeric ILArray of any 
        /// type. If <c>range</c> applies 
        /// to less dimensions than dimensions existing in the array, the upper dimensions will be 
        /// merged and the array will be reshaped before applying the removal to it.</para>
        /// <para>In case of removal the ILArray returned will be a reference array.</para></remarks>
        public new ILLogicalArray this[params ILBaseArray[] range] {
            get {
                return new ILLogicalArray(base[range]);
            }
            set {
                base[range] = value;
                m_numberNonZero = sumElements(); 
            }
        }
        /// <summary>
        /// ranged subarray access
        /// </summary>
        /// <param name="shiftdim">number of dimensions to shift the result</param>
        /// <param name="range">range specification</param>
        /// <returns>reference pointing to the elements of this array specified by range. </returns>
        /// <remarks>For n-dimensional arrays trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in range. However, if range contains only one array, those indices 
        /// are interpreted as sequential index access elements. I.e. the elements in the index vector are allowed to 
        /// range from 0...[NumberOfElements-1]. A vector containing corresponding elements will be returned for this case.
        /// <para>The indexer may be used for querying single/any elements 
        /// in this array. <c>range</c> may contains index specifications for one ... any 
        /// dimension. The array returned will have the size specified by range.</para></remarks>
        public new ILLogicalArray this[short shiftdim, params ILBaseArray[] range] {
            get {
                return new ILLogicalArray(base[shiftdim, range]);
            }
        }
        /// <summary>
		/// Single element access
		/// </summary>
		/// <param name="dims">dimensions specifier. int array or comma seperated list.
		/// If this is a single int element only, this will lead to sequential index access. 
        /// If dims consist out of at least 2 elements, trailing missing dimensions will be replaced by "0". </param>
		/// <returns>Scalar ILLogicalArray element pointed to by 'dims'</returns>
		public new ILLogicalArray this[params int[] dims] {
			get {
				return new ILLogicalArray(base[dims]);
			}
			set {
                // if possible: remember old value 
                byte oldValue = 0; 
                bool mustExpand = false; 
                int[] dimens = m_dimensions.ToIntArray(dims.Length); 
                int baseIdx = getBaseIndex(ref mustExpand, ref dimens, dims); 
                if (baseIdx < m_data.Length) {
                    oldValue = m_data[baseIdx]; 
                }
                // if something went wrong (base throws  exception), 
                // -> nothing will be altered
                base[dims] = value; 
                // udate 
                if (oldValue > 0 && (object.Equals(value,null) || value.IsEmpty)) {
                    m_numberNonZero--; 
                } else {
                    m_numberNonZero += (value.GetValue(0) - oldValue); 
                }
			}
		}
		#endregion

        /// <summary>
        /// get reference to this array having the dimensions shifted by <c>shiftDimensions</c>.
        /// </summary>
        /// <param name="shiftDimensions">number of dimensions to shift this array (to the left for positive values)</param>
        /// <returns>Referencing ILArray of the same type and size with <c>shiftDimensions</c> dimensions shifted to the left.</returns>
        public new ILLogicalArray GetShifted(int shiftDimensions) {
            return new ILLogicalArray ((ILArray<byte>)base.ShiftDimensions(shiftDimensions),m_numberNonZero); 
        }
        /// <summary>
        /// Create a full reference from this ILLogicalArray
        /// </summary>
        /// <returns>object of real type 'ILLogicalArray' as full reference to this ILLogicalArrays.</returns>
        public override ILBaseArray CreateReference() {
            return new ILLogicalArray((ILArray<byte>)base.CreateReference(),m_numberNonZero);
        }
        /// <summary>
        /// output information about this ILLogicalArray
        /// </summary>
        /// <param name="s">predefined string, to be used as prefix for output</param>
        /// <param name="maxLength">number of characters in lines of output</param>
        /// <returns>string representation of this ILLogicalArray</returns>
        public override String ToString(String s, int maxLength) {
			StringBuilder sb = new StringBuilder(s);
			// print dimension string 
			ILDimension dim = Dimensions;
			sb.Append(String.Format("\r\nILLogicalArray: '{0}'\r\n",
				(Name.Length > 0) ? Name : this.GetHashCode().ToString()));
			sb.Append("[");
			for (int t = 0; t < dim.NumberOfDimensions; t++) {
				sb.Append(dim[t]);
				if (t < dim.NumberOfDimensions - 1)
					sb.Append(",");
			}
			sb.Append("] ");
			// status flags
			if (IsReference)
				sb.Append("Ref(" + GetNumberOfReferences() + ") ");
			else
				sb.Append("Phys. ");
			sb.Append( ValuesToString(maxLength));
			return sb.ToString();
		}
        /// <summary>
        /// output information about this ILLogicalArray
        /// </summary>
        /// <returns>string representation of this ILLogicalArray</returns>
		public override String ToString() {
			return ToString("", 0);
        }

        #region redefined properties 
        /// <summary>
        /// shift the dimensions of this array by one (transpose for matrix)
        /// </summary>
        public new ILLogicalArray T {
            get {
                return new ILLogicalArray(base.T,m_numberNonZero); 
            }
        }
        /// <summary>
        /// create solid array as copy of this array 
        /// </summary>
        public new ILLogicalArray C {
            get {
                return new ILLogicalArray(base.C,m_numberNonZero); 
            }
        }
        /// <summary>
        /// create solid array as reference to this array 
        /// </summary>
        public new ILLogicalArray R {
            get {
                return new ILLogicalArray(base.R,m_numberNonZero); 
            }
        }
        #endregion redefined properties   

        #region overwritten base functions 
        /// <summary>
        /// [deprecated] create empty ILLogicalArray 
        /// </summary>
        /// <returns>empty ILLogicalArray.</returns>
        public static new ILLogicalArray empty() {
            return new ILLogicalArray(new byte[0],0,0);
        }
        #endregion





    }
}
