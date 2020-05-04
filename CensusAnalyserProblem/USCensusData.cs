///-----------------------------------------------------------------------------
///   Class:--------> USCensusData                                                  
///   Description:--> Created parameterised constructor and                      
///                   delegate object CsvUSCensusData                         
///                   Method calling for CsvStateCensusReadRecord is done.                        
///   Author:-------> Nitikesh Shinde                     Date: 04/05/2020       
///-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class USCensusDataDao : ICSVBuilder
    {
        public static string USDataPath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\USCensusData.csv";
        // variables declaration
        public string stateCensusFilePath { get; set; }
        public char delimeter { get; set; }
        public string[] header { get; set; }
        public string givenPath { get; set; }

        // Default Constructor
        public USCensusDataDao()
        {
        }

        // CsvStates parameterised constructor
        public USCensusDataDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvUSCensusDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord usCensusDataPathObject = new CsvStateCensusReadRecord(USDataPath);
            var returnObject = usCensusDataPathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }
}
