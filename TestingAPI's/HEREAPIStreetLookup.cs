using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Core;
using TestingAPI_s.DTO.HEREAPI;
using TestingAPI_s.Enums;
using TestingAPI_s.Factory;
using TestingAPI_s.Utilis;

namespace TestingAPI_s
{
    public class HEREAPIStreetLookup : IStreetLookUp
    {
        private IRestClient _client;

        public HEREAPIStreetLookup()
        {
            _client = new RestClient("https://geocode.search.hereapi.com/v1/");
        }
        public APIsOptions GetNameOfAPI()
        {
            return APIsOptions.HERE;
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Items == null||response.Data.Items.Count==0 ? new List<string> { ErrorMessages.NoStateFound } :
                 response.Data.Items.Select(x => x.Address).Select(x => x.StateCode).ToList();
        }

        public List<string> GetStatesSearchByStreetAndZip(string street, string zipCode)
        {
            var response = SendRequest(street,zipCode);
            return response.Data.Items == null || response.Data.Items.Count == 0 ? new List<string> { ErrorMessages.NoStateFound } :
                 response.Data.Items.Select(x => x.Address).Select(x => x.StateCode).ToList();
        }

        public List<string> GetZipCodesSearchByStreet(string street)
        {
            var response = SendRequest(street);
            return response.Data.Items.Select(x => x.Address).Select(x => x.PostalCode).ToList();
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

        private IRestResponse<JSONDetailsHERE> SendRequest(string street, string zipCode = "")
        {
            var request = new RestRequest("geocode");
            SetQueryParameters(request, street,zipCode);
            var response = _client.Get<JSONDetailsHERE>(request);
            return response;
        }
        private ValidationResult CheckValidationAndConfidance(IRestResponse<JSONDetailsHERE> response)
        {
            if (response.Data.Items.Count == 1 && response.Data.Items!=null) return new ValidationResult(true, ConfidenceLevel.Exact);
            if (response.Data.Items.Count > 1 && response.Data.Items!=null) return new ValidationResult(true, ConfidenceLevel.Interpolated);
            return new ValidationResult(false, ConfidenceLevel.Failed);
        }
        private void SetQueryParameters(RestRequest request, string street,string zipCode="")
        {
            request.AddHeader(Params.HEREAPI.Bearer,Authorization.BearerToken);
            request.AddQueryParameter(Params.HEREAPI.ApiKey, Authorization.APIKey);
            request.AddQueryParameter(Params.HEREAPI.In, "countryCode:USA");
            if (zipCode != "")
                request.AddQueryParameter(Params.HEREAPI.Query,"street="+street+";postalCode="+zipCode);
            else
                request.AddQueryParameter("q",street);
           

        }
        private static partial class Authorization
        {
            public const string APIKey = "MrdqLwKqMHBOo4zPy0dM4hbS3ERzOOAHomecyDLwcLI";
            public const string BearerToken = "hwpAJCKO8WzJBKSt3wbuKg";

        }
    }
}
