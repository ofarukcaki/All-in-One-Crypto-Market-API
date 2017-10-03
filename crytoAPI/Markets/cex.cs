using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace crytoAPI.Markets
{
    public class cex
    {
        public static string output;
        public static Cex myMarket = new Cex();


        public static string equations(string pair)
        {
            if (pair == "usd")
            {
                pair = "BTC/USD";
            }
            if( pair.EndsWith("btc"))
            {
                var altName = pair.Replace("btc", string.Empty);
                pair = (altName + "/btc").ToUpper();
            }
            return pair;
        }


        public static Cex getdata(string pair)
        {
            // Equations
            pair = pair == "fiat" ? "usd" : pair; //If pair is "fiat" than convert it to "usd" for api requests.
            pair = equations(pair);

            try
            {
                var task = fetchdata(pair);
                task.Wait();

                //return "asd";
                return myMarket;
            }
            catch
            {
                return null;
            }

            //return  fetchdata(pair).ToString();

        }


        public static async Task fetchdata(string pair)
        {
            var client = new HttpClient();
            //var fullurl = "https://cex.io/api/ticker/" + pair.Replace('_','/');
            var fullurl = "https://cex.io/api/ticker/" + pair;
            var result = await client.GetStringAsync(fullurl);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(result);

            myMarket.ask = r.ask;
            myMarket.bid = r.bid;
            myMarket.last = r.last;
            myMarket.volume = r.volume;
            myMarket.high = r.high;
            myMarket.low = r.low;


            //string output = JsonConvert.SerializeObject(myMarket);
            //output = myMarket;
            System.Diagnostics.Debug.WriteLine(myMarket);


        }


        public class Cex
        {
            public string ask { get; set; }
            public string bid { get; set; }
            public string last { get; set; }
            public string volume { get; set; }
            public string high { get; set; }
            public string low { get; set; }
        }

        public class RootObject
        {
            public string timestamp { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string last { get; set; }
            public string volume { get; set; }
            public string volume30d { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
        }

       
    }
}
