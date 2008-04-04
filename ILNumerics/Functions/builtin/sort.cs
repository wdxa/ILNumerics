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
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Algorithms; 
using ILNumerics.Exceptions; 
using ILNumerics.Data; 
using ILNumerics.Misc; 
/*!HC:TYPELIST:
<hycalper>
    <type>
        <source locate="after">
            inCls1
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<char>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<UInt16>]]></destination>
        <destination><![CDATA[ILArray<UInt32>]]></destination>
        <destination><![CDATA[ILArray<UInt64>]]></destination>
    </type>
    <type>
        <source locate="after">
            inCls2
        </source>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
        <destination><![CDATA[ILArray<double>]]></destination>
    </type>
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
        <source locate="after">
            inArr2
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
        <source locate="after">
            outCls
        </source>
        <destination><![CDATA[ILArray<byte>]]></destination>
        <destination><![CDATA[ILArray<char>]]></destination>
        <destination><![CDATA[ILArray<complex>]]></destination>
        <destination><![CDATA[ILArray<fcomplex>]]></destination>
        <destination><![CDATA[ILArray<float>]]></destination>
        <destination><![CDATA[ILArray<Int16>]]></destination>
        <destination><![CDATA[ILArray<Int32>]]></destination>
        <destination><![CDATA[ILArray<Int64>]]></destination>
        <destination><![CDATA[ILArray<UInt16>]]></destination>
        <destination><![CDATA[ILArray<UInt32>]]></destination>
        <destination><![CDATA[ILArray<UInt64>]]></destination>
    </type>
    <type>
        <source locate="after">
            outArr
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
 </hycalper>
 */

namespace ILNumerics.BuiltInFunctions {
    public partial class ILMath {

#region HYCALPER LOOPSTART
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static /*!HC:outCls*/ ILArray<double> sort (/*!HC:inCls1*/ ILArray<double> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static /*!HC:outCls*/ ILArray<double> sort (/*!HC:inCls1*/ ILArray<double> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static /*!HC:outCls*/ ILArray<double> sort (/*!HC:inCls1*/ ILArray<double> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            /*!HC:outCls*/ ILArray<double> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static /*!HC:outCls*/ ILArray<double> sort (/*!HC:inCls1*/ ILArray<double> A, out /*!HC:inCls2*/ ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            /*!HC:outCls*/ ILArray<double> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
#endregion HYCALPER LOOPEND
#region HYCALPER AUTO GENERATED CODE
// DO NOT EDIT INSIDE THIS REGION !! CHANGES WILL BE LOST !! 
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt64> sort ( ILArray<UInt64> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt64> sort ( ILArray<UInt64> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt64> sort ( ILArray<UInt64> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<UInt64> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<UInt64> sort ( ILArray<UInt64> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<UInt64> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt32> sort ( ILArray<UInt32> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt32> sort ( ILArray<UInt32> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt32> sort ( ILArray<UInt32> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<UInt32> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<UInt32> sort ( ILArray<UInt32> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<UInt32> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt16> sort ( ILArray<UInt16> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt16> sort ( ILArray<UInt16> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<UInt16> sort ( ILArray<UInt16> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<UInt16> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<UInt16> sort ( ILArray<UInt16> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<UInt16> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int64> sort ( ILArray<Int64> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int64> sort ( ILArray<Int64> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int64> sort ( ILArray<Int64> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<Int64> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<Int64> sort ( ILArray<Int64> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<Int64> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int32> sort ( ILArray<Int32> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int32> sort ( ILArray<Int32> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int32> sort ( ILArray<Int32> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<Int32> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<Int32> sort ( ILArray<Int32> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<Int32> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int16> sort ( ILArray<Int16> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int16> sort ( ILArray<Int16> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<Int16> sort ( ILArray<Int16> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<Int16> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<Int16> sort ( ILArray<Int16> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<Int16> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<float> sort ( ILArray<float> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<float> sort ( ILArray<float> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<float> sort ( ILArray<float> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<float> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<float> sort ( ILArray<float> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<float> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<fcomplex> sort ( ILArray<fcomplex> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<fcomplex> sort ( ILArray<fcomplex> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<fcomplex> sort ( ILArray<fcomplex> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<fcomplex> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<fcomplex> sort ( ILArray<fcomplex> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<fcomplex> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<complex> sort ( ILArray<complex> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<complex> sort ( ILArray<complex> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<complex> sort ( ILArray<complex> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<complex> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<complex> sort ( ILArray<complex> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<complex> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<char> sort ( ILArray<char> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<char> sort ( ILArray<char> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<char> sort ( ILArray<char> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<char> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<char> sort ( ILArray<char> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<char> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted in ascending order using quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<byte> sort ( ILArray<byte> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort data in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<byte> sort ( ILArray<byte> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</remarks>
        public static  ILArray<byte> sort ( ILArray<byte> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<byte> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolid(ret.m_data,posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array, n-dimensional</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        /// <example><code>ILArray&lt;double&gt; A = ILMath.rand(1,5); 
        /// //A: 
        /// // 0.4324  0.9231  0.1231  0.1423  0.2991
        /// ILArray&lt;double&gt; I; 
        /// ILArray&lt;double&gt; R = ILMath.sort(A, out I, 1, false);
        /// //R: 
        /// // 0.1231  0.1423  0.2991  0.4324  0.9231  
        /// //I: 
        /// // 2  3  4  0  1
        /// </code>
        /// </example></remarks>
        public static  ILArray<byte> sort ( ILArray<byte> A, out  ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            if (A.IsEmpty || A.IsScalar) {
                return A.C; 
            }
            ILArray<byte> ret = A.C; 
            int inc = ret.Dimensions.SequentialIndexDistance(dim); 
            int dimLen = A.Dimensions[dim]; 
            int maxRuns = A.Dimensions.NumberOfElements / dimLen; 
            int posInArr = 0; 
            if (descending) {
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortDescSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            } else {
                // ascending
                for (int c = 0; c < maxRuns; c++) {
                    if (posInArr >= A.Dimensions.NumberOfElements) 
                        posInArr -= (A.Dimensions.NumberOfElements-1); 
                    ILQuickSort.QuickSortAscSolidIDX(ret.m_data,Indices.m_data, posInArr,posInArr+(dimLen-1)*inc,inc);    
                    posInArr += dimLen*inc; 
                }
            }
            return ret;
        }

#endregion HYCALPER AUTO GENERATED CODE

#region bucket sort - string
        /// <summary>
        /// sort strings in A along first non singleton dimension ascending
        /// </summary>
        /// <param name="A">input array. A may be an empty, scalar, vector or matrix.</param>
        /// <returns>sorted array of the same size/shape as A</returns>
        /// <remarks><para>The strings in A will be sorted lexicographically in ascending order using bucket sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the other rows/columns.</para>
        /// <para>The sorting order of strings will get determined char-wise by comparing the ASCII codes of the characters.</para></remarks>
        public static ILArray<string> sort (ILArray<string> A) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,false); 
        }
        /// <summary>
        /// sort strings in A along first non singleton dimension
        /// </summary>
        /// <param name="A">input array. A may be an empty, scalar, vector or matrix.</param>
        /// <param name="descending">Specifies the direction of sorting: true: descending sort direction; false: ascending</param>
        /// <returns>sorted array of the same size/shape as A</returns>
        /// <remarks><para>The strings in A will be sorted lexicographically in ascending order using bucket sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the other rows/columns.</para>
        /// <para>The sorting order of strings will get determined char-wise by comparing the ASCII codes of the characters.</para></remarks>
        public static ILArray<string> sort (ILArray<string> A, bool descending) {
            int fnsd = A.Dimensions.FirstNonSingleton(); 
            if (fnsd < 0) return A.C; 
            return sort(A,fnsd,descending); 
        }
        /// <summary>
        /// sort strings in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array. A may be an empty, scalar, vector or matrix.</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="descending">Specifies the direction of sorting: true: descending sort direction; false: ascending</param>
        /// <returns>sorted array of the same size/shape as A</returns>
        /// <remarks><para>The strings in A will be sorted lexicographically in ascending order using bucket sort algorithm. Data 
        /// along the first non singleton dimension will therefore get sorted independently from data 
        /// in the other rows/columns.</para>
        /// <para>The sorting order of strings will get determined char-wise by comparing the ASCII codes of the characters.</para></remarks>
        public static ILArray<string> sort (ILArray<string> A, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (A.Dimensions.NumberOfDimensions > 2) 
                throw new ILArgumentException("sort: for element type string only matrices are supported!");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) 
                return A.C; 
            ILArray<string> ret = new ILArray<string>(new string[A.Dimensions.NumberOfElements],A.Dimensions); 
            int dim1 = dim % A.Dimensions.NumberOfDimensions; 
            int dim2 = (dim1 + 1) % A.Dimensions.NumberOfDimensions; 
            int maxRuns = A.Dimensions[dim2]; 
            ILQueueList<string,byte> ql; 
            ILArray<int>[] ind = new ILArray<int>[2]; 
            int [] indI = new int[2];  
            ILASCIIKeyMapper km = new ILASCIIKeyMapper(); 
            for (int c = 0; c < maxRuns; c++) {
                ind[dim2] = c; 
                ind[dim1] = null; 
                ql = ILBucketSort.BucketSort<string,char,byte>(A[ind].Values,null,km,ILBucketSort.SortMethod.ConstantLength);     
                indI[dim2] = c; 
                if (descending) {
                    for (int i = ql.Count; i-->0; ) { 
                        indI[dim1] = i; 
                        ret.SetValue(ql.Dequeue().Data,indI);                                                             
                    }
                } else {
                    for (int i = 0; ql.Count > 0; i++ ) { 
                        indI[dim1] = i; 
                        ret.SetValue(ql.Dequeue().Data,indI);                                                             
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// sort data in A along dimension 'dim'
        /// </summary>
        /// <param name="A">input array: empty, scalar, vector or matrix</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">output parameter: returns permutation matrix also</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are of type double.</para>
        ///</remarks>
        public static ILArray<string> sort (ILArray<string> A, out ILArray<double> Indices, int dim, bool descending) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (A.Dimensions.NumberOfDimensions > 2) 
                throw new ILArgumentException("sort: for element type string only matrices are supported!");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) {
                Indices = 0.0; 
                return A.C; 
            }
            ILArray<string> ret = new ILArray<string>(new string[A.Dimensions.NumberOfElements],A.Dimensions); 
            int dim1 = dim % A.Dimensions.NumberOfDimensions; 
            int dim2 = (dim1 + 1) % A.Dimensions.NumberOfDimensions; 
            int maxRuns = A.Dimensions[dim2]; 
            ILQueueList<string,double> ql; 
            ILArray<int>[] ind = new ILArray<int>[2]; 
            int [] indI = new int[2];  
            ILASCIIKeyMapper km = new ILASCIIKeyMapper(); 
            Indices = ILMath.counter(0.0,1.0,A.Dimensions.ToIntArray()); 
            for (int c = 0; c < maxRuns; c++) {
                ind[dim2] = c; 
                ind[dim1] = null; 
                ql = ILBucketSort.BucketSort<string,char,double>(A[ind].Values,Indices[ind].Values,km,ILBucketSort.SortMethod.ConstantLength);     
                indI[dim2] = c; 
                if (descending) {
                    for (int i = ql.Count; i-->0; ) { 
                        indI[dim1] = i;
                        ILListItem<string,double> item = ql.Dequeue();
                        ret.SetValue(item.Data,indI);
                        Indices.SetValue(item.m_index,indI);                                      
                    }
                } else {
                    for (int i = 0; ql.Count > 0; i++ ) { 
                        indI[dim1] = i; 
                        ILListItem<string,double> item = ql.Dequeue();
                        ret.SetValue(item.Data,indI);
                        Indices.SetValue(item.m_index,indI);                                      
                    }
                }
            }
            return ret; 
        }
        /// <summary>
        /// generic sort algorithm in A along dimension 'dim' 
        /// </summary>
        /// <param name="A">input array: empty, scalar, vector or matrix</param>
        /// <param name="descending">Specifies the direction of sorting</param>
        /// <param name="dim">dimension to sort along</param>
        /// <param name="Indices">input/output parameter: the values in Indices will be returned in the same sorted order as the elements in A. This can be used to derive a permutation matrix of the sorting process.</param>
        /// <param name="keymapper">Instancce of an object of type ILKeyMapper. This object must 
        /// be derived ILKeyMapper&lt;T,SubelementType&gt; and match the generic argument <typeparamref name="T"/>. It will be 
        /// used to split single elements into its subelements and map their content into bucket numbers. For all 
        /// reference types except those of type string you will have to write your own ILKeyMapper class for that purpose.</param>
        /// <returns>sorted array of the same size as A</returns>
        /// <remarks><para>The data in A will be sorted using the quick sort algorithm. Data 
        /// along the dimension <paramref name="dim"/> will therefore get sorted independently from data 
        /// in the next row/column.</para>
        /// <para>This overload also returns an array 'Indices' which will hold the indices into the original 
        /// elements <b>after sorting</b>. Elements of 'Indices' are always of type int.</para>
        /// <para>This generic version is able to sort arbitrary element types. Even user defined reference types can be sorted 
        /// by specifying a user defined ILKeyMapper class instance. Also the type of Indices may be arbitrarily choosen. In difference 
        /// to the regular sort function overload, Indices must manually given to the function on the beginning. The given array's 
        /// elements will than be sorted in the same order as the input array A and returned.</para>
        /// <para>By using this overload you may use the same permutation matrix several times to reflect the 
        /// manipulations done to A due multiple sort processes. The Indices given will directly get used for the current sorting 
        /// without looking at their initial order.</para>
        /// </remarks>
        public static ILArray<T> sort<T,S,I> (ILArray<T> A, ref ILArray<I> Indices, int dim, bool descending, ILKeyMapper<T,S> keymapper) {
            if (object.Equals (A,null)) 
                throw new Exception("sort: parameter A must not be null");
            if (A.Dimensions.NumberOfDimensions > 2) 
                throw new ILArgumentException("sort: for generic element type - only matrices are supported!");
            if (dim < 0 || dim >= A.Dimensions.NumberOfDimensions)
                throw new ILArgumentException("sort: invalid dimension argument");
            if (keymapper == null) 
                throw new ILArgumentException("sort: the keymapper argument must not be null"); 
            if (object.Equals (Indices,null) || !Indices.Dimensions.IsSameSize(A.Dimensions))
                throw new ILArgumentException("sort: Indices argument must have same size/shape as input A");
            // early exit: scalar/ empty
            if (A.IsEmpty || A.IsScalar) {
                Indices = default(I); 
                return A.C; 
            }
            ILArray<T> ret = new ILArray<T>(new T[A.Dimensions.NumberOfElements],A.Dimensions); 
            int dim1 = dim % A.Dimensions.NumberOfDimensions; 
            int dim2 = (dim1 + 1) % A.Dimensions.NumberOfDimensions; 
            int maxRuns = A.Dimensions[dim2]; 
            ILQueueList<T,I> ql; 
            ILArray<int>[] ind = new ILArray<int>[2]; 
            int [] indI = new int[2];  
            for (int c = 0; c < maxRuns; c++) {
                ind[dim2] = c; 
                ind[dim1] = null; 
                ql = ILBucketSort.BucketSort<T,S,I>(A[ind].Values,Indices[ind].Values,keymapper,ILBucketSort.SortMethod.ConstantLength);     
                indI[dim2] = c; 
                if (descending) {
                    for (int i = ql.Count; i-->0; ) { 
                        indI[dim1] = i;
                        ILListItem<T,I> item = ql.Dequeue();
                        ret.SetValue(item.Data,indI);
                        Indices.SetValue(item.m_index,indI);                                      
                    }
                } else {
                    for (int i = 0; ql.Count > 0; i++ ) { 
                        indI[dim1] = i; 
                        ILListItem<T,I> item = ql.Dequeue();
                        ret.SetValue(item.Data,indI);
                        Indices.SetValue(item.m_index,indI);                                      
                    }
                }
            }
            return ret; 
        }
#endregion 


        internal static bool IsSorted (double[] vec, bool descending) {
            if (descending) {
                for (int i = 1; i < vec.Length; i++) {
                    if (vec[i] > vec[i-1])
                        return false; 
                }
            } else {
                for (int i = 1; i < vec.Length; i++) {
                    if (vec[i] < vec[i-1])
                        return false; 
                }
            }
            return true;
        }

    }
}
