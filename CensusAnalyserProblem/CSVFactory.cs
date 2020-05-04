///--------------------------------------------------------------------------
///   Class:--------> CSVFactory
///   Description:--> Created two instance method of StateCensusAnalyser:
///                     1)CsvStateCodeData DelegateOfCsvStates
///                     2)CsvStateCensusData DelegateOfStateCensusAnalyser  
///                     3)
///   Author:-------> Nitikesh Shinde                     Date: 04/05/2020
///--------------------------------------------------------------------------

using System;
using static CensusAnalyserProblem.CsvStatesDao;
using static CensusAnalyserProblem.StateCensusAnalyserDao;
using static CensusAnalyserProblem.USCensusDataDao;

namespace CensusAnalyserProblem
{
    public class CSVFactory
    {
        /// <summary>
        ///Method to creating instance of StateCensusAnalyser
        ///Delegate is referance type variable that holds thr referance to the method.
        /// </summary>
        /// <returns></returns>

        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        // Method to creating instance of CsvStates
        public static CsvStateCodeDataDao DelegateOfCsvStates()
        {
            CsvStatesDao csvStateData = InstanceOfCsvStates();
            CsvStateCodeDataDao getStateData = new CsvStateCodeDataDao(CsvStatesDao.CsvStateCodeReadRecord);
            return getStateData;
        }

        // Method to creating instance of USCensusData
        public static CsvUSCensusData DelegateOfUSCensusData()
        {
            USCensusDataDao csvUSData = InstanceOfUSCensusData();
            CsvUSCensusData getUSData = new CsvUSCensusData(USCensusDataDao.CsvUSCensusDataReadRecord);
            return getUSData;
        }

        private static USCensusDataDao InstanceOfUSCensusData()
        {
            throw new NotImplementedException();
        }

        private static CsvStatesDao InstanceOfCsvStates()
        {
            return new CsvStatesDao();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyserDao();
        }
    }
}
