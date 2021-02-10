using CsvHelper;
using System;
using System.IO;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Utilis
{
    public static class StatisticsToCsvFile
    {
      
        public static void Write(APIsOptions options,StatisticOfMatched statistic,StreamWriter writer, CsvWriter csvWriter)
        {
                csvWriter.WriteField(options.ToString());
                csvWriter.NextRecord();
                csvWriter.WriteField($"Matched:{statistic.NumberOfMatched}");
                csvWriter.WriteField($"Precentege:{Math.Round(statistic.PercentageOfMatched,2)}");
                csvWriter.NextRecord();
                writer.Flush();
        }
    }

   

}
