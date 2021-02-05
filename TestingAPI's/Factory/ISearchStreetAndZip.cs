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
        Tuple<bool,string> ValidateStreetAndZip(string street,string zipCode);

    }
}
