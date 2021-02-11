using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.Core;
using TestingAPI_s.DTO.LocationlQAPI;
using TestingAPI_s.Enums;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
    public class LocationlQStreetLookup : IStreetLookUp
    {
        private IRestClient _client;
        private Dictionary<string, string> _listOfStates;

        public LocationlQStreetLookup()
        {
            _client = new RestClient("https://us1.locationiq.com/v1/");
            _listOfStates = StateCodes.MakeListOfStatesAndStateCodes();
        }

        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.LocationlQ;
        }

        public List<string> GetStatesSearchByStreetAndZip(string street, string zipCode)
        {
            System.Threading.Thread.Sleep(2000);
            var response = SendRequest(street, zipCode);
            return response.Data == null || response.Data[0].Address == null || response.Data[0].Address.Count == 0 ? 
            new List<string> { ErrorMessages.NoStateFound } :
            response.Data.SelectMany(x => x.Address).Select(y => y.ExtendedState).ToList()
            .Select(state => StateCodes.GetStateCode(state, _listOfStates)).ToList();
               
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            System.Threading.Thread.Sleep(2000); //rate limit if api is consumed free
            var response = SendRequest(street);
            return response.Data==null||response.Data[0].Address ==null || response.Data[0].Address.Count==0? new List<string> { ErrorMessages.NoStateFound } :
            response.Data.SelectMany(x => x.Address).Select(y => y.ExtendedState).ToList()
            .Select(state => StateCodes.GetStateCode(state, _listOfStates)).ToList();
        }

        public List<string> GetZipCodesSearchByStreet(string street)
        {
            System.Threading.Thread.Sleep(2000);
            var response = SendRequest(street);
            return response.Data == null || response.Data[0].Address == null || response.Data[0].Address.Count == 0 ? 
            new List<string> { ErrorMessages.NoPostalCodeFound } :
            response.Data.SelectMany(x => x.Address)
            .Select(x => x.Postcode==null?ErrorMessages.NoPostalCodeFound:x.Postcode).ToList();
        }

        public ValidationResult ValidateStreet(string street)
        {
            var response = SendRequest(street);
            if (response.Data[0].Address == null) return new ValidationResult(false, ConfidenceLevel.Failed);
            return new ValidationResult(true, ConfidenceLevel.Exact);
        }

        public ValidationResult ValidateStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            if (response.Data[0].Address==null) return new ValidationResult(false, ConfidenceLevel.Failed);
            return new ValidationResult(true, ConfidenceLevel.Exact);
        }

        private void SetQueryParameters(RestRequest request, string street)
        {
            request.AddQueryParameter(Params.LocationlQAPI.Key, APISecurityIdentification.APIKey);
            request.AddQueryParameter(Params.LocationlQAPI.Query, street);
            request.AddQueryParameter(Params.LocationlQAPI.Countrycodes, "us"); 
            request.AddQueryParameter(Params.LocationlQAPI.AddressDetails, "1");
            request.AddQueryParameter(Params.LocationlQAPI.Format, "json");
            request.AddQueryParameter(Params.LocationlQAPI.Postaladdress, "1");
            request.AddQueryParameter(Params.LocationlQAPI.Limit, "1000");
        }

        private IRestResponse<List<JSONDetailsLocationlQ>> SendRequest(string street,string zipCode="")
        {
            var request = new RestRequest("search.php");
            var streetAndZipCode = string.Join(" ", street, zipCode).TrimEnd();
            SetQueryParameters(request, streetAndZipCode);
            var response = _client.Get<List<JSONDetailsLocationlQ>>(request);
            return response;
        }

        private static class APISecurityIdentification
        {
            public const string APIKey = "pk.b1a3158bf38dab9cab1638f50044f320";
        }
    }
}
