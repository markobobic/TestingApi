using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.Factory
{
   public interface ISearchStreetAndZip
    {
        string GetStateSearchByStreetAndZip(string street,string zipCode);
        (bool isValid, string accuracy) ValidateStreetAndZip(string street,string zipCode);

    }
}
