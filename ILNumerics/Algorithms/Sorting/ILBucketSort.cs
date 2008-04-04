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
using System.Windows.Forms; 
using ILNumerics.Exceptions; 
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Misc; 

namespace ILNumerics.Algorithms {

    /// <summary>
    /// Bucket sort algorithm (for internal use)
    /// </summary>
    /// <remarks>This class is not intended to be used directly. Sorting functionality is supplied by <see cref="ILMath.sort(ILArray{Double})"/></remarks>
    public class ILBucketSort {
        /// <summary>
        /// sort method for bucket sorts
        /// </summary>
        public enum SortMethod {
            /// <summary>
            /// constant length
            /// </summary>
            ConstantLength,
            /// <summary>
            /// variable length
            /// </summary>
            VariableLenth
        }

        /// <summary>
        /// Bucket sort algorithm 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="indices">return corresponding source element indices</param>
        /// <param name="mapper"></param>
        /// <param name="method"></param>
        public static ILQueueList<ElementType,IndexType> BucketSort<ElementType,SubelementType,IndexType> (
                                            IEnumerable<ElementType> input,
                                            IEnumerable<IndexType> indices,
                                            ILKeyMapper<ElementType,SubelementType> mapper,
                                            SortMethod method) {
            if (mapper == null) 
                throw new ILInvalidOperationException("ILBucketSort: key mapper must not be null!");
            if (input == null) {
                return new ILQueueList<ElementType,IndexType>(); 
            }
            // do the sort now
            switch (method) {
                case SortMethod.VariableLenth: 
                    return bucketSort_variableLength<ElementType,SubelementType,IndexType>(input,mapper); 
                case SortMethod.ConstantLength:
                    if (indices != null) 
                        return bucketSort_constantLength(input,indices,mapper);
                    else 
                        return bucketSort_constantLength<ElementType,SubelementType,IndexType>(input,mapper);
                default: 
                    throw new ILArgumentException("ILBucketSort: unknown sort method specified."); 
            }
        }
       
        private static ILQueueList<ElementType,IndexType> 
            bucketSort_variableLength<ElementType, SubelementType,IndexType>(
                                    IEnumerable<ElementType> input, 
                                    ILKeyMapper<ElementType, SubelementType> mapper) {
            ILQueueList<ElementType,IndexType> ret;
            int m = mapper.NumberOfKeys; 
            ILQueueList<ElementType,IndexType>[] buckets = new ILQueueList<ElementType,IndexType>[m]; 
            ILQueueList<ElementType,IndexType> Q = new ILQueueList<ElementType,IndexType>(); 
            IEnumerable<ElementType> inp = input;

            #region compute lmax
            int maxLen = 0, tmp = 0;
            foreach (ElementType elem in inp) {
                tmp = mapper.SubelementsCount( elem );  
                if (tmp > maxLen)
                    maxLen = tmp;
            }
            #endregion
            #region create Lengths array
            ILQueueList<ElementType,IndexType>[] Lengths = new ILQueueList<ElementType,IndexType>[maxLen]; 
            foreach (ElementType elem in inp) {
                int len = mapper.SubelementsCount (elem) - 1; 
                if (Lengths[len] == null) {
                    Lengths[len] = new ILQueueList<ElementType,IndexType>(); 
                }
                Lengths[len].Enqueue(elem);
            }
            #endregion
            #region create bucket indices for each position: Noempty array
            ILQueueList<int,byte>[] Noempty = new ILQueueList<int,byte>[maxLen];
            ILLogicalArray alreadyFound = new ILLogicalArray(maxLen,m); 
            byte tr = (byte)1; 
            foreach (ElementType s in inp) {
                for (int l = mapper.SubelementsCount(s); l --> 0; ) {
                    int hpos = mapper.Map(s,l,0); 
                    if (alreadyFound.GetValue(l,hpos) == 0) {
                        alreadyFound.SetValue(tr,l,hpos); 
                        if (Noempty[l] == null) {
                            // create list and init with new value
                            Noempty[l] = new ILQueueList<int,byte>(); 
                        } 
                        Noempty[l].Enqueue(hpos);
                    }
                }
            }
            alreadyFound.Dispose(); 
            for (int i = 0; i < maxLen; i++) {
                // sort lists for each length
                Noempty[i] = bucketSort_constantLength<int,int,byte>(Noempty[i],new ILIntLimitedKeyMapper(m));
            }
            #endregion
            #region sort
            ILListItem<ElementType,IndexType> curElement;
            for (int l = maxLen; l-->0; ) {
                // sort Length[l] list
                if (Lengths[l] != null) {
                    Q.AddToStart(Lengths[l]); 
                }
                // sort from last sorting loop (l+1)
                while (Q.Count > 0) {
                    curElement = Q.Dequeue(); 
                    int hpos = mapper.Map(curElement.Data,l,0); 
                    if (buckets[hpos] == null) {
                        buckets[hpos] = new ILQueueList<ElementType,IndexType>();  
                    } 
                    buckets[hpos].Enqueue(curElement); 
                }
                // collect queues
                foreach (int c in Noempty[l]) {
                    Q.Enqueue(buckets[c]); 
                    buckets[c].Clear(); 
                }
            }
            #endregion
            return Q; 
        }
        internal static ILQueueList<ElementType,IndexType> 
            bucketSort_constantLength<ElementType,SubelementType,IndexType>(
                                    IEnumerable<ElementType> input,
                                    ILKeyMapper<ElementType,SubelementType> mapper) {
            int m = mapper.NumberOfKeys;
            int tmp = 0; 
            ILQueueList<ElementType,IndexType>[] buckets = new ILQueueList<ElementType,IndexType>[m];
            ILQueueList<ElementType,IndexType> Q = new ILQueueList<ElementType,IndexType>(); 
            // find longest element 
            int maxLen = 0;
            foreach (ElementType elem in input) {
                tmp = mapper.SubelementsCount( elem );  
                if (tmp > maxLen)
                    maxLen = tmp;
            }
            // sort into buckets 
            tmp = 0; 
            for (int k = maxLen; k-- > 0; ) {
                // walk along the input 
                if (k == maxLen - 1) {
                    foreach (ElementType elem in input) {
                        // put current into bucket
                        int bpos = mapper.Map(elem,k,0);
                        if (buckets[bpos] == null) {
                            // must create list first
                            buckets[bpos] = new ILQueueList<ElementType,IndexType>();
                        } 
                        // append to list 
                        buckets[bpos].Enqueue(elem); 
                    }
                } else {
                    while (Q.Count > 0) {
                        // put current into bucket
                        ILListItem<ElementType,IndexType> elem = Q.Dequeue(); 
                        int bpos = mapper.Map(elem.Data,k,0);
                        if (buckets[bpos] == null) {
                            // must create list first
                            buckets[bpos] = new ILQueueList<ElementType,IndexType>();
                        } 
                        // append to list 
                        buckets[bpos].Enqueue(elem); 
                    }
                }
                // concatenate all buckets 
                for (int i = 0; i < buckets.Length; i++) {
                    if (buckets[i] != null && buckets[i].Count > 0) {
                        Q.Enqueue(buckets[i]); 
                        buckets[i].Clear();
                    }
                }
                // goto previous position in strings 
            }
            return Q;
        }

        internal static ILQueueList<ElementType,IndexType> 
            bucketSort_constantLength<ElementType,SubelementType,IndexType>(
                                            IEnumerable<ElementType> input,
                                            IEnumerable<IndexType> indices, 
                                            ILKeyMapper<ElementType,SubelementType> mapper) {
            int m = mapper.NumberOfKeys;
            int tmp = 0; 
            ILQueueList<ElementType,IndexType>[] buckets = new ILQueueList<ElementType,IndexType>[m];
            ILQueueList<ElementType,IndexType> Q = new ILQueueList<ElementType,IndexType>(); 
            // find longest element 
            int maxLen = 0;
            foreach (ElementType elem in input) {
                tmp = mapper.SubelementsCount( elem );  
                if (tmp > maxLen)
                    maxLen = tmp;
            }
            // sort into buckets 
            IEnumerator<IndexType> indIt = indices.GetEnumerator();
            indIt.MoveNext(); 
            for (int k = maxLen; k-- > 0; ) {
                // walk along the input 
                if (k == maxLen - 1) {
                    foreach (ElementType elem in input) {
                        // put current into bucket
                        int bpos = mapper.Map(elem,k,0);
                        if (buckets[bpos] == null) {
                            // must create list first
                            buckets[bpos] = new ILQueueList<ElementType,IndexType>();
                        } 
                        // append to list 
                        buckets[bpos].Enqueue(elem,indIt.Current);
                        indIt.MoveNext(); 
                    }
                } else {
                    while (Q.Count > 0) {
                        // put current into bucket
                        ILListItem<ElementType,IndexType> elem = Q.Dequeue(); 
                        int bpos = mapper.Map(elem.Data,k,0);
                        if (buckets[bpos] == null) {
                            // must create list first
                            buckets[bpos] = new ILQueueList<ElementType,IndexType>();
                        } 
                        // append to list 
                        buckets[bpos].Enqueue(elem); 
                    }
                }
                // concatenate all buckets 
                for (int i = 0; i < buckets.Length; i++) {
                    if (buckets[i] != null && buckets[i].Count > 0) {
                        Q.Enqueue(buckets[i]); 
                        buckets[i].Clear();
                    }
                }
                // goto previous position in strings 
            }
            return Q;
        }

    }
}
