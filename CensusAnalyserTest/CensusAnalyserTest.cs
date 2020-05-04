///----------------------------------------------------------------------------
///   Class:--------> Tests
///   Description:--> Test cases for India Census data
///   Author:-------> Nitikesh Shinde                     Date: 02/05/2020
///----------------------------------------------------------------------------

using CensusAnalyserProblem;
using NUnit.Framework;
using static CensusAnalyserProblem.StateCensusAnalyserDao;
using static CensusAnalyserProblem.CsvStatesDao;
using static CensusAnalyserProblem.USCensusDataDao;

namespace Tests
{
    public class CensusTests
    {
        // with NameSpace Assembly reference 
        // DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusDataDao stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDataDao stateCode = CSVFactory.DelegateOfCsvStates();
        readonly CsvUSCensusDataDao USCensus = CSVFactory.DelegateOfUSCensusData();
        // FilePath ,Valid and Invalid Headers of StateCensusData
        public string stateCensusDataPath= @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.csv";
        public string stateCensusDataPathIncorrectName = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusDataIncorrect.csv";
        public string stateCensusDataPathIncorrectExtension = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.txt";
        public string[] headerStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] headerStateCensusInvalid = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
        
        // FilePath ,Valid and Invalid Headers of StateCode
        public string stateCodePath= @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.csv";
        public string stateCodePathIncorrectName = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCodeIncorrect.csv";
        public string stateCodePathIncorrectExtension = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.txt";
        public string[] headerStateCode = { "SrNo", "State", "PIN", "StateCode" };
        public string[] headerStateCodeInvalid = { "SrNo", "StateInvalid", "PIN", "StateCode" };

        // FilePath and Headers of USCensusData
        public string USDataPath = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\USCensusData.csv";
        public string[] headerUSData = { "State Id", "State", "Population", "Housing units", "Total area", "Water area", "Land area", "Population Density", "Housing Density" };
       
        // Correct and Incorrect Delimeter
        char delimeter = ',';
        char IncorrectDelimeter = ';';

        // FilePath of JSON files
        public string jsonPathstateCensus = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCensusData.json";
        public string jsonPathstateCode = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\StateCode.json";
        public string jsonPathUSData = @"C:\Users\Admin\source\repos\CensusAnalyserProblem\CensusAnalyserProblem\USDataJSON.json";

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
            var numberOfRecords = stateCensus(headerStateCensus, delimeter, stateCensusDataPath);
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
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectName);
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
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectExtension);
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
            object exceptionMessage = stateCensus(headerStateCensus, IncorrectDelimeter, stateCensusDataPath);
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
            object exceptionMessage = stateCensus(headerStateCensusInvalid, delimeter, stateCensusDataPath);
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
            var numberOfRecords = stateCode(headerStateCode, delimeter, stateCodePath);
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
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectName);
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
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectExtension);
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
            object exceptionMessage = stateCode(headerStateCode, IncorrectDelimeter, stateCodePath);
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
            object exceptionMessage = stateCode(headerStateCodeInvalid, delimeter, stateCodePath);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <Test 11>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </Test 11>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusPath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }
        /// <Test 12>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </Test 12>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting__ReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusPath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 13>
        ///  Test for StateCodeCsv and json path to add into json after sorting return return first stateCode.
        /// </Test 13>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnFirstStateCode()
        {
            string expected = "AD";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCodePath, jsonPathstateCode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 14>
        ///  Test for StateCodeCsv and json path to add into json after sorting return return last stateCode.
        /// </Test 14>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_ReturnLatStateCode()
        {
            string expected = "WB";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCodePath, jsonPathstateCode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 15>
        /// Test for StateCensuscsv and json path to add into json after sorting return most Population.
        /// </Test 15>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromMostPopulousToLeast_ReturnMostPopulation()
        {
            string expected = "199812341";
            string mostPopulation = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "Population");
            Assert.AreEqual(expected, mostPopulation);
        }

        /// <Test 16>
        /// Test for StateCensuscsv and json path to add into json after sorting return most Population.
        /// </Test 16>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromLeastToPopulousToMost_ReturnLeastPopulation()
        {
            string expected = "607688";
            string leastPopulation = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "Population");
            Assert.AreEqual(expected, leastPopulation);
        }
        /// <Test 17>
        /// Test for StateCensuscsv and json path to add into json after sorting return most DensityPerSqKm.
        /// </Test 17>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromMostDensityPerKmLeast_ReturnMostDensityPerSqKm()
        {
            string expected = "1102";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "DensityPerSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }

        /// <Test 18>
        /// Test for StateCensuscsv and json path to add into json after sorting return least DensityPerSqKm.
        /// </Test 18>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromLeastDensityPerKmMost_ReturnLeastDensityPerSqKm()
        {
            string expected = "52";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "DensityPerSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }
        /// <Test 19>
        /// Test for StateCensuscsv and json path to add into json after sorting return most AreaInSqKm.
        /// </Test 19>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromMostAreaInSqKmToLeast_ReturnMostAreaInSqKmv()
        {
            string expected = "342239";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "AreaInSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }
        /// <Test 20>
        /// Test for StateCensuscsv and json path to add into json after sorting return Least AreaInSqKm.
        /// </Test 20>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSortFromLeastAreaInSqKmToMost_ReturnLeastAreaInSqKmv()
        {
            string expected = "3702";
            string mostDensityPerKm = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "AreaInSqKm");
            Assert.AreEqual(expected, mostDensityPerKm);
        }
        /// <Test 21>
        /// Checking number of records of US census data
        /// </Test 21>
        [Test]
        public void CheckUSCensusDataNumberOFRecords()
        {
            var returnRecords = USCensus(headerUSData,delimeter,USDataPath);
            Assert.AreEqual(51, returnRecords);
        }

        /// <Test 22>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning most populus number.
        /// </Test 22>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromMostPopulousToLeast_ReturnMostPolulation()
        {
            string expected = "37253956";
            string mostPopulus = JSONCensus.ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(USDataPath, jsonPathUSData,"Population");
            Assert.AreEqual(expected, mostPopulus);
        }

        /// <Test 23>
        /// Converting CSv file to JSON  and sorting it 
        /// and returning least populus number.
        /// </Test 23>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromLeastPopulousToMost_ReturnLeastPopulation()
        {
            string expected = "563626";
            string leastPopulation = JSONCensus.ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(USDataPath, jsonPathUSData, "Population");
            Assert.AreEqual(expected, leastPopulation);
        }

        /// <Test 24>
        ///  Test for USCensuscsv and json path to add into json after sorting return return first state.
        /// </Test 24>
        [Test]
        public void CheckUSCensusDataAndAddToJsonPathAndSorting_ReturnFirstState()
        {
            string expected = "Alabama";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(USDataPath, jsonPathUSData, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <Test 25>
        ///  Test for USCensuscsv and json path to add into json after sorting return return last state.
        /// </Test 25>
        [Test]
        public void CheckUSCensusDataAndAddToJsonPathAndSorting_ReturnLastState()
        {
            string expected = "Wyoming";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(USDataPath, jsonPathUSData, "State");
            Assert.AreEqual(expected, lastValue);
        }   
    }// End of CensusTests
    }// End of namespace Tests