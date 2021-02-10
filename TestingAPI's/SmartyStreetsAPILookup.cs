using RestSharp;
using SmartyStreets;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.DTO.SmartyStreetsAPI;
using SmartyStreets.USAutocompleteApi;
using TestingAPI_s.Utilis;
using TestingAPI_s.Enums;
using TestingAPI_s.Core;

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

        public ValidationResult ValidateStreet(string street)
        {
            var lookupResult = ExecuteLookUp(street);
            if (lookupResult[0].State != ErrorMessages.NoStateFound) return new ValidationResult(true, ConfidenceLevel.Exact);
            return new ValidationResult(false, ConfidenceLevel.Failed);
        }

        public List<string> GetZipCodesSearchByStreet(string street)
        {
            return new List<string> {"Smarty Streets doesn't return Zip Code" };
        }

        public List<string> GetStatesSearchByStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            return response.Data.SelectMany(x => x.Components).Select(x => x.StateAbbreviation).ToList();
        }

        public ValidationResult ValidateStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            return CheckValidationAndConfidance(response);
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
            _lookup = new Lookup(street);
            _lookup.GeolocateType = FilterSearch.GeoLocation;
            _lookup.MaxSuggestions = FilterSearch.MaxAddress;
            _clientLookup.Send(_lookup);
            if (_lookup.Result == null) return new Suggestion[] { new Suggestion { State = ErrorMessages.NoStateFound } };
            return _lookup.Result;
        }
        private IRestResponse<List<JSONDetailsSmartyStreets>> SendRequest(string street, string zipCode = "")
        {
            var request = new RestRequest("street-address");
            SetQueryParameters(request,street,zipCode);
            var response = _client.Get<List<JSONDetailsSmartyStreets>>(request);
            return response;
        }
        private ValidationResult CheckValidationAndConfidance(IRestResponse<List<JSONDetailsSmartyStreets>> response)
        {
            if (response.Data.Count == 0) return new ValidationResult(false, ConfidenceLevel.Failed);
            return new ValidationResult(true, ConfidenceLevel.Exact);
        }

        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.SmartyStreets;
        }

        private  static  class APISecurityIdentification
        {
            public const string AuthId = "6ed9d44c-a080-fee2-fc4e-c87e2922eb63";
            public const string AuthToken = "ZinXJP79afaeRiZXQsQQ";
        }
        

    }
}
