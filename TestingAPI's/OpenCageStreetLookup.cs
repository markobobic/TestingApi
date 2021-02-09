using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.Core;
using TestingAPI_s.DTO.OpenCageAPI;
using TestingAPI_s.Enums;
using TestingAPI_s.ExtensionMethods;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
    public class OpenCageStreetLookup : IStreetLookUp
    {
        private IRestClient _client;

        public OpenCageStreetLookup()
        {
            _client = new RestClient("https://api.opencagedata.com/geocode/v1/");
        }

        public List<string> GetStatesSearchByStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.StateCode).ToList();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.StateCode).ToList();
        }

        public List<string> GetZipCodesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.Postcode).ToList();
        }

        public ValidationResult ValidateStreet(string street)
        {
            var response = SendRequest(street);
            return CheckValidationAndConfidance(response);
        }

        public ValidationResult ValidateStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street, zipCode);
            return CheckValidationAndConfidance(response);
        }
        private void SetQueryParameters(RestRequest request,string street)
        {
            request.AddQueryParameter(Params.OpenCageAPI.Key, APISecurityIdentification.AuthKey);
            request.AddQueryParameter(Params.OpenCageAPI.Query, street);
            request.AddQueryParameter(Params.OpenCageAPI.Language, "en");
            request.AddQueryParameter(Params.OpenCageAPI.Pretty, "1");
            request.AddQueryParameter(Params.OpenCageAPI.CountryCode, "us");
        }
        private IRestResponse<JSONDetailsOpenCage> SendRequest(string street, string zipCode = "")
        {
            var request = new RestRequest("json");
            var streetAndZipCode = string.Join(" ", street, zipCode).TrimEnd();
            SetQueryParameters(request, streetAndZipCode);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            return response;
        }
        private ValidationResult CheckValidationAndConfidance(IRestResponse<JSONDetailsOpenCage> response)
        {
            var confidanceRate = response.Data.Results.Select(x => x.Confidence.TryParseNull()).FirstOrDefault();
            var confidance = confidanceRate >= 9 ? ConfidenceLevel.Exact : (confidanceRate >= 5 ? ConfidenceLevel.Interpolated
                : confidanceRate <=3 || confidanceRate == null ? ConfidenceLevel.Failed : ConfidenceLevel.Fallback);
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated
                || confidance == ConfidenceLevel.Fallback) return new ValidationResult(true, confidance);
            return new ValidationResult(false, ConfidenceLevel.Failed);
        }
        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.OpenCage;
        }

       
        private static class APISecurityIdentification
        {
            public const string AuthKey = "e2a1a3e9e19f474d92c708d33afb75e3";
            
        }
    }
}
