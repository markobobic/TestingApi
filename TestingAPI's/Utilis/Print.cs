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
        public static void AllSmartyStreetData(Tuple<bool,string> validation,List<string> states=null,string state="")
        {
            Console.WriteLine("-----------SMARTY STREETS-----------");
            if (validation.Item1 == true && states.Count==0 || states!=null) 
                states.ForEach(x => Console.WriteLine($"State: {x}"));
            Console.WriteLine($"Validation:{validation.Item1}");
            Console.WriteLine($"Accuracy:{validation.Item2}");
            if(validation.Item1==true && state!=string.Empty)
                Console.WriteLine($"State:{state}");
            if(validation.Item1==false)
                Console.WriteLine($"Validation:{validation.Item1}"); 
                
        }
        public static void AllRadarData(string state, Tuple<bool, string> validation, string zipCode="")
        {
            Console.WriteLine("-----------RADAR API-----------");
            if (validation.Item1 == true)
            Console.WriteLine($"State:{state}");
            Console.WriteLine($"ZipCode:{zipCode}");
            Console.WriteLine($"Validation:{validation.Item1}");
            Console.WriteLine($"Accuracy:{validation.Item2}");
            if (validation.Item1 == false)
                Console.WriteLine("There is no state, validation is false");

        }
    }
}
