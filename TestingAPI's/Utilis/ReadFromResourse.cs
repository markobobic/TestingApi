using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.ExtensionMethods;

namespace TestingAPI_s.Utilis
{
    public static class ReadFromResourse
    {
        
        public static (List<string> StreetsList,List<string>ZipCodeList) GeStreetList()
        {
            string zipCode=string.Empty;
            string street=string.Empty;
            List<string> ZipCodes = new List<string>();
            List<string> Streets = new List<string>();

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
                    zipCode = item.GetLastCharacters(5);
                    street = item.RemoveLastCharacters(6);
                    ZipCodes.Add(zipCode);
                    Streets.Add(street);
                }
                return (Streets, ZipCodes);

            }

        }
    }
}
