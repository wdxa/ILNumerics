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
using ILNumerics.Misc;  
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inArr1
        </source>
        <destination>byte</destination>
        <destination>complex</destination>
    </type>
    <type>
        <source locate="after">
            inArr2
        </source>
        <destination>double</destination>
        <destination>double</destination>
    </type>
 </hycalper>
 */
    
namespace ILNumerics.Algorithms {
    internal class ILQuickSort {

#region HYCALPER LOOPSTART recursiveQuickSorts
        internal static void QuickSortAscSolid (/*!HC:inArr1*/ double [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length < 2) return; 
            unsafe {
                fixed (/*!HC:inArr1*/ double * vec = vecP) {
                    /*!HC:inArr1*/ double temp, pivotItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolid (/*!HC:inArr1*/ double [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            if (vecP.Length < 2) return; 
            int loSwap, hiSwap;
            int pivotIndex;
            unsafe {
                fixed (/*!HC:inArr1*/ double * vec = vecP) {
                    /*!HC:inArr1*/ double temp, pivotItem;
                    if (hiBound - loBound == inc) { // Two items to sort
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            // All vec[loBound+1..loSwap-1]
                            // are <= pivot && loSwap <= hiSwap+1
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            // All vec[hiSwap=+1..hiBound]
                            // are > pivot && hiSwap >= loSwap-1
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                        // INVARIANT: All vec[loBound..loSwap-1] are <= pivot
                        // && All vec[hiSwap+1..hiBound] are > pivot
                        // && (loSwap < hiSwap) -->
                        // vec[loSwap] <= pivot < vec[hiSwap]
                        // && (loSwap >= hiSwap) --> vec[hiSwap] <= pivot
                        // && loBound <= loSwap <= hiSwap+1 <= hiBound+1
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortAscSolidIDX (/*!HC:inArr1*/ double [] vecP, /*!HC:inArr2*/ double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed (/*!HC:inArr2*/ double * idx = idxP)
                fixed (/*!HC:inArr1*/ double * vec = vecP) {
                    /*!HC:inArr1*/ double temp, pivotItem;
                    /*!HC:inArr2*/ double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolidIDX (/*!HC:inArr1*/ double [] vecP, /*!HC:inArr2*/ double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed (/*!HC:inArr2*/ double * idx = idxP)
                fixed (/*!HC:inArr1*/ double * vec = vecP) {
                    /*!HC:inArr1*/ double temp, pivotItem;
                    /*!HC:inArr2*/ double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }
#endregion HYCALPER LOOPEND recursiveQuickSorts
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        internal static void QuickSortAscSolid ( complex [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length < 2) return; 
            unsafe {
                fixed ( complex * vec = vecP) {
                    complex temp, pivotItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolid ( complex [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            if (vecP.Length < 2) return; 
            int loSwap, hiSwap;
            int pivotIndex;
            unsafe {
                fixed ( complex * vec = vecP) {
                    complex temp, pivotItem;
                    if (hiBound - loBound == inc) { // Two items to sort
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            // All vec[loBound+1..loSwap-1]
                            // are <= pivot && loSwap <= hiSwap+1
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            // All vec[hiSwap=+1..hiBound]
                            // are > pivot && hiSwap >= loSwap-1
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                        // INVARIANT: All vec[loBound..loSwap-1] are <= pivot
                        // && All vec[hiSwap+1..hiBound] are > pivot
                        // && (loSwap < hiSwap) -->
                        // vec[loSwap] <= pivot < vec[hiSwap]
                        // && (loSwap >= hiSwap) --> vec[hiSwap] <= pivot
                        // && loBound <= loSwap <= hiSwap+1 <= hiBound+1
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortAscSolidIDX ( complex [] vecP,  double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed ( double * idx = idxP)
                fixed ( complex * vec = vecP) {
                    complex temp, pivotItem;
                    double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolidIDX ( complex [] vecP,  double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed ( double * idx = idxP)
                fixed ( complex * vec = vecP) {
                    complex temp, pivotItem;
                    double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortAscSolid ( byte [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length < 2) return; 
            unsafe {
                fixed ( byte * vec = vecP) {
                    byte temp, pivotItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolid ( byte [] vecP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            if (vecP.Length < 2) return; 
            int loSwap, hiSwap;
            int pivotIndex;
            unsafe {
                fixed ( byte * vec = vecP) {
                    byte temp, pivotItem;
                    if (hiBound - loBound == inc) { // Two items to sort
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    pivotItem = (*(vec+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            // All vec[loBound+1..loSwap-1]
                            // are <= pivot && loSwap <= hiSwap+1
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            // All vec[hiSwap=+1..hiBound]
                            // are > pivot && hiSwap >= loSwap-1
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                        // INVARIANT: All vec[loBound..loSwap-1] are <= pivot
                        // && All vec[hiSwap+1..hiBound] are > pivot
                        // && (loSwap < hiSwap) -->
                        // vec[loSwap] <= pivot < vec[hiSwap]
                        // && (loSwap >= hiSwap) --> vec[hiSwap] <= pivot
                        // && loBound <= loSwap <= hiSwap+1 <= hiBound+1
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolid(vecP, loBound, hiSwap-inc,inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolid(vecP, hiSwap+inc, hiBound,inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortAscSolidIDX ( byte [] vecP,  double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed ( double * idx = idxP)
                fixed ( byte * vec = vecP) {
                    byte temp, pivotItem;
                    double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) > *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) <= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) > pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortAscSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortAscSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }
        internal static void QuickSortDescSolidIDX ( byte [] vecP,  double [] idxP, int loBound, int hiBound, int inc) {
            System.Diagnostics.Debug.Assert(vecP != null); 
            System.Diagnostics.Debug.Assert(loBound <= hiBound);
            System.Diagnostics.Debug.Assert(loBound >= 0);
            System.Diagnostics.Debug.Assert(idxP != null); 
            System.Diagnostics.Debug.Assert(idxP.Length == vecP.Length); 
            int loSwap, hiSwap;
            int pivotIndex;
            if (vecP.Length == 1) {
                //idxP[0] = 0; 
                return;   
            } 
            if (vecP.Length == 0) {
                return; 
            }
            unsafe {
                fixed ( double * idx = idxP)
                fixed ( byte * vec = vecP) {
                    byte temp, pivotItem;
                    double tmpIdx, pivotIndexItem;
                    if (hiBound - loBound == inc) { 
                        if (*(vec + loBound) < *(vec + hiBound)) {
                            // exchange data
                            temp = (*(vec+loBound));
                            (*(vec+loBound)) = (*(vec+hiBound));
                            (*(vec+hiBound)) = temp;
                            // exchange idx
                            pivotIndexItem = (*(idx+loBound));
                            (*(idx+loBound)) = (*(idx+hiBound));
                            (*(idx+hiBound)) = pivotIndexItem;
                        }
                        return;
                    }
                    pivotIndex = loBound + (int)((hiBound - loBound) / inc / 2) * inc; // 3 or more items to sort
                    // exchange pivot item for data + idx
                    pivotItem = (*(vec+pivotIndex));
                    pivotIndexItem = (*(idx+pivotIndex));
                    (*(vec+pivotIndex)) = (*(vec+loBound));
                    (*(vec+loBound)) = pivotItem;
                    (*(idx+pivotIndex)) = (*(idx+loBound));
                    (*(idx+loBound)) = pivotIndexItem;

                    loSwap = loBound + inc;
                    hiSwap = hiBound;
                    do {
                        while (loSwap <= hiSwap && (*(vec+loSwap)) >= pivotItem) {
                            //System.Diagnostics.Debug.Assert(Check1(vec, loBound, loSwap, hiSwap, pivotItem));
                            loSwap += inc;
                        }
                        while ((*(vec+hiSwap)) < pivotItem)  {
                            //System.Diagnostics.Debug.Assert(Check2(vec, hiBound, loSwap, hiSwap, pivotItem)); 
                            hiSwap -= inc;
                        }
                        if (loSwap < hiSwap) {
                            temp = (*(vec+loSwap));
                            (*(vec+loSwap)) = (*(vec+hiSwap));
                            (*(vec+hiSwap)) = temp;
                            tmpIdx = (*(idx+loSwap));
                            (*(idx+loSwap)) = (*(idx+hiSwap));
                            (*(idx+hiSwap)) = tmpIdx;
                            // in-/ decrease swap positions
                            loSwap += inc;
                            hiSwap -= inc;
                        }
                    } while (loSwap <= hiSwap);
                    //System.Diagnostics.Debug.Assert(Check3(vec, hiBound, loBound, loSwap, hiSwap, pivotItem)); 
                    (*(vec+loBound)) = (*(vec+hiSwap));
                    (*(vec+hiSwap)) = pivotItem;
                    (*(idx+loBound)) = (*(idx+hiSwap));
                    (*(idx+hiSwap)) = pivotIndexItem;

                    if (loBound < hiSwap-inc) // 2 or more items in 1st subvec
                        QuickSortDescSolidIDX(vecP, idxP, loBound, hiSwap-inc, inc);
                    if (hiSwap+inc < hiBound) // 2 or more items in 2nd subvec
                        QuickSortDescSolidIDX(vecP, idxP, hiSwap+inc, hiBound, inc);
                } // fixed
            } // unsafe 
        }

#endregion HYCALPER AUTO GENERATED CODE

#region Debug assertion checks
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
