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

            Console.WriteLine("----------SEARCHING BY STREET----------");
            RunSmartyStreetsAPI.StartSearchByStreetPrint(street: "3301 South Greenfield Rd");
            RunRadarAPI.StartSearchByStreetPrint(street: "3301 South Greenfield Rd");
            Console.WriteLine();
            Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
            RunSmartyStreetsAPI.StartSearchByStreetAndZipPrint(street: "3301 South Greenfield Rd", zipCode: "85297");
            RunRadarAPI.StartSearchByStreetAndZipPrint(street: "3301 South Greenfield Rd", zipCode: "85297");
            Console.ReadLine();
        }

    }
}



