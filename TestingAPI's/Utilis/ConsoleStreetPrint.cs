using System;
using System.Collections.Generic;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Utilis
{
    public static class ConsoleStreetPrint
    {
        public static void AllData(APIsOptions aPIsOptions,(bool isValid, string accuracy) validation,List<string> states=null,string state="",string zipCode="")
        {
            switch (aPIsOptions)
            {
                case APIsOptions.Radar: RadarData(state,validation,zipCode); break;
                case APIsOptions.SmartyStreets:SmartyStreetsData(validation, states, state); break;
                case APIsOptions.OpenCage: OpenCageData(state, validation, zipCode); break;
                case APIsOptions.LocationlQ: LocationlQData(validation, states, state); break;
            }

        }
        public static void SmartyStreetsData((bool isValid, string accuracy) validation, List<string> states = null, string state = "")
        {
            Console.WriteLine("-----------SMARTY STREETS API-----------");
            if (validation.isValid == true && states.Count > 1 || states != null)
                states.ForEach(x => Console.WriteLine($"State: {x}"));
            Console.WriteLine($"Validation:{validation.isValid}");
            Console.WriteLine($"Accuracy:{validation.accuracy}");
            if (validation.isValid == true && state != string.Empty)
                Console.WriteLine($"State:{state}");
            if (validation.isValid == false)
                Console.WriteLine($"Validation:{validation.isValid}");
        }
        public static void RadarData(string state, (bool isValid, string accuracy) validation, string zipCode="")
        {
            Console.WriteLine("-----------RADAR API-----------");
            if (validation.isValid == true)
            Console.WriteLine($"State:{state}");
            Console.WriteLine($"ZipCode:{zipCode}");
            Console.WriteLine($"Validation:{validation.isValid}");
            Console.WriteLine($"Accuracy:{validation.accuracy}");
            if (validation.isValid == false)
                Console.WriteLine("There is no state, validation is false");

        }
        public static void OpenCageData(string state, (bool isValid, string accuracy) validation, string zipCode = "")
        {
            Console.WriteLine("-----------OPENCAGE API-----------");
            if (validation.isValid == true)
                Console.WriteLine($"State:{state}");
            Console.WriteLine($"ZipCode:{zipCode}");
            Console.WriteLine($"Validation:{validation.isValid}");
            Console.WriteLine($"Accuracy:{validation.accuracy}");
            if (validation.isValid == false)
                Console.WriteLine("There is no state, validation is false");

        }
        public static void LocationlQData((bool isValid, string accuracy) validation, List<string> states = null, string state = "")
        {
            Console.WriteLine("-----------LOCATIONLQ API-----------");
            if (validation.isValid == true && states.Count > 1 || states != null)
                states.ForEach(x => Console.WriteLine($"Extended states: {x}"));
            Console.WriteLine($"Validation:{validation.isValid}");
            Console.WriteLine($"Accuracy:{validation.accuracy}");
            if (validation.isValid == true && state != string.Empty)
                Console.WriteLine($"Extended State:{state}");
            if (validation.isValid == false)
                Console.WriteLine($"Validation:{validation.isValid}");

        }
    }
}
