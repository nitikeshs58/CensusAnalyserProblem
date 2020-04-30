using System;

namespace CensusAnalyserProblem
{
    public class CsvStates : ICSVBuilder
    {
        public static string stateCodePath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
        // variables declaration
        readonly string[] header;
        readonly char delimeter;
        readonly string givenPath;

        // Default Constructor
        public CsvStates()
        {
        }

        // CsvStates parameterised constructor
        public CsvStates(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCodeData(string[] header, char delimeter, string givenPath);

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

        private static CsvStates InstanceOfCsvStates()
        {
            throw new NotImplementedException();
        }

        private static StateCensusAnalyser InstanceOfStateCensusAnalyser()
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }//End of class CsvStates    
}// End of namespace CensusAnalyserProblem