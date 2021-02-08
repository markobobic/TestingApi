using RestSharp;
using SmartyStreets;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.DTO.SmartyStreetsAPI;
using SmartyStreets.USAutocompleteApi;
using TestingAPI_s.Utilis;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Factory
{
    public class SmartyStreetsAPILookup : IStreetLookUp
    {
        private readonly IRestClient _client;
        private Client _clientLookup;
        private Lookup _lookup;
        private string _authToken;
        private string _authId;

        public SmartyStreetsAPILookup()
        {
            _client = new RestClient("https://us-street.api.smartystreets.com/");
            _authId = APISecurityIdentification.AuthId;
            _authToken = APISecurityIdentification.AuthToken;
            _clientLookup = new ClientBuilder(_authId, _authToken).BuildUsAutocompleteApiClient();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            return ExecuteLookUp(street).Select(x => x.State).ToList();
        }

        public (bool isValid, string accuracy) ValidateStreet(string street)
        {
            var lookupResult = ExecuteLookUp(street);
            if (lookupResult[0].State != ErrorMessages.NoStateFound) return (true, ConfidenceLevel.Exact);
            return (false, ConfidenceLevel.Failed);
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
            var request = new RestRequest("street-address");
            SetQueryParameters(request,street, zipCode);
            var response = _client.Get<List<JSONDetailsSmartyStreets>>(request);
            return response.Data.SelectMany(x => x.Components).Select(x => x.StateAbbreviation).FirstOrDefault();
        }

        public (bool isValid, string accuracy) ValidateStreetAndZip(string street, string zipCode)
        {
            var request = new RestRequest("street-address");
            SetQueryParameters(request,street, zipCode);
            var response = _client.Get<List<JSONDetailsSmartyStreets>>(request);
            if (response.Data.Count == 0) return (false, ConfidenceLevel.Failed);
            return (true, ConfidenceLevel.Exact);
        }

        private void SetQueryParameters(RestRequest request,string street,string zipCode)
        {
            request.AddQueryParameter(Params.SmartyStreetsAPI.AuthId, APISecurityIdentification.AuthId);
            request.AddQueryParameter(Params.SmartyStreetsAPI.AuthToken, APISecurityIdentification.AuthToken);
            request.AddQueryParameter(Params.SmartyStreetsAPI.Street, street);
            request.AddQueryParameter(Params.SmartyStreetsAPI.ZipCode, zipCode);
            request.AddQueryParameter(Params.SmartyStreetsAPI.Candidates,FilterSearch.MaxCandidates);
            request.AddQueryParameter(Params.SmartyStreetsAPI.Match, FilterSearch.MatchInvalid);
        }
        private Suggestion[] ExecuteLookUp(string street)
        {
            _lookup = new SmartyStreets.USAutocompleteApi.Lookup(street);
            _lookup.GeolocateType = FilterSearch.GeoLocation;
            _lookup.MaxSuggestions = FilterSearch.MaxAddress;
            _clientLookup.Send(_lookup);
            if (_lookup.Result == null) return new Suggestion[] { new Suggestion { State = ErrorMessages.NoStateFound } };
            return _lookup.Result;
        }

        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.SmartyStreets;
        }

        private  static  class APISecurityIdentification
        {
            public const string AuthId = "cbc5700b-27a4-a562-a2e2-e9e8ec30638c";
            public const string AuthToken = "TLld5U94YFK7fhg8WD4l";
        }
        

    }
}
