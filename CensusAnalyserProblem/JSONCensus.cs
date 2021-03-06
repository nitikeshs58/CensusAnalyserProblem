﻿///-----------------------------------------------------------------------------
///   Class:--------> JSONCensus                                                 
///   Description:--> Methods to return First and last data as per KeyValue
///                   Added .csv data in JSON format and sorting is done Alphabetically
///                     1)SortCsvFileWriteInJsonAndReturnFirstData
///                     2)SortCsvFileWriteInJsonAndReturnLastData
///                     3)ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson
///                     4)ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson
///   Author:-------> Nitikesh Shinde                     Date: 04/05/2020       
///-----------------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using ChoETL;

namespace CensusAnalyserProblem
{
    public class JSONCensus
    { 
    /// <summary>
    /// Method to write the First state data using json
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="jsonFilepath"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string SortCsvFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string key)
    {
        string readFile = File.ReadAllText(filePath);
        StringBuilder stringbuilder = new StringBuilder();
        using (var reader = ChoCSVReader.LoadText(readFile)
                                   .WithFirstLineHeader())
        {
            using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
        }
        File.WriteAllText(jsonFilepath, stringbuilder.ToString());
        JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);
        //serialize JSON to a string and then write string to a file
        var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
        File.WriteAllText(jsonFilepath, jsonArray);
        return CsvStateCensusReadRecord.RetriveFirstDataOnKey(jsonFilepath, key);
    }
    /// <summary>
    /// Method to write the last state data using json
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="jsonFilepath"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string SortCsvFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string key)
    {
        string readFile = File.ReadAllText(filePath);
        StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                       .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
        File.WriteAllText(jsonFilepath, stringbuilder.ToString());
        JArray array = CsvStateCensusReadRecord.SortingJsonBasedOnKey(jsonFilepath, key);
        // serialize JSON to a string and then write string to a file
        var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
        File.WriteAllText(jsonFilepath, jsonArray);
        return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
    }

        /// <summary>
        /// Method to sorting the most population
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnDataNumberOfStatesHighestSortCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveLastDataOnKey(jsonFilepath, key);
        }

        /// <summary>
        /// Method to sorting the most population
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnDataNumberOfStatesSortLowestCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var reader = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(reader);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CsvStateCensusReadRecord.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CsvStateCensusReadRecord.RetriveFirstDataOnKey(jsonFilepath, key);
        }
    }
}
