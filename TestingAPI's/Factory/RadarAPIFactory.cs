using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.DTO;
using TestingAPI_s.Utilis;

namespace TestingAPI_s.Factory
{
    public class RadarAPIFactory : IStreetLookUp
    {
        private IRestClient client;
        private IRestRequest request;

        public RadarAPIFactory()
        {
            client = new RestClient("https://api.radar.io/v1/geocode/");
            request = new RestRequest("forward");
               
        }
        #region Getting data
        public string GetStateSearchByStreet(string street)
        {
            ClearAndAddParameterForStreet(street);
            var response = client.Get<ItemDetailsRadar>(request);
            return response.Data.addresses.Select(x => x.stateCode).FirstOrDefault().ToString();
        }

        public List<string> GetStatesSearchByStreet(string street)
        {
            Console.WriteLine("Radar API doesn't have feature for mulitple states");
            return new List<string>();
        }

        public string GetZipCodeSearchByStreet(string street)
        {
            ClearAndAddParameterForStreet(street);
            var response = client.Get<ItemDetailsRadar>(request);
            return response.Data.addresses.Select(x => x.postalCode==null?ErrorMessages.NoPostalCodeFound: x.postalCode)
                .FirstOrDefault().ToString();
        }
        public Tuple<bool,string> ValidateStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join(" ", street, zipCode);
            ClearAndAddParameterForStreet(streetAndZipCode);
            var response = client.Get<ItemDetailsRadar>(request);
            var confidance = response.Data.addresses.Select(x => x.confidence).FirstOrDefault().ToString();
            if (confidance ==ConfidenceLevel.Exact || confidance== ConfidenceLevel.Interpolated ||
                confidance == ConfidenceLevel.Fallback ) return new Tuple<bool, string>(true,confidance);
            return new Tuple<bool, string>(false, ConfidenceLevel.Failed);

        }
        public string GetStateSearchByStreetAndZip(string street, string zipCode)
        {
            var streetAndZipCode = string.Join("", street, zipCode);
            ClearAndAddParameterForStreet(streetAndZipCode);
            var response = client.Get<ItemDetailsRadar>(request);
            return response.Data.addresses.Select(x => x.stateCode).FirstOrDefault().ToString();

        }

        #endregion
        #region Validation
        public Tuple<bool,string> ValidateStreet(string street)
        {
            ClearAndAddParameterForStreet(street);
            var response = client.Get<ItemDetailsRadar>(request);
            var confidance = response.Data.addresses.Select(x => x.confidence).FirstOrDefault().ToString();
            if (confidance == ConfidenceLevel.Exact || confidance == ConfidenceLevel.Interpolated 
                || confidance == ConfidenceLevel.Fallback) return new Tuple<bool, string>(true, confidance);
            return new Tuple<bool, string>(false, ConfidenceLevel.Failed);

        }
        #endregion
        private void ClearAndAddParameterForStreet(string street)
        {
            if(request.Parameters.Count==0)
            request.AddHeader("Authorization", Authorization.Code);
            if (request.Parameters.Count > 1) { 
            request.Parameters.Remove(request.Parameters[1]);
            }
            request.AddQueryParameter("query", street);
        }
        private static partial class Authorization
        {
            public const string Code = "prj_live_sk_d2c9fb8f3b1c2f4de29452ea45076fbba7b51c48";


        }
    }
   
}
