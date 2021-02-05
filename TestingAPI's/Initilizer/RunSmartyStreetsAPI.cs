using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;

namespace TestingAPI_s.Utilis
{
   public static class RunSmartyStreetsAPI
    {
        private static FactoryCreator factory = new ConcreteFactoryCreator();
        private static IStreetLookUp smartyStreets = factory.FactoryMethod(APIsOptions.SmartyStreets);
        public static void StartSearchByStreetPrint(string street)
        {
            var states = smartyStreets.GetStatesSearchByStreet(street);
            var validation = smartyStreets.ValidateStreet(street);
            Print.AllSmartyStreetData(validation,states);
        }

        public static void StartSearchByStreetAndZipPrint(string street, string zipCode)
        {
            var state = smartyStreets.GetStateSearchByStreetAndZip(street, zipCode);
            var validation = smartyStreets.ValidateStreetAndZip(street, zipCode);
            Print.AllSmartyStreetData(validation,new List<string>(),state);

        }
    }
}
