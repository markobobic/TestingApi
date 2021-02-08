using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TestingAPI_s.ExtensionMethods;

namespace TestingAPI_s.Utilis
{
    public class StreetLookupInput
    {
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public StreetLookupInput(string streetName,string zipCode)
        {
            StreetName = streetName;
            ZipCode = zipCode;
        }
    }

    public static class ReadFromResourse
    {
        public static List<StreetLookupInput> GeStreetList()
        {
            List<StreetLookupInput> streetLookupInputs = new List<StreetLookupInput>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("TestingAPI_s.StreetList.txt"))
            using (var reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                string[] array = text.Split(
                  new[] { "\r\n", "\r", "\n" },
                     StringSplitOptions.None);
                foreach (var item in array)
                {
                    var nesto = item;
                    var splited = item.Split(new string[] { "||" }, StringSplitOptions.None);
                    var streetLookupInput = new StreetLookupInput(splited[0],splited[1]);
                    streetLookupInputs.Add(streetLookupInput);
                }
                return streetLookupInputs;

            }

        }
    }
}
