using System;
using System.Collections.Generic;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Utilis
{
    public static class ConsoleStreetPrint
    {
        public static void Data(APIsOptions aPIsOptions,ValidationResult validation,List<string> states,string correctStateCode,List<string> zipCodes=null)
        {
            switch (aPIsOptions)
            {
                case APIsOptions.SmartyStreets: Console.WriteLine("-----------SMARTY STREETS API-----------"); break;
                case APIsOptions.Radar: Console.WriteLine("-----------RADAR API-----------"); break;
                case APIsOptions.OpenCage: Console.WriteLine("-----------OPENCAGE API-----------"); break;
                case APIsOptions.LocationlQ: Console.WriteLine("-----------LOCATIONLQ API-----------"); break;
                case APIsOptions.HERE: Console.WriteLine("-----------HERE API-----------"); break;

            }

            if (validation.IsValid == true && states.Count > 1) { 
                states.ForEach(state => Console.WriteLine($"States: {state}"));
            Console.WriteLine($"Validation:{validation.IsValid}");
            Console.WriteLine($"Accuracy:{validation.Accuracy}");
            }
            if (validation.IsValid == true && states.Count ==1)
                states.ForEach(state => Console.WriteLine($"State: {state}"));
            if (validation.IsValid == false)
            {
                Console.WriteLine($"Validation:{validation.IsValid}");
                Console.WriteLine($"Accuracy:{validation.Accuracy}");
            }
            Console.WriteLine($"Correct state code:{correctStateCode}");
            Console.WriteLine($"Are matched: {states.Contains(correctStateCode)}");
        }
       
    }
}
