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
        private IRestClient client;
        private IRestRequest request;
        private SmartyStreets.USAutocompleteApi.Client clientLookup;
        private SmartyStreets.USAutocompleteApi.Lookup lookup;
        private string authToken;
        private string authId;

        public SmartyStreetsAPIFactory()
        {
            client = new RestClient("https://us-street.api.smartystreets.com/");
            request = new RestRequest("street-address");
            authId = APISecurityIdentification.AuthId;
            authToken = APISecurityIdentification.AuthToken;
            clientLookup = new ClientBuilder(authId, authToken).BuildUsAutocompleteApiClient();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            return ExecuteLookUp(street).Select(x => x.State).ToList();
        }
        public Tuple<bool, string> ValidateStreet(string street)
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
            ClearAndAddParameterForStreet(street,zipCode);
            var response = client.Get<List<ItemDetailsSmartyStreets>>(request);
            return response.Data.SelectMany(x => x.components).Select(x => x.state_abbreviation).FirstOrDefault();
        }

        public Tuple<bool, string> ValidateStreetAndZip(string street, string zipCode)
        {
            ClearAndAddParameterForStreet(street, zipCode);
            var response = client.Get<List<ItemDetailsSmartyStreets>>(request);
            if (response.Data.Count == 0) return new Tuple<bool, string>(false, ConfidenceLevel.Failed);
            return new Tuple<bool, string>(true, ConfidenceLevel.Exact);
        }

        private void ClearAndAddParameterForStreet(string street,string zipCode)
        {
            if (request.Parameters.Count == 0) { 
            request.AddQueryParameter(SmartyQueryParams.AuthId, APISecurityIdentification.AuthId);
            request.AddQueryParameter(SmartyQueryParams.AuthToken, APISecurityIdentification.AuthToken);
            }
            if (request.Parameters.Count > 2)
            {
                request.Parameters.RemoveRange(2, request.Parameters.Count-2);
            }
            request.AddQueryParameter(SmartyQueryParams.Street, street);
            request.AddQueryParameter(SmartyQueryParams.ZipCode, zipCode);
            request.AddQueryParameter(SmartyQueryParams.Candidates,FilterSearch.MaxCandidates);
            request.AddQueryParameter(SmartyQueryParams.Match, FilterSearch.MatchInvalid);
        }
        private Suggestion[] ExecuteLookUp(string street)
        {
            lookup = new SmartyStreets.USAutocompleteApi.Lookup(street);
            lookup.GeolocateType = FilterSearch.GeoLocation;
            lookup.MaxSuggestions = FilterSearch.MaxAddress;
            clientLookup.Send(lookup);
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
