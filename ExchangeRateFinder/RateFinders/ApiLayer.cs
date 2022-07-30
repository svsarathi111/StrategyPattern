using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ExchangeRateFinder.RateFinders
{
    class ApiLayer : ISources
    {
        public string url = "https://api.apilayer.com/currency_data/live?apikey=vWXIXCZLzPq1gX0a8oNMMF35RpWiNBvT";

        public string jPath = "$.quotes.";

        public JObject obj;

        public void CallAPI()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "&source=" + Globals.basecurrency);
            request.Method = "GET";
            using (var webresponse = (HttpWebResponse)request.GetResponse())
            {
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                using (var reader = new StreamReader(webresponse.GetResponseStream(), enc))
                {
                    obj = JObject.Parse(reader.ReadToEnd());
                }
            }
        }

        public void GetOutputCurrency()
        {
            Globals.results.Add(Math.Round((decimal)obj.SelectToken(jPath + Globals.basecurrency + Globals.outputCurrency), 5));
        }
    }
}
