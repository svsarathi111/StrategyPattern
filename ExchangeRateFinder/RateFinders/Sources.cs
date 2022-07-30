using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ExchangeRateFinder.RateFinders
{    
    abstract class Sources
    {
        public abstract string url { get; set; }

        public abstract string jPath { get; set; }

        public JObject obj;

        public void CallAPI()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            using (var webresponse = (HttpWebResponse)request.GetResponse())
            {
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                using (var reader = new StreamReader(webresponse.GetResponseStream(), enc))
                {
                    obj =  JObject.Parse(reader.ReadToEnd());
                }
            }
        }

        public dynamic GetOutputCurrency()
        {
            return Math.Round((decimal)obj.SelectToken(jPath), 5);
        }
    }
}
