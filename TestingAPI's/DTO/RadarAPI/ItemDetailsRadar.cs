using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.DTO
{

    public class ItemDetailsRadar
    {
        public List<ItemRadar> addresses { get; set; }
    }
    public class ItemRadar
    {
        public string country { get; set; }
        public string countryCode { get; set; }
        public double distance { get; set; }
        public string confidence { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string stateCode { get; set; }
        public string number { get; set; }
        public string street { get; set; }
        public string formattedAddress { get; set; }

    }
}
