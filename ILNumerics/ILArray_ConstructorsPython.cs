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
using ILNumerics.Storage;
using ILNumerics.Misc;
using ILNumerics.Exceptions;

namespace ILNumerics
{

    public partial class ILArray<BaseT> : ILBaseArray<BaseT>
    {
        #region Subarray interface
        /// <summary>
        ///	Subarray to this array + dimension shift
        /// </summary>
        /// <param name="range">String specifying the ranges to create subarray from</param>
        /// <param name="shift">Number of dimensions to shift the result.</param>
        /// <returns>shifted subarray as specified</returns>
        public ILBaseArray<BaseT> Subarray(int shift, params object[] range)
        {
            if (shift < 1)
                return Subarray(range);
            if (range == null)
                return ShiftDimensions(shift);
            ILRange rng = new ILRange(m_dimensions, RangeSide.Right, range);
            if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0, 0);
            if (rng.nonSingletonDimensions >= MinimumRefDimensions)
            {
                // create reference 
                if (IsReference)
                    return CreateReferenceSubarrayFromReferenceShifted((short)shift, rng);
                else
                    return CreateReferenceSubarrayFromPhysicalShifted((short)shift, rng);
            }
            else
            {
                // create physical
                if (IsReference)
                    return CreatePhysicalSubarrayFromReferenceShifted((short)shift, rng);
                else
                    return CreatePhysicalSubarrayFromPhysicalShifted((short)shift, rng);
            }
        }

        /// <summary>
        ///	Subarray from this array
        /// </summary>
        /// <param name="range">Strings specifying the ranges to create subarray from</param>
        /// <returns>subarray as specified</returns>
        public ILBaseArray<BaseT> Subarray(params object[] range)
        {
            if (range == null)
                return ShiftDimensions(0);
            ILRange rng = new ILRange(m_dimensions, RangeSide.Right, range);
            if (rng.NumberOfElements == 0) return ILArray<BaseT>.empty(0, 0);
            if (rng.nonSingletonDimensions >= MinimumRefDimensions)
            {
                // create reference 
                if (IsReference)
                    return CreateReferenceSubarrayFromReference(rng);
                else
                    return CreateReferenceSubarrayFromPhysical(rng);
            }
            else
            {
                // create physical
                if (IsReference)
                    return CreatePhysicalSubarrayFromReference(rng);
                else
                    return CreatePhysicalSubarrayFromPhysical(rng);
            }
        }
        #endregion

    }
}

#endif 