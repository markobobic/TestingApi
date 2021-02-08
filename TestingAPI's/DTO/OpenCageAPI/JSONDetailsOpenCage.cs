using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestingAPI_s.DTO.OpenCageAPI
{
    public class JSONDetailsOpenCage
    {
        [JsonProperty("results")]
        public List<JSONDetailsAddress> Results { get; set; }
    }
    public class JSONDetailsAddress
    {
        [JsonProperty("confidence")]
        public string Confidence { get; set; }
        [JsonProperty("components")]
        public List<ItemOpenCage> Components { get; set; }
    }
    public class ItemOpenCage
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        [JsonProperty("_category")]
        public string Category { get; set; }
        [JsonProperty("continent")]
        public string Continent { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("road")]
        public string Road { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("state_code")]
        public string StateCode { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }


    }
}
