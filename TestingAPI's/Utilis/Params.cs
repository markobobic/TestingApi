namespace TestingAPI_s.Utilis
{
    public static class Params
    { 
        public static class SmartyStreetsAPI
        {
            public const string Street = "street";
            public const string ZipCode = "zipcode";
            public const string Candidates = "candidates";
            public const string Match = "match";
            public const string AuthId = "auth-id";
            public const string AuthToken = "auth-token";
        }

        public static class RadarAPI
        {
            public const string Query = "query";
            public const string Authorization = "Authorization";
        }

        public static class OpenCageAPI
        {
            public const string Query = "q";
            public const string Language = "language";
            public const string Pretty = "pretty";
            public const string Key = "key";
            public const string CountryCode = "countrycode";
        }

        public static class LocationlQAPI
        {
            public const string Query = "q";
            public const string Countrycodes = "countrycodes";
            public const string AddressDetails = "addressdetails";
            public const string Format = "format";
            public const string Key = "key";
            public const string Postaladdress = "postaladdress";

        }

        public static class HEREAPI
        {
            public static string Bearer = "Bearer";
            public static string ApiKey = "apiKey";
            public const string Query = "qq";
            public const string In = "in";

        }

    }
}
