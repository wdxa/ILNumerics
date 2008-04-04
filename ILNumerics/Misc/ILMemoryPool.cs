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
using System.Collections; 
using System.Collections.Generic;
using System.Text;
using ILNumerics.Exceptions; 

namespace ILNumerics.Misc {
    /// <summary>
    /// Memory pool serving as temporary storage for System.Array objects
    /// </summary>
    /// <remarks>The pool reduces the pressure on the systems memory done by larger objects.
    /// <para>Arrays created in ILNumerics.Net will try to reclaim its memory from this pool. If attempt fails, the memory is gathered from the managed heap normally.</para>
    /// <para>Disposed array objects register their underlying System.Array in the pool for later reusing. The process is triggered by the garbage collector or by the user calling the Dispose function available for all ILArray objects.</para></remarks>
    public class ILMemoryPool {
        /// <summary>
        /// The only global ILMemoryPool instance
        /// </summary>
        public static readonly ILMemoryPool Pool = new ILMemoryPool(100, 200); 
        
        private SortedDictionary<int,List<Array>> m_pool; 
        private List<Array> m_livetimes;
        private long m_maxBytes; 
        private long m_curBytes; 
        private long m_minArrLength;
        private long m_reclaimedBytesCount;

        /// <summary>
        /// Number of reclaimed bytes since the pool exists
        /// </summary>
        /// <remarks>The counter will be reset by calls to <see cref="ILNumerics.Misc.ILMemoryPool.Reset(int, int)"/></remarks>
        public long ReclaimedBytesCount {
            get { return m_reclaimedBytesCount; }
        }
        private long m_reclaimedObjectsCount;
        /// <summary>
        /// Number of reclaimed objects since the pool exists
        /// </summary>
        /// <remarks>The counter will be reset by calls to <see cref="ILNumerics.Misc.ILMemoryPool.Reset(int, int)"/></remarks>
        public long ReclaimedObjectsCount {
            get { return m_reclaimedObjectsCount; }
        } 
        
        private ILMemoryPool(int MinArrayLength, int PoolSizeMB) {
            m_maxBytes = PoolSizeMB * 1024 * 1024; 
            m_minArrLength = MinArrayLength; 
            m_livetimes = new List<Array>(500); 
            m_pool = new SortedDictionary<int,List<Array>>(); 
        }
        /// <summary>
        /// Reset &amp; reconfigure the pool 
        /// </summary>
        /// <param name="MinArrayLength">Minimum length for array object to be stored inside the pool</param>
        /// <param name="PoolSizeMB">Overall size the memory pool consumes at most</param>
        /// <remarks>Reset will dispose all objects currently hold in the pool!</remarks>
        public void Reset ( int MinArrayLength, int PoolSizeMB ) {
            lock (this) {
                m_maxBytes = PoolSizeMB * 1024 * 1024; 
                m_minArrLength = MinArrayLength; 
                m_livetimes = new List<Array>(500); 
                m_pool = new SortedDictionary<int,List<Array>>();
                m_curBytes = 0; 
                m_reclaimedBytesCount = 0; 
                m_reclaimedObjectsCount = 0; 
            }
        }
        /// <summary>
        /// Dispose all object currently hold in the pool 
        /// </summary>
        /// <remarks>The pool get cleared and continues working with the same parameters after the call has finished. </remarks>
        public void DisposeContent() {
            lock (this) {
                m_livetimes.Clear(); 
                m_pool.Clear(); 
                m_curBytes = 0;
            }
        }
        /// <summary>
        /// Register an array object of value type in the pool
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="arr">value type array</param>
        /// <remarks><para>In order to be stored in the pool, the array must meet the minimum array length and must fit into the global pool size.
        /// Null objects or empty arrays or array not suitable for the pool will be silently ignored.</para>
        /// <para>If the new array is too large to fit into the remaining pool space, the oldest objects in the pool will be released until the object can get registered.</para></remarks>
        public void RegisterObject<T>(T[] arr) {
            if (arr == null || arr.Length == 0 || arr.Length < m_minArrLength)
                return; 
            if (!arr.GetType().GetElementType().IsValueType)
                return; 
            // determine size of new array
            long newSize = arr.Length * System.Runtime.InteropServices.Marshal.SizeOf(arr[0]);
            if (newSize >= m_maxBytes) return; 
            lock (this) {
                // clean up to free space for new array 
                while (m_curBytes + newSize > m_maxBytes) {
                    RemoveOldestObject();
                }
                // add the array to the pool 
                List<Array> inPool; 
                if (m_pool.TryGetValue(arr.Length, out inPool)) {
                    // append to pool 
                    inPool.Add(arr);
                } else {
                    // add new length to pool 
                    inPool = new List<Array>(); 
                    inPool.Add(arr); 
                    m_pool.Add(arr.Length,inPool);     
                }
                m_curBytes += newSize;
                // AddMostRecentObject
                m_livetimes.Insert(m_livetimes.Count, arr);
            }
        }

        private void RemoveOldestObject() {
            Array oldest = m_livetimes[0];
            // remove from pool - the objects is expected to exist in the pool still!
            if (RemoveFromPool(oldest)) { 
                m_curBytes -= (oldest.Length * System.Runtime.InteropServices.Marshal.SizeOf(oldest.GetValue(0))); 
            }
        }
        /// <summary>
        /// Request a System.Array instance
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="length">length of array</param>
        /// <returns>System.Array - either from the pool or a newly created array</returns>
        /// <remarks><para>If a suitable System.Array was found in the pool, this object is returned. Otherwise a new array is created.</para>
        /// <para>There is no way of determining, if the array was recalimed from pool or newly created! If you must be sure, the element values are set to default(T), call the overloaded version <see cref="ILNumerics.Misc.ILMemoryPool.New&lt;T&gt;(int, bool, out bool)"/> instead!</para>
        /// <para>If a new array could not get created due to an OutOfMemoryException, a garbage collection is triggered and the array is again requested from the pool. If this failes again, another attempt to create the array is done. Exceptions may thrown from this last attempt are not catched and transported back to the callee.</para></remarks>
        public T[] New<T>(int length) {
            T[] ret = null; 
            // try to find a suitable object in the pool first 
            if (length >= m_minArrLength && (ret = GetFromPool<T>(length)) != null) {
                return ret;
            }
            // must create a new one
            try {
                ret = new T[length]; 
            } catch (OutOfMemoryException) {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                if (length >= m_minArrLength && (ret = GetFromPool<T>(length)) != null) {
                    return ret; 
                }
            } 
            if (ret == null) {
                ret = new T[length]; 
            } 
            return ret; 
        }
        
        /// <summary>
        /// Request a System.Array instance and optionally clear the array
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="length">length of array</param>
        /// <param name="clear">if true, the elements of the array returned are set to default(T).</param>
        /// <param name="iscleared">out paramater determining if the array returned has been cleared</param>
        /// <returns>System.Array - either from the pool or a newly created array</returns>
        /// <remarks><para>If a suitable System.Array was found in the pool, this object is returned. Otherwise a new array is created.</para>
        /// <para>If the <paramref name="clear">clear </paramref> parameter was set to false, the <paramref name="iscleared">iscleared</paramref> parameter can be used to determine, if the object was returnd from the pool and may need extra clearing.</para>
        /// <para>If a new array could not get created due to an OutOfMemoryException, a garbage collection is triggered and the array is again requested from the pool. If this failes again, another attempt to create the array is done. Exceptions eventually thrown from this last attempt are not catched and transported back to the callee.</para></remarks>
        public T[] New<T>(int length, bool clear, out bool iscleared) {
            T[] ret = null; 
            // try to find a suitable object in the pool first 
            if (length >= m_minArrLength && (ret = GetFromPool<T>(length)) != null) {
                if (clear) {
                    for (int i = 0; i < length; i++) {
                        ret[i] = default(T); 
                    }
                    iscleared = true; 
                } else {
                    iscleared = false; 
                }
                return ret;
            }
            // must create a new one
            try {
                ret = new T[length]; 
            } catch (OutOfMemoryException) {
                System.GC.Collect(); 
                System.GC.WaitForPendingFinalizers();
                if (length >= m_minArrLength && (ret = GetFromPool<T>(length)) != null) {
                    if (clear) {
                        for (int i = 0; i < length; i++) {
                            ret[i] = default(T); 
                        }
                        iscleared = true; 
                    } else {
                        iscleared = false; 
                    }
                    return ret;
                }
            } 
            if (ret == null) {
                ret = new T[length]; 
            } 
            iscleared = true; 
            return ret; 
        }

        private bool RemoveFromPool(Array arr) {
            List<Array> inPool; 
            if (m_pool.TryGetValue(arr.Length,out inPool)) {  
                if (!inPool.Remove(arr)) 
                    return false;
                m_livetimes.Remove(arr);
                if (inPool.Count == 0) {
                    m_pool.Remove(arr.Length); 
                }
                return true;
            } 
            return false; 
        }

        private T[] GetFromPool<T>(int length) {
            List<Array> inPool; 
            lock (this) {
                if (m_pool.TryGetValue(length,out inPool)) {
                    foreach(Array arr in inPool) {
                        if (arr is T[]) { 
                            inPool.Remove(arr); 
                            m_livetimes.Remove(arr); 
                            int newSize = (arr.Length * System.Runtime.InteropServices.Marshal.SizeOf(arr.GetValue(0)));
                            m_curBytes -= newSize;
                            if (inPool.Count == 0) {
                                m_pool.Remove(length); 
                            }
                            m_reclaimedObjectsCount += 1; 
                            m_reclaimedBytesCount += newSize; 
                            return (T[])arr;  
                        }
                    }
                }
            }
            return null; 
        }
        /// <summary>
        /// Give infos about pool state, optionally reset counters
        /// </summary>
        /// <param name="shortVersion">true: abbreviate infos to: current MB in Pool, reclaimed MB for livetime, reclaimed objects for livetime. False: give full info (see below)</param>
        /// <param name="reset">true: reset internal counter for reclaimed objects/ - bytes</param>
        /// <returns>infos about current pool state</returns>
        public string Info(bool shortVersion, bool reset) {
            if (shortVersion) {
                string s = String.Format("CurMB: {0}| CurObj: {1}| ReclMB: {2}| ReclObj: {3}",m_curBytes/1024/1024,countObj(),m_reclaimedBytesCount/1024/1024,m_reclaimedObjectsCount); 
                if (reset) {
                    m_reclaimedBytesCount = 0; 
                    m_reclaimedObjectsCount = 0; 
                }
                return s; 
            } else {
                StringBuilder sb = new StringBuilder(); 
                sb.Append("ILMemoryPool - "); 
                sb.Append(DateTime.Now.ToLongTimeString() + Environment.NewLine);
                string tmp; 
                lock (this) {
                    sb.Append(String.Format("CurMB: {0}| CurObj: {1}| ReclMB: {2}| ReclObj: {3}",m_curBytes/1024/1024,countObj(),m_reclaimedBytesCount/1024/1024,m_reclaimedObjectsCount) + Environment.NewLine); 
                    foreach (KeyValuePair<int,List<Array>> item in m_pool) {
                        sb.Append(item.Key + ": "); 
                        foreach(Array a in item.Value) {
                            tmp = a.GetType().GetElementType().Name; 
                            if (char.IsNumber(tmp[tmp.Length-1])) {
                                tmp = new String(new char[]{tmp[0], tmp[tmp.Length-1]}); 
                            } else {
                                tmp = tmp.Substring(0,2);
                            }
                            sb.Append(tmp); 
                            sb.Append(" "); 
                        }
                        sb.Append(Environment.NewLine); 
                    }
                    if (reset) {
                        m_reclaimedBytesCount = 0; 
                        m_reclaimedObjectsCount = 0; 
                    }
                }
                return sb.ToString(); 
            }
        }
        
        /// <summary>
        /// Give extended infos about pool state
        /// </summary>
        /// <returns>Full info about current and reclaimed pool objects</returns>
        /// <remarks>For short version infos use the overloaded version <see cref="ILNumerics.Misc.ILMemoryPool.Info(bool)"/></remarks>
        public string Info() {
            return Info(false, false); 
        }

        /// <summary>
        /// Give infos about pool state, optionally reset counters
        /// </summary>
        /// <param name="shortVersion">true: abbreviate infos to: current MB in Pool, reclaimed MB for livetime, reclaimed objects for livetime. False: give full info (see below)</param>
        /// <returns>infos about current pool state</returns>
        public string Info(bool shortVersion) {
            return Info(shortVersion, false); 
        }

        private int countObj() {
            int ret = 0; 
            foreach (KeyValuePair<int,List<Array>> item in m_pool) {
                foreach(Array a in item.Value) {
                    ret ++; 
                }
            }
            return ret; 
        }

        /// <summary>
        /// Collect all pending objects waiting for garbage cleaning and finalization
        /// </summary>
        /// <param name="generations">collect objects of given generations number only</param>
        /// <remarks>This function will return, if a garbage collector run and all subsequent finalizers has been completed.
        /// <para>After the function returns, all pending <code>ILArray</code>s not referenced from anywhere will have been placed 
        /// into the pool for reusement.</para></remarks>
        public void Collect(int generations) {
            System.GC.Collect(generations); 
            System.GC.WaitForPendingFinalizers(); 
        }

        /// <summary>
        /// Collect all pending objects waiting for garbage cleaning and finalization
        /// </summary>
        /// <remarks>This function will return, if a garbage collector run and all subsequent 
        /// finalizers has been completed.
        /// <para>After the function returns, all pending <code>ILArray</code>s 
        /// not referenced from anywhere will have been placed 
        /// into the pool for reusement. Therefore this function should only be called, 
        /// in order to prepare the pool directly <b>before</b> requesting large amounts of memory. 
        /// </para></remarks>
        public void Collect() {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers(); 
        }
    }
}
