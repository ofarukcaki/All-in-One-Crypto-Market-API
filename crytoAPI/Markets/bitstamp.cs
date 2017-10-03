using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace crytoAPI.Markets
{
    public class bitstamp
    {
        public static string output;
        public static Bitstamp myMarket = new Bitstamp();

        public static string equations(string pair)
        {
            if (pair == "usd")
            {
                pair = "btcusd";
            }
            return pair;
        }

        public static Bitstamp getdata(string pair)
        {
            pair = pair == "fiat" ? "usd" : pair;
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

        //public string arrange(string tempPair)
        //{

        //}

        public static async Task fetchdata(string pair)
        {
            var client = new HttpClient();
            var fullurl = "https://www.bitstamp.net/api/v2/ticker/" + pair;
            var result = await client.GetStringAsync(fullurl);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(result);
            
            

            //Bitfinex myMarket = new Bitfinex();
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


        public class Bitstamp
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
            public string high { get; set; }
            public string last { get; set; }
            public string timestamp { get; set; }
            public string bid { get; set; }
            public string vwap { get; set; }
            public string volume { get; set; }
            public string low { get; set; }
            public string ask { get; set; }
            public string open { get; set; }
        }
    }
}
