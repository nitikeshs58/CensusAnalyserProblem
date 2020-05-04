///-----------------------------------------------------------------------------
///   Class:--------> CsvStates                                                  
///   Description:--> Created parameterised constructor and                      
///                   delegate object CsvStateCodeData                         
///                   Method calling for CsvStateCensusReadRecord is done.                        
///   Author:-------> Nitikesh Shinde                     Date: 01/05/2020       
///-----------------------------------------------------------------------------

using System;

namespace CensusAnalyserProblem
{
    public class CsvStatesDao : ICSVBuilder
    {
        public static string stateCodePath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
        // variables declaration
        public string stateCensusFilePath;
        public char delimeter;
        public string[] header;
        public string givenPath;

        // Default Constructor
        public CsvStatesDao()
        {
        }

        // CsvStates parameterised constructor
        public CsvStatesDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCodeDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCodePathObject = new CsvStateCensusReadRecord(stateCodePath);
            var returnObject = stateCodePathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            // we have method 
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
    }//End of class CsvStates    
}// End of namespace CensusAnalyserProblem