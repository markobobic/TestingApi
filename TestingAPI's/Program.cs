using System;
using System.Collections.Generic;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;
using TestingAPI_s.Initilizer;
using TestingAPI_s.Utilis;

namespace TestingAPI_s
{
    class Program
    {
        static void Main(string[] args)
        {
            var nesto = ReadFromResourse.GeStreetList();
            Console.WriteLine("----------SEARCHING BY STREET----------");
            RunSmartyStreetsAPI.StartSearchByStreetPrint(street: "20 jay st brooklyn");
            RunRadarAPI.StartSearchByStreetPrint(street: "20 jay st brooklyn");
            Console.WriteLine();
            Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
            RunSmartyStreetsAPI.StartSearchByStreetAndZipPrint(street: "20 jay st brooklyn", zipCode: "11201");
            RunRadarAPI.StartSearchByStreetAndZipPrint(street: "20 jay st brooklyn", zipCode: "11201");
            Console.ReadLine();
        }

    }
}



