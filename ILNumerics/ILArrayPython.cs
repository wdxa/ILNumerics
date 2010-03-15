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

#if IRONPYTHON

using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Runtime.Serialization; 
using System.Runtime.CompilerServices;
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
using ILNumerics.BuiltInFunctions;
using Slice = IronPython.Runtime.Slice;
[assembly:InternalsVisibleTo("ILNumericsTest, PublicKey=0024000004800000940000000602000000240000525341310004000001000100bb4dc9610b0cfe6f698d933c322979c2c69d17f119c94e6a182426ead00f8972014ef3cf8ba4c2499eaf3c314775b32d152a67375d0a48f4d2617c82b72e0a8fa0684c757366bbda6adc6a0c4fed35e73eece3c55e3dd51636dc32acf0d443a0a8033f9206854cfec8e35b8c8c2f7447cac8c52b6d88fcd3d4f72b64e295e2b2")]

namespace ILNumerics
{
    /// <summary>
    /// Main rectangular generic array type. Objects of this class are able to build references.
    /// </summary>
    /// <typeparam name="BaseT">inner type. This will mostly be a system numeric type or a 
    /// complex floating point type.</typeparam>
    /// <remarks> This class serves as the main rectangular array holding arbitrary elements 
    /// in arbitrary dimensions. The most common specialisation will be a numeric array of arbitrary size. 
    /// <para>The most significant property of ILArray's is the ability to create, hold and handle references of other 
    /// ILArray's. Those references act like a solid array to the outside world but consume only a very little 
    /// memory itself. Therefore they directly use the elements of the original array for computations and only 
    /// store access rules in a very economical yet performant way. Write access to any arrays involved is 
    /// controlled by internal reference counting. The references are detached accordingly. That behavior 
    /// may also get flexible adjusted by the user of the library due to the 
    /// <see cref="ILDetachingBehavior">ILDetachingBehavior</see> property. </para>
    /// <para>The inner type of the elements (specified through the generic parameter BaseT)
    /// does not change the general behavior of the ILArray<![CDATA[<>]]>. However, if it comes 
    /// to mathematical operations there is a limited number 
    /// of inner types common mathematical functions and operators are defined for. All basic 
    /// operations (+,-,*,/,<![CDATA[<,>,<=]]>,etc.) are defined for all ILArray's having 
    /// the inner type BaseT of a numeric type (system defined like 'double','int' - or complex, fcomplex).
    /// Some functions are defined for even less types. This is the case mostly for all linear algebraic functions 
    /// explicilty involving matrices or vectors (LAPACK) and for trigonometric functions and those, 
    /// wich explicitly return floating point values (cos, atan etc.). Therefore you may create ILArrays 
    /// of arbitrary types, but might not be able to use them afterwards in other then some basic 
    /// operations defined for all ILArrays - regardless of the inner type - like concatenation, (de)serialization and 
    /// string exports. </para>
    /// </remarks>
    /// <seealso cref="ILBaseArray"/>
    [System.Diagnostics.DebuggerTypeProxy(typeof(ILArrayDebuggerProxy<>))]
    [System.Diagnostics.DebuggerDisplay("{debuggerHeadLineDisplay(),nq}")]
    public partial class ILArray<BaseT> : ILBaseArray<BaseT>, IDisposable
    {

        #region members + properties

        /// <summary>
        /// Subarray access for get/set/removal
        /// </summary>
        /// <param name="slices">Array of IronPython Slice objects</param>
        /// <returns>Reference pointing to the elements of this array specified by range. If used for removal: 
        /// the array will be changed to a referencing array having the selected parts removed.</returns>
        public ILArray<BaseT> this[params IronPython.Runtime.Slice[] slices]
        {
            get
            {
                return (ILArray<BaseT>)Subarray((object[])slices);
            }
            set
            {
                if (Object.ReferenceEquals(value,null) || value.IsEmpty) {
                    ILDimension oldDim = m_dimensions; 
                    ILDimension newdim = null;
                    int dimIdx = -1; 
                    int[] indices = null; 
                    ExtractRemovalParameter((object[])slices, out dimIdx, out indices, out newdim); 
                    if (indices.Length == 0)
                        return; 
                    Reshape(newdim);
                    try {
                        Remove(dimIdx,indices); 
                    } catch (ILException e) {
                        // rollback: 
                        Reshape(oldDim); 
                        throw e; 
                    }
                } else {
                    SetRange(new ILRange(m_dimensions, RangeSide.Left, (object[])slices), value);
                }
            }
        }

        /// <summary>
        /// Subarray access for get/set/removal
        /// </summary>
        /// <param name="genSlices">Object array comprising IronPython Slice objects or integers</param>
        /// <returns>Reference pointing to the elements of this array specified by range. If used for removal: 
        /// the array will be changed to a referencing array having the selected parts removed.</returns>
        public ILArray<BaseT> this[params object[] genSlices]
        {
            get
            {
                return (ILArray<BaseT>)Subarray(genSlices);
            }
            set
            {
                if (Object.ReferenceEquals(value, null) || value.IsEmpty)
                {
                    ILDimension oldDim = m_dimensions;
                    ILDimension newdim = null;
                    int dimIdx = -1;
                    int[] indices = null;
                    ExtractRemovalParameter(genSlices, out dimIdx, out indices, out newdim);
                    if (indices.Length == 0)
                        return;
                    Reshape(newdim);
                    try
                    {
                        Remove(dimIdx, indices);
                    }
                    catch (ILException e)
                    {
                        // rollback: 
                        Reshape(oldDim);
                        throw e;
                    }
                }
                else
                {
                    SetRange(new ILRange(m_dimensions, RangeSide.Left, genSlices), value);
                }
            }
        }

        // Previous version, converting slices to strings
        //public ILArray<BaseT> this[params object[] genSlices]
        //{
        //    get
        //    {
        //        string[] range = new string[genSlices.Length];
        //        for (int i = 0; i < genSlices.Length; ++i)
        //        {
        //            if (genSlices[i] is int)
        //            {
        //                range[i] = ((int)genSlices[i]).ToString();
        //            }
        //            else if (genSlices[i] is Slice)
        //            {
        //                Slice tmpSlice = (Slice)genSlices[i];
        //                range[i] = ((tmpSlice.start == null) ? "0" : tmpSlice.start.ToString())
        //                + ((tmpSlice.step == null) ? "" : ":" + tmpSlice.step.ToString())
        //                + ((tmpSlice.stop == null) ? ":end" : ":" + tmpSlice.stop.ToString());
        //            }
        //        }
        //        return this[range];
        //    }
        //    set
        //    {
        //        string[] range = new string[genSlices.Length];
        //        for (int i = 0; i < genSlices.Length; ++i)
        //        {
        //            if (genSlices[i] is int)
        //            {
        //                range[i] = ((int)genSlices[i]).ToString();
        //            }
        //            else if (genSlices[i] is Slice)
        //            {
        //                Slice tmpSlice = (Slice)genSlices[i];
        //                range[i] = ((tmpSlice.start == null) ? "0" : tmpSlice.start.ToString())
        //                + ((tmpSlice.step == null) ? "" : ":" + tmpSlice.step.ToString())
        //                + ((tmpSlice.stop == null) ? ":end" : ":" + tmpSlice.stop.ToString());
        //            }
        //        }
        //        this[range] = value;
        //    }
        //}

        #endregion

        public ILBaseArray __pow__(double exponent)
        {
            if (this is ILArray<double>)
            {
                return ILMath.pow(this as ILArray<double>, exponent);

            }
            else if (this is ILArray<complex>)
            {
                return ILMath.pow(this as ILArray<complex>, exponent);
            }
            else return new ILArray<BaseT>();
        }

        public ILArray(IronPython.Runtime.List list)
        {
            List<int> size = new List<int>();
            Type type = typeof(double);
            PythonListHelper.GetListDimensionsAndType(ref size, list, ref type);
            if (!PythonListHelper.CheckList(ref size, list, 0, ref type))
            {
                throw new ArgumentException("List is not rectangular or not of constant type!");
            }
            if (type != typeof(BaseT))
            {
                throw new ArgumentException("Array type does not match list type!");
            }
            try
            {
                m_dimensions = new ILDimension(true, size.ToArray());
                bool dummy;
                m_data = ILMemoryPool.Pool.New<BaseT>(m_dimensions.NumberOfElements, true, out dummy);
                m_name = "";
                IncreaseReference();
            }
            catch (Exception e)
            {
                throw new Exception("Error creating new ILArray object.", e);
            }
            int[] indices = new int[size.Count];
            FillILArrayFromList<BaseT>(ref size, list, 0, ref type, ref m_data, 0, 1);
        }

        internal static void FillILArrayFromList<BaseT>(ref List<int> size, IronPython.Runtime.List list, int dimension, ref Type type, ref BaseT[] m_data, int index, int stride)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] is IronPython.Runtime.List)
                {
                    IronPython.Runtime.List newList = (IronPython.Runtime.List)list[i];
                    FillILArrayFromList<BaseT>(ref size, newList, dimension + 1, ref type, ref m_data, index, stride * size[dimension]);
                    index += stride;
                }
                else
                {
                    m_data[index] = (BaseT)Convert.ChangeType(list[i], typeof(BaseT));
                    index += stride;
                }
            }
        }

        /// <summary>
        /// helper function to prepare parameters for partial removal 
        /// </summary>
        /// <param name="range">object with index specification.May be of 
        /// type ILBaseArray[] with numeric arrays or a string array according 
        /// to the format of <see cref="ILNumerics.Storage.ILRange"/>. 
        /// </param>
        /// <param name="dimensionIdx">out parameter: number of dimension the indices to be removed lay in</param>
        /// <param name="indices">indices to be removed</param>
        /// <param name="dimensions">dimension structure, may be used if the array must be 
        /// reshaped <b>before</b> the removal.</param>
        /// <remarks>if range consists out of a range specification wich is smaller than 
        /// the actual dimension length of this array, the array must also be reshaped in order to remove 
        /// the data accordingly. This reshape proccess will <b>not</b> be done inside of this function! However 
        /// ther <c>dimension</c> value returned reflect the size of the array before removing and therefore
        /// may comfortable be used for reshaping the array.</remarks>
        /// <exception cref="ILNumerics.Exceptions.ILArgumentException">if <list type="bullet">
        /// <item>the length of range exceeds the dimensions of this array</item>
        /// <item>more or less than exactly one dimension of <c>range</c> was not null</item>
        /// <item>the type of range was invalid, or</item>
        /// <item>range is of type array of <see cref="ILNumerics.ILBaseArray"/>, but the elements are non numeric ILArray's</item>
        /// </list></exception>
        private void ExtractRemovalParameter(object[] range, out int dimensionIdx, out int[] indices, out ILDimension dimensions)
        {
            dimensionIdx = 0;
            indices = null;
            dimensions = null;
            int inDimCount = 0;
            //
            if (range.Length > m_dimensions.NumberOfDimensions)
                throw new ILArgumentException("Error removing: dimension specification exceeds matrix dimensions.");
            int specCount = 0;
            int tmp = 0;
            inDimCount = range.Length;
            //
            for (int i = 0; i < range.Length; i++)
            {
                if (range[i] is ILBaseArray)
                {
                    #region ILBaseArray input
                    ILBaseArray rng = (ILBaseArray)range[i];
                    if (rng != null && !rng.IsEmpty)
                    {
                        dimensionIdx = i;
                        if (specCount++ > 0)
                            throw new ILArgumentException("Error removing: only one dimension must be non-empty!");
                        if (false)
                        {
                        }
                        else if (rng is ILLogicalArray)
                        {
                            ILArray<double> ind = ILNumerics.BuiltInFunctions.ILMath.find((ILLogicalArray)rng);
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            #region HYCALPER LOOPSTART
                            /* !HC:TYPELIST:
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
</hycalper>
*/
                        }
                        else if (rng is /*!HC:inCls1*/ ILArray<double>)
                        {
                            /*!HC:inCls1*/
                            ILArray<double> ind = (/*!HC:inCls1*/ ILArray<double>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            #endregion HYCALPER LOOPEND
                            #region HYCALPER AUTO GENERATED CODE
                            // DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<fcomplex>)
                        {
                            ILArray<fcomplex> ind = (ILArray<fcomplex>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<complex>)
                        {
                            ILArray<complex> ind = (ILArray<complex>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<byte>)
                        {
                            ILArray<byte> ind = (ILArray<byte>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<char>)
                        {
                            ILArray<char> ind = (ILArray<char>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<UInt64>)
                        {
                            ILArray<UInt64> ind = (ILArray<UInt64>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<UInt32>)
                        {
                            ILArray<UInt32> ind = (ILArray<UInt32>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<UInt16>)
                        {
                            ILArray<UInt16> ind = (ILArray<UInt16>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<Int64>)
                        {
                            ILArray<Int64> ind = (ILArray<Int64>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<Int32>)
                        {
                            ILArray<Int32> ind = (ILArray<Int32>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<Int16>)
                        {
                            ILArray<Int16> ind = (ILArray<Int16>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }
                            /* !HC:TYPELIST:

                            */
                        }
                        else if (rng is ILArray<float>)
                        {
                            ILArray<float> ind = (ILArray<float>)rng;
                            tmp = ind.Dimensions.NumberOfElements;
                            indices = new int[tmp];
                            for (int p = 0; p < tmp; p++)
                            {
                                indices[p] = (int)ind.GetValue(p);
                            }

                            #endregion HYCALPER AUTO GENERATED CODE
                        }
                        else
                            throw new ILArgumentTypeException("error removing: dimensions specifier must be numeric type!");
                    }
                    if (indices == null)
                    {
                        dimensionIdx = 0;
                        dimensions = m_dimensions;
                        indices = new int[0] { };
                        return;
                    }
                    #endregion
                }
                else if (range[i] is Slice)
                {
                    #region Python slice input
                    Slice rng = (Slice)range[i];
                    if ((rng != null) && !(rng.start == null && rng.stop == null && rng.step == null))
                    {
                        dimensionIdx = i;
                        if (specCount++ > 0)
                            throw new ILArgumentException("Error removing: only one dimension must be non-empty!");
                        List<int> ids = new List<int>();
                        int start, ende, step;
                        if (rng.start == null) start = 0;
                            else start = (int)(rng.start);
                        if (rng.stop == null) ende = m_dimensions[i];
                            else ende = (int)(rng.stop) + 1;
                        if (rng.step == null) step = 1;
                            else step = (int)(rng.step);
                        try
                        {
                            for (int r = start; r < ende; r += step)
                            {
                                ids.Add(r);
                            }
                            indices = ids.ToArray();
                        }
                        catch (FormatException e)
                        {
                            throw new ILArgumentException("remove: invalid index in " + i.ToString() + "th dimension! (" + e.Message + ")");
                        }
                        if (indices == null)
                        {
                            dimensionIdx = 0;
                            dimensions = m_dimensions;
                            indices = new int[0] { };
                            return;
                        }
                    }
                    #endregion
                }
                else if (range is string[])
                {
                    #region string input
                    string rng = (string)range[i];
                    if (rng.Contains(";"))
                    {
                        throw new ILArgumentException("Error removing: ';' not valid");
                    }
                    if (rng != null && rng.Trim() != ":")
                    {
                        dimensionIdx = i;
                        if (specCount++ > 0)
                            throw new ILArgumentException("Error removing: only one dimension must be non-empty!");
                        rng = rng.Replace("end", (m_dimensions[i] - 1).ToString());
                        string[] tmpIdx = rng.Split(',');
                        List<int> ids = new List<int>();
                        try
                        {
                            for (int c = 0; c < tmpIdx.Length; c++)
                            {
                                string[] tmprng = tmpIdx[c].Split(':');
                                switch (tmprng.Length)
                                {
                                    case 1:
                                        // no range spec.
                                        ids.Add(int.Parse(tmprng[0].Trim()));
                                        break;
                                    case 2:
                                        // single range: spacing 1
                                        int start = int.Parse(tmprng[0].Trim());
                                        int ende = int.Parse(tmprng[1].Trim()) + 1;
                                        for (int r = start; r < ende; r++)
                                        {
                                            ids.Add(r);
                                        }
                                        break;
                                    case 3:
                                        // single range: spacing 1
                                        start = int.Parse(tmprng[0].Trim());
                                        ende = int.Parse(tmprng[2].Trim()) + 1;
                                        int step = int.Parse(tmprng[1].Trim());
                                        for (int r = start; r < ende; r += step)
                                        {
                                            ids.Add(r);
                                        }
                                        break;
                                }
                            }
                            indices = ids.ToArray();
                        }
                        catch (FormatException e)
                        {
                            throw new ILArgumentException("remove: invalid index in " + i.ToString() + "th dimension! Did you seperate dimensions by ';'? (" + e.Message + ")");
                        }
                    }
                    if (indices == null)
                    {
                        dimensionIdx = 0;
                        dimensions = m_dimensions;
                        indices = new int[0] { };
                        return;
                    }
                    #endregion
                }
                else
                {
                    throw new ILArgumentException("Invalid range specification. The type of indices specified is invalid. Remove failed.");
                }
            }
            // check if array must be reshaped
            int[] tmpDim = new int[(inDimCount > 1) ? inDimCount : 2];
            int pos = 0;
            while (pos < m_dimensions.NumberOfDimensions)
            {
                if (pos < inDimCount)
                    tmpDim[pos] = m_dimensions[pos];
                else
                {
                    int mult = 1;
                    int i = pos;
                    while (i < m_dimensions.NumberOfDimensions)
                    {
                        mult *= m_dimensions[i++];
                    }
                    tmpDim[pos - 1] *= mult;
                    break;
                }
                pos++;
            }
            // if only one dimension specified -> make row vector
            if (pos == 1)
            {
                tmpDim[1] = tmpDim[0];
                tmpDim[0] = 1;
                dimensionIdx = 1;
            }
            dimensions = new ILDimension(tmpDim);
        }
    }
    
    public static class PythonListHelper
    {
        public static void GetListDimensionsAndType(ref List<int> size, IronPython.Runtime.List list, ref Type type)
        {
            size.Add(list.Count);
            if (list[0] is IronPython.Runtime.List)
            {
                IronPython.Runtime.List newList = (IronPython.Runtime.List)list[0];
                GetListDimensionsAndType(ref size, newList, ref type);
            }
            else type = list[0].GetType();
        }

        public static bool CheckList(ref List<int> size, IronPython.Runtime.List list, int dimension, ref Type type)
        {
            bool passed = true;
            if (list.Count != size[dimension])
            {
                return false;
            }
            if (dimension < (size.Count - 1))
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i] is IronPython.Runtime.List)
                    {
                        IronPython.Runtime.List newList = (IronPython.Runtime.List)list[i];
                        passed = passed && CheckList(ref size, newList, dimension+1, ref type);
                    }
                    else
                    {
                        passed = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].GetType() != type)
                    {
                        // allow a mixture of integers and doubles, but set type to double
                        if ((type == typeof(Int32)) && (list[i].GetType() == typeof(Double)))
                        {
                            type = typeof(Double);
                        }
                        else if (!((type == typeof(Double)) && (list[i].GetType() == typeof(Int32))))
                        {   
                            passed = false;
                            break;
                        }
                    }
                }
            }
            return passed;
        }
    }
}

#endif