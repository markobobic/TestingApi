using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;
using TestingAPI_s.Initilizer;
using TestingAPI_s.Utilis;
using static System.Console;


namespace TestingAPI_s
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtResource = ReadFromResourse.GeStreetList();
            WriteLine("----------SEARCHING BY STREET----------");
            using (var writer = new StreamWriter(PathForWrittenFile.PathForStreetOnly))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    TestRunner.SearchStreetFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.Radar), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.HERE), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource, writer, csvWriter);
                }
            }
            WriteLine();
            using (var writer = new StreamWriter(PathForWrittenFile.PathForStreetAndZip))
            {
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    Console.WriteLine("----------SEARCHING BY STREET AND ZIP CODE----------");
                    TestRunner.SearchStreetZipCodesFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.LocationlQ), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.Radar), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.HERE), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.OpenCage), txtResource, writer, csvWriter);
                    TestRunner.SearchStreetZipCodesFromAPIAndWrite(StreetLookupFactory.Create(APIsOptions.SmartyStreets), txtResource, writer, csvWriter);
                }
            }
            ReadLine();
        }

        
    }
}



