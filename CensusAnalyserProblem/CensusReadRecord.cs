﻿///-------------------------------------------------------------------------------
///   Class:--------> CsvStateCensusReadRecord
///   Description:--> Read records/fields of csv files and Returned required output
///                   as Exception message or values to pass Test Cases.
///   Author:-------> Nitikesh Shinde                     Date: 01/05/2020
///-------------------------------------------------------------------------------

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace CensusAnalyserProblem
{
    public class CsvStateCensusReadRecord
    {
        // Variables
        string actualPath;
        char delimeter;
        int numberOfRecord;

        // Default Constrructor
        public CsvStateCensusReadRecord()
        {
        }

        //Parameterised constructor
        public CsvStateCensusReadRecord(string filePath = null)
        {
            this.actualPath = filePath;
        }

        /// <ReadRecords>
        /// Reading the Records of the given filePath
        /// Return value or an Exception message to pass the test case.
        /// </summary>
        /// <param name="passHeader"></param>
        /// <param name="in_delimeter"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object ReadRecords(string[] passHeader = null, char in_delimeter = ',', string filePath = null)
        {
            try
            {
                if (!filePath.Contains(".csv"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_EXTENSION_OF_FILE, "Invalid Extension of file");
                }
                else if (!filePath.Contains(actualPath))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "Invalid file");
                }

                // streams are used to read/write data from large files
                //CsvReader is open source C# library to read CSV data from strings/textFiles
                CsvReader csvRecords = new CsvReader(new StreamReader(filePath), true);
                int fieldCount = csvRecords.FieldCount;
                string[] headers = csvRecords.GetFieldHeaders();
                delimeter = csvRecords.Delimiter;
                // string ArrayList
                List<string[]> record = new List<string[]>();
                while (csvRecords.ReadNextRecord())
                {
                    string[] tempRecord = new string[fieldCount];
                    csvRecords.CopyCurrentRecordTo(tempRecord);
                    record.Add(tempRecord);
                    numberOfRecord++;
                }

                if (numberOfRecord == 0)
                {
                    throw new CSVException(CSVException.ExceptionType.FILE_IS_EMPTY, "File has no data");
                }
                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, "Incorrect Delimeter");
                }
                else if (!IsHeaderSame(passHeader, headers))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER_ERROR, "Invalid Header");
                }
                return numberOfRecord;
            }
            catch (CensusAnalyserException file_not_found)
            {
                return file_not_found.Message;
            }
            catch (CSVException emptyFileException)
            {
                return emptyFileException.Message;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }// End of ReadRecords

        //method will compare two headers 
        // if same return true , if not return false
        private bool IsHeaderSame(string[] passHeader, string[] headers)
        {
            if (passHeader.Length != headers.Length)
            {
                return false;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                // ToLower() :- Returns a copy of string converted to lowercase
                if (headers[i].ToLower().CompareTo(passHeader[i].ToLower()) != 0)
                {
                    return false;
                }
            }
            return true;
        }//End of isHeadersame

        /// <SortingJsonBasedOnKey>
        /// Sorting String based on Key and Returning sorted array. 
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JArray SortingJsonBasedOnKey(string jsonFilePath, string key)
        {
            string jsonFile = File.ReadAllText(jsonFilePath);
            JArray CensusArray = JArray.Parse(jsonFile);
            //bubble sort
            for (int i = 0; i < CensusArray.Count - 1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i - 1; j++)
                {
                    if (CensusArray[j][key].ToString().CompareTo(CensusArray[j + 1][key].ToString()) > 0)
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }

        /// <summary>
        /// Sorting interger based on Key and Returning sorted array. 
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JArray SortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray CensusArray = JArray.Parse(jsonFile);
            //sorting in sorting in ascending order
            for (int i = 0; i < CensusArray.Count-1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i-1; j++)
                {
                    if ((int)CensusArray[j][key] > (int)CensusArray[j + 1][key])
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }

        /// <summary>
        /// Method to retrive the first state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string firstValue = jArray[0][key].ToString();
            return firstValue;
        }
        /// <summary>
        /// Method to retrive the last state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string lastValue = jArray[jArray.Count - 1][key].ToString();
            return lastValue;
        }
    }
}