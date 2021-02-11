using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.Core;
using TestingAPI_s.DTO;
using TestingAPI_s.Enums;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
    public class RadarAPIStreetLookup : IStreetLookUp
    {
        private IRestClient _client;

        public RadarAPIStreetLookup()
        {
            _client = new RestClient("https://api.radar.io/v1/search/");
        }
       
        public List<string> GetStatesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Addresses == null || response.Data.Addresses.Count == 0 || response.Data == null ?
            new List<string> { ErrorMessages.NoStateFound } :
            response.Data.Addresses.Select(x => x.StateCode==null?ErrorMessages.NoStateFound:x.StateCode).ToList();
        }
        public List<string> GetZipCodesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Addresses == null || response.Data.Addresses.Count == 0 || response.Data == null ?
            new List<string> { ErrorMessages.NoPostalCodeFound } :
            response.Data.Addresses.Select(x => x.PostalCode==null?ErrorMessages.NoPostalCodeFound:x.PostalCode).ToList();
        }

        public ValidationResult ValidateStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street,zipCode);
            return CheckValidationAndConfidance(response);

        }
        public List<string> GetStatesSearchByStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            return response.Data.Addresses == null || response.Data.Addresses.Count==0 || response.Data == null ? new List<string> { ErrorMessages.NoStateFound } :
             response.Data.Addresses.Select(x => x.StateCode == null ? ErrorMessages.NoStateAndZipFound : x.StateCode).ToList();
        }

        public ValidationResult ValidateStreet(string street)
        {
            var response = SendRequest(street);
            return CheckValidationAndConfidance(response);
        }
       
        private void SetQueryParameters(RestRequest request, string street)
        {
           request.AddHeader(Params.RadarAPI.Authorization, Authorization.Code);
           request.AddQueryParameter(Params.RadarAPI.Query, street);
           request.AddQueryParameter(Params.RadarAPI.Limit, "100");
           
        }
        private IRestResponse<JSONDetailsRadar> SendRequest(string street, string zipCode = "")
        {
            var request = new RestRequest("autocomplete");
            var streetAndZipCode = string.Join(" ,", street, zipCode).TrimEnd();
            SetQueryParameters(request, streetAndZipCode);
            var response = _client.Get<JSONDetailsRadar>(request);
            return response;
        }
        private ValidationResult CheckValidationAndConfidance(IRestResponse<JSONDetailsRadar> response)
        {
            if (response.Data.Addresses.Count == 1 && response.Data.Addresses != null) return new ValidationResult(true, ConfidenceLevel.Exact);
            if (response.Data.Addresses.Count > 1 && response.Data.Addresses != null) return new ValidationResult(true, ConfidenceLevel.Interpolated);
            return new ValidationResult(false, ConfidenceLevel.Failed);
        }
        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.Radar;
        }

       
        private static partial class Authorization
        {
            public const string Code = "prj_live_sk_d2c9fb8f3b1c2f4de29452ea45076fbba7b51c48";


        }
    }
   
}
