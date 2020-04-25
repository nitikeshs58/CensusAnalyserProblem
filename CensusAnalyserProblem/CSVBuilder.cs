using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    //interface ICSVBuilder for reading / fetching data from file
    public interface ICSVBuilder
    {
        object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath);
        object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath);
    }
}
