using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.DTO.SmartyStreetsAPI
{
    public class ItemDetailsSmartyStreets
    {
        public List<ItemSmartyStreets> components { get; set; }
    }
    public class ItemSmartyStreets
    {
        public string primary_number { get; set; }
        public string street_name { get; set; }
        public double street_suffix { get; set; }
        public string city_name { get; set; }
        public string default_city_name { get; set; }
        public string state_abbreviation { get; set; }
        public string zipcode { get; set; }
        public string plus4_code { get; set; }
        public string delivery_point { get; set; }
        public string delivery_point_check_digit { get; set; }

    }
}
