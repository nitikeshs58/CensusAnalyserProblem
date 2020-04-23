using System;
using System.IO;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace CensusAnalyserProblem
{
    public class CsvStates
    {
        public static string stateCodePath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
        // variables declaration
        string[] header;
        char delimeter;
        string givenPath;

        // CsvStates parameterised constructor
        public  CsvStates(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public object CsvStateCodeReadRecord()
        {
            StateCensusAnalyser stateCodePathObject = new StateCensusAnalyser(stateCodePath);
            var returnObject= stateCodePathObject.ReadRecords(header, delimeter,givenPath);
            return returnObject;
        }
    }//End of class CsvStates    
}// End of namespace CensusAnalyserProblem
