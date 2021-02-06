using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Initilizer
{
    public static class RunRadarAPI
    {
        private static FactoryCreator factory = new ConcreteFactoryCreator();
        private static IStreetLookUp radar = factory.FactoryMethod(APIsOptions.Radar);
        public static void StartSearchByStreetPrint(string street)
        {
            var validation = radar.ValidateStreet(street);
            var state = radar.GetStateSearchByStreet(street);
            var zipCode = radar.GetZipCodeSearchByStreet(street);
            
            Print.AllRadarData(state, validation, zipCode);
                
        }
        public static void StartSearchByStreetAndZipPrint(string street,string zipCode)
        {
            var state = radar.GetStateSearchByStreetAndZip(street, zipCode);
            var validation = radar.ValidateStreetAndZip(street,zipCode);
            Print.AllRadarData(state,validation,zipCode);

        }
    }
}
