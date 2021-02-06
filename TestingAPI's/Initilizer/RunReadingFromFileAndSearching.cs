using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Initilizer
{
    public  delegate void RunStreetSearch(string street);
    public delegate void RunStreeZipCodestSearch(string street,string zipoCode);
    public static class RunReadingFromFileAndSearching
    {
        public static void SteetFromAPIs(RunStreetSearch streetSearch)
        {
            var textResource = ReadFromResourse.GeStreetList();
            foreach (var street in textResource.StreetsList)
            {
                streetSearch(street);
            }
        }
        public static void StreetZipCodesFromAPIs(RunStreeZipCodestSearch streetZipCodeSearch)
        {
            var textResource = ReadFromResourse.GeStreetList();
            foreach (var street in textResource.StreetsList.Zip
                (textResource.ZipCodeList, (street, zipCode) => new { Street=street, Zipcode=zipCode}))
            {
                streetZipCodeSearch(street.Street,street.Zipcode);
            }
        }
    }
}
