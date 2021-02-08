using System.Collections.Generic;
using TestingAPI_s.Core;

namespace TestingAPI_s.Factory
{
    public interface IStreetLookUp : ISearchStreetAndZip,INameOfAPI
    {
        string GetStateSearchByStreet(string street);
        List<string> GetStatesSearchByStreet(string street);
        string GetZipCodeSearchByStreet(string street);
        (bool isValid, string accuracy) ValidateStreet(string street);
    }
}
