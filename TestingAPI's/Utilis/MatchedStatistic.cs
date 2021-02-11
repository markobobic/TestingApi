using System.Collections.Generic;
using TestingAPI_s.Core;
using TestingAPI_s.Enums;
using TestingAPI_s.Initilizer;

namespace TestingAPI_s.Utilis
{
    public static class MatchedStatistic
    {
        public static Dictionary<AddressCorrectness, Statistics> Calculate(List<string> states, string correctState, StatisticsOfCorrectAddress statsCorrectAddr,
            StatisticsOfIncorrectAddress statsIncorrectAddr, Dictionary<AddressCorrectness, Statistics> results)

        {
            if (TestRunner.Counter <= 70) { 
                
             results[AddressCorrectness.Correct] = AnaylyzeForCorrectAddress(states, correctState, statsCorrectAddr);
            }
            if (TestRunner.Counter >= 70) { 
            results[AddressCorrectness.Incorrect] = AnaylyzeForIncorrectAddress(states, correctState, statsIncorrectAddr);
            }
            return results;
        }

        private static StatisticsOfCorrectAddress AnaylyzeForCorrectAddress(List<string> states, string correctState, StatisticsOfCorrectAddress statsCorrectAddr)
           
        {
            if (states.Contains(correctState))
            {
                statsCorrectAddr.NumberOfMatched += 1;
            }
            statsCorrectAddr.PercentageOfMatched = (statsCorrectAddr.NumberOfMatched / 70) * 100;
            return statsCorrectAddr;
        }

        private static StatisticsOfIncorrectAddress AnaylyzeForIncorrectAddress(List<string> states, string correctState, StatisticsOfIncorrectAddress statsIncorrectAddr)
        {
            if (states.Contains(correctState))
            {
                statsIncorrectAddr.NumberOfMatched += 1;
            }
            statsIncorrectAddr.PercentageOfMatched = (statsIncorrectAddr.NumberOfMatched / 30) * 100;
            return statsIncorrectAddr;
        }
    }
}
