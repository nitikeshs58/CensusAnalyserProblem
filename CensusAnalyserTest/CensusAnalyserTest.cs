using CensusAnalyserProblem;
using NUnit.Framework;

namespace Tests
{
    public class CensusTests
    {

        string stateCensusDataPath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
        string stateCodePath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";

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
            StateCensusAnalyser censusPath= new StateCensusAnalyser(stateCensusDataPath);
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string path =stateCensusDataPath;
            var numberOfRecords = censusPath.ReadRecords(header,delimeter,path);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(stateCensusDataPath);
            string incorrectPath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrect.csv";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage=censusPath.ReadRecords(header,delimeter, incorrectPath);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(stateCensusDataPath);
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string inCorrectExtensionPath = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrectExtension.txt";
            object exceptionMessage = censusPath.ReadRecords(header,delimeter,inCorrectExtensionPath);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(stateCensusDataPath);
            char userDelimeter = ';';
            string path = stateCensusDataPath;
            object exceptionMessage = censusPath.ReadRecords(null,userDelimeter,path);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(stateCensusDataPath);
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            char userDelimeter = ',';
            string path = stateCensusDataPath;
            object exceptionMessage = censusPath.ReadRecords(header,userDelimeter,path);
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
            string path = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            CsvStates stateCodePath = new CsvStates(header, delimeter, path);
            var numberOfRecords = stateCodePath.CsvStateCodeReadRecord();
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
            string path = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCodeIncorrect.csv";
            CsvStates stateCodePath = new CsvStates(header, delimeter, path);
            object exceptionMessage = stateCodePath.CsvStateCodeReadRecord();
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
            string path = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.txt";
            CsvStates stateCodePath = new CsvStates(header, delimeter, path);
            object exceptionMessage = stateCodePath.CsvStateCodeReadRecord();
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
            string path = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            CsvStates stateCodePath = new CsvStates(header, delimeter, path);
            object exceptionMessage = stateCodePath.CsvStateCodeReadRecord();
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
            string path = @"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
            CsvStates stateCodePath = new CsvStates(header, delimeter, path);
            object exceptionMessage = stateCodePath.CsvStateCodeReadRecord();
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }
    }
}