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
               var state = streetlookup.GetStateSearchByStreet(data.StreetName);
               var validation =streetlookup.ValidateStreet(data.StreetName);
               var zipCode = streetlookup.GetZipCodeSearchByStreet(data.StreetName);
                ConsoleStreetPrint.AllData(streetlookup.GetNameOfAPI(),validation,null,state,zipCode);
            }
        }

        public static void SearchStreetZipCodesFromAPI(IStreetLookUp streetlookup, List<StreetLookupInput> textResource)
        {
            foreach (var data in textResource)
            {
                streetlookup.GetStateSearchByStreetAndZip(data.StreetName,data.ZipCode);
                streetlookup.ValidateStreetAndZip(data.StreetName, data.ZipCode);
                //ConsoleStreetPrint();
            }
        }
    }
}
