using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Utilis
{
    public static class StatisticsToCsvFile
    {
      
        public static void Write(APIsOptions options,Dictionary<AddressCorrectness,Statistics> results,StreamWriter writer, CsvWriter csvWriter)
        {
                csvWriter.WriteField($"{ options}-Correct addresses result" );
                csvWriter.NextRecord();
                csvWriter.WriteField($"Matched:{results[AddressCorrectness.Correct].NumberOfMatched} of 70 results");
                csvWriter.WriteField($"Precentege:{Math.Round(results[AddressCorrectness.Correct].PercentageOfMatched,2)}");
                csvWriter.NextRecord();
                csvWriter.WriteField($"{ options}-Incorrect addresses result");
                csvWriter.NextRecord();
                csvWriter.WriteField($"Matched:{results[AddressCorrectness.Incorrect].NumberOfMatched} of 30 results");
                csvWriter.WriteField($"Precentege:{Math.Round(results[AddressCorrectness.Incorrect].PercentageOfMatched, 2)}");
                csvWriter.NextRecord();
                writer.Flush();
        }
    }

   

}
