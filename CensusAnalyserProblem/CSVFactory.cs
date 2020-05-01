///--------------------------------------------------------------------------
///   Class:--------> CSVFactory
///   Description:--> Created two instance method of StateCensusAnalyser:
///                     1)CsvStateCodeData DelegateOfCsvStates
///                     2)CsvStateCensusData DelegateOfStateCensusAnalyser                   
///   Author:-------> Nitikesh Shinde                     Date: 01/05/2020
///--------------------------------------------------------------------------

using static CensusAnalyserProblem.CsvStatesDao;
using static CensusAnalyserProblem.StateCensusAnalyserDao;

namespace CensusAnalyserProblem
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
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
