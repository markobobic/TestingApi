using RestSharp;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.DTO.SmartyStreetsAPI;
using SmartyStreets.USAutocompleteApi;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
   public class SmartyStreetsAPIFactory : IStreetLookUp
    {
        private string authToken;
        private string authId;
        
        private SmartyStreets.USAutocompleteApi.Client client;
        private SmartyStreets.USAutocompleteApi.Lookup lookup;
        public SmartyStreetsAPIFactory()
        {
            authId = APISecurityIdentification.AuthId;
            authToken = APISecurityIdentification.AuthToken;
            client = new ClientBuilder(authId, authToken).BuildUsAutocompleteApiClient();
           
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            return ExecuteLookUp(street).Select(x => x.State).ToList();
        }
        public Tuple<bool,string> ValidateStreet(string street)
        {
            var lookupResult = ExecuteLookUp(street);
            if (lookupResult[0].State != ErrorMessages.NoStateFound) return new Tuple<bool, string>(true, ConfidenceLevel.Exact);
            return new Tuple<bool, string>(false, ConfidenceLevel.Failed);
        }
        public string GetZipCodeSearchByStreet(string street)
        {
            Console.WriteLine("Smarty Streets doesn't return Zip Code");
            return string.Empty;
        }

        public string GetStateSearchByStreet(string street)
        {
            return ExecuteLookUp(street).Select(x => x.State).FirstOrDefault();
        }
        public string GetStateSearchByStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join(" ", street, zipCode);
            return ExecuteLookUp(streetAndZipCode).Select(x => x.State).FirstOrDefault();
        }

        public Tuple<bool, string> ValidateStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join(" ", street, zipCode);
            var lookupResult = ExecuteLookUp(streetAndZipCode);
            if (lookupResult[0].State != ErrorMessages.NoStateFound) return new Tuple<bool, string>(true, ConfidenceLevel.Exact);
            return new Tuple<bool, string>(false, ConfidenceLevel.Failed);
        }
        private Suggestion[] ExecuteLookUp(string street)
        {
            lookup = new SmartyStreets.USAutocompleteApi.Lookup(street.ToLower());
            lookup.GeolocateType = FilterSearch.GeoLocation;
            lookup.MaxSuggestions = FilterSearch.MaxAddresses;
            client.Send(lookup);
            if (lookup.Result == null) return new Suggestion[] { new Suggestion { State = ErrorMessages.NoStateFound } };
            return lookup.Result;
        }

        private  static  class APISecurityIdentification
        {
            public const string AuthId = "cbc5700b-27a4-a562-a2e2-e9e8ec30638c";
            public const string AuthToken = "TLld5U94YFK7fhg8WD4l";
        }

        
    }
}
