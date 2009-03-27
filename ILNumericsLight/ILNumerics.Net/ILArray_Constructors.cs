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
        public ILArray(BaseT[] data, ILDimension dimensions)
        {
            System.Diagnostics.Debug.Assert(dimensions != null, "ILArray|(construct): " + 
                "dimension must be specified!");

            m_dimensions = dimensions.Trim();
            if (data.Length != m_dimensions.NumberOfElements)
                throw new ILArgumentException("ILArray.construct: Data array specifier must match "
                                        + "size of dimensions!");
            m_data = data;
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
        internal ILArray(ILArray<BaseT> inp)
        {
            m_data = (BaseT[])inp.m_data;
            m_dimensions = inp.m_dimensions;
            m_name = inp.Name;
        }
        /// <summary>
        /// implicit copy constructor
        /// </summary>
        /// <param name="inp">ILArray to be copied</param>
        /// <remarks>This is used in C++ derivate as assignment operator</remarks>
        public void MarshalCopy(ILArray<BaseT> inp)
        {
            m_data = inp.m_data;
            m_dimensions = inp.Dimensions;
            m_name = inp.Name;
        }
        /// <summary>
        /// create scalar or row vector from values explitely given
        /// </summary>
        /// <param name="vector_elements">elements. </param>
        /// <remarks><para>The elements may are given as comma seperated list or as predefined System.Array 
        /// of type 'BaseT'. In this case the System.Array object given will directly be used as storage 
        /// for the newly created ILArray.</para>
        /// <para>If vector_elements is null, an empty ILArray will be created.</para></remarks>
        public ILArray(BaseT[] vector_elements)
        {
            if (object.Equals(vector_elements, null))
            {
                m_data = new BaseT[0];
                m_dimensions = new ILDimension(new int[2] { 0, 0 });
            }
            else
            {
                m_data = vector_elements;
                m_dimensions = new ILDimension(new int[2] { 1, m_data.Length });
            }
        }
        /// <summary>
        /// Standard constructor creating empty ILArray
        /// </summary>
        public ILArray()
        {
            m_data = new BaseT[0];
            m_dimensions = new ILDimension();
            m_name = "";
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
                if (range[0] is ILArray<double>) {
                    return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<double>)range[0]); 
                } else if (range[0] is ILLogicalArray) {
                    return CreatePhysicalSubarrayFromPhysicalSequential(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0])); 
                } else if (range[0] is ILArray<complex>) {
                    return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<complex>)range[0]); 
                } else if (range[0] is ILArray<byte>) {
                    return CreatePhysicalSubarrayFromPhysicalSequential((ILArray<byte>)range[0]); 
                } else throw new ILArgumentException ("specified type of indices array is not supported for sequential addressing!");
                #endregion sequential index access
            } else {
                ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
                if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0); 
                return CreatePhysicalSubarrayFromPhysical(rng);
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
                if (range[0] is ILArray<double>) {
                    return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<double>)range[0],shift); 
                } else if (range[0] is ILLogicalArray) {
                    return CreatePhysicalSubarrayFromPhysicalSequentialShifted(ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)range[0]),shift); 
                } else if (range[0] is ILArray<complex>) {
                    return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<complex>)range[0],shift); 
                } else if (range[0] is ILArray<byte>) {
                    return CreatePhysicalSubarrayFromPhysicalSequentialShifted((ILArray<byte>)range[0],shift); 
                } else throw new ILArgumentException ("specified type of indices array is not supported for sequential addressing!");
                #endregion sequential index access
            } else {
                ILRange rng = new ILRange(m_dimensions,RangeSide.Right, range); 
                if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0,0);
                return CreatePhysicalSubarrayFromPhysicalShifted((short)shift, rng);
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
            return CreatePhysicalSubarrayFromPhysicalShifted((short)shift,rng); 
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
            return CreatePhysicalSubarrayFromPhysical(rng); 
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
    <destination><![CDATA[ILArray<byte>]]></destination>
    <destination><![CDATA[ILArray<complex>]]></destination>
</type>
<type>
    <source locate="after">
        inArr1
    </source>
    <destination>byte</destination>
    <destination>complex</destination>
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

            /*!HC:inArr1*/ double [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++)
                outdata[i] = m_data[(int)indData[i]]; 

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

            /*!HC:inArr1*/ double [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++) {
                outdata[outPos] = m_data[(int)indData[i]]; 
                outPos += outInc; 
                if (outPos > outLen) outPos %= outLen; 
            }
            outdata[outLen] = m_data[(int)indData[outLen]];

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
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysicalSequential( ILArray<complex> indices){
            ILDimension dim = indices.m_dimensions; 
            int outLen = dim.NumberOfElements; 
            BaseT[] outdata = ILMemoryPool.Pool.New< BaseT> (outLen); 

            complex [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++)
                outdata[i] = m_data[(int)indData[i]]; 

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

            complex [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++) {
                outdata[outPos] = m_data[(int)indData[i]]; 
                outPos += outInc; 
                if (outPos > outLen) outPos %= outLen; 
            }
            outdata[outLen] = m_data[(int)indData[outLen]];

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

            byte [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++)
                outdata[i] = m_data[(int)indData[i]]; 

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

            byte [] indData = indices.m_data; 
            for (int i = 0; i < outLen; i++) {
                outdata[outPos] = m_data[(int)indData[i]]; 
                outPos += outInc; 
                if (outPos > outLen) outPos %= outLen; 
            }
            outdata[outLen] = m_data[(int)indData[outLen]];

            return new ILArray<BaseT>(outdata, dim);
        }
        

#endregion HYCALPER AUTO GENERATED CODE
       
        /// <summary>
        /// create physical subarray from physical ILArray 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        private ILArray<BaseT> CreatePhysicalSubarrayFromPhysical(ILRange range)
        {
            if (range == null)
                throw new ILArgumentException("range specified must not be null!");
            int rangeDimLen = range.NumberOfDimensions, higherDimSum = 0;
            int leadDimLenRange = range[0].Length, leadDimLen = m_dimensions[0];
            int curPosOut = 0, d, outElemCount = range.NumberOfElements;
            BaseT[] retArr = ILMemoryPool.Pool.New<BaseT>(outElemCount);
            int[] idxArr = new int[rangeDimLen];    // used to store current position inside higher dims 
            bool[] isFullDim = new bool[rangeDimLen];
            int[][] r = range.RangeArray;
            int[] seqDistances = m_dimensions.GetSequentialIndexDistances(range.NumberOfDimensions);
            int[] rleadDim = range[0];
            if (rleadDim[0] < 0)
            {
                #region LeadDim is full (specified as ':')
                // leading dimension is a "full" dimension: only its largest index is (negative) given in range[d]
                for (int i = 1; i < idxArr.Length; i++)
                {
                    if (r[i][0] < 0)
                    {
                        // full dimension
                        //higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                        isFullDim[i] = true;
                    }
                    else
                    {
                        higherDimSum += seqDistances[i] * (r[i][idxArr[i]]);
                    }
                }
                leadDimLenRange = -rleadDim[0] + 1;
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++)
                {
                    retArr[curPosOut++] = m_data[higherDimSum + lIdx];
                }
                while (curPosOut < outElemCount)
                {
                    // increase higher dims 
                    d = 1;
                    while (d < rangeDimLen)
                    {
                        if (!isFullDim[d])
                        {
                            if (idxArr[d] >= r[d].Length - 1)
                            {
                                idxArr[d] = 0;
                                d++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (idxArr[d] >= -r[d][0])
                            {
                                idxArr[d] = 0;
                                d++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    System.Diagnostics.Debug.Assert(d != idxArr.Length);
                    idxArr[d] += 1;
                    higherDimSum = 0;
                    for (int i = 1; i < idxArr.Length; i++)
                    {
                        if (isFullDim[i])
                        {
                            higherDimSum += seqDistances[i] * idxArr[i];
                        }
                        else
                        {
                            higherDimSum += seqDistances[i] * (r[i][idxArr[i]]);
                        }
                    }
                    // do the copy! 
                    for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++)
                    {
                        retArr[curPosOut++] = m_data[higherDimSum++];
                    }

                }
                #endregion
            }
            else
            {
                #region LeadDim is explicitly declared
                for (int i = 1; i < idxArr.Length; i++)
                {
                    // ... not sure for higher dimensions...
                    if (r[i][0] < 0)
                    {
                        // full dimension
                        // higherDimSum += m_dimensions.SequentialIndexDistance(i) * idxArr[i];
                        isFullDim[i] = true;
                    }
                    else
                    {
                        higherDimSum += seqDistances[i] * (r[i][0]);
                    }
                }
                for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++)
                {
                    retArr[curPosOut++] = m_data[higherDimSum + rleadDim[lIdx]];
                }
                while (curPosOut < outElemCount)
                {
                    // increase higher dims 
                    d = 1;
                    while (d < idxArr.Length)
                    {
                        if (!isFullDim[d])
                        {
                            if (idxArr[d] >= r[d].Length - 1)
                            {
                                idxArr[d] = 0;
                                d++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (idxArr[d] >= -r[d][0])
                            {
                                idxArr[d] = 0;
                                d++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        System.Diagnostics.Debug.Assert(d < idxArr.Length);
                    }
                    System.Diagnostics.Debug.Assert(d != idxArr.Length);
                    idxArr[d] += 1;
                    higherDimSum = 0;
                    for (int i = 1; i < idxArr.Length; i++)
                    {
                        if (isFullDim[i])
                        {
                            higherDimSum += seqDistances[i] * idxArr[i];
                        }
                        else
                        {
                            higherDimSum += seqDistances[i] * (r[i][idxArr[i]]);
                        }
                    }
                    // do the copy! 
                    for (int lIdx = 0; lIdx < leadDimLenRange; lIdx++)
                    {
                        retArr[curPosOut++] = m_data[higherDimSum + rleadDim[lIdx]];
                    }

                }
                #endregion
            }
            return new ILArray<BaseT>(retArr, range.GetDimensions());
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

        #endregion

    }
}
