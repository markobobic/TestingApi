using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _client = new RestClient("https://api.radar.io/v1/geocode/");
        }
       
        public string GetStateSearchByStreet(string street)
        {
            var request = new RestRequest("forward");
            SetQueryParameters(request,street);
            var response = _client.Get<JSONDetailsRadar>(request);
            return response.Data.Addresses.Select(x => x.StateCode).FirstOrDefault().ToString();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            Console.WriteLine("Radar API doesn't have feature for mulitple states");
            return new List<string>();
        }

        public string GetZipCodeSearchByStreet(string street)
        {
            var request = new RestRequest("forward");
            SetQueryParameters(request,street);
            var response = _client.Get<JSONDetailsRadar>(request);
            return response.Data.Addresses.Select(x => x.PostalCode==null?ErrorMessages.NoPostalCodeFound: x.PostalCode)
                .FirstOrDefault().ToString();
        }
        public (bool isValid, string accuracy) ValidateStreetAndZip(string street, string zipCode)
        {
            var request = new RestRequest("forward");
            var streetAndZipCode = string.Join(" ", street, zipCode);
            SetQueryParameters(request,streetAndZipCode);
            var response = _client.Get<JSONDetailsRadar>(request);
            if(response.Data.Addresses.Count==0) return (false, ConfidenceLevel.Failed);
            var confidance = response.Data.Addresses.Select(x => x.Confidence).FirstOrDefault().ToString();
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated ||
                confidance == ConfidenceLevel.Fallback) return (true, confidance);
            return (false, ConfidenceLevel.Failed);

        }
        public string GetStateSearchByStreetAndZip(string street, string zipCode)
        {
            var request = new RestRequest("forward");
            var streetAndZipCode = string.Join(" ", street, zipCode);
            SetQueryParameters(request, streetAndZipCode);
            var response = _client.Get<JSONDetailsRadar>(request);
            if (response.Data.Addresses.Count == 0) return ErrorMessages.NoStateAndZipFound;
            return response.Data.Addresses.Select(x => x.StateCode == null ? ErrorMessages.NoStateAndZipFound : x.StateCode).
                FirstOrDefault();
             
        }

        public (bool isValid, string accuracy) ValidateStreet(string street)
        {
            var request = new RestRequest("forward");
            SetQueryParameters(request, street);
            var response = _client.Get<JSONDetailsRadar>(request);
            var confidance = response.Data.Addresses.Select(x => x.Confidence).FirstOrDefault();
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated 
                || confidance == ConfidenceLevel.Fallback) return(true, confidance);
            return (false, ConfidenceLevel.Failed);

        }
       
        private void SetQueryParameters(RestRequest request, string street)
        {
           request.AddHeader(Params.RadarAPI.Authorization, Authorization.Code);
           request.AddQueryParameter(Params.RadarAPI.Query, street);
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
