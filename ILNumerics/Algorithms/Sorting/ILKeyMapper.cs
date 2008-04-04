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

namespace ILNumerics.Algorithms {
    /// <summary>
    /// key mapper class, to be overriden for user defined classes to be sorted with bucket sort
    /// </summary>
    /// <typeparam name="ElementType">Type of elements. Elements are constructed out of any number of subelements</typeparam>
    /// <typeparam name="SubelementType">Type of subelements</typeparam>
    /// <remarks>This class can be overriden to enable sorting (bucket sort) for arbitrary types. The elements of those types may be devidable into subelements.
    /// <para>Examples of sortable classes:
    /// <list>
    /// <item>colors: number/type of subelements: 1/any (f.e. the color code). One should write a <![CDATA[ILKeyMapper<Color,int>]]>.</item>
    /// <item>strings: number/type of subelements: arbitrary/char. Here a sample ILASCIKeyMapper implementation exists already. This implementation is the default implementation used for bucket sort via ILMath.sort().</item>
    /// <item>trees: number/type of subelements: arbitrary/tree nodes. One should write a key mapper to map a node of a tree to a bucket number</item>
    /// <item>...</item></list></para></remarks>
    public abstract class ILKeyMapper<ElementType,SubelementType> {
        /// <summary>
        /// maps subelement types to bucket index
        /// </summary>
        /// <param name="inSubelement">item</param>
        /// <returns>bucket index</returns>
        public abstract int Map (SubelementType inSubelement); 
        /// <summary>
        /// map subelemt - provide fallback on error
        /// </summary>
        /// <param name="element">element item</param>
        /// <param name="position">position of subelement in element item to be mapped</param>
        /// <param name="fallback">if position is out of range, give back fallback</param>
        /// <returns>mapped bucket for subelement or fallback on error</returns>
        public virtual int Map(ElementType element, int position, int fallback) {
            if (SubelementsCount(element) > position) 
                return Map(GetSubelement(element,position));
            else 
                return fallback; 
        }
        /// <summary>
        /// count subelements in an element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public abstract int SubelementsCount (ElementType element); 
        /// <summary>
        /// get subelement from element item
        /// </summary>
        /// <param name="element">element item</param>
        /// <param name="idx">position of subitem in element</param>
        /// <returns>subitem referenced</returns>
        public abstract SubelementType GetSubelement (ElementType element, int idx); 
        
        private int m_numberOfKeys = 0; 
        /// <summary>
        /// maximum number of keys (different subitems)
        /// </summary>
        public int NumberOfKeys {
            get {
                return m_numberOfKeys; 
            }
        }
        /// <summary>
        /// construct key mapper
        /// </summary>
        /// <param name="NumberOfKeys">maximm number of different subitems (keys)</param>
        public ILKeyMapper (int NumberOfKeys) {
            m_numberOfKeys = NumberOfKeys; 
        }
    }
    /// <summary>
    /// Concrete implementation of a key mapper for strings
    /// </summary>
    /// <remarks>this class is the default key mapper, used for bucket sort on strings</remarks>
    public class ILASCIIKeyMapper : ILKeyMapper<string, char> {
        /// <summary>
        /// map subelement to bucket 
        /// </summary>
        /// <param name="inSubelement">subelement to be mapped</param>
        /// <returns>ASCII code of the subelement character</returns>
        public override int  Map(char inSubelement) {
            return (int)inSubelement; 
        }
        /// <summary>
        /// Map char out of string with fallback
        /// </summary>
        /// <param name="element">full string item</param>
        /// <param name="position">position of character in string</param>
        /// <param name="fallback">fallback bucket number, if position is out of range</param>
        /// <returns>ASCII code for character specified, fallback on error</returns>
        public override int Map(string element, int position, int fallback) {
            if (element.Length > position)
                return (int)element[position]; 
            else 
                return fallback; 
        }
        /// <summary>
        /// give one char from string
        /// </summary>
        /// <param name="element">full string item</param>
        /// <param name="idx">character position in string</param>
        /// <returns>character in string</returns>
        /// <exception cref="IndexOutOfRangeException"> if idx is not within element ranges</exception>
        public override char  GetSubelement(string element, int idx) {
 	           return element[idx];
        }
        /// <summary>
        /// Count numer of characters in string
        /// </summary>
        /// <param name="element">element item</param>
        /// <returns>number of characters in string - length of string</returns>
        public override int SubelementsCount(string element) {
            if (object.Equals(element,null))
                return 0; 
            return element.Length;             
        }
        /// <summary>
        /// construct ASCII key mapper for 256 buckets
        /// </summary>
        public ILASCIIKeyMapper() : base(256) {}
    }
    /// <summary>
    /// Integer key mapper - sample implementation for bucket sort
    /// </summary>
    /// <remarks>This mapper may be used for sorting integers with bucketsort. 
    /// <para>The integers to be sorted must be positive and limited. It corresponds to the number of buckets to be created.</para>
    /// <para>This implementation serves as a sample implementation for bucket sort. You should consider using quicksort instead, which is implemented for ILMath.sort()</para></remarks>
    public class ILIntLimitedKeyMapper : ILKeyMapper<int,int> {
        /// <summary>
        /// Gives subelement - i.e. the element itself
        /// </summary>
        /// <param name="element">element</param>
        /// <param name="idx">(ignored)</param>
        /// <returns>element</returns>
        public override int GetSubelement(int element, int idx) {
            return element; 
        }
        /// <summary>
        /// map element - ignoring position &amp; fallback
        /// </summary>
        /// <param name="element">integer element</param>
        /// <param name="position">(ignored)</param>
        /// <param name="fallback">(ignored)</param>
        /// <returns>integer element</returns>
        public override int Map(int element, int position, int fallback) {
            return element; 
        }
        /// <summary>
        /// map (copy) subelement
        /// </summary>
        /// <param name="inSubelement">subelement</param>
        /// <returns>subelement</returns>
        public override int Map(int inSubelement) {
            return inSubelement; 
        }
        /// <summary>
        /// number of subelements in an element (Here: always 1)
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>1</returns>
        public override int SubelementsCount(int element) {
            return 1; 
        }
        /// <summary>
        /// construct integer key mapper
        /// </summary>
        /// <param name="limit">maximum number of buckets to be used</param>
        public ILIntLimitedKeyMapper (int limit) : base(limit) {} 
    }
}

