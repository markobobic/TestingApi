using System.Collections.Generic;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;
using static System.Console;

namespace TestingAPI_s.Utilis
{
    public static class ConsoleStreetPrint
    {
        public static void Data(APIsOptions aPIsOptions,ValidationResult validation,List<string> states,string correctStateCode,List<string> zipCodes=null)
        {
            switch (aPIsOptions)
            {
                case APIsOptions.SmartyStreets: WriteLine("-----------SMARTY STREETS API-----------"); break;
                case APIsOptions.Radar: WriteLine("-----------RADAR API-----------"); break;
                case APIsOptions.OpenCage: WriteLine("-----------OPENCAGE API-----------"); break;
                case APIsOptions.LocationlQ: WriteLine("-----------LOCATIONLQ API-----------"); break;
                case APIsOptions.HERE: WriteLine("-----------HERE API-----------"); break;

            }

            if (validation.IsValid == true && states.Count > 1) { 
                states.ForEach(state => WriteLine($"States: {state}"));
            WriteLine($"Validation:{validation.IsValid}");
            WriteLine($"Accuracy:{validation.Accuracy}");
            }
            if (validation.IsValid == true && states.Count ==1)
                states.ForEach(state => WriteLine($"State: {state}"));
            if (validation.IsValid == false)
            {
                WriteLine($"Validation:{validation.IsValid}");
                WriteLine($"Accuracy:{validation.Accuracy}");
            }
            WriteLine($"Correct state code:{correctStateCode}");
            WriteLine($"Are matched: {states.Contains(correctStateCode)}");
        }
       
    }
}
