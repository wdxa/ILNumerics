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
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Runtime.Serialization; 
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;

namespace ILNumerics {

    public partial class ILArray<BaseT> : ILBaseArray<BaseT> {

        
        #region Constructors
        /// <summary>
        ///	Create ILArray of specified size and type
        /// </summary>
        /// <param name="size">
        /// Variable length integer array specifying the number and size of dimensions 
        /// to be created.
        /// </param>
        /// <param name="data">preallocated array with data. The array will
        /// directly be used for storage. No copy will be done.</param>
        /// <remarks>The size parameter may not be null or empty! 
        /// An exception will be thrown in this case. The dimensions will be trimmed 
        /// before processing (removing non singleton dimensions from the end). 
        /// Depending on the requested size an ILArray of the specified type and 
        /// dimension will be created. 
        /// </remarks>
        public ILArray(BaseT[] data, params int[] size) {
            if (size == null || size.Length == 0) {
                m_dimensions = new ILDimension(1,data.Length); 
            } else {
                m_dimensions = new ILDimension(true,size);
            }
            if (data.Length != m_dimensions.NumberOfElements)
                throw new ILArgumentException("size of data must match dimensions!");
            m_data = data;
            IncreaseReference();
        }

        /// <summary>
        /// Create ILArray of specified size and type
        /// </summary>
        /// <param name="data">preallocated array with data. The array will
        /// directly be used for storage. No copy will be done.</param>
        /// <param name="dimensions">
        /// dimension specification. The ILDimension given must not be null and will 
        /// directly be used for the new object! No copy will be made for it!
        /// </param>
        /// <remarks>The size parameter may not be null or empty! 
        /// An exception will be thrown in this case. The dimensions will be trimmed 
        /// before processing (removing non singleton dimensions from the end). 
        /// Depending on the requested size an ILArray of the specified type and 
        /// dimension will be created. 
        /// </remarks>
        public ILArray(BaseT[] data, ILDimension dimensions) {
            System.Diagnostics.Debug.Assert(dimensions != null,"ILArray|(construct): "
                                            + "dimension must be specified!");
            m_dimensions = dimensions.Trim();
            if (data.Length != m_dimensions.NumberOfElements)
                throw new ILArgumentException("ILArray.construct: Data array specifier must match "
                                        + "size of dimensions!");
            m_data = data;
            IncreaseReference();
        }
        /// <summary>
        ///		Create ILArray of type object and given name and size 
        /// </summary>
        /// <param name="size">
        /// Variable length int array specifying the number and size of dimensions 
        /// to be created.
        /// </param>
        /// <remarks>The size parameter may not be null or an empty array! 
        /// An Exception will be thrown in this case. The dimensions will be trimmed 
        /// before processing (removing non singleton dimensions from the end). 
        /// Depending on the requested size an ILArray of the specified 
        /// dimension will be created. 
        /// </remarks>
        public ILArray(params int[] size) {
            if (size == null || size.Length == 0)
                throw new ArgumentException("ILArray|(construct): dimension specification needed!");
            try {
                m_dimensions = new ILDimension(true,size);
                bool dummy; 
                m_data = ILMemoryPool.Pool.New<BaseT>(m_dimensions.NumberOfElements, true, out dummy);
                m_name = "";
                IncreaseReference();
            } catch (Exception e) {
                throw new Exception("Error creating new ILArray object.", e);
            }
        }

        /// <summary>
        ///	'Copy' Constructor. Creates a new ILArray as exact copy of input array
        /// </summary>
        /// <param name="inp">
        /// ILArray object to create a copy from
        /// </param>
        /// <remarks>
        /// <para>
        /// The ILArray given will be copied and the reference counter will get increased. The resulting 
        /// new ILArray will be an exact - but shallow - copy of inp. 
        /// Use this constructor only for casting purposes! For copy/clone operations 
        /// use the Subarray/CreateReference/Copy/Clone functions or the index access instead!</para>
        /// </remarks>
        internal ILArray(ILArray<BaseT> inp) {
            m_data = (BaseT[])inp.m_data;
            IncreaseReference(); 
            m_dimensions = inp.m_dimensions;
            m_name = inp.Name;
            m_indexOffset = inp.m_indexOffset;
        }
        /// <summary>
        /// implicit copy constructor
        /// </summary>
        /// <param name="inp">ILArray to be copied</param>
        /// <remarks>This is used in C++ derivate as assignment operator</remarks>
        public void MarshalCopy(ILArray<BaseT> inp) {
            DecreaseReference(); 
            m_data = inp.m_data;
            IncreaseReference(); 
            m_dimensions = inp.Dimensions;
            m_name = inp.Name;
            m_indexOffset = inp.m_indexOffset;
            inp.Dispose();  
        }
        /// <summary>
        /// create scalar or row vector from values explitely given
        /// </summary>
        /// <param name="vector_elements">elements. </param>
        /// <remarks><para>The elements may are given as comma seperated list or as predefined System.Array 
        /// of type 'BaseT'. In this case the System.Array object given will directly be used as storage 
        /// for the newly created ILArray.</para>
        /// <para>If vector_elements is null, an empty ILArray will be created.</para></remarks>
        public ILArray(BaseT[] vector_elements) { 
            if (object.Equals(vector_elements,null)) {
                m_data = new BaseT[0]; 
                m_dimensions = new ILDimension(new int[2] {0,0}); 
            } else {
                m_data  = vector_elements; 
                m_dimensions = new ILDimension(new int[2] {1,m_data.Length}); 
            }
            m_indexOffset = null; 
            IncreaseReference();
        }	
        /// <summary>
        /// Standard constructor creating empty ILArray
        /// </summary>
        public ILArray() {
            m_data = new BaseT[0];
            IncreaseReference(); 
            m_dimensions = new ILDimension(0,0);
            m_name = "";
            m_indexOffset = null;
        }

        /// <summary>
        /// Constructor creating referencing ILArray object from ILIndexOffset object
        /// and source storage.
        /// </summary>
        /// <param name="storage">
        /// ILArray as source for the reference storage. Holds the physical
        /// data or the source for the reference (i.e. existing storage).
        /// </param>
        /// <param name="idxOffset">
        /// ILIndexOffset object holding indices with destination index for each 
        /// dimension or null for referencing full storage.
        /// </param>
        /// <remarks>
        /// Any dimensions shifts must be implicitly be reflected by the 
        /// idxOffset parameter. The dimensions of the resulting reference storage will 
        /// directly be derived from the idxOffset parameter (if it is not null !). 
        /// </remarks>
        private ILArray(ILArray<BaseT> storage, ILIndexOffset idxOffset) {
            m_data = storage.m_data;
            IncreaseReference();
            m_dimensions = idxOffset.GetDimensions();
            m_indexOffset = idxOffset;
        }
        #endregion

        #region Destructor + Dispose
         
        /// <summary>
        /// free storage on finalize
        /// </summary>
        /// <remarks>This will decrease the reference counter for the current m_data member 
        /// and mark all attribute members as null for garbage collection. <br> You should never 
        /// have to call any finalizing code directly unless you know, what you are doing!</br></remarks>
        ~ILArray() {
            Dispose();
        }
        /// <summary>
		/// Dispose this storage before garbage collection.
		/// </summary>
		/// <remarks><para>Calling Dispose should be the last method called for an ILArray. 
        /// The storage referenced by this object will be released in the next GC run. Calling 
        /// Dispose() will increase performance of your application, since disposed objects 
        /// can faster get cleaned up by the GC. However, if this method is not called for an 
        /// object, the garbage collector finalization queue will call it for you.</para></remarks>
		public void Dispose() {
            //Console.Out.WriteLine("Disposing: " + m_name); 
            if (m_data != null) {
			    DecreaseReference();
                System.GC.SuppressFinalize(this);
                // todo: move the storage to memory pool
			    m_data = null;
			    m_dimensions = null;
			    m_indexOffset = null;
            }
        }
        #endregion

        #region Subarray interface
        /// <summary>
        ///	Subarray from this array
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public override ILBaseArray<BaseT> Subarray (params ILBaseArray[] range) {
            if (range.Length == 0) {
                return ILArray<BaseT>.empty(0,0);
            } else if (range.Length == 1) {
                #region sequential index access
                if (IsReference) {
                    #region reference array
                    if (range[0] is ILArray<double>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<double>)range[0]); 
                    } else if (range[0] is ILArray<float>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<float>)range[0]); 
                    } else if (range[0] is ILLogicalArray) {
                        return CreatePhysicalSubarrayFromReferenceSequential(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0])); 
                    } else if (range[0] is ILArray<complex>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<complex>)range[0]); 
                    } else if (range[0] is ILArray<fcomplex>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<fcomplex>)range[0]); 
                    } else if (range[0] is ILArray<byte>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<byte>)range[0]); 
                    } else if (range[0] is ILArray<char>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<char>)range[0]); 
                    } else if (range[0] is ILArray<Int16>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<Int16>)range[0]); 
                    } else if (range[0] is ILArray<Int32>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<Int32>)range[0]); 
                    } else if (range[0] is ILArray<Int64>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<Int64>)range[0]); 
                    } else if (range[0] is ILArray<UInt16>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<UInt16>)range[0]); 
                    } else if (range[0] is ILArray<UInt32>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<UInt32>)range[0]); 
                    } else if (range[0] is ILArray<UInt64>) {
                        return CreatePhysicalSubarrayFromReferenceSequential((ILArray<UInt64>)range[0]); 
                    } else throw new ILArgumentException ("specified type of ILBaseArray for indices is not supported for addressing!");
                    #endregion
                } else {
                    #region physical array
                    if (range[0] is ILArray<double>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<double>)range[0]); 
                    } else if (range[0] is ILLogicalArray) {
                        return CreatePhysicalSubarrayFromPhysicalSequential(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0])); 
                    } else if (range[0] is ILArray<float>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<float>)range[0]); 
                    } else if (range[0] is ILArray<complex>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<complex>)range[0]); 
                    } else if (range[0] is ILArray<fcomplex>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<fcomplex>)range[0]); 
                    } else if (range[0] is ILArray<byte>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<byte>)range[0]); 
                    } else if (range[0] is ILArray<char>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<char>)range[0]); 
                    } else if (range[0] is ILArray<Int16>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<Int16>)range[0]); 
                    } else if (range[0] is ILArray<Int32>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<Int32>)range[0]); 
                    } else if (range[0] is ILArray<Int64>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<Int64>)range[0]); 
                    } else if (range[0] is ILArray<UInt16>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<UInt16>)range[0]); 
                    } else if (range[0] is ILArray<UInt32>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<UInt32>)range[0]); 
                    } else if (range[0] is ILArray<UInt64>) {
                        return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<UInt64>)range[0]); 
                    } else throw new ILArgumentException ("specified type of indices array is not supported for sequential addressing!");
                    #endregion
                }
                #endregion sequential index access
            } else {
                ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
                if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0); 
                if (rng.nonSingletonDimensions >= MinimumRefDimensions) {
                    if (m_indexOffset == null) 
                        return CreateReferenceSubarrayFromPhysical(rng); 
                    else 
                        return CreateReferenceSubarrayFromReference(rng); 
                } else {
                    if (m_indexOffset == null) {
                        return CreatePhysicalSubarrayFromPhysical(rng); 
                    } else {
                        return CreatePhysicalSubarrayFromReference(rng);  
                    }
                }
            }
        }
        /// <summary>
        ///	Subarray from this ILArray + dimension shift
        /// </summary>
        /// <param name="range"> arrays specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public override ILBaseArray<BaseT> Subarray (int shift, ILBaseArray[] range) {
            if (shift == 0)
                return Subarray(range);
            if (range.Length == 0) {
                return ILArray<BaseT>.empty(0,0);
            } else if (range.Length == 1) {
                #region sequential indices access
                if (IsReference) {
                    #region reference array
                    if (range[0] is ILArray<double>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<double>)range[0],shift); 
                    } else if (range[0] is ILLogicalArray) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0]),shift); 
                    } else if (range[0] is ILArray<float>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<float>)range[0],shift); 
                    } else if (range[0] is ILArray<complex>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<complex>)range[0],shift); 
                    } else if (range[0] is ILArray<fcomplex>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<fcomplex>)range[0],shift); 
                    } else if (range[0] is ILArray<byte>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<byte>)range[0],shift); 
                    } else if (range[0] is ILArray<char>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<char>)range[0],shift); 
                    } else if (range[0] is ILArray<Int16>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<Int16>)range[0],shift); 
                    } else if (range[0] is ILArray<Int32>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<Int32>)range[0],shift); 
                    } else if (range[0] is ILArray<Int64>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<Int64>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt16>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<UInt16>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt32>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<UInt32>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt64>) {
                        return CreatePhysicalSubarrayFromReferenceSequentialShifted((ILArray<UInt64>)range[0],shift); 
                    } else throw new ILArgumentException ("specified type of ILBaseArray for indices is not supported for sequential addressing!"); 
                    #endregion reference array
                } else {
                    #region physical array 
                    if (range[0] is ILArray<double>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<double>)range[0],shift); 
                    } else if (range[0] is ILLogicalArray) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0]),shift); 
                    } else if (range[0] is ILArray<float>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<float>)range[0],shift); 
                    } else if (range[0] is ILArray<complex>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<complex>)range[0],shift); 
                    } else if (range[0] is ILArray<fcomplex>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<fcomplex>)range[0],shift); 
                    } else if (range[0] is ILArray<byte>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<byte>)range[0],shift); 
                    } else if (range[0] is ILArray<char>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<char>)range[0],shift); 
                    } else if (range[0] is ILArray<Int16>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<Int16>)range[0],shift); 
                    } else if (range[0] is ILArray<Int32>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<Int32>)range[0],shift); 
                    } else if (range[0] is ILArray<Int64>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<Int64>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt16>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<UInt16>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt32>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<UInt32>)range[0],shift); 
                    } else if (range[0] is ILArray<UInt64>) {
                        return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<UInt64>)range[0],shift); 
                    } else throw new ILArgumentException ("specified type of indices array is not supported for sequential addressing!");
                    #endregion physical array
                }
                #endregion sequential index access
            } else {
                ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
                if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0); 
                if (rng.nonSingletonDimensions >= MinimumRefDimensions) {
                    if (m_indexOffset == null) 
                        return CreateReferenceSubarrayFromPhysicalShifted((short)shift,rng); 
                    else 
                        return CreateReferenceSubarrayFromReferenceShifted((short) shift,rng); 
                } else {
                    if (m_indexOffset == null) {
                        return CreatePhysicalSubarrayFromPhysicalShifted((short)shift, rng); 
                    } else {
                        return CreatePhysicalSubarrayFromReferenceShifted((short)shift, rng);  
                    }
                }
            }

        }
        /// <summary>
        ///	Subarray to this array + dimension shift
        /// </summary>
        /// <param name="range"> string specifying the ranges to create subarray from</param>
        /// <param name="shift"> Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public override ILBaseArray<BaseT> Subarray (int shift, params string [] range) {
            if (shift < 1) 
                return Subarray(range); 
            if (range == null) 
                return ShiftDimensions(shift); 
            ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
            if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0);
            if (rng.nonSingletonDimensions >= MinimumRefDimensions) {
                // create reference 
                if (IsReference) 
                    return CreateReferenceSubarrayFromReferenceShifted((short)shift,rng); 
                else 
                    return CreateReferenceSubarrayFromPhysicalShifted((short)shift,rng); 
            } else { 
                // create physical
                if (IsReference) 
                    return CreatePhysicalSubarrayFromReferenceShifted((short)shift,rng); 
                else 
                    return CreatePhysicalSubarrayFromPhysicalShifted((short)shift,rng); 
            }
        }
        /// <summary>
        ///	Subarray from this array
        /// </summary>
        /// <param name="range"> strings specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public override ILBaseArray<BaseT> Subarray (params string [] range) {
            if (range == null) 
                return ShiftDimensions(0); 
            ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
            if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0);
            if (rng.nonSingletonDimensions >= MinimumRefDimensions) {
                // create reference 
                if (IsReference) 
                    return CreateReferenceSubarrayFromReference(rng); 
                else 
                    return CreateReferenceSubarrayFromPhysical(rng); 
            } else { 
                // create physical
                if (IsReference) 
                    return CreatePhysicalSubarrayFromReference(rng); 
                else 
                    return CreatePhysicalSubarrayFromPhysical(rng); 
            }
        }
        #endregion

        #region subarray creation: Physical

        #region HYCALPER LOOPSTART Sequential access
        /*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential(/*!HC:inCls1*/ ILArray<double> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                /*!HC:inArr1*/ double [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted(/*!HC:inCls1*/ ILArray<double> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                /*!HC:inArr1*/ double [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential(/*!HC:inCls1*/ ILArray<double> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                /*!HC:inArr1*/ double [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted(/*!HC:inCls1*/ ILArray<double> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                /*!HC:inArr1*/ double [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
        #endregion HYCALPER LOOPEND Sequential access
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<fcomplex> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                fcomplex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<fcomplex> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                fcomplex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<fcomplex> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                fcomplex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<fcomplex> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                fcomplex [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<complex> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                complex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<complex> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                complex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<complex> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                complex [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<complex> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                complex [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<byte> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                byte [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<byte> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                byte [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<byte> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                byte [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<byte> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                byte [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<char> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                char [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<char> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                char [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<char> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                char [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<char> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                char [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<UInt64> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                UInt64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<UInt64> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                UInt64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<UInt64> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                UInt64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<UInt64> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                UInt64 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<UInt32> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                UInt32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<UInt32> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                UInt32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<UInt32> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                UInt32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<UInt32> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                UInt32 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<UInt16> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                UInt16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<UInt16> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                UInt16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<UInt16> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                UInt16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<UInt16> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                UInt16 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<Int64> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                Int64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<Int64> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                Int64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<Int64> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                Int64 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<Int64> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                Int64 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<Int32> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                Int32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<Int32> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                Int32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<Int32> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                Int32 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<Int32> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                Int32 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<Int16> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                Int16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<Int16> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                Int16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<Int16> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                Int16 [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<Int16> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                Int16 [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        
       
        /// <summary>
        /// create physical copy from this physical array 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<float> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indices.GetValue(i)]; 
                }
            } else {
                float [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[(int)indData[i]]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical copy from this physical array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequentialShifted( ILArray<float> indices,int shift){
            if (shift < 0) 
                shift = 0; 
            if (shift > indices.m_dimensions.NumberOfDimensions)
                shift %= indices.m_dimensions.NumberOfDimensions; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift); 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indices.GetValue(i)];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indices.GetValue(outLen)];
            } else {
                float [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[outPos] = m_data[(int)indData[i]]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
                outdata[outLen] = m_data[(int)indData[outLen]];
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <returns>physical copy of elements addressed by indices.shape of indices</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequential( ILArray<float> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen);
            if (indices.IsReference) {
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indices.GetValue(i))]; 
                }
            } else {
                float [] indData = indices.m_data; 
                for (int i = 0; i < outLen; i++) {
                    outdata[i] = m_data[getBaseIndex((int)indData[i])]; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        /// <summary>
        /// create physical subarray from this referencing array and shift dimensions 
        /// </summary>
        /// <param name="indices">sequential indices. may be of any size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>physical copy of elements addressed by indices.shape of shifted indices array</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceSequentialShifted( ILArray<float> indices,int shift){
            if (shift > indices.Dimensions.NumberOfDimensions) 
                shift %= indices.Dimensions.NumberOfDimensions; 
            if (shift < 0) 
                shift = 0; 
            ILDimension dim = indices.m_dimensions.GetShifted(shift).Trim();
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen--);
            int outPos = 0, outInc = dim.SequentialIndexDistance(dim.NumberOfDimensions - shift); 
            // improves performance by optimizing increments 
            if (outInc == dim.NumberOfElements)
                outInc = 1; 
            if (indices.IsReference) {
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indices.GetValue(i))];
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            } else {
                float [] indData = indices.m_data; 
                for (int i = 0; i <= outLen; i++) {
                    outdata[outPos] = m_data[getBaseIndex((int)indData[i])]; 
                    outPos += outInc; 
                    if (outPos > outLen) outPos %= outLen; 
                }
            }
            return new ILArray<BaseT>(outdata, dim);
        }
        

#endregion HYCALPER AUTO GENERATED CODE

        /// <summary>
        /// create physical range from reference array 
        /// </summary>
        /// <param name="range">valid range</param>
        /// <returns>referencing subarray</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReference(ILRange range) {
			if (range == null) 
                throw new ILArgumentException ("range specified must not be null!"); 
            int rangeDimLen = range.NumberOfDimensions,higherDimSum = 0;
            int myDimLen = m_dimensions.NumberOfDimensions;
            int leadDimLenRange = range[0].Length, leadDimLen = m_dimensions[0]; 
            int curPosOut = 0, d, outElemCount = range.NumberOfElements, secIdx; 
            BaseT[] retArr = ILMemoryPool.Pool.New< BaseT> (outElemCount); 
            int[] idxArr = new int[rangeDimLen];    // used to store current position inside higher dims 
            bool[] isFullDim = new bool[rangeDimLen]; 
            int[][] r = range.RangeArray; 
            int[] rleadDim = range[0]; 
            int[] ileadDim = m_indexOffset[0]; 
            if (rangeDimLen == 1) {
                #region early exit: return vector
                if (rleadDim[0] >= 0) {
                    int i = 0; 
                    for (i = 0; i < rleadDim.Length;) {
                        int secDimIdx = rleadDim[i];
                        higherDimSum = 0; 
                        for (d = 0;d < m_dimensions.NumberOfDimensions; d++) {
                            higherDimSum += m_indexOffset[d,secDimIdx % m_dimensions[d]];
                            secDimIdx /= m_dimensions[d]; 
                        }
                        retArr[i++] = m_data[higherDimSum];
                    }
                } else {
                    int i = 0, tmpLen = - rleadDim[0] + 1; 
                    for (i = 0; i < tmpLen;) {
                        int secDimIdx = i;
                        higherDimSum = 0; 
                        for (d = 0;d < m_dimensions.NumberOfDimensions; d++) {
                            higherDimSum += m_indexOffset[d,secDimIdx % m_dimensions[d]];
                            secDimIdx /= m_dimensions[d]; 
                        }
                        retArr[i++] = m_data[higherDimSum];
                    }
                }
                #endregion
            } else {
                if (rleadDim[0] < 0) {
                    #region LeadDim is full (specified as ':')
                    // leading dimension is a "full" dimension: only its largest index is (negative) given in range[d]
                    int i = 1; 
                    while (i < rangeDimLen-1) {
                        if (r[i][0] < 0) {
                            // full dimension
                            //higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                            isFullDim[i] = true; 
                            higherDimSum +=  m_indexOffset[i++,0]; 
                        } else {
                            higherDimSum += m_indexOffset[i,r[i++][0]]; 
                        }
                    }
                    // last dimension's indices may exeed dimension -> reshaping case 
                    if (r[i][0] < 0) {
                        // full dimension
                        isFullDim[i] = true; 
                        higherDimSum +=  m_indexOffset[i,0]; 
                    } else {
                        secIdx = r[i][0];   
                        for (; i < m_dimensions.NumberOfDimensions;) {
                            higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                            secIdx /= m_indexOffset[i++].Length; 
                        }
                    }
                    leadDimLenRange = - rleadDim[0] + 1; 
                    for (i = 0; i < leadDimLenRange;) { 
                        retArr[curPosOut++] = m_data[higherDimSum + ileadDim[i++]]; 
                    }
                    while (curPosOut < outElemCount) {
                        // increase higher dims 
                        d = 1; 
                        while  (d < rangeDimLen) {
                            if (!isFullDim[d]) {
                                if (idxArr[d] >= r[d].Length - 1) {
                                    idxArr[d] = 0;
                                    d++; 
                                } else {
                                    break; 
                                }
                            } else {
                                if (idxArr[d] >= - r[d][0]) { 
                                    idxArr[d] = 0;
                                    d++; 
                                } else {
                                    break; 
                                }
                            }
                        }
                        System.Diagnostics.Debug.Assert(d != idxArr.Length); 
                        idxArr[d] += 1;
                        higherDimSum = 0; 
                        for (i = 1; i < rangeDimLen -1;) {
                            if (isFullDim[i]) {
                                higherDimSum += m_indexOffset[i,idxArr[i++]];
                            } else {
                                higherDimSum += m_indexOffset[i,r[i][idxArr[i++]]]; 
                            }
                        }
                        if (isFullDim[i] == true)
                            secIdx = idxArr[i];   
                        else 
                            secIdx = r[i][idxArr[i]];   
                        for (; i < m_dimensions.NumberOfDimensions;) {
                            higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                            secIdx /= m_indexOffset[i++].Length; 
                        }
                        // do the copy! 
                        for (i = 0; i < leadDimLenRange;) { 
                            retArr[curPosOut++] = m_data[higherDimSum + ileadDim[i++]]; 
                        }
                    }
                    #endregion
                } else {
                    #region LeadDim is explicitly declared 
                    int i = 1; 
                    while (i < rangeDimLen-1) {
                        if (r[i][0] < 0) {
                            // full dimension
                            //higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                            isFullDim[i] = true; 
                            higherDimSum +=  m_indexOffset[i++,0]; 
                        } else {
                            higherDimSum += m_indexOffset[i,r[i++][0]]; 
                        }
                    }
                    // last dimension's indices may exeed dimension -> reshaping case 
                    if (r[i][0] < 0) {
                        // full dimension
                        isFullDim[i] = true; 
                        higherDimSum +=  m_indexOffset[i,0]; 
                    } else {
                        secIdx = r[i][0];   
                        for (; i < m_indexOffset.Length;) {
                            higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                            secIdx /= m_indexOffset[i++].Length; 
                        }
                    }
                    for (i = 0; i < leadDimLenRange;) { 
                        retArr[curPosOut++] = m_data[higherDimSum + ileadDim[rleadDim[i++]]]; 
                    }
                    while (curPosOut < outElemCount) {
                        // increase higher dims 
                        d = 1; 
                        while  (d < idxArr.Length) {
                            if (!isFullDim[d]) {
                                if (idxArr[d] >= r[d].Length - 1) {
                                    idxArr[d] = 0;
                                    d++; 
                                } else {
                                    break; 
                                }
                            } else {
                                if (idxArr[d] >= - r[d][0]) { 
                                    idxArr[d] = 0;
                                    d++; 
                                } else {
                                    break; 
                                }
                            }
                            System.Diagnostics.Debug.Assert(d < idxArr.Length); 
                        }
                        System.Diagnostics.Debug.Assert(d != idxArr.Length);
                        idxArr[d] += 1;
                        higherDimSum = 0; 
                        for (i = 1; i < rangeDimLen - 1;) {
                            if (isFullDim[i]) {
                                higherDimSum += m_indexOffset[i,idxArr[i++]];
                            } else {
                                higherDimSum += m_indexOffset[i,r[i][idxArr[i++]]]; 
                            }
                        }
                        if (isFullDim[i] == true)
                            secIdx = idxArr[i];   
                        else 
                            secIdx = r[i][idxArr[i]];   
                        for (; i < m_dimensions.NumberOfDimensions;) {
                            higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                            secIdx /= m_indexOffset[i++].Length; 
                        }
                        // do the copy! 
                        for (i = 0; i < leadDimLenRange;) { 
                            retArr[curPosOut++] = m_data[higherDimSum + ileadDim[rleadDim[i++]]]; 
                        }
                    }
                    #endregion
                }
            }
            return new ILArray<BaseT> (retArr,range.GetDimensions()); 
        }        
        /// <summary>
        /// create pyhsical array from reference array and shift dimensions 
        /// </summary>
        /// <param name="range">valid range </param>
        /// <param name="shift">number of dimensions to shift result</param>
        /// <returns>physical copy of elements adressed</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromReferenceShifted(int shift, ILRange range) {
            System.Diagnostics.Debug.Assert(range != null,"Range must not be null!");             
            int[][] r = range.RangeArray; 
            int rangeDimLen = range.NumberOfDimensions,higherDimSum = 0;
            int curPosOut = 0, d; 
            int intshift = shift % rangeDimLen; 
            shift %= ((rangeDimLen > 1) ? rangeDimLen : 2);
            BaseT[] retArr = ILMemoryPool.Pool.New< BaseT> (range.NumberOfElements); 
            int leadDimNr = intshift, leadDimLenRange = range[intshift].Length, leadDimLen = m_dimensions[intshift];
            int reshapingDimNr = (rangeDimLen < m_dimensions.NumberOfDimensions) ? rangeDimLen - 1: -1; 
            int outElemCount = range.NumberOfElements, secIdx; 
            int[] idxArr = new int[rangeDimLen];    // used to store current position inside higher dims 
            bool[] isFullDim = new bool[rangeDimLen]; 
            int [] ileadDim = m_indexOffset[leadDimNr]; 
            int[] rleadDim = r[leadDimNr];   // faster access                              
            if (rangeDimLen == 1) {
                #region early exit: return vector
                if (rleadDim[0] >= 0) {
                    int i = 0; 
                    for (i = 0; i < rleadDim.Length;) {
                        int secDimIdx = rleadDim[i];
                        higherDimSum = 0; 
                        for (d = 0;d < m_dimensions.NumberOfDimensions; d++) {
                            higherDimSum += m_indexOffset[d,secDimIdx % m_dimensions[d]];
                            secDimIdx /= m_dimensions[d]; 
                        }
                        retArr[i++] = m_data[higherDimSum];
                    }
                } else {
                    int i = 0, tmpLen = - rleadDim[0] + 1; 
                    for (i = 0; i < tmpLen;) {
                        int secDimIdx = i;
                        higherDimSum = 0; 
                        for (d = 0;d < m_dimensions.NumberOfDimensions; d++) {
                            higherDimSum += m_indexOffset[d,secDimIdx % m_dimensions[d]];
                            secDimIdx /= m_dimensions[d]; 
                        }
                        retArr[i++] = m_data[higherDimSum];
                    }
                }
                #endregion
            } else {
                if (rleadDim[0] < 0) {
                    #region LeadDim is full (specified as ':')
                    // leading dimension is a "full" dimension: only its largest 
                    // index is (negative) given in range[d]
                    leadDimLenRange = - rleadDim[0] + 1; 
                    int i = (leadDimNr + 1) % rangeDimLen; 
                    for (; i != leadDimNr; i = (++i)%rangeDimLen) {
                        if (r[i][0] < 0) {
                            // full dimension
                            isFullDim[i] = true; 
                            higherDimSum += m_indexOffset[i,0]; 
                        } else if (i == reshapingDimNr){
                            // last dimension's indices may exeed dimension -> reshaping case 
                            secIdx = r[i][0];   
                            for (; i < m_dimensions.NumberOfDimensions;) {
                                higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                                secIdx /= m_indexOffset[i].Length; 
                            }
                        } else {
                            higherDimSum +=  m_indexOffset[i,r[i][0]]; 
                        }
                    }
                    if (leadDimNr == reshapingDimNr) {
                        for (i = 0; i < leadDimLenRange;) { 
                            secIdx = i++; 
                            int reshapingDimsAdd = higherDimSum; 
                            for (d = leadDimNr; d < m_dimensions.NumberOfDimensions;) {
                                reshapingDimsAdd += m_indexOffset[d,secIdx % m_dimensions[d]];
                                secIdx /= m_indexOffset[d++].Length; 
                            }
                            retArr[curPosOut++] = m_data[reshapingDimsAdd];
                        }
                    } else {
                        for (i = 0; i < leadDimLenRange;) { 
                            retArr[curPosOut++] = m_data[higherDimSum + ileadDim[i++]];
                        }
                    }
                    while (curPosOut < outElemCount) {
                        // increase higher dims 
                        d = (leadDimNr + 1) % rangeDimLen; 
                        while  (d != leadDimNr) {
                            if (!isFullDim[d]) {
                                if (idxArr[d] >= range[d].Length - 1) {
                                    idxArr[d] = 0;
                                    d = (d+1) % rangeDimLen; 
                                } else {
                                    break;  
                                }
                            } else {
                                if (idxArr[d] >= - r[d][0]) { 
                                    idxArr[d] = 0;
                                    d = (d+1) % rangeDimLen;  
                                } else {
                                    break;  
                                }
                            }
                        }
                        System.Diagnostics.Debug.Assert(d != leadDimNr, "error while increasing higher dimensions. Number of element limit not reached!"); 
                        idxArr[d] += 1;
                        higherDimSum = 0; 
                        i = (leadDimNr + 1) % rangeDimLen; 
                        for (; i != leadDimNr; i = (++i)%rangeDimLen) {
                            if (isFullDim[i])
                                secIdx = idxArr[i]; 
                            else 
                                secIdx = r[i][idxArr[i]];
                            if (i == reshapingDimNr) {
                                for (; i < m_dimensions.NumberOfDimensions;) {
                                    higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                                    secIdx /= m_indexOffset[i].Length; 
                                }
                            } else {
                                higherDimSum +=  m_indexOffset[i,secIdx]; 
                            }
                        }
                        if (leadDimNr == reshapingDimNr) {
                            for (i = 0; i < leadDimLenRange;) { 
                                secIdx = i++; 
                                int reshapingDimsAdd = higherDimSum; 
                                for (d = leadDimNr; d < m_dimensions.NumberOfDimensions;) {
                                    reshapingDimsAdd += m_indexOffset[d,secIdx % m_dimensions[d]];
                                    secIdx /= m_indexOffset[d++].Length; 
                                }
                                retArr[curPosOut++] = m_data[reshapingDimsAdd];
                            }
                        } else {
                            for (i = 0; i < leadDimLenRange;) { 
                                retArr[curPosOut++] = m_data[higherDimSum + ileadDim[i++]];
                            }
                        }
                    }
                    #endregion
                } else {
                    #region LeadDim is explicitly declared 
                    // leading dimension is a "full" dimension: only its largest 
                    // index is (negative) given in range[d]
                    leadDimLenRange = rleadDim.Length; 
                    int i = (leadDimNr + 1) % rangeDimLen; 
                    for (; i != leadDimNr; i = (++i)%rangeDimLen) {
                        if (r[i][0] < 0) {
                            // full dimension
                            isFullDim[i] = true; 
                            higherDimSum += m_indexOffset[i,0]; 
                        } else if (i == reshapingDimNr){
                            // last dimension's indices may exeed dimension -> reshaping case 
                            secIdx = r[i][0];   
                            for (; i < m_dimensions.NumberOfDimensions;) {
                                higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                                secIdx /= m_indexOffset[i].Length; 
                            }
                        } else {
                            higherDimSum +=  m_indexOffset[i,r[i][0]]; 
                        }
                    }
                    if (leadDimNr == reshapingDimNr) {
                        for (i = 0; i < leadDimLenRange;) { 
                            secIdx = rleadDim[i++]; 
                            int reshapingDimsAdd = higherDimSum; 
                            for (d = leadDimNr; d < m_dimensions.NumberOfDimensions;) {
                                reshapingDimsAdd += m_indexOffset[d,secIdx % m_dimensions[d]];
                                secIdx /= m_indexOffset[d++].Length; 
                            }
                            retArr[curPosOut++] = m_data[reshapingDimsAdd];
                        }
                    } else {
                        for (i = 0; i < leadDimLenRange;) { 
                            retArr[curPosOut++] = m_data[higherDimSum + ileadDim[rleadDim[i++]]];
                        }
                    }
                    while (curPosOut < outElemCount) {
                        // increase higher dims 
                        d = (leadDimNr + 1) % rangeDimLen; 
                        while  (d != leadDimNr) {
                            if (!isFullDim[d]) {
                                if (idxArr[d] >= range[d].Length - 1) {
                                    idxArr[d] = 0;
                                    d = (d+1) % rangeDimLen; 
                                } else {
                                    break;  
                                }
                            } else {
                                if (idxArr[d] >= - r[d][0]) { 
                                    idxArr[d] = 0;
                                    d = (d+1) % rangeDimLen;  
                                } else {
                                    break;  
                                }
                            }
                        }
                        System.Diagnostics.Debug.Assert(d != leadDimNr, "error while increasing higher dimensions. Number of element limit not reached!"); 
                        idxArr[d] += 1;
                        higherDimSum = 0; 
                        i = (leadDimNr + 1) % rangeDimLen; 
                        for (; i != leadDimNr; i = (++i)%rangeDimLen) {
                            if (isFullDim[i])
                                secIdx = idxArr[i]; 
                            else 
                                secIdx = r[i][idxArr[i]];
                            if (i == reshapingDimNr) {
                                for (; i < m_dimensions.NumberOfDimensions;) {
                                    higherDimSum += m_indexOffset[i,secIdx % m_dimensions[i]];
                                    secIdx /= m_indexOffset[i].Length; 
                                }
                            } else {
                                higherDimSum +=  m_indexOffset[i,secIdx]; 
                            }
                        }
                        if (leadDimNr == reshapingDimNr) {
                            for (i = 0; i < leadDimLenRange;) { 
                                secIdx = rleadDim[i]; 
                                int reshapingDimsAdd = higherDimSum; 
                                for (d = leadDimNr; d < m_dimensions.NumberOfDimensions;) {
                                    reshapingDimsAdd += m_indexOffset[d,secIdx % m_dimensions[d]];
                                    secIdx /= m_indexOffset[d++].Length; 
                                }
                                retArr[curPosOut++] = m_data[reshapingDimsAdd];
                            }
                        } else {
                            for (i = 0; i < leadDimLenRange;) { 
                                retArr[curPosOut++] = m_data[higherDimSum + ileadDim[rleadDim[i++]]];
                            }                                 
                        }
                    }
                    #endregion
                }
            }
            return new ILArray<BaseT> (retArr,range.GetDimensions().GetShifted(shift)); 
        }
        /// <summary>
        /// create physical subarray from physical ILArray 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysical(ILRange range) {
			if (range == null) 
                throw new ILArgumentException ("range specified must not be null!"); 
            int rangeDimLen = range.NumberOfDimensions,higherDimSum = 0;
            int leadDimLenRange = range[0].Length, leadDimLen = m_dimensions[0]; 
            int curPosOut = 0, d, outElemCount = range.NumberOfElements; 
            BaseT[] retArr = ILMemoryPool.Pool.New< BaseT> (outElemCount ); 
            int[] idxArr = new int[rangeDimLen];    // used to store current position inside higher dims 
            bool[] isFullDim = new bool[rangeDimLen]; 
            int[][] r = range.RangeArray; 
            int [] seqDistances = m_dimensions.GetSequentialIndexDistances(range.NumberOfDimensions); 
            int[] rleadDim = range[0]; 
            if (rleadDim[0] < 0) {
                #region LeadDim is full (specified as ':')
                // leading dimension is a "full" dimension: only its largest index is (negative) given in range[d]
                for (int i = 1; i < idxArr.Length; i++) {
                    if (r[i][0] < 0) {
                        // full dimension
                        //higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                        isFullDim[i] = true; 
                    } else {
                        higherDimSum += seqDistances[i] * (r[i][idxArr[i]]); 
                    }
                }
                leadDimLenRange = - rleadDim[0] + 1; 
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx ++) { 
                    retArr[curPosOut++] = m_data[higherDimSum + lIdx]; 
                }
                while (curPosOut < outElemCount) {
                    // increase higher dims 
                    d = 1; 
                    while  (d < rangeDimLen) {
                        if (!isFullDim[d]) {
                            if (idxArr[d] >= r[d].Length - 1) {
                                idxArr[d] = 0;
                                d++; 
                            } else {
                                break; 
                            }
                        } else {
                            if (idxArr[d] >= - r[d][0]) { 
                                idxArr[d] = 0;
                                d++; 
                            } else {
                                break; 
                            }
                        }
                    }
                    System.Diagnostics.Debug.Assert(d != idxArr.Length); 
                    idxArr[d] += 1;
                    higherDimSum = 0; 
                    for (int i = 1; i < idxArr.Length; i++) {
                        if (isFullDim[i]) {
                            higherDimSum += seqDistances[i] * idxArr[i];
                        } else {
                            higherDimSum += seqDistances[i] * (r[i][idxArr[i]]); 
                        }
                    }
                    // do the copy! 
                    for (int lIdx = 0; lIdx < leadDimLenRange; lIdx ++) { 
                        retArr[curPosOut++] = m_data[higherDimSum++]; 
                    }

                }
                #endregion
            } else {
                #region LeadDim is explicitly declared 
                for (int i = 1; i < idxArr.Length; i++) {
                    // ... not sure for higher dimensions...
                    if (r[i][0] < 0) {
                        // full dimension
                        // higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                        isFullDim[i] = true; 
                    } else {
                        higherDimSum += seqDistances[i] * (r[i][0]); 
                    }
                }
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx ++) { 
                    retArr[curPosOut++] = m_data[higherDimSum + rleadDim[lIdx]]; 
                }
                while (curPosOut < outElemCount) {
                    // increase higher dims 
                    d = 1; 
                    while  (d < idxArr.Length) {
                        if (!isFullDim[d]) {
                            if (idxArr[d] >= r[d].Length - 1) {
                                idxArr[d] = 0;
                                d++; 
                            } else {
                                break; 
                            }
                        } else {
                            if (idxArr[d] >= - r[d][0]) { 
                                idxArr[d] = 0;
                                d++; 
                            } else {
                                break; 
                            }
                        }
                        System.Diagnostics.Debug.Assert(d < idxArr.Length); 
                    }
                    System.Diagnostics.Debug.Assert(d != idxArr.Length);
                    idxArr[d] += 1;
                    higherDimSum = 0; 
                    for (int i = 1; i < idxArr.Length; i++) {
                        if (isFullDim[i]) {
                            higherDimSum += seqDistances[i] * idxArr[i];
                        } else {
                            higherDimSum += seqDistances[i] * (r[i][idxArr[i]]); 
                        }
                    }
                    // do the copy! 
                    for (int lIdx = 0; lIdx < leadDimLenRange; lIdx ++) { 
                        retArr[curPosOut++] = m_data[higherDimSum + rleadDim[lIdx]]; 
                    }

                }
                #endregion
            }
            return new ILArray<BaseT> (retArr,range.GetDimensions()); 
        }
        /// <summary>
        /// create shifted physical subarray of ILArray specified by range and shift
        /// </summary>
        /// <param name="range">must be valid range</param>
        /// <param name="shift">may be any integer - will be handled modulus ranges dimensions</param>
        /// <returns>physical array specified by range / shift</returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalShifted( int shift, ILRange range) {
			if (range == null) 
                throw new ILArgumentException ("ILArray (construct): Range specified must not be null!"); 
            int rangeDimLen = range.NumberOfDimensions,higherDimSum = 0;
            int intshift = shift % rangeDimLen;  
            shift = shift % ((rangeDimLen > 1)? rangeDimLen : 2); 
            int curPosOut = 0, d; 
            BaseT[] retArr = ILMemoryPool.Pool.New< BaseT> (range.NumberOfElements ); 
            int leadDimNr = intshift, leadDimLenRange = range[intshift].Length, leadDimLen = m_dimensions[intshift];
            int leadDimInc = m_dimensions.SequentialIndexDistance(intshift), tmpI = 0; 
            int outElemCount = range.NumberOfElements, curPosIn; 
            int[] idxArr = new int[rangeDimLen];    // used to store current position inside higher dims 
            bool[] isFullDim = new bool[rangeDimLen]; 
            int[][] r = range.RangeArray; 
            int[] rleadDim = r[leadDimNr];   // faster access 
            int[] seqDistances = m_dimensions.GetSequentialIndexDistances(range.NumberOfDimensions); 
            if (rleadDim[0] < 0) {
                #region LeadDim is full (specified as ':')
                // leading dimension is a "full" dimension: only its largest 
                // index is (negative) given in range[d]
                leadDimLenRange = - rleadDim[0] +1; 
                for (int i = 1; i < idxArr.Length; i++) {
                    tmpI = (leadDimNr + i) % rangeDimLen; 
                    if (r[tmpI][0] < 0) {
                        // full dimension
                        //higherDimSum += m_dimensions.SequentialIndexDistance(tmpI) * idxArr[i];  // always 0!
                        isFullDim[tmpI] = true; 
                    } else {
                        higherDimSum += seqDistances[tmpI] * (r[tmpI][0]); 
                    }
                }
                curPosIn = higherDimSum; // todo: might be implemented more efficient...
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++, curPosIn += leadDimInc) { 
                    retArr[curPosOut++] = m_data[curPosIn];
                }
                while (curPosOut < outElemCount) {
                    // increase higher dims 
                    d = (leadDimNr + 1) % rangeDimLen; 
                    while  (d != leadDimNr) {
                        if (!isFullDim[d]) {
                            if (idxArr[d] >= range[d].Length - 1) {
                                idxArr[d] = 0;
                                d = (d+1) % rangeDimLen; 
                            } else {
                                break;  
                            }
                        } else {
                            if (idxArr[d] >= - r[d][0]) { 
                                idxArr[d] = 0;
                                d = (d+1) % rangeDimLen;  
                            } else {
                                break;  
                            }
                        }
                    }
                    System.Diagnostics.Debug.Assert(d != leadDimNr); 
                    idxArr[d] += 1;
                    higherDimSum = 0; 
                    for (int i = 1; i < idxArr.Length; i++) {
                        tmpI = (i + leadDimNr)%rangeDimLen; 
                        if (isFullDim[tmpI]) {
                            higherDimSum += seqDistances[tmpI] * idxArr[tmpI];
                        } else {
                            higherDimSum += seqDistances[tmpI] * (r[tmpI][idxArr[tmpI]]); 
                        }
                    }
                    // do the copy! 
                    curPosIn = higherDimSum; // todo: might be implemented more efficient...
                    tmpI = leadDimLenRange; 
                    while(tmpI-- > 0) { 
                        retArr[curPosOut++] = m_data[curPosIn];
                        curPosIn += leadDimInc; 
                    }
                }
                #endregion
            } else {
                #region LeadDim is explicitly declared 
                for (int i = 1; i < idxArr.Length; i++) {
                    tmpI = (leadDimNr + i) % rangeDimLen; 
                    if (r[tmpI][0] < 0) {
                        // full dimension
                        //higherDimSum += m_dimensions.SequentialIndexDistance(tmpI) * idxArr[i];  // always 0!
                        isFullDim[tmpI] = true; 
                    } else {
                        higherDimSum += seqDistances[tmpI] * (r[tmpI][0]); 
                    }
                }
                curPosIn = higherDimSum; // todo: might be implemented more efficient...
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++) { 
                    curPosIn = higherDimSum + rleadDim[lIdx] * leadDimInc;
                    retArr[curPosOut++] = m_data[curPosIn];
                }
                while (curPosOut < outElemCount) {
                    // increase higher dims 
                    d = (leadDimNr + 1) % rangeDimLen; 
                    while (d != leadDimNr) {
                        if (!isFullDim[d]) {
                            if (idxArr[d] >= range[d].Length - 1) {
                                idxArr[d] = 0;
                                d = (d+1) % rangeDimLen; 
                            } else {
                                break;  
                            }
                        } else {
                            if (idxArr[d] >= - r[d][0]) { 
                                idxArr[d] = 0;
                                d = (d+1) % rangeDimLen;  
                            } else {
                                break;  
                            }
                        }
                    }
                    System.Diagnostics.Debug.Assert (d != leadDimNr);  // reached the end
                    idxArr[d] += 1;
                    higherDimSum = 0; 
                    for (int i = 1; i < idxArr.Length; i++) {
                        tmpI = (i + leadDimNr)%rangeDimLen; 
                        if (isFullDim[tmpI]) {
                            higherDimSum += seqDistances[tmpI] * idxArr[tmpI];
                        } else {
                            higherDimSum += seqDistances[tmpI] * (r[tmpI][idxArr[tmpI]]); 
                        }
                    }
                    // do the copy! 
                    curPosIn = higherDimSum; // todo: might be implemented more efficient...
                    for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++) { 
                        curPosIn = higherDimSum + rleadDim[lIdx] * leadDimInc;
                        retArr[curPosOut++] = m_data[curPosIn];
                    }
                }
                #endregion
            }
            return new ILArray<BaseT> (retArr,range.GetDimensions().GetShifted(shift)); 
        }
        #endregion 

        #region subarray creation: Reference
        /// <summary>
        /// create full reference subarray if this is a physical array
        /// </summary>
        /// <param name="range">range specification - must (o.c.) be a valid range</param>
        /// <returns>referencing subarray with dimensions specified by range</returns>
        private ILArray<BaseT> CreateReferenceSubarrayFromPhysical(ILRange range) {
            ILIndexOffset outIDXOffset = null; 
            int posIdxOffset = 0, rDimLen = range.NumberOfDimensions;
            int singlDimAdds = 0; // offset increment for singleton dimensions passed
            int[][] indexOffset;
            int[][] rangeArr = range.RangeArray; 
            int[] seqDistances = m_dimensions.GetSequentialIndexDistances(range.NumberOfDimensions);
            int[] isRegularSpaced; 
            // reference will be tensor order 2 or greater 
            // create temp jagged array as if no dims from range 
            // would be trimmed
            indexOffset = new int[rDimLen][];
            isRegularSpaced = new int[rDimLen]; 
            // current position to write to tmp idxOffset 
            // (start from end!)
            posIdxOffset = rDimLen - 1;
            int d; int tmpLen;
            int nonSingleDimCount = 0;
            // will be set to true if passed the first non 
            // singleton > trim from end(s) only/ see below
            bool singlDimStop = false;
            for (d = rDimLen; d-- > 0; ) {
                // current position inside range (shifted) 
                tmpLen = range[d].Length;
                // enable both trims: from end of srcStorage 
                // AND from end of shifted storage!!
                if (d == rDimLen - 1)
                    singlDimStop = false;
                if (tmpLen == 1 && singlDimStop == false && rangeArr[d][0] >= 0) {
                    // trim singleton dimensions from end of this
                    singlDimAdds += seqDistances[d] * rangeArr[d][0];
                } else {
                    if (tmpLen == 1 && rangeArr[d][0] < 0) {
                        // full dimension requested
                        tmpLen = -rangeArr[d][0] + 1; // length of indices 
                    }
                    // non singleton dim found -> create entry in indexOffset
                    singlDimStop = true;
                    nonSingleDimCount++;
                    indexOffset[posIdxOffset] = new int[tmpLen];
                    if (tmpLen == rangeArr[d].Length)
                        // explicit elements in dimension addressed 
                        for (int i = 0; i < tmpLen; i++)
                            indexOffset[posIdxOffset][i] = seqDistances[d] * rangeArr[d][i];
                    else 
                        // full dimension addressed
                        for (int i = 0; i < tmpLen; i++)
                            indexOffset[posIdxOffset][i] = seqDistances[d] * i;
                    posIdxOffset--;
                    isRegularSpaced[d] = (range.Spacing(d) != int.MinValue)? range.Spacing(d) * seqDistances[d] : int.MinValue; 
                }
            }
            // test if more than one dimension left after all that trim
            if (nonSingleDimCount == 0) {
                // scalar
                int[][] tmp = new int[2][];
                tmp[0] = new int[1] { singlDimAdds };
                tmp[1] = new int[1] { 0 };
                outIDXOffset = new ILIndexOffset(tmp,isRegularSpaced);
           } else if (nonSingleDimCount == 1) {
                // vector -> constructing ILMatrixStorage 
                int[][] tmp = new int[2][];
                tmp[0] = indexOffset[posIdxOffset + 1];
                tmp[1] = new int[1] { singlDimAdds };
                outIDXOffset = new ILIndexOffset(tmp,isRegularSpaced);
            } else {
                // tensor order 2 ...
                ILDimension outDims = range.GetDimensions();
                // dimensions may be trimmable (again) after shift!!
                // trim + transfer indexOffset 
                if (outDims.NumberOfDimensions < indexOffset.Length || posIdxOffset >= 0) {
                    int[][] tmp = new int[outDims.NumberOfDimensions][];
                    System.Array.Copy(indexOffset, posIdxOffset + 1,
                                        tmp, 0, outDims.NumberOfDimensions);
                    indexOffset = tmp;
                }
                // add singleton dimensions offset to first dimension
                if (singlDimAdds > 0)
                    for (int i = 0; i < indexOffset[0].Length; i++)
                        indexOffset[0][i] += singlDimAdds;
                outIDXOffset = new ILIndexOffset(indexOffset,isRegularSpaced);
            }
            return new ILArray<BaseT>(this, outIDXOffset);  
        }
                                #region obsolete - alternative for ILIndexOffset.Map
        //private ILArray<BaseT> CreateReferenceSubarrayFromReference(ILRange range) {
        //    ILIndexOffset outIDXOffset = null; 
        //    int posIdxOffset = 0, rDimLen = range.NumberOfDimensions;
        //    int singlDimAdds = 0; // offset increment for singleton dimensions passed
        //    int[][] indexOffset;
        //    int[][] rangeArr = range.RangeArray; 
        //    int[] seqDistances = m_dimensions.SequentialIndexDistances; 
        //    // reference will be tensor order 2 or greater 
        //    // create temp jagged array as if no dims from range 
        //    // would be trimmed
        //    indexOffset = new int[rDimLen][];
        //    // current position to write to tmp idxOffset 
        //    // (start from end!)
        //    posIdxOffset = rDimLen - 1;
        //    int d; int tmpLen;
        //    int nonSingleDimCount = 0;
        //    // will be set to true if passed the first non 
        //    // singleton > trim from end(s) only/ see below
        //    bool singlDimStop = false;
        //    for (d = rDimLen; d-- > 0; ) {
        //        // current position inside range (shifted) 
        //        tmpLen = range[d].Length;
        //        // enable both trims: from end of srcStorage 
        //        // AND from end of shifted storage!!
        //        if (d == rDimLen - 1)
        //            singlDimStop = false;
        //        if (tmpLen == 1 && singlDimStop == false && rangeArr[d][0] >= 0) {
        //            // trim singleton dimensions from end of this
        //            singlDimAdds += seqDistances[d] * rangeArr[d][0];
        //        } else {
        //            if (tmpLen == 1 && rangeArr[d][0] < 0) {
        //                // full dimension requested
        //                tmpLen = -rangeArr[d][0] + 1; // length of indices 
        //            }
        //            // non singleton dim found -> create entry in indexOffset
        //            singlDimStop = true;
        //            nonSingleDimCount++;
        //            indexOffset[posIdxOffset] = new int[tmpLen];
        //            if (tmpLen == rangeArr[d].Length)
        //                for (int i = 0; i < tmpLen; i++)
        //                    indexOffset[posIdxOffset][i]
        //                        = m_indexOffset[d, rangeArr[d][i]];
        //            else 
        //                for (int i = 0; i < tmpLen; i++)
        //                    indexOffset[posIdxOffset][i]
        //                        =  m_indexOffset[d, i];
        //            posIdxOffset--;
        //        }
        //    }
        //    // test if more than one dimension left after all that trim
        //    if (nonSingleDimCount == 0) {
        //        // scalar
        //        int[][] tmp = new int[2][];
        //        tmp[0] = new int[1] { singlDimAdds };
        //        tmp[1] = new int[1] { 0 };
        //        outIDXOffset = new ILIndexOffset(tmp);
        //        m_dimensions = new ILDimension(1, 1);
        //        m_dimensions[0] = 1;
        //        m_dimensions[1] = 1;
        //    } else if (nonSingleDimCount == 1) {
        //        // vector -> constructing ILMatrixStorage 
        //        int[][] tmp = new int[2][];
        //        tmp[0] = indexOffset[posIdxOffset + 1];
        //        tmp[1] = new int[1] { singlDimAdds };
        //        outIDXOffset = new ILIndexOffset(tmp);
        //    } else {
        //        // tensor order 2 ...
        //        ILDimension outDims = range.GetDimensions();
        //        // trim + transfer indexOffset 
        //        if (outDims.NumberOfDimensions < indexOffset.Length || posIdxOffset >= 0) {
        //            int[][] tmp = new int[outDims.NumberOfDimensions][];
        //            System.Array.Copy(indexOffset, posIdxOffset + 1,
        //                                tmp, 0, outDims.NumberOfDimensions);
        //            indexOffset = tmp;
        //        }
        //        // add singleton dimensions offset to first dimension
        //        if (singlDimAdds > 0)
        //            for (int i = 0; i < indexOffset[0].Length; i++)
        //                indexOffset[0][i] += singlDimAdds;
        //        outIDXOffset = new ILIndexOffset(indexOffset);
        //    }
        //    return new ILArray<BaseT>(this, outIDXOffset);  
        //}
        #endregion
        /// <summary>
        /// full referencing subarray if this is reference array 
        /// </summary>
        /// <param name="range">range specification</param>
        /// <returns>referencing subarray with dimensions specified by range</returns>
        private ILArray<BaseT> CreateReferenceSubarrayFromReference(ILRange range) {
            return new ILArray<BaseT>(this,m_indexOffset.Map(range,0)); 
        }
        /// <summary>
        /// create reference subarray if this is physical array and shift dimensions 
        /// </summary>
        /// <param name="shift">number of dimensions to shift</param>
        /// <param name="range">range specification</param>
        /// <returns>shifted reference array with size specified by range</returns>
        private ILArray<BaseT> CreateReferenceSubarrayFromPhysicalShifted(Int16 shift, ILRange range) {
            ILIndexOffset outIDXOffset = null; 
            int posIdxOffset = 0, rDimLen = range.NumberOfDimensions;
            int singlDimAdds = 0; // offset increment for singleton dimensions passed
            int[][] indexOffset;
            int[][] rangeArr = range.RangeArray; 
            int[] seqDistances = m_dimensions.GetSequentialIndexDistances(range.NumberOfDimensions); 
            int[] regularSpacing = new int[rDimLen]; 
            // reference will be tensor order 2 or greater 
            // create temp jagged array as if no dims from range 
            // would be trimmed
            indexOffset = new int[rDimLen][];
            // current position to write to tmp idxOffset 
            // (start from end!)
            posIdxOffset = rDimLen - 1;
            int d; int tmpLen; int curRangeIdx;
            int nonSingleDimCount = 0;
            // will be set to true if passed the first non 
            // singleton > trim from end(s) only/ see below
            bool singlDimStop = false;
            for (d = rDimLen; d-- > 0; ) {
                // current position inside range (shifted) 
                curRangeIdx = (d + shift) % rDimLen;
                tmpLen = range[curRangeIdx].Length;
                // enable both trims: from end of srcStorage 
                // AND from end of shifted storage!!
                if (curRangeIdx == rDimLen - 1)
                    singlDimStop = false;
                if (tmpLen == 1 && singlDimStop == false && rangeArr[curRangeIdx][0] >= 0) {
                    // trim singleton dimensions from end of this
                    singlDimAdds += seqDistances[curRangeIdx] * rangeArr[curRangeIdx][0];
                } else {
                    if (tmpLen == 1 && rangeArr[curRangeIdx][0] < 0) {
                        // full dimension requested
                        tmpLen = -rangeArr[curRangeIdx][0] + 1; // length of indices 
                    }
                    // non singleton dim found -> create entry in indexOffset
                    singlDimStop = true;
                    nonSingleDimCount++;
                    indexOffset[posIdxOffset] = new int[tmpLen];
                    if (tmpLen == rangeArr[curRangeIdx].Length) {
                        // explicit elements in dimension addressed 
                        for (int i = 0; i < tmpLen; i++)
                            indexOffset[posIdxOffset][i] = seqDistances[curRangeIdx] * rangeArr[curRangeIdx][i];
                    } else {
                        // full dimension addressed
                        for (int i = 0; i < tmpLen; i++)
                            indexOffset[posIdxOffset][i] = seqDistances[curRangeIdx] * i;
                    }
                    regularSpacing[posIdxOffset] = (range.Spacing(curRangeIdx) != int.MinValue) ?  
                        range.Spacing(curRangeIdx) * seqDistances[curRangeIdx] : int.MinValue; 
                    posIdxOffset--;
                }
            }
            // test if more than one dimension left after all that trim
            if (nonSingleDimCount == 0) {
                // scalar
                int[][] tmp = new int[2][];
                tmp[0] = new int[1] { singlDimAdds };
                tmp[1] = new int[1] { 0 };
                outIDXOffset = new ILIndexOffset(tmp,regularSpacing);
           } else if (nonSingleDimCount == 1) {
                // vector 
                int[][] tmp = new int[2][];
                tmp[(shift -1) % 2] = indexOffset[posIdxOffset + 1];
                tmp[(shift) % 2] = new int[1] { singlDimAdds };
                int [] tmpRegularSpacing = new int [2]; 
                tmpRegularSpacing[(shift-1) % 2] = regularSpacing[posIdxOffset + 1];  
                tmpRegularSpacing[(shift) % 2] = 0;
                outIDXOffset = new ILIndexOffset(tmp,tmpRegularSpacing);
            } else {
                // tensor order 2 ...
                ILDimension outDims = range.GetDimensions();
                // dimensions may be trimmable (again) after shift!!
                outDims = outDims.GetShifted(shift).Trim(); 
                // trim + transfer indexOffset 
                if (outDims.NumberOfDimensions < indexOffset.Length || posIdxOffset >= 0) {
                    int[][] tmp = new int[outDims.NumberOfDimensions][];
                    System.Array.Copy(indexOffset, posIdxOffset + 1,
                                        tmp, 0, outDims.NumberOfDimensions);
                    indexOffset = tmp;
                    int [ ] tmpRS = new int[outDims.NumberOfDimensions];
                    System.Array.Copy(regularSpacing, posIdxOffset + 1,
                                        tmpRS, 0, outDims.NumberOfDimensions);
                    regularSpacing = tmpRS;
                }
                // add singleton dimensions offset to first dimension
                if (singlDimAdds > 0)
                    for (int i = 0; i < indexOffset[0].Length; i++)
                        indexOffset[0][i] += singlDimAdds;
                outIDXOffset = new ILIndexOffset(indexOffset,regularSpacing);
            }
            return new ILArray<BaseT>(this, outIDXOffset);  
        }
        /// <summary>
        /// create reference subarray if this is reference and shift dimensions 
        /// </summary>
        /// <param name="shift">number of dimensions to shift</param>
        /// <param name="range">range specification</param>
        /// <returns>shifted reference array with size specified by range</returns>
        private ILArray<BaseT> CreateReferenceSubarrayFromReferenceShifted(Int16 shift, ILRange range) {
            return new ILArray<BaseT>(this,m_indexOffset.Map(range,shift));  
        }
        #region HYCALPER LOOPSTART Sequential access
/*!HC:TYPELIST:
<hycalper>
<type>
    <source locate="after">
        inCls1
    </source>
    <destination><![CDATA[ILArray<float>]]></destination>
    <destination><![CDATA[ILArray<Int16>]]></destination>
    <destination><![CDATA[ILArray<Int32>]]></destination>
    <destination><![CDATA[ILArray<Int64>]]></destination>
    <destination><![CDATA[ILArray<UInt16>]]></destination>
    <destination><![CDATA[ILArray<UInt32>]]></destination>
    <destination><![CDATA[ILArray<UInt64>]]></destination>
    <destination><![CDATA[ILArray<char>]]></destination>
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
    <destination><![CDATA[ILArray<fcomplex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>float</destination>
    <destination>Int16</destination>
    <destination>Int32</destination>
    <destination>Int64</destination>
    <destination>UInt16</destination>
    <destination>UInt32</destination>
    <destination>UInt64</destination>
    <destination>char</destination>
    <destination>byte</destination>
    <destination>complex</destination>
    <destination>fcomplex</destination>
</type>
</hycalper>
 */
        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential(/*!HC:inCls1*/ ILArray<double> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted(/*!HC:inCls1*/ ILArray<double> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        #endregion HYCALPER LOOPEND Sequential access
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<fcomplex> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<fcomplex> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<complex> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<complex> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<byte> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<byte> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<char> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<char> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<UInt64> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<UInt64> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<UInt32> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<UInt32> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<UInt16> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<UInt16> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<Int64> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<Int64> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<Int32> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<Int32> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<Int16> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<Int16> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

        /// <summary>
        /// create reference from sequential indices
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequential( ILArray<float> indices){
            // create ILIndexOffset
            // THIS FUNCTION DOES ONLY MAKE SENCE FOR INDICES BEING A VECTOR! 
            // for higher dimensions it would be too complicated to track regularity... 
            System.Diagnostics.Debug.Assert (indices.IsVector); 
            ILDimension dim = indices.m_dimensions;
            int[][] idx = new int[2][];
            int sdDim = ((dim[0] == 1) ? 0 : 1);
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }
        /// <summary>
        /// create reference from sequential indices and shift dimensions
        /// </summary>
        /// <param name="indices">array of vector size</param>
        /// <param name="shift">number of dimensions to shift the result</param>
        /// <returns>Referencing ILArray vector pointing to this ILArray's elements</returns>
        /// <remarks> Make sure indices is <b>vector</b> have not more than 2 dimensions and all 
        /// values in indices fit inside my array! Only the first 2 dimensions 
        /// will be recognized! No Exception will be thrown!</remarks>
        private ILArray<BaseT> CreateReferenceSubarrayFromArraySequentialShifted( ILArray<float> indices, int shift){
            // create ILIndexOffset
            System.Diagnostics.Debug.Assert(true); // this function is obsolete: referencing makes only sence for arrays dim > 2! only vectors can garantee proper spacing for referencing here ...
            ILDimension dim = indices.m_dimensions; 
            int[][] idx = new int[2][];
            int sdDim = (((dim[0] == 1) ? 0 : 1) + shift) % 2;
            int nsdDim = (sdDim + 1) % 2;
            int outLen = dim.NumberOfElements; 
            idx[sdDim] = new int[1] { 0 };
            int[] nsd = new int [outLen]; 
            int[] regularSpacing = new int[2]; 
            bool stopped = false; 
            int spacing,oldVal,curVal; 
            regularSpacing[sdDim] = 0; 
            idx[nsdDim] = nsd;
            if (m_indexOffset == null) {
                if (outLen > 1) {
                    oldVal = nsd[0] = (int)indices.GetValue(0);
                    curVal = nsd[1] = (int)indices.GetValue(1);
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = (int)indices.GetValue(i);
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = (int)indices.GetValue(0);
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            } else {
                if (outLen > 1) {
                    oldVal = nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    curVal = nsd[1] = m_indexOffset[nsdDim,(int)indices.GetValue(1)];
                    regularSpacing[nsdDim] = spacing = curVal - oldVal;                     
                    for (int i = 2; i < outLen; i++) {
                        oldVal = curVal; 
                        curVal = nsd[i] = m_indexOffset[nsdDim,(int)indices.GetValue(i)];
                        if (!stopped && curVal - oldVal != spacing) {
                            stopped = true; 
                            regularSpacing[nsdDim] = int.MinValue; 
                        }
                    } 
                } else if (outLen == 1) {
                    nsd[0] = m_indexOffset[nsdDim,(int)indices.GetValue(0)];
                    regularSpacing[0] = 0; 
                } else { 
                    regularSpacing[0] = 0; 
                }
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idx,regularSpacing));
        }

#endregion HYCALPER AUTO GENERATED CODE

        #endregion 

        #region "Shift Only" Versions 
        /// <summary>
        /// create physical shifted version if this is physical array 
        /// </summary>
        /// <param name="shift">number of dimensions to shift</param>
        /// <returns>physical array</returns>
        private ILArray<BaseT> CreatePhysicalShiftedFromPhysical(int shift) {
            if (IsEmpty) return ILArray<BaseT>.empty(m_dimensions.GetShifted(shift)); 
            BaseT[] retArr = ILMemoryPool.Pool.New<BaseT>(m_dimensions.NumberOfElements); 
            int inc = 1, len = m_dimensions.NumberOfDimensions;
            int numElem = m_dimensions.NumberOfElements-1; 
            int loopLen = numElem -1; 
            int pos = 0; 
            for (int d = 0; d < len && d < shift; d++) 
                inc *= m_dimensions[d]; 
            int i = 0; 
            while (i < numElem) {
                retArr[i++] = m_data[pos];
                pos = (pos + inc) % numElem; 
            }
            retArr[i] = m_data[numElem];
            return new ILArray<BaseT>(retArr, m_dimensions.GetShifted(shift)); 
        }
        /// <summary>
        /// create physical shifted version if this is a reference array 
        /// </summary>
        /// <param name="shift">number of dimensions to shift</param>
        /// <returns>reference array</returns>
        private ILArray<BaseT> CreatePhysicalShiftedFromReference(int shift) {
            if (IsEmpty) return ILArray<BaseT>.empty(m_dimensions.GetShifted(shift)); 
            BaseT[] retArr = ILMemoryPool.Pool.New< BaseT> (m_dimensions.NumberOfElements); 
            int inc = 1, len = m_dimensions.NumberOfDimensions;
            int numElem = m_dimensions.NumberOfElements-1; 
            int loopLen = numElem -1; 
            int pos = 0; 
            for (int d = 0; d < len && d < shift; d++) 
                inc *= m_dimensions[d]; 
            int i = 0; 
            while (i < numElem) {
                retArr[i++] = m_data[getBaseIndex(pos)];
                pos = (pos + inc) % numElem; 
            }
            retArr[i] = m_data[getBaseIndex(numElem)];
            return new ILArray<BaseT>(retArr, m_dimensions.GetShifted(shift)); 
        }
        /// <summary>
        /// create reference array by shifting its dimensions 
        /// </summary>
        /// <param name="shift">number of dimension to shift</param>
        /// <returns>reference array with shifted dimensions</returns>
        private ILArray<BaseT> CreateReferenceShiftedFromPhysical(int shift) {
            if (IsEmpty) return ILArray<BaseT>.empty(m_dimensions.GetShifted(shift)); 
            int idxPos = 0;
            int srcPos = 0;
            if (shift < 0) shift = 0; 
            ILDimension srcDims = m_dimensions.Trim();
            int[][] idxOffset = new int[srcDims.NumberOfDimensions][];
            int[] seqDistances = m_dimensions.GetSequentialIndexDistances(0); 
            int[] regularSpacing = new int [srcDims.NumberOfDimensions]; 
            for (int i = 0; i < srcDims.NumberOfDimensions; i++) {
                idxPos = i;
                srcPos = (i + shift) % srcDims.NumberOfDimensions;
                idxOffset[idxPos] = new int[srcDims[srcPos]];
                for (int d = 0; d < srcDims[srcPos]; d++) {
                    idxOffset[idxPos][d] =  seqDistances[srcPos] * d;
                }
                regularSpacing[idxPos] = seqDistances[srcPos]; 
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idxOffset,regularSpacing)); 
        }
        /// <summary>
        /// create reference array from full reference array by shifting dimensions 
        /// </summary>
        /// <param name="shift">number of dimensions to shift </param>
        /// <returns>referencing array with shifted dimensions</returns>
        private ILArray<BaseT> CreateReferenceShiftedFromReference(int shift) {
            if (IsEmpty) return ILArray<BaseT>.empty(m_dimensions.GetShifted(shift)); 
            int idxPos = 0;
            int srcPos = 0;
            if (shift < 0) shift = 0; 
            ILDimension srcDims = m_dimensions.Trim();
            int[][] idxOffset = new int[srcDims.NumberOfDimensions][];
            int[] regularSpacing = new int [srcDims.NumberOfDimensions]; 
            for (int i = 0; i < srcDims.NumberOfDimensions; i++) {
                idxPos = i;
                srcPos = (i + shift) % srcDims.NumberOfDimensions;
                idxOffset[idxPos] = new int[srcDims[srcPos]];
                int[] tmpDim = m_indexOffset[srcPos]; 
                for (int d = 0; d < srcDims[srcPos]; d++) {
                    idxOffset[idxPos][d] = tmpDim[d];
                }
                regularSpacing[idxPos] = m_indexOffset.RegularySpacing(srcPos); 
            }
            return new ILArray<BaseT>(this, new ILIndexOffset(idxOffset,regularSpacing)); 
        }
        #endregion

    }
}
