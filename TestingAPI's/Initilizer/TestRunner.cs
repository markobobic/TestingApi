using CsvHelper;
using System.Collections.Generic;
using System.IO;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Initilizer
{
    public static class TestRunner
    {
        public static int Counter;
        public static void SearchStreetFromAPIAndWrite(IStreetLookUp streetlookup, List<StreetLookupInput> textResource,StreamWriter writer, CsvWriter csvWriter)
        {
            Counter = 0;
            StatisticsOfCorrectAddress statsCorrectAddr = new StatisticsOfCorrectAddress();
            StatisticsOfIncorrectAddress statsIncorrectAddr = new StatisticsOfIncorrectAddress();
            Dictionary<AddressCorrectness, Statistics> results = new Dictionary<AddressCorrectness, Statistics>();

            foreach (var data in textResource)
            {
               var states = streetlookup.GetStatesSearchByStreet(data.StreetName);
               var validation =streetlookup.ValidateStreet(data.StreetName);
               var zipCodes = streetlookup.GetZipCodesSearchByStreet(data.StreetName);
               ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(),validation,states,data.StateCode,zipCodes);
               Counter += 1;
               results = MatchedStatistic.Calculate(states, data.StateCode, statsCorrectAddr, statsIncorrectAddr,results);
              
            }
            StatisticsToCsvFile.Write(streetlookup.GetNameOfAPI(), results, writer, csvWriter);
        }

        public static void SearchStreetZipCodesFromAPIAndWrite(IStreetLookUp streetlookup, List<StreetLookupInput> textResource,StreamWriter writer, CsvWriter csvWriter)
        {
            Counter = 0;
            StatisticsOfCorrectAddress statsCorrectAddr = new StatisticsOfCorrectAddress();
            StatisticsOfIncorrectAddress statsIncorrectAddr = new StatisticsOfIncorrectAddress();
            Dictionary<AddressCorrectness, Statistics> results = new Dictionary<AddressCorrectness, Statistics>();
            foreach (var data in textResource)
            {
                var states =streetlookup.GetStatesSearchByStreetAndZip(data.StreetName,data.ZipCode);
                var validation=streetlookup.ValidateStreetAndZip(data.StreetName, data.ZipCode);
                ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(), validation, states,data.StateCode);
                Counter += 1;
                results = MatchedStatistic.Calculate(states, data.StateCode, statsCorrectAddr, statsIncorrectAddr, results);
            }
            StatisticsToCsvFile.Write(streetlookup.GetNameOfAPI(), results, writer, csvWriter);
        }


    }
}
