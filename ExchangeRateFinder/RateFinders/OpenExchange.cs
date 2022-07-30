using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ExchangeRateFinder.RateFinders
{
    class OpenExchange : ISources
    {
        public string url = "https://openexchangerates.org/api/latest.json?app_id=1de86dfd996b4c9da20c0b3fa6eefaa4";

        public string jPath = "$.rates.";

        public JObject obj;

        public void CallAPI()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "&base=" + Globals.basecurrency);
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
            Globals.results.Add(Math.Round((decimal)obj.SelectToken(jPath + Globals.outputCurrency), 5));
        }
    }
}
