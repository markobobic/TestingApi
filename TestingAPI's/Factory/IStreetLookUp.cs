using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.Factory
{
   public interface IStreetLookUp : ISearchStreetAndZip
    {
        string GetStateSearchByStreet(string street);
        List<string> GetStatesSearchByStreet(string street);
        string GetZipCodeSearchByStreet(string street);
        Tuple<bool, string> ValidateStreet(string street);




    }
}
