using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.Utilis
{
    public static class Print
    {
        public static void AllSmartyStreetData((bool isValid, string accuracy) validation,List<string> states=null,string state="")
        {
            Console.WriteLine("-----------SMARTY STREETS-----------");
            if (validation.isValid == true && states.Count==0 || states!=null) 
                states.ForEach(x => Console.WriteLine($"State: {x}"));
            Console.WriteLine($"Validation:{validation.isValid}");
            Console.WriteLine($"Accuracy:{validation.accuracy}");
            if(validation.isValid == true && state!=string.Empty)
                Console.WriteLine($"State:{state}");
            if(validation.isValid == false)
                Console.WriteLine($"Validation:{validation.isValid}"); 
                
        }
        public static void AllRadarData(string state, (bool isValid, string accuracy) validation, string zipCode="")
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
    }
}
