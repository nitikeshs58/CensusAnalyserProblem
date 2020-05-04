///---------------------------------------------------------------------------------------
///   Interface:----> ICSVBuilder
///   Description:--> Created interface ICSVBuilder for reading and fetching data from file
///   Author:-------> Nitikesh Shinde                     Date: 04/05/2020
///----------------------------------------------------------------------------------------

namespace CensusAnalyserProblem
{
    //interface ICSVBuilder for reading / fetching data from file
    public interface ICSVBuilder
    {
        object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath);
        object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath);
        object CsvUSCensusDataReadRecord(string[] header, char delimeter, string givenPath);
    }
}
