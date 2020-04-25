using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyserProblem.CsvStates;
using static CensusAnalyserProblem.StateCensusAnalyser;

namespace CensusAnalyserProblem
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
        public static CsvStateCensusData DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyser csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusData getStateCensus = new CsvStateCensusData(StateCensusAnalyser.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        // Method to creating instance of CsvStates
        public static CsvStateCodeData DelegateOfCsvStates()
        {
            CsvStates csvStateData = InstanceOfCsvStates();
            CsvStateCodeData getStateData = new CsvStateCodeData(CsvStates.CsvStateCodeReadRecord);
            return getStateData;
        }

        private static CsvStates InstanceOfCsvStates()
        {
            return new CsvStates();
        }

        private static StateCensusAnalyser InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyser();
        }
    }
}
