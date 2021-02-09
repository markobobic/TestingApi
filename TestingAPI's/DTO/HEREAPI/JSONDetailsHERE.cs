﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestingAPI_s.DTO.HEREAPI
{
    public class JSONDetailsHERE
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
    public class Address
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        [JsonProperty("stateCode")]
        public string StateCode { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }
    }

    public class Item
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }

   
}
