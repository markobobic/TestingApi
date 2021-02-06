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
            RunReadingFromFileAndSearching.SteetFromAPIs(RunRadarAPI.StartSearchByStreetPrint);
            RunReadingFromFileAndSearching.SteetFromAPIs(RunSmartyStreetsAPI.StartSearchByStreetPrint);
            Console.WriteLine();
            Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
            RunReadingFromFileAndSearching.StreetZipCodesFromAPIs(RunRadarAPI.StartSearchByStreetAndZipPrint);
            RunReadingFromFileAndSearching.StreetZipCodesFromAPIs(RunSmartyStreetsAPI.StartSearchByStreetAndZipPrint);
            Console.ReadLine();
        }

    }
}



