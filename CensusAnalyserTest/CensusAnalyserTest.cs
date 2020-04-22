using CensusAnalyserProblem;
using NUnit.Framework;

namespace Tests
{
    public class CensusTests
    {
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
            StateCensusAnalyser censusPath= new StateCensusAnalyser();
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            var numberOfRecords = censusPath.ReadRecords(header,delimeter);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrect.csv");
            object exceptionMessage=censusPath.ReadRecords();
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrectExtension.txt");
            object exceptionMessage = censusPath.ReadRecords();
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv");
            char userDelimeter = ';';
            object exceptionMessage = censusPath.ReadRecords(null,userDelimeter);
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
            StateCensusAnalyser censusPath = new StateCensusAnalyser();
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage = censusPath.ReadRecords(header);
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
            CsvStates stateCodePath = new CsvStates();
            char delimeter = ',';
            string[] header = {"SrNo","State","PIN","StateCode"};
            var numberOfRecords = stateCodePath.ReadRecordsStateCode(header, delimeter);
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
            CsvStates stateCodePath = new CsvStates(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusCodeIncorrect.csv");
            object exceptionMessage = stateCodePath.ReadRecordsStateCode();
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
            CsvStates stateCodePath = new CsvStates(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCodeIncorrectExtension.txt");
            object exceptionMessage = stateCodePath.ReadRecordsStateCode();
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
            CsvStates stateCodePath = new CsvStates(@"C:\Users\Admin\Documents\Visual Studio 2017\Projects\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv");
            char userDelimeter = ';';
            object exceptionMessage = stateCodePath.ReadRecordsStateCode(null, userDelimeter);
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
            CsvStates stateCodePath = new CsvStates();
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage = stateCodePath.ReadRecordsStateCode(header);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }
    }
}