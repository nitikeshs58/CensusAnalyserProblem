using CensusAnalyserProblem;
using NUnit.Framework;
using static CensusAnalyserProblem.StateCensusAnalyser;
using static CensusAnalyserProblem.CsvStates;

namespace Tests
{
    public class CensusTests
    {
        //with NameSpace Assembly reference 
        // DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusData stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeData stateCode = CSVFactory.DelegateOfCsvStates();
        public string jsonPathstateCensus = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.json";
        public string jsonPathstateCode = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.json";
        [SetUp]
        public void Setup()
        {
        }

        /// <Test1 :CheckNumberOfRecordsMatches>
        /// #Creating object as a 'censusPath' of class 'StateCensusAnalyser'
        /// and getting path of 'StateCensusData.csv' file.
        /// #calling 'NumberOfRecords' method and getting numberOfRecords
        /// #matching expected records with numberOfRecords.
        /// </Test1 :CheckNumberOfRecordsMatches>
        [Test]
        public void CheckNumberOfRecordsMatches()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
            var numberOfRecords = stateCensus(header, delimeter, path);
            Assert.AreEqual(29, numberOfRecords);
        }

        /// <Test2 :CheckIncorrectCSVFile>
        ///#Sent Incorrect CSV file name : 'StateCensusDataIncorrect.csv'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid file"
        ///test case passes
        /// </Test2 :CheckIncorrectCSVFile>
        [Test]
        public void CheckIncorrectCSVFile()
        {
            string incorrectPath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrect.csv";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage = stateCensus(header, delimeter, incorrectPath);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <Test3 :CheckCorrectDotExtensionFile>
        ///#Sent Incorrect Extension of file : '.txt'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid Extension of file"
        ///test case passes
        /// </Test3 :CheckCorrectDotExtensionFile>
        [Test]
        public void CheckCorrectDotExtensionFile()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string inCorrectExtensionPath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.txt";
            object exceptionMessage = stateCensus(header, delimeter, inCorrectExtensionPath);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <Test4 :CheckInCorrectDelimeter>
        ///#Sent user delimeter : ';'
        ///#CSV File if incorrect Returns a custom Exception as "Incorrect Delimeter"
        ///test case passes
        /// </Test4 :CheckInCorrectDelimeter>
        [Test]
        public void CheckInCorrectDelimeter()
        {
            char userDelimeter = ';';
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
            object exceptionMessage = stateCensus(null, userDelimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <Test5 :CheckInvalidHeader>
        ///#Sending inValid header[] 
        ///#Comparing with actual header of csv file and returning exception message
        ///message is same then, test case passes
        /// </Test5 :CheckInvalidHeader>
        [Test]
        public void CheckInvalidHeader()
        {
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            char userDelimeter = ',';
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
            object exceptionMessage = stateCensus(header, userDelimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }


        /// <Test6 :CheckNumberOfRecordsMatchesStateCode>
        /// #Creating object as a 'stateCodePath' of class 'CsvStates'
        /// and getting path of 'StateCode.csv' file.
        /// #calling 'NumberOfRecords' method and getting numberOfRecords
        /// #matching expected records with numberOfRecords.
        /// </Test6 :CheckNumberOfRecordsMatchesStateCode>
        [Test]
        public void CheckNumberOfRecordsMatchesStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            var numberOfRecords = stateCode(header, delimeter, path);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <Test7 :CheckIncorrectCSVFileStateCode>
        ///#Sent Incorrect CSV file name : 'StateCode.csv'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid file"
        ///test case passes
        /// </Test7 :CheckIncorrectCSVFileStateCode>
        [Test]
        public void CheckIncorrectCSVFileStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCodeIncorrect.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <Test8 :CheckCorrectDotExtensionFileStateCode>
        ///#Sent Incorrect Extension of file : '.txt'
        ///#CSV File if incorrect Returns a custom Exception as "Invalid Extension of file"
        ///test case passes
        /// </Test8 :CheckCorrectDotExtensionFileStateCode>
        [Test]
        public void CheckCorrectDotExtensionFileStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.txt";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <Test9 :CheckInCorrectDelimeterStateCode>
        ///#Sent user delimeter : ';'
        ///#CSV File if incorrect Returns a custom Exception as "Incorrect Delimeter"
        ///test case passes
        /// </Test9 :CheckInCorrectDelimeterStateCode>
        [Test]
        public void CheckInCorrectDelimeterStateCode()
        {
            char delimeter = ';';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <Test10 :CheckInvalidHeaderStateCode>
        ///#Sending inValid header[] 
        ///#Comparing with actual header of csv file and returning exception message
        ///message is same then, test case passes
        /// </Test10 :CheckInvalidHeaderStateCode>
        [Test]
        public void CheckInvalidHeaderStateCode()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "InvalidState", "PIN", "StateCode" };
            string path = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <Test 11>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </Test 11>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string stateCensusfilePath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusfilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }
        /// <Test 12>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </Test 12>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting__ReturnLastState()
        {
            string expected = "West Bengal";
            string stateCensusfilePath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusfilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }
    }// End of CensusTests
}// End of namespace Tests