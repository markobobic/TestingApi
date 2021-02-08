using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TestingAPI_s.DTO.LocationlQAPI;
using TestingAPI_s.Enums;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
    public class LocationlQStreetLookup : IStreetLookUp
    {
        private IRestClient client;

        public LocationlQStreetLookup()
        {
            client = new RestClient("https://us1.locationiq.com/v1/");            
        }

        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.LocationlQ;
        }

        public string GetStateSearchByStreet(string street)
        {
            var request = new RestRequest("search.php");
            SetQueryParameters(request,street);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            return response.Data.SelectMany(x => x.Address).Select(y => y.State).FirstOrDefault();
        }

        public string GetStateSearchByStreetAndZip(string street, string zipCode)
        {
            System.Threading.Thread.Sleep(2000);
            var request = new RestRequest("search.php");
            var streetAndZipCode = string.Join(" ", street, zipCode);
            SetQueryParameters(request,streetAndZipCode);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            return response.Data[0].Address == null?  ErrorMessages.NoStateFound: 
                response.Data.SelectMany(x => x.Address).Select(y => y.ExtendedState).FirstOrDefault();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            System.Threading.Thread.Sleep(2000); //rate limit if api is consumed free
            var request = new RestRequest("search.php");
            SetQueryParameters(request, street);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            return response.Data[0].Address == null ? new List<string> { ErrorMessages.NoStateFound } :
                 response.Data.SelectMany(x => x.Address).Select(y => y.ExtendedState).ToList();
        }

        public string GetZipCodeSearchByStreet(string street)
        {
            var request = new RestRequest("search.php");
            SetQueryParameters(request, street);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            return response.Data.SelectMany(x => x.Address).Select(x => x.Postcode).FirstOrDefault();
        }

        public (bool isValid, string accuracy) ValidateStreet(string street)
        {
            var request = new RestRequest("search.php");
            SetQueryParameters(request, street);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            if (response.Data[0].Address==null) return (false, ConfidenceLevel.Failed);
            return (true, ConfidenceLevel.Exact);
        }

        public (bool isValid, string accuracy) ValidateStreetAndZip(string street, string zipCode)
        {
            var request = new RestRequest("search.php");
            var streetAndZipCode = string.Join(" ", street, zipCode);
            SetQueryParameters(request,streetAndZipCode);
            var response = client.Get<List<JSONDetailsLocationlQ>>(request);
            if (response.Data[0].Address==null) return (false, ConfidenceLevel.Failed);
            return (true, ConfidenceLevel.Exact);
        }

        private void SetQueryParameters(RestRequest request, string street)
        {
            request.AddQueryParameter(Params.LocationlQAPI.Key, APISecurityIdentification.APIKey);
            request.AddQueryParameter(Params.LocationlQAPI.Query, street);
            request.AddQueryParameter(Params.LocationlQAPI.Countrycodes, "us"); 
            request.AddQueryParameter(Params.LocationlQAPI.AddressDetails, "1");
            request.AddQueryParameter(Params.LocationlQAPI.Format, "json");
            request.AddQueryParameter(Params.LocationlQAPI.Postaladdress, "1");
        }

        private static class APISecurityIdentification
        {
            public const string APIKey = "pk.b1a3158bf38dab9cab1638f50044f320";
        }
    }
}
