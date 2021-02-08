using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestingAPI_s.DTO
{
    public class JSONDetailsRadar
    {
        [JsonProperty("addresses")]
        public List<ItemRadar> Addresses { get; set; }
    }
    public class ItemRadar
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("confidence")]
        public string Confidence { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("stateCode")]
        public string StateCode { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }

    }
}
