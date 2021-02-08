using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.OpenCage;
        }

        public string GetStateSearchByStreet(string street)
        {
            var request = new RestRequest("json");
            SetQueryParameters(request,street);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.StateCode).FirstOrDefault();
        }

        public string GetStateSearchByStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join(",", street, zipCode);
            var request = new RestRequest("json");
            SetQueryParameters(request, streetAndZipCode);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.StateCode).FirstOrDefault();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            Console.WriteLine("Radar API doesn't have feature for mulitple states");
            return new List<string>();
        }

        public string GetZipCodeSearchByStreet(string street)
        {
            var request = new RestRequest("json");
            SetQueryParameters(request, street);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            return response.Data.Results.SelectMany(x => x.Components).Select(x => x.Postcode).FirstOrDefault();
        }

        public (bool isValid, string accuracy) ValidateStreet(string street)
        {
            var request = new RestRequest("json");
            SetQueryParameters(request,street);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            var confidanceRate = response.Data.Results.Select(x => x.Confidence.TryParseNull()).FirstOrDefault();
            var confidance = confidanceRate >= 9 ? ConfidenceLevel.Exact : (confidanceRate >= 5 ? ConfidenceLevel.Interpolated
                : confidanceRate==0? ConfidenceLevel.Failed :ConfidenceLevel.Fallback);
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated
                || confidance == ConfidenceLevel.Fallback) return (true, confidance);
            return (false, ConfidenceLevel.Failed);
        }

        public (bool isValid, string accuracy) ValidateStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join(",", street, zipCode);
            var request = new RestRequest("json");
            SetQueryParameters(request,streetAndZipCode);
            var response = _client.Get<JSONDetailsOpenCage>(request);
            var confidanceRate = response.Data.Results.Select(x => x.Confidence.TryParseNull()).FirstOrDefault();
            var confidance = confidanceRate >= 9 ? ConfidenceLevel.Exact : (confidanceRate >= 5 ? ConfidenceLevel.Interpolated
                : confidanceRate == 0 ? ConfidenceLevel.Failed : ConfidenceLevel.Fallback);
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated
                || confidance == ConfidenceLevel.Fallback) return (true, confidance);
            return (false, ConfidenceLevel.Failed);
        }
        private void SetQueryParameters(RestRequest request,string street)
        {
            request.AddQueryParameter(Params.OpenCageAPI.Key, APISecurityIdentification.AuthKey);
            request.AddQueryParameter(Params.OpenCageAPI.Query, street);
            request.AddQueryParameter(Params.OpenCageAPI.Language, "en");
            request.AddQueryParameter(Params.OpenCageAPI.Pretty, "1");
        }
        private static class APISecurityIdentification
        {
            public const string AuthKey = "e2a1a3e9e19f474d92c708d33afb75e3";
            
        }
    }
}
