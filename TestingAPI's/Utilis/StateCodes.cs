using System.Collections.Generic;

namespace TestingAPI_s.Utilis
{
    public static class StateCodes
    {
        public static Dictionary<string,string> MakeListOfStatesAndStateCodes()
        {
            Dictionary<string, string> states = new Dictionary<string, string>();
            states.Add("Alabama", "AL");
            states.Add("Alaska", "AK");
            states.Add("Alberta", "AB");
            states.Add("American Samoa", "AS");
            states.Add("Arizona", "AZ");
            states.Add("Arkansas", "AR");
            states.Add("Armed Forces (AE)", "AE");
            states.Add("Armed Forces Americas", "AA");
            states.Add("Armed Forces Pacific", "AP");
            states.Add("British Columbia", "BC");
            states.Add("California", "CA");
            states.Add("Colorado", "CO");
            states.Add("Connecticut", "CT");
            states.Add("Delaware", "DE");
            states.Add("District of Columbia", "DC");
            states.Add("Florida", "FL");
            states.Add("Georgia", "GA");
            states.Add("Guam", "GU");
            states.Add("Hawaii", "HI");
            states.Add("Idaho", "ID");
            states.Add("Illinois", "IL");
            states.Add("Indiana", "IN");
            states.Add("Iowa", "IA");
            states.Add("Kansas", "KS");
            states.Add("Kentucky", "KY");
            states.Add("Louisiana", "LA");
            states.Add("Maine", "ME");
            states.Add("Manitoba", "MB");
            states.Add("Maryland", "MD");
            states.Add("Massachusetts", "MA");
            states.Add("Michigan", "MI");
            states.Add("Minnesota", "MN");
            states.Add("Mississippi", "MS");
            states.Add("Missouri", "MO");
            states.Add("Montana", "MT");
            states.Add("Nebraska", "NE");
            states.Add("Nevada", "NV");
            states.Add("New Brunswick", "NB");
            states.Add("New Hampshire", "NH");
            states.Add("New Jersey", "NJ");
            states.Add("New Mexico", "NM");
            states.Add("New York", "NY");
            states.Add("Newfoundland", "NF");
            states.Add("North Carolina", "NC");
            states.Add("North Dakota", "ND");
            states.Add("Northwest Territories", "NT");
            states.Add("Nova Scotia", "NS");
            states.Add("Nunavut", "NU");
            states.Add("Ohio", "OH");
            states.Add("Oklahoma", "OK");
            states.Add("Ontario", "ON");
            states.Add("Oregon", "OR");
            states.Add("Pennsylvania", "PA");
            states.Add("Prince Edward Island", "PE");
            states.Add("Puerto Rico", "PR");
            states.Add("Quebec", "QC");
            states.Add("Rhode Island", "RI");
            states.Add("Saskatchewan", "SK");
            states.Add("South Carolina", "SC");
            states.Add("South Dakota", "SD");
            states.Add("Tennessee", "TN");
            states.Add("Texas", "TX");
            states.Add("Utah", "UT");
            states.Add("Vermont", "VT");
            states.Add("Virgin Islands", "VI");
            states.Add("Virginia", "VA");
            states.Add("Washington", "WA");
            states.Add("West Virginia", "WV");
            states.Add("Wisconsin", "WI");
            states.Add("Wyoming", "WY");
            states.Add("Yukon Territory", "YT");
            return states;
        }
        public static string GetStateCode(string stateName,Dictionary<string,string> states)
        {
            return states[stateName];
        }
    }
}
