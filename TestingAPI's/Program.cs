using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            using (var writer = new StreamWriter(PathForWrittenFile.PathForStreetOnly)) 
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.HERE), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.Radar), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPI(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource, writer, csvWriter);
                }
            }
            Console.WriteLine();
            using (var writer = new StreamWriter(PathForWrittenFile.PathForStreetAndZip))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
                    TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.Radar), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPI(StreetLookupFactory.Create(APIsOptions.HERE), txtResource, writer, csvWriter);
                }
            }
            Console.ReadLine();
        }

        
    }
}



