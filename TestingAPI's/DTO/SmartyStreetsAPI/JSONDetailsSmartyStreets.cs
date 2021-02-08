using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestingAPI_s.DTO.SmartyStreetsAPI
{
    public class JSONDetailsSmartyStreets
    {
        [JsonProperty("components")]
        public List<ItemSmartyStreets> Components { get; set; }
    }
    public class ItemSmartyStreets
    {
        [JsonProperty("primary_number")]
        public string PrimaryNumber { get; set; }
        [JsonProperty("street_name")]
        public string StreetName { get; set; }
        [JsonProperty("street_suffix")]
        public string StreetSuffix { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("default_city_name")]
        public string DefaultCityName { get; set; }
        [JsonProperty("state_abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }
        [JsonProperty("plus4_code")]
        public string Plus4Code { get; set; }
        [JsonProperty("delivery_point")]
        public string DeliveryPoint { get; set; }
        [JsonProperty("delivery_point_check_digit")]
        public string DeliveryPointCheckDigit { get; set; }

    }
}
