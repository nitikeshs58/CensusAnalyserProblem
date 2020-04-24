using System;

namespace CensusAnalyserProblem
{
    public class StateCensusAnalyser
    {
        public static string stateCensusPath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
        // variables declaration
        string[] header;
        char delimeter;
        string givenPath;

        // Main Method
        static void Main(string[] args)
        {
        }//end: static void Main(string[] args)

        // Default Constructor
        public StateCensusAnalyser()
        {
        }

        // CsvStates parameterised constructor
        public StateCensusAnalyser(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCensusData(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'CensusReadRecord' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCensusPathObject = new CsvStateCensusReadRecord(stateCensusPath);
            var returnObject = stateCensusPathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        } 
    }//End of class StateCensusAnalyser            
}// End of namespace CensusAnalyserProblem

