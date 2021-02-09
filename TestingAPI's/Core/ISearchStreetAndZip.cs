using System.Collections.Generic;
using TestingAPI_s.Core;

namespace TestingAPI_s.Factory
{
    public interface ISearchStreetAndZip
    {
        List<string> GetStatesSearchByStreetAndZip(string street, string zipCode);
        ValidationResult ValidateStreetAndZip(string street, string zipCode);
    }
}
