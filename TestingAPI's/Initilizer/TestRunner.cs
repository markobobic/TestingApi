using System.Collections.Generic;
using TestingAPI_s.Factory;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Initilizer
{
    public static class TestRunner
    {
        public static void SearchStreetFromAPI(IStreetLookUp streetlookup, List<StreetLookupInput> textResource)
        {
            foreach (var data in textResource)
            {
               var states = streetlookup.GetStatesSearchByStreet(data.StreetName);
               var validation =streetlookup.ValidateStreet(data.StreetName);
               var zipCodes = streetlookup.GetZipCodesSearchByStreet(data.StreetName);
               ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(),validation,states,data.StateCode,zipCodes);
            }
        }

        public static void SearchStreetZipCodesFromAPI(IStreetLookUp streetlookup, List<StreetLookupInput> textResource)
        {
            foreach (var data in textResource)
            {
                var states =streetlookup.GetStatesSearchByStreetAndZip(data.StreetName,data.ZipCode);
                var validation=streetlookup.ValidateStreetAndZip(data.StreetName, data.ZipCode);
                ConsoleStreetPrint.Data(streetlookup.GetNameOfAPI(), validation, states,data.StateCode);
            }
        }
    }
}
