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
using ILNumerics.Storage; 
using ILNumerics.Exceptions; 

namespace ILNumerics {
	/// <summary>
	/// ILCell : container base class holding arbitrary ILBaseArray objects 
	/// </summary>
	/// <remarks>
    /// ILCell is derived from <![CDATA[ILArray<ILBaseArray>]]>. Therefore any 
    /// ILBaseArray may be used as inner element type. No further constraints are made 
    /// for the elements. All array types used inside ILNumerics.Net (e.g.<![CDATA[ILArray<BaseT>]]>) 
    /// inherit from ILBaseArray.
	/// </remarks>
	public class ILCell : ILArray<ILBaseArray> {

        #region constructors
        /// <summary>
		/// Create cell object with pre-created data in specified dimensions 
		/// </summary>
		/// <remarks>object array data will directly be used for storage. No 
		/// copy will be made. The size must match prod(size)</remarks>
		public ILCell(ILBaseArray[] data, params int[] size)  
				: base (data, size){}
        /// <summary>
        /// constructor creating ILCell from base type
        /// </summary>
        /// <param name="input"></param>
        internal ILCell(ILArray<ILBaseArray> input) 
            : base(input) { }

        /// <summary>
        /// Create empty cell object 
        /// </summary>
        /// <param name="size">dimensions. This may be a comma separeted list
        /// or a int array holding dimension lengths.</param>
        public ILCell(params int[] size)
            : base(new ILBaseArray[prod(size)], size)
        {
        }

        #endregion constructors

        #region properties 
        /// <summary>
        /// Transposed version of this ILCell
        /// </summary>
        public new ILCell T {
            get {
                return new ILCell(base.T);
            }
        }
        #endregion

        #region Index access


        /// <summary>
        /// get/set/remove single element 
        /// </summary>
        /// The type of access depends on the length of indices. 
        /// <paramref name="indices" value="index to element"/>
        /// <value>inner element, new inner element or null</value>
        /// <remarks>If indices contains only one element, the array will be accessed via sequential index access. 
        /// This is sometimes called "linear" index access also. Sequential index access reflects the index of internal storage 
        /// the way the data are actually organized in memory. This access method is mainly convinient for vectors where you are not interested of orientation.
        /// The following example demonstrates sequential index access for ILArray's (which also holds for ILCells): 
        /// <example><code>
        /// ILArray&lt;double&gt; A = new  ILArray&lt;double&gt;(1.0,12.0);
        /// A[2] gives: 3.0
        /// </code>But the transpose 
        /// <code>
        /// A.T[2] gives also: 3.0
        /// </code> 
        /// For matrices and N-dimensional arrays this holds as well: 
        /// <code>
        /// ILArray&lt;double&gt; A = new  ILArray&lt;double&gt;(1.0,12.0);
        /// A = 
        /// [1.0 4.0
        ///  2.0 5.0 
        ///  3.0 6.0 
        /// 
        ///  7.0 10.0
        ///  8.0 11.0
        ///  9.0 12.0]
        /// 
        /// A = ILMath.Reshape(A,3,2,2); 
        /// A[10] gives 11.0
        /// A[10,1] gives ILArgumentException -> out of range
        /// A[2,1,1] gives 12.0
        /// A[2,1] gives 6.0 (set trailing dimension to '0')</code></example>
        /// <para>For get access the array returned will be a reference to the element addressed.</para>
        /// <para>If the element addressed is a ILCell itself, a deep reference to this element will be returned instead. 
        /// I.e. all elements of the ILCell will be recursively replaced with references to itself.</para>
        /// <para>
        /// <list type="bullet">
        /// <listheader>The type of the element returned depends on the type of the element addressed:</listheader>
        /// <item>For ILArray&lt;BaseT&gt; the array returned will be a reference to the original array (same type and size).</item> 
        /// <item>For ILCell the ILBaseArray returned is a deep reference of the original element stored.</item>
        /// <item>for other types the behavior is undefined. (since other types are not implemented yet ;)</item>
        /// </list> </para>
        /// <para>This indexer may also be used for direct access to elements of elements of this cell:
        /// <example>
        /// <code>
        /// ILCell innerCell = new ILCell(2,1); 
        /// innerCell[0] = ILMath.vector(10,200); 
        /// innerCell[1] = ILArray&lt;int&gt;(-10,-20,-30);
        /// ILCell cell = new ILCell(2,1); 
        /// cell[0] = innerCell; 
        /// cell[1] = new ILArray&lt;string&gt;("foobla"); 
        /// // cell is now: 
        /// // [ILCell,(1x2)] 
        /// //      [innerCell[0], ILArray&lt;double&gt;(1x181)]
        /// //      [innerCell[0], ILArray&lt;double&gt;(1x3)]
        /// // [ILArray&lt;string&gt;,(1x1)]
        /// 
        /// cell[0,0] -&gt; will give innerCell eq. ILCell (1x2)
        /// cell[0,1] -&gt; will give ILArray&lt;string&gt;
        /// cell[0,0,0,1] -&gt; will give innerCell[1] eq. ILArray&lt;int&gt;(1x3)
        /// </code>
        /// </example> 
        /// In the last example above the trailing indices specified make the indexer walk down into the ILCell element and retrieve 
        /// the content of this element. This kind of index access may be done as deep as you want. Just 
        /// append the inner indices into inner elements to the right side of index specification. Addressing inner elements 
        /// this way is the only way to alter elements <b>directly</b> inside the ILCell. </para>
        /// <para>For set access the element <code>value</code> will directly be stored in the ILCell. No copy/reference will be done for it!</para></remarks>
        public new ILBaseArray this[params int[] indices] {
            get{
                int mydimlen = m_dimensions.NumberOfDimensions; 
                if (indices.Length <= mydimlen) {
                    // address this ILCell 
                    ILBaseArray ret = base[indices].GetValue(0,0);
                    if (object.Equals(ret,null)) {
                        return null; 
                    } else if (ret is ILArray<ILBaseArray>) {
                        ILArray<ILBaseArray> tmp = (ILArray<ILBaseArray>) ret; 
                        ILCell retC = new ILCell(tmp).DeepReferenceElements(); 
                        return retC; 
                    }  else if (ret is ILLogicalArray){
                        return (ILLogicalArray)((ILLogicalArray)ret).CreateReference(); 
                    }  else {
                        return ret.CreateReference();
                    }
                } else {
                    // address element of an element of this ILCell
                    int[] innerIndices = new int[indices.Length - mydimlen]; 
                    int[] myIndices = new int[mydimlen]; 
                    int i = 0; 
                    for (; i < mydimlen; i++)
                        myIndices[i] = indices[i]; 
                    for (int n = 0; i < indices.Length; i++)
                        innerIndices[n++] = indices[i]; 
                    ILBaseArray innerElement = GetValue(myIndices); 
                    if (innerElement is ILCell) {
                        return ((ILCell)innerElement)[innerIndices]; 
                    } else if (innerElement is ILArray<double>){
                        return ((ILArray<double>)innerElement)[innerIndices];
                    } else {
                        throw new ILArgumentTypeException("inner cell element type is not supported for deep index access!");
                    }
                }
            }
            set {
                if (Object.ReferenceEquals(value,null))
                    throw new ILArgumentException("cell removal is not supported for single integer indexing! The value specified must not be null!"); 
                int mydimlen = m_dimensions.NumberOfDimensions; 
                if (indices.Length <= mydimlen) {
                    // address this ILCell
                    SetValue( value.CreateReference(), indices); 
                } else {
                    // address element of an element of this ILCell
                    int[] innerIndices = new int[indices.Length - mydimlen]; 
                    int[] myIndices = new int[mydimlen]; 
                    int i = 0; 
                    for (; i < mydimlen; i++)
                        myIndices[i] = indices[i]; 
                    for (int n = 0; i < indices.Length; i++)
                        innerIndices[n++] = indices[i]; 
                    ILBaseArray innerElement = GetValue(myIndices); 
                    if (innerElement is ILCell) {
                        ((ILCell)innerElement)[innerIndices] = value.CreateReference(); 
                    } else if (value is ILArray<double> && innerElement is ILArray<double>){
                        ((ILArray<double>)innerElement)[innerIndices] = (ILArray<double>)value.CreateReference();
                    } else if (value is ILArray<float> && innerElement is ILArray<float>){
                        ((ILArray<float>)innerElement)[innerIndices] = (ILArray<float>)value.CreateReference();
                    } else if (value is ILArray<complex> && innerElement is ILArray<complex>){
                        ((ILArray<complex>)innerElement)[innerIndices] = (ILArray<complex>)value.CreateReference();
                    } else if (value is ILArray<fcomplex> && innerElement is ILArray<fcomplex>){
                        ((ILArray<fcomplex>)innerElement)[innerIndices] = (ILArray<fcomplex>)value.CreateReference();
                    } else if (value is ILArray<Int16> && innerElement is ILArray<Int16>){
                        ((ILArray<Int16>)innerElement)[innerIndices] = (ILArray<Int16>)value.CreateReference();
                    } else if (value is ILArray<Int32> && innerElement is ILArray<Int32>){
                        ((ILArray<Int32>)innerElement)[innerIndices] = (ILArray<Int32>)value.CreateReference();
                    } else if (value is ILArray<Int64> && innerElement is ILArray<Int64>){
                        ((ILArray<Int64>)innerElement)[innerIndices] = (ILArray<Int64>)value.CreateReference();
                    } else if (value is ILArray<UInt16> && innerElement is ILArray<UInt16>){
                        ((ILArray<UInt16>)innerElement)[innerIndices] = (ILArray<UInt16>)value.CreateReference();
                    } else if (value is ILArray<UInt32> && innerElement is ILArray<UInt32>){
                        ((ILArray<UInt32>)innerElement)[innerIndices] = (ILArray<UInt32>)value.CreateReference();
                    } else if (value is ILArray<UInt64> && innerElement is ILArray<UInt64>){
                        ((ILArray<UInt64>)innerElement)[innerIndices] = (ILArray<UInt64>)value.CreateReference();
                    } else if (value is ILArray<byte> && innerElement is ILArray<byte>){
                        ((ILArray<byte>)innerElement)[innerIndices] = (ILArray<byte>)value.CreateReference();
                    } else if (value is ILArray<char> && innerElement is ILArray<char>){
                        ((ILArray<char>)innerElement)[innerIndices] = (ILArray<char>)value.CreateReference();
                    } else {
                        throw new ILArgumentTypeException("right side argument type is not supported in this context! The value must have the same type as the inner array of the cell!");
                    }
                }
            }
        }
 
        /// <summary>
        /// Subarray access. Get/set regular subarray. 
        /// </summary>
        /// <param name="indices">address range</param>
        /// <returns>reference cell array with subarray addressed by <c>indices</c>. </returns>
        /// <remarks>Query access: for N-dimensional cell arrays trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in <c>indices</c>.
        /// <para>The indexer may be used for querying or altering single/any elements 
        /// in this cell. <c>indices</c> may contains index specifications for one to any 
        /// dimension. The cell array returned will have the size specified by <c>indices</c>.</para>
        /// <para>Values returned will be reference cells. All elements contained will be 'deep references' created by 
        /// recursively walking downwards the elements and replacing them by references to itself. Therefore altering the 
        /// values returned will not alter the original elements.</para>
        /// <para>The indexer may also be used for removing parts of the cell. Therefore an empty array 
        /// (of the same type) or null must be assigned to the range specified by <c>indices</c> (using the set-access). <c>indices</c> 
        /// must contain exactly one dimension specification other than null for this case. This may be any vector-sized numeric ILArray of any 
        /// numeric type. If <c>indices</c> applies 
        /// to less dimensions than dimensions existing in the array, the upper dimensions will be 
        /// merged and the array will be reshaped before applying the removal to it.
        /// <example>
        /// <code>
        /// ILCell C = new ILCell(4,10); 
        /// C[null,2] = null;  // &gt;- will remove the third column (index '2') from the cell.
        /// C[null,ILMath.vector(2,5)] = null;  &gt;- will remove columns 3...6
        /// C[1,1] = null; &gt;- will produce an error. Only one dimension can be specified not null! 
        /// </code></example></para>
        /// <para>In case of removal the object will be changed into a reference array having the only removal dimension decreased.</para>
        /// <para>The general behaviors of this acces methods are compatible with corresponding Matlab access: a(:) = []. </para>
        /// <para></para></remarks>
        public new ILBaseArray this[params ILBaseArray[] indices] {
            get{
                ILBaseArray ret = base[indices];
                if (ret.IsScalar) {
                    ret = ((ILArray<ILBaseArray>)ret).GetValue(0); 
                    if (ret is ILCell)
                        return ((ILCell)ret).CreateReference(); 
                    else if (object.Equals(ret,null))
                        return new ILCell(); 
                    else 
                        return ret.CreateReference(); 
                } else {
                    if (ret is ILArray<ILBaseArray>) {
                        return new ILCell((ILArray<ILBaseArray>)ret).CreateReference(); 
                    } else {
                        throw new Exception("inner error: Cell array returned was null."); 
                    }
                }
            }
            set { 
                if (Object.ReferenceEquals(value,null)) {
                    base[indices] = null; 
                } else if (value is ILCell) {
                    base[indices] = (ILArray<ILBaseArray>)((ILCell)value).CreateReference();
                } else {
                    base[indices] = value.CreateReference(); 
                }
            }
        }
        
        /// <summary>
        /// Subarray access. Get/set regular subarray. 
        /// </summary>
        /// <param name="indices">address range. String array with each element holding a comma seperated list of indices for each dimension. </param>
        /// <returns>reference cell array with subarray addressed by <c>indices</c>. </returns>
        /// <remarks><para>The colon ':' is used, to identify the whole dimension. If used, the colon must be the only char in the dimension string.</para>
        /// <para><c>indices</c> may be a single string having dimension strings seperated by semicolon ';'</para>
        /// Query access: for N-dimensional cell arrays missing trailing dimensions will be choosen to be 0. Therefore you 
        /// may ommit those trailing dimensions in <c>indices</c>.
        /// <para>The indexer may be used for querying or altering single/any elements 
        /// in this cell. <c>indices</c> may contain index specifications for one to any 
        /// dimension. The cell array returned will have the size specified by <c>indices</c>.</para>
        /// <para>Values returned will be reference cells. All elements contained will be 'deep references' created by 
        /// recursively walking downwards the elements and replacing them by references to itself. Therefore altering the 
        /// values returned will not alter the original elements.</para>
        /// <para>The indexer may also be used for removing parts of the cell. Therefore an empty array 
        /// (of the same type) or null must be assigned to the range specified by <c>indices</c> (using the set-access). <c>indices</c> 
        /// must contain exactly one dimension specification other than ":" for this case. If <c>indices</c> applies 
        /// to less dimensions than dimensions existing in the array, the upper dimensions will be 
        /// merged and the array will be reshaped before applying the removal to it.
        /// <example>
        /// <code>
        /// ILCell C = new ILCell(4,10); 
        /// C[":;2"] = null;  // &gt;- will remove the third column (index '2') from the cell.
        /// C[":;2,5"] = null;  &gt;- will remove columns 3...6
        /// C["1;1"] = null; &gt;- will produce an error. Only one dimension can be specified not null! 
        /// </code></example></para>
        /// <para>In case of removal the object will be changed into a reference array having the only removal dimension decreased.</para>
        /// <para>The general behaviors of this access methods are compatible with corresponding Matlab access: a(:) = []. </para>
        /// <para></para></remarks>
        public new ILBaseArray this[params string[] indices] {
            get{
                ILBaseArray ret = base[indices];
                if (ret.IsScalar && ret is ILArray<ILBaseArray>) {
                    ret = ((ILArray<ILBaseArray>)ret).GetValue(0); 
                    if (ret is ILCell)
                        return ((ILCell)ret).CreateReference(); 
                    else 
                        return ret.CreateReference(); 
                } else {
                    if (ret is ILArray<ILBaseArray>) {
                        return new ILCell((ILArray<ILBaseArray>)ret).CreateReference(); 
                    } else {
                        throw new Exception("inner error: Cell array returned was null."); 
                    }
                }
            }
            set { 
                if (Object.ReferenceEquals(value,null)) {
                    base[indices] = null; 
                } else if (value is ILCell) {
                    base[indices] = ((ILCell)value).CreateReference();
                } else {
                    base[indices] = value.CreateReference(); 
                }
            }
        }

        #endregion index access

        #region helper functions 

        private static long prod(int[] sizes) {
            int ret = 1; 
            for (int i = 0; i < sizes.Length; i++) 
                ret *= sizes[i]; 
            return ret;
        }

        /// <summary>
        /// Deep reference from this ILCell
        /// </summary>
        /// <returns>ILCell having all elements replaced with references to their originals.</returns>
        /// <remarks>For all elements of supported types (ILBaseArray,ILCell), the reference creation will be done 
        /// recursively. </remarks>
        public override ILBaseArray CreateReference() {
            ILArray<ILBaseArray> ret1 = (ILArray<ILBaseArray>) base.CreateReference();
            ILCell ret2 = new ILCell(ret1); 
            ret1.Dispose();
            ret2.DeepReferenceElements(); 
            return ret2;
        }

        /// <summary>
        /// walk through all elements of this ILCell and replace them with references to their original
        /// </summary>
        /// <returns>this object having alle elements "referenced"</returns>
        /// <remarks>This may be seen as a deep reference (in distinction to deep copy). Elements 
        /// of type ILCell will recursevely get changed into references. </remarks>
        internal virtual ILCell DeepReferenceElements() {
            // this will create a deep (recursive) reference of this whole array
            int len = m_dimensions.NumberOfElements; 
            for (int i = 0; i < len; i++) {
                ILBaseArray a = GetValue(i); 
                if (a is ILCell) 
                    SetValue(((ILCell)a).CreateReference(),i); 
                else {
                    if (!Object.ReferenceEquals(a,null))
                        SetValue(a.CreateReference(),i);
                }
            }
            return this;
        }

        #endregion helper functions

    }
}
