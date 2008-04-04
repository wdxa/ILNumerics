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

namespace ILNumerics {
    /// <summary>
    /// Switches to set the detaching behavior for referencing storages. 
    /// </summary>
    /// <remarks>
    /// Special attention is to be made for altering ranges on reference storages. There are 
    /// cases where setting a value may alter other elements as well. This is true
    /// for elements "pointing" to the same physical array elements. If you dont want 
    /// this behavior, set this switch to 'DetachAlways' so you wont have to worry about 
    /// storages beeing references anymore. This behavior may be known as similar 
    /// to other mathematical engines (like Matlab f.e.).
    /// 
    /// The default switch is 'DetachOnWrite'.</remarks>
    public enum ILDetachingBehavior {
	    /// <summary>
	    /// if used, ILArray's will never automatically detach. This can 
        /// lead to situations, where altering the elements of one array also change 
        /// the elements of another array, if the second is referencing the same solid
        /// array elements. 
	    /// </summary>
        DetachNever,
        /// <summary>
        /// (default) - Referencing arrays will automatically detach 
        /// themself before attempting to alter any values used. The results are self 
        /// dereferencing arrays which act to the outside world, like they would 
        /// all consist out of solid storages, but internally save memory by not creating 
        /// any real copies of arrays as long as it is not absolutely neccessary.
        /// </summary>
	    DetachOnWrite,
        /// <summary>
        /// Attempts to create a reference of an existing array will result 
        /// in copying the values. This is the way other (native) mathematical engines usually handle 
        /// their storages. It consumes more memory, but will sometimes 
        /// lead to increased performance for large computations, since physical storages
        /// are optimized for faster element access.
        /// </summary>
	    DetachAlways,
        /// <summary>
        /// This value acts like 'DetachOnWrite' except a storage will not 
        /// be detached, if it is the only reference to the underlying physical storage.
        /// </summary>
	    DetachSave
    }

    /// <summary>
    /// Defines the way ILArrays are serialized to stream. Used by function ToStream. 
    /// </summary>
    /// <seealso cref="ILNumerics.ILArray&lt;BaseT&gt;.ToStream(System.IO.Stream,string,ILNumerics.ILArrayStreamSerializationFlags)"/>
    public enum ILArrayStreamSerializationFlags {
        /// <summary>
        /// print values 'vectorized': one value after each other. The true dimension configuration 
        /// of the array will be lost in the result. 
        /// </summary>
        Serial,
        /// <summary>
        /// print values 'matrixwise'. The real dimensions configuration for the array are kept 
        /// in the result. The array will be printed by pages, consisting out of the 1st and 2nd 
        /// leading dimnsion. A dimension tag will prefix each page. The format can be used as 
        /// fancier output version for human reading as well as human readable serialization 
        /// format. ILArray's are capable of constructing from streams containing this type of 
        /// output. 
        /// </summary>
        Formatted, 
        /// <summary>
        /// export whole array instance to matlab 5.0 format
        /// </summary>
        Matlab
    }
    /// <summary>
    /// possible properties for matrices 
    /// </summary>
    /// <remarks><para>These properties may be returned by function overloads receiving a MatrixProperties parameter by reference. The properties must be checked inside the function, the result is returned also.</para>
    /// <para><![CDATA[This enum is a bitflag'ed enum! You may query for any combination via the bitwise operators | and &. ]]></para></remarks>
    public enum MatrixProperties : int {
        /// <summary>
        /// hermitian matrix 
        /// </summary>
        Hermitian = 1,
        /// <summary>
        /// positive definite
        /// </summary>
        PositivDefinite = 2 ,
        /// <summary>
        /// upper triangular matrix
        /// </summary>
        UpperTriangular = 4,
        /// <summary>
        /// lower triangular matrix
        /// </summary>
        LowerTriangular = 8,
        /// <summary>
        /// square matrix
        /// </summary>
        Square = 16,
        /// <summary>
        /// diagonal matrix
        /// </summary>
        Diagonal = 32,
        /// <summary>
        /// the matrix is singular 
        /// </summary>
        Singular = 64,
        /// <summary>
        /// hessenberg matrix
        /// </summary>
        Hessenberg = 128,
        /// <summary>
        /// householder matrix
        /// </summary>
        Householder = 256,
        /// <summary>
        /// unitary matrix
        /// </summary>
        Unitary = 512,
        /// <summary>
        /// orthogonal matrix
        /// </summary>
        Orthogonal = 1024,
        /// <summary>
        /// orthonormal matrix
        /// </summary>
        Orthonormal = 2048,
        /// <summary>
        /// the matrix has deficient rank
        /// </summary>
        RankDeficient = 4096,
        /// <summary>
        /// nu specific properties (default)
        /// </summary>
        None = 0
    }
    /// <summary>
    /// Possible states for <see cref="ILNumerics.Algorithms.ILAsyncAlgorithm"/>
    /// </summary>
    public enum ILAlgorithmState {
        /// <summary>
        /// The algorithm was newly created
        /// </summary>
        Initialized,
        /// <summary>
        /// the algorithm is running normally 
        /// </summary>
        Running,
        /// <summary>
        /// the algorithm was temporarily suspended
        /// </summary>
        Suspended, 
        /// <summary>
        /// the algorithm finished successfully
        /// </summary>
        Finished,
        /// <summary>
        /// the algorithm was cancelled
        /// </summary>
        Canceled
    }  
}

