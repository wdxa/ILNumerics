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

#if IRONPYTHON

using System;
using System.Collections.Generic;
using System.Text;
using ILNumerics;
using ILNumerics.Exceptions;
using ILNumerics.Storage;
using ILNumerics.Misc;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace ILNumerics.BuiltInFunctions
{
    public partial class ILMath
    {
        /// <summary>
        /// Load data from text file (e.g. csv, xls, xlsx) 
        /// </summary>
        /// <param name="path">Path including filename</param>
        /// <returns>Best-fit ILArray or ILCell containing ILArrays</returns>
        /// <remarks>This routine is for quick loading: a custom text file may require custom code</remarks>
        public static ILBaseArray load(string path)
        {
            ILBaseArray baseArray = ILReader.LoadOLEDB(path);
            return baseArray;
        }

        /// <summary>
        /// Create ILArray or ILCell from CSV string
        /// </summary>
        /// <param name="text">CSV string</param>
        /// <returns>Best-fit ILArray or ILCell containing ILArrays</returns>
        public static ILBaseArray LoadFromString(string text)
        {
            ILBaseArray baseArray = ILReader.LoadOLEDBText(text);
            return baseArray;
        }
    }

    public static class ILReader
    {
        /// <summary>
        /// Create ILArray or ILCell from CSV string
        /// </summary>
        /// <param name="csvText">CSV string</param>
        /// <returns>Best-fit ILArray or ILCell containing ILArrays</returns>
        public static ILBaseArray LoadOLEDBText(string csvText)
        {
            string tempFile = Path.GetTempFileName();
            StreamWriter sw = new StreamWriter(tempFile);
            sw.Write(csvText);
            sw.Close();
            return LoadOLEDB(tempFile);
        }

        /// <summary>
        /// Load data from text file (e.g. csv, xls, xlsx) 
        /// </summary>
        /// <param name="path">Path including filename</param>
        /// <returns>Best-fit ILArray or ILCell containing ILArrays</returns>
        public static ILBaseArray LoadOLEDB(string path)
        {
            string connExcelXLS = "Provider=Microsoft.Jet.OLEDB.4.0;"
                + "Data Source={0};"
                + "Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=20;READONLY=TRUE\""; //READONLY=FALSE
            string connExcelXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source={0};"
                + "Extended Properties=\"Excel 12.0;HDR=YES;READONLY=TRUE\"";
            string connCSV = "Provider=Microsoft.Jet.OLEDB.4.0;"
                + "Data Source={0};"
                + "Extended Properties=\"text;HDR=No;FMT=Delimited\"";
            StringBuilder connString = new StringBuilder();
            StringBuilder queryString = new StringBuilder();
            string pathOnly = Path.GetFullPath(path).Substring(0, Path.GetFullPath(path).LastIndexOf('\\'));
            switch (Path.GetExtension(path))
            {
                case ".xls":
                    connString.AppendFormat(connExcelXLS, Path.GetFullPath(path));
                    queryString.Append("SELECT * FROM [Sheet1$]");
                    break;
                case ".xlsx":
                    connString.AppendFormat(connExcelXLSX, Path.GetFullPath(path));
                    queryString.Append("SELECT * FROM [Sheet1$]");
                    break;
                default:
                    connString.AppendFormat(connCSV, pathOnly + "\\");
                    queryString.Append("SELECT * FROM " + Path.GetFileName(path));
                    break;

            }
            OleDbConnection connection = new OleDbConnection(connString.ToString());
            OleDbCommand command = new OleDbCommand(queryString.ToString(), connection);
            //create an OleDbDataAdapter to execute the query
            DataSet dataSet = new DataSet();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(command);
            dAdapter.Fill(dataSet);
            // Now find types of columns and create appropriate ILArrays
            // Assume one table
            return ILCellFromDataTable(dataSet.Tables[0]);
        }

        public static ILBaseArray ILCellFromDataTable(DataTable dataTable)
        {
            int nColumns = dataTable.Columns.Count;
            ILBaseArray baseArray;
            // Check if last row is all null
            int nRows = dataTable.Rows.Count;
            int rowsToExclude;
            bool oneNonNull = true;
            for (int i = nRows - 1; i > 0; --i)
            {
                oneNonNull = false;
                for (int j = 0; j < nColumns; ++j)
                {
                    if (!(dataTable.Rows[i].IsNull(j)))
                    {
                        oneNonNull = true;
                    }
                }
                if (oneNonNull == false)
                {
                    dataTable.Rows[i].Delete();
                }
            }
            dataTable.AcceptChanges();
            nRows = dataTable.Rows.Count;
            // Check if all columns have the same type
            Type firstColumnType = dataTable.Columns[0].DataType;
            bool columnTypesDifferent = false;
            for (int i = 0; i < nColumns; ++i)
            {
                if (dataTable.Columns[i].DataType != firstColumnType)
                    columnTypesDifferent = true;
            }
            if (columnTypesDifferent)
            {
                baseArray = new ILCell(nColumns);
                for (int i = 0; i < nColumns; ++i)
                {
                    Type type = dataTable.Columns[i].DataType;
                    // need CreateInstance(Type t, int size)  really!
                    if (type == System.Type.GetType("System.Double"))
                        ((ILCell)baseArray)[i] = LoadILArrayFromDataColumn<double>(dataTable, i);
                    else if (type == System.Type.GetType("System.Single"))
                        ((ILCell)baseArray)[i] = LoadILArrayFromDataColumn<float>(dataTable, i);
                    else if (type == System.Type.GetType("System.Byte"))
                        ((ILCell)baseArray)[i] = LoadILArrayFromDataColumn<byte>(dataTable, i);
                    else if (type == System.Type.GetType("System.Int32"))
                        ((ILCell)baseArray)[i] = LoadILArrayFromDataColumn<int>(dataTable, i);
                    else if (type == System.Type.GetType("System.String"))
                        ((ILCell)baseArray)[i] = LoadILArrayFromDataColumn<string>(dataTable, i);
                }
            }
            else
            {
                if (firstColumnType == System.Type.GetType("System.Double"))
                    baseArray = LoadILArrayFromDataTable<double>(dataTable);
                else if (firstColumnType == System.Type.GetType("System.Single"))
                    baseArray = LoadILArrayFromDataTable<float>(dataTable);
                else if (firstColumnType == System.Type.GetType("System.Byte"))
                    baseArray = LoadILArrayFromDataTable<byte>(dataTable);
                else if (firstColumnType == System.Type.GetType("System.Int32"))
                    baseArray = LoadILArrayFromDataTable<int>(dataTable);
                else if (firstColumnType == System.Type.GetType("System.String"))
                    baseArray = LoadILArrayFromDataTable<string>(dataTable);
                else baseArray = new ILCell(1);
            }
            return baseArray;
        }

        private static ILArray<T> LoadILArrayFromDataColumn<T>(System.Data.DataTable table, int column)
        {
            int nRows = table.Rows.Count;
            int nColumns = table.Columns.Count;
            ILArray<T> array = new ILArray<T>(nRows);
            for (int i = 0; i < nRows; ++i)
            {
                object temp = table.Rows[i][column];
                if (temp is T)
                {
                    array[i] = (T)temp;
                }
            }
            return array;
        }

        private static ILArray<T> LoadILArrayFromDataTable<T>(System.Data.DataTable table)
        {
            int nRows = table.Rows.Count;
            int nColumns = table.Columns.Count;
            ILArray<T> array = new ILArray<T>(nRows);
            for (int i = 0; i < nRows; ++i)
            {
                for (int j = 0; j < nColumns; ++j)
                {
                    object temp = table.Rows[i][j];
                    if (temp is T)
                    {
                        array[i, j] = (T)temp;
                    }
                }
            }
            return array;
        }
    }
}

#endif