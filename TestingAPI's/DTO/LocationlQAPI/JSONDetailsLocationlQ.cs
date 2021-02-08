using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace TestingAPI_s.DTO.LocationlQAPI
{
    public class JSONDetailsLocationlQ
    {
        [JsonProperty("address")]
        public List<ItemLocationlQ> Address { get; set; }
    }

    public class ItemLocationlQ
    {
        private string _extendedState;
        public string ExtendedState
        {
            get { return State; }
            set { _extendedState = value; }
        }

        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty("road")]
        public string Road { get; set; }
        [JsonProperty("hamlet")]
        public string Hamlet { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
