using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics.Storage;
using ILNumerics.Misc;

namespace ILNumerics.BuiltInFunctions {
	
	public sealed partial class ILMath {
#region helper constructs
        // binary elementwise functions returning logical
        private class OpLogical_DoubleDouble {
            internal byte eq(double in1, double in2) {
                return (in1 == in2) ? (byte)1 : (byte)0;
            }
            internal byte neq(double in1, double in2) {
                return (in1 != in2) ? (byte)1 : (byte)0;
            }
            internal byte lt(double in1, double in2) {
                return (in1 < in2) ? (byte)1 : (byte)0;
            }
            internal byte gt(double in1, double in2) {
                return (in1 > in2) ? (byte)1 : (byte)0;
            }
            internal byte le(double in1, double in2) {
                return (in1 <= in2) ? (byte)1 : (byte)0;
            }
            internal byte ge(double in1, double in2) {
                return (in1 >= in2) ? (byte)1 : (byte)0;
            }
        }
        // binary elementwise functions returning double
        private class OpDouble_DoubleDouble {
            internal double min(double in1, double in2) {
                return (in1 < in2) ? in1 : in2;
            }
            internal double max(double in1, double in2) {
                return (in1 > in2) ? in1 : in2;
            }
            internal double add(double in1, double in2) {
                return in1 + in2; 
            }
            internal double subtract(double in1, double in2) {
                return in1 - in2; 
            }
            internal double multiply(double in1, double in2) {
                return in1 * in2; 
            }
            internal double divide(double in1, double in2) {
                if (in2 != 0)
                    return in1 / in2; 
                return double.NaN; 
            }
        }
        // unary elementwise functions returning double 
        private class OpDouble_Double {
			internal delegate double dblOut_2dblIn(double in1, double parameter); 
			private double m_parameter; 
			dblOut_2dblIn m_applyFun;

			internal OpDouble_Double(double parameter, dblOut_2dblIn applyFunc) {
					m_parameter = parameter; 
					m_applyFun = applyFunc; 
			}
			internal double operate(double in1) {
				return m_applyFun(in1, m_parameter);
			}
			internal double add(double in1) {
				return in1 + m_parameter;
			}
            internal double subtractL(double in1) {
                return in1 - m_parameter;
            }
            internal double subtractR(double in1) {
                return  m_parameter - in1;
            }
            internal double divideL(double in1) {
                return in1 / m_parameter;
            }
            internal double divideR(double in1) {
                return m_parameter / in1;
            }
            internal double multiply(double in1) {
				return in1 * m_parameter;
			}
			internal double set(double discard){
				return m_parameter; 
			}
            internal double max(double in1) {
                return (in1 > m_parameter) ? in1 : m_parameter;
            }
            internal double min(double in1) {
                return (in1 < m_parameter) ? in1 : m_parameter;
            }
        }
		// unary elementwise functions returning logical
        private class OpLogical_Double {
            internal delegate byte boolOut_2dblIn(double in1, double parameter);
			private double m_parameter;
			boolOut_2dblIn m_applyFun;

			internal OpLogical_Double(double parameter, boolOut_2dblIn applyFunc) {
				m_parameter = parameter;
				m_applyFun = applyFunc;
			}
			internal byte operate(double in1) {
				return m_applyFun(in1, m_parameter);
			}
            internal byte eq(double in1) {
				return (in1 == m_parameter) ? (byte)1 : (byte)0;
			}
            internal byte neq(double in1) {
                return (in1 != m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte gt(double in1) {
                return (in1 > m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte lt(double in1) {
                return (in1 < m_parameter) ? (byte)1 : (byte)01;
            }
            internal byte ge(double in1) {
                return (in1 >= m_parameter) ? (byte)1 : (byte)0;
            }
            internal byte le(double in1) {
                return (in1 <= m_parameter) ? (byte)1 : (byte)0;
			}
		}

		public delegate double ILApplyDouble_Double(double in1);
        public delegate byte ILApplyLogical_Double(double in1);
        public delegate byte ILApplyLogical_DoubleDouble(double in1, double in2);
        public delegate double ILApplyDouble_DoubleDouble(double in1, double in2);
        public delegate int ILApplyInt_Logical(byte in1);
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new ILLogicalArray with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray2 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static ILLogicalArray LogicalBinaryDoubleOperator(ILArray<double> inArray1, ILArray<double> inArray2,
                                                     ILApplyLogical_DoubleDouble operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize(inArray2.Dimensions))
                throw new Exception("Array dimensions must match.");
            byte[] retBoolArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retBoolArr = new byte[newLength];
            int leadDim = 0;
            int leadDimLen = inDim[0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim[i]) {
                        leadDimLen = inDim[i];
                        leadDim = i;
                    }
                }
                ILIterator<double> it1 = inArray1.CreateIterator(ILIteratorPositions.ILEnd, leadDim);
                ILIterator<double> it2 = inArray2.CreateIterator(ILIteratorPositions.ILEnd, leadDim);
                unsafe {
                    fixed (byte* pOutArr = retBoolArr) {
                        byte* poutarr = pOutArr;
                        byte* outEnd = poutarr + newLength;
                        while (poutarr < outEnd) {
                            *poutarr++ = operation(it1.Increment(), it2.Increment());
                        }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed (double* pInArr1 = inArray1.m_data,
                            pInArr2 = inArray2.m_data) {
                        fixed (byte* pOutArr = retBoolArr) {
                            byte* poutarr = pOutArr;
                            byte* poutend = poutarr + newLength;
                            double* pIn1 = pInArr1;
                            double* pIn2 = pInArr2;
                            while (poutarr < poutend)
                                *poutarr++ = operation(*pIn1++, *pIn2++);
                        }
                    }
                }
                #endregion
            }
            return new ILLogicalArray(retBoolArr, inDim.ToIntArray());
        }
        /// <summary>
        /// operate on elements of both storages by the given function -> relational operations 
        /// </summary>
        /// <param name="inArray1">First storage array</param>
        /// <param name="inArray2">Second storage array</param>
        /// <param name="operation">operation to apply to the elements of inArray. This
        /// acts like a function pointer.</param>
        /// <returns>new ILLogicalArray with result of operation for corresponding 
        /// elements of both arrays.</returns>
        /// <remarks>The values of inArray2 nor inArray2 will not be altered.The dimensions 
        /// of both arrays must match.</remarks>
        private static ILArray<double> DoubleBinaryDoubleOperator(ILArray<double> inArray1, ILArray<double> inArray2,
                                                     ILApplyDouble_DoubleDouble operation) {
            ILDimension inDim = inArray1.Dimensions;
            if (!inDim.IsSameSize(inArray2.Dimensions))
                throw new Exception("Array dimensions must match.");
            double[] retBoolArr;
            // build ILDimension
            int newLength = inDim.NumberOfElements;
            retBoolArr = new double[newLength];
            int leadDim = 0;
            int leadDimLen = inDim[0];
            if (inArray1.IsReference || inArray2.IsReference) {
                // this will most probably be not very fast, but .... :|
                #region Reference storage
                // walk along the longest dimension (for performance reasons)
                for (int i = 1; i < inDim.NumberOfDimensions; i++) {
                    if (leadDimLen < inDim[i]) {
                        leadDimLen = inDim[i];
                        leadDim = i;
                    }
                }
                ILIterator<double> it1 = inArray1.CreateIterator(ILIteratorPositions.ILEnd, leadDim);
                ILIterator<double> it2 = inArray2.CreateIterator(ILIteratorPositions.ILEnd, leadDim);
                unsafe {
                    fixed (double* pOutArr = retBoolArr) {
                        double* poutarr = pOutArr;
                        double* outEnd = poutarr + newLength;
                        while (poutarr < outEnd) {
                            *poutarr++ = operation(it1.Increment(), it2.Increment());
                        }
                    }
                }
                // ==============================================================
                #endregion
            } else {
                // physical -> pointer arithmetic
                #region physical storage
                unsafe {
                    fixed (double* pInArr1 = inArray1.m_data,
                            pInArr2 = inArray2.m_data) {
                        fixed (double* pOutArr = retBoolArr) {
                            double* poutarr = pOutArr;
                            double* poutend = poutarr + newLength;
                            double* pIn1 = pInArr1;
                            double* pIn2 = pInArr2;
                            while (poutarr < poutend)
                                *poutarr++ = operation(*pIn1++, *pIn2++);
                        }
                    }
                }
                #endregion
            }
            return new ILArray<double>(retBoolArr, inDim.ToIntArray());
        }
        /// <summary>
		/// Applys the function (delegate) given to all elements of the storage
		/// </summary>
		/// <param name="inArray">storage array to apply the function to</param>
		/// <param name="operation">operation to apply to the elements of inArray. This
		/// acts like a function pointer.</param>
		/// <returns>new ILArray<double> with result</returns>
		/// <remarks> the values of inArray will not be altered.</remarks>
		private static ILArray<double> DoubleUnaryDoubleOperator(ILArray<double> inArray, ILApplyDouble_Double operation) {
			ILDimension inDim = inArray.Dimensions;
			double[] retDblArr;
			// build ILDimension
			int newLength = inDim.NumberOfElements;
			retDblArr = new double[newLength];
			int leadDim = 0;
			int leadDimLen = inDim[0];
			if (inArray.IsReference) {
				#region Reference storage
				// walk along the longest dimension (for performance reasons)
				for (int i = 1; i < inDim.NumberOfDimensions; i++) {
					if (leadDimLen < inDim[i]) {
						leadDimLen = inDim[i];
						leadDim = i;
					}
				}
				ILIndexOffset idxOffset = inArray.m_indexOffset;
				int incOut = inDim.SequentialIndexDistance(leadDim);
				// ========================  REFERENCE double Storage ===========
				if (inArray.IsMatrix) {
					#region Matrix
					////////////////////////////   MATRIX   ////////////////////
					int secDim = (leadDim + 1) % 2;
					unsafe {
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* tmpIn = pInArr;
								double* tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
								int* secDimEnd = secDimStart + idxOffset[secDim].Length;
								int* secDimIdx = secDimStart;
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + idxOffset[secDim].Length; ;
								while (secDimIdx < secDimEnd) {
									tmpIn = pInArr + *secDimIdx++;
									leadDimIdx = leadDimStart;
									while (leadDimIdx < leadDimEnd) {
										*tmpOut = operation(*(tmpIn + *leadDimIdx++));
										tmpOut += incOut;
									}
									if (tmpOut > tmpOutEnd)
										tmpOut = pOutArr + (tmpOutEnd - tmpOut);
								}
							}
						}
					}
					#endregion
				} else if (inArray.IsVector) {
					#region Vector
					////////////////////////////   VECTOR   ///////////////////////
					unsafe {
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* tmpIn = pInArr + idxOffset[((leadDim + 1) % 2), 0];
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								// start at first element
								while (leadDimIdx < leadDimEnd)
									*tmpOut++ = operation(*(tmpIn + *leadDimIdx++));
							}
						}
					}
					#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
					#region arbitrary size
					unsafe {
						int[] curPosition = new int[inArray.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
							fixed (double* pOutArr = retDblArr,
									pInArr = inArray.m_data) {
								double* tmpOut = pOutArr;
								double* tmpOutEnd = tmpOut + retDblArr.Length;
								// init lesezeiger: add alle Dimensionen mit 0 (außer leadDim)
								double* tmpIn = pInArr + inArray.getBaseIndex(0, 0);
								tmpIn -= idxOffset[leadDim, 0];
								int* leadDimIdx = leadDimStart;
								int* leadDimEnd = leadDimStart + leadDimLen;
								int dimLen = curPosition.Length;
								int d, curD;
								// start at first element
								while (tmpOut < tmpOutEnd) {
									leadDimIdx = leadDimStart;
									while (leadDimIdx < leadDimEnd) {
										*tmpOut = operation(*(tmpIn + *leadDimIdx++));
										tmpOut += incOut;
									}
									if (tmpOut > tmpOutEnd)
										tmpOut = pOutArr + (tmpOutEnd - tmpOut);

									// increment higher dimensions 
									d = 1;
									while (d < dimLen) {
										curD = (d + leadDim) % dimLen;
										tmpIn -= idxOffset[curD, curPosition[curD]];
										curPosition[curD]++;
										if (curPosition[curD] < idxOffset[curD].Length) {
											tmpIn += idxOffset[curD, curPosition[curD]];
											break;
										}
										curPosition[curD] = 0;
										tmpIn += idxOffset[curD, 0];
										d++;
									}
								}
							}
						}
					}
					#endregion
				}
				// ==============================================================
				#endregion
			} else {
				// physical -> pointer arithmetic
				#region physical storage
				unsafe {
					fixed (double* pOutArr = retDblArr,
							pInArr = inArray.m_data) {
						double* lastElement = pOutArr + retDblArr.Length;
						double* tmpOut = pOutArr;
						double* tmpIn = pInArr;
						while (tmpOut < lastElement)
							*tmpOut++ = operation(*tmpIn++);
					}
				}
				#endregion
			}
			return new ILArray<double>(retDblArr, inDim.ToIntArray());
		}
		/// <summary>
		/// Applys the function (delegate) given to all elements of the storage
		/// </summary>
		/// <param name="inArray">storage array to be apply the function to</param>
		/// <param name="operation">operation to apply to the elements of inArray. This
		/// acts like a function pointer.</param>
		/// <returns>new ILArray<double> with result</returns>
		/// <remarks> the values of inArray will not be altered.</remarks>
		private static ILLogicalArray LogicalUnaryDoubleOperator(ILArray<double> inArray, ILApplyLogical_Double operation) {
			ILDimension inDim = inArray.Dimensions;
            byte[] retByteArr;
			// build ILDimension
			int newLength = inDim.NumberOfElements;
            retByteArr = new byte[newLength];
			int leadDim = 0;
			int leadDimLen = inDim[0];
			if (inArray.IsReference) {
				#region Reference storage
				// walk along the longest dimension (for performance reasons)
				for (int i = 1; i < inDim.NumberOfDimensions; i++) {
					if (leadDimLen < inDim[i]) {
						leadDimLen = inDim[i];
						leadDim = i;
					}
				}
				ILIndexOffset idxOffset = inArray.m_indexOffset;
				int incOut = inDim.SequentialIndexDistance(leadDim);
				// ========================  REFERENCE double Storage ===========
				if (inArray.IsMatrix) {
					#region Matrix
					////////////////////////////   MATRIX   ////////////////////
					int secDim = (leadDim + 1) % 2;
					unsafe {
						fixed (int* leadDimStart = idxOffset[leadDim],
								secDimStart = idxOffset[secDim]) {
                            fixed (byte* pOutArr = retByteArr) {
								fixed (double* pInArr = inArray.m_data) {
                                    byte* tmpOut = pOutArr;
									double* tmpIn = pInArr;
                                    byte* tmpOutEnd = pOutArr + inDim.NumberOfElements - 1;
									int* secDimEnd = secDimStart + idxOffset[secDim].Length;
									int* secDimIdx = secDimStart;
									int* leadDimIdx = leadDimStart;
									int* leadDimEnd = leadDimStart + idxOffset[secDim].Length; ;
									while (secDimIdx < secDimEnd) {
										tmpIn = pInArr + *secDimIdx++;
										leadDimIdx = leadDimStart;
										while (leadDimIdx < leadDimEnd) {
											*tmpOut = operation(*(tmpIn + *leadDimIdx++));
											tmpOut += incOut;
										}
										if (tmpOut > tmpOutEnd)
											tmpOut = pOutArr + (tmpOutEnd - tmpOut);
									}
								}
							}
						}
					}
					#endregion
				} else if (inArray.IsVector) {
					#region Vector
					////////////////////////////   VECTOR   ///////////////////////
					unsafe {
						fixed (int* leadDimStart = idxOffset[leadDim]) {
                            fixed (byte* pOutArr = retByteArr) {
								fixed (double* pInArr = inArray.m_data) {
                                    byte* tmpOut = pOutArr;
									double* tmpIn = pInArr + idxOffset[((leadDim + 1) % 2), 0];
									int* leadDimIdx = leadDimStart;
									int* leadDimEnd = leadDimStart + leadDimLen;
									// start at first element
									while (leadDimIdx < leadDimEnd)
										*tmpOut++ = operation(*(tmpIn + *leadDimIdx++));
								}
							}
						}
					}
					#endregion
				} else {
					/////////////////////////////   ARBITRARY DIMENSIONS //////////
					#region arbitrary size
					unsafe {
						int[] curPosition = new int[inArray.Dimensions.NumberOfDimensions];
						fixed (int* leadDimStart = idxOffset[leadDim]) {
                            fixed (byte* pOutArr = retByteArr) {
								fixed (double* pInArr = inArray.m_data) {
                                    byte* tmpOut = pOutArr;
                                    byte* tmpOutEnd = tmpOut + retByteArr.Length;
									// init lesezeiger: add alle Dimensionen mit 0 (außer leadDim)
									double* tmpIn = pInArr + inArray.getBaseIndex(0, 0);
									tmpIn -= idxOffset[leadDim, 0];
									int* leadDimIdx = leadDimStart;
									int* leadDimEnd = leadDimStart + leadDimLen;
									int dimLen = curPosition.Length;
									int d, curD;
									// start at first element
									while (tmpOut < tmpOutEnd) {
										leadDimIdx = leadDimStart;
										while (leadDimIdx < leadDimEnd) {
											*tmpOut = operation(*(tmpIn + *leadDimIdx++));
											tmpOut += incOut;
										}
										if (tmpOut > tmpOutEnd)
											tmpOut = pOutArr + (tmpOutEnd - tmpOut);

										// increment higher dimensions 
										d = 1;
										while (d < dimLen) {
											curD = (d + leadDim) % dimLen;
											tmpIn -= idxOffset[curD, curPosition[curD]];
											curPosition[curD]++;
											if (curPosition[curD] < idxOffset[curD].Length) {
												tmpIn += idxOffset[curD, curPosition[curD]];
												break;
											}
											curPosition[curD] = 0;
											tmpIn += idxOffset[curD, 0];
											d++;
										}
									}
								}
							}
						}
					}
					#endregion
				}
				// ==============================================================
				#endregion
			} else {
				// physical -> pointer arithmetic
				#region physical storage
				unsafe {
                    fixed (byte* pOutArr = retByteArr) {
						fixed (double* pInArr = inArray.m_data) {
                            byte* lastElement = pOutArr + retByteArr.Length;
                            byte* tmpOut = pOutArr;
							double* tmpIn = pInArr;
							while (tmpOut < lastElement)
								*tmpOut++ = operation(*tmpIn++);
						}
					}
				}
				#endregion
			}
			return new ILLogicalArray(retByteArr, inDim.ToIntArray());
		}
        
#endregion

#region Unary Functions  Basic Math

		public static ILArray<double> Abs(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Abs);
		}
		public static ILArray<double> Acos(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Acos);
		}
		public static ILArray<double> Asin(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Asin);
		}
		public static ILArray<double> Atan(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Atan);
		}
		public static ILArray<double> Ceiling(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Ceiling);
		}
		public static ILArray<double> Cos(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Cos);
		}
		public static ILArray<double> Cosh(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Cosh);
		}
		public static ILArray<double> Exp(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Exp);
		}
		public static ILArray<double> Floor(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Floor);
		}
		public static ILArray<double> Log(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Log);
		}
		public static ILArray<double> Log10(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Log10);
		}
		public static ILArray<double> Round(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Round);
		}
		private static double Sign(double inDbl) {
			return (double)Math.Sign(inDbl);
		}
		public static ILArray<double> Sign(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Sign);
		}
		public static ILArray<double> Sin(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Sin);
		}
		public static ILArray<double> Sinh(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Sinh);
		}
		public static ILArray<double> Sqrt(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Sqrt);
		}
		public static ILArray<double> Tan(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Tan);
		}
		public static ILArray<double> Tanh(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Tanh);
		}
		public static ILArray<double> Truncate(ILArray<double> inArray) {
			return DoubleUnaryDoubleOperator(inArray, Math.Truncate);
		}
		public static ILArray<double> Pow(ILArray<double> inArray, double parameter) {
			OpDouble_Double helper = new OpDouble_Double(parameter, Math.Pow);
			return DoubleUnaryDoubleOperator(inArray, helper.operate);
		}
		public static ILArray<double> Add(ILArray<double> inArray, double parameter) {
			OpDouble_Double helper = new OpDouble_Double(parameter, null);
			return DoubleUnaryDoubleOperator(inArray, helper.add);
		}
        public static ILArray<double> SubtractL(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.subtractL);
        }
        public static ILArray<double> SubtractR(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.subtractR);
        }
        public static ILArray<double> DivideL(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.divideL);
        }
        public static ILArray<double> DivideR(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.divideR);
        }
        public static ILArray<double> Multiply(ILArray<double> inArray, double parameter) {
			OpDouble_Double helper = new OpDouble_Double(parameter, null);
			return DoubleUnaryDoubleOperator(inArray, helper.multiply);
		}
		public static ILArray<double> Set(ILArray<double> inArray, double parameter) {
			OpDouble_Double helper = new OpDouble_Double(parameter, null);
			return DoubleUnaryDoubleOperator(inArray, helper.set);
		}
        public static ILArray<double> Max(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.max);
        }
        public static ILArray<double> Min(ILArray<double> inArray, double parameter) {
            OpDouble_Double helper = new OpDouble_Double(parameter, null);
            return DoubleUnaryDoubleOperator(inArray, helper.min);
        }
#endregion

#region Array Creation
		//////////////////////////////   ONES / ZEROS ... ////////////////////////////////
		public static ILArray<double> Ones(params int[] dimensions) {
			ILDimension dim = new ILDimension(dimensions);
			double[] data = new double[dim.NumberOfElements];
			ILArray<double> ret = new ILArray<double>(data, dimensions);
			return Set(ret, 1.0); 
			{/* unsafe {
				fixed(double* pData = data) {
					double* ende = pData + data.Length; 
					double* curr = pData; 
					while (curr < ende) 
						*curr++ = 1.0; 
			}*/
			}
		}
		public static ILArray<double> Zeros(params int[] dimensions) {
			ILDimension dim = new ILDimension(dimensions);
			double[] data = new double[dim.NumberOfElements];
			return new ILArray<double>(data, dimensions);
		}
        public static ILArray<double> Eye(int rows, int columns) {
            ILArray<double> ret = Zeros(rows, columns);
            int diagLen = Math.Min(rows, columns);
            for (int i = 0; i < diagLen; i++)
                ret[i, i] = 1.0;
            return ret;
        }
        /// <summary>
        /// random n-dimensional array elements
        /// </summary>
        /// <param name="dimensions">int array or single int paramters specifying 
        /// dimensions for new array to be created</param>
        /// <returns>n-dimensional array filled with random numbers.</returns>
        /// <remarks>the elements lay within the range 0.0 ... 1.0 and are uniformly 
        /// distributed.</remarks>
        public static ILArray<double> Rand(params int[] dimensions) {
            ILDimension dim = new ILDimension(dimensions);
            double[] data = new double[dim.NumberOfElements];
            unsafe {
                fixed (double* pRetArray = data) {
                    double* pCurIdx = pRetArray;
                    double* pLastElement = pCurIdx + dim.NumberOfElements;
                    Random r = new Random((int)System.Environment.TickCount);
                    while (pCurIdx < pLastElement)
                        *pCurIdx++ = r.NextDouble();
                }
            }
            return new ILArray<double>(data, dimensions);
        }
#endregion

#region Relational (binary)  Operators
		////////////////////////////////  RELOP //////////////////////////////////
		public static ILLogicalArray eq(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.eq);
		}
		public static ILLogicalArray neq(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.neq);
		}
		public static ILLogicalArray le(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.le);
		}
		public static ILLogicalArray ge(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.ge);
		}
		public static ILLogicalArray lt(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.lt);
		}
		public static ILLogicalArray gt(ILArray<double> Array1, ILArray<double> Array2) {
			OpLogical_DoubleDouble helper = new OpLogical_DoubleDouble();
			return LogicalBinaryDoubleOperator(Array1, Array2, helper.gt);
		}
#endregion

#region relational with scalars
        // RELOP with scalars 
		public static ILLogicalArray eq(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.eq);
		}
		public static ILLogicalArray neq(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.neq);
		}
		public static ILLogicalArray le(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.le);
		}
		public static ILLogicalArray ge(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.ge);
		}
		public static ILLogicalArray lt(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.lt);
		}
		public static ILLogicalArray gt(ILArray<double> Array1, double Array2) {
			OpLogical_Double helper = new OpLogical_Double(Array2, null);
			return LogicalUnaryDoubleOperator(Array1, helper.gt);
		}
#endregion

#region Binary functions Basic Math
        public static ILArray<double> Add(ILArray<double> Array1, ILArray<double> Array2) {
            if (Array1.IsScalar) {
                if (Array2.IsScalar)
                    return new ILArray<double>(new double[1] { Array1[0, 0] + Array2[0, 0] }, 1, 1);
                else {
                    OpDouble_Double helper = new OpDouble_Double(Array1[0, 0], null);
                    return DoubleUnaryDoubleOperator(Array2, helper.add);
                }
            } else if (Array2.IsScalar) {
                OpDouble_Double helper = new OpDouble_Double(Array2[0, 0], null);
                return DoubleUnaryDoubleOperator(Array1, helper.add);
            } else {
                OpDouble_DoubleDouble helper = new OpDouble_DoubleDouble();
                return DoubleBinaryDoubleOperator(Array1, Array2, helper.add);
            }
        }
        public static ILArray<double> Subtract(ILArray<double> Array1, ILArray<double> Array2) {
            if (Array1.IsScalar) {
                if (Array2.IsScalar)
                    return new ILArray<double>(new double[1] { Array1[0, 0] - Array2[0, 0] }, 1, 1);
                else {
                    OpDouble_Double helper = new OpDouble_Double(Array1[0, 0], null);
                    return DoubleUnaryDoubleOperator(Array2, helper.subtractR);
                }
            } else if (Array2.IsScalar) {
                OpDouble_Double helper = new OpDouble_Double(Array2[0, 0], null);
                return DoubleUnaryDoubleOperator(Array1, helper.subtractL);
            } else {
                OpDouble_DoubleDouble helper = new OpDouble_DoubleDouble();
                return DoubleBinaryDoubleOperator(Array1, Array2, helper.subtract);
            }
        }
        public static ILArray<double> MultiplyElements(ILArray<double> Array1, ILArray<double> Array2) {
            if (Array1.IsScalar) {
                if (Array2.IsScalar)
                    return new ILArray<double>(new double[1] { Array1[0, 0] * Array2[0, 0] }, 1, 1);
                else {
                    OpDouble_Double helper = new OpDouble_Double(Array1[0, 0],null);
                    return DoubleUnaryDoubleOperator(Array2, helper.multiply);
                }
            } else if (Array2.IsScalar) {
                OpDouble_Double helper = new OpDouble_Double(Array2[0, 0], null);
                return DoubleUnaryDoubleOperator(Array1, helper.multiply);
            } else {
                OpDouble_DoubleDouble helper = new OpDouble_DoubleDouble();
                return DoubleBinaryDoubleOperator(Array1, Array2, helper.multiply);
            }
        }
        public static ILArray<double> Divide(ILArray<double> Array1, ILArray<double> Array2) {
            if (Array1.IsScalar) {
                if (Array2.IsScalar) {
                    double tmp = Array2[0, 0];
                    if (tmp != 0)
                        return new ILArray<double>(new double[1] { Array1[0, 0] / tmp }, 1, 1);
                    else
                        return new ILArray<double>(new double[1] { double.NaN }, 1, 1);
                } else {
                    OpDouble_Double helper = new OpDouble_Double(Array1[0, 0], null);
                    return DoubleUnaryDoubleOperator(Array2, helper.divideR);
                }
            } else if (Array2.IsScalar) {
                OpDouble_Double helper = new OpDouble_Double(Array2[0, 0], null);
                return DoubleUnaryDoubleOperator(Array1, helper.divideL);
            } else {
                OpDouble_DoubleDouble helper = new OpDouble_DoubleDouble();
                return DoubleBinaryDoubleOperator(Array1, Array2, helper.divide);
            }
        }
#endregion

    }
}
