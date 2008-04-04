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
using ILNumerics; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Settings {
    /// <summary>
    /// General settings for ILNumerics.Net classes
    /// </summary>
    public sealed class ILSettings {

        /// <summary>
        /// Sets the detaching behavior for referencing storages 
        /// </summary>
        /// <remarks> 
        /// This flag controls, how ILArray objects react on write access.
        /// Possible values are one of the enum values of ILArray.DetachingBehavior:
        /// <list>
        /// <item>
        /// DetachNever - if used, ILArray's will never automatically detach. This can 
        /// lead to situations, where altering the elements of one storage also change 
        /// the elements of another storage, if the second is referencing the same physical
        /// storage array elements. 
        /// </item>
        /// <item>
        /// DetachOnWrite - Referencing storages will automatically detach 
        /// themself before attempting to alter any values used. The results are self 
        /// dereferencing storages which act to the outside world, like they would 
        /// all consist out of physical storages, but internally save memory by not creating 
        /// any real copies of arrays as long as it is not neccessary. 
        /// </item>
        /// <item>
        /// DetachAlways - Attempts to create a reference of an existing storage will result 
        /// in copying the values. This is the way other mathematical engines handle 
        /// their storages (f.e. Matlab). It consumes more memory, but will most probably 
        /// lead to increased performance for large computations, since physical storages
        /// are optimized for faster element access.
        /// </item>
        /// <item>DetachSave (default) - This value acts like 'DetachOnWrite' except a storage will not 
        /// be detached, if it is the only reference to the underlying physical storage. 
        /// </item>
        /// </list>
        /// Special attention is to be made for altering ranges on reference storages. There are 
        /// cases where setting a value may alter other elements as well. this is true
        /// for elements "pointing" to the same physical array element. If you dont agree with 
        /// that behavior, set this switch to 'DetachAlways' so you wont have to worry about 
        /// storages beeing references anymore. This behavior may be known as similar 
        /// to other mathematical engines (like MATLAB f.e.).
        /// 
        /// This flag is set to 'DetachSave' by default.</remarks>
        public static ILDetachingBehavior DetachReferences = ILDetachingBehavior.DetachSave;
        /// <summary>
        ///	Minimum number of dimensions for Reference storage objects.
        /// </summary>
        /// <remarks>
        /// This parameter influences all overloaded versions of the CreateReference members and subarray creation: 
        /// If the object requested (the reference specified by range and/or dimension shifts)
        /// is of less than MinimumRefDimensions non singleton dimensions, the 
        /// "reference" will be created as real copy, i.e. a solid ILArray an physical storage object. For 
        /// the defaut value of 2 this will result in an matrix object. For the current 
        /// implementation using referencing for objects with less then 
        /// 2 non singleton dimensions would be of little use, since fast indexing requires them 
        /// to hold a copy of all dimension specifiers for an object. Therefore they would 
        /// consume at least half the memory and more performance for creating them then creating a real copy 
        /// as physical storage. Use this parameter to make ILNumerics.Net actually create 
        /// <b>copies</b> and not <b>references</b> of all storage objects with non singleton 
        /// dimensions less then MinimumRefDimensions.
        /// </remarks>
        public static int MinimumRefDimensions {
            get {
                return m_ILMinimumRefDimensions; 
            }
            set {
                if (value < 2) 
                    throw new ILArgumentException("Number of dimensionss for reference arrays must be greater or equal 2!"); 
                m_ILMinimumRefDimensions = value; 
            }
        }
        private static int m_ILMinimumRefDimensions = 2;
    }
}
