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
using ILNumerics.Algorithms; 
using ILNumerics.Exceptions;
using ILNumerics.Settings; 
using ILNumerics.Misc;  
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>byte</destination>
        <destination>char</destination>
        <destination>complex</destination>
        <destination>fcomplex</destination>
        <destination>float</destination>
        <destination>Int16</destination>
        <destination>Int32</destination>
        <destination>Int64</destination>
        <destination>UInt16</destination>
        <destination>UInt32</destination>
        <destination>UInt64</destination>
    </type>
    <type>
        <source locate="endregion">
            checkNAN
        </source>
        <destination></destination>
        <destination></destination>
        <destination><![CDATA[                
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex.NaN; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination><![CDATA[                
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex.NaN; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination><![CDATA[                
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float.NaN; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
    </type>
    <type>
        <source locate="endregion">
            checkIdxNAN
        </source>
        <destination></destination>
        <destination></destination>
        <destination><![CDATA[                
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination><![CDATA[                
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination><![CDATA[                
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }]]></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
        <destination></destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
        <destination>double</destination>
    </type>
 </hycalper>
 */
    
namespace ILNumerics.Algorithms {

    /// <summary>
    /// the class provides a number of one dimensional quicksort implementations for several datatypes/ properties
    /// </summary>
    public class ILQuickSort {

#region HYCALPER LOOPSTART QuickSorts

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT(/*!HC:inArr1*/ double [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        /*!HC:inArr1*/ double a1, a2, a3; 
        unsafe {
        fixed (
            /*!HC:inArr1*/ double * vec = vecP) {
            /*!HC:inArr1*/ double temp, pivotItem;                
            /*!HC:checkNAN*/
            #region check & presort for NaNs 
            for (; hi >= lo && double.IsNaN(*(vec + hi)) ; hi -= inc);
            if (hi >= lo) {
                for (i = hi - inc; i >= lo; i -= inc) {
                    if (double .IsNaN(*(vec + i))) {
                        *(vec + i) = *(vec + hi); 
                        *(vec + hi) = double .NaN; 
                        hi -= inc; 
                    }
                }
            }
            #endregion HYCALPER checkNAN
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT(/*!HC:inArr1*/ double [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        /*!HC:inArr1*/ double a1, a2, a3; 
        unsafe {
        fixed (
            /*!HC:inArr1*/ double * vec = vecP) {
            /*!HC:inArr1*/ double temp, pivotItem;                
            /*!HC:checkNAN*/
            #region check & presort for NaNs 
            for (; hi >= lo && double.IsNaN(*(vec + hi)) ; hi -= inc);
            if (hi >= lo) {
                for (i = hi - inc; i >= lo; i -= inc) {
                    if (double .IsNaN(*(vec + i))) {
                        *(vec + i) = *(vec + hi); 
                        *(vec + hi) = double .NaN; 
                        hi -= inc; 
                    }
                }
            }
            #endregion HYCALPER checkNAN
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT(/*!HC:inArr1*/ double [] vecP, /*!HC:inArr2*/ double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        /*!HC:inArr1*/ double a1, a2, a3; 
        /*!HC:inArr2*/ double ai1, ai2, ai3; 
        unsafe {
        fixed (/*!HC:inArr2*/ double * vecIdx = idxP)
        fixed (
            /*!HC:inArr1*/ double * vec = vecP) {
            /*!HC:inArr1*/ double temp, pivotItem;                
            /*!HC:checkIdxNAN*/
            #region check & presort for NaNs 
            for (; hi >= lo && double.IsNaN(*(vec + hi)) ; hi -= inc);
            if (hi >= lo) {
                for (i = hi - inc; i >= lo; i -= inc) {
                    if (double .IsNaN(*(vec + i))) {
                        *(vec + i) = *(vec + hi); 
                        *(vec + hi) = double .NaN; 
                        ai1 = *(vecIdx + hi); 
                        *(vecIdx + hi) = *(vecIdx + i); 
                        *(vecIdx + i) = ai1; 
                        hi -= inc; 
                    }
                }
            }
            #endregion HYCALPER checkIdxNAN
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT(/*!HC:inArr1*/ double [] vecP, /*!HC:inArr2*/ double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        /*!HC:inArr1*/ double a1, a2, a3; 
        /*!HC:inArr2*/ double ai1, ai2, ai3; 
        unsafe {
        fixed (/*!HC:inArr2*/ double * vecIdx = idxP)
        fixed (
            /*!HC:inArr1*/ double * vec = vecP) {
            /*!HC:inArr1*/ double temp, pivotItem;                
            /*!HC:checkIdxNAN*/
            #region check & presort for NaNs 
            for (; hi >= lo && double.IsNaN(*(vec + hi)) ; hi -= inc);
            if (hi >= lo) {
                for (i = hi - inc; i >= lo; i -= inc) {
                    if (double .IsNaN(*(vec + i))) {
                        *(vec + i) = *(vec + hi); 
                        *(vec + hi) = double .NaN; 
                        ai1 = *(vecIdx + hi); 
                        *(vecIdx + hi) = *(vecIdx + i); 
                        *(vecIdx + i) = ai1; 
                        hi -= inc; 
                    }
                }
            }
            #endregion HYCALPER checkIdxNAN
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
#endregion HYCALPER LOOPEND recursiveQuickSorts
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( UInt64 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt64 a1, a2, a3; 
        unsafe {
        fixed (
            UInt64 * vec = vecP) {
            UInt64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( UInt64 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt64 a1, a2, a3; 
        unsafe {
        fixed (
            UInt64 * vec = vecP) {
            UInt64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( UInt64 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt64 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt64 * vec = vecP) {
            UInt64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( UInt64 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt64 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt64 * vec = vecP) {
            UInt64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( UInt32 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt32 a1, a2, a3; 
        unsafe {
        fixed (
            UInt32 * vec = vecP) {
            UInt32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( UInt32 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt32 a1, a2, a3; 
        unsafe {
        fixed (
            UInt32 * vec = vecP) {
            UInt32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( UInt32 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt32 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt32 * vec = vecP) {
            UInt32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( UInt32 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt32 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt32 * vec = vecP) {
            UInt32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( UInt16 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt16 a1, a2, a3; 
        unsafe {
        fixed (
            UInt16 * vec = vecP) {
            UInt16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( UInt16 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt16 a1, a2, a3; 
        unsafe {
        fixed (
            UInt16 * vec = vecP) {
            UInt16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( UInt16 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt16 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt16 * vec = vecP) {
            UInt16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( UInt16 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        UInt16 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            UInt16 * vec = vecP) {
            UInt16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( Int64 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int64 a1, a2, a3; 
        unsafe {
        fixed (
            Int64 * vec = vecP) {
            Int64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( Int64 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int64 a1, a2, a3; 
        unsafe {
        fixed (
            Int64 * vec = vecP) {
            Int64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( Int64 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int64 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int64 * vec = vecP) {
            Int64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( Int64 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int64 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int64 * vec = vecP) {
            Int64 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( Int32 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int32 a1, a2, a3; 
        unsafe {
        fixed (
            Int32 * vec = vecP) {
            Int32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( Int32 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int32 a1, a2, a3; 
        unsafe {
        fixed (
            Int32 * vec = vecP) {
            Int32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( Int32 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int32 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int32 * vec = vecP) {
            Int32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( Int32 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int32 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int32 * vec = vecP) {
            Int32 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( Int16 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int16 a1, a2, a3; 
        unsafe {
        fixed (
            Int16 * vec = vecP) {
            Int16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( Int16 [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int16 a1, a2, a3; 
        unsafe {
        fixed (
            Int16 * vec = vecP) {
            Int16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( Int16 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int16 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int16 * vec = vecP) {
            Int16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( Int16 [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        Int16 a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            Int16 * vec = vecP) {
            Int16 temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( float [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        float a1, a2, a3; 
        unsafe {
        fixed (
            float * vec = vecP) {
            float temp, pivotItem;                
                            
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( float [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        float a1, a2, a3; 
        unsafe {
        fixed (
            float * vec = vecP) {
            float temp, pivotItem;                
                            
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( float [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        float a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            float * vec = vecP) {
            float temp, pivotItem;                
                            
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( float [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        float a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            float * vec = vecP) {
            float temp, pivotItem;                
                            
                for (; hi >= lo && float.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (float .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = float .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( fcomplex [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        fcomplex a1, a2, a3; 
        unsafe {
        fixed (
            fcomplex * vec = vecP) {
            fcomplex temp, pivotItem;                
                            
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( fcomplex [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        fcomplex a1, a2, a3; 
        unsafe {
        fixed (
            fcomplex * vec = vecP) {
            fcomplex temp, pivotItem;                
                            
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( fcomplex [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        fcomplex a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            fcomplex * vec = vecP) {
            fcomplex temp, pivotItem;                
                            
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( fcomplex [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        fcomplex a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            fcomplex * vec = vecP) {
            fcomplex temp, pivotItem;                
                            
                for (; hi >= lo && fcomplex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (fcomplex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = fcomplex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( complex [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        complex a1, a2, a3; 
        unsafe {
        fixed (
            complex * vec = vecP) {
            complex temp, pivotItem;                
                            
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( complex [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        complex a1, a2, a3; 
        unsafe {
        fixed (
            complex * vec = vecP) {
            complex temp, pivotItem;                
                            
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex.IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex.NaN; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( complex [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        complex a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            complex * vec = vecP) {
            complex temp, pivotItem;                
                            
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( complex [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        complex a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            complex * vec = vecP) {
            complex temp, pivotItem;                
                            
                for (; hi >= lo && complex.IsNaN(*(vec + hi)) ; hi -= inc);
                if (hi >= lo) {
                    for (i = hi - inc; i >= lo; i -= inc) {
                        if (complex .IsNaN(*(vec + i))) {
                            *(vec + i) = *(vec + hi); 
                            *(vec + hi) = complex .NaN; 
                            ai1 = *(vecIdx + hi); 
                            *(vecIdx + hi) = *(vecIdx + i); 
                            *(vecIdx + i) = ai1; 
                            hi -= inc; 
                        }
                    }
                }
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( char [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        char a1, a2, a3; 
        unsafe {
        fixed (
            char * vec = vecP) {
            char temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( char [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        char a1, a2, a3; 
        unsafe {
        fixed (
            char * vec = vecP) {
            char temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( char [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        char a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            char * vec = vecP) {
            char temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( char [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        char a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            char * vec = vecP) {
            char temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

    /// <summary>
    /// inline one dimensional quick sort, ascending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolid_IT( byte [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        byte a1, a2, a3; 
        unsafe {
        fixed (
            byte * vec = vecP) {
            byte temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline one dimensional quick sort, descending, arbitrary element spacing
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolid_IT( byte [] vecP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        byte a1, a2, a3; 
        unsafe {
        fixed (
            byte * vec = vecP) {
            byte temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                        }
                        *(vec + i + inc) = pivotItem;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4D(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, ascending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortAscSolidIDX_IT( byte [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        byte a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            byte * vec = vecP) {
            byte temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp <= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 > a2) {
                        if (a1 > a3) {
                            if (a3 > a2) {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + hi) = ai1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + hi) = a1; 
                                *(vec + lo) = a3; 
                                *(vec + lo + inc) = a2; 
                                *(vecIdx + hi) = ai1;  
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + lo + inc) = ai2; 
                            }
                        } else {
                            *(vec + lo) = a2; 
                            *(vec + lo + inc) = a1; 
                            *(vecIdx + lo) = ai2; 
                            *(vecIdx + lo + inc) = ai1; 
                        }
                    } else {
                        if (a2 > a3) {
                            *(vec + hi) = a2; 
                            *(vecIdx + hi) = ai2; 
                            if (a3 > a1) {
                                *(vec + lo + inc) = a3; 
                                *(vecIdx + lo + inc) = ai3; 
                            } else {
                                *(vec + lo + inc) = a1; 
                                *(vec + lo) = a3; 
                                *(vecIdx + lo + inc) = ai1; 
                                *(vecIdx + lo) = ai3; 
                            }
                        } else {
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) < pivotItem); 
                        do j -= inc; while (*(vec + j) > pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }
    /// <summary>
    /// inline 1 dimensional quick sort, descending, arbitrary element spacing, indices aware
    /// </summary>
    /// <param name="vecP">data array, 1dim, replaced on output with sorted values</param>
    /// <param name="lo">lowest index of sorting range</param>
    /// <param name="hi">highest index of sorting range</param>
    /// <param name="idxP">indices vector, content will implace be sorted along with <paramref name="vecP"/></param>
    /// <param name="inc">spacing between elements (dimension specifier)</param>
    /// <remarks><para>Quick sort algorithm is used for ranges of minimum lengths specified by 
    /// <see cref="ILNumerics.Settings.ILSettings.MinimumQuicksortLength"/> and above. 
    /// Below that length, a simple insertion sort is used instead.</para>
    /// <para>The algorithm implements a non-recursive quicksort variant. Therefore a small amount of 
    /// memory is needed to perform the sorting. That 'stack' memory is preserved from the ILMemoryPool. 
    /// The size is determined by the value of 
    /// <see cref="ILNumerics.Settings.ILSettings.MaxSafeQuicksortRecursionDepth"/>.</para>
    /// <para><b>Handling of NaN values (for double,float,complex or fcomplex arrays element datatypes only):</b> 
    /// if the input array contains any NaN values, those elements will be sorted to the end of the array on output.</para></remarks>
    public static void QuickSortDescSolidIDX_IT( byte [] vecP,  double [] idxP, int lo, int hi, int inc) {
        System.Diagnostics.Debug.Assert(vecP != null); 
        System.Diagnostics.Debug.Assert(lo <= hi);
        System.Diagnostics.Debug.Assert(lo >= 0);
        //int loSwap, hiSwap;
        int pivotIndex, i, j;
        if (vecP.Length < 2) return;
        int[] stack = ILMemoryPool.Pool.New<int>(ILSettings.MaxSafeQuicksortRecursionDepth * 2);
        int stackPos = -1;
        byte a1, a2, a3; 
        double ai1, ai2, ai3; 
        unsafe {
        fixed ( double * vecIdx = idxP)
        fixed (
            byte * vec = vecP) {
            byte temp, pivotItem;                
            
            for (; ; ) {
                if (hi - lo < (ILSettings.MinimumQuicksortLength * inc)) {
                    #region small array: insertion sort
                    for (j = lo + inc; j <= hi; j += inc) {
                        pivotItem = (*(vec + j));
                        ai1 = *(vecIdx + j); 
                        for (i = j - inc; i >= lo; i -= inc) {
                            temp = *(vec + i);
                            if (temp >= pivotItem)
                                break;
                            *(vec + i + inc) = temp;
                            *(vecIdx + i + inc) = *(vecIdx + i);
                        }
                        *(vec + i + inc) = pivotItem;
                        *(vecIdx + i + inc) = ai1;
                    }
                    #endregion
                    if (stackPos < 0) break;
                    lo = stack[stackPos--];
                    hi = stack[stackPos--]; 
                } else {
                    // quicksort
                    pivotIndex = lo + (int)((hi - lo) / inc / 2) * inc;
                    a1 = *(vec + lo); 
                    a2 = *(vec + pivotIndex); 
                    a3 = *(vec + hi);
                    ai1 = *(vecIdx + lo); 
                    ai2 = *(vecIdx + pivotIndex); 
                    ai3 = *(vecIdx + hi);
                    *(vec + pivotIndex) = *(vec + lo + inc);
                    *(vecIdx + pivotIndex) = *(vecIdx + lo + inc);
                    #region bring lo, lo+inc, hi in order
                    // by explicitely stepping through all possible paths,
                    // we save some assignments and comparisons
                    if (a1 < a2) {
                        if (a2 < a3) {
                            *(vec + hi) = a1; 
                            *(vec + lo) = a3; 
                            *(vec + lo + inc) = a2; 
                            *(vecIdx + hi) = ai1; 
                            *(vecIdx + lo) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        } else {
                            if (a1 < a3) {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a3; 
                                *(vec + hi) = a1; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                                *(vecIdx + hi) = ai1; 
                            } else {
                                *(vec + lo) = a2; 
                                *(vec + lo + inc) = a1; 
                                //*(vec + hi) = a3; 
                                *(vecIdx + lo) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                                //*(vecIdx + hi) = ai3; 
                            }
                        }
                    } else {
                        if (a2 < a3) {
                            if (a1 < a3) {
                                *(vec + lo) = a3; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a1; 
                                *(vecIdx + lo) = ai3; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai1; 
                            } else {
                                //*(vec + lo) = a1; 
                                *(vec + hi) = a2; 
                                *(vec + lo + inc) = a3; 
                                //*(vecIdx + lo) = ai1; 
                                *(vecIdx + hi) = ai2; 
                                *(vecIdx + lo + inc) = ai3; 
                            }
                        } else {
                            //*(vec + lo) = a1; 
                            //*(vec + hi) = a3; 
                            *(vec + lo + inc) = a2; 
                            //*(vecIdx + lo) = ai1; 
                            //*(vecIdx + hi) = ai3; 
                            *(vecIdx + lo + inc) = ai2; 
                        }
                    }
                    #endregion
                    i = lo + inc; j = hi; 
                    pivotItem = *(vec + lo + inc);
                    ai1 = *(vecIdx + lo + inc);
                    for (;;) {
                        do i += inc; while (*(vec + i) > pivotItem); 
                        do j -= inc; while (*(vec + j) < pivotItem); 
                        if (j < i) break; 
                        temp = *(vec + i); 
                        ai2 = *(vecIdx + i); 
                        *(vec + i) = *(vec + j); 
                        *(vec + j) = temp; 
                        *(vecIdx + i) = *(vecIdx + j); 
                        *(vecIdx + j) = ai2; 
                    }
                    *(vec + lo + inc) = *(vec + j); 
                    *(vec + j) = pivotItem;
                    *(vecIdx + lo + inc) = *(vecIdx + j); 
                    *(vecIdx + j) = ai1;
#if DEBUG
                    //System.Diagnostics.Debug.Assert(Check4A(vecP,lo,hi,j,inc)); 
#endif 
                    if (hi - i + inc >= j - lo) {
                        stack[++stackPos] = hi; 
                        stack[++stackPos] = i; 
                        hi = j - inc; 
                    } else {
                        stack[++stackPos] = j - inc; 
                        stack[++stackPos] = lo; 
                        lo = i; 
                    }
                }
            }
        } // fixed
        } // unsafe 
    }

#endregion HYCALPER AUTO GENERATED CODE

#region Debug assertion checks
        private static bool Check4A<T>(T[] vec, int lo, int hi, int pivIndex, int inc) {
            double piv = Convert.ToDouble(vec[pivIndex].ToString()); 
            for (int i = lo; i <= pivIndex; i += inc) {
                if (Convert.ToDouble(vec[i].ToString()) > piv) {
                    return false; 
                }
            }
            for (int i = hi; i >= pivIndex; i -= inc) {
                if (Convert.ToDouble(vec[i].ToString()) < piv) {
                    return false; 
                }
            }
            return true; 
        }
        private static bool Check4D<T>(T[] vec, int lo, int hi, int pivIndex, int inc) {
            double piv = Convert.ToDouble(vec[pivIndex].ToString()); 
            for (int i = lo; i <= pivIndex; i += inc) {
                if (Convert.ToDouble(vec[i].ToString()) < piv) {
                    return false; 
                }
            }
            for (int i = hi; i >= pivIndex; i -= inc) {
                if (Convert.ToDouble(vec[i].ToString()) > piv) {
                    return false; 
                }
            }
            return true; 
        }
        private static bool Check3(double[] vec, int hiBound, int loBound, int loSwap, int hiSwap, double pivotItem) {
            for (int i = loBound; i < loSwap - 1; i++) {
                if (!(vec[i] <= pivotItem)) {
                    return false; 
                }
            }
            for (int i = hiSwap + 1; i < hiBound; i++) {
                if (!(vec[i] > pivotItem)) {
                    return false; 
                }
            }
            if (loSwap < hiSwap) {
                if (!(vec[loSwap] <= pivotItem && pivotItem < vec[hiSwap])) {
                    return false; 
                }
            } else {
                if (!(vec[hiSwap] <= pivotItem && (loBound <= loSwap) && (loSwap <= hiSwap + 1) && (hiSwap + 1 <= hiBound + 1))) {
                    return false; 
                }
            }
            return true; 
        }
        private static bool Check1(double[] vec, int loBound, int loSwap, int hiSwap, double pivotItem) {
            for (int i = loBound + 1; i < loSwap - 1; i++) {
                if (!(vec[i] <= pivotItem && loSwap <= hiSwap + 1)) {
                    return false; 
                }
            }
            return true; 
        }
        private static bool Check2(double[] vec, int hiBound, int loSwap, int hiSwap, double pivotItem) {
            for (int i = hiSwap + 1; i < hiBound; i++) {
                if (!(vec[i] > pivotItem && loSwap <= hiSwap + 1)) {
                    return false; 
                }
            }
            return true;
        }
#endregion 

    }
}
