using System;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Factory
{
    public static class StreetLookupFactory
    {
        public static IStreetLookUp Create(APIsOptions option)
        {
            switch (option)
            {
                case APIsOptions.Radar: return new RadarAPIStreetLookup();
                case APIsOptions.SmartyStreets: return new SmartyStreetsAPILookup();
                case APIsOptions.OpenCage: return new OpenCageStreetLookup();
                case APIsOptions.LocationlQ: return new LocationlQStreetLookup();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
