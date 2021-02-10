using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Core;

namespace TestingAPI_s.Utilis
{
    public static class MatchedStatistic
    {
        public static StatisticOfMatched Calculate(List<string> states, string correctState, StatisticOfMatched statisticOfMatched,List<StreetLookupInput> textResource)
        {
            if (states.Contains(correctState))
            {
                statisticOfMatched.NumberOfMatched += 1;
            }
            statisticOfMatched.PercentageOfMatched = (statisticOfMatched.NumberOfMatched / textResource.Count) * 100;
            return statisticOfMatched;
        }
    }
}
