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
using ILNumerics.Storage;
using ILNumerics.Native; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections; 



namespace ILNumerics {
    /// <summary>
    /// The base type for all array datatypes of ILNumerics.Net
    /// </summary>
    /// <remarks>All numerical arrays must derive from ILBaseArray. ILBaseArrays itself 
    /// cannot be instanciated. By now only ILArray<![CDATA[<>]]> exist, which describes 
    /// a rectangular array as full (solid) or referencing array. There are plans to 
    /// extend the collection of derived types by triangular and sparse arrays. 
    /// </remarks>
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("")]
    public abstract class ILBaseArray {

        internal ILBaseArray() {
            // todo: determine type of architecture etc...
        }

        #region implicit casts 
        /// <summary>
        /// cast scalar to ILBaseArray
        /// </summary>
        /// <param name="input">system value type</param>
        /// <returns>ILBaseArray</returns>
        public static  implicit operator ILBaseArray (double input) {
            return new ILArray<double>(new double[1]{input}); 
        }
        /// <summary>
        /// cast scalar to ILBaseArray
        /// </summary>
        /// <param name="input">system value type</param>
        /// <returns>ILBaseArray</returns>
        /// <remarks>The ILBaseArray returned will be scalar of type ILArray&lt;complex></remarks>
        public static  implicit operator ILBaseArray (complex input) {
            return new ILArray<complex>(new complex[1]{input}); 
        }
        /// <summary>
        /// cast scalar to ILBaseArray
        /// </summary>
        /// <param name="input">system value type</param>
        /// <returns>ILBaseArray</returns>
        /// <remarks>The ILBaseArray returned will be scalar of type ILArray&lt;byte></remarks>
        public static  implicit operator ILBaseArray (byte input) {
            return new ILArray<byte>(new byte[1]{input}, 1, 1);
        }
        #endregion implicit casts

        /// <summary>
		///		Name of this object.
		/// </summary>
		protected String m_name = "";
		/// <summary>
		///		Set/Get name for this object.
		/// </summary>
		public String Name {
			get {
				if (m_name == null || m_name.Length == 0) 
					return String.Format("IL{0}",this.GetHashCode());
				else 	
					return m_name;
			}
			set {
                m_name = value; 
			}
		}
        /// <summary>
        /// dimension specification for this storage object
        /// </summary>
        internal ILDimension m_dimensions;
        /// <summary>
        /// Dimension for this storage. 
        /// </summary>
        /// <value>This is a read only property. Only derived types are allowed to alter the dimensions object directly.</value>
        public ILDimension Dimensions {
            get {
                return m_dimensions;
            }
            protected set {
                m_dimensions = value; 
            }
        }
        #region public properties
        /// <summary>
        /// Length of longest dimension in this instance
        /// </summary>
        /// <remarks>This attribute is readonly.</remarks>
        public int Length {
            get {
                return m_dimensions.Longest;
            }
        }
        /// <summary>
        /// Determine if this instance is a scalar
        /// </summary>
        /// <remarks>This attribute is readonly. It returns: Dimension.NumberOfElements == 1.</remarks>
        public bool IsScalar {
            get {
                return m_dimensions.NumberOfElements == 1;
            }
        }
        /// <summary>
        /// Determine if this array is a matrix.
        /// </summary>
        /// <remarks>In order for an array to be a matrix the number of <b>non singleton</b> 
        /// dimensions must equal 2. This attribute is readonly. </remarks>
        public bool IsMatrix {
            get {
                return m_dimensions.NumberOfDimensions == 2; 
            }
        }
        /// <summary>
        /// Determine if this array is a vector.
        /// </summary>
        /// <remarks>In order for an array to be a vector the number of <b>non singleton</b> 
        /// dimensions must equal 1. Keep in mind, all ILArrays have at least 2 dimensions. Therefore 
        /// it is not sufficient to test for the number of dimensions, but to take the number of 
        /// <b>non singleton</b> dimensions into account. This attribute is readonly. </remarks>
        public bool IsVector {
            get {
                return (Dimensions[0] == 1 || Dimensions[1] == 1) && Dimensions.NumberOfDimensions == 2;
            }
        }
        /// <summary>
        /// Test if this array instance is a row vector
        /// </summary>
        public bool IsRowVector {
            get {
                return Dimensions[0] == 1 && Dimensions.NumberOfDimensions == 2;
            }
        }

        /// <summary>
        /// Test if this array instance is a column vector
        /// </summary>
        public bool IsColumnVector {
            get {
                return Dimensions[1] == 1 && Dimensions.NumberOfDimensions == 2;; 
            }
        }
        /// <summary>
        /// true if array is empty (number of elements stored is 0)
        /// </summary>
        public bool IsEmpty {
            get {
                return m_dimensions.NumberOfElements == 0;
            }
        }
        /// <summary>
        /// Determine if this array is of complex inner type
        /// </summary>
        public abstract bool IsComplex {
            get; 
        }
        
        /// <summary>
        /// Determine if this array is of numeric inner type
        /// </summary>
        public abstract bool IsNumeric {
            get; 
        }

        #endregion

        /// <summary>
        /// Create full (shallow) copy of this storage. 
        /// </summary>
        /// <returns>ILArray as new (physical) representation of this storages data.</returns>
        /// <remarks>The ILArray object returned will be of the same size than this object.
        /// Keep in mind, no reference counters are altered! The new object is just a plain 
        /// copy of the old one which remains unchanged. Also: "copy" means, the m_data array
        /// will be copied, but (of course) not (!) the objects referenced by the array elements!
        /// Therefore this is a 'shallow' copy only! This is necessary, since objects stored inside
        /// ILArray do not have any restrictions. (Especially they do not have to support the IClonable()
        /// interface.) </remarks>
        public abstract object Clone(); 

        /// <summary>
        /// Convert values of elements into string representation.
        /// </summary>
        /// <param name="maxLength">0: all columns will be printed behind each other. 
        /// Other than 0: The columns will be split after 'maxLength' characters. </param>
        /// <returns>Formated string representation</returns>
        public abstract StringBuilder ValuesToString(int maxLength); 

        /// <summary>
        /// print values of this instance to stream 
        /// </summary>
        /// <param name="outStream">Stream to write the values into</param>
        /// <param name="format">Format string to be used for output. See <see cref="System.String.Format(string,object)"/> for a specification
        /// of valid formating expressions. This flag is only used, when 'method' is set to 'Serial' </param>
        /// <param name="method">a constant out of <see cref="ILArrayStreamSerializationFlags"/>. Specifies the way 
        /// the values will be serialized.</param>
        /// <remarks><para>If for method 'Formated' is used, any occourences of a NewLine character(s) 
        /// will be replaced from the format string before applying to the elements. This is due to 
        /// prevent the format from breaking the 'page' style for the output. </para>
        /// <para>If 'method' is set to 'Matlab', the array will be written as Matfile version 5.0. No compression will be used. The internal 'Name' property will be used as 
        /// array name for writing. This array instance will be the only array in the mat file. If you want to write several arrays bundled into one mat file, use the MatFile class to
        /// create a collection of arrays and write the MatFile to stream than. </para></remarks>
        public abstract void ToStream(Stream outStream, string format, ILArrayStreamSerializationFlags method); 
    }


    /// <summary>
	/// Typed base class for all ILNumerics.Net data storage classes for any storage type. 
    /// </summary>
    /// <remarks><para>You should not use this type directly. It serves as a base class 
    /// for all typed storages only and will be used be derived classes like ILArray<![CDATA[<>]]>.</para>
    /// <para>If you are looking for an (untyped) base class to be used as generic class for any ILArray types, you should use ILBaseArray instead!</para>
    /// </remarks>
	[Serializable]
    [System.Diagnostics.DebuggerDisplay("{m_dimensions.ToString()}")]
    public abstract class ILBaseArray<BaseT> : ILBaseArray, ICloneable, IEnumerable<ILArray<BaseT>> {
        /// <summary>
        /// The actual storage array. 
        /// </summary>
        /// <remarks> The derived type is responsible for the implementation, which way 
        /// the storage is used. So far, this is only an 1D-System.Array of arbitrary size 
        /// and type.This is hidden for framework users since direct public access 
        /// to the storage is not intended for public users. </remarks>
        internal BaseT[] m_data;
        /// <summary>
        /// Give direct reference for this data array
        /// </summary>
        /// <remarks>This property is only used by C++ derivate (copy constructor)</remarks>
        protected BaseT[] Data {
            get {
                return m_data; 
            }
            set {
                m_data = value; 
            }
        }

        #region public access wrapper shortcuts

#if LINUX
	/** 
	  XXX The construct below does not work on linux
	*/
#else
        ///// <summary>
        ///// Subarray access for ILBaseArray. Get: Create referencing subarray, 
        ///// Set: alter range of this ILBaseArray with new value elements.
        ///// </summary>
        ///// <paramref name="dims" value="Range specification for subarray elements"/>
        //public virtual ILBaseArray<BaseT> this[String dims] {
        //    get {
        //        try {
        //            return Subarray(new ILRange(m_dimensions, dims), 0);
        //        } catch (Exception e) {
        //            throw new ArgumentException("ILArray|Indexer[]: "
        //                + "Invalid range specification", e);
        //        }
        //    }
        //    set {
        //        //if (value.IsEmpty) {
        //        //    ILDimension newdim = null;
        //        //    int dimIdx = -1; 
        //        //    int[] indices = null; 
        //        //    ExtractRemovalParameter(new string[1]{dims},out dimIdx,out indices, out newdim); 
        //        //    Reshape(newdim);
        //        //    Remove(dimIdx,indices);
        //        //} else 
        //            SetRange(new ILRange(m_dimensions, dims), value);
        //    }
        //}
        ///// <summary>
        ///// Subarray access for ILArray and dimension shift
        ///// </summary>
        ///// <paramref name="dims" value="dimension specification"/>
        ///// <value>returns new ILArray as reference subarray to this ILBaseArray</value>
        //public virtual ILBaseArray<BaseT> this[String dims, int shiftDims] {
        //    get {
        //    }
        //}
        ///// <summary>
        ///// subarray access via double array indices
        ///// </summary>
        ///// <paramref name="dims" value="dimension specification"/>
        ///// <value>alter values pointed to by elements of dims/ return 
        ///// subarray of elements of this array referenced by dim.</value>
        //public virtual ILBaseArray<BaseT> this[ILArray<double> dims] {
        //    get {
        //        try {
        //            if (dims.IsEmpty)
        //                return new ILArray<BaseT>.empty(); 
        //            return Subarray(dims, 0);
        //        } catch (Exception e) {
        //            throw new ArgumentException("ILArray|Indexer[]: "
        //                + "Invalid range specification", e);
        //        }
        //    }
        //    set {
        //        try {
        //            SetRange(dims, value);
        //        } catch (Exception e) {
        //            throw new Exception("Error while setting values.", e);
        //        }
        //    }
        //}
        /////// <summary>
        /////// Create subarray by index array and shift dimension 
        /////// </summary>
        /////// <paramref name="dims" value="dimension specification"/>
        /////// <value>returns new ILArray as reference subarray to this ILBaseArray</value>
        ////public virtual ILBaseArray<BaseT> this[ILArray<double> dims, int shiftDims] {
        ////    get {
        ////        try {
        ////            if (dims.Length == 0)
        ////                throw new ArgumentException("ILArray|Indexer[]: "
        ////                                        + "Invalid subarray specification:"
        ////                                        + " Length must be > 0.");
        ////            return Subarray(dims, shiftDims);
        ////        } catch (Exception e) {
        ////            throw new ArgumentException("ILArray|Indexer[]: "
        ////                + "Invalid range specification", e);
        ////        }
        ////    }
        ////}
        /////// <summary>
        /////// create shifted version
        /////// </summary>
        /////// <param name="shift">dimensions specifier. </param>
        /////// <returns>sifted version of this array. The inner type
        /////// depends on the type and storage version of this array. </returns>
        ////public virtual ILBaseArray<BaseT> this[int shift] { 
        ////    get {
        ////        try {
        ////            return ShiftDimensions(shift);
        ////        } catch (Exception e) {
        ////            throw new ArgumentException("ILArray|Indexer[]: "
        ////                + "Invalid range specification", e);
        ////        }
        ////    }
        ////}
        ///// <summary>
        ///// Single element access
        ///// </summary>
        ///// <param name="dims">dimensions specifier. int array or comma seperated list.
        ///// If this is a single int element only, this will be expected to be a dimensions
        ///// shift an result in a shifted version to be created. If dims consist out of 
        ///// at least 2 elements, the corresponding value will be returned. </param>
        ///// <returns>element pointed to be by 'dims'</returns>
        //public virtual BaseT this[params int[] dims] {
        //    get {
        //        try {
        //            if (dims.Length == 0)
        //                throw new ArgumentException("ILArray|Indexer[]: "
        //                                        + "Invalid index specification:"
        //                                        + " Length must be > 0.");
        //            // interprete as index specification
        //            return GetValue(dims);
        //        } catch (Exception e) {
        //            throw new ArgumentException("ILArray|Indexer[]: "
        //                + "Invalid range specification", e);
        //        }
        //    }
        //    set {
        //        try {
        //            if (dims.Length == 0)
        //                throw new ArgumentException("ILArray|Indexer[]: "
        //                                        + "Invalid index specification:"
        //                                        + " Length must be > 0.");
        //            SetValue(value, dims);
        //        } catch (Exception e) {
        //            throw new Exception("ILArray|Indexer[]: "
        //                + "Invalid range specification", e);
        //        }
        //    }
        //}

#endif
        #endregion

        #region subarray + range get / set
		/// <summary>
		/// Create shifted version of this array
		/// </summary>
		/// <param name="shift">number of dimensions to shift this storage.</param>
		/// <returns>storage as shifted version of this storage.</returns>
		public abstract ILBaseArray<BaseT> ShiftDimensions(int shift); 
        /// <summary>
        ///	Subarray to this array + dimension shift
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public abstract ILBaseArray<BaseT> Subarray(int shift, params ILBaseArray[] range );
        /// <summary>
        ///	Subarray to this storage
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public abstract ILBaseArray<BaseT> Subarray(params ILBaseArray[] range);
        /// <summary>
        ///	Subarray to this array + dimension shift
        /// </summary>
        /// <param name="range"> strings specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public abstract ILBaseArray<BaseT> Subarray(int shift, params string [] range);
        /// <summary>
        ///	Subarray to this array
        /// </summary>
        /// <param name="range"> strings specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public abstract ILBaseArray<BaseT> Subarray(params string [] range);

        /// <summary>
        ///	Alter values specified by range
        /// </summary>
        /// <param name="range">
        /// ILRange specifying the dimensions/indices to alter
        /// </param>
        /// <param name="values">
        /// ILArray holding the new values.
        /// </param>
        /// <remarks>
        /// The values pointed to by range will be replaced with the values 
        /// coming from vals. If the underlying 
        /// ILArray pointed to by vals is of another size then specified 
        /// by range, only a part of the vals-storaged will be used or respectivly 
        /// those values will repeatedly get inserted. One may use this as a 
        /// feature for filling the range with a sequence of values repeatedly. 
        /// On the other hand this may cause the problem of not recognizing 
        /// differences in the size between vals and range!
        /// Another remarkable situation arises, if this storage is the only 
        /// reference wich is left to an physical storage array and it holds 
        /// multiple (repeated) entries to single array elements. Due to the 
        /// nature of a "reference", altering any values will also update corresponding
        /// entries in the reference storage, pointing to the same underlying elements. 
        /// (In fact, those corresponding values will only point to the updated 
        /// elements also.) Keep in mind, that setting a range for a reference which 
        /// is connected to an array which is referenced by more than one storage, will 
        /// usually lead to a Detach() process - therefore the storage gets disconnected 
        /// and the behavior described will not happen. Since for the user the result 
        /// is not transparent, consider to eather 
        /// <list type="bullet">
        /// <item>
        /// check the state of the storage before calling SetRange() </item>
        /// <item>Detach() the storage manually, if required, or</item>
        /// <item>set the static flag DetachReferences to true to detach all reference storages 
        /// automatically before altering any values on it.</item></list> Hoever there might be 
        /// situations, where one may want to alter many values by altering only 
        /// one. Therefore the above mentioned flag might be set to true if needed. 
        /// </remarks>
        public abstract void SetRange(ILRange range, ILBaseArray<BaseT> values);
        #endregion
        
        /// <summary>
        ///  Serialize this ILArray into binary stream.
        /// </summary>
        /// <param name="outStream">Sysem.IO.Stream to receive the byte sttream 
        /// for this ILBaseArray</param>
        /// <returns>true on success, false on error</returns>
        public virtual bool Serialize(Stream outStream) {
            try {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(outStream, this);
                return true;
            } catch (Exception) {
                return false;
            }
        }
        /// <summary>
        /// Deserialize / restore ILArray from binary stream 'inStream'
        /// </summary>
        /// <param name="inStream">System.IO.Stream to reconstruct the 
        /// ILArray from</param>
        /// <returns><![CDATA[ILArray<BaseT>]]> reconstructed from Stream. If 
        /// the ILArray could not get restored, an SerializationException 
        /// will be thrown. </returns>
        public static ILBaseArray<BaseT> Deserialize(Stream inStream) {
            try {
                BinaryFormatter bf = new BinaryFormatter();
                ILBaseArray<BaseT> ret = (ILBaseArray<BaseT>)bf.Deserialize(inStream);
                return ret;
            } catch (Exception e) {
                throw e;
            }
        }
        /// <summary>
        /// Create iterator for the elements of the current instance of ILBaseArray
        /// </summary>
        /// <returns>Iterator of the same type as the current instance of ILBaseArray, initialized 
        /// to the first element, ready for counting forwards on 
        /// the first dimension.</returns>
        public abstract ILIterator<BaseT> CreateIterator();
        /// <summary>
        /// Create iterator for the elements of the current instance of ILBaseArray, specify start 
        /// element and dimension to walk along
        /// </summary>
        /// <param name="pos">start position. One out of the ILIteratorPositions: 
        /// ILStart, ILMiddle, ILEnd</param>
        /// <param name="leadingDimension">The dimension index to walk along</param>
        /// <returns>Iterator of the same type as the current instance of ILBaseArray
        /// </returns>
        public abstract ILIterator<BaseT> CreateIterator(ILIteratorPositions pos, int leadingDimension);

        /// <summary>
        /// Determine if this array holds numeric values
        /// </summary>
        /// <remarks>An ILArray is stated to be 'numeric' as long as its inner type is one of the 
        /// following: 
        /// <list type="table">
        /// <listheader>
        ///     <term>inner type</term>
        /// </listheader>
        /// <item>
        ///     <term>System.double</term>
        ///     <description>floating point, real, 8 bytes </description>
        /// </item>
        /// <item>
        ///     <term>System.float</term>
        ///     <description>floating point real, 4 bytes</description>
        /// </item>
        /// <item>
        ///     <term>ILNumerics.complex</term>
        ///     <description>floating point complex, 16 bytes</description>
        /// </item>
        /// <item>
        ///     <term>ILNumerics.fcomplex</term>
        ///     <description>floating point complex, 8 bytes</description>
        /// </item>
        /// <item>
        ///     <term>System.char</term>
        ///     <description>integer, real, 1 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.byte</term>
        ///     <description>integer, real, 1 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.Int16</term>
        ///     <description>integer, real, 2 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.Int32</term>
        ///     <description>integer, real, 4 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.Int64</term>
        ///     <description>integer, real, 8 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.UInt16</term>
        ///     <description>unsigned integer, real, 2 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.UInt32</term>
        ///     <description>unsigned integer, real, 4 byte</description>
        /// </item>
        /// <item>
        ///     <term>System.UInt64</term>
        ///     <description>unsigned integer, real, 8 byte</description>
        /// </item>
        /// </list>
        /// </remarks>
        public override bool IsNumeric {
            get {
                System.Array a = m_data;
                if (a is double[] ||
                    a is float[] ||
                    a is complex[] ||
                    a is byte[] ||
                    a is char[] ||
                    a is Int16[] ||
                    a is Int32[] ||
                    a is Int64[] ||
                    a is UInt16[] ||
                    a is UInt32[] ||
                    a is UInt64[])
                    return true;
                return false;
            }
        }
        /// <summary>
        /// Determine if this array has complex elements
        /// </summary>
        public override bool IsComplex {
            get {
                return (this is ILBaseArray<complex>);
            }
        }

        #region internal storage (helper) functions
        /// <summary>
        /// Get single value from this storage
        /// </summary>
        /// <param name="idx">Integer array holding the dimension specifier 
        /// pointing to the value. This can be a comma seperated list 
        /// or a System.Array.</param>
        /// <returns>Object on the position pointed to by idx</returns>
        public abstract BaseT GetValue(params int[] idx);
        /// <summary>
        /// Set single value to element at index specified.
        /// </summary>
        /// <param name="value">new value</param>
        /// <param name="idx">index of element to be altered</param>
        public abstract void SetValue(BaseT value, params int[] idx);


        


        #endregion

        #region IEnumerable<ILBaseArray<BaseT>> Member

        /// <summary>
        /// create enumerator returning skalar <![CDATA[ILArray<BaseT>]]>
        /// </summary>
        /// <returns>enumerator</returns>
        /// <remarks>This makes objects of type <![CDATA[ILBaseArray<BaseT>]]> usable in a foreach loop.</remarks>
       public virtual IEnumerator<ILArray<BaseT>> GetEnumerator ( ) {
            int len = m_dimensions.NumberOfElements; 
            for (int i = 0; i < len; i++) 
                yield return new ILArray<BaseT>(new BaseT[]{GetValue(i)});
        }
        /// <summary>
        /// create enumerator 
        /// </summary>
        /// <returns>generic enumerator of inner base type as IEnumerator interface</returns>
        /// <remarks>This makes objects of type <![CDATA[ILBaseArray<BaseT>]]> usable in a foreach loop.</remarks>
        IEnumerator  IEnumerable.GetEnumerator() {
            return GetEnumerator(); 
        }
        /// <summary>
        /// create enumerator returning elements of inner base type
        /// </summary>
        /// <value>enumerator walking along the first dimension</value>
        /// <remarks>This makes the return value usable in a foreach loop.</remarks>
        public virtual IEnumerable<BaseT> Values {
            get{
                int len = m_dimensions.NumberOfElements; 
                for (int i = 0; i < len; i++) 
                    yield return GetValue(i); 
            }
        }
        /// <summary>
        /// create enumerator capable of walking along arbitrary dimensions 
        /// </summary>
        /// <param name="leaddim">leading dimension</param>
        /// <returns>enumerator of inner base type</returns>
        /// <remarks>This makes the return value usable in a foreach loop.</remarks>
        public virtual IEnumerable<BaseT> Iterator(int leaddim) {
            ILIterator<BaseT> it = CreateIterator(ILIteratorPositions.ILStart,leaddim); 
            yield return it.Value;
            while (!it.IsAtEnd()){
                yield return it.Increment();
            }
        }
        #endregion
    }
    /// <summary>
    /// Enumerate all numeric type names used by ILNumerics.Net
    /// </summary>
    public enum NumericType {
        /// <summary>
        /// double element type
        /// </summary>
        Double,
        /// <summary>
        /// float element type
        /// </summary>
        Single,
        /// <summary>
        /// complex element type
        /// </summary>
        Complex ,
        /// <summary>
        /// fcomplex element type
        /// </summary>
        FComplex,
        /// <summary>
        /// byte element type
        /// </summary>
        Byte,
        /// <summary>
        /// char element type
        /// </summary>
        Char,
        /// <summary>
        /// Int16 element type
        /// </summary>
        Int16,
        /// <summary>
        /// Int32 element type
        /// </summary>
        Int32,
        /// <summary>
        /// Int64 element type
        /// </summary>
        Int64,
        /// <summary>
        /// unsigned UInt16 element type
        /// </summary>
        UInt16,
        /// <summary>
        /// unsigned UInt32 element type
        /// </summary>
        UInt32,
        /// <summary>
        /// unsigned UInt64 element type
        /// </summary>
        UInt64
    }
}