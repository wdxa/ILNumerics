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

        #region Reference management
        /// <summary>
        ///	Minimum number of dimensions for Reference storage objects.
        /// </summary>
        /// <remarks>
        /// This parameter influences all overloaded versions of the CreateReference members: 
        /// If the object requested (the reference specified by range and/or dimension shifts)
        /// is of less than MinimumRefDimensions non singleton dimensions, the 
        /// "reference" will be created as real copy, i.e. a ILFullArray an physical storage object. For 
        /// the defaut value of 2 this will result in an matrix object. For the current 
        /// implementation using referencing ILFullArray's for obejcts with less then 
        /// 2 non singleton dimensions would be of little use, since fast indexing requires them 
        /// to hold a copy of all dimension specifiers for an object. Therefore they would 
        /// consume at least half the memory and more performance for creating them then creating a real copy 
        /// as physical storage. Use this parameter to make ILNumerics.Net actually create 
        /// <b>copies</b> and not <b>references</b> of all storage objects with non singleton 
        /// dimensions less then MinimumRefDimensions.
        /// </remarks>
        public int MinimumRefDimensions {
            get {
                return m_minReferenceStorageDims; 
            }
            set {
                if (value < 2) 
                    throw new ILArgumentException("Number of dimensionss for reference arrays must be greater or equal 2!"); 
                m_minReferenceStorageDims = value; 
            }
        }
        private int m_minReferenceStorageDims = ILNumerics.Settings.ILSettings.MinimumRefDimensions;
        /// <summary>
        /// reference counter
        /// </summary>
        /// <remarks><para>The member counts the references connected to any internal array
        /// based on the hash code of the storage array. The systems hash code 
        /// for the array is used as key. Upon creation of any ILArray object
        /// the array is placed as new entry into the dictionary with its hash code as 
        /// key. Upon creation of any references the value is beeing increased. At 
        /// finalization time and on detaching as well as on calling the Dispose() member the value gets decreased. </para>
        /// <para> This reference counter is mainly used for determining the writable state 
        /// of the storage. A storage is writable (sets IsReadonly == false), if exactly 
        /// one reference to it exist. </para>
        /// </remarks>
        private static Dictionary<int, int> References = new Dictionary<int, int>(100);
        /// <summary>
        /// Sets the detaching bahavior for referencing storages of this type
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
        /// DetachOnWrite (default) - Referencing storages will automatically detach 
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
        /// <item>DetachSave - This value acts like 'DetachOnWrite' except a storage will not 
        /// be detached, if it is the only reference to the underlying physical storage. 
        /// </item>
        /// </list>
        /// Special attention is to be made for altering ranges on reference storages. There are 
        /// cases where setting a value may alter other elements as well. this is true
        /// for elements "pointing" to the same physical array element. If you dont agree with 
        /// that behavior, set this switch to 'DetachAlways' so you wont have to worry about 
        /// storages beeing references anymore. This behavior may be known as similar 
        /// to other mathematical engines (like Matlab f.e.).
        /// 
        /// This flag is set to the global value in the ILSettings class, which points to 'DetachOnWrite' by default.</remarks>
        public static ILDetachingBehavior DetachReferences =  ILNumerics.Settings.ILSettings.DetachReferences;

        /// <summary>
        /// Increase reference counter for the key (hash code)
        /// </summary>
        protected void IncreaseReference() {
            lock (References) {
                int key = m_data.GetHashCode(); 
                if (References.ContainsKey(key))
                    References[key] = References[key] + 1;
                else {
                    References.Add(key, 1);
                    //Console.Out.WriteLine("Added Reference: " + key);
                }
            }
        }
        /// <summary>
        /// Decrease reference counter for this array
        /// </summary>
        protected void DecreaseReference() {
            lock (References) {
                int key = m_data.GetHashCode(); 
                if (References.ContainsKey(key)) {
                    if (References[key] == 1) {
                        References.Remove(key);
                        ILMemoryPool.Pool.RegisterObject(m_data);
                        return;
                    }
                    References[key] = References[key] - 1;
                } 
            }
        }
        /// <summary>
        /// query number of references for the current instance of ILArray
        /// </summary>
        /// <returns>Number of object pointing to the current instance.</returns>
        public int GetNumberOfReferences() {
            return GetNumberOfReferences(m_data);
        }
        /// <summary>
        /// query number of references for a specific array
        /// </summary>
        /// <returns>number of objects pointing to an ILArray's storage.</returns>
        /// <param name="data">storage array for an ILArray</param>
        /// <returns>Number of references currently existing for this array</returns>
        /// <remarks>This function is for internal useage only and is not intended to 
        /// be used directly! Use <see cref="ILNumerics.ILArray&lt;T&gt;.GetNumberOfReferences()"/> instead!</remarks>
        internal static int GetNumberOfReferences(BaseT[] data) {
            lock (References) {
                if (References.ContainsKey(data.GetHashCode()))
                    return References[data.GetHashCode()];
                else
                    return 0;
            }
        }
        /// <summary>
        ///	Returns true if this object cannot be altered without detaching
        /// </summary>
        /// <returns>
        /// True if elements of this storage cannot be altered without detaching, false 
        /// if they can be written.
        /// </returns>
        /// <remarks>
        /// <para>Upon creation every ILArray starts with a reference counter 
        /// value of 1. This is due to the physical storage will always lay within 
        /// its own ILArray container. Therfore it is writeable by that container. 
        /// If another reference was created, the reference counter will be increased, 
        /// marking the storage as readonly. If one of the objects (ILArray container 
        /// or referencing storage) is beeing detached, the storage becomes writable 
        /// again. In this situation, even a reference storage may alter the values 
        /// of the underlying solid ILArray.</para> 
        /// <para>Usually you dont have to handle with 
        /// the reference counter. It is managed automatically. This member is queried 
        /// by all functions attempting write access to an storage due to decide, if 
        /// the storage to write to must be detached before writing to it.</para></remarks>
        public bool IsReadonly() {
            lock(References) {
                int key = m_data.GetHashCode(); 
                if (References.ContainsKey(key))
                    return References[key] != 1;
                else
                    return true;
            }
        }

        #endregion

    }
}
