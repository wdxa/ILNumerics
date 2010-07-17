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
using ILNumerics;
using ILNumerics.Misc;
using ILNumerics.Exceptions;
using Slice = IronPython.Runtime.Slice;
namespace ILNumerics.Storage
{
	/// <summary>
	/// ILRange specify the dimensions for an ILArray object if it is a reference.
	/// </summary>
	/// <description>ILRange is used to specify the parts of the original dimensions
	/// the ILArray objects referes to if it is a reference to another ILArray object. 
	/// ILRange objects do not know about a 'maximum size'. They dont know the dimensions of the objects,
	/// they get applied to. Therefore the 'colon' specifier will get stored and evaluated at the 
	/// time, the range gets assigned to an ILArray Object. </description>
    public partial class ILRange
    {
        //TODO Add string and ILBaseArray to list of indexing objects
        /// <summary>
        /// Creates ILRange from object array containing ints and Slices.
        /// </summary>
        /// <param name="dims">Dimension specification</param>
        /// <param name="rng">Array with range specification</param>
        /// <param name="side">Specify if this range is applied to left side or right side expressions</param>
        public ILRange(ILDimension dims, RangeSide side, params object[] rng)
        {
            // objects can be slices or integers
            if (rng.Length < 1)
            {
                Resize(0);
                return;
            }
            // expand string range definition to multidimensional array m_range
            /* 
             * Note: by specifying a range definition for fewer dimensions than
             * dimensions in dims, subsequent trailing dimensions will be 
             * merged and added to the last dimension of the range. The 'reshaped'
             * dimension is than considered for output. The decision as to whether the 
             * dimension must be expanded is determined by the limits of those
             * output dimensions.
             */
            int start, ende, step;
            int rngLenUse = rng.Length;
            int tmpValue;
            Resize(rngLenUse);
            #region prepare out dimension length
            int[] outDims = new int[m_nrDims];
            if (rng.Length == 1)
            {
                outDims[0] = dims.NumberOfElements;
            }
            else
            {
                if (rng.Length <= dims.NumberOfDimensions)
                {
                    for (start = 0; start < m_nrDims; start++)
                    {
                        outDims[start] = dims[start];
                    }
                    for (; start < dims.NumberOfDimensions; start++)
                    {
                        outDims[m_nrDims - 1] *= dims[start];
                    }
                }
                else
                {
                    for (start = 0; start < dims.NumberOfDimensions; start++)
                    {
                        outDims[start] = dims[start];
                    }
                    for (; start < rng.Length; start++)
                    {
                        outDims[start] = 1;
                    }
                }
            }
            #endregion
            m_numberOfElements = 1;
            RegularSpacedList idxList = new RegularSpacedList(2);
            for (int d = 0; d < rngLenUse; d++)
            {
                int dimsd = outDims[d];
                idxList.Clear();
                if (rng[d] is int)
                {
                    // single number specified 
                    int singleIndex = (int)(rng[d]);
                    if (singleIndex < 0)
                        throw new ILArgumentException("invalid index for dimension " + d.ToString());
                    if (singleIndex >= dimsd)
                    {
                        if (side == RangeSide.Right)
                            throw new ILArgumentException("invalid index for dimension " + d.ToString());
                        else
                        {
                            Expanding = true;
                            if (m_expandDimensions[d] <= singleIndex)
                                m_expandDimensions[d] = singleIndex + 1;
                        }
                    }
                    idxList.Add(singleIndex);
                }
                else if (rng[d] is Slice)
                {
                    if (((Slice)rng[d]).start == null && ((Slice)rng[d]).stop == null && ((Slice)rng[d]).step == null)
                    {
                        #region full dimension
                        m_range[d] = new int[1] { -(dimsd - 1) };
                        m_numberOfElements *= dimsd;
                        m_regularSpaced[d] = 1;
                        if (dimsd > 1)
                            m_nonSingletonDimensions++;
                        continue;
                        #endregion
                    }
                    else
                    {
                        if (((Slice)rng[d]).step == null)
                        {
                            if (((Slice)rng[d]).start == null) start = 0;
                                else start = (int)(((Slice)rng[d]).start);
                            if (((Slice)rng[d]).stop == null) ende = dimsd - 1;
                                else ende = (int)(((Slice)rng[d]).stop);
                            step = (ende >= start) ? 1 : -1;
                        }
                        else 
                        {
                            step = (int)(((Slice)rng[d]).step); 
                            if (step > 0)
                            {
                                if (((Slice)rng[d]).start == null) start = 0;
                                    else start = (int)(((Slice)rng[d]).start);
                                if (((Slice)rng[d]).stop == null) ende = dimsd - 1;
                                    else ende = (int)(((Slice)rng[d]).stop);
                            }
                            else if (step < 0)
                            {
                                if (((Slice)rng[d]).start == null) start = dimsd - 1;
                                    else start = (int)(((Slice)rng[d]).start);
                                if (((Slice)rng[d]).stop == null) ende = 0;
                                    else ende = (int)(((Slice)rng[d]).stop);
                            }
                            else throw new ILArgumentException("Invalid index for dimension " + d.ToString() + ".");
                        }

                        if (start < 0 || ende < 0) throw new ILArgumentException("Invalid index for dimension " + d.ToString() + ".");
                        if (start >= dimsd || ende >= dimsd)
                        {
                            if (side == RangeSide.Right)
                                throw new ILArgumentException("Invalid index for dimension " + d.ToString() + ".");
                            else
                            {
                                Expanding = true;
                                int tmpVal = (start > ende) ? start : ende;
                                if (m_expandDimensions[d] <= tmpVal)
                                    m_expandDimensions[d] = tmpVal + 1;
                            }
                        }
                        if (start <= ende)
                        {
                            if (step > 0)
                            {
                                for (int t = start; t <= ende; t += step)
                                {
                                    idxList.Add(t);
                                }
                            }
                        }
                        else
                        {
                            if (step < 0)
                            {
                                for (int t = start; t >= ende; t += step)
                                {
                                    idxList.Add(t);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // If ILBaseArray is used to specify a dimension, all dimensions must be specified by ILBaseArrays
                    // Same for strings
                    // Cannot mix and match except Slices and integers
                    throw new ILArgumentException("Cannot combine other indexers with integers and Slices");
                }
                m_range[d] = (int[])idxList.ToArray();
                int idxlistcount = idxList.Count;
                m_numberOfElements *= idxlistcount;
                m_regularSpaced[d] = (idxList.IsRegularSpaced) ? idxList.RegularSpacing : int.MinValue;
                if (idxlistcount > 1)
                    m_nonSingletonDimensions++; 
            }
        }
    }
}

#endif