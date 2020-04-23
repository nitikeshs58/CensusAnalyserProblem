﻿using System;
using System.IO;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace CensusAnalyserProblem
{
    public class StateCensusAnalyser
    {
        // Variables
        string givenPath;
        int numberOfRecord;
        public char delimeter;

        public StateCensusAnalyser(string filePath = null)
        {
            givenPath=filePath;
        }

        // Main Method
        static void Main(string[] args)
        {

        }//end: static void Main(string[] args)

        // ReadRecords Method
        public object ReadRecords(string[] passHeader=null,char in_delimeter=',',string filePath=null)
        {
            try
            {
                if (!filePath.Contains(".csv"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_EXTENSION_OF_FILE, "Invalid Extension of file");
                }
                else if (!filePath.Contains(givenPath))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "Invalid file");
                }
                
                var records = new StreamReader(filePath);
                CsvReader csvRecords = new CsvReader(records);
                string[] headers = csvRecords.GetFieldHeaders();                
                delimeter = csvRecords.Delimiter;

                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, "Incorrect Delimeter");
                }
                else if (!IsHeaderSame(passHeader, headers))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER_ERROR, "Invalid Header");
                }
                while (csvRecords.ReadNextRecord())
                {
                    numberOfRecord++;
                }          
                return numberOfRecord;
            }
            catch(CensusAnalyserException file_not_found)
            {
                return file_not_found.Message;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }// End of ReadRecords

        //method will compare two headers 
        // if same return true , if not return false
        private bool IsHeaderSame(string[] passHeader, string[] headers)
        {
            if(passHeader.Length!=headers.Length)
            {
                return false;
            }
            for (int i = 0;i< headers.Length;i++)
            {
                // ToLower() :- Returns a copy of string converted to lowercase
                if(headers[i].ToLower().CompareTo(passHeader[i].ToLower())!=0)
                {
                    return false;
                }
            }
            return true;
        }//End of isHeadersame
    }//End of class StateCensusAnalyser            
}// End of namespace CensusAnalyserProblem

