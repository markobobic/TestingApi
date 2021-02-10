using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TestingAPI_s.Core;
using TestingAPI_s.Factory;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Initilizer
{
    public static class TestRunner
    {
        public static void SearchStreetFromAPI(IStreetLookUp streetlookup, List<StreetLookupInput> textResource,StreamWriter writer, CsvWriter csvWriter)
        {
            StatisticOfMatched calculation = new StatisticOfMatched();
           
            foreach (var data in textResource)
            {
               var states = streetlookup.GetStatesSearchByStreet(data.StreetName);
               var validation =streetlookup.ValidateStreet(data.StreetName);
               var zipCodes = streetlookup.GetZipCodesSearchByStreet(data.StreetName);
               ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(),validation,states,data.StateCode,zipCodes);
               calculation = MatchedStatistic.Calculate(states, data.StateCode, calculation, textResource);
              
            }
            StatisticsToCsvFile.Write(streetlookup.GetNameOfAPI(), calculation, writer, csvWriter);
        }

        public static void SearchStreetZipCodesFromAPI(IStreetLookUp streetlookup, List<StreetLookupInput> textResource,StreamWriter writer, CsvWriter csvWriter)
        {
            StatisticOfMatched calculation = new StatisticOfMatched();
            foreach (var data in textResource)
            {
                var states =streetlookup.GetStatesSearchByStreetAndZip(data.StreetName,data.ZipCode);
                var validation=streetlookup.ValidateStreetAndZip(data.StreetName, data.ZipCode);
                ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(), validation, states,data.StateCode);
                calculation = MatchedStatistic.Calculate(states, data.StateCode, calculation, textResource);
            }
            StatisticsToCsvFile.Write(streetlookup.GetNameOfAPI(), calculation, writer, csvWriter);
        }


    }
}
