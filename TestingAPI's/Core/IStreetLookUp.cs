using System.Collections.Generic;
using TestingAPI_s.Core;

namespace TestingAPI_s.Factory
{
    public interface IStreetLookUp : ISearchStreetAndZip,INameOfAPI
    {
        List<string> GetStatesSearchByStreet(string street);
        List<string> GetZipCodesSearchByStreet(string street);
        ValidationResult ValidateStreet(string street);
    }
}
