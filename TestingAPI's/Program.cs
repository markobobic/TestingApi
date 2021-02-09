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
            var txtResource = ReadFromResourse.GeStreetList();
            Console.WriteLine("----------SEARCHING BY STREET----------");
            TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.Radar), txtResource);
            TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource);
            TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource);
            TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource);
            TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.HERE), txtResource);
            Console.WriteLine();
            Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
            TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.Radar), txtResource);
            TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource);
            TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource);
            TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource);
            TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.HERE), txtResource);
            Console.ReadLine();
        }

        
    }
}



