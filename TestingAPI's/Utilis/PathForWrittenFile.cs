using System;

namespace TestingAPI_s.Utilis
{
    public static class PathForWrittenFile
    {
        public static string PathForStreetOnly = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\StatisticsStreet.csv";
        public static string PathForStreetAndZip = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\StatisticsStreetAndZip.csv";

    }
}
