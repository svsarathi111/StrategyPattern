using System.Collections.Generic;
using System.Configuration;

namespace ExchangeRateFinder
{
    class Globals
    {
        public static string printMode, basecurrency, outputCurrency;

        public static List<decimal> results = new List<decimal>();

        public static void GetConfigData()
        {
            printMode = ConfigurationManager.AppSettings["PrintMode"].ToLower();
            basecurrency = ConfigurationManager.AppSettings["BASE"];
            outputCurrency = ConfigurationManager.AppSettings["OUTPUT"];
        }
    }
}
