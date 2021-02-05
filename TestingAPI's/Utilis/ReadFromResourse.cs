using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.Utilis
{
    public static class ReadFromResourse
    {
        public static ImmutableList<string> GeStreetList()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("TestingAPI_s.StreetList.txt"))
            using (var reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                string[] array = text.Split(
                  new[] { Environment.NewLine },
                  StringSplitOptions.RemoveEmptyEntries);
                return ImmutableList<string>.Empty.AddRange(array);

            }

        }
    }
}
